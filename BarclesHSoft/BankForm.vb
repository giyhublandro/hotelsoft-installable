Imports System.IO
Imports MySql.Data.MySqlClient


Public Class BankForm
    Private Sub BankForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.banque(GlobalVariable.actualLanguageValue)

        listeDesBanques()
        TabControl1.SelectedIndex = 1
        'GunaLabelGestCompteGeneraux.Text = "LISTES DES BANQUES"

    End Sub

    Private Sub GunaImageButton3_Click(sender As Object, e As EventArgs) Handles GunaImageButton3.Click
        Close()
    End Sub

    Public Sub listeDesBanques()

        Dim query As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            query = "SELECT `CODE_BANQUE`, `NOM_BANQUE` AS BANK, `NUMERO_COMPTE` AS 'ACCOUNT', `TELEPHONE`, `ADRESSE` AS ADDRESS, `EMAIL`, `FAX` From banque ORDER BY NOM_BANQUE ASC"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            query = "SELECT `CODE_BANQUE`, `NOM_BANQUE` AS BANQUE, `NUMERO_COMPTE` AS 'COMPTE', `TELEPHONE`, `ADRESSE`, `EMAIL`, `FAX` From banque ORDER BY NOM_BANQUE ASC"
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaDataGridViewBanqueListe.DataSource = table

            GunaDataGridViewBanqueListe.Columns("CODE_BANQUE").Visible = False

        Else
            GunaDataGridViewBanqueListe.Columns.Clear()
        End If


    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerBanque.Click

        Dim banque As New Banque()

        Dim CODE_BANQUE As String = GunaTextBoxCodeBanque.Text
        Dim NOM_BANQUE As String = GunaTextBoxNom.Text
        Dim NUMERO_COMPTE As String = GunaTextBoxNumCompteBanque.Text
        Dim TELEPHONE As String = GunaTextBoxPhone.Text
        Dim ADRESSE As String = GunaTextBoxAdresse.Text
        Dim EMAIL As String = GunaTextBoxEmail.Text
        Dim FAX As String = GunaTextBoxFax.Text
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        If GunaButtonEnregistrerBanque.Text = "Sauvegarder" Or GunaButtonEnregistrerBanque.Text = "Save" Then

            Functions.DeleteElementOnTwoConditions(CODE_BANQUE, "banque", "CODE_BANQUE", "CODE_AGENCE", CODE_AGENCE)

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Bank successfully updated !"
                languageTitle = "BANK"
                GunaButtonEnregistrerBanque.Text = "Add"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Banque mise à jours avec succès !"
                languageTitle = "BANQUE"
                GunaButtonEnregistrerBanque.Text = "Enregistrer"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            CODE_BANQUE = Functions.GeneratingRandomCodePanne("banque", "BQ")

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Bank successfully created !"
                languageTitle = "BANK"
                GunaButtonEnregistrerBanque.Text = "Add"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Banque créee avec succès !"
                languageTitle = "BANQUE"
                GunaButtonEnregistrerBanque.Text = "Enregistrer"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        banque.insertBanque(CODE_BANQUE, NOM_BANQUE, NUMERO_COMPTE, TELEPHONE, ADRESSE, EMAIL, FAX, CODE_AGENCE)

        Functions.SiplifiedClearTextBox(Me)

        listeDesBanques()

        TabControl1.SelectedIndex = 1

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 1 Then

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaLabelGestCompteGeneraux.Text = "BANKS LIST"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelGestCompteGeneraux.Text = "LISTE DES BANQUES"
            End If

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaLabelGestCompteGeneraux.Text = "BANK CREATION / EDITING"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelGestCompteGeneraux.Text = "CREATION / EDITION DE BANQUE"
            End If
        End If
    End Sub

    Private Sub GunaDataGridViewBanqueListe_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBanqueListe.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewBanqueListe.Rows(e.RowIndex)

            Dim CODE_BANQUE As String = row.Cells("CODE_BANQUE").Value.ToString()
            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
            TabControl1.SelectedIndex = 0

            Dim banque As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_BANQUE, "banque", "CODE_BANQUE", CODE_AGENCE, "CODE_AGENCE")

            If banque.Rows.Count > 0 Then

                GunaTextBoxCodeBanque.Text = banque.Rows(0)("CODE_BANQUE")
                GunaTextBoxNom.Text = banque.Rows(0)("NOM_BANQUE")
                GunaTextBoxNumCompteBanque.Text = banque.Rows(0)("NUMERO_COMPTE")
                GunaTextBoxAdresse.Text = banque.Rows(0)("ADRESSE")
                GunaTextBoxPhone.Text = banque.Rows(0)("TELEPHONE")
                GunaTextBoxFax.Text = banque.Rows(0)("FAX")
                GunaTextBoxEmail.Text = banque.Rows(0)("EMAIL")

                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaButtonEnregistrerBanque.Text = "Save"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonEnregistrerBanque.Text = "Sauvegarder"
                End If

            End If

        End If

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewBanqueListe.Rows.Count > 0 Then

            Dim NOM_BANQUE As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                NOM_BANQUE = GunaDataGridViewBanqueListe.CurrentRow.Cells("BANK").Value.ToString
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                NOM_BANQUE = GunaDataGridViewBanqueListe.CurrentRow.Cells("BANQUE").Value.ToString
            End If

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Dou you really want to delete " & NOM_BANQUE
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Voulez-vous vraiment Supprimer " & NOM_BANQUE
                languageTitle = "Suppression"
            End If

            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewBanqueListe, GunaDataGridViewBanqueListe.CurrentRow.Cells("CODE_BANQUE").Value.ToString, "banque", "CODE_BANQUE")

                GunaDataGridViewBanqueListe.Columns.Clear()

                listeDesBanques()

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Deleted successfully"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Vous avez supprimé avec succès"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Nothing to be deleted !"
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Aucune ligne à suprimer !"
                languageTitle = "Supression"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

End Class