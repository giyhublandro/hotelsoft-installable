<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanierForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PanierForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPictureBoxLogo = New Guna.UI.WinForms.GunaPictureBox()
        Me.GunaNumericQte = New Guna.UI.WinForms.GunaNumeric()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDataGridViewLigneFacture = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelPu = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelPrixTotal = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxCodeArticle = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonAjouterAuPanier = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaComboBoxUniteOuConso = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaPanelCommande = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxCodeFacture = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNumeroBlocNote = New Guna.UI.WinForms.GunaTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GunaPanel1.SuspendLayout()
        CType(Me.GunaPictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridViewLigneFacture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPanelCommande.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(921, 25)
        Me.GunaPanel1.TabIndex = 2
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(892, 3)
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
        Me.GunaImageButton3.Location = New System.Drawing.Point(887, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(887, 3)
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
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(377, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(116, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "VOTRE PANIER"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(886, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2088, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaPictureBoxLogo
        '
        Me.GunaPictureBoxLogo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GunaPictureBoxLogo.BaseColor = System.Drawing.Color.LightGray
        Me.GunaPictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GunaPictureBoxLogo.Location = New System.Drawing.Point(11, 3)
        Me.GunaPictureBoxLogo.Name = "GunaPictureBoxLogo"
        Me.GunaPictureBoxLogo.Size = New System.Drawing.Size(165, 166)
        Me.GunaPictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GunaPictureBoxLogo.TabIndex = 183
        Me.GunaPictureBoxLogo.TabStop = False
        '
        'GunaNumericQte
        '
        Me.GunaNumericQte.BackColor = System.Drawing.Color.Transparent
        Me.GunaNumericQte.BaseColor = System.Drawing.Color.White
        Me.GunaNumericQte.BorderColor = System.Drawing.Color.Silver
        Me.GunaNumericQte.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaNumericQte.ButtonForeColor = System.Drawing.Color.White
        Me.GunaNumericQte.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GunaNumericQte.ForeColor = System.Drawing.Color.Black
        Me.GunaNumericQte.Location = New System.Drawing.Point(101, 176)
        Me.GunaNumericQte.Maximum = CType(500, Long)
        Me.GunaNumericQte.Minimum = CType(1, Long)
        Me.GunaNumericQte.Name = "GunaNumericQte"
        Me.GunaNumericQte.Radius = 5
        Me.GunaNumericQte.Size = New System.Drawing.Size(75, 30)
        Me.GunaNumericQte.TabIndex = 185
        Me.GunaNumericQte.Text = "GunaNumeric1"
        Me.GunaNumericQte.Value = CType(1, Long)
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabel2.Location = New System.Drawing.Point(14, 182)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(74, 19)
        Me.GunaLabel2.TabIndex = 186
        Me.GunaLabel2.Text = "Quantité :"
        '
        'GunaDataGridViewLigneFacture
        '
        Me.GunaDataGridViewLigneFacture.AllowUserToAddRows = False
        Me.GunaDataGridViewLigneFacture.AllowUserToDeleteRows = False
        Me.GunaDataGridViewLigneFacture.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewLigneFacture.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewLigneFacture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewLigneFacture.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GunaDataGridViewLigneFacture.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewLigneFacture.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewLigneFacture.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewLigneFacture.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewLigneFacture.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewLigneFacture.ColumnHeadersHeight = 25
        Me.GunaDataGridViewLigneFacture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewLigneFacture.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewLigneFacture.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewLigneFacture.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewLigneFacture.Location = New System.Drawing.Point(216, 31)
        Me.GunaDataGridViewLigneFacture.Name = "GunaDataGridViewLigneFacture"
        Me.GunaDataGridViewLigneFacture.ReadOnly = True
        Me.GunaDataGridViewLigneFacture.RowHeadersVisible = False
        Me.GunaDataGridViewLigneFacture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewLigneFacture.Size = New System.Drawing.Size(695, 309)
        Me.GunaDataGridViewLigneFacture.TabIndex = 187
        Me.GunaDataGridViewLigneFacture.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewLigneFacture.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewLigneFacture.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewLigneFacture.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewLigneFacture.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewLigneFacture.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewLigneFacture.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewLigneFacture.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewLigneFacture.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewLigneFacture.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewLigneFacture.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewLigneFacture.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewLigneFacture.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewLigneFacture.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewLigneFacture.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewLigneFacture.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewLigneFacture.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewLigneFacture.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewLigneFacture.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewLigneFacture.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewLigneFacture.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewLigneFacture.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton2.ForeColor = System.Drawing.Color.White
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(801, 346)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 4
        Me.GunaButton2.Size = New System.Drawing.Size(102, 30)
        Me.GunaButton2.TabIndex = 188
        Me.GunaButton2.Text = "Commander"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabel3.Location = New System.Drawing.Point(14, 251)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(36, 19)
        Me.GunaLabel3.TabIndex = 186
        Me.GunaLabel3.Text = "PU :"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabel4.Location = New System.Drawing.Point(14, 281)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(58, 19)
        Me.GunaLabel4.TabIndex = 186
        Me.GunaLabel4.Text = "TOTAL :"
        '
        'GunaLabelPu
        '
        Me.GunaLabelPu.AutoSize = True
        Me.GunaLabelPu.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabelPu.Location = New System.Drawing.Point(118, 251)
        Me.GunaLabelPu.Name = "GunaLabelPu"
        Me.GunaLabelPu.Size = New System.Drawing.Size(58, 19)
        Me.GunaLabelPu.TabIndex = 186
        Me.GunaLabelPu.Text = "TOTAL :"
        '
        'GunaLabelPrixTotal
        '
        Me.GunaLabelPrixTotal.AutoSize = True
        Me.GunaLabelPrixTotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabelPrixTotal.Location = New System.Drawing.Point(118, 281)
        Me.GunaLabelPrixTotal.Name = "GunaLabelPrixTotal"
        Me.GunaLabelPrixTotal.Size = New System.Drawing.Size(58, 19)
        Me.GunaLabelPrixTotal.TabIndex = 186
        Me.GunaLabelPrixTotal.Text = "TOTAL :"
        '
        'GunaTextBoxCodeArticle
        '
        Me.GunaTextBoxCodeArticle.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeArticle.BaseColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxCodeArticle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeArticle.BorderSize = 1
        Me.GunaTextBoxCodeArticle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeArticle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeArticle.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeArticle.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeArticle.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeArticle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeArticle.Location = New System.Drawing.Point(208, 346)
        Me.GunaTextBoxCodeArticle.Name = "GunaTextBoxCodeArticle"
        Me.GunaTextBoxCodeArticle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeArticle.Radius = 4
        Me.GunaTextBoxCodeArticle.SelectedText = ""
        Me.GunaTextBoxCodeArticle.Size = New System.Drawing.Size(98, 28)
        Me.GunaTextBoxCodeArticle.TabIndex = 189
        Me.GunaTextBoxCodeArticle.Visible = False
        '
        'GunaButtonAjouterAuPanier
        '
        Me.GunaButtonAjouterAuPanier.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAjouterAuPanier.AnimationSpeed = 0.03!
        Me.GunaButtonAjouterAuPanier.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAjouterAuPanier.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAjouterAuPanier.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterAuPanier.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAjouterAuPanier.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAjouterAuPanier.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAjouterAuPanier.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouterAuPanier.Image = Nothing
        Me.GunaButtonAjouterAuPanier.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAjouterAuPanier.Location = New System.Drawing.Point(11, 318)
        Me.GunaButtonAjouterAuPanier.Name = "GunaButtonAjouterAuPanier"
        Me.GunaButtonAjouterAuPanier.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAjouterAuPanier.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterAuPanier.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouterAuPanier.OnHoverImage = Nothing
        Me.GunaButtonAjouterAuPanier.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterAuPanier.Radius = 4
        Me.GunaButtonAjouterAuPanier.Size = New System.Drawing.Size(165, 30)
        Me.GunaButtonAjouterAuPanier.TabIndex = 188
        Me.GunaButtonAjouterAuPanier.Text = "Ajouter au Panier"
        Me.GunaButtonAjouterAuPanier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 382)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(923, 10)
        Me.GunaPanel2.TabIndex = 190
        '
        'GunaComboBoxUniteOuConso
        '
        Me.GunaComboBoxUniteOuConso.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxUniteOuConso.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxUniteOuConso.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxUniteOuConso.BorderSize = 1
        Me.GunaComboBoxUniteOuConso.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxUniteOuConso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxUniteOuConso.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxUniteOuConso.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxUniteOuConso.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxUniteOuConso.FormattingEnabled = True
        Me.GunaComboBoxUniteOuConso.ItemHeight = 20
        Me.GunaComboBoxUniteOuConso.Location = New System.Drawing.Point(11, 216)
        Me.GunaComboBoxUniteOuConso.Name = "GunaComboBoxUniteOuConso"
        Me.GunaComboBoxUniteOuConso.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxUniteOuConso.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxUniteOuConso.Radius = 5
        Me.GunaComboBoxUniteOuConso.Size = New System.Drawing.Size(165, 26)
        Me.GunaComboBoxUniteOuConso.TabIndex = 321
        '
        'GunaPanelCommande
        '
        Me.GunaPanelCommande.Controls.Add(Me.GunaPictureBoxLogo)
        Me.GunaPanelCommande.Controls.Add(Me.GunaComboBoxUniteOuConso)
        Me.GunaPanelCommande.Controls.Add(Me.GunaNumericQte)
        Me.GunaPanelCommande.Controls.Add(Me.GunaLabel2)
        Me.GunaPanelCommande.Controls.Add(Me.GunaLabel3)
        Me.GunaPanelCommande.Controls.Add(Me.GunaButtonAjouterAuPanier)
        Me.GunaPanelCommande.Controls.Add(Me.GunaLabel4)
        Me.GunaPanelCommande.Controls.Add(Me.GunaLabelPrixTotal)
        Me.GunaPanelCommande.Controls.Add(Me.GunaLabelPu)
        Me.GunaPanelCommande.Location = New System.Drawing.Point(8, 30)
        Me.GunaPanelCommande.Name = "GunaPanelCommande"
        Me.GunaPanelCommande.Size = New System.Drawing.Size(194, 349)
        Me.GunaPanelCommande.TabIndex = 322
        '
        'GunaTextBoxCodeFacture
        '
        Me.GunaTextBoxCodeFacture.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeFacture.BaseColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxCodeFacture.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeFacture.BorderSize = 1
        Me.GunaTextBoxCodeFacture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeFacture.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeFacture.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeFacture.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeFacture.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeFacture.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeFacture.Location = New System.Drawing.Point(324, 346)
        Me.GunaTextBoxCodeFacture.Name = "GunaTextBoxCodeFacture"
        Me.GunaTextBoxCodeFacture.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeFacture.Radius = 4
        Me.GunaTextBoxCodeFacture.SelectedText = ""
        Me.GunaTextBoxCodeFacture.Size = New System.Drawing.Size(100, 28)
        Me.GunaTextBoxCodeFacture.TabIndex = 189
        Me.GunaTextBoxCodeFacture.Visible = False
        '
        'GunaTextBoxNumeroBlocNote
        '
        Me.GunaTextBoxNumeroBlocNote.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumeroBlocNote.BaseColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxNumeroBlocNote.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNumeroBlocNote.BorderSize = 1
        Me.GunaTextBoxNumeroBlocNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNumeroBlocNote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNumeroBlocNote.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumeroBlocNote.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNumeroBlocNote.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNumeroBlocNote.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNumeroBlocNote.Location = New System.Drawing.Point(441, 346)
        Me.GunaTextBoxNumeroBlocNote.Name = "GunaTextBoxNumeroBlocNote"
        Me.GunaTextBoxNumeroBlocNote.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNumeroBlocNote.Radius = 4
        Me.GunaTextBoxNumeroBlocNote.SelectedText = ""
        Me.GunaTextBoxNumeroBlocNote.Size = New System.Drawing.Size(100, 28)
        Me.GunaTextBoxNumeroBlocNote.TabIndex = 189
        Me.GunaTextBoxNumeroBlocNote.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'PanierForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 392)
        Me.Controls.Add(Me.GunaPanelCommande)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaTextBoxNumeroBlocNote)
        Me.Controls.Add(Me.GunaTextBoxCodeFacture)
        Me.Controls.Add(Me.GunaTextBoxCodeArticle)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaDataGridViewLigneFacture)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PanierForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PanierForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.GunaPictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridViewLigneFacture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPanelCommande.ResumeLayout(False)
        Me.GunaPanelCommande.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPictureBoxLogo As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents GunaNumericQte As Guna.UI.WinForms.GunaNumeric
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDataGridViewLigneFacture As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelPu As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelPrixTotal As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxCodeArticle As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonAjouterAuPanier As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaComboBoxUniteOuConso As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaPanelCommande As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxCodeFacture As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNumeroBlocNote As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
