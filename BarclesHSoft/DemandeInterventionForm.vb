Imports MySql.Data.MySqlClient

Public Class DemandeInterventionForm

    'Dim connect As New DataBaseManipulation()

    Private Sub DemandeInterventionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaComboBoxInterventionStatuts.SelectedIndex = 0

        GunaTextBoxSite.Text = GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE")

        GunaDateTimePickerIntervention.Value = GlobalVariable.DateDeTravail

        'GunaDateTimePickerIntervention.Value = GlobalVariable.DateDeTravail

        TabControl2.SelectedIndex = 1

        'Charging  information into combobox
        AutoLoadInformation()

        'Definition des étages et sous sol
        ZoneEtSousZone()

        GunaTextBoxHeureDemande.Text = Now().ToLongTimeString

        autoloadTypeDePersonnel()

        GunaComboBoxStatut.SelectedIndex = 0

        GunaComboBoxLieuPanne.SelectedIndex = 0

    End Sub

    Public Sub autoLoadHabitation()

        If Trim(GunaComboBoxLocalisation.SelectedValue.ToString).Equals("Chambre - appartment") Then

            Dim chambre As DataTable = Functions.allTableFieldsOrganised("chambre", "CODE_CHAMBRE")

            If (chambre.Rows.Count > 0) Then

                GunaComboBoxSousZone.DataSource = chambre
                GunaComboBoxSousZone.ValueMember = "CODE_CHAMBRE"
                GunaComboBoxSousZone.DisplayMember = "CODE_CHAMBRE"

            End If

        Else
            GunaComboBoxSousZone.DataSource = Nothing
        End If

    End Sub

    Public Sub AutoLoadInformation()

        Dim TYPE As Integer = 0 'GRANDE FAMILLE DES PANNES ET SOUS FAMILLE : PLOMBERIE -> TUYEAU CASSE

        Dim Famille As DataTable = Functions.GetAllElementsOnTwoConditions("famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE", TYPE, "TYPE")

        If (Famille.Rows.Count > 0) Then

            GunaComboFamille.DataSource = Famille
            GunaComboFamille.ValueMember = "LIBELLE"
            GunaComboFamille.DisplayMember = "LIBELLE"

            Dim SousFamille As DataTable = Functions.GetAllElementsOnTwoConditions("sous famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE", GunaComboFamille.SelectedValue.ToString, "PARENT")

            If SousFamille.Rows.Count > 0 Then

                GunaComboBoxSousFamille.DataSource = SousFamille
                GunaComboBoxSousFamille.ValueMember = "LIBELLE"
                GunaComboBoxSousFamille.DisplayMember = "LIBELLE"

            End If

        End If

        Dim TYPE_ As Integer = 1 'GRANDE FAMILLE DES PANNES ET SOUS FAMILLE : PLOMBERIE -> TUYEAU CASSE

        Dim Famille_ As DataTable = Functions.GetAllElementsOnTwoConditions("famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE", TYPE_, "TYPE")

        If (Famille_.Rows.Count > 0) Then

            GunaComboBoxLocalisation.DataSource = Famille_
            GunaComboBoxLocalisation.ValueMember = "LIBELLE"
            GunaComboBoxLocalisation.DisplayMember = "LIBELLE"

            autoLoadHabitation()

            If GunaComboBoxLocalisation.SelectedIndex >= 0 Then

                Dim CODE_LOCALISATION_PARENT As String = GunaComboBoxLocalisation.SelectedValue.ToString
                loadSousLocalisation(CODE_LOCALISATION_PARENT)

            End If

        End If

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

    'LIste des Articles
    Public Sub InterventionList()

        Dim query As String = ""

        If GunaComboBoxInterventionStatuts.SelectedIndex >= 0 Then
            If GunaComboBoxInterventionStatuts.SelectedIndex = 3 Then
                query = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` ORDER BY DATE_INTERVENTION ASC"

            Else
                query = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention`  WHERE STATUT =@STATUT ORDER BY DATE_INTERVENTION ASC"
            End If
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        If GunaComboBoxInterventionStatuts.SelectedIndex >= 0 And GunaComboBoxInterventionStatuts.SelectedIndex <= 2 Then
            command.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = GunaComboBoxInterventionStatuts.SelectedItem
        End If

        'REFRESHING information from database for instant visualisation 
        'Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` ORDER BY DATE_INTERVENTION ASC"

        'Dim command As New MySqlCommand(query, GlobalVariable.connect)
        'Parameters.Add("@TYPE_INTERVENTION", MySqlDbType.VarChar).Value = GlobalVariable.TypeIntervention

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewDemandeIntervention.DataSource = table

            'GunaDataGridViewDemandeIntervention.Columns("STATUT").Visible = False
        Else
            GunaDataGridViewDemandeIntervention.Columns.Clear()
        End If

    End Sub

    'Enregistrer
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_DEMANDE_INTERVENTION = GunaTextBoxCodeDemandeInervention.Text

        Dim DATE_INTERVENTION = GunaDateTimePickerIntervention.Value.ToShortDateString
        Dim HEURE_INTERVENTION = GunaTextBoxHeureDemande.Text
        Dim SITE = GunaTextBoxSite.Text
        Dim SOUS_ZONE = ""

        If GunaComboBoxSousZone.SelectedIndex >= 0 Then
            SOUS_ZONE = GunaComboBoxSousZone.SelectedValue.ToString()
        End If

        Dim ZONE = GunaComboBoxZone.SelectedItem.ToString
        Dim STATUT = GunaComboBoxStatut.SelectedItem
        Dim FAMILLE_PANNE = GunaComboFamille.SelectedValue.ToString
        Dim TYPE_PANNE = GunaComboBoxSousFamille.SelectedValue.ToString
        Dim ORIGINE_DEMANDE = GunaTextBoxOrigin.Text
        Dim COMMENTAIRE = GunaTextBoxCommentaire.Text
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim SERVICE_ORIGIN As String = ""
        Dim LIEU_PANNE As String = GunaComboBoxLieuPanne.SelectedItem

        If GunaComboBoxOriginDemande.SelectedIndex >= 0 Then
            SERVICE_ORIGIN = GunaComboBoxOriginDemande.SelectedItem
        End If

        Dim panne As New Panne()

        If Trim(GunaButtonEnregistrer.Text) = "Sauvegarder" Then

            Functions.DeleteElementByCode(CODE_DEMANDE_INTERVENTION, "demande_intervention_probleme", "CODE_DEMANDE")

            If panne.UpdateDemande(CODE_DEMANDE_INTERVENTION, DATE_INTERVENTION, HEURE_INTERVENTION, SITE, SOUS_ZONE, ZONE, STATUT, FAMILLE_PANNE, TYPE_PANNE, ORIGINE_DEMANDE, COMMENTAIRE, CODE_AGENCE, CODE_UTILISATEUR, SERVICE_ORIGIN, LIEU_PANNE) Then
                MessageBox.Show("Demande d'interveion mise à jour avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            TabControl2.SelectedIndex = 1

            GunaButtonEnregistrer.Text = "Enregistrer"

        ElseIf Trim(GunaButtonEnregistrer.Text) = "Enregistrer" Or Trim(GunaButtonValider.Text) = "Valider" Then

            'verifyfields function
            If (True) Then

                'En cas de validation soit on veut editer (valider) une demande existante ou alors enregistrer une nouvelle demande en la validant directement
                'on supprimer si existe toute occurence de cette demande dans la db avant une nouvelle insertion en changeant l'état
                If Trim(GunaButtonEnregistrer.Text) = "Valider" Then

                    STATUT = "Validée"
                    Functions.DeleteElementByCode(GunaTextBoxCodeDemandeInervention.Text, "demande_intervention", "CODE_DEMANDE_INTERVENTION")

                End If

                'check existence
                If Not Functions.entryCodeExists(CODE_DEMANDE_INTERVENTION, "demande_intervention", "CODE_DEMANDE_INTERVENTION") Then

                    If STATUT = "En cours" Then
                        STATUT = "Mise en attente"
                    End If

                    If panne.InsertDemande(CODE_DEMANDE_INTERVENTION, DATE_INTERVENTION, HEURE_INTERVENTION, SITE, SOUS_ZONE, ZONE, STATUT, FAMILLE_PANNE, TYPE_PANNE, ORIGINE_DEMANDE, COMMENTAIRE, CODE_AGENCE, CODE_UTILISATEUR, SERVICE_ORIGIN, LIEU_PANNE) Then
                        MessageBox.Show("Nouvel demande enregistrée avec succès", "Création Demande", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création Demande", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Cette demande existe déjà, Essayer à nouveau", "Demande Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Demande Invalide", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        If GunaDataGridViewP1.Rows.Count > 0 Then

            For i = 0 To GunaDataGridViewP1.Rows.Count - 1

                Dim CODE_PROBLEME As String = GunaDataGridViewP1.Rows(i).Cells("CODE_").Value.ToString
                Dim LOCALISATION_PANNE As String = GunaDataGridViewP1.Rows(i).Cells("PROBLEME_PARENT_").Value.ToString
                Dim HABITATION As String = GunaDataGridViewP1.Rows(i).Cells("CHAMBRE_").Value.ToString 
                Dim PROBLEME As String = GunaDataGridViewP1.Rows(i).Cells("PROBLEME_").Value.ToString

                panne.insertProblemeDemande(CODE_PROBLEME, CODE_DEMANDE_INTERVENTION, LOCALISATION_PANNE, HABITATION, PROBLEME)

            Next

            GunaDataGridViewP1.Rows.Clear()
            GunaComboBoxLocalisation.SelectedIndex = -1
            GunaComboBoxOriginDemande.SelectedIndex = -1
            GunaComboBoxNomDemande.SelectedIndex = -1
            GunaTextBoxCommentaire.Clear()
            GunaTextBoxNombreDeProblem.Text = 0

        End If

        GunaComboBoxLocalisation.SelectedIndex = 1
        GunaTextBoxOrigin.Text = ""
        GunaTextBoxNombreDeProblem.Text = "0"
        'Functions.SiplifiedClearTextBox(Me)

        'InterventionList()

        TabControl2.SelectedIndex = 1

        'connect.closeConnection()

    End Sub

    'Validation de demande
    Private Sub GunaButtonValider_Click(sender As Object, e As EventArgs) Handles GunaButtonValider.Click

        Dim CODE_DEMANDE_INTERVENTION = Functions.GeneratingRandomCodePanne("demande_intervention", "")
        Dim DATE_INTERVENTION = GunaDateTimePickerIntervention.Value.ToShortDateString
        Dim HEURE_INTERVENTION = GunaTextBoxHeureDemande.Text
        Dim SITE = GunaTextBoxSite.Text
        Dim SOUS_ZONE = GunaComboBoxSousZone.SelectedValue.ToString
        Dim ZONE = GunaComboBoxZone.SelectedItem.ToString
        Dim STATUT = GunaTextBoxStatut.Text
        Dim FAMILLE_PANNE = GunaComboFamille.SelectedValue.ToString
        Dim TYPE_PANNE = GunaComboBoxSousFamille.SelectedValue.ToString
        Dim ORIGINE_DEMANDE = GunaTextBoxOrigin.Text
        Dim COMMENTAIRE = GunaTextBoxCommentaire.Text
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim panne As New Panne()

        Dim SERVICE_ORIGIN As String = ""
        Dim LIEU_PANNE As String = ""

        If Trim(GunaButtonValider.Text) = "Valider" Then

            'verifyfields function
            If (True) Then

                'En cas de validation soit on veut editer (valider) une demande existante ou alors enregistrer une nouvelle demande en la validant directement
                'on supprimer si existe toute occurence de cette demande dans la db avant une nouvelle insertion en changeant l'état


                STATUT = "Validée"
                Functions.DeleteElementByCode(GunaTextBoxCodeDemandeInervention.Text, "demande_intervention", "CODE_DEMANDE_INTERVENTION")

                'check existence
                If Not Functions.entryCodeExists(CODE_DEMANDE_INTERVENTION, "demande_intervention", "CODE_DEMANDE_INTERVENTION") Then


                    If panne.InsertDemande(CODE_DEMANDE_INTERVENTION, DATE_INTERVENTION, HEURE_INTERVENTION, SITE, SOUS_ZONE, ZONE, STATUT, FAMILLE_PANNE, TYPE_PANNE, ORIGINE_DEMANDE, COMMENTAIRE, CODE_AGENCE, CODE_UTILISATEUR, SERVICE_ORIGIN, LIEU_PANNE) Then

                        MessageBox.Show("Demandé enregistrée et validée avec succès", "Validation Demande", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création Demande", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Cette demande existe déjà, Essayer à nouveau", "Demande Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Demande Invalide", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        Functions.SiplifiedClearTextBox(Me)

        STATUT = "En cours"
        'InterventionList()

        TabControl2.SelectedIndex = 1

        'connect.closeConnection()

    End Sub

    'Reorganise when we enter the button for search
    Private Sub GunaTextBoxcCode_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` ORDER BY DATE_INTERVENTION ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

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
    Private Sub GunaTextBoxcCode_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT CODE_ARTICLE AS 'CODE', DESIGNATION_FR AS 'DESIGNATION', DESCRIPTION , PRIX_VENTE_HT As 'PRIX HT' FROM article WHERE CODE_ARTICLE LIKE '%" & GunaTextBoxcCode.Text & "%' ORDER BY DESIGNATION_FR ASC"
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then

        'GunaDataGridViewDemandeIntervention.DataSource = table

        'Else
        'GunaDataGridViewDemandeIntervention.Columns.Clear()
        'End If

        ''connect.closeConnection()

    End Sub

    'live search  based on the name
    Private Sub GunaTextBoxDesig_TextChanged(sender As Object, e As EventArgs)

        ' Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` WHERE CODE_DEMANDE_INTERVENTION LIKE '%" & GunaTextBoxDesig.Text & "%' ORDER BY CODE_DEMANDE_INTERVENTION ASC"

        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'GunaDataGridViewDemandeIntervention.DataSource = table
        'Else
        'GunaDataGridViewDemandeIntervention.Columns.Clear()
        'End If

        ''connect.closeConnection()

    End Sub

    Private Sub GunaTextBoxDesig_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` ORDER BY DATE_INTERVENTION ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

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

    'mise à jours dea
    Private Sub GunaDataGridViewDemandeIntervention_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewDemandeIntervention.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewDemandeIntervention.Rows(e.RowIndex)

            Dim demandeIntervention As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE INTERVENTION").Value.ToString), "demande_intervention", "CODE_DEMANDE_INTERVENTION")

            If demandeIntervention.Rows.Count > 0 Then

                GunaTextBoxCodeDemandeInervention.Text = demandeIntervention.Rows(0)("CODE_DEMANDE_INTERVENTION")
                GunaDateTimePickerIntervention.Value = demandeIntervention.Rows(0)("DATE_INTERVENTION")
                GunaTextBoxHeureDemande.Text = demandeIntervention.Rows(0)("HEURE_INTERVENTION")
                GunaTextBoxSite.Text = demandeIntervention.Rows(0)("SITE")
                GunaComboBoxZone.SelectedItem = demandeIntervention.Rows(0)("ZONE")

                If Trim(demandeIntervention.Rows(0)("STATUT")).Equals("Terminé") Then
                    GunaTextBoxStatut.Text = "Terminée"
                    GunaComboBoxStatut.SelectedItem = "Terminée"

                Else
                    GunaComboBoxStatut.SelectedItem = demandeIntervention.Rows(0)("STATUT")
                    GunaTextBoxStatut.Text = demandeIntervention.Rows(0)("STATUT")
                End If

                GunaComboFamille.SelectedValue = demandeIntervention.Rows(0)("FAMILLE_PANNE")
                GunaComboBoxSousFamille.SelectedValue = demandeIntervention.Rows(0)("TYPE_PANNE") 'SOUS FAMILLE
                GunaTextBoxOrigin.Text = demandeIntervention.Rows(0)("ORIGINE_DEMANDE")
                GunaTextBoxCommentaire.Text = demandeIntervention.Rows(0)("COMMENTAIRE")
                GunaComboBoxOriginDemande.SelectedItem = demandeIntervention.Rows(0)("SERVICE_ORIGIN")
                GunaComboBoxNomDemande.SelectedItem = demandeIntervention.Rows(0)("ORIGINE_DEMANDE")

                If Not Trim(demandeIntervention.Rows(0)("SOUS_ZONE")).Equals("") Then

                    Dim chambre As DataTable = Functions.allTableFieldsOrganised("chambre", "CODE_CHAMBRE")

                    If (chambre.Rows.Count > 0) Then

                        GunaComboBoxSousZone.DataSource = chambre
                        GunaComboBoxSousZone.ValueMember = "CODE_CHAMBRE"
                        GunaComboBoxSousZone.DisplayMember = "CODE_CHAMBRE"

                    End If

                    GunaComboBoxSousZone.SelectedValue = demandeIntervention.Rows(0)("SOUS_ZONE")

                End If

                Dim dt As DataTable = Functions.getElementByCode(demandeIntervention.Rows(0)("CODE_DEMANDE_INTERVENTION"), "demande_intervention_probleme", "CODE_DEMANDE")

                If dt.Rows.Count > 0 Then

                    GunaTextBoxNombreDeProblem.Text = dt.Rows.Count

                    For i = 0 To dt.Rows.Count - 1
                        GunaDataGridViewP1.Rows.Add(dt.Rows(i)("CODE_PROBLEME"), dt.Rows(i)("PROBLEME"), dt.Rows(i)("LOCALISATION_PANNE"), dt.Rows(i)("HABITATION"))
                    Next

                End If

            End If

            TabControl2.SelectedIndex = 0
            GunaDataGridViewDemandeIntervention.Columns.Clear()

        End If

    End Sub

    'SUPRESSION D'ARTICLE
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewDemandeIntervention.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supperimer cet article " & GunaDataGridViewDemandeIntervention.CurrentRow.Cells("CODE INTERVENTION").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

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

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnuler.Click
        Me.Close()
    End Sub

    Private Sub loadSousLocalisation(ByVal CODE_LOCALISATION_PARENT As String)

        Dim SousFamille As DataTable = Functions.GetAllElementsOnTwoConditions("sous famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE", CODE_LOCALISATION_PARENT, "PARENT")

        If SousFamille.Rows.Count > 0 Then

            GunaDataGridViewP0.Rows.Clear()

            Dim Chambre As String = ""

            If GunaComboBoxSousZone.SelectedIndex >= 0 Then
                Chambre = GunaComboBoxSousZone.SelectedValue.ToString()
            End If

            For i = 0 To SousFamille.Rows.Count - 1
                GunaDataGridViewP0.Rows.Add(SousFamille.Rows(i)("CODE_PANNE"), SousFamille.Rows(i)("LIBELLE"), CODE_LOCALISATION_PARENT, Chambre)
            Next

        End If

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

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged

        GunaDataGridViewDemandeIntervention.DataSource = Nothing

        If Trim(GunaButtonEnregistrer.Text).Equals("Enregistrer") Then
            GunaTextBoxHeureDemande.Text = Now().ToLongTimeString()
            GunaTextBoxCodeDemandeInervention.Text = Functions.GeneratingRandomCodeWithSpecifications("demande_intervention", "")
        End If

        If TabControl2.SelectedIndex = 0 Then
            GunaButtonAnnuler.Visible = True
            GunaButtonValider.Visible = False
            GunaButtonEnregistrer.Visible = True
        Else
            GunaButtonAnnuler.Visible = True
            GunaButtonValider.Visible = False
            GunaButtonEnregistrer.Visible = False
        End If

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        InterventionList()
    End Sub


    Private Sub autoloadTypeDePersonnel()

        Dim tableTypePersonnel As DataTable = Functions.allTableFieldsOrganised("type_personnel", "LIBELLE_TYPE_PERSONNEL")

        GunaComboBoxOriginDemande.Items.Clear()

        If (tableTypePersonnel.Rows.Count > 0) Then

            For i = 0 To tableTypePersonnel.Rows.Count - 1
                GunaComboBoxOriginDemande.Items.Add(tableTypePersonnel.Rows(i)("LIBELLE_TYPE_PERSONNEL"))
            Next

            GunaComboBoxOriginDemande.Items.Add("CLIENT")

        End If

    End Sub

    Private Sub autoloadNomParApportAuType(ByVal type_personnel As String)

        Dim tableTypePersonnel As DataTable = Functions.getElementByCode(type_personnel, "type_personnel", "LIBELLE_TYPE_PERSONNEL")

        GunaComboBoxNomDemande.Items.Clear()

        If Trim(GunaComboBoxOriginDemande.SelectedItem).Equals("CLIENT") Then

            'ON SELECTION LES EN CHAMBRES DU JOUR

            Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

            Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 ORDER BY CHAMBRE_ID ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If table.Rows.Count > 0 Then

                For i = 0 To table.Rows.Count - 1
                    GunaComboBoxNomDemande.Items.Add(table.Rows(i)("CHAMBRE") & " - " & table.Rows(i)("NOM CLIENT"))
                Next

            End If

        Else

            If tableTypePersonnel.Rows.Count > 0 Then

                Dim CODE_TYPE_PERSONNEL As String = tableTypePersonnel.Rows(0)("CODE_TYPE_PERSONNEL")

                Dim personnel As DataTable = Functions.getElementByCode(CODE_TYPE_PERSONNEL, "personnel", "CODE_TYPE_PERSONNEL")

                If personnel.Rows.Count > 0 Then

                    For i = 0 To tableTypePersonnel.Rows.Count - 1
                        GunaComboBoxNomDemande.Items.Add(personnel.Rows(i)("NOM_PERSONNEL") & " " & personnel.Rows(i)("PRENOM_PERSONNEL"))
                    Next

                End If

            End If

        End If

    End Sub

    Private Sub GunaComboBoxOriginDemande_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxOriginDemande.SelectedIndexChanged

        'ON DOIT SELECTIONNER LES NOM DU PERSONNELS EN FONCTIONS DU TYPE DU PERSONNEL OU CLIENT

        If GunaComboBoxOriginDemande.SelectedIndex >= 0 Then
            autoloadNomParApportAuType(GunaComboBoxOriginDemande.SelectedItem)
        End If

    End Sub

    Private Sub GunaComboBoxNomDemande_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNomDemande.SelectedIndexChanged

        If GunaComboBoxNomDemande.SelectedIndex >= 0 Then
            GunaTextBoxOrigin.Text = GunaComboBoxNomDemande.SelectedItem
        End If

    End Sub

    Private Sub GunaComboBoxStatut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxStatut.SelectedIndexChanged

        If GunaComboBoxStatut.SelectedIndex >= 0 Then
            GunaTextBoxStatut.Text = GunaComboBoxStatut.SelectedItem
        End If

    End Sub

    Private Sub GunaComboBoxLocalisation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxLocalisation.SelectedIndexChanged

        If GunaComboBoxLocalisation.SelectedIndex >= 0 Then

            autoLoadHabitation()

            Dim CODE_LOCALISATION_PARENT As String = GunaComboBoxLocalisation.SelectedValue.ToString
            loadSousLocalisation(CODE_LOCALISATION_PARENT)

        End If

    End Sub

    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButton2.Click
        deplacemntDeLigne(GunaDataGridViewP0, GunaDataGridViewP1)
    End Sub

    Public Sub deplacemntDeLigne(ByVal GridDepart As DataGridView, ByVal GridArrive As DataGridView)

        If GridDepart.SelectedRows.Count > 0 Then

            Dim selectedgrid As DataGridViewRow = GridDepart.SelectedRows(0)
            GridDepart.Rows.Remove(selectedgrid)
            GridArrive.Rows.Add(selectedgrid)

            Dim nombreDePanne As Integer = 0

            If GunaDataGridViewP1.Rows.Count > 0 Then
                nombreDePanne = GunaDataGridViewP1.Rows.Count
            End If

            GunaTextBoxNombreDeProblem.Text = nombreDePanne

        End If

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        deplacemntDeLigne(GunaDataGridViewP1, GunaDataGridViewP0)
    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click
        GunaDataGridViewP1.Rows.Clear()
    End Sub

    Private Sub GunaTextBoxIntervention_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxIntervention.TextChanged

        If Not Trim(GunaTextBoxIntervention.Text).Equals("") Then

            'Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` WHERE CODE_DEMANDE_INTERVENTION LIKE '%" & GunaTextBoxcCodeLibelle.Text & "%' AND STATUT =@STATUT or FAMILLE_PANNE LIKE '%" & GunaTextBoxcCodeLibelle.Text & "%' AND STATUT =@STATUT ORDER BY CODE_DEMANDE_INTERVENTION ASC"
            Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` WHERE CODE_DEMANDE_INTERVENTION LIKE '%" & GunaTextBoxIntervention.Text & "%' OR FAMILLE_PANNE LIKE '%" & GunaTextBoxIntervention.Text & "%' ORDER BY CODE_DEMANDE_INTERVENTION ASC"

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

    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click

        If GunaDataGridViewDemandeIntervention.Rows.Count > 0 Then

            Dim CODE_DEMANDE_INTERVENTION As String = GunaDataGridViewDemandeIntervention.CurrentRow.Cells("CODE INTERVENTION").Value.ToString

            GlobalVariable.DocumentToGenerate = "demande intervention"

            Dim infoSupDemande As DataTable = Functions.getElementByCode(CODE_DEMANDE_INTERVENTION, "demande_intervention", "CODE_DEMANDE_INTERVENTION")

            If infoSupDemande.Rows.Count > 0 Then
                Impression.documentServiceTechnique(infoSupDemande)
            End If

        Else
            MessageBox.Show("Aucune ligne à supprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

End Class