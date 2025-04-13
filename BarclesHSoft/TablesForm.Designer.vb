<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TablesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TablesForm))
        Me.GunaPanelTopPanel = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabelDateDeTravail = New Guna.UI.WinForms.GunaLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageManager = New System.Windows.Forms.TabPage()
        Me.GunaPanelTopPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanelTopPanel
        '
        Me.GunaPanelTopPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaLabelDateDeTravail)
        Me.GunaPanelTopPanel.Controls.Add(Me.PictureBox2)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaLabel1)
        Me.GunaPanelTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanelTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanelTopPanel.Name = "GunaPanelTopPanel"
        Me.GunaPanelTopPanel.Size = New System.Drawing.Size(1121, 25)
        Me.GunaPanelTopPanel.TabIndex = 3
        '
        'GunaLabelDateDeTravail
        '
        Me.GunaLabelDateDeTravail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLabelDateDeTravail.AutoSize = True
        Me.GunaLabelDateDeTravail.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabelDateDeTravail.ForeColor = System.Drawing.Color.White
        Me.GunaLabelDateDeTravail.Location = New System.Drawing.Point(499, 2)
        Me.GunaLabelDateDeTravail.Name = "GunaLabelDateDeTravail"
        Me.GunaLabelDateDeTravail.Size = New System.Drawing.Size(57, 19)
        Me.GunaLabelDateDeTravail.TabIndex = 77
        Me.GunaLabelDateDeTravail.Text = "TABLES"
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
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = CType(resources.GetObject("GunaImageButton2.Image"), System.Drawing.Image)
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(1067, 3)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 3
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1091, 3)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2288, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageManager)
        Me.TabControl1.Location = New System.Drawing.Point(3, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1115, 639)
        Me.TabControl1.TabIndex = 5
        '
        'TabPageManager
        '
        Me.TabPageManager.BackColor = System.Drawing.Color.Black
        Me.TabPageManager.Location = New System.Drawing.Point(4, 22)
        Me.TabPageManager.Name = "TabPageManager"
        Me.TabPageManager.Size = New System.Drawing.Size(1107, 613)
        Me.TabPageManager.TabIndex = 1
        Me.TabPageManager.Text = "Manager"
        '
        'TablesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 670)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GunaPanelTopPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TablesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TablesForm"
        Me.GunaPanelTopPanel.ResumeLayout(False)
        Me.GunaPanelTopPanel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaPanelTopPanel As Guna.UI.WinForms.GunaPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelDateDeTravail As Guna.UI.WinForms.GunaLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageManager As TabPage
End Class
