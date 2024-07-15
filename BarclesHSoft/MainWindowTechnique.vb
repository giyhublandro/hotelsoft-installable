Imports MySql.Data.MySqlClient

Public Class MainWindowTechnique

    'Dim connect As New DataBaseManipulation()

    '-------------------------------GESTION DES BON D'interventions -------------------------------

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        DemandeInterventionForm.Close()
        Functions.exitApplicationThread()
    End Sub

    Private Sub MainWindowTechnique_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail
        GunaDateTimePickerIntervention.Value = GlobalVariable.DateDeTravail

        Dim menuAccess As New AccessRight()

        menuAccess.accesAuxModules(GlobalVariable.DroitAccesDeUtilisateurConnect, ReceptionToolStripMenuItem, RESERVATIONToolStripMenuItem, SERVICEDETAGEToolStripMenuItem, BarRestaurationToolStripMenuItem, ComptabilitéToolStripMenuItem, ECONOMATToolStripMenuItem, TECHNIQUEToolStripMenuItem, ToolStripMenuItem1)

        menuAccess.administrationDuModule(GlobalVariable.DroitAccesDeUtilisateurConnect, ToolStripMenuItemSession, ToolStripMenuItemConfig, ToolStripMenuItemServTech, ToolStripMenuItemSecurite, ClôturerToolStripMenuItem, ToolStripSeparatorCloture, FermerCaisseToolStripMenuItem, OuvrirCaisseToolStripMenuItem, ToolStripSeparator2)

        GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

        'TITRE DE LA FENETRE
        If GlobalVariable.softwareVersion = "barcleshsoftdbdemo" Then
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") + " (DEMO) "
        Else
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        End If

        TabControl2.SelectedIndex = 2

        PanelBonIntervention.Visible = True

        GunaTextBoxSite.Text = GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE")

        GunaDataGridViewLigneEquipement.Columns.Add("CODE_EQUIPEMENT", "CODE EQUIPEMENT")
        GunaDataGridViewLigneEquipement.Columns.Add("LIBELLE_EQUIPEMENT", "LIBELLE EQUIPEMENT")
        GunaDataGridViewLigneEquipement.Columns.Add("QUANTITE", "QUANTITE")
        GunaDataGridViewLigneEquipement.Columns.Add("PUB", "PU BASE")
        GunaDataGridViewLigneEquipement.Columns.Add("PUR", "PU REEL")
        GunaDataGridViewLigneEquipement.Columns.Add("PT", "PT")
        GunaDataGridViewLigneEquipement.Columns.Add("UTILISATEUR", "UTILISATEUR")

        'GunaDateTimePickerIntervention.Value = GlobalVariable.DateDeTravail

        'Charging  information into combobox
        AutoLoadInformation()

        'Definition des étages et sous sol
        ZoneEtSousZone()

        GunaComboBoxTemps.SelectedIndex = 0

        GunaComboBoxTypeBonAAficher.SelectedIndex = 3
        GunaComboBoxLieuPanne.SelectedIndex = 0
        GunaComboBoxStatut.SelectedIndex = 0
        'GunaComboBoxInterventionStatuts.SelectedIndex = 0

        'BonInterventionForm.TopMost = True
        'BonInterventionForm.Location = New System.Drawing.Point(10, 104)
        'BonInterventionForm.Show()

    End Sub



    Public Sub AutoLoadInformation()

        Dim TYPE As Integer = 0
        Dim Famille As DataTable = Functions.GetAllElementsOnTwoConditions("famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE", TYPE, "TYPE")

        If (Famille.Rows.Count > 0) Then

            GunaComboFamille.DataSource = Famille
            GunaComboFamille.ValueMember = "LIBELLE"
            GunaComboFamille.DisplayMember = "LIBELLE"

            Dim SousFamille As DataTable = Functions.GetAllElementsOnTwoConditions("sous famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE", GunaComboFamille.SelectedValue.ToString, "PARENT")

            If (SousFamille.Rows.Count > 0) Then

                GunaComboBoxSousFamille.DataSource = SousFamille
                GunaComboBoxSousFamille.ValueMember = "LIBELLE"
                GunaComboBoxSousFamille.DisplayMember = "LIBELLE"

            End If

        End If

        Dim chambre As DataTable = Functions.allTableFieldsOrganised("chambre", "CODE_CHAMBRE")

        If (chambre.Rows.Count > 0) Then

            GunaComboBoxSousZone.DataSource = chambre
            GunaComboBoxSousZone.ValueMember = "CODE_CHAMBRE"
            GunaComboBoxSousZone.DisplayMember = "CODE_CHAMBRE"

        End If

        'Liste des intervenants

        Dim panne As New Panne()

        Dim Intervenant As DataTable = panne.Intervenants()

        If (Intervenant.Rows.Count > 0) Then

            GunaComboBoxIntervenant.DataSource = Intervenant
            GunaComboBoxIntervenant.ValueMember = "CODE_PERSONNEL"
            GunaComboBoxIntervenant.DisplayMember = "NOM_PERSONNEL"

        End If

        'connect.closeConnection()

    End Sub

    Public Sub ZoneEtSousZone()

        'Sous Zone
        Dim nombreEtage As Integer = GlobalVariable.AgenceActuelle.Rows(0)("ETAGE")

        If nombreEtage >= 0 Then

            For i = 1 To nombreEtage
                GunaComboBoxZone.Items.Add(i)
            Next

            GunaComboBoxZone.SelectedIndex = 0
        End If


    End Sub

    Public Sub InterventionList()

        Dim query1 As String = "SELECT `CODE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `intervention` ORDER BY DATE_INTERVENTION DESC"

        Dim index As Integer = 5
        Dim query As String = ""

        'If GunaComboBoxInterventionStatuts.SelectedIndex >= 0 Then

        'If GunaComboBoxInterventionStatuts.SelectedIndex = 3 Then
        ' query1 = "SELECT `CODE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `ZONE`, `SOUS_ZONE` As 'SOUS ZONE', `LIEU_PANNE` AS 'LIEU PANNE', `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `intervention` ORDER BY DATE_INTERVENTION DESC"
        'Else
        'query1 = "SELECT `CODE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `ZONE`,`SOUS_ZONE` As 'SOUS ZONE',`LIEU_PANNE` AS 'LIEU PANNE',  `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `intervention` WHERE STATUT =@STATUT ORDER BY DATE_INTERVENTION DESC"
        'End If

        'End If

        'Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        'If GunaComboBoxInterventionStatuts.SelectedIndex >= 0 And GunaComboBoxInterventionStatuts.SelectedIndex <= 2 Then
        'command1.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = GunaComboBoxInterventionStatuts.SelectedItem
        'End If

        'Dim adapter1 As New MySqlDataAdapter(command1)
        'Dim table1 As New DataTable()
        'adapter1.Fill(table1)

        'If (table1.Rows.Count > 0) Then
        'GunaDataGridViewListeIntervention.DataSource = table1
        ' Else
        'GunaDataGridViewListeIntervention.DataSource = Nothing
        'End If

    End Sub
    'LIste des Articles
    Public Sub DemandeInterventionList()

        'REFRESHING information from database for instant visualisation 
        Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` WHERE STATUT =@STATUT ORDER BY DATE_INTERVENTION ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = "Validée"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewDemandeIntervention.DataSource = table
        Else
            GunaDataGridViewDemandeIntervention.DataSource.Columns.Clear()
        End If

    End Sub

    'Enregistrer
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_INTERVENTION As String = GunaTextBoxCodeIntervention.Text
        Dim DATE_INTERVENTION As Date = GunaDateTimePickerIntervention.Value.ToShortDateString()
        Dim HEURE_INTERVENTION As String = GunaTextBoxHeureIntervention.Text
        Dim SITE As String = GunaTextBoxSite.Text

        Dim SOUS_ZONE As String = ""

        If GunaComboBoxSousZone.SelectedIndex >= 0 Then
            SOUS_ZONE = GunaComboBoxSousZone.SelectedValue.ToString
        End If

        Dim ZONE As Integer = GunaComboBoxZone.SelectedItem
        Dim STATUT As String = GunaComboBoxStatut.SelectedItem
        Dim FAMILLE_PANNE As String = GunaComboFamille.SelectedValue.ToString
        Dim TYPE_PANNE As String = GunaComboBoxSousFamille.SelectedValue.ToString
        Dim DIAGNOSTIQUE As String = GunaTextBoxDiag.Text
        Dim COMMENTAIRE As String = GunaTextBoxCommentaire.Text
        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        Dim CODE_INTERVENANT As String = GunaComboBoxIntervenant.SelectedValue.ToString
        Dim CODE_DEMANDE As String = GunaTextBoxCodeDemandeIntervention.Text
        Dim TEMPS As Integer = GunaTextBoxTempsMinutes.Text
        Dim LIEU_PANNE As String = GunaComboBoxLieuPanne.SelectedItem
        Dim ORIGINE_DEMANDE As String = GunaTextBoxOrigineDemande.Text
        Dim ID_LIGNE_INTERVENTION As Integer = -1

        Dim intervention As New Panne()

        Dim message As String = ""

        If Trim(GunaButtonEnregistrer.Text).Equals("Enregistrer") Then

            Functions.DeleteElementByCode(CODE_DEMANDE, "intervention", "CODE_DEMANDE")
            Functions.DeleteElementByCode(CODE_DEMANDE, "ligne_intervention", "CODE_DEMANDE")

            message = "Intervention mise à jours avec succès"

        Else
            message = "Intervention crée avec succès "
        End If

        intervention.InsertIntervention(CODE_INTERVENTION, DATE_INTERVENTION, HEURE_INTERVENTION, SITE, SOUS_ZONE, ZONE, STATUT, FAMILLE_PANNE, TYPE_PANNE, DIAGNOSTIQUE, COMMENTAIRE, CODE_AGENCE, CODE_UTILISATEUR, CODE_INTERVENANT, CODE_DEMANDE, TEMPS, LIEU_PANNE, ORIGINE_DEMANDE)

        If GunaDataGridViewLigneEquipement.Rows.Count > 0 Then

            For i = 0 To GunaDataGridViewLigneEquipement.Rows.Count - 1

                Dim CODE_EQUIPEMENT As String = GunaDataGridViewLigneEquipement.Rows(i).Cells("CODE_EQUIPEMENT").Value.ToString
                Dim PRIX_BASE As Double = GunaDataGridViewLigneEquipement.Rows(i).Cells("PUB").Value
                Dim PRIX_REEL As Double = GunaDataGridViewLigneEquipement.Rows(i).Cells("PUR").Value
                Dim QTE As Double = GunaDataGridViewLigneEquipement.Rows(i).Cells("QUANTITE").Value
                Dim PT As Double = GunaDataGridViewLigneEquipement.Rows(i).Cells("PT").Value
                Dim EQUIPEMENT_UTILISE As String = GunaDataGridViewLigneEquipement.Rows(i).Cells("LIBELLE_EQUIPEMENT").Value.ToString
                Dim ETAT As Integer = 0
                Dim UTILISATEUR As String = GunaDataGridViewLigneEquipement.Rows(i).Cells("UTILISATEUR").Value.ToString

                'INSERTION D'EQUIPEMENT UTILISE
                intervention.InsertEquipementPourIntervention(CODE_EQUIPEMENT, PRIX_BASE, PRIX_REEL, QTE, PT, EQUIPEMENT_UTILISE, ETAT, UTILISATEUR, CODE_DEMANDE, CODE_INTERVENTION)

            Next

            GunaDataGridViewLigneEquipement.Rows.Clear()

        End If

        'MISE A JOURS DU STATUT DE LA DEMANDE
        Dim updateQuery As String = "UPDATE demande_intervention SET STATUT = @STATUT WHERE CODE_DEMANDE_INTERVENTION = @CODE_DEMANDE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_DEMANDE", MySqlDbType.VarChar).Value = CODE_DEMANDE
        command.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = STATUT

        command.ExecuteNonQuery()

        MessageBox.Show(message, "Intervetion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        TabControl2.SelectedIndex = 1
        'GunaComboFamille.SelectedIndex = -1
        GunaTextBoxOrigineDemande.Clear()
        GunaTextBoxDiag.Clear()
        GunaTextBoxCommentaire.Clear()
        GunaTextBoxCommentDemande.Clear()
        'GunaComboBoxSousFamille.SelectedIndex = -1
        GunaComboBoxIntervenant.SelectedIndex = -1
        GunaDataGridViewP1.Rows.Clear()

    End Sub

    'Validation de Intervention
    Private Sub GunaButtonValider_Click(sender As Object, e As EventArgs) Handles GunaButtonValider.Click

    End Sub

    'Reorganise when we enter the button for search
    Private Sub GunaTextBoxcCode_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxcCodeLibelle.Enter

        Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` WHERE STATUT =@STATUT ORDER BY DATE_INTERVENTION ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = "Validée"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewDemandeIntervention.DataSource = table
        Else
            GunaDataGridViewDemandeIntervention.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    'Live search based on the code
    Private Sub GunaTextBoxcCode_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxcCodeLibelle.TextChanged

        If Not Trim(GunaTextBoxcCodeLibelle.Text).Equals("") Then

            'Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` WHERE CODE_DEMANDE_INTERVENTION LIKE '%" & GunaTextBoxcCodeLibelle.Text & "%' AND STATUT =@STATUT or FAMILLE_PANNE LIKE '%" & GunaTextBoxcCodeLibelle.Text & "%' AND STATUT =@STATUT ORDER BY CODE_DEMANDE_INTERVENTION ASC"
            Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` WHERE CODE_DEMANDE_INTERVENTION LIKE '%" & GunaTextBoxcCodeLibelle.Text & "%' OR FAMILLE_PANNE LIKE '%" & GunaTextBoxcCodeLibelle.Text & "%' ORDER BY CODE_DEMANDE_INTERVENTION ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = "Validée"

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                GunaDataGridViewDemandeIntervention.DataSource = table
            Else
                GunaDataGridViewDemandeIntervention.Columns.Clear()
            End If

        Else
            GunaDataGridViewDemandeIntervention.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub


    'mise à jours dea
    Private Sub GunaDataGridViewArticle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewDemandeIntervention.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Enregistrer"

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewDemandeIntervention.Rows(e.RowIndex)

            Dim demandeIntervention As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE INTERVENTION").Value.ToString), "demande_intervention", "CODE_DEMANDE_INTERVENTION")

            If demandeIntervention.Rows.Count > 0 Then

                Dim CODE_DEMANDE_INTERVENTION As String = demandeIntervention.Rows(0)("CODE_DEMANDE_INTERVENTION")
                GunaTextBoxCodeDemandeIntervention.Text = demandeIntervention.Rows(0)("CODE_DEMANDE_INTERVENTION")
                GunaDateTimePickerIntervention.Value = demandeIntervention.Rows(0)("DATE_INTERVENTION")
                GunaDateTimePickerHeure.Value = demandeIntervention.Rows(0)("DATE_INTERVENTION")
                GunaTextBoxSite.Text = demandeIntervention.Rows(0)("SITE")
                GunaComboBoxSousZone.SelectedValue = demandeIntervention.Rows(0)("SOUS_ZONE")
                GunaComboBoxZone.SelectedItem = demandeIntervention.Rows(0)("ZONE")
                GunaTextBoxStatut.Text = demandeIntervention.Rows(0)("STATUT")
                GunaComboBoxStatut.SelectedItem = demandeIntervention.Rows(0)("STATUT")
                GunaComboFamille.SelectedValue = demandeIntervention.Rows(0)("FAMILLE_PANNE")
                GunaComboBoxSousFamille.SelectedValue = demandeIntervention.Rows(0)("TYPE_PANNE") 'SOUS FAMILLE
                GunaTextBoxDiag.Text = ""
                GunaTextBoxCommentDemande.Text = demandeIntervention.Rows(0)("COMMENTAIRE")
                GunaTextBoxOrigineDemande.Text = demandeIntervention.Rows(0)("ORIGINE_DEMANDE")
                GunaComboBoxLieuPanne.SelectedItem = demandeIntervention.Rows(0)("LIEU_PANNE")

                'GunaTextBoxCommentaire.Clear()

                TabControl2.SelectedIndex = 0

                'DETERMINONS SI LA DEMANDE EST ASSOCIE A UN BON D'INTERVENTION

                Dim infoSupBonIntervention As DataTable = Functions.getElementByCode(CODE_DEMANDE_INTERVENTION, "intervention", "CODE_DEMANDE")

                If infoSupBonIntervention.Rows.Count > 0 Then

                    GunaTextBoxDiag.Text = infoSupBonIntervention.Rows(0)("DIAGNOSTIQUE")
                    GunaTextBoxTempsMinutes.Text = infoSupBonIntervention.Rows(0)("TEMPS")
                    GunaComboBoxIntervenant.SelectedValue = infoSupBonIntervention.Rows(0)("CODE_INTERVENANT")
                    GunaComboFamille.SelectedValue = infoSupBonIntervention.Rows(0)("FAMILLE_PANNE")
                    GunaComboBoxSousFamille.SelectedValue = infoSupBonIntervention.Rows(0)("TYPE_PANNE")
                    GunaTextBoxOrigineDemande.Text = infoSupBonIntervention.Rows(0)("ORIGINE_DEMANDE")
                    GunaTextBoxCommentaire.Text = infoSupBonIntervention.Rows(0)("COMMENTAIRE")
                    GunaTextBoxHeureIntervention.Text = infoSupBonIntervention.Rows(0)("HEURE_INTERVENTION")
                    GunaDateTimePickerIntervention.Value = infoSupBonIntervention.Rows(0)("DATE_INTERVENTION")

                    Dim CODE_INTERVENTION As String = infoSupBonIntervention.Rows(0)("CODE_INTERVENTION")

                    Dim infoSupEquipementIntervention As DataTable = Functions.getElementByCode(CODE_INTERVENTION, "ligne_intervention", "CODE_INTERVENTION")

                    If infoSupEquipementIntervention.Rows.Count > 0 Then

                        Dim CODE_EQUIPEMENT As String = infoSupEquipementIntervention.Rows(0)("CODE_EQUIPEMENT")
                        Dim PRIX_BASE As Double = infoSupEquipementIntervention.Rows(0)("PRIX_BASE")
                        Dim PRIX_REEL As Double = infoSupEquipementIntervention.Rows(0)("PRIX_REEL")
                        Dim QTE As Double = infoSupEquipementIntervention.Rows(0)("QTE")
                        Dim PT As Double = infoSupEquipementIntervention.Rows(0)("PT")
                        Dim EQUIPEMENT_UTILISE As String = infoSupEquipementIntervention.Rows(0)("EQUIPEMENT_UTILISE")
                        Dim ETAT = infoSupEquipementIntervention.Rows(0)("ETAT")
                        Dim UTILISATEUR As String = infoSupEquipementIntervention.Rows(0)("UTILISATEUR")
                        Dim CODE_DEMANDE As String = infoSupEquipementIntervention.Rows(0)("CODE_DEMANDE")

                        GunaDataGridViewLigneEquipement.Rows.Add(CODE_EQUIPEMENT, EQUIPEMENT_UTILISE, QTE, PRIX_BASE, PRIX_REEL, PT, UTILISATEUR)

                        montantTotalEquipementUtilise()

                    End If

                End If

                Dim dt As DataTable = Functions.getElementByCode(CODE_DEMANDE_INTERVENTION, "demande_intervention_probleme", "CODE_DEMANDE")

                If dt.Rows.Count > 0 Then

                    GunaDataGridViewP1.Rows.Clear()

                    'GunaTextBoxNombreDeProblem.Text = dt.Rows.Count
                    GunaTextBoxSite.Text = dt.Rows.Count

                    For i = 0 To dt.Rows.Count - 1
                        GunaDataGridViewP1.Rows.Add(dt.Rows(i)("CODE_PROBLEME"), dt.Rows(i)("PROBLEME"), dt.Rows(i)("LOCALISATION_PANNE"), dt.Rows(i)("HABITATION"))
                    Next

                Else
                    GunaTextBoxSite.Text = -1
                End If

            End If

        End If

    End Sub

    'SUPRESSION DEMANDES INTERVENTIONS
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If GunaDataGridViewDemandeIntervention.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supperimer cette demande " & GunaDataGridViewDemandeIntervention.CurrentRow.Cells("CODE INTERVENTION").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewDemandeIntervention, GunaDataGridViewDemandeIntervention.CurrentRow.Cells("CODE INTERVENTION").Value.ToString, "demande_intervention", "CODE_DEMANDE_INTERVENTION")

                GunaDataGridViewDemandeIntervention.Columns.Clear()

                InterventionList()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    'A chaque changement d'une famille de panee on affiche les sous famille de apnnes correspondantes
    Private Sub GunaComboFamille_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboFamille.SelectedIndexChanged

        Dim SousFamille As DataTable = Functions.GetAllElementsOnTwoConditions("sous famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE", GunaComboFamille.SelectedValue.ToString, "PARENT")

        If (SousFamille.Rows.Count > 0) Then

            GunaComboBoxSousFamille.DataSource = SousFamille
            GunaComboBoxSousFamille.ValueMember = "LIBELLE"
            GunaComboBoxSousFamille.DisplayMember = "LIBELLE"

        End If

    End Sub

    'Choix du l'equipement dans la liste des articles
    Private Sub GunaTextBoxArticle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxArticle.TextChanged

        GunaDataGridViewArticle.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxArticle.Text).Equals("") Then

        End If

        'Determining from which table to search for the articles

        getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE =@TYPE ORDER BY DESIGNATION_FR ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "materiels"
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewArticle.DataSource = table
        Else
            GunaDataGridViewArticle.Columns.Clear()
            GunaDataGridViewArticle.Visible = False
        End If

        If GunaTextBoxArticle.Text = "" Then
            GunaDataGridViewArticle.Visible = False
        End If

        'connect.closeConnection()

    End Sub

    'Filling the other fields concerning the article when the value of th room changes
    Private Sub GunaDataGridViewArticle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticle.CellClick

        GunaDataGridViewArticle.Visible = False

        'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
        'il disparait de nouveau après ajout a la facture

        GunaButtonAjouterLigne.Visible = True

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewArticle.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE DESIGNATION_FR=@DESIGNATION_FR ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@DESIGNATION_FR", MySqlDbType.VarChar).Value = row.Cells("DESIGNATION_FR").Value.ToString

            adapter.SelectCommand = command
            adapter.Fill(Article)

            If Article.Rows.Count > 0 Then

                GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")

                GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxPU.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0") 'PU DE AFFICHE
                GunaTextBoxPUR.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0") 'PU DE REEL

                GunaDataGridViewArticle.Visible = False

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid

            End If

            'connect.closeConnection()

        End If

    End Sub

    Private Sub coutTotalMateriel()

        If Not Trim(GunaTextBoxPUR.Text).Equals("") And Not Trim(GunaTextBoxQuantite.Text).Equals("") Then
            GunaTextBoxPT.Text = Format(Double.Parse(GunaTextBoxPUR.Text) * Double.Parse(GunaTextBoxQuantite.Text), "#,##0")
        Else
            GunaTextBoxPT.Text = 0
        End If

    End Sub

    'AJOUT D'EQUIPEMENT UTILISE
    Private Sub GunaButtonAjouterLigne_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click

        GunaDataGridViewLigneEquipement.Rows.Add(GunaTextBoxCodeArticle.Text, GunaTextBoxArticle.Text, GunaTextBoxQuantite.Text, GunaTextBoxPU.Text, GunaTextBoxPUR.Text, GunaTextBoxPT.Text, GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR"))

        GunaTextBoxArticle.Clear()
        GunaButtonAjouterLigne.Visible = False

        GunaTextBoxCodeArticle.Text = ""
        GunaTextBoxArticle.Text = ""
        GunaTextBoxQuantite.Text = 1
        GunaTextBoxPU.Text = 0
        GunaTextBoxPUR.Text = 0
        GunaTextBoxPT.Text = 0

        montantTotalEquipementUtilise()

    End Sub

    Private Sub montantTotalEquipementUtilise()

        Dim montantTotal As Double = 0

        If GunaDataGridViewLigneEquipement.Rows.Count > 0 Then

            For i = 0 To GunaDataGridViewLigneEquipement.Rows.Count - 1
                montantTotal += GunaDataGridViewLigneEquipement.Rows(i).Cells("PT").Value
            Next

        End If

        GunaTextBoxTotalCout.Text = Format(montantTotal, "#,##0")

    End Sub


    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaAdvenceButton35_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonDemandeIntervention.Click

        DemandeInterventionForm.TopMost = True
        DemandeInterventionForm.Location = New System.Drawing.Point(10, 108)
        DemandeInterventionForm.Visible = True
        PanelBonIntervention.Hide()
        DemandeInterventionForm.TabControl2.SelectedIndex = 0
        DemandeInterventionForm.GunaLabelGestCompteGeneraux.Text = "REDACTION DEMANDE INTERVETION"

    End Sub

    Private Sub GunaAdvenceButton34_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonBonIntervention.Click

        DemandeInterventionForm.TopMost = False
        DemandeInterventionForm.Visible = False
        TabControl2.SelectedIndex = 1
        PanelBonIntervention.Show()
        PanelBonIntervention.BringToFront()

        GunaLabelGestCompteGeneraux.Text = "LISTE DES BONS D'INTERVENTIONS"

    End Sub

    Dim page As Integer = 1

    Private Sub ReceptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceptionToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        MainWindow.GunaDataGridViewResaDashBoard.Columns.Clear()

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()

        MainWindow.ReinitialisationDesDates()

        Me.Activate()

        MainWindow.GunaGroupBoxRoomStatus.Controls.Clear()
        'PanelGraphiques.Controls.Clear()
        MainWindow.GunaGroupBoxStatistiques.Controls.Clear()
        MainWindow.elementsDesChambres()
        MainWindow.contenuStatistique()
        MainWindow.StatistiquesDesChambres()
        MainWindow.StatusDesChambres(page)

        MainWindow.PanelTableauDeBords.Show()
        MainWindow.GunaShadowPanelReception.BringToFront()
        MainWindow.GunaShadowPanelReception.Show()

        MainWindow.GunaShadowPanelReservation.Hide()
        MainWindow.PanelEnregistrement.Hide()

        MainWindow.Show()

        Me.Hide()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RESERVATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESERVATIONToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        MainWindow.TabControlHbergement.SelectedIndex = 1

        MainWindow.GunaShadowPanelReservation.Show()
        MainWindow.PanelEnregistrement.Show()

        MainWindow.GunaShadowPanelReception.Hide()
        MainWindow.PanelTableauDeBords.Hide()

        MainWindow.Show()

        Me.Hide()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SERVICEDETAGEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SERVICEDETAGEToolStripMenuItem.Click
        GlobalVariable.typeChambreOuSalle = "chambre"

        MainWindowServiceEtageForm.Visible = True

        Me.Visible = False
    End Sub

    Private Sub BarRestaurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarRestaurationToolStripMenuItem.Click

        GlobalVariable.typeDeClientAFacturer = "comptoir"

        If Trim(GlobalVariable.AgenceActuelle.Rows(0)("CAISSE_ENREGISTREUSE_1")).Equals("") Then
            BarRestaurantForm.Show()
            BarRestaurantForm.GunaLabelHeader.Text = "COMPTOIR"
        Else
            BarRestaurantCaisseEnregistreuseForm.Show()
            BarRestaurantCaisseEnregistreuseForm.GunaLabelHeader.Text = "COMPTOIR"
        End If

        Me.Close()
    End Sub

    Private Sub ComptabilitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComptabilitéToolStripMenuItem.Click
        MainWindowComptabiliteForm.Visible = True

        Me.Visible = False
    End Sub

    Private Sub ECONOMATToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ECONOMATToolStripMenuItem.Click
        MainWindowEconomat.Show()

        Me.Visible = False
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Private Sub GunaLabel20_Click(sender As Object, e As EventArgs) Handles GunaLabelNotification.Click
        NotificationsForm.GunaTextBoxFromWhichWindow.Text = "technique"
        NotificationsForm.TopMost = True
        NotificationsForm.Show()

        Dim CATEG_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
        'Dim POSTE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("POSTE_UTILISATEUR")

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(CATEG_UTILISATEUR, "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then

            NotificationsForm.GunaDataGridViewNotification.Columns.Clear()

            NotificationsForm.GunaDataGridViewNotification.DataSource = notifications

            NotificationsForm.GunaDataGridViewNotification.Columns("ID_NOTIFICATION").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_PROFIL").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_AGENCE").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("ETAT_NOTIFCATION").Visible = False

        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor

        MainWindowCuisineForm.Show()
        ArticleForm.Show()

        ArticleForm.Location = New Point(90, 110)
        ArticleForm.TopMost = True
        Me.Close()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TimerToRefreshClock_Tick(sender As Object, e As EventArgs) Handles TimerToRefreshClock.Tick

        'NOTIFCATION
        'kklg

        If Not GlobalVariable.ConnectedUser Is Nothing Then

            Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

            If notifications.Rows.Count > 0 Then
                GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
            Else

            End If

        End If

    End Sub

    Private Sub ApprovisionnementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApprovisionnementToolStripMenuItem.Click
        BonApprovisionnementForm.Show()
        BonApprovisionnementForm.TopMost = True
    End Sub


    Private Sub listeDesDemandesValidees()

        Dim index As Integer = 5
        Dim query As String = ""

        If GunaComboBoxTypeBonAAficher.SelectedIndex >= 0 Then
            If GunaComboBoxTypeBonAAficher.SelectedIndex = 3 Then
                query = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` ORDER BY DATE_INTERVENTION ASC"

            Else
                query = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention`  WHERE STATUT =@STATUT ORDER BY DATE_INTERVENTION ASC"
            End If
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        If GunaComboBoxTypeBonAAficher.SelectedIndex >= 0 And GunaComboBoxTypeBonAAficher.SelectedIndex <= 2 Then
            command.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = GunaComboBoxTypeBonAAficher.SelectedItem
        End If

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        GunaDataGridViewDemandeIntervention.Columns.Clear()

        If (table.Rows.Count > 0) Then
            GunaDataGridViewDemandeIntervention.DataSource = table

        Else
            GunaDataGridViewDemandeIntervention.Columns.Clear()
        End If


    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        'LISTE DES DEMANDES VALIDES
        listeDesDemandesValidees()

    End Sub

    Private Sub GunaTextBoxQuantite_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxQuantite.TextChanged
        coutTotalMateriel()
    End Sub

    Private Sub GunaTextBoxPUR_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPUR.TextChanged
        coutTotalMateriel()
    End Sub

    Private Sub GunaComboBoxTemps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTemps.SelectedIndexChanged

        Dim facteur As Integer = 60

        Dim minutes As Integer = 0

        Dim conversion As Boolean = False

        If Not Trim(GunaTextBoxTempsMinutes.Text).Equals("") Then
            minutes = Double.Parse(GunaTextBoxTempsMinutes.Text)
        Else
            GunaTextBoxTempsMinutes.Text = 0
        End If

        If minutes > 0 Then

            If GunaComboBoxTemps.SelectedIndex = 0 Then

                GunaTextBoxTempsMinutes.Visible = True
                PanelTime.Visible = False
                GunaTextBoxTempsHeure.Visible = False
                GunaTextBoxTempsHeureMinutes.Visible = False
                GunaTextBoxTempsMinutes.Text = minutes

            ElseIf GunaComboBoxTemps.SelectedIndex = 1 Then

                GunaTextBoxTempsHeure.Visible = True
                GunaTextBoxTempsHeureMinutes.Visible = True
                GunaTextBoxTempsMinutes.Visible = False
                PanelTime.Visible = True

                Dim tempsEnHeure As Double = minutes / facteur
                Dim IntegerPart As Integer = Int(tempsEnHeure)
                Dim DecimalPart As Double = tempsEnHeure - IntegerPart

                GunaTextBoxTempsHeure.Text = IntegerPart
                GunaTextBoxTempsHeureMinutes.Text = Math.Ceiling(DecimalPart * facteur)

            End If

        End If

    End Sub

    Private Sub GunaComboBoxStatut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxStatut.SelectedIndexChanged
        GunaTextBoxStatut.Text = GunaComboBoxStatut.SelectedItem.ToString
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged

        GunaDataGridViewDemandeIntervention.DataSource = Nothing

        If TabControl2.SelectedIndex = 0 Then

            GunaTextBoxHeureIntervention.Text = Now().ToShortTimeString()
            GunaTextBoxCodeIntervention.Text = Functions.GeneratingRandomCodeWithSpecifications("intervention", "")

        End If

    End Sub

    Private Sub GunaButtonAfficherIntervention_Click(sender As Object, e As EventArgs)

        InterventionList()

    End Sub

    Private Sub ToolStripMenuItem128_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem128.Click

    End Sub

    Private Sub ToolStripMenuItem123_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem123.Click

    End Sub

    Private Sub ToolStripMenuItem124_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem124.Click

    End Sub

    Private Sub FamilleDePannesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamilleDePannesToolStripMenuItem.Click

    End Sub

    Private Sub SousFamillesDePannesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SousFamillesDePannesToolStripMenuItem.Click

    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        DemandeInterventionForm.TopMost = True
        DemandeInterventionForm.Location = New System.Drawing.Point(10, 108)
        DemandeInterventionForm.Visible = True
        PanelBonIntervention.Hide()
        DemandeInterventionForm.TabControl2.SelectedIndex = 1
        DemandeInterventionForm.GunaLabelGestCompteGeneraux.Text = "LISTE DES DEMANDES INTERVETIONS"
    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click

        DemandeInterventionForm.TopMost = False
        DemandeInterventionForm.Visible = False
        TabControl2.SelectedIndex = 2
        PanelBonIntervention.Show()
        PanelBonIntervention.BringToFront()

        GunaLabelGestCompteGeneraux.Text = "DEMANDE D'INTERVENTIONS EN ATTENTES"

    End Sub

    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButton2.Click

        TimePickerForm.GunaLabelTitreHeure.Text = "INTERVENTION"
        TimePickerForm.Show()
        TimePickerForm.TopMost = True

    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click

        If GunaDataGridViewDemandeIntervention.Rows.Count > 0 Then

            Dim CODE_DEMANDE_INTERVENTION As String = GunaDataGridViewDemandeIntervention.CurrentRow.Cells("CODE INTERVENTION").Value.ToString

            GlobalVariable.DocumentToGenerate = "intervention"

            Dim infoSupDemande As DataTable = Functions.getElementByCode(CODE_DEMANDE_INTERVENTION, "demande_intervention", "CODE_DEMANDE_INTERVENTION")

            If infoSupDemande.Rows.Count > 0 Then
                Impression.documentServiceTechnique(infoSupDemande)
            End If

        Else
            MessageBox.Show("Aucune ligne à supprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ToolStripMenuItem119_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem119.Click
        Dim dialog As DialogResult

        If GlobalVariable.actualLanguageValue = 1 Then
            dialog = MessageBox.Show("Voulez-vous vraiment fermer ", "Fermer BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Else
            dialog = MessageBox.Show("Do you really want to close your session ", "Close BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        End If

        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else

            Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

            Dim CODE_CAISSE As String = ""

            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

            End If

            Dim ETAT_CAISSE As Integer = 0
            Dim caissier As New Caisse()

            'caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

            Dim Action As String = ""

            If GlobalVariable.actualLanguageValue = 1 Then
                Action = "DECONNEXION DE " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")

            Else
                Action = "LOG OUT OF " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")

            End If

            User.mouchard(Action)

            HomeForm.Close()

            AccueilForm.Close()

            AccueilForm.Show()

            Me.Close()

        End If
    End Sub

    Private Sub ToolStripMenuItem117_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem117.Click
        GlobalVariable.changerMotDePasseDepuis = "technique"

        ChangePasswordForm.Show()
        ChangePasswordForm.TopMost = True

    End Sub

    Private Sub PlanningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanningToolStripMenuItem.Click
        PlanningHebdomadaireDuPersonnelForm.Show()
        PlanningHebdomadaireDuPersonnelForm.TopMost = True
    End Sub




    '-------------------------------END GESTION DES BON D'interventions -------------------------------

    '-------------------------------GESTION DES BON DE COMMANDES --------------------------------------



    '------------------------------END GESTION DES BON DE COMMANDES --------------------------------------

End Class