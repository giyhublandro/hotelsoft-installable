<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AccueilForm
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
        Dim Animation1 As Guna.UI.Animation.Animation = New Guna.UI.Animation.Animation()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccueilForm))
        Me.PanelAccueil = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBoxRights = New System.Windows.Forms.TextBox()
        Me.GunaComboBoxLangue = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabelLangue = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonSeConnecter = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.PanelConnexion = New System.Windows.Forms.Panel()
        Me.GunaCheckBoxVersion = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaLineTextBoxUsername = New Guna.UI.WinForms.GunaLineTextBox()
        Me.GunaComboBoxVersion = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaButtonAnnulerAccueil = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabelVersion = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLineTextBoxMotDePasse = New Guna.UI.WinForms.GunaLineTextBox()
        Me.GunaLabelPwd = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelUser = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonOuvrirSession = New Guna.UI.WinForms.GunaButton()
        Me.GunaTransitionAnimation = New Guna.UI.WinForms.GunaTransition(Me.components)
        Me.GunaPanelFormTop = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabelNomUtilisateur = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelUsername = New Guna.UI.WinForms.GunaLabel()
        Me.GunaGroupBoxHotel = New Guna.UI.WinForms.GunaGroupBox()
        Me.GunaLabelTitle = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabelHotelName = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.GunaPictureBoxHotel = New Guna.UI.WinForms.GunaPictureBox()
        Me.GunaPictureBoxCustom = New Guna.UI.WinForms.GunaPictureBox()
        Me.GunaPictureBoxRestaurant = New Guna.UI.WinForms.GunaPictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.PanelAccueil.SuspendLayout()
        Me.PanelConnexion.SuspendLayout()
        Me.GunaPanelFormTop.SuspendLayout()
        Me.GunaGroupBoxHotel.SuspendLayout()
        CType(Me.GunaPictureBoxHotel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaPictureBoxCustom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaPictureBoxRestaurant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelAccueil
        '
        Me.PanelAccueil.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelAccueil.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.PanelAccueil.Controls.Add(Me.TextBox1)
        Me.PanelAccueil.Controls.Add(Me.TextBox3)
        Me.PanelAccueil.Controls.Add(Me.TextBox2)
        Me.PanelAccueil.Controls.Add(Me.TextBoxRights)
        Me.PanelAccueil.Controls.Add(Me.GunaComboBoxLangue)
        Me.PanelAccueil.Controls.Add(Me.GunaLabelLangue)
        Me.PanelAccueil.Controls.Add(Me.GunaButtonSeConnecter)
        Me.PanelAccueil.Controls.Add(Me.GunaLabel4)
        Me.PanelAccueil.Controls.Add(Me.GunaLabel5)
        Me.PanelAccueil.Controls.Add(Me.GunaLabel2)
        Me.GunaTransitionAnimation.SetDecoration(Me.PanelAccueil, Guna.UI.Animation.DecorationType.None)
        Me.PanelAccueil.Location = New System.Drawing.Point(58, 309)
        Me.PanelAccueil.Name = "PanelAccueil"
        Me.PanelAccueil.Size = New System.Drawing.Size(543, 236)
        Me.PanelAccueil.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaTransitionAnimation.SetDecoration(Me.TextBox1, Guna.UI.Animation.DecorationType.None)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(59, 149)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(433, 23)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Text = "CONTACT: 695-04-35-76"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaTransitionAnimation.SetDecoration(Me.TextBox3, Guna.UI.Animation.DecorationType.None)
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.White
        Me.TextBox3.Location = New System.Drawing.Point(59, 122)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(433, 12)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Text = "V.1.0.2"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaTransitionAnimation.SetDecoration(Me.TextBox2, Guna.UI.Animation.DecorationType.None)
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.White
        Me.TextBox2.Location = New System.Drawing.Point(59, 100)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(433, 22)
        Me.TextBox2.TabIndex = 8
        Me.TextBox2.Text = "Par BARCLES DIGITAL TECHNOLOGIES Cameroun"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxRights
        '
        Me.TextBoxRights.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.TextBoxRights.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaTransitionAnimation.SetDecoration(Me.TextBoxRights, Guna.UI.Animation.DecorationType.None)
        Me.TextBoxRights.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRights.ForeColor = System.Drawing.Color.White
        Me.TextBoxRights.Location = New System.Drawing.Point(59, 76)
        Me.TextBoxRights.Multiline = True
        Me.TextBoxRights.Name = "TextBoxRights"
        Me.TextBoxRights.Size = New System.Drawing.Size(433, 23)
        Me.TextBoxRights.TabIndex = 8
        Me.TextBoxRights.Text = "Copyrights BARCLES HOTEL SOFT,  2021 Tous droits réservés"
        Me.TextBoxRights.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaComboBoxLangue
        '
        Me.GunaComboBoxLangue.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxLangue.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxLangue.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxLangue.BorderSize = 1
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaComboBoxLangue, Guna.UI.Animation.DecorationType.None)
        Me.GunaComboBoxLangue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxLangue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxLangue.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxLangue.Font = New System.Drawing.Font("Nirmala UI Semilight", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxLangue.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxLangue.FormattingEnabled = True
        Me.GunaComboBoxLangue.ItemHeight = 18
        Me.GunaComboBoxLangue.Location = New System.Drawing.Point(195, 198)
        Me.GunaComboBoxLangue.Name = "GunaComboBoxLangue"
        Me.GunaComboBoxLangue.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxLangue.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxLangue.Radius = 3
        Me.GunaComboBoxLangue.Size = New System.Drawing.Size(160, 24)
        Me.GunaComboBoxLangue.TabIndex = 6
        '
        'GunaLabelLangue
        '
        Me.GunaLabelLangue.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabelLangue, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabelLangue.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelLangue.ForeColor = System.Drawing.Color.White
        Me.GunaLabelLangue.Location = New System.Drawing.Point(243, 177)
        Me.GunaLabelLangue.Name = "GunaLabelLangue"
        Me.GunaLabelLangue.Size = New System.Drawing.Size(64, 20)
        Me.GunaLabelLangue.TabIndex = 7
        Me.GunaLabelLangue.Text = "Langue: "
        '
        'GunaButtonSeConnecter
        '
        Me.GunaButtonSeConnecter.AnimationHoverSpeed = 0.07!
        Me.GunaButtonSeConnecter.AnimationSpeed = 0.03!
        Me.GunaButtonSeConnecter.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonSeConnecter.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonSeConnecter.BorderColor = System.Drawing.Color.Black
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaButtonSeConnecter, Guna.UI.Animation.DecorationType.None)
        Me.GunaButtonSeConnecter.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonSeConnecter.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonSeConnecter.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonSeConnecter.ForeColor = System.Drawing.Color.White
        Me.GunaButtonSeConnecter.Image = Nothing
        Me.GunaButtonSeConnecter.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonSeConnecter.Location = New System.Drawing.Point(191, 23)
        Me.GunaButtonSeConnecter.Name = "GunaButtonSeConnecter"
        Me.GunaButtonSeConnecter.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonSeConnecter.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonSeConnecter.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonSeConnecter.OnHoverImage = Nothing
        Me.GunaButtonSeConnecter.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonSeConnecter.Radius = 3
        Me.GunaButtonSeConnecter.Size = New System.Drawing.Size(178, 42)
        Me.GunaButtonSeConnecter.TabIndex = 2
        Me.GunaButtonSeConnecter.Text = "Se connecter"
        Me.GunaButtonSeConnecter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabel4, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel4.ForeColor = System.Drawing.Color.White
        Me.GunaLabel4.Location = New System.Drawing.Point(148, 311)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(13, 15)
        Me.GunaLabel4.TabIndex = 1
        Me.GunaLabel4.Text = "a"
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabel5, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabel5.Font = New System.Drawing.Font("Palatino Linotype", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.ForeColor = System.Drawing.Color.White
        Me.GunaLabel5.Location = New System.Drawing.Point(56, 235)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(417, 47)
        Me.GunaLabel5.TabIndex = 0
        Me.GunaLabel5.Text = "BARCLES HOTEL SOFT"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabel2, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.ForeColor = System.Drawing.Color.White
        Me.GunaLabel2.Location = New System.Drawing.Point(91, 92)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(0, 17)
        Me.GunaLabel2.TabIndex = 1
        '
        'PanelConnexion
        '
        Me.PanelConnexion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelConnexion.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.PanelConnexion.Controls.Add(Me.GunaCheckBoxVersion)
        Me.PanelConnexion.Controls.Add(Me.GunaLineTextBoxUsername)
        Me.PanelConnexion.Controls.Add(Me.GunaComboBoxVersion)
        Me.PanelConnexion.Controls.Add(Me.GunaButtonAnnulerAccueil)
        Me.PanelConnexion.Controls.Add(Me.GunaLabelVersion)
        Me.PanelConnexion.Controls.Add(Me.GunaLineTextBoxMotDePasse)
        Me.PanelConnexion.Controls.Add(Me.GunaLabelPwd)
        Me.PanelConnexion.Controls.Add(Me.GunaLabelUser)
        Me.PanelConnexion.Controls.Add(Me.GunaLabel6)
        Me.PanelConnexion.Controls.Add(Me.GunaButtonOuvrirSession)
        Me.GunaTransitionAnimation.SetDecoration(Me.PanelConnexion, Guna.UI.Animation.DecorationType.None)
        Me.PanelConnexion.Location = New System.Drawing.Point(58, 309)
        Me.PanelConnexion.Name = "PanelConnexion"
        Me.PanelConnexion.Size = New System.Drawing.Size(543, 236)
        Me.PanelConnexion.TabIndex = 5
        Me.PanelConnexion.Visible = False
        '
        'GunaCheckBoxVersion
        '
        Me.GunaCheckBoxVersion.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxVersion.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxVersion.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaCheckBoxVersion, Guna.UI.Animation.DecorationType.None)
        Me.GunaCheckBoxVersion.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxVersion.Location = New System.Drawing.Point(266, 203)
        Me.GunaCheckBoxVersion.Name = "GunaCheckBoxVersion"
        Me.GunaCheckBoxVersion.Size = New System.Drawing.Size(20, 20)
        Me.GunaCheckBoxVersion.TabIndex = 6
        '
        'GunaLineTextBoxUsername
        '
        Me.GunaLineTextBoxUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.GunaLineTextBoxUsername.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLineTextBoxUsername, Guna.UI.Animation.DecorationType.None)
        Me.GunaLineTextBoxUsername.FocusedLineColor = System.Drawing.Color.White
        Me.GunaLineTextBoxUsername.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLineTextBoxUsername.ForeColor = System.Drawing.Color.White
        Me.GunaLineTextBoxUsername.LineColor = System.Drawing.Color.Maroon
        Me.GunaLineTextBoxUsername.LineSize = 2
        Me.GunaLineTextBoxUsername.Location = New System.Drawing.Point(167, 31)
        Me.GunaLineTextBoxUsername.Name = "GunaLineTextBoxUsername"
        Me.GunaLineTextBoxUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaLineTextBoxUsername.SelectedText = ""
        Me.GunaLineTextBoxUsername.Size = New System.Drawing.Size(284, 32)
        Me.GunaLineTextBoxUsername.TabIndex = 0
        '
        'GunaComboBoxVersion
        '
        Me.GunaComboBoxVersion.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxVersion.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxVersion.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaComboBoxVersion.BorderSize = 1
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaComboBoxVersion, Guna.UI.Animation.DecorationType.None)
        Me.GunaComboBoxVersion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxVersion.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxVersion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaComboBoxVersion.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxVersion.FormattingEnabled = True
        Me.GunaComboBoxVersion.ItemHeight = 25
        Me.GunaComboBoxVersion.Location = New System.Drawing.Point(167, 149)
        Me.GunaComboBoxVersion.Name = "GunaComboBoxVersion"
        Me.GunaComboBoxVersion.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxVersion.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxVersion.Size = New System.Drawing.Size(284, 31)
        Me.GunaComboBoxVersion.TabIndex = 2
        Me.GunaComboBoxVersion.Visible = False
        '
        'GunaButtonAnnulerAccueil
        '
        Me.GunaButtonAnnulerAccueil.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAnnulerAccueil.AnimationSpeed = 0.03!
        Me.GunaButtonAnnulerAccueil.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAnnulerAccueil.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAnnulerAccueil.BorderColor = System.Drawing.Color.Black
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaButtonAnnulerAccueil, Guna.UI.Animation.DecorationType.None)
        Me.GunaButtonAnnulerAccueil.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAnnulerAccueil.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAnnulerAccueil.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAnnulerAccueil.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAnnulerAccueil.Image = Nothing
        Me.GunaButtonAnnulerAccueil.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAnnulerAccueil.Location = New System.Drawing.Point(90, 200)
        Me.GunaButtonAnnulerAccueil.Name = "GunaButtonAnnulerAccueil"
        Me.GunaButtonAnnulerAccueil.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAnnulerAccueil.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAnnulerAccueil.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAnnulerAccueil.OnHoverImage = Nothing
        Me.GunaButtonAnnulerAccueil.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAnnulerAccueil.Radius = 4
        Me.GunaButtonAnnulerAccueil.Size = New System.Drawing.Size(138, 27)
        Me.GunaButtonAnnulerAccueil.TabIndex = 5
        Me.GunaButtonAnnulerAccueil.Text = "Annuler"
        Me.GunaButtonAnnulerAccueil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabelVersion
        '
        Me.GunaLabelVersion.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabelVersion, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabelVersion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelVersion.ForeColor = System.Drawing.Color.Black
        Me.GunaLabelVersion.Location = New System.Drawing.Point(99, 154)
        Me.GunaLabelVersion.Name = "GunaLabelVersion"
        Me.GunaLabelVersion.Size = New System.Drawing.Size(60, 20)
        Me.GunaLabelVersion.TabIndex = 5
        Me.GunaLabelVersion.Text = "Version:"
        Me.GunaLabelVersion.Visible = False
        '
        'GunaLineTextBoxMotDePasse
        '
        Me.GunaLineTextBoxMotDePasse.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.GunaLineTextBoxMotDePasse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLineTextBoxMotDePasse, Guna.UI.Animation.DecorationType.None)
        Me.GunaLineTextBoxMotDePasse.FocusedLineColor = System.Drawing.Color.White
        Me.GunaLineTextBoxMotDePasse.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLineTextBoxMotDePasse.ForeColor = System.Drawing.Color.White
        Me.GunaLineTextBoxMotDePasse.LineColor = System.Drawing.Color.Maroon
        Me.GunaLineTextBoxMotDePasse.LineSize = 2
        Me.GunaLineTextBoxMotDePasse.Location = New System.Drawing.Point(168, 79)
        Me.GunaLineTextBoxMotDePasse.Name = "GunaLineTextBoxMotDePasse"
        Me.GunaLineTextBoxMotDePasse.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.GunaLineTextBoxMotDePasse.SelectedText = ""
        Me.GunaLineTextBoxMotDePasse.Size = New System.Drawing.Size(284, 32)
        Me.GunaLineTextBoxMotDePasse.TabIndex = 1
        Me.GunaLineTextBoxMotDePasse.UseSystemPasswordChar = True
        '
        'GunaLabelPwd
        '
        Me.GunaLabelPwd.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabelPwd, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabelPwd.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelPwd.ForeColor = System.Drawing.Color.Black
        Me.GunaLabelPwd.Location = New System.Drawing.Point(54, 85)
        Me.GunaLabelPwd.Name = "GunaLabelPwd"
        Me.GunaLabelPwd.Size = New System.Drawing.Size(109, 20)
        Me.GunaLabelPwd.TabIndex = 5
        Me.GunaLabelPwd.Text = "Mot de passe : "
        '
        'GunaLabelUser
        '
        Me.GunaLabelUser.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabelUser, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabelUser.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelUser.ForeColor = System.Drawing.Color.Black
        Me.GunaLabelUser.Location = New System.Drawing.Point(76, 35)
        Me.GunaLabelUser.Name = "GunaLabelUser"
        Me.GunaLabelUser.Size = New System.Drawing.Size(87, 20)
        Me.GunaLabelUser.TabIndex = 3
        Me.GunaLabelUser.Text = "Utilisateur : "
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabel6, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel6.ForeColor = System.Drawing.Color.White
        Me.GunaLabel6.Location = New System.Drawing.Point(148, 311)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(13, 15)
        Me.GunaLabel6.TabIndex = 1
        Me.GunaLabel6.Text = "a"
        '
        'GunaButtonOuvrirSession
        '
        Me.GunaButtonOuvrirSession.AnimationHoverSpeed = 0.07!
        Me.GunaButtonOuvrirSession.AnimationSpeed = 0.03!
        Me.GunaButtonOuvrirSession.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonOuvrirSession.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonOuvrirSession.BorderColor = System.Drawing.Color.Black
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaButtonOuvrirSession, Guna.UI.Animation.DecorationType.None)
        Me.GunaButtonOuvrirSession.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonOuvrirSession.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonOuvrirSession.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonOuvrirSession.ForeColor = System.Drawing.Color.White
        Me.GunaButtonOuvrirSession.Image = Nothing
        Me.GunaButtonOuvrirSession.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonOuvrirSession.Location = New System.Drawing.Point(321, 200)
        Me.GunaButtonOuvrirSession.Name = "GunaButtonOuvrirSession"
        Me.GunaButtonOuvrirSession.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonOuvrirSession.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonOuvrirSession.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonOuvrirSession.OnHoverImage = Nothing
        Me.GunaButtonOuvrirSession.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonOuvrirSession.Radius = 4
        Me.GunaButtonOuvrirSession.Size = New System.Drawing.Size(138, 27)
        Me.GunaButtonOuvrirSession.TabIndex = 3
        Me.GunaButtonOuvrirSession.Text = "Ouvrir une Session"
        Me.GunaButtonOuvrirSession.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTransitionAnimation
        '
        Me.GunaTransitionAnimation.AnimationType = Guna.UI.Animation.AnimationType.Scale
        Me.GunaTransitionAnimation.Cursor = Nothing
        Animation1.AnimateOnlyDifferences = True
        Animation1.BlindCoeff = CType(resources.GetObject("Animation1.BlindCoeff"), System.Drawing.PointF)
        Animation1.LeafCoeff = 0!
        Animation1.MaxTime = 1.0!
        Animation1.MinTime = 0!
        Animation1.MosaicCoeff = CType(resources.GetObject("Animation1.MosaicCoeff"), System.Drawing.PointF)
        Animation1.MosaicShift = CType(resources.GetObject("Animation1.MosaicShift"), System.Drawing.PointF)
        Animation1.MosaicSize = 0
        Animation1.Padding = New System.Windows.Forms.Padding(0)
        Animation1.RotateCoeff = 0!
        Animation1.RotateLimit = 0!
        Animation1.ScaleCoeff = CType(resources.GetObject("Animation1.ScaleCoeff"), System.Drawing.PointF)
        Animation1.SlideCoeff = CType(resources.GetObject("Animation1.SlideCoeff"), System.Drawing.PointF)
        Animation1.TimeCoeff = 0!
        Animation1.TransparencyCoeff = 0!
        Me.GunaTransitionAnimation.DefaultAnimation = Animation1
        Me.GunaTransitionAnimation.MaxAnimationTime = 1000
        '
        'GunaPanelFormTop
        '
        Me.GunaPanelFormTop.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GunaPanelFormTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanelFormTop.Controls.Add(Me.PictureBox1)
        Me.GunaPanelFormTop.Controls.Add(Me.GunaLabelNomUtilisateur)
        Me.GunaPanelFormTop.Controls.Add(Me.GunaLabelUsername)
        Me.GunaPanelFormTop.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanelFormTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaPanelFormTop, Guna.UI.Animation.DecorationType.None)
        Me.GunaPanelFormTop.Location = New System.Drawing.Point(0, -2)
        Me.GunaPanelFormTop.Name = "GunaPanelFormTop"
        Me.GunaPanelFormTop.Size = New System.Drawing.Size(657, 31)
        Me.GunaPanelFormTop.TabIndex = 5
        '
        'GunaLabelNomUtilisateur
        '
        Me.GunaLabelNomUtilisateur.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabelNomUtilisateur, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabelNomUtilisateur.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelNomUtilisateur.ForeColor = System.Drawing.Color.White
        Me.GunaLabelNomUtilisateur.Location = New System.Drawing.Point(251, 8)
        Me.GunaLabelNomUtilisateur.Name = "GunaLabelNomUtilisateur"
        Me.GunaLabelNomUtilisateur.Size = New System.Drawing.Size(120, 17)
        Me.GunaLabelNomUtilisateur.TabIndex = 10
        Me.GunaLabelNomUtilisateur.Text = "ADMINISTRATION"
        Me.GunaLabelNomUtilisateur.Visible = False
        '
        'GunaLabelUsername
        '
        Me.GunaLabelUsername.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabelUsername, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabelUsername.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelUsername.ForeColor = System.Drawing.Color.White
        Me.GunaLabelUsername.Location = New System.Drawing.Point(264, 8)
        Me.GunaLabelUsername.Name = "GunaLabelUsername"
        Me.GunaLabelUsername.Size = New System.Drawing.Size(0, 17)
        Me.GunaLabelUsername.TabIndex = 8
        '
        'GunaGroupBoxHotel
        '
        Me.GunaGroupBoxHotel.BackColor = System.Drawing.Color.White
        Me.GunaGroupBoxHotel.BaseColor = System.Drawing.Color.White
        Me.GunaGroupBoxHotel.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBoxHotel.BorderSize = 2
        Me.GunaGroupBoxHotel.Controls.Add(Me.GunaLabelTitle)
        Me.GunaGroupBoxHotel.Controls.Add(Me.GunaPictureBoxHotel)
        Me.GunaGroupBoxHotel.Controls.Add(Me.GunaLabelHotelName)
        Me.GunaGroupBoxHotel.Controls.Add(Me.GunaPictureBoxCustom)
        Me.GunaGroupBoxHotel.Controls.Add(Me.GunaPictureBoxRestaurant)
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaGroupBoxHotel, Guna.UI.Animation.DecorationType.None)
        Me.GunaGroupBoxHotel.LineBottom = 2
        Me.GunaGroupBoxHotel.LineColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBoxHotel.LineLeft = 2
        Me.GunaGroupBoxHotel.LineRight = 2
        Me.GunaGroupBoxHotel.LineTop = 2
        Me.GunaGroupBoxHotel.Location = New System.Drawing.Point(58, 58)
        Me.GunaGroupBoxHotel.Name = "GunaGroupBoxHotel"
        Me.GunaGroupBoxHotel.Size = New System.Drawing.Size(542, 234)
        Me.GunaGroupBoxHotel.TabIndex = 6
        Me.GunaGroupBoxHotel.TextLocation = New System.Drawing.Point(10, 8)
        '
        'GunaLabelTitle
        '
        Me.GunaLabelTitle.AutoSize = True
        Me.GunaLabelTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabelTitle, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabelTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabelTitle.ForeColor = System.Drawing.Color.Purple
        Me.GunaLabelTitle.Location = New System.Drawing.Point(121, 185)
        Me.GunaLabelTitle.Name = "GunaLabelTitle"
        Me.GunaLabelTitle.Size = New System.Drawing.Size(299, 18)
        Me.GunaLabelTitle.TabIndex = 8
        Me.GunaLabelTitle.Text = "LOGICIELS DE GESTION HÔTELIERE"
        '
        'GunaLabelHotelName
        '
        Me.GunaLabelHotelName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLabelHotelName.AutoSize = True
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaLabelHotelName, Guna.UI.Animation.DecorationType.None)
        Me.GunaLabelHotelName.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelHotelName.Location = New System.Drawing.Point(79, -3)
        Me.GunaLabelHotelName.Name = "GunaLabelHotelName"
        Me.GunaLabelHotelName.Size = New System.Drawing.Size(119, 48)
        Me.GunaLabelHotelName.TabIndex = 11
        Me.GunaLabelHotelName.Text = "HOTEL"
        Me.GunaLabelHotelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GunaLabelHotelName.Visible = False
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaPanel1, Guna.UI.Animation.DecorationType.None)
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 549)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(656, 10)
        Me.GunaPanel1.TabIndex = 7
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaPanelFormTop
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaPictureBoxHotel
        '
        Me.GunaPictureBoxHotel.BaseColor = System.Drawing.Color.White
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaPictureBoxHotel, Guna.UI.Animation.DecorationType.None)
        Me.GunaPictureBoxHotel.Image = CType(resources.GetObject("GunaPictureBoxHotel.Image"), System.Drawing.Image)
        Me.GunaPictureBoxHotel.Location = New System.Drawing.Point(6, 3)
        Me.GunaPictureBoxHotel.Name = "GunaPictureBoxHotel"
        Me.GunaPictureBoxHotel.Size = New System.Drawing.Size(530, 224)
        Me.GunaPictureBoxHotel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GunaPictureBoxHotel.TabIndex = 9
        Me.GunaPictureBoxHotel.TabStop = False
        '
        'GunaPictureBoxCustom
        '
        Me.GunaPictureBoxCustom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaPictureBoxCustom.BaseColor = System.Drawing.Color.Transparent
        Me.GunaPictureBoxCustom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaPictureBoxCustom, Guna.UI.Animation.DecorationType.None)
        Me.GunaPictureBoxCustom.Image = CType(resources.GetObject("GunaPictureBoxCustom.Image"), System.Drawing.Image)
        Me.GunaPictureBoxCustom.Location = New System.Drawing.Point(-1, -25)
        Me.GunaPictureBoxCustom.Name = "GunaPictureBoxCustom"
        Me.GunaPictureBoxCustom.Size = New System.Drawing.Size(546, 270)
        Me.GunaPictureBoxCustom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GunaPictureBoxCustom.TabIndex = 10
        Me.GunaPictureBoxCustom.TabStop = False
        Me.GunaPictureBoxCustom.Visible = False
        '
        'GunaPictureBoxRestaurant
        '
        Me.GunaPictureBoxRestaurant.BaseColor = System.Drawing.Color.White
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaPictureBoxRestaurant, Guna.UI.Animation.DecorationType.None)
        Me.GunaPictureBoxRestaurant.Image = Global.BarclesHSoft.My.Resources.Resources.Restaurantsoft_header_1_png
        Me.GunaPictureBoxRestaurant.Location = New System.Drawing.Point(6, 6)
        Me.GunaPictureBoxRestaurant.Name = "GunaPictureBoxRestaurant"
        Me.GunaPictureBoxRestaurant.Size = New System.Drawing.Size(530, 224)
        Me.GunaPictureBoxRestaurant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GunaPictureBoxRestaurant.TabIndex = 7
        Me.GunaPictureBoxRestaurant.TabStop = False
        Me.GunaPictureBoxRestaurant.Visible = False
        '
        'PictureBox1
        '
        Me.GunaTransitionAnimation.SetDecoration(Me.PictureBox1, Guna.UI.Animation.DecorationType.None)
        Me.PictureBox1.Image = Global.BarclesHSoft.My.Resources.Resources.BARCLES_LOGO_BLQNC
        Me.PictureBox1.Location = New System.Drawing.Point(12, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaImageButton2, Guna.UI.Animation.DecorationType.None)
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = CType(resources.GetObject("GunaImageButton2.Image"), System.Drawing.Image)
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(600, 6)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 7
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaTransitionAnimation.SetDecoration(Me.GunaImageButton1, Guna.UI.Animation.DecorationType.None)
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = CType(resources.GetObject("GunaImageButton1.Image"), System.Drawing.Image)
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(625, 6)
        Me.GunaImageButton1.Name = "GunaImageButton1"
        Me.GunaImageButton1.OnHoverImage = Nothing
        Me.GunaImageButton1.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton1.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton1.TabIndex = 6
        '
        'AccueilForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(657, 560)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.PanelAccueil)
        Me.Controls.Add(Me.GunaGroupBoxHotel)
        Me.Controls.Add(Me.GunaPanelFormTop)
        Me.Controls.Add(Me.PanelConnexion)
        Me.GunaTransitionAnimation.SetDecoration(Me, Guna.UI.Animation.DecorationType.None)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "AccueilForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.PanelAccueil.ResumeLayout(False)
        Me.PanelAccueil.PerformLayout()
        Me.PanelConnexion.ResumeLayout(False)
        Me.PanelConnexion.PerformLayout()
        Me.GunaPanelFormTop.ResumeLayout(False)
        Me.GunaPanelFormTop.PerformLayout()
        Me.GunaGroupBoxHotel.ResumeLayout(False)
        Me.GunaGroupBoxHotel.PerformLayout()
        CType(Me.GunaPictureBoxHotel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaPictureBoxCustom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaPictureBoxRestaurant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaTransitionAnimation As Guna.UI.WinForms.GunaTransition
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonSeConnecter As Guna.UI.WinForms.GunaButton
    Friend WithEvents PanelAccueil As Panel
    Friend WithEvents PanelConnexion As Panel
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanelFormTop As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabelUser As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLineTextBoxUsername As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents GunaLineTextBoxMotDePasse As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents GunaLabelPwd As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonOuvrirSession As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonAnnulerAccueil As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelUsername As Guna.UI.WinForms.GunaLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GunaLabelNomUtilisateur As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaGroupBoxHotel As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents GunaComboBoxVersion As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabelVersion As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaCheckBoxVersion As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaPictureBoxRestaurant As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaComboBoxLangue As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabelLangue As Guna.UI.WinForms.GunaLabel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GunaLabelTitle As Guna.UI.WinForms.GunaLabel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GunaPictureBoxHotel As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents TextBoxRights As TextBox
    Friend WithEvents GunaPictureBoxCustom As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents GunaLabelHotelName As Guna.UI.WinForms.GunaLabel
End Class
