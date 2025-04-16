Imports System.Net   'Web
Imports System.IO    'Files
Imports MySql.Data.MySqlClient

Public Class DataBaseBackUpForm

    Dim Path As String
    Dim BackupPath As String
    Dim DatabaseName As String = "Backup-" + Date.Now.ToString("dd-MM-yyyy-HH-mm-ss")

    Dim mysqlDump As String = ""

    'Dim user As String = "u635472668"
    'Dim password As String = "Klg160590@"
    'Dim ftp As String = "ftp://145.223.89.103"

    Dim user As String = ""
    Dim password As String = ""
    Dim ftp As String = ""

    Dim file_to_transfer As String = ""

    Sub Backup()

        Try

            If Not Directory.Exists(BackupPath) Then
                Directory.CreateDirectory(BackupPath)
            End If
            'Process.Start("[MySQL Dump File Location]", "-u [USERNAME] -p [YOUR PASSWORD] [DATABASE THAT YOU WANT TO BACKUP] -r ""[OUTPUT LOCATION INCLUDE .SQL EXTENSION]""")

            'If GunaComboBoxServerType.SelectedIndex = 0 Then
            'WAMP Server
            'Process.Start("C:\wamp64\bin\mysql\mysql5.7.14\bin\mysqldump.exe", "-u root skripsi -r """ & BackupPath & "" & DatabaseName & ".sql""")
            'Process.Start("C:\wamp\bin\mysql\mysql5.6.17\bin\mysqldump.exe", "-u root " + GlobalVariable.softwareVersion + " -r """ & BackupPath & "" & DatabaseName & ".sql""")
            'Process.Start(mysqlDump, "-u root " + GlobalVariable.softwareVersion + " -r """ & BackupPath & "" & DatabaseName & ".sql""")

            'ElseIf GunaComboBoxServerType.SelectedIndex = 1 Then
            'XAMPP SERVER
            'Process.Start("C:\xampp\mysql\bin\mysqldump.exe", "-u root skripsi -r """ & BackupPath & "" & DatabaseName & ".sql""")
            'Process.Start(mysqlDump, "-u root " + GlobalVariable.softwareVersion + " -r """ & BackupPath & "" & DatabaseName & ".sql""")
            'ElseIf GunaComboBoxServerType.SelectedIndex = 2 Then
            'MySQL 8.0 Above
            'Process.Start("C:\wamp64\bin\mysql\mysql8.0.21\bin\mysqldump.exe", "--replace --column-statistics=0 -u root -proot --databases audioelektronik -r """ & BackupPath & "" & DatabaseName & ".sql""")
            'End If

            Process.Start(mysqlDump, "-u root " + GlobalVariable.softwareVersion + " -r """ & BackupPath & "" & DatabaseName & ".sql""")

            'MsgBox("Backup Created Successfully!", MsgBoxStyle.Information, "Backup")

            Dim agence As New Agency()
            Dim FICHIER As String = DatabaseName & ".sql"
            Dim CHEMIN As String = BackupPath + FICHIER
            agence.serveur_ftp_last_backup(FICHIER, CHEMIN)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Close()

    End Sub

    Private Sub GunaButtonBackup_Click(sender As Object, e As EventArgs) Handles GunaButtonBackup.Click
        'FolderBrowserDialog1.ShowDialog()
        'BackupPath = FolderBrowserDialog1.SelectedPath.ToString() + "\"
        BackupPath = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") + "\DB\"
        Backup()

        GlobalVariable.server_ftp = Functions.allTableFields("serveur_ftp")

    End Sub

    Private Sub DataBaseBackUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.DatabaseBackup(GlobalVariable.actualLanguageValue)

        'mysqlDump = lectureDumpFromTextFile()

        If Not GlobalVariable.server_ftp Is Nothing Then
            If GlobalVariable.server_ftp.Rows.Count > 0 Then
                mysqlDump = GlobalVariable.server_ftp.Rows(0)("MYSQL_DUMP")
                ftp = GlobalVariable.server_ftp.Rows(0)("HOTE")
                user = GlobalVariable.server_ftp.Rows(0)("NOM_UTILISATEUR")
                password = GlobalVariable.server_ftp.Rows(0)("MOT_DE_PASSE")
            End If
        End If

    End Sub

    Private Function lectureDumpFromTextFile()

        'Element d'un fichier end '
        Dim path As String = "C:\dump.txt"

        Dim monStreamReader As StreamReader = New StreamReader(path)

        Dim ligne As String = ""
        Dim i As Integer = 0

        Dim mysqlDump As String = ""

        Do
            ligne = monStreamReader.ReadLine()

            If i = 0 Then
                mysqlDump = Trim(ligne)
            End If

            i += 1

        Loop Until ligne Is Nothing

        monStreamReader.Close()

        Return mysqlDump

    End Function

    Public Sub transfer_file()

        'Upload File to FTP site

        'Create Request To Upload File'
        'Dim wrUpload As FtpWebRequest = DirectCast(WebRequest.Create(ftp + "/" + DatabaseName & ".sql"), FtpWebRequest)
        Dim DatabaseFile As String = GlobalVariable.server_ftp.Rows(0)("FICHIER")
        Dim wrUpload As FtpWebRequest = DirectCast(WebRequest.Create(ftp + "/" + DatabaseFile), FtpWebRequest)

        'Specify Username & Password'
        wrUpload.Credentials = New NetworkCredential(user, password)

        'Start Upload Process'
        wrUpload.Method = WebRequestMethods.Ftp.UploadFile

        'Locate File And Store It In Byte Array'
        'Dim btfile() As Byte = File.ReadAllBytes("C:/Backup-11-04-2025-02-40-21.sql")

        file_to_transfer = GlobalVariable.server_ftp.Rows(0)("CHEMIN")
        Dim btfile() As Byte = File.ReadAllBytes(file_to_transfer)

        'Get File'
        Dim strFile As Stream = wrUpload.GetRequestStream()

        'Upload Each Byte'
        strFile.Write(btfile, 0, btfile.Length)

        'Close'
        strFile.Close()

        'Free Memory'
        strFile.Dispose()

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim haveInternet As Boolean = Functions.checkInternetCOnnection()

        If haveInternet Then

            Try
                transfer_file()
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        BackgroundWorker1.Dispose()
        Me.Close()
    End Sub

    Private Sub GunaButtonTransfert_Click(sender As Object, e As EventArgs) Handles GunaButtonTransfert.Click
        transfer_file()
    End Sub

    Dim i As Integer = 0

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        i += 1
        GunaProgressBar1.Value = 1
    End Sub
End Class