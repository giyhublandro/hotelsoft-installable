Imports MySql.Data.MySqlClient

Public Class BarRestaurantForm

    Public Class ArgumentType

        'action = 0 : ultrMessageSimpleText
        Public action As Integer
        Public whatsAppMessage As String
        Public mobile_number As String
        Public dt As DataTable
        Public DateDebut As Date
        Public DateFin As Date
        Public fichier As String

    End Class

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

    Structure BlocNote

        Dim NUMERO_BLOC_NOTE

    End Structure

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

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Functions.exitApplicationThread()
    End Sub

    Public Sub bloquerLaModificationDuPrixUnitaire()
        If GlobalVariable.AgenceActuelle.Rows(0)("PRIX_BAR_RESTAU_MODIFIABLE") = 1 Then
            GunaTextBoxMontantHT.Enabled = True
        Else
            GunaTextBoxMontantHT.Enabled = False
        End If
    End Sub

    'ON CREE LA MAINCOURANTE AUTRES SI ELLE N'EXISTE PAS

    Private Sub creationMainCouranteAutres()

        Dim ETAT_MAIN_COURANTE As Integer = 0

        Dim main_courante_autres As DataTable = Functions.getElementByOnCodeAndDate(ETAT_MAIN_COURANTE, "main_courante_autres", "ETAT_MAIN_COURANTE", GlobalVariable.DateDeTravail, "main_courante_autres")

        'LA MAIN COURANTE EN DATE DU JOUR EST INEXISTANTE

        If Not main_courante_autres.Rows.Count > 0 Then

            '-SI NON CREATION D'UNE NOUVELLE PUIS MISE AJOURS
            '1.1 - LA CREATION DEVRA SE FAIRE UNE SEULE FOIS POUR TOUT LE CYCLE D'EXITENCE DU LOGICIEL

            '-----------------------------------

            Dim CODE_MAIN_COURANTE_AUTRES = Functions.GeneratingRandomCodePanne("main_courante_autres", "MCA")
            Dim DATE_MAIN_COURANTE As Date = GlobalVariable.DateDeTravail
            Dim CODE_CHAMBRE As String = ""
            Dim MONTANT_ACCORDE As Double = 0
            Dim ETAT_CHAMBRE As Integer = 0
            Dim NOM_CLIENT As String = GunaTextBoxNom_Prenom.Text
            Dim PDJ As Double = 0
            Dim DEJEUNER As Double = 0
            Dim DINER As Double = 0
            Dim CAFE As Double = 0
            Dim BAR As Double = 0
            Dim CAVE As Double = 0
            Dim AUTRE As Double = 0
            Dim SOUS_TOTAL1 As Double = 0
            Dim LOCATION As Double = 0
            Dim TELE As Double = 0
            Dim FAX As Double = 0
            Dim LINGE As Double = 0
            Dim DIVERS As Double = 0
            Dim SOUS_TOTAL2 As Double = 0
            Dim TOTAL_JOUR As Double = 0
            Dim REPORT_VEILLE As Double = 0
            Dim TOTAL_GENERAL As Double = 0
            Dim NUM_RESERVATION As String = 0
            Dim DEDUCTION As Double = 0
            Dim ENCAISSEMENT_ESPECE As Double = 0
            Dim ENCAISSEMENT_CHEQUE As Double = 0
            Dim ENCAISSEMENT_CARTE_CREDIT As Double = 0
            Dim DEBITEUR As Double = 0
            Dim ARRHES As Double = 0
            Dim A_REPORTER As Double = 0
            Dim OBSERVATIONS As Double = 0
            Dim TYPE_CHAMBRE As Double = 0
            Dim INDICE_FREQUENTATION As Double = 0
            Dim INDICE_FREQUENTATION_PCT As Double = 0
            Dim TAUX_OCCUPATION As Double = 0
            Dim TAUX_OCCUPATION_PCT As Double = 0
            Dim CLIENTS_ATTENDUS As Integer = 0
            Dim CLIENTS_EN_CHAMBRE As Integer = 0
            Dim CHAMBRES_DISPONIBLES As Integer = 0
            Dim TOTAL_HORS_SERVICE As Integer = 0
            Dim CHAMBRES_HORS_SERVICE As Integer = 0
            Dim TOTAL_FICTIVES As Integer = 0
            Dim CHAMBRES_FICTIVES As Integer = 0
            Dim NOMBRE_MESSAGES As Integer = 0
            Dim TOTAL_GRATUITES As Integer = 0
            Dim CHAMBRES_GRATUITES As Integer = 0
            Dim TOTAL_NON_FACTUREES As Integer = 0
            Dim CHAMBRES_NON_FACTUREES As Integer = 0
            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            Dim CODE_CLIENT As String = ""

            Dim query As String = "SELECT * FROM client WHERE TYPE_CLIENT=@TYPE_CLIENT ORDER BY NOM_PRENOM ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Client As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "COMPTOIR"

            adapter.SelectCommand = command

            adapter.Fill(Client)

            If (Client.Rows.Count > 0) Then
                GunaTextBoxNom_Prenom.Enabled = False
                CODE_CLIENT = Client.Rows(0)("CODE_CLIENT")
                NOM_CLIENT = Client.Rows(0)("NOM_PRENOM")
            End If

            Dim TYPE_CHAMBRE_OU_SALLE As String = "" 'criteres de filtre

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                TYPE_CHAMBRE_OU_SALLE = "comptoir"
            End If

            Dim mainCourantes As New MainCourantes()

            If mainCourantes.insertMainCouranteAutres(CODE_MAIN_COURANTE_AUTRES, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, LOCATION, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

            End If

        End If
    End Sub

    Private Sub BarRestaurantForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TimerRefreshConnexion.Start()

        Dim language As New Languages()

        language.barRestaurant(GlobalVariable.actualLanguageValue)

        If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
            GunaComboBoxFiltreBlocNotre.Visible = True
        Else
            GunaComboBoxFiltreBlocNotre.Visible = False
        End If

        '----------------------------------------------------------------------------------------------------------------------------------------------------

        'autoLoadMagasinActuel()

        GlobalVariable.typeDeClientAFacturer = "comptoir"

        GlobalVariable.billetageAPartirDe = "bar"

        creationMainCouranteAutres()
        '---------------------------------------------------------------------------------------------------------------

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("IMPRIMER_FB") = 1 Then
            GunaButtonImprimer.Visible = True
        Else
            GunaButtonImprimer.Visible = False
        End If

        bloquerLaModificationDuPrixUnitaire()

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail

        GunaTextBoxCodeClient.Visible = True

        GlobalVariable.ArticleFamily = "BAR"

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()

        indicateurDEtatDeCaisse()

        LabelNomCaissier.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

        GunaDateTimePickerParDateFin.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerParDateDebut.Value = GlobalVariable.DateDeTravail

        Dim menuAccess As New AccessRight()

        menuAccess.accesAuxModules(GlobalVariable.DroitAccesDeUtilisateurConnect, ReceptionToolStripMenuItem, RESERVATIONToolStripMenuItem, SERVICEDETAGEToolStripMenuItem, BarRestaurationToolStripMenuItem, ComptabilitéToolStripMenuItem, ECONOMATToolStripMenuItem, TECHNIQUEToolStripMenuItem, ToolStripMenuItemCusine)

        menuAccess.administrationDuModule(GlobalVariable.DroitAccesDeUtilisateurConnect, ToolStripMenuItemSession, ToolStripMenuItemConfig, ToolStripMenuItemServTech, ToolStripMenuItemSecurite, ClôturerToolStripMenuItem, ToolStripSeparatorCloture, FermerCaisseToolStripMenuItem, OuvrirCaisseToolStripMenuItem, ToolStripSeparator2)

        GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then
            GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
        End If

        'TITRE DE LA FENETRE
        If GlobalVariable.softwareVersion = "barcleshsoftdbdemo" Then
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") + " (DEMO) "
        Else
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        End If

        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
            GunaDataGridViewBlocNoteOuvert.Visible = True
            LabelBlocNoteOuvert.Visible = True
        Else
            GunaDataGridViewBlocNoteOuvert.Visible = False
            LabelBlocNoteOuvert.Visible = False
        End If

        If Trim(GlobalVariable.ArticleFamily) = "" Then
            GlobalVariable.ArticleFamily = "BAR"
        End If

        'Oon affiche le bouton permettant de lire la carte si on traite un client en chambre

        'gestion des cartes d'acces
        CB_Software.SelectedIndex = 0
        CB_Port.SelectedIndex = 0
        CB_Breakfast.SelectedIndex = 1
        CB_DB.SelectedIndex = 0

        TB_Time.Text = DateTime.Now.ToString("yyyyMMdd1200") + DateTime.Now.AddDays(1).ToString("yyyyMMdd1200")

        GunaTextBoxFacturationDate.Text = GlobalVariable.DateDeTravail

        'Managing  the facturationcoming from the front desk

        'CLIENT COMPTOIRE
        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            If Trim(GunaTextBoxNumfacture.Text) = "" Then
                'GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCode("facture", "")
            End If

            GunaTextBoxBlocNote.Visible = True
            GunaComboBoxListeDesComandes.Visible = True
            LabelBlocNoteOuTable.Visible = True

            'Client comptoir liste des commandes pour chaque bloc_note
            AutoLoadOfBlocNote()

            'On selectionne le nouveau bloc note affiché par défaut
            Dim blocNoteEnCours As DataTable

            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                'We have atleast an element in our combobox
                blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If blocNoteEnCours.Rows.Count > 0 Then

                    'On insere le numero de la proforma lié a cette facture
                    GunaTextBoxNumfacture.Text = blocNoteEnCours.Rows(0)("CODE_FACTURE")
                    GunaTextBoxCodeClient.Text = blocNoteEnCours.Rows(0)("CODE_CLIENT")

                    If Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT").Rows.Count > 0 Then
                        GunaTextBoxNom_Prenom.Text = Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT").Rows(0)("NOM_PRENOM")
                    End If

                    'CLIENT FIDELE

                    GunaTextBoxCodeElite.Text = blocNoteEnCours.Rows(0)("CODE_ELITE")
                    GunaTextBoxRefClient.Text = blocNoteEnCours.Rows(0)("CODE_CLIENT_FIDEL")
                    Dim CODE_CLIENT_FIDEL As String = blocNoteEnCours.Rows(0)("CODE_CLIENT_FIDEL")
                    Dim CODE_ELITE As String = blocNoteEnCours.Rows(0)("CODE_ELITE")

                    Dim ClientFidel As DataTable = Functions.getElementByCode(CODE_CLIENT_FIDEL, "client", "CODE_CLIENT")

                    If ClientFidel.Rows.Count > 0 Then
                        GunaTextBoxNomPrenom.Text = ClientFidel.Rows(0)("NOM_PRENOM") 'Nom du client Fidel

                        If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then
                            AffichageDesIinformationsDuCLientFidel(CODE_ELITE, CODE_CLIENT_FIDEL)
                        End If

                    Else
                        GunaTextBoxNomPrenom.Text = ""
                    End If

                    Dim ListeDesArticlesDeCetteComandes As DataTable = Functions.GetAllElementsOnCondition(blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE"), "ligne_facture_temp", "NUMERO_BLOC_NOTE")
                    'On charge l'ensemble des articles en relation avec cette commande ou numero de bloc note
                    If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then
                        OutPutLigneFacture()
                    Else
                        'GunaDataGridViewLigneFacture.Columns.Clear()
                    End If

                    If GlobalVariable.actualLanguageValue = 0 Then
                        If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                            GunaButtonSaveFacturation.Text = "Close"
                        ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                            GunaButtonSaveFacturation.Text = "Pay"
                        End If
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                            GunaButtonSaveFacturation.Text = "Clôturer"
                        ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                            GunaButtonSaveFacturation.Text = "Régler"
                        End If
                    End If

                    FacturationKeyInformation()

                    GunaTextBoxCodeClient.Visible = False

                    DisplaySavingButton()

                Else

                    GunaTextBoxCodeClient.Visible = True

                End If

            End If

        Else

        End If

        '----------------------------------------------------------------------------------------------------------------------------------------------------

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then
            GunaCheckBoxDateFictive.Visible = True
        Else
            GunaCheckBoxDateFictive.Visible = False
        End If

        SituationDeCaisseJournaliere()

        resumeDesVentesDuJours(CDate(GlobalVariable.DateDeTravail).ToShortDateString)

        'gestion_des_shifts : ON REGARDE SI L'UTILISATEUR A DEJA UN MAGASIN ET SON SHIFT UTILE POUR LA GESTION DES STOCKS
        Functions.magasinActuelEtShiftDunUtilisateur()

        If GlobalVariable.actualLanguageValue = 0 Then

            GunaDataGridViewBills.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
            GunaDataGridViewBills.Columns.Add("AMOUNT", "AMOUNT")
            GunaDataGridViewBills.Columns.Add("STATE", "STATE")
            GunaDataGridViewBills.Columns.Add("TIME", "TIME")

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            GunaDataGridViewBills.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
            GunaDataGridViewBills.Columns.Add("MONTANT", "MONTANT")
            GunaDataGridViewBills.Columns.Add("ETAT", "ETAT")
            GunaDataGridViewBills.Columns.Add("TEMPS", "TEMPS")

        End If
    End Sub

    Private Sub GunaAdvenceButtonFacturationDesEnChambres_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonFacturationDesEnChambres.Click

        '-----------------------------------------------------------

        Dim continuer As Boolean = True

        If GunaLabelHeader.Text.Equals("EN CHAMBRE") Then
            continuer = False
        End If

        If GunaLabelHeader.Text.Equals("IN HOUSE") Then
            continuer = False
        End If

        If continuer Then

            Me.Cursor = Cursors.WaitCursor

            GunaComboBoxFiltreBlocNotre.Visible = False

            GunaDataGridViewClient.BringToFront()

            ClearFacturationKeyInformation()
            clearArticleFields()

            GlobalVariable.typeDeClientAFacturer = "en chambre"

            GunaPanelEnChambre.Visible = True
            GunaPanelEnChambre.BringToFront()
            GunaPanelEventsSup.Visible = False
            GunaPanelClientComptoirSup.Visible = False
            GunaPanelComptoirBloc.Visible = False

            TB_RoomNo.Visible = True
            LabelNumeroChambre.Visible = True
            GunaAdvenceButtonLectureDeCarte.Visible = True

            GunaDataGridViewLigneFacture.Columns.Clear()

            GunaTextBoxCodeClient.Clear()
            GunaTextBoxArticle.Clear()

            GunaTextBoxCodeClient.Visible = True

            If Trim(GlobalVariable.ArticleFamily) = "" Then
                GlobalVariable.ArticleFamily = "BAR"
            End If

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaLabelHeader.Text = "IN HOUSE"
                LibelleFacturation.Text = GlobalVariable.ArticleFamily & " BILLING "
                GunaButtonSaveFacturation.Text = "Save"
                LabelRef.Text = "Customer"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelHeader.Text = "EN CHAMBRE"
                LibelleFacturation.Text = "FACTURATION " & GlobalVariable.ArticleFamily
                GunaButtonSaveFacturation.Text = "Enregistrer"
                LabelRef.Text = "Client"
            End If

            'Oon affiche le bouton permettant de lire la carte si on traite un client en chambre

            tb_server.Text = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_HOTEL_LOCK_SYSTEM")

            'gestion des cartes d'acces
            CB_Software.SelectedIndex = 0
            CB_Port.SelectedIndex = 0
            CB_Breakfast.SelectedIndex = 1
            CB_DB.SelectedIndex = 0

            GunaPanelComptoirBloc.Visible = True

            TB_Time.Text = DateTime.Now.ToString("yyyyMMdd1200") + DateTime.Now.AddDays(1).ToString("yyyyMMdd1200")

            GunaTextBoxFacturationDate.Text = CDate(GlobalVariable.DateDeTravail).ToShortDateString

            'CLIENT EN CHAMBRE

            GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("facture", "")

            GunaTextBoxNom_Prenom.Enabled = False

            TabControlBarRestaurant.SelectedIndex = 0

            TB_RoomNo.Enabled = True

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Public Sub clearArticleFields()

        'We empty article fields
        GunaTextBoxQuantite.Text = 1
        GunaTextBoxMontantHT.Text = 0
        GunaTextBoxTVA.Text = 0
        GunaTextBoxMontantTTC.Text = 0
        GunaTextBoxArticle.Text = ""

        If discounStays = False Then
            GunaTextBoxRemise.Text = 0
        End If

        GunaTextBoxMontantReduction.Text = 0
        GunaTextBoxLecteurRFID.Clear()

    End Sub

    '0- CLEAR KEY INFORMATION
    'We fill the general information concerning the Invoice
    Public Sub ClearFacturationKeyInformation()

        GunaTextBoxMontantTTCGeneral.Text = 0
        GunaTextBoxSoldeClient.Text = 0
        GunaTextBoxTVARecap.Text = 0

    End Sub

    '1- BOUTON A AFFICHER

    Public Sub DisplaySavingButton()

        Dim facturationLine As DataTable

        If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            facturationLine = Functions.getElementByCode(GunaTextBoxNumReservation.Text, "ligne_facture_temp", "CODE_RESERVATION")
        Else
            facturationLine = Functions.getElementByCode(GunaTextBoxNumfacture.Text, "ligne_facture_temp", "CODE_FACTURE")
        End If

        If facturationLine.Rows.Count > 0 Then
            'We can only save a facturation if it is associated to atleast one facturationLine
            'We display the button to save facturation as it is associated to atleast one line in ligne_facturation

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                'On se rassure que notre combo de bloc note n'est pas vide 
                If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                    'puis on selection les informations de numero de bloc note en cour
                    Dim blocNoteEnCours As DataTable
                    blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                    If blocNoteEnCours.Rows.Count > 0 Then
                        'si son etat = 2 alors on ne doit pas afficher au cas contraire on l'affiche
                        If Not blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 2 Then
                            GunaButtonSaveFacturation.Visible = True
                        Else
                            GunaButtonSaveFacturation.Visible = False
                        End If

                    End If

                End If

            Else
                GunaButtonSaveFacturation.Visible = True
            End If

        Else
            'We hide the button to save facturation as it is not associated to atleast one line in ligne_facturation
            GunaButtonSaveFacturation.Visible = False
        End If

    End Sub

    '2- AUTO LOADING FO BLOC NOTE

    Public Sub AutoLoadOfBlocNote()

        Dim ETAT_BLOC_NOTE_NEW As Integer = 1
        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Functions.verifionsQueLesBlocNoteSontDansLeBonEtat(DateDeSituation, ETAT_BLOC_NOTE_NEW)

        'A- CHARGEMENT DE LA LISTE DES BLOCS NOTES

        Dim caisse As New Caisse()

        'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes a cloturer et a regler par apport a un caissier et un a la date de travail

        Dim ETAT_BLOC_NOTE As Integer = 0

        'Commande non clôturée
        Dim ligneFactureBlocNote As DataTable = caisse.AutoLoadBlocNote(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        'Commande clôturée
        ETAT_BLOC_NOTE = 1

        Dim ligneFactureBlocNote1 As DataTable = caisse.AutoLoadBlocNote(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        ligneFactureBlocNote.Merge(ligneFactureBlocNote1)
        'klg
        'GunaComboBoxListeDesComandes.DataSource = Nothing

        If ligneFactureBlocNote.Rows.Count > 0 Then

            GunaComboBoxListeDesComandes.DataSource = ligneFactureBlocNote
            GunaComboBoxListeDesComandes.ValueMember = "NUMERO_BLOC_NOTE"
            GunaComboBoxListeDesComandes.DisplayMember = "NUMERO_BLOC_NOTE"

            'B- SELECTION DU BLOC NOTE A TRAITER

            'CONTROL D'EXISTENCE D'UNE LIGNE DE BLOC_NOTE AU MOINS
            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                'PERMET DE CONTROLLER QUE LES MANIPULATION SE FONT SUR LE BLOC_NOTE_EN_COURS
                If Not Trim(GlobalVariable.blocNoteARegler) = "" Then
                    GunaComboBoxListeDesComandes.SelectedValue = Trim(GlobalVariable.blocNoteARegler)
                Else
                    GunaComboBoxListeDesComandes.SelectedIndex = 0
                End If

                'On selectionne le nouveau bloc note en cas de changement
                Dim blocNoteEnCours As DataTable

                If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                    blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                    If blocNoteEnCours.Rows.Count > 0 Then
                        GunaTextBoxNumfacture.Text = blocNoteEnCours.Rows(0)("CODE_FACTURE")
                    End If

                End If

            End If

        Else
            'GunaComboBoxListeDesComandes.DataSource = Nothing
        End If

        'C- VISUALISATION DE LA LISTE DES BLOC NOTES

        ETAT_BLOC_NOTE = 0 'NON CLOTURER
        Dim blocNoteAvisualiser As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        ETAT_BLOC_NOTE = 1 'CLOTURE DONC A REGLER
        Dim blocNoteAvisualiser2 As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        blocNoteAvisualiser.Merge(blocNoteAvisualiser2)

        GunaDataGridViewBlocNoteOuvert.Columns.Clear()

        If blocNoteAvisualiser.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewBlocNoteOuvert.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("AMOUNT", "AMOUNT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("STATE", "STATE")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("TIME", "TIME")

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewBlocNoteOuvert.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("MONTANT", "MONTANT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("ETAT", "ETAT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("TEMPS", "TEMPS")

            End If

            For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                Dim ETAT_NOTE As String = ""
                Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString

                If GlobalVariable.actualLanguageValue = 0 Then

                    If blocNoteAvisualiser.Rows(i)("STATE") = 0 Then
                        ETAT_NOTE = "TO CLOSE"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                        ETAT_NOTE = "TO BE PAID"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 2 Then
                        ETAT_NOTE = "PAID"
                    End If

                    GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), blocNoteAvisualiser.Rows(i)("AMOUNT"), ETAT_NOTE, TEMPS)

                    GunaDataGridViewBlocNoteOuvert.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteOuvert.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 0 Then
                        ETAT_NOTE = "A CLOTURER"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                        ETAT_NOTE = "A REGLER"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 2 Then
                        ETAT_NOTE = "REGLE"
                    End If

                    GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), blocNoteAvisualiser.Rows(i)("MONTANT"), ETAT_NOTE, TEMPS)

                    GunaDataGridViewBlocNoteOuvert.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteOuvert.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End If

            Next

        End If


        Dim selectionDesDifferentsServeurs As DataTable = caisse.lesDifferentsServeur(DateDeSituation)

        If selectionDesDifferentsServeurs.Rows.Count > 0 Then

            GunaComboBoxFiltreBlocNotre.Items.Clear()

            For i = 0 To selectionDesDifferentsServeurs.Rows.Count - 1

                'Dim CODE_UTILIASTEUR As String = selectionDesDifferentsServeurs.Rows(i)("CODE_CAISSIER")
                'Dim infoSupCassier As DataTable = Functions.getElementByCode(CODE_UTILIASTEUR, "utilisateurs", "CODE_UTILIASTEUR")

                'If infoSupCassier.Rows.Count > 0 Then

                'GunaComboBoxFiltreBlocNotre.Items.Add()

                GunaComboBoxFiltreBlocNotre.Items.Add(selectionDesDifferentsServeurs.Rows(i)("CODE_CAISSIER").ToString.ToUpper)

                'End If

            Next

            GunaComboBoxFiltreBlocNotre.Items.Add("Tous".ToUpper)

            GunaComboBoxFiltreBlocNotre.SelectedIndex = GunaComboBoxFiltreBlocNotre.Items.Count - 1

        End If

        ETAT_BLOC_NOTE = 2 'CLOTURE ET REGLE

        Dim blocNoteAvisualiser3 As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        GunaDataGridViewBlocNoteFermee.Columns.Clear()

        If blocNoteAvisualiser3.Rows.Count > 0 Then


            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewBlocNoteFermee.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNoteFermee.Columns.Add("AMOUNT", "AMOUNT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("STATE", "STATE")

                For i = 0 To blocNoteAvisualiser3.Rows.Count - 1

                    Dim ETAT_NOTE As String = ""

                    If blocNoteAvisualiser3.Rows(i)("STATE") = 2 Then
                        ETAT_NOTE = "PAID"
                    End If

                    GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser3.Rows(i)("RECEIPT NUMBER"), blocNoteAvisualiser3.Rows(i)("AMOUNT"), ETAT_NOTE)

                    GunaDataGridViewBlocNoteFermee.DefaultCellStyle.ForeColor = Color.DarkRed

                    GunaDataGridViewBlocNoteFermee.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteFermee.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Next

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewBlocNoteFermee.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
                GunaDataGridViewBlocNoteFermee.Columns.Add("MONTANT", "MONTANT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("ETAT", "ETAT")

                For i = 0 To blocNoteAvisualiser3.Rows.Count - 1

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser3.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString

                    If blocNoteAvisualiser3.Rows(i)("ETAT") = 2 Then
                        ETAT_NOTE = "REGLE"
                    End If

                    GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser3.Rows(i)("NUMERO BLOC NOTE"), blocNoteAvisualiser3.Rows(i)("MONTANT"), ETAT_NOTE)

                    GunaDataGridViewBlocNoteFermee.DefaultCellStyle.ForeColor = Color.DarkRed

                    GunaDataGridViewBlocNoteFermee.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteFermee.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Next

            End If

        End If

        BlocNotesVisualisation()

    End Sub

    Private Sub BlocNotesVisualisation()

        Dim caisse As New Caisse()

        'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes a cloturer et a regler par apport a un caissier et un a la date de travail

        Dim ETAT_BLOC_NOTE As Integer = 0 'NON CLOTURER

        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")


        'C- VISUALISATION DE LA LISTE DES BLOC NOTES

        Dim blocNoteAvisualiser As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        ETAT_BLOC_NOTE = 1 'CLOTURE DONC A REGLER
        Dim blocNoteAvisualiser2 As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        blocNoteAvisualiser.Merge(blocNoteAvisualiser2)

        GunaDataGridViewBlocNoteOuvert.Columns.Clear()

        If blocNoteAvisualiser.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewBlocNoteOuvert.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("AMOUNT", "AMOUNT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("STATE", "STATE")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("TEMPS", "TEMPS")

                For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString

                    If blocNoteAvisualiser.Rows(i)("STATE") = 0 Then
                        ETAT_NOTE = "OPENED"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                        ETAT_NOTE = "CLOSED"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 2 Then

                        ETAT_NOTE = "PAID"
                    End If

                    GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), blocNoteAvisualiser.Rows(i)("AMOUNT"), ETAT_NOTE, TEMPS)

                    GunaDataGridViewBlocNoteOuvert.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteOuvert.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Next

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewBlocNoteOuvert.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("MONTANT", "MONTANT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("ETAT", "ETAT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("TIME", "TIME")

                For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 0 Then
                        ETAT_NOTE = "OUVERT"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                        ETAT_NOTE = "FERMÉ"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 2 Then
                        ETAT_NOTE = "REGLÉ"
                    End If

                    GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), blocNoteAvisualiser.Rows(i)("MONTANT"), ETAT_NOTE, TEMPS)

                    GunaDataGridViewBlocNoteOuvert.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteOuvert.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Next

            End If

        End If

        ETAT_BLOC_NOTE = 2 'CLOTURE ET REGLE
        Dim blocNoteAvisualiser3 As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        GunaDataGridViewBlocNoteFermee.Columns.Clear()

        If blocNoteAvisualiser3.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewBlocNoteFermee.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNoteFermee.Columns.Add("AMOUNT", "AMOUNT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("STATE", "STATE")

                For i = 0 To blocNoteAvisualiser3.Rows.Count - 1

                    Dim ETAT_NOTE As String = ""

                    If blocNoteAvisualiser3.Rows(i)("STATE") = 2 Then
                        ETAT_NOTE = "PAID"
                    End If

                    GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser3.Rows(i)("RECEIPT NUMBER"), blocNoteAvisualiser3.Rows(i)("AMOUNT"), ETAT_NOTE)

                    GunaDataGridViewBlocNoteFermee.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteFermee.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Next

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewBlocNoteFermee.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
                GunaDataGridViewBlocNoteFermee.Columns.Add("MONTANT", "MONTANT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("ETAT", "ETAT")

                For i = 0 To blocNoteAvisualiser3.Rows.Count - 1

                    Dim ETAT_NOTE As String = ""

                    If blocNoteAvisualiser3.Rows(i)("ETAT") = 2 Then
                        ETAT_NOTE = "REGLE"
                    End If

                    GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser3.Rows(i)("NUMERO BLOC NOTE"), blocNoteAvisualiser3.Rows(i)("MONTANT"), ETAT_NOTE)

                    GunaDataGridViewBlocNoteFermee.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteFermee.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Next

            End If

        End If

    End Sub
    '3- FACTURATION KEY INFORMATION

    Public Sub FacturationKeyInformation()

        Dim MontantHTGeneral As Double = 0
        Dim MontantTTCGeneral As Double = 0

        Dim FacturationLineList As DataTable

        If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            FacturationLineList = Functions.getElementByCode(GunaTextBoxNumReservation.Text, "ligne_facture_temp", "CODE_RESERVATION")
        Else
            FacturationLineList = Functions.getElementByCode(GunaTextBoxNumfacture.Text, "ligne_facture_temp", "CODE_FACTURE")
        End If

        If FacturationLineList.Rows.Count > 0 Then

            For i = 0 To FacturationLineList.Rows.Count - 1
                MontantHTGeneral += FacturationLineList.Rows(i)("MONTANT_HT")
                MontantTTCGeneral += FacturationLineList.Rows(i)("MONTANT_TTC")
            Next

        End If

        GunaTextBoxMontantTTCGeneral.Text = Format(MontantTTCGeneral, "#,##0")

    End Sub

    Public Sub OutPutLigneFactureFermee(ByVal NUMERO_BLOC_NOTE As String)

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            getUserQuery = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',
            PRIX_UNITAIRE_TTC As 'UNIT PRICE', ligne_facture.QUANTITE AS QUANTITY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', 
            GRIFFE_UTILISATEUR AS 'USER' FROM ligne_facture WHERE NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE ORDER BY LIBELLE_FACTURE ASC"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            getUserQuery = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',
            PRIX_UNITAIRE_TTC As 'PU TTC', ligne_facture.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', 
            GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR' FROM ligne_facture WHERE NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE ORDER BY LIBELLE_FACTURE ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        Dim adapter As New MySqlDataAdapter

        Dim table As New DataTable()

        adapter.SelectCommand = command

        adapter.Fill(table)

        'LIGNE DE COMPTOIR

        If Not table.Rows.Count > 0 Then

            'SI ON TRAITE UNE LIGNE DE COMPTOIR VERS EN CHAMBRE
            Dim getUserQuery01 = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                getUserQuery01 = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',
                PRIX_UNITAIRE_TTC As 'UNIT PRICE', ligne_facture.QUANTITE as QUANTITY, MONTANT_HT AS 'MONTANT ET', MONTANT_TTC AS 'AMOUNT IT',
                GRIFFE_UTILISATEUR AS 'USER' FROM ligne_facture WHERE NUMERO_SERIE_FIN = @NUMERO_BLOC_NOTE ORDER BY LIBELLE_FACTURE ASC"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                getUserQuery01 = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',
                PRIX_UNITAIRE_TTC As 'PU TTC', ligne_facture.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR' 
                FROM ligne_facture WHERE NUMERO_SERIE_FIN = @NUMERO_BLOC_NOTE ORDER BY LIBELLE_FACTURE ASC"

            End If

            Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

            command01.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
            Dim adapter01 As New MySqlDataAdapter

            adapter01.SelectCommand = command01

            adapter01.Fill(table)

        End If

        '-----------------------------------------------------------
        GunaDataGridViewLigneFacture.Columns.Clear()

        If table.Rows.Count > 0 Then

            GunaDataGridViewLigneFacture.DataSource = table

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewLigneFacture.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("QUANTITY").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("AMOUNT ET").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("AMOUNT ET").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("AMOUNT IT").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("AMOUNT IT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            End If

            GunaDataGridViewLigneFacture.Columns("ARTICLE").Visible = False
            GunaDataGridViewLigneFacture.Columns("ID_LIGNE_FACTURE").Visible = False
            GunaDataGridViewLigneFacture.Columns("TYPE_LIGNE_FACTURE").Visible = False

        Else
            'GunaDataGridViewLigneFacture.Columns.Clear()
        End If

    End Sub
    '4- OUTPUT LIGNE FACTURE TEMP

    Public Sub OutPutLigneFacture()

        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

        Dim query As String = ""

        'POUR LES EVENEMENTS SUIVANTS CODE_DE_RESERVATION
        'POUR LES AUTRES SUIVANTS EN CHAMBRE ET COMPTOIR CODE_FACTURE

        If GlobalVariable.actualLanguageValue = 0 Then

            If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',PRIX_UNITAIRE_TTC As 'UNIT PRICE', 
                ligne_facture_temp.QUANTITE AS QUANTITY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', GRIFFE_UTILISATEUR AS 'USER' 
                , CODE_LOT FROM ligne_facture_temp WHERE CODE_RESERVATION =@CODE_RESERVATION AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' ORDER BY ID_LIGNE_FACTURE DESC"
            Else
                query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',PRIX_UNITAIRE_TTC As 'UNIT PRICE', 
                ligne_facture_temp.QUANTITE AS QUANTITY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', GRIFFE_UTILISATEUR AS 'USER' 
                , CODE_LOT FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"
            End If

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC',
                ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR'
                , CODE_LOT FROM ligne_facture_temp WHERE CODE_RESERVATION =@CODE_RESERVATION AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' ORDER BY ID_LIGNE_FACTURE DESC"
            Else
                query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC',
                ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR' 
                , CODE_LOT FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"
            End If

        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)

        If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GunaTextBoxNumReservation.Text
        Else
            command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = GunaTextBoxNumfacture.Text
        End If

        Dim table As New DataTable()

        adapter.Fill(table)

        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
            GunaDataGridViewLigneFacture.Columns.Clear()
        End If

        If table.Rows.Count > 0 Then

            GunaDataGridViewLigneFacture.DataSource = table

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewLigneFacture.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("QUANTITY").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("AMOUNT ET").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("AMOUNT ET").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("AMOUNT ET").Visible = False
                GunaDataGridViewLigneFacture.Columns("AMOUNT IT").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("AMOUNT IT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("MONTANT HT").Visible = False
                GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            End If

            GunaDataGridViewLigneFacture.Columns("ARTICLE").Visible = False
            GunaDataGridViewLigneFacture.Columns("ID_LIGNE_FACTURE").Visible = False
            GunaDataGridViewLigneFacture.Columns("TYPE_LIGNE_FACTURE").Visible = False
            GunaDataGridViewLigneFacture.Columns("CODE_LOT").Visible = False

        Else

            If True Then

                Dim query_ As String = ""

                If GlobalVariable.actualLanguageValue = 0 Then

                    If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                        query_ = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',PRIX_UNITAIRE_TTC As 'UNIT PRICE', 
                ligne_facture_temp.QUANTITE AS QUANTITY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', GRIFFE_UTILISATEUR AS 'USER' 
                , CODE_LOT FROM ligne_facture_temp WHERE CODE_RESERVATION =@CODE_RESERVATION AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' ORDER BY ID_LIGNE_FACTURE DESC"
                    Else
                        query_ = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',PRIX_UNITAIRE_TTC As 'UNIT PRICE', 
                ligne_facture_temp.QUANTITE AS QUANTITY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', GRIFFE_UTILISATEUR AS 'USER', CODE_FACTURE 
                , CODE_LOT FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE ORDER BY ID_LIGNE_FACTURE DESC"
                    End If

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                        query_ = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC',
                ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR'
                , CODE_LOT FROM ligne_facture_temp WHERE CODE_RESERVATION =@CODE_RESERVATION AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' ORDER BY ID_LIGNE_FACTURE DESC"
                    Else
                        query_ = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC',
                ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR', CODE_FACTURE 
                , CODE_LOT FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_BLOC_NOTE =@NUMERO_BLOC_NOTE ORDER BY ID_LIGNE_FACTURE DESC"
                    End If

                End If

                Dim NUMERO_BLOC_NOTE As String = ""

                If GunaComboBoxListeDesComandes.DataSource IsNot Nothing Then
                    If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                        NUMERO_BLOC_NOTE = Trim(GunaComboBoxListeDesComandes.SelectedValue.ToString)
                    End If
                End If

                Dim command_ As New MySqlCommand(query_, GlobalVariable.connect)

                Dim adapter_ As New MySqlDataAdapter(command_)

                If GlobalVariable.typeDeClientAFacturer = "evenement" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                    command_.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GunaTextBoxNumReservation.Text
                Else
                    command_.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
                End If

                Dim table_ As New DataTable()

                adapter_.Fill(table_)

                If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                    GunaDataGridViewLigneFacture.Columns.Clear()
                End If

                If table_.Rows.Count > 0 Then

                    GunaDataGridViewLigneFacture.DataSource = table_
                    Dim CODE_FACTURE As String = table_.Rows(0)("CODE_FACTURE")
                    GunaTextBoxNumfacture.Text = CODE_FACTURE
                    Functions.updateOfFields("ligne_facture_bloc_note", "CODE_FACTURE", CODE_FACTURE, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 2)

                    If GlobalVariable.actualLanguageValue = 0 Then

                        GunaDataGridViewLigneFacture.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneFacture.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        GunaDataGridViewLigneFacture.Columns("QUANTITY").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneFacture.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        GunaDataGridViewLigneFacture.Columns("AMOUNT ET").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneFacture.Columns("AMOUNT ET").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        GunaDataGridViewLigneFacture.Columns("AMOUNT ET").Visible = False
                        GunaDataGridViewLigneFacture.Columns("AMOUNT IT").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneFacture.Columns("AMOUNT IT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    ElseIf GlobalVariable.actualLanguageValue = 1 Then

                        GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        GunaDataGridViewLigneFacture.Columns("MONTANT HT").Visible = False
                        GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Format = "#,##0.00"
                        GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    End If

                    GunaDataGridViewLigneFacture.Columns("ARTICLE").Visible = False
                    GunaDataGridViewLigneFacture.Columns("ID_LIGNE_FACTURE").Visible = False
                    GunaDataGridViewLigneFacture.Columns("TYPE_LIGNE_FACTURE").Visible = False
                    GunaDataGridViewLigneFacture.Columns("CODE_LOT").Visible = False
                    GunaDataGridViewLigneFacture.Columns("CODE_FACTURE").Visible = False

                    DisplaySavingButton()
                    FacturationKeyInformation()

                Else
                    'GunaDataGridViewLigneFacture.DataSource = Nothing
                End If

            Else

            End If

        End If

    End Sub

    '5- SITUATION DE CAISSE
    Public Sub SituationDeCaisseJournaliere()

        Dim situationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

        Dim TotalReglement As Double = 0

        If situationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To situationDeCaisse.Rows.Count - 1
                TotalReglement += situationDeCaisse.Rows(i)("MONTANT_VERSE")
            Next

            LabelSituationCaisse.Text = Format(TotalReglement, "#,##0")

        Else
            LabelSituationCaisse.Text = 0
        End If

    End Sub


    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonGesBloc.Click

        GunaDataGridViewBlocNote.Columns.Clear()
        GunaDataGridViewFolio3.Columns.Clear()
        GunaDataGridViewReglmentBlocNOtes.Columns.Clear()

        GlobalVariable.billetageAPartirDe = "bar"
        If GlobalVariable.actualLanguageValue = 0 Then
            GunaLabelHeader.Text = "RECEIPT MANAGEMENT"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelHeader.Text = "GESTION DES BLOCS NOTES"
        End If

        TabControlBarRestaurant.SelectedIndex = 1
    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonAppro.Click

        autoLoadMagasinActuel()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaLabelHeader.Text = "STORE REQUISITION"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelHeader.Text = "DEMANDE D'APPROVISIONNEMENT"
        End If

        TabControlBarRestaurant.SelectedIndex = 2

        NewRequisition()

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

        afficherCommande()

    End Sub

    Private Sub afficherCommande()
        Dim econom As New Economat
        '3- ON RECHARGE LE CONTENU DU bordero_ligne_temp dans le datagrid
        GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)

        GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False
        GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False
    End Sub

    Private Sub GunaAdvenceButtonRapportBar_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonRapportBar.Click
        If GlobalVariable.actualLanguageValue = 0 Then
            GunaLabelHeader.Text = "REPORTS"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelHeader.Text = "RAPPORTS"
        End If

        TabControlBarRestaurant.SelectedIndex = 3
    End Sub

    Private Sub GunaAdvenceButtonEvent_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonEvent.Click

        Dim continuer As Boolean = True

        If GunaLabelHeader.Text.Equals("EVENTS") Then
            continuer = False
        End If

        If GunaLabelHeader.Text.Equals("EVENEMENTIEL") Then
            continuer = False
        End If

        If continuer Then


            '--------------------------------------------------

            Me.Cursor = Cursors.WaitCursor

            GunaComboBoxFiltreBlocNotre.Visible = False

            ClearFacturationKeyInformation()

            clearArticleFields()

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaLabelHeader.Text = "EVENTS"
                GunaButtonSaveFacturation.Text = "Save"
                LibelleFacturation.Text = GlobalVariable.ArticleFamily & " BILLING"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaLabelHeader.Text = "EVENEMENTIEL"
                GunaButtonSaveFacturation.Text = "Enregistrer"
                LibelleFacturation.Text = "FACTURATION " & GlobalVariable.ArticleFamily

            End If

            GunaPanelEventsSup.Visible = True
            'GunaPanelEventsSup.BringToFront()

            GunaPanelEnChambre.Visible = False

            GunaPanelClientComptoirSup.Visible = False
            GunaPanelComptoirBloc.Visible = False

            GunaTextBoxNom_Prenom.Enabled = True

            GunaTextBoxCodeClient.Visible = False

            GunaTextBoxCodeClient.Clear()

            LabelBlocNoteOuvert.Visible = True

            GunaDataGridViewLigneFacture.Columns.Clear()

            GlobalVariable.typeDeClientAFacturer = "evenement"

            GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("facture", "")

            ListeDesSalles()

            GunaComboBoxListeDesResaEvents.SelectedIndex = -1

            DisplaySavingButton()

            TabControlBarRestaurant.SelectedIndex = 0

            Me.Cursor = Cursors.Default

            '--------------------------------------------------
        End If

    End Sub

    Public Sub ListeDesSalles()

        'On affiche toutes les reserv_conf dont la date saisie est entre la d'entrée et la date de sortie (inclusif)

        Dim DateDebut As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            GunaComboBoxListeDesResaEvents.DataSource = table
            GunaComboBoxListeDesResaEvents.DisplayMember = "CHAMBRE"
            GunaComboBoxListeDesResaEvents.ValueMember = "RESERVATION"

            If GunaComboBoxListeDesResaEvents.SelectedIndex >= 0 Then
                GunaComboBoxListeDesResaEvents.SelectedIndex = 0
            End If

        End If

    End Sub

    Dim page As Integer = 1

    Private Sub ReceptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceptionToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        'MainWindow.GunaDataGridViewResaDashBoard.Columns.Clear()

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()

        MainWindow.ReinitialisationDesDates()

        MainWindow.elementsDesChambres()
        MainWindow.contenuStatistique()
        MainWindow.StatistiquesDesChambres()

        MainWindow.GunaShadowPanelReservation.Hide()
        MainWindow.PanelEnregistrement.Hide()

        MainWindow.PanelTableauDeBords.Show()
        MainWindow.GunaShadowPanelReception.Show()

        MainWindow.Show()

        Me.Close()

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

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SERVICEDETAGEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SERVICEDETAGEToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        GlobalVariable.typeChambreOuSalle = "chambre"

        MainWindowServiceEtageForm.Visible = True

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCusine.Click
        Me.Cursor = Cursors.WaitCursor

        MainWindowCuisineForm.Show()
        ArticleForm.Show()

        ArticleForm.Location = New Point(90, 110)
        ArticleForm.TopMost = True
        Me.Close()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ComptabilitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComptabilitéToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        MainWindowComptabiliteForm.Visible = True

        Me.Close()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ECONOMATToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ECONOMATToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        MainWindowEconomat.Show()

        Me.Close()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TECHNIQUEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TECHNIQUEToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        MainWindowTechnique.Show()

        Me.Close()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ToolStripMenuItem117_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem117.Click

        GlobalVariable.changerMotDePasseDepuis = "bar"

        ChangePasswordForm.Show()
        ChangePasswordForm.TopMost = True

    End Sub

    Public Function existenceDeBlocNoteOuvert() As Integer

        Dim caisseGest As New Caisse()

        Dim NUMERO_BLOC_NOTE As String = ""

        'On selectionne l'ensemble des reglements du client payés ou pas lié à la réservation
        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim blocNoteDuCaissierActuel As DataTable = caisseGest.BlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        Dim nombreDeBlocNoteNonCloturer As Integer = 0

        For i = 0 To blocNoteDuCaissierActuel.Rows.Count - 1

            If GlobalVariable.actualLanguageValue = 0 Then
                If blocNoteDuCaissierActuel.Rows(i)("ETAT_BLOC_NOTE") = 0 Then
                    nombreDeBlocNoteNonCloturer += 1
                End If
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                If blocNoteDuCaissierActuel.Rows(i)("ETAT_BLOC_NOTE") = 0 Then
                    nombreDeBlocNoteNonCloturer += 1
                End If
            End If

        Next

        Return nombreDeBlocNoteNonCloturer

    End Function

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub FermerCaisseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerCaisseToolStripMenuItem.Click

        Dim args As ArgumentType = New ArgumentType()
        Dim dtParentCategory As DataTable

        GlobalVariable.billetageAPartirDe = "bar"

        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim caissier As New Caisse()
        Dim nombreDeBlocNoteNonCloturer As Integer = existenceDeBlocNoteOuvert()

        Dim envoiDeRapport As Boolean = False

        '1- ON SE RASSURE QUE TOUS LES BLOCS NOTES SONT CLOTURES

        Dim messageDePasDeVente As String = ""

        If nombreDeBlocNoteNonCloturer = 0 Then

            '2- ON SE RASSURE QUE lA CAISSE EST EQUILIBREE EN COMPARANT LES VENTES COMPTOIRS ET ENCAISSEMENTS

            Dim especes As Double = Functions.SituationDeCaisseEspeces(GlobalVariable.DateDeTravail, CODE_CAISSIER)

            Dim CODE_CAISSE As String = ""
            Dim CODE_UTILISATEUR As String = ""
            Dim CAISSE_UTILISATEUR As DataTable
            Dim ETAT_CAISSE As Integer = 0

            Dim TotalDesVentes As Double = 0
            Dim TotalEncaisse As Double = 0

            Double.TryParse(LabelTotalVenteComptoire.Text, TotalDesVentes)
            Double.TryParse(LabelSituationCaisse.Text, TotalEncaisse)

            'LE CONTROL NE DOIT ETRE FAIT QUE POUR LES PERSONNES DU BAR-RESTAURANT

            GlobalVariable.fenetreDouvervetureDeCaisse = "bar"

            If TotalEncaisse = TotalDesVentes Then

                '3- ON DETERMINE SI ON A EFFECTUE DES ENCAISSEMENTS EN ESPECES

                CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                CAISSE_UTILISATEUR = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                If especes = 0 Then

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "No sales to be transfered"
                        languageTitle = "Cash Transfer"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Aucune recette à transférer"
                        languageTitle = "Transfert de Caisse"
                    End If

                    messageDePasDeVente = languageMessage

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                        CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

                        FermerCaisseToolStripMenuItem.Visible = False

                        OuvrirCaisseToolStripMenuItem.Visible = True

                    End If

                    caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                    'A- MISE A JOUR DES ENCAISSEMENTS

                    'MISE AJOURS DE ETAT (REGLEMENT) : POUR NE PLUS PRENDRE EN COMPTE LES REGLEMENTS APRES CLOTURE

                    Dim encaissementDuCaissierActuel As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

                    Dim ETAT As Integer = 1
                    Dim NUM_REGLEMENT As String = ""
                    Dim reglement As New Reglement()

                    If encaissementDuCaissierActuel.Rows.Count > 0 Then

                        For i = 0 To encaissementDuCaissierActuel.Rows.Count - 1
                            NUM_REGLEMENT = encaissementDuCaissierActuel.Rows(i)("NUM_REGLEMENT")
                            reglement.UpdateEtatReglementPourClientComptoire(NUM_REGLEMENT, ETAT)
                        Next

                    End If

                    '------------------------------------------------------------------------------------------------------------------------------

                    'B- MISE A JOUR DES BLOCS NOTES

                    'MISE AJOURS DE ETAT_FACTURE (LIGNE_BLOC_NOTE) : POUR NE PLUS PRENDRE LES LIGNES DE BLOC NOTES APRES CLOTURE

                    Dim ligneFacture As New LigneFacture()
                    Dim caisseGest As New Caisse()

                    Dim NUMERO_BLOC_NOTE As String = ""

                    Dim ETAT_ = 1  ' BLOC NOTE PLUS PRIS EN COMPTE DANS LES VENTES DU JOURS
                    Dim ETAT_BLOC_NOTE As Integer = 2

                    Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

                    Dim blocNoteDuCaissierActuel As DataTable = caisseGest.BlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

                    If blocNoteDuCaissierActuel.Rows.Count > 0 Then

                        For i = 0 To blocNoteDuCaissierActuel.Rows.Count - 1

                            If GlobalVariable.actualLanguageValue = 0 Then
                                NUMERO_BLOC_NOTE = blocNoteDuCaissierActuel.Rows(i)("NUMERO_BLOC_NOTE")
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                NUMERO_BLOC_NOTE = blocNoteDuCaissierActuel.Rows(i)("NUMERO_BLOC_NOTE")
                            End If

                            ligneFacture.UpdateEtatLigneFacturePourClientComptoireApreCloture(NUMERO_BLOC_NOTE, ETAT_) 'ligne_facture_bloc_note

                        Next

                    End If

                    'C- MISE A JOURS DES LIGNES FACTURES 

                    Dim ligne_facture As New LigneFacture()

                    Dim UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                    ligne_facture.UpdateEtatLigneFactureLorsDeAucuneRecette(UTILISATEUR, ETAT, DateDeSituation)

                    ligne_facture.UpdateEtatLigneFactureGratuite(UTILISATEUR, ETAT, DateDeSituation)

                    'ON DOIT CLOTURER AUSSI LES VENTES DES EN CHAMBRES EN PLUS DES CLIENTS COMPTOIRS

                    '------------------------------------------------------------------------------------------------------------------------------

                    GlobalVariable.transfertDeCaisseVersCaissiere = False 'PERMET DE CONTROLLER QUE VENDEUR EST D'ACCORDS AVEC LES MONTANTS RENSEIGNEES

                    indicateurDEtatDeCaisse()

                    'ON SE RASSURE QUE TOUS LES ETAT_FACTURE QUI SONT PASSE A ZERO 1 ET N'ETANT PAS ASSOCIE A NUMERO DE FACTURE REPASSE A ZERO
                    CloturerForm.miseAjoursDesLignesDeChargeDeHebergementPasAssocieAUneFacture(GlobalVariable.DateDeTravail)

                    '-----------------------------------------------

                    'CHARGEMENT DU FICHIER DE VENTILATION DU SHIFT APRES CLOTURE DE CAISSE

                    '-----------------------------------------------

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Successfully closed"
                        languageTitle = "Cash Management"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Caisse fermée avec succès !"
                        languageTitle = "Gestion de caisse"
                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    envoiDeRapport = True

                    Dim caisse As New Caisse()

                    If True Then

                        Dim EN_CHAMBRE As Double = LabelTotalVenteEnChambre.Text
                        Dim COMPTOIR As Double = LabelTotalVenteComptoire.Text
                        Dim COMPTE As Double = LabelVenteVersCompte.Text
                        Dim GRATUITEE As Double = LabelVenteOfferte.Text
                        Dim GRATUITE_EN_CHAMBRE As Double = LabelOffresEnChambre.Text
                        Dim EN_SALLE As Double = LabelVenteEvent.Text
                        Dim TOTAL_VENTE As Double = GunaTextBoxTotalDesVentesJournaliere.Text
                        Dim DATE_VENTE As Date = GlobalVariable.DateDeTravail
                        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                        If CAISSE_UTILISATEUR.Rows.Count > 0 Then
                            CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")
                        End If

                        caisse.resume_vente_journaliere(EN_CHAMBRE, COMPTOIR, COMPTE, GRATUITEE, GRATUITE_EN_CHAMBRE, EN_SALLE, TOTAL_VENTE, DATE_VENTE, CODE_UTILISATEUR, CODE_AGENCE, CODE_CAISSE)

                        GunaTextBoxTotalDesVentesJournaliere.Text = 0
                        LabelSituationCaisse.Text = 0
                        LabelTotalVenteComptoire.Text = 0
                        LabelTotalVenteEnChambre.Text = 0
                        LabelVenteOfferte.Text = 0
                        LabelVenteVersCompte.Text = 0
                        LabelOffresEnChambre.Text = 0
                        LabelVenteEvent.Text = 0

                        BackgroundWorker1.RunWorkerAsync()

                        'GESTION DES SHIFTS

                        Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                        Dim SHIFT_VALUE As Integer = GlobalVariable.shiftActuel
                        Dim DEBUT_FIN As Integer = 1 'METTRE A JOUR LE STOCK DE FIN

                        Functions.inventaireJournalierTextFile(CODE_MAGASIN, SHIFT_VALUE, DEBUT_FIN)

                        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
                        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

                        GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT"
                        'Dim ligneFacture_ As New LigneFacture()
                        Dim CODE_CAISSIER_ As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        dtParentCategory = ligneFacture.ListeDesCategoriesDArticleVendus(DateDebut, DateFin, CODE_CAISSIER_)

                        args.action = 0 'JOURNAL DES VENTES DU SHIFT
                        args.dt = dtParentCategory
                        args.DateDebut = DateDebut
                        args.DateFin = DateFin

                        If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                            If dtParentCategory.Rows.Count > 0 Then
                                backGroundWorkerToCall(args)
                            End If

                        End If

                    End If

                Else

                    BilletageForm.Close()
                    BilletageForm.Show()
                    BilletageForm.TopMost = True

                End If

            Else

                Dim dialog As DialogResult

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Your balance is negative we have to equilibrate in order to close the shift !!"
                    languageTitle = "Debtor fund"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Le solde de la caisse est débiteur elle sera équilibrée à fin de permettre sa clôture !!"
                    languageTitle = "Caisse Débiteur"
                End If

                dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If dialog = DialogResult.No Then
                    'e.Cancel = True
                Else
                    ComparaisonVenteReglement.Close()
                    ComparaisonVenteReglement.Show()
                    ComparaisonVenteReglement.TopMost = True
                End If

                GlobalVariable.transfertDeCaisseVersCaissiere = False

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Please close all the receipts !!"
                languageTitle = "Receipt Management"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Bien vouloir clôturer tous les blocs notes ouverts !!"
                languageTitle = "Gestion des blocs notes"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Public Sub GestionOuvertureDeCaisse()

        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

        Dim CODE_CAISSE As String = ""

        Dim message As String = ""

        'Droit d'acces a la caisse 
        If Integer.Parse(GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE")) = 1 Then

            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

                OuvrirCaisseToolStripMenuItem.Visible = False

                FermerCaisseToolStripMenuItem.Visible = True

                Dim ETAT_CAISSE As Integer = 1
                Dim caissier As New Caisse()

                caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                If GlobalVariable.actualLanguageValue = 0 Then
                    message = "Successfully opened"
                    languageTitle = "Funds Management"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    message = "Caisse ouverte avec succès"
                    languageTitle = "Gestion de caisse"
                End If
                '-----------------------------------------------

                'CHARGEMENT DU FICHIER DE VENTILATION DU SHIFT AVANT CLOTURE DE CAISSE


                '-----------------------------------------------

            Else
                If GlobalVariable.actualLanguageValue = 0 Then
                    message = "You don't manage cash"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    message = "Vous n'avez pas de caisse"
                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                message = "You don't have the right to own a box"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                message = "Vous n'avez pas droit à la caisse"
            End If

        End If

        If GlobalVariable.actualLanguageValue = 0 Then
            languageTitle = "Funds Management"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageTitle = "Gestion de caisse"
        End If

        MessageBox.Show(message, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub OuvrirCaisseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirCaisseToolStripMenuItem.Click

        Dim gestionStock As Integer = GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK")
        Dim continuer As Boolean = True 'PAR DEFAUT POURSUIVRE POUR GERER LE CAS DE NON ACTIVATION DE LA GESTION DES STOCK

        'ON NE DOIT PAS POUVOUR OUVRIR SA CAISSE SI LA GESTION DES STOCKS EST ACTIVE
        'ET QUE L'ON A PAS ENCORE CHOISI SON MAGASIN ET CHOISI UN SHIFT

        If gestionStock = 1 Then

            continuer = False

            'LE SEUL MOYEN D'OUVRIR LA CAISSE C'EST DE CHOISIR UN MAGASIN

            If GlobalVariable.magasinActuel.Equals("") Then
                Functions.magasinActuelEtShiftDunUtilisateur()
            Else
                continuer = True
            End If

        End If

        If continuer Then

            GlobalVariable.fenetreDouvervetureDeCaisse = "bar"

            '1- VERIFICATION DE DROIT DE CAISSE
            If Integer.Parse(GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE")) = 1 Then

                '2- VERIFICATION DE CAISSE

                Dim possedeUneCaisse As Boolean = False

                Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                possedeUneCaisse = Functions.detentionDeCaisse(CODE_UTILISATEUR)

                If possedeUneCaisse Then

                    passwordVerifivationForm.Show()
                    passwordVerifivationForm.TopMost = True

                    indicateurDEtatDeCaisse()

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

        End If

    End Sub

    Private Sub ToolStripMenuItem119_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem119.Click

        Dim dialog As DialogResult

        Dim Action As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "Do you really wan to close"
            languageTitle = "Close BarclesHSoft"
            Action = "DECONNECTION OF " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Voulez-vous vraiment fermer"
            languageTitle = "Fermer BarclesHSoft"
            Action = "DECONNEXION DE " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")
        End If

        dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

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

            User.mouchard(Action)

            HomeForm.Close()

            AccueilForm.Close()

            AccueilForm.Show()

            Me.Close()

        End If

    End Sub

    Private Sub GunaAdvenceButtonPetiteCaisse_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonPetiteCaisse.Click

        Me.Cursor = Cursors.WaitCursor

        'GESTION DES PETITES CAISSES

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("PETITE_CAISSE") = 1 Then

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim detenteurDePetiteCaisse As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "utilisateur_caisse", "CODE_UTILISATEUR")

            If detenteurDePetiteCaisse.Rows.Count > 0 Then

                Dim CODE_CAISSE As String = detenteurDePetiteCaisse.Rows(0)("CODE_CAISSE")

                Dim infoPetiteCaissse As DataTable = Functions.getElementByCode(CODE_CAISSE, "petite_caisse", "CODE_CAISSE")

                If infoPetiteCaissse.Rows.Count > 0 Then

                    PetiteCaisseForm.Close()
                    PetiteCaisseForm.Show()
                    PetiteCaisseForm.TopMost = True

                    PetiteCaisseForm.GunaLabelGestCompteGeneraux.Text = infoPetiteCaissse.Rows(0)("LIBELLE_CAISSE") & " " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR").ToString.ToUpper
                    PetiteCaisseForm.GunaTextBoxCodePetiteCaisse.Text = infoPetiteCaissse.Rows(0)("CODE_CAISSE")
                    PetiteCaisseForm.GunaTextBoxPLafonds.Text = Format(infoPetiteCaissse.Rows(0)("MONTANT_PLAFONDS"), "#,##0")
                    PetiteCaisseForm.GunaLabelIndexTitreMouvement.Visible = True

                Else

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Petty cash Float does not exist"
                        languageTitle = "Petty Cash Float Management"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Pas d'existence de Petite Caissse !!"
                        languageTitle = "Gestion Petite Caisse"
                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "No Petty cash Float assigned to you"
                    languageTitle = "Petty Float Flow Management"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Aucune petite caisse ne vous a été attribuée !!"
                    languageTitle = "Gestion Petite Caisse"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "You don't have the right to own a Petty cash Flow"
                languageTitle = "Petty Cash Flow Management"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Vous n'avez pas droit à la petite caissse !"
                languageTitle = "Gestion Petite Caisse"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PETITEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PETITEToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        'GESTION DES PETITES CAISSES

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("PETITE_CAISSE") = 1 Then

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim detenteurDePetiteCaisse As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "utilisateur_caisse", "CODE_UTILISATEUR")

            If detenteurDePetiteCaisse.Rows.Count > 0 Then

                Dim CODE_CAISSE As String = detenteurDePetiteCaisse.Rows(0)("CODE_CAISSE")

                Dim infoPetiteCaissse As DataTable = Functions.getElementByCode(CODE_CAISSE, "petite_caisse", "CODE_CAISSE")

                If infoPetiteCaissse.Rows.Count > 0 Then
                    PetiteCaisseForm.Show()
                    PetiteCaisseForm.TopMost = True
                    PetiteCaisseForm.GunaLabelGestCompteGeneraux.Text = infoPetiteCaissse.Rows(0)("LIBELLE_CAISSE")
                    PetiteCaisseForm.GunaTextBoxCodePetiteCaisse.Text = infoPetiteCaissse.Rows(0)("CODE_CAISSE")
                    PetiteCaisseForm.GunaLabelIndexTitreMouvement.Visible = True
                    PetiteCaisseForm.TopMost = True
                Else

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Petty cash Float does not exist"
                        languageTitle = "Petty Cash Float Management"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Pas d'existence de Petite Caissse !!"
                        languageTitle = "Gestion Petite Caisse"
                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "No Petty cash Float assigned to you"
                    languageTitle = "Petty Cash Float Management"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Aucune petite caisse ne vous a été attribuée !!"
                    languageTitle = "Gestion Petite Caisse"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If
        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "You don't have the right to own a Petty cash Flow"
                languageTitle = "Petty Cash Flow Management"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Vous n'avez pas droit à la petite caissse !"
                languageTitle = "Gestion Petite Caisse"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaTextBoxCodeClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCodeClient.TextChanged

        Dim query As String = ""
        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim CLIENT_TYPE As String = ""

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            CLIENT_TYPE = "chambre"

            query = "SELECT CHAMBRE_ID, reserve_conf.NOM_CLIENT, CODE_RESERVATION FROM reserve_conf, client WHERE 
                reserve_conf.NOM_CLIENT LIKE '%" & Trim(GunaTextBoxCodeClient.Text) & "%' AND ETAT_RESERVATION = 1 AND DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE_CLIENT AND client.CODE_CLIENT = reserve_conf.CLIENT_ID
                OR client.CODE_ELITE LIKE '%" & Trim(GunaTextBoxCodeClient.Text) & "%' AND ETAT_RESERVATION = 1 AND DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE_CLIENT AND client.CODE_CLIENT = reserve_conf.CLIENT_ID
                OR CHAMBRE_ID LIKE '%" & Trim(GunaTextBoxCodeClient.Text) & "%' AND ETAT_RESERVATION = 1 AND DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE_CLIENT AND client.CODE_CLIENT = reserve_conf.CLIENT_ID
                ORDER BY reserve_conf.NOM_CLIENT ASC"

        ElseIf GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            If GlobalVariable.actualLanguageValue = 1 Then
                CLIENT_TYPE = "COMPTOIR"
            Else
                CLIENT_TYPE = "WALK IN"
            End If

            'query = "SELECT NOM_PRENOM, EMAIL FROM client WHERE NOM_PRENOM Like '%" & Trim(GunaTextBoxCodeClient.Text) & "%'  AND TYPE_CLIENT = @TYPE_CLIENT 
            'query = "SELECT NOM_PRENOM, EMAIL FROM client WHERE NOM_PRENOM Like '%" & Trim(GunaTextBoxCodeClient.Text) & "%'  AND TYPE_CLIENT = @TYPE_CLIENT OR CODE_ELITE Like '%" & Trim(GunaTextBoxCodeClient.Text) & "%' ORDER BY NOM_PRENOM ASC"
            query = "SELECT NOM_PRENOM, EMAIL FROM client WHERE NOM_PRENOM LIKE '%" & Trim(GunaTextBoxCodeClient.Text) & "%' AND TYPE_CLIENT = @TYPE_CLIENT ORDER BY NOM_PRENOM ASC"

        End If

        GunaDataGridViewClient.Visible = True

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = CLIENT_TYPE

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaDataGridViewClient.Visible = True
                GunaDataGridViewClient.DataSource = table

                If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                    If Not GunaDataGridViewClient Is Nothing Then
                        If GunaDataGridViewClient.Rows.Count > 0 Then
                            GunaDataGridViewClient.Columns("CODE_RESERVATION").Visible = False
                        End If
                    End If

                End If
            Else
                GunaDataGridViewClient.Columns.Clear()
                GunaDataGridViewClient.Visible = False
            End If

            If Trim(GunaTextBoxCodeClient.Text).Equals("") Then

                GunaTextBoxCodeClient.Clear()
                GunaTextBoxNom_Prenom.Clear()
                TB_RoomNo.Clear()
                GunaTextBoxNumReservation.Clear()

                GunaDataGridViewClient.Columns.Clear()
                GunaDataGridViewClient.Visible = False

                GunaComboBoxListeDesComandes.DataSource = Nothing

            End If

        Else
            GunaDataGridViewClient.Visible = False
        End If

    End Sub

    Private Sub listeDesPointDeVente()

        'On masque le chant du nom on load
        'GunaTextBoxNom_Prenom.Enabled = False

        'Loading other 'article families currently called article type into a combobox
        Dim tableFamille As DataTable = Functions.allTableFieldsOrganised("famille", "LIBELLE_FAMILLE")

        If (tableFamille.Rows.Count > 0) Then

            GunaComboBoxPointDeVente.DataSource = tableFamille
            'GunaComboBoxTypeArticle.ValueMember = "CODE_FAMILLE"
            GunaComboBoxPointDeVente.ValueMember = "LIBELLE_FAMILLE"
            GunaComboBoxPointDeVente.DisplayMember = "LIBELLE_FAMILLE"

        End If

    End Sub

    Private Sub GunaComboBoxPointDeVente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxPointDeVente.SelectedIndexChanged

        If GunaCheckBoxChangeSecteur.Checked Then

            If GlobalVariable.actualLanguageValue = 0 Then
                LibelleFacturation.Text = GunaComboBoxPointDeVente.SelectedValue.ToString & " BILLING "
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                LibelleFacturation.Text = "FACTURATION " & GunaComboBoxPointDeVente.SelectedValue.ToString
            End If

            GlobalVariable.ArticleFamily = GunaComboBoxPointDeVente.SelectedValue.ToString

        End If

    End Sub

    Dim discounStays As Boolean = False

    Private Sub GunaDataGridViewClient_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewClient.CellClick

        Dim gestionStock As Integer = GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK")
        Dim continuer As Boolean = True

        'ON NE DOIT PAS POUVOUR OUVRIR SA CAISSE SI LA GESTION DES STOCKS EST ACTIVE
        'ET QUE L'ON A PAS ENCORE CHOISI SON MAGASIN ET CHOISI UN SHIFT

        If gestionStock = 1 Then

            continuer = False

            'LE SEUL MOYEN D'OUVRIR LA CAISSE C'EST DE CHOISIR UN MAGASIN

            If GlobalVariable.magasinActuel.Equals("") Then
                Functions.magasinActuelEtShiftDunUtilisateur()
            Else
                continuer = True
            End If

        End If

        If continuer Then

            Me.Cursor = Cursors.WaitCursor

            GunaTextBoxNom_Prenom.Enabled = True

            If e.RowIndex >= 0 Then

                GunaTextBoxCodeClient.Visible = False

                Dim row As DataGridViewRow

                row = GunaDataGridViewClient.Rows(e.RowIndex)

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

                    If GunaDataGridViewClient.Columns.Count = 3 Then
                        CODE_RESERVATION = row.Cells(2).Value.ToString
                    End If

                    GunaTextBoxNom_Prenom.Enabled = False

                    GunaTextBoxCodeClient.Text = Client.Rows(0)("CODE_CLIENT")
                    GunaTextBoxNom_Prenom.Text = Client.Rows(0)("NOM_PRENOM")

                    'On recherche le numéro de réservation du client en chambre
                    If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then

                        GunaTextBoxNumReservation.Text = CODE_RESERVATION

                        GunaDataGridViewChambreReservation.Visible = False

                        Dim resa As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION", 1, "ETAT_RESERVATION")

                        If resa.Rows.Count > 0 Then

                            TB_RoomNo.Text = resa.Rows(0)("CHAMBRE_ID")

                            'Ont recuperes les mains courantes dont l'etat vaut zero donc non cloturer

                            GlobalVariable.codeReservationToUpdate = resa.Rows(0)("CODE_RESERVATION")

                            Dim mainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                            If mainCouranteJournaliere.Rows.Count > 0 Then
                                GlobalVariable.codeMainCouranteJournaliereToUpdate = mainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                                'GunaTextBoxMontantTTC.Text = GlobalVariable.codeMainCouranteJournaliereToUpdate
                            End If

                            GunaDataGridViewChambreReservation.Visible = False

                            Dim Caisse As New Caisse()

                            If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                                GunaComboBoxListeDesComandes.DataSource = Caisse.AutoLoadBlocNoteEnChambre(GlobalVariable.DateDeTravail.ToShortDateString, GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), 0, CODE_RESERVATION)
                                GunaComboBoxListeDesComandes.ValueMember = "NUMERO_BLOC_NOTE"
                                GunaComboBoxListeDesComandes.DisplayMember = "NUMERO_BLOC_NOTE"
                            End If
                            '-------------------- ON RECHERCHE SI IL EXISTE D'EVENTUELLE INFORMATION CONCERNANT CETTE RESA
                            'Refresh Datagrid To view newly inserted Articles
                            OutPutLigneFacture()

                            'We Refresh the general information concerning the Invoice
                            FacturationKeyInformation()

                            'Determining wether or not to save a facturation
                            DisplaySavingButton()

                            If GunaDataGridViewLigneFacture.Rows.Count > 0 Then
                                GunaButtonSaveFacturation.Visible = True
                            End If
                            '-----------------------------------------------------------------------------

                        End If

                        'On doit pouvoir remplacer le libellé des clients comptoir par un nom précis

                        If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                            GunaTextBoxNom_Prenom.Enabled = False
                            TB_RoomNo.Enabled = False

                            GunaTextBoxSoldeClient.Text = Format(Functions.SituationDeReservation(GunaTextBoxNumReservation.Text), "#,##0")

                        Else
                            GunaTextBoxNom_Prenom.Enabled = True
                            TB_RoomNo.Enabled = True
                        End If

                        GunaDataGridViewClient.Visible = False
                        GunaDataGridViewClient.Columns.Clear()

                        GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("facture", "")

                    Else

                        'We clear the article field if nothing is found when we click on the custom datagrid
                        clearArticleFields()

                    End If

                End If

            Else

            End If

            GunaTextBoxNom_Prenom.Enabled = True

            GunaDataGridViewClient.Visible = False

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                GunaTextBoxNom_Prenom.Enabled = False
            End If

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub GunaDataGridViewChambreReservation_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewChambreReservation.CellClick

        Me.Cursor = Cursors.WaitCursor

        Dim CODE_RESERVATION As String = ""

        If e.RowIndex >= 0 Then

            GunaTextBoxCodeClient.Visible = False

            GunaDataGridViewChambreReservation.Visible = False

            Dim row As DataGridViewRow

            row = GunaDataGridViewChambreReservation.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM client WHERE NOM_PRENOM=@NOM_PRENOM ORDER BY NOM_PRENOM ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Client As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = row.Cells("NOM_CLIENT").Value.ToString
            Else
                command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = row.Cells("NOM_PRENOM").Value.ToString
            End If

            adapter.SelectCommand = command

            adapter.Fill(Client)

            If (Client.Rows.Count > 0) Then

                GunaTextBoxNom_Prenom.Enabled = False

                GunaTextBoxCodeClient.Text = Client.Rows(0)("CODE_CLIENT")
                GunaTextBoxNom_Prenom.Text = Client.Rows(0)("NOM_PRENOM")

                'On recherche le numéro de réservation du client en chambre
                If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                    GunaTextBoxNumReservation.Text = row.Cells("CODE_RESERVATION").Value.ToString

                    CODE_RESERVATION = GunaTextBoxNumReservation.Text

                    GunaDataGridViewChambreReservation.Visible = False

                    Dim infoResa As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION", 1, "ETAT_RESERVATION")

                    If infoResa.Rows.Count > 0 Then

                        TB_RoomNo.Text = infoResa.Rows(0)("CHAMBRE_ID")
                        'GunaTextBoxSoldeClient.Text = Format(infoResa.Rows(0)("SOLDE_RESERVATION"), "#,##0")

                        GunaDataGridViewChambreReservation.Visible = False

                    End If

                End If

                GlobalVariable.codeReservationToUpdate = CODE_RESERVATION

                Dim mainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                If mainCouranteJournaliere.Rows.Count > 0 Then
                    GlobalVariable.codeMainCouranteJournaliereToUpdate = mainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                    'GunaTextBoxMontantTTC.Text = GlobalVariable.codeMainCouranteJournaliereToUpdate
                End If

                GunaDataGridViewClient.Visible = False
                GunaDataGridViewClient.Columns.Clear()

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid
                clearArticleFields()

            End If

            'Solde du client comptoir, en chambre ou paymaster
            If Not Trim(GunaTextBoxCodeClient.Text) = "" Then

                If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                    GunaTextBoxSoldeClient.Text = Format(Functions.SituationDeReservation(GunaTextBoxNumReservation.Text), "#,##0")
                End If

            End If

            Dim caisse As New Caisse()

            If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                GunaComboBoxListeDesComandes.DataSource = Caisse.AutoLoadBlocNoteEnChambre(GlobalVariable.DateDeTravail.ToShortDateString, GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), 0, CODE_RESERVATION)
                GunaComboBoxListeDesComandes.ValueMember = "NUMERO_BLOC_NOTE"
                GunaComboBoxListeDesComandes.DisplayMember = "NUMERO_BLOC_NOTE"
            End If

            OutPutLigneFacture()

            DisplaySavingButton()

            FacturationKeyInformation()

            If GunaDataGridViewLigneFacture.Rows.Count > 0 Then
                GunaButtonSaveFacturation.Visible = True
            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TB_RoomNo_TextChanged(sender As Object, e As EventArgs) Handles TB_RoomNo.TextChanged

        If Not Trim(TB_RoomNo.Text).Equals("") Then

            If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then

                Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

                Dim CLIENT_TYPE As String = ""

                If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                    CLIENT_TYPE = "chambre"
                ElseIf GlobalVariable.typeDeClientAFacturer = "evenement" Then
                    CLIENT_TYPE = "salle"

                End If

                Dim query As String = "SELECT CHAMBRE_ID, NOM_CLIENT, CODE_RESERVATION FROM reserve_conf WHERE CHAMBRE_ID LIKE '%" & Trim(TB_RoomNo.Text) & "%' AND ETAT_RESERVATION = @ETAT_RESERVATION AND DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)
                command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int16).Value = 1
                command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = CLIENT_TYPE

                Dim adapter As New MySqlDataAdapter(command)
                Dim reservation As New DataTable()

                adapter.Fill(reservation)

                If (reservation.Rows.Count > 0) Then

                    GunaDataGridViewChambreReservation.Visible = True

                    GunaDataGridViewChambreReservation.DataSource = reservation

                    If Not GunaDataGridViewChambreReservation Is Nothing Then
                        If GunaDataGridViewChambreReservation.Rows.Count > 0 Then
                            GunaDataGridViewChambreReservation.Columns("CODE_RESERVATION").Visible = False
                        End If
                    End If

                Else
                    GunaDataGridViewChambreReservation.Visible = False
                End If

            End If

        Else

            GunaDataGridViewChambreReservation.Visible = False
            GunaTextBoxNumReservation.Clear()
            GunaTextBoxNom_Prenom.Clear()
            GunaTextBoxCodeClient.Clear()
            clearArticleFields()

        End If

    End Sub

    Private Sub GunaCheckBoxChangeSecteur_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxChangeSecteur.CheckedChanged

        If GunaCheckBoxChangeSecteur.Checked Then

            listeDesPointDeVente()

            If GunaComboBoxPointDeVente.Items.Count > 0 Then
                GunaComboBoxPointDeVente.SelectedIndex = 1
            End If

            GunaComboBoxPointDeVente.Visible = True

        Else
            GunaComboBoxPointDeVente.Visible = False
        End If

    End Sub

    Private Sub GunaAdvenceButtonLectureDeCarte_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonLectureDeCarte.Click

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
        If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then

            If Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows.Count > 0 Then
                GunaTextBoxNumReservation.Text = Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("CODE_RESERVATION")
                GunaTextBoxCodeClient.Text = Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("CLIENT_ID")
            Else

            End If

        End If

    End Sub

    Private Sub GunaButtonNouveauBloc_Click(sender As Object, e As EventArgs) Handles GunaButtonNouveauBloc.Click

        Me.Cursor = Cursors.WaitCursor

        'ETAT_FACTURE = 0 : ESPECES, CHEQUE...
        'ETAT_FACTURE = 1 : EN CHAMBRE
        'ETAT_FACTURE = 2 : GRATUITEE
        'ETAT_FACTURE = 3 : VERS COMPTE

        'LE BLOC NOTE NE PEUT QUE ETRE ENREGISTRE SI IL EST ASSOCIE A UN NOM DE CLIENT

        If Trim(GunaTextBoxNom_Prenom.Text) = "" Then

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Impossible to create as no customer is associated to the receipt"
                languageTitle = "Command creation"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Impossible de créer car aucun client n'est associé au bloc note!!"
                languageTitle = "Création de commande"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            'Génération d'un nouveau numéro proforma associé au numéro de bloc_note

            GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")

            Dim LigneReservationTemp As New LigneFacture()

            'On insère une nouvelle ligne dans la ligne de facture temporaire ou des bloc note

            Dim MONTANT_BLOC_NOTE As Double = Double.Parse(GunaTextBoxMontantTTCGeneral.Text)

            Dim NUMERO_BLOC_NOTE_VERIF As String = Trim(GunaTextBoxBlocNote.Text) 'Permet de vérifier l'unicité des bloc notes
            Dim NUMERO_BLOC_NOTE As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR") & GlobalVariable.DateDeTravail.ToString("ddMM") & "-" & Trim(GunaTextBoxBlocNote.Text)

            Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail

            Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
            Dim CODE_CLIENT_FIDEL As String = GunaTextBoxRefClient.Text
            Dim CODE_ELITE As String = GunaTextBoxCodeElite.Text

            'NUMERO DE BLOC NOTE DEVANT ETRE UNIQUE
            Dim blocNoteExistant As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE_VERIF, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE_VERIF")

            If Not blocNoteExistant.Rows.Count > 0 Then

                'GunaTextBoxNumfacture.Text = GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCode("facture", "")

                If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                    GunaDataGridViewLigneFacture.Columns.Clear()

                    'Pour les en chambres impossible de traiter deux blocs simultanement
                    If GunaComboBoxListeDesComandes.Items.Count = 0 Then

                        LigneReservationTemp.InsertLigneBlocNoteCommande(NUMERO_BLOC_NOTE, GunaTextBoxNumfacture.Text, GunaTextBoxCodeClient.Text, DATE_CREATION, CODE_CAISSIER, NUMERO_BLOC_NOTE_VERIF)

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

                    LigneReservationTemp.InsertLigneBlocNoteCommande(NUMERO_BLOC_NOTE, GunaTextBoxNumfacture.Text, GunaTextBoxCodeClient.Text, DATE_CREATION, CODE_CAISSIER, NUMERO_BLOC_NOTE_VERIF, CODE_CLIENT_FIDEL, CODE_ELITE)

                    'On charge l'ensemble des bloc notes non réglés et clôturé
                    AutoLoadOfBlocNote()

                    If GunaComboBoxListeDesComandes.Items.Count > 0 Then
                        GunaComboBoxListeDesComandes.SelectedValue = NUMERO_BLOC_NOTE
                    End If

                    'A la création d'un nouveau bloc note 

                    If GlobalVariable.actualLanguageValue = 0 Then
                        GunaButtonSaveFacturation.Text = "Close"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        GunaButtonSaveFacturation.Text = "Clôturer"
                    End If

                End If

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

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaComboBoxListeDesComandes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxListeDesComandes.SelectedIndexChanged


        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            Me.Cursor = Cursors.WaitCursor

            'On efface les anciens elemts pour afficher de nouvelle
            'GunaDataGridViewLigneFacture.Columns.Clear()

            Dim blocNoteEnCours As DataTable

            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If blocNoteEnCours.Rows.Count > 0 Then

                    'GlobalVariable.blocNoteARegler = 

                    GunaTextBoxNumfacture.Text = blocNoteEnCours.Rows(0)("CODE_FACTURE")

                    Dim ClientDevantRegler As DataTable = Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT")

                    If ClientDevantRegler.Rows.Count > 0 Then
                        GunaTextBoxCodeClient.Text = ClientDevantRegler.Rows(0)("CODE_CLIENT") 'Code client
                        GunaTextBoxCodeClient.Visible = False
                        GunaTextBoxNom_Prenom.Text = ClientDevantRegler.Rows(0)("NOM_PRENOM") 'Nom du client

                        'CLIENT FIDELE

                        GunaTextBoxCodeElite.Text = blocNoteEnCours.Rows(0)("CODE_ELITE")
                        GunaTextBoxRefClient.Text = blocNoteEnCours.Rows(0)("CODE_CLIENT_FIDEL")
                        Dim CODE_CLIENT_FIDEL As String = blocNoteEnCours.Rows(0)("CODE_CLIENT_FIDEL")
                        Dim CODE_ELITE As String = blocNoteEnCours.Rows(0)("CODE_ELITE")

                        Dim ClientFidel As DataTable = Functions.getElementByCode(CODE_CLIENT_FIDEL, "client", "CODE_CLIENT")

                        If ClientFidel.Rows.Count > 0 Then
                            GunaTextBoxNomPrenom.Text = ClientFidel.Rows(0)("NOM_PRENOM") 'Nom du client Fidel
                            If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then
                                AffichageDesIinformationsDuCLientFidel(CODE_ELITE, CODE_CLIENT_FIDEL)
                            End If
                        Else
                            GunaTextBoxNomPrenom.Text = ""
                        End If

                    End If

                    'on verifie si le bon est associe aux clients fidels

                    Dim ListeDesArticlesDeCetteComandes As DataTable = Functions.GetAllElementsOnCondition(blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE"), "ligne_facture_temp", "NUMERO_BLOC_NOTE")

                    If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then

                        'QUAND LE BLOC NOTE SE TROUVE DANS LIGNE FACTURE TEMP

                        If GlobalVariable.actualLanguageValue = 0 Then

                            If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                                GunaButtonSaveFacturation.Text = "Close"
                            ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                                GunaButtonSaveFacturation.Text = "Pay"
                            End If

                        ElseIf GlobalVariable.actualLanguageValue = 1 Then

                            If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                                GunaButtonSaveFacturation.Text = "Clôturer"
                            ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                                GunaButtonSaveFacturation.Text = "Régler"
                            End If

                        End If
                        'klg
                        'Determining wether or not to save a facturation

                        OutPutLigneFacture()

                        DisplaySavingButton()

                        FacturationKeyInformation()

                    Else

                        'AU CAS OU LES FACTURES SE TROUVE DANS LIGNE_FACTURE

                        'On charge l'ensemble des articles en relation avec cette commande ou numero de bloc note

                        Dim NUMERO_BLOC_NOTE As String = blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE")

                        'ListeDesArticlesDeCetteComandes = Functions.GetAllElementsOnCondition(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")
                        ListeDesArticlesDeCetteComandes = Functions.GetAllElementsOnCondition(NUMERO_BLOC_NOTE, "ligne_facture", "NUMERO_BLOC_NOTE")

                        If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then

                            If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then
                                OutPutLigneFactureFermee(NUMERO_BLOC_NOTE)
                            End If

                            If GlobalVariable.actualLanguageValue = 0 Then

                                If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                                    GunaButtonSaveFacturation.Text = "Close"
                                ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                                    GunaButtonSaveFacturation.Text = "Pay"
                                End If

                            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                                If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                                    GunaButtonSaveFacturation.Text = "Clôturer"
                                ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                                    GunaButtonSaveFacturation.Text = "Régler"
                                End If

                            End If

                            'Determining wether or not to save a facturation
                            DisplaySavingButton()

                            FacturationKeyInformation()

                        Else
                            GunaButtonSaveFacturation.Visible = False
                        End If

                        OutPutLigneFacture()

                    End If

                    'OutPutLigneFacture()

                End If

            Else

                GunaButtonSaveFacturation.Visible = False

                If GlobalVariable.typeDeClientAFacturer = "en chmabre" Or GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                    'klg
                    'GunaComboBoxListeDesComandes.DataSource = Nothing
                End If

            End If

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Public Sub AutoLoadEventListeVisualisation()

        Dim caisse As New Caisse()

        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', CODE_EVENEMENT, SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', reserve_conf.CODE_RESERVATION AS 'RESERVATION', ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf, forfait_salle WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE AND reserve_conf.CODE_RESERVATION = forfait_salle.CODE_RESERVATION ORDER BY CHAMBRE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            GunaDataGridViewEventsResa.Columns.Clear()


            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewEventsResa.Columns.Add("RESERVATION", "RESERVATION")
                GunaDataGridViewEventsResa.Columns.Add("HOLE", "HOLE")
                GunaDataGridViewEventsResa.Columns.Add("CUSTOMER NAME", "CUSTOMER NAME")
                GunaDataGridViewEventsResa.Columns.Add("AMOUNT", "AMOUNT")

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewEventsResa.Columns.Add("RESERVATION", "RESERVATION")
                GunaDataGridViewEventsResa.Columns.Add("SALLE", "SALLE")
                GunaDataGridViewEventsResa.Columns.Add("NOM CLIENT", "NOM CLIENT")
                GunaDataGridViewEventsResa.Columns.Add("MONTANT", "MONTANT")

            End If

            For i = 0 To table.Rows.Count - 1

                Dim MONTANT As Double = 0
                Dim CODE_RESERVATION As String = table.Rows(i)("RESERVATION")
                Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                Dim CODE_EVENEMENT As String = table.Rows(i)("CODE_EVENEMENT")

                Dim ligne_facture_temp As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_RESERVATION, "ligne_facture_temp", "CODE_RESERVATION", CODE_UTILISATEUR_CREA, "CODE_UTILISATEUR_CREA")
                If ligne_facture_temp.Rows.Count > 0 Then

                    For j = 0 To ligne_facture_temp.Rows.Count - 1
                        MONTANT += Double.Parse(ligne_facture_temp.Rows(j)("MONTANT_HT"))
                    Next

                End If

                Dim infoEvent As DataTable = Functions.getElementByCode(CODE_EVENEMENT, "evenement", "CODE_EVENEMENT")

                Dim EVENEMENT As String = ""

                If infoEvent.Rows.Count > 0 Then
                    EVENEMENT = infoEvent.Rows(0)("LIBELLE")
                End If

                GunaDataGridViewEventsResa.Rows.Add(table.Rows(i)("RESERVATION"), table.Rows(i)("CHAMBRE"), EVENEMENT, MONTANT)

            Next

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewEventsResa.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0.00"

                GunaDataGridViewEventsResa.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewEventsResa.Columns("CUSTOMER NAME").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                GunaDataGridViewEventsResa.Columns("RESERVATION").Visible = False

            ElseIf GlobalVariable.actualLanguageValue = 0 Then


                GunaDataGridViewEventsResa.Columns("MONTANT").DefaultCellStyle.Format = "#,##0.00"

                GunaDataGridViewEventsResa.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewEventsResa.Columns("NOM CLIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                GunaDataGridViewEventsResa.Columns("RESERVATION").Visible = False

            End If

        End If

    End Sub
    Private Sub GunaComboBoxListeDesResaEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxListeDesResaEvents.SelectedIndexChanged

        'AFFICHAGE D'UN EVENEMENT EN RELATION AVEC LA RESERVATION
        If GlobalVariable.typeDeClientAFacturer = "evenement" Then

            Me.Cursor = Cursors.WaitCursor

            If GunaComboBoxListeDesResaEvents.SelectedIndex >= 0 Then

                GunaDataGridViewLigneFacture.Columns.Clear()

                GunaTextBoxNumReservation.Text = GunaComboBoxListeDesResaEvents.SelectedValue.ToString

                Dim CODE_RESERVATION As String = GunaTextBoxNumReservation.Text

                Dim evenement As DataTable = Functions.getElementByCode(CODE_RESERVATION, "forfait_salle", "CODE_RESERVATION")

                If evenement.Rows.Count > 0 Then
                    Dim CODE_EVENEMENT As String = evenement.Rows(0)("CODE_EVENEMENT")

                    Dim infoSupEvent As DataTable = Functions.getElementByCode(CODE_EVENEMENT, "evenement", "CODE_EVENEMENT")

                    If infoSupEvent.Rows.Count > 0 Then
                        GunaTextBoxEvents.Text = infoSupEvent.Rows(0)("LIBELLE")
                    Else
                        GunaTextBoxEvents.Text = ""
                    End If

                Else
                    GunaTextBoxEvents.Text = ""
                End If

                Dim resa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                If resa.Rows.Count > 0 Then

                    GunaTextBoxCodeClient.Text = resa.Rows(0)("CLIENT_ID")
                    GunaTextBoxNom_Prenom.Text = resa.Rows(0)("NOM_CLIENT")
                    GunaDataGridViewClient.Visible = False

                    'ON CHARGE LES INFORMATIONS EN RAPPORTS AVEC UNE RESA DE LA LISTE
                    OutPutLigneFacture()

                    DisplaySavingButton()

                    FacturationKeyInformation()

                End If

                If resa.Rows.Count > 0 Then

                    TB_RoomNo.Text = resa.Rows(0)("CHAMBRE_ID")

                    'Ont recuperes les mains courantes dont l'etat vaut zero donc non cloturer

                    GlobalVariable.codeReservationToUpdate = resa.Rows(0)("CODE_RESERVATION")

                    Dim mainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                    If mainCouranteJournaliere.Rows.Count > 0 Then
                        GlobalVariable.codeMainCouranteJournaliereToUpdate = mainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                        'GunaTextBoxMontantTTC.Text = GlobalVariable.codeMainCouranteJournaliereToUpdate
                    End If

                    GunaTextBoxSituationEvents.Text = Format(Functions.SituationDeReservation(GunaTextBoxNumReservation.Text), "#,##0")

                    GunaDataGridViewChambreReservation.Visible = False

                End If

            Else

                GunaTextBoxEvents.Clear()
                GunaTextBoxNom_Prenom.Clear()
                GunaTextBoxSituationEvents.Clear()

            End If

            TB_RoomNo.Visible = False
            LabelNumeroChambre.Visible = False

            AutoLoadEventListeVisualisation()

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub GunaDataGridViewEventsResa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewEventsResa.CellClick
        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = GunaDataGridViewEventsResa.Rows(e.RowIndex)

            GunaComboBoxListeDesResaEvents.SelectedValue = row.Cells(0).Value.ToString

        End If
    End Sub

    Private Sub GunaDataGridViewBlocNoteOuvert_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBlocNoteOuvert.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = GunaDataGridViewBlocNoteOuvert.Rows(e.RowIndex)

            GunaComboBoxListeDesComandes.SelectedValue = Trim(row.Cells(0).Value.ToString)

        End If

    End Sub

    Private Sub GunaButtonImprimer_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimer.Click

        Me.Cursor = Cursors.WaitCursor
        Dim BLOC_NOTE As String = ""
        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString
            End If
        End If

        Dim NUM_FACTURE As String = GunaTextBoxNumfacture.Text
        Impression.commandeImpression(GunaDataGridViewLigneFacture, GunaTextBoxNom_Prenom.Text, GunaTextBoxNumfacture.Text, TB_RoomNo.Text, BLOC_NOTE)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonnNouvelleFacture_Click(sender As Object, e As EventArgs) Handles GunaButtonnNouvelleFacture.Click

        Me.Cursor = Cursors.WaitCursor

        discounStays = False

        GunaTextBoxCodeElite.Clear()
        GunaTextBoxCodeClient.Visible = True

        emptyFacturationFormField()

        ClearFacturationKeyInformation()

        TB_RoomNo.Clear()

        DisplaySavingButton()

        GunaDataGridViewLigneFacture.Columns.Clear()

        GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")

        TB_RoomNo.Enabled = True

        Me.Cursor = Cursors.Default

    End Sub

    Public Sub emptyFacturationFormField()

        GlobalVariable.codeReservationToUpdate = ""
        GlobalVariable.codeMainCouranteJournaliereToUpdate = ""

        GunaTextBoxNumfacture.Text = ""
        GunaTextBoxNumReservation.Text = ""
        GunaTextBoxFacturationDate.Text = GlobalVariable.DateDeTravail

        'We disable the fields
        GunaTextBoxNumReservation.Enabled = False
        GunaTextBoxFacturationDate.Enabled = False
        GunaTextBoxNumfacture.Enabled = False

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
            GunaTextBoxCodeClient.Text = ""
            GunaTextBoxNom_Prenom.Text = ""
            'We disable the fields
            GunaTextBoxCodeClient.Enabled = True
            GunaTextBoxNom_Prenom.Enabled = True
        Else

            If Not GunaTextBoxNomPrenom.Text.Contains("WALK IN") Or Not GunaTextBoxNomPrenom.Text.Contains("COMPTOIR") Then
                GunaTextBoxNomPrenom.Clear()
                'We disable the fields
                GunaTextBoxCodeClient.Enabled = True
                GunaTextBoxNom_Prenom.Enabled = True
            End If

        End If



        'Clearing Article fields
        clearArticleFields()

    End Sub

    Private Sub GunaTextBoxArticle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxArticle.TextChanged

        If Not GunaCheckBoxLecteurRFID.Checked Then

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
                GlobalVariable.ArticleFamily = GunaComboBoxPointDeVente.SelectedValue.ToString
            End If


            'Determining from which table to search for the articles
            If GlobalVariable.ArticleFamily = "BAR" Or GlobalVariable.ArticleFamily = "RESTAURANT" Then

                If GlobalVariable.actualLanguageValue = 0 Then
                    LibelleFacturation.Text = GlobalVariable.ArticleFamily & " BILLING"
                ElseIf GlobalVariable.actualLanguageValue = 0 Then
                    LibelleFacturation.Text = "FACTURATION " & GlobalVariable.ArticleFamily
                End If

                getArticleQuery = "SELECT DESIGNATION_FR, PRIX_VENTE_HT FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY1 AND TYPE=@TYPE AND VISIBLE=@VISIBLE OR DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticle.Text) & "%' AND TYPE_ARTICLE =@ARTICLEFAMILY2 AND TYPE=@TYPE AND VISIBLE=@VISIBLE ORDER BY DESIGNATION_FR ASC"

            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    LibelleFacturation.Text = GlobalVariable.ArticleFamily & " BILLING"
                ElseIf GlobalVariable.actualLanguageValue = 0 Then
                    LibelleFacturation.Text = "FACTURATION " & GlobalVariable.ArticleFamily
                End If

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

    Private Sub GunaDataGridViewArticle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticle.CellClick

        'MessageBox.Show(GlobalVariable.magasinActuel)

        Me.Cursor = Cursors.WaitCursor

        'GunaTextBoxSousFamilleArticle
        If e.RowIndex >= 0 Then

            GunaDataGridViewArticle.Visible = False

            'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
            'il disparait de nouveau après ajout a la facture
            'En plus il ne peut pas aparaitre pour les clients comptoir, si il n'est associé à aucun numéro de bloc_note

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                    GunaButtonAjouterLigne.Visible = True
                End If
            Else
                If Trim(GunaTextBoxCodeClient.Text) = "" Then
                    GunaButtonAjouterLigne.Visible = False
                Else
                    GunaButtonAjouterLigne.Visible = True
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

                If GlobalVariable.DroitAccesDeUtilisateurConnect(0)("CORRECTIONS") = 1 Then
                    GunaTextBoxMontantHT.Enabled = True
                Else
                    GunaTextBoxMontantHT.Enabled = False
                End If

            End If

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                    'On selectionne le nouveau bloc note affiché par défaut
                    Dim blocNoteEnCours As DataTable

                    'We have atleast an element in our combo box
                    blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                    If blocNoteEnCours.Rows.Count > 0 And GunaComboBoxListeDesComandes.Visible Then
                        'On ne peut pas ajouter une ligne a une commande clôturée

                        If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Or blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 2 Then
                            GunaButtonAjouterLigne.Visible = False
                        Else
                            GunaButtonAjouterLigne.Visible = True
                        End If

                    End If

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
                nomArticle = row.Cells("DESIGNATION_FR").Value.ToString

                If GlobalVariable.actualLanguageValue = 0 Then

                    If Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Simple tracking" Or Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Suivi simple" Then
                        suivieStock = True
                    Else
                        suivieStock = False
                    End If

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    If Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Suivi simple" Or Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Simple tracking" Then
                        suivieStock = True
                    Else
                        suivieStock = False
                    End If

                End If

                Double.TryParse(GunaTextBoxQuantite.Text, quantite)

                Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel

                GunaTextBoxMontantHT.Text = Format(prixUtilse(CODE_MAGASIN, Article), "#,##0")

                Double.TryParse(GunaTextBoxMontantHT.Text, montant)
                GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
                Double.TryParse(GunaTextBoxTVA.Text, TVA)
                montantHT = (quantite * montant)
                GunaTextBoxMontantTTC.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

                If Not Trim(Article.Rows(0)("CODE_SOUS_FAMILLE")) = "" Then

                    'DETERMINATION DE LA NATURE DU REPAS (PDJ, DEJEUNER, DINER)
                    GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_SOUS_FAMILLE")

                Else
                    'QUAND LA FAMILLE EST VIDE ONT S'APPUI SYR LA SOUS FAMILLE COMME AVEC : HEBERGEMENT ET LOCATION SALLE
                    GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_FAMILLE")
                End If

                GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
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

                If gestionDesStock = 0 Then

                    GunaTextBoxStockMagasin.Visible = False
                    Label20.Visible = False
                    GunaTextBoxConso.Visible = False
                    GunaLabel2.Visible = False

                ElseIf gestionDesStock = 1 Then

                    GunaTextBoxStockMagasin.Visible = True
                    Label20.Visible = True
                End If

                Dim NOMBRE_UNITE As Integer = 2

                gestionDesUnites(Article, QUANTITE_DU_MAGASIN_ACTUEL, NOMBRE_UNITE)

                '--------------------------------------------------------------------------------------------------------------------------------

                If Integer.Parse(Article.Rows(0)("BOISSON")) = 1 Then

                    'ON RECUPERE LA CONSOMMATION
                    Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If Trim(Article.Rows(0)("CODE_CONSO")).Equals("") Then
                        conso = Nothing
                    End If

                    If conso IsNot Nothing Then

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
                                    'GunaTextBoxStockMagasin.Text = Format((Article.Rows(0)("CONTENANCE") / conso.Rows(0)("VALEUR_NUMERIQUE")) * QUANTITE_DU_MAGASIN_ACTUEL, "#,##0")
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

                                GunaTextBoxStockEconomat.Text = Format(nombreDeBouteille_, "#,##0")
                                GunaTextBoxConsoOnly.Text = Format(nombreDeConso_, "#,##0")

                                'MessageBox.Show(GlobalVariable.magasinActuel & " Qte : " & QUANTITE_DU_MAGASIN_ACTUEL & " nbre de conso dans bouteille : " & nombreDeConsoDansUneBouteille & " nbre total de conso : " & nombreDeConsoTotal)

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

                End If

                GunaDataGridViewArticle.Visible = False

            Else
                clearArticleFields()
            End If
            GunaComboBoxUniteOuConso.Visible = True
        End If


        Me.Cursor = Cursors.Default

    End Sub

    Dim montant As Double = 0
    Dim quantite As Double = 0
    Dim montantTTC As Double = 0
    Dim TVA As Double = 0
    Dim montantHT As Double = 0
    Dim codeArticle As String = ""
    Dim nomArticle As String = ""
    Dim suivieStock As Boolean = False

    Public Sub gestionDesUnites(ByVal Article As DataTable, ByVal QUANTITE_DU_MAGASIN_ACTUEL As String, ByVal NOMBRE_UNITE As Integer)

        GunaComboBoxUniteOuConso.Items.Clear()

        Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")
        Dim CODE_CONSO As String = Article.Rows(0)("CODE_CONSO")

        Dim conso As DataTable = Functions.getElementByCode(CODE_CONSO, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

        Dim pasDeConso As Boolean = False

        If Article.Rows(0)("BOISSON") = 1 Then
            If conso.Rows.Count > 0 Then

                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaComboBoxUniteOuConso.Items.Add("SHOT")
                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    GunaComboBoxUniteOuConso.Items.Add("CONSOMMATION")
                End If

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

    Public Function prixUtilseConso(ByVal CODE_MAGASIN As String, ByVal article As DataTable) As Double

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

    Private Sub GunaTextBoxLecteurRFID_Validated(sender As Object, e As EventArgs) Handles GunaTextBoxLecteurRFID.TextChanged

        If GunaCheckBoxLecteurRFID.Checked Then

            Me.Cursor = Cursors.WaitCursor

            If Not Trim(GunaTextBoxLecteurRFID.Text).Equals("") Then

                Dim ajouter As Boolean = False

                '1- RECUPERATION DES DONNEES POUR INSERTION DANS LA BD 

                GunaDataGridViewArticle.Visible = False

                'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
                'il disparait de nouveau après ajout a la facture
                'En plus il ne peut pas aparaitre pour les clients comptoir, si il n'est associé à aucun numéro de bloc_note

                If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                    If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                        GunaButtonAjouterLigne.Visible = True
                    End If
                Else
                    If Trim(GunaTextBoxCodeClient.Text) = "" Then
                        GunaButtonAjouterLigne.Visible = False
                    Else
                        GunaButtonAjouterLigne.Visible = True
                    End If
                End If

                If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                    If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                        'On selectionne le nouveau bloc note affiché par défaut
                        Dim blocNoteEnCours As DataTable

                        'We have atleast an element in our combo box
                        blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                        If blocNoteEnCours.Rows.Count > 0 And GunaComboBoxListeDesComandes.Visible Then
                            'On ne peut pas ajouter une ligne a une commande clôturée
                            If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Or blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 2 Then
                                GunaButtonAjouterLigne.Visible = False
                            Else
                                GunaButtonAjouterLigne.Visible = True
                            End If
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

                If Article.Rows.Count > 0 Then

                    ajouter = True

                    codeArticle = Article.Rows(0)("CODE_ARTICLE")
                    nomArticle = Article.Rows(0)("DESIGNATION_FR")


                    If GlobalVariable.actualLanguageValue = 0 Then

                        If Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Simple tracking" Or Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Suivi simple" Then
                            suivieStock = True
                        Else
                            suivieStock = False
                        End If

                    ElseIf GlobalVariable.actualLanguageValue = 1 Then

                        If Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Suivi simple" Or Trim(Article.Rows(0)("METHODE_SUIVI_STOCK")) = "Suivi simple" Then
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

                        'DETERMINATION DE LA NATURE DU REPAS (PDJ, DEJEUNER, DINER)
                        GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_SOUS_FAMILLE")

                    Else
                        'QUAND LA FAMILLE EST VIDE ONT S'APPUI SYR LA SOUS FAMILLE COMME AVEC : HEBERGEMENT ET LOCATION SALLE
                        GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_FAMILLE")
                    End If

                    GunaTextBoxLecteurRFID.Text = Article.Rows(0)("DESIGNATION_FR")
                    GunaTextBoxPointDeVente.Text = Article.Rows(0)("TYPE_ARTICLE")
                    '----------------------------------------------------------------------------------------------------------------------------
                    'NOUS ALLONS AFFICHER NON PLUS LA QUANTITE DANS TOUS LES MAGASIN MAIS CELLE DU MAGASIN DE L'UTILISATEUR CONECTE

                    Dim econom As New Economat()
                    Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                    Dim QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, codeArticle)

                    'ON DETERMINE SI LE BOUTON DE GESTION DE STOCK A ETE CHOISI AU NIVEAU DE LA CREATION DES AGENCES
                    Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

                    If gestionDesStock = 0 Then
                        'GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0.00")
                        GunaTextBoxStockEconomat.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.00")

                        GunaTextBoxStockMagasin.Visible = False
                        Label20.Visible = False

                    ElseIf gestionDesStock = 1 Then

                        GunaTextBoxStockMagasin.Visible = True
                        Label20.Visible = True

                        GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0.00")
                        GunaTextBoxStockEconomat.Text = Format(Article.Rows(0)("QUANTITE"), "#,##0.00")

                    End If

                    Dim NOMBRE_UNITE As Integer = 2

                    gestionDesUnites(Article, QUANTITE_DU_MAGASIN_ACTUEL, NOMBRE_UNITE)

                    '--------------------------------------------------------------------------------------------------------------------------------

                    'TRAITEMENT DE CONSOMATION
                    'If Double.Parse(Article.Rows(0)("PRIX_CONSO")) > 0 Then
                    If Integer.Parse(Article.Rows(0)("BOISSON")) = 1 Then

                        'ON RECUPERE LA CONSOMMATION
                        Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                        If conso.Rows.Count > 0 Then

                            Dim QUANTITE_CONSO = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                            GunaTextBoxQuantiteConso.Text = QUANTITE_CONSO

                            'GunaTextBoxMontantHT.Text = Format(Article.Rows(0)("PRIX_CONSO"), "#,##0")
                            GunaTextBoxMontantHT.Text = Format(prixUtilseConso(CODE_MAGASIN, Article), "#,##0")

                            '---------------------------------------------------------------------------------------------------------------------------------------------
                            ' 
                            If gestionDesStock = 0 Then
                                'AFFICHAGE DES QUANTITES DU GRAND MAGASIN
                                'STOCK = CONTENANCE * QTE / VALEUR_NUMERIQUE
                                GunaTextBoxStockMagasin.Text = Format((Article.Rows(0)("CONTENANCE") / conso.Rows(0)("VALEUR_NUMERIQUE")) * Article.Rows(0)("QUANTITE"), "#,##0.00")

                            ElseIf gestionDesStock = 1 Then
                                'AFFICHAGE DES QUANTITES DU PETIT MAGASIN
                                If QUANTITE_DU_MAGASIN_ACTUEL > 0 Then
                                    GunaTextBoxStockMagasin.Text = Format((Article.Rows(0)("CONTENANCE") / conso.Rows(0)("VALEUR_NUMERIQUE")) * QUANTITE_DU_MAGASIN_ACTUEL, "#,##0")
                                Else
                                    GunaTextBoxStockMagasin.Text = 0
                                End If

                            End If

                            '---------------------------------------------------------------------------------------------------------------------------------------------

                            If GlobalVariable.actualLanguageValue = 0 Then
                                GunaTextBoxArticle.Text = "SHOT " & GunaTextBoxArticle.Text
                                GunaComboBoxUniteOuConso.SelectedItem = "SHOT"
                            Else
                                GunaTextBoxArticle.Text = "CONSO " & GunaTextBoxArticle.Text
                                GunaComboBoxUniteOuConso.SelectedItem = "CONSOMMATION"
                            End If

                            GunaComboBoxUniteOuConso.Visible = True

                        Else
                            GunaComboBoxUniteOuConso.Visible = False
                        End If

                    Else
                        GunaComboBoxUniteOuConso.Visible = False
                    End If

                    GunaDataGridViewArticle.Visible = False

                Else

                    'We clear the article field if nothing is found when we click on the custom datagrid
                    'clearArticleFields()

                End If

                GunaComboBoxUniteOuConso.Visible = True
                GunaButtonAjouterLigne.Visible = False

                '2- ENREGISTREMENT DES DONNEES DANS LA BD 

                '-----------------------------------------------------------------

                If ajouter Then

                    Dim proceder As Boolean = False

                    proceder = gestionDesStocks(codeArticle)

                    If proceder Then

                        GunaButtonAjouterLigne.Visible = False

                        Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("mouvement_stock", "MS")

                        Dim CODE_CHAMBRE As String = TB_RoomNo.Text
                        Dim CODE_MODE_PAIEMENT As String = GunaTextBoxNom_Prenom.Text
                        Dim NUMERO_PIECE As String = GunaTextBoxCodeClient.Text
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
                        Dim TYPE_LIGNE_FACTURE As String = GlobalVariable.ArticleFamily.ToUpper()
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

                        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                            TYPE = "comptoir"
                        ElseIf GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                            TYPE = "chambre"
                        ElseIf GlobalVariable.typeDeClientAFacturer = "evenement" Then
                            TYPE = "salle"
                        End If

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

                        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                            If Not GlobalVariable.checkInFacturation Then

                                If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                                    NUMERO_BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString
                                End If

                            End If

                            'GESTION DES MODIFICATIONS D'UN ARTICLE DEJA DANS LA BASE DE DONNEE

                            '-------------------- MISE AJOURS DU MONTANT_BLOC_NOTE EN PLUS -------------------------
                            'Mise a jours du montant en plus du bloc_note, date et caissier apres a jout d'un nouvel article
                            Dim MONTANT_BLOC_NOTE As Double = Trim(GunaTextBoxMontantTTC.Text) - Trim(GunaTextBoxMontantReduction.Text)

                            Dim insertQuery As String = "UPDATE ligne_facture_bloc_note SET MONTANT_BLOC_NOTE=MONTANT_BLOC_NOTE + @MONTANT_BLOC_NOTE WHERE  NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

                            Dim command01 As New MySqlCommand(insertQuery, GlobalVariable.connect)

                            command01.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.String).Value = NUMERO_BLOC_NOTE
                            command01.Parameters.Add("@MONTANT_BLOC_NOTE", MySqlDbType.Double).Value = MONTANT_BLOC_NOTE

                            command01.ExecuteNonQuery()
                            '----------------------------------------

                        End If

                        If GunaTextBoxMontantReduction.Text > 0 Then

                            If GlobalVariable.actualLanguageValue = 0 Then
                                LIBELLE_FACTURE = "DISCOUNT OF " & "[" & GunaTextBoxRemise.Text & " %]" & " ON " + LIBELLE_FACTURE
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                LIBELLE_FACTURE = "REMISE DE " & "[" & GunaTextBoxRemise.Text & " %]" & " SUR " + LIBELLE_FACTURE
                            End If

                            MONTANT_TTC = GunaTextBoxMontantReduction.Text * -1
                            MONTANT_HT = GunaTextBoxMontantReduction.Text * -1
                            MONTANT_REMISE = GunaTextBoxMontantReduction.Text
                            QUANTITE = 1

                            NUMERO_SERIE_DEBUT = CODE_ARTICLE ' NUMERO_SERIE_DEBUT = CODE DE LA LIGNE D'ARTICLE SUR LEQUEL ON APPLIQUE LA REDUCTION POUR PERMETTRE LA SUPPRESSION OU EDITION

                            If ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, "-", CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO) Then
                                'FUSIONNEE : UTILISE COMME SOUS FAMILLE DE L'ARTICLE
                            End If

                        End If

                        If ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO) Then
                            'FUSIONNEE : UTILISE COMME SOUS FAMILLE DE L'ARTICLE
                        End If

                        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

                        GunaComboBoxUniteOuConso.Visible = False

                        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                            AutoLoadOfBlocNote()
                        ElseIf GlobalVariable.typeDeClientAFacturer = "evenement" Then
                            AutoLoadEventListeVisualisation()
                        End If

                        'Refresh Datagrid To view newly inserted Articles
                        OutPutLigneFacture()

                        'We Refresh the general information concerning the Invoice
                        FacturationKeyInformation()

                        'Determining wether or not to save a facturation
                        DisplaySavingButton()

                        'Refreshing the client solde
                        'We update the value of the solde at the level of the front desk
                        Dim MainForm As New MainWindow()

                        If Not GlobalVariable.codeClientToUpdate = "" Then
                            MainForm.GunaLabelSolde.Text = Functions.SituationDuClient(GlobalVariable.codeClientToUpdate)
                        End If

                    End If

                    GunaTextBoxLecteurRFID.Clear()
                    'After adding a line we clear the article field
                    clearArticleFields()
                    '-----------------------------------------------------------------
                End If


            End If

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub GunaCheckBoxLecteurRFID_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxLecteurRFID.CheckedChanged

        If GunaCheckBoxLecteurRFID.Checked Then
            GunaTextBoxLecteurRFID.Visible = True
            GunaTextBoxArticle.Visible = False
        Else
            GunaTextBoxLecteurRFID.Visible = False
            GunaTextBoxArticle.Visible = True
        End If

        GunaTextBoxLecteurRFID.Clear()
        GunaTextBoxArticle.Clear()

    End Sub

    Private Sub GunaPictureBoxLecteurRFI_Click(sender As Object, e As EventArgs) Handles GunaPictureBoxLecteurRFI.Click

        If GunaCheckBoxLecteurRFID.Checked Then
            GunaCheckBoxLecteurRFID.Checked = False
        Else
            GunaCheckBoxLecteurRFID.Checked = True
        End If

    End Sub

    Private Sub GunaLabelNotification_Click(sender As Object, e As EventArgs) Handles GunaLabelNotification.Click
        NotificationsForm.Show()
        NotificationsForm.TopMost = True
    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        NotificationsForm.Show()
        NotificationsForm.TopMost = True
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
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

    Private Sub GunaTextBoxBlocNote_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxBlocNote.TextChanged

        If Trim(GunaTextBoxBlocNote.Text).Equals("") Then
            GunaButtonNouveauBloc.Visible = False
        Else
            GunaButtonNouveauBloc.Visible = True
        End If

    End Sub

    Private Sub GunaTextBoxMontantHT_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantHT.TextChanged

        If Not Trim(GunaTextBoxMontantHT.Text).Equals("") Then

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

            GunaTextBoxMontantTTC.Text = Format(montantHT * quantite, "#,##0")

            GunaTextBoxMontantReduction.Text = Format((GunaTextBoxMontantTTC.Text * GunaTextBoxRemise.Text) / 100, "#,##0")

        End If

    End Sub

    Private Sub GunaTextBoxQuantite_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxQuantite.TextChanged

        If Not Trim(GunaTextBoxQuantite.Text).Equals("") Then

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

        End If

    End Sub

    Private Sub PictureBoxClearArticleFields_Click(sender As Object, e As EventArgs) Handles PictureBoxClearArticleFields.Click
        GunaTextBoxArticle.Clear()
        GunaTextBoxLecteurRFID.Clear()
    End Sub

    Public Function gestionDesStocks(ByVal CODE_ARTICLE As String) As Boolean

        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim magasin As Integer = Integer.Parse(GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("PETIT_MAGAZIN"))

        Dim proceder As Boolean = True
        Dim controlerLeStock As Boolean = True

        'A.1. ON DETERMINE SI ON DOIT GERER LE STOCK EN NEGATIF OU PAS

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

                            'ON DOIT CONVERTIR LA QUANTITE VOULU PAR APPORT A LA PLUS PETITE UNITE ET FAIRE LES COMPARAISON

                            QUANTITE_VOULU = Functions.conversionEnPlusPetiteUnite(CODE_ARTICLE, QUANTITE_VOULU, UNITE_DE_VENTE)

                            Dim UNITE_COMPTAGE As String = infoSupArticle.Rows(0)("UNITE_COMPTAGE")
                            Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                            If unite.Rows.Count > 0 Then

                                If unite.Rows(0)("VALEUR_NUMERIQUE") >= 1 Then
                                    'QUANTITE DU MAGASIN ACTUEL FONCTION DE LA PETITE UNITE
                                    'QUANTITE_DU_MAGASIN_ACTUEL = QUANTITE_DU_MAGASIN_ACTUEL * unite.Rows(0)("VALEUR_NUMERIQUE")
                                    QUANTITE_DU_MAGASIN_ACTUEL = QUANTITE_DU_MAGASIN_ACTUEL
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

                                    If GlobalVariable.actualLanguageValue = 0 Then
                                        languageMessage = "You need to do a supply request"
                                        languageTitle = "INVENTORY MANAGEMENT"
                                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                        languageMessage = "Vous devez faire une demande de réapprovisionnement !!"
                                        languageTitle = "GESTION DES STOCKS"
                                    End If

                                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                                        GunaComboBoxListeDesResaEvents.SelectedValue = GlobalVariable.blocNoteARegler
                                    End If

                                End If

                            End If

                            'ON VERIFIE SI ON TRAITE LES CONSOMMATIONS

                            Dim consoVente As Boolean = False

                            If GunaComboBoxUniteOuConso.SelectedItem = "CONSOMMATION" Or GunaComboBoxUniteOuConso.SelectedItem = "SHOT" Then
                                consoVente = True
                            End If

                            If consoVente Then

                                Dim CODE_CONSO As String = infoSupArticle.Rows(0)("CODE_CONSO")
                                Dim CONTENANCE As Double = infoSupArticle.Rows(0)("CONTENANCE")
                                Dim conso As DataTable = Functions.getElementByCode(CODE_CONSO, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                                If conso.Rows.Count > 0 Then

                                Else
                                    proceder = False
                                End If

                            End If

                            If controlerLeStock Then

                                'ON VERIFIE SI LE STOCK EST SUFFISANT
                                If (QUANTITE_DU_MAGASIN_ACTUEL >= QUANTITE_VOULU) And QUANTITE_DU_MAGASIN_ACTUEL > 0 Then
                                    'A.1.2.1. LE STOCK EST SUFFISANT POUR LA QUANTITE DEMANDE => VENTE NORMAL

                                Else
                                    'A.1.2.2. LE STOCK EST INSUFFISANT POUR LA QUANTITE DEMANDE

                                    If GlobalVariable.actualLanguageValue = 0 Then
                                        languageMessage = "The quantity of " & infoSupArticle.Rows(0)("DESIGNATION_FR") & " been " & QUANTITE_DU_MAGASIN_ACTUEL & " is insufficient !!"
                                        languageTitle = "INVENTORY MANAGEMENT"
                                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                        languageMessage = "Le Stock de " & infoSupArticle.Rows(0)("DESIGNATION_FR") & " étant de " & QUANTITE_DU_MAGASIN_ACTUEL & CONSOMMATION & " en magasin est  insuffisant !!"
                                        languageTitle = "GESTION DES STOCKS"
                                    End If

                                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                    If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                                        GunaComboBoxListeDesResaEvents.SelectedValue = GlobalVariable.blocNoteARegler
                                    End If

                                    proceder = False

                                End If

                            End If

                        End If

                    Else

                        '1.1.1.2. SI NON : AUCUN MAGASIN AFFECTE

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "A Store has not been assigned to you !!"
                            languageTitle = "INVENTORY MANAGAMENT"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Aucun magasin ne vous a été affecté !!"
                            languageTitle = "GESTION DES STOCKS"
                        End If

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                            GunaComboBoxListeDesResaEvents.SelectedValue = GlobalVariable.blocNoteARegler
                        End If

                        proceder = False

                    End If

                Else

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "You don't have the right to have a store !!"
                        languageTitle = "INVENTORY MANAGAMENT"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Vous n'avez pas droit a un magasin !!"
                        languageTitle = "GESTION DES STOCKS"
                    End If

                    '1.2. SI NON
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                        GunaComboBoxListeDesResaEvents.SelectedValue = GlobalVariable.blocNoteARegler
                    End If

                    proceder = False

                End If

            End If

            '1.1.1. TRAITEMENT DES UNITES (STOCKAGE ET DESTOCKAGE)

        End If

        Return proceder

    End Function
    Dim TITRE_CONSOMMATION As String = ""

    Private Sub GunaButtonAjouterLigne_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click

        Me.Cursor = Cursors.WaitCursor

        Dim proceder As Boolean = False

        proceder = gestionDesStocks(codeArticle)

        If proceder Then

            GunaButtonAjouterLigne.Visible = False

            Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("mouvement_stock", "MS")

            Dim CODE_CHAMBRE As String = TB_RoomNo.Text
            Dim CODE_MODE_PAIEMENT As String = GunaTextBoxNom_Prenom.Text
            Dim NUMERO_PIECE As String = GunaTextBoxCodeClient.Text
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

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                TYPE = "comptoir"
            ElseIf GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                TYPE = "chambre"
            ElseIf GlobalVariable.typeDeClientAFacturer = "evenement" Then
                TYPE = "salle"
            End If

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

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                If Not GlobalVariable.checkInFacturation Then

                    If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                        NUMERO_BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString
                        NUMERO_SERIE_FIN = GunaComboBoxListeDesComandes.SelectedValue.ToString
                    End If

                End If

                'GESTION DES MODIFICATIONS D'UN ARTICLE DEJA DANS LA BASE DE DONNEE

                '-------------------- MISE AJOURS DU MONTANT_BLOC_NOTE EN PLUS -------------------------
                'Mise a jours du montant en plus du bloc_note, date et caissier apres a jout d'un nouvel article
                Dim MONTANT_BLOC_NOTE As Double = Trim(GunaTextBoxMontantTTC.Text) - Trim(GunaTextBoxMontantReduction.Text)

                '----------------------------------------
            ElseIf GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                    NUMERO_BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString

                    Dim MONTANT_BLOC_NOTE As Double = Trim(GunaTextBoxMontantTTC.Text) - Trim(GunaTextBoxMontantReduction.Text)

                    'MISE A JOURS DU BLOC NOTE DES ENCHAMBRE

                    Functions.updateMontantBlocNOteEnChambre(NUMERO_BLOC_NOTE, CODE_RESERVATION, MONTANT_BLOC_NOTE)

                End If

            End If

            '-------------------------- LIGNE FACTURATION--------------------------

            ' If Trim(CODE_FACTURE) = "" Then
            'CODE_FACTURE = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")
            'GunaTextBoxNumfacture.Text = CODE_FACTURE
            'End If


            If ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO) Then
                'FUSIONNEE : UTILISE COMME SOUS FAMILLE DE L'ARTICLE

            End If

            If GunaTextBoxMontantReduction.Text > 0 Then

                If GlobalVariable.actualLanguageValue = 0 Then
                    LIBELLE_FACTURE = "DISOUNT OF " & "[" & GunaTextBoxRemise.Text & " %]" & " ON " + LIBELLE_FACTURE
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    LIBELLE_FACTURE = "REMISE DE " & "[" & GunaTextBoxRemise.Text & " %]" & " SUR " + LIBELLE_FACTURE
                End If

                MONTANT_TTC = GunaTextBoxMontantReduction.Text * -1
                MONTANT_HT = GunaTextBoxMontantReduction.Text * -1
                MONTANT_REMISE = GunaTextBoxMontantReduction.Text
                QUANTITE = 1

                NUMERO_SERIE_DEBUT = CODE_ARTICLE ' NUMERO_SERIE_DEBUT = CODE DE LA LIGNE D'ARTICLE SUR LEQUEL ON APPLIQUE LA REDUCTION POUR PERMETTRE LA SUPPRESSION OU EDITION

                If ligneFacture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, "-", CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO) Then
                    'FUSIONNEE : UTILISE COMME SOUS FAMILLE DE L'ARTICLE
                End If

            End If

            Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

            GunaComboBoxUniteOuConso.Visible = False

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                miseAJourDuMontantDuBlocNote(NUMERO_BLOC_NOTE)
                BlocNotesVisualisation()
            ElseIf GlobalVariable.typeDeClientAFacturer = "evenement" Then
                AutoLoadEventListeVisualisation()
            End If

            'Refresh Datagrid To view newly inserted Articles
            OutPutLigneFacture()

            'We Refresh the general information concerning the Invoice
            FacturationKeyInformation()

            'Determining wether or not to save a facturation
            DisplaySavingButton()

            'Refreshing the client solde
            'We update the value of the solde at the level of the front desk
            Dim MainForm As New MainWindow()

            If Not GlobalVariable.codeClientToUpdate = "" Then
                MainForm.GunaLabelSolde.Text = Functions.SituationDuClient(GlobalVariable.codeClientToUpdate)
            End If

            Dim MONTANT_BLOC_NOTE_ As Double = GunaTextBoxMontantTTCGeneral.Text
            Functions.updateOfFields("ligne_facture_bloc_note", "MONTANT_BLOC_NOTE", MONTANT_BLOC_NOTE_, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 0)

            bloquerLaModificationDuPrixUnitaire()

        End If

        'After adding a line we clear the article field
        clearArticleFields()

        'SI L'ON EST ENTRAINE D'AJOUTER DANS LE CADRE D'UNE MODIFICATION

        Me.Cursor = Cursors.Default


        If GlobalVariable.AgenceActuelle.Rows(0)("PRIX_BAR_RESTAU_MODIFIABLE") = 1 Then
            GunaTextBoxMontantHT.Enabled = True
        Else
            GunaTextBoxMontantHT.Enabled = False
        End If

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

        If Not Trim(GunaTextBoxMontantReduction.Text).Equals("") Then


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

        End If

    End Sub

    Dim typeDeReductionPourcentageOuMontant As String = ""

    Private Sub GunaTextBoxRemise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRemise.TextChanged

        If Not Trim(GunaTextBoxRemise.Text).Equals("") Then

            If typeDeReductionPourcentageOuMontant = "pourcentage" Then

                If Trim(GunaTextBoxRemise.Text) = "" Then
                    GunaTextBoxRemise.Text = 0
                End If

                If Trim(GunaTextBoxMontantTTC.Text) = "" Then
                    GunaTextBoxMontantTTC.Text = 0
                End If

                GunaTextBoxMontantReduction.Text = Format((GunaTextBoxMontantTTC.Text * GunaTextBoxRemise.Text) / 100, "#,##0")

            End If

        End If

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

                    'GunaTextBoxConsoOnly.Visible = True
                    'GunaLabel5.Visible = True
                    'GunaLabel6.Visible = True

                    Dim QUANTITE_CONSO = conso.Rows(0)("VALEUR_NUMERIQUE")

                    Dim PRIX_CONSO As Double = 0

                    If article.Rows.Count > 0 Then

                        'PRIX_CONSO = article.Rows(0)("PRIX_CONSO")
                        PRIX_CONSO = prixUtilseConso(CODE_MAGASIN, article)

                        'GunaTextBoxQuantiteConso.Text = QUANTITE_CONSO

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

                            ' GunaTextBoxStockEconomat.Text = Format(nombreDeBouteille, "#,##0")
                            'GunaTextBoxConsoOnly.Text = Format(nombreDeConso, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                        ElseIf gestionDesStock = 1 Then

                            'GunaTextBoxStockMagasin.Text = Format(nombreDeBouteille, "#,##0")
                            'GunaTextBoxConso.Text = Format(nombreDeConso, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                        End If

                        '------------------------------------------------------------------------------------------------------------------------

                    End If

                Else

                    'GunaTextBoxConsoOnly.Visible = False
                    'GunaLabel5.Visible = False
                    'GunaLabel6.Visible = False

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

                    GunaTextBoxArticle.Text = article.Rows(0)("DESIGNATION_FR")

                    GunaDataGridViewArticle.Visible = False

                End If

            End If

        End If

    End Sub

    Private Sub SupprimerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem1.Click

        'SUPPRESSION D'UN ARTICLE DEJA DANS LA BASE DE DONNEE

        Dim NUMERO_BLOC_NOTE As String = ""
        Dim numberOfElement As Integer = 0

        If GunaDataGridViewLigneFacture.Rows.Count > 0 Then

            numberOfElement = GunaDataGridViewLigneFacture.Rows.Count

            Dim ETAT_BLOC_NOTE As String = Trim(GunaButtonSaveFacturation.Text)

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Or GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then

                If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                    NUMERO_BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString
                End If

            End If

            Dim DeleteRow As Boolean = False

            Dim rowToDelete As String = ""
            Dim NameOfrowToDelete As String = ""
            Dim ligneDuBlocNOte As Integer
            Dim ID_LIGNE_FACTURE As Integer

            Dim MONTANT_A_RETRANCHER As Double = 0

            If rowToDelete = "" Then
                rowToDelete = GunaDataGridViewLigneFacture.CurrentRow.Cells("ARTICLE").Value.ToString

                ligneDuBlocNOte = GunaDataGridViewLigneFacture.CurrentRow.Cells("ID_LIGNE_FACTURE").Value
                ID_LIGNE_FACTURE = GunaDataGridViewLigneFacture.CurrentRow.Cells("ID_LIGNE_FACTURE").Value

                If GlobalVariable.actualLanguageValue = 0 Then

                    NameOfrowToDelete = GunaDataGridViewLigneFacture.CurrentRow.Cells("ITEM").Value.ToString
                    MONTANT_A_RETRANCHER = GunaDataGridViewLigneFacture.CurrentRow.Cells("AMOUNT IT").Value

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    NameOfrowToDelete = GunaDataGridViewLigneFacture.CurrentRow.Cells("DESIGNATION").Value.ToString
                    MONTANT_A_RETRANCHER = GunaDataGridViewLigneFacture.CurrentRow.Cells("MONTANT TTC").Value

                End If

            End If

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Do you really want to delete the item " & NameOfrowToDelete
                languageTitle = "Item delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Voulez-vous vraiment Supprimer l'article " & NameOfrowToDelete
                languageTitle = "Suppression d'article"
            End If

            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
                DeleteRow = False
            Else
                DeleteRow = True
            End If

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                If DeleteRow Then

                    Dim CODE_ARTICLE As String = rowToDelete

                    'Dim articleExistant As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "CODE_ARTICLE", NUMERO_BLOC_NOTE, "NUMERO_BLOC_NOTE")
                    Dim articleExistant As DataTable = Functions.GetAllElementsOnTwoConditions(ID_LIGNE_FACTURE, "ligne_facture_temp", "ID_LIGNE_FACTURE", NUMERO_BLOC_NOTE, "NUMERO_BLOC_NOTE")

                    If articleExistant.Rows.Count > 0 Then

                        'GESTION DE MODIFICATION DONC ON RETRANCHE L'ANCIEN MONTANT AVANT AJOUT DE LA NOUVELLE
                        Dim infoBlocNote As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                        If infoBlocNote.Rows.Count > 0 Then

                            If infoBlocNote.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                                '-------------------- MISE AJOURS DU MONTANT_BLOC_NOTE EN MOINS-------------------------
                                'Mise a jours du montant du bloc_note, date et caissier apres a jout d'un nouvel article

                                '----------------------------------------

                                'ON SUPPRIME L'ARTICLE CAR IL EST DEJA EXISTANT DANS LA BASE DE DONNEE
                                'Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "CODE_ARTICLE", "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE)
                                Functions.DeleteElementOnTwoConditions(ID_LIGNE_FACTURE, "ligne_facture_temp", "ID_LIGNE_FACTURE", "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE)

                                'SUPPRESSION DES LIGNES DE REDUCTION SI ELLE EXISTE
                                Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "NUMERO_SERIE_DEBUT", "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE)

                                miseAJourDuMontantDuBlocNote(NUMERO_BLOC_NOTE)

                                If GlobalVariable.actualLanguageValue = 0 Then
                                    languageMessage = "You successfully deleted"
                                    languageTitle = "Delete"
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    languageMessage = "Vous avez supprimé avec succès"
                                    languageTitle = "Suppression"
                                End If

                                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else

                                If GlobalVariable.actualLanguageValue = 0 Then
                                    languageMessage = "Cannot delete, receipt as it is closed!"
                                    languageTitle = "Delete"
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    languageMessage = "Impossible de supprimer, bloc notre clôturé !"
                                    languageTitle = "Suppression"
                                End If

                                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If
                        End If

                    Else

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "Impossible to delete, the item as the receipt is closed !"
                            languageTitle = "Delete"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Impossible de supprimer, l'article qu'il le bloc note est clôturé !"
                            languageTitle = "Suppression"
                        End If

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

                GunaComboBoxListeDesComandes.SelectedValue = NUMERO_BLOC_NOTE

                BlocNotesVisualisation()

            Else

                Dim CODE_ARTICLE As String = rowToDelete

                Dim CODE_FACTURE As String = Trim(GunaTextBoxNumfacture.Text)

                'Dim articleExistant As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "CODE_ARTICLE", CODE_FACTURE, "CODE_FACTURE")
                Dim articleExistant As DataTable = Functions.GetAllElementsOnTwoConditions(ID_LIGNE_FACTURE, "ligne_facture_temp", "ID_LIGNE_FACTURE", CODE_FACTURE, "CODE_FACTURE")

                If articleExistant.Rows.Count > 0 Then
                    'ON SUPPRIME L'ARTICLE CAR IL EST DEJA EXISTANT DANS LA BASE DE DONNEE
                    'Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "CODE_ARTICLE", "CODE_FACTURE", CODE_FACTURE)
                    Functions.DeleteElementOnTwoConditions(ID_LIGNE_FACTURE, "ligne_facture_temp", "ID_LIGNE_FACTURE", "CODE_FACTURE", CODE_FACTURE)

                    'SUPPRESSION DES LIGNES DE REDUCTION SI ELLE EXISTE
                    Functions.DeleteElementOnTwoConditions(CODE_ARTICLE, "ligne_facture_temp", "NUMERO_SERIE_DEBUT", "CODE_FACTURE", CODE_FACTURE)

                End If

                If GlobalVariable.typeDeClientAFacturer = "evenement" Then
                    AutoLoadEventListeVisualisation()
                End If

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "You successfully deleted"
                    languageMessage = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Vous avez supprimé avec succès"
                    languageMessage = "Supression"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                'GunaComboBoxListeDesComandes.SelectedValue = NUMERO_BLOC_NOTE

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "There is nothing to delete"
                languageMessage = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Aucune ligne à supprimer!"
                languageMessage = "Supression"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        OutPutLigneFacture()

        FacturationKeyInformation()

        DisplaySavingButton()

        Dim MONTANT_BLOC_NOTE_ As Double = GunaTextBoxMontantTTCGeneral.Text
        Functions.updateOfFields("ligne_facture_bloc_note", "MONTANT_BLOC_NOTE", MONTANT_BLOC_NOTE_, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 0)

        If numberOfElement = 1 Then
            GunaDataGridViewLigneFacture.DataSource = Nothing
        End If

        'AFFICHAGE DES DETAILS DU BLOC NOTE APRES UN DOUBLE CLICK
        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

        'MontantTotalDesVentesDuJours(DateDeSituation)
    End Sub

    Public Sub miseAJourDuMontantDuBlocNote(ByVal NUMERO_BLOC_NOTE As String)

        Dim MONTANT_BLOC_NOTE As Double = 0

        Dim ligneDuBlocNotes As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")

        If ligneDuBlocNotes.Rows.Count > 0 Then

            For i = 0 To ligneDuBlocNotes.Rows.Count - 1
                MONTANT_BLOC_NOTE += ligneDuBlocNotes.Rows(i)("MONTANT_TTC")
            Next

        End If

        Dim updateQuery As String = "UPDATE ligne_facture_bloc_note Set MONTANT_BLOC_NOTE = @MONTANT_BLOC_NOTE WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

        Dim command1 As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command1.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.String).Value = NUMERO_BLOC_NOTE
        command1.Parameters.Add("@MONTANT_BLOC_NOTE", MySqlDbType.Double).Value = MONTANT_BLOC_NOTE

        command1.ExecuteNonQuery()

    End Sub

    Dim pointDeVenteLorsDelaModifitication = ""

    Private Sub GunaDataGridViewLigneFacture_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLigneFacture.CellDoubleClick

        If e.RowIndex >= 0 Then

            If GunaButtonSaveFacturation.Text = "Clôturer" Or GunaButtonSaveFacturation.Text = "Enregistrer" Or GunaButtonSaveFacturation.Text = "Close" Or GunaButtonSaveFacturation.Text = "Save" Then

                '------------------------------------------------------------------------------
                GunaButtonAjouterLigne.Visible = True

                Dim article As New DataTable()

                Dim row As DataGridViewRow

                row = GunaDataGridViewLigneFacture.Rows(e.RowIndex)

                codeArticle = Trim(row.Cells("ARTICLE").Value.ToString)

                Dim ID_LIGNE_FACTURE As Integer = Trim(row.Cells("ID_LIGNE_FACTURE").Value)

                article = Functions.getElementByCode(codeArticle, "article", "CODE_ARTICLE")

                'GESTION DES UNITES A AFFICHER

                GunaComboBoxUniteOuConso.Items.Clear()

                gestionDesUnitesAppro(article, 1)

                GunaComboBoxUniteOuConso.SelectedItem = Trim(row.Cells("CODE_LOT").Value.ToString)

                GunaComboBoxUniteOuConso.Visible = True

                If GlobalVariable.actualLanguageValue = 0 Then

                    GunaTextBoxQuantite.Text = Format(row.Cells("QUANTITY").Value, "#,##0")

                    GunaTextBoxMontantHT.Text = Format(row.Cells("UNIT PRICE").Value, "#,##0")

                    GunaTextBoxMontantTTC.Text = Format(row.Cells("AMOUNT IT").Value, "#,##0")

                    GunaTextBoxArticle.Text = Trim(row.Cells("ITEM").Value.ToString)

                    If GunaTextBoxArticle.Text.Contains("ACCOMMODATION") Or GunaTextBoxArticle.Text.Contains("HALL RENT") Then
                        GunaTextBoxMontantHT.Enabled = True
                    End If

                    GunaTextBoxPointDeVente.Text = row.Cells("TYPE_LIGNE_FACTURE").Value.ToString

                    If article.Rows.Count > 0 Then
                        GunaTextBoxStockMagasin.Text = Format(article.Rows(0)("QUANTITE"), "#,##.00")

                        GunaTextBoxSousFamilleArticle.Text = article.Rows(0)("CODE_SOUS_FAMILLE")
                    Else
                        GunaTextBoxStockMagasin.Text = 0
                        GunaButtonAjouterLigne.Visible = False
                    End If

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    GunaTextBoxQuantite.Text = Format(row.Cells("QUANTITE").Value, "#,##0")

                    GunaTextBoxMontantHT.Text = Format(row.Cells("PU TTC").Value, "#,##0")

                    GunaTextBoxMontantTTC.Text = Format(row.Cells("MONTANT TTC").Value, "#,##0")

                    GunaTextBoxArticle.Text = Trim(row.Cells("DESIGNATION").Value.ToString)

                    If GunaTextBoxArticle.Text.Contains("HEBERGEMENT") Or GunaTextBoxArticle.Text.Contains("LOCATION SALLE") Then
                        GunaTextBoxMontantHT.Enabled = True
                    End If

                    GunaTextBoxPointDeVente.Text = row.Cells("TYPE_LIGNE_FACTURE").Value.ToString

                    If article.Rows.Count > 0 Then
                        GunaTextBoxStockMagasin.Text = Format(article.Rows(0)("QUANTITE"), "#,##.00")

                        GunaTextBoxSousFamilleArticle.Text = article.Rows(0)("CODE_SOUS_FAMILLE")
                    Else
                        GunaTextBoxStockMagasin.Text = 0
                        GunaButtonAjouterLigne.Visible = False
                    End If

                End If

                '-----------------------------------------------------------------------------------------------------------------------

                Dim econom As New Economat()
                Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                Dim QUANTITE_DU_MAGASIN_ACTUEL = 0

                Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, codeArticle)

                'ON DETERMINE SI LE BOUTON DE GESTION DE STOCK A ETE CHOISI AU NIVEAU DE LA CREATION DES AGENCES
                Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

                If gestionDesStock = 0 Then
                    'GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0.00")
                    GunaTextBoxStockEconomat.Text = Format(article.Rows(0)("QUANTITE"), "#,##0.00")

                    GunaTextBoxStockMagasin.Visible = False
                    Label20.Visible = False
                    GunaTextBoxConso.Visible = False
                    GunaLabel2.Visible = False

                ElseIf gestionDesStock = 1 Then

                    GunaTextBoxStockMagasin.Visible = True
                    Label20.Visible = True
                    GunaLabel2.Visible = True
                    GunaTextBoxConso.Visible = True

                    'GunaTextBoxStockMagasin.Text = Format(QUANTITE_DU_MAGASIN_ACTUEL, "#,##0.00")
                    GunaTextBoxStockEconomat.Text = Format(article.Rows(0)("QUANTITE"), "#,##0.00")

                End If

                Dim valeurConversion As Double = 1

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

                        valeurConversion = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                        GunaTextBoxQuantiteConso.Text = valeurConversion

                    Else

                        GunaTextBoxConsoOnly.Visible = False
                        GunaLabel5.Visible = False
                        GunaLabel6.Visible = False

                    End If

                End If

                Dim nombreDeConsoTotal = QUANTITE_DU_MAGASIN_ACTUEL

                Dim nombreDeBouteille As Double = 0
                Dim nombreDeConso As Integer = 0

                Dim contenance As Double = article.Rows(0)("CONTENANCE")

                Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                If nombreDeConsoDansUneBouteille > 0 Then
                    nombreDeBouteille = Int(nombreDeConsoTotal / nombreDeConsoDansUneBouteille)
                    nombreDeConso = nombreDeConsoTotal Mod nombreDeConsoDansUneBouteille
                End If

                If gestionDesStock = 0 Then

                    GunaTextBoxStockEconomat.Text = Format(nombreDeBouteille, "#,##0")
                    GunaTextBoxConsoOnly.Text = Format(nombreDeConso, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                ElseIf gestionDesStock = 1 Then

                    GunaLabel6.Visible = False
                    GunaTextBoxConsoOnly.Visible = False
                    GunaLabel5.Visible = False
                    GunaTextBoxStockMagasin.Text = Format(nombreDeBouteille, "#,##0")
                    GunaTextBoxConso.Text = Format(nombreDeConso, "#,##0") 'LES QTE DES ARTICLES APAR APPORTS AUX CONSOMMATIONS

                End If

                '------------------------------------------------------------------------------------------------------------------------

                GunaDataGridViewArticle.Visible = False

                Dim NUMERO_BLOC_NOTE As String = ""
                Dim MONTANT_BLOC_NOTE As Double = GunaTextBoxMontantTTC.Text
                Dim CODE_FACTURE As String = GunaTextBoxNumfacture.Text

                If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                    If GunaButtonSaveFacturation.Text = "Clôturer" Or GunaButtonSaveFacturation.Text = "Close" Then

                        Dim infoSupBlocNote As DataTable

                        If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                            NUMERO_BLOC_NOTE = GunaComboBoxListeDesComandes.SelectedValue.ToString

                            infoSupBlocNote = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                            GunaDataGridViewBlocNoteOuvert.Columns.Clear()

                        End If

                        'GunaButtonAjouterLigne.Visible = True
                        'Functions.DeleteElementOnTwoConditions(CODE_FACTURE, "ligne_facture_temp", "CODE_FACTURE", "CODE_ARTICLE", codeArticle)
                        Functions.DeleteElementOnTwoConditions(CODE_FACTURE, "ligne_facture_temp", "CODE_FACTURE", "ID_LIGNE_FACTURE", ID_LIGNE_FACTURE)

                        'LIGNE DE REDUCTION DELETE
                        Functions.DeleteElementOnTwoConditions(CODE_FACTURE, "ligne_facture_temp", "CODE_FACTURE", "NUMERO_SERIE_DEBUT", codeArticle)

                        If infoSupBlocNote.Rows.Count > 0 Then

                            miseAJourDuMontantDuBlocNote(NUMERO_BLOC_NOTE)

                        End If

                        BlocNotesVisualisation()

                    Else
                        GunaButtonAjouterLigne.Visible = False
                    End If

                Else
                    'Functions.DeleteElementOnTwoConditions(CODE_FACTURE, "ligne_facture_temp", "CODE_FACTURE", "CODE_ARTICLE", codeArticle)
                    Functions.DeleteElementOnTwoConditions(CODE_FACTURE, "ligne_facture_temp", "CODE_FACTURE", "ID_LIGNE_FACTURE", ID_LIGNE_FACTURE)

                    'LIGNE DE REDUCTION DELETE
                    Functions.DeleteElementOnTwoConditions(CODE_FACTURE, "ligne_facture_temp", "CODE_FACTURE", "NUMERO_SERIE_DEBUT", codeArticle)

                    If GlobalVariable.typeDeClientAFacturer = "evenement" Then
                        AutoLoadEventListeVisualisation()
                    End If

                End If

                OutPutLigneFacture()

                FacturationKeyInformation()

                DisplaySavingButton()
                '------------------------------------------------------------------------------
            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Impossible to close a receipt that has been closed !!"
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Impossible de supprimer un bloc note cloturé !!"
                    languageTitle = "Supression"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        If Not GunaDataGridViewLigneFacture.Rows.Count > 0 Then
            GunaButtonSaveFacturation.Visible = False
        End If

    End Sub

    Dim ENSEMBLE_DES_BLOC_NOTES(10) As BlocNote

    Private Sub TransférerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransférerToolStripMenuItem.Click

        If GunaDataGridViewBlocNoteOuvert.Rows.Count > 0 Then

            Dim i As Integer = 0

            For Each row As DataGridViewRow In GunaDataGridViewBlocNoteOuvert.SelectedRows

                Dim NUMERO_BLOC_NOTE As String = Trim(row.Cells(0).Value.ToString)

                ENSEMBLE_DES_BLOC_NOTES(i).NUMERO_BLOC_NOTE = NUMERO_BLOC_NOTE

                i += 1

            Next

            TransfertDeClientEntreCaissierForm.Show()
            TransfertDeClientEntreCaissierForm.TopMost = True

        End If
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        'SUPRESSION DE BLOC NOTE VIDE

        If GunaDataGridViewBlocNoteOuvert.Rows.Count > 0 Then

            Dim NUMERO_BLOC_NOTE As String = ""

            Dim ETAT_BLOC_NOTE As String = Trim(GunaButtonSaveFacturation.Text)

            Dim DeleteRow As Boolean = False

            Dim rowToDelete As String = ""
            Dim rowToDeleteMontant As Double = 0

            Dim MONTANT_A_RETRANCHER As Double = 0

            If rowToDelete = "" Then
                rowToDelete = GunaDataGridViewBlocNoteOuvert.CurrentRow.Cells(0).Value.ToString
                NUMERO_BLOC_NOTE = GunaDataGridViewBlocNoteOuvert.CurrentRow.Cells(0).Value.ToString
                rowToDeleteMontant = GunaDataGridViewBlocNoteOuvert.CurrentRow.Cells(1).Value
            End If

            If rowToDeleteMontant > 0 Then

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Impossible to delete the receipt as it is not empty !!" & Chr(13) & "Please transfer the receipt"
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Impossible de supprimer ce bloc note car il n'est pas vide !!" & Chr(13) & "Bien vouloir le transférer"
                    languageTitle = "Suppression"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                Dim dialog As DialogResult


                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Do you really want to delete the receipt" & rowToDelete
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Voulez-vous vraiment Supprimer le bloc note " & rowToDelete
                    languageTitle = "Suppression"
                End If

                dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If dialog = DialogResult.No Then
                    'e.Cancel = True
                    DeleteRow = False
                Else
                    DeleteRow = True
                End If

                If DeleteRow Then

                    If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                        'GESTION DE MODIFICATION DONC ON RETRANCHE L'ANCIEN MONTANT AVANT AJOUT DE LA NOUVELLE
                        Dim infoBlocNote As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                        If infoBlocNote.Rows.Count > 0 Then

                            If infoBlocNote.Rows(0)("ETAT_BLOC_NOTE") = 0 Then

                                Functions.DeleteElementOnTwoConditions(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE", "ETAT_BLOC_NOTE", 0)

                                If GlobalVariable.actualLanguageValue = 0 Then
                                    languageMessage = "Successfully deleted"
                                    languageTitle = "Delete"
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    languageMessage = "Vous avez supprimé avec succès"
                                    languageTitle = "Suppression"
                                End If

                                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                AutoLoadOfBlocNote()

                                OutPutLigneFacture()

                                FacturationKeyInformation()

                                DisplaySavingButton()

                            Else
                                If GlobalVariable.actualLanguageValue = 0 Then
                                    languageMessage = "Impossible to delete a closed receipt !"
                                    languageTitle = "Delete"
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    languageMessage = "Impossible de supprimer, bloc notre clôturé !"
                                    languageTitle = "Suppression"
                                End If

                                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If

                        End If

                    End If

                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Nothing to be deleted !"
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Aucune ligne à supprimer!"
                languageTitle = "Suppression"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            If Not GunaDataGridViewBlocNoteOuvert.Rows.Count > 0 Then
                GunaComboBoxListeDesComandes.DataSource = Nothing
            End If

        End If


    End Sub

    Private Sub LabelTotalVenteComptoire_Click(sender As Object, e As EventArgs) Handles LabelTotalVenteComptoire.Click

        Dim ETAT_FACTURE As Integer = 0

        If False Then
            ComparaisonVenteReglement.Show()
            ComparaisonVenteReglement.TopMost = True
        Else
            journalDesVentesDuShiftParRubrique(ETAT_FACTURE)
        End If

    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click

        Dim ETAT_FACTURE As Integer = 0

        If False Then
            ComparaisonVenteReglement.Show()
            ComparaisonVenteReglement.TopMost = True
        Else
            journalDesVentesDuShiftParRubrique(ETAT_FACTURE)
        End If

    End Sub

    Private Sub TypeDévènementToolStripMenuItemEvent_Click(sender As Object, e As EventArgs) Handles TypeDévènementToolStripMenuItemEvent.Click
        EvenementForm.Show()
        EvenementForm.BringToFront()
    End Sub

    'TRANSFERT DE BLOC NOTE D'UN CAISSIER A UN AUTRE

    Public Sub TransfertDeBlocNoteAvantPassassionDeService(ByVal NEW_CODE_CAISSIER As String)

        If ENSEMBLE_DES_BLOC_NOTES.Length > 0 Then

            For i = 0 To ENSEMBLE_DES_BLOC_NOTES.Length - 1

                Dim NUMERO_BLOC_NOTE As String = ENSEMBLE_DES_BLOC_NOTES(i).NUMERO_BLOC_NOTE

                Dim caisse As New Caisse()

                caisse.TransfertElementDeCaisseAvantPassassion(NUMERO_BLOC_NOTE, NEW_CODE_CAISSIER)

            Next

        End If

        GunaDataGridViewBlocNoteOuvert.Rows.Clear()

        BlocNotesVisualisation() 'RECAPITULATIF DES BLOC NOTES

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "Transfer successful !!"
            languageTitle = "Sales Managament"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Transfert réalisé avec succès !!"
            languageTitle = "Gestion de Caisse"
        End If

        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Dim CODE_FACTURE_GLOBAL As String

    Private Sub GunaTextBoxNumfacture_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNumfacture.TextChanged

        If Not Trim(GunaTextBoxNumfacture.Text).Equals("") Then
            CODE_FACTURE_GLOBAL = GunaTextBoxNumfacture.Text
        End If

    End Sub


    Public Function determinonsLeMontantTotalDesVentesPourLesEvenement(ByVal dateDeTravail As Date, ByVal type_salle_chambre As String) As Double

        '1- ON DETERMINE TOUTES LES RESERVATIONS LOGE
        Dim queryEnChambre As String = "SELECT CODE_RESERVATION FROM reserve_conf WHERE DATE_ENTTRE <= '" & dateDeTravail.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & dateDeTravail.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

        Dim commandEnChambreSalle As New MySqlCommand(queryEnChambre, GlobalVariable.connect)
        commandEnChambreSalle.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = type_salle_chambre
        commandEnChambreSalle.Parameters.Add("@ETAT", MySqlDbType.Int16).Value = 0

        Dim adapterEnChambreSalle As New MySqlDataAdapter(commandEnChambreSalle)
        Dim tableEnChambreSalle As New DataTable()
        adapterEnChambreSalle.Fill(tableEnChambreSalle)

        Dim totalDesConsommation As Double = 0
        Dim CODE_RESERVATION As String = ""

        If tableEnChambreSalle.Rows.Count > 0 Then
            '2- POUR CHACUN DES RESA ON DETERMINE LE MONTANT DE SES CONSOMMATION UN JOUR DONNEE
            For i = 0 To tableEnChambreSalle.Rows.Count - 1
                CODE_RESERVATION = tableEnChambreSalle.Rows(i)("CODE_RESERVATION")
                totalDesConsommation += consommationDUneReservation(CODE_RESERVATION, dateDeTravail)
            Next

        End If

        Return totalDesConsommation

    End Function

    Public Function consommationDUneReservation(ByVal CODE_RESERVATION As String, ByVal DateDeSituation As Date) As Double

        'PERMET DE DETERMINER LES CONSOMMATION DU F&B D'UN CLIENT DONNEE
        Dim totalDesConsommation As Double = 0
        Dim ETAT As Integer = 0

        Dim getUserQuery = "SELECT * FROM ligne_facture WHERE CODE_UTILISATEUR_CREA = @CODE_CAISSIER AND FUSIONNEE NOT IN ('LOCATION SALLE','HEBERGEMENT', 'ACCOMMODATION','HALL RENTING') AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY DATE_FACTURE DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT
        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        If dt.Rows.Count > 0 Then

            For j = 0 To dt.Rows.Count - 1
                totalDesConsommation += dt.Rows(j)("MONTANT_TTC")
            Next

        End If

        Return totalDesConsommation

    End Function

    'PERMET A CE QUE LES VENTES EN CHAMBRE NE SE REAFFICHE PAS
    Public Shared Function aDejaClotureLeShift(ByVal DateDeSituation As Date) As Boolean

        Dim aDejaCloture As Boolean = False

        Dim getUserQuery = "SELECT * FROM resume_vente_journaliere WHERE CODE_UTILISATEUR = @CODE_UTILISATEUR AND DATE_VENTE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_VENTE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "'"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        If dt.Rows.Count > 0 Then
            aDejaCloture = True
        End If

        Return aDejaCloture

    End Function


    Public Sub resumeDesVentesDuJours(ByVal DateDeSituation As Date)

        Dim MontantTotalDesVenteDuComptoire As Double = 0
        Dim MontantTotalDesVenteDesEnChambres As Double = 0
        Dim MontantTotalDesVente As Double = 0
        Dim MontantTotalDesVenteDesVersCompte As Double = 0
        Dim MontantTotalDesVenteDesGratuite As Double = 0
        Dim MontantTotalDesVenteDesGratuiteEnChambre As Double = 0
        Dim MontantTotalDesVenteEvenement As Double = 0

        Dim ETAT As Integer = 0 ' ON CHOISI LES LIGNES A ZERO AINSI UNE FOIS LA CAISSER FERME CELLE-CI N'APPARAITRONS PLUS

        Dim caissier As New Caisse()

        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        'BlocNoteDunCaissierQuelconque = > PRENANT EN COMPTE L'ETAT = 0 -> DONC FACTURE DONC L'EQUILIBRE N'A PAS ETE EFFECTUE: NON EQUILIBRE
        Dim totalDesBlocNotesEnCours As DataTable = caissier.BlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        If totalDesBlocNotesEnCours.Rows.Count > 0 Then

            For k = 0 To totalDesBlocNotesEnCours.Rows.Count - 1

                If totalDesBlocNotesEnCours.Rows(k)("ETAT_FACTURE") = 0 Then ' COMPTOIR
                    MontantTotalDesVenteDuComptoire += totalDesBlocNotesEnCours.Rows(k)("MONTANT_BLOC_NOTE")
                ElseIf totalDesBlocNotesEnCours.Rows(k)("ETAT_FACTURE") = 2 Then 'GRATUITEE
                    MontantTotalDesVenteDesGratuite += totalDesBlocNotesEnCours.Rows(k)("MONTANT_BLOC_NOTE")
                ElseIf totalDesBlocNotesEnCours.Rows(k)("ETAT_FACTURE") = 3 Then 'COMPTE DEBITEUR
                    MontantTotalDesVenteDesVersCompte += totalDesBlocNotesEnCours.Rows(k)("MONTANT_BLOC_NOTE")
                ElseIf totalDesBlocNotesEnCours.Rows(k)("ETAT_FACTURE") = 1 Then 'VENTE EN CHAMBRE
                    MontantTotalDesVenteDesEnChambres += totalDesBlocNotesEnCours.Rows(k)("MONTANT_BLOC_NOTE")
                End If

            Next

        Else
            'GunaAdvenceButtonAppro.Text = DateDeSituation & " - " & CODE_CAISSIER
        End If

        LabelTotalVenteComptoire.Text = Format(MontantTotalDesVenteDuComptoire, "#,##0")

        LabelTotalVenteEnChambre.Text = Format(MontantTotalDesVenteDesEnChambres, "#,##0")

        LabelVenteVersCompte.Text = Format(MontantTotalDesVenteDesVersCompte, "#,##0")

        LabelVenteOfferte.Text = Format(MontantTotalDesVenteDesGratuite, "#,##0")

        Dim type_salle_chambre As String = "salle"

        'PERMET DE DTERMINER LE MONTANT TOTAL DE VENTES EN SALLE
        MontantTotalDesVenteEvenement = determinonsLeMontantTotalDesVentesPourLesEvenement(GlobalVariable.DateDeTravail, type_salle_chambre)

        'Dim aDejaCLoture As Boolean = aDejaClotureLeShift(GlobalVariable.DateDeTravail)

        'If aDejaCLoture Then
        'MontantTotalDesVenteEvenement = 0
        'End If

        LabelVenteEvent.Text = Format(MontantTotalDesVenteEvenement, "#,##0")
        MontantTotalDesVente = MontantTotalDesVenteDuComptoire + MontantTotalDesVenteDesEnChambres + MontantTotalDesVenteDesVersCompte + MontantTotalDesVenteDesGratuite + MontantTotalDesVenteEvenement
        GunaTextBoxTotalDesVentesJournaliere.Text = Format(MontantTotalDesVente, "#,##0")

        '--------------------------------------------------------------------------------------------------------
        Dim getUserQuery01 = "SELECT * FROM ligne_facture_gratuite, reserve_conf WHERE CODE_UTILISATEUR_CREA = @CODE_CAISSIER AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT AND ligne_facture_gratuite.CODE_RESERVATION =  reserve_conf.CODE_RESERVATION ORDER BY DATE_FACTURE DESC"

        Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

        command01.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        command01.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT
        Dim adapter01 As New MySqlDataAdapter

        Dim dt01 As New DataTable()

        adapter01.SelectCommand = command01
        adapter01.Fill(dt01)

        If dt01.Rows.Count > 0 Then

            For j = 0 To dt01.Rows.Count - 1
                If Not Trim(dt01.Rows(j)("CODE_RESERVATION")) = "-" Then
                    MontantTotalDesVenteDesGratuiteEnChambre += dt01.Rows(j)("MONTANT_TTC")
                End If
            Next

        End If

        LabelOffresEnChambre.Text = Format(MontantTotalDesVenteDesGratuiteEnChambre, "#,##0")

        '--------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub GunaButtonSaveFacturation_Click(sender As Object, e As EventArgs) Handles GunaButtonSaveFacturation.Click

        Me.Cursor = Cursors.WaitCursor

        Dim CODE_FACTURE_OLD As String = GunaTextBoxNumfacture.Text

        Dim OLD_MONTANT_TTC As Double = GunaTextBoxMontantTTCGeneral.Text
        'la caisse doit etre ouverte avant toute facturation

        Dim ETAT_CAISSE As Integer = 0

        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

        Dim CODE_CAISSE As String = ""

        Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

        Dim possedeCaisse As Boolean = False

        Dim CODE_RESERVATION As String = GunaTextBoxNumReservation.Text

        'GESTION DES IMPRESSIONS APRES TOUS LES TRAITEMENTS
        Dim dt As DataGridView
        Dim NOM_CLIENT As String = ""
        Dim NUM_FACTURE As String = ""
        Dim CHAMBRE As String = ""
        Dim BLOC_A_REGLER As String = ""

        Dim imprimerCommandeEnChambre As Boolean = False
        Dim imprimerCommandeComptoir As Boolean = False

        dt = GunaDataGridViewLigneFacture
        'If CAISSE_UTILISATEUR.Rows.Count > 0 Then

        'End If

        If CAISSE_UTILISATEUR.Rows.Count <= 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Cash In Management"
                languageMessage = "You can't cash in !!"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Gestion de Caisse"
                languageMessage = "Vous n'avez pas de caisse !!"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            ETAT_CAISSE = CAISSE_UTILISATEUR.Rows(0)("ETAT_CAISSE")

            If ETAT_CAISSE = 0 Then

                Dim Nomclient As String = GunaTextBoxNom_Prenom.Text
                Dim Codeclient As String = GunaTextBoxCodeClient.Text

                GunaTextBoxNom_Prenom.Text = Nomclient
                GunaTextBoxCodeClient.Text = Codeclient

                Dim dialog As DialogResult

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Cash Register Management"
                    languageMessage = "Open your Cash Register !!"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Gestion de Caisse"
                    languageMessage = "Bien vouloir ouvrir votre caisse !! "
                End If

                dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                If dialog = DialogResult.No Then
                    'e.Cancel = True
                Else

                    'DEMANDE DE MOT DE PASSE AVANT DE PERMETTRE L'OUVERTURE DE CAISSE

                    GlobalVariable.fenetreDouvervetureDeCaisse = "bar"

                    passwordVerifivationForm.Close()

                    passwordVerifivationForm.Show()
                    passwordVerifivationForm.TopMost = True

                End If

            Else

                If Trim(GunaTextBoxNom_Prenom.Text) = "" Then
                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageTitle = "Billing saving"
                        languageMessage = "Unable to save because no customer " & Chr(13) & " is associated with the billing!!"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageTitle = "Enregsitrement de facture"
                        languageMessage = "Impossible d'enregistrer car aucun client" & Chr(13) & "n'est associé à la facturation!!"
                    End If
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    GunaButtonSaveFacturation.Visible = False

                    If GunaButtonSaveFacturation.Text = "Régler" Or GunaButtonSaveFacturation.Text = "Pay" Then

                        'CLIENT COMPTOIRE, COMPTANT OU PAYMASTER

                        GlobalVariable.typeDeClientAFacturer = "comptoir"

                        If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                            GlobalVariable.blocNoteARegler = GunaComboBoxListeDesComandes.SelectedValue.ToString
                            GlobalVariable.codeClientDevantRegler = GunaTextBoxCodeClient.Text

                        End If

                        ReglementForm.Close()
                        ReglementForm.Show()

                        ReglementForm.GunaTextBoxNumFacture.Text = GunaTextBoxNumfacture.Text
                        ReglementForm.GunaLabelBlocNoteARegler.Text = GunaComboBoxListeDesComandes.SelectedValue.ToString

                        ReglementForm.BringToFront()
                        ReglementForm.TopMost = True

                        GlobalVariable.ouvertureDelaFenetreDeReglementApArtirDu = "bar"

                    ElseIf Trim(GunaButtonSaveFacturation.Text) = "Enregistrer" Or GunaButtonSaveFacturation.Text = "Clôturer" Or Trim(GunaButtonSaveFacturation.Text) = "Save" Or GunaButtonSaveFacturation.Text = "Close" Then

                        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                            If Not GunaComboBoxListeDesComandes.SelectedValue.ToString Is Nothing Then

                                GlobalVariable.blocNoteARegler = GunaComboBoxListeDesComandes.SelectedValue.ToString

                                GunaComboBoxListeDesComandes.SelectedValue = GlobalVariable.blocNoteARegler

                            End If

                        End If

                        'EN CHAMBRE
                        Dim facturation As New LigneFacture()

                        If Trim(GunaButtonSaveFacturation.Text) = "Enregistrer" Or Trim(GunaButtonSaveFacturation.Text) = "Save" Then

                            If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then

                                'LES ARTICLES ASSOCIE A UNE FICHE TECHNIQUE SERONT TRANSFERE LORS DE LA MIGRATION DE TEMP VERS LIGNE FACTURE
                                facturation.MigrationDeLigneFatureTempVersLigneFactureEnChambre(CODE_RESERVATION)

                                Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION)

                                Dim NUMERO_BLOC_NOTE As String = GunaComboBoxListeDesComandes.SelectedValue.ToString
                                Dim MONTANT_ENCAISSEMENT As Double = Double.Parse(GunaTextBoxMontantTTCGeneral.Text)
                                Functions.updateOfFields("ligne_facture_bloc_note", "MONTANT_ENCAISSEMENT", MONTANT_ENCAISSEMENT, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 1)

                            End If

                            If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                                Dim NUMERO_BLOC_NOTE As String = GunaComboBoxListeDesComandes.SelectedValue.ToString

                                Functions.updateEtatBlocNOteEnChambre(NUMERO_BLOC_NOTE, GunaTextBoxNumReservation.Text, 2)

                            End If

                            imprimerCommandeEnChambre = True

                            NOM_CLIENT = GunaTextBoxNom_Prenom.Text
                            NUM_FACTURE = GunaTextBoxNumfacture.Text
                            CHAMBRE = TB_RoomNo.Text

                            'Impression.commande(GunaDataGridViewLigneFacture, GunaTextBoxNom_Prenom.Text, GunaTextBoxNumfacture.Text, TB_RoomNo.Text)

                            GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")

                        ElseIf GunaButtonSaveFacturation.Text = "Clôturer" Or GunaButtonSaveFacturation.Text = "Close" Then

                            imprimerCommandeComptoir = True

                            NOM_CLIENT = GunaTextBoxNom_Prenom.Text
                            NUM_FACTURE = GunaTextBoxNumfacture.Text
                            CHAMBRE = TB_RoomNo.Text
                            BLOC_A_REGLER = GlobalVariable.blocNoteARegler

                            ''Impression.commande(GunaDataGridViewLigneFacture, GunaTextBoxNom_Prenom.Text, GunaTextBoxNumfacture.Text, TB_RoomNo.Text, GlobalVariable.blocNoteARegler)

                            'On enregistre definitivement les ligne du bloc note a la clôture

                            'LES ARTICLES ASSOCIE A UNE FICHE TECHNIQUE SERONT TRANSFERE LORS DE LA MIGRATION DE TEMP VERS LIGNE FACTURE
                            facturation.MigrationDeLigneFatureTempVersLigneFactureComptoire(GunaComboBoxListeDesComandes.SelectedValue.ToString)

                            'GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")

                            'Impression.commande(GunaDataGridViewLigneFacture, GunaTextBoxNom_Prenom.Text, TB_RoomNo.Text)

                            'mose a jour de l'état du bloc note
                            '0 = ouverte
                            '1 = fermée
                            '2 = réglée

                            Dim ETAT_BLOC_NOTE As Integer = 1
                            'On met ajour l'etat du bloc note pour qu'on ne puisse plus y ajouter des éléments
                            facturation.UpdateBlocNote(GunaComboBoxListeDesComandes.SelectedValue.ToString, ETAT_BLOC_NOTE)

                            Dim blocNoteEnCours As DataTable = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                            If blocNoteEnCours.Rows.Count > 0 Then

                                If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then

                                    If GlobalVariable.actualLanguageValue = 0 Then
                                        GunaButtonSaveFacturation.Text = "Close"
                                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                        GunaButtonSaveFacturation.Text = "Clôturer"

                                    End If

                                ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then

                                    If GlobalVariable.actualLanguageValue = 0 Then
                                        GunaButtonSaveFacturation.Text = "Pay"

                                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                        GunaButtonSaveFacturation.Text = "Régler"
                                    End If

                                Else

                                    'GunaButtonSaveFacturation.Visible = False

                                End If

                                Dim ClientDevantRegler As DataTable = Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT")

                                If ClientDevantRegler.Rows.Count > 0 Then
                                    GunaTextBoxCodeClient.Text = ClientDevantRegler.Rows(0)("CODE_CLIENT") 'Code client
                                    GunaTextBoxNom_Prenom.Text = ClientDevantRegler.Rows(0)("NOM_PRENOM") 'Nom du client
                                End If

                            End If

                        End If

                        'On charge l'ensemble des lignes factures créer dans la facture correspondate

                        Dim MontantHTGeneral As Double = 0
                        Dim MontantTTCGeneral As Double = 0

                        Dim FacturationLineList As DataTable = Functions.getElementByCode(GunaTextBoxNumfacture.Text, "ligne_facture_temp", "CODE_FACTURE")

                        If FacturationLineList.Rows.Count > 0 Then

                            For i = 0 To FacturationLineList.Rows.Count - 1
                                MontantHTGeneral = MontantHTGeneral + FacturationLineList.Rows(i)("MONTANT_HT")
                                MontantTTCGeneral = MontantTTCGeneral + FacturationLineList.Rows(i)("MONTANT_TTC")
                            Next

                        End If

                        'We have to update Account: compte at DEBIT
                        Dim compte As New Compte()
                        Dim compteClient As DataTable

                        'Obtained when we validate the field used to search a client
                        Dim CODE_CLIENT As String = GunaTextBoxCodeClient.Text

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

                                If GlobalVariable.actualLanguageValue = 0 Then
                                    SENS_DU_SOLDE = "Credit"
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    SENS_DU_SOLDE = "Créditeur"
                                End If

                            ElseIf 0 > SOLDE_COMPTE Then


                                If GlobalVariable.actualLanguageValue = 0 Then
                                    SENS_DU_SOLDE = "Debtor"
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    SENS_DU_SOLDE = "Debiteur"
                                End If

                            Else

                                If GlobalVariable.actualLanguageValue = 0 Then
                                    SENS_DU_SOLDE = "equilibrate"
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    SENS_DU_SOLDE = "equilibre"
                                End If

                            End If

                            'On insère le montant de la facture au debit
                            'compte.updateCompteAuDebit(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, SOLDE_COMPTE, SENS_DU_SOLDE)

                        End If

                        'MISE A JOURS DES INFORMATIONS DE LA MAINCOURANTE

                        'MISE A JOUR DU SOLDE DU CLIENT ON DOIT PRENDRE EN COMPTE LE FAIT CLIENT COMPTOIRE OU EN CHAMBRE
                        Dim reservation As New Reservation()

                        'Supression de ligne lié a la facture dans ligne_facture_temp
                        If GunaButtonSaveFacturation.Text = "Enregistrer" Or GunaButtonSaveFacturation.Text = "Save" Then
                            Functions.DeleteElementByCode(GunaTextBoxNumReservation.Text, "ligne_facture_temp", "CODE_RESERVATION")
                            'GunaDataGridViewLigneFacture.Columns.Clear()
                        End If

                    End If

                    'GunaTextBoxSoldeClient.Text = 0
                    GunaTextBoxTVARecap.Text = 0
                    GunaTextBoxMontantTTCGeneral.Text = 0

                    'Determining wether or not to save a facturation
                    If GlobalVariable.checkInFacturation Then
                        DisplaySavingButton()
                    Else
                        'REPOSISIONNEMENT DES ELEMENTS D'UN BLOC NOTE
                        If GlobalVariable.typeDeClientAFacturer = "comptoir" Or GlobalVariable.typeDeClientAFacturer = "" Then

                            Dim blocNoteActuel As DataTable

                            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then

                                blocNoteActuel = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                                If blocNoteActuel.Rows.Count > 0 Then

                                    GunaTextBoxNumfacture.Text = blocNoteActuel.Rows(0)("CODE_FACTURE")
                                    GunaTextBoxCodeClient.Text = blocNoteActuel.Rows(0)("CODE_CLIENT")

                                    If Functions.getElementByCode(blocNoteActuel.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT").Rows.Count > 0 Then
                                        GunaTextBoxNom_Prenom.Text = Functions.getElementByCode(blocNoteActuel.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT").Rows(0)("NOM_PRENOM")
                                    End If

                                Else

                                    'GunaDataGridViewLigneFacture.Columns.Clear()

                                End If

                            End If

                        End If

                    End If

                    'MISE AJOUR DU SOLDE DE LA RESERVATION APRES FACTURATION

                    'If Not GlobalVariable.typeDeClientAFacturer = "en chambre" Then

                    If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then

                        Dim reservation As New Reservation()
                        'reservation.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reservation", GunaLabelSolde.Text)
                        Dim updatedSolde As Double = Functions.SituationDeReservation(CODE_RESERVATION)

                        'If Functions.getElementByCode(CODE_RESERVATION, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                        If Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION").Rows.Count > 0 Then
                            reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", updatedSolde)
                        End If

                    End If

                    'Facturation calculator
                    FacturationKeyInformation()

                    'DisplaySavingButton()

                    GunaDataGridViewClient.Visible = False

                    If imprimerCommandeComptoir Then
                        Impression.commandeImpression(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE, BLOC_A_REGLER)
                    End If

                    manualRefresh()

                    If imprimerCommandeEnChambre Then
                        Impression.commandeImpression(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE)
                    End If

                    If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then
                        GunaDataGridViewLigneFacture.DataSource = Nothing

                        If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                            GunaComboBoxListeDesComandes.DataSource = Nothing
                        End If

                    End If

                End If

            End If

            GlobalVariable.quantite_conso = 0

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Dim i As Integer = 0

    Public Sub manualRefresh()

        Me.Cursor = Cursors.WaitCursor

        resumeDesVentesDuJours(CDate(GlobalVariable.DateDeTravail).ToShortDateString)

        'Solde du client comptoir, en chambre ou paymaster

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Then

            If Not Trim(GunaTextBoxNumReservation.Text).Equals("") Then

                If GlobalVariable.typeDeClientAFacturer = "en chambre" Then
                    GunaTextBoxSoldeClient.Text = Format(Functions.SituationDeReservation(GunaTextBoxNumReservation.Text), "#,##0")
                Else
                    GunaTextBoxSituationEvents.Text = Format(Functions.SituationDeReservation(GunaTextBoxNumReservation.Text), "#,##0")
                End If

                If GlobalVariable.typeDeClientAFacturer = "evenement" Then
                    AutoLoadEventListeVisualisation()
                End If

            End If

        End If

        'GESTION DES NOTIFICATIONS

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then
            GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
        Else

        End If

        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            AutoLoadOfBlocNote()

            BlocNotesVisualisation()

            '------------------------------------------------------------------------
            Dim Caisse As New Caisse()

            Dim ETAT_BLOC_NOTE As Integer = 0

            Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
            Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            'Commande non clôturée
            Dim ligneFactureBlocNote As DataTable = Caisse.AutoLoadBlocNote(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

            'Commande clôturée
            ETAT_BLOC_NOTE = 1

            Dim ligneFactureBlocNote1 As DataTable = Caisse.AutoLoadBlocNote(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

            ligneFactureBlocNote.Merge(ligneFactureBlocNote1)

            'If Not GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
            GunaComboBoxListeDesComandes.DataSource = Nothing
            'End If

            If ligneFactureBlocNote.Rows.Count > 0 Then

                GunaComboBoxListeDesComandes.DataSource = ligneFactureBlocNote
                GunaComboBoxListeDesComandes.ValueMember = "NUMERO_BLOC_NOTE"
                GunaComboBoxListeDesComandes.DisplayMember = "NUMERO_BLOC_NOTE"

                If Not Trim(GlobalVariable.blocNoteARegler).Equals("") Then
                    GunaComboBoxListeDesComandes.SelectedValue = GlobalVariable.blocNoteARegler
                End If

            Else
                'klg
                'GunaDataGridViewLigneFacture.Columns.Clear()
                'GunaDataGridViewLigneFacture.DataSource = Nothing
            End If

            '------------------------------------------------------------------------
        End If

        OutPutLigneFacture()

        DisplaySavingButton()

        SituationDeCaisseJournaliere()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonArricherReservation_Click(sender As Object, e As EventArgs) Handles GunaButtonArricherBlocNotes.Click
        listeDesblocNoteSurUnePeriode()
    End Sub

    Private Sub listeDesblocNoteSurUnePeriode()

        Dim caisse As New Caisse()

        Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim blocNoteSurUnePeriode As DataTable

        Dim ETAT_NOTE As String = ""

        blocNoteSurUnePeriode = caisse.blocNOteSurUnePeriode(GunaDateTimePickerParDateDebut.Value, GunaDateTimePickerParDateFin.Value)

        If blocNoteSurUnePeriode.Rows.Count > 0 Then

            GunaDataGridViewBlocNote.Rows.Clear()

            Dim STATUT As String = ""

            Dim montantTotalDesBlocNotes As Double = 0

            GunaDataGridViewBlocNote.Columns.Clear()

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewBlocNote.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNote.Columns.Add("SALE AMOUNT", "SALE AMOUNT")
                GunaDataGridViewBlocNote.Columns.Add("STATUS", "STATUS")

            Else

                GunaDataGridViewBlocNote.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
                GunaDataGridViewBlocNote.Columns.Add("MONTANT VENDU", "MONTANT VENDU")
                GunaDataGridViewBlocNote.Columns.Add("STATUT", "STATUT")

            End If

            For i = 0 To blocNoteSurUnePeriode.Rows.Count - 1

                If GlobalVariable.actualLanguageValue = 0 Then

                    ETAT_NOTE = Functions.etatNoteBlocNote(blocNoteSurUnePeriode.Rows(i)("STATE"))
                    GunaDataGridViewBlocNote.Rows.Add(blocNoteSurUnePeriode.Rows(i)("RECEIPT NUMBER"), Format(blocNoteSurUnePeriode.Rows(i)("AMOUNT"), "#,##0"), ETAT_NOTE)
                    montantTotalDesBlocNotes += blocNoteSurUnePeriode.Rows(i)("AMOUNT")

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    ETAT_NOTE = Functions.etatNoteBlocNote(blocNoteSurUnePeriode.Rows(i)("ETAT"))
                    GunaDataGridViewBlocNote.Rows.Add(blocNoteSurUnePeriode.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteSurUnePeriode.Rows(i)("MONTANT"), "#,##0"), ETAT_NOTE)
                    montantTotalDesBlocNotes += blocNoteSurUnePeriode.Rows(i)("MONTANT")

                End If

            Next

            GunaTextBoxNombreDeBlocNote.Text = GunaDataGridViewBlocNote.Rows.Count
            GunaTextBoxTotalDesBlocNotes.Text = Format(montantTotalDesBlocNotes, "#,##0")

        Else
            GunaDataGridViewBlocNote.Rows.Clear()
        End If

    End Sub

    Private Sub GunaTextBoxSearchBlocNote_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxSearchBlocNote.TextChanged
        'Dim query As String = "SELECT `NUMERO_BLOC_NOTE` AS 'NUMERO BLOC NOTE', `MONTANT_BLOC_NOTE` AS MONTANT, ETAT_BLOC_NOTE AS ETAT FROM `ligne_facture_bloc_note` WHERE NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBoxSearchBlocNote.Text) & "%' AND CODE_CAISSIER=@CODE_CAISSIER AND ETAT_BLOC_NOTE = 1 OR NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBoxSearchBlocNote.Text) & "%' AND CODE_CAISSIER=@CODE_CAISSIER AND ETAT_BLOC_NOTE = 2 "

        If Not Trim(GunaTextBoxSearchBlocNote.Text).Equals("") Then

            Dim DateDebut As Date = GunaDateTimePickerParDateDebut.Value
            Dim DateFin As Date = GunaDateTimePickerParDateFin.Value
            Dim query As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                query = "SELECT `NUMERO_BLOC_NOTE` AS 'RECEIPT CODE', `MONTANT_BLOC_NOTE` AS AMOUNT, ETAT_FACTURE AS STATE FROM `ligne_facture_bloc_note` WHERE NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBoxSearchBlocNote.Text) & "%' AND DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "'"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                query = "SELECT `NUMERO_BLOC_NOTE` AS 'NUMERO BLOC NOTE', `MONTANT_BLOC_NOTE` AS MONTANT, ETAT_FACTURE AS ETAT FROM `ligne_facture_bloc_note` WHERE NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBoxSearchBlocNote.Text) & "%' AND DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "'"
            End If

            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
            command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim adapter As New MySqlDataAdapter(command)
            Dim blocNoteSurUnePeriode As New DataTable()

            adapter.Fill(blocNoteSurUnePeriode)

            Dim ETAT_NOTE As String = ""

            If (blocNoteSurUnePeriode.Rows.Count > 0) Then

                GunaDataGridViewBlocNote.Rows.Clear()

                For i = 0 To blocNoteSurUnePeriode.Rows.Count - 1

                    If GlobalVariable.actualLanguageValue = 0 Then
                        ETAT_NOTE = Functions.etatNoteBlocNote(blocNoteSurUnePeriode.Rows(i)("STATE"))
                        GunaDataGridViewBlocNote.Rows.Add(blocNoteSurUnePeriode.Rows(i)("RECEIPT CODE"), Format(blocNoteSurUnePeriode.Rows(i)("AMOUNT"), "#,##0"), ETAT_NOTE)
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        ETAT_NOTE = Functions.etatNoteBlocNote(blocNoteSurUnePeriode.Rows(i)("ETAT"))
                        GunaDataGridViewBlocNote.Rows.Add(blocNoteSurUnePeriode.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteSurUnePeriode.Rows(i)("MONTANT"), "#,##0"), ETAT_NOTE)
                    End If

                Next

            Else
                GunaDataGridViewBlocNote.Rows.Clear()
            End If

        Else

            If GunaDataGridViewBlocNote.Rows.Count > 0 Then
                GunaDataGridViewBlocNote.Rows.Clear()
                listeDesblocNoteSurUnePeriode()
                GunaTextBoxNombreDeBlocNote.Text = GunaDataGridViewBlocNote.Rows.Count
            Else

            End If

            GunaDataGridViewBlocNote.Rows.Clear()

        End If

        If GunaDataGridViewBlocNote.Rows.Count > 0 Then
            GunaTextBoxNombreDeBlocNote.Text = GunaDataGridViewBlocNote.Rows.Count
        Else
            GunaTextBoxNombreDeBlocNote.Text = 0
        End If

    End Sub

    Private Sub listeDesLigneGestionBlocNOte(ByVal NUMERO_BLOC_NOTE As String)

        Dim caissier As New Caisse()

        GunaDataGridViewFolio3.Columns.Clear()

        Dim ligneBocNote As DataTable = caissier.LigneDunBlocNoteQuelconque(NUMERO_BLOC_NOTE)

        If ligneBocNote.Rows.Count > 0 Then
            GunaDataGridViewFolio3.DataSource = ligneBocNote
        Else
            'ON SELECTIONNE LES LIGNES PARTANT DU NUMERO DE RESERVATION DU BLOC NOTE

            Dim infoSupBlocNOte As New DataTable
            infoSupBlocNOte = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

            If infoSupBlocNOte.Rows.Count > 0 Then

                Dim CODE_RESERVATION As String = infoSupBlocNOte.Rows(0)("CODE_RESERVATION")

                ligneBocNote = caissier.LigneDunBlocNoteQuelconquePartantDuNumResa(CODE_RESERVATION, NUMERO_BLOC_NOTE)

                GunaDataGridViewFolio3.DataSource = ligneBocNote

            End If

        End If

        If ligneBocNote.Rows.Count > 0 Then

            GunaDataGridViewFolio3.Columns(2).DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewFolio3.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewFolio3.Columns(3).DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewFolio3.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewFolio3.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim totalMontantDuBlocNote As Double = 0

            For i = 0 To GunaDataGridViewFolio3.Rows.Count - 1

                If GlobalVariable.actualLanguageValue = 0 Then
                    totalMontantDuBlocNote += ligneBocNote.Rows(i)("TOTAL AMOUNT")
                Else
                    totalMontantDuBlocNote += ligneBocNote.Rows(i)("MONTANT TOTAL")
                End If

            Next

            GunaTextBoxTotalBlocNote.Text = Format(totalMontantDuBlocNote, "#,##0")

            GunaDataGridViewFolio3.Columns(4).Visible = False
            GunaDataGridViewFolio3.Columns(5).Visible = False

        End If

    End Sub

    Private Sub GunaDataGridViewBlocNote_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBlocNote.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim caissier As New Caisse()

            Dim row As DataGridViewRow

            row = GunaDataGridViewBlocNote.Rows(e.RowIndex)

            Dim NUMERO_BLOC_NOTE As String = Trim(row.Cells(0).Value.ToString)

            GunaTextBoxNumBlocNoteDet.Text = NUMERO_BLOC_NOTE

            listeDesLigneGestionBlocNOte(NUMERO_BLOC_NOTE)

            Dim reglementDuBlocNote As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "reglement", "NUMERO_BLOC_NOTE")

            GunaDataGridViewReglmentBlocNOtes.Rows.Clear()

            If reglementDuBlocNote.Rows.Count > 0 Then

                GunaDataGridViewReglmentBlocNOtes.Columns.Clear()

                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaDataGridViewReglmentBlocNOtes.Columns.Add("WORDING", "WORDING")
                    GunaDataGridViewReglmentBlocNOtes.Columns.Add("AMOUNT", "AMOUNT")
                    GunaDataGridViewReglmentBlocNOtes.Columns.Add("ID_REGLEMENT", "ID_REGLEMENT")
                Else
                    GunaDataGridViewReglmentBlocNOtes.Columns.Add("LIBELLE", "LIBELLE")
                    GunaDataGridViewReglmentBlocNOtes.Columns.Add("MONTANT", "MONTANT")
                    GunaDataGridViewReglmentBlocNOtes.Columns.Add("ID_REGLEMENT", "ID_REGLEMENT")
                End If

                For i = 0 To reglementDuBlocNote.Rows.Count - 1
                    GunaDataGridViewReglmentBlocNOtes.Rows.Add(reglementDuBlocNote.Rows(i)("REF_REGLEMENT"), reglementDuBlocNote.Rows(i)("MONTANT_VERSE"), reglementDuBlocNote.Rows(i)("ID_REGLEMENT"))
                Next

                GunaDataGridViewReglmentBlocNOtes.Columns(1).DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewReglmentBlocNOtes.Columns(2).Visible = False

            End If

        End If

    End Sub

    Public Sub traitementDeRecettePourTransfertVersLaCaissePrincipale(ByVal RECETTE_A_TRANSFERER As Double, ByVal CODE_CAISSIER As String)

        '1- GENERATION DE LA LIGNE DE TRANSACTION QUI SERA VISIBLE AU NIVEAU DE LA CAISSE PRINCIPALE SOUS FORME DE FACTURE

        'Variables for filling the facturation data
        Dim LIBELLE_FACTURE As String = ""
        Dim CODE_CLIENT As String = ""
        Dim NOM_CLIENT_FACTURE As String = ""

        Dim infoCaissier As DataTable = Functions.getElementByCode(CODE_CAISSIER, "utilisateurs", "CODE_UTILISATEUR")

        If infoCaissier.Rows.Count > 0 Then
            CODE_CLIENT = infoCaissier.Rows(0)("CODE_UTILISATEUR")
            NOM_CLIENT_FACTURE = infoCaissier.Rows(0)("NOM_UTILISATEUR")

            If GlobalVariable.actualLanguageValue = 0 Then

                LIBELLE_FACTURE = "CASH TRANSFERRED BY " & infoCaissier.Rows(0)("NOM_UTILISATEUR") & " ( " & infoCaissier.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] "

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                LIBELLE_FACTURE = "TRANSFERT DE RECETTE PAR " & infoCaissier.Rows(0)("NOM_UTILISATEUR") & " ( " & infoCaissier.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] "

            End If

        End If

        Dim CODE_FACTURE As String = Functions.GeneratingRandomCodeWithSpecifications("transfert_recette", "")

        Dim CODE_RESERVATION As String = ""

        Dim CODE_COMMANDE As String = "ENTREE DE RECETTE"
        Dim NUMERO_TABLE As String = ""
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
        'Dim LIBELLE_FACTURE As String = "TRANSFERT DE RECETTE PAR  " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " ( " & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] "

        Dim MONTANT_TRANSPORT As Double = 0
        Dim MONTANT_REMISE As Double = 0
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR") 'CODE_DU CAISSIER
        Dim CODE_UTILISATEUR_ANNULE As String = ""
        Dim CODE_UTILISATEUR_VALIDE As String = ""

        Dim MONTANT_AVANCE As Double = 0
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim facture As New Facture()

        'CODE_FACTURE = GunaTextBoxNumfacture.Text

        If facture.insertTransfertRecette(CODE_FACTURE, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT, TAXE, MONTANT_TTC, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, LIBELLE_FACTURE, MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE) Then

            ETAT_FACTURE = 1 ' BLOC NOTE PLUS PRIS EN COMPTE DANS LES VENTES DU JOURS ET AUSSI UTILISE POUR LES LIGNES DE FACTURE

            'ON MET A JOUR TOUTES LES LIGNES DE VENTE DU CAISSIER ACTUEL POUR LES VENTES EN CHAMBRES AU NIVEAU DU BAR PARTICULIEREMENT
            'PAR LA MEME OCCAISION ON INSERT LE CODE DE LA TRANSACTION DE VERSEMENT DANS LES LIGNES DE LIGNE_FACTURE ET REGLEMENTS
            Dim ligne_facture As New LigneFacture()

            ligne_facture.UpdateEtatLigneFacture(CODE_UTILISATEUR_CREA, ETAT_FACTURE, CODE_FACTURE)

        End If

    End Sub

    Private Sub GunaButtonFactures_Click(sender As Object, e As EventArgs) Handles GunaButtonFactures.Click

        ClientForm.Show()
        ClientForm.TopMost = True

        historiqueApartirDuCardex()

        ClientForm.TabControl1.SelectedIndex = 2
        ClientForm.TabControl2.SelectedIndex = 0

        GunaTextBoxCompteDebiteur.Text = ""
        GunaButtonFactures.Visible = False
        GunaTextBoxCompteDebiteur.Visible = False
        GunaTextBoxNomPrenom.Clear()
        GunaTextBoxRefClient.Clear()

    End Sub

    Public Sub historiqueApartirDuCardex()

        Dim INDICE_DE_COMPTE As Integer = 0

        ClientForm.AutoLoadBanque()

        ClientForm.GunaDateTimePickerDebutClientForm.Value = GlobalVariable.DateDeTravail
        ClientForm.GunaDateTimePickerFinClientForm.Value = GlobalVariable.DateDeTravail

        ClientForm.GunaComboBoxTypeDeFiltre.SelectedIndex = 1

        ClientForm.GunaTextBoxMontantVerse.Text = 0
        '---------------------------------------- CONTENT OF REGLEMENTFORM COMING FROM THE FRONTDESK ---------------------------------

        'We initialise the content of reglementForm with information coming from the frontdesk: Solde-SistuationClient-Reglement

        'Setting a value for the paiment mode on load
        ClientForm.GunaComboBoxModeReglementPratique.SelectedIndex = 0

        ClientForm.GunaComboBoxNatureOperation.SelectedIndex = 0

        Dim CodeClient As String = GunaTextBoxRefClient.Text
        ClientForm.GunaTextBoxCodeEntreprise.Text = GunaTextBoxRefClient.Text

        'On rempli la description du client pour des eventuelles modifications

        Dim client As DataTable = Functions.getElementByCode(CodeClient, "client", "CODE_CLIENT")

        If client.Rows.Count > 0 Then

            If True Then

                ClientForm.GunaTextBoxCodeClient.Text = client.Rows(0)("CODE_CLIENT")
                ClientForm.GunaTextBoxNomRaisonSociale.Text = client.Rows(0)("NOM_CLIENT")
                ClientForm.GunaTextBoxPrenom.Text = client.Rows(0)("PRENOMS")
                ClientForm.GunaTextBox12.Text = client.Rows(0)("ADRESSE")
                ClientForm.MaskedTextBoxTelephone.Text = client.Rows(0)("TELEPHONE")
                ClientForm.GunaDateTimePicker1.Value = client.Rows(0)("DATE_DE_NAISSANCE")
                ClientForm.GunaTextBox6.Text = client.Rows(0)("LIEU_DE_NAISSANCE")
                ClientForm.GunaTextBoxNomDeJeunneFille.Text = client.Rows(0)("NOM_JEUNE_FILLE")
                ClientForm.GunaTextBoxFax.Text = client.Rows(0)("FAX")
                ClientForm.GunaTextBoxEmail.Text = client.Rows(0)("EMAIL")
                ClientForm.GunaTextBoxNationalite.Text = client.Rows(0)("NATIONALITE")
                ClientForm.GunaComboBoxPays.SelectedValue = client.Rows(0)("PAYS_RESIDENCE")
                'GUnaTextBoxNumCompteReal.Text = client.Rows(0)("NUM_COMPTE_COLLECTIF")
                ClientForm.GunaComboBoxTypeClient.SelectedValue = client.Rows(0)("TYPE_CLIENT")
                ClientForm.GunaTextBoxSiteWeb.Text = client.Rows(0)("SITE_INTERNET")
                ClientForm.GunaTextBoxProfession.Text = client.Rows(0)("PROFESSION")
                ClientForm.GunaTextBoxCni.Text = client.Rows(0)("CNI")
                'GunaComboBoxVille.SelectedValue = client.Rows(0)("VILLE_DE_RESIDENCE")
                ClientForm.GunaTextBox5.Text = client.Rows(0)("VILLE_DE_RESIDENCE")
                ClientForm.GunaComboBoxModeReglement.SelectedItem = client.Rows(0)("CODE_MODE_PAIEMENT")
                ClientForm.GunaComboBoxModeTransport.SelectedItem = client.Rows(0)("MODE_TRANSPORT")
                ClientForm.GunaTextBoxNumVehicule.Text = client.Rows(0)("NUM_VEHICULE")

                ClientForm.GunaTextBoxMarqueVehicule.Text = client.Rows(0)("MARQUE_VEHICULE")

                ClientForm.GunaTextBoxEntreprise.Text = client.Rows(0)("CODE_ENTREPRISE")

                'LE NUMERO DE COMPTE N'EXISTE PAS DONC NUMERO DE COMPTE PROVIENT DES INFOS DU CLIENT
                ClientForm.GUnaTextBoxNumCompteReal.Text = client.Rows(0)("NUM_COMPTE")

                'ATTRIBUTION DES INFORMATION DE COMPTE FINANCE

            End If

            Dim compte As DataTable = Functions.getElementByCode(ClientForm.GunaTextBoxCodeClient.Text, "compte", "CODE_CLIENT")

            If compte.Rows.Count > 0 Then

                If Not Trim(compte.Rows(0)("NUMERO_COMPTE")) = "" Then
                    'LE NUMERO DE COMPTE EXISTE
                    ClientForm.GUnaTextBoxNumCompteReal.Text = Trim(compte.Rows(0)("NUMERO_COMPTE")) ' NUMERO DE COMPTE
                Else
                    ClientForm.GUnaTextBoxNumCompteReal.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", INDICE_DE_COMPTE))
                End If

                ClientForm.GunaTextBoxIntituleDeCompte.Text = Trim(compte.Rows(0)("INTITULE")) ' INTITULE DE COMPTE

                ClientForm.GunaTextBoxPersonneAContacter.Text = Trim(compte.Rows(0)("PERSONNE_A_CONTACTER")) ' INTITULE DE COMPTE
                ClientForm.GunaTextBoxContactPourPaiement.Text = Trim(compte.Rows(0)("CONTACT_PAIEMENT")) ' INTITULE DE COMPTE
                ClientForm.GunaTextBoxAdresseDeFacturation.Text = Trim(compte.Rows(0)("ADRESSE_DE_FACTURATION")) ' INTITULE DE COMPTE

                If compte.Rows(0)("PLAFONDS_DU_COMPTE") >= 0 Then
                    ClientForm.GunaTextBoxMontantPlafondsDuCompte.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0.00")
                Else
                    ClientForm.GunaTextBoxMontantPlafondsDuCompte.Text = 0
                End If

                If compte.Rows(0)("DELAI_DE_PAIEMENT") >= 0 Then
                    ClientForm.NumericUpDownDelaiDePaiement.Text = Trim(compte.Rows(0)("DELAI_DE_PAIEMENT"))
                Else
                    ClientForm.NumericUpDownDelaiDePaiement.Text = 0
                End If

                If compte.Rows(0)("ETAT_DU_COMPTE") = 1 Then
                    ClientForm.GunaCheckBoxActivationDesactivationDuCompte.Checked = True
                Else
                    ClientForm.GunaCheckBoxActivationDesactivationDuCompte.Checked = False
                End If

            Else

                ClientForm.GUnaTextBoxNumCompteReal.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", INDICE_DE_COMPTE))

            End If

            '---
            '-----------------------------------------------------------------------------------------------------------------------------------
            If client.Rows.Count > 0 Then

                '----------------------------------------------------------

                If Not Trim(ClientForm.GunaTextBoxEntreprise.Text).Equals("") Then

                    Dim infoSupEntreprise As DataTable = Functions.getElementByCode(ClientForm.GunaTextBoxEntreprise.Text, "client", "CODE_CLIENT")
                    If infoSupEntreprise.Rows.Count > 0 Then
                        ClientForm.GunaTextBoxCompanyName.Text = infoSupEntreprise.Rows(0)("NOM_PRENOM")
                    Else
                        ClientForm.GunaTextBoxEntreprise.Clear()
                    End If

                End If


                Functions.AffectingTitleToAForm(ClientForm.GunaTextBoxNomRaisonSociale.Text + " " + ClientForm.GunaTextBoxPrenom.Text, ClientForm.GunaLabelTitreForm)

                'AssignACompanyToClient()

                'ONT CHARGENT LES DONNEES DES TARIF DU CLIENT

                Dim tarifs As New Tarifs

                ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Clear()

                If tarifs.SelectionDesForfaitsDuClient(client.Rows(0)("CODE_CLIENT")).Rows.Count > 0 Then
                    ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.DataSource = tarifs.SelectionDesForfaitsDuClient(client.Rows(0)("CODE_CLIENT"))
                End If

                If ClientForm.GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or ClientForm.GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or ClientForm.GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Or ClientForm.GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then

                    'Dim client As DataTable = Functions.getElementByCode(CodeClient, "client", "CODE_CLIENT")

                    If client.Rows.Count > 0 Then

                        ClientForm.GunaTextBoxNomRaisonSociale.Text = client.Rows(0)("NOM_PRENOM")

                        'Dim compte As DataTable = Functions.getElementByCode(Trim(CodeClient), "compte", "CODE_CLIENT")

                        If compte.Rows.Count > 0 Then

                            GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")

                            ClientForm.GunaTextBoxSoldeCompte.Text = Format(compte.Rows(0)("SOLDE_COMPTE"), "#,##0")
                            'GunaTextBoxPersonneAContacter.Text = compte.Rows(0)("PERSONNE_A_CONTACTER")
                            'GunaTextBoxContactPaiement.Text = compte.Rows(0)("CONTACT_PAIEMENT")
                            'GunaTextBoxAdressePaiement.Text = compte.Rows(0)("ADRESSE_DE_FACTURATION")
                            'GunaTextBoxDelaiPaiement.Text = compte.Rows(0)("DELAI_DE_PAIEMENT")

                            'GunaTextBoxPlafonds.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0")

                        End If

                        Dim factures As DataTable = Functions.getElementByCode(CodeClient, "facture", "CODE_CLIENT")

                        If factures.Rows.Count > 0 Then

                            Dim ChiffresAffaire As Double = 0

                            For j = 0 To factures.Rows.Count - 1
                                ChiffresAffaire += factures.Rows(j)("MONTANT_TTC")
                            Next

                            ClientForm.GunaTextBoxChiffreAffaire.Text = Format(ChiffresAffaire, "#,##0")

                        End If

                        ClientForm.GunaTextBoxAPayer.Text = 0

                        ClientForm.GunaTextBoxSolde.Text = 0

                        ClientForm.GunaTextBoxMontantVerse.Text = 0

                        If ClientForm.GunaComboBoxNatureOperation.SelectedIndex >= 0 Then
                            ClientForm.GunaTextBoxReference.Text = ClientForm.GunaComboBoxNatureOperation.SelectedItem & " " & Trim(ClientForm.GunaTextBoxNomRaisonSociale.Text) & " " & Date.Now()
                        End If

                        ClientForm.situationDuClientEntreprise(CodeClient)

                    End If

                End If

            End If

            '-----------------------------------------------------------------------------------------------------------------------------------



            'ON rempli les entetes du datagrid des tarif pour éviterqu'il ne se répète
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.BringToFront()
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("ID_TARIF_PRIX", "ID")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("CODE_TARIF", "CODE APPLIQUE")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("TYPE_TARIF", "TYPE TARIF")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("CODE_TYPE", "CODE TYPE")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF_ENCOURS", "PRIX ENCOURS")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF1", "PRIX 1")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF2", "PRIX 2")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF3", "PRIX 3")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF4", "PRIX 4")
            ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF5", "PRIX 5")

            ClientForm.GunaButtonEnregistrerClient.Text = "Sauvegarder"

        End If

    End Sub

    Private Sub GunaTextBoxNomPrenom_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNomPrenom.TextChanged

        If Not Trim(GunaTextBoxNomPrenom.Text).Equals("") Then

            GunaDataGridViewClientMaison.Visible = True

            'Dim query As String = "SELECT NOM_CLIENT, EMAIL From client, compte WHERE NOM_CLIENT Like '%" & GunaTextBoxNomPrenom.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND client.CODE_CLIENT = compte.CODE_CLIENT AND ETAT_DU_COMPTE=@ETAT_DU_COMPTE"
            Dim query As String = "SELECT NOM_CLIENT, EMAIL, CODE_ELITE From client, compte WHERE 
            NOM_CLIENT LIKE '%" & GunaTextBoxNomPrenom.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND client.CODE_CLIENT = compte.CODE_CLIENT
            OR CODE_ELITE LIKE '%" & Trim(GunaTextBoxNomPrenom.Text) & "%' AND CODE_AGENCE=@CODE_AGENCE AND client.CODE_CLIENT = compte.CODE_CLIENT ORDER BY NOM_PRENOM ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
            command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = 1

            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaDataGridViewClientMaison.DataSource = table

            Else

                'query = "SELECT INTITULE, NUMERO_COMPTE From compte WHERE 
                'INTITULE LIKE '%" & GunaTextBoxNomPrenom.Text & "%'
                'Or NUMERO_COMPTE LIKE '%" & Trim(GunaTextBoxNomPrenom.Text) & "%' ORDER BY INTITULE ASC"

                'command = New MySqlCommand(query, GlobalVariable.connect)
                'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                'command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = 1

                'table = New DataTable
                'adapter = New MySqlDataAdapter(command)

                'adapter.Fill(table)

                'If (table.Rows.Count > 0) Then

                'GunaDataGridViewClientMaison.DataSource = table

                'Else

                'GunaDataGridViewClientMaison.Columns.Clear()
                'GunaDataGridViewClientMaison.Visible = False

                'End If

                GunaDataGridViewClientMaison.Columns.Clear()
                GunaDataGridViewClientMaison.Visible = False

            End If

        Else

            GunaDataGridViewClientMaison.Visible = False
            GunaTextBoxCompteDebiteur.Visible = False
            GunaButtonFactures.Visible = False
            GunaButtonCodeEliteDetails.Visible = False
            GunaTextBoxCodeElite.Text = ""
            GunaTextBoxRefClient.Text = ""

        End If

    End Sub

    Private Sub GunaDataGridViewClientMaison_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewClientMaison.CellClick

        If e.RowIndex >= 0 Then

            GunaDataGridViewClientMaison.Visible = False

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewClientMaison.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM client WHERE NOM_CLIENT = @NOM_CLIENT AND EMAIL=@EMAIL"
            Dim adapter As New MySqlDataAdapter

            Dim table As New DataTable()
            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@NOM_CLIENT", MySqlDbType.VarChar).Value = Trim(row.Cells("NOM_CLIENT").Value.ToString())
            command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = row.Cells("EMAIL").Value.ToString()

            adapter.SelectCommand = command
            adapter.Fill(table)

            Dim CODE_ELITE As String = ""

            If table.Rows.Count > 0 Then

                GunaTextBoxCompteDebiteur.Text = Trim(table.Rows(0)("NUM_COMPTE"))
                GunaTextBoxRefClient.Text = Trim(table.Rows(0)("CODE_CLIENT"))

                CODE_ELITE = Trim(table.Rows(0)("CODE_ELITE"))
                GunaTextBoxCodeElite.Text = Trim(table.Rows(0)("CODE_ELITE"))

                Dim CODE_CLIENT As String = Trim(table.Rows(0)("CODE_CLIENT"))

                Dim compte As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                If compte.Rows.Count > 0 Then

                    'If compte.Rows(0)("ETAT_DU_COMPTE") = 1 Then

                    If True Then
                        'COMPTE ACTIF

                        GunaTextBoxCompteDebiteur.Visible = True
                        GunaButtonFactures.Visible = True
                        GunaButtonCodeEliteDetails.Visible = False

                        Dim ETAT_DU_COMPTE As Double = 0

                        If Double.Parse(compte.Rows(0)("SOLDE_COMPTE")) < 0 Then
                            ETAT_DU_COMPTE = Double.Parse(compte.Rows(0)("PLAFONDS_DU_COMPTE")) - Math.Abs(Double.Parse(compte.Rows(0)("SOLDE_COMPTE")))
                        End If

                        If ETAT_DU_COMPTE >= 0 Then
                            'AU DESSUS  
                            GunaTextBoxCompteDebiteur.BaseColor = Color.Green
                        Else
                            'EN DESSOUS
                            GunaTextBoxCompteDebiteur.BaseColor = Color.Red
                        End If

                        GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")

                    End If

                Else
                    GunaTextBoxCompteDebiteur.Visible = False
                    GunaButtonFactures.Visible = False
                End If

                If Not CODE_ELITE.Equals("") Then

                    If CODE_ELITE.Contains(GunaTextBoxNomPrenom.Text) Then
                        If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then
                            AffichageDesIinformationsDuCLientFidel(CODE_ELITE, CODE_CLIENT)
                        End If
                    End If

                End If


                GunaTextBoxNomPrenom.Text = table.Rows(0)("NOM_PRENOM")

            Else
                GunaTextBoxNomPrenom.Clear()
                GunaButtonFactures.Visible = False
                GunaTextBoxCompteDebiteur.Visible = False
            End If

        End If

    End Sub

    Private Sub AffichageDesIinformationsDuCLientFidel(ByVal CODE_ELITE As String, ByVal CODE_CLIENT As String)

        GunaTextBoxCompteDebiteur.Visible = False
        GunaButtonFactures.Visible = False
        GunaButtonCodeEliteDetails.Visible = True

        discounStays = True

        Dim eliteClub As New ClubElite

        Dim dt As DataTable = eliteClub.infoDuCodeElite(CODE_ELITE)

        If dt.Rows.Count > 0 Then

            GunaTextBoxRemise.Text = dt.Rows(0)("REDUCTION_ACCORDEE")
            Dim VAEUR_DU_POINT As Double = 0
            VAEUR_DU_POINT = dt.Rows(0)("VAEUR_DU_POINT")
            Dim MONTANT_DES_POINTS As Double = 0
            Dim infoCodeClient As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_CLIENT, "club_elite_membre_client", "CODE_CLIENT_CARTE", CODE_ELITE, "ID_CARTE_ELITE")
            Dim POINTS As Double = 0

            If infoCodeClient.Rows.Count > 0 Then
                POINTS = infoCodeClient.Rows(0)("POINTS")
                MONTANT_DES_POINTS = VAEUR_DU_POINT * POINTS
            End If

            GunaButtonCodeEliteDetails.Text = POINTS & " Pts (" & Format(MONTANT_DES_POINTS, "#,##0") & " FCFA)"

        Else
            discounStays = False
        End If

    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click

        If GunaDataGridViewBlocNote.Rows.Count > 0 Then

            Dim i As Integer = 0

            Dim cashier As New Caisse()

            For Each row As DataGridViewRow In GunaDataGridViewBlocNote.SelectedRows

                Dim NUMERO_BLOC_NOTE As String = Trim(row.Cells(0).Value.ToString)
                Dim NOM_CLIENT As String = ""
                Dim NOM_SERVEUR As String = ""

                Dim blocNote As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If blocNote.Rows.Count > 0 Then

                    Dim ligneBlocNote As DataTable = cashier.LigneDunBlocNoteQuelconque(NUMERO_BLOC_NOTE)

                    Dim CODE_CLIENT As String = blocNote.Rows(0)("CODE_CLIENT")
                    Dim CODE_SERVEUR As String = blocNote.Rows(0)("CODE_CAISSIER")

                    Dim infoClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

                    If infoClient.Rows.Count > 0 Then
                        NOM_CLIENT = infoClient.Rows(0)("NOM_PRENOM")
                    End If

                    Dim infoUser As DataTable = Functions.getElementByCode(CODE_SERVEUR, "utilisateurs", "CODE_UTILISATEUR")

                    If infoUser.Rows.Count > 0 Then
                        NOM_SERVEUR = infoUser.Rows(0)("NOM_UTILISATEUR")
                    End If

                    If ligneBlocNote.Rows.Count > 0 Then
                        Impression.commandeGestionDesBlocNotes(ligneBlocNote, NOM_CLIENT, NOM_SERVEUR, NUMERO_BLOC_NOTE)
                    End If

                End If

            Next

        End If

    End Sub


    '----------------------------------------------------------------- DEBUT DE GESTION DES STOCKE -------------------------------------

    Public Sub autoLoadMagasinActuel()

        Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel

        Dim magasin As DataTable

        If Trim(CODE_MAGASIN).Equals("") Then
            magasin = Functions.allTableFieldsOrganised("magasin", "LIBELLE_MAGASIN")
        Else
            magasin = Functions.getElementByCode(CODE_MAGASIN, "magasin", "CODE_MAGASIN")
        End If


        If magasin.Rows.Count > 0 Then
            GunaComboBoxMagasinSource.DataSource = magasin
            GunaComboBoxMagasinSource.DisplayMember = "LIBELLE_MAGASIN"
            GunaComboBoxMagasinSource.ValueMember = "CODE_MAGASIN"
        End If

        If GunaComboBoxTypeTiers.SelectedIndex >= 0 Then
            GunaComboBoxTypeTiers.SelectedIndex = 0
        End If

        If GunaComboBoxTypeBordereau.SelectedIndex >= 0 Then
            GunaComboBoxTypeBordereau.SelectedIndex = 0
        End If

        GunaTextBoxTiers.Text = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        GunaTextBoxNomTiers.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

    End Sub

    Private Sub NewRequisition()

        Dim INDICE As String = ""

        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        Functions.DeleteElementOnTwoConditions(CODE_UTILISATEUR_CREA, "bordereau_ligne_temp", "CODE_USER", "CODE_AGENCE", CODE_AGENCE)

        GunaDataGridViewLigneArticleCommande.Columns.Clear()
        Functions.SiplifiedClearTextBox(Me)

        GunaComboBoxTypeTiers.SelectedIndex = 0
        GunaComboBoxTypeBordereau.SelectedIndex = 0

        GunaTextBoxTiers.Text = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        GunaTextBoxNomTiers.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Store Requisition" Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Market List" Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.list_du_marche Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Exceptionnal Exit" Then

            If GlobalVariable.actualLanguageValue = 0 Then

                If Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Store Requisition" Then
                    INDICE = "SR"
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Market List" Then
                    INDICE = "ML"
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Exceptionnal Exit" Then
                    INDICE = "ML"
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Exceptionnal out going" Then
                    INDICE = "ML"
                End If

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Then
                    INDICE = "BA"
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.list_du_marche Then
                    INDICE = "LM"
                ElseIf Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.sortie_exceptionnelle Then
                    INDICE = "SE"
                End If

            End If

            GunaTextBoxCodeBordereau.Text = Functions.GeneratingRandomCodeWithSpecifications("bordereaux", INDICE)

        End If

    End Sub

    Private Sub GunaButtonNouveau_Click(sender As Object, e As EventArgs) Handles GunaButtonNouveau.Click

        NewRequisition()

    End Sub

    Private Sub GunaTextBoxLibelleBordereau_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxLibelleBordereau.TextChanged

        If Trim(GunaTextBoxLibelleBordereau.Text) = "" Then
            GunaButtonEnregistrer.Visible = False
        Else
            GunaButtonEnregistrer.Visible = True
        End If

    End Sub

    Private Sub GunaTextBoxTiers_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTiers.TextChanged
        Dim query As String = ""

        'If Trim(GunaTextBoxTiers.Text) = "" Then

        'GunaDataGridViewTiers.Visible = False

        'GunaTextBoxNomTiers.Clear()

        'End If

        'query = "SELECT NOM_PERSONNEL, PRENOM_PERSONNEL FROM personnel WHERE NOM_PERSONNEL LIKE '%" & Trim(GunaTextBoxTiers.Text) & "%' OR PRENOM_PERSONNEL LIKE '%" & Trim(GunaTextBoxTiers.Text) & "' ORDER BY NOM_PERSONNEL ASC"

        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim Tiers As New DataTable()
        'adapter.Fill(Tiers)

        'If (Tiers.Rows.Count > 0) Then

        'GunaDataGridViewTiers.Visible = True

        'GunaDataGridViewTiers.DataSource = Tiers

        'End If

        'If Trim(GunaTextBoxTiers.Text) = "" Then
        'GunaDataGridViewTiers.Visible = False
        'End If

    End Sub

    Private Sub GunaTextBoxArticleAppro_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxArticleAppro.TextChanged

        GunaDataGridViewArticleAppro.Visible = True

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxArticleAppro.Text).Equals("") Then

            GunaComboBoxUniteComptageAppro.Items.Clear()

            GunaTextBoxGrandeUniteDeCompatge.Clear()

            GunaTextBoxEnStock.Text = 0
            GunaTextBoxConsoAppro.Text = 0
            GunaTextBoxSeuile.Text = 0

            GunaTextBoxCoutDuStock.Text = 0

            GunaTextBoxQuantite.Text = 1

            GunaDataGridViewArticleAppro.Visible = False
            GunaButtonAjouterLigne.Visible = False

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonAjouterLigne.Text = "Add"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterLigne.Text = "Ajouter"
            End If

        Else


            'Determining from which table to search for the articles
            'getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticleAppro.Text) & "%' AND METHODE_SUIVI_STOCK=@METHODE_SUIVI_STOCK ORDER BY DESIGNATION_FR ASC"

            'getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticleAppro.Text) & "%' AND CODE_FAMILLE IN ('BOISSONS') AND TYPE=@TYPE ORDER BY DESIGNATION_FR ASC"
            getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxArticleAppro.Text) & "%' AND METHODE_SUIVI_STOCK=@METHODE_SUIVI_STOCK ORDER BY DESIGNATION_FR ASC"

            Dim METHODE_SUIVI_STOCK As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                'èMETHODE_SUIVI_STOCK = "Simple tracking"
                METHODE_SUIVI_STOCK = "Suivi simple"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                METHODE_SUIVI_STOCK = "Suivi simple"
            End If

            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            Command.Parameters.Add("@METHODE_SUIVI_STOCK", MySqlDbType.VarChar).Value = METHODE_SUIVI_STOCK

            'Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"

            'EMPECHE L'AFFICHAGE DES ARTICLES A LA CARTE DONC LES PLATS

            Dim CARTE As Integer = 0
            Command.Parameters.Add("@CARTE", MySqlDbType.Int64).Value = CARTE

            adapter.SelectCommand = Command
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaDataGridViewArticleAppro.DataSource = table
            Else
                GunaDataGridViewArticleAppro.Columns.Clear()

                GunaDataGridViewArticleAppro.Visible = False
            End If

            If GunaTextBoxArticleAppro.Text = "" Then
                GunaDataGridViewArticleAppro.Visible = False
            End If

            'connect.closeConnection()


        End If

    End Sub

    Private Sub GunaDataGridViewArticleAppro_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewArticleAppro.CellClick

        GunaDataGridViewArticleAppro.Visible = False

        Dim econom As New Economat()
        'Le bouton permettant d'ajouter un article a la facture n'est visible que lorsque l'on est sure que le produit existe
        'il disparait de nouveau après ajout a la facture

        GunaButtonAjouterLigneAppro.Visible = True

        If e.RowIndex >= 0 Then

            GunaTextBoxQteAppro.Text = 1

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewArticleAppro.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE DESIGNATION_FR=@DESIGNATION_FR ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@DESIGNATION_FR", MySqlDbType.VarChar).Value = Trim(row.Cells("DESIGNATION_FR").Value.ToString)

            adapter.SelectCommand = command
            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then

                GunaTextBoxCodeArticleAppro.Text = Article.Rows(0)("CODE_ARTICLE")

                GunaTextBoxAchat.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") 'PRIX D'ACHAT 
                GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0") 'COUT MOYEN UNITAIRE PONDERE
                GunaTextBoxArticleAppro.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxSeuile.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")
                GunaTextBoxEnStock.Text = Article.Rows(0)("QUANTITE")
                GunaTextBoxCodeUniteComptage.Text = Article.Rows(0)("UNITE_COMPTAGE")

                GunaTextBoxCoutDuStock.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") ' PRIX UNITAIRE A L'ACHAT

                Dim unite As DataTable = Functions.getElementByCode(GunaTextBoxCodeUniteComptage.Text, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If unite.Rows.Count > 0 Then
                    gestionDesUnitesAppro(Article)
                End If

                GunaDataGridViewArticleAppro.Visible = False

                '--------------------------------------------------------------------------------------------------------------------

                If Integer.Parse(Article.Rows(0)("BOISSON")) = 1 Then

                    'ON RECUPERE LA CONSOMMATION
                    Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If Trim(Article.Rows(0)("CODE_CONSO")).Equals("") Then
                        conso = Nothing
                    End If

                    If conso.Rows.Count > 0 Then

                        Dim valeurConversion As Double = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                        '---------------------------------------------------------------------------------------------------------------------------------------------

                        Dim nombreDeBouteille As Double = 0
                        Dim nombreDeConso As Integer = 0

                        Dim nombreDeConsoTotal = Article.Rows(0)("QUANTITE")
                        Dim contenance As Double = Article.Rows(0)("CONTENANCE")

                        Dim nombreDeConsoDansUneBouteille As Integer = Math.Floor(contenance / valeurConversion)

                        If nombreDeConsoDansUneBouteille > 0 Then
                            nombreDeBouteille = Int(nombreDeConsoTotal / nombreDeConsoDansUneBouteille)
                            nombreDeConso = nombreDeConsoTotal Mod nombreDeConsoDansUneBouteille
                        End If

                        GunaTextBoxEnStock.Text = nombreDeBouteille
                        GunaTextBoxConsoAppro.Text = nombreDeConso

                        GunaTextBoxConsoAppro.Visible = True
                        LabelConso.Visible = True

                        '------------------------------------------------------------------------------------------------------------------------

                    Else
                        GunaTextBoxConsoAppro.Visible = False
                        LabelConso.Visible = False
                    End If

                Else
                    GunaComboBoxUniteOuConso.Visible = False
                End If


                '--------------------------------------------------------------------------------------------------------------------

            End If

        End If

    End Sub

    Public Sub gestionDesUnitesAppro(ByVal Article As DataTable, Optional ByVal uniteDuBarAppro As Integer = 0)

        GunaComboBoxUniteComptageAppro.Items.Clear()

        Dim UNITE_COMPTAGE As String = Article.Rows(0)("UNITE_COMPTAGE")

        Dim pasDeConso As Boolean = True

        Dim unite As DataTable = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

        If unite.Rows.Count > 0 Then

            If uniteDuBarAppro = 0 Then

                GunaComboBoxUniteComptageAppro.Items.Add(unite.Rows(0)("GRANDE_UNITE"))

                If unite.Rows(0)("VALEUR_NUMERIQUE") > 1 Then
                    GunaComboBoxUniteComptageAppro.Items.Add(unite.Rows(0)("PETITE_UNITE"))
                End If

                GunaComboBoxUniteComptageAppro.SelectedItem = unite.Rows(0)("GRANDE_UNITE")

            Else

                GunaComboBoxUniteOuConso.Items.Add(unite.Rows(0)("GRANDE_UNITE"))

                If unite.Rows(0)("VALEUR_NUMERIQUE") > 1 Then
                    GunaComboBoxUniteOuConso.Items.Add(unite.Rows(0)("PETITE_UNITE"))

                    GunaComboBoxUniteOuConso.SelectedItem = unite.Rows(0)("PETITE_UNITE")

                Else
                    GunaComboBoxUniteOuConso.SelectedItem = unite.Rows(0)("PETITE_UNITE")
                End If

                Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel

                '-------------------------------------------------------------------------
                If Integer.Parse(Article.Rows(0)("BOISSON")) = 1 Then

                    Dim econom As New Economat()

                    'Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                    Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
                    Dim CODE_ARTICLE As String = Article.Rows(0)("CODE_ARTICLE")
                    Dim QUANTITE_DU_MAGASIN_ACTUEL = econom.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(CODE_MAGASIN, CODE_ARTICLE)

                    Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

                    'ON RECUPERE LA CONSOMMATION
                    Dim conso As DataTable = Functions.getElementByCode(Trim(Article.Rows(0)("CODE_CONSO")), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    If conso.Rows.Count > 0 Then

                        Dim QUANTITE_CONSO = conso.Rows(0)("VALEUR_NUMERIQUE") 'VOLUME DE LA CONSOMMATION

                        GunaTextBoxQuantiteConso.Text = QUANTITE_CONSO

                        'GunaTextBoxMontantHT.Text = Format(Article.Rows(0)("PRIX_CONSO"), "#,##0")
                        ' GunaTextBoxMontantHT.Text = Format(prixUtilseConso(CODE_MAGASIN, Article), "#,##0")

                        '---------------------------------------------------------------------------------------------------------------------------------------------
                        ' 
                        If gestionDesStock = 0 Then
                            'AFFICHAGE DES QUANTITES DU GRAND MAGASIN
                            'STOCK = CONTENANCE * QTE / VALEUR_NUMERIQUE
                            GunaTextBoxStockMagasin.Text = Format((Article.Rows(0)("CONTENANCE") / conso.Rows(0)("VALEUR_NUMERIQUE")) * Article.Rows(0)("QUANTITE"), "#,##0.00")

                        ElseIf gestionDesStock = 1 Then
                            'AFFICHAGE DES QUANTITES DU PETIT MAGASIN
                            If QUANTITE_DU_MAGASIN_ACTUEL > 0 Then
                                GunaTextBoxStockMagasin.Text = Format((Article.Rows(0)("CONTENANCE") / conso.Rows(0)("VALEUR_NUMERIQUE")) * QUANTITE_DU_MAGASIN_ACTUEL, "#,##0")
                            Else
                                GunaTextBoxStockMagasin.Text = 0
                            End If

                        End If

                        '---------------------------------------------------------------------------------------------------------------------------------------------

                        If GlobalVariable.actualLanguageValue = 0 Then

                            GunaTextBoxArticle.Text = "SHOT " & Article.Rows(0)("DESIGNATION_FR")

                            GunaComboBoxUniteOuConso.Items.Add("SHOT")

                            GunaComboBoxUniteOuConso.SelectedItem = "SHOT"

                        ElseIf GlobalVariable.actualLanguageValue = 1 Then

                            GunaTextBoxArticle.Text = "CONSO " & Article.Rows(0)("DESIGNATION_FR")

                            GunaComboBoxUniteOuConso.Items.Add("CONSOMMATION")

                            GunaComboBoxUniteOuConso.SelectedItem = "CONSOMMATION"

                        End If

                    Else
                        'GunaComboBoxUniteOuConso.Visible = False
                    End If

                Else
                    'GunaComboBoxUniteOuConso.Visible = False
                End If

                '-------------------------------------------------------------------------

            End If

        End If

    End Sub

    Dim montantGlobalAchat As Double = 0
    Dim montantGlobalVente As Double = 0

    Private Sub GunaButtonAjouterLigneAppro_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigneAppro.Click

        Dim econom As New Economat()

        Dim CODE_BORDEREAUX As String = ""
        Dim UNITE_COMPTAGE As String = ""
        Dim DESIGNATION As String = ""
        Dim CODE_ARTICLE As String = ""
        Dim QUANTITE As Double = 0
        Dim EN_STOCK As Double = 0
        Dim DATE_PEREMPTION As Date
        Dim PRIX_VENTE As Double = 0
        Dim PRIX_ACHAT As Double = 0
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_USER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim ID_LIGNE_BORDEREAU As Integer
        Dim COUT_DU_STOCK As Double = 0

        Dim dateDatePeremption As Date = GlobalVariable.DateDeTravail

        'MISE A JOUR D'UN BORDEREAU

        If GunaButtonAjouterLigneAppro.Text = "Modifier" Or GunaButtonAjouterLigneAppro.Text = "Edit" Then

            ID_LIGNE_BORDEREAU = GunaTextBoxID_LIGNE_TEMP.Text

            CODE_BORDEREAUX = Trim(GunaTextBoxCodeBordereau.Text)
            'modification des élemenets ou ligne du bordereau

            '0' - On supprime l'ancienne occurence de l'article
            CODE_ARTICLE = GunaTextBoxCodeArticleAppro.Text

            GunaTextBoxTVARecap.Text = CODE_ARTICLE

            'On supprime les lignes existantes pour prendre en compte d'eventuelle mise a jour sans risque de doublons

            Functions.DeleteElementOnTwoConditions(ID_LIGNE_BORDEREAU, "bordereau_ligne_temp", "ID_LIGNE_BORDEREAU", "CODE_USER", CODE_USER)

            '2 on ajoute l'element nouvellement saisie dans bordereau_ligne_temp
            UNITE_COMPTAGE = GunaComboBoxUniteComptageAppro.SelectedItem
            CODE_BORDEREAUX = GunaTextBoxCodeBordereau.Text
            DESIGNATION = GunaTextBoxArticleAppro.Text
            CODE_ARTICLE = GunaTextBoxCodeArticleAppro.Text
            QUANTITE = Double.Parse(GunaTextBoxQteAppro.Text)
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

            GunaDataGridViewLigneArticleCommande.Columns.Clear()

            '3- ON RECHARGE LE CONTENU DU bordero_ligne_temp dans le datagrid
            GunaDataGridViewLigneArticleCommande.DataSource = econom.ligneBordereauTempElements(GlobalVariable.codeAgence, GlobalVariable.codeUser)

            'econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonAjouterLigneAppro.Text = "Add"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterLigneAppro.Text = "Ajouter"

            End If

        Else
            'Nouveau bordereau

            If Trim(GunaTextBoxPrixVente.Text) = "" Then
                GunaTextBoxPrixVente.Text = 1
            End If

            If Trim(GunaTextBoxQteAppro.Text) = "" Then
                GunaTextBoxQteAppro.Text = 1
            End If

            UNITE_COMPTAGE = GunaComboBoxUniteComptageAppro.SelectedItem
            CODE_BORDEREAUX = GunaTextBoxCodeBordereau.Text
            DESIGNATION = GunaTextBoxArticleAppro.Text
            CODE_ARTICLE = GunaTextBoxCodeArticleAppro.Text
            QUANTITE = Double.Parse(GunaTextBoxQteAppro.Text)
            EN_STOCK = Double.Parse(GunaTextBoxEnStock.Text)
            DATE_PEREMPTION = dateDatePeremption

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

            'GunaDataGridViewLigneArticleMagasin.Columns("PRIX UNITAIRE").Visible = False
            GunaDataGridViewLigneArticleCommande.Columns("SELLING PRICE").Visible = False

            'GunaDataGridViewLigneArticleMagasin.Columns("DATE DE PEREMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

            GunaDataGridViewLigneArticleCommande.Columns("DESIGNATION").ReadOnly = True
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

            'GunaDataGridViewLigneArticleMagasin.Columns("PRIX UNITAIRE").Visible = False
            GunaDataGridViewLigneArticleCommande.Columns("PRIX VENTE").Visible = False

            'GunaDataGridViewLigneArticleMagasin.Columns("DATE DE PEREMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewLigneArticleCommande.Columns("CODE ARTICLE").Visible = False

            GunaDataGridViewLigneArticleCommande.Columns("DESIGNATION").ReadOnly = True
            GunaDataGridViewLigneArticleCommande.Columns("PRIX TOTAL").ReadOnly = True
            GunaDataGridViewLigneArticleCommande.Columns("EN STOCK").ReadOnly = True

        End If

        GunaDataGridViewLigneArticleCommande.Columns("ID_LIGNE_BORDEREAU").Visible = False

        GunaTextBoxArticleAppro.Clear()
        GunaButtonAjouterLigneAppro.Visible = False

        montantGlobalAchat = 0
        montantGlobalVente = 0

        For i = 0 To GunaDataGridViewLigneArticleCommande.Rows.Count - 1

            If GlobalVariable.actualLanguageValue = 0 Then

                montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("TOTAL PRICE").Value
                montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("SELLING PRICE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                montantGlobalAchat += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX TOTAL").Value
                montantGlobalVente += GunaDataGridViewLigneArticleCommande.Rows(i).Cells("PRIX VENTE").Value * GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITE").Value

            End If

        Next

        GunaTextBoxMontantHTGeneralAppro.Text = Format(montantGlobalAchat, "#,##0")

        GunaTextBoxVenteAppro.Text = Format(montantGlobalVente, "#,##0")

        GunaTextBoxQteAppro.Text = 1
        GunaTextBoxPrixVente.Text = 0
        GunaTextBoxAchat.Text = 0

        montantGlobalAchat = 0
        montantGlobalVente = 0

        GunaTextBoxSeuile.Text = 0
        GunaTextBoxEnStock.Text = 0
        GunaTextBoxCoutDuStock.Text = 0

        GunaTextBoxGrandeUniteDeCompatge.Clear()

        GunaButtonAjouterLigneAppro.Visible = False

    End Sub

    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Me.Cursor = Cursors.WaitCursor

        GunaComboBoxTypeBordereau.Enabled = True

        GunaButtonAnnulerBordereau.Visible = False

        Dim econom As New Economat()

        If GunaButtonEnregistrer.Text = "Emettre" Or GunaButtonEnregistrer.Text = "Emit" Then

            If GunaComboBoxTypeBordereau.SelectedItem = GlobalVariable.bon_approvisi Or GunaComboBoxTypeBordereau.SelectedItem = "Store Requisition" Then

                Dim status As String = ""

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Slip"
                    languageMessage = "Slip successfully saved!"
                    status = "NOT VALIDATED"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Bordereau"
                    languageMessage = "Bordereau Enregistré avec succès!"
                    status = "NON VALIDE"
                End If

                InsertionDesElementsPourGestionDeStock(status)

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim CODE_USER As String = GlobalVariable.codeUser

        econom.freeligneBordereauTempElements(CODE_AGENCE, CODE_USER)

        'ENVOI DE NOTIFICATION EN DIRECTION DE L'ECONOMAT POUR AVISIER QUE LA DEMANDE A ETET ENVOYE
        Dim sendMessage As New User()

        Dim magasin As DataTable = Functions.getElementByCode(GlobalVariable.magasinActuel.ToUpper, "magasin", "CODE_MAGASIN")
        Dim nomMagasin As String = ""
        If magasin.Rows.Count > 0 Then
            nomMagasin = magasin.Rows(0)("LIBELLE_MAGASIN")
        End If

        Dim EXPEDITEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
        Dim DATE_ENVOI As Date = Date.Now()

        Dim CODE_PROFIL As String = "ECONOME"
        Dim MESSAGE As String = "VOUS AVEZ UNE DEMANDE D'APPROVISIONNEMENT DU MAGASIN : " & nomMagasin.ToUpper
        Dim OBJET As String = GlobalVariable.bon_approvisi

        If GlobalVariable.actualLanguageValue = 0 Then
            CODE_PROFIL = "ECONOME"
            MESSAGE = "YOU HAVE A STORE SUPPLY REQUEST : " & nomMagasin.ToUpper
            OBJET = "SUPPLY SLIP"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            CODE_PROFIL = "ECONOME"
            MESSAGE = "VOUS AVEZ UNE DEMANDE D'APPROVISIONNEMENT DU MAGASIN : " & nomMagasin.ToUpper
            OBJET = GlobalVariable.bon_approvisi
        End If

        sendMessage.sendMessage(CODE_PROFIL, MESSAGE, OBJET, DATE_ENVOI, EXPEDITEUR)

        GunaTextBoxVenteAppro.Clear()
        GunaDataGridViewLigneArticleCommande.Columns.Clear()

        Functions.SiplifiedClearTextBox(Me)

        Me.Cursor = Cursors.Default

    End Sub

    Dim MONTANT_PAYER As Double = 0

    Private Sub InsertionDesElementsPourGestionDeStock(ByVal ETAT_NOTE_DU_BORDEREAU As String, Optional ByVal ETAT_DU_BORDE As Integer = 0)

        Dim CODE_BORDEREAUX As String = ""

        Dim econom As New Economat()
        'Enregistrement des éléments du bordereau

        If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Store Requisition" Then
            CODE_BORDEREAUX = Functions.GeneratingRandomCodePanne("bordereaux", "BA")
        End If

        Dim ETAT_DU_BORDEREAU As Integer = 0
        Dim TYPE_BORDEREAUX As String = GunaComboBoxTypeBordereau.SelectedItem.ToString
        Dim REF_BORDEREAUX As String = ""
        Dim LIBELLE_BORDEREAUX As String = GunaTextBoxLibelleBordereau.Text
        Dim CODE_TIERS As String = GunaTextBoxTiers.Text
        Dim NON_TIERS As String = GunaTextBoxNomTiers.Text
        Dim DATE_BORDEREAU As Date = GlobalVariable.DateDeTravail
        Dim OBSERVATIONS As String = GunaTextBoxObservation.Text
        Dim MONTANT_HT As Double = Double.Parse(GunaTextBoxMontantHTGeneralAppro.Text) ' MONTANT VENTE
        Dim MONTANT_TAXE As Double = 0
        Dim MONTANT_TTC As Double = 0

        Dim VALIDE As String = "NON CONTROLE"
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim CODE_MAGASIN As String = ""
        Dim CODE_SOUS_MAGASIN As String = ""

        If GunaComboBoxMagasinSource.SelectedIndex >= 0 Then
            CODE_SOUS_MAGASIN = GunaComboBoxMagasinSource.SelectedValue.ToString()
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

        Dim COUT_DU_STOCK As Double = 0

        If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Save" Then
            CODE_BORDEREAUX = Trim(GunaTextBoxCodeBordereau.Text)
            ETAT_DU_BORDEREAU = ETAT_DU_BORDE
            VALIDE = ETAT_NOTE_DU_BORDEREAU
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

                If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Store Requisition" Then
                    CODE_LIGNE = Functions.GeneratingRandomCodePanne("bordereaux", "BA")
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


                Dim QUANTITE As Double = qte 'QUANTITE INITIAL implique la QUANTITE FINAL = QUANTITE INITIAL + QUANTITE EN MOVEMENT (ENTREE EN STOCK)

                Dim entre_en_stock As Double = 0

                If GlobalVariable.actualLanguageValue = 0 Then

                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("STOCK").Value.ToString, qte)
                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("QUANTITY").Value, entre_en_stock)

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    Double.TryParse(GunaDataGridViewLigneArticleCommande.Rows(i).Cells("EN STOCK").Value.ToString, qte)
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
                Dim NUM_SERIE_FIN As String = ""

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

                    Dim CODE_MOUVEMENT As String = Functions.GeneratingRandomCode("mouvement_stock", "MS")
                    Dim LIBELLE_MOUVEMENT As String = GunaComboBoxTypeBordereau.SelectedItem.ToString

                    Dim TYPE_MOUVEMENT As String = ""

                    Dim QUANTITE_ENTREE As Double = 0
                    Dim QUANTITE_SORTIE As Double = 0
                    Dim VALEUR_ENTREE As Double = 0
                    Dim VALEUR_SORTIE As String = 0

                    If Trim(GunaComboBoxTypeBordereau.SelectedItem) = GlobalVariable.bon_approvisi Or Trim(GunaComboBoxTypeBordereau.SelectedItem) = "Store Requisition" Then

                        If GlobalVariable.actualLanguageValue = 0 Then
                            TYPE_MOUVEMENT = "Store Requisition"
                        ElseIf GlobalVariable.actualLanguageValue = 0 Then
                            TYPE_MOUVEMENT = "Approvisionnement"
                        End If

                        QUANTITE_ENTREE = entre_en_stock
                        VALEUR_ENTREE = QUANTITE_ENTREE
                    End If

                    If LIBELLE_UNITE = PETITE_UNITE Then
                        'QUANTITE_ENTREE = QUANTITE_ENTREE / VALEUR_DE_CONVERSION
                        'QUANTITE_SORTIE = QUANTITE_SORTIE / VALEUR_DE_CONVERSION
                        'VALEUR_ENTREE = VALEUR_ENTREE / VALEUR_DE_CONVERSION
                        'VALEUR_SORTIE = VALEUR_SORTIE / VALEUR_DE_CONVERSION
                    End If

                    Dim ETAT_MOUVEMENT As String = ""

                    Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                    'GESTION DES LIGNES DE MOUVEMENT SSI NOUS GERONS LES BON DE RECEPTION VALIDE CAR NOUS NE FAISON QUE NOUVELLEMENT ENREGISTRER UNE COMMANDE

                    'EN PARTANT DU PRINCIPE QUE: UNE SORTIE DIRECTE NE REQUIERT POINT DE VALIDATION

                End If

            Next

        End If

        Functions.DeleteElementOnTwoConditions(CODE_UTILISATEUR_CREA, "bordereau_ligne_temp", "CODE_USER", "CODE_AGENCE", CODE_AGENCE)

        Functions.SiplifiedClearTextBox(Me)

        GunaDataGridViewLigneArticleCommande.Columns.Clear()

    End Sub

    Private Sub GunaTextBoxCoutDuStock_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCoutDuStock.TextChanged
        'GunaTextBoxAchat.Text = GunaTextBoxCoutDuStock.Text * GunaTextBoxQuantite.Text
        GunaTextBoxAchat.Text = GunaTextBoxCoutDuStock.Text
    End Sub

    Private Sub GunaDataGridViewLigneArticleCommande_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLigneArticleCommande.CellDoubleClick

        'MODICFICATION DU DATAGRID
        Dim econom As New Economat()

        If e.RowIndex >= 0 Then

            If Not Trim(GunaTextBoxCodeBordereau.Text) = "" Then
                GunaButtonController.Visible = False
            End If

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonAjouterLigneAppro.Text = "Edit"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterLigneAppro.Text = "Modifier"
            End If

            GunaButtonAjouterLigneAppro.Visible = True

            'GunaTextBoxQteAppro.Text = 1

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewLigneArticleCommande.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE CODE_ARTICLE=@CODE_ARTICLE ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim CODE_ARTICLE As String = row.Cells("CODE ARTICLE").Value.ToString
            Dim QUANTITE As Double = row.Cells("QUANTITE").Value
            Dim PU As Double = row.Cells("PRIX UNITAIRE").Value
            Dim UNITE_UTILISE As String = row.Cells("UNITE").Value

            GunaTextBoxID_LIGNE_TEMP.Text = row.Cells("ID_LIGNE_BORDEREAU").Value

            command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

            adapter.SelectCommand = command

            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then

                GunaTextBoxCodeArticleAppro.Text = Article.Rows(0)("CODE_ARTICLE")

                GunaTextBoxAchat.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") 'PRIX D'ACHAT 
                GunaTextBoxPrixVente.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0.0") 'COUT MOYEN UNITAIRE PONDERE
                GunaTextBoxArticleAppro.Text = Article.Rows(0)("DESIGNATION_FR")
                GunaTextBoxSeuile.Text = Article.Rows(0)("SEUIL_REAPPROVISIONNEMENT")
                GunaTextBoxEnStock.Text = Article.Rows(0)("QUANTITE")
                GunaTextBoxCodeUniteComptage.Text = Article.Rows(0)("UNITE_COMPTAGE")

                GunaTextBoxCoutDuStock.Text = Format(Article.Rows(0)("COUT_U_MOYEN_PONDERE"), "#,##0.0") ' PRIX UNITAIRE A L'ACHAT

                Dim unite As DataTable = Functions.getElementByCode(GunaTextBoxCodeUniteComptage.Text, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                If unite.Rows.Count > 0 Then
                    gestionDesUnitesAppro(Article)
                End If

                GunaDataGridViewArticleAppro.Visible = False

                '--------------------------------------------------------------
                GunaComboBoxUniteComptageAppro.SelectedItem = UNITE_UTILISE

                GunaTextBoxQteAppro.Text = Format(QUANTITE, "#,##0.0")
                GunaTextBoxCoutDuStock.Text = Format(PU, "#,##0.0")
                'GunaTextBoxAchat.Text = PU
                GunaDataGridViewArticle.Visible = False

            Else

            End If

            GunaDataGridViewArticle.Visible = False

        End If

    End Sub

    Private Sub GunaTextBoxVenteAppro_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxVenteAppro.TextChanged

        If Not Trim(GunaTextBoxVenteAppro.Text) = "" Then
            MONTANT_PAYER = GunaTextBoxVenteAppro.Text
        End If

    End Sub

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

    Private Sub GunaDataGridViewBlocNoteFermee_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBlocNoteFermee.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = GunaDataGridViewBlocNoteFermee.Rows(e.RowIndex)

            Dim NUMERO_BLOC_NOTE As String = row.Cells(0).Value.ToString

            Dim blocNoteEnCours As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

            If blocNoteEnCours.Rows.Count > 0 Then

                GunaTextBoxNumfacture.Text = blocNoteEnCours.Rows(0)("CODE_FACTURE")

                Dim ClientDevantRegler As DataTable = Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT")

                If ClientDevantRegler.Rows.Count > 0 Then
                    GunaTextBoxCodeClient.Text = ClientDevantRegler.Rows(0)("CODE_CLIENT") 'Code client
                    GunaTextBoxCodeClient.Visible = False
                    GunaTextBoxNom_Prenom.Text = ClientDevantRegler.Rows(0)("NOM_PRENOM") 'Nom du client
                End If

                OutPutLigneFactureFermee(NUMERO_BLOC_NOTE)

                GunaButtonSaveFacturation.Visible = False

                FacturationKeyInformation()

            End If
        Else
            GunaButtonSaveFacturation.Visible = False
        End If

    End Sub

    Private Sub ChoisirMagasinDeTravailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChoisirMagasinDeTravailToolStripMenuItem.Click

        '2- MAGASIN DE l'UTILISATEUR SI IL EST ASSOCIE A PLUS D'UN MAGASIN
        Dim lesMagasins As DataTable = Functions.getElementByCode(Trim(GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")), "utilisateur_magazin", "CODE_UTILISATEUR")

        If lesMagasins.Rows.Count >= 1 Then

            ChoixDuMagasinForm.Close()
            ChoixDuMagasinForm.Show()
            ChoixDuMagasinForm.TopMost() = True
            ChoixDuMagasinForm.BringToFront()

        ElseIf lesMagasins.Rows.Count = 1 Then
            GlobalVariable.magasinActuel = Trim(lesMagasins.Rows(0)("CODE_MAGAZIN"))
        End If

    End Sub

    Private Sub GunaButtonRefresh_Click(sender As Object, e As EventArgs) Handles GunaButtonRefresh.Click

        'Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        'If notifications.Rows.Count > 0 Then
        'GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
        'End If

        manualRefresh()

    End Sub

    Private Sub SupprimerToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem2.Click

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then
            'SI ON N'A PAS LE DROIT DE CORRECTION

            If GunaDataGridViewBlocNote.Rows.Count > 0 Then

                Dim NUMERO_BLOC_NOTE As String = ""

                Dim DeleteRow As Boolean = False

                Dim rowToDelete As String = ""
                Dim rowToDeleteMontant As Double = 0

                Dim MONTANT_A_RETRANCHER As Double = 0

                If rowToDelete = "" Then
                    rowToDelete = GunaDataGridViewBlocNote.CurrentRow.Cells(0).Value.ToString
                    NUMERO_BLOC_NOTE = GunaDataGridViewBlocNote.CurrentRow.Cells(0).Value.ToString
                    rowToDeleteMontant = GunaDataGridViewBlocNote.CurrentRow.Cells(1).Value
                End If

                If True Then

                    Dim dialog As DialogResult

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Do you really want to delete the receipt " & rowToDelete
                        languageTitle = "Delete"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Voulez-vous vraiment Supprimer le bloc note " & rowToDelete
                        languageTitle = "Suppression"
                    End If

                    dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If dialog = DialogResult.No Then
                        'e.Cancel = True
                        DeleteRow = False
                    Else
                        DeleteRow = True
                    End If

                    If DeleteRow Then

                        'GESTION DE MODIFICATION DONC ON RETRANCHE L'ANCIEN MONTANT AVANT AJOUT DE LA NOUVELLE
                        Dim infoBlocNote As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                        If infoBlocNote.Rows.Count > 0 Then

                            If GlobalVariable.actualLanguageValue = 0 Then
                                languageMessage = "Deleting the receipt" & rowToDelete & " will delete it content also " & Chr(13) & " Do you want to continu"
                                languageTitle = "Delete"
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                languageMessage = "La suppression du bloc note " & rowToDelete & " supprimera son contenu " & Chr(13) & " Voulez-vous continuer "
                                languageTitle = "Suppression"
                            End If

                            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If dialog = DialogResult.Yes Then

                                Functions.DeleteElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")
                                Functions.DeleteElementByCode(NUMERO_BLOC_NOTE, "ligne_facture", "NUMERO_BLOC_NOTE")
                                Functions.DeleteElementByCode(NUMERO_BLOC_NOTE, "ligne_facture", "NUMERO_SERIE_FIN")

                                If GlobalVariable.actualLanguageValue = 0 Then
                                    languageMessage = "Receipt " & NUMERO_BLOC_NOTE & " Successfully deleted"
                                    languageTitle = "Delete"
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    languageMessage = "Vous avez supprimé le bloc note " & NUMERO_BLOC_NOTE & " avec succès"
                                    languageTitle = "Suppression"
                                End If

                                listeDesblocNoteSurUnePeriode()

                                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If
                        End If

                    End If

                End If

            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Nothing to be deleted !"
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Aucune ligne à supprimer!"
                    languageTitle = "Suppression"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "You don't have the necessary right"
                languageTitle = "Correction"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Vous n'avez pas le droit necessaire"
                languageTitle = "Correction"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub GunaDataGridViewFolio3_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewFolio3.CellEndEdit

        If True Then
            'SI ON N'A PAS LE DROIT DE CORRECTION

        Else

            Dim rowValue As Boolean

            '1- DETERMINER LES VALEURS MODIFIEES

            '2- METTRE A JOUR LE CONTENU DES BLOCS NOTES

            '3- 

        End If

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSupLigneBlocNoteGestBlocNote.Click

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then


            If GunaDataGridViewFolio3.Rows.Count > 0 Then

                Dim ID_LIGNE_FACTURE As Integer
                Dim CODE_ARTICLE As String = ""
                Dim NUMERO_BLOC_NOTE As String = GunaTextBoxNumBlocNoteDet.Text

                Dim DeleteRow As Boolean = False

                Dim rowToDelete As String = ""
                Dim rowToDeleteMontant As Double = 0

                Dim MONTANT_A_RETRANCHER As Double = 0

                If rowToDelete = "" Then
                    rowToDelete = GunaDataGridViewFolio3.CurrentRow.Cells(0).Value.ToString
                    ID_LIGNE_FACTURE = GunaDataGridViewFolio3.CurrentRow.Cells(5).Value.ToString
                    CODE_ARTICLE = GunaDataGridViewFolio3.CurrentRow.Cells(4).Value.ToString
                    rowToDeleteMontant = GunaDataGridViewFolio3.CurrentRow.Cells(2).Value
                End If

                If rowToDeleteMontant > 0 Then

                    Dim dialog As DialogResult

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Do you really want to delete " & rowToDelete
                        languageTitle = "Delete"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Voulez-vous vraiment Supprimer " & rowToDelete
                        languageTitle = "Suppression"
                    End If

                    dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If dialog = DialogResult.No Then
                        'e.Cancel = True
                        DeleteRow = False
                    Else
                        DeleteRow = True
                    End If

                    If DeleteRow Then

                        Dim infoSup As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")

                        '------------------------------------------------------------------------
                        Dim MONTANT_BLOC_NOTE As Double = 0

                        Dim ligneDuBlocNotes As DataTable

                        If infoSup.Rows.Count > 0 Then
                            'SI L'ON EST DANS LIGNE FACTURE TEMP

                            Functions.DeleteElementOnTwoConditions(ID_LIGNE_FACTURE, "ligne_facture_temp", "ID_LIGNE_FACTURE", "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE)

                            ligneDuBlocNotes = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")

                        Else

                            infoSup = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture", "NUMERO_BLOC_NOTE")

                            If infoSup.Rows.Count > 0 Then

                                Functions.DeleteElementOnTwoConditions(ID_LIGNE_FACTURE, "ligne_facture", "ID_LIGNE_FACTURE", "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE)

                                ligneDuBlocNotes = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture", "NUMERO_BLOC_NOTE")

                            Else

                                Functions.DeleteElementOnTwoConditions(ID_LIGNE_FACTURE, "ligne_facture", "ID_LIGNE_FACTURE", "NUMERO_SERIE_DEBUT", NUMERO_BLOC_NOTE)

                                ligneDuBlocNotes = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture", "NUMERO_SERIE_DEBUT")

                            End If

                        End If


                        If ligneDuBlocNotes.Rows.Count > 0 Then

                            For i = 0 To ligneDuBlocNotes.Rows.Count - 1
                                MONTANT_BLOC_NOTE += ligneDuBlocNotes.Rows(i)("MONTANT_TTC")
                            Next

                        End If

                        Dim updateQuery As String = "UPDATE ligne_facture_bloc_note Set MONTANT_BLOC_NOTE = @MONTANT_BLOC_NOTE WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

                        Dim command1 As New MySqlCommand(updateQuery, GlobalVariable.connect)

                        command1.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.String).Value = NUMERO_BLOC_NOTE
                        command1.Parameters.Add("@MONTANT_BLOC_NOTE", MySqlDbType.Double).Value = MONTANT_BLOC_NOTE

                        command1.ExecuteNonQuery()
                        '------------------------------------------------------------------------

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "Successfully deleted"
                            languageTitle = "Delete"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Vous avez supprimé avec succès"
                            languageTitle = "Suppression"
                        End If

                        listeDesblocNoteSurUnePeriode()

                        listeDesLigneGestionBlocNOte(NUMERO_BLOC_NOTE)

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Nothing to be deleted !"
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Aucune ligne à supprimer!"
                    languageTitle = "Suppression"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "You don't have the necessary right"
                languageTitle = "Correction"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Vous n'avez pas le droit necessaire"
                languageTitle = "Correction"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub


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

    Private Sub TimerRefreshConnexion_Tick(sender As Object, e As EventArgs) Handles TimerRefreshConnexion.Tick

        'RAFRAICHISSEMENT DE L'APPEL A LA ABSE DE DONNEE

        If GlobalVariable.databaseType = "MYSQL" Then

            GlobalVariable.connecFunction()
            'GlobalVariable.connect.OpenAsync()
        ElseIf GlobalVariable.databaseType = "ACCESS" Then
            'GlobalVariable.sqlConnection.OpenAsync()
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim mobile_number As String = MainWindow.listeOfTelephoneNumbers()
        MessageBox.Show(mobile_number)
        Dim languageMessage As String = "Aucune recette à transférer"
        Functions.ultrMessageSimpleText(languageMessage, mobile_number)

    End Sub

    Private Sub GunaButton12_Click(sender As Object, e As EventArgs) Handles GunaButton12.Click

        RapportFacturesForm.Close()
        GlobalVariable.DocumentToGenerate = "FICHE D'INVENTAIRE JOURNALIERE BAR"
        RapportFacturesForm.Show()
        RapportFacturesForm.TopMost = True
        RapportFacturesForm.GunaDateTimePickerDebut.MaxDate = GlobalVariable.DateDeTravail.AddDays(-1)

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        RapportFacturesForm.Close()
        GlobalVariable.DocumentToGenerate = "INVENTAIRE DU MAGASIN"
        RapportFacturesForm.GunaDateTimePickerDebut.Enabled = False
        RapportFacturesForm.GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
        RapportFacturesForm.GunaDateTimePickerFin.Enabled = False
        RapportFacturesForm.GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail
        RapportFacturesForm.Show()
        RapportFacturesForm.TopMost = True

    End Sub

    Private Sub documentToBeSendUsingBackGroundWorker(ByVal args As ArgumentType)

        If args.action = 0 Then
            'FOR RAPPORT FINANCIER
            RapportApresCloture.docJournalDesVentesShift(args.dt, args.DateDebut, args.DateFin)
        ElseIf args.action = 1 Then

        ElseIf args.action = 2 Then

        ElseIf args.action = 3 Then

        ElseIf args.action = 4 Then

        ElseIf args.action = 5 Then

        End If

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

    Public Sub backGroundWorkerToCall(ByVal args As ArgumentType)

        If Not BackgroundWorker2.IsBusy Then
            BackgroundWorker2.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker3.IsBusy Then
            BackgroundWorker3.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker4.IsBusy Then
            BackgroundWorker4.RunWorkerAsync(args)
        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        GlobalVariable.DocumentToGenerate = "INVENTAIRE DES VENTES"

        RapportFacturesForm.Close()
        RapportFacturesForm.GunaCheckBoxParFamille.Visible = True

        RapportFacturesForm.TopMost = True
        RapportFacturesForm.Show()
    End Sub

    Private Sub journalDesVentesDuShiftImprimer()

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT"
        Dim ligneFacture As New LigneFacture()
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim dtParentCategory As DataTable = ligneFacture.ListeDesCategoriesDArticleVendus(DateDebut, DateFin, CODE_CAISSIER)

        Impression.journalDesVentes(dtParentCategory, DateDebut, DateFin)

    End Sub

    Private Sub journalDesVentesDuShiftParRubrique(ByVal ETAT_FACTURE As Integer)

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT"

        Dim titre As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then

            If ETAT_FACTURE = 0 Then
                titre = "JOURNAL DES VENTES COMPTOIR DU SHIFT"
            ElseIf ETAT_FACTURE = 1 Then
                titre = "JOURNAL DES VENTES EN CHAMBRES DU SHIFT"
            ElseIf ETAT_FACTURE = 2 Then
                titre = "JOURNAL DES OFFRES DU SHIFT"
            ElseIf ETAT_FACTURE = 3 Then
                titre = "JOURNAL DES VENTES TRANSFERES VERS COMPTES VEBITEURS DU SHIFT"
            ElseIf ETAT_FACTURE = 4 Then
                titre = "JOURNAL DES VENTES EN SALLES DU SHIFT"
            End If

        Else

            If ETAT_FACTURE = 0 Then
                titre = "WALK IN SALES"
            ElseIf ETAT_FACTURE = 1 Then
                titre = "IN HOUSE SALES"
            ElseIf ETAT_FACTURE = 2 Then
                titre = "SALES OFFERED"
            ElseIf ETAT_FACTURE = 3 Then
                titre = "SALES TRANSFERED TO DEBTOR ACCOUNTS"
            ElseIf ETAT_FACTURE = 4 Then
                titre = "EVENTS SALES"
            End If

        End If

        Dim ligneFacture As New LigneFacture()
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim dtParentCategory As DataTable = ligneFacture.ListeDesCategoriesDArticleVendusParRubrique(DateDebut, DateFin, ETAT_FACTURE, CODE_CAISSIER)

        Impression.journalDesVentesDuShiftParRubrique(dtParentCategory, DateDebut, DateFin, titre, ETAT_FACTURE)

    End Sub

    Private Sub GunaButtonVenteShift_Click(sender As Object, e As EventArgs) Handles GunaButtonVenteShift.Click
        journalDesVentesDuShiftImprimer()
    End Sub

    Private Sub GunaButtonRapportDesVentes_Click(sender As Object, e As EventArgs) Handles GunaButtonRapportDesVentes.Click
        RapportFacturesForm.Close()
        GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES" 'CUMUL JOURNALIER

        If GlobalVariable.actualLanguageValue = 1 Then

        Else

        End If

        RapportFacturesForm.Show()
        RapportFacturesForm.TopMost = True
    End Sub

    Private Sub GunaButton13_Click(sender As Object, e As EventArgs) Handles GunaButton13.Click
        RapportFacturesForm.Close()
        GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES PERIODIQUE"
        RapportFacturesForm.Show()
        RapportFacturesForm.TopMost = True
    End Sub

    Private Sub GunaButtonCaisseJournalier_Click(sender As Object, e As EventArgs) Handles GunaButtonCaisseJournalier.Click
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Functions.DocumentToPrintSituation(CODE_CAISSIER, "reglement", "CODE_CAISSIER", GlobalVariable.DateDeTravail)
    End Sub

    Private Sub GunaButtonCaisseGlobal_Click(sender As Object, e As EventArgs) Handles GunaButtonCaisseGlobal.Click
        GlobalVariable.DocumentToGenerate = "SITUATION GLOBAL"
        RapportFacturesForm.Show()
        RapportFacturesForm.TopMost = True
        RapportFacturesForm.GunaDateTimePickerFin.Enabled = False
    End Sub

    Private Sub GunaButton14_Click(sender As Object, e As EventArgs) Handles GunaButton14.Click
        RapportFacturesForm.Close()
        GlobalVariable.DocumentToGenerate = "SITUATION DE CAISSE PERIODIQUE"
        RapportFacturesForm.Show()
        RapportFacturesForm.TopMost = True
    End Sub

    Private Sub GunaButtonListePetitDejeuner_Click(sender As Object, e As EventArgs) Handles GunaButtonListePetitDejeuner.Click
        Functions.listeDesPetitsDejeuner(GlobalVariable.DateDeTravail)
    End Sub


    Private Sub GunaAdvenceButtonAuComptant_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonAuComptant.Click
        '----------------------------------------------------------

        Dim continuer As Boolean = True

        If GunaLabelHeader.Text.Equals("WALK IN") Then
            continuer = False
        End If

        If GunaLabelHeader.Text.Equals("COMPTOIR") Then
            continuer = False
        End If

        If continuer Then

            If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
                GunaComboBoxFiltreBlocNotre.Visible = True
            End If

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaLabelHeader.Text = "WALK IN"
                LabelRef.Text = "Account"

                LibelleFacturation.Text = GlobalVariable.ArticleFamily & " BILLING"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelHeader.Text = "COMPTOIR"
                LabelRef.Text = "Journal"

                LibelleFacturation.Text = "FACTURATION " & GlobalVariable.ArticleFamily

            End If

            Me.Cursor = Cursors.WaitCursor

            GunaTextBoxCodeClient.Clear()

            AutoLoadOfBlocNote()

            GunaDataGridViewClient.BringToFront()

            GunaTextBoxNom_Prenom.Enabled = True

            ClearFacturationKeyInformation()
            clearArticleFields()

            GlobalVariable.typeDeClientAFacturer = "comptoir"

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                If GunaComboBoxListeDesComandes Is Nothing Then
                    AutoLoadOfBlocNote()
                End If
            End If
            GunaPanelEnChambre.Visible = False
            GunaPanelEventsSup.Visible = False
            GunaPanelClientComptoirSup.Visible = True
            GunaPanelClientComptoirSup.BringToFront()
            GunaPanelComptoirBloc.Visible = True
            GunaPanelComptoirBloc.BringToFront()

            GlobalVariable.codeReservationToUpdate = ""
            GlobalVariable.codeMainCouranteJournaliereToUpdate = ""

            GunaTextBoxCodeClient.Clear()
            GunaTextBoxArticle.Clear()

            GunaTextBoxNumfacture.Text = Functions.GeneratingRandomCodeWithSpecifications("facture", "")

            GunaTextBoxFacturationDate.Text = CDate(GlobalVariable.DateDeTravail).ToShortDateString

            'On selectionne le nouveau bloc note affiché par défaut
            Dim blocNoteEnCours As DataTable

            If GunaComboBoxListeDesComandes.SelectedIndex >= 0 Then
                'We have atleast an element in our combobox
                blocNoteEnCours = Functions.getElementByCode(GunaComboBoxListeDesComandes.SelectedValue.ToString, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If blocNoteEnCours.Rows.Count > 0 Then

                    'On insere le numero de la proforma lié a cette facture
                    GunaTextBoxNumfacture.Text = blocNoteEnCours.Rows(0)("CODE_FACTURE")
                    GunaTextBoxCodeClient.Text = blocNoteEnCours.Rows(0)("CODE_CLIENT")
                    GunaTextBoxCodeClient.Visible = False

                    If Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT").Rows.Count > 0 Then
                        GunaTextBoxNom_Prenom.Text = Functions.getElementByCode(blocNoteEnCours.Rows(0)("CODE_CLIENT"), "client", "CODE_CLIENT").Rows(0)("NOM_PRENOM")
                    End If

                    Dim ListeDesArticlesDeCetteComandes As DataTable = Functions.GetAllElementsOnCondition(blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE"), "ligne_facture_temp", "NUMERO_BLOC_NOTE")

                    'On charge l'ensemble des articles en relation avec cette commande ou numero de bloc note
                    If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then

                        OutPutLigneFacture()

                        DisplaySavingButton()

                    End If

                    If GlobalVariable.actualLanguageValue = 0 Then

                        If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                            GunaButtonSaveFacturation.Text = "Close"
                        ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                            GunaButtonSaveFacturation.Text = "Pay"
                        End If

                    ElseIf GlobalVariable.actualLanguageValue = 1 Then

                        If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 0 Then
                            GunaButtonSaveFacturation.Text = "Clôturer"
                        ElseIf blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 1 Then
                            GunaButtonSaveFacturation.Text = "Régler"
                        End If

                    End If

                    FacturationKeyInformation()

                    GunaTextBoxCodeClient.Visible = False

                End If

            Else
                GunaTextBoxCodeClient.Visible = True
            End If

            TabControlBarRestaurant.SelectedIndex = 0

            Me.Cursor = Cursors.Default

        End If
        '----------------------------------------------------------

    End Sub

    Private Sub PlanningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanningToolStripMenuItem.Click
        PlanningHebdomadaireDuPersonnelForm.Show()
        PlanningHebdomadaireDuPersonnelForm.TopMost = True
    End Sub

    Private Sub GunaTextBoxTotalDesVentesJournaliere_Click(sender As Object, e As EventArgs) Handles GunaTextBoxTotalDesVentesJournaliere.Click
        journalDesVentesDuShiftImprimer()
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        journalDesVentesDuShiftImprimer()
    End Sub

    Private Sub LabelTotalVenteEnChambre_Click(sender As Object, e As EventArgs) Handles LabelTotalVenteEnChambre.Click
        Dim ETAT_FACTURE As Integer = 1

        If False Then
            ComparaisonVenteReglement.Show()
            ComparaisonVenteReglement.TopMost = True
        Else
            journalDesVentesDuShiftParRubrique(ETAT_FACTURE)
        End If
    End Sub

    Private Sub LabelVenteOfferte_Click(sender As Object, e As EventArgs) Handles LabelVenteOfferte.Click
        Dim ETAT_FACTURE As Integer = 2

        If False Then
            ComparaisonVenteReglement.Show()
            ComparaisonVenteReglement.TopMost = True
        Else
            journalDesVentesDuShiftParRubrique(ETAT_FACTURE)
        End If
    End Sub

    Private Sub LabelVenteVersCompte_Click(sender As Object, e As EventArgs) Handles LabelVenteVersCompte.Click
        Dim ETAT_FACTURE As Integer = 3

        If False Then
            ComparaisonVenteReglement.Show()
            ComparaisonVenteReglement.TopMost = True
        Else
            journalDesVentesDuShiftParRubrique(ETAT_FACTURE)
        End If
    End Sub

    Private Sub LabelVenteEvent_Click(sender As Object, e As EventArgs) Handles LabelVenteEvent.Click
        Dim ETAT_FACTURE As Integer = 4

        If False Then
            ComparaisonVenteReglement.Show()
            ComparaisonVenteReglement.TopMost = True
        Else
            journalDesVentesDuShiftParRubrique(ETAT_FACTURE)
        End If

    End Sub

    Private Sub GunaButtonInventaire_Click(sender As Object, e As EventArgs) Handles GunaButtonInventaire.Click

        Me.Cursor = Cursors.WaitCursor

        DataGridViewRapports.Columns.Clear()

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToShortDateString
        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToShortDateString

        Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel

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

        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

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
                    Dim DATE_CONTROL As Date = DateDebut

                    'MessageBox.Show(gesion_des_shifts_.Rows.Count)

                    For i = 0 To gesion_des_shifts_.Rows.Count - 1

                        INDEX_SHIFT = gesion_des_shifts_.Rows(i)("INDEX_SHIFT")
                        DATE_DE_CONTROLE_DEBUT = gesion_des_shifts_.Rows(i)("DATE_DE_CONTROLE_DEBUT")
                        DATE_DE_CONTROLE_FIN = gesion_des_shifts_.Rows(i)("DATE_DE_CONTROLE_FIN")

                        If INDEX_SHIFT = 0 Then
                            'SHIFT DU JOUR
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
                            'SHIFT DU SOIR
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

                If CODE_ARTICLE = "5453234" Then
                    MessageBox.Show(" MATIN : " & SF_MATIN & " - " & ENTREE_MATIN & " - " & SORTIE_MATIN & " - " & SI_MATIN & " / SOIR : " & SF_SOIR & " - " & ENTREE_SOIR & " - " & SORTIE_SOIR & " - " & SI_SOIR)
                End If

                'AFFICHAGE DES INFORMATION DE CHAQUE ARTICLE
                DataGridViewRapports.Rows.Add(ficheInventaireJournaliere.Rows(j)("DESIGNATION_FR"), SI_MATIN, ENTREE_MATIN, SORTIE_MATIN, SF_MATIN, SI_SOIR, ENTREE_SOIR, SORTIE_SOIR, SF_SOIR, CODE_ARTICLE)

            Next

            If DataGridViewRapports.Rows.Count > 0 Then
                DataGridViewRapports.Columns("CODE_ARTICLE").Visible = False
            End If

        Else
            GunaButtonImprimer.Visible = False
        End If

        Impression.ficheInventaireJournalierBar(DataGridViewRapports, DateDebut, DateFin)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        RapportFacturesForm.Close()
        GlobalVariable.DocumentToGenerate = "FICHE DE VENTILATION" 'CUMUL JOURNALIER

        RapportFacturesForm.Show()
        RapportFacturesForm.TopMost = True

        If GlobalVariable.actualLanguageValue = 1 Then
            RapportFacturesForm.GunaLabelGeneral.Text = "FICHE DE VENTILATION"
        Else
            RapportFacturesForm.GunaLabelGeneral.Text = "SALES VENTILATION FORM"
        End If

    End Sub

    Private Sub ImprimerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem1.Click
        'Imprimer Facture

        printCommandeOrder(GunaDataGridViewBlocNoteOuvert)

    End Sub

    Public Sub printCommandeOrder(ByVal dt As DataGridView)

        Dim i As Integer = 0

        Dim cashier As New Caisse()

        For Each row As DataGridViewRow In dt.SelectedRows

            Dim NUMERO_BLOC_NOTE As String = Trim(row.Cells(0).Value.ToString)
            Dim NOM_CLIENT As String = ""
            Dim NOM_SERVEUR As String = ""

            Dim blocNote As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

            If blocNote.Rows.Count > 0 Then

                Dim ligneBlocNote As DataTable = cashier.LigneDunBlocNoteQuelconque(NUMERO_BLOC_NOTE)

                Dim CODE_CLIENT As String = blocNote.Rows(0)("CODE_CLIENT")
                Dim CODE_SERVEUR As String = blocNote.Rows(0)("CODE_CAISSIER")

                Dim infoClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

                If infoClient.Rows.Count > 0 Then
                    NOM_CLIENT = infoClient.Rows(0)("NOM_PRENOM")
                End If

                Dim infoUser As DataTable = Functions.getElementByCode(CODE_SERVEUR, "utilisateurs", "CODE_UTILISATEUR")

                If infoUser.Rows.Count > 0 Then
                    NOM_SERVEUR = infoUser.Rows(0)("NOM_UTILISATEUR")
                End If

                If ligneBlocNote.Rows.Count > 0 Then
                    Impression.commandeGestionDesBlocNotes(ligneBlocNote, NOM_CLIENT, NOM_SERVEUR, NUMERO_BLOC_NOTE)
                End If

            End If

        Next

    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        printCommandeOrder(GunaDataGridViewBlocNoteFermee)
    End Sub

    Private Sub GunaTextBox5_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox5.TextChanged

        If Trim(GunaTextBox5.Text).Equals("") Then
            GunaDataGridViewBills.Visible = False
            GunaDataGridViewBills.Columns.Clear()
        Else

            GunaDataGridViewBills.Visible = True

            Dim DateDeSituation As Date = GlobalVariable.DateDeTravail
            Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            If True Then

                Dim getUserQuery = ""
                'SESSION UNIQUE VEUT DIRE QUE 

                If GlobalVariable.actualLanguageValue = 0 Then

                    If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
                        getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE, DATE_DE_CONTROLE FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBox5.Text) & "%' ORDER BY NUMERO_BLOC_NOTE ASC"
                    Else
                        getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE, DATE_DE_CONTROLE FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBox5.Text) & "%' ORDER BY NUMERO_BLOC_NOTE ASC"
                    End If

                Else

                    If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
                        getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT, DATE_DE_CONTROLE FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBox5.Text) & "%' ORDER BY NUMERO_BLOC_NOTE ASC"
                    Else
                        getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT, DATE_DE_CONTROLE FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBox5.Text) & "%' ORDER BY NUMERO_BLOC_NOTE ASC"
                    End If

                End If

                Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

                command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER

                Dim adapter As New MySqlDataAdapter(command)
                Dim blocNoteAvisualiser As New DataTable()

                adapter.Fill(blocNoteAvisualiser)

                If blocNoteAvisualiser.Rows.Count > 0 Then

                    GunaDataGridViewBills.Rows.Clear()

                    If GlobalVariable.actualLanguageValue = 0 Then

                        GunaDataGridViewBills.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                        GunaDataGridViewBills.Columns.Add("AMOUNT", "AMOUNT")
                        GunaDataGridViewBills.Columns.Add("STATE", "STATE")
                        GunaDataGridViewBills.Columns.Add("TIME", "TIME")

                    ElseIf GlobalVariable.actualLanguageValue = 1 Then

                        GunaDataGridViewBills.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
                        GunaDataGridViewBills.Columns.Add("MONTANT", "MONTANT")
                        GunaDataGridViewBills.Columns.Add("ETAT", "ETAT")
                        GunaDataGridViewBills.Columns.Add("TEMPS", "TEMPS")

                    End If

                    For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                        Dim ETAT_NOTE As String = ""
                        Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString

                        If GlobalVariable.actualLanguageValue = 0 Then

                            If blocNoteAvisualiser.Rows(i)("STATE") = 0 Then
                                ETAT_NOTE = "TO CLOSE"
                            ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                                ETAT_NOTE = "TO BE PAID"
                            ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 2 Then
                                ETAT_NOTE = "PAID"
                            End If

                            GunaDataGridViewBills.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), blocNoteAvisualiser.Rows(i)("AMOUNT"), ETAT_NOTE, TEMPS)

                            GunaDataGridViewBills.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                            GunaDataGridViewBills.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        ElseIf GlobalVariable.actualLanguageValue = 1 Then

                            If blocNoteAvisualiser.Rows(i)("ETAT") = 0 Then
                                ETAT_NOTE = "A CLOTURER"
                            ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                                ETAT_NOTE = "A REGLER"
                            ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 2 Then
                                ETAT_NOTE = "REGLE"
                            End If

                            GunaDataGridViewBills.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), blocNoteAvisualiser.Rows(i)("MONTANT"), ETAT_NOTE, TEMPS)

                            GunaDataGridViewBills.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                            GunaDataGridViewBills.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        End If

                    Next

                Else
                    GunaDataGridViewBills.Columns.Clear()
                    GunaDataGridViewBills.Visible = False
                End If

            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        printCommandeOrder(GunaDataGridViewBills)

        GunaTextBox5.Text = ""
    End Sub
End Class