Imports MySql.Data.MySqlClient
Imports System.IO

Public Class ArticleForm

    'Dim connect As New DataBaseManipulation()

    Private Sub ArticleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        informationUtiles()



        If GlobalVariable.typeArticle = "" Then
            GlobalVariable.typeArticle = "article"
        End If

        GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture_temp", "")

        listeDesFichesTechniques()

        If GlobalVariable.typeArticle = "article" Then
            GunaCheckBoxAlaCarte.Visible = True
            GunaLabel116.Text = "CODE ARTICLE / NOM DE L'ARTICLE"
            GunaCheckBoxVisibiliteAuBar.Visible = True
            GunaCheckBoxBoisson.Visible = True
            GunaComboBoxArticleMatiere.SelectedIndex = 0
        Else
            GunaCheckBoxAlaCarte.Visible = False
            GunaLabel116.Text = "CODE MATIERE / NOM DE LA MATIERE"
            GunaCheckBoxVisibiliteAuBar.Visible = False
            GunaCheckBoxVisibiliteAuBar.Checked = False
            GunaCheckBoxBoisson.Checked = False
            GunaCheckBoxBoisson.Visible = False
            GunaComboBoxArticleMatiere.SelectedIndex = 1
        End If

        If GlobalVariable.typeArticle = "article" Then
            GunaCheckBoxArticleMatiere.Checked = False
        ElseIf GlobalVariable.typeArticle = "matiere" Then
            GunaCheckBoxArticleMatiere.Checked = False
        End If

        'Charging artilce family into combobox
        autoLoadArticleFamilyFromDatabaseIntoCombo()

        uniteDeConsommation()

        If GunaComboBoxSuiviStock.Items.Count > 0 Then
            GunaComboBoxSuiviStock.SelectedIndex = 0
        End If

        Dim UNITE_COMPTAGE As String = "34713"

        If GunaComboBoxUniteDeCompatage.SelectedIndex >= 0 Then
            GunaComboBoxUniteDeCompatage.SelectedValue = UNITE_COMPTAGE.ToUpper() 'UNITE
        End If

        If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then
            GunaCheckBoxRetablirLesQuantie.Visible = True
        Else
            GunaCheckBoxRetablirLesQuantie.Visible = False
        End If

    End Sub

    Private Sub ficheTechniqueListe()

        Dim articleFiche As New Article()

        GunaDataGridViewFicheTechnique.DataSource = articleFiche.ListeDesFichesTechnique()

        'GunaDataGridViewFicheTechnique.Columns("LIBELLE FICHE").DefaultCellStyle.Format = "#,##0"

        GunaDataGridViewFicheTechnique.Columns("PRIX DE VENTE").DefaultCellStyle.Format = "#,##0"
        GunaDataGridViewFicheTechnique.Columns("PRIX DE VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GunaDataGridViewFicheTechnique.Columns("MARGE BRUTE").DefaultCellStyle.Format = "#,##0"
        GunaDataGridViewFicheTechnique.Columns("MARGE BRUTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        GunaDataGridViewFicheTechnique.Columns("NOMBRE DE PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        GunaDataGridViewFicheTechnique.Columns("COEF DE MARGE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        GunaDataGridViewFicheTechnique.Columns("CODE FICHE").Visible = False
        GunaDataGridViewFicheTechnique.Columns("ARTICLE").Visible = False
        GunaDataGridViewFicheTechnique.Columns("NOMBRE DE PORTION").Visible = False


    End Sub

    Private Sub listeDesFichesTechniques()

        'Si on veut afficher la liste des fiches techniques
        If Not Trim(GlobalVariable.ficheTechnique) = "" Then

            ficheTechniqueListe()

            TabControlArticle.SelectedIndex = 3

        Else
            TabControlArticle.SelectedIndex = 1
        End If

    End Sub


    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Close()
        GlobalVariable.ficheTechnique = ""
    End Sub

    'Annuler
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
        GlobalVariable.ficheTechnique = ""
    End Sub

    Private Sub autoLoadArticleFamilyFromDatabaseIntoCombo()

        Dim tableFamille As DataTable = Functions.allTableFieldsOrganised("famille", "LIBELLE_FAMILLE") ' POINT DE VENTE

        If (tableFamille.Rows.Count > 0) Then

            GunaComboBoxTypeArticle.DataSource = tableFamille
            'GunaComboBoxTypeArticle.ValueMember = "CODE_FAMILLE"
            GunaComboBoxTypeArticle.ValueMember = "LIBELLE_FAMILLE"
            GunaComboBoxTypeArticle.DisplayMember = "LIBELLE_FAMILLE"

        End If

        'Dim uniteDeComptage As DataTable = Functions.allTableFields("unite_comptage")
        Dim uniteDeComptage As DataTable = Functions.allTableFieldsOnConditionOrganised("unite_comptage", "TYPE", "Autres", "GRANDE_UNITE")

        If (uniteDeComptage.Rows.Count > 0) Then

            GunaComboBoxUniteDeCompatage.DataSource = uniteDeComptage
            'GunaComboBoxUniteDeCompatage.ValueMember = "CODE_FAMILLE"
            GunaComboBoxUniteDeCompatage.ValueMember = "CODE_UNITE_DE_COMPTAGE"
            GunaComboBoxUniteDeCompatage.DisplayMember = "GRANDE_UNITE"

        End If

        Dim tableFicheTechnique As DataTable = Functions.allTableFieldsOrganised("fiche_technique", "LIBELLE_FICHE")

        If (tableFicheTechnique.Rows.Count > 0) Then

            GunaComboBoxFicheTechnique.DataSource = tableFicheTechnique
            'GunaComboBoxFicheTechnique.ValueMember = "CODE_FAMILLE"
            GunaComboBoxFicheTechnique.ValueMember = "CODE_FICHE_TECHNIQUE"
            GunaComboBoxFicheTechnique.DisplayMember = "LIBELLE_FICHE"

        End If

        'connect.closeConnection()

        Dim categorieArticle As DataTable = Functions.allTableFieldsOrganised("categorie_article", "LIBELLE_FAMILLE") 'CATEGORIE ARTICLE

        If (categorieArticle.Rows.Count > 0) Then

            'PARENT DE NIVEAU 1 : CATEGORIE
            GunaComboBoxCategorieArticle.DataSource = categorieArticle
            'GunaComboBoxSousSousFamillle.ValueMember = "CODE_FAMILLE"
            GunaComboBoxCategorieArticle.ValueMember = "LIBELLE_FAMILLE"
            GunaComboBoxCategorieArticle.DisplayMember = "LIBELLE_FAMILLE"

            GunaComboBoxFiltreArticle.DataSource = categorieArticle
            'GunaComboBoxSousSousFamillle.ValueMember = "CODE_FAMILLE"
            GunaComboBoxFiltreArticle.ValueMember = "LIBELLE_FAMILLE"
            GunaComboBoxFiltreArticle.DisplayMember = "LIBELLE_FAMILLE"

        End If

        GunaComboBoxSousFamilleArticle.SelectedIndex = -1
        GunaComboBoxCategorieArticle.SelectedIndex = -1
        GunaComboBoxLastLevelArticle.SelectedIndex = -1
        GunaComboBoxFicheTechnique.SelectedIndex = -1
        'GunaComboBoxUniteDeCompatage.SelectedIndex = -1

    End Sub

    'LIste des Articles
    Public Sub ArticleList()

        Dim CODE_FAMILLE As String = ""

        If GunaComboBoxFiltreArticle.SelectedIndex >= 0 Then
            CODE_FAMILLE = GunaComboBoxFiltreArticle.SelectedValue.ToString
        End If
        'REFRESHING information from database for instant visualisation 
        Dim query As String = "SELECT CODE_ARTICLE AS 'CODE', DESIGNATION_FR AS 'DESIGNATION', DESCRIPTION, COUT_U_MOYEN_PONDERE As 'PRIX ACHAT HT', PRIX_ACHAT_HT As 'COUT MOYEN', PRIX_VENTE_HT As 'PRIX VENTE HT', PRIX_VENTE1_HT AS 'PRIX VENTE 2', PRIX_VENTE2_HT AS 'PRIX VENTE 3', PRIX_VENTE3_HT AS 'PRIX VENTE 4' , QUANTITE FROM article WHERE TYPE=@TYPE ORDER BY DESIGNATION_FR ASC"

        If GunaCheckBoxFiltreArticleCategorie.Checked Then
            query = "SELECT CODE_ARTICLE AS 'CODE', DESIGNATION_FR AS 'DESIGNATION', DESCRIPTION, COUT_U_MOYEN_PONDERE As 'PRIX ACHAT HT', PRIX_ACHAT_HT As 'COUT MOYEN', PRIX_VENTE_HT As 'PRIX VENTE HT', PRIX_VENTE1_HT AS 'PRIX VENTE 2', PRIX_VENTE2_HT AS 'PRIX VENTE 3', PRIX_VENTE3_HT AS 'PRIX VENTE 4' , QUANTITE FROM article WHERE TYPE=@TYPE AND CODE_FAMILLE=@CODE_FAMILLE ORDER BY DESIGNATION_FR ASC"
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeArticle
        command.Parameters.Add("@CODE_FAMILLE", MySqlDbType.VarChar).Value = CODE_FAMILLE
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaButtonAfficherLesFacturesEtReglement.Visible = True

            GunaLabelNombreClient.Visible = True
            GunaLabelNombreClient.Text = table.Rows.Count

            GunaDataGridViewArticle.DataSource = table
            GunaDataGridViewArticle.Columns("PRIX ACHAT HT").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewArticle.Columns("PRIX VENTE HT").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewArticle.Columns("COUT MOYEN").DefaultCellStyle.Format = "#,##0"

            GunaDataGridViewArticle.Columns("PRIX ACHAT HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewArticle.Columns("PRIX VENTE HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewArticle.Columns("COUT MOYEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewArticle.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewArticle.Columns("QUANTITE").DefaultCellStyle.Format = "n2"

            GunaDataGridViewArticle.Columns("PRIX VENTE 2").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewArticle.Columns("PRIX VENTE 2").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewArticle.Columns("PRIX VENTE 2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewArticle.Columns("PRIX VENTE 3").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewArticle.Columns("PRIX VENTE 3").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewArticle.Columns("PRIX VENTE 3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewArticle.Columns("PRIX VENTE 4").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewArticle.Columns("PRIX VENTE 4").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewArticle.Columns("PRIX VENTE 4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewArticle.Columns("CODE").Visible = False

        Else

            GunaDataGridViewArticle.Columns.Clear()
            GunaLabelNombreClient.Visible = False
            GunaButtonAfficherLesFacturesEtReglement.Visible = False

        End If

    End Sub

    'Enregistrer
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_ARTICLE As String = Functions.GeneratingRandomCode("article", "")

        Dim REFERENCE As String = ""
        Dim CODE_BARRE As String = ""

        If Trim(GunaTextBoxCodeBarre.Text) = "" Then
            CODE_BARRE = "-"
        Else
            CODE_BARRE = Trim(GunaTextBoxCodeBarre.Text)
        End If

        Dim TYPE_

        If GunaComboBoxArticleMatiere.SelectedIndex >= 0 Then

            If GunaComboBoxArticleMatiere.SelectedIndex = 0 Then
                TYPE_ = "article"
            ElseIf GunaComboBoxArticleMatiere.SelectedIndex = 1 Then
                TYPE_ = "matiere"
            End If

        End If

        Dim DESIGNATION_FR As String = Trim(GunaTextBoxDesignation.Text)
        Dim DESIGNATION_EN As String = ""
        Dim DESCRIPTION As String = ""
        Dim CODE_GROUPE_ARTICLE As String = ""

        Dim CODE_FAMILLE As String = ""
        If GunaComboBoxCategorieArticle.SelectedIndex >= 0 Then
            CODE_FAMILLE = GunaComboBoxCategorieArticle.SelectedValue 'CATEGORIE D'ARTICLE 
        End If

        ' TAUX_EXONERATION_TVA : SEUIL_REAPPROVISIONNEMENT_PETIT_MAGASIN

        Dim CODE_SOUS_FAMILLE As String = ""
        If GunaComboBoxSousFamilleArticle.SelectedIndex >= 0 Then
            CODE_SOUS_FAMILLE = GunaComboBoxSousFamilleArticle.SelectedValue 'FAMILLE
        End If

        Dim CODE_UNITE_DE_COMPTAGE As String = ""
        If GunaComboBoxUniteDeCompatage.SelectedIndex >= 0 Then
            CODE_UNITE_DE_COMPTAGE = GunaComboBoxUniteDeCompatage.SelectedValue 'UNITE DE COMPTAGE
        End If

        Dim CODE_SOUS_SOUS_FAMILLE As String = ""
        If GunaComboBoxLastLevelArticle.SelectedIndex >= 0 Then
            CODE_SOUS_SOUS_FAMILLE = GunaComboBoxLastLevelArticle.SelectedValue 'SOUS FAMILLE
        End If

        Dim TYPE_ARTICLE As String = ""
        If GunaComboBoxTypeArticle.SelectedIndex >= 0 Then
            TYPE_ARTICLE = GunaComboBoxTypeArticle.SelectedValue ''Equivalent de la sous famille : point de vente
        End If

        Dim METHODE_SUIVI_STOCK As String = Trim(GunaComboBoxSuiviStock.SelectedItem)

        Dim CONDITIONNEMENT As String = ""
        Dim SEUIL_PRIX_VENTE_HT As Double = 0

        Dim PRIX_ACHAT_HT As Double = 0 'C'EST LE COUT MOYEN UNITAIRE PONDERE
        Double.TryParse(GunaTextBoxCUMP.Text, PRIX_ACHAT_HT)

        Dim COUT_U_MOYEN_PONDERE As Double = 0

        If Not GunaTextBoxPrixAchat.Text = "" Then
            COUT_U_MOYEN_PONDERE = Double.Parse(GunaTextBoxPrixAchat.Text) 'C'EST LE PRIX D'ACHAT
        End If

        Dim PRIX_ACHAT_TTC As Double = 0

        Dim PRIX_VENTE_HT As Double = 0
        If Not Trim(GunaTextBoxVenteHT.Text).Equals("") Then
            Double.TryParse(GunaTextBoxVenteHT.Text, PRIX_VENTE_HT)
        End If

        Dim QUANTITE As Double = 0 'USED A STOCK QUANTITY

        If Not Trim(GunaTextBoxStock.Text).Equals("") Then
            QUANTITE = GunaTextBoxStock.Text
        End If

        Dim PRIX_VENTE_TTC As Double = 0
        Dim PRIX_VENTE1_HT As Double = 0

        If Not Trim(GunaTextBoxVenteHT2.Text).Equals("") Then
            Double.TryParse(GunaTextBoxVenteHT2.Text, PRIX_VENTE1_HT)
        End If

        Dim PRIX_VENTE1_TTC As Double = 0
        Dim PRIX_VENTE2_HT As Double = 0

        If Not Trim(GunaTextBoxVenteHT3.Text).Equals("") Then
            Double.TryParse(GunaTextBoxVenteHT3.Text, PRIX_VENTE2_HT)
        End If
        Dim PRIX_VENTE2_TTC As Double = 0

        Dim PRIX_VENTE3_HT As Double = 0
        If Not Trim(GunaTextBoxVenteHT4.Text).Equals("") Then
            Double.TryParse(GunaTextBoxVenteHT4.Text, PRIX_VENTE3_HT)
        End If

        Dim PRIX_VENTE3_TTC As Double = 0
        Dim PRIX_VENTE4_HT As Double = 0
        Dim PRIX_VENTE4_TTC As Double = 0
        Dim PRIX_VENTE5_HT As Double = 0
        Dim PRIX_VENTE5_TTC As Double = 0
        Dim PRIX_VENTE6_HT As Double = 0
        Dim PRIX_VENTE6_TTC As Double = 0
        Dim PRIX_VENTE7_HT As Double = 0
        Dim PRIX_VENTE7_TTC As Double = 0
        Dim PRIX_VENTE8_HT As Double = 0
        Dim PRIX_VENTE8_TTC As Double = 0
        Dim PRIX_VENTE9_HT As Double = 0
        Dim POURCENTAGE_REMISE As Double = 0

        Dim SEUIL_REAPPROVISIONNEMENT_PETIT_MAGASIN As Double = 0

        If Trim(GunaTextBoxStockReaProPetitMagasin.Text) = "" Then
            GunaTextBoxStockReaProPetitMagasin.Text = 0
        End If

        Double.TryParse(GunaTextBoxStockReaProPetitMagasin.Text, SEUIL_REAPPROVISIONNEMENT_PETIT_MAGASIN)

        Dim SEUIL_REAPPROVISIONNEMENT As Double = 0
        If Trim(GunaTextBoxStockReapproGrandMagasin.Text) = "" Then
            GunaTextBoxStockReapproGrandMagasin.Text = 0
        End If

        Double.TryParse(GunaTextBoxStockReapproGrandMagasin.Text, SEUIL_REAPPROVISIONNEMENT)

        Dim NUMERO_SERIE As String = GunaTextBoxNumSerie.Text
        Dim ARTICLE_COMPOSE As String = ""
        Dim ARTICLE_LIE As String = ""
        Dim ARTICLE_RECONDITIONNABLE As String = ""
        Dim APPARAIT_SUR_FICHE_CLIENT As String = ""
        Dim ARTICLE_PERISSABLE As String = ""
        Dim ARTICLE_GERE_PAR_LOT As String = ""
        Dim DATE_DEBUT_PROMOTION As Date = GlobalVariable.DateDeTravail
        Dim POURCENTAGE_REMISE_PROMOTION As Double = 0
        Dim DATE_FIN_PROMOTION As Date = GlobalVariable.DateDeTravail
        Dim CHEMIN_PHOTO As String = ""
        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.codeUser
        Dim DATE_MODIFICATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_MODIF As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim ARTICLE_A_REMISE As String = ""
        Dim CODE_CLE As String = ""

        Dim DELEGUE As String = ""
        Dim SEUIL_PRIX_VENTE_TTC As Double = 0
        Dim TX_LIMIT As Double = 0
        Dim DAILY_LIMIT As Double = 0
        Dim TAUX_TVA As Double = 0
        Dim SPECIALITE_ARTICLE As String = ""
        Dim ARTICLE_MULTIPRIX As String = ""
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim TYPE As String = GlobalVariable.typeArticle

        If GunaComboBoxArticleMatiere.SelectedIndex >= 0 Then
            If GunaComboBoxArticleMatiere.SelectedIndex = 0 Then
                TYPE = "article"
            Else
                TYPE = "matiere"
            End If
        End If

        Dim BOISSON As Integer = 0
        Dim VISIBLE As Integer = 0

        If GunaCheckBoxVisibiliteAuBar.Checked Then
            VISIBLE = 1
        End If

        If GunaCheckBoxBoisson.Checked Then
            BOISSON = 1
        Else

        End If

        Dim CONTENANCE As Double = 0

        If Not GunaTextBoxContenance.Text = "" Then
            CONTENANCE = Double.Parse(GunaTextBoxContenance.Text)
        End If

        'UN PRODUIT A LA CARTE : CARTE = 1 EST UN ARTICLE DONT LES MATIERES SONT DESTOCKER A LA VENTE UNIQUEMENT
        'UN PRODUIT PAS A LA CARTE : CARTE = 0 EST UN ARTICLEDONT LES MATIERES SONT DESTOCKER A LA PREPARATION

        Dim CARTE As Integer = 0

        If GunaCheckBoxAlaCarte.Checked Then

            CARTE = 1

            If GunaComboBoxFicheTechnique.SelectedIndex >= 0 Then
                CODE_CLE = GunaComboBoxFicheTechnique.SelectedValue.ToString 'CODE_CLE USED AS CODE_FICHE_TECHNIQUE
            End If

        End If

        Dim CODE_CONSO = GunaComboBoxUniteDeConsommation.SelectedValue

        Dim PRIX_CONSO = Double.Parse(GunaTextBoxPrixConso1.Text)
        Dim PRIX_CONSO2 = Double.Parse(GunaTextBoxPrixConso2.Text)
        Dim PRIX_CONSO3 = Double.Parse(GunaTextBoxPrixConso3.Text)
        Dim PRIX_CONSO4 = Double.Parse(GunaTextBoxPrixConso4.Text)

        If BOISSON = 0 Then
            CODE_CONSO = ""
            PRIX_CONSO = 0
            PRIX_CONSO2 = 0
            PRIX_CONSO3 = 0
            PRIX_CONSO4 = 0
        End If

        Dim article As New Article()

        If Trim(GunaButtonEnregistrer.Text) = "Sauvegarder" Then

            CODE_ARTICLE = GunaTextBoxCodeArticle.Text

            'TAUX_EXONERATION_TVA = SEUIL_REAPPROVISIONNEMENT_PETIT_MAGASIN

            If article.updateArticle(CODE_ARTICLE, REFERENCE, CODE_BARRE, DESIGNATION_FR, DESIGNATION_EN, DESCRIPTION, CODE_GROUPE_ARTICLE, CODE_FAMILLE, CODE_SOUS_FAMILLE, CODE_SOUS_SOUS_FAMILLE, METHODE_SUIVI_STOCK, TYPE_ARTICLE, CONDITIONNEMENT, SEUIL_PRIX_VENTE_HT, PRIX_ACHAT_HT, COUT_U_MOYEN_PONDERE, PRIX_ACHAT_TTC, PRIX_VENTE_HT, PRIX_VENTE_TTC, PRIX_VENTE1_HT, PRIX_VENTE1_TTC, PRIX_VENTE2_HT, PRIX_VENTE2_TTC, PRIX_VENTE3_HT, PRIX_VENTE3_TTC, PRIX_VENTE4_HT, PRIX_VENTE4_TTC, PRIX_VENTE5_HT, PRIX_VENTE5_TTC, PRIX_VENTE6_HT, PRIX_VENTE6_TTC, PRIX_VENTE7_HT, PRIX_VENTE7_TTC, PRIX_VENTE8_HT, PRIX_VENTE8_TTC, PRIX_VENTE9_HT, QUANTITE, POURCENTAGE_REMISE, SEUIL_REAPPROVISIONNEMENT_PETIT_MAGASIN, SEUIL_REAPPROVISIONNEMENT, NUMERO_SERIE, ARTICLE_COMPOSE, ARTICLE_LIE, ARTICLE_RECONDITIONNABLE, APPARAIT_SUR_FICHE_CLIENT, ARTICLE_PERISSABLE, ARTICLE_GERE_PAR_LOT, DATE_DEBUT_PROMOTION, POURCENTAGE_REMISE_PROMOTION, DATE_FIN_PROMOTION, CHEMIN_PHOTO, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, ARTICLE_A_REMISE, CODE_CLE, DELEGUE, SEUIL_PRIX_VENTE_TTC, TX_LIMIT, DAILY_LIMIT, TAUX_TVA, SPECIALITE_ARTICLE, ARTICLE_MULTIPRIX, CODE_AGENCE, CODE_UNITE_DE_COMPTAGE, CARTE, CODE_CONSO, PRIX_CONSO, CONTENANCE, BOISSON, PRIX_CONSO2, PRIX_CONSO3, PRIX_CONSO4, VISIBLE, TYPE_) Then

                If GlobalVariable.typeArticle = "article" Then
                    MessageBox.Show("Article mise à jour avec succès", "Mise à jour d'Article", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Matière mise à jour avec succès", "Mise à jour de Matière", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Dim QTE_STOCK As Double = 0

                If Not Trim(GunaTextBoxStock.Text) = "" Then

                    If BOISSON = 1 Then

                        '------------------------------------------------------------
                        Dim nombreDeConso = GunaTextBoxStockEnConso.Text
                        Dim valeurConversion As Double = Double.Parse(GunaTextBoxValeurUniteConso.Text)
                        Dim nombreDeConsoTotal As Integer = nombreDeConso + Math.Floor(CONTENANCE / valeurConversion) * QUANTITE

                        QTE_STOCK = nombreDeConsoTotal 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS
                        '------------------------------------------------------------

                    End If

                End If

                article.updateQuantite(CODE_ARTICLE, QTE_STOCK)

            End If

            'TabControlArticle.SelectedIndex = 1

            GunaButtonEnregistrer.Text = "Enregistrer"

        Else

            'verifyfields function
            If (True) Then
                'check existence
                If Not Functions.entryCodeExists(CODE_ARTICLE, "article", "CODE_ARTICLE") Then
                    If article.insertArticle(CODE_ARTICLE, REFERENCE, CODE_BARRE, DESIGNATION_FR, DESIGNATION_EN, DESCRIPTION, CODE_GROUPE_ARTICLE, CODE_FAMILLE, CODE_SOUS_FAMILLE, CODE_SOUS_SOUS_FAMILLE, METHODE_SUIVI_STOCK, TYPE_ARTICLE, CONDITIONNEMENT, SEUIL_PRIX_VENTE_HT, PRIX_ACHAT_HT, COUT_U_MOYEN_PONDERE, PRIX_ACHAT_TTC, PRIX_VENTE_HT, PRIX_VENTE_TTC, PRIX_VENTE1_HT, PRIX_VENTE1_TTC, PRIX_VENTE2_HT, PRIX_VENTE2_TTC, PRIX_VENTE3_HT, PRIX_VENTE3_TTC, PRIX_VENTE4_HT, PRIX_VENTE4_TTC, PRIX_VENTE5_HT, PRIX_VENTE5_TTC, PRIX_VENTE6_HT, PRIX_VENTE6_TTC, PRIX_VENTE7_HT, PRIX_VENTE7_TTC, PRIX_VENTE8_HT, PRIX_VENTE8_TTC, PRIX_VENTE9_HT, QUANTITE, POURCENTAGE_REMISE, SEUIL_REAPPROVISIONNEMENT_PETIT_MAGASIN, SEUIL_REAPPROVISIONNEMENT, NUMERO_SERIE, ARTICLE_COMPOSE, ARTICLE_LIE, ARTICLE_RECONDITIONNABLE, APPARAIT_SUR_FICHE_CLIENT, ARTICLE_PERISSABLE, ARTICLE_GERE_PAR_LOT, DATE_DEBUT_PROMOTION, POURCENTAGE_REMISE_PROMOTION, DATE_FIN_PROMOTION, CHEMIN_PHOTO, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, ARTICLE_A_REMISE, CODE_CLE, DELEGUE, SEUIL_PRIX_VENTE_TTC, TX_LIMIT, DAILY_LIMIT, TAUX_TVA, SPECIALITE_ARTICLE, ARTICLE_MULTIPRIX, CODE_AGENCE, TYPE, CODE_UNITE_DE_COMPTAGE, CARTE, CODE_CONSO, PRIX_CONSO, CONTENANCE, BOISSON, PRIX_CONSO2, PRIX_CONSO3, PRIX_CONSO4, VISIBLE) Then

                        If GlobalVariable.typeArticle = "article" Then
                            MessageBox.Show("Nouvel Article enregistré avec succès", "Création d'Article", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Nouvelle Matière enregistré avec succès", "Création d'Article", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Cette Article/Matière existe déjà, Essayer à nouveau", "Article Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        '------------------------ GESTION DES IMAGES ----------------------------------------

        Dim ms As New MemoryStream()

        If Not GunaPictureBoxLogo.Image Is Nothing Then

            GunaPictureBoxLogo.Image.Save(ms, GunaPictureBoxLogo.Image.RawFormat)

            Dim img As Byte() = ms.GetBuffer()

            If ms.Length > 0 Then

                Dim updateQuery As String = "UPDATE `article` SET `IMAGE_1`= @IMAGE_1 WHERE CODE_ARTICLE = @CODE_ARTICLE"

                Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
                command.Parameters.Add("@IMAGE_1", MySqlDbType.Blob).Value = ms.ToArray()

                command.ExecuteNonQuery()

            End If

        End If

        '-----------------------------------------------------------------------------------

        GunaPictureBoxLogo.Image = Nothing

        ArticleList()

        GunaTextBoxPrixConso1.Text = 0

        GunaTextBoxDesignation.Text = ""
        GunaComboBoxSuiviStock.SelectedIndex = 0
        GunaTextBoxCUMP.Text = 0
        GunaTextBoxStockReaProPetitMagasin.Text = 0
        GunaTextBoxStockReapproGrandMagasin.Text = 0
        'GunaComboBoxTypeArticle.SelectedIndex = -1
        GunaTextBoxCodeArticle.Text = ""
        GunaTextBoxVenteHT.Text = 0
        GunaTextBoxNumSerie.Text = ""
        GunaTextBoxStockReaProPetitMagasin.Text = 6
        GunaTextBoxStockReapproGrandMagasin.Text = 12
        GunaTextBoxStock.Text = 0
        GunaTextBoxPrixAchat.Text = 0

        GunaTextBoxContenance.Text = 0

        GunaTextBoxVenteHT2.Text = 0
        GunaTextBoxVenteHT3.Text = 0
        GunaTextBoxVenteHT4.Text = 0

        GunaCheckBoxBoisson.Checked = False

        GunaTextBoxPrixConso2.Text = 0
        GunaTextBoxPrixConso3.Text = 0
        GunaTextBoxPrixConso4.Text = 0

        GunaLabelStockEnConso.Visible = False
        GunaTextBoxStockEnConso.Visible = False
        GunaTextBoxStockEnConso.Text = 0
        'connect.closeConnection()

        If GlobalVariable.typeArticle = "article" Then
            GunaComboBoxArticleMatiere.SelectedIndex = 0
        Else
            GunaComboBoxArticleMatiere.SelectedIndex = 1
        End If

    End Sub

    'mise à jours dea
    Private Sub GunaDataGridViewArticle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticle.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Sauvegarder"

            If GunaButtonEnregistrer.Text = "Sauvegarder" Then
                GunaButtonFicheDeStock.Visible = True
            Else
                GunaButtonFicheDeStock.Visible = False
            End If

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewArticle.Rows(e.RowIndex)

            TabControlArticle.SelectedIndex = 0

            Dim Article As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE").Value.ToString), "article", "CODE_ARTICLE")

            If Article.Rows.Count > 0 Then

                GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")
                GunaComboBoxSuiviStock.SelectedItem = Article.Rows(0)("METHODE_SUIVI_STOCK")
                GunaTextBoxDesignation.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxCUMP.Text = Format(Article.Rows(0)("PRIX_ACHAT_HT"), "#,##0")
                GunaTextBoxVenteHT.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0")
                GunaTextBoxVenteHT2.Text = Format(Article.Rows(0)("PRIX_VENTE1_HT"), "#,##0")
                GunaTextBoxVenteHT3.Text = Format(Article.Rows(0)("PRIX_VENTE2_HT"), "#,##0")
                GunaTextBoxVenteHT4.Text = Format(Article.Rows(0)("PRIX_VENTE3_HT"), "#,##0")
                GunaTextBoxNumSerie.Text = Article.Rows(0)("NUMERO_SERIE")
                GunaTextBoxStockReaProPetitMagasin.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT_PETIT_MAGASIN")
                GunaTextBoxStockReapproGrandMagasin.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")

                GunaComboBoxTypeArticle.SelectedValue = Article.Rows(0)("TYPE_ARTICLE")

                If Article.Rows(0)("TYPE").Equals("article") Then
                    GunaComboBoxArticleMatiere.SelectedIndex = 0
                ElseIf Article.Rows(0)("TYPE").Equals("matiere") Then
                    GunaComboBoxArticleMatiere.SelectedIndex = 1
                End If

                'VISIBILITE

                If Article.Rows(0)("VISIBLE") = 1 Then
                    GunaCheckBoxVisibiliteAuBar.Checked = True
                Else
                    GunaCheckBoxVisibiliteAuBar.Checked = False
                End If

                GunaComboBoxCategorieArticle.SelectedValue = Article.Rows(0)("CODE_FAMILLE")

                GunaComboBoxSousFamilleArticle.SelectedValue = Article.Rows(0)("CODE_SOUS_FAMILLE") 'REFERENCE CONTAINS THE SOUS FAMILLE CODE

                GunaComboBoxUniteDeCompatage.SelectedValue = Article.Rows(0)("UNITE_COMPTAGE") 'CODE DE L'UNITE DE COMTAGE
                GunaTextBoxCodeBarre.Text = Article.Rows(0)("CODE_BARRE")
                GunaTextBoxPrixAchat.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0")

                'ON CHARGE D'ABORDS TOUTES LES SOUS SOUS FAMILLE AVANT D'EN CHOISIR UNE

                '--------------------------------------------------------------

                Dim SousFamille As DataTable = Functions.GetAllElementsOnCondition(GunaComboBoxSousFamilleArticle.SelectedValue, "sous_sous_famille", "CODE_FAMILLE_PARENT")

                If (SousFamille.Rows.Count > 0) Then

                    GunaComboBoxLastLevelArticle.DataSource = SousFamille
                    GunaComboBoxLastLevelArticle.ValueMember = "LIBELLE_FAMILLE"
                    'GunaComboBoxLastLevelArticle.ValueMember = "CODE_SOUS_FAMILLE"
                    GunaComboBoxLastLevelArticle.DisplayMember = "LIBELLE_FAMILLE"

                Else
                    GunaComboBoxLastLevelArticle.SelectedValue = -1
                End If

                '--------------------------------------------------------------

                GunaComboBoxLastLevelArticle.SelectedValue = Article.Rows(0)("CODE_SOUS_SOUS_FAMILLE")

                If Not Trim(Article.Rows(0)("CODE_CONSO")) = "" Then
                    GunaComboBoxUniteDeConsommation.SelectedValue = Article.Rows(0)("CODE_CONSO")
                End If

                GunaTextBoxPrixConso1.Text = Format(Article.Rows(0)("PRIX_CONSO"), "#,##0")
                GunaTextBoxPrixConso2.Text = Format(Article.Rows(0)("PRIX_CONSO2"), "#,##0")
                GunaTextBoxPrixConso3.Text = Format(Article.Rows(0)("PRIX_CONSO3"), "#,##0")
                GunaTextBoxPrixConso4.Text = Format(Article.Rows(0)("PRIX_CONSO4"), "#,##0")

                If Article.Rows(0)("CARTE") = 1 Then 'ARTICLE DONT LE DESTOCKAGE SE FAIT A LA VENTE

                    GunaCheckBoxAlaCarte.Checked = True

                    GunaComboBoxFicheTechnique.SelectedValue = Article.Rows(0)("CODE_CLE") ' CODE DE LA FICHE TECHNIQUE DONT DEPEND L'ARTICLE

                Else
                    GunaCheckBoxAlaCarte.Checked = False 'ARTICLE DONT LE DESTOCKAGE SE FAIT A LA PREPARATION DE L'ARTICLE
                End If

                GunaTextBoxContenance.Text = Article.Rows(0)("CONTENANCE")

                If Article.Rows(0)("BOISSON") = 1 Then

                    GunaCheckBoxBoisson.Checked = True

                    '----------------------------------------------------------
                    Dim nombreDeBouteille As Double = 0
                    Dim nombreDeConso As Integer = 0
                    Dim nombreDeConsoTotal As Integer = Article.Rows(0)("QUANTITE")
                    Dim contenance As Double = Double.Parse(GunaTextBoxContenance.Text)
                    Dim valeurConversion As Double = Double.Parse(GunaTextBoxValeurUniteConso.Text)

                    Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                    If nombreDeConsoDansUneBouteille > 0 Then

                        nombreDeBouteille = Int(nombreDeConsoTotal / nombreDeConsoDansUneBouteille)
                        nombreDeConso = nombreDeConsoTotal Mod nombreDeConsoDansUneBouteille

                    End If

                    GunaTextBoxStock.Text = Format(nombreDeBouteille, "#,##0.0")
                    GunaTextBoxStockEnConso.Text = Format(nombreDeConso, "#,##0.0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS
                    '----------------------------------------------------------

                Else
                    GunaCheckBoxBoisson.Checked = False
                    GunaTextBoxStock.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.0")
                End If

                If Not IsDBNull(Article.Rows(0)("IMAGE_1")) Then 'IMAGE DEPUIS VBNET

                    Dim img() As Byte
                    img = Article.Rows(0)("IMAGE_1")

                    Dim mStream As New MemoryStream(img)

                    If mStream.Length > 0 Then
                        GunaPictureBoxLogo.Image = Image.FromStream(mStream)
                    End If

                End If


            End If

        End If

        GunaTextBoxRefArticleMatiere.Text = ""

        GunaDataGridViewExisting.Visible = False

    End Sub

    'SUPRESSION D'ARTICLE
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewArticle.Rows.Count > 0 Then

            Dim CODE_ARTICLE As String = GunaDataGridViewArticle.CurrentRow.Cells("CODE").Value.ToString
            Dim NOM_ARTICLE As String = GunaDataGridViewArticle.CurrentRow.Cells("DESIGNATION").Value.ToString

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supprimer " & NOM_ARTICLE, "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewArticle, CODE_ARTICLE, "article", "CODE_ARTICLE")

                GunaDataGridViewArticle.Columns.Clear()

                GunaTextBoxRefArticleMatiere.Clear()

                ArticleList()

                MessageBox.Show("Vous avez supprimé " & NOM_ARTICLE & " avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    'AJOUT DES MATIERES DANS LA LISTE DE COMPOSITION DE L'ARTICLE
    Private Sub GunaTextBox3_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxLibelleFiche.TextChanged, GunaTextBoxArticleMatiere.TextChanged

        GunaDataGridViewArticleAAjouter.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxArticleMatiere.Text).Equals("") Then

            GunaDataGridViewArticleAAjouter.Visible = False
            GunaButtonAjouterLigne.Enabled = True
            GunaTextBoxUniteDeComptage.Clear()
            GunaTextBoxCodeUniteComptage.Clear()
            GunaTextBoxQuantiteDeMatiere.Text = 1

        End If

        getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticleMatiere.Text) & "%' AND TYPE =@TYPE ORDER BY DESIGNATION_FR ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "matiere"
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewArticleAAjouter.DataSource = table
        Else
            GunaDataGridViewArticleAAjouter.Columns.Clear()
            GunaDataGridViewArticleAAjouter.Visible = False
        End If

    End Sub

    Dim montant As Double = 0
    Dim quantite As Double = 0
    Dim montantTTC As Double = 0
    Dim TVA As Double = 0
    Dim montantHT As Double = 0
    Dim codeArticle As String = ""

    'Matiere de la fiche technique
    Private Sub GunaDataGridViewArticleAAjouter_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticleAAjouter.CellClick

        If e.RowIndex >= 0 Then

            GunaTextBoxMontantHT.Visible = False
            'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
            'il disparait de nouveau après ajout a la facture
            'En plus il ne peut pas aparaitre pour les clients comptoire, si il n'est associé à aucun numéro de bloc_note

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewArticleAAjouter.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE DESIGNATION_FR=@DESIGNATION_FR AND TYPE=@TYPE ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@DESIGNATION_FR", MySqlDbType.VarChar).Value = row.Cells("DESIGNATION_FR").Value.ToString
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "matiere"

            adapter.SelectCommand = command
            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then
                'On determine si l'article est associe a une unite
                Dim uniteDeComptage As DataTable = Functions.getElementByCode(Article.Rows(0)("UNITE_COMPTAGE"), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If uniteDeComptage.Rows.Count > 0 Then
                    GunaTextBoxCodeUniteComptage.Text = Article.Rows(0)("UNITE_COMPTAGE")
                    GunaTextBoxUniteDeComptage.Text = uniteDeComptage.Rows(0)("PETITE_UNITE")
                    GunaButtonAjouterLigne.Enabled = True
                Else

                    GunaTextBoxUniteDeComptage.Text = "Aucune Unité"
                    GunaButtonAjouterLigne.Enabled = False

                End If

                codeArticle = Article.Rows(0)("CODE_ARTICLE")
                Double.TryParse(GunaTextBoxQuantiteDeMatiere.Text, quantite)
                GunaTextBoxMontantHT.Text = Format(Article.Rows(0)("PRIX_ACHAT_HT"), "#,##0")
                Double.TryParse(GunaTextBoxMontantHT.Text, montant)
                GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
                Double.TryParse(GunaTextBoxTVA.Text, TVA)
                montantHT = (quantite * montant)
                GunaTextBoxMontantAchatHT.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

                GunaTextBoxArticleMatiere.Text = Article.Rows(0)("DESIGNATION_FR")
                'GunaTextBoxStock.Text = Article.Rows(0)("QUANTITE")
                GunaDataGridViewArticleAAjouter.Visible = False

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid
                'clearArticleFields()

            End If

        End If

    End Sub

    '   NOTE

    'Dans la fiche technique de la metiere c'est le cout moyen unitaire pondere qui est utilse lors de la creation des fiches techniques

    Public Sub OutPutLigneFacture()

        Dim query As String = "SELECT ligne_facture_temp.CODE_ARTICLE As 'CODE ARTICLE' , DESIGNATION_FR AS 'DESIGNATION', unite_comptage.PETITE_UNITE AS 'UNITE', MONTANT_REMISE As 'PRIX ACHAT', ligne_facture_temp.QUANTITE AS 'QTE UTILISE', ligne_facture_temp.MONTANT_TTC AS 'QTE / PORTION', MONTANT_HT AS 'COUT DE REVIENT' FROM ligne_facture_temp, article, unite_comptage WHERE ligne_facture_temp.CODE_ARTICLE = article.CODE_ARTICLE  AND article.UNITE_COMPTAGE=unite_comptage.CODE_UNITE_DE_COMPTAGE AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = GunaTextBoxNumfacture.Text

        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            'klg
            GunaDataGridViewLigneFiche.Columns.Clear()

            GunaDataGridViewLigneFiche.DataSource = table

            GunaDataGridViewLigneFiche.Columns("PRIX ACHAT").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewLigneFiche.Columns("PRIX ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewLigneFiche.Columns("PRIX ACHAT").DefaultCellStyle.Format = "n2"

            GunaDataGridViewLigneFiche.Columns("QTE UTILISE").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewLigneFiche.Columns("QTE UTILISE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewLigneFiche.Columns("QTE UTILISE").DefaultCellStyle.Format = "n2"

            GunaDataGridViewLigneFiche.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewLigneFiche.Columns("COUT DE REVIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewLigneFiche.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "n2"

            GunaDataGridViewLigneFiche.Columns("QTE / PORTION").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewLigneFiche.Columns("QTE / PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewLigneFiche.Columns("QTE / PORTION").DefaultCellStyle.Format = "n2"

            GunaDataGridViewLigneFiche.Columns("CODE ARTICLE").Visible = False
            GunaDataGridViewLigneFiche.Columns("PRIX ACHAT").Visible = False

        Else
            GunaDataGridViewLigneFiche.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    'AJOUT DES LIGNES D'UNE FICHE TECHNIQUE
    Private Sub GunaButtonAjouter_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click

        GunaButtonAjouterLigne.Visible = True

        Dim CODE_MOUVEMENT As String = ""

        Dim CODE_CHAMBRE As String = ""
        Dim CODE_MODE_PAIEMENT As String = ""
        Dim NUMERO_PIECE As String = ""
        Dim CODE_ARTICLE As String = codeArticle 'Variable globale
        Dim CODE_LOT As String = ""
        'Dim TAXE As Double = Double.Parse(GunaTextBoxTVA.Text)
        Dim TAXE As Double = 0
        Dim QUANTITE As Integer = Trim(GunaTextBoxQuantiteDeMatiere.Text)

        Dim PRIX_UNITAIRE_TTC As Double = Trim(GunaTextBoxMontantHT.Text) / Trim(GunaTextBoxQuantiteDeMatiere.Text)
        'Dim MONTANT_TTC As Double = Double.Parse(Trim(GunaTextBoxQuantite.Text)) / Double.Parse(Trim(GunaTextBoxNombreDePortion.Text))
        Dim MONTANT_TTC As Double = Double.Parse(Trim(GunaTextBoxQuantiteDeMatiere.Text)) / 1
        Dim DATE_FACTURE As Date = GlobalVariable.DateDeTravail.ToShortDateString()
        Dim HEURE_FACTURE As DateTime = Date.Now().ToShortTimeString
        Dim ETAT_FACTURE As Integer = 0
        Dim DATE_OCCUPATION As Date = Now().ToShortDateString()
        Dim HEURE_OCCUPATION As DateTime = Date.Now().ToShortTimeString
        Dim LIBELLE_FACTURE As String = GunaTextBoxArticleMatiere.Text
        Dim TYPE_LIGNE_FACTURE As String = "fiche technique"
        Dim NUMERO_SERIE As String = ""
        Dim NUMERO_ORDRE As Integer = 0
        Dim DESCRIPTION As String = ""
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim MONTANT_HT As Double = 0
        'COUT PAR PLUS PETITE UNITE NECESSAIRE POUR LA FICHE TECHNIQUE
        Dim MONTANT_REMISE As Double = 0 ' = MONTANT PAR UNITE DE LA PLUS PETITE UNITE DE COMPTAGE

        Dim prixParPetiteUnite As DataTable = Functions.getElementByCode(GunaTextBoxCodeUniteComptage.Text, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

        If prixParPetiteUnite.Rows.Count > 0 Then

            GunaTextBoxMontantHT.Visible = True

            GunaTextBoxValeurConversionUnite.Text = prixParPetiteUnite.Rows(0)("VALEUR_NUMERIQUE")

            MONTANT_REMISE = Trim(GunaTextBoxMontantHT.Text) / prixParPetiteUnite.Rows(0)("VALEUR_NUMERIQUE")

            MONTANT_HT = (MONTANT_REMISE * QUANTITE) 'COUT DE REVIENT

        End If

        Dim MONTANT_TAXE As Double = MONTANT_REMISE * QUANTITE ' MONTANT TOTAL DE REVIENT PAR PLUS PETITE UNITE DE COMPTAGE
        Dim NUMERO_SERIE_DEBUT As String = ""
        Dim NUMERO_SERIE_FIN As String = ""
        Dim CODE_MAGASIN As String = ""
        Dim FUSIONNEE As String = ""
        Dim CODE_RESERVATION As String = ""
        Dim CODE_FACTURE As String = GunaTextBoxNumfacture.Text
        Dim TYPE As String = GlobalVariable.typeChambreOuSalle

        Dim TABLE_LIGNE As String = "ligne_facture_temp"

        Dim NUMERO_BLOC_NOTE As String = ""

        '-------------------------- LIGNE FACTURATION--------------------------
        Dim ligneFacture As New LigneFacture()

        If GunaButtonAjouterLigne.Text = "Modifier" Then

            CODE_ARTICLE = GunaTextBoxCodeArticlePourFiche.Text

            Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "CODE_ARTICLE", "CODE_FACTURE", CODE_FACTURE)

            GunaLabelUniteDeComptage.Text = "Unité de comptage"

            GunaLabelModifPetiteUnite.Visible = False

            GunaComboBoxPetiteUniteComptage.Visible = False

            GunaButtonAjouterLigne.Text = "Ajouter"

        End If

        If ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE) Then

        End If

        'Refresh Datagrid To view newly inserted Articles
        OutPutLigneFacture()

        GunaTextBoxArticleMatiere.Clear()

        'On renseigne les information supplementaire concernant la fiche de police
        informationGeneraleFicheTechnique()

    End Sub

    Dim totalPrixRevient As Double = 0

    Private Sub informationGeneraleFicheTechnique()

        Dim CRU As Double = 0
        Dim PMI As Double = 0
        Dim PV As Double = 0
        Dim PVPPV As Double = 0
        Dim MB As Double = 0
        Dim DIVERS As Double = 0
        Dim QTE As Double = 1

        If GunaDataGridViewLigneFicheTechPreparation.Rows.Count > 0 Then

            If Not GunaCheckBoxFTPlusieursPlat.Checked Then

                'UN ARTICLE ASSOCIE A UNE FICHE TECHNIQUE

                If Trim(GunaTextBoxDiversPourcentage.Text) = "" Then
                    GunaTextBoxDiversPourcentage.Text = 0
                End If

                If Trim(GunaTextBoxDiversMontant.Text) = "" Then
                    GunaTextBoxDiversMontant.Text = 0
                End If

                Dim ficheTechniqueElements As New Article()

                Dim CODE_FICHE_TECHNIQUE As String = GunaTextBoxCodeFicheTechnique.Text

                Dim ficheTechElement As DataTable = ficheTechniqueElements.elementsDuneFicheTechniquePourPreparation(CODE_FICHE_TECHNIQUE)

                'Dim infoSupFt As DataTable = Functions.getElementByCode(CODE_FICHE_TECHNIQUE, "fiche_technique", "CODE_FICHE_TECHNIQUE")

                'If infoSupFt.Rows.Count > 0 Then
                'GunaTextBoxCM.Text = Format(infoSupFt.Rows(0)(""), "#,##0.0")
                'End If

                If ficheTechElement.Rows.Count > 0 Then

                    If Trim(GunaTextBoxNombreDePortion.Text) = "" Then
                        GunaTextBoxNombreDePortion.Text = 1
                    End If

                    GunaDataGridViewLigneFicheTechPreparation.Columns.Clear()

                    GunaDataGridViewLigneFicheTechPreparation.Columns.Add("CODE ARTICLE", "CODE ARTICLE")
                    GunaDataGridViewLigneFicheTechPreparation.Columns.Add("DESIGNATION", "DESIGNATION")
                    GunaDataGridViewLigneFicheTechPreparation.Columns.Add("UNITE", "UNITE")
                    GunaDataGridViewLigneFicheTechPreparation.Columns.Add("QTE UTILISE", "QTE UTILISE")
                    GunaDataGridViewLigneFicheTechPreparation.Columns.Add("QTE / PORTION", "QTE / PORTION")
                    GunaDataGridViewLigneFicheTechPreparation.Columns.Add("COUT DE REVIENT", "COUT DE REVIENT")
                    GunaDataGridViewLigneFicheTechPreparation.Columns.Add("COUT ACHAT", "COUT ACHAT")

                    For i = 0 To ficheTechElement.Rows.Count - 1
                        GunaDataGridViewLigneFicheTechPreparation.Rows.Add(ficheTechElement(i)("CODE ARTICLE"), ficheTechElement(i)("DESIGNATION"), ficheTechElement(i)("UNITE"), ficheTechElement(i)("QTE UTILISE") * GunaTextBoxNombreDePortion.Text, ficheTechElement(i)("QTE / PORTION"), ficheTechElement(i)("COUT DE REVIENT") * GunaTextBoxNombreDePortion.Text, ficheTechElement(i)("COUT ACHAT") * GunaTextBoxNombreDePortion.Text)
                    Next

                    GunaDataGridViewLigneFicheTechPreparation.Columns("COUT ACHAT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewLigneFicheTechPreparation.Columns("COUT ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GunaDataGridViewLigneFicheTechPreparation.Columns("COUT ACHAT").DefaultCellStyle.Format = "n2"

                    GunaDataGridViewLigneFicheTechPreparation.Columns("QTE UTILISE").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewLigneFicheTechPreparation.Columns("QTE UTILISE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GunaDataGridViewLigneFicheTechPreparation.Columns("QTE UTILISE").DefaultCellStyle.Format = "n2"

                    GunaDataGridViewLigneFicheTechPreparation.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewLigneFicheTechPreparation.Columns("COUT DE REVIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GunaDataGridViewLigneFicheTechPreparation.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "n2"

                    GunaDataGridViewLigneFicheTechPreparation.Columns("QTE / PORTION").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewLigneFicheTechPreparation.Columns("QTE / PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GunaDataGridViewLigneFicheTechPreparation.Columns("QTE / PORTION").DefaultCellStyle.Format = "n2"

                    GunaDataGridViewLigneFicheTechPreparation.Columns("CODE ARTICLE").Visible = False
                    GunaDataGridViewLigneFicheTechPreparation.Columns("COUT ACHAT").Visible = False

                    'Indices du datagrid en rapport avec la prepartion d'un article a partir de la fiche technique

                    totalPrixRevient = 0

                    For i = 0 To GunaDataGridViewLigneFicheTechPreparation.Rows.Count - 1
                        totalPrixRevient += Double.Parse(GunaDataGridViewLigneFicheTechPreparation.Rows(i).Cells("COUT DE REVIENT").Value)
                    Next

                    If Trim(GunaTextBoxNombreDePortion.Text) = "" Then
                        GunaTextBoxNombreDePortion.Text = 0
                    End If

                    If Trim(GunaTextBoxPrixVente.Text) = "" Then
                        GunaTextBoxPrixVente.Text = 0
                    End If

                    'GunaTextBoxPV.Text = Format(Double.Parse(GunaTextBoxQuantiteADestocker.Text) * Double.Parse(GunaTextBoxPrixVente.Text), "#,##0")
                    'GunaTextBoxPV.Text = Format(GunaTextBoxPrixVente.Text * GunaTextBoxNombreDePortion.Text, "#,##0")

                    GunaTextBoxDiversMontant.Text = Format((Double.Parse(GunaTextBoxDiversPourcentage.Text) * Double.Parse(totalPrixRevient)) / 100, "#,##0")

                    If Not Trim(GunaTextBoxNombreDePortion.Text).Equals("") Then
                        QTE = GunaTextBoxNombreDePortion.Text
                    End If

                    GunaTextBoxPV.Text = Format(GunaTextBoxPrixVente.Text * QTE, "#,##0")

                    GunaTextBoxTotaLPrixRevient.Text = Format((totalPrixRevient), "#,##0")

                    If Double.Parse(GunaTextBoxNombreDePortion.Text) > 0 Then
                        GunaTextBoxCRPP.Text = Format((totalPrixRevient + (Double.Parse(GunaTextBoxDiversPourcentage.Text) * Double.Parse(totalPrixRevient)) / 100) / GunaTextBoxNombreDePortion.Text, "#,##0")
                    Else
                        GunaTextBoxCRPP.Text = 0
                    End If

                    If Trim(GunaTextBoxPMI.Text) = "" Then
                        GunaTextBoxPMI.Text = 0
                    End If

                    If Trim(GunaTextBoxCRPP.Text) = "" Then
                        GunaTextBoxCRPP.Text = 0
                    End If

                    CRU = 0
                    PMI = 0
                    DIVERS = 0

                    Double.TryParse(GunaTextBoxCRPP.Text, CRU)
                    Double.TryParse(GunaTextBoxPMI.Text, PMI)
                    Double.TryParse(GunaTextBoxPMI.Text, DIVERS)

                    GunaTextBoxPRPPV.Text = Format(Math.Round((CRU * PMI / 100)) + CRU, "#,##0")

                    GunaTextBoxMontanPourcentageInvendu.Text = CRU * PMI / 100

                    GunaTextBoxMB.Text = Format(GunaTextBoxPV.Text - (GunaTextBoxPRPPV.Text) * QTE, "#,##0")

                    PV = 0
                    PVPPV = 0
                    MB = 0

                    Double.TryParse(GunaTextBoxPV.Text, PV)
                    Double.TryParse(GunaTextBoxPRPPV.Text, PVPPV)
                    Double.TryParse(GunaTextBoxMB.Text, MB)

                    If PVPPV > 0 Then

                        GunaTextBoxCM.Text = Format(PV / (PVPPV * QTE), "#,##0.0") 'LE PRIX DE VENTE EST COMBIEN DE FOIS LE COUT TOTAL DE PRODUCTION
                        GunaTextBoxTM.Text = Format((MB / (PVPPV * QTE)) * 100, "#,##0.0") '

                    Else
                        GunaTextBoxCM.Text = 0
                        GunaTextBoxTM.Text = 0
                    End If

                Else

                End If

            Else

                'PLUSIEURS ARTICLES ASSOCIES A UNE FICHE TECHNIQUE


            End If

        Else

            'CREATION DE FICHE TECHNIQUE
            'Indices du datagrid en rapport avec la fiche technique
            totalPrixRevient = 0

            If Trim(GunaTextBoxDiversPourcentage.Text) = "" Then
                GunaTextBoxDiversPourcentage.Text = 0
            End If

            If Trim(GunaTextBoxDiversMontant.Text) = "" Then
                GunaTextBoxDiversMontant.Text = 0
            End If

            For i = 0 To GunaDataGridViewLigneFiche.Rows.Count - 1
                totalPrixRevient += Double.Parse(GunaDataGridViewLigneFiche.Rows(i).Cells("COUT DE REVIENT").Value)
            Next

            If Trim(GunaTextBoxNombreDePortion.Text) = "" Then
                GunaTextBoxNombreDePortion.Text = 0
            End If

            If Trim(GunaTextBoxPrixVente.Text) = "" Then
                GunaTextBoxPrixVente.Text = 0
            End If

            'GunaTextBoxPV.Text = Format(Double.Parse(GunaTextBoxQuantiteADestocker.Text) * Double.Parse(GunaTextBoxPrixVente.Text), "#,##0")
            'GunaTextBoxPV.Text = GunaTextBoxPrixVente.Text

            GunaTextBoxTotaLPrixRevient.Text = Format(totalPrixRevient, "#,##0")

            GunaTextBoxDiversMontant.Text = Format((Double.Parse(GunaTextBoxDiversPourcentage.Text) * Double.Parse(totalPrixRevient)) / 100, "#,##0")

            If Double.Parse(GunaTextBoxNombreDePortion.Text) > 0 Then
                GunaTextBoxCRPP.Text = Format((totalPrixRevient + GunaTextBoxDiversMontant.Text) / GunaTextBoxNombreDePortion.Text, "#,##0")
            Else
                GunaTextBoxCRPP.Text = 0
            End If

            'GunaTextBoxMB.Text = Format(GunaTextBoxPV.Text - GunaTextBoxTotaLPrixRevient.Text, "#,##0")

            If Trim(GunaTextBoxPMI.Text) = "" Then
                GunaTextBoxPMI.Text = 0
            End If

            If Trim(GunaTextBoxCRPP.Text) = "" Then
                GunaTextBoxCRPP.Text = 0
            End If

            CRU = 0
            PMI = 0
            DIVERS = 0

            Double.TryParse(GunaTextBoxCRPP.Text, CRU)
            Double.TryParse(GunaTextBoxPMI.Text, PMI)
            Double.TryParse(GunaTextBoxDiversMontant.Text, DIVERS)

            GunaTextBoxPRPPV.Text = Format(Math.Round((CRU * PMI / 100)) + CRU, "#,##0")

            GunaTextBoxMontanPourcentageInvendu.Text = Format(CRU * PMI / 100, "#,##0")

            PV = 0
            PVPPV = 0
            MB = 0

            Double.TryParse(GunaTextBoxPV.Text, PV)
            Double.TryParse(GunaTextBoxPRPPV.Text, PVPPV)
            Double.TryParse(GunaTextBoxMB.Text, MB)

            Dim CM As Double = 0
            Double.TryParse(GunaTextBoxCM.Text, CM)

            If PVPPV > 0 Then

                'LE COEFFICIENT DE MARGE PERMET DE DETERMINER LE PRIX DE VENTE
                If PrixDeVenteFxnDuCoef.Checked Then
                    GunaTextBoxPV.Text = Format(CM * PVPPV, "#,##0")
                Else
                    'LE PRIX DE VENTE PERMET DE DETERMINER LE COEFFICIENT DE MARGE 
                    If PV > 0 Then
                        GunaTextBoxCM.Text = Format(PVPPV / PV, "#,##0.0")
                    End If

                End If

                GunaTextBoxMB.Text = Format(GunaTextBoxPV.Text - GunaTextBoxPRPPV.Text, "#,##0")

                GunaTextBoxTM.Text = Format((MB / PVPPV) * 100, "#,##0")

            Else
                'GunaTextBoxCM.Text = 0

                'GunaTextBoxTM.Text = 0
            End If


        End If


    End Sub

    'Enregistrement des fiches techniques
    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButtonPreparationDePlat.Click

        'PREPARATION DES ARTICLES

        Dim article As New Article()

        Dim LIBELLE_FICHE As String = GunaTextBoxLibelleFiche.Text
        Dim NOM_ARTICLE As String = GunaTextBoxNomArticle.Text

        Dim CODE_ARTICLE_FICHE As String = GunaTextBoxCodeArticlePourFiche.Text
        Dim NOMBRE_DE_PORTION As Integer = GunaTextBoxNombreDePortion.Text
        Dim CODE_FICHE_TECHNIQUE As String = GunaTextBoxCodeFicheTechnique.Text
        Dim A_LA_CARTE As Integer = Integer.Parse(GunaTextBoxALaCarte.Text)
        Dim DATE_PREPARATION As Date = GlobalVariable.DateDeTravail
        Dim CTR As Double = GunaTextBoxTotaLPrixRevient.Text
        Dim PV As Double = GunaTextBoxPV.Text
        Dim CRPPP As Double = GunaTextBoxCRPP.Text
        Dim PMI As Double = GunaTextBoxPMI.Text
        Dim CM As Double = GunaTextBoxCM.Text
        Dim CRPPV As Double = GunaTextBoxPRPPV.Text
        Dim MB As Double = GunaTextBoxMB.Text
        Dim TM As Double = GunaTextBoxTM.Text
        Dim DIVERS_POURCENTAGE As Integer = GunaTextBoxDiversPourcentage.Text
        Dim DIVERS_MONTANT As Double = GunaTextBoxDiversMontant.Text

        Dim PRIX_VENTE As Double = 0

        If Not Trim(GunaTextBoxPrixVente.Text).Equals("") Then
            PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text)
        End If

        If GunaCheckBoxFTPlusieursPlat.Checked Then

            NOMBRE_DE_PORTION = 1

            PRIX_VENTE = GunaTextBoxPV.Text

            Dim query As String = "SELECT * FROM fiche_technique_article_prepare WHERE DATE_PREPARATION <= '" & DATE_PREPARATION.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >='" & DATE_PREPARATION.ToString("yyyy-MM-dd") & "' AND CODE_FICHE_TECHNIQUE = @CODE_FICHE_TECHNIQUE"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If table.Rows.Count > 0 Then

                For i = 0 To table.Rows.Count - 1
                    If Not i = table.Rows.Count - 1 Then
                        CODE_ARTICLE_FICHE += table.Rows(i)("CODE_ARTICLE") & ","
                    Else
                        CODE_ARTICLE_FICHE += table.Rows(i)("CODE_ARTICLE")
                    End If

                Next

            End If

        Else

            Dim tableName As String = "fiche_technique_article_prepare"
            'Insetion des lignes pour genration du rapport des preparation en cuisine
            article.ficheTechniqueArticlePrepare(CODE_ARTICLE_FICHE, NOM_ARTICLE, CODE_FICHE_TECHNIQUE, NOMBRE_DE_PORTION, DATE_PREPARATION, PRIX_VENTE, tableName)

        End If

        article.updateFicheTechnique(LIBELLE_FICHE, NOM_ARTICLE, PRIX_VENTE, CODE_FICHE_TECHNIQUE, CODE_ARTICLE_FICHE, NOMBRE_DE_PORTION, CTR, PV, CRPPP, PMI, CM, CRPPV, MB, TM, DATE_PREPARATION, DIVERS_POURCENTAGE, DIVERS_MONTANT)

        'GENERATION D'UN BON DE COMMANDE
        Dim econom As New Economat()
        'Enregistrement des éléments du bordereau

        Dim CODE_BORDEREAUX As String = Functions.GeneratingRandomCode("bordereaux", "BA")
        Dim TYPE_BORDEREAUX As String = GlobalVariable.bon_approvisi
        Dim REF_BORDEREAUX As String = CODE_FICHE_TECHNIQUE
        Dim LIBELLE_BORDEREAUX As String = "DEMANDE DES MATIERES POUR " & GunaTextBoxLibelleFiche.Text.ToUpper & " " + GlobalVariable.DateDeTravail
        Dim CODE_TIERS As String = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")
        Dim NON_TIERS As String = GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")
        Dim DATE_BORDEREAU As Date = GlobalVariable.DateDeTravail
        Dim OBSERVATIONS As String = ""
        Dim MONTANT_HT As Double = GunaTextBoxTotaLPrixRevient.Text
        Dim MONTANT_TAXE As Double = 0
        Dim MONTANT_TTC As Double = 0
        Dim MONTANT_PAYER As Double = GunaTextBoxPV.Text
        Dim VALIDE As String = "NON CONTTROLE"
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_MAGASIN As String = GunaComboBoxMagDestock.SelectedValue.ToString
        Dim CODE_SOUS_MAGASIN As String = GunaComboBoxMagasinRecep.SelectedValue.ToString

        '-------------------------------- GESTION DES STOCKS ---------------------------------------------
        'Si c'est un article a la carte => A_LA_CARTE = 1
        'Dans ce cas on destok uniquement a la vente
        'Au cas contraire on cree un bon de commande qui une fois valider entrainera un destockage

        'If GunaButtonEnregistrer.Text = "Enregistrer" And A_LA_CARTE = 0 Then
        If GunaButtonEnregistrer.Text = "Enregistrer" Then

            'Insertion des information du bordereau

            If econom.insertBordereau(CODE_BORDEREAUX, TYPE_BORDEREAUX, REF_BORDEREAUX, LIBELLE_BORDEREAUX, CODE_TIERS, NON_TIERS, DATE_BORDEREAU, OBSERVATIONS, MONTANT_HT, MONTANT_TAXE, MONTANT_TTC, MONTANT_PAYER, VALIDE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_MAGASIN, CODE_SOUS_MAGASIN) Then

                '----------------------
                Dim upDateQuery As String = "UPDATE `bordereaux` SET `ENREGISTRER`= @ENREGISTRER WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_BORDEREAUX=@CODE_BORDEREAUX"

                Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

                command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                command.Parameters.Add("@ENREGISTRER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                command.ExecuteNonQuery()
                '----------------------

                '-----------------------LIGNE DE BORDEREAUX -----------------------------
                'TRANSFERT INTER MAGASINS
                '------------------------ LIGNE BORDEREAUX -----------------------------

                For i = 0 To GunaDataGridViewLigneFicheTechPreparation.Rows.Count - 1

                    'Defini plus bas selon si c'est une commande ou une reception
                    Dim CODE_LOT As String = ""
                    Dim NUM_SERIE_DEBUT As String = ""
                    Dim CODE_LIGNE As String = Functions.GeneratingRandomCode("bordereaux", "BC")

                    Dim CODE_ARTICLE As String = GunaDataGridViewLigneFicheTechPreparation.Rows(i).Cells("CODE ARTICLE").Value.ToString

                    Dim qte As Double = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("QUANTITE")

                    Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                    Dim entre_en_stock As Double = 0

                    Double.TryParse(GunaDataGridViewLigneFicheTechPreparation.Rows(i).Cells("QTE UTILISE").Value, entre_en_stock)

                    'Le BC est fonction de la grande unite et non de la petite donc une conversion est necessaire

                    Dim codeUniteDeComptageLigne As String = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("UNITE_COMPTAGE")

                    Dim prixParPetiteUniteLigne As DataTable = Functions.getElementByCode(codeUniteDeComptageLigne, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    Dim valeurUniteLigne As Double = 0

                    If prixParPetiteUniteLigne.Rows.Count > 0 Then
                        valeurUniteLigne = prixParPetiteUniteLigne.Rows(0)("VALEUR_NUMERIQUE")
                    End If

                    Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock / valeurUniteLigne 'QUANTITE EN MOVEMENT

                    Dim DATE_PEREMPTION As Date = GlobalVariable.DateDeTravail.AddDays(1)
                    'COUT ACHAT
                    Dim PRIX_UNITAIRE_HT As Double = Double.Parse(GunaDataGridViewLigneFicheTechPreparation.Rows(i).Cells("COUT ACHAT").Value)
                    'PRIX VENTE
                    Dim PRIX_UNITAIRE_TTC As Double = Double.Parse(GunaDataGridViewLigneFicheTechPreparation.Rows(i).Cells("COUT ACHAT").Value)
                    Dim PRIX_TOTAL_HT As Double = QUANTITE_ENTREE_STOCK * PRIX_UNITAIRE_HT 'PRIX TOTAL ACHAT

                    Dim infoSupArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")
                    Dim PRIX_TOTAL_TTC As Double = 0

                    If infoSupArticle.Rows.Count > 0 Then

                        PRIX_TOTAL_TTC = QUANTITE_ENTREE_STOCK * infoSupArticle.Rows(0)("COUT_U_MOYEN_PONDERE")
                        NUM_SERIE_DEBUT = infoSupArticle.Rows(0)("UNITE_COMPTAGE")

                        Dim infoSupUniteDeComptage As DataTable = Functions.getElementByCode(NUM_SERIE_DEBUT, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                        If infoSupUniteDeComptage.Rows.Count > 0 Then
                            NUM_SERIE_DEBUT = infoSupUniteDeComptage.Rows(0)("PETITE_UNITE")
                        End If

                    End If

                    'PRIX TOTAL VENTE

                    Dim NUM_SERIE_FIN As String = ""
                    Dim COUT_DU_STOCK As Double = PRIX_TOTAL_HT
                    'Insertion des informations des lignes du bordereau
                    If econom.insertLigneBordereau(CODE_BORDEREAUX, CODE_LIGNE, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE, QUANTITE_ENTREE_STOCK, DATE_PEREMPTION, PRIX_UNITAIRE_HT, PRIX_UNITAIRE_TTC, PRIX_TOTAL_HT, PRIX_TOTAL_TTC, NUM_SERIE_DEBUT, NUM_SERIE_FIN, COUT_DU_STOCK, CODE_SOUS_MAGASIN) Then

                    End If

                Next

            End If

            GunaDataGridViewLigneFiche.Columns.Clear()
            GunaTextBoxNomArticle.Clear()
            GunaTextBoxPrixVente.Clear()
            GunaTextBoxNombreDePortion.Text = 1
            GunaTextBoxLibelleFiche.Clear()

        Else

            'Mise à jour d'un bordereau

        End If

        '----------------------------------------------------------------------------

        listeDesFichesTechniques()

        GunaDataGridViewLigneFicheTechPreparation.Columns.Clear()

        'MessageBox.Show("Vous avez enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information)
        MessageBox.Show(NOM_ARTICLE + " preparé avec succès", "Fiche Technique", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub GunaTextBoxPrixVente_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPrixVente.TextChanged
        informationGeneraleFicheTechnique()
    End Sub

    'Choix de l'article pour l'ajout des elements de la fiche technique
    Private Sub GunaTextBoxNomArticle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNomArticle.TextChanged

        GunaDataGridViewArticleDeLaFicheTechnique.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxNomArticle.Text).Equals("") Then

            'GunaButtonEnregistrerFicheTechnique.Visible = False
            'GunaButtonImprimerFicheTechnique.Visible = False
            GunaDataGridViewArticleDeLaFicheTechnique.Visible = False
            GunaTextBoxQuantiteDeMatiere.Text = 1

            GunaTextBoxPrixVente.Clear()

        Else

            GunaButtonPreparationDePlat.Visible = True
            GunaButtonImprimerFicheTechnique.Visible = True

        End If

        getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxNomArticle.Text) & "%' AND TYPE =@TYPE AND CODE_FAMILLE IN ('ALIMENTS(REPAS)') ORDER BY DESIGNATION_FR ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewArticleDeLaFicheTechnique.DataSource = table
        Else
            GunaDataGridViewArticleDeLaFicheTechnique.Columns.Clear()
            GunaDataGridViewArticleDeLaFicheTechnique.Visible = False
        End If

    End Sub

    'Article de la fiche technique
    Private Sub GunaDataGridViewArticleDeLaFicheTechnique_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticleDeLaFicheTechnique.CellClick


        If e.RowIndex >= 0 Then

            'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
            'il disparait de nouveau après ajout a la facture
            'En plus il ne peut pas aparaitre pour les clients comptoire, si il n'est associé à aucun numéro de bloc_note

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewArticleDeLaFicheTechnique.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE DESIGNATION_FR=@DESIGNATION_FR AND TYPE=@TYPE ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@DESIGNATION_FR", MySqlDbType.VarChar).Value = row.Cells("DESIGNATION_FR").Value.ToString
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"

            adapter.SelectCommand = command
            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then
                'On determine si l'article est associe a une unite
                Dim uniteDeComptage As DataTable = Functions.getElementByCode(Article.Rows(0)("UNITE_COMPTAGE"), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If uniteDeComptage.Rows.Count > 0 Then

                Else

                End If

                GunaTextBoxCodeArticlePourFiche.Text = Article.Rows(0)("CODE_ARTICLE")
                GunaTextBoxNomArticle.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0")
                GunaTextBoxALaCarte.Text = Article.Rows(0)("CARTE")

                GunaDataGridViewArticleDeLaFicheTechnique.Visible = False

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid
                'clearArticleFields()

            End If

        End If

    End Sub

    Private Sub GunaTextBoxQuantiteADestocker_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNombreDePortion.TextChanged

        informationGeneraleFicheTechnique()

    End Sub

    Private Sub GunaTextBoxPMI_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPMI.TextChanged
        informationGeneraleFicheTechnique()
    End Sub

    'MODIFICATION DES FICHE TECHNIQUES


    'DETAILS D'UNE FICHE TECHNIQUE

    Private Sub listeDetailsDuneFichetechnique(ByVal CODE_FICHE_TECHNIQUE As String)

        Dim ficheTechniqueElements As New Article()

        GunaDataGridViewDetailFIcheTechnique.DataSource = ficheTechniqueElements.elementsDuneFicheTechnique(CODE_FICHE_TECHNIQUE)

        GunaDataGridViewDetailFIcheTechnique.Columns("QUANTITE UTILISE").DefaultCellStyle.Format = "#,##0"
        GunaDataGridViewDetailFIcheTechnique.Columns("QUANTITE UTILISE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        GunaDataGridViewDetailFIcheTechnique.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "#,##0"
        GunaDataGridViewDetailFIcheTechnique.Columns("COUT DE REVIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        GunaDataGridViewDetailFIcheTechnique.Columns("COUT ACHAT").DefaultCellStyle.Format = "#,##0"
        GunaDataGridViewDetailFIcheTechnique.Columns("COUT ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        GunaDataGridViewDetailFIcheTechnique.Columns("QTE / PORTION").DefaultCellStyle.Format = "#,##0"
        GunaDataGridViewDetailFIcheTechnique.Columns("QTE / PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GunaDataGridViewDetailFIcheTechnique.Columns("QTE / PORTION").DefaultCellStyle.Format = "n2"

        GunaDataGridViewDetailFIcheTechnique.Columns("CODE ARTICLE").Visible = False

    End Sub

    Dim CURRENT_CELL As String = ""

    Private Sub VoirLesDétailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoirLesDétailsToolStripMenuItem.Click

        If GunaDataGridViewFicheTechnique.Rows.Count > 0 Then

            CURRENT_CELL = GunaDataGridViewFicheTechnique.CurrentRow.Cells("CODE FICHE").Value.ToString

            Dim FICHE_TECHNIQUE As DataTable = Functions.getElementByCode(CURRENT_CELL, "fiche_technique", "CODE_FICHE_TECHNIQUE")

            If FICHE_TECHNIQUE.Rows.Count > 0 Then
                LabelFicheTecniqueADetailler.Text = FICHE_TECHNIQUE.Rows(0)("LIBELLE_FICHE")
                LabelFicheTecniqueADetailler.Visible = True
            Else
                LabelFicheTecniqueADetailler.Visible = False
            End If

            Dim CODE_FICHE_TECHNIQUE As String = CURRENT_CELL

            listeDetailsDuneFichetechnique(CODE_FICHE_TECHNIQUE)

            TabControlArticle.SelectedIndex = 4

        Else

            MessageBox.Show("Oups", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub TabControlArticle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlArticle.SelectedIndexChanged

        Dim title As String = ""
        'On supprime le contenu la grille de detail si c'est pas elle qu'on affiche
        If Not (TabControlArticle.SelectedIndex = 4) Then
            GunaDataGridViewDetailFIcheTechnique.Columns.Clear()
        End If

        If TabControlArticle.SelectedIndex = 0 Then

            If GlobalVariable.typeArticle = "article" Then
                title = "FICHE DE RENSEIGNEMENT D'ARTICLE / PLAT"

                Dim tableFicheTechnique As DataTable = Functions.allTableFieldsOrganised("fiche_technique", "LIBELLE_FICHE")

                If (tableFicheTechnique.Rows.Count > 0) Then

                    GunaComboBoxFicheTechnique.DataSource = tableFicheTechnique
                    'GunaComboBoxFicheTechnique.ValueMember = "CODE_FAMILLE"
                    GunaComboBoxFicheTechnique.ValueMember = "CODE_FICHE_TECHNIQUE"
                    GunaComboBoxFicheTechnique.DisplayMember = "LIBELLE_FICHE"

                End If

            ElseIf GlobalVariable.typeArticle = "matiere" Then
                title = "FICHE DE RENSEIGNEMENT DE MATIERE"
            End If


        ElseIf TabControlArticle.SelectedIndex = 1 Then

            title = " LISTE DES " + GlobalVariable.typeArticle.ToUpper() + "S"

        ElseIf TabControlArticle.SelectedIndex = 2 Then

            Dim TYPE_LIGNE_FACTURE As String = "fiche technique"
            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Functions.DeleteElementOnTwoConditions(CODE_UTILISATEUR_CREA, "ligne_facture_temp", "CODE_UTILISATEUR_CREA", "TYPE_LIGNE_FACTURE", TYPE_LIGNE_FACTURE)

            title = " FICHE TECHNIQUE DE PLAT "

        ElseIf TabControlArticle.SelectedIndex = 3 Then

            title = "LISTE DES FICHES TECHNIQUES DE PLAT"

        ElseIf TabControlArticle.SelectedIndex = 4 Then

            title = "DETAILS D'UNE FICHE TECHNIQUE DE PLAT"

        ElseIf TabControlArticle.SelectedIndex = 5 Then

            title = "COMMANDES DE LA CUISINE"

            'AFFICHAGE DES COMMANDES EN COURS OU EN ATTENTE
            commandeEncoursDePreparation()

            'AFFICHAGE DES COMMANDES PREPAREES
            commandePrepare()

            'AFFICHAGE DES INROMATIONS COMPLEMENTAIRES
            informationUtiles()

        End If

        GunaLabelGestCompteGeneraux.Text = title

    End Sub

    Public Sub commandePrepare()

        Dim FillingListquery2 = "SELECT `CODE_ARTICLE`, `NOM_ARTICLE` AS ARTICLE, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE` AS QUANTITE, `DATE_PREPARATION`, `ETAT`, `RANDOM_CODE` FROM `commande_cuisine` WHERE ETAT=@ETAT AND DATE_PREPARATION=@DATE_PREPARATION"

        Dim commandList2 As New MySqlCommand(FillingListquery2, GlobalVariable.connect)
        commandList2.Parameters.Add("@DATE_PREPARATION", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
        commandList2.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1
        'commandList.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = Trim(CODE_ENTREPRISE)

        Dim adapterList2 As New MySqlDataAdapter(commandList2)
        Dim tableList2 As New DataTable()

        adapterList2.Fill(tableList2)

        If tableList2.Rows.Count > 0 Then

            GunaDataGridViewCommandePreparee.Columns.Clear()

            GunaDataGridViewCommandePreparee.DataSource = tableList2

            GunaDataGridViewCommandePreparee.Columns("CODE_ARTICLE").Visible = False

            GunaDataGridViewCommandePreparee.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewCommandePreparee.Columns("DATE_PREPARATION").Visible = False
            GunaDataGridViewCommandePreparee.Columns("ETAT").Visible = False
            GunaDataGridViewCommandePreparee.Columns("CODE_FICHE_TECHNIQUE").Visible = False
            GunaDataGridViewCommandePreparee.Columns("RANDOM_CODE").Visible = False

        End If

    End Sub

    Public Sub commandeEncoursDePreparation()

        Dim FillingListquery = "SELECT `CODE_ARTICLE`, `NOM_ARTICLE` AS ARTICLE, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE` AS QUANTITE, `DATE_PREPARATION`, `ETAT`, `RANDOM_CODE` FROM `commande_cuisine` WHERE ETAT=@ETAT AND DATE_PREPARATION=@DATE_PREPARATION"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@DATE_PREPARATION", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
        commandList.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0
        'commandList.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = Trim(CODE_ENTREPRISE)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        If tableList.Rows.Count > 0 Then

            GunaDataGridViewCommandeEnCours.Columns.Clear()

            If tableList.Rows.Count = 1 Then
                GunaDataGridViewCommandeEnCours.Columns.Clear()
            End If

            GunaDataGridViewCommandeEnCours.DataSource = tableList

            GunaDataGridViewCommandeEnCours.Columns("CODE_ARTICLE").Visible = False
            GunaDataGridViewCommandeEnCours.Columns("DATE_PREPARATION").Visible = False

            GunaDataGridViewCommandeEnCours.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewCommandeEnCours.Columns("ETAT").Visible = False
            GunaDataGridViewCommandeEnCours.Columns("CODE_FICHE_TECHNIQUE").Visible = False
            GunaDataGridViewCommandeEnCours.Columns("RANDOM_CODE").Visible = False

        Else

            GunaDataGridViewCommandeEnCours.Columns.Clear()

        End If

    End Sub

    Private Sub GunaButton2_Click_2(sender As Object, e As EventArgs) Handles GunaButton2.Click

        'LISTE DES ARTICLES ET MATEIRES
        GunaTextBoxRefArticleMatiere.Clear()
        ArticleList()

    End Sub


    'Impression d'une fiche technique
    Private Sub GunaButtonImprimerFicheTechnique_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerFicheTechnique.Click

        Dim CTR As Double = GunaTextBoxTotaLPrixRevient.Text
        Dim PV As Double = GunaTextBoxPV.Text
        Dim CRPPP As Double = GunaTextBoxCRPP.Text
        Dim PMI As Double = GunaTextBoxPMI.Text
        Dim CM As Double = GunaTextBoxCM.Text
        Dim CRPPV As Double = GunaTextBoxPRPPV.Text
        Dim MB As Double = GunaTextBoxMB.Text
        Dim TM As Double = GunaTextBoxTM.Text
        Dim CODE_FICHE As String = ""
        Dim NOM_FICHE As String = GunaTextBoxLibelleFiche.Text

        Impression.ficheTechnique(GunaDataGridViewLigneFiche, NOM_FICHE, CODE_FICHE, GunaTextBoxNombreDePortion.Text, GunaTextBoxPrixVente.Text, CTR, PV, CRPPP, PMI, CM, CRPPV, MB, TM)

    End Sub

    Private Sub GunaButtonFicheDeStock_Click(sender As Object, e As EventArgs) Handles GunaButtonFicheDeStock.Click

        Dim articleFiche As New Article()

        Dim CODE_ARTICLE As String = Trim(GunaTextBoxCodeArticle.Text)

        'Dim article As DataTable = articleFiche.ficheDeStockDunProduitQuelConque(CODE_ARTICLE)
        Dim article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

        'Dim stock = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("QUANTITE")

        If article.Rows.Count > 0 Then
            Impression.ficheDeStock(article, GlobalVariable.DateDeTravail, GlobalVariable.DateDeTravail)
        Else
            MessageBox.Show("oups", "oups")
        End If

    End Sub

    'PRODUCTION DES PORTIONS OU DES FICHES TECHNIQUES
    Private Sub GunaCheckBoxPortion_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxPortion.CheckedChanged

        Dim TYPE_LIGNE_FACTURE As String = "fiche technique"
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Functions.DeleteElementOnTwoConditions(CODE_UTILISATEUR_CREA, "ligne_facture_temp", "CODE_UTILISATEUR_CREA", "TYPE_LIGNE_FACTURE", TYPE_LIGNE_FACTURE)

        If GunaCheckBoxPortion.Checked Then

            GunaComboBoxMagDestock.Visible = True
            GunaLabel63.Visible = True

            AutoLoadlisteMagasinSource()

            GunaComboBoxMagasinRecep.Visible = True
            GunaLabelMagasinDeDestination.Visible = True

            GunaCheckBoxFTPlusieursPlat.Visible = True

            GunaButtonCreationDeFiche.Visible = True

            Dim CODE_ARTICLE = GunaTextBoxCodeArticlePourFiche.Text

            Dim CODE_FACTURE As String = GunaTextBoxNumfacture.Text

            Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "CODE_ARTICLE", "CODE_FACTURE", CODE_FACTURE)

            'Portion
            GunaLabel8.Visible = True
            GunaTextBoxNomArticle.Visible = True
            GunaTextBoxNombreDePortion.Visible = True
            GunaTextBoxPrixVente.Visible = True
            GunaLabel9.Visible = True
            GunaLabel22.Visible = True
            GunaLabel33.Visible = True
            GunaTextBoxFicheTechnique.Visible = True
            GunaButtonCreationDeFiche.Visible = False
            GunaDataGridViewLigneFicheTechPreparation.Visible = True
            GunaTextBoxDescription.Visible = False
            GunaLabelDescription.Visible = False
            GunaTextBoxQuantiteDeMatiere.Visible = False

            'Fiche technique
            GunaLabel10.Visible = False
            GunaTextBoxArticleMatiere.Visible = False
            GunaButtonAjouterLigne.Visible = False
            GunaTextBoxArticleMatiere.Visible = False
            GunaLabelUniteDeComptage.Visible = False
            GunaTextBoxUniteDeComptage.Visible = False
            GunaLabel6.Visible = False
            GunaTextBoxQuantiteDeMatiere.Visible = False
            GunaLabel34.Visible = False
            GunaTextBoxLibelleFiche.Visible = False
            GunaButtonPreparationDePlat.Visible = True
            GunaDataGridViewLigneFiche.Visible = False

        Else

            GunaDataGridViewLigneFicheTechPreparation.Columns.Clear()

            GunaTextBoxQuantiteDeMatiere.Visible = False
            GunaComboBoxMagDestock.Visible = False
            GunaLabel63.Visible = False

            GunaButtonVisualierArticlePreparee.Visible = False

            GunaComboBoxMagasinRecep.Visible = False
            GunaLabelMagasinDeDestination.Visible = False

            GunaButtonCreationDeFiche.Visible = False

            'preparation
            GunaButtonCreationDeFiche.Visible = True
            GunaLabel8.Visible = False
            GunaTextBoxNomArticle.Visible = False
            GunaTextBoxNombreDePortion.Visible = False
            GunaTextBoxPrixVente.Visible = False
            GunaLabel9.Visible = False
            GunaLabel22.Visible = False
            GunaLabel33.Visible = False
            GunaTextBoxFicheTechnique.Visible = False
            GunaDataGridViewLigneFicheTechPreparation.Visible = False
            GunaTextBoxDescription.Visible = True
            GunaLabelDescription.Visible = True

            'Fiche technique
            GunaLabel10.Visible = True
            GunaButtonPreparationDePlat.Visible = False
            GunaTextBoxArticleMatiere.Visible = True
            GunaButtonAjouterLigne.Visible = True
            GunaTextBoxArticleMatiere.Visible = True
            GunaLabelUniteDeComptage.Visible = True
            GunaTextBoxUniteDeComptage.Visible = True
            GunaLabel6.Visible = True
            GunaTextBoxQuantiteDeMatiere.Visible = True
            GunaLabel34.Visible = True
            GunaTextBoxLibelleFiche.Visible = True
            GunaDataGridViewLigneFiche.Visible = True

            GunaTextBoxQuantiteDeMatiere.Visible = True

            GunaCheckBoxFTPlusieursPlat.Visible = False

        End If

        GunaDataGridViewLigneFiche.Columns.Clear()

        Functions.SiplifiedClearTextBox(Me)

        GunaTextBoxPMI.Text = 20
        GunaTextBoxDiversPourcentage.Text = 10
        GunaTextBoxNombreDePortion.Text = 1
        GunaTextBoxQuantiteDeMatiere.Text = 1
        GunaTextBoxTotaLPrixRevient.Text = 0

        '----------------------------------------------------------
        GunaTextBoxTotaLPrixRevient.Text = 0
        GunaTextBoxPV.Text = 0
        GunaTextBoxDiversMontant.Text = 0
        GunaTextBoxPRPPV.Text = 0
        GunaTextBoxMB.Text = 0
        GunaTextBoxTM.Text = 0
        GunaTextBoxCRPP.Text = 0
        GunaTextBoxMontanPourcentageInvendu.Text = 0
        GunaTextBoxCM.Text = 3
        PrixDeVenteFxnDuCoef.Checked = True

    End Sub

    'Choix d'une fiche technique pour un nombre de portion de donnee
    Private Sub GunaTextBox1_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxFicheTechnique.TextChanged

        GunaDataGridViewFiche.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getFicheQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxFicheTechnique.Text).Equals("") Then

            GunaDataGridViewFiche.Visible = False
            GunaTextBoxQuantiteDeMatiere.Text = 1
            GunaTextBoxCodeFicheTechnique.Clear()

            GunaDataGridViewLigneFicheTechPreparation.Columns.Clear()

            GunaTextBoxPMI.Text = 20
            GunaTextBoxDiversPourcentage.Text = 10
            GunaTextBoxNombreDePortion.Text = 1
            GunaTextBoxQuantiteDeMatiere.Text = 1
            GunaTextBoxTotaLPrixRevient.Text = 0

            '----------------------------------------------------------
            GunaTextBoxTotaLPrixRevient.Text = 0
            GunaTextBoxPV.Text = 0
            GunaTextBoxDiversMontant.Text = 0
            GunaTextBoxPRPPV.Text = 0
            GunaTextBoxMB.Text = 0
            GunaTextBoxTM.Text = 0
            GunaTextBoxCRPP.Text = 0
            GunaTextBoxMontanPourcentageInvendu.Text = 0
            GunaTextBoxCM.Text = 3
        Else

            GunaButtonPreparationDePlat.Visible = True
            GunaButtonImprimerFicheTechnique.Visible = True

        End If

        getFicheQuery = "SELECT LIBELLE_FICHE FROM fiche_technique WHERE LIBELLE_FICHE LIKE '%" & Trim(GunaTextBoxFicheTechnique.Text) & "%' ORDER BY LIBELLE_FICHE ASC"

        Dim Command As New MySqlCommand(getFicheQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewFiche.DataSource = table
        Else
            GunaDataGridViewFiche.Columns.Clear()
            GunaDataGridViewFiche.Visible = False
        End If

    End Sub

    'Apres selction d'une fiche techniaue pour preparation d'un nombre de portion
    Private Sub GunaDataGridViewFiche_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewFiche.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewFiche.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM fiche_technique WHERE LIBELLE_FICHE=@LIBELLE_FICHE ORDER BY LIBELLE_FICHE ASC"
            Dim adapter As New MySqlDataAdapter
            Dim fiche As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@LIBELLE_FICHE", MySqlDbType.VarChar).Value = row.Cells("LIBELLE_FICHE").Value.ToString
            adapter.SelectCommand = command
            adapter.Fill(fiche)

            If (fiche.Rows.Count > 0) Then

                Dim ficheTechniqueElements As New Article()

                GunaDataGridViewLigneFicheTechPreparation.Columns.Clear()
                GunaDataGridViewLigneFicheTechPreparation.Rows.Clear()

                GunaDataGridViewLigneFicheTechPreparation.Columns.Add("CODE ARTICLE", "CODE ARTICLE")
                GunaDataGridViewLigneFicheTechPreparation.Columns.Add("DESIGNATION", "DESIGNATION")
                GunaDataGridViewLigneFicheTechPreparation.Columns.Add("UNITE", "UNITE")
                GunaDataGridViewLigneFicheTechPreparation.Columns.Add("QTE UTILISE", "QTE UTILISE")
                GunaDataGridViewLigneFicheTechPreparation.Columns.Add("QTE / PORTION", "QTE / PORTION")
                GunaDataGridViewLigneFicheTechPreparation.Columns.Add("COUT DE REVIENT", "COUT DE REVIENT")
                GunaDataGridViewLigneFicheTechPreparation.Columns.Add("COUT ACHAT", "COUT ACHAT") 'PRIX ACHAT

                'GunaDataGridViewLigneFicheTechPreparation.DataSource = ficheTechniqueElements.elementsDuneFicheTechniquePourPreparation(fiche.Rows(0)("CODE_FICHE_TECHNIQUE"))
                Dim ficheTechElement As DataTable = ficheTechniqueElements.elementsDuneFicheTechniquePourPreparation(fiche.Rows(0)("CODE_FICHE_TECHNIQUE"))

                If ficheTechElement.Rows.Count > 0 Then

                    For i = 0 To ficheTechElement.Rows.Count - 1
                        GunaDataGridViewLigneFicheTechPreparation.Rows.Add(ficheTechElement(i)("CODE ARTICLE"), ficheTechElement(i)("DESIGNATION"), ficheTechElement(i)("UNITE"), ficheTechElement(i)("QTE UTILISE"), ficheTechElement(i)("QTE / PORTION") / GunaTextBoxNombreDePortion.Text, ficheTechElement(i)("COUT DE REVIENT"), ficheTechElement(i)("COUT ACHAT"))
                    Next

                Else

                End If


                GunaDataGridViewLigneFicheTechPreparation.Columns("COUT ACHAT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneFicheTechPreparation.Columns("COUT ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewLigneFicheTechPreparation.Columns("COUT ACHAT").DefaultCellStyle.Format = "n2"

                GunaDataGridViewLigneFicheTechPreparation.Columns("QTE UTILISE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneFicheTechPreparation.Columns("QTE UTILISE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewLigneFicheTechPreparation.Columns("QTE UTILISE").DefaultCellStyle.Format = "n2"

                GunaDataGridViewLigneFicheTechPreparation.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneFicheTechPreparation.Columns("COUT DE REVIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewLigneFicheTechPreparation.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "n2"
                GunaDataGridViewLigneFicheTechPreparation.Columns("QTE / PORTION").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneFicheTechPreparation.Columns("QTE / PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewLigneFicheTechPreparation.Columns("QTE / PORTION").DefaultCellStyle.Format = "n2"
                GunaDataGridViewLigneFicheTechPreparation.Columns("CODE ARTICLE").Visible = False
                GunaDataGridViewLigneFicheTechPreparation.Columns("COUT ACHAT").Visible = False

                'GunaTextBoxNombreDePortion.Text = fiche.Rows(0)("QUANTITE")

                GunaTextBoxDiversPourcentage.Text = fiche.Rows(0)("DIVERS_POURCENTAGE")
                GunaTextBoxDiversMontant.Text = fiche.Rows(0)("DIVERS_MONTANT")

                GunaTextBoxCodeFicheTechnique.Text = fiche.Rows(0)("CODE_FICHE_TECHNIQUE")

                GunaTextBoxFicheTechnique.Text = fiche.Rows(0)("LIBELLE_FICHE")

                GunaTextBoxTotaLPrixRevient.Text = Format(fiche.Rows(0)("CTR"), "#,##0")
                'GunaTextBoxPV.Text = Format(fiche.Rows(0)("PV"), "#,##0")
                GunaTextBoxCRPP.Text = Format(fiche.Rows(0)("CRPPP"), "#,##0")
                GunaTextBoxCM.Text = Format(fiche.Rows(0)("CM"), "#,##0.0")
                GunaTextBoxPRPPV.Text = Format(fiche.Rows(0)("CRPPV"), "#,##0")
                GunaTextBoxMB.Text = Format(fiche.Rows(0)("MB"), "#,##0")
                GunaTextBoxTM.Text = Format(fiche.Rows(0)("TM"), "#,##0")

                '-------------------------------
                If PrixDeVenteFxnDuCoef.Checked Then
                    GunaTextBoxPV.Text = Format(fiche.Rows(0)("CM") * fiche.Rows(0)("CRPPV"), "#,##0")
                Else
                    'LE PRIX DE VENTE PERMET DE DETERMINER LE COEFFICIENT DE MARGE 

                End If

                'GunaTextBoxTM.Text = Format((MB / (PVPPV * QTE)) * 100, "#,##0.0") '
                '-------------------------------

                GunaDataGridViewFiche.Visible = False

                'GunaTextBoxFicheTechnique.Text = ficheTechniqueElements.elementsDuneFicheTechnique(fiche.Rows(0)("CODE_FICHE_TECHNIQUE")).Rows(0)("")
            Else

                GunaDataGridViewLigneFicheTechPreparation.Visible = False

            End If

        End If

    End Sub

    Private Sub GunaButtonNonPreparation_Click(sender As Object, e As EventArgs) Handles GunaButtonCreationDeFiche.Click
        'Creation des fiches techniques
        Dim article As New Article()

        Dim LIBELLE_FICHE As String = GunaTextBoxLibelleFiche.Text
        Dim NOM_ARTICLE As String = GunaTextBoxNomArticle.Text
        Dim PRIX_VENTE As Double = Double.Parse(GunaTextBoxPrixVente.Text)
        Dim CODE_ARTICLE_FICHE As String = GunaTextBoxCodeArticlePourFiche.Text
        Dim QUANTITE_ARTICLE_FICHE As Integer = GunaTextBoxNombreDePortion.Text
        Dim CODE_FICHE_TECHNIQUE As String = Functions.GeneratingRandomCodeWithSpecifications("fiche_technique", "FT")
        Dim A_LA_CARTE As Integer = Integer.Parse(GunaTextBoxALaCarte.Text)
        Dim CTR As Double = GunaTextBoxTotaLPrixRevient.Text
        Dim PV As Double = GunaTextBoxPV.Text
        Dim CRPPP As Double = GunaTextBoxCRPP.Text
        Dim PMI As Double = GunaTextBoxPMI.Text
        Dim CM As Double = GunaTextBoxCM.Text
        Dim CRPPV As Double = GunaTextBoxPRPPV.Text
        Dim MB As Double = GunaTextBoxMB.Text
        Dim TM As Double = GunaTextBoxTM.Text
        Dim DESCRIPTION As String = GunaTextBoxDescription.Text
        Dim DIVERS_POURCENTAGE As Integer = GunaTextBoxDiversPourcentage.Text
        Dim DIVERS_MONTANT As Double = GunaTextBoxDiversMontant.Text

        If GunaButtonCreationDeFiche.Text = "Enregistrer" Then
            MessageBox.Show("Fiche Technique enregistrée avec succès", "Fiche Technique", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            'CURRENT_CELL = GunaDataGridViewFicheTechnique.CurrentRow.Cells("CODE FICHE").Value.ToString
            CURRENT_CELL = GunaTextBoxCodeFicheTechnique.Text

            'SUPPRESSION DE LES FICHES
            Functions.DeleteElementByCode(CURRENT_CELL, "fiche_technique_ligne", "CODE_FICHE_TECHNIQUE")

            'SUPPRESSION DE LES LIGNES DE FICHE
            Functions.DeleteElementByCode(CURRENT_CELL, "fiche_technique", "CODE_FICHE_TECHNIQUE")

            MessageBox.Show("Fiche Technique mise à jours avec succès", "Fiche Technique", MessageBoxButtons.OK, MessageBoxIcon.Information)

            GunaButtonCreationDeFiche.Text = "Enregistrer"

            GunaTextBoxCodeFicheTechnique.Clear()

        End If

        article.insertFicheTechnique(LIBELLE_FICHE, NOM_ARTICLE, PRIX_VENTE, CODE_FICHE_TECHNIQUE, CODE_ARTICLE_FICHE, QUANTITE_ARTICLE_FICHE, CTR, PV, CRPPP, PMI, CM, CRPPV, MB, TM, DESCRIPTION, DIVERS_POURCENTAGE, DIVERS_MONTANT)

        'Insertion des matieres de la fiche technique
        For i = 0 To GunaDataGridViewLigneFiche.Rows.Count - 1

            Dim CODE_ARTICLE As String = GunaDataGridViewLigneFiche.Rows(i).Cells("CODE ARTICLE").Value.ToString
            Dim UNITE_COMPTAGE As String = GunaDataGridViewLigneFiche.Rows(i).Cells("UNITE").Value
            Dim QUANTITE As Double = GunaDataGridViewLigneFiche.Rows(i).Cells("QTE UTILISE").Value
            Dim PRIX_ACHAT As Double = GunaDataGridViewLigneFiche.Rows(i).Cells("PRIX ACHAT").Value
            Dim PRIX_REVIENT As Double = GunaDataGridViewLigneFiche.Rows(i).Cells("COUT DE REVIENT").Value
            Dim QUANTITE_PAR_PORTION As Double = GunaDataGridViewLigneFiche.Rows(i).Cells("QTE / PORTION").Value

            article.insertLigneFicheTechnique(CODE_FICHE_TECHNIQUE, CODE_ARTICLE, UNITE_COMPTAGE, QUANTITE, PRIX_ACHAT, PRIX_REVIENT, QUANTITE_PAR_PORTION)

        Next

        Functions.SiplifiedClearTextBox(Me)

        GunaTextBoxQuantiteDeMatiere.Text = 1

        GunaDataGridViewLigneFiche.Columns.Clear()

        'Suppression de la table temporaire utilisée contenant les lignes d'une fiche technique

        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Functions.DeleteElementOnTwoConditions("fiche technique", "ligne_facture_temp", "TYPE_LIGNE_FACTURE", "CODE_UTILISATEUR_CREA", CODE_UTILISATEUR_CREA)

        GunaDataGridViewFicheTechnique.Columns.Clear()
        GunaDataGridViewLigneFiche.Columns.Clear()

        GunaTextBoxDiversPourcentage.Text = 10
        GunaTextBoxPMI.Text = 20
        GunaTextBoxMB.Text = 0
        GunaTextBoxTM.Text = 0
        GunaTextBoxTotaLPrixRevient.Text = 0
        GunaTextBoxPRPPV.Text = 0
        GunaTextBoxCM.Text = 0

        ficheTechniqueListe()

    End Sub

    'RETOUR A LA LISTE DE FICHES TECHNIQUES APRES VISUALISATION DES DETAILS
    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        TabControlArticle.SelectedIndex = 3
    End Sub

    'SUPPRESSION DES FICHES TECHNIQUES
    Private Sub SupprimerFicheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerFicheToolStripMenuItem.Click

        If GunaDataGridViewFicheTechnique.Rows.Count > 0 Then

            Dim CODE_FICHE As String = GunaDataGridViewFicheTechnique.CurrentRow.Cells("CODE FICHE").Value.ToString
            Dim LIBELLE_FICHE As String = GunaDataGridViewFicheTechnique.CurrentRow.Cells("LIBELLE FICHE").Value.ToString

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supprimer la fiche technique : " & GunaDataGridViewFicheTechnique.CurrentRow.Cells("LIBELLE FICHE").Value.ToString, "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                'SUPRESSION DE LA FICHE TECHNIQUE
                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewFicheTechnique, CODE_FICHE, "fiche_technique", "CODE_FICHE_TECHNIQUE")

                'SUPPRESSION DES LIGNES DE LA FICHE SUPPRIMEE
                Functions.DeleteElementByCode(CODE_FICHE, "fiche_technique_ligne", "CODE_FICHE_TECHNIQUE")

                GunaDataGridViewFicheTechnique.Columns.Clear()
                GunaTextBoxSearchFicheTechnique.Clear()

                ficheTechniqueListe()

                MessageBox.Show("Vous avez supprimé " & LIBELLE_FICHE & " avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    'SUPPRESSION D'UNE LIGNE DES DETAILS D'UNE FICHE TECHNIQUE
    Private Sub SupprimerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem1.Click

        If GunaDataGridViewDetailFIcheTechnique.Rows.Count > 0 Then

            Dim CODE_FICHE As String = CURRENT_CELL
            Dim CODE_ARTICLE As String = GunaDataGridViewDetailFIcheTechnique.CurrentRow.Cells("CODE ARTICLE").Value.ToString
            Dim LIBELLE_FICHE As String = GunaDataGridViewDetailFIcheTechnique.CurrentRow.Cells("DESIGNATION").Value.ToString

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supprimer l'article: " & LIBELLE_FICHE & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                'SUPPRESSION DES LIGNES DE LA FICHE SUPPRIMEE
                Functions.DeleteElementOnTwoConditions(CODE_FICHE, "fiche_technique_ligne", "CODE_FICHE_TECHNIQUE", "CODE_ARTICLE", CODE_ARTICLE)

                GunaDataGridViewDetailFIcheTechnique.Columns.Clear()

                listeDetailsDuneFichetechnique(CODE_FICHE)

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    'MODIFICATION D'UN ELEMENT DE LA FICHE TECHNIQUE
    Private Sub GunaDataGridViewLigneFicheTechPreparation_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLigneFicheTechPreparation.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewLigneFicheTechPreparation.Rows(e.RowIndex)

            Dim CODE_ARTICLE As String = row.Cells("CODE ARTICLE").Value.ToString

            Dim infoArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

            If infoArticle.Rows.Count > 0 Then

                GunaTextBoxArticleMatiere.Text = infoArticle.Rows(0)("DESIGNATION")
                GunaTextBoxCodeArticlePourFiche.Text = infoArticle.Rows(0)("CODE ARTICLE")
                GunaTextBoxQuantiteDeMatiere.Text = infoArticle.Rows(0)("QTE UTILISE")

                GunaTextBoxMontantHT.Text = infoArticle.Rows(0)("PRIX_ACHAT_HT")

            End If

        End If

    End Sub

    Dim notFirstChange As Boolean = False

    Private Sub GunaDataGridViewLigneFiche_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLigneFiche.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewLigneFiche.Rows(e.RowIndex)

            Dim CODE_ARTICLE As String = row.Cells("CODE ARTICLE").Value.ToString

            GunaTextBoxArticleMatiere.Text = row.Cells("DESIGNATION").Value.ToString
            GunaTextBoxCodeArticlePourFiche.Text = row.Cells("CODE ARTICLE").Value.ToString
            GunaTextBoxQuantiteDeMatiere.Text = row.Cells("QTE UTILISE").Value

            GunaTextBoxUniteDeComptage.Text = row.Cells("UNITE").Value.ToString

            GunaTextBoxMontantHT.Text = row.Cells("PRIX ACHAT").Value

            Dim PETITE_UNITE As String = row.Cells("UNITE").Value.ToString

            'GunaComboBoxPetiteUniteComptage.Visible = True

            'GunaLabelModifPetiteUnite.Visible = True

            GunaDataGridViewArticleAAjouter.Visible = False

            GunaLabelUniteDeComptage.Text = "Unité actuelle"

            GunaButtonAjouterLigne.Text = "Modifier"

            Dim infoUniteArticle As DataTable = Functions.getElementByCode(PETITE_UNITE, "unite_comptage", "PETITE_UNITE")

            If infoUniteArticle.Rows.Count > 0 Then

                GunaTextBoxCodeUniteComptage.Text = infoUniteArticle.Rows(0)("CODE_UNITE_DE_COMPTAGE")

                Dim autresUnite As DataTable = Functions.allTableFieldsOrganised("unite_comptage", "PETITE_UNITE")

                If autresUnite.Rows.Count > 0 Then

                    GunaComboBoxPetiteUniteComptage.DataSource = autresUnite
                    GunaComboBoxPetiteUniteComptage.ValueMember = "CODE_UNITE_DE_COMPTAGE"
                    GunaComboBoxPetiteUniteComptage.DisplayMember = "PETITE_UNITE"

                    GunaComboBoxPetiteUniteComptage.SelectedIndex = -1

                End If

            End If

        End If

    End Sub

    'EN CAS DE CHANGEMENT DE PETITE UNITE
    Private Sub GunaComboBoxPetiteUniteComptage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxPetiteUniteComptage.SelectedIndexChanged

        If notFirstChange Then

            If GunaComboBoxPetiteUniteComptage.SelectedIndex >= 0 Then

                Dim CODE_UNITE As String = Trim(GunaComboBoxPetiteUniteComptage.SelectedValue.ToString)

                Dim infoPetiteUnite As DataTable = Functions.getElementByCode(CODE_UNITE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If infoPetiteUnite.Rows.Count > 0 Then

                    'GunaTextBoxUniteDeComptage.Text = infoPetiteUnite.Rows(0)("PETITE_UNITE")

                    GunaTextBoxCodeUniteComptage.Text = infoPetiteUnite.Rows(0)("CODE_UNITE_DE_COMPTAGE")

                End If

                'GunaTextBoxCodeUniteComptage.Text = GunaComboBoxPetiteUniteComptage.SelectedValue
            End If

        End If

        notFirstChange = True

    End Sub

    Private Sub GunaComboBoxUniteDeCompatage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUniteDeCompatage.SelectedIndexChanged

        If GunaComboBoxUniteDeCompatage.SelectedIndex >= 0 Then

            Dim CODE_UNITE = GunaComboBoxUniteDeCompatage.SelectedValue.ToString

            Dim UNITE As DataTable = Functions.getElementByCode(CODE_UNITE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

            Dim conso As Boolean = False

            If UNITE.Rows.Count > 0 Then

                GunaTextBoxUniteDeStockage.Text = UNITE.Rows(0)("PETITE_UNITE")

                If UNITE.Rows(0)("VALEUR_NUMERIQUE") > 0 Then

                    If GunaCheckBoxBoisson.Checked Then
                        conso = True
                    End If
                End If

            End If

            If Not conso Then
                GunaLabelStockEnConso.Visible = False
                GunaTextBoxStockEnConso.Visible = False
                GunaTextBoxStockEnConso.Text = 0
            End If

        Else
            GunaTextBoxUniteDeStockage.Clear()
        End If

    End Sub

    'DEPLACEMENT APRES MISE A JOURS

    Private Sub GunaButtonMoveLeftToRight_Click(sender As Object, e As EventArgs)

        If GunaDataGridViewCommandeEnCours.SelectedRows.Count > 0 Then

            Dim selectedgrid As DataGridViewRow = GunaDataGridViewCommandeEnCours.SelectedRows(0)
            GunaDataGridViewCommandeEnCours.Rows.Remove(selectedgrid)
            GunaDataGridViewCommandePreparee.Rows.Add(selectedgrid)

        End If

    End Sub

    Private Sub GunaButtonAllToLeft_Click(sender As Object, e As EventArgs)

        If GunaDataGridViewCommandePreparee.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewCommandePreparee.SelectedRows(0)
            GunaDataGridViewCommandePreparee.Rows.Remove(selectedgrid)
            GunaDataGridViewCommandeEnCours.Rows.Add(selectedgrid)
        End If

    End Sub

    'ENREGISTREMENT DE MENU DU JOUR
    Private Sub GunaButtonCloturerFolio2_Click(sender As Object, e As EventArgs) Handles GunaButtonCloturerFolio2.Click

        Dim article As New Article()

        For i = 0 To GunaDataGridViewCommandePreparee.Rows.Count - 1


            Dim CODE_MENU As String = Functions.GeneratingRandomCode("menu_du_jour", "")
            Dim CODE_FICHE_TECHNIQUE As String = GunaDataGridViewCommandePreparee.Rows(i).Cells("DataGridViewTextBoxColumn2").Value.ToString()
            Dim LIBELLE_FICHE As String = GunaDataGridViewCommandePreparee.Rows(i).Cells("DataGridViewTextBoxColumn1").Value.ToString()
            Dim DATE_DU_JOUR As Date = GlobalVariable.DateDeTravail

            article.meneDuJour(CODE_MENU, CODE_FICHE_TECHNIQUE, LIBELLE_FICHE, DATE_DU_JOUR)

        Next

        GunaDataGridViewCommandePreparee.Rows.Clear()

    End Sub

    'VISUALISATION DES ARTICLES / PPLAT / MATIERES EXISTANTES
    Private Sub GunaTextBoxDesignation_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxDesignation.TextChanged

        If GunaButtonEnregistrer.Text = "Enregistrer" And Trim(GunaTextBoxDesignation.Text).Equals("") Then
            GunaTextBoxDesignation.Clear()
            GunaDataGridViewExisting.Visible = False
            GunaDataGridViewExisting.Columns.Clear()
        End If

        If Not Trim(GunaTextBoxDesignation.Text).Equals("") Then

            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim getArticleQuery As String = ""

            'Si l'article n'existe pas alors on efface toute les informations le concernant

            getArticleQuery = "SELECT CODE_ARTICLE AS 'CODE', DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxDesignation.Text) & "%' AND TYPE =@TYPE ORDER BY DESIGNATION_FR ASC"

            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeArticle
            adapter.SelectCommand = Command
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                GunaDataGridViewExisting.Visible = True
                GunaDataGridViewExisting.DataSource = table

                GunaDataGridViewExisting.Columns("CODE").Visible = False
            Else
                GunaDataGridViewExisting.Columns.Clear()
                GunaDataGridViewExisting.Visible = False
            End If

            If GunaTextBoxDesignation.Text = "" Then
                GunaDataGridViewExisting.Visible = False
            End If
        End If

    End Sub

    Private Sub GunaDataGridViewExisting_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewExisting.CellClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Sauvegarder"

            If GunaButtonEnregistrer.Text = "Sauvegarder" Then
                GunaButtonFicheDeStock.Visible = True
            Else
                GunaButtonFicheDeStock.Visible = False
            End If

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewExisting.Rows(e.RowIndex)

            'TabControlArticle.SelectedIndex = 0

            Dim Article As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE").Value.ToString), "article", "CODE_ARTICLE")

            If Article.Rows.Count > 0 Then

                GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")
                GunaComboBoxSuiviStock.SelectedItem = Article.Rows(0)("METHODE_SUIVI_STOCK")
                GunaTextBoxDesignation.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxCUMP.Text = Format(Article.Rows(0)("PRIX_ACHAT_HT"), "#,##0")
                GunaTextBoxVenteHT.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0")
                GunaTextBoxVenteHT2.Text = Format(Article.Rows(0)("PRIX_VENTE1_HT"), "#,##0")
                GunaTextBoxVenteHT3.Text = Format(Article.Rows(0)("PRIX_VENTE2_HT"), "#,##0")
                GunaTextBoxVenteHT4.Text = Format(Article.Rows(0)("PRIX_VENTE3_HT"), "#,##0")
                GunaTextBoxNumSerie.Text = Article.Rows(0)("NUMERO_SERIE")
                GunaTextBoxStockReaProPetitMagasin.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT_PETIT_MAGASIN")
                GunaTextBoxStockReapproGrandMagasin.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")
                GunaTextBoxStock.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.00")
                GunaComboBoxTypeArticle.SelectedValue = Article.Rows(0)("TYPE_ARTICLE")

                If Article.Rows(0)("TYPE").Equals("article") Then
                    GunaComboBoxArticleMatiere.SelectedIndex = 0
                ElseIf Article.Rows(0)("TYPE").Equals("matiere") Then
                    GunaComboBoxArticleMatiere.SelectedIndex = 1
                End If

                'VISIBILITE

                If Article.Rows(0)("VISIBLE") = 1 Then
                    GunaCheckBoxVisibiliteAuBar.Checked = True
                Else
                    GunaCheckBoxVisibiliteAuBar.Checked = False
                End If

                GunaComboBoxCategorieArticle.SelectedValue = Article.Rows(0)("CODE_FAMILLE")

                GunaComboBoxSousFamilleArticle.SelectedValue = Article.Rows(0)("CODE_SOUS_FAMILLE") 'REFERENCE CONTAINS THE SOUS FAMILLE CODE

                GunaComboBoxUniteDeCompatage.SelectedValue = Article.Rows(0)("UNITE_COMPTAGE") 'CODE DE L'UNITE DE COMTAGE
                GunaTextBoxCodeBarre.Text = Article.Rows(0)("CODE_BARRE")
                GunaTextBoxPrixAchat.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0")

                'ON CHARGE D'ABORDS TOUTES LES SOUS SOUS FAMILLE AVANT D'EN CHOISIR UNE

                '--------------------------------------------------------------

                Dim SousFamille As DataTable = Functions.GetAllElementsOnCondition(GunaComboBoxSousFamilleArticle.SelectedValue, "sous_sous_famille", "CODE_FAMILLE_PARENT")

                If (SousFamille.Rows.Count > 0) Then

                    GunaComboBoxLastLevelArticle.DataSource = SousFamille
                    GunaComboBoxLastLevelArticle.ValueMember = "LIBELLE_FAMILLE"
                    'GunaComboBoxLastLevelArticle.ValueMember = "CODE_SOUS_FAMILLE"
                    GunaComboBoxLastLevelArticle.DisplayMember = "LIBELLE_FAMILLE"

                Else
                    GunaComboBoxLastLevelArticle.SelectedValue = -1
                End If

                '--------------------------------------------------------------

                GunaComboBoxLastLevelArticle.SelectedValue = Article.Rows(0)("CODE_SOUS_SOUS_FAMILLE")

                If Not Trim(Article.Rows(0)("CODE_CONSO")) = "" Then
                    GunaComboBoxUniteDeConsommation.SelectedValue = Article.Rows(0)("CODE_CONSO")
                End If

                GunaTextBoxPrixConso1.Text = Format(Article.Rows(0)("PRIX_CONSO"), "#,##0")
                GunaTextBoxPrixConso2.Text = Format(Article.Rows(0)("PRIX_CONSO2"), "#,##0")
                GunaTextBoxPrixConso3.Text = Format(Article.Rows(0)("PRIX_CONSO3"), "#,##0")
                GunaTextBoxPrixConso4.Text = Format(Article.Rows(0)("PRIX_CONSO4"), "#,##0")

                If Article.Rows(0)("CARTE") = 1 Then 'ARTICLE DONT LE DESTOCKAGE SE FAIT A LA VENTE

                    GunaCheckBoxAlaCarte.Checked = True

                    GunaComboBoxFicheTechnique.SelectedValue = Article.Rows(0)("CODE_CLE") ' CODE DE LA FICHE TECHNIQUE DONT DEPEND L'ARTICLE

                Else
                    GunaCheckBoxAlaCarte.Checked = False 'ARTICLE DONT LE DESTOCKAGE SE FAIT A LA PREPARATION DE L'ARTICLE
                End If

                GunaTextBoxContenance.Text = Article.Rows(0)("CONTENANCE")

                If Article.Rows(0)("BOISSON") = 1 Then

                    '-----------------------------------------------------------------------------------------------------------------------
                    GunaCheckBoxBoisson.Checked = True
                    Dim nombreDeBouteille As Double = 0
                    Dim nombreDeConso As Integer = 0
                    Dim nombreDeConsoTotal As Integer = Article.Rows(0)("QUANTITE")
                    Dim contenance As Double = Double.Parse(GunaTextBoxContenance.Text)
                    Dim valeurConversion As Double = Double.Parse(GunaTextBoxValeurUniteConso.Text)

                    Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                    If nombreDeConsoDansUneBouteille > 0 Then
                        nombreDeBouteille = Int(nombreDeConsoTotal / nombreDeConsoDansUneBouteille)
                        nombreDeConso = nombreDeConsoTotal Mod nombreDeConsoDansUneBouteille
                    End If

                    GunaTextBoxStock.Text = Format(nombreDeBouteille, "#,##0.0")
                    GunaTextBoxStockEnConso.Text = Format(nombreDeConso, "#,##0.0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS
                    '------------------------------------------------------------------------------------------------------------------------

                Else
                    GunaCheckBoxBoisson.Checked = False
                    GunaTextBoxStock.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.0")
                End If

                If Not IsDBNull(Article.Rows(0)("IMAGE_1")) Then 'IMAGE DEPUIS VBNET

                    Dim img() As Byte
                    img = Article.Rows(0)("IMAGE_1")

                    Dim mStream As New MemoryStream(img)

                    If mStream.Length > 0 Then
                        GunaPictureBoxLogo.Image = Image.FromStream(mStream)
                    End If

                End If

            End If

        End If

        GunaTextBoxRefArticleMatiere.Text = ""
        GunaDataGridViewExisting.Visible = False
        GunaDataGridViewExisting.Columns.Clear()

    End Sub

    Private Sub GunaTextBoxDesignation_Validated(sender As Object, e As EventArgs) Handles GunaTextBoxDesignation.Validated
        'GunaDataGridViewExisting.Visible = False
    End Sub

    Public Sub uniteDeConsommation()

        'Dim uniteDeComptage As DataTable = Functions.allTableFields("unite_comptage")
        Dim uniteDeComptage As DataTable = Functions.allTableFieldsOnConditionOrganised("unite_comptage", "TYPE", "Consommation", "GRANDE_UNITE")

        If (uniteDeComptage.Rows.Count > 0) Then

            GunaComboBoxUniteDeConsommation.DataSource = uniteDeComptage
            'GunaComboBoxUniteDeConsommation.ValueMember = "CODE_FAMILLE"
            GunaComboBoxUniteDeConsommation.ValueMember = "CODE_UNITE_DE_COMPTAGE"
            GunaComboBoxUniteDeConsommation.DisplayMember = "GRANDE_UNITE"

        End If

    End Sub

    Private Sub GunaComboBoxUniteDeConsommation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUniteDeConsommation.SelectedIndexChanged

        If Not GunaComboBoxUniteDeConsommation.SelectedValue.ToString Is Nothing Then

            Dim CODE_UNITE As String = GunaComboBoxUniteDeConsommation.SelectedValue.ToString

            Dim UNITE As DataTable = Functions.getElementByCode(CODE_UNITE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

            If UNITE.Rows.Count > 0 Then
                GunaTextBoxValeurUniteConso.Text = UNITE.Rows(0)("VALEUR_NUMERIQUE")
            End If

            nombreDeConsoDelaContenanceEtLeStockEnConso()

        End If

    End Sub

    Private Sub nombreDeConsoDelaContenanceEtLeStockEnConso()

        If GunaCheckBoxBoisson.Checked Then

            'Calcul de la quantie En Stock En Consommation

            If Trim(GunaTextBoxStock.Text) = "" Then
                GunaTextBoxStock.Text = 0
            End If

            If Trim(GunaTextBoxValeurUniteConso.Text) = "" Then
                GunaTextBoxValeurUniteConso.Text = 0
            End If

            If Trim(GunaTextBoxStockEnConso.Text) = "" Then
                GunaTextBoxStockEnConso.Text = 0
            End If

            If Trim(GunaTextBoxContenance.Text) = "" Then
                GunaTextBoxContenance.Text = 0
            End If

            If Trim(GunaTextBoxNbreConso.Text) = "" Then
                GunaTextBoxNbreConso.Text = 0
            End If

            If Double.Parse(GunaTextBoxValeurUniteConso.Text) > 0 Then

                Dim nombreDeConso As Integer = Double.Parse(GunaTextBoxContenance.Text) / Double.Parse(GunaTextBoxValeurUniteConso.Text)
                GunaTextBoxNbreConso.Text = Format(Math.Floor(nombreDeConso), "#,##0")
                'GunaTextBoxStockEnConso.Text = Format(Double.Parse(GunaTextBoxContenance.Text) / Double.Parse(GunaTextBoxValeurUniteConso.Text) * GunaTextBoxStock.Text, "#,##0")
                'GunaTextBoxStockEnConso.Text = Format(Math.Floor(nombreDeConso) * GunaTextBoxStock.Text, "#,##0")

                'ECLATEMENT EN BOUTEILLE ET CONSOMMATION

            End If

        End If

    End Sub

    Private Sub GunaCheckBoxBoisson_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxBoisson.CheckedChanged

        If GunaCheckBoxBoisson.Checked Then

            GunaLabel39.Visible = True
            GunaTextBoxContenance.Visible = True
            GunaLabel40.Visible = True
            GunaLabel37.Visible = True
            GunaLabel37.Visible = True
            GunaLabel36.Visible = True
            GunaLabel29.Visible = True
            GunaLabel38.Visible = True
            GunaTextBoxValeurUniteConso.Visible = True
            GunaTextBoxPrixConso1.Visible = True

            GunaComboBoxUniteDeConsommation.Visible = True

            GunaLabelStockEnConso.Visible = True
            GunaTextBoxStockEnConso.Visible = True

            GunaLabelNbreDeConso.Visible = True
            GunaTextBoxNbreConso.Visible = True

            nombreDeConsoDelaContenanceEtLeStockEnConso()

            GunaTextBoxPrixConso2.Visible = True
            GunaTextBoxPrixConso3.Visible = True
            GunaTextBoxPrixConso4.Visible = True

            GunaLabel57.Visible = True
            GunaLabel58.Visible = True
            GunaLabel59.Visible = True

        Else

            GunaTextBoxNbreConso.Text = 0
            GunaTextBoxPrixConso1.Text = 0
            GunaTextBoxStockEnConso.Text = 0

            GunaLabel39.Visible = False
            GunaTextBoxContenance.Visible = False
            GunaLabel40.Visible = False
            GunaLabel37.Visible = False
            GunaLabel37.Visible = False
            GunaLabel36.Visible = False
            GunaLabel29.Visible = False
            GunaLabel38.Visible = False
            GunaTextBoxValeurUniteConso.Visible = False
            GunaTextBoxPrixConso1.Visible = False
            GunaComboBoxUniteDeConsommation.Visible = False

            GunaLabelStockEnConso.Visible = False
            GunaTextBoxStockEnConso.Visible = False

            GunaLabelNbreDeConso.Visible = False
            GunaTextBoxNbreConso.Visible = False

            '------------------------------

            GunaTextBoxPrixConso2.Visible = False
            GunaTextBoxPrixConso3.Visible = False
            GunaTextBoxPrixConso4.Visible = False

            GunaLabel57.Visible = False
            GunaLabel58.Visible = False
            GunaLabel59.Visible = False

        End If

    End Sub

    Private Sub GunaTextBoxContenance_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxContenance.TextChanged
        nombreDeConsoDelaContenanceEtLeStockEnConso()
    End Sub

    Private Sub GunaCheckBoxAlaCarte_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxAlaCarte.CheckedChanged

        If GunaCheckBoxAlaCarte.Checked Then
            GunaComboBoxFicheTechnique.Visible = True
            GunaLabelFicheTechnique.Visible = True
            GunaPanelConseil.Visible = True

            If GunaComboBoxFicheTechnique.Items.Count > 0 Then
                GunaComboBoxFicheTechnique.SelectedIndex = -1
            Else
                GunaComboBoxFicheTechnique.SelectedIndex = -1
            End If

        Else
            GunaComboBoxFicheTechnique.Visible = False
            GunaLabelFicheTechnique.Visible = False
            GunaPanelConseil.Visible = False
        End If

    End Sub

    Private Sub GunaTextBoxDiversPourcentage_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxDiversPourcentage.TextChanged
        informationGeneraleFicheTechnique()
    End Sub

    'AFFICHAGE DES MATIERES D'UNE FICHE TECHNIQUE POUR UN ARTICLE ASSOCIE A UNE FICHE TECHNIQUE

    Private Sub GunaDataGridViewCommandeEnCours_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewCommandeEnCours.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewCommandeEnCours.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM fiche_technique WHERE CODE_FICHE_TECHNIQUE=@CODE_FICHE_TECHNIQUE ORDER BY LIBELLE_FICHE ASC"
            Dim adapter As New MySqlDataAdapter
            Dim fiche As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim QUANTITE As Double = Double.Parse(row.Cells("QUANTITE").Value)

            command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = row.Cells("CODE_FICHE_TECHNIQUE").Value.ToString
            adapter.SelectCommand = command
            adapter.Fill(fiche)

            If (fiche.Rows.Count > 0) Then

                Dim ficheTechniqueElements As New Article()

                GunaDataGridViewMatieresArticle.Columns.Clear()
                GunaDataGridViewMatieresArticle.Rows.Clear()

                'AJOUTS DES COLUMNS

                GunaDataGridViewMatieresArticle.Columns.Add("CODE ARTICLE", "CODE ARTICLE")
                GunaDataGridViewMatieresArticle.Columns.Add("DESIGNATION", "DESIGNATION")
                GunaDataGridViewMatieresArticle.Columns.Add("UNITE", "UNITE")
                GunaDataGridViewMatieresArticle.Columns.Add("QTE UTILISE", "QTE UTILISE")
                GunaDataGridViewMatieresArticle.Columns.Add("QTE / PORTION", "QTE / PORTION")
                GunaDataGridViewMatieresArticle.Columns.Add("COUT DE REVIENT", "COUT DE REVIENT")
                GunaDataGridViewMatieresArticle.Columns.Add("COUT ACHAT", "COUT ACHAT") 'PRIX ACHAT

                'GunaDataGridViewMatieresArticle.DataSource = ficheTechniqueElements.elementsDuneFicheTechniquePourPreparation(fiche.Rows(0)("CODE_FICHE_TECHNIQUE"))
                Dim ficheTechElement As DataTable = ficheTechniqueElements.elementsDuneFicheTechniquePourPreparation(fiche.Rows(0)("CODE_FICHE_TECHNIQUE"))

                Dim coutTotalDeProduction As Double = 0

                If ficheTechElement.Rows.Count > 0 Then

                    For i = 0 To ficheTechElement.Rows.Count - 1
                        GunaDataGridViewMatieresArticle.Rows.Add(ficheTechElement(i)("CODE ARTICLE"), ficheTechElement(i)("DESIGNATION"), ficheTechElement(i)("UNITE"), ficheTechElement(i)("QTE UTILISE") * QUANTITE, ficheTechElement(i)("QTE / PORTION"), ficheTechElement(i)("COUT DE REVIENT") * QUANTITE, ficheTechElement(i)("COUT ACHAT") * QUANTITE)

                        coutTotalDeProduction += ficheTechElement(i)("COUT DE REVIENT") * QUANTITE

                    Next

                End If

                GunaDataGridViewMatieresArticle.Columns("COUT ACHAT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewMatieresArticle.Columns("COUT ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewMatieresArticle.Columns("COUT ACHAT").DefaultCellStyle.Format = "n2"

                GunaDataGridViewMatieresArticle.Columns("QTE UTILISE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewMatieresArticle.Columns("QTE UTILISE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewMatieresArticle.Columns("QTE UTILISE").DefaultCellStyle.Format = "n2"

                GunaDataGridViewMatieresArticle.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewMatieresArticle.Columns("COUT DE REVIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewMatieresArticle.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "n2"
                GunaDataGridViewMatieresArticle.Columns("QTE / PORTION").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewMatieresArticle.Columns("QTE / PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewMatieresArticle.Columns("QTE / PORTION").DefaultCellStyle.Format = "n2"
                GunaDataGridViewMatieresArticle.Columns("CODE ARTICLE").Visible = False
                GunaDataGridViewMatieresArticle.Columns("COUT ACHAT").Visible = False

                GunaTextBoxCoutDeProduction.Text = Format(coutTotalDeProduction, "#,##0")

            Else

                GunaTextBoxCoutDeProduction.Text = 0
                GunaDataGridViewMatieresArticle.Visible = False

            End If

        End If

    End Sub

    'AFFICHAGE DES INFORMATIONS UTILISE
    Public Sub informationUtiles()

        'NOMBRE DE PLAT EN ATTENTE DE PREPARATION
        Dim nombreDePlatEnAttenteDePreparation As Integer = 0

        For i = 0 To GunaDataGridViewCommandeEnCours.Rows.Count - 1
            nombreDePlatEnAttenteDePreparation += Double.Parse(GunaDataGridViewCommandeEnCours.Rows(i).Cells("QUANTITE").Value)
        Next
        GunaTextBoxNmbrePlatEnAttente.Text = Format(nombreDePlatEnAttenteDePreparation, "#,##0")
        '------------------------------------------------------------------------------------------------------------

        'NOMBRE DE PLAT PREPARE
        Dim nombreDePlatPrepare As Integer = 0
        Dim coutDeProductionDesPlatsPrepares As Integer = 0
        Dim totalDesVenteDesPlatsPrepares As Integer = 0

        Dim QUANTITE As Double = 0
        Dim CODE_ARTICLE As String = ""
        Dim CODE_FICHE_TECHNIQUE As String = ""

        Dim ficheTechniqueElements As New Article()
        Dim DIVERS_MONTANT As Double = 0
        Dim TOTAL_DIVERS As Double = 0

        'NOMMBRE DE PLAT PREPARE, COUT TOTAL DE PRODUCTION ET DE VENTE
        For i = 0 To GunaDataGridViewCommandePreparee.Rows.Count - 1

            QUANTITE = GunaDataGridViewCommandePreparee.Rows(i).Cells("QUANTITE").Value
            CODE_ARTICLE = GunaDataGridViewCommandePreparee.Rows(i).Cells("CODE_ARTICLE").Value.ToString
            CODE_FICHE_TECHNIQUE = GunaDataGridViewCommandePreparee.Rows(i).Cells("CODE_FICHE_TECHNIQUE").Value.ToString

            Dim infoFicheFt As DataTable = Functions.getElementByCode(CODE_FICHE_TECHNIQUE, "fiche_technique", "CODE_FICHE_TECHNIQUE")

            If infoFicheFt.Rows.Count > 0 Then
                DIVERS_MONTANT = infoFicheFt.Rows(0)("DIVERS_MONTANT")
            End If

            TOTAL_DIVERS += DIVERS_MONTANT * QUANTITE

            'ON DETERMINE LES QUANTITES
            nombreDePlatPrepare += Double.Parse(QUANTITE)

            Dim infoSupArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

            'ON DETERMINE LE PRIX DE VENTE DE L'ARTICLE
            If infoSupArticle.Rows.Count > 0 Then
                totalDesVenteDesPlatsPrepares += Double.Parse(infoSupArticle.Rows(0)("PRIX_VENTE_HT")) * QUANTITE

                Dim ficheTechElement As DataTable = ficheTechniqueElements.elementsDuneFicheTechniquePourPreparation(CODE_FICHE_TECHNIQUE)

                'ON DETERMINE LE PRIX DE PRODUCTION DE L'ARTICLE A PARTIR DE SA FICHE TECHNIQUE
                If ficheTechElement.Rows.Count > 0 Then

                    For j = 0 To ficheTechElement.Rows.Count - 1
                        coutDeProductionDesPlatsPrepares += ficheTechElement(j)("COUT DE REVIENT") * QUANTITE
                    Next

                End If
            End If

        Next

        coutDeProductionDesPlatsPrepares += TOTAL_DIVERS

        GunaTextBoxCmdePreparee.Text = Format(nombreDePlatPrepare, "#,##0")
        GunaTextBoxTotalDesVentes.Text = Format(totalDesVenteDesPlatsPrepares, "#,##0")
        GunaTextBoxCoutProduction.Text = Format(coutDeProductionDesPlatsPrepares, "#,##0")

        GunaTextBoxMargeBrute.Text = Format(totalDesVenteDesPlatsPrepares - coutDeProductionDesPlatsPrepares, "#,##0")
        '------------------------------------------------------------------------------------------------------------

        'COUT TOTAL DES VENTES & COUT TOTAL DE PRODUCTION

        '-------------------------------------------------------------------------------------------------------------
    End Sub

    'PREPARATION DES REPAS
    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButtonPreparer.Click

        If GunaDataGridViewCommandeEnCours.Rows.Count > 0 Then

            Dim ETAT_BORDEREAU As Integer = 1
            Dim NOMBRE As Double = 0
            Dim econom As New Economat()

            For Each row As DataGridViewRow In GunaDataGridViewCommandeEnCours.SelectedRows

                Dim CODE_FICHE_TECHNIQUE As String = row.Cells("CODE_FICHE_TECHNIQUE").Value.ToString
                Dim CODE_ARTICLE As String = row.Cells("CODE_ARTICLE").Value.ToString
                Dim RANDOM_CODE As String = row.Cells("RANDOM_CODE").Value.ToString

                Dim QUANTITE As Double = Double.Parse(row.Cells("QUANTITE").Value)

                '------------------------------------------------------------------------
                'DESTOCKAGES DES MATIRES

                'ON VERIFIE SI LA REFERENCE DU BC EST ASSOCIE AU CODE D'UNE FICHE TECHNIQUE AUQUEL CAS IL FAUDRA JUSTE VALIDER POUR DESTOCKER
                Dim ficheTechnique As DataTable = Functions.getElementByCode(CODE_FICHE_TECHNIQUE, "fiche_technique", "CODE_FICHE_TECHNIQUE")

                If ficheTechnique.Rows.Count > 0 Then

                    'DESTOCKAGE DES MATIERES EN PROVENANCE DE LA FICHE TECHNIQUE

                    Dim arti As New Article()

                    Dim articleADestocker As DataTable = arti.elementsDuneFicheTechnique(CODE_FICHE_TECHNIQUE)

                    If articleADestocker.Rows.Count > 0 Then

                        For i = 0 To articleADestocker.Rows.Count - 1

                            Dim CODE_ARTICLE_A_DESTOCKER = articleADestocker.Rows(i)("CODE ARTICLE")

                            Dim codeUniteDeComptageLigne As String = Functions.getElementByCode(CODE_ARTICLE_A_DESTOCKER, "article", "CODE_ARTICLE").Rows(0)("UNITE_COMPTAGE")

                            Dim prixParPetiteUniteLigne As DataTable = Functions.getElementByCode(codeUniteDeComptageLigne, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                            Dim valeurUniteLigne As Double = 0

                            'On verifie si l'article a une grande unite
                            If prixParPetiteUniteLigne.Rows.Count > 0 And Not Trim(prixParPetiteUniteLigne.Rows(0)("VALEUR_NUMERIQUE")) = "" Then
                                valeurUniteLigne = prixParPetiteUniteLigne.Rows(0)("VALEUR_NUMERIQUE")
                            Else
                                valeurUniteLigne = 1
                            End If

                            'MISE A JOUR DE LA QUANTITE DES LIGNE L'ARTICLE COMPOSE
                            Dim qteDouble As Double = 0
                            Dim valeurDeConversion As Double = 0

                            Double.TryParse(articleADestocker.Rows(i)("QUANTITE UTILISE"), qteDouble)
                            Double.TryParse(valeurUniteLigne, valeurDeConversion)

                            Dim TABLE_SOURCEA_DESTOCKER As String = "article"

                            Dim QUANTITE_ARTICLE_A_DESTOCKER As Double = ((qteDouble * -1) / valeurDeConversion) * QUANTITE

                            Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                            Dim CMUP As Double = 0

                            If Functions.getElementByCode(articleADestocker.Rows(i)("CODE ARTICLE"), "article", "CODE_ARTICLE").Rows.Count > 0 Then

                                QUANTITE_AVANT_MOVEMENT = Functions.getElementByCode(articleADestocker.Rows(i)("CODE ARTICLE"), "article", "CODE_ARTICLE").Rows(0)("QUANTITE")
                                CMUP = Functions.getElementByCode(articleADestocker.Rows(i)("CODE ARTICLE"), "article", "CODE_ARTICLE").Rows(0)("PRIX_ACHAT_HT")

                            End If

                            If econom.gestionStockagesEtDeStockages(CODE_ARTICLE_A_DESTOCKER, TABLE_SOURCEA_DESTOCKER, QUANTITE_ARTICLE_A_DESTOCKER) Then

                            End If

                            'MOVEMENT DE STOCK

                            Dim entre_en_stock As Double = 0

                            Dim sortie_de_stock As Double = QUANTITE_ARTICLE_A_DESTOCKER

                            Dim DATE_PEREMPTION As Date

                            ' Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel

                            Dim CODE_MAGASIN As String = ""
                            Dim TYPE_MAGASIN As String = ""
                            Dim infoSupMagCentrale As DataTable

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

                            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                            Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "")
                            Dim LIBELLE_MOUVEMENT As String = "sortie des matieres pour pour l'article " + articleADestocker.Rows(i)("DESIGNATION")

                            Dim TYPE_MOUVEMENT As String = "sortie de stock"

                            Dim QUANTITE_ENTREE As Double = 0
                            Dim QUANTITE_SORTIE As Double = sortie_de_stock
                            Dim VALEUR_ENTREE As Double = 0
                            Dim VALEUR_SORTIE As String = sortie_de_stock

                            Dim ETAT_MOUVEMENT As String = ""
                            Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                            Dim CODE_LOT As String = ""

                            Dim CODE_BORDEREAUX_MOV As String = ""

                            'INSERTION DU MOVEMENT DE STOCK
                            If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE_A_DESTOCKER, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE * -1, VALEUR_ENTREE, VALEUR_SORTIE * -1, CODE_UTILISATEUR_CREA, GlobalVariable.codeAgence, CODE_BORDEREAUX_MOV, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                            End If

                        Next

                        'MISE A JOUR DE LA QUANTITE DE L'ARTICLE COMPOSE

                        Dim TABLE_SOURCE As String = "article"
                        Dim QUANTITE_ARTICLE As Double = QUANTITE
                        Dim CODE_DESTINATION As String = ""

                        If econom.gestionStockagesEtDeStockages(CODE_ARTICLE, TABLE_SOURCE, QUANTITE_ARTICLE) Then

                            'MISE A JOURS DE LA COMMANDE DE LA CUISINE
                            Dim updateQuery As String = "UPDATE `commande_cuisine` SET `ETAT`=@ETAT WHERE RANDOM_CODE=@RANDOM_CODE"

                            Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                            command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1
                            command.Parameters.Add("@RANDOM_CODE", MySqlDbType.VarChar).Value = RANDOM_CODE

                            'Opening the connection
                            'connect.openConnection()

                            'Excuting the command and testing if everything went on well
                            command.ExecuteNonQuery()

                        End If

                        'ETAT_BORDEREAU = 5

                    End If

                    If GunaDataGridViewCommandeEnCours.Rows.Count <= 0 Then
                        GunaDataGridViewCommandeEnCours.Columns.Clear()
                    End If

                    commandePrepare()

                    commandeEncoursDePreparation()

                    'AFFICHAGE DES INROMATIONS COMPLEMENTAIRES
                    informationUtiles()

                Else

                End If
                '-------------------------------------------------------------------------

            Next

        End If

    End Sub

    Private Sub GunaDataGridViewCommandePreparee_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewCommandePreparee.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            Dim coutTotalDeProduction As Double = 0

            row = Me.GunaDataGridViewCommandePreparee.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM fiche_technique WHERE CODE_FICHE_TECHNIQUE=@CODE_FICHE_TECHNIQUE ORDER BY LIBELLE_FICHE ASC"
            Dim adapter As New MySqlDataAdapter
            Dim fiche As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim QUANTITE As Double = Double.Parse(row.Cells("QUANTITE").Value)

            command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = row.Cells("CODE_FICHE_TECHNIQUE").Value.ToString
            adapter.SelectCommand = command
            adapter.Fill(fiche)

            If (fiche.Rows.Count > 0) Then

                Dim ficheTechniqueElements As New Article()

                GunaDataGridViewMatieresArticle.Columns.Clear()
                GunaDataGridViewMatieresArticle.Rows.Clear()

                'AJOUTS DES COLUMNS

                GunaDataGridViewMatieresArticle.Columns.Add("CODE ARTICLE", "CODE ARTICLE")
                GunaDataGridViewMatieresArticle.Columns.Add("DESIGNATION", "DESIGNATION")
                GunaDataGridViewMatieresArticle.Columns.Add("UNITE", "UNITE")
                GunaDataGridViewMatieresArticle.Columns.Add("QTE UTILISE", "QTE UTILISE")
                GunaDataGridViewMatieresArticle.Columns.Add("QTE / PORTION", "QTE / PORTION")
                GunaDataGridViewMatieresArticle.Columns.Add("COUT DE REVIENT", "COUT DE REVIENT")
                GunaDataGridViewMatieresArticle.Columns.Add("COUT ACHAT", "COUT ACHAT") 'PRIX ACHAT

                'GunaDataGridViewMatieresArticle.DataSource = ficheTechniqueElements.elementsDuneFicheTechniquePourPreparation(fiche.Rows(0)("CODE_FICHE_TECHNIQUE"))
                Dim ficheTechElement As DataTable = ficheTechniqueElements.elementsDuneFicheTechniquePourPreparation(fiche.Rows(0)("CODE_FICHE_TECHNIQUE"))

                If ficheTechElement.Rows.Count > 0 Then

                    For i = 0 To ficheTechElement.Rows.Count - 1
                        GunaDataGridViewMatieresArticle.Rows.Add(ficheTechElement(i)("CODE ARTICLE"), ficheTechElement(i)("DESIGNATION"), ficheTechElement(i)("UNITE"), ficheTechElement(i)("QTE UTILISE") * QUANTITE, ficheTechElement(i)("QTE / PORTION"), ficheTechElement(i)("COUT DE REVIENT") * QUANTITE, ficheTechElement(i)("COUT ACHAT") * QUANTITE)

                        coutTotalDeProduction += ficheTechElement(i)("COUT DE REVIENT") * QUANTITE

                    Next

                End If

                GunaDataGridViewMatieresArticle.Columns("COUT ACHAT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewMatieresArticle.Columns("COUT ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewMatieresArticle.Columns("COUT ACHAT").DefaultCellStyle.Format = "n2"

                GunaDataGridViewMatieresArticle.Columns("QTE UTILISE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewMatieresArticle.Columns("QTE UTILISE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewMatieresArticle.Columns("QTE UTILISE").DefaultCellStyle.Format = "n2"

                GunaDataGridViewMatieresArticle.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewMatieresArticle.Columns("COUT DE REVIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewMatieresArticle.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "n2"
                GunaDataGridViewMatieresArticle.Columns("QTE / PORTION").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewMatieresArticle.Columns("QTE / PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewMatieresArticle.Columns("QTE / PORTION").DefaultCellStyle.Format = "n2"
                GunaDataGridViewMatieresArticle.Columns("CODE ARTICLE").Visible = False
                GunaDataGridViewMatieresArticle.Columns("COUT ACHAT").Visible = False

                GunaTextBoxCoutDeProduction.Text = Format(coutTotalDeProduction, "#,##0")

            Else

                GunaDataGridViewMatieresArticle.Visible = False

                GunaTextBoxCoutDeProduction.Text = 0

            End If

        End If

    End Sub

    Private Sub GunaButtonAfficherFiche_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherFiche.Click
        ficheTechniqueListe()
    End Sub

    Private Sub TimerToRefreshClock_Tick(sender As Object, e As EventArgs) Handles TimerToRefreshClock.Tick

        commandePrepare()

        commandeEncoursDePreparation()

        informationUtiles()

    End Sub

    'AU CHANGEMENT DE LA FAMILLE D'ARTICLE DE NIVEAU I
    Private Sub GunaComboBoxSousSousFamillle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCategorieArticle.SelectedIndexChanged

        If GunaComboBoxCategorieArticle.SelectedIndex >= 0 Then

            GunaComboBoxSousFamilleArticle.DataSource = Nothing

            Dim PARENT As String = GunaComboBoxCategorieArticle.SelectedValue.ToString

            Dim Famille As DataTable = Functions.GetAllElementsOnCondition(PARENT, "sous_famille", "CODE_FAMILLE_PARENT")

            If (Famille.Rows.Count > 0) Then

                GunaComboBoxSousFamilleArticle.DataSource = Famille
                GunaComboBoxSousFamilleArticle.ValueMember = "LIBELLE_SOUS_FAMILLE"
                'GunaComboBoxSousFamilleArticle.ValueMember = "CODE_SOUS_FAMILLE"
                GunaComboBoxSousFamilleArticle.DisplayMember = "LIBELLE_SOUS_FAMILLE"

            Else
                GunaComboBoxSousFamilleArticle.SelectedIndex = -1
                GunaComboBoxLastLevelArticle.SelectedIndex = -1
            End If

        End If

    End Sub

    Private Sub GunaComboBoxSousFamilleArticle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxSousFamilleArticle.SelectedIndexChanged

        GunaComboBoxLastLevelArticle.DataSource = Nothing

        If GunaComboBoxSousFamilleArticle.SelectedIndex >= 0 Then

            'Dim PARENT As String = GunaComboBoxSousFamilleArticle.SelectedValue.ToStringGunaDataGridViewCommandePreparee
            Dim PARENT As String = GunaComboBoxSousFamilleArticle.SelectedValue.ToString

            Dim SousFamille As DataTable = Functions.GetAllElementsOnCondition(PARENT, "sous_sous_famille", "CODE_FAMILLE_PARENT")

            If (SousFamille.Rows.Count > 0) Then

                GunaComboBoxLastLevelArticle.DataSource = SousFamille
                GunaComboBoxLastLevelArticle.ValueMember = "LIBELLE_FAMILLE"
                'GunaComboBoxLastLevelArticle.ValueMember = "CODE_SOUS_FAMILLE"
                GunaComboBoxLastLevelArticle.DisplayMember = "LIBELLE_FAMILLE"

            Else
                'GunaComboBoxLastLevelArticle.SelectedIndex = -1
            End If

        End If

    End Sub

    Private Sub GunaButtonImprimerCommandeDuBar_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerCommandeDuBar.Click

        Dim dateDebut As Date = GlobalVariable.DateDeTravail
        Dim dateFin As Date = GlobalVariable.DateDeTravail

        'COMMANDE PREPAREES DE LA CUISINE DE LA CUISINE
        Dim FillingListquery2 = "SELECT `CODE_ARTICLE`, `NOM_ARTICLE` AS ARTICLE, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE` AS QUANTITE, `DATE_PREPARATION`, `ETAT`, PRIX_VENTE, `RANDOM_CODE` FROM `commande_cuisine` WHERE ETAT=@ETAT AND DATE_PREPARATION <= '" & dateFin.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >= '" & dateDebut.ToString("yyyy-MM-dd") & "' "

        Dim commandList2 As New MySqlCommand(FillingListquery2, GlobalVariable.connect)
        commandList2.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1

        Dim adapterList2 As New MySqlDataAdapter(commandList2)
        Dim tableList2 As New DataTable()

        adapterList2.Fill(tableList2)

        If tableList2.Rows.Count > 0 Then
            Dim title As String = "COMMANDES PREPAREES DE LA CUISINE"
            Dim tableName As String = "commande_cuisine"
            Impression.productionDelaCuisine(tableList2, dateDebut, dateFin, tableName, title)
        End If

    End Sub

    Private Sub GunaTextBoxRefClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefArticleMatiere.TextChanged

        If Trim(GunaTextBoxRefArticleMatiere.Text) = "" Then
            GunaDataGridViewArticle.Columns.Clear()
            GunaLabelNombreClient.Visible = False
        Else

            'REFRESHING information from database for instant visualisation 
            Dim query As String = "SELECT CODE_ARTICLE AS 'CODE', DESIGNATION_FR AS 'DESIGNATION', DESCRIPTION, COUT_U_MOYEN_PONDERE As 'PRIX ACHAT HT', PRIX_ACHAT_HT As 'COUT MOYEN', PRIX_VENTE_HT As 'PRIX VENTE HT', PRIX_VENTE1_HT AS 'PRIX VENTE 2', PRIX_VENTE2_HT AS 'PRIX VENTE 3', PRIX_VENTE3_HT AS 'PRIX VENTE 4' , QUANTITE FROM article WHERE TYPE=@TYPE AND DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxRefArticleMatiere.Text) & "%' OR TYPE=@TYPE AND CODE_ARTICLE LIKE '%" & Trim(GunaTextBoxRefArticleMatiere.Text) & "%' ORDER BY DESIGNATION_FR ASC"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeArticle
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaButtonAfficherLesFacturesEtReglement.Visible = True

                GunaLabelNombreClient.Visible = True
                GunaLabelNombreClient.Text = table.Rows.Count

                GunaDataGridViewArticle.DataSource = table
                GunaDataGridViewArticle.Columns("PRIX ACHAT HT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRIX VENTE HT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("COUT MOYEN").DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewArticle.Columns("PRIX ACHAT HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewArticle.Columns("PRIX VENTE HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewArticle.Columns("COUT MOYEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewArticle.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewArticle.Columns("QUANTITE").DefaultCellStyle.Format = "n2"

                GunaDataGridViewArticle.Columns("PRIX VENTE 2").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRIX VENTE 2").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRIX VENTE 2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewArticle.Columns("PRIX VENTE 3").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRIX VENTE 3").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRIX VENTE 3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewArticle.Columns("PRIX VENTE 4").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRIX VENTE 4").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRIX VENTE 4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewArticle.Columns("CODE").Visible = False

            Else

                GunaDataGridViewArticle.Columns.Clear()
                GunaLabelNombreClient.Visible = False
                GunaButtonAfficherLesFacturesEtReglement.Visible = False

            End If

        End If

    End Sub

    Private Sub GunaButtonAfficherLesFacturesEtReglement_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLesFacturesEtReglement.Click

        Dim titre As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            If GlobalVariable.typeArticle = "article" Then
                titre = "LISTE DES ARTICLES"
            Else
                titre = "LISTE DES MATIERES"
            End If
        Else
            If GlobalVariable.typeArticle = "article" Then
                titre = "LIST OF ARTICLES"
            Else
                titre = "LIST OF MATERIALS"
            End If
        End If

        Dim all As Integer = 0

        If GunaCheckBoxAll.Checked Then
            all = 1
        End If

        If GunaDataGridViewArticle.Rows.Count > 0 Then
            Functions.ImpressionArticleMatieres(GunaDataGridViewArticle, titre, all)
        End If

    End Sub

    Private Sub GunaTextBoxSearchFicheTechnique_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxSearchFicheTechnique.TextChanged

        If Trim(GunaTextBoxSearchFicheTechnique.Text) = "" Then
            GunaDataGridViewFicheTechnique.Columns.Clear()
        Else

            Dim existQuery As String = "SELECT CODE_FICHE_TECHNIQUE As 'CODE FICHE', `LIBELLE_FICHE` As `LIBELLE FICHE` ,`NOM_ARTICLE` AS 'ARTICLE', `QUANTITE` AS 'NOMBRE DE PORTION', `PRIX_VENTE` AS 'PRIX DE VENTE', `CM` AS 'COEF DE MARGE', `MB` as 'MARGE BRUTE' FROM `fiche_technique` WHERE LIBELLE_FICHE LIKE '%" & Trim(GunaTextBoxSearchFicheTechnique.Text) & "%' ORDER BY LIBELLE_FICHE ASC"

            Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaDataGridViewFicheTechnique.DataSource = table

                GunaDataGridViewFicheTechnique.Columns("PRIX DE VENTE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewFicheTechnique.Columns("PRIX DE VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewFicheTechnique.Columns("MARGE BRUTE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewFicheTechnique.Columns("MARGE BRUTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewFicheTechnique.Columns("NOMBRE DE PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewFicheTechnique.Columns("COEF DE MARGE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewFicheTechnique.Columns("CODE FICHE").Visible = False
                GunaDataGridViewFicheTechnique.Columns("ARTICLE").Visible = False
                GunaDataGridViewFicheTechnique.Columns("NOMBRE DE PORTION").Visible = False

            End If

        End If

    End Sub

    Private Sub GunaButtonEffacer_Click(sender As Object, e As EventArgs)
        GunaTextBoxCodeFicheTechnique.Clear()
        GunaTextBoxLibelleFiche.Clear()
        GunaButtonCreationDeFiche.Visible = True
        GunaButtonCreationDeFiche.Text = "Enregistrer"

        Functions.DeleteElementByCode("fiche technique", "ligne_facture_temp", "TYPE_LIGNE_FACTURE")

    End Sub

    'UTILISER DANS LE CAS D'UNE PREPARATION MULTIPLE

    Private Sub GunaButtonAjouterPlat_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterPlat.Click

        If Not Trim(GunaTextBoxCodeFicheTechnique.Text).Equals("") Then

            If Not Trim(GunaTextBoxCodeArticlePourFiche.Text).Equals("") Then

                Dim LIBELLE_FICHE As String = GunaTextBoxLibelleFiche.Text
                Dim NOM_ARTICLE As String = GunaTextBoxNomArticle.Text
                Dim PRIX_VENTE As Double = Double.Parse(GunaTextBoxPrixVente.Text)
                Dim CODE_ARTICLE_FICHE As String = GunaTextBoxCodeArticlePourFiche.Text
                Dim NOMBRE_DE_PORTION As Integer = GunaTextBoxNombreDePortion.Text
                Dim CODE_FICHE_TECHNIQUE As String = GunaTextBoxCodeFicheTechnique.Text
                Dim A_LA_CARTE As Integer = Integer.Parse(GunaTextBoxALaCarte.Text)
                Dim DATE_PREPARATION As Date = GlobalVariable.DateDeTravail

                Dim article As New Article()
                'article.preparationDePlusieursPlats(CODE_ARTICLE_FICHE, NOM_ARTICLE, CODE_FICHE_TECHNIQUE, NOMBRE_DE_PORTION, DATE_PREPARATION, PRIX_VENTE)

                Dim tableName As String = "fiche_technique_article_prepare"

                'Insetion des lignes pour genration du rapport des preparation en cuisine
                article.ficheTechniqueArticlePrepare(CODE_ARTICLE_FICHE, NOM_ARTICLE, CODE_FICHE_TECHNIQUE, NOMBRE_DE_PORTION, DATE_PREPARATION, PRIX_VENTE, tableName)

                Dim prix_moyen_de_vente As Double = 0

                Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

                Dim query As String = "SELECT AVG(PRIX_VENTE) As PV FROM fiche_technique_article_prepare WHERE DATE_PREPARATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_FICHE_TECHNIQUE = @CODE_FICHE_TECHNIQUE"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)
                command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                If table.Rows.Count > 0 Then

                    If table.Rows(0)("PV") > 0 Then
                        prix_moyen_de_vente = table.Rows(0)("PV")
                    End If

                    GunaTextBoxPV.Text = Format(prix_moyen_de_vente, "#,##0")

                    GunaTextBoxNomArticle.Clear()
                    GunaTextBoxCodeArticlePourFiche.Clear()
                    GunaTextBoxNombreDePortion.Text = 1

                End If

            End If

        End If

        'Dim article As New 
        '
    End Sub

    Private Sub GunaCheckBoxFTPlusieursPlat_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxFTPlusieursPlat.CheckedChanged

        If GunaCheckBoxFTPlusieursPlat.Checked Then
            GunaButtonAjouterPlat.Visible = True
            GunaButtonVisualierArticlePreparee.Visible = True
        Else
            GunaButtonAjouterPlat.Visible = False
            GunaButtonVisualierArticlePreparee.Visible = False
        End If

    End Sub

    Public Sub AutoLoadlisteMagasinSource()

        Dim query As String = "SELECT * FROM magasin WHERE TYPE_MAGASIN=@TYPE_MAGASIN ORDER BY LIBELLE_MAGASIN ASC"
        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        command.Parameters.Add("@TYPE_MAGASIN", MySqlDbType.VarChar).Value = "Petit magasin"
        adapter.SelectCommand = command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            GunaComboBoxMagasinRecep.DataSource = table
            GunaComboBoxMagasinRecep.ValueMember = "CODE_MAGASIN"
            GunaComboBoxMagasinRecep.DisplayMember = "LIBELLE_MAGASIN"

        End If

        Dim query01 As String = "SELECT * FROM magasin WHERE TYPE_MAGASIN=@TYPE_MAGASIN ORDER BY LIBELLE_MAGASIN ASC"
        Dim adapter01 As New MySqlDataAdapter
        Dim table01 As New DataTable
        Dim command01 As New MySqlCommand(query01, GlobalVariable.connect)

        command01.Parameters.Add("@TYPE_MAGASIN", MySqlDbType.VarChar).Value = "Magasin central"
        adapter01.SelectCommand = command01
        adapter01.Fill(table01)

        If table01.Rows.Count > 0 Then

            GunaComboBoxMagDestock.DataSource = table01
            GunaComboBoxMagDestock.ValueMember = "CODE_MAGASIN"
            GunaComboBoxMagDestock.DisplayMember = "LIBELLE_MAGASIN"

        End If

    End Sub

    Private Sub GunaButtonVisualierArticlePreparee_Click(sender As Object, e As EventArgs) Handles GunaButtonVisualierArticlePreparee.Click

        'AFFICHAGE DE LA LISTE DES ARTICLES PREPAREES

        If Not Trim(GunaTextBoxCodeFicheTechnique.Text).Equals("") Then

            ArticlePrepareeVisualisationForm.Close()
            ArticlePrepareeVisualisationForm.Show()
            ArticlePrepareeVisualisationForm.TopMost = True

        End If

    End Sub

    Private Sub GunaDataGridViewFicheTechnique_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewFicheTechnique.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim CURRENT_CELL_EDIT As String = ""

            If True Then

                TabControlArticle.SelectedIndex = 2

                Dim row As DataGridViewRow

                row = Me.GunaDataGridViewFicheTechnique.Rows(e.RowIndex)

                CURRENT_CELL_EDIT = row.Cells("CODE FICHE").Value.ToString

                GunaCheckBoxPortion.Checked = False

                GunaTextBoxCodeFicheTechnique.Text = CURRENT_CELL_EDIT

                Dim FICHE_TECHNIQUE As DataTable = Functions.getElementByCode(CURRENT_CELL_EDIT, "fiche_technique", "CODE_FICHE_TECHNIQUE")

                If FICHE_TECHNIQUE.Rows.Count > 0 Then

                    GunaButtonCreationDeFiche.Visible = True
                    GunaButtonCreationDeFiche.Text = "Sauvegarder"

                    GunaTextBoxLibelleFiche.Text = FICHE_TECHNIQUE.Rows(0)("LIBELLE_FICHE")

                    Dim ligneFicheTechnique As DataTable = Functions.getElementByCode(CURRENT_CELL_EDIT, "fiche_technique_ligne", "CODE_FICHE_TECHNIQUE")

                    'On doit remplir ligne_facture_temp et l'utiliser pour remplir le datagrid
                    If ligneFicheTechnique.Rows.Count > 0 Then

                        For i = 0 To ligneFicheTechnique.Rows.Count - 1

                            'GunaButtonAjouterLigne.Visible = True

                            Dim CODE_MOUVEMENT As String = ""

                            Dim CODE_CHAMBRE As String = ""
                            Dim CODE_MODE_PAIEMENT As String = ""
                            Dim NUMERO_PIECE As String = ""
                            Dim CODE_ARTICLE As String = ligneFicheTechnique.Rows(i)("CODE_ARTICLE")
                            Dim CODE_LOT As String = ""
                            'Dim TAXE As Double = Double.Parse(GunaTextBoxTVA.Text)
                            Dim TAXE As Double = 0
                            Dim QUANTITE As Integer = ligneFicheTechnique.Rows(i)("QUANTITE_PAR_PORTION")

                            Dim PRIX_UNITAIRE_TTC As Double = ligneFicheTechnique.Rows(i)("PRIX_ACHAT")
                            Dim MONTANT_TTC As Double = Double.Parse(ligneFicheTechnique.Rows(i)("QUANTITE_PAR_PORTION"))
                            Dim DATE_FACTURE As Date = GlobalVariable.DateDeTravail.ToShortDateString()
                            Dim HEURE_FACTURE As DateTime = Date.Now().ToShortTimeString
                            Dim ETAT_FACTURE As Integer = 0
                            Dim DATE_OCCUPATION As Date = Now().ToShortDateString()
                            Dim HEURE_OCCUPATION As DateTime = Date.Now().ToShortTimeString

                            Dim article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")
                            Dim LIBELLE_FACTURE As String = " "

                            If article.Rows.Count > 0 Then
                                LIBELLE_FACTURE = article.Rows(0)("CODE_ARTICLE")
                            Else

                            End If

                            Dim TYPE_LIGNE_FACTURE As String = "fiche technique"
                            Dim NUMERO_SERIE As String = ""
                            Dim NUMERO_ORDRE As Integer = 0
                            Dim DESCRIPTION As String = ""
                            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                            Dim MONTANT_HT As Double = ligneFicheTechnique.Rows(i)("PRIX_REVIENT")
                            'COUT PAR PLUS PETITE UNITE NECESSAIRE POUR LA FICHE TECHNIQUE
                            Dim MONTANT_REMISE As Double = ligneFicheTechnique.Rows(i)("PRIX_ACHAT") ' = MONTANT PAR UNITE DE LA PLUS PETITE UNITE DE COMPTAGE

                            Dim MONTANT_TAXE As Double = ligneFicheTechnique.Rows(i)("PRIX_REVIENT") * ligneFicheTechnique.Rows(i)("QUANTITE_PAR_PORTION") ' MONTANT TOTAL DE REVIENT PAR PLUS PETITE UNITE DE COMPTAGE
                            Dim NUMERO_SERIE_DEBUT As String = ""
                            Dim NUMERO_SERIE_FIN As String = ""
                            Dim CODE_MAGASIN As String = ""
                            Dim FUSIONNEE As String = ""
                            Dim CODE_RESERVATION As String = ""
                            'Dim CODE_FACTURE As String = GunaTextBoxNumfacture.Text
                            Dim CODE_FACTURE As String = ligneFicheTechnique.Rows(i)("CODE_FICHE_TECHNIQUE")

                            GunaTextBoxNumfacture.Text = ligneFicheTechnique.Rows(i)("CODE_FICHE_TECHNIQUE")

                            Dim TYPE As String = GlobalVariable.typeChambreOuSalle

                            Dim TABLE_LIGNE As String = "ligne_facture_temp"

                            Dim NUMERO_BLOC_NOTE As String = ""

                            '-------------------------- LIGNE FACTURATION--------------------------
                            Dim ligneFacture As New LigneFacture()

                            If ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE) Then

                            End If

                        Next

                        If GunaButtonCreationDeFiche.Text = "Sauvegarder" Then

                            Dim ficheTechniqueElements As New Article()
                            Dim CODE_FICHE_TECHNIQUE As String = GunaTextBoxCodeFicheTechnique.Text

                            Dim ficheTechElement As DataTable = Functions.getElementByCode(CODE_FICHE_TECHNIQUE, "fiche_technique", "CODE_FICHE_TECHNIQUE")

                            If ficheTechElement.Rows.Count > 0 Then
                                GunaTextBoxCM.Text = Double.Parse(ficheTechElement.Rows(0)("CM"))
                                GunaTextBoxPMI.Text = Double.Parse(ficheTechElement.Rows(0)("PMI"))
                                GunaTextBoxTM.Text = Double.Parse(ficheTechElement.Rows(0)("TM"))
                            End If

                        End If

                    Else

                    End If

                Else
                    'LabelFicheTecniqueADetailler.Visible = False
                    'GunaButtonNonPreparation.Visible = False
                End If

            End If

            'Refresh Datagrid To view newly inserted Articles
            OutPutLigneFacture()

            GunaTextBoxArticleMatiere.Clear()

            'On renseigne les information supplementaire concernant la fiche de police
            informationGeneraleFicheTechnique()

        Else

            MessageBox.Show("Oups", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If


    End Sub

    Private Sub GunaTextBoxCM_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCM.TextChanged
        informationGeneraleFicheTechnique()
    End Sub

    Private Sub CoefFxnDuPrixDeVente_Click(sender As Object, e As EventArgs) Handles CoefFxnDuPrixDeVente.Click
        informationGeneraleFicheTechnique()
    End Sub

    Private Sub PrixDeVenteFxnDuCoef_Click(sender As Object, e As EventArgs) Handles PrixDeVenteFxnDuCoef.Click
        informationGeneraleFicheTechnique()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        'SUPPRESSION DE MATIERE LORS DE LA CREATION D'UN FICHE TECHNIQUE

        Dim CODE_ARTICLE As String = GunaDataGridViewLigneFiche.CurrentRow.Cells("CODE ARTICLE").Value.ToString
        Dim MATIERE As String = GunaDataGridViewLigneFiche.CurrentRow.Cells("DESIGNATION").Value.ToString

        Dim dialog As DialogResult
        dialog = MessageBox.Show("Voulez-vous vraiment Supprimer la matiére : " & MATIERE, "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else

            Dim TYPE_LIGNE_FACTURE As String = "fiche technique"
            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim getUserQuery = "DELETE FROM ligne_facture_temp  WHERE CODE_FACTURE = @CODE_FACTURE AND CODE_ARTICLE=@CODE_ARTICLE AND TYPE_LIGNE_FACTURE =@TYPE_LIGNE_FACTURE"
            Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

            Command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = GunaTextBoxNumfacture.Text
            Command.Parameters.Add("@TYPE_LIGNE_FACTURE", MySqlDbType.VarChar).Value = TYPE_LIGNE_FACTURE
            Command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
            adapter.SelectCommand = Command
            adapter.Fill(table)

            GunaDataGridViewLigneFiche.Columns.Clear()

            OutPutLigneFacture()

            MessageBox.Show("Vous avez supprimé la matiére " & MATIERE & " avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaComboBoxFicheTechnique_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxFicheTechnique.SelectedIndexChanged

        If GunaCheckBoxAlaCarte.Checked Then

            If GunaComboBoxFicheTechnique.SelectedIndex >= 0 Then

                Dim CODE_FICHE_TECHNIQUE As String = GunaComboBoxFicheTechnique.SelectedValue.ToString

                Dim infoSupFiche As DataTable = Functions.getElementByCode(CODE_FICHE_TECHNIQUE, "fiche_technique", "CODE_FICHE_TECHNIQUE")

                If infoSupFiche.Rows.Count > 0 Then
                    GunaTextBoxPVConseil.Text = Format(infoSupFiche.Rows(0)("PV"), "#,##0")
                    GunaTextBoxPAConseil.Text = Format(infoSupFiche.Rows(0)("CRPPV"), "#,##0")
                End If

            End If

        End If

    End Sub

    Private Sub GunaButtonUpload_Click(sender As Object, e As EventArgs) Handles GunaButtonUpload.Click
        Dim opf As New OpenFileDialog
        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF) | *.jpg;*.png;*.gif"

        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim ImagePath As String = opf.FileName
            GunaPictureBoxLogo.Image = Image.FromFile(opf.FileName)
        End If

    End Sub

    Private Sub GunaCheckBoxArticleMatiere_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxArticleMatiere.Click

        GunaDataGridViewArticle.Columns.Clear()

        If GunaCheckBoxArticleMatiere.Checked Then
            GlobalVariable.typeArticle = "matiere"
            GunaComboBoxArticleMatiere.SelectedIndex = 1
        Else
            GlobalVariable.typeArticle = "article"
            GunaComboBoxArticleMatiere.SelectedIndex = 0
        End If

        GunaTextBoxRefArticleMatiere.Clear()

    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        TabControlArticle.SelectedIndex = 0
    End Sub

    Private Sub GunaCheckBoxRetablirLesQuantie_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxRetablirLesQuantie.Click

        If GunaCheckBoxRetablirLesQuantie.Checked Then
            GunaButtonRetablirQte.Visible = True
        Else
            GunaButtonRetablirQte.Visible = False
        End If

    End Sub

    Private Sub GunaButtonRetablirQte_Click(sender As Object, e As EventArgs) Handles GunaButtonRetablirQte.Click

        Me.Cursor = Cursors.WaitCursor

        Dim QUANTITE As Double = 0

        Dim infoArticle As DataTable = Functions.getElementByCode(QUANTITE, "article", "0")

        If infoArticle.Rows.Count > 0 Then

            For i = 0 To infoArticle.Rows.Count - 1

                Dim CODE_ARTICLE As String = infoArticle.Rows(i)("CODE_ARTICLE")
                Economat.miseAjourQuantiteTotalRestant(CODE_ARTICLE)

            Next

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaCheckBoxFiltreArticleCategorie_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFiltreArticleCategorie.Click

        If GunaCheckBoxFiltreArticleCategorie.Checked Then

            GunaComboBoxFiltreArticle.Visible = True

            If GunaComboBoxFiltreArticle.Items.Count > 0 Then
                GunaComboBoxFiltreArticle.SelectedIndex = 0
            End If

        Else
            GunaComboBoxFiltreArticle.Visible = False
            GunaComboBoxFiltreArticle.SelectedIndex = -1
        End If

    End Sub

End Class