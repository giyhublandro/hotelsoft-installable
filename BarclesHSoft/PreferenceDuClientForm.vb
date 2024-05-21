Public Class PreferenceDuClientForm
    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub PreferenceDuClientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listeDesPreferences()

    End Sub

    Private Sub listeDesPreferences()

        Dim CODE_CLIENT As String = MainWindow.GunaTextBoxRefClient.Text

        Dim preferences As DataTable = Functions.allTableFieldsOnConditionOrganised("prefernces_du_client", "CODE_CLIENT", CODE_CLIENT, "PREFERENCE")

        GunaDataGridViewPreferences.Columns.Clear()

        If preferences.Rows.Count > 0 Then

            GunaDataGridViewPreferences.DataSource = preferences

            GunaDataGridViewPreferences.Columns("ID_PREF_CLIENT").Visible = False
            GunaDataGridViewPreferences.Columns("CODE_PREFERENCE").Visible = False
            GunaDataGridViewPreferences.Columns("CODE_CLIENT").Visible = False

        End If


    End Sub

    Private Sub GunaButtonAjoutPreference_Click(sender As Object, e As EventArgs) Handles GunaButtonAjoutPreference.Click

        Dim CODE_CLIENT As String = MainWindow.GunaTextBoxRefClient.Text
        Dim PREFERENCE As String = GunaTextBoxPreference.Text
        Dim CODE_PREFERENCE As String = Functions.GeneratingRandomCodeWithSpecifications("prefernces_du_client", "")

        Dim preferenceDuClient As New Client()

        preferenceDuClient.insertPreferences(CODE_CLIENT, PREFERENCE, CODE_PREFERENCE)

        MessageBox.Show("Préférence ajoutée avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        listeDesPreferences()

        GunaTextBoxPreference.Text = ""

    End Sub

End Class