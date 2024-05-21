Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ZenoLockForm

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
    Dim cheminLockSystem As String = ""

    Private Sub ZenoLockForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim DATE_DE_TRAVAIL As Date = GlobalVariable.DateDeTravail.ToShortDateString
        Dim nombreDeNuiteAEncoder As Integer = 0
        Dim nombreDeJourConsomme As Integer = 0

        Dim gratuitee As Boolean = False

        If MainWindow.GunaCheckBoxGratuitee.Checked Then
            gratuitee = True
        End If

        Dim language As New Languages()
        language.ZenoLock(GlobalVariable.actualLanguageValue)

        cheminLockSystem = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_HOTEL_LOCK_SYSTEM")

        CB_Software.SelectedIndex = 0
        CB_Port.SelectedIndex = 0
        CB_Breakfast.SelectedIndex = 1
        CB_DB.SelectedIndex = 0

        'TB_Time.Text = DateTime.Now.ToString("yyyyMMdd1200") + DateTime.Now.AddDays(1).ToString("yyyyMMdd1200")
        TB_Time.Text = ""

        If (CB_DB.SelectedIndex = 0) Then
            If (CB_Software.SelectedIndex = 0) Then
                tb_server.Text = cheminLockSystem
            Else
                tb_server.Text = cheminLockSystem
            End If
        Else
            tb_server.Text = cheminLockSystem
        End If

        If (CB_DB.SelectedIndex = 0) Then
            If (CB_Software.SelectedIndex = 0) Then
                tb_server.Text = cheminLockSystem
            Else
                tb_server.Text = cheminLockSystem
            End If
        End If

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

        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail

        If GlobalVariable.zenlockForm = "frontdesk" Then

            Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate

            If Not Trim(CODE_RESERVATION).Equals("") Then

                GlobalVariable.infoReservationPourEncodage = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                If GlobalVariable.infoReservationPourEncodage.Rows.Count > 0 Then

                    GunaTextBoxNumResa.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("CODE_RESERVATION")

                    TB_IDNo.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("CODE_RESERVATION")

                    TB_RoomNo.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("CHAMBRE_ID")
                    TB_Holder.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("NOM_CLIENT")
                    GunaTextBoxNuits.Text = CType((GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE") - GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")).TotalDays, Int32)
                    GunaTextBoxLibelleHotel.Text = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
                    GunaTextBoxLibelleChambre.Text = Functions.getElementByCode(Trim(TB_RoomNo.Text), "chambre", "CODE_CHAMBRE").Rows(0)("LIBELLE_CHAMBRE")
                    GunaTextBoxTypeChambre.Text = Functions.getElementByCode(TB_RoomNo.Text, "chambre", "CODE_CHAMBRE").Rows(0)("CODE_TYPE_CHAMBRE")
                    GunaTextBoxLibelleTYpeChambre.Text = Functions.getElementByCode(GunaTextBoxTypeChambre.Text, "type_chambre", "CODE_TYPE_CHAMBRE").Rows(0)("LIBELLE_TYPE_CHAMBRE")

                    GunaTextBoxPrix.Text = Format(GlobalVariable.infoReservationPourEncodage.Rows(0)("MONTANT_ACCORDE"), "#,##0")

                    GunaTextBoxDateArrivee.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")

                    If GlobalVariable.AgenceActuelle.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 And Not gratuitee Then
                        'SI OND OIT PAYER AVANT ENCODAGE ALORS LE NOMBRE DE NUITE DEPEND DE MONTANT PAYER PAR APPORT AU MONTANT ACCORDE

                        Dim DATE_ENTTRE As Date = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")

                        nombreDeNuiteAEncoder = Functions.nombreDeJourAInsererDansLEncodeur(DATE_ENTTRE, DATE_DE_TRAVAIL, CODE_RESERVATION)

                        'GunaTextBoxDateDepart.Text = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")).AddDays(nombreDeNuiteAEncoder)

                        GunaTextBoxDateDepart.Text = CDate(DATE_DE_TRAVAIL).AddDays(nombreDeNuiteAEncoder)

                    Else
                        GunaTextBoxDateDepart.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE")
                    End If

                    GunaTextBoxHeureArrivee.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("HEURE_ENTREE").ToShortTimeString
                    GunaTextBoxHeureDepart.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("HEURE_SORTIE").ToShortTimeString

                    Dim dateArrive As Date = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")).ToShortDateString
                    Dim dateDepart As Date = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE")).ToShortDateString
                    Dim HeureEntree As DateTime = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("HEURE_ENTREE")).ToShortTimeString
                    Dim heureDepart As DateTime = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("HEURE_SORTIE")).ToShortTimeString

                    TB_Time.Text = dateArrive.ToString("yyyyMMdd") + HeureEntree.ToString("HHmm") + dateDepart.ToString("yyyyMMdd") + heureDepart.ToString("HHmm")

                    If GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE") = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE") Then

                        If GlobalVariable.actualLanguageValue = 0 Then
                            GunaLabel13.Text = "HOUR(S)"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            GunaLabel13.Text = "HEURE(S)"
                        End If

                        GunaTextBoxNuits.Text = (heureDepart - HeureEntree).TotalHours

                    Else
                        If GlobalVariable.actualLanguageValue = 0 Then
                            GunaLabel13.Text = "NIGHT(S)"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            GunaLabel13.Text = "NUIT(S)"
                        End If

                    End If

                End If

            End If

        Else

            If GlobalVariable.infoReservationPourEncodage.Rows.Count > 0 Then

                GunaTextBoxNumResa.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("CODE_RESERVATION")
                Dim CODE_RESERVATION As String = GlobalVariable.infoReservationPourEncodage.Rows(0)("CODE_RESERVATION")

                TB_IDNo.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("CODE_RESERVATION")

                TB_RoomNo.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("CHAMBRE_ID")
                TB_Holder.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("NOM_CLIENT")
                GunaTextBoxNuits.Text = CType((GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE") - GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")).TotalDays, Int32)
                GunaTextBoxLibelleHotel.Text = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
                GunaTextBoxLibelleChambre.Text = Functions.getElementByCode(Trim(TB_RoomNo.Text), "chambre", "CODE_CHAMBRE").Rows(0)("LIBELLE_CHAMBRE")
                GunaTextBoxTypeChambre.Text = Functions.getElementByCode(TB_RoomNo.Text, "chambre", "CODE_CHAMBRE").Rows(0)("CODE_TYPE_CHAMBRE")
                GunaTextBoxLibelleTYpeChambre.Text = Functions.getElementByCode(GunaTextBoxTypeChambre.Text, "type_chambre", "CODE_TYPE_CHAMBRE").Rows(0)("LIBELLE_TYPE_CHAMBRE")

                GunaTextBoxPrix.Text = Format(GlobalVariable.infoReservationPourEncodage.Rows(0)("MONTANT_ACCORDE"), "#,##0")

                '------------------------------- GESTION DE PAIEMENT AVANT ENCODAGE ----------------------------------------------

                GunaTextBoxDateArrivee.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")

                If GlobalVariable.AgenceActuelle.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 And Not gratuitee Then
                    'SI OND OIT PAYER AVANT ENCODAGE ALORS LE NOMBRE DE NUITE DEPEND DE MONTANT PAYER PAR APPORT AU MONTANT ACCORDE

                    Dim DATE_ENTTRE As Date = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")

                    nombreDeNuiteAEncoder = Functions.nombreDeJourAInsererDansLEncodeur(DATE_ENTTRE, DATE_DE_TRAVAIL, CODE_RESERVATION)

                    'GunaTextBoxDateDepart.Text = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")).AddDays(nombreDeNuiteAEncoder)

                    GunaTextBoxDateDepart.Text = CDate(DATE_DE_TRAVAIL).AddDays(nombreDeNuiteAEncoder)

                Else
                    GunaTextBoxDateDepart.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE")
                End If

                '-----------------------------------------------------------------------------------------------------------------

                'GunaTextBoxDateArrivee.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")
                'GunaTextBoxDateDepart.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE")
                GunaTextBoxHeureArrivee.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("HEURE_ENTREE").ToShortTimeString
                GunaTextBoxHeureDepart.Text = GlobalVariable.infoReservationPourEncodage.Rows(0)("HEURE_SORTIE").ToShortTimeString

                Dim dateArrive As Date = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE")).ToShortDateString
                Dim dateDepart As Date = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE")).ToShortDateString
                Dim HeureEntree As DateTime = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("HEURE_ENTREE")).ToShortTimeString
                Dim heureDepart As DateTime = CDate(GlobalVariable.infoReservationPourEncodage.Rows(0)("HEURE_SORTIE")).ToShortTimeString

                TB_Time.Text = dateArrive.ToString("yyyyMMdd") + HeureEntree.ToString("HHmm") + dateDepart.ToString("yyyyMMdd") + heureDepart.ToString("HHmm")

                If GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_ENTTRE") = GlobalVariable.infoReservationPourEncodage.Rows(0)("DATE_SORTIE") Then
                    If GlobalVariable.actualLanguageValue = 0 Then
                        GunaLabel13.Text = "HOUR(S)"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        GunaLabel13.Text = "HEURE(S)"
                    End If

                    GunaTextBoxNuits.Text = (heureDepart - HeureEntree).TotalHours

                Else
                    If GlobalVariable.actualLanguageValue = 0 Then
                        GunaLabel13.Text = "NIGHT(S)"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        GunaLabel13.Text = "NUIT(S)"
                    End If

                End If

            End If

        End If

        If GlobalVariable.AgenceActuelle.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 Then

            If nombreDeNuiteAEncoder = 0 Then

                If GlobalVariable.AgenceActuelle.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 Then
                    B_NewKey.Enabled = False
                Else
                    B_NewKey.Enabled = True
                End If

            Else
                B_NewKey.Enabled = True
            End If
        Else

            B_NewKey.Enabled = True
        End If

        TB_Holder.MaxLength = 24

    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButton8_Click(sender As Object, e As EventArgs) Handles GunaImageButton8.Click

        GlobalVariable.zenlockForm = ""
        Dim lStatus As Integer

        TB_Result.Text = "Executing..."

        TB_Result.Refresh()

        lStatus = EndSession()

        TB_Result.Text = lStatus.ToString("X")

        Me.Close()

    End Sub

    Private Sub GunaButton9_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    'Configuration des paramètres d'encodage

    Private Sub GunaCheckBox1_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxConfiguration.Click

        If GunaCheckBoxConfiguration.Checked Then
            GroupBoxConfig.Visible = True
        Else
            GroupBoxConfig.Visible = False
        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub




    ' ---------------------------------- GESTION DES ENCODAGES -----------------------------------------

    'Declare Unicode Function StartSession Lib "LockDll_64.dll" (ByVal LockCard As Integer, ByVal DBServer As String, ByVal LogUser As String, ByVal DBFlag As Integer) As Integer

    'Declare Unicode Function EndSession Lib "LockDll_64.dll" () As Integer

    'Declare Unicode Function ChangeLogUser Lib "LockDll_64.dll" (ByVal LogUser As String) As Integer

    'Declare Unicode Function NewKey Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByRef CardNo As Integer) As Integer

    'Declare Unicode Function AddKey Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByRef CardNo As Integer) As Integer

    'Declare Unicode Function DupKey Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByRef CardNo As Integer) As Integer

    'Declare Unicode Function ReadKeyCard Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByRef CardNo As Integer, ByRef CardStatus As Integer, ByRef breakfast As Integer) As Integer

    'Declare Unicode Function EraseKeyCard Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal CardNo As Integer) As Integer

    'Declare Unicode Function CheckOut Lib "LockDll_64.dll" (ByVal RoomNo As String, ByVal CardNo As Integer) As Integer

    'Declare Unicode Function ReadCardID Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal dwCardId As Integer) As Integer

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

    Private Sub B_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Start.Click

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

    End Sub

    Private Sub B_End_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_End.Click
        Dim lStatus As Integer

        TB_Result.Text = "Executing..."

        TB_Result.Refresh()

        lStatus = EndSession()

        TB_Result.Text = lStatus.ToString("X")

    End Sub

    Private Sub B_NewKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_NewKey.Click

        '-------------------------------------- MOUCHARDS ---------------------------------------------------

        Dim VISITE As String = ""

        If GunaCheckBoxVisite.Checked Then
            VISITE = GunaTextBoxComment.Text
        End If

        Dim ACTION As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            ACTION = "CARD ENCODED [ROOM " & TB_RoomNo.Text & " / " & TB_Holder.Text & " FROM " & GunaTextBoxDateArrivee.Text & " " & GunaTextBoxHeureArrivee.Text & " - " & GunaTextBoxDateDepart.Text & " " & GunaTextBoxHeureDepart.Text & "] " & VISITE

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            ACTION = "ENCODAGE DE CARTE [CHAMBRE " & TB_RoomNo.Text & " / " & TB_Holder.Text & " DU " & GunaTextBoxDateArrivee.Text & " " & GunaTextBoxHeureArrivee.Text & " - " & GunaTextBoxDateDepart.Text & " " & GunaTextBoxHeureDepart.Text & "] " & VISITE

        End If
        User.mouchard(ACTION)
        '----------------------------------------------------------------------------------------------------

        Dim lStatus As Integer
        Dim Port As Integer
        Dim CardNo As Integer
        Dim OverFlag As Integer
        Dim Breakfast As Integer
        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String

        Port = CB_Port.SelectedIndex

        If (CK_Over.Checked) Then
            OverFlag = 1
        Else
            OverFlag = 0
        End If

        Breakfast = CB_Breakfast.SelectedIndex
        Dim nomClient As String = TB_Holder.Text
        RoomNo = TB_RoomNo.Text
        'Holder = TB_Holder.Text.Substring(0, 20)

        If nomClient.Length > 20 Then
            nomClient = nomClient.Substring(0, 20)
        End If

        Holder = nomClient
        IDNo = TB_IDNo.Text
        TimeStr = TB_Time.Text
        CardNo = 0

        TB_Result.Text = "Executing..."

        TB_Result.Refresh()

        lStatus = NewKey(Port, RoomNo, "", "", TimeStr, Holder, IDNo, Breakfast, OverFlag, CardNo)

        TB_Result.Text = lStatus.ToString("X")

        If (Integer.Parse(lStatus) = 0) Then
            TB_CardNo.Text = CardNo.ToString()
        End If

        'ENVOIE DE MESSAGE WHATSAPP

        If GunaCheckBoxVisite.Checked Then

            If True Then

                Dim CODE_RESERVATION As String = GunaTextBoxNumResa.Text
                Dim NOM_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
                Dim DATE_ENTTRE As String = GunaTextBoxDateArrivee.Text
                Dim DATE_SORTIE As String = GunaTextBoxDateDepart.Text
                Dim HEURE_ENTREE As String = GunaTextBoxHeureArrivee.Text
                Dim HEURE_SORTIE As String = GunaTextBoxHeureDepart.Text
                Dim CHAMBRE_ID As String = Trim(TB_RoomNo.Text)
                Dim NOM_CLIENT As String = TB_Holder.Text

                Dim NUITEES As Integer = 0

                If Not Trim(GunaTextBoxNuits.Text).Equals("") Then
                    NUITEES = GunaTextBoxNuits.Text
                End If

                Dim MONTANT_ACCORDE As Double = 0

                If Not Trim(GunaTextBoxPrix.Text).Equals("") Then
                    MONTANT_ACCORDE = GunaTextBoxPrix.Text
                End If

                Dim COMMENTAIRE As String = GunaTextBoxComment.Text

                If GlobalVariable.actualLanguageValue = 0 Then
                    whatsAppMessage = "NEW CARD FOR VISIT -/ BY : " & NOM_UTILISATEUR & Chr(13) & "-/ AT : " & Now().ToShortTimeString & Chr(13) & "-/ START : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & "-/ END : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & "-/ LAST : " & NUITEES & " MINUTES ROOM : " & Chr(13) & "-/ ROOM : " & CHAMBRE_ID & Chr(13) & "-/ COMMENT :  " & COMMENTAIRE
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    whatsAppMessage = "NOUVELLE CARTE POUR VISITE " & Chr(13) & "-/ PAR : " & NOM_UTILISATEUR & Chr(13) & "-/ A : " & Now().ToShortTimeString & Chr(13) & "-/ DEBUT : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & "-/ FIN : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & "-/ DUREE : " & NUITEES & " MINUTES " & Chr(13) & "CHAMBRE : " & CHAMBRE_ID & Chr(13) & "-/ COMMENTAIRE :  " & COMMENTAIRE
                End If

                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                    Dim mobile_number As String = MainWindow.listeOfTelephoneNumbers()

                    Dim args As ArgumentType = New ArgumentType()

                    args.action = 0
                    args.whatsAppMessage = whatsAppMessage
                    args.mobile_number = mobile_number

                    backGroundWorkerToCall(args)

                    'Functions.ultrMessageSimpleText(whatsAppMessage, mobile_number)
                End If

                Dim nature As Integer = 0
                gestionDesEncodage(CODE_RESERVATION, nature)

                Me.Close()

                GlobalVariable.zenlockForm = ""

            End If

        Else

            If Integer.Parse(lStatus) = 0 Then

                Dim CODE_RESERVATION As String = GunaTextBoxNumResa.Text
                Dim NOM_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
                Dim DATE_ENTTRE As String = GunaTextBoxDateArrivee.Text
                Dim DATE_SORTIE As String = GunaTextBoxDateDepart.Text
                Dim HEURE_ENTREE As String = GunaTextBoxHeureArrivee.Text
                Dim HEURE_SORTIE As String = GunaTextBoxHeureDepart.Text
                Dim CHAMBRE_ID As String = Trim(TB_RoomNo.Text)
                Dim NOM_CLIENT As String = TB_Holder.Text
                Dim NUITEES_HOURS As Integer = GunaTextBoxNuits.Text
                Dim MONTANT_ACCORDE As Double = GunaTextBoxPrix.Text
                Dim COMMENTAIRE As String = GunaTextBoxComment.Text

                '-----------------------------------------------------------------------------------

                Dim RESA_TYPE As String = ""

                If GunaLabel13.Text = "HOUR(S)" Then
                    RESA_TYPE = "HOUR(S)"
                ElseIf GunaLabel13.Text = "HEURE(S)" Then
                    RESA_TYPE = "HEURE(S)"
                ElseIf GunaLabel13.Text = "NIGHT(S)" Then
                    RESA_TYPE = "NIGHT(S)"
                ElseIf GunaLabel13.Text = "NUIT(S)" Then
                    RESA_TYPE = "NUITEE(S)"
                End If

                '-----------------------------------------------------------------------------------

                If GlobalVariable.actualLanguageValue = 0 Then
                    whatsAppMessage = "CARD ISSUANCE " & Chr(13) & "-/ BY : " & NOM_UTILISATEUR & Chr(13) & "-/ AT : " & Now().ToShortTimeString & Chr(13) & "-/ ARRIVAL : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & "-/ DEPARTURE : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & "-/ " & RESA_TYPE & " : " & NUITEES_HOURS & Chr(13) & "-/ NAME : " & NOM_CLIENT & Chr(13) & "-/ ROOM : " & CHAMBRE_ID & Chr(13) & "-/ COMMENT :  " & COMMENTAIRE
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    whatsAppMessage = "NOUVELLE CARTE " & Chr(13) & "-/ PAR :  " & NOM_UTILISATEUR & Chr(13) & "-/ A : " & Now().ToShortTimeString & Chr(13) & "-/ ARRIVEE : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & "-/ DEPART : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & "-/ " & RESA_TYPE & " : " & NUITEES_HOURS & Chr(13) & "-/ CLIENT : " & NOM_CLIENT & Chr(13) & "-/ TYPE DE CHAMBRE : " & GunaTextBoxLibelleTYpeChambre.Text & Chr(13) & "-/ CHAMBRE : " & CHAMBRE_ID & Chr(13) & "-/ COMMENTAIRE :  " & COMMENTAIRE
                End If

                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                    Dim mobile_number As String = MainWindow.listeOfTelephoneNumbers()
                    'Functions.ultrMessageSimpleText(whatsAppMessage, mobile_number)

                    Dim args As ArgumentType = New ArgumentType()

                    args.action = 0
                    args.whatsAppMessage = whatsAppMessage
                    args.mobile_number = mobile_number

                    backGroundWorkerToCall(args)

                End If

                Dim nature As Integer = 0
                gestionDesEncodage(CODE_RESERVATION, nature)

                Me.Close()

                GlobalVariable.zenlockForm = ""

            Else

            End If

        End If

    End Sub

    Dim whatsAppMessage As String = ""
    Dim web As New WebBrowser
    Dim web1 As New WebBrowser
    Dim web2 As New WebBrowser
    Dim web3 As New WebBrowser
    Dim web4 As New WebBrowser
    Dim web5 As New WebBrowser

    Private Sub B_DupKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DupKey.Click
        Dim lStatus As Integer
        Dim Port As Integer
        Dim CardNo As Integer
        Dim OverFlag As Integer
        Dim Breakfast As Integer
        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String

        Port = CB_Port.SelectedIndex

        If (CK_Over.Checked) Then
            OverFlag = 1
        Else
            OverFlag = 0
        End If

        Breakfast = CB_Breakfast.SelectedIndex

        RoomNo = TB_RoomNo.Text
        Holder = TB_Holder.Text
        IDNo = TB_IDNo.Text
        TimeStr = TB_Time.Text
        CardNo = 0

        TB_Result.Text = "Executing..."
        TB_Result.Refresh()

        lStatus = DupKey(Port, RoomNo, "", "", TimeStr, Holder, IDNo, Breakfast, OverFlag, CardNo)

        TB_Result.Text = lStatus.ToString("X")

        If (lStatus = 0) Then
            TB_CardNo.Text = CardNo.ToString()
        End If

    End Sub

    Private Sub B_ReadKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ReadKey.Click

        Dim lStatus As Integer
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

        lStatus = ReadKeyCard(Port, RoomNo, Door, lift, TimeStr, Holder, IDNo, CardNo, CardStatus, Breakfast)

        'TB_Result.Text = Hex(lStatus)
        TB_Result.Text = lStatus.ToString("X")

        'lStatus = ReadKeyCard(Port, RoomNo, Door, lift, TimeStr, Holder, IDNo, CardNo, CardStatus, Breakfast)

        'TB_Result.Text = lStatus.ToString("X")

        Dim CODE_RESERVATION As String = GunaTextBoxNumResa.Text

        If (lStatus = 0) Then

            TB_CardNo.Text = CardNo.ToString()
            TB_Status.Text = CardStatus.ToString()
            CB_Breakfast.SelectedIndex = Breakfast

            TB_RoomNo.Text = RoomNo.ToString()
            TB_Holder.Text = Holder.ToString()
            TB_IDNo.Text = IDNo.ToString()
            TB_Time.Text = TimeStr.ToString()

            If Trim(CODE_RESERVATION).Equals("") Then
                CODE_RESERVATION = TB_IDNo.Text
            End If

            If GlobalVariable.zenlockForm = "frontdesk" Then

                Dim infoSupReservation As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                If infoSupReservation.Rows.Count > 0 Then

                    GunaTextBoxLibelleHotel.Text = GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE")
                    'GunaTextBoxPrix.Text = Format(Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("MONTANT_ACCORDE"), "#,##0")
                    GunaTextBoxPrix.Text = Format(infoSupReservation.Rows(0)("MONTANT_ACCORDE"), "#,##0")
                    'TB_Holder.Text = Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("NOM_CLIENT")
                    TB_Holder.Text = infoSupReservation.Rows(0)("NOM_CLIENT")
                    'GunaTextBoxDateArrivee.Text = Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("DATE_ENTTRE")
                    GunaTextBoxDateArrivee.Text = infoSupReservation.Rows(0)("DATE_ENTTRE")
                    'GunaTextBoxDateDepart.Text = Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("DATE_SORTIE")
                    GunaTextBoxDateDepart.Text = infoSupReservation.Rows(0)("DATE_SORTIE")
                    'GunaTextBoxNuits.Text = CType((Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("DATE_SORTIE") - Functions.GetAllElementsOnTwoConditions(TB_RoomNo.Text, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION").Rows(0)("DATE_ENTTRE")).TotalDays, Int32)
                    GunaTextBoxNuits.Text = CType((infoSupReservation.Rows(0)("DATE_SORTIE") - infoSupReservation.Rows(0)("DATE_ENTTRE")).TotalDays, Int32)

                    GunaTextBoxTypeChambre.Text = Functions.getElementByCode(TB_RoomNo.Text, "chambre", "CODE_CHAMBRE").Rows(0)("CODE_TYPE_CHAMBRE")
                    GunaTextBoxLibelleTYpeChambre.Text = Functions.getElementByCode(GunaTextBoxTypeChambre.Text, "type_chambre", "CODE_TYPE_CHAMBRE").Rows(0)("LIBELLE_TYPE_CHAMBRE")

                    GunaTextBoxHeureArrivee.Text = CDate(infoSupReservation.Rows(0)("HEURE_ENTREE")).ToShortTimeString
                    GunaTextBoxHeureDepart.Text = CDate(infoSupReservation.Rows(0)("HEURE_SORTIE")).ToShortTimeString

                    Dim HeureEntree As DateTime = CDate(GunaTextBoxHeureArrivee.Text).ToShortTimeString
                    Dim heureDepart As DateTime = CDate(GunaTextBoxHeureDepart.Text).ToShortTimeString

                    If CDate(GunaTextBoxDateArrivee.Text).ToShortDateString = CDate(GunaTextBoxDateDepart.Text).ToShortDateString Then
                        If GlobalVariable.actualLanguageValue = 0 Then
                            GunaLabel13.Text = "HOUR(S)"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            GunaLabel13.Text = "HEURE(S)"
                        End If

                        GunaTextBoxNuits.Text = (heureDepart - HeureEntree).TotalHours
                    Else
                        If GlobalVariable.actualLanguageValue = 0 Then
                            GunaLabel13.Text = "NIGHT(S)"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            GunaLabel13.Text = "NUITEE(S)"
                        End If

                    End If

                End If

            End If

            '-------------------------------------- MOUCHARDS ---------------------------------------------------
            Dim ACTION As String = ""
            If GlobalVariable.actualLanguageValue = 0 Then
                ACTION = "CARD READ [ROOM " & TB_RoomNo.Text & " / " & TB_Holder.Text & " FROM " & GunaTextBoxDateArrivee.Text & " " & GunaTextBoxHeureArrivee.Text & " - " & GunaTextBoxDateDepart.Text & " " & GunaTextBoxHeureDepart.Text & "] BY " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                ACTION = "LECTURE DE CARTE [CHAMBRE " & TB_RoomNo.Text & " / " & TB_Holder.Text & " DU " & GunaTextBoxDateArrivee.Text & " " & GunaTextBoxHeureArrivee.Text & " - " & GunaTextBoxDateDepart.Text & " " & GunaTextBoxHeureDepart.Text & "] PAR " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

            End If

            User.mouchard(ACTION)
            '----------------------------------------------------------------------------------------------------


            GlobalVariable.zenlockForm = ""

        End If

        Dim NOM_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        Dim DATE_SORTIE As String = ""

        Dim DATE_ENTTRE As String = ""

        Dim HEURE_ENTREE As String = ""

        If Trim(GunaTextBoxDateArrivee.Text).Equals("") Then
            DATE_ENTTRE = GlobalVariable.DateDeTravail
        Else
            DATE_ENTTRE = GunaTextBoxDateArrivee.Text
        End If

        If Trim(GunaTextBoxDateDepart.Text).Equals("") Then
            DATE_SORTIE = GlobalVariable.DateDeTravail
        Else
            DATE_SORTIE = GunaTextBoxDateDepart.Text
        End If

        If Trim(GunaTextBoxHeureArrivee.Text).Equals("") Then
            HEURE_ENTREE = Now().ToShortTimeString
        Else
            HEURE_ENTREE = GunaTextBoxHeureArrivee.Text
        End If

        Dim HEURE_SORTIE As String = GunaTextBoxHeureDepart.Text

        If Trim(GunaTextBoxHeureArrivee.Text).Equals("") Then
            HEURE_SORTIE = Now().ToShortTimeString
        Else
            HEURE_SORTIE = GunaTextBoxHeureDepart.Text
        End If

        Dim CHAMBRE_ID As String = Trim(TB_RoomNo.Text)
        Dim NOM_CLIENT As String = TB_Holder.Text

        Dim NUITEES As Integer = 0

        If Not Trim(GunaTextBoxNuits.Text).Equals("") Then
            NUITEES = GunaTextBoxNuits.Text
        End If

        Dim MONTANT_ACCORDE As Double = 0

        If Not Trim(GunaTextBoxPrix.Text).Equals("") Then
            MONTANT_ACCORDE = GunaTextBoxPrix.Text
        End If

        Dim COMMENTAIRE As String = GunaTextBoxComment.Text

        Dim RESA_TYPE As String = ""

        If GunaLabel13.Text = "HOUR(S)" Then
            RESA_TYPE = "HOUR(S)"
        ElseIf GunaLabel13.Text = "HEURE(S)" Then
            RESA_TYPE = "HEURE(S)"
        ElseIf GunaLabel13.Text = "NIGHT(S)" Then
            RESA_TYPE = "NIGHT(S)"
        ElseIf GunaLabel13.Text = "NUIT(S)" Then
            RESA_TYPE = "NUITEE(S)"
        End If

        If GlobalVariable.actualLanguageValue = 0 Then

            If Trim(RoomNo).Equals("") Then
                whatsAppMessage = "CARD READING" & Chr(13) & "-/ BY : " & NOM_UTILISATEUR & Chr(13) & "-/ AT : " & Now().ToShortTimeString
            Else
                whatsAppMessage = "CARD READING" & Chr(13) & "-/ BY :  " & NOM_UTILISATEUR & Chr(13) & "-/ AT : " & Now().ToShortTimeString & Chr(13) & "-/ ARRIVAL : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & "-/ DEPARTURE : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & "-/ " & RESA_TYPE & " : " & NUITEES & Chr(13) & "-/ NAME : " & NOM_CLIENT & Chr(13) & "-/ ROOM TYPE : " & GunaTextBoxLibelleTYpeChambre.Text & Chr(13) & "-/ ROOM : " & CHAMBRE_ID & Chr(13) & "-/ COMMENT :  " & COMMENTAIRE
            End If

        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            If Trim(RoomNo).Equals("") Then
                whatsAppMessage = "LECTURE DE CARTE " & Chr(13) & "-/ PAR : " & NOM_UTILISATEUR & " A : " & Now().ToShortTimeString
            Else
                whatsAppMessage = "LECTURE DE CARTE " & Chr(13) & "-/ PAR : " & NOM_UTILISATEUR & Chr(13) & "-/ A : " & Now().ToShortTimeString & Chr(13) & "-/ ARRIVEE : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & "-/ DEPART : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & "-/ " & RESA_TYPE & " : " & NUITEES & Chr(13) & "-/ CLIENT : " & NOM_CLIENT & Chr(13) & "-/ TYPE DE CHAMBRE : " & GunaTextBoxLibelleTYpeChambre.Text & Chr(13) & "-/ CHAMBRE : " & CHAMBRE_ID & Chr(13) & "-/ COMMENTAIRE :  " & COMMENTAIRE
            End If
        End If

        If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
            Dim mobile_number As String = MainWindow.listeOfTelephoneNumbers()

            'Functions.ultrMessageSimpleText(whatsAppMessage, mobile_number)
            'klg
            Dim args As ArgumentType = New ArgumentType()

            args.action = 0
            args.whatsAppMessage = whatsAppMessage
            args.mobile_number = mobile_number

            backGroundWorkerToCall(args)

        End If

            Dim nature As Integer = 1

        gestionDesEncodage(CODE_RESERVATION, nature)

    End Sub

    Private Sub B_EraseKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_EraseKey.Click

        Dim lStatus As Integer
        Dim Port As Integer
        Dim CardNo As Integer

        Port = CB_Port.SelectedIndex

        If IsNumeric(TB_CardNo.Text) Then
            CardNo = Val(TB_CardNo.Text)
        Else
            CardNo = 0
        End If

        TB_Result.Text = "Executing..."

        TB_Result.Refresh()

        lStatus = EraseKeyCard(Port, CardNo)

        TB_Result.Text = lStatus.ToString("X")

        '----------------------------------------------------------------------------------------------------

        '-------------------------------------- MOUCHARDS ---------------------------------------------------
        Dim ACTION As String = ""
        If GlobalVariable.actualLanguageValue = 0 Then
            ACTION = "CARD ERASEMENT [ROOM " & TB_RoomNo.Text & " / " & TB_Holder.Text & " FROM " & GunaTextBoxDateArrivee.Text & " " & GunaTextBoxHeureArrivee.Text & " - " & GunaTextBoxDateDepart.Text & " " & GunaTextBoxHeureDepart.Text & "]"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            ACTION = "EFFACEMENT DE CARTE [CHAMBRE " & TB_RoomNo.Text & " / " & TB_Holder.Text & " DU " & GunaTextBoxDateArrivee.Text & " " & GunaTextBoxHeureArrivee.Text & " - " & GunaTextBoxDateDepart.Text & " " & GunaTextBoxHeureDepart.Text & "]"

        End If

        User.mouchard(ACTION)
        '----------------------------------------------------------------------------------------------------

        ' If GlobalVariable.infoReservationPourEncodage.Rows.Count > 0 Then

        'If lStatus = 0 Then

        Dim CODE_RESERVATION As String = GunaTextBoxNumResa.Text

        If Trim(CODE_RESERVATION).Equals("") Then
            CODE_RESERVATION = TB_IDNo.Text
        End If

        Dim NOM_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        Dim DATE_ENTTRE As String = GunaTextBoxDateArrivee.Text
        Dim DATE_SORTIE As String = GunaTextBoxDateDepart.Text
        Dim HEURE_ENTREE As String = GunaTextBoxHeureArrivee.Text
        Dim HEURE_SORTIE As String = GunaTextBoxHeureDepart.Text
        Dim CHAMBRE_ID As String = Trim(TB_RoomNo.Text)
        Dim NOM_CLIENT As String = TB_Holder.Text

        Dim NUITEES As Integer = 0

        If Not Trim(GunaTextBoxNuits.Text).Equals("") Then
            NUITEES = GunaTextBoxNuits.Text
        End If

        Dim COMMENTAIRE As String = GunaTextBoxComment.Text

        Dim RESA_TYPE As String = ""

        If GunaLabel13.Text = "HOUR(S)" Then
            RESA_TYPE = "HOUR(S)"
        ElseIf GunaLabel13.Text = "HEURE(S)" Then
            RESA_TYPE = "HEURE(S)"
        ElseIf GunaLabel13.Text = "NIGHT(S)" Then
            RESA_TYPE = "NIGHT(S)"
        ElseIf GunaLabel13.Text = "NUIT(S)" Then
            RESA_TYPE = "NUITEE(S)"
        End If

        If GlobalVariable.actualLanguageValue = 0 Then
            whatsAppMessage = "CARD CANCELLATION " & Chr(13) & "-/ BY :  " & NOM_UTILISATEUR & Chr(13) & "-/ AT : " & Now().ToShortTimeString & Chr(13) & "-/ ARRIVAL : " & DATE_ENTTRE & " " & HEURE_ENTREE & Chr(13) & "-/ DEPARTURE : " & DATE_SORTIE & " " & HEURE_SORTIE & Chr(13) & "-/ " & RESA_TYPE & " : " & NUITEES & Chr(13) & "-/ CLIENT : " & NOM_CLIENT & Chr(13) & "-/ ROOM TYPE : " & GunaTextBoxLibelleTYpeChambre.Text & Chr(13) & "-/ ROOM : " & CHAMBRE_ID & Chr(13) & "-/ COMMENT :  " & COMMENTAIRE
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            whatsAppMessage = "EFFACEMENT DE CARTE " & Chr(13) & "-/ PAR : " & NOM_UTILISATEUR & Chr(13) & "-/ A : " & Now().ToShortTimeString & Chr(13) & "-/ ARRIVEE : " & DATE_ENTTRE & " " & HEURE_ENTREE & Chr(13) & "-/ DEPART : " & DATE_SORTIE & " " & HEURE_SORTIE & Chr(13) & "-/ " & RESA_TYPE & " : " & NUITEES & Chr(13) & "-/ CLIENT : " & NOM_CLIENT & Chr(13) & "-/ TYPE DE CHAMBRE : " & GunaTextBoxLibelleTYpeChambre.Text & Chr(13) & "-/ CHAMBRE : " & CHAMBRE_ID & Chr(13) & "-/ COMMENTAIRE :  " & COMMENTAIRE
        End If

        If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

            Dim mobile_number As String = MainWindow.listeOfTelephoneNumbers()

            'Functions.ultrMessageSimpleText(whatsAppMessage, mobile_number)

            Dim args As ArgumentType = New ArgumentType()

            args.action = 0
            args.whatsAppMessage = whatsAppMessage
            args.mobile_number = mobile_number

            backGroundWorkerToCall(args)

        End If

        Dim nature As Integer = 2
        gestionDesEncodage(CODE_RESERVATION, nature)

        'Functions.SiplifiedClearTextBox(Me)

    End Sub

    Private Sub B_CheckOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_CheckOut.Click

        Dim lStatus As Integer
        Dim CardNo As Integer
        Dim RoomNo As String

        If IsNumeric(TB_CardNo.Text) Then
            CardNo = Val(TB_CardNo.Text)
        Else
            CardNo = 0
        End If

        RoomNo = TB_RoomNo.Text

        TB_Result.Text = "Executing..."
        TB_Result.Refresh()

        lStatus = CheckOut(RoomNo, CardNo)

        TB_Result.Text = lStatus.ToString("X")

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        EndSession()
    End Sub

    Private Sub CB_DB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_DB.SelectedIndexChanged

        If (CB_DB.SelectedIndex = 0) Then
            If (CB_Software.SelectedIndex = 0) Then
                tb_server.Text = cheminLockSystem
            Else
                tb_server.Text = cheminLockSystem
            End If
        Else
            tb_server.Text = "(local)"
        End If

    End Sub

    Private Sub CB_Software_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Software.SelectedIndexChanged

        If (CB_DB.SelectedIndex = 0) Then
            If (CB_Software.SelectedIndex = 0) Then
                tb_server.Text = cheminLockSystem
            Else
                tb_server.Text = cheminLockSystem
            End If
        End If

    End Sub

    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButton2.Click
        GlobalVariable.zenlockForm = ""
        Dim lStatus As Integer

        TB_Result.Text = "Executing..."

        TB_Result.Refresh()

        lStatus = EndSession()

        TB_Result.Text = lStatus.ToString("X")

        Me.Close()

    End Sub

    Private Sub TB_Result_TextChanged(sender As Object, e As EventArgs) Handles TB_Result.TextChanged

        If TB_Result.Text = "0" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "SUCCESSFUL OPERATION"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Opération réussie"
            End If

        ElseIf TB_Result.Text = "FFFF0001" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "CARD ERROR"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Erreur de carte"
            End If

        ElseIf TB_Result.Text = "FFFF0003" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "EMPTY CARD"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Carte vierge"
            End If

        ElseIf TB_Result.Text = "FFFF0005" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "GROUP CARD"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Carte de groupe"
            End If

        ElseIf TB_Result.Text = "FFFF0007" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "LOADED CARD"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Carte chargée"
            End If

        ElseIf TB_Result.Text = "FFFF3002" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "SETTING DOES NOT EXIST"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Le paramètre système n'existe pas"
            End If

        ElseIf TB_Result.Text = "FFFF3001" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "SQL CONNECTION ERROR"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Erreur de connexion SQL"
            End If

        ElseIf TB_Result.Text = "FFFF1001" Then

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "THE INITIALISATION FONCTION HAS NOT BEEN INVOKED"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "La fonction d'initialisation n'a pas été invoquée"

            End If

        ElseIf TB_Result.Text = "FFFF0008" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "PLEASE PLUG THE ENCODER"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Bien vouloir Brancher l'encodeur"
            End If

        ElseIf TB_Result.Text = "FFFF0009" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "PORT COM ERROR"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Erreur de port COM"
            End If

        ElseIf TB_Result.Text = "FFFF0005" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "GROUP CARD"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Carte de groupe"
            End If

        ElseIf TB_Result.Text = "FFFF1003" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "NO EXISTING INFORMATION"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Information Inexistante"
            End If

        ElseIf TB_Result.Text = "FFFF0002 " Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "CARD REPLACED"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Carte remplacée"
            End If

        ElseIf TB_Result.Text = "FFFF0006 " Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "EMPTY GROUP CARD"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Carte de groupe vierge"
            End If

        ElseIf TB_Result.Text = "FFFF0008" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "OPENED PORT COM ERROR"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Erreur de port COM ouvert"
            End If

        ElseIf TB_Result.Text = "FFFF1001 " Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "Session not established"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Session non établie"
            End If

        ElseIf TB_Result.Text = "FFFF1002 " Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "No Name associated to the reservation"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Aucun Nom associé à la réservation"
            End If

        ElseIf TB_Result.Text = "FFFF1005" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "Wrong room number"
            Else
                GunaTextBoxSenseDuMessage.Text = "Mauvais numéro de chambre"
            End If

        ElseIf TB_Result.Text = "FFFF4000" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "The interface authentifiaction code does not exist (Register the DLL)"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Le code de l'interterface d'authentification n'existe pas (Enregister la DLL)"
            End If
            '
            'SOLUTION
            'ENREGISTRER LA DLL
        ElseIf TB_Result.Text = "FFFF4001" Then
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "Wrong interface authentification code" '
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "Mauvais code d'authentification d'interface" '
            End If

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaTextBoxSenseDuMessage.Text = "..." '
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxSenseDuMessage.Text = "..." '
            End If
        End If

    End Sub

    'ENREGISTREMENT DU CHEMIN
    Private Sub GunaButtonChemin_Click(sender As Object, e As EventArgs) Handles GunaButtonChemin.Click

        Dim updateQuery As String = "UPDATE `agence` SET CHEMIN_HOTEL_LOCK_SYSTEM=@CHEMIN_HOTEL_LOCK_SYSTEM WHERE CODE_AGENCE = @CODE_AGENCE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        Dim CHEMIN_HOTEL_LOCK_SYSTEM As String = tb_server.Text

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@CHEMIN_HOTEL_LOCK_SYSTEM", MySqlDbType.VarChar).Value = CHEMIN_HOTEL_LOCK_SYSTEM

        command.ExecuteNonQuery()

        If GlobalVariable.actualLanguageValue = 0 Then
            MessageBox.Show("Path successfully saved !!")
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            MessageBox.Show("Chemin enregisté avec succès !!")
        End If

        MainWindow.Activate()

    End Sub

    Private Sub listeDesTypeDeChanmbre()

        Dim queryDepart As String = "SELECT * FROM type_chambre WHERE TYPE=@TYPE ORDER BY LIBELLE_TYPE_CHAMBRE ASC"

        Dim command As New MySqlCommand(queryDepart, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            GunaComboBoxTypeDeChambre.DataSource = table
            GunaComboBoxTypeDeChambre.DisplayMember = "LIBELLE_TYPE_CHAMBRE"
            GunaComboBoxTypeDeChambre.ValueMember = "CODE_TYPE_CHAMBRE"

        End If

    End Sub

    Private Sub listeDesChanmbre(ByVal CODE_TYPE_CHAMBRE As String)

        Dim queryDepart As String = "SELECT * FROM chambre WHERE CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE ORDER BY LIBELLE_CHAMBRE ASC"

        Dim command As New MySqlCommand(queryDepart, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            GunaComboBoxRoomNUmber.DataSource = table
            GunaComboBoxRoomNUmber.ValueMember = "CODE_CHAMBRE"
            GunaComboBoxRoomNUmber.DisplayMember = "CODE_CHAMBRE"


        End If

    End Sub

    Private Sub GunaCheckBoxVisite_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxVisite.CheckedChanged

        If GunaCheckBoxVisite.Checked Then

            listeDesTypeDeChanmbre()

            GunaComboBoxTypeDeChambre.SelectedIndex = -1

            GunaTextBoxComment.Text = "VISITE"
            GunaLabel13.Text = "MINUTES"

            GunaTextBoxDateArrivee.Text = GlobalVariable.DateDeTravail.ToShortDateString
            GunaTextBoxDateDepart.Text = GlobalVariable.DateDeTravail.ToShortDateString
            GunaTextBoxHeureArrivee.Text = Now().ToShortTimeString
            GunaTextBoxHeureDepart.Text = Now().ToShortTimeString

            Dim dateArrive As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
            Dim dateDepart As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
            Dim HeureEntree As DateTime = CDate(Now()).ToShortTimeString
            Dim heureDepart As DateTime = CDate(Now()).ToShortTimeString

            TB_Time.Text = dateArrive.ToString("yyyyMMdd") + HeureEntree.ToString("HHmm") + dateDepart.ToString("yyyyMMdd") + heureDepart.ToString("HHmm")

            GunaElipsePanelVisite.Visible = True

            B_NewKey.Enabled = True

        Else

            Dim nombreDeNuiteAEncoder As Integer = 0

            Dim DATE_ENTTRE As Date = MainWindow.GunaDateTimePickerArrivee.Value.ToShortDateString()

            Dim DATE_DE_TRAVAIL As Date = GlobalVariable.DateDeTravail.ToShortDateString()

            Dim CODE_RESERVATION As String = MainWindow.GunaLabelNumReservation.Text
            nombreDeNuiteAEncoder = Functions.nombreDeJourAInsererDansLEncodeur(DATE_ENTTRE, DATE_DE_TRAVAIL, CODE_RESERVATION)

            If GlobalVariable.AgenceActuelle.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 Then

                If nombreDeNuiteAEncoder <= 0 Then
                    B_NewKey.Enabled = False
                Else
                    B_NewKey.Enabled = True
                End If

            Else
                B_NewKey.Enabled = True
            End If

            GunaElipsePanelVisite.Visible = False
            GunaTextBoxComment.Clear()
            GunaTextBoxNuits.Clear()
            GunaTextBoxHeureArrivee.Clear()
            GunaTextBoxHeureDepart.Clear()
            GunaLabel13.Text = "NUIT(S)"

            TB_RoomNo.Clear()
            GunaTextBoxLibelleChambre.Clear()
            GunaTextBoxTypeChambre.Clear()
            GunaTextBoxLibelleTYpeChambre.Clear()

            GunaTextBoxDateArrivee.Clear()
            GunaTextBoxDateDepart.Clear()
            TB_Time.Clear()

        End If

    End Sub

    Private Sub GunaComboBoxMinutes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxMinutes.SelectedIndexChanged

        If GunaComboBoxMinutes.SelectedIndex >= 0 Then

            Dim tempsAFaire As Integer = GunaComboBoxMinutes.SelectedItem

            GunaTextBoxNuits.Text = tempsAFaire

            GunaTextBoxHeureArrivee.Text = Now().ToShortTimeString

            GunaTextBoxHeureDepart.Text = Now().AddMinutes(tempsAFaire).ToShortTimeString

            Dim dateArrive As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
            Dim dateDepart As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
            Dim HeureEntree As DateTime = CDate(Now()).ToShortTimeString
            Dim heureDepart As DateTime = Now().AddMinutes(tempsAFaire).ToShortTimeString

            TB_Time.Text = dateArrive.ToString("yyyyMMdd") + HeureEntree.ToString("HHmm") + dateDepart.ToString("yyyyMMdd") + heureDepart.ToString("HHmm")

        End If

    End Sub

    Private Sub GunaComboBoxTypeDeChambre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeChambre.SelectedIndexChanged

        If GunaComboBoxTypeDeChambre.SelectedIndex >= 0 Then

            GunaTextBoxTypeChambre.Text = GunaComboBoxTypeDeChambre.SelectedValue.ToString

            Dim infoSupType As DataTable = Functions.getElementByCode(GunaComboBoxTypeDeChambre.SelectedValue.ToString, "type_chambre", "CODE_TYPE_CHAMBRE")

            If infoSupType.Rows.Count > 0 Then
                GunaTextBoxLibelleTYpeChambre.Text = infoSupType.Rows(0)("LIBELLE_TYPE_CHAMBRE")
            End If

            listeDesChanmbre(GunaComboBoxTypeDeChambre.SelectedValue.ToString)

            GunaComboBoxRoomNUmber.SelectedIndex = -1

        End If

    End Sub

    Private Sub GunaComboBoxRoomNUmber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxRoomNUmber.SelectedIndexChanged

        If GunaComboBoxRoomNUmber.SelectedIndex >= 0 Then

            TB_RoomNo.Text = GunaComboBoxRoomNUmber.SelectedValue.ToString

            Dim infoSupType As DataTable = Functions.getElementByCode(GunaComboBoxRoomNUmber.SelectedValue.ToString, "chambre", "CODE_CHAMBRE")

            If infoSupType.Rows.Count > 0 Then
                GunaTextBoxLibelleChambre.Text = infoSupType.Rows(0)("LIBELLE_CHAMBRE")
            End If

        Else
            TB_RoomNo.Text = ""
        End If

    End Sub

    Private Sub gestionDesEncodage(ByVal CODE_RESERVATION As String, ByVal nature As Integer)

        'nature : 0 = ENCODAGE
        'nature : 1 = LECTURE
        'nature : 2 = EFFACEMENT

        Dim infoSupResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "suivi_des_encodages", "CODE_RESERVATION")

        Dim resa_conf As New Reservation()

        If Not infoSupResa.Rows.Count > 0 Then

            If nature = 0 Then
                resa_conf.insertionSuiviEncodage(CODE_RESERVATION)
            End If

        End If

        Dim updateSuivie As Boolean = False

        'ON NE DOIT PAS METTRE AJOURS SI LES INFORMATIONS ON DEJA ETE INTRODUITES

        infoSupResa = Functions.getElementByCode(CODE_RESERVATION, "suivi_des_encodages", "CODE_RESERVATION")

        If infoSupResa.Rows.Count > 0 Then

            If nature = 0 Then
                If Trim(infoSupResa.Rows(0)("HEURE_ENCODAGE")).Equals("") Then
                    updateSuivie = True
                End If
            ElseIf nature = 1 Then
                If Trim(infoSupResa.Rows(0)("HEURE_LECTURE")).Equals("") Then
                    updateSuivie = True
                End If
            ElseIf nature = 2 Then
                If Trim(infoSupResa.Rows(0)("HEURE_EFFACEMENT")).Equals("") Then
                    updateSuivie = True
                End If
            End If

            If updateSuivie Then
                resa_conf.updateDesInformationsEncodage(CODE_RESERVATION, nature)
            End If

        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then

            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)

        End If

    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker6_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker6.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker7_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker7.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker8_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker8.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker9_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker9.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker10_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker10.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    '-----------------------------------

    Private Sub BackgroundWorker11_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker11.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker12_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker12.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker13_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker13.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker14_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker14.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    Private Sub BackgroundWorker15_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker15.DoWork

        Dim args As ArgumentType = e.Argument

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

    End Sub

    '-----------------------------------

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        BackgroundWorker3.Dispose()
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        BackgroundWorker3.Dispose()
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        BackgroundWorker3.Dispose()
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

End Class