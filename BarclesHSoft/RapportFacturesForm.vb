Imports MySql.Data.MySqlClient

Public Class RapportFacturesForm


    Private Sub RapportFacturesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.rapportsFacture(GlobalVariable.actualLanguageValue)

        If GlobalVariable.DocumentToGenerate = "MOUCHARDS" Or GlobalVariable.DocumentToGenerate = "SITUATION MENSUEL DE L'ETABLISSEMENT" Then
            DataGridViewRapports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Else
            DataGridViewRapports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail.ToShortDateString
        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail.ToShortDateString

        If GlobalVariable.DocumentToGenerate = "SITUATION GLOBAL" Then
            GunaButtonAfficher.Visible = False
            GunaButtonImprimer.Visible = True
        Else
            GunaButtonAfficher.Visible = True
        End If

        If GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES PERIODIQUE" Or
            GlobalVariable.DocumentToGenerate = "SITUATION DE CAISSE PERIODIQUE" Or
            GlobalVariable.DocumentToGenerate = "INVENTAIRE DES VENTES" Or
            GlobalVariable.DocumentToGenerate = "SITUATION GLOBAL" Or
            GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES" Or
            GlobalVariable.DocumentToGenerate = "FICHE DE VENTILATION" Then

            utiliseteurDeCaisse()

            GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex = -1
            GunaCheckBoxTous.Checked = True

            GunaLabel2.Visible = True
            GunaCheckBoxTous.Visible = True
            GunaComboBoxUtilisateurDeMagasinBar.Visible = True

        Else

            GunaLabel2.Visible = False
            GunaCheckBoxTous.Visible = False
            GunaComboBoxUtilisateurDeMagasinBar.Visible = False

        End If

        If GlobalVariable.DocumentToGenerate = "INVENTAIRE DES VENTES" Then
            GunaComboBoxParPointDeVente.Visible = True
            GunaComboBoxParPointDeVente.SelectedIndex = 0
        End If


        If GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES" Then
            GunaDateTimePickerFin.Enabled = False
        End If

        If GlobalVariable.DocumentToGenerate = "FICHE D'INVENTAIRE JOURNALIERE BAR" Then

            GunaLabel3.Visible = True
            GunaComboBoxMagasins.Visible = True

            GunaDateTimePickerDebut.Enabled = True
            GunaDateTimePickerFin.Enabled = False

            AutoLoadlisteMagasinSource()

            GunaComboBoxMagasins.SelectedValue = GlobalVariable.magasinActuel

        ElseIf GlobalVariable.DocumentToGenerate = "SITUATION MENSUEL DE L'ETABLISSEMENT" Or GlobalVariable.DocumentToGenerate = "PERIODIC ACCOMMODATION REPORT" Then

            GunaDateTimePickerDebut.Value = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail)
            GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail.ToShortDateString

            GunaDateTimePickerDebut.Enabled = True
            GunaDateTimePickerFin.Enabled = True

        ElseIf GlobalVariable.DocumentToGenerate = "INVENTAIRE DU MAGASIN" Then

            AutoLoadlisteMagasinSource()
            GunaLabel3.Visible = True
            GunaComboBoxMagasins.Visible = True

            GunaComboBoxMagasins.SelectedValue = GlobalVariable.magasinActuel

        End If

        If GlobalVariable.DocumentToGenerate = "FICHE D'INVENTAIRE JOURNALIERE BAR" Or GlobalVariable.DocumentToGenerate = "MOUCHARDS" Then
            GunaDateTimePickerDebut.Enabled = True
            GunaDateTimePickerFin.Value = GunaDateTimePickerDebut.Value
        End If

        If GlobalVariable.DocumentToGenerate = "FICHE STATISTIQUE JOURNALIERE" Then

            'LE JOUR MAXIMUM D'OBTENTION DE LA FICHE STATISTIQUE ET LE JOUR DE LA DATE DE TRAVAIL
            GunaDateTimePickerDebut.MaxDate = GlobalVariable.DateDeTravail
            GunaButtonAfficher.Visible = False
            GunaButtonImprimer.Visible = True
            'PAR DEFAUT ON TIRE LE FICHE STATISQUE DE LA VEILLE
            GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail.AddDays(-1)
            GunaDateTimePickerDebut.Enabled = True
            GunaDateTimePickerFin.Enabled = False

            GunaDateTimePickerDebut.MaxDate = CDate(GlobalVariable.DateDeTravail.AddDays(-1)).ToShortDateString
        Else
            GunaDateTimePickerDebut.MaxDate = CDate(GlobalVariable.DateDeTravail).ToShortDateString
        End If

        If GlobalVariable.DocumentToGenerate = "MOUCHARDS" Then

            utiliseteur()

            GunaLabel2.Visible = True
            GunaComboBoxUtilisateurDeMagasinBar.Visible = True
            GunaCheckBoxTous.Visible = True

        End If

        GunaLabelGeneral.Text = GlobalVariable.DocumentToGenerate

    End Sub

    Public Sub AutoLoadlisteMagasinSource()

        Dim table As DataTable = Functions.allTableFieldsOrganised("magasin", "LIBELLE_MAGASIN")

        If (table.Rows.Count > 0) Then

            GunaComboBoxMagasins.DataSource = table
            GunaComboBoxMagasins.ValueMember = "CODE_MAGASIN"
            GunaComboBoxMagasins.DisplayMember = "LIBELLE_MAGASIN"

        End If

    End Sub

    Public Sub utiliseteur()

        'ON NE SELECTIONNE QUE LES CEUX QUI PEUVENT VENDRE (UTILISATEUR POSSEDANT MAGASIN ET CAISSE)

        Dim Query As String = "SELECT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR FROM utilisateurs ORDER BY NOM_UTILISATEUR ASC"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@GRANDE_CAISSE", MySqlDbType.Int32).Value = 1

        Dim tableCaissier As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(tableCaissier)

        If tableCaissier.Rows.Count > 0 Then

            GunaComboBoxUtilisateurDeMagasinBar.DataSource = tableCaissier
            GunaComboBoxUtilisateurDeMagasinBar.ValueMember = "CODE_UTILISATEUR"
            GunaComboBoxUtilisateurDeMagasinBar.DisplayMember = "NOM_UTILISATEUR"

        End If

    End Sub

    Public Sub utiliseteurDeCaisse()

        'ON NE SELECTIONNE QUE LES CEUX QUI PEUVENT VENDRE (UTILISATEUR POSSEDANT MAGASIN ET CAISSE)

        'Dim Query As String = "SELECT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR, GRANDE_CAISSE From utilisateurs, utilisateur_acces, utilisateur_magazin WHERE utilisateurs.CATEG_UTILISATEUR=utilisateur_acces.CODE_PROFIL AND GRANDE_CAISSE=@GRANDE_CAISSE AND utilisateur_magazin.CODE_UTILISATEUR = utilisateurs.CODE_UTILISATEUR ORDER BY NOM_UTILISATEUR ASC"
        Dim Query As String = "SELECT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR, GRANDE_CAISSE From utilisateurs, utilisateur_acces WHERE utilisateurs.CATEG_UTILISATEUR=utilisateur_acces.CODE_PROFIL AND GRANDE_CAISSE=@GRANDE_CAISSE ORDER BY NOM_UTILISATEUR ASC"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@GRANDE_CAISSE", MySqlDbType.Int32).Value = 1

        Dim tableCaissier As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(tableCaissier)

        If (tableCaissier.Rows.Count > 0) Then

            GunaComboBoxUtilisateurDeMagasinBar.DataSource = tableCaissier
            GunaComboBoxUtilisateurDeMagasinBar.ValueMember = "CODE_UTILISATEUR"
            GunaComboBoxUtilisateurDeMagasinBar.DisplayMember = "NOM_UTILISATEUR"

        End If

    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToShortDateString
        Dim DateFin As Date = GunaDateTimePickerFin.Value.ToShortDateString
        Dim DATE_CONTROL As Date = CDate(DateDebut).ToShortDateString

        DataGridViewRapports.Columns.Clear()

        If GlobalVariable.DocumentToGenerate = "facture" Then

            Dim factureRapport As New Facture()

            Dim ListeDesFactures As DataTable = factureRapport.ListeDesFacturePourRapport(DateDebut, DateFin)
            'Dim ListeDesReglements As DataTable

            'LISTE DES FACTURES
            If ListeDesFactures.Rows.Count > 0 Then

                DataGridViewRapports.DataSource = ListeDesFactures
                DataGridViewRapports.Columns(4).DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaButtonImprimer.Visible = True

            Else

                DataGridViewRapports.Columns.Clear()

                GunaButtonImprimer.Visible = False

            End If

        ElseIf GlobalVariable.DocumentToGenerate = "REGLEMENTS" Then

            GunaLabelGeneral.Text = "REGLEMENTS"

            Dim reglementRapport As New Reglement()

            Dim ListeDesReglements As DataTable = reglementRapport.ListeDesReglementsPourRapport(DateDebut, DateFin)
            'Dim ListeDesReglements As DataTable

            'LISTE DES FACTURES
            If ListeDesReglements.Rows.Count > 0 Then

                DataGridViewRapports.DataSource = ListeDesReglements
                DataGridViewRapports.Columns(3).DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaButtonImprimer.Visible = True

            Else

                DataGridViewRapports.Columns.Clear()

                GunaButtonImprimer.Visible = False

            End If

        ElseIf GlobalVariable.DocumentToGenerate = "INVENTAIRE DU MAGASIN" Then

            GunaLabelGeneral.Text = "INVENTAIRE DU MAGASIN " & GlobalVariable.magasinActuel.ToUpper()

            Dim CODE_MAGASIN As String = ""

            If GunaComboBoxMagasins.SelectedIndex >= 0 Then
                CODE_MAGASIN = GunaComboBoxMagasins.SelectedValue.ToString
            End If

            Dim TYPE As String = "article"

            Dim FillingListquery As String = "SELECT * FROM article WHERE CODE_FAMILLE = @CODE_FAMILLE AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"
            Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
            Dim CODE_FAMILLE As String = "BOISSONS"
            commandList.Parameters.Add("@CODE_FAMILLE", MySqlDbType.VarChar).Value = CODE_FAMILLE
            commandList.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = TYPE
            commandList.Parameters.Add("@VISIBLE", MySqlDbType.Int32).Value = 1

            Dim adapterList As New MySqlDataAdapter(commandList)
            Dim tousLesArticles As New DataTable()

            adapterList.Fill(tousLesArticles)

            DataGridViewRapports.DataSource = Nothing

            DataGridViewRapports.Columns.Clear()

            DataGridViewRapports.Columns.Add("CODE_ARTICLE", "CODE ARTICLE")
            DataGridViewRapports.Columns.Add("LIBELLE", "DESIGNATION")
            DataGridViewRapports.Columns.Add("QUANTITE_EN_STOCK", "QUANTITE EN STOCK")
            DataGridViewRapports.Columns.Add("QUANTITE_PHYSIQUE", "QUANTITE PHYSIQUE")
            DataGridViewRapports.Columns.Add("COUT_DU_STOCK", "COUT DU STOCK")

            If tousLesArticles.Rows.Count > 0 Then

                Dim econom As New Economat()

                Dim CODE_ARTICLE As String = ""
                Dim LIBELLE_ARTICLE As String = ""
                Dim QUANTITE_EN_STOCK As Double = 0
                Dim COUT_DU_STOCK As Double = 0
                Dim PRIX_DE_VENTE As Double = 0

                For i = 0 To tousLesArticles.Rows.Count - 1

                    LIBELLE_ARTICLE = tousLesArticles.Rows(i)("DESIGNATION_FR")
                    CODE_ARTICLE = tousLesArticles.Rows(i)("CODE_ARTICLE")
                    QUANTITE_EN_STOCK = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)
                    'COUT_DU_STOCK = QUANTITE_EN_STOCK * tousLesArticles.Rows(i)("PRIX_ACHAT_HT")

                    PRIX_DE_VENTE = Functions.prixDeVenteDuMagasin(CODE_MAGASIN, tousLesArticles, i)
                    COUT_DU_STOCK = QUANTITE_EN_STOCK * PRIX_DE_VENTE

                    DataGridViewRapports.Rows.Add(CODE_ARTICLE, LIBELLE_ARTICLE, QUANTITE_EN_STOCK, "", COUT_DU_STOCK)

                Next

                'DataGridViewFactures.DataSource = tousLesArticles

                DataGridViewRapports.Columns("QUANTITE_EN_STOCK").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("QUANTITE_EN_STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridViewRapports.Columns("COUT_DU_STOCK").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("COUT_DU_STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridViewRapports.Columns("CODE_ARTICLE").Visible = False

                GunaButtonImprimer.Visible = True

            Else
                'GunaDataGridViewInventaire.Rows.Clear()
                GunaButtonImprimer.Visible = False
            End If

        ElseIf GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES" Then

            GunaLabelGeneral.Text = GlobalVariable.DocumentToGenerate & " JOURNALIER "

            Dim ventes As New LigneFacture()

            'Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
            Dim CODE_UTILISATEUR As String = ""

            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
                CODE_UTILISATEUR = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString
            End If

            'Dim ListeDesVentes As DataTable = ventes.ListeDesArticlesVendus(DateDebut, DateFin, CODE_UTILISATEUR)
            Dim ListeDesVentes As DataTable = ventes.ListeDesArticlesVendusJournalier(DateDebut, DateFin)
            'Dim ListeDesReglements As DataTable

            'LISTE DES FACTURES
            If ListeDesVentes.Rows.Count > 0 Then

                DataGridViewRapports.DataSource = ListeDesVentes
                DataGridViewRapports.Columns("MONTANT TOTAL").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("MONTANT TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridViewRapports.Columns("ARTICLE").Visible = False

                GunaButtonImprimer.Visible = True

            Else

                DataGridViewRapports.Columns.Clear()

                GunaButtonImprimer.Visible = False

            End If

        ElseIf GlobalVariable.DocumentToGenerate = "SITUATION DE CAISSE PERIODIQUE" Then

            Dim dtSpecific As New DataTable

            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then

                Dim CODE_CAISSIER As String = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString

                Dim getUserQuery1 = "SELECT DATE_REGLEMENT AS 'DATE REGLEMENT', REF_REGLEMENT AS REFEERNCE, MODE_REGLEMENT As 'MODE REGLEMENT', MONTANT_VERSE AS 'MONTANT' FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER < 3 ORDER BY DATE_REGLEMENT DESC"

                Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)

                command1.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER

                Dim adapter1 As New MySqlDataAdapter

                adapter1.SelectCommand = command1

                adapter1.Fill(dtSpecific)

            Else

                Dim getUserQuery1 = "SELECT DATE_REGLEMENT AS 'DATE REGLEMENT', REF_REGLEMENT AS REFEERNCE, MODE_REGLEMENT As 'MODE REGLEMENT', MONTANT_VERSE AS 'MONTANT' FROM reglement WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER < 3 ORDER BY DATE_REGLEMENT DESC"

                Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)

                Dim adapter1 As New MySqlDataAdapter
                adapter1.SelectCommand = command1
                adapter1.Fill(dtSpecific)

            End If

            If dtSpecific.Rows.Count > 0 Then
                GunaButtonImprimer.Visible = True
                DataGridViewRapports.DataSource = dtSpecific

                DataGridViewRapports.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
            Else
                GunaButtonImprimer.Visible = False
            End If

        ElseIf Trim(GlobalVariable.DocumentToGenerate) = "JOURNAL DES VENTES PERIODIQUE" Then

            GunaLabelGeneral.Text = GlobalVariable.DocumentToGenerate

            Dim ventes As New LigneFacture()

            Dim CODE_UTILISATEUR As String = ""

            'Dim ListeDesVentes As DataTable = ventes.ListeDesArticlesVendus(DateDebut, DateFin, CODE_UTILISATEUR)
            Dim ListeDesVentes As DataTable

            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
                CODE_UTILISATEUR = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString
                'ListeDesVentes = ventes.ListeDesArticlesVendus(DateDebut, DateFin, CODE_UTILISATEUR)
                ListeDesVentes = ventes.ListeDesArticlesVendus(DateDebut, DateFin, CODE_UTILISATEUR)
            Else
                ListeDesVentes = ventes.ListeDesArticlesVendusPeriodique(DateDebut, DateFin)
            End If

            DataGridViewRapports.DataSource = ListeDesVentes

            DataGridViewRapports.Columns("MONTANT TOTAL").DefaultCellStyle.Format = "#,##0"
            DataGridViewRapports.Columns("MONTANT TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewRapports.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0"
            DataGridViewRapports.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewRapports.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0"
            DataGridViewRapports.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridViewRapports.Columns("ARTICLE").Visible = False

            GunaButtonImprimer.Visible = True

        ElseIf GlobalVariable.DocumentToGenerate = "INVENTAIRE DES VENTES" Then

            GunaLabelGeneral.Text = GlobalVariable.DocumentToGenerate

            Dim ventes As New LigneFacture()

            Dim CODE_UTILISATEUR As String = ""

            Dim ListeDesVentes As New DataTable()

            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
                CODE_UTILISATEUR = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString
            End If

            ListeDesVentes = ventes.ListeDesArticlesVendusInventaire(DateDebut, DateFin, CODE_UTILISATEUR)

            If ListeDesVentes.Rows.Count > 0 Then

                DataGridViewRapports.Columns.Clear()
                DataGridViewRapports.Rows.Clear()

                DataGridViewRapports.Columns.Add("ARTICLE", "ARTICLE")
                DataGridViewRapports.Columns.Add("QUANTITE", "QTE VENDU")
                DataGridViewRapports.Columns.Add("STOCK", "STOCK ACTUEL")
                DataGridViewRapports.Columns.Add("PU", "PRIX UNITAIRE")
                DataGridViewRapports.Columns.Add("PA", "PRIX ACHAT")
                DataGridViewRapports.Columns.Add("MONTANT", "MONTANT TOTAL")
                DataGridViewRapports.Columns.Add("MARGE", "MARGE")

                Dim articleIndividuel As New DataTable()

                For i = 0 To ListeDesVentes.Rows.Count - 1

                    Dim CODE_ARTICLE As String = ListeDesVentes.Rows(i)("CODE_ARTICLE")
                    'Dim LIBELLE_FACTURE As String = ListeDesVentes.Rows(i)("LIBELLE_FACTURE")

                    Dim LIBELLE_FACTURE As String = ""
                    Dim FAMILLE As String = ""
                    Dim SUIVIE As String = ""

                    Dim PA As Double = 0
                    Dim STOCK As Double = 0

                    Dim infoArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                    If infoArticle.Rows.Count > 0 Then

                        LIBELLE_FACTURE = infoArticle.Rows(0)("DESIGNATION_FR")
                        PA = infoArticle.Rows(0)("COUT_U_MOYEN_PONDERE")

                        SUIVIE = infoArticle.Rows(0)("METHODE_SUIVI_STOCK")

                        'If Trim(SUIVIE).Equals("Suivi simple") Then
                        STOCK = infoArticle.Rows(0)("QUANTITE")
                        'Else

                        'End If

                    End If

                    Dim PRIXMOYENUNITAIRE As Double = 0
                    Dim QUANTITE As Double = 0
                    Dim MONTANT As Double = 0

                    Dim UNITE_DE_VENTE As String = ""

                    articleIndividuel = ventes.ListeDesArticlesVendusInventaireIndividuel(DateDebut, DateFin, CODE_UTILISATEUR, CODE_ARTICLE)

                    '------------------------------ NEW 18.08.2023 ------------------------------------------------

                    Dim QUANITE_CORRECTE_FORMAT = Functions.affichageQteDansUnFormatCorrect(CODE_ARTICLE, QUANTITE)

                    '----------------------------------------------------------------------------------------------

                    For j = 0 To articleIndividuel.Rows.Count - 1

                        UNITE_DE_VENTE = articleIndividuel.Rows(j)("CODE_LOT")

                        QUANTITE += articleIndividuel.Rows(j)("QUANTITE")
                        MONTANT += articleIndividuel.Rows(j)("MONTANT TOTAL")

                        If QUANTITE > 0 Then
                            PRIXMOYENUNITAIRE = MONTANT / QUANTITE
                        End If

                        QUANITE_CORRECTE_FORMAT += Functions.conversionEnPlusPetiteUnite(CODE_ARTICLE, articleIndividuel.Rows(j)("QUANTITE"), UNITE_DE_VENTE)

                    Next

                    Dim MARGE As Double = MONTANT - (QUANTITE * PA)

                    'DataGridViewRapports.Rows.Add(LIBELLE_FACTURE, QUANTITE, STOCK, PRIXMOYENUNITAIRE, PA, MONTANT, MARGE)

                    QUANITE_CORRECTE_FORMAT = Functions.affichageQteDansUnFormatCorrect(CODE_ARTICLE, QUANITE_CORRECTE_FORMAT)
                    Dim STOCK_CORRECTE_FORMAT = Functions.affichageQteDansUnFormatCorrect(CODE_ARTICLE, STOCK)

                    If Not Trim(LIBELLE_FACTURE).Equals("LIBELLE_FACTURE") Then
                        DataGridViewRapports.Rows.Add(LIBELLE_FACTURE, QUANITE_CORRECTE_FORMAT, STOCK_CORRECTE_FORMAT, PRIXMOYENUNITAIRE, PA, MONTANT, MARGE)
                    End If

                Next

                DataGridViewRapports.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("PU").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("PU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("STOCK").DefaultCellStyle.Format = "#,##0.00"
                DataGridViewRapports.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridViewRapports.Columns("PA").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("PA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("MARGE").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("MARGE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.00"
                DataGridViewRapports.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'DataGridViewFactures.Columns("ARTICLE").Visible = False

                GunaButtonImprimer.Visible = True

            End If

        ElseIf GlobalVariable.DocumentToGenerate = "MOUCHARDS" Then

            Dim query13 As String = ""
            Dim NOM_UTILISATEUR As String = ""
            Dim CODE_UTILISATEUR As String = ""
            Dim CODE_RESERVATION As String = GunaTextBoxCodeResa.Text

            If True Then

                'table trace

                If GunaCheckBoxPropResa.Checked Then

                    'POUR L'ENSEBLE DES RESERVATIONS RESERVATION
                    If GunaCheckBoxTous.Checked Then
                        query13 = "SELECT `ACTION`, `PAR`, `DATE_DE_CONTROLE` AS A, `UTILISATEUR_ID`, `CHAMBRE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, 
                    `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`,`MONTANT_ACCORDE`, `ADULTES`, `NB_PERSONNES` AS PAX, `ENFANTS`, 
                      `MONTANT_TOTAL_CAUTION`,  `GROUPE`,  `SOLDE_RESERVATION`, `CHAMBRE_ROUTAGE`, `VENANT_DE`, `SE_RENDANT_A`, 
                     `ROUTAGE`, `ETAT_NOTE_RESERVATION`, `CODE_ENTREPRISE`, `NOM_ENTREPRISE`, `BC_ENTREPRISE`, `TYPE_CHAMBRE`, `CODE_RESERVATION` FROM `trace` 
                    WHERE DATE_CREATION BETWEEN '" & DateDebut.ToString("yyyy-MM-dd") & "' AND '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY ID_TRACE, DATE_DE_CONTROLE ASC"
                    Else
                        query13 = "SELECT `ACTION`, `PAR`, `DATE_DE_CONTROLE` AS A, `UTILISATEUR_ID`, `CHAMBRE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, 
                    `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `MONTANT_ACCORDE`, `ADULTES`, `NB_PERSONNES` AS PAX, `ENFANTS`, 
                      `MONTANT_TOTAL_CAUTION`,  `GROUPE`, `SOLDE_RESERVATION`, `CHAMBRE_ROUTAGE`, `VENANT_DE`, `SE_RENDANT_A`, 
                    `ROUTAGE`, `ETAT_NOTE_RESERVATION`, `CODE_ENTREPRISE`, `NOM_ENTREPRISE`, `BC_ENTREPRISE`, `TYPE_CHAMBRE`, `CODE_RESERVATION` FROM `trace` 
                    WHERE UTILISATEUR_ID=@UTILISATEUR_ID AND DATE_CREATION BETWEEN '" & DateDebut.ToString("yyyy-MM-dd") & "' AND '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY ACTION, DATE_DE_CONTROLE ASC"

                        CODE_UTILISATEUR = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString

                    End If

                Else

                    'SPECIQUEMENT PAR APPORT A UNE RESERVATION
                    If GunaCheckBoxTous.Checked Then

                        query13 = "SELECT `ACTION`, `PAR`, `DATE_DE_CONTROLE` AS A, `UTILISATEUR_ID`, `CHAMBRE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, 
                    `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`,`MONTANT_ACCORDE`, `ADULTES`, `NB_PERSONNES` AS PAX, `ENFANTS`, 
                      `MONTANT_TOTAL_CAUTION`,  `GROUPE`,  `SOLDE_RESERVATION`, `CHAMBRE_ROUTAGE`, `VENANT_DE`, `SE_RENDANT_A`, 
                     `ROUTAGE`, `ETAT_NOTE_RESERVATION`, `CODE_ENTREPRISE`, `NOM_ENTREPRISE`,  `BC_ENTREPRISE`, `TYPE_CHAMBRE`, `CODE_RESERVATION`  FROM `trace` 
                    WHERE DATE_CREATION BETWEEN '" & DateDebut.ToString("yyyy-MM-dd") & "' AND '" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY ID_TRACE, DATE_DE_CONTROLE ASC"

                    Else
                        query13 = "SELECT `ACTION`, `PAR`, `DATE_DE_CONTROLE` AS A, `UTILISATEUR_ID`, `CHAMBRE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, 
                    `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `MONTANT_ACCORDE`, `ADULTES`, `NB_PERSONNES` AS PAX, `ENFANTS`, 
                      `MONTANT_TOTAL_CAUTION`,  `GROUPE`, `SOLDE_RESERVATION`, `CHAMBRE_ROUTAGE`, `VENANT_DE`, `SE_RENDANT_A`, 
                    `ROUTAGE`, `ETAT_NOTE_RESERVATION`, `CODE_ENTREPRISE`, `NOM_ENTREPRISE`, `BC_ENTREPRISE`, `TYPE_CHAMBRE`, `CODE_RESERVATION` FROM `trace` 
                    WHERE UTILISATEUR_ID=@UTILISATEUR_ID AND DATE_CREATION BETWEEN '" & DateDebut.ToString("yyyy-MM-dd") & "' AND '" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY ACTION, DATE_DE_CONTROLE ASC"

                        CODE_UTILISATEUR = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString

                    End If

                End If

            Else

                'table mourchards

                If GunaCheckBoxTous.Checked Then
                    query13 = "SELECT `ACTION`, `DATE_DE_CONTROLE` As 'DATE HEURE', `NOM_UTILISATEUR` As 'UTILISATEUR' FROM `mouchards` WHERE DATE_CREATION BETWEEN '" & DateDebut.ToString("yyyy-MM-dd") & "' AND '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY ACTION, DATE_DE_CONTROLE ASC"
                Else
                    query13 = "SELECT `ACTION`, `DATE_DE_CONTROLE` As 'DATE HEURE', `NOM_UTILISATEUR` As 'UTILISATEUR' FROM `mouchards` WHERE NOM_UTILISATEUR=@NOM_UTILISATEUR AND DATE_CREATION BETWEEN '" & DateDebut.ToString("yyyy-MM-dd") & "' AND '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY ACTION, DATE_DE_CONTROLE ASC"
                    CODE_UTILISATEUR = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString

                    Dim infoSupUSer As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "utilisateurs", "CODE_UTILISATEUR")

                    If infoSupUSer.Rows.Count > 0 Then
                        NOM_UTILISATEUR = infoSupUSer.Rows(0)("NOM_UTILISATEUR")
                    End If
                End If

            End If

            Dim command13 As New MySqlCommand(query13, GlobalVariable.connect)
            'command13.Parameters.Add("@NOM_UTILISATEUR", MySqlDbType.VarChar).Value = NOM_UTILISATEUR
            command13.Parameters.Add("@UTILISATEUR_ID", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
            command13.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
            Dim adapter13 As New MySqlDataAdapter(command13)
            Dim dt As New DataTable()
            adapter13.Fill(dt)

            If dt.Rows.Count > 0 Then

                DataGridViewRapports.Columns.Clear()

                DataGridViewRapports.DataSource = dt

                GunaButtonImprimer.Visible = True

            End If

        ElseIf GlobalVariable.DocumentToGenerate = "SITUATION MENSUEL DE L'ETABLISSEMENT" Then

            Me.Cursor = Cursors.WaitCursor

            ' -------------------------------------- SITUATION GENERALE DES PRESTATIONS -------------------------------------------------------
            Dim DateDebutStat As Date = GunaDateTimePickerDebut.Value.ToShortDateString
            Dim DateFinStat As Date = GunaDateTimePickerFin.Value.ToShortDateString

            ListeDesMainCourantesDujours()

            If DataGridViewRapports.Rows.Count > 0 Then
                GunaButtonImprimer.Visible = True
            Else
                GunaButtonImprimer.Visible = False
            End If

            Me.Cursor = Cursors.Default
            '---------------------------------------------------------------------------------------------------------------------------------------------

        ElseIf GlobalVariable.DocumentToGenerate = "FICHE DE VENTILATION" Then

            DataGridViewRapports.Columns.Clear()

            Dim NOM_CLIENT As String = ""
            Dim In_ As String = ""
            Dim Out_ As String = ""
            Dim blocNote As String = ""
            Dim pax As Integer = 0
            Dim breakfast As Double = 0
            Dim dejeuner As Double = 0
            Dim dinner As Double = 0
            Dim boisson As Double = 0
            Dim cash As Double = 0
            Dim visa As Double = 0
            Dim mobile_money As Double = 0
            Dim guest_in As Double = 0
            Dim observation As String = ""
            Dim compte As Double = 0
            Dim free As Double = 0
            Dim misc As Double = 0

            DataGridViewRapports.Columns.Add("No", "No")
            DataGridViewRapports.Columns.Add("CLIENT", "CLIENT")
            DataGridViewRapports.Columns.Add("IN", "IN")
            DataGridViewRapports.Columns.Add("OUT", "OUT")

            If GlobalVariable.actualLanguageValue = 0 Then
                DataGridViewRapports.Columns.Add("INVOICE", "INVOICE")
                DataGridViewRapports.Columns.Add("PAX", "PAX")
                DataGridViewRapports.Columns.Add("BRKFAST", "BRKFAST")
                DataGridViewRapports.Columns.Add("LUNCH", "LUNCH")
                DataGridViewRapports.Columns.Add("DINER", "DINER")
                DataGridViewRapports.Columns.Add("BEVERAGE", "BEVERAGE")
                DataGridViewRapports.Columns.Add("MISC.", "MISC.")
                DataGridViewRapports.Columns.Add("CASH", "CASH")
                DataGridViewRapports.Columns.Add("VISA", "VISA")
                DataGridViewRapports.Columns.Add("MOBIL", "MOBILE MONEY")
                DataGridViewRapports.Columns.Add("GUEST IN", "GUEST IN")
                DataGridViewRapports.Columns.Add("ACCOUNT", "ACCOUNT")
                DataGridViewRapports.Columns.Add("FREE", "FREE")
                DataGridViewRapports.Columns.Add("OBSERVATION", "OBSERVATION")
            Else
                DataGridViewRapports.Columns.Add("BLOC_NOTE", "BLOC NOTE")
                DataGridViewRapports.Columns.Add("PAX", "PAX")
                DataGridViewRapports.Columns.Add("BRKFAST", "BRKFAST")
                DataGridViewRapports.Columns.Add("LUNCH", "LUNCH")
                DataGridViewRapports.Columns.Add("DINER", "DINER")
                DataGridViewRapports.Columns.Add("BEVERAGE", "BEVERAGE")
                DataGridViewRapports.Columns.Add("AUTRES", "AUTRES")
                DataGridViewRapports.Columns.Add("CASH", "CASH")
                DataGridViewRapports.Columns.Add("VISA", "VISA")
                DataGridViewRapports.Columns.Add("MOBIL", "MOBILE MONEY")
                DataGridViewRapports.Columns.Add("EN CAHMBRE", "EN CAHMBRE")
                DataGridViewRapports.Columns.Add("COMPTE", "COMPTE")
                DataGridViewRapports.Columns.Add("GARTUIT", "GARTUIT")
                DataGridViewRapports.Columns.Add("OBSERVATION", "OBSERVATION")
            End If

            '1- SELECTION DE L'ENSEMBLE DES BLOC NOTES
            Dim CODE_CAISSIER As String = ""
            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
                CODE_CAISSIER = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString
            End If

            Dim blocNoteDuCaissier As DataTable
            Dim caisse As New Caisse

            blocNoteDuCaissier = caisse.blocNoteVentilation(DateDebut, DateFin, CODE_CAISSIER)

            If blocNoteDuCaissier.Rows.Count > 0 Then

                GunaButtonImprimer.Visible = True

                Dim NUMERO_BLOC_NOTE As String = ""
                Dim NUMERO_BLOC_NOTE_VERIF As String = ""
                Dim CODE_CLIENT As String = ""
                Dim montant As Double = 0
                Dim ETAT_FACTURE As Integer = -1
                Dim infoSupClient As DataTable

                For i = 0 To blocNoteDuCaissier.Rows.Count - 1

                    NOM_CLIENT = ""
                    In_ = ""
                    Out_ = ""
                    blocNote = ""
                    pax = 0
                    breakfast = 0
                    dejeuner = 0
                    dinner = 0
                    boisson = 0
                    cash = 0
                    visa = 0
                    mobile_money = 0
                    guest_in = 0
                    observation = ""
                    compte = 0
                    free = 0
                    misc = 0

                    NUMERO_BLOC_NOTE_VERIF = blocNoteDuCaissier.Rows(i)("NUMERO_BLOC_NOTE_VERIF")
                    ETAT_FACTURE = Integer.Parse(blocNoteDuCaissier.Rows(i)("ETAT_FACTURE"))
                    CODE_CLIENT = blocNoteDuCaissier.Rows(i)("CODE_CLIENT")

                    If ETAT_FACTURE = 1 Then

                    Else

                        infoSupClient = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")
                        If infoSupClient.Rows.Count > 0 Then
                            NOM_CLIENT = infoSupClient.Rows(0)("NOM_CLIENT")
                        End If

                    End If

                    If ETAT_FACTURE = 1 Then
                        If GlobalVariable.actualLanguageValue = 1 Then
                            In_ = "V"
                            Out_ = ""
                        Else
                            In_ = "V"
                            Out_ = ""
                        End If
                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            In_ = ""
                            Out_ = "V"
                        Else
                            In_ = ""
                            Out_ = "V"
                        End If
                    End If

                    NUMERO_BLOC_NOTE = blocNoteDuCaissier.Rows(i)("NUMERO_BLOC_NOTE")

                    Dim getReglement = "SELECT * FROM reglement WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

                    Dim commandReg As New MySqlCommand(getReglement, GlobalVariable.connect)
                    commandReg.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE

                    Dim adapterReg As New MySqlDataAdapter

                    Dim dtReg As New DataTable()

                    adapterReg.SelectCommand = commandReg
                    adapterReg.Fill(dtReg)

                    If dtReg.Rows.Count > 0 Then

                        If ETAT_FACTURE = 0 Then
                            For l = 0 To dtReg.Rows.Count - 1
                                If dtReg.Rows(l)("MODE_REGLEMENT").Equals("Espèce") Or dtReg.Rows(l)("MODE_REGLEMENT").Equals("Cash") Then
                                    cash += dtReg.Rows(l)("MONTANT_VERSE")
                                ElseIf dtReg.Rows(l)("MODE_REGLEMENT").Equals("MTN Money") Or dtReg.Rows(l)("MODE_REGLEMENT").Equals("ORANGE Money") Then
                                    mobile_money += dtReg.Rows(l)("MONTANT_VERSE")
                                ElseIf dtReg.Rows(l)("MODE_REGLEMENT").Equals("Chèque") Or dtReg.Rows(l)("MODE_REGLEMENT").Equals("Cheque") Or
                                        dtReg.Rows(l)("MODE_REGLEMENT").Equals("Virement Bancaire") Or dtReg.Rows(l)("MODE_REGLEMENT").Equals("Bank Transfer") Or
                                    dtReg.Rows(l)("MODE_REGLEMENT").Equals("Carte Bancaire") Or dtReg.Rows(l)("MODE_REGLEMENT").Equals("Credit Card") Then
                                    visa += dtReg.Rows(l)("MONTANT_VERSE")
                                End If
                            Next
                        End If

                    End If

                    If ETAT_FACTURE = 1 Then
                        guest_in += blocNoteDuCaissier.Rows(i)("MONTANT_BLOC_NOTE")
                    ElseIf ETAT_FACTURE = 2 Then
                        compte += blocNoteDuCaissier.Rows(i)("MONTANT_BLOC_NOTE")
                    ElseIf ETAT_FACTURE = 3 Then
                        free += blocNoteDuCaissier.Rows(i)("MONTANT_BLOC_NOTE")
                    End If

                    Dim ligne_facture As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture", "NUMERO_BLOC_NOTE")

                    If Not ligne_facture.Rows.Count > 0 Then
                        ligne_facture = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture", "NUMERO_SERIE_FIN")
                    End If

                    If ligne_facture.Rows.Count > 0 Then

                        For m = 0 To ligne_facture.Rows.Count - 1

                            pax += ligne_facture.Rows(m)("QUANTITE")

                            If ligne_facture.Rows(m)("TYPE_LIGNE_FACTURE").Equals("BAR") Then
                                boisson += ligne_facture.Rows(m)("MONTANT_TTC")
                            ElseIf ligne_facture.Rows(m)("TYPE_LIGNE_FACTURE").Equals("RESTAURANT") Then

                                If ligne_facture.Rows(m)("FUSIONNEE").Equals("DEJEUNER") Then
                                    dejeuner += ligne_facture.Rows(m)("MONTANT_TTC")
                                ElseIf ligne_facture.Rows(m)("FUSIONNEE").Equals("DINER") Then
                                    dinner += ligne_facture.Rows(m)("MONTANT_TTC")
                                ElseIf ligne_facture.Rows(m)("FUSIONNEE").Equals("PETIT DEJEUNER") Then
                                    breakfast += ligne_facture.Rows(m)("MONTANT_TTC")
                                Else
                                    dejeuner += ligne_facture.Rows(m)("MONTANT_TTC")
                                End If

                            Else
                                misc += ligne_facture.Rows(m)("MONTANT_TTC")
                            End If

                        Next

                    End If

                    DataGridViewRapports.Rows.Add(i + 1, NOM_CLIENT, In_, Out_, NUMERO_BLOC_NOTE_VERIF, pax, breakfast, dejeuner, dinner, boisson, misc, cash, visa, mobile_money, guest_in, free, compte, observation)

                Next

                DataGridViewRapports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                DataGridViewRapports.AutoResizeColumns()

            Else
                GunaButtonImprimer.Visible = False
            End If

        ElseIf GlobalVariable.DocumentToGenerate = "STATISTQIUES DES PRIX MOYENS" Then

            Dim DateDebutStat As Date = GunaDateTimePickerDebut.Value.ToShortDateString
            Dim DateFinStat As Date = GunaDateTimePickerFin.Value.ToShortDateString

            Dim nombreDejour As Integer = CType((DateFinStat - DateDebutStat).TotalDays, Int32)

            DataGridViewRapports.Columns.Clear()

            Dim roomTypes As DataTable = Functions.GetAllElementsOnCondition("chambre", "type_chambre", "TYPE")

            If roomTypes.Rows.Count > 0 Then

                DataGridViewRapports.Columns.Add("DATE", "DATE")

                For i = 0 To roomTypes.Rows.Count - 1
                    DataGridViewRapports.Columns.Add(roomTypes.Rows(i)("LIBELLE_TYPE_CHAMBRE"), roomTypes.Rows(i)("LIBELLE_TYPE_CHAMBRE"))
                Next

                For i = 0 To nombreDejour - 1

                    Dim datePVM As Date = DateDebutStat.AddDays(i).ToShortDateString

                    For j = 0 To roomTypes.Rows.Count - 1
                        prixDeVenteMoyen(j, roomTypes, datePVM)
                    Next

                    If roomTypes.Rows.Count = 1 Then
                        DataGridViewRapports.Rows.Add(CDate(datePVM).ToShortDateString, PVM_1)
                    ElseIf roomTypes.Rows.Count = 2 Then
                        DataGridViewRapports.Rows.Add(CDate(datePVM).ToShortDateString, PVM_1, PVM_2)
                    ElseIf roomTypes.Rows.Count = 3 Then
                        DataGridViewRapports.Rows.Add(CDate(datePVM).ToShortDateString, PVM_1, PVM_2, PVM_3)
                    ElseIf roomTypes.Rows.Count = 4 Then
                        DataGridViewRapports.Rows.Add(CDate(datePVM).ToShortDateString, PVM_1, PVM_2, PVM_3, PVM_4)
                    ElseIf roomTypes.Rows.Count = 5 Then
                        DataGridViewRapports.Rows.Add(CDate(datePVM).ToShortDateString, PVM_1, PVM_2, PVM_3, PVM_4, PVM_5)
                    ElseIf roomTypes.Rows.Count = 6 Then
                        DataGridViewRapports.Rows.Add(CDate(datePVM).ToShortDateString, PVM_1, PVM_2, PVM_3, PVM_4, PVM_5, PVM_6)
                    End If

                Next

                If DataGridViewRapports.Rows.Count > 0 Then

                    GunaButtonImprimer.Visible = True

                    For i = 1 To DataGridViewRapports.Columns.Count - 1
                        DataGridViewRapports.Columns(i).DefaultCellStyle.Format = "#,##0"
                        DataGridViewRapports.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next

                Else
                    GunaButtonImprimer.Visible = False
                End If

                PVM_1 = 0
                PVM_2 = 0
                PVM_3 = 0
                PVM_4 = 0
                PVM_5 = 0
                PVM_6 = 0

            End If

        ElseIf GlobalVariable.DocumentToGenerate = "STATISTQIUES DU DASHBOARD" Then

            Dim DateDebutStat As Date = GunaDateTimePickerDebut.Value.ToShortDateString
            Dim DateFinStat As Date = GunaDateTimePickerFin.Value.ToShortDateString

            Dim nombreDejour As Integer = CType((DateFinStat - DateDebutStat).TotalDays, Int32)

            DataGridViewRapports.Columns.Clear()

            Dim roomTypes As DataTable = Functions.GetAllElementsOnCondition("chambre", "type_chambre", "TYPE")

            'Dim total As Integer = 0

            If roomTypes.Rows.Count > 0 Then

                DataGridViewRapports.Columns.Add("DATE", "DATE")

                For i = 0 To roomTypes.Rows.Count - 1
                    DataGridViewRapports.Columns.Add(roomTypes.Rows(i)("LIBELLE_TYPE_CHAMBRE"), roomTypes.Rows(i)("LIBELLE_TYPE_CHAMBRE"))
                Next

                For i = 0 To nombreDejour - 1

                    Dim dateTOJ As Date = DateDebutStat.AddDays(i).ToShortDateString

                    For j = 0 To roomTypes.Rows.Count - 1
                        tauxOccupationJournalier(j, roomTypes, dateTOJ)
                    Next

                    If roomTypes.Rows.Count = 1 Then
                        DataGridViewRapports.Rows.Add(CDate(dateTOJ).ToShortDateString, TOJ_1)
                    ElseIf roomTypes.Rows.Count = 2 Then
                        DataGridViewRapports.Rows.Add(CDate(dateTOJ).ToShortDateString, TOJ_1, TOJ_2)
                    ElseIf roomTypes.Rows.Count = 3 Then
                        DataGridViewRapports.Rows.Add(CDate(dateTOJ).ToShortDateString, TOJ_1, TOJ_2, TOJ_3)
                    ElseIf roomTypes.Rows.Count = 4 Then
                        DataGridViewRapports.Rows.Add(CDate(dateTOJ).ToShortDateString, TOJ_1, TOJ_2, TOJ_3, TOJ_4)
                    ElseIf roomTypes.Rows.Count = 5 Then
                        DataGridViewRapports.Rows.Add(CDate(dateTOJ).ToShortDateString, TOJ_1, TOJ_2, TOJ_3, TOJ_4, TOJ_5)
                    ElseIf roomTypes.Rows.Count = 6 Then
                        DataGridViewRapports.Rows.Add(CDate(dateTOJ).ToShortDateString, TOJ_1, TOJ_2, TOJ_3, TOJ_4, TOJ_5, TOJ_6)
                    End If

                Next

                If DataGridViewRapports.Rows.Count > 0 Then

                    GunaButtonImprimer.Visible = True

                    For i = 1 To DataGridViewRapports.Columns.Count - 1
                        DataGridViewRapports.Columns(i).DefaultCellStyle.Format = "#,##0.00"
                        DataGridViewRapports.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next

                Else
                    GunaButtonImprimer.Visible = False
                End If

                TOJ_1 = 0
                TOJ_2 = 0
                TOJ_3 = 0
                TOJ_4 = 0
                TOJ_5 = 0
                TOJ_6 = 0

            End If

        ElseIf GlobalVariable.DocumentToGenerate = "FICHE D'INVENTAIRE JOURNALIERE BAR" Then

            Dim CODE_MAGASIN As String = ""

            If GunaComboBoxMagasins.SelectedIndex >= 0 Then
                CODE_MAGASIN = GunaComboBoxMagasins.SelectedValue.ToString
            End If

            GunaDateTimePickerDebut.Enabled = True

            DataGridViewRapports.Columns.Add("DESIGNATION", "DESIGNATION")

            DataGridViewRapports.Columns.Add("STOCK_INITIAL_MATIN", "SI MATIN")
            DataGridViewRapports.Columns.Add("ENTREE_MATIN", "ENTREE MATIN")
            DataGridViewRapports.Columns.Add("SORTIE_MATIN", "SORTIE MATIN")
            DataGridViewRapports.Columns.Add("STOCK_FINAL_MATIN", "SF MATIN")

            DataGridViewRapports.Columns.Add("STOCK_INITIAL_SOIR", "SI SOIR")
            DataGridViewRapports.Columns.Add("ENTREE_SOIR", "ENTREE SOIR")
            DataGridViewRapports.Columns.Add("SORTIE_SOIR", "SORTIE SOIR")
            DataGridViewRapports.Columns.Add("STOCK_FINAL_SOIR", "SF SOIR")

            DataGridViewRapports.Columns.Add("CODE_ARTICLE", "CODE_ARTICLE")

            Dim CODE_CAISSIER As String = ""

            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
                CODE_CAISSIER = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString
            End If

            '--------------------------------------------------------------------------------------------------------

            'ON SELECTIONNE LES ELEMENTS PERMETTANT LA GESTION DES SHIFTS

            Dim query_ As String = "SELECT * FROM gesion_des_shifts WHERE DATE_SHIFT <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SHIFT >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_MAGASIN=@CODE_MAGASIN ORDER BY INDEX_SHIFT ASC"
            Dim command_ As New MySqlCommand(query_, GlobalVariable.connect)

            Dim adapter_ As New MySqlDataAdapter
            command_.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
            Dim gesion_des_shifts_ As New DataTable()

            adapter_.SelectCommand = command_

            adapter_.Fill(gesion_des_shifts_)

            '--------------------------------------------------------------------------------------------------------

            'ON SELECTIONNE UNIQUEMENT LES BOISSONS

            Dim getUserQuery1 = "SELECT CODE_ARTICLE, DESIGNATION_FR, CODE_FAMILLE, QUANTITE FROM article WHERE CODE_FAMILLE = @CODE_FAMILLE AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

            Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)
            Dim CODE_FAMILLE As String = "BOISSONS"
            Dim TYPE As String = "article"
            Dim VISIBLE As Integer = 1

            command1.Parameters.Add("@CODE_FAMILLE", MySqlDbType.VarChar).Value = CODE_FAMILLE
            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = TYPE
            command1.Parameters.Add("@VISIBLE", MySqlDbType.Int32).Value = VISIBLE

            Dim adapter1 As New MySqlDataAdapter

            Dim ficheInventaireJournaliere As New DataTable()

            adapter1.SelectCommand = command1

            adapter1.Fill(ficheInventaireJournaliere)

            If ficheInventaireJournaliere.Rows.Count > 0 Then

                GunaButton16.Visible = True
                GunaButtonImprimer.Visible = True

                DataGridViewRapports.Rows.Clear()

                Dim tempsDeMouvement As DateTime

                Dim CODE_ARTICLE As String = ""

                For j = 0 To ficheInventaireJournaliere.Rows.Count - 1

                    Dim SI_MATIN As Double = 0
                    Dim SF_MATIN As Double = 0
                    Dim ENTREE_MATIN As Double = 0
                    Dim SORTIE_MATIN As Double = 0

                    Dim SI_SOIR As Double = 0
                    Dim SF_SOIR As Double = 0
                    Dim ENTREE_SOIR As Double = 0
                    Dim SORTIE_SOIR As Double = 0

                    CODE_ARTICLE = ficheInventaireJournaliere.Rows(j)("CODE_ARTICLE")

                    Dim INDEX_SHIFT As Integer = -1

                    If gesion_des_shifts_.Rows.Count > 0 Then

                        Dim econom As New Economat()

                        Dim DATE_DE_CONTROLE_DEBUT As DateTime
                        Dim DATE_DE_CONTROLE_FIN As DateTime
                        Dim natureInformation As Integer

                        For i = 0 To gesion_des_shifts_.Rows.Count - 1

                            INDEX_SHIFT = gesion_des_shifts_.Rows(i)("INDEX_SHIFT")
                            DATE_DE_CONTROLE_DEBUT = gesion_des_shifts_.Rows(i)("DATE_DE_CONTROLE_DEBUT")
                            DATE_DE_CONTROLE_FIN = gesion_des_shifts_.Rows(i)("DATE_DE_CONTROLE_FIN")

                            If INDEX_SHIFT = 0 Then

                                natureInformation = 4
                                SF_MATIN = econom.inventaireJornalierDuBarRestaurant(CODE_MAGASIN, CODE_ARTICLE, DATE_DE_CONTROLE_DEBUT, DATE_DE_CONTROLE_FIN, natureInformation, DATE_CONTROL)

                                natureInformation = 2
                                ENTREE_MATIN = econom.inventaireJornalierDuBarRestaurant(CODE_MAGASIN, CODE_ARTICLE, DATE_DE_CONTROLE_DEBUT, DATE_DE_CONTROLE_FIN, natureInformation, DATE_CONTROL)

                                natureInformation = 3
                                SORTIE_MATIN = econom.inventaireJornalierDuBarRestaurant(CODE_MAGASIN, CODE_ARTICLE, DATE_DE_CONTROLE_DEBUT, DATE_DE_CONTROLE_FIN, natureInformation, DATE_CONTROL)

                                SI_MATIN = SF_MATIN - ENTREE_MATIN + SORTIE_MATIN

                                If SI_MATIN < 0 Then
                                    SI_MATIN = 0
                                End If

                            ElseIf INDEX_SHIFT = 1 Then

                                natureInformation = 4
                                SF_SOIR = econom.inventaireJornalierDuBarRestaurant(CODE_MAGASIN, CODE_ARTICLE, DATE_DE_CONTROLE_DEBUT, DATE_DE_CONTROLE_FIN, natureInformation, DATE_CONTROL)

                                natureInformation = 2
                                ENTREE_SOIR = econom.inventaireJornalierDuBarRestaurant(CODE_MAGASIN, CODE_ARTICLE, DATE_DE_CONTROLE_DEBUT, DATE_DE_CONTROLE_FIN, natureInformation, DATE_CONTROL)

                                natureInformation = 3
                                SORTIE_SOIR = econom.inventaireJornalierDuBarRestaurant(CODE_MAGASIN, CODE_ARTICLE, DATE_DE_CONTROLE_DEBUT, DATE_DE_CONTROLE_FIN, natureInformation, DATE_CONTROL)

                                SI_SOIR = SF_SOIR - ENTREE_SOIR + SORTIE_SOIR

                                If SI_SOIR < 0 Then
                                    SI_SOIR = 0
                                End If

                            ElseIf INDEX_SHIFT = 2 Then
                                'SHIFT DE NUIT

                            End If

                        Next

                    End If

                    'AFFICHAGE DES INFORMATION DE CHAQUE ARTICLE
                    DataGridViewRapports.Rows.Add(ficheInventaireJournaliere.Rows(j)("DESIGNATION_FR"), SI_MATIN, ENTREE_MATIN, SORTIE_MATIN, SF_MATIN, SI_SOIR, ENTREE_SOIR, SORTIE_SOIR, SF_SOIR, CODE_ARTICLE)

                Next

                If DataGridViewRapports.Rows.Count > 0 Then
                    DataGridViewRapports.Columns("CODE_ARTICLE").Visible = False
                End If

            Else
                GunaButton16.Visible = False
                GunaButtonImprimer.Visible = False
            End If

        ElseIf GlobalVariable.DocumentToGenerate = "HEBERGEMENT" Then

            Dim DateDebutStat As Date = GunaDateTimePickerDebut.Value.ToShortDateString
            Dim DateFinStat As Date = GunaDateTimePickerFin.Value.ToShortDateString

            Dim nombreDejour As Integer = CType((DateFinStat - DateDebutStat).TotalDays, Int32)

            nombreDejour += 1
            DataGridViewRapports.Columns.Clear()

            Dim query_ As String = "SELECT DISTINCT TYPE_LIGNE_FACTURE FROM ligne_facture WHERE DATE_FACTURE <= '" & DateFinStat.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE >='" & DateDebutStat.ToString("yyyy-MM-dd") & "' ORDER BY TYPE_LIGNE_FACTURE ASC"
            Dim command_ As New MySqlCommand(query_, GlobalVariable.connect)

            Dim adapter_ As New MySqlDataAdapter

            Dim table As New DataTable()

            adapter_.SelectCommand = command_

            adapter_.Fill(table)

            If table.Rows.Count > 0 Then

                Dim nombreDePointDeVente = table.Rows.Count

                'AJOUT DES EN TETES

                DataGridViewRapports.Columns.Add("DATE", "DATE")

                For i = 0 To table.Rows.Count - 1

                    If Not Trim(table.Rows(i)("TYPE_LIGNE_FACTURE")).Equals("") Then
                        DataGridViewRapports.Columns.Add(table.Rows(i)("TYPE_LIGNE_FACTURE"), table.Rows(i)("TYPE_LIGNE_FACTURE"))
                    End If
                    'service.Rows.Add(table.Rows(i)("TYPE_LIGNE_FACTURE"))
                Next

                Dim ligne_facture As New LigneFacture()

                For i = 0 To nombreDejour - 1

                    Dim venteDu As Date = DateDebutStat.AddDays(i).ToShortDateString

                    For j = 0 To table.Rows.Count - 1
                        valeursDuService(j, table, venteDu)
                    Next

                    If table.Rows.Count = 1 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1)
                    ElseIf table.Rows.Count = 2 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2)
                    ElseIf table.Rows.Count = 3 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3)
                    ElseIf table.Rows.Count = 4 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4)
                    ElseIf table.Rows.Count = 5 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4, montantService_5)
                    ElseIf table.Rows.Count = 6 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4, montantService_5, montantService_6)
                    ElseIf table.Rows.Count = 7 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4, montantService_5, montantService_6, montantService_7)
                    ElseIf table.Rows.Count = 8 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4, montantService_5, montantService_6, montantService_7, montantService_8)
                    ElseIf table.Rows.Count = 9 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4, montantService_5, montantService_6, montantService_7, montantService_8, montantService_9)
                    ElseIf table.Rows.Count = 10 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4, montantService_5, montantService_6, montantService_7, montantService_8, montantService_9, montantService_10)
                    ElseIf table.Rows.Count = 11 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4, montantService_5, montantService_6, montantService_7, montantService_8, montantService_9, montantService_10, montantService_11)
                    ElseIf table.Rows.Count = 12 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, montantService_2, montantService_3, montantService_4, montantService_5, montantService_6, montantService_7, montantService_8, montantService_9, montantService_10, montantService_11, montantService_12)
                    End If

                Next

            End If

            If DataGridViewRapports.Rows.Count > 0 Then

                GunaButtonImprimer.Visible = True

                For i = 1 To DataGridViewRapports.Columns.Count - 1
                    DataGridViewRapports.Columns(i).DefaultCellStyle.Format = "#,##0"
                    DataGridViewRapports.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next

            Else
                GunaButtonImprimer.Visible = False
            End If

            montantService_1 = 0
            montantService_2 = 0
            montantService_3 = 0
            montantService_4 = 0
            montantService_5 = 0
            montantService_6 = 0
            montantService_7 = 0
            montantService_8 = 0
            montantService_9 = 0
            montantService_10 = 0
            montantService_11 = 0
            montantService_12 = 0


        ElseIf GlobalVariable.DocumentToGenerate = "PERIODIC ACCOMMODATION REPORT" Then

            Dim DateDebutStat As Date = GunaDateTimePickerDebut.Value.ToShortDateString
            Dim DateFinStat As Date = GunaDateTimePickerFin.Value.ToShortDateString

            Dim nombreDejour As Integer = CType((DateFinStat - DateDebutStat).TotalDays, Int32)

            nombreDejour += 1
            DataGridViewRapports.Columns.Clear()

            Dim table As DataTable = Functions.GetAllElementsOnCondition("chambre", "type_chambre", "TYPE")

            If table.Rows.Count > 0 Then

                'AJOUT DES EN TETES
                DataGridViewRapports.Columns.Add("DATE", "DATE")

                For i = 0 To table.Rows.Count - 1

                    If Not Trim(table.Rows(i)("CODE_TYPE_CHAMBRE")).Equals("") Then
                        DataGridViewRapports.Columns.Add(table.Rows(i)("CODE_TYPE_CHAMBRE"), table.Rows(i)("CODE_TYPE_CHAMBRE"))
                        DataGridViewRapports.Columns.Add("NIGHTS", "NIGHTS")
                    End If

                Next

                Dim ligne_facture As New LigneFacture()

                Dim INCOM_GENERATED_CASHED_IN As Integer = 1

                For i = 0 To nombreDejour - 1

                    Dim venteDu As Date = DateDebutStat.AddDays(i).ToShortDateString

                    'On parcours les types de chambres
                    For j = 0 To table.Rows.Count - 1
                        valeursRapportHegergement(j, table, venteDu, INCOM_GENERATED_CASHED_IN)
                    Next

                    If table.Rows.Count = 1 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, nights_1)
                    ElseIf table.Rows.Count = 2 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, nights_1, montantService_2, nights_2)
                    ElseIf table.Rows.Count = 3 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, nights_1, montantService_2, nights_2, montantService_3, nights_3)
                    ElseIf table.Rows.Count = 4 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, nights_1, montantService_2, nights_2, montantService_3, nights_3, montantService_4, nights_4)
                    ElseIf table.Rows.Count = 5 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, nights_1, montantService_2, nights_2, montantService_3, nights_3, montantService_4, nights_4, montantService_5, nights_5)
                    ElseIf table.Rows.Count = 6 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, nights_1, montantService_2, nights_2, montantService_3, nights_3, montantService_4, nights_4, montantService_5, nights_5, montantService_6, nights_6)
                    ElseIf table.Rows.Count = 7 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, nights_1, montantService_2, nights_7, montantService_3, nights_3, montantService_4, nights_4, montantService_5, nights_5, montantService_6, nights_6, montantService_7, nights_7)
                    ElseIf table.Rows.Count = 8 Then
                        DataGridViewRapports.Rows.Add(CDate(venteDu).ToShortDateString, montantService_1, nights_1, montantService_2, nights_2, montantService_3, nights_3, montantService_4, nights_4, montantService_5, nights_5, montantService_6, nights_6, montantService_7, nights_7, montantService_8, nights_8)
                    End If

                Next

            End If

            If DataGridViewRapports.Rows.Count > 0 Then

                GunaButtonImprimer.Visible = True

                For i = 1 To DataGridViewRapports.Columns.Count - 1
                    DataGridViewRapports.Columns(i).DefaultCellStyle.Format = "#,##0"
                    DataGridViewRapports.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next

            Else
                GunaButtonImprimer.Visible = False
            End If

            montantService_1 = 0
            montantService_2 = 0
            montantService_3 = 0
            montantService_4 = 0
            montantService_5 = 0
            montantService_6 = 0
            montantService_7 = 0
            montantService_8 = 0
            montantService_9 = 0
            montantService_10 = 0
            montantService_11 = 0
            montantService_12 = 0

            nights_1 = 0
            nights_2 = 0
            nights_3 = 0
            nights_4 = 0
            nights_5 = 0
            nights_6 = 0
            nights_7 = 0
            nights_8 = 0
            nights_9 = 0
            nights_10 = 0
            nights_11 = 0
            nights_12 = 0

        End If

    End Sub

    Dim nights_1 As Integer = 0
    Dim nights_2 As Integer = 0
    Dim nights_3 As Integer = 0
    Dim nights_4 As Integer = 0
    Dim nights_5 As Integer = 0
    Dim nights_6 As Integer = 0
    Dim nights_7 As Integer = 0
    Dim nights_8 As Integer = 0
    Dim nights_9 As Integer = 0
    Dim nights_10 As Integer = 0
    Dim nights_11 As Integer = 0
    Dim nights_12 As Integer = 0

    Dim montantService_1 As Double = 0
    Dim montantService_2 As Double = 0
    Dim montantService_3 As Double = 0
    Dim montantService_4 As Double = 0
    Dim montantService_5 As Double = 0
    Dim montantService_6 As Double = 0
    Dim montantService_7 As Double = 0
    Dim montantService_8 As Double = 0
    Dim montantService_9 As Double = 0
    Dim montantService_10 As Double = 0
    Dim montantService_11 As Double = 0
    Dim montantService_12 As Double = 0

    Dim TOJ_1 As Integer = 0
    Dim TOJ_2 As Integer = 0
    Dim TOJ_3 As Integer = 0
    Dim TOJ_4 As Integer = 0
    Dim TOJ_5 As Integer = 0
    Dim TOJ_6 As Integer = 0

    Dim PVM_1 As Integer = 0
    Dim PVM_2 As Integer = 0
    Dim PVM_3 As Integer = 0
    Dim PVM_4 As Integer = 0
    Dim PVM_5 As Integer = 0
    Dim PVM_6 As Integer = 0

    Public Function prixDeVenteMoyen(ByVal j As Integer, ByVal roomTypes As DataTable, ByVal dateStat As Date)

        Dim roomType As String = ""

        Dim prixMoyen As Double = 0
        Dim nbreChambreTotalVendu As Integer = 0

        If j = 0 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreTotalVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count
            prixMoyen = Functions.enChambrePrixMoyen(dateStat, dateStat, roomType)

            If nbreChambreTotalVendu > 0 Then
                PVM_1 = prixMoyen / nbreChambreTotalVendu
            End If

        ElseIf j = 1 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreTotalVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count
            prixMoyen = Functions.enChambrePrixMoyen(dateStat, dateStat, roomType)

            If nbreChambreTotalVendu > 0 Then
                PVM_2 = prixMoyen / nbreChambreTotalVendu
            End If

        ElseIf j = 2 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreTotalVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count
            prixMoyen = Functions.enChambrePrixMoyen(dateStat, dateStat, roomType)

            If nbreChambreTotalVendu > 0 Then
                PVM_3 = prixMoyen / nbreChambreTotalVendu
            End If

        ElseIf j = 3 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreTotalVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count
            prixMoyen = Functions.enChambrePrixMoyen(dateStat, dateStat, roomType)

            If nbreChambreTotalVendu > 0 Then
                PVM_4 = prixMoyen / nbreChambreTotalVendu
            End If

        ElseIf j = 4 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreTotalVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count
            prixMoyen = Functions.enChambrePrixMoyen(dateStat, dateStat, roomType)

            If nbreChambreTotalVendu > 0 Then
                PVM_5 = prixMoyen / nbreChambreTotalVendu
            End If

        ElseIf j = 5 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreTotalVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count
            prixMoyen = Functions.enChambrePrixMoyen(dateStat, dateStat, roomType)

            If nbreChambreTotalVendu > 0 Then
                PVM_6 = prixMoyen / nbreChambreTotalVendu
            End If

        End If

    End Function

    Public Function tauxOccupationJournalier(ByVal j As Integer, ByVal roomTypes As DataTable, ByVal dateStat As Date)

        Dim roomType As String = ""

        Dim nbreChambreVendu As Integer = 0
        Dim nbreChambreTotalDuType As Integer = 0

        If j = 0 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count

            Dim nombreDeChambreDUnCertainType As DataTable = Functions.getElementByCode(roomType, "chambre", "CODE_TYPE_CHAMBRE")

            If nombreDeChambreDUnCertainType.Rows.Count > 0 Then
                nbreChambreTotalDuType = nombreDeChambreDUnCertainType.Rows.Count
            End If

            If nbreChambreTotalDuType > 0 Then

                TOJ_1 = (nbreChambreVendu / nbreChambreTotalDuType) * 100

            End If

        ElseIf j = 1 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count

            Dim nombreDeChambreDUnCertainType As DataTable = Functions.getElementByCode(roomType, "chambre", "CODE_TYPE_CHAMBRE")

            If nombreDeChambreDUnCertainType.Rows.Count > 0 Then
                nbreChambreTotalDuType = nombreDeChambreDUnCertainType.Rows.Count
            End If

            If nbreChambreTotalDuType > 0 Then
                TOJ_2 = (nbreChambreVendu / nbreChambreTotalDuType) * 100
            End If
        ElseIf j = 2 Then
            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count

            Dim nombreDeChambreDUnCertainType As DataTable = Functions.getElementByCode(roomType, "chambre", "CODE_TYPE_CHAMBRE")

            If nombreDeChambreDUnCertainType.Rows.Count > 0 Then
                nbreChambreTotalDuType = nombreDeChambreDUnCertainType.Rows.Count
            End If

            If nbreChambreTotalDuType > 0 Then
                TOJ_3 = (nbreChambreVendu / nbreChambreTotalDuType) * 100
            End If
        ElseIf j = 3 Then
            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count

            Dim nombreDeChambreDUnCertainType As DataTable = Functions.getElementByCode(roomType, "chambre", "CODE_TYPE_CHAMBRE")

            If nombreDeChambreDUnCertainType.Rows.Count > 0 Then
                nbreChambreTotalDuType = nombreDeChambreDUnCertainType.Rows.Count
            End If

            If nbreChambreTotalDuType > 0 Then
                TOJ_4 = (nbreChambreVendu / nbreChambreTotalDuType) * 100
            End If
        ElseIf j = 4 Then
            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count

            Dim nombreDeChambreDUnCertainType As DataTable = Functions.getElementByCode(roomType, "chambre", "CODE_TYPE_CHAMBRE")

            If nombreDeChambreDUnCertainType.Rows.Count > 0 Then
                nbreChambreTotalDuType = nombreDeChambreDUnCertainType.Rows.Count
            End If

            If nbreChambreTotalDuType > 0 Then
                TOJ_5 = (nbreChambreVendu / nbreChambreTotalDuType) * 100
            End If
        ElseIf j = 5 Then

            roomType = roomTypes.Rows(j)("CODE_TYPE_CHAMBRE")
            nbreChambreVendu = Functions.enChambreParType(dateStat, dateStat, roomType).Rows.Count

            Dim nombreDeChambreDUnCertainType As DataTable = Functions.getElementByCode(roomType, "chambre", "CODE_TYPE_CHAMBRE")

            If nombreDeChambreDUnCertainType.Rows.Count > 0 Then
                nbreChambreTotalDuType = nombreDeChambreDUnCertainType.Rows.Count
            End If

            If nbreChambreTotalDuType > 0 Then
                TOJ_6 = (nbreChambreVendu / nbreChambreTotalDuType) * 100
            End If

        End If

    End Function

    Public Function valeursDuService(ByVal j As Integer, ByVal categorieList As DataTable, ByVal dateStat As Date)
        '2KLG
        Dim ligne_facture As New LigneFacture()
        Dim CategorieParent As String = ""

        If j = 0 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_1 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 1 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_2 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 2 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_3 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 3 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_4 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 4 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_5 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 5 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_6 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 6 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_7 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 7 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_8 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 8 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_9 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 9 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_10 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 10 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_11 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        ElseIf j = 11 Then
            CategorieParent = categorieList.Rows(j)("TYPE_LIGNE_FACTURE")
            montantService_12 = ligne_facture.VenteNetParPointDeVente(dateStat, dateStat, CategorieParent)
        End If

    End Function

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click

        If DataGridViewRapports.Rows.Count > 0 Then

            GlobalVariable.ReservationToUpdate = Functions.getElementByCode(DataGridViewRapports.CurrentRow.Cells("RESERVATION").Value.ToString, "reserve_conf", "CODE_RESERVATION")

            'Client en chambre
            If DataGridViewRapports.Rows.Count > 0 Then
                Functions.DocumentToPrint(DataGridViewRapports.CurrentRow.Cells("CODE").Value.ToString, "lign_facture", "CODE_FACTURE", GlobalVariable.codeClientToUpdate, DataGridViewRapports.CurrentRow.Cells("RESERVATION").Value.ToString)
            Else
                'Client comptoire ou autre
                Functions.DocumentToPrint(DataGridViewRapports.CurrentRow.Cells("CODE").Value.ToString, "lign_facture", "CODE_FACTURE", DataGridViewRapports.CurrentRow.Cells("NOM CLIENT").Value.ToString, DataGridViewRapports.CurrentRow.Cells("RESERVATION").Value.ToString)
            End If

        End If

    End Sub

    Private Sub GunaButtonImprimer_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimer.Click

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToShortDateString
        Dim DateFin As Date = GunaDateTimePickerFin.Value.ToShortDateString

        If GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES" Then

            Dim ligneFacture As New LigneFacture()

            Dim dtParentCategory As DataTable = ligneFacture.ListeDesCategoriesDArticleVendus(DateDebut, DateFin)

            Impression.journalDesVentes(dtParentCategory, DateDebut, DateFin)

        ElseIf GlobalVariable.DocumentToGenerate = "JOURNAL PETITE CAISSE" Then
            Impression.journalPetiteCaisse(DateDebut, DateFin)
        ElseIf GlobalVariable.DocumentToGenerate = "facture" Then

            Dim CODE_FACTURE As String = DataGridViewRapports.CurrentRow.Cells("CODE").Value.ToString
            Dim CODE_CLIENT As String = DataGridViewRapports.CurrentRow.Cells("CODE_CLIENT").Value.ToString

            Functions.DocumentToPrint(CODE_FACTURE, "lign_facture", "CODE_FACTURE", CODE_CLIENT)

        ElseIf GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES PERIODIQUE" Or GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES" Then

            Dim CODE_UTILISATEUR As String = ""

            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
                CODE_UTILISATEUR = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue
            End If

            Impression.journalDesVentesPeriodique(DateDebut, DateFin, CODE_UTILISATEUR)

        ElseIf GlobalVariable.DocumentToGenerate = "SITUATION DE CAISSE PERIODIQUE" Or GlobalVariable.DocumentToGenerate = "SITUATION GLOBAL" Then

            Me.Cursor = Cursors.WaitCursor
            Dim CASHIER As String = ""

            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
                CASHIER = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString
            End If

            Functions.rapportDesCaissesPeriodique(DateDebut, DateFin, CASHIER)

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "INVENTAIRE DES VENTES" Then

            Me.Cursor = Cursors.WaitCursor

            Dim LIBELLE As String = ""

            If GunaCheckBoxParFamille.Checked Then
                LIBELLE = " RAPPORT DES VENTES JOURNALIER PAR FAMILLE D'ARTICLE DU "
            Else
                LIBELLE = " RAPPORT DES VENTES JOURNALIER PAR ARTICLE DU "
            End If

            Dim CODE_CAISSIER As String = ""

            If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
                CODE_CAISSIER = GunaComboBoxUtilisateurDeMagasinBar.SelectedValue.ToString
            End If

            'INVENTAIRE GLOBAL
            If GunaComboBoxParPointDeVente.SelectedIndex = 0 Then

                Dim ligneFacture As New LigneFacture()
                Dim dtParentCategory As DataTable = ligneFacture.ListeDesCategoriesDArticleVendus(DateDebut, DateFin, CODE_CAISSIER)

                If GunaCheckBoxParFamille.Visible Then
                    If GunaCheckBoxParFamille.Checked Then
                        Impression.inventaireDesVentesParFamille(dtParentCategory, DateDebut, DateFin, CODE_CAISSIER, LIBELLE)
                    Else
                        Impression.inventaireDesVentes(DataGridViewRapports, DateDebut, DateFin, CODE_CAISSIER, LIBELLE)
                    End If
                End If

            Else

                'INVENTAIRE PAR MAGASIN
                If GunaCheckBoxParFamille.Visible Then
                    If GunaCheckBoxParFamille.Checked Then
                        Impression.inventaireDesVentesParFamilleMagasin(DateDebut, DateFin, CODE_CAISSIER, LIBELLE)
                    Else
                        Impression.inventaireDesVentesParMagasin(DateDebut, DateFin, CODE_CAISSIER, LIBELLE)
                    End If
                End If

            End If

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "PRODUCTIVITE DES RECEPTIONNISTES" Then

            Me.Cursor = Cursors.WaitCursor
            Impression.productiviteReceptionnistes(DateDebut, DateFin)
            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "FICHE D'INVENTAIRE JOURNALIERE BAR" Then

            Impression.ficheInventaireJournalierBar(DataGridViewRapports, DateDebut, DateFin)

        ElseIf GlobalVariable.DocumentToGenerate = "MOUCHARDS" Then

            If True Then
                'trace
                Impression.traces(DataGridViewRapports, DateDebut, DateFin)
            Else
                'mouchards
                Impression.mouchards(DataGridViewRapports, DateDebut, DateFin)
            End If

        ElseIf GlobalVariable.DocumentToGenerate = "FICHE STATISTIQUE JOURNALIERE" Then

            Me.Cursor = Cursors.WaitCursor

            Impression.statistiquesJournaliere(DateDebut)

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "INVENTAIRE DU MAGASIN" Then

            Me.Cursor = Cursors.WaitCursor

            Impression.impressionEconomatBarRestautant(DataGridViewRapports, GunaLabelGeneral.Text)

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "SITUATION MENSUEL DE L'ETABLISSEMENT" Then

            Me.Cursor = Cursors.WaitCursor

            Functions.RapportMainCouranteMensuel(DataGridViewRapports, GunaDateTimePickerDebut.Value.ToShortDateString, GunaDateTimePickerFin.Value.ToShortDateString)

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "HEBERGEMENT" Then

            Me.Cursor = Cursors.WaitCursor

            Functions.VenteNetParPointDeVente(DataGridViewRapports, GunaDateTimePickerDebut.Value.ToShortDateString, GunaDateTimePickerFin.Value.ToShortDateString)

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "STATISTQIUES DU DASHBOARD" Then

            Me.Cursor = Cursors.WaitCursor

            Impression.TauxOccupationPeriodique(DataGridViewRapports, GunaDateTimePickerDebut.Value.ToShortDateString, GunaDateTimePickerFin.Value.ToShortDateString)

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "STATISTQIUES DES PRIX MOYENS" Then

            Me.Cursor = Cursors.WaitCursor

            Impression.PrixMoyenPeriodique(DataGridViewRapports, GunaDateTimePickerDebut.Value.ToShortDateString, GunaDateTimePickerFin.Value.ToShortDateString)

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "PERIODIC ACCOMMODATION REPORT" Then

            Me.Cursor = Cursors.WaitCursor

            Impression.VenteNetHebermentNuits(DataGridViewRapports, GunaDateTimePickerDebut.Value.ToShortDateString, GunaDateTimePickerFin.Value.ToShortDateString)

            Me.Cursor = Cursors.Default

        ElseIf GlobalVariable.DocumentToGenerate = "FICHE DE VENTILATION" Then

            Me.Cursor = Cursors.WaitCursor

            Impression.FicheVentilationBarRestaurant(DataGridViewRapports, GunaDateTimePickerDebut.Value.ToShortDateString, GunaDateTimePickerFin.Value.ToShortDateString)

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub GunaCheckBoxTous_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTous.CheckedChanged

        If GunaCheckBoxTous.Checked Then
            GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex = -1
        Else
            GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex = 0
        End If

        DataGridViewRapports.Columns.Clear()

    End Sub

    Private Sub GunaComboBoxUtilisateurDeMagasinBar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUtilisateurDeMagasinBar.SelectedIndexChanged, GunaComboBoxParPointDeVente.SelectedIndexChanged

        Dim indexUser As Integer = GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex

        If GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex >= 0 Then
            'GunaCheckBoxTous.Checked = False
            'GunaComboBoxUtilisateurDeMagasinBar.SelectedIndex = indexUser
        End If

        DataGridViewRapports.Columns.Clear()

    End Sub

    Private Sub GunaDateTimePickerDebut_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDebut.ValueChanged
        DataGridViewRapports.Columns.Clear()

        If GlobalVariable.DocumentToGenerate = "FICHE D'INVENTAIRE JOURNALIERE BAR" Or
            GlobalVariable.DocumentToGenerate = "SITUATION GLOBAL" Or GlobalVariable.DocumentToGenerate = "MOUCHARDS" Or
            GlobalVariable.DocumentToGenerate = "FICHE STATISTIQUE JOURNALIERE" Or GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT" Or
            GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES" Then
            GunaDateTimePickerFin.Value = GunaDateTimePickerDebut.Value
        End If

    End Sub

    Private Sub GunaDateTimePickerFin_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerFin.ValueChanged
        DataGridViewRapports.Columns.Clear()
        'DataGridViewFactures.Rows.Clear()
    End Sub

    Public Function calculDuMontantAReporterDelaVeillePourLePremierJour(ByVal date_maincounrante As Date) As Double

        Dim changerSigne As Integer = -1

        Dim reportVeille As Double = 0

        If True Then

            Dim DateDebut As Date = date_maincounrante.AddDays(-1).ToString("yyyy-MM-dd")
            Dim DateFin As Date = date_maincounrante.AddDays(-1).ToString("yyyy-MM-dd")

            'RESERVATION 

            Dim getUserQuery1 = "SELECT CHAMBRE_ID As 'CHAMBRE', DAY_USE, NUM_RESERVATION, ARRHES, main_courante_journaliere.NOM_CLIENT As 'NOM & PRENOM', DATE_ENTTRE As 'DATE ARRIVEE', DATE_SORTIE As 'DATE DEPART', NB_PERSONNES As 'NBRE DE PAX', PDJ, DEJEUNER, DINER,CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_journaliere.NUM_RESERVATION As 'RESERVATION', main_courante_journaliere.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_journaliere.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_journaliere.SERVICES AS 'SERVICES', main_courante_journaliere.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_journaliere.BOUTIQE AS 'BOUTIQUE', main_courante_journaliere.CYBERCAFE As 'BUSINESS CENTER', main_courante_journaliere.SPORTS As 'SPORTS' , main_courante_journaliere.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_journaliere.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_journaliere.BLANCHISSERIE As BLANCHISSERIE, main_courante_journaliere.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER', HEURE_ENTREE, HEURE_SORTIE,TAUX_OCCUPATION_PCT As 'TAXE DE SEJOUR' FROM main_Courante_journaliere, reserve_conf WHERE DATE_MAIN_COURANTE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND main_Courante_journaliere.NUM_RESERVATION = reserve_conf.CODE_RESERVATION AND reserve_conf.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

            Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)

            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

            Dim adapter1 As New MySqlDataAdapter(command1)

            Dim table As New DataTable()

            adapter1.Fill(table)

            '-------------------------------------------------------- MAINCOURANTE ----------------------------------------------

            Dim getUserQuery01 = "SELECT CODE_CHAMBRE As 'CHAMBRE', NUM_RESERVATION, ARRHES, main_courante_autres.NOM_CLIENT As 'NOM & PRENOM', PDJ, DEJEUNER, DINER, CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_autres.NUM_RESERVATION As 'RESERVATION', main_courante_autres.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_autres.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_autres.SERVICES AS 'SERVICES', main_courante_autres.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_autres.BOUTIQE AS 'BOUTIQUE', main_courante_autres.CYBERCAFE As 'BUSINESS CENTER', main_courante_autres.SPORTS As 'SPORTS' , main_courante_autres.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_autres.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_autres.BLANCHISSERIE As BLANCHISSERIE, main_courante_autres.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER' FROM main_Courante_autres WHERE DATE_MAIN_COURANTE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY main_courante_autres.NOM_CLIENT ASC"

            Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)
            command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

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
                    Dim dateMainCourante As Date = date_maincounrante.AddDays(-1).ToShortDateString

                    Dim HEBERGEMENT As Double = table.Rows(i)("HEBERGEMENT")
                    Dim taxeDeSejours As Double = table.Rows(i)("TAXE DE SEJOUR")


                    Dim RETRANCHEMENTHEBERGEMENT As Double = 0
                    Dim RETRANCHEMENTTAXEDESEJOUR As Double = 0

                    nuits = CType((depart - arrivee).TotalDays, Int64)

                    Dim PAX As Integer = table.Rows(i)("NBRE DE PAX")

                    If PAX <= 0 Then
                        PAX = 1
                    End If

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

                    'ON DOIT MULTIPLIER LE DAY USE PAR LE NOMBRE D'HEURE
                    If table.Rows(i)("DAY_USE") = 1 Then

                        Dim DEBUT As Date = CDate(table.Rows(i)("HEURE_ENTREE")).ToShortTimeString
                        Dim FIN As Date = CDate(table.Rows(i)("HEURE_SORTIE")).ToShortTimeString

                        Dim NombreHeure As Integer = 0

                        NombreHeure = CType((FIN - DEBUT).TotalHours, Int32)

                        'HEBERGEMENT *= NombreHeure

                        'AUTRES_VENTE -= HEBERGEMENT

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

                    reportVeille += (table.Rows(i)("A REPORTER") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR - table.Rows(i)("ARRHES")) * changerSigne

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

                    reportVeille += table0.Rows(i)("A REPORTER") * changerSigne

                Next

            End If

        End If

        Return reportVeille

    End Function

    Private Sub ListeDesMainCourantesDujours()

        Dim changerSigne As Integer = -1

        Dim DocumentToGenerate As String = GlobalVariable.typeChambreOuSalle
        Dim calculDuMontantAReporter

        If True Then

            'MAINCOURANTE JOURNALIERE

            'Functions.AffectingTitleToAForm("SITUATION MENSUEL DE L'ETABLISSEMENT", GunaLabelGeneral)

            Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToString("yyyy-MM-dd")
            Dim DateFin As Date = GunaDateTimePickerFin.Value.ToString("yyyy-MM-dd")
            '2klg
            Dim nombreDejour As Integer = CType((DateFin - DateDebut).TotalDays, Int32)

            GunaButtonImprimer.Visible = True
            GunaButtonAfficher.Visible = True

            'RESERVATION 

            '1- ON DOIT RECUPER LES MAINS COURANTE DE CHAQUE JOUR PAR APPORT A L'INTERVAL DE DATE
            DataGridViewRapports.Columns.Clear()
            DataGridViewRapports.Rows.Clear()

            '------------------ ADD COLUMNS --------------------

            DataGridViewRapports.Columns.Add("DATE", "DATE")
            DataGridViewRapports.Columns.Add("HEBERGEMENT", "HEBERGEMENT")
            DataGridViewRapports.Columns.Add("TAXE", "TAXE")
            DataGridViewRapports.Columns.Add("PDJ", "PDJ")
            DataGridViewRapports.Columns.Add("DEJEUNER", "DEJEUNER")
            DataGridViewRapports.Columns.Add("DINER", "DINER")
            DataGridViewRapports.Columns.Add("BAR", "BAR")
            DataGridViewRapports.Columns.Add("BLANCHISSERIE", "BLANCHISSERIE")
            DataGridViewRapports.Columns.Add("AUTRES", "AUTRES")
            DataGridViewRapports.Columns.Add("RECETTE_DU_JOUR", "RECETTE DU JOUR") 'TOTAL DU JOUR
            DataGridViewRapports.Columns.Add("REPORT_VEILLE", "REPORT VEILLE")
            DataGridViewRapports.Columns.Add("TOTAL_GENERAL", "TOTAL GENERAL")
            DataGridViewRapports.Columns.Add("ESPECES", "ESPECES")
            DataGridViewRapports.Columns.Add("CARTE", "CARTE")
            DataGridViewRapports.Columns.Add("MOBILE_MONEY", "MOBILE MONEY")
            DataGridViewRapports.Columns.Add("A_REPORTER", "A REPORTER")

            Dim REPORT_VEILLE As Double = 0

            For j = 0 To nombreDejour

                Dim TOTAL_ENCAISSEMENT As Double = 0
                Dim RESTAURANT As Double = 0
                Dim BAR As Double = 0
                Dim AUTRES_VENTE As Double = 0
                Dim TOTAL_RECETTE As Double = 0

                Dim HEBERGEMENT As Double = 0
                Dim taxeDeSejours As Double = 0

                Dim RETRANCHEMENTHEBERGEMENT As Double = 0
                Dim RETRANCHEMENTTAXEDESEJOUR As Double = 0

                Dim DEJEUNER As Double = 0
                Dim PDJ As Double = 0
                Dim DINER As Double = 0
                Dim BLANCHISSERIE As Double = 0
                Dim RECETTE_DU_JOUR As Double = 0

                Dim TOTAL_GENERAL As Double = 0
                Dim ESPECES As Double = 0
                Dim CARTE_CREDIT As Double = 0
                Dim MOBILE_MONEY As Double = 0
                Dim A_REPORTER As Double = 0
                Dim ARRHES As Double = 0

                '1.1- INCREMENTATION DE LA DATE APRES CHAQUE RECUPERATION ET AFFICHAGE DE DONNEES

                Dim DateStat As Date = DateDebut.AddDays(j)

                HEBERGEMENT = Functions.ListeDesMainCourantesDujours(DateStat)

                If j = 0 Then
                    REPORT_VEILLE = calculDuMontantAReporterDelaVeillePourLePremierJour(DateStat)
                End If

                Dim getUserQuery1 = "SELECT CHAMBRE_ID As 'CHAMBRE', DAY_USE, NUM_RESERVATION, ARRHES, main_courante_journaliere.NOM_CLIENT As 'NOM & PRENOM', DATE_ENTTRE As 'DATE ARRIVEE', DATE_SORTIE As 'DATE DEPART', NB_PERSONNES As 'NBRE DE PAX', PDJ, DEJEUNER, DINER,CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_journaliere.NUM_RESERVATION As 'RESERVATION', main_courante_journaliere.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_journaliere.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_journaliere.SERVICES AS 'SERVICES', main_courante_journaliere.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_journaliere.BOUTIQE AS 'BOUTIQUE', main_courante_journaliere.CYBERCAFE As 'BUSINESS CENTER', main_courante_journaliere.SPORTS As 'SPORTS' , main_courante_journaliere.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_journaliere.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_journaliere.BLANCHISSERIE As BLANCHISSERIE, main_courante_journaliere.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER', HEURE_ENTREE, HEURE_SORTIE,TAUX_OCCUPATION_PCT As 'TAXE DE SEJOUR' FROM main_Courante_journaliere, reserve_conf WHERE DATE_MAIN_COURANTE <= '" & DateStat.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateStat.ToString("yyyy-MM-dd") & "' AND main_Courante_journaliere.NUM_RESERVATION = reserve_conf.CODE_RESERVATION AND reserve_conf.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

                Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)

                'command1.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
                'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 0
                'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 1
                command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = DocumentToGenerate

                Dim adapter1 As New MySqlDataAdapter(command1)

                Dim table As New DataTable()

                adapter1.Fill(table)

                '-----------------------------------------HEBERGEMENT-------------------------------------------------------------

                'Dim getUserQuery01_ = "SELECT * FROM `ligne_facture` WHERE DATE_FACTURE >='" & DateStat.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateStat.ToString("yyyy-MM-dd") & "'
                'And `TYPE_LIGNE_FACTURE` LIKE 'HEBERGEMENT'"

                Dim getUserQuery01_ = "SELECT * FROM `ligne_facture` WHERE DATE_FACTURE >='" & DateStat.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateStat.ToString("yyyy-MM-dd") & "'
                And `FUSIONNEE` IN ('HEBERGEMENT', 'ACCOMMODATION')"

                Dim command01_ As New MySqlCommand(getUserQuery01_, GlobalVariable.connect)
                Dim adapter01_ As New MySqlDataAdapter(command01_)

                Dim table01_ As New DataTable()

                adapter01_.Fill(table01_)

                If Not table01_ Is Nothing Then
                    If table01_.Rows.Count > 0 Then
                        For i = 0 To table01_.Rows.Count - 1
                            HEBERGEMENT += table01_.Rows(i)("MONTANT_TTC")
                        Next
                    End If
                End If

                '--------------------------------------------------------------------------------------------------------------------
                '-------------------------------------------------------- MAINCOURANTE ----------------------------------------------

                Dim getUserQuery01 = "SELECT CODE_CHAMBRE As 'CHAMBRE', NUM_RESERVATION, ARRHES, main_courante_autres.NOM_CLIENT As 'NOM & PRENOM', PDJ, DEJEUNER, DINER, CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_autres.NUM_RESERVATION As 'RESERVATION', main_courante_autres.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_autres.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_autres.SERVICES AS 'SERVICES', main_courante_autres.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_autres.BOUTIQE AS 'BOUTIQUE', main_courante_autres.CYBERCAFE As 'BUSINESS CENTER', main_courante_autres.SPORTS As 'SPORTS' , main_courante_autres.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_autres.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_autres.BLANCHISSERIE As BLANCHISSERIE, main_courante_autres.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER' FROM main_Courante_autres WHERE DATE_MAIN_COURANTE <= '" & DateStat.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateStat.ToString("yyyy-MM-dd") & "' ORDER BY main_courante_autres.NOM_CLIENT ASC"

                Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

                'command1.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
                'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 0
                'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 1
                command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = DocumentToGenerate

                Dim adapter01 As New MySqlDataAdapter(command01)

                Dim table0 As New DataTable()

                adapter01.Fill(table0)


                If table.Rows.Count > 0 Then

                    '------------------ FAILED COLUMNS -----------------

                    '2. ON DOIT FAIRE LA SOMME DES MAINCOURANTE POUR N'AVOIR QUE UNE SEULE DATE
                    '2.1 LES EN CAHMBRES

                    For i = 0 To table.Rows.Count - 1

                        Dim NUMERO_RESERVATION As String = table.Rows(i)("NUM_RESERVATION")

                        RESTAURANT += table.Rows(i)("PDJ") + table.Rows(i)("DEJEUNER") + table.Rows(i)("DINER")
                        BAR += table.Rows(i)("CAFE") + table.Rows(i)("CAVE") + table.Rows(i)("DIVERS")

                        PDJ += table.Rows(i)("PDJ")
                        DEJEUNER += table.Rows(i)("DEJEUNER")
                        DINER += table.Rows(i)("DINER")
                        BLANCHISSERIE += table.Rows(i)("BLANCHISSERIE")

                        RECETTE_DU_JOUR += table.Rows(i)("RECETTE DU JOUR")
                        'REPORT_VEILLE += table.Rows(i)("REPORT VEILLE")
                        'TOTAL_GENERAL += table.Rows(i)("TOTAL GENERAL")

                        ESPECES += table.Rows(i)("ESPECES")
                        CARTE_CREDIT += table.Rows(i)("CARTE CREDIT") + table.Rows(i)("CHEQUE")
                        MOBILE_MONEY += table.Rows(i)("MOBILE MONEY")
                        'A_REPORTER += table.Rows(i)("A REPORTER")
                        ARRHES += table.Rows(i)("ARRHES")

                        'Dim RESTAURANT As Double = table.Rows(i)("CAVE") + table.Rows(i)("DIVERS") + table.Rows(i)("CAFE")

                        AUTRES_VENTE += table.Rows(i)("SERVICES") + table.Rows(i)("SALON DE BEAUTE") + table.Rows(i)("BOUTIQUE") + table.Rows(i)("BUSINESS CENTER") + table.Rows(i)("SPORTS") + table.Rows(i)("LOISIRS") + table.Rows(i)("JOURNAUX") + table.Rows(i)("AUTRES")

                        Dim nuits As Integer = 0

                        Dim arrivee As Date = CDate(table.Rows(i)("DATE ARRIVEE")).ToShortDateString
                        Dim depart As Date = CDate(table.Rows(i)("DATE DEPART")).ToShortDateString

                        Dim dateTravail As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
                        Dim dateMainCourante As Date = GunaDateTimePickerDebut.Value.ToShortDateString

                        'taxeDeSejours += table.Rows(i)("TAXE DE SEJOUR")

                        Dim SERVICE As String = ""
                        If GlobalVariable.actualLanguageValue = 1 Then
                            SERVICE = "TAXE DE SEJOURS"
                        Else
                            SERVICE = "TOURIST TAX"
                        End If

                        taxeDeSejours += Functions.totalDunServiceUnCertainJourSpecifique(DateStat, SERVICE, table.Rows(i)("NUM_RESERVATION"))

                        'HEBERGEMENT += table.Rows(i)("HEBERGEMENT")

                        Dim HEBERGEMENT_ As Double = table.Rows(i)("HEBERGEMENT")
                        Dim taxeDeSejours_ As Double = table.Rows(i)("TAXE DE SEJOUR")

                        nuits = CType((depart - arrivee).TotalDays, Int64)

                        Dim PAX As Integer = table.Rows(i)("NBRE DE PAX")

                        If PAX <= 0 Then
                            PAX = 1
                        End If

                        If AUTRES_VENTE < 0 Then
                            AUTRES_VENTE = 0
                        End If

                        TOTAL_ENCAISSEMENT += table.Rows(i)("ESPECES") + table.Rows(i)("CARTE CREDIT") + table.Rows(i)("MOBILE MONEY") + table.Rows(i)("CHEQUE")

                    Next

                    'TOTAL_RECETTE = AUTRES_VENTE + HEBERGEMENT + RESTAURANT + BAR + BLANCHISSERIE

                    'MAINcourantes comptoires
                    For i = 0 To table0.Rows.Count - 1

                        RESTAURANT += table0.Rows(i)("PDJ") + table0.Rows(i)("DEJEUNER") + table0.Rows(i)("DINER")
                        BAR += table0.Rows(i)("CAFE") + table0.Rows(i)("CAVE") + table0.Rows(i)("DIVERS")
                        RECETTE_DU_JOUR += table0.Rows(i)("RECETTE DU JOUR")

                        PDJ += table0.Rows(i)("PDJ")
                        DEJEUNER += table0.Rows(i)("DEJEUNER")
                        DINER += table0.Rows(i)("DINER")
                        BLANCHISSERIE += table0.Rows(i)("BLANCHISSERIE")

                        AUTRES_VENTE += table0.Rows(i)("SERVICES") + table0.Rows(i)("SALON DE BEAUTE") + table0.Rows(i)("BOUTIQUE") + table0.Rows(i)("BUSINESS CENTER") + table0.Rows(i)("SPORTS") + table0.Rows(i)("LOISIRS") + table0.Rows(i)("JOURNAUX") + table0.Rows(i)("AUTRES")
                        BLANCHISSERIE += table0.Rows(i)("BLANCHISSERIE")
                        TOTAL_ENCAISSEMENT += table0.Rows(i)("ESPECES") + table0.Rows(i)("CARTE CREDIT") + table0.Rows(i)("MOBILE MONEY") + table0.Rows(i)("CHEQUE")

                        'REPORT_VEILLE += table0.Rows(i)("REPORT VEILLE")
                        'TOTAL_GENERAL += table0.Rows(i)("TOTAL GENERAL")

                        ESPECES += table0.Rows(i)("ESPECES")
                        CARTE_CREDIT += table0.Rows(i)("CARTE CREDIT") + table0.Rows(i)("CHEQUE")
                        MOBILE_MONEY += table0.Rows(i)("MOBILE MONEY")
                        'A_REPORTER += table0.Rows(i)("A REPORTER")
                        ARRHES += table0.Rows(i)("ARRHES")

                    Next

                    TOTAL_RECETTE = (AUTRES_VENTE + HEBERGEMENT + PDJ + DEJEUNER + DINER + BAR + BLANCHISSERIE + taxeDeSejours)
                    'TOTAL_GENERAL = TOTAL_RECETTE + A_REPORTER + REPORT_VEILLE
                    TOTAL_GENERAL = (TOTAL_RECETTE) + (REPORT_VEILLE * changerSigne)
                    TOTAL_ENCAISSEMENT = ESPECES + CARTE_CREDIT + MOBILE_MONEY
                    A_REPORTER = TOTAL_ENCAISSEMENT - TOTAL_GENERAL

                    DataGridViewRapports.Rows.Add(DateStat.ToShortDateString(), HEBERGEMENT, taxeDeSejours, PDJ, DEJEUNER, DINER, BAR, BLANCHISSERIE, AUTRES_VENTE, TOTAL_RECETTE, REPORT_VEILLE, TOTAL_GENERAL * changerSigne, ESPECES, CARTE_CREDIT, MOBILE_MONEY, A_REPORTER)

                    REPORT_VEILLE = A_REPORTER

                Else

                    'DataGridViewRapports.Visible = False
                    'DataGridViewRapports.Columns.Clear()

                End If

            Next

            If DataGridViewRapports.Rows.Count > 0 Then

                DataGridViewRapports.Columns("HEBERGEMENT").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("HEBERGEMENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'DataGridViewRapports.Columns("NBRE_PAX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridViewRapports.Columns("PDJ").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("PDJ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("TAXE").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("TAXE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'DataGridViewRapports.Columns("NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridViewRapports.Columns("DEJEUNER").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("DEJEUNER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("DINER").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("DINER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("BAR").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("BAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("ESPECES").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("ESPECES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("CARTE").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("CARTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("MOBILE_MONEY").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("MOBILE_MONEY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("BLANCHISSERIE").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("BLANCHISSERIE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("RECETTE_DU_JOUR").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("RECETTE_DU_JOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("REPORT_VEILLE").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("REPORT_VEILLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("TOTAL_GENERAL").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("TOTAL_GENERAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.Columns("A_REPORTER").DefaultCellStyle.Format = "#,##0"
                DataGridViewRapports.Columns("A_REPORTER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewRapports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            End If
            '--------------------------------------------------------------------------------------------------------------------


        End If

        'connect.closeConnection()

    End Sub


    Public Function valeursRapportHegergement(ByVal j As Integer, ByVal roomType As DataTable, ByVal dateStat As Date, ByVal INCOM_GENERATED_CASHED_IN As Integer)

        Dim ligne_facture As New LigneFacture()
        Dim room_type As String = ""

        If j = 0 Then
            room_type = roomType.Rows(j)("CODE_TYPE_CHAMBRE")
            montantService_1 = ligne_facture.VenteNetHeberment(dateStat, dateStat, room_type, INCOM_GENERATED_CASHED_IN)
            nights_1 = ligne_facture.VenteNetHebermentNuits(dateStat, room_type)
        ElseIf j = 1 Then
            room_type = roomType.Rows(j)("CODE_TYPE_CHAMBRE")
            montantService_2 = ligne_facture.VenteNetHeberment(dateStat, dateStat, room_type, INCOM_GENERATED_CASHED_IN)
            nights_2 = ligne_facture.VenteNetHebermentNuits(dateStat, room_type)
        ElseIf j = 2 Then
            room_type = roomType.Rows(j)("CODE_TYPE_CHAMBRE")
            montantService_3 = ligne_facture.VenteNetHeberment(dateStat, dateStat, room_type, INCOM_GENERATED_CASHED_IN)
            nights_3 = ligne_facture.VenteNetHebermentNuits(dateStat, room_type)
        ElseIf j = 3 Then
            room_type = roomType.Rows(j)("CODE_TYPE_CHAMBRE")
            montantService_4 = ligne_facture.VenteNetHeberment(dateStat, dateStat, room_type, INCOM_GENERATED_CASHED_IN)
            nights_4 = ligne_facture.VenteNetHebermentNuits(dateStat, room_type)
        ElseIf j = 4 Then
            room_type = roomType.Rows(j)("CODE_TYPE_CHAMBRE")
            montantService_5 = ligne_facture.VenteNetHeberment(dateStat, dateStat, room_type, INCOM_GENERATED_CASHED_IN)
            nights_5 = ligne_facture.VenteNetHebermentNuits(dateStat, room_type)
        ElseIf j = 5 Then
            room_type = roomType.Rows(j)("CODE_TYPE_CHAMBRE")
            montantService_6 = ligne_facture.VenteNetHeberment(dateStat, dateStat, room_type, INCOM_GENERATED_CASHED_IN)
            nights_6 = ligne_facture.VenteNetHebermentNuits(dateStat, room_type)
        ElseIf j = 6 Then
            room_type = roomType.Rows(j)("CODE_TYPE_CHAMBRE")
            montantService_7 = ligne_facture.VenteNetHeberment(dateStat, dateStat, room_type, INCOM_GENERATED_CASHED_IN)
            nights_7 = ligne_facture.VenteNetHebermentNuits(dateStat, room_type)
        ElseIf j = 7 Then
            room_type = roomType.Rows(j)("CODE_TYPE_CHAMBRE")
            montantService_8 = ligne_facture.VenteNetHeberment(dateStat, dateStat, room_type, INCOM_GENERATED_CASHED_IN)
            nights_8 = ligne_facture.VenteNetHebermentNuits(dateStat, room_type)
        End If

    End Function

    Private Sub GunaButton16_Click(sender As Object, e As EventArgs) Handles GunaButton16.Click

        Dim title As String = "FICHE INVENTAIRE JOURNALIERE BAR " & GunaDateTimePickerDebut.Value.ToString("ddMMyyHHmmss")

        If GlobalVariable.actualLanguageValue = 0 Then
            title = "DAILY INVENTORY FORM" & GunaDateTimePickerDebut.Value.ToString("ddMMyyHms")
        End If

        Impression.ficheSuivieDeStockExportExcelForm(DataGridViewRapports, title)

    End Sub

End Class