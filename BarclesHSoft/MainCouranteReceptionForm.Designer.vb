<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainCouranteReceptionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainCouranteReceptionForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.DataGridViewMainCouranteReception = New Guna.UI.WinForms.GunaDataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GunaDateTimePicker1Fin = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaDateTimePickerDebut = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaTextBoxLiveSearch = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel35 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonAfficher = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonImprimer = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelDateMainCourante = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.DataGridViewMainCouranteReception, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GunaPanel1.Size = New System.Drawing.Size(1200, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(1145, 3)
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
        Me.GunaImageButton5.Location = New System.Drawing.Point(1170, 3)
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
        Me.GunaImageButton3.Location = New System.Drawing.Point(1161, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(1161, 3)
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
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(474, 1)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(196, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "Main Courante Réception"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1165, 2)
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
        'DataGridViewMainCouranteReception
        '
        Me.DataGridViewMainCouranteReception.AllowUserToAddRows = False
        Me.DataGridViewMainCouranteReception.AllowUserToDeleteRows = False
        Me.DataGridViewMainCouranteReception.AllowUserToOrderColumns = True
        Me.DataGridViewMainCouranteReception.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DataGridViewMainCouranteReception.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewMainCouranteReception.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridViewMainCouranteReception.BackgroundColor = System.Drawing.Color.LightBlue
        Me.DataGridViewMainCouranteReception.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewMainCouranteReception.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridViewMainCouranteReception.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewMainCouranteReception.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewMainCouranteReception.ColumnHeadersHeight = 25
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewMainCouranteReception.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewMainCouranteReception.EnableHeadersVisualStyles = False
        Me.DataGridViewMainCouranteReception.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewMainCouranteReception.Location = New System.Drawing.Point(12, 117)
        Me.DataGridViewMainCouranteReception.MultiSelect = False
        Me.DataGridViewMainCouranteReception.Name = "DataGridViewMainCouranteReception"
        Me.DataGridViewMainCouranteReception.ReadOnly = True
        Me.DataGridViewMainCouranteReception.RowHeadersVisible = False
        Me.DataGridViewMainCouranteReception.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewMainCouranteReception.Size = New System.Drawing.Size(1176, 425)
        Me.DataGridViewMainCouranteReception.TabIndex = 34
        Me.DataGridViewMainCouranteReception.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.DataGridViewMainCouranteReception.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridViewMainCouranteReception.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DataGridViewMainCouranteReception.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DataGridViewMainCouranteReception.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DataGridViewMainCouranteReception.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DataGridViewMainCouranteReception.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.DataGridViewMainCouranteReception.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewMainCouranteReception.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewMainCouranteReception.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridViewMainCouranteReception.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewMainCouranteReception.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DataGridViewMainCouranteReception.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.DataGridViewMainCouranteReception.ThemeStyle.HeaderStyle.Height = 25
        Me.DataGridViewMainCouranteReception.ThemeStyle.ReadOnly = True
        Me.DataGridViewMainCouranteReception.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridViewMainCouranteReception.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridViewMainCouranteReception.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewMainCouranteReception.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DataGridViewMainCouranteReception.ThemeStyle.RowsStyle.Height = 22
        Me.DataGridViewMainCouranteReception.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewMainCouranteReception.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GunaDateTimePicker1Fin)
        Me.GroupBox4.Controls.Add(Me.GunaDateTimePickerDebut)
        Me.GroupBox4.Controls.Add(Me.GunaTextBoxLiveSearch)
        Me.GroupBox4.Controls.Add(Me.GunaLabel4)
        Me.GroupBox4.Controls.Add(Me.GunaLabel35)
        Me.GroupBox4.Controls.Add(Me.GunaButtonAfficher)
        Me.GroupBox4.Controls.Add(Me.GunaLabel3)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(86, 31)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1031, 80)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        '
        'GunaDateTimePicker1Fin
        '
        Me.GunaDateTimePicker1Fin.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker1Fin.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaDateTimePicker1Fin.BorderSize = 1
        Me.GunaDateTimePicker1Fin.CustomFormat = "yyyy-MM-dd"
        Me.GunaDateTimePicker1Fin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePicker1Fin.Enabled = False
        Me.GunaDateTimePicker1Fin.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1Fin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDateTimePicker1Fin.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker1Fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePicker1Fin.Location = New System.Drawing.Point(664, 33)
        Me.GunaDateTimePicker1Fin.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePicker1Fin.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePicker1Fin.Name = "GunaDateTimePicker1Fin"
        Me.GunaDateTimePicker1Fin.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker1Fin.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1Fin.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1Fin.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker1Fin.Size = New System.Drawing.Size(152, 32)
        Me.GunaDateTimePicker1Fin.TabIndex = 39
        Me.GunaDateTimePicker1Fin.Text = "06/07/2021"
        Me.GunaDateTimePicker1Fin.Value = New Date(2021, 7, 6, 12, 28, 28, 662)
        '
        'GunaDateTimePickerDebut
        '
        Me.GunaDateTimePickerDebut.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDebut.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaDateTimePickerDebut.BorderSize = 1
        Me.GunaDateTimePickerDebut.CustomFormat = "yyyy-MM-dd"
        Me.GunaDateTimePickerDebut.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDebut.Enabled = False
        Me.GunaDateTimePickerDebut.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDateTimePickerDebut.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerDebut.Location = New System.Drawing.Point(466, 33)
        Me.GunaDateTimePickerDebut.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDebut.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDebut.Name = "GunaDateTimePickerDebut"
        Me.GunaDateTimePickerDebut.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDebut.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDebut.Size = New System.Drawing.Size(158, 32)
        Me.GunaDateTimePickerDebut.TabIndex = 39
        Me.GunaDateTimePickerDebut.Text = "06/07/2021"
        Me.GunaDateTimePickerDebut.Value = New Date(2021, 7, 6, 12, 28, 28, 662)
        '
        'GunaTextBoxLiveSearch
        '
        Me.GunaTextBoxLiveSearch.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxLiveSearch.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxLiveSearch.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxLiveSearch.BorderSize = 1
        Me.GunaTextBoxLiveSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxLiveSearch.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxLiveSearch.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxLiveSearch.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxLiveSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxLiveSearch.Location = New System.Drawing.Point(9, 34)
        Me.GunaTextBoxLiveSearch.Name = "GunaTextBoxLiveSearch"
        Me.GunaTextBoxLiveSearch.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxLiveSearch.Radius = 4
        Me.GunaTextBoxLiveSearch.SelectedText = ""
        Me.GunaTextBoxLiveSearch.Size = New System.Drawing.Size(223, 34)
        Me.GunaTextBoxLiveSearch.TabIndex = 38
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel4.Location = New System.Drawing.Point(661, 10)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(25, 17)
        Me.GunaLabel4.TabIndex = 37
        Me.GunaLabel4.Text = "Au"
        Me.GunaLabel4.Visible = False
        '
        'GunaLabel35
        '
        Me.GunaLabel35.AutoSize = True
        Me.GunaLabel35.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel35.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel35.Location = New System.Drawing.Point(465, 10)
        Me.GunaLabel35.Name = "GunaLabel35"
        Me.GunaLabel35.Size = New System.Drawing.Size(26, 17)
        Me.GunaLabel35.TabIndex = 37
        Me.GunaLabel35.Text = "Du"
        Me.GunaLabel35.Visible = False
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
        Me.GunaButtonAfficher.Location = New System.Drawing.Point(892, 31)
        Me.GunaButtonAfficher.Name = "GunaButtonAfficher"
        Me.GunaButtonAfficher.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAfficher.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficher.OnHoverImage = Nothing
        Me.GunaButtonAfficher.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.Radius = 5
        Me.GunaButtonAfficher.Size = New System.Drawing.Size(121, 37)
        Me.GunaButtonAfficher.TabIndex = 36
        Me.GunaButtonAfficher.Text = "Afficher"
        Me.GunaButtonAfficher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel3.Location = New System.Drawing.Point(251, 39)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(170, 21)
        Me.GunaLabel3.TabIndex = 4
        Me.GunaLabel3.Text = "MAIN COURANTE DU:"
        Me.GunaLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaButtonImprimer
        '
        Me.GunaButtonImprimer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonImprimer.AnimationSpeed = 0.03!
        Me.GunaButtonImprimer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonImprimer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonImprimer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonImprimer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonImprimer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonImprimer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonImprimer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonImprimer.Image = Nothing
        Me.GunaButtonImprimer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonImprimer.Location = New System.Drawing.Point(1067, 554)
        Me.GunaButtonImprimer.Name = "GunaButtonImprimer"
        Me.GunaButtonImprimer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonImprimer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonImprimer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonImprimer.OnHoverImage = Nothing
        Me.GunaButtonImprimer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonImprimer.Radius = 5
        Me.GunaButtonImprimer.Size = New System.Drawing.Size(121, 27)
        Me.GunaButtonImprimer.TabIndex = 36
        Me.GunaButtonImprimer.Text = "Imprimer"
        Me.GunaButtonImprimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.ForeColor = System.Drawing.Color.ForestGreen
        Me.GunaLabel2.Location = New System.Drawing.Point(355, 122)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(257, 21)
        Me.GunaLabel2.TabIndex = 4
        Me.GunaLabel2.Text = "MAIN COURANTE RECEPTION DU "
        Me.GunaLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaLabelDateMainCourante
        '
        Me.GunaLabelDateMainCourante.AutoSize = True
        Me.GunaLabelDateMainCourante.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelDateMainCourante.ForeColor = System.Drawing.Color.ForestGreen
        Me.GunaLabelDateMainCourante.Location = New System.Drawing.Point(618, 122)
        Me.GunaLabelDateMainCourante.Name = "GunaLabelDateMainCourante"
        Me.GunaLabelDateMainCourante.Size = New System.Drawing.Size(257, 21)
        Me.GunaLabelDateMainCourante.TabIndex = 4
        Me.GunaLabelDateMainCourante.Text = "MAIN COURANTE RECEPTION DU "
        Me.GunaLabelDateMainCourante.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(-2, 589)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1201, 10)
        Me.GunaPanel2.TabIndex = 35
        '
        'MainCouranteReceptionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 600)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.DataGridViewMainCouranteReception)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GunaLabelDateMainCourante)
        Me.Controls.Add(Me.GunaButtonImprimer)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainCouranteReceptionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.DataGridViewMainCouranteReception, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents DataGridViewMainCouranteReception As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GunaTextBoxLiveSearch As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel35 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonImprimer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabelDateMainCourante As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDateTimePickerDebut As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaDateTimePicker1Fin As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaButtonAfficher As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
End Class
