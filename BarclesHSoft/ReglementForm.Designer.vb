<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReglementForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReglementForm))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButtonReduce = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButtonFermer = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxCodeClientFidele = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeElite = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxMontantDepot = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeDepot = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButtonEnregistrerReglement = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaTextBoxAPayer = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelMontantAPayer = New System.Windows.Forms.Label()
        Me.GunaDataGridViewLigneFactureReglement = New Guna.UI.WinForms.GunaDataGridView()
        Me.DateOperation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LibelleOperation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Article = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codeFacture = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaTextBoxNom = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxClientAFacturer = New Guna.UI.WinForms.GunaTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GunaSeparator1 = New Guna.UI.WinForms.GunaSeparator()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GunaTextBoxMontantVerse = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelSolde = New System.Windows.Forms.Label()
        Me.GunaTextBoxSolde = New Guna.UI.WinForms.GunaTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GunaComboBoxModereglement = New Guna.UI.WinForms.GunaComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GunaTextBoxReference = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaDataGridView2 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.LabelEntreprise = New System.Windows.Forms.Label()
        Me.LabelNumeroCompte = New System.Windows.Forms.Label()
        Me.GunaDataGridViewCompany = New Guna.UI.WinForms.GunaDataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelSituationCaisse = New System.Windows.Forms.Panel()
        Me.LabelSituationCaisse = New System.Windows.Forms.Label()
        Me.GunaPanelSupplementCarte = New Guna.UI.WinForms.GunaPanel()
        Me.MaskedTextBoxCVV = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MaskedTextBoxNumeroCarte = New System.Windows.Forms.MaskedTextBox()
        Me.GunaDateTimePickerDateExpiration = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.LabelCVV = New System.Windows.Forms.Label()
        Me.GunaTextBoxReferenceTransactionBanque = New Guna.UI.WinForms.GunaTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelDateExpiration = New System.Windows.Forms.Label()
        Me.LabelNumCarte = New System.Windows.Forms.Label()
        Me.GunaComboBoxBanque = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaPanelSupplementCheque = New Guna.UI.WinForms.GunaPanel()
        Me.GunaComboBoxBanqueEmettrice = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBoxCheque = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelNumCompte = New System.Windows.Forms.Label()
        Me.LabelBanqueEmettrice = New System.Windows.Forms.Label()
        Me.GunaCheckBoxRemboursement = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaTextBoxEntreprise = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxContact = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelContact = New System.Windows.Forms.Label()
        Me.GunaLabelBlocNoteARegler = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanelGratuite = New Guna.UI.WinForms.GunaPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GunaCheckBoxOffresEnChambre = New Guna.UI.WinForms.GunaCheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GunaComboBoxNumChambreGrat = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBoxCodeClientGrat = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeChambreGrat = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeResaGrat = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNomClientGrat = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxRemarque = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxAuthorisation = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelRemarque = New System.Windows.Forms.Label()
        Me.LabelAuthorisee = New System.Windows.Forms.Label()
        Me.GunaPanelTransfertEnChambre = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxMontantATransferer = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaComboBoxCodeChambre = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBoxCodeClient = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeReservation = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodeChambre = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNomClient = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelNomClient = New System.Windows.Forms.Label()
        Me.LabelChambre = New System.Windows.Forms.Label()
        Me.GunaTextBoxNumeroCompte = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.PanelTransfertVersCompte = New System.Windows.Forms.Panel()
        Me.PictureBoxClearArticleFields = New System.Windows.Forms.PictureBox()
        Me.GunaAdvenceButtonCodeClientDuCompte = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaComboBoxCompteIndividuelOuPaymaster = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaPanelGestCaisse = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxMontantPercu = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxMontantRendu = New Guna.UI.WinForms.GunaTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LabelMontantRendu = New System.Windows.Forms.Label()
        Me.GunaTextBoxNumFacture = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaPanelClubElite = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxValeurTotalCritere = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxValeurDuPoint = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCritere = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaComboBoxCritereElite = New Guna.UI.WinForms.GunaComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GunaCheckBoxArrhes = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaButtonDepotDeGarantie = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxRefDepot = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaDataGridViewDepot = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.GunaDataGridViewLigneFactureReglement, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaDataGridViewCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSituationCaisse.SuspendLayout()
        Me.GunaPanelSupplementCarte.SuspendLayout()
        Me.GunaPanelSupplementCheque.SuspendLayout()
        Me.GunaPanelGratuite.SuspendLayout()
        Me.GunaPanelTransfertEnChambre.SuspendLayout()
        Me.PanelTransfertVersCompte.SuspendLayout()
        CType(Me.PictureBoxClearArticleFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPanelGestCaisse.SuspendLayout()
        Me.GunaPanelClubElite.SuspendLayout()
        CType(Me.GunaDataGridViewDepot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(349, 1)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(126, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "ENCAISSEMENT"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaImageButtonReduce)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButtonFermer)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton5)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Controls.Add(Me.GunaTextBoxCodeClientFidele)
        Me.GunaPanel1.Controls.Add(Me.GunaTextBoxCodeElite)
        Me.GunaPanel1.Controls.Add(Me.GunaTextBoxMontantDepot)
        Me.GunaPanel1.Controls.Add(Me.GunaTextBoxCodeDepot)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(834, 25)
        Me.GunaPanel1.TabIndex = 2
        '
        'GunaImageButtonReduce
        '
        Me.GunaImageButtonReduce.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonReduce.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonReduce.Image = CType(resources.GetObject("GunaImageButtonReduce.Image"), System.Drawing.Image)
        Me.GunaImageButtonReduce.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButtonReduce.Location = New System.Drawing.Point(779, 3)
        Me.GunaImageButtonReduce.Name = "GunaImageButtonReduce"
        Me.GunaImageButtonReduce.OnHoverImage = Nothing
        Me.GunaImageButtonReduce.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButtonReduce.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButtonReduce.TabIndex = 11
        '
        'GunaImageButtonFermer
        '
        Me.GunaImageButtonFermer.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonFermer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonFermer.Image = CType(resources.GetObject("GunaImageButtonFermer.Image"), System.Drawing.Image)
        Me.GunaImageButtonFermer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButtonFermer.Location = New System.Drawing.Point(803, 3)
        Me.GunaImageButtonFermer.Name = "GunaImageButtonFermer"
        Me.GunaImageButtonFermer.OnHoverImage = Nothing
        Me.GunaImageButtonFermer.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButtonFermer.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButtonFermer.TabIndex = 10
        '
        'GunaImageButton5
        '
        Me.GunaImageButton5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton5.Image = Nothing
        Me.GunaImageButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton5.Location = New System.Drawing.Point(780, 3)
        Me.GunaImageButton5.Name = "GunaImageButton5"
        Me.GunaImageButton5.OnHoverImage = Nothing
        Me.GunaImageButton5.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton5.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton5.TabIndex = 9
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = Nothing
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(804, 3)
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
        Me.GunaImageButton3.Location = New System.Drawing.Point(800, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(800, 3)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 6
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(799, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2001, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaTextBoxCodeClientFidele
        '
        Me.GunaTextBoxCodeClientFidele.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeClientFidele.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeClientFidele.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeClientFidele.BorderSize = 1
        Me.GunaTextBoxCodeClientFidele.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeClientFidele.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeClientFidele.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeClientFidele.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeClientFidele.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeClientFidele.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeClientFidele.Location = New System.Drawing.Point(191, 1)
        Me.GunaTextBoxCodeClientFidele.Name = "GunaTextBoxCodeClientFidele"
        Me.GunaTextBoxCodeClientFidele.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeClientFidele.Radius = 5
        Me.GunaTextBoxCodeClientFidele.SelectedText = ""
        Me.GunaTextBoxCodeClientFidele.Size = New System.Drawing.Size(126, 25)
        Me.GunaTextBoxCodeClientFidele.TabIndex = 74
        Me.GunaTextBoxCodeClientFidele.Visible = False
        '
        'GunaTextBoxCodeElite
        '
        Me.GunaTextBoxCodeElite.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeElite.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeElite.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeElite.BorderSize = 1
        Me.GunaTextBoxCodeElite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeElite.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeElite.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeElite.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeElite.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeElite.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeElite.Location = New System.Drawing.Point(33, 0)
        Me.GunaTextBoxCodeElite.Name = "GunaTextBoxCodeElite"
        Me.GunaTextBoxCodeElite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeElite.Radius = 5
        Me.GunaTextBoxCodeElite.SelectedText = ""
        Me.GunaTextBoxCodeElite.Size = New System.Drawing.Size(126, 25)
        Me.GunaTextBoxCodeElite.TabIndex = 74
        Me.GunaTextBoxCodeElite.Visible = False
        '
        'GunaTextBoxMontantDepot
        '
        Me.GunaTextBoxMontantDepot.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantDepot.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantDepot.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantDepot.BorderSize = 1
        Me.GunaTextBoxMontantDepot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantDepot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantDepot.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantDepot.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantDepot.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantDepot.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxMontantDepot.Location = New System.Drawing.Point(570, 1)
        Me.GunaTextBoxMontantDepot.Name = "GunaTextBoxMontantDepot"
        Me.GunaTextBoxMontantDepot.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantDepot.Radius = 5
        Me.GunaTextBoxMontantDepot.SelectedText = ""
        Me.GunaTextBoxMontantDepot.Size = New System.Drawing.Size(99, 25)
        Me.GunaTextBoxMontantDepot.TabIndex = 74
        Me.GunaTextBoxMontantDepot.Visible = False
        '
        'GunaTextBoxCodeDepot
        '
        Me.GunaTextBoxCodeDepot.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeDepot.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeDepot.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeDepot.BorderSize = 1
        Me.GunaTextBoxCodeDepot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeDepot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeDepot.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeDepot.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeDepot.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeDepot.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeDepot.Location = New System.Drawing.Point(675, 1)
        Me.GunaTextBoxCodeDepot.Name = "GunaTextBoxCodeDepot"
        Me.GunaTextBoxCodeDepot.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeDepot.Radius = 5
        Me.GunaTextBoxCodeDepot.SelectedText = ""
        Me.GunaTextBoxCodeDepot.Size = New System.Drawing.Size(99, 25)
        Me.GunaTextBoxCodeDepot.TabIndex = 74
        Me.GunaTextBoxCodeDepot.Visible = False
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
        Me.GunaButtonEnregistrerReglement.Location = New System.Drawing.Point(702, 701)
        Me.GunaButtonEnregistrerReglement.Name = "GunaButtonEnregistrerReglement"
        Me.GunaButtonEnregistrerReglement.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrerReglement.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerReglement.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerReglement.OnHoverImage = Nothing
        Me.GunaButtonEnregistrerReglement.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerReglement.Radius = 4
        Me.GunaButtonEnregistrerReglement.Size = New System.Drawing.Size(116, 37)
        Me.GunaButtonEnregistrerReglement.TabIndex = 7
        Me.GunaButtonEnregistrerReglement.Text = "Encaisser"
        Me.GunaButtonEnregistrerReglement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButton1.Location = New System.Drawing.Point(86, 627)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(121, 37)
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
        Me.GunaTextBoxAPayer.Location = New System.Drawing.Point(634, 416)
        Me.GunaTextBoxAPayer.Name = "GunaTextBoxAPayer"
        Me.GunaTextBoxAPayer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAPayer.Radius = 5
        Me.GunaTextBoxAPayer.SelectedText = ""
        Me.GunaTextBoxAPayer.Size = New System.Drawing.Size(184, 31)
        Me.GunaTextBoxAPayer.TabIndex = 72
        Me.GunaTextBoxAPayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelMontantAPayer
        '
        Me.LabelMontantAPayer.AutoSize = True
        Me.LabelMontantAPayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMontantAPayer.Location = New System.Drawing.Point(471, 423)
        Me.LabelMontantAPayer.Name = "LabelMontantAPayer"
        Me.LabelMontantAPayer.Size = New System.Drawing.Size(120, 16)
        Me.LabelMontantAPayer.TabIndex = 70
        Me.LabelMontantAPayer.Text = "Montant à Payer"
        '
        'GunaDataGridViewLigneFactureReglement
        '
        Me.GunaDataGridViewLigneFactureReglement.AllowUserToAddRows = False
        Me.GunaDataGridViewLigneFactureReglement.AllowUserToDeleteRows = False
        Me.GunaDataGridViewLigneFactureReglement.AllowUserToResizeColumns = False
        Me.GunaDataGridViewLigneFactureReglement.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GunaDataGridViewLigneFactureReglement.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.GunaDataGridViewLigneFactureReglement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewLigneFactureReglement.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewLigneFactureReglement.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewLigneFactureReglement.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewLigneFactureReglement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewLigneFactureReglement.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.GunaDataGridViewLigneFactureReglement.ColumnHeadersHeight = 25
        Me.GunaDataGridViewLigneFactureReglement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewLigneFactureReglement.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateOperation, Me.LibelleOperation, Me.Debit, Me.Credit, Me.Article, Me.codeFacture, Me.Id})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(225, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewLigneFactureReglement.DefaultCellStyle = DataGridViewCellStyle13
        Me.GunaDataGridViewLigneFactureReglement.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewLigneFactureReglement.GridColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GunaDataGridViewLigneFactureReglement.Location = New System.Drawing.Point(9, 113)
        Me.GunaDataGridViewLigneFactureReglement.Name = "GunaDataGridViewLigneFactureReglement"
        Me.GunaDataGridViewLigneFactureReglement.ReadOnly = True
        Me.GunaDataGridViewLigneFactureReglement.RowHeadersVisible = False
        Me.GunaDataGridViewLigneFactureReglement.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewLigneFactureReglement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewLigneFactureReglement.Size = New System.Drawing.Size(810, 248)
        Me.GunaDataGridViewLigneFactureReglement.TabIndex = 17
        Me.GunaDataGridViewLigneFactureReglement.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Turquoise
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GunaDataGridViewLigneFactureReglement.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'DateOperation
        '
        Me.DateOperation.HeaderText = "Date Opération"
        Me.DateOperation.Name = "DateOperation"
        Me.DateOperation.ReadOnly = True
        Me.DateOperation.Visible = False
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
        'Article
        '
        Me.Article.HeaderText = "Article"
        Me.Article.Name = "Article"
        Me.Article.ReadOnly = True
        Me.Article.Visible = False
        '
        'codeFacture
        '
        Me.codeFacture.HeaderText = "Code"
        Me.codeFacture.Name = "codeFacture"
        Me.codeFacture.ReadOnly = True
        Me.codeFacture.Visible = False
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
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
        Me.GunaTextBoxNom.Location = New System.Drawing.Point(98, 57)
        Me.GunaTextBoxNom.Name = "GunaTextBoxNom"
        Me.GunaTextBoxNom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNom.Radius = 5
        Me.GunaTextBoxNom.SelectedText = ""
        Me.GunaTextBoxNom.Size = New System.Drawing.Size(143, 34)
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
        Me.GunaTextBoxClientAFacturer.Location = New System.Drawing.Point(247, 57)
        Me.GunaTextBoxClientAFacturer.Name = "GunaTextBoxClientAFacturer"
        Me.GunaTextBoxClientAFacturer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxClientAFacturer.Radius = 5
        Me.GunaTextBoxClientAFacturer.SelectedText = ""
        Me.GunaTextBoxClientAFacturer.Size = New System.Drawing.Size(575, 34)
        Me.GunaTextBoxClientAFacturer.TabIndex = 75
        Me.GunaTextBoxClientAFacturer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Client"
        '
        'GunaSeparator1
        '
        Me.GunaSeparator1.BackColor = System.Drawing.SystemColors.Control
        Me.GunaSeparator1.LineColor = System.Drawing.Color.White
        Me.GunaSeparator1.Location = New System.Drawing.Point(14, 97)
        Me.GunaSeparator1.Name = "GunaSeparator1"
        Me.GunaSeparator1.Size = New System.Drawing.Size(808, 10)
        Me.GunaSeparator1.TabIndex = 76
        Me.GunaSeparator1.Thickness = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(484, 461)
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
        Me.GunaTextBoxMontantVerse.Location = New System.Drawing.Point(634, 453)
        Me.GunaTextBoxMontantVerse.Name = "GunaTextBoxMontantVerse"
        Me.GunaTextBoxMontantVerse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantVerse.Radius = 5
        Me.GunaTextBoxMontantVerse.SelectedText = ""
        Me.GunaTextBoxMontantVerse.Size = New System.Drawing.Size(184, 30)
        Me.GunaTextBoxMontantVerse.TabIndex = 72
        Me.GunaTextBoxMontantVerse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelSolde
        '
        Me.LabelSolde.AutoSize = True
        Me.LabelSolde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSolde.Location = New System.Drawing.Point(485, 610)
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
        Me.GunaTextBoxSolde.Enabled = False
        Me.GunaTextBoxSolde.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxSolde.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxSolde.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxSolde.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxSolde.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxSolde.Location = New System.Drawing.Point(634, 603)
        Me.GunaTextBoxSolde.Name = "GunaTextBoxSolde"
        Me.GunaTextBoxSolde.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxSolde.Radius = 5
        Me.GunaTextBoxSolde.SelectedText = ""
        Me.GunaTextBoxSolde.Size = New System.Drawing.Size(184, 31)
        Me.GunaTextBoxSolde.TabIndex = 72
        Me.GunaTextBoxSolde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 470)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 16)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Mode de Règlement"
        '
        'GunaComboBoxModereglement
        '
        Me.GunaComboBoxModereglement.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxModereglement.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxModereglement.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxModereglement.BorderSize = 1
        Me.GunaComboBoxModereglement.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxModereglement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxModereglement.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxModereglement.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxModereglement.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxModereglement.FormattingEnabled = True
        Me.GunaComboBoxModereglement.ItemHeight = 25
        Me.GunaComboBoxModereglement.Items.AddRange(New Object() {"Espèce", "Chèque", "Carte Bancaire", "Prise en charge", "MTN Money", "ORANGE Money", "Gratuitée", "Transfert En chambre", "Transfert Vers Compte Débiteur", "Virement Bancaire"})
        Me.GunaComboBoxModereglement.Location = New System.Drawing.Point(10, 489)
        Me.GunaComboBoxModereglement.Name = "GunaComboBoxModereglement"
        Me.GunaComboBoxModereglement.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxModereglement.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxModereglement.Radius = 4
        Me.GunaComboBoxModereglement.Size = New System.Drawing.Size(295, 31)
        Me.GunaComboBoxModereglement.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 413)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Référence"
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
        Me.GunaTextBoxReference.Location = New System.Drawing.Point(10, 432)
        Me.GunaTextBoxReference.Name = "GunaTextBoxReference"
        Me.GunaTextBoxReference.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxReference.Radius = 5
        Me.GunaTextBoxReference.SelectedText = ""
        Me.GunaTextBoxReference.Size = New System.Drawing.Size(443, 31)
        Me.GunaTextBoxReference.TabIndex = 72
        '
        'GunaDataGridView2
        '
        Me.GunaDataGridView2.AllowUserToAddRows = False
        Me.GunaDataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.GunaDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.GunaDataGridView2.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.GunaDataGridView2.ColumnHeadersHeight = 4
        Me.GunaDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView2.ColumnHeadersVisible = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView2.DefaultCellStyle = DataGridViewCellStyle10
        Me.GunaDataGridView2.EnableHeadersVisualStyles = False
        Me.GunaDataGridView2.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.Location = New System.Drawing.Point(67, 94)
        Me.GunaDataGridView2.MultiSelect = False
        Me.GunaDataGridView2.Name = "GunaDataGridView2"
        Me.GunaDataGridView2.ReadOnly = True
        Me.GunaDataGridView2.RowHeadersVisible = False
        Me.GunaDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView2.Size = New System.Drawing.Size(288, 119)
        Me.GunaDataGridView2.TabIndex = 17
        Me.GunaDataGridView2.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView2.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.Height = 4
        Me.GunaDataGridView2.ThemeStyle.ReadOnly = True
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridView2.Visible = False
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(-1, 743)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(841, 10)
        Me.GunaPanel2.TabIndex = 78
        '
        'LabelEntreprise
        '
        Me.LabelEntreprise.AutoSize = True
        Me.LabelEntreprise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEntreprise.Location = New System.Drawing.Point(7, 5)
        Me.LabelEntreprise.Name = "LabelEntreprise"
        Me.LabelEntreprise.Size = New System.Drawing.Size(79, 16)
        Me.LabelEntreprise.TabIndex = 70
        Me.LabelEntreprise.Text = "Entreprise"
        Me.LabelEntreprise.Visible = False
        '
        'LabelNumeroCompte
        '
        Me.LabelNumeroCompte.AutoSize = True
        Me.LabelNumeroCompte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumeroCompte.Location = New System.Drawing.Point(302, 5)
        Me.LabelNumeroCompte.Name = "LabelNumeroCompte"
        Me.LabelNumeroCompte.Size = New System.Drawing.Size(126, 16)
        Me.LabelNumeroCompte.TabIndex = 70
        Me.LabelNumeroCompte.Text = " Compte débiteur"
        Me.LabelNumeroCompte.Visible = False
        '
        'GunaDataGridViewCompany
        '
        Me.GunaDataGridViewCompany.AllowUserToAddRows = False
        Me.GunaDataGridViewCompany.AllowUserToDeleteRows = False
        Me.GunaDataGridViewCompany.AllowUserToResizeColumns = False
        Me.GunaDataGridViewCompany.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewCompany.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GunaDataGridViewCompany.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GunaDataGridViewCompany.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewCompany.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewCompany.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewCompany.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.GunaDataGridViewCompany.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewCompany.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GunaDataGridViewCompany.ColumnHeadersHeight = 4
        Me.GunaDataGridViewCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewCompany.ColumnHeadersVisible = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewCompany.DefaultCellStyle = DataGridViewCellStyle7
        Me.GunaDataGridViewCompany.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewCompany.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewCompany.Location = New System.Drawing.Point(8, 56)
        Me.GunaDataGridViewCompany.MultiSelect = False
        Me.GunaDataGridViewCompany.Name = "GunaDataGridViewCompany"
        Me.GunaDataGridViewCompany.ReadOnly = True
        Me.GunaDataGridViewCompany.RowHeadersVisible = False
        Me.GunaDataGridViewCompany.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewCompany.Size = New System.Drawing.Size(284, 155)
        Me.GunaDataGridViewCompany.TabIndex = 79
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
        Me.GunaDataGridViewCompany.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(519, 685)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Situation Caisse"
        '
        'PanelSituationCaisse
        '
        Me.PanelSituationCaisse.BackColor = System.Drawing.Color.Pink
        Me.PanelSituationCaisse.Controls.Add(Me.LabelSituationCaisse)
        Me.PanelSituationCaisse.Location = New System.Drawing.Point(504, 704)
        Me.PanelSituationCaisse.Name = "PanelSituationCaisse"
        Me.PanelSituationCaisse.Size = New System.Drawing.Size(146, 34)
        Me.PanelSituationCaisse.TabIndex = 80
        '
        'LabelSituationCaisse
        '
        Me.LabelSituationCaisse.AutoSize = True
        Me.LabelSituationCaisse.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSituationCaisse.Location = New System.Drawing.Point(57, 5)
        Me.LabelSituationCaisse.Name = "LabelSituationCaisse"
        Me.LabelSituationCaisse.Size = New System.Drawing.Size(20, 24)
        Me.LabelSituationCaisse.TabIndex = 0
        Me.LabelSituationCaisse.Text = "0"
        '
        'GunaPanelSupplementCarte
        '
        Me.GunaPanelSupplementCarte.Controls.Add(Me.MaskedTextBoxCVV)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.Label7)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.MaskedTextBoxNumeroCarte)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.GunaDateTimePickerDateExpiration)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.LabelCVV)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.GunaTextBoxReferenceTransactionBanque)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.Label4)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.LabelDateExpiration)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.LabelNumCarte)
        Me.GunaPanelSupplementCarte.Controls.Add(Me.GunaComboBoxBanque)
        Me.GunaPanelSupplementCarte.Location = New System.Drawing.Point(16, 528)
        Me.GunaPanelSupplementCarte.Name = "GunaPanelSupplementCarte"
        Me.GunaPanelSupplementCarte.Size = New System.Drawing.Size(428, 145)
        Me.GunaPanelSupplementCarte.TabIndex = 81
        Me.GunaPanelSupplementCarte.Visible = False
        '
        'MaskedTextBoxCVV
        '
        Me.MaskedTextBoxCVV.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBoxCVV.Location = New System.Drawing.Point(189, 24)
        Me.MaskedTextBoxCVV.Mask = "000"
        Me.MaskedTextBoxCVV.Name = "MaskedTextBoxCVV"
        Me.MaskedTextBoxCVV.Size = New System.Drawing.Size(155, 24)
        Me.MaskedTextBoxCVV.TabIndex = 78
        Me.MaskedTextBoxCVV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaskedTextBoxCVV.ValidatingType = GetType(Integer)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 16)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Banque"
        Me.Label7.Visible = False
        '
        'MaskedTextBoxNumeroCarte
        '
        Me.MaskedTextBoxNumeroCarte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBoxNumeroCarte.Location = New System.Drawing.Point(23, 25)
        Me.MaskedTextBoxNumeroCarte.Mask = "0000000000000000"
        Me.MaskedTextBoxNumeroCarte.Name = "MaskedTextBoxNumeroCarte"
        Me.MaskedTextBoxNumeroCarte.Size = New System.Drawing.Size(155, 24)
        Me.MaskedTextBoxNumeroCarte.TabIndex = 78
        Me.MaskedTextBoxNumeroCarte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaskedTextBoxNumeroCarte.ValidatingType = GetType(Integer)
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
        Me.GunaDateTimePickerDateExpiration.Location = New System.Drawing.Point(20, 73)
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
        Me.LabelCVV.Location = New System.Drawing.Point(186, 5)
        Me.LabelCVV.Name = "LabelCVV"
        Me.LabelCVV.Size = New System.Drawing.Size(38, 16)
        Me.LabelCVV.TabIndex = 73
        Me.LabelCVV.Text = "CVV"
        Me.LabelCVV.Visible = False
        '
        'GunaTextBoxReferenceTransactionBanque
        '
        Me.GunaTextBoxReferenceTransactionBanque.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxReferenceTransactionBanque.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxReferenceTransactionBanque.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTextBoxReferenceTransactionBanque.BorderSize = 1
        Me.GunaTextBoxReferenceTransactionBanque.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxReferenceTransactionBanque.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxReferenceTransactionBanque.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxReferenceTransactionBanque.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxReferenceTransactionBanque.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaTextBoxReferenceTransactionBanque.Location = New System.Drawing.Point(197, 75)
        Me.GunaTextBoxReferenceTransactionBanque.Name = "GunaTextBoxReferenceTransactionBanque"
        Me.GunaTextBoxReferenceTransactionBanque.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxReferenceTransactionBanque.Radius = 5
        Me.GunaTextBoxReferenceTransactionBanque.SelectedText = ""
        Me.GunaTextBoxReferenceTransactionBanque.Size = New System.Drawing.Size(213, 28)
        Me.GunaTextBoxReferenceTransactionBanque.TabIndex = 85
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(194, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(188, 16)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Référence de Transaction"
        '
        'LabelDateExpiration
        '
        Me.LabelDateExpiration.AutoSize = True
        Me.LabelDateExpiration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDateExpiration.Location = New System.Drawing.Point(20, 54)
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
        Me.LabelNumCarte.Location = New System.Drawing.Point(21, 6)
        Me.LabelNumCarte.Name = "LabelNumCarte"
        Me.LabelNumCarte.Size = New System.Drawing.Size(123, 16)
        Me.LabelNumCarte.TabIndex = 74
        Me.LabelNumCarte.Text = "Numéro de carte"
        Me.LabelNumCarte.Visible = False
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
        Me.GunaComboBoxBanque.Location = New System.Drawing.Point(82, 109)
        Me.GunaComboBoxBanque.Name = "GunaComboBoxBanque"
        Me.GunaComboBoxBanque.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxBanque.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxBanque.Radius = 4
        Me.GunaComboBoxBanque.Size = New System.Drawing.Size(256, 31)
        Me.GunaComboBoxBanque.TabIndex = 77
        '
        'GunaPanelSupplementCheque
        '
        Me.GunaPanelSupplementCheque.Controls.Add(Me.GunaComboBoxBanqueEmettrice)
        Me.GunaPanelSupplementCheque.Controls.Add(Me.GunaTextBoxCheque)
        Me.GunaPanelSupplementCheque.Controls.Add(Me.LabelNumCompte)
        Me.GunaPanelSupplementCheque.Controls.Add(Me.LabelBanqueEmettrice)
        Me.GunaPanelSupplementCheque.Location = New System.Drawing.Point(16, 527)
        Me.GunaPanelSupplementCheque.Name = "GunaPanelSupplementCheque"
        Me.GunaPanelSupplementCheque.Size = New System.Drawing.Size(428, 114)
        Me.GunaPanelSupplementCheque.TabIndex = 82
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
        Me.GunaComboBoxBanqueEmettrice.Items.AddRange(New Object() {"Espèce", "Chèque", "Carte de crédit", "Prise en charge", "MTN Money", "ORANGE Money", "Gratuitée", "Transfert En chambre", "Transfert Vers Compte Débiteur"})
        Me.GunaComboBoxBanqueEmettrice.Location = New System.Drawing.Point(24, 22)
        Me.GunaComboBoxBanqueEmettrice.Name = "GunaComboBoxBanqueEmettrice"
        Me.GunaComboBoxBanqueEmettrice.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxBanqueEmettrice.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxBanqueEmettrice.Radius = 4
        Me.GunaComboBoxBanqueEmettrice.Size = New System.Drawing.Size(256, 31)
        Me.GunaComboBoxBanqueEmettrice.TabIndex = 78
        '
        'GunaTextBoxCheque
        '
        Me.GunaTextBoxCheque.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCheque.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCheque.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTextBoxCheque.BorderSize = 1
        Me.GunaTextBoxCheque.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCheque.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCheque.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCheque.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCheque.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaTextBoxCheque.Location = New System.Drawing.Point(23, 80)
        Me.GunaTextBoxCheque.Name = "GunaTextBoxCheque"
        Me.GunaTextBoxCheque.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCheque.Radius = 5
        Me.GunaTextBoxCheque.SelectedText = ""
        Me.GunaTextBoxCheque.Size = New System.Drawing.Size(257, 30)
        Me.GunaTextBoxCheque.TabIndex = 75
        '
        'LabelNumCompte
        '
        Me.LabelNumCompte.AutoSize = True
        Me.LabelNumCompte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumCompte.Location = New System.Drawing.Point(20, 62)
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
        Me.LabelBanqueEmettrice.Location = New System.Drawing.Point(21, 3)
        Me.LabelBanqueEmettrice.Name = "LabelBanqueEmettrice"
        Me.LabelBanqueEmettrice.Size = New System.Drawing.Size(130, 16)
        Me.LabelBanqueEmettrice.TabIndex = 74
        Me.LabelBanqueEmettrice.Text = "Banque Emettrice"
        Me.LabelBanqueEmettrice.Visible = False
        '
        'GunaCheckBoxRemboursement
        '
        Me.GunaCheckBoxRemboursement.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxRemboursement.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxRemboursement.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxRemboursement.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxRemboursement.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxRemboursement.Location = New System.Drawing.Point(315, 498)
        Me.GunaCheckBoxRemboursement.Name = "GunaCheckBoxRemboursement"
        Me.GunaCheckBoxRemboursement.Size = New System.Drawing.Size(136, 20)
        Me.GunaCheckBoxRemboursement.TabIndex = 83
        Me.GunaCheckBoxRemboursement.Text = "Remboursement"
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
        Me.GunaTextBoxEntreprise.Location = New System.Drawing.Point(10, 24)
        Me.GunaTextBoxEntreprise.Name = "GunaTextBoxEntreprise"
        Me.GunaTextBoxEntreprise.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxEntreprise.Radius = 5
        Me.GunaTextBoxEntreprise.SelectedText = ""
        Me.GunaTextBoxEntreprise.Size = New System.Drawing.Size(258, 31)
        Me.GunaTextBoxEntreprise.TabIndex = 72
        Me.GunaTextBoxEntreprise.Visible = False
        '
        'GunaTextBoxContact
        '
        Me.GunaTextBoxContact.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxContact.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxContact.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTextBoxContact.BorderSize = 1
        Me.GunaTextBoxContact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxContact.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxContact.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxContact.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxContact.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaTextBoxContact.Location = New System.Drawing.Point(45, 558)
        Me.GunaTextBoxContact.Name = "GunaTextBoxContact"
        Me.GunaTextBoxContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxContact.Radius = 5
        Me.GunaTextBoxContact.SelectedText = ""
        Me.GunaTextBoxContact.Size = New System.Drawing.Size(231, 30)
        Me.GunaTextBoxContact.TabIndex = 85
        '
        'LabelContact
        '
        Me.LabelContact.AutoSize = True
        Me.LabelContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelContact.Location = New System.Drawing.Point(42, 537)
        Me.LabelContact.Name = "LabelContact"
        Me.LabelContact.Size = New System.Drawing.Size(188, 16)
        Me.LabelContact.TabIndex = 84
        Me.LabelContact.Text = "Référence de Transaction"
        Me.LabelContact.Visible = False
        '
        'GunaLabelBlocNoteARegler
        '
        Me.GunaLabelBlocNoteARegler.AutoSize = True
        Me.GunaLabelBlocNoteARegler.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelBlocNoteARegler.ForeColor = System.Drawing.Color.Black
        Me.GunaLabelBlocNoteARegler.Location = New System.Drawing.Point(349, 31)
        Me.GunaLabelBlocNoteARegler.Name = "GunaLabelBlocNoteARegler"
        Me.GunaLabelBlocNoteARegler.Size = New System.Drawing.Size(97, 21)
        Me.GunaLabelBlocNoteARegler.TabIndex = 4
        Me.GunaLabelBlocNoteARegler.Text = "BLOC_NOTE"
        Me.GunaLabelBlocNoteARegler.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.GunaLabelBlocNoteARegler.Visible = False
        '
        'GunaPanelGratuite
        '
        Me.GunaPanelGratuite.Controls.Add(Me.Label11)
        Me.GunaPanelGratuite.Controls.Add(Me.GunaCheckBoxOffresEnChambre)
        Me.GunaPanelGratuite.Controls.Add(Me.Label10)
        Me.GunaPanelGratuite.Controls.Add(Me.Label9)
        Me.GunaPanelGratuite.Controls.Add(Me.GunaComboBoxNumChambreGrat)
        Me.GunaPanelGratuite.Controls.Add(Me.GunaTextBoxCodeClientGrat)
        Me.GunaPanelGratuite.Controls.Add(Me.GunaTextBoxCodeChambreGrat)
        Me.GunaPanelGratuite.Controls.Add(Me.GunaTextBoxCodeResaGrat)
        Me.GunaPanelGratuite.Controls.Add(Me.GunaTextBoxNomClientGrat)
        Me.GunaPanelGratuite.Controls.Add(Me.GunaTextBoxRemarque)
        Me.GunaPanelGratuite.Controls.Add(Me.GunaTextBoxAuthorisation)
        Me.GunaPanelGratuite.Controls.Add(Me.LabelRemarque)
        Me.GunaPanelGratuite.Controls.Add(Me.LabelAuthorisee)
        Me.GunaPanelGratuite.Location = New System.Drawing.Point(16, 528)
        Me.GunaPanelGratuite.Name = "GunaPanelGratuite"
        Me.GunaPanelGratuite.Size = New System.Drawing.Size(339, 210)
        Me.GunaPanelGratuite.TabIndex = 86
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(4, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 24)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "*"
        '
        'GunaCheckBoxOffresEnChambre
        '
        Me.GunaCheckBoxOffresEnChambre.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxOffresEnChambre.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxOffresEnChambre.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxOffresEnChambre.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxOffresEnChambre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxOffresEnChambre.Location = New System.Drawing.Point(32, 122)
        Me.GunaCheckBoxOffresEnChambre.Name = "GunaCheckBoxOffresEnChambre"
        Me.GunaCheckBoxOffresEnChambre.Size = New System.Drawing.Size(107, 20)
        Me.GunaCheckBoxOffresEnChambre.TabIndex = 98
        Me.GunaCheckBoxOffresEnChambre.Text = "En chambre"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 16)
        Me.Label10.TabIndex = 97
        Me.Label10.Text = "Nom du client"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(167, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 96
        Me.Label9.Text = "N°"
        Me.Label9.Visible = False
        '
        'GunaComboBoxNumChambreGrat
        '
        Me.GunaComboBoxNumChambreGrat.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxNumChambreGrat.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxNumChambreGrat.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxNumChambreGrat.BorderSize = 1
        Me.GunaComboBoxNumChambreGrat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxNumChambreGrat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxNumChambreGrat.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxNumChambreGrat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaComboBoxNumChambreGrat.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxNumChambreGrat.FormattingEnabled = True
        Me.GunaComboBoxNumChambreGrat.ItemHeight = 25
        Me.GunaComboBoxNumChambreGrat.Location = New System.Drawing.Point(197, 117)
        Me.GunaComboBoxNumChambreGrat.Name = "GunaComboBoxNumChambreGrat"
        Me.GunaComboBoxNumChambreGrat.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxNumChambreGrat.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxNumChambreGrat.Radius = 5
        Me.GunaComboBoxNumChambreGrat.Size = New System.Drawing.Size(129, 31)
        Me.GunaComboBoxNumChambreGrat.TabIndex = 94
        Me.GunaComboBoxNumChambreGrat.Visible = False
        '
        'GunaTextBoxCodeClientGrat
        '
        Me.GunaTextBoxCodeClientGrat.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeClientGrat.BaseColor = System.Drawing.Color.DimGray
        Me.GunaTextBoxCodeClientGrat.BorderColor = System.Drawing.Color.DarkGray
        Me.GunaTextBoxCodeClientGrat.BorderSize = 1
        Me.GunaTextBoxCodeClientGrat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeClientGrat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeClientGrat.Enabled = False
        Me.GunaTextBoxCodeClientGrat.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeClientGrat.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeClientGrat.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeClientGrat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeClientGrat.Location = New System.Drawing.Point(273, 175)
        Me.GunaTextBoxCodeClientGrat.Name = "GunaTextBoxCodeClientGrat"
        Me.GunaTextBoxCodeClientGrat.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeClientGrat.Radius = 5
        Me.GunaTextBoxCodeClientGrat.SelectedText = ""
        Me.GunaTextBoxCodeClientGrat.Size = New System.Drawing.Size(57, 28)
        Me.GunaTextBoxCodeClientGrat.TabIndex = 90
        Me.GunaTextBoxCodeClientGrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeClientGrat.Visible = False
        '
        'GunaTextBoxCodeChambreGrat
        '
        Me.GunaTextBoxCodeChambreGrat.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeChambreGrat.BaseColor = System.Drawing.Color.DimGray
        Me.GunaTextBoxCodeChambreGrat.BorderColor = System.Drawing.Color.DarkGray
        Me.GunaTextBoxCodeChambreGrat.BorderSize = 1
        Me.GunaTextBoxCodeChambreGrat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeChambreGrat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeChambreGrat.Enabled = False
        Me.GunaTextBoxCodeChambreGrat.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeChambreGrat.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeChambreGrat.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeChambreGrat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeChambreGrat.Location = New System.Drawing.Point(215, 175)
        Me.GunaTextBoxCodeChambreGrat.Name = "GunaTextBoxCodeChambreGrat"
        Me.GunaTextBoxCodeChambreGrat.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeChambreGrat.Radius = 5
        Me.GunaTextBoxCodeChambreGrat.SelectedText = ""
        Me.GunaTextBoxCodeChambreGrat.Size = New System.Drawing.Size(49, 28)
        Me.GunaTextBoxCodeChambreGrat.TabIndex = 90
        Me.GunaTextBoxCodeChambreGrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeChambreGrat.Visible = False
        '
        'GunaTextBoxCodeResaGrat
        '
        Me.GunaTextBoxCodeResaGrat.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeResaGrat.BaseColor = System.Drawing.Color.DimGray
        Me.GunaTextBoxCodeResaGrat.BorderColor = System.Drawing.Color.DarkGray
        Me.GunaTextBoxCodeResaGrat.BorderSize = 1
        Me.GunaTextBoxCodeResaGrat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeResaGrat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeResaGrat.Enabled = False
        Me.GunaTextBoxCodeResaGrat.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeResaGrat.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeResaGrat.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeResaGrat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeResaGrat.Location = New System.Drawing.Point(162, 174)
        Me.GunaTextBoxCodeResaGrat.Name = "GunaTextBoxCodeResaGrat"
        Me.GunaTextBoxCodeResaGrat.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeResaGrat.Radius = 5
        Me.GunaTextBoxCodeResaGrat.SelectedText = ""
        Me.GunaTextBoxCodeResaGrat.Size = New System.Drawing.Size(43, 30)
        Me.GunaTextBoxCodeResaGrat.TabIndex = 91
        Me.GunaTextBoxCodeResaGrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeResaGrat.Visible = False
        '
        'GunaTextBoxNomClientGrat
        '
        Me.GunaTextBoxNomClientGrat.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNomClientGrat.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomClientGrat.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNomClientGrat.BorderSize = 1
        Me.GunaTextBoxNomClientGrat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNomClientGrat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNomClientGrat.Enabled = False
        Me.GunaTextBoxNomClientGrat.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomClientGrat.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNomClientGrat.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNomClientGrat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxNomClientGrat.Location = New System.Drawing.Point(14, 176)
        Me.GunaTextBoxNomClientGrat.Name = "GunaTextBoxNomClientGrat"
        Me.GunaTextBoxNomClientGrat.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNomClientGrat.Radius = 5
        Me.GunaTextBoxNomClientGrat.SelectedText = ""
        Me.GunaTextBoxNomClientGrat.Size = New System.Drawing.Size(312, 28)
        Me.GunaTextBoxNomClientGrat.TabIndex = 93
        Me.GunaTextBoxNomClientGrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxNomClientGrat.Visible = False
        '
        'GunaTextBoxRemarque
        '
        Me.GunaTextBoxRemarque.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxRemarque.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRemarque.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxRemarque.BorderSize = 1
        Me.GunaTextBoxRemarque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxRemarque.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxRemarque.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRemarque.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxRemarque.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxRemarque.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxRemarque.Location = New System.Drawing.Point(29, 81)
        Me.GunaTextBoxRemarque.Name = "GunaTextBoxRemarque"
        Me.GunaTextBoxRemarque.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxRemarque.Radius = 5
        Me.GunaTextBoxRemarque.SelectedText = ""
        Me.GunaTextBoxRemarque.Size = New System.Drawing.Size(297, 28)
        Me.GunaTextBoxRemarque.TabIndex = 0
        '
        'GunaTextBoxAuthorisation
        '
        Me.GunaTextBoxAuthorisation.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxAuthorisation.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAuthorisation.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxAuthorisation.BorderSize = 1
        Me.GunaTextBoxAuthorisation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxAuthorisation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxAuthorisation.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxAuthorisation.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxAuthorisation.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxAuthorisation.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxAuthorisation.Location = New System.Drawing.Point(29, 27)
        Me.GunaTextBoxAuthorisation.Name = "GunaTextBoxAuthorisation"
        Me.GunaTextBoxAuthorisation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxAuthorisation.Radius = 5
        Me.GunaTextBoxAuthorisation.SelectedText = ""
        Me.GunaTextBoxAuthorisation.Size = New System.Drawing.Size(297, 28)
        Me.GunaTextBoxAuthorisation.TabIndex = 0
        '
        'LabelRemarque
        '
        Me.LabelRemarque.AutoSize = True
        Me.LabelRemarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRemarque.Location = New System.Drawing.Point(34, 61)
        Me.LabelRemarque.Name = "LabelRemarque"
        Me.LabelRemarque.Size = New System.Drawing.Size(80, 16)
        Me.LabelRemarque.TabIndex = 84
        Me.LabelRemarque.Text = "Remarque"
        Me.LabelRemarque.Visible = False
        '
        'LabelAuthorisee
        '
        Me.LabelAuthorisee.AutoSize = True
        Me.LabelAuthorisee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAuthorisee.Location = New System.Drawing.Point(34, 9)
        Me.LabelAuthorisee.Name = "LabelAuthorisee"
        Me.LabelAuthorisee.Size = New System.Drawing.Size(109, 16)
        Me.LabelAuthorisee.TabIndex = 84
        Me.LabelAuthorisee.Text = "Authorisée par"
        Me.LabelAuthorisee.Visible = False
        '
        'GunaPanelTransfertEnChambre
        '
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxMontantATransferer)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaComboBoxCodeChambre)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxCodeClient)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxCodeReservation)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxCodeChambre)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.GunaTextBoxNomClient)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.LabelNomClient)
        Me.GunaPanelTransfertEnChambre.Controls.Add(Me.LabelChambre)
        Me.GunaPanelTransfertEnChambre.Location = New System.Drawing.Point(17, 528)
        Me.GunaPanelTransfertEnChambre.Name = "GunaPanelTransfertEnChambre"
        Me.GunaPanelTransfertEnChambre.Size = New System.Drawing.Size(424, 124)
        Me.GunaPanelTransfertEnChambre.TabIndex = 87
        '
        'GunaTextBoxMontantATransferer
        '
        Me.GunaTextBoxMontantATransferer.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantATransferer.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantATransferer.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantATransferer.BorderSize = 1
        Me.GunaTextBoxMontantATransferer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantATransferer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantATransferer.Enabled = False
        Me.GunaTextBoxMontantATransferer.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantATransferer.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantATransferer.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantATransferer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxMontantATransferer.Location = New System.Drawing.Point(21, 68)
        Me.GunaTextBoxMontantATransferer.Name = "GunaTextBoxMontantATransferer"
        Me.GunaTextBoxMontantATransferer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantATransferer.Radius = 5
        Me.GunaTextBoxMontantATransferer.SelectedText = ""
        Me.GunaTextBoxMontantATransferer.Size = New System.Drawing.Size(115, 30)
        Me.GunaTextBoxMontantATransferer.TabIndex = 89
        Me.GunaTextBoxMontantATransferer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaComboBoxCodeChambre
        '
        Me.GunaComboBoxCodeChambre.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxCodeChambre.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxCodeChambre.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxCodeChambre.BorderSize = 1
        Me.GunaComboBoxCodeChambre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxCodeChambre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxCodeChambre.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxCodeChambre.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaComboBoxCodeChambre.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxCodeChambre.FormattingEnabled = True
        Me.GunaComboBoxCodeChambre.ItemHeight = 25
        Me.GunaComboBoxCodeChambre.Location = New System.Drawing.Point(20, 25)
        Me.GunaComboBoxCodeChambre.Name = "GunaComboBoxCodeChambre"
        Me.GunaComboBoxCodeChambre.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxCodeChambre.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxCodeChambre.Radius = 5
        Me.GunaComboBoxCodeChambre.Size = New System.Drawing.Size(115, 31)
        Me.GunaComboBoxCodeChambre.TabIndex = 88
        '
        'GunaTextBoxCodeClient
        '
        Me.GunaTextBoxCodeClient.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeClient.BaseColor = System.Drawing.Color.DimGray
        Me.GunaTextBoxCodeClient.BorderColor = System.Drawing.Color.DarkGray
        Me.GunaTextBoxCodeClient.BorderSize = 1
        Me.GunaTextBoxCodeClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeClient.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeClient.Enabled = False
        Me.GunaTextBoxCodeClient.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeClient.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeClient.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeClient.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeClient.Location = New System.Drawing.Point(304, 58)
        Me.GunaTextBoxCodeClient.Name = "GunaTextBoxCodeClient"
        Me.GunaTextBoxCodeClient.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeClient.Radius = 5
        Me.GunaTextBoxCodeClient.SelectedText = ""
        Me.GunaTextBoxCodeClient.Size = New System.Drawing.Size(112, 28)
        Me.GunaTextBoxCodeClient.TabIndex = 0
        Me.GunaTextBoxCodeClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeClient.Visible = False
        '
        'GunaTextBoxCodeReservation
        '
        Me.GunaTextBoxCodeReservation.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeReservation.BaseColor = System.Drawing.Color.DimGray
        Me.GunaTextBoxCodeReservation.BorderColor = System.Drawing.Color.DarkGray
        Me.GunaTextBoxCodeReservation.BorderSize = 1
        Me.GunaTextBoxCodeReservation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeReservation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeReservation.Enabled = False
        Me.GunaTextBoxCodeReservation.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeReservation.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeReservation.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeReservation.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeReservation.Location = New System.Drawing.Point(165, 68)
        Me.GunaTextBoxCodeReservation.Name = "GunaTextBoxCodeReservation"
        Me.GunaTextBoxCodeReservation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeReservation.Radius = 5
        Me.GunaTextBoxCodeReservation.SelectedText = ""
        Me.GunaTextBoxCodeReservation.Size = New System.Drawing.Size(112, 30)
        Me.GunaTextBoxCodeReservation.TabIndex = 0
        Me.GunaTextBoxCodeReservation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeReservation.Visible = False
        '
        'GunaTextBoxCodeChambre
        '
        Me.GunaTextBoxCodeChambre.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeChambre.BaseColor = System.Drawing.Color.DimGray
        Me.GunaTextBoxCodeChambre.BorderColor = System.Drawing.Color.DarkGray
        Me.GunaTextBoxCodeChambre.BorderSize = 1
        Me.GunaTextBoxCodeChambre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeChambre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeChambre.Enabled = False
        Me.GunaTextBoxCodeChambre.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeChambre.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeChambre.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeChambre.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxCodeChambre.Location = New System.Drawing.Point(304, 89)
        Me.GunaTextBoxCodeChambre.Name = "GunaTextBoxCodeChambre"
        Me.GunaTextBoxCodeChambre.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeChambre.Radius = 5
        Me.GunaTextBoxCodeChambre.SelectedText = ""
        Me.GunaTextBoxCodeChambre.Size = New System.Drawing.Size(112, 28)
        Me.GunaTextBoxCodeChambre.TabIndex = 0
        Me.GunaTextBoxCodeChambre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCodeChambre.Visible = False
        '
        'GunaTextBoxNomClient
        '
        Me.GunaTextBoxNomClient.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNomClient.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomClient.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNomClient.BorderSize = 1
        Me.GunaTextBoxNomClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNomClient.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNomClient.Enabled = False
        Me.GunaTextBoxNomClient.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomClient.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNomClient.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNomClient.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxNomClient.Location = New System.Drawing.Point(141, 25)
        Me.GunaTextBoxNomClient.Name = "GunaTextBoxNomClient"
        Me.GunaTextBoxNomClient.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNomClient.Radius = 5
        Me.GunaTextBoxNomClient.SelectedText = ""
        Me.GunaTextBoxNomClient.Size = New System.Drawing.Size(275, 30)
        Me.GunaTextBoxNomClient.TabIndex = 0
        Me.GunaTextBoxNomClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelNomClient
        '
        Me.LabelNomClient.AutoSize = True
        Me.LabelNomClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNomClient.Location = New System.Drawing.Point(142, 6)
        Me.LabelNomClient.Name = "LabelNomClient"
        Me.LabelNomClient.Size = New System.Drawing.Size(102, 16)
        Me.LabelNomClient.TabIndex = 84
        Me.LabelNomClient.Text = "Nom du client"
        Me.LabelNomClient.Visible = False
        '
        'LabelChambre
        '
        Me.LabelChambre.AutoSize = True
        Me.LabelChambre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelChambre.Location = New System.Drawing.Point(17, 6)
        Me.LabelChambre.Name = "LabelChambre"
        Me.LabelChambre.Size = New System.Drawing.Size(70, 16)
        Me.LabelChambre.TabIndex = 84
        Me.LabelChambre.Text = "Chambre"
        Me.LabelChambre.Visible = False
        '
        'GunaTextBoxNumeroCompte
        '
        Me.GunaTextBoxNumeroCompte.AnimationHoverSpeed = 0.07!
        Me.GunaTextBoxNumeroCompte.AnimationSpeed = 0.03!
        Me.GunaTextBoxNumeroCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumeroCompte.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumeroCompte.BorderColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxNumeroCompte.BorderSize = 1
        Me.GunaTextBoxNumeroCompte.CheckedBaseColor = System.Drawing.Color.Gray
        Me.GunaTextBoxNumeroCompte.CheckedBorderColor = System.Drawing.Color.Black
        Me.GunaTextBoxNumeroCompte.CheckedForeColor = System.Drawing.Color.White
        Me.GunaTextBoxNumeroCompte.CheckedImage = Nothing
        Me.GunaTextBoxNumeroCompte.CheckedLineColor = System.Drawing.Color.DimGray
        Me.GunaTextBoxNumeroCompte.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaTextBoxNumeroCompte.FocusedColor = System.Drawing.Color.Empty
        Me.GunaTextBoxNumeroCompte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxNumeroCompte.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxNumeroCompte.Image = Nothing
        Me.GunaTextBoxNumeroCompte.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaTextBoxNumeroCompte.LineColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumeroCompte.Location = New System.Drawing.Point(311, 24)
        Me.GunaTextBoxNumeroCompte.Name = "GunaTextBoxNumeroCompte"
        Me.GunaTextBoxNumeroCompte.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumeroCompte.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaTextBoxNumeroCompte.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaTextBoxNumeroCompte.OnHoverImage = Nothing
        Me.GunaTextBoxNumeroCompte.OnHoverLineColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumeroCompte.OnPressedColor = System.Drawing.Color.Black
        Me.GunaTextBoxNumeroCompte.Radius = 5
        Me.GunaTextBoxNumeroCompte.Size = New System.Drawing.Size(122, 30)
        Me.GunaTextBoxNumeroCompte.TabIndex = 89
        Me.GunaTextBoxNumeroCompte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PanelTransfertVersCompte
        '
        Me.PanelTransfertVersCompte.Controls.Add(Me.PictureBoxClearArticleFields)
        Me.PanelTransfertVersCompte.Controls.Add(Me.GunaDataGridViewCompany)
        Me.PanelTransfertVersCompte.Controls.Add(Me.LabelEntreprise)
        Me.PanelTransfertVersCompte.Controls.Add(Me.GunaAdvenceButtonCodeClientDuCompte)
        Me.PanelTransfertVersCompte.Controls.Add(Me.GunaTextBoxNumeroCompte)
        Me.PanelTransfertVersCompte.Controls.Add(Me.GunaTextBoxEntreprise)
        Me.PanelTransfertVersCompte.Controls.Add(Me.LabelNumeroCompte)
        Me.PanelTransfertVersCompte.Controls.Add(Me.GunaComboBoxCompteIndividuelOuPaymaster)
        Me.PanelTransfertVersCompte.Location = New System.Drawing.Point(16, 527)
        Me.PanelTransfertVersCompte.Name = "PanelTransfertVersCompte"
        Me.PanelTransfertVersCompte.Size = New System.Drawing.Size(443, 214)
        Me.PanelTransfertVersCompte.TabIndex = 90
        '
        'PictureBoxClearArticleFields
        '
        Me.PictureBoxClearArticleFields.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PictureBoxClearArticleFields.Image = CType(resources.GetObject("PictureBoxClearArticleFields.Image"), System.Drawing.Image)
        Me.PictureBoxClearArticleFields.InitialImage = CType(resources.GetObject("PictureBoxClearArticleFields.InitialImage"), System.Drawing.Image)
        Me.PictureBoxClearArticleFields.Location = New System.Drawing.Point(279, 28)
        Me.PictureBoxClearArticleFields.Name = "PictureBoxClearArticleFields"
        Me.PictureBoxClearArticleFields.Size = New System.Drawing.Size(22, 25)
        Me.PictureBoxClearArticleFields.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxClearArticleFields.TabIndex = 190
        Me.PictureBoxClearArticleFields.TabStop = False
        '
        'GunaAdvenceButtonCodeClientDuCompte
        '
        Me.GunaAdvenceButtonCodeClientDuCompte.AnimationHoverSpeed = 0.07!
        Me.GunaAdvenceButtonCodeClientDuCompte.AnimationSpeed = 0.03!
        Me.GunaAdvenceButtonCodeClientDuCompte.BackColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButtonCodeClientDuCompte.BaseColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonCodeClientDuCompte.BorderColor = System.Drawing.Color.LightGray
        Me.GunaAdvenceButtonCodeClientDuCompte.BorderSize = 1
        Me.GunaAdvenceButtonCodeClientDuCompte.CheckedBaseColor = System.Drawing.Color.Gray
        Me.GunaAdvenceButtonCodeClientDuCompte.CheckedBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonCodeClientDuCompte.CheckedForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonCodeClientDuCompte.CheckedImage = Nothing
        Me.GunaAdvenceButtonCodeClientDuCompte.CheckedLineColor = System.Drawing.Color.DimGray
        Me.GunaAdvenceButtonCodeClientDuCompte.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaAdvenceButtonCodeClientDuCompte.FocusedColor = System.Drawing.Color.Empty
        Me.GunaAdvenceButtonCodeClientDuCompte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaAdvenceButtonCodeClientDuCompte.ForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonCodeClientDuCompte.Image = Nothing
        Me.GunaAdvenceButtonCodeClientDuCompte.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaAdvenceButtonCodeClientDuCompte.LineColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButtonCodeClientDuCompte.Location = New System.Drawing.Point(311, 62)
        Me.GunaAdvenceButtonCodeClientDuCompte.Name = "GunaAdvenceButtonCodeClientDuCompte"
        Me.GunaAdvenceButtonCodeClientDuCompte.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButtonCodeClientDuCompte.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonCodeClientDuCompte.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonCodeClientDuCompte.OnHoverImage = Nothing
        Me.GunaAdvenceButtonCodeClientDuCompte.OnHoverLineColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButtonCodeClientDuCompte.OnPressedColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonCodeClientDuCompte.Radius = 5
        Me.GunaAdvenceButtonCodeClientDuCompte.Size = New System.Drawing.Size(122, 30)
        Me.GunaAdvenceButtonCodeClientDuCompte.TabIndex = 89
        Me.GunaAdvenceButtonCodeClientDuCompte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaAdvenceButtonCodeClientDuCompte.Visible = False
        '
        'GunaComboBoxCompteIndividuelOuPaymaster
        '
        Me.GunaComboBoxCompteIndividuelOuPaymaster.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxCompteIndividuelOuPaymaster.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxCompteIndividuelOuPaymaster.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxCompteIndividuelOuPaymaster.BorderSize = 1
        Me.GunaComboBoxCompteIndividuelOuPaymaster.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxCompteIndividuelOuPaymaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxCompteIndividuelOuPaymaster.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxCompteIndividuelOuPaymaster.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxCompteIndividuelOuPaymaster.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxCompteIndividuelOuPaymaster.FormattingEnabled = True
        Me.GunaComboBoxCompteIndividuelOuPaymaster.ItemHeight = 25
        Me.GunaComboBoxCompteIndividuelOuPaymaster.Items.AddRange(New Object() {"INDIVIDUEL", "COMPTE"})
        Me.GunaComboBoxCompteIndividuelOuPaymaster.Location = New System.Drawing.Point(10, 59)
        Me.GunaComboBoxCompteIndividuelOuPaymaster.Name = "GunaComboBoxCompteIndividuelOuPaymaster"
        Me.GunaComboBoxCompteIndividuelOuPaymaster.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxCompteIndividuelOuPaymaster.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxCompteIndividuelOuPaymaster.Radius = 4
        Me.GunaComboBoxCompteIndividuelOuPaymaster.Size = New System.Drawing.Size(165, 31)
        Me.GunaComboBoxCompteIndividuelOuPaymaster.TabIndex = 77
        '
        'GunaPanelGestCaisse
        '
        Me.GunaPanelGestCaisse.Controls.Add(Me.GunaTextBoxMontantPercu)
        Me.GunaPanelGestCaisse.Controls.Add(Me.GunaTextBoxMontantRendu)
        Me.GunaPanelGestCaisse.Controls.Add(Me.Label8)
        Me.GunaPanelGestCaisse.Controls.Add(Me.LabelMontantRendu)
        Me.GunaPanelGestCaisse.Location = New System.Drawing.Point(465, 489)
        Me.GunaPanelGestCaisse.Name = "GunaPanelGestCaisse"
        Me.GunaPanelGestCaisse.Size = New System.Drawing.Size(361, 110)
        Me.GunaPanelGestCaisse.TabIndex = 91
        Me.GunaPanelGestCaisse.Visible = False
        '
        'GunaTextBoxMontantPercu
        '
        Me.GunaTextBoxMontantPercu.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantPercu.BaseColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTextBoxMontantPercu.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantPercu.BorderSize = 1
        Me.GunaTextBoxMontantPercu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantPercu.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantPercu.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantPercu.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantPercu.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantPercu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxMontantPercu.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantPercu.Location = New System.Drawing.Point(168, 20)
        Me.GunaTextBoxMontantPercu.Name = "GunaTextBoxMontantPercu"
        Me.GunaTextBoxMontantPercu.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantPercu.Radius = 5
        Me.GunaTextBoxMontantPercu.SelectedText = ""
        Me.GunaTextBoxMontantPercu.Size = New System.Drawing.Size(184, 31)
        Me.GunaTextBoxMontantPercu.TabIndex = 75
        Me.GunaTextBoxMontantPercu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GunaTextBoxMontantPercu.Visible = False
        '
        'GunaTextBoxMontantRendu
        '
        Me.GunaTextBoxMontantRendu.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMontantRendu.BaseColor = System.Drawing.Color.Salmon
        Me.GunaTextBoxMontantRendu.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMontantRendu.BorderSize = 1
        Me.GunaTextBoxMontantRendu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMontantRendu.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMontantRendu.Enabled = False
        Me.GunaTextBoxMontantRendu.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantRendu.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMontantRendu.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMontantRendu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxMontantRendu.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxMontantRendu.Location = New System.Drawing.Point(168, 60)
        Me.GunaTextBoxMontantRendu.Name = "GunaTextBoxMontantRendu"
        Me.GunaTextBoxMontantRendu.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantRendu.Radius = 5
        Me.GunaTextBoxMontantRendu.SelectedText = ""
        Me.GunaTextBoxMontantRendu.Size = New System.Drawing.Size(184, 31)
        Me.GunaTextBoxMontantRendu.TabIndex = 76
        Me.GunaTextBoxMontantRendu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GunaTextBoxMontantRendu.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 16)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Montant Perçu"
        Me.Label8.Visible = False
        '
        'LabelMontantRendu
        '
        Me.LabelMontantRendu.AutoSize = True
        Me.LabelMontantRendu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMontantRendu.Location = New System.Drawing.Point(65, 67)
        Me.LabelMontantRendu.Name = "LabelMontantRendu"
        Me.LabelMontantRendu.Size = New System.Drawing.Size(57, 16)
        Me.LabelMontantRendu.TabIndex = 74
        Me.LabelMontantRendu.Text = "Relicat"
        Me.LabelMontantRendu.Visible = False
        '
        'GunaTextBoxNumFacture
        '
        Me.GunaTextBoxNumFacture.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNumFacture.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumFacture.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNumFacture.BorderSize = 1
        Me.GunaTextBoxNumFacture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNumFacture.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNumFacture.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNumFacture.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNumFacture.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNumFacture.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNumFacture.Location = New System.Drawing.Point(652, 29)
        Me.GunaTextBoxNumFacture.Name = "GunaTextBoxNumFacture"
        Me.GunaTextBoxNumFacture.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNumFacture.Radius = 5
        Me.GunaTextBoxNumFacture.SelectedText = ""
        Me.GunaTextBoxNumFacture.Size = New System.Drawing.Size(174, 25)
        Me.GunaTextBoxNumFacture.TabIndex = 74
        Me.GunaTextBoxNumFacture.Visible = False
        '
        'GunaPanelClubElite
        '
        Me.GunaPanelClubElite.BackColor = System.Drawing.Color.PeachPuff
        Me.GunaPanelClubElite.Controls.Add(Me.GunaTextBoxValeurTotalCritere)
        Me.GunaPanelClubElite.Controls.Add(Me.GunaTextBoxValeurDuPoint)
        Me.GunaPanelClubElite.Controls.Add(Me.GunaTextBoxCritere)
        Me.GunaPanelClubElite.Controls.Add(Me.GunaComboBoxCritereElite)
        Me.GunaPanelClubElite.Controls.Add(Me.Label14)
        Me.GunaPanelClubElite.Controls.Add(Me.Label13)
        Me.GunaPanelClubElite.Controls.Add(Me.Label12)
        Me.GunaPanelClubElite.Location = New System.Drawing.Point(15, 527)
        Me.GunaPanelClubElite.Name = "GunaPanelClubElite"
        Me.GunaPanelClubElite.Size = New System.Drawing.Size(443, 205)
        Me.GunaPanelClubElite.TabIndex = 191
        '
        'GunaTextBoxValeurTotalCritere
        '
        Me.GunaTextBoxValeurTotalCritere.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxValeurTotalCritere.BaseColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTextBoxValeurTotalCritere.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxValeurTotalCritere.BorderSize = 1
        Me.GunaTextBoxValeurTotalCritere.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxValeurTotalCritere.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxValeurTotalCritere.Enabled = False
        Me.GunaTextBoxValeurTotalCritere.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxValeurTotalCritere.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxValeurTotalCritere.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxValeurTotalCritere.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxValeurTotalCritere.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxValeurTotalCritere.Location = New System.Drawing.Point(226, 79)
        Me.GunaTextBoxValeurTotalCritere.Name = "GunaTextBoxValeurTotalCritere"
        Me.GunaTextBoxValeurTotalCritere.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxValeurTotalCritere.Radius = 5
        Me.GunaTextBoxValeurTotalCritere.SelectedText = ""
        Me.GunaTextBoxValeurTotalCritere.Size = New System.Drawing.Size(114, 31)
        Me.GunaTextBoxValeurTotalCritere.TabIndex = 75
        Me.GunaTextBoxValeurTotalCritere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaTextBoxValeurDuPoint
        '
        Me.GunaTextBoxValeurDuPoint.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxValeurDuPoint.BaseColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTextBoxValeurDuPoint.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxValeurDuPoint.BorderSize = 1
        Me.GunaTextBoxValeurDuPoint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxValeurDuPoint.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxValeurDuPoint.Enabled = False
        Me.GunaTextBoxValeurDuPoint.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxValeurDuPoint.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxValeurDuPoint.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxValeurDuPoint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxValeurDuPoint.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxValeurDuPoint.Location = New System.Drawing.Point(101, 79)
        Me.GunaTextBoxValeurDuPoint.Name = "GunaTextBoxValeurDuPoint"
        Me.GunaTextBoxValeurDuPoint.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxValeurDuPoint.Radius = 5
        Me.GunaTextBoxValeurDuPoint.SelectedText = ""
        Me.GunaTextBoxValeurDuPoint.Size = New System.Drawing.Size(113, 31)
        Me.GunaTextBoxValeurDuPoint.TabIndex = 75
        Me.GunaTextBoxValeurDuPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GunaTextBoxValeurDuPoint.Visible = False
        '
        'GunaTextBoxCritere
        '
        Me.GunaTextBoxCritere.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCritere.BaseColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTextBoxCritere.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCritere.BorderSize = 1
        Me.GunaTextBoxCritere.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCritere.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCritere.Enabled = False
        Me.GunaTextBoxCritere.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCritere.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCritere.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCritere.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCritere.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxCritere.Location = New System.Drawing.Point(226, 39)
        Me.GunaTextBoxCritere.Name = "GunaTextBoxCritere"
        Me.GunaTextBoxCritere.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCritere.Radius = 5
        Me.GunaTextBoxCritere.SelectedText = ""
        Me.GunaTextBoxCritere.Size = New System.Drawing.Size(114, 31)
        Me.GunaTextBoxCritere.TabIndex = 75
        Me.GunaTextBoxCritere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaComboBoxCritereElite
        '
        Me.GunaComboBoxCritereElite.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxCritereElite.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxCritereElite.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxCritereElite.BorderSize = 1
        Me.GunaComboBoxCritereElite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxCritereElite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxCritereElite.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxCritereElite.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxCritereElite.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxCritereElite.FormattingEnabled = True
        Me.GunaComboBoxCritereElite.ItemHeight = 25
        Me.GunaComboBoxCritereElite.Items.AddRange(New Object() {"Espèce", "Chèque", "Carte Bancaire", "Prise en charge", "MTN Money", "ORANGE Money", "Gratuitée", "Transfert En chambre", "Transfert Vers Compte Débiteur", "Virement Bancaire"})
        Me.GunaComboBoxCritereElite.Location = New System.Drawing.Point(22, 38)
        Me.GunaComboBoxCritereElite.Name = "GunaComboBoxCritereElite"
        Me.GunaComboBoxCritereElite.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxCritereElite.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxCritereElite.Radius = 4
        Me.GunaComboBoxCritereElite.Size = New System.Drawing.Size(192, 31)
        Me.GunaComboBoxCritereElite.TabIndex = 77
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(348, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 16)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "FCFA"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(348, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 16)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Critère"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(149, 16)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Critère de règlement"
        '
        'GunaCheckBoxArrhes
        '
        Me.GunaCheckBoxArrhes.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxArrhes.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxArrhes.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxArrhes.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxArrhes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxArrhes.Location = New System.Drawing.Point(522, 371)
        Me.GunaCheckBoxArrhes.Name = "GunaCheckBoxArrhes"
        Me.GunaCheckBoxArrhes.Size = New System.Drawing.Size(20, 20)
        Me.GunaCheckBoxArrhes.TabIndex = 83
        '
        'GunaButtonDepotDeGarantie
        '
        Me.GunaButtonDepotDeGarantie.AnimationHoverSpeed = 0.07!
        Me.GunaButtonDepotDeGarantie.AnimationSpeed = 0.03!
        Me.GunaButtonDepotDeGarantie.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonDepotDeGarantie.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonDepotDeGarantie.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonDepotDeGarantie.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonDepotDeGarantie.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonDepotDeGarantie.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonDepotDeGarantie.ForeColor = System.Drawing.Color.White
        Me.GunaButtonDepotDeGarantie.Image = Nothing
        Me.GunaButtonDepotDeGarantie.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonDepotDeGarantie.Location = New System.Drawing.Point(9, 366)
        Me.GunaButtonDepotDeGarantie.Name = "GunaButtonDepotDeGarantie"
        Me.GunaButtonDepotDeGarantie.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonDepotDeGarantie.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonDepotDeGarantie.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonDepotDeGarantie.OnHoverImage = Nothing
        Me.GunaButtonDepotDeGarantie.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonDepotDeGarantie.Radius = 4
        Me.GunaButtonDepotDeGarantie.Size = New System.Drawing.Size(182, 31)
        Me.GunaButtonDepotDeGarantie.TabIndex = 192
        Me.GunaButtonDepotDeGarantie.Text = "Référence Dépot de garantie"
        Me.GunaButtonDepotDeGarantie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxRefDepot
        '
        Me.GunaTextBoxRefDepot.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxRefDepot.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRefDepot.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxRefDepot.BorderSize = 1
        Me.GunaTextBoxRefDepot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxRefDepot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxRefDepot.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRefDepot.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxRefDepot.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxRefDepot.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxRefDepot.Location = New System.Drawing.Point(198, 366)
        Me.GunaTextBoxRefDepot.Name = "GunaTextBoxRefDepot"
        Me.GunaTextBoxRefDepot.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxRefDepot.Radius = 5
        Me.GunaTextBoxRefDepot.SelectedText = ""
        Me.GunaTextBoxRefDepot.Size = New System.Drawing.Size(318, 31)
        Me.GunaTextBoxRefDepot.TabIndex = 193
        '
        'GunaDataGridViewDepot
        '
        Me.GunaDataGridViewDepot.AllowUserToAddRows = False
        Me.GunaDataGridViewDepot.AllowUserToResizeColumns = False
        Me.GunaDataGridViewDepot.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewDepot.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GunaDataGridViewDepot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GunaDataGridViewDepot.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewDepot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewDepot.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewDepot.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewDepot.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GunaDataGridViewDepot.ColumnHeadersHeight = 25
        Me.GunaDataGridViewDepot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewDepot.DefaultCellStyle = DataGridViewCellStyle3
        Me.GunaDataGridViewDepot.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewDepot.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewDepot.Location = New System.Drawing.Point(198, 399)
        Me.GunaDataGridViewDepot.Name = "GunaDataGridViewDepot"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewDepot.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GunaDataGridViewDepot.RowHeadersVisible = False
        Me.GunaDataGridViewDepot.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewDepot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewDepot.Size = New System.Drawing.Size(318, 154)
        Me.GunaDataGridViewDepot.TabIndex = 194
        Me.GunaDataGridViewDepot.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewDepot.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewDepot.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewDepot.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewDepot.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewDepot.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewDepot.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewDepot.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewDepot.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewDepot.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewDepot.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewDepot.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewDepot.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewDepot.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewDepot.ThemeStyle.ReadOnly = False
        Me.GunaDataGridViewDepot.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewDepot.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewDepot.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridViewDepot.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewDepot.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewDepot.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewDepot.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewDepot.Visible = False
        '
        'ReglementForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PeachPuff
        Me.ClientSize = New System.Drawing.Size(834, 754)
        Me.Controls.Add(Me.GunaDataGridViewDepot)
        Me.Controls.Add(Me.GunaTextBoxRefDepot)
        Me.Controls.Add(Me.GunaButtonDepotDeGarantie)
        Me.Controls.Add(Me.GunaPanelClubElite)
        Me.Controls.Add(Me.GunaPanelGratuite)
        Me.Controls.Add(Me.PanelTransfertVersCompte)
        Me.Controls.Add(Me.GunaPanelGestCaisse)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaLabelBlocNoteARegler)
        Me.Controls.Add(Me.GunaTextBoxContact)
        Me.Controls.Add(Me.LabelContact)
        Me.Controls.Add(Me.GunaCheckBoxArrhes)
        Me.Controls.Add(Me.GunaCheckBoxRemboursement)
        Me.Controls.Add(Me.PanelSituationCaisse)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaDataGridView2)
        Me.Controls.Add(Me.GunaComboBoxModereglement)
        Me.Controls.Add(Me.GunaSeparator1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GunaTextBoxClientAFacturer)
        Me.Controls.Add(Me.GunaTextBoxNumFacture)
        Me.Controls.Add(Me.GunaTextBoxNom)
        Me.Controls.Add(Me.GunaTextBoxReference)
        Me.Controls.Add(Me.GunaTextBoxSolde)
        Me.Controls.Add(Me.GunaTextBoxMontantVerse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelSolde)
        Me.Controls.Add(Me.GunaTextBoxAPayer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelMontantAPayer)
        Me.Controls.Add(Me.GunaDataGridViewLigneFactureReglement)
        Me.Controls.Add(Me.GunaButtonEnregistrerReglement)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaPanelSupplementCarte)
        Me.Controls.Add(Me.GunaPanelSupplementCheque)
        Me.Controls.Add(Me.GunaPanelTransfertEnChambre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ReglementForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClientForm"
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.GunaDataGridViewLigneFactureReglement, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaDataGridViewCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSituationCaisse.ResumeLayout(False)
        Me.PanelSituationCaisse.PerformLayout()
        Me.GunaPanelSupplementCarte.ResumeLayout(False)
        Me.GunaPanelSupplementCarte.PerformLayout()
        Me.GunaPanelSupplementCheque.ResumeLayout(False)
        Me.GunaPanelSupplementCheque.PerformLayout()
        Me.GunaPanelGratuite.ResumeLayout(False)
        Me.GunaPanelGratuite.PerformLayout()
        Me.GunaPanelTransfertEnChambre.ResumeLayout(False)
        Me.GunaPanelTransfertEnChambre.PerformLayout()
        Me.PanelTransfertVersCompte.ResumeLayout(False)
        Me.PanelTransfertVersCompte.PerformLayout()
        CType(Me.PictureBoxClearArticleFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPanelGestCaisse.ResumeLayout(False)
        Me.GunaPanelGestCaisse.PerformLayout()
        Me.GunaPanelClubElite.ResumeLayout(False)
        Me.GunaPanelClubElite.PerformLayout()
        CType(Me.GunaDataGridViewDepot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaButtonEnregistrerReglement As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButtonReduce As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButtonFermer As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaTextBoxAPayer As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelMontantAPayer As Label
    Friend WithEvents GunaSeparator1 As Guna.UI.WinForms.GunaSeparator
    Friend WithEvents Label5 As Label
    Friend WithEvents GunaTextBoxClientAFacturer As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNom As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewLigneFactureReglement As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaComboBoxModereglement As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxReference As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxSolde As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantVerse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelSolde As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GunaDataGridView2 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents LabelNumeroCompte As Label
    Friend WithEvents LabelEntreprise As Label
    Friend WithEvents GunaDataGridViewCompany As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelSituationCaisse As Panel
    Friend WithEvents LabelSituationCaisse As Label
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
    Friend WithEvents GunaCheckBoxRemboursement As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaTextBoxEntreprise As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxContact As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelContact As Label
    Friend WithEvents GunaLabelBlocNoteARegler As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanelGratuite As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxRemarque As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxAuthorisation As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelRemarque As Label
    Friend WithEvents LabelAuthorisee As Label
    Friend WithEvents GunaPanelTransfertEnChambre As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxNomClient As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelNomClient As Label
    Friend WithEvents LabelChambre As Label
    Friend WithEvents GunaComboBoxCodeChambre As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxCodeClient As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeReservation As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeChambre As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNumeroCompte As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents PanelTransfertVersCompte As Panel
    Friend WithEvents GunaTextBoxMontantATransferer As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents PictureBoxClearArticleFields As PictureBox
    Friend WithEvents GunaAdvenceButtonCodeClientDuCompte As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents GunaComboBoxCompteIndividuelOuPaymaster As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GunaTextBoxReferenceTransactionBanque As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GunaComboBoxBanque As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaComboBoxBanqueEmettrice As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents DateOperation As DataGridViewTextBoxColumn
    Friend WithEvents LibelleOperation As DataGridViewTextBoxColumn
    Friend WithEvents Debit As DataGridViewTextBoxColumn
    Friend WithEvents Credit As DataGridViewTextBoxColumn
    Friend WithEvents Article As DataGridViewTextBoxColumn
    Friend WithEvents codeFacture As DataGridViewTextBoxColumn
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents GunaPanelGestCaisse As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxMontantPercu As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantRendu As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents LabelMontantRendu As Label
    Friend WithEvents GunaTextBoxNumFacture As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GunaComboBoxNumChambreGrat As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxCodeChambreGrat As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeResaGrat As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNomClientGrat As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaCheckBoxOffresEnChambre As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaTextBoxCodeClientGrat As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GunaPanelClubElite As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaComboBoxCritereElite As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GunaTextBoxCodeElite As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCritere As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents GunaTextBoxValeurTotalCritere As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents GunaTextBoxValeurDuPoint As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxCodeClientFidele As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaCheckBoxArrhes As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaTextBoxCodeDepot As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantDepot As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonDepotDeGarantie As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxRefDepot As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewDepot As Guna.UI.WinForms.GunaDataGridView
End Class
