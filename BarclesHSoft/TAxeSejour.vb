Imports System.IO
Imports MySql.Data.MySqlClient

Public Class TAxeSejour

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new client Catgeory
    Public Function insertHotelCategory(ByVal CODE_CATEGORIE_HOTEL As String, ByVal LIBELLE As String, ByVal MONTANT_TAXE As Double, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `category_hotel_taxe_sejour_collectee` (`CODE_CATEGORIE_HOTEL`, `LIBELLE`, `MONTANT_TAXE`, `DATE_CREATION`,  `CODE_UTILISATEUR`) VALUES (@value1,@value2,@value3,@value4,@value8)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_CATEGORIE_HOTEL
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@value4", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

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
    Public Function hotelCategoryExists(ByVal CODE_CATEGORIE_HOTEL As String, ByVal LIBELLE As String) As Boolean

        Dim existQuery As String = "SELECT * From category_hotel_taxe_sejour_collectee WHERE CODE_CATEGORIE_HOTEL=@CODE_CATEGORIE_HOTEL OR LIBELLE=@LIBELLE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_CATEGORIE_HOTEL", MySqlDbType.VarChar).Value = CODE_CATEGORIE_HOTEL
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

    'create a function to update the selected user
    Public Function updateHotelCategory(ByVal CODE_CATEGORIE_HOTEL As String, ByVal LIBELLE As String, ByVal MONTANT_TAXE As Double) As Boolean

        Dim insertQuery As String = "UPDATE `category_hotel_taxe_sejour_collectee` SET `CODE_CATEGORIE_HOTEL`=@value2,`LIBELLE`=@value3,`MONTANT_TAXE`=@value4  WHERE CODE_CATEGORIE_HOTEL=@CODE_CATEGORIE_HOTEL"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_CATEGORIE_HOTEL
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@CODE_CATEGORIE_HOTEL", MySqlDbType.VarChar).Value = CODE_CATEGORIE_HOTEL

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

End Class
