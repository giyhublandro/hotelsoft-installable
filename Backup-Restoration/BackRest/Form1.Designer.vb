<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GunaTextBoxDatabaseName = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 37)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Backup"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(197, 50)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 37)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Restore"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GunaTextBoxDatabaseName
        '
        Me.GunaTextBoxDatabaseName.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxDatabaseName.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxDatabaseName.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxDatabaseName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxDatabaseName.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxDatabaseName.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxDatabaseName.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxDatabaseName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxDatabaseName.Location = New System.Drawing.Point(85, 11)
        Me.GunaTextBoxDatabaseName.Name = "GunaTextBoxDatabaseName"
        Me.GunaTextBoxDatabaseName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxDatabaseName.Radius = 4
        Me.GunaTextBoxDatabaseName.SelectedText = ""
        Me.GunaTextBoxDatabaseName.Size = New System.Drawing.Size(187, 30)
        Me.GunaTextBoxDatabaseName.TabIndex = 2
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(10, 19)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(55, 15)
        Me.GunaLabel1.TabIndex = 3
        Me.GunaLabel1.Text = "DataBase"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 97)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaTextBoxDatabaseName)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Backup Restore"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents GunaTextBoxDatabaseName As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
End Class
