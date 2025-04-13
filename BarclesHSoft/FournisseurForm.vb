Imports MySql.Data.MySqlClient

Public Class FournisseurForm

    'Dim connect As New DataBaseManipulation()

    Private Sub FournisseurForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim langue As New Languages()
        langue.fournisseur(GlobalVariable.actualLanguageValue)

    End Sub

    Private Sub GunaImageButton4_Click_1(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub listeDesFournisseurs()

        'REFRESHING information from database for instant visualisation 
        Dim query As String = "SELECT `ID_FOURNISSEUR`, `CODE_FOURNISSEUR` AS 'CODE FOURNISSEUR', `NOM_FOURNISSEUR` AS 'NOM FOURNISSEUR', `POURCENTAGE_REMISE` AS 'POURCENTAGE REMISE', `ADRESSE`, `TELEPHONE`, `FAX`,
        `NUMERO_COMPTE` AS 'NUMERO COMPTE', `DATE_CREATION` As 'DATE_CREATION' FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = GlobalVariable.prestaire_fournisseur

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewFournisseurs.DataSource = table
            GunaDataGridViewFournisseurs.Columns(0).Visible = False
            GunaDataGridViewFournisseurs.Columns(1).Visible = False
            GunaDataGridViewFournisseurs.Rows(0).Selected = True
        Else
            GunaDataGridViewFournisseurs.Columns.Clear()
        End If



    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim fournisseur As New Economat()

        Dim NOM_FOURNISSEUR = GunaTextBoxRaisonSociale.Text
        Dim CODE_FOURNISSEUR = Functions.GeneratingRandomCode("fournisseur", "")
        Dim remise As Double
        Double.TryParse(GunaTextBoxPourcentageRemise.Text, remise)
        Dim POURCENTAGE_REMISE = remise
        Dim ADRESSE = GunaTextBoxAdresse.Text
        Dim TELEPHONE = GunaTextBoxPhone.Text
        Dim FAX = GunaTextBoxfax.Text
        Dim NUMERO_COMPTE = GunaTextBoxMail.Text
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim BLANCHISSEUR = 0

        If GunaCheckBoxBlanchisseur.Checked Then
            BLANCHISSEUR = 1
        End If

        If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then

            CODE_FOURNISSEUR = GunaTextBoxCodeFournisseur.Text

            If fournisseur.updateFournisseur(NOM_FOURNISSEUR, CODE_FOURNISSEUR, POURCENTAGE_REMISE, ADRESSE, TELEPHONE, FAX, NUMERO_COMPTE, CODE_AGENCE, BLANCHISSEUR) Then
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Fournisseur / Prestataire mise à jour avec succès", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Supplier / Prestataire successfully updated", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Un problème lors de la mise à jour du fournisseur", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("A problem during updating", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrer.Text = "Enregistrer"
            Else
                GunaButtonEnregistrer.Text = "Create"
            End If

            Functions.SiplifiedClearTextBox(Me)

        ElseIf GunaButtonEnregistrer.Text = "Enregistrer" Or GunaButtonEnregistrer.Text = "Save" Then

            If Not Trim(GunaTextBoxRaisonSociale.Text).Equals("") Then

                fournisseur.insertFournisseur(NOM_FOURNISSEUR, CODE_FOURNISSEUR, POURCENTAGE_REMISE, ADRESSE, TELEPHONE, FAX, NUMERO_COMPTE, CODE_AGENCE, BLANCHISSEUR)

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Nouveau fournisseur / Prestataire crée avec succès", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("New supplier / Prestataire added successfully", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Functions.SiplifiedClearTextBox(Me)

            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Entrer la raison sociale ou le nom du fournisseur !!!", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("The name can not be empty !!!", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        End If

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        listeDesFournisseurs()
    End Sub

    Private Sub GunaDataGridViewFournisseurs_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewFournisseurs.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow
            row = Me.GunaDataGridViewFournisseurs.Rows(e.RowIndex)
            Dim CODE_FOURNISSEUR As String = ""
            CODE_FOURNISSEUR = row.Cells(1).Value.ToString

            Dim infoSup As DataTable = Functions.getElementByCode(CODE_FOURNISSEUR, "fournisseur", "CODE_FOURNISSEUR")

            If infoSup.Rows.Count > 0 Then

                GunaTextBoxRaisonSociale.Text = infoSup.Rows(0)("NOM_FOURNISSEUR")
                GunaTextBoxCodeFournisseur.Text = infoSup.Rows(0)("CODE_FOURNISSEUR")
                GunaTextBoxPourcentageRemise.Text = infoSup.Rows(0)("POURCENTAGE_REMISE")
                GunaTextBoxAdresse.Text = infoSup.Rows(0)("ADRESSE")
                GunaTextBoxPhone.Text = infoSup.Rows(0)("TELEPHONE")
                GunaTextBoxfax.Text = infoSup.Rows(0)("FAX")
                GunaTextBoxMail.Text = infoSup.Rows(0)("NUMERO_COMPTE")

                If infoSup.Rows(0)("BLANCHISSEUR") = 1 Then
                    GunaCheckBoxBlanchisseur.Checked = True
                Else
                    GunaCheckBoxBlanchisseur.Checked = False
                End If

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonEnregistrer.Text = "Sauvegarder"
                Else
                    GunaButtonEnregistrer.Text = "Update"
                End If

                TabControl1.SelectedIndex = 0

            End If

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 1 Then
            listeDesFournisseurs()
        End If

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewFournisseurs.CurrentRow.Selected Then

            Dim ID_FOURNISSEUR As Integer = GunaDataGridViewFournisseurs.CurrentRow.Cells("ID_FOURNISSEUR").Value
            Dim NOM_FOURNISSEUR As String = GunaDataGridViewFournisseurs.CurrentRow.Cells(2).Value.ToString()
            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Do you really want to delete " & NOM_FOURNISSEUR
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Voulez-vous vraiment Supprimer " & NOM_FOURNISSEUR
                languageTitle = "Suppression"
            End If

            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.Yes Then

                Functions.DeleteElementByCode(ID_FOURNISSEUR, "fournisseur", "ID_FOURNISSEUR")

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = NOM_FOURNISSEUR & " successfully deleted "
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = NOM_FOURNISSEUR & " supprimé avec succès "
                    languageTitle = "Suppression"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                listeDesFournisseurs()

            End If

        End If

    End Sub

End Class