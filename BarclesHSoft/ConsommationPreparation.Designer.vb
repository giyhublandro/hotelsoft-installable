<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsommationPreparation
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLabelNomDuNettoyeur = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaComboBoxUniteDeCompatage = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxUniteDeStockage = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel28 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxBoisson = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaDataGridViewExisting = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaLinePanelTop.SuspendLayout()
        CType(Me.GunaDataGridViewExisting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaLabelNomDuNettoyeur
        '
        Me.GunaLabelNomDuNettoyeur.AutoSize = True
        Me.GunaLabelNomDuNettoyeur.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelNomDuNettoyeur.Location = New System.Drawing.Point(192, 7)
        Me.GunaLabelNomDuNettoyeur.Name = "GunaLabelNomDuNettoyeur"
        Me.GunaLabelNomDuNettoyeur.Size = New System.Drawing.Size(197, 17)
        Me.GunaLabelNomDuNettoyeur.TabIndex = 74
        Me.GunaLabelNomDuNettoyeur.Text = "Préparation de Consommation"
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelNomDuNettoyeur)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(584, 33)
        Me.GunaLinePanelTop.TabIndex = 2
        '
        'GunaComboBoxUniteDeCompatage
        '
        Me.GunaComboBoxUniteDeCompatage.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxUniteDeCompatage.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxUniteDeCompatage.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxUniteDeCompatage.BorderSize = 1
        Me.GunaComboBoxUniteDeCompatage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxUniteDeCompatage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxUniteDeCompatage.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxUniteDeCompatage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxUniteDeCompatage.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxUniteDeCompatage.FormattingEnabled = True
        Me.GunaComboBoxUniteDeCompatage.ItemHeight = 25
        Me.GunaComboBoxUniteDeCompatage.Location = New System.Drawing.Point(23, 119)
        Me.GunaComboBoxUniteDeCompatage.Name = "GunaComboBoxUniteDeCompatage"
        Me.GunaComboBoxUniteDeCompatage.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxUniteDeCompatage.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxUniteDeCompatage.Radius = 5
        Me.GunaComboBoxUniteDeCompatage.Size = New System.Drawing.Size(299, 31)
        Me.GunaComboBoxUniteDeCompatage.TabIndex = 103
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(23, 99)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(191, 17)
        Me.GunaLabel2.TabIndex = 104
        Me.GunaLabel2.Text = "Quantité de la consommation : "
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(20, 45)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(122, 17)
        Me.GunaLabel1.TabIndex = 104
        Me.GunaLabel1.Text = "Consommation de :"
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
        Me.GunaButtonEnregistrer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEnregistrer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.Image = Nothing
        Me.GunaButtonEnregistrer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(451, 173)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(121, 37)
        Me.GunaButtonEnregistrer.TabIndex = 105
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
        Me.GunaButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(12, 173)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 37)
        Me.GunaButton1.TabIndex = 106
        Me.GunaButton1.Text = "Annuler"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.Indigo
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 215)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(586, 10)
        Me.GunaPanel1.TabIndex = 107
        '
        'GunaTextBoxUniteDeStockage
        '
        Me.GunaTextBoxUniteDeStockage.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxUniteDeStockage.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxUniteDeStockage.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxUniteDeStockage.BorderSize = 1
        Me.GunaTextBoxUniteDeStockage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxUniteDeStockage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxUniteDeStockage.Enabled = False
        Me.GunaTextBoxUniteDeStockage.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxUniteDeStockage.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxUniteDeStockage.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxUniteDeStockage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxUniteDeStockage.Location = New System.Drawing.Point(341, 119)
        Me.GunaTextBoxUniteDeStockage.Name = "GunaTextBoxUniteDeStockage"
        Me.GunaTextBoxUniteDeStockage.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxUniteDeStockage.Radius = 4
        Me.GunaTextBoxUniteDeStockage.SelectedText = ""
        Me.GunaTextBoxUniteDeStockage.Size = New System.Drawing.Size(156, 31)
        Me.GunaTextBoxUniteDeStockage.TabIndex = 109
        Me.GunaTextBoxUniteDeStockage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel28
        '
        Me.GunaLabel28.AutoSize = True
        Me.GunaLabel28.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel28.Location = New System.Drawing.Point(338, 99)
        Me.GunaLabel28.Name = "GunaLabel28"
        Me.GunaLabel28.Size = New System.Drawing.Size(44, 17)
        Me.GunaLabel28.TabIndex = 108
        Me.GunaLabel28.Text = "Valeur"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(503, 127)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(63, 17)
        Me.GunaLabel3.TabIndex = 108
        Me.GunaLabel3.Text = "Centi litre"
        '
        'GunaTextBoxBoisson
        '
        Me.GunaTextBoxBoisson.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxBoisson.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxBoisson.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxBoisson.BorderSize = 1
        Me.GunaTextBoxBoisson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxBoisson.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxBoisson.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxBoisson.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxBoisson.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxBoisson.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxBoisson.Location = New System.Drawing.Point(151, 38)
        Me.GunaTextBoxBoisson.Name = "GunaTextBoxBoisson"
        Me.GunaTextBoxBoisson.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxBoisson.Radius = 5
        Me.GunaTextBoxBoisson.SelectedText = ""
        Me.GunaTextBoxBoisson.Size = New System.Drawing.Size(415, 30)
        Me.GunaTextBoxBoisson.TabIndex = 110
        '
        'GunaDataGridViewExisting
        '
        Me.GunaDataGridViewExisting.AllowUserToAddRows = False
        Me.GunaDataGridViewExisting.AllowUserToDeleteRows = False
        Me.GunaDataGridViewExisting.AllowUserToOrderColumns = True
        Me.GunaDataGridViewExisting.AllowUserToResizeColumns = False
        Me.GunaDataGridViewExisting.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewExisting.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewExisting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewExisting.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewExisting.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewExisting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewExisting.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewExisting.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewExisting.ColumnHeadersHeight = 4
        Me.GunaDataGridViewExisting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewExisting.ColumnHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewExisting.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewExisting.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewExisting.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewExisting.Location = New System.Drawing.Point(152, 70)
        Me.GunaDataGridViewExisting.MultiSelect = False
        Me.GunaDataGridViewExisting.Name = "GunaDataGridViewExisting"
        Me.GunaDataGridViewExisting.ReadOnly = True
        Me.GunaDataGridViewExisting.RowHeadersVisible = False
        Me.GunaDataGridViewExisting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewExisting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewExisting.Size = New System.Drawing.Size(416, 26)
        Me.GunaDataGridViewExisting.TabIndex = 111
        Me.GunaDataGridViewExisting.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewExisting.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewExisting.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewExisting.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewExisting.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewExisting.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewExisting.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewExisting.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewExisting.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewExisting.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewExisting.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewExisting.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewExisting.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewExisting.ThemeStyle.HeaderStyle.Height = 4
        Me.GunaDataGridViewExisting.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewExisting.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewExisting.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewExisting.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewExisting.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewExisting.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewExisting.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewExisting.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewExisting.Visible = False
        '
        'ConsommationPreparation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 225)
        Me.Controls.Add(Me.GunaDataGridViewExisting)
        Me.Controls.Add(Me.GunaTextBoxBoisson)
        Me.Controls.Add(Me.GunaTextBoxUniteDeStockage)
        Me.Controls.Add(Me.GunaLabel3)
        Me.Controls.Add(Me.GunaLabel28)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaButtonEnregistrer)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaComboBoxUniteDeCompatage)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ConsommationPreparation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConsommationPreparation"
        Me.TopMost = True
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        CType(Me.GunaDataGridViewExisting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaLabelNomDuNettoyeur As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaComboBoxUniteDeCompatage As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxUniteDeStockage As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel28 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxBoisson As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewExisting As Guna.UI.WinForms.GunaDataGridView
End Class
