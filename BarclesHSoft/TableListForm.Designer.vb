<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TableListForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.GunaTextBox1 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonAjouterLigne = New Guna.UI.WinForms.GunaButton()
        Me.GunaDataGridViewBarRestaurant = New Guna.UI.WinForms.GunaDataGridView()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridViewBarRestaurant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(187, 15)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(67, 26)
        Me.NumericUpDown1.TabIndex = 0
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(269, 15)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(67, 26)
        Me.NumericUpDown2.TabIndex = 0
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown2.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GunaTextBox1
        '
        Me.GunaTextBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox1.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox1.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox1.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBox1.Location = New System.Drawing.Point(12, 13)
        Me.GunaTextBox1.Name = "GunaTextBox1"
        Me.GunaTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox1.Radius = 4
        Me.GunaTextBox1.SelectedText = ""
        Me.GunaTextBox1.Size = New System.Drawing.Size(160, 30)
        Me.GunaTextBox1.TabIndex = 1
        '
        'GunaButtonAjouterLigne
        '
        Me.GunaButtonAjouterLigne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonAjouterLigne.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAjouterLigne.AnimationSpeed = 0.03!
        Me.GunaButtonAjouterLigne.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAjouterLigne.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAjouterLigne.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterLigne.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAjouterLigne.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAjouterLigne.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAjouterLigne.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouterLigne.Image = Nothing
        Me.GunaButtonAjouterLigne.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAjouterLigne.Location = New System.Drawing.Point(354, 15)
        Me.GunaButtonAjouterLigne.Name = "GunaButtonAjouterLigne"
        Me.GunaButtonAjouterLigne.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAjouterLigne.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterLigne.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouterLigne.OnHoverImage = Nothing
        Me.GunaButtonAjouterLigne.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterLigne.Radius = 4
        Me.GunaButtonAjouterLigne.Size = New System.Drawing.Size(98, 26)
        Me.GunaButtonAjouterLigne.TabIndex = 318
        Me.GunaButtonAjouterLigne.Text = "Générer"
        Me.GunaButtonAjouterLigne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaDataGridViewBarRestaurant
        '
        Me.GunaDataGridViewBarRestaurant.AllowUserToAddRows = False
        Me.GunaDataGridViewBarRestaurant.AllowUserToDeleteRows = False
        Me.GunaDataGridViewBarRestaurant.AllowUserToResizeColumns = False
        Me.GunaDataGridViewBarRestaurant.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewBarRestaurant.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GunaDataGridViewBarRestaurant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaDataGridViewBarRestaurant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewBarRestaurant.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewBarRestaurant.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewBarRestaurant.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewBarRestaurant.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewBarRestaurant.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GunaDataGridViewBarRestaurant.ColumnHeadersHeight = 28
        Me.GunaDataGridViewBarRestaurant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewBarRestaurant.DefaultCellStyle = DataGridViewCellStyle9
        Me.GunaDataGridViewBarRestaurant.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewBarRestaurant.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewBarRestaurant.Location = New System.Drawing.Point(10, 51)
        Me.GunaDataGridViewBarRestaurant.Name = "GunaDataGridViewBarRestaurant"
        Me.GunaDataGridViewBarRestaurant.ReadOnly = True
        Me.GunaDataGridViewBarRestaurant.RowHeadersVisible = False
        Me.GunaDataGridViewBarRestaurant.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewBarRestaurant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewBarRestaurant.Size = New System.Drawing.Size(442, 375)
        Me.GunaDataGridViewBarRestaurant.TabIndex = 319
        Me.GunaDataGridViewBarRestaurant.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.HeaderStyle.Height = 28
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewBarRestaurant.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'TableListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 431)
        Me.Controls.Add(Me.GunaDataGridViewBarRestaurant)
        Me.Controls.Add(Me.GunaButtonAjouterLigne)
        Me.Controls.Add(Me.GunaTextBox1)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Name = "TableListForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TableListForm"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridViewBarRestaurant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents GunaTextBox1 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonAjouterLigne As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDataGridViewBarRestaurant As Guna.UI.WinForms.GunaDataGridView
End Class
