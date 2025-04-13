Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.ComponentModel
Imports System.Data

Public Class FolioForm

    'Dim connect As New DataBaseManipulation()
    Dim montantTotal As Double = 0

    Structure SituationClient

        Dim dateOperation
        Dim libelleOperation
        Dim Debit
        Dim Credit
        Dim quantite
        Dim code
        Dim article
        Dim id

    End Structure

    '-------------------------- SITUATION DU CLIENT 
    Private Sub SituationDuClient()

        If Not GlobalVariable.codeClientToUpdate = "" Then

            Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate

            Dim elementFix As DataTable = Functions.getElementByCode(CODE_RESERVATION, "folio_element_fix", "CODE_RESERVATION")

            Dim CodeClient As String = GlobalVariable.codeClientToUpdate

            GunaLabelNomDuClient.Text = GlobalVariable.ClientToUpdate(0)("NOM_PRENOM")

            'On selectionne l'ensemble des reglements du client payés ou pas lié à la réservation
            Dim query As String = "SELECT CODE_FACTURE, CODE_ARTICLE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC, QUANTITE, PRIX_UNITAIRE_TTC, ID_LIGNE_FACTURE FROM ligne_facture WHERE CODE_RESERVATION = @CODE_RESERVATION AND ETAT_FACTURE = 0 AND CODE_AGENCE = @CODE_AGENCE ORDER BY DATE_FACTURE DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CodeClient
            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

            Dim adapter As New MySqlDataAdapter(command)
            Dim tableFacture As New DataTable()

            adapter.Fill(tableFacture)

            If Not Trim(GlobalVariable.ReservationToUpdate(0)("CODE_ENTREPRISE")).Equals("") Then
                CodeClient = GlobalVariable.ReservationToUpdate(0)("CODE_ENTREPRISE")
            End If


            'On selectionne l'ensemble des reglement du client
            Dim query1 As String = "SELECT REF_REGLEMENT, NUM_REGLEMENT,MONTANT_VERSE, DATE_REGLEMENT,QUANTITE, ID_REGLEMENT FROM reglement WHERE CODE_RESERVATION=@CODE_RESERVATION AND IMPRIMER = 0 ORDER BY DATE_REGLEMENT DESC"
            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
            command1.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CodeClient
            command1.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

            Dim adapter1 As New MySqlDataAdapter(command1)
            Dim tableReglement As New DataTable()

            adapter1.Fill(tableReglement)

            Dim tailleDuTableau As Integer = tableReglement.Rows.Count + tableFacture.Rows.Count

            'On crée une structure de tableau
            Dim toutesLesFactures(tailleDuTableau) As SituationClient

            Dim niemElementDutableau As Integer = 0

            Dim totalFacture As Double = 0
            Dim totalReglement As Double = 0

            'Insertion des reglements dans notre structure
            For i = 0 To tableReglement.Rows.Count - 1

                toutesLesFactures(i).dateOperation = tableReglement.Rows(i)("DATE_REGLEMENT")
                toutesLesFactures(i).Debit = 0
                toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
                toutesLesFactures(i).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")
                toutesLesFactures(i).quantite = tableReglement.Rows(i)("QUANTITE")
                toutesLesFactures(i).code = tableReglement.Rows(i)("NUM_REGLEMENT")
                toutesLesFactures(i).article = ""
                toutesLesFactures(i).id = tableReglement.Rows(i)("ID_REGLEMENT")

                totalReglement = totalReglement + tableReglement.Rows(i)("MONTANT_VERSE")
                niemElementDutableau = i

            Next

            niemElementDutableau += 1

            'Puis dans notre structure on ajoute les factures a la suite des reglements
            For i = 0 To tableFacture.Rows.Count - 1

                toutesLesFactures(niemElementDutableau).dateOperation = tableFacture.Rows(i)("DATE_FACTURE")
                toutesLesFactures(niemElementDutableau).Debit = tableFacture.Rows(i)("MONTANT_TTC")
                toutesLesFactures(niemElementDutableau).Credit = 0
                toutesLesFactures(niemElementDutableau).libelleOperation = tableFacture.Rows(i)("LIBELLE_FACTURE")
                'toutesLesFactures(niemElementDutableau).quantite = tableFacture.Rows(i)("QUANTITE")
                toutesLesFactures(niemElementDutableau).id = tableFacture.Rows(i)("ID_LIGNE_FACTURE")

                Dim QUANTITE As Double = 0

                If tableFacture.Rows(i)("QUANTITE") = 0 Then

                    If tableFacture.Rows(i)("PRIX_UNITAIRE_TTC") > 0 Then
                        QUANTITE = tableFacture.Rows(i)("MONTANT_TTC") / tableFacture.Rows(i)("PRIX_UNITAIRE_TTC")
                    End If

                Else
                    QUANTITE = tableFacture.Rows(i)("QUANTITE")
                End If

                toutesLesFactures(niemElementDutableau).quantite = QUANTITE
                toutesLesFactures(niemElementDutableau).code = tableFacture.Rows(i)("CODE_FACTURE")
                toutesLesFactures(niemElementDutableau).article = tableFacture.Rows(i)("CODE_ARTICLE")

                totalFacture = totalFacture + tableFacture.Rows(i)("MONTANT_TTC")
                niemElementDutableau += 1

            Next

            If elementFix.Rows.Count > 0 Then

                '1- SI LES ELEMENTS SONT FIXES

                'Enfin on insere le tout dans notre datagrid
                If toutesLesFactures.Length > 0 Then

                    If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then

                        If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then

                            GunaTextBoxCompanyName.Text = GlobalVariable.ReservationToUpdate.Rows(0)("NOM_ENTREPRISE")
                            GunaTextBoxEntreprise.Text = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")

                            Dim dt As DataGridView

                            Dim FOLIO As Integer = 0

                            For i = 0 To toutesLesFactures.Length - 1

                                FOLIO = restaurationDesElementsFixe(toutesLesFactures(i).id, CODE_RESERVATION, toutesLesFactures(i).Debit, toutesLesFactures(i).Credit, Trim(GunaTextBoxCompanyName.Text))

                                If FOLIO = 1 Then
                                    dt = GunaDataGridViewFolio1
                                ElseIf FOLIO = 2 Then
                                    dt = GunaDataGridViewFolio2
                                ElseIf FOLIO = 3 Then
                                    dt = GunaDataGridViewFolio3
                                ElseIf FOLIO = 4 Then
                                    dt = GunaDataGridViewFolio4
                                End If

                                If Not toutesLesFactures(i).libelleOperation = "" Then
                                    dt.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, toutesLesFactures(i).quantite, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"), toutesLesFactures(i).code, toutesLesFactures(i).article, toutesLesFactures(i).id)
                                End If

                            Next

                            dt.Sort(dt.Columns(0), ListSortDirection.Descending)
                            'dt.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                            soldeApresRestaurationDesElementsFixe()

                        End If

                    End If

                End If

            Else

                '2- SI LES ELEMENTS SONT NON FIXES

                'Enfin on insere le tout dans notre datagrid
                If (toutesLesFactures.Length > 0) Then

                    If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then

                        If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then

                            GunaTextBoxCompanyName.Text = GlobalVariable.ReservationToUpdate.Rows(0)("NOM_ENTREPRISE")
                            GunaTextBoxEntreprise.Text = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")

                            'Si le client n'est pas associe a une entreprise alors on charge dans le folio 1
                            If Trim(GunaTextBoxCompanyName.Text) = "" Then

                                For i = 0 To toutesLesFactures.Length - 1

                                    If Not toutesLesFactures(i).libelleOperation = "" Then
                                        GunaDataGridViewFolio1.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, toutesLesFactures(i).quantite, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"), toutesLesFactures(i).code, toutesLesFactures(i).article, toutesLesFactures(i).id)
                                    End If

                                Next

                                GunaDataGridViewFolio1.Sort(GunaDataGridViewFolio1.Columns(0), ListSortDirection.Descending)

                                GunaTextBoxSoldeFolio1.Text = Format(totalReglement - totalFacture, "#,##0")

                                GunaDataGridViewFolio1.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                                GunaTextBoxSoldeFolio2.Text = 0

                            Else

                                'Le client est associe a une entreprise alors on charge dans le folio 2
                                For i = 0 To toutesLesFactures.Length - 1

                                    If Not toutesLesFactures(i).libelleOperation = "" Then
                                        GunaDataGridViewFolio2.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, toutesLesFactures(i).quantite, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"), toutesLesFactures(i).code, toutesLesFactures(i).article, toutesLesFactures(i).id)
                                    End If

                                Next

                                'Sorting the elements of situation client
                                GunaDataGridViewFolio2.Sort(GunaDataGridViewFolio2.Columns(0), ListSortDirection.Descending)

                                GunaTextBoxSoldeFolio2.Text = Format(totalReglement - totalFacture, "#,##0")

                                'GunaDataGridViewFolio2.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                                GunaTextBoxSoldeFolio1.Text = 0

                            End If

                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub FolioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.folio(GlobalVariable.actualLanguageValue)

        SituationDuClient()

        If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then

            If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then

                '---------------------------------------------------------------------------------------------------
                'CO CHAMBRIER

                'Loading other 'article families cureently called article type into a combobox
                Dim existQuery As String = "SELECT CODE_CLIENT, NOM_PRENOM FROM `cochambrier` WHERE CODE_RESERVATION=@CODE_RESERVATION ORDER BY NOM_PRENOM ASC"

                Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
                command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GlobalVariable.codeReservationToUpdate

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                Dim existQuery01 As String = "SELECT CLIENT_ID AS CODE_CLIENT, NOM_CLIENT AS 'NOM_PRENOM' FROM `reserve_conf` WHERE CODE_RESERVATION=@CODE_RESERVATION ORDER BY NOM_CLIENT ASC"

                Dim command01 As New MySqlCommand(existQuery01, GlobalVariable.connect)
                command01.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GlobalVariable.codeReservationToUpdate

                Dim adapter01 As New MySqlDataAdapter(command01)
                Dim table01 As New DataTable()
                adapter01.Fill(table01)

                table.Merge(table01)

                If (table.Rows.Count > 0) Then

                    GunaComboBoxCoChambrier.DataSource = table
                    GunaComboBoxCoChambrier.ValueMember = "CODE_CLIENT"
                    GunaComboBoxCoChambrier.DisplayMember = "NOM_PRENOM"

                Else

                End If

                GunaComboBoxCoChambrier.SelectedValue = GlobalVariable.codeClientToUpdate
                '---------------------------------------------------------------------------------------------------

                GunaTextBoxCompanyName.Text = GlobalVariable.ReservationToUpdate.Rows(0)("NOM_ENTREPRISE")

                GunaTextBoxEntreprise.Text = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")

                Dim compte As DataTable = Functions.getElementByCode(Trim(GunaTextBoxEntreprise.Text), "compte", "CODE_CLIENT")

                If compte.Rows.Count > 0 Then

                    If Trim(GunaTextBoxCompanyName.Text) = "" Then
                        GunaTextBoxCompteDebiteur.Text = ""
                    Else
                        GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")
                    End If

                End If

            End If

        End If

        'Definition de qui paie la facture par défaut
        GunaComboBoxTypeFolio.SelectedIndex = 0 ' A savoir l'individu

    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonFermer_Click(sender As Object, e As EventArgs) Handles GunaButtonFermer.Click
        Me.Close()
    End Sub

    'Calcul des solde de chaque coté du folio
    Private Sub CalculDuSoldeDesFoliosApresBasculement()

        'Hiding the quantity column that will be used in the bill
        'GunaDataGridViewFolio1.Columns(2).Visible = False

        'A Chaque basculement on recupere le datatgrid entier et on calcul son montant total

        'On determine le solde du folio 2 A CHQUE BASCULEMENT
        Dim numberOfElemntsFolio2 As Integer = GunaDataGridViewFolio2.RowCount
        Dim montantTotalDebitFolio2 As Double = 0
        Dim montantTotalCreditFolio2 As Double = 0

        If numberOfElemntsFolio2 >= 0 Then

            Dim DebitFolio2 As Double = 0
            Dim CreditFolio2 As Double = 0

            For i = 0 To numberOfElemntsFolio2 - 1

                Double.TryParse(GunaDataGridViewFolio2.Rows(i).Cells(3).Value, montantTotalDebitFolio2)
                DebitFolio2 += montantTotalDebitFolio2

                Double.TryParse(GunaDataGridViewFolio2.Rows(i).Cells(4).Value, montantTotalCreditFolio2)
                CreditFolio2 += montantTotalCreditFolio2

            Next

            GunaTextBoxSoldeFolio2.Text = Format(CreditFolio2 - DebitFolio2, "#,##0")

            GunaDataGridViewFolio2.Sort(GunaDataGridViewFolio2.Columns(0), ListSortDirection.Descending)

        End If

        'On determine le solde du folio 1 A CHQUE BASCULEMENT
        Dim numberOfElemntsFolio1 As Integer = GunaDataGridViewFolio1.RowCount
        Dim montantTotalCreditFolio1 As Double = 0
        Dim montantTotalDebitFolio1 As Double = 0

        If numberOfElemntsFolio1 >= 0 Then

            Dim DebitFolio1 As Double = 0
            Dim CreditFolio1 As Double = 0

            For i = 0 To numberOfElemntsFolio1 - 1

                Double.TryParse(GunaDataGridViewFolio1.Rows(i).Cells(3).Value, montantTotalDebitFolio1)
                DebitFolio1 += montantTotalDebitFolio1

                Double.TryParse(GunaDataGridViewFolio1.Rows(i).Cells(4).Value, montantTotalCreditFolio1)
                CreditFolio1 += montantTotalCreditFolio1

            Next

            GunaTextBoxSoldeFolio1.Text = Format(CreditFolio1 - DebitFolio1, "#,##0")

            GunaDataGridViewFolio1.Sort(GunaDataGridViewFolio1.Columns(0), ListSortDirection.Descending)

        End If

        'On determine le solde du folio 3 A CHQUE BASCULEMENT
        Dim numberOfElemntsFolio3 As Integer = GunaDataGridViewFolio3.RowCount
        Dim montantTotalCreditFolio3 As Double = 0
        Dim montantTotalDebitFolio3 As Double = 0

        If numberOfElemntsFolio3 >= 0 Then

            Dim DebitFolio3 As Double = 0
            Dim CreditFolio3 As Double = 0

            For i = 0 To numberOfElemntsFolio3 - 1

                Double.TryParse(GunaDataGridViewFolio3.Rows(i).Cells(3).Value, montantTotalDebitFolio3)
                DebitFolio3 += montantTotalDebitFolio3

                Double.TryParse(GunaDataGridViewFolio3.Rows(i).Cells(4).Value, montantTotalCreditFolio3)
                CreditFolio3 += montantTotalCreditFolio3

            Next

            GunaTextBoxSoldeFolio3.Text = Format(CreditFolio3 - DebitFolio3, "#,##0")

            GunaDataGridViewFolio3.Sort(GunaDataGridViewFolio3.Columns(0), ListSortDirection.Descending)

        End If

        'On determine le solde du folio 4 A CHAQUE BASCULEMENT
        Dim numberOfElemntsFolio4 As Integer = GunaDataGridViewFolio4.RowCount
        Dim montantTotalCreditFolio4 As Double = 0
        Dim montantTotalDebitFolio4 As Double = 0

        If numberOfElemntsFolio4 >= 0 Then

            Dim DebitFolio4 As Double = 0
            Dim CreditFolio4 As Double = 0

            For i = 0 To numberOfElemntsFolio4 - 1

                Double.TryParse(GunaDataGridViewFolio4.Rows(i).Cells(3).Value, montantTotalDebitFolio4)
                DebitFolio4 += montantTotalDebitFolio4

                Double.TryParse(GunaDataGridViewFolio4.Rows(i).Cells(4).Value, montantTotalCreditFolio4)
                CreditFolio4 += montantTotalCreditFolio4

            Next

            GunaTextBoxSoldeFolio4.Text = Format(CreditFolio4 - DebitFolio4, "#,##0")

            GunaDataGridViewFolio4.Sort(GunaDataGridViewFolio4.Columns(0), ListSortDirection.Descending)

        End If

    End Sub

    'Basculement du folio1 pour le folio2
    Private Sub GunaButtonAJouterUn_Click(sender As Object, e As EventArgs) Handles GunaButtonMoveLeftToRight.Click

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
            GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio2.Rows.Add(selectedgrid)
        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Basculement du folio2 pour le folio1
    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButtonMoveRightToLeft.Click

        If GunaDataGridViewFolio2.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio2.SelectedRows(0)
            GunaDataGridViewFolio2.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio1.Rows.Add(selectedgrid)
        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Folio 1  vers folio 3
    Private Sub GunaButtonBottomLeft_Click(sender As Object, e As EventArgs) Handles GunaButtonBottomLeft.Click

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
            GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio3.Rows.Add(selectedgrid)
        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Tous Folio 1 vers folio 3
    Private Sub GunaButtonAllBottomLeft_Click(sender As Object, e As EventArgs) Handles GunaButtonAllBottomLeft.Click

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio1.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
                GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio3.Rows.Add(selectedgrid)
            Loop

        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Folio 3 vers folio 1
    Private Sub GunaButtonTopLeft_Click(sender As Object, e As EventArgs) Handles GunaButtonTopLeft.Click

        If GunaDataGridViewFolio3.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio3.SelectedRows(0)
            GunaDataGridViewFolio3.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio1.Rows.Add(selectedgrid)
        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Tous Folio 3 vers folio 1
    Private Sub GunaButtonAllTopLeft_Click(sender As Object, e As EventArgs) Handles GunaButtonAllTopLeft.Click

        If GunaDataGridViewFolio3.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio3.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio3.SelectedRows(0)
                GunaDataGridViewFolio3.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio1.Rows.Add(selectedgrid)
            Loop

        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Folio 1 vers Folio 4
    Private Sub GunaButtonBottomRight_Click(sender As Object, e As EventArgs) Handles GunaButtonBottomRight.Click

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
            GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio4.Rows.Add(selectedgrid)
        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Tous Folio 1 vers Folio 4
    Private Sub GunaButtonAllBottomRight_Click(sender As Object, e As EventArgs) Handles GunaButtonAllBottomRight.Click

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio1.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
                GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio4.Rows.Add(selectedgrid)
            Loop

        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Folio 4 vers Folio 1
    Private Sub GunaButtonTopRight_Click(sender As Object, e As EventArgs) Handles GunaButtonTopRight.Click

        If GunaDataGridViewFolio4.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio4.SelectedRows(0)
            GunaDataGridViewFolio4.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio1.Rows.Add(selectedgrid)
        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Tous Folio 4 vers Folio 1
    Private Sub GunaButtonAllTopRight_Click(sender As Object, e As EventArgs) Handles GunaButtonAllTopRight.Click

        If GunaDataGridViewFolio4.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio4.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio4.SelectedRows(0)
                GunaDataGridViewFolio4.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio1.Rows.Add(selectedgrid)
            Loop

        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Move everything found in the left to the right
    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButtonAllToRight.Click

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio1.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
                GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio2.Rows.Add(selectedgrid)
            Loop

        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Move everything found in the right to the left
    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButtonAllToLeft.Click

        If GunaDataGridViewFolio2.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio2.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio2.SelectedRows(0)
                GunaDataGridViewFolio2.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio1.Rows.Add(selectedgrid)
            Loop

        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Folio 3 vers Folio 4
    Private Sub GunaButtonBottomLeftToRight_Click(sender As Object, e As EventArgs) Handles GunaButtonBottomLeftToRight.Click

        If GunaDataGridViewFolio3.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio3.SelectedRows(0)
            GunaDataGridViewFolio3.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio4.Rows.Add(selectedgrid)
        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Tous Folio 3 vers Folio 4
    Private Sub GunaButtonAllBottomLeftToRight_Click(sender As Object, e As EventArgs) Handles GunaButtonAllBottomLeftToRight.Click

        If GunaDataGridViewFolio3.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio3.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio3.SelectedRows(0)
                GunaDataGridViewFolio3.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio4.Rows.Add(selectedgrid)
            Loop

        End If

    End Sub

    'Folio 4 vers Folio 3
    Private Sub GunaButtonBottomRightToLeft_Click(sender As Object, e As EventArgs) Handles GunaButtonBottomRightToLeft.Click

        If GunaDataGridViewFolio4.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio4.SelectedRows(0)
            GunaDataGridViewFolio4.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio3.Rows.Add(selectedgrid)
        End If

        'Calcul du solde de chaque folio apres basculement
        CalculDuSoldeDesFoliosApresBasculement()

    End Sub

    'Tous Folio 4 vers Folio 3
    Private Sub GunaButtonAllBottomRightToLeft_Click(sender As Object, e As EventArgs) Handles GunaButtonAllBottomRightToLeft.Click

        If GunaDataGridViewFolio4.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio4.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio4.SelectedRows(0)
                GunaDataGridViewFolio4.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio3.Rows.Add(selectedgrid)
            Loop

        End If


    End Sub

    '--------------------------------------GESTION DE L'IMPRESSION DE LA FACTURE -------------------------------------

    Public Shared Function chargementTemporaireDesElementsDeFacturePourImpression(ByVal dt As DataTable) As DataTable

        If dt.Rows.Count > 0 Then

            Functions.deleteAll("print_facture_reglement_temp")

            Dim insertQuery As String = ""

            Dim MONTANT As Double = 0

            For i = 0 To dt.Rows.Count - 1

                insertQuery = "INSERT INTO `print_facture_reglement_temp`(`DATE_ELEMT`, `LIBELLE_ELEMENT`, `QUANTITE`, `MONTANT`, `ID`) VALUES (@value1, @value2, @value3, @value4, @value5)"

                Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

                If Not Trim(dt.Rows(i)(3)).Equals("") And Not Trim(dt.Rows(i)(4)).Equals("") Then

                    If Double.Parse(dt.Rows(i)(3)) > 0 Then
                        MONTANT = Double.Parse(dt.Rows(i)(3)) * -1
                    ElseIf Double.Parse(dt.Rows(i)(3)) < 0 Then
                        MONTANT = Double.Parse(dt.Rows(i)(3)) * -1
                    ElseIf Double.Parse(dt.Rows(i)(4)) > 0 Then
                        MONTANT = Double.Parse(dt.Rows(i)(4))
                    ElseIf Double.Parse(dt.Rows(i)(4)) < 0 Then
                        MONTANT = Double.Parse(dt.Rows(i)(4))
                    Else
                        MONTANT = 0
                    End If

                End If

                command.Parameters.Add("@value1", MySqlDbType.Date).Value = CDate(dt.Rows(i)(0))
                command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = dt.Rows(i)(1)
                command.Parameters.Add("@value3", MySqlDbType.Double).Value = dt.Rows(i)(2)
                command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT
                command.Parameters.Add("@value5", MySqlDbType.Double).Value = dt.Rows(i)(8)

                command.ExecuteNonQuery()

            Next

            Dim query As String = "SELECT `DATE_ELEMT`, `LIBELLE_ELEMENT`, `QUANTITE`, `MONTANT`, `ID` FROM `print_facture_reglement_temp` ORDER BY DATE_ELEMT DESC"
            Dim command1 As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command1)
            Dim elements As New DataTable()

            adapter.Fill(elements)

            'Enfin on insere le tout dans notre datagrid
            If (elements.Rows.Count > 0) Then

                'Functions.deleteAll("print_facture_reglement_temp")

                Return elements

            End If

        End If

    End Function

    Private Async Sub DocumentToPrint(ByVal Optional cloturer As String = "")

        Dim TELEPHONE As String = ""

        Dim signe As Integer = -1
        If GlobalVariable.AgenceActuelle.Rows(0)("INVERSER_SIGNE_FACTURE") = 1 Then
            signe *= -1
        End If

        Dim sfd As New SaveFileDialog With {.Filter = "PDF Files (*.pdf) | *.pdf"}

        If GlobalVariable.actualLanguageValue = 1 Then
            sfd.FileName = "Facture de " & GlobalVariable.ClientToUpdate.Rows(0)("NOM_PRENOM") & " " & (Date.Now().ToString("ddMMyyHHmmss"))

        Else
            sfd.FileName = "Bill of " & GlobalVariable.ClientToUpdate.Rows(0)("NOM_PRENOM") & " " & (Date.Now().ToString("ddMMyyHHmmss"))

        End If

        Dim dateArrivee As Date = GlobalVariable.ReservationToUpdate.Rows(0)("DATE_ENTTRE")
        Dim dateDepart As Date = GlobalVariable.ReservationToUpdate.Rows(0)("DATE_SORTIE")

        Dim titreFichier As String = ""

        Dim nomDuDossierRapport As String = "ENVOI\FACTURES"

        Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        If GlobalVariable.actualLanguageValue = 1 Then
            titreFichier = "Facture de " & GlobalVariable.ClientToUpdate.Rows(0)("NOM_PRENOM") & " " & (Date.Now().ToString("ddMMyyHHmmss"))

        Else
            titreFichier = "Bill of " & GlobalVariable.ClientToUpdate.Rows(0)("NOM_PRENOM") & " " & (Date.Now().ToString("ddMMyyHHmmss"))

        End If

        Dim fichier As String = filePathAndDirectory & "\" & titreFichier & ".pdf"

        If sfd.ShowDialog = 1 Then
            '
            Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 50)
            Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create))
            Dim pdfWriteFichier As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

            'pdfWrite.PageEvent = New HeaderFooter

            Dim pdfTable As New PdfPTable(4) 'Number of columns
            pdfTable.TotalWidth = 520.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
            pdfTable.SetWidths(widths)

            Dim pdfCell As PdfPCell = Nothing

            pdfWrite.PageEvent = New HeaderFooter
            pdfWriteFichier.PageEvent = New HeaderFooter

            pdfWrite.SetMargins(150.0F, 15.0F, 150.0F, 150.0F)
            pdfWriteFichier.SetMargins(150.0F, 15.0F, 150.0F, 150.0F)

            pdfDoc.Open()

            If GlobalVariable.actualLanguageValue = 1 Then

                Dim p1 As Paragraph = New Paragraph(Chr(13) & Chr(13) & Chr(13) & "FACTURE No : " & Functions.GeneratingRandomCodeWithSpecifications("facture", "") & Chr(13) & "DATE : " & GlobalVariable.DateDeTravail & Chr(13) & "DATE ARRIVEE : " & dateArrivee.ToShortDateString & Chr(13) & "DATE DEPART : " & dateDepart.ToShortDateString & Chr(13), pColumn)
                p1.Alignment = Element.ALIGN_LEFT
                pdfDoc.Add(p1)

            Else

                Dim p1 As Paragraph = New Paragraph(Chr(13) & Chr(13) & Chr(13) & "INVOICE No : " & Functions.GeneratingRandomCodeWithSpecifications("facture", "") & Chr(13) & "DATE : " & GlobalVariable.DateDeTravail & Chr(13) & "ARRIVAL DATE : " & dateArrivee.ToShortDateString & Chr(13) & "DEPARTURE DATE : " & dateDepart.ToShortDateString & Chr(13), pColumn)
                p1.Alignment = Element.ALIGN_LEFT
                pdfDoc.Add(p1)

            End If

            Dim societe As DataTable = Functions.allTableFields("societe")
            Dim clientInformation As DataTable
            Dim clientEntrepriseInformation As DataTable

            If GlobalVariable.FolioToPrint = "Folio2" Then
                'Association de la facture à un client
                clientEntrepriseInformation = Functions.getElementByCode(Trim(GunaTextBoxEntreprise.Text), "client", "CODE_CLIENT")
            Else

            End If

            If GunaComboBoxCoChambrier.Items.Count > 0 Then
                clientInformation = Functions.getElementByCode(GunaComboBoxCoChambrier.SelectedValue.ToString, "client", "CODE_CLIENT")
            End If

            Dim listeDesCompagnons As String

            If Not GlobalVariable.codeClientToUpdate = "" Then

                Dim termes As String = ""

                If GlobalVariable.FolioToPrint = "Folio2" Then

                    '------------------ ON DOIT AFFICHER LA LISTE COMPLETE DES NOMS DES COMPAGNONS ------------------------

                    If Not GunaCheckBoxTousLesCompagnons.Checked Then

                        'AFFICHAGE INDIVIDUEL

                        If clientEntrepriseInformation.Rows.Count > 0 Then

                            If GlobalVariable.actualLanguageValue = 1 Then
                                termes = Chr(13) & "NOM ET PRENOM : " & clientEntrepriseInformation.Rows(0)("NOM_PRENOM") & " (" & clientInformation.Rows(0)("NOM_PRENOM") & " ) " & Chr(13) & clientEntrepriseInformation.Rows(0)("NOM_JEUNE_FILLE") & Chr(13) & clientEntrepriseInformation.Rows(0)("PRENOMS") & Chr(13) & "CHAMBRE N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMERO : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)

                            Else
                                termes = Chr(13) & "FIRST AND LAST NAME : " & clientEntrepriseInformation.Rows(0)("NOM_PRENOM") & " (" & clientInformation.Rows(0)("NOM_PRENOM") & " ) " & Chr(13) & clientEntrepriseInformation.Rows(0)("NOM_JEUNE_FILLE") & Chr(13) & clientEntrepriseInformation.Rows(0)("PRENOMS") & Chr(13) & "ROMM N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMBER : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)

                            End If

                        Else

                            If clientInformation.Rows.Count > 0 Then

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    termes = Chr(13) & "NOM ET PRENOM : " & clientInformation.Rows(0)("NOM_PRENOM") & Chr(13) & "CHAMBRE N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMERO : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)
                                Else
                                    termes = Chr(13) & "FIRST AND LAST NAME : " & clientInformation.Rows(0)("NOM_PRENOM") & Chr(13) & "ROMM N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMBER : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)
                                End If

                            End If

                        End If

                    Else

                        'AFFICHAGE DE L'ENSEMBLE DES CLIENTS

                        Dim existQuery As String = "SELECT CODE_CLIENT, NOM_PRENOM FROM `cochambrier` WHERE CODE_RESERVATION=@CODE_RESERVATION ORDER BY NOM_PRENOM ASC"

                        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
                        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GlobalVariable.codeReservationToUpdate

                        Dim adapter As New MySqlDataAdapter(command)
                        Dim compagnons As New DataTable()
                        adapter.Fill(compagnons)

                        For i = 0 To compagnons.Rows.Count - 1
                            If i = 0 Then
                                listeDesCompagnons = compagnons.Rows(i)("NOM_PRENOM")
                            Else
                                listeDesCompagnons += " / " & compagnons.Rows(i)("NOM_PRENOM")
                            End If
                        Next

                    End If

                    If clientEntrepriseInformation.Rows.Count > 0 Then

                        If GlobalVariable.actualLanguageValue = 1 Then
                            termes = Chr(13) & "NOM ET PRENOM : " & clientEntrepriseInformation.Rows(0)("NOM_PRENOM") & " (" & clientInformation.Rows(0)("NOM_PRENOM") & listeDesCompagnons & " ) " & Chr(13) & clientEntrepriseInformation.Rows(0)("NOM_JEUNE_FILLE") & Chr(13) & clientEntrepriseInformation.Rows(0)("PRENOMS") & Chr(13) & "CHAMBRE N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMERO : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)

                        Else
                            termes = Chr(13) & "FIRST AND LAST NAME : " & clientEntrepriseInformation.Rows(0)("NOM_PRENOM") & " (" & clientInformation.Rows(0)("NOM_PRENOM") & listeDesCompagnons & " ) " & Chr(13) & clientEntrepriseInformation.Rows(0)("NOM_JEUNE_FILLE") & Chr(13) & clientEntrepriseInformation.Rows(0)("PRENOMS") & Chr(13) & "ROOM N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMBER : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)

                        End If

                    Else

                        If clientInformation.Rows.Count > 0 Then

                            If GlobalVariable.actualLanguageValue = 1 Then
                                termes = Chr(13) & "NOM ET PRENOM : " & clientInformation.Rows(0)("NOM_PRENOM") & listeDesCompagnons & Chr(13) & "CHAMBRE N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMERO : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)

                            Else
                                termes = Chr(13) & "FIRST AND LAST NAME : " & clientInformation.Rows(0)("NOM_PRENOM") & listeDesCompagnons & Chr(13) & "ROOM N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMBER : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)

                            End If

                        End If

                    End If

                Else

                    If GunaCheckBoxTousLesCompagnons.Checked Then

                        'AFFICHAGE DE L'ENSEMBLE DES CLIENTS

                        Dim existQuery As String = "SELECT CODE_CLIENT, NOM_PRENOM FROM `cochambrier` WHERE CODE_RESERVATION=@CODE_RESERVATION ORDER BY NOM_PRENOM ASC"

                        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
                        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GlobalVariable.codeReservationToUpdate

                        Dim adapter As New MySqlDataAdapter(command)
                        Dim compagnons As New DataTable()
                        adapter.Fill(compagnons)

                        For i = 0 To compagnons.Rows.Count - 1
                            If i = 0 Then
                                listeDesCompagnons = " / " & compagnons.Rows(i)("NOM_PRENOM") & " / "
                            ElseIf i = compagnons.Rows.Count - 1 Then
                                listeDesCompagnons += compagnons.Rows(i)("NOM_PRENOM")
                            Else
                                listeDesCompagnons += compagnons.Rows(i)("NOM_PRENOM") & " / "
                            End If
                        Next

                    End If

                    If clientInformation.Rows.Count > 0 Then

                        If GlobalVariable.actualLanguageValue = 1 Then
                            termes = Chr(13) & "NOM ET PRENOM : " & clientInformation.Rows(0)("NOM_PRENOM") & listeDesCompagnons & Chr(13) & "CHAMBRE N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMERO : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)

                        Else
                            termes = Chr(13) & "FIRST AND LAST NAME : " & clientInformation.Rows(0)("NOM_PRENOM") & listeDesCompagnons & Chr(13) & "ROOM N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION NUMBER : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13) & Chr(13)

                        End If

                    End If

                End If

                pdfDoc.Add(New Paragraph(termes, pColumn))

            End If

            pdfCell = New PdfPCell(New Paragraph("DATE", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 18
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DESIGNATION", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 18
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("QTY", pColumn))
            Else
                pdfCell = New PdfPCell(New Paragraph("QTE", pColumn))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 18
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 18
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            Dim dtFromFolio As DataTable
            Dim dt As DataTable

            If GlobalVariable.FolioToPrint = "Folio1" Then
                dtFromFolio = GetDataTableFolioN(GunaDataGridViewFolio1)
            ElseIf GlobalVariable.FolioToPrint = "Folio2" Then
                dtFromFolio = GetDataTableFolioN(GunaDataGridViewFolio2)
            ElseIf GlobalVariable.FolioToPrint = "Folio3" Then
                dtFromFolio = GetDataTableFolioN(GunaDataGridViewFolio3)
            ElseIf GlobalVariable.FolioToPrint = "Folio4" Then
                dtFromFolio = GetDataTableFolioN(GunaDataGridViewFolio4)
            End If
            'kklg
            dt = chargementTemporaireDesElementsDeFacturePourImpression(dtFromFolio)

            Dim exonere As Boolean = Functions.exonereDelaTVAComplet(GlobalVariable.codeReservationToUpdate)

            If dt.Rows.Count > 0 Then'

                TotalVersement = 0
                'TotalFacture = 0
                totalTVA = 0
                taxeSejour = 0

                For i = 0 To dt.Rows.Count - 1

                    pdfCell = New PdfPCell(New Paragraph(CDate(dt.Rows(i)(0)).ToShortDateString, pRow))
                    pdfCell.MinimumHeight = 18
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(dt.Rows(i)(1), pRow))
                    pdfCell.MinimumHeight = 18
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(dt.Rows(i)(2), pRow))
                    pdfCell.MinimumHeight = 18
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfCell)

                    Dim MONTANT_INVERSE As Double = dt.Rows(i)("MONTANT")
                    If MONTANT_INVERSE < 0 Then
                        MONTANT_INVERSE *= signe * -1
                    End If

                    If GlobalVariable.AgenceActuelle.Rows(0)("INVERSER_SIGNE_FACTURE") = 1 Then
                        pdfCell = New PdfPCell(New Paragraph(Format(MONTANT_INVERSE, "#,##0"), pRow))
                    Else
                        pdfCell = New PdfPCell(New Paragraph(Format(dt.Rows(i)("MONTANT"), "#,##0"), pRow))
                    End If

                    pdfCell.MinimumHeight = 18
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT

                    pdfTable.AddCell(pdfCell)

                    'TAXE DE SEJOURS
                    If dt.Rows(i)(3) < 0 Then

                        Dim LIBELLE_TAXE As String = "TAXE DE SEJOUR"
                        If GlobalVariable.actualLanguageValue = 1 Then
                            LIBELLE_TAXE = "TAXE DE SEJOUR"
                        Else
                            LIBELLE_TAXE = "TOURIST TAX"
                        End If

                        Dim LIBELLE_FACTURE As String = dt.Rows(i)(1).ToString.ToUpper()
                        totalTVA += Functions.prelevementDeTaxeSurUnMontantPOurCalcul(dt.Rows(i)(3))

                        If LIBELLE_FACTURE.Contains(LIBELLE_TAXE) Then
                            taxeSejour += Functions.NonprelevementDeTaxeSurUnMontant(dt.Rows(i)(3))
                        Else

                            If exonere Then
                                'ON NE PRELEVE PAS LA TAXE SUR LES CHARGES 'SI TAXE ACTIVE
                                'totalTVA += Functions.NonprelevementDeTaxeSurUnMontant(dt.Rows(i)(3))
                                totalTVA = 0
                            End If

                        End If

                    End If

                Next

                pdfDoc.Add(pdfTable)

                If TotalFacture < 0 Then
                    TotalFacture *= -1
                End If

                If TotalVersement < 0 Then
                    TotalFacture *= -1
                End If

                If totalTVA < 0 Then
                    totalTVA *= -1
                End If

                If taxeSejour < 0 Then
                    taxeSejour *= -1
                End If

                Dim pdfTable2 As New PdfPTable(4) 'Number of columns

                pdfTable2.TotalWidth = 520.0F
                pdfTable2.LockedWidth = True
                pdfTable2.HorizontalAlignment = Element.ALIGN_RIGHT
                'pdfTable2.HeaderRows = 1

                Dim widths2 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                pdfTable2.SetWidths(widths2)

                Dim pdfCell2 As PdfPCell = Nothing

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell2 = New PdfPCell(New Paragraph(Chr(13) & "TOTAL HT : ", fontTotal))
                Else
                    pdfCell2 = New PdfPCell(New Paragraph(Chr(13) & "TOTAL ET : ", fontTotal))
                End If

                pdfCell2.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell2.MinimumHeight = 18
                pdfCell2.PaddingLeft = 15.0F
                pdfCell2.Border = 0
                pdfCell2.Colspan = 3
                pdfTable2.AddCell(pdfCell2)

                pdfCell2 = New PdfPCell(New Paragraph(Chr(13) & Format(TotalFacture - totalTVA - taxeSejour, "#,##0"), fontTotal))
                pdfCell2.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell2.MinimumHeight = 18
                pdfCell2.PaddingLeft = 5.0F
                pdfCell2.Border = 0
                pdfTable2.AddCell(pdfCell2)

                pdfDoc.Add(pdfTable2)

                '-----------------------------------

                Dim pdfTable4 As New PdfPTable(4) 'Number of columns

                pdfTable4.TotalWidth = 520.0F
                pdfTable4.LockedWidth = True
                pdfTable4.HorizontalAlignment = Element.ALIGN_RIGHT
                'pdfTable4.HeaderRows = 1

                Dim widths4 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                pdfTable4.SetWidths(widths2)

                Dim pdfCell4 As PdfPCell = Nothing

                Dim TVA As Double = 0

                'SI LE CLIENT N'ES PAS EXONERE DE LA TVA ALORS ON CALCUL LA TVA SI ACTIVE

                If Not exonere Then

                    If societe.Rows(0)("TAUX_TVA") > 0 Then
                        'TVA ACTIVE
                        TVA = totalTVA
                    Else
                        'TVA NON ACTIVE
                        TVA = 0
                    End If

                End If

                If taxeSejour > 0 Then

                    '-----------------------------------

                    Dim pdfTable6 As New PdfPTable(4) 'Number of columns

                    pdfTable6.TotalWidth = 520.0F
                    pdfTable6.LockedWidth = True
                    pdfTable6.HorizontalAlignment = Element.ALIGN_RIGHT
                    'pdfTable4.HeaderRows = 1

                    Dim widths6 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                    pdfTable6.SetWidths(widths6)

                    Dim pdfCell6 As PdfPCell = Nothing

                    If GlobalVariable.actualLanguageValue = 1 Then
                        pdfCell6 = New PdfPCell(New Paragraph("TAXE DE SEJOURS : ", fontTotal))
                    Else
                        pdfCell6 = New PdfPCell(New Paragraph("TOURIST TAX : ", fontTotal))
                    End If

                    pdfCell6.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell6.MinimumHeight = 18
                    pdfCell6.PaddingLeft = 15.0F
                    pdfCell6.Border = 0
                    pdfCell6.Colspan = 3
                    pdfTable6.AddCell(pdfCell6)

                    Dim TAXE_SEJOUR As Double = 0

                    pdfCell6 = New PdfPCell(New Paragraph(Format(taxeSejour, "#,##0"), fontTotal))
                    pdfCell6.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell6.MinimumHeight = 18
                    pdfCell6.PaddingLeft = 5.0F
                    pdfCell6.Border = 0
                    pdfTable6.AddCell(pdfCell6)

                    pdfDoc.Add(pdfTable6)

                    '-----------------------------------
                End If

                If TVA > 0 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        pdfCell4 = New PdfPCell(New Paragraph("TVA : ", fontTotal))
                    Else
                        pdfCell4 = New PdfPCell(New Paragraph("VAT : ", fontTotal))
                    End If

                    pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell4.MinimumHeight = 18
                    pdfCell4.PaddingLeft = 15.0F
                    pdfCell4.Border = 0
                    pdfCell4.Colspan = 3
                    pdfTable4.AddCell(pdfCell4)

                    pdfCell4 = New PdfPCell(New Paragraph(Format(TVA, "#,##0"), fontTotal))
                    pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell4.MinimumHeight = 18
                    pdfCell4.PaddingLeft = 5.0F
                    pdfCell4.Border = 0
                    pdfTable4.AddCell(pdfCell4)

                    pdfDoc.Add(pdfTable4)

                    Dim pdfTable3 As New PdfPTable(4) 'Number of columns

                    pdfTable3.TotalWidth = 520.0F
                    pdfTable3.LockedWidth = True
                    pdfTable3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfTable3.HeaderRows = 1

                    Dim widths3 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                    pdfTable3.SetWidths(widths3)

                    Dim pdfCell3 As PdfPCell = Nothing

                    pdfCell3 = New PdfPCell(New Paragraph("", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph("----------------", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        pdfCell3 = New PdfPCell(New Paragraph("TOTAL TTC : ", fontTotal))
                    Else
                        pdfCell3 = New PdfPCell(New Paragraph("TOTAL IT : ", fontTotal))
                    End If

                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)


                    pdfCell3 = New PdfPCell(New Paragraph(Format(TotalFacture, "#,##0"), fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 5.0F
                    pdfCell3.Border = 0
                    pdfTable3.AddCell(pdfCell3)

                    pdfDoc.Add(pdfTable3)

                    '-----------------------------------------------------

                Else

                    Dim pdfTable3 As New PdfPTable(4) 'Number of columns

                    pdfTable3.TotalWidth = 520.0F
                    pdfTable3.LockedWidth = True
                    pdfTable3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfTable3.HeaderRows = 1

                    Dim widths3 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                    pdfTable3.SetWidths(widths3)

                    Dim pdfCell3 As PdfPCell = Nothing

                    pdfCell3 = New PdfPCell(New Paragraph("", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph("----------------", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        pdfCell3 = New PdfPCell(New Paragraph("TOTAL : ", fontTotal))
                    Else
                        pdfCell3 = New PdfPCell(New Paragraph("TOTAL : ", fontTotal))
                    End If

                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph(Format(TotalFacture, "#,##0"), fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 5.0F
                    pdfCell3.Border = 0
                    pdfTable3.AddCell(pdfCell3)

                    pdfDoc.Add(pdfTable3)

                End If

                Dim pdfTable7 As New PdfPTable(4) 'Number of columns

                pdfTable7.TotalWidth = 520.0F
                pdfTable7.LockedWidth = True
                pdfTable7.HorizontalAlignment = Element.ALIGN_RIGHT
                'pdfTable7.HeaderRows = 1

                Dim widths7 As Single() = New Single() {1.2F, 6.5F, 1.0F, 1.5F}
                pdfTable7.SetWidths(widths7)

                Dim pdfCell7 As PdfPCell = Nothing

                TotalVersement = TotalReglementFacture
                Dim soldeNet As Double = 0
                soldeNet = TotalVersement - (TotalFacture)

                Dim terme As String = ""

                If soldeNet > 0 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        terme = "FAVEUR CLIENT : "

                    Else
                        terme = "CLIENT FAVOR : "


                    End If

                ElseIf soldeNet = 0 Then
                    If GlobalVariable.actualLanguageValue = 1 Then
                        terme = "SOLDE NUL : "

                    Else
                        terme = "NULL BALANCE : "

                    End If
                ElseIf 0 > soldeNet Then
                    If GlobalVariable.actualLanguageValue = 1 Then
                        terme = "A REGLER : "
                    Else
                        terme = "TO PAY : "
                    End If
                End If

                pdfCell7 = New PdfPCell(New Paragraph(terme, fontTotal))
                pdfCell7.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell7.MinimumHeight = 18
                pdfCell7.PaddingLeft = 15.0F
                pdfCell7.Border = 0
                pdfCell7.Colspan = 3
                pdfTable7.AddCell(pdfCell7)

                If soldeNet < 0 Then
                    soldeNet *= signe * -1
                End If

                pdfCell7 = New PdfPCell(New Paragraph(Format(soldeNet, "#,##0"), fontTotal))
                pdfCell7.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell7.MinimumHeight = 18
                pdfCell7.PaddingLeft = 5.0F
                pdfCell7.Border = 0
                pdfTable7.AddCell(pdfCell7)

                pdfDoc.Add(pdfTable7)

                '---------------------------------------------------------

                'generation des factures et ligne factures apres cloture

                If Not Trim(cloturer) = "" Then

                    Dim facture As New Facture()
                    Dim ligneFacture As New LigneFacture()
                    Dim reglement As New Reglement()
                    Dim compte As New Compte()

                    Dim CODE_FACTURE As String = Functions.GeneratingRandomCodeWithSpecifications("facture", "")
                    Dim CODE_COMMANDE As String = ""
                    Dim NUMERO_TABLE As String = ""
                    Dim CODE_MODE_PAIEMENT As String = ""

                    Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                    Dim NUM_MOUVEMENT As String = ""
                    Dim DATE_FACTURE As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
                    Dim CODE_COMMERCIAL As String = ""
                    Dim AVANCE As Double = TotalVersement
                    Dim RESTE_A_PAYER As Double = TotalVersement - (TotalFacture)
                    Dim DATE_PAIEMENT As Date
                    Dim ETAT_FACTURE As Integer = 1

                    Dim MONTANT_HT As Double = TotalFacture
                    Dim TAXE As Double = totalTVA + taxeSejour
                    Dim MONTANT_TTC As Double = TotalFacture

                    Dim MONTANT_TRANSPORT As Double = 0
                    Dim MONTANT_REMISE As Double = 0
                    Dim CODE_UTILISATEUR_ANNULE As String = ""
                    Dim CODE_UTILISATEUR_VALIDE As String = ""
                    Dim NOM_CLIENT_FACTURE As String = ""
                    Dim MONTANT_AVANCE As Double = TotalVersement

                    Dim CODE_CLIENT As String = ""
                    Dim LIBELLE_FACTURE As String = ""
                    Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")


                    If GlobalVariable.FolioToPrint = "Folio2" Then
                        'INFORMATION DE L'ENTREPRISE PRENNANT LA PRISE EN CHARGE
                        If clientEntrepriseInformation.Rows.Count > 0 Then
                            CODE_CLIENT = clientEntrepriseInformation.Rows(0)("CODE_CLIENT")
                            LIBELLE_FACTURE = clientEntrepriseInformation.Rows(0)("NOM_PRENOM") + " [ " & GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT") & " / " & GlobalVariable.ReservationToUpdate.Rows(0)("CHAMBRE_ID") & " ] " + Now().ToLongTimeString
                            NOM_CLIENT_FACTURE = clientEntrepriseInformation.Rows(0)("NOM_PRENOM")
                        End If

                    Else

                        If clientInformation.Rows.Count > 0 Then
                            CODE_CLIENT = clientInformation.Rows(0)("CODE_CLIENT")
                            LIBELLE_FACTURE = clientInformation.Rows(0)("NOM_PRENOM")
                            NOM_CLIENT_FACTURE = clientInformation.Rows(0)("NOM_PRENOM")
                        End If

                    End If

                    Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                    Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate

                    If GlobalVariable.FolioToPrint = "Folio2" Then

                        'EN CAS DE CLOTURE DANS LE FOLIO ENTREPRISE
                        '-----------------------------------------------------------
                        'L'ENTREPRISE POUVANT ETRE ASSOCIEE A PLUS D'UNE RESERVATION DIRECTE, ON PEUT DONC LA RETROUVER PAR APPORT AU CODE DE CE DERNIER

                        Dim ETAT_RESERVATION = 1

                        'Dim reservationEntreprise As DataTable = Functions.GetAllElementsOnTwoConditions(Trim(GunaTextBoxEntreprise.Text), "reserve_conf", "CLIENT_ID", ETAT_RESERVATION, "ETAT_RESERVATION")

                        Dim reservationEntreprise As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

                        If reservationEntreprise.Rows.Count > 0 Then

                            CODE_RESERVATION = reservationEntreprise.Rows(0)("CODE_RESERVATION")
                            CODE_CLIENT = Trim(GunaTextBoxEntreprise.Text) 'ENTREPRISE

                            Dim CODE_RESERVATION_INDIVIDU = GlobalVariable.codeReservationToUpdate

                            'MISE A JOURS DU SOLDE DE L'INDIVIDU ET DU SOLDE DE L'ENTREPRISE PAR APPORT AU MONTANT TOTAL DE LA FACTURE
                            '-----------------------------------------------------------

                            'MISE A JOURS DU SOLDE DE LA RESERVATION EN COURS APRES TRANSFERT DE CHARGE OU REGLEMENT

                            'EN PLUS DANS L'ENTREPRISE
                            'reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))

                            'EN MOINS CHEZ L'INDIVIDU
                            'reservation.updateSoldeReservation(CODE_RESERVATION_INDIVIDU, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION_INDIVIDU))

                            '----------------------------------------------------------------------

                            Dim CODE_ENTREPRISE As String = CODE_CLIENT

                            MainWindow.gestionDesComptesDebiteurLorsDesReservations(CODE_ENTREPRISE)

                            '----------------------------------------------------------------------
                        End If

                    End If

                    'GENERATION DE LA FACTURE ET DU CODE_FACTURE QUI SERA INSERE DANS LES ligne_facture QUE L'ON CLOTURE

                    facture.insertFacture(CODE_FACTURE, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT, TAXE, MONTANT_TTC, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, LIBELLE_FACTURE, MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE, GRIFFE_UTILISATEUR)

                    For i = 0 To dtFromFolio.Rows.Count - 1

                        'mettre a jour le code_facture et etat_fature des lignes actuels contenu dans le folio

                        Dim OLD_CODE_FACTURE As String = dtFromFolio.Rows(i)("CODE")
                        Dim CODE_ARTICLE As String = dtFromFolio.Rows(i)("ARTICLE")
                        Dim NEW_CODE_FACTURE As String = CODE_FACTURE
                        Dim ID_LIGNE_FACTURE As Integer = dtFromFolio.Rows(i)("ID")
                        Dim NUM_REGLEMENT As String = dtFromFolio.Rows(i)("CODE")
                        Dim IMPRIMER As Integer = 1

                        reglement.updateReglementClotureFolio(NUM_REGLEMENT, NEW_CODE_FACTURE, IMPRIMER, CODE_ARTICLE, CODE_RESERVATION)

                        ligneFacture.updateLigneFactureClotureFolio_(OLD_CODE_FACTURE, NEW_CODE_FACTURE, ETAT_FACTURE, CODE_ARTICLE, CODE_RESERVATION, ID_LIGNE_FACTURE)

                    Next

                    Dim compteEntreprise As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                    If compteEntreprise.Rows.Count > 0 Then

                        Dim NUMERO_COMPTE As String = compteEntreprise.Rows(0)("NUMERO_COMPTE")
                        Dim TOTAL_DEBIT As Double = MONTANT_TTC
                        Dim TOTAL_CREDIT As Double = 0

                        compte.updateCompteAlaClotureDuFolio(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT)

                    End If

                    Dim reservationUpdate As New Reservation()

                    Dim updatedSolde As Double = Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate)
                    Dim solde As Double = updatedSolde
                    reservationUpdate.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reserve_conf", updatedSolde)

                    MainWindow.GunaLabelSolde.Text = Format(solde, "#,##0")

                    If 0 > Solde Then
                        MainWindow.GunaLabelSolde.ForeColor = Color.Red
                    ElseIf Solde = 0 Then
                        MainWindow.GunaLabelSolde.ForeColor = Color.Black
                    Else
                        MainWindow.GunaLabelSolde.ForeColor = Color.Green
                    End If

                    MainWindow.Refresh()

                End If

                '---------------------------------------------------------

                If GlobalVariable.actualLanguageValue = 1 Then

                    Dim totalLettre = New Paragraph(Chr(13) & Chr(13) & "Arrêter la présente à la somme de : " & Functions.NBLT(TotalFacture) & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), fontTotal)
                    pdfDoc.Add(totalLettre)

                    Dim signature = New Paragraph(Chr(13) & Chr(13) & "                 SIGNATURE DU CLIENT                                                            SIGNATURE DE L'HOTEL", pRow)
                    pdfDoc.Add(signature)

                Else

                    Dim totalLettre = New Paragraph(Chr(13) & Chr(13) & "Hold at an amount of : " & Functions.NBLTENGLISH(TotalFacture) & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), fontTotal)
                    pdfDoc.Add(totalLettre)

                    Dim signature = New Paragraph(Chr(13) & Chr(13) & "                   CLIENT'S SIGNATURE                                                            HOTEL'S SIGNATURE", pRow)
                    pdfDoc.Add(signature)
                End If

                pdfDoc.Close()


                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("PDF a été exporté " & sfd.FileName, "Generate PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("PDF exported successfully " & sfd.FileName, "Generate PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                Process.Start(sfd.FileName)

                If GlobalVariable.FolioToPrint = "Folio1" Then
                    GunaDataGridViewFolio1.Rows.Clear()
                    GunaTextBoxSoldeFolio1.Text = 0
                ElseIf GlobalVariable.FolioToPrint = "Folio2" Then
                    GunaDataGridViewFolio2.Rows.Clear()
                    GunaTextBoxSoldeFolio2.Text = 0
                ElseIf GlobalVariable.FolioToPrint = "Folio3" Then
                    GunaDataGridViewFolio3.Rows.Clear()
                    GunaTextBoxSoldeFolio3.Text = 0
                ElseIf GlobalVariable.FolioToPrint = "Folio4" Then
                    GunaDataGridViewFolio4.Rows.Clear()
                    GunaTextBoxSoldeFolio4.Text = 0
                End If

                If Not Trim(cloturer).Equals("") Then

                    Dim EMAIL As String = ""

                    Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxEntreprise.Text)

                    If Not Trim(CODE_ENTREPRISE).Equals("") Then

                        Dim infoSup As DataTable = Functions.getElementByCode(CODE_ENTREPRISE, "client", "CODE_CLIENT")

                        If infoSup.Rows.Count > 0 Then
                            EMAIL = infoSup.Rows(0)("EMAIL")
                            TELEPHONE = infoSup.Rows(0)("TELEPHONE")
                        End If

                    Else
                        EMAIL = GlobalVariable.ClientToUpdate.Rows(0)("EMAIL")
                        TELEPHONE = GlobalVariable.ClientToUpdate.Rows(0)("TELEPHONE")
                    End If

                    If Not Trim(TELEPHONE).Equals("") And TELEPHONE.Length >= 13 Then

                        'POUR LES LIGNES DE CHARGES ET REGLEMENT
                        Dim Titre As String = "FACTURE"

                        Dim bodyText As String = "Ci jointe votre facture " & fichier

                        If GlobalVariable.actualLanguageValue = 1 Then
                            Titre = "FACTURE"

                            bodyText = "Ci jointe votre facture " & fichier

                        Else
                            Titre = "BILL"

                            bodyText = "Below attached your Bill " & fichier

                        End If

                        'envoieDocumentMailClient(fichier, Titre, bodyText, EMAIL)

                        Dim nmessageOuDocument As Integer = 1
                        Dim typeDeDocument As Integer = 2
                        Dim phoneNumber As String = TELEPHONE

                        Dim args As ArgumentType = New ArgumentType()

                        args.cloturer = cloturer
                        args.fichier = fichier
                        args.nmessageOuDocument = nmessageOuDocument
                        args.titreFichier = titreFichier
                        args.bodyText = bodyText
                        args.typeDeDocument = typeDeDocument
                        args.phoneNumber = phoneNumber

                        backGroundWorkerToCall(args)

                        'Functions.ultrMessage(fichier, nmessageOuDocument, titreFichier, bodyText, typeDeDocument, phoneNumber)

                        'UNIQUEMENT POUR LES LIGNES DE CHARGES
                        'RapportApresCloture.DocumentToPrint(cloturer, EMAIL, dtFromFolio, CODE_ENTREPRISE, TELEPHONE)

                    End If

                End If

                GlobalVariable.FolioToPrint = ""

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Aucune Ligne de Fatcure à imprimer !")

                Else
                    MessageBox.Show("Nothing to print !")

                End If

            End If

        End If

    End Sub

    Public Class ArgumentType

        Public cloturer As String
        Public fichier As String
        Public nmessageOuDocument As Integer
        Public titreFichier As String
        Public bodyText As String
        Public typeDeDocument As Integer
        Public phoneNumber As String

    End Class

    'Code to generate a pdf for printing documents for folio 1
    Private Sub GunaButtonImprimer_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerFolio1.Click

        montantTotal = 0

        GlobalVariable.FolioToPrint = "Folio1"

        'Me.Close()

        DocumentToPrint()


    End Sub

    'Code to generate a pdf for printing documents for folio 2
    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerFolio2.Click

        If Not GunaTextBoxCompanyName.Text = "" Then

            montantTotal = 0
            GlobalVariable.FolioToPrint = "Folio2"

            DocumentToPrint()

        Else


            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Folio réservé aux clients associés à une entreprise" & Chr(13) & "Bien vouloir choisir une entreprise !", "Folio Entreprise", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Folio for comapny use only " & Chr(13) & "Please choose a company !", "Company Folio", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If


    End Sub

    'Code to generate a pdf for printing documents for folio 3
    Private Sub GunaButtonImprimerFolio3_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerFolio3.Click

        montantTotal = 0

        GlobalVariable.FolioToPrint = "Folio3"

        'Me.Close()

        DocumentToPrint()

    End Sub

    'Code to generate a pdf for printing documents for folio 4
    Private Sub GunaButtonImprimerFolio4_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerFolio4.Click

        montantTotal = 0

        GlobalVariable.FolioToPrint = "Folio4"

        DocumentToPrint()

        'Me.Close()

    End Sub

    Dim TotalVersement As Double = 0
    Dim TotalFacture As Double = 0
    Dim totalNormal As Double = 0
    Dim totalTVA As Double = 0
    Dim taxeSejour As Double = 0

    Private Function GetDataTableFolio11(ByVal Grid As DataGridView) As DataTable

        Dim dataTable As New DataTable("dt")

        Dim dataColumn1 As New DataColumn(Grid.Columns(0).HeaderText, GetType(String))
        Dim dataColumn2 As New DataColumn(Grid.Columns(1).HeaderText, GetType(String))
        Dim dataColumn3 As New DataColumn(Grid.Columns(2).HeaderText, GetType(String))
        Dim dataColumn4 As New DataColumn(Grid.Columns(3).HeaderText, GetType(String))
        Dim dataColumn5 As New DataColumn(Grid.Columns(4).HeaderText, GetType(String))
        'Dim dataColumn6 As New DataColumn(Grid.Columns(5).HeaderText, GetType(String))

        dataTable.Columns.Add(dataColumn1)
        dataTable.Columns.Add(dataColumn2)
        dataTable.Columns.Add(dataColumn3)
        dataTable.Columns.Add(dataColumn4)
        dataTable.Columns.Add(dataColumn5)
        'dataTable.Columns.Add(dataColumn6)

        Dim row As DataRow

        For i = 0 To Grid.Rows.Count - 1

            row = dataTable.NewRow

            Dim quantite As Integer
            Dim montantTotal As Double

            Double.TryParse(Grid.Rows(i).Cells(3).Value, montantTotal)
            Integer.TryParse(Grid.Rows(i).Cells(2).Value, quantite)

            row(dataColumn1) = CDate(Grid.Rows(i).Cells(0).Value).ToShortDateString 'Date operation
            row(dataColumn2) = Grid.Rows(i).Cells(1).Value 'LIbelle Opération
            row(dataColumn3) = Grid.Rows(i).Cells(2).Value 'quantite
            row(dataColumn4) = Functions.prelevementDeTaxeSurUnMontant(Format(Grid.Rows(i).Cells(3).Value / Grid.Rows(i).Cells(2).Value, "#,##0")) ' Prix unitaire
            row(dataColumn5) = Functions.prelevementDeTaxeSurUnMontant(Format(Grid.Rows(i).Cells(3).Value)) ' Montant Total
            'row(dataColumn6) = GunaDataGridViewFolio1.Rows(i).Cells(5).Value

            dataTable.Rows.Add(row)

            'TotalFacture += Functions.prelevementDeTaxeSurUnMontant(montantTotal)
            'totalTVA += Functions.prelevementDeTaxeSurUnMontantPOurCalcul(montantTotal)

        Next

        dataTable.AcceptChanges()

        Return dataTable

    End Function

    Dim TotalReglementFacture As Double = 0

    Private Function GetDataTableFolioN(ByVal GunaDataGridViewFolioN As DataGridView) As DataTable

        If GunaDataGridViewFolioN.Rows.Count > 0 Then

            TotalFacture = 0
            TotalReglementFacture = 0

            Dim dataTable As New DataTable("dt")

            Dim dataColumn1 As New DataColumn(GunaDataGridViewFolioN.Columns(0).HeaderText, GetType(String)) 'DATE
            Dim dataColumn2 As New DataColumn(GunaDataGridViewFolioN.Columns(1).HeaderText, GetType(String)) 'LIBELLE
            Dim dataColumn3 As New DataColumn(GunaDataGridViewFolioN.Columns(2).HeaderText, GetType(String)) 'QTE
            Dim dataColumn4 As New DataColumn(GunaDataGridViewFolioN.Columns(3).HeaderText, GetType(String)) 'DEBIT
            Dim dataColumn5 As New DataColumn(GunaDataGridViewFolioN.Columns(4).HeaderText, GetType(String)) 'CREDIT


            'Dim dataColumn6 As New DataColumn("CREDIT", GetType(String))
            Dim dataColumn6 As New DataColumn("PU", GetType(String))
            'Dim dataColumn7 As New DataColumn("CODE", GetType(String))
            Dim dataColumn7 As New DataColumn(GunaDataGridViewFolioN.Columns(5).HeaderText, GetType(String)) 'CODE_FACTURE 
            Dim dataColumn8 As New DataColumn(GunaDataGridViewFolioN.Columns(6).HeaderText, GetType(String)) 'ARTICLE
            Dim dataColumn9 As New DataColumn(GunaDataGridViewFolioN.Columns(7).HeaderText, GetType(String)) 'ARTICLE

            dataTable.Columns.Add(dataColumn1)
            dataTable.Columns.Add(dataColumn2)
            dataTable.Columns.Add(dataColumn3)
            dataTable.Columns.Add(dataColumn4)
            dataTable.Columns.Add(dataColumn5)
            dataTable.Columns.Add(dataColumn6)
            dataTable.Columns.Add(dataColumn7)
            dataTable.Columns.Add(dataColumn8)
            dataTable.Columns.Add(dataColumn9)

            Dim row As DataRow

            For i = 0 To GunaDataGridViewFolioN.Rows.Count - 1

                row = dataTable.NewRow

                Dim quantite As Integer
                Dim montantTotal As Double = 0
                Dim montantReglement As Double = 0

                Double.TryParse(GunaDataGridViewFolioN.Rows(i).Cells(3).Value, montantTotal)
                Double.TryParse(GunaDataGridViewFolioN.Rows(i).Cells(4).Value, montantReglement)
                Integer.TryParse(GunaDataGridViewFolioN.Rows(i).Cells(2).Value, quantite)

                row(dataColumn1) = GunaDataGridViewFolioN.Rows(i).Cells(0).Value 'Date operation
                row(dataColumn2) = GunaDataGridViewFolioN.Rows(i).Cells(1).Value 'LIbelle Opération
                row(dataColumn3) = GunaDataGridViewFolioN.Rows(i).Cells(2).Value 'quantite

                'row(dataColumn4) = GunaDataGridViewFolioN.Rows(i).Cells(3).Value / GunaDataGridViewFolioN.Rows(i).Cells(2).Value ' Prix unitaire

                If Not Double.Parse(GunaDataGridViewFolioN.Rows(i).Cells(3).Value) = 0 Then
                    'row(dataColumn4) = GunaDataGridViewFolioN.Rows(i).Cells(3).Value ' Debit Montant Total
                    'row(dataColumn5) = 0 ' Credit Montant Total
                    'row(dataColumn6) = GunaDataGridViewFolioN.Rows(i).Cells(3).Value / GunaDataGridViewFolioN.Rows(i).Cells(2).Value ' Prix unitaire

                ElseIf Not Double.Parse(GunaDataGridViewFolioN.Rows(i).Cells(4).Value) = 0 Then
                    'row(dataColumn4) = 0 ' Debit Montant Total
                    'row(dataColumn5) = Double.Parse(GunaDataGridViewFolioN.Rows(i).Cells(4).Value) ' Credit Montant Total
                    'row(dataColumn6) = GunaDataGridViewFolioN.Rows(i).Cells(4).Value / GunaDataGridViewFolioN.Rows(i).Cells(2).Value ' Prix unitaire
                End If

                row(dataColumn4) = Double.Parse(GunaDataGridViewFolioN.Rows(i).Cells(3).Value) ' Debit Montant Total
                row(dataColumn5) = Double.Parse(GunaDataGridViewFolioN.Rows(i).Cells(4).Value) ' Credit Montant Total
                row(dataColumn6) = GunaDataGridViewFolioN.Rows(i).Cells(4).Value / GunaDataGridViewFolioN.Rows(i).Cells(2).Value ' Prix unitaire

                row(dataColumn7) = GunaDataGridViewFolioN.Rows(i).Cells(5).Value 'code facture

                row(dataColumn8) = GunaDataGridViewFolioN.Rows(i).Cells(6).Value 'code article
                row(dataColumn9) = GunaDataGridViewFolioN.Rows(i).Cells(7).Value 'id

                dataTable.Rows.Add(row)

                TotalFacture += montantTotal
                TotalReglementFacture += montantReglement

                'COLONNE 3 : DEBIT
                'COLONNE 4 : CREDIT

            Next

            'dataTable.AcceptChanges()

            Return dataTable

        Else

        End If

    End Function

    Class HeaderFooter

        Inherits PdfPageEventHelper

        Dim societe As DataTable = Functions.allTableFields("societe")

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim UTILISE As Integer = 1

        'Dim papierEnTete As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_AGENCE, "papier_entete", "CODE_AGENCE", UTILISE, "UTILISE")

        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)

            Dim papierEnTete As DataTable = Functions.getElementByCode(CODE_AGENCE, "papier_entete", "CODE_AGENCE")

            Dim HeaderFont As New Font(iTextSharp.text.Font.FontFamily.COURIER, 22, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font1 As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font2 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font4 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font3 As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

            Dim pdfCell As PdfPCell = Nothing

            Dim img() As Byte
            img = societe.Rows(0)("LOGO")

            Dim img2() As Byte
            img2 = papierEnTete.Rows(0)("IMAGE_2")

            Dim img1() As Byte
            img1 = papierEnTete.Rows(0)("IMAGE_1")

            Dim mStream As New MemoryStream(img)
            Dim mStream2 As New MemoryStream(img2)
            Dim mStream1 As New MemoryStream(img1)

            Dim logo As Image
            logo = Image.GetInstance(img)
            logo.ScalePercent(65.0F)

            Dim IMAGE_2 As Image
            IMAGE_2 = Image.GetInstance(img2)
            IMAGE_2.ScalePercent(18.0F)

            Dim IMAGE_1 As Image
            IMAGE_1 = Image.GetInstance(img1)
            IMAGE_1.ScalePercent(18.0F)

            Dim pHeader As New PdfPTable(1)
            pHeader.TotalWidth = document.PageSize.Width
            pHeader.DefaultCell.Border = 0

            Dim pHeaderSubTitle As New PdfPTable(1)
            pHeaderSubTitle.TotalWidth = document.PageSize.Width
            pHeaderSubTitle.DefaultCell.Border = 0

            Dim pHeaderSubTitle1 As New PdfPTable(1)
            pHeaderSubTitle1.TotalWidth = document.PageSize.Width
            pHeaderSubTitle1.DefaultCell.Border = 0

            '------------------------------------------------------------------ START HEADER ----------------------------------------------------------------------------------

            If papierEnTete.Rows.Count > 0 Then

                Dim EN_TETE_L1 = papierEnTete.Rows(0)("EN_TETE_L1")
                Dim EN_TETE_L2 = papierEnTete.Rows(0)("EN_TETE_L2")
                Dim EN_TETE_L3 = papierEnTete.Rows(0)("EN_TETE_L3")
                Dim EN_TETE_L4 = papierEnTete.Rows(0)("EN_TETE_L4")
                Dim PIEDS_L1 = papierEnTete.Rows(0)("PIEDS_L1")
                Dim PIEDS_L2 = papierEnTete.Rows(0)("PIEDS_L2")
                Dim PIEDS_L3 = papierEnTete.Rows(0)("PIEDS_L3")

                If papierEnTete.Rows(0)("UTILISE") = 1 Then

                    Dim pdfTable As New PdfPTable(3) 'Number of columns

                    pdfTable.TotalWidth = document.PageSize.Width
                    pdfTable.LockedWidth = True
                    pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                    'pdfTable.HeaderRows = 1

                    Dim widths As Single() = New Single() {2.4F, 10.0F, 2.4F}
                    pdfTable.SetWidths(widths)

                    pdfCell = New PdfPCell(logo)
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    pdfCell.Border = 0
                    pdfCell.PaddingLeft = 15.0F
                    pdfTable.AddCell(pdfCell)

                    Dim mtable As PdfPTable = New PdfPTable(1)
                    mtable.WidthPercentage = 100
                    mtable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

                    pdfCell = New PdfPCell(New Paragraph(societe.Rows(0)("RAISON_SOCIALE"), HeaderFont))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.Border = 0 'used to remove borders on the cells

                    mtable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(EN_TETE_L1 & Chr(13), font1))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.Border = 0 'used to remove borders on the cells

                    mtable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(EN_TETE_L2, font3))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.Border = 0 'used to remove borders on the cells

                    mtable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(EN_TETE_L3, font3))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.Border = 0 'used to remove borders on the cells

                    mtable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(EN_TETE_L4, font3))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.Border = 0 'used to remove borders on the cells

                    mtable.DefaultCell.BorderWidth = 0
                    pdfTable.DefaultCell.BorderWidth = 0

                    mtable.AddCell(pdfCell)

                    pdfTable.AddCell(mtable)

                    pdfCell = New PdfPCell(IMAGE_2)
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    pdfCell.Border = 0
                    pdfCell.PaddingRight = 15.0F

                    If document.PageNumber = 1 Then
                        pdfTable.AddCell(pdfCell)
                        pdfTable.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 155, writer.DirectContent)
                    Else
                        pdfTable.AddCell(pdfCell)
                    End If

                    '----------------------------------------------------------------------------------------------------------------------------------------------------------------

                    If GlobalVariable.DocumentToGenerate = "situation caisse" Then
                        pdfCell = New PdfPCell(New Paragraph("               SIGNATURE DU CAISSIER                                               SIGNATURE DU COMPTABLE"))
                    ElseIf GlobalVariable.DocumentToGenerate = "DST" Then
                        pdfCell = New PdfPCell(New Paragraph(""))
                    ElseIf GlobalVariable.DocumentToGenerate = "reglement" Or GlobalVariable.DocumentToGenerate = "facture" Then
                        pdfCell = New PdfPCell(New Paragraph("               SIGNATURE DU CLIENT                                                    SIGNATURE DE L'HOTEL"))
                    End If

                    Dim pFooter As New PdfPTable(1)
                    pFooter.TotalWidth = document.PageSize.Width
                    pdfCell.PaddingLeft = 15.0F
                    pFooter.DefaultCell.Border = 0

                    pdfCell = New PdfPCell(New Paragraph(PIEDS_L1, font4))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 15.0F
                    pdfCell.Border = 0
                    pFooter.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(PIEDS_L2 & Chr(13) & PIEDS_L3 & Chr(13) & " BARCLES HOTEL SOFT " & GlobalVariable.DateDeTravail & "-" & Now().ToLongTimeString, font2))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 15.0F
                    pdfCell.Border = 0
                    pFooter.AddCell(pdfCell)

                    'pFooter.WriteSelectedRows(0, -1, 0, document.GetBottom(document.BottomMargin) - 23, writer.DirectContent)
                    pFooter.WriteSelectedRows(0, -1, 0, 55, writer.DirectContent)

                    'COIN INFERIEUR GAUCHE
                    Dim pFooterLeft As New PdfPTable(1)
                    pFooterLeft.TotalWidth = document.PageSize.Width
                    pdfCell.PaddingLeft = 15.0F
                    pFooterLeft.DefaultCell.Border = 0

                    pdfCell = New PdfPCell(IMAGE_1)
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfCell.PaddingLeft = 15.0F
                    pdfCell.Border = 0
                    pFooterLeft.AddCell(pdfCell)
                    'pFooterLeft.WriteSelectedRows(0, -1, 0, document.GetBottom(document.BottomMargin) + 15, writer.DirectContent)
                    pFooterLeft.WriteSelectedRows(0, -1, 0, 95, writer.DirectContent)


                ElseIf papierEnTete.Rows(0)("UTILISE") = 0 Then


                    Dim mtable As PdfPTable = New PdfPTable(1)
                    mtable.WidthPercentage = 100
                    mtable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

                    '--------------------------------------------------------------

                    Dim pdfTable As New PdfPTable(2) 'Number of columns

                    pdfTable.TotalWidth = document.PageSize.Width
                    pdfTable.LockedWidth = True
                    pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT

                    Dim widths As Single() = New Single() {30.0F, 70.0F}
                    pdfTable.SetWidths(widths)

                    pdfCell = New PdfPCell(logo)
                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell.MinimumHeight = 15
                    pdfCell.Border = 0
                    pdfCell.PaddingLeft = 15.0F
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(societe.Rows(0)("RAISON_SOCIALE"), HeaderFont))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.Border = 0 'used to remove borders on the cells
                    mtable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Chr(13) & EN_TETE_L1 & Chr(13) & EN_TETE_L2 & Chr(13) & EN_TETE_L3 & Chr(13) & EN_TETE_L4, font1))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.MinimumHeight = 15
                    pdfCell.Border = 0 'used to remove borders on the cells
                    mtable.AddCell(pdfCell)

                    mtable.DefaultCell.BorderWidth = 0
                    pdfTable.DefaultCell.BorderWidth = 0

                    If document.PageNumber = 1 Then
                        pdfTable.AddCell(mtable)
                        pdfTable.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 155, writer.DirectContent)
                    End If
                    '----------------------------------------------------------------------------------------------------------------------------------------------------------------

                    Dim pFooter As New PdfPTable(1)
                    pFooter.TotalWidth = document.PageSize.Width
                    pdfCell.PaddingLeft = 15.0F
                    pdfCell.MinimumHeight = 15
                    pFooter.DefaultCell.Border = 0

                    pdfCell = New PdfPCell(New Paragraph(PIEDS_L1, font4))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 15.0F
                    pdfCell.MinimumHeight = 15
                    pdfCell.Border = 0
                    pFooter.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(PIEDS_L2 & Chr(13) & PIEDS_L3 & Chr(13) & " BARCLES HOTEL SOFT " & GlobalVariable.DateDeTravail & "-" & Now().ToLongTimeString, font2))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.PaddingLeft = 15.0F
                    pdfCell.MinimumHeight = 15
                    pdfCell.Border = 0
                    pFooter.AddCell(pdfCell)

                    pFooter.WriteSelectedRows(0, -1, 0, 60, writer.DirectContent)

                End If

            End If

        End Sub

    End Class

    Private Sub GunaButtonPayer_Click(sender As Object, e As EventArgs) Handles GunaButtonPayer.Click, GunaButtonPayerFolio3.Click, GunaButtonPayerFolio2.Click, GunaButtonPayerFolio4.Click

        'Variable to be used at the level of reglement to Know if to output or no entreprise label 
        GlobalVariable.ComingFromFolio1FactureType = GunaComboBoxTypeFolio.SelectedItem

        Me.Close()

        ReglementForm.Show()
        ReglementForm.TopMost = True

    End Sub

    'Choix du client entreprise  à facturer
    Private Sub GunaTextBoxEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxEntreprise.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxEntreprise.Text).Equals("") Then

            GunaTextBoxCompanyName.Clear()

            GunaDataGridViewCompany.Visible = False

        End If

        GunaDataGridViewCompany.Visible = True

        Dim query As String = "Select NOM_CLIENT From client WHERE NOM_CLIENT Like '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT
        OR NOM_CLIENT Like '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT_"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "Entreprise"
        command.Parameters.Add("@TYPE_CLIENT_", MySqlDbType.VarChar).Value = "Company"
        'command.Parameters.Add("@ENTREPRISE", MySqlDbType.VarChar).Value = GunaComboBoxTypeClient.SelectedValue

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewCompany.DataSource = table
        Else
            GunaDataGridViewCompany.Columns.Clear()
            GunaDataGridViewCompany.Visible = False
        End If

        If GunaTextBoxEntreprise.Text.Trim().Equals("") Then
            GunaDataGridViewCompany.Columns.Clear()
            GunaDataGridViewCompany.Visible = False
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaDataGridViewCompany_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewCompany.CellClick

        GunaDataGridViewCompany.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewCompany.Rows(e.RowIndex)
            Dim company As DataTable = Functions.getElementByCode(row.Cells("NOM_CLIENT").Value.ToString, "client", "NOM_CLIENT")

            GunaTextBoxCompanyName.Text = row.Cells("NOM_CLIENT").Value.ToString
            GunaTextBoxEntreprise.Text = company.Rows(0)("CODE_CLIENT")

            Dim compte As DataTable = Functions.getElementByCode(Trim(GunaTextBoxEntreprise.Text), "compte", "CODE_CLIENT")

            If compte.Rows.Count > 0 Then
                GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")

            End If

            GunaDataGridViewCompany.Visible = False

            'connect.closeConnection()

        End If

    End Sub

    Private Sub backGroundWorkerToCall(ByVal args As ArgumentType)

        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker2.IsBusy Then
            BackgroundWorker2.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker3.IsBusy Then
            BackgroundWorker3.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker4.IsBusy Then
            BackgroundWorker4.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker5.IsBusy Then
            BackgroundWorker5.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker6.IsBusy Then
            BackgroundWorker6.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker7.IsBusy Then
            BackgroundWorker7.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker8.IsBusy Then
            BackgroundWorker8.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker9.IsBusy Then
            BackgroundWorker9.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker10.IsBusy Then
            BackgroundWorker10.RunWorkerAsync(args)
        End If

    End Sub


    'Cloture des factures
    Private Sub GunaButtonCloturer_Click(sender As Object, e As EventArgs) Handles GunaButtonCloturerFolio1.Click

        If Trim(GunaTextBoxSoldeFolio1.Text) = "" Then
            GunaTextBoxSoldeFolio1.Text = 0
        End If

        If GunaTextBoxSoldeFolio1.Text = 0 Then

            If GunaDataGridViewFolio1.Rows.Count > 0 Then

                montantTotal = 0

                GlobalVariable.FolioToPrint = "Folio1"

                DocumentToPrint("cloturer")
                'BackgroundWorker1.RunWorkerAsync()

                Me.Close()

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Impossible de clôturer un Folio individuel vide!!", "Clôture de Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else
                    MessageBox.Show("Impossible to close an empty folio !!", "Close Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            End If

        Else

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Impossible de clôturer un Folio individuel avec un solde non nul !!", "Clôture de Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else
                dialog = MessageBox.Show("Impossible to close a Folio with a non null balance !!", "Close Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

            If dialog = DialogResult.OK Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    GlobalVariable.ComingFromFolio1FactureType = "INDIVIDUEL"
                Else
                    GlobalVariable.ComingFromFolio1FactureType = "INDIVIDUAL"
                End If

                ReglementForm.Close()
                ReglementForm.Show()
                ReglementForm.TopMost = True

                Me.Close()

            End If

        End If

    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButtonCloturerFolio2.Click

        If Not Trim(GunaTextBoxCompteDebiteur.Text).Equals("") Then

            If GunaDataGridViewFolio2.Rows.Count > 0 Then

                montantTotal = 0

                GlobalVariable.FolioToPrint = "Folio2"

                DocumentToPrint("cloturer")

                Me.Close()

            End If


        Else
            ' Dim dialog As DialogResult

            'If GlobalVariable.actualLanguageValue = 1 Then
            'dialog = MessageBox.Show("Impossible de clôturer un Folio Entreprise sans entreprise !!", "Clôture de Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'Else
            'dialog = MessageBox.Show("Impossible to close a Folio with no company !!", "Close Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'End If
        End If


        'BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub GunaButton6_Click_1(sender As Object, e As EventArgs) Handles GunaButtonCloturerFolio3.Click

        If Trim(GunaTextBoxSoldeFolio3.Text) = "" Then
            GunaTextBoxSoldeFolio3.Text = 0
        End If

        If GunaTextBoxSoldeFolio3.Text = 0 Then

            If GunaDataGridViewFolio3.Rows.Count > 0 Then

                montantTotal = 0

                GlobalVariable.FolioToPrint = "Folio3"

                DocumentToPrint("cloturer")

                'BackgroundWorker1.RunWorkerAsync()

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Impossible de clôturer un Folio individuel vide!!", "Clôture de Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else
                    MessageBox.Show("Impossible to close an empty folio !!", "Close Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            End If

        Else

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Impossible de clôturer un Folio individuel avec un solde non nul !!", "Clôture de Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else
                dialog = MessageBox.Show("Impossible to close a Folio with a non null balance !!", "Close Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

            If dialog = DialogResult.OK Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    GlobalVariable.ComingFromFolio1FactureType = "INDIVIDUEL"
                Else
                    GlobalVariable.ComingFromFolio1FactureType = "INDIVIDUAL"
                End If

                ReglementForm.Close()
                ReglementForm.Show()
                ReglementForm.TopMost = True

                Me.Close()

            End If

        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonCloturerFolio4.Click

        If Trim(GunaTextBoxSoldeFolio4.Text) = "" Then
            GunaTextBoxSoldeFolio4.Text = 0
        End If

        If GunaTextBoxSoldeFolio4.Text = 0 Then

            If GunaDataGridViewFolio4.Rows.Count > 0 Then

                montantTotal = 0

                GlobalVariable.FolioToPrint = "Folio4"

                DocumentToPrint("cloturer")

                'BackgroundWorker1.RunWorkerAsync()

                'Me.Close()

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Impossible de clôturer un Folio individuel vide!!", "Clôture de Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else
                    MessageBox.Show("Impossible to close an empty folio !!", "Close Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            End If

        Else

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Impossible de clôturer un Folio individuel avec un solde non nul !!", "Clôture de Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else
                dialog = MessageBox.Show("Impossible to close a Folio with a non null balance !!", "Close Folio", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

            If dialog = DialogResult.OK Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    GlobalVariable.ComingFromFolio1FactureType = "INDIVIDUEL"
                Else
                    GlobalVariable.ComingFromFolio1FactureType = "INDIVIDUAL"
                End If

                ReglementForm.Close()
                ReglementForm.Show()
                ReglementForm.TopMost = True

                Me.Close()

            End If
        End If

    End Sub

    'GESTION DES PAYMASTER

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs)

        ReglementLettrageForm.Show()

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker5.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker6_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker6.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker7_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker7.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker8_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker8.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker9_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker9.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Private Sub BackgroundWorker10_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker10.DoWork

        Dim args As ArgumentType = e.Argument

        Functions.ultrMessage(args.fichier, args.nmessageOuDocument, args.titreFichier, args.bodyText, args.typeDeDocument, args.phoneNumber)

    End Sub

    Public Sub sauvegardeDesElementsFixe(ByVal dt As DataGridView, ByVal FOLIO As Integer)

        If dt.Rows.Count > 0 Then

            Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate
            Dim CHARGE_REGLEMENT As Integer = 0 'Permet de savoir si la ligne correspond a une ligne ou a un reglement 1:CHARGE ; 2 REGLEMENT
            Dim ID_LIGNE As Integer = 0 'Permet d'identifier la ligne_facture our le reglement
            Dim DEBIT As Double = 0
            Dim CREDIT As Double = 0

            For i = 0 To dt.Rows.Count - 1

                ID_LIGNE = dt.Rows(i).Cells(7).Value
                DEBIT = dt.Rows(i).Cells(3).Value
                CREDIT = dt.Rows(i).Cells(4).Value

                If DEBIT = 0 And CREDIT = 0 Then
                    CHARGE_REGLEMENT = 1 'ligne_facture
                ElseIf Not DEBIT = 0 Then
                    CHARGE_REGLEMENT = 1 'ligne_facture
                ElseIf Not CREDIT = 0 Then
                    CHARGE_REGLEMENT = 2 'ligne_facture
                End If

                Dim insertQuery As String = "INSERT INTO `folio_element_fix` (`ID_LIGNE`, `FOLIO`, `CHARGE_REGLEMENT`, `CODE_RESERVATION`) 
                VALUES (@ID_LIGNE, @FOLIO, @CHARGE_REGLEMENT, @CODE_RESERVATION)"

                Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

                command.Parameters.Add("@ID_LIGNE", MySqlDbType.Int32).Value = ID_LIGNE
                command.Parameters.Add("@FOLIO", MySqlDbType.Int32).Value = FOLIO
                command.Parameters.Add("@CHARGE_REGLEMENT", MySqlDbType.Int32).Value = CHARGE_REGLEMENT
                command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

                command.ExecuteNonQuery()

            Next

        End If

    End Sub

    Private Sub GunaButton1_Click_2(sender As Object, e As EventArgs) Handles GunaButton1.Click

        'Sauvegarde des positions des elements contenus dans le folio

        Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate
        Functions.DeleteElementByCode(CODE_RESERVATION, "folio_element_fix", "CODE_RESERVATION")
        Dim infoResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

        If infoResa.Rows.Count > 0 Then

            Dim dt As DataGridView

            For i = 1 To 4

                If i = 1 Then
                    dt = GunaDataGridViewFolio1
                ElseIf i = 2 Then
                    dt = GunaDataGridViewFolio2
                ElseIf i = 3 Then
                    dt = GunaDataGridViewFolio3
                ElseIf i = 4 Then
                    dt = GunaDataGridViewFolio4
                End If

                sauvegardeDesElementsFixe(dt, i)

            Next

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Position des éléments enregistrés avec succès", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Elements positions successfully saved", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Public Function restaurationDesElementsFixe(ByVal ID_LIGNE As Integer,
                                                ByVal CODE_RESERVATION As String,
                                                ByVal DEBIT As Integer,
                                                CREDIT As Integer, ByVal ENTREPRISE As String) As Integer

        Dim FOLIO As Integer = 0
        Dim CHARGE_REGLEMENT As Integer = 0
        Dim CHARGE_REGLEMENT_VERIF As Integer = 0

        Dim infoLigneFolio As DataTable = Functions.GetAllElementsOnTwoConditions(ID_LIGNE, "folio_element_fix", "ID_LIGNE", CODE_RESERVATION, "CODE_RESERVATION")

        If infoLigneFolio.Rows.Count > 0 Then

            'On pourra avoir le meme identifiant pour une charge et un reglement dans ce cas on doit choisir le bon
            'selon si c'est un reglement ou une charge.

            If DEBIT = 0 And CREDIT = 0 Then
                CHARGE_REGLEMENT_VERIF = 1 'ligne_facture
            ElseIf Not DEBIT = 0 Then
                CHARGE_REGLEMENT_VERIF = 1 'ligne_facture
            ElseIf Not CREDIT = 0 Then
                CHARGE_REGLEMENT_VERIF = 2 'ligne_facture
            End If

            For i = 0 To infoLigneFolio.Rows.Count - 1

                CHARGE_REGLEMENT = infoLigneFolio.Rows(i)("CHARGE_REGLEMENT")

                If CHARGE_REGLEMENT_VERIF = CHARGE_REGLEMENT Then
                    FOLIO = infoLigneFolio.Rows(i)("FOLIO")
                End If

            Next

        Else

            If Trim(ENTREPRISE).Equals("") Then
                FOLIO = 1
            Else
                FOLIO = 2
            End If

        End If

        Return FOLIO

    End Function

    Public Sub soldeApresRestaurationDesElementsFixe()

        Dim DEBIT As Double = 0
        Dim CREDIT As Double = 0
        Dim dt As DataGridView

        For i = 1 To 4

            DEBIT = 0
            CREDIT = 0

            If i = 1 Then
                dt = GunaDataGridViewFolio1
            ElseIf i = 2 Then
                dt = GunaDataGridViewFolio2
            ElseIf i = 3 Then
                dt = GunaDataGridViewFolio3
            ElseIf i = 4 Then
                dt = GunaDataGridViewFolio4
            End If

            For j = 0 To dt.Rows.Count - 1

                DEBIT += dt.Rows(j).Cells(3).Value
                CREDIT += dt.Rows(j).Cells(4).Value

            Next

            If i = 1 Then
                GunaTextBoxSoldeFolio1.Text = Format(CREDIT - DEBIT, "#,##0")
            ElseIf i = 2 Then
                GunaTextBoxSoldeFolio2.Text = Format(CREDIT - DEBIT, "#,##0")
            ElseIf i = 3 Then
                GunaTextBoxSoldeFolio3.Text = Format(CREDIT - DEBIT, "#,##0")
            ElseIf i = 4 Then
                GunaTextBoxSoldeFolio4.Text = Format(CREDIT - DEBIT, "#,##0")
            End If

        Next

    End Sub


End Class