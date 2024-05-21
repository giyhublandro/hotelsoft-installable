Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Data

Public Class BonApprovisionnementForm

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub autoloadMagasin()

        Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel

        Dim magasin As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

        If magasin.Rows.Count > 0 Then
            GunaComboBoxMagasinReception.DataSource = magasin
            GunaComboBoxMagasinReception.DisplayMember = "LIBELLE_MAGASIN"
            GunaComboBoxMagasinReception.ValueMember = "CODE_MAGASIN"
        End If

    End Sub

    Private Sub BonApprovisionnementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.bonApprovisionnement(GlobalVariable.actualLanguageValue)

        GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

        TabControlEconomat.SelectedIndex = 0

        'Theme color
        If GlobalVariable.AgenceActuelle.Rows.Count > 0 Then

            GlobalVariable.codeAgence = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        End If

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail

        GunaTextBoxTiers.Text = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        GunaTextBoxNomTiers.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

        If GlobalVariable.actualLanguageValue = 0 Then
            'GunaDataGridViewLigneArticleCommande.Columns.Add("ITEM CODE", "ITEM CODE")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("WORDING", "WORDING")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("QUANTITY", "QUANTITY")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("STOCK", "STOCK")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("COST PRICE", "COST PRICE")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("SALE PRICE", "SALE PRICE")
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            'GunaDataGridViewLigneArticleCommande.Columns.Add("CODE ARTICLE", "CODE ARTICLE")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("DESIGNATION", "DESIGNATION")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("QUANTITE", "QUANTITE")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("EN STOCK", "EN STOCK")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("PRIX ACHAT", "PRIX ACHAT")
            'GunaDataGridViewLigneArticleCommande.Columns.Add("PRIX VENTE", "PRIX VENTE")
        End If

        'GunaDataGridViewLigneArticleCommande.Columns.Add("DATE PEREMPTION", "DATE DE PEREMPTION")

        autoloadMagasin()
        'Pour être sur de ne gérer le lot que au bon moment
        GunaComboBoxListeDesLots.SelectedIndex = -1

        'GunaComboBoxTypeTiers.SelectedIndex = 1

        'GunaComboBoxTypeBordereau.SelectedIndex = 0

        '----------------------------END ECONOMAT ------------------

        NewBonDeRequisition()

        afficherCommande()

    End Sub

    '---------------------------------------------------- FROM START -----------------------------------------------------------------------

    Dim INDICE As String = ""

    Private Sub InsertionDesElementsPourGestionDeStock(ByVal ETAT_NOTE_DU_BORDEREAU As String, Optional ByVal ETAT_DU_BORDE As Integer = 0)

        LabelQuantiteEnMagasinSource.Visible = False

        GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

        Dim CODE_BORDEREAUX As String = ""

        Dim econom As New Economat()
        'Enregistrement des éléments du bordereau

        CODE_BORDEREAUX = GunaTextBoxCodeBordereau.Text
        Dim ETAT_DU_BORDEREAU As Integer = 0
        Dim TYPE_BORDEREAUX As String = GunaComboBoxTypeBordereau.SelectedItem.ToString
        Dim REF_BORDEREAUX As String = ""
        Dim LIBELLE_BORDEREAUX As String = GunaTextBoxLibelleBordereau.Text
        Dim CODE_TIERS As String = GunaTextBoxTiers.Text
        Dim NON_TIERS As String = GunaTextBoxNomTiers.Text
        Dim DATE_BORDEREAU As Date = GlobalVariable.DateDeTravail
        Dim OBSERVATIONS As String = GunaTextBoxObservation.Text
        Dim MONTANT_HT As Double = 0 ' MONTANT VENTE

        If Not Trim(GunaTextBoxMontantHTGeneral.Text) = "" Then
            MONTANT_HT = Double.Parse(GunaTextBoxMontantHTGeneral.Text)
        End If

        Dim MONTANT_TAXE As Double = 0
        Dim MONTANT_TTC As Double = 0
        Dim MONTANT_PAYER As Double = 0 ' MONTANT ACHAT

        If Not Trim(GunaTextBoxMontantTTCGeneral.Text) = "" Then
            MONTANT_PAYER = Double.Parse(GunaTextBoxMontantTTCGeneral.Text)
        End If

        Dim VALIDE As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            VALIDE = "NOT CONTROLED"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            VALIDE = "NON CONTROLE"
        End If

        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_MAGASIN As String = ""

        Dim CODE_SOUS_MAGASIN As String = ""

        If GunaComboBoxMagasinReception.SelectedIndex >= 0 Then
            CODE_SOUS_MAGASIN = GunaComboBoxMagasinReception.SelectedValue.ToString()
        End If

        Dim infoSupMagCentrale As DataTable
        Dim TYPE_MAGASIN As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            TYPE_MAGASIN = "Main storage"

            infoSupMagCentrale = Functions.getElementByCode(TYPE_MAGASIN, "magasin", "TYPE_MAGASIN")

            If infoSupMagCentrale.Rows.Count > 0 Then
                CODE_MAGASIN = infoSupMagCentrale.Rows(0)("CODE_MAGASIN")
            End If

        Else

            TYPE_MAGASIN = "Magasin central"
            infoSupMagCentrale = Functions.getElementByCode(TYPE_MAGASIN, "magasin", "TYPE_MAGASIN")

            If infoSupMagCentrale.Rows.Count > 0 Then
                CODE_MAGASIN = infoSupMagCentrale.Rows(0)("CODE_MAGASIN")
            End If

        End If
        '---------------------------------------

        Dim COUT_DU_STOCK As Double = 0

        If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then
            CODE_BORDEREAUX = Trim(GunaTextBoxCodeBordereau.Text)
            ETAT_DU_BORDEREAU = ETAT_DU_BORDE
            VALIDE = ETAT_NOTE_DU_BORDEREAU
        End If

        If Trim(TYPE_BORDEREAUX) = GlobalVariable.sortie_exceptionnelle Then
            CODE_MAGASIN = CODE_SOUS_MAGASIN
            CODE_SOUS_MAGASIN = ""
        End If

        'Insertion des information du bordereau
        If econom.insertBordereau(CODE_BORDEREAUX, TYPE_BORDEREAUX, REF_BORDEREAUX, LIBELLE_BORDEREAUX, CODE_TIERS, NON_TIERS, DATE_BORDEREAU, OBSERVATIONS, MONTANT_HT, MONTANT_TAXE, MONTANT_TTC, MONTANT_PAYER, VALIDE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_MAGASIN, CODE_SOUS_MAGASIN, ETAT_DU_BORDEREAU) Then

            Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")
            Dim CHAMP_A_METTRE_A_JOUR As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                CHAMP_A_METTRE_A_JOUR = "SAVED"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                CHAMP_A_METTRE_A_JOUR = "ENREGISTRER"
            End If

            econom.inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)

            '-----------------------LIGNE DE BORDEREAUX -----------------------------
            'TRANSFERT INTER MAGASINS
            '------------------------ LIGNE DE MOVEMENT --------------------------

            For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

                'Defini plus bas selon si c'est une commande ou une reception
                Dim CODE_LOT As String = ""

                'Verif d'exitence de valeur pour le lot
                If GunaComboBoxListeDesLots.SelectedIndex >= 0 Then
                    'CODE_LOT = GunaComboBoxListeDesLots.SelectedValue.ToString
                End If

                Dim CODE_LIGNE As String = ""

                If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Store Requisition" Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then
                    CODE_LIGNE = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "")
                End If

                Dim CODE_ARTICLE As String = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("CODE ARTICLE").Value.ToString

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                Dim Article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                If Article.Rows.Count > 0 Then
                    QUANTITE_AVANT_MOVEMENT = Article.Rows(0)("QUANTITE")
                    CMUP = Article.Rows(0)("PRIX_ACHAT_HT")
                End If

                Dim qte As Double = 0

                If GlobalVariable.actualLanguageValue = 0 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("STOCK").Value.ToString, qte)
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)
                End If

                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                If GlobalVariable.actualLanguageValue = 0 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value, entre_en_stock)
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value, entre_en_stock)
                End If

                Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock 'QUANTITE EN MOVEMENT

                Dim DATE_PEREMPTION As Date

                Dim UNITE_UTILISE As String
                Dim PRIX_UNITAIRE_HT As Double
                Dim PRIX_UNITAIRE_TTC As Double
                Dim PRIX_TOTAL_HT As Double
                Dim PRIX_TOTAL_TTC As Double
                Dim NUM_SERIE_DEBUT As String
                Dim NUM_SERIE_FIN As String


                If GlobalVariable.actualLanguageValue = 0 Then
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value
                    PRIX_UNITAIRE_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT PRICE").Value 'PRIX UNITAIRE ACHAT
                    PRIX_UNITAIRE_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value 'PRIX UNITAIRE VENTE
                    PRIX_TOTAL_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT PRICE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL ACHAT
                    PRIX_TOTAL_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL VENTE
                    NUM_SERIE_DEBUT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value
                    NUM_SERIE_FIN = ""

                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value
                    PRIX_UNITAIRE_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX UNITAIRE").Value 'PRIX UNITAIRE ACHAT
                    PRIX_UNITAIRE_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value 'PRIX UNITAIRE VENTE
                    PRIX_TOTAL_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX UNITAIRE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL ACHAT
                    PRIX_TOTAL_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL VENTE
                    NUM_SERIE_DEBUT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value
                    NUM_SERIE_FIN = ""

                End If

                'NUM_SERIE_DEBUT : USED AS UNITE DE DESTOCKAGE UTILISE POUR LIGNE DE BORDEREAU

                '-------------------------- DEBUT TRAITEMENTS DE LIGNE DE MOUVEMENT FONCTION DE L'UNITE UTILISEE ------------------------------------------------
                Dim PETITE_UNITE As String = ""
                Dim GRANDE_UNITE As String = ""
                Dim LIBELLE_UNITE As String = UNITE_UTILISE

                Dim VALEUR_DE_CONVERSION As Double = 1

                If Article.Rows.Count > 0 Then

                    Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")

                    Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If unite.Rows.Count > 0 Then

                        PETITE_UNITE = unite.Rows(0)("PETITE_UNITE")
                        GRANDE_UNITE = unite.Rows(0)("GRANDE_UNITE")
                        VALEUR_DE_CONVERSION = unite.Rows(0)("VALEUR_NUMERIQUE")

                        If LIBELLE_UNITE = PETITE_UNITE Then
                            'QUANTITE = QUANTITE / VALEUR_DE_CONVERSION
                            'QUANTITE_ENTREE_STOCK = QUANTITE_ENTREE_STOCK / VALEUR_DE_CONVERSION
                        End If

                    End If

                End If

                '------------------------------------------------------------------------------------------------------------------------------------------------

                If GlobalVariable.actualLanguageValue = 0 Then
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                End If

                'NUM_SERIE_DEBUT : USED AS UNITE D'ENTREE
                'Insertion des informations des lignes du bordereau
                If econom.insertLigneBordereau(CODE_BORDEREAUX, CODE_LIGNE, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE, QUANTITE_ENTREE_STOCK, DATE_PEREMPTION, PRIX_UNITAIRE_HT, PRIX_UNITAIRE_TTC, PRIX_TOTAL_HT, PRIX_TOTAL_TTC, NUM_SERIE_DEBUT, NUM_SERIE_FIN, COUT_DU_STOCK, CODE_SOUS_MAGASIN) Then

                End If

            Next

            Dim sendMessage As New User()

            Dim CODE_PROFIL As String
            Dim MESSAGE As String
            Dim OBJET As String

            Dim getArticleQuery As String = "SELECT * FROM utilisateurs WHERE CATEG_UTILISATEUR LIKE '%ECONOM%'"

            '--------------------------------------------------------------------------------

            Dim str As String = ""

            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            adapter.SelectCommand = Command
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                CODE_PROFIL = table.Rows(0)("CATEG_UTILISATEUR")
            Else
                CODE_PROFIL = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
            End If

            If GlobalVariable.actualLanguageValue = 0 Then

                'CODE DU PROFIL DE L'ECONOME

                If True Then

                Else

                End If

                MESSAGE = "STORE REQUISITION [" & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & "] ON THE " & GlobalVariable.DateDeTravail
                OBJET = "STORE REQUISITION"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                'CODE_PROFIL = "ECONOM"

                If GunaComboBoxTypeBordereau.SelectedIndex = 0 Then
                    MESSAGE = "DEMANDE D'APPROVISIONNEMENT [" & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & "] LE " & GlobalVariable.DateDeTravail
                    OBJET = "DEMANDE D'APPROVISIONNEMENT"
                ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 1 Then
                    MESSAGE = "DEMANDE DE CONTROLE DE SORTIE [" & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & "] LE " & GlobalVariable.DateDeTravail
                    OBJET = "DEMANDE DE CONTROLE DE SORTIE"

                End If

            End If

            Dim EXPEDITEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
            Dim DATE_ENVOI As Date = Date.Now()

            'NOTIFICATIONS

            sendMessage.sendMessage(CODE_PROFIL, MESSAGE, OBJET, DATE_ENVOI, EXPEDITEUR)

        End If

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
            'ON MET A JOUR LA PERIODE DE LA LISTE DU MARCHE

            Dim DATE_DU As Date = GunaDateTimePicker1.Value.ToShortDateString()
            Dim DATE_AU As Date = GunaDateTimePicker2.Value.ToShortDateString()

            Dim PASSANT As Integer = 0

            If Not Trim(GunaTextBoxPassant.Text).Equals("") Then
                PASSANT = GunaTextBoxPassant.Text
            End If

            Dim updateQuery As String = "UPDATE `bordereaux` SET `DATE_DU` = @DATE_DU , `DATE_AU` = @DATE_AU, `PASSANT` = @PASSANT WHERE CODE_BORDEREAUX = @CODE_BORDEREAUX"

            Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

            command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
            command.Parameters.Add("@DATE_DU", MySqlDbType.Date).Value = DATE_DU
            command.Parameters.Add("@DATE_AU", MySqlDbType.Date).Value = DATE_AU
            command.Parameters.Add("@PASSANT", MySqlDbType.Int64).Value = PASSANT

            command.ExecuteNonQuery()

            '--------------------------------

            If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                RapportApresCloture.impressionEconomat(GunaDataGridViewLigneArticleCommande, title, totalAchat, totalVente, numeroBon, ETAT_BORDEREAUX_MAIL, nomTiers, libelle, reference, observation, typeBordereau, from)
            End If

            '-------------------------------
        End If

        Functions.SiplifiedClearTextBox(Me)

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

    End Sub

    Dim CODE_REFERENCE_BORDERO As String = ""

    Dim title As String
    Dim nomTiers As String
    Dim libelle As String
    Dim reference As String
    Dim observation As String
    Dim numeroBon As String
    Dim typeBordereau As String
    Dim from As String
    Dim ETAT_BORDEREAUX_MAIL As Integer = 0

    Dim totalVente As Double = 0
    Dim totalAchat As Double = 0

    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Me.Cursor = Cursors.WaitCursor

        GunaComboBoxTypeBordereau.Enabled = True

        Dim econom As New Economat()

        If GunaButtonEnregistrer.Text = "Emettre" Or GunaButtonEnregistrer.Text = "Emit" Then

            If GunaComboBoxTypeBordereau.SelectedItem = "Store Requisition" Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.list_du_marche Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Market List" Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then

                    title = LabelBon.Text
                    nomTiers = GunaTextBoxNomTiers.Text
                    libelle = GunaTextBoxLibelleBordereau.Text
                    reference = ""
                    observation = GunaTextBoxObservation.Text
                    numeroBon = GunaTextBoxCodeBordereau.Text
                    typeBordereau = GlobalVariable.list_du_marche
                    from = "approvisionnement"
                    ETAT_BORDEREAUX_MAIL = 0

                    'Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

                    If Not Trim(GunaTextBoxMontantHTGeneral.Text).Equals("") Then
                        totalAchat = GunaTextBoxMontantHTGeneral.Text
                    End If

                    If Not Trim(GunaTextBoxMontantTTCGeneral.Text).Equals("") Then
                        totalVente = GunaTextBoxMontantTTCGeneral.Text
                    End If

                End If

                Dim STATUS As String = ""
                If GlobalVariable.actualLanguageValue = 0 Then
                    STATUS = "NOT VALIDATED"
                    lanaguageMessage = "Slip successfully emitted !"
                    lanaguageTitle = "Slip"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    STATUS = "NON VALIDE"
                    lanaguageMessage = "Bordereau Emit avec succès !"
                    lanaguageTitle = "Bordereau"
                End If

                InsertionDesElementsPourGestionDeStock(STATUS)

                MessageBox.Show(lanaguageMessage, lanaguageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_USER As String = GlobalVariable.codeUser

        econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

        TabControlEconomat.SelectedIndex = 1

        NewBonDeRequisition()

        Me.Cursor = Cursors.Default

        TabControlEconomat.SelectedIndex = 0

    End Sub


    Private Sub ToolStripMenuItem105_Click(sender As Object, e As EventArgs)
        FournisseurForm.Show()
    End Sub

    Sub AutoLoadlisteDesLotsDansLeBordereaux()

        Dim table As DataTable = Functions.allTableFieldsOrganised("lot", "LIBELLE_LOT")

        If (table.Rows.Count > 0) Then

            GunaComboBoxListeDesLots.DataSource = table
            GunaComboBoxListeDesLots.ValueMember = "CODE_LOT"
            GunaComboBoxListeDesLots.DisplayMember = "LIBELLE_LOT"

        End If

    End Sub

    Public Sub AutoLoadlisteMagasinSource()

        'Dim table As DataTable = Functions.allTableFieldsOrganised("magasin", "LIBELLE_MAGASIN")
        Dim table As DataTable = Functions.getElementByCode("Petit magasin", "magasin", "TYPE_MAGASIN")

        If (table.Rows.Count > 0) Then

            GunaComboBoxMagasinReception.DataSource = table
            GunaComboBoxMagasinReception.ValueMember = "CODE_MAGASIN"
            GunaComboBoxMagasinReception.DisplayMember = "LIBELLE_MAGASIN"

        End If

        GunaComboBoxMagasinReception.SelectedValue = GlobalVariable.magasinActuel

    End Sub

    Sub AutoLoadlisteMagasinDestination()

        Dim table As DataTable = Functions.allTableFieldsOrganised("magasin", "LIBELLE_MAGASIN")

        If (table.Rows.Count > 0) Then

            GunaComboBoxMagasinDeDestination.DataSource = table
            GunaComboBoxMagasinDeDestination.ValueMember = "CODE_MAGASIN"
            GunaComboBoxMagasinDeDestination.DisplayMember = "LIBELLE_MAGASIN"

        End If

    End Sub

    '2- BORDEREAU TAB

    'Choix des articles pour entrer en magasin
    Private Sub GunaTextBoxArticle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxArticle.TextChanged

        GunaDataGridViewArticle.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxArticle.Text).Equals("") Then

            GunaComboBoxUniteOuConso.Items.Clear()

            GunaTextBoxGrandeUniteDeCompatge.Clear()

            GunaTextBoxEnStock.Text = 0

            GunaTextBoxSeuile.Text = 0

            GunaTextBoxCoutDuStock.Text = 0

            GunaTextBoxQuantite.Text = 1

            GunaDataGridViewArticle.Visible = False
            GunaButtonAjouterLigne.Visible = False

            LabelQuantiteEnMagasinSource.Visible = False
            GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

            LabelQteEnMagasinDeDestination.Visible = False
            GunaTextBoxQunatiteDansLeMagasinDestination.Visible = False

            GunaTextBoxQunatiteDansLeMagasinProvenance.Clear()

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonAjouterLigne.Text = "Add"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterLigne.Text = "Ajouter"

            End If

        End If

        'Determining from which table to search for the articles

        If GunaTextBoxSuivreArticleNonSuivi.Text = "OUI" Or GunaTextBoxSuivreArticleNonSuivi.Text = "YES" Then
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND METHODE_SUIVI_STOCK=@METHODE_SUIVI_STOCK OR DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND METHODE_SUIVI_STOCK=@METHODE_NON_SUIVI_STOCK AND CARTE =@CARTE ORDER BY DESIGNATION_FR ASC"
        Else
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND METHODE_SUIVI_STOCK=@METHODE_SUIVI_STOCK AND CARTE =@CARTE ORDER BY DESIGNATION_FR ASC"
        End If

        'getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY  ORDER BY DESIGNATION_FR ASC"

        Dim METHODE_NON_SUIVI_STOCK As String = "Non Suivi"

        Dim METHODE_SUIVI_STOCK As String = "Suivi simple"

        If GlobalVariable.actualLanguageValue = 0 Then

            METHODE_NON_SUIVI_STOCK = "No Tracking"

            METHODE_SUIVI_STOCK = "Simple Tracking"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            METHODE_NON_SUIVI_STOCK = "Non suivi"

            METHODE_SUIVI_STOCK = "Suivi simple"

        End If

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)

        Command.Parameters.Add("@METHODE_SUIVI_STOCK", MySqlDbType.VarChar).Value = METHODE_SUIVI_STOCK

        Command.Parameters.Add("@METHODE_NON_SUIVI_STOCK", MySqlDbType.VarChar).Value = METHODE_NON_SUIVI_STOCK

        'EMPECHE L'AFFICHAGE DES ARTICLES A LA CARTE DONC LES PLATS

        Dim CARTE As Integer = 0
        Command.Parameters.Add("@CARTE", MySqlDbType.Int64).Value = CARTE

        adapter.SelectCommand = Command
        adapter.Fill(table)

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

    Dim partieDecimalBoolean As Boolean = False

    'Ajout de l'article dans la liste des articles a mettre en magasin
    Private Sub GunaDataGridViewArticle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticle.CellClick, GunaDataGridViewPrevisions.CellClick

        GunaDataGridViewArticle.Visible = False

        Dim econom As New Economat()
        'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
        'il disparait de nouveau après ajout a la facture

        GunaButtonAjouterLigne.Visible = True

        If e.RowIndex >= 0 Then

            GunaTextBoxQuantite.Text = 1

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewArticle.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE DESIGNATION_FR=@DESIGNATION_FR ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@DESIGNATION_FR", MySqlDbType.VarChar).Value = Trim(row.Cells("DESIGNATION_FR").Value.ToString)

            adapter.SelectCommand = command
            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then

                GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")

                LabelQuantiteEnMagasinSource.Visible = False
                GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

                LabelQteEnMagasinDeDestination.Visible = False
                GunaComboBoxMagasinDeDestination.Visible = False

                GunaTextBoxAchat.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") 'PRIX D'ACHAT 
                GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0") 'COUT MOYEN UNITAIRE PONDERE
                GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxSeuile.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")
                GunaTextBoxEnStock.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.00")
                GunaTextBoxCodeUniteComptage.Text = Article.Rows(0)("UNITE_COMPTAGE")

                GunaTextBoxCoutDuStock.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") ' PRIX UNITAIRE A L'ACHAT

                Dim unite As DataTable = Functions.getElementByCode(GunaTextBoxCodeUniteComptage.Text, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If unite.Rows.Count > 0 Then
                    gestionDesUnites(Article)

                    GunaComboBoxUniteOuConso.SelectedIndex = -1

                End If

                'partieDecimalBoolean = retentionDeLaPartieDecimalBoolean(GunaTextBoxEnStock.Text)

                'GESTION DE L'AFFICHAGE DES VALEURS A VIRGULES

                If Not Trim(GunaTextBoxEnStock.Text) = "" Then

                    If unite.Rows.Count > 0 Then

                        If unite.Rows(0)("VALEUR_NUMERIQUE") > 1 Then

                            GunaComboBoxUniteOuConso.SelectedItem = unite.Rows(0)("GRANDE_UNITE")

                            Dim nombre As Double = GunaTextBoxEnStock.Text

                            Dim partieDecimal As Double = 0

                            partieDecimal = retentionDeLaPartieDecimal(nombre)

                            If partieDecimal < 0 Or partieDecimal > 0 Then

                                Label2.Visible = True

                                GunaTextBoxQtePetiteUnite.Visible = True

                                GunaTextBoxEnStock.Text = Double.Parse(GunaTextBoxEnStock.Text) - partieDecimal

                            Else
                                'Label2.Visible = False
                                'GunaTextBoxQtePetiteUnite.Visible = False
                            End If

                        Else
                            GunaComboBoxUniteOuConso.SelectedIndex = 0
                        End If

                        Label14.Text = unite.Rows(0)("GRANDE_UNITE")

                        Label2.Text = unite.Rows(0)("PETITE_UNITE")

                    End If

                End If

                GunaDataGridViewArticle.Visible = False

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid

            End If

            'connect.closeConnection()

        End If

    End Sub

    Dim montantGlobalAchat As Double = 0
    Dim montantGlobalVente As Double = 0

    Private Sub afficherCommande()

        Dim econom As New Economat
        '3- ON RECHARGE LE CONTENU DU bordero_ligne_temp dans le datagrid
        GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)

        GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False
        GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

    End Sub

    'Ajouter un article sélectionné dans le datagrid
    Private Sub GunaButtonAjouterLigne_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click

        Dim econom As New Economat()

        Dim CODE_BORDEREAUX As String = ""
        Dim DESIGNATION As String = ""
        Dim CODE_ARTICLE As String = ""
        Dim QUANTITE As Double = 0
        Dim EN_STOCK As Double = 0
        Dim DATE_PEREMPTION As Date
        Dim PRIX_VENTE As Double = 0
        Dim PRIX_ACHAT As Double = 0
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim UNITE_COMPTAGE As String = ""
        Dim COUT_DU_STOCK As Double = 0
        Dim ID_LIGNE_BORDEREAU As Integer
        Dim dateDatePeremption As Date
        If Not (GlobalVariable.DateDeTravail > GunaDateTimePickerDatePeremption.Value And GunaDateTimePickerDatePeremption.Value > GlobalVariable.DateDeTravail) Then
            dateDatePeremption = GunaDateTimePickerDatePeremption.Value.ToShortDateString
        End If

        'MISE A JOUR D'UN BORDEREAU

        If GunaButtonAjouterLigne.Text = "Modifier" Or GunaButtonAjouterLigne.Text = "Edit" Then

            ID_LIGNE_BORDEREAU = GunaTextBoxID_LIGNE_TEMP.Text

            CODE_BORDEREAUX = Trim(GunaTextBoxCodeBordereau.Text)
            'modification des élemenets ou ligne du bordereau

            '0' - On supprime l'ancienne occurence de l'article
            CODE_ARTICLE = GunaTextBoxCodeArticle.Text

            GunaTextBoxTVARecap.Text = CODE_ARTICLE

            'On supprime les lignes existantes pour prendre en compte d'eventuelle mise a jour sans risque de doublons

            Functions.DeleteElementOnTwoConditions(ID_LIGNE_BORDEREAU, "bordereau_ligne_temp", "ID_LIGNE_BORDEREAU", "CODE_USER", CODE_USER)

            '2 on ajoute l'element nouvellement saisie dans bordereau_ligne_temp
            UNITE_COMPTAGE = GunaComboBoxUniteOuConso.SelectedItem
            CODE_BORDEREAUX = GunaTextBoxCodeBordereau.Text
            DESIGNATION = GunaTextBoxArticle.Text
            CODE_ARTICLE = GunaTextBoxCodeArticle.Text
            QUANTITE = Double.Parse(GunaTextBoxQuantite.Text)
            EN_STOCK = Double.Parse(GunaTextBoxEnStock.Text)
            DATE_PEREMPTION = dateDatePeremption
            'PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
            PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text)
            'PRIX_ACHAT = Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text) 'PRIX UNITAIRE A LA VENTE
            PRIX_ACHAT = Double.Parse(GunaTextBoxAchat.Text)  'PRIX UNITAIRE A L'ACHAT

            If Trim(GunaTextBoxCoutDuStock.Text) = "" Then
                GunaTextBoxCoutDuStock.Text = 0
            End If

            'COUT TOTAL DU STOCK : PROX TOTAL
            COUT_DU_STOCK = Double.Parse(GunaTextBoxCoutDuStock.Text) * QUANTITE

            econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)

            'GunaDataGridViewLigneArticleMagasin.Rows.Add(GunaTextBoxCodeArticle.Text, GunaTextBoxArticle.Text, GunaTextBoxQuantite.Text, Double.Parse(GunaTextBoxEnStock.Text), Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text), Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text), dateDatePeremption)

            GunaDataGridViewLigneArticleCommande.Columns.Clear()

            '3- ON RECHARGE LE CONTENU DU bordero_ligne_temp dans le datagrid
            GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)

            'econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonAjouterLigne.Text = "Add"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterLigne.Text = "Ajouter"
            End If


        Else

            UNITE_COMPTAGE = GunaComboBoxUniteOuConso.SelectedItem
            CODE_BORDEREAUX = GunaTextBoxCodeBordereau.Text
            DESIGNATION = GunaTextBoxArticle.Text
            CODE_ARTICLE = GunaTextBoxCodeArticle.Text

            EN_STOCK = Double.Parse(GunaTextBoxEnStock.Text)
            DATE_PEREMPTION = dateDatePeremption

            If Trim(GunaTextBoxPrixVente.Text) = "" Then
                GunaTextBoxPrixVente.Text = 1
            End If

            If Trim(GunaTextBoxQuantite.Text) = "" Then
                GunaTextBoxQuantite.Text = 1
            End If

            QUANTITE = Double.Parse(GunaTextBoxQuantite.Text)

            'PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
            PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text)
            'PRIX_ACHAT = Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
            PRIX_ACHAT = Double.Parse(GunaTextBoxAchat.Text) 'PRIX UNITAIRE

            CODE_AGENCE = GlobalVariable.codeAgence
            CODE_USER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
            Dim coutDuStock As Double = 0

            If Trim(GunaTextBoxCoutDuStock.Text) = "" Then
                GunaTextBoxCoutDuStock.Text = 0
            End If

            Double.TryParse(GunaTextBoxCoutDuStock.Text, coutDuStock)

            COUT_DU_STOCK = coutDuStock * QUANTITE

            econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)

            GunaDataGridViewLigneArticleCommande.Columns.Clear()

            GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)


        End If

        If GlobalVariable.actualLanguageValue = 0 Then

            GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0.0"
            GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

            GunaDataGridViewLigneArticleCommande.Columns("ITEM").ReadOnly = True
            GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").ReadOnly = True
            GunaDataGridViewLigneArticleCommande.Columns("STOCK").ReadOnly = True


        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0.0"
            GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").Visible = False

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

            GunaDataGridViewLigneArticleCommande.Columns("DESIGNATION").ReadOnly = True
            GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").ReadOnly = True
            GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").ReadOnly = True

        End If

        GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False

        GunaTextBoxArticle.Clear()
        GunaButtonAjouterLigne.Visible = False

        montantGlobalAchat = 0
        montantGlobalVente = 0

        For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1
            If GlobalVariable.actualLanguageValue = 0 Then
                montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value
            End If

        Next

        GunaTextBoxMontantHTGeneral.Text = Format(montantGlobalAchat, "#,##0")

        GunaTextBoxMontantTTCGeneral.Text = Format(montantGlobalVente, "#,##0")

        GunaTextBoxQuantite.Text = 1
        GunaTextBoxPrixVente.Text = 0
        GunaTextBoxAchat.Text = 0

        montantGlobalAchat = 0
        montantGlobalVente = 0

        GunaTextBoxSeuile.Text = 0
        GunaTextBoxEnStock.Text = 0
        GunaTextBoxCoutDuStock.Text = 0

        GunaTextBoxGrandeUniteDeCompatge.Clear()

        LabelQuantiteEnMagasinSource.Visible = False
        LabelQteEnMagasinDeDestination.Visible = False
        GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False
        GunaTextBoxQunatiteDansLeMagasinDestination.Visible = False

    End Sub

    'appuarution du second magasin en cas de transfert inter magain
    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeBordereau.SelectedIndexChanged

        NewBonDeRequisition()

        Dim econom As New Economat()

        GunaLabel94.Visible = False
        GunaComboBoxMagasinDeDestination.Visible = False

        LabelQuantiteEnMagasinSource.Visible = False
        LabelQteEnMagasinDeDestination.Visible = False
        GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False
        GunaTextBoxQunatiteDansLeMagasinDestination.Visible = False

        PanelGestionLot.Visible = False

        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

        'Functions.SiplifiedClearTextBox(Me)

        GunaTextBoxSeuile.Text = 0

        GunaTextBoxEnStock.Text = 0

        GunaTextBoxQuantite.Text = 1

        GunaTextBoxGrandeUniteDeCompatge.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then

            GunaButtonEnregistrer.Text = "Emit"

            If GunaComboBoxTypeBordereau.SelectedIndex >= 0 Then

                If GunaComboBoxTypeBordereau.SelectedItem = "Market List" Then
                    LabelBon.Text = "MARKET LIST"
                    GunaPanel3.Visible = True
                    GunaPanelPax.Visible = True
                    GunaLabelNbrePax.Visible = True

                    GunaDateTimePicker1.Value = GlobalVariable.DateDeTravail
                    GunaDateTimePicker1.MinDate = GlobalVariable.DateDeTravail
                    GunaDateTimePicker1.MaxDate = GlobalVariable.DateDeTravail.AddDays(7)
                    GunaDateTimePicker2.MinDate = GlobalVariable.DateDeTravail
                    GunaDateTimePicker2.Value = GlobalVariable.DateDeTravail.AddDays(7)

                Else
                    LabelBon.Text = "STORE REQUISITION"
                    GunaPanel3.Visible = False
                    GunaPanelPax.Visible = False
                    GunaLabelNbrePax.Visible = True
                End If

            End If

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            GunaButtonEnregistrer.Text = "Emettre"

            If GunaComboBoxTypeBordereau.SelectedIndex >= 0 Then

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
                    LabelBon.Text = "LISTE DU MARCHE"

                    GunaPanel3.Visible = True
                    GunaPanelPax.Visible = True
                    GunaLabelNbrePax.Visible = True

                    GunaDateTimePicker1.Value = GlobalVariable.DateDeTravail
                    GunaDateTimePicker1.MinDate = GlobalVariable.DateDeTravail
                    GunaDateTimePicker1.MaxDate = GlobalVariable.DateDeTravail.AddDays(7)
                    GunaDateTimePicker2.MinDate = GlobalVariable.DateDeTravail
                    GunaDateTimePicker2.Value = GlobalVariable.DateDeTravail.AddDays(7)

                Else

                    LabelBon.Text = "BON D'APPROVISIONNEMENT"
                    GunaPanel3.Visible = False
                    GunaPanelPax.Visible = False
                    GunaLabelNbrePax.Visible = False

                End If

            End If

        End If

    End Sub

    Private Sub GunaComboBoxTypeTiers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeTiers.SelectedIndexChanged

        GunaTextBoxTiers.Clear()
        GunaTextBoxNomTiers.Clear()

    End Sub

    Private Sub empecherAjoutArticle()

        GunaTextBoxArticle.Enabled = False
        GunaTextBoxArticle.BaseColor = Color.LightGray
        GunaTextBoxLecteurRFID.Enabled = False
        GunaTextBoxLecteurRFID.BaseColor = Color.LightGray

    End Sub

    Private Sub permettreAjoutArticle()

        GunaTextBoxArticle.Enabled = True
        GunaTextBoxArticle.BaseColor = Color.White
        GunaTextBoxLecteurRFID.Enabled = True
        GunaTextBoxLecteurRFID.BaseColor = Color.White

    End Sub

    'MODIFICATION DE DATAGRID DES LIGNE DU BORDEREAU DE COMMANDE
    Private Sub GunaDataGridViewLigneArticleMagasin_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaButtonAjouterLigne.Text = "Edit"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaButtonAjouterLigne.Text = "Modifier"

            End If

            GunaButtonAjouterLigne.Visible = True

            Dim row As DataGridViewRow
            row = Me.GunaDataGridViewLigneArticleCommande.Rows(e.RowIndex)

            GunaTextBoxCodeArticle.Text = row.Cells("CODE ARTICLE").Value.ToString

            Dim article As DataTable = Functions.getElementByCode(GunaTextBoxCodeArticle.Text, "article", "CODE_ARTICLE")

            If (article.Rows.Count > 0) Then

                GunaTextBoxCodeArticle.Text = article.Rows(0)("CODE_ARTICLE")
                GunaTextBoxQuantite.Text = row.Cells("QUANTITE").Value.ToString()
                GunaTextBoxAchat.Text = Format(article.Rows(0)("PRIX_ACHAT_HT"), "#,##0")
                GunaTextBoxPrixVente.Text = Format(article.Rows(0)("PRIX_VENTE_HT"), "#,##0")
                GunaTextBoxArticle.Text = article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxSeuile.Text = article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")
                GunaTextBoxEnStock.Text = article.Rows(0)("QUANTITE")

                GunaDataGridViewArticle.Visible = False

            End If

        End If

    End Sub

    'GESTION DU LECTUER RFID
    Private Sub GunaCheckBoxLecteurRFID_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxLecteurRFID.CheckedChanged

        If GunaCheckBoxLecteurRFID.Checked Then

            GunaTextBoxLecteurRFID.Focus()
            GunaTextBoxLecteurRFID.Visible = True
            'GunaTextBoxLecteurRFID.TabIndex = 0
            GunaTextBoxLecteurRFID.Select()

            GunaTextBoxQuantite.Visible = False
            LabelQuantite.Visible = False

            GunaTextBoxCoutDuStock.Visible = False
            LabelCout.Visible = False

        Else

            GunaTextBoxCoutDuStock.Visible = True
            LabelCout.Visible = True

            GunaTextBoxLecteurRFID.Visible = False

            GunaTextBoxQuantite.Visible = True
            LabelQuantite.Visible = True

            GunaTextBoxArticle.Enabled = True

        End If

    End Sub

    'Apres qjout de la touche entree de lecteur de code rfid
    Private Sub GunaTextBoxLecteurRFID_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxLecteurRFID.KeyUp

        If e.KeyCode = Keys.Enter Then

        End If

    End Sub

    Private Sub GunaTextBoxLecteurRFID_Validated(sender As Object, e As EventArgs) Handles GunaTextBoxLecteurRFID.Validated

        'Chargement des variables necessaires a l'enregistrement du produit.
        Dim CODE_BARRE As String = GunaTextBoxLecteurRFID.Text
        Dim econom As New Economat()

        Dim Article As DataTable = Functions.getElementByCode(CODE_BARRE, "article", "CODE_BARRE")

        If Article.Rows.Count > 0 And Not Trim(GunaTextBoxLecteurRFID.Text) = "" Then

            GunaTextBoxQuantite.Text = 1

            GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")

            LabelQuantiteEnMagasinSource.Visible = False
            GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

            LabelQteEnMagasinDeDestination.Visible = False
            LabelQteEnMagasinDeDestination.Visible = False

            GunaTextBoxAchat.Text = Format(Article.Rows(0)("PRIX_ACHAT_HT"), "#,##0")
            GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0")
            GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
            GunaTextBoxSeuile.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")
            GunaTextBoxEnStock.Text = Article.Rows(0)("QUANTITE")
            'GunaTextBoxObservation.Text = Article.Rows(0)("DESIGNATION_FR")
            GunaDataGridViewArticle.Visible = False

        End If

        ' End 'Chargement des variables necessaires a l'enregistrement du produit.

        ' Enregistrement des informations du produit

        Dim dateDatePeremption As Date
        If Not (GlobalVariable.DateDeTravail > GunaDateTimePickerDatePeremption.Value And GunaDateTimePickerDatePeremption.Value > GlobalVariable.DateDeTravail) Then
            dateDatePeremption = GunaDateTimePickerDatePeremption.Value.ToShortDateString
        End If

        If Not GunaTextBoxCodeBordereau.Text = "" Then

            'modification des élemenets ou ligne du bordereau

            'GunaDataGridViewLigneArticleMagasin.Columns.Clear()
            'Dim tableTemp As DataTable = economatArticleQuelconque.ArticleDunBordereauQuelconque(Trim(GunaTextBoxReference.Text), "ligne_bordereaux_temp")
            'GunaDataGridViewLigneArticleMagasin.DataSource = tableTemp

        Else
            'Nouveau bordereau


            If Article.Rows.Count > 0 And Not Trim(GunaTextBoxLecteurRFID.Text) = "" Then


                Dim CODE_BORDEREAUX = ""
                Dim DESIGNATION = GunaTextBoxArticle.Text
                Dim CODE_ARTICLE = GunaTextBoxCodeArticle.Text
                Dim QUANTITE = Double.Parse(GunaTextBoxQuantite.Text)
                Dim EN_STOCK = Double.Parse(GunaTextBoxEnStock.Text)
                Dim DATE_PEREMPTION = dateDatePeremption
                Dim PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
                Dim PRIX_ACHAT = Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
                Dim CODE_AGENCE = GlobalVariable.codeAgence
                Dim CODE_USER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                Dim coutDuStock As Double = 0

                If Trim(GunaTextBoxCoutDuStock.Text) = "" Then
                    GunaTextBoxCoutDuStock.Text = 0
                End If

                Double.TryParse(GunaTextBoxCoutDuStock.Text, coutDuStock)
                Dim COUT_DU_STOCK As Double = coutDuStock

                econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, CODE_USER, COUT_DU_STOCK)

                'GunaDataGridViewLigneArticleMagasin.Rows.Add(GunaTextBoxCodeArticle.Text, GunaTextBoxArticle.Text, GunaTextBoxQuantite.Text, Double.Parse(GunaTextBoxEnStock.Text), Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text), Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text), dateDatePeremption)

                GunaDataGridViewLigneArticleCommande.Columns.Clear()

                GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)

                'GunaDataGridViewLigneArticleMagasin.Columns.Clear()
                'GunaDataGridViewLigneArticleMagasin.Rows.Add(GunaTextBoxCodeArticle.Text, GunaTextBoxArticle.Text, GunaTextBoxQuantite.Text, Double.Parse(GunaTextBoxEnStock.Text), Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text), Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text), dateDatePeremption)
            End If

        End If

        If GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("COST PRICE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneArticleCommande.Columns("COST PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLigneArticleCommande.Columns("STOCK COST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewLigneArticleCommande.Columns("STOCK COST").DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewLigneArticleCommande.Columns("COST PRICE").Visible = False
                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

                'GunaDataGridViewLigneArticleCommande.Columns("DATE DE PEREMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("PRIX ACHAT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneArticleCommande.Columns("PRIX ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLigneArticleCommande.Columns("COUT DU STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewLigneArticleCommande.Columns("COUT DU STOCK").DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewLigneArticleCommande.Columns("PRIX ACHAT").Visible = False
                GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").Visible = False

                'GunaDataGridViewLigneArticleCommande.Columns("DATE DE PEREMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End If

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

        End If


        GunaTextBoxArticle.Clear()
        GunaButtonAjouterLigne.Visible = False

        For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

            'montantGlobalAchat += GunaDataGridViewLigneArticleMagasin.Rows(i).Cells("PRIX ACHAT").Value * GunaDataGridViewLigneArticleMagasin.Rows(i).Cells("QUANTITE").Value
            'montantGlobalVente += GunaDataGridViewLigneArticleMagasin.Rows(i).Cells("PRIX VENTE").Value * GunaDataGridViewLigneArticleMagasin.Rows(i).Cells("QUANTITE").Value

        Next

        GunaTextBoxMontantHTGeneral.Text = Format(montantGlobalAchat, "#,##0")
        GunaTextBoxMontantTTCGeneral.Text = Format(montantGlobalVente, "#,##0")

        GunaTextBoxQuantite.Text = 1
        GunaTextBoxPrixVente.Text = 0
        GunaTextBoxAchat.Text = 0

        montantGlobalAchat = 0
        montantGlobalVente = 0

        GunaTextBoxSeuile.Text = 0
        GunaTextBoxEnStock.Text = 0
        GunaTextBoxCoutDuStock.Text = 0

        GunaTextBoxGrandeUniteDeCompatge.Clear()

        GunaTextBoxLecteurRFID.Clear()

        'GunaTextBoxLecteurRFID.Select()

    End Sub

    Private Sub GunaTextBoxLibelleBordereau_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxLibelleBordereau.TextChanged

        If Trim(GunaTextBoxLibelleBordereau.Text) = "" Then
            'GunaButtonValider.Visible = False
            GunaButtonEnregistrer.Visible = False

        Else
            'GunaButtonValider.Visible = True
            GunaButtonEnregistrer.Visible = True
            GunaButtonEnregistrer.Enabled = True
        End If

    End Sub

    Public Sub NewBonDeRequisition()

        GunaComboBoxTypeBordereau.Enabled = True


        If GlobalVariable.actualLanguageValue = 0 Then
            GunaLabelMagasinDeDestination.Text = "Receiving Store"

            GunaButtonEnregistrer.Text = "Emit"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelMagasinDeDestination.Text = "Magasin De Réception"

            GunaButtonEnregistrer.Text = "Emettre"

        End If

        'GunaComboBoxTypeBordereau.SelectedIndex = 0

        Functions.SiplifiedClearTextBox(Me)

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

        GunaTextBoxCoutDuStock.Text = 0

        GunaTextBoxQuantite.Text = 1

        permettreAjoutArticle()

        GunaButtonEnregistrer.Enabled = True

        montantGlobalAchat = 0
        montantGlobalVente = 0

        Dim econom As New Economat()
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim CODE_USER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

        GunaTextBoxTiers.Text = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        GunaTextBoxNomTiers.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Store Requisition" Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Market List" Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.list_du_marche Then

            If GlobalVariable.actualLanguageValue = 0 Then

                If Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Store Requisition" Then
                    INDICE = "SR"
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Market List" Then
                    INDICE = "ML"
                End If

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
                    INDICE = "BA"
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.list_du_marche Then
                    INDICE = "LM"
                End If

            End If

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", INDICE)

        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        NewBonDeRequisition()

    End Sub

    Private Sub GunaComboBoxMagasinSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxMagasinReception.SelectedIndexChanged

        If GunaComboBoxMagasinReception.SelectedIndex >= 0 Then

            Dim CODE_MAGASIN As String = GunaComboBoxMagasinReception.SelectedValue.ToString

            Dim magasinActuel As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

            If magasinActuel.Rows.Count > 0 Then
                GunaTextBoxSuivreArticleNonSuivi.Text = magasinActuel.Rows(0)("GESTION_PAR_LOT") 'POUR LE SUIVI DES MAGASINS NON SUIVI
            End If

        End If

    End Sub

    'ON VIDE LE CHAMP D'ARTICLE POUR FORCER UNE NOUVELLE SAISIE
    Private Sub GunaComboBoxMagasinDeDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxMagasinDeDestination.SelectedIndexChanged
        GunaTextBoxArticle.Clear()
    End Sub

    Private Sub GunaTextBoxQuantite_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxQuantite.TextChanged

        Dim prixArticle As Double = 0

        If Not Trim(GunaTextBoxCoutDuStock.Text) = "" And Not Trim(GunaTextBoxQuantite.Text) = "" Then
            prixArticle = Double.Parse(GunaTextBoxCoutDuStock.Text)
            'GunaTextBoxCoutDuStock.Text = Format(Double.Parse(GunaTextBoxQuantite.Text) * prixArticle, "#,##0")
        Else

        End If

    End Sub

    Private Sub GunaTextBoxCoutDuStock_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCoutDuStock.TextChanged

        'GunaTextBoxAchat.Text = GunaTextBoxCoutDuStock.Text * GunaTextBoxQuantite.Text
        GunaTextBoxAchat.Text = GunaTextBoxCoutDuStock.Text

    End Sub

    'AU CHANGEMENT D'UNE VALEUR DE CELLULE (QUANTITE / PU) ON MODIFIE LE PRIX TOTAL

    Private Sub GunaDataGridViewLigneArticleMagasin_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLigneArticleCommande.CellDoubleClick


        'MODICFICATION DU DATAGRID
        Dim econom As New Economat()

        If e.RowIndex >= 0 Then


            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonAjouterLigne.Text = "Edit"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterLigne.Text = "Modifier"
            End If

            GunaButtonAjouterLigne.Visible = True

            GunaTextBoxQuantite.Text = 1

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewLigneArticleCommande.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE CODE_ARTICLE=@CODE_ARTICLE ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim CODE_ARTICLE As String
            Dim QUANTITE As Double
            Dim PU As Double
            Dim UNITE_UTILISE As String

            If GlobalVariable.actualLanguageValue = 0 Then

                CODE_ARTICLE = row.Cells("CODE ARTICLE").Value.ToString
                QUANTITE = row.Cells("QUANTITY").Value
                PU = row.Cells("UNIT PRICE").Value
                UNITE_UTILISE = row.Cells("UNIT").Value

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                CODE_ARTICLE = row.Cells("CODE ARTICLE").Value.ToString
                QUANTITE = row.Cells("QUANTITE").Value
                PU = row.Cells("PRIX UNITAIRE").Value
                UNITE_UTILISE = row.Cells("UNITE").Value

            End If

            command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

            GunaTextBoxID_LIGNE_TEMP.Text = row.Cells("ID_LIGNE_BORDEREAU").Value

            adapter.SelectCommand = command

            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then

                GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")

                LabelQuantiteEnMagasinSource.Visible = False
                GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

                LabelQteEnMagasinDeDestination.Visible = False
                GunaComboBoxMagasinDeDestination.Visible = False

                GunaTextBoxAchat.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") 'PRIX D'ACHAT 
                GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0") 'COUT MOYEN UNITAIRE PONDERE
                GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxSeuile.Text = Format(Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT"), "#,##0.0")
                GunaTextBoxEnStock.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.0")
                GunaTextBoxCodeUniteComptage.Text = Article.Rows(0)("UNITE_COMPTAGE")

                GunaTextBoxCoutDuStock.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") ' PRIX UNITAIRE A L'ACHAT

                Dim unite As DataTable = Functions.getElementByCode(GunaTextBoxCodeUniteComptage.Text, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If unite.Rows.Count > 0 Then
                    gestionDesUnites(Article)
                End If

                GunaComboBoxUniteOuConso.SelectedItem = UNITE_UTILISE

                GunaTextBoxQuantite.Text = Format(QUANTITE, "#,##0.0")
                GunaTextBoxCoutDuStock.Text = Format(PU, "#,##0.0")
                'GunaTextBoxAchat.Text = PU
                GunaDataGridViewArticle.Visible = False

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid

            End If

            GunaDataGridViewArticle.Visible = False

        End If

    End Sub

    Public Sub gestionDesUnites(ByVal Article As DataTable)

        GunaComboBoxUniteOuConso.Items.Clear()

        Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")

        Dim pasDeConso As Boolean = True

        Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

        If unite.Rows.Count > 0 Then

            GunaComboBoxUniteOuConso.Items.Add(unite.Rows(0)("GRANDE_UNITE"))

            If unite.Rows(0)("VALEUR_NUMERIQUE") > 1 Then
                GunaComboBoxUniteOuConso.Items.Add(unite.Rows(0)("PETITE_UNITE"))
            End If

            GunaComboBoxUniteOuConso.SelectedItem = unite.Rows(0)("GRANDE_UNITE")

        End If

    End Sub

    Private Sub GunaComboBoxUniteOuConso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUniteOuConso.SelectedIndexChanged

        Dim CODE_ARTICLE = GunaTextBoxCodeArticle.Text

        Dim article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

        If article.Rows.Count > 0 Then

            Dim econom As New Economat()

            Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
            Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

            Dim QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)

            Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

            Dim PETITE_UNITE As String = ""
            Dim GRANDE_UNITE As String = ""

            '1- CHANGER LES QUANTITES EN STOCK PAR APPOORT A L'UNITE AFFICHEE.
            '2- MODIFIER LE PRIX PAR APPORT A LA QUANTITE AFFICHEE.
            '3- ENREGISTRER LE NOM DE L'UNITE DE DESTOCKAGE.

            'GESTION DE LA PETITE UNITE

            Dim UNITE_COMPTAGE As String = article.Rows(0)("UNITE_COMPTAGE")
            Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")
            Dim VALEUR_DE_CONVERSION As Double = 1

            If unite.Rows.Count > 0 Then

                PETITE_UNITE = unite.Rows(0)("PETITE_UNITE")
                GRANDE_UNITE = unite.Rows(0)("GRANDE_UNITE")
                VALEUR_DE_CONVERSION = unite.Rows(0)("VALEUR_NUMERIQUE")

            End If

            If GunaComboBoxUniteOuConso.SelectedIndex >= 0 Then

                Dim LIBELLE_UNITE As String = GunaComboBoxUniteOuConso.SelectedItem

                If LIBELLE_UNITE = PETITE_UNITE Then

                    GunaTextBoxEnStock.Text = Format(article.Rows(0)("QUANTITE") * VALEUR_DE_CONVERSION, "#,##0.00")
                    GunaTextBoxSeuile.Text = Format(article.Rows(0)("SEUIL_REAPPROVISIONNEMENT") * VALEUR_DE_CONVERSION, "#,##0.0")
                    GunaTextBoxCoutDuStock.Text = Format(article.Rows(0)("COUT_U_MOYEN_PONDERE") / VALEUR_DE_CONVERSION, "#,##0.00")
                    GunaTextBoxPrixVente.Text = Format(article.Rows(0)("PRIX_VENTE_HT") / VALEUR_DE_CONVERSION, "#,##0.0")

                    Label2.Visible = False
                    GunaTextBoxQtePetiteUnite.Visible = False

                    Label14.Text = unite.Rows(0)("PETITE_UNITE")

                ElseIf LIBELLE_UNITE = GRANDE_UNITE Then

                    GunaTextBoxEnStock.Text = Format(article.Rows(0)("QUANTITE"), "#,##0.00")
                    GunaTextBoxSeuile.Text = Format(article.Rows(0)("SEUIL_REAPPROVISIONNEMENT"), "#,##0.00")
                    GunaTextBoxCoutDuStock.Text = Format(article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.00")
                    GunaTextBoxPrixVente.Text = Format(article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0")

                    If VALEUR_DE_CONVERSION > 1 Then

                        Dim nombre As Double = GunaTextBoxEnStock.Text
                        Dim partieDecimal As Double = retentionDeLaPartieDecimal(nombre)

                        Label2.Visible = True
                        GunaTextBoxQtePetiteUnite.Visible = True

                        GunaTextBoxQtePetiteUnite.Text = Format(partieDecimal * VALEUR_DE_CONVERSION, "#,##0")

                        GunaTextBoxEnStock.Text = Double.Parse(GunaTextBoxEnStock.Text) - partieDecimal

                        Label14.Text = unite.Rows(0)("GRANDE_UNITE")

                        Label2.Text = unite.Rows(0)("PETITE_UNITE")

                    End If

                End If

            End If

        End If

    End Sub

    'ON DETERMINE SI LA GRANDE UNITE CONTIENT DES CHIFFRES AVIRGULE

    Public Function retentionDeLaPartieDecimal(ByVal nombre As Double) As Double

        Dim partieDecimal As Double = 0

        Dim IntegerPart As Integer = Int(nombre)
        Dim DecimalPart As Double = nombre - IntegerPart

        Return DecimalPart

    End Function

    Public Function retentionDeLaPartieDecimalBoolean(ByVal nombre As Double) As Boolean

        Dim partieDecimal As Double = 0

        Dim IntegerPart As Integer = Int(nombre)
        Dim DecimalPart As Double = nombre - IntegerPart

        Return DecimalPart

        If DecimalPart = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub SupprimerToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem1.Click

        Dim econom As New Economat()

        If GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then

            Dim DeleteRow As Boolean = False

            Dim rowToDelete As String = ""

            If Not GunaDataGridViewLigneArticleCommande.CurrentRow.Cells("CODE ARTICLE").Value.ToString Is Nothing Then

                If rowToDelete = "" Then
                    rowToDelete = GunaDataGridViewLigneArticleCommande.CurrentRow.Cells("CODE ARTICLE").Value.ToString
                End If

            End If

            Dim dialog As DialogResult

            Dim articleToDelete As DataTable = Functions.getElementByCode(rowToDelete, "article", "CODE_ARTICLE")

            Dim nomArticle As String = ""

            If articleToDelete.Rows.Count > 0 Then
                nomArticle = articleToDelete.Rows(0)("DESIGNATION_FR")
            End If

            If GlobalVariable.actualLanguageValue = 0 Then
                lanaguageMessage = "Do you want to remove the item " & nomArticle
                lanaguageTitle = "Annuler"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                lanaguageMessage = "Voulez-vous vraiment retirer l'article " & nomArticle
                lanaguageTitle = "Annuler"
            End If

            dialog = MessageBox.Show(lanaguageMessage, lanaguageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                DeleteRow = True
            End If

            If DeleteRow Then

                Dim CODE_ARTICLE As String = rowToDelete
                Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                Dim articleToTransfert As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_ARTICLE, "bordereau_ligne_temp", "CODE_ARTICLE", CODE_USER, "CODE_USER")

                If articleToTransfert.Rows.Count > 0 Then

                    'AVANT SUPPRESION ON MIGRE VERS LA TABLE DES ANNULEES

                    For i = 0 To articleToTransfert.Rows.Count - 1

                        Dim DESIGNATION = articleToTransfert.Rows(i)("DESIGNATION")
                        Dim CODE_ARTICLE_ = articleToTransfert.Rows(i)("CODE_ARTICLE")
                        Dim QUANTITE = articleToTransfert.Rows(i)("QUANTITE")
                        Dim EN_STOCK = articleToTransfert.Rows(i)("EN_STOCK")
                        Dim DATE_PEREMPTION = articleToTransfert.Rows(i)("DATE_PEREMPTION")
                        Dim PRIX_VENTE = articleToTransfert.Rows(i)("PRIX_VENTE")
                        Dim PRIX_ACHAT = articleToTransfert.Rows(i)("PRIX_ACHAT")
                        Dim COUT_DU_STOCK = articleToTransfert.Rows(i)("COUT_DU_STOCK")
                        Dim CODE_BORDEREAUX = articleToTransfert.Rows(i)("CODE_BORDEREAU")
                        Dim CODE_AGENCE = articleToTransfert.Rows(i)("CODE_AGENCE")

                        econom.insertLigneBordereauAnnuler(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, CODE_USER, COUT_DU_STOCK)

                    Next

                End If

                'SUPPRESION DE LA LIGNE DE COMMANDE DANS LIGNE_BORDEREAU_TEMP
                Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "bordereau_ligne_temp", "CODE_ARTICLE", "CODE_USER", CODE_USER)

                'rafraichissement du dataGrid

                GunaDataGridViewLigneArticleCommande.Columns.Clear()

                GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)

                If GlobalVariable.actualLanguageValue = 0 Then

                    GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Format = "#,##0"

                    GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Format = "#,##0"

                    'GunaDataGridViewLigneArticleMagasin.Columns("PRIX UNITAIRE").Visible = False
                    GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

                    'GunaDataGridViewLigneArticleMagasin.Columns("DATE DE PEREMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Format = "#,##0"

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Format = "#,##0"

                    'GunaDataGridViewLigneArticleMagasin.Columns("PRIX UNITAIRE").Visible = False
                    GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").Visible = False

                    'GunaDataGridViewLigneArticleMagasin.Columns("DATE DE PEREMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                End If

                GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

                GunaTextBoxArticle.Clear()
                GunaButtonAjouterLigne.Visible = False

                For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

                    If GlobalVariable.actualLanguageValue = 0 Then

                        montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value

                        montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value

                    ElseIf GlobalVariable.actualLanguageValue = 1 Then

                        montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value

                        montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value

                    End If

                Next

                GunaTextBoxMontantHTGeneral.Text = Format(montantGlobalAchat, "#,##0")

                GunaTextBoxMontantTTCGeneral.Text = Format(montantGlobalVente, "#,##0")

            End If

        End If

    End Sub

    Dim lanaguageMessage As String = ""
    Dim lanaguageTitle As String = ""

    Private Sub GunaDateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePicker1.ValueChanged

        GunaDateTimePicker2.Value = GunaDateTimePicker1.Value.AddDays(7)
        Dim dateDu As Date = GunaDateTimePicker1.Value.ToShortDateString

        GunaDataGridViewPrevisions.Columns.Clear()

        Dim j0 As Integer = Functions.nombreDeClientEnChambre(dateDu.AddDays(0), "chambre")
        Dim j1 As Integer = Functions.nombreDeClientEnChambre(dateDu.AddDays(1), "chambre")
        Dim j2 As Integer = Functions.nombreDeClientEnChambre(dateDu.AddDays(2), "chambre")
        Dim j3 As Integer = Functions.nombreDeClientEnChambre(dateDu.AddDays(3), "chambre")
        Dim j4 As Integer = Functions.nombreDeClientEnChambre(dateDu.AddDays(4), "chambre")
        Dim j5 As Integer = Functions.nombreDeClientEnChambre(dateDu.AddDays(5), "chambre")
        Dim j6 As Integer = Functions.nombreDeClientEnChambre(dateDu.AddDays(6), "chambre")
        Dim j7 As Integer = Functions.nombreDeClientEnChambre(dateDu.AddDays(7), "chambre")

        For i = 0 To 7
            GunaDataGridViewPrevisions.Columns.Add(dateDu.AddDays(i), dateDu.AddDays(i))
        Next

        GunaLabelNbrePax.Text = j0 + j1 + j2 + j3 + j4 + j5 + j6 + j7

        GunaDataGridViewPrevisions.Rows.Add(j0, j1, j2, j3, j4, j5, j6, j7)

        GunaDataGridViewPrevisions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub RetirerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetirerToolStripMenuItem.Click

        Dim dialog As DialogResult
        Dim DeleteRow As Boolean = False

        Dim NameOfrowToDelete As String = GunaDataGridViewLigneArticleCommande.CurrentRow.Cells("DESIGNATION").Value.ToString

        Dim ID_LIGNE_BORDEREAU As Integer = GunaDataGridViewLigneArticleCommande.CurrentRow.Cells("ID_LIGNE_BORDEREAU").Value

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "Do you really want to remove the item " & NameOfrowToDelete
            languageTitle = "Item delete"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Voulez-vous vraiment retirer l'article " & NameOfrowToDelete
            languageTitle = "Suppression d'article"
        End If

        dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If Not dialog = DialogResult.No Then
            DeleteRow = True
        End If

        If DeleteRow Then

            'Dim articleExistant As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "CODE_ARTICLE", NUMERO_BLOC_NOTE, "NUMERO_BLOC_NOTE")
            Functions.DeleteElementByCode(ID_LIGNE_BORDEREAU, "bordereau_ligne_temp", "ID_LIGNE_BORDEREAU")

            afficherCommande()

        End If
    End Sub

    '---------------------------------------------------- FROM END -------------------------------------------------------------------------

End Class