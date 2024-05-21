Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Evenement

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new entry
    Public Function insertEvent(ByVal CODE_EVENEMENT As String, ByVal LIBELLE As String, ByVal DATE_CREATION As Date, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `evenement`(`CODE_EVENEMENT`, `LIBELLE`, `DATE_CREATION`, `CODE_AGENCE`) VALUES (@value2, @value3, @value4, @value5)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_EVENEMENT
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value4", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_AGENCE

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    'create a function to update the selected reservation
    Public Function updateEvent(ByVal CODE_EVENEMENT As String, ByVal LIBELLE As String) As Boolean

        Dim updateQuery As String = "UPDATE `evenement` SET `LIBELLE`=@LIBELLE WHERE CODE_EVENEMENT=@CODE_EVENEMENT"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_EVENEMENT", MySqlDbType.VarChar).Value = CODE_EVENEMENT
        command.Parameters.Add("@LIBELLE", MySqlDbType.VarChar).Value = LIBELLE
        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    'Create a function to check if the username already exists
    Public Function eventExists(ByVal CODE_EVENEMENT As String, ByVal LIBELLE As String) As Boolean

        Dim existQuery As String = "SELECT * From evenement WHERE CODE_EVENEMENT=@CODE_EVENEMENT OR LIBELLE=@LIBELLE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_EVENEMENT", MySqlDbType.VarChar).Value = CODE_EVENEMENT
        command.Parameters.Add("@LIBELLE", MySqlDbType.VarChar).Value = LIBELLE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

End Class

