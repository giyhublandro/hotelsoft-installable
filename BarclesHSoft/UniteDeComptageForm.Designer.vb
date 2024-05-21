<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UniteDeComptageForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UniteDeComptageForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton6 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunalabelUniteDecComptage = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageDescriptionUnite = New System.Windows.Forms.TabPage()
        Me.GunaComboBoxUnitePour = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBox5 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBox2 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxCodePetiteUnite = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabelCodeUniteDestockage = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBox6 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeGrandeUnite = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBox3 = New Guna.UI.WinForms.GunaTextBox()
        Me.TabPageListeUnite = New System.Windows.Forms.TabPage()
        Me.DataGridViewUniteListe = New Guna.UI.WinForms.GunaDataGridView()
        Me.ContextMenuStripSuppression = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimerToolStripMenuItemSupressionCaisse = New System.Windows.Forms.ToolStripMenuItem()
        Me.GunaPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageDescriptionUnite.SuspendLayout()
        Me.TabPageListeUnite.SuspendLayout()
        CType(Me.DataGridViewUniteListe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripSuppression.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton6)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton5)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunalabelUniteDecComptage)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(934, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaImageButton6
        '
        Me.GunaImageButton6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton6.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton6.Image = CType(resources.GetObject("GunaImageButton6.Image"), System.Drawing.Image)
        Me.GunaImageButton6.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton6.Location = New System.Drawing.Point(898, 2)
        Me.GunaImageButton6.Name = "GunaImageButton6"
        Me.GunaImageButton6.OnHoverImage = Nothing
        Me.GunaImageButton6.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton6.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton6.TabIndex = 10
        '
        'GunaImageButton5
        '
        Me.GunaImageButton5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton5.Image = Nothing
        Me.GunaImageButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton5.Location = New System.Drawing.Point(1229, 3)
        Me.GunaImageButton5.Name = "GunaImageButton5"
        Me.GunaImageButton5.OnHoverImage = Nothing
        Me.GunaImageButton5.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton5.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton5.TabIndex = 9
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = Nothing
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(1236, 2)
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
        Me.GunaImageButton3.Location = New System.Drawing.Point(1234, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(1234, 3)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 6
        '
        'GunalabelUniteDecComptage
        '
        Me.GunalabelUniteDecComptage.AutoSize = True
        Me.GunalabelUniteDecComptage.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunalabelUniteDecComptage.ForeColor = System.Drawing.Color.White
        Me.GunalabelUniteDecComptage.Location = New System.Drawing.Point(296, 3)
        Me.GunalabelUniteDecComptage.Name = "GunalabelUniteDecComptage"
        Me.GunalabelUniteDecComptage.Size = New System.Drawing.Size(341, 21)
        Me.GunalabelUniteDecComptage.TabIndex = 4
        Me.GunalabelUniteDecComptage.Text = "Création et mise à jour des conditionnements"
        Me.GunalabelUniteDecComptage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1233, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2435, -2)
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
        Me.GunaDragControl2.TargetControl = Me.GunalabelUniteDecComptage
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageDescriptionUnite)
        Me.TabControl1.Controls.Add(Me.TabPageListeUnite)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(904, 406)
        Me.TabControl1.TabIndex = 2
        '
        'TabPageDescriptionUnite
        '
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaComboBoxUnitePour)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaTextBox5)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaLabel7)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaLabel6)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaTextBox2)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaLabel5)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaLabel4)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaLabel3)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaTextBoxCodePetiteUnite)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaLabelCodeUniteDestockage)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaTextBox6)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaTextBoxCodeGrandeUnite)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaLabel2)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaButtonEnregistrer)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaButton1)
        Me.TabPageDescriptionUnite.Controls.Add(Me.GunaTextBox3)
        Me.TabPageDescriptionUnite.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDescriptionUnite.Name = "TabPageDescriptionUnite"
        Me.TabPageDescriptionUnite.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDescriptionUnite.Size = New System.Drawing.Size(896, 377)
        Me.TabPageDescriptionUnite.TabIndex = 0
        Me.TabPageDescriptionUnite.Text = "Description Unité de comptage"
        Me.TabPageDescriptionUnite.UseVisualStyleBackColor = True
        '
        'GunaComboBoxUnitePour
        '
        Me.GunaComboBoxUnitePour.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxUnitePour.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxUnitePour.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxUnitePour.BorderSize = 1
        Me.GunaComboBoxUnitePour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxUnitePour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxUnitePour.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxUnitePour.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxUnitePour.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxUnitePour.FormattingEnabled = True
        Me.GunaComboBoxUnitePour.ItemHeight = 25
        Me.GunaComboBoxUnitePour.Location = New System.Drawing.Point(293, 55)
        Me.GunaComboBoxUnitePour.Name = "GunaComboBoxUnitePour"
        Me.GunaComboBoxUnitePour.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxUnitePour.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxUnitePour.Radius = 5
        Me.GunaComboBoxUnitePour.Size = New System.Drawing.Size(170, 31)
        Me.GunaComboBoxUnitePour.TabIndex = 34
        '
        'GunaTextBox5
        '
        Me.GunaTextBox5.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox5.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox5.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBox5.BorderSize = 1
        Me.GunaTextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox5.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox5.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox5.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBox5.Location = New System.Drawing.Point(290, 263)
        Me.GunaTextBox5.Name = "GunaTextBox5"
        Me.GunaTextBox5.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox5.Radius = 4
        Me.GunaTextBox5.SelectedText = ""
        Me.GunaTextBox5.Size = New System.Drawing.Size(127, 34)
        Me.GunaTextBox5.TabIndex = 32
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel7.Location = New System.Drawing.Point(295, 34)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(74, 17)
        Me.GunaLabel7.TabIndex = 30
        Me.GunaLabel7.Text = "Unité pour "
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.Location = New System.Drawing.Point(287, 242)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(130, 17)
        Me.GunaLabel6.TabIndex = 30
        Me.GunaLabel6.Text = "Valeur de conversion"
        '
        'GunaTextBox2
        '
        Me.GunaTextBox2.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox2.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox2.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBox2.BorderSize = 1
        Me.GunaTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox2.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox2.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox2.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBox2.Location = New System.Drawing.Point(290, 198)
        Me.GunaTextBox2.Name = "GunaTextBox2"
        Me.GunaTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox2.Radius = 4
        Me.GunaTextBox2.SelectedText = ""
        Me.GunaTextBox2.Size = New System.Drawing.Size(436, 34)
        Me.GunaTextBox2.TabIndex = 32
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.ForeColor = System.Drawing.Color.DarkRed
        Me.GunaLabel5.Location = New System.Drawing.Point(209, 346)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(504, 17)
        Me.GunaLabel5.TabIndex = 30
        Me.GunaLabel5.Text = "NB : UNITE DE  STOCKAGE = UNITE DE DESTOCKAGE * VALEUR DE CONVERSION"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(290, 112)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(170, 17)
        Me.GunaLabel4.TabIndex = 30
        Me.GunaLabel4.Text = "Libellé Unité de Destockage"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(287, 178)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(153, 17)
        Me.GunaLabel3.TabIndex = 30
        Me.GunaLabel3.Text = "Libellé unité de Stockage"
        '
        'GunaTextBoxCodePetiteUnite
        '
        Me.GunaTextBoxCodePetiteUnite.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodePetiteUnite.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodePetiteUnite.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxCodePetiteUnite.BorderSize = 1
        Me.GunaTextBoxCodePetiteUnite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodePetiteUnite.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodePetiteUnite.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodePetiteUnite.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodePetiteUnite.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodePetiteUnite.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodePetiteUnite.Location = New System.Drawing.Point(120, 134)
        Me.GunaTextBoxCodePetiteUnite.Name = "GunaTextBoxCodePetiteUnite"
        Me.GunaTextBoxCodePetiteUnite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodePetiteUnite.Radius = 4
        Me.GunaTextBoxCodePetiteUnite.SelectedText = ""
        Me.GunaTextBoxCodePetiteUnite.Size = New System.Drawing.Size(117, 34)
        Me.GunaTextBoxCodePetiteUnite.TabIndex = 33
        '
        'GunaLabelCodeUniteDestockage
        '
        Me.GunaLabelCodeUniteDestockage.AutoSize = True
        Me.GunaLabelCodeUniteDestockage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelCodeUniteDestockage.Location = New System.Drawing.Point(112, 114)
        Me.GunaLabelCodeUniteDestockage.Name = "GunaLabelCodeUniteDestockage"
        Me.GunaLabelCodeUniteDestockage.Size = New System.Drawing.Size(164, 17)
        Me.GunaLabelCodeUniteDestockage.TabIndex = 31
        Me.GunaLabelCodeUniteDestockage.Text = "Code Unité de Destockage"
        '
        'GunaTextBox6
        '
        Me.GunaTextBox6.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox6.BaseColor = System.Drawing.Color.Maroon
        Me.GunaTextBox6.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBox6.BorderSize = 1
        Me.GunaTextBox6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox6.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox6.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox6.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox6.Location = New System.Drawing.Point(803, 6)
        Me.GunaTextBox6.Name = "GunaTextBox6"
        Me.GunaTextBox6.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox6.Radius = 4
        Me.GunaTextBox6.SelectedText = ""
        Me.GunaTextBox6.Size = New System.Drawing.Size(44, 34)
        Me.GunaTextBox6.TabIndex = 33
        Me.GunaTextBox6.Visible = False
        '
        'GunaTextBoxCodeGrandeUnite
        '
        Me.GunaTextBoxCodeGrandeUnite.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeGrandeUnite.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeGrandeUnite.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxCodeGrandeUnite.BorderSize = 1
        Me.GunaTextBoxCodeGrandeUnite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeGrandeUnite.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeGrandeUnite.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeGrandeUnite.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeGrandeUnite.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeGrandeUnite.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeGrandeUnite.Location = New System.Drawing.Point(120, 198)
        Me.GunaTextBoxCodeGrandeUnite.Name = "GunaTextBoxCodeGrandeUnite"
        Me.GunaTextBoxCodeGrandeUnite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeGrandeUnite.Radius = 4
        Me.GunaTextBoxCodeGrandeUnite.SelectedText = ""
        Me.GunaTextBoxCodeGrandeUnite.Size = New System.Drawing.Size(117, 34)
        Me.GunaTextBoxCodeGrandeUnite.TabIndex = 33
        Me.GunaTextBoxCodeGrandeUnite.Visible = False
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(114, 179)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(149, 17)
        Me.GunaLabel2.TabIndex = 31
        Me.GunaLabel2.Text = "Code Unité de Stockage"
        Me.GunaLabel2.Visible = False
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
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(769, 334)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(121, 37)
        Me.GunaButtonEnregistrer.TabIndex = 28
        Me.GunaButtonEnregistrer.Text = "Enregistrer"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButton1.Location = New System.Drawing.Point(15, 334)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 37)
        Me.GunaButton1.TabIndex = 29
        Me.GunaButton1.Text = "Fermer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBox3
        '
        Me.GunaTextBox3.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox3.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox3.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBox3.BorderSize = 1
        Me.GunaTextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox3.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox3.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox3.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBox3.Location = New System.Drawing.Point(290, 133)
        Me.GunaTextBox3.Name = "GunaTextBox3"
        Me.GunaTextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox3.Radius = 4
        Me.GunaTextBox3.SelectedText = ""
        Me.GunaTextBox3.Size = New System.Drawing.Size(436, 34)
        Me.GunaTextBox3.TabIndex = 32
        '
        'TabPageListeUnite
        '
        Me.TabPageListeUnite.Controls.Add(Me.DataGridViewUniteListe)
        Me.TabPageListeUnite.Location = New System.Drawing.Point(4, 25)
        Me.TabPageListeUnite.Name = "TabPageListeUnite"
        Me.TabPageListeUnite.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageListeUnite.Size = New System.Drawing.Size(896, 377)
        Me.TabPageListeUnite.TabIndex = 1
        Me.TabPageListeUnite.Text = "Liste des Unité de comptage"
        Me.TabPageListeUnite.UseVisualStyleBackColor = True
        '
        'DataGridViewUniteListe
        '
        Me.DataGridViewUniteListe.AllowUserToAddRows = False
        Me.DataGridViewUniteListe.AllowUserToDeleteRows = False
        Me.DataGridViewUniteListe.AllowUserToOrderColumns = True
        Me.DataGridViewUniteListe.AllowUserToResizeColumns = False
        Me.DataGridViewUniteListe.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DataGridViewUniteListe.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewUniteListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewUniteListe.BackgroundColor = System.Drawing.Color.LightBlue
        Me.DataGridViewUniteListe.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewUniteListe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridViewUniteListe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewUniteListe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewUniteListe.ColumnHeadersHeight = 30
        Me.DataGridViewUniteListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewUniteListe.ContextMenuStrip = Me.ContextMenuStripSuppression
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewUniteListe.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewUniteListe.EnableHeadersVisualStyles = False
        Me.DataGridViewUniteListe.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewUniteListe.Location = New System.Drawing.Point(20, 46)
        Me.DataGridViewUniteListe.Name = "DataGridViewUniteListe"
        Me.DataGridViewUniteListe.ReadOnly = True
        Me.DataGridViewUniteListe.RowHeadersVisible = False
        Me.DataGridViewUniteListe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridViewUniteListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewUniteListe.Size = New System.Drawing.Size(856, 325)
        Me.DataGridViewUniteListe.TabIndex = 108
        Me.DataGridViewUniteListe.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.DataGridViewUniteListe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridViewUniteListe.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DataGridViewUniteListe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DataGridViewUniteListe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DataGridViewUniteListe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DataGridViewUniteListe.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.DataGridViewUniteListe.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewUniteListe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewUniteListe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridViewUniteListe.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewUniteListe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DataGridViewUniteListe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewUniteListe.ThemeStyle.HeaderStyle.Height = 30
        Me.DataGridViewUniteListe.ThemeStyle.ReadOnly = True
        Me.DataGridViewUniteListe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridViewUniteListe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridViewUniteListe.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewUniteListe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DataGridViewUniteListe.ThemeStyle.RowsStyle.Height = 22
        Me.DataGridViewUniteListe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewUniteListe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'ContextMenuStripSuppression
        '
        Me.ContextMenuStripSuppression.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimerToolStripMenuItemSupressionCaisse})
        Me.ContextMenuStripSuppression.Name = "ContextMenuStripSuppression"
        Me.ContextMenuStripSuppression.Size = New System.Drawing.Size(130, 26)
        '
        'ImprimerToolStripMenuItemSupressionCaisse
        '
        Me.ImprimerToolStripMenuItemSupressionCaisse.Name = "ImprimerToolStripMenuItemSupressionCaisse"
        Me.ImprimerToolStripMenuItemSupressionCaisse.Size = New System.Drawing.Size(129, 22)
        Me.ImprimerToolStripMenuItemSupressionCaisse.Text = "Supprimer"
        '
        'UniteDeComptageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UniteDeComptageForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageDescriptionUnite.ResumeLayout(False)
        Me.TabPageDescriptionUnite.PerformLayout()
        Me.TabPageListeUnite.ResumeLayout(False)
        CType(Me.DataGridViewUniteListe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripSuppression.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunalabelUniteDecComptage As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageDescriptionUnite As TabPage
    Friend WithEvents GunaTextBox3 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBox5 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBox2 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxCodeGrandeUnite As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents TabPageListeUnite As TabPage
    Friend WithEvents DataGridViewUniteListe As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaTextBoxCodePetiteUnite As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabelCodeUniteDestockage As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBox6 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaImageButton6 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents ContextMenuStripSuppression As ContextMenuStrip
    Friend WithEvents ImprimerToolStripMenuItemSupressionCaisse As ToolStripMenuItem
    Friend WithEvents GunaComboBoxUnitePour As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
End Class
