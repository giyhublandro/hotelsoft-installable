<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PetiteCaisseForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PetiteCaisseForm))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxRefEntreeEnAttntes = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaImageButtonReduce = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButtonFermer = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButtonEnregistrerReglement = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonOuvertureFermeture = New Guna.UI.WinForms.GunaButton()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.LabelMontantAPayer = New System.Windows.Forms.Label()
        Me.GunaDataGridViewTransactionPetiteCaisse = New Guna.UI.WinForms.GunaDataGridView()
        Me.DateOperation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num_reglement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.receveur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approuve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.effectue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaTextBoxNom = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCaissier = New Guna.UI.WinForms.GunaTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GunaTextBoxMontantVerse = New Guna.UI.WinForms.GunaTextBox()
        Me.LabelSolde = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GunaComboBoxModereglement = New Guna.UI.WinForms.GunaComboBox()
        Me.LabelMotif = New System.Windows.Forms.Label()
        Me.GunaTextBoxMotif = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelSituationCaisse = New System.Windows.Forms.Panel()
        Me.LabelSituationCaisse = New System.Windows.Forms.Label()
        Me.GunaComboBoxNatureMovt = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabelIndexTitreMouvement = New Guna.UI.WinForms.GunaLabel()
        Me.PanelTotalSortie = New System.Windows.Forms.Panel()
        Me.LabelDepense = New System.Windows.Forms.Label()
        Me.GunaTextBoxParCaissier = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.GunaDataGridView2 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaTextBoxCodeUserFiltre = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaCheckBoxToutVoir = New Guna.UI.WinForms.GunaCheckBox()
        Me.LabelRef = New System.Windows.Forms.Label()
        Me.GunaTextBoxReference = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCodePetiteCaisse = New Guna.UI.WinForms.GunaTextBox()
        Me.PanelServiceDemandeur = New System.Windows.Forms.Panel()
        Me.GunaComboBoxProfilUtilisateur = New Guna.UI.WinForms.GunaComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GunaTextBoxPLafonds = New Guna.UI.WinForms.GunaTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GunaDataGridViewRemboursementEnAttente = New Guna.UI.WinForms.GunaDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaPaneInfoSupReceveur = New Guna.UI.WinForms.GunaPanel()
        Me.GunaTextBoxApprouvePar = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxCNIDuReceveur = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxNomDuReceveur = New Guna.UI.WinForms.GunaTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LabelCNI = New System.Windows.Forms.Label()
        Me.LabelNomReceveur = New System.Windows.Forms.Label()
        Me.GunaCheckBoxTiers = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaPanelTiers = New Guna.UI.WinForms.GunaPanel()
        Me.GunaComboBoxFournisseur = New Guna.UI.WinForms.GunaComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GunaTextBoxCodeRefrence = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaButtonImprimerListeDesComptes = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonHistoriques = New Guna.UI.WinForms.GunaButton()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker5 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker6 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker7 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker8 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker9 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaPanel1.SuspendLayout()
        CType(Me.GunaDataGridViewTransactionPetiteCaisse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSituationCaisse.SuspendLayout()
        Me.PanelTotalSortie.SuspendLayout()
        CType(Me.GunaDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelServiceDemandeur.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.GunaDataGridViewRemboursementEnAttente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPaneInfoSupReceveur.SuspendLayout()
        Me.GunaPanelTiers.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(303, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(114, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "PETITE CAISSE"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaTextBoxRefEntreeEnAttntes)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButtonReduce)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButtonFermer)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton5)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(834, 25)
        Me.GunaPanel1.TabIndex = 2
        '
        'GunaTextBoxRefEntreeEnAttntes
        '
        Me.GunaTextBoxRefEntreeEnAttntes.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRefEntreeEnAttntes.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxRefEntreeEnAttntes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxRefEntreeEnAttntes.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxRefEntreeEnAttntes.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxRefEntreeEnAttntes.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxRefEntreeEnAttntes.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.GunaTextBoxRefEntreeEnAttntes.Location = New System.Drawing.Point(479, 3)
        Me.GunaTextBoxRefEntreeEnAttntes.Name = "GunaTextBoxRefEntreeEnAttntes"
        Me.GunaTextBoxRefEntreeEnAttntes.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxRefEntreeEnAttntes.SelectedText = ""
        Me.GunaTextBoxRefEntreeEnAttntes.Size = New System.Drawing.Size(160, 21)
        Me.GunaTextBoxRefEntreeEnAttntes.TabIndex = 12
        Me.GunaTextBoxRefEntreeEnAttntes.Visible = False
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
        Me.GunaButtonEnregistrerReglement.Location = New System.Drawing.Point(715, 619)
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
        Me.GunaButtonOuvertureFermeture.Location = New System.Drawing.Point(329, 623)
        Me.GunaButtonOuvertureFermeture.Name = "GunaButtonOuvertureFermeture"
        Me.GunaButtonOuvertureFermeture.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonOuvertureFermeture.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonOuvertureFermeture.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonOuvertureFermeture.OnHoverImage = Nothing
        Me.GunaButtonOuvertureFermeture.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonOuvertureFermeture.Radius = 4
        Me.GunaButtonOuvertureFermeture.Size = New System.Drawing.Size(121, 34)
        Me.GunaButtonOuvertureFermeture.TabIndex = 8
        Me.GunaButtonOuvertureFermeture.Text = "Fermer Caisse"
        Me.GunaButtonOuvertureFermeture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLabelGestCompteGeneraux
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaPanel1
        '
        'LabelMontantAPayer
        '
        Me.LabelMontantAPayer.AutoSize = True
        Me.LabelMontantAPayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMontantAPayer.Location = New System.Drawing.Point(11, 380)
        Me.LabelMontantAPayer.Name = "LabelMontantAPayer"
        Me.LabelMontantAPayer.Size = New System.Drawing.Size(149, 16)
        Me.LabelMontantAPayer.TabIndex = 70
        Me.LabelMontantAPayer.Text = "Type de Mouvement"
        '
        'GunaDataGridViewTransactionPetiteCaisse
        '
        Me.GunaDataGridViewTransactionPetiteCaisse.AllowUserToAddRows = False
        Me.GunaDataGridViewTransactionPetiteCaisse.AllowUserToDeleteRows = False
        Me.GunaDataGridViewTransactionPetiteCaisse.AllowUserToOrderColumns = True
        Me.GunaDataGridViewTransactionPetiteCaisse.AllowUserToResizeColumns = False
        Me.GunaDataGridViewTransactionPetiteCaisse.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewTransactionPetiteCaisse.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.GunaDataGridViewTransactionPetiteCaisse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GunaDataGridViewTransactionPetiteCaisse.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewTransactionPetiteCaisse.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewTransactionPetiteCaisse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewTransactionPetiteCaisse.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewTransactionPetiteCaisse.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.GunaDataGridViewTransactionPetiteCaisse.ColumnHeadersHeight = 25
        Me.GunaDataGridViewTransactionPetiteCaisse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewTransactionPetiteCaisse.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateOperation, Me.num_reglement, Me.Description, Me.Debit, Me.Credit, Me.receveur, Me.approuve, Me.effectue})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewTransactionPetiteCaisse.DefaultCellStyle = DataGridViewCellStyle15
        Me.GunaDataGridViewTransactionPetiteCaisse.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewTransactionPetiteCaisse.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewTransactionPetiteCaisse.Location = New System.Drawing.Point(7, 8)
        Me.GunaDataGridViewTransactionPetiteCaisse.Name = "GunaDataGridViewTransactionPetiteCaisse"
        Me.GunaDataGridViewTransactionPetiteCaisse.ReadOnly = True
        Me.GunaDataGridViewTransactionPetiteCaisse.RowHeadersVisible = False
        Me.GunaDataGridViewTransactionPetiteCaisse.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewTransactionPetiteCaisse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewTransactionPetiteCaisse.Size = New System.Drawing.Size(785, 247)
        Me.GunaDataGridViewTransactionPetiteCaisse.TabIndex = 17
        Me.GunaDataGridViewTransactionPetiteCaisse.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewTransactionPetiteCaisse.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'DateOperation
        '
        Me.DateOperation.HeaderText = "Date"
        Me.DateOperation.Name = "DateOperation"
        Me.DateOperation.ReadOnly = True
        Me.DateOperation.Width = 65
        '
        'num_reglement
        '
        Me.num_reglement.HeaderText = "Référence"
        Me.num_reglement.Name = "num_reglement"
        Me.num_reglement.ReadOnly = True
        Me.num_reglement.Width = 106
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 113
        '
        'Debit
        '
        Me.Debit.HeaderText = "Montant déposé"
        Me.Debit.Name = "Debit"
        Me.Debit.ReadOnly = True
        Me.Debit.Width = 147
        '
        'Credit
        '
        Me.Credit.HeaderText = "Montant retiré"
        Me.Credit.Name = "Credit"
        Me.Credit.ReadOnly = True
        Me.Credit.Width = 133
        '
        'receveur
        '
        Me.receveur.HeaderText = "Receveur"
        Me.receveur.Name = "receveur"
        Me.receveur.ReadOnly = True
        '
        'approuve
        '
        Me.approuve.HeaderText = "Approuvé par"
        Me.approuve.Name = "approuve"
        Me.approuve.ReadOnly = True
        Me.approuve.Width = 129
        '
        'effectue
        '
        Me.effectue.HeaderText = "effectué par"
        Me.effectue.Name = "effectue"
        Me.effectue.ReadOnly = True
        Me.effectue.Width = 119
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
        Me.GunaTextBoxNom.Location = New System.Drawing.Point(35, 55)
        Me.GunaTextBoxNom.Name = "GunaTextBoxNom"
        Me.GunaTextBoxNom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNom.Radius = 5
        Me.GunaTextBoxNom.SelectedText = ""
        Me.GunaTextBoxNom.Size = New System.Drawing.Size(88, 34)
        Me.GunaTextBoxNom.TabIndex = 74
        Me.GunaTextBoxNom.Visible = False
        '
        'GunaTextBoxCaissier
        '
        Me.GunaTextBoxCaissier.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCaissier.BaseColor = System.Drawing.Color.Plum
        Me.GunaTextBoxCaissier.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCaissier.BorderSize = 1
        Me.GunaTextBoxCaissier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCaissier.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCaissier.Enabled = False
        Me.GunaTextBoxCaissier.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCaissier.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCaissier.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCaissier.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCaissier.Location = New System.Drawing.Point(14, 55)
        Me.GunaTextBoxCaissier.Name = "GunaTextBoxCaissier"
        Me.GunaTextBoxCaissier.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCaissier.Radius = 5
        Me.GunaTextBoxCaissier.SelectedText = ""
        Me.GunaTextBoxCaissier.Size = New System.Drawing.Size(282, 34)
        Me.GunaTextBoxCaissier.TabIndex = 75
        Me.GunaTextBoxCaissier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaTextBoxCaissier.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 16)
        Me.Label5.TabIndex = 73
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 510)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Montant"
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
        Me.GunaTextBoxMontantVerse.Location = New System.Drawing.Point(14, 529)
        Me.GunaTextBoxMontantVerse.Name = "GunaTextBoxMontantVerse"
        Me.GunaTextBoxMontantVerse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMontantVerse.Radius = 5
        Me.GunaTextBoxMontantVerse.SelectedText = ""
        Me.GunaTextBoxMontantVerse.Size = New System.Drawing.Size(143, 31)
        Me.GunaTextBoxMontantVerse.TabIndex = 72
        Me.GunaTextBoxMontantVerse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelSolde
        '
        Me.LabelSolde.AutoSize = True
        Me.LabelSolde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSolde.Location = New System.Drawing.Point(17, 604)
        Me.LabelSolde.Name = "LabelSolde"
        Me.LabelSolde.Size = New System.Drawing.Size(102, 16)
        Me.LabelSolde.TabIndex = 70
        Me.LabelSolde.Text = "Montant retiré"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 445)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 16)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Mode de Sortie"
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
        Me.GunaComboBoxModereglement.Items.AddRange(New Object() {"Espèces"})
        Me.GunaComboBoxModereglement.Location = New System.Drawing.Point(14, 464)
        Me.GunaComboBoxModereglement.Name = "GunaComboBoxModereglement"
        Me.GunaComboBoxModereglement.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxModereglement.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxModereglement.Radius = 4
        Me.GunaComboBoxModereglement.Size = New System.Drawing.Size(202, 31)
        Me.GunaComboBoxModereglement.TabIndex = 77
        '
        'LabelMotif
        '
        Me.LabelMotif.AutoSize = True
        Me.LabelMotif.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMotif.Location = New System.Drawing.Point(237, 458)
        Me.LabelMotif.Name = "LabelMotif"
        Me.LabelMotif.Size = New System.Drawing.Size(41, 16)
        Me.LabelMotif.TabIndex = 70
        Me.LabelMotif.Text = "Motif"
        '
        'GunaTextBoxMotif
        '
        Me.GunaTextBoxMotif.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMotif.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMotif.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMotif.BorderSize = 1
        Me.GunaTextBoxMotif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxMotif.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMotif.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMotif.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMotif.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMotif.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxMotif.Location = New System.Drawing.Point(307, 437)
        Me.GunaTextBoxMotif.Multiline = True
        Me.GunaTextBoxMotif.Name = "GunaTextBoxMotif"
        Me.GunaTextBoxMotif.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMotif.Radius = 5
        Me.GunaTextBoxMotif.SelectedText = ""
        Me.GunaTextBoxMotif.Size = New System.Drawing.Size(272, 58)
        Me.GunaTextBoxMotif.TabIndex = 72
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 661)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(841, 10)
        Me.GunaPanel2.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(180, 604)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Solde en caisse"
        '
        'PanelSituationCaisse
        '
        Me.PanelSituationCaisse.BackColor = System.Drawing.Color.Red
        Me.PanelSituationCaisse.Controls.Add(Me.LabelSituationCaisse)
        Me.PanelSituationCaisse.Location = New System.Drawing.Point(170, 622)
        Me.PanelSituationCaisse.Name = "PanelSituationCaisse"
        Me.PanelSituationCaisse.Size = New System.Drawing.Size(146, 34)
        Me.PanelSituationCaisse.TabIndex = 80
        '
        'LabelSituationCaisse
        '
        Me.LabelSituationCaisse.AutoSize = True
        Me.LabelSituationCaisse.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSituationCaisse.Location = New System.Drawing.Point(31, 5)
        Me.LabelSituationCaisse.Name = "LabelSituationCaisse"
        Me.LabelSituationCaisse.Size = New System.Drawing.Size(20, 24)
        Me.LabelSituationCaisse.TabIndex = 0
        Me.LabelSituationCaisse.Text = "0"
        '
        'GunaComboBoxNatureMovt
        '
        Me.GunaComboBoxNatureMovt.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxNatureMovt.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxNatureMovt.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxNatureMovt.BorderSize = 1
        Me.GunaComboBoxNatureMovt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxNatureMovt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxNatureMovt.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxNatureMovt.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxNatureMovt.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxNatureMovt.FormattingEnabled = True
        Me.GunaComboBoxNatureMovt.ItemHeight = 23
        Me.GunaComboBoxNatureMovt.Location = New System.Drawing.Point(14, 401)
        Me.GunaComboBoxNatureMovt.Name = "GunaComboBoxNatureMovt"
        Me.GunaComboBoxNatureMovt.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxNatureMovt.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxNatureMovt.Size = New System.Drawing.Size(202, 29)
        Me.GunaComboBoxNatureMovt.TabIndex = 86
        '
        'GunaLabelIndexTitreMouvement
        '
        Me.GunaLabelIndexTitreMouvement.AutoSize = True
        Me.GunaLabelIndexTitreMouvement.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelIndexTitreMouvement.ForeColor = System.Drawing.Color.Black
        Me.GunaLabelIndexTitreMouvement.Location = New System.Drawing.Point(302, 28)
        Me.GunaLabelIndexTitreMouvement.Name = "GunaLabelIndexTitreMouvement"
        Me.GunaLabelIndexTitreMouvement.Size = New System.Drawing.Size(151, 25)
        Me.GunaLabelIndexTitreMouvement.TabIndex = 4
        Me.GunaLabelIndexTitreMouvement.Text = "ENCAISSEMENT"
        Me.GunaLabelIndexTitreMouvement.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.GunaLabelIndexTitreMouvement.Visible = False
        '
        'PanelTotalSortie
        '
        Me.PanelTotalSortie.BackColor = System.Drawing.Color.Red
        Me.PanelTotalSortie.Controls.Add(Me.LabelDepense)
        Me.PanelTotalSortie.Location = New System.Drawing.Point(17, 623)
        Me.PanelTotalSortie.Name = "PanelTotalSortie"
        Me.PanelTotalSortie.Size = New System.Drawing.Size(146, 34)
        Me.PanelTotalSortie.TabIndex = 80
        '
        'LabelDepense
        '
        Me.LabelDepense.AutoSize = True
        Me.LabelDepense.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDepense.Location = New System.Drawing.Point(31, 5)
        Me.LabelDepense.Name = "LabelDepense"
        Me.LabelDepense.Size = New System.Drawing.Size(20, 24)
        Me.LabelDepense.TabIndex = 0
        Me.LabelDepense.Text = "0"
        '
        'GunaTextBoxParCaissier
        '
        Me.GunaTextBoxParCaissier.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxParCaissier.BaseColor = System.Drawing.Color.GhostWhite
        Me.GunaTextBoxParCaissier.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxParCaissier.BorderSize = 1
        Me.GunaTextBoxParCaissier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxParCaissier.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxParCaissier.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxParCaissier.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxParCaissier.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxParCaissier.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxParCaissier.Location = New System.Drawing.Point(441, 55)
        Me.GunaTextBoxParCaissier.Name = "GunaTextBoxParCaissier"
        Me.GunaTextBoxParCaissier.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxParCaissier.Radius = 5
        Me.GunaTextBoxParCaissier.SelectedText = ""
        Me.GunaTextBoxParCaissier.Size = New System.Drawing.Size(225, 34)
        Me.GunaTextBoxParCaissier.TabIndex = 75
        Me.GunaTextBoxParCaissier.Visible = False
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton2.ForeColor = System.Drawing.Color.White
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(672, 29)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 4
        Me.GunaButton2.Size = New System.Drawing.Size(69, 27)
        Me.GunaButton2.TabIndex = 87
        Me.GunaButton2.Text = "Filtrer"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton2.Visible = False
        '
        'GunaDataGridView2
        '
        Me.GunaDataGridView2.AllowUserToAddRows = False
        Me.GunaDataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GunaDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.GunaDataGridView2.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.GunaDataGridView2.ColumnHeadersHeight = 4
        Me.GunaDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridView2.ColumnHeadersVisible = False
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView2.DefaultCellStyle = DataGridViewCellStyle12
        Me.GunaDataGridView2.EnableHeadersVisualStyles = False
        Me.GunaDataGridView2.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.Location = New System.Drawing.Point(441, 91)
        Me.GunaDataGridView2.MultiSelect = False
        Me.GunaDataGridView2.Name = "GunaDataGridView2"
        Me.GunaDataGridView2.ReadOnly = True
        Me.GunaDataGridView2.RowHeadersVisible = False
        Me.GunaDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView2.Size = New System.Drawing.Size(300, 118)
        Me.GunaDataGridView2.TabIndex = 88
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
        'GunaTextBoxCodeUserFiltre
        '
        Me.GunaTextBoxCodeUserFiltre.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeUserFiltre.BaseColor = System.Drawing.Color.SlateGray
        Me.GunaTextBoxCodeUserFiltre.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeUserFiltre.BorderSize = 1
        Me.GunaTextBoxCodeUserFiltre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeUserFiltre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeUserFiltre.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeUserFiltre.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeUserFiltre.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeUserFiltre.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeUserFiltre.Location = New System.Drawing.Point(672, 55)
        Me.GunaTextBoxCodeUserFiltre.Name = "GunaTextBoxCodeUserFiltre"
        Me.GunaTextBoxCodeUserFiltre.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeUserFiltre.Radius = 5
        Me.GunaTextBoxCodeUserFiltre.SelectedText = ""
        Me.GunaTextBoxCodeUserFiltre.Size = New System.Drawing.Size(69, 34)
        Me.GunaTextBoxCodeUserFiltre.TabIndex = 75
        Me.GunaTextBoxCodeUserFiltre.Visible = False
        '
        'GunaCheckBoxToutVoir
        '
        Me.GunaCheckBoxToutVoir.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxToutVoir.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxToutVoir.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxToutVoir.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxToutVoir.Location = New System.Drawing.Point(323, 62)
        Me.GunaCheckBoxToutVoir.Name = "GunaCheckBoxToutVoir"
        Me.GunaCheckBoxToutVoir.Size = New System.Drawing.Size(91, 20)
        Me.GunaCheckBoxToutVoir.TabIndex = 89
        Me.GunaCheckBoxToutVoir.Text = "Tous Affiher"
        Me.GunaCheckBoxToutVoir.Visible = False
        '
        'LabelRef
        '
        Me.LabelRef.AutoSize = True
        Me.LabelRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRef.Location = New System.Drawing.Point(366, 380)
        Me.LabelRef.Name = "LabelRef"
        Me.LabelRef.Size = New System.Drawing.Size(55, 16)
        Me.LabelRef.TabIndex = 70
        Me.LabelRef.Text = "Libéllé"
        '
        'GunaTextBoxReference
        '
        Me.GunaTextBoxReference.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxReference.BaseColor = System.Drawing.Color.LightPink
        Me.GunaTextBoxReference.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxReference.BorderSize = 1
        Me.GunaTextBoxReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxReference.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxReference.Enabled = False
        Me.GunaTextBoxReference.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxReference.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxReference.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxReference.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxReference.Location = New System.Drawing.Point(369, 399)
        Me.GunaTextBoxReference.Name = "GunaTextBoxReference"
        Me.GunaTextBoxReference.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxReference.Radius = 5
        Me.GunaTextBoxReference.SelectedText = ""
        Me.GunaTextBoxReference.Size = New System.Drawing.Size(455, 32)
        Me.GunaTextBoxReference.TabIndex = 72
        '
        'GunaTextBoxCodePetiteCaisse
        '
        Me.GunaTextBoxCodePetiteCaisse.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodePetiteCaisse.BaseColor = System.Drawing.Color.SlateGray
        Me.GunaTextBoxCodePetiteCaisse.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodePetiteCaisse.BorderSize = 1
        Me.GunaTextBoxCodePetiteCaisse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodePetiteCaisse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodePetiteCaisse.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodePetiteCaisse.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodePetiteCaisse.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodePetiteCaisse.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodePetiteCaisse.Location = New System.Drawing.Point(179, 27)
        Me.GunaTextBoxCodePetiteCaisse.Name = "GunaTextBoxCodePetiteCaisse"
        Me.GunaTextBoxCodePetiteCaisse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodePetiteCaisse.Radius = 5
        Me.GunaTextBoxCodePetiteCaisse.SelectedText = ""
        Me.GunaTextBoxCodePetiteCaisse.Size = New System.Drawing.Size(117, 28)
        Me.GunaTextBoxCodePetiteCaisse.TabIndex = 75
        Me.GunaTextBoxCodePetiteCaisse.Visible = False
        '
        'PanelServiceDemandeur
        '
        Me.PanelServiceDemandeur.Controls.Add(Me.GunaComboBoxProfilUtilisateur)
        Me.PanelServiceDemandeur.Controls.Add(Me.Label4)
        Me.PanelServiceDemandeur.Location = New System.Drawing.Point(236, 510)
        Me.PanelServiceDemandeur.Name = "PanelServiceDemandeur"
        Me.PanelServiceDemandeur.Size = New System.Drawing.Size(340, 60)
        Me.PanelServiceDemandeur.TabIndex = 95
        '
        'GunaComboBoxProfilUtilisateur
        '
        Me.GunaComboBoxProfilUtilisateur.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxProfilUtilisateur.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxProfilUtilisateur.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxProfilUtilisateur.BorderSize = 1
        Me.GunaComboBoxProfilUtilisateur.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxProfilUtilisateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxProfilUtilisateur.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxProfilUtilisateur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxProfilUtilisateur.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxProfilUtilisateur.FormattingEnabled = True
        Me.GunaComboBoxProfilUtilisateur.ItemHeight = 23
        Me.GunaComboBoxProfilUtilisateur.Location = New System.Drawing.Point(8, 26)
        Me.GunaComboBoxProfilUtilisateur.Name = "GunaComboBoxProfilUtilisateur"
        Me.GunaComboBoxProfilUtilisateur.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxProfilUtilisateur.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxProfilUtilisateur.Radius = 4
        Me.GunaComboBoxProfilUtilisateur.Size = New System.Drawing.Size(321, 29)
        Me.GunaComboBoxProfilUtilisateur.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 16)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Service demandeur"
        '
        'GunaTextBoxPLafonds
        '
        Me.GunaTextBoxPLafonds.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxPLafonds.BaseColor = System.Drawing.Color.LightBlue
        Me.GunaTextBoxPLafonds.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxPLafonds.BorderSize = 1
        Me.GunaTextBoxPLafonds.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxPLafonds.Enabled = False
        Me.GunaTextBoxPLafonds.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxPLafonds.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxPLafonds.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxPLafonds.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GunaTextBoxPLafonds.ForeColor = System.Drawing.Color.White
        Me.GunaTextBoxPLafonds.Location = New System.Drawing.Point(23, 45)
        Me.GunaTextBoxPLafonds.Name = "GunaTextBoxPLafonds"
        Me.GunaTextBoxPLafonds.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxPLafonds.Radius = 5
        Me.GunaTextBoxPLafonds.SelectedText = ""
        Me.GunaTextBoxPLafonds.Size = New System.Drawing.Size(129, 36)
        Me.GunaTextBoxPLafonds.TabIndex = 96
        Me.GunaTextBoxPLafonds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 16)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Montant du Plafonds"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(158, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 16)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "FCFA"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 88)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(807, 290)
        Me.TabControl1.TabIndex = 97
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GunaDataGridViewTransactionPetiteCaisse)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(799, 261)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Transactions Terminées"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GunaDataGridViewRemboursementEnAttente)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(799, 261)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Remboursements en attentes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GunaDataGridViewRemboursementEnAttente
        '
        Me.GunaDataGridViewRemboursementEnAttente.AllowUserToAddRows = False
        Me.GunaDataGridViewRemboursementEnAttente.AllowUserToDeleteRows = False
        Me.GunaDataGridViewRemboursementEnAttente.AllowUserToOrderColumns = True
        Me.GunaDataGridViewRemboursementEnAttente.AllowUserToResizeColumns = False
        Me.GunaDataGridViewRemboursementEnAttente.AllowUserToResizeRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewRemboursementEnAttente.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.GunaDataGridViewRemboursementEnAttente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GunaDataGridViewRemboursementEnAttente.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewRemboursementEnAttente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewRemboursementEnAttente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewRemboursementEnAttente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewRemboursementEnAttente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.GunaDataGridViewRemboursementEnAttente.ColumnHeadersHeight = 25
        Me.GunaDataGridViewRemboursementEnAttente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewRemboursementEnAttente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewRemboursementEnAttente.DefaultCellStyle = DataGridViewCellStyle18
        Me.GunaDataGridViewRemboursementEnAttente.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewRemboursementEnAttente.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewRemboursementEnAttente.Location = New System.Drawing.Point(7, 7)
        Me.GunaDataGridViewRemboursementEnAttente.Name = "GunaDataGridViewRemboursementEnAttente"
        Me.GunaDataGridViewRemboursementEnAttente.ReadOnly = True
        Me.GunaDataGridViewRemboursementEnAttente.RowHeadersVisible = False
        Me.GunaDataGridViewRemboursementEnAttente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GunaDataGridViewRemboursementEnAttente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewRemboursementEnAttente.Size = New System.Drawing.Size(785, 247)
        Me.GunaDataGridViewRemboursementEnAttente.TabIndex = 18
        Me.GunaDataGridViewRemboursementEnAttente.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridViewRemboursementEnAttente.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 65
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Référence"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 106
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 113
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Montant déposé"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 147
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Montant retiré"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 133
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Receveur"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Approuvé par"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 129
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "effectué par"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 119
        '
        'GunaPaneInfoSupReceveur
        '
        Me.GunaPaneInfoSupReceveur.Controls.Add(Me.GunaTextBoxApprouvePar)
        Me.GunaPaneInfoSupReceveur.Controls.Add(Me.GunaTextBoxCNIDuReceveur)
        Me.GunaPaneInfoSupReceveur.Controls.Add(Me.GunaTextBoxNomDuReceveur)
        Me.GunaPaneInfoSupReceveur.Controls.Add(Me.Label9)
        Me.GunaPaneInfoSupReceveur.Controls.Add(Me.LabelCNI)
        Me.GunaPaneInfoSupReceveur.Controls.Add(Me.LabelNomReceveur)
        Me.GunaPaneInfoSupReceveur.Location = New System.Drawing.Point(585, 438)
        Me.GunaPaneInfoSupReceveur.Name = "GunaPaneInfoSupReceveur"
        Me.GunaPaneInfoSupReceveur.Size = New System.Drawing.Size(241, 168)
        Me.GunaPaneInfoSupReceveur.TabIndex = 98
        '
        'GunaTextBoxApprouvePar
        '
        Me.GunaTextBoxApprouvePar.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxApprouvePar.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxApprouvePar.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxApprouvePar.BorderSize = 1
        Me.GunaTextBoxApprouvePar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxApprouvePar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxApprouvePar.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxApprouvePar.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxApprouvePar.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxApprouvePar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxApprouvePar.Location = New System.Drawing.Point(9, 130)
        Me.GunaTextBoxApprouvePar.Multiline = True
        Me.GunaTextBoxApprouvePar.Name = "GunaTextBoxApprouvePar"
        Me.GunaTextBoxApprouvePar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxApprouvePar.Radius = 5
        Me.GunaTextBoxApprouvePar.SelectedText = ""
        Me.GunaTextBoxApprouvePar.Size = New System.Drawing.Size(224, 28)
        Me.GunaTextBoxApprouvePar.TabIndex = 75
        '
        'GunaTextBoxCNIDuReceveur
        '
        Me.GunaTextBoxCNIDuReceveur.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCNIDuReceveur.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCNIDuReceveur.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCNIDuReceveur.BorderSize = 1
        Me.GunaTextBoxCNIDuReceveur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCNIDuReceveur.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCNIDuReceveur.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCNIDuReceveur.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCNIDuReceveur.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCNIDuReceveur.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCNIDuReceveur.Location = New System.Drawing.Point(9, 75)
        Me.GunaTextBoxCNIDuReceveur.Multiline = True
        Me.GunaTextBoxCNIDuReceveur.Name = "GunaTextBoxCNIDuReceveur"
        Me.GunaTextBoxCNIDuReceveur.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCNIDuReceveur.Radius = 5
        Me.GunaTextBoxCNIDuReceveur.SelectedText = ""
        Me.GunaTextBoxCNIDuReceveur.Size = New System.Drawing.Size(224, 28)
        Me.GunaTextBoxCNIDuReceveur.TabIndex = 75
        '
        'GunaTextBoxNomDuReceveur
        '
        Me.GunaTextBoxNomDuReceveur.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxNomDuReceveur.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomDuReceveur.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxNomDuReceveur.BorderSize = 1
        Me.GunaTextBoxNomDuReceveur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxNomDuReceveur.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxNomDuReceveur.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxNomDuReceveur.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxNomDuReceveur.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxNomDuReceveur.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxNomDuReceveur.Location = New System.Drawing.Point(9, 22)
        Me.GunaTextBoxNomDuReceveur.Multiline = True
        Me.GunaTextBoxNomDuReceveur.Name = "GunaTextBoxNomDuReceveur"
        Me.GunaTextBoxNomDuReceveur.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxNomDuReceveur.Radius = 5
        Me.GunaTextBoxNomDuReceveur.SelectedText = ""
        Me.GunaTextBoxNomDuReceveur.Size = New System.Drawing.Size(224, 28)
        Me.GunaTextBoxNomDuReceveur.TabIndex = 76
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 16)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "APPROUVE PAR"
        '
        'LabelCNI
        '
        Me.LabelCNI.AutoSize = True
        Me.LabelCNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCNI.Location = New System.Drawing.Point(6, 58)
        Me.LabelCNI.Name = "LabelCNI"
        Me.LabelCNI.Size = New System.Drawing.Size(33, 16)
        Me.LabelCNI.TabIndex = 73
        Me.LabelCNI.Text = "CNI"
        '
        'LabelNomReceveur
        '
        Me.LabelNomReceveur.AutoSize = True
        Me.LabelNomReceveur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNomReceveur.Location = New System.Drawing.Point(6, 4)
        Me.LabelNomReceveur.Name = "LabelNomReceveur"
        Me.LabelNomReceveur.Size = New System.Drawing.Size(126, 16)
        Me.LabelNomReceveur.TabIndex = 74
        Me.LabelNomReceveur.Text = "Nom du receveur"
        '
        'GunaCheckBoxTiers
        '
        Me.GunaCheckBoxTiers.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxTiers.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxTiers.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxTiers.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxTiers.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxTiers.Location = New System.Drawing.Point(170, 534)
        Me.GunaCheckBoxTiers.Name = "GunaCheckBoxTiers"
        Me.GunaCheckBoxTiers.Size = New System.Drawing.Size(62, 20)
        Me.GunaCheckBoxTiers.TabIndex = 99
        Me.GunaCheckBoxTiers.Text = "Tiers"
        '
        'GunaPanelTiers
        '
        Me.GunaPanelTiers.Controls.Add(Me.GunaComboBoxFournisseur)
        Me.GunaPanelTiers.Controls.Add(Me.Label8)
        Me.GunaPanelTiers.Location = New System.Drawing.Point(237, 509)
        Me.GunaPanelTiers.Name = "GunaPanelTiers"
        Me.GunaPanelTiers.Size = New System.Drawing.Size(340, 60)
        Me.GunaPanelTiers.TabIndex = 100
        Me.GunaPanelTiers.Visible = False
        '
        'GunaComboBoxFournisseur
        '
        Me.GunaComboBoxFournisseur.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxFournisseur.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxFournisseur.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxFournisseur.BorderSize = 1
        Me.GunaComboBoxFournisseur.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxFournisseur.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxFournisseur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxFournisseur.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxFournisseur.FormattingEnabled = True
        Me.GunaComboBoxFournisseur.ItemHeight = 23
        Me.GunaComboBoxFournisseur.Location = New System.Drawing.Point(6, 26)
        Me.GunaComboBoxFournisseur.Name = "GunaComboBoxFournisseur"
        Me.GunaComboBoxFournisseur.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxFournisseur.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxFournisseur.Radius = 4
        Me.GunaComboBoxFournisseur.Size = New System.Drawing.Size(321, 29)
        Me.GunaComboBoxFournisseur.TabIndex = 97
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 16)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "Fournisseurs"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(240, 380)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Référence"
        '
        'GunaTextBoxCodeRefrence
        '
        Me.GunaTextBoxCodeRefrence.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeRefrence.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeRefrence.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeRefrence.BorderSize = 1
        Me.GunaTextBoxCodeRefrence.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeRefrence.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeRefrence.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeRefrence.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeRefrence.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeRefrence.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeRefrence.Location = New System.Drawing.Point(244, 399)
        Me.GunaTextBoxCodeRefrence.Name = "GunaTextBoxCodeRefrence"
        Me.GunaTextBoxCodeRefrence.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeRefrence.Radius = 5
        Me.GunaTextBoxCodeRefrence.SelectedText = ""
        Me.GunaTextBoxCodeRefrence.Size = New System.Drawing.Size(119, 32)
        Me.GunaTextBoxCodeRefrence.TabIndex = 72
        '
        'GunaButtonImprimerListeDesComptes
        '
        Me.GunaButtonImprimerListeDesComptes.AnimationHoverSpeed = 0.07!
        Me.GunaButtonImprimerListeDesComptes.AnimationSpeed = 0.03!
        Me.GunaButtonImprimerListeDesComptes.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonImprimerListeDesComptes.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonImprimerListeDesComptes.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonImprimerListeDesComptes.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonImprimerListeDesComptes.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonImprimerListeDesComptes.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonImprimerListeDesComptes.ForeColor = System.Drawing.Color.White
        Me.GunaButtonImprimerListeDesComptes.Image = CType(resources.GetObject("GunaButtonImprimerListeDesComptes.Image"), System.Drawing.Image)
        Me.GunaButtonImprimerListeDesComptes.ImageSize = New System.Drawing.Size(30, 30)
        Me.GunaButtonImprimerListeDesComptes.Location = New System.Drawing.Point(576, 619)
        Me.GunaButtonImprimerListeDesComptes.Name = "GunaButtonImprimerListeDesComptes"
        Me.GunaButtonImprimerListeDesComptes.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonImprimerListeDesComptes.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonImprimerListeDesComptes.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonImprimerListeDesComptes.OnHoverImage = Nothing
        Me.GunaButtonImprimerListeDesComptes.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonImprimerListeDesComptes.Radius = 4
        Me.GunaButtonImprimerListeDesComptes.Size = New System.Drawing.Size(113, 34)
        Me.GunaButtonImprimerListeDesComptes.TabIndex = 94
        Me.GunaButtonImprimerListeDesComptes.Text = "Imprimer"
        Me.GunaButtonImprimerListeDesComptes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GunaButtonImprimerListeDesComptes.Visible = False
        '
        'GunaButtonHistoriques
        '
        Me.GunaButtonHistoriques.AnimationHoverSpeed = 0.07!
        Me.GunaButtonHistoriques.AnimationSpeed = 0.03!
        Me.GunaButtonHistoriques.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonHistoriques.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonHistoriques.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonHistoriques.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonHistoriques.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonHistoriques.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonHistoriques.ForeColor = System.Drawing.Color.White
        Me.GunaButtonHistoriques.Image = Nothing
        Me.GunaButtonHistoriques.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonHistoriques.Location = New System.Drawing.Point(687, 80)
        Me.GunaButtonHistoriques.Name = "GunaButtonHistoriques"
        Me.GunaButtonHistoriques.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonHistoriques.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonHistoriques.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonHistoriques.OnHoverImage = Nothing
        Me.GunaButtonHistoriques.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonHistoriques.Radius = 4
        Me.GunaButtonHistoriques.Size = New System.Drawing.Size(128, 27)
        Me.GunaButtonHistoriques.TabIndex = 87
        Me.GunaButtonHistoriques.Text = "Historiques"
        Me.GunaButtonHistoriques.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'BackgroundWorker5
        '
        Me.BackgroundWorker5.WorkerSupportsCancellation = True
        '
        'BackgroundWorker6
        '
        Me.BackgroundWorker6.WorkerSupportsCancellation = True
        '
        'BackgroundWorker7
        '
        Me.BackgroundWorker7.WorkerSupportsCancellation = True
        '
        'BackgroundWorker8
        '
        Me.BackgroundWorker8.WorkerSupportsCancellation = True
        '
        'BackgroundWorker9
        '
        Me.BackgroundWorker9.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'PetiteCaisseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LemonChiffon
        Me.ClientSize = New System.Drawing.Size(834, 672)
        Me.Controls.Add(Me.GunaButtonHistoriques)
        Me.Controls.Add(Me.GunaPanelTiers)
        Me.Controls.Add(Me.GunaCheckBoxTiers)
        Me.Controls.Add(Me.GunaPaneInfoSupReceveur)
        Me.Controls.Add(Me.GunaDataGridView2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GunaTextBoxPLafonds)
        Me.Controls.Add(Me.PanelServiceDemandeur)
        Me.Controls.Add(Me.GunaButtonImprimerListeDesComptes)
        Me.Controls.Add(Me.GunaCheckBoxToutVoir)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaComboBoxNatureMovt)
        Me.Controls.Add(Me.PanelTotalSortie)
        Me.Controls.Add(Me.PanelSituationCaisse)
        Me.Controls.Add(Me.GunaLabelIndexTitreMouvement)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaComboBoxModereglement)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GunaTextBoxCodePetiteCaisse)
        Me.Controls.Add(Me.GunaTextBoxCodeUserFiltre)
        Me.Controls.Add(Me.GunaTextBoxParCaissier)
        Me.Controls.Add(Me.GunaTextBoxCaissier)
        Me.Controls.Add(Me.GunaTextBoxNom)
        Me.Controls.Add(Me.GunaTextBoxCodeRefrence)
        Me.Controls.Add(Me.GunaTextBoxReference)
        Me.Controls.Add(Me.GunaTextBoxMotif)
        Me.Controls.Add(Me.GunaTextBoxMontantVerse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LabelRef)
        Me.Controls.Add(Me.LabelSolde)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LabelMotif)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelMontantAPayer)
        Me.Controls.Add(Me.GunaButtonEnregistrerReglement)
        Me.Controls.Add(Me.GunaButtonOuvertureFermeture)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PetiteCaisseForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClientForm"
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.GunaDataGridViewTransactionPetiteCaisse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSituationCaisse.ResumeLayout(False)
        Me.PanelSituationCaisse.PerformLayout()
        Me.PanelTotalSortie.ResumeLayout(False)
        Me.PanelTotalSortie.PerformLayout()
        CType(Me.GunaDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelServiceDemandeur.ResumeLayout(False)
        Me.PanelServiceDemandeur.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.GunaDataGridViewRemboursementEnAttente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPaneInfoSupReceveur.ResumeLayout(False)
        Me.GunaPaneInfoSupReceveur.PerformLayout()
        Me.GunaPanelTiers.ResumeLayout(False)
        Me.GunaPanelTiers.PerformLayout()
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
    Friend WithEvents GunaButtonOuvertureFermeture As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButtonReduce As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButtonFermer As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents LabelMontantAPayer As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GunaTextBoxCaissier As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNom As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaDataGridViewTransactionPetiteCaisse As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaComboBoxModereglement As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaTextBoxMotif As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxMontantVerse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelSolde As Label
    Friend WithEvents LabelMotif As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelSituationCaisse As Panel
    Friend WithEvents LabelSituationCaisse As Label
    Friend WithEvents GunaComboBoxNatureMovt As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabelIndexTitreMouvement As Guna.UI.WinForms.GunaLabel
    Friend WithEvents PanelTotalSortie As Panel
    Friend WithEvents LabelDepense As Label
    Friend WithEvents GunaTextBoxParCaissier As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDataGridView2 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaTextBoxCodeUserFiltre As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaCheckBoxToutVoir As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaTextBoxReference As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelRef As Label
    Friend WithEvents GunaTextBoxCodePetiteCaisse As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButtonImprimerListeDesComptes As Guna.UI.WinForms.GunaButton
    Friend WithEvents PanelServiceDemandeur As Panel
    Friend WithEvents GunaComboBoxProfilUtilisateur As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GunaTextBoxPLafonds As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GunaPaneInfoSupReceveur As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxCNIDuReceveur As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxNomDuReceveur As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents LabelCNI As Label
    Friend WithEvents LabelNomReceveur As Label
    Friend WithEvents GunaCheckBoxTiers As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaPanelTiers As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaComboBoxFournisseur As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DateOperation As DataGridViewTextBoxColumn
    Friend WithEvents num_reglement As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Debit As DataGridViewTextBoxColumn
    Friend WithEvents Credit As DataGridViewTextBoxColumn
    Friend WithEvents receveur As DataGridViewTextBoxColumn
    Friend WithEvents approuve As DataGridViewTextBoxColumn
    Friend WithEvents effectue As DataGridViewTextBoxColumn
    Friend WithEvents GunaTextBoxApprouvePar As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GunaTextBoxCodeRefrence As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GunaButtonHistoriques As Guna.UI.WinForms.GunaButton
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GunaDataGridViewRemboursementEnAttente As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents GunaTextBoxRefEntreeEnAttntes As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker5 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker6 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker7 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker8 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker9 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
End Class
