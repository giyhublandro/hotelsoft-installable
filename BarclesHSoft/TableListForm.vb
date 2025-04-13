Imports MySql.Data.MySqlClient

Public Class TableListForm

    Private Sub GunaButtonAjouterLigne_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click

        Dim n As Integer = NumericUpDown1.Value
        Dim m As Integer = NumericUpDown2.Value

        Dim name As String = ""
        Dim TABLE_NAME As String = ""

        For i = n To m

            name = GunaTextBox1.Text

            If i < 10 Then
                TABLE_NAME = name & "0" & i
            Else
                TABLE_NAME = name & "" & i
            End If

            Dim insertQuery As String = "INSERT INTO `tables`(`TABLE_NAME`) VALUES (@TABLE_NAME)"

            Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

            command.Parameters.Add("@TABLE_NAME", MySqlDbType.VarChar).Value = TABLE_NAME
            command.ExecuteNonQuery()

        Next

        tableList()

    End Sub

    Public Sub tableList()

        Dim query4 = "SELECT * FROM `tables`"

        Dim command4 As New MySqlCommand(query4, GlobalVariable.connect)

        Dim adapter4 As New MySqlDataAdapter(command4)
        Dim dt As New DataTable()
        adapter4.Fill(dt)

        If dt.Rows.Count > 0 Then
            GunaDataGridViewBarRestaurant.DataSource = dt
            GunaDataGridViewBarRestaurant.Columns(0).Visible = False
        Else
            dt = Nothing
        End If

    End Sub

    Private Sub TableListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tableList()
    End Sub

End Class