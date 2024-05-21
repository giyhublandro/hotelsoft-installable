Imports System.IO
Imports MySql.Data.MySqlClient

Public Class TypePersonnel

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new client Catgeory
    Public Function insertTypePersonnel(ByVal CODE_TYPE_PERSONNEL As String, ByVal LIBELLE_TYPE_PERSONNEL As String, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `type_personnel`(`CODE_TYPE_PERSONNEL`, `LIBELLE_TYPE_PERSONNEL`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`) VALUES (@value1,@value2,@value3,@value4,@value5)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE_TYPE_PERSONNEL
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

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
    Public Function typePersonnelExist(ByVal CODE_TYPE_PERSONNEL As String, ByVal LIBELLE_TYPE_PERSONNEL As String) As Boolean

        Dim existQuery As String = "SELECT * From type_personnel WHERE CODE_TYPE_PERSONNEL=@CODE_TYPE_PERSONNEL OR LIBELLE_TYPE_PERSONNEL=@LIBELLE_TYPE_PERSONNEL"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
        command.Parameters.Add("@LIBELLE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = LIBELLE_TYPE_PERSONNEL

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
    Public Function updateTypePersonnel(ByVal CODE_TYPE_PERSONNEL As String, ByVal LIBELLE_TYPE_PERSONNEL As String, ByVal CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "UPDATE `type_personnel` SET `CODE_TYPE_PERSONNEL`=@value2,`LIBELLE_TYPE_PERSONNEL`=@value3,`CODE_UTILISATEUR_MODIF`=@value6,`DATE_MODIFICATION`=@value7 WHERE CODE_TYPE_PERSONNEL=@CODE_TYPE_PERSONNEL"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_TYPE_PERSONNEL
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = Now()
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CODE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL

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

    '---------------------------------- PERSONNEL SAVING ----------------------------------------------

    'insert a new client Catgeory
    Public Function insertPersonnel(ByVal CODE_PERSONNEL As String, ByVal MATRICULE As String, ByVal NOM_PERSONNEL As String, ByVal NOM_JEUNE_FILLE As String, ByVal PRENOM_PERSONNEL As String, ByVal DATE_NAISSANCE As Date, ByVal LIEU_NAISSANCE As String, ByVal NOM_PERE As String, ByVal NOM_MERE As String, ByVal PROFESSION As String, ByVal CODE_AGENCE As String, ByVal SEXE As String, ByVal NUMERO_CNI As String, ByVal CODE_TYPE_PERSONNEL As String, ByVal ADRESSE As String, ByVal TELEPHONE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_CREATION As Date, ByVal CHEMIN_PHOTO As String, ByVal SALAIRE As Double) As Boolean

        Dim insertQuery As String = "INSERT INTO `personnel`(`CODE_PERSONNEL`,  `MATRICULE`, `NOM_PERSONNEL`, `NOM_JEUNE_FILLE`, `PRENOM_PERSONNEL`, `DATE_NAISSANCE`, `LIEU_NAISSANCE`, `NOM_PERE`, `NOM_MERE`, `PROFESSION`, `CODE_AGENCE`, `SEXE`, `NUMERO_CNI`, `CODE_TYPE_PERSONNEL`, `ADRESSE`, `TELEPHONE`, `FAX`, `EMAIL`, `CODE_UTILISATEUR_CREA`, `DATE_CREATION`, `CHEMIN_PHOTO`,`SALAIRE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@SALAIRE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_PERSONNEL
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = MATRICULE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NOM_PERSONNEL
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = NOM_JEUNE_FILLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = PRENOM_PERSONNEL
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = DATE_NAISSANCE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = LIEU_NAISSANCE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = NOM_PERE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = NOM_MERE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = PROFESSION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = SEXE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = NUMERO_CNI
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
        command.Parameters.Add("@value16", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = Date.Now()
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = CHEMIN_PHOTO
        command.Parameters.Add("@SALAIRE", MySqlDbType.Double).Value = SALAIRE

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
    Public Function PersonnelExist(ByVal CODE_PERSONNEL As String, ByVal NOM_PERSONNEL As String) As Boolean

        Dim existQuery As String = "SELECT * From personnel WHERE CODE_PERSONNEL=@CODE_PERSONNEL OR NOM_PERSONNEL=@NOM_PERSONNEL"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_PERSONNEL
        command.Parameters.Add("@NOM_PERSONNEL", MySqlDbType.VarChar).Value = NOM_PERSONNEL

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
    Public Function updatePersonnel(ByVal CODE_PERSONNEL As String, ByVal MATRICULE As String, ByVal NOM_PERSONNEL As String, ByVal NOM_JEUNE_FILLE As String, ByVal PRENOM_PERSONNEL As String, ByVal DATE_NAISSANCE As Date, ByVal LIEU_NAISSANCE As String, ByVal NOM_PERE As String, ByVal NOM_MERE As String, ByVal PROFESSION As String, ByVal SEXE As String, ByVal NUMERO_CNI As String, ByVal CODE_TYPE_PERSONNEL As String, ByVal ADRESSE As String, ByVal TELEPHONE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal CHEMIN_PHOTO As String, ByVal SALAIRE As Double) As Boolean

        Dim insertQuery As String = "UPDATE `personnel` SET `CODE_PERSONNEL`=@value2,`MATRICULE`=@value3,`NOM_PERSONNEL`=@value4,`NOM_JEUNE_FILLE`=@value5,`PRENOM_PERSONNEL`=@value6,`DATE_NAISSANCE`=@value7,`LIEU_NAISSANCE`=@value8,`NOM_PERE`=@value9,`NOM_MERE`=@value10,`PROFESSION`=@value11,`SEXE`=@value13,`NUMERO_CNI`=@value14,`CODE_TYPE_PERSONNEL`=@value15,`ADRESSE`=@value16,`TELEPHONE`=@value17,`FAX`=@value18,`EMAIL`=@value19,`CHEMIN_PHOTO`=@value22, `SALAIRE`=@SALAIRE WHERE CODE_PERSONNEL=@CODE_PERSONNEL"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_PERSONNEL
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_PERSONNEL
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = MATRICULE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NOM_PERSONNEL
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = NOM_JEUNE_FILLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = PRENOM_PERSONNEL
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = DATE_NAISSANCE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = LIEU_NAISSANCE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = NOM_PERE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = NOM_MERE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = PROFESSION
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = SEXE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = NUMERO_CNI
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
        command.Parameters.Add("@value16", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = CHEMIN_PHOTO
        command.Parameters.Add("@SALAIRE", MySqlDbType.Double).Value = SALAIRE

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
