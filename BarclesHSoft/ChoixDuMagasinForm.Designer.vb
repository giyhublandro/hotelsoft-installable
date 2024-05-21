<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChoixDuMagasinForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChoixDuMagasinForm))
        Me.GunaButtonOuvrirSession = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBoxMagasins = New Guna.UI.WinForms.GunaComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaComboBoxShift = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.SuspendLayout()
        '
        'GunaButtonOuvrirSession
        '
        Me.GunaButtonOuvrirSession.AnimationHoverSpeed = 0.07!
        Me.GunaButtonOuvrirSession.AnimationSpeed = 0.03!
        Me.GunaButtonOuvrirSession.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonOuvrirSession.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonOuvrirSession.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonOuvrirSession.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonOuvrirSession.FocusedColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GunaButtonOuvrirSession, "GunaButtonOuvrirSession")
        Me.GunaButtonOuvrirSession.ForeColor = System.Drawing.Color.White
        Me.GunaButtonOuvrirSession.Image = Nothing
        Me.GunaButtonOuvrirSession.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonOuvrirSession.Name = "GunaButtonOuvrirSession"
        Me.GunaButtonOuvrirSession.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonOuvrirSession.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonOuvrirSession.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonOuvrirSession.OnHoverImage = Nothing
        Me.GunaButtonOuvrirSession.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonOuvrirSession.Radius = 4
        Me.GunaButtonOuvrirSession.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel1
        '
        resources.ApplyResources(Me.GunaLabel1, "GunaLabel1")
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.UseWaitCursor = True
        '
        'GunaComboBoxMagasins
        '
        Me.GunaComboBoxMagasins.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxMagasins.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxMagasins.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxMagasins.BorderSize = 1
        Me.GunaComboBoxMagasins.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxMagasins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxMagasins.FocusedColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GunaComboBoxMagasins, "GunaComboBoxMagasins")
        Me.GunaComboBoxMagasins.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxMagasins.FormattingEnabled = True
        Me.GunaComboBoxMagasins.Name = "GunaComboBoxMagasins"
        Me.GunaComboBoxMagasins.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxMagasins.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxMagasins.Radius = 5
        Me.GunaComboBoxMagasins.UseWaitCursor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Indigo
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Indigo
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'GunaElipse1
        '
        Me.GunaElipse1.Radius = 10
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaComboBoxShift
        '
        Me.GunaComboBoxShift.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxShift.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxShift.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxShift.BorderSize = 1
        Me.GunaComboBoxShift.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxShift.FocusedColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GunaComboBoxShift, "GunaComboBoxShift")
        Me.GunaComboBoxShift.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxShift.FormattingEnabled = True
        Me.GunaComboBoxShift.Items.AddRange(New Object() {resources.GetString("GunaComboBoxShift.Items"), resources.GetString("GunaComboBoxShift.Items1"), resources.GetString("GunaComboBoxShift.Items2")})
        Me.GunaComboBoxShift.Name = "GunaComboBoxShift"
        Me.GunaComboBoxShift.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxShift.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxShift.Radius = 5
        Me.GunaComboBoxShift.UseWaitCursor = True
        '
        'GunaLabel2
        '
        resources.ApplyResources(Me.GunaLabel2, "GunaLabel2")
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.UseWaitCursor = True
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GunaButton1, "GunaButton1")
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChoixDuMagasinForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MistyRose
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GunaComboBoxShift)
        Me.Controls.Add(Me.GunaComboBoxMagasins)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaButtonOuvrirSession)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChoixDuMagasinForm"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaButtonOuvrirSession As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaComboBoxMagasins As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaComboBoxShift As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
End Class
