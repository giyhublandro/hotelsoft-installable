<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FabricationDeProformaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FabricationDeProformaForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBoxGroupe = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDataGridView = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaTextBoxClient = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabelNomClient = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.ImprimerDocChambreSalle = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonEnvoyer = New Guna.UI.WinForms.GunaButton()
        Me.GunaCheckBoxSalle = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.GunaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1069, 25)
        Me.GunaPanel1.TabIndex = 2
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(1010, 2)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 4
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = CType(resources.GetObject("GunaImageButton3.Image"), System.Drawing.Image)
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(1037, 2)
        Me.GunaImageButton3.Name = "GunaImageButton3"
        Me.GunaImageButton3.OnHoverImage = Nothing
        Me.GunaImageButton3.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton3.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton3.TabIndex = 7
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(367, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(244, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "ETABLISSEMENT DE PROFORMA"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1034, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2236, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaComboBoxGroupe
        '
        Me.GunaComboBoxGroupe.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxGroupe.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxGroupe.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxGroupe.BorderSize = 1
        Me.GunaComboBoxGroupe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxGroupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxGroupe.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxGroupe.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxGroupe.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxGroupe.FormattingEnabled = True
        Me.GunaComboBoxGroupe.ItemHeight = 25
        Me.GunaComboBoxGroupe.Location = New System.Drawing.Point(12, 52)
        Me.GunaComboBoxGroupe.Name = "GunaComboBoxGroupe"
        Me.GunaComboBoxGroupe.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxGroupe.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxGroupe.Radius = 5
        Me.GunaComboBoxGroupe.Size = New System.Drawing.Size(166, 31)
        Me.GunaComboBoxGroupe.TabIndex = 77
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(12, 31)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(81, 15)
        Me.GunaLabel2.TabIndex = 78
        Me.GunaLabel2.Text = "No de Groupe"
        '
        'GunaDataGridView
        '
        Me.GunaDataGridView.AllowUserToAddRows = False
        Me.GunaDataGridView.AllowUserToDeleteRows = False
        Me.GunaDataGridView.AllowUserToOrderColumns = True
        Me.GunaDataGridView.AllowUserToResizeColumns = False
        Me.GunaDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GunaDataGridView.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridView.ColumnHeadersHeight = 30
        Me.GunaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridView.EnableHeadersVisualStyles = False
        Me.GunaDataGridView.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView.Location = New System.Drawing.Point(12, 101)
        Me.GunaDataGridView.Name = "GunaDataGridView"
        Me.GunaDataGridView.ReadOnly = True
        Me.GunaDataGridView.RowHeadersVisible = False
        Me.GunaDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView.Size = New System.Drawing.Size(1045, 402)
        Me.GunaDataGridView.TabIndex = 104
        Me.GunaDataGridView.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridView.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView.ThemeStyle.HeaderStyle.Height = 30
        Me.GunaDataGridView.ThemeStyle.ReadOnly = True
        Me.GunaDataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridView.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaTextBoxClient
        '
        Me.GunaTextBoxClient.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxClient.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxClient.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxClient.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxClient.Enabled = False
        Me.GunaTextBoxClient.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxClient.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxClient.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxClient.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxClient.Location = New System.Drawing.Point(190, 52)
        Me.GunaTextBoxClient.Name = "GunaTextBoxClient"
        Me.GunaTextBoxClient.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxClient.Radius = 5
        Me.GunaTextBoxClient.SelectedText = ""
        Me.GunaTextBoxClient.Size = New System.Drawing.Size(431, 30)
        Me.GunaTextBoxClient.TabIndex = 105
        '
        'GunaLabelNomClient
        '
        Me.GunaLabelNomClient.AutoSize = True
        Me.GunaLabelNomClient.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabelNomClient.Location = New System.Drawing.Point(193, 33)
        Me.GunaLabelNomClient.Name = "GunaLabelNomClient"
        Me.GunaLabelNomClient.Size = New System.Drawing.Size(45, 15)
        Me.GunaLabelNomClient.TabIndex = 78
        Me.GunaLabelNomClient.Text = "CLIENT"
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
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 513)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1069, 10)
        Me.GunaPanel2.TabIndex = 106
        '
        'ImprimerDocChambreSalle
        '
        Me.ImprimerDocChambreSalle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ImprimerDocChambreSalle.AnimationHoverSpeed = 0.07!
        Me.ImprimerDocChambreSalle.AnimationSpeed = 0.03!
        Me.ImprimerDocChambreSalle.BackColor = System.Drawing.Color.Transparent
        Me.ImprimerDocChambreSalle.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ImprimerDocChambreSalle.BorderColor = System.Drawing.Color.Black
        Me.ImprimerDocChambreSalle.DialogResult = System.Windows.Forms.DialogResult.None
        Me.ImprimerDocChambreSalle.FocusedColor = System.Drawing.Color.Empty
        Me.ImprimerDocChambreSalle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ImprimerDocChambreSalle.ForeColor = System.Drawing.Color.White
        Me.ImprimerDocChambreSalle.Image = CType(resources.GetObject("ImprimerDocChambreSalle.Image"), System.Drawing.Image)
        Me.ImprimerDocChambreSalle.ImageSize = New System.Drawing.Size(20, 20)
        Me.ImprimerDocChambreSalle.Location = New System.Drawing.Point(814, 52)
        Me.ImprimerDocChambreSalle.Name = "ImprimerDocChambreSalle"
        Me.ImprimerDocChambreSalle.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ImprimerDocChambreSalle.OnHoverBorderColor = System.Drawing.Color.Black
        Me.ImprimerDocChambreSalle.OnHoverForeColor = System.Drawing.Color.White
        Me.ImprimerDocChambreSalle.OnHoverImage = Nothing
        Me.ImprimerDocChambreSalle.OnPressedColor = System.Drawing.Color.Black
        Me.ImprimerDocChambreSalle.Radius = 5
        Me.ImprimerDocChambreSalle.Size = New System.Drawing.Size(100, 31)
        Me.ImprimerDocChambreSalle.TabIndex = 107
        Me.ImprimerDocChambreSalle.Text = "Imprimer"
        '
        'GunaButtonEnvoyer
        '
        Me.GunaButtonEnvoyer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.GunaButtonEnvoyer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEnvoyer.AnimationSpeed = 0.03!
        Me.GunaButtonEnvoyer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEnvoyer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnvoyer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnvoyer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEnvoyer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEnvoyer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaButtonEnvoyer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnvoyer.Image = Nothing
        Me.GunaButtonEnvoyer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnvoyer.Location = New System.Drawing.Point(926, 52)
        Me.GunaButtonEnvoyer.Name = "GunaButtonEnvoyer"
        Me.GunaButtonEnvoyer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnvoyer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnvoyer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnvoyer.OnHoverImage = Nothing
        Me.GunaButtonEnvoyer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnvoyer.Radius = 5
        Me.GunaButtonEnvoyer.Size = New System.Drawing.Size(131, 31)
        Me.GunaButtonEnvoyer.TabIndex = 108
        Me.GunaButtonEnvoyer.Text = "Ajouter Au Devis"
        Me.GunaButtonEnvoyer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButtonEnvoyer.Visible = False
        '
        'GunaCheckBoxSalle
        '
        Me.GunaCheckBoxSalle.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxSalle.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxSalle.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxSalle.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxSalle.Location = New System.Drawing.Point(648, 58)
        Me.GunaCheckBoxSalle.Name = "GunaCheckBoxSalle"
        Me.GunaCheckBoxSalle.Size = New System.Drawing.Size(20, 20)
        Me.GunaCheckBoxSalle.TabIndex = 109
        Me.GunaCheckBoxSalle.Visible = False
        '
        'FabricationDeProformaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 524)
        Me.Controls.Add(Me.GunaCheckBoxSalle)
        Me.Controls.Add(Me.GunaButtonEnvoyer)
        Me.Controls.Add(Me.ImprimerDocChambreSalle)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaTextBoxClient)
        Me.Controls.Add(Me.GunaDataGridView)
        Me.Controls.Add(Me.GunaLabelNomClient)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaComboBoxGroupe)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FabricationDeProformaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FabricationDeProformaForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.GunaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaComboBoxGroupe As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDataGridView As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaTextBoxClient As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabelNomClient As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents ImprimerDocChambreSalle As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonEnvoyer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaCheckBoxSalle As Guna.UI.WinForms.GunaCheckBox
End Class
