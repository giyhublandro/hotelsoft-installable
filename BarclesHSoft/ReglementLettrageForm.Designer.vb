<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReglementLettrageForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReglementLettrageForm))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButtonReduce = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButtonFermer = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButtonEnregistrerReglement = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaTextBoxAPayer = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelMontantAPayer = New System.Windows.Forms.Label()
        Me.GunaDataGridViewDetailsFactures = New Guna.UI.WinForms.GunaDataGridView()
        Me.DateOperation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LibelleOperation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaTextBoxNom = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxClientAFacturer = New Guna.UI.WinForms.GunaTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GunaTextBoxMontantVerse = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelSolde = New System.Windows.Forms.Label()
        Me.GunaTextBoxSolde = New Guna.UI.WinForms.GunaTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GunaComboBoxModeReglement = New Guna.UI.WinForms.GunaComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GunaTextBoxReference = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaDataGridViewClient = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanelSupplementCarte = New Guna.UI.WinForms.GunaPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GunaComboBoxBanque = New Guna.UI.WinForms.GunaComboBox()
        Me.MaskedTextBoxCVV = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBoxNumeroCarte = New System.Windows.Forms.MaskedTextBox()
        Me.GunaTextBoxCodeDeLAvoir = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaDateTimePickerDateExpiration = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.LabelCVV = New System.Windows.Forms.Label()
        Me.LabelDateExpiration = New System.Windows.Forms.Label()
        Me.LabelNumCarte = New System.Windows.Forms.Label()
        Me.GunaPanelSupplementCheque = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxCheque = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaComboBoxBanqueEmettrice = New Guna.UI.WinForms.GunaComboBox()
        Me.LabelNumCompte = New System.Windows.Forms.Label()
        Me.LabelBanqueEmettrice = New System.Windows.Forms.Label()
        Me.GunaTextBoxCompteDebiteur = New Guna.UI.WinForms.GunaTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GunaPanel3 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GunaTextBoxSoldeCompte = New Guna.UI.WinForms.GunaTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GunaTextBoxPersonneAContacter = New Guna.UI.WinForms.GunaTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GunaTextBoxAdressePaiement = New Guna.UI.WinForms.GunaTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GunaTextBoxContactPaiement = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxDelaiPaiement = New Guna.UI.WinForms.GunaTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GunaTextBoxPlafonds = New Guna.UI.WinForms.GunaTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GunaDataGridViewListeFacture = New Guna.UI.WinForms.GunaDataGridView()
        Me.REFERENCE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DATE_FACTURE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NATURE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LIBELLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LETTRAGE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONTANT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONTANT_SOLDE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SOLDE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODE_CLIENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaContextMenuStripFactureARegler = New Guna.UI.WinForms.GunaContextMenuStrip()
        Me.ImprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimerFactureSynthèseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransférerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RéductionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GunaComboBoxNatureOperation = New Guna.UI.WinForms.GunaComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GunaTextBoxCodeEntreprise = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeFacture = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeReservation = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonEffacerDetail = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxChiffreAffaire = New Guna.UI.WinForms.GunaTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GunaComboBoxTypeDeFiltre = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaButtonAfficherLesFacturesEtReglement = New Guna.UI.WinForms.GunaButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GunaDateTimePickerFin = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.PanelSituationCaisse = New System.Windows.Forms.Panel()
        Me.LabelSituationCaisse = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GunaButtonOuvertureFermeture = New Guna.UI.WinForms.GunaButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaTextBoxInconnu = New Guna.UI.WinForms.GunaTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelDettes = New System.Windows.Forms.Label()
        Me.GunaButtonTransfert = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanelVirement = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxReferenceVirement = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaComboBoxBanqueVirement = New Guna.UI.WinForms.GunaComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GunaPanelAvoir = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxMontantAvoir = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaComboBoxAvoir = New Guna.UI.WinForms.GunaComboBox()
        Me.LabelMontant = New System.Windows.Forms.Label()
        Me.Label1Avoir = New System.Windows.Forms.Label()
        Me.GunaPanelPriseEncharge = New Guna.UI.WinForms.GunaPanel()
        Me.GunaDataGridViewCompany = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaTextBoxNumeroCompte = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxEntreprise = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelNumeroCompte = New System.Windows.Forms.Label()
        Me.LabelEntreprise = New System.Windows.Forms.Label()
        Me.GunaPanelMobileMOney = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxContact = New Guna.UI.WinForms.GunaTextBox()
        Me.Gunalabel56 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.LabelRang = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LabelSur = New System.Windows.Forms.Label()
        Me.GunaPanelDepotDeGarantie = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxMontantDepotDeGarantie = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaComboBoxDepotDeGarantie = New Guna.UI.WinForms.GunaComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.GunaDateTimePickerDebut = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.GunaDataGridViewDetailsFactures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridViewClient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPanelSupplementCarte.SuspendLayout()
        Me.GunaPanelSupplementCheque.SuspendLayout()
        CType(Me.GunaDataGridViewListeFacture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaContextMenuStripFactureARegler.SuspendLayout()
        Me.PanelSituationCaisse.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GunaPanelVirement.SuspendLayout()
        Me.GunaPanelAvoir.SuspendLayout()
        Me.GunaPanelPriseEncharge.SuspendLayout()
        CType(Me.GunaDataGridViewCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPanelMobileMOney.SuspendLayout()
        Me.GunaPanelDepotDeGarantie.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(489, 1)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(216, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "REGLEMENTS ET LETTRAGES"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButtonReduce)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButtonFermer)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1300, 25)
        Me.GunaPanel1.TabIndex = 2
        '
        'GunaImageButtonReduce
        '
        Me.GunaImageButtonReduce.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonReduce.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonReduce.Image = CType(resources.GetObject("GunaImageButtonReduce.Image"), System.Drawing.Image)
        Me.GunaImageButtonReduce.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButtonReduce.Location = New System.Drawing.Point(1246, 3)
        Me.GunaImageButtonReduce.Name = "GunaImageButtonReduce"
        Me.GunaImageButtonReduce.OnHoverImage = Nothing
        Me.GunaImageButtonReduce.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButtonReduce.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButtonReduce.TabIndex = 87
        '
        'GunaImageButtonFermer
        '
        Me.GunaImageButtonFermer.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonFermer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonFermer.Image = CType(resources.GetObject("GunaImageButtonFermer.Image"), System.Drawing.Image)
        Me.GunaImageButtonFermer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButtonFermer.Location = New System.Drawing.Point(1270, 3)
        Me.GunaImageButtonFermer.Name = "GunaImageButtonFermer"
        Me.GunaImageButtonFermer.OnHoverImage = Nothing
        Me.GunaImageButtonFermer.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButtonFermer.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButtonFermer.TabIndex = 86
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1265, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2467, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaButtonEnregistrerReglement
        '
        Me.GunaButtonEnregistrerReglement.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEnregistrerReglement.AnimationSpeed = 0.03!
        Me.GunaButtonEnregistrerReglement.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEnregistrerReglement.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrerReglement.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerReglement.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEnregistrerReglement.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEnregistrerReglement.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEnregistrerReglement.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerReglement.Image = Nothing
        Me.GunaButtonEnregistrerReglement.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnregistrerReglement.Location = New System.Drawing.Point(1187, 669)
        Me.GunaButtonEnregistrerReglement.Name = "GunaButtonEnregistrerReglement"
        Me.GunaButtonEnregistrerReglement.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrerReglement.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerReglement.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerReglement.OnHoverImage = Nothing
        Me.GunaButtonEnregistrerReglement.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerReglement.Radius = 4
        Me.GunaButtonEnregistrerReglement.Size = New System.Drawing.Size(97, 37)
        Me.GunaButtonEnregistrerReglement.TabIndex = 7
        Me.GunaButtonEnregistrerReglement.Text = "Enregistrer"
        Me.GunaButtonEnregistrerReglement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButtonEnregistrerReglement.Visible = False
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
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(730, 614)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 16)
        Me.GunaButton1.TabIndex = 8
        Me.GunaButton1.Text = "Fermer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton1.Visible = False
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLabelGestCompteGeneraux
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaPanel1
        '
        'GunaTextBoxAPayer
        '
        Me.GunaTextBoxAPayer.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAPayer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GunaTextBoxAPayer.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxAPayer.BorderSize = 1
        Me.GunaTextBoxAPayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxAPayer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAPayer.Enabled = False
        Me.GunaTextBoxAPayer.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAPayer.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAPayer.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAPayer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxAPayer.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxAPayer.Location = New System.Drawing.Point(1206, 506)
        Me.GunaTextBoxAPayer.Name = "GunaTextBoxAPayer"
        Me.GunaTextBoxAPayer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAPayer.Radius = 5
        Me.GunaTextBoxAPayer.SelectedText = ""
        Me.GunaTextBoxAPayer.Size = New System.Drawing.Size(82, 31)
        Me.GunaTextBoxAPayer.TabIndex = 72
        Me.GunaTextBoxAPayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelMontantAPayer
        '
        Me.LabelMontantAPayer.AutoSize = True
        Me.LabelMontantAPayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMontantAPayer.Location = New System.Drawing.Point(1054, 513)
        Me.LabelMontantAPayer.Name = "LabelMontantAPayer"
        Me.LabelMontantAPayer.Size = New System.Drawing.Size(120, 16)
        Me.LabelMontantAPayer.TabIndex = 70
        Me.LabelMontantAPayer.Text = "Montant à Payer"
        '
        'GunaDataGridViewDetailsFactures
        '
        Me.GunaDataGridViewDetailsFactures.AllowUserToAddRows = False
        Me.GunaDataGridViewDetailsFactures.AllowUserToDeleteRows = False
        Me.GunaDataGridViewDetailsFactures.AllowUserToResizeColumns = False
        Me.GunaDataGridViewDetailsFactures.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewDetailsFactures.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GunaDataGridViewDetailsFactures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewDetailsFactures.BackgroundColor = System.Drawing.Color.PaleTurquoise
        Me.GunaDataGridViewDetailsFactures.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewDetailsFactures.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewDetailsFactures.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewDetailsFactures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GunaDataGridViewDetailsFactures.ColumnHeadersHeight = 25
        Me.GunaDataGridViewDetailsFactures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewDetailsFactures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateOperation, Me.LibelleOperation, Me.Debit, Me.Credit})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewDetailsFactures.DefaultCellStyle = DataGridViewCellStyle9
        Me.GunaDataGridViewDetailsFactures.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewDetailsFactures.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewDetailsFactures.Location = New System.Drawing.Point(9, 449)
        Me.GunaDataGridViewDetailsFactures.Name = "GunaDataGridViewDetailsFactures"
        Me.GunaDataGridViewDetailsFactures.ReadOnly = True
        Me.GunaDataGridViewDetailsFactures.RowHeadersVisible = False
        Me.GunaDataGridViewDetailsFactures.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewDetailsFactures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewDetailsFactures.Size = New System.Drawing.Size(608, 249)
        Me.GunaDataGridViewDetailsFactures.TabIndex = 17
        Me.GunaDataGridViewDetailsFactures.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.BackColor = System.Drawing.Color.PaleTurquoise
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewDetailsFactures.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'DateOperation
        '
        Me.DateOperation.HeaderText = "Date Opération"
        Me.DateOperation.Name = "DateOperation"
        Me.DateOperation.ReadOnly = True
        '
        'LibelleOperation
        '
        Me.LibelleOperation.HeaderText = "Libelle Operation"
        Me.LibelleOperation.Name = "LibelleOperation"
        Me.LibelleOperation.ReadOnly = True
        '
        'Debit
        '
        Me.Debit.HeaderText = "Débit"
        Me.Debit.Name = "Debit"
        Me.Debit.ReadOnly = True
        '
        'Credit
        '
        Me.Credit.HeaderText = "Crédit"
        Me.Credit.Name = "Credit"
        Me.Credit.ReadOnly = True
        '
        'GunaTextBoxNom
        '
        Me.GunaTextBoxNom.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNom.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNom.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNom.BorderSize = 1
        Me.GunaTextBoxNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNom.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNom.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNom.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNom.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNom.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNom.Location = New System.Drawing.Point(461, 74)
        Me.GunaTextBoxNom.Name = "GunaTextBoxNom"
        Me.GunaTextBoxNom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNom.Radius = 5
        Me.GunaTextBoxNom.SelectedText = ""
        Me.GunaTextBoxNom.Size = New System.Drawing.Size(222, 33)
        Me.GunaTextBoxNom.TabIndex = 74
        '
        'GunaTextBoxClientAFacturer
        '
        Me.GunaTextBoxClientAFacturer.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxClientAFacturer.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxClientAFacturer.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxClientAFacturer.BorderSize = 1
        Me.GunaTextBoxClientAFacturer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxClientAFacturer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxClientAFacturer.Enabled = False
        Me.GunaTextBoxClientAFacturer.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxClientAFacturer.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxClientAFacturer.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxClientAFacturer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxClientAFacturer.Location = New System.Drawing.Point(116, 31)
        Me.GunaTextBoxClientAFacturer.Name = "GunaTextBoxClientAFacturer"
        Me.GunaTextBoxClientAFacturer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxClientAFacturer.Radius = 5
        Me.GunaTextBoxClientAFacturer.SelectedText = ""
        Me.GunaTextBoxClientAFacturer.Size = New System.Drawing.Size(339, 34)
        Me.GunaTextBoxClientAFacturer.TabIndex = 75
        Me.GunaTextBoxClientAFacturer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1067, 551)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Montant Versé"
        '
        'GunaTextBoxMontantVerse
        '
        Me.GunaTextBoxMontantVerse.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantVerse.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantVerse.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantVerse.BorderSize = 1
        Me.GunaTextBoxMontantVerse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantVerse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantVerse.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantVerse.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantVerse.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantVerse.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxMontantVerse.Location = New System.Drawing.Point(1206, 543)
        Me.GunaTextBoxMontantVerse.Name = "GunaTextBoxMontantVerse"
        Me.GunaTextBoxMontantVerse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantVerse.Radius = 5
        Me.GunaTextBoxMontantVerse.SelectedText = ""
        Me.GunaTextBoxMontantVerse.Size = New System.Drawing.Size(82, 31)
        Me.GunaTextBoxMontantVerse.TabIndex = 72
        Me.GunaTextBoxMontantVerse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelSolde
        '
        Me.LabelSolde.AutoSize = True
        Me.LabelSolde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSolde.Location = New System.Drawing.Point(1065, 587)
        Me.LabelSolde.Name = "LabelSolde"
        Me.LabelSolde.Size = New System.Drawing.Size(106, 16)
        Me.LabelSolde.TabIndex = 70
        Me.LabelSolde.Text = "Solde à payer"
        '
        'GunaTextBoxSolde
        '
        Me.GunaTextBoxSolde.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxSolde.BaseColor = System.Drawing.Color.Salmon
        Me.GunaTextBoxSolde.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxSolde.BorderSize = 1
        Me.GunaTextBoxSolde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxSolde.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxSolde.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxSolde.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxSolde.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxSolde.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxSolde.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxSolde.Location = New System.Drawing.Point(1206, 580)
        Me.GunaTextBoxSolde.Name = "GunaTextBoxSolde"
        Me.GunaTextBoxSolde.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxSolde.Radius = 5
        Me.GunaTextBoxSolde.SelectedText = ""
        Me.GunaTextBoxSolde.Size = New System.Drawing.Size(82, 31)
        Me.GunaTextBoxSolde.TabIndex = 72
        Me.GunaTextBoxSolde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(623, 473)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 16)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "MODE DE REGLEMENT"
        '
        'GunaComboBoxModeReglement
        '
        Me.GunaComboBoxModeReglement.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxModeReglement.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxModeReglement.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxModeReglement.BorderSize = 1
        Me.GunaComboBoxModeReglement.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxModeReglement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxModeReglement.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxModeReglement.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxModeReglement.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxModeReglement.FormattingEnabled = True
        Me.GunaComboBoxModeReglement.ItemHeight = 25
        Me.GunaComboBoxModeReglement.Items.AddRange(New Object() {"Cash", "Chèque", "Carte de crédit", "Prise en charge", "MTN Money", "ORANGE Money", "Avoir", "Virement Bancaire", "Caution", "Dépôt de garantie", "Retenue", "Gratuitée"})
        Me.GunaComboBoxModeReglement.Location = New System.Drawing.Point(626, 492)
        Me.GunaComboBoxModeReglement.Name = "GunaComboBoxModeReglement"
        Me.GunaComboBoxModeReglement.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxModeReglement.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxModeReglement.Radius = 4
        Me.GunaComboBoxModeReglement.Size = New System.Drawing.Size(168, 31)
        Me.GunaComboBoxModeReglement.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(623, 419)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 16)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "REFERENCE"
        '
        'GunaTextBoxReference
        '
        Me.GunaTextBoxReference.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxReference.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxReference.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxReference.BorderSize = 1
        Me.GunaTextBoxReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxReference.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxReference.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxReference.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxReference.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxReference.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxReference.Location = New System.Drawing.Point(626, 436)
        Me.GunaTextBoxReference.Name = "GunaTextBoxReference"
        Me.GunaTextBoxReference.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxReference.Radius = 5
        Me.GunaTextBoxReference.SelectedText = ""
        Me.GunaTextBoxReference.Size = New System.Drawing.Size(366, 31)
        Me.GunaTextBoxReference.TabIndex = 72
        '
        'GunaDataGridViewClient
        '
        Me.GunaDataGridViewClient.AllowUserToAddRows = False
        Me.GunaDataGridViewClient.AllowUserToDeleteRows = False
        Me.GunaDataGridViewClient.AllowUserToResizeColumns = False
        Me.GunaDataGridViewClient.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewClient.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.GunaDataGridViewClient.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewClient.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewClient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewClient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewClient.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewClient.ColumnHeadersHeight = 4
        Me.GunaDataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewClient.ColumnHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewClient.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewClient.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewClient.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewClient.Location = New System.Drawing.Point(461, 111)
        Me.GunaDataGridViewClient.MultiSelect = False
        Me.GunaDataGridViewClient.Name = "GunaDataGridViewClient"
        Me.GunaDataGridViewClient.ReadOnly = True
        Me.GunaDataGridViewClient.RowHeadersVisible = False
        Me.GunaDataGridViewClient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewClient.Size = New System.Drawing.Size(343, 207)
        Me.GunaDataGridViewClient.TabIndex = 17
        Me.GunaDataGridViewClient.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewClient.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewClient.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewClient.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewClient.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewClient.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewClient.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewClient.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewClient.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewClient.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewClient.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewClient.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewClient.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewClient.ThemeStyle.HeaderStyle.Height = 4
        Me.GunaDataGridViewClient.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewClient.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewClient.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewClient.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewClient.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewClient.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewClient.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewClient.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewClient.Visible = False
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 777)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(841, 10)
        Me.GunaPanel2.TabIndex = 78
        '
        'GunaPanelSupplementCarte
        '
        Me.GunaPanelSupplementCarte.Controls.Add(Me.Label18)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.GunaComboBoxBanque)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.MaskedTextBoxCVV)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.MaskedTextBoxNumeroCarte)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.GunaTextBoxCodeDeLAvoir)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.GunaDateTimePickerDateExpiration)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.LabelCVV)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.LabelDateExpiration)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.LabelNumCarte)
        Me.GunaPanelSupplementCarte.Location = New System.Drawing.Point(628, 530)
        Me.GunaPanelSupplementCarte.Name = "GunaPanelSupplementCarte"
        Me.GunaPanelSupplementCarte.Size = New System.Drawing.Size(439, 116)
        Me.GunaPanelSupplementCarte.TabIndex = 81
        Me.GunaPanelSupplementCarte.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(192, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 16)
        Me.Label18.TabIndex = 86
        Me.Label18.Text = "Banque"
        Me.Label18.Visible = False
        '
        'GunaComboBoxBanque
        '
        Me.GunaComboBoxBanque.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxBanque.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxBanque.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxBanque.BorderSize = 1
        Me.GunaComboBoxBanque.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxBanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxBanque.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxBanque.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxBanque.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxBanque.FormattingEnabled = True
        Me.GunaComboBoxBanque.ItemHeight = 25
        Me.GunaComboBoxBanque.Location = New System.Drawing.Point(189, 76)
        Me.GunaComboBoxBanque.Name = "GunaComboBoxBanque"
        Me.GunaComboBoxBanque.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxBanque.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxBanque.Radius = 4
        Me.GunaComboBoxBanque.Size = New System.Drawing.Size(237, 31)
        Me.GunaComboBoxBanque.TabIndex = 85
        '
        'MaskedTextBoxCVV
        '
        Me.MaskedTextBoxCVV.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBoxCVV.Location = New System.Drawing.Point(201, 25)
        Me.MaskedTextBoxCVV.Mask = "000"
        Me.MaskedTextBoxCVV.Name = "MaskedTextBoxCVV"
        Me.MaskedTextBoxCVV.Size = New System.Drawing.Size(155, 24)
        Me.MaskedTextBoxCVV.TabIndex = 78
        Me.MaskedTextBoxCVV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaskedTextBoxCVV.ValidatingType = GetType(Integer)
        '
        'MaskedTextBoxNumeroCarte
        '
        Me.MaskedTextBoxNumeroCarte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBoxNumeroCarte.Location = New System.Drawing.Point(13, 25)
        Me.MaskedTextBoxNumeroCarte.Mask = "0000000000000000"
        Me.MaskedTextBoxNumeroCarte.Name = "MaskedTextBoxNumeroCarte"
        Me.MaskedTextBoxNumeroCarte.Size = New System.Drawing.Size(155, 24)
        Me.MaskedTextBoxNumeroCarte.TabIndex = 78
        Me.MaskedTextBoxNumeroCarte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaskedTextBoxNumeroCarte.ValidatingType = GetType(Integer)
        '
        'GunaTextBoxCodeDeLAvoir
        '
        Me.GunaTextBoxCodeDeLAvoir.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeDeLAvoir.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeDeLAvoir.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeDeLAvoir.BorderSize = 1
        Me.GunaTextBoxCodeDeLAvoir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeDeLAvoir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeDeLAvoir.Enabled = False
        Me.GunaTextBoxCodeDeLAvoir.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeDeLAvoir.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeDeLAvoir.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeDeLAvoir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeDeLAvoir.Location = New System.Drawing.Point(204, 76)
        Me.GunaTextBoxCodeDeLAvoir.Name = "GunaTextBoxCodeDeLAvoir"
        Me.GunaTextBoxCodeDeLAvoir.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeDeLAvoir.Radius = 5
        Me.GunaTextBoxCodeDeLAvoir.SelectedText = ""
        Me.GunaTextBoxCodeDeLAvoir.Size = New System.Drawing.Size(134, 31)
        Me.GunaTextBoxCodeDeLAvoir.TabIndex = 72
        Me.GunaTextBoxCodeDeLAvoir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaDateTimePickerDateExpiration
        '
        Me.GunaDateTimePickerDateExpiration.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerDateExpiration.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDateExpiration.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaDateTimePickerDateExpiration.BorderSize = 1
        Me.GunaDateTimePickerDateExpiration.CustomFormat = Nothing
        Me.GunaDateTimePickerDateExpiration.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDateExpiration.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateExpiration.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaDateTimePickerDateExpiration.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDateExpiration.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerDateExpiration.Location = New System.Drawing.Point(13, 77)
        Me.GunaDateTimePickerDateExpiration.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDateExpiration.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDateExpiration.Name = "GunaDateTimePickerDateExpiration"
        Me.GunaDateTimePickerDateExpiration.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDateExpiration.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateExpiration.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateExpiration.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDateExpiration.Radius = 5
        Me.GunaDateTimePickerDateExpiration.Size = New System.Drawing.Size(158, 30)
        Me.GunaDateTimePickerDateExpiration.TabIndex = 77
        Me.GunaDateTimePickerDateExpiration.Text = "15/09/2021"
        Me.GunaDateTimePickerDateExpiration.Value = New Date(2021, 9, 15, 18, 5, 8, 818)
        '
        'LabelCVV
        '
        Me.LabelCVV.AutoSize = True
        Me.LabelCVV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCVV.Location = New System.Drawing.Point(198, 6)
        Me.LabelCVV.Name = "LabelCVV"
        Me.LabelCVV.Size = New System.Drawing.Size(38, 16)
        Me.LabelCVV.TabIndex = 73
        Me.LabelCVV.Text = "CVV"
        Me.LabelCVV.Visible = False
        '
        'LabelDateExpiration
        '
        Me.LabelDateExpiration.AutoSize = True
        Me.LabelDateExpiration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDateExpiration.Location = New System.Drawing.Point(13, 58)
        Me.LabelDateExpiration.Name = "LabelDateExpiration"
        Me.LabelDateExpiration.Size = New System.Drawing.Size(114, 16)
        Me.LabelDateExpiration.TabIndex = 73
        Me.LabelDateExpiration.Text = "Date Expiration"
        Me.LabelDateExpiration.Visible = False
        '
        'LabelNumCarte
        '
        Me.LabelNumCarte.AutoSize = True
        Me.LabelNumCarte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumCarte.Location = New System.Drawing.Point(11, 6)
        Me.LabelNumCarte.Name = "LabelNumCarte"
        Me.LabelNumCarte.Size = New System.Drawing.Size(123, 16)
        Me.LabelNumCarte.TabIndex = 74
        Me.LabelNumCarte.Text = "Numéro de carte"
        Me.LabelNumCarte.Visible = False
        '
        'GunaPanelSupplementCheque
        '
        Me.GunaPanelSupplementCheque.Controls.Add(Me.GunaTextBoxCheque)
        Me.GunaPanelSupplementCheque.Controls.Add(Me.GunaComboBoxBanqueEmettrice)
        Me.GunaPanelSupplementCheque.Controls.Add(Me.LabelNumCompte)
        Me.GunaPanelSupplementCheque.Controls.Add(Me.LabelBanqueEmettrice)
        Me.GunaPanelSupplementCheque.Location = New System.Drawing.Point(629, 531)
        Me.GunaPanelSupplementCheque.Name = "GunaPanelSupplementCheque"
        Me.GunaPanelSupplementCheque.Size = New System.Drawing.Size(428, 118)
        Me.GunaPanelSupplementCheque.TabIndex = 82
        '
        'GunaTextBoxCheque
        '
        Me.GunaTextBoxCheque.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCheque.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCheque.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCheque.BorderSize = 1
        Me.GunaTextBoxCheque.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCheque.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCheque.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCheque.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCheque.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaTextBoxCheque.Location = New System.Drawing.Point(55, 80)
        Me.GunaTextBoxCheque.Name = "GunaTextBoxCheque"
        Me.GunaTextBoxCheque.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCheque.Radius = 5
        Me.GunaTextBoxCheque.SelectedText = ""
        Me.GunaTextBoxCheque.Size = New System.Drawing.Size(322, 30)
        Me.GunaTextBoxCheque.TabIndex = 75
        '
        'GunaComboBoxBanqueEmettrice
        '
        Me.GunaComboBoxBanqueEmettrice.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxBanqueEmettrice.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxBanqueEmettrice.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxBanqueEmettrice.BorderSize = 1
        Me.GunaComboBoxBanqueEmettrice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxBanqueEmettrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxBanqueEmettrice.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxBanqueEmettrice.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxBanqueEmettrice.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxBanqueEmettrice.FormattingEnabled = True
        Me.GunaComboBoxBanqueEmettrice.ItemHeight = 25
        Me.GunaComboBoxBanqueEmettrice.Location = New System.Drawing.Point(56, 24)
        Me.GunaComboBoxBanqueEmettrice.Name = "GunaComboBoxBanqueEmettrice"
        Me.GunaComboBoxBanqueEmettrice.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxBanqueEmettrice.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxBanqueEmettrice.Radius = 4
        Me.GunaComboBoxBanqueEmettrice.Size = New System.Drawing.Size(316, 31)
        Me.GunaComboBoxBanqueEmettrice.TabIndex = 85
        '
        'LabelNumCompte
        '
        Me.LabelNumCompte.AutoSize = True
        Me.LabelNumCompte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumCompte.Location = New System.Drawing.Point(52, 62)
        Me.LabelNumCompte.Name = "LabelNumCompte"
        Me.LabelNumCompte.Size = New System.Drawing.Size(139, 16)
        Me.LabelNumCompte.TabIndex = 73
        Me.LabelNumCompte.Text = "Numéro de chèque"
        Me.LabelNumCompte.Visible = False
        '
        'LabelBanqueEmettrice
        '
        Me.LabelBanqueEmettrice.AutoSize = True
        Me.LabelBanqueEmettrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBanqueEmettrice.Location = New System.Drawing.Point(53, 3)
        Me.LabelBanqueEmettrice.Name = "LabelBanqueEmettrice"
        Me.LabelBanqueEmettrice.Size = New System.Drawing.Size(130, 16)
        Me.LabelBanqueEmettrice.TabIndex = 74
        Me.LabelBanqueEmettrice.Text = "Banque Emettrice"
        Me.LabelBanqueEmettrice.Visible = False
        '
        'GunaTextBoxCompteDebiteur
        '
        Me.GunaTextBoxCompteDebiteur.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCompteDebiteur.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxCompteDebiteur.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCompteDebiteur.BorderSize = 1
        Me.GunaTextBoxCompteDebiteur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCompteDebiteur.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCompteDebiteur.Enabled = False
        Me.GunaTextBoxCompteDebiteur.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCompteDebiteur.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCompteDebiteur.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCompteDebiteur.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCompteDebiteur.Location = New System.Drawing.Point(116, 73)
        Me.GunaTextBoxCompteDebiteur.Name = "GunaTextBoxCompteDebiteur"
        Me.GunaTextBoxCompteDebiteur.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCompteDebiteur.Radius = 5
        Me.GunaTextBoxCompteDebiteur.SelectedText = ""
        Me.GunaTextBoxCompteDebiteur.Size = New System.Drawing.Size(120, 34)
        Me.GunaTextBoxCompteDebiteur.TabIndex = 75
        Me.GunaTextBoxCompteDebiteur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "N° COMPTE"
        '
        'GunaPanel3
        '
        Me.GunaPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel3.Location = New System.Drawing.Point(14, 709)
        Me.GunaPanel3.Name = "GunaPanel3"
        Me.GunaPanel3.Size = New System.Drawing.Size(1304, 10)
        Me.GunaPanel3.TabIndex = 86
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel3.Location = New System.Drawing.Point(488, 140)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(248, 25)
        Me.GunaLabel3.TabIndex = 4
        Me.GunaLabel3.Text = "FACTURES ET REGLEMENTS"
        Me.GunaLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 16)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "ENTREPRISE"
        '
        'GunaTextBoxSoldeCompte
        '
        Me.GunaTextBoxSoldeCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxSoldeCompte.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxSoldeCompte.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxSoldeCompte.BorderSize = 1
        Me.GunaTextBoxSoldeCompte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxSoldeCompte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxSoldeCompte.Enabled = False
        Me.GunaTextBoxSoldeCompte.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxSoldeCompte.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxSoldeCompte.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxSoldeCompte.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxSoldeCompte.Location = New System.Drawing.Point(324, 73)
        Me.GunaTextBoxSoldeCompte.Name = "GunaTextBoxSoldeCompte"
        Me.GunaTextBoxSoldeCompte.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxSoldeCompte.Radius = 5
        Me.GunaTextBoxSoldeCompte.SelectedText = ""
        Me.GunaTextBoxSoldeCompte.Size = New System.Drawing.Size(131, 34)
        Me.GunaTextBoxSoldeCompte.TabIndex = 75
        Me.GunaTextBoxSoldeCompte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(238, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 16)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "SOLDE"
        '
        'GunaTextBoxPersonneAContacter
        '
        Me.GunaTextBoxPersonneAContacter.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPersonneAContacter.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxPersonneAContacter.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxPersonneAContacter.BorderSize = 1
        Me.GunaTextBoxPersonneAContacter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxPersonneAContacter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPersonneAContacter.Enabled = False
        Me.GunaTextBoxPersonneAContacter.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPersonneAContacter.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPersonneAContacter.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPersonneAContacter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxPersonneAContacter.Location = New System.Drawing.Point(689, 45)
        Me.GunaTextBoxPersonneAContacter.Name = "GunaTextBoxPersonneAContacter"
        Me.GunaTextBoxPersonneAContacter.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPersonneAContacter.Radius = 5
        Me.GunaTextBoxPersonneAContacter.SelectedText = ""
        Me.GunaTextBoxPersonneAContacter.Size = New System.Drawing.Size(310, 34)
        Me.GunaTextBoxPersonneAContacter.TabIndex = 75
        Me.GunaTextBoxPersonneAContacter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(742, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(203, 16)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "PERSONNE A CONTACTER"
        '
        'GunaTextBoxAdressePaiement
        '
        Me.GunaTextBoxAdressePaiement.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAdressePaiement.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxAdressePaiement.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxAdressePaiement.BorderSize = 1
        Me.GunaTextBoxAdressePaiement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxAdressePaiement.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAdressePaiement.Enabled = False
        Me.GunaTextBoxAdressePaiement.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAdressePaiement.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAdressePaiement.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAdressePaiement.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxAdressePaiement.Location = New System.Drawing.Point(1005, 46)
        Me.GunaTextBoxAdressePaiement.Name = "GunaTextBoxAdressePaiement"
        Me.GunaTextBoxAdressePaiement.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAdressePaiement.Radius = 5
        Me.GunaTextBoxAdressePaiement.SelectedText = ""
        Me.GunaTextBoxAdressePaiement.Size = New System.Drawing.Size(286, 34)
        Me.GunaTextBoxAdressePaiement.TabIndex = 75
        Me.GunaTextBoxAdressePaiement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1045, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(216, 16)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "ADRESSE DE FACTURATION"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(690, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "CONTACT"
        '
        'GunaTextBoxContactPaiement
        '
        Me.GunaTextBoxContactPaiement.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxContactPaiement.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxContactPaiement.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxContactPaiement.BorderSize = 1
        Me.GunaTextBoxContactPaiement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxContactPaiement.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxContactPaiement.Enabled = False
        Me.GunaTextBoxContactPaiement.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxContactPaiement.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxContactPaiement.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxContactPaiement.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxContactPaiement.Location = New System.Drawing.Point(774, 82)
        Me.GunaTextBoxContactPaiement.Name = "GunaTextBoxContactPaiement"
        Me.GunaTextBoxContactPaiement.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxContactPaiement.Radius = 5
        Me.GunaTextBoxContactPaiement.SelectedText = ""
        Me.GunaTextBoxContactPaiement.Size = New System.Drawing.Size(105, 34)
        Me.GunaTextBoxContactPaiement.TabIndex = 75
        Me.GunaTextBoxContactPaiement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxDelaiPaiement
        '
        Me.GunaTextBoxDelaiPaiement.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxDelaiPaiement.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxDelaiPaiement.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxDelaiPaiement.BorderSize = 1
        Me.GunaTextBoxDelaiPaiement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxDelaiPaiement.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxDelaiPaiement.Enabled = False
        Me.GunaTextBoxDelaiPaiement.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxDelaiPaiement.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxDelaiPaiement.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxDelaiPaiement.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxDelaiPaiement.Location = New System.Drawing.Point(1069, 82)
        Me.GunaTextBoxDelaiPaiement.Name = "GunaTextBoxDelaiPaiement"
        Me.GunaTextBoxDelaiPaiement.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxDelaiPaiement.Radius = 5
        Me.GunaTextBoxDelaiPaiement.SelectedText = ""
        Me.GunaTextBoxDelaiPaiement.Size = New System.Drawing.Size(66, 34)
        Me.GunaTextBoxDelaiPaiement.TabIndex = 75
        Me.GunaTextBoxDelaiPaiement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(890, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(157, 16)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "DELAI DE PAIEMENT"
        '
        'GunaTextBoxPlafonds
        '
        Me.GunaTextBoxPlafonds.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPlafonds.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxPlafonds.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxPlafonds.BorderSize = 1
        Me.GunaTextBoxPlafonds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxPlafonds.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPlafonds.Enabled = False
        Me.GunaTextBoxPlafonds.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPlafonds.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPlafonds.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPlafonds.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxPlafonds.Location = New System.Drawing.Point(116, 113)
        Me.GunaTextBoxPlafonds.Name = "GunaTextBoxPlafonds"
        Me.GunaTextBoxPlafonds.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPlafonds.Radius = 5
        Me.GunaTextBoxPlafonds.SelectedText = ""
        Me.GunaTextBoxPlafonds.Size = New System.Drawing.Size(120, 34)
        Me.GunaTextBoxPlafonds.TabIndex = 75
        Me.GunaTextBoxPlafonds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 16)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "PLAFONDS "
        '
        'GunaDataGridViewListeFacture
        '
        Me.GunaDataGridViewListeFacture.AllowUserToAddRows = False
        Me.GunaDataGridViewListeFacture.AllowUserToDeleteRows = False
        Me.GunaDataGridViewListeFacture.AllowUserToResizeColumns = False
        Me.GunaDataGridViewListeFacture.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewListeFacture.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GunaDataGridViewListeFacture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewListeFacture.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewListeFacture.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewListeFacture.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewListeFacture.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewListeFacture.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.GunaDataGridViewListeFacture.ColumnHeadersHeight = 25
        Me.GunaDataGridViewListeFacture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewListeFacture.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.REFERENCE, Me.DATE_FACTURE, Me.NATURE, Me.LIBELLE, Me.LETTRAGE, Me.MONTANT, Me.MONTANT_SOLDE, Me.SOLDE, Me.CODE_CLIENT})
        Me.GunaDataGridViewListeFacture.ContextMenuStrip = Me.GunaContextMenuStripFactureARegler
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewListeFacture.DefaultCellStyle = DataGridViewCellStyle6
        Me.GunaDataGridViewListeFacture.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewListeFacture.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewListeFacture.Location = New System.Drawing.Point(9, 168)
        Me.GunaDataGridViewListeFacture.Name = "GunaDataGridViewListeFacture"
        Me.GunaDataGridViewListeFacture.ReadOnly = True
        Me.GunaDataGridViewListeFacture.RowHeadersVisible = False
        Me.GunaDataGridViewListeFacture.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewListeFacture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewListeFacture.Size = New System.Drawing.Size(1282, 249)
        Me.GunaDataGridViewListeFacture.TabIndex = 87
        Me.GunaDataGridViewListeFacture.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewListeFacture.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewListeFacture.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewListeFacture.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewListeFacture.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewListeFacture.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewListeFacture.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewListeFacture.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewListeFacture.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewListeFacture.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewListeFacture.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewListeFacture.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewListeFacture.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewListeFacture.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewListeFacture.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewListeFacture.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewListeFacture.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewListeFacture.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewListeFacture.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewListeFacture.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewListeFacture.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewListeFacture.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'REFERENCE
        '
        Me.REFERENCE.HeaderText = "REFERENCE"
        Me.REFERENCE.Name = "REFERENCE"
        Me.REFERENCE.ReadOnly = True
        Me.REFERENCE.Visible = False
        '
        'DATE_FACTURE
        '
        Me.DATE_FACTURE.HeaderText = "DATE"
        Me.DATE_FACTURE.Name = "DATE_FACTURE"
        Me.DATE_FACTURE.ReadOnly = True
        '
        'NATURE
        '
        Me.NATURE.HeaderText = "NATURE"
        Me.NATURE.Name = "NATURE"
        Me.NATURE.ReadOnly = True
        '
        'LIBELLE
        '
        Me.LIBELLE.HeaderText = "LIBELLE"
        Me.LIBELLE.Name = "LIBELLE"
        Me.LIBELLE.ReadOnly = True
        '
        'LETTRAGE
        '
        Me.LETTRAGE.HeaderText = "LETTRAGE"
        Me.LETTRAGE.Name = "LETTRAGE"
        Me.LETTRAGE.ReadOnly = True
        '
        'MONTANT
        '
        Me.MONTANT.HeaderText = "DEBIT"
        Me.MONTANT.Name = "MONTANT"
        Me.MONTANT.ReadOnly = True
        '
        'MONTANT_SOLDE
        '
        Me.MONTANT_SOLDE.HeaderText = "CREDIT"
        Me.MONTANT_SOLDE.Name = "MONTANT_SOLDE"
        Me.MONTANT_SOLDE.ReadOnly = True
        '
        'SOLDE
        '
        Me.SOLDE.HeaderText = "SOLDE"
        Me.SOLDE.Name = "SOLDE"
        Me.SOLDE.ReadOnly = True
        '
        'CODE_CLIENT
        '
        Me.CODE_CLIENT.HeaderText = "CODE_CLIENT"
        Me.CODE_CLIENT.Name = "CODE_CLIENT"
        Me.CODE_CLIENT.ReadOnly = True
        Me.CODE_CLIENT.Visible = False
        '
        'GunaContextMenuStripFactureARegler
        '
        Me.GunaContextMenuStripFactureARegler.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimerToolStripMenuItem, Me.ImprimerFactureSynthèseToolStripMenuItem, Me.TransférerToolStripMenuItem, Me.RéductionToolStripMenuItem})
        Me.GunaContextMenuStripFactureARegler.Name = "GunaContextMenuStripTransfertDeBlocNote"
        Me.GunaContextMenuStripFactureARegler.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaContextMenuStripFactureARegler.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaContextMenuStripFactureARegler.RenderStyle.ColorTable = Nothing
        Me.GunaContextMenuStripFactureARegler.RenderStyle.RoundedEdges = True
        Me.GunaContextMenuStripFactureARegler.RenderStyle.SelectionArrowColor = System.Drawing.Color.White
        Me.GunaContextMenuStripFactureARegler.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaContextMenuStripFactureARegler.RenderStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GunaContextMenuStripFactureARegler.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro
        Me.GunaContextMenuStripFactureARegler.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault
        Me.GunaContextMenuStripFactureARegler.Size = New System.Drawing.Size(216, 92)
        '
        'ImprimerToolStripMenuItem
        '
        Me.ImprimerToolStripMenuItem.Name = "ImprimerToolStripMenuItem"
        Me.ImprimerToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ImprimerToolStripMenuItem.Text = "Imprimer Facture Détaillée"
        '
        'ImprimerFactureSynthèseToolStripMenuItem
        '
        Me.ImprimerFactureSynthèseToolStripMenuItem.Name = "ImprimerFactureSynthèseToolStripMenuItem"
        Me.ImprimerFactureSynthèseToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ImprimerFactureSynthèseToolStripMenuItem.Text = "Imprimer Facture Synthèse"
        '
        'TransférerToolStripMenuItem
        '
        Me.TransférerToolStripMenuItem.Name = "TransférerToolStripMenuItem"
        Me.TransférerToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.TransférerToolStripMenuItem.Text = "Régler"
        '
        'RéductionToolStripMenuItem
        '
        Me.RéductionToolStripMenuItem.Name = "RéductionToolStripMenuItem"
        Me.RéductionToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.RéductionToolStripMenuItem.Text = "Réduction"
        '
        'GunaComboBoxNatureOperation
        '
        Me.GunaComboBoxNatureOperation.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxNatureOperation.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxNatureOperation.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxNatureOperation.BorderSize = 1
        Me.GunaComboBoxNatureOperation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxNatureOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxNatureOperation.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxNatureOperation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxNatureOperation.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxNatureOperation.FormattingEnabled = True
        Me.GunaComboBoxNatureOperation.ItemHeight = 25
        Me.GunaComboBoxNatureOperation.Items.AddRange(New Object() {"AVOIR", "REGLEMENT", "REMBOURSEMENT", "DEPOT GARANTIE", "CAUTION", "RETENUE"})
        Me.GunaComboBoxNatureOperation.Location = New System.Drawing.Point(837, 492)
        Me.GunaComboBoxNatureOperation.Name = "GunaComboBoxNatureOperation"
        Me.GunaComboBoxNatureOperation.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxNatureOperation.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxNatureOperation.Radius = 4
        Me.GunaComboBoxNatureOperation.Size = New System.Drawing.Size(154, 31)
        Me.GunaComboBoxNatureOperation.TabIndex = 77
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(834, 474)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 15)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "NATURE OPERATION"
        '
        'GunaTextBoxCodeEntreprise
        '
        Me.GunaTextBoxCodeEntreprise.AllowDrop = True
        Me.GunaTextBoxCodeEntreprise.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeEntreprise.BaseColor = System.Drawing.Color.Gray
        Me.GunaTextBoxCodeEntreprise.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeEntreprise.BorderSize = 1
        Me.GunaTextBoxCodeEntreprise.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeEntreprise.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeEntreprise.Enabled = False
        Me.GunaTextBoxCodeEntreprise.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeEntreprise.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeEntreprise.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeEntreprise.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeEntreprise.Location = New System.Drawing.Point(312, 109)
        Me.GunaTextBoxCodeEntreprise.Name = "GunaTextBoxCodeEntreprise"
        Me.GunaTextBoxCodeEntreprise.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeEntreprise.Radius = 5
        Me.GunaTextBoxCodeEntreprise.SelectedText = ""
        Me.GunaTextBoxCodeEntreprise.Size = New System.Drawing.Size(143, 25)
        Me.GunaTextBoxCodeEntreprise.TabIndex = 75
        Me.GunaTextBoxCodeEntreprise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeEntreprise.Visible = False
        '
        'GunaTextBoxCodeFacture
        '
        Me.GunaTextBoxCodeFacture.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeFacture.BaseColor = System.Drawing.Color.Gray
        Me.GunaTextBoxCodeFacture.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeFacture.BorderSize = 1
        Me.GunaTextBoxCodeFacture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeFacture.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeFacture.Enabled = False
        Me.GunaTextBoxCodeFacture.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeFacture.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeFacture.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeFacture.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeFacture.Location = New System.Drawing.Point(1142, 82)
        Me.GunaTextBoxCodeFacture.Name = "GunaTextBoxCodeFacture"
        Me.GunaTextBoxCodeFacture.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeFacture.Radius = 5
        Me.GunaTextBoxCodeFacture.SelectedText = ""
        Me.GunaTextBoxCodeFacture.Size = New System.Drawing.Size(104, 34)
        Me.GunaTextBoxCodeFacture.TabIndex = 75
        Me.GunaTextBoxCodeFacture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeFacture.Visible = False
        '
        'GunaTextBoxCodeReservation
        '
        Me.GunaTextBoxCodeReservation.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeReservation.BaseColor = System.Drawing.Color.Gray
        Me.GunaTextBoxCodeReservation.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeReservation.BorderSize = 1
        Me.GunaTextBoxCodeReservation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeReservation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeReservation.Enabled = False
        Me.GunaTextBoxCodeReservation.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeReservation.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeReservation.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeReservation.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeReservation.Location = New System.Drawing.Point(1121, 128)
        Me.GunaTextBoxCodeReservation.Name = "GunaTextBoxCodeReservation"
        Me.GunaTextBoxCodeReservation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeReservation.Radius = 5
        Me.GunaTextBoxCodeReservation.SelectedText = ""
        Me.GunaTextBoxCodeReservation.Size = New System.Drawing.Size(104, 34)
        Me.GunaTextBoxCodeReservation.TabIndex = 75
        Me.GunaTextBoxCodeReservation.Text = "CODE RESA"
        Me.GunaTextBoxCodeReservation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeReservation.Visible = False
        '
        'GunaButtonEffacerDetail
        '
        Me.GunaButtonEffacerDetail.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEffacerDetail.AnimationSpeed = 0.03!
        Me.GunaButtonEffacerDetail.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEffacerDetail.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEffacerDetail.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEffacerDetail.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEffacerDetail.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEffacerDetail.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEffacerDetail.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEffacerDetail.Image = Nothing
        Me.GunaButtonEffacerDetail.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEffacerDetail.Location = New System.Drawing.Point(520, 422)
        Me.GunaButtonEffacerDetail.Name = "GunaButtonEffacerDetail"
        Me.GunaButtonEffacerDetail.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEffacerDetail.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEffacerDetail.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEffacerDetail.OnHoverImage = Nothing
        Me.GunaButtonEffacerDetail.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEffacerDetail.Radius = 4
        Me.GunaButtonEffacerDetail.Size = New System.Drawing.Size(97, 24)
        Me.GunaButtonEffacerDetail.TabIndex = 88
        Me.GunaButtonEffacerDetail.Text = "Effacer"
        Me.GunaButtonEffacerDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel2.Location = New System.Drawing.Point(208, 425)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(163, 21)
        Me.GunaLabel2.TabIndex = 90
        Me.GunaLabel2.Text = "DETAILS DE FACTURE"
        Me.GunaLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaTextBoxChiffreAffaire
        '
        Me.GunaTextBoxChiffreAffaire.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxChiffreAffaire.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxChiffreAffaire.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxChiffreAffaire.BorderSize = 1
        Me.GunaTextBoxChiffreAffaire.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxChiffreAffaire.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxChiffreAffaire.Enabled = False
        Me.GunaTextBoxChiffreAffaire.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxChiffreAffaire.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxChiffreAffaire.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxChiffreAffaire.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxChiffreAffaire.Location = New System.Drawing.Point(1170, 444)
        Me.GunaTextBoxChiffreAffaire.Name = "GunaTextBoxChiffreAffaire"
        Me.GunaTextBoxChiffreAffaire.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxChiffreAffaire.Radius = 5
        Me.GunaTextBoxChiffreAffaire.SelectedText = ""
        Me.GunaTextBoxChiffreAffaire.Size = New System.Drawing.Size(118, 34)
        Me.GunaTextBoxChiffreAffaire.TabIndex = 75
        Me.GunaTextBoxChiffreAffaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1167, 425)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 16)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Chiffres d'affaire"
        '
        'GunaComboBoxTypeDeFiltre
        '
        Me.GunaComboBoxTypeDeFiltre.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxTypeDeFiltre.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxTypeDeFiltre.BorderColor = System.Drawing.Color.LightGray
        Me.GunaComboBoxTypeDeFiltre.BorderSize = 1
        Me.GunaComboBoxTypeDeFiltre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxTypeDeFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxTypeDeFiltre.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxTypeDeFiltre.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaComboBoxTypeDeFiltre.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxTypeDeFiltre.FormattingEnabled = True
        Me.GunaComboBoxTypeDeFiltre.ItemHeight = 30
        Me.GunaComboBoxTypeDeFiltre.Items.AddRange(New Object() {"Compte", "Entreprise", "Individuel"})
        Me.GunaComboBoxTypeDeFiltre.Location = New System.Drawing.Point(461, 31)
        Me.GunaComboBoxTypeDeFiltre.Name = "GunaComboBoxTypeDeFiltre"
        Me.GunaComboBoxTypeDeFiltre.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxTypeDeFiltre.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxTypeDeFiltre.Radius = 5
        Me.GunaComboBoxTypeDeFiltre.Size = New System.Drawing.Size(222, 36)
        Me.GunaComboBoxTypeDeFiltre.TabIndex = 92
        '
        'GunaButtonAfficherLesFacturesEtReglement
        '
        Me.GunaButtonAfficherLesFacturesEtReglement.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAfficherLesFacturesEtReglement.AnimationSpeed = 0.03!
        Me.GunaButtonAfficherLesFacturesEtReglement.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAfficherLesFacturesEtReglement.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAfficherLesFacturesEtReglement.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficherLesFacturesEtReglement.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAfficherLesFacturesEtReglement.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAfficherLesFacturesEtReglement.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAfficherLesFacturesEtReglement.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficherLesFacturesEtReglement.Image = Nothing
        Me.GunaButtonAfficherLesFacturesEtReglement.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAfficherLesFacturesEtReglement.Location = New System.Drawing.Point(1191, 130)
        Me.GunaButtonAfficherLesFacturesEtReglement.Name = "GunaButtonAfficherLesFacturesEtReglement"
        Me.GunaButtonAfficherLesFacturesEtReglement.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAfficherLesFacturesEtReglement.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAfficherLesFacturesEtReglement.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAfficherLesFacturesEtReglement.OnHoverImage = Nothing
        Me.GunaButtonAfficherLesFacturesEtReglement.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAfficherLesFacturesEtReglement.Radius = 4
        Me.GunaButtonAfficherLesFacturesEtReglement.Size = New System.Drawing.Size(97, 32)
        Me.GunaButtonAfficherLesFacturesEtReglement.TabIndex = 88
        Me.GunaButtonAfficherLesFacturesEtReglement.Text = "Afficher"
        Me.GunaButtonAfficherLesFacturesEtReglement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(804, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 16)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "Du"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1009, 138)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 16)
        Me.Label15.TabIndex = 73
        Me.Label15.Text = "Au"
        '
        'GunaDateTimePickerFin
        '
        Me.GunaDateTimePickerFin.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerFin.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerFin.BorderColor = System.Drawing.Color.LightGray
        Me.GunaDateTimePickerFin.BorderSize = 1
        Me.GunaDateTimePickerFin.CustomFormat = Nothing
        Me.GunaDateTimePickerFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerFin.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaDateTimePickerFin.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerFin.Location = New System.Drawing.Point(1039, 129)
        Me.GunaDateTimePickerFin.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerFin.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerFin.Name = "GunaDateTimePickerFin"
        Me.GunaDateTimePickerFin.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerFin.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerFin.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerFin.Radius = 5
        Me.GunaDateTimePickerFin.Size = New System.Drawing.Size(145, 32)
        Me.GunaDateTimePickerFin.TabIndex = 93
        Me.GunaDateTimePickerFin.Text = "25/04/2022"
        Me.GunaDateTimePickerFin.Value = New Date(2022, 4, 25, 18, 3, 24, 728)
        '
        'PanelSituationCaisse
        '
        Me.PanelSituationCaisse.BackColor = System.Drawing.Color.Red
        Me.PanelSituationCaisse.Controls.Add(Me.LabelSituationCaisse)
        Me.PanelSituationCaisse.Location = New System.Drawing.Point(894, 671)
        Me.PanelSituationCaisse.Name = "PanelSituationCaisse"
        Me.PanelSituationCaisse.Size = New System.Drawing.Size(146, 34)
        Me.PanelSituationCaisse.TabIndex = 96
        '
        'LabelSituationCaisse
        '
        Me.LabelSituationCaisse.AutoSize = True
        Me.LabelSituationCaisse.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSituationCaisse.Location = New System.Drawing.Point(35, 5)
        Me.LabelSituationCaisse.Name = "LabelSituationCaisse"
        Me.LabelSituationCaisse.Size = New System.Drawing.Size(20, 24)
        Me.LabelSituationCaisse.TabIndex = 0
        Me.LabelSituationCaisse.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(906, 653)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 16)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Solde en caisse"
        '
        'GunaButtonOuvertureFermeture
        '
        Me.GunaButtonOuvertureFermeture.AnimationHoverSpeed = 0.07!
        Me.GunaButtonOuvertureFermeture.AnimationSpeed = 0.03!
        Me.GunaButtonOuvertureFermeture.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonOuvertureFermeture.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonOuvertureFermeture.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonOuvertureFermeture.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonOuvertureFermeture.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonOuvertureFermeture.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonOuvertureFermeture.ForeColor = System.Drawing.Color.White
        Me.GunaButtonOuvertureFermeture.Image = Nothing
        Me.GunaButtonOuvertureFermeture.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonOuvertureFermeture.Location = New System.Drawing.Point(1046, 672)
        Me.GunaButtonOuvertureFermeture.Name = "GunaButtonOuvertureFermeture"
        Me.GunaButtonOuvertureFermeture.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonOuvertureFermeture.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonOuvertureFermeture.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonOuvertureFermeture.OnHoverImage = Nothing
        Me.GunaButtonOuvertureFermeture.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonOuvertureFermeture.Radius = 4
        Me.GunaButtonOuvertureFermeture.Size = New System.Drawing.Size(135, 34)
        Me.GunaButtonOuvertureFermeture.TabIndex = 94
        Me.GunaButtonOuvertureFermeture.Text = "Fermer Caisse"
        Me.GunaButtonOuvertureFermeture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer1
        '
        '
        'GunaTextBoxInconnu
        '
        Me.GunaTextBoxInconnu.AllowDrop = True
        Me.GunaTextBoxInconnu.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxInconnu.BaseColor = System.Drawing.Color.Gray
        Me.GunaTextBoxInconnu.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxInconnu.BorderSize = 1
        Me.GunaTextBoxInconnu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxInconnu.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxInconnu.Enabled = False
        Me.GunaTextBoxInconnu.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxInconnu.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxInconnu.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxInconnu.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxInconnu.Location = New System.Drawing.Point(312, 140)
        Me.GunaTextBoxInconnu.Name = "GunaTextBoxInconnu"
        Me.GunaTextBoxInconnu.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxInconnu.Radius = 5
        Me.GunaTextBoxInconnu.SelectedText = ""
        Me.GunaTextBoxInconnu.Size = New System.Drawing.Size(143, 25)
        Me.GunaTextBoxInconnu.TabIndex = 75
        Me.GunaTextBoxInconnu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxInconnu.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(627, 652)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(145, 16)
        Me.Label17.TabIndex = 95
        Me.Label17.Text = "Situation des dettes"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightPink
        Me.Panel1.Controls.Add(Me.LabelDettes)
        Me.Panel1.Location = New System.Drawing.Point(628, 670)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(146, 34)
        Me.Panel1.TabIndex = 96
        '
        'LabelDettes
        '
        Me.LabelDettes.AutoSize = True
        Me.LabelDettes.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDettes.Location = New System.Drawing.Point(34, 6)
        Me.LabelDettes.Name = "LabelDettes"
        Me.LabelDettes.Size = New System.Drawing.Size(20, 22)
        Me.LabelDettes.TabIndex = 0
        Me.LabelDettes.Text = "0"
        '
        'GunaButtonTransfert
        '
        Me.GunaButtonTransfert.AnimationHoverSpeed = 0.07!
        Me.GunaButtonTransfert.AnimationSpeed = 0.03!
        Me.GunaButtonTransfert.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonTransfert.BaseColor = System.Drawing.Color.DarkGreen
        Me.GunaButtonTransfert.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonTransfert.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonTransfert.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonTransfert.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonTransfert.ForeColor = System.Drawing.Color.White
        Me.GunaButtonTransfert.Image = Nothing
        Me.GunaButtonTransfert.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonTransfert.Location = New System.Drawing.Point(780, 671)
        Me.GunaButtonTransfert.Name = "GunaButtonTransfert"
        Me.GunaButtonTransfert.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonTransfert.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonTransfert.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonTransfert.OnHoverImage = Nothing
        Me.GunaButtonTransfert.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonTransfert.Radius = 4
        Me.GunaButtonTransfert.Size = New System.Drawing.Size(105, 34)
        Me.GunaButtonTransfert.TabIndex = 94
        Me.GunaButtonTransfert.Text = "Transfért Caisse"
        Me.GunaButtonTransfert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanelVirement
        '
        Me.GunaPanelVirement.Controls.Add(Me.GunaTextBoxReferenceVirement)
        Me.GunaPanelVirement.Controls.Add(Me.GunaComboBoxBanqueVirement)
        Me.GunaPanelVirement.Controls.Add(Me.Label19)
        Me.GunaPanelVirement.Controls.Add(Me.Label20)
        Me.GunaPanelVirement.Location = New System.Drawing.Point(626, 531)
        Me.GunaPanelVirement.Name = "GunaPanelVirement"
        Me.GunaPanelVirement.Size = New System.Drawing.Size(413, 118)
        Me.GunaPanelVirement.TabIndex = 82
        '
        'GunaTextBoxReferenceVirement
        '
        Me.GunaTextBoxReferenceVirement.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxReferenceVirement.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxReferenceVirement.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxReferenceVirement.BorderSize = 1
        Me.GunaTextBoxReferenceVirement.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxReferenceVirement.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxReferenceVirement.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxReferenceVirement.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxReferenceVirement.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaTextBoxReferenceVirement.Location = New System.Drawing.Point(64, 80)
        Me.GunaTextBoxReferenceVirement.Name = "GunaTextBoxReferenceVirement"
        Me.GunaTextBoxReferenceVirement.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxReferenceVirement.Radius = 5
        Me.GunaTextBoxReferenceVirement.SelectedText = ""
        Me.GunaTextBoxReferenceVirement.Size = New System.Drawing.Size(322, 30)
        Me.GunaTextBoxReferenceVirement.TabIndex = 75
        '
        'GunaComboBoxBanqueVirement
        '
        Me.GunaComboBoxBanqueVirement.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxBanqueVirement.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxBanqueVirement.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxBanqueVirement.BorderSize = 1
        Me.GunaComboBoxBanqueVirement.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxBanqueVirement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxBanqueVirement.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxBanqueVirement.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxBanqueVirement.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxBanqueVirement.FormattingEnabled = True
        Me.GunaComboBoxBanqueVirement.ItemHeight = 25
        Me.GunaComboBoxBanqueVirement.Location = New System.Drawing.Point(65, 24)
        Me.GunaComboBoxBanqueVirement.Name = "GunaComboBoxBanqueVirement"
        Me.GunaComboBoxBanqueVirement.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxBanqueVirement.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxBanqueVirement.Radius = 4
        Me.GunaComboBoxBanqueVirement.Size = New System.Drawing.Size(316, 31)
        Me.GunaComboBoxBanqueVirement.TabIndex = 85
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(61, 62)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 16)
        Me.Label19.TabIndex = 73
        Me.Label19.Text = "Référence"
        Me.Label19.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(62, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 16)
        Me.Label20.TabIndex = 74
        Me.Label20.Text = "Banque"
        Me.Label20.Visible = False
        '
        'GunaPanelAvoir
        '
        Me.GunaPanelAvoir.Controls.Add(Me.GunaTextBoxMontantAvoir)
        Me.GunaPanelAvoir.Controls.Add(Me.GunaComboBoxAvoir)
        Me.GunaPanelAvoir.Controls.Add(Me.LabelMontant)
        Me.GunaPanelAvoir.Controls.Add(Me.Label1Avoir)
        Me.GunaPanelAvoir.Location = New System.Drawing.Point(632, 531)
        Me.GunaPanelAvoir.Name = "GunaPanelAvoir"
        Me.GunaPanelAvoir.Size = New System.Drawing.Size(438, 118)
        Me.GunaPanelAvoir.TabIndex = 97
        Me.GunaPanelAvoir.Visible = False
        '
        'GunaTextBoxMontantAvoir
        '
        Me.GunaTextBoxMontantAvoir.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantAvoir.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantAvoir.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantAvoir.BorderSize = 1
        Me.GunaTextBoxMontantAvoir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantAvoir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantAvoir.Enabled = False
        Me.GunaTextBoxMontantAvoir.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantAvoir.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantAvoir.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantAvoir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxMontantAvoir.Location = New System.Drawing.Point(133, 79)
        Me.GunaTextBoxMontantAvoir.Name = "GunaTextBoxMontantAvoir"
        Me.GunaTextBoxMontantAvoir.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantAvoir.Radius = 5
        Me.GunaTextBoxMontantAvoir.SelectedText = ""
        Me.GunaTextBoxMontantAvoir.Size = New System.Drawing.Size(106, 31)
        Me.GunaTextBoxMontantAvoir.TabIndex = 92
        Me.GunaTextBoxMontantAvoir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaComboBoxAvoir
        '
        Me.GunaComboBoxAvoir.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxAvoir.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxAvoir.BorderColor = System.Drawing.Color.LightGray
        Me.GunaComboBoxAvoir.BorderSize = 1
        Me.GunaComboBoxAvoir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxAvoir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxAvoir.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxAvoir.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxAvoir.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxAvoir.FormattingEnabled = True
        Me.GunaComboBoxAvoir.ItemHeight = 25
        Me.GunaComboBoxAvoir.Location = New System.Drawing.Point(36, 37)
        Me.GunaComboBoxAvoir.Name = "GunaComboBoxAvoir"
        Me.GunaComboBoxAvoir.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxAvoir.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxAvoir.Radius = 5
        Me.GunaComboBoxAvoir.Size = New System.Drawing.Size(367, 31)
        Me.GunaComboBoxAvoir.TabIndex = 95
        '
        'LabelMontant
        '
        Me.LabelMontant.AutoSize = True
        Me.LabelMontant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMontant.Location = New System.Drawing.Point(41, 87)
        Me.LabelMontant.Name = "LabelMontant"
        Me.LabelMontant.Size = New System.Drawing.Size(83, 16)
        Me.LabelMontant.TabIndex = 93
        Me.LabelMontant.Text = "MONTANT"
        Me.LabelMontant.Visible = False
        '
        'Label1Avoir
        '
        Me.Label1Avoir.AutoSize = True
        Me.Label1Avoir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1Avoir.Location = New System.Drawing.Point(36, 18)
        Me.Label1Avoir.Name = "Label1Avoir"
        Me.Label1Avoir.Size = New System.Drawing.Size(118, 16)
        Me.Label1Avoir.TabIndex = 94
        Me.Label1Avoir.Text = "Liste des avoirs"
        Me.Label1Avoir.Visible = False
        '
        'GunaPanelPriseEncharge
        '
        Me.GunaPanelPriseEncharge.Controls.Add(Me.GunaDataGridViewCompany)
        Me.GunaPanelPriseEncharge.Controls.Add(Me.GunaTextBoxNumeroCompte)
        Me.GunaPanelPriseEncharge.Controls.Add(Me.GunaTextBoxEntreprise)
        Me.GunaPanelPriseEncharge.Controls.Add(Me.LabelNumeroCompte)
        Me.GunaPanelPriseEncharge.Controls.Add(Me.LabelEntreprise)
        Me.GunaPanelPriseEncharge.Location = New System.Drawing.Point(627, 528)
        Me.GunaPanelPriseEncharge.Name = "GunaPanelPriseEncharge"
        Me.GunaPanelPriseEncharge.Size = New System.Drawing.Size(508, 121)
        Me.GunaPanelPriseEncharge.TabIndex = 98
        Me.GunaPanelPriseEncharge.Visible = False
        '
        'GunaDataGridViewCompany
        '
        Me.GunaDataGridViewCompany.AllowUserToAddRows = False
        Me.GunaDataGridViewCompany.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewCompany.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GunaDataGridViewCompany.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GunaDataGridViewCompany.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewCompany.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewCompany.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewCompany.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewCompany.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.GunaDataGridViewCompany.ColumnHeadersHeight = 4
        Me.GunaDataGridViewCompany.ColumnHeadersVisible = False
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewCompany.DefaultCellStyle = DataGridViewCellStyle12
        Me.GunaDataGridViewCompany.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewCompany.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCompany.Location = New System.Drawing.Point(43, 60)
        Me.GunaDataGridViewCompany.MultiSelect = False
        Me.GunaDataGridViewCompany.Name = "GunaDataGridViewCompany"
        Me.GunaDataGridViewCompany.ReadOnly = True
        Me.GunaDataGridViewCompany.RowHeadersVisible = False
        Me.GunaDataGridViewCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewCompany.Size = New System.Drawing.Size(284, 85)
        Me.GunaDataGridViewCompany.TabIndex = 84
        Me.GunaDataGridViewCompany.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewCompany.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewCompany.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewCompany.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewCompany.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewCompany.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewCompany.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewCompany.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCompany.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCompany.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewCompany.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewCompany.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewCompany.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.GunaDataGridViewCompany.ThemeStyle.HeaderStyle.Height = 4
        Me.GunaDataGridViewCompany.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewCompany.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewCompany.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewCompany.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewCompany.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewCompany.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewCompany.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCompany.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewCompany.Visible = False
        '
        'GunaTextBoxNumeroCompte
        '
        Me.GunaTextBoxNumeroCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumeroCompte.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumeroCompte.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNumeroCompte.BorderSize = 1
        Me.GunaTextBoxNumeroCompte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNumeroCompte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNumeroCompte.Enabled = False
        Me.GunaTextBoxNumeroCompte.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumeroCompte.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNumeroCompte.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNumeroCompte.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNumeroCompte.Location = New System.Drawing.Point(331, 25)
        Me.GunaTextBoxNumeroCompte.Name = "GunaTextBoxNumeroCompte"
        Me.GunaTextBoxNumeroCompte.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNumeroCompte.Radius = 5
        Me.GunaTextBoxNumeroCompte.SelectedText = ""
        Me.GunaTextBoxNumeroCompte.Size = New System.Drawing.Size(139, 31)
        Me.GunaTextBoxNumeroCompte.TabIndex = 82
        Me.GunaTextBoxNumeroCompte.Visible = False
        '
        'GunaTextBoxEntreprise
        '
        Me.GunaTextBoxEntreprise.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxEntreprise.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxEntreprise.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxEntreprise.BorderSize = 1
        Me.GunaTextBoxEntreprise.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxEntreprise.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxEntreprise.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxEntreprise.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxEntreprise.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxEntreprise.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxEntreprise.Location = New System.Drawing.Point(41, 25)
        Me.GunaTextBoxEntreprise.Name = "GunaTextBoxEntreprise"
        Me.GunaTextBoxEntreprise.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxEntreprise.Radius = 5
        Me.GunaTextBoxEntreprise.SelectedText = ""
        Me.GunaTextBoxEntreprise.Size = New System.Drawing.Size(284, 31)
        Me.GunaTextBoxEntreprise.TabIndex = 83
        Me.GunaTextBoxEntreprise.Visible = False
        '
        'LabelNumeroCompte
        '
        Me.LabelNumeroCompte.AutoSize = True
        Me.LabelNumeroCompte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumeroCompte.Location = New System.Drawing.Point(330, 6)
        Me.LabelNumeroCompte.Name = "LabelNumeroCompte"
        Me.LabelNumeroCompte.Size = New System.Drawing.Size(126, 16)
        Me.LabelNumeroCompte.TabIndex = 80
        Me.LabelNumeroCompte.Text = " Compte débiteur"
        Me.LabelNumeroCompte.Visible = False
        '
        'LabelEntreprise
        '
        Me.LabelEntreprise.AutoSize = True
        Me.LabelEntreprise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEntreprise.Location = New System.Drawing.Point(39, 6)
        Me.LabelEntreprise.Name = "LabelEntreprise"
        Me.LabelEntreprise.Size = New System.Drawing.Size(79, 16)
        Me.LabelEntreprise.TabIndex = 81
        Me.LabelEntreprise.Text = "Entreprise"
        Me.LabelEntreprise.Visible = False
        '
        'GunaPanelMobileMOney
        '
        Me.GunaPanelMobileMOney.Controls.Add(Me.GunaTextBoxContact)
        Me.GunaPanelMobileMOney.Controls.Add(Me.Gunalabel56)
        Me.GunaPanelMobileMOney.Location = New System.Drawing.Point(633, 536)
        Me.GunaPanelMobileMOney.Name = "GunaPanelMobileMOney"
        Me.GunaPanelMobileMOney.Size = New System.Drawing.Size(379, 67)
        Me.GunaPanelMobileMOney.TabIndex = 99
        '
        'GunaTextBoxContact
        '
        Me.GunaTextBoxContact.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxContact.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxContact.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxContact.BorderSize = 1
        Me.GunaTextBoxContact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxContact.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxContact.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxContact.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxContact.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaTextBoxContact.Location = New System.Drawing.Point(10, 28)
        Me.GunaTextBoxContact.Name = "GunaTextBoxContact"
        Me.GunaTextBoxContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxContact.Radius = 5
        Me.GunaTextBoxContact.SelectedText = ""
        Me.GunaTextBoxContact.Size = New System.Drawing.Size(356, 30)
        Me.GunaTextBoxContact.TabIndex = 87
        '
        'Gunalabel56
        '
        Me.Gunalabel56.AutoSize = True
        Me.Gunalabel56.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gunalabel56.Location = New System.Drawing.Point(9, 8)
        Me.Gunalabel56.Name = "Gunalabel56"
        Me.Gunalabel56.Size = New System.Drawing.Size(188, 16)
        Me.Gunalabel56.TabIndex = 86
        Me.Gunalabel56.Text = "Référence de Transaction"
        Me.Gunalabel56.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(1023, 453)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 16)
        Me.Label21.TabIndex = 73
        Me.Label21.Text = "RANG : "
        '
        'LabelRang
        '
        Me.LabelRang.AutoSize = True
        Me.LabelRang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRang.Location = New System.Drawing.Point(1085, 453)
        Me.LabelRang.Name = "LabelRang"
        Me.LabelRang.Size = New System.Drawing.Size(13, 16)
        Me.LabelRang.TabIndex = 73
        Me.LabelRang.Text = "-"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(1117, 453)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(13, 16)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "/"
        '
        'LabelSur
        '
        Me.LabelSur.AutoSize = True
        Me.LabelSur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSur.Location = New System.Drawing.Point(1135, 453)
        Me.LabelSur.Name = "LabelSur"
        Me.LabelSur.Size = New System.Drawing.Size(13, 16)
        Me.LabelSur.TabIndex = 73
        Me.LabelSur.Text = "-"
        '
        'GunaPanelDepotDeGarantie
        '
        Me.GunaPanelDepotDeGarantie.Controls.Add(Me.GunaTextBoxMontantDepotDeGarantie)
        Me.GunaPanelDepotDeGarantie.Controls.Add(Me.GunaComboBoxDepotDeGarantie)
        Me.GunaPanelDepotDeGarantie.Controls.Add(Me.Label23)
        Me.GunaPanelDepotDeGarantie.Controls.Add(Me.Label24)
        Me.GunaPanelDepotDeGarantie.Location = New System.Drawing.Point(626, 531)
        Me.GunaPanelDepotDeGarantie.Name = "GunaPanelDepotDeGarantie"
        Me.GunaPanelDepotDeGarantie.Size = New System.Drawing.Size(438, 118)
        Me.GunaPanelDepotDeGarantie.TabIndex = 100
        Me.GunaPanelDepotDeGarantie.Visible = False
        '
        'GunaTextBoxMontantDepotDeGarantie
        '
        Me.GunaTextBoxMontantDepotDeGarantie.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantDepotDeGarantie.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantDepotDeGarantie.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantDepotDeGarantie.BorderSize = 1
        Me.GunaTextBoxMontantDepotDeGarantie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantDepotDeGarantie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantDepotDeGarantie.Enabled = False
        Me.GunaTextBoxMontantDepotDeGarantie.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantDepotDeGarantie.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantDepotDeGarantie.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantDepotDeGarantie.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxMontantDepotDeGarantie.Location = New System.Drawing.Point(133, 79)
        Me.GunaTextBoxMontantDepotDeGarantie.Name = "GunaTextBoxMontantDepotDeGarantie"
        Me.GunaTextBoxMontantDepotDeGarantie.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantDepotDeGarantie.Radius = 5
        Me.GunaTextBoxMontantDepotDeGarantie.SelectedText = ""
        Me.GunaTextBoxMontantDepotDeGarantie.Size = New System.Drawing.Size(106, 31)
        Me.GunaTextBoxMontantDepotDeGarantie.TabIndex = 92
        Me.GunaTextBoxMontantDepotDeGarantie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaComboBoxDepotDeGarantie
        '
        Me.GunaComboBoxDepotDeGarantie.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxDepotDeGarantie.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxDepotDeGarantie.BorderColor = System.Drawing.Color.LightGray
        Me.GunaComboBoxDepotDeGarantie.BorderSize = 1
        Me.GunaComboBoxDepotDeGarantie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxDepotDeGarantie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxDepotDeGarantie.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxDepotDeGarantie.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxDepotDeGarantie.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxDepotDeGarantie.FormattingEnabled = True
        Me.GunaComboBoxDepotDeGarantie.ItemHeight = 25
        Me.GunaComboBoxDepotDeGarantie.Location = New System.Drawing.Point(36, 40)
        Me.GunaComboBoxDepotDeGarantie.Name = "GunaComboBoxDepotDeGarantie"
        Me.GunaComboBoxDepotDeGarantie.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxDepotDeGarantie.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxDepotDeGarantie.Radius = 5
        Me.GunaComboBoxDepotDeGarantie.Size = New System.Drawing.Size(367, 31)
        Me.GunaComboBoxDepotDeGarantie.TabIndex = 95
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(41, 87)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 16)
        Me.Label23.TabIndex = 93
        Me.Label23.Text = "MONTANT"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(36, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(210, 16)
        Me.Label24.TabIndex = 94
        Me.Label24.Text = "Liste des Dépôt de Garanties"
        '
        'GunaDateTimePickerDebut
        '
        Me.GunaDateTimePickerDebut.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerDebut.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDebut.BorderColor = System.Drawing.Color.LightGray
        Me.GunaDateTimePickerDebut.BorderSize = 1
        Me.GunaDateTimePickerDebut.CustomFormat = Nothing
        Me.GunaDateTimePickerDebut.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDebut.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaDateTimePickerDebut.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerDebut.Location = New System.Drawing.Point(850, 130)
        Me.GunaDateTimePickerDebut.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDebut.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDebut.Name = "GunaDateTimePickerDebut"
        Me.GunaDateTimePickerDebut.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDebut.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDebut.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDebut.Radius = 5
        Me.GunaDateTimePickerDebut.Size = New System.Drawing.Size(145, 32)
        Me.GunaDateTimePickerDebut.TabIndex = 93
        Me.GunaDateTimePickerDebut.Text = "25/04/2022"
        Me.GunaDateTimePickerDebut.Value = New Date(2022, 4, 25, 18, 3, 24, 728)
        '
        'ReglementLettrageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 720)
        Me.Controls.Add(Me.GunaDateTimePickerDebut)
        Me.Controls.Add(Me.GunaDateTimePickerFin)
        Me.Controls.Add(Me.GunaTextBoxCodeFacture)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelSituationCaisse)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GunaButtonTransfert)
        Me.Controls.Add(Me.GunaButtonOuvertureFermeture)
        Me.Controls.Add(Me.GunaDataGridViewClient)
        Me.Controls.Add(Me.GunaComboBoxTypeDeFiltre)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaButtonAfficherLesFacturesEtReglement)
        Me.Controls.Add(Me.GunaButtonEffacerDetail)
        Me.Controls.Add(Me.GunaDataGridViewListeFacture)
        Me.Controls.Add(Me.GunaPanel3)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaComboBoxNatureOperation)
        Me.Controls.Add(Me.GunaComboBoxModeReglement)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.LabelSur)
        Me.Controls.Add(Me.LabelRang)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GunaTextBoxCodeReservation)
        Me.Controls.Add(Me.GunaTextBoxInconnu)
        Me.Controls.Add(Me.GunaTextBoxCodeEntreprise)
        Me.Controls.Add(Me.GunaTextBoxChiffreAffaire)
        Me.Controls.Add(Me.GunaTextBoxSoldeCompte)
        Me.Controls.Add(Me.GunaTextBoxDelaiPaiement)
        Me.Controls.Add(Me.GunaTextBoxContactPaiement)
        Me.Controls.Add(Me.GunaTextBoxAdressePaiement)
        Me.Controls.Add(Me.GunaTextBoxPlafonds)
        Me.Controls.Add(Me.GunaTextBoxCompteDebiteur)
        Me.Controls.Add(Me.GunaTextBoxPersonneAContacter)
        Me.Controls.Add(Me.GunaTextBoxClientAFacturer)
        Me.Controls.Add(Me.GunaTextBoxNom)
        Me.Controls.Add(Me.GunaTextBoxReference)
        Me.Controls.Add(Me.GunaTextBoxSolde)
        Me.Controls.Add(Me.GunaTextBoxMontantVerse)
        Me.Controls.Add(Me.LabelSolde)
        Me.Controls.Add(Me.GunaTextBoxAPayer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelMontantAPayer)
        Me.Controls.Add(Me.GunaDataGridViewDetailsFactures)
        Me.Controls.Add(Me.GunaButtonEnregistrerReglement)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaLabel3)
        Me.Controls.Add(Me.GunaPanelPriseEncharge)
        Me.Controls.Add(Me.GunaPanelSupplementCarte)
        Me.Controls.Add(Me.GunaPanelVirement)
        Me.Controls.Add(Me.GunaPanelSupplementCheque)
        Me.Controls.Add(Me.GunaPanelDepotDeGarantie)
        Me.Controls.Add(Me.GunaPanelAvoir)
        Me.Controls.Add(Me.GunaPanelMobileMOney)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ReglementLettrageForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClientForm"
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.GunaDataGridViewDetailsFactures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridViewClient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPanelSupplementCarte.ResumeLayout(False)
        Me.GunaPanelSupplementCarte.PerformLayout()
        Me.GunaPanelSupplementCheque.ResumeLayout(False)
        Me.GunaPanelSupplementCheque.PerformLayout()
        CType(Me.GunaDataGridViewListeFacture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaContextMenuStripFactureARegler.ResumeLayout(False)
        Me.PanelSituationCaisse.ResumeLayout(False)
        Me.PanelSituationCaisse.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GunaPanelVirement.ResumeLayout(False)
        Me.GunaPanelVirement.PerformLayout()
        Me.GunaPanelAvoir.ResumeLayout(False)
        Me.GunaPanelAvoir.PerformLayout()
        Me.GunaPanelPriseEncharge.ResumeLayout(False)
        Me.GunaPanelPriseEncharge.PerformLayout()
        CType(Me.GunaDataGridViewCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPanelMobileMOney.ResumeLayout(False)
        Me.GunaPanelMobileMOney.PerformLayout()
        Me.GunaPanelDepotDeGarantie.ResumeLayout(False)
        Me.GunaPanelDepotDeGarantie.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaButtonEnregistrerReglement As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaTextBoxAPayer As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelMontantAPayer As Label
    Friend WithEvents GunaTextBoxClientAFacturer As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNom As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewDetailsFactures As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaComboBoxModeReglement As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxReference As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxSolde As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantVerse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelSolde As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GunaDataGridViewClient As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents DateOperation As DataGridViewTextBoxColumn
    Friend WithEvents LibelleOperation As DataGridViewTextBoxColumn
    Friend WithEvents Debit As DataGridViewTextBoxColumn
    Friend WithEvents Credit As DataGridViewTextBoxColumn
    Friend WithEvents GunaPanelSupplementCarte As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaDateTimePickerDateExpiration As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents LabelDateExpiration As Label
    Friend WithEvents LabelNumCarte As Label
    Friend WithEvents LabelCVV As Label
    Friend WithEvents MaskedTextBoxNumeroCarte As MaskedTextBox
    Friend WithEvents MaskedTextBoxCVV As MaskedTextBox
    Friend WithEvents GunaPanelSupplementCheque As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxCheque As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelNumCompte As Label
    Friend WithEvents LabelBanqueEmettrice As Label
    Friend WithEvents GunaImageButtonReduce As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButtonFermer As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents Label4 As Label
    Friend WithEvents GunaTextBoxCompteDebiteur As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaPanel3 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GunaTextBoxSoldeCompte As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GunaTextBoxAdressePaiement As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxPersonneAContacter As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents GunaTextBoxDelaiPaiement As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxContactPaiement As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GunaTextBoxPlafonds As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewListeFacture As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaComboBoxNatureOperation As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GunaTextBoxCodeEntreprise As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeFacture As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeReservation As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonEffacerDetail As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaContextMenuStripFactureARegler As Guna.UI.WinForms.GunaContextMenuStrip
    Friend WithEvents TransférerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label14 As Label
    Friend WithEvents GunaTextBoxChiffreAffaire As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeDeLAvoir As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaComboBoxTypeDeFiltre As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaButtonAfficherLesFacturesEtReglement As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDateTimePickerFin As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents PanelSituationCaisse As Panel
    Friend WithEvents LabelSituationCaisse As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents GunaButtonOuvertureFermeture As Guna.UI.WinForms.GunaButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ImprimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GunaTextBoxInconnu As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelDettes As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents GunaButtonTransfert As Guna.UI.WinForms.GunaButton
    Friend WithEvents Label18 As Label
    Friend WithEvents GunaComboBoxBanque As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaComboBoxBanqueEmettrice As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaPanelVirement As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxReferenceVirement As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaComboBoxBanqueVirement As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents GunaPanelAvoir As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxMontantAvoir As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaComboBoxAvoir As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents LabelMontant As Label
    Friend WithEvents Label1Avoir As Label
    Friend WithEvents GunaPanelPriseEncharge As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaDataGridViewCompany As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaTextBoxNumeroCompte As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxEntreprise As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelNumeroCompte As Label
    Friend WithEvents LabelEntreprise As Label
    Friend WithEvents GunaPanelMobileMOney As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxContact As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Gunalabel56 As Label
    Friend WithEvents LabelRang As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents LabelSur As Label
    Friend WithEvents GunaPanelDepotDeGarantie As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxMontantDepotDeGarantie As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaComboBoxDepotDeGarantie As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents GunaDateTimePickerDebut As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents ImprimerFactureSynthèseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REFERENCE As DataGridViewTextBoxColumn
    Friend WithEvents DATE_FACTURE As DataGridViewTextBoxColumn
    Friend WithEvents NATURE As DataGridViewTextBoxColumn
    Friend WithEvents LIBELLE As DataGridViewTextBoxColumn
    Friend WithEvents LETTRAGE As DataGridViewTextBoxColumn
    Friend WithEvents MONTANT As DataGridViewTextBoxColumn
    Friend WithEvents MONTANT_SOLDE As DataGridViewTextBoxColumn
    Friend WithEvents SOLDE As DataGridViewTextBoxColumn
    Friend WithEvents CODE_CLIENT As DataGridViewTextBoxColumn
    Friend WithEvents RéductionToolStripMenuItem As ToolStripMenuItem
End Class
