Imports System.IO
Imports MySql.Data.MySqlClient

Public Class MainWindowCuisineForm
    Private Sub MainWindowCuisineForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim langue As New Languages
        langue.article(GlobalVariable.actualLanguageValue)
        langue.side_menu_kitchen_form(GlobalVariable.actualLanguageValue)

        langue.mainwindowCuisine(GlobalVariable.actualLanguageValue)

        If GlobalVariable.softwareVersion = "barcleshsoftdbdemo" Then
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") + " (DEMO) "
        ElseIf GlobalVariable.softwareVersion = "barcleshsoftdb" Then
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        End If

        Dim menuAccess As New AccessRight()

        menuAccess.accesAuxModules(GlobalVariable.DroitAccesDeUtilisateurConnect, ReceptionToolStripMenuItem, RESERVATIONToolStripMenuItem, SERVICEDETAGEToolStripMenuItem, BarRestaurationToolStripMenuItem, ComptabilitéToolStripMenuItem, ECONOMATToolStripMenuItem, TECHNIQUEToolStripMenuItem, CUISINEToolStripMenuItem)

        menuAccess.administrationDuModuleCuisine(GlobalVariable.DroitAccesDeUtilisateurConnect, ToolStripMenuItemSession, ToolStripMenuItemConfig, ToolStripMenuItemServTech, ToolStripMenuItemSecurite)

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail

        affichageDeArticleForm()

        ArticleForm.TabControlArticle.SelectedIndex = 5

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then
            GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
        End If

        GunaComboBoxEntreSortie.SelectedIndex = 0

        GunaDateTimePicker1.Value = GlobalVariable.DateDeTravail
        GunaDateTimePicker2.Value = GlobalVariable.DateDeTravail

        'Functions.magasinActuelEtShiftDunUtilisateur()

        If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 1 Then
            ReceptionToolStripMenuItem.Visible = False
            RESERVATIONToolStripMenuItem.Visible = False
            SERVICEDETAGEToolStripMenuItem.Visible = False
            TECHNIQUEToolStripMenuItem.Visible = False
            ToolStripMenuItemServTech.Visible = False
        End If

    End Sub

    Private Sub affichageDeArticleForm()

        BonApprovisionnementForm.Close()
        ArticleForm.Close()
        ArticleForm.Show()
        ArticleForm.Location = New Point(50, 110)
        ArticleForm.TopMost = True

        ArticleForm.informationUtiles()
        ArticleForm.GunaImageButton4.Visible = True
        ArticleForm.GunaButtonAfficherLesFacturesEtReglement.Visible = False

    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click

        Functions.exitApplicationThread()

    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaAdvenceButtonMatiere_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonMatiere.Click
        GlobalVariable.typeArticle = "matiere"
        affichageDeArticleForm()
        ArticleForm.TabControlArticle.SelectedIndex = 0
    End Sub

    Private Sub GunaAdvenceButton20_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton20.Click
        GlobalVariable.typeArticle = "article"
        affichageDeArticleForm()
        ArticleForm.TabControlArticle.SelectedIndex = 0
    End Sub

    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        GlobalVariable.typeArticle = "matiere"
        ArticleForm.GunaDataGridViewArticle.Columns.Clear()
        affichageDeArticleForm()
        ArticleForm.TabControlArticle.SelectedIndex = 1
    End Sub

    Private Sub GunaAdvenceButton26_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton26.Click
        GlobalVariable.typeArticle = "article"
        ArticleForm.GunaDataGridViewArticle.Columns.Clear()
        affichageDeArticleForm()
        ArticleForm.TabControlArticle.SelectedIndex = 1
    End Sub

    Private Sub GunaAdvenceButton18_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton18.Click
        GlobalVariable.ficheTechnique = "fiche"
        affichageDeArticleForm()
        ArticleForm.TabControlArticle.SelectedIndex = 2
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        GlobalVariable.ficheTechnique = "fiche"
        affichageDeArticleForm()
        ArticleForm.TabControlArticle.SelectedIndex = 3
    End Sub

    Private Sub GunaAdvenceButtonCommande_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonCommande.Click
        affichageDeArticleForm()

        ArticleForm.TabControlArticle.SelectedIndex = 5
    End Sub

    Private Sub TimerToRefreshClock_Tick(sender As Object, e As EventArgs) Handles TimerToRefreshClock.Tick

        ArticleForm.commandePrepare()
        ArticleForm.commandeEncoursDePreparation()
        ArticleForm.informationUtiles()

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then
            GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
        Else

        End If

    End Sub

    'CUISINE

    Dim page As Integer = 1

    Private Sub ReceptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceptionToolStripMenuItem.Click

        MainWindow.GunaDataGridViewResaDashBoard.Columns.Clear()

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()

        MainWindow.ReinitialisationDesDates()

        Me.Activate()

        MainWindow.GunaGroupBoxRoomStatus.Controls.Clear()
        'PanelGraphiques.Controls.Clear()
        MainWindow.GunaGroupBoxStatistiques.Controls.Clear()
        MainWindow.elementsDesChambres()
        MainWindow.contenuStatistique()
        MainWindow.StatistiquesDesChambres()
        MainWindow.StatusDesChambres(page)

        'FacturationForm.Close()

        MainWindow.GunaShadowPanelReservation.Hide()
        MainWindow.PanelEnregistrement.Hide()

        MainWindow.PanelTableauDeBords.Show()
        MainWindow.GunaShadowPanelReception.Show()

        MainWindow.Show()

        ArticleForm.Close()

        Me.Close()

    End Sub

    Private Sub RESERVATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESERVATIONToolStripMenuItem.Click

        MainWindow.TabControlHbergement.SelectedIndex = 1
        MainWindow.GunaShadowPanelReception.Hide()
        MainWindow.PanelTableauDeBords.Hide()

        MainWindow.GunaShadowPanelReservation.Show()

        MainWindow.PanelEnregistrement.Show()

        MainWindow.Show()

        ArticleForm.Close()

        Me.Close()

    End Sub

    Private Sub SERVICEDETAGEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SERVICEDETAGEToolStripMenuItem.Click
        GlobalVariable.typeChambreOuSalle = "chambre"

        ArticleForm.Close()
        Me.Hide()

        MainWindowServiceEtageForm.Show()
    End Sub

    Private Sub BarRestaurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarRestaurationToolStripMenuItem.Click
        GlobalVariable.typeDeClientAFacturer = "comptoir"
        If Trim(GlobalVariable.AgenceActuelle.Rows(0)("CAISSE_ENREGISTREUSE_1")).Equals("") Then
            BarRestaurantForm.Close()
            BarRestaurantForm.Show()
            BarRestaurantForm.GunaLabelHeader.Text = "COMPTOIR"
        Else
            BarRestaurantCaisseEnregistreuseForm.Close()
            BarRestaurantCaisseEnregistreuseForm.Show()
            BarRestaurantCaisseEnregistreuseForm.GunaLabelHeader.Text = "COMPTOIR"
        End If

        Me.Close()
    End Sub

    Private Sub ComptabilitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComptabilitéToolStripMenuItem.Click
        MainWindowComptabiliteForm.Close()
        MainWindowComptabiliteForm.Visible = True
        ArticleForm.Close()
        Me.Visible = False
    End Sub

    Private Sub ECONOMATToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ECONOMATToolStripMenuItem.Click

        MainWindowEconomat.Show()
        ArticleForm.Close()
        Me.Visible = False

    End Sub

    Private Sub TECHNIQUEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TECHNIQUEToolStripMenuItem.Click
        MainWindowTechnique.Show()
        ArticleForm.Close()
        Me.Close()
    End Sub

    Private Sub ApprovisionnementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApprovisionnementToolStripMenuItem.Click

        BonApprovisionnementForm.Show()
        BonApprovisionnementForm.TopMost = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable

        '--------------------------------------------------------------------------------
        Dim getArticleQuery As String = "SELECT * FROM magasin WHERE LIBELLE_MAGASIN LIKE '%KITCHEN%' OR `LIBELLE_MAGASIN` LIKE '%CUISINE%'"

        '--------------------------------------------------------------------------------

        Dim str As String = ""

        BonApprovisionnementForm.GunaComboBoxTypeBordereau.SelectedIndex = 0

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            BonApprovisionnementForm.GunaComboBoxMagasinReception.DataSource = table
            BonApprovisionnementForm.GunaComboBoxMagasinReception.ValueMember = "CODE_MAGASIN"
            BonApprovisionnementForm.GunaComboBoxMagasinReception.DisplayMember = "LIBELLE_MAGASIN"

            BonApprovisionnementForm.GunaComboBoxMagasinReception.SelectedIndex = 0

        Else

        End If

        ArticleForm.Close()

    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click

        BonApprovisionnementForm.Show()
        BonApprovisionnementForm.TopMost = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable

        '--------------------------------------------------------------------------------
        Dim getArticleQuery As String = "SELECT * FROM magasin WHERE LIBELLE_MAGASIN LIKE '% CUISINE %'"

        '--------------------------------------------------------------------------------

        Dim str As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Clear()
            BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Add("Market List")
            BonApprovisionnementForm.GunaLabelTitreDeLaFenetreBonApp.Text = "MARKET LIST"

            getArticleQuery = "SELECT * FROM magasin WHERE LIBELLE_MAGASIN LIKE '%KITCHEN%' OR `LIBELLE_MAGASIN` LIKE '%CUISINE%'"

        Else

            BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Clear()
            BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.list_du_marche)
            BonApprovisionnementForm.GunaLabelTitreDeLaFenetreBonApp.Text = "LISTE DU MARCHE"

            getArticleQuery = "SELECT * FROM `magasin` WHERE `LIBELLE_MAGASIN` Like '%CUISINE%' OR LIBELLE_MAGASIN LIKE '%KITCHEN%'"

        End If

        BonApprovisionnementForm.GunaComboBoxTypeBordereau.SelectedIndex = 0

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            BonApprovisionnementForm.GunaComboBoxMagasinReception.DataSource = table
            BonApprovisionnementForm.GunaComboBoxMagasinReception.ValueMember = "CODE_MAGASIN"
            BonApprovisionnementForm.GunaComboBoxMagasinReception.DisplayMember = "LIBELLE_MAGASIN"

            BonApprovisionnementForm.GunaComboBoxMagasinReception.SelectedIndex = 0

        Else

        End If

        If GlobalVariable.actualLanguageValue = 0 Then
            BonApprovisionnementForm.LabelBon.Text = "MARKET LIST"
        Else
            BonApprovisionnementForm.LabelBon.Text = "LISTE DU MARCHE"
        End If

        If BonApprovisionnementForm.LabelBon.Text = "MARKET LIST" Or BonApprovisionnementForm.LabelBon.Text = "LISTE DU MARCHE" Then
            BonApprovisionnementForm.GunaTextBoxPassant.Visible = True
        Else
            BonApprovisionnementForm.GunaTextBoxPassant.Visible = False
        End If

        ArticleForm.Close()

    End Sub

    Private Sub ToolStripMenuItem119_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem119.Click

        'Dim dialog As DialogResult

        'If GlobalVariable.actualLanguageValue = 1 Then
        'dialog = MessageBox.Show("Voulez-vous vraiment fermer ", "Fermer BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'Else
        'dialog = MessageBox.Show("Do you really want to close your session ", "Close BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'End If

        'If dialog = DialogResult.No Then
        'e.Cancel = True
        'Else

        'Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

        'Dim CODE_CAISSE As String = ""

        'Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

        'If CAISSE_UTILISATEUR.Rows.Count > 0 Then

        'CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

        'End If

        ''Dim ETAT_CAISSE As Integer = 0
        'Dim caissier As New Caisse()

        'caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)


        'End If

        Dim Action As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            Action = "DECONNEXION DE " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")
        Else
            Action = "LOG OUT OF " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")
        End If

        User.mouchard(Action)

        HomeForm.Close()

        AccueilForm.Close()

        AccueilForm.Show()

        Me.Close()

    End Sub

    Private Sub ToolStripMenuItem117_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem117.Click
        GlobalVariable.changerMotDePasseDepuis = "cuisine"

        ChangePasswordForm.Show()
        ChangePasswordForm.TopMost = True
    End Sub

    Private Sub GunaLabelNotification_Click(sender As Object, e As EventArgs) Handles GunaLabelNotification.Click
        NotificationsForm.GunaTextBoxFromWhichWindow.Text = "cuisine"
        NotificationsForm.GunaLabelTitle.Text = "BOITE DE RECEPTION : MESSAGES NON LUS"

        NotificationsForm.TopMost = True
        NotificationsForm.Show()

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then

            NotificationsForm.GunaDataGridViewNotification.Columns.Clear()

            NotificationsForm.GunaDataGridViewNotification.DataSource = notifications

            NotificationsForm.GunaDataGridViewNotification.Columns("ID_NOTIFICATION").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_PROFIL").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_AGENCE").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("ETAT_NOTIFCATION").Visible = False

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then
            GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
        End If

    End Sub

    Public Function choixDuMagasin()

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable

        Dim getArticleQuery As String = "SELECT * FROM magasin WHERE LIBELLE_MAGASIN LIKE '%KITCHEN%' OR `LIBELLE_MAGASIN` LIKE '%CUISINE%'"

        Dim str As String = ""

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)
        Dim CODE_MAGASIN As String = ""
        If table.Rows.Count > 0 Then
            CODE_MAGASIN = table.Rows(0)("CODE_MAGASIN")
        End If

        Return CODE_MAGASIN

    End Function

    Private Sub GunaButtonInventaire_Click(sender As Object, e As EventArgs) Handles GunaButtonInventaire.Click

        Dim CODE_MAGASIN As String = choixDuMagasin()

        If Not Trim(CODE_MAGASIN).Equals("") Then
            Me.Cursor = Cursors.WaitCursor
            inventaireDesArticles(CODE_MAGASIN)
            Me.Cursor = Cursors.Default
        End If

        If GunaDataGridViewInventaire.Rows.Count > 0 Then
            GunaButtonImpressionDirecte.Visible = True
        Else
            GunaButtonImpressionDirecte.Visible = False
        End If

    End Sub


    Public Sub inventaireDesArticles(ByVal CODE_MAGASIN As String)

        Dim FillingListquery As String = "SELECT * FROM article ORDER BY DESIGNATION_FR ASC"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tousLesArticles As New DataTable()

        adapterList.Fill(tousLesArticles)

        GunaDataGridViewInventaire.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then

            GunaDataGridViewInventaire.Columns.Add("CODE_ARTICLE", "CODE ARTICLE")
            GunaDataGridViewInventaire.Columns.Add("LIBELLE", "ITEM")
            GunaDataGridViewInventaire.Columns.Add("QUANTITE_EN_STOCK", "STOCK")
            GunaDataGridViewInventaire.Columns.Add("QUANTITE_PHYSIQUE", "PHYSICAL QTY")
            GunaDataGridViewInventaire.Columns.Add("COUT_DU_STOCK", "STOCK COST")

        Else

            GunaDataGridViewInventaire.Columns.Add("CODE_ARTICLE", "CODE ARTICLE")
            GunaDataGridViewInventaire.Columns.Add("LIBELLE", "DESIGNATION")
            GunaDataGridViewInventaire.Columns.Add("QUANTITE_EN_STOCK", "QUANTITE EN STOCK")
            GunaDataGridViewInventaire.Columns.Add("QUANTITE_PHYSIQUE", "QUANTITE PHYSIQUE")
            GunaDataGridViewInventaire.Columns.Add("COUT_DU_STOCK", "COUT DU STOCK")

        End If

        If tousLesArticles.Rows.Count > 0 Then

            Dim econom As New Economat()

            Dim CODE_ARTICLE As String = ""
            Dim LIBELLE_ARTICLE As String = ""
            Dim QUANTITE_EN_STOCK As Double = 0
            Dim COUT_DU_STOCK As Double = 0

            For i = 0 To tousLesArticles.Rows.Count - 1

                LIBELLE_ARTICLE = tousLesArticles.Rows(i)("DESIGNATION_FR")
                CODE_ARTICLE = tousLesArticles.Rows(i)("CODE_ARTICLE")
                QUANTITE_EN_STOCK = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)
                COUT_DU_STOCK = QUANTITE_EN_STOCK * tousLesArticles.Rows(i)("PRIX_ACHAT_HT")

                If QUANTITE_EN_STOCK > 0 Then
                    GunaDataGridViewInventaire.Rows.Add(CODE_ARTICLE, LIBELLE_ARTICLE, QUANTITE_EN_STOCK, "", COUT_DU_STOCK)
                End If

            Next

            'GunaDataGridViewInventaire.DataSource = tousLesArticles
            GunaDataGridViewInventaire.Columns(0).Visible = False
            GunaDataGridViewInventaire.Columns("QUANTITE_EN_STOCK").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewInventaire.Columns("QUANTITE_EN_STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Else
            'GunaDataGridViewInventaire.Rows.Clear()
            GunaDataGridViewInventaire.Columns(0).Visible = False
        End If

    End Sub

    Private Sub GunaButtonImpressionDirecte_Click(sender As Object, e As EventArgs) Handles GunaButtonImpressionDirecte.Click

        Dim title As String = GlobalVariable.inventaire.ToString.ToUpper

        Dim numeroBon As String = ""
        Dim libelle As String = ""
        Dim reference As String = ""
        Dim observation As String = ""
        Dim nomTiers As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        Dim totalAchat As Double = 0
        Dim totalVente As Double = 0

        Dim CODE_MAGASIN_ As String = choixDuMagasin()
        Impression.impressionEconomat(GunaDataGridViewInventaire, title, totalAchat, totalVente, numeroBon, nomTiers, libelle, reference, observation, CODE_MAGASIN_)

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        Dim entreeSortie As Integer = GunaComboBoxEntreSortie.SelectedIndex
        Dim globalIndividuel As Integer = 1
        GlobalVariable.typeRapportEconmat = "ES"

        If GlobalVariable.typeRapportEconmat = "ES" Then

            Dim CODE_MAGASIN As String = choixDuMagasin()

            Dim econom As New Economat
            If (globalIndividuel >= 0 And globalIndividuel <= 1) And (entreeSortie >= 0 And entreeSortie <= 1) Then
                'DEMANDE A AFFICHER LES ENTREES OU SORTIES GLOBALES OU INDIVIDUELLE DONC DETAILLEES
                GunaDataGridViewBorderoByTypeEtDate.DataSource = econom.affichageDesEntreesSortiePeriodiqueSpecifique(GunaDateTimePicker1.Value.ToShortDateString, GunaDateTimePicker2.Value.ToShortDateString, entreeSortie, globalIndividuel, CODE_MAGASIN)

                If GunaDataGridViewBorderoByTypeEtDate.Rows.Count > 0 Then

                    '`DATE_BORDEREAU` AS 'DATE' = 0, 
                    'DESIGNATION_FR AS ITEM = 1, 
                    'NUM_SERIE_DEBUT As UNIT = 2, 
                    'ligne_bordereaux.QUANTITE As 'QTY BEFORE' = 3, 
                    'QUANTITE_ENTREE_STOCK AS 'MOVING QTY' = 4, 
                    'PRIX_UNITAIRE_HT AS 'UNIT PRICE' = 5, 
                    'PRIX_TOTAL_HT AS 'TOTAL' = 6, 
                    'magasin.LIBELLE_MAGASIN AS 'STORE' = 7 

                    GunaDataGridViewBorderoByTypeEtDate.Columns(5).DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewBorderoByTypeEtDate.Columns(6).DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewBorderoByTypeEtDate.Columns(3).DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewBorderoByTypeEtDate.Columns(4).DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaButtonImpirmerRapportEconomat.Visible = True

                    GunaDataGridViewBorderoByTypeEtDate.Columns(7).Visible = False

                Else
                    GunaButtonImpirmerRapportEconomat.Visible = False
                    GunaDataGridViewBorderoByTypeEtDate.Columns(7).Visible = False
                End If

            End If

        End If
    End Sub

    Private Sub GunaButtonImpirmerRapportEconomat_Click(sender As Object, e As EventArgs) Handles GunaButtonImpirmerRapportEconomat.Click

        Dim title As String = ""

        Dim entreeSortie As Integer = GunaComboBoxEntreSortie.SelectedIndex
        Dim globalIndividuel As Integer = 1
        If entreeSortie = 0 Then
            title = "ENTREES DU MAGASIN"
        Else
            title = "SORTIES DU MAGASIN"
        End If

        If GlobalVariable.actualLanguageValue = 0 Then
            If entreeSortie = 0 Then
                title = "STORE ENTRIES"
            Else
                title = "STORE OUT GOING"
            End If

        End If

        Dim entreeSortieOuAchatPeriodique As Integer = 0 'ENTREE SORTIE = 0 or ACHAT PERIODIQUE = 1

        Dim CODE_MAGASIN As String = choixDuMagasin()

        Impression.affichageDesEntreesSortiePeriodiqueImpression(GunaDateTimePicker1.Value.ToShortDateString, GunaDateTimePicker2.Value.ToShortDateString, entreeSortie, globalIndividuel, title, entreeSortieOuAchatPeriodique, CODE_MAGASIN)

    End Sub

    Private Sub GunaComboBoxEntreSortie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxEntreSortie.SelectedIndexChanged
        GunaDataGridViewBorderoByTypeEtDate.Columns.Clear()
    End Sub
End Class