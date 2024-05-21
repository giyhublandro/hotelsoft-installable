Imports System.IO
Imports MySql.Data.MySqlClient

Public Class RoomType

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new ROOM TYPE
    Public Function Insert(ByVal LIBELLE_TYPE_CHAMBRE As String, ByVal DESCRIPTION As String, ByVal PRIX As Integer, ByVal CODE_TYPE_CHAMBRE As String, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal DATE_MODIFICATION As Date, ByVal TAUX_CHARGE_FIXE As Double, ByVal CODE_AGENCE As String, Optional ByVal SUPERFICIE As Double = 0, Optional ByVal CAPACITE As Double = 0, Optional ByVal CODE_TYPE As String = "chambre") As Boolean

        Dim insertQuery As String = "INSERT INTO `type_chambre` (`LIBELLE_TYPE_CHAMBRE`, `DESCRIPTION`, `PRIX`, `CODE_TYPE_CHAMBRE`, `DATE_CREATION`, `CODE_UTILISATEUR_MODIF`, `DATE_MODIFICATION`, `TAUX_CHARGE_FIXE`, `CODE_AGENCE`, `SUPERFICIE`, `CAPACITE`,`TYPE`) VALUES (@LIBELLE_TYPE_CHAMBRE, @DESCRIPTION, @PRIX, @CODE_TYPE_CHAMBRE, @DATE_CREATION, @CODE_UTILISATEUR_MODIF, @DATE_MODIFICATION, @TAUX_CHARGE_FIXE, @CODE_AGENCE,@SUPERFICIE,@CAPACITE,@TYPE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@LIBELLE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_TYPE_CHAMBRE
        command.Parameters.Add("@DESCRIPTION", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@CODE_UTILISATEUR_MODIF", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@DATE_MODIFICATION", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = CODE_TYPE
        command.Parameters.Add("@SUPERFICIE", MySqlDbType.Double).Value = SUPERFICIE
        command.Parameters.Add("@CAPACITE", MySqlDbType.Double).Value = CAPACITE
        command.Parameters.Add("@TAUX_CHARGE_FIXE", MySqlDbType.Double).Value = TAUX_CHARGE_FIXE

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


    'insert a new ROOM TYPE on start up
    Public Function InsertOnStartUp(ByVal LIBELLE_TYPE_CHAMBRE As String, ByVal PRIX As Double, ByVal CODE_TYPE_CHAMBRE As String, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_AGENCE As String, ByVal NOMBRE_LIT_UNE_PLACE As Integer, ByVal NOMBRE_LIT_DEUX_PLACES As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `type_chambre` (`LIBELLE_TYPE_CHAMBRE`, `PRIX`, `CODE_TYPE_CHAMBRE`, `DATE_CREATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`, `NOMBRE_LIT_UNE_PLACE`, `NOMBRE_LIT_DEUX_PLACES`) VALUES (@LIBELLE_TYPE_CHAMBRE, @PRIX, @CODE_TYPE_CHAMBRE, @DATE_CREATION, @CODE_UTILISATEUR_MODIF, @CODE_AGENCE, @NOMBRE_LIT_UNE_PLACE, @NOMBRE_LIT_DEUX_PLACES)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@LIBELLE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_TYPE_CHAMBRE
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = Now()
        command.Parameters.Add("@CODE_UTILISATEUR_MODIF", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@NOMBRE_LIT_UNE_PLACE", MySqlDbType.Int32).Value = NOMBRE_LIT_UNE_PLACE
        command.Parameters.Add("@NOMBRE_LIT_DEUX_PLACES", MySqlDbType.Int32).Value = NOMBRE_LIT_DEUX_PLACES

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

    'Create a function to check if the company already exists
    Public Function typeChambreExists(ByVal CODE_TYPE_CHAMBRE As String, ByVal LIBELLE_TYPE_CHAMBRE As String) As Boolean

        Dim existQuery As String = "SELECT * From type_chambre WHERE CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE OR LIBELLE_TYPE_CHAMBRE=@LIBELLE_TYPE_CHAMBRE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@LIBELLE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_TYPE_CHAMBRE

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

    'create a function to update the selected company
    Public Function UpdateChambreOnCreation(ByVal CODE_TYPE_CHAMBRE As String, ByVal LIBELLE_TYPE_CHAMBRE As String, ByVal PRIX As Double, ByVal CODE_UTILISATEUR_MODIF As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_AGENCE As String, ByVal NOMBRE_LIT_UNE_PLACE As Integer, ByVal NOMBRE_LIT_DEUX_PLACES As Integer) As Boolean
        Dim updateQuery As String = "UPDATE type_chambre SET CODE_TYPE_CHAMBRE=@NEW_CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE=@LIBELLE_TYPE_CHAMBRE, PRIX=@PRIX, CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE,  CODE_UTILISATEUR_MODIF=@CODE_UTILISATEUR_MODIF, DATE_MODIFICATION=@DATE_MODIFICATION, CODE_AGENCE=@CODE_AGENCE , NOMBRE_LIT_UNE_PLACE=@NOMBRE_LIT_UNE_PLACE, NOMBRE_LIT_DEUX_PLACES=@NOMBRE_LIT_DEUX_PLACES WHERE CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@NEW_CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE

        command.Parameters.Add("@LIBELLE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_TYPE_CHAMBRE
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX

        command.Parameters.Add("@CODE_UTILISATEUR_MODIF", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@DATE_MODIFICATION", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@NOMBRE_LIT_UNE_PLACE", MySqlDbType.Int32).Value = NOMBRE_LIT_UNE_PLACE
        command.Parameters.Add("@NOMBRE_LIT_DEUX_PLACES", MySqlDbType.Int32).Value = NOMBRE_LIT_DEUX_PLACES

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

    'create a function to update the selected entry
    Public Function UpdateChambre(ByVal LIBELLE_TYPE_CHAMBRE As String, ByVal DESCRIPTION As String, ByVal PRIX As Double, ByVal CODE_TYPE_CHAMBRE As String, ByVal CODE_UTILISATEUR_MODIF As String, ByVal DATE_MODIFICATION As Date, ByVal TAUX_CHARGE_FIXE As Double, ByVal CODE_AGENCE As String, ByVal OLD_CODE_TYPE_CHAMBRE As String, Optional ByVal SUPERFICIE As Double = 0, Optional ByVal CAPACITE As Double = 0, Optional ByVal CODE_TYPE As String = "chambre") As Boolean

        Dim updateQuery As String = "UPDATE type_chambre SET LIBELLE_TYPE_CHAMBRE=@LIBELLE_TYPE_CHAMBRE, DESCRIPTION=@DESCRIPTION, PRIX=@PRIX, CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE, CAPACITE=@CAPACITE , SUPERFICIE=@SUPERFICIE ,CODE_UTILISATEUR_MODIF=@CODE_UTILISATEUR_MODIF, DATE_MODIFICATION=@DATE_MODIFICATION, TAUX_CHARGE_FIXE=@TAUX_CHARGE_FIXE, CODE_AGENCE=@CODE_AGENCE WHERE CODE_TYPE_CHAMBRE = @OLD_CODE_TYPE_CHAMBRE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@LIBELLE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_TYPE_CHAMBRE
        command.Parameters.Add("@DESCRIPTION", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@OLD_CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = OLD_CODE_TYPE_CHAMBRE
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@CODE_UTILISATEUR_MODIF", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@DATE_MODIFICATION", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = CODE_TYPE
        command.Parameters.Add("@SUPERFICIE", MySqlDbType.Double).Value = SUPERFICIE
        command.Parameters.Add("@CAPACITE", MySqlDbType.Double).Value = CAPACITE
        command.Parameters.Add("@TAUX_CHARGE_FIXE", MySqlDbType.Double).Value = TAUX_CHARGE_FIXE

        command.ExecuteNonQuery()

        Dim updateQuery_ As String = "UPDATE chambre SET CODE_TYPE_CHAMBRE = @CODE_TYPE_CHAMBRE WHERE CODE_TYPE_CHAMBRE = @OLD_CODE_TYPE_CHAMBRE"

        Dim command_ As New MySqlCommand(updateQuery_, GlobalVariable.connect)

        command_.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command_.Parameters.Add("@OLD_CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = OLD_CODE_TYPE_CHAMBRE

        command_.ExecuteNonQuery()

        Return True

    End Function

    'Create a Function to return a company using its id
    Public Function getTypeChambreById(ByVal ID_TYPE_CHAMBRE As Integer) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT * type_chambre WHERE ID_TYPE_CHAMBRE=@ID_TYPE_CHAMBRE"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ID_TYPE_CHAMBRE", MySqlDbType.Int32).Value = ID_TYPE_CHAMBRE
        adapter.SelectCommand = Command
        adapter.Fill(table)

        Return table

    End Function

    'SALLE DE FETE

    'insert a new ROOM TYPE on start up
    Public Function InsertOnStartUpSalle(ByVal LIBELLE_TYPE_CHAMBRE As String, ByVal PRIX As Double, ByVal CODE_TYPE_CHAMBRE As String, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_AGENCE As String, ByVal CAPACITE As Integer, ByVal TYPE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `type_chambre` (`LIBELLE_TYPE_CHAMBRE`, `PRIX`, `CODE_TYPE_CHAMBRE`, `DATE_CREATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`, `CAPACITE`, `TYPE`) VALUES (@LIBELLE_TYPE_CHAMBRE, @PRIX, @CODE_TYPE_CHAMBRE, @DATE_CREATION, @CODE_UTILISATEUR_MODIF, @CODE_AGENCE, @CAPACITE,@TYPE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@LIBELLE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_TYPE_CHAMBRE
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = Now()
        command.Parameters.Add("@CODE_UTILISATEUR_MODIF", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CAPACITE", MySqlDbType.Int32).Value = CAPACITE
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

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

    'create a function to update the selected company
    Public Function UpdateChambreOnCreationSalle(ByVal CODE_TYPE_CHAMBRE As String, ByVal LIBELLE_TYPE_CHAMBRE As String, ByVal PRIX As Double, ByVal CODE_UTILISATEUR_MODIF As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_AGENCE As String, ByVal CAPACITE As Integer) As Boolean
        Dim updateQuery As String = "UPDATE type_chambre SET CODE_TYPE_CHAMBRE=@NEW_CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE=@LIBELLE_TYPE_CHAMBRE, PRIX=@PRIX, CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE,  CODE_UTILISATEUR_MODIF=@CODE_UTILISATEUR_MODIF, DATE_MODIFICATION=@DATE_MODIFICATION, CODE_AGENCE=@CODE_AGENCE , CAPACITE=@CAPACITE CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@NEW_CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE

        command.Parameters.Add("@LIBELLE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = LIBELLE_TYPE_CHAMBRE
        command.Parameters.Add("@PRIX", MySqlDbType.Double).Value = PRIX

        command.Parameters.Add("@CODE_UTILISATEUR_MODIF", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@DATE_MODIFICATION", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CAPACITE", MySqlDbType.Int32).Value = CAPACITE

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
