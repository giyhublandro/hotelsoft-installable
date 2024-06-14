Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Data

Public Class MainWindowEconomat

    'Database connection management
    'Dim connect As New DataBaseManipulation()
    Public Class ArgumentType

        'action = 0 : ultrMessageSimpleText
        Public action As Integer
        Public whatsAppMessage As String
        Public mobile_number As String

        '--------------------------------
        'action = 1 : consifirmation resa salle

        Public CODE_RESERVATAION As String
        Public NOM_PRENOM As String
        Public ARRIVAL As Date
        Public DEPART As Date
        Public TEMP_A_FAIRE As Integer
        Public TYPE_CHAMBRE As String
        Public NUM_CHAMBRE As String
        Public MONTANT_PAR_NUITEE As Double
        Public HEURE_ARRIVEE As DateTime
        Public HEURE_DEPART As DateTime
        Public TYPE_CHAMBRE_SALLE As String
        Public EMAIL As String
        Public TELEPHONE_CLIENT As String
        Public WHATSAPP_OU_EMAIL As Integer

        'action = 2 : confirmation resa chambre
        'action = 3 : devis estimatif salle
        'action = 4 : Fiche de police
        'action = 5 : Contrat de location
        'action = 6 :
        'action = 7 :
        'action = 8 :
        'action = 9 :
        'action = 10 :

    End Class

    Dim firstLoad As Boolean = True

    Private Async Sub MainWindowEconomat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim langue As New Languages()
        langue.economat(GlobalVariable.actualLanguageValue)

        Dim menuAccess As New AccessRight()

        menuAccess.accesAuxModules(GlobalVariable.DroitAccesDeUtilisateurConnect, ReceptionToolStripMenuItem, RESERVATIONToolStripMenuItem, SERVICEDETAGEToolStripMenuItem, BarRestaurationToolStripMenuItem, ComptabilitéToolStripMenuItem, ECONOMATToolStripMenuItem, TECHNIQUEToolStripMenuItem, ToolStripMenuItem53)

        menuAccess.administrationDuModule(GlobalVariable.DroitAccesDeUtilisateurConnect, ToolStripMenuItemSession, ToolStripMenuItemConfig, ToolStripMenuItemServTech, ToolStripMenuItemSecurite, ClôturerToolStripMenuItem, ToolStripSeparatorCloture, FermerCaisseToolStripMenuItem, OuvrirCaisseToolStripMenuItem, ToolStripSeparator2)

        GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

        'TITRE DE LA FENETRE
        If GlobalVariable.softwareVersion = "barcleshsoftdbdemo" Then
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") + " (DEMO) "
        Else
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        End If

        TabControlEconomat.SelectedIndex = 0

        GunaDateTimePickerFrom.Value = GlobalVariable.DateDeTravail.ToShortDateString()
        GunaDateTimePickerTo.Value = GlobalVariable.DateDeTravail.ToShortDateString()

        'Theme color
        If GlobalVariable.AgenceActuelle.Rows.Count > 0 Then
            GlobalVariable.codeAgence = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        End If

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then
            GunaCheckBoxDateFictive.Visible = True
        Else
            GunaCheckBoxDateFictive.Visible = False
        End If

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail

        'Dim economat As New Economat()
        'AutoLoadlisteDesLotsDansLeBordereaux()

        AutoLoadlisteMagasinSource()

        AutoLoadlisteMagasinDestination()

        'utilis seulement si on souhaite faire un tranfert inter magains
        'GunaComboBoxMagasinDeProvenance.SelectedIndex = -1

        'Entete du tableau des articles pour entrer en magasin

        'GunaDataGridViewLigneArticleCommande.Columns.Add("CODE ARTICLE", "CODE ARTICLE")
        'GunaDataGridViewLigneArticleCommande.Columns.Add("DESIGNATION", "DESIGNATION")
        'GunaDataGridViewLigneArticleCommande.Columns.Add("QUANTITE", "QUANTITE")
        'GunaDataGridViewLigneArticleCommande.Columns.Add("EN STOCK", "EN STOCK")
        'GunaDataGridViewLigneArticleCommande.Columns.Add("PRIX ACHAT", "PRIX ACHAT")
        'GunaDataGridViewLigneArticleCommande.Columns.Add("PRIX VENTE", "PRIX VENTE")

        'Pour être sur de ne gérer le lot que au bon moment
        GunaComboBoxListeDesLots.SelectedIndex = -1

        GunaComboBoxTypeTiers.SelectedIndex = 1

        GunaComboBoxTypeBordereau.SelectedIndex = 1

        firstLoad = False
        recuperationDesSaisies()

        notification()
        '----------------------------END ECONOMAT ------------------

    End Sub

    Private Sub notification()

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then
            GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
        End If

    End Sub

    Private Sub recuperationDesSaisies()

        Dim econom As New Economat
        Dim CODE_BORDEREAU As String = ""
        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim infoSupBordereau As DataTable = Functions.GetAllElementsOnCondition(CODE_USER, "bordereau_ligne_temp", "CODE_USER")

        If infoSupBordereau.Rows.Count > 0 Then
            CODE_BORDEREAU = infoSupBordereau.Rows(0)("CODE_BORDEREAU")
            GunaTextBoxCodeBordereau.Text = infoSupBordereau.Rows(0)("CODE_BORDEREAU")
            'GunaDataGridViewLigneArticleCommande = Nothing
            GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElementsSuivantBordoro(GlobalVariable.codeAgence, CODE_BORDEREAU)
            GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False 'false
        End If

    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Functions.exitApplicationThread()
    End Sub

    '--------------------------------------------- MODULE ECONOMAT --------------------------------------------------------

    'MAGASINS
    Private Sub ToolStripMenuItem91_Click(sender As Object, e As EventArgs)
        MAgasinForm.Show()
    End Sub

    Private Sub InsertionDesElementsPourGestionDeStock(Optional ByVal ETAT_NOTE_DU_BORDEREAU As String = "NON VALIDE", Optional ByVal ETAT_DU_BORDE As Integer = 0)

        'LabelQuantiteEnMagasinSource.Visible = False

        'GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

        Dim CODE_BORDEREAUX As String = GunaTextBoxCodeBordereau.Text

        Dim econom As New Economat()
        'Enregistrement des éléments du bordereau

        Dim ETAT_DU_BORDEREAU As Integer = 0
        Dim TYPE_BORDEREAUX As String = GunaComboBoxTypeBordereau.SelectedItem.ToString
        Dim REF_BORDEREAUX As String = GunaTextBoxReference.Text
        Dim LIBELLE_BORDEREAUX As String = GunaTextBoxLibelleBordereau.Text
        Dim CODE_TIERS As String = GunaTextBoxTiers.Text
        Dim NON_TIERS As String = GunaTextBoxNomTiers.Text
        Dim DATE_BORDEREAU As Date = GlobalVariable.DateDeTravail
        Dim OBSERVATIONS As String = GunaTextBoxObservation.Text

        If Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
            GunaTextBoxMontantHTGeneralAchat.Text = 0
        End If

        Dim MONTANT_HT As Double = Double.Parse(GunaTextBoxMontantHTGeneralAchat.Text) ' MONTANT VENTE
        Dim MONTANT_TAXE As Double = 0
        Dim MONTANT_TTC As Double = 0

        If Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
            GunaTextBoxMontantTTCGeneralVente.Text = 0
        End If

        Dim MONTANT_PAYER As Double = Double.Parse(GunaTextBoxMontantTTCGeneralVente.Text) ' MONTANT ACHAT
        Dim VALIDE As String = "NON CONTROLE"
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString
        Dim CODE_SOUS_MAGASIN As String = ""

        Dim COUT_DU_STOCK As Double = 0

        If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then
            CODE_BORDEREAUX = Trim(GunaTextBoxCodeBordereau.Text)
            ETAT_DU_BORDEREAU = ETAT_DU_BORDE
            VALIDE = ETAT_NOTE_DU_BORDEREAU
        End If

        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.transfert_inter Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then

            If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
                CODE_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
                CODE_SOUS_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString
            Else
                CODE_SOUS_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
            End If

        End If

        'Insertion des information du bordereau
        If econom.insertBordereau(CODE_BORDEREAUX, TYPE_BORDEREAUX, REF_BORDEREAUX, LIBELLE_BORDEREAUX, CODE_TIERS, NON_TIERS, DATE_BORDEREAU, OBSERVATIONS, MONTANT_HT, MONTANT_TAXE, MONTANT_TTC, MONTANT_PAYER, VALIDE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_MAGASIN, CODE_SOUS_MAGASIN, ETAT_DU_BORDEREAU) Then

            Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")
            Dim CHAMP_A_METTRE_A_JOUR As String = "ENREGISTRER"

            econom.inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)

            '-------------------------------------- MISE A JOURS DES PERIODES DE LA LISTE DU MARCHE -------------------------------------------------------
            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
                'ON MET A JOUR LA PERIODE DE LA LISTE DU MARCHE

                Dim DATE_DU As Date = GunaDateTimePickerP1LM.Value.ToShortDateString()
                Dim DATE_AU As Date = GunaDateTimePickerP2LM.Value.ToShortDateString()

                Dim updateQuery As String = "UPDATE `bordereaux` SET `DATE_DU` = @DATE_DU , `DATE_AU` = @DATE_AU  WHERE CODE_BORDEREAUX = @CODE_BORDEREAUX"

                Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
                command.Parameters.Add("@DATE_DU", MySqlDbType.Date).Value = DATE_DU
                command.Parameters.Add("@DATE_AU", MySqlDbType.Date).Value = DATE_AU

                command.ExecuteNonQuery()

            End If
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

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BR")

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "TI")

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BC")
                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_approvisi Then
                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BA")
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BS")

                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "SE")

                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "EE")

                End If

                Dim CODE_ARTICLE As String = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("CODE ARTICLE").Value.ToString

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                Dim Article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                If Article.Rows.Count > 0 Then

                    CMUP = Article.Rows(0)("PRIX_ACHAT_HT")

                End If

                Dim qte As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("STOCK").Value.ToString, qte)
                End If

                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value, entre_en_stock)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value, entre_en_stock)
                End If
                Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock 'QUANTITE EN MOVEMENT

                Dim DATE_PEREMPTION As Date

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                    DATE_PEREMPTION = GunaDateTimePickerDatePeremption.Value.ToShortDateString()
                End If

                Dim UNITE_UTILISE As String = ""
                Dim PRIX_UNITAIRE_HT As Double = 0 'PRIX UNITAIRE ACHAT
                Dim PRIX_UNITAIRE_TTC As Double = 0 'PRIX UNITAIRE VENTE
                Dim PRIX_TOTAL_HT As Double = 0 'PRIX TOTAL ACHAT
                Dim PRIX_TOTAL_TTC As Double = 0 'PRIX TOTAL VENTE
                Dim NUM_SERIE_DEBUT As String = 0
                Dim NUM_SERIE_FIN As String = ""

                If GlobalVariable.actualLanguageValue = 1 Then
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value
                    PRIX_UNITAIRE_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX UNITAIRE").Value 'PRIX UNITAIRE ACHAT
                    PRIX_UNITAIRE_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value 'PRIX UNITAIRE VENTE
                    PRIX_TOTAL_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX UNITAIRE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL ACHAT
                    PRIX_TOTAL_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL VENTE
                    NUM_SERIE_DEBUT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value
                    NUM_SERIE_FIN = ""
                Else
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value
                    PRIX_UNITAIRE_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT PRICE").Value 'PRIX UNITAIRE ACHAT
                    PRIX_UNITAIRE_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value 'PRIX UNITAIRE VENTE
                    PRIX_TOTAL_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT PRICE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL ACHAT
                    PRIX_TOTAL_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL VENTE
                    NUM_SERIE_DEBUT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value
                    NUM_SERIE_FIN = ""
                End If

                'NUM_SERIE_DEBUT : USED AS UNITE DE DESTOCKAGE UTILISE POUR LIGNE DE BORDEREAU

                '-------------------------- DEBUT TRAITEMENTS DE LIGNE DE MOUVEMENT FONCTION DE L'UNITE UTILISEE ------------------------------------------------
                Dim PETITE_UNITE As String = ""
                Dim GRANDE_UNITE As String = ""
                Dim LIBELLE_UNITE As String = UNITE_UTILISE

                Dim VALEUR_DE_CONVERSION As Double = 1

                If Article.Rows.Count > 0 Then

                    Dim BOISSON As Integer = Article.Rows(0)("BOISSON")

                    Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")

                    Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If unite.Rows.Count > 0 Then

                        PETITE_UNITE = unite.Rows(0)("PETITE_UNITE")
                        GRANDE_UNITE = unite.Rows(0)("GRANDE_UNITE")
                        VALEUR_DE_CONVERSION = unite.Rows(0)("VALEUR_NUMERIQUE")

                        '-------------------------------------------------------------------------------------------------------------------------------------------
                        Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                        If Trim(Article.Rows(0)("CODE_CONSO")).Equals("") Then
                            conso = Nothing
                        End If

                        If conso IsNot Nothing And BOISSON = 1 Then

                            If conso.Rows.Count > 0 Then

                                'Dim QUANTITE_CONSO = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION
                                Dim valeurConversion As Double = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                                'MessageBox.Show("Petite Unite : " & PETITE_UNITE & " Grande unite :  " & GRANDE_UNITE & " Unite de conso : " & conso.Rows(0)("GRANDE_UNITE") & " valeur conso : " & conso.Rows(0)("VALEUR_NUMERIQUE"))

                                Dim contenance As Double = Article.Rows(0)("CONTENANCE")

                                Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                                If LIBELLE_UNITE = PETITE_UNITE Then
                                    QUANTITE_ENTREE_STOCK = QUANTITE_ENTREE_STOCK * nombreDeConsoDansUneBouteille
                                End If

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    NUM_SERIE_DEBUT = "CONSOMMATION"
                                ElseIf GlobalVariable.actualLanguageValue = 10 Then
                                    NUM_SERIE_DEBUT = "SHOT"
                                End If

                            End If

                        Else

                            If LIBELLE_UNITE = PETITE_UNITE Then

                                QUANTITE_ENTREE_STOCK = QUANTITE_ENTREE_STOCK '

                            ElseIf LIBELLE_UNITE = GRANDE_UNITE Then

                                QUANTITE_ENTREE_STOCK = QUANTITE_ENTREE_STOCK * VALEUR_DE_CONVERSION

                            End If

                            NUM_SERIE_DEBUT = PETITE_UNITE

                        End If

                    End If

                End If

                '------------------------------------------------------------------------------------------------------------------------------------------------

                If GlobalVariable.actualLanguageValue = 1 Then
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                Else
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                End If

                'NUM_SERIE_DEBUT : USED AS UNITE D'ENTREE
                'Insertion des informations des lignes du bordereau
                If econom.insertLigneBordereau(CODE_BORDEREAUX, CODE_LIGNE, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE, QUANTITE_ENTREE_STOCK, DATE_PEREMPTION, PRIX_UNITAIRE_HT, PRIX_UNITAIRE_TTC, PRIX_TOTAL_HT, PRIX_TOTAL_TTC, NUM_SERIE_DEBUT, NUM_SERIE_FIN, COUT_DU_STOCK, CODE_SOUS_MAGASIN) Then

                    Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "MS")
                    Dim LIBELLE_MOUVEMENT As String = GunaComboBoxTypeBordereau.SelectedItem.ToString

                    Dim TYPE_MOUVEMENT As String = ""

                    Dim QUANTITE_ENTREE As Double = 0
                    Dim QUANTITE_SORTIE As Double = 0
                    Dim VALEUR_ENTREE As Double = 0
                    Dim VALEUR_SORTIE As String = 0

                    If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                        TYPE_MOUVEMENT = "Entrée en stock"
                        QUANTITE_ENTREE = entre_en_stock
                        VALEUR_ENTREE = QUANTITE_ENTREE
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then
                        TYPE_MOUVEMENT = "Sortie de stock"
                        QUANTITE_SORTIE = entre_en_stock
                        VALEUR_SORTIE = entre_en_stock
                    ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then
                        TYPE_MOUVEMENT = GlobalVariable.transfert_inter
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then
                        TYPE_MOUVEMENT = GlobalVariable.sortie_exceptionnelle
                        QUANTITE_SORTIE = entre_en_stock
                        VALEUR_SORTIE = entre_en_stock
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then
                        TYPE_MOUVEMENT = GlobalVariable.entree_exceptionnelle
                        QUANTITE_ENTREE = entre_en_stock
                        VALEUR_ENTREE = QUANTITE_ENTREE
                    End If

                End If

            Next

            'Mise ajours du bon de commande ayant conduit au Bon de Réception pour que le bon de commande ne s'affiche plus lors de creation d'un bon de réception
            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                Dim CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR As String = REF_BORDEREAUX
                Dim ETAT_BORDEREAU As Integer = 3
                econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

            ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

            End If

        End If

        Functions.SiplifiedClearTextBox(Me)

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

    End Sub

    Dim CODE_REFERENCE_BORDERO As String = ""

    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        If GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then

            Me.Cursor = Cursors.WaitCursor

            GunaComboBoxTypeBordereau.Enabled = True

            GunaButtonAnnulerBordereau.Visible = False

            Dim econom As New Economat()

            If GunaButtonEnregistrer.Text = "Enregistrer" Or GunaButtonEnregistrer.Text = "Save" Then

                '------------------------------------ ENVOI DE MAIL ------------------------------------------------------

                Dim totalAchat As Double = 0
                'Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

                If Not Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
                    totalAchat = GunaTextBoxMontantHTGeneralAchat.Text
                End If

                Dim totalVente As Double = 0

                If Not Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
                    totalVente = GunaTextBoxMontantTTCGeneralVente.Text
                End If

                Dim title As String = LabelBon.Text
                Dim nomTiers As String = GunaTextBoxNomTiers.Text
                Dim libelle As String = GunaTextBoxLibelleBordereau.Text
                Dim reference As String = GunaTextBoxReference.Text
                Dim observation As String = GunaTextBoxObservation.Text
                Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

                Dim typeBordereau As String = GlobalVariable.list_du_marche

                Dim ETAT_BORDEREAUX_MAIL As Integer = 0

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
                    If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
                        typeBordereau = ""
                    End If

                    If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                        Dim args As ArgumentType = New ArgumentType()
                        args.action = 1
                        ''backGroundWorkerToCall(args)

                        RapportApresCloture.impressionEconomat(GunaDataGridViewLigneArticleCommande, title, totalAchat, totalVente, numeroBon, ETAT_BORDEREAUX_MAIL, nomTiers, libelle, reference, observation, typeBordereau)

                    End If

                End If

                '------------------------------------------------------------------------------------------

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then

                    InsertionDesElementsPourGestionDeStock()

                    Dim ETAT_BORDEREAU As Integer = 5

                    'Dim CODE_BORDEREAUX_A_RECEPTION_A_METTRE_AJOUR As String = Functions.latInsertedElementCode("bordereaux", "CODE_BORDEREAUX")
                    'MISE A JOUR DU BON DE COMMANDE AYANT CONDUIT AU BON DE RECEPTION
                    Dim CODE_BORDEREAUX_A_METTRE_AJOUR As String = CODE_REFERENCE_BORDERO

                    econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_A_METTRE_AJOUR, ETAT_BORDEREAU)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bordereau crée avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Slip successfully created!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_approvisi Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then

                    InsertionDesElementsPourGestionDeStock()

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bordereau crée avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Slip successfully created!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

                    InsertionDesElementsPourGestionDeStock()

                    'Dim ETAT_BORDEREAU As Integer = 4
                    Dim ETAT_BORDEREAU As Integer = 5

                    'Dim CODE_BORDEREAUX_A_RECEPTION_A_METTRE_AJOUR As String = Functions.latInsertedElementCode("bordereaux", "CODE_BORDEREAUX")
                    'MISE A JOUR DU BON DE COMMANDE AYANT CONDUIT AU TRANSFERT INTER MAGASIN

                    Dim CODE_BORDEREAUX_A_METTRE_AJOUR As String = CODE_REFERENCE_BORDERO

                    econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_A_METTRE_AJOUR, ETAT_BORDEREAU)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Transfert Inter Magasin enregistré avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Inter Store Transfer Successfully saved!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then

                    InsertionDesElementsPourGestionDeStock()

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Sortie réalisé avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Exit successfully done!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Then

                    InsertionDesElementsPourGestionDeStock()

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Sortie exceptionnelle enregistrée avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Exceptionnal Exit successfully saved!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.entree_exceptionnelle Then

                    InsertionDesElementsPourGestionDeStock()

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Entrée exceptionnelle enregistrée avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Exceptionnal Entry successfully saved!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            ElseIf GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then

                'MISE A JOURS DES DIFFERENTS BORDEREAUX

                'Mise à jour d'un bordereau

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then

                    Dim ETAT_NOTE_DU_BORDEREAU As String = Functions.getElementByCode(Trim(GunaTextBoxCodeBordereau.Text), "bordereaux", "CODE_BORDEREAUX").Rows(0)("VALIDE")

                    Dim ETAT_DU_BORDEREAU As String = Functions.getElementByCode(Trim(GunaTextBoxCodeBordereau.Text), "bordereaux", "CODE_BORDEREAUX").Rows(0)("ETAT_BORDEREAU")

                    Dim CODE_BORDEREAUX As String = Trim(GunaTextBoxCodeBordereau.Text)

                    Functions.DeleteElementByCode(CODE_BORDEREAUX, "bordereaux", "CODE_BORDEREAUX")

                    Functions.DeleteElementByCode(CODE_BORDEREAUX, "ligne_bordereaux", "CODE_BORDEREAUX")

                    InsertionDesElementsPourGestionDeStock(ETAT_NOTE_DU_BORDEREAU, ETAT_DU_BORDEREAU)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bordereau mise à jours avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Slip successfully updated!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_approvisi Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then

                    Dim infoSupBordereaux As DataTable = Functions.getElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

                    If infoSupBordereaux.Rows.Count > 0 Then

                        Dim ETAT_DU_BORDEREAU As String = infoSupBordereaux.Rows(0)("VALIDE")

                        Functions.DeleteElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

                        Functions.DeleteElementByCode(GunaTextBoxCodeBordereau.Text, "ligne_bordereaux", "CODE_BORDEREAUX")

                        InsertionDesElementsPourGestionDeStock(ETAT_DU_BORDEREAU)

                    End If

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bordereau mis ajour avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Slip successfully updated!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.entree_exceptionnelle Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

                    Dim infoSupBordereaux As DataTable = Functions.getElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

                    If infoSupBordereaux.Rows.Count > 0 Then

                        Dim ETAT_DU_BORDEREAU As String = infoSupBordereaux.Rows(0)("VALIDE")

                        Functions.DeleteElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

                        Functions.DeleteElementByCode(GunaTextBoxCodeBordereau.Text, "ligne_bordereaux", "CODE_BORDEREAUX")

                        InsertionDesElementsPourGestionDeStock(ETAT_DU_BORDEREAU)

                    End If

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bordereau mis ajour avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Slip successfully updated!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            End If

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
            Dim CODE_USER As String = GlobalVariable.codeUser

            econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

            TabControlEconomat.SelectedIndex = 1

            NewBonDeRequisition()

            Me.Cursor = Cursors.Default

            TabControlEconomat.SelectedIndex = 0

        Else
            If GlobalVariable.actualLanguageValue = 10 Then
                MessageBox.Show("Please Fill de Form!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Bien vouloir remplir le bordereau!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Public Sub sauvegardeDeModificationAvantControle(ByVal Optional ETAT_NOTE_DU_BORDEREAU As String = "", ByVal Optional ETAT_DU_BORDEREAU As Integer = 0)

        'LabelQuantiteEnMagasinSource.Visible = False

        'GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

        Dim CODE_BORDEREAUX As String = GunaTextBoxCodeBordereau.Text

        Dim econom As New Economat()
        'Enregistrement des éléments du bordereau

        Dim TYPE_BORDEREAUX As String = GunaComboBoxTypeBordereau.SelectedItem.ToString
        Dim REF_BORDEREAUX As String = GunaTextBoxReference.Text
        Dim LIBELLE_BORDEREAUX As String = GunaTextBoxLibelleBordereau.Text
        Dim CODE_TIERS As String = GunaTextBoxTiers.Text
        Dim NON_TIERS As String = GunaTextBoxNomTiers.Text
        Dim DATE_BORDEREAU As Date = GlobalVariable.DateDeTravail
        Dim OBSERVATIONS As String = GunaTextBoxObservation.Text

        If Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
            GunaTextBoxMontantHTGeneralAchat.Text = 0
        End If

        Dim MONTANT_HT As Double = Double.Parse(GunaTextBoxMontantHTGeneralAchat.Text) ' MONTANT VENTE
        Dim MONTANT_TAXE As Double = 0
        Dim MONTANT_TTC As Double = 0

        If Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
            GunaTextBoxMontantTTCGeneralVente.Text = 0
        End If

        Dim MONTANT_PAYER As Double = Double.Parse(GunaTextBoxMontantTTCGeneralVente.Text) ' MONTANT ACHAT
        Dim VALIDE As String = ETAT_NOTE_DU_BORDEREAU
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString
        Dim CODE_SOUS_MAGASIN As String = ""

        Dim COUT_DU_STOCK As Double = 0

        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.transfert_inter Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then

            If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
                CODE_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
                CODE_SOUS_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString
            Else
                CODE_SOUS_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
            End If

        End If

        'Insertion des information du bordereau
        If econom.insertBordereau(CODE_BORDEREAUX, TYPE_BORDEREAUX, REF_BORDEREAUX, LIBELLE_BORDEREAUX, CODE_TIERS, NON_TIERS, DATE_BORDEREAU, OBSERVATIONS, MONTANT_HT, MONTANT_TAXE, MONTANT_TTC, MONTANT_PAYER, VALIDE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_MAGASIN, CODE_SOUS_MAGASIN, ETAT_DU_BORDEREAU) Then

            Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")
            Dim CHAMP_A_METTRE_A_JOUR As String = "ENREGISTRER"

            econom.inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)

            '-------------------------------------- MISE A JOURS DES PERIODES DE LA LISTE DU MARCHE -------------------------------------------------------
            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
                'ON MET A JOUR LA PERIODE DE LA LISTE DU MARCHE

                Dim DATE_DU As Date = GunaDateTimePickerP1LM.Value.ToShortDateString()
                Dim DATE_AU As Date = GunaDateTimePickerP2LM.Value.ToShortDateString()

                Dim updateQuery As String = "UPDATE `bordereaux` SET `DATE_DU` = @DATE_DU , `DATE_AU` = @DATE_AU  WHERE CODE_BORDEREAUX = @CODE_BORDEREAUX"

                Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
                command.Parameters.Add("@DATE_DU", MySqlDbType.Date).Value = DATE_DU
                command.Parameters.Add("@DATE_AU", MySqlDbType.Date).Value = DATE_AU

                command.ExecuteNonQuery()

            End If
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

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BR")

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "TI")

                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BC")
                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_approvisi Then
                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BA")
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BS")

                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "SE")

                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "EE")

                End If

                Dim CODE_ARTICLE As String = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("CODE ARTICLE").Value.ToString

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                Dim Article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                If Article.Rows.Count > 0 Then
                    CMUP = Article.Rows(0)("PRIX_ACHAT_HT")
                End If

                Dim qte As Double = 0

                Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)

                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value, entre_en_stock)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value, entre_en_stock)
                End If

                Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock 'QUANTITE EN MOVEMENT

                Dim DATE_PEREMPTION As Date

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                    DATE_PEREMPTION = GunaDateTimePickerDatePeremption.Value.ToShortDateString()
                End If

                Dim UNITE_UTILISE As String = ""
                Dim PRIX_UNITAIRE_HT As Double = 0 'PRIX UNITAIRE ACHAT
                Dim PRIX_UNITAIRE_TTC As Double = 0 'PRIX UNITAIRE VENTE
                Dim PRIX_TOTAL_HT As Double = 0 'PRIX TOTAL ACHAT
                Dim PRIX_TOTAL_TTC As Double = 0 'PRIX TOTAL VENTE
                Dim NUM_SERIE_DEBUT As String = ""
                Dim NUM_SERIE_FIN As String = ""

                If GlobalVariable.actualLanguageValue = 1 Then
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value
                    PRIX_UNITAIRE_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX UNITAIRE").Value 'PRIX UNITAIRE ACHAT
                    PRIX_UNITAIRE_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value 'PRIX UNITAIRE VENTE
                    PRIX_TOTAL_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX UNITAIRE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL ACHAT
                    PRIX_TOTAL_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL VENTE
                    NUM_SERIE_DEBUT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value.ToString
                    NUM_SERIE_FIN = ""
                Else
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value
                    PRIX_UNITAIRE_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT PRICE").Value 'PRIX UNITAIRE ACHAT
                    PRIX_UNITAIRE_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value 'PRIX UNITAIRE VENTE
                    PRIX_TOTAL_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT PRICE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL ACHAT
                    PRIX_TOTAL_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL VENTE
                    NUM_SERIE_DEBUT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value.ToString
                    NUM_SERIE_FIN = ""
                End If

                'NUM_SERIE_DEBUT : USED AS UNITE DE DESTOCKAGE UTILISE POUR LIGNE DE BORDEREAU

                '-------------------------- DEBUT TRAITEMENTS DE LIGNE DE MOUVEMENT FONCTION DE L'UNITE UTILISEE ------------------------------------------------
                Dim PETITE_UNITE As String = ""
                Dim GRANDE_UNITE As String = ""
                Dim LIBELLE_UNITE As String = UNITE_UTILISE

                Dim VALEUR_DE_CONVERSION As Double = 1

                If Article.Rows.Count > 0 Then

                    Dim BOISSON As Integer = Article.Rows(0)("BOISSON")

                    Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")

                    Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If unite.Rows.Count > 0 Then

                        PETITE_UNITE = unite.Rows(0)("PETITE_UNITE")
                        GRANDE_UNITE = unite.Rows(0)("GRANDE_UNITE")
                        VALEUR_DE_CONVERSION = unite.Rows(0)("VALEUR_NUMERIQUE")

                        '-------------------------------------------------------------------------------------------------------------------------------------------
                        Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                        If Trim(Article.Rows(0)("CODE_CONSO")).Equals("") Then
                            conso = Nothing
                        End If

                        If conso IsNot Nothing And BOISSON = 1 Then

                            If conso.Rows.Count > 0 Then

                                'Dim QUANTITE_CONSO = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION
                                Dim valeurConversion As Double = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                                'MessageBox.Show("Petite Unite : " & PETITE_UNITE & " Grande unite :  " & GRANDE_UNITE & " Unite de conso : " & conso.Rows(0)("GRANDE_UNITE") & " valeur conso : " & conso.Rows(0)("VALEUR_NUMERIQUE"))

                                Dim contenance As Double = Article.Rows(0)("CONTENANCE")

                                Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                                If LIBELLE_UNITE = PETITE_UNITE Then
                                    QUANTITE_ENTREE_STOCK = QUANTITE_ENTREE_STOCK * nombreDeConsoDansUneBouteille
                                End If

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    NUM_SERIE_DEBUT = "CONSOMMATION"
                                ElseIf GlobalVariable.actualLanguageValue = 10 Then
                                    NUM_SERIE_DEBUT = "SHOT"
                                End If

                            End If

                        Else

                            If LIBELLE_UNITE = PETITE_UNITE Then

                                QUANTITE_ENTREE_STOCK = QUANTITE_ENTREE_STOCK '

                            ElseIf LIBELLE_UNITE = GRANDE_UNITE Then

                                QUANTITE_ENTREE_STOCK = QUANTITE_ENTREE_STOCK * VALEUR_DE_CONVERSION

                            End If

                            NUM_SERIE_DEBUT = PETITE_UNITE

                        End If

                    End If

                End If

                '------------------------------------------------------------------------------------------------------------------------------------------------

                If GlobalVariable.actualLanguageValue = 1 Then
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                Else
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                End If
                'NUM_SERIE_DEBUT : USED AS UNITE D'ENTREE
                'Insertion des informations des lignes du bordereau
                If econom.insertLigneBordereau(CODE_BORDEREAUX, CODE_LIGNE, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE, QUANTITE_ENTREE_STOCK, DATE_PEREMPTION, PRIX_UNITAIRE_HT, PRIX_UNITAIRE_TTC, PRIX_TOTAL_HT, PRIX_TOTAL_TTC, NUM_SERIE_DEBUT, NUM_SERIE_FIN, COUT_DU_STOCK, CODE_SOUS_MAGASIN) Then

                    Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "MS")
                    Dim LIBELLE_MOUVEMENT As String = GunaComboBoxTypeBordereau.SelectedItem.ToString

                    Dim TYPE_MOUVEMENT As String = ""

                    Dim QUANTITE_ENTREE As Double = 0
                    Dim QUANTITE_SORTIE As Double = 0
                    Dim VALEUR_ENTREE As Double = 0
                    Dim VALEUR_SORTIE As String = 0

                    If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                        TYPE_MOUVEMENT = "Entrée en stock"
                        QUANTITE_ENTREE = entre_en_stock
                        VALEUR_ENTREE = QUANTITE_ENTREE
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then
                        TYPE_MOUVEMENT = "Sortie de stock"
                        QUANTITE_SORTIE = entre_en_stock
                        VALEUR_SORTIE = entre_en_stock
                    ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then
                        TYPE_MOUVEMENT = GlobalVariable.transfert_inter
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then
                        TYPE_MOUVEMENT = GlobalVariable.sortie_exceptionnelle
                        QUANTITE_SORTIE = entre_en_stock
                        VALEUR_SORTIE = entre_en_stock
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then
                        TYPE_MOUVEMENT = GlobalVariable.entree_exceptionnelle
                        QUANTITE_ENTREE = entre_en_stock
                        VALEUR_ENTREE = QUANTITE_ENTREE
                    End If

                End If

            Next

        End If

    End Sub

    'Validation du bon de commande avant tout autre action
    Private Sub GunaButtonValider_Click(sender As Object, e As EventArgs) Handles GunaButtonController.Click

        Me.Cursor = Cursors.WaitCursor

        'ENREGISTREMENT AU CAS OU LE IL A ETE MODIFIE

        Dim CODE_BORDEREAUX As String = Trim(GunaTextBoxCodeBordereau.Text)
        Dim save As Boolean = True

        Dim infoSupBordereau As DataTable = Functions.getElementByCode(CODE_BORDEREAUX, "ligne_bordereaux", "CODE_BORDEREAUX")

        If Not infoSupBordereau Is Nothing Then
            If infoSupBordereau.Rows.Count > 0 Then
                save = False
            End If
        End If

        If save Then

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.entree_exceptionnelle Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Then

                Dim ETAT_NOTE_DU_BORDEREAU As String = Functions.getElementByCode(Trim(GunaTextBoxCodeBordereau.Text), "bordereaux", "CODE_BORDEREAUX").Rows(0)("VALIDE")

                Dim ETAT_DU_BORDEREAU As String = Functions.getElementByCode(Trim(GunaTextBoxCodeBordereau.Text), "bordereaux", "CODE_BORDEREAUX").Rows(0)("ETAT_BORDEREAU")

                Functions.DeleteElementByCode(CODE_BORDEREAUX, "bordereaux", "CODE_BORDEREAUX")

                Functions.DeleteElementByCode(CODE_BORDEREAUX, "ligne_bordereaux", "CODE_BORDEREAUX")

                sauvegardeDeModificationAvantControle(ETAT_NOTE_DU_BORDEREAU, ETAT_DU_BORDEREAU)

            ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_approvisi Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then

                Dim infoSupBordereaux As DataTable = Functions.getElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

                If infoSupBordereaux.Rows.Count > 0 Then

                    Dim ETAT_DU_BORDEREAU As String = infoSupBordereaux.Rows(0)("VALIDE")

                    Functions.DeleteElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

                    Functions.DeleteElementByCode(GunaTextBoxCodeBordereau.Text, "ligne_bordereaux", "CODE_BORDEREAUX")

                    sauvegardeDeModificationAvantControle(ETAT_DU_BORDEREAU)

                End If

            End If

        End If

        GunaComboBoxTypeBordereau.Enabled = True

        permettreAjoutArticle()

        GunaLabelEnregistreur.Visible = False

        GunaButtonAnnulerBordereau.Visible = False

        Dim econom As New Economat()
        Dim CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR As String = ""
        Dim ETAT_BORDEREAU As Integer = 1

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then

            Dim totalAchat As Double = 0
            'Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

            If Not Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
                totalAchat = GunaTextBoxMontantHTGeneralAchat.Text
            End If

            Dim totalVente As Double = 0

            If Not Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
                totalVente = GunaTextBoxMontantTTCGeneralVente.Text
            End If

            Dim title As String = LabelBon.Text
            Dim nomTiers As String = GunaTextBoxNomTiers.Text
            Dim libelle As String = GunaTextBoxLibelleBordereau.Text
            Dim reference As String = GunaTextBoxReference.Text
            Dim observation As String = GunaTextBoxObservation.Text
            Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

            Dim typeBordereau As String = GlobalVariable.list_du_marche

            Dim ETAT_BORDEREAUX_MAIL As Integer = 1

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
                    typeBordereau = ""
                End If
                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                    Dim args As ArgumentType = New ArgumentType()
                    args.action = 1
                    ''backGroundWorkerToCall(args)
                    RapportApresCloture.impressionEconomat(GunaDataGridViewLigneArticleCommande, title, totalAchat, totalVente, numeroBon, ETAT_BORDEREAUX_MAIL, nomTiers, libelle, reference, observation, typeBordereau)
                End If
            End If

        End If

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then

            If Trim(GunaTextBoxCodeBordereau.Text) = "" Then

            Else

                'ON VERIFIE SI LA REFERENCE DU BC EST ASSOCIE AU CODE D'UNE FICHE TECHNIQUE AUQUEL CAS IL FAUDRA JUSTE VALIDER POUR DESTOCKER
                Dim ficheTechnique As DataTable = Functions.getElementByCode(GunaTextBoxReference.Text, "fiche_technique", "CODE_FICHE_TECHNIQUE")

                If ficheTechnique.Rows.Count > 0 Then

                    Dim CODE_FICHE_TECHNIQUE As String = GunaTextBoxReference.Text

                    Dim QUANTITE_PREPAREE As Double = 0

                    If GlobalVariable.actualLanguageValue = 1 Then
                        QUANTITE_PREPAREE = ficheTechnique.Rows(0)("QUANTITE")
                    Else
                        QUANTITE_PREPAREE = ficheTechnique.Rows(0)("QUANTITY")
                    End If

                    'DESTOCKAGE DES MATIERES EN PROVENANCE DE LA FICHE TECHNIQUE

                    Dim arti As New Article()

                    Dim articleADestocker As DataTable = arti.elementsDuneFicheTechnique(CODE_FICHE_TECHNIQUE)

                    If articleADestocker.Rows.Count > 0 Then

                        ETAT_BORDEREAU = 2

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

                            Dim QUANTITE_ARTICLE_A_DESTOCKER As Double = ((qteDouble * -1) / valeurDeConversion) * QUANTITE_PREPAREE

                            Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                            Dim CMUP As Double = 0

                            Dim CODE_MAGASIN As String = ""

                            If GunaComboBoxMagasin_1.SelectedIndex >= 0 Then
                                CODE_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString
                            End If

                            If Functions.getElementByCode(articleADestocker.Rows(i)("CODE ARTICLE"), "article", "CODE_ARTICLE").Rows.Count > 0 Then

                                If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then
                                    QUANTITE_AVANT_MOVEMENT = Economat.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, articleADestocker.Rows(i)("CODE ARTICLE"))
                                Else
                                    QUANTITE_AVANT_MOVEMENT = Functions.getElementByCode(articleADestocker.Rows(i)("CODE ARTICLE"), "article", "CODE_ARTICLE").Rows(0)("QUANTITE")
                                End If

                                CMUP = Functions.getElementByCode(articleADestocker.Rows(i)("CODE ARTICLE"), "article", "CODE_ARTICLE").Rows(0)("PRIX_ACHAT_HT")

                            End If

                            If econom.gestionStockagesEtDeStockages(CODE_ARTICLE_A_DESTOCKER, TABLE_SOURCEA_DESTOCKER, QUANTITE_ARTICLE_A_DESTOCKER) Then

                            End If

                            'MOVEMENT DE STOCK

                            Dim entre_en_stock As Double = 0

                            Dim sortie_de_stock As Double = QUANTITE_ARTICLE_A_DESTOCKER

                            Dim DATE_PEREMPTION As Date

                            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                                DATE_PEREMPTION = GunaDateTimePickerDatePeremption.Value.ToShortDateString()
                            End If

                            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                            Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "")
                            Dim LIBELLE_MOUVEMENT As String = "sortie des matieres pour pour l'article " + articleADestocker.Rows(i)("DESIGNATION")

                            If GlobalVariable.actualLanguageValue = 0 Then
                                LIBELLE_MOUVEMENT = "Out going of raw materials for " + articleADestocker.Rows(i)("DESIGNATION")
                            End If

                            Dim TYPE_MOUVEMENT As String = "sortie de stock"

                            Dim QUANTITE_ENTREE As Double = 0
                            Dim QUANTITE_SORTIE As Double = sortie_de_stock
                            Dim VALEUR_ENTREE As Double = 0
                            Dim VALEUR_SORTIE As String = sortie_de_stock

                            Dim ETAT_MOUVEMENT As String = ""
                            Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                            Dim CODE_LOT As String = codeUniteDeComptageLigne

                            Dim CODE_BORDEREAUX_MOV As String = Trim(GunaTextBoxCodeBordereau.Text)

                            Dim infoSupMagasin As DataTable = Functions.getElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

                            If infoSupMagasin.Rows.Count > 0 Then
                                CODE_MAGASIN = infoSupMagasin.Rows(0)("CODE_MAGASIN")
                            End If

                            'INSERTION DU MOVEMENT DE STOCK
                            If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT.ToString.ToUpper(), TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE_A_DESTOCKER, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE * -1, VALEUR_ENTREE, VALEUR_SORTIE * -1, CODE_UTILISATEUR_CREA, GlobalVariable.codeAgence, CODE_BORDEREAUX_MOV, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                            End If

                        Next

                        'MISE A JOUR DE LA QUANTITE DE L'ARTICLE COMPOSE

                        'ON DOIT DETERMINER SI LA FICHE TECHNIQUE EST ASSOCIE A UN OU PLUSIEURS ARTICLES / PLATS

                        Dim DATE_PREPARATION As Date = GlobalVariable.DateDeTravail

                        Dim query As String = "SELECT * FROM fiche_technique_article_prepare WHERE DATE_PREPARATION <= '" & DATE_PREPARATION.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >='" & DATE_PREPARATION.ToString("yyyy-MM-dd") & "' AND CODE_FICHE_TECHNIQUE = @CODE_FICHE_TECHNIQUE AND ETAT=@ETAT"

                        Dim command As New MySqlCommand(query, GlobalVariable.connect)
                        command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE
                        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0

                        Dim adapter As New MySqlDataAdapter(command)
                        Dim table As New DataTable()
                        adapter.Fill(table)

                        If table.Rows.Count > 0 Then

                            For i = 0 To table.Rows.Count - 1

                                Dim CODE_ARTICLE As String = table.Rows(i)("CODE_ARTICLE")
                                Dim TABLE_SOURCE As String = "article"
                                Dim QUANTITE_ARTICLE As Double = table.Rows(i)("QUANTITE_PREPARE")
                                Dim CODE_DESTINATION As String = ""

                                If econom.gestionStockagesEtDeStockages(CODE_ARTICLE, TABLE_SOURCE, QUANTITE_ARTICLE) Then

                                    Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("mouvement_stock", "MS")
                                    Dim LIBELLE_MOUVEMENT = "Préparation de plat " & table.Rows(i)("NOM_ARTICLE")
                                    If GlobalVariable.actualLanguageValue = 0 Then
                                        LIBELLE_MOUVEMENT = "Preparation of " & table.Rows(i)("NOM_ARTICLE")
                                    End If
                                    Dim TYPE_MOUVEMENT = "Entrée"
                                    Dim ETAT_MOUVEMENT = 0
                                    Dim DATE_MOUVEMENT = GlobalVariable.DateDeTravail
                                    Dim CODE_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString
                                    Dim CODE_ARTICLE_A_DESTOCKER As String = CODE_ARTICLE
                                    Dim CODE_LOT As String = ""
                                    Dim QUANTITE_ENTREE = QUANTITE_ARTICLE
                                    Dim QUANTITE_SORTIE = 0
                                    Dim VALEUR_ENTREE = QUANTITE_ARTICLE
                                    Dim VALEUR_SORTIE = 0
                                    Dim CODE_UTILISATEUR_CREA = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                                    Dim CODE_BORDEREAUX_MOV As String = Trim(GunaTextBoxCodeBordereau.Text)

                                    Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                                    Dim CMUP As Double = 0

                                    Dim infoSupArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                                    If infoSupArticle.Rows.Count > 0 Then

                                        If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then
                                            QUANTITE_AVANT_MOVEMENT = Economat.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)
                                        Else
                                            QUANTITE_AVANT_MOVEMENT = infoSupArticle.Rows(0)("QUANTITE")
                                        End If

                                        CMUP = infoSupArticle.Rows(0)("PRIX_ACHAT_HT")
                                    End If

                                    If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT.ToString.ToUpper(), TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE_A_DESTOCKER, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE * -1, VALEUR_ENTREE, VALEUR_SORTIE * -1, CODE_UTILISATEUR_CREA, GlobalVariable.codeAgence, CODE_BORDEREAUX_MOV, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                                    End If
                                End If

                                'MISE A JOUR DE L'ETAT DE LA LIGNE PREPAREE

                                Dim ID_FICHE_ARTICLE_PREPARE As Integer = table.Rows(i)("ID_FICHE_ARTICLE_PREPARE")

                                '-----------------------------------------------------------------------------------------------------------------------------
                                Dim updateQuery As String = "UPDATE `fiche_technique_article_prepare` SET `ETAT` = @ETAT  WHERE ID_FICHE_ARTICLE_PREPARE = @ID_FICHE_ARTICLE_PREPARE"

                                Dim commandUpdate As New MySqlCommand(updateQuery, GlobalVariable.connect)

                                commandUpdate.Parameters.Add("@ETAT", MySqlDbType.VarChar).Value = 1
                                commandUpdate.Parameters.Add("@ID_FICHE_ARTICLE_PREPARE", MySqlDbType.VarChar).Value = ID_FICHE_ARTICLE_PREPARE

                                commandUpdate.ExecuteNonQuery()
                                '----------------------------------------------------------------------------------------------------------------------------

                            Next

                        Else

                        End If

                        ETAT_BORDEREAU = 5

                        '2- UNE FICHE TECHNIQUE UN ARTICLE

                        '1- UNE FICHE TECHNIQUE PLUSIERS PLATS

                    End If

                End If

                If GlobalVariable.actualLanguageValue = 0 Then
                    MessageBox.Show("Slip successfully controled!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Bordereau contrôlé avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                TabControlEconomat.SelectedIndex = 1

            End If

            Dim TYPE_BORDERO As String = ""

            If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
                TYPE_BORDERO = GlobalVariable.bon_approvisi
            End If

            CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR = GunaTextBoxCodeBordereau.Text

            econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU, TYPE_BORDERO)

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
            Dim CODE_USER As String = GlobalVariable.codeUser

            econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

            Functions.SiplifiedClearTextBox(Me)

            GunaDataGridViewLigneArticleCommande.Columns.Clear()

            If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
                TYPE_BORDERO = ""
            End If

        ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_reception Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then

            'LE REAPPROVISIONNEMENT SE FAIT EN SELON LES ETAPES SUIVANTES : BC->SAVE->CONTROLLER (3 ETAPES)
            '------------------------ LIGNE DE MOVEMENT --------------------------

            Dim CODE_LOT As String = ""

            'Dim CODE_BORDEREAUX As String = Trim(GunaTextBoxCodeBordereau.Text)
            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

                Dim CODE_ARTICLE As String = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("CODE ARTICLE").Value.ToString

                Dim qte As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("STOCK").Value.ToString, qte)
                End If

                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                'Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock 'QUANTITE EN MOVEMENT

                '------------------------------------------------------------------------------------------

                'ON DOIT VERIFIER QUE NOUS SOMMES EN GRANDE UNITE
                Dim UNITE_UTILISE As String = ""
                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value.ToString, entre_en_stock)

                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value.ToString
                Else
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value.ToString
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value.ToString, entre_en_stock)

                End If
                CODE_LOT = UNITE_UTILISE
                Dim DATE_PEREMPTION As Date = GunaDateTimePickerDatePeremption.Value.ToShortDateString()

                Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString

                Dim COUT_DU_STOCK As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                Else
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                End If

                Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "")
                Dim LIBELLE_MOUVEMENT As String = GunaComboBoxTypeBordereau.SelectedItem.ToString

                Dim TYPE_MOUVEMENT As String = ""

                Dim QUANTITE_ENTREE As Double = 0
                Dim QUANTITE_SORTIE As Double = 0
                Dim VALEUR_ENTREE As Double = 0
                Dim VALEUR_SORTIE As String = 0

                TYPE_MOUVEMENT = "Entrée en stock"
                QUANTITE_ENTREE = entre_en_stock
                VALEUR_ENTREE = QUANTITE_ENTREE

                '-------------------------- DEBUT TRAITEMENTS DE LIGNE DE MOUVEMENT FONCTION DE L'UNITE UTILISEE ------------------------------------------------
                Dim PETITE_UNITE As String = ""
                Dim GRANDE_UNITE As String = ""
                Dim LIBELLE_UNITE As String = UNITE_UTILISE

                Dim VALEUR_DE_CONVERSION As Double = 1

                Dim Article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                If Article.Rows.Count > 0 Then

                    Dim BOISSON As Integer = Article.Rows(0)("BOISSON")
                    Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")

                    Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If unite.Rows.Count > 0 Then

                        PETITE_UNITE = unite.Rows(0)("PETITE_UNITE")
                        GRANDE_UNITE = unite.Rows(0)("GRANDE_UNITE")
                        VALEUR_DE_CONVERSION = unite.Rows(0)("VALEUR_NUMERIQUE")

                        Dim OLD_VALUE As Double = VALEUR_ENTREE

                        '-------------------------------------------------------------------------------------------------------------------------------------------
                        Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                        If Trim(Article.Rows(0)("CODE_CONSO")).Equals("") Then
                            conso = Nothing
                        End If

                        If conso IsNot Nothing And BOISSON = 1 Then

                            If conso.Rows.Count > 0 And Article.Rows(0)("BOISSON") = 1 Then

                                'Dim QUANTITE_CONSO = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION
                                Dim valeurConversion As Double = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                                Dim contenance As Double = Article.Rows(0)("CONTENANCE")

                                Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                                If LIBELLE_UNITE = PETITE_UNITE Then

                                    QUANTITE_ENTREE = QUANTITE_ENTREE * nombreDeConsoDansUneBouteille
                                    QUANTITE_SORTIE = QUANTITE_SORTIE * nombreDeConsoDansUneBouteille
                                    VALEUR_SORTIE = VALEUR_SORTIE * nombreDeConsoDansUneBouteille
                                    VALEUR_ENTREE = VALEUR_ENTREE * nombreDeConsoDansUneBouteille

                                End If


                                If GlobalVariable.actualLanguageValue = 10 Then
                                    CODE_LOT = "SHOT"
                                Else
                                    CODE_LOT = "CONSOMMATION"
                                End If


                            End If

                        Else

                            If LIBELLE_UNITE = PETITE_UNITE Then

                                QUANTITE_ENTREE = QUANTITE_ENTREE '
                                QUANTITE_SORTIE = QUANTITE_SORTIE '
                                VALEUR_SORTIE = VALEUR_SORTIE '
                                VALEUR_ENTREE = VALEUR_ENTREE '

                            ElseIf LIBELLE_UNITE = GRANDE_UNITE Then

                                QUANTITE_ENTREE = QUANTITE_ENTREE * VALEUR_DE_CONVERSION
                                QUANTITE_SORTIE = QUANTITE_SORTIE * VALEUR_DE_CONVERSION
                                VALEUR_SORTIE = VALEUR_SORTIE * VALEUR_DE_CONVERSION
                                VALEUR_ENTREE = VALEUR_ENTREE * VALEUR_DE_CONVERSION

                            End If

                            CODE_LOT = PETITE_UNITE

                        End If
                        '----------------------------------------------------------------------------------------------
                    End If

                End If


                '------------------------------------------------------------------------------------------

                Dim ETAT_MOUVEMENT As String = ""
                Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                'GESTION DES LIGNES DE MOUVEMENT SSI NOUS GERONS LES BON DE RECEPTION VALIDE

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                If Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows.Count > 0 Then

                    If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then
                        QUANTITE_AVANT_MOVEMENT = Economat.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)
                    Else
                        QUANTITE_AVANT_MOVEMENT = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("QUANTITE")
                    End If

                    CMUP = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("PRIX_ACHAT_HT")

                End If

                'INSERTION DU MOVEMENT DE STOCK
                If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_BORDEREAUX, QUANTITE_AVANT_MOVEMENT, CMUP) Then


                    'MISE A JOURS DES QUANTITE D'ARTICLES lors des entrées en magasins DANS LE GAND MAGASIN

                    Dim CODE_SOURCE As String = CODE_ARTICLE
                    Dim TABLE_SOURCE As String = "article"
                    Dim QUANTITE_ARTICLE As Double = QUANTITE_ENTREE
                    Dim CODE_DESTINATION As String = ""

                    Dim infoMagasin As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

                    If infoMagasin.Rows.Count > 0 Then

                        If infoMagasin.Rows(0)("TYPE_MAGASIN").Equals("Magasin central") Then
                            If econom.gestionStockagesEtDeStockages(CODE_SOURCE, TABLE_SOURCE, QUANTITE_ARTICLE) Then

                            End If
                        End If

                    End If

                    'MISE A JOUR DU PRIX

                    econom.CoutMoyenUnitairePondereDunArticleQuelconque(CODE_ARTICLE)

                End If

            Next

            'Mise ajours du bon de commande ayant conduit au Bon de Réception pour que le bon de commande ne s'affiche plus lors de creation d'un bon de réception

            CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR = Trim(GunaTextBoxCodeBordereau.Text)

            ETAT_BORDEREAU = 6

            econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bordereau de reception validé avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Delivery slip successfully validated!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            TabControlEconomat.SelectedIndex = 1

            NewBonDeRequisition()

        ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then

            '-------------------------------------------------------------------------------------------------------------
            Dim COUT_DU_STOCK As Double = 0
            'Dim CODE_BORDEREAUX As String = Trim(GunaTextBoxCodeBordereau.Text)
            Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString

            Dim CODE_SOUS_MAGASIN As String = ""

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Then

                If GunaComboBoxMagasin_2.Items.Count >= 0 Then

                    If GunaComboBoxMagasin_2.DataSource IsNot Nothing Then
                        'CODE_SOUS_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
                        CODE_SOUS_MAGASIN = ""
                    End If

                End If

            ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie Then

                If GunaComboBoxMagasin_2.SelectedIndex >= 0 Then
                    CODE_SOUS_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
                End If

            End If

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

                'Defini plus bas selon si c'est une commande ou une reception
                Dim CODE_LOT As String = ""

                'Verif d'exitence de valeur pour le lot
                If GunaComboBoxListeDesLots.SelectedIndex >= 0 Then
                    'CODE_LOT = GunaComboBoxListeDesLots.SelectedValue.ToString
                End If

                Dim CODE_LIGNE As String = ""

                If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "SE")

                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then

                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BS")

                End If

                Dim CODE_ARTICLE As String = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("CODE ARTICLE").Value.ToString

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                Dim Article As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                If Article.Rows.Count > 0 Then

                    If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then
                        QUANTITE_AVANT_MOVEMENT = Economat.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)
                    Else
                        QUANTITE_AVANT_MOVEMENT = Article.Rows(0)("QUANTITE")
                    End If

                    CMUP = Article.Rows(0)("PRIX_ACHAT_HT")

                End If

                Dim qte As Double = 0

                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value, entre_en_stock)
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value, entre_en_stock)
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("STOCK").Value.ToString, qte)
                End If

                Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock 'QUANTITE EN MOVEMENT

                Dim DATE_PEREMPTION As Date

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                    DATE_PEREMPTION = GunaDateTimePickerDatePeremption.Value.ToShortDateString()
                End If

                Dim UNITE_UTILISE As String = ""
                CODE_LOT = UNITE_UTILISE
                Dim PRIX_UNITAIRE_HT As Double = 0 'PRIX UNITAIRE ACHAT
                Dim PRIX_UNITAIRE_TTC As Double = 0 'PRIX UNITAIRE VENTE
                Dim PRIX_TOTAL_HT As Double = 0 'PRIX TOTAL ACHAT
                Dim PRIX_TOTAL_TTC As Double = 0 'PRIX TOTAL VENTE
                Dim NUM_SERIE_DEBUT As String = ""
                Dim NUM_SERIE_FIN As String = ""

                If GlobalVariable.actualLanguageValue = 1 Then
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value
                    CODE_LOT = UNITE_UTILISE
                    PRIX_UNITAIRE_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX UNITAIRE").Value 'PRIX UNITAIRE ACHAT
                    PRIX_UNITAIRE_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value 'PRIX UNITAIRE VENTE
                    PRIX_TOTAL_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX UNITAIRE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL ACHAT
                    PRIX_TOTAL_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL VENTE
                    NUM_SERIE_DEBUT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value
                    NUM_SERIE_FIN = ""
                Else
                    UNITE_UTILISE = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value
                    CODE_LOT = UNITE_UTILISE
                    PRIX_UNITAIRE_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT PRICE").Value 'PRIX UNITAIRE ACHAT
                    PRIX_UNITAIRE_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value 'PRIX UNITAIRE VENTE
                    PRIX_TOTAL_HT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT PRICE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL ACHAT
                    PRIX_TOTAL_TTC = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value * QUANTITE_ENTREE_STOCK 'PRIX TOTAL VENTE
                    NUM_SERIE_DEBUT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value
                    NUM_SERIE_FIN = ""
                End If

                'NUM_SERIE_DEBUT : USED AS UNITE DE DESTOCKAGE UTILISE POUR LIGNE DE BORDEREAU

                '-------------------------- DEBUT TRAITEMENTS DE LIGNE DE MOUVEMENT FONCTION DE L'UNITE UTILISEE ------------------------------------------------
                Dim PETITE_UNITE As String = ""
                Dim GRANDE_UNITE As String = ""
                Dim LIBELLE_UNITE As String = UNITE_UTILISE '

                Dim VALEUR_DE_CONVERSION As Double = 1

                If Article.Rows.Count > 0 Then

                    Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")
                    Dim BOISSON As Integer = Article.Rows(0)("BOISSON")

                    Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If unite.Rows.Count > 0 Then

                        PETITE_UNITE = unite.Rows(0)("PETITE_UNITE")
                        GRANDE_UNITE = unite.Rows(0)("GRANDE_UNITE")
                        VALEUR_DE_CONVERSION = unite.Rows(0)("VALEUR_NUMERIQUE")

                        '-------------------------------------------------------------------------------------------------------------------------------------------
                        Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                        If Trim(Article.Rows(0)("CODE_CONSO")).Equals("") Then
                            conso = Nothing
                        End If

                        If conso IsNot Nothing And BOISSON = 1 Then

                            If conso.Rows.Count > 0 Then

                                'Dim QUANTITE_CONSO = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION
                                Dim valeurConversion As Double = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                                Dim contenance As Double = Article.Rows(0)("CONTENANCE")

                                Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                                If LIBELLE_UNITE = PETITE_UNITE Then
                                    entre_en_stock = entre_en_stock * nombreDeConsoDansUneBouteille
                                End If

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    CODE_LOT = "CONSOMMATION"
                                ElseIf GlobalVariable.actualLanguageValue = 0 Then
                                    CODE_LOT = "SHOT"
                                End If

                            End If

                        Else

                            If LIBELLE_UNITE = PETITE_UNITE Then
                                entre_en_stock = entre_en_stock '
                            ElseIf LIBELLE_UNITE = GRANDE_UNITE Then
                                entre_en_stock = entre_en_stock * VALEUR_DE_CONVERSION
                            End If

                            CODE_LOT = PETITE_UNITE

                        End If
                        '----------------------------------------------------------------------------------------------
                    End If

                End If

                '------------------------------------------------------------------------------------------------------------------------------------------------

                If GlobalVariable.actualLanguageValue = 1 Then
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                Else
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                End If
                'NUM_SERIE_DEBUT : USED AS UNITE D'ENTREE
                'Insertion des informations des lignes du bordereau
                If True Then

                    Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "MS")
                    Dim LIBELLE_MOUVEMENT As String = GunaComboBoxTypeBordereau.SelectedItem.ToString

                    Dim TYPE_MOUVEMENT As String = ""

                    Dim QUANTITE_ENTREE As Double = 0
                    Dim QUANTITE_SORTIE As Double = 0
                    Dim VALEUR_ENTREE As Double = 0
                    Dim VALEUR_SORTIE As String = 0

                    If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                        TYPE_MOUVEMENT = "Entrée en stock"
                        QUANTITE_ENTREE = entre_en_stock
                        VALEUR_ENTREE = QUANTITE_ENTREE
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then
                        TYPE_MOUVEMENT = "Sortie de stock"
                        QUANTITE_SORTIE = entre_en_stock
                        VALEUR_SORTIE = entre_en_stock
                    ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then
                        TYPE_MOUVEMENT = GlobalVariable.transfert_inter
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then
                        TYPE_MOUVEMENT = GlobalVariable.sortie_exceptionnelle
                        QUANTITE_SORTIE = entre_en_stock
                        VALEUR_SORTIE = entre_en_stock
                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then
                        TYPE_MOUVEMENT = GlobalVariable.entree_exceptionnelle
                        QUANTITE_ENTREE = entre_en_stock
                        VALEUR_ENTREE = QUANTITE_ENTREE
                    End If

                    Dim ETAT_MOUVEMENT As String = ""

                    Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                    'GESTION DES LIGNES DE MOUVEMENT SSI NOUS GERONS LES BON DE RECEPTION VALIDE CAR NOUS NE FAISON QUE NOUVELLEMENT ENREGISTRER UNE COMMANDE

                    'EN PARTANT DU PRINCIPE QUE: UNE SORTIE DIRECTE NE REQUIERT POINT DE VALIDATION

                    If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then

                        'EN CAS DE COSRTIE DIRECTE ON RECONVERTIE EN GRANDE UNITE

                        If LIBELLE_UNITE = PETITE_UNITE Then
                            ' QUANTITE_ENTREE = QUANTITE_ENTREE / VALEUR_DE_CONVERSION
                            'QUANTITE_SORTIE = QUANTITE_SORTIE / VALEUR_DE_CONVERSION
                            'VALEUR_ENTREE = VALEUR_ENTREE / VALEUR_DE_CONVERSION
                            'VALEUR_SORTIE = VALEUR_SORTIE / VALEUR_DE_CONVERSION
                        End If

                        If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_BORDEREAUX, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                            'MISE AJOURS DES QUANTITES EN STOCK APRES UNE SORTIE D'ARTICLE

                            'MISE A JOURS DES QUANTITE D'ARTICLES lors des entrées en magasins

                            Dim CODE_SOURCE As String = CODE_ARTICLE
                            Dim TABLE_SOURCE As String = "article"
                            Dim QUANTITE_ARTICLE As Double = QUANTITE_SORTIE * -1
                            Dim CODE_DESTINATION As String = ""

                            'ON NE DOIT QUE FAIRE LA MISE AJOURS DES QTES POUR LES ENTREES EN DIRECTION DU GRAND MAGASIN

                            Dim infoMagasin As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

                            If infoMagasin.Rows.Count > 0 Then

                                If infoMagasin.Rows(0)("TYPE_MAGASIN").Equals("Magasin central") Then

                                    If econom.gestionStockagesEtDeStockages(CODE_SOURCE, TABLE_SOURCE, QUANTITE_ARTICLE) Then

                                    End If

                                End If

                            End If

                        End If


                        'LA SORTIE SIMPLE IMPLIQUE L'ENTRE DANS UN AUTRE MAGASIN

                        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then

                            QUANTITE_ENTREE = VALEUR_SORTIE
                            QUANTITE_SORTIE = QUANTITE_SORTIE
                            VALEUR_SORTIE = 0
                            QUANTITE_SORTIE = 0
                            TYPE_MOUVEMENT = "Entrée en stock"

                            If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then
                                QUANTITE_AVANT_MOVEMENT = Economat.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_SOUS_MAGASIN, CODE_ARTICLE)
                            End If

                            econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_SOUS_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_BORDEREAUX, QUANTITE_AVANT_MOVEMENT, CMUP)

                        End If

                    End If

                End If

            Next
            '-------------------------------------------------------------------------------------------------------------

            CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR = GunaTextBoxCodeBordereau.Text

            econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

            Dim CODE_USER As String = GlobalVariable.codeUser

            econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

            Functions.SiplifiedClearTextBox(Me)

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bordereau de controlé avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Slip successfully controled", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            GunaDataGridViewLigneArticleCommande.Columns.Clear()

        ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

            For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

                Dim QUANTITE_ENTREE As Double = 0
                Dim QUANTITE_SORTIE As Double = 0
                Dim VALEUR_ENTREE As Double = 0
                Dim VALEUR_SORTIE As String = 0

                Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "MS")
                Dim LIBELLE_MOUVEMENT As String = GunaComboBoxTypeBordereau.SelectedItem.ToString
                Dim CODE_LIGNE As String = Functions.GeneratingRandomCodePanne("bordereaux", "TI")

                Dim CODE_ARTICLE As String = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("CODE ARTICLE").Value.ToString

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                If Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows.Count > 0 Then

                    If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 0 Then
                        QUANTITE_AVANT_MOVEMENT = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("QUANTITE")
                    End If

                    CMUP = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("PRIX_ACHAT_HT")

                End If

                Dim qte As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("STOCK").Value.ToString, qte)
                End If

                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value.ToString, entre_en_stock)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value.ToString, entre_en_stock)
                End If

                Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock 'QUANTITE EN MOVEMENT

                Dim DATE_PEREMPTION As Date

                Dim TYPE_MOUVEMENT As String = GlobalVariable.transfert_inter

                '------------------------------------
                Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail
                Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString

                Dim CODE_SOUS_MAGASIN As String = ""

                If GunaComboBoxMagasin_2.DataSource IsNot Nothing Then

                    If GunaComboBoxMagasin_2.Items.Count >= 0 Then
                        CODE_SOUS_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
                    End If

                End If

                'Dim CODE_BORDEREAUX As String = GunaTextBoxCodeBordereau.Text
                Dim ETAT_MOUVEMENT As Integer = 0

                Dim CODE_LOT As String = ""

                If GlobalVariable.actualLanguageValue = 1 Then
                    CODE_LOT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value.ToString
                Else
                    CODE_LOT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value.ToString
                End If
                '---------------------------------------

                'Pour un Transfert inter magasin on doit:

                '1- Retrancher les quantités en mouvement du magasin de provenance (source-depart) : pour équilibrer les quantités du magasin source
                QUANTITE_ENTREE = 0
                VALEUR_ENTREE = 0
                QUANTITE_SORTIE = entre_en_stock
                VALEUR_SORTIE = entre_en_stock

                Dim infoMagasin As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

                If infoMagasin.Rows.Count > 0 Then

                    If infoMagasin.Rows(0)("TYPE_MAGASIN").Equals("Magasin central") Then

                        Dim CODE_SOURCE As String = CODE_ARTICLE
                        Dim TABLE_SOURCE As String = "article"

                        If econom.gestionStockagesEtDeStockages(CODE_SOURCE, TABLE_SOURCE, entre_en_stock) Then

                        End If

                    End If

                End If

                QUANTITE_AVANT_MOVEMENT = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)

                If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_BORDEREAUX, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                End If

                '2- Ajouter les quantité en mouvement dans le magasin de destinations (destination-arrive): pour équilibrer les quantités du magasin source
                CODE_MOUVEMENT = Functions.GeneratingRandomCode("mouvement_stock", "MS")
                QUANTITE_ENTREE = entre_en_stock
                VALEUR_ENTREE = entre_en_stock
                QUANTITE_SORTIE = 0
                VALEUR_SORTIE = 0

                QUANTITE_AVANT_MOVEMENT = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_SOUS_MAGASIN, CODE_ARTICLE)

                If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_SOUS_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_BORDEREAUX, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                End If

                'POUR CHAQUE LIGNE DE MOUVEMENT LA QUANTITE SERA DONE PAR : QUANTITE_ENTREE - QUANTITE_SORTIE

            Next

            ETAT_BORDEREAU = 1

            Dim CODE_BORDEREAUX_A_METTRE_AJOUR As String = GunaTextBoxCodeBordereau.Text

            econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_A_METTRE_AJOUR, ETAT_BORDEREAU)

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Transfert inter magasin réalisé avec succès !!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Inter Store Transfer successfully saved !!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            GunaDataGridViewLigneArticleCommande.Columns.Clear()

            Functions.SiplifiedClearTextBox(Me)

        End If

        GunaButtonController.Visible = False
        GunaButtonEnregistrer.Visible = False

        Me.Cursor = Cursors.Default

        TabControlEconomat.SelectedIndex = 0

    End Sub

    Private Sub ToolStripMenuItem105_Click(sender As Object, e As EventArgs)
        FournisseurForm.Show()
    End Sub

    '1- LOT TAB

    Public Sub emptyEconomatField()

        GunaTextBoxCodeLot.Clear()
        GunaTextBoxLibelleLot.Clear()
        GunaTextBoxCommentaire.Clear()

    End Sub

    'Enregistrement et sauvegarde de lot
    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerLot.Click

        Dim economat As New Economat()

        Dim CODE_LOT As String = Functions.GeneratingRandomCode("lot", "")
        Dim LIBELLE_LOT As String = GunaTextBoxLibelleLot.Text
        Dim COMMENTAIRE As String = GunaTextBoxCommentaire.Text

        If Trim(GunaButtonEnregistrerLot.Text) = "Sauvegarder" Or Trim(GunaButtonEnregistrerLot.Text) = "Update" Then

            CODE_LOT = GunaTextBoxCodeLot.Text

            If economat.updateLot(CODE_LOT, LIBELLE_LOT, COMMENTAIRE) Then
                MessageBox.Show("Lot mis à jours avec succès  ", "Gestion de lot", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        ElseIf Trim(GunaButtonEnregistrerLot.Text) = "Enregistrer" Or Trim(GunaButtonEnregistrerLot.Text) = "Save" Then

            If economat.insertLot(CODE_LOT, LIBELLE_LOT, COMMENTAIRE) Then
                MessageBox.Show("Lot ajouté avec succès  ", "Gestion de lot", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        emptyEconomatField()

        'Remplissage de la Liste des lots pour rafraichissement
        GunaDataGridViewListeDesLots.DataSource = Functions.allTableFieldsOrganised("lot", "LIBELLE_LOT")

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

        Dim table As DataTable = Functions.allTableFieldsOrganised("magasin", "LIBELLE_MAGASIN")

        If (table.Rows.Count > 0) Then

            GunaComboBoxMagasin_1.DataSource = table
            GunaComboBoxMagasin_1.ValueMember = "CODE_MAGASIN"
            GunaComboBoxMagasin_1.DisplayMember = "LIBELLE_MAGASIN"

        End If

    End Sub

    Sub AutoLoadlisteMagasinDestination()

        Dim table As DataTable = Functions.allTableFieldsOrganised("magasin", "LIBELLE_MAGASIN")

        If (table.Rows.Count > 0) Then

            GunaComboBoxMagasin_2.DataSource = table
            GunaComboBoxMagasin_2.ValueMember = "CODE_MAGASIN"
            GunaComboBoxMagasin_2.DisplayMember = "LIBELLE_MAGASIN"

        End If

    End Sub

    'Modifier le lot
    Private Sub GunaDataGridViewListeDesLots_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewListeDesLots.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrerLot.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewListeDesLots.Rows(e.RowIndex)

            Dim lot As DataTable = Functions.getElementByCode(row.Cells("CODE_LOT").Value.ToString, "lot", "CODE_LOT")

            If lot.Rows.Count > 0 Then

                GunaTextBoxCodeLot.Text = lot.Rows(0)("CODE_LOT")
                GunaTextBoxLibelleLot.Text = lot.Rows(0)("LIBELLE_LOT")
                GunaTextBoxCommentaire.Text = lot.Rows(0)("COMMENTAIRE")

            Else


            End If

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

            GunaTextBoxPlusBasPrix.Clear()
            GunaTextBoxPlusHautPrix.Clear()
            GunaTextBoxQtePetiteUnite.Text = 0
            GunaComboBoxUniteOuConso.Items.Clear()

            GunaTextBoxGrandeUniteDeCompatge.Clear()

            GunaTextBoxQteGrdeUnite.Text = 0

            GunaTextBoxSeuile.Text = 0

            GunaTextBoxCoutDuStock.Text = 0

            GunaTextBoxQuantite.Text = 1

            LabelPteUnite.Visible = True
            GunaTextBoxQtePetiteUnite.Visible = True

            LabelGrdeUnite.Visible = False
            GunaTextBoxQteGrdeUnite.Visible = False

            GunaDataGridViewArticle.Visible = False
            GunaButtonAjouterLigne.Visible = False

            LabelQteEnMagasinDeDestination.Visible = False
            GunaTextBoxQunatiteDansLeMagasinDestination.Visible = False

            GunaTextBoxQunatiteDansLeMagasinProvenance.Clear()

            LabelQuantiteEnMagasinSource.Visible = True
            GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonAjouterLigne.Text = "Add"
                LabelPteUnite.Text = "Small Unit Qty"
                LabelGrdeUnite.Text = "Big Unit Qty"
            Else
                GunaButtonAjouterLigne.Text = "Ajouter"
                LabelPteUnite.Text = "Qte Pte Unité"
                LabelGrdeUnite.Text = "Qte Gde Unité"
            End If

        End If

        'Determining from which table to search for the articles

        If GunaTextBoxSuivreArticleNonSuivi.Text = "OUI" Then
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND METHODE_SUIVI_STOCK=@METHODE_SUIVI_STOCK OR DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND METHODE_SUIVI_STOCK=@METHODE_NON_SUIVI_STOCK AND CARTE =@CARTE ORDER BY DESIGNATION_FR ASC"
        Else
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND METHODE_SUIVI_STOCK=@METHODE_SUIVI_STOCK AND CARTE =@CARTE ORDER BY DESIGNATION_FR ASC"
        End If

        'getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY  ORDER BY DESIGNATION_FR ASC"

        Dim METHODE_NON_SUIVI_STOCK As String = "Non Suivi"

        Dim METHODE_SUIVI_STOCK As String = "Suivi simple"

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
    Private Sub GunaDataGridViewArticle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticle.CellClick
        'GunaComboBoxMagasinDeDestination
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

            Dim CODE_MAGASIN As String = ""
            Dim CODE_ARTCLE As String = ""

            CODE_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString

            Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

            If Article.Rows.Count > 0 Then

                GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")

                CODE_ARTCLE = Article.Rows(0)("CODE_ARTICLE")

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie Then

                    LabelQuantiteEnMagasinSource.Visible = True
                    LabelQteEnMagasinDeDestination.Visible = True
                    GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True
                    GunaTextBoxQunatiteDansLeMagasinDestination.Visible = True
                    GunaTextBoxQunatiteDansLeMagasinDestination.Visible = True

                    LabelQteEnMagasinDeDestination.Visible = True

                    LabelQuantiteEnMagasinSource.Visible = True

                    GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True

                    GunaTextBoxQunatiteDansLeMagasinDestination.Visible = True

                    Dim CODE_SOUS_MAGASIN As String = GunaComboBoxMagasin_2.SelectedValue.ToString

                    GunaTextBoxQunatiteDansLeMagasinDestination.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_SOUS_MAGASIN, CODE_ARTCLE)

                Else

                    If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then
                        GunaComboBoxMagasin_2.Visible = True
                        GunaLabelMagasin_2.Visible = True

                        '------------------------------------------------



                        '------------------------------------------------

                    Else
                        LabelQteEnMagasinDeDestination.Visible = False
                        GunaComboBoxMagasin_2.Visible = False
                        LabelQuantiteEnMagasinSource.Visible = False
                        GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False
                        GunaLabelMagasin_2.Visible = False
                    End If

                End If

                GunaTextBoxAchat.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") 'PRIX D'ACHAT UNITAIRE
                GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0") 'COUT MOYEN UNITAIRE PONDERE
                GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxSeuile.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")
                GunaTextBoxQteGrdeUnite.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.00")
                GunaTextBoxCodeUniteComptage.Text = Article.Rows(0)("UNITE_COMPTAGE")

                GunaTextBoxCoutDuStock.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") ' PRIX UNITAIRE A L'ACHAT

                Dim unite As DataTable = Functions.getElementByCode(GunaTextBoxCodeUniteComptage.Text, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If unite.Rows.Count > 0 Then

                    gestionDesUnites(Article)

                    GunaComboBoxUniteOuConso.SelectedIndex = -1

                End If

                Dim QUANTITE_DU_MAGASIN_ACTUEL

                If gestionDesStock = 0 Then
                    QUANTITE_DU_MAGASIN_ACTUEL = Article.Rows(0)("QUANTITE")
                    GunaTextBoxQunatiteDansLeMagasinProvenance.Text = 0
                ElseIf gestionDesStock = 1 Then
                    QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTCLE)
                    GunaTextBoxQunatiteDansLeMagasinProvenance.Text = QUANTITE_DU_MAGASIN_ACTUEL
                End If

                'If Not Trim(GunaTextBoxQteGrdeUnite.Text) = "" Then

                If unite.Rows.Count > 0 Then

                    Dim nombreDeGrandeUnite As Double = 0
                    Dim nombreDePetiteUnite As Integer = 0
                    Dim nombreTotalDePetiteUnite As Double = QUANTITE_DU_MAGASIN_ACTUEL

                    Dim VALEUR_DE_CONVERSION = unite.Rows(0)("VALEUR_NUMERIQUE")

                    If VALEUR_DE_CONVERSION > 1 Then

                        If nombreTotalDePetiteUnite > 0 Then
                            nombreDeGrandeUnite = Int(nombreTotalDePetiteUnite / VALEUR_DE_CONVERSION)
                            nombreDePetiteUnite = nombreTotalDePetiteUnite Mod VALEUR_DE_CONVERSION
                        End If

                        GunaTextBoxQteGrdeUnite.Text = Format(nombreDeGrandeUnite, "#,##0.00")
                        GunaTextBoxSeuile.Text = Format(Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT"), "#,##0.0")
                        GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0")

                        GunaTextBoxQtePetiteUnite.Text = Format(nombreDePetiteUnite, "#,##0.0")

                        LabelPteUnite.Visible = True
                        GunaTextBoxQtePetiteUnite.Visible = True

                        LabelGrdeUnite.Visible = True
                        GunaTextBoxQteGrdeUnite.Visible = True

                        LabelPteUnite.Text = unite.Rows(0)("PETITE_UNITE").ToString.ToString()
                        LabelGrdeUnite.Text = unite.Rows(0)("GRANDE_UNITE").ToString.ToString()

                    Else

                        If Integer.Parse(Article.Rows(0)("BOISSON")) = 1 Then

                            Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                            If Trim(Article.Rows(0)("CODE_CONSO")).Equals("") Then
                                conso = Nothing
                            End If

                            If conso.Rows.Count > 0 Then

                                Dim nombreDeBouteille As Integer = 0
                                Dim nombreDeConso As Integer = 0
                                Dim nombreDeConsoTotal As Double = QUANTITE_DU_MAGASIN_ACTUEL

                                Dim contenance As Double = Article.Rows(0)("CONTENANCE")
                                Dim valeurConversion = conso.Rows(0)("VALEUR_NUMERIQUE")
                                Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                                If nombreDeConsoDansUneBouteille > 0 Then
                                    nombreDeBouteille = Int(nombreDeConsoTotal / nombreDeConsoDansUneBouteille)
                                    nombreDeConso = nombreDeConsoTotal Mod nombreDeConsoDansUneBouteille
                                End If

                                LabelPteUnite.Visible = True
                                GunaTextBoxQtePetiteUnite.Visible = True

                                LabelGrdeUnite.Visible = True
                                GunaTextBoxQteGrdeUnite.Visible = True

                                GunaTextBoxQteGrdeUnite.Text = nombreDeBouteille
                                GunaTextBoxQtePetiteUnite.Text = nombreDeConso 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                                LabelGrdeUnite.Text = unite.Rows(0)("PETITE_UNITE").ToString.ToString()
                                LabelPteUnite.Text = "CONSO"
                                GunaComboBoxUniteOuConso.Items.Add("CONSOMMATION")

                            End If

                        Else

                            'SI NON
                            GunaTextBoxQteGrdeUnite.Text = Format(0, "#,##0.00")
                            GunaTextBoxSeuile.Text = Format(Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT"), "#,##0.0")
                            GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0")
                            GunaTextBoxQtePetiteUnite.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0.0")

                            LabelPteUnite.Visible = True
                            GunaTextBoxQtePetiteUnite.Visible = True

                            LabelGrdeUnite.Visible = False
                            GunaTextBoxQteGrdeUnite.Visible = False

                            LabelGrdeUnite.Text = unite.Rows(0)("PETITE_UNITE").ToString.ToString()

                        End If

                    End If

                End If

                GunaComboBoxUniteOuConso.SelectedItem = unite.Rows(0)("PETITE_UNITE").ToString.ToString()

                GunaDataGridViewArticle.Visible = False

                LabelQuantiteEnMagasinSource.Visible = True
                GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True

                Dim BAS_PRIX As Integer = 0
                Dim HAUT_PRIX As Integer = 1

                Dim econo As New Economat

                GunaTextBoxPlusBasPrix.Text = Format(econo.historiquesArticlePlusHautBasPrix(CODE_ARTCLE, BAS_PRIX), "#,##0")
                GunaTextBoxPlusHautPrix.Text = Format(econo.historiquesArticlePlusHautBasPrix(CODE_ARTCLE, HAUT_PRIX), "#,##0")

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid

            End If

            'connect.closeConnection()

            If GunaComboBoxTypeBordereau.Enabled Then
                GunaButtonAjouterLigne.Visible = True
            Else

                Dim ETAT_BORDEREAU As Integer = -1

                If Not Trim(GunaTextBoxEtatBordereau.Text).Equals("") Then
                    ETAT_BORDEREAU = GunaTextBoxEtatBordereau.Text
                End If

                'ON PEUT AJOUTER SI ON N'A PAS ENCORE CONTROLE
                If ETAT_BORDEREAU = 0 Then

                    If GunaComboBoxTypeBordereau.SelectedIndex = 1 Or GunaComboBoxTypeBordereau.SelectedIndex = 0 Or GunaComboBoxTypeBordereau.SelectedIndex = 3 Or GunaComboBoxTypeBordereau.SelectedIndex = 4 Or GunaComboBoxTypeBordereau.SelectedIndex = 6 Or GunaComboBoxTypeBordereau.SelectedIndex = 7 Or GunaComboBoxTypeBordereau.SelectedIndex = 8 Or GunaComboBoxTypeBordereau.SelectedIndex = 10 Then
                        GunaButtonAjouterLigne.Visible = True
                    End If

                Else
                    GunaButtonAjouterLigne.Visible = False
                End If

            End If

        End If

    End Sub

    Dim montantGlobalAchat As Double = 0
    Dim montantGlobalVente As Double = 0

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

        If GunaButtonAjouterLigne.Text = "Modifier" Or GunaButtonAjouterLigne.Text = "Update" Then

            ID_LIGNE_BORDEREAU = GunaTextBoxID_LIGNE_TEMP.Text

            CODE_BORDEREAUX = Trim(GunaTextBoxCodeBordereau.Text)
            'modification des élemenets ou ligne du bordereau

            '0' - On supprime l'ancienne occurence de l'article
            CODE_ARTICLE = GunaTextBoxCodeArticle.Text

            GunaTextBoxTVARecap.Text = CODE_ARTICLE

            'On supprime les lignes existantes pour prendre en compte d'eventuelle mise a jour sans risque de doublons

            Functions.DeleteElementByCode(ID_LIGNE_BORDEREAU, "bordereau_ligne_temp", "ID_LIGNE_BORDEREAU")

            Functions.DeleteElementOnTwoConditions(CODE_BORDEREAUX, "ligne_bordereaux", "CODE_BORDEREAUX", "CODE_ARTICLE", CODE_ARTICLE)

            '1- on charge le contenu actuel du datagrid dans ligne bordereau temp

            Dim elementDeBordoro As DataTable = econom.ArticleDunBordereauQuelconque(CODE_BORDEREAUX, "ligne_bordereaux")

            If elementDeBordoro.Rows.Count > 0 Then

                For i = 0 To elementDeBordoro.Rows.Count - 1

                    DESIGNATION = elementDeBordoro.Rows(i)("DESIGNATION")
                    CODE_ARTICLE = elementDeBordoro.Rows(i)("CODE ARTICLE")
                    QUANTITE = elementDeBordoro.Rows(i)("QUANTITE")
                    EN_STOCK = elementDeBordoro.Rows(i)("EN STOCK")
                    'DATE_PEREMPTION = elementDeBordoro.Rows(i)("DATE DE PEREMPTION")
                    PRIX_VENTE = elementDeBordoro.Rows(i)("PRIX VENTE")
                    PRIX_ACHAT = elementDeBordoro.Rows(i)("PRIX UNITAIRE") ' PRIX ACHAT
                    COUT_DU_STOCK = elementDeBordoro.Rows(i)("PRIX TOTAL")

                    Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "bordereau_ligne_temp", "CODE_ARTICLE", "CODE_USER", CODE_USER)

                    If Not Trim(GunaTextBoxCodeBordereau.Text) = "" Then
                        Functions.DeleteElementOnTwoConditions(CODE_BORDEREAUX, "ligne_bordereaux", "CODE_BORDEREAUX", "CODE_ARTICLE", CODE_ARTICLE)
                    End If

                    Dim UNITE_UTILISE As String = GunaComboBoxUniteOuConso.SelectedItem

                    econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_UTILISE, CODE_USER, COUT_DU_STOCK)

                Next

            End If

            '2 on ajoute l'element nouvellement saisie dans bordereau_ligne_temp
            CODE_BORDEREAUX = GunaTextBoxCodeBordereau.Text
            UNITE_COMPTAGE = GunaComboBoxUniteOuConso.SelectedItem
            DESIGNATION = GunaTextBoxArticle.Text
            CODE_ARTICLE = GunaTextBoxCodeArticle.Text
            QUANTITE = Double.Parse(GunaTextBoxQuantite.Text)
            EN_STOCK = Double.Parse(GunaTextBoxQteGrdeUnite.Text)
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
            GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElementsSuivantBordoro(GlobalVariable.codeAgence, CODE_BORDEREAUX)

            'econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterLigne.Text = "Ajouter"
            Else
                GunaButtonAjouterLigne.Text = "Add"
            End If

        Else
            'Nouveau bordereau

            'En cas de transfert inter magasin on doit vérifier que la quantité à transferer est en quantité suffisante
            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

                Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString
                Dim CODE_ARTCLE As String = GunaTextBoxCodeArticle.Text

                Dim quantiteEnStock As Double = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTCLE)

                'Si la qte  à ajouter est inférieur ou égale à la quantité du stock dans le dit magasin alors on l'ajoute au bordereau
                If Not Double.Parse(GunaTextBoxQuantite.Text) <= quantiteEnStock Then

                    CODE_BORDEREAUX = GunaTextBoxCodeBordereau.Text
                    UNITE_COMPTAGE = GunaComboBoxUniteOuConso.SelectedItem
                    DESIGNATION = GunaTextBoxArticle.Text
                    CODE_ARTICLE = GunaTextBoxCodeArticle.Text
                    QUANTITE = Double.Parse(GunaTextBoxQuantite.Text)
                    EN_STOCK = Double.Parse(GunaTextBoxQteGrdeUnite.Text)
                    DATE_PEREMPTION = dateDatePeremption
                    PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
                    PRIX_ACHAT = Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
                    CODE_AGENCE = GlobalVariable.codeAgence
                    CODE_USER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                    COUT_DU_STOCK = Double.Parse(GunaTextBoxCoutDuStock.Text)

                    econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)

                    GunaDataGridViewLigneArticleCommande.Columns.Clear()

                    GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElementsSuivantBordoro(GlobalVariable.codeAgence, CODE_BORDEREAUX)

                End If

            Else

                CODE_BORDEREAUX = GunaTextBoxCodeBordereau.Text
                UNITE_COMPTAGE = GunaComboBoxUniteOuConso.SelectedItem
                DESIGNATION = GunaTextBoxArticle.Text
                CODE_ARTICLE = GunaTextBoxCodeArticle.Text
                QUANTITE = Double.Parse(GunaTextBoxQuantite.Text)
                EN_STOCK = Double.Parse(GunaTextBoxQteGrdeUnite.Text)
                DATE_PEREMPTION = dateDatePeremption

                If Trim(GunaTextBoxPrixVente.Text) = "" Then
                    GunaTextBoxPrixVente.Text = 1
                End If

                If Trim(GunaTextBoxQuantite.Text) = "" Then
                    GunaTextBoxQuantite.Text = 1
                End If

                'PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
                PRIX_VENTE = Double.Parse(GunaTextBoxPrixVente.Text)
                'PRIX_ACHAT = Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text)
                PRIX_ACHAT = Double.Parse(GunaTextBoxAchat.Text)

                CODE_AGENCE = GlobalVariable.codeAgence
                CODE_USER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                Dim coutDuStock As Double = 0

                If Trim(GunaTextBoxCoutDuStock.Text) = "" Then
                    GunaTextBoxCoutDuStock.Text = 0
                End If

                Double.TryParse(GunaTextBoxCoutDuStock.Text, coutDuStock)

                If GunaCheckBoxPUOuPT.Checked Then
                    COUT_DU_STOCK = coutDuStock * QUANTITE
                Else
                    COUT_DU_STOCK = coutDuStock

                    If QUANTITE > 0 Then
                        PRIX_ACHAT = COUT_DU_STOCK / QUANTITE
                    End If
                End If

                econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)

                GunaDataGridViewLigneArticleCommande.Columns.Clear()

                GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElementsSuivantBordoro(GlobalVariable.codeAgence, CODE_BORDEREAUX)

            End If

        End If

        If GlobalVariable.actualLanguageValue = 1 Then

            GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0.0"
            GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").Visible = False '

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False 'false

            GunaDataGridViewLigneArticleCommande.Columns("DESIGNATION").ReadOnly = True '
            GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").ReadOnly = True
            GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").ReadOnly = True

        Else

            GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Format = "#,##0.0"
            GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0.0"
            GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False '

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False 'false

            GunaDataGridViewLigneArticleCommande.Columns("DESIGNATION").ReadOnly = True '
            GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").ReadOnly = True
            GunaDataGridViewLigneArticleCommande.Columns("STOCK").ReadOnly = True

        End If

        GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False 'false

        GunaTextBoxArticle.Clear()
        GunaButtonAjouterLigne.Visible = False

        montantGlobalAchat = 0
        montantGlobalVente = 0

        For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

            If GlobalVariable.actualLanguageValue = 1 Then
                montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value
            Else
                montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value

            End If

        Next

        GunaTextBoxMontantHTGeneralAchat.Text = Format(montantGlobalAchat, "#,##0")

        GunaTextBoxMontantTTCGeneralVente.Text = Format(montantGlobalVente, "#,##0")

        GunaTextBoxQuantite.Text = 1
        GunaTextBoxPrixVente.Text = 0
        GunaTextBoxAchat.Text = 0

        montantGlobalAchat = 0
        montantGlobalVente = 0

        GunaTextBoxSeuile.Text = 0
        GunaTextBoxQteGrdeUnite.Text = 0
        GunaTextBoxCoutDuStock.Text = 0

        GunaTextBoxGrandeUniteDeCompatge.Clear()

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

            LabelQuantiteEnMagasinSource.Visible = False
            LabelQteEnMagasinDeDestination.Visible = False
            GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False
            GunaTextBoxQunatiteDansLeMagasinDestination.Visible = False

        End If

        GunaTextBoxPlusBasPrix.Clear()
        GunaTextBoxPlusHautPrix.Clear()

    End Sub

    'appuarution du second magasin en cas de transfert inter magain
    Private Sub GunaComboBoxTypeBordereau_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeBordereau.SelectedIndexChanged

        'NewBonDeRequisition()

        Dim econom As New Economat()

        'TRANSFERT INTER MAGASIN / 'SORTIE DIRECTE
        If GunaComboBoxTypeBordereau.SelectedIndex = 6 Or GunaComboBoxTypeBordereau.SelectedIndex = 3 Then

            GunaLabelMagasin_2.Visible = True
            GunaComboBoxMagasin_2.Visible = True

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_2.Text = "Magasin de Réception"
                GunaLabelMagasin_1.Text = "Magasin de Provenance"
            Else
                GunaLabelMagasin_2.Text = "Receiving Store"
                GunaLabelMagasin_1.Text = "Source Store"
            End If

            If GunaComboBoxTypeBordereau.SelectedIndex = 6 Then
                LabelQteEnMagasinDeDestination.Visible = True
                GunaTextBoxQunatiteDansLeMagasinDestination.Visible = True
            End If

        Else

            GunaLabelMagasin_2.Visible = False
            GunaComboBoxMagasin_2.Visible = False

            LabelQteEnMagasinDeDestination.Visible = False

            GunaTextBoxQunatiteDansLeMagasinDestination.Visible = False

        End If

        PanelGestionLot.Visible = False

        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        If Not firstLoad Then
            econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)
        End If

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaButtonEnregistrer.Text = "Save"
        Else
            GunaButtonEnregistrer.Text = "Enregistrer"
        End If

        'Functions.SiplifiedClearTextBox(Me)

        GunaTextBoxSeuile.Text = 0

        GunaTextBoxQteGrdeUnite.Text = 0

        GunaTextBoxQuantite.Text = 1

        GunaTextBoxGrandeUniteDeCompatge.Clear()

        'DETERMINONS LES MAGASINS A AFFICHER RECEPTION ET/OU PROVENANCE

        Dim CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION As String = ""
        Dim CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE As String = ""


        If GunaComboBoxTypeBordereau.SelectedIndex = 1 Then

            'LabelBon.Text = "BON DE REQUISITION"
            LabelBon.Text = GlobalVariable.bon_requisition.ToUpper()

            GunaDataGridViewInventaire.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin de Réception"
            Else
                GunaLabelMagasin_1.Text = "Receiving Store"
            End If

            If GlobalVariable.actualLanguageValue = 10 Then
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Main storage"
            Else
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Magasin central"
            End If

            magasinSourceOuDeRecetionAAfficher(CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION, CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE)

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 3 Then

            LabelBon.Text = GlobalVariable.sortie.ToUpper()

            GunaDataGridViewInventaire.Visible = False

            'GunaLabelMagasin_1.Text = "Magasin de Provenance"
            'GunaLabelMagasin_2.Text = "Magasin de Réception"

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_2.Text = "Magasin de Réception"
                GunaLabelMagasin_1.Text = "Magasin de Provenance"
            Else
                GunaLabelMagasin_2.Text = "Receiving Store"
                GunaLabelMagasin_1.Text = "Source Store"
            End If

            If GlobalVariable.actualLanguageValue = 10 Then
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Main storage"
                CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE = "small storage"
            Else
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Magasin central"
                CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE = "Petit magasin"
            End If

            magasinSourceOuDeRecetionAAfficher(CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION, CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE)

            LabelQteEnMagasinDeDestination.Visible = True
            GunaTextBoxQunatiteDansLeMagasinDestination.Visible = True

            If Not Trim(GunaTextBoxCodeArticle.Text).Equals("") Then

                Dim CODE_ARTICLE As String = GunaTextBoxCodeArticle.Text

                Dim infoSupArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                If infoSupArticle.Rows.Count > 0 Then

                    If GunaComboBoxMagasin_2.DataSource IsNot Nothing Then

                        If GunaComboBoxMagasin_2.SelectedIndex >= 0 Then
                            Dim CODE_SOUS_MAGASIN As String = GunaComboBoxMagasin_2.SelectedValue.ToString
                            GunaTextBoxQunatiteDansLeMagasinDestination.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_SOUS_MAGASIN, CODE_ARTICLE)
                        End If

                    Else

                    End If

                    If GunaComboBoxMagasin_1.DataSource IsNot Nothing Then

                        If GunaComboBoxMagasin_1.SelectedIndex >= 0 Then
                            Dim CODE_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString
                            GunaTextBoxQunatiteDansLeMagasinProvenance.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)
                        End If

                    End If

                End If

            End If

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 2 Then

            LabelBon.Text = GlobalVariable.inventaire.ToUpper()

            GunaDataGridViewInventaire.BringToFront()
            GunaDataGridViewInventaire.Visible = True

            Dim CODE_MAGASIN As String = ""

            If GunaComboBoxMagasin_1.Items.Count > 0 Then
                CODE_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString
            End If

            inventaireDesArticles(CODE_MAGASIN)

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin d'Inventaire"
            Else
                GunaLabelMagasin_1.Text = "Inventory Store"
            End If

            AutoLoadlisteMagasinSource()

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 4 Then

            LabelBon.Text = GlobalVariable.sortie_exceptionnelle

            GunaDataGridViewInventaire.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin de Provenance"
            Else
                GunaLabelMagasin_1.Text = "Source Store"
            End If

            GunaComboBoxMagasin_1.DataSource = Nothing

            AutoLoadlisteMagasinSource()

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 7 Then

            LabelBon.Text = GlobalVariable.entree_exceptionnelle.ToUpper()

            GunaDataGridViewInventaire.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin de Réception"
            Else
                GunaLabelMagasin_1.Text = "Receiving Store"
            End If

            AutoLoadlisteMagasinSource()

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 8 Then

            LabelBon.Text = GlobalVariable.bon_approvisi.ToUpper()

            GunaDataGridViewInventaire.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin de Réception"
            Else
                GunaLabelMagasin_1.Text = "Receiving Store"
            End If

            If GlobalVariable.actualLanguageValue = 10 Then
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "small storage"
                CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE = "Main storage"
            Else
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Petit magasin"
                CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE = "Magasin central"
            End If

            magasinSourceOuDeRecetionAAfficher(CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION, CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE)

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 0 Then

            LabelBon.Text = GlobalVariable.bon_reception.ToUpper()

            GunaDataGridViewInventaire.Visible = False

            If GlobalVariable.actualLanguageValue = 10 Then
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Main storage"
            Else
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Magasin central"
            End If

            magasinSourceOuDeRecetionAAfficher(CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION, CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE)

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin de Réception"
            Else
                GunaLabelMagasin_1.Text = "Receiving Store"
            End If

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 6 Then

            LabelBon.Text = GlobalVariable.transfert_inter.ToUpper()

            GunaDataGridViewInventaire.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin de Provenance"
                GunaLabelMagasin_2.Text = "Magasin de Réception"
            Else
                GunaLabelMagasin_1.Text = "Source Store"
                GunaLabelMagasin_2.Text = "Receiving Store"
            End If

            If GlobalVariable.actualLanguageValue = 10 Then
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Main storage"
                CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE = "small storage"
            Else
                CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION = "Magasin central"
                CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE = "Petit magasin"
            End If

            magasinSourceOuDeRecetionAAfficher(CODE_MAGASIN_OU_TYPE_MAGASIN_RECETION, CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE)

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 9 Then

            LabelBon.Text = GlobalVariable.bon_cmd.ToUpper()

            GunaDataGridViewInventaire.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin de Réception"
            Else
                GunaLabelMagasin_1.Text = "Receiving Store"
            End If

            GunaComboBoxMagasin_1.DataSource = Nothing
            GunaComboBoxMagasin_2.DataSource = Nothing

        ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 10 Then

            LabelBon.Text = GlobalVariable.list_du_marche.ToUpper

            GunaDataGridViewInventaire.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelMagasin_1.Text = "Magasin de Réception"
            Else
                GunaLabelMagasin_1.Text = "Receiving Store"
            End If

            AutoLoadlisteMagasinSource()

            GunaDateTimePickerP1LM.Value = GlobalVariable.DateDeTravail
            GunaDateTimePickerP1LM.MinDate = GlobalVariable.DateDeTravail
            GunaDateTimePickerP1LM.MaxDate = GlobalVariable.DateDeTravail.AddDays(7)
            GunaDateTimePickerP2LM.MinDate = GlobalVariable.DateDeTravail
            GunaDateTimePickerP2LM.Value = GlobalVariable.DateDeTravail.AddDays(7)

        End If

        If GunaComboBoxTypeBordereau.SelectedIndex = 6 Or GunaComboBoxTypeBordereau.SelectedIndex = 0 Then

            Dim infoSupBordereau As DataTable = Functions.getElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

            'ON NE DOIT PAS OUVRIR LE CHAMP SI LE BORDEREAU EAST ENREGISTRE

            If infoSupBordereau.Rows.Count > 0 Then
                GunaTextBoxReference.Enabled = False
                GunaTextBoxReference.BaseColor = Color.Gainsboro
            Else
                GunaTextBoxReference.Enabled = True
                GunaTextBoxReference.BaseColor = Color.White

                If GlobalVariable.actualLanguageValue = 1 Then

                    If GunaComboBoxTypeBordereau.SelectedIndex = 0 Then
                        GunaLabelRefBordero.Text = "Référence Bon de Comande"
                    ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 6 Then
                        GunaLabelRefBordero.Text = "Référence Bon Approvision."
                    End If

                Else

                    If GunaComboBoxTypeBordereau.SelectedIndex = 0 Then
                        GunaLabelRefBordero.Text = "Order slip reference"
                    ElseIf GunaComboBoxTypeBordereau.SelectedIndex = 6 Then
                        GunaLabelRefBordero.Text = "Requisition reference"
                    End If

                End If

            End If

        Else

            GunaTextBoxReference.Enabled = False
            GunaTextBoxReference.BaseColor = Color.Gainsboro

        End If

        If GunaComboBoxTypeBordereau.SelectedIndex = 10 Then
            GunaPanelListeMarche.Visible = True
        Else
            GunaPanelListeMarche.Visible = False
        End If

        LabelQuantiteEnMagasinSource.Visible = True
        GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True

    End Sub

    Public Sub inventaireDesArticles(ByVal CODE_MAGASIN As String)

        Dim FillingListquery As String = "SELECT * FROM article ORDER BY DESIGNATION_FR ASC"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tousLesArticles As New DataTable()

        adapterList.Fill(tousLesArticles)

        GunaDataGridViewInventaire.Columns.Clear()

        GunaDataGridViewInventaire.Columns.Add("CODE_ARTICLE", "CODE ARTICLE")
        GunaDataGridViewInventaire.Columns.Add("LIBELLE", "DESIGNATION")
        GunaDataGridViewInventaire.Columns.Add("QUANTITE_EN_STOCK", "QUANTITE EN STOCK")
        GunaDataGridViewInventaire.Columns.Add("QUANTITE_PHYSIQUE", "QUANTITE PHYSIQUE")
        GunaDataGridViewInventaire.Columns.Add("COUT_DU_STOCK", "COUT DU STOCK")

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

                GunaDataGridViewInventaire.Rows.Add(CODE_ARTICLE, LIBELLE_ARTICLE, QUANTITE_EN_STOCK, "", COUT_DU_STOCK)

            Next

            'GunaDataGridViewInventaire.DataSource = tousLesArticles

            GunaDataGridViewInventaire.Columns("QUANTITE_EN_STOCK").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewInventaire.Columns("QUANTITE_EN_STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Else
            'GunaDataGridViewInventaire.Rows.Clear()
        End If

    End Sub

    'GEstion des tiers
    Private Sub GunaTextBox9_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTiers.TextChanged

        Dim query As String = ""

        If Trim(GunaTextBoxTiers.Text) = "" Then

            GunaDataGridViewTiers.Visible = False

            GunaTextBoxNomTiers.Clear()

        End If

        If Trim(GunaComboBoxTypeTiers.SelectedItem) = "Fournisseur" Or Trim(GunaComboBoxTypeTiers.SelectedItem) = "Supplier" Then

            query = "SELECT NOM_FOURNISSEUR FROM fournisseur WHERE NOM_FOURNISSEUR Like '%" & Trim(GunaTextBoxTiers.Text) & "%' ORDER BY NOM_FOURNISSEUR ASC"

        ElseIf Trim(GunaComboBoxTypeTiers.SelectedItem) = "Client" Then

            query = "SELECT NOM_PRENOM FROM client WHERE NOM_PRENOM Like '%" & Trim(GunaTextBoxTiers.Text) & "%' ORDER BY NOM_PRENOM ASC"

        ElseIf Trim(GunaComboBoxTypeTiers.SelectedItem) = "Personnel" Then

            query = "SELECT NOM_PERSONNEL, PRENOM_PERSONNEL FROM personnel WHERE NOM_PERSONNEL LIKE '%" & Trim(GunaTextBoxTiers.Text) & "%' OR PRENOM_PERSONNEL LIKE '%" & Trim(GunaTextBoxTiers.Text) & "' ORDER BY NOM_PERSONNEL ASC"
        Else
            query = "SELECT NOM_FOURNISSEUR FROM fournisseur WHERE NOM_FOURNISSEUR Like '%" & Trim(GunaTextBoxTiers.Text) & "%' ORDER BY NOM_FOURNISSEUR ASC"
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim Tiers As New DataTable()
        adapter.Fill(Tiers)

        If (Tiers.Rows.Count > 0) Then

            GunaDataGridViewTiers.Visible = True

            GunaDataGridViewTiers.DataSource = Tiers

        End If

        If Trim(GunaTextBoxTiers.Text) = "" Then
            GunaDataGridViewTiers.Visible = False
        End If

    End Sub

    Private Sub GunaAdvenceButton26_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton26.Click
        FournisseurForm.TopMost() = True

        FournisseurForm.Show()
    End Sub

    'Selection d'un élément de la liste des type de tiers proposé
    Private Sub GunaDataGridViewTiers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewTiers.CellClick

        GunaDataGridViewTiers.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewTiers.Rows(e.RowIndex)

            Dim query As String = ""
            Dim rowHeader As String = ""

            Dim Code As String = ""
            Dim Nom As String = ""

            If Trim(GunaComboBoxTypeTiers.SelectedItem) = "Fournisseur" Or Trim(GunaComboBoxTypeTiers.SelectedItem) = "Supplier" Then

                query = "SELECT * FROM fournisseur WHERE NOM_FOURNISSEUR = @NOM"
                rowHeader = "NOM_FOURNISSEUR"

            ElseIf Trim(GunaComboBoxTypeTiers.SelectedItem) = "Client" Then

                query = "SELECT * FROM client WHERE NOM_PRENOM =@NOM"
                rowHeader = "NOM_PRENOM"

            ElseIf Trim(GunaComboBoxTypeTiers.SelectedItem) = "Personnel" Then

                query = "SELECT * FROM personnel WHERE NOM_PERSONNEL =@NOM "
                rowHeader = "NOM_PERSONNEL"

            End If

            Dim adapter As New MySqlDataAdapter
            Dim Tiers As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@NOM", MySqlDbType.VarChar).Value = row.Cells(rowHeader).Value.ToString

            adapter.SelectCommand = command

            adapter.Fill(Tiers)

            If (Tiers.Rows.Count > 0) Then

                If Trim(GunaComboBoxTypeTiers.SelectedItem) = "Fournisseur" Or Trim(GunaComboBoxTypeTiers.SelectedItem) = "Supplier" Then

                    Code = Tiers.Rows(0)("CODE_FOURNISSEUR")
                    Nom = Tiers.Rows(0)("NOM_FOURNISSEUR")

                ElseIf Trim(GunaComboBoxTypeTiers.SelectedItem) = "Client" Then

                    Code = Tiers.Rows(0)("CODE_CLIENT")
                    Nom = Tiers.Rows(0)("NOM_PRENOM")

                ElseIf Trim(GunaComboBoxTypeTiers.SelectedItem) = "Personnel" Then

                    Code = Tiers.Rows(0)("CODE_PERSONNEL")
                    Nom = Tiers.Rows(0)("NOM_PERSONNEL") & " " & Tiers.Rows(0)("PRENOM_PERSONNEL")

                End If

                GunaTextBoxTiers.Text = Code
                GunaTextBoxNomTiers.Text = Nom

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid

            End If

            GunaDataGridViewTiers.Visible = False

            'connect.closeConnection()

        End If

    End Sub

    Private Sub GunaComboBoxTypeTiers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeTiers.SelectedIndexChanged

        GunaTextBoxTiers.Clear()
        GunaTextBoxNomTiers.Clear()

    End Sub

    'Selection du bon de comande ayant conduit au bon de réception.
    Private Sub GunaTextBoxReference_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxReference.TextChanged

        GunaDataGridViewRefBordero.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxReference.Text).Equals("") Then
            GunaDataGridViewRefBordero.Visible = False
        Else

            'Determining from which table to search for the articles
            'getQuery = "SELECT CODE_BORDEREAUX, LIBELLE_BORDEREAUX FROM bordereaux WHERE LIBELLE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX =@TYPE_BORDEREAUX  AND ETAT_BORDEREAU =@ETAT_BORDEREAU OR CODE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX =@TYPE_BORDEREAUX  AND ETAT_BORDEREAU =@ETAT_BORDEREAU or LIBELLE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX =@TYPE_BORDEREAUX  AND ETAT_BORDEREAU =@ETAT_BORDEREAU OR CODE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX =@TYPE_BORDEREAUX_2  AND ETAT_BORDEREAU =@ETAT_BORDEREAU ORDER BY LIBELLE_BORDEREAUX ASC"

            Dim TYPE_BORDEREAUX As String = GlobalVariable.bon_approvisi

            Dim ETAT_DU_BORDEREAU As Integer = 0

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then
                getQuery = "SELECT CODE_BORDEREAUX, LIBELLE_BORDEREAUX FROM bordereaux WHERE LIBELLE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX =@TYPE_BORDEREAUX  AND ETAT_BORDEREAU =@ETAT_BORDEREAU OR CODE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX =@TYPE_BORDEREAUX AND ETAT_BORDEREAU =@ETAT_BORDEREAU"
                TYPE_BORDEREAUX = GlobalVariable.bon_approvisi
                ETAT_DU_BORDEREAU = 4
            ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then
                getQuery = "SELECT CODE_BORDEREAUX, LIBELLE_BORDEREAUX FROM bordereaux WHERE LIBELLE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX IN ('Bon de Commande', 'Liste du Marché', 'Market List','Order slip') AND ETAT_BORDEREAU =@ETAT_BORDEREAU OR CODE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX  IN ('Bon de Commande', 'Liste du Marché', 'Market List','Order slip') AND ETAT_BORDEREAU =@ETAT_BORDEREAU"
                ETAT_DU_BORDEREAU = 4
            ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_approvisi Then
                getQuery = "SELECT CODE_BORDEREAUX, LIBELLE_BORDEREAUX FROM bordereaux WHERE LIBELLE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX IN ('Bon de Commande', 'Bon Approvisionnement', 'Order slip', 'Store Requisition') OR CODE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxReference.Text) & "%' AND TYPE_BORDEREAUX  IN ('Bon de Commande', 'Liste du Marché', 'Market List','Order slip')"
                ETAT_DU_BORDEREAU = 4
            End If

            Dim Command As New MySqlCommand(getQuery, GlobalVariable.connect)
            Command.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX

            'On ne sélectionne que les bordereaux de type commande n'ayant pas encore été traitée (réception après commande)
            Command.Parameters.Add("@ETAT_BORDEREAU", MySqlDbType.Int64).Value = ETAT_DU_BORDEREAU
            adapter.SelectCommand = Command
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                GunaDataGridViewRefBordero.Visible = True
                GunaDataGridViewRefBordero.DataSource = table
            Else
                GunaDataGridViewRefBordero.Columns.Clear()
                GunaDataGridViewRefBordero.Visible = False
            End If

            If Trim(GunaTextBoxReference.Text = "") Then
                GunaDataGridViewRefBordero.Visible = False
            End If

        End If

    End Sub

    'Sélection du type de bordereau 
    Private Sub GunaButtonAfficherValidee_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherValidee.Click

        Dim econom As New Economat()

        Dim date_debut As Date = GunaDateTimePickerFrom.Value.ToShortDateString
        Dim date_fin As Date = GunaDateTimePickerTo.Value.ToShortDateString

        If GunaComboBoxTypeDeBordereau.SelectedIndex >= 0 Then

            GunaDataGridViewListeBordereauxValides.DataSource = econom.allTableFieldsOrganised(GunaComboBoxTypeDeBordereau.SelectedItem.ToString, GunaComboBoxTrierLeBordereau.SelectedIndex, date_debut, date_fin)
            GunaLabelNombreClient.Text = "(" & GunaDataGridViewListeBordereauxValides.Rows.Count & ")"
            GunaDataGridViewListeBordereauxValides.Columns("MONTANT").DefaultCellStyle.Format = "#,##0.0"

            GunaDataGridViewListeBordereauxValides.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucun Type de bordereau sélectionné")
            Else
                MessageBox.Show("Please select a slip type")
            End If

        End If

    End Sub

    'Choix du bon de commande de la réception (Bon de commande en relation avec un bon de recption)
    Private Sub GunaDataGridViewRefBordero_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRefBordero.CellClick

        If e.RowIndex >= 0 Then

            GunaTextBoxQuantite.Text = 1

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewRefBordero.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM bordereaux WHERE LIBELLE_BORDEREAUX=@LIBELLE_BORDEREAUX AND CODE_BORDEREAUX =@CODE_BORDEREAUX ORDER BY LIBELLE_BORDEREAUX ASC"

            Dim adapter As New MySqlDataAdapter
            Dim Bordereau As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@LIBELLE_BORDEREAUX", MySqlDbType.VarChar).Value = row.Cells("LIBELLE_BORDEREAUX").Value.ToString
            command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = row.Cells("CODE_BORDEREAUX").Value.ToString

            adapter.SelectCommand = command
            adapter.Fill(Bordereau)

            Dim economatArticleDuBordereau As New Economat()

            If (Bordereau.Rows.Count > 0) Then

                GunaTextBoxReference.Text = Bordereau.Rows(0)("CODE_BORDEREAUX")

                CODE_REFERENCE_BORDERO = Bordereau.Rows(0)("CODE_BORDEREAUX")

                GunaTextBoxTiers.Text = Bordereau.Rows(0)("CODE_TIERS")
                GunaTextBoxNomTiers.Text = Bordereau.Rows(0)("NON_TIERS")
                GunaTextBoxObservation.Text = Bordereau.Rows(0)("OBSERVATIONS")

                GunaDataGridViewTiers.Visible = False

                GunaTextBoxMontantHTGeneralAchat.Text = Format(Bordereau.Rows(0)("MONTANT_HT"), "#,##0")

                GunaTextBoxMontantTTCGeneralVente.Text = Format(Bordereau.Rows(0)("MONTANT_PAYER"), "#,##0")

                'On liste l'ensemble des articles de ce bordereau
                GunaDataGridViewLigneArticleCommande.Columns.Clear()

                'GunaDataGridViewLigneArticleCommande.DataSource = economatArticleDuBordereau.ArticleDunBordereauQuelconque(GunaTextBoxReference.Text, "ligne_bordereaux")


                '----------------------------------------------------------------------------------------------------------------------

                Dim CODE_BORDEREAUX As String = GunaTextBoxCodeBordereau.Text

                Dim econom As New Economat()

                For i = 0 To econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows.Count - 1

                    If GlobalVariable.actualLanguageValue = 1 Then

                        Dim UNITE_COMPTAGE As String = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("UNITE")

                        'Dim CODE_BORDEREAUX As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE_BORDEREAUX")
                        Dim DESIGNATION As String = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("DESIGNATION")
                        Dim CODE_ARTICLE As String = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE ARTICLE")

                        Dim QUANTITE As Double = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("QUANTITE")

                        Dim EN_STOCK As Double = 0

                        If Bordereau.Rows(0)("ETAT_BORDEREAU") = 6 Then
                            EN_STOCK = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("EN STOCK") - QUANTITE
                        Else
                            EN_STOCK = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("EN STOCK")
                        End If

                        Dim DATE_PEREMPTION As Date = GlobalVariable.DateDeTravail
                        Dim PRIX_VENTE As Double = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("PRIX VENTE")
                        Dim PRIX_ACHAT As Double = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("PRIX UNITAIRE")
                        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        Dim COUT_DU_STOCK As Double = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("PRIX TOTAL")

                        econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)

                    Else

                        Dim UNITE_COMPTAGE As String = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("UNIT")

                        'Dim CODE_BORDEREAUX As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE_BORDEREAUX")
                        Dim DESIGNATION As String = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("DESIGNATION")
                        Dim CODE_ARTICLE As String = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE ARTICLE")

                        Dim QUANTITE As Double = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("QUANTITY")

                        Dim EN_STOCK As Double = 0

                        If Bordereau.Rows(0)("ETAT_BORDEREAU") = 6 Then
                            EN_STOCK = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("STOCK") - QUANTITE
                        Else
                            EN_STOCK = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("STOCK")
                        End If

                        Dim DATE_PEREMPTION As Date = GlobalVariable.DateDeTravail
                        Dim PRIX_VENTE As Double = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("TOTAL PRICE")
                        Dim PRIX_ACHAT As Double = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("UNIT PRICE")
                        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        Dim COUT_DU_STOCK As Double = econom.ArticleDunBordereauQuelconque(Bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("TOTAL PRICE")

                        econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)


                    End If

                Next

                GunaDataGridViewLigneArticleCommande.Columns.Clear()

                'GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)
                GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElementsSuivantBordoro(GlobalVariable.codeAgence, CODE_BORDEREAUX)

                '----------------------------------------------------------------------------------------------------------------------

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then
                    GunaComboBoxMagasin_2.SelectedValue = Trim(Bordereau.Rows(0)("CODE_SOUS_MAGASIN"))
                Else
                    'GunaComboBoxMagasin_1.SelectedValue = Trim(Bordereau.Rows(0)("CODE_MAGASIN"))
                End If

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid

            End If


            If GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Format = "#,##0.0"
                GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0.0"
                GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.0"

                GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Format = "#,##0.0"

                GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Format = "#,##0.0"

                'GunaDataGridViewLigneArticleMagasin.Columns("PRIX ACHAT").Visible = False

                GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").Visible = False

            Else

                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Format = "#,##0.0"
                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0.0"
                GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Format = "#,##0.0"

                GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Format = "#,##0.0"

                GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Format = "#,##0.0"

                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

            End If

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False
            GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False

        End If

        GunaDataGridViewRefBordero.Visible = False

    End Sub

    Private Sub GunaButtonAfficherLots_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLots.Click

        '---------------------------- ECONOMAT -----------------------------
        'Remplissage de la Liste des lots pour rafraichissement
        GunaDataGridViewListeDesLots.DataSource = Functions.allTableFieldsOrganised("lot", "LIBELLE_LOT")

    End Sub

    Dim page As Integer = 1

    Private Sub ReceptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceptionToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

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

        MainWindow.GunaShadowPanelReservation.Hide()
        MainWindow.PanelEnregistrement.Hide()

        MainWindow.PanelTableauDeBords.Show()
        MainWindow.GunaShadowPanelReception.Show()

        MainWindow.Show()

        Me.Hide()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub RESERVATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESERVATIONToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        MainWindow.TabControlHbergement.SelectedIndex = 1
        MainWindow.GunaShadowPanelReception.Hide()
        MainWindow.PanelTableauDeBords.Hide()

        MainWindow.GunaShadowPanelReservation.Show()

        MainWindow.PanelEnregistrement.Show()

        MainWindow.Show()

        Me.Hide()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SERVICEDETAGEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SERVICEDETAGEToolStripMenuItem.Click
        GlobalVariable.typeChambreOuSalle = "chambre"

        'RoomForm.TopMost = True
        'RoomForm.Location = New System.Drawing.Point(10, 110)
        'RoomForm.Show()

        MainWindowServiceEtageForm.Visible = True

        Me.Close()

    End Sub

    Private Sub BarRestaurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarRestaurationToolStripMenuItem.Click

        GlobalVariable.typeDeClientAFacturer = "comptoir"
        'MainWindowBarRestaurantForm.Show()
        BarRestaurantForm.Show()
        BarRestaurantForm.TopMost = True

        Me.Close()
    End Sub

    Private Sub ComptabilitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComptabilitéToolStripMenuItem.Click
        MainWindowComptabiliteForm.Visible = True

        Me.Close()

    End Sub

    Private Sub TECHNIQUEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TECHNIQUEToolStripMenuItem.Click
        MainWindowTechnique.Show()

        Me.Close()

    End Sub

    'Affichage du magasin
    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        MAgasinForm.TopMost() = True
        MAgasinForm.Show()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
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

    Private Sub magasinSourceOuDeRecetionAAfficher(ByVal CODE_MAGASIN_OU_TYPE_MAGASIN As String, ByVal CODE_SOUS_MAGASIN_OU_TYPE_MAGASIN As String)

        GunaComboBoxMagasin_1.DataSource = Nothing
        GunaComboBoxMagasin_2.DataSource = Nothing

        '1- MAGASIN DE RECEPTION

        Dim infoMagReception As DataTable = Functions.getElementByCode(CODE_MAGASIN_OU_TYPE_MAGASIN, "magasin", "CODE_MAGASIN") 'code de magasin

        If infoMagReception.Rows.Count > 0 Then

            GunaComboBoxMagasin_1.DataSource = infoMagReception
            GunaComboBoxMagasin_1.DisplayMember = "LIBELLE_MAGASIN"
            GunaComboBoxMagasin_1.ValueMember = "CODE_MAGASIN"

            GunaComboBoxMagasin_1.SelectedIndex = 0

        Else

            'SELECTION D'UN TYPE DE MAGASIN CENTRAL OU PAS

            Dim TYPE_MAGASIN As String = CODE_MAGASIN_OU_TYPE_MAGASIN 'type de magsin

            infoMagReception = Functions.getElementByCode(CODE_MAGASIN_OU_TYPE_MAGASIN, "magasin", "TYPE_MAGASIN")

            If infoMagReception.Rows.Count > 0 Then

                GunaComboBoxMagasin_1.DataSource = infoMagReception
                GunaComboBoxMagasin_1.DisplayMember = "LIBELLE_MAGASIN"
                GunaComboBoxMagasin_1.ValueMember = "CODE_MAGASIN"

                GunaComboBoxMagasin_1.SelectedIndex = 0

            End If

        End If

        '2- MAGASIN DE DESTINATION

        infoMagReception = Functions.getElementByCode(CODE_SOUS_MAGASIN_OU_TYPE_MAGASIN, "magasin", "CODE_MAGASIN") 'code de magasin

        If infoMagReception.Rows.Count > 0 Then

            GunaComboBoxMagasin_2.DataSource = infoMagReception
            GunaComboBoxMagasin_2.DisplayMember = "LIBELLE_MAGASIN"
            GunaComboBoxMagasin_2.ValueMember = "CODE_MAGASIN"

            GunaComboBoxMagasin_2.SelectedIndex = 0

        Else

            'SELECTION D'UN TYPE DE MAGASIN CENTRAL OU PAS

            Dim TYPE_MAGASIN As String = CODE_SOUS_MAGASIN_OU_TYPE_MAGASIN 'type de magsin

            infoMagReception = Functions.getElementByCode(CODE_SOUS_MAGASIN_OU_TYPE_MAGASIN, "magasin", "TYPE_MAGASIN")

            If infoMagReception.Rows.Count > 0 Then

                GunaComboBoxMagasin_2.DataSource = infoMagReception
                GunaComboBoxMagasin_2.DisplayMember = "LIBELLE_MAGASIN"
                GunaComboBoxMagasin_2.ValueMember = "CODE_MAGASIN"

                GunaComboBoxMagasin_2.SelectedIndex = 0

            End If

        End If


    End Sub

    Private Sub GunaDataGridViewListeBordereauxValides_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewListeBordereauxValides.CellDoubleClick

        NewBonDeRequisition()

        Dim econom As New Economat()

        If e.RowIndex >= 0 Then

            GunaComboBoxTypeBordereau.Enabled = False

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewListeBordereauxValides.Rows(e.RowIndex)

            Dim bordereau As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE BORDEREAUX").Value.ToString), "bordereaux", "CODE_BORDEREAUX")

            If bordereau.Rows.Count > 0 Then

                GunaComboBoxTypeBordereau.SelectedItem = Trim(bordereau.Rows(0)("TYPE_BORDEREAUX"))
                GunaTextBoxEtatBordereau.Text = bordereau.Rows(0)("ETAT_BORDEREAU")
                Dim CODE_MAGASIN As String = bordereau.Rows(0)("CODE_MAGASIN")
                Dim CODE_SOUS_MAGASIN As String = bordereau.Rows(0)("CODE_SOUS_MAGASIN")

                Dim CODE_MAGASIN_OU_TYPE_MAGASIN_RECEPTION As String = ""
                Dim CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE As String = ""

                'DETERMINONS LE MAGASIN DE RECEPTION

                If bordereau.Rows(0)("TYPE_BORDEREAUX").Equals(GlobalVariable.bon_requisition) Or bordereau.Rows(0)("TYPE_BORDEREAUX").Equals(GlobalVariable.bon_reception) Or bordereau.Rows(0)("TYPE_BORDEREAUX").Equals(GlobalVariable.bon_cmd) Then
                    CODE_MAGASIN_OU_TYPE_MAGASIN_RECEPTION = CODE_MAGASIN 'LE MAGASIN DE RECEPTION EST LE GRAND MAGASIN ET IL N'EXISTE PAS DE SOUS MAGASINS ON TRAITE UN SEUL MAGASIN
                    magasinSourceOuDeRecetionAAfficher(CODE_MAGASIN_OU_TYPE_MAGASIN_RECEPTION, CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE)
                Else

                    If bordereau.Rows(0)("TYPE_BORDEREAUX").Equals(GlobalVariable.bon_approvisi) Then
                        CODE_MAGASIN_OU_TYPE_MAGASIN_RECEPTION = CODE_SOUS_MAGASIN
                        CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE = CODE_MAGASIN
                        magasinSourceOuDeRecetionAAfficher(CODE_MAGASIN_OU_TYPE_MAGASIN_RECEPTION, CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE)
                    ElseIf bordereau.Rows(0)("TYPE_BORDEREAUX").Equals(GlobalVariable.sortie) Or bordereau.Rows(0)("TYPE_BORDEREAUX").Equals(GlobalVariable.transfert_inter) Then
                        CODE_MAGASIN_OU_TYPE_MAGASIN_RECEPTION = CODE_MAGASIN
                        CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE = "Petit magasin"
                        magasinSourceOuDeRecetionAAfficher(CODE_MAGASIN_OU_TYPE_MAGASIN_RECEPTION, CODE_MAGASIN_OU_TYPE_MAGASIN_PROVENANCE)
                        GunaComboBoxMagasin_2.SelectedValue = CODE_SOUS_MAGASIN
                        GunaComboBoxMagasin_2.Visible = True
                        If GlobalVariable.actualLanguageValue = 1 Then
                            GunaLabelMagasin_2.Text = "Magasin de Destination"
                        Else
                            GunaLabelMagasin_2.Text = "Receiving Store"
                        End If
                    ElseIf bordereau.Rows(0)("TYPE_BORDEREAUX").Equals(GlobalVariable.entree_exceptionnelle) Or bordereau.Rows(0)("TYPE_BORDEREAUX").Equals(GlobalVariable.sortie_exceptionnelle) Then
                        AutoLoadlisteMagasinSource()
                        GunaComboBoxMagasin_1.SelectedValue = CODE_MAGASIN
                    End If

                End If

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then

                    If bordereau.Rows(0)("DATE_DU").ToShortDateString() <= GunaDateTimePickerP1LM.MaxDate And bordereau.Rows(0)("DATE_DU").ToShortDateString() >= GunaDateTimePickerP1LM.MinDate Then
                        GunaDateTimePickerP1LM.Value = bordereau.Rows(0)("DATE_DU")
                    End If

                    If bordereau.Rows(0)("DATE_AU").ToShortDateString() <= GunaDateTimePickerP2LM.MaxDate And bordereau.Rows(0)("DATE_AU").ToShortDateString() >= GunaDateTimePickerP2LM.MinDate Then
                        GunaDateTimePickerP2LM.Value = bordereau.Rows(0)("DATE_AU")
                    End If

                End If

                GunaTextBoxCodeBordereau.Text = bordereau.Rows(0)("CODE_BORDEREAUX")

                GunaTextBoxReference.Text = bordereau.Rows(0)("REF_BORDEREAUX")
                GunaTextBoxLibelleBordereau.Text = bordereau.Rows(0)("LIBELLE_BORDEREAUX")
                GunaTextBoxTiers.Text = bordereau.Rows(0)("CODE_TIERS")
                GunaTextBoxNomTiers.Text = bordereau.Rows(0)("NON_TIERS")
                GunaTextBoxObservation.Text = bordereau.Rows(0)("OBSERVATIONS")

                GunaTextBoxMontantHTGeneralAchat.Text = Format(bordereau.Rows(0)("MONTANT_HT"), "#,##0") ' PRIX ACHAT

                GunaTextBoxMontantTTCGeneralVente.Text = Format(bordereau.Rows(0)("MONTANT_PAYER"), "#,##0") ' PRIX VENTE

                CODE_REFERENCE_BORDERO = GunaTextBoxReference.Text

                GunaDataGridViewTiers.Visible = False

                'ON VERIFIE SI LA REFERENCE DU BC CORRESPOND AU CODE D'UNE FICHE TECHNIQUE AUQUEL CAS IL FAUDRA JUSTE VALIDER POUR DESTOCKER
                Dim ficheTechnique As DataTable = Functions.getElementByCode(Trim(GunaTextBoxReference.Text), "fiche_technique", "CODE_FICHE_TECHNIQUE")

                If ficheTechnique.Rows.Count > 0 Then
                    GunaButtonEnregistrer.Visible = True
                    GunaButtonEnregistrer.Enabled = False
                Else
                    GunaButtonEnregistrer.Visible = True
                End If

                If bordereau.Rows(0)("ETAT_BORDEREAU") = 0 Then

                    'ANNULATION
                    GunaButtonAnnulerBordereau.Visible = True

                    GunaLabelEnregistreur.Visible = True
                    GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

                    GunaButtonController.Enabled = True
                    GunaButtonController.Visible = True

                    GunaButtonController.Enabled = True
                    PictureBox1NextStage.Visible = False
                    GunaButtonValider.Visible = False

                ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 1 Then

                    'ANNULATION
                    GunaButtonAnnulerBordereau.Visible = True
                    GunaButtonAnnulerBordereau.Enabled = True

                    '-------- ENREGISTRER ---------
                    GunaLabelEnregistreur.Visible = True
                    GunaButtonEnregistrer.Visible = True
                    GunaButtonEnregistrer.Enabled = False
                    GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

                    '------ CONTROLER -----------------
                    GunaLabelControleur.Visible = True
                    GunaButtonController.Visible = True
                    GunaButtonController.Enabled = False
                    GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

                    PictureBoxNext1.Visible = True

                    '------ VERIFICATION -----------------
                    GunaButtonVerification.Visible = True
                    GunaButtonVerification.Enabled = True

                    If Trim(GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter) Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then

                        GunaButtonAnnulerBordereau.Visible = False
                        GunaButtonVerification.Visible = False
                        PictureBoxNext1.Visible = False

                    End If

                ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 2 Then

                    'ANNULATION
                    GunaButtonAnnulerBordereau.Visible = True
                    GunaButtonAnnulerBordereau.Enabled = True

                    empecherAjoutArticle()

                    '-------- ENREGISTRER ---------
                    GunaLabelEnregistreur.Visible = True
                    GunaButtonEnregistrer.Visible = True
                    GunaButtonEnregistrer.Enabled = False
                    GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

                    '------ CONTROLER -----------------
                    GunaLabelControleur.Visible = True
                    GunaButtonController.Visible = True
                    GunaButtonController.Enabled = False
                    GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

                    PictureBoxNext1.Visible = True

                    '------ VERIFICATION -----------------
                    GunaButtonVerification.Visible = True
                    GunaButtonVerification.Enabled = False
                    GunaLabelVerification.Visible = True
                    GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")

                    If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Then
                        GunaButtonValider.Text = "Sortir"
                    ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.entree_exceptionnelle Then
                        GunaButtonValider.Text = "Entrer"
                    Else
                        GunaButtonValider.Text = "Valider"
                    End If

                    '---------- VALIDER ------------------
                    PictureBox1NextStage.Visible = True
                    GunaButtonValider.Visible = True


                ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 3 Then

                    'ANNULATION
                    GunaButtonAnnulerBordereau.Visible = True
                    GunaButtonAnnulerBordereau.Enabled = True

                    empecherAjoutArticle()

                    '-------- ENREGISTRER ---------
                    GunaLabelEnregistreur.Visible = True
                    GunaButtonEnregistrer.Visible = True
                    GunaButtonEnregistrer.Enabled = False
                    GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

                    '------ CONTROLER -----------------
                    GunaLabelControleur.Visible = True
                    GunaButtonController.Visible = True
                    GunaButtonController.Enabled = False
                    GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

                    PictureBoxNext1.Visible = True

                    '------ VERIFICATION -----------------
                    GunaButtonVerification.Visible = True
                    GunaButtonVerification.Enabled = False
                    GunaLabelVerification.Visible = True
                    GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")

                    PictureBox1NextStage.Visible = True

                    '---------- VALIDER ------------------
                    GunaButtonValider.Visible = True
                    GunaButtonValider.Enabled = False
                    GunaLabelValideur.Visible = True
                    GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")

                    '--------------- COMMANDER --------------
                    PictureBoxNext3.Visible = True
                    GunaButtonCommander.Visible = True

                    If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then

                        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Then
                            GunaButtonValider.Text = "Sortir"
                        ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.entree_exceptionnelle Then
                            GunaButtonValider.Text = "Entrer"
                        Else
                            GunaButtonValider.Text = "Valider"
                        End If

                        '---------- VALIDER ------------------
                        GunaButtonValider.Visible = True
                        GunaButtonValider.Enabled = False
                        GunaLabelValideur.Visible = True
                        GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")

                        PictureBoxNext3.Visible = False
                        GunaButtonCommander.Visible = False

                        'ANNULATION
                        GunaButtonAnnulerBordereau.Visible = True
                        GunaButtonAnnulerBordereau.Enabled = False

                    ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
                        If GlobalVariable.actualLanguageValue = 1 Then
                            GunaButtonCommander.Text = "Approvisionner"
                        Else
                            GunaButtonCommander.Text = "Supply"
                        End If
                    End If

                ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 4 Then

                    'ANNULATION
                    GunaButtonAnnulerBordereau.Visible = True
                    GunaButtonAnnulerBordereau.Enabled = True

                    empecherAjoutArticle()

                    '-------- ENREGISTRER ---------
                    GunaLabelEnregistreur.Visible = True
                    GunaButtonEnregistrer.Visible = True
                    GunaButtonEnregistrer.Enabled = False
                    GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

                    '------ CONTROLER -----------------
                    GunaLabelControleur.Visible = True
                    GunaButtonController.Visible = True
                    GunaButtonController.Enabled = False
                    GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

                    PictureBoxNext1.Visible = True

                    '------ VERIFICATION -----------------
                    GunaButtonVerification.Visible = True
                    GunaLabelVerification.Visible = True
                    PictureBox1NextStage.Visible = True

                    GunaButtonVerification.Enabled = False
                    GunaLabelVerification.Visible = True
                    GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")

                    PictureBox1NextStage.Visible = True

                    '---------- VALIDER ------------------
                    GunaButtonValider.Visible = True
                    GunaButtonValider.Enabled = False
                    GunaLabelValideur.Visible = True
                    GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")

                    '--------------- COMMANDER --------------
                    PictureBoxNext3.Visible = True
                    GunaButtonCommander.Visible = True
                    GunaButtonCommander.Enabled = False
                    GunaLabelCommandeur.Visible = True
                    GunaLabelCommandeur.Text = bordereau.Rows(0)("COMMANDER")

                ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 5 Then

                    'ANNULATION
                    GunaButtonAnnulerBordereau.Visible = False
                    GunaButtonAnnulerBordereau.Enabled = False

                    empecherAjoutArticle()

                    '-------- ENREGISTRER ---------
                    GunaLabelEnregistreur.Visible = True
                    GunaButtonEnregistrer.Visible = True
                    GunaButtonEnregistrer.Enabled = False
                    GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

                    '------ CONTROLER -----------------
                    GunaLabelControleur.Visible = True
                    GunaButtonController.Visible = True
                    GunaButtonController.Enabled = False
                    GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

                    PictureBoxNext1.Visible = True

                    '------ VERIFICATION -----------------
                    GunaButtonVerification.Visible = True
                    GunaLabelVerification.Visible = True
                    PictureBox1NextStage.Visible = True

                    GunaButtonVerification.Enabled = False
                    GunaLabelVerification.Visible = True
                    GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")

                    PictureBox1NextStage.Visible = True

                    '---------- VALIDER ------------------
                    GunaButtonValider.Visible = True
                    GunaButtonValider.Enabled = False
                    GunaLabelValideur.Visible = True
                    GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")

                    '--------------- COMMANDER --------------
                    PictureBoxNext3.Visible = True
                    GunaButtonCommander.Visible = True
                    GunaButtonCommander.Enabled = False
                    GunaLabelCommandeur.Visible = True
                    GunaLabelCommandeur.Text = bordereau.Rows(0)("COMMANDER")

                ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 6 Then

                    'ETAT_BORDEREAU = 6
                    '-------- ENREGISTRER ---------
                    GunaLabelEnregistreur.Visible = True
                    GunaButtonEnregistrer.Visible = True
                    GunaButtonEnregistrer.Enabled = False
                    GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

                    '------ CONTROLER -----------------
                    GunaLabelControleur.Visible = True
                    GunaButtonController.Visible = True
                    GunaButtonController.Enabled = False
                    GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

                ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 7 Then

                    GunaLabelEnregistreur.Visible = True
                    GunaButtonEnregistrer.Enabled = False
                    GunaLabelAnnuler.Text = bordereau.Rows(0)("ENREGISTRER")

                    'ANNULATION
                    GunaLabelAnnuler.Visible = True
                    GunaButtonAnnulerBordereau.Visible = True
                    GunaButtonAnnulerBordereau.Enabled = False
                    GunaLabelAnnuler.Text = bordereau.Rows(0)("ANNULER")

                End If

                GunaDataGridViewLigneArticleCommande.Columns.Clear()

                '---------------------On insere le contenu d'un bordereau dans la bordereau_ligne_temp avant de le mettre dans le datagrid
                '1- Insertion du contenu du bordereau dans le datagrid

                Dim CODE_BORDEREAUX As String = bordereau.Rows(0)("CODE_BORDEREAUX")

                For i = 0 To econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows.Count - 1

                    If GlobalVariable.actualLanguageValue = 1 Then

                        Dim UNITE_COMPTAGE As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("UNITE")
                        'Dim CODE_BORDEREAUX As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE_BORDEREAUX")
                        Dim DESIGNATION As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("DESIGNATION")
                        Dim CODE_ARTICLE As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE ARTICLE")

                        Dim QUANTITE As Double = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("QUANTITE")

                        Dim EN_STOCK As Double = 0

                        If bordereau.Rows(0)("ETAT_BORDEREAU") = 6 Then
                            EN_STOCK = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("EN STOCK") - QUANTITE
                        Else
                            EN_STOCK = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("EN STOCK")
                        End If

                        Dim DATE_PEREMPTION As Date = GlobalVariable.DateDeTravail
                        Dim PRIX_VENTE As Double = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("PRIX VENTE")
                        Dim PRIX_ACHAT As Double = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("PRIX UNITAIRE")
                        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        Dim COUT_DU_STOCK As Double = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("PRIX TOTAL")

                        econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)

                    Else

                        Dim UNITE_COMPTAGE As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("UNIT")
                        'Dim CODE_BORDEREAUX As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE_BORDEREAUX")
                        Dim DESIGNATION As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("DESIGNATION")
                        Dim CODE_ARTICLE As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE ARTICLE")

                        Dim QUANTITE As Double = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("QUANTITY")

                        Dim EN_STOCK As Double = 0

                        If bordereau.Rows(0)("ETAT_BORDEREAU") = 6 Then
                            EN_STOCK = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("STOCK") - QUANTITE
                        Else
                            EN_STOCK = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("STOCK")
                        End If

                        Dim DATE_PEREMPTION As Date = GlobalVariable.DateDeTravail
                        Dim PRIX_VENTE As Double = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("SELLING PRICE")
                        Dim PRIX_ACHAT As Double = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("UNIT PRICE")
                        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        Dim COUT_DU_STOCK As Double = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("TOTAL PRICE")

                        econom.insertLigneBordereauTemp(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)

                    End If

                Next

                'Functions.DeleteElementByCode(CODE_BORDEREAUX, "ligne_bordereaux", "CODE_BORDEREAUX")

                GunaDataGridViewLigneArticleCommande.Columns.Clear()

                'GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)
                GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElementsSuivantBordoro(GlobalVariable.codeAgence, CODE_BORDEREAUX)

                Dim CODE_AGENCE_AFTER As String = GlobalVariable.codeAgence
                Dim CODE_USER_AFTER As String = GlobalVariable.codeUser

                '2- Puis on deverse le contenu de bordereau_ligne_temp dans le datagrid
                '---------------------------------------------------------------------------------------------------------------------

                If GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then

                    If GlobalVariable.actualLanguageValue = 1 Then

                        GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                        GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                        GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0.00"

                        GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Format = "#,##0.00"

                        'GunaDataGridViewLigneArticleMagasin.Columns("PRIX ACHAT").Visible = False
                        GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").Visible = False

                    Else


                        GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                        GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                        GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0.00"

                        GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Format = "#,##0.00"

                        GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

                    End If

                    GunaDataGridViewRefBordero.Visible = False

                    GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False '
                    GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

                End If

            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrer.Text = "Sauvegarder"
            Else
                GunaButtonEnregistrer.Text = "Update"
            End If

            TabControlEconomat.SelectedIndex = 1

        End If

    End Sub

    'Au changement du type de bordereau on éfface le datagrid
    Private Sub GunaComboBoxTypeDeBordereau_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeBordereau.SelectedIndexChanged

        LabelListeDesBons.Visible = True

        If GunaComboBoxTypeDeBordereau.SelectedIndex = 1 Then
            LabelListeDesBons.Text = GlobalVariable.bon_requisition.ToUpper()
        ElseIf GunaComboBoxTypeDeBordereau.SelectedIndex = 0 Then
            LabelListeDesBons.Text = GlobalVariable.bon_reception
        ElseIf GunaComboBoxTypeDeBordereau.SelectedIndex = 4 Then
            LabelListeDesBons.Text = GlobalVariable.sortie_exceptionnelle.ToUpper()
        ElseIf GunaComboBoxTypeDeBordereau.SelectedIndex = 3 Then
            LabelListeDesBons.Text = GlobalVariable.sortie
        ElseIf GunaComboBoxTypeDeBordereau.SelectedIndex = 7 Then
            LabelListeDesBons.Text = GlobalVariable.entree_exceptionnelle.ToUpper()
        ElseIf GunaComboBoxTypeDeBordereau.SelectedIndex = 6 Then
            LabelListeDesBons.Text = GlobalVariable.transfert_inter.ToUpper
        ElseIf GunaComboBoxTypeDeBordereau.SelectedIndex = 8 Then
            LabelListeDesBons.Text = GlobalVariable.bon_cmd.ToUpper()
        ElseIf GunaComboBoxTypeDeBordereau.SelectedIndex = 9 Then
            LabelListeDesBons.Text = GlobalVariable.bon_approvisi.ToUpper()
        ElseIf GunaComboBoxTypeDeBordereau.SelectedIndex = 10 Then
            LabelListeDesBons.Text = GlobalVariable.list_du_marche.ToUpper()
        End If

        GunaDataGridViewListeBordereauxValides.Columns.Clear()
        GunaLabelNombreClient.Text = "(" & 0 & ")"
    End Sub

    'MODIFICATION DE DATAGRID DES LIGNE DU BORDEREAU DE COMMANDE


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

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

                LabelQuantiteEnMagasinSource.Visible = True

                LabelQteEnMagasinDeDestination.Visible = True

                Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString

                Dim CODE_SOUS_MAGASIN As String = GunaComboBoxMagasin_2.SelectedValue.ToString

                Dim CODE_ARTCLE As String = Article.Rows(0)("CODE_ARTICLE")

                GunaTextBoxQunatiteDansLeMagasinProvenance.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTCLE)

                GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True

                GunaTextBoxQunatiteDansLeMagasinDestination.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_SOUS_MAGASIN, CODE_ARTCLE)

                LabelQteEnMagasinDeDestination.Visible = True

            Else

                LabelQuantiteEnMagasinSource.Visible = False
                GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

                LabelQteEnMagasinDeDestination.Visible = False
                LabelQteEnMagasinDeDestination.Visible = False

            End If

            GunaTextBoxAchat.Text = Format(Article.Rows(0)("PRIX_ACHAT_HT"), "#,##0")
            GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0")
            GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
            GunaTextBoxSeuile.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")
            GunaTextBoxQteGrdeUnite.Text = Article.Rows(0)("QUANTITE")
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

            'En cas de transfert inter magasin on doit vérifier que la quantité à transferer est en quantité suffisante
            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

                Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString
                Dim CODE_ARTCLE As String = GunaTextBoxCodeArticle.Text

                Dim quantite As Double = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTCLE)

                'Si la qte  à ajouter est inférieur ou égale à la quantité du stock dans le dit magasin alors on l'ajoute au bordereau
                If Not Double.Parse(GunaTextBoxQuantite.Text) >= quantite Then

                    'GunaDataGridViewLigneArticleMagasin.Rows.Add(GunaTextBoxCodeArticle.Text, GunaTextBoxArticle.Text, GunaTextBoxQuantite.Text, Double.Parse(GunaTextBoxEnStock.Text), Double.Parse(GunaTextBoxAchat.Text) * Integer.Parse(GunaTextBoxQuantite.Text), Double.Parse(GunaTextBoxPrixVente.Text) * Integer.Parse(GunaTextBoxQuantite.Text), dateDatePeremption)

                Else


                End If

            Else

                If Article.Rows.Count > 0 And Not Trim(GunaTextBoxLecteurRFID.Text) = "" Then


                    Dim CODE_BORDEREAUX = ""
                    Dim DESIGNATION = GunaTextBoxArticle.Text
                    Dim CODE_ARTICLE = GunaTextBoxCodeArticle.Text
                    Dim QUANTITE = Double.Parse(GunaTextBoxQuantite.Text)
                    Dim EN_STOCK = Double.Parse(GunaTextBoxQteGrdeUnite.Text)
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


        End If

        If GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then

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

            Else
                '**klg
                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("PRIX ACHAT").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewLigneArticleCommande.Columns("PRIX ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").Visible = False
                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

                '------------------------

                GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

                'GunaDataGridViewLigneArticleCommande.Columns("DATE DE PEREMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End If

        End If


        GunaTextBoxArticle.Clear()
        GunaButtonAjouterLigne.Visible = False

        For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

            'montantGlobalAchat += GunaDataGridViewLigneArticleMagasin.Rows(i).Cells("PRIX ACHAT").Value * GunaDataGridViewLigneArticleMagasin.Rows(i).Cells("QUANTITE").Value
            'montantGlobalVente += GunaDataGridViewLigneArticleMagasin.Rows(i).Cells("PRIX VENTE").Value * GunaDataGridViewLigneArticleMagasin.Rows(i).Cells("QUANTITE").Value

        Next

        GunaTextBoxMontantHTGeneralAchat.Text = Format(montantGlobalAchat, "#,##0")
        GunaTextBoxMontantTTCGeneralVente.Text = Format(montantGlobalVente, "#,##0")

        GunaTextBoxQuantite.Text = 1
        GunaTextBoxPrixVente.Text = 0
        GunaTextBoxAchat.Text = 0

        montantGlobalAchat = 0
        montantGlobalVente = 0

        GunaTextBoxSeuile.Text = 0
        GunaTextBoxQteGrdeUnite.Text = 0
        GunaTextBoxCoutDuStock.Text = 0

        GunaTextBoxGrandeUniteDeCompatge.Clear()

        GunaTextBoxLecteurRFID.Clear()

        'GunaTextBoxLecteurRFID.Select()

    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        NotificationsForm.TopMost = True
        NotificationsForm.Show()

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions("ECONOME", "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If Not notifications.Rows.Count > 0 Then

            notifications = Functions.GetAllElementsOnTwoConditions("PURCHASE", "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        End If

        If notifications.Rows.Count > 0 Then

            NotificationsForm.GunaDataGridViewNotification.Columns.Clear()

            NotificationsForm.GunaDataGridViewNotification.DataSource = notifications

            NotificationsForm.GunaDataGridViewNotification.Columns("ID_NOTIFICATION").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_PROFIL").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_AGENCE").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("ETAT_NOTIFCATION").Visible = False

        End If

    End Sub

    Private Sub GunaLabel20_Click(sender As Object, e As EventArgs) Handles GunaLabelNotification.Click

        If GlobalVariable.actualLanguageValue = 1 Then
            NotificationsForm.GunaTextBoxFromWhichWindow.Text = "economat"
        Else
            NotificationsForm.GunaTextBoxFromWhichWindow.Text = "purchase"
        End If

        NotificationsForm.TopMost = True
        NotificationsForm.Show()

        Dim CATEG_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
        'Dim POSTE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("POSTE_UTILISATEUR")

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(CATEG_UTILISATEUR, "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then

            NotificationsForm.GunaDataGridViewNotification.Columns.Clear()

            NotificationsForm.GunaDataGridViewNotification.DataSource = notifications

            NotificationsForm.GunaDataGridViewNotification.Columns("ID_NOTIFICATION").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_PROFIL").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_AGENCE").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("ETAT_NOTIFCATION").Visible = False

        End If

    End Sub

    Private Sub TabControlEconomat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlEconomat.SelectedIndexChanged

        PanelApport.Visible = False

        LabelListeDesBons.Visible = False

        Dim econom As New Economat()

        If TabControlEconomat.SelectedIndex = 1 Then

            GunaDataGridViewListeBordereauxValides.Columns.Clear()
        End If

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_USER As String = GlobalVariable.codeUser

        If Trim(GunaButtonEnregistrer.Text).Equals("Enregistrer") Or Trim(GunaButtonEnregistrer.Text).Equals("Save") Then
            If Not GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then
                econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)
            End If
        End If

        GunaDateTimePicker1.Value = GlobalVariable.DateDeTravail
        GunaDateTimePicker2.Value = GlobalVariable.DateDeTravail

        If TabControlEconomat.SelectedIndex = 0 Then
            NewBonDeRequisition()
        End If

    End Sub

    Private Sub GunaButtonCommander_Click(sender As Object, e As EventArgs) Handles GunaButtonValider.Click

        Me.Cursor = Cursors.WaitCursor

        Dim econom As New Economat()

        Dim CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR As String = ""

        Dim ETAT_BORDEREAU As Integer = 0

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
            Dim totalAchat As Double = 0
            'Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

            If Not Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
                totalAchat = GunaTextBoxMontantHTGeneralAchat.Text
            End If

            Dim totalVente As Double = 0

            If Not Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
                totalVente = GunaTextBoxMontantTTCGeneralVente.Text
            End If

            Dim title As String = LabelBon.Text
            Dim nomTiers As String = GunaTextBoxNomTiers.Text
            Dim libelle As String = GunaTextBoxLibelleBordereau.Text
            Dim reference As String = GunaTextBoxReference.Text
            Dim observation As String = GunaTextBoxObservation.Text
            Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

            Dim typeBordereau As String = GlobalVariable.list_du_marche

            Dim ETAT_BORDEREAUX_MAIL As Integer = 3

            Dim args As New ArgumentType()

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
                    typeBordereau = ""
                End If

                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                    args.action = 1
                    ''backGroundWorkerToCall(args)
                    RapportApresCloture.impressionEconomat(GunaDataGridViewLigneArticleCommande, title, totalAchat, totalVente, numeroBon, ETAT_BORDEREAUX_MAIL, nomTiers, libelle, reference, observation, typeBordereau)

                End If

            End If

        End If

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Then


            'LE REAPPROVISIONNEMENT SE FAIT EN SELON LES ETAPES SUIVANTES : BC->SAVE->CONTROLLER (3 ETAPES)
            '------------------------ LIGNE DE MOVEMENT --------------------------
            permettreAjoutArticle()

            Dim CODE_LOT As String = ""

            Dim CODE_BORDEREAUX As String = Trim(GunaTextBoxCodeBordereau.Text)

            For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

                Dim CODE_ARTICLE As String = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("CODE ARTICLE").Value.ToString

                If GlobalVariable.actualLanguageValue = 1 Then
                    CODE_LOT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value.ToString
                Else
                    CODE_LOT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value.ToString
                End If

                Dim qte As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("STOCK").Value.ToString, qte)
                End If

                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value.ToString, entre_en_stock)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value.ToString, entre_en_stock)
                End If

                Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock 'QUANTITE EN MOVEMENT

                Dim DATE_PEREMPTION As Date = GunaDateTimePickerDatePeremption.Value.ToShortDateString()

                Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString

                Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                Dim COUT_DU_STOCK As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                Else
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                End If

                Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "")
                Dim LIBELLE_MOUVEMENT As String = GunaComboBoxTypeBordereau.SelectedItem.ToString

                Dim TYPE_MOUVEMENT As String = GlobalVariable.sortie_exceptionnelle

                Dim QUANTITE_ENTREE As Double = 0
                Dim QUANTITE_SORTIE As Double = QUANTITE_ENTREE_STOCK
                Dim VALEUR_ENTREE As Double = 0
                Dim VALEUR_SORTIE As String = QUANTITE_ENTREE_STOCK

                QUANTITE_ENTREE = 0
                VALEUR_ENTREE = 0

                Dim ETAT_MOUVEMENT As String = ""
                Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                'GESTION DES LIGNES DE MOUVEMENT SSI NOUS GERONS LES BON DE RECEPTION VALIDE

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                If Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows.Count > 0 Then

                    If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then

                    Else
                        QUANTITE_AVANT_MOVEMENT = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("QUANTITE")
                    End If

                    CMUP = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("PRIX_ACHAT_HT")

                End If

                'INSERTION DU MOVEMENT DE STOCK
                If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_BORDEREAUX, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                    'MISE A JOURS DES QUANTITE D'ARTICLES lors des entrées en magasins

                    Dim CODE_SOURCE As String = CODE_ARTICLE
                    Dim TABLE_SOURCE As String = "article"
                    Dim QUANTITE_ARTICLE As Double = QUANTITE_SORTIE * -1
                    Dim CODE_DESTINATION As String = ""

                    If econom.gestionStockagesEtDeStockages(CODE_SOURCE, TABLE_SOURCE, QUANTITE_ARTICLE) Then
                        'MessageBox.Show(CODE_SOURCE & "-" & QUANTITE_ARTICLE)
                    End If

                    'MISE A JOUR DU PRIX
                    econom.CoutMoyenUnitairePondereDunArticleQuelconque(CODE_ARTICLE)

                End If

            Next

            'Mise ajours du bon de commande ayant conduit au Bon de Réception pour que le bon de commande ne s'affiche plus lors de creation d'un bon de réception

            CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR = Trim(GunaTextBoxCodeBordereau.Text)

            ETAT_BORDEREAU = 3

            econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Sortie exceptionnelle réalisée avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Exceptionnal Exit realised successfully", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            TabControlEconomat.SelectedIndex = 1

        ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.entree_exceptionnelle Then

            'LE REAPPROVISIONNEMENT SE FAIT EN SELON LES ETAPES SUIVANTES : BC->SAVE->CONTROLLER (3 ETAPES)
            '------------------------ LIGNE DE MOVEMENT --------------------------
            permettreAjoutArticle()

            Dim CODE_LOT As String = ""

            Dim CODE_BORDEREAUX As String = Trim(GunaTextBoxCodeBordereau.Text)

            For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

                Dim CODE_ARTICLE As String = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("CODE ARTICLE").Value.ToString

                If GlobalVariable.actualLanguageValue = 1 Then
                    CODE_LOT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNITE").Value.ToString
                Else
                    CODE_LOT = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("UNIT").Value.ToString
                End If

                Dim qte As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("STOCK").Value.ToString, qte)
                End If
                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value.ToString, entre_en_stock)
                Else
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value.ToString, entre_en_stock)
                End If

                Dim QUANTITE_ENTREE_STOCK As Double = entre_en_stock 'QUANTITE EN MOVEMENT

                Dim DATE_PEREMPTION As Date = GunaDateTimePickerDatePeremption.Value.ToShortDateString()

                Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString

                Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                Dim COUT_DU_STOCK As Double = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                Else
                    COUT_DU_STOCK = GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                End If

                Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "")
                Dim LIBELLE_MOUVEMENT As String = GunaComboBoxTypeBordereau.SelectedItem.ToString

                Dim TYPE_MOUVEMENT As String = ""

                Dim QUANTITE_ENTREE As Double = 0
                Dim QUANTITE_SORTIE As Double = 0
                Dim VALEUR_ENTREE As Double = 0
                Dim VALEUR_SORTIE As String = 0

                TYPE_MOUVEMENT = "Entrée en stock"
                QUANTITE_ENTREE = entre_en_stock
                VALEUR_ENTREE = QUANTITE_ENTREE

                Dim ETAT_MOUVEMENT As String = ""
                Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                'GESTION DES LIGNES DE MOUVEMENT SSI NOUS GERONS LES BON DE RECEPTION VALIDE

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                If Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows.Count > 0 Then

                    If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then

                    Else
                        QUANTITE_AVANT_MOVEMENT = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("QUANTITE")
                    End If

                    CMUP = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("PRIX_ACHAT_HT")

                End If

                'INSERTION DU MOVEMENT DE STOCK
                If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, CODE_AGENCE, CODE_BORDEREAUX, QUANTITE_AVANT_MOVEMENT, CMUP) Then


                    'MISE A JOURS DES QUANTITE D'ARTICLES lors des entrées en magasins

                    Dim CODE_SOURCE As String = CODE_ARTICLE
                    Dim TABLE_SOURCE As String = "article"
                    Dim QUANTITE_ARTICLE As Double = QUANTITE_ENTREE
                    Dim CODE_DESTINATION As String = ""

                    If econom.gestionStockagesEtDeStockages(CODE_SOURCE, TABLE_SOURCE, QUANTITE_ARTICLE) Then

                    End If

                    'MISE A JOUR DU PRIX
                    econom.CoutMoyenUnitairePondereDunArticleQuelconque(CODE_ARTICLE)

                End If

            Next

            'Mise ajours du bon de commande ayant conduit au Bon de Réception pour que le bon de commande ne s'affiche plus lors de creation d'un bon de réception

            CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR = Trim(GunaTextBoxCodeBordereau.Text)

            ETAT_BORDEREAU = 3

            econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Entrée exceptionnelle réalisée avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Eceptionnal Entry realised successfully", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            TabControlEconomat.SelectedIndex = 1

        Else

            GunaComboBoxTypeBordereau.Enabled = True

            GunaButtonAnnulerBordereau.Visible = False

            permettreAjoutArticle()

            ETAT_BORDEREAU = 3

            CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR = GunaTextBoxCodeBordereau.Text
            econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
            Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim dialog_1 As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog_1 = MessageBox.Show("Authoriser un décaissement ", "Demande de decaissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                dialog_1 = MessageBox.Show("Authorise a cash out flow ", "Seek for Cash Out Flow", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            If dialog_1 = DialogResult.No Then
                'e.Cancel = True
            Else

                If Trim(GunaTextBoxMontantHTGeneralAchat.Text) = "" Then
                    GunaTextBoxMontantHTGeneralAchat.Text = 0
                End If

                Dim RECETTE_A_TRANSFERER As Double = GunaTextBoxMontantHTGeneralAchat.Text

                traitementDeRecettePourTransfertVersLaCaissePrincipale(RECETTE_A_TRANSFERER)

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Demande de decaissment envoyé avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Request for disbursement successfully send!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Dim message As String = "Demande de decaissement d'un montant de " & Format(RECETTE_A_TRANSFERER, "#,##0") & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                If GlobalVariable.actualLanguageValue = 0 Then
                    message = "Requesting for an amount of " & Format(RECETTE_A_TRANSFERER, "#,##0") & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                End If

                If Not GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_5").Equals("") Then
                    Functions.ultrMessageSimpleText(message, GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_5"))
                End If

            End If

            TabControlEconomat.SelectedIndex = 1

            GunaButtonController.Visible = False

            Functions.SiplifiedClearTextBox(Me)

            GunaDataGridViewLigneArticleCommande.Columns.Clear()

            PictureBoxNext1.Visible = False
            GunaLabelControleur.Visible = False
            GunaLabelEnregistreur.Visible = False
            GunaLabelVerification.Visible = False
            GunaButtonVerification.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bon validé avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Slip successfully validated", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        NewBonDeRequisition()

        Me.Cursor = Cursors.Default

        TabControlEconomat.SelectedIndex = 0

    End Sub

    Private Sub GunaTextBoxLibelleBordereau_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxLibelleBordereau.TextChanged

        If Trim(GunaTextBoxLibelleBordereau.Text) = "" Then
            'GunaButtonValider.Visible = False
            GunaButtonEnregistrer.Visible = False

            PictureBox1NextStage.Visible = False
            GunaButtonValider.Visible = False
            PictureBoxNext3.Visible = False
            GunaButtonCommander.Visible = False
        Else
            'GunaButtonValider.Visible = True
            GunaButtonEnregistrer.Visible = True
            GunaButtonController.Enabled = True
            GunaButtonEnregistrer.Enabled = True
        End If

    End Sub

    Public Sub NewBonDeRequisition()

        GunaTextBoxCodeArticle.Clear()

        GunaTextBoxPlusBasPrix.Text = 0
        GunaTextBoxPlusHautPrix.Text = 0

        GunaComboBoxTypeBordereau.Enabled = True

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelMagasin_1.Text = "Magasin De Réception"
        Else
            GunaLabelMagasin_1.Text = "Receiving Store"
        End If

        'GunaComboBoxTypeBordereau.SelectedIndex = 0

        Functions.SiplifiedClearTextBox(Me)

        '------------------- GENERATION DU CODE BU BON----------------------

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception Then

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "BR")

        ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "TI")

        ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "BRQ")

        ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_approvisi Then

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "BA")

        ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Then

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "BS")

        ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "SE")

        ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "EE")

        ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.list_du_marche Then
            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", "LM")
        End If
        '-------------------------------------------------------------------
        GunaDataGridViewLigneArticleCommande.Columns.Clear()

        GunaTextBoxCoutDuStock.Text = 0

        GunaTextBoxQuantite.Text = 1

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaButtonEnregistrer.Text = "Enregistrer"
        Else
            GunaButtonEnregistrer.Text = "Save"
        End If

        permettreAjoutArticle()

        GunaButtonEnregistrer.Enabled = True

        GunaButtonValider.Enabled = True
        GunaButtonCommander.Enabled = True

        GunaButtonController.Visible = False
        GunaButtonController.Enabled = True
        GunaLabelControleur.Visible = False

        GunaLabelCommandeur.Visible = False
        GunaLabelEnregistreur.Visible = False

        GunaLabelValideur.Visible = False

        PictureBoxNext1.Visible = False

        GunaLabelVerification.Visible = False
        GunaButtonVerification.Visible = False

        GunaLabelAnnuler.Visible = False
        GunaButtonAnnulerBordereau.Visible = False
        GunaButtonAnnulerBordereau.Enabled = True

        montantGlobalAchat = 0
        montantGlobalVente = 0

        Dim econom As New Economat()
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim CODE_USER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        'econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

    End Sub

    Private Sub emptyTempTable()

        Dim econom As New Economat()
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim CODE_USER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

    End Sub


    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click



        NewBonDeRequisition()

    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click

        NewBonDeRequisition()

        GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition

        TabControlEconomat.SelectedIndex = 1

        If GunaDataGridViewLigneArticleCommande IsNot Nothing Then

            If GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then
                GunaDataGridViewLigneArticleCommande.Columns(0).Visible = False 'false
                GunaDataGridViewLigneArticleCommande.Columns(1).Visible = False 'false
            End If

        End If


    End Sub

    Private Sub GunaAdvenceButton18_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton18.Click

        GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_reception

        TabControlEconomat.SelectedIndex = 1

    End Sub

    Private Sub GunaAdvenceButton20_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton20.Click

        GlobalVariable.ficheTechnique = "fiche"
        ArticleForm.TopMost() = True
        ArticleForm.Show()
        'ArticleForm.GunaLabelGestCompteGeneraux.Text = "Fiche Technique"

    End Sub

    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        TabControlEconomat.SelectedIndex = 0
        emptyTempTable()
    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        GunaDateTimePicker1.Value = GlobalVariable.DateDeTravail.AddDays(-1).ToShortDateString
        GunaDateTimePicker2.Value = GlobalVariable.DateDeTravail.ToShortDateString

        TabControlEconomat.SelectedIndex = 2
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        nettoyageDuDataGrid()

        GunaRadioButtonParBordero.Checked = True
        GunaRadioButtonParBordero.Visible = True

        GunaRadioButtonParTypeEtDate.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True


        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "BONS DE COMMANDES"
            GunaRadioButtonParBordero.Text = "D'UN BON"
            GunaRadioButtonParTypeEtDate.Text = "PAR TYPE DE BON ET DATE"
        Else
            LabelTypeDeRapport.Text = "ORDER SLIP"
            GunaRadioButtonParBordero.Text = "A SLIP"
            GunaRadioButtonParTypeEtDate.Text = "PER SLIP TYPE AND DATE"
        End If

        GlobalVariable.typeRapportEconmat = "BC"

        GunaComboBoxTypeBorderoRapport.Visible = False

        GunaDateTimePicker1.Visible = False
        GunaDateTimePicker2.Visible = False
        GunaLabelDu.Visible = False
        GunaLabelAu.Visible = False
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = False

    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click


        nettoyageDuDataGrid()

        GunaRadioButtonParBordero.Checked = True
        GunaRadioButtonParBordero.Visible = True

        GunaRadioButtonParTypeEtDate.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        GlobalVariable.typeRapportEconmat = "BR"

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "BONS DE RECEPTIONS"
            GunaRadioButtonParBordero.Text = "D'UN BON"
            GunaRadioButtonParTypeEtDate.Text = "PAR TYPE DE BON ET DATE"
        Else
            LabelTypeDeRapport.Text = "DELIVERY SLIP"
            GunaRadioButtonParBordero.Text = "A SLIP"
            GunaRadioButtonParTypeEtDate.Text = "PER SLIP TYPE AND DATE"
        End If
        GunaDateTimePicker1.Visible = False
        GunaDateTimePicker2.Visible = False
        GunaLabelDu.Visible = False
        GunaLabelAu.Visible = False
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = False

    End Sub

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click

        nettoyageDuDataGrid()
        GunaRadioButtonParBordero.Checked = True
        GunaRadioButtonParBordero.Visible = True
        GunaRadioButtonParBordero.Text = "D'UN BON"
        GunaRadioButtonParTypeEtDate.Text = "PAR TYPE DE BON ET DATE"

        GunaRadioButtonParTypeEtDate.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "TRANSFERT INTER MAGASINS"
        GlobalVariable.typeRapportEconmat = "TIM"

        GunaDateTimePicker1.Visible = False
        GunaDateTimePicker2.Visible = False
        GunaLabelDu.Visible = False
        GunaLabelAu.Visible = False
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = False

    End Sub

    Private Sub GunaButton11_Click(sender As Object, e As EventArgs) Handles GunaButton11.Click

        nettoyageDuDataGrid()
        GunaRadioButtonParBordero.Text = "FICHE DE PRODUIT (ARTICLE / MATIERE)"

        GunaRadioButtonParTypeEtDate.Visible = False

        GunaRadioButtonParBordero.Visible = True
        GunaTextBoxElementRapport.Visible = True

        GunaRadioButtonParBordero.Checked = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "FICHE DES PRODUITS (ARTICLES/MATIERE)"

        GlobalVariable.typeRapportEconmat = "FPAM"

        GunaDateTimePicker1.Visible = False
        GunaDateTimePicker2.Visible = False
        GunaLabelDu.Visible = False
        GunaLabelAu.Visible = False
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = False

    End Sub

    Private Sub GunaButton4_Click_1(sender As Object, e As EventArgs)

        GunaRadioButtonParBordero.Checked = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "PRODUCTIONS DU RESTAURANT"
        GlobalVariable.typeRapportEconmat = "pr"
    End Sub

    Private Sub GunaButton12_Click(sender As Object, e As EventArgs) Handles GunaButton12.Click

        nettoyageDuDataGrid()
        GunaRadioButtonParBordero.Checked = True
        GunaRadioButtonParBordero.Visible = True

        'GunaDateTimePicker1.Visible = True
        'GunaDateTimePicker2.Visible = True
        'GunaLabelDu.Visible = True
        'GunaLabelAu.Visible = True

        GunaRadioButtonParBordero.Text = "ARTICLE OU MATIERE"
        GunaRadioButtonParTypeEtDate.Text = "ARTICLES OU MATIERES"

        GunaRadioButtonParTypeEtDate.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "FICHE DE STOCKS"

        GlobalVariable.typeRapportEconmat = "FS"

    End Sub

    Private Sub GunaButtonEtatDesChambres_Click(sender As Object, e As EventArgs) Handles GunaButtonInventaire.Click

        GunaComboBoxListeDesMagasinPourInventaire.SelectedIndex = 0

        nettoyageDuDataGrid()

        GunaRadioButtonParTypeEtDate.Checked = True
        GunaRadioButtonParTypeEtDate.Visible = False

        GunaButtonImpirmerRapportEconomat.Visible = True

        GunaRadioButtonParBordero.Visible = False
        GunaTextBoxElementRapport.Visible = False

        GunaLabelDu.Visible = False
        GunaDateTimePicker1.Visible = False
        GunaDateTimePicker2.Visible = False
        GunaLabelAu.Visible = False

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True

        LabelTypeDeRapport.Text = "INVENTAIRES"

        GlobalVariable.typeRapportEconmat = "INV"

        GunaLabel2.Visible = True
        GunaComboBoxListeDesMagasinPourInventaire.Visible = True

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click

        nettoyageDuDataGrid()
        GunaRadioButtonParBordero.Checked = True

        GunaRadioButtonParBordero.Text = "ARTICLE OU MATIERE"
        GunaRadioButtonParTypeEtDate.Text = "TOUS LES ARTICLES OU TOUTES LES MATIERES"

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "MOVEMENTS DE STOCK"

        GlobalVariable.typeRapportEconmat = "MS"

    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButtonImpirmerRapportEconomat.Click

        Dim entreeSortie As Integer = 0
        Dim globalIndividuel As Integer = 0

        If Not GlobalVariable.typeRapportEconmat = "INV" Then
            GunaButtonImpirmerRapportEconomat.Visible = False
        End If

        GunaButtonImpirmerRapportEconomat.Visible = True

        Dim getQuery As String = ""
        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable


        Dim dateDebut_ As Date = GunaDateTimePicker1.Value.ToShortDateString
        Dim dateFin_ As Date = GunaDateTimePicker2.Value.ToShortDateString

        If GlobalVariable.typeRapportEconmat = "PC" Then 'PRODUCTION DE LA CUISINE

            If Trim(GunaTextBoxCodeElementRapport.Text) = "" Then

                'Pour l'ensemble des articles
                getQuery = "SELECT `CODE_ARTICLE`, `NOM_ARTICLE` AS ARTICLE, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE` AS QUANTITE, `DATE_PREPARATION`, `ETAT`, `PRIX_VENTE`
                            FROM `fiche_technique_article_prepare` 
                            WHERE ETAT=@ETAT AND DATE_PREPARATION <= '" & dateFin_.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >= '" & dateDebut_.ToString("yyyy-MM-dd") & "' "

                Dim Command As New MySqlCommand(getQuery, GlobalVariable.connect)
                Command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1
                adapter.SelectCommand = Command

                adapter.Fill(table)

            Else

                Dim CODE_ARTICLE As String = Trim(GunaTextBoxCodeElementRapport.Text)
                'Pour un article specifique
                getQuery = "SELECT `CODE_ARTICLE`, `NOM_ARTICLE` AS ARTICLE, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE` AS QUANTITE, `DATE_PREPARATION`, `ETAT`, `PRIX_VENTE` 
                            FROM `fiche_technique_article_prepare` 
                            WHERE ETAT=@ETAT AND DATE_PREPARATION <= '" & dateFin_.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >= '" & dateDebut_.ToString("yyyy-MM-dd") & "' AND CODE_ARTICLE=@CODE_ARTICLE"

                Dim Command As New MySqlCommand(getQuery, GlobalVariable.connect)
                Command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
                Command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1
                adapter.SelectCommand = Command
                adapter.Fill(table)

            End If

            If table.Rows.Count > 0 Then
                Impression.productionDelaCuisine(table, dateDebut_, dateFin_, "fiche_technique_article_prepare", "PRODUCTION DE LA CUISINE")
            Else
                MessageBox.Show("Aucun élément à Imprimer ! ", "Documents", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf GlobalVariable.typeRapportEconmat = "CPC" Then

            'COMMANDE PREPAREES DE LA CUISINE

            Dim FillingListquery2 = "SELECT `CODE_ARTICLE`, `NOM_ARTICLE` AS ARTICLE, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE` AS QUANTITE, `DATE_PREPARATION`, `ETAT`, `RANDOM_CODE`, `PRIX_VENTE` FROM `commande_cuisine` WHERE ETAT=@ETAT AND DATE_PREPARATION <= '" & dateFin_.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >= '" & dateDebut_.ToString("yyyy-MM-dd") & "' "

            Dim commandList2 As New MySqlCommand(FillingListquery2, GlobalVariable.connect)
            commandList2.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1

            Dim adapterList2 As New MySqlDataAdapter(commandList2)

            adapterList2.Fill(table)

            If table.Rows.Count > 0 Then
                Impression.productionDelaCuisine(table, dateDebut_, dateFin_, "commande_cuisine", "COMMANDES PREPAREES DE LA CUISINE")
            End If

        ElseIf GlobalVariable.typeRapportEconmat = "RECAP_CUISINE" Then

            Dim FillingListquery2 = "SELECT `CODE_ARTICLE`, `NOM_ARTICLE` AS ARTICLE, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE` AS QUANTITE, `DATE_PREPARATION`, `ETAT`, `PRIX_VENTE` FROM `commande_cuisine` WHERE ETAT=@ETAT AND DATE_PREPARATION <= '" & dateFin_.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >= '" & dateDebut_.ToString("yyyy-MM-dd") & "' "

            Dim commandList2 As New MySqlCommand(FillingListquery2, GlobalVariable.connect)
            commandList2.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1

            Dim adapterList2 As New MySqlDataAdapter(commandList2)

            adapterList2.Fill(table)

            Dim FillingListquery02 = "SELECT `CODE_ARTICLE`, `NOM_ARTICLE` AS ARTICLE, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE` AS QUANTITE, `DATE_PREPARATION`, `ETAT`, `PRIX_VENTE` FROM `fiche_technique_article_prepare` WHERE ETAT=@ETAT AND DATE_PREPARATION <= '" & dateFin_.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >= '" & dateDebut_.ToString("yyyy-MM-dd") & "' "

            Dim commandList02 As New MySqlCommand(FillingListquery02, GlobalVariable.connect)
            commandList02.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1

            Dim adapterList02 As New MySqlDataAdapter(commandList02)
            Dim table02 As New DataTable
            adapterList02.Fill(table02)

            table.Merge(table02)

            If table.Rows.Count > 0 Then

                Functions.deleteAll("production_cuisine")

                Dim NOM_ARTICLE As String = ""
                Dim PRIX_VENTE As Double = 0
                Dim CODE_ARTICLE_FICHE As String = ""
                Dim NOMBRE_DE_PORTION As Integer = 0
                Dim CODE_FICHE_TECHNIQUE As String = ""
                Dim DATE_PREPARATION As Date

                For i = 0 To table.Rows.Count - 1

                    NOM_ARTICLE = table.Rows(i)("ARTICLE")
                    PRIX_VENTE = table.Rows(i)("PRIX_VENTE")
                    CODE_ARTICLE_FICHE = table.Rows(i)("CODE_ARTICLE")
                    NOMBRE_DE_PORTION = table.Rows(i)("QUANTITE")
                    CODE_FICHE_TECHNIQUE = table.Rows(i)("CODE_FICHE_TECHNIQUE")
                    DATE_PREPARATION = table.Rows(i)("DATE_PREPARATION")

                    Dim article As New Article()

                    Dim tableName As String = "production_cuisine"

                    'Insetion des lignes pour genration du rapport des preparation en cuisine
                    article.ficheTechniqueArticlePrepare(CODE_ARTICLE_FICHE, NOM_ARTICLE, CODE_FICHE_TECHNIQUE, NOMBRE_DE_PORTION, DATE_PREPARATION, PRIX_VENTE, tableName)

                Next

                'SELECTION DE DIFFERENT ARTICLES DE LA CUISINE

                Dim FillingListquery002 = "SELECT DISTINCT `CODE_ARTICLE` FROM `production_cuisine` WHERE DATE_PREPARATION <= '" & dateFin_.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >= '" & dateDebut_.ToString("yyyy-MM-dd") & "' "

                Dim commandList002 As New MySqlCommand(FillingListquery002, GlobalVariable.connect)

                Dim adapterList002 As New MySqlDataAdapter(commandList002)

                Dim table002 As New DataTable
                adapterList002.Fill(table002)

                If table002.Rows.Count > 0 Then
                    Impression.productionDelaCuisine(table002, dateDebut_, dateFin_, "production_cuisine", "CUMUL PREPARATION-COMMANDE DE LA CUISINE", "cumul")
                End If

            End If

        ElseIf GlobalVariable.typeRapportEconmat = "INV" Then

            Dim FillingListquery As String = "SELECT CODE_ARTICLE AS 'CODE ARTICLE', DESIGNATION_FR AS 'DESIGNATION', QUANTITE As STOCK, COUT_U_MOYEN_PONDERE AS 'PRIX UNITAIRE', PRIX_ACHAT_HT As 'COUT MOYEN UNITAIRE' FROM article WHERE METHODE_SUIVI_STOCK =@METHODE_SUIVI_STOCK ORDER BY DESIGNATION_FR ASC"

            Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
            commandList.Parameters.Add("@METHODE_SUIVI_STOCK", MySqlDbType.VarChar).Value = "Suivi simple"

            Dim adapterList As New MySqlDataAdapter(commandList)
            Dim tousLesArticles As New DataTable()

            adapterList.Fill(tousLesArticles)

            If tousLesArticles.Rows.Count > 0 Then
                Impression.Inventaire(tousLesArticles)
            End If

        ElseIf GlobalVariable.typeRapportEconmat = "BC" Or GlobalVariable.typeRapportEconmat = "BR" Or GlobalVariable.typeRapportEconmat = "BRQ" Or GlobalVariable.typeRapportEconmat = "TIM" Or GlobalVariable.typeRapportEconmat = "BS" Then

            'BON DE COMMANDE, BON DE RECEPTION, BON DE REQUISITION,TRANSFERT INTER MAGASIN, INVENTAIRE
            Dim TYPE_BORDEREAUX As String = ""
            Dim existQuery As String = ""

            If GlobalVariable.typeRapportEconmat = "BC" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_cmd
            ElseIf GlobalVariable.typeRapportEconmat = "BR" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_reception
            ElseIf GlobalVariable.typeRapportEconmat = "BS" Then
                TYPE_BORDEREAUX = GlobalVariable.sortie
            ElseIf GlobalVariable.typeRapportEconmat = "BRQ" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_requisition
            ElseIf GlobalVariable.typeRapportEconmat = "TIM" Then
                TYPE_BORDEREAUX = GlobalVariable.transfert_inter
            End If

            If Not Trim(GunaTextBoxCodeElementRapport.Text) = "" Then
                'RAPPORT INDIVIDUEL
                existQuery = "SELECT bordereaux.CODE_BORDEREAUX, `TYPE_BORDEREAUX`, `REF_BORDEREAUX`, `LIBELLE_BORDEREAUX`, `NON_TIERS`, `DATE_BORDEREAU`, `OBSERVATIONS`, `MONTANT_HT`, `MONTANT_TAXE`, `MONTANT_TTC`, `MONTANT_PAYER`, DESIGNATION_FR, ligne_bordereaux.QUANTITE_ENTREE_STOCK, PRIX_UNITAIRE_HT, PRIX_TOTAL_HT FROM `bordereaux`, `ligne_bordereaux`, article WHERE bordereaux.CODE_BORDEREAUX=@CODE_BORDEREAUX AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND bordereaux.CODE_BORDEREAUX= ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE =ligne_bordereaux.CODE_ARTICLE"

            End If

            Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

            command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = GunaTextBoxCodeElementRapport.Text
            command.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX

            adapter.SelectCommand = command
            adapter.Fill(table)

            'IMPRESSION DES BORDEREAU

            Impression.Bon(table)

        ElseIf GlobalVariable.typeRapportEconmat = "FS" Or GlobalVariable.typeRapportEconmat = "FPAM" Then 'FICHE DE STOCK

            'FICHE DE STOCK : FS
            'FICHE DES ARTICLES ET MATIERES : FPAM

            Dim stock = 0

            Dim DateDebut As Date = GunaDateTimePicker1.Value.ToShortDateString
            Dim DateFin As Date = GunaDateTimePicker2.Value.ToShortDateString

            If Trim(GunaTextBoxCodeElementRapport.Text) = "" Then ' FICHE DE STOCK UNIQUEMENT / MOUVEMENT DES STOCKS
                'Pour l'ensemble des articles

                'Dim existQuery As String = "SELECT * FROM Article WHERE METHODE_SUIVI_STOCK =@METHODE_SUIVI_STOCK ORDER BY DESIGNATION_FR ASC"
                'SELCTION UNIQUEMENT DES ARTICLES EN MOUVEMENT DANS CET INTERVAL

                Dim existQuery As String = "SELECT DISTINCT article.CODE_ARTICLE, `REFERENCE`, `CODE_BARRE`, `DESIGNATION_FR`, `DESIGNATION_EN`, `DESCRIPTION`, `CODE_GROUPE_ARTICLE`, `CODE_FAMILLE`, `CODE_SOUS_FAMILLE`, `CODE_SOUS_SOUS_FAMILLE`, `METHODE_SUIVI_STOCK`, `TYPE_ARTICLE`, `CONDITIONNEMENT`, `SEUIL_PRIX_VENTE_HT`, `PRIX_ACHAT_HT`, `COUT_U_MOYEN_PONDERE`, `PRIX_ACHAT_TTC`, `PRIX_VENTE_HT`, `PRIX_VENTE_TTC`, `PRIX_VENTE1_HT`, `PRIX_VENTE1_TTC`, `PRIX_VENTE2_HT`, `PRIX_VENTE2_TTC`, `PRIX_VENTE3_HT`, `PRIX_VENTE3_TTC`, `PRIX_VENTE4_HT`, `PRIX_VENTE4_TTC`, `PRIX_VENTE5_HT`, `PRIX_VENTE5_TTC`, `PRIX_VENTE6_HT`, `PRIX_VENTE6_TTC`, `PRIX_VENTE7_HT`, `PRIX_VENTE7_TTC`, `PRIX_VENTE8_HT`, `PRIX_VENTE8_TTC`, `PRIX_VENTE9_HT`, `PRIX_VENTE9_TTC`, `POURCENTAGE_REMISE`, `TAUX_EXONERATION_TVA`, `SEUIL_REAPPROVISIONNEMENT`, `NUMERO_SERIE`, `ARTICLE_COMPOSE`, `ARTICLE_LIE`, `ARTICLE_RECONDITIONNABLE`, `APPARAIT_SUR_FICHE_CLIENT`, `ARTICLE_PERISSABLE`, `ARTICLE_GERE_PAR_LOT`, `DATE_DEBUT_PROMOTION`, `POURCENTAGE_REMISE_PROMOTION`, `DATE_FIN_PROMOTION`, `CHEMIN_PHOTO`, `DATE_CREATION`,`DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `ARTICLE_A_REMISE`, `CODE_CLE`, `DELEGUE`, `SEUIL_PRIX_VENTE_TTC`, `TX_LIMIT`, `DAILY_LIMIT`, `TAUX_TVA`, `SPECIALITE_ARTICLE`, `ARTICLE_MULTIPRIX`, article.CODE_AGENCE, `QUANTITE`, `TYPE`, `UNITE_COMPTAGE`, `PRIX_PAR_PETITE_UNITE`, `STOCK_FIN_DU_MOIS`, `CARTE`, `CODE_CONSO`, `PRIX_CONSO`, `CONTENANCE`, `BOISSON`, `PRIX_CONSO2`, `PRIX_CONSO3`, `PRIX_CONSO4`, `VISIBLE` FROM Article, mouvement_stock WHERE METHODE_SUIVI_STOCK =@METHODE_SUIVI_STOCK AND DATE_MOUVEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_MOUVEMENT >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND mouvement_stock.CODE_ARTICLE = article.CODE_ARTICLE ORDER BY DESIGNATION_FR ASC"

                Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

                command.Parameters.Add("@METHODE_SUIVI_STOCK", MySqlDbType.VarChar).Value = "Suivi simple"
                adapter.SelectCommand = command
                adapter.Fill(table)

                If GlobalVariable.typeRapportEconmat = "FS" Then

                    If table.Rows.Count > 0 Then
                        Impression.ficheDeStock(table, GunaDateTimePicker1.Value, GunaDateTimePicker2.Value)
                    Else
                        MessageBox.Show("Aucune Fiche à Imprimer ! ", "Documents", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            Else

                Dim CODE_ARTICLE As String = Trim(GunaTextBoxCodeElementRapport.Text)

                Dim existQuery As String = "SELECT * FROM Article WHERE CODE_ARTICLE =@CODE_ARTICLE AND CODE_AGENCE=@CODE_AGENCE "

                Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
                command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                adapter.SelectCommand = command
                adapter.Fill(table)

                If table.Rows.Count > 0 Then

                    If table.Rows.Count > 0 Then

                        If GlobalVariable.typeRapportEconmat = "FS" Then
                            Impression.ficheDeStock(table, GunaDateTimePicker1.Value, GunaDateTimePicker2.Value)
                        ElseIf GlobalVariable.typeRapportEconmat = "FPAM" Then
                            Impression.ficheProduitArticleOuMatiere(table)
                        End If

                    Else
                        MessageBox.Show("Aucun élément à Imprimer ! ", "Documents", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            End If

        ElseIf GlobalVariable.typeRapportEconmat = "FPT" Then

            'GunaDataGridViewBorderoByTypeEtDate.Visible = True

            Dim CODE_FICHE_TECHNIQUE As String = GunaTextBoxCodeElementRapport.Text

            Dim ficheTechnique As DataTable = Functions.getElementByCode(CODE_FICHE_TECHNIQUE, "fiche_technique", "CODE_FICHE_TECHNIQUE")

            If ficheTechnique.Rows.Count > 0 Then

                Dim CTR As Double = ficheTechnique.Rows(0)("CTR")
                Dim PV As Double = ficheTechnique.Rows(0)("PV")
                Dim CRPPP As Double = ficheTechnique.Rows(0)("CRPPP")
                Dim PMI As Double = ficheTechnique.Rows(0)("PMI")
                Dim CM As Double = ficheTechnique.Rows(0)("CM")
                Dim CRPPV As Double = ficheTechnique.Rows(0)("CRPPV")
                Dim MB As Double = ficheTechnique.Rows(0)("MB")
                Dim TM As Double = ficheTechnique.Rows(0)("TM")
                Dim NOM_FICHE As String = GunaTextBoxElementRapport.Text
                Dim NOMBRE_DE_PORTION = 0
                Dim PRIX_VENTE = 0

                'GunaDataGridViewBorderoByTypeEtDate.Visible = FALSE

                Impression.ficheTechnique(GunaDataGridViewBorderoByTypeEtDate, NOM_FICHE, CODE_FICHE_TECHNIQUE, NOMBRE_DE_PORTION, PRIX_VENTE, CTR, PV, CRPPP, PMI, CM, CRPPV, MB, TM)

            End If

        ElseIf GlobalVariable.typeRapportEconmat = "ES" Then 'LISTE DES ENTREES / SORTIES

            If GunaComboBoxEntreSortie.SelectedIndex >= 0 Then

                If GunaComboBoxEntreSortie.SelectedIndex = 0 Then
                    'GESTION DES ENTREES (BON DE RECEPTION)
                    entreeSortie = 0
                Else
                    'GESTION DES SORTIES (BON DE SORTIE ET SORTIE EXCEPETIONNELLE)
                    entreeSortie = 1
                End If

            End If

            If GunaComboBoxGlobalIndividuel.SelectedIndex >= 0 Then

                If GunaComboBoxGlobalIndividuel.SelectedIndex = 0 Then
                    'AFFICHAGE INDIVIDUEL DONC VISIBILITE DE CHAQUE LIGNE DURANT LA PERIODE
                    globalIndividuel = 0
                Else
                    'AFFICHAGE GLOBAL DONC VISIBILITE GLOBALE (RESUME) DE CHAQUE LIGNE DURANT LA PERIODE
                    globalIndividuel = 1
                End If

            End If

            If (globalIndividuel >= 0 And globalIndividuel <= 1) And (entreeSortie >= 0 And entreeSortie <= 1) Then
                'DEMANDE A AFFICHER LES ENTREES OU SORTIES GLOBALES OU INDIVIDUELLE DONC DETAILLEES

                Dim title As String = ""

                If entreeSortie = 0 Then
                    title = "ENTREES PAR MAGASIN"
                Else
                    title = "SORTIES PAR MAGASIN"
                End If

                Impression.affichageDesEntreesSortiePeriodiqueImpression(GunaDateTimePicker1.Value.ToShortDateString, GunaDateTimePicker2.Value.ToShortDateString, entreeSortie, globalIndividuel, title, entreeSortieOuAchatPeriodique)

            End If

        ElseIf GlobalVariable.typeRapportEconmat = "AP" Then 'LISTE DES ACHATS PERIODIQUES

            Dim title As String = "ACHATS PERIODIQUE"

            If GunaComboBoxGlobalIndividuel.SelectedIndex >= 0 Then

                If GunaComboBoxGlobalIndividuel.SelectedIndex = 0 Then
                    'AFFICHAGE INDIVIDUEL DONC VISIBILITE DE CHAQUE LIGNE DURANT LA PERIODE
                    globalIndividuel = 0
                Else
                    'AFFICHAGE GLOBAL DONC VISIBILITE GLOBALE (RESUME) DE CHAQUE LIGNE DURANT LA PERIODE
                    globalIndividuel = 1
                End If

            End If

            Impression.affichageDesEntreesSortiePeriodiqueImpression(GunaDateTimePicker1.Value.ToShortDateString, GunaDateTimePicker2.Value.ToShortDateString, entreeSortie, globalIndividuel, title, entreeSortieOuAchatPeriodique)

        End If

        GunaTextBoxElementRapport.Clear()

        GunaTextBoxCodeElementRapport.Clear()

    End Sub

    'Choix du rapport a produire
    Private Sub GunaTextBoxElementRapport_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxElementRapport.TextChanged

        GunaDataGridViewRapport.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""
        Dim TYPE_BORDEREAUX As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxElementRapport.Text).Equals("") Then

            GunaDataGridViewRapport.Visible = False

            LabelQuantiteEnMagasinSource.Visible = False
            GunaTextBoxQunatiteDansLeMagasinProvenance.Clear()
            GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

        End If

        'Determining from which table to search for the articles

        If GlobalVariable.typeRapportEconmat = "pr" Then

            getArticleQuery = "SELECT DESIGNATION_FR 
            FROM article,fiche_technique_article_prepare 
            WHERE article.CODE_ARTICLE=fiche_technique_article_prepare.CODE_ARTILCE 
            AND DESIGNATION_FR Like '%" & Trim(GunaTextBoxElementRapport.Text) & "%' 
            AND TYPE=@TYPE ORDER BY DESIGNATION_FR ASC"

            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"
            adapter.SelectCommand = Command
            adapter.Fill(table)

        ElseIf GlobalVariable.typeRapportEconmat = "FPT" Then
            'FICHE TECHNIQUE DE PLAT
            getArticleQuery = "SELECT LIBELLE_FICHE 
            FROM fiche_technique 
            WHERE LIBELLE_FICHE LIKE '%" & Trim(GunaTextBoxElementRapport.Text) & "%' ORDER BY LIBELLE_FICHE ASC"

            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            adapter.SelectCommand = Command
            adapter.Fill(table)

        ElseIf GlobalVariable.typeRapportEconmat = "PC" Then
            'PREPARATION DE LA CUISINE
            getArticleQuery = "SELECT fiche_technique_article_prepare.NOM_ARTICLE, LIBELLE_FICHE
            FROM fiche_technique_article_prepare, fiche_technique
            WHERE fiche_technique_article_prepare.NOM_ARTICLE LIKE '%" & Trim(GunaTextBoxElementRapport.Text) & "%' AND fiche_technique.CODE_FICHE_TECHNIQUE = fiche_technique_article_prepare.CODE_FICHE_TECHNIQUE ORDER BY LIBELLE_FICHE ASC"

            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            adapter.SelectCommand = Command
            adapter.Fill(table)

        ElseIf GlobalVariable.typeRapportEconmat = "BRQ" Or GlobalVariable.typeRapportEconmat = "BC" Or GlobalVariable.typeRapportEconmat = "BR" Or GlobalVariable.typeRapportEconmat = "TIM" Or GlobalVariable.typeRapportEconmat = "BS" Then
            'BON DE REQUISITION, 'BON DE COMMANDE, 'BON DE SORTIE, 'BON DE RECEPTION, 'TRANSFERT INTER MAGASIN

            If GlobalVariable.typeRapportEconmat = "BC" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_cmd
            ElseIf GlobalVariable.typeRapportEconmat = "BR" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_reception
            ElseIf GlobalVariable.typeRapportEconmat = "BS" Then
                TYPE_BORDEREAUX = GlobalVariable.sortie
            ElseIf GlobalVariable.typeRapportEconmat = "BRQ" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_requisition
            ElseIf GlobalVariable.typeRapportEconmat = "TIM" Then
                TYPE_BORDEREAUX = GlobalVariable.transfert_inter
            End If

            getArticleQuery = "SELECT `CODE_BORDEREAUX`, `LIBELLE_BORDEREAUX` FROM `bordereaux` WHERE CODE_BORDEREAUX Like '%" & Trim(GunaTextBoxElementRapport.Text) & "%' AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX OR LIBELLE_BORDEREAUX Like '%" & Trim(GunaTextBoxElementRapport.Text) & "%' AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX"

            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            Command.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX
            adapter.SelectCommand = Command
            adapter.Fill(table)

        ElseIf GlobalVariable.typeRapportEconmat = "FS" Or GlobalVariable.typeRapportEconmat = "MS" Or GlobalVariable.typeRapportEconmat = "FPAM" Or GlobalVariable.typeRapportEconmat = "INV" Then
            'FICHE DE STOCK, MOVEMENT DE STOCK, FICHE PRODUIT (ARTICLE/MATIERE), INVENTAIRE
            getArticleQuery = "SELECT DESIGNATION_FR FROM article  
            WHERE DESIGNATION_FR Like '%" & Trim(GunaTextBoxElementRapport.Text) & "%' 
            ORDER BY DESIGNATION_FR ASC"

            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            'Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"
            adapter.SelectCommand = Command
            adapter.Fill(table)

        End If

        If (table.Rows.Count > 0) Then
            GunaDataGridViewRapport.DataSource = table
        Else
            GunaDataGridViewRapport.Columns.Clear()

            GunaDataGridViewRapport.Visible = False
        End If

        If GunaTextBoxElementRapport.Text = "" Then
            GunaDataGridViewRapport.Visible = False
        End If


    End Sub

    Private Sub GunaDataGridViewRapport_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRapport.CellClick

        GunaDataGridViewRapport.Visible = False

        Dim bordero As New DataTable

        If e.RowIndex >= 0 Then

            GunaButtonImpirmerRapportEconomat.Visible = True

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewRapport.Rows(e.RowIndex)

            If GlobalVariable.typeRapportEconmat = "BRQ" Or GlobalVariable.typeRapportEconmat = "BC" Or GlobalVariable.typeRapportEconmat = "BR" Or GlobalVariable.typeRapportEconmat = "TIM" Or GlobalVariable.typeRapportEconmat = "BS" Then

                Dim query As String = "SELECT * FROM bordereaux WHERE LIBELLE_BORDEREAUX=@LIBELLE_BORDEREAUX OR CODE_BORDEREAUX=@CODE_BORDEREAUX ORDER BY LIBELLE_BORDEREAUX ASC"
                Dim adapter As New MySqlDataAdapter
                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = Trim(row.Cells("CODE_BORDEREAUX").Value.ToString)
                command.Parameters.Add("@LIBELLE_BORDEREAUX", MySqlDbType.VarChar).Value = Trim(row.Cells("LIBELLE_BORDEREAUX").Value.ToString)

                adapter.SelectCommand = command
                adapter.Fill(bordero)

                If (bordero.Rows.Count > 0) Then

                    GunaTextBoxCodeElementRapport.Text = bordero.Rows(0)("CODE_BORDEREAUX")
                    GunaTextBoxElementRapport.Text = bordero.Rows(0)("LIBELLE_BORDEREAUX")

                    GunaDataGridViewRapport.Visible = False

                End If

            ElseIf GlobalVariable.typeRapportEconmat = "FS" Or GlobalVariable.typeRapportEconmat = "MS" Or GlobalVariable.typeRapportEconmat = "FPAM" Then

                Dim query As String = "SELECT * FROM article WHERE DESIGNATION_FR=@DESIGNATION_FR ORDER BY DESIGNATION_FR ASC"
                Dim adapter As New MySqlDataAdapter
                Dim Article As New DataTable
                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                command.Parameters.Add("@DESIGNATION_FR", MySqlDbType.VarChar).Value = Trim(row.Cells("DESIGNATION_FR").Value.ToString)

                adapter.SelectCommand = command
                adapter.Fill(Article)

                If (Article.Rows.Count > 0) Then

                    GunaTextBoxCodeElementRapport.Text = Article.Rows(0)("CODE_ARTICLE")
                    GunaTextBoxElementRapport.Text = Article.Rows(0)("DESIGNATION_FR")

                    GunaDataGridViewRapport.Visible = False

                End If

            ElseIf GlobalVariable.typeRapportEconmat = "FPT" Or GlobalVariable.typeRapportEconmat = "PC" Then
                'FICHE TECHNIQUE DE PLAT ET FICHE DE PRODUCTION DU RESTAURANT
                Dim query As String = ""

                If GlobalVariable.typeRapportEconmat = "FPT" Then
                    query = "SELECT * FROM fiche_technique WHERE LIBELLE_FICHE=@LIBELLE_FICHE ORDER BY LIBELLE_FICHE ASC"
                ElseIf GlobalVariable.typeRapportEconmat = "PC" Then
                    query = "SELECT * FROM fiche_technique_article_prepare WHERE LIBELLE_FICHE=@LIBELLE_FICHE ORDER BY LIBELLE_FICHE ASC"
                End If

                Dim adapter As New MySqlDataAdapter
                Dim Article As New DataTable
                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                command.Parameters.Add("@LIBELLE_FICHE", MySqlDbType.VarChar).Value = Trim(row.Cells("LIBELLE_FICHE").Value.ToString)

                adapter.SelectCommand = command
                adapter.Fill(Article)

                If (Article.Rows.Count > 0) Then

                    'GunaDataGridViewBorderoByTypeEtDate.Visible = True

                    GunaTextBoxCodeElementRapport.Text = Article.Rows(0)("CODE_FICHE_TECHNIQUE")
                    Dim CODE_FICHE_TECHNIQUE As String = Article.Rows(0)("CODE_FICHE_TECHNIQUE")
                    GunaTextBoxElementRapport.Text = Article.Rows(0)("LIBELLE_FICHE")

                    Dim ficheTechniqueElements As New Article()

                    GunaDataGridViewBorderoByTypeEtDate.DataSource = ficheTechniqueElements.elementsDuneFicheTechnique(CODE_FICHE_TECHNIQUE)

                    GunaDataGridViewBorderoByTypeEtDate.Columns("QUANTITE UTILISE").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("QUANTITE UTILISE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GunaDataGridViewBorderoByTypeEtDate.Columns("QUANTITE UTILISE").DefaultCellStyle.Format = "n2"

                    GunaDataGridViewBorderoByTypeEtDate.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("COUT DE REVIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    GunaDataGridViewBorderoByTypeEtDate.Columns("COUT DE REVIENT").DefaultCellStyle.Format = "n2"

                    GunaDataGridViewBorderoByTypeEtDate.Columns("COUT ACHAT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("COUT ACHAT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    GunaDataGridViewBorderoByTypeEtDate.Columns("COUT ACHAT").DefaultCellStyle.Format = "n2"

                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE / PORTION").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE / PORTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE / PORTION").DefaultCellStyle.Format = "n2"

                    GunaDataGridViewBorderoByTypeEtDate.Columns("CODE ARTICLE").Visible = False

                    GunaDataGridViewRapport.Visible = False

                End If

            End If

        Else

            GunaButtonImpirmerRapportEconomat.Visible = False

        End If

    End Sub

    'CHANGEMENT DU 
    Private Sub GunaComboBoxMagasinSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxMagasin_1.SelectedIndexChanged

        Dim CODE_MAGASIN As String = ""

        If GunaComboBoxMagasin_1.SelectedIndex >= 0 Then
            CODE_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString()
        End If

        Dim magasinActuel As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

        If magasinActuel.Rows.Count > 0 Then
            GunaTextBoxSuivreArticleNonSuivi.Text = magasinActuel.Rows(0)("GESTION_PAR_LOT") 'POUR LE SUIVI DES MAGASINS NON SUIVI
        End If

        If Not Trim(GunaTextBoxCodeArticle.Text).Equals("") Then

            'DETERMINATION DES QUANTITES D'UN ARTICLE QUELCONQUE DANS UN MAGASIN PRECIS

            LabelQteEnMagasinDeDestination.Visible = True

            LabelQuantiteEnMagasinSource.Visible = True

            GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True

            GunaTextBoxQunatiteDansLeMagasinDestination.Visible = True

            Dim CODE_SOUS_MAGASIN As String = ""

            If GunaComboBoxMagasin_2.Items.Count > 0 Then

                If Not GunaComboBoxMagasin_2.SelectedValue Is Nothing Then
                    CODE_SOUS_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
                End If

            End If

            Dim CODE_ARTICLE As String = GunaTextBoxCodeArticle.Text

            Dim infoSupArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

            Dim econom As New Economat()

            If infoSupArticle.Rows.Count > 0 Then

                GunaTextBoxQunatiteDansLeMagasinProvenance.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)

                GunaTextBoxQunatiteDansLeMagasinDestination.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_SOUS_MAGASIN, CODE_ARTICLE)

            End If

        End If

        'A CHAQUE FOIS QUE LE MAGASIN CHANGE ET QUE L'ON TRAITE LES INVENTAIRES ON DOIT DETERMINER LES INVENTAIRES DU MAGASIN ENCOURS

        If GunaComboBoxTypeBordereau.SelectedIndex = 2 Then
            inventaireDesArticles(CODE_MAGASIN)
        End If

    End Sub

    Private Sub GunaButtonCommander_Click_1(sender As Object, e As EventArgs) Handles GunaButtonCommander.Click

        Me.Cursor = Cursors.WaitCursor

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
            Dim totalAchat As Double = 0
            'Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

            If Not Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
                totalAchat = GunaTextBoxMontantHTGeneralAchat.Text
            End If

            Dim totalVente As Double = 0

            If Not Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
                totalVente = GunaTextBoxMontantTTCGeneralVente.Text
            End If

            Dim title As String = LabelBon.Text
            Dim nomTiers As String = GunaTextBoxNomTiers.Text
            Dim libelle As String = GunaTextBoxLibelleBordereau.Text
            Dim reference As String = GunaTextBoxReference.Text
            Dim observation As String = GunaTextBoxObservation.Text
            Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

            Dim typeBordereau As String = GlobalVariable.list_du_marche

            Dim ETAT_BORDEREAUX_MAIL As Integer = 4

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
                    typeBordereau = ""
                End If
                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                    Dim args As ArgumentType = New ArgumentType()
                    args.action = 1
                    ''backGroundWorkerToCall(args)
                    RapportApresCloture.impressionEconomat(GunaDataGridViewLigneArticleCommande, title, totalAchat, totalVente, numeroBon, ETAT_BORDEREAUX_MAIL, nomTiers, libelle, reference, observation, typeBordereau)
                End If
            End If

        End If

        GunaComboBoxTypeBordereau.Enabled = True

        GunaButtonAnnulerBordereau.Visible = False

        permettreAjoutArticle()

        Dim econom As New Economat()

        Dim ETAT_BORDEREAU As Integer = 4

        Dim CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR As String = GunaTextBoxCodeBordereau.Text

        econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

        'TRANSFORMATION DU BON DE REQUISITION EN BON DE COMMANDE
        Dim TYPE_DE_BORDERO As String = GlobalVariable.bon_cmd

        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
            TYPE_DE_BORDERO = GlobalVariable.bon_approvisi
        End If

        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_requisition Then
            econom.transformerRequisitionEnBonDeCommande(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, TYPE_DE_BORDERO)
        End If

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

        TabControlEconomat.SelectedIndex = 1

        GunaButtonController.Visible = False

        Functions.SiplifiedClearTextBox(Me)

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

        PictureBoxNext1.Visible = False
        GunaLabelValideur.Visible = False
        GunaLabelControleur.Visible = False
        GunaLabelEnregistreur.Visible = False
        GunaLabelVerification.Visible = False
        GunaButtonVerification.Visible = False

        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
            MessageBox.Show("Bon d'approvisionnement crée avec succès !", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Bon de Commande crée avec succès !", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        NewBonDeRequisition()

        Me.Cursor = Cursors.Default

        TabControlEconomat.SelectedIndex = 0

    End Sub

    'ON VIDE LE CHAMP D'ARTICLE POUR FORCER UNE NOUVELLE SAISIE
    Private Sub GunaComboBoxMagasinDeDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxMagasin_2.SelectedIndexChanged

        Dim CODE_MAGASIN As String = ""

        If GunaComboBoxMagasin_1.SelectedIndex >= 0 Then
            CODE_MAGASIN = GunaComboBoxMagasin_1.SelectedValue.ToString()
        End If

        Dim magasinActuel As DataTable = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")

        If magasinActuel.Rows.Count > 0 Then
            GunaTextBoxSuivreArticleNonSuivi.Text = magasinActuel.Rows(0)("GESTION_PAR_LOT") 'POUR LE SUIVI DES MAGASINS NON SUIVI
        End If

        If Not Trim(GunaTextBoxCodeArticle.Text).Equals("") Then

            'DETERMINATION DES QUANTITES D'UN ARTICLE QUELCONQUE DANS UN MAGASIN PRECIS

            LabelQteEnMagasinDeDestination.Visible = True

            LabelQuantiteEnMagasinSource.Visible = True

            GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True

            GunaTextBoxQunatiteDansLeMagasinDestination.Visible = True

            Dim CODE_SOUS_MAGASIN As String = ""

            If GunaComboBoxMagasin_2.Items.Count > 0 Then
                If Not GunaComboBoxMagasin_2.SelectedValue Is Nothing Then
                    CODE_SOUS_MAGASIN = GunaComboBoxMagasin_2.SelectedValue.ToString
                End If
            End If


            Dim CODE_ARTICLE As String = GunaTextBoxCodeArticle.Text

            Dim infoSupArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

            Dim econom As New Economat()

            If infoSupArticle.Rows.Count > 0 Then

                GunaTextBoxQunatiteDansLeMagasinProvenance.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)

                GunaTextBoxQunatiteDansLeMagasinDestination.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_SOUS_MAGASIN, CODE_ARTICLE)

            End If

        End If

    End Sub

    Private Sub GunaButtonRequisition_Click(sender As Object, e As EventArgs) Handles GunaButtonRequisition.Click

        nettoyageDuDataGrid()
        GunaRadioButtonParBordero.Checked = True
        GunaRadioButtonParBordero.Visible = True
        GunaRadioButtonParBordero.Text = "D'UN BON"
        GunaRadioButtonParTypeEtDate.Text = "PAR TYPE DE BON ET DATE"

        GunaRadioButtonParTypeEtDate.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "BON DE REQUISITION"
        GlobalVariable.typeRapportEconmat = "BRQ"
    End Sub

    Private Sub GunaButtonBonSortie_Click(sender As Object, e As EventArgs) Handles GunaButtonBonSortie.Click

        nettoyageDuDataGrid()
        GunaRadioButtonParBordero.Checked = True
        GunaRadioButtonParBordero.Visible = True
        GunaRadioButtonParBordero.Text = "D'UN BON"
        GunaRadioButtonParTypeEtDate.Text = "PAR TYPE DE BON ET DATE"

        GunaRadioButtonParTypeEtDate.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "BON DE SORTIE"
        GlobalVariable.typeRapportEconmat = "BS"

    End Sub

    Public Sub nettoyageDuDataGrid()

        GunaDataGridViewBorderoByTypeEtDate.Columns.Clear()
        GunaDataGridViewBorderoByTypeEtDate.Visible = False

        GunaLabel2.Visible = False
        GunaComboBoxListeDesMagasinPourInventaire.Visible = False

    End Sub

    'RAPPORT PAR CODE DE BORDERO 
    Private Sub GunaRadioButtonParBordero_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonParBordero.CheckedChanged

        If GlobalVariable.typeRapportEconmat = "BC" Or GlobalVariable.typeRapportEconmat = "BR" Or GlobalVariable.typeRapportEconmat = "BRQ" Or GlobalVariable.typeRapportEconmat = "TIM" Or GlobalVariable.typeRapportEconmat = "BS" Then

            If GunaRadioButtonParBordero.Checked Then

                GunaTextBoxElementRapport.Visible = True

                GunaTextBoxElementRapport.Clear()

                GunaRadioButtonParBordero.Text = "D'UN BON"

                GunaTextBoxElementRapport.Visible = True
                GunaComboBoxTypeBorderoRapport.Visible = False

                GunaDataGridViewBorderoByTypeEtDate.Visible = False
                GunaButtonAfficher.Visible = False

                GunaDataGridViewBorderoByTypeEtDate.Columns.Clear()

            Else

                'GunaRadioButtonParBordero.Text = "PAR TYPE DE BON ET DATE"

                'GunaTextBoxElementRapport.Visible = False
                'GunaComboBoxTypeBorderoRapport.Visible = True
                'GunaDateTimePicker1.Visible = True
                'GunaDateTimePicker2.Visible = True
                'GunaLabelDu.Visible = True
                'GunaLabelAu.Visible = True
                'GunaDataGridViewBorderoByTypeEtDate.Visible = True
                'GunaButtonAfficher.Visible = True



            End If

        ElseIf GlobalVariable.typeRapportEconmat = "FS" Then

            If GunaRadioButtonParBordero.Checked Then
                GunaTextBoxElementRapport.Clear()
                GunaTextBoxElementRapport.Visible = True
                GunaButtonImpirmerRapportEconomat.Visible = False
                GunaDateTimePicker1.Visible = True
                GunaDateTimePicker2.Visible = True
                GunaLabelDu.Visible = True
                GunaLabelAu.Visible = True
            Else
                GunaTextBoxElementRapport.Visible = False
                GunaButtonImpirmerRapportEconomat.Visible = True
                GunaDateTimePicker1.Visible = True
                GunaDateTimePicker2.Visible = True
                GunaLabelDu.Visible = True
                GunaLabelAu.Visible = True
            End If

        ElseIf GlobalVariable.typeRapportEconmat = "MS" Then

            If GunaRadioButtonParBordero.Checked Then

            Else

            End If

        ElseIf GlobalVariable.typeRapportEconmat = "PR" Then

            If GunaRadioButtonParBordero.Checked Then
                GunaDateTimePicker1.Visible = False
                GunaDateTimePicker2.Visible = False
                GunaLabelDu.Visible = False
                GunaLabelAu.Visible = False
                GunaButtonImpirmerRapportEconomat.Visible = False
                GunaTextBoxElementRapport.Visible = True
            Else
                GunaDateTimePicker1.Visible = True
                GunaDateTimePicker2.Visible = True
                GunaLabelDu.Visible = True
                GunaLabelAu.Visible = True
                GunaButtonImpirmerRapportEconomat.Visible = True
                GunaTextBoxElementRapport.Visible = False
            End If

        End If


        If GunaRadioButtonParBordero.Checked Then

            GunaDateTimePicker1.Visible = False
            GunaDateTimePicker2.Visible = False
            GunaLabelDu.Visible = False
            GunaLabelAu.Visible = False
            GunaButtonImpirmerRapportEconomat.Visible = False
            GunaButtonAfficher.Visible = False

        Else
            GunaRadioButtonParTypeEtDate.Checked = True
        End If

    End Sub

    'AFFICHER LES BORDERO PAR DATE ET PAR TYPE
    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        Dim econom As New Economat()

        Dim entreeSortie As Integer = 0
        Dim globalIndividuel As Integer = 0

        If GlobalVariable.typeRapportEconmat = "ES" Then

            If GunaComboBoxEntreSortie.SelectedIndex >= 0 Then

                If GunaComboBoxEntreSortie.SelectedIndex = 0 Then
                    'GESTION DES ENTREES (BON DE RECEPTION)
                    entreeSortie = 0
                Else
                    'GESTION DES SORTIES (BON DE SORTIE ET SORTIE EXCEPETIONNELLE)
                    entreeSortie = 1
                End If

            End If

            If GunaComboBoxGlobalIndividuel.SelectedIndex >= 0 Then

                If GunaComboBoxGlobalIndividuel.SelectedIndex = 0 Then
                    'AFFICHAGE INDIVIDUEL DONC VISIBILITE DE CHAQUE LIGNE DURANT LA PERIODE
                    globalIndividuel = 0
                Else
                    'AFFICHAGE GLOBAL DONC VISIBILITE GLOBALE (RESUME) DE CHAQUE LIGNE DURANT LA PERIODE
                    globalIndividuel = 1
                End If

            End If

            If (globalIndividuel >= 0 And globalIndividuel <= 1) And (entreeSortie >= 0 And entreeSortie <= 1) Then
                'DEMANDE A AFFICHER LES ENTREES OU SORTIES GLOBALES OU INDIVIDUELLE DONC DETAILLEES
                GunaDataGridViewBorderoByTypeEtDate.DataSource = econom.affichageDesEntreesSortiePeriodique(GunaDateTimePicker1.Value.ToShortDateString, GunaDateTimePicker2.Value.ToShortDateString, entreeSortie, globalIndividuel)

                If GunaDataGridViewBorderoByTypeEtDate.Rows.Count > 0 Then

                    GunaDataGridViewBorderoByTypeEtDate.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewBorderoByTypeEtDate.Columns("TOTAL").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE AVANT MOVT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE AVANT MOVT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE EN MOVT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE EN MOVT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaButtonImpirmerRapportEconomat.Visible = True

                    GunaDataGridViewBorderoByTypeEtDate.Columns("MAGASIN").Visible = False

                Else
                    GunaButtonImpirmerRapportEconomat.Visible = False
                End If

            End If

        ElseIf GlobalVariable.typeRapportEconmat = "AP" Then 'LISTE DES ACHATS PERIODIQUE


            If GunaComboBoxEntreSortie.SelectedIndex >= 0 Then

                If GunaComboBoxEntreSortie.SelectedIndex = 0 Then
                    'GESTION DES ENTREES (BON DE RECEPTION)
                    entreeSortie = 0
                Else
                    'GESTION DES SORTIES (BON DE SORTIE ET SORTIE EXCEPETIONNELLE)
                    entreeSortie = 1
                End If

            End If

            If GunaComboBoxGlobalIndividuel.SelectedIndex >= 0 Then

                If GunaComboBoxGlobalIndividuel.SelectedIndex = 0 Then
                    'AFFICHAGE INDIVIDUEL DONC VISIBILITE DE CHAQUE LIGNE DURANT LA PERIODE
                    globalIndividuel = 0
                Else
                    'AFFICHAGE GLOBAL DONC VISIBILITE GLOBALE (RESUME) DE CHAQUE LIGNE DURANT LA PERIODE
                    globalIndividuel = 1
                End If

            End If

            If (globalIndividuel >= 0 And globalIndividuel <= 1) And (entreeSortie >= 0 And entreeSortie <= 1) Then
                'DEMANDE A AFFICHER LES ENTREES OU SORTIES GLOBALES OU INDIVIDUELLE DONC DETAILLEES
                GunaDataGridViewBorderoByTypeEtDate.DataSource = econom.affichageDesEntreesSortiePeriodique(GunaDateTimePicker1.Value.ToShortDateString, GunaDateTimePicker2.Value.ToShortDateString, entreeSortie, globalIndividuel)

                If GunaDataGridViewBorderoByTypeEtDate.Rows.Count > 0 Then

                    GunaDataGridViewBorderoByTypeEtDate.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewBorderoByTypeEtDate.Columns("TOTAL").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE AVANT MOVT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE AVANT MOVT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE EN MOVT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBorderoByTypeEtDate.Columns("QTE EN MOVT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaButtonImpirmerRapportEconomat.Visible = True

                    GunaDataGridViewBorderoByTypeEtDate.Columns("MAGASIN").Visible = False

                Else
                    GunaButtonImpirmerRapportEconomat.Visible = False
                End If

            End If

        Else

            If GunaComboBoxTypeBorderoRapport.SelectedIndex >= 0 Then

                GunaDataGridViewBorderoByTypeEtDate.DataSource = econom.allTableFieldsOrganisedBetweenDates(GunaComboBoxTypeBorderoRapport.SelectedItem.ToString, GunaComboBoxTrierLeBordereau.SelectedIndex, GunaDateTimePicker1.Value, GunaDateTimePicker2.Value)

                GunaDataGridViewBorderoByTypeEtDate.Visible = True

                GunaDataGridViewBorderoByTypeEtDate.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewBorderoByTypeEtDate.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Else

                MessageBox.Show("Aucun Type de bordereau sélectionné !!")

            End If

        End If

    End Sub

    'IMPRESSION DES BON DE COMMANDE APRES AFFICHAGE DANS LE DATAGRID
    Private Sub TransférerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransférerToolStripMenuItem.Click

        If GunaDataGridViewBorderoByTypeEtDate.Rows.Count > 0 Then

            Dim getQuery As String = ""
            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable

            Dim TYPE_BORDEREAUX As String = ""

            If GlobalVariable.typeRapportEconmat = "BC" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_cmd
            ElseIf GlobalVariable.typeRapportEconmat = "BR" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_reception
            ElseIf GlobalVariable.typeRapportEconmat = "BS" Then
                TYPE_BORDEREAUX = GlobalVariable.sortie
            ElseIf GlobalVariable.typeRapportEconmat = "BRQ" Then
                TYPE_BORDEREAUX = GlobalVariable.bon_requisition
            ElseIf GlobalVariable.typeRapportEconmat = "TIM" Then
                TYPE_BORDEREAUX = GlobalVariable.transfert_inter
            End If

            For Each row As DataGridViewRow In GunaDataGridViewBorderoByTypeEtDate.SelectedRows

                Dim CODE_BORDEREAUX As String = Trim(row.Cells("CODE BORDEREAUX").Value)

                If Not CODE_BORDEREAUX = "" Then
                    'RAPPORT INDIVIDUEL
                    getQuery = "SELECT bordereaux.CODE_BORDEREAUX, `TYPE_BORDEREAUX`, `REF_BORDEREAUX`, `LIBELLE_BORDEREAUX`, `NON_TIERS`, `DATE_BORDEREAU`, `OBSERVATIONS`, `MONTANT_HT`, `MONTANT_TAXE`, `MONTANT_TTC`, `MONTANT_PAYER`, DESIGNATION_FR, ligne_bordereaux.QUANTITE_ENTREE_STOCK, PRIX_UNITAIRE_HT, PRIX_TOTAL_HT FROM `bordereaux`, `ligne_bordereaux`, article WHERE bordereaux.CODE_BORDEREAUX=@CODE_BORDEREAUX AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND bordereaux.CODE_BORDEREAUX= ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE =ligne_bordereaux.CODE_ARTICLE"

                Else
                    'ENSEMBLE DE RAPPORT



                End If

                Dim command As New MySqlCommand(getQuery, GlobalVariable.connect)

                command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
                command.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX

                adapter.SelectCommand = command
                adapter.Fill(table)

                'IMPRESSION DES BORDEREAU

                Impression.Bon(table)

            Next

        End If

    End Sub

    Private Sub GunaComboBoxTypeBorderoRapport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeBorderoRapport.SelectedIndexChanged

        If GunaComboBoxTypeBorderoRapport.SelectedIndex = 0 Then
            GlobalVariable.typeRapportEconmat = "BR"
        ElseIf GunaComboBoxTypeBorderoRapport.SelectedIndex = 1 Then
            GlobalVariable.typeRapportEconmat = "BRQ"
        ElseIf GunaComboBoxTypeBorderoRapport.SelectedIndex = 2 Then
            GlobalVariable.typeRapportEconmat = "INV"
        ElseIf GunaComboBoxTypeBorderoRapport.SelectedIndex = 3 Then
            GlobalVariable.typeRapportEconmat = "BS"
        ElseIf GunaComboBoxTypeBorderoRapport.SelectedIndex = 4 Then
            GlobalVariable.typeRapportEconmat = ""
        ElseIf GunaComboBoxTypeBorderoRapport.SelectedIndex = 5 Then
            GlobalVariable.typeRapportEconmat = ""
        ElseIf GunaComboBoxTypeBorderoRapport.SelectedIndex = 6 Then
            GlobalVariable.typeRapportEconmat = "TIM"
        ElseIf GunaComboBoxTypeBorderoRapport.SelectedIndex = 7 Then
            GlobalVariable.typeRapportEconmat = ""
        ElseIf GunaComboBoxTypeBorderoRapport.SelectedIndex = 8 Then
            GlobalVariable.typeRapportEconmat = "BC"
        End If

    End Sub

    Private Sub GunaButton4_Click_2(sender As Object, e As EventArgs) Handles GunaButton4.Click

        nettoyageDuDataGrid()
        GunaRadioButtonParBordero.Text = "FICHE TECHNIQUE DE PLAT"
        GunaRadioButtonParTypeEtDate.Visible = False

        GunaRadioButtonParBordero.Checked = True

        GunaRadioButtonParBordero.Visible = True
        GunaTextBoxElementRapport.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "FICHE TECHNIQUE DE PLAT"
        GlobalVariable.typeRapportEconmat = "FPT"

        GunaDateTimePicker1.Visible = False
        GunaDateTimePicker2.Visible = False
        GunaLabelDu.Visible = False
        GunaLabelAu.Visible = False
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = False
    End Sub

    Private Sub GunaButton6_Click_1(sender As Object, e As EventArgs) Handles GunaButtonProdRetau.Click

        nettoyageDuDataGrid()
        'PRODUCTION DU RESTAURANT

        GunaRadioButtonParTypeEtDate.Checked = True

        GunaRadioButtonParTypeEtDate.Visible = True
        GunaComboBoxTypeBorderoRapport.Visible = False


        GunaRadioButtonParTypeEtDate.Text = "PRODUCTION DE CUISINE"

        GunaRadioButtonParBordero.Text = "PRODUCTION DE CUISINE"

        'GunaRadioButtonParTypeEtDate.Checked = False
        GunaRadioButtonParBordero.Visible = False
        GunaTextBoxElementRapport.Visible = False


        GunaDateTimePicker1.Visible = True
        GunaDateTimePicker2.Visible = True
        GunaLabelDu.Visible = True
        GunaLabelAu.Visible = True
        GunaButtonImpirmerRapportEconomat.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "PRODUCTION DE CUISINE"

        GlobalVariable.typeRapportEconmat = "PC"

    End Sub

    Private Sub GunaTextBoxQuantite_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxQuantite.TextChanged

        Dim prixArticle As Double = 0

        If Not Trim(GunaTextBoxCoutDuStock.Text) = "" And Not Trim(GunaTextBoxQuantite.Text) = "" Then
            prixArticle = Double.Parse(GunaTextBoxCoutDuStock.Text)
            'GunaTextBoxCoutDuStock.Text = Format(Double.Parse(GunaTextBoxQuantite.Text) * prixArticle, "#,##0")
        Else

        End If

    End Sub

    'VERIFICATION DES BORDEREAUX
    Public Sub traitementDeRecettePourTransfertVersLaCaissePrincipale(ByVal RECETTE_A_TRANSFERER As Double)

        '1- GENERATION DE LA LIGNE DE TRANSACTION QUI SERA VISIBLE AU NIVEAU DE LA CAISSE PRINCIPALE SOUS FORME DE FACTURE

        'Variables for filling the facturation data
        Dim infoSup As String = ""

        Dim magasin As DataTable = Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "utilisateur_magazin", "CODE_UTILISATEUR")

        If magasin.Rows.Count > 0 Then

            Dim infoMagasin As DataTable = Functions.getElementByCode(magasin.Rows(0)("CODE_MAGAZIN"), "magasin", "CODE_MAGASIN")

            If infoMagasin.Rows.Count > 0 Then
                infoSup = " [ " & infoMagasin.Rows(0)("LIBELLE_MAGASIN") & " ] "
            End If

        End If

        Dim CODE_FACTURE As String = Functions.GeneratingRandomCode("transfert_recette", "") ' CODE_BON_DE_COMMANDE

        Dim CODE_RESERVATION As String = ""
        Dim CODE_CLIENT As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim NOM_CLIENT_FACTURE As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        Dim CODE_COMMANDE As String = "DEMANDE DE DECAISSEMENT"

        If GlobalVariable.actualLanguageValue = 0 Then
            CODE_COMMANDE = "DISBURSEMENT REQUEST"
        End If

        Dim NUMERO_TABLE As String = GunaTextBoxCodeBordereau.Text
        Dim CODE_MODE_PAIEMENT As String = ""
        Dim NUM_MOUVEMENT As String = Functions.GeneratingRandomCode("transfert_recette", "")
        Dim DATE_FACTURE As Date = GlobalVariable.DateDeTravail

        Dim CODE_COMMERCIAL As String = ""

        Dim MONTANT_HT As Double = RECETTE_A_TRANSFERER
        Dim TAXE As Double = 0
        Dim MONTANT_TTC As Double = RECETTE_A_TRANSFERER
        Dim AVANCE As Double = 0
        Dim RESTE_A_PAYER As Double = RECETTE_A_TRANSFERER * -1
        Dim DATE_PAIEMENT As Date
        Dim ETAT_FACTURE As String = 0
        Dim LIBELLE_FACTURE As String = "DECAISSEMENT POUR ACHAT ( " & CODE_FACTURE.ToUpper & " ) PAR  " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " ( " & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] / " & infoSup
        Dim MONTANT_TRANSPORT As Double = 0
        Dim MONTANT_REMISE As Double = 0
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR") 'CODE_DU CAISSIER
        Dim CODE_UTILISATEUR_ANNULE As String = ""
        Dim CODE_UTILISATEUR_VALIDE As String = ""

        Dim MONTANT_AVANCE As Double = 0
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim facture As New Facture()

        If facture.insertTransfertRecette(CODE_FACTURE, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT, TAXE, MONTANT_TTC, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, LIBELLE_FACTURE, MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE) Then

        End If

        '2- INSERTATION DU MONTANT DES COUPURES

    End Sub

    Private Sub GunaButtonVerification_Click(sender As Object, e As EventArgs) Handles GunaButtonVerification.Click

        Me.Cursor = Cursors.WaitCursor

        If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
            Dim totalAchat As Double = 0
            'Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

            If Not Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
                totalAchat = GunaTextBoxMontantHTGeneralAchat.Text
            End If

            Dim totalVente As Double = 0

            If Not Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
                totalVente = GunaTextBoxMontantTTCGeneralVente.Text
            End If

            Dim title As String = LabelBon.Text
            Dim nomTiers As String = GunaTextBoxNomTiers.Text
            Dim libelle As String = GunaTextBoxLibelleBordereau.Text
            Dim reference As String = GunaTextBoxReference.Text
            Dim observation As String = GunaTextBoxObservation.Text
            Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

            Dim typeBordereau As String = GlobalVariable.list_du_marche

            Dim ETAT_BORDEREAUX_MAIL As Integer = 2

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Or GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.list_du_marche Then
                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_requisition Then
                    typeBordereau = ""
                End If

                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                    Dim args As ArgumentType = New ArgumentType()
                    args.action = 1
                    ''backGroundWorkerToCall(args)
                    RapportApresCloture.impressionEconomat(GunaDataGridViewLigneArticleCommande, title, totalAchat, totalVente, numeroBon, ETAT_BORDEREAUX_MAIL, nomTiers, libelle, reference, observation, typeBordereau)
                End If

            End If

        End If

        GunaComboBoxTypeBordereau.Enabled = True

        GunaButtonAnnulerBordereau.Visible = False


        permettreAjoutArticle()

        Dim econom As New Economat()
        Dim ETAT_BORDEREAU As Integer = 2

        Dim CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR As String = GunaTextBoxCodeBordereau.Text
        econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

        'TabControlEconomat.SelectedIndex = 1

        GunaButtonController.Visible = False

        Functions.SiplifiedClearTextBox(Me)

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

        NewBonDeRequisition()

        If GlobalVariable.actualLanguageValue = 1 Then
            MessageBox.Show("Bon vérifié avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Slip successfully verified!", "Slip", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Default

        TabControlEconomat.SelectedIndex = 0

    End Sub

    Private Sub GunaButtonAnnulerBordereau_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnulerBordereau.Click

        GunaButtonAnnulerBordereau.Visible = False

        Dim dialog As DialogResult

        'Using form = New Form() With {.TopMost = True}
        dialog = MessageBox.Show("Voulez-vous vraiment annuler se bordereau ?", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'End Using

        'If dialog = DialogResult.No Then
        'e.Cancel = True
        'Else

        If Not dialog = DialogResult.No Then

            permettreAjoutArticle()

            Dim econom As New Economat()
            Dim ETAT_BORDEREAU As Integer = 7 ' ETAT_ANNULATION = 7

            Dim CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR As String = GunaTextBoxCodeBordereau.Text
            econom.updateBordereauDeCommandeAyantConduitAuBordereauDeReception(CODE_BORDEREAUX_COMMANDE_METTRE_AJOUR, ETAT_BORDEREAU)

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
            Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

            TabControlEconomat.SelectedIndex = 1

            GunaButtonController.Visible = False

            Functions.SiplifiedClearTextBox(Me)

            GunaDataGridViewLigneArticleCommande.Columns.Clear()

            PictureBoxNext1.Visible = False
            GunaLabelControleur.Visible = False
            GunaLabelEnregistreur.Visible = False
            GunaLabelVerification.Visible = False
            GunaButtonVerification.Visible = False

            MessageBox.Show("Bon annulé avec succès!", "Bordereau", MessageBoxButtons.OK, MessageBoxIcon.Information)

            NewBonDeRequisition()

        End If

    End Sub

    Private Sub GunaButton8_Click(sender As Object, e As EventArgs) Handles GunaButton8.Click

        nettoyageDuDataGrid()
        'COMMMANDE DE LA CUISINE

        GunaRadioButtonParTypeEtDate.Checked = True

        GunaRadioButtonParTypeEtDate.Visible = True
        GunaRadioButtonParTypeEtDate.Text = "COMMANDES PREPAREES DE LA CUISINE"

        GunaRadioButtonParBordero.Text = "COMMANDES PREPAREES DE LA CUISINE"

        GunaComboBoxTypeBorderoRapport.Visible = False

        'GunaRadioButtonParTypeEtDate.Checked = False
        GunaRadioButtonParBordero.Visible = False
        GunaTextBoxElementRapport.Visible = False


        GunaDateTimePicker1.Visible = True
        GunaDateTimePicker2.Visible = True
        GunaLabelDu.Visible = True
        GunaLabelAu.Visible = True
        GunaButtonImpirmerRapportEconomat.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "COMMANDES PREPAREES DE LA CUISINE"

        GlobalVariable.typeRapportEconmat = "CPC"

    End Sub

    'CUISINE
    Private Sub ToolStripMenuItem53_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem53.Click

        Me.Cursor = Cursors.WaitCursor

        MainWindowCuisineForm.Show()
        ArticleForm.Show()

        ArticleForm.Location = New Point(90, 110)
        ArticleForm.TopMost = True

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaTextBoxCoutDuStock_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCoutDuStock.TextChanged

        'GunaTextBoxAchat.Text = GunaTextBoxCoutDuStock.Text * GunaTextBoxQuantite.Text
        GunaTextBoxAchat.Text = GunaTextBoxCoutDuStock.Text

    End Sub

    'ON BASCULE L'ELEMENT ANNULER VERS LA TABLE DES LIGNE COMMANDE ANNULEES
    Private Sub SupprimerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem1.Click

        Dim econom As New Economat()

        If GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then

            Dim DeleteRow As Boolean = False

            Dim rowToDelete As String = ""
            Dim ID_LIGNE_BORDEREAU As Integer

            If Not GunaDataGridViewLigneArticleCommande.CurrentRow.Cells("CODE ARTICLE").Value.ToString Is Nothing Then

                If rowToDelete = "" Then
                    rowToDelete = GunaDataGridViewLigneArticleCommande.CurrentRow.Cells("CODE ARTICLE").Value.ToString
                    ID_LIGNE_BORDEREAU = GunaDataGridViewLigneArticleCommande.CurrentRow.Cells("ID_LIGNE_BORDEREAU").Value.ToString
                End If

            End If

            Dim dialog As DialogResult

            Dim articleToDelete As DataTable = Functions.getElementByCode(rowToDelete, "article", "CODE_ARTICLE")

            Dim nomArticle As String = ""

            If articleToDelete.Rows.Count > 0 Then
                nomArticle = articleToDelete.Rows(0)("DESIGNATION_FR")
            End If

            dialog = MessageBox.Show("Voulez-vous vraiment retirer l'article " & nomArticle, "Annuler", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                DeleteRow = True
            End If

            If DeleteRow Then

                Dim CODE_ARTICLE As String = rowToDelete
                Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                Dim articleToTransfert As DataTable = Functions.getElementByCode(ID_LIGNE_BORDEREAU, "bordereau_ligne_temp", "ID_LIGNE_BORDEREAU")

                If articleToTransfert.Rows.Count > 0 Then

                    'AVANT SUPPRESION ON MIGRE VERS LA TABLE DES ANNULEES

                    For i = 0 To articleToTransfert.Rows.Count - 1

                        Dim DESIGNATION = articleToTransfert.Rows(i)("DESIGNATION")
                        Dim UNITE_COMPTAGE = articleToTransfert.Rows(i)("UNITE_COMPTAGE")
                        Dim CODE_ARTICLE_ = articleToTransfert.Rows(i)("CODE_ARTICLE")
                        Dim QUANTITE = articleToTransfert.Rows(i)("QUANTITE")
                        Dim EN_STOCK = articleToTransfert.Rows(i)("EN_STOCK")
                        Dim DATE_PEREMPTION = articleToTransfert.Rows(i)("DATE_PEREMPTION")
                        Dim PRIX_VENTE = articleToTransfert.Rows(i)("PRIX_VENTE")
                        Dim PRIX_ACHAT = articleToTransfert.Rows(i)("PRIX_ACHAT")
                        Dim COUT_DU_STOCK = articleToTransfert.Rows(i)("COUT_DU_STOCK")
                        Dim CODE_BORDEREAUX = articleToTransfert.Rows(i)("CODE_BORDEREAU")
                        Dim CODE_AGENCE = articleToTransfert.Rows(i)("CODE_AGENCE")

                        econom.insertLigneBordereauAnnuler(CODE_ARTICLE, DESIGNATION, QUANTITE, EN_STOCK, PRIX_VENTE, PRIX_ACHAT, DATE_PEREMPTION, CODE_AGENCE, CODE_BORDEREAUX, UNITE_COMPTAGE, CODE_USER, COUT_DU_STOCK)

                    Next

                End If

                'SUPPRESION DE LA LIGNE DE COMMANDE DANS LIGNE_BORDEREAU_TEMP
                'Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "bordereau_ligne_temp", "CODE_ARTICLE", "CODE_USER", CODE_USER)

                Functions.DeleteElementByCode(ID_LIGNE_BORDEREAU, "bordereau_ligne_temp", "ID_LIGNE_BORDEREAU")

                'rafraichissement du dataGrid

                GunaDataGridViewLigneArticleCommande.Columns.Clear()

                GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)

                If GlobalVariable.actualLanguageValue = 1 Then

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Format = "#,##0"

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewLigneArticleCommande.Columns("PRIX UNITAIRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewLigneArticleCommande.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").DefaultCellStyle.Format = "#,##0"

                    GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").Visible = False

                Else

                    GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Format = "#,##0"

                    GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewLigneArticleCommande.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridViewLigneArticleCommande.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewLigneArticleCommande.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    GunaDataGridViewLigneArticleCommande.Columns("TOTAL PRICE").DefaultCellStyle.Format = "#,##0"

                    GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

                End If

                'GunaDataGridViewLigneArticleMagasin.Columns("PRIX UNITAIRE").Visible = False


                'GunaDataGridViewLigneArticleMagasin.Columns("DATE DE PEREMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False
                GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False

                GunaTextBoxArticle.Clear()
                GunaButtonAjouterLigne.Visible = False

                For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

                    montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value

                    montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value

                Next

                GunaTextBoxMontantHTGeneralAchat.Text = Format(montantGlobalAchat, "#,##0")

                GunaTextBoxMontantTTCGeneralVente.Text = Format(montantGlobalVente, "#,##0")

            End If

        End If

    End Sub


    'AU CHANGEMENT D'UNE VALEUR DE CELLULE (QUANTITE / PU) ON MODIFIE LE PRIX TOTAL

    Private Sub GunaDataGridViewLigneArticleMagasin_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLigneArticleCommande.CellDoubleClick


        'MODICFICATION DU DATAGRID
        Dim econom As New Economat()

        Dim CODE_BORDEREAUX As String = Trim(GunaTextBoxCodeBordereau.Text)

        Dim infoSupBordereau As DataTable = Functions.getElementByCode(CODE_BORDEREAUX, "bordereaux", "CODE_BORDEREAUX")
        Dim edit As Boolean = False

        If infoSupBordereau.Rows.Count > 0 Then
            If infoSupBordereau.Rows(0)("ETAT_BORDEREAU") = 0 Then
                edit = True
            End If
        Else
            edit = True
        End If

        If e.RowIndex >= 0 And edit Then

            GunaButtonEnregistrer.Enabled = True
            edit = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterLigne.Text = "Modifier"
            Else
                GunaButtonAjouterLigne.Text = "Update"
            End If

            GunaButtonAjouterLigne.Visible = True

            GunaTextBoxQuantite.Text = 1

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewLigneArticleCommande.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE CODE_ARTICLE=@CODE_ARTICLE ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim CODE_ARTICLE As String = row.Cells("CODE ARTICLE").Value.ToString
            Dim QUANTITE As Double = 0
            Dim PU As Double = 0
            Dim UNITE_UTILISE As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                QUANTITE = row.Cells("QUANTITY").Value
                PU = row.Cells("UNIT PRICE").Value
                UNITE_UTILISE = row.Cells("UNIT").Value
            Else
                QUANTITE = row.Cells("QUANTITE").Value
                PU = row.Cells("PRIX UNITAIRE").Value
                UNITE_UTILISE = row.Cells("UNITE").Value
            End If

            GunaTextBoxID_LIGNE_TEMP.Text = row.Cells("ID_LIGNE_BORDEREAU").Value

            command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

            adapter.SelectCommand = command

            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then

                GunaTextBoxCodeArticle.Text = Article.Rows(0)("CODE_ARTICLE")

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter Then

                    'DETERMINATION DES QUANTITES D'UN ARTICLE QUELCONQUE DANS UN MAGASIN PRECIS

                    LabelQteEnMagasinDeDestination.Visible = True

                    LabelQuantiteEnMagasinSource.Visible = True

                    GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = True

                    GunaTextBoxQunatiteDansLeMagasinDestination.Visible = True

                    Dim CODE_MAGASIN As String = GunaComboBoxMagasin_1.SelectedValue.ToString

                    Dim CODE_SOUS_MAGASIN As String = GunaComboBoxMagasin_2.SelectedValue.ToString

                    Dim CODE_ARTCLE As String = Article.Rows(0)("CODE_ARTICLE")

                    GunaTextBoxQunatiteDansLeMagasinProvenance.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTCLE)

                    GunaTextBoxQunatiteDansLeMagasinDestination.Text = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_SOUS_MAGASIN, CODE_ARTCLE)

                Else

                    LabelQuantiteEnMagasinSource.Visible = False
                    GunaTextBoxQunatiteDansLeMagasinProvenance.Visible = False

                    LabelQteEnMagasinDeDestination.Visible = False
                    GunaComboBoxMagasin_2.Visible = False

                End If

                GunaTextBoxAchat.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") 'PRIX D'ACHAT 
                GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0") 'COUT MOYEN UNITAIRE PONDERE
                GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxSeuile.Text = Format(Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT"), "#,##0.0")
                GunaTextBoxQteGrdeUnite.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.0")
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

    Private Sub TimerToRefreshClock_Tick(sender As Object, e As EventArgs) Handles TimerToRefreshClock.Tick

        'NOTIFCATION
        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions("ECONOME", "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then
            GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
            GunaLabelNotification.ForeColor = Color.Crimson
        Else
            GunaLabelNotification.ForeColor = Color.White
        End If

    End Sub

    'GESTION DES UNITES

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

    Private Sub GunaRadioButtonParTypeEtDate_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonParTypeEtDate.CheckedChanged

        If GunaRadioButtonParTypeEtDate.Checked Then

            GunaTextBoxElementRapport.Visible = False
            GunaDateTimePicker1.Visible = True
            GunaDateTimePicker2.Visible = True
            GunaLabelDu.Visible = True
            GunaLabelAu.Visible = True
            GunaComboBoxTypeBorderoRapport.Visible = True
            GunaButtonImpirmerRapportEconomat.Visible = False
            GunaButtonAfficher.Visible = False

            If GlobalVariable.typeRapportEconmat = "BC" Or GlobalVariable.typeRapportEconmat = "BR" Or GlobalVariable.typeRapportEconmat = "BRQ" Or GlobalVariable.typeRapportEconmat = "TIM" Or GlobalVariable.typeRapportEconmat = "BS" Then
                GunaButtonAfficher.Visible = True
                GunaButtonImpirmerRapportEconomat.Visible = False
            Else
                GunaButtonAfficher.Visible = False
                GunaButtonImpirmerRapportEconomat.Visible = True
            End If

        Else
            GunaTextBoxElementRapport.Visible = True
            GunaRadioButtonParBordero.Checked = True
        End If

    End Sub

    Public Sub etapeDuParcoursMiseAjours(ByVal bordereau As DataTable)

        If bordereau.Rows(0)("ETAT_BORDEREAU") = 0 Then

            'ANNULATION
            GunaButtonAnnulerBordereau.Visible = True

            GunaLabelEnregistreur.Visible = True
            GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

            GunaButtonController.Enabled = True
            GunaButtonController.Visible = True

            GunaButtonController.Enabled = True
            PictureBox1NextStage.Visible = False
            GunaButtonValider.Visible = False

        ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 1 Then

            'ANNULATION
            GunaButtonAnnulerBordereau.Visible = True
            GunaButtonAnnulerBordereau.Enabled = True

            '-------- ENREGISTRER ---------
            GunaLabelEnregistreur.Visible = True
            GunaButtonEnregistrer.Visible = True
            GunaButtonEnregistrer.Enabled = False
            GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

            '------ CONTROLER -----------------
            GunaLabelControleur.Visible = True
            GunaButtonController.Visible = True
            GunaButtonController.Enabled = False
            GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

            PictureBoxNext1.Visible = True

            '------ VERIFICATION -----------------
            GunaButtonVerification.Visible = True
            GunaButtonVerification.Enabled = True

            If Trim(GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.transfert_inter) Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then

                GunaButtonAnnulerBordereau.Visible = False
                GunaButtonVerification.Visible = False
                PictureBoxNext1.Visible = False

            End If

        ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 2 Then

            'ANNULATION
            GunaButtonAnnulerBordereau.Visible = True
            GunaButtonAnnulerBordereau.Enabled = True

            empecherAjoutArticle()

            '-------- ENREGISTRER ---------
            GunaLabelEnregistreur.Visible = True
            GunaButtonEnregistrer.Visible = True
            GunaButtonEnregistrer.Enabled = False
            GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

            '------ CONTROLER -----------------
            GunaLabelControleur.Visible = True
            GunaButtonController.Visible = True
            GunaButtonController.Enabled = False
            GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

            PictureBoxNext1.Visible = True

            '------ VERIFICATION -----------------
            GunaButtonVerification.Visible = True
            GunaButtonVerification.Enabled = False
            GunaLabelVerification.Visible = True
            GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Then
                GunaButtonValider.Text = "Sortir"
            ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.entree_exceptionnelle Then
                GunaButtonValider.Text = "Entrer"
            Else
                GunaButtonValider.Text = "Valider"
            End If

            '---------- VALIDER ------------------
            PictureBox1NextStage.Visible = True
            GunaButtonValider.Visible = True


        ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 3 Then

            'ANNULATION
            GunaButtonAnnulerBordereau.Visible = True
            GunaButtonAnnulerBordereau.Enabled = True

            empecherAjoutArticle()

            '-------- ENREGISTRER ---------
            GunaLabelEnregistreur.Visible = True
            GunaButtonEnregistrer.Visible = True
            GunaButtonEnregistrer.Enabled = False
            GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

            '------ CONTROLER -----------------
            GunaLabelControleur.Visible = True
            GunaButtonController.Visible = True
            GunaButtonController.Enabled = False
            GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

            PictureBoxNext1.Visible = True

            '------ VERIFICATION -----------------
            GunaButtonVerification.Visible = True
            GunaButtonVerification.Enabled = False
            GunaLabelVerification.Visible = True
            GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")

            PictureBox1NextStage.Visible = True

            '---------- VALIDER ------------------
            GunaButtonValider.Visible = True
            GunaButtonValider.Enabled = False
            GunaLabelValideur.Visible = True
            GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")

            '--------------- COMMANDER --------------
            PictureBoxNext3.Visible = True
            GunaButtonCommander.Visible = True

            If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.entree_exceptionnelle Then

                If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.sortie_exceptionnelle Then
                    GunaButtonValider.Text = "Sortir"
                ElseIf GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.entree_exceptionnelle Then
                    GunaButtonValider.Text = "Entrer"
                Else
                    GunaButtonValider.Text = "Valider"
                End If

                '---------- VALIDER ------------------
                GunaButtonValider.Visible = True
                GunaButtonValider.Enabled = False
                GunaLabelValideur.Visible = True
                GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")

                PictureBoxNext3.Visible = False
                GunaButtonCommander.Visible = False

                'ANNULATION
                GunaButtonAnnulerBordereau.Visible = True
                GunaButtonAnnulerBordereau.Enabled = False

            ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
                GunaButtonCommander.Text = "Approvisionner"
            End If

        ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 4 Then

            'ANNULATION
            GunaButtonAnnulerBordereau.Visible = True
            GunaButtonAnnulerBordereau.Enabled = True

            empecherAjoutArticle()

            '-------- ENREGISTRER ---------
            GunaLabelEnregistreur.Visible = True
            GunaButtonEnregistrer.Visible = True
            GunaButtonEnregistrer.Enabled = False
            GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

            '------ CONTROLER -----------------
            GunaLabelControleur.Visible = True
            GunaButtonController.Visible = True
            GunaButtonController.Enabled = False
            GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

            PictureBoxNext1.Visible = True

            '------ VERIFICATION -----------------
            GunaButtonVerification.Visible = True
            GunaLabelVerification.Visible = True
            PictureBox1NextStage.Visible = True

            GunaButtonVerification.Enabled = False
            GunaLabelVerification.Visible = True
            GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")

            PictureBox1NextStage.Visible = True

            '---------- VALIDER ------------------
            GunaButtonValider.Visible = True
            GunaButtonValider.Enabled = False
            GunaLabelValideur.Visible = True
            GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")

            '--------------- COMMANDER --------------
            PictureBoxNext3.Visible = True
            GunaButtonCommander.Visible = True
            GunaButtonCommander.Enabled = False
            GunaLabelCommandeur.Visible = True
            GunaLabelCommandeur.Text = bordereau.Rows(0)("COMMANDER")

        ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 5 Then

            'ANNULATION
            GunaButtonAnnulerBordereau.Visible = False
            GunaButtonAnnulerBordereau.Enabled = False

            empecherAjoutArticle()

            '-------- ENREGISTRER ---------
            GunaLabelEnregistreur.Visible = True
            GunaButtonEnregistrer.Visible = True
            GunaButtonEnregistrer.Enabled = False
            GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

            '------ CONTROLER -----------------
            GunaLabelControleur.Visible = True
            GunaButtonController.Visible = True
            GunaButtonController.Enabled = False
            GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

            PictureBoxNext1.Visible = True

            '------ VERIFICATION -----------------
            GunaButtonVerification.Visible = True
            GunaLabelVerification.Visible = True
            PictureBox1NextStage.Visible = True

            GunaButtonVerification.Enabled = False
            GunaLabelVerification.Visible = True
            GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")

            PictureBox1NextStage.Visible = True

            '---------- VALIDER ------------------
            GunaButtonValider.Visible = True
            GunaButtonValider.Enabled = False
            GunaLabelValideur.Visible = True
            GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")

            '--------------- COMMANDER --------------
            PictureBoxNext3.Visible = True
            GunaButtonCommander.Visible = True
            GunaButtonCommander.Enabled = False
            GunaLabelCommandeur.Visible = True
            GunaLabelCommandeur.Text = bordereau.Rows(0)("COMMANDER")

        ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 6 Then

            'ETAT_BORDEREAU = 6
            '-------- ENREGISTRER ---------
            GunaLabelEnregistreur.Visible = True
            GunaButtonEnregistrer.Visible = True
            GunaButtonEnregistrer.Enabled = False
            GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")

            '------ CONTROLER -----------------
            GunaLabelControleur.Visible = True
            GunaButtonController.Visible = True
            GunaButtonController.Enabled = False
            GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")

        ElseIf bordereau.Rows(0)("ETAT_BORDEREAU") = 7 Then

            GunaLabelEnregistreur.Visible = True
            GunaButtonEnregistrer.Enabled = False
            GunaLabelAnnuler.Text = bordereau.Rows(0)("ENREGISTRER")

            'ANNULATION
            GunaLabelAnnuler.Visible = True
            GunaButtonAnnulerBordereau.Visible = True
            GunaButtonAnnulerBordereau.Enabled = False
            GunaLabelAnnuler.Text = bordereau.Rows(0)("ANNULER")

        End If

    End Sub

    Private Sub ActualisationDesBoutons(ByVal ETAT_BORDEREAU As Integer, ByVal bordereau As DataTable)

        '1-/- AFFICHAGE DES ELEMENTS DU PARCOURS

        If ETAT_BORDEREAU = 0 Then
            GunaLabelEnregistreur.Visible = True
            GunaLabelEnregistreur.Text = bordereau.Rows(0)("ENREGISTRER")
            GunaButtonEnregistrer.Visible = True
        End If

        If ETAT_BORDEREAU = 1 Then
            GunaLabelControleur.Visible = True
            GunaLabelControleur.Text = bordereau.Rows(0)("CONTROLER")
            GunaButtonController.Visible = True
        End If

        If ETAT_BORDEREAU = 2 Then
            GunaLabelVerification.Visible = True
            GunaLabelVerification.Text = bordereau.Rows(0)("VERIFIER")
            GunaButtonVerification.Visible = True
            PictureBoxNext1.Visible = True
        End If

        If ETAT_BORDEREAU = 3 Then
            GunaLabelValideur.Visible = True
            GunaLabelValideur.Text = bordereau.Rows(0)("VALIDER")
            GunaButtonValider.Visible = True
            PictureBox1NextStage.Visible = True
        End If

        If ETAT_BORDEREAU = 4 Then
            GunaLabelCommandeur.Visible = True
            GunaLabelCommandeur.Text = bordereau.Rows(0)("COMMANDER")
            GunaButtonCommander.Visible = True
            PictureBoxNext3.Visible = True
        End If

        '2-/- AFFICHAGE DES ELEMENTS DU PARCOURS

    End Sub

    Private Sub visibiliteDesBoutonDuParcours()

        If Not Trim(GunaTextBoxCodeBordereau.Text).Equals("") Then

            Dim bordero As DataTable = Functions.getElementByCode(GunaTextBoxCodeBordereau.Text, "bordereaux", "CODE_BORDEREAUX")

            If bordero.Rows.Count > 0 Then

                etapeDuParcoursMiseAjours(bordero)

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

                    Dim ETAT_BORDEREAU As Integer = bordero.Rows(0)("ETAT_BORDEREAU")

                    If ETAT_BORDEREAU = 1 Then

                        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("VERIFICATION") = 0 Then
                            GunaButtonVerification.Enabled = False
                        Else
                            GunaLabelVerification.Enabled = True
                        End If

                    ElseIf ETAT_BORDEREAU = 2 Then

                        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("VALIDER") = 0 Then
                            GunaButtonValider.Enabled = False
                            'GunaLabelValideur.Visible = False
                        Else
                            GunaButtonValider.Enabled = True
                        End If

                    ElseIf ETAT_BORDEREAU = 3 Then

                        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("COMMANDER") = 0 Then
                            GunaButtonCommander.Enabled = False
                            'GunaLabelCommandeur.Visible = False
                        Else
                            GunaButtonCommander.Enabled = True
                        End If

                    ElseIf ETAT_BORDEREAU = 0 Then

                        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CONTROLER") = 0 Then
                            GunaButtonController.Enabled = False
                        Else
                            GunaButtonController.Enabled = True
                            'GunaLabelVerification.Visible = False
                        End If

                    End If

                End If

            Else

                GunaLabelControleur.Visible = False
                GunaButtonController.Visible = False
                PictureBoxNext1.Visible = False
                GunaButtonVerification.Visible = False
                GunaLabelVerification.Visible = False
                GunaLabelValideur.Visible = False
                GunaButtonValider.Visible = False
                PictureBox1NextStage.Visible = False
                GunaButtonValider.Visible = False
                GunaLabelValideur.Visible = False
                PictureBoxNext3.Visible = False
                GunaLabelCommandeur.Visible = False
                GunaButtonCommander.Visible = False
                GunaLabelEnregistreur.Visible = False
                'GunaButtonEnregistrer.Visible = False

            End If

        Else

            GunaLabelControleur.Visible = False
            GunaButtonController.Visible = False
            PictureBoxNext1.Visible = False
            GunaButtonVerification.Visible = False
            GunaLabelVerification.Visible = False
            GunaLabelValideur.Visible = False
            GunaButtonValider.Visible = False
            PictureBox1NextStage.Visible = False
            GunaButtonValider.Visible = False
            GunaLabelValideur.Visible = False
            PictureBoxNext3.Visible = False
            GunaLabelCommandeur.Visible = False
            GunaButtonCommander.Visible = False
            GunaLabelEnregistreur.Visible = False
            'GunaButtonEnregistrer.Visible = False

        End If

    End Sub

    'VISIBILITE DES BOUTONS
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        visibiliteDesBoutonDuParcours()
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles GunaComboBoxListeDesMagasinPourInventaire.SelectedIndexChanged

    End Sub

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

    Private Sub GunaButtonImpressionDirecte_Click(sender As Object, e As EventArgs) Handles GunaButtonImpressionDirecte.Click

        Dim totalAchat As Double = 0
        Dim numeroBon As String = GunaTextBoxCodeBordereau.Text

        If Not Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
            totalAchat = GunaTextBoxMontantHTGeneralAchat.Text
        End If

        Dim totalVente As Double = 0

        If Not Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
            totalVente = GunaTextBoxMontantTTCGeneralVente.Text
        End If

        Dim title As String = LabelBon.Text
        Dim nomTiers As String = GunaTextBoxNomTiers.Text
        Dim libelle As String = GunaTextBoxLibelleBordereau.Text
        Dim reference As String = GunaTextBoxReference.Text
        Dim observation As String = GunaTextBoxObservation.Text

        '--------------------------

        Dim typeBordereau As String = GlobalVariable.list_du_marche
        Dim from As String = ""
        Dim ETAT_BORDEREAUX_MAIL As Integer = 0

        '--------------------------

        If GunaComboBoxTypeBordereau.SelectedIndex = 2 Then
            'INVENTAIRES
            Impression.impressionEconomat(GunaDataGridViewInventaire, title, totalAchat, totalVente, numeroBon, nomTiers, libelle, reference, observation)
        Else

            If GunaComboBoxTypeBordereau.SelectedIndex = 10 Then
                'GESSTION DES LISTES DU MARCHE
                Impression.impressionEconomaListeMarche(title, totalAchat, totalVente, numeroBon, nomTiers, libelle, reference, observation)
            Else
                'AUTRES DOCUMENTS
                Impression.impressionEconomat(GunaDataGridViewLigneArticleCommande, title, totalAchat, totalVente, numeroBon, nomTiers, libelle, reference, observation)
            End If

        End If

    End Sub

    Dim entreeSortieOuAchatPeriodique As Integer

    Private Sub GunaButton6_Click_2(sender As Object, e As EventArgs) Handles GunaButton6.Click

        'ENTREES / SORTIES PAR MAGASIN
        LabelTypeDeRapport.Text = "ENTREES - SORTIES PAR MAGASIN"

        nettoyageDuDataGrid()

        entreeSortieOuAchatPeriodique = 0 ' ON TRAITE LES ENTREES SORTIES DE CHAQUE MAGASIN

        GunaRadioButtonParBordero.Checked = True
        GunaRadioButtonParBordero.Visible = True

        GunaRadioButtonParTypeEtDate.Visible = False

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True

        GlobalVariable.typeRapportEconmat = "ES" 'ENTREES SORTIES PAR MAGASIN

        GunaComboBoxTypeBorderoRapport.Visible = False

        GunaDateTimePicker1.Visible = False
        GunaDateTimePicker2.Visible = False
        GunaLabelDu.Visible = False
        GunaLabelAu.Visible = False
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = False
        GunaRadioButtonParBordero.Visible = False
        GunaTextBoxElementRapport.Visible = False

        '-----------------------------------------------------
        GunaDateTimePicker1.Visible = True
        GunaDateTimePicker2.Visible = True
        GunaLabelDu.Visible = True
        GunaLabelAu.Visible = True
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = True
        GunaComboBoxEntreSortie.Visible = True
        GunaComboBoxEntreSortie.SelectedIndex = 0
        GunaComboBoxGlobalIndividuel.Visible = True
        GunaComboBoxGlobalIndividuel.SelectedIndex = 0
        GunaDataGridViewBorderoByTypeEtDate.Visible = True


    End Sub

    Private Sub GunaButton9_Click(sender As Object, e As EventArgs) Handles GunaButton9.Click

        'ACHATS PERIODIQUE
        LabelTypeDeRapport.Text = "ACHATS SUR UNE PERIODE"
        nettoyageDuDataGrid()

        GunaRadioButtonParBordero.Checked = True
        GunaRadioButtonParBordero.Visible = True

        GunaRadioButtonParTypeEtDate.Visible = False

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True

        GlobalVariable.typeRapportEconmat = "AP" 'ACHATS PERIODIQUES

        entreeSortieOuAchatPeriodique = 1 ' ON TRAITE LES ACHATS PERIODIQUES

        GunaComboBoxTypeBorderoRapport.Visible = False

        GunaDateTimePicker1.Visible = False
        GunaDateTimePicker2.Visible = False
        GunaLabelDu.Visible = False
        GunaLabelAu.Visible = False
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = False
        GunaRadioButtonParBordero.Visible = False
        GunaTextBoxElementRapport.Visible = False

        '-----------------------------------------------------
        GunaDateTimePicker1.Visible = True
        GunaDateTimePicker2.Visible = True
        GunaLabelDu.Visible = True
        GunaLabelAu.Visible = True
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaButtonAfficher.Visible = True
        GunaComboBoxEntreSortie.Visible = False
        GunaComboBoxEntreSortie.SelectedIndex = 0
        GunaComboBoxGlobalIndividuel.Visible = True
        GunaComboBoxGlobalIndividuel.SelectedIndex = 0
        GunaDataGridViewBorderoByTypeEtDate.Visible = True

    End Sub

    Private Sub GunaComboBoxEntreSortie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxEntreSortie.SelectedIndexChanged
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaDataGridViewBorderoByTypeEtDate.Columns.Clear()
    End Sub

    Private Sub GunaComboBoxGlobalIndividuel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxGlobalIndividuel.SelectedIndexChanged
        GunaButtonImpirmerRapportEconomat.Visible = False
        GunaDataGridViewBorderoByTypeEtDate.Columns.Clear()
    End Sub

    Private Sub GunaCheckBoxPUOuPT_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxPUOuPT.CheckedChanged

        If GlobalVariable.actualLanguageValue = 1 Then

            If GunaCheckBoxPUOuPT.Checked Then
                GunaCheckBoxPUOuPT.Text = "Prix Unitaire"
                LabelCout.Text = "PU"
            Else
                GunaCheckBoxPUOuPT.Text = "Prix Total"
                LabelCout.Text = "PT"
            End If

        Else

            If GunaCheckBoxPUOuPT.Checked Then
                GunaCheckBoxPUOuPT.Text = "Unit Price"
                LabelCout.Text = "UP"
            Else
                GunaCheckBoxPUOuPT.Text = "Total Price"
                LabelCout.Text = "TP"
            End If

        End If

    End Sub

    Private Sub GunaTextBoxMontantHTGeneralAchat_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantHTGeneralAchat.TextChanged

        Dim totalAchat As Double = 0
        Dim totalVente As Double = 0
        Dim totalMarge As Double = 0

        If Not Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
            totalAchat = GunaTextBoxMontantHTGeneralAchat.Text
        End If

        If Not Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
            totalVente = GunaTextBoxMontantTTCGeneralVente.Text
        End If

        GunaTextBoxMarge.Text = Format(totalVente - totalAchat, "#,##0")

    End Sub

    Private Sub GunaTextBoxMontantTTCGeneralVente_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantTTCGeneralVente.TextChanged

        Dim totalAchat As Double = 0
        Dim totalVente As Double = 0
        Dim totalMarge As Double = 0

        If Not Trim(GunaTextBoxMontantHTGeneralAchat.Text).Equals("") Then
            totalAchat = GunaTextBoxMontantHTGeneralAchat.Text
        End If

        If Not Trim(GunaTextBoxMontantTTCGeneralVente.Text).Equals("") Then
            totalVente = GunaTextBoxMontantTTCGeneralVente.Text
        End If

        GunaTextBoxMarge.Text = Format(totalVente - totalAchat, "#,##0")

    End Sub

    'GESTION DES DATES FICITIVES

    Private Sub GunaCheckBoxDateFictive_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDateFictive.Click

        If GunaCheckBoxDateFictive.Checked Then
            GunaDateTimePickerDateDeTravailFictif.Visible = True
            GlobalVariable.DateDeTravail = GunaDateTimePickerDateDeTravailFictif.Value.ToShortDateString
        Else
            GunaDateTimePickerDateDeTravailFictif.Visible = False
            GlobalVariable.DateDeTravail = Functions.ObtenirDateDeTravail()
            GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail
        End If

    End Sub

    Private Sub GunaDateTimePickerDateDeTravailFictif_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDateDeTravailFictif.ValueChanged

        If GunaCheckBoxDateFictive.Checked Then
            GunaDateTimePickerDateDeTravailFictif.Visible = True
            GlobalVariable.DateDeTravail = GunaDateTimePickerDateDeTravailFictif.Value.ToShortDateString

            GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail
        End If

    End Sub

    Private Sub GunaButtonDetails_Click(sender As Object, e As EventArgs) Handles GunaButtonDetails.Click

        'OBTENTION DES PRIX 

        If GunaDataGridViewLigneArticleCommande.Rows.Count > 0 Then

            priceDetailForm.Show()
            priceDetailForm.TopMost = True

        End If

    End Sub

    Private Sub GunaButton10_Click(sender As Object, e As EventArgs) Handles GunaButton10.Click

        nettoyageDuDataGrid()
        'COMMMANDE DE LA CUISINE

        GunaRadioButtonParTypeEtDate.Checked = True

        GunaRadioButtonParTypeEtDate.Visible = True
        GunaRadioButtonParTypeEtDate.Text = "PREPARATION / COMMANDE DE LA CUISINE"

        GunaRadioButtonParBordero.Text = "PREPARATION / COMMANDE DE LA CUISINE"

        'GunaRadioButtonParTypeEtDate.Checked = False
        GunaRadioButtonParBordero.Visible = False
        GunaTextBoxElementRapport.Visible = False

        GunaComboBoxTypeBorderoRapport.Visible = False

        GunaDateTimePicker1.Visible = True
        GunaDateTimePicker2.Visible = True
        GunaLabelDu.Visible = True
        GunaLabelAu.Visible = True
        GunaButtonImpirmerRapportEconomat.Visible = True

        PanelApport.Visible = True
        LabelTypeDeRapport.Visible = True
        LabelTypeDeRapport.Text = "PREPARATION / COMMANDE DE LA CUISINE"

        GlobalVariable.typeRapportEconmat = "RECAP_CUISINE"

    End Sub

    Private Sub GunaDateTimePickerP1LM_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerP1LM.ValueChanged
        GunaDateTimePickerP2LM.Value = GunaDateTimePickerP1LM.Value.AddDays(7)
    End Sub

    Private Sub documentToBeSendUsingBackGroundWorker(ByVal args As ArgumentType)

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        ElseIf args.action = 1 Then
            RapportApresCloture.impressionEconomat(GunaDataGridViewLigneArticleCommande, title, totalAchat, totalVente, numeroBon, ETAT_BORDEREAUX_MAIL, nomTiers, libelle, reference, observation, typeBordereau)
        ElseIf args.action = 2 Then

        End If

    End Sub

    Private Sub ToolStripMenuItem119_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem119.Click
        Dim dialog As DialogResult

        If GlobalVariable.actualLanguageValue = 1 Then
            dialog = MessageBox.Show("Voulez-vous vraiment fermer ", "Fermer BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Else
            dialog = MessageBox.Show("Do you really want to close your session ", "Close BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        End If

        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else

            Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

            Dim CODE_CAISSE As String = ""

            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

            End If

            Dim ETAT_CAISSE As Integer = 0
            Dim caissier As New Caisse()

            'caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

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

        End If
    End Sub

    Private Sub ToolStripMenuItem117_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem117.Click

        GlobalVariable.changerMotDePasseDepuis = "economat"
        ChangePasswordForm.Show()
        ChangePasswordForm.TopMost = True

    End Sub

    Private Sub ToolStripMenuItem86_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem86.Click
        ArticleForm.Close()

        GlobalVariable.typeArticle = "article"
        ArticleForm.TopMost() = True
        ArticleForm.Show()
    End Sub

    Private Sub MatièresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MatièresToolStripMenuItem.Click
        GlobalVariable.typeArticle = "matiere"
        ArticleForm.TopMost() = True
        ArticleForm.Show()
    End Sub

    Private Sub ToolStripMenuItem93_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem93.Click
        UniteDeComptageForm.Close()
        UniteDeComptageForm.TopMost() = True
        UniteDeComptageForm.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

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

    Private Sub backGroundWorkerToCall(ByVal args As ArgumentType)

        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker2.IsBusy Then
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

    Private Sub ToolStripMenuItem82_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem82.Click
        ArticleFamilyForm.Close()

        GlobalVariable.typeFamilleOuSousFamille = "famille" 'POINT DE VENTE

        ArticleFamilyForm.Show()

        ArticleFamilyForm.TopMost = True
    End Sub

    Private Sub CatégoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatégoriesToolStripMenuItem.Click
        ArticleFamilyForm.Close()

        GlobalVariable.typeFamilleOuSousFamille = "categorie" 'CATEGORIE

        ArticleFamilyForm.Show()

        ArticleFamilyForm.TopMost() = True
    End Sub

    Private Sub ToolStripMenuItem83_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem83.Click
        ArticleFamilyForm.Close()

        GlobalVariable.typeFamilleOuSousFamille = "sous famille" 'FAMILLE
        ArticleFamilyForm.TopMost() = True
        ArticleFamilyForm.Show()
    End Sub

    Private Sub FamilleDArToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamilleDArToolStripMenuItem.Click
        ArticleFamilyForm.Close()

        GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" 'SOUS FAMILLE
        ArticleFamilyForm.TopMost() = True
        ArticleFamilyForm.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        notification()

    End Sub

    Private Sub GunaButton13_Click(sender As Object, e As EventArgs) Handles GunaButton13.Click
        Dim econom As New Economat
        econom.freeligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"))
        GunaDataGridViewLigneArticleCommande.DataSource = Nothing
    End Sub

    Private Sub GunaButton16_Click(sender As Object, e As EventArgs) Handles GunaButton16.Click

        Dim title As String = "Inventaire " & GlobalVariable.DateDeTravail.ToString("ddMMyyHms")
        If GlobalVariable.actualLanguageValue = 0 Then
            title = "Inventory Excel " & GlobalVariable.DateDeTravail.ToString("ddMMyyHms")
        End If
        Impression.inventoryExportExcelForm(GunaDataGridViewInventaire, title)

    End Sub
End Class