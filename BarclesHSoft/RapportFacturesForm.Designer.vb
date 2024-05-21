<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RapportFacturesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RapportFacturesForm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton6 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton7 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGeneral = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.ContextMenuStripImprimerFacture = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GunaComboBoxMagasins = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaCheckBoxTous = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaComboBoxUtilisateurDeMagasinBar = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaDateTimePickerFin = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaDateTimePickerDebut = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel35 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonAfficher = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.DataGridViewRapports = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaCheckBoxParFamille = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaComboBoxParPointDeVente = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaButtonImprimer = New Guna.UI.WinForms.GunaButton()
        Me.GunaCheckBoxPropResa = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaTextBoxCodeResa = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButton16 = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel1.SuspendLayout()
        Me.ContextMenuStripImprimerFacture.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridViewRapports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton6)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton7)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton5)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGeneral)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1200, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaImageButton6
        '
        Me.GunaImageButton6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton6.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton6.Image = CType(resources.GetObject("GunaImageButton6.Image"), System.Drawing.Image)
        Me.GunaImageButton6.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton6.Location = New System.Drawing.Point(1137, 3)
        Me.GunaImageButton6.Name = "GunaImageButton6"
        Me.GunaImageButton6.OnHoverImage = Nothing
        Me.GunaImageButton6.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton6.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton6.TabIndex = 11
        '
        'GunaImageButton7
        '
        Me.GunaImageButton7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton7.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton7.Image = CType(resources.GetObject("GunaImageButton7.Image"), System.Drawing.Image)
        Me.GunaImageButton7.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton7.Location = New System.Drawing.Point(1161, 3)
        Me.GunaImageButton7.Name = "GunaImageButton7"
        Me.GunaImageButton7.OnHoverImage = Nothing
        Me.GunaImageButton7.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton7.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton7.TabIndex = 10
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = Nothing
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
        Me.GunaImageButton5.Image = Nothing
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
        'GunaLabelGeneral
        '
        Me.GunaLabelGeneral.AutoSize = True
        Me.GunaLabelGeneral.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGeneral.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGeneral.Location = New System.Drawing.Point(474, 1)
        Me.GunaLabelGeneral.Name = "GunaLabelGeneral"
        Me.GunaLabelGeneral.Size = New System.Drawing.Size(165, 21)
        Me.GunaLabelGeneral.TabIndex = 4
        Me.GunaLabelGeneral.Text = "ETATS DES FACTURES"
        Me.GunaLabelGeneral.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.GunaDragControl2.TargetControl = Me.GunaLabelGeneral
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'ContextMenuStripImprimerFacture
        '
        Me.ContextMenuStripImprimerFacture.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimerToolStripMenuItem})
        Me.ContextMenuStripImprimerFacture.Name = "ContextMenuStrip1"
        Me.ContextMenuStripImprimerFacture.Size = New System.Drawing.Size(124, 26)
        '
        'ImprimerToolStripMenuItem
        '
        Me.ImprimerToolStripMenuItem.Name = "ImprimerToolStripMenuItem"
        Me.ImprimerToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ImprimerToolStripMenuItem.Text = "Imprimer"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GunaComboBoxMagasins)
        Me.GroupBox4.Controls.Add(Me.GunaCheckBoxTous)
        Me.GroupBox4.Controls.Add(Me.GunaComboBoxUtilisateurDeMagasinBar)
        Me.GroupBox4.Controls.Add(Me.GunaDateTimePickerFin)
        Me.GroupBox4.Controls.Add(Me.GunaDateTimePickerDebut)
        Me.GroupBox4.Controls.Add(Me.GunaLabel4)
        Me.GroupBox4.Controls.Add(Me.GunaLabel2)
        Me.GroupBox4.Controls.Add(Me.GunaLabel3)
        Me.GroupBox4.Controls.Add(Me.GunaLabel35)
        Me.GroupBox4.Controls.Add(Me.GunaButtonAfficher)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(28, 31)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1144, 80)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        '
        'GunaComboBoxMagasins
        '
        Me.GunaComboBoxMagasins.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxMagasins.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxMagasins.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxMagasins.BorderSize = 1
        Me.GunaComboBoxMagasins.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxMagasins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxMagasins.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxMagasins.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxMagasins.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxMagasins.FormattingEnabled = True
        Me.GunaComboBoxMagasins.ItemHeight = 25
        Me.GunaComboBoxMagasins.Location = New System.Drawing.Point(333, 37)
        Me.GunaComboBoxMagasins.Name = "GunaComboBoxMagasins"
        Me.GunaComboBoxMagasins.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxMagasins.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxMagasins.Radius = 5
        Me.GunaComboBoxMagasins.Size = New System.Drawing.Size(342, 31)
        Me.GunaComboBoxMagasins.TabIndex = 42
        Me.GunaComboBoxMagasins.UseWaitCursor = True
        Me.GunaComboBoxMagasins.Visible = False
        '
        'GunaCheckBoxTous
        '
        Me.GunaCheckBoxTous.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxTous.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxTous.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxTous.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxTous.Location = New System.Drawing.Point(260, 43)
        Me.GunaCheckBoxTous.Name = "GunaCheckBoxTous"
        Me.GunaCheckBoxTous.Size = New System.Drawing.Size(55, 20)
        Me.GunaCheckBoxTous.TabIndex = 41
        Me.GunaCheckBoxTous.Text = "Tous"
        '
        'GunaComboBoxUtilisateurDeMagasinBar
        '
        Me.GunaComboBoxUtilisateurDeMagasinBar.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxUtilisateurDeMagasinBar.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxUtilisateurDeMagasinBar.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxUtilisateurDeMagasinBar.BorderSize = 1
        Me.GunaComboBoxUtilisateurDeMagasinBar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxUtilisateurDeMagasinBar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxUtilisateurDeMagasinBar.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxUtilisateurDeMagasinBar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxUtilisateurDeMagasinBar.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxUtilisateurDeMagasinBar.FormattingEnabled = True
        Me.GunaComboBoxUtilisateurDeMagasinBar.ItemHeight = 25
        Me.GunaComboBoxUtilisateurDeMagasinBar.Location = New System.Drawing.Point(22, 38)
        Me.GunaComboBoxUtilisateurDeMagasinBar.Name = "GunaComboBoxUtilisateurDeMagasinBar"
        Me.GunaComboBoxUtilisateurDeMagasinBar.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxUtilisateurDeMagasinBar.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxUtilisateurDeMagasinBar.Radius = 5
        Me.GunaComboBoxUtilisateurDeMagasinBar.Size = New System.Drawing.Size(228, 31)
        Me.GunaComboBoxUtilisateurDeMagasinBar.TabIndex = 40
        Me.GunaComboBoxUtilisateurDeMagasinBar.Visible = False
        '
        'GunaDateTimePickerFin
        '
        Me.GunaDateTimePickerFin.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerFin.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerFin.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaDateTimePickerFin.BorderSize = 1
        Me.GunaDateTimePickerFin.CustomFormat = "yyyy-MM-dd"
        Me.GunaDateTimePickerFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerFin.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDateTimePickerFin.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerFin.Location = New System.Drawing.Point(857, 36)
        Me.GunaDateTimePickerFin.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerFin.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerFin.Name = "GunaDateTimePickerFin"
        Me.GunaDateTimePickerFin.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerFin.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerFin.Radius = 5
        Me.GunaDateTimePickerFin.Size = New System.Drawing.Size(147, 32)
        Me.GunaDateTimePickerFin.TabIndex = 39
        Me.GunaDateTimePickerFin.Text = "06/07/2021"
        Me.GunaDateTimePickerFin.Value = New Date(2021, 7, 6, 12, 28, 28, 662)
        '
        'GunaDateTimePickerDebut
        '
        Me.GunaDateTimePickerDebut.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerDebut.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDebut.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaDateTimePickerDebut.BorderSize = 1
        Me.GunaDateTimePickerDebut.CustomFormat = "yyyy-MM-dd"
        Me.GunaDateTimePickerDebut.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDebut.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDateTimePickerDebut.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerDebut.Location = New System.Drawing.Point(681, 36)
        Me.GunaDateTimePickerDebut.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDebut.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDebut.Name = "GunaDateTimePickerDebut"
        Me.GunaDateTimePickerDebut.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDebut.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDebut.Radius = 5
        Me.GunaDateTimePickerDebut.Size = New System.Drawing.Size(158, 32)
        Me.GunaDateTimePickerDebut.TabIndex = 39
        Me.GunaDateTimePickerDebut.Text = "06/07/2021"
        Me.GunaDateTimePickerDebut.Value = New Date(2021, 7, 6, 12, 28, 28, 662)
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel4.Location = New System.Drawing.Point(859, 17)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(25, 17)
        Me.GunaLabel4.TabIndex = 37
        Me.GunaLabel4.Text = "Au"
        Me.GunaLabel4.Visible = False
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel2.Location = New System.Drawing.Point(19, 17)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(69, 17)
        Me.GunaLabel2.TabIndex = 37
        Me.GunaLabel2.Text = "Personnel"
        Me.GunaLabel2.Visible = False
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel3.Location = New System.Drawing.Point(332, 17)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(60, 17)
        Me.GunaLabel3.TabIndex = 37
        Me.GunaLabel3.Text = "Magasin"
        Me.GunaLabel3.Visible = False
        '
        'GunaLabel35
        '
        Me.GunaLabel35.AutoSize = True
        Me.GunaLabel35.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel35.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel35.Location = New System.Drawing.Point(680, 17)
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
        Me.GunaButtonAfficher.Location = New System.Drawing.Point(1015, 36)
        Me.GunaButtonAfficher.Name = "GunaButtonAfficher"
        Me.GunaButtonAfficher.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAfficher.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficher.OnHoverImage = Nothing
        Me.GunaButtonAfficher.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.Radius = 5
        Me.GunaButtonAfficher.Size = New System.Drawing.Size(121, 32)
        Me.GunaButtonAfficher.TabIndex = 36
        Me.GunaButtonAfficher.Text = "Afficher"
        Me.GunaButtonAfficher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(-2, 589)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1201, 10)
        Me.GunaPanel2.TabIndex = 35
        '
        'DataGridViewRapports
        '
        Me.DataGridViewRapports.AllowUserToAddRows = False
        Me.DataGridViewRapports.AllowUserToDeleteRows = False
        Me.DataGridViewRapports.AllowUserToOrderColumns = True
        Me.DataGridViewRapports.AllowUserToResizeColumns = False
        Me.DataGridViewRapports.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.DataGridViewRapports.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewRapports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewRapports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewRapports.BackgroundColor = System.Drawing.Color.LightBlue
        Me.DataGridViewRapports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewRapports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridViewRapports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewRapports.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewRapports.ColumnHeadersHeight = 25
        Me.DataGridViewRapports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRapports.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewRapports.EnableHeadersVisualStyles = False
        Me.DataGridViewRapports.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewRapports.Location = New System.Drawing.Point(28, 130)
        Me.DataGridViewRapports.Name = "DataGridViewRapports"
        Me.DataGridViewRapports.ReadOnly = True
        Me.DataGridViewRapports.RowHeadersVisible = False
        Me.DataGridViewRapports.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridViewRapports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewRapports.Size = New System.Drawing.Size(1144, 409)
        Me.DataGridViewRapports.TabIndex = 52
        Me.DataGridViewRapports.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.DataGridViewRapports.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridViewRapports.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DataGridViewRapports.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DataGridViewRapports.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DataGridViewRapports.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DataGridViewRapports.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.DataGridViewRapports.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewRapports.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewRapports.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridViewRapports.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewRapports.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DataGridViewRapports.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewRapports.ThemeStyle.HeaderStyle.Height = 25
        Me.DataGridViewRapports.ThemeStyle.ReadOnly = True
        Me.DataGridViewRapports.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridViewRapports.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridViewRapports.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewRapports.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DataGridViewRapports.ThemeStyle.RowsStyle.Height = 22
        Me.DataGridViewRapports.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewRapports.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaCheckBoxParFamille
        '
        Me.GunaCheckBoxParFamille.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxParFamille.Checked = True
        Me.GunaCheckBoxParFamille.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxParFamille.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxParFamille.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxParFamille.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxParFamille.Location = New System.Drawing.Point(450, 555)
        Me.GunaCheckBoxParFamille.Name = "GunaCheckBoxParFamille"
        Me.GunaCheckBoxParFamille.Size = New System.Drawing.Size(95, 20)
        Me.GunaCheckBoxParFamille.TabIndex = 41
        Me.GunaCheckBoxParFamille.Text = "Par famille"
        Me.GunaCheckBoxParFamille.Visible = False
        '
        'GunaComboBoxParPointDeVente
        '
        Me.GunaComboBoxParPointDeVente.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxParPointDeVente.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxParPointDeVente.BorderColor = System.Drawing.Color.Silver
        Me.GunaComboBoxParPointDeVente.BorderSize = 1
        Me.GunaComboBoxParPointDeVente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxParPointDeVente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxParPointDeVente.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxParPointDeVente.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxParPointDeVente.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxParPointDeVente.FormattingEnabled = True
        Me.GunaComboBoxParPointDeVente.ItemHeight = 25
        Me.GunaComboBoxParPointDeVente.Items.AddRange(New Object() {"Global", "Par point de vente"})
        Me.GunaComboBoxParPointDeVente.Location = New System.Drawing.Point(588, 550)
        Me.GunaComboBoxParPointDeVente.Name = "GunaComboBoxParPointDeVente"
        Me.GunaComboBoxParPointDeVente.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxParPointDeVente.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxParPointDeVente.Radius = 5
        Me.GunaComboBoxParPointDeVente.Size = New System.Drawing.Size(189, 31)
        Me.GunaComboBoxParPointDeVente.TabIndex = 40
        Me.GunaComboBoxParPointDeVente.Visible = False
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
        Me.GunaButtonImprimer.Image = CType(resources.GetObject("GunaButtonImprimer.Image"), System.Drawing.Image)
        Me.GunaButtonImprimer.ImageSize = New System.Drawing.Size(30, 30)
        Me.GunaButtonImprimer.Location = New System.Drawing.Point(1053, 547)
        Me.GunaButtonImprimer.Name = "GunaButtonImprimer"
        Me.GunaButtonImprimer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonImprimer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonImprimer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonImprimer.OnHoverImage = Nothing
        Me.GunaButtonImprimer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonImprimer.Radius = 4
        Me.GunaButtonImprimer.Size = New System.Drawing.Size(119, 32)
        Me.GunaButtonImprimer.TabIndex = 51
        Me.GunaButtonImprimer.Text = "Imprimer"
        Me.GunaButtonImprimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GunaButtonImprimer.Visible = False
        '
        'GunaCheckBoxPropResa
        '
        Me.GunaCheckBoxPropResa.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxPropResa.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxPropResa.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxPropResa.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxPropResa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxPropResa.Location = New System.Drawing.Point(28, 555)
        Me.GunaCheckBoxPropResa.Name = "GunaCheckBoxPropResa"
        Me.GunaCheckBoxPropResa.Size = New System.Drawing.Size(61, 20)
        Me.GunaCheckBoxPropResa.TabIndex = 41
        Me.GunaCheckBoxPropResa.Text = "Tous"
        Me.GunaCheckBoxPropResa.Visible = False
        '
        'GunaTextBoxCodeResa
        '
        Me.GunaTextBoxCodeResa.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeResa.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxCodeResa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeResa.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeResa.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeResa.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeResa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxCodeResa.Location = New System.Drawing.Point(89, 549)
        Me.GunaTextBoxCodeResa.Name = "GunaTextBoxCodeResa"
        Me.GunaTextBoxCodeResa.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeResa.SelectedText = ""
        Me.GunaTextBoxCodeResa.Size = New System.Drawing.Size(109, 30)
        Me.GunaTextBoxCodeResa.TabIndex = 53
        Me.GunaTextBoxCodeResa.Visible = False
        '
        'GunaButton16
        '
        Me.GunaButton16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButton16.AnimationHoverSpeed = 0.07!
        Me.GunaButton16.AnimationSpeed = 0.03!
        Me.GunaButton16.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton16.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton16.BorderColor = System.Drawing.Color.Black
        Me.GunaButton16.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton16.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton16.ForeColor = System.Drawing.Color.White
        Me.GunaButton16.Image = Nothing
        Me.GunaButton16.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton16.Location = New System.Drawing.Point(945, 552)
        Me.GunaButton16.Name = "GunaButton16"
        Me.GunaButton16.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton16.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton16.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton16.OnHoverImage = Nothing
        Me.GunaButton16.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton16.Radius = 4
        Me.GunaButton16.Size = New System.Drawing.Size(99, 26)
        Me.GunaButton16.TabIndex = 298
        Me.GunaButton16.Text = "Exporter"
        Me.GunaButton16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton16.Visible = False
        '
        'RapportFacturesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 600)
        Me.Controls.Add(Me.GunaButton16)
        Me.Controls.Add(Me.GunaTextBoxCodeResa)
        Me.Controls.Add(Me.GunaCheckBoxPropResa)
        Me.Controls.Add(Me.GunaComboBoxParPointDeVente)
        Me.Controls.Add(Me.GunaCheckBoxParFamille)
        Me.Controls.Add(Me.DataGridViewRapports)
        Me.Controls.Add(Me.GunaButtonImprimer)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RapportFacturesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.ContextMenuStripImprimerFacture.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridViewRapports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaLabelGeneral As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GunaLabel35 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDateTimePickerDebut As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaDateTimePickerFin As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaButtonAfficher As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton6 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton7 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents ContextMenuStripImprimerFacture As ContextMenuStrip
    Friend WithEvents ImprimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GunaButtonImprimer As Guna.UI.WinForms.GunaButton
    Friend WithEvents DataGridViewRapports As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaComboBoxUtilisateurDeMagasinBar As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaCheckBoxTous As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaCheckBoxParFamille As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaComboBoxParPointDeVente As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaCheckBoxPropResa As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaTextBoxCodeResa As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaComboBoxMagasins As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButton16 As Guna.UI.WinForms.GunaButton
End Class
