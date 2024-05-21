Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class ReglementLettrageForm

    'Destinée à contenir l'ensemble des fatures du client pour des mis à jours

    'Dim connect As New DataBaseManipulation()

    Private Sub ReglementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.paymaster(GlobalVariable.actualLanguageValue)


        AutoLoadBanque()

        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail

        GunaComboBoxTypeDeFiltre.SelectedIndex = 1

        GunaImageButtonFermer.Visible = True
        GunaImageButtonReduce.Visible = True
        GunaImageButtonFermer.BringToFront()
        GunaImageButtonReduce.BringToFront()

        GunaTextBoxMontantVerse.Text = 0
        '---------------------------------------- CONTENT OF REGLEMENTFORM COMING FROM THE FRONTDESK ---------------------------------

        'We initialise the content of reglementForm with information coming from the frontdesk: Solde-SistuationClient-Reglement

        '----------------------------------------END  CONTENT OF REGLEMENTFORM COMING FROM THE FRONTDESK ---------------------------------

        'Setting a value for the paiment mode on load
        GunaComboBoxModeReglement.SelectedIndex = 0

        GunaComboBoxNatureOperation.SelectedIndex = 0

        indicateurDEtatDeCaisse()

        GunaComboBoxNatureOperation.SelectedIndex = 1

    End Sub


    Public Sub GestionOuvertureDeCaisse()

        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

        Dim CODE_CAISSE As String = ""

        Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

        If CAISSE_UTILISATEUR.Rows.Count > 0 Then

            CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

        End If

        Dim ETAT_CAISSE As Integer = 1
        Dim caissier As New Caisse()

        caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

        If GlobalVariable.actualLanguageValue = 1 Then
            MessageBox.Show("Caisse ouverte avec succès", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Cash Register", "Cssh Register", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Public Sub indicateurDEtatDeCaisse()

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") Then

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim caisse As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If caisse.Rows.Count > 0 Then

                Dim CODE_CAISSE As String = caisse.Rows(0)("CODE_CAISSE")

                If caisse.Rows(0)("ETAT_CAISSE") = 0 Then
                    PanelSituationCaisse.BackColor = Color.Red

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaButtonOuvertureFermeture.Text = "Ouvrir Caisse"
                    Else
                        GunaButtonOuvertureFermeture.Text = "Open Cash Register"
                    End If

                    Timer1.Stop()

                    LabelSituationCaisse.Text = 0

                Else
                    PanelSituationCaisse.BackColor = Color.LightGreen

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaButtonOuvertureFermeture.Text = "Fermer Caisse"
                    Else
                        GunaButtonOuvertureFermeture.Text = "Close Cash Register"
                    End If

                    Timer1.Start()

                End If

            End If

        End If

    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Public Sub SitutationDesDettes()
        'Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT ORDER BY DATE_REGLEMENT DESC"
        Dim getUserQuery = "SELECT * FROM facture"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        'Dim SituationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)
        Dim SituationDeDette As DataTable = dt

        Dim TotalDette As Double = 0

        If SituationDeDette.Rows.Count > 0 Then

            'On selection l'ensemble des reglements d'un jour donné

            For i = 0 To SituationDeDette.Rows.Count - 1
                TotalDette += SituationDeDette.Rows(i)("RESTE_A_PAYER")
            Next

            LabelDettes.Text = Format(Math.Abs(TotalDette), "#,##0")

        Else
            LabelDettes.Text = 0
        End If

    End Sub

    Public Sub SituationDeCaisse()

        'Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT ORDER BY DATE_REGLEMENT DESC"
        Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND ETAT=@ETAT AND IMPRIMER=@IMPRIMER ORDER BY DATE_REGLEMENT DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0
        command.Parameters.Add("@IMPRIMER", MySqlDbType.Int64).Value = 2

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Dim SituationDeCaisse As DataTable = dt

        Dim TotalFacture As Double = 0

        If situationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To situationDeCaisse.Rows.Count - 1
                TotalFacture += situationDeCaisse.Rows(i)("MONTANT_VERSE")
            Next

            '------------------------------ RETRANCHEMENT DES RETENUES ------------------------------------------------

            Dim getUserQuery01 = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND ETAT=@ETAT AND IMPRIMER=@IMPRIMER AND MODE_REGLEMENT=@MODE_REGLEMENT ORDER BY DATE_REGLEMENT DESC"

            Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)


            Dim MODE_REGLEMENT As String = "Retenue"

            command01.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
            command01.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0
            command01.Parameters.Add("@MODE_REGLEMENT", MySqlDbType.VarChar).Value = MODE_REGLEMENT
            command01.Parameters.Add("@IMPRIMER", MySqlDbType.Int64).Value = 2

            Dim adapter01 As New MySqlDataAdapter

            Dim dt01 As New DataTable()
            'Dim command As New MySqlCommand(query, GlobalVariable.connect)

            adapter01.SelectCommand = command01
            adapter01.Fill(dt01)

            Dim totalRetenue As Double = 0

            For i = 0 To dt01.Rows.Count - 1
                totalRetenue += dt01.Rows(i)("MONTANT_VERSE")
            Next
            '----------------------------------------------------------------------------------------------------------

            LabelSituationCaisse.Text = Format(TotalFacture - totalRetenue, "#,##0")

        Else
            LabelSituationCaisse.Text = 0
        End If

    End Sub

    Public Function SituationDeCaisseAmount(ByVal DateDebutStat As Date, ByVal DateFinStat As Date) As Double

        Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & DateDebutStat.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFinStat.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT ORDER BY DATE_REGLEMENT DESC"

        'Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND ETAT=@ETAT ORDER BY DATE_REGLEMENT DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        'Dim SituationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)
        Dim SituationDeCaisse As DataTable = dt

        Dim TotalFacture As Double = 0

        If SituationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To SituationDeCaisse.Rows.Count - 1
                TotalFacture += SituationDeCaisse.Rows(i)("MONTANT_VERSE")
            Next

            Dim situationDeCaisseCasDeRemboursement As DataTable = Functions.SituationDeCaisseCasDeRemboursement(GlobalVariable.DateDeTravail)

            Dim TotalRembourse As Double = 0
            'On selection l'ensemble des remboursement d'un jour donné
            If situationDeCaisseCasDeRemboursement.Rows.Count > 0 Then

                For j = 0 To situationDeCaisseCasDeRemboursement.Rows.Count - 1
                    TotalRembourse += situationDeCaisseCasDeRemboursement.Rows(j)("MONTANT_HT")
                Next

                'On soustrait les montant remboursé des montants encaissé
                TotalFacture -= Math.Abs(TotalRembourse)

            End If

        End If

        Return TotalFacture

    End Function

    'Autocompletion using live search trick (Custom AutoCompletion) ----------------------- CUSTOM AUTOCOMPLETION ----------------------
    Private Sub GunaTextBoxNom_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNom.TextChanged

        If Not Trim(GunaTextBoxNom.Text).Equals("") Then

            If GunaComboBoxTypeDeFiltre.SelectedIndex >= 0 Then

                GunaDataGridViewClient.Visible = True

                Dim query As String = ""
                If GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Then
                    query = "SELECT NOM_PRENOM, CODE_CLIENT FROM client WHERE NOM_PRENOM LIKE '%" & GunaTextBoxNom.Text & "%' AND TYPE_CLIENT = @TYPE_CLIENT OR NUM_COMPTE LIKE '%" & GunaTextBoxNom.Text & "%' AND TYPE_CLIENT = @TYPE_CLIENT"
                ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then
                    query = "SELECT NOM_PRENOM, CODE_CLIENT FROM client WHERE NOM_PRENOM LIKE '%" & GunaTextBoxNom.Text & "%' AND TYPE_CLIENT = @TYPE_CLIENT OR NUM_COMPTE LIKE '%" & GunaTextBoxNom.Text & "%' AND TYPE_CLIENT = @TYPE_CLIENT"
                ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Account" Then
                    'CLIENT N'ETANT PAS ASSOCIE A UN COMPTE
                    query = "SELECT NUMERO_COMPTE, INTITULE, CODE_CLIENT FROM compte WHERE INTITULE LIKE '%" & GunaTextBoxNom.Text & "%' AND CODE_CLIENT = @CODE_CLIENT AND ETAT_DU_COMPTE=@ETAT_DU_COMPTE"
                End If

                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                Dim ETAT_DU_COMPTE As Integer = 1

                command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = GunaComboBoxTypeDeFiltre.SelectedItem
                command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = ""
                command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE

                Dim adapter As New MySqlDataAdapter(command)

                Dim table As New DataTable()

                adapter.Fill(table)

                If (table.Rows.Count > 0) Then

                    GunaDataGridViewClient.DataSource = table

                    If (Not GunaComboBoxTypeDeFiltre.SelectedItem = "Compte") Or (Not GunaComboBoxTypeDeFiltre.SelectedItem = "Account") Then
                        GunaDataGridViewClient.Columns("CODE_CLIENT").Visible = False
                    End If

                Else
                    GunaDataGridViewClient.Columns.Clear()
                    GunaDataGridViewClient.Visible = False
                End If

                If GunaTextBoxNom.Text = "" Then
                    GunaDataGridViewClient.Visible = False
                End If

            End If

        Else
            GunaDataGridViewClient.DataSource = Nothing
            GunaDataGridViewClient.Visible = False
        End If

    End Sub

    Structure SituationClient

        Dim REFERENCE
        Dim DATE_OPERATION
        Dim NATURE
        Dim LIBELLE
        Dim MONTANT
        Dim MONTANT_SOLDE
        Dim SOLDE

    End Structure

    'Retrait de toute les fature liés au client pour regmelent ou encaissement

    Private Sub soldeSuivantUnComptePaymaster(ByVal NUMERO_COMPTE_PAYMASTER As String)

        Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE, LETTRAGE  FROM facture WHERE ETAT_FACTURE = 1 AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
        command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = NUMERO_COMPTE_PAYMASTER
        'command2.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, CODE_MODE , LETTRAGE FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 2 ORDER BY DATE_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = NUMERO_COMPTE_PAYMASTER
        'command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim CODE_MODE As String = "AVOIR"
        'command3.Parameters.Add("@CODE_MODE", MySqlDbType.VarChar).Value = CODE_MODE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationClient

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        'GunaDataGridViewListeFacture.Rows.Clear()

        'niemElementDutableau += 1

        'Enfin on insere le tout dans notre datagrid

        For j = 0 To tableFacture.Rows.Count - 1

            totalFacture = totalFacture + tableFacture.Rows(j)("MONTANT")
            totalReglement += tableFacture.Rows(j)("MONTANT_AVANCE")

        Next

        For k = 0 To tableReglement.Rows.Count - 1

            'totalReglement = totalReglement + tableReglement.Rows(k)("MONTANT_VERSE")

            'Dim AVOIR As String = "REGLEMENT"

            'If Not Trim(tableReglement.Rows(k)("CODE_MODE")).Equals("") Then
            'AVOIR = tableReglement.Rows(k)("CODE_MODE")
            'End If

            'GunaDataGridViewListeFacture.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, AVOIR, tableReglement.Rows(k)("REF_REGLEMENT"), tableReglement.Rows(k)("LETTRAGE"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"), "")

        Next

        '''GunaTextBoxSoldeCompte.Text = Format(Double.Parse(totalReglement) - Double.Parse(totalFacture), "#,##0")

    End Sub

    Private Sub ListeDesFacturesEtReglementsSuivantUnComptePaymasterCodeClient(ByVal DateDebut As Date, ByVal DateFin As Date)

        Dim query2 As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FISCALITE") = 1 Then
            query2 = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, CODE_CLIENT FROM facture WHERE FSC=@FSC AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE = 1 ORDER BY DATE_FACTURE DESC"
        Else
            query2 = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, CODE_CLIENT FROM facture WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE = 1 ORDER BY DATE_FACTURE DESC"

        End If
        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)

        'command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = NUMERO_COMPTE_PAYMASTER
        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FISCALITE") = 1 Then
            command2.Parameters.Add("@FSC", MySqlDbType.Int32).Value = 1
        End If

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture2 As New DataTable()

        adapter2.Fill(tableFacture2)

        Dim tailleDuTableau As Integer = tableFacture2.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationClient

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        GunaDataGridViewListeFacture.Rows.Clear()

        'niemElementDutableau += 1

        'Enfin on insere le tout dans notre datagrid

        For j = 0 To tableFacture2.Rows.Count - 1

            totalFacture += tableFacture2.Rows(j)("MONTANT")

            GunaDataGridViewListeFacture.Rows.Add(tableFacture2.Rows(j)("REFERENCE"), CDate(tableFacture2.Rows(j)("DATE")).ToShortDateString, "FACTURE", tableFacture2.Rows(j)("LIBELLE"), tableFacture2.Rows(j)("LETTRAGE"), Format(tableFacture2.Rows(j)("MONTANT"), "#,##0"), Format(tableFacture2.Rows(j)("MONTANT SOLDE"), "#,##0"), Format(Double.Parse(tableFacture2.Rows(j)("MONTANT SOLDE")) - Double.Parse(tableFacture2.Rows(j)("MONTANT")), "#,##0"), tableFacture2.Rows(j)("CODE_CLIENT"))

        Next

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------

    End Sub

    Private Sub ListeDesFacturesEtReglementsSuivantUnComptePaymaster(ByVal NUMERO_COMPTE_PAYMASTER As String, ByVal DateDebut As Date, ByVal DateFin As Date)

        Dim query2 As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FISCALITE") = 1 Then
            query2 = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, CODE_CLIENT FROM facture WHERE FSC=@FSC AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE = 1 AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        Else
            query2 = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, CODE_CLIENT FROM facture WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE = 1 AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        End If

        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
        command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = NUMERO_COMPTE_PAYMASTER

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FISCALITE") = 1 Then
            command2.Parameters.Add("@FSC", MySqlDbType.Int32).Value = 1
        End If

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT), CODE_MODE , LETTRAGE FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 2 ORDER BY DATE_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = NUMERO_COMPTE_PAYMASTER
        'command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim CODE_MODE As String = "AVOIR"
        'command3.Parameters.Add("@CODE_MODE", MySqlDbType.VarChar).Value = CODE_MODE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationClient

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        GunaDataGridViewListeFacture.Rows.Clear()

        'niemElementDutableau += 1

        'Enfin on insere le tout dans notre datagrid

        For j = 0 To tableFacture.Rows.Count - 1

            totalFacture = totalFacture + tableFacture.Rows(j)("MONTANT")

            GunaDataGridViewListeFacture.Rows.Add(tableFacture.Rows(j)("REFERENCE"), CDate(tableFacture.Rows(j)("DATE")).ToShortDateString, "FACTURE", tableFacture.Rows(j)("LIBELLE"), tableFacture.Rows(j)("LETTRAGE"), Format(tableFacture.Rows(j)("MONTANT"), "#,##0"), Format(tableFacture.Rows(j)("MONTANT SOLDE"), "#,##0"), Format(Double.Parse(tableFacture.Rows(j)("MONTANT SOLDE")) - Double.Parse(tableFacture.Rows(j)("MONTANT")), "#,##0"))

        Next

        For k = 0 To tableReglement.Rows.Count - 1

            totalReglement = totalReglement + tableReglement.Rows(k)("MONTANT_VERSE")

            Dim AVOIR As String = "REGLEMENT"

            If Not Trim(tableReglement.Rows(k)("CODE_MODE")).Equals("") Then
                AVOIR = tableReglement.Rows(k)("CODE_MODE")
            End If

            GunaDataGridViewListeFacture.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, AVOIR, tableReglement.Rows(k)("REF_REGLEMENT"), tableReglement.Rows(k)("LETTRAGE"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"), "")

        Next

        'GunaTextBoxSoldeCompte.Text = Format(Double.Parse(totalReglement) - Double.Parse(totalFacture), "#,##0")

    End Sub

    Private Sub situationDuClientEntreprise(ByVal CODE_CLIENT As String)

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------

        Dim CODE_ENTREPRISE As String = Trim(CODE_CLIENT)

        Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE  FROM facture WHERE ETAT_FACTURE = 1 AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
        command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command2.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        For j = 0 To tableFacture.Rows.Count - 1
            totalFacture = totalFacture + tableFacture.Rows(j)("MONTANT")
            totalReglement += tableFacture.Rows(j)("MONTANT SOLDE")
        Next

        GunaTextBoxSoldeCompte.Text = Format(Double.Parse(totalReglement) - Double.Parse(totalFacture), "#,##0")

    End Sub

    Private Sub SoldeEntrepriseEtIndividuel(ByVal CODE_CLIENT As String)

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------

        Dim CODE_ENTREPRISE As String = Trim(CODE_CLIENT)

        Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE  FROM facture WHERE ETAT_FACTURE = 1 AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
        command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command2.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT), CODE_MODE , LETTRAGE FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 2 ORDER BY DATE_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim CODE_MODE As String = "AVOIR"
        'command3.Parameters.Add("@CODE_MODE", MySqlDbType.VarChar).Value = CODE_MODE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationClient

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        'GunaDataGridViewListeFacture.Rows.Clear()

        'niemElementDutableau += 1

        'Enfin on insere le tout dans notre datagrid

        For j = 0 To tableFacture.Rows.Count - 1
            totalFacture = totalFacture + tableFacture.Rows(j)("MONTANT")
            totalReglement = totalFacture + tableFacture.Rows(j)("MONTANT SOLDE")
        Next

        '''GunaTextBoxSoldeCompte.Text = Format(Double.Parse(totalReglement) - Double.Parse(totalFacture), "#,##0")

    End Sub

    Private Sub ListeDesFacturesEtReglements(ByVal CODE_CLIENT As String, ByVal DateDebut As Date, ByVal DateFin As Date)

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------
        Dim query2 As String = ""
        Dim FISCALITE As Integer = 0
        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FISCALITE") = 1 Then
            query2 = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, CODE_CLIENT FROM facture WHERE FSC=@FSC AND ETAT_FACTURE = 1 AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        Else
            query2 = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, CODE_CLIENT FROM facture WHERE FSC=@FSC AND ETAT_FACTURE = 1 AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        End If

        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
        command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command2.Parameters.Add("@FSC", MySqlDbType.Int16).Value = FISCALITE

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT), CODE_MODE , LETTRAGE FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 2 ORDER BY DATE_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        Dim CODE_MODE As String = "AVOIR"

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationClient

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        GunaDataGridViewListeFacture.Rows.Clear()

        'niemElementDutableau += 1

        'Enfin on insere le tout dans notre datagrid

        For j = 0 To tableFacture.Rows.Count - 1

            totalFacture = totalFacture + tableFacture.Rows(j)("MONTANT")

            GunaDataGridViewListeFacture.Rows.Add(tableFacture.Rows(j)("REFERENCE"), CDate(tableFacture.Rows(j)("DATE")).ToShortDateString, "FACTURE", tableFacture.Rows(j)("LIBELLE"), tableFacture.Rows(j)("LETTRAGE"), Format(tableFacture.Rows(j)("MONTANT"), "#,##0"), Format(tableFacture.Rows(j)("MONTANT SOLDE"), "#,##0"), Format(Double.Parse(tableFacture.Rows(j)("MONTANT SOLDE")) - Double.Parse(tableFacture.Rows(j)("MONTANT")), "#,##0"))

        Next

        For k = 0 To tableReglement.Rows.Count - 1

            totalReglement = totalReglement + tableReglement.Rows(k)("MONTANT_VERSE")

            Dim AVOIR As String = "REGLEMENT"

            If Not Trim(tableReglement.Rows(k)("CODE_MODE")).Equals("") Then
                AVOIR = tableReglement.Rows(k)("CODE_MODE")
            End If

            GunaDataGridViewListeFacture.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, AVOIR, tableReglement.Rows(k)("REF_REGLEMENT"), tableReglement.Rows(k)("LETTRAGE"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"), "")

        Next

        'GunaTextBoxSoldeCompte.Text = Format(Double.Parse(totalReglement) - Double.Parse(totalFacture), "#,##0")

    End Sub

    'Retourner le rang par apport a une entreprise

    Public Function rang(ByVal CODE_CLIENT As String) As Integer

        Dim position As Integer

        Dim entreprise As DataTable

        Dim existQuery As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            existQuery = "SELECT client.NOM_CLIENT AS 'ENTREPRISE', client.CODE_CLIENT , Sum(MONTANT_TTC) AS 'CA' from facture, client WHERE TYPE_CLIENT ='COMPANY' AND facture.CODE_CLIENT = client.CODE_CLIENT GROUP BY facture.CODE_CLIENT ORDER BY 'CA' ASC"
        Else
            existQuery = "SELECT client.NOM_CLIENT AS 'ENTREPRISE',  client.CODE_CLIENT , Sum(MONTANT_TTC) AS 'CA' from facture, client WHERE TYPE_CLIENT ='ENTREPRISE' AND facture.CODE_CLIENT = client.CODE_CLIENT GROUP BY facture.CODE_CLIENT ORDER BY CA DESC"
        End If

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            LabelSur.Text = table.Rows.Count

            For i = 0 To table.Rows.Count - 1

                If table.Rows(i)("CODE_CLIENT").Equals(CODE_CLIENT) Then
                    Return i + 1
                End If

            Next

        End If

    End Function

    'When we double click on a cell of our custom datagrid (client d) used for autocompletion
    Private Sub GunaDataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewClient.CellClick

        GunaDataGridViewClient.Visible = False

        effacementDesDetails()

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewClient.Rows(e.RowIndex)

            Dim CodeClient As String = ""
            Dim numeroCompte As String = ""

            If GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Account" Then

                numeroCompte = row.Cells("NUMERO_COMPTE").Value.ToString

                Dim compte As DataTable = Functions.getElementByCode(numeroCompte, "compte", "NUMERO_COMPTE")

                If compte.Rows.Count > 0 Then

                    GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")

                    GunaTextBoxClientAFacturer.Text = compte.Rows(0)("INTITULE")

                    GunaTextBoxSoldeCompte.Text = Format(compte.Rows(0)("SOLDE_COMPTE"), "#,##0")

                    GunaTextBoxPersonneAContacter.Text = compte.Rows(0)("PERSONNE_A_CONTACTER")
                    GunaTextBoxContactPaiement.Text = compte.Rows(0)("CONTACT_PAIEMENT")
                    GunaTextBoxAdressePaiement.Text = compte.Rows(0)("ADRESSE_DE_FACTURATION")
                    GunaTextBoxDelaiPaiement.Text = compte.Rows(0)("DELAI_DE_PAIEMENT")

                    GunaTextBoxPlafonds.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0")

                    'ListeDesFacturesEtReglementsSuivantUnComptePaymaster(numeroCompte)

                End If

                GunaTextBoxNom.Clear()

            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then

                CodeClient = row.Cells("CODE_CLIENT").Value.ToString

                GunaTextBoxCodeEntreprise.Text = CodeClient

                Dim client As DataTable = Functions.getElementByCode(CodeClient, "client", "CODE_CLIENT")

                If client.Rows.Count > 0 Then

                    GunaTextBoxClientAFacturer.Text = client.Rows(0)("NOM_PRENOM")

                    Dim compte As DataTable = Functions.getElementByCode(Trim(CodeClient), "compte", "CODE_CLIENT")

                    If compte.Rows.Count > 0 Then

                        GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")

                        GunaTextBoxSoldeCompte.Text = Format(compte.Rows(0)("SOLDE_COMPTE"), "#,##0")
                        GunaTextBoxPersonneAContacter.Text = compte.Rows(0)("PERSONNE_A_CONTACTER")
                        GunaTextBoxContactPaiement.Text = compte.Rows(0)("CONTACT_PAIEMENT")
                        GunaTextBoxAdressePaiement.Text = compte.Rows(0)("ADRESSE_DE_FACTURATION")
                        GunaTextBoxDelaiPaiement.Text = compte.Rows(0)("DELAI_DE_PAIEMENT")

                        GunaTextBoxPlafonds.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0")

                    End If

                    GunaTextBoxNom.Clear()

                    'We take all the invoice of the current user for reglement and insert the values of the field of RegelementForm
                    'ListeDesFacturesEtReglements(CodeClient)

                    Dim factures As DataTable = Functions.getElementByCode(CodeClient, "facture", "CODE_CLIENT")

                    If factures.Rows.Count > 0 Then

                        Dim ChiffresAffaire As Double = 0

                        For j = 0 To factures.Rows.Count - 1
                            ChiffresAffaire += factures.Rows(j)("MONTANT_TTC")
                        Next

                        GunaTextBoxChiffreAffaire.Text = Format(ChiffresAffaire, "#,##0")

                        If GunaComboBoxTypeDeFiltre.SelectedIndex = 1 Then
                            Label21.Visible = True
                            LabelRang.Visible = True
                            LabelRang.Text = rang(CodeClient)
                        Else
                            Label21.Visible = False
                            LabelRang.Visible = False
                            LabelRang.Text = "-"
                            LabelSur.Text = "-"
                        End If
                    Else

                        If GunaComboBoxTypeDeFiltre.SelectedIndex = 1 Then
                            Label21.Visible = True
                            LabelRang.Visible = True
                            LabelRang.Text = "-"
                            LabelSur.Text = "-"
                        End If

                    End If

                    GunaTextBoxAPayer.Text = 0

                    GunaTextBoxSolde.Text = 0

                    GunaTextBoxMontantVerse.Text = 0

                    If GunaComboBoxNatureOperation.SelectedIndex >= 0 Then
                        GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " " & Trim(GunaTextBoxClientAFacturer.Text) & " " & Date.Now()
                    End If

                    situationDuClientEntreprise(CodeClient)

                End If

            End If

        End If

    End Sub

    Structure SituationFacture

        Dim dateOperation
        Dim libelleOperation
        Dim Debit
        Dim Credit

    End Structure

    Public Sub DetailDeFacture(ByVal CODE_FACTURE As String)

        Dim query As String = "SELECT CODE_FACTURE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC FROM ligne_facture WHERE CODE_FACTURE = @CODE_FACTURE AND ETAT_FACTURE = 1 ORDER BY DATE_FACTURE DESC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        Dim adapter As New MySqlDataAdapter(command)
        Dim tableFacture As New DataTable()

        adapter.Fill(tableFacture)

        Dim query1 As String = "SELECT NUM_REGLEMENT, NUM_FACTURE, MONTANT_VERSE, DATE_REGLEMENT, REF_REGLEMENT FROM reglement WHERE NUM_FACTURE = @CODE_FACTURE AND IMPRIMER = 1 ORDER BY DATE_REGLEMENT DESC"
        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim tableReglement As New DataTable()

        adapter1.Fill(tableReglement)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count + tableReglement.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationFacture

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        'Puis dans notre structure on ajoute les factures a la suite des reglements
        Dim n = tableFacture.Rows.Count

        For i = 0 To tableFacture.Rows.Count - 1

            toutesLesFactures(i).dateOperation = CDate(tableFacture.Rows(i)("DATE_FACTURE")).ToShortDateString
            toutesLesFactures(i).Debit = tableFacture.Rows(i)("MONTANT_TTC")
            toutesLesFactures(i).Credit = 0
            toutesLesFactures(i).libelleOperation = tableFacture.Rows(i)("LIBELLE_FACTURE")

            totalFacture = totalFacture + tableFacture.Rows(i)("MONTANT_TTC")

        Next

        For i = 0 To tableReglement.Rows.Count - 1

            toutesLesFactures(n).dateOperation = CDate(tableReglement.Rows(i)("DATE_REGLEMENT")).ToShortDateString
            toutesLesFactures(n).Debit = 0
            toutesLesFactures(n).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
            toutesLesFactures(n).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")

            totalReglement += tableReglement.Rows(i)("MONTANT_VERSE")

            n += 1

        Next

        'Enfin on insere le tout dans notre datagrid
        If (toutesLesFactures.Length > 0) Then

            GunaDataGridViewDetailsFactures.Rows.Clear()

            For i = 0 To toutesLesFactures.Length - 1

                If Not toutesLesFactures(i).libelleOperation = "" Then
                    GunaDataGridViewDetailsFactures.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"))
                End If

            Next

            'Sorting the elements of situation client
            GunaDataGridViewDetailsFactures.Sort(GunaDataGridViewDetailsFactures.Columns(1), ListSortDirection.Descending)

        End If

        GunaTextBoxSolde.Text = Format(totalFacture, "#,##0")

        Dim montantAPayer As Double = 0

        GunaComboBoxNatureOperation.SelectedItem = "REMBOURSEMENT"

        'We affect values to the textbox below the datagrid
        'GunaTextBoxAPayer.Text = Format(totalFacture, "#,##0")

        Dim solde As Double = 0

        Double.TryParse(GunaTextBoxAPayer.Text, solde)
        Dim soldeAregler = solde
        GunaTextBoxSolde.Text = GunaTextBoxAPayer.Text
        'Solde = Debit - credit

        If soldeAregler >= 0 Then '

            GunaComboBoxNatureOperation.SelectedItem = "REGLEMENT"

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelMontantAPayer.Text = "Montant à payer"
                LabelSolde.Text = "Solde à payer"

            Else
                LabelMontantAPayer.Text = "Amount to Pay"
                LabelSolde.Text = "Balance to Pay"

            End If

            GunaTextBoxMontantVerse.Text = 0

            GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " " & GunaTextBoxClientAFacturer.Text & " " & Date.Now()
            'we enable the button as we can pay
            'GunaButtonEnregistrerReglement.Enabled = True

        Else

            ' means we dont have some thing to pay solde a regler is nothing also

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelMontantAPayer.Text = "Montant à rembourser"
                LabelSolde.Text = "Solde à rembourser"
                GunaTextBoxReference.Text = "REBOURSEMENT " & GunaTextBoxClientAFacturer.Text & " " & GlobalVariable.DateDeTravail
            Else
                LabelMontantAPayer.Text = "Amount to Refund"
                LabelSolde.Text = "Balance to Refund"
                GunaTextBoxReference.Text = "REFUND " & GunaTextBoxClientAFacturer.Text & " " & GlobalVariable.DateDeTravail
            End If


            GunaTextBoxAPayer.Text = Format(Double.Parse(GunaTextBoxAPayer.Text) * -1, "#,##0")
            GunaTextBoxMontantVerse.Text = 0


            'We desactivate the button that permit to save as there is nothing to pay
            'GunaButtonEnregistrerReglement.Enabled = False

        End If

        GunaTextBoxSolde.Enabled = False
        GunaTextBoxAPayer.Enabled = False

    End Sub

    'On recalcul le solde lorsque le montant versé varie
    Private Sub GunaTextBoxMontantVerse_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantVerse.TextChanged

        Dim APayer As Double = 0
        Dim montantVerse As Double = 0
        Dim solde As Double = 0

        Double.TryParse(GunaTextBoxAPayer.Text, APayer)
        Double.TryParse(GunaTextBoxMontantVerse.Text, montantVerse)

        If Not APayer = 0 Then
            GunaTextBoxSolde.Text = Format(APayer - montantVerse, "#,##0")
        End If

    End Sub


    'We save the reglement form information
    Private Sub GunaButtonEnregistrerClient_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerReglement.Click

        Me.Cursor = Cursors.WaitCursor

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") Then

            'Même si on a le droit a la caisse on doit encore être associé à une caisse pour pouvoir encaisser

            If Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "caisse", "CODE_UTILISATEUR").Rows.Count > 0 Then

                Dim ETAT_CAISSE As Integer = 0

                Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                Dim CODE_CAISSE As String = ""

                Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                If CAISSE_UTILISATEUR.Rows.Count > 0 Then
                    ETAT_CAISSE = CAISSE_UTILISATEUR.Rows(0)("ETAT_CAISSE")
                End If

                If ETAT_CAISSE = 0 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bien vouloir ouvrir votre caisse!!", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Please open your Cash Box!!", "Cash Box Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    GlobalVariable.fenetreDouvervetureDeCaisse = "comptable"

                    passwordVerifivationForm.Show()
                    passwordVerifivationForm.TopMost = True

                Else

                    Dim montantVerse As Double = Trim(GunaTextBoxMontantVerse.Text)

                    Dim CODE_CLIENT As String = ""

                    Dim CODE_RESERVATION As String = Trim(GunaTextBoxCodeReservation.Text)

                    If GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Account" Then
                        CODE_CLIENT = GunaTextBoxCompteDebiteur.Text
                    Else
                        CODE_CLIENT = Trim(GunaTextBoxCodeEntreprise.Text)
                    End If

                    If Trim(GunaTextBoxMontantVerse.Text) = "" Then
                        GunaTextBoxMontantVerse.Text = 0
                    End If

                    Dim MODE_REG_INFO_SUP_1 As String = ""
                    Dim MODE_REG_INFO_SUP_2 As String = ""
                    Dim MODE_REG_INFO_SUP_3 As Date = Date.Now().ToShortDateString

                    If GunaComboBoxModeReglement.SelectedIndex = 1 Then
                        MODE_REG_INFO_SUP_1 = GunaComboBoxBanqueEmettrice.SelectedValue.ToString
                        MODE_REG_INFO_SUP_2 = GunaTextBoxCheque.Text
                    ElseIf GunaComboBoxModeReglement.SelectedIndex = 2 Then
                        MODE_REG_INFO_SUP_1 = MaskedTextBoxNumeroCarte.Text
                        MODE_REG_INFO_SUP_2 = MaskedTextBoxCVV.Text
                        MODE_REG_INFO_SUP_3 = GunaDateTimePickerDateExpiration.Value.ToShortDateString()
                    ElseIf GunaComboBoxModeReglement.SelectedIndex = 3 Then
                        MODE_REG_INFO_SUP_1 = GunaTextBoxEntreprise.Text
                        MODE_REG_INFO_SUP_2 = GunaTextBoxNumeroCompte.Text
                    ElseIf GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then
                        MODE_REG_INFO_SUP_1 = GunaTextBoxContact.Text
                    ElseIf GunaComboBoxModeReglement.SelectedIndex = 6 Then
                        MODE_REG_INFO_SUP_1 = GunaComboBoxAvoir.SelectedValue.ToString
                    ElseIf GunaComboBoxModeReglement.SelectedIndex = 7 Then 'virement bancaire
                        MODE_REG_INFO_SUP_1 = GunaComboBoxBanqueVirement.SelectedValue.ToString
                        MODE_REG_INFO_SUP_2 = GunaTextBoxReferenceVirement.Text
                    End If

                    'If Double.Parse(GunaTextBoxMontantVerse.Text) >= Double.Parse(GunaTextBoxAPayer.Text) Then
                    If Double.Parse(GunaTextBoxMontantVerse.Text) > 0 Then

                        'We update the state of the values of the invoice
                        Dim facture As New LigneFacture()

                        'We have to update each facture in the list of the client facture
                        Dim montanVerse As Double = GunaTextBoxMontantVerse.Text
                        Dim montanVerseAvantRetranchement As Double = 0

                        'GESTION DES ENCAISSEMENTS
                        'Insert a line into reglement
                        Dim reglement As New Reglement()
                        Dim caisse As New Caisse()

                        Dim NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "")

                        Dim NUM_FACTURE = Trim(GunaTextBoxCodeFacture.Text)

                        Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        Dim MONTANT_VERSE = Double.Parse(GunaTextBoxMontantVerse.Text)

                        Dim DATE_REGLEMENT = GlobalVariable.DateDeTravail
                        Dim MODE_REGLEMENT = GunaComboBoxModeReglement.SelectedItem
                        Dim MODE_REGLEMENT_INDEX As Integer = GunaComboBoxModeReglement.SelectedIndex
                        Dim REF_REGLEMENT = Trim(GunaTextBoxReference.Text)
                        Dim CODE_MODE = ""
                        Dim IMPRIMER = 2
                        Dim CODE_AGENCE = GlobalVariable.codeAgence

                        '------------------- RECEPTION -----------------
                        'IMPRIMER = 0 : REGLEMENT NOUVELLEMENT GENERE
                        'IMPRIMER = 1 : REGLEMENT CLOTURE DANS LE FOLIO

                        '------------------ BAR / RECEPTION ------------
                        'ETAT = 0 : REGLEMENT NOUVELLEMENT GENERE
                        'ETAT = 1 : REGLEMENT CLOTURE LORS DE LA FERMETURE DE CAISSE POUR NE PLUS L'AFFICHER

                        '----------------- COMPTABILITE ---------------
                        'IMPRIMER = 2 : REGLEMENT NOUVELLEMENT GENERE

                        '----------------- CAISSIER(E) PRINCIPAL(E) -------------------
                        'IMPRIMER = 3 : REGLEMENT NOUVELLEMENT GENERE

                        Dim NUMERO_BLOC_NOTE As String = ""

                        Dim MainForm As New MainWindow()

                        'CAS DE REMBOURSEMENT
                        If Trim(LabelMontantAPayer.Text).Equals("Montant à rembourser") Or Trim(LabelMontantAPayer.Text).Equals("Amount to Refund") Then

                            Dim factureDeRemboursement As New Facture()

                            Dim CODE_FACTURE As String = Functions.GeneratingRandomCode("facture", "")
                            Dim CODE_COMMANDE As String = ""
                            Dim NUMERO_TABLE As String = ""
                            Dim CODE_MODE_PAIEMENT As String = MODE_REGLEMENT
                            Dim NUM_MOUVEMENT As String = ""
                            Dim DATE_FACTURE As String = GlobalVariable.DateDeTravail
                            Dim CODE_COMMERCIAL As String = ""
                            Dim MONTANT_HT As Double = MONTANT_VERSE
                            Dim TAXE As Double = 0
                            Dim MONTANT_TTC As Double = MONTANT_VERSE
                            Dim AVANCE As Double = MONTANT_VERSE
                            Dim RESTE_A_PAYER As Double = 0
                            Dim DATE_PAIEMENT As Date = GlobalVariable.DateDeTravail
                            Dim ETAT_FACTURE As String = 0
                            Dim LIBELLE_FACTURE As String = GunaTextBoxReference.Text
                            Dim MONTANT_TRANSPORT As Double = 0
                            Dim MONTANT_REMISE As Double = 0
                            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                            Dim CODE_UTILISATEUR_ANNULE As String = ""
                            Dim CODE_UTILISATEUR_VALIDE As String = ""
                            Dim NOM_CLIENT_FACTURE As String = GunaTextBoxClientAFacturer.Text
                            Dim MONTANT_AVANCE As Double = 0
                            Dim TYPE As String = GlobalVariable.typeChambreOuSalle

                            If True Then
                                'apres insertion dans la facture on insère dans ligne facture

                                Dim ligneFactureDeremboursement As New LigneFacture()

                                Dim CODE_MOUVEMENT As String = ""
                                Dim CODE_CHAMBRE As String = ""

                                If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                                    CODE_CHAMBRE = GlobalVariable.ReservationToUpdate.Rows(0)("CHAMBRE_ID")
                                End If

                                Dim NUMERO_PIECE As String = ""
                                Dim CODE_ARTICLE As String = ""
                                Dim CODE_LOT As String = ""
                                Dim QUANTITE As Double = 1
                                Dim PRIX_UNITAIRE_TTC As Double = MONTANT_VERSE

                                Dim HEURE_FACTURE As DateTime = Now().ToShortTimeString()

                                Dim DATE_OCCUPATION As Date = GlobalVariable.DateDeTravail
                                Dim HEURE_OCCUPATION As DateTime = Now().ToShortTimeString()

                                Dim TYPE_LIGNE_FACTURE As String = "Remboursement"
                                Dim NUMERO_SERIE As String = ""
                                Dim NUMERO_ORDRE As String = ""
                                Dim DESCRIPTION As String = ""
                                Dim MONTANT_TAXE As Double = 0
                                Dim NUMERO_SERIE_DEBUT As String = ""
                                Dim NUMERO_SERIE_FIN As String = ""
                                Dim CODE_MAGASIN As String = ""
                                Dim FUSIONNEE As String = ""

                                If ligneFactureDeremboursement.insertLigneFacture(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, NUMERO_BLOC_NOTE) Then

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        MessageBox.Show("Remboursement effectué avec succès", "Remboursement", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Else
                                        MessageBox.Show("Successful refund", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If

                                End If

                            End If

                        Else

                            Dim messageText As String = "Règlement enregistré avec succès !!"

                            If GlobalVariable.actualLanguageValue = 0 Then
                                messageText = "Payment successfully registered!"
                            End If

                            If Trim(GunaComboBoxNatureOperation.SelectedItem) = "AVOIR" Then
                                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "AV")
                                CODE_MODE = "AVOIR"
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageText = "Avoir enregistré avec succès !!"
                                Else
                                    messageText = "Payment successfully registered!"
                                End If
                                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "AV")
                            End If

                            If Trim(GunaComboBoxNatureOperation.SelectedItem) = "DEPOT GARANTIE" Then
                                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "AV")
                                CODE_MODE = "DEPOT GARANTIE"
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageText = "Dépôt de garantie enregistré avec succès !!"
                                Else
                                    messageText = "Security deposit successfully registered!"
                                End If
                                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "DG")
                            End If


                            If Trim(GunaComboBoxNatureOperation.SelectedItem) = "RETENUE TVA" Then
                                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "AV")
                                CODE_MODE = "RETENUE TVA"
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageText = "Retenue sur TVA enregistrée avec succès !!"
                                Else
                                    messageText = "VAT withholding successfully recorded !"
                                End If
                                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "RTVA")
                            End If

                            'CREATION DES 

                            If GunaComboBoxModeReglement.SelectedItem = "Avoir" Or GunaComboBoxModeReglement.SelectedItem = "Dépôt de garantie" Then
                                'CODE_MODE = "AVOIR"
                                MONTANT_VERSE = MONTANT_VERSE * -1

                                If GunaComboBoxModeReglement.SelectedItem = "Avoir" Or GunaComboBoxModeReglement.SelectedItem = "Credit note" Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        messageText = "Règlement réalisé avec un avoir !!"
                                    Else
                                        messageText = "Payment made with a credit note!"
                                    End If
                                ElseIf GunaComboBoxModeReglement.SelectedItem = "Dépôt de garantie" Then

                                ElseIf GunaComboBoxModeReglement.SelectedItem = "Retenue sur TVA" Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        messageText = "Règlement réalisé avec un dépôt de garantie !!"
                                    Else
                                        messageText = "Payment made with a deposit !"
                                    End If
                                End If

                                'REGELEMENT AVEC AVOIR

                                If (MONTANT_VERSE * -1) <= Double.Parse(GunaTextBoxAPayer.Text) Then
                                    Dim MONTANT_VERSE_PAR_AVOIR As Double = Double.Parse(GunaTextBoxAPayer.Text) * -1

                                    reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE_PAR_AVOIR, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                End If

                            ElseIf GunaComboBoxModeReglement.SelectedItem = "Caution" Or GunaComboBoxModeReglement.SelectedItem = "Bail" Then

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageText = "Caution enregistrée avec succès !!"
                                Else
                                    messageText = "Bail successfully registered!"
                                End If

                                'GESTION DES CAUTIONS
                                Dim CODE_CAUTION As String = Functions.GeneratingRandomCodeWithSpecifications("caution", "")
                                Dim CODE_ENTREPRISE_CAUTION As String = GunaTextBoxCodeEntreprise.Text
                                Dim Debit As Double = 0
                                Dim Credit As Double = MONTANT_VERSE
                                Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
                                Dim CODE_UTILISATEUR_CREA = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                                Dim caution As New Reservation()
                                Dim TYPE_DEPOT_CAUTION As Integer = 0
                                caution.insertionCaution(CODE_CAUTION, CODE_ENTREPRISE_CAUTION, Debit, Credit, DATE_CREATION, CODE_UTILISATEUR_CREA, TYPE_DEPOT_CAUTION)

                            Else

                                'REGELEMENT NORMAL
                                reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                            End If

                            'INSERTION DE INFORMATIONS POUR LES REGLEMENTS ASSOCIES AUX BANQUES
                            If GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 7 Then

                                Dim banque As New Banque()
                                Dim CODE_BANQUE As String = ""

                                If MODE_REGLEMENT_INDEX = 1 Then

                                    If GunaComboBoxBanqueEmettrice.SelectedIndex >= 0 Then
                                        CODE_BANQUE = GunaComboBoxBanqueEmettrice.SelectedValue.ToString
                                    End If

                                End If

                                If MODE_REGLEMENT_INDEX = 2 Then

                                    If GunaComboBoxBanque.SelectedIndex >= 0 Then
                                        CODE_BANQUE = GunaComboBoxBanque.SelectedValue.ToString
                                    End If

                                End If

                                If MODE_REGLEMENT_INDEX = 7 Then

                                    If GunaComboBoxBanqueVirement.SelectedIndex >= 0 Then
                                        CODE_BANQUE = GunaComboBoxBanqueVirement.SelectedValue.ToString
                                    End If

                                End If

                                Dim MODE_REGELEMENT As String = GunaComboBoxModeReglement.SelectedItem
                                Dim CODE_REGLEMENT As String = NUM_REGLEMENT
                                Dim DEBIT As Double = 0
                                Dim CREDIT As Double = GunaTextBoxMontantVerse.Text
                                Dim CODE_TRANSCATION As String = Functions.GeneratingRandomCodePanne("banque_transaction", "")

                                'INFORMATION SUPLLEMTAIRE LIEES A LA CARTE DE CREDIT
                                banque.insertBanqueTransactions(CODE_BANQUE, MODE_REGELEMENT, CODE_REGLEMENT, DEBIT, CREDIT, CODE_AGENCE, CODE_TRANSCATION)


                            End If


                            'Mise a jours du solde de la caisse du caissier actuellement connecté en plus
                            'caisse.updateSoldeCaisse(CODE_CAISSIER, MONTANT_VERSE)

                            'MISE A JOURS DU COMPTE DU CLIENT SI RATTACHE A UNE ENTREPRISE

                            Dim compte As New Compte()

                            Dim compteEntreprise As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                            If compteEntreprise.Rows.Count > 0 Then

                                Dim NUMERO_COMPTE As String = compteEntreprise.Rows(0)("NUMERO_COMPTE")

                                Dim TOTAL_DEBIT As Double = 0
                                Dim TOTAL_CREDIT As Double = 0

                                If GunaComboBoxModeReglement.SelectedIndex = 0 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 3 Or GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then

                                    TOTAL_CREDIT = Double.Parse(GunaTextBoxMontantVerse.Text)

                                End If

                                'MISE AJOURS DU COMPTE DE L'ENTREPRISE
                                compte.updateCompteAlaClotureDuFolio(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT)

                            Else

                                Dim NUMERO_COMPTE As String = GunaTextBoxCompteDebiteur.Text

                                Dim TOTAL_DEBIT As Double = 0
                                Dim TOTAL_CREDIT As Double = 0

                                If GunaComboBoxModeReglement.SelectedIndex = 0 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 3 Or GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then

                                    TOTAL_CREDIT = Double.Parse(GunaTextBoxMontantVerse.Text)

                                End If

                                If GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Then
                                    compte.updateCompteApresTrasnfert(NUMERO_COMPTE, TOTAL_DEBIT, TOTAL_CREDIT)
                                Else
                                    compte.updateCompteAlaClotureDuFolio(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT)
                                End If

                            End If

                            MessageBox.Show(messageText, "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            'We set back montPAyer to 0
                            GunaTextBoxMontantVerse.Text = 0

                        End If

                        If Trim(GunaComboBoxNatureOperation.SelectedItem) = "REGLEMENT" Then

                            '****************************** REGLEMENTS DE L'ENSEMBLE DES FACTURES SELECTIONNEES* **************************************************************************
                            ReglementDesFacturesSelectionnees(montantVerse)

                        End If

                        effacementDesDetails()

                        If Trim(GunaTextBoxClientAFacturer.Text).Equals("") Then
                            ListeDesFacturesEtReglementsSuivantUnComptePaymasterCodeClient(GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)
                        Else

                            If GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Then
                                Dim NUMERO_COMPTE_PAYMASTER As String = GunaTextBoxCompteDebiteur.Text
                                ListeDesFacturesEtReglementsSuivantUnComptePaymaster(NUMERO_COMPTE_PAYMASTER, GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)
                            Else
                                ListeDesFacturesEtReglements(Trim(GunaTextBoxCodeEntreprise.Text), GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)
                            End If

                        End If

                        situationDuClientEntreprise(Trim(GunaTextBoxCodeEntreprise.Text))

                        SitutationDesDettes()

                    Else

                        'Montant versé inférieur au montant 

                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Bien vouloir saisir un montant correcte!", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            MessageBox.Show("Please enter a correct amount!", "Cash In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                        GunaTextBoxMontantVerse.Text = 0

                    End If

                    'Facturation des en chambres
                    Dim reservation As New Reservation()

                    GunaTextBoxCodeFacture.Clear()

                End If

                If Trim(GunaTextBoxClientAFacturer.Text).Equals("") Then
                    'GunaTextBoxCompteDebiteur.Clear()
                    'GunaTextBoxCodeEntreprise.Clear()
                    'GunaTextBoxInconnu.Clear()
                End If

            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Dim changementEffectue As Boolean = False

    'We refresh the content of the Folio Datagrids each time a new reglement is done
    Private Sub PayMasterForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        If changementEffectue Then

            effacementDesDetails()

            If GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Account" Then
                Dim NUMERO_COMPTE_PAYMASTER As String = GunaTextBoxCompteDebiteur.Text
                ListeDesFacturesEtReglementsSuivantUnComptePaymaster(NUMERO_COMPTE_PAYMASTER, GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)
            Else
                ListeDesFacturesEtReglements(Trim(GunaTextBoxCodeEntreprise.Text), GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)
            End If

            changementEffectue = False

        End If

    End Sub

    Private Sub GunaTextBoxEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxEntreprise.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxEntreprise.Text).Equals("") Then

            GunaTextBoxEntreprise.Clear()

            GunaDataGridViewCompany.Visible = False

        End If

        GunaDataGridViewCompany.Visible = True

        Dim query As String = "Select NOM_CLIENT From client WHERE NOM_CLIENT Like '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT
        OR
        NOM_CLIENT Like '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT_"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "ENTREPRISE"
        command.Parameters.Add("@TYPE_CLIENT_", MySqlDbType.VarChar).Value = "COMPANY"

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

            GunaTextBoxEntreprise.Text = row.Cells("NOM_CLIENT").Value.ToString
            'GunaTextBoxEntreprise.Text = company.Rows(0)("CODE_CLIENT")

            Dim client As DataTable = Functions.getElementByCode(Trim(GunaTextBoxEntreprise.Text), "client", "NOM_PRENOM")
            Dim codeClient As String = client.Rows(0)("CODE_CLIENT")

            Dim compte As DataTable = Functions.getElementByCode(codeClient, "compte", "CODE_CLIENT")

            If compte.Rows.Count > 0 Then
                GunaTextBoxNumeroCompte.Text = compte.Rows(0)("CODE_CLIENT")
            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaTextBoxNumeroCompte.Text = "Pas de compte"

                Else
                    GunaTextBoxNumeroCompte.Text = "No Account"

                End If
            End If

            GunaDataGridViewCompany.Visible = False

            'connect.closeConnection()

        End If

    End Sub

    Private Sub GunaComboBoxModereglement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxModeReglement.SelectedIndexChanged

        If GunaComboBoxModeReglement.SelectedIndex = 2 Then
            GunaPanelSupplementCarte.Visible = True
            LabelDateExpiration.Visible = True
            LabelNumCarte.Visible = True
            Label18.Visible = True
            LabelCVV.Visible = True
            GunaPanelSupplementCarte.BringToFront()
        Else
            GunaPanelSupplementCarte.Visible = False
            LabelDateExpiration.Visible = False
            LabelNumCarte.Visible = False
            LabelCVV.Visible = False
            Label18.Visible = False

        End If

        If GunaComboBoxModeReglement.SelectedIndex = 1 Then
            GunaPanelSupplementCheque.Visible = True
            LabelBanqueEmettrice.Visible = True
            LabelNumCompte.Visible = True
            GunaPanelSupplementCheque.BringToFront()
        Else
            GunaPanelSupplementCheque.Visible = False
            LabelBanqueEmettrice.Visible = False
            LabelNumCompte.Visible = False

        End If


        If GunaComboBoxModeReglement.SelectedIndex = 3 Then

            GunaPanelPriseEncharge.Visible = True

            LabelEntreprise.Visible = True
            GunaTextBoxEntreprise.Visible = True
            LabelNumeroCompte.Visible = True
            GunaTextBoxNumeroCompte.Visible = True

        Else

            GunaPanelPriseEncharge.Visible = False

            LabelEntreprise.Visible = False
            GunaTextBoxEntreprise.Visible = False
            GunaTextBoxNumeroCompte.Visible = False
            LabelNumeroCompte.Visible = False

        End If

        If GunaComboBoxModeReglement.SelectedIndex = 7 Then
            GunaPanelVirement.Visible = True
            Label20.Visible = True
            Label19.Visible = True
            GunaTextBoxReferenceVirement.Visible = True
        Else
            GunaPanelVirement.Visible = False
            Label20.Visible = False
            Label19.Visible = False
            GunaTextBoxReferenceVirement.Visible = False
        End If


        If GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then

            GunaPanelMobileMOney.Visible = True
            Gunalabel56.Visible = True
            GunaTextBoxContact.Visible = True
        Else
            GunaPanelMobileMOney.Visible = False
            Gunalabel56.Visible = False
            GunaTextBoxContact.Visible = False
        End If

        GunaTextBoxMontantVerse.Text = 0

        If GunaComboBoxModeReglement.SelectedIndex = 6 Then

            GunaPanelAvoir.Visible = True

            GunaComboBoxNatureOperation.SelectedIndex = 1

            Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxCodeEntreprise.Text)

            AutoLoadDesAvoir(CODE_ENTREPRISE)

            'Label1Avoir.BringToFront()
            'GunaComboBoxAvoir.BringToFront()

            Label1Avoir.Visible = True
            GunaTextBoxMontantAvoir.Visible = True
            LabelMontant.Visible = True

            GunaComboBoxAvoir.Visible = True

        Else

            GunaPanelAvoir.Visible = False

            Label1Avoir.Visible = False
            GunaComboBoxAvoir.Visible = False
            GunaTextBoxMontantAvoir.Visible = False
            LabelMontant.Visible = False

            GunaTextBoxCodeDeLAvoir.Clear()

        End If

        If GunaComboBoxModeReglement.SelectedIndex = 9 Then

            Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxCodeEntreprise.Text)

            GunaComboBoxNatureOperation.SelectedIndex = 1

            AutoLoadDesDepotsDeGarantie(CODE_ENTREPRISE)

            GunaPanelDepotDeGarantie.Visible = True

        Else
            GunaPanelDepotDeGarantie.Visible = False
        End If

        If GunaComboBoxModeReglement.SelectedIndex = 10 Then
            GunaComboBoxNatureOperation.SelectedIndex = 5
        Else

        End If

        If GunaComboBoxModeReglement.SelectedIndex = 8 Then
            GunaComboBoxNatureOperation.SelectedIndex = 4
        Else

        End If

    End Sub

    Private Sub GunaTextBoxSolde_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxSolde.TextChanged

        Dim balance As Double = 0

        Double.TryParse(GunaTextBoxSolde.Text, balance)

        If balance < 0 Then
            'LabelSolde.Text = "Solde à rembourser"
        Else
            'LabelSolde.Text = "Solde à payer"
        End If

    End Sub

    Private Sub GunaImageButtonReduce_Click(sender As Object, e As EventArgs) Handles GunaImageButtonReduce.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButtonFermer_Click(sender As Object, e As EventArgs) Handles GunaImageButtonFermer.Click
        Me.Close()
    End Sub

    'NATURE DE L'OPERATION EN COURS
    Private Sub GunaComboBoxNatureOperation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNatureOperation.SelectedIndexChanged

        If GunaComboBoxNatureOperation.SelectedItem = "REBOURSEMENT" Or GunaComboBoxNatureOperation.SelectedItem = "REFUND" Then

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelMontantAPayer.Text = "Montant à rembourser"
                LabelSolde.Text = "Solde à rembourser"
            Else
                LabelMontantAPayer.Text = "Amount to Refund"
                LabelSolde.Text = "Balance to Refund"
            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelMontantAPayer.Text = "Montant à payer"
                LabelSolde.Text = "Solde à payer"
            Else
                LabelMontantAPayer.Text = "Amount to Pay"
                LabelSolde.Text = "Balance to Pay"
            End If


        End If

        If GunaComboBoxNatureOperation.SelectedIndex >= 0 Then
            GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " " & Trim(GunaTextBoxClientAFacturer.Text) & " " & Date.Now()
        End If

    End Sub

    'VISUALISATION DES DETAILS D'UNE FACTUE QUELCONQUE

    Private Sub GunaDataGridViewListeFacture_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewListeFacture.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewListeFacture.Rows(e.RowIndex)

            Dim CODE_FACTURE As String = row.Cells("REFERENCE").Value.ToString

            Dim NATURE As String = row.Cells("NATURE").Value.ToString

            If Trim(GunaTextBoxCompteDebiteur.Text).Equals("") And Trim(GunaTextBoxCodeEntreprise.Text).Equals("") Then

                Dim CODE_CLIENT As String = ""

                If Not IsNothing(row.Cells("CODE_CLIENT").Value.ToString) Then

                    CODE_CLIENT = row.Cells("CODE_CLIENT").Value.ToString

                    Dim infoLigneFacture As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "NUMERO_COMPTE")

                    If infoLigneFacture.Rows.Count > 0 Then
                        GunaTextBoxCompteDebiteur.Text = infoLigneFacture.Rows(0)("NUMERO_COMPTE")
                        GunaTextBoxInconnu.Text = infoLigneFacture.Rows(0)("NUMERO_COMPTE")
                        GunaComboBoxTypeDeFiltre.SelectedItem = "Compte"
                    Else

                        infoLigneFacture = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

                        If infoLigneFacture.Rows.Count > 0 Then

                            GunaTextBoxInconnu.Text = infoLigneFacture.Rows(0)("CODE_CLIENT")
                            GunaTextBoxCodeEntreprise.Text = infoLigneFacture.Rows(0)("CODE_CLIENT")

                            If Trim(infoLigneFacture.Rows(0)("TYPE_CLIENT")).Equals("ENTREPRISE") Then

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise"
                                Else
                                    GunaComboBoxTypeDeFiltre.SelectedItem = "Company"
                                End If
                            Else

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel"
                                Else
                                    GunaComboBoxTypeDeFiltre.SelectedItem = "Individual"
                                End If
                            End If

                        End If

                    End If

                End If

            End If

            If NATURE = "FACTURE" Then

                GunaTextBoxCodeFacture.Text = Trim(CODE_FACTURE)

                DetailDeFacture(CODE_FACTURE)

                Dim facture As DataTable = Functions.getElementByCode(CODE_FACTURE, "facture", "CODE_FACTURE")

                If facture.Rows.Count > 0 Then

                    If facture.Rows(0)("RESTE_A_PAYER") = 0 Then
                        GunaButtonEnregistrerReglement.Visible = False
                    Else
                        GunaButtonEnregistrerReglement.Visible = True
                    End If
                End If

            Else

            End If

        End If

    End Sub

    Private Sub effacementDesDetails()

        GunaDataGridViewDetailsFactures.Rows.Clear()
        GunaTextBoxCodeFacture.Clear()

        GunaTextBoxAPayer.Text = 0
        GunaTextBoxMontantVerse.Text = 0
        GunaTextBoxSolde.Text = 0

        GunaTextBoxReference.Clear()

        GunaComboBoxNatureOperation.SelectedItem = "AVOIR"

        GunaComboBoxModeReglement.SelectedIndex = 0

        'GunaTextBoxCodeEntreprise.Clear()

    End Sub

    'EFFACEMENT DU DATAGRID DES DETAILS
    Private Sub GunaButtonEffacerDetail_Click(sender As Object, e As EventArgs) Handles GunaButtonEffacerDetail.Click

        effacementDesDetails()

        GunaTextBoxReference.Clear()

    End Sub

    Public Sub AutoLoadBanque()

        Dim query As String = "SELECT * From banque ORDER BY NOM_BANQUE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxBanque.DataSource = table
            GunaComboBoxBanque.ValueMember = "CODE_BANQUE"
            GunaComboBoxBanque.DisplayMember = "NOM_BANQUE"

            GunaComboBoxBanqueEmettrice.DataSource = table
            GunaComboBoxBanqueEmettrice.ValueMember = "CODE_BANQUE"
            GunaComboBoxBanqueEmettrice.DisplayMember = "NOM_BANQUE"

            GunaComboBoxBanqueVirement.DataSource = table
            GunaComboBoxBanqueVirement.ValueMember = "CODE_BANQUE"
            GunaComboBoxBanqueVirement.DisplayMember = "NOM_BANQUE"

        Else
            GunaComboBoxBanque.Items.Clear()
            GunaComboBoxBanqueEmettrice.Items.Clear()
            GunaComboBoxBanqueVirement.Items.Clear()
        End If

    End Sub



    Public Sub AutoLoadDesDepotsDeGarantie(ByVal CODE_ENTREPRISE As String)

        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 2 AND CODE_MODE = @CODE_MODE AND MONTANT_VERSE > 0 ORDER BY DATE_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim CODE_MODE As String = "DEPOT GARANTIE"
        command3.Parameters.Add("@CODE_MODE", MySqlDbType.VarChar).Value = CODE_MODE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        If (tableReglement.Rows.Count > 0) Then

            GunaComboBoxDepotDeGarantie.DataSource = tableReglement
            'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
            GunaComboBoxDepotDeGarantie.ValueMember = "NUM_REGLEMENT"
            GunaComboBoxDepotDeGarantie.DisplayMember = "REF_REGLEMENT"

        End If

    End Sub

    Public Sub AutoLoadDesAvoir(ByVal CODE_ENTREPRISE As String)

        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 2 AND CODE_MODE = @CODE_MODE AND MONTANT_VERSE > 0 ORDER BY DATE_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim CODE_MODE As String = "AVOIR"
        command3.Parameters.Add("@CODE_MODE", MySqlDbType.VarChar).Value = CODE_MODE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        If (tableReglement.Rows.Count > 0) Then

            GunaComboBoxAvoir.DataSource = tableReglement
            'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
            GunaComboBoxAvoir.ValueMember = "NUM_REGLEMENT"
            GunaComboBoxAvoir.DisplayMember = "REF_REGLEMENT"

        End If

    End Sub

    Private Sub GunaComboBoxAvoir_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxAvoir.SelectedIndexChanged

        If GunaComboBoxAvoir.SelectedIndex >= 0 Then

            Dim Avoir As DataTable = Functions.getElementByCode(GunaComboBoxAvoir.SelectedValue.ToString, "reglement", "NUM_REGLEMENT")

            If Avoir.Rows.Count > 0 Then

                'ON UTILISE QUE LES AVOIR A VALEUR NEGATIVE POUR REGLER
                If Avoir.Rows(0)("MONTANT_VERSE") > 0 Then

                    'POUR CHAQUE AVOIR ON DOIT DETERMINER SI IL A DEJA ETE UTILISE POUR REGLER DES FACTURES
                    ' SI OUI
                    '1- ON DOIT RECUPERER TOUTS LES AVOIR A VALEUR NEGATIVE ASSOCIER A LA VOIR ORIGINAL 
                    '- ON RECHERCHE LES AVOIRS AYANT POUR CODE DE LETTRAGE LE CODE DE L'AVOIR ORIGINAL
                    'A FIN DE DETERMINER LE SOLDE DE L'AVOIR ORIGINAL A UTILISER DONC A AFFICHER
                    Dim CODE_AVOIR_ORIGINAL As String = Avoir.Rows(0)("NUM_REGLEMENT")

                    Dim avoirNegatifDeLAvoirOriginal As DataTable = Functions.getElementByCode(CODE_AVOIR_ORIGINAL, "reglement", "LETTRAGE")

                    If avoirNegatifDeLAvoirOriginal.Rows.Count > 0 Then

                        Dim MONTANT_TOTAL_DEJA_UTILISE As Double = 0

                        For i = 0 To avoirNegatifDeLAvoirOriginal.Rows.Count - 1
                            MONTANT_TOTAL_DEJA_UTILISE += avoirNegatifDeLAvoirOriginal.Rows(i)("MONTANT_VERSE")
                        Next

                        GunaTextBoxMontantAvoir.Text = Format(Avoir.Rows(0)("MONTANT_VERSE") + MONTANT_TOTAL_DEJA_UTILISE, "#,##0")
                        GunaTextBoxMontantVerse.Text = Format(Avoir.Rows(0)("MONTANT_VERSE") + MONTANT_TOTAL_DEJA_UTILISE, "#,##0")

                    Else

                        'SI NON 
                        '1- ON AFFICHE SON MONTANT ORIGINAL

                        GunaTextBoxMontantAvoir.Text = Format(Avoir.Rows(0)("MONTANT_VERSE"), "#,##0")
                        GunaTextBoxMontantVerse.Text = Format(Avoir.Rows(0)("MONTANT_VERSE"), "#,##0")

                    End If

                    GunaTextBoxCodeDeLAvoir.Text = Avoir.Rows(0)("NUM_REGLEMENT")

                End If

            End If

        End If

    End Sub

    'REGLEMENT DE L'ENSEMBLE DES FACTURES SELECTIONNEES

    Structure Facture
        Dim CODE_FACTURE
    End Structure

    Dim ENSEMBLE_DES_FACTURES(50) As Facture

    Private Sub TransférerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransférerToolStripMenuItem.Click

        Dim NATURE_OPERATION As String = GunaDataGridViewListeFacture.CurrentRow.Cells("NATURE").Value.ToString

        If Trim(NATURE_OPERATION) = "FACTURE" Then

            Dim MONTANT_TOTAL_DES_FACTURES As Double = 0
            Dim CODE_FACTURE As String = ""


            If GunaDataGridViewListeFacture.Rows.Count > 0 Then

                Dim i As Integer = 0

                For Each row As DataGridViewRow In GunaDataGridViewListeFacture.SelectedRows

                    CODE_FACTURE = Trim(row.Cells(0).Value.ToString)

                    MONTANT_TOTAL_DES_FACTURES += Double.Parse(Trim(row.Cells(7).Value))

                    ENSEMBLE_DES_FACTURES(i).CODE_FACTURE = CODE_FACTURE

                    i += 1

                Next

                GunaTextBoxAPayer.Text = Format(Math.Abs(MONTANT_TOTAL_DES_FACTURES), "#,##0")

                GunaComboBoxNatureOperation.SelectedItem = "REGLEMENT"

            End If

        Else
            'REGLEMENT DES REGLEMENTS
        End If


    End Sub

    Private Sub ReglementDesFacturesSelectionnees(ByVal montantVerse As Double)

        'CETTE PROCEDURE CE CONTENTE DE METTRE A JOURS LES ETATS DES FACTURES (DEBIT, CREDIT, AVANCE, SOLDE)
        'RECUPERATION DU CODE DE REGLEMENT INSERER
        Dim tableName As String = "reglement"
        Dim codeFieldName As String = "NUM_REGLEMENT"

        Dim CODE_REGLEMENT As String = Functions.latInsertedElementCode(tableName, codeFieldName)

        Dim facture As New Facture()

        Dim montantTotalAPayer As Double = 0

        If Trim(GunaTextBoxMontantVerse.Text) = "" Then
            GunaTextBoxMontantVerse.Text = 0
        End If

        Dim factureSelectionnee As DataTable

        'ENSEMBLE DES FACTURES SELECTIONNEES PUIS ON DETERMINE LE MONTANT ASSOCIE AUX RETENUES SUR TVA AFIN D'AJOUTER#
        'CE MONTANT AU MONTAN VERSE 

        'ON PARCOURS L'ENSEMBLES DES LIGNES SELECTIONNEES PUIS 
        '--------------------------------------------------------
        Dim CODE_FACTURE_RTVA As String = ""
        Dim MONTANT_RETENU_TVA As Double = 0

        For i = 0 To ENSEMBLE_DES_FACTURES.Length - 1

            CODE_FACTURE_RTVA = ENSEMBLE_DES_FACTURES(i).CODE_FACTURE

            If Not CODE_FACTURE_RTVA Is Nothing Then

                If CODE_FACTURE_RTVA.Contains("RTVA") Then

                    Dim infoSupRTVA As DataTable = Functions.getElementByCode(CODE_FACTURE_RTVA, "reglement", "NUM_REGLEMENT")

                    If infoSupRTVA.Rows.Count > 0 Then

                        MONTANT_RETENU_TVA += infoSupRTVA.Rows(0)("MONTANT_VERSE")

                        Dim TABLE_ = "reglement"
                        Dim CONDITION_FIELD_NAME_ = "NUM_REGLEMENT" '
                        Dim CONDITION_FIELD_VALUE_ = CODE_FACTURE_RTVA
                        Dim LETTRAGE_ = CODE_REGLEMENT

                        miseAJourDuLettrage(TABLE_, LETTRAGE_, CONDITION_FIELD_NAME_, CONDITION_FIELD_VALUE_)

                    End If

                End If

            End If

        Next

        montantVerse += MONTANT_RETENU_TVA

        '--------------------------------------------------------
        For i = 0 To ENSEMBLE_DES_FACTURES.Length - 1

            Dim CODE_FACTURE As String = ENSEMBLE_DES_FACTURES(i).CODE_FACTURE
            Dim CODE_MODE_PAIEMENT As String = GunaComboBoxModeReglement.SelectedItem.ToString
            Dim DATE_PAIEMENT As Date = GlobalVariable.DateDeTravail
            Dim ETAT_FACTURE As String = 1
            Dim MONTANT_AVANCE As Double = 0
            Dim RESTE_A_PAYER As Double = 0

            'montantTotalAPayer += Functions.getElementByCode(CODE_FACTURE, "facture", "CODE_FACTURE").Rows(i)("MONTANT_TTC")
            factureSelectionnee = Functions.getElementByCode(CODE_FACTURE, "facture", "CODE_FACTURE")

            'TANT QUE LE MONTANT VERSE EST ENCORE SUFFISAMENT GRAND POUR REGLER LES FACTURES

            If factureSelectionnee.Rows.Count > 0 And montantVerse >= 0 Then

                Dim MONTANT_FACTURE_ENCOURS As Double = Double.Parse(factureSelectionnee.Rows(0)("MONTANT_TTC"))
                'ON DETERMINE SI LA FACTURE EST DEJA REGLE OU NON
                If Not Double.Parse(factureSelectionnee.Rows(0)("RESTE_A_PAYER")) = 0 Then

                    'MessageBox.Show(" VERSE: " & montantVerse & " - CODE: " & CODE_FACTURE & " - ENCOURS: " & MONTANT_FACTURE_ENCOURS)

                    If montantVerse >= MONTANT_FACTURE_ENCOURS Then

                        MONTANT_AVANCE = MONTANT_FACTURE_ENCOURS
                        RESTE_A_PAYER = MONTANT_FACTURE_ENCOURS - MONTANT_AVANCE

                        montantVerse -= MONTANT_AVANCE

                    Else

                        MONTANT_AVANCE = montantVerse
                        RESTE_A_PAYER = MONTANT_FACTURE_ENCOURS - MONTANT_AVANCE

                        montantVerse -= MONTANT_AVANCE

                    End If

                    Dim updateQuery As String = "UPDATE `facture` SET `CODE_MODE_PAIEMENT`=@CODE_MODE_PAIEMENT, `DATE_PAIEMENT`=@DATE_PAIEMENT, `ETAT_FACTURE`=@ETAT_FACTURE, `MONTANT_AVANCE`=MONTANT_AVANCE + @MONTANT_AVANCE , `RESTE_A_PAYER`= MONTANT_TTC - MONTANT_AVANCE, AVANCE = MONTANT_AVANCE WHERE CODE_FACTURE=@CODE_FACTURE"

                    Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                    command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

                    command.Parameters.Add("@CODE_MODE_PAIEMENT", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT

                    command.Parameters.Add("@RESTE_A_PAYER", MySqlDbType.Double).Value = RESTE_A_PAYER
                    command.Parameters.Add("@DATE_PAIEMENT", MySqlDbType.Date).Value = DATE_PAIEMENT
                    command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
                    command.Parameters.Add("@MONTANT_AVANCE", MySqlDbType.Double).Value = MONTANT_AVANCE

                    command.ExecuteNonQuery()

                End If

            End If

            'MISE A JOURS DU LETTRAGE PAR APPORT AU CODE DE REGLEMENT

            'SI ON UTILISE UN AVOIR POUR REGLER :
            '1- ON CREE UN AVOIR A VALEUR NEGATIVE PERMETTANT DE DEDUIRE DE L'AVOIR ORIGINAL 
            '2- LE LETTRAGE DU NOUVELLE AVOIR ET LES FACTURE SERA CELUI DE L'AVOIR ORIGINAL (AVOIR DONT ON DEDUIRA LES MONTANT DE FACTURES)

            'SINON 
            '1- ON CREE UN REGLEMENT DONT SON CODE SERA UTILISE COMME LETTRAGE

            Dim LETTRAGE As String = ""

            If GunaComboBoxModeReglement.SelectedItem = "Avoir" Or GunaComboBoxModeReglement.SelectedItem = "Dépôt de garantie" Then
                LETTRAGE = GunaTextBoxCodeDeLAvoir.Text
            Else
                LETTRAGE = CODE_REGLEMENT ' VALEUR DU LETTRAGE
            End If

            'FACTURE
            Dim TABLE As String = "facture"
            Dim CONDITION_FIELD_NAME As String = "CODE_FACTURE" ' 
            Dim CONDITION_FIELD_VALUE As String = CODE_FACTURE
            miseAJourDuLettrage(TABLE, LETTRAGE, CONDITION_FIELD_NAME, CONDITION_FIELD_VALUE)

            'REGLEMENT
            TABLE = "reglement"
            CONDITION_FIELD_NAME = "NUM_REGLEMENT" '
            CONDITION_FIELD_VALUE = CODE_REGLEMENT
            miseAJourDuLettrage(TABLE, LETTRAGE, CONDITION_FIELD_NAME, CONDITION_FIELD_VALUE)

        Next

        For i = 0 To ENSEMBLE_DES_FACTURES.Length - 1
            ENSEMBLE_DES_FACTURES(i).CODE_FACTURE = ""
        Next

    End Sub

    Public Sub miseAJourDuLettrage(ByVal TABLE As String, ByVal LETTRAGE As String, ByVal CONDITION_FIELD_NAME As String, ByVal CONDITION_FIELD_VALUE As String)

        Dim insertQuery As String = "UPDATE " & TABLE & " SET `LETTRAGE`=@LETTRAGE WHERE " & CONDITION_FIELD_NAME & " =@CONDITION_FIELD_VALUE"

        Dim command1 As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command1.Parameters.Add("@CONDITION_FIELD_VALUE", MySqlDbType.VarChar).Value = CONDITION_FIELD_VALUE
        command1.Parameters.Add("@LETTRAGE", MySqlDbType.VarChar).Value = LETTRAGE

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        command1.ExecuteNonQuery()

    End Sub

    Private Sub GunaDataGridViewListeFacture_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewListeFacture.CellClick

        Dim MONTANT_TOTAL_DES_FACTURES As Double = 0
        Dim CODE_FACTURE As String = ""

        If GunaDataGridViewListeFacture.Rows.Count > 0 Then

            Dim i As Integer = 0

            Dim TOTAL_LIGNE_FACTURE = 0
            Dim TOTAL_LIGNE_RETENUE = 0

            For Each row As DataGridViewRow In GunaDataGridViewListeFacture.SelectedRows

                CODE_FACTURE = Trim(row.Cells(0).Value.ToString)

                If Trim(row.Cells(7).Value.ToString) = "" Then
                    TOTAL_LIGNE_FACTURE = 0
                Else
                    TOTAL_LIGNE_FACTURE = Double.Parse(Trim(row.Cells(7).Value))
                End If

                If CODE_FACTURE.Contains("RTVA") Then
                    'ON DOIT DETERMINER LE MONTANT DE LA RETENUE A RETRANCHER
                    If Trim(row.Cells(6).Value.ToString) = "" Then
                        TOTAL_LIGNE_RETENUE = 0
                    Else
                        TOTAL_LIGNE_RETENUE = Double.Parse(Trim(row.Cells(6).Value))
                    End If
                    'ON RETRANCHE LE NONTANT DE LA RETENUE
                    MONTANT_TOTAL_DES_FACTURES += Double.Parse(TOTAL_LIGNE_RETENUE)
                Else
                    MONTANT_TOTAL_DES_FACTURES += Double.Parse(TOTAL_LIGNE_FACTURE)
                End If

                ENSEMBLE_DES_FACTURES(i).CODE_FACTURE = CODE_FACTURE

                i += 1

            Next

            GunaTextBoxAPayer.Text = Format(Math.Abs(MONTANT_TOTAL_DES_FACTURES), "#,##0")
            GunaTextBoxSolde.Text = Format(Math.Abs(MONTANT_TOTAL_DES_FACTURES), "#,##0")

        End If

        GunaComboBoxNatureOperation.SelectedItem = "REGLEMENT"

    End Sub

    Private Sub GunaComboBoxTypeDeFiltre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeFiltre.SelectedIndexChanged

        If GunaComboBoxTypeDeFiltre.SelectedIndex = 1 Then
            Label21.Visible = True
            LabelRang.Visible = True
        Else
            Label21.Visible = False
            LabelRang.Visible = False
            LabelRang.Text = "-"
            LabelSur.Text = "-"
        End If

        If Trim(GunaTextBoxInconnu.Text).Equals("") Then

            effacementDesDetails()

            GunaTextBoxReference.Clear()

            Functions.SiplifiedClearTextBox(Me)

            GunaDataGridViewListeFacture.Rows.Clear()

            Label5.Text = GunaComboBoxTypeDeFiltre.SelectedItem.ToString.ToUpper

        End If

        GunaDataGridViewClient.DataSource = Nothing
        GunaDataGridViewClient.Visible = False

    End Sub

    Private Sub listeDesFacturesSuivantUnePeriode()

        GunaDataGridViewListeFacture.Rows.Clear()

        If Trim(GunaTextBoxCompteDebiteur.Text).Equals("") And Trim(GunaTextBoxCodeEntreprise.Text).Equals("") Then
            ListeDesFacturesEtReglementsSuivantUnComptePaymasterCodeClient(GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)
        Else

            If GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Account" Then
                Dim NUMERO_COMPTE_PAYMASTER As String = GunaTextBoxCompteDebiteur.Text
                ListeDesFacturesEtReglementsSuivantUnComptePaymaster(NUMERO_COMPTE_PAYMASTER, GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)
            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then
                'We take all the invoice of the current user for reglement and insert the values of the field of RegelementForm
                Dim CODE_CLIENT As String = GunaTextBoxCodeEntreprise.Text
                ListeDesFacturesEtReglements(CODE_CLIENT, GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)
            End If

        End If

    End Sub
    'AFFICHAGE FACTURES SUIVANT UNE PERIODE
    Private Sub GunaButtonAfficherLesFacturesEtReglement_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLesFacturesEtReglement.Click
        listeDesFacturesSuivantUnePeriode()
    End Sub

    Private Sub GunaButtonOuvertureFermeture_Click(sender As Object, e As EventArgs) Handles GunaButtonOuvertureFermeture.Click

        If GunaButtonOuvertureFermeture.Text = "Ouvrir Caisse" Or GunaButtonOuvertureFermeture.Text = "Open Cash Register" Then

            GlobalVariable.fenetreDouvervetureDeCaisse = "comptable"

            passwordVerifivationForm.Show()
            passwordVerifivationForm.TopMost = True

        ElseIf GunaButtonOuvertureFermeture.Text = "Fermer Caisse" Or GunaButtonOuvertureFermeture.Text = "Close Cash Register" Then

            Dim ETAT_CAISSE As Integer = 0
            Dim caissier As New Caisse()
            Dim CODE_CAISSE As String = ""

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim infoCaisse As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR", CODE_AGENCE, "CODE_AGENCE")

            If infoCaisse.Rows.Count > 0 Then

                CODE_CAISSE = infoCaisse.Rows(0)("CODE_CAISSE")

                caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                indicateurDEtatDeCaisse()

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show(CODE_CAISSE & " Caisse fermée avec succès", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(CODE_CAISSE & " Cash Box successfully closed", "Cash Box Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

            Timer1.Stop()

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        SituationDeCaisse()

        SitutationDesDettes()

        'AFFICHAGE DU SOLDE

        If Not Trim(GunaTextBoxSoldeCompte.Text) = "" Then

            If GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Account" Then
                Dim NUMERO_COMPTE As String = GunaTextBoxCompteDebiteur.Text
                soldeSuivantUnComptePaymaster(NUMERO_COMPTE)
            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then
                Dim CODE_CLIENT As String = Trim(GunaTextBoxCodeEntreprise.Text)
                SoldeEntrepriseEtIndividuel(CODE_CLIENT)
            End If

        End If

    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click

        If GunaDataGridViewListeFacture.Rows.Count > 0 Then

            Dim NATURE_OPERATION As String = GunaDataGridViewListeFacture.CurrentRow.Cells("NATURE").Value.ToString

            Dim CODE_CLIENT_COMPTE As String = ""

            If GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then
                CODE_CLIENT_COMPTE = GunaTextBoxCodeEntreprise.Text
            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Account" Then
                CODE_CLIENT_COMPTE = GunaTextBoxCompteDebiteur.Text
            End If

            If Trim(NATURE_OPERATION) = "FACTURE" Then

                GlobalVariable.DocumentToGenerate = "facture"

                If GunaDataGridViewListeFacture.Rows.Count > 0 Then
                    Functions.DocumentToPrint(GunaDataGridViewListeFacture.CurrentRow.Cells("REFERENCE").Value.ToString, "lign_facture", "CODE_FACTURE", CODE_CLIENT_COMPTE, "")
                End If

            ElseIf Trim(NATURE_OPERATION) = "REGLEMENT" Then

                GlobalVariable.DocumentToGenerate = "reglement"

                Functions.DocumentToPrint(GunaDataGridViewListeFacture.CurrentRow.Cells("REFERENCE").Value.ToString, "reglement", "NUM_REGLEMENT", CODE_CLIENT_COMPTE, "")

            End If

        Else
            MessageBox.Show("OUps", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    'TRANSFERT DE LA CAISSE DU COMPTABLE

    Private Sub GunaButtonTransfert_Click(sender As Object, e As EventArgs) Handles GunaButtonTransfert.Click

        GlobalVariable.billetageAPartirDe = "comptable"

        Dim DateDebutStat As Date = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail)
        Dim DateFinStat As Date = Functions.lastDayOfMonth(GlobalVariable.DateDeTravail)

        Dim encaissementEspeces As Double = SituationDeCaisseAmount(DateDebutStat, DateFinStat)

        'ON NE PEUT PAS TRANSFERT DES ENCAISSMENT VIDES

        If encaissementEspeces > 0 Then
            BilletageForm.Show()
            BilletageForm.TopMost = True
        Else
            'FacturationForm.Close()

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune recette à transférer ", "Transfert de Caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No revenue to be transferred ", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

            Dim CODE_CAISSE As String = ""

            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

            End If

            Dim ETAT_CAISSE As Integer = 0
            Dim caissier As New Caisse()

            caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Caisse Transférer avec succès !!", "Transfert de Caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Caish Box Successful transfered !!", "Transfer of Cash Box", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        End If
    End Sub

    Private Sub GunaComboBoxDepotDeGarantie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxDepotDeGarantie.SelectedIndexChanged


        If GunaComboBoxDepotDeGarantie.SelectedIndex >= 0 Then

            Dim deepotDeGarantie As DataTable = Functions.getElementByCode(GunaComboBoxDepotDeGarantie.SelectedValue.ToString, "reglement", "NUM_REGLEMENT")

            If deepotDeGarantie.Rows.Count > 0 Then

                'ON UTILISE QUE LES AVOIR A VALEUR NEGATIVE POUR REGLER
                If deepotDeGarantie.Rows(0)("MONTANT_VERSE") > 0 Then

                    'POUR CHAQUE AVOIR ON DOIT DETERMINER SI IL A DEJA ETE UTILISE POUR REGLER DES FACTURES
                    ' SI OUI
                    '1- ON DOIT RECUPERER TOUTS LES AVOIR A VALEUR NEGATIVE ASSOCIER A LA VOIR ORIGINAL 
                    '- ON RECHERCHE LES AVOIRS AYANT POUR CODE DE LETTRAGE LE CODE DE L'AVOIR ORIGINAL
                    'A FIN DE DETERMINER LE SOLDE DE L'AVOIR ORIGINAL A UTILISER DONC A AFFICHER
                    Dim CODE_DEPOT_ORIGINAL As String = deepotDeGarantie.Rows(0)("NUM_REGLEMENT")

                    Dim depotNegatifDuDepotOriginal As DataTable = Functions.getElementByCode(CODE_DEPOT_ORIGINAL, "reglement", "LETTRAGE")

                    If depotNegatifDuDepotOriginal.Rows.Count > 0 Then

                        Dim MONTANT_TOTAL_DEJA_UTILISE As Double = 0

                        For i = 0 To depotNegatifDuDepotOriginal.Rows.Count - 1
                            MONTANT_TOTAL_DEJA_UTILISE += depotNegatifDuDepotOriginal.Rows(i)("MONTANT_VERSE")
                        Next

                        GunaTextBoxMontantDepotDeGarantie.Text = Format(deepotDeGarantie.Rows(0)("MONTANT_VERSE") + MONTANT_TOTAL_DEJA_UTILISE, "#,##0")
                        GunaTextBoxMontantVerse.Text = Format(deepotDeGarantie.Rows(0)("MONTANT_VERSE") + MONTANT_TOTAL_DEJA_UTILISE, "#,##0")

                    Else

                        'SI NON 
                        '1- ON AFFICHE SON MONTANT ORIGINAL

                        GunaTextBoxMontantDepotDeGarantie.Text = Format(deepotDeGarantie.Rows(0)("MONTANT_VERSE"), "#,##0")
                        GunaTextBoxMontantVerse.Text = Format(deepotDeGarantie.Rows(0)("MONTANT_VERSE"), "#,##0")

                    End If

                    GunaTextBoxCodeDeLAvoir.Text = deepotDeGarantie.Rows(0)("NUM_REGLEMENT") 'CODE DU DEPOT DE GARANTIE

                End If

            End If

        End If


    End Sub

    Private Sub ImprimerFactureSynthèseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerFactureSynthèseToolStripMenuItem.Click

        If GunaDataGridViewListeFacture.Rows.Count > 0 Then

            Dim NATURE_OPERATION As String = GunaDataGridViewListeFacture.CurrentRow.Cells("NATURE").Value.ToString

            Dim CODE_CLIENT_COMPTE As String = ""

            If GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then
                CODE_CLIENT_COMPTE = GunaTextBoxCodeEntreprise.Text
            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Account" Then
                CODE_CLIENT_COMPTE = GunaTextBoxCompteDebiteur.Text
            End If

            If Trim(NATURE_OPERATION) = "FACTURE" Then

                GlobalVariable.DocumentToGenerate = "facture"

                If GunaDataGridViewListeFacture.Rows.Count > 0 Then
                    Functions.DocumentToPrintSynthese(GunaDataGridViewListeFacture.CurrentRow.Cells("REFERENCE").Value.ToString, "lign_facture", "CODE_FACTURE", CODE_CLIENT_COMPTE, "")
                End If

            ElseIf Trim(NATURE_OPERATION) = "REGLEMENT" Then

                GlobalVariable.DocumentToGenerate = "reglement"

                Functions.DocumentToPrintSynthese(GunaDataGridViewListeFacture.CurrentRow.Cells("REFERENCE").Value.ToString, "reglement", "NUM_REGLEMENT", CODE_CLIENT_COMPTE, "")

            End If

        Else
            MessageBox.Show("OUps", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class