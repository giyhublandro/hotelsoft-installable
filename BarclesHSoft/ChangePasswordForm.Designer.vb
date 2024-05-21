<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChangePasswordForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePasswordForm))
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GunaTextBox1 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelGestUsers = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxCeode = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNomUser = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButton3 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxAncienPasse = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNewPasse = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxConfirmPasse = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLinePanelTop.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton4)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.Panel5)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelGestUsers)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(450, 33)
        Me.GunaLinePanelTop.TabIndex = 11
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(417, 7)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 9
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(411, 6)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 8
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel4)
        Me.Panel5.Location = New System.Drawing.Point(110, 39)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(789, 33)
        Me.Panel5.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GunaTextBox1)
        Me.Panel4.Controls.Add(Me.GunaLabel1)
        Me.Panel4.Location = New System.Drawing.Point(0, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(135, 30)
        Me.Panel4.TabIndex = 2
        '
        'GunaTextBox1
        '
        Me.GunaTextBox1.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox1.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox1.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox1.Location = New System.Drawing.Point(72, -11)
        Me.GunaTextBox1.Name = "GunaTextBox1"
        Me.GunaTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox1.SelectedText = ""
        Me.GunaTextBox1.Size = New System.Drawing.Size(160, 30)
        Me.GunaTextBox1.TabIndex = 8
        Me.GunaTextBox1.Text = "GunaTextBox1"
        '
        'GunaLabel1
        '
        Me.GunaLabel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(48, 13)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(99, 17)
        Me.GunaLabel1.TabIndex = 96
        Me.GunaLabel1.Text = "Nom Utilisateur"
        '
        'GunaLabelGestUsers
        '
        Me.GunaLabelGestUsers.AutoSize = True
        Me.GunaLabelGestUsers.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestUsers.Location = New System.Drawing.Point(89, 6)
        Me.GunaLabelGestUsers.Name = "GunaLabelGestUsers"
        Me.GunaLabelGestUsers.Size = New System.Drawing.Size(228, 21)
        Me.GunaLabelGestUsers.TabIndex = 13
        Me.GunaLabelGestUsers.Text = "Changement du Mot de Passe"
        Me.GunaLabelGestUsers.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLinePanelTop
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaLabelGestUsers
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(210, 552)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(156, 40)
        Me.GunaButton1.TabIndex = 3
        Me.GunaButton1.Text = "Fermer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton2.ForeColor = System.Drawing.Color.White
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(383, 552)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 4
        Me.GunaButton2.Size = New System.Drawing.Size(156, 40)
        Me.GunaButton2.TabIndex = 3
        Me.GunaButton2.Text = "Enregistrer"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxCeode
        '
        Me.GunaTextBoxCeode.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCeode.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCeode.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCeode.BorderSize = 1
        Me.GunaTextBoxCeode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCeode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCeode.Enabled = False
        Me.GunaTextBoxCeode.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCeode.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCeode.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCeode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCeode.Location = New System.Drawing.Point(12, 64)
        Me.GunaTextBoxCeode.Name = "GunaTextBoxCeode"
        Me.GunaTextBoxCeode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCeode.Radius = 5
        Me.GunaTextBoxCeode.SelectedText = ""
        Me.GunaTextBoxCeode.Size = New System.Drawing.Size(140, 30)
        Me.GunaTextBoxCeode.TabIndex = 4
        Me.GunaTextBoxCeode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxNomUser
        '
        Me.GunaTextBoxNomUser.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNomUser.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomUser.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNomUser.BorderSize = 1
        Me.GunaTextBoxNomUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNomUser.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNomUser.Enabled = False
        Me.GunaTextBoxNomUser.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomUser.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNomUser.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNomUser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNomUser.Location = New System.Drawing.Point(182, 64)
        Me.GunaTextBoxNomUser.Name = "GunaTextBoxNomUser"
        Me.GunaTextBoxNomUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNomUser.Radius = 5
        Me.GunaTextBoxNomUser.SelectedText = ""
        Me.GunaTextBoxNomUser.Size = New System.Drawing.Size(256, 30)
        Me.GunaTextBoxNomUser.TabIndex = 5
        Me.GunaTextBoxNomUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(12, 39)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(76, 20)
        Me.GunaLabel2.TabIndex = 5
        Me.GunaLabel2.Text = "Utilisateur"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(5, 116)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(145, 20)
        Me.GunaLabel3.TabIndex = 5
        Me.GunaLabel3.Text = "Ancien Mot de Passe"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(5, 169)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(159, 20)
        Me.GunaLabel4.TabIndex = 5
        Me.GunaLabel4.Text = "Nouveau Mot de Passe"
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(5, 218)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(166, 20)
        Me.GunaLabel5.TabIndex = 5
        Me.GunaLabel5.Text = "Confirmer Mot de Passe"
        '
        'GunaButton3
        '
        Me.GunaButton3.AnimationHoverSpeed = 0.07!
        Me.GunaButton3.AnimationSpeed = 0.03!
        Me.GunaButton3.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton3.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton3.BorderColor = System.Drawing.Color.Black
        Me.GunaButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton3.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton3.ForeColor = System.Drawing.Color.White
        Me.GunaButton3.Image = Nothing
        Me.GunaButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton3.Location = New System.Drawing.Point(30, 268)
        Me.GunaButton3.Name = "GunaButton3"
        Me.GunaButton3.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton3.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton3.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton3.OnHoverImage = Nothing
        Me.GunaButton3.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton3.Radius = 4
        Me.GunaButton3.Size = New System.Drawing.Size(112, 34)
        Me.GunaButton3.TabIndex = 6
        Me.GunaButton3.Text = "Annuler"
        Me.GunaButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonEnregistrer
        '
        Me.GunaButtonEnregistrer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEnregistrer.AnimationSpeed = 0.03!
        Me.GunaButtonEnregistrer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEnregistrer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEnregistrer.Enabled = False
        Me.GunaButtonEnregistrer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEnregistrer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEnregistrer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.Image = Nothing
        Me.GunaButtonEnregistrer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(307, 268)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(112, 34)
        Me.GunaButtonEnregistrer.TabIndex = 3
        Me.GunaButtonEnregistrer.TabStop = False
        Me.GunaButtonEnregistrer.Text = "Enregistrer"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 309)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(450, 10)
        Me.GunaPanel1.TabIndex = 14
        '
        'GunaTextBoxAncienPasse
        '
        Me.GunaTextBoxAncienPasse.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAncienPasse.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAncienPasse.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxAncienPasse.BorderSize = 1
        Me.GunaTextBoxAncienPasse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAncienPasse.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAncienPasse.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAncienPasse.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAncienPasse.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxAncienPasse.Location = New System.Drawing.Point(182, 113)
        Me.GunaTextBoxAncienPasse.Name = "GunaTextBoxAncienPasse"
        Me.GunaTextBoxAncienPasse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.GunaTextBoxAncienPasse.Radius = 5
        Me.GunaTextBoxAncienPasse.SelectedText = ""
        Me.GunaTextBoxAncienPasse.Size = New System.Drawing.Size(256, 26)
        Me.GunaTextBoxAncienPasse.TabIndex = 0
        Me.GunaTextBoxAncienPasse.UseSystemPasswordChar = True
        '
        'GunaTextBoxNewPasse
        '
        Me.GunaTextBoxNewPasse.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNewPasse.BaseColor = System.Drawing.Color.LightPink
        Me.GunaTextBoxNewPasse.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxNewPasse.BorderSize = 1
        Me.GunaTextBoxNewPasse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNewPasse.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNewPasse.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNewPasse.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNewPasse.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxNewPasse.Location = New System.Drawing.Point(182, 166)
        Me.GunaTextBoxNewPasse.Name = "GunaTextBoxNewPasse"
        Me.GunaTextBoxNewPasse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.GunaTextBoxNewPasse.Radius = 5
        Me.GunaTextBoxNewPasse.SelectedText = ""
        Me.GunaTextBoxNewPasse.Size = New System.Drawing.Size(256, 26)
        Me.GunaTextBoxNewPasse.TabIndex = 1
        Me.GunaTextBoxNewPasse.UseSystemPasswordChar = True
        '
        'GunaTextBoxConfirmPasse
        '
        Me.GunaTextBoxConfirmPasse.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxConfirmPasse.BaseColor = System.Drawing.Color.LightPink
        Me.GunaTextBoxConfirmPasse.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxConfirmPasse.BorderSize = 1
        Me.GunaTextBoxConfirmPasse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxConfirmPasse.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxConfirmPasse.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxConfirmPasse.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxConfirmPasse.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxConfirmPasse.Location = New System.Drawing.Point(182, 215)
        Me.GunaTextBoxConfirmPasse.Name = "GunaTextBoxConfirmPasse"
        Me.GunaTextBoxConfirmPasse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.GunaTextBoxConfirmPasse.Radius = 5
        Me.GunaTextBoxConfirmPasse.SelectedText = ""
        Me.GunaTextBoxConfirmPasse.Size = New System.Drawing.Size(256, 26)
        Me.GunaTextBoxConfirmPasse.TabIndex = 2
        Me.GunaTextBoxConfirmPasse.UseSystemPasswordChar = True
        '
        'ChangePasswordForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 320)
        Me.Controls.Add(Me.GunaTextBoxConfirmPasse)
        Me.Controls.Add(Me.GunaTextBoxNewPasse)
        Me.Controls.Add(Me.GunaTextBoxAncienPasse)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaButtonEnregistrer)
        Me.Controls.Add(Me.GunaButton3)
        Me.Controls.Add(Me.GunaLabel5)
        Me.Controls.Add(Me.GunaLabel4)
        Me.Controls.Add(Me.GunaLabel3)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaTextBoxNomUser)
        Me.Controls.Add(Me.GunaTextBoxCeode)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChangePasswordForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserForm"
        Me.TopMost = True
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GunaLabelGestUsers As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxNomUser As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCeode As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton3 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBox1 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxAncienPasse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxConfirmPasse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNewPasse As Guna.UI.WinForms.GunaTextBox
End Class
