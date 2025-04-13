<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GenerationForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerationForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelNomAuth = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonAfficherValidee = New Guna.UI.WinForms.GunaButton()
        Me.GunaComboBoxAction = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaComboBoxUtilisateur = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBoxCode = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl3 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaLinePanelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 202)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(428, 10)
        Me.Panel1.TabIndex = 22
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton2)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelNomAuth)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(427, 33)
        Me.GunaLinePanelTop.TabIndex = 21
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(397, 6)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 9
        '
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = Nothing
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(388, 6)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 8
        '
        'GunaLabelNomAuth
        '
        Me.GunaLabelNomAuth.AutoSize = True
        Me.GunaLabelNomAuth.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelNomAuth.Location = New System.Drawing.Point(120, 6)
        Me.GunaLabelNomAuth.Name = "GunaLabelNomAuth"
        Me.GunaLabelNomAuth.Size = New System.Drawing.Size(158, 21)
        Me.GunaLabelNomAuth.TabIndex = 13
        Me.GunaLabelNomAuth.Text = "AUTHENTIFICATION"
        Me.GunaLabelNomAuth.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaButtonAfficherValidee
        '
        Me.GunaButtonAfficherValidee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonAfficherValidee.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAfficherValidee.AnimationSpeed = 0.03!
        Me.GunaButtonAfficherValidee.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAfficherValidee.BaseColor = System.Drawing.Color.Indigo
        Me.GunaButtonAfficherValidee.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficherValidee.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAfficherValidee.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAfficherValidee.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaButtonAfficherValidee.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficherValidee.Image = Nothing
        Me.GunaButtonAfficherValidee.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAfficherValidee.Location = New System.Drawing.Point(300, 93)
        Me.GunaButtonAfficherValidee.Name = "GunaButtonAfficherValidee"
        Me.GunaButtonAfficherValidee.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAfficherValidee.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficherValidee.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficherValidee.OnHoverImage = Nothing
        Me.GunaButtonAfficherValidee.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAfficherValidee.Radius = 5
        Me.GunaButtonAfficherValidee.Size = New System.Drawing.Size(114, 32)
        Me.GunaButtonAfficherValidee.TabIndex = 115
        Me.GunaButtonAfficherValidee.Text = "Envoyer"
        Me.GunaButtonAfficherValidee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaComboBoxAction
        '
        Me.GunaComboBoxAction.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxAction.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxAction.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxAction.BorderSize = 1
        Me.GunaComboBoxAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxAction.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxAction.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxAction.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxAction.FormattingEnabled = True
        Me.GunaComboBoxAction.ItemHeight = 24
        Me.GunaComboBoxAction.Items.AddRange(New Object() {"Changer prix hébergement", "Annuler Check In", "Annuler Charge", "Reduction Charges"})
        Me.GunaComboBoxAction.Location = New System.Drawing.Point(12, 95)
        Me.GunaComboBoxAction.Name = "GunaComboBoxAction"
        Me.GunaComboBoxAction.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxAction.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxAction.Radius = 5
        Me.GunaComboBoxAction.Size = New System.Drawing.Size(265, 30)
        Me.GunaComboBoxAction.TabIndex = 116
        '
        'GunaComboBoxUtilisateur
        '
        Me.GunaComboBoxUtilisateur.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxUtilisateur.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxUtilisateur.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxUtilisateur.BorderSize = 1
        Me.GunaComboBoxUtilisateur.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxUtilisateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxUtilisateur.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxUtilisateur.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxUtilisateur.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxUtilisateur.FormattingEnabled = True
        Me.GunaComboBoxUtilisateur.ItemHeight = 24
        Me.GunaComboBoxUtilisateur.Items.AddRange(New Object() {"Changer prix hébergement", "Annuler Check In"})
        Me.GunaComboBoxUtilisateur.Location = New System.Drawing.Point(12, 57)
        Me.GunaComboBoxUtilisateur.Name = "GunaComboBoxUtilisateur"
        Me.GunaComboBoxUtilisateur.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxUtilisateur.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxUtilisateur.Radius = 5
        Me.GunaComboBoxUtilisateur.Size = New System.Drawing.Size(401, 30)
        Me.GunaComboBoxUtilisateur.TabIndex = 116
        '
        'GunaTextBoxCode
        '
        Me.GunaTextBoxCode.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCode.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCode.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxCode.BorderSize = 1
        Me.GunaTextBoxCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCode.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCode.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCode.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCode.Location = New System.Drawing.Point(12, 164)
        Me.GunaTextBoxCode.Name = "GunaTextBoxCode"
        Me.GunaTextBoxCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCode.Radius = 3
        Me.GunaTextBoxCode.SelectedText = ""
        Me.GunaTextBoxCode.Size = New System.Drawing.Size(135, 30)
        Me.GunaTextBoxCode.TabIndex = 118
        Me.GunaTextBoxCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButton1
        '
        Me.GunaButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.Indigo
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(166, 162)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 5
        Me.GunaButton1.Size = New System.Drawing.Size(114, 32)
        Me.GunaButton1.TabIndex = 115
        Me.GunaButton1.Text = "Valider"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(160, 140)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(69, 15)
        Me.GunaLabel1.TabIndex = 119
        Me.GunaLabel1.Text = "GunaLabel1"
        Me.GunaLabel1.Visible = False
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(15, 38)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(69, 15)
        Me.GunaLabel2.TabIndex = 120
        Me.GunaLabel2.Text = "GunaLabel2"
        Me.GunaLabel2.Visible = False
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLinePanelTop
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaLabelNomAuth
        '
        'GunaDragControl3
        '
        Me.GunaDragControl3.TargetControl = Me
        '
        'GunaElipse1
        '
        Me.GunaElipse1.Radius = 10
        Me.GunaElipse1.TargetControl = Me
        '
        'GenerationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 212)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaTextBoxCode)
        Me.Controls.Add(Me.GunaComboBoxUtilisateur)
        Me.Controls.Add(Me.GunaComboBoxAction)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaButtonAfficherValidee)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GenerationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GenerationForm"
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelNomAuth As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonAfficherValidee As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaComboBoxAction As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaComboBoxUtilisateur As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxCode As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl3 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
End Class
