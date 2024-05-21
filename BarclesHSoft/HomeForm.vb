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

        If GlobalVariable.AgenceActuelle.Rows(0)("RAPPORT_AUTO") = 0 Then
            backGroundWorkerToCall()
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

        MainWindow.PanelTableauDeBords.Hide()
        MainWindow.GunaShadowPanelReception.Hide()

        MainWindow.GunaShadowPanelReservation.Show()
        MainWindow.PanelEnregistrement.Show()

        MainWindow.Show()

        MainWindow.LectureDeCarte()

        Me.Close()

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

        BarRestaurantForm.GunaLabelHeader.Text = "COMPTOIR"
        GlobalVariable.typeDeClientAFacturer = "comptoir"
        BarRestaurantForm.Show()

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

        End If

        AccueilForm.Close()

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

        'FacturationForm.GunaLabelHeader.Text = "AU COMPTANT"
        'FacturationForm.TopMost = True
        'FacturationForm.Location = New System.Drawing.Point(10, 110)
        'FacturationForm.Show()
        'MainWindowBarRestaurantForm.GunaLabelHeader.Text = "COMPTOIRE"

        MainWindowCuisineForm.Show()

        'BarRestaurantForm.Show()

        Me.Close()
        'Me.Hide()

        Me.Cursor = Cursors.Default

    End Sub


    Public Sub backGroundWorkerToCall()

        If Not BackgroundWorker2.IsBusy Then
            BackgroundWorker2.RunWorkerAsync()
        ElseIf Not BackgroundWorker3.IsBusy Then
            BackgroundWorker3.RunWorkerAsync()
        ElseIf Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
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

End Class
