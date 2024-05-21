<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransfertDeClientEntreCaissierForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransfertDeClientEntreCaissierForm))
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButtonClose = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaComboBoxUtilisateurDeCaisse = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLinePanelTop.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(290, 128)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(98, 34)
        Me.GunaButtonEnregistrer.TabIndex = 18
        Me.GunaButtonEnregistrer.TabStop = False
        Me.GunaButtonEnregistrer.Text = "Transférer"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(12, 46)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(126, 20)
        Me.GunaLabel4.TabIndex = 19
        Me.GunaLabel4.Text = "Choisir un caissier"
        '
        'GunaImageButtonClose
        '
        Me.GunaImageButtonClose.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonClose.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonClose.Image = CType(resources.GetObject("GunaImageButtonClose.Image"), System.Drawing.Image)
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
        Me.GunaLabel2.Location = New System.Drawing.Point(113, 6)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(185, 21)
        Me.GunaLabel2.TabIndex = 13
        Me.GunaLabel2.Text = "SELECTION DE CAISSIER"
        Me.GunaLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 188)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 12)
        Me.Panel1.TabIndex = 22
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
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
        'GunaComboBoxUtilisateurDeCaisse
        '
        Me.GunaComboBoxUtilisateurDeCaisse.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxUtilisateurDeCaisse.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxUtilisateurDeCaisse.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxUtilisateurDeCaisse.BorderSize = 1
        Me.GunaComboBoxUtilisateurDeCaisse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxUtilisateurDeCaisse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxUtilisateurDeCaisse.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxUtilisateurDeCaisse.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxUtilisateurDeCaisse.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxUtilisateurDeCaisse.FormattingEnabled = True
        Me.GunaComboBoxUtilisateurDeCaisse.ItemHeight = 26
        Me.GunaComboBoxUtilisateurDeCaisse.Location = New System.Drawing.Point(16, 71)
        Me.GunaComboBoxUtilisateurDeCaisse.Name = "GunaComboBoxUtilisateurDeCaisse"
        Me.GunaComboBoxUtilisateurDeCaisse.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxUtilisateurDeCaisse.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxUtilisateurDeCaisse.Radius = 5
        Me.GunaComboBoxUtilisateurDeCaisse.Size = New System.Drawing.Size(372, 32)
        Me.GunaComboBoxUtilisateurDeCaisse.TabIndex = 23
        '
        'TransfertDeClientEntreCaissierForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 200)
        Me.Controls.Add(Me.GunaComboBoxUtilisateurDeCaisse)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.Controls.Add(Me.GunaButtonEnregistrer)
        Me.Controls.Add(Me.GunaLabel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TransfertDeClientEntreCaissierForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TransfertDeClientEntreCaissierForm"
        Me.TopMost = True
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButtonClose As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaComboBoxUtilisateurDeCaisse As Guna.UI.WinForms.GunaComboBox
End Class
