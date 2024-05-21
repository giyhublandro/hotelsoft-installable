<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passwordVerifivationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(passwordVerifivationForm))
        Me.GunaLabelGestUsers = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxPasswordVerification = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaTextBoxApresTentativeEncaissemtn = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelNomAuth = New Guna.UI.WinForms.GunaLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GunaTextBoxMontantQueLonVeutRegler = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLinePanelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLabelGestUsers
        '
        Me.GunaLabelGestUsers.AutoSize = True
        Me.GunaLabelGestUsers.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestUsers.Location = New System.Drawing.Point(73, -103)
        Me.GunaLabelGestUsers.Name = "GunaLabelGestUsers"
        Me.GunaLabelGestUsers.Size = New System.Drawing.Size(228, 21)
        Me.GunaLabelGestUsers.TabIndex = 18
        Me.GunaLabelGestUsers.Text = "Changement du Mot de Passe"
        Me.GunaLabelGestUsers.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaTextBoxPasswordVerification
        '
        Me.GunaTextBoxPasswordVerification.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPasswordVerification.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPasswordVerification.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxPasswordVerification.BorderSize = 1
        Me.GunaTextBoxPasswordVerification.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPasswordVerification.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPasswordVerification.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPasswordVerification.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPasswordVerification.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxPasswordVerification.Location = New System.Drawing.Point(12, 70)
        Me.GunaTextBoxPasswordVerification.Name = "GunaTextBoxPasswordVerification"
        Me.GunaTextBoxPasswordVerification.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.GunaTextBoxPasswordVerification.Radius = 5
        Me.GunaTextBoxPasswordVerification.SelectedText = ""
        Me.GunaTextBoxPasswordVerification.Size = New System.Drawing.Size(256, 36)
        Me.GunaTextBoxPasswordVerification.TabIndex = 14
        Me.GunaTextBoxPasswordVerification.UseSystemPasswordChar = True
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
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(290, 72)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(98, 34)
        Me.GunaButtonEnregistrer.TabIndex = 15
        Me.GunaButtonEnregistrer.TabStop = False
        Me.GunaButtonEnregistrer.Text = "Ouvrir"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(12, 47)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(96, 20)
        Me.GunaLabel4.TabIndex = 16
        Me.GunaLabel4.Text = "Mot de Passe"
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(401, -127)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 17
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaTextBoxApresTentativeEncaissemtn)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton2)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelNomAuth)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(400, 33)
        Me.GunaLinePanelTop.TabIndex = 19
        '
        'GunaTextBoxApresTentativeEncaissemtn
        '
        Me.GunaTextBoxApresTentativeEncaissemtn.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxApresTentativeEncaissemtn.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxApresTentativeEncaissemtn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxApresTentativeEncaissemtn.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxApresTentativeEncaissemtn.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxApresTentativeEncaissemtn.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxApresTentativeEncaissemtn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxApresTentativeEncaissemtn.Location = New System.Drawing.Point(321, 3)
        Me.GunaTextBoxApresTentativeEncaissemtn.Name = "GunaTextBoxApresTentativeEncaissemtn"
        Me.GunaTextBoxApresTentativeEncaissemtn.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxApresTentativeEncaissemtn.SelectedText = ""
        Me.GunaTextBoxApresTentativeEncaissemtn.Size = New System.Drawing.Size(34, 26)
        Me.GunaTextBoxApresTentativeEncaissemtn.TabIndex = 21
        Me.GunaTextBoxApresTentativeEncaissemtn.Text = "0"
        Me.GunaTextBoxApresTentativeEncaissemtn.Visible = False
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(370, 6)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 9
        '
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = Nothing
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(361, 6)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 8
        '
        'GunaLabelNomAuth
        '
        Me.GunaLabelNomAuth.AutoSize = True
        Me.GunaLabelNomAuth.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelNomAuth.Location = New System.Drawing.Point(131, 5)
        Me.GunaLabelNomAuth.Name = "GunaLabelNomAuth"
        Me.GunaLabelNomAuth.Size = New System.Drawing.Size(158, 21)
        Me.GunaLabelNomAuth.TabIndex = 13
        Me.GunaLabelNomAuth.Text = "AUTHENTIFICATION"
        Me.GunaLabelNomAuth.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 139)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 12)
        Me.Panel1.TabIndex = 20
        '
        'GunaTextBoxMontantQueLonVeutRegler
        '
        Me.GunaTextBoxMontantQueLonVeutRegler.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantQueLonVeutRegler.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxMontantQueLonVeutRegler.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantQueLonVeutRegler.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantQueLonVeutRegler.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantQueLonVeutRegler.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantQueLonVeutRegler.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxMontantQueLonVeutRegler.Location = New System.Drawing.Point(290, 112)
        Me.GunaTextBoxMontantQueLonVeutRegler.Name = "GunaTextBoxMontantQueLonVeutRegler"
        Me.GunaTextBoxMontantQueLonVeutRegler.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantQueLonVeutRegler.SelectedText = ""
        Me.GunaTextBoxMontantQueLonVeutRegler.Size = New System.Drawing.Size(98, 26)
        Me.GunaTextBoxMontantQueLonVeutRegler.TabIndex = 21
        Me.GunaTextBoxMontantQueLonVeutRegler.Text = "0"
        Me.GunaTextBoxMontantQueLonVeutRegler.Visible = False
        '
        'passwordVerifivationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 150)
        Me.Controls.Add(Me.GunaTextBoxMontantQueLonVeutRegler)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.Controls.Add(Me.GunaImageButton4)
        Me.Controls.Add(Me.GunaLabelGestUsers)
        Me.Controls.Add(Me.GunaTextBoxPasswordVerification)
        Me.Controls.Add(Me.GunaButtonEnregistrer)
        Me.Controls.Add(Me.GunaLabel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "passwordVerifivationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "passwordVerifivationForm"
        Me.TopMost = True
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelGestUsers As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxPasswordVerification As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelNomAuth As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GunaTextBoxApresTentativeEncaissemtn As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantQueLonVeutRegler As Guna.UI.WinForms.GunaTextBox
End Class
