
Imports MySql.Data.MySqlClient

Public Class ConfigClass

    Public Function createConfig(
            ByVal DESCRIPTION_1_F As String,
            ByVal DESCRIPTION_2_F As String,
            ByVal DESCRIPTION_3_F As String,
            ByVal DESCRIPTION_4_F As String,
            ByVal DESCRIPTION_1_E As String,
            ByVal DESCRIPTION_2_E As String,
            ByVal DESCRIPTION_3_E As String,
            ByVal DESCRIPTION_4_E As String,
            ByVal ACTIV_MES As String,
            ByVal SPEC_1E As String,
            ByVal SPEC_2E As String,
            ByVal SPEC_3E As String,
            ByVal SPEC_4E As String,
            ByVal SPEC_1F As String,
            ByVal SPEC_2F As String,
            ByVal SPEC_3F As String,
            ByVal SPEC_4F As String,
            ByVal SCHEME_COLOR As String,
            ByVal SCHEME_SECONDARY_COLOR As String,
            ByVal FOOTER_DOCUMENT_SOFTWARE As String,
            ByVal C_NAME As String,
            ByVal LOG As String,
            ByVal TEXT_PRIMARY_COLOR As String,
            ByVal TEXT_SECONDARY_COLOR As String)

        Dim insertQuery As String = "INSERT INTO `config`(`DESCRIPTION_1_F`, `DESCRIPTION_2_F`, `DESCRIPTION_3_F`, `DESCRIPTION_4_F`, `DESCRIPTION_1_E`, `DESCRIPTION_2_E`, 
`DESCRIPTION_3_E`, `DESCRIPTION_4_E`, `ACTIV_MES`, `SPEC_1E`, `SPEC_2E`, `SPEC_3E`, `SPEC_4E`, `SPEC_1F`, `SPEC_2F`, `SPEC_3F`, 
`SPEC_4F`, `SCHEME_COLOR`, `SCHEME_SECONDARY_COLOR`, `FOOTER_DOCUMENT_SOFTWARE`,`C_NAME`,`LOG`, `TEXT_PRIMARY_COLOR`, `TEXT_PRIMARY_COLOR`)
VALUES (@DESCRIPTION_1_F,@DESCRIPTION_2_F,@DESCRIPTION_3_F,@DESCRIPTION_4_F,@DESCRIPTION_1_E,@DESCRIPTION_2_E, 
DESCRIPTION_3_E,@DESCRIPTION_4_E,@ACTIV_MES,@SPEC_1E,@SPEC_2E,@SPEC_3E,@SPEC_4E,@SPEC_1F,@SPEC_2F,@SPEC_3F, 
SPEC_4F,@SCHEME_COLOR,@SCHEME_SECONDARY_COLOR,@FOOTER_DOCUMENT_SOFTWARE,@C_NAME, @LOG, @TEXT_PRIMARY_COLOR, @TEXT_SECONDARY_COLOR)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@DESCRIPTION_1_F", MySqlDbType.VarChar).Value = DESCRIPTION_1_F
        command.Parameters.Add("@DESCRIPTION_2_F", MySqlDbType.VarChar).Value = DESCRIPTION_2_F
        command.Parameters.Add("@DESCRIPTION_3_F", MySqlDbType.VarChar).Value = DESCRIPTION_3_F
        command.Parameters.Add("@DESCRIPTION_4_F", MySqlDbType.VarChar).Value = DESCRIPTION_4_F
        command.Parameters.Add("@DESCRIPTION_1_E", MySqlDbType.VarChar).Value = DESCRIPTION_1_E
        command.Parameters.Add("@DESCRIPTION_2_E", MySqlDbType.VarChar).Value = DESCRIPTION_2_E
        command.Parameters.Add("@DESCRIPTION_3_E", MySqlDbType.VarChar).Value = DESCRIPTION_3_E
        command.Parameters.Add("@DESCRIPTION_4_E", MySqlDbType.VarChar).Value = DESCRIPTION_4_E
        command.Parameters.Add("@SPEC_1E", MySqlDbType.VarChar).Value = SPEC_1E
        command.Parameters.Add("@SPEC_2E", MySqlDbType.VarChar).Value = SPEC_2E
        command.Parameters.Add("@SPEC_3E", MySqlDbType.VarChar).Value = SPEC_3E
        command.Parameters.Add("@SPEC_4E", MySqlDbType.VarChar).Value = SPEC_4E
        command.Parameters.Add("@SPEC_1F", MySqlDbType.VarChar).Value = SPEC_1F
        command.Parameters.Add("@SPEC_2F", MySqlDbType.VarChar).Value = SPEC_2F
        command.Parameters.Add("@SPEC_3F", MySqlDbType.VarChar).Value = SPEC_3F
        command.Parameters.Add("@SPEC_4F", MySqlDbType.VarChar).Value = SPEC_4F
        command.Parameters.Add("@ACTIV_MES", MySqlDbType.VarChar).Value = ACTIV_MES
        command.Parameters.Add("@SCHEME_COLOR", MySqlDbType.VarChar).Value = SCHEME_COLOR
        command.Parameters.Add("@SCHEME_SECONDARY_COLOR", MySqlDbType.VarChar).Value = SCHEME_SECONDARY_COLOR
        command.Parameters.Add("@FOOTER_DOCUMENT_SOFTWARE", MySqlDbType.VarChar).Value = FOOTER_DOCUMENT_SOFTWARE
        command.Parameters.Add("@LOG", MySqlDbType.VarChar).Value = LOG
        command.Parameters.Add("@TEXT_PRIMARY_COLOR", MySqlDbType.VarChar).Value = TEXT_PRIMARY_COLOR
        command.Parameters.Add("@TEXT_SECONDARY_COLOR", MySqlDbType.VarChar).Value = TEXT_SECONDARY_COLOR

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function


    Public Function updateConfigEn(
            ByVal DESCRIPTION_1_E As String,
            ByVal DESCRIPTION_2_E As String,
            ByVal DESCRIPTION_3_E As String,
            ByVal DESCRIPTION_4_E As String,
            ByVal ACTIV_MES As String,
            ByVal SPEC_1E As String,
            ByVal SPEC_2E As String,
            ByVal SPEC_3E As String,
            ByVal SPEC_4E As String,
            ByVal SCHEME_COLOR As String,
            ByVal SCHEME_SECONDARY_COLOR As String,
            ByVal FOOTER_DOCUMENT_SOFTWARE As String,
            ByVal C_NAME As String,
            ByVal LOG As String,
            ByVal TEXT_PRIMARY_COLOR As String,
            ByVal TEXT_SECONDARY_COLOR As String,
            ByVal ID_CONFIG As Integer)

        Dim insertQuery As String = "UPDATE `config` SET `DESCRIPTION_1_E`=@DESCRIPTION_1_E,`DESCRIPTION_2_E`=@DESCRIPTION_2_E,`DESCRIPTION_3_E`=@DESCRIPTION_3_E,`DESCRIPTION_4_E`=@DESCRIPTION_4_E,`ACTIV_MES`=@ACTIV_MES,
`SPEC_1E`=@SPEC_1E,`SPEC_2E`=@SPEC_2E,`SPEC_3E`=@SPEC_3E,`SPEC_4E`=@SPEC_4E,`SCHEME_COLOR`=@SCHEME_COLOR,`SCHEME_SECONDARY_COLOR`=@SCHEME_SECONDARY_COLOR,`FOOTER_DOCUMENT_SOFTWARE`=@FOOTER_DOCUMENT_SOFTWARE,`LOG`=@LOG,
TEXT_PRIMARY_COLOR =@TEXT_PRIMARY_COLOR, TEXT_SECONDARY_COLOR =@TEXT_SECONDARY_COLOR, C_NAME=@C_NAME WHERE ID_CONFIG=@ID_CONFIG"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@ID_CONFIG", MySqlDbType.Int64).Value = ID_CONFIG
        command.Parameters.Add("@DESCRIPTION_1_E", MySqlDbType.VarChar).Value = DESCRIPTION_1_E
        command.Parameters.Add("@DESCRIPTION_2_E", MySqlDbType.VarChar).Value = DESCRIPTION_2_E
        command.Parameters.Add("@DESCRIPTION_3_E", MySqlDbType.VarChar).Value = DESCRIPTION_3_E
        command.Parameters.Add("@DESCRIPTION_4_E", MySqlDbType.VarChar).Value = DESCRIPTION_4_E
        command.Parameters.Add("@SPEC_1E", MySqlDbType.VarChar).Value = SPEC_1E
        command.Parameters.Add("@SPEC_2E", MySqlDbType.VarChar).Value = SPEC_2E
        command.Parameters.Add("@SPEC_3E", MySqlDbType.VarChar).Value = SPEC_3E
        command.Parameters.Add("@SPEC_4E", MySqlDbType.VarChar).Value = SPEC_4E
        command.Parameters.Add("@ACTIV_MES", MySqlDbType.VarChar).Value = ACTIV_MES
        command.Parameters.Add("@SCHEME_COLOR", MySqlDbType.VarChar).Value = SCHEME_COLOR
        command.Parameters.Add("@SCHEME_SECONDARY_COLOR", MySqlDbType.VarChar).Value = SCHEME_SECONDARY_COLOR
        command.Parameters.Add("@FOOTER_DOCUMENT_SOFTWARE", MySqlDbType.VarChar).Value = FOOTER_DOCUMENT_SOFTWARE
        command.Parameters.Add("@LOG", MySqlDbType.VarChar).Value = LOG
        command.Parameters.Add("@TEXT_PRIMARY_COLOR", MySqlDbType.VarChar).Value = TEXT_PRIMARY_COLOR
        command.Parameters.Add("@TEXT_SECONDARY_COLOR", MySqlDbType.VarChar).Value = TEXT_SECONDARY_COLOR
        command.Parameters.Add("@C_NAME", MySqlDbType.VarChar).Value = C_NAME

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


    Public Function updateConfigFr(
            ByVal DESCRIPTION_1_F As String,
            ByVal DESCRIPTION_2_F As String,
            ByVal DESCRIPTION_3_F As String,
            ByVal DESCRIPTION_4_F As String,
            ByVal ACTIV_MES As String,
            ByVal SPEC_1F As String,
            ByVal SPEC_2F As String,
            ByVal SPEC_3F As String,
            ByVal SPEC_4F As String,
            ByVal SCHEME_COLOR As String,
            ByVal SCHEME_SECONDARY_COLOR As String,
            ByVal FOOTER_DOCUMENT_SOFTWARE As String,
            ByVal C_NAME As String,
            ByVal LOG As String,
            ByVal TEXT_PRIMARY_COLOR As String,
            ByVal TEXT_SECONDARY_COLOR As String,
            ByVal ID_CONFIG As Integer)

        Dim insertQuery As String = "UPDATE `config` SET `ID_CONFIG`=@ID_CONFIG,`DESCRIPTION_1_F`=@DESCRIPTION_1_F,`DESCRIPTION_2_F`=@DESCRIPTION_2_F,`DESCRIPTION_3_F`=@DESCRIPTION_3_F,
`DESCRIPTION_4_F`=@DESCRIPTION_4_F,`ACTIV_MES`=@ACTIV_MES,`SPEC_1F`=@SPEC_1F,`SPEC_2F`=@SPEC_2F,`SPEC_3F`=@SPEC_3F,
`SPEC_4F`=@SPEC_4F,`SCHEME_COLOR`=@SCHEME_COLOR,`SCHEME_SECONDARY_COLOR`=@SCHEME_SECONDARY_COLOR,`FOOTER_DOCUMENT_SOFTWARE`=@FOOTER_DOCUMENT_SOFTWARE,`LOG`=@LOG,
TEXT_PRIMARY_COLOR =@TEXT_PRIMARY_COLOR, TEXT_SECONDARY_COLOR =@TEXT_SECONDARY_COLOR,C_NAME=@C_NAME WHERE ID_CONFIG=@ID_CONFIG"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@ID_CONFIG", MySqlDbType.Int64).Value = ID_CONFIG
        command.Parameters.Add("@DESCRIPTION_1_F", MySqlDbType.VarChar).Value = DESCRIPTION_1_F
        command.Parameters.Add("@DESCRIPTION_2_F", MySqlDbType.VarChar).Value = DESCRIPTION_2_F
        command.Parameters.Add("@DESCRIPTION_3_F", MySqlDbType.VarChar).Value = DESCRIPTION_3_F
        command.Parameters.Add("@DESCRIPTION_4_F", MySqlDbType.VarChar).Value = DESCRIPTION_4_F
        command.Parameters.Add("@SPEC_1F", MySqlDbType.VarChar).Value = SPEC_1F
        command.Parameters.Add("@SPEC_2F", MySqlDbType.VarChar).Value = SPEC_2F
        command.Parameters.Add("@SPEC_3F", MySqlDbType.VarChar).Value = SPEC_3F
        command.Parameters.Add("@SPEC_4F", MySqlDbType.VarChar).Value = SPEC_4F
        command.Parameters.Add("@ACTIV_MES", MySqlDbType.VarChar).Value = ACTIV_MES
        command.Parameters.Add("@SCHEME_COLOR", MySqlDbType.VarChar).Value = SCHEME_COLOR
        command.Parameters.Add("@SCHEME_SECONDARY_COLOR", MySqlDbType.VarChar).Value = SCHEME_SECONDARY_COLOR
        command.Parameters.Add("@FOOTER_DOCUMENT_SOFTWARE", MySqlDbType.VarChar).Value = FOOTER_DOCUMENT_SOFTWARE
        command.Parameters.Add("@LOG", MySqlDbType.VarChar).Value = LOG
        command.Parameters.Add("@TEXT_PRIMARY_COLOR", MySqlDbType.VarChar).Value = TEXT_PRIMARY_COLOR
        command.Parameters.Add("@TEXT_SECONDARY_COLOR", MySqlDbType.VarChar).Value = TEXT_SECONDARY_COLOR
        command.Parameters.Add("@C_NAME", MySqlDbType.VarChar).Value = C_NAME
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
