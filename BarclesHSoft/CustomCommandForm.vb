Imports MySql.Data.MySqlClient
Imports System.IO

Public Class CustomCommandForm

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonBar_Click(sender As Object, e As EventArgs) Handles GunaButtonBar.Click

        PanelLeftPanel.Controls.Clear()


        GlobalVariable.ArticleFamily = "BAR"

        Dim PARENT As String = "BOISSONS"

        Dim Famille As DataTable = Functions.GetAllElementsOnCondition(PARENT, "sous_famille", "CODE_FAMILLE_PARENT")

        Dim panelColor As Color = Color.DarkSlateGray

        If (Famille.Rows.Count > 0) Then
            familleDesArticles(Famille, panelColor)
        End If

    End Sub

    Private Sub GunaButtonRestaurant_Click(sender As Object, e As EventArgs) Handles GunaButtonRestaurant.Click

        PanelLeftPanel.Controls.Clear()

        GlobalVariable.ArticleFamily = "RESTAURANT"
        Dim PARENT As String = "ALIMENTS(REPAS)"

        Dim Famille As DataTable = Functions.GetAllElementsOnCondition(PARENT, "sous_famille", "CODE_FAMILLE_PARENT")

        Dim panelColor As Color = Color.MediumVioletRed

        If (Famille.Rows.Count > 0) Then
            familleDesArticles(Famille, panelColor)
        End If

    End Sub

    Public Sub familleDesArticles(ByVal familleArticleList As DataTable, ByVal panelColor As Color)

        Dim xValue As Integer = 0

        Dim yValue As Integer = 0

        If familleArticleList.Rows.Count > 0 Then

            For i As Integer = 0 To familleArticleList.Rows.Count - 1 Step 1

                Dim nomArticle As String = ""
                Dim codeArticle As String = ""

                Dim toolTip As New ToolTip()

                Dim buttonColor As Color = panelColor
                Dim textColor As Color = Color.White
                Dim ClientInRoom As DataTable

                textColor = Color.Black

                Dim customPanel As New Panel
                customPanel.Text = "Test" & i
                customPanel.Name = "a" & i
                customPanel.Location = New Point(12 + xValue, 5 + yValue)
                customPanel.BackColor = buttonColor
                customPanel.ForeColor = textColor
                'customPanel.Size = New Size(75, 103)
                customPanel.Size = New Size(145, 25)
                customPanel.Anchor = AnchorStyles.None

                Dim customLabel As New Label

                customLabel.AutoSize = True
                customLabel.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                customLabel.Location = New System.Drawing.Point(5, 35)
                customLabel.Name = "customLabel"
                customLabel.Size = New System.Drawing.Size(108, 20)
                customLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                customLabel.TabIndex = 4

                customLabel.Text = familleArticleList.Rows(i)("LIBELLE_SOUS_FAMILLE")

                customPanel.Controls.Add(customLabel)

                '-----------------------------------------------------------------------------------------------------

                Dim customButton As New Button

                'customButton.AnimationHoverSpeed = 0.07!
                'customButton.AnimationSpeed = 0.03!
                customButton.FlatStyle = FlatStyle.Flat
                customButton.BackColor = buttonColor
                'customButton.BorderColor = System.Drawing.Color.Black
                customButton.DialogResult = System.Windows.Forms.DialogResult.None
                'customButton.FocusedColor = System.Drawing.Color.Empty
                customButton.Font = New System.Drawing.Font("Segoe UI", 10.0!)
                customButton.ForeColor = System.Drawing.Color.White

                'End If
                customButton.Image = Nothing
                customButton.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'customButton.ImageSize = New System.Drawing.Size(52, 52)
                customButton.Location = New System.Drawing.Point(0, 0)
                customButton.Name = familleArticleList.Rows(i)("LIBELLE_SOUS_FAMILLE")
                customButton.Size = New System.Drawing.Size(145, 25)
                customButton.TabIndex = 3
                customButton.Text = familleArticleList.Rows(i)("LIBELLE_SOUS_FAMILLE")
                customButton.TextAlign = System.Drawing.ContentAlignment.TopCenter

                'POUR CHACUNE DES CHAMBRES ON POSE UN EVENEMENT DE TYPE CLICK

                AddHandler customButton.Click, AddressOf onClick
                AddHandler customPanel.Click, AddressOf onClick

                customPanel.Controls.Add(customButton)

                PanelLeftPanel.Controls.Add(customPanel)

                toolTip.ShowAlways = True

                toolTip.UseFading = True
                toolTip.UseAnimation = True
                toolTip.IsBalloon = True
                toolTip.AutoPopDelay = 5000

                xValue = xValue + 150

                If (i + 1) Mod 9 = 0 Then
                    xValue = 0
                    yValue = yValue + 30
                End If

            Next

        End If

    End Sub


    Public Sub sousfamilleDesArticles(ByVal familleArticleList As DataTable, ByVal panelColor As Color)

        Dim xValue As Integer = 300

        Dim yValue As Integer = 0

        If familleArticleList.Rows.Count > 0 Then

            For i As Integer = 0 To familleArticleList.Rows.Count - 1 Step 1

                Dim nomArticle As String = ""
                Dim codeArticle As String = ""

                Dim toolTip As New ToolTip()

                Dim buttonColor As Color = panelColor
                Dim textColor As Color = Color.White
                Dim ClientInRoom As DataTable

                textColor = Color.Black

                Dim customPanel As New Panel
                customPanel.Text = "Test" & i
                customPanel.Name = "a" & i
                customPanel.Location = New Point(12 + xValue, 5 + yValue)
                customPanel.BackColor = buttonColor
                customPanel.ForeColor = textColor
                'customPanel.Size = New Size(75, 103)
                customPanel.Size = New Size(145, 25)
                customPanel.Anchor = AnchorStyles.None

                Dim customLabel As New Label

                customLabel.AutoSize = True
                customLabel.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                customLabel.Location = New System.Drawing.Point(5, 35)
                customLabel.Name = "customLabel"
                customLabel.Size = New System.Drawing.Size(108, 20)
                customLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                customLabel.TabIndex = 4

                customLabel.Text = familleArticleList.Rows(i)("LIBELLE_FAMILLE")

                customPanel.Controls.Add(customLabel)

                'customLabel.Text = ""
                'NOM DE LA PERSONNE DEVANT NETTOYER ------------------------------------------

                Dim customPanel1 As New Panel
                customPanel1.Text = "Test1" & i
                customPanel1.Name = "a1" & i
                customPanel1.Location = New Point(5 + xValue, 35 + yValue)
                customPanel1.BackColor = buttonColor
                customPanel1.ForeColor = textColor
                'customPanel.Size = New Size(75, 103)
                customPanel1.Size = New Size(108, 50)
                customPanel1.Anchor = AnchorStyles.None


                '-----------------------------------------------------------------------------------------------------

                Dim customButton As New Button

                'customButton.AnimationHoverSpeed = 0.07!
                'customButton.AnimationSpeed = 0.03!
                customButton.FlatStyle = FlatStyle.Flat
                customButton.BackColor = buttonColor
                'customButton.BorderColor = System.Drawing.Color.Black
                customButton.DialogResult = System.Windows.Forms.DialogResult.None
                'customButton.FocusedColor = System.Drawing.Color.Empty
                customButton.Font = New System.Drawing.Font("Segoe UI", 10.0!)
                customButton.ForeColor = System.Drawing.Color.White

                customButton.Image = Nothing
                customButton.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'customButton.ImageSize = New System.Drawing.Size(52, 52)
                customButton.Location = New System.Drawing.Point(0, 0)
                customButton.Name = familleArticleList.Rows(i)("LIBELLE_FAMILLE")
                customButton.Size = New System.Drawing.Size(145, 25)
                customButton.TabIndex = 3
                customButton.Text = familleArticleList.Rows(i)("LIBELLE_FAMILLE")
                customButton.TextAlign = System.Drawing.ContentAlignment.TopCenter

                'POUR CHACUNE DES CHAMBRES ON POSE UN EVENEMENT DE TYPE CLICK

                AddHandler customButton.Click, AddressOf onClick
                AddHandler customPanel.Click, AddressOf onClick

                customPanel.Controls.Add(customButton)

                PanelLeftPanel.Controls.Add(customPanel)

                toolTip.ShowAlways = True

                toolTip.UseFading = True
                toolTip.UseAnimation = True
                toolTip.IsBalloon = True
                toolTip.AutoPopDelay = 5000

                xValue = xValue + 150
                yValue = 0

            Next

        End If

    End Sub

    Private Sub affichageDesPictogrammes(ByVal article As DataTable)

        Dim xValue As Integer = 0
        Dim yValue As Integer = 0

        If article.Rows.Count > 0 Then

            If nombreDePageMax = 1 Then
                GunaButtonSuivant.Visible = False
            Else
                GunaButtonSuivant.Visible = True
            End If

            Dim apartirDe As Integer = 0
            Dim nbreArticleTotal As Integer = article.Rows.Count
            Dim maxAAfficher As Integer = 0

            If numeroDePage = 1 Then
                apartirDe = 0
            Else

                If numeroDePage = 2 Then
                    apartirDe = nbreTotalParPage
                Else
                    apartirDe = nbreTotalParPage * (numeroDePage - 1)
                End If

            End If

            'ON DOIT SAVOIR SI ON SE TROUVE DEJA SUR LA DERNIERE PAGE

            maxAAfficher = nbreTotalParPage * numeroDePage

            If numeroDePage = nombreDePageMax Then
                maxAAfficher = nbreArticleTotal
            End If

            ' i As Integer =  - 2 Step 1
            ' i As Integer = apartirDe To maxAAfficher - 1 Step 1
            ' i As Integer = 0 To article.Rows.Count - 1 Step 1

            For i As Integer = apartirDe To maxAAfficher - 1 Step 1

                Dim nomCLient As String = ""
                Dim emailCLient As String = ""

                Dim toolTip As New ToolTip()

                Dim buttonColor As Color
                Dim ClientInRoom As DataTable

                ' --------------------------------------------------------------------------------------------
                Dim customPanel As New Panel
                customPanel.Text = "Test" & i
                customPanel.Name = "a" & i
                customPanel.Location = New Point(45 + xValue, 5 + yValue)
                'customPanel.BackColor = Color.White
                'customPanel.Size = New Size(75, 103)
                customPanel.Size = New Size(170, 180)
                customPanel.Anchor = Anchor.Top
                customPanel.Anchor = AnchorStyles.None

                'Dim customPictureBox = New Guna.UI.WinForms.GunaCirclePictureBox
                Dim customPictureBox = New PictureBox

                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.ROOM_STATE_FREE

                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.FREE_ROOM

                '------------------------------------------------------------

                If Not IsDBNull(article.Rows(i)("IMAGE_1")) Then 'IMAGE DEPUIS VBNET

                    Dim img() As Byte
                    img = article.Rows(i)("IMAGE_1")

                    Dim mStream As New MemoryStream(img)

                    If mStream.Length > 0 Then
                        customPictureBox.Image = Image.FromStream(mStream)
                    End If

                End If

                '------------------------------------------------------------
                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.FREE_ROOM

                AddHandler customPictureBox.DoubleClick, AddressOf onDoubleClick

                'customPictureBox.Location = New System.Drawing.Point(3, 18)
                customPictureBox.Location = New System.Drawing.Point(4, -8)
                customPictureBox.Name = article.Rows(i)("CODE_ARTICLE")
                customPictureBox.Size = New System.Drawing.Size(120, 120)
                customPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
                customPictureBox.TabIndex = 2
                customPictureBox.TabStop = False
                customPictureBox.Anchor = Anchor.Top
                'customPictureBox.BackColor = Color.Red

                customPanel.Controls.Add(customPictureBox)

                'GunaPanel1.Controls.Add(customPanel)

                Dim customLabel As New Label

                customLabel.AutoSize = True
                customLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'customLabel.Location = New System.Drawing.Point(13, 0)
                customLabel.Location = New System.Drawing.Point(0, 116)
                customLabel.Name = article.Rows(i)("DESIGNATION_FR")
                customLabel.Size = New System.Drawing.Size(25, 25)
                customLabel.TabIndex = 4
                customLabel.Text = article.Rows(i)("DESIGNATION_FR")

                customPanel.Controls.Add(customLabel)

                Dim customLabel_ As New Label

                customLabel_.AutoSize = True
                customLabel_.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'customLabel.Location = New System.Drawing.Point(13, 0)
                customLabel_.Location = New System.Drawing.Point(0, 130)
                customLabel_.Name = article.Rows(i)("DESIGNATION_FR")
                customLabel_.ForeColor = Color.OrangeRed
                customLabel_.Size = New System.Drawing.Size(25, 20)
                customLabel_.TabIndex = 4
                customLabel_.Text = Format(article.Rows(i)("PRIX_VENTE_HT"), "#,##0") & " F"

                customPanel.Controls.Add(customLabel_)

                Dim customButtonAdd As New Button

                customButtonAdd.DialogResult = System.Windows.Forms.DialogResult.None

                customButtonAdd.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                customButtonAdd.ForeColor = System.Drawing.Color.White
                customButtonAdd.BackColor = System.Drawing.Color.Indigo
                customButtonAdd.Image = Nothing
                customButtonAdd.Location = New System.Drawing.Point(60, 150)
                customButtonAdd.Name = article.Rows(i)("CODE_ARTICLE")
                customButtonAdd.TabIndex = 3
                customButtonAdd.Text = "Ajouter"
                customButtonAdd.Size = New Size(75, 30)

                customPanel.Controls.Add(customButtonAdd)

                AddHandler customButtonAdd.Click, AddressOf onClickAdd

                Dim number As New NumericUpDown

                number.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                number.ForeColor = System.Drawing.Color.Black
                number.Location = New System.Drawing.Point(0, 152)
                number.Name = "NumericUpDown" & article.Rows(i)("CODE_ARTICLE")
                number.TabIndex = 3
                number.Text = "1"
                number.Minimum = 1
                number.Visible = False
                number.Size = New Size(50, 20)

                customPanel.Controls.Add(number)

                GunaPanel1.Controls.Add(customPanel)

                Dim panneau As Integer = 0

                panneau = Math.Floor((i + 1) / 24)

                toolTip.ShowAlways = True

                toolTip.UseFading = True
                toolTip.UseAnimation = True
                toolTip.IsBalloon = True
                toolTip.AutoPopDelay = 5000

                xValue = xValue + 180

                If (i + 1) Mod 7 = 0 Then
                    xValue = 0
                    yValue = yValue + 185
                End If

            Next

            GunaPanel1.BringToFront()

            If apartirDe = 0 Then
                numeroDePage = 1
            End If

        Else

            GunaButtonSuivant.Visible = False

        End If

    End Sub

    Private Sub onDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)



    End Sub

    Dim nombreTotalArticle As Integer = 0

    Private Sub onClickAdd(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim btn As Button = CType(sender, Button)

        Dim CODE_ARTICLE As String = btn.Name

        PanierForm.GunaTextBoxCodeArticle.Text = btn.Name
        PanierForm.GunaTextBoxCodeFacture.Text = GunaTextBoxCodeFacture.Text

        PanierForm.Show()
        PanierForm.TopMost = True

    End Sub

    Private Sub onClick(ByVal sender As Object, ByVal e As System.EventArgs)

        GunaPanel1.Controls.Clear()

        GunaPanel1.AutoScroll = True

        numeroDePage = 1
        nombreDePageMax = 1

        GlobalVariable.btnNettoyage = CType(sender, Button)
        Dim btn As Button = GlobalVariable.btnNettoyage
        'Dim sousFamille As String = btn.Name

        Dim sous_famille As String = btn.Name
        Dim Parent As String = btn.Name
        GunaTextBoxParent.Text = btn.Name

        Dim article As DataTable = Functions.GetAllElementsOnCondition(sous_famille, "article", "CODE_SOUS_FAMILLE")

        If article.Rows.Count > 0 Then

            nombreTotalArticle = article.Rows.Count
            nombreDePageMax = Math.Ceiling(nombreTotalArticle / nbreTotalParPage)

            If nombreDePageMax = 1 Then
                GunaButtonPrecedent.Visible = False
                GunaButtonSuivant.Visible = False

            Else

            End If

            GunaLabelPagination.Text = "Page " & numeroDePage & " / " & nombreDePageMax
            GunaLabel1.Text = btn.Name & " (" & article.Rows.Count & ")"

            'affichage des pictogrammes

            If sous_famille.Equals("DEJEUNERS/DINNERS") Then

                'ON DOIT ENCORE AFFICHER LES BOUTTONS POUR LES DIVERS CATEGORIES DE DEJUNERS/DINNERS

                Dim sousFamille As DataTable = Functions.GetAllElementsOnCondition(Parent, "sous_sous_famille", "CODE_FAMILLE_PARENT")

                Dim panelColor As Color = Color.LightBlue

                If (sousFamille.Rows.Count > 0) Then
                    sousfamilleDesArticles(sousFamille, panelColor)
                End If

            Else
                affichageDesPictogrammes(article)
            End If

        Else

            article = Functions.GetAllElementsOnCondition(Parent, "article", "CODE_SOUS_SOUS_FAMILLE")

            If article.Rows.Count > 0 Then

                nombreTotalArticle = article.Rows.Count
                nombreDePageMax = Math.Ceiling(nombreTotalArticle / nbreTotalParPage)

                If nombreDePageMax = 1 Then
                    GunaButtonPrecedent.Visible = False
                    GunaButtonSuivant.Visible = False

                Else

                End If

                GunaLabelPagination.Text = "Page " & numeroDePage & " / " & nombreDePageMax
                GunaLabel1.Text = btn.Name & " (" & article.Rows.Count & ")"

                affichageDesPictogrammes(article)

            Else
                nombreTotalArticle = 0
                nombreDePageMax = Math.Ceiling(nombreTotalArticle / nbreTotalParPage)
                If nombreDePageMax = 1 Then
                    GunaButtonPrecedent.Visible = False
                    GunaButtonSuivant.Visible = False

                Else

                End If
                GunaLabelPagination.Text = "Page " & numeroDePage & " / " & nombreDePageMax
                GunaLabel1.Text = btn.Name & " (" & 0 & ")"
            End If

            If nombreDePageMax = 1 Then
                GunaButtonPrecedent.Visible = False
                GunaButtonSuivant.Visible = False
            End If

        End If

        'L'ARTICLE A CE NIVEAU PERMET DE SUIVRE LES MOUVEMENTS OU ALORS A QUEL NIVEAU NOUS DEVONS AFFICHER LES ARTICLES
        articleSuivantPrecedent = article

    End Sub

    Dim articleSuivantPrecedent As DataTable

    Private Sub CustomCommandForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        GlobalVariable.typeDeClientAFacturer = "comptoir"

        GunaTextBoxCodeFacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture_bloc_note", "CL")

        GlobalVariable.ArticleFamily = "BAR"

        Dim PARENT As String = "BOISSONS"

        Dim Famille As DataTable = Functions.GetAllElementsOnCondition(PARENT, "sous_famille", "CODE_FAMILLE_PARENT")

        Dim panelColor As Color = Color.DarkSlateGray

        If (Famille.Rows.Count > 0) Then
            familleDesArticles(Famille, panelColor)
        End If

    End Sub

    Dim numeroDePage As Integer = 1
    Dim nombreDePageMax As Integer = 1
    Dim nbreTotalParPage As Integer = 21

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButtonSuivant.Click

        GunaPanel1.Controls.Clear()

        numeroDePage += 1

        affichageDesPictogrammes(articleSuivantPrecedent)

        If numeroDePage > 1 Then
            GunaButtonPrecedent.Visible = True
        Else
            GunaButtonPrecedent.Visible = False
        End If

        If numeroDePage = nombreDePageMax Then
            GunaButtonSuivant.Visible = False
        End If

        GunaLabelPagination.Text = "Page " & numeroDePage & " / " & nombreDePageMax

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonPrecedent.Click

        GunaPanel1.Controls.Clear()

        numeroDePage -= 1

        affichageDesPictogrammes(articleSuivantPrecedent)

        If numeroDePage > 1 Then
            GunaButtonSuivant.Visible = True
        Else

            GunaButtonSuivant.Visible = False

            If numeroDePage = 1 Then
                GunaButtonPrecedent.Visible = False
                GunaButtonSuivant.Visible = True
            End If

        End If

        GunaLabelPagination.Text = "Page " & numeroDePage & " / " & nombreDePageMax

    End Sub

    Private Sub GunaButtonPanier_Click(sender As Object, e As EventArgs) Handles GunaButtonPanier.Click

        PanierForm.GunaTextBoxCodeFacture.Text = GunaTextBoxCodeFacture.Text
        PanierForm.GunaPanelCommande.Visible = False

        PanierForm.Show()
        PanierForm.TopMost = True

    End Sub

    Public Sub keyInformation()

        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail
        Dim query As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',PRIX_UNITAIRE_TTC As 'UNIT PRICE', 
                ligne_facture_temp.QUANTITE AS QUANTITY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', GRIFFE_UTILISATEUR AS 'USER' 
                , CODE_LOT, TYPE_LIGNE_FACTURE FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC',
                ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR' 
                , CODE_LOT, TYPE_LIGNE_FACTURE FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"

        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = GunaTextBoxCodeFacture.Text

        Dim table As New DataTable()

        adapter.Fill(table)

        Dim montalToalDesBoissons As Double = 0
        Dim montalToTalRepas As Double = 0
        Dim qteArticle As Integer = 0

        If table.Rows.Count > 0 Then

            For i = 0 To table.Rows.Count - 1

                qteArticle += table.Rows(i)("QUANTITE")

                If table.Rows(i)("TYPE_LIGNE_FACTURE").Equals("BAR") Then
                    montalToalDesBoissons += table.Rows(i)("MONTANT TTC")
                ElseIf table.Rows(i)("TYPE_LIGNE_FACTURE").Equals("RESTAURANT") Then
                    montalToTalRepas += table.Rows(i)("MONTANT TTC")
                End If
            Next

            Label3.Text = "(" & qteArticle & ")"

        End If

        LabelTotalVenteBoisson.Text = Format(montalToalDesBoissons, "#,##0")
        LabelTotalVenteRepas.Text = Format(montalToTalRepas, "#,##0")

        Dim montantTotal As Double = montalToalDesBoissons + montalToTalRepas

        LabelTotal.Text = Format(montantTotal, "#,##0")

    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click

        AccueilForm.Show()
        AccueilForm.TopMost = True

        Me.Close()

    End Sub

    Private Sub GunaPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class