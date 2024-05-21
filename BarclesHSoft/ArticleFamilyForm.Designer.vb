<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ArticleFamilyForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArticleFamilyForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageDescription = New System.Windows.Forms.TabPage()
        Me.GunaComboBoxCategArticle = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaComboBoxFamilleArticle = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabelFamilleArticle = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelCategorie = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBoxSuiviStock = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBoxDescription = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxLIbelle = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxTauxRemise = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxTauxTVA = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBox10 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel9 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBox9 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBox8 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCompteMArchandises = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxCodeArticle = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel11 = New Guna.UI.WinForms.GunaLabel()
        Me.TabPageListe = New System.Windows.Forms.TabPage()
        Me.GunaDataGridViewFamilleArticle = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaContextMenuStrip1 = New Guna.UI.WinForms.GunaContextMenuStrip()
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GunaButtonAfficher = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageDescription.SuspendLayout()
        Me.TabPageListe.SuspendLayout()
        CType(Me.GunaDataGridViewFamilleArticle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(934, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = CType(resources.GetObject("GunaImageButton3.Image"), System.Drawing.Image)
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(905, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(900, 3)
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
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(281, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(324, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "GESTION DES FAMILLES ET SOUS FAMILLES"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(899, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2101, -2)
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
        Me.GunaButton1.Location = New System.Drawing.Point(133, 595)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 37)
        Me.GunaButton1.TabIndex = 3
        Me.GunaButton1.Text = "Annuler"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(670, 595)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(121, 37)
        Me.GunaButtonEnregistrer.TabIndex = 3
        Me.GunaButtonEnregistrer.Text = "Enregistrer"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageDescription)
        Me.TabControl1.Controls.Add(Me.TabPageListe)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(910, 563)
        Me.TabControl1.TabIndex = 25
        '
        'TabPageDescription
        '
        Me.TabPageDescription.BackColor = System.Drawing.Color.LightCyan
        Me.TabPageDescription.Controls.Add(Me.GunaComboBoxCategArticle)
        Me.TabPageDescription.Controls.Add(Me.GunaComboBoxFamilleArticle)
        Me.TabPageDescription.Controls.Add(Me.GunaLabelFamilleArticle)
        Me.TabPageDescription.Controls.Add(Me.GunaLabelCategorie)
        Me.TabPageDescription.Controls.Add(Me.GunaComboBoxSuiviStock)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxDescription)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel2)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxLIbelle)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel4)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxTauxRemise)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxTauxTVA)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBox10)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel9)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBox9)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel7)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel8)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBox8)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxCompteMArchandises)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel6)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel5)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxCodeArticle)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel11)
        Me.TabPageDescription.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDescription.Name = "TabPageDescription"
        Me.TabPageDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDescription.Size = New System.Drawing.Size(902, 534)
        Me.TabPageDescription.TabIndex = 0
        Me.TabPageDescription.Text = "Description"
        '
        'GunaComboBoxCategArticle
        '
        Me.GunaComboBoxCategArticle.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxCategArticle.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxCategArticle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxCategArticle.BorderSize = 1
        Me.GunaComboBoxCategArticle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxCategArticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxCategArticle.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxCategArticle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxCategArticle.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxCategArticle.FormattingEnabled = True
        Me.GunaComboBoxCategArticle.ItemHeight = 27
        Me.GunaComboBoxCategArticle.Location = New System.Drawing.Point(46, 76)
        Me.GunaComboBoxCategArticle.Name = "GunaComboBoxCategArticle"
        Me.GunaComboBoxCategArticle.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxCategArticle.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxCategArticle.Radius = 5
        Me.GunaComboBoxCategArticle.Size = New System.Drawing.Size(399, 33)
        Me.GunaComboBoxCategArticle.TabIndex = 106
        '
        'GunaComboBoxFamilleArticle
        '
        Me.GunaComboBoxFamilleArticle.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxFamilleArticle.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxFamilleArticle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxFamilleArticle.BorderSize = 1
        Me.GunaComboBoxFamilleArticle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxFamilleArticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxFamilleArticle.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxFamilleArticle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxFamilleArticle.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxFamilleArticle.FormattingEnabled = True
        Me.GunaComboBoxFamilleArticle.ItemHeight = 27
        Me.GunaComboBoxFamilleArticle.Location = New System.Drawing.Point(487, 76)
        Me.GunaComboBoxFamilleArticle.Name = "GunaComboBoxFamilleArticle"
        Me.GunaComboBoxFamilleArticle.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxFamilleArticle.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxFamilleArticle.Radius = 5
        Me.GunaComboBoxFamilleArticle.Size = New System.Drawing.Size(358, 33)
        Me.GunaComboBoxFamilleArticle.TabIndex = 107
        '
        'GunaLabelFamilleArticle
        '
        Me.GunaLabelFamilleArticle.AutoSize = True
        Me.GunaLabelFamilleArticle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelFamilleArticle.Location = New System.Drawing.Point(484, 55)
        Me.GunaLabelFamilleArticle.Name = "GunaLabelFamilleArticle"
        Me.GunaLabelFamilleArticle.Size = New System.Drawing.Size(99, 17)
        Me.GunaLabelFamilleArticle.TabIndex = 102
        Me.GunaLabelFamilleArticle.Text = "Famille d'Article"
        '
        'GunaLabelCategorie
        '
        Me.GunaLabelCategorie.AutoSize = True
        Me.GunaLabelCategorie.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelCategorie.Location = New System.Drawing.Point(43, 55)
        Me.GunaLabelCategorie.Name = "GunaLabelCategorie"
        Me.GunaLabelCategorie.Size = New System.Drawing.Size(116, 17)
        Me.GunaLabelCategorie.TabIndex = 104
        Me.GunaLabelCategorie.Text = "Catégorie d'Article"
        '
        'GunaComboBoxSuiviStock
        '
        Me.GunaComboBoxSuiviStock.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxSuiviStock.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxSuiviStock.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxSuiviStock.BorderSize = 1
        Me.GunaComboBoxSuiviStock.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxSuiviStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxSuiviStock.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxSuiviStock.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxSuiviStock.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxSuiviStock.FormattingEnabled = True
        Me.GunaComboBoxSuiviStock.ItemHeight = 25
        Me.GunaComboBoxSuiviStock.Items.AddRange(New Object() {"Non Suivi", "Suivi simple", "Suivi par lot"})
        Me.GunaComboBoxSuiviStock.Location = New System.Drawing.Point(50, 448)
        Me.GunaComboBoxSuiviStock.Name = "GunaComboBoxSuiviStock"
        Me.GunaComboBoxSuiviStock.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxSuiviStock.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxSuiviStock.Radius = 5
        Me.GunaComboBoxSuiviStock.Size = New System.Drawing.Size(245, 31)
        Me.GunaComboBoxSuiviStock.TabIndex = 57
        Me.GunaComboBoxSuiviStock.Visible = False
        '
        'GunaTextBoxDescription
        '
        Me.GunaTextBoxDescription.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxDescription.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxDescription.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxDescription.BorderSize = 1
        Me.GunaTextBoxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxDescription.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxDescription.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxDescription.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxDescription.Location = New System.Drawing.Point(50, 223)
        Me.GunaTextBoxDescription.Name = "GunaTextBoxDescription"
        Me.GunaTextBoxDescription.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxDescription.Radius = 4
        Me.GunaTextBoxDescription.SelectedText = ""
        Me.GunaTextBoxDescription.Size = New System.Drawing.Size(795, 34)
        Me.GunaTextBoxDescription.TabIndex = 47
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(47, 205)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(74, 17)
        Me.GunaLabel2.TabIndex = 39
        Me.GunaLabel2.Text = "Description"
        '
        'GunaTextBoxLIbelle
        '
        Me.GunaTextBoxLIbelle.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxLIbelle.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxLIbelle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxLIbelle.BorderSize = 1
        Me.GunaTextBoxLIbelle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxLIbelle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxLIbelle.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxLIbelle.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxLIbelle.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxLIbelle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxLIbelle.Location = New System.Drawing.Point(46, 154)
        Me.GunaTextBoxLIbelle.Name = "GunaTextBoxLIbelle"
        Me.GunaTextBoxLIbelle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxLIbelle.Radius = 4
        Me.GunaTextBoxLIbelle.SelectedText = ""
        Me.GunaTextBoxLIbelle.Size = New System.Drawing.Size(492, 34)
        Me.GunaTextBoxLIbelle.TabIndex = 47
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(47, 136)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(45, 17)
        Me.GunaLabel4.TabIndex = 39
        Me.GunaLabel4.Text = "Libellé"
        '
        'GunaTextBoxTauxRemise
        '
        Me.GunaTextBoxTauxRemise.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxTauxRemise.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxTauxRemise.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxTauxRemise.BorderSize = 1
        Me.GunaTextBoxTauxRemise.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxTauxRemise.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxTauxRemise.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxTauxRemise.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxTauxRemise.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxTauxRemise.Location = New System.Drawing.Point(600, 445)
        Me.GunaTextBoxTauxRemise.Name = "GunaTextBoxTauxRemise"
        Me.GunaTextBoxTauxRemise.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxTauxRemise.Radius = 4
        Me.GunaTextBoxTauxRemise.SelectedText = ""
        Me.GunaTextBoxTauxRemise.Size = New System.Drawing.Size(245, 34)
        Me.GunaTextBoxTauxRemise.TabIndex = 49
        Me.GunaTextBoxTauxRemise.Text = "0,00"
        Me.GunaTextBoxTauxRemise.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GunaTextBoxTauxRemise.Visible = False
        '
        'GunaTextBoxTauxTVA
        '
        Me.GunaTextBoxTauxTVA.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxTauxTVA.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxTauxTVA.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxTauxTVA.BorderSize = 1
        Me.GunaTextBoxTauxTVA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxTauxTVA.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxTauxTVA.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxTauxTVA.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxTauxTVA.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxTauxTVA.Location = New System.Drawing.Point(332, 445)
        Me.GunaTextBoxTauxTVA.Name = "GunaTextBoxTauxTVA"
        Me.GunaTextBoxTauxTVA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxTauxTVA.Radius = 4
        Me.GunaTextBoxTauxTVA.SelectedText = ""
        Me.GunaTextBoxTauxTVA.Size = New System.Drawing.Size(245, 34)
        Me.GunaTextBoxTauxTVA.TabIndex = 48
        Me.GunaTextBoxTauxTVA.Text = "0,00"
        Me.GunaTextBoxTauxTVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GunaTextBoxTauxTVA.Visible = False
        '
        'GunaTextBox10
        '
        Me.GunaTextBox10.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox10.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox10.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBox10.BorderSize = 1
        Me.GunaTextBox10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox10.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox10.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox10.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox10.Location = New System.Drawing.Point(310, 385)
        Me.GunaTextBox10.Name = "GunaTextBox10"
        Me.GunaTextBox10.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox10.Radius = 4
        Me.GunaTextBox10.SelectedText = ""
        Me.GunaTextBox10.Size = New System.Drawing.Size(535, 34)
        Me.GunaTextBox10.TabIndex = 50
        Me.GunaTextBox10.Visible = False
        '
        'GunaLabel9
        '
        Me.GunaLabel9.AutoSize = True
        Me.GunaLabel9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel9.Location = New System.Drawing.Point(597, 426)
        Me.GunaLabel9.Name = "GunaLabel9"
        Me.GunaLabel9.Size = New System.Drawing.Size(77, 17)
        Me.GunaLabel9.TabIndex = 42
        Me.GunaLabel9.Text = "Taux remise"
        Me.GunaLabel9.Visible = False
        '
        'GunaTextBox9
        '
        Me.GunaTextBox9.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox9.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox9.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBox9.BorderSize = 1
        Me.GunaTextBox9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox9.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox9.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox9.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox9.Location = New System.Drawing.Point(50, 385)
        Me.GunaTextBox9.Name = "GunaTextBox9"
        Me.GunaTextBox9.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox9.Radius = 4
        Me.GunaTextBox9.SelectedText = ""
        Me.GunaTextBox9.Size = New System.Drawing.Size(245, 34)
        Me.GunaTextBox9.TabIndex = 51
        Me.GunaTextBox9.Visible = False
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel7.Location = New System.Drawing.Point(47, 425)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(86, 17)
        Me.GunaLabel7.TabIndex = 40
        Me.GunaLabel7.Text = "Suivi en stock"
        Me.GunaLabel7.Visible = False
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel8.Location = New System.Drawing.Point(329, 426)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(60, 17)
        Me.GunaLabel8.TabIndex = 41
        Me.GunaLabel8.Text = "Taux TVA"
        Me.GunaLabel8.Visible = False
        '
        'GunaTextBox8
        '
        Me.GunaTextBox8.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox8.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox8.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBox8.BorderSize = 1
        Me.GunaTextBox8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox8.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox8.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox8.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox8.Location = New System.Drawing.Point(310, 329)
        Me.GunaTextBox8.Name = "GunaTextBox8"
        Me.GunaTextBox8.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox8.Radius = 4
        Me.GunaTextBox8.SelectedText = ""
        Me.GunaTextBox8.Size = New System.Drawing.Size(535, 34)
        Me.GunaTextBox8.TabIndex = 52
        Me.GunaTextBox8.Visible = False
        '
        'GunaTextBoxCompteMArchandises
        '
        Me.GunaTextBoxCompteMArchandises.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCompteMArchandises.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCompteMArchandises.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCompteMArchandises.BorderSize = 1
        Me.GunaTextBoxCompteMArchandises.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCompteMArchandises.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCompteMArchandises.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCompteMArchandises.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCompteMArchandises.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxCompteMArchandises.Location = New System.Drawing.Point(50, 329)
        Me.GunaTextBoxCompteMArchandises.Name = "GunaTextBoxCompteMArchandises"
        Me.GunaTextBoxCompteMArchandises.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCompteMArchandises.Radius = 4
        Me.GunaTextBoxCompteMArchandises.SelectedText = ""
        Me.GunaTextBoxCompteMArchandises.Size = New System.Drawing.Size(245, 34)
        Me.GunaTextBoxCompteMArchandises.TabIndex = 53
        Me.GunaTextBoxCompteMArchandises.Visible = False
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.Location = New System.Drawing.Point(47, 365)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(89, 17)
        Me.GunaLabel6.TabIndex = 43
        Me.GunaLabel6.Text = "Compte vente"
        Me.GunaLabel6.Visible = False
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(47, 308)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(132, 17)
        Me.GunaLabel5.TabIndex = 44
        Me.GunaLabel5.Text = "Compte marchandise"
        Me.GunaLabel5.Visible = False
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
        Me.GunaTextBoxCodeArticle.Location = New System.Drawing.Point(557, 154)
        Me.GunaTextBoxCodeArticle.Name = "GunaTextBoxCodeArticle"
        Me.GunaTextBoxCodeArticle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeArticle.Radius = 4
        Me.GunaTextBoxCodeArticle.SelectedText = ""
        Me.GunaTextBoxCodeArticle.Size = New System.Drawing.Size(288, 34)
        Me.GunaTextBoxCodeArticle.TabIndex = 56
        Me.GunaTextBoxCodeArticle.Visible = False
        '
        'GunaLabel11
        '
        Me.GunaLabel11.AutoSize = True
        Me.GunaLabel11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel11.Location = New System.Drawing.Point(554, 134)
        Me.GunaLabel11.Name = "GunaLabel11"
        Me.GunaLabel11.Size = New System.Drawing.Size(39, 17)
        Me.GunaLabel11.TabIndex = 46
        Me.GunaLabel11.Text = "Code"
        Me.GunaLabel11.Visible = False
        '
        'TabPageListe
        '
        Me.TabPageListe.Controls.Add(Me.GunaDataGridViewFamilleArticle)
        Me.TabPageListe.Controls.Add(Me.GunaButtonAfficher)
        Me.TabPageListe.Location = New System.Drawing.Point(4, 25)
        Me.TabPageListe.Name = "TabPageListe"
        Me.TabPageListe.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageListe.Size = New System.Drawing.Size(902, 534)
        Me.TabPageListe.TabIndex = 1
        Me.TabPageListe.Text = "Liste"
        Me.TabPageListe.UseVisualStyleBackColor = True
        '
        'GunaDataGridViewFamilleArticle
        '
        Me.GunaDataGridViewFamilleArticle.AllowUserToAddRows = False
        Me.GunaDataGridViewFamilleArticle.AllowUserToDeleteRows = False
        Me.GunaDataGridViewFamilleArticle.AllowUserToOrderColumns = True
        Me.GunaDataGridViewFamilleArticle.AllowUserToResizeColumns = False
        Me.GunaDataGridViewFamilleArticle.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewFamilleArticle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewFamilleArticle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewFamilleArticle.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewFamilleArticle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewFamilleArticle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewFamilleArticle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewFamilleArticle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewFamilleArticle.ColumnHeadersHeight = 30
        Me.GunaDataGridViewFamilleArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewFamilleArticle.ContextMenuStrip = Me.GunaContextMenuStrip1
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewFamilleArticle.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewFamilleArticle.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewFamilleArticle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewFamilleArticle.Location = New System.Drawing.Point(19, 98)
        Me.GunaDataGridViewFamilleArticle.Name = "GunaDataGridViewFamilleArticle"
        Me.GunaDataGridViewFamilleArticle.ReadOnly = True
        Me.GunaDataGridViewFamilleArticle.RowHeadersVisible = False
        Me.GunaDataGridViewFamilleArticle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewFamilleArticle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewFamilleArticle.Size = New System.Drawing.Size(863, 430)
        Me.GunaDataGridViewFamilleArticle.TabIndex = 1
        Me.GunaDataGridViewFamilleArticle.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.HeaderStyle.Height = 30
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewFamilleArticle.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaContextMenuStrip1
        '
        Me.GunaContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupprimerToolStripMenuItem})
        Me.GunaContextMenuStrip1.Name = "GunaContextMenuStrip1"
        Me.GunaContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaContextMenuStrip1.RenderStyle.ColorTable = Nothing
        Me.GunaContextMenuStrip1.RenderStyle.RoundedEdges = True
        Me.GunaContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White
        Me.GunaContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GunaContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro
        Me.GunaContextMenuStrip1.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault
        Me.GunaContextMenuStrip1.Size = New System.Drawing.Size(181, 48)
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
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
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 641)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(934, 8)
        Me.GunaPanel2.TabIndex = 47
        '
        'ArticleFamilyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 650)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GunaButtonEnregistrer)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ArticleFamilyForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageDescription.ResumeLayout(False)
        Me.TabPageDescription.PerformLayout()
        Me.TabPageListe.ResumeLayout(False)
        CType(Me.GunaDataGridViewFamilleArticle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaContextMenuStrip1.ResumeLayout(False)
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
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageDescription As TabPage
    Friend WithEvents TabPageListe As TabPage
    Friend WithEvents GunaDataGridViewFamilleArticle As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaComboBoxSuiviStock As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxLIbelle As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxTauxRemise As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxTauxTVA As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBox10 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel9 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBox9 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBox8 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCompteMArchandises As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxCodeArticle As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel11 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxDescription As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaContextMenuStrip1 As Guna.UI.WinForms.GunaContextMenuStrip
    Friend WithEvents SupprimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GunaButtonAfficher As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaComboBoxCategArticle As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaComboBoxFamilleArticle As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabelFamilleArticle As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelCategorie As Guna.UI.WinForms.GunaLabel
End Class
