Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class SituationClientForm

    Private Sub SituationClientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.situationClient(GlobalVariable.actualLanguageValue)

        If Trim(GlobalVariable.codeReservationToUpdate).Equals("") Then
            GunaLabelNomDuClient.Text = ""
        End If

        'We initialize our form
        SituationDuClient()

    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------------------------------------------

    Structure SituationClient

        Dim dateOperation
        Dim heureOperation
        Dim libelleOperation
        Dim Debit
        Dim Credit
        Dim Article
        Dim Code
        Dim Id
        Dim GriffeUtilisateur

    End Structure

    'Database connection management
    'Dim connect As New DataBaseManipulation()

    'Create a Function to return an entry using its id
    Public Function getElementById(ByVal Code As String, ByVal tableName As String, ByVal ConditionTable As String) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable()
        Dim getUserQuery = "SELECT * From " & tableName & " WHERE " & ConditionTable & "=@conditionTable"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@conditionTable", MySqlDbType.VarChar).Value = Code
        adapter.SelectCommand = Command
        adapter.Fill(table)

        'connect.closeConnection()

        Return table

    End Function

    Private Sub SituationDuClient()

        GunaDataGridViewSituation.Rows.Clear()

        Dim CODE_RESERVATION As String = MainWindow.GunaLabelNumReservation.Text

        If Not GlobalVariable.codeReservationToUpdate = "" Then

            Dim CodeClient As String = ""

            If Not GlobalVariable.codeClientToUpdate = "" Then
                CodeClient = GlobalVariable.codeClientToUpdate
                GunaButtonRoutageManuel.Text = CodeClient
            Else

                If Functions.getElementByCode(GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT"), "client", "NOM_PRENOM").Rows.Count > 0 Then
                    CodeClient = Functions.getElementByCode(GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT"), "client", "NOM_PRENOM").Rows(0)("CODE_CLIENT")
                Else

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Aucun client associé à cette Réservation !!", "Situation Réservation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("no Client associated to the servation !!", "Reservation Situation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            End If

            Dim infoResa As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

            Dim CODE_ENTREPRISE As String = ""
            If infoResa.Rows.Count > 0 Then
                GunaLabelNomDuClient.Text = infoResa.Rows(0)("NOM_CLIENT")
                CODE_ENTREPRISE = infoResa.Rows(0)("CODE_ENTREPRISE")
            End If

            'On selectionne l'ensemble des factures du client payés ou pas

            Dim query As String = "SELECT CODE_FACTURE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC, CODE_ARTICLE, ID_LIGNE_FACTURE, CODE_UTILISATEUR_CREA, DATE_DE_CONTROLE FROM ligne_facture WHERE CODE_RESERVATION = @CODE_RESERVATION AND ETAT_FACTURE = 0 ORDER BY DATE_FACTURE ASC"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CodeClient
            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = Trim(GlobalVariable.codeReservationToUpdate)

            Dim adapter As New MySqlDataAdapter(command)
            Dim tableFacture As New DataTable()

            adapter.Fill(tableFacture)

            'SI LA RESERVATION EST RATTACHE A UNE ENTREPRISE ALORS LE CODE_ENTREPRISE EST UTILISE COMME CODE CLIENT

            If Not Trim(CODE_ENTREPRISE).Equals("") Then
                'ON VERIFIE L'EXISTENCE DE L'ENTREPRISE
                Dim infoEntreprise As DataTable = Functions.getElementByCode(CODE_ENTREPRISE, "client", "CODE_CLIENT")

                If infoEntreprise.Rows.Count > 0 Then
                    CodeClient = infoEntreprise.Rows(0)("CODE_ENTREPRISE")
                End If

            End If

            'On selectionne l'ensemble des reglement du client
            'Dim query1 As String = "SELECT REF_REGLEMENT, NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, ID_REGLEMENT FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND CODE_RESERVATION=@CODE_RESERVATION AND IMPRIMER = 0 ORDER BY DATE_REGLEMENT ASC"
            Dim query1 As String = "SELECT REF_REGLEMENT, NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, ID_REGLEMENT, CODE_CAISSIER, DATE_DE_CONTROLE FROM reglement WHERE  CODE_RESERVATION=@CODE_RESERVATION AND IMPRIMER = 0 ORDER BY DATE_REGLEMENT ASC"

            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
            command1.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CodeClient
            command1.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = Trim(GlobalVariable.codeReservationToUpdate)

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

                toutesLesFactures(i).dateOperation = CDate(tableReglement.Rows(i)("DATE_REGLEMENT")).ToShortDateString
                toutesLesFactures(i).heureOperation = CDate(tableReglement.Rows(i)("DATE_DE_CONTROLE")).ToShortTimeString
                toutesLesFactures(i).Debit = 0
                toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
                toutesLesFactures(i).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")
                toutesLesFactures(i).Article = ""
                toutesLesFactures(i).Code = tableReglement.Rows(i)("NUM_REGLEMENT")
                toutesLesFactures(i).Id = tableReglement.Rows(i)("ID_REGLEMENT")
                toutesLesFactures(i).GriffeUtilisateur = tableReglement.Rows(i)("CODE_CAISSIER")

                totalReglement = totalReglement + tableReglement.Rows(i)("MONTANT_VERSE")
                niemElementDutableau = i

            Next

            niemElementDutableau += 1

            'Puis dans notre structure on ajoute les factures a la suite des reglements

            For i = 0 To tableFacture.Rows.Count - 1

                toutesLesFactures(niemElementDutableau).dateOperation = CDate(tableFacture.Rows(i)("DATE_FACTURE")).ToShortDateString
                toutesLesFactures(niemElementDutableau).heureOperation = CDate(tableFacture.Rows(i)("DATE_DE_CONTROLE")).ToShortTimeString
                toutesLesFactures(niemElementDutableau).Debit = tableFacture.Rows(i)("MONTANT_TTC")
                toutesLesFactures(niemElementDutableau).Credit = 0
                toutesLesFactures(niemElementDutableau).libelleOperation = tableFacture.Rows(i)("LIBELLE_FACTURE")
                toutesLesFactures(niemElementDutableau).Article = tableFacture.Rows(i)("CODE_ARTICLE")
                toutesLesFactures(niemElementDutableau).Code = tableFacture.Rows(i)("CODE_FACTURE")
                toutesLesFactures(niemElementDutableau).Id = tableFacture.Rows(i)("ID_LIGNE_FACTURE")
                toutesLesFactures(niemElementDutableau).GriffeUtilisateur = tableFacture.Rows(i)("CODE_UTILISATEUR_CREA")

                totalFacture = totalFacture + tableFacture.Rows(i)("MONTANT_TTC")
                niemElementDutableau += 1

            Next

            'Enfin on insere le tout dans notre datagrid
            If (toutesLesFactures.Length > 0) Then

                For i = 0 To toutesLesFactures.Length - 1

                    Dim debit = 0
                    Dim credit = 0

                    If Not toutesLesFactures(i).libelleOperation = "" Then

                        If toutesLesFactures(i).Credit > 0 Then
                            credit = Format(toutesLesFactures(i).Credit, "#,##0")
                        Else
                            credit = 0
                        End If

                        If Not toutesLesFactures(i).Debit > 0 Then
                            debit = Format(toutesLesFactures(i).Debit, "#,##0")
                        Else
                            debit = 0
                        End If

                        GunaDataGridViewSituation.Rows.Add(i, CDate(toutesLesFactures(i).dateOperation).ToShortDateString & " " & CDate(toutesLesFactures(i).heureOperation).ToLongTimeString, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"), toutesLesFactures(i).Article, toutesLesFactures(i).Code, toutesLesFactures(i).Id, toutesLesFactures(i).GriffeUtilisateur)

                        GunaDataGridViewSituation.Columns("credit").DefaultCellStyle.ForeColor = Color.DarkOliveGreen
                        GunaDataGridViewSituation.Columns("debit").DefaultCellStyle.ForeColor = Color.DarkRed

                    End If

                Next

                GunaDataGridViewSituation.Columns(0).Visible = False
                GunaDataGridViewSituation.Columns("debit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewSituation.Columns("credit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'GunaDataGridViewSituation.Columns("credit").Visible = False

                'Sorting the elements of situation client
                GunaDataGridViewSituation.Sort(GunaDataGridViewSituation.Columns(1), ListSortDirection.Descending)

            End If

            GunaTextBoxSolde.Text = Format(totalReglement - totalFacture, "#,##0")

            'connect.closeConnection()

        Else

            'SITUATION D'UN CLIENT DONT ON A PAS ENCORE FAIT L'ENREGISTREMENT DE LA RESERVATIONS

            Dim CodeClient As String = ""

            If Trim(MainWindow.GunaTextBoxCodeEntrepriseDuClient.Text).Equals("") Then
                CodeClient = MainWindow.GunaTextBoxCodeEntrepriseDuClient.Text
            Else
                CodeClient = MainWindow.GunaTextBoxRefClient.Text
            End If

            'On selectionne l'ensemble des factures du client payés ou pas

            Dim query As String = "SELECT CODE_FACTURE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC, CODE_ARTICLE, ID_LIGNE_FACTURE FROM ligne_facture WHERE CODE_RESERVATION = @CODE_RESERVATION AND ETAT_FACTURE = 0 ORDER BY DATE_FACTURE ASC"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CodeClient
            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

            Dim adapter As New MySqlDataAdapter(command)
            Dim tableFacture As New DataTable()

            adapter.Fill(tableFacture)

            'On selectionne l'ensemble des reglement du client
            'Dim query1 As String = "SELECT REF_REGLEMENT, NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, ID_REGLEMENT FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND CODE_RESERVATION=@CODE_RESERVATION AND IMPRIMER = 0 ORDER BY DATE_REGLEMENT ASC"
            Dim query1 As String = "SELECT REF_REGLEMENT, NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, ID_REGLEMENT FROM reglement WHERE  CODE_RESERVATION=@CODE_RESERVATION AND IMPRIMER = 0 ORDER BY DATE_REGLEMENT ASC"

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

                toutesLesFactures(i).dateOperation = CDate(tableReglement.Rows(i)("DATE_REGLEMENT")).ToShortDateString
                toutesLesFactures(i).Debit = 0
                toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
                toutesLesFactures(i).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")
                toutesLesFactures(i).Article = ""
                toutesLesFactures(i).Code = tableReglement.Rows(i)("NUM_REGLEMENT")
                toutesLesFactures(i).Id = tableReglement.Rows(i)("ID_REGLEMENT")

                totalReglement = totalReglement + tableReglement.Rows(i)("MONTANT_VERSE")
                niemElementDutableau = i

            Next

            niemElementDutableau += 1

            'Puis dans notre structure on ajoute les factures a la suite des reglements

            For i = 0 To tableFacture.Rows.Count - 1

                toutesLesFactures(niemElementDutableau).dateOperation = CDate(tableFacture.Rows(i)("DATE_FACTURE")).ToShortDateString
                toutesLesFactures(niemElementDutableau).Debit = tableFacture.Rows(i)("MONTANT_TTC")
                toutesLesFactures(niemElementDutableau).Credit = 0
                toutesLesFactures(niemElementDutableau).libelleOperation = tableFacture.Rows(i)("LIBELLE_FACTURE")
                toutesLesFactures(niemElementDutableau).Article = tableFacture.Rows(i)("CODE_ARTICLE")
                toutesLesFactures(niemElementDutableau).Code = tableFacture.Rows(i)("CODE_FACTURE")
                toutesLesFactures(niemElementDutableau).Id = tableFacture.Rows(i)("ID_LIGNE_FACTURE")

                totalFacture = totalFacture + tableFacture.Rows(i)("MONTANT_TTC")
                niemElementDutableau += 1

            Next

            'Enfin on insere le tout dans notre datagrid
            If (toutesLesFactures.Length > 0) Then

                For i = 0 To toutesLesFactures.Length - 1

                    Dim debit = 0
                    Dim credit = 0

                    If Not toutesLesFactures(i).libelleOperation = "" Then

                        If toutesLesFactures(i).Credit > 0 Then
                            credit = Format(toutesLesFactures(i).Credit, "#,##0")
                        Else
                            credit = 0
                        End If

                        If Not toutesLesFactures(i).Debit > 0 Then
                            debit = Format(toutesLesFactures(i).Debit, "#,##0")
                        Else
                            debit = 0
                        End If

                        GunaDataGridViewSituation.Rows.Add(i, CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"), toutesLesFactures(i).Article, toutesLesFactures(i).Code, toutesLesFactures(i).Id)


                        GunaDataGridViewSituation.Columns("credit").DefaultCellStyle.ForeColor = Color.DarkOliveGreen
                        GunaDataGridViewSituation.Columns("debit").DefaultCellStyle.ForeColor = Color.DarkRed

                    End If

                Next

                GunaDataGridViewSituation.Columns(0).Visible = False
                GunaDataGridViewSituation.Columns("debit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewSituation.Columns("credit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'GunaDataGridViewSituation.Columns("credit").Visible = False

                'Sorting the elements of situation client
                GunaDataGridViewSituation.Sort(GunaDataGridViewSituation.Columns(1), ListSortDirection.Descending)

            End If

            GunaTextBoxSolde.Text = Format(totalReglement - totalFacture, "#,##0")

        End If

    End Sub

    '--------------------------------------------------------------------------------------------------------------------

    'We open the facturationForm uppon clicking on button payer at the level of SituationClient opened by double clicking GunaPanelSolde
    Private Sub GunaButtonPayer_Click(sender As Object, e As EventArgs) Handles GunaButtonPayer.Click

        GlobalVariable.typeDeClientAFacturer = ""
        Me.Close()
        GlobalVariable.ouvertureDelaFenetreDeReglementApArtirDu = "reception"
        ReglementForm.Show()
        ReglementForm.TopMost = True

    End Sub

    'Opening of the folio when we click on facturer
    Private Sub GunaButtonFacturer_Click(sender As Object, e As EventArgs) Handles GunaButtonFacturer.Click

        If GunaButtonFacturer.Text = "Facturer" Or GunaButtonFacturer.Text = "Bill" Then
            FolioForm.Close()
            FolioForm.Show()
            FolioForm.TopMost = True
        ElseIf GunaButtonFacturer.Text = "Imprimer" Or GunaButtonFacturer.Text = "Print" Then
            Impression.PrintSituationDuClient(GunaDataGridViewSituation, GlobalVariable.codeReservationToUpdate)
        End If

        Me.Close()

    End Sub

    'GESTION DU ROUTAGE MANUEL
    Private Sub GunaButtonRoutageManuel_Click(sender As Object, e As EventArgs) Handles GunaButtonRoutageManuel.Click

        RoutageManuelForm.Show()

    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'TRANSFERER DES CHARGES D'UNE RESERVATION A UNE AUTRE

    Private Sub EnChambre()

        'On affiche toutes les reserv_conf dont la date saisie est entre la d'entrée et la date de sortie (inclusif)

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxCodeChambre.DataSource = table
            GunaComboBoxCodeChambre.ValueMember = "RESERVATION"
            GunaComboBoxCodeChambre.DisplayMember = "CHAMBRE"

        End If

        'connect.closeConnection()
    End Sub

    'AFFICHAGE DES INFORMATIONS POUR TRANSFERT
    Private Sub TransférerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransférerToolStripMenuItem.Click

        If GunaDataGridViewSituation.Rows.Count > 0 Then

            Dim montantDuTransfert As Double = 0

            For Each row As DataGridViewRow In GunaDataGridViewSituation.SelectedRows
                montantDuTransfert += Trim(row.Cells("debit").Value)
            Next

            GunaTextBoxMontantATransferer.Text = Format(montantDuTransfert, "#,##0.00")

        End If

        GunaTextBoxNomClient.Visible = True
        GunaPanelTransfertEnChambre.Visible = True
        GunaComboBoxCodeChambre.Visible = True
        'GunaTextBoxCodeResa.Visible = False
        LabelChambre.Visible = True
        LabelNomClient.Visible = True
        GunaButtonTransferer.Visible = True

        EnChambre()

        Dim resa As New Reservation()
        Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate
        Dim updatedSolde As Double = Functions.SituationDeReservation(CODE_RESERVATION)
        resa.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", updatedSolde)

        Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION)

    End Sub

    Private Sub GunaComboBoxCodeChambre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCodeChambre.SelectedIndexChanged

        If GunaComboBoxCodeChambre.SelectedIndex >= 0 Then

            Dim CODE_RESERVATION As String = GunaComboBoxCodeChambre.SelectedValue.ToString

            Dim reservationInfo As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

            If reservationInfo.Rows.Count > 0 Then

                GunaTextBoxNomClient.Text = reservationInfo.Rows(0)("NOM_CLIENT")
                GunaTextBoxCodeChambre.Text = reservationInfo.Rows(0)("CHAMBRE_ID")
                GunaTextBoxCodeReservation.Text = reservationInfo.Rows(0)("CODE_RESERVATION")
                GunaTextBoxCodeClient.Text = reservationInfo.Rows(0)("CLIENT_ID")

            End If

        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnulerTransfert.Click

        GunaTextBoxNomClient.Visible = False
        GunaComboBoxCodeChambre.Visible = False
        GunaPanelTransfertEnChambre.Visible = False
        'GunaTextBoxCodeResa.Visible = False
        LabelChambre.Visible = False
        LabelNomClient.Visible = False
        GunaButtonTransferer.Visible = False

    End Sub

    Private Sub GunaButtonTransferer_Click(sender As Object, e As EventArgs) Handles GunaButtonTransferer.Click

        If GunaDataGridViewSituation.Rows.Count > 0 Then

            Dim ligne_facture As New LigneFacture()

            For Each row As DataGridViewRow In GunaDataGridViewSituation.SelectedRows

                Dim NOM_CLIENT As String = GunaTextBoxNomClient.Text
                Dim CODE_ARTICLE As String = row.Cells("Article").Value.ToString
                Dim NOM_ARTICLE As String = row.Cells("designation").Value.ToString
                Dim CODE_CHAMBRE As String = GunaTextBoxCodeChambre.Text
                Dim NEW_CODE_RESERVATION As String = GunaTextBoxCodeReservation.Text
                Dim OLD_CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate
                Dim CODE_FACTURE As String = Trim(row.Cells("Code").Value.ToString)
                Dim ID_LIGNE_FACTURE As Integer = row.Cells("Id").Value

                'DANS LA FONCTION CI DESSOUS NOUS TRAITONS LA MISE AJOURS DE LA MAINCOURANTE

                ligne_facture.transfertDeLigneChargeEnChambreVersEnChambre(CODE_ARTICLE, CODE_CHAMBRE, NEW_CODE_RESERVATION, OLD_CODE_RESERVATION, CODE_FACTURE, NOM_CLIENT, ID_LIGNE_FACTURE)

            Next

            For Each row As DataGridViewRow In GunaDataGridViewSituation.SelectedRows

                GunaDataGridViewSituation.Rows.RemoveAt(row.Index)

            Next

            Dim reservation As New Reservation()

            Dim CODE_RESERVATION = GunaTextBoxCodeReservation.Text
            Dim CODE_RESERVATION_TO_UPDATE = GlobalVariable.codeReservationToUpdate

            'On met a jours le solde de la nouvelle reservation
            reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))

            'On met a jours le solde de l'ancienne reservation
            reservation.updateSoldeReservation(CODE_RESERVATION_TO_UPDATE, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION_TO_UPDATE))

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Transfert effectué vers la chambre ( " & GunaTextBoxCodeChambre.Text & " ) avec succès ! ", "Transfert de charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Transfer onto the Room ( " & GunaTextBoxCodeChambre.Text & " ) successfully ! ", "Charge Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            'GunaDataGridViewSituation.Columns.Clear()

            GunaTextBoxSolde.Text = 0

            GunaPanelTransfertEnChambre.Visible = False

            Dim Solde As Double = 0

            For i = 0 To GunaDataGridViewSituation.Rows.Count - 1
                Solde += GunaDataGridViewSituation.Rows(i).Cells("credit").Value - GunaDataGridViewSituation.Rows(i).Cells("debit").Value
            Next

            GunaTextBoxSolde.Text = Format(Solde, "#,##0")

            'MISE A JOURS DU SOLDE DE LA RESERVATION EN COURS APRES TRANSFERT DE CHARGE OU REGLEMENT

            MainWindow.GunaLabelSolde.Text = GunaTextBoxSolde.Text

            If 0 > Solde Then
                MainWindow.GunaLabelSolde.ForeColor = Color.Red
            ElseIf Solde = 0 Then
                MainWindow.GunaLabelSolde.ForeColor = Color.Black
            Else
                MainWindow.GunaLabelSolde.ForeColor = Color.Green
            End If

            'ON DOIT METTRE AJOUR LES MAINCOURANTES DES DEUX RESERVATIONS


        End If

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub AnnulerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnulerToolStripMenuItem.Click

        '---------------------------------------

        Me.Hide()
        Dim CODE_RESERVATION As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then

            If GunaDataGridViewSituation.Rows.Count > 0 Then

                Dim dialog As DialogResult

                If GlobalVariable.actualLanguageValue = 1 Then
                    dialog = MessageBox.Show("Voulez-vous vraiment annuler cette charge", "Annulation de charge", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Else
                    dialog = MessageBox.Show("Do you reallly want to cancel the charge", "Charge cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                End If

                If dialog = DialogResult.Yes Then

                    Dim Motif As String = ""

                    If GlobalVariable.actualLanguageValue = 1 Then
                        Motif = InputBox("Raison d'annulation", "Annulation de charge", "")
                    Else
                        Motif = InputBox("Reason of cancelation", "Cancelation of charge", "")
                    End If

                    Dim ID_LIGNE_FACTURE As Integer

                    For Each row As DataGridViewRow In GunaDataGridViewSituation.SelectedRows

                        Dim debit As Double = row.Cells("debit").Value

                        '1- INSCRIRE LA CONTRE ECRITURE 
                        '1-1. TESTER SI CHARGES OU REGLEMENT

                        If debit > 0 Then

                            '-SI OUI

                            ID_LIGNE_FACTURE = row.Cells("Id").Value

                            Dim insert As String = "INSERT INTO ligne_facture (`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`, `GRIFFE_UTILISATEUR`, `VALEUR_CONSO`, `ETAT`) 
                            SELECT `CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`, `GRIFFE_UTILISATEUR`, `VALEUR_CONSO`, `ETAT` FROM ligne_facture WHERE ID_LIGNE_FACTURE = @ID_LIGNE_FACTURE"

                            Dim command As New MySqlCommand(insert, GlobalVariable.connect)

                            command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int32).Value = ID_LIGNE_FACTURE
                            command.ExecuteNonQuery()

                            Dim nomDelaTable As String = "ligne_facture"

                            Dim infoSupArticle As DataTable = Functions.getElementByCode(ID_LIGNE_FACTURE, nomDelaTable, "ID_LIGNE_FACTURE")

                            Dim NEW_LIBELLE As String = ""
                            Dim MONTANT_HT As Double = 0
                            Dim PRIX_UNITAIRE_TTC As Double = 0
                            Dim MONTANT_TTC As Double = 0
                            Dim POINT_DE_VENTE As String = ""
                            Dim FUSIONNEE As String = ""

                            If infoSupArticle.Rows.Count > 0 Then
                                NEW_LIBELLE = infoSupArticle.Rows(0)("LIBELLE_FACTURE")
                                MONTANT_HT = infoSupArticle.Rows(0)("MONTANT_HT")
                                PRIX_UNITAIRE_TTC = infoSupArticle.Rows(0)("PRIX_UNITAIRE_TTC")
                                MONTANT_TTC = infoSupArticle.Rows(0)("MONTANT_TTC")
                                POINT_DE_VENTE = infoSupArticle.Rows(0)("TYPE_LIGNE_FACTURE")
                                FUSIONNEE = infoSupArticle.Rows(0)("FUSIONNEE")
                            End If

                            Dim NEW_ID_LIGNE_FACTURE As Integer = Functions.latInsertedElementId(nomDelaTable, "ID_LIGNE_FACTURE")

                            Dim nomDuChamp As String = "LIBELLE_FACTURE"
                            Dim ValeurDuChamp As String = Motif.ToUpper() & " " & NEW_LIBELLE
                            Dim nomDuChampDuCode As String = "ID_LIGNE_FACTURE"
                            Dim valeurDuChampDuCode As Integer = NEW_ID_LIGNE_FACTURE
                            Dim variableType As Integer = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "CODE_UTILISATEUR_CREA"
                            ValeurDuChamp = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                            variableType = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "CODE_FACTURE"
                            ValeurDuChamp = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")
                            variableType = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "MONTANT_HT"
                            ValeurDuChamp = MONTANT_HT * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "PRIX_UNITAIRE_TTC"
                            ValeurDuChamp = PRIX_UNITAIRE_TTC * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "MONTANT_TTC"
                            ValeurDuChamp = MONTANT_TTC * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            '2- METTRE A JOUR LA MAIN COURANTE JOURNALIERE PAR APPORT AU BAR-RESTAURANT

                            Dim mettreAJour As Boolean = True

                            If Trim(FUSIONNEE).Equals("HEBERGEMENT") Then
                                mettreAJour = False
                            End If

                            If Trim(FUSIONNEE).Equals("ACCOMMODATION") Then
                                mettreAJour = False
                            End If

                            If mettreAJour Then

                                Dim ligne_facture As New LigneFacture()
                                ligne_facture.miseAjoursApresAnnulationDeChargeDepuisLaSituationDuCLient(NEW_ID_LIGNE_FACTURE)

                            Else

                                Dim CODE_MAIN_COURANTE_JOURNALIERE As String = GlobalVariable.codeMainCouranteJournaliereToUpdate
                                Functions.updateOfFieldsAddSubtract("main_courante_journaliere", "TOTAL_GENERAL", MONTANT_TTC * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)
                                Functions.updateOfFieldsAddSubtract("main_courante_journaliere", "TOTAL_JOUR", MONTANT_TTC * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)
                                Functions.updateOfFieldsAddSubtract("main_courante_journaliere", "MONTANT_ACCORDE", MONTANT_TTC * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)

                            End If

                        Else

                            'GESTION DES REGLEMENTS

                        End If

                    Next

                    GunaDataGridViewSituation.Rows.Clear()
                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Charge annulée avec succès", "Annulation de Charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Charge canceled successfully", "Charge cancelation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then

                        CODE_RESERVATION = GlobalVariable.ReservationToUpdate(0)("CODE_RESERVATION")

                        Dim solde As Double = Functions.SituationDeReservation(CODE_RESERVATION)
                        Dim resa As New Reservation()
                        resa.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", solde)

                        MainWindow.GunaLabelSolde.Text = Format(solde, "#,##0")

                        If 0 > solde Then
                            MainWindow.GunaLabelSolde.ForeColor = Color.Red
                        ElseIf solde = 0 Then
                            MainWindow.GunaLabelSolde.ForeColor = Color.Black
                        Else
                            MainWindow.GunaLabelSolde.ForeColor = Color.Green
                        End If

                        MainWindow.MainWindowManualActivation()

                        MainWindow.Refresh()

                    End If

                End If

                Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION)

            Else
                If True Then
                    MessageBox.Show("Aucune charge à annuler !", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No charge to cancel !", "Cancelation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            '---------------------------------------

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "You don't have the necessary right to cancel"
                languageTitle = "Correction"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Vous n'avez pas le droit necessaire pour Annuler"
                languageTitle = "Correction"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        Me.Show()

        SituationDuClient()

    End Sub

    Private Sub RéductionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RéductionToolStripMenuItem.Click

        Me.Hide()
        Dim CODE_RESERVATION As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then

            If GunaDataGridViewSituation.Rows.Count > 0 Then

                Dim dialog As DialogResult

                If GlobalVariable.actualLanguageValue = 1 Then
                    dialog = MessageBox.Show("Vous êtes sur le point de faire une réduction", "Réduction de charge", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Else
                    dialog = MessageBox.Show("You are about to do a reduction", "Charge reduction", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                End If

                If dialog = DialogResult.Yes Then

                    Dim MONTANT As Double = 0

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MONTANT = Double.Parse(InputBox("MONTANT DE LA REDUCTION ", "Réduction de charge", ""))
                    Else
                        MONTANT = Double.Parse(InputBox("REDUCTION AMOUNT ", "Charge Discount", ""))
                    End If

                    Dim ID_LIGNE_FACTURE As Integer

                    For Each row As DataGridViewRow In GunaDataGridViewSituation.SelectedRows

                        Dim debit As Double = row.Cells("debit").Value

                        '1- INSCRIRE LA CONTRE ECRITURE 
                        '1-1. TESTER SI CHARGES OU REGLEMENT

                        If debit > 0 Then

                            '-SI OUI

                            ID_LIGNE_FACTURE = row.Cells("Id").Value

                            Dim insert As String = "INSERT INTO ligne_facture (`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`, `GRIFFE_UTILISATEUR`, `VALEUR_CONSO`, `ETAT`) 
                            SELECT `CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`, `GRIFFE_UTILISATEUR`, `VALEUR_CONSO`, `ETAT` FROM ligne_facture WHERE ID_LIGNE_FACTURE = @ID_LIGNE_FACTURE"

                            Dim command As New MySqlCommand(insert, GlobalVariable.connect)

                            command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int32).Value = ID_LIGNE_FACTURE
                            command.ExecuteNonQuery()

                            Dim nomDelaTable As String = "ligne_facture"

                            Dim infoSupArticle As DataTable = Functions.getElementByCode(ID_LIGNE_FACTURE, nomDelaTable, "ID_LIGNE_FACTURE")

                            Dim NEW_LIBELLE As String = ""
                            Dim MONTANT_HT As Double = 0
                            Dim PRIX_UNITAIRE_TTC As Double = 0
                            Dim MONTANT_TTC As Double = 0
                            Dim POINT_DE_VENTE As String = ""
                            Dim FUSIONNEE As String = ""

                            If infoSupArticle.Rows.Count > 0 Then
                                NEW_LIBELLE = infoSupArticle.Rows(0)("LIBELLE_FACTURE")
                                'MONTANT_HT = infoSupArticle.Rows(0)("MONTANT_HT")
                                MONTANT_HT = MONTANT
                                'PRIX_UNITAIRE_TTC = infoSupArticle.Rows(0)("PRIX_UNITAIRE_TTC")
                                PRIX_UNITAIRE_TTC = MONTANT
                                'MONTANT_TTC = infoSupArticle.Rows(0)("MONTANT_TTC")
                                MONTANT_TTC = MONTANT
                                POINT_DE_VENTE = infoSupArticle.Rows(0)("TYPE_LIGNE_FACTURE")
                                FUSIONNEE = infoSupArticle.Rows(0)("FUSIONNEE")
                            End If

                            Dim NEW_ID_LIGNE_FACTURE As Integer = Functions.latInsertedElementId(nomDelaTable, "ID_LIGNE_FACTURE")

                            Dim nomDuChamp As String = "LIBELLE_FACTURE"
                            Dim ValeurDuChamp As String = "REDUCTION " & NEW_LIBELLE

                            If GlobalVariable.actualLanguageValue = 0 Then
                                ValeurDuChamp = "DISCOUNT " & NEW_LIBELLE
                            End If

                            Dim nomDuChampDuCode As String = "ID_LIGNE_FACTURE"
                            Dim valeurDuChampDuCode As Integer = NEW_ID_LIGNE_FACTURE
                            Dim variableType As Integer = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "CODE_UTILISATEUR_CREA"
                            ValeurDuChamp = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                            variableType = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "CODE_FACTURE"
                            ValeurDuChamp = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")
                            variableType = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "MONTANT_HT"
                            ValeurDuChamp = MONTANT_HT * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "PRIX_UNITAIRE_TTC"
                            ValeurDuChamp = PRIX_UNITAIRE_TTC * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "MONTANT_TTC"
                            ValeurDuChamp = MONTANT_TTC * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            '2- METTRE A JOUR LA MAIN COURANTE JOURNALIERE

                            Dim mettreAJour As Boolean = True

                            If Trim(FUSIONNEE).Equals("HEBERGEMENT") Then
                                mettreAJour = False
                            End If

                            If Trim(FUSIONNEE).Equals("ACCOMMODATION") Then
                                mettreAJour = False
                            End If

                            If mettreAJour Then

                                Dim ligne_facture As New LigneFacture()
                                'ligne_facture.miseAjoursApresAnnulationDeChargeDepuisLaSituationDuCLient(NEW_ID_LIGNE_FACTURE)

                            Else

                                Dim CODE_MAIN_COURANTE_JOURNALIERE As String = GlobalVariable.codeMainCouranteJournaliereToUpdate
                                Functions.updateOfFieldsAddSubtract("main_courante_journaliere", "TOTAL_GENERAL", MONTANT_TTC * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)
                                Functions.updateOfFieldsAddSubtract("main_courante_journaliere", "TOTAL_JOUR", MONTANT_TTC * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)
                                Functions.updateOfFieldsAddSubtract("main_courante_journaliere", "MONTANT_ACCORDE", MONTANT_TTC * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)

                            End If

                        Else

                            'GESTION DES REGLEMENTS

                        End If

                    Next

                    GunaDataGridViewSituation.Rows.Clear()

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Réduction fait avec succès", "Réduction de Charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Reduction succesffully donne", "Discount", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then

                        CODE_RESERVATION = GlobalVariable.ReservationToUpdate(0)("CODE_RESERVATION")

                        Dim solde As Double = Functions.SituationDeReservation(CODE_RESERVATION)

                        Dim resa As New Reservation()
                        resa.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", solde)


                        MainWindow.GunaLabelSolde.Text = Format(solde, "#,##0")

                        If 0 > solde Then
                            MainWindow.GunaLabelSolde.ForeColor = Color.Red
                        ElseIf solde = 0 Then
                            MainWindow.GunaLabelSolde.ForeColor = Color.Black
                        Else
                            MainWindow.GunaLabelSolde.ForeColor = Color.Green
                        End If

                        MainWindow.MainWindowManualActivation()

                        MainWindow.Refresh()

                    End If

                End If

                Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION)

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Aucune ligne à Réduire !", "Réduction", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No ligne selected for reduction !", "Reduction", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            '---------------------------------------

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "You don't have the necessary right to make a discount"
                languageTitle = "Correction"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Vous n'avez pas le droit necessaire d'éffectuer des réduction"
                languageTitle = "Correction"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        Me.Show()

        SituationDuClient()

    End Sub

End Class

