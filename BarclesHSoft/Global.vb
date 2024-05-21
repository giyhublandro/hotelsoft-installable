Imports System.IO
Imports MySql.Data.MySqlClient

Public Class GlobalVariable

    Public Shared libre_propre As String = ""
    Public Shared occupee_propre As String = ""
    Public Shared libre_sale As String = ""
    Public Shared occupee_sale As String = ""
    Public Shared hors_service As String = ""
    Public Shared reserver As String = ""

    Public Shared bon_reception As String = "Bon de Réception"
    Public Shared bon_requisition As String = "Bon de Réquisition"
    Public Shared inventaire As String = "Inventaire"
    Public Shared sortie As String = "Sortie"
    Public Shared sortie_exceptionnelle As String = "Sortie Exceptionnelle"
    Public Shared retour_marchandise = "Retour Marchandises"
    Public Shared transfert_inter = "Transfert Inter Magasin"
    Public Shared entree_exceptionnelle = "Entrée Exceptionnelle"
    Public Shared bon_approvisi = "Bon Approvisionnement"
    Public Shared bon_cmd = "Bon de Commande"
    Public Shared list_du_marche = "Liste du Marché"

    Public Shared editUserFromFrontOffice As Boolean = False

    Public Shared actualLanguageValue As Integer = 1

    Public Shared defaultLanguage As Integer = -1 'FRENCH 

    Public Shared tarificationDynamiqueActif As Boolean = False

    Public Shared licenceExipre As Boolean = False

    Public Shared ficheStatistiquesJournaliere As String = ""
    Public Shared nomUniteDeVente As String = ""

    Public Shared ouvertureDelaFenetreDeReglementApArtirDu As String = ""

    Public Shared categorisationDeDepense As String = ""

    Public Shared typeFamilleOuSousFamilleDepense As String = ""

    Public Shared decaissemtnAssocie As String = ""

    Public Shared billetageAPartirDe As String = ""

    Public Shared transfertDeCaisseVersCaissiere As Boolean = False

    Public Shared derniereValeurDepartFinal As Integer = 0

    Public Shared upddateStatData As Boolean = False

    Public Shared entierAnnulation As Integer = 0

    Public Shared updateFinalValueOfStat As Boolean = False

    Public Shared attribuerChambre As Boolean = False

    Public Shared quantite_conso As Double = 0

    'CONTROL DE DUPLICATION

    Public Shared duplicationDeReservation As Boolean = False

    'GESTION DES CLOTURE ET OUVERTURE DE CAISSE AVANT CLOTURE DU NIGHT

    Public Shared softwareVersion As String = "" ' 0 : DEMONSTRATION; 1 : COMPLETE

    Public Shared gestionDeCaisseAvantCloture As String = ""

    Public Shared changerMotDePasseDepuis As String = ""

    Public Shared fenetreDouvervetureDeCaisse As String = "" 'DETERMINE LE LIEU OU ON VEUT OUVRIR LA CAISSE

    Public Shared TransfertDeElementDeCaisse As String = "" 'INDIQUE QU'ON UTILISE LA FENETRE DE VERIFICATION DE PWD POUR UN TRANSFERT ENTRE CAISSE

    Public Shared chambreEnCoursDeControl As String = ""

    Public Shared controlDeChambreOk As Boolean = False

    Public Shared AjouterConsigneFormRole As String

    Public Shared magasinActuel As String = ""
    Public Shared shiftActuel As Integer = -1
    Public Shared typeRapportEconmat As String = ""

    ' GESTION DES ARTICLES ET MATIERES 

    Public Shared typeArticle As String = ""
    Public Shared ficheTechnique As String = ""
    Public Shared informationDesStatistiques As DataTable

    Public Shared affichageDuStatutsDesCahmbresOuPas As Boolean = False
    Public Shared iconDeChambreOccupe As String = ""

    Public Shared btnNettoyage As Button
    Public Shared databaseType As String = ""

    'ZenlockForm 
    Public Shared zenlockForm As String = ""

    Public Shared ActualWindow As String = ""
    Public Shared PreviousWindow As String = ""
    Public Shared PreviousWindowParam As String = ""
    Public Shared infoReservationPourEncodage As DataTable
    Public Shared Sub navigation(ByVal ActualWindowParam As String)

        PreviousWindow = ActualWindow
        ActualWindow = ActualWindowParam

    End Sub

    'Home Form module visibility
    Public Shared modulesVisible As Boolean = False

    Public Shared montantTTCAfterCloture As Double = 0
    Public Shared montantHTAfterCloture As Double
    Public Shared TVAAfterCloture As Double

    'Type de client à facturer
    Public Shared typeDeClientAFacturer As String = ""

    'code client devant regler 
    Public Shared codeClientDevantRegler As String = ""

    'bloc_note
    Public Shared blocNoteARegler As String = ""

    'Gestion des pannes
    Public Shared TypePanne As String = ""

    'INtervention
    Public Shared TypeIntervention As String = ""

    'Droit d'accès de l'utilisateur connecté
    Public Shared DroitAccesDeUtilisateurConnect As DataTable

    'To know if we are working on famille or sous famille
    Public Shared typeFamilleOuSousFamille As String = ""
    'Date de Clôture
    Public Shared DateDeTravail As Date
    Public Shared cloturer As Boolean = False

    'Connaitre si on gere l'ancienne ou la nouvelle main courante
    Public Shared AncienneMainCourante As Boolean = False

    'For calculation
    Public Shared avance As Double
    'card paiment
    Public Shared cardPaiement As Double = 0

    'Information that are going to be used through out teh software
    'Connected user profile
    Public Shared ConnectedUser As DataTable
    'Currency
    Public Shared Monnaie As DataTable
    'Agency
    Public Shared AgenceActuelle As DataTable
    'Company
    Public Shared societe As DataTable

    'tarif 
    Public Shared codeTarifPrixToUpdate

    '----------------------------- RESERVATION ---------------------
    'To create user or rooType from front office and imediately populate the client part of the reservation form

    'SALLE

    Public Shared capacite As Integer = 0
    'Public Shared capacite As Integer = 0

    'Promotion

    Public Shared tarifFromFrontDesk As Boolean = False
    Public Shared tarifFromFrontDeskCode As String = ""

    'CHAMBRE
    Public Shared addUserFromFrontOffice As Boolean = False
    Public Shared addCategorieFromFrontOffice As Boolean = False
    Public Shared chambreOuSalleFromFrontDesk As String = ""
    Public Shared CategorieAddedFromFrontOffice As DataTable

    Public Shared fromMainCouranteJournaliereToFrontOffice As Boolean = False

    Public Shared userId As Integer
    Public Shared codeUser As String = ""

    Public Shared idClient As Integer
    Public Shared codeClient As String
    Public Shared codeCompteClient As String

    Public Shared sensDuSoldeDuCompte As String

    Public Shared idChambre As Integer
    Public Shared codeChambre As String

    Public Shared agencyId As Integer

    Public Shared DATE_ENTTRE As Date
    Public Shared HEURE_ENTREE As DateTime
    Public Shared DATE_SORTIE As Date
    Public Shared HEURE_CREATION As DateTime
    Public Shared HEURE_SORTIE As DateTime
    Public Shared ADULTES As Integer
    Public Shared NB_PERSONNES As Integer
    Public Shared ENFANTS As Integer
    Public Shared RECEVOIR_EMAIL As Integer
    Public Shared RECEVOIR_SMS As Integer
    Public Shared ETAT_RESERVATION As Integer

    Public Shared MONTANT_TOTAL_CAUTION As Double
    Public Shared MOTIF_ETAT As String
    Public Shared DATE_ETAT As Date
    Public Shared MONTANT_ACCORDE As Double
    Public Shared MONTANT_TOTAL As Double

    '----------------------------- END RESERVATION ---------------------

    '----------------------------- TYPE CHAMBRE PANEL - WIZARD ---------------------
    Public Shared codeAgence As String = ""
    Public Shared codeSociete As String = ""


    '---------------------------------- DATABASE CONNECTION CREDENTIALS
    'OFF LINE DATABASE

    Public Shared ip_1 As String
    Public Shared ip_2 As String
    Public Shared ip_3 As String
    Public Shared ip_4 As String
    Public Shared user As String

    '------------------------- LECTURE DE FICHER AS STRING -----------------------------------------

    Sub lectureFichier(ByVal fichier As String)

        Try


        Catch ex As Exception


        End Try

    End Sub

    Public Shared simpleMessage As Boolean = False
    '-----------------------------------------------------------------------------------------------
    Public Shared Sub connectClose()
        connect.Close()
    End Sub

    Public Shared Sub connecFunction()

        'Element d'un fichier end '
        Dim path As String = "c:\credentials.txt"
        Dim sw As StreamWriter

        'Dim fs As FileStream = Nothing

        'fs = New FileStream(path, FileMode.Open, FileAccess.Read)

        Dim monStreamReader As StreamReader = New StreamReader(path)

        Dim ligne As String = ""
        Dim i As Integer = 0
        ' Open the file to read from.
        'Dim readText() As String = File.ReadAllLines(path)

        Do
            ligne = monStreamReader.ReadLine()

            If i = 0 Then
                ip_1 = Trim(ligne)
            ElseIf i = 1 Then
                user = Trim(ligne)
            End If

            i += 1

        Loop Until ligne Is Nothing

        monStreamReader.Close()

        '-------------------------------------------- OLD EXCELLENTE -------------------------------
        'Dim readText() As String = File.ReadAllLines(path)
        'Dim s As String

        'For Each s In readText

        'If i = 0 Then
        'ip_1 = Trim(s)
        'ElseIf i = 1 Then
        'user = Trim(s)
        'End If

        'i += 1

        'Next

        '------------------------------------------------------- END OLD -----------------------------------------------------------------

        'connect = New MySqlConnection("server=" + ip_1 + ";port=3306; uid=" & user & "; pwd=;database= " & softwareVersion & ";Convert Zero Datetime=True")
        'connect.OpenAsync()
        'TEST

        connect = New MySqlConnection()
        connect_2 = New MySqlConnection()

        Try

            With connect
                '.ConnectionString = "server=barcles.com;port=3306; uid=barcl668283; pwd=123@Barcles;database=barcl668283_1l62cc;Connect Timeout=10000000;pooling = true; OldGuids=true"
                .ConnectionString = "server=" + ip_1 + ";port=3306; uid=" & user & "; pwd=;database= " & softwareVersion & ";Convert Zero Datetime=True"
                '.OpenAsync()
                .Open()
            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message & " Unable to connect oups")

        End Try

        'connect.OpenAsync()

        'Public Shared connect As MySqlConnection = New MySqlConnection("server=" & ip_1 & "," & ip_2 & "," & ip_3 & "," & ip_4 & ";port=3306; uid=" & user & "; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True"
    End Sub

    Public Shared connect As MySqlConnection

    Public Shared connect_2 As MySqlConnection
    ' Public Shared connect As MySqlConnection = connecFunction()

    'LA ROCHELLE HOTEL RESTAURANT
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.200.230,192.168.200.233,127.0.0.1,localhost;port=3306; uid=restaurant; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")

    'LA ROCHELLE HOTEL GOUVERNANTE
    ' Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.200.230,192.168.200.225,127.0.0.1,localhost;port=3306; uid=gouvernante; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")

    'LA ROCHELLE HOTEL DIRECTION

    'Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.200.230,192.168.200.232,127.0.0.1,localhost;port=3306; uid=direction; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")

    'LA ROCHELLE HOTEL RECEPTION
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.200.230,192.168.200.231,127.0.0.1,localhost;port=3306; uid=reception; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")


    'SAFARI HOTEL PERFECT BAR RESTAURANT
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.100.14, 192.168.100.19,127.0.0.1,localhost ;port=3306; uid=restaurant; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")
    'SAFARI HOTEL PERFECT DIRECTION
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.100.14, 192.168.100.16,127.0.0.1,localhost ;port=3306; uid=server; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")
    'SAFARI HOTEL PERFECT ECONOMAT
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.100.14, 192.168.100.17,127.0.0.1,localhost ;port=3306; uid=economa; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")
    'SAFARI HOTEL PERFECT ASSISTANT COMPTABLE
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.100.14, 192.168.100.10,127.0.0.1,localhost ;port=3306; uid=NJILLE; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")
    'SAFARI HOTEL PERFECT COMPTABLE
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=192.168.100.14, 192.168.100.56,127.0.0.1,localhost ;port=3306; uid=COMPTABLE; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")
    'ON LINE DATABASE
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=91.216.107.248;port=3306;uid=barcl668283;pwd=uiphwk93p4;database=barcl668283_5phorg")
    'Public Shared connect As MySqlConnection = New MySqlConnection("server=//194.23.243.11291.216.107.189;Port=3306; User ID=barcl668283; password=uiphwk93p4; database=barcl668283_5phorg")
    'Public Shared connectionString As String = "Dsn=BarclesHsoft Access;dbq=C:\Users\hotelsoft\Documents\Visual Studio 2017\Projets\BarclesHSoft\db\barcleshsoftdb.mdb;uid=admin"

    'Public Shared sqlConnection As New Odbc.OdbcConnection(connectionString)
    '---------------------------------------------------------------------------------

    '---------------------------- Holding the information that we will use through out
    'of the user that has been inserted lastly ------------------------
    Public Shared userAddedFromFrontOffice As DataTable

    '--------------------------------------------------------------------
    'variables to update reservation and main courante (simple - journaliere - generale)
    Public Shared codeReservationToUpdate As String = ""
    Public Shared codeMainCouranteToUpdate As String = ""
    Public Shared codeMainCouranteGeneraleToUpdate As String = ""
    Public Shared codeMainCouranteJournaliereToUpdate As String = ""
    Public Shared codeReglementToUpdate As String = ""
    Public Shared codeOccupationchambreToUpdate As String = ""
    Public Shared codeFactureToUpdate As String = ""
    Public Shared codeCompteToUpdate As String = ""
    Public Shared codeChambreToUpdate As String = ""
    Public Shared codeClientToUpdate As String = ""
    Public Shared reserveConfCheckInState As String = "NON"
    Public Shared reserveConfCheckOutState As Integer = 3

    'Variable for facturation of a checkedInClient
    Public Shared checkInFacturation As Boolean

    'We get the entities and the informations they contain
    Public Shared ReservationToUpdate As DataTable
    Public Shared MainCouranteToUpdate As DataTable
    Public Shared MainCouranteGeneraleToUpdate As DataTable
    Public Shared MainCouranteJournaliereToUpdate As DataTable
    Public Shared ReglementToUpdate As DataTable
    Public Shared OccupationchambreToUpdate As DataTable
    Public Shared FactureToUpdate As DataTable
    Public Shared CompteToUpdate As DataTable
    Public Shared ChambreToUpdate As DataTable
    Public Shared ClientToUpdate As DataTable

    'FActuratiion variables

    Public Shared ArticleFamily As String = ""

    'Liste des factures client pour reglement
    Public Shared listDesFacturesDuClient As New DataTable()

    'To know the person to charge individual or company when coming from folio to reglement
    'So as to display or not the company text box
    Public Shared ComingFromFolio1FactureType As String = ""

    'Planning management
    'When coming from Planning TAB roomCode

    Public Shared ComingFromPlanning As Boolean = False

    'Structure du planning

    Structure Planning

        Dim dateDebut As Date
        Dim dateFin As Date
        Dim codeChambre As String

    End Structure

    Public Shared ReservationViaplanning As Planning

    '---------------------------THEMEM COLOR ----------------------------------
    Public Shared couleurTheme As String

    '--------------------- PLANNING ----------------------
    Public Shared typeChambreOuSalle As String = "chambre"

    Public Shared FolioToPrint As String = ""
    Public Shared DocumentToGenerate As String = ""

End Class
