Imports System.IO
Imports MySql.Data.MySqlClient

Public Class DataBaseBackUpForm

    Dim Path As String
    Dim BackupPath As String
    Dim DatabaseName As String = "Backup-" + Date.Now.ToString("dd-MM-yyyy-HH-mm-ss")

    Dim mysqlDump As String = ""

    Sub Backup()

        Try

            If Not Directory.Exists(BackupPath) Then
                Directory.CreateDirectory(BackupPath)
            End If
            'Process.Start("[MySQL Dump File Location]", "-u [USERNAME] -p [YOUR PASSWORD] [DATABASE THAT YOU WANT TO BACKUP] -r ""[OUTPUT LOCATION INCLUDE .SQL EXTENSION]""")

            If GunaComboBoxServerType.SelectedIndex = 0 Then
                'WAMP Server
                'Process.Start("C:\wamp64\bin\mysql\mysql5.7.14\bin\mysqldump.exe", "-u root skripsi -r """ & BackupPath & "" & DatabaseName & ".sql""")
                'Process.Start("C:\wamp\bin\mysql\mysql5.6.17\bin\mysqldump.exe", "-u root " + GlobalVariable.softwareVersion + " -r """ & BackupPath & "" & DatabaseName & ".sql""")
                Process.Start(mysqlDump, "-u root " + GlobalVariable.softwareVersion + " -r """ & BackupPath & "" & DatabaseName & ".sql""")

            ElseIf GunaComboBoxServerType.SelectedIndex = 1 Then
                'XAMPP SERVER
                'Process.Start("C:\xampp\mysql\bin\mysqldump.exe", "-u root skripsi -r """ & BackupPath & "" & DatabaseName & ".sql""")
                Process.Start(mysqlDump, "-u root " + GlobalVariable.softwareVersion + " -r """ & BackupPath & "" & DatabaseName & ".sql""")
            ElseIf GunaComboBoxServerType.SelectedIndex = 2 Then
                'MySQL 8.0 Above
                'Process.Start("C:\wamp64\bin\mysql\mysql8.0.21\bin\mysqldump.exe", "--replace --column-statistics=0 -u root -proot --databases audioelektronik -r """ & BackupPath & "" & DatabaseName & ".sql""")
            End If

            Me.Close()

            MsgBox("Backup Created Successfully!", MsgBoxStyle.Information, "Backup")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GunaButtonBackup_Click(sender As Object, e As EventArgs) Handles GunaButtonBackup.Click
        FolderBrowserDialog1.ShowDialog()
        BackupPath = FolderBrowserDialog1.SelectedPath.ToString() + "\"
        Backup()
    End Sub

    Private Sub DataBaseBackUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.DatabaseBackup(GlobalVariable.actualLanguageValue)

        GunaComboBoxServerType.SelectedIndex = 0

        mysqlDump = lectureDump()

    End Sub

    Private Function lectureDump()

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
End Class