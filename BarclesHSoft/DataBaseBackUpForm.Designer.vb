<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataBaseBackUpForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataBaseBackUpForm))
        Me.GunaButtonBackup = New Guna.UI.WinForms.GunaButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GunaButtonTransfert = New Guna.UI.WinForms.GunaButton()
        Me.GunaProgressBar1 = New Guna.UI.WinForms.GunaProgressBar()
        Me.SuspendLayout()
        '
        'GunaButtonBackup
        '
        Me.GunaButtonBackup.AnimationHoverSpeed = 0.07!
        Me.GunaButtonBackup.AnimationSpeed = 0.03!
        Me.GunaButtonBackup.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonBackup.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonBackup.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonBackup.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonBackup.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonBackup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButtonBackup.ForeColor = System.Drawing.Color.White
        Me.GunaButtonBackup.Image = CType(resources.GetObject("GunaButtonBackup.Image"), System.Drawing.Image)
        Me.GunaButtonBackup.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonBackup.Location = New System.Drawing.Point(121, 11)
        Me.GunaButtonBackup.Name = "GunaButtonBackup"
        Me.GunaButtonBackup.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonBackup.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonBackup.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonBackup.OnHoverImage = Nothing
        Me.GunaButtonBackup.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonBackup.Radius = 4
        Me.GunaButtonBackup.Size = New System.Drawing.Size(111, 30)
        Me.GunaButtonBackup.TabIndex = 2
        Me.GunaButtonBackup.Text = "BACK UP"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(17, 16)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(83, 21)
        Me.GunaLabel1.TabIndex = 3
        Me.GunaLabel1.Text = "DATABASE"
        '
        'BackgroundWorker1
        '
        '
        'GunaButtonTransfert
        '
        Me.GunaButtonTransfert.AnimationHoverSpeed = 0.07!
        Me.GunaButtonTransfert.AnimationSpeed = 0.03!
        Me.GunaButtonTransfert.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonTransfert.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonTransfert.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonTransfert.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonTransfert.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonTransfert.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButtonTransfert.ForeColor = System.Drawing.Color.White
        Me.GunaButtonTransfert.Image = CType(resources.GetObject("GunaButtonTransfert.Image"), System.Drawing.Image)
        Me.GunaButtonTransfert.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonTransfert.Location = New System.Drawing.Point(282, 11)
        Me.GunaButtonTransfert.Name = "GunaButtonTransfert"
        Me.GunaButtonTransfert.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonTransfert.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonTransfert.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonTransfert.OnHoverImage = Nothing
        Me.GunaButtonTransfert.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonTransfert.Radius = 4
        Me.GunaButtonTransfert.Size = New System.Drawing.Size(110, 30)
        Me.GunaButtonTransfert.TabIndex = 2
        Me.GunaButtonTransfert.Text = "TRANSFERT"
        '
        'GunaProgressBar1
        '
        Me.GunaProgressBar1.BorderColor = System.Drawing.Color.Black
        Me.GunaProgressBar1.ColorStyle = Guna.UI.WinForms.ColorStyle.[Default]
        Me.GunaProgressBar1.IdleColor = System.Drawing.Color.Gainsboro
        Me.GunaProgressBar1.Location = New System.Drawing.Point(58, 47)
        Me.GunaProgressBar1.Name = "GunaProgressBar1"
        Me.GunaProgressBar1.ProgressMaxColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaProgressBar1.ProgressMinColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaProgressBar1.Size = New System.Drawing.Size(334, 23)
        Me.GunaProgressBar1.TabIndex = 4
        '
        'DataBaseBackUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 73)
        Me.Controls.Add(Me.GunaProgressBar1)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaButtonTransfert)
        Me.Controls.Add(Me.GunaButtonBackup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DataBaseBackUpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DataBase BackUp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaButtonBackup As Guna.UI.WinForms.GunaButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GunaButtonTransfert As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaProgressBar1 As Guna.UI.WinForms.GunaProgressBar
End Class
