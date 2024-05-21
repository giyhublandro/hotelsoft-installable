Imports MySql.Data.MySqlClient

Public Class MainCouranteGenerale

    'Dim connect As New DataBaseManipulation()

    Private Sub MainCouranteGenerale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaLabelDateMainCourante.Text = GunaDateTimePickerDebut.Value.ToString()
    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    'Live search implementation
    Private Sub GunaTextBoxLiveSearch_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxLiveSearch.TextChanged

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToString("yyyy-MM-dd")

        'On affiche toutes les main_courante_generale correspondant a la date saisie
        Dim query As String = "SELECT NOM_CLIENT As 'NOM DU CLIENT' FROM main_Courante_generale WHERE NOM_CLIENT LIKE '%" & GunaTextBoxLiveSearch.Text & "%' AND DATE_MAIN_COURANTE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE <='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY NOM_CLIENT ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            DataGridViewMainCouranteReception.DataSource = table
        Else
            DataGridViewMainCouranteReception.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    'Click so as to output the main_courante_journaliere based on the typed date

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT NOM_CLIENT As 'NOM CLIENT' FROM main_courante_journaliere WHERE DATE_MAIN_COURANTE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE <='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY ID_MAIN_COURANTE_JOURNALIERE DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewMainCouranteReception.DataSource = table

        Else

            DataGridViewMainCouranteReception.Columns.Clear()

        End If

        'connect.closeConnection()

    End Sub

    'When the field gains focus
    Private Sub GunaTextBoxLiveSearch_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxLiveSearch.Enter

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT NOM_CLIENT As 'NOM CLIENT' FROM main_courante_journaliere WHERE DATE_MAIN_COURANTE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE <='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY NOM_CLIENT ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewMainCouranteReception.DataSource = table

        Else

            DataGridViewMainCouranteReception.Columns.Clear()

        End If

        'connect.closeConnection()

    End Sub

End Class