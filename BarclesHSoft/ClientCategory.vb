Imports System.IO
Imports MySql.Data.MySqlClient

Public Class CilentCategory

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new client Catgeory
    Public Function insertClienCategory(ByVal CODE_TYPE_CLIENT As String, ByVal LIBELLE As String, ByVal PAIE_TAXE_SEJOUR As Integer, ByVal DATE_CREATION As Date, ByVal TAUX_EXONERATION_TVA As Double, ByVal POURCENTAGE_REMISE As Double, ByVal POURCENTAGE_RISTOURNE As Double, ByVal CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `categorie_client`(`CODE_TYPE_CLIENT`, `LIBELLE`, `PAIE_TAXE_SEJOUR`, `DATE_CREATION`, `TAUX_EXONERATION_TVA`, `POURCENTAGE_REMISE`, `POURCENTAGE_RISTOURNE`, `CODE_UTILISATEUR`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_TYPE_CLIENT
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value3", MySqlDbType.Int32).Value = PAIE_TAXE_SEJOUR
        command.Parameters.Add("@value4", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = TAUX_EXONERATION_TVA
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = POURCENTAGE_RISTOURNE
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
    Public Function clientCategoryExists(ByVal CODE_TYPE_CLIENT As String, ByVal LIBELLE As String) As Boolean

        Dim existQuery As String = "SELECT * From categorie_client WHERE CODE_TYPE_CLIENT=@CODE_TYPE_CLIENT OR LIBELLE=@LIBELLE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TYPE_CLIENT", MySqlDbType.VarChar).Value = CODE_TYPE_CLIENT
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
    Public Function updateClientCategory(ByVal CODE_TYPE_CLIENT As String, ByVal LIBELLE As String, ByVal PAIE_TAXE_SEJOUR As Integer, ByVal DATE_CREATION As Date, ByVal TAUX_EXONERATION_TVA As Double, ByVal POURCENTAGE_REMISE As Double, ByVal POURCENTAGE_RISTOURNE As Double, ByVal CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "UPDATE `categorie_client` SET `CODE_TYPE_CLIENT`=@value2,`LIBELLE`=@value3,`PAIE_TAXE_SEJOUR`=@value4,`DATE_CREATION`=@value5,`TAUX_EXONERATION_TVA`=@value6,`POURCENTAGE_REMISE`=@value7,`POURCENTAGE_RISTOURNE`=@value8,`CODE_UTILISATEUR`=@value9  WHERE CODE_TYPE_CLIENT=@CODE_TYPE_CLIENT"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_TYPE_CLIENT
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value4", MySqlDbType.Int32).Value = PAIE_TAXE_SEJOUR
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = TAUX_EXONERATION_TVA
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = POURCENTAGE_RISTOURNE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CODE_TYPE_CLIENT", MySqlDbType.VarChar).Value = CODE_TYPE_CLIENT

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

    'Create a Function to return a user using his id
    Public Function getUserById(ByVal ID_TYPE_CLIENT As Integer) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT * type_client WHERE ID_TYPE_CLIENT=@ID_TYPE_CLIENT"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ID_TYPE_CLIENT", MySqlDbType.Int32).Value = ID_TYPE_CLIENT
        adapter.SelectCommand = Command
        adapter.Fill(table)

        Return table

    End Function

End Class
