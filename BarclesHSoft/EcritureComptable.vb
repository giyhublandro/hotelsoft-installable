Imports MySql.Data.MySqlClient

Public Class EcritureComptable

    'INSERTION D'UN NOUVEAU NUMERO DE COMPTE DANS LE PLAN 

    Public Function InsertCompte(ByVal COMPTE As String, ByVal INTITULE As String) As Boolean


        Dim Inserting As String = "INSERT INTO `plan_comptable`(`COMPTE`, `INTITULE`) VALUES (@COMPTE,@INTITULE)"

        Dim command As New MySqlCommand(Inserting, GlobalVariable.connect)

        command.Parameters.Add("@COMPTE", MySqlDbType.VarChar).Value = COMPTE
        command.Parameters.Add("@INTITULE", MySqlDbType.VarChar).Value = INTITULE

        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Sub compteDeClasseSpecifiqueDuPlan(ByVal classDuCompte As String, ByVal compteListe As ComboBox)

        Dim query As String = "SELECT COMPTE, INTITULE FROM plan_comptable WHERE COMPTE LIKE '" & classDuCompte & "%' ORDER BY COMPTE ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            compteListe.DataSource = table
            compteListe.ValueMember = "COMPTE"
            'compteListe.DisplayMember = "COMPTE" & " - " & "INTITULE"
            compteListe.DisplayMember = "INTITULE"

        End If

    End Sub

End Class
