<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoadData
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadData))
        Me.GunaTextBoxL1 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaProgressBarL1 = New Guna.UI.WinForms.GunaProgressBar()
        Me.GunaButtonParcourirL1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonL1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabelTitle = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDataGridView1 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaComboBoxSheetL1 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaPanelTopBar = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaResize1 = New Guna.UI.WinForms.GunaResize(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        CType(Me.GunaDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPanelTopBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaTextBoxL1
        '
        Me.GunaTextBoxL1.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxL1.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxL1.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxL1.BorderSize = 1
        Me.GunaTextBoxL1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxL1.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxL1.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxL1.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxL1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxL1.Location = New System.Drawing.Point(14, 39)
        Me.GunaTextBoxL1.Name = "GunaTextBoxL1"
        Me.GunaTextBoxL1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxL1.Radius = 5
        Me.GunaTextBoxL1.ReadOnly = True
        Me.GunaTextBoxL1.SelectedText = ""
        Me.GunaTextBoxL1.Size = New System.Drawing.Size(442, 26)
        Me.GunaTextBoxL1.TabIndex = 0
        '
        'GunaProgressBarL1
        '
        Me.GunaProgressBarL1.BackColor = System.Drawing.Color.Transparent
        Me.GunaProgressBarL1.BorderColor = System.Drawing.Color.Black
        Me.GunaProgressBarL1.ColorStyle = Guna.UI.WinForms.ColorStyle.[Default]
        Me.GunaProgressBarL1.IdleColor = System.Drawing.Color.Gainsboro
        Me.GunaProgressBarL1.Location = New System.Drawing.Point(952, 41)
        Me.GunaProgressBarL1.Name = "GunaProgressBarL1"
        Me.GunaProgressBarL1.ProgressMaxColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaProgressBarL1.ProgressMinColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaProgressBarL1.Radius = 5
        Me.GunaProgressBarL1.Size = New System.Drawing.Size(152, 22)
        Me.GunaProgressBarL1.TabIndex = 2
        '
        'GunaButtonParcourirL1
        '
        Me.GunaButtonParcourirL1.AnimationHoverSpeed = 0.07!
        Me.GunaButtonParcourirL1.AnimationSpeed = 0.03!
        Me.GunaButtonParcourirL1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonParcourirL1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonParcourirL1.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonParcourirL1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonParcourirL1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonParcourirL1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaButtonParcourirL1.ForeColor = System.Drawing.Color.White
        Me.GunaButtonParcourirL1.Image = Nothing
        Me.GunaButtonParcourirL1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonParcourirL1.Location = New System.Drawing.Point(465, 42)
        Me.GunaButtonParcourirL1.Name = "GunaButtonParcourirL1"
        Me.GunaButtonParcourirL1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonParcourirL1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonParcourirL1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonParcourirL1.OnHoverImage = Nothing
        Me.GunaButtonParcourirL1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonParcourirL1.Size = New System.Drawing.Size(43, 21)
        Me.GunaButtonParcourirL1.TabIndex = 4
        Me.GunaButtonParcourirL1.Text = "..."
        Me.GunaButtonParcourirL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonL1
        '
        Me.GunaButtonL1.AnimationHoverSpeed = 0.07!
        Me.GunaButtonL1.AnimationSpeed = 0.03!
        Me.GunaButtonL1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonL1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonL1.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonL1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonL1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonL1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaButtonL1.ForeColor = System.Drawing.Color.White
        Me.GunaButtonL1.Image = Nothing
        Me.GunaButtonL1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonL1.Location = New System.Drawing.Point(844, 40)
        Me.GunaButtonL1.Name = "GunaButtonL1"
        Me.GunaButtonL1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonL1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonL1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonL1.OnHoverImage = Nothing
        Me.GunaButtonL1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonL1.Radius = 5
        Me.GunaButtonL1.Size = New System.Drawing.Size(96, 25)
        Me.GunaButtonL1.TabIndex = 4
        Me.GunaButtonL1.Text = "Uploader"
        Me.GunaButtonL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaLabelTitle
        '
        Me.GunaLabelTitle.AutoSize = True
        Me.GunaLabelTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.GunaLabelTitle.ForeColor = System.Drawing.SystemColors.Info
        Me.GunaLabelTitle.Location = New System.Drawing.Point(364, 0)
        Me.GunaLabelTitle.Name = "GunaLabelTitle"
        Me.GunaLabelTitle.Size = New System.Drawing.Size(287, 25)
        Me.GunaLabelTitle.TabIndex = 5
        Me.GunaLabelTitle.Text = "IMPORTATION DE FICHIER EXCEL"
        '
        'GunaDataGridView1
        '
        Me.GunaDataGridView1.AllowUserToAddRows = False
        Me.GunaDataGridView1.AllowUserToResizeColumns = False
        Me.GunaDataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GunaDataGridView1.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridView1.ColumnHeadersHeight = 25
        Me.GunaDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridView1.EnableHeadersVisualStyles = False
        Me.GunaDataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.Location = New System.Drawing.Point(12, 71)
        Me.GunaDataGridView1.Name = "GunaDataGridView1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GunaDataGridView1.RowHeadersVisible = False
        Me.GunaDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView1.Size = New System.Drawing.Size(1095, 367)
        Me.GunaDataGridView1.TabIndex = 6
        Me.GunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView1.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridView1.ThemeStyle.ReadOnly = False
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaComboBoxSheetL1
        '
        Me.GunaComboBoxSheetL1.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxSheetL1.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxSheetL1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxSheetL1.BorderSize = 1
        Me.GunaComboBoxSheetL1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxSheetL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxSheetL1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxSheetL1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxSheetL1.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxSheetL1.FormattingEnabled = True
        Me.GunaComboBoxSheetL1.Location = New System.Drawing.Point(619, 39)
        Me.GunaComboBoxSheetL1.Name = "GunaComboBoxSheetL1"
        Me.GunaComboBoxSheetL1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxSheetL1.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxSheetL1.Radius = 5
        Me.GunaComboBoxSheetL1.Size = New System.Drawing.Size(216, 26)
        Me.GunaComboBoxSheetL1.TabIndex = 7
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(539, 45)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(71, 15)
        Me.GunaLabel1.TabIndex = 8
        Me.GunaLabel1.Text = "Feuille Excel"
        '
        'GunaImageButton5
        '
        Me.GunaImageButton5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton5.Image = CType(resources.GetObject("GunaImageButton5.Image"), System.Drawing.Image)
        Me.GunaImageButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton5.Location = New System.Drawing.Point(1080, 3)
        Me.GunaImageButton5.Name = "GunaImageButton5"
        Me.GunaImageButton5.OnHoverImage = Nothing
        Me.GunaImageButton5.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton5.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton5.TabIndex = 9
        '
        'GunaPanelTopBar
        '
        Me.GunaPanelTopBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanelTopBar.Controls.Add(Me.GunaImageButton5)
        Me.GunaPanelTopBar.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanelTopBar.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanelTopBar.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanelTopBar.Controls.Add(Me.GunaLabelTitle)
        Me.GunaPanelTopBar.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanelTopBar.Controls.Add(Me.GunaLabel3)
        Me.GunaPanelTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanelTopBar.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanelTopBar.Name = "GunaPanelTopBar"
        Me.GunaPanelTopBar.Size = New System.Drawing.Size(1119, 25)
        Me.GunaPanelTopBar.TabIndex = 9
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = Nothing
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(1087, 2)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 8
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = Nothing
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(1085, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(1085, 3)
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
        Me.GunaImageButton1.Location = New System.Drawing.Point(1084, 2)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 2
        '
        'GunaLabel3
        '
        Me.GunaLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.White
        Me.GunaLabel3.Location = New System.Drawing.Point(2286, -2)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel3.TabIndex = 1
        Me.GunaLabel3.Text = "X"
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.Indigo
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 478)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1119, 14)
        Me.GunaPanel2.TabIndex = 10
        '
        'GunaResize1
        '
        Me.GunaResize1.TargetForm = Me
        '
        'GunaElipse1
        '
        Me.GunaElipse1.Radius = 10
        Me.GunaElipse1.TargetControl = Me
        '
        'Timer1
        '
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.Green
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(517, 444)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 5
        Me.GunaButton1.Size = New System.Drawing.Size(96, 30)
        Me.GunaButton1.TabIndex = 4
        Me.GunaButton1.Text = "Terminer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLabelTitle
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaPanelTopBar
        '
        'LoadData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 490)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaPanelTopBar)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaComboBoxSheetL1)
        Me.Controls.Add(Me.GunaDataGridView1)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaButtonL1)
        Me.Controls.Add(Me.GunaButtonParcourirL1)
        Me.Controls.Add(Me.GunaProgressBarL1)
        Me.Controls.Add(Me.GunaTextBoxL1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LoadData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoadData"
        CType(Me.GunaDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPanelTopBar.ResumeLayout(False)
        Me.GunaPanelTopBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaTextBoxL1 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaProgressBarL1 As Guna.UI.WinForms.GunaProgressBar
    Friend WithEvents GunaButtonParcourirL1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonL1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabelTitle As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDataGridView1 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaComboBoxSheetL1 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanelTopBar As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaResize1 As Guna.UI.WinForms.GunaResize
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
End Class
