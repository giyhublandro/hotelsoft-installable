Imports System.Text
Public Class Language
    Dim g_szCurPath As String
    Dim g_szLanguagePath As String
    '    /// <summary>
    '    /// È¡µÃÓïÑÔ×ÊÔ´ÎÄ¼þµÄÂ·¾¶
    '    /// </summary>
    Public Sub GetLanguagePath_Ex()
        Dim sldefault As String = ""
        g_szCurPath = Application.StartupPath
        'Dim sLan As String = ""
        'sLan = GetINI("System", "Language", sldefault, g_szCurPath + "\\Config.ini")
        'If sLan = "" Then 
        '    sLan = "Chinese"
        'End If
        g_szLanguagePath = g_szCurPath + "\\ToolsLanguage.ini"
    End Sub

    '     /// <summary>
    '     /// ¸ù¾Ý±êÊ¶szIDµ½Ñ¡¶¨µÄÓïÑÔÎÄ¼þÖÐ¼ÓÔØ×Ö·û´®
    '     /// </summary>
    '    /// <param name="szID"></param>
    '    /// <returns></returns>
    Public Function g_LoadString_Ex(ByVal szID As String) As String

        Dim szValue As String = ""
        Dim sldefault As String = ""
        If g_szLanguagePath = "" Then
            GetLanguagePath_Ex()
        End If
        szValue = GetINI("String", szID, sldefault, g_szLanguagePath)
        If szValue = "" Then
            szValue = "Not found"
        Else
            szValue.Replace("\\n", "\n") '//Ìæ»»»Ø»»ÐÐ·ûºÅ
        End If
        Return szValue
    End Function

    '      /// <summary>
    '     /// µ±¶Ô»°¿òÔËÐÐÊ±»ñÈ¡ÆäËùÓÐ¿ÉµÃµ½µÄ×Ö·û´®£¬²¢±£´æµ½ÓïÑÔÎÄ¼þÖÐ
    '    ///	Ã¿¸ö¿Ø¼þÓÃ¶Ô»°¿òIDºÍ¿Ø¼þIDÎ¨Ò»±êÊ¶
    '    /// </summary>
    '    /// <param name="frm"></param>
    Public Sub g_SetFormStrings_Ex(ByVal frm As Form)

        Dim szSection As String = "LockSDKDemo"
        Dim szKey As String
        Dim szText As String
        Dim bSetText As Boolean = True '//true,´ÓÎÄ¼þÖÐ¶Á£¬ÉèÖÃ´°¿Ú£»false:´Ó¶Ô»°¿ò¶Á±£´æµ½ÎÄ¼þ
        Dim c1 As Control
        If g_szLanguagePath = "" Then
            GetLanguagePath_Ex()
        End If

        If bSetText Then '//´ÓÎÄ¼þÖÐ¶Á£¬ÉèÖÃ¶Ô»°¿ò
            Dim szDefault As String
            Dim sldefault As String = ""
            '   //¶Á´°¿Ú±êÌâ
            szKey = frm.Name + "_Title"

            szDefault = GetINI(szSection, szKey, sldefault, g_szLanguagePath)
            If szDefault = "" Then

                szDefault = "Not found"

            Else

                szDefault.Replace("\\n", "\n") '//Ìæ»»»Ø»»ÐÐ·ûºÅ
            End If
            frm.Text = szDefault

            '//Ð´Èë¸÷¸ö×Ö¿Ø¼þ±êÌâ
            For Each c1 In frm.Controls

                szKey = c1.Name ' frm.Name + "_" + c1.Name
                szText = GetINI(szSection, szKey, sldefault, g_szLanguagePath)
                c1.Text = szText
            Next

        Else '//´Ó´°¿Ú±£´æµ½ÎÄ¼þ
            '//Ð´Èë´°¿Ú±êÌâ
            szKey = frm.Name + "_Title"
            szText = frm.Text
            '            Writue(szSection, szKey, szText, g_szLanguagePath)

            '   //Ð´Èë¸÷¸ö×Ó¿Ø¼þµÄ±êÌâÎÄ×Ö
            For Each c1 In frm.Controls

                szKey = frm.Name + "_" + c1.Name
                szText = c1.Text
                '  Writue(szSection, szKey, szText, g_szLanguagePath)
            Next
        End If
    End Sub


    ''  // ÉùÃ÷INIÎÄ¼þµÄÐ´²Ù×÷º¯Êý WritePrivateProfileString() 
    'Declare Function WritePrivateProfileString Lib "kernel32.dll" (ByVal section As String, ByVal key As String, ByVal val As String, ByVal filePath As String)

    '' // ÉùÃ÷INIÎÄ¼þµÄ¶Á²Ù×÷º¯Êý GetPrivateProfileString()

    'Declare Function GetPrivateProfileString Lib "kernel32.dll" (ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String)



    'Public Sub Writue(ByVal section As String, ByVal key As String, ByVal value As String, ByVal sPath As String)
    '    ' section=ÅäÖÃ½Ú£¬key=¼üÃû£¬value=¼üÖµ£¬path=Â·¾¶
    '    WritePrivateProfileString(section, key, value, sPath)
    'End Sub
    'Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal sPath As String) As String
    '    '            // Ã¿´Î´ÓiniÖÐ¶ÁÈ¡¶àÉÙ×Ö½Ú
    '    Dim temp As StringBuilder = New StringBuilder

    '    '   System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
    '    '           // section=ÅäÖÃ½Ú£¬key=¼üÃû£¬temp=ÉÏÃæ£¬path=Â·¾¶
    '    GetPrivateProfileString(section, key, "", temp, 255, sPath)
    '    ReadValue = temp.ToString()
    'End Function
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    '¶¨Áx×xÈ¡ÅäÖÃ™nº¯”µ
    Public Function GetINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As String
        Dim Str As String = LSet(Str, 256)
        GetPrivateProfileString(Section, AppName, lpDefault, Str, Len(Str), FileName)
        Return Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1)
    End Function
    '¶¨ÁxŒ‘ÈëÅäÖÃ™nº¯”µ
    Public Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As Long
        WriteINI = WritePrivateProfileString(Section, AppName, lpDefault, FileName)
    End Function
End Class


