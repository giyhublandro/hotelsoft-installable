Imports System.Net.NetworkInformation

Public Class HomeForm

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButtonClose.Click
        Application.ExitThread()
    End Sub

    Private Sub GunaImageButtonMinimized_Click(sender As Object, e As EventArgs) Handles GunaImageButtonMinimized.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'MODULE RESERVATION
    Private Sub reception_Click(sender As Object, e As EventArgs) Handles GunaButtonReservation.Click, GunaButtonMenuReservation.Click

        Me.Cursor = Cursors.WaitCursor

        MainWindow.TabControlHbergement.SelectedIndex = 1

        MainWindow.GunaShadowPanelReservation.Show()
        MainWindow.PanelEnregistrement.Show()

        MainWindow.GunaShadowPanelReception.Hide()
        MainWindow.PanelTableauDeBords.Hide()

        MainWindow.Show()

        If GlobalVariable.AgenceActuelle.Rows(0)("RAPPORT_AUTO") = 0 Then 'SI LE RAPPORT N'A PAS DEJA ETE ENVOYE

            backGroundWorkerToCall()
            BackgroundWorker4.RunWorkerAsync()

            Me.Hide()

        Else
            Me.Close()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    'MODULE RECEPTION
    Private Sub GunaButtonMenuReception_Click(sender As Object, e As EventArgs) Handles GunaButtonMenuReception.Click

        Me.Cursor = Cursors.WaitCursor

        GlobalVariable.affichageDuStatutsDesCahmbresOuPas = False

        MainWindow.PanelTableauDeBords.Show()
        MainWindow.GunaShadowPanelReception.Show()

        MainWindow.GunaShadowPanelReservation.Hide()
        MainWindow.PanelEnregistrement.Hide()

        MainWindow.Show()

        If GlobalVariable.AgenceActuelle.Rows(0)("rapport_auto") = 0 Then
            backGroundWorkerToCall()
            Me.Hide()
        Else
            Me.Close()
        End If
        'choixDeMagasinOuPas()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonLectureDeCarte_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonLectureDeCarte.Click

        Me.Cursor = Cursors.WaitCursor

        'MainWindow.PanelTableauDeBords.Hide()
        'MainWindow.GunaShadowPanelReception.Hide()

        'MainWindow.GunaShadowPanelReservation.Show()
        'MainWindow.PanelEnregistrement.Show()

        'MainWindow.Show()

        'MainWindow.LectureDeCarte()

        'Me.Close()


        If True Then

            GlobalVariable.zenlockForm = "frontdesk"
            ZenoLockForm.Close()
            ZenoLockForm.Show()
            ZenoLockForm.TopMost = True

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonServiceEtage_Click(sender As Object, e As EventArgs) Handles GunaButtonServiceEtage.Click, GunaButtonMenuService.Click

        Me.Cursor = Cursors.WaitCursor

        GlobalVariable.typeChambreOuSalle = "chambre"

        'RoomForm.TopMost = True
        'RoomForm.Location = New System.Drawing.Point(10, 110)
        'RoomForm.Show()
        MainWindowServiceEtageForm.TabControlRoomForm.SelectedIndex = 6
        MainWindowServiceEtageForm.LabelLibelleActif.Text = "NETTOYAGE DES CHAMBRES"
        MainWindowServiceEtageForm.Visible = True

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonBarResturant_Click(sender As Object, e As EventArgs) Handles GunaButtonBarResturant.Click, GunaButtonMenuBarRestaurant.Click

        Me.Cursor = Cursors.WaitCursor

        GlobalVariable.typeDeClientAFacturer = "comptoir"

        If Trim(GlobalVariable.AgenceActuelle.Rows(0)("CAISSE_ENREGISTREUSE_1")).Equals("") Then

        Else

        End If

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_ENREGISTREUSE") = 1 Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FAST_FOOD") = 1 Then
                FastFoodForm.Show()
                FastFoodForm.TopMost = True
            Else
                BarRestaurantCaisseEnregistreuseForm.Show()
            End If

        Else

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FAST_FOOD") = 1 Then
                FastFoodForm.Show()
                FastFoodForm.TopMost = True
            Else
                BarRestaurantForm.Show()
                FastFoodForm.TopMost = True
            End If

        End If

        'FastFoodForm.Close()
        'BarRestaurantForm.Show()

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonCompatbilite_Click(sender As Object, e As EventArgs) Handles GunaButtonCompatbilite.Click, GunaButtonMenuComptabilite.Click

        Me.Cursor = Cursors.WaitCursor
        MainWindowComptabiliteForm.Visible = True

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonEconomat_Click(sender As Object, e As EventArgs) Handles GunaButtonEconomat.Click, GunaButtonMenuEconomat.Click

        Me.Cursor = Cursors.WaitCursor
        MainWindowEconomat.Show()

        Me.Close()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim languages As New Languages()
        languages.home(GlobalVariable.actualLanguageValue)

        'AccueilForm.Hide()
        AccueilForm.Close()

        'On vérifie si on a des droit
        'Si oui
        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_RESERVATION") = 0 Then
                GunaButtonMenuReservation.Enabled = False
                GunaButtonReservation.Enabled = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_RECEPTION") = 0 Then
                GunaButtonMenuReception.Enabled = False
                GunaButtonReception.Enabled = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_ECONOMAT") = 0 Then
                GunaButtonMenuEconomat.Enabled = False
                GunaButtonEconomat.Enabled = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_SERVICE_ETAGE") = 0 Then
                GunaButtonMenuService.Enabled = False
                GunaButtonServiceEtage.Enabled = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_BAR_RESTAURANT") = 0 Then
                GunaButtonMenuBarRestaurant.Enabled = False
                GunaButtonBarResturant.Enabled = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_COMPTABILITE") = 0 Then
                GunaButtonMenuComptabilite.Enabled = False
                GunaButtonCompatbilite.Enabled = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_TECHNIQUE") = 0 Then
                GunaButtonMenuTechnique.Enabled = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_CUISINE") = 0 Then
                GunaButtonCuisine.Enabled = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_MARKETING") = 0 Then
                GunaButtonMarketing.Enabled = False
            End If

        End If

        If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then
            GunaPictureBoxRestaurant.Visible = False
            GunaPictureBoxHotel.Visible = True
        Else
            GunaPictureBoxRestaurant.Visible = True
            GunaPictureBoxHotel.Visible = False

            GunaButtonAccueil1.Visible = False
            GunaButtonAccueil.Visible = False
            GunaButtonMenuReception.Visible = False
            GunaButtonMenuReservation.Visible = False
            GunaButtonMenuTechnique.Visible = False
            GunaButtonMenuService.Visible = False
            GunaAdvenceButtonLectureDeCarte.Visible = False

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaLabel2.Text = "MODULE OF BARCLES RESTAURANT SOFT"
            Else
                GunaLabel2.Text = "MODULE DE BARCLES RESTAURANT SOFT"
            End If

        End If

        'AccueilForm.Close()

        Dim CODE_UTILISATEUR_MAJ As String = ""
        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim infoUser As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "utilisateur_acces_profil", "CODE_UTILISATEUR")

        If infoUser.Rows.Count > 1 Then

            GunaButtonMenuReservation.Enabled = False
            GunaButtonReservation.Enabled = False

            GunaButtonMenuReception.Enabled = False
            GunaButtonReception.Enabled = False

            GunaButtonMenuEconomat.Enabled = False
            GunaButtonEconomat.Enabled = False

            GunaButtonMenuService.Enabled = False
            GunaButtonServiceEtage.Enabled = False

            GunaButtonMenuBarRestaurant.Enabled = False
            GunaButtonBarResturant.Enabled = False

            GunaButtonMenuComptabilite.Enabled = False
            GunaButtonCompatbilite.Enabled = False

            GunaButtonMenuTechnique.Enabled = False
            GunaButtonCuisine.Enabled = False
            GunaButtonMarketing.Enabled = False

            GunaButtonChoixProfil.Visible = True

        End If

        Dim showCustomImage As Boolean = False

        If GlobalVariable.AgenceActuelle.Rows(0)("CONFIG") = 1 Then
            If GlobalVariable.config.Rows.Count > 0 Then
                showCustomImage = True
            End If
        End If

        If showCustomImage Then

            GunaPictureBoxHotel.Visible = False
            GunaPictureBoxRestaurant.Visible = False
            GunaPictureBoxPerso.Visible = True

            If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaLabel2.Text = "MODULES OF LYTECORE HOTEL"
                Else
                    GunaLabel2.Text = "MODULES DE LYTECORE HOTEL"
                End If
            Else
                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaLabel2.Text = "MODULES OF LYTECORE RESTAURANT"
                Else
                    GunaLabel2.Text = "MODULES DE LYTECORE RESTAURANT"
                End If
            End If

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
                GunaPanel1.BackColor = Color.FromName(paramCouleur(0))
                GunaPanel3.BackColor = Color.FromName(paramCouleur(0))
            Else
                GunaPanel1.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                GunaPanel3.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
            End If

            'GunaPictureBoxPerso.BringToFront()
            'GunaLabelHotelName.Text = GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE")
            'GunaLabelHotelName.BringToFront()

            PictureBox2.Image = Global.BarclesHSoft.My.Resources.Resources.h1

        End If
    End Sub

    Private Sub GunaButton45_Click(sender As Object, e As EventArgs) Handles GunaButtonAccueil.Click

        GunaAdvenceButtonLectureDeCarte.Visible = False
        GunaButtonAccueil.Visible = False

        GunaButtonAccueil1.Visible = True

        GunaButtonReservation.Visible = True
        GunaButton7.Visible = True
        GunaButton8.Visible = True
        GunaButton9.Visible = True
        GunaButton10.Visible = True
        GunaButton11.Visible = True
        GunaButton12.Visible = True
        GunaButton33.Visible = True

        GunaButtonReception.Visible = True
        GunaButton21.Visible = True
        GunaButton22.Visible = True
        GunaButton6.Visible = True
        GunaButton23.Visible = True
        GunaButton24.Visible = True
        GunaButton25.Visible = True
        GunaButton28.Visible = True

        GunaButtonServiceEtage.Visible = True
        GunaButton31.Visible = True
        GunaButton30.Visible = True
        GunaButton29.Visible = True
        GunaButton37.Visible = True
        GunaButton38.Visible = True
        GunaButton39.Visible = True
        GunaButton40.Visible = True

        GunaButtonBarResturant.Visible = True
        GunaButton5.Visible = True
        GunaButton26.Visible = True
        GunaButton27.Visible = True
        GunaButton34.Visible = True
        GunaButton41.Visible = True
        GunaButton42.Visible = True
        GunaButton43.Visible = True

        GunaButtonCompatbilite.Visible = True
        GunaButton13.Visible = True
        GunaButton14.Visible = True
        GunaButton15.Visible = True
        GunaButton16.Visible = True
        GunaButton35.Visible = True
        GunaButton49.Visible = True
        GunaButton48.Visible = True

        GunaButtonEconomat.Visible = True
        GunaButton17.Visible = True
        GunaButton18.Visible = True
        GunaButton19.Visible = True
        GunaButton20.Visible = True
        GunaButton36.Visible = True
        GunaButton50.Visible = True
        GunaButton51.Visible = True


    End Sub

    Private Sub GunaButtonAccueil1_Click(sender As Object, e As EventArgs) Handles GunaButtonAccueil1.Click

        GunaAdvenceButtonLectureDeCarte.Visible = True

        GunaButtonAccueil.Visible = True

        GunaButtonAccueil1.Visible = False

        GunaButtonReservation.Visible = False

        GunaButtonReservation.Visible = False
        GunaButton7.Visible = False
        GunaButton8.Visible = False
        GunaButton9.Visible = False
        GunaButton10.Visible = False
        GunaButton11.Visible = False
        GunaButton12.Visible = False
        GunaButton33.Visible = False

        GunaButtonReception.Visible = False
        GunaButton21.Visible = False
        GunaButton22.Visible = False
        GunaButton6.Visible = False
        GunaButton23.Visible = False
        GunaButton24.Visible = False
        GunaButton25.Visible = False
        GunaButton28.Visible = False

        GunaButtonServiceEtage.Visible = False
        GunaButton31.Visible = False
        GunaButton30.Visible = False
        GunaButton29.Visible = False
        GunaButton37.Visible = False
        GunaButton38.Visible = False
        GunaButton39.Visible = False
        GunaButton40.Visible = False

        GunaButtonBarResturant.Visible = False
        GunaButton5.Visible = False
        GunaButton26.Visible = False
        GunaButton27.Visible = False
        GunaButton34.Visible = False
        GunaButton41.Visible = False
        GunaButton42.Visible = False
        GunaButton43.Visible = False

        GunaButtonCompatbilite.Visible = False
        GunaButton13.Visible = False
        GunaButton14.Visible = False
        GunaButton15.Visible = False
        GunaButton16.Visible = False
        GunaButton35.Visible = False
        GunaButton49.Visible = False
        GunaButton48.Visible = False

        GunaButtonEconomat.Visible = False
        GunaButton17.Visible = False
        GunaButton18.Visible = False
        GunaButton19.Visible = False
        GunaButton20.Visible = False
        GunaButton36.Visible = False
        GunaButton50.Visible = False
        GunaButton51.Visible = False

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonMenuTechnique.Click

        Me.Cursor = Cursors.WaitCursor
        MainWindowTechnique.Visible = True

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonReception_Click(sender As Object, e As EventArgs) Handles GunaButtonReception.Click

        Me.Cursor = Cursors.WaitCursor

        MainWindow.TabControlHbergement.SelectedIndex = 0

        MainWindow.GunaShadowPanelReservation.Hide()
        MainWindow.PanelEnregistrement.Hide()

        GlobalVariable.affichageDuStatutsDesCahmbresOuPas = True

        MainWindow.GunaShadowPanelReception.Show()
        MainWindow.PanelTableauDeBords.Show()

        MainWindow.Show()

        Me.Hide()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButtonCuisine_Click(sender As Object, e As EventArgs) Handles GunaButtonCuisine.Click

        Me.Cursor = Cursors.WaitCursor

        MainWindowCuisineForm.Show()

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Public Sub backGroundWorkerToCall()

        If Not BackgroundWorker2.IsBusy Then
            BackgroundWorker2.RunWorkerAsync()
        ElseIf Not BackgroundWorker3.IsBusy Then
            BackgroundWorker3.RunWorkerAsync()
        ElseIf Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        ElseIf Not BackgroundWorker5.IsBusy Then
            BackgroundWorker5.RunWorkerAsync()
        ElseIf Not BackgroundWorker6.IsBusy Then
            BackgroundWorker6.RunWorkerAsync()
        ElseIf Not BackgroundWorker7.IsBusy Then
            BackgroundWorker7.RunWorkerAsync()
        ElseIf Not BackgroundWorker8.IsBusy Then
            BackgroundWorker8.RunWorkerAsync()
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim dateDeTravail As Date = GlobalVariable.DateDeTravail.AddDays(-1)
        Functions.ultrMessageFichierAuto(dateDeTravail)
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim dateDeTravail As Date = GlobalVariable.DateDeTravail.AddDays(-1)
        Functions.ultrMessageFichierAuto(dateDeTravail)
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Dim dateDeTravail As Date = GlobalVariable.DateDeTravail.AddDays(-1)
        Functions.ultrMessageFichierAuto(dateDeTravail)
    End Sub

    Private Sub BackgroundWorker6_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker6.DoWork
        Dim dateDeTravail As Date = GlobalVariable.DateDeTravail.AddDays(-1)
        Functions.ultrMessageFichierAuto(dateDeTravail)
    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork
        Dim dateDeTravail As Date = GlobalVariable.DateDeTravail.AddDays(-1)
        Functions.ultrMessageFichierAuto(dateDeTravail)
    End Sub

    Private Sub BackgroundWorker7_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker7.DoWork
        Dim dateDeTravail As Date = GlobalVariable.DateDeTravail.AddDays(-1)
        Functions.ultrMessageFichierAuto(dateDeTravail)
    End Sub

    Private Sub BackgroundWorker8_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker8.DoWork
        Dim dateDeTravail As Date = GlobalVariable.DateDeTravail.AddDays(-1)
        Functions.ultrMessageFichierAuto(dateDeTravail)
    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Functions.listeDesDeparts(GlobalVariable.DateDeTravail.AddDays(-2))
    End Sub

    Private Sub GunaButtonChoixProfil_Click(sender As Object, e As EventArgs) Handles GunaButtonChoixProfil.Click

        '1- Si l'utilisateur a plus d'un profil on doit le faire choisir un profil
        'ProfilChoixForm.Close()
        ProfilChoixForm.Show()
        ProfilChoixForm.TopMost = True

    End Sub

    Private Sub GunaButtonMarketing_Click(sender As Object, e As EventArgs) Handles GunaButtonMarketing.Click

        Me.Cursor = Cursors.WaitCursor

        MainwindoMarketinngForm.Show()

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

End Class
