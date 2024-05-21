<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NotificationsForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaLabelNomDuNettoyeur = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanelTopLine = New Guna.UI.WinForms.GunaPanel()
        Me.TimerToRefreshClock = New System.Windows.Forms.Timer(Me.components)
        Me.GunaFermer = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton3 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton4 = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanelEcrire = New Guna.UI.WinForms.GunaPanel()
        Me.GunaComboBoxProfilUtilisateur = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaTextBoxObjet = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxMessage = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonEnvoyer = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanelLire = New Guna.UI.WinForms.GunaPanel()
        Me.GunaDataGridViewNotification = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaButtonMessageLus = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonMessageNonLus = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton5 = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxFromWhichWindow = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLinePanelTop.SuspendLayout()
        Me.GunaPanelEcrire.SuspendLayout()
        Me.GunaPanelLire.SuspendLayout()
        CType(Me.GunaDataGridViewNotification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaTextBoxFromWhichWindow)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelNomDuNettoyeur)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(700, 33)
        Me.GunaLinePanelTop.TabIndex = 1
        '
        'GunaLabelNomDuNettoyeur
        '
        Me.GunaLabelNomDuNettoyeur.AutoSize = True
        Me.GunaLabelNomDuNettoyeur.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelNomDuNettoyeur.Location = New System.Drawing.Point(247, 9)
        Me.GunaLabelNomDuNettoyeur.Name = "GunaLabelNomDuNettoyeur"
        Me.GunaLabelNomDuNettoyeur.Size = New System.Drawing.Size(140, 17)
        Me.GunaLabelNomDuNettoyeur.TabIndex = 74
        Me.GunaLabelNomDuNettoyeur.Text = "BOITE DE RECEPTION"
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
        'GunaPanelTopLine
        '
        Me.GunaPanelTopLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanelTopLine.Location = New System.Drawing.Point(0, 439)
        Me.GunaPanelTopLine.Name = "GunaPanelTopLine"
        Me.GunaPanelTopLine.Size = New System.Drawing.Size(621, 10)
        Me.GunaPanelTopLine.TabIndex = 7
        Me.GunaPanelTopLine.Visible = False
        '
        'TimerToRefreshClock
        '
        Me.TimerToRefreshClock.Enabled = True
        Me.TimerToRefreshClock.Interval = 60000
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
        Me.GunaFermer.Location = New System.Drawing.Point(12, 410)
        Me.GunaFermer.Name = "GunaFermer"
        Me.GunaFermer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaFermer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaFermer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaFermer.OnHoverImage = Nothing
        Me.GunaFermer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaFermer.Radius = 4
        Me.GunaFermer.Size = New System.Drawing.Size(112, 24)
        Me.GunaFermer.TabIndex = 78
        Me.GunaFermer.Text = "Fermer"
        Me.GunaFermer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButton3
        '
        Me.GunaButton3.AnimationHoverSpeed = 0.07!
        Me.GunaButton3.AnimationSpeed = 0.03!
        Me.GunaButton3.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton3.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton3.BorderColor = System.Drawing.Color.Black
        Me.GunaButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton3.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton3.ForeColor = System.Drawing.Color.White
        Me.GunaButton3.Image = Nothing
        Me.GunaButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton3.Location = New System.Drawing.Point(21, 45)
        Me.GunaButton3.Name = "GunaButton3"
        Me.GunaButton3.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton3.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton3.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton3.OnHoverImage = Nothing
        Me.GunaButton3.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton3.Radius = 4
        Me.GunaButton3.Size = New System.Drawing.Size(146, 23)
        Me.GunaButton3.TabIndex = 77
        Me.GunaButton3.Text = "ECRIRE"
        Me.GunaButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.GunaButton4.Location = New System.Drawing.Point(21, 78)
        Me.GunaButton4.Name = "GunaButton4"
        Me.GunaButton4.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton4.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton4.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton4.OnHoverImage = Nothing
        Me.GunaButton4.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton4.Radius = 4
        Me.GunaButton4.Size = New System.Drawing.Size(146, 23)
        Me.GunaButton4.TabIndex = 77
        Me.GunaButton4.Text = "MESSAGES RECUS"
        Me.GunaButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanelEcrire
        '
        Me.GunaPanelEcrire.Controls.Add(Me.GunaComboBoxProfilUtilisateur)
        Me.GunaPanelEcrire.Controls.Add(Me.GunaTextBoxObjet)
        Me.GunaPanelEcrire.Controls.Add(Me.GunaTextBoxMessage)
        Me.GunaPanelEcrire.Controls.Add(Me.GunaLabel4)
        Me.GunaPanelEcrire.Controls.Add(Me.GunaLabel2)
        Me.GunaPanelEcrire.Controls.Add(Me.GunaLabel3)
        Me.GunaPanelEcrire.Controls.Add(Me.GunaButtonEnvoyer)
        Me.GunaPanelEcrire.Location = New System.Drawing.Point(209, 47)
        Me.GunaPanelEcrire.Name = "GunaPanelEcrire"
        Me.GunaPanelEcrire.Size = New System.Drawing.Size(465, 390)
        Me.GunaPanelEcrire.TabIndex = 79
        Me.GunaPanelEcrire.Visible = False
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
        Me.GunaComboBoxProfilUtilisateur.Location = New System.Drawing.Point(84, 12)
        Me.GunaComboBoxProfilUtilisateur.Name = "GunaComboBoxProfilUtilisateur"
        Me.GunaComboBoxProfilUtilisateur.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxProfilUtilisateur.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxProfilUtilisateur.Radius = 4
        Me.GunaComboBoxProfilUtilisateur.Size = New System.Drawing.Size(350, 29)
        Me.GunaComboBoxProfilUtilisateur.TabIndex = 85
        '
        'GunaTextBoxObjet
        '
        Me.GunaTextBoxObjet.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxObjet.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxObjet.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxObjet.BorderSize = 1
        Me.GunaTextBoxObjet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxObjet.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxObjet.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxObjet.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxObjet.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxObjet.Location = New System.Drawing.Point(84, 57)
        Me.GunaTextBoxObjet.Name = "GunaTextBoxObjet"
        Me.GunaTextBoxObjet.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxObjet.Radius = 5
        Me.GunaTextBoxObjet.SelectedText = ""
        Me.GunaTextBoxObjet.Size = New System.Drawing.Size(350, 31)
        Me.GunaTextBoxObjet.TabIndex = 84
        '
        'GunaTextBoxMessage
        '
        Me.GunaTextBoxMessage.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxMessage.BaseColor = System.Drawing.Color.LightBlue
        Me.GunaTextBoxMessage.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxMessage.BorderSize = 1
        Me.GunaTextBoxMessage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxMessage.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxMessage.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxMessage.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxMessage.Location = New System.Drawing.Point(16, 126)
        Me.GunaTextBoxMessage.Multiline = True
        Me.GunaTextBoxMessage.Name = "GunaTextBoxMessage"
        Me.GunaTextBoxMessage.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxMessage.Radius = 5
        Me.GunaTextBoxMessage.SelectedText = ""
        Me.GunaTextBoxMessage.Size = New System.Drawing.Size(438, 221)
        Me.GunaTextBoxMessage.TabIndex = 84
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(15, 16)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(56, 17)
        Me.GunaLabel4.TabIndex = 82
        Me.GunaLabel4.Text = "Service:"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(15, 104)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(65, 17)
        Me.GunaLabel2.TabIndex = 81
        Me.GunaLabel2.Text = "Message:"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(15, 64)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(50, 17)
        Me.GunaLabel3.TabIndex = 82
        Me.GunaLabel3.Text = "Objet: "
        '
        'GunaButtonEnvoyer
        '
        Me.GunaButtonEnvoyer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonEnvoyer.AnimationSpeed = 0.03!
        Me.GunaButtonEnvoyer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonEnvoyer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnvoyer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnvoyer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonEnvoyer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonEnvoyer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonEnvoyer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonEnvoyer.Image = Nothing
        Me.GunaButtonEnvoyer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonEnvoyer.Location = New System.Drawing.Point(309, 356)
        Me.GunaButtonEnvoyer.Name = "GunaButtonEnvoyer"
        Me.GunaButtonEnvoyer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonEnvoyer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnvoyer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnvoyer.OnHoverImage = Nothing
        Me.GunaButtonEnvoyer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnvoyer.Radius = 4
        Me.GunaButtonEnvoyer.Size = New System.Drawing.Size(112, 25)
        Me.GunaButtonEnvoyer.TabIndex = 77
        Me.GunaButtonEnvoyer.Text = "Envoyer"
        Me.GunaButtonEnvoyer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanelLire
        '
        Me.GunaPanelLire.Controls.Add(Me.GunaDataGridViewNotification)
        Me.GunaPanelLire.Location = New System.Drawing.Point(208, 45)
        Me.GunaPanelLire.Name = "GunaPanelLire"
        Me.GunaPanelLire.Size = New System.Drawing.Size(465, 349)
        Me.GunaPanelLire.TabIndex = 85
        '
        'GunaDataGridViewNotification
        '
        Me.GunaDataGridViewNotification.AllowUserToAddRows = False
        Me.GunaDataGridViewNotification.AllowUserToDeleteRows = False
        Me.GunaDataGridViewNotification.AllowUserToResizeColumns = False
        Me.GunaDataGridViewNotification.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GunaDataGridViewNotification.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GunaDataGridViewNotification.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridViewNotification.BackgroundColor = System.Drawing.Color.White
        Me.GunaDataGridViewNotification.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridViewNotification.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewNotification.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridViewNotification.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.GunaDataGridViewNotification.ColumnHeadersHeight = 25
        Me.GunaDataGridViewNotification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(216, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(125, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridViewNotification.DefaultCellStyle = DataGridViewCellStyle6
        Me.GunaDataGridViewNotification.EnableHeadersVisualStyles = False
        Me.GunaDataGridViewNotification.GridColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.GunaDataGridViewNotification.Location = New System.Drawing.Point(6, 11)
        Me.GunaDataGridViewNotification.Name = "GunaDataGridViewNotification"
        Me.GunaDataGridViewNotification.ReadOnly = True
        Me.GunaDataGridViewNotification.RowHeadersVisible = False
        Me.GunaDataGridViewNotification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridViewNotification.Size = New System.Drawing.Size(453, 335)
        Me.GunaDataGridViewNotification.TabIndex = 0
        Me.GunaDataGridViewNotification.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Alizarin
        Me.GunaDataGridViewNotification.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GunaDataGridViewNotification.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridViewNotification.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewNotification.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewNotification.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridViewNotification.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridViewNotification.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.GunaDataGridViewNotification.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GunaDataGridViewNotification.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridViewNotification.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewNotification.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridViewNotification.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GunaDataGridViewNotification.ThemeStyle.HeaderStyle.Height = 25
        Me.GunaDataGridViewNotification.ThemeStyle.ReadOnly = True
        Me.GunaDataGridViewNotification.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.GunaDataGridViewNotification.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridViewNotification.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaDataGridViewNotification.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaDataGridViewNotification.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridViewNotification.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.GunaDataGridViewNotification.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'GunaButtonMessageLus
        '
        Me.GunaButtonMessageLus.AnimationHoverSpeed = 0.07!
        Me.GunaButtonMessageLus.AnimationSpeed = 0.03!
        Me.GunaButtonMessageLus.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonMessageLus.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonMessageLus.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonMessageLus.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonMessageLus.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonMessageLus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonMessageLus.ForeColor = System.Drawing.Color.White
        Me.GunaButtonMessageLus.Image = Nothing
        Me.GunaButtonMessageLus.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonMessageLus.Location = New System.Drawing.Point(21, 145)
        Me.GunaButtonMessageLus.Name = "GunaButtonMessageLus"
        Me.GunaButtonMessageLus.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonMessageLus.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonMessageLus.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonMessageLus.OnHoverImage = Nothing
        Me.GunaButtonMessageLus.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonMessageLus.Radius = 4
        Me.GunaButtonMessageLus.Size = New System.Drawing.Size(146, 23)
        Me.GunaButtonMessageLus.TabIndex = 77
        Me.GunaButtonMessageLus.Text = "MESSAGES LUS"
        Me.GunaButtonMessageLus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonMessageNonLus
        '
        Me.GunaButtonMessageNonLus.AnimationHoverSpeed = 0.07!
        Me.GunaButtonMessageNonLus.AnimationSpeed = 0.03!
        Me.GunaButtonMessageNonLus.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonMessageNonLus.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonMessageNonLus.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonMessageNonLus.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonMessageNonLus.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonMessageNonLus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonMessageNonLus.ForeColor = System.Drawing.Color.White
        Me.GunaButtonMessageNonLus.Image = Nothing
        Me.GunaButtonMessageNonLus.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonMessageNonLus.Location = New System.Drawing.Point(21, 184)
        Me.GunaButtonMessageNonLus.Name = "GunaButtonMessageNonLus"
        Me.GunaButtonMessageNonLus.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonMessageNonLus.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonMessageNonLus.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonMessageNonLus.OnHoverImage = Nothing
        Me.GunaButtonMessageNonLus.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonMessageNonLus.Radius = 4
        Me.GunaButtonMessageNonLus.Size = New System.Drawing.Size(146, 23)
        Me.GunaButtonMessageNonLus.TabIndex = 77
        Me.GunaButtonMessageNonLus.Text = "MESSAGES NON LUS"
        Me.GunaButtonMessageNonLus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButton5
        '
        Me.GunaButton5.AnimationHoverSpeed = 0.07!
        Me.GunaButton5.AnimationSpeed = 0.03!
        Me.GunaButton5.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton5.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton5.BorderColor = System.Drawing.Color.Black
        Me.GunaButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton5.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton5.ForeColor = System.Drawing.Color.White
        Me.GunaButton5.Image = Nothing
        Me.GunaButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton5.Location = New System.Drawing.Point(21, 227)
        Me.GunaButton5.Name = "GunaButton5"
        Me.GunaButton5.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButton5.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton5.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton5.OnHoverImage = Nothing
        Me.GunaButton5.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton5.Radius = 4
        Me.GunaButton5.Size = New System.Drawing.Size(146, 23)
        Me.GunaButton5.TabIndex = 77
        Me.GunaButton5.Text = "BOITE D'ENVOI"
        Me.GunaButton5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxFromWhichWindow
        '
        Me.GunaTextBoxFromWhichWindow.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxFromWhichWindow.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxFromWhichWindow.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxFromWhichWindow.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxFromWhichWindow.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxFromWhichWindow.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxFromWhichWindow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxFromWhichWindow.ForeColor = System.Drawing.Color.Black
        Me.GunaTextBoxFromWhichWindow.Location = New System.Drawing.Point(590, 3)
        Me.GunaTextBoxFromWhichWindow.Name = "GunaTextBoxFromWhichWindow"
        Me.GunaTextBoxFromWhichWindow.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxFromWhichWindow.SelectedText = ""
        Me.GunaTextBoxFromWhichWindow.Size = New System.Drawing.Size(98, 26)
        Me.GunaTextBoxFromWhichWindow.TabIndex = 75
        Me.GunaTextBoxFromWhichWindow.Visible = False
        '
        'NotificationsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 450)
        Me.Controls.Add(Me.GunaPanelLire)
        Me.Controls.Add(Me.GunaPanelEcrire)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.Controls.Add(Me.GunaButton5)
        Me.Controls.Add(Me.GunaButtonMessageNonLus)
        Me.Controls.Add(Me.GunaButtonMessageLus)
        Me.Controls.Add(Me.GunaButton4)
        Me.Controls.Add(Me.GunaButton3)
        Me.Controls.Add(Me.GunaFermer)
        Me.Controls.Add(Me.GunaPanelTopLine)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NotificationsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserForm"
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.GunaPanelEcrire.ResumeLayout(False)
        Me.GunaPanelEcrire.PerformLayout()
        Me.GunaPanelLire.ResumeLayout(False)
        CType(Me.GunaDataGridViewNotification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPanelTopLine As Guna.UI.WinForms.GunaPanel
    Friend WithEvents TimerToRefreshClock As Timer
    Friend WithEvents GunaLabelNomDuNettoyeur As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaFermer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPanelEcrire As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxMessage As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonEnvoyer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton4 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton3 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaPanelLire As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaTextBoxObjet As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDataGridViewNotification As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaComboBoxProfilUtilisateur As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaButtonMessageLus As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonMessageNonLus As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton5 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxFromWhichWindow As Guna.UI.WinForms.GunaTextBox
End Class
