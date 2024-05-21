<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EliteClubForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EliteClubForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton6 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton7 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton8 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel3 = New Guna.UI.WinForms.GunaPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageDescription = New System.Windows.Forms.TabPage()
        Me.GunaGroupBox1 = New Guna.UI.WinForms.GunaGroupBox()
        Me.GunaDataGridView1 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaTextBoxCodeArticle = New Guna.UI.WinForms.GunaTextBox()
        Me.TabPageListe = New System.Windows.Forms.TabPage()
        Me.GunaButtonAfficher = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel1.SuspendLayout()
        Me.GunaPanel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageDescription.SuspendLayout()
        Me.GunaGroupBox1.SuspendLayout()
        CType(Me.GunaDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageListe.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaPanel2)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1164, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Controls.Add(Me.GunaImageButton5)
        Me.GunaPanel2.Controls.Add(Me.GunaImageButton6)
        Me.GunaPanel2.Controls.Add(Me.GunaImageButton7)
        Me.GunaPanel2.Controls.Add(Me.GunaLabel4)
        Me.GunaPanel2.Controls.Add(Me.GunaImageButton8)
        Me.GunaPanel2.Controls.Add(Me.GunaLabel5)
        Me.GunaPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1164, 25)
        Me.GunaPanel2.TabIndex = 9
        '
        'GunaImageButton5
        '
        Me.GunaImageButton5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton5.Image = CType(resources.GetObject("GunaImageButton5.Image"), System.Drawing.Image)
        Me.GunaImageButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton5.Location = New System.Drawing.Point(1134, 2)
        Me.GunaImageButton5.Name = "GunaImageButton5"
        Me.GunaImageButton5.OnHoverImage = Nothing
        Me.GunaImageButton5.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton5.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton5.TabIndex = 8
        '
        'GunaImageButton6
        '
        Me.GunaImageButton6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton6.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton6.Image = Nothing
        Me.GunaImageButton6.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton6.Location = New System.Drawing.Point(1130, 2)
        Me.GunaImageButton6.Name = "GunaImageButton6"
        Me.GunaImageButton6.OnHoverImage = Nothing
        Me.GunaImageButton6.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton6.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton6.TabIndex = 7
        '
        'GunaImageButton7
        '
        Me.GunaImageButton7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton7.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton7.Image = Nothing
        Me.GunaImageButton7.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton7.Location = New System.Drawing.Point(1130, 3)
        Me.GunaImageButton7.Name = "GunaImageButton7"
        Me.GunaImageButton7.OnHoverImage = Nothing
        Me.GunaImageButton7.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton7.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton7.TabIndex = 6
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.ForeColor = System.Drawing.Color.White
        Me.GunaLabel4.Location = New System.Drawing.Point(505, 1)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(91, 21)
        Me.GunaLabel4.TabIndex = 4
        Me.GunaLabel4.Text = "CLUB ELITE"
        Me.GunaLabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton8
        '
        Me.GunaImageButton8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton8.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton8.Image = Nothing
        Me.GunaImageButton8.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton8.Location = New System.Drawing.Point(1129, 2)
        Me.GunaImageButton8.Name = "GunaImageButton8"
        Me.GunaImageButton8.OnHoverImage = Nothing
        Me.GunaImageButton8.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton8.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton8.TabIndex = 2
        '
        'GunaLabel5
        '
        Me.GunaLabel5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.ForeColor = System.Drawing.Color.White
        Me.GunaLabel5.Location = New System.Drawing.Point(2331, -2)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel5.TabIndex = 1
        Me.GunaLabel5.Text = "X"
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(1134, 2)
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
        Me.GunaImageButton3.Location = New System.Drawing.Point(1130, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(1130, 3)
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
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(383, 3)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(127, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "MEMBRES ELITE"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1129, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2331, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaPanel2
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaLabel4
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
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
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(999, 293)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(121, 30)
        Me.GunaButtonEnregistrer.TabIndex = 3
        Me.GunaButtonEnregistrer.Text = "Enregistrer"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel3
        '
        Me.GunaPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel3.Location = New System.Drawing.Point(0, 390)
        Me.GunaPanel3.Name = "GunaPanel3"
        Me.GunaPanel3.Size = New System.Drawing.Size(1164, 10)
        Me.GunaPanel3.TabIndex = 28
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageDescription)
        Me.TabControl1.Controls.Add(Me.TabPageListe)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1145, 358)
        Me.TabControl1.TabIndex = 29
        '
        'TabPageDescription
        '
        Me.TabPageDescription.BackColor = System.Drawing.Color.LightCyan
        Me.TabPageDescription.Controls.Add(Me.GunaGroupBox1)
        Me.TabPageDescription.Controls.Add(Me.GunaButtonEnregistrer)
        Me.TabPageDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageDescription.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDescription.Name = "TabPageDescription"
        Me.TabPageDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDescription.Size = New System.Drawing.Size(1137, 329)
        Me.TabPageDescription.TabIndex = 0
        Me.TabPageDescription.Text = "Configurations"
        '
        'GunaGroupBox1
        '
        Me.GunaGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox1.BaseColor = System.Drawing.Color.White
        Me.GunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox1.Controls.Add(Me.GunaDataGridView1)
        Me.GunaGroupBox1.Controls.Add(Me.GunaTextBoxCodeArticle)
        Me.GunaGroupBox1.LineColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GunaGroupBox1.Name = "GunaGroupBox1"
        Me.GunaGroupBox1.Radius = 10
        Me.GunaGroupBox1.Size = New System.Drawing.Size(1125, 281)
        Me.GunaGroupBox1.TabIndex = 108
        Me.GunaGroupBox1.Text = "TYPE DE MEMBRE : SILVER - GOLD - PLATINUM"
        Me.GunaGroupBox1.TextLocation = New System.Drawing.Point(10, 8)
        '
        'GunaDataGridView1
        '
        Me.GunaDataGridView1.AllowUserToAddRows = False
        Me.GunaDataGridView1.AllowUserToDeleteRows = False
        Me.GunaDataGridView1.AllowUserToResizeColumns = False
        Me.GunaDataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridView1.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.GunaDataGridView1.EnableHeadersVisualStyles = False
        Me.GunaDataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.Location = New System.Drawing.Point(11, 34)
        Me.GunaDataGridView1.Name = "GunaDataGridView1"
        Me.GunaDataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GunaDataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GunaDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GunaDataGridView1.Size = New System.Drawing.Size(1103, 235)
        Me.GunaDataGridView1.TabIndex = 57
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
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.Height = 23
        Me.GunaDataGridView1.ThemeStyle.ReadOnly = False
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaTextBoxCodeArticle
        '
        Me.GunaTextBoxCodeArticle.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeArticle.BaseColor = System.Drawing.Color.Pink
        Me.GunaTextBoxCodeArticle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeArticle.BorderSize = 1
        Me.GunaTextBoxCodeArticle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeArticle.Enabled = False
        Me.GunaTextBoxCodeArticle.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeArticle.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeArticle.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeArticle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxCodeArticle.Location = New System.Drawing.Point(716, 2)
        Me.GunaTextBoxCodeArticle.Name = "GunaTextBoxCodeArticle"
        Me.GunaTextBoxCodeArticle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeArticle.Radius = 4
        Me.GunaTextBoxCodeArticle.SelectedText = ""
        Me.GunaTextBoxCodeArticle.Size = New System.Drawing.Size(158, 26)
        Me.GunaTextBoxCodeArticle.TabIndex = 56
        Me.GunaTextBoxCodeArticle.Visible = False
        '
        'TabPageListe
        '
        Me.TabPageListe.Controls.Add(Me.GunaButtonAfficher)
        Me.TabPageListe.Location = New System.Drawing.Point(4, 25)
        Me.TabPageListe.Name = "TabPageListe"
        Me.TabPageListe.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageListe.Size = New System.Drawing.Size(1137, 275)
        Me.TabPageListe.TabIndex = 1
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
        Me.GunaButtonAfficher.Location = New System.Drawing.Point(799, 27)
        Me.GunaButtonAfficher.Name = "GunaButtonAfficher"
        Me.GunaButtonAfficher.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAfficher.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficher.OnHoverImage = Nothing
        Me.GunaButtonAfficher.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.Radius = 4
        Me.GunaButtonAfficher.Size = New System.Drawing.Size(83, 37)
        Me.GunaButtonAfficher.TabIndex = 3
        Me.GunaButtonAfficher.Text = "Afficher"
        Me.GunaButtonAfficher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EliteClubForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1164, 401)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GunaPanel3)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EliteClubForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.GunaPanel2.ResumeLayout(False)
        Me.GunaPanel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageDescription.ResumeLayout(False)
        Me.GunaGroupBox1.ResumeLayout(False)
        CType(Me.GunaDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageListe.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton6 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton7 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton8 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel3 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageDescription As TabPage
    Friend WithEvents GunaTextBoxCodeArticle As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents TabPageListe As TabPage
    Friend WithEvents GunaButtonAfficher As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaGroupBox1 As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents GunaDataGridView1 As Guna.UI.WinForms.GunaDataGridView
End Class
