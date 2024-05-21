Imports MySql.Data.MySqlClient

Public Class CahierDeConsigneForm

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""
    Dim languageAction As String = ""

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonNouvelle.Click

        AjouterConsigneForm.Close()

        GunaTextBoxConsigneInfo.BaseColor = Color.White
        GunaTextBoxConsigneMessage.BaseColor = Color.White

        GunaButtonComment.Enabled = True

        GunaPictureBoxValidated.Visible = False

        GunaButtonValiderConsigne.Enabled = True

        GunaDataGridViewConsigneComment.Columns.Clear()

        GunaButtonValiderConsigne.Visible = False

        GunaTextBoxConsigneInfo.Clear()
        GunaTextBoxConsigneMessage.Clear()
        GunaTextBoxCodeConsigneSelectionne.Clear()

        GlobalVariable.AjouterConsigneFormRole = "Nouvelle"

        AjouterConsigneForm.Show()
        AjouterConsigneForm.TopMost = True

    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButtonComment.Click

        AjouterConsigneForm.Close()
        GlobalVariable.AjouterConsigneFormRole = "Commenter"
        AjouterConsigneForm.Show() ' Ajoute un commentaire à la consigne
        AjouterConsigneForm.TopMost = True

    End Sub

    Public Sub listeDesConsignes(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_CONSIGNE As Integer)

        Dim consigne As New Consigne()

        Dim lesConsignes As DataTable = consigne.listeDesConsignes(DateDebut, DateFin, ETAT_CONSIGNE)

        GunaDataGridViewConsigneList.Columns.Clear()

        If lesConsignes.Rows.Count > 0 Then

            GunaDataGridViewConsigneList.DataSource = lesConsignes
            GunaDataGridViewConsigneList.Columns("CODE_CONSIGNE").Visible = False
            GunaDataGridViewConsigneList.Columns("ETAT_CONSIGNE").Visible = False

        End If

    End Sub

    Private Sub CahierDeConsigneForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.cahierDeConsigne(GlobalVariable.actualLanguageValue)

        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail
        Dim ETAT_CONSIGNE As Integer = 0

        listeDesConsignes(DateDebut, DateFin, ETAT_CONSIGNE)

        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail.ToShortDateString
        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail.ToShortDateString

    End Sub

    'modification des commentaire d'une consigne
    Private Sub GunaDataGridViewConsigneComment_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewConsigneComment.CellDoubleClick, GunaDataGridViewConsigneMessage.CellDoubleClick

    End Sub

    'Modification des consignes

    Dim CODE_CONSIGNE As String = ""
    Private Sub GunaDataGridViewConsigneList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewConsigneList.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaDataGridViewConsigneComment.Columns.Clear()

            Dim consigne As New Consigne()

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewConsigneList.Rows(e.RowIndex)

            CODE_CONSIGNE = Trim(row.Cells("CODE_CONSIGNE").Value.ToString)

            GunaTextBoxCodeConsigneSelectionne.Text = CODE_CONSIGNE

            Dim commentaireDUneConsigne As DataTable = consigne.listeDesCommentaireDuneConsigne(CODE_CONSIGNE)

            GunaDataGridViewConsigneMessage.Rows.Clear()

            If GlobalVariable.actualLanguageValue = 0 Then
                languageAction = "Instruction N°: " & row.Cells("NUMBER").Value.ToString & " from " & row.Cells("DATE & TIME").Value.ToString & " by " & row.Cells("AUTHOR").Value.ToString
                GunaTextBoxConsigneMessage.Text = row.Cells("INSTRUCTION").Value.ToString

                GunaDataGridViewConsigneMessage.Rows.Add(row.Cells("INSTRUCTION").Value.ToString)
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageAction = "Consigne N°: " & row.Cells("NUMERO").Value.ToString & " du " & row.Cells("DATE & HEURE").Value.ToString & " par " & row.Cells("AUTEUR").Value.ToString
                GunaTextBoxConsigneMessage.Text = row.Cells("CONSIGNE").Value.ToString

                GunaDataGridViewConsigneMessage.Rows.Add(row.Cells("CONSIGNE").Value.ToString)
            End If

            GunaTextBoxConsigneInfo.Text = languageAction

            GunaDataGridViewConsigneMessage.Rows(0).Height = 600

            GunaDataGridViewConsigneMessage.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            GunaDataGridViewConsigneMessage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft

            Dim ETAT_CONSIGNE As Integer = 0

            Integer.TryParse(Trim(row.Cells("ETAT_CONSIGNE").Value.ToString), ETAT_CONSIGNE)

            If ETAT_CONSIGNE = 1 Then

                GunaTextBoxConsigneInfo.Enabled = False
                GunaTextBoxConsigneMessage.Enabled = False
                GunaDataGridViewConsigneComment.Enabled = False
                GunaButtonComment.Visible = False

                GunaTextBoxConsigneInfo.BaseColor = Color.LightGray
                GunaTextBoxConsigneMessage.BaseColor = Color.LightGray

                GunaButtonValiderConsigne.Visible = False

                GunaPictureBoxValidated.Visible = True

                GunaButtonValiderConsigne.Enabled = False
                GunaButtonValiderConsigne.Visible = False

            Else

                GunaTextBoxConsigneInfo.BaseColor = Color.White
                GunaTextBoxConsigneMessage.BaseColor = Color.White

                'GunaTextBoxConsigneInfo.Enabled = True
                'GunaTextBoxConsigneMessage.Enabled = True
                GunaDataGridViewConsigneComment.Enabled = True
                GunaButtonComment.Enabled = True
                GunaButtonComment.Visible = True

                GunaButtonValiderConsigne.Visible = True

                GunaPictureBoxValidated.Visible = False

                GunaButtonValiderConsigne.Enabled = True

            End If

            If commentaireDUneConsigne.Rows.Count > 0 Then

                GunaDataGridViewConsigneComment.Columns.Clear()

                GunaDataGridViewConsigneComment.DataSource = commentaireDUneConsigne

            End If

        End If

    End Sub

    'Filtrer les consignes 
    Private Sub GunaButtonFiltrer_Click(sender As Object, e As EventArgs) Handles GunaButtonFiltrer.Click

        GunaDataGridViewConsigneList.Columns.Clear()

        Dim consigne As New Consigne()

        Dim Auteur As String = ""

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToShortDateString
        Dim DateFin As Date = GunaDateTimePickerFin.Value.ToShortDateString
        Dim ETAT_CONSIGNE As Integer = 0

        If GunaCheckBoxFait.Checked Then
            ETAT_CONSIGNE = 1
        End If

        listeDesConsignes(DateDebut, DateFin, ETAT_CONSIGNE)

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButtonSupprimerConsigne.Click

        Dim consigne As New Consigne()

        If GunaDataGridViewConsigneList.Rows.Count > 0 Then

            GunaDataGridViewConsigneComment.Columns.Clear()

            GunaButtonValiderConsigne.Visible = False

            GunaTextBoxConsigneInfo.Clear()
            GunaTextBoxConsigneMessage.Clear()
            GunaTextBoxCodeConsigneSelectionne.Clear()

            Dim DeleteRow As Boolean = False
            Dim rowToDelete As String = GunaDataGridViewConsigneList.CurrentRow.Cells("CODE_CONSIGNE").Value.ToString

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Do you really want to delete the instruction "
                languageTitle = "Delete Instruction"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Voulez-vous vraiment Supprimer cette consigne "
                languageTitle = "Suppression de Consigne"
            End If

            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                DeleteRow = True

            End If

            If DeleteRow Then

                Dim ETAT_CONSIGNE As Integer = 0

                If GunaCheckBoxFait.Checked Then
                    ETAT_CONSIGNE = 1
                End If

                Functions.DeleteRowFromDataGrid(GunaDataGridViewConsigneList, rowToDelete, "cahier_consigne", "CODE_CONSIGNE")

                Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToShortDateString
                Dim DateFin As Date = GunaDateTimePickerFin.Value.ToShortDateString

                listeDesConsignes(DateDebut, DateFin, ETAT_CONSIGNE)

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Instruction deleted successfully "
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Vous avez supprimé avec succès"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "No Instruction to be deleted !"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Aucune Consigne à supprimer !"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    'DESACTIVATION DE LA CONSIGNE
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonValiderConsigne.Click

        Dim consigne As New Consigne()

        Dim ETAT_CONSIGNE As Integer = 1
        Dim CODE_CONSIGNE As String = Trim(GunaTextBoxCodeConsigneSelectionne.Text)

        consigne.validationDeLaConsigne(ETAT_CONSIGNE, CODE_CONSIGNE)

        GunaTextBoxConsigneInfo.Enabled = False
        GunaTextBoxConsigneInfo.BaseColor = Color.LightGray
        GunaTextBoxConsigneMessage.BaseColor = Color.LightGray
        GunaTextBoxConsigneMessage.Enabled = False

        GunaDataGridViewConsigneComment.Enabled = False

        GunaButtonComment.Enabled = False

        GunaButtonValiderConsigne.Enabled = False

        GunaPictureBoxValidated.Visible = True

        GunaTextBoxCodeConsigneSelectionne.Text = CODE_CONSIGNE

        Dim commentaireDUneConsigne As DataTable = consigne.listeDesCommentaireDuneConsigne(CODE_CONSIGNE)

        If ETAT_CONSIGNE = 1 Then

            GunaTextBoxConsigneInfo.Enabled = False
            GunaTextBoxConsigneMessage.Enabled = False
            GunaDataGridViewConsigneComment.Enabled = False
            GunaButtonComment.Enabled = False

            GunaTextBoxConsigneInfo.BaseColor = Color.LightGray
            GunaTextBoxConsigneMessage.BaseColor = Color.LightGray

            GunaButtonValiderConsigne.Visible = False

            GunaPictureBoxValidated.Visible = True

            GunaButtonValiderConsigne.Enabled = False

        Else

            GunaTextBoxConsigneInfo.BaseColor = Color.White
            GunaTextBoxConsigneMessage.BaseColor = Color.White

            GunaTextBoxConsigneInfo.Enabled = True
            GunaTextBoxConsigneMessage.Enabled = True
            GunaDataGridViewConsigneComment.Enabled = True
            GunaButtonComment.Enabled = True

            GunaButtonValiderConsigne.Visible = True

            GunaPictureBoxValidated.Visible = False

            GunaButtonValiderConsigne.Enabled = True

        End If

        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail

        If commentaireDUneConsigne.Rows.Count > 0 Then

            GunaDataGridViewConsigneComment.Columns.Clear()

            GunaDataGridViewConsigneComment.DataSource = commentaireDUneConsigne

        End If

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "Instruction donne"
            languageTitle = "Instruction"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Consigne Faite"
            languageTitle = "Consigne"
        End If

        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        ETAT_CONSIGNE = 0

        If GunaCheckBoxFait.Checked Then
            ETAT_CONSIGNE = 1
        End If

        listeDesConsignes(DateDebut, DateFin, ETAT_CONSIGNE)

        MainWindow.GunaLabelNombreDeConsigne.Text = "(" & Functions.alerteConsignes() & ")"

    End Sub

End Class