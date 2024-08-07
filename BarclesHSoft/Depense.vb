﻿Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Depense
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new entry
    Public Function insertDepenseFamily(ByVal NATURE As String, ByVal CODE_FAMILLE As String, ByVal NOM_FAMILLE As String, ByVal CODE_SOUS_FAMILLE As String, ByVal NOM_SOUS_FAMILLE As String, ByVal DESCRIPTION As String) As Boolean

        Dim insertQuery As String = ""

        If GlobalVariable.typeFamilleOuSousFamilleDepense = "famille" Then
            insertQuery = "INSERT INTO `depense_famille`(`NATURE`, `CODE_FAMILLE`, `NOM_FAMILLE`, `CODE_AGENCE`, `DESCRIPTION`) VALUES (@value2, @value3, @value4, @value5, @value7)"

        ElseIf GlobalVariable.typeFamilleOuSousFamilleDepense = "sous famille" Then
            insertQuery = "INSERT INTO `depense_famille`(`NATURE`, `CODE_SOUS_FAMILLE`, `NOM_SOUS_FAMILLE`, `CODE_AGENCE`, `DESCRIPTION`, `CODE_FAMILLE`, `NOM_FAMILLE`) VALUES (@value2, @value8, @value6, @value5, @value7, @value3, @value4)"
        End If

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = NATURE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_FAMILLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NOM_FAMILLE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NOM_SOUS_FAMILLE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_SOUS_FAMILLE

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
    Public Function updateDepenseFamily(ByVal NATURE As String, ByVal CODE_FAMILLE As String, ByVal NOM_FAMILLE As String, ByVal CODE_SOUS_FAMILLE As String, ByVal NOM_SOUS_FAMILLE As String, ByVal DESCRIPTION As String) As Boolean

        Dim updateQuery As String = ""

        If GlobalVariable.typeFamilleOuSousFamilleDepense = "famille" Then
            updateQuery = "UPDATE `depense_famille` SET `CODE_FAMILLE`=@CODE_FAMILLE,`NOM_FAMILLE`=@value4, `DESCRIPTION`=@value7 WHERE  CODE_FAMILLE= @CODE_FAMILLE"

        ElseIf GlobalVariable.typeFamilleOuSousFamilleDepense = "sous famille" Then

            updateQuery = "UPDATE `depense_famille` SET `CODE_SOUS_FAMILLE`=@CODE_SOUS_FAMILLE, CODE_FAMILLE=@CODE_FAMILLE, `NOM_SOUS_FAMILLE`=@value6, `DESCRIPTION`=@value7, `NOM_FAMILLE`=@value4 WHERE CODE_SOUS_FAMILLE =@CODE_SOUS_FAMILLE"

        End If

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = NATURE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_FAMILLE
        command.Parameters.Add("@CODE_FAMILLE", MySqlDbType.VarChar).Value = CODE_FAMILLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NOM_FAMILLE
        command.Parameters.Add("@CODE_SOUS_FAMILLE", MySqlDbType.VarChar).Value = CODE_SOUS_FAMILLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NOM_SOUS_FAMILLE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = DESCRIPTION

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

    Public Function insertCategorieDepense(ByVal CODE_CATEGORY_DEPENSE As String, ByVal FAMILLE As String, ByVal SOUS_FAMILLE As String, ByVal CODE As String,
                                           ByVal LIBELLE As String, ByVal MONTANT As Double, ByVal CODE_AGENCE As String, ByVal DATE_DEPENSE As Date) As Boolean

        Dim insertQuery As String = ""

        insertQuery = "INSERT INTO `regroupement_depenses`(`CODE_CATEGORY_DEPENSE`, `FAMILLE`, `SOUS_FAMILLE`, `CODE`, `LIBELLE`, `MONTANT`,`CODE_AGENCE`, DATE_DEPENSE)
        VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7, @DATE_DEPENSE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_CATEGORY_DEPENSE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = FAMILLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = SOUS_FAMILLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = MONTANT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@DATE_DEPENSE", MySqlDbType.Date).Value = DATE_DEPENSE

        If command.ExecuteNonQuery() = 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function insertCategorieChiffresAffiares(ByVal CODE As String, ByVal COMPTE As String, ByVal INTITULE As String,
                                           ByVal MONTANT As Double, ByVal DATE_CREATION As Date) As Boolean

        Dim insertQuery As String = ""

        insertQuery = "INSERT INTO `regroupement_chiffres_affaires`(`CODE`, `COMPTE`, `INTITULE`, `MONTANT`,  `DATE_CREATION`) 
        VALUES (@CODE,@COMPTE,@INTITULE,@MONTANT, @DATE_CREATION)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE", MySqlDbType.VarChar).Value = CODE
        command.Parameters.Add("@INTITULE", MySqlDbType.VarChar).Value = INTITULE
        command.Parameters.Add("@COMPTE", MySqlDbType.VarChar).Value = COMPTE
        command.Parameters.Add("@MONTANT", MySqlDbType.Double).Value = MONTANT
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION

        If command.ExecuteNonQuery() = 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function previsions(ByVal COMPTE As String, ByVal MONTANT As Double, ByVal DATE_DEBUT As Date, ByVal DATE_FIN As Date) As Boolean

        Dim insertQuery As String = ""

        insertQuery = "INSERT INTO `compte_exploitation_previsions`(`COMPTE`, `MONTANT`,  `DATE_DEBUT`,  `DATE_FIN`) 
        VALUES (@COMPTE, @MONTANT, @DATE_DEBUT, @DATE_FIN)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@COMPTE", MySqlDbType.VarChar).Value = COMPTE
        command.Parameters.Add("@MONTANT", MySqlDbType.Double).Value = MONTANT
        command.Parameters.Add("@DATE_DEBUT", MySqlDbType.Date).Value = DATE_DEBUT
        command.Parameters.Add("@DATE_FIN", MySqlDbType.Date).Value = DATE_FIN

        If command.ExecuteNonQuery() = 1 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
