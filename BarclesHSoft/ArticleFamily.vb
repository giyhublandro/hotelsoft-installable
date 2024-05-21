Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ArticleFamily
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new entry
    Public Function insertArticleFamily(ByVal CODE_FAMILLE As String, ByVal LIBELLE_FAMILLE As String, ByVal NIVEAU_HIERARCHIQUE As String, ByVal CODE_FAMILLE_PARENT As String, ByVal NUM_COMPTE_MARCHANDISE As String, ByVal NUM_COMPTE_VENTE As String, ByVal METHODE_SUIVI_STOCK As String, ByVal POURCENTAGE_REMISE As Double, ByVal TAUX_TVA As Double, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_AGENCE As String, ByVal TABLE_NAME As String) As Boolean

        Dim insertQuery As String = "INSERT INTO " & TABLE_NAME & " (`CODE_FAMILLE`, `LIBELLE_FAMILLE`, `NIVEAU_HIERARCHIQUE`, `CODE_FAMILLE_PARENT`, `NUM_COMPTE_MARCHANDISE`, `NUM_COMPTE_VENTE`, `METHODE_SUIVI_STOCK`, `POURCENTAGE_REMISE`, `TAUX_TVA`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_FAMILLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_FAMILLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NIVEAU_HIERARCHIQUE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_FAMILLE_PARENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUM_COMPTE_MARCHANDISE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NUM_COMPTE_VENTE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = METHODE_SUIVI_STOCK
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = TAUX_TVA
        command.Parameters.Add("@value11", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value13", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_AGENCE

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
    Public Function updateArticleFamily(ByVal CODE_FAMILLE As String, ByVal LIBELLE_FAMILLE As String, ByVal NIVEAU_HIERARCHIQUE As String, ByVal CODE_FAMILLE_PARENT As String, ByVal NUM_COMPTE_MARCHANDISE As String, ByVal NUM_COMPTE_VENTE As String, ByVal METHODE_SUIVI_STOCK As String, ByVal POURCENTAGE_REMISE As Double, ByVal TAUX_TVA As Double, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_AGENCE As String, ByVal TABLE_NAME As String) As Boolean

        Dim updateQuery As String = "UPDATE " & TABLE_NAME & " SET `CODE_FAMILLE`=@value2, `LIBELLE_FAMILLE`=@value3, `NIVEAU_HIERARCHIQUE`=@value4, `CODE_FAMILLE_PARENT`=@value5, `NUM_COMPTE_MARCHANDISE`=@value6,  `NUM_COMPTE_VENTE`=@value7, `METHODE_SUIVI_STOCK`=@value8, `POURCENTAGE_REMISE`=@value9, `TAUX_TVA`=@value10, `CODE_UTILISATEUR_CREA`=@value12, `DATE_MODIFICATION`=@value13, `CODE_UTILISATEUR_MODIF`=@value14, `CODE_AGENCE`=@value15 WHERE CODE_FAMILLE=@CODE_FAMILLE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FAMILLE", MySqlDbType.VarChar).Value = CODE_FAMILLE

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_FAMILLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_FAMILLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NIVEAU_HIERARCHIQUE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_FAMILLE_PARENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUM_COMPTE_MARCHANDISE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NUM_COMPTE_VENTE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = METHODE_SUIVI_STOCK
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = TAUX_TVA
        'command.Parameters.Add("@value11", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value13", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_AGENCE

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

    Public Function insertArticleFamilySous(ByVal CODE_SOUS_FAMILLE As String, ByVal LIBELLE_SOUS_FAMILLE As String, ByVal NIVEAU_HIERARCHIQUE As String, ByVal CODE_FAMILLE_PARENT As String, ByVal NUM_COMPTE_MARCHANDISE As String, ByVal NUM_COMPTE_VENTE As String, ByVal METHODE_SUIVI_STOCK As String, ByVal POURCENTAGE_REMISE As Double, ByVal TAUX_TVA As Double, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `sous_famille`(`CODE_SOUS_FAMILLE`, `LIBELLE_SOUS_FAMILLE`, `NIVEAU_HIERARCHIQUE`, `CODE_FAMILLE_PARENT`, `NUM_COMPTE_MARCHANDISE`, `NUM_COMPTE_VENTE`, `METHODE_SUIVI_STOCK`, `POURCENTAGE_REMISE`, `TAUX_TVA`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_SOUS_FAMILLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_SOUS_FAMILLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NIVEAU_HIERARCHIQUE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_FAMILLE_PARENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUM_COMPTE_MARCHANDISE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NUM_COMPTE_VENTE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = METHODE_SUIVI_STOCK
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = TAUX_TVA
        command.Parameters.Add("@value11", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value13", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_AGENCE

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
    Public Function updateArticleFamilySous(ByVal CODE_SOUS_FAMILLE As String, ByVal LIBELLE_SOUS_FAMILLE As String, ByVal NIVEAU_HIERARCHIQUE As String, ByVal CODE_FAMILLE_PARENT As String, ByVal NUM_COMPTE_MARCHANDISE As String, ByVal NUM_COMPTE_VENTE As String, ByVal METHODE_SUIVI_STOCK As String, ByVal POURCENTAGE_REMISE As Double, ByVal TAUX_TVA As Double, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As DateTime, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_AGENCE As String) As Boolean

        Dim updateQuery As String = "UPDATE `sous_famille` SET `CODE_SOUS_FAMILLE`=@value2,`LIBELLE_SOUS_FAMILLE`=@value3,`NIVEAU_HIERARCHIQUE`=@value4,`CODE_FAMILLE_PARENT`=@value5,`NUM_COMPTE_MARCHANDISE`=@value6,`NUM_COMPTE_VENTE`=@value7,`METHODE_SUIVI_STOCK`=@value8,`POURCENTAGE_REMISE`=@value9,`TAUX_TVA`=@value10,`CODE_UTILISATEUR_CREA`=@value12,`CODE_UTILISATEUR_MODIF`=@value14,`CODE_AGENCE`=@value15 WHERE CODE_SOUS_FAMILLE=@CODE_FAMILLE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FAMILLE", MySqlDbType.VarChar).Value = CODE_SOUS_FAMILLE

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_SOUS_FAMILLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_SOUS_FAMILLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NIVEAU_HIERARCHIQUE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_FAMILLE_PARENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUM_COMPTE_MARCHANDISE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NUM_COMPTE_VENTE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = METHODE_SUIVI_STOCK
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = TAUX_TVA
        'command.Parameters.Add("@value11", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        'command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = DATE_MODIFICATION
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_AGENCE

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
