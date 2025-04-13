<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ActivationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActivationForm))
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelTitre = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxMessage = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonActiver = New Guna.UI.WinForms.GunaButton()
        Me.GunaShadowPanel1 = New Guna.UI.WinForms.GunaShadowPanel()
        Me.GunaTextBox5 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBox4 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBox3 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBox2 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBox1 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel10 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel9 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLinePanelTop.SuspendLayout()
        Me.GunaShadowPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelTitre)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(490, 33)
        Me.GunaLinePanelTop.TabIndex = 1
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(451, 7)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 4
        '
        'GunaLabelTitre
        '
        Me.GunaLabelTitre.AutoSize = True
        Me.GunaLabelTitre.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelTitre.Location = New System.Drawing.Point(8, 7)
        Me.GunaLabelTitre.Name = "GunaLabelTitre"
        Me.GunaLabelTitre.Size = New System.Drawing.Size(273, 17)
        Me.GunaLabelTitre.TabIndex = 74
        Me.GunaLabelTitre.Text = "ACTIVATION DE HOTEL SOFT PAR BARCLES"
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLinePanelTop
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Nothing
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(210, 552)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(156, 40)
        Me.GunaButton1.TabIndex = 3
        Me.GunaButton1.Text = "Fermer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton2.ForeColor = System.Drawing.Color.White
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(383, 552)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 4
        Me.GunaButton2.Size = New System.Drawing.Size(156, 40)
        Me.GunaButton2.TabIndex = 3
        Me.GunaButton2.Text = "Enregistrer"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxMessage
        '
        Me.GunaTextBoxMessage.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMessage.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxMessage.BorderSize = 1
        Me.GunaTextBoxMessage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMessage.Enabled = False
        Me.GunaTextBoxMessage.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMessage.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMessage.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMessage.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaTextBoxMessage.Location = New System.Drawing.Point(12, 39)
        Me.GunaTextBoxMessage.Multiline = True
        Me.GunaTextBoxMessage.Name = "GunaTextBoxMessage"
        Me.GunaTextBoxMessage.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMessage.SelectedText = ""
        Me.GunaTextBoxMessage.Size = New System.Drawing.Size(466, 55)
        Me.GunaTextBoxMessage.TabIndex = 6
        Me.GunaTextBoxMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonActiver
        '
        Me.GunaButtonActiver.AnimationHoverSpeed = 0.07!
        Me.GunaButtonActiver.AnimationSpeed = 0.03!
        Me.GunaButtonActiver.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonActiver.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonActiver.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonActiver.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonActiver.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonActiver.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonActiver.ForeColor = System.Drawing.Color.White
        Me.GunaButtonActiver.Image = Nothing
        Me.GunaButtonActiver.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonActiver.Location = New System.Drawing.Point(191, 173)
        Me.GunaButtonActiver.Name = "GunaButtonActiver"
        Me.GunaButtonActiver.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonActiver.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonActiver.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonActiver.OnHoverImage = Nothing
        Me.GunaButtonActiver.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonActiver.Radius = 4
        Me.GunaButtonActiver.Size = New System.Drawing.Size(120, 26)
        Me.GunaButtonActiver.TabIndex = 5
        Me.GunaButtonActiver.Text = "Activer"
        Me.GunaButtonActiver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaShadowPanel1
        '
        Me.GunaShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaShadowPanel1.BaseColor = System.Drawing.Color.White
        Me.GunaShadowPanel1.Controls.Add(Me.GunaTextBox5)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaTextBox4)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaTextBox3)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaTextBox2)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaTextBox1)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel10)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel9)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel8)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel7)
        Me.GunaShadowPanel1.Location = New System.Drawing.Point(12, 100)
        Me.GunaShadowPanel1.Name = "GunaShadowPanel1"
        Me.GunaShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.GunaShadowPanel1.ShadowShift = 10
        Me.GunaShadowPanel1.Size = New System.Drawing.Size(466, 67)
        Me.GunaShadowPanel1.TabIndex = 39
        '
        'GunaTextBox5
        '
        Me.GunaTextBox5.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox5.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox5.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBox5.BorderSize = 1
        Me.GunaTextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox5.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox5.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox5.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBox5.Location = New System.Drawing.Point(364, 17)
        Me.GunaTextBox5.MaxLength = 5
        Me.GunaTextBox5.Name = "GunaTextBox5"
        Me.GunaTextBox5.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox5.Radius = 5
        Me.GunaTextBox5.SelectedText = ""
        Me.GunaTextBox5.Size = New System.Drawing.Size(60, 32)
        Me.GunaTextBox5.TabIndex = 4
        Me.GunaTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBox4
        '
        Me.GunaTextBox4.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox4.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox4.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBox4.BorderSize = 1
        Me.GunaTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox4.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox4.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox4.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBox4.Location = New System.Drawing.Point(283, 17)
        Me.GunaTextBox4.MaxLength = 5
        Me.GunaTextBox4.Name = "GunaTextBox4"
        Me.GunaTextBox4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox4.Radius = 5
        Me.GunaTextBox4.SelectedText = ""
        Me.GunaTextBox4.Size = New System.Drawing.Size(60, 32)
        Me.GunaTextBox4.TabIndex = 3
        Me.GunaTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBox3
        '
        Me.GunaTextBox3.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox3.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox3.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBox3.BorderSize = 1
        Me.GunaTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox3.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox3.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox3.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBox3.Location = New System.Drawing.Point(202, 17)
        Me.GunaTextBox3.MaxLength = 5
        Me.GunaTextBox3.Name = "GunaTextBox3"
        Me.GunaTextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox3.Radius = 5
        Me.GunaTextBox3.SelectedText = ""
        Me.GunaTextBox3.Size = New System.Drawing.Size(60, 32)
        Me.GunaTextBox3.TabIndex = 2
        Me.GunaTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBox2
        '
        Me.GunaTextBox2.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox2.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox2.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBox2.BorderSize = 1
        Me.GunaTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox2.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox2.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox2.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBox2.Location = New System.Drawing.Point(121, 17)
        Me.GunaTextBox2.MaxLength = 5
        Me.GunaTextBox2.Name = "GunaTextBox2"
        Me.GunaTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox2.Radius = 5
        Me.GunaTextBox2.SelectedText = ""
        Me.GunaTextBox2.Size = New System.Drawing.Size(60, 32)
        Me.GunaTextBox2.TabIndex = 1
        Me.GunaTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBox1
        '
        Me.GunaTextBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox1.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox1.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBox1.BorderSize = 1
        Me.GunaTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox1.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBox1.Location = New System.Drawing.Point(40, 17)
        Me.GunaTextBox1.MaxLength = 5
        Me.GunaTextBox1.Name = "GunaTextBox1"
        Me.GunaTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox1.Radius = 5
        Me.GunaTextBox1.SelectedText = ""
        Me.GunaTextBox1.Size = New System.Drawing.Size(60, 32)
        Me.GunaTextBox1.TabIndex = 0
        Me.GunaTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel10
        '
        Me.GunaLabel10.AutoSize = True
        Me.GunaLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GunaLabel10.Location = New System.Drawing.Point(347, 26)
        Me.GunaLabel10.Name = "GunaLabel10"
        Me.GunaLabel10.Size = New System.Drawing.Size(11, 15)
        Me.GunaLabel10.TabIndex = 12
        Me.GunaLabel10.Text = "-"
        '
        'GunaLabel9
        '
        Me.GunaLabel9.AutoSize = True
        Me.GunaLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GunaLabel9.Location = New System.Drawing.Point(266, 26)
        Me.GunaLabel9.Name = "GunaLabel9"
        Me.GunaLabel9.Size = New System.Drawing.Size(11, 15)
        Me.GunaLabel9.TabIndex = 12
        Me.GunaLabel9.Text = "-"
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GunaLabel8.Location = New System.Drawing.Point(185, 26)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(11, 15)
        Me.GunaLabel8.TabIndex = 12
        Me.GunaLabel8.Text = "-"
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GunaLabel7.Location = New System.Drawing.Point(104, 26)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(11, 15)
        Me.GunaLabel7.TabIndex = 12
        Me.GunaLabel7.Text = "-"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(358, 176)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(104, 20)
        Me.GunaLabel2.TabIndex = 12
        Me.GunaLabel2.Text = "SERIAL KEY"
        Me.GunaLabel2.Visible = False
        '
        'ActivationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 204)
        Me.Controls.Add(Me.GunaShadowPanel1)
        Me.Controls.Add(Me.GunaButtonActiver)
        Me.Controls.Add(Me.GunaTextBoxMessage)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.Controls.Add(Me.GunaLabel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ActivationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserForm"
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.GunaShadowPanel1.ResumeLayout(False)
        Me.GunaShadowPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabelTitre As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaTextBoxMessage As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonActiver As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaShadowPanel1 As Guna.UI.WinForms.GunaShadowPanel
    Friend WithEvents GunaTextBox5 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBox4 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBox3 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBox2 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBox1 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel10 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel9 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
End Class
