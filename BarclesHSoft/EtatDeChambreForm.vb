Public Class EtatDeChambreForm

    Private Sub EtatDeChambreForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim langue As New Languages
        langue.etatChambre(GlobalVariable.actualLanguageValue)

        GunaLabelTime.Text = Now().ToLongTimeString()

        If GlobalVariable.controlDeChambreOk Then

            'GunaAdvenceButtonTerminer.Visible = False

            Dim serviceEtag As New ServicesEtage

            GunaLabelHeureControle.Text = Now().ToLongTimeString
            GunaLabelHeureControle.Visible = True

            Dim CODE_CHAMBRE As String = GlobalVariable.btnNettoyage.Name
            Dim CHAMP As String = "HEURE_CONTROL"
            Dim STATUTS As Integer = 3
            Dim ETAT_CHAMBRE_NOTE As String = "Libre propre"
            If GlobalVariable.actualLanguageValue = 0 Then
                ETAT_CHAMBRE_NOTE = "Free clean"
            End If
            Dim room As DataTable = Functions.getElementByCode(CODE_CHAMBRE, "chambre", "CODE_CHAMBRE")

            If room.Rows.Count > 0 Then

                ETAT_CHAMBRE_NOTE = "---"
                Dim roomNettoyageTable As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_CHAMBRE, "nettoyage", "CODE_CHAMBRE", 2, "STATUTS")

                If roomNettoyageTable.Rows.Count > 0 Then
                    'ETAT_CHAMBRE_NOTE = "In-2"
                    If roomNettoyageTable.Rows(0)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_sale Then
                        ETAT_CHAMBRE_NOTE = GlobalVariable.occupee_propre
                    ElseIf roomNettoyageTable.Rows(0)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_sale Then
                        ETAT_CHAMBRE_NOTE = GlobalVariable.libre_propre
                    End If

                    GunaAdvenceButtonDébuter.Visible = True
                    PictureBox1.Visible = True

                    GunaAdvenceButtonDébuter.Enabled = False
                    PictureBox1.Enabled = False

                    GunaAdvenceButtonFin.Visible = True
                    PictureBox2.Visible = True

                    GunaAdvenceButtonFin.Enabled = False
                    PictureBox2.Enabled = False

                    GunaAdvenceButtonTerminer.Enabled = True
                    GunaAdvenceButtonTerminer.Visible = True

                    'Times
                    GunaLabelHeureDebut.Visible = True
                    GunaLabelHeureDebut.Text = CDate(roomNettoyageTable.Rows(0)("HEURE_DEBUT")).ToLongTimeString
                    GunaLabelHeureFin.Visible = True
                    GunaLabelHeureFin.Text = CDate(roomNettoyageTable.Rows(0)("HEURE_FIN")).ToLongTimeString
                    GunaLabelHeureControle.Visible = True
                    GunaLabelHeureControle.Text = Now().ToLongTimeString()

                    'serviceEtag.updateNettoyageTime(CODE_CHAMBRE, CHAMP, STATUTS)
                    'serviceEtag.updateRoomApresNettoyage(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE)
                    'serviceEtag.miseAjourDelaChambreApreNettoyage(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE)

                    GlobalVariable.btnNettoyage.BackColor = Color.Orange

                    GlobalVariable.controlDeChambreOk = False

                End If

            End If

        End If

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaFermer.Click

        Me.Close()
        TimerToRefreshClock.Enabled = False

        MainWindowServiceEtageForm.StatistiquesDeNettoyage()
        MainWindowServiceEtageForm.StatusDesChambres()

    End Sub

    'Enregistrement de commentaire
    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerCommentaire.Click

        'Me.Cursor = Cursors.WaitCursor

        Dim service As New ServicesEtage()

        Dim CODE_CHAMBRE As String = GunaLabelChmabreEncoursDeNettoyage.Text
        Dim COMMENTAIRE As String = GunaTextBoxMessage.Text

        If service.ajouterUnCommentaire(CODE_CHAMBRE, COMMENTAIRE) Then

            MainWindowServiceEtageForm.DataGridViewRoomListe.Columns.Clear()

            MainWindowServiceEtageForm.roomList()

            Me.Close()

        End If

        'ON reaffiche les boutons pour éviter qu'il soient masqués au prochain affichage de la fenêtre
        GunaAdvenceButtonDébuter.Visible = True
        GunaLabelGestionDuTemps.Visible = True

        'Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonDébuter.Click

        Me.Cursor = Cursors.WaitCursor

        Dim serviceEtag As New ServicesEtage

        GunaLabelHeureDebut.Text = Now().ToLongTimeString
        GunaLabelHeureDebut.Visible = True

        Dim CODE_CHAMBRE As String = GlobalVariable.btnNettoyage.Name
        Dim CHAMP As String = "HEURE_DEBUT"
        Dim ETAT_CHAMBRE_NOTE As String = "Nettoyage"
        If GlobalVariable.actualLanguageValue = 0 Then
            ETAT_CHAMBRE_NOTE = "Cleaning"
        End If
        Dim STATUTS As Integer = 1

        serviceEtag.updateNettoyageTime(CODE_CHAMBRE, CHAMP, STATUTS)

        PictureBox1.Visible = True
        GunaAdvenceButtonFin.Enabled = True
        GunaAdvenceButtonDébuter.Enabled = False

        serviceEtag.updateRoomApresNettoyage(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE)

        GlobalVariable.btnNettoyage.BackColor = Color.OrangeRed

        MainWindowServiceEtageForm.TabPageNettoyage.Controls.Clear()
        MainWindowServiceEtageForm.StatistiquesDeNettoyage()
        MainWindowServiceEtageForm.StatusDesChambres()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaAdvenceButtonTerminer_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonTerminer.Click

        Me.Cursor = Cursors.WaitCursor

        GlobalVariable.chambreEnCoursDeControl = Trim(GunaLabelChmabreEncoursDeNettoyage.Text)

        GlobalVariable.controlDeChambreOk = True

        If GlobalVariable.controlDeChambreOk Then

            If Not Trim(GlobalVariable.chambreEnCoursDeControl).Equals("") Then
                ControllerNettoyageForm.Show()
            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaButton4_Click_1(sender As Object, e As EventArgs) Handles GunaButton4.Click
        Me.Close()
    End Sub

    'GEStion des motifs de mise en hors services
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Me.Cursor = Cursors.WaitCursor

        Dim service As New ServicesEtage()
        Dim CODE_CHAMBRE As String = GunaLabelChmabreEncoursDeNettoyage.Text
        Dim ETAT_CHAMBRE_NOTE As String = GlobalVariable.hors_service
        Dim ETAT_CHAMBRE As Integer = 1
        Dim CODE_MOTIF As String = Functions.GeneratingRandomCode("motif_hors_service", "")
        Dim MOTIF As String = GunaComboBoxMotifHS.SelectedItem
        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        'Avant d'attribuer le nouvel état on prends en compte les anciens état des chambres

        'On ne met pas ajour mais on crée une nouvelle entrée ce qui aidera dans les statistiques
        service.insertMotif(CODE_MOTIF, CODE_CHAMBRE, MOTIF, CODE_AGENCE)

        service.ChangementEtatDesChambre(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, ETAT_CHAMBRE)

        MainWindowServiceEtageForm.GunaDataGridViewEtatsDesChambres.Columns.Clear()

        MainWindowServiceEtageForm.roomList()

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    'Fin permet d'enregistrer le temps de fin de nettoyage
    Private Sub GunaAdvenceButtonFin_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonFin.Click

        Me.Cursor = Cursors.WaitCursor

        Dim service As New ServicesEtage()

        GunaLabelHeureFin.Text = Now().ToLongTimeString
        GunaLabelHeureFin.Visible = True

        Dim CODE_CHAMBRE As String = GlobalVariable.btnNettoyage.Name
        Dim CHAMP As String = "HEURE_FIN"
        Dim STATUTS As Integer = 2
        Dim ETAT_CHAMBRE_NOTE As String = "Attente"
        If GlobalVariable.actualLanguageValue = 0 Then
            ETAT_CHAMBRE_NOTE = "Pending"
        End If

        service.updateNettoyageTime(CODE_CHAMBRE, CHAMP, STATUTS)

        service.updateRoomApresNettoyage(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE)

        PictureBox1.Visible = False
        PictureBox2.Visible = True
        GunaAdvenceButtonFin.Enabled = False
        GunaAdvenceButtonTerminer.Enabled = True

        GlobalVariable.btnNettoyage.BackColor = Color.Orange

        TimerToRefreshClock.Enabled = False

        MainWindowServiceEtageForm.TabPageNettoyage.Controls.Clear()
        MainWindowServiceEtageForm.StatistiquesDeNettoyage()
        MainWindowServiceEtageForm.StatusDesChambres()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TimerToRefreshClock_Tick(sender As Object, e As EventArgs) Handles TimerToRefreshClock.Tick
        GunaLabelTime.Text = Now().ToLongTimeString()
    End Sub

End Class