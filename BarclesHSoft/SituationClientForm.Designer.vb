<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SituationClientForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SituationClientForm))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelNomDuClient = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton7 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButtonPayer = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaLabel23 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxSolde = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaDataGridViewSituation = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaButtonFacturer = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaButtonRoutageManuel = New Guna.UI.WinForms.GunaButton()
        Me.GunaContextMenuStripTransfertDeCharge = New Guna.UI.WinForms.GunaContextMenuStrip()
        Me.TransférerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnnulerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RéductionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GunaPanelTransfertEnChambre = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxMontantATransferer = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonAnnulerTransfert = New Guna.UI.WinForms.GunaButton()
        Me.GunaComboBoxCodeChambre = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBoxCodeClient = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeReservation = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeChambre = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNomClient = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelNomClient = New System.Windows.Forms.Label()
        Me.LabelChambre = New System.Windows.Forms.Label()
        Me.GunaButtonTransferer = New Guna.UI.WinForms.GunaButton()
        Me.Ordre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.designation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.credit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Article = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GriffeUtilisateur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.GunaDataGridViewSituation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaContextMenuStripTransfertDeCharge.SuspendLayout()
        Me.GunaPanelTransfertEnChambre.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(12, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(127, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "SITUATION DE  :"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelNomDuClient)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton7)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(837, 25)
        Me.GunaPanel1.TabIndex = 2
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(783, 2)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 15
        '
        'GunaLabelNomDuClient
        '
        Me.GunaLabelNomDuClient.AutoSize = True
        Me.GunaLabelNomDuClient.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelNomDuClient.ForeColor = System.Drawing.Color.White
        Me.GunaLabelNomDuClient.Location = New System.Drawing.Point(292, 5)
        Me.GunaLabelNomDuClient.Name = "GunaLabelNomDuClient"
        Me.GunaLabelNomDuClient.Size = New System.Drawing.Size(80, 17)
        Me.GunaLabelNomDuClient.TabIndex = 14
        Me.GunaLabelNomDuClient.Text = "GunaLabel2"
        '
        'GunaImageButton7
        '
        Me.GunaImageButton7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton7.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton7.Image = CType(resources.GetObject("GunaImageButton7.Image"), System.Drawing.Image)
        Me.GunaImageButton7.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton7.Location = New System.Drawing.Point(807, 2)
        Me.GunaImageButton7.Name = "GunaImageButton7"
        Me.GunaImageButton7.OnHoverImage = Nothing
        Me.GunaImageButton7.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton7.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton7.TabIndex = 13
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = Nothing
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(806, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(803, 3)
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
        Me.GunaImageButton1.Location = New System.Drawing.Point(802, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2004, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaButtonPayer
        '
        Me.GunaButtonPayer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonPayer.AnimationSpeed = 0.03!
        Me.GunaButtonPayer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonPayer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonPayer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonPayer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonPayer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonPayer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonPayer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonPayer.Image = Nothing
        Me.GunaButtonPayer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonPayer.Location = New System.Drawing.Point(506, 603)
        Me.GunaButtonPayer.Name = "GunaButtonPayer"
        Me.GunaButtonPayer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonPayer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonPayer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonPayer.OnHoverImage = Nothing
        Me.GunaButtonPayer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonPayer.Radius = 4
        Me.GunaButtonPayer.Size = New System.Drawing.Size(97, 30)
        Me.GunaButtonPayer.TabIndex = 7
        Me.GunaButtonPayer.Text = "Encaisser"
        Me.GunaButtonPayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButton1.Location = New System.Drawing.Point(16, 603)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(85, 30)
        Me.GunaButton1.TabIndex = 8
        Me.GunaButton1.Text = "Annuler"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLabelGestCompteGeneraux
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaPanel1
        '
        'GunaLabel23
        '
        Me.GunaLabel23.AutoSize = True
        Me.GunaLabel23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel23.Location = New System.Drawing.Point(510, 494)
        Me.GunaLabel23.Name = "GunaLabel23"
        Me.GunaLabel23.Size = New System.Drawing.Size(49, 17)
        Me.GunaLabel23.TabIndex = 11
        Me.GunaLabel23.Text = "SOLDE"
        '
        'GunaTextBoxSolde
        '
        Me.GunaTextBoxSolde.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxSolde.BaseColor = System.Drawing.Color.Beige
        Me.GunaTextBoxSolde.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxSolde.BorderSize = 1
        Me.GunaTextBoxSolde.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxSolde.Enabled = False
        Me.GunaTextBoxSolde.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxSolde.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxSolde.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxSolde.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxSolde.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxSolde.Location = New System.Drawing.Point(600, 484)
        Me.GunaTextBoxSolde.Name = "GunaTextBoxSolde"
        Me.GunaTextBoxSolde.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxSolde.Radius = 10
        Me.GunaTextBoxSolde.SelectedText = ""
        Me.GunaTextBoxSolde.Size = New System.Drawing.Size(138, 37)
        Me.GunaTextBoxSolde.TabIndex = 10
        Me.GunaTextBoxSolde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaDataGridViewSituation
        '
        Me.GunaDataGridViewSituation.AllowUserToAddRows = False
        Me.GunaDataGridViewSituation.AllowUserToDeleteRows = False
        Me.GunaDataGridViewSituation.AllowUserToOrderColumns = True
        Me.GunaDataGridViewSituation.AllowUserToResizeColumns = False
        Me.GunaDataGridViewSituation.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewSituation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.GunaDataGridViewSituation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewSituation.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewSituation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewSituation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewSituation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewSituation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.GunaDataGridViewSituation.ColumnHeadersHeight = 25
        Me.GunaDataGridViewSituation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewSituation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ordre, Me.DataGridViewTextBoxColumn2, Me.designation, Me.debit, Me.credit, Me.Article, Me.code, Me.Id, Me.GriffeUtilisateur})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewSituation.DefaultCellStyle = DataGridViewCellStyle15
        Me.GunaDataGridViewSituation.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewSituation.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewSituation.Location = New System.Drawing.Point(14, 41)
        Me.GunaDataGridViewSituation.Name = "GunaDataGridViewSituation"
        Me.GunaDataGridViewSituation.ReadOnly = True
        Me.GunaDataGridViewSituation.RowHeadersVisible = False
        Me.GunaDataGridViewSituation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewSituation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewSituation.Size = New System.Drawing.Size(811, 420)
        Me.GunaDataGridViewSituation.TabIndex = 9
        Me.GunaDataGridViewSituation.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewSituation.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewSituation.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewSituation.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewSituation.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewSituation.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewSituation.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewSituation.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewSituation.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewSituation.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewSituation.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewSituation.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewSituation.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewSituation.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewSituation.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewSituation.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewSituation.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewSituation.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewSituation.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewSituation.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewSituation.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewSituation.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaButtonFacturer
        '
        Me.GunaButtonFacturer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonFacturer.AnimationSpeed = 0.03!
        Me.GunaButtonFacturer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonFacturer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonFacturer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonFacturer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonFacturer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonFacturer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonFacturer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonFacturer.Image = Nothing
        Me.GunaButtonFacturer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonFacturer.Location = New System.Drawing.Point(641, 603)
        Me.GunaButtonFacturer.Name = "GunaButtonFacturer"
        Me.GunaButtonFacturer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonFacturer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonFacturer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonFacturer.OnHoverImage = Nothing
        Me.GunaButtonFacturer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonFacturer.Radius = 4
        Me.GunaButtonFacturer.Size = New System.Drawing.Size(97, 30)
        Me.GunaButtonFacturer.TabIndex = 7
        Me.GunaButtonFacturer.Text = "Facturer"
        Me.GunaButtonFacturer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(-2, 639)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(754, 10)
        Me.GunaPanel2.TabIndex = 12
        '
        'GunaButtonRoutageManuel
        '
        Me.GunaButtonRoutageManuel.AnimationHoverSpeed = 0.07!
        Me.GunaButtonRoutageManuel.AnimationSpeed = 0.03!
        Me.GunaButtonRoutageManuel.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonRoutageManuel.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonRoutageManuel.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonRoutageManuel.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonRoutageManuel.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonRoutageManuel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonRoutageManuel.ForeColor = System.Drawing.Color.White
        Me.GunaButtonRoutageManuel.Image = Nothing
        Me.GunaButtonRoutageManuel.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonRoutageManuel.Location = New System.Drawing.Point(272, 603)
        Me.GunaButtonRoutageManuel.Name = "GunaButtonRoutageManuel"
        Me.GunaButtonRoutageManuel.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonRoutageManuel.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonRoutageManuel.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonRoutageManuel.OnHoverImage = Nothing
        Me.GunaButtonRoutageManuel.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonRoutageManuel.Radius = 4
        Me.GunaButtonRoutageManuel.Size = New System.Drawing.Size(143, 30)
        Me.GunaButtonRoutageManuel.TabIndex = 8
        Me.GunaButtonRoutageManuel.Text = "Routage"
        Me.GunaButtonRoutageManuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButtonRoutageManuel.Visible = False
        '
        'GunaContextMenuStripTransfertDeCharge
        '
        Me.GunaContextMenuStripTransfertDeCharge.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransférerToolStripMenuItem, Me.AnnulerToolStripMenuItem, Me.RéductionToolStripMenuItem})
        Me.GunaContextMenuStripTransfertDeCharge.Name = "GunaContextMenuStripTransfertDeBlocNote"
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.ColorTable = Nothing
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.RoundedEdges = True
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.SelectionArrowColor = System.Drawing.Color.White
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro
        Me.GunaContextMenuStripTransfertDeCharge.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault
        Me.GunaContextMenuStripTransfertDeCharge.Size = New System.Drawing.Size(129, 70)
        '
        'TransférerToolStripMenuItem
        '
        Me.TransférerToolStripMenuItem.Name = "TransférerToolStripMenuItem"
        Me.TransférerToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.TransférerToolStripMenuItem.Text = "Transférer"
        '
        'AnnulerToolStripMenuItem
        '
        Me.AnnulerToolStripMenuItem.Name = "AnnulerToolStripMenuItem"
        Me.AnnulerToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.AnnulerToolStripMenuItem.Text = "Annuler"
        '
        'RéductionToolStripMenuItem
        '
        Me.RéductionToolStripMenuItem.Name = "RéductionToolStripMenuItem"
        Me.RéductionToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.RéductionToolStripMenuItem.Text = "Réduction"
        '
        'GunaPanelTransfertEnChambre
        '
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxMontantATransferer)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaButtonAnnulerTransfert)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaComboBoxCodeChambre)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxCodeClient)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxCodeReservation)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxCodeChambre)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxNomClient)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.LabelNomClient)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.LabelChambre)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaButtonTransferer)
        Me.GunaPanelTransfertEnChambre.Location = New System.Drawing.Point(4, 466)
        Me.GunaPanelTransfertEnChambre.Name = "GunaPanelTransfertEnChambre"
        Me.GunaPanelTransfertEnChambre.Size = New System.Drawing.Size(424, 131)
        Me.GunaPanelTransfertEnChambre.TabIndex = 88
        Me.GunaPanelTransfertEnChambre.Visible = False
        '
        'GunaTextBoxMontantATransferer
        '
        Me.GunaTextBoxMontantATransferer.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantATransferer.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantATransferer.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantATransferer.BorderSize = 1
        Me.GunaTextBoxMontantATransferer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantATransferer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantATransferer.Enabled = False
        Me.GunaTextBoxMontantATransferer.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantATransferer.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantATransferer.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantATransferer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxMontantATransferer.Location = New System.Drawing.Point(141, 61)
        Me.GunaTextBoxMontantATransferer.Name = "GunaTextBoxMontantATransferer"
        Me.GunaTextBoxMontantATransferer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantATransferer.Radius = 5
        Me.GunaTextBoxMontantATransferer.SelectedText = ""
        Me.GunaTextBoxMontantATransferer.Size = New System.Drawing.Size(87, 30)
        Me.GunaTextBoxMontantATransferer.TabIndex = 0
        Me.GunaTextBoxMontantATransferer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonAnnulerTransfert
        '
        Me.GunaButtonAnnulerTransfert.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAnnulerTransfert.AnimationSpeed = 0.03!
        Me.GunaButtonAnnulerTransfert.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAnnulerTransfert.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAnnulerTransfert.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAnnulerTransfert.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAnnulerTransfert.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAnnulerTransfert.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAnnulerTransfert.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAnnulerTransfert.Image = Nothing
        Me.GunaButtonAnnulerTransfert.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAnnulerTransfert.Location = New System.Drawing.Point(238, 61)
        Me.GunaButtonAnnulerTransfert.Name = "GunaButtonAnnulerTransfert"
        Me.GunaButtonAnnulerTransfert.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAnnulerTransfert.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAnnulerTransfert.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAnnulerTransfert.OnHoverImage = Nothing
        Me.GunaButtonAnnulerTransfert.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAnnulerTransfert.Radius = 4
        Me.GunaButtonAnnulerTransfert.Size = New System.Drawing.Size(86, 29)
        Me.GunaButtonAnnulerTransfert.TabIndex = 8
        Me.GunaButtonAnnulerTransfert.Text = "Annuler"
        Me.GunaButtonAnnulerTransfert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaComboBoxCodeChambre
        '
        Me.GunaComboBoxCodeChambre.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxCodeChambre.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxCodeChambre.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxCodeChambre.BorderSize = 1
        Me.GunaComboBoxCodeChambre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxCodeChambre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxCodeChambre.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxCodeChambre.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxCodeChambre.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxCodeChambre.FormattingEnabled = True
        Me.GunaComboBoxCodeChambre.ItemHeight = 25
        Me.GunaComboBoxCodeChambre.Location = New System.Drawing.Point(20, 25)
        Me.GunaComboBoxCodeChambre.Name = "GunaComboBoxCodeChambre"
        Me.GunaComboBoxCodeChambre.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxCodeChambre.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxCodeChambre.Radius = 5
        Me.GunaComboBoxCodeChambre.Size = New System.Drawing.Size(115, 31)
        Me.GunaComboBoxCodeChambre.TabIndex = 88
        '
        'GunaTextBoxCodeClient
        '
        Me.GunaTextBoxCodeClient.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeClient.BaseColor = System.Drawing.Color.DimGray
        Me.GunaTextBoxCodeClient.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeClient.BorderSize = 1
        Me.GunaTextBoxCodeClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeClient.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeClient.Enabled = False
        Me.GunaTextBoxCodeClient.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeClient.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeClient.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeClient.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeClient.Location = New System.Drawing.Point(20, 98)
        Me.GunaTextBoxCodeClient.Name = "GunaTextBoxCodeClient"
        Me.GunaTextBoxCodeClient.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeClient.Radius = 5
        Me.GunaTextBoxCodeClient.SelectedText = ""
        Me.GunaTextBoxCodeClient.Size = New System.Drawing.Size(93, 30)
        Me.GunaTextBoxCodeClient.TabIndex = 0
        Me.GunaTextBoxCodeClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeClient.Visible = False
        '
        'GunaTextBoxCodeReservation
        '
        Me.GunaTextBoxCodeReservation.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeReservation.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeReservation.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeReservation.BorderSize = 1
        Me.GunaTextBoxCodeReservation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeReservation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeReservation.Enabled = False
        Me.GunaTextBoxCodeReservation.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeReservation.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeReservation.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeReservation.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeReservation.Location = New System.Drawing.Point(20, 61)
        Me.GunaTextBoxCodeReservation.Name = "GunaTextBoxCodeReservation"
        Me.GunaTextBoxCodeReservation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeReservation.Radius = 5
        Me.GunaTextBoxCodeReservation.SelectedText = ""
        Me.GunaTextBoxCodeReservation.Size = New System.Drawing.Size(115, 30)
        Me.GunaTextBoxCodeReservation.TabIndex = 0
        Me.GunaTextBoxCodeReservation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxCodeChambre
        '
        Me.GunaTextBoxCodeChambre.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeChambre.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeChambre.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeChambre.BorderSize = 1
        Me.GunaTextBoxCodeChambre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeChambre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeChambre.Enabled = False
        Me.GunaTextBoxCodeChambre.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeChambre.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeChambre.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeChambre.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeChambre.Location = New System.Drawing.Point(119, 98)
        Me.GunaTextBoxCodeChambre.Name = "GunaTextBoxCodeChambre"
        Me.GunaTextBoxCodeChambre.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeChambre.Radius = 5
        Me.GunaTextBoxCodeChambre.SelectedText = ""
        Me.GunaTextBoxCodeChambre.Size = New System.Drawing.Size(64, 30)
        Me.GunaTextBoxCodeChambre.TabIndex = 0
        Me.GunaTextBoxCodeChambre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeChambre.Visible = False
        '
        'GunaTextBoxNomClient
        '
        Me.GunaTextBoxNomClient.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNomClient.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomClient.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNomClient.BorderSize = 1
        Me.GunaTextBoxNomClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNomClient.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNomClient.Enabled = False
        Me.GunaTextBoxNomClient.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomClient.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNomClient.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNomClient.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxNomClient.Location = New System.Drawing.Point(141, 25)
        Me.GunaTextBoxNomClient.Name = "GunaTextBoxNomClient"
        Me.GunaTextBoxNomClient.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNomClient.Radius = 5
        Me.GunaTextBoxNomClient.SelectedText = ""
        Me.GunaTextBoxNomClient.Size = New System.Drawing.Size(275, 30)
        Me.GunaTextBoxNomClient.TabIndex = 0
        Me.GunaTextBoxNomClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelNomClient
        '
        Me.LabelNomClient.AutoSize = True
        Me.LabelNomClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNomClient.Location = New System.Drawing.Point(142, 6)
        Me.LabelNomClient.Name = "LabelNomClient"
        Me.LabelNomClient.Size = New System.Drawing.Size(102, 16)
        Me.LabelNomClient.TabIndex = 84
        Me.LabelNomClient.Text = "Nom du client"
        Me.LabelNomClient.Visible = False
        '
        'LabelChambre
        '
        Me.LabelChambre.AutoSize = True
        Me.LabelChambre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelChambre.Location = New System.Drawing.Point(17, 6)
        Me.LabelChambre.Name = "LabelChambre"
        Me.LabelChambre.Size = New System.Drawing.Size(70, 16)
        Me.LabelChambre.TabIndex = 84
        Me.LabelChambre.Text = "Chambre"
        Me.LabelChambre.Visible = False
        '
        'GunaButtonTransferer
        '
        Me.GunaButtonTransferer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonTransferer.AnimationSpeed = 0.03!
        Me.GunaButtonTransferer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonTransferer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonTransferer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonTransferer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonTransferer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonTransferer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonTransferer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonTransferer.Image = Nothing
        Me.GunaButtonTransferer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonTransferer.Location = New System.Drawing.Point(330, 61)
        Me.GunaButtonTransferer.Name = "GunaButtonTransferer"
        Me.GunaButtonTransferer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonTransferer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonTransferer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonTransferer.OnHoverImage = Nothing
        Me.GunaButtonTransferer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonTransferer.Radius = 4
        Me.GunaButtonTransferer.Size = New System.Drawing.Size(86, 29)
        Me.GunaButtonTransferer.TabIndex = 8
        Me.GunaButtonTransferer.Text = "Transférer"
        Me.GunaButtonTransferer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Ordre
        '
        Me.Ordre.HeaderText = "Ordre"
        Me.Ordre.Name = "Ordre"
        Me.Ordre.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date opération"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'designation
        '
        Me.designation.HeaderText = "Libelle Operation"
        Me.designation.Name = "designation"
        Me.designation.ReadOnly = True
        '
        'debit
        '
        Me.debit.HeaderText = "Débit"
        Me.debit.Name = "debit"
        Me.debit.ReadOnly = True
        '
        'credit
        '
        Me.credit.HeaderText = "Crédit"
        Me.credit.Name = "credit"
        Me.credit.ReadOnly = True
        '
        'Article
        '
        Me.Article.HeaderText = "Article"
        Me.Article.Name = "Article"
        Me.Article.ReadOnly = True
        Me.Article.Visible = False
        '
        'code
        '
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        Me.code.Visible = False
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'GriffeUtilisateur
        '
        Me.GriffeUtilisateur.HeaderText = "Utilisateur"
        Me.GriffeUtilisateur.Name = "GriffeUtilisateur"
        Me.GriffeUtilisateur.ReadOnly = True
        '
        'SituationClientForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 650)
        Me.ContextMenuStrip = Me.GunaContextMenuStripTransfertDeCharge
        Me.Controls.Add(Me.GunaPanelTransfertEnChambre)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaLabel23)
        Me.Controls.Add(Me.GunaTextBoxSolde)
        Me.Controls.Add(Me.GunaDataGridViewSituation)
        Me.Controls.Add(Me.GunaButtonFacturer)
        Me.Controls.Add(Me.GunaButtonPayer)
        Me.Controls.Add(Me.GunaButtonRoutageManuel)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SituationClientForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClientForm"
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.GunaDataGridViewSituation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaContextMenuStripTransfertDeCharge.ResumeLayout(False)
        Me.GunaPanelTransfertEnChambre.ResumeLayout(False)
        Me.GunaPanelTransfertEnChambre.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaButtonPayer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaImageButton7 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel23 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxSolde As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewSituation As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaButtonFacturer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabelNomDuClient As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaButtonRoutageManuel As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaContextMenuStripTransfertDeCharge As Guna.UI.WinForms.GunaContextMenuStrip
    Friend WithEvents TransférerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GunaPanelTransfertEnChambre As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaComboBoxCodeChambre As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxCodeClient As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeReservation As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeChambre As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNomClient As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelNomClient As Label
    Friend WithEvents LabelChambre As Label
    Friend WithEvents GunaButtonTransferer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonAnnulerTransfert As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxMontantATransferer As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents AnnulerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RéductionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Ordre As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents designation As DataGridViewTextBoxColumn
    Friend WithEvents debit As DataGridViewTextBoxColumn
    Friend WithEvents credit As DataGridViewTextBoxColumn
    Friend WithEvents Article As DataGridViewTextBoxColumn
    Friend WithEvents code As DataGridViewTextBoxColumn
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents GriffeUtilisateur As DataGridViewTextBoxColumn
End Class
