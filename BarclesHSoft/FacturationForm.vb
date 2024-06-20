Imports MySql.Data.MySqlClient

Public Class FacturationForm

    'On crée un facture au chargement du Form
    'puis on ajouete des articles dans ligne_facture
    'enfin on met à jour les montants de notre facture créee 

    Dim montant As Double = 0
    Dim quantite As Double = 0
    Dim montantTTC As Double = 0
    Dim TVA As Double = 0
    Dim montantHT As Double = 0
    Dim codeArticle As String = ""
    Dim nomArticle As String = ""

    'Dim connect As New DataBaseManipulation()

    Public Sub indicateurDEtatDeCaisse()

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 1 Then

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim caisse As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If caisse.Rows.Count > 0 Then

                If caisse.Rows(0)("ETAT_CAISSE") = 0 Then
                    PanelSituationCaisse.BackColor = Color.Red
                Else
                    PanelSituationCaisse.BackColor = Color.LightGreen
                End If

            End If

        End If

    End Sub

    Public Sub bloquerLaModificationDuPrixUnitaire()
        If GlobalVariable.AgenceActuelle.Rows(0)("PRIX_BAR_RESTAU_MODIFIABLE") = 1 Then
            GunaTextBoxMontantHT.Enabled = True
        Else
            GunaTextBoxMontantHT.Enabled = False
        End If
    End Sub

    Private Sub FacturationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        firstLoad = True

        GunaTextBoxCodeElite.Clear()

        If GlobalVariable.ClientToUpdate IsNot Nothing Then

            If GlobalVariable.ClientToUpdate.Rows.Count > 0 Then
                GunaTextBoxCodeElite.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_ELITE")

                'CODE_ELITE
                If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then

                    If Not Trim(GunaTextBoxCodeElite.Text).Equals("") Then

                        discounStays = True

                        Dim CODE_ELITE As String = GunaTextBoxCodeElite.Text
                        Dim eliteClub As New ClubElite

                        Dim dt As DataTable = eliteClub.infoDuCodeElite(CODE_ELITE)

                        If dt.Rows.Count > 0 Then
                            GunaTextBoxRemise.Text = dt.Rows(0)("REDUCTION_ACCORDEE")
                        End If

                    Else
                        discounStays = False
                    End If

                End If

            End If

        End If

        Dim language As New Languages()
        language.facturation(GlobalVariable.actualLanguageValue)

        Functions.magasinActuelEtShiftDunUtilisateur()

        GlobalVariable.typeDeClientAFacturer = "en chambre"
        'GunaComboBoxListeDesComandes
        indicateurDEtatDeCaisse()

        LabelNomCaissier.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

        'AutoLoadOfBlocNote()

        If Trim(GlobalVariable.ArticleFamily) = "" Then
            GlobalVariable.ArticleFamily = "BAR"
        End If

        'Oon affiche le bouton permettant de lire la carte si on traite un client en chambre

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Or Not GlobalVariable.codeReservationToUpdate = "" Then

            tb_server.Text = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_HOTEL_LOCK_SYSTEM")
            'GunaButtonLecture.Visible = True
            TB_RoomNo.Visible = True
            LabelNumeroChambre.Visible = True

            GunaAdvenceButtonLectureDeCarte.Visible = True
        Else

            GunaAdvenceButtonLectureDeCarte.Visible = False
            GunaButtonLecture.Visible = False
            TB_RoomNo.Visible = False
            LabelNumeroChambre.Visible = False

        End If

        bloquerLaModificationDuPrixUnitaire()

        'gestion des cartes d'acces
        CB_Software.SelectedIndex = 0
        CB_Port.SelectedIndex = 0
        CB_Breakfast.SelectedIndex = 1
        CB_DB.SelectedIndex = 0

        TB_Time.Text = DateTime.Now.ToString("yyyyMMdd1200") + DateTime.Now.AddDays(1).ToString("yyyyMMdd1200")

        GunaTextBoxFacturationDate.Text = GlobalVariable.DateDeTravail

        'Managing  the facturationcoming from the front desk
        If GlobalVariable.checkInFacturation Then

            'CLIENT EN CHAMBRE

            GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonSaveFacturation.Text = "Enregistrer"
            Else
                GunaButtonSaveFacturation.Text = "Save"
            End If

            'We fill the form when coming from frontoffice
            If Not GlobalVariable.codeReservationToUpdate = "" Then

                'Auto fill the invoice form with information from front desk
                ClientForFacturation()

                'Refresh Datagrid
                OutPutLigneFacture()

                If GunaDataGridViewLigneFacture.Rows.Count > 0 Then
                    GunaButtonSaveFacturation.Visible = True
                End If

            Else

                'We opened the window passing through the menuStripItem
                'We cear fields
                clearArticleFields()

                'We generate a new invoice random code

                GunaTextBoxFacturationDate.Text = GlobalVariable.DateDeTravail

                GunaTextBoxNumfacture.Enabled = True
                GunaTextBoxFacturationDate.Enabled = True

            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonSaveFacturation.Text = "Enregistrer"
            Else
                GunaButtonSaveFacturation.Text = "Save"
            End If

            GunaTextBoxBlocNote.Visible = True
            GunaComboBoxListeDesComandes.Visible = True
            LabelBlocNoteOuTable.Visible = True

        Else

        End If

        If Trim(GlobalVariable.ArticleFamily) = "SERVICES" Or Trim(GlobalVariable.ArticleFamily) = "BLANCHISSERIE" Then
            GunaTextBoxBlocNote.Visible = False
            GunaButtonNouveauBloc.Visible = False
            GunaComboBoxListeDesComandes.Visible = False
            LabelBlocNoteOuTable.Visible = False
        Else
            GunaTextBoxBlocNote.Visible = True
            'GunaButtonNouveauBloc.Visible = True
            GunaComboBoxListeDesComandes.Visible = True
            LabelBlocNoteOuTable.Visible = True
        End If

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

            Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate
            Dim Caisse As New Caisse()
            GunaComboBoxListeDesComandes.DataSource = Caisse.AutoLoadBlocNoteEnChambre(GlobalVariable.DateDeTravail.ToShortDateString, GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), 0, CODE_RESERVATION)
            GunaComboBoxListeDesComandes.ValueMember = "NUMERO_BLOC_NOTE"
            GunaComboBoxListeDesComandes.DisplayMember = "NUMERO_BLOC_NOTE"

        End If

        'OutPut DataGrid 
        OutPutLigneFacture()

        'Determining wether or not to save a facturation
        DisplaySavingButton()

        SituationDeCaisseJournaliere()

    End Sub

    'When we close the facturationForm
    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButtonClose.Click

        discounStays = False
        'Empty facturation form field
        emptyFacturationFormField()
        GlobalVariable.checkInFacturation = False
        Me.Close()

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButtonReduce.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'Inserting client information from frontoffice for facturation 
    Public Sub ClientForFacturation()

        'Facturation of a client coming from the front desk initialised to true when we click on BAR/RESTAURANT in facturation of frontdesk
        If GlobalVariable.checkInFacturation Then

            'GunaTextBoxNumfacture.Text = GlobalVariable.codeFactureToUpdate

            GunaTextBoxSoldeClient.Text = Format(Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate), "#,##0")

            GunaTextBoxNumReservation.Text = GlobalVariable.codeReservationToUpdate
            GunaTextBoxFacturationDate.Text = GlobalVariable.DateDeTravail

            'We disable the fields
            GunaTextBoxNumReservation.Enabled = False
            GunaTextBoxFacturationDate.Enabled = False
            GunaTextBoxNumfacture.Enabled = False

            'Getting the client 
            Dim client As DataTable = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "client", "CODE_CLIENT")

            If client.Rows.Count > 0 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    LibelleFacturation.Text = "EN CHAMBRE"
                Else
                    LibelleFacturation.Text = "IN HOUSE"
                End If

                GunaTextBoxNomPrenomClient.Text = client.Rows(0)("CODE_CLIENT")
                GunaTextBoxNom_Prenom.Text = client.Rows(0)("NOM_PRENOM")

                'We disable the fields
                GunaTextBoxNomPrenomClient.Enabled = False
                GunaTextBoxNom_Prenom.Enabled = False

                TB_RoomNo.Text = GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID")

                GunaTextBoxNomPrenomClient.Visible = False

                GunaDataGridViewChambreReservation.Visible = False

            End If

        End If

    End Sub

    'Empty facturation form field 
    Public Sub emptyFacturationFormField()

        GunaTextBoxNumfacture.Text = ""
        GunaTextBoxNumReservation.Text = ""
        GunaTextBoxFacturationDate.Text = GlobalVariable.DateDeTravail
        LibelleFacturation.Text = "FACTURATION COMPTOIRE"

        'We disable the fields
        GunaTextBoxNumReservation.Enabled = False
        GunaTextBoxFacturationDate.Enabled = False
        GunaTextBoxNumfacture.Enabled = False

        GunaTextBoxNomPrenomClient.Text = ""
        GunaTextBoxNom_Prenom.Text = ""

        'We disable the fields
        GunaTextBoxNomPrenomClient.Enabled = False
        GunaTextBoxNom_Prenom.Enabled = False

        GunaTextBoxFacturationDate.Text = GlobalVariable.DateDeTravail

        'Clearing Article fields
        clearArticleFields()

        'GlobalVariable.ArticleFamily = ""

    End Sub

    Public Sub clearArticleFields()

        'We empty article fields
        GunaTextBoxQuantite.Text = 1
        GunaTextBoxMontantHT.Text = 0
        GunaTextBoxTVA.Text = 0
        GunaTextBoxMontantTTC.Text = 0
        GunaTextBoxArticle.Text = ""

        GunaTextBoxMontantReduction.Text = 0

        If discounStays = False Then
            GunaTextBoxRemise.Text = 0
        End If

    End Sub

    'We fill the general information concerning the Invoice
    Public Sub ClearFacturationKeyInformation()

        GunaTextBoxMontantTTCGeneral.Text = 0
        GunaTextBoxSoldeClient.Text = 0
        GunaTextBoxTVARecap.Text = 0

    End Sub
    'Determining wether or not to save a facturation
    Public Sub DisplaySavingButton()

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaButtonSaveFacturation.Text = "Enregistrer"
        Else
            GunaButtonSaveFacturation.Text = "Save"
        End If

        If GunaDataGridViewLigneFacture.Rows.Count > 0 Then
            GunaButtonSaveFacturation.Visible = True
        Else
            GunaButtonSaveFacturation.Visible = False
            GunaDataGridViewLigneFacture.DataSource = Nothing
        End If

    End Sub

    'Filling the article custom autocomplete coming from front desk

    Private Sub GunaTextBoxArticle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxArticle.TextChanged

        GunaDataGridViewArticle.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxArticle.Text).Equals("") Then

            bloquerLaModificationDuPrixUnitaire()

            GunaTextBoxConso.Visible = False
            GunaLabel2.Visible = False

            GunaTextBoxQuantiteConso.Clear()

            GunaButtonAjouterLigne.Visible = False
            GunaLabel4.Visible = False

            GunaComboBoxUniteOuConso.Visible = False
            GunaTextBoxConso.Text = 0
            GunaTextBoxConsoOnly.Text = 0
            clearArticleFields()
            GunaTextBoxStockMagasin.Text = 0
            GunaTextBoxStockEconomat.Text = 0

            GunaTextBoxConsoOnly.Visible = False
            GunaLabel5.Visible = False
            GunaLabel6.Visible = False
            GunaTextBoxConsoOnly.Text = 0

        End If

        If GunaCheckBoxChangeSecteur.Checked Then
            'MessageBox.Show(GunaComboBoxTypeArticle.SelectedValue.ToString)
            GlobalVariable.ArticleFamily = GunaComboBoxTypeArticle.SelectedValue.ToString
        End If


        'Determining from which table to search for the articles
        If GlobalVariable.ArticleFamily = "BAR" Or GlobalVariable.ArticleFamily = "RESTAURANT" Then

            LibelleFacturation.Text = "FACTURATION " & GlobalVariable.ArticleFamily
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY1 AND TYPE=@TYPE AND VISIBLE=@VISIBLE OR DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY2 AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        'If GlobalVariable.ArticleFamily = "RESTAURANT" Then

        'LibelleFacturation.Text = "FACTURATION RESTAURANT"
        'getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY ORDER BY DESIGNATION_FR ASC"

        ' End If

        If GlobalVariable.ArticleFamily = "SERVICES" Then

            LibelleFacturation.Text = "FACTURATION SERVICES"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        If GlobalVariable.ArticleFamily = "SALON DE BEAUTE" Then

            LibelleFacturation.Text = "FACTURATION SALON DE BEAUTE"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        If GlobalVariable.ArticleFamily = "BOUTIQUE" Then

            LibelleFacturation.Text = "FACTURATION BOUTIQUE"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        If GlobalVariable.ArticleFamily = "BUSINESS CENTER" Then

            LibelleFacturation.Text = "FACTURATION BUSINESS CENTER"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        If GlobalVariable.ArticleFamily = "AUTRES" Then

            LibelleFacturation.Text = "AUTRES FACTURATION"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        If GlobalVariable.ArticleFamily = "LOISIRS" Then

            LibelleFacturation.Text = "FACTURATION LOISIRS"
            'getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND METHODE_SUIVI_STOCK=@METHODE_SUIVI_STOCK ORDER BY DESIGNATION_FR ASC"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        If GlobalVariable.ArticleFamily = "KIOSQUE A JOURNAUX" Then

            LibelleFacturation.Text = "FACTURATION KIOSQUE A JOURNAUX"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        If GlobalVariable.ArticleFamily = "SPORTS" Then

            LibelleFacturation.Text = "FACTURATION SPORTS"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        If GlobalVariable.ArticleFamily = "BLANCHISSERIE" Then

            LibelleFacturation.Text = "FACTURATION BLANCHISSERIE"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

        End If

        'If Not GlobalVariable.ArticleFamily = "" Then

        'lleFacturation.Text = "FACTURATION " & GlobalVariable.ArticleFamily
        'getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' AND TYPE_ARTICLE=@ARTICLEFAMILY ORDER BY DESIGNATION_FR ASC"

        'End If

        If Not GlobalVariable.ArticleFamily = "" Then

            If GlobalVariable.ArticleFamily = "BAR" Or GlobalVariable.ArticleFamily = "RESTAURANT" Then

                Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
                Command.Parameters.Add("@ARTICLEFAMILY1", MySqlDbType.VarChar).Value = "BAR"
                Command.Parameters.Add("@ARTICLEFAMILY2", MySqlDbType.VarChar).Value = "RESTAURANT"
                Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"
                'Command.Parameters.Add("@METHODE_SUIVI_STOCK", MySqlDbType.VarChar).Value = "Suivi simple"
                Command.Parameters.Add("@VISIBLE", MySqlDbType.Int64).Value = 1
                adapter.SelectCommand = Command
                adapter.Fill(table)

            Else

                Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
                Command.Parameters.Add("@ARTICLEFAMILY", MySqlDbType.VarChar).Value = GlobalVariable.ArticleFamily
                Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"
                'Command.Parameters.Add("@METHODE_SUIVI_STOCK", MySqlDbType.VarChar).Value = "Suivi simple"
                Command.Parameters.Add("@VISIBLE", MySqlDbType.Int64).Value = 1
                adapter.SelectCommand = Command
                adapter.Fill(table)

            End If

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

        'connect.closeConnection()

    End Sub

    Private Function prixUtilseConso(ByVal CODE_MAGASIN As String, ByVal article As DataTable) As Double

        Dim PRIX_CONSO_UTILISE As Double = 0

        Dim infoMagasin As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

        If infoMagasin.Rows.Count > 0 Then

            If infoMagasin.Rows(0)("PRIX_CONSO_UTILISE") = 1 Then
                PRIX_CONSO_UTILISE = article.Rows(0)("PRIX_CONSO")
            ElseIf infoMagasin.Rows(0)("PRIX_CONSO_UTILISE") = 2 Then
                PRIX_CONSO_UTILISE = article.Rows(0)("PRIX_CONSO2")
            ElseIf infoMagasin.Rows(0)("PRIX_CONSO_UTILISE") = 3 Then
                PRIX_CONSO_UTILISE = article.Rows(0)("PRIX_CONSO3")
            ElseIf infoMagasin.Rows(0)("PRIX_CONSO_UTILISE") = 4 Then
                PRIX_CONSO_UTILISE = article.Rows(0)("PRIX_CONSO4")
            Else
                PRIX_CONSO_UTILISE = article.Rows(0)("PRIX_CONSO")
            End If

        Else
            PRIX_CONSO_UTILISE = article.Rows(0)("PRIX_CONSO")
        End If

        Return PRIX_CONSO_UTILISE

    End Function

    Private Function prixUtilse(ByVal CODE_MAGASIN As String, ByVal article As DataTable) As Double

        Dim PRIX_UTILISE As Double = 0

        Dim infoMagasin As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

        If infoMagasin.Rows.Count > 0 Then

            If infoMagasin.Rows(0)("PRIX_UTILISE") = 1 Then
                PRIX_UTILISE = article.Rows(0)("PRIX_VENTE_HT")
            ElseIf infoMagasin.Rows(0)("PRIX_UTILISE") = 2 Then
                PRIX_UTILISE = article.Rows(0)("PRIX_VENTE1_HT")
            ElseIf infoMagasin.Rows(0)("PRIX_UTILISE") = 3 Then
                PRIX_UTILISE = article.Rows(0)("PRIX_VENTE2_HT")
            ElseIf infoMagasin.Rows(0)("PRIX_UTILISE") = 4 Then
                PRIX_UTILISE = article.Rows(0)("PRIX_VENTE3_HT")
            Else
                PRIX_UTILISE = article.Rows(0)("PRIX_VENTE_HT")
            End If

        Else
            PRIX_UTILISE = article.Rows(0)("PRIX_VENTE_HT")
        End If

        Return PRIX_UTILISE

    End Function


    'Filling the other fields concerning the article when the value of th room changes
    Private Sub GunaDataGridViewArticle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticle.CellClick

        If e.RowIndex >= 0 Then

            GunaDataGridViewArticle.Visible = False

            'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
            'il disparait de nouveau après ajout a la facture
            'En plus il ne peut pas aparaitre pour les clients comptoir, si il n'est associé à aucun numéro de bloc_note

            If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                If Trim(GunaTextBoxNomPrenomClient.Text) = "" Then
                    GunaButtonAjouterLigne.Visible = False
                Else

                    If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                        GunaButtonAjouterLigne.Visible = True
                    Else
                        If Trim(GlobalVariable.ArticleFamily = "SERVICES") Or Trim(GlobalVariable.ArticleFamily) = "BLANCHISSERIE" Then
                            GunaButtonAjouterLigne.Visible = True
                        End If
                    End If
                End If

            End If

            If GlobalVariable.AgenceActuelle.Rows(0)("PRIX_BAR_RESTAU_MODIFIABLE") = 1 Then
                GunaTextBoxMontantHT.Enabled = True
            Else

                If GlobalVariable.ArticleFamily = "SERVICES" Then
                    GunaTextBoxMontantHT.Enabled = True
                Else
                    GunaTextBoxMontantHT.Enabled = False
                End If

            End If

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

                codeArticle = Article.Rows(0)("CODE_ARTICLE")
                nomArticle = Article.Rows(0)("DESIGNATION_FR")

                If GlobalVariable.actualLanguageValue = 0 Then

                    If Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Simple tracking" Then
                        suivieStock = True
                    Else
                        suivieStock = False
                    End If

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    If Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Suivi simple" Then
                        suivieStock = True
                    Else
                        suivieStock = False
                    End If

                End If

                Double.TryParse(GunaTextBoxQuantite.Text, quantite)

                Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel

                'GunaTextBoxMontantHT.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0")

                GunaTextBoxMontantHT.Text = Format(prixUtilse(CODE_MAGASIN, Article), "#,##0")

                Double.TryParse(GunaTextBoxMontantHT.Text, montant)
                GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
                Double.TryParse(GunaTextBoxTVA.Text, TVA)
                montantHT = (quantite * montant)
                GunaTextBoxMontantTTC.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

                If Not Trim(Article.Rows(0)("CODE_SOUS_FAMILLE")) = "" Then

                    GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_SOUS_FAMILLE")
                    'End If
                Else
                    GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_FAMILLE")
                End If

                GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxPointDeVente.Text = Article.Rows(0)("TYPE_ARTICLE")

                '----------------------------------------------------------------------------------------------------------------------------
                'NOUS ALLONS AFFICHER NON PLUS LA QUANTITE DANS TOUS LES MAGASIN MAIS CELLE DU MAGASIN DE L'UTILISATEUR CONECTE

                Dim econom As New Economat()
                Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                Dim QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, codeArticle)
                Dim QUANTITE_DU_MAGASIN_ECONOMAT = Article.Rows(0)("QUANTITE")
                Dim NOMBRE_UNITE As Integer = 2

                gestionDesUnites(Article, QUANTITE_DU_MAGASIN_ACTUEL, NOMBRE_UNITE)

                '---------------------- START NEWLY ADDED ----------------------------

                'ON DETERMINE SI LE BOUTON DE GESTION DE STOCK A ETE CHOISI AU NIVEAU DE LA CREATION DES AGENCES
                Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

                If gestionDesStock = 0 Then

                    GunaTextBoxStockMagasin.Visible = False
                    Label20.Visible = False
                    GunaTextBoxConso.Visible = False
                    GunaLabel2.Visible = False

                ElseIf gestionDesStock = 1 Then

                    GunaTextBoxStockMagasin.Visible = True
                    Label20.Visible = True

                End If
                '---------------------- END NEWLY ADDED ------------------------------
                '--------------------------------------------------------------------------------------------------------------------------------

                'TRAITEMENT DE CONSOMATION
                'If Double.Parse(Article.Rows(0)("PRIX_CONSO")) > 0 Then
                If Integer.Parse(Article.Rows(0)("BOISSON")) = 1 Then

                    'ON RECUPERE LA CONSOMMATION
                    Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If Trim(Article.Rows(0)("CODE_CONSO")).Equals("") Then
                        conso = Nothing
                    End If

                    If conso.Rows.Count > 0 Then

                        GunaTextBoxConsoOnly.Visible = True
                        GunaLabel5.Visible = True
                        GunaLabel6.Visible = True

                        Dim valeurConversion As Double = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                        GunaTextBoxQuantiteConso.Text = valeurConversion

                        GunaTextBoxMontantHT.Text = Format(prixUtilseConso(CODE_MAGASIN, Article), "#,##0")

                        '---------------------------------------------------------------------------------------------------------------------------------------------

                        Dim nombreDeConsoTotal As Integer = 0
                        Dim nombreDeConsoTotal_ As Integer = QUANTITE_DU_MAGASIN_ECONOMAT

                        If gestionDesStock = 0 Then
                            'AFFICHAGE DES QUANTITES DU GRAND MAGASIN
                            'STOCK = CONTENANCE * QTE / VALEUR_NUMERIQUE
                            nombreDeConsoTotal = Article.Rows(0)("QUANTITE")
                            GunaTextBoxConso.Visible = False
                            GunaLabel2.Visible = False

                        ElseIf gestionDesStock = 1 Then
                            'AFFICHAGE DES QUANTITES DU PETIT MAGASIN

                            GunaTextBoxConso.Visible = True
                            GunaLabel2.Visible = True

                            If QUANTITE_DU_MAGASIN_ACTUEL > 0 Then
                                nombreDeConsoTotal = QUANTITE_DU_MAGASIN_ACTUEL
                            Else
                                GunaTextBoxStockMagasin.Text = 0
                            End If

                        End If

                        '---------------------------------------------------------------------------------------------------------------------------------------------
                        If GlobalVariable.actualLanguageValue = 0 Then

                            GunaTextBoxArticle.Text = "SHOT " & GunaTextBoxArticle.Text
                            GunaComboBoxUniteOuConso.SelectedItem = "SHOT"

                        ElseIf GlobalVariable.actualLanguageValue = 1 Then

                            GunaTextBoxArticle.Text = "CONSO " & GunaTextBoxArticle.Text
                            GunaComboBoxUniteOuConso.SelectedItem = "CONSOMMATION"

                        End If

                        If GlobalVariable.actualLanguageValue = 0 Then
                            If GunaComboBoxUniteOuConso.SelectedIndex < 0 Then
                                GunaComboBoxUniteOuConso.SelectedItem = "CONSOMMATION"
                            End If
                        End If

                        '-----------------------------------------------------------------------------------------------------------------------
                        Dim nombreDeBouteille As Double = 0
                        Dim nombreDeBouteille_ As Double = 0
                        Dim nombreDeConso As Integer = 0
                        Dim nombreDeConso_ As Integer = 0

                        Dim contenance As Double = Article.Rows(0)("CONTENANCE")

                        Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion) 'MAGASIN ACTUEL

                        If nombreDeConsoDansUneBouteille > 0 Then
                            nombreDeBouteille = Int(nombreDeConsoTotal / nombreDeConsoDansUneBouteille) 'MAGASIN ACTUEL
                            nombreDeBouteille_ = Int(nombreDeConsoTotal_ / nombreDeConsoDansUneBouteille) 'ECONOMAT
                            nombreDeConso = nombreDeConsoTotal Mod nombreDeConsoDansUneBouteille 'MAGASIN ACTUEL
                            nombreDeConso_ = nombreDeConsoTotal_ Mod nombreDeConsoDansUneBouteille 'ECONOMAT
                        End If

                        If gestionDesStock = 0 Then

                            GunaTextBoxStockEconomat.Text = Format(nombreDeBouteille_, "#,##0")
                            GunaTextBoxConsoOnly.Text = Format(nombreDeConso_, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                        ElseIf gestionDesStock = 1 Then

                            GunaLabel4.Visible = True
                            GunaComboBoxUniteOuConso.Visible = False
                            GunaLabel6.Visible = False
                            GunaLabel6.Visible = True

                            'MessageBox.Show(GlobalVariable.magasinActuel & " Qte : " & QUANTITE_DU_MAGASIN_ACTUEL & " nbre de conso dans bouteille : " & nombreDeConsoDansUneBouteille & " nbre total de conso : " & nombreDeConsoTotal)

                            GunaTextBoxStockEconomat.Text = Format(nombreDeBouteille_, "#,##0")
                            GunaTextBoxConsoOnly.Text = Format(nombreDeConso_, "#,##0")

                            GunaTextBoxStockMagasin.Text = Format(nombreDeBouteille, "#,##0")
                            GunaTextBoxConso.Text = Format(nombreDeConso, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                        End If
                        '------------------------------------------------------------------------------------------------------------------------

                        GunaComboBoxUniteOuConso.Visible = True

                    Else
                        GunaComboBoxUniteOuConso.Visible = False
                        GunaTextBoxConsoOnly.Visible = False
                        GunaLabel5.Visible = False
                        GunaLabel6.Visible = False
                    End If

                Else

                    GunaTextBoxStockEconomat.Text = Format(QUANTITE_DU_MAGASIN_ECONOMAT, "#,##0")

                    GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0")

                    GunaTextBoxConso.Text = 0
                    GunaTextBoxConsoOnly.Text = 0
                    GunaTextBoxConso.Visible = False

                    GunaComboBoxUniteOuConso.Visible = False
                    GunaTextBoxConsoOnly.Visible = False
                    GunaLabel5.Visible = False
                    GunaLabel6.Visible = False
                    GunaComboBoxUniteOuConso.Visible = False

                End If

                GunaDataGridViewArticle.Visible = False

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid
                clearArticleFields()

            End If

            GunaComboBoxUniteOuConso.Visible = True
            'connect.closeConnection()

        End If

    End Sub

    Public Sub gestionDesUnites(ByVal Article As DataTable, ByVal QUANTITE_DU_MAGASIN_ACTUEL As String, ByVal NOMBRE_UNITE As Integer)

        GunaComboBoxUniteOuConso.Items.Clear()

        Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")
        Dim CODE_CONSO As String = Article.Rows(0)("CODE_CONSO")

        Dim conso As DataTable = Functions.getElementByCode(CODE_CONSO, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

        Dim pasDeConso As Boolean = False

        If Article.Rows(0)("BOISSON") = 1 Then
            If conso.Rows.Count > 0 Then
                GunaComboBoxUniteOuConso.Items.Add("CONSOMMATION")
                pasDeConso = True
            End If
        End If

        Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

        If unite.Rows.Count > 0 Then

            If unite.Rows(0)("VALEUR_NUMERIQUE") >= 1 Then
                GunaComboBoxUniteOuConso.Items.Add(unite.Rows(0)("PETITE_UNITE"))
            End If

            If NOMBRE_UNITE = 3 Then
                GunaComboBoxUniteOuConso.Items.Add(unite.Rows(0)("GRANDE_UNITE"))
            End If

            If Not pasDeConso Then
                'ON A QUE UNE SEULE UNITE A SAVOIR LA PETITE UNITE
                If NOMBRE_UNITE = 2 Then
                    'AFFICHAGE POUR LE BAR RESTAURANT
                    GunaComboBoxUniteOuConso.SelectedItem = unite.Rows(0)("PETITE_UNITE")
                ElseIf NOMBRE_UNITE = 3 Then
                    'AFFICHAGE POUR L'ECONOMAT
                    GunaComboBoxUniteOuConso.SelectedItem = unite.Rows(0)("GRANDE_UNITE")
                End If

            End If

        End If

    End Sub
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonFermer.Click
        discounStays = False
        GlobalVariable.checkInFacturation = False
        Me.Close()

    End Sub

    'Creation of invoice depending on if we come from the frontdesk or MenuStripItem that will be updated later

    Public Sub FacturationCreation()

        'Variables for filling the facturation data

        Dim CODE_FACTURE As String = GunaTextBoxNumfacture.Text

        Dim CODE_RESERVATION As String
        Dim CODE_CLIENT As String

        Dim NOM_CLIENT_FACTURE As String

        If Not GlobalVariable.codeClientToUpdate = "" Then

            'We come from frontdesk
            CODE_RESERVATION = GlobalVariable.codeReservationToUpdate
            CODE_CLIENT = GlobalVariable.codeClientToUpdate
            NOM_CLIENT_FACTURE = GlobalVariable.ClientToUpdate(0)("NOM_PRENOM")

        Else

            'we are not from the front desk
            CODE_RESERVATION = Trim(GunaTextBoxNumReservation.Text)
            CODE_CLIENT = Trim(GunaTextBoxNomPrenomClient.Text)
            NOM_CLIENT_FACTURE = Trim(GunaTextBoxNom_Prenom.Text)

        End If

        Dim CODE_COMMANDE As String = ""
        Dim NUMERO_TABLE As String = ""
        Dim CODE_MODE_PAIEMENT As String = ""
        Dim NUM_MOUVEMENT As String = ""
        Dim DATE_FACTURE As Date = GlobalVariable.DateDeTravail

        Dim CODE_COMMERCIAL As String = ""

        Dim MONTANT_HT As Double = 0
        Dim TAXE As Double = 0
        Dim MONTANT_TTC As Double = 0
        Dim AVANCE As Double = 0
        Dim RESTE_A_PAYER As Double = 0
        Dim DATE_PAIEMENT As Date
        Dim ETAT_FACTURE As String = 0
        Dim LIBELLE_FACTURE As String = LibelleFacturation.Text
        Dim MONTANT_TRANSPORT As Double = 0
        Dim MONTANT_REMISE As Double = 0
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.codeUser
        Dim CODE_UTILISATEUR_ANNULE As String = ""
        Dim CODE_UTILISATEUR_VALIDE As String = ""
        Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")

        Dim MONTANT_AVANCE As Double = 0
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim facture As New Facture()

        CODE_FACTURE = GunaTextBoxNumfacture.Text

        'codeClientToUpdate has a value so we come from front office
        If Not GlobalVariable.codeClientToUpdate = "" Then

            'Facturation of client from front office (client checkedIn)

            'To avoid inserting a newly generated CODE_RESERVATION
            CODE_RESERVATION = GlobalVariable.codeReservationToUpdate

            'If facture.insertFacture(CODE_FACTURE, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT, TAXE, MONTANT_TTC, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, LIBELLE_FACTURE, MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE) Then

            'End If

        Else

            'Direct Facturation or Facturation of client  that are not found in the hotel so we come from the MenuStripIte

            'The reservation is not associated to an invoice

            '-------------------------- FACTURATION  DES CLIENT EN CHAMBRES--------------------------

            If Not Functions.entryCodeExists(CODE_FACTURE, "facture", "CODE_FACTURE") Then

                If facture.insertFacture(CODE_FACTURE, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT, TAXE, MONTANT_TTC, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, LIBELLE_FACTURE, MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE, GRIFFE_UTILISATEUR) Then

                End If

            End If

        End If

    End Sub

    Dim suivieStock As Boolean = False

    Public Function gestionDesStocks(ByVal CODE_ARTICLE As String) As Boolean

        '2klg

        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim magasin As Integer = Integer.Parse(GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("PETIT_MAGAZIN"))

        Dim proceder As Boolean = True
        Dim controlerLeStock As Boolean = True

        'TOUT ELEMENTS SUR LEQUEL ON A DESATIVE LA GESTION DES STOCK NE FERA PAS L'OBBJET DE CONTROL DE STOCK

        If suivieStock Then

            Dim CONSOMMATION As String = ""

            Dim UNITE_DE_VENTE As String = ""

            If GunaComboBoxUniteOuConso.SelectedIndex >= 0 Then

                UNITE_DE_VENTE = GunaComboBoxUniteOuConso.SelectedItem.ToString()

                If GunaComboBoxUniteOuConso.Items.Count > 1 Then
                    CONSOMMATION = " Conso"
                End If

            End If
            'A.1. ON DETERMINE SI ON DOIT GERER LE STOCK EN NEGATIF OU PAS

            If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then

                '1- VERIFIEER QU'ON A LE DROIT A UN MAGASIN

                '1.1. SI OUI

                If magasin = 1 Then

                    '1.1.1. ON VERIFIE QUE ON NOUS A EFFECTE UN PETIT MAGASIN

                    If Not Trim(GlobalVariable.magasinActuel) = "" Then

                        Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                        '1.1.1.1. SI OUI : A ETE AFFECTE A UN MAGASIN

                        'GESTION DES STOCK EN POSITIFS
                        'A.1.1- GESTION DES SEUILS DES REAPPROVISIONNEMENT
                        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                        Dim infoSupArticle As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_ARTICLE, "article", "CODE_ARTICLE", CODE_AGENCE, "CODE_AGENCE")

                        If infoSupArticle.Rows.Count > 0 Then

                            Dim econom As New Economat()

                            Dim QTE_REAPPROVISIONNEMENT_PETIT_MAGASIN As Double = infoSupArticle.Rows(0)("TAUX_EXONERATION_TVA") 'USED AS QTE REAPPROVISIONNEMENT PETIT MAAGSIN

                            'NB: LA QUANTITE DE REAPPROVISIONNEMENT DU PETIT MAGASIN EST FONCTION DE LA PETITE UNITE AFFICHEE
                            'COMPARE LA QTE DEMANDE AVEC LA QUANTITE EN STOCK SUIVANT LA PLUS PETITE UNITE

                            'ON VERIFIE SI ON A LE STOCK SUFFISANT POUR VENDRE ET SI IL FAUT EFFECTUER DES DEMANDES DE REAPPROVISIONNEMENT
                            Dim QUANTITE_DU_MAGASIN_ACTUEL As Double = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, codeArticle)

                            Dim QUANTITE_VOULU As Double = Double.Parse(GunaTextBoxQuantite.Text)

                            QUANTITE_VOULU = Functions.conversionEnPlusPetiteUnite(CODE_ARTICLE, QUANTITE_VOULU, UNITE_DE_VENTE)

                            Dim UNITE_COMPTAGE As String = infoSupArticle.Rows(0)("UNITE_COMPTAGE")
                            Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                            If unite.Rows.Count > 0 Then

                                If unite.Rows(0)("VALEUR_NUMERIQUE") >= 1 Then
                                    'QUANTITE DU MAGASIN ACTUEL FONCTION DE LA PETITE UNITE
                                    QUANTITE_DU_MAGASIN_ACTUEL = QUANTITE_DU_MAGASIN_ACTUEL * unite.Rows(0)("VALEUR_NUMERIQUE")
                                End If

                            End If

                            'B. ON VERIFIE SI L'ARTICLE EST A LA CARTE

                            Dim PLAT_A_LA_CARTE As Integer = infoSupArticle.Rows(0)("CARTE")

                            If PLAT_A_LA_CARTE = 1 Then
                                'B.1- SI OUI : ON VERIFIE SI L'ARTICLE EST ASSOCIE A UNE FICHE TECHNIQUE

                                Dim CODE_FICHE_TECHNIQUE As String = infoSupArticle.Rows(0)("CODE_CLE")

                                If Not Trim(CODE_FICHE_TECHNIQUE) = "" Then
                                    'SI OUI : 'B.1.1. IL NE DOIT PAS ETRE SUJET ON CONTROLE DE STOCK
                                    controlerLeStock = False
                                End If

                            Else
                                'B.2- SI NON
                            End If

                            If controlerLeStock Then

                                If QUANTITE_DU_MAGASIN_ACTUEL <= QTE_REAPPROVISIONNEMENT_PETIT_MAGASIN Then
                                    'A.1.2. ON A ATTEINT LE NIVEAU DE DEMANDE DE REAPPROVISIONNEMENT
                                    MessageBox.Show("Vous devez faire une demande de réapprovisionnement !!", "GESTION DES STOCKS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                            End If

                            'ON VERIFIE SI ON TRAITE LES CONSOMMATIONS

                            If GunaComboBoxUniteOuConso.SelectedItem = "CONSOMMATION" Then

                                Dim CODE_CONSO As String = infoSupArticle.Rows(0)("CODE_CONSO")
                                Dim CONTENANCE As Double = infoSupArticle.Rows(0)("CONTENANCE")
                                Dim conso As DataTable = Functions.getElementByCode(CODE_CONSO, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                                If conso.Rows.Count > 0 Then
                                    'ON DOIT DERTEMINER LA QUANTITE DE CONSO DEMANDE EN BOUTEILLE
                                    QUANTITE_VOULU = (QUANTITE_VOULU * conso.Rows(0)("VALEUR_NUMERIQUE")) / CONTENANCE

                                    'FORMULE DE PASSAGE DE LA BOUTEILLE A CONSOSSMATION = CONTENANCE_DE_LA_BOUTEILLE / VOLUME_DE_LA_CONSO

                                    'FORMULE DE PASSAGE DE LA CONSOSSMATION A BOUTEILLE= NOMBRE_DE_CONSOMMATION * VOLUME_DE_LA_CONSO / CONTENANCE_DE_LA_BOUTEILLE
                                Else
                                    proceder = False
                                End If

                            End If

                            If controlerLeStock Then

                                'ON VERIFIE SI LE STOCK EST SUFFISANT
                                If QUANTITE_DU_MAGASIN_ACTUEL >= QUANTITE_VOULU Then
                                    'A.1.2.1. LE STOCK EST SUFFISANT POUR LA QUANTITE DEMANDE => VENTE NORMAL

                                Else
                                    'A.1.2.2. LE STOCK EST INSUFFISANT POUR LA QUANTITE DEMANDE
                                    MessageBox.Show("Le Stock de " & infoSupArticle.Rows(0)("DESIGNATION_FR") & " étant de " & QUANTITE_DU_MAGASIN_ACTUEL & CONSOMMATION & " en magasin est  insuffisant !!", "GESTION DES STOCKS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    proceder = False
                                End If

                            End If

                        End If

                    Else

                        '1.1.1.2. SI NON : AUCUN MAGASIN AFFECTE
                        MessageBox.Show("Aucun magasin ne vous a été affecté !!", "GESTION DES MAGASINS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        proceder = False

                    End If

                Else
                    '1.2. SI NON
                    MessageBox.Show("Vous n'avez pas droit a un magasin !!", "GESTION DES MAGASINS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    proceder = False

                End If

            End If

            '1.1.1. TRAITEMENT DES UNITES (STOCKAGE ET DESTOCKAGE)
        End If

        Return proceder

    End Function

    Dim TITRE_CONSOMMATION As String = ""

    'We save the ligne facture
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click

        Dim infoSup As DataTable = Functions.getElementByCode(Trim(GunaTextBoxArticle.Text), "article", "DESIGNATION_FR")

        If infoSup.Rows.Count > 0 Then

            Dim proceder As Boolean = False

            proceder = gestionDesStocks(codeArticle)

            If proceder Then

                GunaButtonAjouterLigne.Visible = False

                Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCodePanne("mouvement_stock", "MS")

                Dim CODE_CHAMBRE As String = TB_RoomNo.Text
                Dim CODE_MODE_PAIEMENT As String = GunaTextBoxNom_Prenom.Text
                Dim NUMERO_PIECE As String = GunaTextBoxNomPrenomClient.Text
                Dim CODE_ARTICLE As String = codeArticle
                Dim CODE_LOT As String = ""

                If GunaComboBoxUniteOuConso.SelectedIndex >= 0 Then
                    CODE_LOT = GunaComboBoxUniteOuConso.SelectedItem 'USED AS UNITE DE COMPTAGE => USED TO KNOW HOW TO MANIPULATE THE REMOVAL OF QUANTITIES
                End If

                Dim TAXE As Double = Double.Parse(GunaTextBoxTVA.Text)
                Dim QUANTITE As Double = Trim(GunaTextBoxQuantite.Text)
                'Dim MONTANT_HT As Double = (Trim(GunaTextBoxMontantHT.Text) * QUANTITE) - GunaTextBoxMontantReduction.Text
                Dim MONTANT_HT As Double = (Trim(GunaTextBoxMontantHT.Text) * QUANTITE)
                'Dim PRIX_UNITAIRE_TTC As Double = Trim(GunaTextBoxMontantTTC.Text - GunaTextBoxMontantReduction.Text) / Trim(GunaTextBoxQuantite.Text)
                Dim PRIX_UNITAIRE_TTC As Double = Trim(GunaTextBoxMontantTTC.Text) / Trim(GunaTextBoxQuantite.Text)
                'Dim MONTANT_TTC As Double = Double.Parse(Trim(GunaTextBoxMontantTTC.Text) - GunaTextBoxMontantReduction.Text)
                Dim MONTANT_TTC As Double = Double.Parse(Trim(GunaTextBoxMontantTTC.Text))
                Dim DATE_FACTURE As Date = GlobalVariable.DateDeTravail.ToShortDateString()
                Dim HEURE_FACTURE As DateTime = Date.Now().ToShortTimeString
                Dim ETAT_FACTURE As Integer = 0
                Dim DATE_OCCUPATION As Date = GlobalVariable.DateDeTravail
                Dim HEURE_OCCUPATION As DateTime = Date.Now().ToShortTimeString

                Dim VALEUR_CONSO = 0

                If Not Trim(GunaTextBoxQuantiteConso.Text) = "" Then
                    VALEUR_CONSO = Double.Parse(GunaTextBoxQuantiteConso.Text)
                    'TITRE_CONSOMMATION = "CONSOMMATION "
                End If

                Dim LIBELLE_FACTURE As String = TITRE_CONSOMMATION & GunaTextBoxArticle.Text
                Dim TYPE_LIGNE_FACTURE As String = GunaTextBoxPointDeVente.Text
                Dim NUMERO_SERIE As String = ""
                Dim NUMERO_ORDRE As Double = 0
                Dim DESCRIPTION As String = ""
                Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                Dim MONTANT_REMISE As Double = 0
                Dim MONTANT_TAXE As Double = GunaTextBoxMontantTTC.Text - GunaTextBoxMontantHT.Text
                Dim NUMERO_SERIE_DEBUT As String = ""
                Dim NUMERO_SERIE_FIN As String = ""
                Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel 'MAGASIN ACTUEL DE L'UTILISSATEUR CONNECTE
                Dim FUSIONNEE As String = GunaTextBoxSousFamilleArticle.Text
                Dim CODE_FACTURE As String = GunaTextBoxNumfacture.Text
                Dim TYPE As String = GlobalVariable.typeChambreOuSalle

                Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")

                'To be initialise
                Dim CODE_RESERVATION As String = ""

                If Not GlobalVariable.codeReservationToUpdate = "" Then

                    CODE_RESERVATION = GlobalVariable.codeReservationToUpdate

                    Dim resa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                    If resa.Rows.Count > 0 Then
                        CODE_CHAMBRE = resa.Rows(0)("CHAMBRE_ID")
                    End If

                ElseIf Not Trim(GunaTextBoxNumReservation.Text) = "" Then

                    CODE_RESERVATION = GunaTextBoxNumReservation.Text

                    If Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION").Rows.Count > 0 Then

                        CODE_CHAMBRE = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION").Rows(0)("CHAMBRE_ID")

                    End If

                Else

                    CODE_RESERVATION = "-"
                    CODE_CHAMBRE = "-"

                End If

                Dim ligneFacture As New LigneFacture()

                Dim TABLE_LIGNE As String = "ligne_facture_temp"

                Dim NUMERO_BLOC_NOTE As String = ""

                '-------------------------- LIGNE FACTURATION--------------------------

                If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                    NUMERO_BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString

                    Dim MONTANT_BLOC_NOTE As Double = Trim(GunaTextBoxMontantTTC.Text) - Trim(GunaTextBoxMontantReduction.Text)

                    'MISE A JOURS DU BLOC NOTE DES ENCHAMBRE

                    Functions.updateMontantBlocNOteEnChambre(NUMERO_BLOC_NOTE, CODE_RESERVATION, MONTANT_BLOC_NOTE)

                End If

                If Trim(CODE_FACTURE) = "" Then
                    CODE_FACTURE = Functions.GeneratingRandomCode("ligne_facture", "")
                    GunaTextBoxNumfacture.Text = CODE_FACTURE
                End If

                If ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO) Then
                    'FUSIONNEE : UTILISE COMME SOUS FAMILLE DE L'ARTICLE
                End If

                If GunaTextBoxMontantReduction.Text > 0 Then

                    LIBELLE_FACTURE = "REMISE DE " & "[" & GunaTextBoxRemise.Text & " %]" & " SUR " & LIBELLE_FACTURE

                    MONTANT_TTC = GunaTextBoxMontantReduction.Text * -1
                    MONTANT_HT = GunaTextBoxMontantReduction.Text * -1
                    QUANTITE = 1

                    If ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO) Then
                        'FUSIONNEE : UTILISE COMME SOUS FAMILLE DE L'ARTICLE
                    End If

                End If

                Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

                GunaComboBoxUniteOuConso.Visible = False

                'Refresh Datagrid To view newly inserted Articles
                OutPutLigneFacture()

                'We Refresh the general information concerning the Invoice
                FacturationKeyInformation()

                'Determining wether or not to save a facturation
                DisplaySavingButton()

                'Refreshing the client solde
                'We update the value of the solde at the level of the front desk
                Dim MainForm As New MainWindow()

                If Not GlobalVariable.codeReservationToUpdate = "" Then
                    MainForm.GunaLabelSolde.Text = Functions.SituationDuClient(GlobalVariable.codeReservationToUpdate)
                End If

                Dim MONTANT_BLOC_NOTE_ As Double = GunaTextBoxMontantTTCGeneral.Text
                Functions.updateOfFields("ligne_facture_bloc_note", "MONTANT_BLOC_NOTE", MONTANT_BLOC_NOTE_, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 0)

            End If

            'After adding a line we clear the article field

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Unknown Article"
                languageTitle = "Article"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Article inconnu"
                languageTitle = "Article"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        clearArticleFields()

    End Sub

    'When ever the quantity changes we do back all calculations
    Private Sub GunaTextBoxQuantite_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxQuantite.TextChanged

        If Trim(GunaTextBoxRemise.Text) = "" Then
            GunaTextBoxRemise.Text = 0
        End If

        Double.TryParse(GunaTextBoxQuantite.Text, quantite)
        'GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
        Double.TryParse(GunaTextBoxMontantHT.Text, montant)
        Double.TryParse(GunaTextBoxTVA.Text, TVA)
        montantHT = (quantite * montant)
        GunaTextBoxMontantTTC.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

        GunaTextBoxMontantReduction.Text = Format((GunaTextBoxMontantTTC.Text * GunaTextBoxRemise.Text) / 100, "#,##0")

    End Sub

    'We load the data (articles) related to the current invoice into a datagrid to view the content of the invoice
    Public Sub OutPutLigneFacture()

        Dim query As String = ""

        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

        'POUR LES EVENEMENTS SUIVANTS CODE_DE_RESERVATION
        'POUR LES AUTRES SUIVANTS EN CHAMBRE ET COMPTOIR CODE_FACTURE
        'If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
        query = "SELECT CODE_FACTURE, ID_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC', ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR' FROM ligne_facture_temp INNER JOIN article WHERE ligne_facture_temp.CODE_ARTICLE = article.CODE_ARTICLE  AND CODE_RESERVATION =@CODE_RESERVATION AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' ORDER BY ID_LIGNE_FACTURE DESC"
        'Else
        'query = "SELECT ID_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC', ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR' FROM ligne_facture_temp INNER JOIN article WHERE ligne_facture_temp.CODE_ARTICLE = article.CODE_ARTICLE  AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"
        'End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)

        'If GlobalVariable.typeDeClientAFacturer = "evenement" Then
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GunaTextBoxNumReservation.Text
        'Else
        'command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = GunaTextBoxNumfacture.Text
        'End If

        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaDataGridViewLigneFacture.Columns.Clear()

            GunaDataGridViewLigneFacture.DataSource = table

            GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Format = "#,##0.00"
            GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.00"
            GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Format = "#,##0.00"
            GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Format = "#,##0.00"
            GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            GunaDataGridViewLigneFacture.Columns("ARTICLE").Visible = False
            GunaDataGridViewLigneFacture.Columns("ID_LIGNE_FACTURE").Visible = False

            If firstLoad Then
                GunaTextBoxNumfacture.Text = table.Rows(0)("CODE_FACTURE")
                firstLoad = False
            End If

        Else
            'GunaDataGridViewLigneFacture.Columns.Clear()
        End If

        'connect.closeConnection()
    End Sub

    Dim firstLoad As Boolean = False

    'We fill the general information concerning the Invoice (montant HT and Montant TTC)
    Public Sub FacturationKeyInformation()

        Dim MontantHTGeneral As Double = 0
        Dim MontantTTCGeneral As Double = 0

        Dim FacturationLineList As DataTable = Functions.getElementByCode(GunaTextBoxNumfacture.Text, "ligne_facture_temp", "CODE_FACTURE")

        If FacturationLineList.Rows.Count > 0 Then

            For i = 0 To FacturationLineList.Rows.Count - 1
                MontantHTGeneral = MontantHTGeneral + FacturationLineList.Rows(i)("MONTANT_HT")
                MontantTTCGeneral = MontantTTCGeneral + FacturationLineList.Rows(i)("MONTANT_TTC")
            Next

        End If

        GunaTextBoxMontantTTCGeneral.Text = Format(MontantTTCGeneral, "#,##0")
        'GunaTextBoxSoldeClient.Text = Format(MontantHTGeneral, "#,##0")

    End Sub

    'We save the facturation ----------- SAVING FACTURATION INFORMATION ----------------

    Private Sub GunaButtonSaveFacturation_Click(sender As Object, e As EventArgs) Handles GunaButtonSaveFacturation.Click

        'FACTURATION FORM

        'la caisse doit etre ouverte avant toute facturation

        Dim ETAT_CAISSE As Integer = 0

        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

        Dim CODE_CAISSE As String = ""

        Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

        Dim CODE_RESERVATION As String = GunaTextBoxNumReservation.Text

        Dim imprimerCommandeEnChambre As Boolean = False
        Dim imprimerCommandeComptoir As Boolean = False

        Dim dt As DataGridView
        Dim NOM_CLIENT As String = ""
        Dim NUM_FACTURE As String = ""
        Dim CHAMBRE As String = ""
        Dim BLOC_A_REGLER As String = ""

        dt = GunaDataGridViewLigneFacture

        If CAISSE_UTILISATEUR.Rows.Count > 0 Then
            ETAT_CAISSE = CAISSE_UTILISATEUR.Rows(0)("ETAT_CAISSE")
        End If

        If ETAT_CAISSE = 0 Then

            '---------------------------------------- 

            '1- VERIFICATION DE DROIT DE CAISSE
            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 1 Then

                '2- VERIFICATION DE CAISSE

                Dim possedeUneCaisse As Boolean = False

                possedeUneCaisse = Functions.detentionDeCaisse(CODE_UTILISATEUR)

                If possedeUneCaisse Then

                    '----------------------------------------
                    Dim dialog As DialogResult

                    If GlobalVariable.actualLanguageValue = 1 Then
                        dialog = MessageBox.Show("Bien vouloir ouvrir votre caisse !! ", "Gestion de caisse", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Else
                        dialog = MessageBox.Show("Please Open your cash box !! ", "Cash Box Management", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    End If

                    If dialog = DialogResult.No Then
                        'e.Cancel = True
                    Else

                        'DEMANDE DE MOT DE PASSE AVANT DE PERMETTRE L'OUVERTURE DE CAISSE

                        GlobalVariable.fenetreDouvervetureDeCaisse = "reception"

                        passwordVerifivationForm.Show()

                        'GestionOuvertureDeCaisse()

                    End If

                Else

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Vous n'avez pas de caisse", "Gestion Caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("You don't have a cash box", "Cash box management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Vous n'avez pas droit a une caisse", "Gestion Caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("You don't have the right to own a cash box", "Cash box Management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If


        Else

            'CAISSE OUVERTE 

            If Trim(GunaTextBoxNom_Prenom.Text) = "" Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Impossible d'enregistrer car aucun client" & Chr(13) & "n'est associé à la facturation!!", "Facturation")
                Else
                    MessageBox.Show("Impossible to save as the billing" & Chr(13) & "is not associated to a client", "Billing")
                End If

            Else

                Me.Cursor = Cursors.WaitCursor

                If Trim(GunaButtonSaveFacturation.Text) = "Enregistrer" Or Trim(GunaButtonSaveFacturation.Text) = "Save" Then

                    'EN CHAMBRE
                    Dim facturation As New LigneFacture()


                    'kklg GunaButtonSaveFacturation.Visible = False

                    facturation.MigrationDeLigneFatureTempVersLigneFactureEnChambre(Trim(GunaTextBoxNumReservation.Text))

                    Dim NUMERO_BLOC_NOTE As String = ""

                    If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                        NUMERO_BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString
                    End If

                    GunaComboBoxListeDesComandes.DataSource = Nothing

                    Functions.updateEtatBlocNOteEnChambre(NUMERO_BLOC_NOTE, GunaTextBoxNumReservation.Text, 2)

                    GunaDataGridViewLigneFacture.Columns.Clear()
                    'GunaButtonSaveFacturation.Visible = False

                    'Managing the creation of facturation based on if the client is in room or not
                    FacturationCreation()

                    'On charge l'ensemble des lignes factures créer dans la facture correspondate

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Facture Bien Enregistrée", "Enregistrement Facture", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Successfully saved", "Successfully saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    'We load all the data found into ligne_facture_temp into the related facture
                    Dim facture As New Facture()

                    Dim MontantHTGeneral As Double = 0
                    Dim MontantTTCGeneral As Double = 0

                    Dim FacturationLineList As DataTable = Functions.getElementByCode(GunaTextBoxNumfacture.Text, "ligne_facture_temp", "CODE_FACTURE")

                    If FacturationLineList.Rows.Count > 0 Then

                        For i = 0 To FacturationLineList.Rows.Count - 1
                            MontantHTGeneral = MontantHTGeneral + FacturationLineList.Rows(i)("MONTANT_HT")
                            MontantTTCGeneral = MontantTTCGeneral + FacturationLineList.Rows(i)("MONTANT_TTC")
                        Next

                    End If

                    GunaTextBoxMontantTTCGeneral.Text = Format(MontantTTCGeneral, "#,##0")
                    'GunaTextBoxSoldeClient.Text = Format(MontantHTGeneral, "#,##0")

                    'facture.updateFactureBeforeSave(CODE_FACTURE, MONTANT_HT, MONTANT_TTC, RESTE_A_PAYER, MONTANT_REMISE, MONTANT_AVANCE)

                    'We have to update Account: compte at DEBIT
                    Dim compte As New Compte()
                    Dim compteClient As DataTable

                    'Obtained when we validate the field used to search a client
                    Dim CODE_CLIENT As String = GunaTextBoxNomPrenomClient.Text

                    compteClient = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                    Dim NUMERO_COMPTE As String = ""

                    If compteClient.Rows.Count > 0 Then

                        NUMERO_COMPTE = compteClient.Rows(0)("NUMERO_COMPTE")

                        'total credit used for testing purpose only same value will de saved back into database
                        Dim TOTAL_DEBIT As Double = MontantTTCGeneral
                        Dim TOTAL_CREDIT As Double = compteClient.Rows(0)("TOTAL_CREDIT")

                        Dim SOLDE_COMPTE As Double = TOTAL_CREDIT - (MontantTTCGeneral + compteClient.Rows(0)("TOTAL_DEBIT"))

                        Dim SENS_DU_SOLDE As String

                        If SOLDE_COMPTE > 0 Then
                            SENS_DU_SOLDE = "crediteur"
                        ElseIf 0 > SOLDE_COMPTE Then
                            SENS_DU_SOLDE = "dediteur"
                        Else
                            SENS_DU_SOLDE = "equilibre"
                        End If

                        'On insère le montant de la facture au debit
                        compte.updateCompteAuDebit(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, SOLDE_COMPTE, SENS_DU_SOLDE)

                    End If

                    '--------------------------------------------- ----------------------------------------------------------
                    Dim MainForm As New MainWindow()
                    'We update the value of the solde at the level of the front desk
                    If True Then

                        Dim solde As Double = Functions.SituationDeReservation(CODE_RESERVATION)

                        'MainForm.GunaLabelSolde.Text = Functions.SituationDuClient(GlobalVariable.codeClientToUpdate)
                        MainWindow.GunaLabelSolde.Text = Format(solde, "#,##0")

                        If 0 > solde Then
                            MainWindow.GunaLabelSolde.ForeColor = Color.Red
                        ElseIf solde = 0 Then
                            MainWindow.GunaLabelSolde.ForeColor = Color.Black
                        Else
                            MainWindow.GunaLabelSolde.ForeColor = Color.Green
                        End If

                        MainWindow.Refresh()

                        '------------------------------------ MISE A JOURS DES DONNEES DES UTILISATEURS ----------------------------------------

                        Dim mainCouranteJournaliere As DataTable = Functions.getElementByCode(GlobalVariable.codeMainCouranteJournaliereToUpdate, "main_courante_journaliere", "CODE_MAIN_COURANTE_JOURNALIERE")

                        If mainCouranteJournaliere.Rows.Count > 0 Then

                            Dim produitSup As Double = 0

                            produitSup = mainCouranteJournaliere.Rows(0)("SERVICES") + mainCouranteJournaliere.Rows(0)("SALON_DE_BEAUTE") + mainCouranteJournaliere.Rows(0)("BOUTIQE") + mainCouranteJournaliere.Rows(0)("CYBERCAFE") + mainCouranteJournaliere.Rows(0)("AUTRES") + mainCouranteJournaliere.Rows(0)("SPORTS") + mainCouranteJournaliere.Rows(0)("LOISIRS") + mainCouranteJournaliere.Rows(0)("KIOSQUE_A_JOURNAUX") + mainCouranteJournaliere.Rows(0)("BLANCHISSERIE")

                            'Pris des repase
                            MainWindow.GunaTextBoxprixRepas.Text = Format(mainCouranteJournaliere.Rows(0)("BAR_RESTAURANT"), "#,##0")
                            MainWindow.GunaTextBoxServiceEtProduitSup.Text = Format(produitSup, "#,##0")
                            '---------------------------------------------------------------------------------------------------------------------

                        End If

                    End If

                    'MISE A JOUR DU SOLDE DU CLIENT ON DOIT PRENDRE EN COMPTE LE FAIT CLIENT COMPTOIRE OU EN CHAMBRE
                    Dim reservation As New Reservation()

                    'On met a jour le solde du client en chambre

                    If GlobalVariable.checkInFacturation Then 'Si l'on vient du front desk
                        reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))
                    ElseIf GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                        reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))
                    End If

                    Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION)

                    'Supression de ligne lié a la facture dans ligne_facture_temp
                    If GunaButtonSaveFacturation.Text = "Enregistrer" Or GunaButtonSaveFacturation.Text = "Save" Then
                        Functions.DeleteElementByCode(GunaTextBoxNumReservation.Text, "ligne_facture_temp", "CODE_RESERVATION")
                    End If

                End If

                'GunaTextBoxSoldeClient.Text = 0
                GunaTextBoxTVARecap.Text = 0
                GunaTextBoxMontantTTCGeneral.Text = 0

                'Determining wether or not to save a facturation
                If GlobalVariable.checkInFacturation Then
                    DisplaySavingButton()
                End If

                'Facturation calculator
                FacturationKeyInformation()

                DisplaySavingButton()

                'Génération de code de la proforma
                If Not GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                    GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("facture", "")
                End If

                If imprimerCommandeComptoir Then
                    Impression.commandeImpression(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE, BLOC_A_REGLER)
                End If

                If imprimerCommandeEnChambre Then
                    Impression.commandeImpression(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE)
                End If

                GunaDataGridViewClient.Visible = False

                SituationDeCaisseJournaliere()

                Me.Cursor = Cursors.Default

            End If

        End If

    End Sub

    Public Sub SituationDeCaisseJournaliere()

        Dim situationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

        Dim TotalFacture As Double = 0

        If situationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To situationDeCaisse.Rows.Count - 1
                TotalFacture += situationDeCaisse.Rows(i)("MONTANT_VERSE")
            Next

            Dim situationDeCaisseCasDeRemboursement As DataTable = Functions.SituationDeCaisseCasDeRemboursement(GlobalVariable.DateDeTravail)

            Dim TotalRembourse As Double = 0
            'On selection l'ensemble des remboursement d'un jour donné
            If situationDeCaisseCasDeRemboursement.Rows.Count > 0 Then

                For j = 0 To situationDeCaisseCasDeRemboursement.Rows.Count - 1
                    TotalRembourse += situationDeCaisseCasDeRemboursement.Rows(j)("MONTANT_HT")
                Next

                'On soustrait les montant remboursé des montants encaissé
                TotalFacture -= TotalRembourse

            End If

            LabelSituationCaisse.Text = Format(TotalFacture, "#,##0")

        Else
            LabelSituationCaisse.Text = 0
        End If

    End Sub

    'Managing a new invoice - click in nouveau
    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButtonnNouvelleFacture.Click

        GunaTextBoxCodeElite.Clear()
        GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")

        GunaTextBoxNomPrenomClient.Visible = True

        GunaTextBoxNomPrenomClient.Visible = True
        'We clear the fields 
        clearArticleFields()
        emptyFacturationFormField()
        GunaDataGridViewLigneFacture.Columns.Clear()
        ClearFacturationKeyInformation()
        TB_RoomNo.Clear()

        GunaTextBoxNomPrenomClient.Enabled = True
        GunaTextBoxNom_Prenom.Enabled = True

        DisplaySavingButton()


        'Me.Activate()

    End Sub

    'We refresh the content of the Folio Datagrids each time a new facturation is done
    Private Sub FacturationForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        If GunaComboBoxListeDesComandes.Items.Count = 1 Then
            DisplaySavingButton()

            Me.Refresh()
        End If

        Dim Folio As New FolioForm()

        Folio.GunaDataGridViewFolio1.Refresh()

        Folio.GunaDataGridViewFolio2.Refresh()

        Folio.GunaDataGridViewFolio3.Refresh()

        Folio.GunaDataGridViewFolio4.Refresh()

    End Sub

    'On recupere la nouvelle famille dans la quelle il va falloire fouiller
    Private Sub GunaComboBoxTypeArticle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeArticle.SelectedIndexChanged

        'GlobalVariable.ArticleFamily = GunaComboBoxTypeArticle.SelectedItem.ToString
        GunaComboBoxTypeArticle.SelectedItem = Trim(GlobalVariable.ArticleFamily)

        LibelleFacturation.Text = "FACTURATION " & GunaComboBoxTypeArticle.SelectedValue.ToString
        'GlobalVariable.ArticleFamily = LibelleFacturation.Text
        'GlobalVariable.ArticleFamily = GunaComboBoxTypeArticle.SelectedValue.ToString
        'If GlobalVariable.checkInFacturation Then
        If GlobalVariable.checkInFacturation Then
            GlobalVariable.ArticleFamily = Trim(GunaComboBoxTypeArticle.SelectedValue.ToString)
            'LibelleFacturation.Text = "FACTURATION " & GunaComboBoxTypeArticle.SelectedValue.ToString
        End If

        'End If

        'GlobalVariable.checkInFacturation = False

        'NE PAS AFFICHER LES NUMEROS DE BLOC NOTES POUR SERVICES ET BLANCHISSERIE

        'If Trim(GlobalVariable.ArticleFamily) = "SERVICES" Or Trim(GlobalVariable.ArticleFamily) = "BLANCHISSERIE" Then
        If Trim(GlobalVariable.ArticleFamily) = "SERVICES" Then
            GunaTextBoxBlocNote.Visible = False
            GunaButtonNouveauBloc.Visible = False
            GunaComboBoxListeDesComandes.Visible = False
            LabelBlocNoteOuTable.Visible = False
        Else
            GunaTextBoxBlocNote.Visible = True
            'GunaButtonNouveauBloc.Visible = True
            GunaComboBoxListeDesComandes.Visible = True
            LabelBlocNoteOuTable.Visible = True
        End If

    End Sub

    'On évite l'affiche du systeme.Data.Row
    Private Sub GunaComboBoxTypeArticle_Click(sender As Object, e As EventArgs) Handles GunaComboBoxTypeArticle.Click

        If GlobalVariable.checkInFacturation Then
            'LibelleFacturation.Visible = False
        End If

    End Sub

    'When the montant ht changes
    Private Sub GunaTextBoxMontantHT_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantHT.TextChanged
        'Changement du prix unitaire
        quantite = 0
        montantHT = 0
        Integer.TryParse(GunaTextBoxQuantite.Text, quantite)
        Double.TryParse(GunaTextBoxMontantHT.Text, montantHT)

        If Trim(GunaTextBoxRemise.Text) = "" Then
            GunaTextBoxRemise.Text = 0
        End If

        If Trim(GunaTextBoxMontantTTC.Text) = "" Then
            GunaTextBoxMontantTTC.Text = 0
        End If

        GunaTextBoxMontantTTC.Text = montantHT * quantite

        GunaTextBoxMontantReduction.Text = Format((GunaTextBoxMontantTTC.Text * GunaTextBoxRemise.Text) / 100, "#,##0")

    End Sub

    Dim discounStays As Boolean = False

    Private Sub GunaDataGridViewClient_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewClient.CellClick

        GunaTextBoxNom_Prenom.Enabled = True

        GunaDataGridViewClient.Visible = False

        If e.RowIndex >= 0 Then

            GunaTextBoxNomPrenomClient.Visible = False

            Dim row As DataGridViewRow

            row = GunaDataGridViewClient.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM client WHERE NOM_PRENOM=@NOM_PRENOM ORDER BY NOM_PRENOM ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Client As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = Trim(row.Cells("NOM_CLIENT").Value.ToString)

            Else
                command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = Trim(row.Cells("NOM_PRENOM").Value.ToString)
            End If

            adapter.SelectCommand = command
            adapter.Fill(Client)

            If (Client.Rows.Count > 0) Then

                GunaTextBoxNomPrenomClient.Text = Client.Rows(0)("CODE_CLIENT")
                GunaTextBoxNom_Prenom.Text = Client.Rows(0)("NOM_PRENOM")


                'On recherche le numéro de réservation du client en chambre
                If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                    GunaTextBoxNumReservation.Text = Functions.GetAllElementsOnTwoConditions(Client.Rows(0)("CODE_CLIENT"), "reserve_conf", "CLIENT_ID", 1, "ETAT_RESERVATION").Rows(0)("CODE_RESERVATION")
                    TB_RoomNo.Text = Functions.GetAllElementsOnTwoConditions(Client.Rows(0)("CODE_CLIENT"), "reserve_conf", "CLIENT_ID", 1, "ETAT_RESERVATION").Rows(0)("CHAMBRE_ID")

                    GunaDataGridViewChambreReservation.Visible = False
                End If

                Dim resa As DataTable = Functions.GetAllElementsOnTwoConditions(Client.Rows(0)("CODE_CLIENT"), "reserve_conf", "CLIENT_ID", 1, "ETAT_RESERVATION")

                If resa.Rows.Count > 0 Then

                    GunaTextBoxNumReservation.Text = resa.Rows(0)("CODE_RESERVATION")

                    GlobalVariable.codeReservationToUpdate = resa.Rows(0)("CODE_RESERVATION")
                    GlobalVariable.ReservationToUpdate = resa

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaButtonSaveFacturation.Text = "Enregistrer"
                    Else
                        GunaButtonSaveFacturation.Text = "Save"
                    End If
                    'TB_RoomNo.Text = resa.Rows(0)("CHAMBRE_ID")

                    'Ont recuperes les mains courantes dont l'etat vaut zero donc non cloturer

                    GlobalVariable.codeReservationToUpdate = resa.Rows(0)("CODE_RESERVATION")
                    Dim CODE_RESERVATION As String = resa.Rows(0)("CODE_RESERVATION")

                    Dim Caisse As New Caisse()

                    If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                        GunaComboBoxListeDesComandes.DataSource = Caisse.AutoLoadBlocNoteEnChambre(GlobalVariable.DateDeTravail.ToShortDateString, GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), 0, CODE_RESERVATION)
                        GunaComboBoxListeDesComandes.ValueMember = "NUMERO_BLOC_NOTE"
                        GunaComboBoxListeDesComandes.DisplayMember = "NUMERO_BLOC_NOTE"
                    End If

                    Dim mainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                    If mainCouranteJournaliere.Rows.Count > 0 Then
                        GlobalVariable.codeMainCouranteJournaliereToUpdate = mainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                        'GunaTextBoxMontantTTC.Text = GlobalVariable.codeMainCouranteJournaliereToUpdate
                    End If

                    Dim mainCouranteGenerale As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_generale", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                    If mainCouranteGenerale.Rows.Count > 0 Then
                        GlobalVariable.codeMainCouranteGeneraleToUpdate = mainCouranteGenerale.Rows(0)("CODE_MAIN_COURANTE_GENERALE")
                        ' GunaTextBoxMontantReduction.Text = GlobalVariable.codeMainCouranteGeneraleToUpdate
                    End If

                Else

                    'We clear the article field if nothing is found when we click on the custom datagrid
                    clearArticleFields()

                End If

                'Solde du client comptoir, en chambre ou paymaster
                If Not Trim(GunaTextBoxNomPrenomClient.Text) = "" Then

                    If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "event" Then
                        GunaTextBoxSoldeClient.Text = Format(Functions.SituationDeReservation(GunaTextBoxNumReservation.Text), "#,##0")
                    Else
                        GunaTextBoxSoldeClient.Text = Functions.SituationDuClient(GunaTextBoxNomPrenomClient.Text)
                    End If

                End If

            End If

        End If

    End Sub


    Private Sub GunaCheckBox1_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxChangeSecteur.Click

        If GunaCheckBoxChangeSecteur.Checked Then

            'On masque le chant du nom on load
            GunaTextBoxNom_Prenom.Enabled = False

            'Loading other 'article families currently called article type into a combobox
            Dim tableFamille As DataTable = Functions.allTableFieldsOrganised("famille", "LIBELLE_FAMILLE")

            If (tableFamille.Rows.Count > 0) Then

                GunaComboBoxTypeArticle.DataSource = tableFamille
                'GunaComboBoxTypeArticle.ValueMember = "CODE_FAMILLE"
                GunaComboBoxTypeArticle.ValueMember = "LIBELLE_FAMILLE"
                GunaComboBoxTypeArticle.DisplayMember = "LIBELLE_FAMILLE"

                GunaComboBoxTypeArticle.SelectedIndex = 1

            End If

            GunaComboBoxTypeArticle.Visible = True

        ElseIf Not GunaCheckBoxChangeSecteur.Checked Then

            GunaComboBoxTypeArticle.Visible = False

        End If

    End Sub

    'MODIFICATION DU CONTENU DE LA LISTE DE FACTURE
    Private Sub GunaDataGridViewLigneFacture_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLigneFacture.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonAjouterLigne.Visible = True

            Dim article As New DataTable()

            Dim row As DataGridViewRow

            row = GunaDataGridViewLigneFacture.Rows(e.RowIndex)

            codeArticle = Trim(row.Cells("ARTICLE").Value.ToString)

            GunaTextBoxQuantite.Text = Format(row.Cells("QUANTITE").Value, "#,##0")

            GunaTextBoxMontantHT.Text = Format(row.Cells("PU TTC").Value, "#,##0")

            GunaTextBoxMontantTTC.Text = Format(row.Cells("MONTANT TTC").Value, "#,##0")

            GunaTextBoxArticle.Text = Trim(row.Cells("DESIGNATION").Value.ToString)

            If GunaTextBoxArticle.Text.Contains("HEBERGEMENT") Or GunaTextBoxArticle.Text.Contains("LOCATION SALLE") Or GunaTextBoxArticle.Text.Contains("ACCOMMODATION") Or GunaTextBoxArticle.Text.Contains("HALL RENTING") Then
                GunaTextBoxMontantHT.Enabled = True
            End If

            article = Functions.getElementByCode(codeArticle, "article", "CODE_ARTICLE")

            Dim QUANTITE_DU_MAGASIN_ECONOMAT = 0

            If article.Rows.Count > 0 Then
                QUANTITE_DU_MAGASIN_ECONOMAT = Format(article.Rows(0)("QUANTITE"), "#,##.00")

                GunaTextBoxSousFamilleArticle.Text = article.Rows(0)("CODE_SOUS_FAMILLE")
            Else
                GunaTextBoxStockMagasin.Text = 0
            End If

            GunaDataGridViewArticle.Visible = False

            Dim NUMERO_BLOC_NOTE As String = ""
            Dim MONTANT_BLOC_NOTE As Double = GunaTextBoxMontantTTC.Text
            Dim CODE_FACTURE As String = GunaTextBoxNumfacture.Text

            Functions.DeleteElementOnTwoConditions(CODE_FACTURE, "ligne_facture_temp", "CODE_FACTURE", "CODE_ARTICLE", codeArticle)

            GunaDataGridViewLigneFacture.DataSource = Nothing

            OutPutLigneFacture()

            'If GunaDataGridViewLigneFacture.Rows.Count <= 0 Then
            'GunaDataGridViewLigneFacture.DataSource = Nothing
            'End If

            '------------------------------------------------------
            Dim econom As New Economat()
            Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

            Dim QUANTITE_DU_MAGASIN_ACTUEL = 0

            Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
            QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, codeArticle)

            Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

            If gestionDesStock = 0 Then

                GunaTextBoxStockMagasin.Visible = False
                Label20.Visible = False
                GunaTextBoxConso.Visible = False
                GunaLabel2.Visible = False

            ElseIf gestionDesStock = 1 Then

                GunaTextBoxStockMagasin.Visible = True
                Label20.Visible = True
                GunaLabel2.Visible = True
                GunaTextBoxConso.Visible = True

            End If

            If Integer.Parse(article.Rows(0)("BOISSON")) = 1 Then

                'ON RECUPERE LA CONSOMMATION
                Dim conso As DataTable = Functions.getElementByCode(Trim(article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If Trim(article.Rows(0)("CODE_CONSO")).Equals("") Then
                    conso = Nothing
                End If

                If conso.Rows.Count > 0 Then

                    GunaTextBoxConsoOnly.Visible = True
                    GunaLabel5.Visible = True
                    GunaLabel6.Visible = True

                    Dim valeurConversion As Double = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                    GunaTextBoxQuantiteConso.Text = valeurConversion

                    GunaTextBoxMontantHT.Text = Format(prixUtilseConso(CODE_MAGASIN, article), "#,##0")

                    '---------------------------------------------------------------------------------------------------------------------------------------------

                    Dim nombreDeConsoTotal As Integer = 0
                    Dim nombreDeConsoTotal_ As Integer = QUANTITE_DU_MAGASIN_ECONOMAT

                    If gestionDesStock = 0 Then
                        'AFFICHAGE DES QUANTITES DU GRAND MAGASIN
                        'STOCK = CONTENANCE * QTE / VALEUR_NUMERIQUE
                        nombreDeConsoTotal = article.Rows(0)("QUANTITE")
                        GunaTextBoxConso.Visible = False
                        GunaLabel2.Visible = False

                    ElseIf gestionDesStock = 1 Then
                        'AFFICHAGE DES QUANTITES DU PETIT MAGASIN

                        GunaTextBoxConso.Visible = True
                        GunaLabel2.Visible = True

                        If QUANTITE_DU_MAGASIN_ACTUEL > 0 Then
                            nombreDeConsoTotal = QUANTITE_DU_MAGASIN_ACTUEL
                        Else
                            GunaTextBoxStockMagasin.Text = 0
                        End If

                    End If

                    '---------------------------------------------------------------------------------------------------------------------------------------------
                    If GlobalVariable.actualLanguageValue = 0 Then

                        GunaTextBoxArticle.Text = "SHOT " & GunaTextBoxArticle.Text
                        GunaComboBoxUniteOuConso.SelectedItem = "SHOT"

                    ElseIf GlobalVariable.actualLanguageValue = 1 Then

                        GunaTextBoxArticle.Text = "CONSO " & GunaTextBoxArticle.Text
                        GunaComboBoxUniteOuConso.SelectedItem = "CONSOMMATION"

                    End If

                    '-----------------------------------------------------------------------------------------------------------------------
                    Dim nombreDeBouteille As Double = 0
                    Dim nombreDeBouteille_ As Double = 0
                    Dim nombreDeConso As Integer = 0
                    Dim nombreDeConso_ As Integer = 0

                    Dim contenance As Double = article.Rows(0)("CONTENANCE")

                    Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion) 'MAGASIN ACTUEL

                    If nombreDeConsoDansUneBouteille > 0 Then
                        nombreDeBouteille = Int(nombreDeConsoTotal / nombreDeConsoDansUneBouteille) 'MAGASIN ACTUEL
                        nombreDeBouteille_ = Int(nombreDeConsoTotal_ / nombreDeConsoDansUneBouteille) 'ECONOMAT
                        nombreDeConso = nombreDeConsoTotal Mod nombreDeConsoDansUneBouteille 'MAGASIN ACTUEL
                        nombreDeConso_ = nombreDeConsoTotal_ Mod nombreDeConsoDansUneBouteille 'ECONOMAT
                    End If

                    If gestionDesStock = 0 Then

                        GunaTextBoxStockEconomat.Text = Format(nombreDeBouteille_, "#,##0")
                        GunaTextBoxConsoOnly.Text = Format(nombreDeConso_, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                    ElseIf gestionDesStock = 1 Then

                        GunaLabel4.Visible = True
                        GunaComboBoxUniteOuConso.Visible = False
                        GunaLabel6.Visible = False
                        GunaLabel6.Visible = True

                        GunaTextBoxStockEconomat.Text = Format(nombreDeBouteille_, "#,##0")
                        GunaTextBoxConsoOnly.Text = Format(nombreDeConso_, "#,##0")

                        GunaTextBoxStockMagasin.Text = Format(nombreDeBouteille, "#,##0")
                        GunaTextBoxConso.Text = Format(nombreDeConso, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                    End If
                    '------------------------------------------------------------------------------------------------------------------------

                    GunaComboBoxUniteOuConso.Visible = True

                Else
                    GunaComboBoxUniteOuConso.Visible = False
                    GunaTextBoxConsoOnly.Visible = False
                    GunaLabel5.Visible = False
                    GunaLabel6.Visible = False
                End If

            Else

                GunaTextBoxStockEconomat.Text = Format(QUANTITE_DU_MAGASIN_ECONOMAT, "#,##0")

                GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0")

                GunaTextBoxConso.Text = 0
                GunaTextBoxConsoOnly.Text = 0
                GunaTextBoxConso.Visible = False

                GunaComboBoxUniteOuConso.Visible = False
                GunaTextBoxConsoOnly.Visible = False
                GunaLabel5.Visible = False
                GunaLabel6.Visible = False
                GunaComboBoxUniteOuConso.Visible = False

            End If

            GunaDataGridViewArticle.Visible = False
            '------------------------------------------------------

        End If

        DisplaySavingButton()

    End Sub

    Private Sub GunaTextBoxNomPrenomClient_TextChanged_1(sender As Object, e As EventArgs) Handles GunaTextBoxNomPrenomClient.TextChanged

        Dim query As String = ""
        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim CLIENT_TYPE As String = ""

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            query = "SELECT reserve_conf.NOM_CLIENT, EMAIL FROM reserve_conf INNER JOIN client WHERE reserve_conf.NOM_CLIENT LIKE '%" & Trim(GunaTextBoxNomPrenomClient.Text) & "%' AND ETAT_RESERVATION = 1 AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND reserve_conf.CLIENT_ID=client.CODE_CLIENT ORDER BY NOM_CLIENT ASC"
        ElseIf GlobalVariable.typeDeClientAFacturer = "paymaster" Then
            CLIENT_TYPE = "PAYMASTER"
            query = "Select NOM_PRENOM, EMAIL FROM client WHERE NOM_PRENOM Like '%" & Trim(GunaTextBoxNomPrenomClient.Text) & "%' AND TYPE_CLIENT = @TYPE_CLIENT ORDER BY NOM_PRENOM ASC"
        ElseIf GlobalVariable.typeDeClientAFacturer = "comptoir" Or GlobalVariable.typeDeClientAFacturer = "" Then
            CLIENT_TYPE = "COMPTOIRE"
            query = "Select NOM_PRENOM, EMAIL FROM client WHERE NOM_PRENOM Like '%" & Trim(GunaTextBoxNomPrenomClient.Text) & "%'  AND TYPE_CLIENT = @TYPE_CLIENT ORDER  BY NOM_PRENOM ASC"
        End If

        If Trim(GunaTextBoxNomPrenomClient.Text).Equals("") Then

            GunaTextBoxNomPrenomClient.Clear()
            GunaTextBoxNom_Prenom.Clear()
            TB_RoomNo.Clear()

            GunaDataGridViewClient.Columns.Clear()
            GunaDataGridViewClient.Visible = False

        End If

        GunaDataGridViewClient.Visible = True

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        If Not GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = CLIENT_TYPE
        End If

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaDataGridViewClient.Visible = True
            GunaDataGridViewClient.DataSource = table

        Else
            GunaDataGridViewClient.Columns.Clear()
            GunaDataGridViewClient.Visible = False
        End If

        If Trim(GunaTextBoxNomPrenomClient.Text).Equals("") Then
            GunaTextBoxNom_Prenom.Clear()
            GunaDataGridViewClient.Columns.Clear()
            GunaDataGridViewClient.Visible = False
        End If

        'connect.closeConnection()

    End Sub

    'GENERATION DES NUMEROS DU BLOC NOTE
    Private Sub GunaTextBoxBlocNote_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxBlocNote.TextChanged

        If Trim(GunaTextBoxBlocNote.Text).Equals("") Then
            GunaButtonNouveauBloc.Visible = False
        Else
            GunaButtonNouveauBloc.Visible = True
        End If

    End Sub

    Public Sub AutoLoadOfBlocNote()

        'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes
        Dim ETAT_BLOC_NOTE As Integer = 0
        'Commande non clôturée
        Dim ligneFactureBlocNote As DataTable = Functions.GetAllElementsOnCondition(ETAT_BLOC_NOTE, "ligne_facture_bloc_note", "ETAT_BLOC_NOTE")

        'Commande clôturée
        Dim ETAT_BLOC_NOTE1 As Integer = 1
        Dim ligneFactureBlocNote1 As DataTable = Functions.GetAllElementsOnCondition(ETAT_BLOC_NOTE1, "ligne_facture_bloc_note", "ETAT_BLOC_NOTE")

        ligneFactureBlocNote.Merge(ligneFactureBlocNote1)

        If ligneFactureBlocNote.Rows.Count > 0 Then

            GunaComboBoxListeDesComandes.DataSource = ligneFactureBlocNote
            GunaComboBoxListeDesComandes.ValueMember = "NUMERO_BLOC_NOTE"
            GunaComboBoxListeDesComandes.DisplayMember = "NUMERO_BLOC_NOTE"

            'GunaComboBoxListeDesComandes.Sorted = True
        Else
            GunaComboBoxListeDesComandes.DataSource = Nothing
        End If

        If ligneFactureBlocNote.Rows.Count > 0 Then
            'On selectionne le nouveau bloc note en cas de changement

            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                Dim blocNoteEnCours As DataTable = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If blocNoteEnCours.Rows.Count > 0 Then
                    GunaTextBoxNumfacture.Text = blocNoteEnCours.Rows(0)("CODE_FACTURE")
                End If

            End If

        End If

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    'CREATION D'UN NOUVEAU BLOC NOTE
    Private Sub GunaButtonNouveauBloc_Click(sender As Object, e As EventArgs) Handles GunaButtonNouveauBloc.Click
        'Génération d'un nouveau numéro proforma associé au numéro de bloc_note

        GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")

        Dim LigneReservationTemp As New LigneFacture()

        'On insère une nouvelle ligne dans la ligne de facture temporaire ou des bloc note

        Dim MONTANT_BLOC_NOTE As Double = Double.Parse(GunaTextBoxMontantTTCGeneral.Text)

        Dim NUMERO_BLOC_NOTE_VERIF As String = Trim(GunaTextBoxBlocNote.Text) 'Permet de vérifier l'unicité des bloc notes
        Dim NUMERO_BLOC_NOTE As String = GlobalVariable.DateDeTravail.ToString("ddMM") & "-" & Trim(GunaTextBoxBlocNote.Text)

        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail

        Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        'NUMERO DE BLOC NOTE DEVANT ETRE UNIQUE
        'Dim blocNoteExistant As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")
        Dim blocNoteExistant As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE_VERIF, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE_VERIF")

        If Not blocNoteExistant.Rows.Count > 0 Then

            'GunaTextBoxNumfacture.Text = GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCode("facture", "")

            If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                'Pour les en chambres impossible de traiter deux blocs simultanement
                If GunaComboBoxListeDesComandes.Items.Count = 0 Then

                    LigneReservationTemp.InsertLigneBlocNoteCommande(NUMERO_BLOC_NOTE, GunaTextBoxNumfacture.Text, GunaTextBoxNomPrenomClient.Text, DATE_CREATION, CODE_CAISSIER, NUMERO_BLOC_NOTE_VERIF)

                    If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                        Dim CODE_RESSERVATION = GunaTextBoxNumReservation.Text
                        Dim updateQuery As String = "UPDATE `ligne_facture_bloc_note` SET `ETAT_FACTURE` = @ETAT_FACTURE, `CODE_RESERVATION`=@CODE_RESERVATION WHERE NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE"

                        Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)

                        commandupdateQuery.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
                        commandupdateQuery.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESSERVATION
                        commandupdateQuery.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = 1

                        commandupdateQuery.ExecuteNonQuery()

                    End If

                    Dim caisse As New Caisse()
                    Dim CODE_RESERVATION As String = GunaTextBoxNumReservation.Text

                    Dim dt As New DataTable()
                    dt = caisse.AutoLoadBlocNoteEnChambre(GlobalVariable.DateDeTravail.ToShortDateString, GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), 0, CODE_RESERVATION)

                    If dt.Rows.Count > 0 Then

                        GunaComboBoxListeDesComandes.DataSource = dt
                        GunaComboBoxListeDesComandes.DisplayMember = "NUMERO_BLOC_NOTE"
                        GunaComboBoxListeDesComandes.ValueMember = "NUMERO_BLOC_NOTE"

                        GunaComboBoxListeDesComandes.SelectedValue = NUMERO_BLOC_NOTE

                    End If

                End If

            Else

                LigneReservationTemp.InsertLigneBlocNoteCommande(NUMERO_BLOC_NOTE, GunaTextBoxNumfacture.Text, GunaTextBoxNomPrenomClient.Text, DATE_CREATION, CODE_CAISSIER, NUMERO_BLOC_NOTE_VERIF)

                'On charge l'ensemble des bloc notes non réglés et clôturé
                AutoLoadOfBlocNote()

                If GunaComboBoxListeDesComandes.Items.Count > 0 Then
                    GunaComboBoxListeDesComandes.SelectedValue = NUMERO_BLOC_NOTE
                End If

                'A la création d'un nouveau bloc note 

                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaButtonSaveFacturation.Text = "Save"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonSaveFacturation.Text = "Enregistrer"
                End If

            End If

            GunaButtonNouveauBloc.Visible = False

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Receipt and Table management"
                languageMessage = "This code exist, please type another !!"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "gestion de bloc note et table"
                languageMessage = "Se numéro existe déjà bien vouloir saisir un autre !!"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'GunaTextBoxBlocNote.Clear()

        End If

        GunaTextBoxBlocNote.Clear()

    End Sub

    'Au changement du nu,ero de bloc note ou nu,ero de commande 
    'on redefini le contenu datagrid en selectionnant les infos liés au nu,ero de bloc note
    Private Sub GunaComboBoxListeDesClientFacture_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxListeDesComandes.SelectedIndexChanged

        GunaDataGridViewLigneFacture.Columns.Clear()

        'On selectionne le nouveau bloc note en cas de changement

        Dim blocNoteEnCours As DataTable

        If Not GunaComboBoxListeDesComandes.DataSource Is Nothing Then

            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")
            End If

            If blocNoteEnCours.Rows.Count > 0 Then

                GunaTextBoxNumfacture.Text = blocNoteEnCours.Rows(0)("CODE_FACTURE")

                Dim ListeDesArticlesDeCetteComandes As DataTable = Functions.GetAllElementsOnCondition(blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE"), "ligne_facture_temp", "NUMERO_BLOC_NOTE")
                'On charge l'ensemble des articles en relation avec cette commande ou numero de bloc note
                If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then

                    Dim ClientDevantRegler As DataTable = Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT")

                    If ClientDevantRegler.Rows.Count > 0 Then
                        GunaTextBoxNomPrenomClient.Text = ClientDevantRegler.Rows(0)("CODE_CLIENT") 'Code client
                        GunaTextBoxNom_Prenom.Text = ClientDevantRegler.Rows(0)("NOM_PRENOM") 'Nom du client
                    End If

                    OutPutLigneFacture()

                Else
                    GunaDataGridViewLigneFacture.Columns.Clear()
                End If

                If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then

                    GunaButtonSaveFacturation.Text = "Clôturer"

                ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then

                    GunaButtonSaveFacturation.Text = "Régler"

                End If

            Else

                GunaComboBoxListeDesComandes.DataSource = Nothing
            End If

            'Determining wether or not to save a facturation
            DisplaySavingButton()

            FacturationKeyInformation()

        End If

    End Sub

    Private Sub GunaCheckBox2_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxClientComptoire.Click

        If GunaCheckBoxClientComptoire.Checked Then

            GlobalVariable.typeDeClientAFacturer = "comptoir"

            'CLIENT EN CHAMBRE

            GunaDataGridViewLigneFacture.Columns.Clear()
            ClearFacturationKeyInformation()
            clearArticleFields()

            GlobalVariable.checkInFacturation = False

            GunaTextBoxBlocNote.Visible = True
            GunaComboBoxListeDesComandes.Visible = True
            LabelBlocNoteOuTable.Visible = True

            'Client comptoir liste des commandes pour chaque bloc_note
            AutoLoadOfBlocNote()

            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                'On selectionne le nouveau bloc note affiché par défaut
                Dim blocNoteEnCours As DataTable = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If blocNoteEnCours.Rows.Count > 0 Then
                    'On insere le numero de la proforma lié a cette facture
                    GunaTextBoxNumfacture.Text = blocNoteEnCours.Rows(0)("CODE_FACTURE")
                    GunaTextBoxNomPrenomClient.Text = blocNoteEnCours.Rows(0)("CODE_CLIENT")
                    GunaTextBoxNom_Prenom.Text = Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT").Rows(0)("NOM_PRENOM")

                    Dim ListeDesArticlesDeCetteComandes As DataTable = Functions.GetAllElementsOnCondition(blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE"), "ligne_facture_temp", "NUMERO_BLOC_NOTE")
                    'On charge l'ensemble des articles en relation avec cette commande ou numero de bloc note
                    If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then

                        OutPutLigneFacture()

                    Else
                        GunaDataGridViewLigneFacture.Columns.Clear()
                    End If

                    FacturationKeyInformation()

                    If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then

                        GunaButtonSaveFacturation.Text = "Clôturer"

                    ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then

                        GunaButtonSaveFacturation.Text = "Régler"

                    End If

                Else
                    'We generate a facture
                    'GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCode("facture", "")
                End If

            End If
            'Determining wether or not to save a facturation
            DisplaySavingButton()

        Else

            'AUTRES CLIENT 

            GlobalVariable.typeDeClientAFacturer = "en chambre"

            GunaDataGridViewLigneFacture.Columns.Clear()
            ClearFacturationKeyInformation()
            clearArticleFields()

            ' GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCode("ligne_facture", "")

            GlobalVariable.checkInFacturation = True

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonSaveFacturation.Text = "Enregistrer"
            Else
                GunaButtonSaveFacturation.Text = "Save"
            End If
            GunaTextBoxBlocNote.Visible = False
            GunaComboBoxListeDesComandes.Visible = False
            LabelBlocNoteOuTable.Visible = False

            'Determining wether or not to save a facturation
            DisplaySavingButton()

        End If

    End Sub

    'SUPPRESSION D'UNE LIGNE DES ELEMENTS DE LA FACTURE
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        Dim numberOfElement As Integer = 0

        If GunaDataGridViewLigneFacture.Rows.Count > 0 Then

            numberOfElement = GunaDataGridViewLigneFacture.Rows.Count

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Supprimer cette Artilce", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                dialog = MessageBox.Show("Do you really want to delete this item", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            If dialog = DialogResult.No Then
                'e.Cancel = True 

            Else

                Functions.DeleteRowFromDataGridGeneralFacturationLine(GunaDataGridViewLigneFacture, GunaDataGridViewLigneFacture.CurrentRow.Cells("ARTICLE").Value.ToString, "ligne_facture_temp", "CODE_ARTICLE", GunaTextBoxNumfacture.Text, "CODE_FACTURE")

                GunaDataGridViewLigneFacture.Columns.Clear()

                OutPutLigneFacture()

                'We determine if or not to display the saving button 

                DisplaySavingButton()

                FacturationKeyInformation()

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("You successfully deleted", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


            End If


        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Nothing to be deletd", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

        Dim NUMERO_BLOC_NOTE As String = ""

        If GunaComboBoxListeDesComandes IsNot Nothing Then
            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                NUMERO_BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString
                Dim MONTANT_BLOC_NOTE_ As Double = GunaTextBoxMontantTTCGeneral.Text
                Functions.updateOfFields("ligne_facture_bloc_note", "MONTANT_BLOC_NOTE", MONTANT_BLOC_NOTE_, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 0)
            End If
        End If

        If numberOfElement = 1 Then
            GunaDataGridViewLigneFacture.DataSource = Nothing
        End If

    End Sub

    '--------------- GESTION D'ENCODAGES

    Private Declare Function StartSession Lib "LockDll.Dll" (ByVal Software As Integer, ByVal DBServer As String, ByVal LogUser As String, ByVal DBFlag As Integer) As Integer
    Private Declare Function EndSession Lib "LockDll.Dll" () As Integer
    Private Declare Function ChangeLogUser Lib "LockDll.Dll" (ByVal LogUser As String) As Integer

    Private Declare Function NewKey Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Door As String, ByVal Floor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByVal CardNo As Integer) As Integer
    Private Declare Function AddKey Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Door As String, ByVal Floor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByVal CardNo As Integer) As Integer
    Private Declare Function DupKey Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Door As String, ByVal Floor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByVal CardNo As Integer) As Integer

    'Private Declare Function ReadKeyCard Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Gate As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal CardNo As Integer, ByVal ByValCardStatus As Integer, ByVal breakfast As Integer) As Integer

    Private Declare Function ReadKeyCard Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Door As String, ByVal Floor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal CardNo As Integer, ByVal ByValCardStatus As Integer, ByVal breakfast As Integer) As Integer

    Private Declare Function EraseKeyCard Lib "LockDll.Dll" (ByVal Port As Integer, ByVal cardno As Integer) As Integer
    Private Declare Function CheckOut Lib "LockDll.Dll" (ByVal RoomNo As String, ByVal CardNo As Integer) As Integer

    'Lecture de la carte d'accès
    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButtonLecture.Click

        'Demarrage de session
        Dim server As String
        Dim user As String
        Dim LockSoftware As Integer
        Dim lStatus As Integer
        Dim db_flag As Long

        server = tb_server.Text
        user = "DllUser"
        LockSoftware = CB_Software.SelectedIndex + 1

        TB_Result.Text = "Executing..."
        db_flag = CB_DB.SelectedIndex
        TB_Result.Refresh()

        lStatus = StartSession(LockSoftware, server, user, CB_DB.SelectedIndex)
        'lStatus = StartSession(LockSoftware, server, user, db_flag)

        TB_Result.Text = lStatus.ToString("X")

        'Lecture de carte
        Dim lReadStatus As Integer
        Dim Port As Integer
        Dim CardNo As Integer
        Dim CardStatus As Integer
        Dim Breakfast As Integer

        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String
        Dim Door As String
        Dim lift As String

        RoomNo = New String("", 64)
        Holder = New String("", 64)
        IDNo = New String("", 64)
        TimeStr = New String("", 64)
        Door = New String("", 128)
        lift = New String("", 128)

        Port = CB_Port.SelectedIndex

        CardNo = 0
        CardStatus = 0
        Breakfast = 0

        TB_Result.Text = "Executing..."
        TB_Result.Refresh()

        lReadStatus = ReadKeyCard(Port, RoomNo, Door, lift, TimeStr, Holder, IDNo, CardNo, CardStatus, Breakfast)

        'TB_Result.Text = Hex(lStatus)
        TB_Result.Text = lReadStatus.ToString("X")

        'lStatus = ReadKeyCard(Port, RoomNo, Door, lift, TimeStr, Holder, IDNo, CardNo, CardStatus, Breakfast)

        'TB_Result.Text = lStatus.ToString("X")

        If (lReadStatus = 0) Then
            TB_CardNo.Text = CardNo.ToString()
            TB_Status.Text = CardStatus.ToString()
            CB_Breakfast.SelectedIndex = Breakfast

            TB_RoomNo.Text = RoomNo.ToString()
            'TB_Holder.Text = Holder.ToString()
            GunaTextBoxNom_Prenom.Text = Holder.ToString()
            TB_IDNo.Text = IDNo.ToString()
            TB_Time.Text = TimeStr.ToString()
        End If

        'Arret de la session
        Dim lEndStatus As Integer

        TB_Result.Text = "Executing..."

        TB_Result.Refresh()

        lEndStatus = EndSession()

        TB_Result.Text = lStatus.ToString("X")

        'On recherche le numéro de réservation du client en chambre
        If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            GunaTextBoxNumReservation.Text = Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("CODE_RESERVATION")
            GunaTextBoxNomPrenomClient.Text = Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("CLIENT_ID")
        End If

    End Sub

    Private Sub LabelSituationCaisse_DoubleClick(sender As Object, e As EventArgs) Handles LabelSituationCaisse.DoubleClick
        GlobalVariable.DocumentToGenerate = "situation caisse"
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Functions.DocumentToPrintSituation(CODE_CAISSIER, "reglement", "CODE_CAISSIER", GlobalVariable.DateDeTravail)
        GlobalVariable.DocumentToGenerate = ""
    End Sub

    Private Sub PanelSituationCaisse_DoubleClick(sender As Object, e As EventArgs) Handles PanelSituationCaisse.DoubleClick
        GlobalVariable.DocumentToGenerate = "situation caisse"
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Functions.DocumentToPrintSituation(CODE_CAISSIER, "reglement", "CODE_CAISSIER", GlobalVariable.DateDeTravail)
        GlobalVariable.DocumentToGenerate = ""
    End Sub

    'Lecteur RFID
    Private Sub GunaCheckBoxLecteurRFID_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxLecteurRFID.Click

        If GunaCheckBoxLecteurRFID.Checked Then
            GunaTextBoxLecteurRFID.Visible = True
            GunaTextBoxArticle.Visible = False
        Else
            GunaTextBoxLecteurRFID.Visible = False
            GunaTextBoxArticle.Visible = True
            GunaTextBoxLecteurRFID.Clear()
        End If

    End Sub

    Private Sub GunaTextBoxLecteurRFID_Validated(sender As Object, e As EventArgs) Handles GunaTextBoxLecteurRFID.Validated

        GunaDataGridViewArticle.Visible = False

        'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
        'il disparait de nouveau après ajout a la facture
        'En plus il ne peut pas aparaitre pour les clients comptoir, si il n'est associé à aucun numéro de bloc_note

        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                GunaButtonAjouterLigne.Visible = True
            End If

        Else
            GunaButtonAjouterLigne.Visible = True
        End If

        If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

            'On selectionne le nouveau bloc note affiché par défaut
            Dim blocNoteEnCours As DataTable

            'We have atleast an element in our combo box
            blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

            If blocNoteEnCours.Rows.Count > 0 And GunaComboBoxListeDesComandes.Visible Then
                'On ne peut pas ajouter une ligne a une commande clôturée
                If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                    GunaButtonAjouterLigne.Visible = False
                End If
            End If

        End If

        Dim query As String = "SELECT * FROM article WHERE CODE_BARRE=@CODE_BARRE ORDER BY DESIGNATION_FR ASC"
        Dim adapter As New MySqlDataAdapter
        Dim Article As New DataTable
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_BARRE", MySqlDbType.VarChar).Value = Trim(GunaTextBoxLecteurRFID.Text)

        adapter.SelectCommand = command
        adapter.Fill(Article)

        If (Article.Rows.Count > 0) Then

            codeArticle = Article.Rows(0)("CODE_ARTICLE")
            Double.TryParse(GunaTextBoxQuantite.Text, quantite)
            GunaTextBoxMontantHT.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0")
            Double.TryParse(GunaTextBoxMontantHT.Text, montant)
            GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
            Double.TryParse(GunaTextBoxTVA.Text, TVA)
            montantHT = (quantite * montant)
            GunaTextBoxMontantTTC.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

            GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
            GunaTextBoxStockMagasin.Text = Article.Rows(0)("QUANTITE")
            GunaDataGridViewArticle.Visible = False

        Else

            'We clear the article field if nothing is found when we click on the custom datagrid
            clearArticleFields()

        End If

        If Trim(GunaTextBoxLecteurRFID.Text) = "" And GunaCheckBoxLecteurRFID.Checked Then
            GunaButtonAjouterLigne.Visible = False
        Else

        End If

        GunaTextBoxLecteurRFID.Clear()

    End Sub

    Private Sub GunaComboBoxUniteOuConso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUniteOuConso.SelectedIndexChanged

        Dim CODE_ARTICLE = codeArticle

        Dim econom As New Economat()

        Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, codeArticle)

        Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

        Dim article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

        If article.Rows.Count > 0 Then

            If GunaComboBoxUniteOuConso.SelectedItem = "CONSOMMATION" Or GunaComboBoxUniteOuConso.SelectedItem = "SHOT" Then

                Dim conso As DataTable = Functions.getElementByCode(article.Rows(0)("CODE_CONSO"), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If conso.Rows.Count > 0 Then

                    GunaTextBoxConsoOnly.Visible = True
                    GunaLabel5.Visible = True
                    GunaLabel6.Visible = True

                    Dim QUANTITE_CONSO = conso.Rows(0)("VALEUR_NUMERIQUE")

                    Dim PRIX_CONSO As Double = 0

                    If True Then

                        'PRIX_CONSO = article.Rows(0)("PRIX_CONSO")
                        PRIX_CONSO = prixUtilseConso(CODE_MAGASIN, article)

                        GunaTextBoxQuantiteConso.Text = QUANTITE_CONSO

                        Double.TryParse(GunaTextBoxQuantite.Text, quantite)
                        GunaTextBoxMontantHT.Text = Format(PRIX_CONSO, "#,##0")
                        Double.TryParse(GunaTextBoxMontantHT.Text, montant)
                        GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
                        Double.TryParse(GunaTextBoxTVA.Text, TVA)
                        montantHT = (quantite * montant)
                        GunaTextBoxMontantTTC.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

                        If GlobalVariable.actualLanguageValue = 0 Then

                            GunaTextBoxArticle.Text = "SHOT " & article.Rows(0)("DESIGNATION_FR")

                        ElseIf GlobalVariable.actualLanguageValue = 1 Then

                            GunaTextBoxArticle.Text = "CONSO " & article.Rows(0)("DESIGNATION_FR")

                        End If

                        'nbreConsommation = Math.Floor(Double.Parse(article.Rows(0)("CONTENANCE") / conso.Rows(0)("VALEUR_NUMERIQUE")) * QUANTITE_DU_MAGASIN_ACTUEL)

                        '---------------------------------------NEW --------------------------------------------------------------------------------
                        Dim nombreDeBouteille As Double = 0
                        Dim nombreDeConso As Integer = 0
                        Dim valeurConversion As Double = conso.Rows(0)("VALEUR_NUMERIQUE")
                        Dim contenance As Double = article.Rows(0)("CONTENANCE")
                        Dim nombreDeConsoTotal

                        If gestionDesStock = 0 Then
                            nombreDeConsoTotal = article.Rows(0)("QUANTITE")
                        ElseIf gestionDesStock = 1 Then
                            nombreDeConsoTotal = QUANTITE_DU_MAGASIN_ACTUEL
                        End If

                        Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                        If nombreDeConsoDansUneBouteille > 0 Then
                            nombreDeBouteille = Int(nombreDeConsoTotal / nombreDeConsoDansUneBouteille)
                            nombreDeConso = nombreDeConsoTotal Mod nombreDeConsoDansUneBouteille
                        End If

                        If gestionDesStock = 0 Then

                            GunaTextBoxStockEconomat.Text = Format(nombreDeBouteille, "#,##0")
                            GunaTextBoxConsoOnly.Text = Format(nombreDeConso, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                        ElseIf gestionDesStock = 1 Then

                            GunaTextBoxStockMagasin.Text = Format(nombreDeBouteille, "#,##0")
                            GunaTextBoxConso.Text = Format(nombreDeConso, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                        End If

                        '------------------------------------------------------------------------------------------------------------------------

                    End If

                Else

                    GunaTextBoxConsoOnly.Visible = False
                    GunaLabel5.Visible = False
                    GunaLabel6.Visible = False

                End If

            Else

                'GESTION DE LA PETITE UNITE

                'Dim nbreConsommation As Integer = 0

                Dim conso As DataTable = Functions.getElementByCode(article.Rows(0)("CODE_CONSO"), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                Dim UNITE_COMPTAGE As String = article.Rows(0)("UNITE_COMPTAGE")
                Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")
                Dim VALEUR_DE_CONVERSION As Double = 1

                If unite.Rows.Count > 0 Then
                    VALEUR_DE_CONVERSION = unite.Rows(0)("VALEUR_NUMERIQUE")
                End If

                If GunaComboBoxUniteOuConso.SelectedIndex >= 0 Then

                    Double.TryParse(GunaTextBoxQuantite.Text, quantite)
                    'GunaTextBoxMontantHT.Text = Format(prixUtilse(CODE_MAGASIN, article) / VALEUR_DE_CONVERSION, "#,##0")
                    GunaTextBoxMontantHT.Text = Format(prixUtilse(CODE_MAGASIN, article), "#,##0")
                    Double.TryParse(GunaTextBoxMontantHT.Text, montant)
                    GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
                    Double.TryParse(GunaTextBoxTVA.Text, TVA)
                    montantHT = (quantite * montant)
                    GunaTextBoxMontantTTC.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

                    'NOMBRE DE UNITE

                    If gestionDesStock = 0 Then
                        GunaTextBoxStockMagasin.Text = Format(article.Rows(0)("QUANTITE"), "#,##0.00")
                    ElseIf gestionDesStock = 1 Then
                        GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0")
                    End If

                    GunaTextBoxQuantiteConso.Clear()

                    If Not (conso.Rows.Count > 0 And article.Rows(0)("BOISSON") = 1) Then

                        If gestionDesStock = 0 Then
                            'GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL * VALEUR_DE_CONVERSION, "#,##0")
                            GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0")
                            GunaTextBoxStockEconomat.Text = Format(article.Rows(0)("QUANTITE"), "#,##0")
                        ElseIf gestionDesStock = 1 Then

                            If QUANTITE_DU_MAGASIN_ACTUEL > 0 Then
                                GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0")
                                GunaTextBoxStockEconomat.Text = Format(article.Rows(0)("QUANTITE"), "#,##0")
                            Else
                                GunaTextBoxStockMagasin.Text = 0
                                GunaTextBoxStockEconomat.Text = Format(article.Rows(0)("QUANTITE"), "#,##0")
                            End If

                        End If

                        GunaTextBoxConsoOnly.Visible = False
                        GunaLabel5.Visible = False
                        GunaLabel6.Visible = False
                        GunaTextBoxConsoOnly.Text = 0

                    End If

                    GunaTextBoxArticle.Text = article.Rows(0)("DESIGNATION_FR")

                    GunaDataGridViewArticle.Visible = False

                End If

            End If

        End If

    End Sub

    Dim typeDeReductionPourcentageOuMontant As String = ""

    Private Sub GunaTextBoxRemise_TextChanged_1(sender As Object, e As EventArgs) Handles GunaTextBoxRemise.TextChanged

        If typeDeReductionPourcentageOuMontant = "pourcentage" Then

            If Trim(GunaTextBoxRemise.Text) = "" Then
                GunaTextBoxRemise.Text = 0
            End If

            If Trim(GunaTextBoxMontantTTC.Text) = "" Then
                GunaTextBoxMontantTTC.Text = 0
            End If

            GunaTextBoxMontantReduction.Text = Format((GunaTextBoxMontantTTC.Text * GunaTextBoxRemise.Text) / 100, "#,##0")

        End If

    End Sub

    'IMPRESSION DU DATAGRID
    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        Impression.commandeImpression(GunaDataGridViewLigneFacture, GunaTextBoxNom_Prenom.Text, GunaTextBoxNumfacture.Text, TB_RoomNo.Text)
    End Sub

    Private Sub TB_RoomNo_TextChanged(sender As Object, e As EventArgs) Handles TB_RoomNo.TextChanged

        If Trim(TB_RoomNo.Text).Equals("") Then
            GunaDataGridViewChambreReservation.Visible = False
            GunaTextBoxNomPrenomClient.Visible = True
            GunaTextBoxNom_Prenom.Clear()
            GunaTextBoxSoldeClient.Clear()
        End If

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim CLIENT_TYPE As String = ""

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            CLIENT_TYPE = "chambre"

        ElseIf GlobalVariable.typeDeClientAFacturer = "evenement" Then
            CLIENT_TYPE = "salle"

        End If

        Dim query As String = "SELECT CHAMBRE_ID, NOM_CLIENT FROM reserve_conf WHERE CHAMBRE_ID LIKE '%" & Trim(TB_RoomNo.Text) & "%' AND ETAT_RESERVATION = @ETAT_RESERVATION AND DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int16).Value = 1
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = CLIENT_TYPE

        Dim adapter As New MySqlDataAdapter(command)
        Dim reservation As New DataTable()

        adapter.Fill(reservation)

        If (reservation.Rows.Count > 0) Then

            GunaDataGridViewChambreReservation.Visible = True

            GunaDataGridViewChambreReservation.DataSource = reservation

        Else
            GunaDataGridViewChambreReservation.Visible = False
        End If

        'connect.closeConnection()

        If Trim(TB_RoomNo.Text).Equals("") Then
            GunaDataGridViewChambreReservation.Visible = False
        End If

    End Sub

    Private Sub GunaDataGridViewChambreReservation_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewChambreReservation.CellClick

        If e.RowIndex >= 0 Then

            GunaTextBoxNomPrenomClient.Visible = False

            GunaDataGridViewChambreReservation.Visible = False

            Dim row As DataGridViewRow

            row = GunaDataGridViewChambreReservation.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM client WHERE NOM_PRENOM=@NOM_PRENOM ORDER BY NOM_PRENOM ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Client As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then
                command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = row.Cells("NOM_CLIENT").Value.ToString
            Else
                command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = row.Cells("NOM_PRENOM").Value.ToString
            End If

            adapter.SelectCommand = command

            adapter.Fill(Client)

            If (Client.Rows.Count > 0) Then

                Dim CODE_RESERVATION As String = ""

                GunaTextBoxNom_Prenom.Enabled = False

                GunaTextBoxNomPrenomClient.Text = Client.Rows(0)("CODE_CLIENT")

                GunaTextBoxNom_Prenom.Text = Client.Rows(0)("NOM_PRENOM")

                'On recherche le numéro de réservation du client en chambre
                If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then

                    GunaDataGridViewChambreReservation.Visible = False

                    GunaTextBoxNumReservation.Text = Functions.GetAllElementsOnTwoConditions(Client.Rows(0)("CODE_CLIENT"), "reserve_conf", "CLIENT_ID", 1, "ETAT_RESERVATION").Rows(0)("CODE_RESERVATION")
                    TB_RoomNo.Text = Functions.GetAllElementsOnTwoConditions(Client.Rows(0)("CODE_CLIENT"), "reserve_conf", "CLIENT_ID", 1, "ETAT_RESERVATION").Rows(0)("CHAMBRE_ID")

                    CODE_RESERVATION = GunaTextBoxNumReservation.Text

                    GunaDataGridViewChambreReservation.Visible = False

                End If

                If GlobalVariable.typeDeClientAFacturer = "evenement" Then
                    'ON RECUPERE LE TYPE D'EVENEMENT

                    CODE_RESERVATION = GunaTextBoxNumReservation.Text

                    Dim evenement As DataTable = Functions.getElementByCode(CODE_RESERVATION, "forfait_salle", "CODE_RESERVATION")

                    If evenement.Rows.Count > 0 Then
                        'If GunaComboBoxEvenement.SelectedIndex >= 0 Then
                        'GunaComboBoxEvenement.SelectedValue = evenement.Rows(0)("CODE_EVENEMENT")
                        'End If
                    End If

                End If

                GlobalVariable.codeReservationToUpdate = CODE_RESERVATION

                Dim mainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                If mainCouranteJournaliere.Rows.Count > 0 Then
                    GlobalVariable.codeMainCouranteJournaliereToUpdate = mainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                    'GunaTextBoxMontantTTC.Text = GlobalVariable.codeMainCouranteJournaliereToUpdate
                End If

                Dim mainCouranteGenerale As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_generale", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                If mainCouranteGenerale.Rows.Count > 0 Then
                    GlobalVariable.codeMainCouranteGeneraleToUpdate = mainCouranteGenerale.Rows(0)("CODE_MAIN_COURANTE_GENERALE")
                    ' GunaTextBoxMontantReduction.Text = GlobalVariable.codeMainCouranteGeneraleToUpdate
                End If


                GunaDataGridViewClient.Visible = False
                GunaDataGridViewClient.Columns.Clear()

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid
                clearArticleFields()

            End If

            'Solde du client comptoir, en chambre ou paymaster
            If Not Trim(GunaTextBoxNomPrenomClient.Text) = "" Then

                If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then
                    GunaTextBoxSoldeClient.Text = Format(Functions.SituationDeReservation(GunaTextBoxNumReservation.Text), "#,##0")
                Else
                    'GunaTextBoxSoldeClient.Text = Format(Functions.SituationDuClient(GunaTextBoxCodeClient.Text), "#,##0")
                End If

            End If

            'connect.closeConnection()

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GunaTextBoxSoldeClient.Text = Format(Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate), "#,##0")
    End Sub

    Private Sub GunaCheckBoxTypeRemise_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTypeRemise.CheckedChanged

        If GunaCheckBoxTypeRemise.Checked Then
            typeDeReductionPourcentageOuMontant = "pourcentage"
            GunaTextBoxMontantReduction.Enabled = False
            GunaTextBoxRemise.Enabled = True
        Else
            GunaTextBoxMontantReduction.Enabled = True
            GunaTextBoxRemise.Enabled = False
            typeDeReductionPourcentageOuMontant = "montant"
        End If

    End Sub

    Private Sub GunaTextBoxMontantReduction_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantReduction.TextChanged

        If typeDeReductionPourcentageOuMontant = "montant" Then

            If Trim(GunaTextBoxMontantReduction.Text) = "" Then
                GunaTextBoxMontantReduction.Text = 0
            End If

            If Trim(GunaTextBoxMontantTTC.Text) = "" Then
                GunaTextBoxMontantTTC.Text = 0
            End If

            'GunaTextBoxMontantReduction.Text = Format((GunaTextBoxMontantTTC.Text * GunaTextBoxRemise.Text) / 100, "#,##0")

            If GunaTextBoxMontantTTC.Text > 0 Then
                GunaTextBoxRemise.Text = Format((100 * GunaTextBoxMontantReduction.Text) / GunaTextBoxMontantTTC.Text, "#,##0.00")
            End If

        End If

    End Sub

    Private Sub GunaTextBoxLecteurRFID_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxLecteurRFID.TextChanged

        If GunaCheckBoxLecteurRFID.Checked Then

            If Trim(GunaTextBoxLecteurRFID.Text).Equals("") Then
                GunaButtonAjouterLigne.Visible = False
            End If

        End If


    End Sub

End Class