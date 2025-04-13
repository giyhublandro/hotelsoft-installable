<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataBaseBackUpForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataBaseBackUpForm))
        Me.GunaComboBoxServerType = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaButtonBackup = New Guna.UI.WinForms.GunaButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.SuspendLayout()
        '
        'GunaComboBoxServerType
        '
        Me.GunaComboBoxServerType.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxServerType.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxServerType.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxServerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxServerType.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxServerType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxServerType.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxServerType.FormattingEnabled = True
        Me.GunaComboBoxServerType.ItemHeight = 25
        Me.GunaComboBoxServerType.Items.AddRange(New Object() {"Wamp", "Xampp", "MySQL 8.0 >"})
        Me.GunaComboBoxServerType.Location = New System.Drawing.Point(76, 10)
        Me.GunaComboBoxServerType.Name = "GunaComboBoxServerType"
        Me.GunaComboBoxServerType.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxServerType.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxServerType.Radius = 4
        Me.GunaComboBoxServerType.Size = New System.Drawing.Size(219, 31)
        Me.GunaComboBoxServerType.TabIndex = 0
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
        Me.GunaButtonBackup.Location = New System.Drawing.Point(303, 10)
        Me.GunaButtonBackup.Name = "GunaButtonBackup"
        Me.GunaButtonBackup.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonBackup.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonBackup.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonBackup.OnHoverImage = Nothing
        Me.GunaButtonBackup.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonBackup.Radius = 4
        Me.GunaButtonBackup.Size = New System.Drawing.Size(97, 30)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(8, 15)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(64, 21)
        Me.GunaLabel1.TabIndex = 3
        Me.GunaLabel1.Text = "Serveur"
        '
        'DataBaseBackUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 112)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaButtonBackup)
        Me.Controls.Add(Me.GunaComboBoxServerType)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DataBaseBackUpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DataBase BackUp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaComboBoxServerType As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaButtonBackup As Guna.UI.WinForms.GunaButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
End Class
