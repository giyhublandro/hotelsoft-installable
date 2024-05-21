Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Banque

    Public Function insertBanque(ByVal CODE_BANQUE As String, ByVal NOM_BANQUE As String, ByVal NUMERO_COMPTE As String, ByVal TELEPHONE As String, ByVal ADRESSE As String, ByVal EMAIL As String, ByVal FAX As String, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `banque`(`CODE_BANQUE`, `NOM_BANQUE`, `NUMERO_COMPTE`, `TELEPHONE`, `ADRESSE`, `EMAIL`, `FAX`,`CODE_AGENCE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_BANQUE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = NOM_BANQUE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NUMERO_COMPTE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_AGENCE

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

    Public Function insertBanqueTransactions(ByVal CODE_BANQUE As String, ByVal MODE_REGELEMENT As String, ByVal CODE_REGLEMENT As String, ByVal DEBIT As Double, ByVal CREDIT As Double, ByVal CODE_AGENCE As String, ByVal CODE_TRANSCATION As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `banque_transaction`(`CODE_BANQUE`, `MODE_REGELEMENT`, `CODE_REGLEMENT`, `DEBIT`, `CREDIT`, `CODE_AGENCE`, `CODE_TRANSCATION`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_BANQUE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = MODE_REGELEMENT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_REGLEMENT
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = DEBIT
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = CREDIT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_TRANSCATION

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
