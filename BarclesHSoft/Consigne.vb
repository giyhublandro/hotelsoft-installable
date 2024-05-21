Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Consigne

    'insert a new client Catgeory
    Public Function insertConsigne(ByVal CODE_CONSIGNE As String, ByVal DATE_CONSIGNE As Date, ByVal AUTEUR As String, ByVal CONSIGNE As String, ByVal HEURE_CONSIGNE As Date) As Boolean

        Dim insertQuery As String = "INSERT INTO `cahier_consigne`(`CODE_CONSIGNE`, `DATE_CONSIGNE`, `AUTEUR`, `CONSIGNE`, `CODE_AGENCE`, `HEURE_CONSIGNE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_CONSIGNE
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_CONSIGNE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = AUTEUR
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CONSIGNE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = HEURE_CONSIGNE

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

    Public Function updateConsigne(ByVal CODE_CONSIGNE As String, ByVal AUTEUR As String, ByVal CONSIGNE As String) As Boolean

        Dim insertQuery As String = "UPDATE `cahier_consigne` SET `CONSIGNE`=@value5 WHERE CODE_CONSIGNE =@CODE_CONSIGNE AND CODE_AGENCE=@CODE_AGENCE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CONSIGNE", MySqlDbType.VarChar).Value = CODE_CONSIGNE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CONSIGNE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

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


    Public Function insertConsigneLigne(ByVal CODE_CONSIGNE As String, ByVal DATE_COMMENTAIRE As Date, ByVal AUTEUR As String, ByVal COMMENTAIRE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `cahier_consigne_ligne`(`CODE_CONSIGNE`, `COMMENTAIRE`, `DATE_COMMENTAIRE`, `AUTEUR`) VALUES (@value2,@value3,@value4,@value5)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_CONSIGNE
        command.Parameters.Add("@value4", MySqlDbType.DateTime).Value = DATE_COMMENTAIRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = AUTEUR
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = COMMENTAIRE

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

    Function listeDesConsignes(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_CONSIGNE As Integer) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            getUserQuery = "SELECT ETAT_CONSIGNE, CODE_CONSIGNE, `ID_CONSIGNE` AS NUMBER, `HEURE_CONSIGNE` AS 'DATE & TIME', `AUTEUR` As AUTHOR, `CONSIGNE` AS INSTRUCTION FROM `cahier_consigne` WHERE DATE_CONSIGNE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CONSIGNE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_CONSIGNE=@ETAT_CONSIGNE ORDER BY ID_CONSIGNE DESC"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            getUserQuery = "SELECT ETAT_CONSIGNE, CODE_CONSIGNE, `ID_CONSIGNE` AS NUMERO, `HEURE_CONSIGNE` AS 'DATE & HEURE', `AUTEUR`, `CONSIGNE` FROM `cahier_consigne` WHERE DATE_CONSIGNE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CONSIGNE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_CONSIGNE=@ETAT_CONSIGNE ORDER BY ID_CONSIGNE DESC"
        End If

        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ETAT_CONSIGNE", MySqlDbType.Int64).Value = ETAT_CONSIGNE

        Dim adapter As New MySqlDataAdapter(Command)
        Dim table As New DataTable()

        adapter.Fill(table)

        Return table

    End Function

    Function listeDesCommentaireDuneConsigne(ByVal CODE_CONSIGNE As String) As DataTable

        Dim getUserQuery As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            getUserQuery = "SELECT `AUTEUR` AS AUTHOR, `DATE_COMMENTAIRE` AS DATE, `COMMENTAIRE` AS COMMENT FROM `cahier_consigne_ligne` WHERE CODE_CONSIGNE=@CODE_CONSIGNE ORDER BY ID_CONSIGNE_LIGNE DESC"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            getUserQuery = "SELECT `AUTEUR`, `DATE_COMMENTAIRE` AS DATE, `COMMENTAIRE` FROM `cahier_consigne_ligne` WHERE CODE_CONSIGNE=@CODE_CONSIGNE ORDER BY ID_CONSIGNE_LIGNE DESC"
        End If

        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@CODE_CONSIGNE", MySqlDbType.VarChar).Value = CODE_CONSIGNE

        Dim adapter As New MySqlDataAdapter(Command)
        Dim table As New DataTable()

        adapter.Fill(table)

        Return table

    End Function

    Function FiltrerLesConsignes(ByVal AUTEUR As String, ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim getUserQuery As String = ""

        If Trim(AUTEUR) = "" Then

            'Les consignes par apports aux dates

            If GlobalVariable.actualLanguageValue = 0 Then
                getUserQuery = "SELECT ETAT_CONSIGNE, CODE_CONSIGNE, `ID_CONSIGNE` AS N°, `HEURE_CONSIGNE` AS 'DATE & TIME', `AUTEUR` As AUTHOR, `CONSIGNE` AS INSTRUCTION 
                FROM `cahier_consigne`
                WHERE DATE_CONSIGNE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
                AND DATE_CONSIGNE >='" & DateDebut.ToString("yyyy-MM-dd") & "' 
                ORDER BY ID_CONSIGNE DESC"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                getUserQuery = "SELECT ETAT_CONSIGNE, CODE_CONSIGNE, `ID_CONSIGNE` AS N°, `HEURE_CONSIGNE` AS 'DATE & HEURE', `AUTEUR`, `CONSIGNE` 
                FROM `cahier_consigne`
                WHERE DATE_CONSIGNE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
                AND DATE_CONSIGNE >='" & DateDebut.ToString("yyyy-MM-dd") & "' 
                ORDER BY ID_CONSIGNE DESC"
            End If

        Else

            'Les consignes par apports aux dates et l'auteur

            If GlobalVariable.actualLanguageValue = 0 Then
                getUserQuery = "SELECT ETAT_CONSIGNE, CODE_CONSIGNE, `ID_CONSIGNE` AS N°, `HEURE_CONSIGNE` AS 'DATE & TIME', `AUTEUR` As AUTHOR, `CONSIGNE` AS INSTRUCTION 
                FROM `cahier_consigne`
                WHERE DATE_CONSIGNE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
                AND DATE_CONSIGNE >='" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND AUTEUR=@AUTEUR ORDER BY ID_CONSIGNE DESC"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                getUserQuery = "SELECT ETAT_CONSIGNE, CODE_CONSIGNE, `ID_CONSIGNE` AS N°, `HEURE_CONSIGNE` AS 'DATE & HEURE', `AUTEUR`, `CONSIGNE` 
                FROM `cahier_consigne`
                WHERE DATE_CONSIGNE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
                AND DATE_CONSIGNE >='" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND AUTEUR=@AUTEUR ORDER BY ID_CONSIGNE DESC"
            End If

        End If

        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@AUTEUR", MySqlDbType.VarChar).Value = AUTEUR

        Dim adapter As New MySqlDataAdapter(Command)
        Dim table As New DataTable()

        adapter.Fill(table)

        Return table

    End Function

    Public Function validationDeLaConsigne(ByVal ETAT_CONSIGNE As Integer, ByVal CODE_CONSIGNE As String) As Boolean

        Dim insertQuery As String = "UPDATE `cahier_consigne` SET `ETAT_CONSIGNE`=@ETAT_CONSIGNE WHERE CODE_CONSIGNE=@CODE_CONSIGNE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@ETAT_CONSIGNE", MySqlDbType.Int64).Value = ETAT_CONSIGNE
        command.Parameters.Add("@CODE_CONSIGNE", MySqlDbType.VarChar).Value = CODE_CONSIGNE

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
