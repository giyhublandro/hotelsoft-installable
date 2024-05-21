<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editionDeMasseForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(editionDeMasseForm))
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GunaLabelGestCompany = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonAppliquerTarifSpecifique = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaDateTimePickerDispoFin = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaDateTimePickerDispoDebut = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBoxTypeDeChambre = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxMontant = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBoxTypeDeTarif = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaDateTimePicker1 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaDateTimePicker2 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel9 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBox3 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaComboBox4 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel10 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel11 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBox2 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel12 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBoxEtatEditionDeMasse = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel13 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxCodeTarifDynamiquePeriodique = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonEditionDeMasse = New Guna.UI.WinForms.GunaButton()
        Me.GunaLinePanelTop.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton3)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton2)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.Panel5)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelGestCompany)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(1077, 33)
        Me.GunaLinePanelTop.TabIndex = 4
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = CType(resources.GetObject("GunaImageButton3.Image"), System.Drawing.Image)
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(1020, 6)
        Me.GunaImageButton3.Name = "GunaImageButton3"
        Me.GunaImageButton3.OnHoverImage = Nothing
        Me.GunaImageButton3.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton3.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton3.TabIndex = 10
        '
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = CType(resources.GetObject("GunaImageButton2.Image"), System.Drawing.Image)
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(1045, 6)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 9
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1038, 6)
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
        Me.Panel4.Location = New System.Drawing.Point(0, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(135, 30)
        Me.Panel4.TabIndex = 2
        '
        'GunaLabelGestCompany
        '
        Me.GunaLabelGestCompany.AutoSize = True
        Me.GunaLabelGestCompany.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompany.Location = New System.Drawing.Point(425, 6)
        Me.GunaLabelGestCompany.Name = "GunaLabelGestCompany"
        Me.GunaLabelGestCompany.Size = New System.Drawing.Size(151, 21)
        Me.GunaLabelGestCompany.TabIndex = 1
        Me.GunaLabelGestCompany.Text = "EDITION DE MASSE"
        Me.GunaLabelGestCompany.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaButtonAppliquerTarifSpecifique
        '
        Me.GunaButtonAppliquerTarifSpecifique.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAppliquerTarifSpecifique.AnimationSpeed = 0.03!
        Me.GunaButtonAppliquerTarifSpecifique.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAppliquerTarifSpecifique.BaseColor = System.Drawing.Color.Indigo
        Me.GunaButtonAppliquerTarifSpecifique.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAppliquerTarifSpecifique.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAppliquerTarifSpecifique.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAppliquerTarifSpecifique.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaButtonAppliquerTarifSpecifique.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAppliquerTarifSpecifique.Image = Nothing
        Me.GunaButtonAppliquerTarifSpecifique.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAppliquerTarifSpecifique.Location = New System.Drawing.Point(944, 97)
        Me.GunaButtonAppliquerTarifSpecifique.Name = "GunaButtonAppliquerTarifSpecifique"
        Me.GunaButtonAppliquerTarifSpecifique.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAppliquerTarifSpecifique.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAppliquerTarifSpecifique.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAppliquerTarifSpecifique.OnHoverImage = Nothing
        Me.GunaButtonAppliquerTarifSpecifique.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAppliquerTarifSpecifique.Radius = 5
        Me.GunaButtonAppliquerTarifSpecifique.Size = New System.Drawing.Size(103, 25)
        Me.GunaButtonAppliquerTarifSpecifique.TabIndex = 6
        Me.GunaButtonAppliquerTarifSpecifique.Text = "Enregistrer"
        Me.GunaButtonAppliquerTarifSpecifique.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 239)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1081, 10)
        Me.GunaPanel1.TabIndex = 11
        '
        'GunaDateTimePickerDispoFin
        '
        Me.GunaDateTimePickerDispoFin.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDispoFin.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaDateTimePickerDispoFin.BorderSize = 1
        Me.GunaDateTimePickerDispoFin.CustomFormat = Nothing
        Me.GunaDateTimePickerDispoFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDispoFin.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDispoFin.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaDateTimePickerDispoFin.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDispoFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerDispoFin.Location = New System.Drawing.Point(486, 95)
        Me.GunaDateTimePickerDispoFin.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDispoFin.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDispoFin.Name = "GunaDateTimePickerDispoFin"
        Me.GunaDateTimePickerDispoFin.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDispoFin.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDispoFin.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDispoFin.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDispoFin.Size = New System.Drawing.Size(147, 30)
        Me.GunaDateTimePickerDispoFin.TabIndex = 12
        Me.GunaDateTimePickerDispoFin.Text = "19/08/2022"
        Me.GunaDateTimePickerDispoFin.Value = New Date(2022, 8, 19, 14, 47, 25, 641)
        '
        'GunaDateTimePickerDispoDebut
        '
        Me.GunaDateTimePickerDispoDebut.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDispoDebut.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaDateTimePickerDispoDebut.BorderSize = 1
        Me.GunaDateTimePickerDispoDebut.CustomFormat = Nothing
        Me.GunaDateTimePickerDispoDebut.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDispoDebut.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDispoDebut.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaDateTimePickerDispoDebut.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDispoDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerDispoDebut.Location = New System.Drawing.Point(308, 95)
        Me.GunaDateTimePickerDispoDebut.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDispoDebut.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDispoDebut.Name = "GunaDateTimePickerDispoDebut"
        Me.GunaDateTimePickerDispoDebut.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDispoDebut.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDispoDebut.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDispoDebut.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDispoDebut.Size = New System.Drawing.Size(141, 30)
        Me.GunaDateTimePickerDispoDebut.TabIndex = 13
        Me.GunaDateTimePickerDispoDebut.Text = "19/08/2022"
        Me.GunaDateTimePickerDispoDebut.Value = New Date(2022, 8, 19, 14, 47, 25, 641)
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(305, 73)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(27, 19)
        Me.GunaLabel1.TabIndex = 14
        Me.GunaLabel1.Text = "Du"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(483, 73)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(26, 19)
        Me.GunaLabel2.TabIndex = 15
        Me.GunaLabel2.Text = "Au"
        '
        'GunaComboBoxTypeDeChambre
        '
        Me.GunaComboBoxTypeDeChambre.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxTypeDeChambre.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxTypeDeChambre.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxTypeDeChambre.BorderSize = 1
        Me.GunaComboBoxTypeDeChambre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxTypeDeChambre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxTypeDeChambre.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxTypeDeChambre.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxTypeDeChambre.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxTypeDeChambre.FormattingEnabled = True
        Me.GunaComboBoxTypeDeChambre.ItemHeight = 24
        Me.GunaComboBoxTypeDeChambre.Location = New System.Drawing.Point(12, 95)
        Me.GunaComboBoxTypeDeChambre.Name = "GunaComboBoxTypeDeChambre"
        Me.GunaComboBoxTypeDeChambre.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxTypeDeChambre.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxTypeDeChambre.Radius = 5
        Me.GunaComboBoxTypeDeChambre.Size = New System.Drawing.Size(257, 30)
        Me.GunaComboBoxTypeDeChambre.TabIndex = 16
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel3.Location = New System.Drawing.Point(14, 73)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(113, 19)
        Me.GunaLabel3.TabIndex = 17
        Me.GunaLabel3.Text = "Type de chambre"
        '
        'GunaTextBoxMontant
        '
        Me.GunaTextBoxMontant.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontant.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontant.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontant.BorderSize = 1
        Me.GunaTextBoxMontant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontant.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontant.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontant.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontant.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxMontant.Location = New System.Drawing.Point(664, 95)
        Me.GunaTextBoxMontant.Name = "GunaTextBoxMontant"
        Me.GunaTextBoxMontant.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontant.Radius = 2
        Me.GunaTextBoxMontant.SelectedText = ""
        Me.GunaTextBoxMontant.Size = New System.Drawing.Size(91, 30)
        Me.GunaTextBoxMontant.TabIndex = 18
        Me.GunaTextBoxMontant.Text = "0"
        Me.GunaTextBoxMontant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel4.Location = New System.Drawing.Point(662, 73)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(63, 19)
        Me.GunaLabel4.TabIndex = 19
        Me.GunaLabel4.Text = "Montant"
        '
        'GunaComboBoxTypeDeTarif
        '
        Me.GunaComboBoxTypeDeTarif.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxTypeDeTarif.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxTypeDeTarif.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxTypeDeTarif.BorderSize = 1
        Me.GunaComboBoxTypeDeTarif.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxTypeDeTarif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxTypeDeTarif.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxTypeDeTarif.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxTypeDeTarif.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxTypeDeTarif.FormattingEnabled = True
        Me.GunaComboBoxTypeDeTarif.ItemHeight = 24
        Me.GunaComboBoxTypeDeTarif.Location = New System.Drawing.Point(814, 36)
        Me.GunaComboBoxTypeDeTarif.Name = "GunaComboBoxTypeDeTarif"
        Me.GunaComboBoxTypeDeTarif.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxTypeDeTarif.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxTypeDeTarif.Radius = 5
        Me.GunaComboBoxTypeDeTarif.Size = New System.Drawing.Size(258, 30)
        Me.GunaComboBoxTypeDeTarif.TabIndex = 16
        Me.GunaComboBoxTypeDeTarif.Visible = False
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabel5.Location = New System.Drawing.Point(381, 36)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(279, 19)
        Me.GunaLabel5.TabIndex = 17
        Me.GunaLabel5.Text = "TARIFICATION PERIODEIQUE  SPECIFIQUE"
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabel6.Location = New System.Drawing.Point(415, 145)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(177, 19)
        Me.GunaLabel6.TabIndex = 17
        Me.GunaLabel6.Text = "RESTRICTION SPECIFIQUE"
        Me.GunaLabel6.Visible = False
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel7.Location = New System.Drawing.Point(724, 40)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(84, 19)
        Me.GunaLabel7.TabIndex = 17
        Me.GunaLabel7.Text = "Type de tarif"
        Me.GunaLabel7.Visible = False
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.Indigo
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(943, 192)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 5
        Me.GunaButton1.Size = New System.Drawing.Size(85, 25)
        Me.GunaButton1.TabIndex = 6
        Me.GunaButton1.Text = "Appliquer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton1.Visible = False
        '
        'GunaDateTimePicker1
        '
        Me.GunaDateTimePicker1.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker1.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaDateTimePicker1.BorderSize = 1
        Me.GunaDateTimePicker1.CustomFormat = Nothing
        Me.GunaDateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePicker1.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaDateTimePicker1.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePicker1.Location = New System.Drawing.Point(540, 189)
        Me.GunaDateTimePicker1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePicker1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePicker1.Name = "GunaDateTimePicker1"
        Me.GunaDateTimePicker1.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker1.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker1.Size = New System.Drawing.Size(141, 30)
        Me.GunaDateTimePicker1.TabIndex = 13
        Me.GunaDateTimePicker1.Text = "19/08/2022"
        Me.GunaDateTimePicker1.Value = New Date(2022, 8, 19, 14, 47, 25, 641)
        Me.GunaDateTimePicker1.Visible = False
        '
        'GunaDateTimePicker2
        '
        Me.GunaDateTimePicker2.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker2.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaDateTimePicker2.BorderSize = 1
        Me.GunaDateTimePicker2.CustomFormat = Nothing
        Me.GunaDateTimePicker2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePicker2.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaDateTimePicker2.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePicker2.Location = New System.Drawing.Point(690, 189)
        Me.GunaDateTimePicker2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePicker2.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePicker2.Name = "GunaDateTimePicker2"
        Me.GunaDateTimePicker2.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker2.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker2.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker2.Size = New System.Drawing.Size(147, 30)
        Me.GunaDateTimePicker2.TabIndex = 12
        Me.GunaDateTimePicker2.Text = "19/08/2022"
        Me.GunaDateTimePicker2.Value = New Date(2022, 8, 19, 14, 47, 25, 641)
        Me.GunaDateTimePicker2.Visible = False
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel8.Location = New System.Drawing.Point(537, 167)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(27, 19)
        Me.GunaLabel8.TabIndex = 14
        Me.GunaLabel8.Text = "Du"
        Me.GunaLabel8.Visible = False
        '
        'GunaLabel9
        '
        Me.GunaLabel9.AutoSize = True
        Me.GunaLabel9.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel9.Location = New System.Drawing.Point(687, 167)
        Me.GunaLabel9.Name = "GunaLabel9"
        Me.GunaLabel9.Size = New System.Drawing.Size(26, 19)
        Me.GunaLabel9.TabIndex = 15
        Me.GunaLabel9.Text = "Au"
        Me.GunaLabel9.Visible = False
        '
        'GunaComboBox3
        '
        Me.GunaComboBox3.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBox3.BaseColor = System.Drawing.Color.White
        Me.GunaComboBox3.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBox3.BorderSize = 1
        Me.GunaComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBox3.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBox3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBox3.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBox3.FormattingEnabled = True
        Me.GunaComboBox3.ItemHeight = 24
        Me.GunaComboBox3.Location = New System.Drawing.Point(10, 189)
        Me.GunaComboBox3.Name = "GunaComboBox3"
        Me.GunaComboBox3.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBox3.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBox3.Radius = 5
        Me.GunaComboBox3.Size = New System.Drawing.Size(257, 30)
        Me.GunaComboBox3.TabIndex = 16
        Me.GunaComboBox3.Visible = False
        '
        'GunaComboBox4
        '
        Me.GunaComboBox4.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBox4.BaseColor = System.Drawing.Color.White
        Me.GunaComboBox4.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBox4.BorderSize = 1
        Me.GunaComboBox4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBox4.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBox4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBox4.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBox4.FormattingEnabled = True
        Me.GunaComboBox4.ItemHeight = 24
        Me.GunaComboBox4.Location = New System.Drawing.Point(276, 189)
        Me.GunaComboBox4.Name = "GunaComboBox4"
        Me.GunaComboBox4.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBox4.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBox4.Radius = 5
        Me.GunaComboBox4.Size = New System.Drawing.Size(258, 30)
        Me.GunaComboBox4.TabIndex = 16
        Me.GunaComboBox4.Visible = False
        '
        'GunaLabel10
        '
        Me.GunaLabel10.AutoSize = True
        Me.GunaLabel10.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel10.Location = New System.Drawing.Point(12, 167)
        Me.GunaLabel10.Name = "GunaLabel10"
        Me.GunaLabel10.Size = New System.Drawing.Size(113, 19)
        Me.GunaLabel10.TabIndex = 17
        Me.GunaLabel10.Text = "Type de chambre"
        Me.GunaLabel10.Visible = False
        '
        'GunaLabel11
        '
        Me.GunaLabel11.AutoSize = True
        Me.GunaLabel11.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel11.Location = New System.Drawing.Point(272, 167)
        Me.GunaLabel11.Name = "GunaLabel11"
        Me.GunaLabel11.Size = New System.Drawing.Size(84, 19)
        Me.GunaLabel11.TabIndex = 17
        Me.GunaLabel11.Text = "Type de tarif"
        Me.GunaLabel11.Visible = False
        '
        'GunaTextBox2
        '
        Me.GunaTextBox2.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox2.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox2.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBox2.BorderSize = 1
        Me.GunaTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox2.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox2.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox2.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox2.Location = New System.Drawing.Point(843, 189)
        Me.GunaTextBox2.Name = "GunaTextBox2"
        Me.GunaTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox2.Radius = 2
        Me.GunaTextBox2.SelectedText = ""
        Me.GunaTextBox2.Size = New System.Drawing.Size(91, 30)
        Me.GunaTextBox2.TabIndex = 18
        Me.GunaTextBox2.Visible = False
        '
        'GunaLabel12
        '
        Me.GunaLabel12.AutoSize = True
        Me.GunaLabel12.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel12.Location = New System.Drawing.Point(841, 167)
        Me.GunaLabel12.Name = "GunaLabel12"
        Me.GunaLabel12.Size = New System.Drawing.Size(63, 19)
        Me.GunaLabel12.TabIndex = 19
        Me.GunaLabel12.Text = "Montant"
        Me.GunaLabel12.Visible = False
        '
        'GunaComboBoxEtatEditionDeMasse
        '
        Me.GunaComboBoxEtatEditionDeMasse.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxEtatEditionDeMasse.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxEtatEditionDeMasse.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxEtatEditionDeMasse.BorderSize = 1
        Me.GunaComboBoxEtatEditionDeMasse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxEtatEditionDeMasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxEtatEditionDeMasse.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxEtatEditionDeMasse.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxEtatEditionDeMasse.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxEtatEditionDeMasse.FormattingEnabled = True
        Me.GunaComboBoxEtatEditionDeMasse.ItemHeight = 23
        Me.GunaComboBoxEtatEditionDeMasse.Location = New System.Drawing.Point(795, 95)
        Me.GunaComboBoxEtatEditionDeMasse.Name = "GunaComboBoxEtatEditionDeMasse"
        Me.GunaComboBoxEtatEditionDeMasse.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxEtatEditionDeMasse.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxEtatEditionDeMasse.Radius = 5
        Me.GunaComboBoxEtatEditionDeMasse.Size = New System.Drawing.Size(112, 29)
        Me.GunaComboBoxEtatEditionDeMasse.TabIndex = 20
        '
        'GunaLabel13
        '
        Me.GunaLabel13.AutoSize = True
        Me.GunaLabel13.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel13.Location = New System.Drawing.Point(794, 73)
        Me.GunaLabel13.Name = "GunaLabel13"
        Me.GunaLabel13.Size = New System.Drawing.Size(33, 19)
        Me.GunaLabel13.TabIndex = 19
        Me.GunaLabel13.Text = "Etat"
        '
        'GunaTextBoxCodeTarifDynamiquePeriodique
        '
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.Location = New System.Drawing.Point(12, 40)
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.Name = "GunaTextBoxCodeTarifDynamiquePeriodique"
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.SelectedText = ""
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.Size = New System.Drawing.Size(160, 26)
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.TabIndex = 21
        Me.GunaTextBoxCodeTarifDynamiquePeriodique.Visible = False
        '
        'GunaButtonEditionDeMasse
        '
        Me.GunaButtonEditionDeMasse.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEditionDeMasse.AnimationSpeed = 0.03!
        Me.GunaButtonEditionDeMasse.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEditionDeMasse.BaseColor = System.Drawing.Color.Indigo
        Me.GunaButtonEditionDeMasse.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEditionDeMasse.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEditionDeMasse.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEditionDeMasse.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaButtonEditionDeMasse.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEditionDeMasse.Image = Nothing
        Me.GunaButtonEditionDeMasse.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEditionDeMasse.Location = New System.Drawing.Point(426, 203)
        Me.GunaButtonEditionDeMasse.Name = "GunaButtonEditionDeMasse"
        Me.GunaButtonEditionDeMasse.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEditionDeMasse.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEditionDeMasse.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEditionDeMasse.OnHoverImage = Nothing
        Me.GunaButtonEditionDeMasse.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEditionDeMasse.Radius = 5
        Me.GunaButtonEditionDeMasse.Size = New System.Drawing.Size(140, 30)
        Me.GunaButtonEditionDeMasse.TabIndex = 22
        Me.GunaButtonEditionDeMasse.Text = "Liste des éditions"
        Me.GunaButtonEditionDeMasse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'editionDeMasseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 248)
        Me.Controls.Add(Me.GunaButtonEditionDeMasse)
        Me.Controls.Add(Me.GunaTextBoxCodeTarifDynamiquePeriodique)
        Me.Controls.Add(Me.GunaComboBoxEtatEditionDeMasse)
        Me.Controls.Add(Me.GunaLabel12)
        Me.Controls.Add(Me.GunaTextBox2)
        Me.Controls.Add(Me.GunaLabel13)
        Me.Controls.Add(Me.GunaLabel4)
        Me.Controls.Add(Me.GunaTextBoxMontant)
        Me.Controls.Add(Me.GunaLabel6)
        Me.Controls.Add(Me.GunaLabel11)
        Me.Controls.Add(Me.GunaLabel5)
        Me.Controls.Add(Me.GunaLabel10)
        Me.Controls.Add(Me.GunaLabel7)
        Me.Controls.Add(Me.GunaComboBox4)
        Me.Controls.Add(Me.GunaLabel3)
        Me.Controls.Add(Me.GunaComboBox3)
        Me.Controls.Add(Me.GunaComboBoxTypeDeTarif)
        Me.Controls.Add(Me.GunaLabel9)
        Me.Controls.Add(Me.GunaComboBoxTypeDeChambre)
        Me.Controls.Add(Me.GunaLabel8)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaDateTimePicker2)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaDateTimePicker1)
        Me.Controls.Add(Me.GunaDateTimePickerDispoFin)
        Me.Controls.Add(Me.GunaDateTimePickerDispoDebut)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaButtonAppliquerTarifSpecifique)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "editionDeMasseForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "editionDeMasseForm"
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GunaLabelGestCompany As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaButtonAppliquerTarifSpecifique As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaDateTimePickerDispoFin As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaDateTimePickerDispoDebut As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaComboBoxTypeDeChambre As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxMontant As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaComboBoxTypeDeTarif As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDateTimePicker1 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaDateTimePicker2 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel9 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaComboBox3 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaComboBox4 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel10 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel11 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBox2 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel12 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaComboBoxEtatEditionDeMasse As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel13 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxCodeTarifDynamiquePeriodique As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonEditionDeMasse As Guna.UI.WinForms.GunaButton
End Class
