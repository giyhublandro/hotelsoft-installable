<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BankForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageDescription = New System.Windows.Forms.TabPage()
        Me.GunaButtonEnregistrerBanque = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxNom = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxEmail = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxFax = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxPhone = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxAdresse = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNumCompteBanque = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxCodeBanque = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.TabPageListe = New System.Windows.Forms.TabPage()
        Me.GunaDataGridViewBanqueListe = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaContextMenuStrip1 = New Guna.UI.WinForms.GunaContextMenuStrip()
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GunaPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageDescription.SuspendLayout()
        Me.TabPageListe.SuspendLayout()
        CType(Me.GunaDataGridViewBanqueListe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(934, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = CType(resources.GetObject("GunaImageButton3.Image"), System.Drawing.Image)
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(905, 3)
        Me.GunaImageButton3.Name = "GunaImageButton3"
        Me.GunaImageButton3.OnHoverImage = Nothing
        Me.GunaImageButton3.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton3.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton3.TabIndex = 7
        '
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = Nothing
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(895, 3)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 6
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(357, 3)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(158, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "LISTE DES BANQUES"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(899, 2)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 2
        '
        'GunaLabel1
        '
        Me.GunaLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.ForeColor = System.Drawing.Color.White
        Me.GunaLabel1.Location = New System.Drawing.Point(2101, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaPanel1
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaLabelGestCompteGeneraux
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageDescription)
        Me.TabControl1.Controls.Add(Me.TabPageListe)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(910, 378)
        Me.TabControl1.TabIndex = 2
        '
        'TabPageDescription
        '
        Me.TabPageDescription.Controls.Add(Me.GunaButtonEnregistrerBanque)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxNom)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel8)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel7)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel6)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxEmail)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel4)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxFax)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxPhone)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel3)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxAdresse)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxNumCompteBanque)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel5)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxCodeBanque)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel2)
        Me.TabPageDescription.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDescription.Name = "TabPageDescription"
        Me.TabPageDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDescription.Size = New System.Drawing.Size(902, 349)
        Me.TabPageDescription.TabIndex = 0
        Me.TabPageDescription.Text = "Description"
        Me.TabPageDescription.UseVisualStyleBackColor = True
        '
        'GunaButtonEnregistrerBanque
        '
        Me.GunaButtonEnregistrerBanque.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEnregistrerBanque.AnimationSpeed = 0.03!
        Me.GunaButtonEnregistrerBanque.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEnregistrerBanque.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrerBanque.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerBanque.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEnregistrerBanque.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEnregistrerBanque.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEnregistrerBanque.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerBanque.Image = Nothing
        Me.GunaButtonEnregistrerBanque.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnregistrerBanque.Location = New System.Drawing.Point(726, 319)
        Me.GunaButtonEnregistrerBanque.Name = "GunaButtonEnregistrerBanque"
        Me.GunaButtonEnregistrerBanque.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrerBanque.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerBanque.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerBanque.OnHoverImage = Nothing
        Me.GunaButtonEnregistrerBanque.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerBanque.Radius = 4
        Me.GunaButtonEnregistrerBanque.Size = New System.Drawing.Size(121, 24)
        Me.GunaButtonEnregistrerBanque.TabIndex = 3
        Me.GunaButtonEnregistrerBanque.Text = "Enregistrer"
        Me.GunaButtonEnregistrerBanque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxNom
        '
        Me.GunaTextBoxNom.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNom.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNom.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxNom.BorderSize = 1
        Me.GunaTextBoxNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNom.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNom.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNom.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNom.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNom.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxNom.Location = New System.Drawing.Point(52, 64)
        Me.GunaTextBoxNom.Name = "GunaTextBoxNom"
        Me.GunaTextBoxNom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNom.Radius = 4
        Me.GunaTextBoxNom.SelectedText = ""
        Me.GunaTextBoxNom.Size = New System.Drawing.Size(791, 34)
        Me.GunaTextBoxNom.TabIndex = 1
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel8.Location = New System.Drawing.Point(480, 181)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(45, 17)
        Me.GunaLabel8.TabIndex = 0
        Me.GunaLabel8.Text = "E-Mail"
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel7.Location = New System.Drawing.Point(251, 181)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(27, 17)
        Me.GunaLabel7.TabIndex = 0
        Me.GunaLabel7.Text = "Fax"
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.Location = New System.Drawing.Point(46, 181)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(68, 17)
        Me.GunaLabel6.TabIndex = 0
        Me.GunaLabel6.Text = "Téléphone"
        '
        'GunaTextBoxEmail
        '
        Me.GunaTextBoxEmail.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxEmail.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxEmail.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxEmail.BorderSize = 1
        Me.GunaTextBoxEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxEmail.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxEmail.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxEmail.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxEmail.Location = New System.Drawing.Point(479, 201)
        Me.GunaTextBoxEmail.Name = "GunaTextBoxEmail"
        Me.GunaTextBoxEmail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxEmail.Radius = 4
        Me.GunaTextBoxEmail.SelectedText = ""
        Me.GunaTextBoxEmail.Size = New System.Drawing.Size(364, 34)
        Me.GunaTextBoxEmail.TabIndex = 1
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(452, 111)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(55, 17)
        Me.GunaLabel4.TabIndex = 0
        Me.GunaLabel4.Text = "Adresse"
        '
        'GunaTextBoxFax
        '
        Me.GunaTextBoxFax.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxFax.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxFax.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxFax.BorderSize = 1
        Me.GunaTextBoxFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxFax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxFax.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxFax.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxFax.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxFax.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxFax.Location = New System.Drawing.Point(247, 201)
        Me.GunaTextBoxFax.Name = "GunaTextBoxFax"
        Me.GunaTextBoxFax.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxFax.Radius = 4
        Me.GunaTextBoxFax.SelectedText = ""
        Me.GunaTextBoxFax.Size = New System.Drawing.Size(211, 34)
        Me.GunaTextBoxFax.TabIndex = 1
        '
        'GunaTextBoxPhone
        '
        Me.GunaTextBoxPhone.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPhone.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPhone.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxPhone.BorderSize = 1
        Me.GunaTextBoxPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPhone.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPhone.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPhone.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPhone.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxPhone.Location = New System.Drawing.Point(49, 201)
        Me.GunaTextBoxPhone.Name = "GunaTextBoxPhone"
        Me.GunaTextBoxPhone.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPhone.Radius = 4
        Me.GunaTextBoxPhone.SelectedText = ""
        Me.GunaTextBoxPhone.Size = New System.Drawing.Size(177, 34)
        Me.GunaTextBoxPhone.TabIndex = 1
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(49, 43)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(117, 17)
        Me.GunaLabel3.TabIndex = 0
        Me.GunaLabel3.Text = "Nom de la Banque"
        '
        'GunaTextBoxAdresse
        '
        Me.GunaTextBoxAdresse.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAdresse.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdresse.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxAdresse.BorderSize = 1
        Me.GunaTextBoxAdresse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxAdresse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAdresse.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdresse.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAdresse.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAdresse.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxAdresse.Location = New System.Drawing.Point(455, 131)
        Me.GunaTextBoxAdresse.Name = "GunaTextBoxAdresse"
        Me.GunaTextBoxAdresse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAdresse.Radius = 4
        Me.GunaTextBoxAdresse.SelectedText = ""
        Me.GunaTextBoxAdresse.Size = New System.Drawing.Size(388, 34)
        Me.GunaTextBoxAdresse.TabIndex = 1
        '
        'GunaTextBoxNumCompteBanque
        '
        Me.GunaTextBoxNumCompteBanque.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumCompteBanque.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumCompteBanque.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxNumCompteBanque.BorderSize = 1
        Me.GunaTextBoxNumCompteBanque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNumCompteBanque.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNumCompteBanque.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumCompteBanque.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNumCompteBanque.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNumCompteBanque.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxNumCompteBanque.Location = New System.Drawing.Point(50, 131)
        Me.GunaTextBoxNumCompteBanque.Name = "GunaTextBoxNumCompteBanque"
        Me.GunaTextBoxNumCompteBanque.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNumCompteBanque.Radius = 4
        Me.GunaTextBoxNumCompteBanque.SelectedText = ""
        Me.GunaTextBoxNumCompteBanque.Size = New System.Drawing.Size(388, 34)
        Me.GunaTextBoxNumCompteBanque.TabIndex = 1
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(47, 111)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(125, 17)
        Me.GunaLabel5.TabIndex = 0
        Me.GunaLabel5.Text = "Numéro de Compte"
        '
        'GunaTextBoxCodeBanque
        '
        Me.GunaTextBoxCodeBanque.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeBanque.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeBanque.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxCodeBanque.BorderSize = 1
        Me.GunaTextBoxCodeBanque.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeBanque.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeBanque.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeBanque.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeBanque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxCodeBanque.Location = New System.Drawing.Point(52, 298)
        Me.GunaTextBoxCodeBanque.Name = "GunaTextBoxCodeBanque"
        Me.GunaTextBoxCodeBanque.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeBanque.Radius = 4
        Me.GunaTextBoxCodeBanque.SelectedText = ""
        Me.GunaTextBoxCodeBanque.Size = New System.Drawing.Size(288, 34)
        Me.GunaTextBoxCodeBanque.TabIndex = 1
        Me.GunaTextBoxCodeBanque.Visible = False
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(49, 278)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(39, 17)
        Me.GunaLabel2.TabIndex = 0
        Me.GunaLabel2.Text = "Code"
        Me.GunaLabel2.Visible = False
        '
        'TabPageListe
        '
        Me.TabPageListe.Controls.Add(Me.GunaDataGridViewBanqueListe)
        Me.TabPageListe.Location = New System.Drawing.Point(4, 25)
        Me.TabPageListe.Name = "TabPageListe"
        Me.TabPageListe.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageListe.Size = New System.Drawing.Size(902, 349)
        Me.TabPageListe.TabIndex = 1
        Me.TabPageListe.Text = "Liste"
        Me.TabPageListe.UseVisualStyleBackColor = True
        '
        'GunaDataGridViewBanqueListe
        '
        Me.GunaDataGridViewBanqueListe.AllowUserToAddRows = False
        Me.GunaDataGridViewBanqueListe.AllowUserToDeleteRows = False
        Me.GunaDataGridViewBanqueListe.AllowUserToResizeColumns = False
        Me.GunaDataGridViewBanqueListe.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GunaDataGridViewBanqueListe.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewBanqueListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewBanqueListe.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewBanqueListe.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewBanqueListe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewBanqueListe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewBanqueListe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewBanqueListe.ColumnHeadersHeight = 25
        Me.GunaDataGridViewBanqueListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewBanqueListe.ContextMenuStrip = Me.GunaContextMenuStrip1
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(225, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewBanqueListe.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewBanqueListe.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewBanqueListe.GridColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GunaDataGridViewBanqueListe.Location = New System.Drawing.Point(6, 89)
        Me.GunaDataGridViewBanqueListe.Name = "GunaDataGridViewBanqueListe"
        Me.GunaDataGridViewBanqueListe.ReadOnly = True
        Me.GunaDataGridViewBanqueListe.RowHeadersVisible = False
        Me.GunaDataGridViewBanqueListe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewBanqueListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewBanqueListe.Size = New System.Drawing.Size(890, 236)
        Me.GunaDataGridViewBanqueListe.TabIndex = 18
        Me.GunaDataGridViewBanqueListe.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Turquoise
        Me.GunaDataGridViewBanqueListe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GunaDataGridViewBanqueListe.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewBanqueListe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewBanqueListe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewBanqueListe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewBanqueListe.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewBanqueListe.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GunaDataGridViewBanqueListe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.GunaDataGridViewBanqueListe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewBanqueListe.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewBanqueListe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewBanqueListe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewBanqueListe.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewBanqueListe.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewBanqueListe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.GunaDataGridViewBanqueListe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewBanqueListe.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewBanqueListe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.GunaDataGridViewBanqueListe.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewBanqueListe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GunaDataGridViewBanqueListe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
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
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(12, 415)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 24)
        Me.GunaButton1.TabIndex = 3
        Me.GunaButton1.Text = "Fermer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaContextMenuStrip1
        '
        Me.GunaContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupprimerToolStripMenuItem})
        Me.GunaContextMenuStrip1.Name = "GunaContextMenuStrip1"
        Me.GunaContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaContextMenuStrip1.RenderStyle.ColorTable = Nothing
        Me.GunaContextMenuStrip1.RenderStyle.RoundedEdges = True
        Me.GunaContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White
        Me.GunaContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GunaContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro
        Me.GunaContextMenuStrip1.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault
        Me.GunaContextMenuStrip1.Size = New System.Drawing.Size(130, 26)
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'BankForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 450)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BankForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageDescription.ResumeLayout(False)
        Me.TabPageDescription.PerformLayout()
        Me.TabPageListe.ResumeLayout(False)
        CType(Me.GunaDataGridViewBanqueListe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnregistrerBanque As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageDescription As TabPage
    Friend WithEvents TabPageListe As TabPage
    Friend WithEvents GunaTextBoxNom As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxCodeBanque As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaTextBoxNumCompteBanque As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaTextBoxAdresse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxEmail As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxFax As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxPhone As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewBanqueListe As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaContextMenuStrip1 As Guna.UI.WinForms.GunaContextMenuStrip
    Friend WithEvents SupprimerToolStripMenuItem As ToolStripMenuItem
End Class
