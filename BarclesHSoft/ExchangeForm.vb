Imports MySql.Data.MySqlClient

Public Class ExchangeForm

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ExchangeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.exchange(GlobalVariable.actualLanguageValue)

        If GlobalVariable.AgenceActuelle.Rows(0)("CONFIG") = 1 Then

            GlobalVariable.config = Functions.allTableFields("config")

            If GlobalVariable.config.Rows.Count > 0 Then

                Dim backColorString As String = GlobalVariable.config.Rows(0)("SCHEME_COLOR")
                Dim backSecondaryColorString As String = GlobalVariable.config.Rows(0)("SCHEME_SECONDARY_COLOR")
                Dim textColorString As String = GlobalVariable.config.Rows(0)("TEXT_PRIMARY_COLOR")
                Dim textSecondaryColorString As String = GlobalVariable.config.Rows(0)("TEXT_SECONDARY_COLOR")

                Dim paramCouleur() As String
                Dim paramSecondaryCouleur() As String
                Dim paramSecondaryTextCouleur() As String
                Dim paramPrimaryTextCouleur() As String

                paramCouleur = Functions.returningColorFromString(backColorString)
                paramSecondaryCouleur = Functions.returningColorFromString(backSecondaryColorString)
                paramSecondaryTextCouleur = Functions.returningColorFromString(textSecondaryColorString)
                paramPrimaryTextCouleur = Functions.returningColorFromString(textColorString)

                If paramCouleur(1).Equals("") Then
                    GunaLabeTop.BackColor = Color.FromName(paramCouleur(0))
                    GunaPanelBottom.BackColor = Color.FromName(paramCouleur(0))
                    GunaButtonExchange.BackColor = Color.FromName(paramCouleur(0))
                Else
                    GunaPanelBottom.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                    GunaLabeTop.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                    GunaButtonExchange.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))

                End If

                Dim buttonPanel As Integer = 0 'Button Background
                GunaButtonExchange.BaseColor = Functions.colorationWindow(buttonPanel)

            End If

        End If

    End Sub

    Private Sub GunaImageButtonFermer_Click(sender As Object, e As EventArgs) Handles GunaImageButtonFermer.Click
        Me.Close()
    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub GunaButtonTables_Click(sender As Object, e As EventArgs) Handles GunaButtonExchange.Click

        Dim ID_LIGNE_FACTURE = GunaTextBoxIdLigne.Text
        Dim NUMERO_BLOC_NOTE = GunaTextBoxNumBlocNote.Text
        Dim CODE_ARTICLE As String = GunaTextBoxCodeArticle.Text

        Dim OriginalQty As Integer = 0
        If Not Trim(GunaTextBoxOriginalQty.Text).Equals("") Then
            OriginalQty = GunaTextBoxOriginalQty.Text
        End If

        Dim realQty As Integer = 0
        If Not Trim(GunaTextBoxQuantite.Text).Equals("") Then
            realQty = GunaTextBoxQuantite.Text
        End If

        Dim table As String = "ligne_facture"

        'Dim articleExistant As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "CODE_ARTICLE", NUMERO_BLOC_NOTE, "NUMERO_BLOC_NOTE")
        Dim articleExistant As DataTable = Functions.GetAllElementsOnTwoConditions(ID_LIGNE_FACTURE, table, "ID_LIGNE_FACTURE", NUMERO_BLOC_NOTE, "NUMERO_BLOC_NOTE")

        If realQty <= OriginalQty Then

            'On ne peut remplacer que la si le nouvelle article est <= a l'ancien article

            If articleExistant.Rows.Count > 0 Then

                Dim econom As New Economat()
                Dim CODE_AGENCE As String = ""

                'GESTION DE MODIFICATION DONC ON RETRANCHE L'ANCIEN MONTANT AVANT AJOUT DE LA NOUVELLE
                Dim infoBlocNote As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If infoBlocNote.Rows.Count > 0 Then

                    If infoBlocNote.Rows(0)("ETAT_BLOC_NOTE") = 1 Then

                        Dim nomDelaTable As String = table
                        Dim mainCourantes As New MainCourantes()

                        Dim UNITE As String = GunaComboBoxUniteChangement.Text
                        Dim QUANTITE As Integer = GunaTextBoxQuantite.Text
                        Dim NEW_CODE_ARTICLE As String = GunaTextBoxRepArticle.Text
                        Dim MONTANT_HT As Integer = GunaTextBoxMontantHT.Text

                        Dim MONTANT_TTC As Integer = GunaTextBoxMontantTTC.Text
                        Dim PRIX_UNITAIRE_TTC As Integer = GunaTextBoxUp.Text
                        Dim LIBELLE_FACTURE As String = GunaTextBoxArticle.Text
                        Dim TYPE_LIGNE_FACTURE As String = GunaTextBoxPointDeVente.Text

                        Dim FUSIONNEE As String = GunaTextBoxSousFamilleArticle.Text

                        If OriginalQty = realQty Then

                            '1- On remplace tout de l'ancien article par le nouvel article
                            updateOfFieldsLigneFacture(table, UNITE, QUANTITE, NEW_CODE_ARTICLE, MONTANT_HT, MONTANT_TTC, PRIX_UNITAIRE_TTC, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, FUSIONNEE, ID_LIGNE_FACTURE)

                            '2- Si la gestion des stocks est active on doit aussi prendre en compte le stock
                            table = "mouvement_stock"
                            Dim QUANTITE_SORTIE As Integer = QUANTITE
                            Dim VALEUR_SORTIE As Integer = QUANTITE

                            If Not Trim(GlobalVariable.magasinActuel).Equals("") Then

                                Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                                Dim QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, NEW_CODE_ARTICLE)

                                Dim QUANTITE_AVANT_MOVEMENT As Integer = QUANTITE_DU_MAGASIN_ACTUEL
                                Dim CMUP As Integer = 0
                                Dim CODE_MOUVEMENT As String = articleExistant.Rows(0)("CODE_MOUVEMENT")

                                updateOfFieldsMovementStock(table, UNITE, QUANTITE_SORTIE, NEW_CODE_ARTICLE, VALEUR_SORTIE, QUANTITE_AVANT_MOVEMENT, CMUP, CODE_MOUVEMENT)

                            End If

                            '3---------Implication sur la maincourante -------------
                            For i = 0 To articleExistant.Rows.Count - 1

                                Dim CODE_FACTURE As String = articleExistant.Rows(i)("CODE_FACTURE")
                                Dim CODE_RESERVATION As String = articleExistant.Rows(i)("CODE_RESERVATION")
                                Dim CODE_MOUVEMENT As String = articleExistant.Rows(i)("CODE_MOUVEMENT")
                                Dim CODE_CHAMBRE As String = articleExistant.Rows(i)("CODE_CHAMBRE")
                                Dim CODE_MODE_PAIEMENT As String = articleExistant.Rows(i)("CODE_MODE_PAIEMENT")
                                Dim NUMERO_PIECE As String = articleExistant.Rows(i)("NUMERO_PIECE")

                                Dim POINT_DE_VENTE As String = articleExistant.Rows(i)("TYPE_LIGNE_FACTURE")

                                CODE_ARTICLE = articleExistant.Rows(i)("CODE_ARTICLE")

                                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                                Dim CMUP As Double = 0

                                Dim CONTENANCE As Double = 0

                                Dim ficheTechnique As DataTable

                                Dim NOM_ARTICLE As String = ""

                                Dim NOMBRE_DE_PORTION As Double = 0

                                Dim articleInfo As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                                Dim reduction As Boolean = False

                                If Not articleInfo.Rows.Count > 0 Then

                                    CODE_ARTICLE = articleExistant.Rows(i)("NUMERO_SERIE_DEBUT")
                                    articleInfo = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                                    reduction = True

                                End If

                                Dim FAMILLE_ARTICLE As String = ""

                                If articleInfo.Rows.Count > 0 Then

                                    table = "main_courante_autres"

                                    Dim ETAT_MAIN_COURANTE As Integer = 0

                                    Dim main_courante_autres As DataTable = Functions.getElementByOnCodeAndDate(ETAT_MAIN_COURANTE, "main_courante_autres", "ETAT_MAIN_COURANTE", GlobalVariable.DateDeTravail, "main_courante_autres")

                                    Dim CODE_MAIN_COURANTE_AUTRES As String = ""

                                    If main_courante_autres.Rows.Count > 0 Then
                                        '-SI OUI MISE AJOURS
                                        CODE_MAIN_COURANTE_AUTRES = main_courante_autres.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                                    End If

                                    FAMILLE_ARTICLE = articleInfo.Rows(0)("CODE_FAMILLE")

                                    Dim MONTANT_TOTAL_ANCIEN_ARTICLE As Double = GunaTextBoxOldMontant.Text

                                    Dim FIELDVALUE As Double = MONTANT_TTC - MONTANT_TOTAL_ANCIEN_ARTICLE

                                    Dim FIELD As String = ""

                                    If Trim(FAMILLE_ARTICLE) = "BOISSONS" Or Trim(FAMILLE_ARTICLE) = "DRINKS" Then
                                        'TRAITEMENT DES BOISSONS
                                        FIELD = "BAR"
                                        MainCourantes.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_AUTRES, TABLE, FIELD, FIELDVALUE)

                                        FIELD = ""

                                        If FUSIONNEE = "EAU MINERAL" Or FUSIONNEE = "MINERAL WATER" Then
                                            FIELD = "CAFE"
                                        Else
                                            If articleExistant.Rows(i)("VALEUR_CONSO") > 0 Then
                                                FIELD = "DIVERS" 'CONSOMMATION
                                            Else
                                                FIELD = "CAVE"
                                            End If
                                        End If

                                        If Not Trim(FIELD).Equals("") Then
                                            mainCourantes.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_AUTRES, table, FIELD, FIELDVALUE)
                                        End If

                                    End If

                                    NOM_ARTICLE = articleInfo.Rows(0)("DESIGNATION_FR")

                                End If

                                Dim ligne_facture As New LigneFacture
                                ligne_facture.miseAjourDeLaMainCouranteParApportAPlusieursPointDeVente(NOM_ARTICLE, POINT_DE_VENTE, MONTANT_TTC)

                            Next
                            '-------------- end implication -----------------------
                        Else
                            'L'article remplacant est < a l'article a remplacer

                            'Remplacement partiel puis insertion du reste
                            '1.1- On remplace juste la qte ayant change en conservant l'ancienne (Remplacement partiel).
                            Dim QUANTITE_DIFF As Integer = OriginalQty - realQty
                            Dim UP As Double = GunaTextBoxPUItem.Text
                            updateOfFieldsPartialLigneFacture(table, QUANTITE_DIFF, UP, ID_LIGNE_FACTURE)

                            '1.2- Insertion des qte restantes par apport au nouvel article.
                            Dim dt As DataTable = Functions.getElementByCode(ID_LIGNE_FACTURE, table, "ID_LIGNE_FACTURE")

                            If dt.Rows.Count > 0 Then

                                Dim CODE_FACTURE As String = dt.Rows(0)("CODE_FACTURE")
                                Dim CODE_RESERVATION As String = dt.Rows(0)("CODE_RESERVATION")

                                Dim CODE_MOUVEMENT As String = dt.Rows(0)("CODE_MOUVEMENT")
                                Dim CODE_CHAMBRE As String = dt.Rows(0)("CODE_CHAMBRE")
                                Dim CODE_MODE_PAIEMENT As String = dt.Rows(0)("CODE_MODE_PAIEMENT")
                                Dim NUMERO_PIECE As String = dt.Rows(0)("NUMERO_PIECE")

                                'Dim CODE_ARTICLE As String = dt.Rows(0)("")
                                Dim CODE_LOT As String = UNITE
                                'Dim MONTANT_HT As Integer = dt.Rows(0)("")
                                Dim TAXE As Double = dt.Rows(0)("TAXE")
                                'Dim QUANTITE As Integer = dt.Rows(0)("")

                                'Dim PRIX_UNITAIRE_TTC As Integer = dt.Rows(0)("")
                                'Dim MONTANT_TTC As Integer = dt.Rows(0)("")
                                Dim DATE_FACTURE As Date = dt.Rows(0)("DATE_FACTURE")
                                Dim HEURE_FACTURE As String = dt.Rows(0)("HEURE_FACTURE")

                                Dim ETAT_FACTURE As Integer = dt.Rows(0)("ETAT_FACTURE")
                                Dim DATE_OCCUPATION As Date = dt.Rows(0)("DATE_OCCUPATION")
                                Dim HEURE_OCCUPATION As String = dt.Rows(0)("HEURE_OCCUPATION")
                                'Dim LIBELLE_FACTURE As String = dt.Rows(0)("")

                                'Dim TYPE_LIGNE_FACTURE As String = dt.Rows(0)("")
                                Dim NUMERO_SERIE As String = dt.Rows(0)("NUMERO_SERIE")
                                Dim NUMERO_ORDRE As Double = dt.Rows(0)("NUMERO_ORDRE")
                                Dim DESCRIPTION As String = dt.Rows(0)("DESCRIPTION")

                                Dim CODE_UTILISATEUR_CREA As String = dt.Rows(0)("CODE_UTILISATEUR_CREA")
                                CODE_AGENCE = dt.Rows(0)("CODE_AGENCE")
                                Dim MONTANT_REMISE As Double = dt.Rows(0)("MONTANT_REMISE")
                                Dim MONTANT_TAXE As Double = dt.Rows(0)("MONTANT_TAXE")

                                Dim NUMERO_SERIE_DEBUT As String = dt.Rows(0)("NUMERO_SERIE_DEBUT")
                                Dim NUMERO_SERIE_FIN As String = dt.Rows(0)("NUMERO_SERIE_FIN")
                                Dim CODE_MAGASIN As String = dt.Rows(0)("CODE_MAGASIN")
                                'Dim FUSIONNEE As String = dt.Rows(0)("")

                                Dim TYPE As String = dt.Rows(0)("TYPE")
                                'Dim NUMERO_BLOC_NOTE As String = dt.Rows(0)("")
                                Dim GRIFFE_UTILISATEUR As String = dt.Rows(0)("GRIFFE_UTILISATEUR")

                                Dim VALEUR_CONSO As Double = 0
                                Dim SERVEUR As String = dt.Rows(0)("SERVEUR")

                                Dim TABLE_LIGNE As String = "ligne_facture"

                                insertNewLigneFacture(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO, SERVEUR)

                            End If

                            '2- Si la gestion des stocks est active on doit aussi prendre en compte le stock

                            '3- Implication sur la maincourante

                        End If

                        'Functions.DeleteElementOnTwoConditions(ID_LIGNE_FACTURE, table, "ID_LIGNE_FACTURE", "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE)

                        '-------------------------------------START-------------------------------------------------------

                        '--------------------------------------END--------------------------------------------------------

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "You successfully Exchange"
                            languageTitle = "Exchange"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Vous avez echangé avec succès"
                            languageTitle = "Echange"
                        End If

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        BarRestaurantForm.BlocNotesVisualisation()

                        Dim ETAT_BLOC_NOTE As Integer = 1

                        BarRestaurantForm.miseAJourDuMontantDuBlocNote(NUMERO_BLOC_NOTE, ETAT_BLOC_NOTE)

                        BarRestaurantForm.resumeDesVentesDuJours(GlobalVariable.DateDeTravail)

                        BarRestaurantForm.manualRefresh()

                        BarRestaurantForm.GunaComboBoxListeDesComandes.SelectedValue = NUMERO_BLOC_NOTE

                        Me.Close()

                    Else

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "Please Delete or change the article !"
                            languageTitle = "Delete"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Bien vouloir supprimer ou changer d'article !"
                            languageTitle = "Suppression"
                        End If

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Impossible to Exchange!"
                    languageTitle = "Exchange"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Impossible de Changer!"
                    languageTitle = "Echanger"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            Functions.SiplifiedClearTextBox(Me)

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Please key in a correct quantity"
                languageTitle = "Exchange"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Bien vouloir saisir une quantité correcte"
                languageTitle = "Echange"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub GunaTextBoxArticle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxArticle.TextChanged

        If Trim(GunaTextBoxArticle.Text).Equals("") Then
            GunaTextBoxRepArticle.Clear()
            GunaDataGridViewArticle.Visible = False
            GunaDataGridViewArticle.Columns.Clear()

            Label11.Visible = False
            Label1.Visible = False
            GunaTextBoxQuantite.Visible = False
            GunaTextBoxUp.Visible = False

        Else
            GunaDataGridViewArticle.Visible = True

            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim getArticleQuery As String = ""

            'Si l'article n'existe pas alors on efface toute les informations le concernant

            If Trim(GunaTextBoxArticle.Text).Equals("") Then

                GunaLabel2.Visible = False

            End If

            'Determining from which table to search for the articles
            If GlobalVariable.ArticleFamily = "BAR" Or GlobalVariable.ArticleFamily = "RESTAURANT" Then

                getArticleQuery = "SELECT DESIGNATION_FR, PRIX_VENTE_HT FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY1 AND TYPE=@TYPE AND VISIBLE=@VISIBLE OR DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY2 AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

            Else

                getArticleQuery = "SELECT DESIGNATION_FR, PRIX_VENTE_HT FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

            End If

            If Not GlobalVariable.ArticleFamily = "" Then

                Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)

                If GlobalVariable.ArticleFamily = "BAR" Or GlobalVariable.ArticleFamily = "RESTAURANT" Then

                    Command.Parameters.Add("@ARTICLEFAMILY1", MySqlDbType.VarChar).Value = "BAR"
                    Command.Parameters.Add("@ARTICLEFAMILY2", MySqlDbType.VarChar).Value = "RESTAURANT"

                Else

                    Command.Parameters.Add("@ARTICLEFAMILY", MySqlDbType.VarChar).Value = GlobalVariable.ArticleFamily

                End If

                Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"
                Command.Parameters.Add("@VISIBLE", MySqlDbType.Int64).Value = 1

                adapter.SelectCommand = Command
                adapter.Fill(table)

            End If

            If (table.Rows.Count > 0) Then
                GunaDataGridViewArticle.DataSource = table
            Else
                GunaDataGridViewArticle.Columns.Clear()
                GunaDataGridViewArticle.Visible = False
            End If

            If GunaTextBoxArticle.Text = "" Then
                GunaDataGridViewArticle.Visible = False
            End If
        End If

    End Sub

    Private Sub GunaTextBoxRepArticle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRepArticle.TextChanged

        If Trim(GunaTextBoxRepArticle.Text).Equals("") Then
            GunaButtonExchange.Enabled = False
        Else
            GunaButtonExchange.Enabled = True
        End If

    End Sub

    Private Sub GunaDataGridViewArticle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticle.CellClick
        Me.Cursor = Cursors.WaitCursor

        Dim codeArticle As String = ""
        Dim nomArticle As String = ""
        Dim suivieStock As Boolean = False
        Dim quantite As Integer = 0
        Dim montant As Double = 0
        Dim montantHT As Double = 0

        If e.RowIndex >= 0 Then

            GunaDataGridViewArticle.Visible = False

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewArticle.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE DESIGNATION_FR=@DESIGNATION_FR ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@DESIGNATION_FR", MySqlDbType.VarChar).Value = row.Cells("DESIGNATION_FR").Value.ToString

            adapter.SelectCommand = command
            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then

                Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                codeArticle = Article.Rows(0)("CODE_ARTICLE")
                GunaTextBoxRepArticle.Text = Article.Rows(0)("CODE_ARTICLE")
                GunaTextBoxUp.Text = BarRestaurantForm.prixUtilse(CODE_MAGASIN, Article)
                nomArticle = row.Cells("DESIGNATION_FR").Value.ToString

                If Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Suivi simple" Or Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Simple tracking" Then
                    suivieStock = True
                Else
                    suivieStock = False
                End If

                Double.TryParse(GunaTextBoxQuantite.Text, quantite)

                GunaTextBoxMontantHT.Text = Format(BarRestaurantForm.prixUtilse(CODE_MAGASIN, Article), "#,##0")

                Double.TryParse(GunaTextBoxMontantHT.Text, montant)
                GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
                Dim TVA As Double = 0
                'ouble.TryParse(GunaTextBoxTVA.Text, TVA)
                montantHT = (quantite * montant)
                GunaTextBoxMontantTTC.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

                If Not Trim(Article.Rows(0)("CODE_SOUS_FAMILLE")) = "" Then

                    'DETERMINATION DE LA NATURE DU REPAS (PDJ, DEJEUNER, DINER)
                    GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_SOUS_FAMILLE")

                Else
                    'QUAND LA FAMILLE EST VIDE ONT S'APPUI SYR LA SOUS FAMILLE COMME AVEC : HEBERGEMENT ET LOCATION SALLE
                    GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_FAMILLE")
                End If

                GunaTextBoxArticle.Text = nomArticle
                GunaTextBoxPointDeVente.Text = Article.Rows(0)("TYPE_ARTICLE")

                '----------------------------------------------------------------------------------------------------------------------------
                'NOUS ALLONS AFFICHER NON PLUS LA QUANTITE DANS TOUS LES MAGASIN MAIS CELLE DU MAGASIN DE L'UTILISATEUR CONECTE

                Dim econom As New Economat()
                Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                Dim QUANTITE_DU_MAGASIN_ACTUEL = 0
                Dim QUANTITE_DU_MAGASIN_ECONOMAT = Article.Rows(0)("QUANTITE")

                QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, codeArticle)

                'ON DETERMINE SI LE BOUTON DE GESTION DE STOCK A ETE CHOISI AU NIVEAU DE LA CREATION DES AGENCES
                Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

                Dim NOMBRE_UNITE As Integer = 2

                gestionDesUnites(Article)

                '--------------------------------------------------------------------------------------------------------------------------------

                GunaDataGridViewArticle.Visible = False

                Label11.Visible = True
                Label1.Visible = True
                GunaTextBoxQuantite.Visible = True
                GunaTextBoxUp.Visible = True

            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Public Sub gestionDesUnites(ByVal Article As DataTable)

        GunaComboBoxUniteChangement.Clear()

        Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")

        Dim pasDeConso As Boolean = True

        Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

        If unite.Rows.Count > 0 Then

            GunaComboBoxUniteChangement.Text = unite.Rows(0)("GRANDE_UNITE")

            If unite.Rows(0)("VALEUR_NUMERIQUE") > 1 Then
                GunaComboBoxUniteChangement.Text = unite.Rows(0)("PETITE_UNITE")
            Else
                GunaComboBoxUniteChangement.Text = unite.Rows(0)("GRANDE_UNITE")
            End If

        End If

    End Sub

    Private Sub GunaTextBoxQuantite_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxQuantite.TextChanged
        calculPrixTotal()
    End Sub

    Private Sub GunaTextBoxUp_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxUp.TextChanged
        calculPrixTotal()
    End Sub

    Private Sub calculPrixTotal()

        Dim Pt As Double = 0
        Dim PU As Double = 0
        Dim Qty As Integer = 0

        If Not Trim(GunaTextBoxQuantite.Text).Equals("") Then
            Qty = GunaTextBoxQuantite.Text
        End If

        If Not Trim(GunaTextBoxUp.Text).Equals("") Then
            PU = GunaTextBoxUp.Text
        End If

        Pt = Qty * PU

        GunaTextBoxMontantHT.Text = Pt
        GunaTextBoxMontantTTC.Text = Pt

    End Sub

    Public Sub updateOfFieldsLigneFacture(ByVal table As String, ByVal UNITE As String, ByVal QUANTITE As Integer, ByVal CODE_ARTICLE As String, ByVal MONTANT_HT As Integer,
                              ByVal MONTANT_TTC As Integer, ByVal PRIX_UNITAIRE_TTC As Integer, ByVal LIBELLE_FACTURE As String, ByVal TYPE_LIGNE_FACTURE As String,
                              ByVal FUSIONNEE As String, ByVal ID_LIGNE_FACTURE As Integer)

        Dim updateQuery As String = "UPDATE " & table & " SET `CODE_LOT`=@UNITE, QUANTITE=@QUANTITE, CODE_ARTICLE=@CODE_ARTICLE, MONTANT_HT=@MONTANT_HT, 
        MONTANT_TTC=@MONTANT_TTC, PRIX_UNITAIRE_TTC=@PRIX_UNITAIRE_TTC, LIBELLE_FACTURE=@LIBELLE_FACTURE, TYPE_LIGNE_FACTURE=@TYPE_LIGNE_FACTURE, FUSIONNEE=@FUSIONNEE
        WHERE ID_LIGNE_FACTURE = @ID_LIGNE_FACTURE"

        Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)

        commandupdateQuery.Parameters.Add("@UNITE", MySqlDbType.VarChar).Value = UNITE
        commandupdateQuery.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int32).Value = ID_LIGNE_FACTURE
        commandupdateQuery.Parameters.Add("@QUANTITE", MySqlDbType.Int32).Value = QUANTITE
        commandupdateQuery.Parameters.Add("@MONTANT_HT", MySqlDbType.Int32).Value = MONTANT_HT
        commandupdateQuery.Parameters.Add("@MONTANT_TTC", MySqlDbType.Int32).Value = MONTANT_TTC
        commandupdateQuery.Parameters.Add("@PRIX_UNITAIRE_TTC", MySqlDbType.Int32).Value = PRIX_UNITAIRE_TTC
        commandupdateQuery.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        commandupdateQuery.Parameters.Add("@LIBELLE_FACTURE", MySqlDbType.VarChar).Value = Trim(LIBELLE_FACTURE)
        commandupdateQuery.Parameters.Add("@TYPE_LIGNE_FACTURE", MySqlDbType.VarChar).Value = TYPE_LIGNE_FACTURE
        commandupdateQuery.Parameters.Add("@FUSIONNEE", MySqlDbType.VarChar).Value = FUSIONNEE

        commandupdateQuery.ExecuteNonQuery()

    End Sub

    Public Sub updateOfFieldsPartialLigneFacture(ByVal table As String, ByVal QUANTITE As Integer, ByVal UP As Double, ByVal ID_LIGNE_FACTURE As Integer)

        Dim updateQuery As String = "UPDATE " & table & " SET QUANTITE=@QUANTITE, MONTANT_HT=QUANTITE*PRIX_UNITAIRE_TTC, MONTANT_TTC=MONTANT_HT
        WHERE ID_LIGNE_FACTURE = @ID_LIGNE_FACTURE"

        Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)

        commandupdateQuery.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int32).Value = ID_LIGNE_FACTURE
        commandupdateQuery.Parameters.Add("@QUANTITE", MySqlDbType.Int32).Value = QUANTITE

        commandupdateQuery.ExecuteNonQuery()

    End Sub

    Public Sub insertNewLigneFacture(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String,
                      ByVal CODE_MOUVEMENT As String, ByVal CODE_CHAMBRE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUMERO_PIECE As String,
                      ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal QUANTITE As Integer,
                      ByVal PRIX_UNITAIRE_TTC As Double, ByVal MONTANT_TTC As Double, ByVal DATE_FACTURE As Date, ByVal HEURE_FACTURE As String,
                      ByVal ETAT_FACTURE As Integer, ByVal DATE_OCCUPATION As Date, ByVal HEURE_OCCUPATION As String, ByVal LIBELLE_FACTURE As String,
                      ByVal TYPE_LIGNE_FACTURE As String, ByVal NUMERO_SERIE As String, ByVal NUMERO_ORDRE As Double, ByVal DESCRIPTION As String,
                      ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal MONTANT_REMISE As Double, ByVal MONTANT_TAXE As Double,
                      ByVal NUMERO_SERIE_DEBUT As String, ByVal NUMERO_SERIE_FIN As String, ByVal CODE_MAGASIN As String, ByVal FUSIONNEE As String,
                      ByVal TYPE As String, ByVal TABLE_LIGNE As String, ByVal NUMERO_BLOC_NOTE As String, ByVal GRIFFE_UTILISATEUR As String,
                      ByVal VALEUR_CONSO As Double, ByVal SERVEUR As String)

        'FUSIONNEE : UTILISE COMME SOUS FAMILLE DE L'ARTICLE
        Dim ligneFacture As New LigneFacture()
        ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO, SERVEUR)

    End Sub

    Public Sub updateOfFieldsMovementStock(ByVal table As String, ByVal UNITE As String, ByVal QUANTITE_SORTIE As Integer, ByVal CODE_ARTICLE As String, ByVal VALEUR_SORTIE As Integer,
                              ByVal QUANTITE_AVANT_MOVEMENT As Integer, ByVal CMUP As Integer, ByVal CODE_MOUVEMENT As String)

        Dim updateQuery As String = "UPDATE " & table & " SET `CODE_LOT`=@UNITE, QUANTITE_SORTIE=@QUANTITE_SORTIE, CODE_ARTICLE=@CODE_ARTICLE, VALEUR_SORTIE=@VALEUR_SORTIE, 
        QUANTITE_AVANT_MOVEMENT=@QUANTITE_AVANT_MOVEMENT, CMUP=@CMUP WHERE CODE_MOUVEMENT = @CODE_MOUVEMENT"

        Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)

        commandupdateQuery.Parameters.Add("@UNITE", MySqlDbType.VarChar).Value = UNITE
        commandupdateQuery.Parameters.Add("@CODE_MOUVEMENT", MySqlDbType.VarChar).Value = CODE_MOUVEMENT
        commandupdateQuery.Parameters.Add("@QUANTITE_SORTIE", MySqlDbType.Int32).Value = QUANTITE_SORTIE
        commandupdateQuery.Parameters.Add("@VALEUR_SORTIE", MySqlDbType.Int32).Value = VALEUR_SORTIE
        commandupdateQuery.Parameters.Add("@QUANTITE_AVANT_MOVEMENT", MySqlDbType.Int32).Value = QUANTITE_AVANT_MOVEMENT
        commandupdateQuery.Parameters.Add("@CMUP", MySqlDbType.Int32).Value = CMUP
        commandupdateQuery.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        commandupdateQuery.ExecuteNonQuery()

    End Sub

End Class