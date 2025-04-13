<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FournisseurForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FournisseurForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageDescription = New System.Windows.Forms.TabPage()
        Me.GunaCheckBoxBlanchisseur = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaTextBoxRaisonSociale = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBox6 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBox5 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBox10 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBox9 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxMail = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxfax = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel12 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxPhone = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxAdresse = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel10 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxPourcentageRemise = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxCodeFournisseur = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel11 = New Guna.UI.WinForms.GunaLabel()
        Me.TabPageListe = New System.Windows.Forms.TabPage()
        Me.GunaDataGridViewFournisseurs = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaButtonAfficher = New Guna.UI.WinForms.GunaButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GunaPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageDescription.SuspendLayout()
        Me.TabPageListe.SuspendLayout()
        CType(Me.GunaDataGridViewFournisseurs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(934, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = CType(resources.GetObject("GunaImageButton4.Image"), System.Drawing.Image)
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(899, 2)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 8
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = Nothing
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(900, 2)
        Me.GunaImageButton3.Name = "GunaImageButton3"
        Me.GunaImageButton3.OnHoverImage = Nothing
        Me.GunaImageButton3.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton3.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton3.TabIndex = 7
        '
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = Nothing
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(900, 3)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 6
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(377, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(124, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "FOURNISSEURS"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(899, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2101, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
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
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(152, 601)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 37)
        Me.GunaButton1.TabIndex = 3
        Me.GunaButton1.Text = "Annuler"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(727, 493)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(121, 37)
        Me.GunaButtonEnregistrer.TabIndex = 3
        Me.GunaButtonEnregistrer.Text = "Enregistrer"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageDescription)
        Me.TabControl1.Controls.Add(Me.TabPageListe)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(910, 565)
        Me.TabControl1.TabIndex = 25
        '
        'TabPageDescription
        '
        Me.TabPageDescription.BackColor = System.Drawing.Color.Wheat
        Me.TabPageDescription.Controls.Add(Me.GunaCheckBoxBlanchisseur)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxRaisonSociale)
        Me.TabPageDescription.Controls.Add(Me.GunaButtonEnregistrer)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel4)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBox6)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBox5)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBox10)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBox9)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxMail)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxfax)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel12)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxPhone)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel7)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel3)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel8)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel6)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel5)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxAdresse)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel10)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxPourcentageRemise)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel2)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxCodeFournisseur)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel11)
        Me.TabPageDescription.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDescription.Name = "TabPageDescription"
        Me.TabPageDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDescription.Size = New System.Drawing.Size(902, 536)
        Me.TabPageDescription.TabIndex = 0
        Me.TabPageDescription.Text = "Description"
        '
        'GunaCheckBoxBlanchisseur
        '
        Me.GunaCheckBoxBlanchisseur.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxBlanchisseur.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxBlanchisseur.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxBlanchisseur.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxBlanchisseur.Location = New System.Drawing.Point(710, 115)
        Me.GunaCheckBoxBlanchisseur.Name = "GunaCheckBoxBlanchisseur"
        Me.GunaCheckBoxBlanchisseur.Size = New System.Drawing.Size(118, 20)
        Me.GunaCheckBoxBlanchisseur.TabIndex = 18
        Me.GunaCheckBoxBlanchisseur.Text = "BLANCHISSEUR"
        '
        'GunaTextBoxRaisonSociale
        '
        Me.GunaTextBoxRaisonSociale.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxRaisonSociale.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRaisonSociale.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxRaisonSociale.BorderSize = 1
        Me.GunaTextBoxRaisonSociale.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxRaisonSociale.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxRaisonSociale.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRaisonSociale.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxRaisonSociale.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxRaisonSociale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxRaisonSociale.Location = New System.Drawing.Point(53, 109)
        Me.GunaTextBoxRaisonSociale.Name = "GunaTextBoxRaisonSociale"
        Me.GunaTextBoxRaisonSociale.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxRaisonSociale.Radius = 4
        Me.GunaTextBoxRaisonSociale.SelectedText = ""
        Me.GunaTextBoxRaisonSociale.Size = New System.Drawing.Size(630, 34)
        Me.GunaTextBoxRaisonSociale.TabIndex = 8
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(50, 91)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(91, 17)
        Me.GunaLabel4.TabIndex = 2
        Me.GunaLabel4.Text = "Raison sociale"
        '
        'GunaTextBox6
        '
        Me.GunaTextBox6.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox6.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox6.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBox6.BorderSize = 1
        Me.GunaTextBox6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox6.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox6.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox6.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox6.Location = New System.Drawing.Point(220, 340)
        Me.GunaTextBox6.Name = "GunaTextBox6"
        Me.GunaTextBox6.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox6.Radius = 4
        Me.GunaTextBox6.SelectedText = ""
        Me.GunaTextBox6.Size = New System.Drawing.Size(628, 34)
        Me.GunaTextBox6.TabIndex = 11
        Me.GunaTextBox6.Visible = False
        '
        'GunaTextBox5
        '
        Me.GunaTextBox5.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox5.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox5.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBox5.BorderSize = 1
        Me.GunaTextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox5.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox5.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox5.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox5.Location = New System.Drawing.Point(53, 340)
        Me.GunaTextBox5.Name = "GunaTextBox5"
        Me.GunaTextBox5.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox5.Radius = 4
        Me.GunaTextBox5.SelectedText = ""
        Me.GunaTextBox5.Size = New System.Drawing.Size(161, 34)
        Me.GunaTextBox5.TabIndex = 12
        Me.GunaTextBox5.Visible = False
        '
        'GunaTextBox10
        '
        Me.GunaTextBox10.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox10.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox10.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBox10.BorderSize = 1
        Me.GunaTextBox10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox10.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox10.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox10.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox10.Location = New System.Drawing.Point(220, 280)
        Me.GunaTextBox10.Name = "GunaTextBox10"
        Me.GunaTextBox10.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox10.Radius = 4
        Me.GunaTextBox10.SelectedText = ""
        Me.GunaTextBox10.Size = New System.Drawing.Size(628, 34)
        Me.GunaTextBox10.TabIndex = 11
        '
        'GunaTextBox9
        '
        Me.GunaTextBox9.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBox9.BaseColor = System.Drawing.Color.White
        Me.GunaTextBox9.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBox9.BorderSize = 1
        Me.GunaTextBox9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBox9.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBox9.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBox9.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBox9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBox9.Location = New System.Drawing.Point(53, 280)
        Me.GunaTextBox9.Name = "GunaTextBox9"
        Me.GunaTextBox9.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBox9.Radius = 4
        Me.GunaTextBox9.SelectedText = ""
        Me.GunaTextBox9.Size = New System.Drawing.Size(161, 34)
        Me.GunaTextBox9.TabIndex = 12
        '
        'GunaTextBoxMail
        '
        Me.GunaTextBoxMail.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMail.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMail.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMail.BorderSize = 1
        Me.GunaTextBoxMail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMail.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMail.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMail.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxMail.Location = New System.Drawing.Point(603, 219)
        Me.GunaTextBoxMail.Name = "GunaTextBoxMail"
        Me.GunaTextBoxMail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMail.Radius = 4
        Me.GunaTextBoxMail.SelectedText = ""
        Me.GunaTextBoxMail.Size = New System.Drawing.Size(245, 34)
        Me.GunaTextBoxMail.TabIndex = 14
        '
        'GunaTextBoxfax
        '
        Me.GunaTextBoxfax.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxfax.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxfax.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxfax.BorderSize = 1
        Me.GunaTextBoxfax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxfax.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxfax.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxfax.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxfax.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxfax.Location = New System.Drawing.Point(329, 219)
        Me.GunaTextBoxfax.Name = "GunaTextBoxfax"
        Me.GunaTextBoxfax.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxfax.Radius = 4
        Me.GunaTextBoxfax.SelectedText = ""
        Me.GunaTextBoxfax.Size = New System.Drawing.Size(245, 34)
        Me.GunaTextBoxfax.TabIndex = 14
        '
        'GunaLabel12
        '
        Me.GunaLabel12.AutoSize = True
        Me.GunaLabel12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel12.Location = New System.Drawing.Point(600, 199)
        Me.GunaLabel12.Name = "GunaLabel12"
        Me.GunaLabel12.Size = New System.Drawing.Size(45, 17)
        Me.GunaLabel12.TabIndex = 5
        Me.GunaLabel12.Text = "E-Mail"
        '
        'GunaTextBoxPhone
        '
        Me.GunaTextBoxPhone.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPhone.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPhone.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxPhone.BorderSize = 1
        Me.GunaTextBoxPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPhone.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPhone.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPhone.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxPhone.Location = New System.Drawing.Point(53, 219)
        Me.GunaTextBoxPhone.Name = "GunaTextBoxPhone"
        Me.GunaTextBoxPhone.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPhone.Radius = 4
        Me.GunaTextBoxPhone.SelectedText = ""
        Me.GunaTextBoxPhone.Size = New System.Drawing.Size(245, 34)
        Me.GunaTextBoxPhone.TabIndex = 14
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel7.Location = New System.Drawing.Point(50, 320)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(102, 17)
        Me.GunaLabel7.TabIndex = 4
        Me.GunaLabel7.Text = "Compte collectif"
        Me.GunaLabel7.Visible = False
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(326, 199)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(27, 17)
        Me.GunaLabel3.TabIndex = 5
        Me.GunaLabel3.Text = "Fax"
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel8.Location = New System.Drawing.Point(220, 263)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(46, 17)
        Me.GunaLabel8.TabIndex = 4
        Me.GunaLabel8.Text = "Intitulé"
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.Location = New System.Drawing.Point(50, 260)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(104, 17)
        Me.GunaLabel6.TabIndex = 4
        Me.GunaLabel6.Text = "Numéro compte"
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(50, 199)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(68, 17)
        Me.GunaLabel5.TabIndex = 5
        Me.GunaLabel5.Text = "Téléphone"
        '
        'GunaTextBoxAdresse
        '
        Me.GunaTextBoxAdresse.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAdresse.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdresse.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxAdresse.BorderSize = 1
        Me.GunaTextBoxAdresse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxAdresse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAdresse.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdresse.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAdresse.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAdresse.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxAdresse.Location = New System.Drawing.Point(53, 165)
        Me.GunaTextBoxAdresse.Name = "GunaTextBoxAdresse"
        Me.GunaTextBoxAdresse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAdresse.Radius = 4
        Me.GunaTextBoxAdresse.SelectedText = ""
        Me.GunaTextBoxAdresse.Size = New System.Drawing.Size(795, 34)
        Me.GunaTextBoxAdresse.TabIndex = 16
        '
        'GunaLabel10
        '
        Me.GunaLabel10.AutoSize = True
        Me.GunaLabel10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel10.Location = New System.Drawing.Point(50, 145)
        Me.GunaLabel10.Name = "GunaLabel10"
        Me.GunaLabel10.Size = New System.Drawing.Size(55, 17)
        Me.GunaLabel10.TabIndex = 6
        Me.GunaLabel10.Text = "Adresse"
        '
        'GunaTextBoxPourcentageRemise
        '
        Me.GunaTextBoxPourcentageRemise.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPourcentageRemise.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPourcentageRemise.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxPourcentageRemise.BorderSize = 1
        Me.GunaTextBoxPourcentageRemise.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPourcentageRemise.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPourcentageRemise.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPourcentageRemise.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPourcentageRemise.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxPourcentageRemise.Location = New System.Drawing.Point(217, 55)
        Me.GunaTextBoxPourcentageRemise.Name = "GunaTextBoxPourcentageRemise"
        Me.GunaTextBoxPourcentageRemise.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPourcentageRemise.Radius = 4
        Me.GunaTextBoxPourcentageRemise.SelectedText = ""
        Me.GunaTextBoxPourcentageRemise.Size = New System.Drawing.Size(288, 34)
        Me.GunaTextBoxPourcentageRemise.TabIndex = 17
        Me.GunaTextBoxPourcentageRemise.Visible = False
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(214, 35)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(62, 17)
        Me.GunaLabel2.TabIndex = 7
        Me.GunaLabel2.Text = "% remise"
        Me.GunaLabel2.Visible = False
        '
        'GunaTextBoxCodeFournisseur
        '
        Me.GunaTextBoxCodeFournisseur.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeFournisseur.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeFournisseur.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeFournisseur.BorderSize = 1
        Me.GunaTextBoxCodeFournisseur.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeFournisseur.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeFournisseur.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeFournisseur.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeFournisseur.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxCodeFournisseur.Location = New System.Drawing.Point(53, 55)
        Me.GunaTextBoxCodeFournisseur.Name = "GunaTextBoxCodeFournisseur"
        Me.GunaTextBoxCodeFournisseur.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeFournisseur.Radius = 4
        Me.GunaTextBoxCodeFournisseur.SelectedText = ""
        Me.GunaTextBoxCodeFournisseur.Size = New System.Drawing.Size(142, 34)
        Me.GunaTextBoxCodeFournisseur.TabIndex = 17
        Me.GunaTextBoxCodeFournisseur.Visible = False
        '
        'GunaLabel11
        '
        Me.GunaLabel11.AutoSize = True
        Me.GunaLabel11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel11.Location = New System.Drawing.Point(50, 35)
        Me.GunaLabel11.Name = "GunaLabel11"
        Me.GunaLabel11.Size = New System.Drawing.Size(39, 17)
        Me.GunaLabel11.TabIndex = 7
        Me.GunaLabel11.Text = "Code"
        Me.GunaLabel11.Visible = False
        '
        'TabPageListe
        '
        Me.TabPageListe.Controls.Add(Me.GunaDataGridViewFournisseurs)
        Me.TabPageListe.Controls.Add(Me.GunaButtonAfficher)
        Me.TabPageListe.Location = New System.Drawing.Point(4, 25)
        Me.TabPageListe.Name = "TabPageListe"
        Me.TabPageListe.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageListe.Size = New System.Drawing.Size(902, 536)
        Me.TabPageListe.TabIndex = 1
        Me.TabPageListe.Text = "Liste"
        Me.TabPageListe.UseVisualStyleBackColor = True
        '
        'GunaDataGridViewFournisseurs
        '
        Me.GunaDataGridViewFournisseurs.AllowUserToAddRows = False
        Me.GunaDataGridViewFournisseurs.AllowUserToDeleteRows = False
        Me.GunaDataGridViewFournisseurs.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewFournisseurs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewFournisseurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GunaDataGridViewFournisseurs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GunaDataGridViewFournisseurs.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewFournisseurs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewFournisseurs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewFournisseurs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewFournisseurs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewFournisseurs.ColumnHeadersHeight = 25
        Me.GunaDataGridViewFournisseurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewFournisseurs.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewFournisseurs.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewFournisseurs.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewFournisseurs.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewFournisseurs.Location = New System.Drawing.Point(18, 74)
        Me.GunaDataGridViewFournisseurs.Name = "GunaDataGridViewFournisseurs"
        Me.GunaDataGridViewFournisseurs.ReadOnly = True
        Me.GunaDataGridViewFournisseurs.RowHeadersVisible = False
        Me.GunaDataGridViewFournisseurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewFournisseurs.Size = New System.Drawing.Size(868, 443)
        Me.GunaDataGridViewFournisseurs.TabIndex = 4
        Me.GunaDataGridViewFournisseurs.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewFournisseurs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewFournisseurs.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewFournisseurs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewFournisseurs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewFournisseurs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewFournisseurs.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewFournisseurs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewFournisseurs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewFournisseurs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewFournisseurs.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewFournisseurs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewFournisseurs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewFournisseurs.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewFournisseurs.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewFournisseurs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewFournisseurs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewFournisseurs.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewFournisseurs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewFournisseurs.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewFournisseurs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewFournisseurs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaButtonAfficher
        '
        Me.GunaButtonAfficher.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAfficher.AnimationSpeed = 0.03!
        Me.GunaButtonAfficher.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAfficher.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAfficher.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAfficher.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAfficher.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAfficher.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficher.Image = Nothing
        Me.GunaButtonAfficher.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAfficher.Location = New System.Drawing.Point(776, 22)
        Me.GunaButtonAfficher.Name = "GunaButtonAfficher"
        Me.GunaButtonAfficher.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAfficher.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficher.OnHoverImage = Nothing
        Me.GunaButtonAfficher.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.Radius = 4
        Me.GunaButtonAfficher.Size = New System.Drawing.Size(110, 37)
        Me.GunaButtonAfficher.TabIndex = 3
        Me.GunaButtonAfficher.Text = "Afficher"
        Me.GunaButtonAfficher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupprimerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(130, 26)
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'FournisseurForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 650)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FournisseurForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageDescription.ResumeLayout(False)
        Me.TabPageDescription.PerformLayout()
        Me.TabPageListe.ResumeLayout(False)
        CType(Me.GunaDataGridViewFournisseurs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageDescription As TabPage
    Friend WithEvents TabPageListe As TabPage
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaTextBoxRaisonSociale As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBox10 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBox9 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxPhone As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxAdresse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel10 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxCodeFournisseur As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel11 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBox6 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBox5 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMail As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxfax As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel12 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxPourcentageRemise As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonAfficher As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDataGridViewFournisseurs As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaCheckBoxBlanchisseur As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SupprimerToolStripMenuItem As ToolStripMenuItem
End Class
