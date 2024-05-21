Imports MySql.Data.MySqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CloturerForm

    Inherits System.Windows.Forms.Form

    'Dim connect As New DataBaseManipulation()

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
    Friend WithEvents GunaImageButtonFermer As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GunaCheckBox4 As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaCheckBoxClotureDeCaisse As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaCheckBoxReservationNonArrivee As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaCheckBoxDepartDuJour As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaCircleProgressBar1 As Guna.UI.WinForms.GunaCircleProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabelTemps As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonTerminer As Guna.UI.WinForms.GunaButton
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker4 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker5 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker6 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker7 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker8 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker9 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker10 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker11 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker12 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker13 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker14 As System.ComponentModel.BackgroundWorker

    Friend WithEvents BackgroundWorker15 As System.ComponentModel.BackgroundWorker
    Friend WithEvents dt As Guna.UI.WinForms.GunaDataGridView

    Public Class ArgumentType

        'action = 0 : ultrMessageSimpleText
        Public action As Integer
        Public whatsAppMessage As String
        Public mobile_number As String
        Public dt As DataTable
        Public DateDebut As Date
        Public DateFin As Date
        Public fichier As String

    End Class

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CloturerForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButtonFermer = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaButtonAnnuler = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonCloturer = New Guna.UI.WinForms.GunaButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GunaLabelTemps = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaCircleProgressBar1 = New Guna.UI.WinForms.GunaCircleProgressBar()
        Me.GunaCheckBox4 = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaCheckBoxClotureDeCaisse = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaCheckBoxReservationNonArrivee = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaCheckBoxDepartDuJour = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GunaButtonTerminer = New Guna.UI.WinForms.GunaButton()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker4 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker5 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker6 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker7 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker8 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker9 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker10 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker11 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker12 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker13 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker14 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker15 = New System.ComponentModel.BackgroundWorker()
        Me.dt = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GunaCircleProgressBar1.SuspendLayout()
        CType(Me.dt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
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
        Me.GunaPanel1.Size = New System.Drawing.Size(450, 25)
        Me.GunaPanel1.TabIndex = 1
        '
        'GunaImageButtonFermer
        '
        Me.GunaImageButtonFermer.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButtonFermer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButtonFermer.Image = CType(resources.GetObject("GunaImageButtonFermer.Image"), System.Drawing.Image)
        Me.GunaImageButtonFermer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButtonFermer.Location = New System.Drawing.Point(421, 3)
        Me.GunaImageButtonFermer.Name = "GunaImageButtonFermer"
        Me.GunaImageButtonFermer.OnHoverImage = Nothing
        Me.GunaImageButtonFermer.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButtonFermer.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButtonFermer.TabIndex = 12
        '
        'GunaImageButton5
        '
        Me.GunaImageButton5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton5.Image = Nothing
        Me.GunaImageButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton5.Location = New System.Drawing.Point(411, 3)
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
        Me.GunaImageButton4.Location = New System.Drawing.Point(418, 2)
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
        Me.GunaImageButton3.Location = New System.Drawing.Point(416, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(416, 3)
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
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(131, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(171, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "CLOTURE DE JOURNEE"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(415, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(1617, -2)
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
        'GunaButtonAnnuler
        '
        Me.GunaButtonAnnuler.AnimationHoverSpeed = 0.07!
        Me.GunaButtonAnnuler.AnimationSpeed = 0.03!
        Me.GunaButtonAnnuler.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonAnnuler.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonAnnuler.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonAnnuler.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonAnnuler.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonAnnuler.ForeColor = System.Drawing.Color.White
        Me.GunaButtonAnnuler.Image = Nothing
        Me.GunaButtonAnnuler.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonAnnuler.Location = New System.Drawing.Point(42, 297)
        Me.GunaButtonAnnuler.Name = "GunaButtonAnnuler"
        Me.GunaButtonAnnuler.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonAnnuler.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonAnnuler.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonAnnuler.OnHoverImage = Nothing
        Me.GunaButtonAnnuler.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonAnnuler.Radius = 4
        Me.GunaButtonAnnuler.Size = New System.Drawing.Size(109, 37)
        Me.GunaButtonAnnuler.TabIndex = 3
        Me.GunaButtonAnnuler.Text = "Annuler"
        Me.GunaButtonAnnuler.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButtonCloturer
        '
        Me.GunaButtonCloturer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonCloturer.AnimationSpeed = 0.03!
        Me.GunaButtonCloturer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonCloturer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonCloturer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonCloturer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonCloturer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonCloturer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonCloturer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonCloturer.Image = Nothing
        Me.GunaButtonCloturer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonCloturer.Location = New System.Drawing.Point(300, 297)
        Me.GunaButtonCloturer.Name = "GunaButtonCloturer"
        Me.GunaButtonCloturer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonCloturer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonCloturer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonCloturer.OnHoverImage = Nothing
        Me.GunaButtonCloturer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonCloturer.Radius = 4
        Me.GunaButtonCloturer.Size = New System.Drawing.Size(104, 37)
        Me.GunaButtonCloturer.TabIndex = 3
        Me.GunaButtonCloturer.Text = "Clôturer"
        Me.GunaButtonCloturer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GunaLabelTemps)
        Me.GroupBox1.Controls.Add(Me.GunaLabel3)
        Me.GroupBox1.Controls.Add(Me.GunaLabel6)
        Me.GroupBox1.Controls.Add(Me.GunaLabel4)
        Me.GroupBox1.Controls.Add(Me.GunaLabel2)
        Me.GroupBox1.Controls.Add(Me.GunaCircleProgressBar1)
        Me.GroupBox1.Controls.Add(Me.GunaCheckBox4)
        Me.GroupBox1.Controls.Add(Me.GunaCheckBoxClotureDeCaisse)
        Me.GroupBox1.Controls.Add(Me.GunaCheckBoxReservationNonArrivee)
        Me.GroupBox1.Controls.Add(Me.GunaCheckBoxDepartDuJour)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 250)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contrôle Avant cloture du :"
        '
        'GunaLabelTemps
        '
        Me.GunaLabelTemps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLabelTemps.AutoSize = True
        Me.GunaLabelTemps.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabelTemps.ForeColor = System.Drawing.Color.Black
        Me.GunaLabelTemps.Location = New System.Drawing.Point(25, 22)
        Me.GunaLabelTemps.Name = "GunaLabelTemps"
        Me.GunaLabelTemps.Size = New System.Drawing.Size(78, 28)
        Me.GunaLabelTemps.TabIndex = 80
        Me.GunaLabelTemps.Text = "Temps "
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel3.Location = New System.Drawing.Point(6, 66)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(201, 19)
        Me.GunaLabel3.TabIndex = 6
        Me.GunaLabel3.Text = "1 - Départs du jours à effectuer"
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel6.Location = New System.Drawing.Point(6, 141)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(179, 19)
        Me.GunaLabel6.TabIndex = 6
        Me.GunaLabel6.Text = "4- Sauvegarde des données"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel4.Location = New System.Drawing.Point(6, 116)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(225, 19)
        Me.GunaLabel4.TabIndex = 6
        Me.GunaLabel4.Text = "3- Réservations du jour non arrivée"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(6, 91)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(142, 19)
        Me.GunaLabel2.TabIndex = 6
        Me.GunaLabel2.Text = "2- Clôture des caisses"
        '
        'GunaCircleProgressBar1
        '
        Me.GunaCircleProgressBar1.AnimationSpeed = 0.6!
        Me.GunaCircleProgressBar1.BaseColor = System.Drawing.Color.Transparent
        Me.GunaCircleProgressBar1.Controls.Add(Me.dt)
        Me.GunaCircleProgressBar1.Font = New System.Drawing.Font("Segoe UI Semilight", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCircleProgressBar1.ForeColor = System.Drawing.Color.Black
        Me.GunaCircleProgressBar1.IdleColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.GunaCircleProgressBar1.IdleOffset = 21
        Me.GunaCircleProgressBar1.IdleThickness = 10
        Me.GunaCircleProgressBar1.Image = Nothing
        Me.GunaCircleProgressBar1.ImageSize = New System.Drawing.Size(52, 52)
        Me.GunaCircleProgressBar1.LineEndCap = System.Drawing.Drawing2D.LineCap.Round
        Me.GunaCircleProgressBar1.LineStartCap = System.Drawing.Drawing2D.LineCap.Round
        Me.GunaCircleProgressBar1.Location = New System.Drawing.Point(228, 22)
        Me.GunaCircleProgressBar1.Maximum = 300
        Me.GunaCircleProgressBar1.Name = "GunaCircleProgressBar1"
        Me.GunaCircleProgressBar1.ProgressMaxColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GunaCircleProgressBar1.ProgressMinColor = System.Drawing.Color.Cyan
        Me.GunaCircleProgressBar1.ProgressOffset = 20
        Me.GunaCircleProgressBar1.ProgressThickness = 30
        Me.GunaCircleProgressBar1.Size = New System.Drawing.Size(195, 195)
        Me.GunaCircleProgressBar1.TabIndex = 5
        Me.GunaCircleProgressBar1.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        Me.GunaCircleProgressBar1.UseProgressPercentText = True
        Me.GunaCircleProgressBar1.Visible = False
        '
        'GunaCheckBox4
        '
        Me.GunaCheckBox4.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBox4.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBox4.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBox4.FillColor = System.Drawing.Color.White
        Me.GunaCheckBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBox4.Location = New System.Drawing.Point(6, 201)
        Me.GunaCheckBox4.Name = "GunaCheckBox4"
        Me.GunaCheckBox4.Size = New System.Drawing.Size(183, 20)
        Me.GunaCheckBox4.TabIndex = 0
        Me.GunaCheckBox4.Text = "Sauvegarde des données"
        Me.GunaCheckBox4.Visible = False
        '
        'GunaCheckBoxClotureDeCaisse
        '
        Me.GunaCheckBoxClotureDeCaisse.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxClotureDeCaisse.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxClotureDeCaisse.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxClotureDeCaisse.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxClotureDeCaisse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxClotureDeCaisse.Location = New System.Drawing.Point(190, 199)
        Me.GunaCheckBoxClotureDeCaisse.Name = "GunaCheckBoxClotureDeCaisse"
        Me.GunaCheckBoxClotureDeCaisse.Size = New System.Drawing.Size(134, 20)
        Me.GunaCheckBoxClotureDeCaisse.TabIndex = 0
        Me.GunaCheckBoxClotureDeCaisse.Text = "Clôture de caisse"
        Me.GunaCheckBoxClotureDeCaisse.Visible = False
        '
        'GunaCheckBoxReservationNonArrivee
        '
        Me.GunaCheckBoxReservationNonArrivee.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxReservationNonArrivee.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxReservationNonArrivee.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxReservationNonArrivee.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxReservationNonArrivee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxReservationNonArrivee.Location = New System.Drawing.Point(189, 225)
        Me.GunaCheckBoxReservationNonArrivee.Name = "GunaCheckBoxReservationNonArrivee"
        Me.GunaCheckBoxReservationNonArrivee.Size = New System.Drawing.Size(230, 20)
        Me.GunaCheckBoxReservationNonArrivee.TabIndex = 0
        Me.GunaCheckBoxReservationNonArrivee.Text = "Réservations du jour non arrivées"
        Me.GunaCheckBoxReservationNonArrivee.Visible = False
        '
        'GunaCheckBoxDepartDuJour
        '
        Me.GunaCheckBoxDepartDuJour.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxDepartDuJour.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxDepartDuJour.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxDepartDuJour.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxDepartDuJour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxDepartDuJour.Location = New System.Drawing.Point(6, 222)
        Me.GunaCheckBoxDepartDuJour.Name = "GunaCheckBoxDepartDuJour"
        Me.GunaCheckBoxDepartDuJour.Size = New System.Drawing.Size(188, 20)
        Me.GunaCheckBoxDepartDuJour.TabIndex = 0
        Me.GunaCheckBoxDepartDuJour.Text = "Départs du jour à effectuer"
        Me.GunaCheckBoxDepartDuJour.Visible = False
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 342)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(450, 5)
        Me.GunaPanel2.TabIndex = 1
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'GunaButtonTerminer
        '
        Me.GunaButtonTerminer.AnimationHoverSpeed = 0.07!
        Me.GunaButtonTerminer.AnimationSpeed = 0.03!
        Me.GunaButtonTerminer.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonTerminer.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaButtonTerminer.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonTerminer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonTerminer.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonTerminer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonTerminer.ForeColor = System.Drawing.Color.White
        Me.GunaButtonTerminer.Image = Nothing
        Me.GunaButtonTerminer.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonTerminer.Location = New System.Drawing.Point(173, 297)
        Me.GunaButtonTerminer.Name = "GunaButtonTerminer"
        Me.GunaButtonTerminer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonTerminer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonTerminer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonTerminer.OnHoverImage = Nothing
        Me.GunaButtonTerminer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonTerminer.Radius = 4
        Me.GunaButtonTerminer.Size = New System.Drawing.Size(104, 37)
        Me.GunaButtonTerminer.TabIndex = 3
        Me.GunaButtonTerminer.Text = "Terminer"
        Me.GunaButtonTerminer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButtonTerminer.Visible = False
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'BackgroundWorker3
        '
        Me.BackgroundWorker3.WorkerSupportsCancellation = True
        '
        'BackgroundWorker4
        '
        Me.BackgroundWorker4.WorkerSupportsCancellation = True
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
        'BackgroundWorker10
        '
        Me.BackgroundWorker10.WorkerSupportsCancellation = True
        '
        'BackgroundWorker11
        '
        Me.BackgroundWorker11.WorkerSupportsCancellation = True
        '
        'BackgroundWorker12
        '
        Me.BackgroundWorker12.WorkerSupportsCancellation = True
        '
        'BackgroundWorker13
        '
        Me.BackgroundWorker13.WorkerSupportsCancellation = True
        '
        'BackgroundWorker14
        '
        Me.BackgroundWorker14.WorkerSupportsCancellation = True
        '
        'BackgroundWorker15
        '
        Me.BackgroundWorker15.WorkerSupportsCancellation = True
        '
        'dt
        '
        Me.dt.AllowUserToAddRows = False
        Me.dt.AllowUserToDeleteRows = False
        Me.dt.AllowUserToOrderColumns = True
        Me.dt.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dt.BackgroundColor = System.Drawing.Color.LightBlue
        Me.dt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semilight", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dt.ColumnHeadersHeight = 25
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semilight", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dt.DefaultCellStyle = DataGridViewCellStyle3
        Me.dt.EnableHeadersVisualStyles = False
        Me.dt.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dt.Location = New System.Drawing.Point(3, 3)
        Me.dt.MultiSelect = False
        Me.dt.Name = "dt"
        Me.dt.ReadOnly = True
        Me.dt.RowHeadersVisible = False
        Me.dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dt.Size = New System.Drawing.Size(188, 38)
        Me.dt.TabIndex = 35
        Me.dt.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.dt.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dt.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dt.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dt.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dt.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dt.ThemeStyle.BackColor = System.Drawing.Color.LightBlue
        Me.dt.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dt.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dt.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dt.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI Semilight", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dt.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dt.ThemeStyle.HeaderStyle.Height = 25
        Me.dt.ThemeStyle.ReadOnly = True
        Me.dt.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dt.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dt.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI Semilight", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dt.ThemeStyle.RowsStyle.Height = 22
        Me.dt.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dt.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dt.Visible = False
        '
        'CloturerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 348)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GunaButtonTerminer)
        Me.Controls.Add(Me.GunaButtonCloturer)
        Me.Controls.Add(Me.GunaButtonAnnuler)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CloturerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneralAccountForm"
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GunaCircleProgressBar1.ResumeLayout(False)
        CType(Me.dt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonCloturer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonAnnuler As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButtonFermer.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Dim dateRapport As Date

    Private Sub CloturerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.cloture(GlobalVariable.actualLanguageValue)

        Control.CheckForIllegalCrossThreadCalls = False

        GunaLabelTemps.Text = GlobalVariable.DateDeTravail

        'On coche certein bouton de la fenentre de cloture par defaut
        'GunaCheckBoxDepartDuJour.Checked = True
        'GunaCheckBoxReservationNonArrivee.Checked = True

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnuler.Click

        Me.Close()

    End Sub

    'Cliquer sur le bouton cloturer

    Dim numberOfElementsToTreat As Integer = 0

    Dim sendRapportApresCloture As Boolean = False

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonCloturer.Click

        Dim dt As DataTable = Functions.reservationPayeeDujour(GlobalVariable.DateDeTravail.ToShortDateString)

        Dim facturationAnticipe As Boolean = True

        If dt.Rows.Count > 0 Then

            Dim s As String = ""
            If dt.Rows.Count > 1 Then
                s = " réservation payées"
            Else
                s = " réservations payée"
            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("La clôture n'est pas possible, il y'a " & dt.Rows.Count & s & " dans les arrivées dont la date d'arrivée doit être prolongée au " & GlobalVariable.DateDeTravail.AddDays(1), "Clôture de la Date du " & GlobalVariable.DateDeTravail, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("The night audit is not possible, we have " & dt.Rows.Count & " paid reservation(s) in the arrivals that the entering that is to be extended to the " & GlobalVariable.DateDeTravail.AddDays(1), "Night Audit Of the " & GlobalVariable.DateDeTravail, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else

            Me.Cursor = Cursors.WaitCursor

            Dim cloturer As Boolean = True

            Dim dateDeTravailAvantCloture As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
            Dim dateRapport As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

            GunaCheckBoxReservationNonArrivee.Checked = True

            BackgroundWorker1.RunWorkerAsync()

            Dim differenceDeJour As Integer = 0

            Dim dateActuelle As Date = Now().ToShortDateString

            If GlobalVariable.AgenceActuelle.Rows.Count > 0 Then

                'ON VERIFIE SI LA CLOTURE MULTIPLE EST ACTIVE OU PAS

                If GlobalVariable.AgenceActuelle.Rows(0)("CLOTURE_MULTIPLE") = 0 Then

                    differenceDeJour = CType((dateActuelle - GlobalVariable.DateDeTravail).TotalDays, Int32)

                    If Not differenceDeJour = 1 Then
                        cloturer = False
                    End If

                End If

            End If

            'On ne peut pas clôturer si il existe une différence de plus d'un jour entre la date de travail et la date réelle

            '---------------------------------------------

            Dim ETAT_CAISSE As Integer = 1 'ETAT DE LA CAISSE OUVERTE

            Dim TYPE_CAISSE As String = "Caisse principale"

            'ON FERME TOUTES LES CAISSE DE TYPE PRINCIPALE SANS CONTROLE D'EQUILIBRE AVANT LA CLOTURE DES AUTRES CAISSE POUVANT NECESSITE UN CONTROLE D'EQUILIBRE
            Dim SelectionDesCaissesPrincipales As DataTable = Functions.GetAllElementsOnTwoConditions(ETAT_CAISSE, "caisse", "ETAT_CAISSE", TYPE_CAISSE, "TYPE_CAISSE")

            If SelectionDesCaissesPrincipales.Rows.Count > 0 Then

                Dim caissier As New Caisse()

                Dim CODE_CAISSE As String = ""

                Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                For i = 0 To SelectionDesCaissesPrincipales.Rows.Count - 1
                    ETAT_CAISSE = 0 'ETAT POUR LES CAISSE FERMEE
                    CODE_CAISSE = SelectionDesCaissesPrincipales.Rows(i)("CODE_CAISSE")
                    caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)
                Next

            End If

            '---------------------------------------------

            ETAT_CAISSE = 1 ' CAISSE OUVERTE A FERMER

            Dim lesCaisses As DataTable = Functions.GetAllElementsOnCondition(ETAT_CAISSE, "caisse", "ETAT_CAISSE")

            If lesCaisses.Rows.Count > 0 Then

                CaisseOuverteAlaCloture.Close()
                CaisseOuverteAlaCloture.Show()
                CaisseOuverteAlaCloture.TopMost = True

                Me.Close()

            Else

                'Not differenceDeJour = 1

                'If Not differenceDeJour = 1 Then
                If Not cloturer Then

                    'MessageBox.Show("La clôture n'est pas possible à cause du décalage de  " & Math.Abs(differenceDeJour) & " jours " & Chr(13) & " entre la date de travail et la date réelle", "Clôture de la date du ", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("La clôture n'est pas possible car, nous avons une différence de " & differenceDeJour & " jours entre la date de travail (" & GlobalVariable.DateDeTravail & " ) et la date du système (" & Date.Now().ToShortDateString & " )", "Clôture de la date du " & GlobalVariable.DateDeTravail, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("The night audit is not possible as , we have a difference of " & differenceDeJour & " days between the working date (" & GlobalVariable.DateDeTravail & " ) and the system date (" & Date.Now().ToShortDateString & " )", "Night Audit of the " & GlobalVariable.DateDeTravail, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    Me.Close()

                Else

                    '------------------------------ RECHERCHE DES DEPARTS AVEC SOLDE NEGATIFS ----------------------------------------------------------

                    Dim DateDebutDepart As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
                    Dim DateFinDepart As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

                    'Dim queryDepart As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_SORTIE >= '" & DateDebutDepart.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & DateFinDepart.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

                    Dim queryDepart As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_SORTIE >= '" & DateDebutDepart.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & DateFinDepart.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 ORDER BY ID_RESERVATION DESC"

                    Dim commandDepart As New MySqlCommand(queryDepart, GlobalVariable.connect)
                    'commandDepart.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

                    Dim adapterDepart As New MySqlDataAdapter(commandDepart)
                    Dim tableDepart As New DataTable()
                    adapterDepart.Fill(tableDepart)

                    'AUCUNE RESERVATION A SOLDE NEGATIF ALORS ONT CONTINUENT

                    If Not tableDepart.Rows.Count > 0 Then

                        '-----------------------------------------------------------------------------------------------------------------------------------

                        Dim DateDeTravail As Date
                        Dim Reservation As New Reservation()

                        DateDeTravail = GlobalVariable.DateDeTravail

                        'Demande de confirmation avant clôture
                        Dim dialog As DialogResult

                        If GlobalVariable.actualLanguageValue = 1 Then
                            dialog = MessageBox.Show("La clôture va fermer définitivement la journée du " & DateDeTravail & " " & Chr(13) &
                         " Tous les clients en chambre seront facturés à cette date Confirmez-vous la clôture  de la journée du " & DateDeTravail & " ?", "Clôture de la date du " & DateDeTravail, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                        Else

                            dialog = MessageBox.Show("The Night Audit will defeinitely close the " & DateDeTravail & " " & Chr(13) &
                         " All the customers in house will be billed their accommodation for this date, Do you confirm the Night Audit of the " & DateDeTravail & " ", "Night Audit of the " & DateDeTravail, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                        End If

                        '1-Selection des mains courantes non clôturées par ordre croissant (permet uniquement de determiner la date a cloturer)

                        'Dim existQuery As String = "SELECT DISTINCT DATE_MAIN_COURANTE, SOUS_TOTAL1 From main_courante_journaliere WHERE ETAT_MAIN_COURANTE = @ETAT_MAIN_COURANTE AND DATE_MAIN_COURANTE <= @DATE_DU_JOUR AND TYPE=@TYPE ORDER BY DATE_MAIN_COURANTE ASC"

                        Dim existQuery As String = "SELECT DISTINCT DATE_MAIN_COURANTE From main_courante_journaliere WHERE ETAT_MAIN_COURANTE = @ETAT_MAIN_COURANTE AND DATE_MAIN_COURANTE >= @DATE_DU_JOUR AND DATE_MAIN_COURANTE <= @DATE_DU_JOUR ORDER BY DATE_MAIN_COURANTE ASC"

                        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

                        command.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
                        command.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 0
                        'command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

                        Dim adapter As New MySqlDataAdapter(command)
                        Dim mainCouranteJournaliere As New DataTable()
                        adapter.Fill(mainCouranteJournaliere)

                        ' If dialog = DialogResult.Yes Then
                        If dialog = DialogResult.Yes Then

                            If mainCouranteJournaliere.Rows.Count > 0 Then

                                Dim CODE_RESERVATION As String = ""

                                'Date a cloturer n'est pas la date du jour car les dates avant celle du jour n'ont pas étés clôturées donc ont les clôture d'abords
                                'Les clotures ne se font pas en cascade mais à achaque click de l'utilisateur

                                'DateDeTravail = mainCouranteJournaliere.Rows(0)("DATE_MAIN_COURANTE")

                                GunaCircleProgressBar1.Visible = True

                                '2- Selection des en chambres pour cloture après demande de confirmation (Toutes les reservations non annulées)

                                'On affiche toutes les reserv_conf dont la date saisie est entre la d'entrée et la date de sortie (inclusif)

                                Dim DateDebut As Date = DateDeTravail.ToString("yyyy-MM-dd")

                                'On selectionne toutes les reservation non annulées
                                Dim query As String = "SELECT * FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 ORDER BY ID_RESERVATION DESC"

                                Dim commandReservation As New MySqlCommand(query, GlobalVariable.connect)
                                'commandReservation.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

                                Dim adapterReservation As New MySqlDataAdapter(commandReservation)
                                Dim tableReservation As New DataTable()
                                adapterReservation.Fill(tableReservation)

                                'Pour chaque réservation on doit:
                                '- Insérer une ligne dans taxe séjours collectés
                                '- Créer ou insérer une ligne dans facture
                                '- Créer ou insérer une ligne dans ligne_facture 
                                '- Mettre à jours les mains courantes en agissant sur ETAT_MAIN_COUNRANTE

                                GunaCircleProgressBar1.Minimum = 0
                                GunaCircleProgressBar1.Maximum = tableReservation.Rows.Count

                                If (tableReservation.Rows.Count > 0) Then

                                    GunaCircleProgressBar1.Value = 1

                                    '3- Clôture des réservations journalieres des en chambres

                                    Dim MENSUEL As Integer

                                    For i = 0 To tableReservation.Rows.Count - 1

                                        Dim DATE_SORTIE As Date = tableReservation.Rows(i)("DATE_SORTIE")
                                        Dim DATE_FACTURE As Date

                                        MENSUEL = tableReservation.Rows(i)("MENSUEL")

                                        numberOfElementsToTreat = i

                                        GunaCircleProgressBar1.Value = i

                                        'ON NE DOIT QUE TRAITER LES RESERVATION LIEES AUX INDIVIDU ET NON CELLE LIE AUX RESERVATION CAR ELLES SERVENT POUR LES PAYMASTER
                                        'LES RESERVATIONS ENTREPRISES SONT UTILES POUR Y TRANSFERER LES FACTURES LIEES AU INVIDU DE CETTE ENTREPRISE DONC NE DOIVENT PAS
                                        'AVOIR DES FACTURES SUPPLEMENTAIRE GENEREES LORS DELA CLOTURE.
                                        ' FACTUE QU'ON PEUT RETROUVER DANS REGLEMENT ET LETTRAGE EN COMPTABILITE

                                        Dim clientInfo As DataTable = Functions.getElementByCode(tableReservation.Rows(i)("CLIENT_ID"), "client", "CODE_CLIENT")

                                        Dim typeClient As String = ""

                                        If clientInfo.Rows.Count > 0 Then
                                            typeClient = clientInfo.Rows(0)("TYPE_CLIENT")
                                        End If

                                        Dim TITRE As String = ""
                                        Dim TITRE_TYPE As String = ""

                                        If tableReservation.Rows(i)("TYPE") = "chambre" Then

                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                TITRE = "HEBERGEMENT"
                                            Else
                                                TITRE = "ACCOMMODATION"
                                            End If


                                            TITRE_TYPE = "chambre"

                                        ElseIf tableReservation.Rows(i)("TYPE") = "salle" Then


                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                TITRE = "LOCATION SALLE"
                                            Else
                                                TITRE = "HALL RENTING"
                                            End If

                                            TITRE_TYPE = "salle"

                                        End If

                                        'If Not Trim(typeClient) = "ENTREPRISE" Then
                                        If True Then

                                            typeClient = ""

                                            'insertion d'une ligne dans factures FACTURATION pour chaque client en chambre

                                            Dim CODE_FACTURE As String = Functions.GeneratingRandomCodeWithSpecifications("facture", "")
                                            Dim CODE_COMMANDE As String = ""
                                            Dim NUMERO_TABLE As String = ""
                                            Dim CODE_MODE_PAIEMENT As String = tableReservation.Rows(i)("NOM_CLIENT")
                                            Dim NUM_MOUVEMENT As String = ""
                                            DATE_FACTURE = GlobalVariable.DateDeTravail
                                            If facturationAnticipe Then
                                                DATE_FACTURE = GlobalVariable.DateDeTravail.AddDays(1)
                                            End If
                                            Dim CODE_COMMERCIAL As String = ""
                                            Dim AVANCE As Double = 0
                                            Dim RESTE_A_PAYER As Double = 0
                                            Dim DATE_PAIEMENT As Date
                                            Dim ETAT_FACTURE As Integer = 0

                                            Dim LIBELLE_FACTURE As String = TITRE & " (" & tableReservation.Rows(i)("NOM_CLIENT") & " / " & tableReservation.Rows(i)("CHAMBRE_ID") & ")"
                                            Dim MONTANT_TRANSPORT As Double = 0
                                            Dim MONTANT_REMISE As Double = 0
                                            Dim CODE_UTILISATEUR_ANNULE As String = ""
                                            Dim CODE_UTILISATEUR_VALIDE As String = ""
                                            Dim NOM_CLIENT_FACTURE As String = ""
                                            Dim MONTANT_AVANCE As Double = 0
                                            Dim CODE_CLIENT As String = tableReservation.Rows(i)("CLIENT_ID")
                                            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                                            CODE_RESERVATION = tableReservation.Rows(i)("CODE_RESERVATION")

                                            'Calcul du montant HT total du séjours
                                            'Dim MONTANT_HT As Double = Integer.Parse((tableReservation.Rows(i)("DATE_SORTIE") - tableReservation.Rows(i)("DATE_ENTTRE")).Days) * Double.Parse(tableReservation.Rows(i)("MONTANT_ACCORDE"))

                                            Dim montant As Double = 0

                                            'Insere uniquement le montant accordé
                                            'La facturation du logement d'un client ce fait au jour le jour donc le preleve le montant accorde et non le montant total du séjour
                                            Double.TryParse(tableReservation.Rows(i)("MONTANT_ACCORDE"), montant)

                                            Dim MONTANT_HT As Double = montant
                                            'Dim MONTANT_HT As Double = mainCouranteJournaliere.Rows(0)("SOUS_TOTAL1")
                                            Dim MONTANT_TTC As Double = MONTANT_HT
                                            'Dim MONTANT_TTC As Double = mainCouranteJournaliere.Rows(0)("SOUS_TOTAL1")
                                            Dim TAXE As Double = 0
                                            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                            Dim CODE_FACTURE_DEJEUNER As String = Functions.GeneratingRandomCodeWithSpecifications("facture", "")

                                            Dim Facture As New Facture()
                                            Dim OldReservationCode As String = ""

                                            'GESTION DU ROUTAGE LOGEMENT
                                            If Trim(tableReservation.Rows(i)("ROUTAGE")) = "OUI" Then

                                                OldReservationCode = CODE_RESERVATION
                                                Dim reservationDeRoutage As New Reservation()
                                                Dim codeDeReservationDeRoutage As DataTable = reservationDeRoutage.ChambreDeRoutage(tableReservation.Rows(i)("CHAMBRE_ROUTAGE"))

                                                If codeDeReservationDeRoutage.Rows.Count > 0 Then
                                                    If GlobalVariable.DateDeTravail <= codeDeReservationDeRoutage.Rows(0)("DATE_SORTIE") Then
                                                        CODE_RESERVATION = codeDeReservationDeRoutage.Rows(0)("CODE_RESERVATION")
                                                    End If
                                                End If

                                            End If

                                            Dim MONTANT_HT_DEJEUNER As Double = 0
                                            Dim MONTANT_TTC_DEJEUNER As Double = 0

                                            'CREATION DE LA FACTURE
                                            If Not Functions.entryCodeExists(CODE_FACTURE, "facture", "CODE_FACTURE") Then

                                                'GESTION DE L'HEBERGEMENT
                                                'If Facture.insertFacture(CODE_FACTURE, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT, TAXE, MONTANT_TTC, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, LIBELLE_FACTURE, MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE) Then

                                                If True Then
                                                    'GESION DEJENER INCLUS
                                                    'LE CHAMP SOUS_TOTAL1 DE LA MAINCOURANTE JOURNALIERE DETERMINE SI LE PETIT DEJEUNER EST INCLUS OU PAS
                                                    'Selection de la main courante specifique a la reservation
                                                    Dim mainCouranteJournalierePDJ As DataTable = Functions.GetAllElementsOnTwoConditions(tableReservation(i)("CODE_RESERVATION"), "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                                                    If mainCouranteJournalierePDJ.Rows.Count > 0 Then

                                                        If Not mainCouranteJournalierePDJ.Rows(0)("SOUS_TOTAL1") = 0 Then

                                                            'GESTION DU PETIT DEJEUNER INCLUS AVEC ROUTAGE)
                                                            If tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE") > 0 Then
                                                                Dim reservationDeRoutage As New Reservation()
                                                                Dim codeDeReservationDeRoutage As DataTable = reservationDeRoutage.ChambreDeRoutage(tableReservation.Rows(i)("CHAMBRE_ROUTAGE"))

                                                                If codeDeReservationDeRoutage.Rows.Count > 0 Then
                                                                    If GlobalVariable.DateDeTravail <= codeDeReservationDeRoutage.Rows(0)("DATE_SORTIE") Then
                                                                        CODE_RESERVATION = codeDeReservationDeRoutage.Rows(0)("CODE_RESERVATION")
                                                                    End If
                                                                End If

                                                                MONTANT_HT_DEJEUNER = tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE")
                                                                MONTANT_TTC_DEJEUNER = tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE")

                                                            Else
                                                                'GESTION DU PETIT DEJEUENER INCLUS SANS ROUTAGE
                                                                If Not OldReservationCode = "" Then
                                                                    CODE_RESERVATION = OldReservationCode
                                                                End If

                                                                MONTANT_HT_DEJEUNER = mainCouranteJournalierePDJ.Rows(0)("SOUS_TOTAL1")
                                                                MONTANT_TTC_DEJEUNER = mainCouranteJournalierePDJ.Rows(0)("SOUS_TOTAL1")

                                                            End If

                                                        End If

                                                        'If Facture.insertFacture(CODE_FACTURE_DEJEUNER, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT_DEJEUNER, TAXE, MONTANT_TTC_DEJEUNER, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, "Petit déjeuner ", MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE) Then

                                                        'End If

                                                    Else

                                                        'GESTION DU ROUTAGE PETIT DEJEUENER SI NON INCLUS

                                                        If tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE") > 0 Then

                                                            Dim reservationDeRoutage As New Reservation()
                                                            Dim codeDeReservationDeRoutage As DataTable = reservationDeRoutage.ChambreDeRoutage(tableReservation.Rows(i)("CHAMBRE_ROUTAGE"))

                                                            If codeDeReservationDeRoutage.Rows.Count > 0 Then

                                                                If GlobalVariable.DateDeTravail <= codeDeReservationDeRoutage.Rows(0)("DATE_SORTIE") Then
                                                                    CODE_RESERVATION = codeDeReservationDeRoutage.Rows(0)("CODE_RESERVATION")
                                                                End If

                                                                MONTANT_HT_DEJEUNER = tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE")
                                                                MONTANT_TTC_DEJEUNER = tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE")

                                                                'If Facture.insertFacture(CODE_FACTURE_DEJEUNER, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT_DEJEUNER, TAXE, MONTANT_TTC_DEJEUNER, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, "Petit déjeuner (" & tableReservation.Rows(i)("CHAMBRE_ID") & ")", MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE) Then

                                                                'End If

                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            End If

                                            'Gestion de la taxe de sejour collectee si elle est cochee la faire apparaitre dans les facturations

                                            Dim taxeSejourCollecte As DataTable = Functions.getElementByCode(tableReservation.Rows(i)("CODE_RESERVATION"), "taxe_sejour_collectee", "NUM_RESERVATION")

                                            'Insertion d'une ligne dans ligne_facture

                                            Dim CODE_MOUVEMENT As String = ""
                                            Dim CODE_CHAMBRE As String = tableReservation.Rows(i)("CHAMBRE_ID")
                                            Dim NOM_CLIENT As String = tableReservation.Rows(i)("NOM_CLIENT")
                                            Dim NUMERO_PIECE As String = ""
                                            Dim CODE_ARTICLE As String = ""
                                            Dim CODE_LOT As String = ""
                                            Dim QUANTITE As Double = 1
                                            Dim PRIX_UNITAIRE_TTC As Double = MONTANT_TTC
                                            Dim HEURE_FACTURE As DateTime = Date.Now().ToShortTimeString
                                            Dim DATE_OCCUPATION As Date
                                            Dim HEURE_OCCUPATION As DateTime = Date.Now().ToShortTimeString
                                            Dim TYPE_LIGNE_FACTURE As String = TITRE
                                            Dim NUMERO_SERIE As String = ""
                                            Dim NUMERO_ORDRE As Integer = 0
                                            Dim DESCRIPTION As String = ""
                                            Dim MONTANT_TAXE As Double = TAXE
                                            Dim NUMERO_SERIE_DEBUT As String = ""
                                            Dim NUMERO_SERIE_FIN As String = ""
                                            Dim CODE_MAGASIN As String = ""
                                            Dim FUSIONNEE As String = TITRE
                                            Dim MONTANT_PETIT_DEJEUNER As Double = 0

                                            If Functions.GetAllElementsOnTwoConditions(tableReservation.Rows(i)("CODE_RESERVATION"), "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE").Rows.Count > 0 Then
                                                MONTANT_PETIT_DEJEUNER = Functions.getElementByCode(tableReservation.Rows(i)("CODE_RESERVATION"), "main_courante_journaliere", "NUM_RESERVATION").Rows(0)("SOUS_TOTAL1")

                                            End If

                                            Dim ligneFacture As New LigneFacture()

                                            '-------------------------- LIGNE FACTURATION--------------------------

                                            'GESTION DES TAXES DE SEJOURS

                                            Dim factureHebergement As Boolean = True
                                            'ON NE DOIT PAS FACTURER EN ANTICIPATION LES RESERVATIONS QUI SERONT EN DEPART LE JOUR SUIVANT
                                            If facturationAnticipe Then

                                                If MENSUEL = 0 Then

                                                    If DATE_SORTIE.ToShortDateString = GlobalVariable.DateDeTravail.AddDays(1) Then
                                                        factureHebergement = False
                                                    End If

                                                Else
                                                    factureHebergement = False
                                                End If

                                            End If

                                            If taxeSejourCollecte.Rows.Count > 0 Then

                                                Dim CODE_FACTURE_TAXE As String = Functions.GeneratingRandomCode("facture", "")
                                                Dim CODE_TAXE_RESERVATION As String = tableReservation.Rows(i)("CODE_RESERVATION")
                                                Dim MONTANT_TAXE_SEJOUR As Double = taxeSejourCollecte.Rows(0)("TAXE_SEJOUR_COLLECTEE")
                                                Dim MONTANT_TAXE_SEJOUR_HT As Double = taxeSejourCollecte.Rows(0)("TAXE_SEJOUR_COLLECTEE")

                                                Dim TYPE_LIGNE_FACTURE_ As String = "" ''klg

                                                If factureHebergement Then

                                                    If GlobalVariable.actualLanguageValue = 1 Then
                                                        TYPE_LIGNE_FACTURE_ = "TAXE DE SEJOURS"
                                                        If ligneFacture.insertLigneFacture(CODE_FACTURE_TAXE, CODE_TAXE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_TAXE_SEJOUR, TAXE, QUANTITE, MONTANT_TAXE_SEJOUR, MONTANT_TAXE_SEJOUR, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, TYPE_LIGNE_FACTURE_ & " " & "(" + NOM_CLIENT + "/" + CODE_CHAMBRE + ") ", TYPE_LIGNE_FACTURE_, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, TYPE_LIGNE_FACTURE_) Then

                                                        End If
                                                    Else
                                                        TYPE_LIGNE_FACTURE_ = "TOURIST TAX"
                                                        If ligneFacture.insertLigneFacture(CODE_FACTURE_TAXE, CODE_TAXE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_TAXE_SEJOUR, TAXE, QUANTITE, MONTANT_TAXE_SEJOUR, MONTANT_TAXE_SEJOUR, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, TYPE_LIGNE_FACTURE_ & " " & "(" + NOM_CLIENT + "/" + CODE_CHAMBRE + ") ", TYPE_LIGNE_FACTURE_, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, TYPE_LIGNE_FACTURE_) Then

                                                        End If
                                                    End If

                                                End If

                                            End If

                                                'END GESTION DES TAXES DE SEJOURS

                                                'GESTION DU ROUTAGE LOGEMENT
                                                If tableReservation.Rows(i)("ROUTAGE") = "OUI" Then

                                                OldReservationCode = CODE_RESERVATION
                                                Dim reservationDeRoutage As New Reservation()
                                                Dim codeDeReservationDeRoutage As DataTable = reservationDeRoutage.ChambreDeRoutage(tableReservation.Rows(i)("CHAMBRE_ROUTAGE"))

                                                If codeDeReservationDeRoutage.Rows.Count > 0 Then
                                                    If GlobalVariable.DateDeTravail <= codeDeReservationDeRoutage.Rows(0)("DATE_SORTIE") Then
                                                        CODE_RESERVATION = codeDeReservationDeRoutage.Rows(0)("CODE_RESERVATION")
                                                    End If
                                                End If

                                            End If

                                            Dim ETAT_MAIN_COURANTE_TO_COPIE As Integer = 0


                                            If factureHebergement Then

                                                If ligneFacture.insertLigneFacture(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TITRE_TYPE) Then

                                                    'LE REGLEMENT EST AJOUTE EN CREDIT ET EN DEBIT POUR LA BALANCE
                                                    'GESTION DU PETIT DEJEUNER

                                                    Dim mainCouranteJournalierePDJ As DataTable = Functions.GetAllElementsOnTwoConditions(tableReservation(i)("CODE_RESERVATION"), "main_courante_journaliere", "NUM_RESERVATION", ETAT_MAIN_COURANTE_TO_COPIE, "ETAT_MAIN_COURANTE")

                                                    If mainCouranteJournalierePDJ.Rows.Count > 0 Then

                                                        If Not mainCouranteJournalierePDJ.Rows(0)("SOUS_TOTAL1") = 0 Then

                                                            'GESTION DU ROUTAGE PETIT DEJEUENER SI INCLUS
                                                            If tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE") > 0 Then
                                                                Dim reservationDeRoutage As New Reservation()
                                                                Dim codeDeReservationDeRoutage As DataTable = reservationDeRoutage.ChambreDeRoutage(tableReservation.Rows(i)("CHAMBRE_ROUTAGE"))

                                                                If codeDeReservationDeRoutage.Rows.Count > 0 Then
                                                                    If GlobalVariable.DateDeTravail <= codeDeReservationDeRoutage.Rows(0)("DATE_SORTIE") Then
                                                                        CODE_RESERVATION = codeDeReservationDeRoutage.Rows(0)("CODE_RESERVATION")
                                                                    End If
                                                                End If

                                                                MONTANT_PETIT_DEJEUNER = tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE")

                                                                If ligneFacture.insertLigneFacture(CODE_FACTURE_DEJEUNER, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_PETIT_DEJEUNER, TAXE, 1, MONTANT_PETIT_DEJEUNER, MONTANT_PETIT_DEJEUNER, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, "PETIT DEJEUNER (" & tableReservation.Rows(i)("NOM_CLIENT") & "/" & CODE_CHAMBRE & ")", TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, "PETIT DEJEUNER") Then

                                                                End If
                                                            Else

                                                                If Not OldReservationCode = "" Then
                                                                    CODE_RESERVATION = OldReservationCode
                                                                End If

                                                                MONTANT_PETIT_DEJEUNER = mainCouranteJournalierePDJ.Rows(0)("SOUS_TOTAL1")

                                                            End If

                                                        Else

                                                            If tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE") > 0 Then

                                                                Dim reservationDeRoutage As New Reservation()
                                                                Dim codeDeReservationDeRoutage As DataTable = reservationDeRoutage.ChambreDeRoutage(tableReservation.Rows(i)("CHAMBRE_ROUTAGE"))

                                                                If codeDeReservationDeRoutage.Rows.Count > 0 Then
                                                                    If GlobalVariable.DateDeTravail <= codeDeReservationDeRoutage.Rows(0)("DATE_SORTIE") Then
                                                                        CODE_RESERVATION = codeDeReservationDeRoutage.Rows(0)("CODE_RESERVATION")
                                                                    End If
                                                                End If

                                                                MONTANT_PETIT_DEJEUNER = tableReservation.Rows(i)("PETIT_DEJEUNER_ROUTAGE")

                                                                If ligneFacture.insertLigneFacture(CODE_FACTURE_DEJEUNER, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_PETIT_DEJEUNER, TAXE, 1, MONTANT_PETIT_DEJEUNER, MONTANT_PETIT_DEJEUNER, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, "PETIT DEJEUNER (" & tableReservation.Rows(i)("NOM_CLIENT") & "/" & CODE_CHAMBRE & ")", TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TITRE_TYPE) Then

                                                                End If

                                                            Else

                                                                'If Not OldReservationCode = "" Then
                                                                'CODE_RESERVATION = OldReservationCode
                                                                'End If

                                                            End If


                                                        End If

                                                    End If

                                                End If

                                            End If


                                            'MISE A JOURS DU SOLDE DU CLIENT
                                            Reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))

                                            '------------------------------------------------------------------------------
                                            'chaque main courante étant associé a une reservation on met a jour chaque mise a jour associé à une reservation

                                            'Mise à jours de mains courantes
                                            Dim mainCourantes As New MainCourantes()

                                            '----------- MAIN COURANTES ------------------------------
                                            Dim CODE_MAIN_COURANTE As DataTable = Functions.getElementByCode(tableReservation(i)("CODE_RESERVATION"), "main_courante", "CODE_RESERVATION")

                                            Dim ETAT_MAIN_COURANTE As Integer = 1

                                            If CODE_MAIN_COURANTE.Rows.Count > 0 Then

                                                Dim updateQueryMainCourante As String = "UPDATE `main_courante` Set `ETAT_MAIN_COURANTE` = @value1 WHERE CODE_MAIN_COURANTE = @CODE_MAIN_COURANTE"

                                                Dim commandMainCourante As New MySqlCommand(updateQueryMainCourante, GlobalVariable.connect)

                                                commandMainCourante.Parameters.Add("@value1", MySqlDbType.Int32).Value = ETAT_MAIN_COURANTE
                                                commandMainCourante.Parameters.Add("@CODE_MAIN_COURANTE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE.Rows(0)("CODE_MAIN_COURANTE")

                                                If (commandMainCourante.ExecuteNonQuery() = 1) Then

                                                End If

                                                '----------- MAIN COURANTE GENERALE ------------------------------

                                            End If

                                            Dim CODE_MAIN_COURANTE_GENERALE As DataTable = Functions.getElementByCode(tableReservation(i)("CODE_RESERVATION"), "main_courante_generale", "NUM_RESERVATION")

                                            If CODE_MAIN_COURANTE_GENERALE.Rows.Count > 0 Then

                                                Dim updateQueryMainCouranteGenerale As String = "UPDATE `main_courante_generale` Set `ETAT_MAIN_COURANTE` = @value1 WHERE CODE_MAIN_COURANTE_GENERALE = @CODE_MAIN_COURANTE_GENERALE"

                                                Dim commandMainCouranteGenerale As New MySqlCommand(updateQueryMainCouranteGenerale, GlobalVariable.connect)

                                                commandMainCouranteGenerale.Parameters.Add("@value1", MySqlDbType.Int32).Value = ETAT_MAIN_COURANTE
                                                commandMainCouranteGenerale.Parameters.Add("@CODE_MAIN_COURANTE_GENERALE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_GENERALE.Rows(0)("CODE_MAIN_COURANTE_GENERALE")

                                                'Opening the connection
                                                'connect.openConnection()

                                                'Excuting the command and testing if everything went on well
                                                If (commandMainCouranteGenerale.ExecuteNonQuery() = 1) Then

                                                End If

                                                'connect.closeConnection()

                                            End If

                                            '----------- MAIN COURANTE JOURNALIERE -------------------------------------------------------------------------------------------
                                            'Dim ETAT_MAIN_COURANTE_TO_COPIE As Integer = 0
                                            'ON DOIT PRENDRE UNE MAIN COURANTE D'UN CERTAIN ETAT
                                            Dim MAIN_COURANTE_JOURNALIERE As DataTable = Functions.GetAllElementsOnTwoConditions(tableReservation(i)("CODE_RESERVATION"), "main_courante_journaliere", "NUM_RESERVATION", ETAT_MAIN_COURANTE_TO_COPIE, "ETAT_MAIN_COURANTE") 'Copie de la main courante a reproduire

                                            '---- COPIE DE LA MAIN COURANTE EN COURS POUR AVOIR DEUX INSTANCE A FIN DE L'UTILISER DANS LA MAIN COURANTE JOURNALIERE ET ANCIENNE-----

                                            If MAIN_COURANTE_JOURNALIERE.Rows.Count > 0 Then

                                                Dim mainCouranteJournaliereColler As New Reservation()

                                                '1- LA FONCTION SI DESSOUS CREEE UNE COPIE DE LA MAINCOURANT ACTUEL 
                                                '2- CHANGE LE CODE DE LA NOUVELLE MAINCOURANTE (CODE_MAIN_COURANTE_JOURNALIERE)
                                                '2- PUIS MET A JOURS L'ETAT DE L'ANCIENNE MAIN_COURANTE

                                                'MIGRATION - COPIER - COLLER
                                                mainCouranteJournaliereColler.insertMainCouranteJournaliere(MAIN_COURANTE_JOURNALIERE) 'COPIE - COLLER DE LA MAIN COURANTE


                                                '-------------------------- UPDATE ROOM --------------------------------

                                                Dim updateQuery1 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE`=@ETAT_CHAMBRE , ETAT_CHAMBRE_NOTE =@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@code"

                                                Dim command1 As New MySqlCommand(updateQuery1, GlobalVariable.connect)

                                                command1.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
                                                command1.Parameters.Add("@code", MySqlDbType.VarChar).Value = tableReservation(i)("CHAMBRE_ID")
                                                command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.occupee_sale

                                                'Opening the connection
                                                'connect.openConnection()

                                                'Excuting the command and testing if everything went on well
                                                If (command1.ExecuteNonQuery() = 1) Then
                                                    'connect.closeConnection()
                                                End If


                                                Dim updateQueryMainCouranteJournaliere As String = "UPDATE `main_courante_journaliere` SET `ETAT_MAIN_COURANTE` = @value1 WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

                                                Dim commandMainCouranteJournaliere As New MySqlCommand(updateQueryMainCouranteJournaliere, GlobalVariable.connect)

                                                commandMainCouranteJournaliere.Parameters.Add("@value1", MySqlDbType.Int32).Value = ETAT_MAIN_COURANTE
                                                commandMainCouranteJournaliere.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = MAIN_COURANTE_JOURNALIERE.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

                                                'Opening the connection
                                                'connect.openConnection()

                                                'Excuting the command and testing if everything went on well
                                                If (commandMainCouranteJournaliere.ExecuteNonQuery() = 1) Then
                                                    'MessageBox.Show("main journaliere du :" & DateDeTravail)
                                                End If

                                                'GunaCircleProgressBar1.Value = GunaCircleProgressBar1.Value + 1

                                                'connect.closeConnection()

                                            End If
                                            '-----------------------------------------------------------------------------------

                                        End If
                                        '----------------------------------------------------

                                        If MENSUEL = 1 Then
                                            If Not GlobalVariable.DateDeTravail = DATE_SORTIE Then
                                                'Functions.suppressionDesLignesDeFacturationPourLaMensualite(CODE_RESERVATION, DATE_FACTURE)
                                            End If
                                        End If

                                    Next

                                    'Gestion des No Show 

                                    '-------------- No Show checkout: reservation dont ont n'a pas fait le checkout. donc la date de sortie et la date de cloture
                                    GunaCircleProgressBar1.Value = GunaCircleProgressBar1.Value + 1

                                    'MessageBox.Show("Vous avez clôturez avec succès la journée de: " & DateDeTravail, "Confirmation de clôture", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        MessageBox.Show("Aucune réservation à clôturer : " & DateDeTravail, "Confirmation de clôture du " & DateDeTravail, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    Else
                                        MessageBox.Show("No customer to Charge : " & DateDeTravail, "Night Audit confirmation of " & DateDeTravail, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    End If


                                End If

                                'GESTION DES NO SHOW 
                                DateDeTravail = GlobalVariable.DateDeTravail
                                Dim DateDebut1 As Date = DateDeTravail.ToString("yyyy-MM-dd")

                                If GunaCheckBoxReservationNonArrivee.Checked Then

                                    Dim query1 As String = "SELECT * FROM reservation WHERE DATE_ENTTRE <= '" & DateDebut1.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE"

                                    Dim commandReservation1 As New MySqlCommand(query1, GlobalVariable.connect)
                                    commandReservation1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

                                    Dim adapterReservation1 As New MySqlDataAdapter(commandReservation1)
                                    Dim tableReservation1 As New DataTable()
                                    adapterReservation1.Fill(tableReservation1)

                                    If (tableReservation1.Rows.Count > 0) Then

                                        For j = 0 To tableReservation1.Rows.Count - 1
                                            'Déplacement de reservation vers la table reserve_temp
                                            Dim noShowCheckIn As String = "INSERT INTO `reserve_temp`(`CODE_RESERVATION`, `CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `CHECKIN`, `TYPE`, `PETIT_DEJEUNER`, `SOLDE_RESERVATION`, `SOURCE_RESERVATION` ,`PETIT_DEJEUNER_ROUTAGE` , `CHAMBRE_ROUTAGE`,`VENANT_DE`,`SE_RENDANT_A`,`RAISON`,`ROUTAGE`,`ETAT_NOTE_RESERVATION`,`DEPOT_DE_GARANTIE`, `DAY_USE`, `TYPE_CHAMBRE`, `BC_ENTREPRISE`) SELECT `CODE_RESERVATION`, `CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `CHECKIN`, `TYPE`, `PETIT_DEJEUNER`, `SOLDE_RESERVATION`,`SOURCE_RESERVATION` ,`PETIT_DEJEUNER_ROUTAGE` ,`CHAMBRE_ROUTAGE`,`VENANT_DE`,`SE_RENDANT_A`,`RAISON`,`ROUTAGE`, `ETAT_NOTE_RESERVATION`,`DEPOT_DE_GARANTIE`, `DAY_USE`, `TYPE_CHAMBRE`, `BC_ENTREPRISE` FROM reservation WHERE CODE_RESERVATION = @CODE_RESERVATION AND ETAT_RESERVATION = 0 AND DATE_ENTTRE <= '" & DateDebut1.ToString("yyyy-MM-dd") & "'"

                                            Dim commandNoShowCheckIn As New MySqlCommand(noShowCheckIn, GlobalVariable.connect)

                                            commandNoShowCheckIn.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = tableReservation1(j)("CODE_RESERVATION")
                                            commandNoShowCheckIn.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = DateDebut1.ToString("yyyy-MM-dd")

                                            'Opening the connection
                                            'connect.openConnection()

                                            'Excuting the command and testing if everything went on well
                                            If (commandNoShowCheckIn.ExecuteNonQuery() = 1) Then
                                                Dim updateQuery1 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE`=@ETAT_CHAMBRE , ETAT_CHAMBRE_NOTE =@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@code"

                                                Dim command1 As New MySqlCommand(updateQuery1, GlobalVariable.connect)

                                                command1.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
                                                command1.Parameters.Add("@code", MySqlDbType.VarChar).Value = tableReservation1(j)("CHAMBRE_ID")
                                                command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

                                                If (command1.ExecuteNonQuery() = 1) Then
                                                    'connect.closeConnection()
                                                End If

                                                Reservation.updateSoldeReservation(tableReservation1(j)("CODE_RESERVATION"), "reservation", Functions.SituationDeReservation(tableReservation1(j)("CODE_RESERVATION")))

                                                Functions.DeleteElementByCode(tableReservation1(j)("CODE_RESERVATION"), "reservation", "CODE_RESERVATION")
                                            Else
                                                'MessageBox.Show("OUps 2")
                                            End If

                                        Next
                                    End If

                                End If

                            Else

                                'miseAjourDelaMainCouranteDuBarRestaurant()

                                'sendRapportApresCloture = True

                                'gestionDeLicenceDeHotelSoft()

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MessageBox.Show("Aucune réservation à clôturer en date du : " & GlobalVariable.DateDeTravail & " ", "Clôture", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Else
                                    MessageBox.Show("No accommodation to bill for the : " & GlobalVariable.DateDeTravail & " ", "Night Audit", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                End If


                            End If

                            'CLOTURE DE LA MAIN_COURANTE_AUTRES
                            miseAjourDelaMainCouranteDuBarRestaurant()

                            GlobalVariable.upddateStatData = True

                            'On inscrit la nouvelle date de travail
                            Functions.cloturer(GlobalVariable.DateDeTravail.AddDays(1))
                            'Puis on rafraishi la date de travail
                            GlobalVariable.DateDeTravail = Functions.ObtenirDateDeTravail()

                            MainWindow.GunaLabel38.Text = GlobalVariable.DateDeTravail.ToShortDateString()

                            changementEtatDesAnciennesMainCourantes(dateDeTravailAvantCloture)

                            'miseAjoursDesLignesDeChargeDeHebergementPasAssocieAUneFacture(dateDeTravailAvantCloture)

                            If Not Trim(GlobalVariable.gestionDeCaisseAvantCloture) = "" Then

                                'C'EST APRES TOUS LE PROCESSUS DE CLOTURE QUE LA VARIABLE CI-DESSOUS RECUPERE LA VALEUR NULL
                                GlobalVariable.gestionDeCaisseAvantCloture = ""

                            End If

                            sendRapportApresCloture = True

                            '------------------------- VIDAGE DES TABLES TEMPORAIRE ------------------------------------

                            Dim tableName As String = "ligne_facture_temp"
                            Functions.deleteAll(tableName)

                            tableName = "bordereau_ligne_temp"
                            Functions.deleteAll(tableName)

                            tableName = "print_facture_reglement_temp"
                            Functions.deleteAll(tableName)

                            '-------------------- MISE A JOURS DES CHAMPS TYPE_LIGNE_FACTURE POUR HEBERGEMENT ET TAXE DE SEJOURS
                            'REQUETTES DE REPARATION
                            Functions.miseAjoursHebergementetTaxeDeSejour()

                            '--------------------- REINITIALISATION DES VARIABLES  ----------------------------
                            miseAjoursDesLignesDeChargeDeHebergementPasAssocieAUneFacture(dateDeTravailAvantCloture)

                            changementEtatDesAnciennesMainCourantes(dateDeTravailAvantCloture)

                            '---------------------------------------------

                            'MainWindow.MainWindowManualActivation()
                            'MainWindow.TabControlHbergement.SelectedIndex = 0

                            GunaCircleProgressBar1.Value = 100

                            GunaLabelTemps.Text = GlobalVariable.DateDeTravail.AddDays(-1)

                            GunaButtonTerminer.Visible = True
                            GunaButtonAnnuler.Visible = False
                            GunaButtonCloturer.Visible = False
                            GunaImageButtonFermer.Visible = False

                            MainWindow.ReinitialisationDesDates()

                            Me.Activate()

                            'gestionDeLicenceDeHotelSoft()

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Vous avez clôturez avec succès la journée du : " & DateDeTravail, "Confirmation de clôture", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else
                                MessageBox.Show("You have successfully closed the : " & DateDeTravail, "Night Audit confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If


                        End If

                    Else

                        Dim pluriel As String = ""

                        If tableDepart.Rows.Count > 1 Then
                            pluriel = "s"
                        End If

                        'ON A DES RESSERVATIONS AVEC DES SOLDE NEGATIFS

                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Vous avez " & tableDepart.Rows.Count & " reservation" & pluriel & " dont les départs n'ont pas étés éffectués rendant la clôture impossible !!", "Clôture impossible", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else
                            MessageBox.Show("You have " & tableDepart.Rows.Count & " customer" & pluriel & " that you have to check out. So impossible to close the date  !!", "Night Audit impossible", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    End If

                End If

            End If

            Me.Cursor = Cursors.Default

            If sendRapportApresCloture Then

                envoieDesRapportsFinancier(CDate(dateDeTravailAvantCloture).ToShortDateString)

                'envoieDuTitre(CDate(dateDeTravailAvantCloture).ToShortDateString)

            End If

        End If

    End Sub

    'ON SE RASSURE QUE TOUTES LES MAINS COURANTES SONT A ZERO POUR UN BON TRAITEMENT DES DONNEES

    Public Sub changementEtatDesAnciennesMainCourantes(ByVal dateDeTravailAvantCloture As Date)

        Dim reservation As New Reservation()

        'Dim query1 As String = "SELECT * FROM main_courante_journaliere WHERE DATE_MAIN_COURANTE >= '" & dateDeTravailAvantCloture.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE <= '" & dateDeTravailAvantCloture.ToString("yyyy-MM-dd") & "' AND ETAT_MAIN_COURANTE=@ETAT_MAIN_COURANTE"
        Dim query1 As String = "SELECT * FROM main_courante_journaliere WHERE DATE_MAIN_COURANTE <= '" & dateDeTravailAvantCloture.ToString("yyyy-MM-dd") & "' AND ETAT_MAIN_COURANTE=@ETAT_MAIN_COURANTE"

        Dim ETAT_MAIN_COURANTE As Integer = 0
        Dim commandMain As New MySqlCommand(query1, GlobalVariable.connect)

        commandMain.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int64).Value = ETAT_MAIN_COURANTE

        Dim adapter As New MySqlDataAdapter(commandMain)
        Dim main_courante_journaliere As New DataTable()
        adapter.Fill(main_courante_journaliere)

        Dim CODE_MAIN_COURANTE As String = ""

        If main_courante_journaliere.Rows.Count > 0 Then

            ETAT_MAIN_COURANTE = 1
            For j = 0 To main_courante_journaliere.Rows.Count - 1
                CODE_MAIN_COURANTE = main_courante_journaliere.Rows(j)("CODE_MAIN_COURANTE_JOURNALIERE")
                reservation.miseAjourEtatMainCourante(CODE_MAIN_COURANTE, ETAT_MAIN_COURANTE)
            Next

        End If

    End Sub

    'BACKGROUND WORKER
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For i = 0 To numberOfElementsToTreat
            BackgroundWorker1.ReportProgress(i)
            Threading.Thread.Sleep(300)
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        GunaCircleProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'MessageBox.Show("Yes donne ", "Clôture", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If fermerLogiciel = True Then

        End If

    End Sub

    Public Sub miseAjourDelaMainCouranteDuBarRestaurant()

        Dim ETAT_MAIN_COURANTE As Integer = 0

        Dim mainCouranteDuJours As DataTable = Functions.getElementByOnCodeAndDate(ETAT_MAIN_COURANTE, "main_courante_autres", "ETAT_MAIN_COURANTE", GlobalVariable.DateDeTravail, "main_courante_autres")

        If mainCouranteDuJours.Rows.Count > 0 Then

            Dim updateQuery1 As String = "UPDATE `main_courante_autres` SET `ETAT_MAIN_COURANTE`=@ETAT_MAIN_COURANTE WHERE CODE_MAIN_COURANTE_JOURNALIERE=@CODE_MAIN_COURANTE_JOURNALIERE"

            Dim command1 As New MySqlCommand(updateQuery1, GlobalVariable.connect)

            command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 1
            command1.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = mainCouranteDuJours(0)("CODE_MAIN_COURANTE_JOURNALIERE")

            command1.ExecuteNonQuery()

        End If

    End Sub

    Public Sub miseAjoursDesLignesDeChargeDeHebergementPasAssocieAUneFacture(ByVal dateDeTravailAvantCloture As Date)

        'SELECTION DE TOUTES LES CHARGES D'HEBERGEMENT DONT L'ETAT_FACTURE EST PASSE A 1 MAIS IL N'EXISTE PAS DE FACTURE 
        'DONC L'ETAT A CHANGE SANS QU'ON EST CLOTURE

        Dim HEBERGEMENT As String = "HEBERGEMENT"

        'SELECTIONS DES CHARGES DES HERBERGEMENT DES EN CHAMBRES

        Dim queryDepart As String = "SELECT ETAT_FACTURE, ID_LIGNE_FACTURE, CODE_FACTURE, reserve_conf.CODE_RESERVATION FROM reserve_conf, ligne_facture WHERE DATE_ENTTRE <= '" & dateDeTravailAvantCloture.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & dateDeTravailAvantCloture.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND reserve_conf.TYPE=@TYPE AND reserve_conf.CODE_RESERVATION = ligne_facture.CODE_RESERVATION AND ETAT_FACTURE=@ETAT_FACTURE AND LIBELLE_FACTURE LIKE '%" & HEBERGEMENT & "%' ORDER BY ID_RESERVATION DESC"

        Dim command As New MySqlCommand(queryDepart, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim ETAT_FACTURE As Integer = 0

        If table.Rows.Count > 0 Then
            'ON VERIFIE SI LA LIGNE FACTURE DONT  L'ETAT EST A 1 EST ASSOCIE A UNE FACTURE
            Dim CODE_FACTURE As String = ""

            For i = 0 To table.Rows.Count - 1

                CODE_FACTURE = table.Rows(i)("CODE_FACTURE")

                Dim facture As DataTable = Functions.getElementByCode(CODE_FACTURE, "facture", "CODE_FACTURE")

                If facture.Rows.Count <= 0 Then
                    'ETAT EST A 1 MAIS ELLE N'ESTT PAS ASSOCIE A UNE FACTURE DONC ON DOIT CHANGER L'ETAT A 0

                    Dim updateQuery1 As String = "UPDATE `ligne_facture` SET `ETAT_FACTURE`=@ETAT_FACTURE WHERE ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"

                    Dim command1 As New MySqlCommand(updateQuery1, GlobalVariable.connect)

                    command1.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int32).Value = 0
                    command1.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = table.Rows(i)("ID_LIGNE_FACTURE")

                    command1.ExecuteNonQuery()

                    'MISE AJOURS DU SOLDE DE LA RESERVATION 
                    Dim CODE_RESERVATION = table.Rows(i)("CODE_RESERVATION")
                    Dim reservation As New Reservation()

                    reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))

                End If

            Next

        End If

    End Sub

    Dim sec1 As Integer = 0
    Dim sec2 As Integer = 0
    Dim sec3 As Integer = 0
    Dim sec4 As Integer = 0
    Dim sec5 As Integer = 0


    Dim web As New WebBrowser
    Dim web1 As New WebBrowser
    Dim web2 As New WebBrowser
    Dim web3 As New WebBrowser
    Dim web4 As New WebBrowser
    Dim web5 As New WebBrowser

    Dim whatsAppMessage As String = ""


    Public Sub envoieDesRapportsFinancier(ByVal DateDuRapport As Date)

        Dim TOTAL_HEBERGEMENT_CLOTURE As Double = 0
        Dim TOTAL_RESTAURANT_CLOTURE As Double = 0
        Dim TOTAL_BAR_CLOTURE As Double = 0
        Dim TOTAL_SORTIE_CLOTURE As Double = 0
        Dim TOTAL_SORTIE_PETITE_CAISSE As Double = 0
        Dim TOTAL_ENCAISSEMENT_CLOTURE As Double = 0
        Dim TOTAL_AUTRES_CLOTURE As Double = 0

        '1/- HEBERGEMENT
        '2/- BAR
        '3/- RESTAURANT
        '4/- AUTRES
        '5/- SORTIE DE FONDS

        Dim DateDebut As Date = DateDuRapport.ToString("yyyy-MM-dd")
        Dim DateFin As Date = DateDuRapport.ToString("yyyy-MM-dd")

        'RESERVATION 

        Dim getUserQuery1 = "SELECT CHAMBRE_ID As 'CHAMBRE', DAY_USE, NUM_RESERVATION, main_courante_journaliere.NOM_CLIENT As 'NOM & PRENOM', DATE_ENTTRE As 'DATE ARRIVEE', DATE_SORTIE As 'DATE DEPART', NB_PERSONNES As 'NBRE DE PAX', PDJ, DEJEUNER, DINER,CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_journaliere.NUM_RESERVATION As 'RESERVATION', main_courante_journaliere.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_journaliere.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_journaliere.SERVICES AS 'SERVICES', main_courante_journaliere.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_journaliere.BOUTIQE AS 'BOUTIQUE', main_courante_journaliere.CYBERCAFE As 'BUSINESS CENTER', main_courante_journaliere.SPORTS As 'SPORTS' , main_courante_journaliere.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_journaliere.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_journaliere.BLANCHISSERIE As BLANCHISSERIE, main_courante_journaliere.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER', HEURE_ENTREE, HEURE_SORTIE,TAUX_OCCUPATION_PCT As 'TAXE DE SEJOUR' FROM main_Courante_journaliere, reserve_conf WHERE DATE_MAIN_COURANTE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND main_Courante_journaliere.NUM_RESERVATION = reserve_conf.CODE_RESERVATION ORDER BY CODE_CHAMBRE ASC"

        Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)

        Dim adapter1 As New MySqlDataAdapter(command1)

        Dim table As New DataTable()

        adapter1.Fill(table)

        '-------------------------------------------------------- MAINCOURANTE ----------------------------------------------

        Dim getUserQuery01 = "SELECT CODE_CHAMBRE As 'CHAMBRE', NUM_RESERVATION, main_courante_autres.NOM_CLIENT As 'NOM & PRENOM', PDJ, DEJEUNER, DINER, CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_autres.NUM_RESERVATION As 'RESERVATION', main_courante_autres.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_autres.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_autres.SERVICES AS 'SERVICES', main_courante_autres.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_autres.BOUTIQE AS 'BOUTIQUE', main_courante_autres.CYBERCAFE As 'BUSINESS CENTER', main_courante_autres.SPORTS As 'SPORTS' , main_courante_autres.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_autres.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_autres.BLANCHISSERIE As BLANCHISSERIE, main_courante_autres.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER' FROM main_Courante_autres WHERE DATE_MAIN_COURANTE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY main_courante_autres.NOM_CLIENT ASC"

        Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

        command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.DocumentToGenerate

        Dim adapter01 As New MySqlDataAdapter(command01)

        Dim table0 As New DataTable()

        adapter01.Fill(table0)

        '--------------------------------------------------------------------------------------------------------------------

        If table.Rows.Count > 0 Then

            '------------------ FAILED COLUMNS -----------------

            For i = 0 To table.Rows.Count - 1

                Dim NUMERO_RESERVATION As String = table.Rows(i)("NUM_RESERVATION")

                '----------------------------------------------- TAXE DE SEJOURS ------------------------------------------------------

                '-----------------------------------------------END TAXE DE SEJOURS ---------------------------------------------------

                Dim RESTAURANT As Double = table.Rows(i)("PDJ") + table.Rows(i)("DEJEUNER") + table.Rows(i)("DINER")
                Dim BAR As Double = table.Rows(i)("CAFE") + table.Rows(i)("CAVE") + table.Rows(i)("DIVERS")

                'Dim RESTAURANT As Double = table.Rows(i)("CAVE") + table.Rows(i)("DIVERS") + table.Rows(i)("CAFE")

                Dim AUTRES_VENTE As Double = table.Rows(i)("SERVICES") + table.Rows(i)("SALON DE BEAUTE") + table.Rows(i)("BOUTIQUE") + table.Rows(i)("BUSINESS CENTER") + table.Rows(i)("SPORTS") + table.Rows(i)("LOISIRS") + table.Rows(i)("JOURNAUX") + table.Rows(i)("AUTRES")

                Dim TOTAL_RECETTE As Double = 0

                Dim nuits As Integer = 0

                Dim arrivee As Date = CDate(table.Rows(i)("DATE ARRIVEE")).ToShortDateString
                Dim depart As Date = CDate(table.Rows(i)("DATE DEPART")).ToShortDateString

                Dim dateTravail As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
                Dim dateMainCourante As Date = DateDuRapport

                'Dim HEBERGEMENT As Double = table.Rows(i)("HEBERGEMENT")
                Dim taxeDeSejours As Double = table.Rows(i)("TAXE DE SEJOUR")


                nuits = CType((depart - arrivee).TotalDays, Int64)

                Dim PAX As Integer = table.Rows(i)("NBRE DE PAX")

                If PAX <= 0 Then
                    PAX = 1
                End If

                'ON DOIT MULTIPLIER LE DAY USE PAR LE NOMBRE D'HEURE
                If table.Rows(i)("DAY_USE") = 1 Then

                    Dim DEBUT As Date = CDate(table.Rows(i)("HEURE_ENTREE")).ToShortTimeString
                    Dim FIN As Date = CDate(table.Rows(i)("HEURE_SORTIE")).ToShortTimeString

                    Dim NombreHeure As Integer = 0

                    NombreHeure = CType((FIN - DEBUT).TotalHours, Int32)

                End If

                If AUTRES_VENTE < 0 Then
                    AUTRES_VENTE = 0
                End If

                Dim TOTAL_ENCAISSEMENT As Double = table.Rows(i)("ESPECES") + table.Rows(i)("CARTE CREDIT") + table.Rows(i)("MOBILE MONEY")

                TOTAL_RESTAURANT_CLOTURE += RESTAURANT
                TOTAL_BAR_CLOTURE += BAR

                TOTAL_ENCAISSEMENT_CLOTURE += table.Rows(i)("ESPECES") + table.Rows(i)("CARTE CREDIT") + table.Rows(i)("MOBILE MONEY")
                TOTAL_AUTRES_CLOTURE += table.Rows(i)("BLANCHISSERIE") + AUTRES_VENTE

            Next

            'MAINcourantes comptoires
            For i = 0 To table0.Rows.Count - 1

                Dim RESTAURANT As Double = table0.Rows(i)("PDJ") + table0.Rows(i)("DEJEUNER") + table0.Rows(i)("DINER")
                Dim BAR As Double = table0.Rows(i)("CAFE") + table0.Rows(i)("CAVE") + table0.Rows(i)("DIVERS")

                'Dim RESTAURANT As Double = table0.Rows(i)("CAVE") + table0.Rows(i)("DIVERS") + table0.Rows(i)("CAFE")

                Dim AUTRES_VENTE As Double = table0.Rows(i)("SERVICES") + table0.Rows(i)("SALON DE BEAUTE") + table0.Rows(i)("BOUTIQUE") + table0.Rows(i)("BUSINESS CENTER") + table0.Rows(i)("SPORTS") + table0.Rows(i)("LOISIRS") + table0.Rows(i)("JOURNAUX") + table0.Rows(i)("AUTRES")

                Dim TOTAL_ENCAISSEMENT As Double = table0.Rows(i)("ESPECES") + table0.Rows(i)("CARTE CREDIT") + table0.Rows(i)("MOBILE MONEY")

                TOTAL_RESTAURANT_CLOTURE += RESTAURANT
                TOTAL_BAR_CLOTURE += BAR
                TOTAL_ENCAISSEMENT_CLOTURE += TOTAL_ENCAISSEMENT
                TOTAL_AUTRES_CLOTURE += table0.Rows(i)("BLANCHISSERIE") + AUTRES_VENTE

            Next

            TOTAL_SORTIE_CLOTURE = SituationDeCaisseCloture(DateDuRapport)

        End If

        'TOTAL DES SORTIES DE LA PETITE CAISSE

        Dim getUserQuery02 = "SELECT * FROM petite_caisse_ligne WHERE DATE_REGLEMENT >= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' " '"

        Dim command02 As New MySqlCommand(getUserQuery02, GlobalVariable.connect)

        Dim adapter02 As New MySqlDataAdapter(command02)

        Dim table02 As New DataTable()

        adapter02.Fill(table02)

        If table02.Rows.Count > 0 Then

            For i = 0 To table02.Rows.Count - 1
                TOTAL_SORTIE_PETITE_CAISSE += table02.Rows(i)("MONTANT_SORTIE")
            Next

        End If

        Dim SERVICE As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            SERVICE = "HEBERGEMENT"
        Else
            SERVICE = "ACCOMMODATION"
        End If

        TOTAL_HEBERGEMENT_CLOTURE = Functions.totalDunServiceUnCertainJour(DateDuRapport, SERVICE)

        'ENVOIE DU MESSAGE WHATSAPP APRES CLOTURE

        If GlobalVariable.actualLanguageValue = 1 Then
            whatsAppMessage = "RAPPORT JOUNALIER DU " & DateDuRapport & Chr(13) & " -/ HEBERGEMENT : " & Format(TOTAL_HEBERGEMENT_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ BAR : " & Format(TOTAL_BAR_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ RESTAURANT : " & Format(TOTAL_RESTAURANT_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ AUTRES : " & Format(TOTAL_AUTRES_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ SORTIES DE FONDS CAISSE PRINCIPALE : " & Format(TOTAL_SORTIE_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ SORTIES DE FONDS PETITE CAISSE : " & Format(TOTAL_SORTIE_PETITE_CAISSE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13)
        Else
            whatsAppMessage = "DAILY REPORT OF " & DateDuRapport & Chr(13) & " -/ ACCOMMODATION : " & Format(TOTAL_HEBERGEMENT_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ BAR : " & Format(TOTAL_BAR_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ RESTAURANT : " & Format(TOTAL_RESTAURANT_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ OTHERS : " & Format(TOTAL_AUTRES_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ FUNDS OUT FROM MAIN CASHIER : " & Format(TOTAL_SORTIE_CLOTURE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " -/ FONDS OUT FROM PETTY CASH : " & Format(TOTAL_SORTIE_PETITE_CAISSE, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13)
        End If

        Dim mobile_number As String = MainWindow.listeOfTelephoneNumbers()

        If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

            Dim args As ArgumentType = New ArgumentType()

            args.whatsAppMessage = whatsAppMessage
            args.mobile_number = mobile_number

            'Functions.ultrMessageSimpleText(whatsAppMessage, mobile_number)

            args.action = 0

            '- B2 : RAPPORT FINANCIER

            backGroundWorkerToCall(args)

            'envoieTitre(DateDuRapport)

        End If

    End Sub

    Public Function envoieTitre(ByVal DateDuRapport As Date)

        Dim tireDocument As String = ""
        Dim titreFichier As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            titreFichier = "MAIN COURANTE JOURNALIERE"
            tireDocument = titreFichier & " DU " & DateDuRapport.ToShortDateString
        Else
            titreFichier = "DAILY FINANCIAL REPORT"
            tireDocument = titreFichier & " OF " & DateDuRapport.ToShortDateString
        End If

        Dim mobile_number As String = MainWindow.listeOfTelephoneNumbers()
        Dim args As ArgumentType = New ArgumentType()

        args.action = 2
        args.mobile_number = mobile_number

        If GlobalVariable.actualLanguageValue = 1 Then
            args.whatsAppMessage = "Recevez nos salutations," & Chr(13) & " Merci de bien vouloir trouver ci joint la " & tireDocument.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce message !!"
        Else
            args.whatsAppMessage = "Receive our greetings," & Chr(13) & " Attachement " & tireDocument.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do no respond to this message !!"
        End If

        'B3 : MESSAGE DE SALUTATION

        backGroundWorkerToCall(args)

        'If Not BackgroundWorker3.IsBusy Then
        'BackgroundWorker3.RunWorkerAsync(args)
        'End If

    End Function

    Public Function SituationDeCaisseCloture(ByVal DateDuRapport As Date) As Double

        'ON SELECTIONNE L'ENSEMBLE DE REGLEMENTS DE DE LA CAISSIERE (MONTANT TOTAL)

        Dim getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND DATE_REGLEMENT >= '" & DateDuRapport.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <='" & DateDuRapport.ToString("yyyy-MM-dd") & "' ORDER BY DATE_REGLEMENT DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@IMPRIMER", MySqlDbType.Int64).Value = 3

        Dim adapter As New MySqlDataAdapter()

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        'Dim SituationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)
        Dim SituationDeCaisse As DataTable = dt

        Dim SortieDeFonds As Double = 0

        If SituationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To SituationDeCaisse.Rows.Count - 1

                'ON CALCUL LES SORTIES DE FONDS
                If SituationDeCaisse.Rows(i)("MONTANT_VERSE") < 0 Then
                    SortieDeFonds += SituationDeCaisse.Rows(i)("MONTANT_VERSE")
                End If

            Next

            Return SortieDeFonds

        End If

    End Function

    Dim fermerLogiciel As Boolean = False

    Public Function ListeDesMainCourantesDujours(ByVal dateDebut As Date, ByVal DateFin As Date, ByVal chambre_salle As String) As DataGridView

        Dim changerSigne As Integer = -1

        If Not GlobalVariable.AncienneMainCourante Then

            'MAINCOURANTE JOURNALIERE
            Dim dateTravail As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
            Dim dateMainCourante As Date = CDate(GlobalVariable.DateDeTravail.AddDays(-1)).ToShortDateString

            Functions.AffectingTitleToAForm("MAIN COURANTE JOURNALIERE", GunaLabelGestCompteGeneraux)

            'RESERVATION 
            Dim ETAT_MAIN_COURANTE As Integer = 0

            If dateMainCourante < dateTravail Then
                ETAT_MAIN_COURANTE = 1
            End If

            'AND ETAT_MAIN_COURANTE=@ETAT_MAIN_COURANTE

            Dim getUserQuery1 = "SELECT CHAMBRE_ID As 'CHAMBRE', DAY_USE, NUM_RESERVATION, ARRHES, main_courante_journaliere.NOM_CLIENT As 'NOM & PRENOM', DATE_ENTTRE As 'DATE ARRIVEE',
            DATE_SORTIE As 'DATE DEPART', NB_PERSONNES As 'NBRE DE PAX', PDJ, DEJEUNER, DINER,CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE',
            ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_journaliere.NUM_RESERVATION As 'RESERVATION', 
            main_courante_journaliere.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_journaliere.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR,
            main_courante_journaliere.SERVICES AS 'SERVICES', main_courante_journaliere.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_journaliere.BOUTIQE AS 'BOUTIQUE',
            main_courante_journaliere.CYBERCAFE As 'BUSINESS CENTER', main_courante_journaliere.SPORTS As 'SPORTS' , main_courante_journaliere.LOISIRS As 'LOISIRS',
            TOTAL_JOUR, main_courante_journaliere.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_journaliere.BLANCHISSERIE As BLANCHISSERIE, main_courante_journaliere.AUTRES As 'AUTRES'
            , TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER', HEURE_ENTREE, HEURE_SORTIE,
            TAUX_OCCUPATION_PCT As 'TAXE DE SEJOUR', ANTICIPE, DAY_USE FROM main_Courante_journaliere, reserve_conf WHERE DATE_MAIN_COURANTE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
            AND DATE_MAIN_COURANTE >='" & dateDebut.ToString("yyyy-MM-dd") & "' AND main_Courante_journaliere.NUM_RESERVATION = reserve_conf.CODE_RESERVATION 
            AND reserve_conf.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

            Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)

            'command1.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
            'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 0
            command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = ETAT_MAIN_COURANTE
            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = chambre_salle

            Dim adapter1 As New MySqlDataAdapter(command1)

            Dim table As New DataTable()

            adapter1.Fill(table)

            '-------------------------------------------------------- MAINCOURANTE ----------------------------------------------

            Dim getUserQuery01 = "SELECT CODE_CHAMBRE As 'CHAMBRE', NUM_RESERVATION, ARRHES, main_courante_autres.NOM_CLIENT As 'NOM & PRENOM', PDJ, DEJEUNER, DINER, CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_autres.NUM_RESERVATION As 'RESERVATION', main_courante_autres.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_autres.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_autres.SERVICES AS 'SERVICES', main_courante_autres.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_autres.BOUTIQE AS 'BOUTIQUE', main_courante_autres.CYBERCAFE As 'BUSINESS CENTER', main_courante_autres.SPORTS As 'SPORTS' , main_courante_autres.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_autres.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_autres.BLANCHISSERIE As BLANCHISSERIE, main_courante_autres.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER' FROM main_Courante_autres WHERE DATE_MAIN_COURANTE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & dateDebut.ToString("yyyy-MM-dd") & "' ORDER BY main_courante_autres.NOM_CLIENT ASC"

            Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

            'command1.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
            'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 0
            'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 1
            command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = chambre_salle

            Dim adapter01 As New MySqlDataAdapter(command01)

            Dim table0 As New DataTable()

            adapter01.Fill(table0)

            '--------------------------------------------------------------------------------------------------------------------

            If table.Rows.Count > 0 Then

                dt.Columns.Clear()
                dt.Rows.Clear()

                '------------------ ADD COLUMNS --------------------

                dt.Columns.Add("CHAMBRE", "CHAMBRE")
                dt.Columns.Add("NOM_PRENOM", "NOM & PRENOM")
                dt.Columns.Add("ARRIVEE", "ARRIVEE")
                dt.Columns.Add("DEPART", "DEPART")
                dt.Columns.Add("NUITEE", "NUITEE")
                dt.Columns.Add("NBRE_PAX", "NBRE PAX")
                dt.Columns.Add("HEBERGEMENT", "HEBERGEMENT")
                dt.Columns.Add("TAXE", "TAXE")
                dt.Columns.Add("PDJ", "PDJ")
                dt.Columns.Add("DEJEUNER", "DEJEUNER")
                dt.Columns.Add("DINER", "DINER")
                dt.Columns.Add("BAR", "BAR")
                dt.Columns.Add("BLANCHISSERIE", "BLANCHISSERIE")
                dt.Columns.Add("AUTRES", "AUTRES")
                dt.Columns.Add("RECETTE_DU_JOUR", "RECETTE DU JOUR") 'TOTAL DU JOUR
                dt.Columns.Add("REPORT_VEILLE", "REPORT VEILLE")
                dt.Columns.Add("TOTAL_GENERAL", "TOTAL GENERAL")
                dt.Columns.Add("ESPECES", "ESPECES")
                dt.Columns.Add("CARTE", "CARTE")
                dt.Columns.Add("MOBILE_MONEY", "MOBILE MONEY")
                dt.Columns.Add("A_REPORTER", "A REPORTER")
                dt.Columns.Add("CODE_RESERVATION", "CODE RESERVATION")

                '------------------ FAILED COLUMNS -----------------

                Dim enChambre As Boolean = False

                For i = 0 To table.Rows.Count - 1

                    enChambre = False
                    Dim DAY_USE As Integer = table.Rows(i)("DAY_USE")
                    Dim NUMERO_RESERVATION As String = table.Rows(i)("NUM_RESERVATION")

                    '----------------------------------------------- TAXE DE SEJOURS ------------------------------------------------------

                    '-----------------------------------------------END TAXE DE SEJOURS ---------------------------------------------------

                    Dim RESTAURANT As Double = table.Rows(i)("PDJ") + table.Rows(i)("DEJEUNER") + table.Rows(i)("DINER")
                    Dim BAR As Double = table.Rows(i)("CAFE") + table.Rows(i)("CAVE") + table.Rows(i)("DIVERS")

                    'Dim RESTAURANT As Double = table.Rows(i)("CAVE") + table.Rows(i)("DIVERS") + table.Rows(i)("CAFE")

                    Dim AUTRES_VENTE As Double = table.Rows(i)("SERVICES") + table.Rows(i)("SALON DE BEAUTE") + table.Rows(i)("BOUTIQUE") + table.Rows(i)("BUSINESS CENTER") + table.Rows(i)("SPORTS") + table.Rows(i)("LOISIRS") + table.Rows(i)("JOURNAUX") + table.Rows(i)("AUTRES")

                    Dim TOTAL_RECETTE As Double = 0

                    Dim nuits As Integer = 0

                    Dim arrivee As Date = CDate(table.Rows(i)("DATE ARRIVEE")).ToShortDateString
                    Dim depart As Date = CDate(table.Rows(i)("DATE DEPART")).ToShortDateString

                    If dateMainCourante >= arrivee And dateMainCourante <= depart Then
                        enChambre = True
                    End If

                    Dim HEBERGEMENT As Double = table.Rows(i)("HEBERGEMENT")
                    Dim taxeDeSejours As Double = table.Rows(i)("TAXE DE SEJOUR")
                    Dim taxeDeSejourDansLigneFacture As Double = 0

                    Dim RETRANCHEMENTHEBERGEMENT As Double = 0
                    Dim RETRANCHEMENTTAXEDESEJOUR As Double = 0
                    Dim TAXE_DE_SEJOUR_REELLE As Double = 0

                    'CALCUL DU SEJOURS ECOULE

                    ' If dateTravail <= depart Then
                    'nuits = CType((dateTravail - arrivee).TotalDays, Int64)
                    'Else
                    'nuits = CType((depart - arrivee).TotalDays, Int64)
                    'End If

                    nuits = CType((depart - arrivee).TotalDays, Int64)

                    Dim PAX As Integer = table.Rows(i)("NBRE DE PAX")

                    If PAX <= 0 Then
                        PAX = 1
                    End If

                    Dim SERVICE As String = ""

                    'ON DOIT DETERMINER QUELLE EST LE VRAI MONTANT DE LA TAXE DE SEJOUR

                    If GlobalVariable.actualLanguageValue = 1 Then
                        SERVICE = "TAXE DE SEJOURS"
                    Else
                        SERVICE = "TOURIST TAX"
                    End If

                    'VA AIDER A RETIRER LES TAXES DE SEJOURS EN TROP
                    TAXE_DE_SEJOUR_REELLE = Functions.totalDunServiceUnCertainJourSpecifique(dateMainCourante, SERVICE, table.Rows(i)("NUM_RESERVATION"))

                    If depart.ToString("yyyy-MM-dd") = dateMainCourante.ToString("yyyy-MM-dd") Then

                        If table.Rows(i)("DAY_USE") = 0 Then

                            RETRANCHEMENTHEBERGEMENT = HEBERGEMENT
                            RETRANCHEMENTTAXEDESEJOUR = taxeDeSejours

                            HEBERGEMENT = 0
                            taxeDeSejours = 0

                        Else
                            'AUTRES_VENTE -= table.Rows(i)("HEBERGEMENT")
                        End If

                    Else

                    End If

                    If HEBERGEMENT < 0 Then
                        HEBERGEMENT = 0
                    End If

                    Dim TAXE_EN_TROP_NEGATIVE As Double = 0

                    'ON DOIT MULTIPLIER LE DAY USE PAR LE NOMBRE D'HEURE
                    If table.Rows(i)("DAY_USE") = 1 Then

                        Dim DEBUT As Date = CDate(table.Rows(i)("HEURE_ENTREE")).ToShortTimeString
                        Dim FIN As Date = CDate(table.Rows(i)("HEURE_SORTIE")).ToShortTimeString

                        Dim NombreHeure As Integer = 0

                        NombreHeure = CType((FIN - DEBUT).TotalHours, Int32)

                    End If

                    If AUTRES_VENTE < 0 Then
                        AUTRES_VENTE = 0
                    End If

                    Dim TOTAL_ENCAISSEMENT As Double = table.Rows(i)("ESPECES") + table.Rows(i)("CARTE CREDIT") + table.Rows(i)("MOBILE MONEY") + table.Rows(i)("CHEQUE")

                    If (RESTAURANT + BAR) = table.Rows(i)("BAR/RESTAURANT") Then
                        TOTAL_RECETTE = AUTRES_VENTE + HEBERGEMENT + table.Rows(i)("BAR/RESTAURANT") + table.Rows(i)("BLANCHISSERIE")
                    ElseIf RESTAURANT + BAR = table.Rows(i)("BAR/RESTAURANT") Then
                        TOTAL_RECETTE = AUTRES_VENTE + HEBERGEMENT + RESTAURANT + BAR + table.Rows(i)("BLANCHISSERIE")
                    Else
                        TOTAL_RECETTE = table.Rows(i)("BAR/RESTAURANT") + AUTRES_VENTE + HEBERGEMENT + table.Rows(i)("BLANCHISSERIE")
                    End If

                    Dim A_REPORTER_SOLDE As Double = 0
                    Dim TOTAL_GENERAL_DU_JOUR As Double = 0
                    Dim TOTAL_CARTE As Double = 0
                    Dim RECETTE_TOTAL_DU_JOUR As Double = 0

                    'DataGridViewMainCouranteReception.Rows.Add(table.Rows(i)("CHAMBRE"), table.Rows(i)("NOM & PRENOM"), CDate(table.Rows(i)("DATE ARRIVEE")).ToShortDateString, CDate(table.Rows(i)("DATE DEPART")).ToShortDateString, nuits, PAX, HEBERGEMENT, taxeDeSejours, table.Rows(i)("PDJ"), table.Rows(i)("DEJEUNER"), table.Rows(i)("DINER"), table.Rows(i)("BAR"), table.Rows(i)("BLANCHISSERIE"), AUTRES_VENTE, (table.Rows(i)("RECETTE DU JOUR") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR), table.Rows(i)("REPORT VEILLE") * changerSigne, (table.Rows(i)("TOTAL GENERAL") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR) * changerSigne, table.Rows(i)("ESPECES"), table.Rows(i)("CARTE CREDIT") + table.Rows(i)("CHEQUE"), table.Rows(i)("MOBILE MONEY"), (table.Rows(i)("A REPORTER") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR - table.Rows(i)("ARRHES")) * changerSigne, table.Rows(i)("NUM_RESERVATION"))
                    'TOTAL_GENERAL_DU_JOUR = (table.Rows(i)("TOTAL GENERAL") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR) * changerSigne

                    TOTAL_GENERAL_DU_JOUR = (table.Rows(i)("TOTAL GENERAL") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR) * changerSigne
                    TOTAL_CARTE = table.Rows(i)("CARTE CREDIT") + table.Rows(i)("CHEQUE")
                    RECETTE_TOTAL_DU_JOUR = (table.Rows(i)("RECETTE DU JOUR") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR)
                    A_REPORTER_SOLDE = (table.Rows(i)("A REPORTER") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR - table.Rows(i)("ARRHES")) * changerSigne

                    Dim TAXE_EN_TROP As Double = 0

                    If taxeDeSejours >= TAXE_DE_SEJOUR_REELLE Then
                        TAXE_EN_TROP = taxeDeSejours - TAXE_DE_SEJOUR_REELLE
                    Else

                    End If

                    If arrivee.ToString("yyyy-MM-dd") = dateMainCourante.ToString("yyyy-MM-dd") Then
                        If TAXE_EN_TROP > 0 Then
                            TAXE_EN_TROP_NEGATIVE = TAXE_EN_TROP
                        End If
                    End If

                    If table.Rows(i)("ANTICIPE") = 1 Then 'BEFORE FACTURATION EN AVANCE

                        TAXE_EN_TROP = 0

                        A_REPORTER_SOLDE = table.Rows(i)("A REPORTER")

                        If dateMainCourante >= dateTravail Then
                            'LES DONNEES N'ETANT PAS ENCORE ARRETER ON PEUT LIRE LA SOURCE VARIABLE

                            If GlobalVariable.actualLanguageValue = 1 Then
                                SERVICE = "HEBERGEMENT"
                            Else
                                SERVICE = "ACCOMMODATION"
                            End If

                            HEBERGEMENT = Functions.totalDunServiceUnCertainJourSpecifique(dateMainCourante, SERVICE, table.Rows(i)("NUM_RESERVATION"))

                            If GlobalVariable.actualLanguageValue = 1 Then
                                SERVICE = "TAXE DE SEJOURS"
                            Else
                                SERVICE = "TOURIST TAX"
                            End If

                            taxeDeSejours = Functions.totalDunServiceUnCertainJourSpecifique(dateMainCourante, SERVICE, table.Rows(i)("NUM_RESERVATION"))

                            If dateMainCourante = depart Then
                                If DAY_USE = 0 Then
                                    RECETTE_TOTAL_DU_JOUR += (HEBERGEMENT + taxeDeSejours)
                                    TOTAL_GENERAL_DU_JOUR += (HEBERGEMENT + taxeDeSejours) * changerSigne
                                End If
                            End If

                            'TOTAL_GENERAL_DU_JOUR += taxeDeSejours + HEBERGEMENT

                        End If

                    End If

                    If enChambre Then
                        dt.Rows.Add(table.Rows(i)("CHAMBRE"), table.Rows(i)("NOM & PRENOM"), CDate(table.Rows(i)("DATE ARRIVEE")).ToShortDateString, CDate(table.Rows(i)("DATE DEPART")).ToShortDateString, nuits, PAX, HEBERGEMENT, TAXE_DE_SEJOUR_REELLE, table.Rows(i)("PDJ"), table.Rows(i)("DEJEUNER"), table.Rows(i)("DINER"), table.Rows(i)("BAR"), table.Rows(i)("BLANCHISSERIE"), AUTRES_VENTE, RECETTE_TOTAL_DU_JOUR - TAXE_EN_TROP, (table.Rows(i)("REPORT VEILLE")) * changerSigne + TAXE_EN_TROP - TAXE_EN_TROP_NEGATIVE, TOTAL_GENERAL_DU_JOUR + TAXE_EN_TROP, table.Rows(i)("ESPECES"), TOTAL_CARTE, table.Rows(i)("MOBILE MONEY"), A_REPORTER_SOLDE + TAXE_EN_TROP, table.Rows(i)("NUM_RESERVATION"))
                    End If

                    RETRANCHEMENTHEBERGEMENT = 0
                    RETRANCHEMENTTAXEDESEJOUR = 0

                Next

                'MAINcourantes comptoires
                For i = 0 To table0.Rows.Count - 1

                    Dim RESTAURANT As Double = table0.Rows(i)("PDJ") + table0.Rows(i)("DEJEUNER") + table0.Rows(i)("DINER")
                    Dim BAR As Double = table0.Rows(i)("CAFE") + table0.Rows(i)("CAVE") + table0.Rows(i)("DIVERS")

                    'Dim RESTAURANT As Double = table0.Rows(i)("CAVE") + table0.Rows(i)("DIVERS") + table0.Rows(i)("CAFE")

                    Dim AUTRES_VENTE As Double = table0.Rows(i)("SERVICES") + table0.Rows(i)("SALON DE BEAUTE") + table0.Rows(i)("BOUTIQUE") + table0.Rows(i)("BUSINESS CENTER") + table0.Rows(i)("SPORTS") + table0.Rows(i)("LOISIRS") + table0.Rows(i)("JOURNAUX") + table0.Rows(i)("AUTRES")

                    Dim TOTAL_RECETTE As Double = 0

                    Dim TOTAL_ENCAISSEMENT As Double = table0.Rows(i)("ESPECES") + table0.Rows(i)("CARTE CREDIT") + table0.Rows(i)("MOBILE MONEY") + table0.Rows(i)("CHEQUE")

                    'TOTAL_RECETTE = AUTRES_VENTE + table0.Rows(i)("BAR/RESTAURANT") + table0.Rows(i)("BLANCHISSERIE")

                    If (RESTAURANT + BAR) = table0.Rows(i)("BAR/RESTAURANT") And (RESTAURANT + table0.Rows(i)("BAR")) = table0.Rows(i)("BAR/RESTAURANT") Then
                        TOTAL_RECETTE = AUTRES_VENTE + table0.Rows(i)("BAR/RESTAURANT") + table0.Rows(i)("BLANCHISSERIE")
                    Else
                        TOTAL_RECETTE = AUTRES_VENTE + RESTAURANT + BAR + table0.Rows(i)("BLANCHISSERIE")
                    End If

                    dt.Rows.Add("-", "CLIENT COMPTOIR", CDate(dateDebut).ToShortDateString, CDate(DateFin).ToShortDateString, 0, 0, 0, 0, table0.Rows(i)("PDJ"), table0.Rows(i)("DEJEUNER"), table0.Rows(i)("DINER"), table0.Rows(i)("BAR"), table0.Rows(i)("BLANCHISSERIE"), AUTRES_VENTE, table0.Rows(i)("RECETTE DU JOUR"), table0.Rows(i)("REPORT VEILLE") * changerSigne, table0.Rows(i)("TOTAL GENERAL") * changerSigne, table0.Rows(i)("ESPECES"), table0.Rows(i)("CARTE CREDIT") + table0.Rows(i)("CHEQUE"), table0.Rows(i)("MOBILE MONEY"), table0.Rows(i)("A REPORTER") * changerSigne, "-")

                Next

                'DataGridViewMainCouranteReception.Visible = True
                'DataGridViewMainCouranteReception.DataSource = table

                dt.Columns("HEBERGEMENT").DefaultCellStyle.Format = "#,##0"
                dt.Columns("HEBERGEMENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("NBRE_PAX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                dt.Columns("PDJ").DefaultCellStyle.Format = "#,##0"
                dt.Columns("PDJ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("TAXE").DefaultCellStyle.Format = "#,##0"
                dt.Columns("TAXE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                dt.Columns("DEJEUNER").DefaultCellStyle.Format = "#,##0"
                dt.Columns("DEJEUNER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("DINER").DefaultCellStyle.Format = "#,##0"
                dt.Columns("DINER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("BAR").DefaultCellStyle.Format = "#,##0"
                dt.Columns("BAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("ESPECES").DefaultCellStyle.Format = "#,##0"
                dt.Columns("ESPECES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("CARTE").DefaultCellStyle.Format = "#,##0"
                dt.Columns("CARTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("MOBILE_MONEY").DefaultCellStyle.Format = "#,##0"
                dt.Columns("MOBILE_MONEY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("BLANCHISSERIE").DefaultCellStyle.Format = "#,##0"
                dt.Columns("BLANCHISSERIE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("RECETTE_DU_JOUR").DefaultCellStyle.Format = "#,##0"
                dt.Columns("RECETTE_DU_JOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("REPORT_VEILLE").DefaultCellStyle.Format = "#,##0"
                dt.Columns("REPORT_VEILLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("TOTAL_GENERAL").DefaultCellStyle.Format = "#,##0"
                dt.Columns("TOTAL_GENERAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("CODE_RESERVATION").Visible = False

                'dt.Columns("ENCAISSEMENT").DefaultCellStyle.Format = "#,##0"
                'dt.Columns("ENCAISSEMENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dt.Columns("A_REPORTER").DefaultCellStyle.Format = "#,##0"
                dt.Columns("A_REPORTER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Else

                'dt.Visible = False
                dt.Columns.Clear()

            End If

        End If

        'connect.closeConnection()

    End Function

    Private Sub GunaButtonTerminer_Click(sender As Object, e As EventArgs) Handles GunaButtonTerminer.Click

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.AddDays(-1).ToString("yyyy-MM-dd")
        Dim DateFin As Date = GlobalVariable.DateDeTravail.AddDays(-1).ToString("yyyy-MM-dd")

        Dim chambre_salle As String = "chambre"

        ListeDesMainCourantesDujours(DateDebut, DateFin, chambre_salle)

        If dt.Rows.Count > 0 Then

            Dim args As ArgumentType = New ArgumentType()
            args.action = 1
            'args.dt = dt
            args.DateDebut = DateDebut
            args.DateFin = DateFin

            If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                fermerLogiciel = True

                '1. GENERATION DE LA LIGNE DESTINEE A CONTENIR LES CHEMINS DES RAPPORTS DU JOURS
                Dim DATE_TRAVAIL As Date = GlobalVariable.DateDeTravail.AddDays(-1)
                Dim dtRapport As DataTable = Functions.verificationExistenceCheminDesRapportsDuJours(DATE_TRAVAIL)

                If Not dtRapport.Rows.Count > 0 Then

                    Dim insertQuery As String = "INSERT INTO `rapport_auto`(`DATE_TRAVAIL`) VALUES (@DATE_TRAVAIL)"
                    Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
                    command.Parameters.Add("@DATE_TRAVAIL", MySqlDbType.Date).Value = DATE_TRAVAIL
                    command.ExecuteNonQuery()

                End If

                '2. GENERATION DES RAPPORTS POUR ENVOI AUTOMATIQUE PAR WHATSAPP ET PAR MAIL

                '2.1- MAINCOURANTE JOURNALIERE
                Dim document As Integer = 1
                Functions.docMainCourante(dt, DateDebut, DateFin, document) 'CHEMIN_MAINCOURANTE

                '2.2- ENCAISSEMENTS
                Functions.docRapportDesCaissesPeriodique(DateDebut, DateFin) 'CHEMIN_REGLEMENT
                '2.3- INVENTAIRES DES VENTES
                ' Functions.docInventaireDesVentesParMagasin(DateDebut, DateFin)
                Functions.docInventaireDesVentes(DateDebut, DateFin) 'CHEMIN_INVENTAIRES_DES_VENTES

                If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then
                    '2.4- INVENTAIRE PAR MAGASIN
                    Functions.docInventaireDesDiversMagasin(DateDebut, DateFin) 'CHEMIN_INVENTAIRES
                End If

                '2.5- JOURNAL DES VENTES
                Functions.docJournalDesVentesPeriodique(DateDebut, DateFin) 'CHEMIN_VENTES

                '2.6- MAINCOURANTE_CUMULE
                DateDebut = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail)
                Functions.ListeDesMainCourantesCumul(DateDebut, DateFin)
                Functions.docRapportMainCouranteMensuel(RapportFacturesForm.DataGridViewRapports, DateDebut, DateFin) 'CHEMIN_MAINCOURANTE_CUMUL

                backGroundWorkerToCall(args)

            End If

        End If

        'Functions.retablissementDesPictogrammeCorrecteDuDashBoard(GlobalVariable.DateDeTravail)

        Me.Close()

        gestionDeLicenceDeHotelSoft()

        Me.Cursor = Cursors.Default

        Functions.updateOfFields("agence", "rapport_auto", 0, "CODE_AGENCE", GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE"), 0)

        If Not fermerLogiciel Then
            fermerLogiciel = True
            fermetureApresCLoture()
        End If

    End Sub

    Public Sub fermetureApresCLoture()

        If fermerLogiciel Then

            Me.Cursor = Cursors.WaitCursor

            Dim elite_traitement As Boolean = True

            If elite_traitement Then

                Dim elite As New ClubElite()

                Dim dateDuJour As Date = GlobalVariable.DateDeTravail.AddDays(-1)
                Dim enChambre As DataTable = Functions.enChambreDuJour(dateDuJour)

                elite.remplissageDesChampsPermettantLeUpGradingDuClient(enChambre)

            End If

            Me.Close()
            AccueilForm.Show()
            MainWindow.Close()

            fermerLogiciel = False

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Public Sub gestionDeLicenceDeHotelSoft()

        Dim licence As New Licence()

        licence.gestionDesLicence()

        ActivationForm.TopMost = True

        GlobalVariable.licenceExipre = True

    End Sub

    Public Sub backGroundWorkerToCall(ByVal args As ArgumentType)

        If Not BackgroundWorker2.IsBusy Then
            BackgroundWorker2.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker3.IsBusy Then
            BackgroundWorker3.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker4.IsBusy Then
            BackgroundWorker4.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker5.IsBusy Then
            BackgroundWorker5.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker6.IsBusy Then
            BackgroundWorker6.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker7.IsBusy Then
            BackgroundWorker7.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker8.IsBusy Then
            BackgroundWorker8.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker9.IsBusy Then
            BackgroundWorker9.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker10.IsBusy Then
            BackgroundWorker10.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker11.IsBusy Then
            BackgroundWorker11.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker12.IsBusy Then
            BackgroundWorker12.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker13.IsBusy Then
            BackgroundWorker13.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker14.IsBusy Then
            BackgroundWorker14.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker15.IsBusy Then
            BackgroundWorker15.RunWorkerAsync(args)
        End If

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker6_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker6.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker7_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker7.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker8_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker8.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker9_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker9.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker10_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker10.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    '-----------------------------------

    Private Sub BackgroundWorker11_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker11.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker12_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker12.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker13_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker13.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker14_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker14.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker15_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker15.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub documentToBeSendUsingBackGroundWorker(ByVal args As ArgumentType)

        If args.action = 0 Then
            'FOR RAPPORT FINANCIER
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        ElseIf args.action = 1 Then
            'FOR MAINCOURANTE
            RapportApresCloture.RapportMainCourante(args.DateDebut, args.DateFin)
        ElseIf args.action = 2 Then
            'INTRODUCTORY MESSAGE TO MAINCOURANTE
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        ElseIf args.action = 3 Then
            'JOURNAL DES VENTES
            RapportApresCloture.docJournalDesVentesShift(args.dt, args.DateDebut, args.DateFin)
        ElseIf args.action = 4 Then

        ElseIf args.action = 5 Then

        ElseIf args.action = 6 Or args.action = 7 Then

        ElseIf args.action = 8 Or args.action = 9 Then

        End If

    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker4_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker15_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker15.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker5_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker5.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker6_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker6.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker7_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker7.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker8_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker8.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker9_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker9.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker10_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker10.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker11_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker12.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker13_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker13.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

    Private Sub BackgroundWorker14_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker14.RunWorkerCompleted
        fermetureApresCLoture()
    End Sub

End Class
