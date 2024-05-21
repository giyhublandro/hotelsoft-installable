Imports MySql.Data.MySqlClient

Public Class BonInterventionForm

    'Dim connect As New DataBaseManipulation()

    Private Sub BonInterventionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaTextBoxSite.Text = GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE")

        GunaDataGridViewLigneEquipement.Columns.Add("CODE_EQUIPEMENT", "CODE EQUIPEMENT")
        GunaDataGridViewLigneEquipement.Columns.Add("LIBELLE_EQUIPEMENT", "LIBELLE EQUIPEMENT")
        GunaDataGridViewLigneEquipement.Columns.Add("QUANTITE", "QUANTITE")

        GunaDateTimePickerIntervention.Value = GlobalVariable.DateDeTravail

        TabControl2.SelectedIndex = 1

        'Charging  information into combobox
        AutoLoadInformation()

        'Definition des étages et sous sol
        ZoneEtSousZone()

    End Sub

    Public Sub AutoLoadInformation()

        Dim Famille As DataTable = Functions.GetAllElementsOnCondition("famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE")

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

    'LIste des Articles
    Public Sub DemandeInterventionListATraiter()

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
            GunaDataGridViewDemandeIntervention.Columns.Clear()
        End If

    End Sub

    Public Sub InterventionListeTreated()

        Dim query1 As String = "SELECT `CODE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `intervention` ORDER BY DATE_INTERVENTION DESC"

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)

        If (table1.Rows.Count > 0) Then
            GunaDataGridViewListeIntervention.DataSource = table1
        Else
            GunaDataGridViewListeIntervention.Columns.Clear()
        End If

    End Sub

    'Enregistrer
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_DEMANDE_INTERVENTION = Functions.GeneratingRandomCodePanne("intervention", "")
        Dim DATE_INTERVENTION = GunaDateTimePickerIntervention.Value.ToShortDateString
        Dim HEURE_INTERVENTION = GunaDateTimePickerHeure.Value.ToShortTimeString
        Dim SITE = GunaTextBoxSite.Text
        Dim SOUS_ZONE = GunaComboBoxSousZone.SelectedValue.ToString
        Dim ZONE = GunaComboBoxZone.SelectedItem.ToString
        Dim STATUT = GunaTextBoxStatut.Text
        Dim FAMILLE_PANNE = GunaComboFamille.SelectedValue.ToString
        Dim TYPE_PANNE = GunaComboBoxSousFamille.SelectedValue.ToString
        Dim ORIGINE_DEMANDE = GunaTextBoxOrigin.Text 'DIAGNOSTIQUE
        Dim COMMENTAIRE = GunaTextBoxCommentaire.Text

        Dim CODE_INTERVENANT = GunaComboBoxIntervenant.SelectedValue.ToString
        Dim CODE_DEMANDE = GunaTextBoxCodeDemandeIntervention.Text
        Dim tempsTravail As Integer = 0
        Integer.TryParse(GunaTextBoxTemps.Text, tempsTravail)
        Dim TEMPS As Integer = tempsTravail
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim SERVICE_ORIGIN As String = ""
        Dim LIEU_PANNE As String = ""
        Dim ORIGINE_DEMANDE_ As String = ""

        Dim panne As New Panne()

        If Trim(GunaButtonEnregistrer.Text) = "Sauvegarder" Then

            CODE_DEMANDE_INTERVENTION = GunaTextBoxCodeDemandeIntervention.Text

            If panne.UpdateDemande(CODE_DEMANDE_INTERVENTION, DATE_INTERVENTION, HEURE_INTERVENTION, SITE, SOUS_ZONE, ZONE, STATUT, FAMILLE_PANNE, TYPE_PANNE, ORIGINE_DEMANDE, COMMENTAIRE, CODE_AGENCE, CODE_UTILISATEUR, SERVICE_ORIGIN, LIEU_PANNE) Then

                MessageBox.Show("Demande d'interveion mise à jour avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            TabControl2.SelectedIndex = 1

            GunaButtonEnregistrer.Text = "Enregistrer"

        ElseIf Trim(GunaButtonEnregistrer.Text) = "Enregistrer" Then

            'verifyfields function
            If (True) Then

                'En cas de validation soit on veut editer (valider) une demande existante ou alors enregistrer une nouvelle demande en la validant directement
                'on supprimer si existe toute occurence de cette demande dans la db avant une nouvelle insertion en changeant l'état

                'check existence
                If Not Functions.entryCodeExists(CODE_DEMANDE_INTERVENTION, "intervention", "CODE_INTERVENTION") Then

                    If panne.InsertIntervention(CODE_DEMANDE_INTERVENTION, DATE_INTERVENTION, HEURE_INTERVENTION, SITE, SOUS_ZONE, ZONE, STATUT, FAMILLE_PANNE, TYPE_PANNE, ORIGINE_DEMANDE, COMMENTAIRE, CODE_AGENCE, CODE_UTILISATEUR, CODE_INTERVENANT, CODE_DEMANDE, TEMPS, LIEU_PANNE, ORIGINE_DEMANDE_) Then

                        MessageBox.Show("Nouvel Intervention enregistrée avec succès", "Création Demande", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création Demande", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Cette Intervention existe déjà, Essayer à nouveau", "Demande Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Demande Invalide", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        Functions.SiplifiedClearTextBox(Me)

        TabControl2.SelectedIndex = 1

        'connect.closeConnection()

    End Sub

    'Validation de Intervention
    Private Sub GunaButtonValider_Click(sender As Object, e As EventArgs) Handles GunaButtonValider.Click

        Dim CODE_DEMANDE_INTERVENTION = Functions.GeneratingRandomCode("intervention", "")
        Dim DATE_INTERVENTION = GunaDateTimePickerIntervention.Value.ToShortDateString
        Dim HEURE_INTERVENTION = GunaDateTimePickerHeure.Value.ToShortTimeString
        Dim SITE = GunaTextBoxSite.Text
        Dim SOUS_ZONE = GunaComboBoxSousZone.SelectedValue.ToString
        Dim ZONE = GunaComboBoxZone.SelectedItem.ToString
        Dim STATUT = GunaTextBoxStatut.Text
        Dim FAMILLE_PANNE = GunaComboFamille.SelectedValue.ToString
        Dim TYPE_PANNE = GunaComboBoxSousFamille.SelectedValue.ToString
        Dim ORIGINE_DEMANDE = GunaTextBoxOrigin.Text 'DIAGNOSTIQUE
        Dim COMMENTAIRE = GunaTextBoxCommentaire.Text

        Dim CODE_INTERVENANT = GunaComboBoxIntervenant.SelectedValue.ToString
        Dim CODE_DEMANDE = GunaTextBoxCodeDemandeIntervention.Text
        Dim tempsTravail As Integer = 0
        Integer.TryParse(GunaTextBoxTemps.Text, tempsTravail)
        Dim TEMPS As Integer = tempsTravail
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim LIEU_PANNE As String = ""
        Dim ORIGINE_DEMANDE_ As String = ""

        Dim panne As New Panne()

        If Trim(GunaButtonValider.Text) = "Valider" Then

            'verifyfields function
            If (True) Then

                'En cas de validation soit on veut editer (valider) une demande existante ou alors enregistrer une nouvelle demande en la validant directement
                'on supprimer si existe toute occurence de cette demande dans la db avant une nouvelle insertion en changeant l'état

                Functions.DeleteElementByCode(GunaTextBoxCodeDemandeIntervention.Text, "intervention", "CODE_INTERVENTION")

                'check existence
                If Not Functions.entryCodeExists(CODE_DEMANDE_INTERVENTION, "demande_intervention", "CODE_DEMANDE_INTERVENTION") Then

                    If panne.InsertIntervention(CODE_DEMANDE_INTERVENTION, DATE_INTERVENTION, HEURE_INTERVENTION, SITE, SOUS_ZONE, ZONE, STATUT, FAMILLE_PANNE, TYPE_PANNE, ORIGINE_DEMANDE, COMMENTAIRE, CODE_AGENCE, CODE_UTILISATEUR, CODE_INTERVENANT, CODE_DEMANDE, TEMPS, LIEU_PANNE, ORIGINE_DEMANDE_) Then
                        STATUT = "Achevé"
                        panne.UpdateStatutDemande(CODE_DEMANDE, STATUT)

                        MessageBox.Show("Intervention enregistrée et validée avec succès", "Validation Intervention", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

        'connect.closeConnection()

    End Sub

    'Live search based on the code
    Private Sub GunaTextBoxcCode_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT CODE_ARTICLE AS 'CODE', DESIGNATION_FR AS 'DESIGNATION', DESCRIPTION , PRIX_VENTE_HT As 'PRIX HT' FROM article WHERE CODE_ARTICLE LIKE '%" & GunaTextBoxcCode.Text & "%' ORDER BY DESIGNATION_FR ASC"

        'Dim command As New MySqlCommand(query, GlobalVariable.connect)
        'Command.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = "Validée"

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then

        'GunaDataGridViewDemandeIntervention.DataSource = table

        ' Else
        'GunaDataGridViewDemandeIntervention.Columns.Clear()
        'End If

        'connect.closeConnection()

    End Sub

    'live search  based on the name
    Private Sub GunaTextBoxDesig_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT `CODE_DEMANDE_INTERVENTION` AS 'CODE INTERVENTION', `DATE_INTERVENTION` AS 'DATE INTERVENTION', `HEURE_INTERVENTION` AS 'HEURE INTERVENTION', `SITE`, `SOUS_ZONE` As 'SOUS ZONE', `ZONE`, `STATUT`, `FAMILLE_PANNE` AS 'FAMILLE PANNE', `TYPE_PANNE` AS 'TYPE PANNE', `ORIGINE_DEMANDE` AS 'ORIGINE DEMANDE', `COMMENTAIRE` FROM `demande_intervention` WHERE CODE_DEMANDE_INTERVENTION LIKE '%" & GunaTextBoxDesig.Text & "%' AND STATUT =@STATUT ORDER BY CODE_DEMANDE_INTERVENTION ASC"

        'Dim command As New MySqlCommand(query, GlobalVariable.connect)
        'Command.Parameters.Add("@STATUT", MySqlDbType.VarChar).Value = "Validée"

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        ' GunaDataGridViewDemandeIntervention.DataSource = table
        'Else
        'GunaDataGridViewDemandeIntervention.Columns.Clear()
        'End If

        'connect.closeConnection()

    End Sub

    'mise à jours dea
    Private Sub GunaDataGridViewArticle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewDemandeIntervention.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Enregistrer"

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewDemandeIntervention.Rows(e.RowIndex)

            TabControl2.SelectedIndex = 0

            Dim demandeIntervention As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE INTERVENTION").Value.ToString), "demande_intervention", "CODE_DEMANDE_INTERVENTION")

            If demandeIntervention.Rows.Count > 0 Then

                GunaTextBoxCodeDemandeIntervention.Text = demandeIntervention.Rows(0)("CODE_DEMANDE_INTERVENTION")
                GunaDateTimePickerIntervention.Value = demandeIntervention.Rows(0)("DATE_INTERVENTION")
                GunaDateTimePickerHeure.Value = demandeIntervention.Rows(0)("DATE_INTERVENTION")
                GunaTextBoxSite.Text = demandeIntervention.Rows(0)("SITE")
                GunaComboBoxSousZone.SelectedValue = demandeIntervention.Rows(0)("SOUS_ZONE")
                GunaComboBoxZone.SelectedItem = demandeIntervention.Rows(0)("ZONE")
                GunaTextBoxStatut.Text = demandeIntervention.Rows(0)("STATUT")
                GunaComboFamille.SelectedValue = demandeIntervention.Rows(0)("FAMILLE_PANNE")
                GunaComboBoxSousFamille.SelectedValue = demandeIntervention.Rows(0)("TYPE_PANNE") 'SOUS FAMILLE
                GunaTextBoxOrigin.Text = demandeIntervention.Rows(0)("ORIGINE_DEMANDE")
                GunaTextBoxCommentaire.Text = demandeIntervention.Rows(0)("COMMENTAIRE")

                If Trim(demandeIntervention.Rows(0)("STATUT")) = "Validée" Then
                    GunaTextBoxStatut.Text = "En cours"
                End If

                GunaTextBoxOrigin.Clear()
                GunaTextBoxCommentaire.Clear()

            End If

        End If

    End Sub

    'SUPRESSION DEMANDES INTERVENTIONS
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click
        If GunaDataGridViewDemandeIntervention.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supperimer cet article " & GunaDataGridViewDemandeIntervention.CurrentRow.Cells("CODE INTERVENTION").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewDemandeIntervention, GunaDataGridViewDemandeIntervention.CurrentRow.Cells("CODE INTERVENTION").Value.ToString, "demande_intervention", "CODE_DEMANDE_INTERVENTION")

                GunaDataGridViewDemandeIntervention.Columns.Clear()

                DemandeInterventionListATraiter()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.Close()
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

        getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY  ORDER BY DESIGNATION_FR ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ARTICLEFAMILY", MySqlDbType.VarChar).Value = "MAINTENANCE"
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

            If (Article.Rows.Count > 0) Then

                GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")

                GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")

                GunaDataGridViewArticle.Visible = False
            Else

                'We clear the article field if nothing is found when we click on the custom datagrid

            End If

            'connect.closeConnection()

        End If

    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Me.Close()
    End Sub

    'AJOUT D'EQUIPEMENT UTILISE
    Private Sub GunaButtonAjouterLigne_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click

        GunaDataGridViewLigneEquipement.Rows.Add(GunaTextBoxCodeArticle.Text, GunaTextBoxArticle.Text, GunaTextBoxQuantite.Text)
        GunaTextBoxArticle.Clear()
        GunaButtonAjouterLigne.Visible = False

    End Sub

    'liste des demandes d'interventions
    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        DemandeInterventionListATraiter()
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged

        GunaDataGridViewListeIntervention.Columns.Clear()
        GunaDataGridViewDemandeIntervention.Columns.Clear()

    End Sub

    'liste des bons d'inervention
    Private Sub GunaButtonIntervention_Click(sender As Object, e As EventArgs) Handles GunaButtonIntervention.Click
        InterventionListeTreated()
    End Sub

End Class