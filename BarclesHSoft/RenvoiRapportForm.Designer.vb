<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenvoiRapportForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RenvoiRapportForm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaLabelGestCompteGeneraux = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanelTopPanel = New Guna.UI.WinForms.GunaPanel()
        Me.GunaImageButton6 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton7 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton4 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton5 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton3 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.GunaCheckBoxMaincouranteJournaliere = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaDateTimePickerDateMainCouranteJournaliere = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaButtonEnvoyer = New Guna.UI.WinForms.GunaButton()
        Me.GunaCheckBoxTousCocher = New Guna.UI.WinForms.GunaCheckBox()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
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
        Me.GunaCheckBoxMaincouranteCumule = New Guna.UI.WinForms.GunaCheckBox()
        Me.GunaDateTimePickerMCCDu = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaDateTimePickerMCCAu = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dt = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaPanelTopPanel.SuspendLayout()
        CType(Me.dt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaLabelGestCompteGeneraux
        '
        Me.GunaLabelGestCompteGeneraux.AutoSize = True
        Me.GunaLabelGestCompteGeneraux.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompteGeneraux.ForeColor = System.Drawing.Color.White
        Me.GunaLabelGestCompteGeneraux.Location = New System.Drawing.Point(408, 2)
        Me.GunaLabelGestCompteGeneraux.Name = "GunaLabelGestCompteGeneraux"
        Me.GunaLabelGestCompteGeneraux.Size = New System.Drawing.Size(205, 21)
        Me.GunaLabelGestCompteGeneraux.TabIndex = 4
        Me.GunaLabelGestCompteGeneraux.Text = "RAPPORTS AUTOMATIQUE"
        Me.GunaLabelGestCompteGeneraux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaPanelTopPanel
        '
        Me.GunaPanelTopPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton6)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton7)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton4)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton5)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton3)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton2)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaLabelGestCompteGeneraux)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaImageButton1)
        Me.GunaPanelTopPanel.Controls.Add(Me.GunaLabel1)
        Me.GunaPanelTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanelTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanelTopPanel.Name = "GunaPanelTopPanel"
        Me.GunaPanelTopPanel.Size = New System.Drawing.Size(1020, 25)
        Me.GunaPanelTopPanel.TabIndex = 2
        '
        'GunaImageButton6
        '
        Me.GunaImageButton6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton6.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton6.Image = CType(resources.GetObject("GunaImageButton6.Image"), System.Drawing.Image)
        Me.GunaImageButton6.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton6.Location = New System.Drawing.Point(963, 3)
        Me.GunaImageButton6.Name = "GunaImageButton6"
        Me.GunaImageButton6.OnHoverImage = Nothing
        Me.GunaImageButton6.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton6.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton6.TabIndex = 11
        '
        'GunaImageButton7
        '
        Me.GunaImageButton7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton7.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton7.Image = CType(resources.GetObject("GunaImageButton7.Image"), System.Drawing.Image)
        Me.GunaImageButton7.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton7.Location = New System.Drawing.Point(987, 3)
        Me.GunaImageButton7.Name = "GunaImageButton7"
        Me.GunaImageButton7.OnHoverImage = Nothing
        Me.GunaImageButton7.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton7.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton7.TabIndex = 10
        '
        'GunaImageButton4
        '
        Me.GunaImageButton4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton4.Image = Nothing
        Me.GunaImageButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton4.Location = New System.Drawing.Point(965, 3)
        Me.GunaImageButton4.Name = "GunaImageButton4"
        Me.GunaImageButton4.OnHoverImage = Nothing
        Me.GunaImageButton4.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton4.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton4.TabIndex = 9
        '
        'GunaImageButton5
        '
        Me.GunaImageButton5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton5.Image = Nothing
        Me.GunaImageButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton5.Location = New System.Drawing.Point(990, 3)
        Me.GunaImageButton5.Name = "GunaImageButton5"
        Me.GunaImageButton5.OnHoverImage = Nothing
        Me.GunaImageButton5.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton5.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton5.TabIndex = 8
        '
        'GunaImageButton3
        '
        Me.GunaImageButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton3.Image = Nothing
        Me.GunaImageButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton3.Location = New System.Drawing.Point(981, 2)
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
        Me.GunaImageButton2.Location = New System.Drawing.Point(981, 3)
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
        Me.GunaImageButton1.Location = New System.Drawing.Point(985, 2)
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
        Me.GunaLabel1.Location = New System.Drawing.Point(2187, -2)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(24, 25)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "X"
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 440)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1020, 10)
        Me.GunaPanel2.TabIndex = 36
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaPanelTopPanel
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.GunaLabelGestCompteGeneraux
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'GunaCheckBoxMaincouranteJournaliere
        '
        Me.GunaCheckBoxMaincouranteJournaliere.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxMaincouranteJournaliere.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxMaincouranteJournaliere.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxMaincouranteJournaliere.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxMaincouranteJournaliere.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxMaincouranteJournaliere.Location = New System.Drawing.Point(12, 41)
        Me.GunaCheckBoxMaincouranteJournaliere.Name = "GunaCheckBoxMaincouranteJournaliere"
        Me.GunaCheckBoxMaincouranteJournaliere.Size = New System.Drawing.Size(214, 20)
        Me.GunaCheckBoxMaincouranteJournaliere.TabIndex = 37
        Me.GunaCheckBoxMaincouranteJournaliere.Text = "Maincourante Journalier du"
        '
        'GunaDateTimePickerDateMainCouranteJournaliere
        '
        Me.GunaDateTimePickerDateMainCouranteJournaliere.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerDateMainCouranteJournaliere.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDateMainCouranteJournaliere.BorderColor = System.Drawing.Color.Silver
        Me.GunaDateTimePickerDateMainCouranteJournaliere.BorderSize = 1
        Me.GunaDateTimePickerDateMainCouranteJournaliere.CustomFormat = Nothing
        Me.GunaDateTimePickerDateMainCouranteJournaliere.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerDateMainCouranteJournaliere.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateMainCouranteJournaliere.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.GunaDateTimePickerDateMainCouranteJournaliere.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDateMainCouranteJournaliere.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerDateMainCouranteJournaliere.Location = New System.Drawing.Point(229, 36)
        Me.GunaDateTimePickerDateMainCouranteJournaliere.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerDateMainCouranteJournaliere.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerDateMainCouranteJournaliere.Name = "GunaDateTimePickerDateMainCouranteJournaliere"
        Me.GunaDateTimePickerDateMainCouranteJournaliere.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerDateMainCouranteJournaliere.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateMainCouranteJournaliere.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerDateMainCouranteJournaliere.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerDateMainCouranteJournaliere.Radius = 5
        Me.GunaDateTimePickerDateMainCouranteJournaliere.Size = New System.Drawing.Size(134, 30)
        Me.GunaDateTimePickerDateMainCouranteJournaliere.TabIndex = 38
        Me.GunaDateTimePickerDateMainCouranteJournaliere.Text = "09/05/2023"
        Me.GunaDateTimePickerDateMainCouranteJournaliere.Value = New Date(2023, 5, 9, 14, 30, 44, 366)
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
        Me.GunaButtonEnvoyer.ImageSize = New System.Drawing.Size(30, 30)
        Me.GunaButtonEnvoyer.Location = New System.Drawing.Point(921, 407)
        Me.GunaButtonEnvoyer.Name = "GunaButtonEnvoyer"
        Me.GunaButtonEnvoyer.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonEnvoyer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonEnvoyer.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonEnvoyer.OnHoverImage = Nothing
        Me.GunaButtonEnvoyer.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonEnvoyer.Radius = 4
        Me.GunaButtonEnvoyer.Size = New System.Drawing.Size(87, 27)
        Me.GunaButtonEnvoyer.TabIndex = 52
        Me.GunaButtonEnvoyer.Text = "Envoyer"
        Me.GunaButtonEnvoyer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaCheckBoxTousCocher
        '
        Me.GunaCheckBoxTousCocher.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxTousCocher.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxTousCocher.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxTousCocher.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxTousCocher.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxTousCocher.Location = New System.Drawing.Point(12, 409)
        Me.GunaCheckBoxTousCocher.Name = "GunaCheckBoxTousCocher"
        Me.GunaCheckBoxTousCocher.Size = New System.Drawing.Size(114, 20)
        Me.GunaCheckBoxTousCocher.TabIndex = 37
        Me.GunaCheckBoxTousCocher.Text = "Tous cocher"
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'BackgroundWorker3
        '
        Me.BackgroundWorker3.WorkerSupportsCancellation = True
        '
        'BackgroundWorker4
        '
        Me.BackgroundWorker4.WorkerReportsProgress = True
        Me.BackgroundWorker4.WorkerSupportsCancellation = True
        '
        'BackgroundWorker5
        '
        Me.BackgroundWorker5.WorkerSupportsCancellation = True
        '
        'BackgroundWorker6
        '
        Me.BackgroundWorker6.WorkerReportsProgress = True
        Me.BackgroundWorker6.WorkerSupportsCancellation = True
        '
        'BackgroundWorker7
        '
        Me.BackgroundWorker7.WorkerSupportsCancellation = True
        '
        'BackgroundWorker8
        '
        Me.BackgroundWorker8.WorkerReportsProgress = True
        Me.BackgroundWorker8.WorkerSupportsCancellation = True
        '
        'BackgroundWorker9
        '
        Me.BackgroundWorker9.WorkerSupportsCancellation = True
        '
        'BackgroundWorker10
        '
        Me.BackgroundWorker10.WorkerReportsProgress = True
        Me.BackgroundWorker10.WorkerSupportsCancellation = True
        '
        'BackgroundWorker11
        '
        Me.BackgroundWorker11.WorkerSupportsCancellation = True
        '
        'BackgroundWorker12
        '
        Me.BackgroundWorker12.WorkerReportsProgress = True
        Me.BackgroundWorker12.WorkerSupportsCancellation = True
        '
        'GunaCheckBoxMaincouranteCumule
        '
        Me.GunaCheckBoxMaincouranteCumule.BaseColor = System.Drawing.Color.White
        Me.GunaCheckBoxMaincouranteCumule.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaCheckBoxMaincouranteCumule.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaCheckBoxMaincouranteCumule.FillColor = System.Drawing.Color.White
        Me.GunaCheckBoxMaincouranteCumule.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaCheckBoxMaincouranteCumule.Location = New System.Drawing.Point(476, 40)
        Me.GunaCheckBoxMaincouranteCumule.Name = "GunaCheckBoxMaincouranteCumule"
        Me.GunaCheckBoxMaincouranteCumule.Size = New System.Drawing.Size(196, 20)
        Me.GunaCheckBoxMaincouranteCumule.TabIndex = 37
        Me.GunaCheckBoxMaincouranteCumule.Text = "Maincourante cumule du"
        '
        'GunaDateTimePickerMCCDu
        '
        Me.GunaDateTimePickerMCCDu.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerMCCDu.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerMCCDu.BorderColor = System.Drawing.Color.Silver
        Me.GunaDateTimePickerMCCDu.BorderSize = 1
        Me.GunaDateTimePickerMCCDu.CustomFormat = Nothing
        Me.GunaDateTimePickerMCCDu.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerMCCDu.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerMCCDu.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.GunaDateTimePickerMCCDu.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerMCCDu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerMCCDu.Location = New System.Drawing.Point(671, 36)
        Me.GunaDateTimePickerMCCDu.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerMCCDu.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerMCCDu.Name = "GunaDateTimePickerMCCDu"
        Me.GunaDateTimePickerMCCDu.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerMCCDu.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerMCCDu.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerMCCDu.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerMCCDu.Radius = 5
        Me.GunaDateTimePickerMCCDu.Size = New System.Drawing.Size(134, 30)
        Me.GunaDateTimePickerMCCDu.TabIndex = 38
        Me.GunaDateTimePickerMCCDu.Text = "09/05/2023"
        Me.GunaDateTimePickerMCCDu.Value = New Date(2023, 5, 9, 14, 30, 44, 366)
        '
        'GunaDateTimePickerMCCAu
        '
        Me.GunaDateTimePickerMCCAu.BackColor = System.Drawing.Color.Transparent
        Me.GunaDateTimePickerMCCAu.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerMCCAu.BorderColor = System.Drawing.Color.Silver
        Me.GunaDateTimePickerMCCAu.BorderSize = 1
        Me.GunaDateTimePickerMCCAu.CustomFormat = Nothing
        Me.GunaDateTimePickerMCCAu.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePickerMCCAu.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerMCCAu.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.GunaDateTimePickerMCCAu.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerMCCAu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePickerMCCAu.Location = New System.Drawing.Point(852, 36)
        Me.GunaDateTimePickerMCCAu.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePickerMCCAu.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePickerMCCAu.Name = "GunaDateTimePickerMCCAu"
        Me.GunaDateTimePickerMCCAu.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePickerMCCAu.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerMCCAu.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePickerMCCAu.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePickerMCCAu.Radius = 5
        Me.GunaDateTimePickerMCCAu.Size = New System.Drawing.Size(134, 30)
        Me.GunaDateTimePickerMCCAu.TabIndex = 38
        Me.GunaDateTimePickerMCCAu.Text = "09/05/2023"
        Me.GunaDateTimePickerMCCAu.Value = New Date(2023, 5, 9, 14, 30, 44, 366)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(817, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 18)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Au"
        '
        'dt
        '
        Me.dt.AllowUserToAddRows = False
        Me.dt.AllowUserToDeleteRows = False
        Me.dt.AllowUserToOrderColumns = True
        Me.dt.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dt.BackgroundColor = System.Drawing.Color.LightBlue
        Me.dt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI Semilight", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dt.ColumnHeadersHeight = 25
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI Semilight", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dt.DefaultCellStyle = DataGridViewCellStyle6
        Me.dt.EnableHeadersVisualStyles = False
        Me.dt.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dt.Location = New System.Drawing.Point(0, 335)
        Me.dt.MultiSelect = False
        Me.dt.Name = "dt"
        Me.dt.ReadOnly = True
        Me.dt.RowHeadersVisible = False
        Me.dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dt.Size = New System.Drawing.Size(1017, 66)
        Me.dt.TabIndex = 54
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
        'RenvoiRapportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 450)
        Me.Controls.Add(Me.dt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GunaButtonEnvoyer)
        Me.Controls.Add(Me.GunaDateTimePickerMCCAu)
        Me.Controls.Add(Me.GunaDateTimePickerMCCDu)
        Me.Controls.Add(Me.GunaDateTimePickerDateMainCouranteJournaliere)
        Me.Controls.Add(Me.GunaCheckBoxMaincouranteCumule)
        Me.Controls.Add(Me.GunaCheckBoxTousCocher)
        Me.Controls.Add(Me.GunaCheckBoxMaincouranteJournaliere)
        Me.Controls.Add(Me.GunaPanel2)
        Me.Controls.Add(Me.GunaPanelTopPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RenvoiRapportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RenvoiRapportForm"
        Me.TopMost = True
        Me.GunaPanelTopPanel.ResumeLayout(False)
        Me.GunaPanelTopPanel.PerformLayout()
        CType(Me.dt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaImageButton6 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton7 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabelGestCompteGeneraux As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanelTopPanel As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaImageButton4 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton5 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton3 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaCheckBoxMaincouranteJournaliere As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents GunaDateTimePickerDateMainCouranteJournaliere As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaButtonEnvoyer As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaCheckBoxTousCocher As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
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
    Friend WithEvents GunaDateTimePickerMCCAu As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaDateTimePickerMCCDu As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaCheckBoxMaincouranteCumule As Guna.UI.WinForms.GunaCheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dt As Guna.UI.WinForms.GunaDataGridView
End Class
