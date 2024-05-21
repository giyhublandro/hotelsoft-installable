<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CautionRemboursement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CautionRemboursement))
        Me.GunaButtonRembourser = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButtonClose = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaTextBoxCaution = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabelMontantARembourser = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxMontantARembourser = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxMotifDifference = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeCaution = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabelmOTIF = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLinePanelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaButtonRembourser
        '
        Me.GunaButtonRembourser.AnimationHoverSpeed = 0.07!
        Me.GunaButtonRembourser.AnimationSpeed = 0.03!
        Me.GunaButtonRembourser.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonRembourser.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonRembourser.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonRembourser.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonRembourser.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonRembourser.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonRembourser.ForeColor = System.Drawing.Color.White
        Me.GunaButtonRembourser.Image = Nothing
        Me.GunaButtonRembourser.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonRembourser.Location = New System.Drawing.Point(271, 125)
        Me.GunaButtonRembourser.Name = "GunaButtonRembourser"
        Me.GunaButtonRembourser.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonRembourser.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonRembourser.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonRembourser.OnHoverImage = Nothing
        Me.GunaButtonRembourser.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonRembourser.Radius = 4
        Me.GunaButtonRembourser.Size = New System.Drawing.Size(98, 34)
        Me.GunaButtonRembourser.TabIndex = 18
        Me.GunaButtonRembourser.TabStop = False
        Me.GunaButtonRembourser.Text = "Rembourser"
        Me.GunaButtonRembourser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(134, 42)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(67, 20)
        Me.GunaLabel4.TabIndex = 19
        Me.GunaLabel4.Text = "Caution :"
        '
        'GunaImageButtonClose
        '
        Me.GunaImageButtonClose.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonClose.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonClose.Image = Nothing
        Me.GunaImageButtonClose.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButtonClose.Location = New System.Drawing.Point(370, 6)
        Me.GunaImageButtonClose.Name = "GunaImageButtonClose"
        Me.GunaImageButtonClose.OnHoverImage = Nothing
        Me.GunaImageButtonClose.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButtonClose.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButtonClose.TabIndex = 9
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(68, 6)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(244, 21)
        Me.GunaLabel2.TabIndex = 13
        Me.GunaLabel2.Text = "REMBOURSEMENT DE CAUTION"
        Me.GunaLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 308)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 12)
        Me.Panel1.TabIndex = 22
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButtonClose)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton2)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabel2)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(400, 33)
        Me.GunaLinePanelTop.TabIndex = 21
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(366, 6)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 14
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
        'GunaTextBoxCaution
        '
        Me.GunaTextBoxCaution.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCaution.BaseColor = System.Drawing.Color.Pink
        Me.GunaTextBoxCaution.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxCaution.BorderSize = 1
        Me.GunaTextBoxCaution.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCaution.Enabled = False
        Me.GunaTextBoxCaution.FocusedBaseColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTextBoxCaution.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCaution.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCaution.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaTextBoxCaution.Location = New System.Drawing.Point(209, 37)
        Me.GunaTextBoxCaution.Name = "GunaTextBoxCaution"
        Me.GunaTextBoxCaution.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCaution.Radius = 5
        Me.GunaTextBoxCaution.SelectedText = ""
        Me.GunaTextBoxCaution.Size = New System.Drawing.Size(160, 32)
        Me.GunaTextBoxCaution.TabIndex = 23
        Me.GunaTextBoxCaution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaLabelMontantARembourser
        '
        Me.GunaLabelMontantARembourser.AutoSize = True
        Me.GunaLabelMontantARembourser.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelMontantARembourser.Location = New System.Drawing.Point(33, 86)
        Me.GunaLabelMontantARembourser.Name = "GunaLabelMontantARembourser"
        Me.GunaLabelMontantARembourser.Size = New System.Drawing.Size(168, 20)
        Me.GunaLabelMontantARembourser.TabIndex = 19
        Me.GunaLabelMontantARembourser.Text = "Montant à Rembourser :"
        '
        'GunaTextBoxMontantARembourser
        '
        Me.GunaTextBoxMontantARembourser.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantARembourser.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantARembourser.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxMontantARembourser.BorderSize = 1
        Me.GunaTextBoxMontantARembourser.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantARembourser.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantARembourser.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantARembourser.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantARembourser.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GunaTextBoxMontantARembourser.Location = New System.Drawing.Point(209, 81)
        Me.GunaTextBoxMontantARembourser.Name = "GunaTextBoxMontantARembourser"
        Me.GunaTextBoxMontantARembourser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantARembourser.Radius = 5
        Me.GunaTextBoxMontantARembourser.SelectedText = ""
        Me.GunaTextBoxMontantARembourser.Size = New System.Drawing.Size(160, 32)
        Me.GunaTextBoxMontantARembourser.TabIndex = 23
        Me.GunaTextBoxMontantARembourser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaTextBoxMotifDifference
        '
        Me.GunaTextBoxMotifDifference.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMotifDifference.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMotifDifference.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxMotifDifference.BorderSize = 1
        Me.GunaTextBoxMotifDifference.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMotifDifference.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMotifDifference.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMotifDifference.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMotifDifference.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaTextBoxMotifDifference.Location = New System.Drawing.Point(40, 200)
        Me.GunaTextBoxMotifDifference.Multiline = True
        Me.GunaTextBoxMotifDifference.Name = "GunaTextBoxMotifDifference"
        Me.GunaTextBoxMotifDifference.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMotifDifference.Radius = 5
        Me.GunaTextBoxMotifDifference.SelectedText = ""
        Me.GunaTextBoxMotifDifference.Size = New System.Drawing.Size(329, 98)
        Me.GunaTextBoxMotifDifference.TabIndex = 23
        Me.GunaTextBoxMotifDifference.Visible = False
        '
        'GunaTextBoxCodeCaution
        '
        Me.GunaTextBoxCodeCaution.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeCaution.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeCaution.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxCodeCaution.BorderSize = 1
        Me.GunaTextBoxCodeCaution.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeCaution.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeCaution.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeCaution.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeCaution.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaTextBoxCodeCaution.Location = New System.Drawing.Point(37, 129)
        Me.GunaTextBoxCodeCaution.Name = "GunaTextBoxCodeCaution"
        Me.GunaTextBoxCodeCaution.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeCaution.Radius = 5
        Me.GunaTextBoxCodeCaution.SelectedText = ""
        Me.GunaTextBoxCodeCaution.Size = New System.Drawing.Size(160, 30)
        Me.GunaTextBoxCodeCaution.TabIndex = 23
        Me.GunaTextBoxCodeCaution.Visible = False
        '
        'GunaLabelmOTIF
        '
        Me.GunaLabelmOTIF.AutoSize = True
        Me.GunaLabelmOTIF.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelmOTIF.Location = New System.Drawing.Point(35, 177)
        Me.GunaLabelmOTIF.Name = "GunaLabelmOTIF"
        Me.GunaLabelmOTIF.Size = New System.Drawing.Size(332, 20)
        Me.GunaLabelmOTIF.TabIndex = 19
        Me.GunaLabelmOTIF.Text = "Raison du remboursement partielle de la caution"
        Me.GunaLabelmOTIF.Visible = False
        '
        'CautionRemboursement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 320)
        Me.Controls.Add(Me.GunaTextBoxMotifDifference)
        Me.Controls.Add(Me.GunaTextBoxCodeCaution)
        Me.Controls.Add(Me.GunaTextBoxMontantARembourser)
        Me.Controls.Add(Me.GunaTextBoxCaution)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.Controls.Add(Me.GunaButtonRembourser)
        Me.Controls.Add(Me.GunaLabelmOTIF)
        Me.Controls.Add(Me.GunaLabelMontantARembourser)
        Me.Controls.Add(Me.GunaLabel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CautionRemboursement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TransfertDeClientEntreCaissierForm"
        Me.TopMost = True
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaButtonRembourser As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButtonClose As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaTextBoxCaution As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabelMontantARembourser As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxMontantARembourser As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMotifDifference As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeCaution As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabelmOTIF As Guna.UI.WinForms.GunaLabel
End Class
