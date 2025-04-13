<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfilChoixForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GunaComboBoxProfils = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonAjouter = New Guna.UI.WinForms.GunaButton()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Indigo
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(359, 11)
        Me.Panel2.TabIndex = 11
        '
        'GunaComboBoxProfils
        '
        Me.GunaComboBoxProfils.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxProfils.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxProfils.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxProfils.BorderSize = 1
        Me.GunaComboBoxProfils.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxProfils.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxProfils.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxProfils.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxProfils.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxProfils.FormattingEnabled = True
        Me.GunaComboBoxProfils.ItemHeight = 25
        Me.GunaComboBoxProfils.Location = New System.Drawing.Point(10, 52)
        Me.GunaComboBoxProfils.Name = "GunaComboBoxProfils"
        Me.GunaComboBoxProfils.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxProfils.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxProfils.Radius = 5
        Me.GunaComboBoxProfils.Size = New System.Drawing.Size(250, 31)
        Me.GunaComboBoxProfils.TabIndex = 10
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GunaLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GunaLabel1.Location = New System.Drawing.Point(10, 24)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(160, 17)
        Me.GunaLabel1.TabIndex = 9
        Me.GunaLabel1.Text = "Choisir le Profile à utiliser"
        Me.GunaLabel1.UseWaitCursor = True
        '
        'GunaButtonAjouter
        '
        Me.GunaButtonAjouter.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAjouter.AnimationSpeed = 0.03!
        Me.GunaButtonAjouter.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAjouter.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAjouter.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouter.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAjouter.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAjouter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAjouter.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouter.Image = Nothing
        Me.GunaButtonAjouter.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAjouter.Location = New System.Drawing.Point(269, 53)
        Me.GunaButtonAjouter.Name = "GunaButtonAjouter"
        Me.GunaButtonAjouter.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAjouter.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouter.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouter.OnHoverImage = Nothing
        Me.GunaButtonAjouter.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAjouter.Radius = 4
        Me.GunaButtonAjouter.Size = New System.Drawing.Size(81, 28)
        Me.GunaButtonAjouter.TabIndex = 102
        Me.GunaButtonAjouter.Text = "Valider"
        Me.GunaButtonAjouter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaElipse1
        '
        Me.GunaElipse1.Radius = 3
        Me.GunaElipse1.TargetControl = Me
        '
        'ProfilChoixForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(359, 97)
        Me.Controls.Add(Me.GunaButtonAjouter)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GunaComboBoxProfils)
        Me.Controls.Add(Me.GunaLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProfilChoixForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProfilChoixForm"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents GunaComboBoxProfils As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonAjouter As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
End Class
