<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EtatDeChambreForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EtatDeChambreForm))
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelChmabreEncoursDeNettoyage = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelNomDuNettoyeur = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabelGestionDuTemps = New Guna.UI.WinForms.GunaLabel()
        Me.GunaTextBoxChambreANettoyer = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaPanelMotifHorsService = New Guna.UI.WinForms.GunaPanel()
        Me.GunaButton4 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonEnregistrer = New Guna.UI.WinForms.GunaButton()
        Me.GunaComboBoxMotifHS = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabelMotif = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanelTopLine = New Guna.UI.WinForms.GunaPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GunaTextBoxMessage = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaAdvenceButtonFin = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaLabelHeureControle = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelHeureFin = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelHeureDebut = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelTime = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaAdvenceButtonDébuter = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaAdvenceButtonTerminer = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaButtonEnregistrerCommentaire = New Guna.UI.WinForms.GunaButton()
        Me.GunaFermer = New Guna.UI.WinForms.GunaButton()
        Me.TimerToRefreshClock = New System.Windows.Forms.Timer(Me.components)
        Me.GunaLinePanelTop.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GunaPanelMotifHorsService.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton4)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.Panel5)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelChmabreEncoursDeNettoyage)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelNomDuNettoyeur)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(450, 33)
        Me.GunaLinePanelTop.TabIndex = 1
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = Nothing
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(417, 7)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 9
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(411, 6)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 8
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel4)
        Me.Panel5.Location = New System.Drawing.Point(110, 39)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(789, 33)
        Me.Panel5.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GunaLabel1)
        Me.Panel4.Location = New System.Drawing.Point(0, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(135, 30)
        Me.Panel4.TabIndex = 2
        '
        'GunaLabel1
        '
        Me.GunaLabel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(48, 13)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(99, 17)
        Me.GunaLabel1.TabIndex = 96
        Me.GunaLabel1.Text = "Nom Utilisateur"
        '
        'GunaLabelChmabreEncoursDeNettoyage
        '
        Me.GunaLabelChmabreEncoursDeNettoyage.AutoSize = True
        Me.GunaLabelChmabreEncoursDeNettoyage.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelChmabreEncoursDeNettoyage.Location = New System.Drawing.Point(376, 4)
        Me.GunaLabelChmabreEncoursDeNettoyage.Name = "GunaLabelChmabreEncoursDeNettoyage"
        Me.GunaLabelChmabreEncoursDeNettoyage.Size = New System.Drawing.Size(34, 21)
        Me.GunaLabelChmabreEncoursDeNettoyage.TabIndex = 1
        Me.GunaLabelChmabreEncoursDeNettoyage.Text = "201"
        Me.GunaLabelChmabreEncoursDeNettoyage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaLabelNomDuNettoyeur
        '
        Me.GunaLabelNomDuNettoyeur.AutoSize = True
        Me.GunaLabelNomDuNettoyeur.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelNomDuNettoyeur.Location = New System.Drawing.Point(53, 6)
        Me.GunaLabelNomDuNettoyeur.Name = "GunaLabelNomDuNettoyeur"
        Me.GunaLabelNomDuNettoyeur.Size = New System.Drawing.Size(61, 17)
        Me.GunaLabelNomDuNettoyeur.TabIndex = 74
        Me.GunaLabelNomDuNettoyeur.Text = "Message"
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaLinePanelTop
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Nothing
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(210, 552)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 4
        Me.GunaButton1.Size = New System.Drawing.Size(156, 40)
        Me.GunaButton1.TabIndex = 3
        Me.GunaButton1.Text = "Fermer"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton2.ForeColor = System.Drawing.Color.White
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(383, 552)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 4
        Me.GunaButton2.Size = New System.Drawing.Size(156, 40)
        Me.GunaButton2.TabIndex = 3
        Me.GunaButton2.Text = "Enregistrer"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabelGestionDuTemps
        '
        Me.GunaLabelGestionDuTemps.AutoSize = True
        Me.GunaLabelGestionDuTemps.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestionDuTemps.Location = New System.Drawing.Point(127, 178)
        Me.GunaLabelGestionDuTemps.Name = "GunaLabelGestionDuTemps"
        Me.GunaLabelGestionDuTemps.Size = New System.Drawing.Size(171, 17)
        Me.GunaLabelGestionDuTemps.TabIndex = 5
        Me.GunaLabelGestionDuTemps.Text = "Gestion du temps de Travail"
        '
        'GunaTextBoxChambreANettoyer
        '
        Me.GunaTextBoxChambreANettoyer.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GunaTextBoxChambreANettoyer.BaseColor = System.Drawing.Color.Silver
        Me.GunaTextBoxChambreANettoyer.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxChambreANettoyer.BorderSize = 1
        Me.GunaTextBoxChambreANettoyer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxChambreANettoyer.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxChambreANettoyer.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxChambreANettoyer.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxChambreANettoyer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxChambreANettoyer.ForeColor = System.Drawing.Color.Black
        Me.GunaTextBoxChambreANettoyer.Location = New System.Drawing.Point(254, 61)
        Me.GunaTextBoxChambreANettoyer.Multiline = True
        Me.GunaTextBoxChambreANettoyer.Name = "GunaTextBoxChambreANettoyer"
        Me.GunaTextBoxChambreANettoyer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxChambreANettoyer.SelectedText = ""
        Me.GunaTextBoxChambreANettoyer.Size = New System.Drawing.Size(164, 28)
        Me.GunaTextBoxChambreANettoyer.TabIndex = 8
        Me.GunaTextBoxChambreANettoyer.Text = "Code Chambre à nettoyer"
        Me.GunaTextBoxChambreANettoyer.Visible = False
        '
        'GunaPanelMotifHorsService
        '
        Me.GunaPanelMotifHorsService.Controls.Add(Me.GunaButton4)
        Me.GunaPanelMotifHorsService.Controls.Add(Me.GunaButtonEnregistrer)
        Me.GunaPanelMotifHorsService.Controls.Add(Me.GunaComboBoxMotifHS)
        Me.GunaPanelMotifHorsService.Controls.Add(Me.GunaLabelMotif)
        Me.GunaPanelMotifHorsService.Location = New System.Drawing.Point(12, 39)
        Me.GunaPanelMotifHorsService.Name = "GunaPanelMotifHorsService"
        Me.GunaPanelMotifHorsService.Size = New System.Drawing.Size(426, 267)
        Me.GunaPanelMotifHorsService.TabIndex = 10
        Me.GunaPanelMotifHorsService.Visible = False
        '
        'GunaButton4
        '
        Me.GunaButton4.AnimationHoverSpeed = 0.07!
        Me.GunaButton4.AnimationSpeed = 0.03!
        Me.GunaButton4.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton4.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton4.BorderColor = System.Drawing.Color.Black
        Me.GunaButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton4.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton4.ForeColor = System.Drawing.Color.White
        Me.GunaButton4.Image = Nothing
        Me.GunaButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton4.Location = New System.Drawing.Point(18, 104)
        Me.GunaButton4.Name = "GunaButton4"
        Me.GunaButton4.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton4.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton4.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton4.OnHoverImage = Nothing
        Me.GunaButton4.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton4.Radius = 4
        Me.GunaButton4.Size = New System.Drawing.Size(85, 37)
        Me.GunaButton4.TabIndex = 72
        Me.GunaButton4.Text = "Annuler"
        Me.GunaButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButtonEnregistrer.Location = New System.Drawing.Point(313, 104)
        Me.GunaButtonEnregistrer.Name = "GunaButtonEnregistrer"
        Me.GunaButtonEnregistrer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnregistrer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrer.OnHoverImage = Nothing
        Me.GunaButtonEnregistrer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrer.Radius = 4
        Me.GunaButtonEnregistrer.Size = New System.Drawing.Size(93, 37)
        Me.GunaButtonEnregistrer.TabIndex = 72
        Me.GunaButtonEnregistrer.Text = "Enregistrer"
        Me.GunaButtonEnregistrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaComboBoxMotifHS
        '
        Me.GunaComboBoxMotifHS.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxMotifHS.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxMotifHS.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxMotifHS.BorderSize = 1
        Me.GunaComboBoxMotifHS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxMotifHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxMotifHS.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxMotifHS.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxMotifHS.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxMotifHS.FormattingEnabled = True
        Me.GunaComboBoxMotifHS.ItemHeight = 25
        Me.GunaComboBoxMotifHS.Items.AddRange(New Object() {"Plomberie", "Electricité", "Peinture"})
        Me.GunaComboBoxMotifHS.Location = New System.Drawing.Point(18, 35)
        Me.GunaComboBoxMotifHS.Name = "GunaComboBoxMotifHS"
        Me.GunaComboBoxMotifHS.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxMotifHS.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxMotifHS.Radius = 5
        Me.GunaComboBoxMotifHS.Size = New System.Drawing.Size(388, 31)
        Me.GunaComboBoxMotifHS.TabIndex = 71
        '
        'GunaLabelMotif
        '
        Me.GunaLabelMotif.AutoSize = True
        Me.GunaLabelMotif.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelMotif.Location = New System.Drawing.Point(17, 8)
        Me.GunaLabelMotif.Name = "GunaLabelMotif"
        Me.GunaLabelMotif.Size = New System.Drawing.Size(51, 20)
        Me.GunaLabelMotif.TabIndex = 70
        Me.GunaLabelMotif.Text = "Motifs"
        '
        'GunaPanelTopLine
        '
        Me.GunaPanelTopLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanelTopLine.Location = New System.Drawing.Point(0, 195)
        Me.GunaPanelTopLine.Name = "GunaPanelTopLine"
        Me.GunaPanelTopLine.Size = New System.Drawing.Size(450, 10)
        Me.GunaPanelTopLine.TabIndex = 7
        Me.GunaPanelTopLine.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.GunaTextBoxMessage)
        Me.Panel1.Controls.Add(Me.GunaPanel1)
        Me.Panel1.Controls.Add(Me.GunaAdvenceButtonFin)
        Me.Panel1.Controls.Add(Me.GunaLabelHeureControle)
        Me.Panel1.Controls.Add(Me.GunaLabelHeureFin)
        Me.Panel1.Controls.Add(Me.GunaLabelHeureDebut)
        Me.Panel1.Controls.Add(Me.GunaLabelTime)
        Me.Panel1.Controls.Add(Me.GunaLabel5)
        Me.Panel1.Controls.Add(Me.GunaAdvenceButtonDébuter)
        Me.Panel1.Controls.Add(Me.GunaAdvenceButtonTerminer)
        Me.Panel1.Controls.Add(Me.GunaButtonEnregistrerCommentaire)
        Me.Panel1.Controls.Add(Me.GunaFermer)
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 278)
        Me.Panel1.TabIndex = 11
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(265, 144)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(41, 28)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 82
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(119, 144)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 82
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'GunaTextBoxMessage
        '
        Me.GunaTextBoxMessage.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMessage.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMessage.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMessage.BorderSize = 1
        Me.GunaTextBoxMessage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMessage.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMessage.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMessage.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxMessage.Location = New System.Drawing.Point(30, 26)
        Me.GunaTextBoxMessage.Multiline = True
        Me.GunaTextBoxMessage.Name = "GunaTextBoxMessage"
        Me.GunaTextBoxMessage.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMessage.Radius = 5
        Me.GunaTextBoxMessage.SelectedText = ""
        Me.GunaTextBoxMessage.Size = New System.Drawing.Size(388, 94)
        Me.GunaTextBoxMessage.TabIndex = 78
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 267)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(450, 10)
        Me.GunaPanel1.TabIndex = 77
        '
        'GunaAdvenceButtonFin
        '
        Me.GunaAdvenceButtonFin.AnimationHoverSpeed = 0.07!
        Me.GunaAdvenceButtonFin.AnimationSpeed = 0.03!
        Me.GunaAdvenceButtonFin.BackColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButtonFin.BaseColor = System.Drawing.Color.Red
        Me.GunaAdvenceButtonFin.BorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonFin.CheckedBaseColor = System.Drawing.Color.Gray
        Me.GunaAdvenceButtonFin.CheckedBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonFin.CheckedForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonFin.CheckedImage = CType(resources.GetObject("GunaAdvenceButtonFin.CheckedImage"), System.Drawing.Image)
        Me.GunaAdvenceButtonFin.CheckedLineColor = System.Drawing.Color.DimGray
        Me.GunaAdvenceButtonFin.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaAdvenceButtonFin.FocusedColor = System.Drawing.Color.Empty
        Me.GunaAdvenceButtonFin.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaAdvenceButtonFin.ForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonFin.Image = CType(resources.GetObject("GunaAdvenceButtonFin.Image"), System.Drawing.Image)
        Me.GunaAdvenceButtonFin.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaAdvenceButtonFin.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaAdvenceButtonFin.Location = New System.Drawing.Point(171, 144)
        Me.GunaAdvenceButtonFin.Name = "GunaAdvenceButtonFin"
        Me.GunaAdvenceButtonFin.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaAdvenceButtonFin.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonFin.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonFin.OnHoverImage = Nothing
        Me.GunaAdvenceButtonFin.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaAdvenceButtonFin.OnPressedColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonFin.Radius = 5
        Me.GunaAdvenceButtonFin.Size = New System.Drawing.Size(83, 28)
        Me.GunaAdvenceButtonFin.TabIndex = 79
        Me.GunaAdvenceButtonFin.Text = "Fin"
        Me.GunaAdvenceButtonFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaLabelHeureControle
        '
        Me.GunaLabelHeureControle.AutoSize = True
        Me.GunaLabelHeureControle.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelHeureControle.Location = New System.Drawing.Point(323, 175)
        Me.GunaLabelHeureControle.Name = "GunaLabelHeureControle"
        Me.GunaLabelHeureControle.Size = New System.Drawing.Size(68, 20)
        Me.GunaLabelHeureControle.TabIndex = 74
        Me.GunaLabelHeureControle.Text = "Message"
        Me.GunaLabelHeureControle.Visible = False
        '
        'GunaLabelHeureFin
        '
        Me.GunaLabelHeureFin.AutoSize = True
        Me.GunaLabelHeureFin.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelHeureFin.Location = New System.Drawing.Point(172, 176)
        Me.GunaLabelHeureFin.Name = "GunaLabelHeureFin"
        Me.GunaLabelHeureFin.Size = New System.Drawing.Size(68, 20)
        Me.GunaLabelHeureFin.TabIndex = 74
        Me.GunaLabelHeureFin.Text = "Message"
        Me.GunaLabelHeureFin.Visible = False
        '
        'GunaLabelHeureDebut
        '
        Me.GunaLabelHeureDebut.AutoSize = True
        Me.GunaLabelHeureDebut.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelHeureDebut.Location = New System.Drawing.Point(26, 176)
        Me.GunaLabelHeureDebut.Name = "GunaLabelHeureDebut"
        Me.GunaLabelHeureDebut.Size = New System.Drawing.Size(68, 20)
        Me.GunaLabelHeureDebut.TabIndex = 74
        Me.GunaLabelHeureDebut.Text = "Message"
        Me.GunaLabelHeureDebut.Visible = False
        '
        'GunaLabelTime
        '
        Me.GunaLabelTime.AutoSize = True
        Me.GunaLabelTime.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelTime.Location = New System.Drawing.Point(192, 237)
        Me.GunaLabelTime.Name = "GunaLabelTime"
        Me.GunaLabelTime.Size = New System.Drawing.Size(68, 20)
        Me.GunaLabelTime.TabIndex = 74
        Me.GunaLabelTime.Text = "Message"
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(27, 2)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(61, 17)
        Me.GunaLabel5.TabIndex = 74
        Me.GunaLabel5.Text = "Message"
        '
        'GunaAdvenceButtonDébuter
        '
        Me.GunaAdvenceButtonDébuter.AnimationHoverSpeed = 0.07!
        Me.GunaAdvenceButtonDébuter.AnimationSpeed = 0.03!
        Me.GunaAdvenceButtonDébuter.BackColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButtonDébuter.BaseColor = System.Drawing.Color.Orange
        Me.GunaAdvenceButtonDébuter.BorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonDébuter.CheckedBaseColor = System.Drawing.Color.Gray
        Me.GunaAdvenceButtonDébuter.CheckedBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonDébuter.CheckedForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonDébuter.CheckedImage = CType(resources.GetObject("GunaAdvenceButtonDébuter.CheckedImage"), System.Drawing.Image)
        Me.GunaAdvenceButtonDébuter.CheckedLineColor = System.Drawing.Color.DimGray
        Me.GunaAdvenceButtonDébuter.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaAdvenceButtonDébuter.FocusedColor = System.Drawing.Color.Empty
        Me.GunaAdvenceButtonDébuter.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaAdvenceButtonDébuter.ForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonDébuter.Image = CType(resources.GetObject("GunaAdvenceButtonDébuter.Image"), System.Drawing.Image)
        Me.GunaAdvenceButtonDébuter.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaAdvenceButtonDébuter.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaAdvenceButtonDébuter.Location = New System.Drawing.Point(25, 144)
        Me.GunaAdvenceButtonDébuter.Name = "GunaAdvenceButtonDébuter"
        Me.GunaAdvenceButtonDébuter.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaAdvenceButtonDébuter.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonDébuter.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonDébuter.OnHoverImage = Nothing
        Me.GunaAdvenceButtonDébuter.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaAdvenceButtonDébuter.OnPressedColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonDébuter.Radius = 5
        Me.GunaAdvenceButtonDébuter.Size = New System.Drawing.Size(83, 28)
        Me.GunaAdvenceButtonDébuter.TabIndex = 80
        Me.GunaAdvenceButtonDébuter.Text = "Début"
        Me.GunaAdvenceButtonDébuter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaAdvenceButtonTerminer
        '
        Me.GunaAdvenceButtonTerminer.AnimationHoverSpeed = 0.07!
        Me.GunaAdvenceButtonTerminer.AnimationSpeed = 0.03!
        Me.GunaAdvenceButtonTerminer.BackColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButtonTerminer.BaseColor = System.Drawing.Color.Green
        Me.GunaAdvenceButtonTerminer.BorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonTerminer.CheckedBaseColor = System.Drawing.Color.Gray
        Me.GunaAdvenceButtonTerminer.CheckedBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonTerminer.CheckedForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonTerminer.CheckedImage = CType(resources.GetObject("GunaAdvenceButtonTerminer.CheckedImage"), System.Drawing.Image)
        Me.GunaAdvenceButtonTerminer.CheckedLineColor = System.Drawing.Color.DimGray
        Me.GunaAdvenceButtonTerminer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaAdvenceButtonTerminer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaAdvenceButtonTerminer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaAdvenceButtonTerminer.ForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonTerminer.Image = CType(resources.GetObject("GunaAdvenceButtonTerminer.Image"), System.Drawing.Image)
        Me.GunaAdvenceButtonTerminer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaAdvenceButtonTerminer.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaAdvenceButtonTerminer.Location = New System.Drawing.Point(317, 144)
        Me.GunaAdvenceButtonTerminer.Name = "GunaAdvenceButtonTerminer"
        Me.GunaAdvenceButtonTerminer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaAdvenceButtonTerminer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonTerminer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButtonTerminer.OnHoverImage = Nothing
        Me.GunaAdvenceButtonTerminer.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaAdvenceButtonTerminer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaAdvenceButtonTerminer.Radius = 5
        Me.GunaAdvenceButtonTerminer.Size = New System.Drawing.Size(112, 28)
        Me.GunaAdvenceButtonTerminer.TabIndex = 81
        Me.GunaAdvenceButtonTerminer.Text = "Contrôler"
        Me.GunaAdvenceButtonTerminer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GunaAdvenceButtonTerminer.Visible = False
        '
        'GunaButtonEnregistrerCommentaire
        '
        Me.GunaButtonEnregistrerCommentaire.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEnregistrerCommentaire.AnimationSpeed = 0.03!
        Me.GunaButtonEnregistrerCommentaire.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEnregistrerCommentaire.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrerCommentaire.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerCommentaire.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEnregistrerCommentaire.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEnregistrerCommentaire.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEnregistrerCommentaire.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerCommentaire.Image = Nothing
        Me.GunaButtonEnregistrerCommentaire.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnregistrerCommentaire.Location = New System.Drawing.Point(323, 227)
        Me.GunaButtonEnregistrerCommentaire.Name = "GunaButtonEnregistrerCommentaire"
        Me.GunaButtonEnregistrerCommentaire.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnregistrerCommentaire.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerCommentaire.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnregistrerCommentaire.OnHoverImage = Nothing
        Me.GunaButtonEnregistrerCommentaire.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnregistrerCommentaire.Radius = 4
        Me.GunaButtonEnregistrerCommentaire.Size = New System.Drawing.Size(112, 34)
        Me.GunaButtonEnregistrerCommentaire.TabIndex = 75
        Me.GunaButtonEnregistrerCommentaire.Text = "Enregistrer"
        Me.GunaButtonEnregistrerCommentaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaFermer
        '
        Me.GunaFermer.AnimationHoverSpeed = 0.07!
        Me.GunaFermer.AnimationSpeed = 0.03!
        Me.GunaFermer.BackColor = System.Drawing.Color.Transparent
        Me.GunaFermer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaFermer.BorderColor = System.Drawing.Color.Black
        Me.GunaFermer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaFermer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaFermer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaFermer.ForeColor = System.Drawing.Color.White
        Me.GunaFermer.Image = Nothing
        Me.GunaFermer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaFermer.Location = New System.Drawing.Point(16, 228)
        Me.GunaFermer.Name = "GunaFermer"
        Me.GunaFermer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaFermer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaFermer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaFermer.OnHoverImage = Nothing
        Me.GunaFermer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaFermer.Radius = 4
        Me.GunaFermer.Size = New System.Drawing.Size(112, 34)
        Me.GunaFermer.TabIndex = 76
        Me.GunaFermer.Text = "Fermer"
        Me.GunaFermer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TimerToRefreshClock
        '
        Me.TimerToRefreshClock.Enabled = True
        '
        'EtatDeChambreForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 308)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GunaPanelTopLine)
        Me.Controls.Add(Me.GunaTextBoxChambreANettoyer)
        Me.Controls.Add(Me.GunaLabelGestionDuTemps)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.Controls.Add(Me.GunaPanelMotifHorsService)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EtatDeChambreForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserForm"
        Me.TopMost = True
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GunaPanelMotifHorsService.ResumeLayout(False)
        Me.GunaPanelMotifHorsService.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelGestionDuTemps As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelChmabreEncoursDeNettoyage As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTextBoxChambreANettoyer As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaPanelMotifHorsService As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaComboBoxMotifHS As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabelMotif As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnregistrer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPanelTopLine As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaButton4 As Guna.UI.WinForms.GunaButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GunaTextBoxMessage As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaAdvenceButtonFin As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaAdvenceButtonDébuter As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents GunaAdvenceButtonTerminer As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents GunaButtonEnregistrerCommentaire As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaFermer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabelTime As Guna.UI.WinForms.GunaLabel
    Friend WithEvents TimerToRefreshClock As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GunaLabelHeureFin As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelHeureDebut As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelHeureControle As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelNomDuNettoyeur As Guna.UI.WinForms.GunaLabel
End Class
