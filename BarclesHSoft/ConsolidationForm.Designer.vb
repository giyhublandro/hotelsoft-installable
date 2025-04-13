<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsolidationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsolidationForm))
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanelTopPanel = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabelDateDeTravail = New Guna.UI.WinForms.GunaLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDataGridView1 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDataGridView3 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaDataGridView2 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonConsolider = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonVersGauche = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonVersDroite = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanelTopPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaPanelTopPanel
        '
        Me.GunaPanelTopPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaLabelDateDeTravail)
        Me.GunaPanelTopPanel.Controls.Add(Me.PictureBox2)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaLabel1)
        Me.GunaPanelTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanelTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanelTopPanel.Name = "GunaPanelTopPanel"
        Me.GunaPanelTopPanel.Size = New System.Drawing.Size(905, 25)
        Me.GunaPanelTopPanel.TabIndex = 4
        '
        'GunaLabelDateDeTravail
        '
        Me.GunaLabelDateDeTravail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLabelDateDeTravail.AutoSize = True
        Me.GunaLabelDateDeTravail.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabelDateDeTravail.ForeColor = System.Drawing.Color.White
        Me.GunaLabelDateDeTravail.Location = New System.Drawing.Point(373, 3)
        Me.GunaLabelDateDeTravail.Name = "GunaLabelDateDeTravail"
        Me.GunaLabelDateDeTravail.Size = New System.Drawing.Size(123, 19)
        Me.GunaLabelDateDeTravail.TabIndex = 77
        Me.GunaLabelDateDeTravail.Text = "CONSOLIDATION"
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(851, 3)
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
        Me.GunaImageButton1.Location = New System.Drawing.Point(875, 3)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2072, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaDataGridView1
        '
        Me.GunaDataGridView1.AllowUserToAddRows = False
        Me.GunaDataGridView1.AllowUserToDeleteRows = False
        Me.GunaDataGridView1.AllowUserToOrderColumns = True
        Me.GunaDataGridView1.AllowUserToResizeColumns = False
        Me.GunaDataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle37.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle37
        Me.GunaDataGridView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.GunaDataGridView1.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle38.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle38.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle38
        Me.GunaDataGridView1.ColumnHeadersHeight = 24
        Me.GunaDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView1.ColumnHeadersVisible = False
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView1.DefaultCellStyle = DataGridViewCellStyle39
        Me.GunaDataGridView1.EnableHeadersVisualStyles = False
        Me.GunaDataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.Location = New System.Drawing.Point(12, 56)
        Me.GunaDataGridView1.Name = "GunaDataGridView1"
        Me.GunaDataGridView1.ReadOnly = True
        Me.GunaDataGridView1.RowHeadersVisible = False
        Me.GunaDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView1.Size = New System.Drawing.Size(353, 276)
        Me.GunaDataGridView1.TabIndex = 307
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
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.Height = 24
        Me.GunaDataGridView1.ThemeStyle.ReadOnly = True
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(129, 35)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(128, 15)
        Me.GunaLabel2.TabIndex = 308
        Me.GunaLabel2.Text = "BONS DE COMMANDE"
        '
        'GunaDataGridView3
        '
        Me.GunaDataGridView3.AllowUserToAddRows = False
        Me.GunaDataGridView3.AllowUserToDeleteRows = False
        Me.GunaDataGridView3.AllowUserToOrderColumns = True
        Me.GunaDataGridView3.AllowUserToResizeColumns = False
        Me.GunaDataGridView3.AllowUserToResizeRows = False
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView3.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle40
        Me.GunaDataGridView3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaDataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.GunaDataGridView3.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle41.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle41.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle41
        Me.GunaDataGridView3.ColumnHeadersHeight = 24
        Me.GunaDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView3.ColumnHeadersVisible = False
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle42.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle42.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView3.DefaultCellStyle = DataGridViewCellStyle42
        Me.GunaDataGridView3.EnableHeadersVisualStyles = False
        Me.GunaDataGridView3.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView3.Location = New System.Drawing.Point(440, 212)
        Me.GunaDataGridView3.Name = "GunaDataGridView3"
        Me.GunaDataGridView3.ReadOnly = True
        Me.GunaDataGridView3.RowHeadersVisible = False
        Me.GunaDataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView3.Size = New System.Drawing.Size(453, 120)
        Me.GunaDataGridView3.TabIndex = 307
        Me.GunaDataGridView3.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridView3.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView3.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridView3.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView3.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridView3.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView3.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView3.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView3.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView3.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridView3.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView3.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView3.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView3.ThemeStyle.HeaderStyle.Height = 24
        Me.GunaDataGridView3.ThemeStyle.ReadOnly = True
        Me.GunaDataGridView3.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView3.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView3.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView3.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaDataGridView3.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView3.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView3.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaDataGridView2
        '
        Me.GunaDataGridView2.AllowUserToAddRows = False
        Me.GunaDataGridView2.AllowUserToDeleteRows = False
        Me.GunaDataGridView2.AllowUserToOrderColumns = True
        Me.GunaDataGridView2.AllowUserToResizeColumns = False
        Me.GunaDataGridView2.AllowUserToResizeRows = False
        DataGridViewCellStyle43.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle43
        Me.GunaDataGridView2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.GunaDataGridView2.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle44.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle44.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle44
        Me.GunaDataGridView2.ColumnHeadersHeight = 24
        Me.GunaDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView2.ColumnHeadersVisible = False
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle45.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle45.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle45.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView2.DefaultCellStyle = DataGridViewCellStyle45
        Me.GunaDataGridView2.EnableHeadersVisualStyles = False
        Me.GunaDataGridView2.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.Location = New System.Drawing.Point(440, 56)
        Me.GunaDataGridView2.Name = "GunaDataGridView2"
        Me.GunaDataGridView2.ReadOnly = True
        Me.GunaDataGridView2.RowHeadersVisible = False
        Me.GunaDataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView2.Size = New System.Drawing.Size(453, 120)
        Me.GunaDataGridView2.TabIndex = 307
        Me.GunaDataGridView2.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView2.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.Height = 24
        Me.GunaDataGridView2.ThemeStyle.ReadOnly = True
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel3.Location = New System.Drawing.Point(616, 190)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(111, 15)
        Me.GunaLabel3.TabIndex = 308
        Me.GunaLabel3.Text = "BONS CONSOLIDES"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel4.Location = New System.Drawing.Point(610, 35)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(122, 15)
        Me.GunaLabel4.TabIndex = 308
        Me.GunaLabel4.Text = "BONS A CONSOLIDES"
        '
        'GunaButtonConsolider
        '
        Me.GunaButtonConsolider.AnimationHoverSpeed = 0.07!
        Me.GunaButtonConsolider.AnimationSpeed = 0.03!
        Me.GunaButtonConsolider.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonConsolider.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonConsolider.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonConsolider.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonConsolider.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonConsolider.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonConsolider.ForeColor = System.Drawing.Color.White
        Me.GunaButtonConsolider.Image = Nothing
        Me.GunaButtonConsolider.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonConsolider.Location = New System.Drawing.Point(778, 29)
        Me.GunaButtonConsolider.Name = "GunaButtonConsolider"
        Me.GunaButtonConsolider.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonConsolider.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonConsolider.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonConsolider.OnHoverImage = Nothing
        Me.GunaButtonConsolider.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonConsolider.Radius = 4
        Me.GunaButtonConsolider.Size = New System.Drawing.Size(115, 22)
        Me.GunaButtonConsolider.TabIndex = 337
        Me.GunaButtonConsolider.Text = "Consolider"
        Me.GunaButtonConsolider.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonVersGauche
        '
        Me.GunaButtonVersGauche.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GunaButtonVersGauche.AnimationHoverSpeed = 0.07!
        Me.GunaButtonVersGauche.AnimationSpeed = 0.03!
        Me.GunaButtonVersGauche.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonVersGauche.BaseColor = System.Drawing.Color.Crimson
        Me.GunaButtonVersGauche.BorderColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonVersGauche.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonVersGauche.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonVersGauche.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonVersGauche.ForeColor = System.Drawing.Color.White
        Me.GunaButtonVersGauche.Image = Nothing
        Me.GunaButtonVersGauche.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonVersGauche.Location = New System.Drawing.Point(371, 255)
        Me.GunaButtonVersGauche.Name = "GunaButtonVersGauche"
        Me.GunaButtonVersGauche.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonVersGauche.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonVersGauche.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonVersGauche.OnHoverImage = Nothing
        Me.GunaButtonVersGauche.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonVersGauche.Radius = 4
        Me.GunaButtonVersGauche.Size = New System.Drawing.Size(63, 28)
        Me.GunaButtonVersGauche.TabIndex = 338
        Me.GunaButtonVersGauche.Tag = "Ajouter un passager"
        Me.GunaButtonVersGauche.Text = "<<<"
        Me.GunaButtonVersGauche.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonVersDroite
        '
        Me.GunaButtonVersDroite.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GunaButtonVersDroite.AnimationHoverSpeed = 0.07!
        Me.GunaButtonVersDroite.AnimationSpeed = 0.03!
        Me.GunaButtonVersDroite.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonVersDroite.BaseColor = System.Drawing.Color.LawnGreen
        Me.GunaButtonVersDroite.BorderColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonVersDroite.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonVersDroite.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonVersDroite.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonVersDroite.ForeColor = System.Drawing.Color.White
        Me.GunaButtonVersDroite.Image = Nothing
        Me.GunaButtonVersDroite.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonVersDroite.Location = New System.Drawing.Point(371, 96)
        Me.GunaButtonVersDroite.Name = "GunaButtonVersDroite"
        Me.GunaButtonVersDroite.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonVersDroite.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonVersDroite.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonVersDroite.OnHoverImage = Nothing
        Me.GunaButtonVersDroite.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonVersDroite.Radius = 4
        Me.GunaButtonVersDroite.Size = New System.Drawing.Size(63, 28)
        Me.GunaButtonVersDroite.TabIndex = 338
        Me.GunaButtonVersDroite.Tag = "Ajouter un passager"
        Me.GunaButtonVersDroite.Text = ">>>"
        Me.GunaButtonVersDroite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButton1.Location = New System.Drawing.Point(440, 29)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(115, 22)
        Me.GunaButton1.TabIndex = 337
        Me.GunaButton1.Text = "Annuler"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ConsolidationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 344)
        Me.Controls.Add(Me.GunaButtonVersDroite)
        Me.Controls.Add(Me.GunaButtonVersGauche)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaButtonConsolider)
        Me.Controls.Add(Me.GunaLabel4)
        Me.Controls.Add(Me.GunaLabel3)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaDataGridView2)
        Me.Controls.Add(Me.GunaDataGridView3)
        Me.Controls.Add(Me.GunaDataGridView1)
        Me.Controls.Add(Me.GunaPanelTopPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ConsolidationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consolidation"
        Me.GunaPanelTopPanel.ResumeLayout(False)
        Me.GunaPanelTopPanel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaPanelTopPanel As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabelDateDeTravail As Guna.UI.WinForms.GunaLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDataGridView1 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDataGridView3 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaDataGridView2 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonConsolider As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonVersGauche As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonVersDroite As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
End Class
