Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Company

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new society
    Public Function InsertCompany(ByVal CODE_SOCIETE As String, ByVal RAISON_SOCIALE As String, ByVal VILLE As String, ByVal BOITE_POSTALE As String, ByVal PAYS As String, ByVal TELEPHONE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal RUE As String, ByVal NUM_CONTRIBUABLE As String, ByVal NUM_REGISTRE As String, Optional ByVal CODE_AGENCE_ACTUEL As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `societe` (`CODE_SOCIETE`, `RAISON_SOCIALE`, `VILLE`, `BOITE_POSTALE`, `PAYS`, `TELEPHONE`, `FAX`, `EMAIL`, `RUE`, `NUM_CONTRIBUABLE`, `NUM_REGISTRE`, `CODE_AGENCE_ACTUEL`) VALUES (@CODE_SOCIETE, @RAISON_SOCIALE, @VILLE, @BOITE_POSTALE, @PAYS, @TELEPHONE, @FAX, @EMAIL, @RUE, @NUM_CONTRIBUABLE, @NUM_REGISTRE, @CODE_AGENCE_ACTUEL)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_SOCIETE", MySqlDbType.VarChar).Value = CODE_SOCIETE
        command.Parameters.Add("@RAISON_SOCIALE", MySqlDbType.VarChar).Value = RAISON_SOCIALE
        command.Parameters.Add("@VILLE", MySqlDbType.VarChar).Value = VILLE
        command.Parameters.Add("@BOITE_POSTALE", MySqlDbType.VarChar).Value = BOITE_POSTALE
        command.Parameters.Add("@PAYS", MySqlDbType.VarChar).Value = PAYS
        command.Parameters.Add("@TELEPHONE", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@FAX", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@RUE", MySqlDbType.VarChar).Value = RUE
        command.Parameters.Add("@NUM_CONTRIBUABLE", MySqlDbType.VarChar).Value = NUM_CONTRIBUABLE
        command.Parameters.Add("@NUM_REGISTRE", MySqlDbType.VarChar).Value = NUM_REGISTRE
        command.Parameters.Add("@CODE_AGENCE_ACTUEL", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

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

    Public Function Insert(ByVal CODE_SOCIETE As String, ByVal RAISON_SOCIALE As String, ByVal VILLE As String, ByVal BOITE_POSTALE As String, ByVal PAYS As String, ByVal TELEPHONE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal RUE As String, ByVal NUM_CONTRIBUABLE As String, ByVal NUM_REGISTRE As String, ByVal CODE_MONNAIE As String, Optional ByVal CODE_AGENCE_ACTUEL As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `societe` (`CODE_SOCIETE`, `RAISON_SOCIALE`, `VILLE`, `BOITE_POSTALE`, `PAYS`, `TELEPHONE`, `FAX`, `EMAIL`, `RUE`, `NUM_CONTRIBUABLE`, `NUM_REGISTRE`,`CODE_MONNAIE`, `CODE_AGENCE_ACTUEL`) VALUES (@CODE_SOCIETE, @RAISON_SOCIALE, @VILLE, @BOITE_POSTALE, @PAYS, @TELEPHONE, @FAX, @EMAIL, @RUE, @NUM_CONTRIBUABLE, @NUM_REGISTRE,@CODE_MONNAIE, @CODE_AGENCE_ACTUEL)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_SOCIETE", MySqlDbType.VarChar).Value = CODE_SOCIETE
        command.Parameters.Add("@RAISON_SOCIALE", MySqlDbType.VarChar).Value = RAISON_SOCIALE
        command.Parameters.Add("@VILLE", MySqlDbType.VarChar).Value = VILLE
        command.Parameters.Add("@BOITE_POSTALE", MySqlDbType.VarChar).Value = BOITE_POSTALE
        command.Parameters.Add("@PAYS", MySqlDbType.VarChar).Value = PAYS
        command.Parameters.Add("@TELEPHONE", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@FAX", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@RUE", MySqlDbType.VarChar).Value = RUE
        command.Parameters.Add("@NUM_CONTRIBUABLE", MySqlDbType.VarChar).Value = NUM_CONTRIBUABLE
        command.Parameters.Add("@NUM_REGISTRE", MySqlDbType.VarChar).Value = NUM_REGISTRE
        command.Parameters.Add("@CODE_MONNAIE", MySqlDbType.VarChar).Value = CODE_MONNAIE
        command.Parameters.Add("@CODE_AGENCE_ACTUEL", MySqlDbType.VarChar).Value = CODE_AGENCE_ACTUEL

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
    Public Function companyExists(ByVal CODE_SOCIETE As String, ByVal RAISON_SOCIALE As String) As Boolean

        Dim existQuery As String = "SELECT * From societe WHERE CODE_SOCIETE=@CODE_SOCIETE OR RAISON_SOCIALE=@RAISON_SOCIALE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_SOCIETE", MySqlDbType.VarChar).Value = CODE_SOCIETE
        command.Parameters.Add("@RAISON_SOCIALE", MySqlDbType.VarChar).Value = RAISON_SOCIALE

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
    Public Function UpdateCompany(ByVal CODE_SOCIETE As String, ByVal TAUX_CHAMBRE As Double, ByVal TAUX_TVA As Double, ByVal TAUX_REPAS As Double, ByVal TAUX_PRODUIT As Double, ByVal DATE_CREATION As Date) As Boolean

        Dim updateQuery As String = "UPDATE `societe` SET `TAUX_CHAMBRE`=@TAUX_CHAMBRE,`TAUX_TVA`=@TAUX_TVA,`TAUX_REPAS`=@TAUX_REPAS, `DATE_CREATION` = @DATE_CREATION,`TAUX_PRODUIT`=@TAUX_PRODUIT WHERE CODE_SOCIETE = @CODE_SOCIETE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_SOCIETE", MySqlDbType.VarChar).Value = CODE_SOCIETE
        command.Parameters.Add("@TAUX_CHAMBRE", MySqlDbType.Double).Value = TAUX_CHAMBRE
        command.Parameters.Add("@TAUX_TVA", MySqlDbType.Double).Value = TAUX_TVA
        command.Parameters.Add("@TAUX_REPAS", MySqlDbType.Double).Value = TAUX_REPAS
        command.Parameters.Add("@TAUX_PRODUIT", MySqlDbType.Double).Value = TAUX_PRODUIT
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = Now()

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
    Public Function getCompanyById(ByVal ID_SOCIETE As Integer) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT * societe WHERE ID_SOCIETE=@ID_SOCIETE"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ID_SOCIETE", MySqlDbType.Int32).Value = ID_SOCIETE
        adapter.SelectCommand = Command
        adapter.Fill(table)

        Return table

    End Function

End Class
