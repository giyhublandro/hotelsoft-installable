<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AjouterConsigneForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjouterConsigneForm))
        Me.GunaTextBoxConsigne = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonLectureDeCarte = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonAjouterConsigne = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabelNotification = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextMessage = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaLabelTitreDeLaFenetre = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaTextBoxConsigne
        '
        Me.GunaTextBoxConsigne.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxConsigne.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxConsigne.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxConsigne.BorderSize = 1
        Me.GunaTextBoxConsigne.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxConsigne.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxConsigne.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxConsigne.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxConsigne.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxConsigne.Location = New System.Drawing.Point(12, 58)
        Me.GunaTextBoxConsigne.Multiline = True
        Me.GunaTextBoxConsigne.Name = "GunaTextBoxConsigne"
        Me.GunaTextBoxConsigne.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxConsigne.Radius = 10
        Me.GunaTextBoxConsigne.SelectedText = ""
        Me.GunaTextBoxConsigne.Size = New System.Drawing.Size(460, 192)
        Me.GunaTextBoxConsigne.TabIndex = 0
        '
        'GunaButtonLectureDeCarte
        '
        Me.GunaButtonLectureDeCarte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonLectureDeCarte.AnimationHoverSpeed = 0.07!
        Me.GunaButtonLectureDeCarte.AnimationSpeed = 0.03!
        Me.GunaButtonLectureDeCarte.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonLectureDeCarte.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonLectureDeCarte.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonLectureDeCarte.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonLectureDeCarte.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonLectureDeCarte.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonLectureDeCarte.ForeColor = System.Drawing.Color.White
        Me.GunaButtonLectureDeCarte.Image = Nothing
        Me.GunaButtonLectureDeCarte.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonLectureDeCarte.Location = New System.Drawing.Point(12, 260)
        Me.GunaButtonLectureDeCarte.Name = "GunaButtonLectureDeCarte"
        Me.GunaButtonLectureDeCarte.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonLectureDeCarte.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonLectureDeCarte.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonLectureDeCarte.OnHoverImage = Nothing
        Me.GunaButtonLectureDeCarte.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonLectureDeCarte.Radius = 5
        Me.GunaButtonLectureDeCarte.Size = New System.Drawing.Size(80, 31)
        Me.GunaButtonLectureDeCarte.TabIndex = 202
        Me.GunaButtonLectureDeCarte.Text = "Fermer"
        Me.GunaButtonLectureDeCarte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonAjouterConsigne
        '
        Me.GunaButtonAjouterConsigne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonAjouterConsigne.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAjouterConsigne.AnimationSpeed = 0.03!
        Me.GunaButtonAjouterConsigne.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAjouterConsigne.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAjouterConsigne.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterConsigne.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAjouterConsigne.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAjouterConsigne.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAjouterConsigne.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouterConsigne.Image = Nothing
        Me.GunaButtonAjouterConsigne.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAjouterConsigne.Location = New System.Drawing.Point(392, 260)
        Me.GunaButtonAjouterConsigne.Name = "GunaButtonAjouterConsigne"
        Me.GunaButtonAjouterConsigne.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAjouterConsigne.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterConsigne.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouterConsigne.OnHoverImage = Nothing
        Me.GunaButtonAjouterConsigne.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterConsigne.Radius = 5
        Me.GunaButtonAjouterConsigne.Size = New System.Drawing.Size(80, 31)
        Me.GunaButtonAjouterConsigne.TabIndex = 202
        Me.GunaButtonAjouterConsigne.Text = "Ajouter"
        Me.GunaButtonAjouterConsigne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(10, 32)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(119, 19)
        Me.GunaLabel1.TabIndex = 203
        Me.GunaLabel1.Text = "Saisir la consigne :"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 22)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 25
        Me.PictureBox2.TabStop = False
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(456, 3)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 2
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaLabelNotification)
        Me.GunaPanel1.Controls.Add(Me.GunaTextMessage)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelTitreDeLaFenetre)
        Me.GunaPanel1.Controls.Add(Me.PictureBox2)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel2)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(484, 25)
        Me.GunaPanel1.TabIndex = 204
        '
        'GunaLabelNotification
        '
        Me.GunaLabelNotification.AutoSize = True
        Me.GunaLabelNotification.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabelNotification.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelNotification.ForeColor = System.Drawing.Color.White
        Me.GunaLabelNotification.Location = New System.Drawing.Point(917, 0)
        Me.GunaLabelNotification.Name = "GunaLabelNotification"
        Me.GunaLabelNotification.Size = New System.Drawing.Size(30, 20)
        Me.GunaLabelNotification.TabIndex = 30
        Me.GunaLabelNotification.Text = "(0)"
        '
        'GunaTextMessage
        '
        Me.GunaTextMessage.AnimationHoverSpeed = 0.07!
        Me.GunaTextMessage.AnimationSpeed = 0.03!
        Me.GunaTextMessage.BaseColor = System.Drawing.Color.Transparent
        Me.GunaTextMessage.BorderColor = System.Drawing.Color.Black
        Me.GunaTextMessage.CheckedBaseColor = System.Drawing.Color.Gray
        Me.GunaTextMessage.CheckedBorderColor = System.Drawing.Color.Black
        Me.GunaTextMessage.CheckedForeColor = System.Drawing.Color.White
        Me.GunaTextMessage.CheckedImage = CType(resources.GetObject("GunaTextMessage.CheckedImage"), System.Drawing.Image)
        Me.GunaTextMessage.CheckedLineColor = System.Drawing.Color.DimGray
        Me.GunaTextMessage.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaTextMessage.FocusedColor = System.Drawing.Color.Empty
        Me.GunaTextMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextMessage.ForeColor = System.Drawing.Color.White
        Me.GunaTextMessage.Image = CType(resources.GetObject("GunaTextMessage.Image"), System.Drawing.Image)
        Me.GunaTextMessage.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaTextMessage.LineColor = System.Drawing.Color.Transparent
        Me.GunaTextMessage.Location = New System.Drawing.Point(886, 4)
        Me.GunaTextMessage.Name = "GunaTextMessage"
        Me.GunaTextMessage.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.GunaTextMessage.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaTextMessage.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaTextMessage.OnHoverImage = Nothing
        Me.GunaTextMessage.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaTextMessage.OnPressedColor = System.Drawing.Color.Black
        Me.GunaTextMessage.Size = New System.Drawing.Size(40, 19)
        Me.GunaTextMessage.TabIndex = 29
        '
        'GunaLabelTitreDeLaFenetre
        '
        Me.GunaLabelTitreDeLaFenetre.AutoSize = True
        Me.GunaLabelTitreDeLaFenetre.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelTitreDeLaFenetre.ForeColor = System.Drawing.Color.White
        Me.GunaLabelTitreDeLaFenetre.Location = New System.Drawing.Point(541, -2)
        Me.GunaLabelTitreDeLaFenetre.Name = "GunaLabelTitreDeLaFenetre"
        Me.GunaLabelTitreDeLaFenetre.Size = New System.Drawing.Size(114, 25)
        Me.GunaLabelTitreDeLaFenetre.TabIndex = 26
        Me.GunaLabelTitreDeLaFenetre.Text = "RECEPTION"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.ForeColor = System.Drawing.Color.White
        Me.GunaLabel2.Location = New System.Drawing.Point(1651, -2)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel2.TabIndex = 1
        Me.GunaLabel2.Text = "X"
        '
        'AjouterConsigneForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 300)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaButtonAjouterConsigne)
        Me.Controls.Add(Me.GunaButtonLectureDeCarte)
        Me.Controls.Add(Me.GunaTextBoxConsigne)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AjouterConsigneForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AjouterConsigneForm"
        Me.TopMost = True
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaTextBoxConsigne As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonLectureDeCarte As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonAjouterConsigne As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabelNotification As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextMessage As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents GunaLabelTitreDeLaFenetre As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
End Class
