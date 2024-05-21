<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneralAccountForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralAccountForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageDescription = New System.Windows.Forms.TabPage()
        Me.NumericUpDownDelaiDePaiement = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel37 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaCheckBoxActivationDesactivationDuCompte = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaTextBoxAdresseDeFacturation = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxContactPourPaiement = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxPersonneAContacter = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxMontantPlafondsDuCompte = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel36 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel35 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel22 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel32 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel31 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxNumCompte = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonAjouterCompte = New Guna.UI.WinForms.GunaButton()
        Me.GunaComboBoxSensSolde = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaComboBoxTypeCompte = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBoxIntituleCompte = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.TabPageListe = New System.Windows.Forms.TabPage()
        Me.GunaButtonAfficher = New Guna.UI.WinForms.GunaButton()
        Me.DataGridViewListeDesComptes = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageDescription.SuspendLayout()
        Me.TabPageListe.SuspendLayout()
        CType(Me.DataGridViewListeDesComptes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(950, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(281, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(351, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "Création et mise à jours des comptes généraux"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(915, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2117, -2)
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageDescription)
        Me.TabControl1.Controls.Add(Me.TabPageListe)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(930, 657)
        Me.TabControl1.TabIndex = 2
        '
        'TabPageDescription
        '
        Me.TabPageDescription.Controls.Add(Me.NumericUpDownDelaiDePaiement)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel37)
        Me.TabPageDescription.Controls.Add(Me.GunaCheckBoxActivationDesactivationDuCompte)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxAdresseDeFacturation)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxContactPourPaiement)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxPersonneAContacter)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxMontantPlafondsDuCompte)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel36)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel35)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel22)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel32)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel31)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxNumCompte)
        Me.TabPageDescription.Controls.Add(Me.GunaButtonAjouterCompte)
        Me.TabPageDescription.Controls.Add(Me.GunaComboBoxSensSolde)
        Me.TabPageDescription.Controls.Add(Me.GunaButton1)
        Me.TabPageDescription.Controls.Add(Me.GunaComboBoxTypeCompte)
        Me.TabPageDescription.Controls.Add(Me.GunaTextBoxIntituleCompte)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel5)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel4)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel3)
        Me.TabPageDescription.Controls.Add(Me.GunaLabel2)
        Me.TabPageDescription.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDescription.Name = "TabPageDescription"
        Me.TabPageDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDescription.Size = New System.Drawing.Size(922, 628)
        Me.TabPageDescription.TabIndex = 0
        Me.TabPageDescription.Text = "Description"
        Me.TabPageDescription.UseVisualStyleBackColor = True
        '
        'NumericUpDownDelaiDePaiement
        '
        Me.NumericUpDownDelaiDePaiement.BackColor = System.Drawing.Color.Transparent
        Me.NumericUpDownDelaiDePaiement.BaseColor = System.Drawing.Color.White
        Me.NumericUpDownDelaiDePaiement.BorderColor = System.Drawing.Color.Gainsboro
        Me.NumericUpDownDelaiDePaiement.BorderSize = 1
        Me.NumericUpDownDelaiDePaiement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NumericUpDownDelaiDePaiement.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NumericUpDownDelaiDePaiement.FocusedBaseColor = System.Drawing.Color.White
        Me.NumericUpDownDelaiDePaiement.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NumericUpDownDelaiDePaiement.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.NumericUpDownDelaiDePaiement.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDownDelaiDePaiement.Location = New System.Drawing.Point(582, 395)
        Me.NumericUpDownDelaiDePaiement.Name = "NumericUpDownDelaiDePaiement"
        Me.NumericUpDownDelaiDePaiement.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.NumericUpDownDelaiDePaiement.Radius = 5
        Me.NumericUpDownDelaiDePaiement.SelectedText = ""
        Me.NumericUpDownDelaiDePaiement.Size = New System.Drawing.Size(137, 30)
        Me.NumericUpDownDelaiDePaiement.TabIndex = 55
        Me.NumericUpDownDelaiDePaiement.Text = "0"
        Me.NumericUpDownDelaiDePaiement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel37
        '
        Me.GunaLabel37.AutoSize = True
        Me.GunaLabel37.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel37.Location = New System.Drawing.Point(579, 374)
        Me.GunaLabel37.Name = "GunaLabel37"
        Me.GunaLabel37.Size = New System.Drawing.Size(156, 17)
        Me.GunaLabel37.TabIndex = 54
        Me.GunaLabel37.Text = "Délai de Paiement (Jours)"
        '
        'GunaCheckBoxActivationDesactivationDuCompte
        '
        Me.GunaCheckBoxActivationDesactivationDuCompte.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxActivationDesactivationDuCompte.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxActivationDesactivationDuCompte.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxActivationDesactivationDuCompte.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxActivationDesactivationDuCompte.Location = New System.Drawing.Point(653, 270)
        Me.GunaCheckBoxActivationDesactivationDuCompte.Name = "GunaCheckBoxActivationDesactivationDuCompte"
        Me.GunaCheckBoxActivationDesactivationDuCompte.Size = New System.Drawing.Size(50, 20)
        Me.GunaCheckBoxActivationDesactivationDuCompte.TabIndex = 53
        Me.GunaCheckBoxActivationDesactivationDuCompte.Text = "OUI"
        '
        'GunaTextBoxAdresseDeFacturation
        '
        Me.GunaTextBoxAdresseDeFacturation.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAdresseDeFacturation.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdresseDeFacturation.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxAdresseDeFacturation.BorderSize = 1
        Me.GunaTextBoxAdresseDeFacturation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxAdresseDeFacturation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAdresseDeFacturation.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdresseDeFacturation.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAdresseDeFacturation.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAdresseDeFacturation.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxAdresseDeFacturation.Location = New System.Drawing.Point(192, 395)
        Me.GunaTextBoxAdresseDeFacturation.Name = "GunaTextBoxAdresseDeFacturation"
        Me.GunaTextBoxAdresseDeFacturation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAdresseDeFacturation.Radius = 5
        Me.GunaTextBoxAdresseDeFacturation.SelectedText = ""
        Me.GunaTextBoxAdresseDeFacturation.Size = New System.Drawing.Size(374, 30)
        Me.GunaTextBoxAdresseDeFacturation.TabIndex = 50
        '
        'GunaTextBoxContactPourPaiement
        '
        Me.GunaTextBoxContactPourPaiement.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxContactPourPaiement.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxContactPourPaiement.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxContactPourPaiement.BorderSize = 1
        Me.GunaTextBoxContactPourPaiement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxContactPourPaiement.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxContactPourPaiement.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxContactPourPaiement.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxContactPourPaiement.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxContactPourPaiement.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxContactPourPaiement.Location = New System.Drawing.Point(546, 333)
        Me.GunaTextBoxContactPourPaiement.Name = "GunaTextBoxContactPourPaiement"
        Me.GunaTextBoxContactPourPaiement.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxContactPourPaiement.Radius = 5
        Me.GunaTextBoxContactPourPaiement.SelectedText = ""
        Me.GunaTextBoxContactPourPaiement.Size = New System.Drawing.Size(173, 30)
        Me.GunaTextBoxContactPourPaiement.TabIndex = 51
        '
        'GunaTextBoxPersonneAContacter
        '
        Me.GunaTextBoxPersonneAContacter.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPersonneAContacter.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPersonneAContacter.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxPersonneAContacter.BorderSize = 1
        Me.GunaTextBoxPersonneAContacter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxPersonneAContacter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPersonneAContacter.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPersonneAContacter.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPersonneAContacter.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPersonneAContacter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxPersonneAContacter.Location = New System.Drawing.Point(192, 333)
        Me.GunaTextBoxPersonneAContacter.Name = "GunaTextBoxPersonneAContacter"
        Me.GunaTextBoxPersonneAContacter.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPersonneAContacter.Radius = 5
        Me.GunaTextBoxPersonneAContacter.SelectedText = ""
        Me.GunaTextBoxPersonneAContacter.Size = New System.Drawing.Size(338, 30)
        Me.GunaTextBoxPersonneAContacter.TabIndex = 52
        '
        'GunaTextBoxMontantPlafondsDuCompte
        '
        Me.GunaTextBoxMontantPlafondsDuCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantPlafondsDuCompte.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantPlafondsDuCompte.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantPlafondsDuCompte.BorderSize = 1
        Me.GunaTextBoxMontantPlafondsDuCompte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantPlafondsDuCompte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantPlafondsDuCompte.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantPlafondsDuCompte.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantPlafondsDuCompte.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantPlafondsDuCompte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxMontantPlafondsDuCompte.Location = New System.Drawing.Point(436, 267)
        Me.GunaTextBoxMontantPlafondsDuCompte.Name = "GunaTextBoxMontantPlafondsDuCompte"
        Me.GunaTextBoxMontantPlafondsDuCompte.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantPlafondsDuCompte.Radius = 5
        Me.GunaTextBoxMontantPlafondsDuCompte.SelectedText = ""
        Me.GunaTextBoxMontantPlafondsDuCompte.Size = New System.Drawing.Size(176, 34)
        Me.GunaTextBoxMontantPlafondsDuCompte.TabIndex = 49
        Me.GunaTextBoxMontantPlafondsDuCompte.Text = "0"
        Me.GunaTextBoxMontantPlafondsDuCompte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaLabel36
        '
        Me.GunaLabel36.AutoSize = True
        Me.GunaLabel36.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel36.Location = New System.Drawing.Point(189, 374)
        Me.GunaLabel36.Name = "GunaLabel36"
        Me.GunaLabel36.Size = New System.Drawing.Size(140, 17)
        Me.GunaLabel36.TabIndex = 44
        Me.GunaLabel36.Text = "Adresse de facturation"
        '
        'GunaLabel35
        '
        Me.GunaLabel35.AutoSize = True
        Me.GunaLabel35.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel35.Location = New System.Drawing.Point(543, 313)
        Me.GunaLabel35.Name = "GunaLabel35"
        Me.GunaLabel35.Size = New System.Drawing.Size(52, 17)
        Me.GunaLabel35.TabIndex = 45
        Me.GunaLabel35.Text = "Contact"
        '
        'GunaLabel22
        '
        Me.GunaLabel22.AutoSize = True
        Me.GunaLabel22.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel22.Location = New System.Drawing.Point(198, 313)
        Me.GunaLabel22.Name = "GunaLabel22"
        Me.GunaLabel22.Size = New System.Drawing.Size(197, 17)
        Me.GunaLabel22.TabIndex = 46
        Me.GunaLabel22.Text = "Nom de la Personne à contacter"
        '
        'GunaLabel32
        '
        Me.GunaLabel32.AutoSize = True
        Me.GunaLabel32.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel32.Location = New System.Drawing.Point(638, 248)
        Me.GunaLabel32.Name = "GunaLabel32"
        Me.GunaLabel32.Size = New System.Drawing.Size(83, 17)
        Me.GunaLabel32.TabIndex = 47
        Me.GunaLabel32.Text = "Compte Actif"
        '
        'GunaLabel31
        '
        Me.GunaLabel31.AutoSize = True
        Me.GunaLabel31.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel31.Location = New System.Drawing.Point(433, 248)
        Me.GunaLabel31.Name = "GunaLabel31"
        Me.GunaLabel31.Size = New System.Drawing.Size(180, 17)
        Me.GunaLabel31.TabIndex = 48
        Me.GunaLabel31.Text = "Montant Plafonds du Compte"
        '
        'GunaTextBoxNumCompte
        '
        Me.GunaTextBoxNumCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumCompte.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumCompte.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNumCompte.BorderSize = 1
        Me.GunaTextBoxNumCompte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNumCompte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNumCompte.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumCompte.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNumCompte.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNumCompte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNumCompte.Location = New System.Drawing.Point(192, 63)
        Me.GunaTextBoxNumCompte.Name = "GunaTextBoxNumCompte"
        Me.GunaTextBoxNumCompte.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNumCompte.Radius = 5
        Me.GunaTextBoxNumCompte.SelectedText = ""
        Me.GunaTextBoxNumCompte.Size = New System.Drawing.Size(266, 36)
        Me.GunaTextBoxNumCompte.TabIndex = 5
        '
        'GunaButtonAjouterCompte
        '
        Me.GunaButtonAjouterCompte.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAjouterCompte.AnimationSpeed = 0.03!
        Me.GunaButtonAjouterCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAjouterCompte.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAjouterCompte.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterCompte.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAjouterCompte.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAjouterCompte.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAjouterCompte.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouterCompte.Image = Nothing
        Me.GunaButtonAjouterCompte.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAjouterCompte.Location = New System.Drawing.Point(653, 585)
        Me.GunaButtonAjouterCompte.Name = "GunaButtonAjouterCompte"
        Me.GunaButtonAjouterCompte.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAjouterCompte.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterCompte.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAjouterCompte.OnHoverImage = Nothing
        Me.GunaButtonAjouterCompte.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAjouterCompte.Radius = 4
        Me.GunaButtonAjouterCompte.Size = New System.Drawing.Size(121, 37)
        Me.GunaButtonAjouterCompte.TabIndex = 3
        Me.GunaButtonAjouterCompte.Text = "Enregistrer"
        Me.GunaButtonAjouterCompte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaComboBoxSensSolde
        '
        Me.GunaComboBoxSensSolde.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxSensSolde.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxSensSolde.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxSensSolde.BorderSize = 1
        Me.GunaComboBoxSensSolde.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxSensSolde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxSensSolde.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxSensSolde.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxSensSolde.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxSensSolde.FormattingEnabled = True
        Me.GunaComboBoxSensSolde.ItemHeight = 25
        Me.GunaComboBoxSensSolde.Items.AddRange(New Object() {"Indifférent", "Débiteur", "Créditeur"})
        Me.GunaComboBoxSensSolde.Location = New System.Drawing.Point(471, 199)
        Me.GunaComboBoxSensSolde.Name = "GunaComboBoxSensSolde"
        Me.GunaComboBoxSensSolde.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxSensSolde.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxSensSolde.Radius = 4
        Me.GunaComboBoxSensSolde.Size = New System.Drawing.Size(248, 31)
        Me.GunaComboBoxSensSolde.TabIndex = 4
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
        Me.GunaButton1.Location = New System.Drawing.Point(116, 585)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 37)
        Me.GunaButton1.TabIndex = 3
        Me.GunaButton1.Text = "Fermer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaComboBoxTypeCompte
        '
        Me.GunaComboBoxTypeCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxTypeCompte.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxTypeCompte.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxTypeCompte.BorderSize = 1
        Me.GunaComboBoxTypeCompte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxTypeCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxTypeCompte.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxTypeCompte.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxTypeCompte.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxTypeCompte.FormattingEnabled = True
        Me.GunaComboBoxTypeCompte.ItemHeight = 25
        Me.GunaComboBoxTypeCompte.Items.AddRange(New Object() {"Autre Compte", "Compte Caisse", "Compte Banque"})
        Me.GunaComboBoxTypeCompte.Location = New System.Drawing.Point(192, 199)
        Me.GunaComboBoxTypeCompte.Name = "GunaComboBoxTypeCompte"
        Me.GunaComboBoxTypeCompte.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxTypeCompte.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxTypeCompte.Radius = 4
        Me.GunaComboBoxTypeCompte.Size = New System.Drawing.Size(245, 31)
        Me.GunaComboBoxTypeCompte.TabIndex = 3
        '
        'GunaTextBoxIntituleCompte
        '
        Me.GunaTextBoxIntituleCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxIntituleCompte.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxIntituleCompte.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxIntituleCompte.BorderSize = 1
        Me.GunaTextBoxIntituleCompte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxIntituleCompte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxIntituleCompte.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxIntituleCompte.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxIntituleCompte.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxIntituleCompte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxIntituleCompte.Location = New System.Drawing.Point(192, 134)
        Me.GunaTextBoxIntituleCompte.Name = "GunaTextBoxIntituleCompte"
        Me.GunaTextBoxIntituleCompte.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxIntituleCompte.Radius = 4
        Me.GunaTextBoxIntituleCompte.SelectedText = ""
        Me.GunaTextBoxIntituleCompte.Size = New System.Drawing.Size(527, 34)
        Me.GunaTextBoxIntituleCompte.TabIndex = 2
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(468, 179)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(72, 17)
        Me.GunaLabel5.TabIndex = 0
        Me.GunaLabel5.Text = "Sens Solde"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(189, 179)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(104, 17)
        Me.GunaLabel4.TabIndex = 0
        Me.GunaLabel4.Text = "Type de Compte"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(189, 114)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(115, 17)
        Me.GunaLabel3.TabIndex = 0
        Me.GunaLabel3.Text = "Intitulé du Compte"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(193, 43)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(123, 17)
        Me.GunaLabel2.TabIndex = 0
        Me.GunaLabel2.Text = "Numéro du compte"
        '
        'TabPageListe
        '
        Me.TabPageListe.Controls.Add(Me.GunaButtonAfficher)
        Me.TabPageListe.Controls.Add(Me.DataGridViewListeDesComptes)
        Me.TabPageListe.Location = New System.Drawing.Point(4, 25)
        Me.TabPageListe.Name = "TabPageListe"
        Me.TabPageListe.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageListe.Size = New System.Drawing.Size(922, 628)
        Me.TabPageListe.TabIndex = 1
        Me.TabPageListe.Text = "Liste"
        Me.TabPageListe.UseVisualStyleBackColor = True
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
        Me.GunaButtonAfficher.Location = New System.Drawing.Point(782, 32)
        Me.GunaButtonAfficher.Name = "GunaButtonAfficher"
        Me.GunaButtonAfficher.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAfficher.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficher.OnHoverImage = Nothing
        Me.GunaButtonAfficher.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAfficher.Radius = 4
        Me.GunaButtonAfficher.Size = New System.Drawing.Size(121, 37)
        Me.GunaButtonAfficher.TabIndex = 4
        Me.GunaButtonAfficher.Text = "Afficher"
        Me.GunaButtonAfficher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DataGridViewListeDesComptes
        '
        Me.DataGridViewListeDesComptes.AllowUserToAddRows = False
        Me.DataGridViewListeDesComptes.AllowUserToDeleteRows = False
        Me.DataGridViewListeDesComptes.AllowUserToOrderColumns = True
        Me.DataGridViewListeDesComptes.AllowUserToResizeColumns = False
        Me.DataGridViewListeDesComptes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DataGridViewListeDesComptes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewListeDesComptes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewListeDesComptes.BackgroundColor = System.Drawing.Color.LightBlue
        Me.DataGridViewListeDesComptes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewListeDesComptes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridViewListeDesComptes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewListeDesComptes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewListeDesComptes.ColumnHeadersHeight = 25
        Me.DataGridViewListeDesComptes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewListeDesComptes.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewListeDesComptes.EnableHeadersVisualStyles = False
        Me.DataGridViewListeDesComptes.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewListeDesComptes.Location = New System.Drawing.Point(6, 116)
        Me.DataGridViewListeDesComptes.MultiSelect = False
        Me.DataGridViewListeDesComptes.Name = "DataGridViewListeDesComptes"
        Me.DataGridViewListeDesComptes.ReadOnly = True
        Me.DataGridViewListeDesComptes.RowHeadersVisible = False
        Me.DataGridViewListeDesComptes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridViewListeDesComptes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewListeDesComptes.Size = New System.Drawing.Size(910, 493)
        Me.DataGridViewListeDesComptes.TabIndex = 1
        Me.DataGridViewListeDesComptes.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.DataGridViewListeDesComptes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridViewListeDesComptes.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DataGridViewListeDesComptes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DataGridViewListeDesComptes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DataGridViewListeDesComptes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DataGridViewListeDesComptes.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.DataGridViewListeDesComptes.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewListeDesComptes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewListeDesComptes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridViewListeDesComptes.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewListeDesComptes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DataGridViewListeDesComptes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewListeDesComptes.ThemeStyle.HeaderStyle.Height = 25
        Me.DataGridViewListeDesComptes.ThemeStyle.ReadOnly = True
        Me.DataGridViewListeDesComptes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridViewListeDesComptes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridViewListeDesComptes.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewListeDesComptes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DataGridViewListeDesComptes.ThemeStyle.RowsStyle.Height = 22
        Me.DataGridViewListeDesComptes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridViewListeDesComptes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GeneralAccountForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 700)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GeneralAccountForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageDescription.ResumeLayout(False)
        Me.TabPageDescription.PerformLayout()
        Me.TabPageListe.ResumeLayout(False)
        CType(Me.DataGridViewListeDesComptes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonAjouterCompte As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageDescription As TabPage
    Friend WithEvents TabPageListe As TabPage
    Friend WithEvents GunaComboBoxSensSolde As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaComboBoxTypeCompte As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxIntituleCompte As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents DataGridViewListeDesComptes As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaButtonAfficher As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxNumCompte As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaCheckBoxActivationDesactivationDuCompte As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaTextBoxAdresseDeFacturation As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxContactPourPaiement As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxPersonneAContacter As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantPlafondsDuCompte As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel36 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel35 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel22 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel32 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel31 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel37 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents NumericUpDownDelaiDePaiement As Guna.UI.WinForms.GunaTextBox
End Class
