<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExchangeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExchangeForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLabeTop = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelDateDeTravail = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButtonFermer = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanelBottom = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxArticle = New Guna.UI.WinForms.GunaTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GunaDataGridViewArticle = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaButtonExchange = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxNumBlocNote = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxIdLigne = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeArticle = New Guna.UI.WinForms.GunaTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GunaTextBoxQuantite = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxMontantHT = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxMontantTTC = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxSousFamilleArticle = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxPointDeVente = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxPUItem = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaComboBoxUniteChangement = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxRepArticle = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxOriginalQty = New Guna.UI.WinForms.GunaTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GunaTextBoxUp = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxOldMontant = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabeTop.SuspendLayout()
        CType(Me.GunaDataGridViewArticle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaLabeTop
        '
        Me.GunaLabeTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLabeTop.Controls.Add(Me.GunaLabel3)
        Me.GunaLabeTop.Controls.Add(Me.GunaLabelDateDeTravail)
        Me.GunaLabeTop.Controls.Add(Me.GunaImageButtonFermer)
        Me.GunaLabeTop.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaLabeTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLabeTop.Controls.Add(Me.GunaLabel1)
        Me.GunaLabeTop.Controls.Add(Me.GunaLabel2)
        Me.GunaLabeTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLabeTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLabeTop.Name = "GunaLabeTop"
        Me.GunaLabeTop.Size = New System.Drawing.Size(500, 25)
        Me.GunaLabeTop.TabIndex = 3
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.White
        Me.GunaLabel3.Location = New System.Drawing.Point(207, 5)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(68, 17)
        Me.GunaLabel3.TabIndex = 4
        Me.GunaLabel3.Text = "ECHANGE"
        '
        'GunaLabelDateDeTravail
        '
        Me.GunaLabelDateDeTravail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLabelDateDeTravail.AutoSize = True
        Me.GunaLabelDateDeTravail.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabelDateDeTravail.ForeColor = System.Drawing.Color.White
        Me.GunaLabelDateDeTravail.Location = New System.Drawing.Point(1116, 3)
        Me.GunaLabelDateDeTravail.Name = "GunaLabelDateDeTravail"
        Me.GunaLabelDateDeTravail.Size = New System.Drawing.Size(118, 19)
        Me.GunaLabelDateDeTravail.TabIndex = 189
        Me.GunaLabelDateDeTravail.Text = "Date de Travail: "
        '
        'GunaImageButtonFermer
        '
        Me.GunaImageButtonFermer.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonFermer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonFermer.Image = CType(resources.GetObject("GunaImageButtonFermer.Image"), System.Drawing.Image)
        Me.GunaImageButtonFermer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButtonFermer.Location = New System.Drawing.Point(467, 2)
        Me.GunaImageButtonFermer.Name = "GunaImageButtonFermer"
        Me.GunaImageButtonFermer.OnHoverImage = Nothing
        Me.GunaImageButtonFermer.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButtonFermer.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButtonFermer.TabIndex = 87
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(568, 0)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(152, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "CAISSE PRINCIPALE"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.GunaLabelGestCompteGeneraux.Visible = False
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(465, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(1667, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.ForeColor = System.Drawing.Color.White
        Me.GunaLabel2.Location = New System.Drawing.Point(825, 2)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(95, 21)
        Me.GunaLabel2.TabIndex = 90
        Me.GunaLabel2.Text = "DEMANDES"
        Me.GunaLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.GunaLabel2.Visible = False
        '
        'GunaPanelBottom
        '
        Me.GunaPanelBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanelBottom.Location = New System.Drawing.Point(0, 160)
        Me.GunaPanelBottom.Name = "GunaPanelBottom"
        Me.GunaPanelBottom.Size = New System.Drawing.Size(500, 10)
        Me.GunaPanelBottom.TabIndex = 4
        '
        'GunaTextBoxArticle
        '
        Me.GunaTextBoxArticle.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxArticle.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxArticle.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxArticle.BorderSize = 1
        Me.GunaTextBoxArticle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxArticle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxArticle.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxArticle.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxArticle.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxArticle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxArticle.Location = New System.Drawing.Point(66, 36)
        Me.GunaTextBoxArticle.Name = "GunaTextBoxArticle"
        Me.GunaTextBoxArticle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxArticle.Radius = 5
        Me.GunaTextBoxArticle.SelectedText = ""
        Me.GunaTextBoxArticle.Size = New System.Drawing.Size(264, 28)
        Me.GunaTextBoxArticle.TabIndex = 318
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 16)
        Me.Label10.TabIndex = 319
        Me.Label10.Text = "Article"
        '
        'GunaDataGridViewArticle
        '
        Me.GunaDataGridViewArticle.AllowUserToAddRows = False
        Me.GunaDataGridViewArticle.AllowUserToDeleteRows = False
        Me.GunaDataGridViewArticle.AllowUserToOrderColumns = True
        Me.GunaDataGridViewArticle.AllowUserToResizeColumns = False
        Me.GunaDataGridViewArticle.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewArticle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewArticle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewArticle.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewArticle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewArticle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewArticle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewArticle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewArticle.ColumnHeadersHeight = 4
        Me.GunaDataGridViewArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewArticle.ColumnHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewArticle.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewArticle.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewArticle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewArticle.Location = New System.Drawing.Point(66, 67)
        Me.GunaDataGridViewArticle.MultiSelect = False
        Me.GunaDataGridViewArticle.Name = "GunaDataGridViewArticle"
        Me.GunaDataGridViewArticle.ReadOnly = True
        Me.GunaDataGridViewArticle.RowHeadersVisible = False
        Me.GunaDataGridViewArticle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewArticle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewArticle.Size = New System.Drawing.Size(274, 98)
        Me.GunaDataGridViewArticle.TabIndex = 320
        Me.GunaDataGridViewArticle.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewArticle.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewArticle.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewArticle.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewArticle.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewArticle.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewArticle.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewArticle.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewArticle.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewArticle.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewArticle.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewArticle.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewArticle.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewArticle.ThemeStyle.HeaderStyle.Height = 4
        Me.GunaDataGridViewArticle.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewArticle.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewArticle.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewArticle.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewArticle.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewArticle.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewArticle.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewArticle.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewArticle.Visible = False
        '
        'GunaButtonExchange
        '
        Me.GunaButtonExchange.AnimationHoverSpeed = 0.07!
        Me.GunaButtonExchange.AnimationSpeed = 0.03!
        Me.GunaButtonExchange.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonExchange.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonExchange.BorderColor = System.Drawing.Color.Transparent
        Me.GunaButtonExchange.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonExchange.Enabled = False
        Me.GunaButtonExchange.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonExchange.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonExchange.ForeColor = System.Drawing.Color.White
        Me.GunaButtonExchange.Image = Nothing
        Me.GunaButtonExchange.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonExchange.Location = New System.Drawing.Point(379, 113)
        Me.GunaButtonExchange.Name = "GunaButtonExchange"
        Me.GunaButtonExchange.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonExchange.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonExchange.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonExchange.OnHoverImage = Nothing
        Me.GunaButtonExchange.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonExchange.Radius = 5
        Me.GunaButtonExchange.Size = New System.Drawing.Size(115, 29)
        Me.GunaButtonExchange.TabIndex = 337
        Me.GunaButtonExchange.Text = "Echange"
        Me.GunaButtonExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxNumBlocNote
        '
        Me.GunaTextBoxNumBlocNote.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumBlocNote.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxNumBlocNote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNumBlocNote.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumBlocNote.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNumBlocNote.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNumBlocNote.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxNumBlocNote.Location = New System.Drawing.Point(387, 26)
        Me.GunaTextBoxNumBlocNote.Name = "GunaTextBoxNumBlocNote"
        Me.GunaTextBoxNumBlocNote.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNumBlocNote.SelectedText = ""
        Me.GunaTextBoxNumBlocNote.Size = New System.Drawing.Size(109, 30)
        Me.GunaTextBoxNumBlocNote.TabIndex = 338
        Me.GunaTextBoxNumBlocNote.Text = "GunaTextBox1"
        Me.GunaTextBoxNumBlocNote.Visible = False
        '
        'GunaTextBoxIdLigne
        '
        Me.GunaTextBoxIdLigne.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxIdLigne.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxIdLigne.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxIdLigne.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxIdLigne.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxIdLigne.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxIdLigne.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxIdLigne.Location = New System.Drawing.Point(159, 26)
        Me.GunaTextBoxIdLigne.Name = "GunaTextBoxIdLigne"
        Me.GunaTextBoxIdLigne.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxIdLigne.SelectedText = ""
        Me.GunaTextBoxIdLigne.Size = New System.Drawing.Size(109, 30)
        Me.GunaTextBoxIdLigne.TabIndex = 339
        Me.GunaTextBoxIdLigne.Text = "GunaTextBox2"
        Me.GunaTextBoxIdLigne.Visible = False
        '
        'GunaTextBoxCodeArticle
        '
        Me.GunaTextBoxCodeArticle.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeArticle.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxCodeArticle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeArticle.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeArticle.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeArticle.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeArticle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxCodeArticle.Location = New System.Drawing.Point(274, 26)
        Me.GunaTextBoxCodeArticle.Name = "GunaTextBoxCodeArticle"
        Me.GunaTextBoxCodeArticle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeArticle.SelectedText = ""
        Me.GunaTextBoxCodeArticle.Size = New System.Drawing.Size(109, 30)
        Me.GunaTextBoxCodeArticle.TabIndex = 340
        Me.GunaTextBoxCodeArticle.Text = "GunaTextBox3"
        Me.GunaTextBoxCodeArticle.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(345, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 342
        Me.Label11.Text = "Quantité"
        Me.Label11.Visible = False
        '
        'GunaTextBoxQuantite
        '
        Me.GunaTextBoxQuantite.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxQuantite.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxQuantite.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxQuantite.BorderSize = 1
        Me.GunaTextBoxQuantite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxQuantite.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxQuantite.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxQuantite.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxQuantite.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxQuantite.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxQuantite.Location = New System.Drawing.Point(415, 35)
        Me.GunaTextBoxQuantite.Name = "GunaTextBoxQuantite"
        Me.GunaTextBoxQuantite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxQuantite.Radius = 5
        Me.GunaTextBoxQuantite.SelectedText = ""
        Me.GunaTextBoxQuantite.Size = New System.Drawing.Size(79, 28)
        Me.GunaTextBoxQuantite.TabIndex = 341
        Me.GunaTextBoxQuantite.Text = "1"
        Me.GunaTextBoxQuantite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxQuantite.Visible = False
        '
        'GunaTextBoxMontantHT
        '
        Me.GunaTextBoxMontantHT.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantHT.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxMontantHT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantHT.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantHT.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantHT.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantHT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxMontantHT.Location = New System.Drawing.Point(12, 69)
        Me.GunaTextBoxMontantHT.Name = "GunaTextBoxMontantHT"
        Me.GunaTextBoxMontantHT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantHT.SelectedText = ""
        Me.GunaTextBoxMontantHT.Size = New System.Drawing.Size(109, 26)
        Me.GunaTextBoxMontantHT.TabIndex = 339
        Me.GunaTextBoxMontantHT.Visible = False
        '
        'GunaTextBoxMontantTTC
        '
        Me.GunaTextBoxMontantTTC.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantTTC.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxMontantTTC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantTTC.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantTTC.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantTTC.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantTTC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxMontantTTC.Location = New System.Drawing.Point(12, 99)
        Me.GunaTextBoxMontantTTC.Name = "GunaTextBoxMontantTTC"
        Me.GunaTextBoxMontantTTC.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantTTC.SelectedText = ""
        Me.GunaTextBoxMontantTTC.Size = New System.Drawing.Size(109, 26)
        Me.GunaTextBoxMontantTTC.TabIndex = 339
        Me.GunaTextBoxMontantTTC.Visible = False
        '
        'GunaTextBoxSousFamilleArticle
        '
        Me.GunaTextBoxSousFamilleArticle.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxSousFamilleArticle.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxSousFamilleArticle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxSousFamilleArticle.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxSousFamilleArticle.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxSousFamilleArticle.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxSousFamilleArticle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxSousFamilleArticle.Location = New System.Drawing.Point(354, 131)
        Me.GunaTextBoxSousFamilleArticle.Name = "GunaTextBoxSousFamilleArticle"
        Me.GunaTextBoxSousFamilleArticle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxSousFamilleArticle.SelectedText = ""
        Me.GunaTextBoxSousFamilleArticle.Size = New System.Drawing.Size(86, 30)
        Me.GunaTextBoxSousFamilleArticle.TabIndex = 339
        Me.GunaTextBoxSousFamilleArticle.Visible = False
        '
        'GunaTextBoxPointDeVente
        '
        Me.GunaTextBoxPointDeVente.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPointDeVente.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxPointDeVente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPointDeVente.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPointDeVente.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPointDeVente.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPointDeVente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxPointDeVente.Location = New System.Drawing.Point(127, 69)
        Me.GunaTextBoxPointDeVente.Name = "GunaTextBoxPointDeVente"
        Me.GunaTextBoxPointDeVente.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPointDeVente.SelectedText = ""
        Me.GunaTextBoxPointDeVente.Size = New System.Drawing.Size(109, 26)
        Me.GunaTextBoxPointDeVente.TabIndex = 339
        Me.GunaTextBoxPointDeVente.Visible = False
        '
        'GunaTextBoxPUItem
        '
        Me.GunaTextBoxPUItem.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPUItem.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxPUItem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPUItem.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPUItem.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPUItem.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPUItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxPUItem.Location = New System.Drawing.Point(127, 99)
        Me.GunaTextBoxPUItem.Name = "GunaTextBoxPUItem"
        Me.GunaTextBoxPUItem.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPUItem.SelectedText = ""
        Me.GunaTextBoxPUItem.Size = New System.Drawing.Size(109, 26)
        Me.GunaTextBoxPUItem.TabIndex = 339
        Me.GunaTextBoxPUItem.Visible = False
        '
        'GunaComboBoxUniteChangement
        '
        Me.GunaComboBoxUniteChangement.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxUniteChangement.BorderColor = System.Drawing.Color.Silver
        Me.GunaComboBoxUniteChangement.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaComboBoxUniteChangement.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaComboBoxUniteChangement.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxUniteChangement.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaComboBoxUniteChangement.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaComboBoxUniteChangement.Location = New System.Drawing.Point(275, 131)
        Me.GunaComboBoxUniteChangement.Name = "GunaComboBoxUniteChangement"
        Me.GunaComboBoxUniteChangement.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaComboBoxUniteChangement.SelectedText = ""
        Me.GunaComboBoxUniteChangement.Size = New System.Drawing.Size(68, 30)
        Me.GunaComboBoxUniteChangement.TabIndex = 339
        Me.GunaComboBoxUniteChangement.Visible = False
        '
        'GunaTextBoxRepArticle
        '
        Me.GunaTextBoxRepArticle.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRepArticle.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxRepArticle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxRepArticle.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRepArticle.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxRepArticle.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxRepArticle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxRepArticle.Location = New System.Drawing.Point(12, 26)
        Me.GunaTextBoxRepArticle.Name = "GunaTextBoxRepArticle"
        Me.GunaTextBoxRepArticle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxRepArticle.SelectedText = ""
        Me.GunaTextBoxRepArticle.Size = New System.Drawing.Size(109, 30)
        Me.GunaTextBoxRepArticle.TabIndex = 339
        Me.GunaTextBoxRepArticle.Visible = False
        '
        'GunaTextBoxOriginalQty
        '
        Me.GunaTextBoxOriginalQty.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxOriginalQty.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxOriginalQty.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxOriginalQty.BorderSize = 1
        Me.GunaTextBoxOriginalQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxOriginalQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxOriginalQty.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxOriginalQty.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxOriginalQty.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxOriginalQty.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxOriginalQty.Location = New System.Drawing.Point(10, 128)
        Me.GunaTextBoxOriginalQty.Name = "GunaTextBoxOriginalQty"
        Me.GunaTextBoxOriginalQty.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxOriginalQty.Radius = 5
        Me.GunaTextBoxOriginalQty.SelectedText = ""
        Me.GunaTextBoxOriginalQty.Size = New System.Drawing.Size(67, 28)
        Me.GunaTextBoxOriginalQty.TabIndex = 341
        Me.GunaTextBoxOriginalQty.Text = "1"
        Me.GunaTextBoxOriginalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxOriginalQty.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(319, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 342
        Me.Label1.Text = "Prix Unitaire"
        Me.Label1.Visible = False
        '
        'GunaTextBoxUp
        '
        Me.GunaTextBoxUp.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxUp.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxUp.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxUp.BorderSize = 1
        Me.GunaTextBoxUp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxUp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxUp.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxUp.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxUp.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxUp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxUp.Location = New System.Drawing.Point(415, 73)
        Me.GunaTextBoxUp.Name = "GunaTextBoxUp"
        Me.GunaTextBoxUp.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxUp.Radius = 5
        Me.GunaTextBoxUp.SelectedText = ""
        Me.GunaTextBoxUp.Size = New System.Drawing.Size(79, 28)
        Me.GunaTextBoxUp.TabIndex = 341
        Me.GunaTextBoxUp.Text = "1"
        Me.GunaTextBoxUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxUp.Visible = False
        '
        'GunaTextBoxOldMontant
        '
        Me.GunaTextBoxOldMontant.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxOldMontant.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxOldMontant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxOldMontant.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxOldMontant.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxOldMontant.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxOldMontant.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxOldMontant.Location = New System.Drawing.Point(127, 128)
        Me.GunaTextBoxOldMontant.Name = "GunaTextBoxOldMontant"
        Me.GunaTextBoxOldMontant.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxOldMontant.SelectedText = ""
        Me.GunaTextBoxOldMontant.Size = New System.Drawing.Size(109, 26)
        Me.GunaTextBoxOldMontant.TabIndex = 339
        Me.GunaTextBoxOldMontant.Visible = False
        '
        'ExchangeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 170)
        Me.Controls.Add(Me.GunaButtonExchange)
        Me.Controls.Add(Me.GunaTextBoxArticle)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GunaDataGridViewArticle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GunaTextBoxOriginalQty)
        Me.Controls.Add(Me.GunaTextBoxUp)
        Me.Controls.Add(Me.GunaTextBoxQuantite)
        Me.Controls.Add(Me.GunaTextBoxCodeArticle)
        Me.Controls.Add(Me.GunaTextBoxSousFamilleArticle)
        Me.Controls.Add(Me.GunaTextBoxMontantTTC)
        Me.Controls.Add(Me.GunaComboBoxUniteChangement)
        Me.Controls.Add(Me.GunaTextBoxOldMontant)
        Me.Controls.Add(Me.GunaTextBoxPUItem)
        Me.Controls.Add(Me.GunaTextBoxPointDeVente)
        Me.Controls.Add(Me.GunaTextBoxMontantHT)
        Me.Controls.Add(Me.GunaTextBoxRepArticle)
        Me.Controls.Add(Me.GunaTextBoxIdLigne)
        Me.Controls.Add(Me.GunaTextBoxNumBlocNote)
        Me.Controls.Add(Me.GunaPanelBottom)
        Me.Controls.Add(Me.GunaLabeTop)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ExchangeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expenditures"
        Me.TopMost = True
        Me.GunaLabeTop.ResumeLayout(False)
        Me.GunaLabeTop.PerformLayout()
        CType(Me.GunaDataGridViewArticle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaLabeTop As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabelDateDeTravail As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButtonFermer As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanelBottom As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxArticle As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GunaDataGridViewArticle As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaButtonExchange As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxNumBlocNote As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxIdLigne As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeArticle As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GunaTextBoxQuantite As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantHT As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantTTC As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxSousFamilleArticle As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxPointDeVente As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxPUItem As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaComboBoxUniteChangement As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxRepArticle As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxOriginalQty As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GunaTextBoxUp As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxOldMontant As Guna.UI.WinForms.GunaTextBox
End Class
