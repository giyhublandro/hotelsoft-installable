<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimePickerForm
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
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabelTitreHeure = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaComboBoxMinutes = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaComboBoxHeure = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabelTime = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.SuspendLayout()
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.Indigo
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(224, 72)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 5
        Me.GunaButton1.Size = New System.Drawing.Size(54, 25)
        Me.GunaButton1.TabIndex = 0
        Me.GunaButton1.Text = "OK"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabelTitreHeure
        '
        Me.GunaLabelTitreHeure.AutoSize = True
        Me.GunaLabelTitreHeure.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelTitreHeure.Location = New System.Drawing.Point(81, 10)
        Me.GunaLabelTitreHeure.Name = "GunaLabelTitreHeure"
        Me.GunaLabelTitreHeure.Size = New System.Drawing.Size(124, 19)
        Me.GunaLabelTitreHeure.TabIndex = 1
        Me.GunaLabelTitreHeure.Text = "HEURE D'ARRIVEE"
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.Indigo
        Me.GunaPanel1.Location = New System.Drawing.Point(-5, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(297, 12)
        Me.GunaPanel1.TabIndex = 3
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.Indigo
        Me.GunaPanel2.Location = New System.Drawing.Point(-5, 120)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(300, 10)
        Me.GunaPanel2.TabIndex = 3
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(40, 99)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(43, 15)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "HEURE"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(131, 99)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(59, 15)
        Me.GunaLabel2.TabIndex = 1
        Me.GunaLabel2.Text = "MINUTES"
        '
        'GunaComboBoxMinutes
        '
        Me.GunaComboBoxMinutes.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxMinutes.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxMinutes.BorderColor = System.Drawing.Color.LightGray
        Me.GunaComboBoxMinutes.BorderSize = 1
        Me.GunaComboBoxMinutes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxMinutes.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxMinutes.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaComboBoxMinutes.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxMinutes.FormattingEnabled = True
        Me.GunaComboBoxMinutes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "00"})
        Me.GunaComboBoxMinutes.Location = New System.Drawing.Point(120, 67)
        Me.GunaComboBoxMinutes.Name = "GunaComboBoxMinutes"
        Me.GunaComboBoxMinutes.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxMinutes.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxMinutes.Radius = 5
        Me.GunaComboBoxMinutes.Size = New System.Drawing.Size(82, 30)
        Me.GunaComboBoxMinutes.TabIndex = 4
        '
        'GunaComboBoxHeure
        '
        Me.GunaComboBoxHeure.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxHeure.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxHeure.BorderColor = System.Drawing.Color.LightGray
        Me.GunaComboBoxHeure.BorderSize = 1
        Me.GunaComboBoxHeure.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxHeure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxHeure.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxHeure.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaComboBoxHeure.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxHeure.FormattingEnabled = True
        Me.GunaComboBoxHeure.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "00"})
        Me.GunaComboBoxHeure.Location = New System.Drawing.Point(24, 67)
        Me.GunaComboBoxHeure.Name = "GunaComboBoxHeure"
        Me.GunaComboBoxHeure.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxHeure.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxHeure.Radius = 5
        Me.GunaComboBoxHeure.Size = New System.Drawing.Size(82, 30)
        Me.GunaComboBoxHeure.TabIndex = 4
        '
        'GunaLabelTime
        '
        Me.GunaLabelTime.AutoSize = True
        Me.GunaLabelTime.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelTime.Location = New System.Drawing.Point(95, 31)
        Me.GunaLabelTime.Name = "GunaLabelTime"
        Me.GunaLabelTime.Size = New System.Drawing.Size(102, 32)
        Me.GunaLabelTime.TabIndex = 1
        Me.GunaLabelTime.Text = "15:30:00"
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BaseColor = System.Drawing.Color.Indigo
        Me.GunaButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButton2.ForeColor = System.Drawing.Color.White
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(224, 102)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 5
        Me.GunaButton2.Size = New System.Drawing.Size(54, 15)
        Me.GunaButton2.TabIndex = 0
        Me.GunaButton2.Text = "Annuler"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TimePickerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 130)
        Me.Controls.Add(Me.GunaComboBoxHeure)
        Me.Controls.Add(Me.GunaComboBoxMinutes)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaLabelTime)
        Me.Controls.Add(Me.GunaLabelTitreHeure)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TimePickerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TimePickerForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabelTitreHeure As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaComboBoxMinutes As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaComboBoxHeure As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabelTime As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
End Class
