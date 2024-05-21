<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CahierDeConsigneForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CahierDeConsigneForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxCodeConsigneSelectionne = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabelTitreDeLaFenetre = New Guna.UI.WinForms.GunaLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonFiltrer = New Guna.UI.WinForms.GunaButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBoxFiltre = New System.Windows.Forms.GroupBox()
        Me.GunaCheckBoxFait = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaDateTimePickerFin = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaDateTimePickerDebut = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonSupprimerConsigne = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonNouvelle = New Guna.UI.WinForms.GunaButton()
        Me.GunaDataGridViewConsigneList = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaDataGridViewConsigneComment = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaButtonComment = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxConsigneInfo = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxConsigneMessage = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonValiderConsigne = New Guna.UI.WinForms.GunaButton()
        Me.GunaPictureBoxValidated = New Guna.UI.WinForms.GunaPictureBox()
        Me.GunaDataGridViewConsigneMessage = New Guna.UI.WinForms.GunaDataGridView()
        Me.consigne = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBoxFiltre.SuspendLayout()
        CType(Me.GunaDataGridViewConsigneList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridViewConsigneComment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaPictureBoxValidated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridViewConsigneMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaTextBoxCodeConsigneSelectionne)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelTitreDeLaFenetre)
        Me.GunaPanel1.Controls.Add(Me.PictureBox2)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1200, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaTextBoxCodeConsigneSelectionne
        '
        Me.GunaTextBoxCodeConsigneSelectionne.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeConsigneSelectionne.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxCodeConsigneSelectionne.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeConsigneSelectionne.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeConsigneSelectionne.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeConsigneSelectionne.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeConsigneSelectionne.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxCodeConsigneSelectionne.Location = New System.Drawing.Point(916, -1)
        Me.GunaTextBoxCodeConsigneSelectionne.Name = "GunaTextBoxCodeConsigneSelectionne"
        Me.GunaTextBoxCodeConsigneSelectionne.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeConsigneSelectionne.SelectedText = ""
        Me.GunaTextBoxCodeConsigneSelectionne.Size = New System.Drawing.Size(112, 26)
        Me.GunaTextBoxCodeConsigneSelectionne.TabIndex = 205
        Me.GunaTextBoxCodeConsigneSelectionne.Text = "CODE_CONSIGNE"
        Me.GunaTextBoxCodeConsigneSelectionne.Visible = False
        '
        'GunaLabelTitreDeLaFenetre
        '
        Me.GunaLabelTitreDeLaFenetre.AutoSize = True
        Me.GunaLabelTitreDeLaFenetre.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelTitreDeLaFenetre.ForeColor = System.Drawing.Color.White
        Me.GunaLabelTitreDeLaFenetre.Location = New System.Drawing.Point(461, -1)
        Me.GunaLabelTitreDeLaFenetre.Name = "GunaLabelTitreDeLaFenetre"
        Me.GunaLabelTitreDeLaFenetre.Size = New System.Drawing.Size(238, 25)
        Me.GunaLabelTitreDeLaFenetre.TabIndex = 26
        Me.GunaLabelTitreDeLaFenetre.Text = "CAHIER  DES CONSIGNES"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 22)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 25
        Me.PictureBox2.TabStop = False
        '
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = CType(resources.GetObject("GunaImageButton2.Image"), System.Drawing.Image)
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(1146, 3)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 3
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1170, 3)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2367, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaButtonFiltrer
        '
        Me.GunaButtonFiltrer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonFiltrer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonFiltrer.AnimationSpeed = 0.03!
        Me.GunaButtonFiltrer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonFiltrer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonFiltrer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonFiltrer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonFiltrer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonFiltrer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonFiltrer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonFiltrer.Image = Nothing
        Me.GunaButtonFiltrer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonFiltrer.Location = New System.Drawing.Point(756, 33)
        Me.GunaButtonFiltrer.Name = "GunaButtonFiltrer"
        Me.GunaButtonFiltrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonFiltrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonFiltrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonFiltrer.OnHoverImage = Nothing
        Me.GunaButtonFiltrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonFiltrer.Radius = 5
        Me.GunaButtonFiltrer.Size = New System.Drawing.Size(80, 31)
        Me.GunaButtonFiltrer.TabIndex = 203
        Me.GunaButtonFiltrer.Text = "Filtrer"
        Me.GunaButtonFiltrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.GroupBoxFiltre)
        Me.GroupBox1.Controls.Add(Me.GunaButtonSupprimerConsigne)
        Me.GroupBox1.Controls.Add(Me.GunaButtonNouvelle)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1176, 108)
        Me.GroupBox1.TabIndex = 204
        Me.GroupBox1.TabStop = False
        '
        'GroupBoxFiltre
        '
        Me.GroupBoxFiltre.Controls.Add(Me.GunaCheckBoxFait)
        Me.GroupBoxFiltre.Controls.Add(Me.GunaDateTimePickerFin)
        Me.GroupBoxFiltre.Controls.Add(Me.GunaButtonFiltrer)
        Me.GroupBoxFiltre.Controls.Add(Me.GunaDateTimePickerDebut)
        Me.GroupBoxFiltre.Controls.Add(Me.GunaLabel4)
        Me.GroupBoxFiltre.Controls.Add(Me.GunaLabel3)
        Me.GroupBoxFiltre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxFiltre.ForeColor = System.Drawing.Color.Indigo
        Me.GroupBoxFiltre.Location = New System.Drawing.Point(289, 13)
        Me.GroupBoxFiltre.Name = "GroupBoxFiltre"
        Me.GroupBoxFiltre.Size = New System.Drawing.Size(872, 83)
        Me.GroupBoxFiltre.TabIndex = 204
        Me.GroupBoxFiltre.TabStop = False
        Me.GroupBoxFiltre.Text = "Filtres"
        '
        'GunaCheckBoxFait
        '
        Me.GunaCheckBoxFait.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxFait.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxFait.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxFait.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxFait.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxFait.Location = New System.Drawing.Point(153, 40)
        Me.GunaCheckBoxFait.Name = "GunaCheckBoxFait"
        Me.GunaCheckBoxFait.Size = New System.Drawing.Size(65, 20)
        Me.GunaCheckBoxFait.TabIndex = 204
        Me.GunaCheckBoxFait.Text = "Faite"
        '
        'GunaDateTimePickerFin
        '
        Me.GunaDateTimePickerFin.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerFin.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerFin.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaDateTimePickerFin.BorderSize = 1
        Me.GunaDateTimePickerFin.CustomFormat = Nothing
        Me.GunaDateTimePickerFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerFin.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaDateTimePickerFin.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerFin.Location = New System.Drawing.Point(556, 34)
        Me.GunaDateTimePickerFin.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerFin.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerFin.Name = "GunaDateTimePickerFin"
        Me.GunaDateTimePickerFin.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerFin.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerFin.Radius = 5
        Me.GunaDateTimePickerFin.Size = New System.Drawing.Size(136, 30)
        Me.GunaDateTimePickerFin.TabIndex = 2
        Me.GunaDateTimePickerFin.Text = "24/01/2022"
        Me.GunaDateTimePickerFin.Value = New Date(2022, 1, 24, 3, 29, 20, 370)
        '
        'GunaDateTimePickerDebut
        '
        Me.GunaDateTimePickerDebut.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerDebut.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDebut.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaDateTimePickerDebut.BorderSize = 1
        Me.GunaDateTimePickerDebut.CustomFormat = Nothing
        Me.GunaDateTimePickerDebut.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDebut.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaDateTimePickerDebut.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerDebut.Location = New System.Drawing.Point(336, 34)
        Me.GunaDateTimePickerDebut.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDebut.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDebut.Name = "GunaDateTimePickerDebut"
        Me.GunaDateTimePickerDebut.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDebut.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDebut.Radius = 5
        Me.GunaDateTimePickerDebut.Size = New System.Drawing.Size(137, 30)
        Me.GunaDateTimePickerDebut.TabIndex = 2
        Me.GunaDateTimePickerDebut.Text = "24/01/2022"
        Me.GunaDateTimePickerDebut.Value = New Date(2022, 1, 24, 3, 29, 20, 370)
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GunaLabel4.Location = New System.Drawing.Point(489, 40)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(60, 19)
        Me.GunaLabel4.TabIndex = 0
        Me.GunaLabel4.Text = "Date Fin"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GunaLabel3.Location = New System.Drawing.Point(247, 40)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(78, 19)
        Me.GunaLabel3.TabIndex = 0
        Me.GunaLabel3.Text = "Date début"
        '
        'GunaButtonSupprimerConsigne
        '
        Me.GunaButtonSupprimerConsigne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonSupprimerConsigne.AnimationHoverSpeed = 0.07!
        Me.GunaButtonSupprimerConsigne.AnimationSpeed = 0.03!
        Me.GunaButtonSupprimerConsigne.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonSupprimerConsigne.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonSupprimerConsigne.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonSupprimerConsigne.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonSupprimerConsigne.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonSupprimerConsigne.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonSupprimerConsigne.ForeColor = System.Drawing.Color.White
        Me.GunaButtonSupprimerConsigne.Image = Nothing
        Me.GunaButtonSupprimerConsigne.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonSupprimerConsigne.Location = New System.Drawing.Point(20, 43)
        Me.GunaButtonSupprimerConsigne.Name = "GunaButtonSupprimerConsigne"
        Me.GunaButtonSupprimerConsigne.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonSupprimerConsigne.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonSupprimerConsigne.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonSupprimerConsigne.OnHoverImage = Nothing
        Me.GunaButtonSupprimerConsigne.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonSupprimerConsigne.Radius = 5
        Me.GunaButtonSupprimerConsigne.Size = New System.Drawing.Size(88, 31)
        Me.GunaButtonSupprimerConsigne.TabIndex = 203
        Me.GunaButtonSupprimerConsigne.Text = "SUPPRIMER"
        Me.GunaButtonSupprimerConsigne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonNouvelle
        '
        Me.GunaButtonNouvelle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonNouvelle.AnimationHoverSpeed = 0.07!
        Me.GunaButtonNouvelle.AnimationSpeed = 0.03!
        Me.GunaButtonNouvelle.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonNouvelle.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonNouvelle.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonNouvelle.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonNouvelle.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonNouvelle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonNouvelle.ForeColor = System.Drawing.Color.White
        Me.GunaButtonNouvelle.Image = Nothing
        Me.GunaButtonNouvelle.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonNouvelle.Location = New System.Drawing.Point(130, 43)
        Me.GunaButtonNouvelle.Name = "GunaButtonNouvelle"
        Me.GunaButtonNouvelle.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonNouvelle.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonNouvelle.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonNouvelle.OnHoverImage = Nothing
        Me.GunaButtonNouvelle.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonNouvelle.Radius = 5
        Me.GunaButtonNouvelle.Size = New System.Drawing.Size(88, 31)
        Me.GunaButtonNouvelle.TabIndex = 203
        Me.GunaButtonNouvelle.Text = "NOUVELLE"
        Me.GunaButtonNouvelle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaDataGridViewConsigneList
        '
        Me.GunaDataGridViewConsigneList.AllowUserToAddRows = False
        Me.GunaDataGridViewConsigneList.AllowUserToDeleteRows = False
        Me.GunaDataGridViewConsigneList.AllowUserToOrderColumns = True
        Me.GunaDataGridViewConsigneList.AllowUserToResizeColumns = False
        Me.GunaDataGridViewConsigneList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GunaDataGridViewConsigneList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewConsigneList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaDataGridViewConsigneList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewConsigneList.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewConsigneList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewConsigneList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewConsigneList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewConsigneList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewConsigneList.ColumnHeadersHeight = 25
        Me.GunaDataGridViewConsigneList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(216, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(125, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewConsigneList.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewConsigneList.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewConsigneList.GridColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.GunaDataGridViewConsigneList.Location = New System.Drawing.Point(12, 163)
        Me.GunaDataGridViewConsigneList.MultiSelect = False
        Me.GunaDataGridViewConsigneList.Name = "GunaDataGridViewConsigneList"
        Me.GunaDataGridViewConsigneList.ReadOnly = True
        Me.GunaDataGridViewConsigneList.RowHeadersVisible = False
        Me.GunaDataGridViewConsigneList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewConsigneList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewConsigneList.Size = New System.Drawing.Size(595, 460)
        Me.GunaDataGridViewConsigneList.TabIndex = 205
        Me.GunaDataGridViewConsigneList.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Alizarin
        Me.GunaDataGridViewConsigneList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GunaDataGridViewConsigneList.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewConsigneList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneList.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewConsigneList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.GunaDataGridViewConsigneList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GunaDataGridViewConsigneList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.GunaDataGridViewConsigneList.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewConsigneList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewConsigneList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewConsigneList.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewConsigneList.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewConsigneList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.GunaDataGridViewConsigneList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewConsigneList.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewConsigneList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.GunaDataGridViewConsigneList.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewConsigneList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.GunaDataGridViewConsigneList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'GunaDataGridViewConsigneComment
        '
        Me.GunaDataGridViewConsigneComment.AllowUserToAddRows = False
        Me.GunaDataGridViewConsigneComment.AllowUserToDeleteRows = False
        Me.GunaDataGridViewConsigneComment.AllowUserToOrderColumns = True
        Me.GunaDataGridViewConsigneComment.AllowUserToResizeColumns = False
        Me.GunaDataGridViewConsigneComment.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.GunaDataGridViewConsigneComment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GunaDataGridViewConsigneComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaDataGridViewConsigneComment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewConsigneComment.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewConsigneComment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewConsigneComment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewConsigneComment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewConsigneComment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.GunaDataGridViewConsigneComment.ColumnHeadersHeight = 25
        Me.GunaDataGridViewConsigneComment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(211, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(107, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewConsigneComment.DefaultCellStyle = DataGridViewCellStyle6
        Me.GunaDataGridViewConsigneComment.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewConsigneComment.GridColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.GunaDataGridViewConsigneComment.Location = New System.Drawing.Point(613, 511)
        Me.GunaDataGridViewConsigneComment.MultiSelect = False
        Me.GunaDataGridViewConsigneComment.Name = "GunaDataGridViewConsigneComment"
        Me.GunaDataGridViewConsigneComment.ReadOnly = True
        Me.GunaDataGridViewConsigneComment.RowHeadersVisible = False
        Me.GunaDataGridViewConsigneComment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewConsigneComment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewConsigneComment.Size = New System.Drawing.Size(575, 112)
        Me.GunaDataGridViewConsigneComment.TabIndex = 205
        Me.GunaDataGridViewConsigneComment.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Carrot
        Me.GunaDataGridViewConsigneComment.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.GunaDataGridViewConsigneComment.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewConsigneComment.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneComment.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneComment.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneComment.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewConsigneComment.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.GunaDataGridViewConsigneComment.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.GunaDataGridViewConsigneComment.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.GunaDataGridViewConsigneComment.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewConsigneComment.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewConsigneComment.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewConsigneComment.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewConsigneComment.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewConsigneComment.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.GunaDataGridViewConsigneComment.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewConsigneComment.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewConsigneComment.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.GunaDataGridViewConsigneComment.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewConsigneComment.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.GunaDataGridViewConsigneComment.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'GunaButtonComment
        '
        Me.GunaButtonComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonComment.AnimationHoverSpeed = 0.07!
        Me.GunaButtonComment.AnimationSpeed = 0.03!
        Me.GunaButtonComment.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonComment.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonComment.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonComment.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonComment.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonComment.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonComment.ForeColor = System.Drawing.Color.White
        Me.GunaButtonComment.Image = Nothing
        Me.GunaButtonComment.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonComment.Location = New System.Drawing.Point(1079, 633)
        Me.GunaButtonComment.Name = "GunaButtonComment"
        Me.GunaButtonComment.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonComment.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonComment.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonComment.OnHoverImage = Nothing
        Me.GunaButtonComment.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonComment.Radius = 5
        Me.GunaButtonComment.Size = New System.Drawing.Size(110, 24)
        Me.GunaButtonComment.TabIndex = 203
        Me.GunaButtonComment.Text = "Commenter"
        Me.GunaButtonComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButtonComment.Visible = False
        '
        'GunaTextBoxConsigneInfo
        '
        Me.GunaTextBoxConsigneInfo.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxConsigneInfo.BaseColor = System.Drawing.Color.Salmon
        Me.GunaTextBoxConsigneInfo.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxConsigneInfo.BorderSize = 1
        Me.GunaTextBoxConsigneInfo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxConsigneInfo.Enabled = False
        Me.GunaTextBoxConsigneInfo.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxConsigneInfo.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxConsigneInfo.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxConsigneInfo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.GunaTextBoxConsigneInfo.Location = New System.Drawing.Point(613, 163)
        Me.GunaTextBoxConsigneInfo.Multiline = True
        Me.GunaTextBoxConsigneInfo.Name = "GunaTextBoxConsigneInfo"
        Me.GunaTextBoxConsigneInfo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxConsigneInfo.Radius = 3
        Me.GunaTextBoxConsigneInfo.SelectedText = ""
        Me.GunaTextBoxConsigneInfo.Size = New System.Drawing.Size(508, 32)
        Me.GunaTextBoxConsigneInfo.TabIndex = 206
        '
        'GunaTextBoxConsigneMessage
        '
        Me.GunaTextBoxConsigneMessage.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxConsigneMessage.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxConsigneMessage.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxConsigneMessage.BorderSize = 1
        Me.GunaTextBoxConsigneMessage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxConsigneMessage.Enabled = False
        Me.GunaTextBoxConsigneMessage.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxConsigneMessage.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxConsigneMessage.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxConsigneMessage.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.GunaTextBoxConsigneMessage.Location = New System.Drawing.Point(21, 410)
        Me.GunaTextBoxConsigneMessage.Multiline = True
        Me.GunaTextBoxConsigneMessage.Name = "GunaTextBoxConsigneMessage"
        Me.GunaTextBoxConsigneMessage.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxConsigneMessage.Radius = 5
        Me.GunaTextBoxConsigneMessage.SelectedText = ""
        Me.GunaTextBoxConsigneMessage.Size = New System.Drawing.Size(575, 213)
        Me.GunaTextBoxConsigneMessage.TabIndex = 206
        Me.GunaTextBoxConsigneMessage.Visible = False
        '
        'GunaButtonValiderConsigne
        '
        Me.GunaButtonValiderConsigne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonValiderConsigne.AnimationHoverSpeed = 0.07!
        Me.GunaButtonValiderConsigne.AnimationSpeed = 0.03!
        Me.GunaButtonValiderConsigne.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonValiderConsigne.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonValiderConsigne.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonValiderConsigne.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonValiderConsigne.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonValiderConsigne.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonValiderConsigne.ForeColor = System.Drawing.Color.White
        Me.GunaButtonValiderConsigne.Image = Nothing
        Me.GunaButtonValiderConsigne.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonValiderConsigne.Location = New System.Drawing.Point(613, 633)
        Me.GunaButtonValiderConsigne.Name = "GunaButtonValiderConsigne"
        Me.GunaButtonValiderConsigne.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonValiderConsigne.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonValiderConsigne.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonValiderConsigne.OnHoverImage = Nothing
        Me.GunaButtonValiderConsigne.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonValiderConsigne.Radius = 5
        Me.GunaButtonValiderConsigne.Size = New System.Drawing.Size(80, 24)
        Me.GunaButtonValiderConsigne.TabIndex = 203
        Me.GunaButtonValiderConsigne.Text = "Faite"
        Me.GunaButtonValiderConsigne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButtonValiderConsigne.Visible = False
        '
        'GunaPictureBoxValidated
        '
        Me.GunaPictureBoxValidated.BaseColor = System.Drawing.Color.White
        Me.GunaPictureBoxValidated.Image = CType(resources.GetObject("GunaPictureBoxValidated.Image"), System.Drawing.Image)
        Me.GunaPictureBoxValidated.Location = New System.Drawing.Point(1127, 164)
        Me.GunaPictureBoxValidated.Name = "GunaPictureBoxValidated"
        Me.GunaPictureBoxValidated.Size = New System.Drawing.Size(61, 31)
        Me.GunaPictureBoxValidated.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GunaPictureBoxValidated.TabIndex = 207
        Me.GunaPictureBoxValidated.TabStop = False
        Me.GunaPictureBoxValidated.Visible = False
        '
        'GunaDataGridViewConsigneMessage
        '
        Me.GunaDataGridViewConsigneMessage.AllowUserToAddRows = False
        Me.GunaDataGridViewConsigneMessage.AllowUserToDeleteRows = False
        Me.GunaDataGridViewConsigneMessage.AllowUserToOrderColumns = True
        Me.GunaDataGridViewConsigneMessage.AllowUserToResizeColumns = False
        Me.GunaDataGridViewConsigneMessage.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.GunaDataGridViewConsigneMessage.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GunaDataGridViewConsigneMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaDataGridViewConsigneMessage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewConsigneMessage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GunaDataGridViewConsigneMessage.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewConsigneMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewConsigneMessage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewConsigneMessage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewConsigneMessage.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GunaDataGridViewConsigneMessage.ColumnHeadersHeight = 25
        Me.GunaDataGridViewConsigneMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewConsigneMessage.ColumnHeadersVisible = False
        Me.GunaDataGridViewConsigneMessage.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.consigne})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(211, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(107, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewConsigneMessage.DefaultCellStyle = DataGridViewCellStyle9
        Me.GunaDataGridViewConsigneMessage.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewConsigneMessage.GridColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.GunaDataGridViewConsigneMessage.Location = New System.Drawing.Point(614, 205)
        Me.GunaDataGridViewConsigneMessage.MultiSelect = False
        Me.GunaDataGridViewConsigneMessage.Name = "GunaDataGridViewConsigneMessage"
        Me.GunaDataGridViewConsigneMessage.ReadOnly = True
        Me.GunaDataGridViewConsigneMessage.RowHeadersVisible = False
        Me.GunaDataGridViewConsigneMessage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewConsigneMessage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewConsigneMessage.Size = New System.Drawing.Size(575, 291)
        Me.GunaDataGridViewConsigneMessage.TabIndex = 205
        Me.GunaDataGridViewConsigneMessage.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Carrot
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.GunaDataGridViewConsigneMessage.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'consigne
        '
        Me.consigne.HeaderText = "consigne"
        Me.consigne.Name = "consigne"
        Me.consigne.ReadOnly = True
        '
        'CahierDeConsigneForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 665)
        Me.Controls.Add(Me.GunaPictureBoxValidated)
        Me.Controls.Add(Me.GunaButtonValiderConsigne)
        Me.Controls.Add(Me.GunaTextBoxConsigneMessage)
        Me.Controls.Add(Me.GunaTextBoxConsigneInfo)
        Me.Controls.Add(Me.GunaButtonComment)
        Me.Controls.Add(Me.GunaDataGridViewConsigneMessage)
        Me.Controls.Add(Me.GunaDataGridViewConsigneComment)
        Me.Controls.Add(Me.GunaDataGridViewConsigneList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CahierDeConsigneForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CahierDeConsigneForm"
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBoxFiltre.ResumeLayout(False)
        Me.GroupBoxFiltre.PerformLayout()
        CType(Me.GunaDataGridViewConsigneList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridViewConsigneComment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaPictureBoxValidated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridViewConsigneMessage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabelTitreDeLaFenetre As Guna.UI.WinForms.GunaLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonFiltrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GunaButtonSupprimerConsigne As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonNouvelle As Guna.UI.WinForms.GunaButton
    Friend WithEvents GroupBoxFiltre As GroupBox
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDateTimePickerFin As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaDateTimePickerDebut As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDataGridViewConsigneList As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaDataGridViewConsigneComment As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaButtonComment As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxConsigneInfo As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxConsigneMessage As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeConsigneSelectionne As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonValiderConsigne As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPictureBoxValidated As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents GunaCheckBoxFait As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaDataGridViewConsigneMessage As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents consigne As DataGridViewTextBoxColumn
End Class
