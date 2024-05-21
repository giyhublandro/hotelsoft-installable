<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiniSageCompatibiliteForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MiniSageCompatibiliteForm))
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ajout d'une pièce")
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Visualisation/Modification d'une pièce")
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Saisie des opérations bancaires")
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Saisie des écritures")
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recherche d'écritures")
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Journaux de saisie")
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Créer un compte général")
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Plan comptable")
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Code Journaux")
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Saisie des écritures", New System.Windows.Forms.TreeNode() {TreeNode35, TreeNode36, TreeNode37, TreeNode38, TreeNode39, TreeNode40, TreeNode41, TreeNode42, TreeNode43})
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Créer un client")
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Créer un fournisseur")
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Plan tiers")
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Interrogation tiers")
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Grand livre tiers")
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Balance tiers")
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion et suivi des Tiers", New System.Windows.Forms.TreeNode() {TreeNode45, TreeNode46, TreeNode47, TreeNode48, TreeNode49, TreeNode50})
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contrôle de caisse")
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rapprochement bancaire manuel")
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rapprochement bancaire auto")
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Synchro compta")
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traitements périodiques", New System.Windows.Forms.TreeNode() {TreeNode52, TreeNode53, TreeNode54, TreeNode55})
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Brouillard")
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Journaux comptables")
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Journal général")
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Grand-livre des comptes")
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Balance des comptes")
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Etat déclaration de taxes")
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bilan / compte de resultat")
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Etat comptables et fiscaux", New System.Windows.Forms.TreeNode() {TreeNode57, TreeNode58, TreeNode59, TreeNode60, TreeNode61, TreeNode62, TreeNode63})
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nouvel exercice / reports des AN")
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Export balance")
        Dim TreeNode67 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clôture des journaux")
        Dim TreeNode68 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fin exercice", New System.Windows.Forms.TreeNode() {TreeNode65, TreeNode66, TreeNode67})
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabelTitreDeLaFenetre = New Guna.UI.WinForms.GunaLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouveauToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FermerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AProposDeVotreSociétéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImporterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExporterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnnulerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CouperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.EffacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SélectionnerToutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.DupliauerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.InverserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculetteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AjouterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VoirmodifierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsulterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrécédentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuivantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechercherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtteindreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLeJournalDeTraitementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StructureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanComptabeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanAnalytiqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanReportingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanTiersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TauxDeTaxesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeJournauxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeJournauxAnalytiqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BanquesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModèlesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModeRèglementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibellésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PosteBudgétaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CycleDeRévisionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FusionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TraitementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaisieParPièceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaisieDesOpérationsBancairesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaisieDesÉcrituresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.JounauxDeSaisieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClôtureDesJournauxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.RèglementTiersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EtatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FenêtreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GunaLinePanel1 = New Guna.UI.WinForms.GunaLinePanel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.RechercheDécrituresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.GunaLabelTitreDeLaFenetre)
        Me.GunaPanel1.Controls.Add(Me.PictureBox2)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanel1.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1200, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaLabelTitreDeLaFenetre
        '
        Me.GunaLabelTitreDeLaFenetre.AutoSize = True
        Me.GunaLabelTitreDeLaFenetre.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelTitreDeLaFenetre.ForeColor = System.Drawing.Color.White
        Me.GunaLabelTitreDeLaFenetre.Location = New System.Drawing.Point(469, 1)
        Me.GunaLabelTitreDeLaFenetre.Name = "GunaLabelTitreDeLaFenetre"
        Me.GunaLabelTitreDeLaFenetre.Size = New System.Drawing.Size(215, 25)
        Me.GunaLabelTitreDeLaFenetre.TabIndex = 26
        Me.GunaLabelTitreDeLaFenetre.Text = "ECRITURE COMPTABLE"
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(1146, 3)
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
        Me.GunaImageButton1.Location = New System.Drawing.Point(1170, 3)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2367, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.EditionToolStripMenuItem, Me.StructureToolStripMenuItem, Me.TraitementToolStripMenuItem, Me.EtatToolStripMenuItem, Me.FenêtreToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 26)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(433, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauToolStripMenuItem, Me.OuvrirToolStripMenuItem, Me.FermerToolStripMenuItem, Me.ToolStripSeparator3, Me.AProposDeVotreSociétéToolStripMenuItem, Me.ToolStripSeparator1, Me.ImporterToolStripMenuItem, Me.ExporterToolStripMenuItem, Me.ToolStripSeparator2, Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'NouveauToolStripMenuItem
        '
        Me.NouveauToolStripMenuItem.Name = "NouveauToolStripMenuItem"
        Me.NouveauToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NouveauToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.NouveauToolStripMenuItem.Text = "Nouveau"
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        Me.OuvrirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OuvrirToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.OuvrirToolStripMenuItem.Text = "Ouvrir"
        '
        'FermerToolStripMenuItem
        '
        Me.FermerToolStripMenuItem.Name = "FermerToolStripMenuItem"
        Me.FermerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.FermerToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.FermerToolStripMenuItem.Text = "Fermer"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(232, 6)
        '
        'AProposDeVotreSociétéToolStripMenuItem
        '
        Me.AProposDeVotreSociétéToolStripMenuItem.Name = "AProposDeVotreSociétéToolStripMenuItem"
        Me.AProposDeVotreSociétéToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.AProposDeVotreSociétéToolStripMenuItem.Text = "A propos de votre société"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(232, 6)
        '
        'ImporterToolStripMenuItem
        '
        Me.ImporterToolStripMenuItem.Name = "ImporterToolStripMenuItem"
        Me.ImporterToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.ImporterToolStripMenuItem.Text = "Importer"
        '
        'ExporterToolStripMenuItem
        '
        Me.ExporterToolStripMenuItem.Name = "ExporterToolStripMenuItem"
        Me.ExporterToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.ExporterToolStripMenuItem.Text = "Exporter"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(232, 6)
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'EditionToolStripMenuItem
        '
        Me.EditionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnnulerToolStripMenuItem, Me.ToolStripSeparator4, Me.CouperToolStripMenuItem, Me.CopierToolStripMenuItem, Me.CollerToolStripMenuItem, Me.ToolStripSeparator5, Me.EffacerToolStripMenuItem, Me.SélectionnerToutToolStripMenuItem, Me.ToolStripSeparator6, Me.DupliauerToolStripMenuItem, Me.ToolStripSeparator7, Me.InverserToolStripMenuItem, Me.CalculetteToolStripMenuItem, Me.ToolStripSeparator8, Me.AjouterToolStripMenuItem, Me.VoirmodifierToolStripMenuItem, Me.ConsulterToolStripMenuItem, Me.SupprimerToolStripMenuItem, Me.PrécédentToolStripMenuItem, Me.SuivantToolStripMenuItem, Me.RechercherToolStripMenuItem, Me.AtteindreToolStripMenuItem, Me.AfficherLeJournalDeTraitementToolStripMenuItem})
        Me.EditionToolStripMenuItem.Name = "EditionToolStripMenuItem"
        Me.EditionToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.EditionToolStripMenuItem.Text = "Edition"
        '
        'AnnulerToolStripMenuItem
        '
        Me.AnnulerToolStripMenuItem.Name = "AnnulerToolStripMenuItem"
        Me.AnnulerToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.AnnulerToolStripMenuItem.Text = "Annuler"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(268, 6)
        '
        'CouperToolStripMenuItem
        '
        Me.CouperToolStripMenuItem.Name = "CouperToolStripMenuItem"
        Me.CouperToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.CouperToolStripMenuItem.Text = "Couper"
        '
        'CopierToolStripMenuItem
        '
        Me.CopierToolStripMenuItem.Name = "CopierToolStripMenuItem"
        Me.CopierToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.CopierToolStripMenuItem.Text = "Copier"
        '
        'CollerToolStripMenuItem
        '
        Me.CollerToolStripMenuItem.Name = "CollerToolStripMenuItem"
        Me.CollerToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.CollerToolStripMenuItem.Text = "Coller"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(268, 6)
        '
        'EffacerToolStripMenuItem
        '
        Me.EffacerToolStripMenuItem.Name = "EffacerToolStripMenuItem"
        Me.EffacerToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.EffacerToolStripMenuItem.Text = "Effacer"
        '
        'SélectionnerToutToolStripMenuItem
        '
        Me.SélectionnerToutToolStripMenuItem.Name = "SélectionnerToutToolStripMenuItem"
        Me.SélectionnerToutToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.SélectionnerToutToolStripMenuItem.Text = "Sélectionner tout"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(268, 6)
        '
        'DupliauerToolStripMenuItem
        '
        Me.DupliauerToolStripMenuItem.Name = "DupliauerToolStripMenuItem"
        Me.DupliauerToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.DupliauerToolStripMenuItem.Text = "Dupliquer"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(268, 6)
        '
        'InverserToolStripMenuItem
        '
        Me.InverserToolStripMenuItem.Name = "InverserToolStripMenuItem"
        Me.InverserToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.InverserToolStripMenuItem.Text = "Inverser"
        '
        'CalculetteToolStripMenuItem
        '
        Me.CalculetteToolStripMenuItem.Name = "CalculetteToolStripMenuItem"
        Me.CalculetteToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.CalculetteToolStripMenuItem.Text = "Calculette"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(268, 6)
        '
        'AjouterToolStripMenuItem
        '
        Me.AjouterToolStripMenuItem.Name = "AjouterToolStripMenuItem"
        Me.AjouterToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.AjouterToolStripMenuItem.Text = "Ajouter"
        '
        'VoirmodifierToolStripMenuItem
        '
        Me.VoirmodifierToolStripMenuItem.Name = "VoirmodifierToolStripMenuItem"
        Me.VoirmodifierToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.VoirmodifierToolStripMenuItem.Text = "Voir/modifier"
        '
        'ConsulterToolStripMenuItem
        '
        Me.ConsulterToolStripMenuItem.Name = "ConsulterToolStripMenuItem"
        Me.ConsulterToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.ConsulterToolStripMenuItem.Text = "Consulter"
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'PrécédentToolStripMenuItem
        '
        Me.PrécédentToolStripMenuItem.Name = "PrécédentToolStripMenuItem"
        Me.PrécédentToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.PrécédentToolStripMenuItem.Text = "Précédent"
        '
        'SuivantToolStripMenuItem
        '
        Me.SuivantToolStripMenuItem.Name = "SuivantToolStripMenuItem"
        Me.SuivantToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.SuivantToolStripMenuItem.Text = "Suivant"
        '
        'RechercherToolStripMenuItem
        '
        Me.RechercherToolStripMenuItem.Name = "RechercherToolStripMenuItem"
        Me.RechercherToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.RechercherToolStripMenuItem.Text = "Rechercher"
        '
        'AtteindreToolStripMenuItem
        '
        Me.AtteindreToolStripMenuItem.Name = "AtteindreToolStripMenuItem"
        Me.AtteindreToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.AtteindreToolStripMenuItem.Text = "Atteindre"
        '
        'AfficherLeJournalDeTraitementToolStripMenuItem
        '
        Me.AfficherLeJournalDeTraitementToolStripMenuItem.Name = "AfficherLeJournalDeTraitementToolStripMenuItem"
        Me.AfficherLeJournalDeTraitementToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.AfficherLeJournalDeTraitementToolStripMenuItem.Text = "Afficher le journal de traitement"
        '
        'StructureToolStripMenuItem
        '
        Me.StructureToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlanComptabeToolStripMenuItem, Me.PlanAnalytiqueToolStripMenuItem, Me.PlanReportingToolStripMenuItem, Me.PlanTiersToolStripMenuItem, Me.TauxDeTaxesToolStripMenuItem, Me.CodeJournauxToolStripMenuItem, Me.CodeJournauxAnalytiqueToolStripMenuItem, Me.BanquesToolStripMenuItem, Me.ModèlesToolStripMenuItem, Me.LibellésToolStripMenuItem, Me.PosteBudgétaireToolStripMenuItem, Me.CycleDeRévisionToolStripMenuItem, Me.FusionToolStripMenuItem})
        Me.StructureToolStripMenuItem.Name = "StructureToolStripMenuItem"
        Me.StructureToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.StructureToolStripMenuItem.Text = "Structure"
        '
        'PlanComptabeToolStripMenuItem
        '
        Me.PlanComptabeToolStripMenuItem.Name = "PlanComptabeToolStripMenuItem"
        Me.PlanComptabeToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.PlanComptabeToolStripMenuItem.Text = "Plan comptable"
        '
        'PlanAnalytiqueToolStripMenuItem
        '
        Me.PlanAnalytiqueToolStripMenuItem.Name = "PlanAnalytiqueToolStripMenuItem"
        Me.PlanAnalytiqueToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.PlanAnalytiqueToolStripMenuItem.Text = "Plan analytique"
        '
        'PlanReportingToolStripMenuItem
        '
        Me.PlanReportingToolStripMenuItem.Name = "PlanReportingToolStripMenuItem"
        Me.PlanReportingToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.PlanReportingToolStripMenuItem.Text = "Plan reporting"
        '
        'PlanTiersToolStripMenuItem
        '
        Me.PlanTiersToolStripMenuItem.Name = "PlanTiersToolStripMenuItem"
        Me.PlanTiersToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.PlanTiersToolStripMenuItem.Text = "Plan tiers"
        '
        'TauxDeTaxesToolStripMenuItem
        '
        Me.TauxDeTaxesToolStripMenuItem.Name = "TauxDeTaxesToolStripMenuItem"
        Me.TauxDeTaxesToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.TauxDeTaxesToolStripMenuItem.Text = "Taux de taxes"
        '
        'CodeJournauxToolStripMenuItem
        '
        Me.CodeJournauxToolStripMenuItem.Name = "CodeJournauxToolStripMenuItem"
        Me.CodeJournauxToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.CodeJournauxToolStripMenuItem.Text = "Code journaux"
        '
        'CodeJournauxAnalytiqueToolStripMenuItem
        '
        Me.CodeJournauxAnalytiqueToolStripMenuItem.Name = "CodeJournauxAnalytiqueToolStripMenuItem"
        Me.CodeJournauxAnalytiqueToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.CodeJournauxAnalytiqueToolStripMenuItem.Text = "Code journaux analytique"
        '
        'BanquesToolStripMenuItem
        '
        Me.BanquesToolStripMenuItem.Name = "BanquesToolStripMenuItem"
        Me.BanquesToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.BanquesToolStripMenuItem.Text = "Banques"
        '
        'ModèlesToolStripMenuItem
        '
        Me.ModèlesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModeRèglementToolStripMenuItem})
        Me.ModèlesToolStripMenuItem.Name = "ModèlesToolStripMenuItem"
        Me.ModèlesToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.ModèlesToolStripMenuItem.Text = "Modèles"
        '
        'ModeRèglementToolStripMenuItem
        '
        Me.ModeRèglementToolStripMenuItem.Name = "ModeRèglementToolStripMenuItem"
        Me.ModeRèglementToolStripMenuItem.Size = New System.Drawing.Size(215, 24)
        Me.ModeRèglementToolStripMenuItem.Text = "Modèles de règlement"
        '
        'LibellésToolStripMenuItem
        '
        Me.LibellésToolStripMenuItem.Name = "LibellésToolStripMenuItem"
        Me.LibellésToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.LibellésToolStripMenuItem.Text = "Libellés"
        '
        'PosteBudgétaireToolStripMenuItem
        '
        Me.PosteBudgétaireToolStripMenuItem.Name = "PosteBudgétaireToolStripMenuItem"
        Me.PosteBudgétaireToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.PosteBudgétaireToolStripMenuItem.Text = "Poste budgétaire"
        '
        'CycleDeRévisionToolStripMenuItem
        '
        Me.CycleDeRévisionToolStripMenuItem.Name = "CycleDeRévisionToolStripMenuItem"
        Me.CycleDeRévisionToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.CycleDeRévisionToolStripMenuItem.Text = "Cycle de révision"
        '
        'FusionToolStripMenuItem
        '
        Me.FusionToolStripMenuItem.Name = "FusionToolStripMenuItem"
        Me.FusionToolStripMenuItem.Size = New System.Drawing.Size(234, 24)
        Me.FusionToolStripMenuItem.Text = "Fusion..."
        '
        'TraitementToolStripMenuItem
        '
        Me.TraitementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaisieParPièceToolStripMenuItem, Me.SaisieDesOpérationsBancairesToolStripMenuItem, Me.SaisieDesÉcrituresToolStripMenuItem, Me.ToolStripSeparator9, Me.JounauxDeSaisieToolStripMenuItem, Me.ClôtureDesJournauxToolStripMenuItem, Me.ToolStripSeparator10, Me.RèglementTiersToolStripMenuItem, Me.ToolStripSeparator11, Me.RechercheDécrituresToolStripMenuItem})
        Me.TraitementToolStripMenuItem.Name = "TraitementToolStripMenuItem"
        Me.TraitementToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.TraitementToolStripMenuItem.Text = "Traitement"
        '
        'SaisieParPièceToolStripMenuItem
        '
        Me.SaisieParPièceToolStripMenuItem.Name = "SaisieParPièceToolStripMenuItem"
        Me.SaisieParPièceToolStripMenuItem.Size = New System.Drawing.Size(266, 24)
        Me.SaisieParPièceToolStripMenuItem.Text = "Saisie par pièce"
        '
        'SaisieDesOpérationsBancairesToolStripMenuItem
        '
        Me.SaisieDesOpérationsBancairesToolStripMenuItem.Name = "SaisieDesOpérationsBancairesToolStripMenuItem"
        Me.SaisieDesOpérationsBancairesToolStripMenuItem.Size = New System.Drawing.Size(266, 24)
        Me.SaisieDesOpérationsBancairesToolStripMenuItem.Text = "Saisie des opérations bancaires"
        '
        'SaisieDesÉcrituresToolStripMenuItem
        '
        Me.SaisieDesÉcrituresToolStripMenuItem.Name = "SaisieDesÉcrituresToolStripMenuItem"
        Me.SaisieDesÉcrituresToolStripMenuItem.Size = New System.Drawing.Size(266, 24)
        Me.SaisieDesÉcrituresToolStripMenuItem.Text = "Saisie des écritures..."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(263, 6)
        '
        'JounauxDeSaisieToolStripMenuItem
        '
        Me.JounauxDeSaisieToolStripMenuItem.Name = "JounauxDeSaisieToolStripMenuItem"
        Me.JounauxDeSaisieToolStripMenuItem.Size = New System.Drawing.Size(266, 24)
        Me.JounauxDeSaisieToolStripMenuItem.Text = "Jounaux de saisie"
        '
        'ClôtureDesJournauxToolStripMenuItem
        '
        Me.ClôtureDesJournauxToolStripMenuItem.Name = "ClôtureDesJournauxToolStripMenuItem"
        Me.ClôtureDesJournauxToolStripMenuItem.Size = New System.Drawing.Size(266, 24)
        Me.ClôtureDesJournauxToolStripMenuItem.Text = "Clôture des journaux"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(263, 6)
        '
        'RèglementTiersToolStripMenuItem
        '
        Me.RèglementTiersToolStripMenuItem.Name = "RèglementTiersToolStripMenuItem"
        Me.RèglementTiersToolStripMenuItem.Size = New System.Drawing.Size(266, 24)
        Me.RèglementTiersToolStripMenuItem.Text = "Règlement tiers"
        '
        'EtatToolStripMenuItem
        '
        Me.EtatToolStripMenuItem.Name = "EtatToolStripMenuItem"
        Me.EtatToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.EtatToolStripMenuItem.Text = "Etat"
        '
        'FenêtreToolStripMenuItem
        '
        Me.FenêtreToolStripMenuItem.Name = "FenêtreToolStripMenuItem"
        Me.FenêtreToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.FenêtreToolStripMenuItem.Text = "Fenêtre"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(27, 20)
        Me.ToolStripMenuItem1.Text = "?"
        '
        'GunaLinePanel1
        '
        Me.GunaLinePanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLinePanel1.LineColor = System.Drawing.Color.Indigo
        Me.GunaLinePanel1.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanel1.LineTop = 1
        Me.GunaLinePanel1.Location = New System.Drawing.Point(-1, 53)
        Me.GunaLinePanel1.Name = "GunaLinePanel1"
        Me.GunaLinePanel1.Size = New System.Drawing.Size(1201, 10)
        Me.GunaLinePanel1.TabIndex = 3
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.Color.Indigo
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ForeColor = System.Drawing.Color.White
        Me.TreeView1.Location = New System.Drawing.Point(3, 64)
        Me.TreeView1.Name = "TreeView1"
        TreeNode35.Name = "ajoutPiece"
        TreeNode35.Text = "Ajout d'une pièce"
        TreeNode36.Name = "Nœud4"
        TreeNode36.Text = "Visualisation/Modification d'une pièce"
        TreeNode37.Name = "Nœud5"
        TreeNode37.Text = "Saisie des opérations bancaires"
        TreeNode38.Name = "Nœud6"
        TreeNode38.Text = "Saisie des écritures"
        TreeNode39.Name = "Nœud7"
        TreeNode39.Text = "Recherche d'écritures"
        TreeNode40.Name = "Nœud8"
        TreeNode40.Text = "Journaux de saisie"
        TreeNode41.Name = "Nœud9"
        TreeNode41.Text = "Créer un compte général"
        TreeNode42.Name = "Nœud10"
        TreeNode42.Text = "Plan comptable"
        TreeNode43.Name = "Nœud11"
        TreeNode43.Text = "Code Journaux"
        TreeNode44.Name = "ecriture"
        TreeNode44.Text = "Saisie des écritures"
        TreeNode45.Name = "Nœud16"
        TreeNode45.Text = "Créer un client"
        TreeNode46.Name = "Nœud17"
        TreeNode46.Text = "Créer un fournisseur"
        TreeNode47.Name = "Nœud18"
        TreeNode47.Text = "Plan tiers"
        TreeNode48.Name = "Nœud19"
        TreeNode48.Text = "Interrogation tiers"
        TreeNode49.Name = "Nœud20"
        TreeNode49.Text = "Grand livre tiers"
        TreeNode50.Name = "Nœud21"
        TreeNode50.Text = "Balance tiers"
        TreeNode51.Name = "Nœud12"
        TreeNode51.Text = "Gestion et suivi des Tiers"
        TreeNode52.Name = "Nœud22"
        TreeNode52.Text = "Contrôle de caisse"
        TreeNode53.Name = "Nœud23"
        TreeNode53.Text = "Rapprochement bancaire manuel"
        TreeNode54.Name = "Nœud24"
        TreeNode54.Text = "Rapprochement bancaire auto"
        TreeNode55.Name = "Nœud25"
        TreeNode55.Text = "Synchro compta"
        TreeNode56.Name = "Nœud13"
        TreeNode56.Text = "Traitements périodiques"
        TreeNode57.Name = "Nœud26"
        TreeNode57.Text = "Brouillard"
        TreeNode58.Name = "Nœud27"
        TreeNode58.Text = "Journaux comptables"
        TreeNode59.Name = "Nœud28"
        TreeNode59.Text = "Journal général"
        TreeNode60.Name = "Nœud29"
        TreeNode60.Text = "Grand-livre des comptes"
        TreeNode61.Name = "Nœud30"
        TreeNode61.Text = "Balance des comptes"
        TreeNode62.Name = "Nœud31"
        TreeNode62.Text = "Etat déclaration de taxes"
        TreeNode63.Name = "Nœud32"
        TreeNode63.Text = "Bilan / compte de resultat"
        TreeNode64.Name = "Nœud14"
        TreeNode64.Text = "Etat comptables et fiscaux"
        TreeNode65.Name = "Nœud33"
        TreeNode65.Text = "Nouvel exercice / reports des AN"
        TreeNode66.Name = "Nœud34"
        TreeNode66.Text = "Export balance"
        TreeNode67.Name = "Nœud35"
        TreeNode67.Text = "Clôture des journaux"
        TreeNode68.Name = "Nœud15"
        TreeNode68.Text = "Fin exercice"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode44, TreeNode51, TreeNode56, TreeNode64, TreeNode68})
        Me.TreeView1.Size = New System.Drawing.Size(326, 696)
        Me.TreeView1.TabIndex = 4
        '
        'RechercheDécrituresToolStripMenuItem
        '
        Me.RechercheDécrituresToolStripMenuItem.Name = "RechercheDécrituresToolStripMenuItem"
        Me.RechercheDécrituresToolStripMenuItem.Size = New System.Drawing.Size(266, 24)
        Me.RechercheDécrituresToolStripMenuItem.Text = "Recherche d'écritures"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(263, 6)
        '
        'MiniSageCompatibiliteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 768)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.GunaLinePanel1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MiniSageCompatibiliteForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabelTitreDeLaFenetre As Guna.UI.WinForms.GunaLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StructureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TraitementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EtatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FenêtreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GunaLinePanel1 As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents NouveauToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OuvrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FermerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImporterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents AProposDeVotreSociétéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExporterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AnnulerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CouperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CollerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EffacerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SélectionnerToutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DupliauerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents InverserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalculetteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents AjouterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VoirmodifierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsulterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupprimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrécédentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SuivantToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RechercherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AtteindreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AfficherLeJournalDeTraitementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanComptabeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanAnalytiqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanReportingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanTiersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TauxDeTaxesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CodeJournauxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CodeJournauxAnalytiqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BanquesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModèlesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LibellésToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PosteBudgétaireToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CycleDeRévisionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FusionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ModeRèglementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaisieParPièceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaisieDesOpérationsBancairesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaisieDesÉcrituresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents JounauxDeSaisieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClôtureDesJournauxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents RèglementTiersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents RechercheDécrituresToolStripMenuItem As ToolStripMenuItem
End Class
