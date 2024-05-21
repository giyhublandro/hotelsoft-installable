<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestionDesDepensesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionDesDepensesForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButtonFermer = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaDataGridViewCategorie = New Guna.UI.WinForms.GunaDataGridView()
        Me.COMPTE = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonAjouter = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxRefCompte = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxiNTITUTLE = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaDataGridViewPlanComptable = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.GunaDataGridViewCategorie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridViewPlanComptable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButtonFermer)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel3)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1119, 25)
        Me.GunaPanel1.TabIndex = 3
        '
        'GunaImageButtonFermer
        '
        Me.GunaImageButtonFermer.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonFermer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonFermer.Image = CType(resources.GetObject("GunaImageButtonFermer.Image"), System.Drawing.Image)
        Me.GunaImageButtonFermer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButtonFermer.Location = New System.Drawing.Point(1086, 2)
        Me.GunaImageButtonFermer.Name = "GunaImageButtonFermer"
        Me.GunaImageButtonFermer.OnHoverImage = Nothing
        Me.GunaImageButtonFermer.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButtonFermer.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButtonFermer.TabIndex = 87
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
        'GunaLabel1
        '
        Me.GunaLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.ForeColor = System.Drawing.Color.White
        Me.GunaLabel1.Location = New System.Drawing.Point(2286, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.White
        Me.GunaLabel3.Location = New System.Drawing.Point(326, 2)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(252, 21)
        Me.GunaLabel3.TabIndex = 90
        Me.GunaLabel3.Text = "CATEGORISATION DES DEPENSES"
        Me.GunaLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaButtonEnregistrer
        '
        Me.GunaButtonEnregistrer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEnregistrer.AnimationSpeed = 0.03!
        Me.GunaButtonEnregistrer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEnregistrer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEnregistrer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEnregistrer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEnregistrer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.Image = Nothing
        Me.GunaButtonEnregistrer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(1006, 49)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(101, 28)
        Me.GunaButtonEnregistrer.TabIndex = 136
        Me.GunaButtonEnregistrer.Text = "Enregistrer"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.Indigo
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 437)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1119, 13)
        Me.GunaPanel2.TabIndex = 137
        '
        'GunaDataGridViewCategorie
        '
        Me.GunaDataGridViewCategorie.AllowUserToAddRows = False
        Me.GunaDataGridViewCategorie.AllowUserToOrderColumns = True
        Me.GunaDataGridViewCategorie.AllowUserToResizeColumns = False
        Me.GunaDataGridViewCategorie.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewCategorie.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewCategorie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewCategorie.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewCategorie.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewCategorie.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewCategorie.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewCategorie.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewCategorie.ColumnHeadersHeight = 25
        Me.GunaDataGridViewCategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewCategorie.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewCategorie.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewCategorie.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCategorie.Location = New System.Drawing.Point(18, 82)
        Me.GunaDataGridViewCategorie.Name = "GunaDataGridViewCategorie"
        Me.GunaDataGridViewCategorie.RowHeadersVisible = False
        Me.GunaDataGridViewCategorie.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewCategorie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewCategorie.Size = New System.Drawing.Size(1095, 349)
        Me.GunaDataGridViewCategorie.TabIndex = 138
        Me.GunaDataGridViewCategorie.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewCategorie.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewCategorie.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewCategorie.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewCategorie.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewCategorie.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewCategorie.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewCategorie.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCategorie.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCategorie.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewCategorie.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewCategorie.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewCategorie.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewCategorie.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewCategorie.ThemeStyle.ReadOnly = False
        Me.GunaDataGridViewCategorie.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewCategorie.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewCategorie.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewCategorie.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewCategorie.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewCategorie.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCategorie.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'COMPTE
        '
        Me.COMPTE.AutoSize = True
        Me.COMPTE.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.COMPTE.Location = New System.Drawing.Point(65, 26)
        Me.COMPTE.Name = "COMPTE"
        Me.COMPTE.Size = New System.Drawing.Size(71, 21)
        Me.COMPTE.TabIndex = 140
        Me.COMPTE.Text = "COMPTE"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaLabel4.Location = New System.Drawing.Point(296, 26)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(73, 21)
        Me.GunaLabel4.TabIndex = 140
        Me.GunaLabel4.Text = "INTITULE"
        '
        'GunaButtonAjouter
        '
        Me.GunaButtonAjouter.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAjouter.AnimationSpeed = 0.03!
        Me.GunaButtonAjouter.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAjouter.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAjouter.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouter.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAjouter.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAjouter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAjouter.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouter.Image = Nothing
        Me.GunaButtonAjouter.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAjouter.Location = New System.Drawing.Point(772, 50)
        Me.GunaButtonAjouter.Name = "GunaButtonAjouter"
        Me.GunaButtonAjouter.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAjouter.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouter.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouter.OnHoverImage = Nothing
        Me.GunaButtonAjouter.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAjouter.Radius = 4
        Me.GunaButtonAjouter.Size = New System.Drawing.Size(101, 26)
        Me.GunaButtonAjouter.TabIndex = 136
        Me.GunaButtonAjouter.Text = "Ajouter"
        Me.GunaButtonAjouter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxRefCompte
        '
        Me.GunaTextBoxRefCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxRefCompte.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRefCompte.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxRefCompte.BorderSize = 1
        Me.GunaTextBoxRefCompte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxRefCompte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxRefCompte.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRefCompte.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxRefCompte.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxRefCompte.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxRefCompte.Location = New System.Drawing.Point(18, 48)
        Me.GunaTextBoxRefCompte.Name = "GunaTextBoxRefCompte"
        Me.GunaTextBoxRefCompte.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxRefCompte.Radius = 5
        Me.GunaTextBoxRefCompte.SelectedText = ""
        Me.GunaTextBoxRefCompte.Size = New System.Drawing.Size(160, 30)
        Me.GunaTextBoxRefCompte.TabIndex = 141
        '
        'GunaTextBoxiNTITUTLE
        '
        Me.GunaTextBoxiNTITUTLE.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxiNTITUTLE.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxiNTITUTLE.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxiNTITUTLE.BorderSize = 1
        Me.GunaTextBoxiNTITUTLE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxiNTITUTLE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxiNTITUTLE.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxiNTITUTLE.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxiNTITUTLE.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxiNTITUTLE.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxiNTITUTLE.Location = New System.Drawing.Point(216, 48)
        Me.GunaTextBoxiNTITUTLE.Name = "GunaTextBoxiNTITUTLE"
        Me.GunaTextBoxiNTITUTLE.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxiNTITUTLE.Radius = 5
        Me.GunaTextBoxiNTITUTLE.SelectedText = ""
        Me.GunaTextBoxiNTITUTLE.Size = New System.Drawing.Size(541, 30)
        Me.GunaTextBoxiNTITUTLE.TabIndex = 141
        '
        'GunaDataGridViewPlanComptable
        '
        Me.GunaDataGridViewPlanComptable.AllowUserToAddRows = False
        Me.GunaDataGridViewPlanComptable.AllowUserToDeleteRows = False
        Me.GunaDataGridViewPlanComptable.AllowUserToOrderColumns = True
        Me.GunaDataGridViewPlanComptable.AllowUserToResizeColumns = False
        Me.GunaDataGridViewPlanComptable.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewPlanComptable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GunaDataGridViewPlanComptable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GunaDataGridViewPlanComptable.BackgroundColor = System.Drawing.Color.White
        Me.GunaDataGridViewPlanComptable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewPlanComptable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewPlanComptable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewPlanComptable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.GunaDataGridViewPlanComptable.ColumnHeadersHeight = 4
        Me.GunaDataGridViewPlanComptable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewPlanComptable.ColumnHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewPlanComptable.DefaultCellStyle = DataGridViewCellStyle6
        Me.GunaDataGridViewPlanComptable.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewPlanComptable.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewPlanComptable.Location = New System.Drawing.Point(18, 82)
        Me.GunaDataGridViewPlanComptable.MultiSelect = False
        Me.GunaDataGridViewPlanComptable.Name = "GunaDataGridViewPlanComptable"
        Me.GunaDataGridViewPlanComptable.ReadOnly = True
        Me.GunaDataGridViewPlanComptable.RowHeadersVisible = False
        Me.GunaDataGridViewPlanComptable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewPlanComptable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewPlanComptable.Size = New System.Drawing.Size(526, 238)
        Me.GunaDataGridViewPlanComptable.TabIndex = 142
        Me.GunaDataGridViewPlanComptable.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewPlanComptable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewPlanComptable.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewPlanComptable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewPlanComptable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewPlanComptable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewPlanComptable.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewPlanComptable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewPlanComptable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewPlanComptable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewPlanComptable.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewPlanComptable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewPlanComptable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewPlanComptable.ThemeStyle.HeaderStyle.Height = 4
        Me.GunaDataGridViewPlanComptable.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewPlanComptable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewPlanComptable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewPlanComptable.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewPlanComptable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewPlanComptable.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewPlanComptable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewPlanComptable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewPlanComptable.Visible = False
        '
        'GestionDesDepensesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 450)
        Me.Controls.Add(Me.GunaDataGridViewPlanComptable)
        Me.Controls.Add(Me.GunaTextBoxiNTITUTLE)
        Me.Controls.Add(Me.GunaTextBoxRefCompte)
        Me.Controls.Add(Me.GunaLabel4)
        Me.Controls.Add(Me.COMPTE)
        Me.Controls.Add(Me.GunaDataGridViewCategorie)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaButtonAjouter)
        Me.Controls.Add(Me.GunaButtonEnregistrer)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GestionDesDepensesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GestionDesDepensesForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.GunaDataGridViewCategorie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridViewPlanComptable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButtonFermer As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaDataGridViewCategorie As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents COMPTE As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonAjouter As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxRefCompte As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxiNTITUTLE As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewPlanComptable As Guna.UI.WinForms.GunaDataGridView
End Class
