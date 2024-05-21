<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomCommandForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomCommandForm))
        Me.GunaLinePanelTop = New Guna.UI.WinForms.GunaLinePanel()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaTextBoxCodeFacture = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxParent = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaImageButton2 = New Guna.UI.WinForms.GunaImageButton()
        Me.GunaImageButton1 = New Guna.UI.WinForms.GunaImageButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GunaLabelGestCompany = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButtonRestaurant = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonBar = New Guna.UI.WinForms.GunaButton()
        Me.PanelLeftPanel = New System.Windows.Forms.Panel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaShadowPanel1 = New Guna.UI.WinForms.GunaShadowPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GunaButtonPanier = New Guna.UI.WinForms.GunaButton()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelTotalVenteRepas = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LabelTotalVenteBoisson = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaButtonPrecedent = New Guna.UI.WinForms.GunaButton()
        Me.GunaButtonSuivant = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabelPagination = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLinePanelTop.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GunaShadowPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLinePanelTop
        '
        Me.GunaLinePanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GunaLinePanelTop.Controls.Add(Me.GunaButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaTextBoxCodeFacture)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaTextBoxParent)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton2)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaImageButton1)
        Me.GunaLinePanelTop.Controls.Add(Me.Panel5)
        Me.GunaLinePanelTop.Controls.Add(Me.GunaLabelGestCompany)
        Me.GunaLinePanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaLinePanelTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLinePanelTop.ForeColor = System.Drawing.Color.Transparent
        Me.GunaLinePanelTop.LineColor = System.Drawing.Color.Black
        Me.GunaLinePanelTop.LineStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaLinePanelTop.Location = New System.Drawing.Point(0, 0)
        Me.GunaLinePanelTop.Name = "GunaLinePanelTop"
        Me.GunaLinePanelTop.Size = New System.Drawing.Size(1064, 33)
        Me.GunaLinePanelTop.TabIndex = 4
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(144, 2)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Size = New System.Drawing.Size(131, 28)
        Me.GunaButton1.TabIndex = 191
        Me.GunaButton1.Text = "ACCUEIL"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaTextBoxCodeFacture
        '
        Me.GunaTextBoxCodeFacture.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxCodeFacture.BaseColor = System.Drawing.Color.LightGray
        Me.GunaTextBoxCodeFacture.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaTextBoxCodeFacture.BorderSize = 1
        Me.GunaTextBoxCodeFacture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GunaTextBoxCodeFacture.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxCodeFacture.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxCodeFacture.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxCodeFacture.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxCodeFacture.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaTextBoxCodeFacture.Location = New System.Drawing.Point(6, 3)
        Me.GunaTextBoxCodeFacture.Name = "GunaTextBoxCodeFacture"
        Me.GunaTextBoxCodeFacture.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxCodeFacture.Radius = 4
        Me.GunaTextBoxCodeFacture.SelectedText = ""
        Me.GunaTextBoxCodeFacture.Size = New System.Drawing.Size(98, 28)
        Me.GunaTextBoxCodeFacture.TabIndex = 190
        Me.GunaTextBoxCodeFacture.Visible = False
        '
        'GunaTextBoxParent
        '
        Me.GunaTextBoxParent.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxParent.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxParent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxParent.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxParent.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxParent.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxParent.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxParent.Location = New System.Drawing.Point(804, 4)
        Me.GunaTextBoxParent.Name = "GunaTextBoxParent"
        Me.GunaTextBoxParent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxParent.SelectedText = ""
        Me.GunaTextBoxParent.Size = New System.Drawing.Size(107, 26)
        Me.GunaTextBoxParent.TabIndex = 10
        Me.GunaTextBoxParent.Text = "GunaTextBox1"
        Me.GunaTextBoxParent.Visible = False
        '
        'GunaImageButton2
        '
        Me.GunaImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton2.Image = CType(resources.GetObject("GunaImageButton2.Image"), System.Drawing.Image)
        Me.GunaImageButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton2.Location = New System.Drawing.Point(1032, 7)
        Me.GunaImageButton2.Name = "GunaImageButton2"
        Me.GunaImageButton2.OnHoverImage = Nothing
        Me.GunaImageButton2.OnHoverImageOffset = New System.Drawing.Point(0, 0)
        Me.GunaImageButton2.Size = New System.Drawing.Size(27, 21)
        Me.GunaImageButton2.TabIndex = 9
        '
        'GunaImageButton1
        '
        Me.GunaImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaImageButton1.Image = Nothing
        Me.GunaImageButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaImageButton1.Location = New System.Drawing.Point(1025, 6)
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
        Me.Panel4.Location = New System.Drawing.Point(0, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(135, 30)
        Me.Panel4.TabIndex = 2
        '
        'GunaLabelGestCompany
        '
        Me.GunaLabelGestCompany.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GunaLabelGestCompany.AutoSize = True
        Me.GunaLabelGestCompany.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabelGestCompany.Location = New System.Drawing.Point(356, 6)
        Me.GunaLabelGestCompany.Name = "GunaLabelGestCompany"
        Me.GunaLabelGestCompany.Size = New System.Drawing.Size(282, 21)
        Me.GunaLabelGestCompany.TabIndex = 1
        Me.GunaLabelGestCompany.Text = "MODULE DE PRISE DES COMMANDES"
        Me.GunaLabelGestCompany.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaButtonRestaurant
        '
        Me.GunaButtonRestaurant.AnimationHoverSpeed = 0.07!
        Me.GunaButtonRestaurant.AnimationSpeed = 0.03!
        Me.GunaButtonRestaurant.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonRestaurant.BaseColor = System.Drawing.Color.MediumVioletRed
        Me.GunaButtonRestaurant.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonRestaurant.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonRestaurant.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonRestaurant.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonRestaurant.ForeColor = System.Drawing.Color.White
        Me.GunaButtonRestaurant.Image = CType(resources.GetObject("GunaButtonRestaurant.Image"), System.Drawing.Image)
        Me.GunaButtonRestaurant.ImageSize = New System.Drawing.Size(35, 35)
        Me.GunaButtonRestaurant.Location = New System.Drawing.Point(149, 7)
        Me.GunaButtonRestaurant.Name = "GunaButtonRestaurant"
        Me.GunaButtonRestaurant.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonRestaurant.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonRestaurant.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonRestaurant.OnHoverImage = Nothing
        Me.GunaButtonRestaurant.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonRestaurant.Radius = 5
        Me.GunaButtonRestaurant.Size = New System.Drawing.Size(114, 33)
        Me.GunaButtonRestaurant.TabIndex = 14
        Me.GunaButtonRestaurant.Text = "REPAS"
        Me.GunaButtonRestaurant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaButtonBar
        '
        Me.GunaButtonBar.AnimationHoverSpeed = 0.07!
        Me.GunaButtonBar.AnimationSpeed = 0.03!
        Me.GunaButtonBar.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonBar.BaseColor = System.Drawing.Color.DarkSlateGray
        Me.GunaButtonBar.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonBar.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonBar.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonBar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButtonBar.ForeColor = System.Drawing.Color.White
        Me.GunaButtonBar.Image = CType(resources.GetObject("GunaButtonBar.Image"), System.Drawing.Image)
        Me.GunaButtonBar.ImageSize = New System.Drawing.Size(33, 30)
        Me.GunaButtonBar.Location = New System.Drawing.Point(15, 7)
        Me.GunaButtonBar.Name = "GunaButtonBar"
        Me.GunaButtonBar.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonBar.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonBar.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonBar.OnHoverImage = Nothing
        Me.GunaButtonBar.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonBar.Radius = 5
        Me.GunaButtonBar.Size = New System.Drawing.Size(114, 32)
        Me.GunaButtonBar.TabIndex = 15
        Me.GunaButtonBar.Text = "BOISSONS"
        Me.GunaButtonBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PanelLeftPanel
        '
        Me.PanelLeftPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelLeftPanel.Location = New System.Drawing.Point(6, 95)
        Me.PanelLeftPanel.Name = "PanelLeftPanel"
        Me.PanelLeftPanel.Size = New System.Drawing.Size(1053, 62)
        Me.PanelLeftPanel.TabIndex = 0
        '
        'GunaLabel1
        '
        Me.GunaLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabel1.Location = New System.Drawing.Point(754, 527)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(16, 21)
        Me.GunaLabel1.TabIndex = 17
        Me.GunaLabel1.Text = "-"
        '
        'GunaShadowPanel1
        '
        Me.GunaShadowPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaShadowPanel1.BaseColor = System.Drawing.Color.White
        Me.GunaShadowPanel1.Controls.Add(Me.Label3)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaButtonPanier)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaButtonBar)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaButtonRestaurant)
        Me.GunaShadowPanel1.Controls.Add(Me.Label21)
        Me.GunaShadowPanel1.Controls.Add(Me.Panel2)
        Me.GunaShadowPanel1.Controls.Add(Me.Panel3)
        Me.GunaShadowPanel1.Controls.Add(Me.Panel1)
        Me.GunaShadowPanel1.Controls.Add(Me.Label22)
        Me.GunaShadowPanel1.Controls.Add(Me.Label2)
        Me.GunaShadowPanel1.Location = New System.Drawing.Point(12, 39)
        Me.GunaShadowPanel1.Name = "GunaShadowPanel1"
        Me.GunaShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.GunaShadowPanel1.Size = New System.Drawing.Size(1030, 50)
        Me.GunaShadowPanel1.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(990, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(20, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "0"
        '
        'GunaButtonPanier
        '
        Me.GunaButtonPanier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonPanier.AnimationHoverSpeed = 0.07!
        Me.GunaButtonPanier.AnimationSpeed = 0.03!
        Me.GunaButtonPanier.BaseColor = System.Drawing.Color.Transparent
        Me.GunaButtonPanier.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonPanier.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonPanier.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonPanier.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButtonPanier.ForeColor = System.Drawing.Color.White
        Me.GunaButtonPanier.Image = CType(resources.GetObject("GunaButtonPanier.Image"), System.Drawing.Image)
        Me.GunaButtonPanier.ImageSize = New System.Drawing.Size(45, 35)
        Me.GunaButtonPanier.Location = New System.Drawing.Point(927, 7)
        Me.GunaButtonPanier.Name = "GunaButtonPanier"
        Me.GunaButtonPanier.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.GunaButtonPanier.OnHoverBorderColor = System.Drawing.Color.Transparent
        Me.GunaButtonPanier.OnHoverForeColor = System.Drawing.Color.Transparent
        Me.GunaButtonPanier.OnHoverImage = Nothing
        Me.GunaButtonPanier.OnPressedColor = System.Drawing.Color.Transparent
        Me.GunaButtonPanier.Size = New System.Drawing.Size(63, 37)
        Me.GunaButtonPanier.TabIndex = 325
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(285, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 15)
        Me.Label21.TabIndex = 324
        Me.Label21.Text = "BOISSON :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Coral
        Me.Panel2.Controls.Add(Me.LabelTotalVenteRepas)
        Me.Panel2.Location = New System.Drawing.Point(569, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(123, 24)
        Me.Panel2.TabIndex = 323
        '
        'LabelTotalVenteRepas
        '
        Me.LabelTotalVenteRepas.AutoSize = True
        Me.LabelTotalVenteRepas.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalVenteRepas.Location = New System.Drawing.Point(21, 1)
        Me.LabelTotalVenteRepas.Name = "LabelTotalVenteRepas"
        Me.LabelTotalVenteRepas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelTotalVenteRepas.Size = New System.Drawing.Size(20, 22)
        Me.LabelTotalVenteRepas.TabIndex = 0
        Me.LabelTotalVenteRepas.Text = "0"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Wheat
        Me.Panel3.Controls.Add(Me.LabelTotalVenteBoisson)
        Me.Panel3.Location = New System.Drawing.Point(370, 11)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(123, 24)
        Me.Panel3.TabIndex = 322
        '
        'LabelTotalVenteBoisson
        '
        Me.LabelTotalVenteBoisson.AutoSize = True
        Me.LabelTotalVenteBoisson.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalVenteBoisson.Location = New System.Drawing.Point(29, 1)
        Me.LabelTotalVenteBoisson.Name = "LabelTotalVenteBoisson"
        Me.LabelTotalVenteBoisson.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelTotalVenteBoisson.Size = New System.Drawing.Size(20, 22)
        Me.LabelTotalVenteBoisson.TabIndex = 0
        Me.LabelTotalVenteBoisson.Text = "0"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGreen
        Me.Panel1.Controls.Add(Me.LabelTotal)
        Me.Panel1.Location = New System.Drawing.Point(767, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(123, 24)
        Me.Panel1.TabIndex = 323
        '
        'LabelTotal
        '
        Me.LabelTotal.AutoSize = True
        Me.LabelTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.Location = New System.Drawing.Point(21, 1)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelTotal.Size = New System.Drawing.Size(20, 22)
        Me.LabelTotal.TabIndex = 0
        Me.LabelTotal.Text = "0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(502, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 15)
        Me.Label22.TabIndex = 321
        Me.Label22.Text = "REPAS :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(701, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 321
        Me.Label2.Text = "TOTAL :"
        '
        'GunaPanel1
        '
        Me.GunaPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaPanel1.AutoScroll = True
        Me.GunaPanel1.AutoScrollMinSize = New System.Drawing.Size(1020, 359)
        Me.GunaPanel1.BackColor = System.Drawing.Color.White
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 163)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1064, 349)
        Me.GunaPanel1.TabIndex = 325
        '
        'GunaButtonPrecedent
        '
        Me.GunaButtonPrecedent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonPrecedent.AnimationHoverSpeed = 0.07!
        Me.GunaButtonPrecedent.AnimationSpeed = 0.03!
        Me.GunaButtonPrecedent.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonPrecedent.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonPrecedent.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonPrecedent.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonPrecedent.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonPrecedent.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.GunaButtonPrecedent.ForeColor = System.Drawing.Color.White
        Me.GunaButtonPrecedent.Image = CType(resources.GetObject("GunaButtonPrecedent.Image"), System.Drawing.Image)
        Me.GunaButtonPrecedent.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonPrecedent.Location = New System.Drawing.Point(367, 528)
        Me.GunaButtonPrecedent.Name = "GunaButtonPrecedent"
        Me.GunaButtonPrecedent.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonPrecedent.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonPrecedent.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonPrecedent.OnHoverImage = Nothing
        Me.GunaButtonPrecedent.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonPrecedent.Radius = 5
        Me.GunaButtonPrecedent.Size = New System.Drawing.Size(114, 21)
        Me.GunaButtonPrecedent.TabIndex = 0
        Me.GunaButtonPrecedent.Text = "Précédent"
        Me.GunaButtonPrecedent.Visible = False
        '
        'GunaButtonSuivant
        '
        Me.GunaButtonSuivant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaButtonSuivant.AnimationHoverSpeed = 0.07!
        Me.GunaButtonSuivant.AnimationSpeed = 0.03!
        Me.GunaButtonSuivant.BackColor = System.Drawing.Color.Transparent
        Me.GunaButtonSuivant.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonSuivant.BorderColor = System.Drawing.Color.Black
        Me.GunaButtonSuivant.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButtonSuivant.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButtonSuivant.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.GunaButtonSuivant.ForeColor = System.Drawing.Color.White
        Me.GunaButtonSuivant.Image = CType(resources.GetObject("GunaButtonSuivant.Image"), System.Drawing.Image)
        Me.GunaButtonSuivant.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButtonSuivant.Location = New System.Drawing.Point(507, 528)
        Me.GunaButtonSuivant.Name = "GunaButtonSuivant"
        Me.GunaButtonSuivant.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButtonSuivant.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButtonSuivant.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButtonSuivant.OnHoverImage = Nothing
        Me.GunaButtonSuivant.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButtonSuivant.Radius = 5
        Me.GunaButtonSuivant.Size = New System.Drawing.Size(114, 21)
        Me.GunaButtonSuivant.TabIndex = 0
        Me.GunaButtonSuivant.Text = "Suivant"
        Me.GunaButtonSuivant.Visible = False
        '
        'GunaLabelPagination
        '
        Me.GunaLabelPagination.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GunaLabelPagination.AutoSize = True
        Me.GunaLabelPagination.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GunaLabelPagination.Location = New System.Drawing.Point(75, 528)
        Me.GunaLabelPagination.Name = "GunaLabelPagination"
        Me.GunaLabelPagination.Size = New System.Drawing.Size(16, 21)
        Me.GunaLabelPagination.TabIndex = 17
        Me.GunaLabelPagination.Text = "-"
        '
        'CustomCommandForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1064, 552)
        Me.Controls.Add(Me.GunaLabelPagination)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaButtonSuivant)
        Me.Controls.Add(Me.GunaButtonPrecedent)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaShadowPanel1)
        Me.Controls.Add(Me.PanelLeftPanel)
        Me.Controls.Add(Me.GunaLinePanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CustomCommandForm"
        Me.Text = "CustomCommandForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GunaLinePanelTop.ResumeLayout(False)
        Me.GunaLinePanelTop.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GunaShadowPanel1.ResumeLayout(False)
        Me.GunaShadowPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaLinePanelTop As Guna.UI.WinForms.GunaLinePanel
    Friend WithEvents GunaImageButton2 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents GunaImageButton1 As Guna.UI.WinForms.GunaImageButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GunaLabelGestCompany As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonRestaurant As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonBar As Guna.UI.WinForms.GunaButton
    Friend WithEvents PanelLeftPanel As Panel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaShadowPanel1 As Guna.UI.WinForms.GunaShadowPanel
    Friend WithEvents LabelTotalVenteBoisson As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelTotalVenteRepas As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelTotal As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaButtonPrecedent As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButtonSuivant As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaTextBoxParent As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabelPagination As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButtonPanier As Guna.UI.WinForms.GunaButton
    Friend WithEvents Label3 As Label
    Friend WithEvents GunaTextBoxCodeFacture As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
End Class
