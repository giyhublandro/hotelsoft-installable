Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Room

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new ROOM
    Public Function Insert(ByVal CODE_CHAMBRE As String, ByVal CODE_TYPE_CHAMBRE As String, ByVal CODE_CATEGORY_CHAMBRE As String, ByVal LIBELLE_CHAMBRE As String, ByVal ETAT_CHAMBRE As Integer, ByVal ETAT_CHAMBRE_NOTE As String, ByVal LOCALISATION As String, ByVal NUM_COMPTE As String, ByVal PRIX As Double, ByVal FICITIF As Integer, ByVal LOCK_NO As String, ByVal GUEST_DAI As String, ByVal DATE_CREATION As Date, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `chambre`(`CODE_CHAMBRE`, `CODE_TYPE_CHAMBRE`, `CODE_CATEGORY_CHAMBRE`, `LIBELLE_CHAMBRE`, `ETAT_CHAMBRE`, `ETAT_CHAMBRE_NOTE`,`LOCALISATION`, `NUM_COMPTE`, `PRIX`, `FICITIF`, `LOCK_NO`, `GUEST_DAI`, `DATE_CREATION`, `CODE_AGENCE`) VALUES(@CODE_CHAMBRE, @CODE_TYPE_CHAMBRE, @CODE_CATEGORIE_CHAMBRE, @LIBELLE_CHAMBRE, @ETAT_CHAMBRE, @ETAT_CHAMBRE_NOTE, @LOCALISATION, @NUM_COMPTE, @PRIX, @FICITIF, @LOCK_NO, @GUEST_DAI, @DATE_CREATION, @CODE_AGENCE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@CODE_CATEGORIE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CATEGORY_CHAMBRE
        command.Parameters.Add("@LIBELLE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_CHAMBRE
        command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = ETAT_CHAMBRE
        command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = ETAT_CHAMBRE_NOTE
        command.Parameters.Add("@LOCALISATION", MySqlDbType.VarChar).Value = LOCALISATION
        command.Parameters.Add("@NUM_COMPTE", MySqlDbType.VarChar).Value = NUM_COMPTE
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX
        command.Parameters.Add("@FICITIF", MySqlDbType.Int32).Value = FICITIF
        command.Parameters.Add("@LOCK_NO", MySqlDbType.VarChar).Value = LOCK_NO
        command.Parameters.Add("@GUEST_DAI", MySqlDbType.VarChar).Value = GUEST_DAI
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE

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

    'Create a function to check if the Room already exists
    Public Function chambreExists(ByVal CODE_CHAMBRE As String, ByVal LIBELLE_CHAMBRE As String) As Boolean

        'Dim existQuery As String = "SELECT * From chambre WHERE CODE_CHAMBRE=@CODE_CHAMBRE OR LIBELLE_CHAMBRE=@LIBELLE_CHAMBRE"
        Dim existQuery As String = "SELECT * From chambre WHERE CODE_CHAMBRE=@CODE_CHAMBRE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@LIBELLE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_CHAMBRE

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

    'create a function to update the selected Room
    Public Function UpdateRoom(ByVal CODE_CHAMBRE As String, ByVal CODE_TYPE_CHAMBRE As String, ByVal CODE_CATEGORY_CHAMBRE As String, ByVal LIBELLE_CHAMBRE As String, ByVal ETAT_CHAMBRE As Integer, ByVal ETAT_CHAMBRE_NOTE As String, ByVal LOCALISATION As String, ByVal NUM_COMPTE As String, ByVal PRIX As Double, ByVal FICITIF As Integer, ByVal LOCK_NO As String, ByVal GUEST_DAI As String, ByVal NUM_AGENCE As String, ByVal OLD_CODE_CHAMBRE As String) As Boolean
        Dim updateQuery As String = "UPDATE chambre SET CODE_CHAMBRE=@CODE_CHAMBRE, CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE, CODE_CATEGORY_CHAMBRE=@CODE_CATEGORY_CHAMBRE,LIBELLE_CHAMBRE=@LIBELLE_CHAMBRE,ETAT_CHAMBRE=@ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE,LOCALISATION=@LOCALISATION, NUM_COMPTE=@NUM_COMPTE, PRIX=@PRIX, FICITIF=@FICITIF, LOCK_NO=@LOCK_NO, GUEST_DAI=@GUEST_DAI, CODE_AGENCE=@NUM_AGENCE WHERE CODE_CHAMBRE = @OLD_CODE_CHAMBRE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@OLD_CODE_CHAMBRE", MySqlDbType.VarChar).Value = OLD_CODE_CHAMBRE
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@CODE_CATEGORY_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CATEGORY_CHAMBRE
        command.Parameters.Add("@LIBELLE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_CHAMBRE
        command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = ETAT_CHAMBRE
        command.Parameters.Add("@LOCALISATION", MySqlDbType.VarChar).Value = LOCALISATION
        command.Parameters.Add("@NUM_COMPTE", MySqlDbType.VarChar).Value = NUM_COMPTE
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX
        command.Parameters.Add("@FICITIF", MySqlDbType.Int32).Value = FICITIF
        command.Parameters.Add("@LOCK_NO", MySqlDbType.VarChar).Value = LOCK_NO
        command.Parameters.Add("@GUEST_DAI", MySqlDbType.VarChar).Value = GUEST_DAI
        command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = ETAT_CHAMBRE_NOTE

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

    'Create a Function to return a company using its id
    Public Function getRoomById(ByVal ID_CHAMBRE As Integer) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT * chambre WHERE ID_CHAMBRE=@ID_CHAMBRE"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ID_CHAMBRE", MySqlDbType.Int32).Value = ID_CHAMBRE
        adapter.SelectCommand = Command
        adapter.Fill(table)

        Return table

    End Function

    'SALLE DE FETE MANAGEMENT 

    'insert a new ROOM
    Public Function Insert(ByVal CODE_CHAMBRE As String, ByVal CODE_TYPE_CHAMBRE As String, ByVal CODE_CATEGORY_CHAMBRE As String, ByVal LIBELLE_CHAMBRE As String, ByVal ETAT_CHAMBRE As Integer, ByVal ETAT_CHAMBRE_NOTE As String, ByVal LOCALISATION As String, ByVal NUM_COMPTE As String, ByVal PRIX As Double, ByVal FICITIF As Integer, ByVal LOCK_NO As String, ByVal GUEST_DAI As String, ByVal DATE_CREATION As Date, ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim insertQuery As String = "INSERT INTO `chambre`(`CODE_CHAMBRE`, `CODE_TYPE_CHAMBRE`, `CODE_CATEGORY_CHAMBRE`, `LIBELLE_CHAMBRE`, `ETAT_CHAMBRE`, `ETAT_CHAMBRE_NOTE`,`LOCALISATION`, `NUM_COMPTE`, `PRIX`, `FICITIF`, `LOCK_NO`, `GUEST_DAI`, `DATE_CREATION`, `CODE_AGENCE`, `TYPE`) VALUES(@CODE_CHAMBRE, @CODE_TYPE_CHAMBRE, @CODE_CATEGORIE_CHAMBRE, @LIBELLE_CHAMBRE, @ETAT_CHAMBRE, @ETAT_CHAMBRE_NOTE, @LOCALISATION, @NUM_COMPTE, @PRIX, @FICITIF, @LOCK_NO, @GUEST_DAI, @DATE_CREATION, @CODE_AGENCE, @TYPE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@CODE_CATEGORIE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CATEGORY_CHAMBRE
        command.Parameters.Add("@LIBELLE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_CHAMBRE
        command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = ETAT_CHAMBRE
        command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = ETAT_CHAMBRE_NOTE
        command.Parameters.Add("@LOCALISATION", MySqlDbType.VarChar).Value = LOCALISATION
        command.Parameters.Add("@NUM_COMPTE", MySqlDbType.VarChar).Value = NUM_COMPTE
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX
        command.Parameters.Add("@FICITIF", MySqlDbType.Int32).Value = FICITIF
        command.Parameters.Add("@LOCK_NO", MySqlDbType.VarChar).Value = LOCK_NO
        command.Parameters.Add("@GUEST_DAI", MySqlDbType.VarChar).Value = GUEST_DAI
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = TYPE

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

    'Create a function to check if the Room already exists
    Public Function roomStatistics() As DataTable

        Dim existQuery As String = "SELECT COUNT(CODE_CHAMBRE)*100.0 /(SELECT COUNT(*) From chambre WHERE chambre.TYPE=@TYPE) As 'Total', type_chambre.CODE_TYPE_CHAMBRE AS 'TYPE CHAMBRE' from chambre INNER JOIN type_chambre WHERE chambre.TYPE=@TYPE AND chambre.CODE_TYPE_CHAMBRE=type_chambre.CODE_TYPE_CHAMBRE GROUP BY type_chambre.CODE_TYPE_CHAMBRE ORDER BY CODE_CHAMBRE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    'Create a function to check if the Room already exists
    Public Function roomsOnly() As DataTable

        Dim existQuery As String = "SELECT * FROM chambre WHERE TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function sallesOnly() As DataTable

        Dim existQuery As String = "SELECT * FROM chambre WHERE TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function


    Public Function ActiveRoomsOnly() As DataTable

        Dim existQuery As String = "SELECT * FROM chambre WHERE TYPE=@TYPE AND ETAT_CHAMBRE= 0 OR TYPE=@TYPE AND ETAT_CHAMBRE= 1 ORDER BY CODE_CHAMBRE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function HSRoomsOnly() As DataTable

        Dim existQuery As String = "SELECT * FROM chambre WHERE TYPE=@TYPE AND ETAT_CHAMBRE_NOTE= @ETAT_CHAMBRE_NOTE ORDER BY CODE_CHAMBRE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
        command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.hors_service

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function roomDisponibilite() As DataTable

        Dim existQuery As String = "SELECT * From chambre WHERE TYPE=@TYPE GROUP BY CODE_TYPE_CHAMBRE ORDER BY CODE_CHAMBRE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function roomChangeL(ByVal i As Integer)

        If i = 0 Then
            'Free clean
            'Free dirty
            'Occupied clean
            'Occupied dirty
            'Reserved
            'Out of service

            Dim query As String = "UPDATE `chambre` SET `ETAT_CHAMBRE_NOTE` = 'Free clean' WHERE `ETAT_CHAMBRE_NOTE` = 'Libre propre'"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.ExecuteNonQuery()

            Dim query_ As String = "UPDATE `chambre` SET `ETAT_CHAMBRE_NOTE`= 'Free dirty' WHERE  `ETAT_CHAMBRE_NOTE` = 'Libre sale'"
            Dim command_ As New MySqlCommand(query_, GlobalVariable.connect)
            command_.ExecuteNonQuery()

            Dim query_1 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE_NOTE`= 'Occupied clean' WHERE  `ETAT_CHAMBRE_NOTE` = 'Occupée propre'"
            Dim command_1 As New MySqlCommand(query_1, GlobalVariable.connect)
            command_1.ExecuteNonQuery()

            Dim query_2 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE_NOTE`= 'Occupied dirty' WHERE  `ETAT_CHAMBRE_NOTE` = 'Occupée sale'"
            Dim command_2 As New MySqlCommand(query_2, GlobalVariable.connect)
            command_2.ExecuteNonQuery()

        ElseIf i = 1 Then

            Dim query As String = "UPDATE `chambre` SET `ETAT_CHAMBRE_NOTE` = 'Libre propre' WHERE `ETAT_CHAMBRE_NOTE` = 'Free clean'"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.ExecuteNonQuery()

            Dim query_ As String = "UPDATE `chambre` SET `ETAT_CHAMBRE_NOTE`= 'Libre sale' WHERE  `ETAT_CHAMBRE_NOTE` = 'Free dirty'"
            Dim command_ As New MySqlCommand(query_, GlobalVariable.connect)
            command_.ExecuteNonQuery()

            Dim query_1 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE_NOTE`= 'Occupée propre' WHERE  `ETAT_CHAMBRE_NOTE` = 'Occupied clean'"
            Dim command_1 As New MySqlCommand(query_1, GlobalVariable.connect)
            command_1.ExecuteNonQuery()

            Dim query_2 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE_NOTE`= 'Occupée sale' WHERE  `ETAT_CHAMBRE_NOTE` = 'Occupied dirty'"
            Dim command_2 As New MySqlCommand(query_2, GlobalVariable.connect)
            command_2.ExecuteNonQuery()

        End If

    End Function

End Class
