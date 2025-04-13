Imports System.IO

Public Class Form1

    Dim Path As String
    Dim BackupPath As String
    Dim DatabaseName As String = "Backup-" + Date.Now.ToString("dd-MM-yyyy-HH-mm-ss")
    Dim mysqlDump As String = ""

    Dim myDatabase As String = ""

    Sub Backup()
        Try

            If Not Directory.Exists(BackupPath) Then
                Directory.CreateDirectory(BackupPath)
            End If

            myDatabase = GunaTextBoxDatabaseName.Text
            'Process.Start("[MySQL Dump File Location]", "-u [USERNAME] -p [YOUR PASSWORD] [DATABASE THAT YOU WANT TO BACKUP] -r ""[OUTPUT LOCATION INCLUDE .SQL EXTENSION]""")

            'WAMP Server
            'Process.Start("C:\wamp64\bin\mysql\mysql5.7.14\bin\mysqldump.exe", "-u root skripsi -r """ & BackupPath & "" & DatabaseName & ".sql""")
            'Process.Start("C:\wamp\bin\mysql\mysql5.6.17\bin\mysqldump.exe", "-u root " + myDatabase + " -r """ & BackupPath & "" & DatabaseName & ".sql""")
            Process.Start(mysqlDump, "-u root " + myDatabase + " -r """ & BackupPath & "" & DatabaseName & ".sql""")

            'XAMPP SERVER
            'Process.Start("C:\xampp\mysql\bin\mysqldump.exe", "-u root skripsi -r """ & BackupPath & "" & DatabaseName & ".sql""")

            'MySQL 8.0 Above
            'Process.Start("C:\wamp64\bin\mysql\mysql8.0.21\bin\mysqldump.exe", "--replace --column-statistics=0 -u root -proot --databases audioelektronik -r """ & BackupPath & "" & DatabaseName & ".sql""")
            MsgBox("Backup Created Successfully!", MsgBoxStyle.Information, "Backup")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Sub Restore()

        myDatabase = GunaTextBoxDatabaseName.Text

        Dim myProcess As New Process()

        myProcess.StartInfo.FileName = "cmd.exe"
        myProcess.StartInfo.UseShellExecute = False
        'myProcess.StartInfo.WorkingDirectory = "C:\wamp64\bin\mysql\mysql8.0.21\bin"
        'myProcess.StartInfo.WorkingDirectory = "C:\wamp\bin\mysql\mysql5.6.17\bin"
        myProcess.StartInfo.WorkingDirectory = mysqlDump
        myProcess.StartInfo.RedirectStandardInput = True
        myProcess.StartInfo.RedirectStandardOutput = True
        myProcess.Start()
        Dim myStreamerWriter As StreamWriter = myProcess.StandardInput
        Dim myStreamerReader As StreamReader = myProcess.StandardOutput

        'myStreamerWriter.WriteLine("mysql -u [USERNAME] -p [PASSWORD] [YOUR DATABASE NAME] < [DATABASE THAT YOU ALREADY BACKUP FILE PATH]")
        'myStreamerWriter.WriteLine("mysql -u root -p root audioelektronik < " & Path & "")
        myStreamerWriter.WriteLine("mysql -u root " + myDatabase + " < " & Path & "")
        myStreamerWriter.Close()
        myProcess.WaitForExit()
        myProcess.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        BackupPath = FolderBrowserDialog1.SelectedPath.ToString() + "\"
        Backup()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Title = "Please Select a File"
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Path = OpenFileDialog1.FileName.ToString()
        Restore()
        MsgBox("Database Restoration Successfully!", MsgBoxStyle.Information, "Restore")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
