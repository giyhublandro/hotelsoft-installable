<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PersonnelForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PersonnelForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButtonEnregistrerPersonnel = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageDescription = New System.Windows.Forms.TabPage()
        Me.MaskedTextBoxTelephone = New System.Windows.Forms.MaskedTextBox()
        Me.GunaDateTimePickerDateNaissance = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaTextBoxLieuDeNaissance = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxFax = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxProfession = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxPrenom = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxSalaire = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNomMere = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel10 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel17 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel14 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel12 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxMatricule = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNom = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNomPere = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCni = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel16 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxEmail = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxAdresse = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxAddress = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel20 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel21 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxCodePersonnel = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel19 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxNomDeJeunneFille = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel13 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel11 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel18 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel9 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel15 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBoxTypePersonnel = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaComboBoxSexe = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaComboBoxPays = New Guna.UI.WinForms.GunaComboBox()
        Me.TabPageListe = New System.Windows.Forms.TabPage()
        Me.GunaButtonAfficher = New Guna.UI.WinForms.GunaButton()
        Me.GunaDataGridViewPersonnel = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageDescription.SuspendLayout()
        Me.TabPageListe.SuspendLayout()
        CType(Me.GunaDataGridViewPersonnel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(281, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(272, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "Création et mise à jour du Personnel"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton5)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(950, 25)
        Me.GunaPanel1.TabIndex = 2
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(895, 2)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 9
        '
        'GunaImageButton5
        '
        Me.GunaImageButton5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton5.Image = CType(resources.GetObject("GunaImageButton5.Image"), System.Drawing.Image)
        Me.GunaImageButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton5.Location = New System.Drawing.Point(919, 2)
        Me.GunaImageButton5.Name = "GunaImageButton5"
        Me.GunaImageButton5.OnHoverImage = Nothing
        Me.GunaImageButton5.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton5.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton5.TabIndex = 8
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = Nothing
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(919, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(916, 3)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 6
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(915, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2117, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaButtonEnregistrerPersonnel
        '
        Me.GunaButtonEnregistrerPersonnel.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEnregistrerPersonnel.AnimationSpeed = 0.03!
        Me.GunaButtonEnregistrerPersonnel.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEnregistrerPersonnel.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrerPersonnel.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerPersonnel.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEnregistrerPersonnel.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEnregistrerPersonnel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEnregistrerPersonnel.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerPersonnel.Image = Nothing
        Me.GunaButtonEnregistrerPersonnel.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnregistrerPersonnel.Location = New System.Drawing.Point(655, 483)
        Me.GunaButtonEnregistrerPersonnel.Name = "GunaButtonEnregistrerPersonnel"
        Me.GunaButtonEnregistrerPersonnel.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrerPersonnel.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerPersonnel.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerPersonnel.OnHoverImage = Nothing
        Me.GunaButtonEnregistrerPersonnel.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerPersonnel.Radius = 4
        Me.GunaButtonEnregistrerPersonnel.Size = New System.Drawing.Size(121, 27)
        Me.GunaButtonEnregistrerPersonnel.TabIndex = 7
        Me.GunaButtonEnregistrerPersonnel.Text = "Enregistrer"
        Me.GunaButtonEnregistrerPersonnel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButton1.Location = New System.Drawing.Point(129, 482)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 27)
        Me.GunaButton1.TabIndex = 8
        Me.GunaButton1.Text = "Annuler"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageDescription)
        Me.TabControl1.Controls.Add(Me.TabPageListe)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(926, 564)
        Me.TabControl1.TabIndex = 6
        '
        'TabPageDescription
        '
        Me.TabPageDescription.BackColor = System.Drawing.Color.MistyRose
        Me.TabPageDescription.Controls.Add(Me.MaskedTextBoxTelephone)
        Me.TabPageDescription.Controls.Add(Me.GunaButtonEnregistrerPersonnel)
        Me.TabPageDescription.Controls.Add(Me.GunaDateTimePickerDateNaissance)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxLieuDeNaissance)
        Me.TabPageDescription.Controls.Add(Me.GunaButton1)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxFax)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxProfession)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxPrenom)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxSalaire)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxNomMere)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel10)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel17)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel14)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel12)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel7)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxMatricule)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxNom)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxNomPere)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxCni)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel16)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxEmail)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxAdresse)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxAddress)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel20)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel21)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel6)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxCodePersonnel)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel19)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxNomDeJeunneFille)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel4)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel13)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel11)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel18)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel9)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel15)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel8)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel5)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel3)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel2)
        Me.TabPageDescription.Controls.Add(Me.GunaComboBoxTypePersonnel)
        Me.TabPageDescription.Controls.Add(Me.GunaComboBoxSexe)
        Me.TabPageDescription.Controls.Add(Me.GunaComboBoxPays)
        Me.TabPageDescription.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDescription.Name = "TabPageDescription"
        Me.TabPageDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDescription.Size = New System.Drawing.Size(918, 535)
        Me.TabPageDescription.TabIndex = 0
        Me.TabPageDescription.Text = "Description"
        '
        'MaskedTextBoxTelephone
        '
        Me.MaskedTextBoxTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MaskedTextBoxTelephone.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBoxTelephone.Location = New System.Drawing.Point(291, 303)
        Me.MaskedTextBoxTelephone.Mask = "000-000-000"
        Me.MaskedTextBoxTelephone.Name = "MaskedTextBoxTelephone"
        Me.MaskedTextBoxTelephone.Size = New System.Drawing.Size(145, 25)
        Me.MaskedTextBoxTelephone.TabIndex = 14
        Me.MaskedTextBoxTelephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaDateTimePickerDateNaissance
        '
        Me.GunaDateTimePickerDateNaissance.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerDateNaissance.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDateNaissance.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaDateTimePickerDateNaissance.BorderSize = 1
        Me.GunaDateTimePickerDateNaissance.CustomFormat = Nothing
        Me.GunaDateTimePickerDateNaissance.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDateNaissance.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateNaissance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDateTimePickerDateNaissance.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDateNaissance.Location = New System.Drawing.Point(82, 187)
        Me.GunaDateTimePickerDateNaissance.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDateNaissance.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDateNaissance.Name = "GunaDateTimePickerDateNaissance"
        Me.GunaDateTimePickerDateNaissance.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDateNaissance.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateNaissance.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateNaissance.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDateNaissance.Radius = 4
        Me.GunaDateTimePickerDateNaissance.Size = New System.Drawing.Size(256, 30)
        Me.GunaDateTimePickerDateNaissance.TabIndex = 7
        Me.GunaDateTimePickerDateNaissance.Text = "10 June 2021"
        Me.GunaDateTimePickerDateNaissance.Value = New Date(2021, 6, 10, 20, 24, 14, 361)
        '
        'GunaTextBoxLieuDeNaissance
        '
        Me.GunaTextBoxLieuDeNaissance.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxLieuDeNaissance.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxLieuDeNaissance.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxLieuDeNaissance.BorderSize = 1
        Me.GunaTextBoxLieuDeNaissance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxLieuDeNaissance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxLieuDeNaissance.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxLieuDeNaissance.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxLieuDeNaissance.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxLieuDeNaissance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxLieuDeNaissance.Location = New System.Drawing.Point(625, 187)
        Me.GunaTextBoxLieuDeNaissance.Name = "GunaTextBoxLieuDeNaissance"
        Me.GunaTextBoxLieuDeNaissance.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxLieuDeNaissance.Radius = 5
        Me.GunaTextBoxLieuDeNaissance.SelectedText = ""
        Me.GunaTextBoxLieuDeNaissance.Size = New System.Drawing.Size(233, 30)
        Me.GunaTextBoxLieuDeNaissance.TabIndex = 8
        '
        'GunaTextBoxFax
        '
        Me.GunaTextBoxFax.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxFax.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxFax.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxFax.BorderSize = 1
        Me.GunaTextBoxFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxFax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxFax.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxFax.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxFax.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxFax.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxFax.Location = New System.Drawing.Point(446, 299)
        Me.GunaTextBoxFax.Name = "GunaTextBoxFax"
        Me.GunaTextBoxFax.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxFax.Radius = 5
        Me.GunaTextBoxFax.SelectedText = ""
        Me.GunaTextBoxFax.Size = New System.Drawing.Size(159, 30)
        Me.GunaTextBoxFax.TabIndex = 15
        '
        'GunaTextBoxProfession
        '
        Me.GunaTextBoxProfession.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxProfession.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxProfession.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxProfession.BorderSize = 1
        Me.GunaTextBoxProfession.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxProfession.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxProfession.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxProfession.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxProfession.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxProfession.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxProfession.Location = New System.Drawing.Point(625, 243)
        Me.GunaTextBoxProfession.Name = "GunaTextBoxProfession"
        Me.GunaTextBoxProfession.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxProfession.Radius = 5
        Me.GunaTextBoxProfession.SelectedText = ""
        Me.GunaTextBoxProfession.Size = New System.Drawing.Size(233, 30)
        Me.GunaTextBoxProfession.TabIndex = 11
        '
        'GunaTextBoxPrenom
        '
        Me.GunaTextBoxPrenom.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPrenom.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPrenom.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxPrenom.BorderSize = 1
        Me.GunaTextBoxPrenom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxPrenom.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPrenom.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPrenom.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPrenom.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPrenom.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxPrenom.Location = New System.Drawing.Point(349, 124)
        Me.GunaTextBoxPrenom.Name = "GunaTextBoxPrenom"
        Me.GunaTextBoxPrenom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPrenom.Radius = 5
        Me.GunaTextBoxPrenom.SelectedText = ""
        Me.GunaTextBoxPrenom.Size = New System.Drawing.Size(264, 30)
        Me.GunaTextBoxPrenom.TabIndex = 5
        '
        'GunaTextBoxSalaire
        '
        Me.GunaTextBoxSalaire.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxSalaire.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxSalaire.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxSalaire.BorderSize = 1
        Me.GunaTextBoxSalaire.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxSalaire.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxSalaire.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxSalaire.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxSalaire.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxSalaire.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxSalaire.Location = New System.Drawing.Point(87, 414)
        Me.GunaTextBoxSalaire.Name = "GunaTextBoxSalaire"
        Me.GunaTextBoxSalaire.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxSalaire.Radius = 5
        Me.GunaTextBoxSalaire.SelectedText = ""
        Me.GunaTextBoxSalaire.Size = New System.Drawing.Size(163, 30)
        Me.GunaTextBoxSalaire.TabIndex = 18
        Me.GunaTextBoxSalaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaTextBoxNomMere
        '
        Me.GunaTextBoxNomMere.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNomMere.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomMere.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNomMere.BorderSize = 1
        Me.GunaTextBoxNomMere.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNomMere.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNomMere.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomMere.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNomMere.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNomMere.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNomMere.Location = New System.Drawing.Point(492, 362)
        Me.GunaTextBoxNomMere.Name = "GunaTextBoxNomMere"
        Me.GunaTextBoxNomMere.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNomMere.Radius = 5
        Me.GunaTextBoxNomMere.SelectedText = ""
        Me.GunaTextBoxNomMere.Size = New System.Drawing.Size(366, 30)
        Me.GunaTextBoxNomMere.TabIndex = 18
        '
        'GunaLabel10
        '
        Me.GunaLabel10.AutoSize = True
        Me.GunaLabel10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel10.Location = New System.Drawing.Point(366, 167)
        Me.GunaLabel10.Name = "GunaLabel10"
        Me.GunaLabel10.Size = New System.Drawing.Size(113, 17)
        Me.GunaLabel10.TabIndex = 21
        Me.GunaLabel10.Text = "Pays de naissance"
        '
        'GunaLabel17
        '
        Me.GunaLabel17.AutoSize = True
        Me.GunaLabel17.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel17.Location = New System.Drawing.Point(443, 279)
        Me.GunaLabel17.Name = "GunaLabel17"
        Me.GunaLabel17.Size = New System.Drawing.Size(27, 17)
        Me.GunaLabel17.TabIndex = 19
        Me.GunaLabel17.Text = "Fax"
        '
        'GunaLabel14
        '
        Me.GunaLabel14.AutoSize = True
        Me.GunaLabel14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel14.Location = New System.Drawing.Point(705, 47)
        Me.GunaLabel14.Name = "GunaLabel14"
        Me.GunaLabel14.Size = New System.Drawing.Size(35, 17)
        Me.GunaLabel14.TabIndex = 23
        Me.GunaLabel14.Text = "Sexe"
        '
        'GunaLabel12
        '
        Me.GunaLabel12.AutoSize = True
        Me.GunaLabel12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel12.Location = New System.Drawing.Point(518, 47)
        Me.GunaLabel12.Name = "GunaLabel12"
        Me.GunaLabel12.Size = New System.Drawing.Size(62, 17)
        Me.GunaLabel12.TabIndex = 23
        Me.GunaLabel12.Text = "Matricule"
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel7.Location = New System.Drawing.Point(622, 223)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(69, 17)
        Me.GunaLabel7.TabIndex = 23
        Me.GunaLabel7.Text = "Profession"
        '
        'GunaTextBoxMatricule
        '
        Me.GunaTextBoxMatricule.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMatricule.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMatricule.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMatricule.BorderSize = 1
        Me.GunaTextBoxMatricule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMatricule.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMatricule.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMatricule.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMatricule.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMatricule.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxMatricule.Location = New System.Drawing.Point(519, 67)
        Me.GunaTextBoxMatricule.Name = "GunaTextBoxMatricule"
        Me.GunaTextBoxMatricule.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMatricule.Radius = 5
        Me.GunaTextBoxMatricule.SelectedText = ""
        Me.GunaTextBoxMatricule.Size = New System.Drawing.Size(180, 30)
        Me.GunaTextBoxMatricule.TabIndex = 1
        '
        'GunaTextBoxNom
        '
        Me.GunaTextBoxNom.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNom.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNom.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNom.BorderSize = 1
        Me.GunaTextBoxNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNom.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNom.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNom.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNom.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNom.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNom.Location = New System.Drawing.Point(81, 124)
        Me.GunaTextBoxNom.Name = "GunaTextBoxNom"
        Me.GunaTextBoxNom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNom.Radius = 5
        Me.GunaTextBoxNom.SelectedText = ""
        Me.GunaTextBoxNom.Size = New System.Drawing.Size(257, 30)
        Me.GunaTextBoxNom.TabIndex = 4
        '
        'GunaTextBoxNomPere
        '
        Me.GunaTextBoxNomPere.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNomPere.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomPere.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNomPere.BorderSize = 1
        Me.GunaTextBoxNomPere.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNomPere.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNomPere.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomPere.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNomPere.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNomPere.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNomPere.Location = New System.Drawing.Point(85, 362)
        Me.GunaTextBoxNomPere.Name = "GunaTextBoxNomPere"
        Me.GunaTextBoxNomPere.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNomPere.Radius = 5
        Me.GunaTextBoxNomPere.SelectedText = ""
        Me.GunaTextBoxNomPere.Size = New System.Drawing.Size(385, 30)
        Me.GunaTextBoxNomPere.TabIndex = 17
        '
        'GunaTextBoxCni
        '
        Me.GunaTextBoxCni.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCni.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCni.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCni.BorderSize = 1
        Me.GunaTextBoxCni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCni.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCni.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCni.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCni.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCni.Location = New System.Drawing.Point(84, 243)
        Me.GunaTextBoxCni.Name = "GunaTextBoxCni"
        Me.GunaTextBoxCni.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCni.Radius = 5
        Me.GunaTextBoxCni.SelectedText = ""
        Me.GunaTextBoxCni.Size = New System.Drawing.Size(254, 30)
        Me.GunaTextBoxCni.TabIndex = 9
        '
        'GunaLabel16
        '
        Me.GunaLabel16.AutoSize = True
        Me.GunaLabel16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel16.Location = New System.Drawing.Point(290, 279)
        Me.GunaLabel16.Name = "GunaLabel16"
        Me.GunaLabel16.Size = New System.Drawing.Size(68, 17)
        Me.GunaLabel16.TabIndex = 18
        Me.GunaLabel16.Text = "Téléphone"
        '
        'GunaTextBoxEmail
        '
        Me.GunaTextBoxEmail.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxEmail.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxEmail.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxEmail.BorderSize = 1
        Me.GunaTextBoxEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxEmail.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxEmail.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxEmail.Location = New System.Drawing.Point(625, 299)
        Me.GunaTextBoxEmail.Name = "GunaTextBoxEmail"
        Me.GunaTextBoxEmail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxEmail.Radius = 5
        Me.GunaTextBoxEmail.SelectedText = ""
        Me.GunaTextBoxEmail.Size = New System.Drawing.Size(233, 30)
        Me.GunaTextBoxEmail.TabIndex = 16
        '
        'GunaTextBoxAdresse
        '
        Me.GunaTextBoxAdresse.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAdresse.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdresse.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxAdresse.BorderSize = 1
        Me.GunaTextBoxAdresse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxAdresse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAdresse.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdresse.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAdresse.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAdresse.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxAdresse.Location = New System.Drawing.Point(369, 243)
        Me.GunaTextBoxAdresse.Name = "GunaTextBoxAdresse"
        Me.GunaTextBoxAdresse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAdresse.Radius = 5
        Me.GunaTextBoxAdresse.SelectedText = ""
        Me.GunaTextBoxAdresse.Size = New System.Drawing.Size(236, 30)
        Me.GunaTextBoxAdresse.TabIndex = 10
        '
        'GunaTextBoxAddress
        '
        Me.GunaTextBoxAddress.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAddress.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAddress.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxAddress.BorderSize = 1
        Me.GunaTextBoxAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAddress.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAddress.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAddress.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAddress.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxAddress.Location = New System.Drawing.Point(86, 299)
        Me.GunaTextBoxAddress.Name = "GunaTextBoxAddress"
        Me.GunaTextBoxAddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAddress.Radius = 5
        Me.GunaTextBoxAddress.SelectedText = ""
        Me.GunaTextBoxAddress.Size = New System.Drawing.Size(199, 30)
        Me.GunaTextBoxAddress.TabIndex = 13
        '
        'GunaLabel20
        '
        Me.GunaLabel20.AutoSize = True
        Me.GunaLabel20.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel20.Location = New System.Drawing.Point(349, 105)
        Me.GunaLabel20.Name = "GunaLabel20"
        Me.GunaLabel20.Size = New System.Drawing.Size(53, 17)
        Me.GunaLabel20.TabIndex = 16
        Me.GunaLabel20.Text = "Prénom"
        '
        'GunaLabel21
        '
        Me.GunaLabel21.AutoSize = True
        Me.GunaLabel21.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel21.Location = New System.Drawing.Point(86, 394)
        Me.GunaLabel21.Name = "GunaLabel21"
        Me.GunaLabel21.Size = New System.Drawing.Size(47, 17)
        Me.GunaLabel21.TabIndex = 16
        Me.GunaLabel21.Text = "Salaire"
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.Location = New System.Drawing.Point(516, 342)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(104, 17)
        Me.GunaLabel6.TabIndex = 16
        Me.GunaLabel6.Text = "Nom de la mère"
        '
        'GunaTextBoxCodePersonnel
        '
        Me.GunaTextBoxCodePersonnel.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodePersonnel.BaseColor = System.Drawing.Color.Pink
        Me.GunaTextBoxCodePersonnel.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodePersonnel.BorderSize = 1
        Me.GunaTextBoxCodePersonnel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodePersonnel.Enabled = False
        Me.GunaTextBoxCodePersonnel.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodePersonnel.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodePersonnel.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodePersonnel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodePersonnel.Location = New System.Drawing.Point(77, 66)
        Me.GunaTextBoxCodePersonnel.Name = "GunaTextBoxCodePersonnel"
        Me.GunaTextBoxCodePersonnel.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodePersonnel.Radius = 5
        Me.GunaTextBoxCodePersonnel.SelectedText = ""
        Me.GunaTextBoxCodePersonnel.Size = New System.Drawing.Size(173, 30)
        Me.GunaTextBoxCodePersonnel.TabIndex = 34
        Me.GunaTextBoxCodePersonnel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel19
        '
        Me.GunaLabel19.AutoSize = True
        Me.GunaLabel19.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel19.Location = New System.Drawing.Point(78, 105)
        Me.GunaLabel19.Name = "GunaLabel19"
        Me.GunaLabel19.Size = New System.Drawing.Size(37, 17)
        Me.GunaLabel19.TabIndex = 15
        Me.GunaLabel19.Text = "Nom"
        '
        'GunaTextBoxNomDeJeunneFille
        '
        Me.GunaTextBoxNomDeJeunneFille.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNomDeJeunneFille.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomDeJeunneFille.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNomDeJeunneFille.BorderSize = 1
        Me.GunaTextBoxNomDeJeunneFille.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNomDeJeunneFille.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNomDeJeunneFille.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomDeJeunneFille.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNomDeJeunneFille.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNomDeJeunneFille.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNomDeJeunneFille.Location = New System.Drawing.Point(624, 125)
        Me.GunaTextBoxNomDeJeunneFille.Name = "GunaTextBoxNomDeJeunneFille"
        Me.GunaTextBoxNomDeJeunneFille.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNomDeJeunneFille.Radius = 5
        Me.GunaTextBoxNomDeJeunneFille.SelectedText = ""
        Me.GunaTextBoxNomDeJeunneFille.Size = New System.Drawing.Size(233, 30)
        Me.GunaTextBoxNomDeJeunneFille.TabIndex = 6
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(82, 342)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(86, 17)
        Me.GunaLabel4.TabIndex = 15
        Me.GunaLabel4.Text = "Nom du Père"
        '
        'GunaLabel13
        '
        Me.GunaLabel13.AutoSize = True
        Me.GunaLabel13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel13.Location = New System.Drawing.Point(81, 223)
        Me.GunaLabel13.Name = "GunaLabel13"
        Me.GunaLabel13.Size = New System.Drawing.Size(59, 17)
        Me.GunaLabel13.TabIndex = 14
        Me.GunaLabel13.Text = "CNI/NIU"
        '
        'GunaLabel11
        '
        Me.GunaLabel11.AutoSize = True
        Me.GunaLabel11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel11.Location = New System.Drawing.Point(81, 167)
        Me.GunaLabel11.Name = "GunaLabel11"
        Me.GunaLabel11.Size = New System.Drawing.Size(114, 17)
        Me.GunaLabel11.TabIndex = 13
        Me.GunaLabel11.Text = "Date de naissance"
        '
        'GunaLabel18
        '
        Me.GunaLabel18.AutoSize = True
        Me.GunaLabel18.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel18.Location = New System.Drawing.Point(622, 280)
        Me.GunaLabel18.Name = "GunaLabel18"
        Me.GunaLabel18.Size = New System.Drawing.Size(45, 17)
        Me.GunaLabel18.TabIndex = 12
        Me.GunaLabel18.Text = "E-Mail"
        '
        'GunaLabel9
        '
        Me.GunaLabel9.AutoSize = True
        Me.GunaLabel9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel9.Location = New System.Drawing.Point(369, 223)
        Me.GunaLabel9.Name = "GunaLabel9"
        Me.GunaLabel9.Size = New System.Drawing.Size(55, 17)
        Me.GunaLabel9.TabIndex = 10
        Me.GunaLabel9.Text = "Adresse"
        '
        'GunaLabel15
        '
        Me.GunaLabel15.AutoSize = True
        Me.GunaLabel15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel15.Location = New System.Drawing.Point(83, 280)
        Me.GunaLabel15.Name = "GunaLabel15"
        Me.GunaLabel15.Size = New System.Drawing.Size(55, 17)
        Me.GunaLabel15.TabIndex = 10
        Me.GunaLabel15.Text = "Adresse"
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel8.Location = New System.Drawing.Point(622, 167)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(110, 17)
        Me.GunaLabel8.TabIndex = 9
        Me.GunaLabel8.Text = "Lieu de naissance"
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(622, 105)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(96, 17)
        Me.GunaLabel5.TabIndex = 8
        Me.GunaLabel5.Text = "Nom jeune fille"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(258, 47)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(96, 17)
        Me.GunaLabel3.TabIndex = 7
        Me.GunaLabel3.Text = "Type Personnel"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(74, 47)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(100, 17)
        Me.GunaLabel2.TabIndex = 6
        Me.GunaLabel2.Text = "Code Personnel"
        '
        'GunaComboBoxTypePersonnel
        '
        Me.GunaComboBoxTypePersonnel.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxTypePersonnel.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxTypePersonnel.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxTypePersonnel.BorderSize = 1
        Me.GunaComboBoxTypePersonnel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxTypePersonnel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxTypePersonnel.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxTypePersonnel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxTypePersonnel.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxTypePersonnel.FormattingEnabled = True
        Me.GunaComboBoxTypePersonnel.ItemHeight = 23
        Me.GunaComboBoxTypePersonnel.Location = New System.Drawing.Point(261, 67)
        Me.GunaComboBoxTypePersonnel.Name = "GunaComboBoxTypePersonnel"
        Me.GunaComboBoxTypePersonnel.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxTypePersonnel.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxTypePersonnel.Radius = 4
        Me.GunaComboBoxTypePersonnel.Size = New System.Drawing.Size(246, 29)
        Me.GunaComboBoxTypePersonnel.TabIndex = 5
        '
        'GunaComboBoxSexe
        '
        Me.GunaComboBoxSexe.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxSexe.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxSexe.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxSexe.BorderSize = 1
        Me.GunaComboBoxSexe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxSexe.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxSexe.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxSexe.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxSexe.FormattingEnabled = True
        Me.GunaComboBoxSexe.ItemHeight = 24
        Me.GunaComboBoxSexe.Items.AddRange(New Object() {"Féminin", "Masculin"})
        Me.GunaComboBoxSexe.Location = New System.Drawing.Point(708, 66)
        Me.GunaComboBoxSexe.Name = "GunaComboBoxSexe"
        Me.GunaComboBoxSexe.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxSexe.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxSexe.Radius = 4
        Me.GunaComboBoxSexe.Size = New System.Drawing.Size(152, 30)
        Me.GunaComboBoxSexe.StartIndex = 0
        Me.GunaComboBoxSexe.TabIndex = 5
        '
        'GunaComboBoxPays
        '
        Me.GunaComboBoxPays.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxPays.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxPays.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxPays.BorderSize = 1
        Me.GunaComboBoxPays.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxPays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxPays.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxPays.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxPays.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxPays.FormattingEnabled = True
        Me.GunaComboBoxPays.ItemHeight = 24
        Me.GunaComboBoxPays.Location = New System.Drawing.Point(368, 187)
        Me.GunaComboBoxPays.Name = "GunaComboBoxPays"
        Me.GunaComboBoxPays.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxPays.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxPays.Radius = 4
        Me.GunaComboBoxPays.Size = New System.Drawing.Size(237, 30)
        Me.GunaComboBoxPays.TabIndex = 5
        '
        'TabPageListe
        '
        Me.TabPageListe.Controls.Add(Me.GunaButtonAfficher)
        Me.TabPageListe.Controls.Add(Me.GunaDataGridViewPersonnel)
        Me.TabPageListe.Location = New System.Drawing.Point(4, 25)
        Me.TabPageListe.Name = "TabPageListe"
        Me.TabPageListe.Size = New System.Drawing.Size(918, 535)
        Me.TabPageListe.TabIndex = 2
        Me.TabPageListe.Text = "Liste"
        Me.TabPageListe.UseVisualStyleBackColor = True
        '
        'GunaButtonAfficher
        '
        Me.GunaButtonAfficher.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAfficher.AnimationSpeed = 0.03!
        Me.GunaButtonAfficher.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAfficher.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAfficher.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAfficher.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAfficher.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAfficher.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficher.Image = Nothing
        Me.GunaButtonAfficher.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAfficher.Location = New System.Drawing.Point(792, 36)
        Me.GunaButtonAfficher.Name = "GunaButtonAfficher"
        Me.GunaButtonAfficher.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAfficher.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficher.OnHoverImage = Nothing
        Me.GunaButtonAfficher.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.Radius = 4
        Me.GunaButtonAfficher.Size = New System.Drawing.Size(114, 37)
        Me.GunaButtonAfficher.TabIndex = 8
        Me.GunaButtonAfficher.Text = "Afficher"
        Me.GunaButtonAfficher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaDataGridViewPersonnel
        '
        Me.GunaDataGridViewPersonnel.AllowUserToAddRows = False
        Me.GunaDataGridViewPersonnel.AllowUserToDeleteRows = False
        Me.GunaDataGridViewPersonnel.AllowUserToOrderColumns = True
        Me.GunaDataGridViewPersonnel.AllowUserToResizeColumns = False
        Me.GunaDataGridViewPersonnel.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewPersonnel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewPersonnel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GunaDataGridViewPersonnel.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewPersonnel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewPersonnel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewPersonnel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewPersonnel.ColumnHeadersHeight = 25
        Me.GunaDataGridViewPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewPersonnel.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewPersonnel.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewPersonnel.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewPersonnel.Location = New System.Drawing.Point(15, 109)
        Me.GunaDataGridViewPersonnel.MultiSelect = False
        Me.GunaDataGridViewPersonnel.Name = "GunaDataGridViewPersonnel"
        Me.GunaDataGridViewPersonnel.ReadOnly = True
        Me.GunaDataGridViewPersonnel.RowHeadersVisible = False
        Me.GunaDataGridViewPersonnel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewPersonnel.Size = New System.Drawing.Size(891, 413)
        Me.GunaDataGridViewPersonnel.TabIndex = 2
        Me.GunaDataGridViewPersonnel.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewPersonnel.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewPersonnel.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewPersonnel.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewPersonnel.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewPersonnel.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewPersonnel.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewPersonnel.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewPersonnel.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewPersonnel.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewPersonnel.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewPersonnel.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewPersonnel.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewPersonnel.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewPersonnel.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewPersonnel.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewPersonnel.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewPersonnel.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewPersonnel.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewPersonnel.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewPersonnel.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewPersonnel.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLabelGestCompteGeneraux
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaPanel1
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 639)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(958, 10)
        Me.GunaPanel2.TabIndex = 9
        '
        'PersonnelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 650)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PersonnelForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClientForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageDescription.ResumeLayout(False)
        Me.TabPageDescription.PerformLayout()
        Me.TabPageListe.ResumeLayout(False)
        CType(Me.GunaDataGridViewPersonnel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaButtonEnregistrerPersonnel As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageDescription As TabPage
    Friend WithEvents GunaDateTimePickerDateNaissance As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaTextBoxLieuDeNaissance As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxProfession As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNomMere As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxNomPere As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCni As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel16 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxEmail As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxAddress As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxNomDeJeunneFille As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel13 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel11 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel18 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel15 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents TabPageListe As TabPage
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaTextBoxCodePersonnel As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents MaskedTextBoxTelephone As MaskedTextBox
    Friend WithEvents GunaComboBoxTypePersonnel As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaDataGridViewPersonnel As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaTextBoxFax As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxPrenom As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel10 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel17 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel14 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel12 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxMatricule As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNom As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxAdresse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel20 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel19 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel9 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaComboBoxSexe As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaComboBoxPays As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaButtonAfficher As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxSalaire As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel21 As Guna.UI.WinForms.GunaLabel
End Class
