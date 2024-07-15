Imports MySql.Data.MySqlClient

Public Class MainWindowServiceEtageForm
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Functions.exitApplicationThread()
    End Sub

    'Public Function personneDevantNettoyerDansStatutDeChambre(ByVal CODE_CHAMBRE As String, ByVal STATUTS As Integer, ByVal STATUTS_1 As Integer, ByVal STATUTS_2 As Integer, ByVal STATUTS_3 As Integer) As String
    Public Function personneDevantNettoyerDansStatutDeChambre(ByVal CODE_CHAMBRE As String, ByVal STATUTS As Integer, ByVal STATUTS_1 As Integer, ByVal STATUTS_2 As Integer, ByVal STATUTS_3 As Integer) As String

        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail

        Dim Query1 As String = ""

        Query1 = "SELECT `COD_PERSONNEL`, `NOM_COMPLET_PERSONNEL` FROM `nettoyage` WHERE DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_CHAMBRE = @CODE_CHAMBRE AND STATUTS=@STATUTS OR DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_CHAMBRE = @CODE_CHAMBRE  OR DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_CHAMBRE = @CODE_CHAMBRE AND STATUTS=@STATUTS_1 OR DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_CHAMBRE = @CODE_CHAMBRE AND STATUTS=@STATUTS_2 OR DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_CHAMBRE = @CODE_CHAMBRE AND STATUTS=@STATUTS_3 ORDER BY ID_NETTOYAGE DESC"

        Dim command1 = New MySqlCommand(Query1, GlobalVariable.connect)

        command1.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command1.Parameters.Add("@STATUTS", MySqlDbType.Int64).Value = STATUTS
        command1.Parameters.Add("@STATUTS_1", MySqlDbType.Int64).Value = STATUTS_1
        command1.Parameters.Add("@STATUTS_2", MySqlDbType.Int64).Value = STATUTS_2
        command1.Parameters.Add("@STATUTS_3", MySqlDbType.Int64).Value = STATUTS_3

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim dt As New DataTable()

        adapter1.Fill(dt)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("NOM_COMPLET_PERSONNEL")
        Else
            Return ""
        End If

    End Function


    Private Sub MainWindowServiceEtageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.serviceEtage(GlobalVariable.actualLanguageValue)

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail

        Dim menuAccess As New AccessRight()

        GunaButtonEtatDesChambres.Visible = True

        menuAccess.accesAuxModules(GlobalVariable.DroitAccesDeUtilisateurConnect, ReceptionToolStripMenuItem, RESERVATIONToolStripMenuItem, SERVICEDETAGEToolStripMenuItem, BarRestaurationToolStripMenuItem, ComptabilitéToolStripMenuItem, ECONOMATToolStripMenuItem, TECHNIQUEToolStripMenuItem, ToolStripMenuItem57)

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

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "STATUTS DES CHAMBRES"
        Else
            LabelLibelleActif.Text = "ROOMS STATUS"
        End If

        LabelLibelleActif.Refresh()


        GlobalVariable.ActualWindow = "ServiceEtage"

        GlobalVariable.navigation(GlobalVariable.ActualWindow)

        If TabControlRoomForm.SelectedIndex = 6 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                LabelLibelleActif.Text = "NETTOYAGE DES CHAMBRES"
            Else
                LabelLibelleActif.Text = "ROOMS CLEANING"
            End If

        End If

        MainWindow.Close()

        TabControlRoomForm.SelectedIndex = 6
        StatistiquesDeNettoyage()
        StatusDesChambres()

        GunaComboBoxEtatChambre.Items.Clear()

        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.occupee_sale)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.occupee_propre)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.libre_sale)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.libre_propre)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.reserver)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.hors_service)

    End Sub

    Private Sub GunaAdvenceButton9_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonStatutsChambre.Click

        GlobalVariable.typeChambreOuSalle = "chambre"
        LabelLibelleActif.Text = "STATUTS DES CHAMBRES"
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "STATUTS DES CHAMBRES"
        Else
            LabelLibelleActif.Text = "ROOMS STATUS"
        End If
        TabControlRoomForm.SelectedIndex = 1

    End Sub

    Dim page As Integer = 1

    Private Sub ReceptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceptionToolStripMenuItem.Click

        'RAFRAICHISSEMENT DES DONNE DU TABLEAU DE BORDS
        '---------------------------------------------------

        MainWindow.GunaDataGridViewResaDashBoard.Columns.Clear()

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()

        MainWindow.ReinitialisationDesDates()

        Me.Activate()

        MainWindow.GunaGroupBoxStatistiques.Controls.Clear()
        MainWindow.elementsDesChambres()
        MainWindow.contenuStatistique()
        MainWindow.StatistiquesDesChambres()

        GlobalVariable.chambreOuSalleFromFrontDesk = ""

        MainWindow.GunaShadowPanelReservation.Hide()
        MainWindow.PanelEnregistrement.Hide()

        MainWindow.PanelTableauDeBords.Show()
        MainWindow.GunaShadowPanelReception.Show()

        MainWindow.Show()

        Me.Hide()

    End Sub

    Private Sub RESERVATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESERVATIONToolStripMenuItem.Click

        GlobalVariable.chambreOuSalleFromFrontDesk = ""

        MainWindow.TabControlHbergement.SelectedIndex = 1
        MainWindow.GunaShadowPanelReception.Hide()

        'MainWindow.GunaShadowPanelReservation.BringToFront()
        MainWindow.GunaShadowPanelReservation.Show()

        'MainWindow.PanelEnregistrement.BringToFront()
        MainWindow.PanelEnregistrement.Show()

        MainWindow.Show()

        Me.Hide()

    End Sub

    Private Sub BarRestaurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarRestaurationToolStripMenuItem.Click

        GlobalVariable.chambreOuSalleFromFrontDesk = ""
        GlobalVariable.typeDeClientAFacturer = "comptoir"

        If Trim(GlobalVariable.AgenceActuelle.Rows(0)("CAISSE_ENREGISTREUSE_1")).Equals("") Then
            BarRestaurantForm.Show()
            BarRestaurantForm.GunaLabelHeader.Text = "COMPTOIR"
        Else
            BarRestaurantCaisseEnregistreuseForm.Show()
            BarRestaurantCaisseEnregistreuseForm.GunaLabelHeader.Text = "COMPTOIR"
        End If


        Me.Close()

    End Sub

    Private Sub ComptabilitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComptabilitéToolStripMenuItem.Click

        GlobalVariable.chambreOuSalleFromFrontDesk = ""

        MainWindowComptabiliteForm.Visible = True

        Me.Visible = False

    End Sub

    Private Sub ECONOMATToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ECONOMATToolStripMenuItem.Click

        GlobalVariable.chambreOuSalleFromFrontDesk = ""

        MainWindowEconomat.Show()

        Me.Visible = False

    End Sub

    Private Sub TECHNIQUEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TECHNIQUEToolStripMenuItem.Click

        GlobalVariable.chambreOuSalleFromFrontDesk = ""

        MainWindowTechnique.Show()

        Me.Visible = False

    End Sub

    Private Sub GunaAdvenceButton8_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonHistorique.Click

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "HISTORIQUES DES CHAMBRES"
        Else
            LabelLibelleActif.Text = "ROOMS HISTORY"
        End If

        TabControlRoomForm.SelectedIndex = 3

    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "ETATS DES CHAMBRES"
        Else
            LabelLibelleActif.Text = "ROOMS STATE"
        End If
        TabControlRoomForm.SelectedIndex = 8

    End Sub

    Private Sub GunaAdvenceButton7_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton7.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "CHAMBRES HORS SERVICES"
        Else
            LabelLibelleActif.Text = "ROOMS OUT OF SERVICE"

        End If
        TabControlRoomForm.SelectedIndex = 2
    End Sub

    Private Sub GunaAdvenceButton32_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton32.Click

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "OBJETS TROUVES/PERDUS"
        Else
            LabelLibelleActif.Text = "LOST & FOUND"
        End If
        TabControlRoomForm.SelectedIndex = 4
    End Sub

    Private Sub GunaAdvenceButton31_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton31.Click

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "RAPPORTS"
        Else
            LabelLibelleActif.Text = "REPORTS"
        End If
        TabControlRoomForm.SelectedIndex = 5
    End Sub

    Private Sub GunaAdvenceButtonEtatDesChambres_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonEtatDesChambres.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "NETTOYAGE DES CHAMBRES"
        Else
            LabelLibelleActif.Text = "ROOMS CLEANING"
        End If
        TabControlRoomForm.SelectedIndex = 6
        StatistiquesDeNettoyage()
        StatusDesChambres()
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelLibelleActif.Text = "PLANNING DE NETTOYAGE"
        Else
            LabelLibelleActif.Text = "PLANNING CLEANING"
        End If
        TabControlRoomForm.SelectedIndex = 7
    End Sub

    '-------------------------------------------------------------------------

    'Dim connect As New DataBaseManipulation()

    Private Sub RoomForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaComboBoxRegistre.SelectedIndex = 0
        GunaComboBoxNature.SelectedIndex = 0
        GunaGroupBoxTrouvees.LineColor = Color.LightSteelBlue

        'Initialisation of ele,ents depending on if we are working on chambre or salle de fete
        If GlobalVariable.typeChambreOuSalle = "salle" Then

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelLibelleActif.Text = "CREATION ET MISE A JOUR DES SALLES"
                GunaLabelTypeChambreOuSalle.Text = "Type de Salle"
                GunaLabelCodeSalleOuNumeroChambre.Text = "Code Salle"
                GunaLabelEtatChambreOuSalle.Text = "Etat de la Salle"
            Else
                LabelLibelleActif.Text = "CREATION AND UPDATES OF HALLS"
                GunaLabelTypeChambreOuSalle.Text = "Hall Category"
                GunaLabelCodeSalleOuNumeroChambre.Text = "Hall Code"
                GunaLabelEtatChambreOuSalle.Text = "Hall State"
            End If

        ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then

            If GlobalVariable.actualLanguageValue = 1 Then

                If TabControlRoomForm.SelectedIndex = 6 Then
                    LabelLibelleActif.Text = "NETTOYAGE DES CHAMBRES"
                Else
                    LabelLibelleActif.Text = "CREATION ET MISE A JOURS DES CHAMBRES"
                End If

                GunaLabelTypeChambreOuSalle.Text = "Type de Chambre"
                GunaLabelCodeSalleOuNumeroChambre.Text = "Numéro Chambre"
                GunaLabelEtatChambreOuSalle.Text = "Etat de la Chambre"

            Else

                If TabControlRoomForm.SelectedIndex = 6 Then
                    LabelLibelleActif.Text = "ROOM CLEANING"
                Else
                    LabelLibelleActif.Text = "CREATION A ROOM UPDATE"
                End If

                GunaLabelTypeChambreOuSalle.Text = "Room Type"
                GunaLabelCodeSalleOuNumeroChambre.Text = "Room number"
                GunaLabelEtatChambreOuSalle.Text = "Room state"
            End If

        End If

        FillingOfTypeChambreOuSalleComboBox()

        GunaComboBoxTypeDeChambreOuSalle.SelectedIndex = -1

    End Sub

    Public Sub FillingOfTypeChambreOuSalleComboBox()

        'We load the Type of rooms or salle

        Dim Query As String = "SELECT * From type_chambre WHERE CODE_AGENCE = @CODE_AGENCE AND TYPE=@TYPE ORDER BY CODE_TYPE_CHAMBRE ASC"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        Dim tableListTypeSalleOuChambre As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(tableListTypeSalleOuChambre)

        If (tableListTypeSalleOuChambre.Rows.Count > 0) Then

            GunaComboBoxTypeDeChambreOuSalle.DataSource = tableListTypeSalleOuChambre
            GunaComboBoxTypeDeChambreOuSalle.ValueMember = "CODE_TYPE_CHAMBRE"
            GunaComboBoxTypeDeChambreOuSalle.DisplayMember = "LIBELLE_TYPE_CHAMBRE"

        End If

        'connect.closeConnection()

    End Sub


    Public Sub roomList()

        'Inserting data from database into datagridView
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        Dim Query As String = "SELECT CODE_CHAMBRE AS 'CODE CHAMBRE', ETAT_CHAMBRE_NOTE As 'ETAT CHAMBRE',LIBELLE_CHAMBRE AS 'LIBELLE',GUEST_DAI AS 'COMMENTAIRE',CODE_TYPE_CHAMBRE As 'CODE TYPE CHAMBRE', LOCALISATION From chambre WHERE CODE_AGENCE = @CODE_AGENCE AND TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

        Dim command = New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        adapter.SelectCommand = command
        adapter.Fill(dbDataSet)
        bSource.DataSource = dbDataSet

        If TabControlRoomForm.SelectedIndex = 1 Then

            DataGridViewRoomListe.DataSource = bSource
            adapter.Update(dbDataSet)

            DataGridViewRoomListe.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            DataGridViewRoomListe.DefaultCellStyle.SelectionForeColor = Color.White
            'DataGridViewRoomListe.Columns("PRIX").DefaultCellStyle.Format = "#,##0"
            'DataGridViewRoomListe.Columns("PRIX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewRoomListe.Columns("CODE TYPE CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridViewRoomListe.Columns("ETAT CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridViewRoomListe.Columns("CODE CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DataGridViewRoomListe.Columns("PRIX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'DataGridViewRoomListe.Columns.Add("STATUT", "STATUT")

            For i = 0 To DataGridViewRoomListe.Rows.Count - 1

                If i Mod 2 = 0 Then
                    DataGridViewRoomListe.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                Else
                    DataGridViewRoomListe.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next

        ElseIf TabControlRoomForm.SelectedIndex = 8 Then

            GunaDataGridViewEtatsDesChambres.DataSource = bSource
            adapter.Update(dbDataSet)

            GunaDataGridViewEtatsDesChambres.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            GunaDataGridViewEtatsDesChambres.DefaultCellStyle.SelectionForeColor = Color.White

            GunaDataGridViewEtatsDesChambres.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            GunaDataGridViewEtatsDesChambres.DefaultCellStyle.SelectionForeColor = Color.White
            GunaDataGridViewEtatsDesChambres.Columns("CODE TYPE CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            GunaDataGridViewEtatsDesChambres.Columns("ETAT CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            GunaDataGridViewEtatsDesChambres.Columns("CODE CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For i = 0 To GunaDataGridViewEtatsDesChambres.Rows.Count - 1

                If i Mod 2 = 0 Then
                    GunaDataGridViewEtatsDesChambres.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                Else
                    GunaDataGridViewEtatsDesChambres.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next

        End If

        'connect.closeConnection()

    End Sub

    'Function to check empty fields
    Public Function verifyFields() As Boolean

        Dim check As Boolean = False

        If (GunaTextBoxcCode.Text.Trim().Equals("") _
                        Or GunaTextBoxLibelle.Text.Trim().Equals("") _
                        Or GunaTextBoxLocalisation.Text.Trim().Equals("") _
                Or GunaTextBoxPrix.Text.Trim().Equals("")) Then
            check = False

        Else

            check = True

        End If

        Return check

    End Function

    'Enregistrement des chmbres
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_CHAMBRE = GunaTextBoxcCode.Text
        Dim CODE_TYPE_CHAMBRE = GunaComboBoxTypeDeChambreOuSalle.SelectedValue.ToString
        Dim LIBELLE_CHAMBRE = GunaTextBoxLibelle.Text
        Dim PRIX = GunaTextBoxPrix.Text
        Dim OLD_CODE_CHAMBRE = GunaTextBoxOldCodeChambre.Text

        Dim FICTIF As Integer = 0

        If GunaCheckBoxFictif.Checked Then
            FICTIF = 1
        End If

        Dim LOCK_NO = GunaTextBoxLock.Text
        Dim ETAT_CHAMBRE = GunaComboBoxEtatChambre.SelectedIndex
        Dim ETAT_CHAMBRE_NOTE = GunaComboBoxEtatChambre.SelectedItem

        Dim CODE_MOTIF As String = ""
        Dim MOTIF As String = ""

        If (Not ETAT_CHAMBRE_NOTE = GlobalVariable.hors_service) Or (Not ETAT_CHAMBRE_NOTE = "Out of Service") Then
            ETAT_CHAMBRE = 0
        Else
            CODE_MOTIF = Functions.GeneratingRandomCode("motif_hors_service", "")
            MOTIF = GunaComboBoxMotifHS.SelectedItem
        End If

        Dim LOCALISATION = GunaTextBoxLocalisation.Text
        Dim NUM_COMPTE = GunaTextBoxCompteNumero.Text
        Dim GUEST_DAI = GunaTextBoxGuest.Text
        Dim CODE_CATEGORY_CHAMBRE = GunaComboBoxMotifHS.SelectedItem 'permet de gérer le motif si la chambre est dans un états hors service

        If CODE_CATEGORY_CHAMBRE = "" Then

            If GlobalVariable.actualLanguageValue = 1 Then
                CODE_CATEGORY_CHAMBRE = "Aucun problème"
            Else
                CODE_CATEGORY_CHAMBRE = "No problem"
            End If

        End If

        Dim DATE_CREATION = GlobalVariable.DateDeTravail.ToShortDateString()
        Dim CODE_AGENCE = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        Dim TYPE As String = ""

        If GlobalVariable.typeChambreOuSalle = "salle" Then
            TYPE = "salle"
        ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then
            TYPE = "chambre"
        End If

        Dim room As New Room
        Dim service As New ServicesEtage

        '---------------- MOTIF HS ------------------------

        Dim title_type As String = ""
        Dim message As String = ""

        If GlobalVariable.typeChambreOuSalle = "salle" Then
            title_type = "Salle"
        Else
            title_type = "Chambre"
        End If

        'company verifyfields function
        If (verifyFields()) Then
            'check if the company alreday exist

            If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then
                'we update the value of the room

                CODE_CHAMBRE = GunaTextBoxcCode.Text

                If room.UpdateRoom(CODE_CHAMBRE, CODE_TYPE_CHAMBRE, CODE_CATEGORY_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE, LOCALISATION, NUM_COMPTE, PRIX, FICTIF, LOCK_NO, GUEST_DAI, CODE_AGENCE, OLD_CODE_CHAMBRE) Then

                    Functions.ClearTextBox(Me)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Modification enregistrée avec succès", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Update successfully saved", "Creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    'Clearing of fields

                    GunaCheckBoxFictif.Checked = False

                    TabControlRoomForm.SelectedIndex = 1

                End If

                If ETAT_CHAMBRE_NOTE = GlobalVariable.hors_service Then

                    CODE_MOTIF = GunaTextBoxCodeMotif.Text

                    'On ne met pas ajour mais on crée une nouvelle entrée ce qui aidera dans les statistiques
                    service.insertMotif(CODE_MOTIF, CODE_CHAMBRE, MOTIF, CODE_AGENCE)

                End If

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonEnregistrer.Text = "Enregistrer"
                Else
                    GunaButtonEnregistrer.Text = "Save"
                End If

            Else

                If Not room.chambreExists(CODE_CHAMBRE, LIBELLE_CHAMBRE) Then

                    If room.Insert(CODE_CHAMBRE, CODE_TYPE_CHAMBRE, CODE_CATEGORY_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE, LOCALISATION, NUM_COMPTE, PRIX, FICTIF, LOCK_NO, GUEST_DAI, DATE_CREATION, CODE_AGENCE, TYPE) Then

                        If ETAT_CHAMBRE = 0 Then

                            If service.insertMotif(CODE_MOTIF, CODE_CHAMBRE, MOTIF, CODE_AGENCE) Then

                            End If

                        End If

                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Nouvelle " & title_type & " enregistrée avec succès", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("New " & title_type & " successfully created", "Creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        'Clearing of fields
                        Functions.ClearTextBox(Me)
                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Un problème lors de la création !!", "Création", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            MessageBox.Show("Problem during creation !!", "Creation", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If
                    End If
                Else
                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Cette " & title_type & "  existe déjà, Essayer à nouveau", "Création", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("Thhis " & title_type & " already exist, Try again", "Creation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            End If

        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir remplir tous les champs !!", "Création de Chambre", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please fill all the fields !!", "Création de Chambre", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        'We refresh the room list
        'roomList()

        'On actiive le formulaire pour rafraishir le panneau des images cde chambre
        'Dim mainWindow As New MainWindow()

        'mainWindow.Activate() 'Icon des chambres au niveau du dashboard

        GunaComboBoxMotifHS.Visible = False
        GunaComboBoxMotifHS.Visible = False
        GunaLabelMotif.Visible = False

    End Sub

    'Auto complete Room type
    Sub AutoCompleteChambre()
        Dim Query As String = "SELECT * From type_chambre WHERE CODE_AGENCE = @CODE_AGENCE AND TYPE=@TYPE ORDER BY CODE_TYPE_CHAMBRE ASC"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(table)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer

        For i = 0 To table.Rows.Count - 1
            col.Add(table.Rows(i)("CODE_TYPE_CHAMBRE").ToString())
        Next

        GunaTextBoxTypeChambre.AutoCompleteSource = AutoCompleteSource.CustomSource
        GunaTextBoxTypeChambre.AutoCompleteCustomSource = col
        GunaTextBoxTypeChambre.AutoCompleteMode = AutoCompleteMode.Suggest

        'connect.closeConnection()

    End Sub

    Private Sub GunaButtonFermer_Click(sender As Object, e As EventArgs) Handles GunaButtonFermer.Click

        Me.Close()

        If MainWindow.GunaRadioButtonSalleFete.Visible Then
            GlobalVariable.typeChambreOuSalle = "salle"
        Else
            GlobalVariable.typeChambreOuSalle = "chambre"
        End If

        GlobalVariable.chambreOuSalleFromFrontDesk = ""

        GunaComboBoxMotifHS.Visible = False
        GunaComboBoxMotifHS.Visible = False
        GunaLabelMotif.Visible = False

    End Sub

    'Taking data from datagridView and insert into textBox for update
    Private Sub DataGridView1_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewRoomListe.CellDoubleClick

        If e.RowIndex >= 0 Then

            If GunaRadioButtonChambre.Checked Then
                GlobalVariable.typeChambreOuSalle = "chambre"
            ElseIf GunaRadioButtonSalle.Checked Then
                GlobalVariable.typeChambreOuSalle = "salle"
            End If

            'We want to upload the room coming from the front desk based on the room type
            If Not GlobalVariable.chambreOuSalleFromFrontDesk = "" Then

                Dim row As DataGridViewRow

                row = Me.DataGridViewRoomListe.Rows(e.RowIndex)

                'We select a room by doucliking when coming from frontdesk

                Dim mainWindow As New MainWindow()

                'We make sure it is possible to Choose a room if a room type is choosen first
                'We set back the diasbled values after checkin or save
                GlobalVariable.chambreOuSalleFromFrontDesk = row.Cells("CODE CHAMBRE").Value.ToString

                mainWindow.Activate()

                Me.Close()

            Else

                'We double click for editing

                Dim row As DataGridViewRow

                row = Me.DataGridViewRoomListe.Rows(e.RowIndex)

                GunaTextBoxLibelle.Text = row.Cells("LIBELLE").Value.ToString

                Dim chambre As DataTable = Functions.getElementByCode(row.Cells("CODE CHAMBRE").Value.ToString, "chambre", "CODE_CHAMBRE")
                GunaTextBoxOldCodeChambre.Text = row.Cells("CODE CHAMBRE").Value.ToString

                'We change the text of the enregistrer button from enregistrer to save

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonEnregistrer.Text = "Sauvegarder"
                Else
                    GunaButtonEnregistrer.Text = "Update"
                End If


                TabControlRoomForm.SelectedIndex = 0

                If chambre.Rows.Count > 0 Then

                    GunaTextBoxcCode.Text = chambre.Rows(0)("CODE_CHAMBRE")

                    GunaComboBoxTypeDeChambreOuSalle.SelectedValue = chambre.Rows(0)("CODE_TYPE_CHAMBRE")

                End If

                'When we upload the other information concerning the room

                Dim query As String = "SELECT * FROM type_chambre WHERE CODE_AGENCE = @CODE_AGENCE AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND TYPE=@TYPE ORDER BY CODE_TYPE_CHAMBRE ASC"

                Dim adapter As New MySqlDataAdapter
                Dim table As New DataTable()
                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
                command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = GunaComboBoxTypeDeChambreOuSalle.SelectedValue
                command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

                adapter.SelectCommand = command
                adapter.Fill(table)

                If (table.Rows.Count > 0) Then
                    GunaTextBoxLibelleType.Text = table.Rows(0)("CODE_TYPE_CHAMBRE").ToString & "-" & table.Rows(0)("LIBELLE_TYPE_CHAMBRE").ToString
                    GunaTextBoxPrix.Text = Format(CType(table.Rows(0)("PRIX"), Double), "#,##0")
                Else

                    GunaTextBoxTypeChambre.Clear()
                    GunaTextBoxLibelleType.Clear()

                End If

                If chambre.Rows(0)("FICITIF") = 0 Then
                    GunaCheckBoxFictif.Checked = False
                Else
                    GunaCheckBoxFictif.Checked = True
                End If

                GunaTextBoxLock.Text = chambre.Rows(0)("LOCK_NO")

                GunaComboBoxEtatChambre.SelectedItem = chambre.Rows(0)("ETAT_CHAMBRE_NOTE")

                GunaTextBoxLocalisation.Text = chambre.Rows(0)("LOCALISATION")

                GunaTextBoxCompteNumero.Text = ""

                GunaTextBoxGuest.Text = chambre.Rows(0)("GUEST_DAI")

                GunaTextBoxLibelle.Text = chambre.Rows(0)("LIBELLE_CHAMBRE")

                GunaComboBoxMotifHS.SelectedItem = chambre.Rows(0)("CODE_CATEGORY_CHAMBRE")

                'Si la chambre a été mise Hors Service alors on doit afficher le motif
                If Trim(chambre.Rows(0)("ETAT_CHAMBRE_NOTE")) = GlobalVariable.hors_service Or Trim(chambre.Rows(0)("ETAT_CHAMBRE_NOTE")) = "Out of Service" Then

                    Dim service As New ServicesEtage()
                    'On détermine la dernière fois que la chambre a été mise hors service
                    Dim motifHS As DataTable = service.DernierHorsService(chambre.Rows(0)("CODE_CHAMBRE"))

                    If motifHS.Rows.Count > 0 Then

                        GunaComboBoxMotifHS.Visible = True
                        GunaComboBoxMotifHS.SelectedItem = motifHS.Rows(0)("MOTIF")
                        GunaTextBoxCodeMotif.Text = motifHS.Rows(0)("CODE_MOTIF")

                    Else
                        GunaComboBoxMotifHS.Visible = False
                    End If

                Else

                    GunaComboBoxMotifHS.Visible = False
                End If

            End If

            DataGridViewRoomListe.Columns.Clear()

        End If

    End Sub

    Private Sub GunaComboBoxTypeDeChambreOuSalle_SelectedValueChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeChambreOuSalle.SelectedValueChanged

        Dim query As String = "SELECT * FROM type_chambre WHERE CODE_AGENCE = @CODE_AGENCE AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND TYPE=@TYPE"
        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = GunaComboBoxTypeDeChambreOuSalle.SelectedValue
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        adapter.SelectCommand = command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaTextBoxLibelleType.Text = table.Rows(0)("CODE_TYPE_CHAMBRE").ToString & "-" & table.Rows(0)("LIBELLE_TYPE_CHAMBRE").ToString
            GunaTextBoxPrix.Text = Format(CType(table.Rows(0)("PRIX"), Double), "#,##0")
        Else

            GunaTextBoxTypeChambre.Clear()
            GunaTextBoxLibelleType.Clear()

        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaComboBoxEtatChambre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxEtatChambre.SelectedIndexChanged

        If Trim(GunaComboBoxEtatChambre.SelectedItem) = GlobalVariable.hors_service Or Trim(GunaComboBoxEtatChambre.SelectedItem) = "Out of Service" Then
            GunaComboBoxMotifHS.Visible = True
            GunaComboBoxMotifHS.Visible = True
            GunaLabelMotif.Visible = True
        Else
            GunaComboBoxMotifHS.Visible = False
            GunaComboBoxMotifHS.Visible = False
            GunaLabelMotif.Visible = False
        End If

    End Sub

    'Suppresion d'une chambre
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        Dim title_type As String = "Salle"

        If GlobalVariable.typeChambreOuSalle = "chambre" Then
            title_type = "Chambre"
        End If

        If DataGridViewRoomListe.Rows.Count > 0 Then

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Supprimer cette " & title_type & " " & DataGridViewRoomListe.CurrentRow.Cells("CODE CHAMBRE").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                dialog = MessageBox.Show("Dou you really want to delete this " & title_type & " " & DataGridViewRoomListe.CurrentRow.Cells("CODE CHAMBRE").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(DataGridViewRoomListe, DataGridViewRoomListe.CurrentRow.Cells("CODE CHAMBRE").Value.ToString, "chambre", "CODE_CHAMBRE")

                DataGridViewRoomListe.Columns.Clear()

                roomList()

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Successfully deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If


        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune ligne à supprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Nothing to delete!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    'AFFICHAGE DE LA LISTE DES CHAMBRES
    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLaListeDesChambres.Click
        'DataGridViewRoomListe.Columns.Clear()

        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
        ElseIf GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        End If

        roomList()

    End Sub

    Private Sub TabControlRoomForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlRoomForm.SelectedIndexChanged

        FillingOfTypeChambreOuSalleComboBox()

        If TabControlRoomForm.SelectedIndex = 7 Then

            If GunaRadioButtonChambre.Checked Then
                GlobalVariable.typeChambreOuSalle = "chambre"
            ElseIf GunaRadioButtonSalle.Checked Then
                GlobalVariable.typeChambreOuSalle = "salle"
            End If

            GunaDataGridViewP0.Rows.Clear()

            NettoyageRoomLIst()

            GunaTextBoxNbreChambreTotalANettoyer.Text = GunaDataGridViewP0.Rows.Count

        Else
            GunaDataGridViewP0.Columns.Clear()
        End If

        If TabControlRoomForm.SelectedIndex = 6 Then

            GunaButtonEtatDesChambres.Visible = True

            StatusDesChambres()
            StatistiquesDeNettoyage()

            PanelSale.Visible = True
            PanelEncours.Visible = True
            PanelAInspecter.Visible = True
            PanelPropre.Visible = True
            PanelHs.Visible = True

        Else
            GunaButtonEtatDesChambres.Visible = False
            TabPageNettoyage.Controls.Clear()

            PanelSale.Visible = False
            PanelEncours.Visible = False
            PanelAInspecter.Visible = False
            PanelPropre.Visible = False
            PanelHs.Visible = False

        End If

        DataGridViewRoomListe.Columns.Clear()
        GunaDataGridViewHorsSerice.Columns.Clear()
        GunaDataGridViewHistoriqueDesChambres.Columns.Clear()
        GunaDataGridViewRegistreObjets.Columns.Clear()
        GunaDataGridViewEtatsDesChambres.Columns.Clear()

    End Sub

    Private Sub HSroomLIst()

        'Inserting data from database into datagridView
        Dim Query1 As String = "SELECT chambre.CODE_CHAMBRE AS 'CODE CHAMBRE', CODE_TYPE_CHAMBRE As 'CODE TYPE CHAMBRE', ETAT_CHAMBRE_NOTE As 'ETAT CHAMBRE', MOTIF ,PRIX , LIBELLE_CHAMBRE AS 'LIBELLE',LOCALISATION, DATE_CREATION As 'DATE DE MISE EN HS' From chambre INNER JOIN motif_hors_service WHERE motif_hors_service.CODE_CHAMBRE = chambre.CODE_CHAMBRE AND chambre.CODE_AGENCE = @CODE_AGENCE AND TYPE=@TYPE AND ETAT_CHAMBRE_NOTE = @ETAT_CHAMBRE_NOTE ORDER BY chambre.CODE_CHAMBRE ASC"

        Dim command1 = New MySqlCommand(Query1, GlobalVariable.connect)
        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.hors_service

        Dim adapter As New MySqlDataAdapter(command1)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            GunaDataGridViewHorsSerice.DataSource = table

            GunaDataGridViewHorsSerice.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            GunaDataGridViewHorsSerice.DefaultCellStyle.SelectionForeColor = Color.White
            GunaDataGridViewHorsSerice.Columns("PRIX").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewHorsSerice.Columns("PRIX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewHorsSerice.Columns("CODE TYPE CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewHorsSerice.Columns("CODE CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewHorsSerice.Columns("PRIX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Else

        End If

    End Sub

    Private Sub NettoyageRoomLIst()

        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
        ElseIf GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        End If

        'Inserting data from database into datagridView
        Dim Query1 As String = "SELECT CODE_CHAMBRE AS 'CHAMBRE', GUEST_DAI As 'COMMENTAIRE', ETAT_CHAMBRE_NOTE As 'ETAT' From chambre WHERE ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE AND TYPE=@TYPE OR ETAT_CHAMBRE_NOTE = @ETAT_CHAMBRE_NOTE1 AND TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

        Dim command1 = New MySqlCommand(Query1, GlobalVariable.connect)
        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.occupee_sale
        command1.Parameters.Add("@ETAT_CHAMBRE_NOTE1", MySqlDbType.VarChar).Value = GlobalVariable.libre_sale

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()

        adapter1.Fill(table1)
        'GunaDataGridViewP0.Columns.Add("CODE", "CODE")
        'GunaDataGridViewP0.Columns.Add("COMMENATIRE", "COMMENATIRE")
        'GunaDataGridViewP0.Columns.Add("ETAT", "ETAT")

        'SELECTION DES CHAMBRES DEJA ATTIBUES

        If table1.Rows.Count > 0 Then

            GunaDataGridViewP0.Columns.Clear()

            GunaDataGridViewP0.Columns.Add("CHANBRE", "CHANBRE")
            GunaDataGridViewP0.Columns.Add("COMMENTAIRE", "COMMENTAIRE")
            GunaDataGridViewP0.Columns.Add("ETAT", "ETAT")

            For i = 0 To table1.Rows.Count - 1

                Dim CODE_CHAMBRE As String = table1.Rows(i)("CHAMBRE")
                Dim STATUTS As Integer = 0

                'Dim ChambreDejaAttribuee As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_CHAMBRE, "nettoyage", "CODE_CHAMBRE", STATUTS, "STATUTS")
                Dim ChambreDejaAttribuee As DataTable = chambreDejaAttribueeDataTable(STATUTS, CODE_CHAMBRE)

                If Not ChambreDejaAttribuee.Rows.Count > 0 Then
                    GunaDataGridViewP0.Rows.Add(table1.Rows(i)("CHAMBRE"), table1.Rows(i)("COMMENTAIRE"), table1.Rows(i)("ETAT"))
                End If

            Next

        Else
            GunaDataGridViewP0.Columns.Clear()
        End If

    End Sub

    Private Function chambreDejaAttribueeDataTable(ByVal STATUTS As Integer, ByVal CODE_CHAMBRE As String) As DataTable

        'SELECTION DES CHAMBRES SALES DU JOUR DEJA ATTRIBUEES

        Dim DateDebut As Date = CDate(GlobalVariable.DateDeTravail).ToString("yyyy-MM-dd")

        Dim Query1 As String = "SELECT * FROM `nettoyage` WHERE CODE_CHAMBRE=@CODE_CHAMBRE AND STATUTS=@STATUTS AND DATE_CREATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "'"

        'Dim Query1 As String = "SELECT * FROM `nettoyage` WHERE CODE_CHAMBRE=@CODE_CHAMBRE AND DATE_CREATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "'"

        Dim command1 = New MySqlCommand(Query1, GlobalVariable.connect)
        command1.Parameters.Add("@STATUTS", MySqlDbType.Int64).Value = STATUTS
        command1.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()

        adapter1.Fill(table1)

        Return table1

    End Function

    'Affichage des hors services
    Private Sub GunaButtonAfficherHorsService_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherHorsService.Click

        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
        ElseIf GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        End If

        HSroomLIst()
    End Sub

    Private Sub GunaDataGridViewHorsSerice_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewHorsSerice.CellDoubleClick

        If e.RowIndex >= 0 Then

            'We double click for editing

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewHorsSerice.Rows(e.RowIndex)

            GunaTextBoxLibelle.Text = row.Cells("LIBELLE").Value.ToString

            Dim chambre As DataTable = Functions.getElementByCode(row.Cells("CODE CHAMBRE").Value.ToString, "chambre", "CODE_CHAMBRE")

            'We change the text of the enregistrer button from enregistrer to save

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrer.Text = "Sauvegarder"
            Else
                GunaButtonEnregistrer.Text = "Update"
            End If

            'MessageBox.Show(row.Cells("CODE CHAMBRE").Value.ToString & "-" & chambre.Rows.Count)
            TabControlRoomForm.SelectedIndex = 0

            'GunaTextBoxcCode.Text = row.Cells("CODE CHAMBRE").Value.ToString
            GunaTextBoxcCode.Text = chambre.Rows(0)("CODE_CHAMBRE")

            GunaComboBoxTypeDeChambreOuSalle.SelectedValue = chambre.Rows(0)("CODE_TYPE_CHAMBRE")

            'When we upload the other information concerning the room

            Dim query As String = "Select * FROM type_chambre WHERE CODE_AGENCE = @CODE_AGENCE And CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE And TYPE=@TYPE ORDER BY CODE_TYPE_CHAMBRE ASC"
            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = GunaComboBoxTypeDeChambreOuSalle.SelectedValue
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            adapter.SelectCommand = command
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaTextBoxLibelleType.Text = table.Rows(0)("CODE_TYPE_CHAMBRE").ToString & "-" & table.Rows(0)("LIBELLE_TYPE_CHAMBRE").ToString
                GunaTextBoxPrix.Text = Format(CType(table.Rows(0)("PRIX"), Double), "#,##0")
            Else

                GunaTextBoxTypeChambre.Clear()
                GunaTextBoxLibelleType.Clear()

            End If

            '---------------------------------------------------------------------

            'GunaTextBoxPrix.Text = Format(row.Cells("PRIX").Value.ToString, "#,##0")

            If chambre.Rows(0)("FICITIF") = 0 Then
                GunaCheckBoxFictif.Checked = False
            Else
                GunaCheckBoxFictif.Checked = True
            End If

            GunaTextBoxLock.Text = chambre.Rows(0)("LOCK_NO")

            GunaComboBoxEtatChambre.SelectedItem = chambre.Rows(0)("ETAT_CHAMBRE_NOTE")

            GunaTextBoxLocalisation.Text = chambre.Rows(0)("LOCALISATION")

            GunaTextBoxCompteNumero.Text = ""

            GunaTextBoxGuest.Text = chambre.Rows(0)("GUEST_DAI")

            GunaTextBoxLibelle.Text = chambre.Rows(0)("LIBELLE_CHAMBRE")

            GunaComboBoxMotifHS.SelectedItem = chambre.Rows(0)("CODE_CATEGORY_CHAMBRE")

            'Si la chambre a été mise Hors Service alors on doit afficher le motif
            If Trim(chambre.Rows(0)("ETAT_CHAMBRE_NOTE")) = GlobalVariable.hors_service Or Trim(chambre.Rows(0)("ETAT_CHAMBRE_NOTE")) = "Out of Service" Then

                Dim service As New ServicesEtage()
                'On détermine la dernière fois que la chambre a été mise hors service
                Dim motifHS As DataTable = service.DernierHorsService(chambre.Rows(0)("CODE_CHAMBRE"))

                If motifHS.Rows.Count > 0 Then

                    GunaComboBoxMotifHS.Visible = True
                    GunaComboBoxMotifHS.SelectedItem = motifHS.Rows(0)("MOTIF")
                    GunaTextBoxCodeMotif.Text = motifHS.Rows(0)("CODE_MOTIF")

                Else
                    GunaComboBoxMotifHS.Visible = False
                End If

            Else

                GunaComboBoxMotifHS.Visible = False
            End If

        End If

        GunaDataGridViewHorsSerice.Columns.Clear()
    End Sub

    Private Sub GunaButtonHistorique_Click(sender As Object, e As EventArgs) Handles GunaButtonHistorique.Click
        Dim serviceEtage As New ServicesEtage()
        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
        ElseIf GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        End If
        GunaDataGridViewHistoriqueDesChambres.DataSource = serviceEtage.HistoriqueDesChambres(GlobalVariable.typeChambreOuSalle)
    End Sub

    'OBJET PERDUS ET TROUVEES
    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNature.SelectedIndexChanged

        If GunaComboBoxNature.SelectedIndex = 0 Then

            GunaGroupBoxTrouvees.LineColor = Color.LightSteelBlue
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaGroupBoxTrouvees.Text = "ANNONCE D'OBJETS TROUVES"
                GunaLabel17.Text = "Endroit où l'objet a été retrouvé"
                GunaLabel16.Text = "Date de retrouvail"
            Else
                GunaGroupBoxTrouvees.Text = "ANNOUNCEMENT OF FOUND OBJECTS"
                GunaLabel17.Text = "Where the object was found"
                GunaLabel16.Text = "Find date"
            End If
        Else

            GunaGroupBoxTrouvees.LineColor = Color.DarkKhaki
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaGroupBoxTrouvees.Text = "ANNONCE D'OBJETS PERDUS"
                GunaLabel17.Text = "Endroit où l'objet a été perdu"
                GunaLabel16.Text = "Date de perte"
            Else
                GunaGroupBoxTrouvees.Text = "LOST AND FOUND REPORT"
                GunaLabel17.Text = "Where the object was lost"
                GunaLabel16.Text = "Date of lost"
            End If
        End If

    End Sub

    Private Sub GunaComboBoxRegistre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxRegistre.SelectedIndexChanged

        GunaDataGridViewRegistreObjets.Columns.Clear()

        GunaComboBoxNature.Visible = True

        If GunaComboBoxRegistre.SelectedIndex = 0 Then

            GunaGroupBoxRegistre.LineColor = Color.LightSteelBlue

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaGroupBoxRegistre.Text = "REGISTRE D'OBJETS TROUVES"
            Else
                GunaGroupBoxRegistre.Text = "FOUND OBJECT REGISTER"
            End If
        ElseIf GunaComboBoxRegistre.SelectedIndex = 1 Then

            GunaGroupBoxRegistre.LineColor = Color.DarkKhaki
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaGroupBoxRegistre.Text = "LOST PROPERTY REGISTERS"
            Else
                GunaGroupBoxRegistre.Text = ""
            End If
        ElseIf GunaComboBoxRegistre.SelectedIndex = 2 Then
            GunaGroupBoxRegistre.LineColor = Color.LightGreen
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaGroupBoxRegistre.Text = "OBJET RESTITUES"
            Else
                GunaGroupBoxRegistre.Text = "RETURNED OBJECTS"
            End If
        End If

    End Sub

    'Enregistrment d'annonce
    Private Sub GunaButtonSaveObjets_Click(sender As Object, e As EventArgs) Handles GunaButtonSaveObjets.Click

        Dim CODE_OBJET As String = Functions.GeneratingRandomCode("objet__perdu_trouve", "")
        Dim TITRE As String = GunaTextBoxTitre.Text
        Dim LIEU As String = GunaTextBoxLieu.Text
        Dim DATE_ANNONCE As Date = GunaDateTimePickerDateAnnonce.Value.ToLongDateString
        Dim CATEGORIE As String = GunaComboBoxCategorie.SelectedItem
        Dim SOUS_CATEGORIE As String = GunaComboBoxSousCategorie.SelectedValue.ToString
        Dim FABRICANT As String = GunaTextBoxFabricant.Text
        Dim MODEL As String = GunaTextBoxModel.Text
        Dim NUMERO_DE_SERIE As String = GunaTextBoxNumSerie.Text
        Dim DESCRIPTION As String = GunaTextBoxDescription.Text
        Dim COULEUR As String = GunaTextBoxCouleur.Text

        Dim NATURE As String = ""

        'Gestion des affichages d'objets en fonction dela nature de l'objet
        If Trim(GunaGroupBoxTrouvees.Text) = "OBJET A RESTITUER" Or Trim(GunaGroupBoxTrouvees.Text) = "ITEM TO BE RETURNED" Then

            If GlobalVariable.actualLanguageValue = 1 Then
                NATURE = "Objets Restitués"
            Else
                NATURE = "Returned items"
            End If

        Else
            NATURE = GunaComboBoxNature.SelectedItem.ToString
        End If

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim service As New ServicesEtage

        If GunaButtonSaveObjets.Text = "Sauvegarder" Or GunaButtonSaveObjets.Text = "Update" Then

            CODE_OBJET = GunaTextBoxCodeObjet.Text

            If service.updateObjet(CODE_OBJET, TITRE, LIEU, DATE_ANNONCE, CATEGORIE, SOUS_CATEGORIE, FABRICANT, MODEL, NUMERO_DE_SERIE, DESCRIPTION, COULEUR, NATURE, CODE_AGENCE) Then
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Vous avez mis à jours avec succès un objet", "Objet trouvés/perdus", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("You have successfully updated an object", "Lost and Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Problème lors de mise à jours de l'objet", "Objet trouvés/perdus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Problem when updating item", "Lost And Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonSaveObjets.Text = "Enregistrer"
            Else
                GunaButtonSaveObjets.Text = "Save"
            End If

        Else

            If service.insertObjet(CODE_OBJET, TITRE, LIEU, DATE_ANNONCE, CATEGORIE, SOUS_CATEGORIE, FABRICANT, MODEL, NUMERO_DE_SERIE, DESCRIPTION, COULEUR, NATURE, CODE_AGENCE) Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Vous avez ajouté avec succès un nouvel objet", "Objet trouvés/perdus", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("You have successfully added a new object", "Lost and Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Problème lors de l'ajout de l'objet", "Objet trouvés/perdus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Problem adding object", "Lost and Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        End If

        Functions.SiplifiedClearTextBox(Me)

    End Sub

    'Affichage de l'ensemble des objets
    Private Sub GunaButtonArricherReservation_Click(sender As Object, e As EventArgs) Handles GunaButtonArricherReservation.Click
        Dim service As New ServicesEtage()
        GunaDataGridViewRegistreObjets.DataSource = service.listeDesObjets(GunaComboBoxRegistre.SelectedItem.ToString, "objet__perdu_trouve", "NATURE")
    End Sub

    'Edition d'un objet
    Private Sub GunaDataGridViewRegistreObjets_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRegistreObjets.CellDoubleClick

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaButtonSaveObjets.Text = "Sauvegarder"
        Else
            GunaButtonSaveObjets.Text = "Save"
        End If

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewRegistreObjets.Rows(e.RowIndex)

            Dim objet As DataTable = Functions.getElementByCode(row.Cells("CODE OBJET").Value.ToString, "objet__perdu_trouve", "CODE_OBJET")

            If objet.Rows.Count > 0 Then

                GunaTextBoxCodeObjet.Text = objet.Rows(0)("CODE_OBJET")
                GunaTextBoxTitre.Text = objet.Rows(0)("TITRE")
                GunaTextBoxLieu.Text = objet.Rows(0)("LIEU")
                GunaDateTimePickerDateAnnonce.Value = objet.Rows(0)("DATE_ANNONCE")
                GunaComboBoxCategorie.SelectedItem = objet.Rows(0)("CATEGORIE")
                GunaComboBoxSousCategorie.SelectedItem = objet.Rows(0)("SOUS_CATEGORIE")
                GunaTextBoxFabricant.Text = objet.Rows(0)("FABRICANT")
                GunaTextBoxModel.Text = objet.Rows(0)("MODEL")
                GunaTextBoxNumSerie.Text = objet.Rows(0)("NUMERO_DE_SERIE")
                GunaTextBoxDescription.Text = objet.Rows(0)("DESCRIPTION")
                GunaTextBoxCouleur.Text = objet.Rows(0)("COULEUR")
                GunaComboBoxNature.SelectedItem = objet.Rows(0)("NATURE")

            End If

            GunaDataGridViewRegistreObjets.Columns.Clear()
        End If

    End Sub

    'NETTOYAGE DES CHAMBRES
    Private Sub GunaTextBoxEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextPersonnel.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextPersonnel.Text).Equals("") Then
            GunaDataGridViewPersonnel.Visible = False
        End If

        GunaDataGridViewPersonnel.Visible = True

        'Dim query As String = "SELECT NOM_PERSONNEL,PRENOM_PERSONNEL From personnel INNER JOIN type_personnel WHERE personnel.CODE_TYPE_PERSONNEL = type_personnel.CODE_TYPE_PERSONNEL AND LIBELLE_TYPE_PERSONNEL=@LIBELLE_TYPE_PERSONNEL AND NOM_PERSONNEL Like '%" & GunaTextPersonnel.Text & "%'"
        'Dim query As String = "SELECT NOM_PERSONNEL,PRENOM_PERSONNEL From personnel INNER JOIN type_personnel WHERE personnel.CODE_TYPE_PERSONNEL = type_personnel.CODE_TYPE_PERSONNEL AND NOM_PERSONNEL Like '%" & GunaTextPersonnel.Text & "%'"
        Dim query As String = "SELECT NOM_PERSONNEL,PRENOM_PERSONNEL From personnel WHERE NOM_PERSONNEL Like '%" & GunaTextPersonnel.Text & "%' OR PRENOM_PERSONNEL Like '%" & GunaTextPersonnel.Text & "%'"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command.Parameters.Add("@LIBELLE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = "FEMME DE CHAMBRE"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewPersonnel.DataSource = table
        Else
            GunaDataGridViewPersonnel.Columns.Clear()
            GunaDataGridViewPersonnel.Visible = False
        End If

        If GunaTextPersonnel.Text.Trim().Equals("") Then
            GunaDataGridViewPersonnel.Columns.Clear()
            GunaDataGridViewPersonnel.Visible = False
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaDataGridViewPersonnel_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPersonnel.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPersonnel.Rows(e.RowIndex)

            Dim personnel As DataTable = Functions.GetAllElementsOnTwoConditions(row.Cells("NOM_PERSONNEL").Value.ToString, "personnel", "NOM_PERSONNEL", row.Cells("PRENOM_PERSONNEL").Value.ToString, "PRENOM_PERSONNEL")

            GunaTextPersonnel.Text = row.Cells("NOM_PERSONNEL").Value.ToString & " " & row.Cells("PRENOM_PERSONNEL").Value.ToString
            GunaTextBoxCodePersonnel.Text = personnel.Rows(0)("CODE_PERSONNEL")

            GunaDataGridViewPersonnel.Visible = False

            'connect.closeConnection()

        End If

    End Sub

    Private Sub GunaButtonP1_Click(sender As Object, e As EventArgs) Handles GunaButtonP1.Click
        GunaTextBoxPersonnelCode1.Text = GunaTextPersonnel.Text
        GunaTextBox6.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP2_Click(sender As Object, e As EventArgs) Handles GunaButtonP2.Click
        GunaTextBoxPersonnelCode2.Text = GunaTextPersonnel.Text
        GunaTextBox8.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP3_Click(sender As Object, e As EventArgs) Handles GunaButtonP3.Click
        GunaTextBoxPersonnelCode3.Text = GunaTextPersonnel.Text
        GunaTextBox12.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP4_Click(sender As Object, e As EventArgs) Handles GunaButtonP4.Click
        GunaTextBoxPersonnelCode4.Text = GunaTextPersonnel.Text
        GunaTextBox10.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP5_Click(sender As Object, e As EventArgs) Handles GunaButtonP5.Click
        GunaTextBoxPersonnelCode5.Text = GunaTextPersonnel.Text
        GunaTextBox14.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP6_Click(sender As Object, e As EventArgs) Handles GunaButtonP6.Click
        GunaTextBoxPersonnelCode6.Text = GunaTextPersonnel.Text
        GunaTextBox16.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    'calcul du total après basculement
    Private Sub CalculDuTotalApresBasculement()

        GunaTextBoxP1.Text = GunaDataGridViewP1.Rows.Count
        GunaTextBoxP2.Text = GunaDataGridViewP2.Rows.Count
        GunaTextBoxP3.Text = GunaDataGridViewP3.Rows.Count
        GunaTextBoxP4.Text = GunaDataGridViewP4.Rows.Count
        GunaTextBoxP5.Text = GunaDataGridViewP5.Rows.Count
        GunaTextBoxP6.Text = GunaDataGridViewP6.Rows.Count

    End Sub

    Public Sub deplacemntDeLigne(ByVal GridDepart As DataGridView, ByVal GridArrive As DataGridView)

        If GridDepart.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GridDepart.SelectedRows(0)
            GridDepart.Rows.Remove(selectedgrid)
            GridArrive.Rows.Add(selectedgrid)

            CalculDuTotalApresBasculement()

        End If

    End Sub

    'P0 > P1 
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        deplacemntDeLigne(GunaDataGridViewP0, GunaDataGridViewP1)
    End Sub

    'P1 > P0 
    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        deplacemntDeLigne(GunaDataGridViewP1, GunaDataGridViewP0)
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        deplacemntDeLigne(GunaDataGridViewP0, GunaDataGridViewP2)
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        deplacemntDeLigne(GunaDataGridViewP2, GunaDataGridViewP0)
    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        deplacemntDeLigne(GunaDataGridViewP0, GunaDataGridViewP3)
    End Sub

    Private Sub GunaButton13_Click(sender As Object, e As EventArgs) Handles GunaButton13.Click
        deplacemntDeLigne(GunaDataGridViewP3, GunaDataGridViewP0)
    End Sub

    Private Sub GunaButton14_Click(sender As Object, e As EventArgs) Handles GunaButton14.Click
        deplacemntDeLigne(GunaDataGridViewP0, GunaDataGridViewP4)
    End Sub

    Private Sub GunaButton15_Click(sender As Object, e As EventArgs) Handles GunaButton15.Click
        deplacemntDeLigne(GunaDataGridViewP4, GunaDataGridViewP0)
    End Sub

    Private Sub GunaButton16_Click(sender As Object, e As EventArgs) Handles GunaButton16.Click
        deplacemntDeLigne(GunaDataGridViewP0, GunaDataGridViewP5)
    End Sub

    Private Sub GunaButton17_Click(sender As Object, e As EventArgs) Handles GunaButton17.Click
        deplacemntDeLigne(GunaDataGridViewP5, GunaDataGridViewP0)
    End Sub

    Private Sub GunaButton18_Click(sender As Object, e As EventArgs) Handles GunaButton18.Click
        deplacemntDeLigne(GunaDataGridViewP0, GunaDataGridViewP6)
    End Sub

    Private Sub GunaButton19_Click(sender As Object, e As EventArgs) Handles GunaButton19.Click
        deplacemntDeLigne(GunaDataGridViewP6, GunaDataGridViewP0)
    End Sub



    '------------------------ REMOVE HERE ------------------------

    Public Sub StatusDesChambres()

        If GunaRadioButtonChambre.Checked Then

            'CHAMBRE

            Dim roomList As New Room()
            Dim rooms As DataTable = roomList.roomsOnly()

            Dim xValue As Integer = 0

            Dim yValue As Integer = 110

            If rooms.Rows.Count > 0 Then

                For i As Integer = 0 To rooms.Rows.Count - 1 Step 1

                    Dim nomCLient As String = ""
                    Dim emailCLient As String = ""

                    Dim toolTip As New ToolTip()

                    Dim buttonColor As Color
                    Dim textColor As Color = Color.White
                    Dim ClientInRoom As DataTable

                    If rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_sale Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_sale Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Occupied dirty" Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Free dirty" Then
                        buttonColor = Color.Red
                        'toolTip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                        'toolTip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))
                    ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_propre Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_propre Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Occupied clean" Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Free clean" Then

                        'La chambre étant occupée on cherche à savoir si c'est une réservation ou un check in

                        Dim existQuery As String = "SELECT * FROM reservation WHERE TYPE=@TYPE AND CHAMBRE_ID=@CODE_CHAMBRE ORDER BY DATE_ENTTRE DESC"

                        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

                        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(rooms.Rows(i)("CODE_CHAMBRE"))

                        Dim adapter As New MySqlDataAdapter(command)
                        Dim table As New DataTable()

                        adapter.Fill(table)

                        If Not table.Rows.Count > 0 Then

                            Dim existQuery1 As String = "SELECT * FROM reserve_conf WHERE TYPE=@TYPE AND CHAMBRE_ID=@CODE_CHAMBRE ORDER BY DATE_ENTTRE DESC"

                            Dim command1 As New MySqlCommand(existQuery1, GlobalVariable.connect)

                            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                            command1.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(rooms.Rows(i)("CODE_CHAMBRE"))

                            Dim adapter1 As New MySqlDataAdapter(command1)
                            Dim table1 As New DataTable()
                            adapter1.Fill(table1)

                            If table1.Rows.Count > 0 Then

                                'ClientInRoom = Functions.getElementByCode("1351808216575", "client", "CODE_CLIENT")
                                'toolTip.ToolTipTitle = ClientInRoom.Rows(0)("NOM_PRENOM").ToString
                                'toolTip.SetToolTip(customPictureBox, ClientInRoom.Rows(0)("EMAIL"))
                            End If

                        Else

                            'ClientInRoom = Functions.getElementByCode("1351808216575", "client", "CODE_CLIENT")
                            'toolTip.ToolTipTitle = ClientInRoom.Rows(0)("NOM_PRENOM").ToString
                            'toolTip.SetToolTip(customPictureBox, ClientInRoom.Rows(0)("EMAIL"))
                        End If

                        buttonColor = Color.ForestGreen
                        textColor = Color.Black
                        'toolTip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                        'toolTip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))

                    ElseIf rooms.Rows(i)("ETAT_CHAMBRE") = 1 Or rooms.Rows(i)("ETAT_CHAMBRE") = 5 Then
                        buttonColor = Color.Black

                        'Tip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                        'Tip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))

                    ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Attente" Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Waiting" Then

                        buttonColor = Color.Orange

                    ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Nettoyage" Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Cleaning" Then

                        buttonColor = Color.OrangeRed

                    End If

                    'ddHandlercustomPanel.Click, AddressOf Update

                    Dim customPanel As New Panel
                    customPanel.Text = "Test" & i
                    customPanel.Name = "a" & i
                    customPanel.Location = New Point(5 + xValue, 35 + yValue)
                    customPanel.BackColor = buttonColor
                    customPanel.ForeColor = textColor
                    'customPanel.Size = New Size(75, 103)
                    customPanel.Size = New Size(108, 50)
                    customPanel.Anchor = AnchorStyles.None

                    Dim customLabel As New Label

                    customLabel.AutoSize = True
                    customLabel.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    customLabel.Location = New System.Drawing.Point(5, 35)
                    customLabel.Name = "customLabel"
                    customLabel.Size = New System.Drawing.Size(108, 20)
                    customLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    customLabel.TabIndex = 4

                    If Not Trim(rooms.Rows(i)("GUEST_DAI")) = "" Then
                        customLabel.Text = "Message"
                    Else

                        Dim CODE_CHAMBRE As String = Trim(rooms.Rows(i)("CODE_CHAMBRE"))

                        Dim STATUTS As Integer = 0
                        Dim STATUTS_1 As Integer = 1
                        Dim STATUTS_2 As Integer = 2
                        Dim STATUTS_3 As Integer = 3

                        customLabel.Text = personneDevantNettoyerDansStatutDeChambre(CODE_CHAMBRE, STATUTS, STATUTS_1, STATUTS_2, STATUTS_3)

                    End If

                    customPanel.Controls.Add(customLabel)

                    'customLabel.Text = ""
                    'NOM DE LA PERSONNE DEVANT NETTOYER ------------------------------------------

                    Dim customPanel1 As New Panel
                    customPanel1.Text = "Test1" & i
                    customPanel1.Name = "a1" & i
                    customPanel1.Location = New Point(5 + xValue, 35 + yValue)
                    customPanel1.BackColor = buttonColor
                    customPanel1.ForeColor = textColor
                    'customPanel.Size = New Size(75, 103)
                    customPanel1.Size = New Size(108, 50)
                    customPanel1.Anchor = AnchorStyles.None

                    Dim customLabel1 As New Label

                    customLabel1.AutoSize = True
                    customLabel1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    customLabel1.Location = New System.Drawing.Point(25, 30)
                    customLabel1.Name = "customLabel"
                    customLabel1.Size = New System.Drawing.Size(108, 20)
                    customLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    customLabel1.TabIndex = 4

                    customPanel1.Controls.Add(customLabel1)

                    '-----------------------------------------------------------------------------------------------------

                    Dim customButton As New Button

                    'customButton.AnimationHoverSpeed = 0.07!
                    'customButton.AnimationSpeed = 0.03!
                    customButton.FlatStyle = FlatStyle.Flat
                    customButton.BackColor = buttonColor
                    'customButton.BorderColor = System.Drawing.Color.Black
                    customButton.DialogResult = System.Windows.Forms.DialogResult.None
                    'customButton.FocusedColor = System.Drawing.Color.Empty
                    customButton.Font = New System.Drawing.Font("Segoe UI", 10.0!)
                    customButton.ForeColor = System.Drawing.Color.White
                    'If True Then

                    'Else

                    'End If
                    customButton.Image = Nothing
                    customButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    'customButton.ImageSize = New System.Drawing.Size(52, 52)
                    customButton.Location = New System.Drawing.Point(0, 0)
                    customButton.Name = rooms.Rows(i)("CODE_CHAMBRE")
                    'customButton.OnHoverBaseColor = buttonColor
                    'customButton.OnHoverBorderColor = buttonColor
                    'customButton.OnHoverForeColor = System.Drawing.Color.White
                    'customButton.OnHoverImage = Nothing
                    'customButton.OnPressedColor = System.Drawing.Color.Black
                    customButton.Size = New System.Drawing.Size(108, 50)
                    customButton.TabIndex = 3
                    customButton.Text = rooms.Rows(i)("CODE_CHAMBRE")
                    customButton.TextAlign = System.Drawing.ContentAlignment.TopCenter

                    'POUR CHACUNE DES CHAMBRES ON POSE UN EVENEMENT DE TYPE CLICK

                    AddHandler customButton.Click, AddressOf onClick
                    AddHandler customPanel.Click, AddressOf onClick

                    customPanel.Controls.Add(customButton)

                    TabPageNettoyage.Controls.Add(customPanel)

                    toolTip.ShowAlways = True

                    toolTip.UseFading = True
                    toolTip.UseAnimation = True
                    toolTip.IsBalloon = True
                    toolTip.AutoPopDelay = 5000

                    xValue = xValue + 120

                    'alignement 
                    If (i + 1) Mod 11 = 0 Then
                        xValue = 0
                        yValue = yValue + 60
                    End If

                Next

            End If

        ElseIf GunaRadioButtonSalle.Checked Then

            'SALLE
            Dim roomList As New Room()

            Dim rooms As DataTable = roomList.sallesOnly()

            Dim xValue As Integer = 0

            Dim yValue As Integer = 110

            If rooms.Rows.Count > 0 Then

                For i As Integer = 0 To rooms.Rows.Count - 1 Step 1

                    Dim nomCLient As String = ""
                    Dim emailCLient As String = ""

                    Dim toolTip As New ToolTip()

                    Dim buttonColor As Color
                    Dim textColor As Color = Color.White
                    Dim ClientInRoom As DataTable

                    If rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_sale Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_sale Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Occupied dirty" Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Free dirty" Then
                        buttonColor = Color.Red
                        'toolTip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                        'toolTip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))
                    ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_propre Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_propre Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Occupied clean" Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Free clean" Then

                        'La chambre étant occupée on cherche à savoir si c'est une réservation ou un check in

                        Dim existQuery As String = "SELECT * FROM reservation WHERE TYPE=@TYPE AND CHAMBRE_ID=@CODE_CHAMBRE ORDER BY DATE_ENTTRE DESC"

                        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

                        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(rooms.Rows(i)("CODE_CHAMBRE"))

                        Dim adapter As New MySqlDataAdapter(command)
                        Dim table As New DataTable()

                        adapter.Fill(table)

                        If Not table.Rows.Count > 0 Then

                            Dim existQuery1 As String = "SELECT * FROM reserve_conf WHERE TYPE=@TYPE AND CHAMBRE_ID=@CODE_CHAMBRE ORDER BY DATE_ENTTRE DESC"

                            Dim command1 As New MySqlCommand(existQuery1, GlobalVariable.connect)

                            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                            command1.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(rooms.Rows(i)("CODE_CHAMBRE"))

                            Dim adapter1 As New MySqlDataAdapter(command1)
                            Dim table1 As New DataTable()
                            adapter1.Fill(table1)

                            If table1.Rows.Count > 0 Then

                                'ClientInRoom = Functions.getElementByCode("1351808216575", "client", "CODE_CLIENT")
                                'toolTip.ToolTipTitle = ClientInRoom.Rows(0)("NOM_PRENOM").ToString
                                'toolTip.SetToolTip(customPictureBox, ClientInRoom.Rows(0)("EMAIL"))
                            End If

                        Else

                            'ClientInRoom = Functions.getElementByCode("1351808216575", "client", "CODE_CLIENT")
                            'toolTip.ToolTipTitle = ClientInRoom.Rows(0)("NOM_PRENOM").ToString
                            'toolTip.SetToolTip(customPictureBox, ClientInRoom.Rows(0)("EMAIL"))
                        End If

                        buttonColor = Color.ForestGreen
                        textColor = Color.Black
                        'toolTip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                        'toolTip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))

                    ElseIf rooms.Rows(i)("ETAT_CHAMBRE") = 1 Or rooms.Rows(i)("ETAT_CHAMBRE") = 5 Then
                        buttonColor = Color.Black

                        'Tip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                        'Tip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))

                    ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Attente" Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Waiting" Then

                        buttonColor = Color.Orange

                    ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Nettoyage" Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = "Cleaning" Then

                        buttonColor = Color.OrangeRed

                    End If

                    'ddHandlercustomPanel.Click, AddressOf Update

                    Dim customPanel As New Panel
                    customPanel.Text = "Test" & i
                    customPanel.Name = "a" & i
                    customPanel.Location = New Point(5 + xValue, 35 + yValue)
                    customPanel.BackColor = buttonColor
                    customPanel.ForeColor = textColor
                    'customPanel.Size = New Size(75, 103)
                    customPanel.Size = New Size(108, 50)
                    customPanel.Anchor = AnchorStyles.None

                    Dim customLabel As New Label

                    customLabel.AutoSize = True
                    customLabel.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    customLabel.Location = New System.Drawing.Point(5, 35)
                    customLabel.Name = "customLabel"
                    customLabel.Size = New System.Drawing.Size(108, 20)
                    customLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    customLabel.TabIndex = 4

                    If Not Trim(rooms.Rows(i)("GUEST_DAI")) = "" Then
                        customLabel.Text = "Message"
                    Else

                        Dim CODE_CHAMBRE As String = Trim(rooms.Rows(i)("CODE_CHAMBRE"))

                        Dim STATUTS As Integer = 0
                        Dim STATUTS_1 As Integer = 1
                        Dim STATUTS_2 As Integer = 2
                        Dim STATUTS_3 As Integer = 3

                        customLabel.Text = personneDevantNettoyerDansStatutDeChambre(CODE_CHAMBRE, STATUTS, STATUTS_1, STATUTS_2, STATUTS_3)

                    End If

                    customPanel.Controls.Add(customLabel)

                    'customLabel.Text = ""
                    'NOM DE LA PERSONNE DEVANT NETTOYER ------------------------------------------

                    Dim customPanel1 As New Panel
                    customPanel1.Text = "Test1" & i
                    customPanel1.Name = "a1" & i
                    customPanel1.Location = New Point(5 + xValue, 35 + yValue)
                    customPanel1.BackColor = buttonColor
                    customPanel1.ForeColor = textColor
                    'customPanel.Size = New Size(75, 103)
                    customPanel1.Size = New Size(108, 50)
                    customPanel1.Anchor = AnchorStyles.None

                    Dim customLabel1 As New Label

                    customLabel1.AutoSize = True
                    customLabel1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    customLabel1.Location = New System.Drawing.Point(25, 30)
                    customLabel1.Name = "customLabel"
                    customLabel1.Size = New System.Drawing.Size(108, 20)
                    customLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    customLabel1.TabIndex = 4

                    customPanel1.Controls.Add(customLabel1)

                    '-----------------------------------------------------------------------------------------------------

                    Dim customButton As New Button

                    'customButton.AnimationHoverSpeed = 0.07!
                    'customButton.AnimationSpeed = 0.03!
                    customButton.FlatStyle = FlatStyle.Flat
                    customButton.BackColor = buttonColor
                    'customButton.BorderColor = System.Drawing.Color.Black
                    customButton.DialogResult = System.Windows.Forms.DialogResult.None
                    'customButton.FocusedColor = System.Drawing.Color.Empty
                    customButton.Font = New System.Drawing.Font("Segoe UI", 10.0!)
                    customButton.ForeColor = System.Drawing.Color.White
                    'If True Then

                    'Else

                    'End If
                    customButton.Image = Nothing
                    customButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    'customButton.ImageSize = New System.Drawing.Size(52, 52)
                    customButton.Location = New System.Drawing.Point(0, 0)
                    customButton.Name = rooms.Rows(i)("CODE_CHAMBRE")
                    'customButton.OnHoverBaseColor = buttonColor
                    'customButton.OnHoverBorderColor = buttonColor
                    'customButton.OnHoverForeColor = System.Drawing.Color.White
                    'customButton.OnHoverImage = Nothing
                    'customButton.OnPressedColor = System.Drawing.Color.Black
                    customButton.Size = New System.Drawing.Size(108, 50)
                    customButton.TabIndex = 3
                    customButton.Text = rooms.Rows(i)("CODE_CHAMBRE")
                    customButton.TextAlign = System.Drawing.ContentAlignment.TopCenter

                    'POUR CHACUNE DES CHAMBRES ON POSE UN EVENEMENT DE TYPE CLICK
                    AddHandler customButton.Click, AddressOf onClick
                    AddHandler customPanel.Click, AddressOf onClick

                    customPanel.Controls.Add(customButton)

                    TabPageNettoyage.Controls.Add(customPanel)

                    toolTip.ShowAlways = True

                    toolTip.UseFading = True
                    toolTip.UseAnimation = True
                    toolTip.IsBalloon = True
                    toolTip.AutoPopDelay = 5000

                    xValue = xValue + 120

                    'alignement 
                    If (i + 1) Mod 11 = 0 Then
                        xValue = 0
                        yValue = yValue + 60
                    End If

                Next

            End If

        End If

    End Sub

    Private Sub onClick(ByVal sender As Object, ByVal e As System.EventArgs)

        GlobalVariable.btnNettoyage = CType(sender, Button)
        Dim btn As Button = GlobalVariable.btnNettoyage
        EtatDeChambreForm.GunaTextBoxMessage.Clear()
        EtatDeChambreForm.GunaTextBoxMessage.Text = Functions.getElementByCode(btn.Name, "chambre", "CODE_CHAMBRE").Rows(0)("GUEST_DAI")
        EtatDeChambreForm.GunaLabelChmabreEncoursDeNettoyage.Text = btn.Name
        Dim CODE_CHAMBRE As String = EtatDeChambreForm.GunaLabelChmabreEncoursDeNettoyage.Text
        Dim room As DataTable = Functions.getElementByCode(CODE_CHAMBRE, "chambre", "CODE_CHAMBRE")

        'Dim roomNettoyage As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_CHAMBRE, "nettoyage", "CODE_CHAMBRE", STATUTS, "STATUTS")

        Dim roomNettoyage As DataTable

        If room.Rows.Count > 0 Then

            If room.Rows(0)("ETAT_CHAMBRE_NOTE") = "Nettoyage" Or room.Rows(0)("ETAT_CHAMBRE_NOTE") = "Cleaning" Then

                EtatDeChambreForm.PictureBox1.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonTerminer.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonTerminer.Enabled = False
                EtatDeChambreForm.GunaAdvenceButtonFin.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonFin.Enabled = True
                'EtatDeChambreForm.GunaAdvenceButtonDébuter.Visible = False
                EtatDeChambreForm.GunaAdvenceButtonDébuter.Enabled = False

                'Gestion de l'affichage du temps de nettoyage

                'Sélection des informations de la chambre dans la table nettoyage
                Dim STATUTS As Integer = 1 'chambre dont le nettoyage a débuté donc en cours de nettoyage
                'roomNettoyage = Functions.GetAllElementsOnTwoConditions(CODE_CHAMBRE, "nettoyage", "CODE_CHAMBRE", STATUTS, "STATUTS")
                roomNettoyage = selectionDesChambresANettoyer(STATUTS)

                If roomNettoyage.Rows.Count > 0 Then
                    EtatDeChambreForm.GunaLabelHeureDebut.Visible = True
                    EtatDeChambreForm.GunaLabelHeureDebut.Text = CDate(roomNettoyage.Rows(0)("HEURE_DEBUT")).ToLongTimeString
                    EtatDeChambreForm.GunaLabelHeureFin.Visible = False
                    EtatDeChambreForm.GunaLabelHeureControle.Visible = False

                    EtatDeChambreForm.GunaLabelNomDuNettoyeur.Text = roomNettoyage.Rows(0)("NOM_COMPLET_PERSONNEL")

                End If

            ElseIf room.Rows(0)("ETAT_CHAMBRE_NOTE") = "Attente" Or room.Rows(0)("ETAT_CHAMBRE_NOTE") = "Waiting" Then

                EtatDeChambreForm.PictureBox2.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonTerminer.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonTerminer.Enabled = True
                EtatDeChambreForm.GunaAdvenceButtonFin.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonFin.Enabled = False
                EtatDeChambreForm.GunaAdvenceButtonDébuter.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonDébuter.Enabled = False

                Dim STATUTS As Integer = 2 'chambre dont le nettoyage est terrminé
                'roomNettoyage = Functions.GetAllElementsOnTwoConditions(CODE_CHAMBRE, "nettoyage", "CODE_CHAMBRE", STATUTS, "STATUTS")
                roomNettoyage = selectionDesChambresANettoyer(STATUTS)

                If roomNettoyage.Rows.Count > 0 Then
                    EtatDeChambreForm.GunaLabelHeureDebut.Visible = True
                    EtatDeChambreForm.GunaLabelHeureDebut.Text = CDate(roomNettoyage.Rows(0)("HEURE_DEBUT")).ToLongTimeString
                    EtatDeChambreForm.GunaLabelHeureFin.Visible = True
                    EtatDeChambreForm.GunaLabelHeureFin.Text = CDate(roomNettoyage.Rows(0)("HEURE_FIN")).ToLongTimeString
                    EtatDeChambreForm.GunaLabelHeureControle.Visible = False

                    EtatDeChambreForm.GunaLabelNomDuNettoyeur.Text = roomNettoyage.Rows(0)("NOM_COMPLET_PERSONNEL")

                End If

            Else

                Dim STATUTS As Integer = 0 'chambre non netoyer mais sale

                'roomNettoyage = Functions.GetAllElementsOnTwoConditions(CODE_CHAMBRE, "nettoyage", "CODE_CHAMBRE", STATUTS, "STATUTS")
                roomNettoyage = selectionDesChambresANettoyer(STATUTS) 'PROPRE A UN JOUR SPECIFIQUE

                If roomNettoyage.Rows.Count > 0 Then

                    EtatDeChambreForm.GunaLabelHeureDebut.Visible = True
                    EtatDeChambreForm.GunaLabelHeureDebut.Text = CDate(roomNettoyage.Rows(0)("HEURE_DEBUT")).ToLongTimeString
                    EtatDeChambreForm.GunaLabelHeureFin.Visible = True
                    EtatDeChambreForm.GunaLabelHeureFin.Text = CDate(roomNettoyage.Rows(0)("HEURE_FIN")).ToLongTimeString
                    EtatDeChambreForm.GunaLabelHeureControle.Visible = False

                    EtatDeChambreForm.GunaLabelNomDuNettoyeur.Text = roomNettoyage.Rows(0)("NOM_COMPLET_PERSONNEL")

                End If

                'Traitement du netoyage aucun click sur l'un des trois bouton
                EtatDeChambreForm.PictureBox1.Visible = False
                EtatDeChambreForm.PictureBox2.Visible = False
                EtatDeChambreForm.GunaAdvenceButtonTerminer.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonTerminer.Enabled = False
                EtatDeChambreForm.GunaAdvenceButtonFin.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonFin.Enabled = False
                EtatDeChambreForm.GunaAdvenceButtonDébuter.Visible = True
                EtatDeChambreForm.GunaAdvenceButtonDébuter.Enabled = True

                'Gestion de l'affichage du temps de nettoyage
                EtatDeChambreForm.GunaLabelHeureDebut.Visible = False
                EtatDeChambreForm.GunaLabelHeureFin.Visible = False
                EtatDeChambreForm.GunaLabelHeureControle.Visible = False

            End If

        End If

        If roomNettoyage.Rows.Count > 0 Then
            EtatDeChambreForm.TopMost = True
            EtatDeChambreForm.Show()
        Else

        End If

    End Sub

    Public Function selectionDesChambresANettoyer(ByVal STATUTS As Integer)

        'SELECTION DES CHAMBRES SALES DU JOUR DEJA ATTRIBUEES

        Dim DateDebut As Date = CDate(GlobalVariable.DateDeTravail).ToString("yyyy-MM-dd")

        Dim Query1 As String = "SELECT * FROM `nettoyage` WHERE STATUTS=@STATUTS AND DATE_CREATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "'"
        Dim command1 = New MySqlCommand(Query1, GlobalVariable.connect)
        command1.Parameters.Add("@STATUTS", MySqlDbType.Int64).Value = STATUTS

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()

        adapter1.Fill(table1)

        Return table1
    End Function

    Public Sub StatistiquesDeNettoyage()

        Dim roomList As New Room()

        Dim Room As DataTable

        If GunaRadioButtonChambre.Checked Then
            Room = roomList.roomsOnly()
        ElseIf GunaRadioButtonSalle.Checked Then
            Room = roomList.sallesOnly()
        End If

        Dim sale As Integer = 0
        Dim propre As Integer = 0
        Dim horsService As Integer = 0
        Dim aInspecter As Integer = 0
        Dim enCours As Integer = 0

        If Room.Rows.Count > 0 Then

            For i = 0 To Room.Rows.Count - 1

                If Room.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_sale Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_sale Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Occupied dirty" Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Clean dirty" Then
                    'Chambre sale
                    sale += 1
                ElseIf Room.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_propre Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_propre Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Occupied clean" Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Free clean" Then
                    propre += 1
                ElseIf Room.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.hors_service Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Out of Service" Then
                    horsService += 1
                ElseIf Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Nettoyage" Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Cleaning" Then
                    'En cours de nettoyage
                    enCours += 1
                ElseIf Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Attente" Or Room.Rows(i)("ETAT_CHAMBRE_NOTE") = "Waiting" Then
                    'Chambre dont le nettoyage est termine et en attente de validation
                    aInspecter += 1
                End If

            Next

        End If

        Dim xValue As Integer = 5
        Dim yValue As Integer = 9

        For m = 0 To 4

            Dim customPanel As New Panel
            customPanel.Text = "Test" & m
            customPanel.Name = "a" & m
            customPanel.Location = New Point(xValue, yValue)

            If m = 0 Then
                customPanel.BackColor = Color.Red
            ElseIf m = 3 Then
                customPanel.BackColor = Color.Green
            ElseIf m = 2 Then
                customPanel.BackColor = Color.Orange
            ElseIf m = 1 Then
                customPanel.BackColor = Color.OrangeRed
            ElseIf m = 4 Then
                customPanel.BackColor = Color.Black
            End If

            customPanel.ForeColor = Color.White
            'customPanel.Size = New Size(75, 103)
            customPanel.Size = New Size(220, 95)
            customPanel.Anchor = AnchorStyles.None


            Dim customLabel As New Label

            customLabel.AutoSize = True
            customLabel.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            customLabel.Name = "customLabel"
            customLabel.Size = New System.Drawing.Size(67, 81)
            customLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            customLabel.TabIndex = 4

            Dim customLabelValue As New Label

            customLabelValue.AutoSize = True
            customLabelValue.Font = New System.Drawing.Font("Segoe UI", 45.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            customLabelValue.Location = New System.Drawing.Point(75, -10)
            customLabelValue.Name = "customLabelValue"
            customLabelValue.Size = New System.Drawing.Size(67, 81)
            customLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            customLabelValue.TabIndex = 4

            'Gestion de l'etat en plus du nombre
            If m = 0 Then

                customLabelValue.Text = sale
                customLabel.Location = New System.Drawing.Point(85, 65)
                If sale > 0 Then
                    customLabel.Text = "Sales"
                Else
                    customLabel.Text = "Sale"
                End If

                If GlobalVariable.actualLanguageValue = 0 Then
                    customLabel.Text = "Dirty"
                End If

            ElseIf m = 3 Then

                customLabelValue.Text = propre
                customLabel.Location = New System.Drawing.Point(80, 65)
                If propre > 0 Then
                    customLabel.Text = "Propres"
                Else
                    customLabel.Text = "Propre"
                End If

                If GlobalVariable.actualLanguageValue = 0 Then
                    customLabel.Text = "Clean"
                End If

            ElseIf m = 2 Then
                customLabel.Location = New System.Drawing.Point(65, 65)
                customLabelValue.Text = aInspecter
                If aInspecter > 0 Then
                    customLabel.Text = "A inspecters"
                Else
                    customLabel.Text = "A inspecter"
                End If

                If GlobalVariable.actualLanguageValue = 0 Then
                    customLabel.Text = "To inspect"
                End If

            ElseIf m = 1 Then
                customLabelValue.Text = enCours
                customLabel.Location = New System.Drawing.Point(70, 65)
                If enCours > 0 Then
                    customLabel.Text = "En cours"
                Else
                    customLabel.Text = "En cours"
                End If

                If GlobalVariable.actualLanguageValue = 0 Then
                    customLabel.Text = "On going"
                End If

            ElseIf m = 4 Then
                customLabelValue.Text = horsService
                customLabel.Location = New System.Drawing.Point(55, 65)
                If horsService > 0 Then
                    customLabel.Text = "Hors services"
                Else
                    customLabel.Text = GlobalVariable.hors_service
                End If
                If GlobalVariable.actualLanguageValue = 0 Then
                    customLabel.Text = "Out of Service"
                End If
            End If

            customPanel.Controls.Add(customLabel)
            customPanel.Controls.Add(customLabelValue)

            TabPageNettoyage.Controls.Add(customPanel)

            xValue = xValue + 272

        Next


    End Sub
    '------------------------------------------------

    'HANDLER


    'Enregistrement des nettoyages
    Private Sub GunaButtonAllBottomRightToLeft_Click(sender As Object, e As EventArgs) Handles GunaButtonAllBottomRightToLeft.Click

        Dim service As New ServicesEtage()
        'Planning de nettoyage des chmabres
        service.calendrierDeNettoyage(GunaDataGridViewP1, GunaTextBoxPersonnelCode1.Text, GunaTextBox6.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP2, GunaTextBoxPersonnelCode2.Text, GunaTextBox8.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP3, GunaTextBoxPersonnelCode3.Text, GunaTextBox12.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP4, GunaTextBoxPersonnelCode4.Text, GunaTextBox10.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP5, GunaTextBoxPersonnelCode5.Text, GunaTextBox14.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP6, GunaTextBoxPersonnelCode6.Text, GunaTextBox16.Text)

        'clearing datagrid
        GunaDataGridViewP1.Rows.Clear()
        GunaDataGridViewP2.Rows.Clear()
        GunaDataGridViewP3.Rows.Clear()
        GunaDataGridViewP4.Rows.Clear()
        GunaDataGridViewP5.Rows.Clear()
        GunaDataGridViewP6.Rows.Clear()

        'clearing Name Text box
        GunaTextBoxPersonnelCode1.Clear()
        GunaTextBoxPersonnelCode2.Clear()
        GunaTextBoxPersonnelCode3.Clear()
        GunaTextBoxPersonnelCode4.Clear()
        GunaTextBoxPersonnelCode5.Clear()
        GunaTextBoxPersonnelCode6.Clear()

        'clearing quantité TextBox
        GunaTextBoxP1.Clear()
        GunaTextBoxP2.Clear()
        GunaTextBoxP3.Clear()
        GunaTextBoxP4.Clear()
        GunaTextBoxP5.Clear()
        GunaTextBoxP6.Clear()

        If GlobalVariable.actualLanguageValue = 1 Then
            MessageBox.Show("Planning établi avec succès", "Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Planning successfully established", "Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    'Ajouter un commentaire à une chambre
    Private Sub CommentaireToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommentaireToolStripMenuItem.Click

        If DataGridViewRoomListe.Rows.Count > 0 Then

            Dim CODE_CHAMBRE As String = DataGridViewRoomListe.CurrentRow.Cells("CODE CHAMBRE").Value.ToString

            EtatDeChambreForm.GunaLabelChmabreEncoursDeNettoyage.Text = CODE_CHAMBRE

            EtatDeChambreForm.GunaTextBoxMessage.Text = DataGridViewRoomListe.CurrentRow.Cells("COMMENTAIRE").Value.ToString

            'Functions.DeleteRowFromDataGridGeneral(DataGridViewRoomListe, DataGridViewRoomListe.CurrentRow.Cells("CODE CHAMBRE").Value.ToString, "chambre", "CODE_CHAMBRE"

            EtatDeChambreForm.GunaButtonEnregistrerCommentaire.Visible = True

            EtatDeChambreForm.GunaAdvenceButtonDébuter.Visible = False
            EtatDeChambreForm.GunaAdvenceButtonFin.Visible = False

            EtatDeChambreForm.GunaLabelGestionDuTemps.Visible = False

            EtatDeChambreForm.Show()

        End If

    End Sub

    Private Sub GunaButtonAfficherEtatDesChambres_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherEtatDesChambres.Click

        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
        ElseIf GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        End If

        roomList()
    End Sub

    'CHANGEMENT D'ETATS DES CHAMBRES

    'PROPRE
    Private Sub PropreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropreToolStripMenuItem.Click

        If GunaDataGridViewEtatsDesChambres.Rows.Count > 0 Then

            Dim service As New ServicesEtage()

            For Each row As DataGridViewRow In GunaDataGridViewEtatsDesChambres.SelectedRows

                Dim CODE_CHAMBRE As String = GunaDataGridViewEtatsDesChambres.CurrentRow.Cells("CODE CHAMBRE").Value.ToString
                Dim ETAT_CHAMBRE_NOTE As String = GunaDataGridViewEtatsDesChambres.CurrentRow.Cells("ETAT CHAMBRE").Value.ToString
                Dim ETAT_CHAMBRE As Integer

                'Avant d'attribuer le nouvel état on prends en compte les anciens état des chambres
                If ETAT_CHAMBRE_NOTE = GlobalVariable.occupee_sale Then

                    ETAT_CHAMBRE_NOTE = GlobalVariable.occupee_propre
                    ETAT_CHAMBRE = 0

                ElseIf ETAT_CHAMBRE_NOTE = GlobalVariable.libre_sale Then

                    ETAT_CHAMBRE_NOTE = GlobalVariable.libre_propre
                    ETAT_CHAMBRE = 0

                ElseIf ETAT_CHAMBRE_NOTE = GlobalVariable.hors_service Then

                    ETAT_CHAMBRE_NOTE = GlobalVariable.libre_propre
                    ETAT_CHAMBRE = 0

                End If

                service.ChangementEtatDesChambre(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, ETAT_CHAMBRE)

            Next

            GunaDataGridViewEtatsDesChambres.Columns.Clear()

            roomList()

        End If

    End Sub

    'SALE
    Private Sub SaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleToolStripMenuItem.Click

        Dim service As New ServicesEtage()

        'Dim CODE_CHAMBRE As String = GunaDataGridViewEtatsDesChambres.CurrentRow.Cells("CODE CHAMBRE").Value.ToString
        'Dim ETAT_CHAMBRE_NOTE As String = GunaDataGridViewEtatsDesChambres.CurrentRow.Cells("ETAT CHAMBRE").Value.ToString
        'Dim ETAT_CHAMBRE As Integer

        'Avant d'attribuer le nouvel état on prends en compte les anciens état des chambres

        For Each row As DataGridViewRow In GunaDataGridViewEtatsDesChambres.SelectedRows

            Dim CODE_CHAMBRE As String = GunaDataGridViewEtatsDesChambres.CurrentRow.Cells("CODE CHAMBRE").Value.ToString
            Dim ETAT_CHAMBRE_NOTE As String = GunaDataGridViewEtatsDesChambres.CurrentRow.Cells("ETAT CHAMBRE").Value.ToString
            Dim ETAT_CHAMBRE As Integer

            If ETAT_CHAMBRE_NOTE = GlobalVariable.occupee_propre Then

                ETAT_CHAMBRE_NOTE = GlobalVariable.occupee_sale
                ETAT_CHAMBRE = 0

            ElseIf ETAT_CHAMBRE_NOTE = GlobalVariable.libre_propre Then

                ETAT_CHAMBRE_NOTE = GlobalVariable.libre_sale
                ETAT_CHAMBRE = 0

            ElseIf ETAT_CHAMBRE_NOTE = GlobalVariable.hors_service Then

                ETAT_CHAMBRE_NOTE = GlobalVariable.libre_sale
                ETAT_CHAMBRE = 0

            End If

            service.ChangementEtatDesChambre(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, ETAT_CHAMBRE)

        Next

        GunaDataGridViewEtatsDesChambres.Columns.Clear()

        roomList()

    End Sub

    'HOR SERVICES
    Private Sub HorsServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HorsServiceToolStripMenuItem.Click

        Dim CODE_CHAMBRE As String = GunaDataGridViewEtatsDesChambres.CurrentRow.Cells("CODE CHAMBRE").Value.ToString

        EtatDeChambreForm.GunaLabelChmabreEncoursDeNettoyage.Text = CODE_CHAMBRE
        EtatDeChambreForm.TopMost = True

        EtatDeChambreForm.GunaPanelMotifHorsService.Visible = True
        EtatDeChambreForm.GunaPanelTopLine.Visible = True
        EtatDeChambreForm.Size = New Size(450, 220)

        EtatDeChambreForm.GunaPanelMotifHorsService.BringToFront()
        EtatDeChambreForm.Show()

    End Sub

    'RESTITUTION D'OBJET TROUVEES

    Private Sub RestituerLobjetToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RestituerLobjetToolStripMenuItem.Click

        'On ne peut que faire appelle a cette partie ssi on est sur un objet perdu qui a été retouvé
        If GunaGroupBoxRegistre.Text = "REGISTRE D'OBJETS TROUVES" Or GunaGroupBoxRegistre.Text = "FOUND OBJECT REGISTER" Then

            GunaGroupBoxTrouvees.LineColor = Color.LightGreen

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaGroupBoxTrouvees.Text = "OBJET A RESTITUER"
                GunaLabel16.Text = "Date de Restitution"
            Else
                GunaGroupBoxTrouvees.Text = "ITEM TO BE RETURNED"
                GunaLabel16.Text = "Restitution date"
            End If

            GunaComboBoxNature.Visible = False

            If GunaDataGridViewRegistreObjets.Rows.Count > 0 Then

                Dim CODE_OBJET As String = GunaDataGridViewRegistreObjets.CurrentRow.Cells("CODE OBJET").Value.ToString

                Dim objet As DataTable = Functions.getElementByCode(CODE_OBJET, "objet__perdu_trouve", "CODE_OBJET")

                If objet.Rows.Count > 0 Then

                    GunaTextBoxCodeObjet.Text = objet.Rows(0)("CODE_OBJET")
                    GunaTextBoxTitre.Text = objet.Rows(0)("TITRE")
                    GunaTextBoxLieu.Text = objet.Rows(0)("LIEU")
                    GunaDateTimePickerDateAnnonce.Value = objet.Rows(0)("DATE_ANNONCE")
                    GunaComboBoxCategorie.SelectedItem = objet.Rows(0)("CATEGORIE")
                    GunaComboBoxSousCategorie.SelectedItem = objet.Rows(0)("SOUS_CATEGORIE")
                    GunaTextBoxFabricant.Text = objet.Rows(0)("FABRICANT")
                    GunaTextBoxModel.Text = objet.Rows(0)("MODEL")
                    GunaTextBoxNumSerie.Text = objet.Rows(0)("NUMERO_DE_SERIE")
                    GunaTextBoxDescription.Text = objet.Rows(0)("DESCRIPTION")
                    GunaTextBoxCouleur.Text = objet.Rows(0)("COULEUR")
                    GunaComboBoxNature.SelectedItem = objet.Rows(0)("NATURE")

                End If

            End If

        End If

    End Sub

    'A la sélection d'une catégorie on définit les sous catégorie de la catégorie parent 
    Private Sub GunaComboBoxCategorie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCategorie.SelectedIndexChanged

        'sélection de tous les sous catégories d'une certaine catégorie parents
        Dim SousCategorie As DataTable = Functions.getElementByCode(Trim(GunaComboBoxCategorie.SelectedItem), "sous_categorie_objets_perdus_retrouves", "CATEGORIE_PARENT")

        If (SousCategorie.Rows.Count > 0) Then

            GunaComboBoxSousCategorie.DataSource = SousCategorie
            GunaComboBoxSousCategorie.ValueMember = "SOUS_CATEGORIE"
            GunaComboBoxSousCategorie.DisplayMember = "SOUS_CATEGORIE"

        Else
            Me.Close()
        End If

    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaLabel20_Click(sender As Object, e As EventArgs) Handles GunaLabelNotification.Click
        NotificationsForm.GunaTextBoxFromWhichWindow.Text = "etage"
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

    'ETATS DES CHAMBRES
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonEtatsDesChambres.Click
        GunaTextBoxCodeRapport.Clear()
        Functions.rapportEtatsDesChambres()
    End Sub


    Dim typeDerapport As Integer  'PLANNING DE NETTOYAGE
    '0 : planning de nettoyage

    'PLANNING DE NETTOYAGE
    Private Sub GunaButtonPlanningDeNettoyage_Click(sender As Object, e As EventArgs) Handles GunaButtonPlanningDeNettoyage.Click

        typeDerapport = 0 ' PLANNING DE NETTOYAGE

        GunaTextBoxCodeRapport.Clear()

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelFiltreRecherche.Text = "NOM DU PERSONNEL"
            LabeltypeRapport.Text = "PLANNING DE NETTOYAGE"
        Else
            LabelFiltreRecherche.Text = "PERSONNEL NAME"
            LabeltypeRapport.Text = "PLANNING CLEANING"
        End If

        LabelFiltreRecherche.Visible = True
        LabelFiltreRecherche.BringToFront()

        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail

        PanelApport.Visible = True

    End Sub

    'RECHERCHE DE PLANNING POUR UN EMPLOYE QUELCONQUE
    Private Sub GunaTextBoxRapport_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRapport.TextChanged

        If typeDerapport = 0 Then 'PLANNING DE NETTOYAGE

            If Trim(GunaTextBoxRapport.Text) = "" Then
                GunaDataGridViewRapport.Columns.Clear()
                GunaDataGridViewRapport.Visible = False
            End If

            Dim Query1 As String = ""

            Query1 = "SELECT DISTINCT `NOM_COMPLET_PERSONNEL`, `COD_PERSONNEL` FROM `nettoyage` WHERE NOM_COMPLET_PERSONNEL LIKE '%" & Trim(GunaTextBoxRapport.Text) & "%' ORDER BY NOM_COMPLET_PERSONNEL ASC"

            Dim command1 = New MySqlCommand(Query1, GlobalVariable.connect)

            Dim adapter1 As New MySqlDataAdapter(command1)

            Dim dt As New DataTable()

            adapter1.Fill(dt)

            If dt.Rows.Count > 0 Then
                GunaDataGridViewRapport.Visible = True
                GunaDataGridViewRapport.DataSource = dt
            Else
                GunaDataGridViewRapport.Columns.Clear()
            End If

            If Trim(GunaTextBoxRapport.Text) = "" Then
                GunaDataGridViewRapport.Columns.Clear()
                GunaDataGridViewRapport.Visible = False
            End If

        End If

    End Sub

    Private Sub GunaDataGridViewRapport_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRapport.CellClick

        GunaDataGridViewRapport.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewRapport.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM nettoyage WHERE COD_PERSONNEL=@COD_PERSONNEL ORDER BY COD_PERSONNEL ASC"
            Dim adapter As New MySqlDataAdapter
            Dim dt As New DataTable()
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@COD_PERSONNEL", MySqlDbType.VarChar).Value = Trim(row.Cells("COD_PERSONNEL").Value.ToString)

            adapter.SelectCommand = command
            adapter.Fill(dt)

            If (dt.Rows.Count > 0) Then

                GunaTextBoxCodeRapport.Text = dt.Rows(0)("COD_PERSONNEL")

                GunaTextBoxRapport.Text = dt.Rows(0)("NOM_COMPLET_PERSONNEL")

                GunaDataGridViewRapport.Visible = False

            End If

        End If

    End Sub

    Private Sub GunaButtonImpirmerRapportEconomat_Click(sender As Object, e As EventArgs) Handles GunaButtonImpirmerRapportSEt.Click

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToShortDateString
        Dim DateFin As Date = GunaDateTimePickerFin.Value.ToShortDateString

        Dim Query1 As String = ""

        If Trim(GunaTextBoxCodeRapport.Text).Equals("") Then

            'Query1 = "SELECT DISTINCT `COD_PERSONNEL`, `NOM_COMPLET_PERSONNEL` FROM `nettoyage` WHERE DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND STATUTS = @STATUTS GROUP BY DATE_CREATION ORDER BY NOM_COMPLET_PERSONNEL ASC"
            'Query1 = "SELECT DISTINCT `COD_PERSONNEL`, `NOM_COMPLET_PERSONNEL` FROM `nettoyage` WHERE DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY NOM_COMPLET_PERSONNEL ASC"
            Query1 = "SELECT DISTINCT `COD_PERSONNEL`, `NOM_COMPLET_PERSONNEL` FROM `nettoyage` WHERE DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY NOM_COMPLET_PERSONNEL ASC"

        Else

            'Query1 = "SELECT `COD_PERSONNEL`, `NOM_COMPLET_PERSONNEL` FROM `nettoyage` WHERE DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND STATUTS = @STATUTS AND COD_PERSONNEL =@COD_PERSONNEL GROUP BY DATE_CREATION ORDER BY NOM_COMPLET_PERSONNEL ASC"
            'Query1 = "SELECT `COD_PERSONNEL`, `NOM_COMPLET_PERSONNEL` FROM `nettoyage` WHERE DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND COD_PERSONNEL =@COD_PERSONNEL ORDER BY NOM_COMPLET_PERSONNEL ASC"
            Query1 = "SELECT DISTINCT `COD_PERSONNEL`, `NOM_COMPLET_PERSONNEL` FROM `nettoyage` WHERE DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_CREATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND COD_PERSONNEL =@COD_PERSONNEL ORDER BY NOM_COMPLET_PERSONNEL ASC"

        End If

        ' Dim STATUTS As Integer = 0
        Dim COD_PERSONNEL As String = Trim(GunaTextBoxCodeRapport.Text)

        Dim command1 = New MySqlCommand(Query1, GlobalVariable.connect)
        'command1.Parameters.Add("@STATUTS", MySqlDbType.Int64).Value = STATUTS
        command1.Parameters.Add("@COD_PERSONNEL", MySqlDbType.VarChar).Value = COD_PERSONNEL

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim dt As New DataTable()

        adapter1.Fill(dt)

        If dt.Rows.Count > 0 Then
            Impression.planningDeNettoyage(dt, typeDerapport, DateDebut, DateFin)
        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Planning du " & GlobalVariable.DateDeTravail & " non disponible!!", "PLANNING DE NETTOYAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Planning of " & GlobalVariable.DateDeTravail & " not avalaible!!", "CLEANING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        GunaTextBoxRapport.Clear()

    End Sub

    Private Sub GunaButtonRapportNettoyage_Click(sender As Object, e As EventArgs) Handles GunaButtonRapportNettoyage.Click

        typeDerapport = 1 ' RAPPORTS DE NETTOYAGE

        GunaTextBoxCodeRapport.Clear()

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelFiltreRecherche.Text = "NOM DU PERSONNEL"
            LabeltypeRapport.Text = "RAPPORT DE PRODUCTIVITE"
        Else
            LabelFiltreRecherche.Text = "PERSONNEL NAME"
            LabeltypeRapport.Text = "PRODUCTIVITY REPORT"
        End If

        LabelFiltreRecherche.Visible = True
        LabelFiltreRecherche.BringToFront()

        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail

        PanelApport.Visible = True

    End Sub

    Private Sub GunaButtonPrintP1_Click(sender As Object, e As EventArgs) Handles GunaButtonPrintP1.Click

        If GunaDataGridViewP1.Rows.Count > 0 Then
            Impression.planningDeNettoyagePerso(GunaDataGridViewP1, GunaTextBoxPersonnelCode1.Text, GunaTextBoxP1.Text)
        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune chambre attribuée pour nettoyage", "PLANNING DE NETTOYAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No room assigned for cleaning", "CLEANING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub GunaButtonPrintP2_Click(sender As Object, e As EventArgs) Handles GunaButtonPrintP2.Click

        If GunaDataGridViewP2.Rows.Count > 0 Then
            Impression.planningDeNettoyagePerso(GunaDataGridViewP2, GunaTextBoxPersonnelCode2.Text, GunaTextBoxP2.Text)
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune chambre attribuée pour nettoyage", "PLANNING DE NETTOYAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No room assigned for cleaning", "CLEANING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub GunaButtonPrintP3_Click(sender As Object, e As EventArgs) Handles GunaButtonPrintP3.Click
        If GunaDataGridViewP3.Rows.Count > 0 Then
            Impression.planningDeNettoyagePerso(GunaDataGridViewP3, GunaTextBoxPersonnelCode3.Text, GunaTextBoxP3.Text)
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune chambre attribuée pour nettoyage", "PLANNING DE NETTOYAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No room assigned for cleaning", "CLEANING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub GunaButtonPrintP4_Click(sender As Object, e As EventArgs) Handles GunaButtonPrintP4.Click
        If GunaDataGridViewP4.Rows.Count > 0 Then
            Impression.planningDeNettoyagePerso(GunaDataGridViewP4, GunaTextBoxPersonnelCode4.Text, GunaTextBoxP4.Text)
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune chambre attribuée pour nettoyage", "PLANNING DE NETTOYAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No room assigned for cleaning", "CLEANING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub GunaButtonPrintP5_Click(sender As Object, e As EventArgs) Handles GunaButtonPrintP5.Click
        If GunaDataGridViewP5.Rows.Count > 0 Then
            Impression.planningDeNettoyagePerso(GunaDataGridViewP5, GunaTextBoxPersonnelCode5.Text, GunaTextBoxP5.Text)
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune chambre attribuée pour nettoyage", "PLANNING DE NETTOYAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No room assigned for cleaning", "CLEANING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub GunaButtonPrintP6_Click(sender As Object, e As EventArgs) Handles GunaButtonPrintP6.Click
        If GunaDataGridViewP6.Rows.Count > 0 Then
            Impression.planningDeNettoyagePerso(GunaDataGridViewP6, GunaTextBoxPersonnelCode6.Text, GunaTextBoxP6.Text)
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune chambre attribuée pour nettoyage", "PLANNING DE NETTOYAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No room assigned for cleaning", "CLEANING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    'IMPRESSION DES TOUS LES PLANNINGS SIMULTANNEMENT
    Private Sub GunaButtonPrintAll_Click(sender As Object, e As EventArgs) Handles GunaButtonPrintAll.Click

        If GunaDataGridViewP1.Rows.Count > 0 Then

            deplacemntDeLigne(GunaDataGridViewP1, GunaDataGridViewAll)

            Impression.planningDeNettoyagePerso(GunaDataGridViewAll, GunaTextBoxPersonnelCode1.Text, GunaTextBoxP1.Text)
        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune chambre attribuée pour nettoyage", "PLANNING DE NETTOYAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No room assigned for cleaning", "CLEANING", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If

    End Sub

    Private Sub GunaButtonEtatDesChambres_Click(sender As Object, e As EventArgs) Handles GunaButtonEtatDesChambres.Click
        TabPageNettoyage.Controls.Clear()
        StatistiquesDeNettoyage()
        StatusDesChambres()
    End Sub

    'CUISINE
    Private Sub ToolStripMenuItem57_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem57.Click

        Me.Cursor = Cursors.WaitCursor

        MainWindowCuisineForm.Show()

        ArticleForm.Show()

        ArticleForm.Location = New Point(90, 110)
        ArticleForm.TopMost = True

        Me.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TimerToRefreshClock_Tick(sender As Object, e As EventArgs) Handles TimerToRefreshClock.Tick

        'NOTIFCATION

        Dim notifications As DataTable

        If Not GlobalVariable.ConnectedUser Is Nothing Then

            If GlobalVariable.ConnectedUser.Rows.Count > 0 Then

                notifications = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

                If notifications.Rows.Count > 0 Then
                    GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
                End If

            Else
                GunaLabelNotification.Text = "(" & 0 & ")"
            End If

        Else
            GunaLabelNotification.Text = "(" & 0 & ")"
        End If

    End Sub

    Private Sub GunaDataGridViewP0_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles GunaDataGridViewP0.RowsRemoved
        GunaTextBoxNbreChambreTotalANettoyer.Text = GunaDataGridViewP0.Rows.Count
    End Sub

    Private Sub GunaDataGridViewP0_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles GunaDataGridViewP0.RowsAdded
        GunaTextBoxNbreChambreTotalANettoyer.Text = GunaDataGridViewP0.Rows.Count
    End Sub

    Private Sub ToolStripMenuItem116_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem116.Click
        BonApprovisionnementForm.Show()
        BonApprovisionnementForm.TopMost = True
        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable

        '--------------------------------------------------------------------------------
        Dim getArticleQuery As String = "SELECT * FROM magasin WHERE LIBELLE_MAGASIN LIKE '%BUANDERIE%' OR `LIBELLE_MAGASIN` LIKE '%LINGERIE%'"

        '--------------------------------------------------------------------------------

        Dim str As String = ""

        BonApprovisionnementForm.GunaComboBoxTypeBordereau.SelectedIndex = 0

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            BonApprovisionnementForm.GunaComboBoxMagasinReception.DataSource = table
            BonApprovisionnementForm.GunaComboBoxMagasinReception.ValueMember = "CODE_MAGASIN"
            BonApprovisionnementForm.GunaComboBoxMagasinReception.DisplayMember = "LIBELLE_MAGASIN"

            BonApprovisionnementForm.GunaComboBoxMagasinReception.SelectedIndex = 0

        Else

        End If


    End Sub

    Private Sub GunaButtonBlanchisserie_Click(sender As Object, e As EventArgs) Handles GunaButtonBlanchisserie.Click

        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.typeDeClientAFacturer = "en chambre"
        FacturationForm.LibelleFacturation.Text = "FACTURATION EN CHAMBRE"

        FacturationForm.GunaTextBoxSoldeClient.Visible = False
        FacturationForm.Label6.Visible = False
        FacturationForm.GunaTextBoxTVARecap.Visible = False
        FacturationForm.Label7.Visible = False

        FacturationForm.Show()
        FacturationForm.TopMost = True
        GlobalVariable.ArticleFamily = "BLANCHISSERIE"
        FacturationForm.GunaCheckBoxChangeSecteur.Visible = False

        FacturationForm.GunaButtonSaveFacturation.Text = "Enregistrer"

    End Sub

    Private Sub GunaRadioButtonChambre_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonChambre.CheckedChanged

        If GunaRadioButtonChambre.Checked Then

            TabPageNettoyage.Controls.Clear()

            GlobalVariable.typeChambreOuSalle = "chambre"

            StatistiquesDeNettoyage()
            StatusDesChambres()

            DataGridViewRoomListe.Columns.Clear()
            GunaDataGridViewEtatsDesChambres.Columns.Clear()
            If GlobalVariable.actualLanguageValue = 1 Then
                LabelLibelleActif.Text = "STATUTS DES CHAMBRES"
            Else
                LabelLibelleActif.Text = "ROOMS STATUS"
            End If

            GunaDataGridViewP0.Rows.Clear()
            NettoyageRoomLIst()

        End If

    End Sub

    Private Sub GunaRadioButtonSalle_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonSalle.CheckedChanged

        If GunaRadioButtonSalle.Checked Then

            TabPageNettoyage.Controls.Clear()

            GlobalVariable.typeChambreOuSalle = "salle"

            StatistiquesDeNettoyage()
            StatusDesChambres()

            DataGridViewRoomListe.Columns.Clear()
            GunaDataGridViewEtatsDesChambres.Columns.Clear()

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelLibelleActif.Text = "STATUTS DES SALLES"
            Else
                LabelLibelleActif.Text = "HALLS STATUS"
            End If

            GunaDataGridViewP0.Rows.Clear()
            NettoyageRoomLIst()

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
        GlobalVariable.changerMotDePasseDepuis = "etage"

        ChangePasswordForm.Show()
        ChangePasswordForm.TopMost = True
    End Sub

    Private Sub PlanningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanningToolStripMenuItem.Click

        PlanningHebdomadaireDuPersonnelForm.Show()
        PlanningHebdomadaireDuPersonnelForm.TopMost = True

    End Sub


    '--------------------------------------------------------------------------

End Class