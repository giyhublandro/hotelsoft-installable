Imports MySql.Data.MySqlClient

Public Class RoomForm

    'Dim connect As New DataBaseManipulation()

    Private Sub RoomForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.room(GlobalVariable.actualLanguageValue)

        GunaComboBoxRegistre.SelectedIndex = 0
        GunaComboBoxNature.SelectedIndex = 0
        GunaGroupBoxTrouvees.LineColor = Color.LightSteelBlue

        'DataGridViewRoomListe.Columns().Add("STATUT", "STATUT")
        'DataGridViewRoomListe.Columns().Add("CODE CHAMBRE", "CODE CHAMBRE")
        'DataGridViewRoomListe.Columns().Add("'CODE TYPE CHAMBRE", "'CODE TYPE CHAMBRE")
        'DataGridViewRoomListe.Columns().Add("ETAT CHAMBRE", "ETAT CHAMBRE")
        'DataGridViewRoomListe.Columns().Add("PRIX", "PRIX")
        'DataGridViewRoomListe.Columns().Add("LIBELLE", "LIBELLE")
        'DataGridViewRoomListe.Columns().Add("LOCALISATION", "LOCALISATION")
        'DataGridViewRoomListe.Columns().Add("DATE CREATION", "DATE CREATION")
        'DataGridViewRoomListe.Columns().Add("ID CHAMBRE", "ID CHAMBRE")

        'Si le frmulaire st chargé venant du front desk

        If Not GlobalVariable.chambreOuSalleFromFrontDesk = "" Then

            'We hide the tab of salle de fete of the left tab
            TabControlRoomForm.TabPages.Remove(TabPageHorService)
            TabControlRoomForm.TabPages.Remove(TabPageHistorique)
            TabControlRoomForm.TabPages.Remove(TabPageObjets)
            TabControlRoomForm.TabPages.Remove(TabPageRapports)
            TabControlRoomForm.TabPages.Remove(TabPageNetoyage)

            'On affiche directement les chambres ainsi on a plus à cliquer sur le bouton afficher

            If MainWindow.GunaRadioButtonChambre.Checked Then
                GunaRadioButtonChambre.Visible = True
                GunaRadioButtonSalle.Visible = False
            Else
                GunaRadioButtonChambre.Visible = False
                GunaRadioButtonSalle.Visible = True
                GunaRadioButtonSalle.Checked = True
            End If

            If GunaRadioButtonChambre.Checked Then
                GlobalVariable.typeChambreOuSalle = "chambre"
            ElseIf GunaRadioButtonSalle.Checked Then
                GlobalVariable.typeChambreOuSalle = "salle"
            End If

            roomList()

        End If

        libelleChamp()

        'We select the second tab
        TabControlRoomForm.SelectedIndex = 1

        'Completion du type de chambre chambre
        'AutoCompleteChambre()

        'roomList()

        FillingOfTypeChambreOuSalleComboBox()

        GunaComboBoxTypeDeChambreOuSalle.SelectedIndex = -1

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelGestCompteGeneraux.Text = "LISTE DES CHAMBRES"
        Else
            GunaLabelGestCompteGeneraux.Text = "LIST OF ROOMS"
        End If

        GunaComboBoxEtatChambre.Items.Clear()

        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.occupee_sale)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.occupee_propre)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.libre_sale)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.libre_propre)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.reserver)
        GunaComboBoxEtatChambre.Items.Add(GlobalVariable.hors_service)

        DataGridViewRoomListe.Columns.Clear()

        AffichageDeTitre()

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

        'Chargement des chambres partant du front desk
        If Not GlobalVariable.chambreOuSalleFromFrontDesk = "" Then

            Me.TopMost() = True

            'Si code de chambre n'existe pas alors on efface toute les informations le concernant
            If Trim(MainWindow.GunaTextBoxNumeroChambre.Text).Equals("") Then

                If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then
                    MainWindow.GunaTextBoxLibelleChambre.Clear()
                Else
                    RestaurantBookingForm.GunaTextBoxLibelleChambre.Clear()
                End If

                DataGridViewRoomListe.Visible = True

            End If

            DataGridViewRoomListe.Visible = True

            'Dim query As String = "SELECT CODE_CHAMBRE AS 'CODE CHAMBRE', ETAT_CHAMBRE_NOTE As 'ETAT CHAMBRE',LIBELLE_CHAMBRE AS 'LIBELLE', PRIX, CODE_TYPE_CHAMBRE As 'CODE TYPE CHAMBRE',LOCALISATION, DATE_CREATION AS 'DATE CREATION',GUEST_DAI As'COMMENTAIRE' From chambre WHERE ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND TYPE=@TYPE AND ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE OR ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND TYPE=@TYPE AND ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE2 ORDER BY CODE_CHAMBRE ASC"
            Dim query As String = "SELECT CODE_CHAMBRE AS 'CODE CHAMBRE', ETAT_CHAMBRE_NOTE As 'ETAT CHAMBRE',LIBELLE_CHAMBRE AS 'LIBELLE', PRIX, CODE_TYPE_CHAMBRE As 'CODE TYPE CHAMBRE',LOCALISATION, DATE_CREATION AS 'DATE CREATION', GUEST_DAI AS 'COMMENTAIRE' FROM chambre WHERE ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND TYPE=@TYPE_ AND ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE ORDER BY CODE_CHAMBRE ASC"

            If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 1 Then
                query = "SELECT CODE_CHAMBRE AS 'CODE CHAMBRE', ETAT_CHAMBRE_NOTE As 'ETAT CHAMBRE',LIBELLE_CHAMBRE AS 'LIBELLE', PRIX, CODE_TYPE_CHAMBRE As 'CODE TYPE CHAMBRE',LOCALISATION, DATE_CREATION AS 'DATE CREATION', GUEST_DAI AS 'COMMENTAIRE' FROM chambre WHERE ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND TYPE=@TYPE_  ORDER BY CODE_CHAMBRE ASC"
            End If

            Dim command1 As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

            command1.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = GlobalVariable.chambreOuSalleFromFrontDesk
            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            command1.Parameters.Add("@TYPE_", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
            command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre
            command1.Parameters.Add("@ETAT_CHAMBRE_NOTE2", MySqlDbType.VarChar).Value = GlobalVariable.libre_sale

            Dim adapter1 As New MySqlDataAdapter(command1)
            Dim table As New DataTable()

            adapter1.Fill(table)

            If (table.Rows.Count > 0) Then

                DataGridViewRoomListe.Columns.Clear()

                'DataGridViewRoomListe.Visible = True
                DataGridViewRoomListe.DataSource = table

                DataGridViewRoomListe.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
                DataGridViewRoomListe.DefaultCellStyle.SelectionForeColor = Color.White
                DataGridViewRoomListe.Columns("PRIX").DefaultCellStyle.Format = "#,##0"
                DataGridViewRoomListe.Columns("PRIX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Else

                DataGridViewRoomListe.Columns.Clear()
                DataGridViewRoomListe.Visible = True
            End If

            If MainWindow.GunaTextBoxNumeroChambre.Text = "" Then
                'DataGridView1.Visible = False
            End If

            'connect.closeConnection()

        Else

            'AFFICHAGE DES CHAMBRES DEPUIS LE MENUS DE PARAMETTRAGE PAR EXAMPLE

            Try

                Dim Query As String = "SELECT CODE_CHAMBRE AS 'CODE CHAMBRE', ETAT_CHAMBRE_NOTE As 'ETAT CHAMBRE',LIBELLE_CHAMBRE AS 'LIBELLE',PRIX,GUEST_DAI AS 'COMMENTAIRE',CODE_TYPE_CHAMBRE As 'CODE TYPE CHAMBRE', LOCALISATION, DATE_CREATION AS 'DATE CREATION' From chambre WHERE CODE_AGENCE = @CODE_AGENCE AND TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

                Dim command = New MySqlCommand(Query, GlobalVariable.connect)
                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
                command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                'command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                adapter.SelectCommand = command
                adapter.Fill(dbDataSet)
                bSource.DataSource = dbDataSet
                DataGridViewRoomListe.DataSource = bSource
                adapter.Update(dbDataSet)

                DataGridViewRoomListe.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
                DataGridViewRoomListe.DefaultCellStyle.SelectionForeColor = Color.White
                DataGridViewRoomListe.Columns("PRIX").DefaultCellStyle.Format = "#,##0"
                DataGridViewRoomListe.Columns("PRIX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridViewRoomListe.Columns("CODE TYPE CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridViewRoomListe.Columns("CODE CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridViewRoomListe.Columns("PRIX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'DataGridViewRoomListe.Columns.Add("STATUT", "STATUT")

                For i = 0 To DataGridViewRoomListe.Rows.Count - 1

                    If i Mod 2 = 0 Then
                        DataGridViewRoomListe.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    Else
                        DataGridViewRoomListe.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If

                Next

                'connect.closeConnection()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click

        GlobalVariable.chambreOuSalleFromFrontDesk = ""

        Me.Close()

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
        Dim CODE_TYPE_CHAMBRE = ""
        Dim OLD_CODE_CHAMBRE = GunaTextBoxOldCodeChambre.Text

        If GunaComboBoxTypeDeChambreOuSalle.SelectedIndex >= 0 Then
            CODE_TYPE_CHAMBRE = GunaComboBoxTypeDeChambreOuSalle.SelectedValue.ToString()
        End If

        Dim LIBELLE_CHAMBRE = GunaTextBoxLibelle.Text
        Dim LIBELLE_CHAMBRE_TYPE_DE_CHAMBRE = GunaTextBoxLibelleType.Text
        Dim PRIX = GunaTextBoxPrix.Text

        Dim FICTIF As Integer = 0

        If GunaCheckBoxFictif.Checked Then
            FICTIF = 1
        End If

        Dim LOCK_NO = GunaTextBoxLock.Text
        Dim ETAT_CHAMBRE = GunaComboBoxEtatChambre.SelectedIndex
        Dim ETAT_CHAMBRE_NOTE = GunaComboBoxEtatChambre.SelectedItem

        Dim CODE_MOTIF As String = ""
        Dim MOTIF As String = ""

        If ETAT_CHAMBRE_NOTE = GlobalVariable.hors_service Then
            CODE_MOTIF = Functions.GeneratingRandomCode("motif_hors_service", "")

            If GunaComboBoxMotifHS.SelectedIndex >= 0 Then
                MOTIF = GunaComboBoxMotifHS.SelectedItem
            End If

        Else
            ETAT_CHAMBRE = 0
        End If

        Dim LOCALISATION = GunaTextBoxLocalisation.Text
        Dim NUM_COMPTE = GunaTextBoxCompteNumero.Text
        Dim GUEST_DAI = GunaTextBoxGuest.Text
        Dim CODE_CATEGORY_CHAMBRE = GunaComboBoxMotifHS.SelectedItem 'permet de gérer le motif si la chambre est dans un états hors service

        If CODE_CATEGORY_CHAMBRE = "" Then
            CODE_CATEGORY_CHAMBRE = "Aucun problème"
        End If

        Dim DATE_CREATION = GlobalVariable.DateDeTravail.ToShortDateString()
        'Dim CODE_AGENCE = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        Dim CODE_AGENCE = GlobalVariable.codeAgence
        Dim TYPE As String = ""
        Dim TYPE_ As String = ""

        If GlobalVariable.typeChambreOuSalle = "salle" Then
            TYPE = "salle"
            If GlobalVariable.actualLanguageValue = 1 Then
                TYPE_ = "Salle"
            Else
                TYPE_ = "Hall"
            End If
        ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then
            TYPE = "chambre"
            If GlobalVariable.actualLanguageValue = 1 Then
                TYPE_ = "Chambre"
            Else
                TYPE_ = "Room"
            End If
        End If

        Dim room As New Room
        Dim service As New ServicesEtage

        Dim LIBELLE As String = GunaTextBoxLibelleType.Text
        '---------------- MOTIF HS ------------------------

        'company verifyfields function
        If (verifyFields()) Then
            'check if the company alreday exist

            If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then
                'we update the value of the room

                If room.UpdateRoom(CODE_CHAMBRE, CODE_TYPE_CHAMBRE, CODE_CATEGORY_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE, LOCALISATION, NUM_COMPTE, PRIX, FICTIF, LOCK_NO, GUEST_DAI, CODE_AGENCE, OLD_CODE_CHAMBRE) Then

                    'Functions.ClearTextBox(Me)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Modification enregistrée avec succès", "Création " & TYPE_, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Update successful", TYPE_ & " Creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    'Clearing of fields

                    GunaCheckBoxFictif.Checked = False

                    TabControlRoomForm.SelectedIndex = 1

                End If

                If ETAT_CHAMBRE_NOTE = GlobalVariable.hors_service Then

                    CODE_MOTIF = GunaTextBoxCodeMotif.Text

                    'On ne met pas ajour mais on crée une nouvelle entrée ce qui aidera dans les statistiques
                    service.insertMotif(CODE_MOTIF, CODE_CHAMBRE, MOTIF, CODE_AGENCE)

                    'If service.updateMotif(CODE_MOTIF, CODE_CHAMBRE, MOTIF, CODE_AGENCE) Then

                    'End If

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
                            MessageBox.Show("Nouvelle " & TYPE & " enregistrée avec succès", "Création de " & TYPE_, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("New " & TYPE & " successfully saved", TYPE_ & " Creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'Clearing of fields
                        'Functions.ClearTextBox(Me)
                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Un problème lors de la création !!", "Création de " & TYPE_, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            MessageBox.Show("A problem during creation !!", TYPE_ & " Creation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                Else
                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Cette " & TYPE_ & " existe déjà, Essayer à nouveau", TYPE_ & " Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("This " & TYPE_ & " already exist, Try again", TYPE_ & " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            End If

        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création de " & TYPE_, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please fill all the fields !!", TYPE_ & " Creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        'We refresh the room list
        'roomList()

        'On actiive le formulaire pour rafraishir le panneau des images cde chambre
        'Dim mainWindow As New MainWindow()

        'MainWindow.MainWindowManualActivation() 'Icon des chambres au niveau du dashboard

        GunaTextBoxcCode.Clear()
        GunaTextBoxLock.Clear()
        GunaTextBoxGuest.Clear()
        GunaTextBoxLibelle.Clear()

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

        GlobalVariable.chambreOuSalleFromFrontDesk = ""

        GunaComboBoxMotifHS.Visible = False
        GunaComboBoxMotifHS.Visible = False
        GunaLabelMotif.Visible = False

    End Sub

    'Taking data from datagridView and insert into textBox for update
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewRoomListe.CellDoubleClick

        If e.RowIndex >= 0 Then

            'We want to upload the room coming from the front desk based on the room type
            If Not GlobalVariable.chambreOuSalleFromFrontDesk = "" Then

                Dim row As DataGridViewRow

                row = Me.DataGridViewRoomListe.Rows(e.RowIndex)

                'We select a room by doucliking when coming from frontdesk

                'We make sure it is possible to Choose a room if a room type is choosen first
                'We set back the diasbled values after checkin or save
                GlobalVariable.chambreOuSalleFromFrontDesk = row.Cells("CODE CHAMBRE").Value.ToString

                If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then
                    MainWindow.MainWindowManualActivation()
                Else
                    RestaurantBookingForm.MainWindowManualActivation()
                End If

                DataGridViewRoomListe.Columns.Clear()

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

                '-----------------------

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
                If Trim(chambre.Rows(0)("ETAT_CHAMBRE_NOTE")) = GlobalVariable.hors_service Then

                    GunaComboBoxMotifHS.Visible = True

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

    'AutoLoad the name of the room type when we leave the field changes
    Private Sub GunaTextBoxTypeChambre_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxTypeChambre.Leave

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

        If Trim(GunaComboBoxEtatChambre.SelectedItem) = GlobalVariable.hors_service Or Trim(GunaComboBoxEtatChambre.SelectedItem) = "Out of service" Then
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

        If DataGridViewRoomListe.Rows.Count > 0 Then

            Dim dialog As DialogResult
            Dim type As String = ""
            If GlobalVariable.actualLanguageValue = 1 Then

                If GlobalVariable.typeChambreOuSalle = "chambre" Then
                    type = "Chambre"
                Else
                    type = "Salle"
                End If

            Else

                If GlobalVariable.typeChambreOuSalle = "chambre" Then
                    type = "Room"
                Else
                    type = "Hall"
                End If

            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Supperimer la " & Type & " : " & DataGridViewRoomListe.CurrentRow.Cells("CODE CHAMBRE").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                dialog = MessageBox.Show("Do you really want to delete the " & type & " : " & DataGridViewRoomListe.CurrentRow.Cells("CODE CHAMBRE").Value.ToString & "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
                    MessageBox.Show("You successfully deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If


        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No line to delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub GunaButtonImprimer_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimer.Click
        PrintPreviewDialog1.WindowState = FormWindowState.Normal
        PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
        PrintPreviewDialog1.ClientSize = New Size(600, 600)

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.DataGridViewRoomListe.Width, Me.DataGridViewRoomListe.Height)
        DataGridViewRoomListe.DrawToBitmap(bm, New Rectangle(0, 0, Me.DataGridViewRoomListe.Width, Me.DataGridViewRoomListe.Height))
        e.Graphics.DrawImage(bm, 0, 0)

        Dim x As Integer = 170
        Dim y As Integer = 360
        Dim xwidth As Integer = 190
        Dim yheight As Integer = 20
        Dim cellWidth As Integer = 0
        Dim cellHeight As Integer = 370

        Dim font As New Font(FontFamily.GenericSerif, 12, FontStyle.Regular)
        Dim rect As New Rectangle(x, 10, xwidth, yheight)

        Dim Strings As New StringFormat

        Strings.Alignment = StringAlignment.Center
        Strings.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
        'e.Graphics.DrawString()


    End Sub

    'AFFICHAGE DE LA LISTE DES CHAMBRES
    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLaListeDesChambres.Click

        DataGridViewRoomListe.Columns.Clear()

        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
        ElseIf GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        Else
            GlobalVariable.typeChambreOuSalle = "chambre"
        End If

        roomList()

    End Sub

    Private Sub TabControlRoomForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlRoomForm.SelectedIndexChanged

        If TabControlRoomForm.SelectedIndex = 7 Then
            NettoyageRoomLIst()
        Else
            GunaDataGridViewP0.Columns.Clear()
        End If

        If TabControlRoomForm.SelectedIndex = 6 Then
            'StatusDesChambres()
        Else
            'TabPageEtatsDesChambres.Controls.Clear()
        End If

        AffichageDeTitre()

        DataGridViewRoomListe.Columns.Clear()
        GunaDataGridViewHorsSerice.Columns.Clear()
        GunaDataGridViewHistoriqueDesChambres.Columns.Clear()
        GunaDataGridViewRegistreObjets.Columns.Clear()

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

        'Inserting data from database into datagridView
        Dim Query1 As String = "SELECT chambre.CODE_CHAMBRE AS 'CODE', GUEST_DAI As 'COMMENTAIRE', ETAT_CHAMBRE_NOTE As 'ETAT' From chambre WHERE ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE OR ETAT_CHAMBRE_NOTE = @ETAT_CHAMBRE_NOTE1 AND TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

        Dim command1 = New MySqlCommand(Query1, GlobalVariable.connect)
        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.occupee_sale
        command1.Parameters.Add("@ETAT_CHAMBRE_NOTE1", MySqlDbType.VarChar).Value = GlobalVariable.libre_sale

        Dim adapter As New MySqlDataAdapter(command1)
        Dim table As New DataTable()

        adapter.Fill(table)
        GunaDataGridViewP0.Columns.Add("CODE", "CODE")
        GunaDataGridViewP0.Columns.Add("COMMENATIRE", "COMMENATIRE")
        GunaDataGridViewP0.Columns.Add("ETAT", "ETAT")

        If table.Rows.Count > 0 Then

            'GunaDataGridViewP0.DataSource = table
            For i = 0 To table.Rows.Count - 1
                GunaDataGridViewP0.Rows.Add(table.Rows(i)("CODE"), table.Rows(i)("COMMENTAIRE"), table.Rows(i)("ETAT"))
            Next

        Else
            GunaDataGridViewP0.Columns.Clear()
        End If

    End Sub

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
            If Trim(chambre.Rows(0)("ETAT_CHAMBRE_NOTE")) = GlobalVariable.hors_service Then

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



        If GlobalVariable.actualLanguageValue = 1 Then
            If GunaComboBoxNature.SelectedIndex = 0 Then
                GunaGroupBoxTrouvees.Text = "ANNONCE D'OBJETS TROUVES"
                GunaLabel17.Text = "Endroit où l'objet a été retrouvé"
                GunaLabel16.Text = "Date de retrouvail"
                GunaGroupBoxTrouvees.LineColor = Color.LightSteelBlue
            Else
                GunaGroupBoxTrouvees.Text = "ANNONCE D'OBJETS PERDUS"
                GunaLabel17.Text = "Endroit où l'objet a été perdu"
                GunaLabel16.Text = "Date de perte"
                GunaGroupBoxTrouvees.LineColor = Color.DarkKhaki
            End If
        Else
            If GunaComboBoxNature.SelectedIndex = 0 Then
                GunaGroupBoxTrouvees.Text = "ANNONCE D'OBJETS TROUVES"
                GunaLabel17.Text = "Endroit où l'objet a été retrouvé"
                GunaLabel16.Text = "Date de retrouvail"
                GunaGroupBoxTrouvees.LineColor = Color.LightSteelBlue
            Else
                GunaGroupBoxTrouvees.Text = "ANNONCE D'OBJETS PERDUS"
                GunaLabel17.Text = "Endroit où l'objet a été perdu"
                GunaLabel16.Text = "Date de perte"
                GunaGroupBoxTrouvees.LineColor = Color.DarkKhaki
            End If
        End If

    End Sub

    Private Sub GunaComboBoxRegistre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxRegistre.SelectedIndexChanged

        GunaDataGridViewRegistreObjets.Columns.Clear()



        If GlobalVariable.actualLanguageValue = 1 Then
            If GunaComboBoxRegistre.SelectedIndex = 0 Then
                GunaGroupBoxRegistre.Text = "REGISTRE D'OBJETS TROUVES"
                GunaGroupBoxRegistre.LineColor = Color.LightSteelBlue
            Else
                GunaGroupBoxRegistre.Text = "REGISTRE D'OBJETS PERDUS"
                GunaGroupBoxRegistre.LineColor = Color.DarkKhaki
            End If
        Else
            If GunaComboBoxRegistre.SelectedIndex = 0 Then
                GunaGroupBoxRegistre.Text = "REGISTRE D'OBJETS TROUVES"
                GunaGroupBoxRegistre.LineColor = Color.LightSteelBlue
            Else
                GunaGroupBoxRegistre.Text = "REGISTRE D'OBJETS PERDUS"
                GunaGroupBoxRegistre.LineColor = Color.DarkKhaki
            End If
        End If

    End Sub

    Private Sub GunaCheckBoxRecherche_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxRecherche.Click

        If GunaCheckBoxRecherche.Checked Then

        Else

        End If

    End Sub

    'Enregistrment d'annonce
    Private Sub GunaButtonSaveObjets_Click(sender As Object, e As EventArgs) Handles GunaButtonSaveObjets.Click

        Dim CODE_OBJET As String = Functions.GeneratingRandomCode("objet__perdu_trouve", "")
        Dim TITRE As String = GunaTextBoxTitre.Text
        Dim LIEU As String = GunaTextBoxLieu.Text
        Dim DATE_ANNONCE As Date = GunaDateTimePickerDateAnnonce.Value.ToLongDateString
        Dim CATEGORIE As String = GunaTextBoxCategorie.Text
        Dim SOUS_CATEGORIE As String = GunaTextBoxSousCategorie.Text
        Dim FABRICANT As String = GunaTextBoxFabricant.Text
        Dim MODEL As String = GunaTextBoxModel.Text
        Dim NUMERO_DE_SERIE As String = GunaTextBoxNumSerie.Text
        Dim DESCRIPTION As String = GunaTextBoxDescription.Text
        Dim COULEUR As String = GunaTextBoxCouleur.Text
        Dim NATURE As String = GunaComboBoxNature.SelectedItem.ToString
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim service As New ServicesEtage

        If GunaButtonSaveObjets.Text = "Sauvegarder" Then

            CODE_OBJET = GunaTextBoxCodeObjet.Text

            If service.updateObjet(CODE_OBJET, TITRE, LIEU, DATE_ANNONCE, CATEGORIE, SOUS_CATEGORIE, FABRICANT, MODEL, NUMERO_DE_SERIE, DESCRIPTION, COULEUR, NATURE, CODE_AGENCE) Then
                MessageBox.Show("Vous avez mis à jours avec succès unobjet", "Objet trouvés/perdus", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Problème lors de mise à jours de l'objet", "Objet trouvés/perdus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            GunaButtonSaveObjets.Text = "Enregistrer"

        Else

            If service.insertObjet(CODE_OBJET, TITRE, LIEU, DATE_ANNONCE, CATEGORIE, SOUS_CATEGORIE, FABRICANT, MODEL, NUMERO_DE_SERIE, DESCRIPTION, COULEUR, NATURE, CODE_AGENCE) Then
                MessageBox.Show("Vous avez ajouté avec succès un nouvel objet", "Objet trouvés/perdus", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Problème lors de l'ajout de l'objet", "Objet trouvés/perdus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        GunaButtonSaveObjets.Text = "Sauvegarder"

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewRegistreObjets.Rows(e.RowIndex)

            Dim objet As DataTable = Functions.getElementByCode(row.Cells("CODE OBJET").Value.ToString, "objet__perdu_trouve", "CODE_OBJET")

            If objet.Rows.Count > 0 Then

                GunaTextBoxCodeObjet.Text = objet.Rows(0)("CODE_OBJET")
                GunaTextBoxTitre.Text = objet.Rows(0)("TITRE")
                GunaTextBoxLieu.Text = objet.Rows(0)("LIEU")
                GunaDateTimePickerDateAnnonce.Value = objet.Rows(0)("DATE_ANNONCE")
                GunaTextBoxCategorie.Text = objet.Rows(0)("CATEGORIE")
                GunaTextBoxSousCategorie.Text = objet.Rows(0)("SOUS_CATEGORIE")
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

        'Dim query As String = "SELECT NOM_PERSONNEL,PRENOM_PERSONNEL From personnel INNER JOIN type_personnel WHERE personnel.CODE_TYPE_PERSONNEL = type_personnel.CODE_TYPE_PERSONNEL AND LIBELLE_TYPE_PERSONNEL=@LIBELLE_TYPE_PERSONNEL AND NOM_PERSONNEL Like '%" & GunaTextPersonnel1.Text & "%' OR PRENOM_PERSONNEL Like '%" & GunaTextPersonnel1.Text & "%' AND CODE_AGENCE=@CODE_AGENCE"
        Dim query As String = "SELECT NOM_PERSONNEL,PRENOM_PERSONNEL From personnel INNER JOIN type_personnel WHERE personnel.CODE_TYPE_PERSONNEL = type_personnel.CODE_TYPE_PERSONNEL AND LIBELLE_TYPE_PERSONNEL=@LIBELLE_TYPE_PERSONNEL AND NOM_PERSONNEL Like '%" & GunaTextPersonnel.Text & "%'"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@LIBELLE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = "FEMME DE CHAMBRE"

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
        GunaTextBox7.Text = GunaTextPersonnel.Text
        GunaTextBox8.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP3_Click(sender As Object, e As EventArgs) Handles GunaButtonP3.Click
        GunaTextBox11.Text = GunaTextPersonnel.Text
        GunaTextBox12.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP4_Click(sender As Object, e As EventArgs) Handles GunaButtonP4.Click
        GunaTextBox9.Text = GunaTextPersonnel.Text
        GunaTextBox10.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP5_Click(sender As Object, e As EventArgs) Handles GunaButtonP5.Click
        GunaTextBox13.Text = GunaTextPersonnel.Text
        GunaTextBox14.Text = GunaTextBoxCodePersonnel.Text
        GunaTextPersonnel.Clear()
    End Sub

    Private Sub GunaButtonP6_Click(sender As Object, e As EventArgs) Handles GunaButtonP6.Click
        GunaTextBox15.Text = GunaTextPersonnel.Text
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

    Public Sub StatusDesChambres()

        Dim roomList As New Room()
        Dim rooms As DataTable = roomList.roomsOnly()

        Dim xValue As Integer = 0
        Dim yValue As Integer = 0

        If rooms.Rows.Count > 0 Then

            For i As Integer = 0 To rooms.Rows.Count - 1 Step 1

                Dim nomCLient As String = ""
                Dim emailCLient As String = ""

                Dim toolTip As New ToolTip()

                Dim buttonColor As Color
                Dim textColor As Color = Color.White
                Dim ClientInRoom As DataTable

                'Dim customPictureBox = New Guna.UI.WinForms.GunaCirclePictureBox()

                'customPictureBox.BaseColor = System.Drawing.Color.White
                'If rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_propre Then
                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.ROOM_STATE_FREE
                'ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_sale Then
                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.ROOM_STATE_FREE_SALE
                'ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_propre Then
                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.ROOM_STATE_OCCUPIED
                ' ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_sale Then
                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.ROOM_STATE_OCCUPIED_SALE
                'ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.hors_service Then
                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.ROOM_STATE_HORS
                'Else
                'customPictureBox.Image = Global.BarclesHSoft.My.Resources.Resources.ROOM_STATE_FREE
                'End If


                'customPictureBox.Location = New System.Drawing.Point(3, 18)
                'customPictureBox.Name = "GunaCirclePictureBox1" & i
                'customPictureBox.Size = New System.Drawing.Size(50, 60)
                'customPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
                'customPictureBox.TabIndex = 2
                'customPictureBox.TabStop = False
                'customPictureBox.UseTransfarantBackground = False

                'customPanel.Controls.Add(customPictureBox)

                If rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_sale Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_sale Then
                    buttonColor = Color.Red
                    'toolTip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                    'toolTip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))
                ElseIf rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.occupee_propre Or rooms.Rows(i)("ETAT_CHAMBRE_NOTE") = GlobalVariable.libre_propre Then

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

                    buttonColor = Color.LightGreen
                    textColor = Color.Black
                    'toolTip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                    'toolTip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))

                ElseIf rooms.Rows(i)("ETAT_CHAMBRE") = 1 Or rooms.Rows(i)("ETAT_CHAMBRE") = 5 Then
                    buttonColor = Color.Black

                    'Tip.ToolTipTitle = rooms.Rows(i)("CODE_CHAMBRE")
                    'Tip.SetToolTip(customPictureBox, rooms.Rows(i)("ETAT_CHAMBRE_NOTE"))
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
                customLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                customLabel.Location = New System.Drawing.Point(20, 25)
                customLabel.Name = "customLabel"
                customLabel.Size = New System.Drawing.Size(108, 20)
                customLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                customLabel.TabIndex = 4

                If Not Trim(rooms.Rows(i)("GUEST_DAI")) = "" Then
                    customLabel.Text = "Un message"
                End If

                customPanel.Controls.Add(customLabel)

                Dim customButton As New Guna.UI.WinForms.GunaButton()

                customButton.AnimationHoverSpeed = 0.07!
                customButton.AnimationSpeed = 0.03!
                customButton.BaseColor = buttonColor
                customButton.BorderColor = System.Drawing.Color.Black
                customButton.DialogResult = System.Windows.Forms.DialogResult.None
                customButton.FocusedColor = System.Drawing.Color.Empty
                customButton.Font = New System.Drawing.Font("Segoe UI", 10.0!)
                customButton.ForeColor = System.Drawing.Color.White
                If True Then

                Else


                End If
                customButton.Image = Nothing
                customButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                customButton.ImageSize = New System.Drawing.Size(52, 52)
                customButton.Location = New System.Drawing.Point(0, 0)
                customButton.Name = rooms.Rows(i)("CODE_CHAMBRE")
                customButton.OnHoverBaseColor = buttonColor
                customButton.OnHoverBorderColor = buttonColor
                customButton.OnHoverForeColor = System.Drawing.Color.White
                customButton.OnHoverImage = Nothing
                customButton.OnPressedColor = System.Drawing.Color.Black
                customButton.Size = New System.Drawing.Size(108, 30)
                customButton.TabIndex = 3
                customButton.Text = rooms.Rows(i)("CODE_CHAMBRE")
                customButton.TextAlign = System.Drawing.ContentAlignment.TopCenter

                AddHandler customButton.DoubleClick, AddressOf onDoucleClik
                AddHandler customPanel.DoubleClick, AddressOf onDoucleClik

                customPanel.Controls.Add(customButton)

                TabPageEtatsDesChambres.Controls.Add(customPanel)

                toolTip.ShowAlways = True

                toolTip.UseFading = True
                toolTip.UseAnimation = True
                toolTip.IsBalloon = True
                toolTip.AutoPopDelay = 5000

                xValue = xValue + 120

                'alignement 
                If (i + 1) Mod 11 = 0 Then
                    xValue = 0
                    yValue = yValue + 65
                End If

            Next

        End If

    End Sub

    Private Sub onDoucleClik(ByVal sender As Object, ByVal e As System.EventArgs)

        'Dim btn As Panel = (CType(sender, Panel).Tag.ToString)

        'MessageBox.Show(btn.Text)

    End Sub

    'Enregistrement des nettoyages
    Private Sub GunaButtonAllBottomRightToLeft_Click(sender As Object, e As EventArgs) Handles GunaButtonAllBottomRightToLeft.Click

        Dim service As New ServicesEtage()

        service.calendrierDeNettoyage(GunaDataGridViewP1, GunaTextBoxPersonnelCode1.Text, GunaTextBox6.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP2, GunaTextBox7.Text, GunaTextBox8.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP3, GunaTextBox11.Text, GunaTextBox12.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP4, GunaTextBox9.Text, GunaTextBox10.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP5, GunaTextBox13.Text, GunaTextBox14.Text)
        service.calendrierDeNettoyage(GunaDataGridViewP6, GunaTextBox15.Text, GunaTextBox16.Text)

        GunaDataGridViewP1.Columns.Clear()
        GunaDataGridViewP2.Columns.Clear()
        GunaDataGridViewP3.Columns.Clear()
        GunaDataGridViewP4.Columns.Clear()
        GunaDataGridViewP5.Columns.Clear()
        GunaDataGridViewP6.Columns.Clear()

    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs)
        StatusDesChambres()
    End Sub

    Private Sub TabPageDescription_Click(sender As Object, e As EventArgs) Handles TabPageDescription.Click

    End Sub

    Public Sub AffichageDeTitre()

        If GlobalVariable.actualLanguageValue = 1 Then


            If TabControlRoomForm.SelectedIndex = 0 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "CREATION DE CHAMBRE"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "CREATION DE SALLE"
                End If
            ElseIf TabControlRoomForm.SelectedIndex = 1 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LISTE DES CHAMBRES"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LISTE DES SALLES"
                End If
            ElseIf TabControlRoomForm.SelectedIndex = 2 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LISTE DES CHAMBRES HORS SERVICES"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LISTE DES SALLES HORS SERVICES"
                End If
            ElseIf TabControlRoomForm.SelectedIndex = 3 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "HISTORIQUES DES CHAMBRES"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "HISTORIQUES DES SALLES"
                End If
            End If

        Else


            If TabControlRoomForm.SelectedIndex = 0 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "ROOM CREATION"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "HALL CREATION"
                End If
            ElseIf TabControlRoomForm.SelectedIndex = 1 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LIST OF ROOMS"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LIST OF HALLS"
                End If
            ElseIf TabControlRoomForm.SelectedIndex = 2 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LIST OF ROOMS OUT OF ORDER"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LIST OF HALLS OUT OF ORDER"
                End If
            ElseIf TabControlRoomForm.SelectedIndex = 3 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "ROOMS HISTORY"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "HALLS HISTORY"
                End If
            End If

        End If

    End Sub

    Private Sub libelleChamp()

        If GlobalVariable.actualLanguageValue = 1 Then

            'Initialisation of ele,ents depending on if we are working on chambre or salle de fete
            If GlobalVariable.typeChambreOuSalle = "salle" Then

                'GunaLabelGestCompteGeneraux.Text = "Création et mise à jour des Salles"
                GunaLabelTypeChambreOuSalle.Text = "Type de Salle"
                GunaLabelCodeSalleOuNumeroChambre.Text = "Code Salle"
                GunaLabelEtatChambreOuSalle.Text = "Etat de la Salle"

            ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then

                'GunaLabelGestCompteGeneraux.Text = "Création et mise à jour des chambres"
                GunaLabelTypeChambreOuSalle.Text = "Type de Chambre"
                GunaLabelCodeSalleOuNumeroChambre.Text = "Numéro Chambre"
                GunaLabelEtatChambreOuSalle.Text = "Etat de la Chambre"

            End If

        Else

            'Initialisation of ele,ents depending on if we are working on chambre or salle de fete
            If GlobalVariable.typeChambreOuSalle = "salle" Then

                'GunaLabelGestCompteGeneraux.Text = "Création et mise à jour des Salles"
                GunaLabelTypeChambreOuSalle.Text = "Hall type"
                GunaLabelCodeSalleOuNumeroChambre.Text = "Hall Code"
                GunaLabelEtatChambreOuSalle.Text = "Hall state"

            ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then

                'GunaLabelGestCompteGeneraux.Text = "Création et mise à jour des chambres"
                GunaLabelTypeChambreOuSalle.Text = "Type of Rooms"
                GunaLabelCodeSalleOuNumeroChambre.Text = "Room Number"
                GunaLabelEtatChambreOuSalle.Text = "Room state"

            End If

        End If


    End Sub

    Private Sub GunaRadioButtonChambre_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonChambre.CheckedChanged

        DataGridViewRoomListe.Columns.Clear()

        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
            Functions.SiplifiedClearTextBox(Me)
        End If

        AffichageDeTitre()

        libelleChamp()

        FillingOfTypeChambreOuSalleComboBox()

    End Sub

    Private Sub GunaRadioButtonSalle_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonSalle.CheckedChanged

        DataGridViewRoomListe.Columns.Clear()

        If GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
            Functions.SiplifiedClearTextBox(Me)
        End If

        AffichageDeTitre()

        libelleChamp()

        FillingOfTypeChambreOuSalleComboBox()

    End Sub

End Class