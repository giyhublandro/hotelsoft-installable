

Imports MySql.Data.MySqlClient
    Imports System.Configuration
    Imports System.Windows.Forms.DataVisualization.Charting
    Imports System.Net
    Imports System.IO

    Imports System.ComponentModel

    '-------------------------------
    Imports System
    Imports System.Text
    Imports System.Web


Public Class RestaurantBookingForm

    'Database connection management
    'Dim connect As New DataBaseManipulation()

    Dim dateDepart As Date
    Dim dateArrivee As Date

    Dim nombreDejour As Integer

    'USED FOR BACKGROUND WORKERS

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

    'GlobalVariable.libre_sale
    'GlobalVariable.occupee_propre
    'GlobalVariable.libre_sale
    'GlobalVariable.occupee_sale
    '"Réservé"
    'GlobalVariable.hors_service

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub


    '------------------------------------- GESTION DU PLANNING----------------------------------

    Public Sub AutoLoadRoomForRouting()

        If GlobalVariable.typeChambreOuSalle = "chambre" Then

            Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

            Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaComboBoxChambreRoutage.DataSource = table
                GunaComboBoxChambreRoutage.ValueMember = "CHAMBRE"
                GunaComboBoxChambreRoutage.DisplayMember = "CHAMBRE"

            End If

        End If

    End Sub

    Public Sub AutoLoadEventList()

        If GlobalVariable.typeChambreOuSalle = "salle" Then

            'Loading other 'article families cureently called article type into a combobox
            Dim existQuery As String = "SELECT * From evenement ORDER BY LIBELLE ASC"

            Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaComboBoxEvenement.DataSource = table
                'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
                GunaComboBoxEvenement.ValueMember = "CODE_EVENEMENT"
                GunaComboBoxEvenement.DisplayMember = "LIBELLE"

            End If

        End If

    End Sub

    Public Sub AutoLoadRoomReservationSource()

        If GlobalVariable.typeChambreOuSalle = "chambre" Or GlobalVariable.typeChambreOuSalle = "salle" Then

            'Loading other 'article families cureently called article type into a combobox
            Dim existQuery As String = "SELECT * From source_reservation ORDER BY SOURCE_RESERVATION ASC"

            Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaComboBoxSourceReservation.DataSource = table
                GunaComboBoxSourceReservation.ValueMember = "CODE_SOURCE_RESERVATION"
                GunaComboBoxSourceReservation.DisplayMember = "SOURCE_RESERVATION"

                'GunaComboBoxSourceResaRapport.ValueMember = "CODE_SOURCE_RESERVATION"
                'GunaComboBoxSourceResaRapport.DisplayMember = "SOURCE_RESERVATION"

            End If

        End If

        GunaComboBoxSourceReservation.SelectedIndex = -1

    End Sub

    Public Sub ReinitialisationDesDates()

        GunaCheckBoxDayUse.Checked = False

        If GlobalVariable.AgenceActuelle.Rows.Count > 0 Then
            GunaTextBoxSerendantA.Text = GlobalVariable.AgenceActuelle.Rows(0)("VILLE")
        End If

        GunaComboBoxHeureDepart.Items.Remove(GunaComboBoxHeureDepart.SelectedItem)
        GunaComboBoxHeureDepart.Items.Add("12:00:00")
        GunaComboBoxHeureDepart.SelectedItem = "12:00:00"

        GunaComboBoxHeureArrivee.Items.Remove(GunaComboBoxHeureArrivee.SelectedItem)
        GunaComboBoxHeureArrivee.Items.Add("12:00:00")
        GunaComboBoxHeureArrivee.SelectedItem = "12:00:00"

        GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())
        'Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.selectedItem

        GunaDateTimePickerParDateArrivee.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerParDateDepart.Value = GlobalVariable.DateDeTravail

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail.ToShortDateString

        'Initializing the date of the tab depart
        GunaDateTimePickerArriveeDepart.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerDepartDepert.Value = GlobalVariable.DateDeTravail

        GunaLabelDateDepartFin.Text = GunaDateTimePickerDepartDepert.Value.ToShortDateString()
        GunaLabelDateDepartDebut.Text = GunaDateTimePickerArriveeDepart.Value.ToShortDateString()


        'Initializing the date of the tab en chambres
        GunaDateTimePickerDebutEnChambre.Value = GlobalVariable.DateDeTravail
        GunaLabel50.Text = GunaDateTimePickerDebutEnChambre.Value.ToShortDateString()


        'Initializing the dates of the tab attendus
        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail

        GunaLabel53.Text = GunaDateTimePickerFin.Value.ToShortDateString()
        GunaLabel54.Text = GunaDateTimePickerDebut.Value.ToShortDateString()

        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail

        GunaTextBoxCodeDeGroupe.Clear()

        GunaCheckBoxReservationDeGroupe.Checked = False

        'Initializing the arrival and departure date to todays date

        GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerDepart.Value = GlobalVariable.DateDeTravail.AddDays(1)

        GlobalVariable.codeReservationToUpdate = ""

        GlobalVariable.typeChambreOuSalle = "salle"

    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    '----------------------------SERVICES D'ETAGES -----------------------------------------------------------------

    '------------------------------------------- FILL OF FORM FOR RESERVATION ------------------------------------------------------

    'PERSONNAL AUTOCOMPLETE OF ROOM TYPE

    Private Sub GunaTextBoxCodeType_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCodeTypeDeChambre.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxCodeTypeDeChambre.Text).Equals("") Then
            'On desactive les informations liéa à la chambre tant que le type de chambre n'est pas rempli
            GunaTextBoxNumeroChambre.Enabled = False
            GunaButtonRoomSearchButton.Enabled = False

            GunaTextBoxLibelleTYpe.Clear()
            GunaTextBoxpPrixAffiche.Text = 0
            GunaTextBoxMontantAccorde.Text = 0
            GunaTextBoxprixRepas.Text = 0
            GunaTextBoxServiceEtProduitSup.Text = 0
            'GunaTextBoxCapacite.Clear()
            'GunaTextBoxSuperficie.Clear()

            If Not GunaCheckBoxGratuitee.Checked Then
                GunaComboBoxCodeTarif.Visible = False
                GunaLabelCodeTarif.Visible = False
            End If

            If GlobalVariable.typeChambreOuSalle = "salle" Then
                GunaTextBoxSuperficie.Clear()
                GunaTextBoxCapacite.Clear()

                GunaTextBoxNbrePersonne.Text = 0
                GunaTextBoxMontantAfficherSalle.Text = 0
                GunaTextBoxDecoration.Text = 0
                GunaTextBoxMontantReelSalle.Text = 0

            End If

            GunaTextBoxNumeroChambre.Clear()
            GunaTextBoxLibelleChambre.Clear()

            GunaDataGridViewRoom.Visible = False

            GunaButtonReservation.Visible = False
            GunaButtonCheckIn.Visible = False
            GunaButtonCheckOut.Visible = False

        Else
            'On active les informations lié à la chambre car le type de chambre est rempli
            GunaTextBoxNumeroChambre.Enabled = True
            GunaButtonRoomSearchButton.Enabled = True
        End If

        GunaDataGridViewRoomType.Visible = True

        Dim query As String = ""

        If GlobalVariable.typeChambreOuSalle = "salle" Then
            query = "SELECT CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE, PRIX AS 'PRIX' From type_chambre WHERE CODE_TYPE_CHAMBRE Like '%" & Trim(GunaTextBoxCodeTypeDeChambre.Text) & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE=@TYPE"
        Else
            If GunaCheckBoxDayUse.Checked Then
                query = "SELECT CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE, MONTANT_SIESTE AS 'PRIX' From type_chambre WHERE CODE_TYPE_CHAMBRE Like '%" & Trim(GunaTextBoxCodeTypeDeChambre.Text) & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE=@TYPE"
            Else
                query = "SELECT CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE, PRIX AS 'PRIX' From type_chambre WHERE CODE_TYPE_CHAMBRE Like '%" & Trim(GunaTextBoxCodeTypeDeChambre.Text) & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE=@TYPE"
            End If
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewRoomType.DataSource = table
        Else
            GunaDataGridViewRoomType.Columns.Clear()
            GunaDataGridViewRoomType.Visible = False
        End If

        If GunaTextBoxCodeTypeDeChambre.Text.Trim().Equals("") Then
            GunaDataGridViewRoomType.Columns.Clear()
            GunaDataGridViewRoomType.Visible = False
        End If

        'connect.closeConnection()

    End Sub

    'Filling the other fields concerning the room type when the click on the cusom Datagrid - Filling of room type at front desk
    Private Sub GunaDataGridViewRoomType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRoomType.CellClick

        GunaDataGridViewRoom.Visible = False

        If e.RowIndex >= 0 Then

            GunaTextBoxNumeroChambre.Clear()

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewRoomType.Rows(e.RowIndex)

            GunaTextBoxLibelleTYpe.Text = row.Cells("LIBELLE_TYPE_CHAMBRE").Value.ToString
            GunaTextBoxCodeTypeDeChambre.Text = row.Cells("CODE_TYPE_CHAMBRE").Value.ToString

            'GunaTextBoxLibelleChambre.Text = row.Cells(2).Value.ToString

            Dim TypeChambre As DataTable = Functions.getElementByCode(Trim(GunaTextBoxCodeTypeDeChambre.Text), "type_chambre", "CODE_TYPE_CHAMBRE")

            If TypeChambre.Rows.Count > 0 Then

                If GunaRadioButtonSalleFete.Checked Then

                    Dim prix As Double = 0
                    Dim superficie As Double = 0
                    Dim capacite As Double = 0
                    Double.TryParse(TypeChambre.Rows(0)("PRIX"), prix)
                    Double.TryParse(TypeChambre.Rows(0)("SUPERFICIE"), superficie)
                    Double.TryParse(TypeChambre.Rows(0)("CAPACITE"), capacite)
                    GunaTextBoxMontantAfficherSalle.Text = Format(prix, "#,##0")

                    If GunaCheckBoxGratuitee.Checked Then
                        If GunaCheckBoxGratuiteInfo.Checked Then
                            If Not Trim(GunaTextBoxAuthoriseePar.Text).Equals("") Then
                                prix = 0
                            End If
                        End If
                    End If

                    GunaTextBoxMontantReelSalle.Text = Format(prix, "#,##0")
                    GunaTextBoxSuperficie.Text = Format(superficie, "#,##0")
                    GunaTextBoxCapacite.Text = Format(capacite, "#,##0")

                    Dim montant As Double = 0

                    Double.TryParse(GunaTextBoxMontantReelSalle.Text.Trim(), montant)

                    If GunaCheckBoxDayUse.Checked Then
                        GunaTextBoxGrandTotal.Text = Format(montant, "#,##0")
                    Else
                        GunaTextBoxGrandTotal.Text = Format(montant * CType(GunaTextBoxTempsAFaire.Text, Int32), "#,##0")
                    End If


                End If

                GunaDataGridViewRoomType.Visible = False

                'We make sure it is possible to Choose a room if a room type is choosen first
                'We set back the diasbled values after checkin or save
                GunaTextBoxNumeroChambre.BaseColor = Color.White
                GunaTextBoxNumeroChambre.Enabled = True

                'connect.closeConnection()

                reservationButtonToDisplay()

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Bien vouloir choisir une catégorie", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Please select a categorie", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If


        End If


    End Sub

    'AFFECTATION DES TARIFICATIONS DYNAMIQUE

    Public Sub determinonsSiOnDoitAfficherLedropDownDesTarifsAssocieAUnTypeDeChambre(ByVal CODE_TYPE_CHAMBRE As String)

        'ON PRENDS LA TARIFICATION AFFECTE CORRESPONDANT AUX TYPE DE CHAMBRE

        Dim existQuerytarif As String = "SELECT * From tarif_prix, tarification_dynamique WHERE CODE_TYPE=@CODE_TYPE_CHAMBRE AND tarif_prix.CODE_TARIF_DYNAMIQUE = tarification_dynamique.CODE_TARIF_DYNAMIQUE AND tarification_dynamique.ETAT=@ETAT ORDER BY LIBELLE_TARIF ASC"

        Dim commandtarif As New MySqlCommand(existQuerytarif, GlobalVariable.connect)
        Dim ETAT As Integer = 1

        commandtarif.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        commandtarif.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT

        Dim adaptertarif As New MySqlDataAdapter(commandtarif)
        Dim tarif As New DataTable()

        adaptertarif.Fill(tarif)

        If tarif.Rows.Count > 0 Then

            GunaComboBoxCodeTarif.DataSource = tarif
            GunaComboBoxCodeTarif.ValueMember = "CODE_TARIF"
            GunaComboBoxCodeTarif.DisplayMember = "LIBELLE_TARIF"

            GunaComboBoxCodeTarif.Visible = True
            GunaLabelCodeTarif.Visible = True

            GunaComboBoxCodeTarif.Enabled = True

        Else

            'DONC ON SE REPOSE SUR LES PRIX AFFICHE
            GunaComboBoxCodeTarif.Visible = False
            GunaLabelCodeTarif.Visible = False

            GunaComboBoxCodeTarif.Enabled = False

        End If

    End Sub

    Public Sub determinationDesTarifsAssocieAUnTypeDeChambre(ByVal CODE_TYPE_CHAMBRE As String)

        determinonsSiOnDoitAfficherLedropDownDesTarifsAssocieAUnTypeDeChambre(CODE_TYPE_CHAMBRE)

        'DETERMINONS LE PRIX DE DEPART A PARTIR DE LA TARIFICATION
        Dim tarifDynamique As New Tarifs

        Dim DateDebut As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
        Dim CODE_TARIF_RESERVATION As String = ""

        'If tarif.Rows.Count > 0 Then

        If GunaComboBoxCodeTarif.SelectedIndex >= 0 Then

            If GunaComboBoxCodeTarif.Visible Then
                CODE_TARIF_RESERVATION = GunaComboBoxCodeTarif.SelectedValue.ToString()
            End If

        End If

        Dim DateArrivee As Date = GunaDateTimePickerArrivee.Value.ToShortDateString
        Dim DateDepart As Date = GunaDateTimePickerDepart.Value.ToShortDateString

        Dim MONTANT As Double = 0

        MONTANT = tarifDynamique.determinationDuMontantDeDepartPourlaReservation(DateDebut, CODE_TARIF_RESERVATION, DateArrivee, DateDepart, CODE_TYPE_CHAMBRE)

        If MONTANT > 0 Then
            GunaTextBoxMontantAccorde.Text = Format(MONTANT, "#,##0")
        Else
            GunaTextBoxMontantAccorde.Text = Format(0, "#,##0")
        End If

    End Sub

    'PERSONNAL AUTOCOMPLETE OF ROOM
    Private Sub GunaTextBoxNumeroChambre_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNumeroChambre.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxNumeroChambre.Text).Equals("") Then
            GunaTextBoxLibelleChambre.Clear()
            GunaDataGridViewRoom.Visible = False
        End If

        GunaDataGridViewRoom.Visible = True

        If True Then

            'We select all the rooms that are not occupied
            'Dim query As String = "SELECT CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, LIBELLE_CHAMBRE From chambre WHERE ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' AND TYPE=@TYPE AND ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE OR ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE2 AND TYPE=@TYPE AND ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' ORDER BY CODE_CHAMBRE ASC"
            Dim query As String = "SELECT CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, LIBELLE_CHAMBRE From chambre WHERE ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' AND TYPE=@TYPE AND ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE ORDER BY CODE_CHAMBRE ASC"

            If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 1 Then
                query = "SELECT CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, LIBELLE_CHAMBRE From chambre WHERE ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' ORDER BY CODE_CHAMBRE ASC"
            End If

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

            command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(GunaTextBoxCodeTypeDeChambre.Text)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre
            'command.Parameters.Add("@ETAT_CHAMBRE_NOTE2", MySqlDbType.VarChar).Value = GlobalVariable.libre_sale
            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------

            'We select the rooms that are found in reservation
            'Dim query1 As String = "SELECT CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, LIBELLE_CHAMBRE From chambre, reservation WHERE DATE_ENTTRE >= @DATE_SORTIE AND ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND  chambre.CODE_CHAMBRE=reservation.CHAMBRE_ID AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' AND ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE AND chambre.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"
            Dim query1 As String = "SELECT CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, LIBELLE_CHAMBRE From chambre, reservation WHERE DATE_ENTTRE >= @DATE_SORTIE AND ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND  chambre.CODE_CHAMBRE=reservation.CHAMBRE_ID AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' AND ETAT_CHAMBRE_NOTE IN ('Occupée propre','Occupée sale') AND chambre.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

            'OR DATE_SORTIE <= @DATE_ENTREE
            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

            command1.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(GunaTextBoxCodeTypeDeChambre.Text)
            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            'command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.occupee_propre
            'command1.Parameters.Add("@ETAT_CHAMBRE_NOTE2", MySqlDbType.VarChar).Value = GlobalVariable.occupee_sale
            command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
            command1.Parameters.Add("@DATE_SORTIE", MySqlDbType.Date).Value = GunaDateTimePickerDepart.Value.ToShortDateString
            command1.Parameters.Add("@DATE_ENTREE", MySqlDbType.Date).Value = GunaDateTimePickerArrivee.Value.ToShortDateString

            Dim adapter1 As New MySqlDataAdapter(command1)
            Dim table1 As New DataTable()

            adapter1.Fill(table1)

            If Not table1.Rows.Count > 0 Then

                Dim DateEntree As Date = GunaDateTimePickerArrivee.Value.ToShortDateString

                'We select the rooms that are found in reserve_conf
                Dim query2 As String = "SELECT CODE_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE_NOTE From chambre, reserve_conf WHERE reserve_conf.CHAMBRE_ID = chambre.CODE_CHAMBRE AND ETAT_RESERVATION = 1 AND " & DateEntree.ToString("yyyy-MM-dd") & " >= DATE_SORTIE  AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE '%" & GunaTextBoxNumeroChambre.Text & "%' AND chambre.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

                Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
                'command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

                command2.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(GunaTextBoxCodeTypeDeChambre.Text)
                command2.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command2.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                'command2.Parameters.Add("@DATE_ENTREE", MySqlDbType.Date).Value = 

                Dim adapter2 As New MySqlDataAdapter(command2)
                Dim table2 As New DataTable()

                'We don't have a room in reservation so we search into reserve_conf
                If table2.Rows.Count > 0 Then
                    table.Merge(table2)
                End If

            Else
                table.Merge(table1)
            End If

            GunaDataGridViewRoom.DataSource = table

            If (table.Rows.Count > 0) Then
                GunaDataGridViewRoom.Visible = True
                GunaDataGridViewRoom.DataSource = table
            Else
                GunaDataGridViewRoom.Columns.Clear()
                GunaDataGridViewRoom.Visible = False
            End If

            If Trim(GunaTextBoxNumeroChambre.Text).Equals("") Then
                GunaDataGridViewRoom.Visible = False
            End If

        Else

            'We select all the rooms that are not occupied
            Dim query As String = "SELECT CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, LIBELLE_CHAMBRE From chambre WHERE ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' AND TYPE=@TYPE AND ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE OR ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE2 AND TYPE=@TYPE AND ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' ORDER BY CODE_CHAMBRE ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

            command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(GunaTextBoxCodeTypeDeChambre.Text)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre
            command.Parameters.Add("@ETAT_CHAMBRE_NOTE2", MySqlDbType.VarChar).Value = GlobalVariable.libre_sale
            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------

            'We select the rooms that are found in reservation
            'Dim query1 As String = "Select CODE_CHAMBRE,LIBELLE_CHAMBRE, ETAT_CHAMBRE_NOTE From chambre INNER JOIN reservation WHERE reservation.CHAMBRE_ID = chambre.CODE_CHAMBRE AND ETAT_RESERVATION = 0 AND DATE_SORTIE < @DATE_ENTREE AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & GunaTextBoxNumeroChambre.Text & "%' AND chambre.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"
            Dim query1 As String = "SELECT CODE_CHAMBRE, ETAT_CHAMBRE_NOTE, LIBELLE_CHAMBRE From chambre, reservation WHERE DATE_ENTTRE >= @DATE_SORTIE AND ETAT_CHAMBRE = 0 AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND  chambre.CODE_CHAMBRE=reservation.CHAMBRE_ID AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE'%" & Trim(GunaTextBoxNumeroChambre.Text) & "%' AND ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE AND chambre.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

            'OR DATE_SORTIE <= @DATE_ENTREE
            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

            command1.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(GunaTextBoxCodeTypeDeChambre.Text)
            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.occupee_propre
            command1.Parameters.Add("@ETAT_CHAMBRE_NOTE2", MySqlDbType.VarChar).Value = GlobalVariable.occupee_sale
            command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
            command1.Parameters.Add("@DATE_SORTIE", MySqlDbType.Date).Value = GunaDateTimePickerDepart.Value.ToShortDateString
            command1.Parameters.Add("@DATE_ENTREE", MySqlDbType.Date).Value = GunaDateTimePickerArrivee.Value.ToShortDateString

            Dim adapter1 As New MySqlDataAdapter(command1)
            Dim table1 As New DataTable()

            adapter1.Fill(table1)

            If Not table1.Rows.Count > 0 Then

                Dim DateEntree As Date = GunaDateTimePickerArrivee.Value.ToShortDateString

                'We select the rooms that are found in reserve_conf
                Dim query2 As String = "SELECT CODE_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE_NOTE From chambre, reserve_conf WHERE reserve_conf.CHAMBRE_ID = chambre.CODE_CHAMBRE AND ETAT_RESERVATION = 1 AND " & DateEntree.ToString("yyyy-MM-dd") & " >= DATE_SORTIE  AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND CODE_AGENCE= @CODE_AGENCE AND CODE_CHAMBRE LIKE '%" & GunaTextBoxNumeroChambre.Text & "%' AND chambre.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

                Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
                'command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

                command2.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(GunaTextBoxCodeTypeDeChambre.Text)
                command2.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command2.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                'command2.Parameters.Add("@DATE_ENTREE", MySqlDbType.Date).Value = 

                Dim adapter2 As New MySqlDataAdapter(command2)
                Dim table2 As New DataTable()

                'We don't have a room in reservation so we search into reserve_conf
                If table2.Rows.Count > 0 Then
                    table.Merge(table2)
                End If

            Else
                table.Merge(table1)
            End If

            GunaDataGridViewRoom.DataSource = table

            If (table.Rows.Count > 0) Then
                GunaDataGridViewRoom.Visible = True
                GunaDataGridViewRoom.DataSource = table
            Else
                GunaDataGridViewRoom.Columns.Clear()
                GunaDataGridViewRoom.Visible = False
            End If

            If Trim(GunaTextBoxNumeroChambre.Text).Equals("") Then
                GunaDataGridViewRoom.Visible = False
            End If

        End If

    End Sub

    'Refresh Room information
    Sub refreshChambre()

        Dim Query As String = "SELECT * From chambre WHERE ETAT_CHAMBRE=@ETAT_CHAMBRE AND TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(table)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer

        For i = 0 To table.Rows.Count - 1
            col.Add(table.Rows(i)("CODE_CHAMBRE").ToString())
        Next

        'connect.closeConnection()

        'We display buttons
        reservationButtonToDisplay()

    End Sub

    'Filling the other fields concerning the room when the value of th room changes
    Private Sub GunaDataGridViewRoom_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRoom.CellClick

        GunaDataGridViewRoom.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewRoom.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM chambre INNER JOIN type_chambre WHERE chambre.CODE_TYPE_CHAMBRE = type_chambre.CODE_TYPE_CHAMBRE AND CODE_CHAMBRE=@CODE_CHAMBRE AND chambre.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"
            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = Trim(row.Cells("CODE_CHAMBRE").Value.ToString)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            adapter.SelectCommand = command
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                Dim chambreId As Integer = 0
                Integer.TryParse(table.Rows(0)("ID_CHAMBRE"), chambreId)
                GlobalVariable.idChambre = chambreId
                GlobalVariable.codeChambre = row.Cells("CODE_CHAMBRE").Value.ToString
                GunaTextBoxNumeroChambre.Text = row.Cells("CODE_CHAMBRE").Value.ToString
                GunaTextBoxLibelleChambre.Text = table.Rows(0)("LOCALISATION").ToString
                'Dim superficie As Double
                'Double.TryParse()
                GunaTextBoxSuperficie.Text = table.Rows(0)("SUPERFICIE")
                GunaTextBoxCapacite.Text = table.Rows(0)("CAPACITE")

                GunaDataGridViewRoom.Visible = False

            Else

                GunaTextBoxSuperficie.Clear()
                GunaTextBoxLibelleTYpe.Clear()
                GunaTextBoxNumeroChambre.Clear()
                GunaTextBoxLibelleChambre.Clear()
                GunaTextBoxpPrixAffiche.Text = 0
                GunaTextBoxCodeTypeDeChambre.Clear()
                GunaTextBoxMontantAccorde.Text = 0
                GunaTextBoxprixRepas.Text = 0
                GunaTextBoxServiceEtProduitSup.Text = 0

            End If

            'connect.closeConnection()

        End If

    End Sub

    'We empty all the filed of the form after registration

    Private Sub emtptyRegistrationFields()

        'Refreshing the database of the rooms to select
        refreshChambre()

        '---------------------- Room field -----------------------
        GunaTextBoxLibelleChambre.Text = ""
        GunaTextBoxCodeTypeDeChambre.Text = ""
        GunaTextBoxLibelleTYpe.Text = ""
        GunaTextBoxNumeroChambre.Text = ""

        '----------------------periode field
        GunaTextBoxTempsAFaire.Text = 0

        GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerDepart.Value = GlobalVariable.DateDeTravail

        '---------------- calculation field
        GunaTextBoxpPrixAffiche.Text = 0
        GunaTextBoxMontantAccorde.Text = 0
        GunaTextBoxNbreAdulte.Text = 0
        GunaTextBoxNbreEnfant.Text = 0
        GunaTextBoxNbrePersonne.Text = 0


        GunaTextBoxPrixParNuitee.Text = 0
        GunaTextBoxNombreDeJourTotal.Text = 0
        GunaTextBoxprixRepas.Text = 0
        GunaTextBoxServiceEtProduitSup.Text = 0
        GunaTextBoxMontantARegler.Text = 0
        GunaTextBoxAvance.Text = 0
        GunaTextBoxMontantCaution.Text = 0

        GunaTextBoxPrixSejour.Text = 0

        GunaTextBoxTotal.Text = 0

        GunaTextBoxMontantARegler.Text = 0
        GunaLabelSolde.Text = 0

        '--------------------- Client field
        GunaTextBoxNomPrenom.Text = ""
        GunaTextBoxTelClient.Text = ""
        GunaTextBoxClientEmail.Text = ""
        GunaTextBoxCNI.Text = ""
        GunaTextBoxRefClient.Text = ""
        GunaTextBoxSiteWeb.Text = ""

        GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")

        'Routage
        GunaCheckBoxPetitDejRoutage.Checked = False
        GunaTextBoxPetitDejeunerRoutage.Visible = False
        GunaCheckBoxChambreRoutage.Checked = False
        GunaTextBoxPrixChambreRoutage.Visible = False


    End Sub

    'Affecting values to the field when coming from main_courante_reception to front office

    Dim mainCouranteJournaliere As New DataTable()

    Sub affectingValuesToFields()

        GlobalVariable.typeDeClientAFacturer = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            If Trim(GlobalVariable.codeReservationToUpdate).Equals("") Then
                GunaButtonReservation.Text = "Booking"
            Else
                GunaButtonReservation.Text = "Save"
            End If

        Else

            If Trim(GlobalVariable.codeReservationToUpdate).Equals("") Then
                GunaButtonReservation.Text = "Réserver"
            Else

                GunaButtonReservation.Text = "Enregistrer"
                GunaRadioButtonWhatsAppNon.Checked = True

                GunaRadioButtonWhatsAppOui.Enabled = True

            End If

        End If

        Dim checkInDateEnabled As Boolean = True
        'GESTION DE L'EMPLACEMENT DE LA RESERVATION
        '----------------------periode field -------------------------
        Dim reservation As DataTable
        reservation = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION")

        If Not reservation.Rows.Count > 0 Then

            reservation = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")
            If Not reservation.Rows.Count > 0 Then
                reservation = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_temp", "CODE_RESERVATION")
            Else
                checkInDateEnabled = False
            End If

        End If

        Dim codeType As String = ""
        Dim roomType As DataTable

        If reservation.Rows.Count > 0 Then

            If mainCouranteJournaliere IsNot Nothing Then

                If mainCouranteJournaliere.Rows.Count > 0 Then

                    codeType = mainCouranteJournaliere.Rows(0)("TYPE_CHAMBRE")

                    'INFO SUPPLEMENTAIRE PAR APPORT AU TYPE DE CHAMBRE
                    roomType = Functions.getElementByCode(codeType, "type_chambre", "CODE_TYPE_CHAMBRE")

                    If roomType.Rows.Count > 0 Then

                        GunaTextBoxCodeTypeDeChambre.Text = roomType.Rows(0)("CODE_TYPE_CHAMBRE")
                        GunaTextBoxLibelleTYpe.Text = roomType.Rows(0)("LIBELLE_TYPE_CHAMBRE")

                    Else

                        GunaTextBoxCodeTypeDeChambre.Text = "-"
                        GunaTextBoxLibelleTYpe.Text = "-"

                    End If

                    '-----------------------------------------------------------------------------------------------------------------------
                    'On n'a le numéro de chambre alors seulement on pourra remplir les inforamtion de la chambre

                    'SI LE NUMERO DE CHAMBRE N'EST PAS VIDE

                    If Not Trim(GlobalVariable.codeChambreToUpdate).Equals("") Then
                        'SI LE NUMERO DE CHAMBRE N'EST PAS VIDE ET NE CONTIENT PAS DE TRAIT D'UNION
                        If Not Trim(GlobalVariable.codeChambreToUpdate).Equals("-") Then
                            'ON RECHERCHE LA CHAMBRE
                            Dim room As DataTable = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")
                            'SI ON TROUVE LA CHAMBRE
                            If room.Rows.Count > 0 Then
                                'ON AFFICHE SES INFORMATION
                                GunaTextBoxNumeroChambre.Text = room.Rows(0)("CODE_CHAMBRE").ToString
                                GunaTextBoxLibelleChambre.Text = room.Rows(0)("LOCALISATION").ToString
                                'GunaTextBoxLibelleChambre.Text = room.Rows(0)("LIBELLE_CHAMBRE")

                            Else

                                GunaTextBoxNumeroChambre.Text = ""
                                GunaTextBoxLibelleChambre.Text = ""
                                GunaTextBoxLibelleChambre.Text = ""

                            End If

                        Else

                            GunaTextBoxNumeroChambre.Text = ""
                            GunaTextBoxLibelleChambre.Text = ""
                            GunaTextBoxLibelleChambre.Text = ""

                        End If

                    Else

                        GunaTextBoxNumeroChambre.Text = ""
                        GunaTextBoxLibelleChambre.Text = ""
                        GunaTextBoxLibelleChambre.Text = ""

                    End If

                Else

                    'LA RESERVATION N'EST PAS ASSOCIE A UNE MAINCOURANTE

                    Dim CHAMBRE_CODE As String = reservation.Rows(0)("CHAMBRE_ID")
                    Dim chamabreInfo As DataTable = Functions.getElementByCode(CHAMBRE_CODE, "chambre", "CODE_CHAMBRE")

                    'MAI ASSOCIE A UNE CHAMBRE
                    If chamabreInfo.Rows.Count > 0 Then

                        '-------------------------------------------------------------------------------------------

                        codeType = chamabreInfo.Rows(0)("CODE_TYPE_CHAMBRE")

                        roomType = Functions.getElementByCode(codeType, "type_chambre", "CODE_TYPE_CHAMBRE")

                        If roomType.Rows.Count > 0 Then

                            GunaTextBoxCodeTypeDeChambre.Text = roomType.Rows(0)("CODE_TYPE_CHAMBRE")
                            GunaTextBoxLibelleTYpe.Text = roomType.Rows(0)("LIBELLE_TYPE_CHAMBRE")

                        Else

                            GunaTextBoxCodeTypeDeChambre.Text = "-"
                            GunaTextBoxLibelleTYpe.Text = "-"

                        End If
                        '-----------------------------------------------------------------------------------------------------------------------
                        'On n'a le numéro de chambre alors seulement on pourra remplir les inforamtion de la chambre

                        If Not Trim(GlobalVariable.codeChambreToUpdate).Equals("") Then
                            'SI LE NUMERO DE CHAMBRE N'EST PAS VIDE ET NE CONTIENT PAS DE TRAIT D'UNION
                            If Not Trim(GlobalVariable.codeChambreToUpdate).Equals("-") Then
                                'ON RECHERCHE LA CHAMBRE
                                Dim room As DataTable = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")
                                'SI ON TROUVE LA CHAMBRE
                                If room.Rows.Count > 0 Then
                                    'ON AFFICHE SES INFORMATION
                                    GunaTextBoxNumeroChambre.Text = room.Rows(0)("CODE_CHAMBRE").ToString
                                    GunaTextBoxLibelleChambre.Text = room.Rows(0)("LOCALISATION").ToString
                                    'GunaTextBoxLibelleChambre.Text = room.Rows(0)("LIBELLE_CHAMBRE")

                                Else

                                    GunaTextBoxNumeroChambre.Text = ""
                                    GunaTextBoxLibelleChambre.Text = ""
                                    GunaTextBoxLibelleChambre.Text = ""

                                End If

                            Else

                                GunaTextBoxNumeroChambre.Text = ""
                                GunaTextBoxLibelleChambre.Text = ""
                                GunaTextBoxLibelleChambre.Text = ""

                            End If

                        Else

                            GunaTextBoxNumeroChambre.Text = ""
                            GunaTextBoxLibelleChambre.Text = ""
                            GunaTextBoxLibelleChambre.Text = ""

                        End If
                        '-------------------------------------------------------------------------------------------

                        GunaTextBoxNumeroChambre.Text = GlobalVariable.codeChambreToUpdate
                        GunaTextBoxLibelleChambre.Text = chamabreInfo.Rows(0)("LOCALISATION").ToString
                        GunaTextBoxLibelleChambre.Text = chamabreInfo.Rows(0)("LIBELLE_CHAMBRE")

                        GunaDataGridViewRoomType.Visible = False

                    Else

                        'LA RESERVATION N'EST PAS ASSOCIE A UN NUMERO DE CHAMBRE 
                        'ON RECUPERE LE TYPE DE CHAMBRE DIRECTEMENT DANS LA RESA

                        roomType = Functions.getElementByCode(reservation.Rows(0)("TYPE_CHAMBRE"), "type_chambre", "CODE_TYPE_CHAMBRE")

                        If roomType.Rows.Count > 0 Then

                            GunaTextBoxCodeTypeDeChambre.Text = roomType.Rows(0)("CODE_TYPE_CHAMBRE")
                            GunaTextBoxLibelleTYpe.Text = roomType.Rows(0)("LIBELLE_TYPE_CHAMBRE")

                        Else

                            GunaTextBoxCodeTypeDeChambre.Text = "-"
                            GunaTextBoxLibelleTYpe.Text = "-"

                        End If

                    End If

                End If

            Else

                'LA RESERVATION N'EST PAS ASSOCIE A UNE MAINCOURANTE

                Dim CHAMBRE_CODE As String = reservation.Rows(0)("CHAMBRE_ID")
                Dim chamabreInfo As DataTable = Functions.getElementByCode(CHAMBRE_CODE, "chambre", "CODE_CHAMBRE")

                'MAI ASSOCIE A UNE CHAMBRE
                If chamabreInfo.Rows.Count > 0 Then

                    '-------------------------------------------------------------------------------------------

                    codeType = chamabreInfo.Rows(0)("CODE_TYPE_CHAMBRE")

                    roomType = Functions.getElementByCode(codeType, "type_chambre", "CODE_TYPE_CHAMBRE")

                    If roomType.Rows.Count > 0 Then

                        GunaTextBoxCodeTypeDeChambre.Text = roomType.Rows(0)("CODE_TYPE_CHAMBRE")
                        GunaTextBoxLibelleTYpe.Text = roomType.Rows(0)("LIBELLE_TYPE_CHAMBRE")

                    Else

                        GunaTextBoxCodeTypeDeChambre.Text = "-"
                        GunaTextBoxLibelleTYpe.Text = "-"

                    End If
                    '-----------------------------------------------------------------------------------------------------------------------
                    'On n'a le numéro de chambre alors seulement on pourra remplir les inforamtion de la chambre

                    If Not Trim(GlobalVariable.codeChambreToUpdate).Equals("") Then
                        'SI LE NUMERO DE CHAMBRE N'EST PAS VIDE ET NE CONTIENT PAS DE TRAIT D'UNION
                        If Not Trim(GlobalVariable.codeChambreToUpdate).Equals("-") Then
                            'ON RECHERCHE LA CHAMBRE
                            Dim room As DataTable = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")
                            'SI ON TROUVE LA CHAMBRE
                            If room.Rows.Count > 0 Then
                                'ON AFFICHE SES INFORMATION
                                GunaTextBoxNumeroChambre.Text = room.Rows(0)("CODE_CHAMBRE").ToString
                                GunaTextBoxLibelleChambre.Text = room.Rows(0)("LOCALISATION").ToString
                                'GunaTextBoxLibelleChambre.Text = room.Rows(0)("LIBELLE_CHAMBRE")

                            Else

                                GunaTextBoxNumeroChambre.Text = ""
                                GunaTextBoxLibelleChambre.Text = ""
                                GunaTextBoxLibelleChambre.Text = ""

                            End If

                        Else

                            GunaTextBoxNumeroChambre.Text = ""
                            GunaTextBoxLibelleChambre.Text = ""
                            GunaTextBoxLibelleChambre.Text = ""

                        End If

                    Else

                        GunaTextBoxNumeroChambre.Text = ""
                        GunaTextBoxLibelleChambre.Text = ""
                        GunaTextBoxLibelleChambre.Text = ""

                    End If
                    '-------------------------------------------------------------------------------------------

                    GunaTextBoxNumeroChambre.Text = GlobalVariable.codeChambreToUpdate
                    GunaTextBoxLibelleChambre.Text = chamabreInfo.Rows(0)("LOCALISATION").ToString
                    GunaTextBoxLibelleChambre.Text = chamabreInfo.Rows(0)("LIBELLE_CHAMBRE")

                    GunaDataGridViewRoomType.Visible = False

                Else

                    'LA RESERVATION N'EST PAS ASSOCIE A UN NUMERO DE CHAMBRE 
                    'ON RECUPERE LE TYPE DE CHAMBRE DIRECTEMENT DANS LA RESA

                    roomType = Functions.getElementByCode(reservation.Rows(0)("TYPE_CHAMBRE"), "type_chambre", "CODE_TYPE_CHAMBRE")

                    If roomType.Rows.Count > 0 Then

                        GunaTextBoxCodeTypeDeChambre.Text = roomType.Rows(0)("CODE_TYPE_CHAMBRE")
                        GunaTextBoxLibelleTYpe.Text = roomType.Rows(0)("LIBELLE_TYPE_CHAMBRE")

                    Else

                        GunaTextBoxCodeTypeDeChambre.Text = "-"
                        GunaTextBoxLibelleTYpe.Text = "-"

                    End If

                End If

            End If

        End If

        Dim TypeChambre As DataTable = Functions.getElementByCode(GunaTextBoxCodeTypeDeChambre.Text, "type_chambre", "CODE_TYPE_CHAMBRE")

        If GunaRadioButtonSalleFete.Checked Then

            If TypeChambre.Rows.Count > 0 Then

                GunaTextBoxMontantAfficherSalle.Text = Format(TypeChambre.Rows(0)("PRIX"), "#,##0")
                GunaTextBoxMontantReelSalle.Text = Format(CType(reservation.Rows(0)("MONTANT_ACCORDE"), Double), "#,##0")

            End If

        End If

        GunaCheckBoxDayUse.Checked = False

        Dim NB_PERSONNES As Integer = 0
        'In case the reservation is not found in reservation, it will be found in reserve_conf
        If reservation.Rows.Count > 0 Then

            Dim DAY_USE As Integer = Integer.Parse(reservation.Rows(0)("DAY_USE"))

            If DAY_USE = 1 Then
                GunaCheckBoxDayUse.Checked = True
                If GlobalVariable.AgenceActuelle.Rows(0)("TARIFICATION_DYNAMIQUE") = 1 Then
                    GunaButtonTarifAppliquable.Visible = True
                Else
                    GunaButtonTarifAppliquable.Visible = False
                End If
            End If

            Dim MENSUEL As Integer = Integer.Parse(reservation.Rows(0)("MENSUEL"))

            If MENSUEL = 1 Then
                GunaButtonTarifAppliquable.Visible = True
            End If

            NB_PERSONNES = CType(reservation.Rows(0)("NB_PERSONNES"), Int32)

            If Trim(reservation.Rows(0)("AFFICHER_PRIX")) = 1 Then
                GunaCheckBoxAfficherPrix.Checked = True
            ElseIf Trim(reservation.Rows(0)("AFFICHER_PRIX")) = 0 Then
                GunaCheckBoxAfficherPrix.Checked = False
            End If

            GunaTextBoxTempsAFaire.Visible = True

            GunaTextBoxTempsAFaire.Text = 0

            If GunaRadioButtonSalleFete.Checked Then

                montanTotalDeLocationSalle(CType(GunaTextBoxTempsAFaire.Text, Int32))

                GunaTextBoxNbrePersonne.Text = CType(reservation.Rows(0)("NB_PERSONNES"), Int32)
                'Gestion des forfaits

                GunaTextBoxDepotDeGarantie.Text = Format(reservation.Rows(0)("DEPOT_DE_GARANTIE"), "#,##0")

            End If

        End If

        If reservation.Rows.Count > 0 Then


            If (CDate(reservation.Rows(0)("DATE_ENTTRE")).ToShortDateString = CDate(reservation.Rows(0)("DATE_SORTIE")).ToShortDateString) Then

                Dim numberOfHoursToSpend As Integer = 0
                'numberOfHoursToSpend = CType((DateTimeDepart - DateTimeArrivee).TotalHours, Int32)
                'numberOfHoursToSpend = CType((CDate(reservation.Rows(0)("HEURE_SORTIE")) - CDate(reservation.Rows(0)("HEURE_ENTREE"))).TotalHours, Int32)

                '--------------------------------------------------------------------------------------------------------------------------------------------------------

                Dim DateTimeArriveeStringFormat As String = CDate(reservation.Rows(0)("HEURE_ENTREE"))

                Dim DateTimeDepartStringFormat As String = CDate(reservation.Rows(0)("HEURE_SORTIE"))

                'Dim DateTimeArrivee As DateTime = DateTime.ParseExact(DateTimeArriveeStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
                Dim DateTimeArrivee As DateTime = CDate(DateTimeArriveeStringFormat).ToLongTimeString
                'Dim DateTimeDepart As DateTime = DateTime.ParseExact(DateTimeDepartStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
                Dim DateTimeDepart As DateTime = CDate(DateTimeDepartStringFormat).ToLongTimeString

                GunaComboBoxHeureDepart.Items.Remove(GunaComboBoxHeureDepart.SelectedItem)
                GunaComboBoxHeureArrivee.Items.Remove(GunaComboBoxHeureArrivee.SelectedItem)

                GunaComboBoxHeureArrivee.Items.Add(CDate(DateTimeArriveeStringFormat).ToLongTimeString)
                GunaComboBoxHeureArrivee.SelectedItem = CDate(DateTimeArriveeStringFormat).ToLongTimeString

                GunaComboBoxHeureDepart.Items.Add(CDate(DateTimeDepartStringFormat).ToLongTimeString)
                GunaComboBoxHeureDepart.SelectedItem = CDate(DateTimeDepartStringFormat).ToLongTimeString

                numberOfHoursToSpend = CType((DateTimeDepart - DateTimeArrivee).TotalHours, Int32)

                If numberOfHoursToSpend > 0 Then
                    GunaTextBoxTempsAFaire.Text = numberOfHoursToSpend
                Else
                    GunaTextBoxTempsAFaire.Text = 0
                End If

                '--------------------------------------------------------------------------------------------------------------------------------------------------------

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaLabelTempsAFaire.Text = "Total heures"
                Else
                    GunaLabelTempsAFaire.Text = "Total hours"
                End If


            Else
                'GESTION DES NUITES

                GunaTextBoxTempsAFaire.Visible = True
                GunaTextBoxTempsAFaire.Text = CType((GunaDateTimePickerDepart.Value - GunaDateTimePickerArrivee.Value).TotalDays, Int32)

                'Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.SelectedItem
                Dim DateTimeArriveeStringFormat As String = reservation.Rows(0)("HEURE_ENTREE")

                'Dim DateTimeDepartStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureDepart.SelectedItem
                Dim DateTimeDepartStringFormat As String = reservation.Rows(0)("HEURE_SORTIE")

                GunaComboBoxHeureDepart.Items.Remove(GunaComboBoxHeureDepart.SelectedItem)
                GunaComboBoxHeureArrivee.Items.Remove(GunaComboBoxHeureArrivee.SelectedItem)

                GunaComboBoxHeureArrivee.Items.Add(CDate(DateTimeArriveeStringFormat).ToLongTimeString)
                GunaComboBoxHeureArrivee.SelectedItem = CDate(DateTimeArriveeStringFormat).ToLongTimeString

                GunaComboBoxHeureDepart.Items.Add(CDate(DateTimeDepartStringFormat).ToLongTimeString)
                GunaComboBoxHeureDepart.SelectedItem = CDate(DateTimeDepartStringFormat).ToLongTimeString

                If True Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaLabelTempsAFaire.Text = "Total nuitées"
                    Else
                        GunaLabelTempsAFaire.Text = "Total nights"
                    End If

                    If GlobalVariable.AgenceActuelle.Rows(0)("TARIFICATION_DYNAMIQUE") = 1 Then
                        GunaButtonTarifAppliquable.Visible = True
                    Else
                        GunaButtonTarifAppliquable.Visible = False
                    End If

                End If

            End If

            GunaTextBoxMontantCaution.Text = Format(reservation.Rows(0)("MONTANT_TOTAL_CAUTION"), "#,##0")
            GunaTextBoxVenantDe.Text = reservation.Rows(0)("VENANT_DE")
            GlobalVariable.reserveConfCheckInState = reservation.Rows(0)("CHECKIN")

            GlobalVariable.reserveConfCheckOutState = reservation.Rows(0)("ETAT_RESERVATION")

            Dim reglement As DataTable = Functions.getElementByCode(GlobalVariable.codeReglementToUpdate, "reglement", "NUM_REGLEMENT")

        End If

        Dim nombreDeJourTotal As Integer
        Dim montantAccorde As Double
        Dim prixParNuitee As Double
        Dim prixRepas As Double
        Dim Total As Double
        Dim ServiceEtProduitSup As Double
        Dim montantARegler As Double
        Dim avance As Double
        Dim caution As Double

        Double.TryParse(GunaTextBoxAvance.Text.Trim(), avance)
        Double.TryParse(GunaTextBoxMontantCaution.Text.Trim(), caution)

        '--------------------- Client field ----------------------------
        Dim client As DataTable = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "client", "CODE_CLIENT")

        If Not client.Rows.Count > 0 Then
            'En cas d'existence d'une réservation sans nom de client 

            If Not GlobalVariable.ReservationToUpdate Is Nothing Then

                If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                    client = Functions.getElementByCode(GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT"), "client", "NOM_PRENOM")
                End If

            End If

        End If

        If client.Rows.Count > 0 Then

            GunaTextBoxNomPrenom.Text = Trim(client.Rows(0)("NOM_PRENOM"))
            GunaTextBoxTelClient.Text = client.Rows(0)("TELEPHONE")
            GunaTextBoxClientEmail.Text = client.Rows(0)("EMAIL")
            GunaTextBoxCNI.Text = client.Rows(0)("CNI")
            'GunaTextBoxRefClient.Text = GlobalVariable.codeClientToUpdate
            GunaTextBoxRefClient.Text = client.Rows(0)("CODE_CLIENT")
            GunaTextBoxSiteWeb.Text = client.Rows(0)("SITE_INTERNET")
            'GunaTextBoxCodeDeGroupe.Text = client.Rows(0)("CODE_ENTREPRISE")
            GunaTextBoxNomJeuneFille.Text = client.Rows(0)("NOM_JEUNE_FILLE")
            GunaTextBoxTypeClient.Text = client.Rows(0)("TYPE_CLIENT")
            GunaDateTimePickerDateNaissance.Value = client.Rows(0)("DATE_DE_NAISSANCE")
            GunaTextBoxLieu.Text = client.Rows(0)("LIEU_DE_NAISSANCE")
            GunaTextBoxNationalite.Text = client.Rows(0)("NATIONALITE")
            GunaTextBoxPaysResidence.Text = client.Rows(0)("PAYS_RESIDENCE")
            GunaTextBoxProfession.Text = client.Rows(0)("PROFESSION")
            GunaTextBoxNumeroCompte.Text = client.Rows(0)("NUM_COMPTE")
            GunaTextBoxRue.Text = client.Rows(0)("ADRESSE")
            GunaTextBoxVilleDeResidence.Text = client.Rows(0)("VILLE_DE_RESIDENCE")
            GunaTextBoxModeTransport.Text = client.Rows(0)("MODE_TRANSPORT")
            GunaTextBoxNumVehicule.Text = client.Rows(0)("NUM_VEHICULE")

            If Trim(client.Rows(0)("CODE_ELITE")).Equals("") Then
                GunaLabelElite.Visible = False
                GunaTextBoxCodeElite.Visible = False
                GunaTextBoxCodeElite.Text = ""
            Else
                GunaLabelElite.Visible = True
                GunaTextBoxCodeElite.Visible = True
                GunaTextBoxCodeElite.Text = client.Rows(0)("CODE_ELITE")
            End If

            If Not Trim(GunaTextBoxRefClient.Text).Equals("") Then
                Dim CODE_CLIENT As String = GunaTextBoxRefClient.Text
                gestionDesComptesDebiteurLorsDesReservationsIndividu(CODE_CLIENT)
            End If

            If Not GlobalVariable.codeReservationToUpdate = "" Then

                If Not GlobalVariable.ReservationToUpdate.Rows(0)("SOURCE_RESERVATION") = "" Then
                    GunaComboBoxSourceReservation.SelectedValue = GlobalVariable.ReservationToUpdate.Rows(0)("SOURCE_RESERVATION")
                End If

                Dim CODE_ENTREPRISE_COMPTE As String = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")

                If Not CODE_ENTREPRISE_COMPTE = "" Then

                    gestionDesComptesDebiteurLorsDesReservations(CODE_ENTREPRISE_COMPTE)

                End If

            End If

            Dim Entreprise As DataTable = Functions.getElementByCode(client.Rows(0)("CODE_ENTREPRISE"), "client", "CODE_CLIENT")

            If Entreprise.Rows.Count > 0 Then

                GunaTextBoxEntrepriseDuclient.Text = Trim(Entreprise.Rows(0)("NOM_PRENOM"))

                gestionDesComptesDebiteurLorsDesReservations(client.Rows(0)("CODE_ENTREPRISE"))

            End If

            GunaTextBoxVenantDe.Text = ""

            GunaTextBoxSerendantA.Text = ""

        Else

            'MessageBox.Show("Aucun client associé a cette réservation")

        End If



        'We display buttons
        reservationButtonToDisplay()

        'Hiding the datagrid
        GunaDataGridViewClient.Visible = False
        GunaDataGridViewRoom.Visible = False
        GunaDataGridViewPhone.Visible = False

        'Initialisation de la ville de depart
        GunaTextBoxSerendantA.Text = GlobalVariable.AgenceActuelle.Rows(0)("VILLE")

        'GESTION DE L'ENSEMBLE DES REGLEMENTS ET FACTURE D'UNE RESERVATION

        If Not GlobalVariable.codeReservationToUpdate = "" Then

            ListeDesFacturesEtReglementPourUneReservation() 'Ligne 1051

        End If

        'GESTION DES TAXES SEJOURS COLLECTE ET PETIE DEJEUNER

        'GESTION DELA RESERVATION DE GROUPE
        If Not GlobalVariable.codeReservationToUpdate = "" And GlobalVariable.typeChambreOuSalle = "chambre" Then

            'Notre réservation existe alors on controle si elle est associé a un groupe si oui on active le bouton de gestion des groupes
            If Not Trim(reservation.Rows(0)("GROUPE")) = "" Then
                GunaCheckBoxReservationDeGroupe.Checked = True
                GunaTextBoxCodeDeGroupe.Visible = True
                GunaTextBoxCodeDeGroupe.Text = reservation.Rows(0)("GROUPE")
            Else
                GunaCheckBoxReservationDeGroupe.Checked = False
            End If

            'GESTION DES ROUTAGES - INSTRUCTIONS DE ROUTAGE

            'ROUTAGE PETIT DEJEUNER
            If Not Trim(reservation.Rows(0)("PETIT_DEJEUNER_ROUTAGE")) = 0 Then
                GunaCheckBoxPetitDejRoutage.Checked = True
            Else
                GunaCheckBoxPetitDejRoutage.Checked = False
            End If

            'ROUTAGE LOGEMENT
            If Not Trim(reservation.Rows(0)("CHAMBRE_ROUTAGE")) = "" Then
                GunaCheckBoxChambreRoutage.Checked = True
                GunaComboBoxChambreRoutage.SelectedValue = reservation.Rows(0)("CHAMBRE_ROUTAGE")
                GunaTextBoxPrixChambreRoutage.Visible = True
                GunaTextBoxPrixChambreRoutage.Text = Format(reservation.Rows(0)("MONTANT_ACCORDE"), "#,##0")
            Else
                GunaCheckBoxChambreRoutage.Checked = False
                GunaTextBoxPrixChambreRoutage.Visible = False
                GunaTextBoxPrixChambreRoutage.Clear()
            End If

        End If

        EtatDuBoutonDeGestionDesReservationDeGroupe()

        'GESTION DES DESTINATION ET PROVENANCE

        If reservation.Rows.Count > 0 Then

            If reservation.Rows(0)("VENANT_DE") IsNot Nothing Then
                'reservation.Rows(0)("VENANT_DE") = ""
            End If

            If reservation.Rows(0)("SE_RENDANT_A") IsNot Nothing Then
                '.Rows(0)("SE_RENDANT_A") = ""
            End If

            If reservation.Rows(0)("RAISON") IsNot Nothing Then
                'reservation.Rows(0)("RAISON") = ""
            End If

            If reservation.Rows(0)("TYPE") = "salle" Then
                GunaTextBoxNbrePersonne.Text = reservation.Rows(0)("NB_PERSONNES")
            End If

            'GESTION DU NOMBRE DE PETIT DEJEUNER INCLUS
            'If reservation.Rows(0)("PETIT_DEJEUNER") = 1 Then
            If reservation.Rows(0)("PETIT_DEJEUNER") >= 1 Then
                GunaCheckBoxPetitDejeuenerInclus.Checked = True
                'GunaTextBoxPetitDejeuner.Text = 1
                GunaTextBoxPetitDejeuner.Text = reservation.Rows(0)("PETIT_DEJEUNER")
                GunaTextBoxBreakFastCost.Text = reservation.Rows(0)("BFK_COST")
            Else
                GunaCheckBoxPetitDejeuenerInclus.Checked = False
                GunaTextBoxPetitDejeuner.Text = 0
                GunaTextBoxBreakFastCost.Text = 0
            End If

            GunaTextBoxVenantDe.Text = reservation.Rows(0)("VENANT_DE")
            montantAccorde = reservation.Rows(0)("MONTANT_ACCORDE")
            GunaTextBoxSerendantA.Text = reservation.Rows(0)("SE_RENDANT_A")
            GunaComboBoxTypeReservation.SelectedItem = reservation.Rows(0)("RAISON")
            GunaComboBoxSourceReservation.SelectedValue = reservation.Rows(0)("SOURCE_RESERVATION")

            'GESTION DES ENTREPRISE ASSOCIE A UN CLIENT
            GunaTextBoxEntrepriseDuclient.Text = reservation.Rows(0)("NOM_ENTREPRISE")
            GunaTextBoxCodeEntrepriseDuClient.Text = reservation.Rows(0)("CODE_ENTREPRISE")
            GunaTextBoxBC.Text = reservation.Rows(0)("BC_ENTREPRISE")
            GunaDataGridViewEntrepriseDuClient.Visible = False

            'GESTION DES TARIFS ASSOCIE A LA RESERVATION

            Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxCodeEntrepriseDuClient.Text)
            Dim CODE_TYPE_CEHAMBRE As String = Trim(GunaTextBoxCodeTypeDeChambre.Text)

            'GESTION DES PRISE EN CHARGES
            Dim CODE_RESERVATION_PRISE_EN_CHARGE As String = reservation.Rows(0)("CODE_RESERVATION")

            gestionDelaPriseEnChargeDeLaReservation(GlobalVariable.codeReservationToUpdate)

            'GESTION DES GRATUITEES
            gestionDelaGratuiteeDeLaReservation(GlobalVariable.codeReservationToUpdate)

            'On recherche si l'entreprise associé au client a une tarification
            tarifToDisplay(CODE_ENTREPRISE, CODE_TYPE_CEHAMBRE)

            'GESTION DES NAVETTES
            gestionDesNavettes(2, GlobalVariable.codeReservationToUpdate)

            gestionDesComptesDebiteurLorsDesReservations(CODE_ENTREPRISE)

            ActivationOuDesactivationDeToutLesBoutonsApresUnCheckOUt()

            GunaTextBoxNbrePersonne.Text = NB_PERSONNES

            GunaTextBoxpPrixAffiche.Text = 0
            GunaTextBoxMontantAccorde.Text = 0


        End If

        'CAS OU LE PRIX DE LA CHAMBRE DE NE S'AFFICHE PAS PAR DEFAUT

        If Trim(GunaTextBoxpPrixAffiche.Text) = "" Or Trim(GunaTextBoxpPrixAffiche.Text) = "0" Then
            If Not Trim(GunaTextBoxCodeTypeDeChambre.Text) = "" Then
                Dim CODE_TYPE_CHAMBRE As String = GunaTextBoxCodeTypeDeChambre.Text
                Dim rePrixChambre As DataTable = Functions.getElementByCode(CODE_TYPE_CHAMBRE, "type_chambre", "CODE_TYPE_CHAMBRE")

                If rePrixChambre.Rows.Count > 0 Then

                    GunaTextBoxpPrixAffiche.Text = Format(rePrixChambre.Rows(0)("PRIX"), "#,##0")

                    Dim MONTANT_ACCORDE As Double = GlobalVariable.ReservationToUpdate.Rows(0)("MONTANT_ACCORDE")

                    If Double.Parse(GunaTextBoxpPrixAffiche.Text) = MONTANT_ACCORDE Then
                        GunaTextBoxMontantAccorde.Text = Format(rePrixChambre.Rows(0)("PRIX"), "#,##0")
                    Else
                        GunaTextBoxMontantAccorde.Text = Format(MONTANT_ACCORDE, "#,##0")
                    End If

                End If

            End If
        Else

        End If

        If reservation.Rows.Count > 0 Then

            montantAccorde = reservation.Rows(0)("MONTANT_ACCORDE")

            If Trim(GlobalVariable.codeReservationToUpdate) = "" Then
                GunaComboBoxHeureArrivee.Items.Clear()
                GunaComboBoxHeureArrivee.Items.Add(Now().ToLongTimeString)
                GunaComboBoxHeureArrivee.SelectedItem = Now().ToLongTimeString
            End If

            GunaDateTimePickerArrivee.Value = CDate(reservation.Rows(0)("DATE_ENTTRE")).ToShortDateString
            GunaDateTimePickerDepart.Value = CDate(reservation.Rows(0)("DATE_SORTIE")).ToShortDateString

            'GESTION DES AFFICHAGE DES DAY USE
            '--------------------------

            If GunaCheckBoxDayUse.Checked Then
                'The price to take into consideration
                Dim tempsAFaire = 1

                If Not Trim(GunaTextBoxTempsAFaire.Text) = "" Then
                    tempsAFaire = GunaTextBoxTempsAFaire.Text
                End If

                'GunaTextBoxMontantAccorde.Text = Format(montantAccorde / tempsAFaire, "#,##0")
                GunaTextBoxMontantAccorde.Text = Format(montantAccorde / tempsAFaire, "#,##0")

            End If

            suivieDesReservations(GlobalVariable.codeReservationToUpdate)

        Else

        End If

        'BLOQUER LA MODIFICATION DES PRIX SI ACTIVE

        GunaTextBoxMontantAccorde.Enabled = True

        If GlobalVariable.AgenceActuelle.Rows(0)("BLOQUER_PRIX_HEBERGEMENT") = 1 Then

            Dim CODE_RESERVATION_SEARCH As String = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_RESERVATION")
            Dim enChambre As DataTable = Functions.getElementByCode(CODE_RESERVATION_SEARCH, "reserve_conf", "CODE_RESERVATION")

            If enChambre.Rows.Count > 0 Then

                GunaTextBoxMontantAccorde.Enabled = False

                If GlobalVariable.ReservationToUpdate.Rows(0)("ETAT_RESERVATION") = 1 Then
                    'PERMET DE NE PAS ACTIVER LE CHAMP MONTANT ACCORDE AU CAS OU ON TRAITE UN CHECKOUT

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then
                        GunaTextBoxMontantAccorde.Enabled = True
                    Else
                        GunaTextBoxMontantAccorde.Enabled = False
                    End If

                End If

            Else
                GunaTextBoxMontantAccorde.Enabled = True
            End If

        End If

        If Not checkInDateEnabled Then
            GunaDateTimePickerArrivee.Enabled = False
            GunaComboBoxHeureArrivee.Enabled = False
        End If


    End Sub

    Public Sub suivieDesReservations(ByVal CODE_RESERVATION As String)

        If True Then

            Dim infoSuiviResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "suivi_des_reservations", "CODE_RESERVATION")

            If infoSuiviResa.Rows.Count > 0 Then

                'ActivationForm.GunaTextBoxMessage.Text = 

                'RESERVATION

                Dim RESERVATION_PAR As String = infoSuiviResa.Rows(0)("RESERVATION_PAR")
                Dim infoUserResa As DataTable = Functions.getElementByCode(RESERVATION_PAR, "utilisateurs", "CODE_UTILISATEUR")

                If infoUserResa.Rows.Count > 0 Then

                    GunaLabelResa.Visible = True
                    GunaLabel155.Visible = True
                    GunaLabel155.Text = infoUserResa.Rows(0)("GRIFFE_UTILISATEUR")

                Else
                    GunaLabelResa.Visible = False
                    GunaLabel155.Visible = False
                End If

                Dim CHECKIN_PAR As String = infoSuiviResa.Rows(0)("CHECKIN_PAR")
                Dim infoUserCheckIn As DataTable = Functions.getElementByCode(CHECKIN_PAR, "utilisateurs", "CODE_UTILISATEUR")

                If infoUserCheckIn.Rows.Count > 0 Then

                    'CHECKIN
                    GunaLabel153.Visible = True

                    GunaLabel156.Visible = True
                    GunaLabel156.Text = infoUserCheckIn.Rows(0)("GRIFFE_UTILISATEUR")

                Else
                    GunaLabel153.Visible = False
                    GunaLabel156.Visible = False
                End If

                'CHECKOUT

                Dim CHECKOUT_PAR As String = infoSuiviResa.Rows(0)("CHECKOUT_PAR")
                Dim infoUserCheckOut As DataTable = Functions.getElementByCode(CHECKOUT_PAR, "utilisateurs", "CODE_UTILISATEUR")

                If infoUserCheckOut.Rows.Count > 0 Then

                    GunaLabel154.Visible = True

                    GunaLabel157.Visible = True
                    GunaLabel157.Text = infoUserCheckOut.Rows(0)("GRIFFE_UTILISATEUR")
                Else
                    GunaLabel154.Visible = False
                    GunaLabel157.Visible = False
                End If

                'DELOGEMENT
                Dim DELOGEMENT_PAR As String = infoSuiviResa.Rows(0)("DELOGEMENT_PAR")
                Dim infoUserdelogement As DataTable = Functions.getElementByCode(DELOGEMENT_PAR, "utilisateurs", "CODE_UTILISATEUR")

                If infoUserdelogement.Rows.Count > 0 Then

                    GunaLabel158.Visible = True

                    GunaLabel159.Visible = True
                    GunaLabel159.Text = infoUserdelogement.Rows(0)("GRIFFE_UTILISATEUR")

                Else
                    GunaLabel158.Visible = False
                    GunaLabel159.Visible = False
                End If

                'ANNULATION
                Dim ANNULER_PAR As String = infoSuiviResa.Rows(0)("ANNULER_PAR")
                Dim infoUserAnnulation As DataTable = Functions.getElementByCode(ANNULER_PAR, "utilisateurs", "CODE_UTILISATEUR")

                If infoUserAnnulation.Rows.Count > 0 Then

                    GunaLabel160.Visible = True

                    GunaLabel161.Visible = True
                    GunaLabel161.Text = infoUserAnnulation.Rows(0)("GRIFFE_UTILISATEUR")

                Else
                    GunaLabel161.Visible = False
                    GunaLabel160.Visible = False
                End If

            End If

        Else

            GunaLabelResa.Visible = False 'RESA
            GunaLabel155.Visible = False 'RESA
            GunaLabel153.Visible = False
            GunaLabel156.Visible = False
            GunaLabel154.Visible = False
            GunaLabel157.Visible = False
            GunaLabel158.Visible = False
            GunaLabel159.Visible = False
            GunaLabel160.Visible = False
            GunaLabel161.Visible = False

        End If

    End Sub


    Private Sub ListeDesFacturesEtReglementPourUneReservation()

        Dim listeDesFactureDelaReservation As New Facture
        Dim listeDesReglementsDelaReservation As New Reglement

        Dim ListeDesFactures As DataTable = listeDesFactureDelaReservation.ListeDesFactureDeLaReservationEncours(GlobalVariable.codeReservationToUpdate)
        Dim ListeDesReglements As DataTable = listeDesReglementsDelaReservation.ListeDesReglementDeLaReservationEncours(GlobalVariable.codeReservationToUpdate)

        'LISTE DES FACTURES
        If ListeDesFactures.Rows.Count > 0 Then
            GunaDataGridViewDesFactures.DataSource = ListeDesFactures

            GunaDataGridViewDesFactures.Columns(3).DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewDesFactures.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewDesFactures.Columns(4).DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewDesFactures.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            GunaDataGridViewDesFactures.Columns(5).DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewDesFactures.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If

        'LISTE DES REGLEMENTS
        If ListeDesReglements.Rows.Count > 0 Then
            GunaDataGridViewListeDesReglement.DataSource = ListeDesReglements
            GunaDataGridViewListeDesReglement.Columns(3).DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewListeDesReglement.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            GunaDataGridViewListeDesReglement.Columns.Clear()
        End If

    End Sub
    'When ever the number of resting days changes

    Private Sub GunaTextBoxTempsAFaire_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTempsAFaire.TextChanged

        Dim tempsAFaire As Integer = 1

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, tempsAFaire)

        If GunaCheckBoxDayUse.Checked Then

            If tempsAFaire > 0 Then

                Dim newTime = DateAndTime.DateAdd("h", tempsAFaire, GunaComboBoxHeureArrivee.SelectedItem)

                GunaComboBoxHeureDepart.Items.Remove(GunaComboBoxHeureDepart.SelectedItem)

                GunaComboBoxHeureDepart.Items.Add(newTime.ToLongTimeString)

                GunaComboBoxHeureDepart.SelectedItem = newTime.ToLongTimeString

                ReservationMoneyCalculation()

            End If

        Else

            GunaDateTimePickerDepart.Value = DateAndTime.DateAdd("d", tempsAFaire, GunaDateTimePickerArrivee.Value)

            GlobalVariable.DATE_ENTTRE = GunaDateTimePickerArrivee.Value.ToShortDateString
            GlobalVariable.DATE_SORTIE = GunaDateTimePickerDepart.Value.ToShortDateString

        End If

        If Trim(GunaTextBoxTempsAFaire.Text) = "" Then
            GunaTextBoxTempsAFaire.Text = 0
        End If

        ' GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * CType(GunaTextBoxTempsAFaire.Text, Int32), "#,##0")

        montanTotalDeLocationSalle(CType(GunaTextBoxTempsAFaire.Text, Int32))

        'We display buttons
        reservationButtonToDisplay()

    End Sub

    ' -------------------------------- PERSONNAL AUTOCOMPLETION -------------------------------------
    'Autocompletion of client

    Sub AutoCompleteClient()

        'Dim Query As String = "SELECT * From client WHERE NOM_PRENOM LIKE '%'" & GunaTextBoxNomPrenom.Text & "'%'"
        Dim Query As String = "SELECT * From client"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(table)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer

        For i = 0 To table.Rows.Count - 1

            'col.Add(table.Rows(i)("NOM_PRENOM").ToString() + "-" + table.Rows(i)("EMAIL"))
            col.Add(table.Rows(i)("NOM_PRENOM").ToString())
        Next

        'connect.closeConnection()

        'We display buttons
        reservationButtonToDisplay()

    End Sub

    'Custom Live search of client
    Private Sub GunaTextBoxNomPrenom_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNomPrenom.TextChanged

        If Trim(GunaTextBoxNomPrenom.Text).Equals("") Then

            If Not GunaCheckBoxReservationDeGroupe.Checked Then


                GunaTextBoxCompteDebiteur.Visible = False
                GunaButtonCheckIn.Visible = False
                GunaTextBoxCodeElite.Visible = False
                GunaLabelElite.Visible = False

                GunaTextBoxRefClient.Text = ""
                GunaTextBoxTelClient.Text = ""
                GunaTextBoxClientEmail.Text = ""
                GunaTextBoxCodeDeGroupe.Clear()
                GunaTextBoxCNI.Text = ""

                GunaTextBoxRefClient.Text = ""

                GunaTextBoxSiteWeb.Text = ""
                GunaTextBoxCodeElite.Text = ""
                GunaTextBoxNomPrenom.Text = ""
                GunaTextBoxTelClient.Clear()
                GunaTextBoxClientEmail.Text = ""
                GunaTextBoxCNI.Text = ""

                GunaTextBoxSiteWeb.Text = ""
                GunaTextBoxNomJeuneFille.Text = ""
                GunaTextBoxTypeClient.Text = ""
                GunaDateTimePickerDateNaissance.Value = Now()
                GunaTextBoxLieu.Text = ""
                GunaTextBoxNationalite.Text = ""
                GunaTextBoxPaysResidence.Text = ""
                GunaTextBoxProfession.Text = ""
                GunaTextBoxNumeroCompte.Text = ""
                GunaTextBoxRue.Text = ""
                GunaTextBoxVilleDeResidence.Text = ""
                GunaTextBoxModeTransport.Text = ""
                GunaTextBoxNumVehicule.Text = ""
                GunaTextBoxEntrepriseDuclient.Text = ""

                GunaTextBoxPaiement.Text = 0
                'GunaTextBoxAvance.Text = 0
                GunaTextBoxDepotDeGarantie.Text = 0
                GunaTextBoxMontantCaution.Text = 0

                'Aucun tableau d'autocompletion ne doit être visible
                setTableUsedForAutocompletionToFalse()

                'On masque les tarifs associés aux clients
                GunaComboBoxCodeTarif.Visible = False
                GunaLabelCodeTarif.Visible = False

                'GunaTextBoxMontantAccorde.Text = GunaTextBoxpPrixAffiche.Text

            End If

        End If

        GunaDataGridViewClient.Visible = True

        Dim Query As String = "SELECT NOM_PRENOM, EMAIL From client WHERE NOM_PRENOM LIKE '%" & GunaTextBoxNomPrenom.Text & "%' OR CODE_ELITE LIKE '%" & GunaTextBoxNomPrenom.Text & "%'"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaDataGridViewClient.DataSource = table
        Else
            GunaDataGridViewClient.Columns.Clear()
            GunaDataGridViewClient.Visible = False
        End If

        If GunaTextBoxNomPrenom.Text = "" Then
            GunaDataGridViewClient.Visible = False
        End If

        'reservationButtonToDisplay()

    End Sub

    'Upponc clicking a row on the values of the datagrid used for custom search of client
    Private Sub GunaDataGridViewClient_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewClient.CellClick

        GunaDataGridViewClient.Visible = False

        Dim row As DataGridViewRow

        row = Me.GunaDataGridViewClient.Rows(e.RowIndex)

        Dim query As String = "SELECT * FROM client WHERE NOM_PRENOM = @NOM_PRENOM AND EMAIL=@EMAIL"
        Dim adapter As New MySqlDataAdapter

        Dim table As New DataTable()
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = Trim(row.Cells("NOM_PRENOM").Value.ToString())
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = row.Cells("EMAIL").Value.ToString()

        adapter.SelectCommand = command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            'Gathering of some information concernit the client to be use later

            GlobalVariable.idClient = table.Rows(0)("ID_CLIENT").ToString
            GlobalVariable.codeClient = Trim(table.Rows(0)("CODE_CLIENT").ToString)
            GlobalVariable.codeCompteClient = table.Rows(0)("NUM_COMPTE").ToString

            GunaTextBoxNomPrenom.Text = Trim(row.Cells("NOM_PRENOM").Value.ToString())
            GunaTextBoxTelClient.Text = Trim(table.Rows(0)("TELEPHONE").ToString)
            GunaTextBoxClientEmail.Text = Trim(table.Rows(0)("EMAIL").ToString)
            GunaTextBoxCNI.Text = Trim(table.Rows(0)("CNI").ToString)
            GunaTextBoxRefClient.Text = Trim(Trim(table.Rows(0)("CODE_CLIENT").ToString))
            GunaTextBoxSiteWeb.Text = Trim(table.Rows(0)("SITE_INTERNET").ToString)
            GunaTextBoxNomJeuneFille.Text = Trim(table.Rows(0)("NOM_JEUNE_FILLE"))
            GunaTextBoxTypeClient.Text = Trim(table.Rows(0)("TYPE_CLIENT"))
            GunaDateTimePickerDateNaissance.Value = Trim(table.Rows(0)("DATE_DE_NAISSANCE"))
            GunaTextBoxLieu.Text = Trim(table.Rows(0)("LIEU_DE_NAISSANCE"))
            GunaTextBoxNationalite.Text = Trim(table.Rows(0)("NATIONALITE"))
            GunaTextBoxPaysResidence.Text = Trim(table.Rows(0)("PAYS_RESIDENCE"))
            GunaTextBoxProfession.Text = Trim(table.Rows(0)("PROFESSION"))
            GunaTextBoxNumeroCompte.Text = Trim(table.Rows(0)("NUM_COMPTE"))
            GunaTextBoxRue.Text = Trim(table.Rows(0)("ADRESSE"))
            GunaTextBoxVilleDeResidence.Text = table.Rows(0)("VILLE_DE_RESIDENCE")
            GunaTextBoxModeTransport.Text = table.Rows(0)("MODE_TRANSPORT")
            GunaTextBoxNumVehicule.Text = table.Rows(0)("NUM_VEHICULE")
            'GunaTextBoxCodeDeGroupe.Text = table.Rows(0)("CODE_ENTREPRISE")
            GunaTextBoxCodeEntrepriseDuClient.Text = table.Rows(0)("CODE_ENTREPRISE")

            If Trim(table.Rows(0)("CODE_ELITE")).Equals("") Then
                GunaLabelElite.Visible = False
                GunaTextBoxCodeElite.Visible = False
                GunaTextBoxCodeElite.Text = ""
            Else
                GunaLabelElite.Visible = True
                GunaTextBoxCodeElite.Visible = True
                GunaTextBoxCodeElite.Text = table.Rows(0)("CODE_ELITE")
            End If

            Dim Entreprise As DataTable = Functions.getElementByCode(table.Rows(0)("CODE_ENTREPRISE"), "client", "CODE_CLIENT")

            If Entreprise.Rows.Count > 0 Then

                GunaTextBoxEntrepriseDuclient.Text = Trim(Entreprise.Rows(0)("NOM_CLIENT"))

                GunaDataGridViewEntrepriseDuClient.Visible = False

            End If

            GunaDataGridViewRoom.Visible = False

            'Initialisation de la ville de depart
            'GunaTextBoxVenantDe.Text = GlobalVariable.AgenceActuelle.Rows(0)("VILLE")
            GunaTextBoxVenantDe.Text = table.Rows(0)("VILLE_DE_RESIDENCE")

            'Initialisation du nombre de personne

            'GunaTextBoxNbreAdulte.Text = 0
            'GunaTextBoxNbrePersonne.Text = GunaTextBoxNbreAdulte.Text

            If Not Trim(GunaTextBoxRefClient.Text).Equals("") Then
                gestionDesComptesDebiteurLorsDesReservationsIndividu(Trim(GunaTextBoxRefClient.Text))
            End If

        Else
            GunaTextBoxNomPrenom.Clear()
        End If

        'connect.closeConnection()

        setTableUsedForAutocompletionToFalse()

        'Managing the buttons to print at the level of the main form 
        reservationButtonToDisplay()

        'GunaDataGridViewEntrepriseDuClient.Visible = False

    End Sub

    'Adding a customer that doesn't exist in database for reservation from front desk
    Private Sub GunaButtonAjouterClient_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterClient.Click

        GlobalVariable.addUserFromFrontOffice = True

        ClientForm.Show()
        ClientForm.TopMost = True

    End Sub

    'Calculating the number of time to spend in hotel when departure date changes
    Private Sub GunaDateTimePickerDepart_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDepart.ValueChanged

        'We calculate the resting days or hours
        CalculatingRestDaysOrHours()

        'Displaying the right buttons on on date changes
        reservationButtonToDisplay()

    End Sub

    'Calculating the number of time to spend in hotel when arrival date changes
    Private Sub GunaDateTimePickerArrivee_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerArrivee.ValueChanged

        'SI ON NE TRAITE PAS LE DAY USE ALORS LA DATE D'ARRIVE NE DOIT JAMAIS ETRE EGALE A LA DATE DE DEPART
        If Not GunaCheckBoxDayUse.Checked Then

            'SEJOURS NORMAL

            If GunaDateTimePickerDepart.Value.ToShortDateString <= GunaDateTimePickerArrivee.Value.ToShortDateString Then
                GunaDateTimePickerDepart.Value = GunaDateTimePickerArrivee.Value.AddDays(1)
            End If

        Else

            'DAY USE

            'GunaDateTimePickerDepart.Value = GlobalVariable.DateDeTravail
            'GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail

        End If

        'We calculate the resting days or hours
        CalculatingRestDaysOrHours()

        'Displaying the right buttons on on date changes
        reservationButtonToDisplay()

    End Sub

    'Calculating the days to spend in hotel
    Private Sub CalculatingRestDaysOrHours()

        'GunaDateTimePickerDepart.Value = GlobalVariable.DateDeTravail.AddDays(1)

        'Le bouton gestion des heures n'etant pas cochet on ne peut pas permettre que la date d'arrivee = la date de sortie
        If GunaCheckBoxDayUse.Checked Then

            If Not (GunaDateTimePickerDepart.Value.ToShortDateString() = GunaDateTimePickerArrivee.Value.ToShortDateString()) Then
                GunaDateTimePickerDepart.Value = GunaDateTimePickerArrivee.Value
            End If

            'On passe de nuitées a heures

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTotalHeure.Text = "Nombre d'heure(s)"
                GunaLabelPrixParNuitee.Text = "Prix par heure"
            Else
                GunaLabelTotalHeure.Text = "Number of hour(s)"
                GunaLabelPrixParNuitee.Text = "Price per hour"
            End If

            If GlobalVariable.typeChambreOuSalle = "salle" Then
                'GunaDateTimePickerDepart.Value = GunaDateTimePickerArrivee.Value
            End If

        Else

            If GlobalVariable.typeChambreOuSalle = "chambre" Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaLabelTotalHeure.Text = "Nombre de nuitée(s)"
                    GunaLabelTempsAFaire.Text = "Total nuitée(s)"
                    GunaLabelPrixParNuitee.Text = "Prix par nuitée"
                Else
                    GunaLabelTotalHeure.Text = "Number of day(s)"
                    GunaLabelTempsAFaire.Text = "Total night(s)"
                    GunaLabelPrixParNuitee.Text = "Price per night"
                End If

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaLabelTotalHeure.Text = "Nombre de jour(s)"
                    GunaLabelTempsAFaire.Text = "Total Jour(s)"
                    GunaLabelPrixParNuitee.Text = "Prix par Jour"

                Else
                    GunaLabelTotalHeure.Text = "Number of days(s)"
                    GunaLabelTempsAFaire.Text = "Total day(s)"
                    GunaLabelPrixParNuitee.Text = "Price per day"

                End If

            End If

            If GunaDateTimePickerDepart.Value < GunaDateTimePickerArrivee.Value Then
                GunaTextBoxTempsAFaire.Text = 0
            Else
                ' Calculate the number of days to stay
                GunaTextBoxTempsAFaire.Text = CType((GunaDateTimePickerDepart.Value - GunaDateTimePickerArrivee.Value).TotalDays, Int32)

                If (CType(GunaTextBoxTempsAFaire.Text, Int32) <= 0) Then

                    GunaTextBoxTempsAFaire.Text = 1

                End If
            End If

        End If

        'Le nombre de jour total vaut le nombre de temps a faire calculé au niveau de la periode du séjour
        ReservationMoneyCalculation()

    End Sub

    'When ever the number of children or adulte changes we recalculate the number of people
    Private Sub GunaTextBoxNbreAdulte_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNbreAdulte.TextChanged

        Dim enfants As Integer = 0
        Dim adultes As Integer = 0
        Dim nombrePersonne As Integer = 0

        Integer.TryParse(GunaTextBoxNbreAdulte.Text, adultes)
        Integer.TryParse(GunaTextBoxNbreEnfant.Text, enfants)

        GunaTextBoxNbrePersonne.Text = adultes + enfants

    End Sub

    Private Sub GunaTextBoxNbreEnfant_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNbreEnfant.TextChanged

        Dim enfants As Integer = 0
        Dim adultes As Integer = 0
        Dim nombrePersonne As Integer = 0

        Integer.TryParse(GunaTextBoxNbreAdulte.Text, adultes)
        Integer.TryParse(GunaTextBoxNbreEnfant.Text, enfants)

        GunaTextBoxNbrePersonne.Text = adultes + enfants

    End Sub

    'A chaque changement de valeur du Cod client on rafraichi les calculs
    Private Sub GunaTextBoxRefClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefClient.TextChanged
        'A CHAQUE FOIS QUE CETTE VALEUR CHANGE ON DOIT VERIFIER SI IL N'EST PAS ASSOCIE A UNE ENTREPRISE
        ReservationMoneyCalculation()

        'lorsque la référence du client se remplit on determine le bouton a afficher
        reservationButtonToDisplay()

    End Sub

    'calculation for the amount to pay and amount paid for reservation
    Sub ReservationMoneyCalculation()

        Dim tempsAFaire As Integer = 0

        Dim nombreDeJourTotal As Integer
        Dim montantAccorde As Double
        Dim prixParNuitee As Double
        Dim prixRepas As Double
        Dim Total As Double
        Dim ServiceEtProduitSup As Double
        Dim montantARegler As Double
        Dim avance As Double
        Dim caution As Double

        Dim numberOfHoursDayOfUse = 0

        Dim montatComplet As Double = -1

        'GESTION DES TARIFS
        'ON DETERMINE SI ON A AFFECTE DES PRIX AUX CLIENT (TARIFS) PUIS ON AGIT SELON LE CAS DE FIGURE
        'Faudrait impérativement avoir le code client et le code de type de chambre ou salle ou article
        If (Not Trim(GunaTextBoxRefClient.Text).Equals("")) And (Not Trim(GunaTextBoxCodeTypeDeChambre.Text).Equals("")) Then

            Dim tarif As New Tarifs

            'ON SELECTIONNE L'ENSEMBLE DES TARIFS
            Dim ListOftarif As DataTable = tarif.SelectDistinctTarif()

            GunaComboBoxCodeTarif.DataSource = ListOftarif
            GunaComboBoxCodeTarif.ValueMember = "CODE_TARIF"
            GunaComboBoxCodeTarif.DisplayMember = "LIBELLE_TARIF"

            Dim TarifDuclientActuel As DataTable = Functions.TarifAppliqueAuClient(Trim(GunaTextBoxRefClient.Text), Trim(GunaTextBoxCodeTypeDeChambre.Text))

            Dim prixDuTarif As Double = 0

            If TarifDuclientActuel.Rows.Count > 0 Then

                If TarifDuclientActuel.Rows(0)("PRIX_TARIF_ENCOURS") = 0 Then

                    prixDuTarif = TarifDuclientActuel.Rows(0)("TARIF_PRIX1")

                Else

                    prixDuTarif = TarifDuclientActuel.Rows(0)("PRIX_TARIF_ENCOURS")

                End If

            End If

            If TarifDuclientActuel.Rows.Count > 0 Then

                If GunaRadioButtonSalleFete.Checked Then
                    GunaTextBoxMontantReelSalle.Text = Format(prixDuTarif, "#,##0")

                    GunaComboBoxCodeTarif.Visible = False
                    GunaLabelCodeTarif.Visible = False

                End If

            Else


            End If

            'GESTION DES DAY USE

        End If
        '----------------------------------------------------------------------------------

        If GunaRadioButtonSalleFete.Checked Then
            'CALCUL DU MONTANT LIE AUX SALES

            If Not (Double.TryParse(GunaTextBoxMontantReelSalle.Text.Trim(), montantAccorde) = 0) Then
                Double.TryParse(GunaTextBoxMontantReelSalle.Text.Trim(), montantAccorde)
            Else
                Double.TryParse(GunaTextBoxMontantAfficherSalle.Text.Trim(), montantAccorde)
            End If

            montatComplet = montantAccorde

            If GunaCheckBoxDayUse.Checked Then
                ' LOCATION DE LA SALLE POUR LA JOURNEE
                Total = montantAccorde
            Else
                'LOCATION DE LA SALLE SUR PLUSIEURS JOURS
                If Trim(GunaTextBoxTempsAFaire.Text).Equals("") Then
                    GunaTextBoxTempsAFaire.Text = 0
                End If
                Total = CType(GunaTextBoxTempsAFaire.Text, Int32) * montantAccorde
            End If

        End If

        'Block de paiment
        Double.TryParse(GunaTextBoxAvance.Text.Trim(), avance)
        Double.TryParse(GunaTextBoxMontantCaution.Text.Trim(), caution)

        'Derteminig the solde to display

        If Not GlobalVariable.codeReservationToUpdate = "" Then

            'Dim solde As Double = Double.Parse(Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate))
            Dim solde As Double = Double.Parse(Functions.SituationDeReservation(GunaLabelNumReservation.Text))
            GunaLabelSolde.Text = Format(solde, "#,##0")

            If 0 > solde Then
                GunaLabelSolde.ForeColor = Color.Red
            ElseIf solde = 0 Then
                GunaLabelSolde.ForeColor = Color.Black
            ElseIf solde > 0 Then
                GunaLabelSolde.ForeColor = Color.Green
            End If

        Else

            GunaLabelSolde.Text = 0

        End If

        '--------------------------
        'Information to be inserted into database after clicking enregistrer reservation
        GlobalVariable.MONTANT_ACCORDE = montantAccorde

        GlobalVariable.MONTANT_TOTAL = Total

        GlobalVariable.MONTANT_TOTAL_CAUTION = caution

        GlobalVariable.avance = avance

    End Sub

    'Determining which buttons to display at the front office
    Sub reservationButtonToDisplay()

        Dim tempAFaire As Double = 0
        Double.TryParse(GunaTextBoxTempsAFaire.Text, tempAFaire)

        If Not Trim(GunaTextBoxTempsAFaire.Text).Equals("") Then
            tempAFaire = GunaTextBoxTempsAFaire.Text
        End If

        Dim tempsAFaireSieste As Integer = 0

        'Integer.TryParse(GunaTextBoxTempsSieste.Text, tempsAFaireSieste)

        If Trim(GunaTextBoxCodeTypeDeChambre.Text).Equals("") Then

            GunaButtonReservation.Visible = False
            GunaButtonCheckIn.Visible = False
            GunaButtonCheckOut.Visible = False

        Else

            'If the client field is not empty and resting time is different from 0, we show the buttons
            If (Not (GunaTextBoxNomPrenom.Text.Trim().Equals("")) And Not tempAFaire = 0) Then

                'Out putting the buttons Enregistrer, Checkin

                'GESTION DES HEURES
                If (GunaDateTimePickerDepart.Value = GunaDateTimePickerArrivee.Value) And GunaCheckBoxDayUse.Checked Then

                    Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.SelectedItem

                    Dim DateTimeDepartStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureDepart.SelectedItem

                    Dim HeureArriveInRightFormat As DateTime = DateTime.ParseExact(DateTimeArriveeStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
                    Dim HeureDepartInRightFormat As DateTime = DateTime.ParseExact(DateTimeDepartStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)

                    'Dim HeureArriveInRightFormat As DateTime = CDate(GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.selectedItem)
                    'Dim HeureDepartInRightFormat As DateTime = CDate(GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.selectedItem)

                    If (HeureDepartInRightFormat < HeureArriveInRightFormat) Then

                        GunaTextBoxTempsAFaire.Text = 0

                        GunaButtonReservation.Visible = True
                        'Le bouton annuler n'est visible que sin on n'a deja enresgitré une résrevation
                        If Not GlobalVariable.codeReservationToUpdate = "" Then

                            Dim ETAT_RESERVATION As Integer = 1

                            If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                            End If
                            If ETAT_RESERVATION = 0 Then
                                GunaButtonAnnulerResa.Visible = True
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If
                        Else
                            GunaButtonAnnulerResa.Visible = False
                        End If

                        GunaButtonCheckOut.Visible = False
                        GunaButtonCheckIn.Visible = True

                    Else

                        If HeureDepartInRightFormat = HeureArriveInRightFormat Then

                            GunaButtonReservation.Visible = True
                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                Dim ETAT_RESERVATION As Integer = 1

                                If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                    ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                                End If
                                If ETAT_RESERVATION = 0 Then
                                    GunaButtonAnnulerResa.Visible = True
                                Else
                                    GunaButtonAnnulerResa.Visible = False
                                End If
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If
                            GunaButtonCheckOut.Visible = False
                            'we output the checkin button only it state is NON checkin not yet donne
                            If GlobalVariable.reserveConfCheckInState = "OUI" And GlobalVariable.reserveConfCheckOutState = 1 Then
                                GunaButtonCheckIn.Visible = False
                                'GunaButtonAnnulerReservation.Visible = True
                            Else
                                GunaButtonCheckIn.Visible = True
                                Dim ETAT_RESERVATION As Integer = 1

                                If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                    ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                                End If
                                If ETAT_RESERVATION = 0 Then
                                    GunaButtonAnnulerResa.Visible = True
                                Else
                                    GunaButtonAnnulerResa.Visible = False
                                End If
                            End If

                        ElseIf HeureArriveInRightFormat <= HeureDepartInRightFormat Then

                            'Gestion du checkout

                            Dim solde As Double = 0

                            Double.TryParse(GunaLabelSolde.Text, solde)

                            GunaButtonReservation.Visible = True
                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                Dim ETAT_RESERVATION As Integer = 1

                                If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                    ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                                End If
                                If ETAT_RESERVATION = 0 Then
                                    GunaButtonAnnulerResa.Visible = True
                                Else
                                    GunaButtonAnnulerResa.Visible = False
                                End If
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If
                            'If GlobalVariable.reserveConfCheckInState = "OUI" And GlobalVariable.reserveConfCheckOutState = 1 And solde >= 0 Then'
                            'GlobalVariable.reserveConfCheckOutState is ETAT_CONFIRMATION
                            'We can't checkout what has not been checked in and checkout what has already been checked out
                            If GlobalVariable.reserveConfCheckInState = "OUI" And GlobalVariable.reserveConfCheckOutState = 1 Then
                                GunaButtonCheckOut.Visible = True
                                GunaButtonCheckIn.Visible = False
                            Else
                                GunaButtonCheckOut.Visible = False
                                GunaButtonCheckIn.Visible = True
                            End If

                        Else

                            GunaButtonReservation.Visible = True

                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                Dim ETAT_RESERVATION As Integer = 1

                                If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                    ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                                End If
                                If ETAT_RESERVATION = 0 Then
                                    GunaButtonAnnulerResa.Visible = False
                                End If
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If

                            GunaButtonCheckOut.Visible = False
                            GunaButtonCheckIn.Visible = False

                        End If

                    End If

                Else

                    'GESTION DES DATES
                    If (GunaDateTimePickerDepart.Value < GunaDateTimePickerArrivee.Value) Then

                        GunaTextBoxTempsAFaire.Text = 1
                        GunaButtonReservation.Visible = False
                        'Le bouton annuler n'est visible que sin on n'a deja enresgitré une résrevation
                        If Not GlobalVariable.codeReservationToUpdate = "" Then
                            Dim ETAT_RESERVATION As Integer = 1

                            If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                            End If
                            If ETAT_RESERVATION = 0 Then
                                GunaButtonAnnulerResa.Visible = True
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If
                        Else
                            GunaButtonAnnulerResa.Visible = False
                        End If

                        GunaButtonCheckOut.Visible = False
                        GunaButtonCheckIn.Visible = False

                    Else

                        If GunaDateTimePickerArrivee.Value.ToShortDateString() = GlobalVariable.DateDeTravail.ToShortDateString() Then

                            GunaButtonReservation.Visible = True
                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                Dim ETAT_RESERVATION As Integer = 1

                                If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                    ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                                End If
                                If ETAT_RESERVATION = 0 Then
                                    GunaButtonAnnulerResa.Visible = True
                                Else
                                    GunaButtonAnnulerResa.Visible = False
                                End If
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If

                            'GunaButtonCheckOut.Visible = False
                            'we output the checkin button only it state is NON checkin not yet donne
                            If GlobalVariable.reserveConfCheckInState = "OUI" And GlobalVariable.reserveConfCheckOutState = 1 Then
                                GunaButtonCheckIn.Visible = False

                                If GlobalVariable.DateDeTravail.ToShortDateString() = GunaDateTimePickerDepart.Value.ToShortDateString() Then
                                    GunaButtonCheckOut.Visible = True
                                Else
                                    GunaButtonCheckOut.Visible = False
                                End If

                            Else
                                GunaButtonCheckIn.Visible = True
                            End If

                        ElseIf GlobalVariable.DateDeTravail.ToShortDateString() = GunaDateTimePickerDepart.Value.ToShortDateString() Then
                            'Permet a ce que l'ont puisse effectuer le checkout au bon moment et meme longtemps apres que la date soit passe
                            'Gestion du checkout
                            Dim solde As Double = 0

                            Double.TryParse(GunaLabelSolde.Text, solde)

                            GunaButtonReservation.Visible = True
                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                Dim ETAT_RESERVATION As Integer = 1

                                If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                    ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                                End If
                                If ETAT_RESERVATION = 0 Then
                                    GunaButtonAnnulerResa.Visible = True
                                Else
                                    GunaButtonAnnulerResa.Visible = False
                                End If
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If

                            'If GlobalVariable.reserveConfCheckInState = "OUI" And GlobalVariable.reserveConfCheckOutState = 1 And solde >= 0 Then'
                            'GlobalVariable.reserveConfCheckOutState is ETAT_CONFIRMATION
                            'We can't checkout what has not been checked in and checkout what has already been checked out

                            If GlobalVariable.reserveConfCheckInState = "OUI" And GlobalVariable.reserveConfCheckOutState = 1 Then
                                GunaButtonCheckOut.Visible = True
                            Else
                                GunaButtonCheckOut.Visible = False
                            End If

                            GunaButtonCheckIn.Visible = False

                        ElseIf GunaDateTimePickerDepart.Value.ToShortDateString() < GlobalVariable.DateDeTravail.ToShortDateString() Then
                            'Permet a ce que l'ont puisse effectuer le checkout au bon moment et meme longtemps apres que la date soit passe
                            'Gestion du checkout
                            Dim solde As Double = 0

                            Double.TryParse(GunaLabelSolde.Text, solde)

                            GunaButtonReservation.Visible = True
                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                Dim ETAT_RESERVATION As Integer = 1

                                If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                    ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                                End If

                                If ETAT_RESERVATION = 0 Then
                                    GunaButtonAnnulerResa.Visible = True
                                Else
                                    GunaButtonAnnulerResa.Visible = False
                                End If
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If

                            'If GlobalVariable.reserveConfCheckInState = "OUI" And GlobalVariable.reserveConfCheckOutState = 1 And solde >= 0 Then'
                            'GlobalVariable.reserveConfCheckOutState is ETAT_CONFIRMATION
                            'We can't checkout what has not been checked in and checkout what has already been checked out

                            If GlobalVariable.reserveConfCheckInState = "OUI" And GlobalVariable.reserveConfCheckOutState = 1 Then
                                GunaButtonCheckOut.Visible = True
                            Else
                                GunaButtonCheckOut.Visible = False
                            End If

                            GunaButtonCheckIn.Visible = False

                        Else

                            GunaButtonReservation.Visible = True

                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                Dim ETAT_RESERVATION As Integer = 1

                                If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows.Count > 0 Then
                                    ETAT_RESERVATION = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION").Rows(0)("ETAT_RESERVATION")
                                End If
                                If ETAT_RESERVATION = 0 Then
                                    GunaButtonAnnulerResa.Visible = True
                                Else
                                    GunaButtonAnnulerResa.Visible = False
                                End If
                            Else
                                GunaButtonAnnulerResa.Visible = False
                            End If

                            GunaButtonCheckOut.Visible = False
                            GunaButtonCheckIn.Visible = False

                        End If

                    End If

                End If

                'Else Client field empty we hide the buttons Enregistrer, Checkin, checkout
            Else

                GunaButtonReservation.Visible = False
                GunaButtonAnnulerResa.Visible = False
                'GunaButtonCheckOut.Visible = False
                GunaButtonCheckIn.Visible = False

            End If

        End If
        'Si la réservation est dans reserve_conf on ne peut plus l'annuler via le bouton annuler mais en faisant un checkout
        If Not GlobalVariable.codeReservationToUpdate = "" Then
            If Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION").Rows.Count > 0 Then
                GunaButtonAnnulerResa.Visible = False
            End If
        End If

        TimerToRefreshClock.Start()

    End Sub

    '-------------------------------------- RESERVATION SAVING -----------------------------------------------

    Public Sub cautionEnregistrement(ByVal CODE_RESERVATION As String, ByVal DEBIT As Double, ByVal CREDIT As Double, ByVal TYPE As Integer)

        Dim resa As New Reservation()

        Dim caution As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_RESERVATION, "caution", "CODE_RESERVATION", TYPE, "TYPE")

        Dim CODE_CAUTION As String = Functions.GeneratingRandomCodePanne("caution", "DG")

        If Trim(GunaTextBoxMontantCaution.Text) = "" Then
            GunaTextBoxMontantCaution.Text = 0
        End If

        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim NOM_CLIENT As String = Trim(GunaTextBoxNomPrenom.Text)

        If caution.Rows.Count > 0 Then
            'LE CODE EXISTE DEJA ALORS ON SAUVEGARDE
            DEBIT = caution.Rows(0)("DEBIT")
            Dim MONTANT_CAUTION As Double = CREDIT
            CODE_CAUTION = caution.Rows(0)("CODE_CAUTION")
            Dim ETAT_DEPOT As String = caution.Rows(0)("ETAT_DEPOT")

            If MONTANT_CAUTION > 0 Then
                resa.updateCaution(CODE_CAUTION, CODE_RESERVATION, DEBIT, CREDIT, CODE_UTILISATEUR_CREA, TYPE, ETAT_DEPOT)
            End If

        Else

            If CREDIT > 0 Then
                'LE CODE N'EXISTE PAS ALORS ON INSERE
                Dim ETAT_DEPOT As String = "Affecté"
                If GlobalVariable.actualLanguageValue = 0 Then
                    ETAT_DEPOT = "Affected"
                End If
                resa.insertionCaution(CODE_CAUTION, CODE_RESERVATION, DEBIT, CREDIT, DATE_CREATION, CODE_UTILISATEUR_CREA, TYPE, ETAT_DEPOT, NOM_CLIENT)
            End If

        End If

    End Sub

    'Saving a reservation
    Private Sub GunaButtonReservation_Click(sender As Object, e As EventArgs) Handles GunaButtonReservation.Click

        Dim facturationAutoApresPronlongementDeSejour As Boolean = False

        'On doit vérifier que la date de sortie n'est jamais inférieure a la date de travail
        Dim dayDiff = CType((GlobalVariable.DateDeTravail - GunaDateTimePickerDepart.Value).TotalDays, Int32)

        If dayDiff > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir vérifier la date de départ", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please check the departure date", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            If GunaComboBoxSourceReservation.SelectedIndex = -1 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Bien vouloir choisir une source de réservation", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Please select a reservation source", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else

                If Not GunaTextBoxNbrePersonne.Text > 0 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bien vouloir indiquer le nombre de personne", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Please indicate the Number of Pax", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Else

                    Dim envoieConfirmationDeReservation As Boolean = False

                    Dim WHATSAPP_OU_EMAIL As Integer
                    'WHATSAPP_OU_EMAIL = 0 'WHATSAPP
                    'WHATSAPP_OU_EMAIL = 1 'EMAIL

                    Dim SEND_WHATSAP As Boolean = False
                    Dim SEND_MAIL As Boolean = False
                    Dim ARG_ACTION As Integer
                    Dim EMAIL As String = Trim(GunaTextBoxClientEmail.Text)

                    If Trim(GunaButtonReservation.Text).Equals("Réserver") Or Trim(GunaButtonReservation.Text).Equals("Booking") Then

                        envoieConfirmationDeReservation = True
                        'GunaRadioButtonWhatsAppOui.Checked = False
                        'GunaRadioButtonWhatsAppNon.Checked = True

                        '---------------------------------------------------------------

                        If GunaRadioButtonWhatsAppOui.Checked Then

                            SEND_WHATSAP = True

                            'ON DOIT DETERMINER LE DOCUMENT ENVOYE

                            If GlobalVariable.typeChambreOuSalle = "salle" Then

                                If GunaComboBoxTypeDeDocSalle.SelectedIndex = 0 Then
                                    ARG_ACTION = 1
                                ElseIf GunaComboBoxTypeDeDocSalle.SelectedIndex = 1 Then
                                    ARG_ACTION = 2
                                End If

                            ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then
                                ARG_ACTION = 3
                            End If

                        End If

                        '-----------------------------------------------------

                        If GunaRadioButtonMailOui.Checked Then

                            If Not Trim(EMAIL).Equals("") And EMAIL.Length > 10 Then

                                SEND_MAIL = True

                                'ON DOIT DETERMINER LE DOCUMENT A ENVOYER

                                If GlobalVariable.typeChambreOuSalle = "salle" Then
                                    If GunaComboBoxTypeDeDocSalle.SelectedIndex = 0 Then
                                        ARG_ACTION = 1
                                    ElseIf GunaComboBoxTypeDeDocSalle.SelectedIndex = 1 Then
                                        ARG_ACTION = 2
                                    End If

                                ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then
                                    ARG_ACTION = 3
                                End If

                            End If

                        End If
                        '---------------------------------------------------------------

                    End If

                    Dim CODE_RESERVATION_DEPART As String = GunaLabelNumReservation.Text
                    Dim CHAMBRE_DEPART As String = GunaTextBoxNumeroChambre.Text

                    Dim resaExist As DataTable = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reserve_conf", "CODE_RESERVATION")

                    Dim exist_reserve_conf As Boolean = False
                    Dim exist_reservation As Boolean = False
                    Dim exist As Boolean = False

                    If resaExist.Rows.Count > 0 Then
                        exist_reserve_conf = True
                        exist = True
                    Else
                        resaExist = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reservation", "CODE_RESERVATION")

                        If resaExist.Rows.Count > 0 Then
                            exist_reservation = True
                            exist = True
                        End If

                    End If

                    Dim messageDeConfirmation As String = ""
                    GlobalVariable.duplicationDeReservation = False

                    'DAY USE ou SEJOURS

                    '---------------------------------------- 

                    'DEBUT ON SE RASSURE QUE LE NUMERO DE CHAMBRE N'EST PAS VIDE OU EXISTE VRAIMENT -------------------------------------

                    Dim continuer As Boolean = False

                    Dim dialog01 As DialogResult

                    Dim message As String = ""

                    If Trim(GunaTextBoxNumeroChambre.Text).Equals("") Or Trim(GunaTextBoxNumeroChambre.Text).Equals("-") Then

                        'SI LA CHAMBRE EST VIDE ET QUE ON TRAITE UN CHECKIN ON NE DOIT PAS POUVOIR CONTINUER
                        If exist_reserve_conf Then
                            continuer = False

                            If GlobalVariable.actualLanguageValue = 1 Then
                                message = "Bien vouloir saisir un numéro de chambre valide !!"
                            Else
                                message = "Please type in a valide room number !!"
                            End If

                        Else
                            continuer = True

                        End If

                    Else

                        Dim roomInfoSuo As DataTable = Functions.getElementByCode(GunaTextBoxNumeroChambre.Text, "chambre", "CODE_CHAMBRE")

                        If roomInfoSuo.Rows.Count > 0 Then
                            continuer = True
                        Else

                            If GlobalVariable.actualLanguageValue = 1 Then
                                message = "Bien vouloir saisir un numéro de chambre valide !!"
                            Else
                                message = "Please type in a valide room number !!"
                            End If

                        End If

                    End If

                    Dim shortMessage As String = ""

                    If Not exist Then

                        If GlobalVariable.actualLanguageValue = 1 Then
                            shortMessage = "Réserver"
                        Else
                            shortMessage = "Booking"
                        End If

                    Else

                        If GlobalVariable.actualLanguageValue = 1 Then
                            shortMessage = "Enregistrement"
                        Else
                            shortMessage = "Save"
                        End If

                    End If

                    If Not continuer Then
                        dialog01 = MessageBox.Show(message, shortMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    'END ON SE RASSURE QUE LE NUMERO DE CHAMBRE N'EST PAS VIDE OU EXISTE VRAIMENT -------------------------------------

                    If continuer Then

                        '----------------------------------------

                        If GunaCheckBoxDayUse.Checked Then

                            If GlobalVariable.typeChambreOuSalle = "chambre" Then
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Type de Chambre : " & GunaTextBoxLibelleTYpe.Text & "; N° Chambre : " & GunaTextBoxNumeroChambre.Text & Chr(13) & " Durée : " & GunaComboBoxHeureArrivee.SelectedItem.ToString & " - " & GunaComboBoxHeureDepart.SelectedItem.ToString & " soit (" & GunaTextBoxTempsAFaire.Text & ") Heure(s)" & Chr(13) & "Tarif réel : " & GunaTextBoxMontantAccorde.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                                Else
                                    messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Room Type : " & GunaTextBoxLibelleTYpe.Text & "; Room N° : " & GunaTextBoxNumeroChambre.Text & Chr(13) & " Period : " & GunaComboBoxHeureArrivee.SelectedItem.ToString & " - " & GunaComboBoxHeureDepart.SelectedItem.ToString & " For (" & GunaTextBoxTempsAFaire.Text & ") Hour(s)" & Chr(13) & "real Price : " & GunaTextBoxMontantAccorde.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                                End If
                            Else
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Type de Salle : " & GunaTextBoxLibelleTYpe.Text & "; Salle : " & GunaTextBoxNumeroChambre.Text & Chr(13) & " Durée : " & GunaComboBoxHeureArrivee.SelectedItem.ToString & " - " & GunaComboBoxHeureDepart.SelectedItem.ToString & " soit (" & GunaTextBoxTempsAFaire.Text & ") Heure(s)" & Chr(13) & "Tarif réel : " & GunaTextBoxMontantReelSalle.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                                Else
                                    messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Hall Type : " & GunaTextBoxLibelleTYpe.Text & "; Hall : " & GunaTextBoxNumeroChambre.Text & Chr(13) & " Period : " & GunaComboBoxHeureArrivee.SelectedItem.ToString & " - " & GunaComboBoxHeureDepart.SelectedItem.ToString & " For (" & GunaTextBoxTempsAFaire.Text & ") Hour(s)" & Chr(13) & "Real Price : " & GunaTextBoxMontantReelSalle.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                                End If
                            End If

                        Else

                            If GunaRadioButtonSalleFete.Checked Then

                                'GESTION DES SALLES
                                Dim nomEvent As String = ""

                                Dim infoSupEvent As DataTable = Functions.getElementByCode(GunaComboBoxEvenement.SelectedValue.ToString, "evenement", "CODE_EVENEMENT")

                                If infoSupEvent.Rows.Count > 0 Then
                                    nomEvent = infoSupEvent.Rows(0)("LIBELLE")
                                End If

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Type de Salle: " & GunaTextBoxLibelleTYpe.Text & "; Salle : " & GunaTextBoxNumeroChambre.Text & Chr(13) & "Pour : " & nomEvent & Chr(13) & "Période : " & GunaDateTimePickerArrivee.Value.ToShortDateString & " - " & GunaDateTimePickerDepart.Value.ToShortDateString & " soit (" & GunaTextBoxTempsAFaire.Text & ") Jour(s)" & Chr(13) & "Tarif réel : " & GunaTextBoxMontantReelSalle.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                                Else
                                    messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Party Hall type : " & GunaTextBoxLibelleTYpe.Text & "; Hall : " & GunaTextBoxNumeroChambre.Text & Chr(13) & "For  : " & nomEvent & Chr(13) & "Period : " & GunaDateTimePickerArrivee.Value.ToShortDateString & " - " & GunaDateTimePickerDepart.Value.ToShortDateString & " for (" & GunaTextBoxTempsAFaire.Text & ") Days(s)" & Chr(13) & "Real Price : " & GunaTextBoxMontantReelSalle.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                                End If

                            End If

                        End If

                        Dim messageTitre As String = ""

                        If Not exist Then
                            If GlobalVariable.actualLanguageValue = 1 Then
                                messageTitre = "Confirmation de Réservation"
                            Else
                                messageTitre = "Booking Confirmation"
                            End If
                        Else
                            If GlobalVariable.actualLanguageValue = 1 Then
                                messageTitre = "Enregistrement de Réservation"
                            Else
                                messageTitre = "Booking Saving"
                            End If
                        End If

                        Dim dialogEnregistrerReserver As DialogResult = MessageBox.Show(messageDeConfirmation, messageTitre, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                        If dialogEnregistrerReserver = DialogResult.OK Then

                            Me.Cursor = Cursors.WaitCursor

                            GlobalVariable.duplicationDeReservation = False

                            Dim CODE_TARIF_RESERVATION As String = ""

                            If GlobalVariable.tarificationDynamiqueActif Then

                                If GunaComboBoxCodeTarif.SelectedIndex >= 0 Then

                                    If GunaComboBoxCodeTarif.Visible Then
                                        CODE_TARIF_RESERVATION = GunaComboBoxCodeTarif.SelectedValue.ToString()
                                    End If

                                End If

                            End If

                            Dim BC_ENTREPRISE As String = GunaTextBoxBC.Text
                            Dim TELEPHONE_CLIENT As String = Trim(GunaTextBoxTelClient.Text)

                            Dim solde As Double = 0

                            Double.TryParse(GunaLabelSolde.Text, solde)

                            If 0 > solde Then
                                GunaLabelSolde.ForeColor = Color.Red
                            ElseIf 0 = solde Then
                                GunaLabelSolde.ForeColor = Color.Black
                            ElseIf solde > 0 Then
                                GunaLabelSolde.ForeColor = Color.Green
                            End If

                            'GunaLabelNumReservation.Visible = False 'We hide reservation code

                            'Insertion de donnees dans la table reservation

                            Dim TYPE_CHAMBRE_OU_SALLE As String = "salle"

                            If GunaRadioButtonMailOui.Checked Then
                                GlobalVariable.RECEVOIR_EMAIL = 1
                            Else
                                GlobalVariable.RECEVOIR_EMAIL = 0
                            End If

                            If GunaRadioButtonWhatsAppOui.Checked Then
                                GlobalVariable.RECEVOIR_SMS = 1
                            Else
                                GlobalVariable.RECEVOIR_SMS = 0
                            End If

                            'Dim CLIENT_ID As String = GlobalVariable.codeClient

                            Dim CLIENT_ID As String = GunaTextBoxRefClient.Text
                            Dim UTILISATEUR_ID As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                            Dim CHAMBRE_ID As String = ""

                            If Not Trim(GunaTextBoxNumeroChambre.Text) = "" Then
                                CHAMBRE_ID = Trim(GunaTextBoxNumeroChambre.Text)
                            Else
                                CHAMBRE_ID = "-"
                            End If

                            Dim AGENCE_ID As String = GlobalVariable.codeAgence
                            Dim NOM_CLIENT As String = Trim(GunaTextBoxNomPrenom.Text)

                            'ROUTAGE PETIT DEJEUNER
                            Dim PETIT_DEJEUNER_ROUTAGE As Double = 0

                            If GunaCheckBoxPetitDejRoutage.Checked Then
                                Dim pdjRoutage As Double = 0
                                Double.TryParse(GunaTextBoxPetitDejeunerRoutage.Text, pdjRoutage)
                                PETIT_DEJEUNER_ROUTAGE = pdjRoutage
                            End If

                            'ROUTAGE LOGEMENT
                            Dim CHAMBRE_ROUTAGE As String = ""

                            If GunaCheckBoxChambreRoutage.Checked Then

                                If GunaComboBoxChambreRoutage.SelectedIndex >= 0 Then
                                    CHAMBRE_ROUTAGE = GunaComboBoxChambreRoutage.SelectedValue.ToString

                                End If

                            End If

                            Dim ETAT_NOTE_RESERVATION As String = ""

                            If Trim(LabelNatureReservation.Text) = "" Then
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    ETAT_NOTE_RESERVATION = "ATTENDUE"
                                Else
                                    ETAT_NOTE_RESERVATION = "EXPECTED"
                                End If
                            Else
                                ETAT_NOTE_RESERVATION = Trim(LabelNatureReservation.Text)
                            End If

                            Dim CODE_RESERVATION = GunaLabelNumReservation.Text

                            If Trim(GunaButtonReservation.Text).Equals("Réserver") Or Trim(GunaButtonReservation.Text).Equals("Booking") Then
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    ETAT_NOTE_RESERVATION = "ATTENDUE"
                                Else
                                    ETAT_NOTE_RESERVATION = "EXPECTED"
                                End If

                            End If

                            Dim ROUTAGE As String = ""

                            If GlobalVariable.actualLanguageValue = 1 Then
                                ROUTAGE = "NON"
                            Else
                                ROUTAGE = "NO"
                            End If

                            If GunaCheckBoxChambreRoutage.Checked Then
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    ROUTAGE = "OUI"
                                Else
                                    ROUTAGE = "YES"
                                End If
                            End If

                            Dim SOURCE_RESERVATION As String = ""

                            If GunaComboBoxSourceReservation.SelectedIndex >= 0 Then
                                SOURCE_RESERVATION = GunaComboBoxSourceReservation.SelectedValue.ToString
                            End If

                            Dim VENANT_DE As String = GunaTextBoxVenantDe.Text
                            Dim SE_RENDANT_A As String = GunaTextBoxSerendantA.Text
                            Dim RAISON As String = GunaComboBoxTypeReservation.SelectedItem.ToString

                            If Trim(GunaTextBoxPetitDejeuner.Text) = "" Then
                                GunaTextBoxPetitDejeuner.Text = 0
                            End If

                            Dim PETIT_DEJEUNER As Double = GunaTextBoxPetitDejeuner.Text

                            Dim BFK_COST As Double = 0
                            If Not Trim(GunaTextBoxBreakFastCost.Text).Equals("") Then
                                BFK_COST = GunaTextBoxBreakFastCost.Text
                            End If
                            '----------------- dates obtained when ever the resting days change----------------------------------
                            'Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.SelectedItem

                            'Dim DateTimeDepartStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureDepart.SelectedItem

                            '-------------------------- DAY USE MANAGEMENT ---------------------------------
                            Dim DAY_USE As Integer = 0

                            If GunaCheckBoxDayUse.Checked Then
                                DAY_USE = 1
                            End If

                            Dim MENSUEL As Integer = 0

                            Dim ETAT As Integer = 0 'gratuitee_de_resa
                            If GunaCheckBoxGratuitee.Checked Then
                                ETAT = 1
                            End If
                            Functions.updateOfFields("gratuitee_de_resa", "ETAT", ETAT, "CODE_RESERVATION", CODE_RESERVATION, 1)
                            '--------------------------------- GESTION DU DAY USE -----------------------------------------

                            '----------------------------------------------------------------------------------------------

                            Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") & " " & GunaComboBoxHeureArrivee.SelectedItem

                            Dim DateTimeDepartStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") & " " & GunaComboBoxHeureDepart.SelectedItem

                            '-------------------------------------
                            Dim DateTimeArrivee As DateTime = DateTime.ParseExact(DateTimeArriveeStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
                            Dim DateTimeDepart As DateTime = DateTime.ParseExact(DateTimeDepartStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)

                            'Dim DATE_ENTTRE As Date = GlobalVariable.DATE_ENTTRE
                            Dim DATE_ENTTRE As Date = GunaDateTimePickerArrivee.Value.ToShortDateString
                            Dim HEURE_ENTREE As String = DateTimeArrivee
                            'Dim DATE_SORTIE As Date = GlobalVariable.DATE_SORTIE
                            Dim DATE_SORTIE As Date = GunaDateTimePickerDepart.Value.ToShortDateString
                            Dim HEURE_SORTIE As String = DateTimeDepart

                            Dim ADULTES As Integer = GunaTextBoxNbreAdulte.Text
                            Dim ENFANTS As Integer = GunaTextBoxNbreEnfant.Text
                            'Dim NB_PERSONNES As Integer = ENFANTS + ADULTES

                            If Trim(GunaTextBoxNbrePersonne.Text) = "" Then
                                GunaTextBoxNbrePersonne.Text = 0
                            End If

                            If Trim(GunaTextBoxMontantCaution.Text) = "" Then
                                GunaTextBoxMontantCaution.Text = 0
                            End If

                            Dim NB_PERSONNES As Integer = GunaTextBoxNbrePersonne.Text
                            Dim RECEVOIR_EMAIL As Integer = GlobalVariable.RECEVOIR_EMAIL
                            Dim RECEVOIR_SMS As Integer = GlobalVariable.RECEVOIR_SMS
                            Dim ETAT_RESERVATION As Integer = 0
                            Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
                            Dim HEURE_CREATION As DateTime = DateTime.Now().ToString("hh:mm:ss")
                            Dim MONTANT_TOTAL_CAUTION As Double = GunaTextBoxMontantCaution.Text
                            Dim MOTIF_ETAT As String = ""
                            Dim DATE_ETAT As Date = GlobalVariable.DateDeTravail
                            'Dim MONTANT_ACCORDE As Double = GlobalVariable.MONTANT_ACCORDE
                            Dim MONTANT_ACCORDE As Double = 0

                            'RECALCUL DU MONTANT POUR LES DAY USE

                            Dim DEBUT_HEURE As Date = CDate(DateTimeArrivee).ToShortTimeString
                            Dim FIN_HEURE As Date = CDate(DateTimeDepart).ToShortTimeString

                            Dim NOMBRE_HEURE As Integer = 1

                            If GunaCheckBoxDayUse.Checked Then
                                NOMBRE_HEURE = CType((FIN_HEURE - DEBUT_HEURE).TotalHours, Int32)
                            End If

                            If GlobalVariable.typeChambreOuSalle = "salle" Then
                                If Not Trim(GunaTextBoxMontantReelSalle.Text) = "" Then
                                    MONTANT_ACCORDE = Double.Parse(GunaTextBoxMontantReelSalle.Text) * NOMBRE_HEURE
                                End If
                            ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then
                                If Not Trim(GunaTextBoxMontantAccorde.Text) = "" Then
                                    MONTANT_ACCORDE = Double.Parse(GunaTextBoxMontantAccorde.Text) * NOMBRE_HEURE
                                End If
                            End If

                            Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxCodeEntrepriseDuClient.Text)
                            Dim NOM_ENTREPRISE As String = Trim(GunaTextBoxEntrepriseDuclient.Text)

                            Dim GROUPE As String = GunaTextBoxCodeDeGroupe.Text

                            'RESERVATION DE GROUPE

                            'Dim CODE_RESERVATION = Functions.GeneratingRandomCodeWithSpecifications("reservation", "RESA")

                            Dim reservation As New Reservation()
                            Dim mainCourante As New MainCourantes()
                            Dim reglement As New Reglement()
                            Dim occupationChambre As New OccupationChambre()
                            Dim facture As New Facture()
                            Dim ligneFacture As New LigneFacture()
                            Dim compte As New Compte()
                            Dim caisse As New Caisse()

                            '------------------------------- REGLEMENT ----------------------------------------------

                            If GunaTextBoxDepotDeGarantie.Text = "" Then
                                GunaTextBoxDepotDeGarantie.Text = 0
                            End If

                            Dim DEPOT_DE_GARANTIE As Double = Double.Parse(GunaTextBoxDepotDeGarantie.Text)

                            Dim NUM_FACTURE As String = ""
                            Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                            Dim montantVerse As Double = 0
                            Double.TryParse(GunaTextBoxAvance.Text, montantVerse)
                            Dim MONTANT_VERSE As Double = montantVerse
                            Dim DATE_REGLEMENT As Date = GlobalVariable.DateDeTravail
                            Dim MODE_REGLEMENT As String = ""
                            Dim REF_REGLEMENT As String = ""

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MODE_REGLEMENT = "Garantie"
                                REF_REGLEMENT = "DEPOT DE GARANTIE DE " & "[" & NOM_CLIENT & " / " & CHAMBRE_ID & "]"
                            Else
                                MODE_REGLEMENT = "Guarantee"
                                REF_REGLEMENT = "GURANTEE DEPOSIT OF " & "[" & NOM_CLIENT & " / " & CHAMBRE_ID & "]"
                            End If

                            Dim CODE_MODE As String = ""
                            Dim IMPRIMER As Double = 0

                            Dim NUMERO_BLOC_NOTE = ""
                            Dim MODE_REG_INFO_SUP_1 = ""
                            Dim MODE_REG_INFO_SUP_2 = ""
                            Dim MODE_REG_INFO_SUP_3 = ""

                            Dim CODE_CLIENT As String = Trim(GunaTextBoxRefClient.Text)
                            Dim CODE_AGENCE As String = AGENCE_ID

                            Dim CODE_MAIN_COURANTE_JOURNALIERE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante_journaliere", "MCJ")

                            Dim TYPE_CHAMBRE As String = GunaTextBoxCodeTypeDeChambre.Text
                            'ON MET AJOUR LE MONTANT DU SOLDE LIE A LA RESERVATION

                            Dim updatedSolde As Double = 0

                            Dim POSTER_TAX As Double = 0 'TAUX_OCCUPATION_PCT USED AS TAXE DE SEJOUR

                            'Inserting a new reservation after checking that the reservation does not already exist
                            If True Then

                                ' variables declarations 

                                '-------------------------------- OCCUPATION CHAMBRE ------------------------------

                                Dim CODE_OCCUPATION_CHAMBRE = Functions.GeneratingRandomCodeWithSpecifications("occupation_chambre", "")
                                Dim MONTANT_HT As Double = MONTANT_ACCORDE
                                Dim TAXE As Double = 0
                                Dim MONTANT_TTC As Double = 0
                                Dim DATE_OCCUPATION As Date = DATE_ENTTRE
                                'Dim OBSERVATIONS As String = ""
                                Dim COMMENTAIRE1 As String = ""
                                Dim COMMENTAIRE2 As String = ""
                                Dim COMMENTAIRE3 As String = ""
                                Dim COMMENTAIRE4 As String = ""
                                Dim DATE_LIBERATION As Date = DATE_SORTIE
                                Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                Dim DATE_PREMIERE_ARRIVEE As Date = DATE_ENTTRE
                                Dim TYPE_RESERVATION As String = ""
                                Dim PDJ_INCLUS As String = ""
                                Dim TAXE_SEJOURS_INCLUS As String = ""
                                Dim TVA_INCLUS As String = ""
                                Dim CODE_CLIENT_REEL As String = CLIENT_ID

                                '----------- MAIN COURANTES ------------------------------
                                Dim CODE_MAIN_COURANTE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante", "MC")

                                'Dim CODE_CLIENT As String = GlobalVariable.codeClient


                                CLIENT_ID = Trim(GunaTextBoxRefClient.Text)

                                Dim CODE_CHAMBRE As String = GlobalVariable.codeChambre
                                Dim ETAT_CHAMBRE As String = 0


                                '----------- MAIN COURANTE GENERALE ------------------------------

                                Dim TAUX_OCCUPATION_PCT As Double = 0 'TAUX_OCCUPATION_PCT USED AS TAXE DE SEJOUR


                                If GunaCheckBoxTaxeSejour.Checked Then
                                    If Not Trim(GunaTextBoxTaxeSejour.Text).Equals("") Then
                                        TAUX_OCCUPATION_PCT = GunaTextBoxTaxeSejour.Text
                                        POSTER_TAX = GunaTextBoxTaxeSejour.Text
                                    End If
                                Else
                                    Functions.DeleteElementByCode(CODE_RESERVATION, "taxe_sejour_collectee", "NUM_RESERVATION")
                                    'Functions.updateOfFields("main_courante_journaliere", "TAUX_OCCUPATION_PCT", TAUX_OCCUPATION_PCT, "NUM_RESERVATION", CODE_RESERVATION, 1)
                                End If

                                Dim CODE_MAIN_COURANTE_GENERALE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante_generale", "MCG")
                                Dim DATE_MAIN_COURANTE As Date = GlobalVariable.DateDeTravail
                                Dim PDJ_FOOD As Double = 0
                                Dim PDJ_BOISSON As Double = 0
                                Dim DEJEUNER_FOOD As Double = 0
                                Dim DEJEUNER_BOISSON As Double = 0
                                Dim DINER_FOOD As Double = 0
                                Dim DINER_BOISSON As Double = 0
                                Dim BANQUET_FOOD As Double = 0
                                Dim BANQUET_BOISSON As Double = 0
                                Dim BAR_MATIN As Double = 0
                                Dim BAR_SOIR As Double = 0
                                Dim DIVERS As Double = 0

                                Dim TOTAL_JOUR As Double = MONTANT_ACCORDE + TAUX_OCCUPATION_PCT
                                Dim REPORT_VEILLE As Double = 0
                                Dim TOTAL_GENERAL As Double = MONTANT_ACCORDE + TAUX_OCCUPATION_PCT
                                Dim NUM_RESERVATION = CODE_RESERVATION
                                Dim DEDUCTION As Double = 0
                                Dim ENCAISSEMENT_ESPECE As Double = 0
                                Dim ENCAISSEMENT_CHEQUE As Double = 0
                                Dim ENCAISSEMENT_CARTE_CREDIT As Double = 0
                                'Dim A_REPORTER As Double = MONTANT_ACCORDE + TAUX_OCCUPATION_PCT
                                Dim A_REPORTER As Double = Functions.SituationDeReservation(CODE_RESERVATION)
                                Dim OBSERVATIONS As String = ""


                                Dim INDICE_FREQUENTATION As Double = 0
                                Dim INDICE_FREQUENTATION_PCT As Double = 0
                                Dim TAUX_OCCUPATION As Double = 0

                                Dim CLIENTS_ATTENDUS As Integer = 0
                                Dim CLIENTS_EN_CHAMBRE As Integer = GunaTextBoxNbrePersonne.Text
                                Dim CHAMBRES_DISPONIBLES As Integer = 0
                                Dim TOTAL_HORS_SERVICE As Integer = 0
                                Dim CHAMBRES_HORS_SERVICE As Integer = 0
                                Dim TOTAL_FICTIVES As Integer = 0
                                Dim CHAMBRES_FICTIVES As Integer = 0
                                Dim NOMBRE_MESSAGES As Integer = 0
                                Dim TOTAL_GRATUITES As Double = 0
                                Dim CHAMBRES_GRATUITES As Integer = 0
                                Dim TOTAL_NON_FACTUREES As Double = 0
                                Dim CHAMBRES_NON_FACTUREES As Integer = 0

                                '----------- MAIN COURANTE JOURNALIERE ------------------------------

                                Dim PDJ As Double = 0
                                Dim DEJEUNER As Double = 0
                                Dim DINER As Double = 0
                                Dim CAFE As Double = 0
                                Dim BAR As Double = 0
                                Dim CAVE As Double = 0
                                Dim AUTRE As Double = 0
                                Dim SOUS_TOTAL1 As Double = 0
                                Dim Location As Double = 0
                                Dim TELE As Double = 0
                                Dim FAX As Double = 0
                                Dim LINGE As Double = 0
                                Dim SOUS_TOTAL2 As Double = 0
                                Dim DEBITEUR As Double = 0
                                Dim ARRHES As Double = 0

                                If GunaCheckBoxPetitDejeuenerInclus.Checked Then

                                    Dim petitDejeuner As Double = 0
                                    Double.TryParse(GunaTextBoxPetitDejeuner.Text, petitDejeuner)
                                    SOUS_TOTAL1 = petitDejeuner 'On gère les petit dejeuener inclus par apport a la valeur SOUS_TOTAL1 de la main courante journaliere

                                End If

                                Dim AFFICHER_PRIX As Integer = 1

                                If Not GunaCheckBoxAfficherPrix.Checked Then
                                    AFFICHER_PRIX = 0
                                End If
                                '------------------------------- compte -----------------------------

                                Dim INTITULE As String = ""
                                Dim NUMERO_COMPTE As String = ""
                                Dim TOTAL_DEBIT As Double = GlobalVariable.MONTANT_TOTAL
                                Dim TOTAL_CREDIT As Double = GlobalVariable.avance
                                Dim SOLDE_COMPTE As Double = TOTAL_CREDIT - TOTAL_DEBIT

                                Dim SENS_DU_SOLDE As String = ""

                                If (TOTAL_DEBIT < TOTAL_CREDIT) Then
                                    SENS_DU_SOLDE = "crediteur**************"
                                ElseIf (TOTAL_CREDIT < TOTAL_DEBIT) Then
                                    SENS_DU_SOLDE = "debiteur***************"
                                Else
                                    SENS_DU_SOLDE = "equilibre***************"
                                End If

                                Dim TYPE_DE_COMPTE As String = ""

                                '--------------------------- FORFAIT SALLE ---------------------------
                                Dim nbreCafe As Integer = 0
                                Dim cafePu As Double = 0
                                Dim dejeunerNbre As Integer = 0
                                Dim dejeunerPu As Double = 0
                                Dim dinerNbre As Integer = 0
                                Dim dinerPu As Double = 0
                                Dim traiteurNbre As Integer = 0
                                Dim traiteurPu As Double = 0

                                Double.TryParse(GunaTextBox35.Text, nbreCafe)
                                Double.TryParse(GunaTextBoxForfaitCafe.Text, cafePu)
                                Double.TryParse(GunaTextBox30.Text, dejeunerNbre)
                                Double.TryParse(GunaTextBoxForfatiDejeuner.Text, dejeunerPu)
                                Double.TryParse(GunaTextBox25.Text, dinerNbre)
                                Double.TryParse(GunaTextBoxForfaitDiner.Text, dinerPu)
                                Double.TryParse(GunaTextBox13.Text, traiteurNbre)
                                Double.TryParse(GunaTextBoxForfaitTraiteur.Text, traiteurPu)

                                Dim NBRE__CAFE = nbreCafe
                                Dim PU_CAFE = cafePu
                                Dim NBRE_DEJEUNER = dejeunerNbre
                                Dim PU_DEJEUNER = dejeunerPu
                                Dim NBRE_DINER = dinerNbre
                                Dim PU_DINER = dinerPu
                                Dim NBRE_TRAITEUR = traiteurNbre
                                Dim PU_TRAITEUR = traiteurPu
                                Dim decorationCast As Double = 0
                                Double.TryParse(GunaTextBoxDecoration.Text, decorationCast)
                                Dim DECORATION = decorationCast


                                Dim LOCATION_MATERIEL As Double = 0
                                Dim AUTRES As Double = 0

                                If Not Trim(GunaTextBoxMateriel.Text) = "" Then
                                    LOCATION_MATERIEL = GunaTextBoxMateriel.Text
                                End If

                                If Not Trim(GunaTextBoxAutres.Text) = "" Then
                                    AUTRES = GunaTextBoxAutres.Text
                                End If

                                Dim CODE_EVENEMENT = ""
                                Dim LIBELLE_EVENEMENT = ""

                                If GunaComboBoxEvenement.SelectedIndex >= 0 Then

                                    CODE_EVENEMENT = GunaComboBoxEvenement.SelectedValue

                                    Dim evenement As DataTable = Functions.getElementByCode("CODE_EVENEMENT", "evenement", "CODE_EVENEMENT")

                                    If evenement.Rows.Count > 0 Then
                                        LIBELLE_EVENEMENT = evenement.Rows(0)("LIBELLE_EVENEMENT")
                                    End If

                                End If

                                Dim NBRE_GOUTER As Integer = 0
                                Dim PU_GOUTER As Double = 0
                                Dim NBRE_COCKTAIL As Integer = 0
                                Dim PU_COCKTAIL As Double = 0

                                If Not Trim(GunaTextBoxQteGouter.Text) = "" Then
                                    NBRE_GOUTER = GunaTextBoxQteGouter.Text
                                End If

                                If Not Trim(GunaTextBoxPrixGouter.Text) = "" Then
                                    PU_GOUTER = GunaTextBoxPrixGouter.Text
                                End If

                                If Not Trim(GunaTextBoxCocktail.Text) = "" Then
                                    NBRE_COCKTAIL = GunaTextBoxCocktail.Text
                                End If

                                If Not Trim(GunaTextBoxPUCocktail.Text) = "" Then
                                    PU_COCKTAIL = GunaTextBoxPUCocktail.Text
                                End If

                                '-------------------------addition forfait salle -------------------------------------

                                Dim HEURE_PAUSE_CAFE As String = ""
                                If GunaComboBoxHeureCafe.SelectedIndex >= 0 Then
                                    HEURE_PAUSE_CAFE = GunaComboBoxHeureCafe.SelectedItem
                                End If

                                Dim HEURE_PAUSE_DEJEUNER As String = ""
                                If GunaComboBoxHeureDej.SelectedIndex >= 0 Then
                                    HEURE_PAUSE_DEJEUNER = GunaComboBoxHeureDej.SelectedItem
                                End If

                                Dim HEURE_DINER As String = ""
                                If GunaComboBoxHeureDiner.SelectedIndex >= 0 Then
                                    HEURE_DINER = GunaComboBoxHeureDiner.SelectedItem
                                End If

                                Dim HEURE_GOUTER As String = ""
                                If GunaComboBoxHeureGouter.SelectedIndex >= 0 Then
                                    HEURE_GOUTER = GunaComboBoxHeureGouter.SelectedItem
                                End If

                                Dim HEURE_COCKTAIL As String = ""
                                If GunaComboBoxHeureCocktail.SelectedIndex >= 0 Then
                                    HEURE_COCKTAIL = GunaComboBoxHeureCocktail.SelectedItem
                                End If

                                Dim VIDEO_PROJ As Integer = 0
                                If GunaCheckBoxVidOui.Checked Then
                                    VIDEO_PROJ = 1
                                ElseIf GunaCheckBoxVidNon.Checked Then
                                    VIDEO_PROJ = 0
                                Else
                                    VIDEO_PROJ = 0
                                End If

                                Dim SONO As Integer = 0
                                If GunaCheckBoxSonoOui.Checked Then
                                    SONO = 1
                                ElseIf GunaCheckBoxSonoNon.Checked Then
                                    SONO = 0
                                Else
                                    SONO = 0
                                End If

                                Dim COUVERTS As Integer = 0
                                If GunaCheckBoxCouvOui.Checked Then
                                    COUVERTS = 1
                                ElseIf GunaCheckBoxCouvNon.Checked Then
                                    COUVERTS = 0
                                Else
                                    COUVERTS = 0
                                End If

                                Dim TABLE_CHAISE As Integer = 0
                                If GunaCheckBoxTableOui.Checked Then
                                    TABLE_CHAISE = 1
                                ElseIf GunaCheckBoxTableNon.Checked Then
                                    TABLE_CHAISE = 0
                                Else
                                    TABLE_CHAISE = 0
                                End If

                                Dim EAU_PTE_QTE As Integer = 0
                                If Not Trim(GunaTextBox47.Text) = "" Then
                                    EAU_PTE_QTE = GunaTextBox47.Text
                                End If

                                Dim EAU_PTE_MONTANT As Double = 0
                                If Not Trim(GunaTextBoxMontantEauPetiteBouteille.Text) = "" Then
                                    EAU_PTE_MONTANT = GunaTextBoxMontantEauPetiteBouteille.Text
                                End If

                                Dim EAU_GRDE_QTE As Integer = 0
                                If Not Trim(GunaTextBox10.Text) = "" Then
                                    EAU_GRDE_QTE = GunaTextBox10.Text
                                End If

                                Dim EAU_GRDE_MONTANT As Double = 0
                                If Not Trim(GunaTextBox68.Text) = "" Then
                                    EAU_GRDE_MONTANT = GunaTextBox68.Text
                                End If

                                Dim BOISSONS_GAZEUSES_QTE As Integer = 0
                                If Not Trim(GunaTextBox48.Text) = "" Then
                                    BOISSONS_GAZEUSES_QTE = GunaTextBox48.Text
                                End If

                                Dim BOISSONS_GAZEUSES_MONTANT As Double = 0
                                If Not Trim(GunaTextBox62.Text) = "" Then
                                    BOISSONS_GAZEUSES_MONTANT = GunaTextBox62.Text
                                End If

                                Dim BIERES_QTE As Integer = 0
                                If Not Trim(GunaTextBox50.Text) = "" Then
                                    BIERES_QTE = GunaTextBox50.Text
                                End If

                                Dim BIERES_MONTANT As Double = 0
                                If Not Trim(GunaTextBox61.Text) = "" Then
                                    BIERES_MONTANT = GunaTextBox61.Text
                                End If

                                Dim VIN_ROUGE_QTE As Integer = 0
                                If Not Trim(GunaTextBox54.Text) = "" Then
                                    VIN_ROUGE_QTE = GunaTextBox54.Text
                                End If

                                Dim VIN_ROUGE_MONTANT As Double = 0
                                If Not Trim(GunaTextBox59.Text) = "" Then
                                    VIN_ROUGE_MONTANT = GunaTextBox59.Text
                                End If

                                Dim VIN_ROSE_QTE As Integer = 0
                                If Not Trim(GunaTextBox63.Text) = "" Then
                                    VIN_ROSE_QTE = GunaTextBox63.Text
                                End If

                                Dim delogement As Boolean = False

                                Dim VIN_ROSE_MONTANT As Double = 0
                                If Not Trim(GunaTextBox64.Text) = "" Then
                                    VIN_ROSE_MONTANT = GunaTextBox64.Text
                                End If

                                Dim BOISSONS_EXT_QTE As Integer = 0
                                If Not Trim(GunaTextBox36.Text) = "" Then
                                    BOISSONS_EXT_QTE = GunaTextBox36.Text
                                End If

                                Dim BOISSONS_EXT_MONTANT As Double = 0
                                If Not Trim(GunaTextBox57.Text) = "" Then
                                    BOISSONS_EXT_MONTANT = GunaTextBox57.Text
                                End If

                                Dim DROIT_DE_BOUCHON As Double = 0
                                If Not Trim(GunaTextBoxDroitDeBouchon.Text) = "" Then
                                    DROIT_DE_BOUCHON = GunaTextBoxDroitDeBouchon.Text
                                End If

                                Dim MISE_EN_PLACE As Integer = 0 ' U

                                If GunaCheckBoxU.Checked Then
                                    MISE_EN_PLACE = 1
                                ElseIf GunaCheckBoxEcole.Checked Then
                                    MISE_EN_PLACE = 2 ' Ecole
                                ElseIf GunaCheckBoxTheatre.Checked Then
                                    MISE_EN_PLACE = 3 ' Theatre
                                ElseIf GunaCheckBoxRectangle.Checked Then
                                    MISE_EN_PLACE = 4 ' Rectangle
                                ElseIf GunaCheckBoxCocktail.Checked Then
                                    MISE_EN_PLACE = 5 'Cocktail
                                ElseIf GunaCheckBoxBanquet.Checked Then
                                    MISE_EN_PLACE = 6 'Banquet
                                End If

                                Dim CLOISONNEMENT As Integer = 0

                                If GunaCheckBox2.Checked Then
                                    CLOISONNEMENT = 2
                                ElseIf GunaCheckBox9.Checked Then
                                    CLOISONNEMENT = 3 ' Ecole
                                Else
                                    CLOISONNEMENT = 0
                                End If

                                '---------------------- Facturation ---------------------------------------

                                Dim CODE_FACTURE = Functions.GeneratingRandomCodeWithSpecifications("facture", "")
                                Dim NUMERO_PIECE = ""
                                Dim CODE_ARTICLE = ""
                                Dim CODE_LOT = ""
                                Dim QUANTITE = 1
                                Dim PRIX_UNITAIRE_TTC = 0
                                Dim DATE_FACTURE = GlobalVariable.DateDeTravail
                                Dim HEURE_FACTURE = Now().ToShortTimeString
                                Dim ETAT_FACTURE = 0
                                Dim HEURE_OCCUPATION = Now().ToShortTimeString
                                Dim LIBELLE_FACTURE = "AVANCE LOCATION SALLE [ " & CODE_CHAMBRE & " ]"
                                Dim TYPE_LIGNE_FACTURE = 0
                                Dim NUMERO_SERIE = ""
                                Dim NUMERO_ORDRE = ""
                                Dim DESCRIPTION = ""
                                Dim MONTANT_REMISE = 0
                                Dim MONTANT_TAXE = 0
                                Dim NUMERO_SERIE_DEBUT = ""
                                Dim NUMERO_SERIE_FIN = ""
                                Dim CODE_MAGASIN = ""
                                Dim FUSIONNEE = ""
                                Dim Type = GlobalVariable.typeChambreOuSalle
                                Dim CODE_MOUVEMENT = ""
                                Dim CODE_MODE_PAIEMENT = ""

                                '-------------------------- UPDATE ROOM --------------------------------


                                If Not exist Then

                                    '-------------------------------------- MOUCHARDS ---------------------------------------------------
                                    Dim ACTION As String = ""

                                    If GunaCheckBoxDayUse.Checked Then

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            ACTION = "CREATION DE RESERVATION [CHAMBRE : " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " DE" & DEBUT_HEURE & " - " & FIN_HEURE & "]"

                                        Else
                                            ACTION = "BOOKING CREATION [ROOM : " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " FROM" & DEBUT_HEURE & " - " & FIN_HEURE & "]"

                                        End If
                                    Else
                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            ACTION = "CREATION DE RESERVATION [CHAMBRE : " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " DU " & DATE_ENTTRE & " - " & DATE_SORTIE & "]"

                                        Else
                                            ACTION = "BOOKING CREATION [ROOM : " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " FROM " & DATE_ENTTRE & " - " & DATE_SORTIE & "]"

                                        End If
                                    End If

                                    User.mouchard(ACTION)
                                    '----------------------------------------------------------------------------------------------------

                                    'SUIVI DES RESERVATIONS

                                    Dim CODE_SUIVI As String = Functions.GeneratingRandomCodeWithSpecifications("suivi_des_reservations", "SVR")
                                    Dim RESERVATION_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                    Dim CHECKIN_PAR As String = ""
                                    Dim CHECKOUT_PAR As String = ""
                                    Dim DELOGEMENT_PAR As String = ""

                                    User.suiviDesReservations(CODE_SUIVI, CODE_RESERVATION, RESERVATION_PAR, CHECKIN_PAR, CHECKOUT_PAR, DELOGEMENT_PAR)

                                    Dim operation As Integer = 0 'INSERTION
                                    gestionDesNavettes(operation, CODE_RESERVATION)

                                    '---------------------------------------------------------------------------------------------------
                                    'We  update the room, we manually got CODE_CHAMBRE when we inserted the room informations
                                    Dim updateQuery As String = "UPDATE `chambre` SET `ETAT_CHAMBRE`=@ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@code "

                                    Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                                    command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
                                    command.Parameters.Add("@code", MySqlDbType.VarChar).Value = Trim(GunaTextBoxNumeroChambre.Text)
                                    command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

                                    'Opening the connection
                                    'connect.openConnection()

                                    'Excuting the command and testing if everything went on well
                                    If (command.ExecuteNonQuery() = 1) Then
                                        'connect.closeConnection()
                                    End If

                                Else

                                    'DELOGEMENT D'UNE CHAMBRE POUR UNE AUTRE
                                    ' We come from main courante reception journaliere
                                    'The room has been changed
                                    'If Not GlobalVariable.codeChambreToUpdate = GlobalVariable.codeChambre Then
                                    If Not (GlobalVariable.codeChambreToUpdate = GunaTextBoxNumeroChambre.Text) And Not GlobalVariable.duplicationDeReservation Then

                                        delogement = True

                                        'SI ON EST DANS LE CADRE D'UNE RESA DE GROUPE ON NE DOIT PAS DEMANDER LA RAISON DU DELOGEMENT
                                        If Trim(GlobalVariable.codeChambreToUpdate) = "-" Or Trim(GlobalVariable.codeChambreToUpdate) = "" Then
                                            delogement = False
                                        End If

                                        If delogement Then

                                            Dim motifDelogement As String = ""

                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                motifDelogement = InputBox("DELOGEMENT ", " Motif du délogement de " & GlobalVariable.codeChambreToUpdate & " vers " & GunaTextBoxNumeroChambre.Text, "")
                                            Else
                                                motifDelogement = InputBox("DISPLACEMENT ", " Reason of displacement from " & GlobalVariable.codeChambreToUpdate & " to " & GunaTextBoxNumeroChambre.Text, "")
                                            End If

                                            OBSERVATIONS = motifDelogement

                                            Dim newEtatChambre As String = GlobalVariable.libre_propre

                                            Dim reservationActuel As DataTable = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reservation", "CODE_RESERVATION")

                                            If reservationActuel.Rows.Count > 0 Then
                                                newEtatChambre = GlobalVariable.libre_propre
                                            Else

                                                Dim reservationConfActuel As DataTable = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reserve_conf", "CODE_RESERVATION")

                                                If reservationConfActuel.Rows.Count > 0 Then
                                                    newEtatChambre = GlobalVariable.libre_sale
                                                Else

                                                End If

                                            End If
                                            'The room has been changed, we liberate the old room and set the new room as occupied

                                            '-------------------------------------- MOUCHARDS ---------------------------------------------------
                                            Dim ACTION As String = ""
                                            '"DELOGEMENT ", " Motif du délogement de " & GlobalVariable.codeChambreToUpdate & " vers " & GunaTextBoxNumeroChambre.Text

                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                ACTION = "DELOGEMENT [DE LA CHAMBRE " & GlobalVariable.codeChambreToUpdate & " VERS " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & "  MOTIF : " & OBSERVATIONS & "]"

                                            Else
                                                ACTION = "DISPLACEMENT [FROM ROOM " & GlobalVariable.codeChambreToUpdate & " TO " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & "  REASON : " & OBSERVATIONS & "]"

                                            End If

                                            User.mouchard(ACTION)
                                            '----------------------------------------------------------------------------------------------------

                                            'SUIVI DES RESERVATIONS

                                            Dim CODE_SUIVI As String = Functions.GeneratingRandomCodeWithSpecifications("suivi_des_reservations", "SVR")
                                            Dim RESERVATION_PAR As String = ""
                                            Dim CHECKIN_PAR As String = ""
                                            Dim CHECKOUT_PAR As String = ""
                                            Dim DELOGEMENT_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                                            User.updateSuiviDesReservations("DELOGEMENT_PAR", DELOGEMENT_PAR, CODE_RESERVATION)

                                            '-----------------------------------------------------------------------------------------------------

                                            'We liberate the old room so as to set occupy the new room
                                            Dim updateQuery1 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE`=@ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@code"

                                            Dim command1 As New MySqlCommand(updateQuery1, GlobalVariable.connect)

                                            command1.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
                                            'command1.Parameters.Add("@code", MySqlDbType.VarChar).Value = GlobalVariable.codeChambre
                                            command1.Parameters.Add("@code", MySqlDbType.VarChar).Value = GlobalVariable.codeChambreToUpdate
                                            command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = newEtatChambre

                                            'Opening the connection
                                            'connect.openConnection()

                                            'Excuting the command and testing if everything went on well
                                            If (command1.ExecuteNonQuery() = 1) Then
                                                'connect.closeConnection()
                                            End If

                                            'We set the new room as occupied
                                            'CODE_CHAMBRE = GlobalVariable.codeChambreToUpdate
                                            CODE_CHAMBRE = Trim(GunaTextBoxNumeroChambre.Text)

                                            Dim updateQuery2 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE`=@ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@code"

                                            Dim command2 As New MySqlCommand(updateQuery2, GlobalVariable.connect)

                                            If newEtatChambre = GlobalVariable.libre_propre Then
                                                newEtatChambre = GlobalVariable.occupee_propre 'Simple reservation
                                            Else
                                                newEtatChambre = GlobalVariable.occupee_sale 'reservation confirmee
                                            End If

                                            command2.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
                                            command2.Parameters.Add("@code", MySqlDbType.VarChar).Value = CODE_CHAMBRE
                                            command2.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.occupee_propre

                                            OBSERVATIONS = "Délogement de la " & GlobalVariable.codeChambreToUpdate & " vers " & Trim(GunaTextBoxNumeroChambre.Text) & " pour " & motifDelogement

                                            If occupationChambre.insertOccupationChambre(CODE_OCCUPATION_CHAMBRE, CODE_RESERVATION, CODE_CHAMBRE, MONTANT_HT, TAXE, MONTANT_TTC, DATE_OCCUPATION, ETAT_CHAMBRE, OBSERVATIONS, COMMENTAIRE1, COMMENTAIRE2, COMMENTAIRE3, COMMENTAIRE4, DATE_LIBERATION, CODE_UTILISATEUR_CREA, DATE_PREMIERE_ARRIVEE, TYPE_RESERVATION, PDJ_INCLUS, TAXE_SEJOURS_INCLUS, TVA_INCLUS, CODE_CLIENT_REEL, CODE_AGENCE) Then

                                                'MISE AJOURS DE LA MAIN COURANTE JOURNALIERE

                                                Dim CODE_MAIN_COURANTE_DELOGEMENT As String = GlobalVariable.codeMainCouranteJournaliereToUpdate
                                                reservation.updateChambreApresDelogement(CODE_MAIN_COURANTE_DELOGEMENT, CODE_CHAMBRE)

                                                User.mouchard(OBSERVATIONS)

                                            End If

                                            If (command2.ExecuteNonQuery() = 1) Then
                                                'connect.closeConnection()
                                            End If

                                            GlobalVariable.duplicationDeReservation = False

                                        End If

                                    End If

                                End If

                                '-------------------------- OCCUPATION CHAMBRE--------------------------
                                If Not Functions.entryCodeExists(CODE_OCCUPATION_CHAMBRE, "occupation_chambre", "CODE_OCCUPATION_CHAMBRE") Then

                                    If GlobalVariable.codeOccupationchambreToUpdate = "" Then
                                        'As the Global variable codeMainCouranteToUpdate is empty => new  Entry

                                        If occupationChambre.insertOccupationChambre(CODE_OCCUPATION_CHAMBRE, CODE_RESERVATION, CODE_CHAMBRE, MONTANT_HT, TAXE, MONTANT_TTC, DATE_OCCUPATION, ETAT_CHAMBRE, OBSERVATIONS, COMMENTAIRE1, COMMENTAIRE2, COMMENTAIRE3, COMMENTAIRE4, DATE_LIBERATION, CODE_UTILISATEUR_CREA, DATE_PREMIERE_ARRIVEE, TYPE_RESERVATION, PDJ_INCLUS, TAXE_SEJOURS_INCLUS, TVA_INCLUS, CODE_CLIENT_REEL, CODE_AGENCE) Then

                                        End If

                                    Else

                                        'As the Global variable codeMainCouranteToUpdate is not empty => insert again

                                        If occupationChambre.insertOccupationChambre(CODE_OCCUPATION_CHAMBRE, CODE_RESERVATION, CODE_CHAMBRE, MONTANT_HT, TAXE, MONTANT_TTC, DATE_OCCUPATION, ETAT_CHAMBRE, OBSERVATIONS, COMMENTAIRE1, COMMENTAIRE2, COMMENTAIRE3, COMMENTAIRE4, DATE_LIBERATION, CODE_UTILISATEUR_CREA, DATE_PREMIERE_ARRIVEE, TYPE_RESERVATION, PDJ_INCLUS, TAXE_SEJOURS_INCLUS, TVA_INCLUS, CODE_CLIENT_REEL, CODE_AGENCE) Then

                                        End If

                                    End If

                                End If

                                'GESTION DES AVANCES ICI

                                '----------- MAIN COURANTE GENERALE ------------------------------

                                'We check if the the main courante generale already exist
                                'If Not Functions.entryCodeExists(CODE_MAIN_COURANTE_GENERALE, "main_courante_generale", "CODE_MAIN_COURANTE_GENERALE") Then

                                If GlobalVariable.codeMainCouranteToUpdate = "" Then
                                    'As the Global variable codeMainCouranteGeneraleToUpdate is empty => new  Entry

                                    If mainCourante.insertMainCouranteGenerale(CODE_MAIN_COURANTE_GENERALE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ_FOOD, PDJ_BOISSON, DEJEUNER_FOOD, DEJEUNER_BOISSON, DINER_FOOD, DINER_BOISSON, BANQUET_FOOD, BANQUET_BOISSON, BAR_MATIN, BAR_SOIR, DIVERS, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                    End If

                                Else
                                    'As the Global variable codeMainCouranteGeneraleToUpdate is not empty => update 

                                    CODE_MAIN_COURANTE_GENERALE = GlobalVariable.codeMainCouranteGeneraleToUpdate
                                    NUM_RESERVATION = CODE_RESERVATION_DEPART

                                    If mainCourante.updateMainCouranteGenerale(CODE_MAIN_COURANTE_GENERALE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ_FOOD, PDJ_BOISSON, DEJEUNER_FOOD, DEJEUNER_BOISSON, DINER_FOOD, DINER_BOISSON, BANQUET_FOOD, BANQUET_BOISSON, BAR_MATIN, BAR_SOIR, DIVERS, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                    End If

                                End If

                                'End If

                                '----------- MAIN COURANTE JOURNALIERE ------------------------------

                                'We check if the the main courante journaliere already exist
                                'If Not Functions.entryCodeExists(CODE_MAIN_COURANTE, "main_courante_journaliere", "CODE_MAIN_COURANTE_JOURNALIERE") Then

                                If Trim(GlobalVariable.codeMainCouranteJournaliereToUpdate) = "" Then
                                    'As the Global variable codeMainCouranteToUpdate is empty => new  Entry

                                    If exist Then
                                        NUM_RESERVATION = CODE_RESERVATION_DEPART
                                    End If

                                    If mainCourante.insertMainCouranteJournaliere(CODE_MAIN_COURANTE_JOURNALIERE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, Location, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then


                                        '-------------------UTILISE POUR LES RESERVATION DONT L'ENCAISSEMENT EST FAIT AVANT L'ENREGISTREMENT ----------------------------------------
                                        'ON DOIT VERIFIER SI LA RESERVATION DONT ON CREEE LA LIGNE DE MAINCOURANTE EST ASSOCIE A UN REGLEMENT EN ESPECE FAITE LORS DE LA RESA

                                        miseAjourDeRegelementApresCreationDeMainCourante(NUM_RESERVATION, CODE_MAIN_COURANTE_JOURNALIERE)

                                        '------------------------------------------------------------------------------------------------------
                                    End If

                                Else
                                    'As the Global variable codeMainCourantJournaliereToUpdate is not empty => update 

                                    CODE_MAIN_COURANTE_JOURNALIERE = GlobalVariable.codeMainCouranteJournaliereToUpdate

                                    NUM_RESERVATION = CODE_RESERVATION_DEPART

                                    If mainCourante.updateMainCouranteJournaliereResaInfo(CODE_MAIN_COURANTE_JOURNALIERE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, Location, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                    End If

                                End If

                                'End If

                                '------------------------------------------------- GESTION DE LA RESERVATION  -----------------------------------

                                If Not exist Then

                                    If GlobalVariable.tarificationDynamiqueActif Then

                                        Dim DateDebut As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
                                        Dim tarif As New Tarifs

                                        'TRAITEMENT D'UN CKECKIN DIRECT DONC FICHIER TEXT DE TARIFICATION INEXISTANT DONC ON VA LE CREER
                                        tarif.determinationDesMontantPourTouteLaPeriodeDelaReservation(DateDebut, CODE_RESERVATION, CODE_TARIF_RESERVATION, DATE_ENTTRE, DATE_SORTIE, TYPE_CHAMBRE)

                                    End If

                                    'As the Global variable codeReservationToUpdate is empty => new Reservation Entry 

                                    If reservation.insertReservation(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, 0, BC_ENTREPRISE, TYPE_CHAMBRE, TYPE_CHAMBRE_OU_SALLE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE) Then

                                        Dim TABLE As String = "reservation"

                                        reservation.updatePetitDejeuner(PETIT_DEJEUNER, CODE_RESERVATION, TABLE, AFFICHER_PRIX, BFK_COST)

                                        If GlobalVariable.typeChambreOuSalle = "salle" Then
                                            reservation.insertForfait(CODE_RESERVATION, NBRE__CAFE, PU_CAFE, NBRE_DEJEUNER, PU_DEJEUNER, NBRE_DINER, PU_DINER, NBRE_TRAITEUR, PU_TRAITEUR, DECORATION, LOCATION_MATERIEL, AUTRES, CODE_EVENEMENT, LIBELLE_EVENEMENT, NBRE_GOUTER, PU_GOUTER, NBRE_COCKTAIL, PU_COCKTAIL, HEURE_PAUSE_CAFE, HEURE_PAUSE_DEJEUNER, HEURE_DINER, HEURE_GOUTER, HEURE_COCKTAIL, VIDEO_PROJ, SONO, COUVERTS, TABLE_CHAISE, EAU_PTE_QTE, EAU_PTE_MONTANT, EAU_GRDE_QTE, EAU_GRDE_MONTANT, BOISSONS_GAZEUSES_QTE, BOISSONS_GAZEUSES_MONTANT, BIERES_QTE, BIERES_MONTANT, VIN_ROUGE_QTE, VIN_ROUGE_MONTANT, VIN_ROSE_QTE, VIN_ROSE_MONTANT, BOISSONS_EXT_QTE, BOISSONS_EXT_MONTANT, DROIT_DE_BOUCHON, MISE_EN_PLACE, CLOISONNEMENT)
                                        End If

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            MessageBox.Show("Réservation de " & NOM_CLIENT & " du " & DATE_ENTTRE & " au " & DATE_SORTIE & " enregistrée avec succès! !", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        Else
                                            MessageBox.Show("Booking of " & NOM_CLIENT & " from " & DATE_ENTTRE & " to " & DATE_SORTIE & " successfully saved!! ", "Booking", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        End If

                                    Else
                                        'Error when inserting a new reservation entry
                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            MessageBox.Show("Problème lors de l'enregistrement de Réservation !!", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                        Else
                                            MessageBox.Show("Issue during the saving of the booking !!", "Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                        End If

                                    End If

                                Else

                                    Dim operation As Integer = 1 'UPDATE
                                    gestionDesNavettes(operation, CODE_RESERVATION)

                                    Dim ACTION As String = ""

                                    If GunaCheckBoxDayUse.Checked Then
                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            ACTION = "SAUVEGARDE DE RESERVATION [CHAMBRE " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " DE " & DEBUT_HEURE & " - " & FIN_HEURE & "]"

                                        Else
                                            ACTION = "BOOKING UPDATE [ROOM " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " FROM " & DEBUT_HEURE & " - " & FIN_HEURE & "]"

                                        End If
                                    Else
                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            ACTION = "SAUVEGARDE DE RESERVATION [CHAMBRE " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " DU " & DATE_ENTTRE & " - " & DATE_SORTIE & "]"
                                        Else
                                            ACTION = "BOOKING UPDATE [ROOM " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " FROM " & DATE_ENTTRE & " - " & DATE_SORTIE & "]"

                                        End If
                                    End If

                                    User.mouchard(ACTION)

                                    Dim ReservationToUpdate As DataTable = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reservation", "CODE_RESERVATION")

                                    If Not ReservationToUpdate.Rows.Count > 0 Then
                                        'not found in reservation so, we search in reserve_conf
                                        ReservationToUpdate = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reserve_conf", "CODE_RESERVATION")

                                        'GESTION DES ETATS DE RESERVATIONS CONFIRMEE
                                        If ReservationToUpdate.Rows(0)("ETAT_RESERVATION") = 1 Then
                                            If GlobalVariable.typeChambreOuSalle = "salle" Then
                                                If GlobalVariable.actualLanguageValue = 1 Then
                                                    ETAT_NOTE_RESERVATION = "EN SALLE"
                                                Else
                                                    ETAT_NOTE_RESERVATION = "IN HALL"
                                                End If

                                            End If
                                        Else
                                            ETAT_NOTE_RESERVATION = "CHECKOUT"
                                        End If

                                    Else

                                        'GESTION DES ETATS DE RESERVATIONS
                                        If ReservationToUpdate.Rows(0)("ETAT_RESERVATION") = 0 Then
                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                ETAT_NOTE_RESERVATION = "ATTENDUE"
                                            Else
                                                ETAT_NOTE_RESERVATION = "EXPECTED"
                                            End If

                                        Else
                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                ETAT_NOTE_RESERVATION = "ANNULEE"
                                            Else
                                                ETAT_NOTE_RESERVATION = "CANCELED"
                                            End If

                                        End If

                                    End If
                                    '-------------------------EITHER WE ARE UPDATING A RESERVATION OR A RESERVATION_CONF-----------------------------------------

                                    'As the Global variable codeReservationToUpdate is not empty => update reservation or reservation _conf
                                    ' we determine if the reservation is found in reservation or reserve_conf
                                    CODE_RESERVATION = CODE_RESERVATION_DEPART
                                    CHAMBRE_ID = CHAMBRE_DEPART

                                    'We have to search where the reservtion to update is found either in reservation or reserve_conf
                                    Dim reservationTable As DataTable = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reservation", "CODE_RESERVATION")

                                    If reservationTable.Rows.Count > 0 Then

                                        ' The Reseravtion is found in reservation

                                        'Dim HEBDOMADAIRE As Integer = 0

                                        If reservation.updateReservation(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, 0, BC_ENTREPRISE, TYPE_CHAMBRE, TYPE_CHAMBRE_OU_SALLE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE) Then

                                            Dim TABLE As String = "reservation"

                                            reservation.updatePetitDejeuner(PETIT_DEJEUNER, CODE_RESERVATION, TABLE, AFFICHER_PRIX, BFK_COST)

                                            If exist Then
                                                'ICI LE SOLDE_RESERVATION DEPAND DU LABEL EMPECHANT UNE VUE INSTANTANNEE
                                                'reservation.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reservation", GunaLabelSolde.Text)
                                                updatedSolde = Functions.SituationDeReservation(CODE_RESERVATION_DEPART)
                                                reservation.updateSoldeReservation(CODE_RESERVATION_DEPART, "reservation", updatedSolde)
                                            End If

                                            If GlobalVariable.typeChambreOuSalle = "salle" Then
                                                reservation.updateForfait(CODE_RESERVATION, NBRE__CAFE, PU_CAFE, NBRE_DEJEUNER, PU_DEJEUNER, NBRE_DINER, PU_DINER, NBRE_TRAITEUR, PU_TRAITEUR, DECORATION, LOCATION_MATERIEL, AUTRES, CODE_EVENEMENT, LIBELLE_EVENEMENT, NBRE_GOUTER, PU_GOUTER, NBRE_COCKTAIL, PU_COCKTAIL, HEURE_PAUSE_CAFE, HEURE_PAUSE_DEJEUNER, HEURE_DINER, HEURE_GOUTER, HEURE_COCKTAIL, VIDEO_PROJ, SONO, COUVERTS, TABLE_CHAISE, EAU_PTE_QTE, EAU_PTE_MONTANT, EAU_GRDE_QTE, EAU_GRDE_MONTANT, BOISSONS_GAZEUSES_QTE, BOISSONS_GAZEUSES_MONTANT, BIERES_QTE, BIERES_MONTANT, VIN_ROUGE_QTE, VIN_ROUGE_MONTANT, VIN_ROSE_QTE, VIN_ROSE_MONTANT, BOISSONS_EXT_QTE, BOISSONS_EXT_MONTANT, DROIT_DE_BOUCHON, MISE_EN_PLACE, CLOISONNEMENT)
                                            End If

                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                MessageBox.Show("Réservation de " & NOM_CLIENT & " du " & DATE_ENTTRE & " au " & DATE_SORTIE & " Mise à jours avec succès !!", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                            Else
                                                MessageBox.Show("Booking of " & NOM_CLIENT & " from " & DATE_ENTTRE & " to " & DATE_SORTIE & " Successfully updated !!", "Booking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            End If

                                        End If

                                    Else

                                        'The resevation is instead found in reserve_conf
                                        'We have to set back the value of etat_reservation from 0 to 1
                                        ETAT_RESERVATION = 1
                                        CHAMBRE_ID = CHAMBRE_DEPART
                                        'MessageBox.Show(CLIENT_ID & " - " & CHAMBRE_ID)
                                        'In case the table has migrate from reservation to reservation_conf we update instead in reserve_conf

                                        ReservationToUpdate = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reserve_conf", "CODE_RESERVATION")

                                        If ReservationToUpdate.Rows.Count > 0 Then
                                            'not found in reservation so, we search in reserve_conf

                                            'GESTION DES ETATS DE RESERVATIONS CONFIRMEE
                                            If ReservationToUpdate.Rows(0)("ETAT_RESERVATION") = 1 Then

                                                If GlobalVariable.typeChambreOuSalle = "salle" Then
                                                    If GlobalVariable.actualLanguageValue = 1 Then
                                                        ETAT_NOTE_RESERVATION = "EN SALLE"
                                                    Else
                                                        ETAT_NOTE_RESERVATION = "IN HALL"
                                                    End If
                                                Else
                                                    ETAT_NOTE_RESERVATION = "CHECKOUT"
                                                End If

                                            Else

                                                'GESTION DES ETATS DE RESERVATIONS
                                                If ReservationToUpdate.Rows(0)("ETAT_RESERVATION") = 0 Then
                                                    If GlobalVariable.actualLanguageValue = 1 Then
                                                        ETAT_NOTE_RESERVATION = "ATTENDUE"
                                                    Else
                                                        ETAT_NOTE_RESERVATION = "EXPECTED"
                                                    End If

                                                Else
                                                    If GlobalVariable.actualLanguageValue = 1 Then
                                                        ETAT_NOTE_RESERVATION = "ANNULEE"
                                                    Else
                                                        ETAT_NOTE_RESERVATION = "CANCELED"
                                                    End If
                                                End If

                                            End If

                                            If reservation.updateReservationConf(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, ETAT_NOTE_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, 0, BC_ENTREPRISE, TYPE_CHAMBRE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE) Then

                                                Dim TABLE As String = "reserve_conf"

                                                reservation.updatePetitDejeuner(PETIT_DEJEUNER, CODE_RESERVATION, TABLE, AFFICHER_PRIX, BFK_COST)

                                                If exist Then
                                                    'reservation.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reserve_conf", GunaLabelSolde.Text)
                                                    updatedSolde = Functions.SituationDeReservation(CODE_RESERVATION_DEPART)
                                                    reservation.updateSoldeReservation(CODE_RESERVATION_DEPART, "reserve_conf", updatedSolde)
                                                End If

                                                If GlobalVariable.typeChambreOuSalle = "salle" Then
                                                    reservation.updateForfait(CODE_RESERVATION, NBRE__CAFE, PU_CAFE, NBRE_DEJEUNER, PU_DEJEUNER, NBRE_DINER, PU_DINER, NBRE_TRAITEUR, PU_TRAITEUR, DECORATION, LOCATION_MATERIEL, AUTRES, CODE_EVENEMENT, LIBELLE_EVENEMENT, NBRE_GOUTER, PU_GOUTER, NBRE_COCKTAIL, PU_COCKTAIL, HEURE_PAUSE_CAFE, HEURE_PAUSE_DEJEUNER, HEURE_DINER, HEURE_GOUTER, HEURE_COCKTAIL, VIDEO_PROJ, SONO, COUVERTS, TABLE_CHAISE, EAU_PTE_QTE, EAU_PTE_MONTANT, EAU_GRDE_QTE, EAU_GRDE_MONTANT, BOISSONS_GAZEUSES_QTE, BOISSONS_GAZEUSES_MONTANT, BIERES_QTE, BIERES_MONTANT, VIN_ROUGE_QTE, VIN_ROUGE_MONTANT, VIN_ROSE_QTE, VIN_ROSE_MONTANT, BOISSONS_EXT_QTE, BOISSONS_EXT_MONTANT, DROIT_DE_BOUCHON, MISE_EN_PLACE, CLOISONNEMENT)
                                                End If


                                            End If

                                        End If

                                    End If

                                End If

                                'EN CAS D'ENCAISSEMT DURANT L'ENREGISTREMENT

                                If DEPOT_DE_GARANTIE > 0 Then

                                    Dim NUM_REGLEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("reglement", "RGL")

                                    MONTANT_VERSE = DEPOT_DE_GARANTIE

                                    'reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                End If

                                If Not Trim(GunaTextBoxPaiement.Text).Equals("") Then

                                    If Double.Parse(GunaTextBoxPaiement.Text) > 0 Then

                                        Dim NUM_REGLEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("reglement", "RGL")

                                        MONTANT_VERSE = GunaTextBoxPaiement.Text

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            MODE_REGLEMENT = "Espèce"
                                            REF_REGLEMENT = "ENCAISSEMENT (" & MODE_REGLEMENT & ") DE " & "[" & NOM_CLIENT & " / " & CHAMBRE_ID & "]"
                                        Else
                                            MODE_REGLEMENT = "Cash"
                                            REF_REGLEMENT = "CASHED IN (" & MODE_REGLEMENT & ") FROM " & "[" & NOM_CLIENT & " / " & CHAMBRE_ID & "]"
                                        End If

                                    End If

                                    'reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                    Dim TABLE As String = ""
                                    Dim FIELD As String = ""

                                    FIELD = "ENCAISSEMENT_ESPECE"

                                    TABLE = "main_courante_journaliere"

                                    Dim FIELDVALUE As Double = MONTANT_VERSE

                                    Dim mainCourantes As New MainCourantes()

                                    'mainCourantes.updateMainCouranteJournaliereModeReglement(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                                End If

                            End If

                            '--------------------------------------- GESTION DE LA MISE A JOURS DU SOLDE DE LA RESERVATION ----------------------------
                            Dim reservationToUpdateInReservation As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reservation", "CODE_RESERVATION")

                            'SOIT DANS RESERVATION

                            Dim SOLDE_RESERVATION As Double = 0

                            If reservationToUpdateInReservation.Rows.Count > 0 Then

                                'MISE JOURS DU SOLDE DE LA RESERVATION
                                updatedSolde = Functions.SituationDeReservation(CODE_RESERVATION)
                                SOLDE_RESERVATION = updatedSolde
                                reservation.updateSoldeReservation(CODE_RESERVATION, "reservation", updatedSolde)

                            Else

                                'OU DANS RESERVATION
                                Dim reservationToUpdateInReserve_conf As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                                If reservationToUpdateInReserve_conf.Rows.Count > 0 Then

                                    updatedSolde = Functions.SituationDeReservation(CODE_RESERVATION)
                                    SOLDE_RESERVATION = updatedSolde
                                    reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", updatedSolde)

                                End If

                            End If

                            '-------------------------------------------- GESTION DES TRACES DES UTILISATEURS ----------------------------------------------------------
                            Dim ACTION_FAITE As String = GunaButtonReservation.Text
                            Dim FAITE_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

                            Dim HEBDOMADAIRE As Integer = 0

                            reservation.insertTrace(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, HEBDOMADAIRE, BC_ENTREPRISE, TYPE_CHAMBRE, ACTION_FAITE, FAITE_PAR, TYPE_CHAMBRE_OU_SALLE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE, SOLDE_RESERVATION)

                            'REENCODAGE DE LA CARTE EN CAS DE CHANGEMENT DE DATE OU HEURE

                            If exist_reserve_conf Then

                                'SEULEMENT POUR LES EN CHAMBRES
                                Dim demandeDeReEncodage As Boolean = False

                                Dim resa As DataTable = Functions.getElementByCode(CODE_RESERVATION_DEPART, "reserve_conf", "CODE_RESERVATION")

                                If resa.Rows.Count > 0 Then

                                    If GunaCheckBoxDayUse.Checked Then

                                        Dim nouveauNombreHeure As Integer = 0

                                        Dim DEBUT_NEW As Date = CDate(GunaComboBoxHeureArrivee.SelectedItem.ToString).ToShortTimeString
                                        Dim FIN_NEW As Date = CDate(GunaComboBoxHeureDepart.SelectedItem.ToString).ToShortTimeString

                                        nouveauNombreHeure = CType((FIN_NEW - DEBUT_NEW).TotalHours, Int32)

                                        Dim DEBUT As Date = CDate(resaExist(0)("HEURE_ENTREE")).ToShortTimeString
                                        Dim FIN As Date = CDate(resaExist(0)("HEURE_SORTIE")).ToShortTimeString

                                        Dim ancienNombreHeure As Integer = 0

                                        ancienNombreHeure = CType((FIN - DEBUT).TotalHours, Int32)

                                        If Not nouveauNombreHeure = ancienNombreHeure Then

                                            If GlobalVariable.AgenceActuelle.Rows(0)("SERRURES") = 1 Then

                                                If GlobalVariable.typeChambreOuSalle = "chambre" Then

                                                    Dim dialog1 As New DialogResult()

                                                    If GlobalVariable.actualLanguageValue = 1 Then
                                                        dialog1 = MessageBox.Show("Changement de période du séjours. Re-encoder la carte ", "Encodage de carte", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                    Else
                                                        dialog1 = MessageBox.Show("Period of stay changed. Issue Card ", "Card Issuance", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                    End If

                                                    ZenoLockForm.Close()

                                                    If dialog1 = DialogResult.Yes Then

                                                        demandeDeReEncodage = True

                                                        GlobalVariable.infoReservationPourEncodage = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                                                        '  --------------------------------- PAYER AVANT ENCODAGE --------------------------------

                                                        Dim DATE_DE_TRAVAIL As Date = GlobalVariable.DateDeTravail.ToShortDateString

                                                        Dim encoder As Boolean = True

                                                    End If
                                                End If

                                            End If

                                            facturationAutoApresPronlongementDeSejour = True 'Payer Avant Encodage

                                        End If

                                        'FACTURATION ANTICIPE APRES PROLONGEMENT : FACTUARTION ANTICIPE 

                                        If facturationAutoApresPronlongementDeSejour Then
                                            reservation.facturationEnAvanceApresPronlogement(CODE_RESERVATION, POSTER_TAX, GlobalVariable.DateDeTravail)
                                        End If

                                    Else

                                        Dim nouveauNombreDejour As Integer = 0

                                        Dim DEBUT_NEW As Date = GunaDateTimePickerArrivee.Value.ToShortDateString
                                        Dim FIN_NEW As Date = GunaDateTimePickerDepart.Value.ToShortDateString

                                        nouveauNombreDejour = CType((FIN_NEW - DEBUT_NEW).TotalDays, Int32)

                                        Dim DEBUT As Date = CDate(resaExist(0)("DATE_ENTTRE")).ToShortDateString
                                        Dim FIN As Date = CDate(resaExist(0)("DATE_SORTIE")).ToShortDateString

                                        Dim ancienNombreDejour As Integer = 0

                                        ancienNombreDejour = CType((FIN - DEBUT).TotalDays, Int32)

                                        If Not nouveauNombreDejour = ancienNombreDejour Then

                                            'LA FENETRE D'ENCODAGE N'EST VISIBLE QUE SI ON ACTIVE L'UTILISATION DES SERRURES

                                            If GlobalVariable.AgenceActuelle.Rows(0)("SERRURES") = 1 Then

                                                If GlobalVariable.typeChambreOuSalle = "chambre" Then
                                                    Dim dialog1 As New DialogResult()

                                                    If GlobalVariable.actualLanguageValue = 1 Then
                                                        dialog1 = MessageBox.Show("Changement de période du séjours. Re-encoder la carte ", "Encodage de carte", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                                    Else
                                                        dialog1 = MessageBox.Show("Period of stay changed. Issuer Card ", "Card Issuance", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                                    End If

                                                    ZenoLockForm.Close()

                                                    If dialog1 = DialogResult.Yes Then

                                                        demandeDeReEncodage = True

                                                        GlobalVariable.infoReservationPourEncodage = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                                                        '--------------------------- PAYER AVANT ENCODAGE ---------------------------

                                                        Dim DATE_DE_TRAVAIL As Date = GlobalVariable.DateDeTravail.ToShortDateString

                                                        Dim encoder As Boolean = True

                                                        Dim nombreDeNuiteAEncoder As Integer = 0

                                                        If GlobalVariable.AgenceActuelle.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 Then

                                                            nombreDeNuiteAEncoder = Functions.nombreDeJourAInsererDansLEncodeur(DATE_ENTTRE, DATE_DE_TRAVAIL, CODE_RESERVATION)

                                                            If nombreDeNuiteAEncoder = 0 Then
                                                                encoder = False
                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            End If

                                            'FACTURATION ANTICIPE APRES PROLONGEMENT : FACTUARTION ANTICIPE 
                                            facturationAutoApresPronlongementDeSejour = True

                                            If facturationAutoApresPronlongementDeSejour Then
                                                reservation.facturationEnAvanceApresPronlogement(CODE_RESERVATION, POSTER_TAX, GlobalVariable.DateDeTravail)
                                            End If

                                        Else

                                            facturationAutoApresPronlongementDeSejour = True

                                            'LES JOURS PEUVENT NE PAS AVOIR CHANGER MAIS LES HEURES OUI
                                            Dim nouveauNombreHeure As Integer = 0

                                            Dim DEBUT_NEW_HEURE As Date = CDate(GunaComboBoxHeureArrivee.SelectedItem.ToString).ToShortTimeString
                                            Dim FIN_NEW_HEURE As Date = CDate(GunaComboBoxHeureDepart.SelectedItem.ToString).ToShortTimeString

                                            nouveauNombreHeure = CType((FIN_NEW_HEURE - DEBUT_NEW_HEURE).TotalHours, Int32)

                                            Dim DEBUT_HEURE_SEJOUR As Date = CDate(resaExist(0)("HEURE_ENTREE")).ToShortTimeString
                                            Dim FIN_HEURE_SEJOUR As Date = CDate(resaExist(0)("HEURE_SORTIE")).ToShortTimeString

                                            Dim ancienNombreHeure As Integer = 0

                                            ancienNombreHeure = CType((FIN_HEURE_SEJOUR - DEBUT_HEURE_SEJOUR).TotalHours, Int32)

                                            If Not nouveauNombreHeure = ancienNombreHeure Then

                                                If GlobalVariable.AgenceActuelle.Rows(0)("SERRURES") = 1 Then

                                                    If GlobalVariable.typeChambreOuSalle = "chambre" Then
                                                        Dim dialog1 As New DialogResult()

                                                        If GlobalVariable.actualLanguageValue = 1 Then
                                                            dialog1 = MessageBox.Show("Changement de période du séjours. Re-encoder la carte ", "Encodage de carte", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                                        Else
                                                            dialog1 = MessageBox.Show("Period of stay changed. Card Issuance ", "Card Issuance", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                                        End If

                                                        ZenoLockForm.Close()

                                                        If dialog1 = DialogResult.Yes Then

                                                            demandeDeReEncodage = True
                                                            GlobalVariable.infoReservationPourEncodage = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                                                            '--------------------------- PAYER AVANT ENCODAGE ---------------------------

                                                            Dim DATE_DE_TRAVAIL As Date = GlobalVariable.DateDeTravail.ToShortDateString

                                                            Dim encoder As Boolean = True

                                                            Dim nombreDeNuiteAEncoder As Integer = 0

                                                            If GlobalVariable.AgenceActuelle.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 Then

                                                                nombreDeNuiteAEncoder = Functions.nombreDeJourAInsererDansLEncodeur(DATE_ENTTRE, DATE_DE_TRAVAIL, CODE_RESERVATION)

                                                                If nombreDeNuiteAEncoder = 0 Then
                                                                    encoder = False
                                                                End If

                                                            End If

                                                        End If

                                                    End If


                                                    'FACTURATION ANTICIPE APRES PROLONGEMENT : FACTUARTION ANTICIPE 
                                                    facturationAutoApresPronlongementDeSejour = True 'Payer Avant Encodage

                                                    If facturationAutoApresPronlongementDeSejour Then
                                                        reservation.facturationEnAvanceApresPronlogement(CODE_RESERVATION, POSTER_TAX, GlobalVariable.DateDeTravail)
                                                    End If

                                                End If

                                            End If


                                        End If

                                    End If

                                    If Not resaExist(0)("CHAMBRE_ID") = GunaTextBoxNumeroChambre.Text Then

                                        If GlobalVariable.AgenceActuelle.Rows(0)("SERRURES") = 1 Then

                                            Dim dialog1 As New DialogResult()

                                            If demandeDeReEncodage Then

                                                If GlobalVariable.actualLanguageValue = 1 Then
                                                    MessageBox.Show("Délogement effectué de la " & GlobalVariable.codeChambreToUpdate & " vers la " & GunaTextBoxNumeroChambre.Text & " .", "Delogement", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                                Else
                                                    MessageBox.Show("Displacement made from " & GlobalVariable.codeChambreToUpdate & " to " & GunaTextBoxNumeroChambre.Text & " .", "Displacement", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                                End If

                                            Else

                                                If GlobalVariable.actualLanguageValue = 1 Then
                                                    dialog1 = MessageBox.Show("Délogement effectué de la " & GlobalVariable.codeChambreToUpdate & " vers la " & GunaTextBoxNumeroChambre.Text & " . Re-encoder la carte ", "Encodage de carte", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                                Else
                                                    dialog1 = MessageBox.Show("Displacement made from " & GlobalVariable.codeChambreToUpdate & " to " & GunaTextBoxNumeroChambre.Text & " . Issue Card ", "Card Issuance", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                                End If

                                                ZenoLockForm.Close()

                                                If dialog1 = DialogResult.Yes Then
                                                    GlobalVariable.infoReservationPourEncodage = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                                                    '--------------------------- PAYER AVANT ENCODAGE ---------------------------

                                                    Dim DATE_DE_TRAVAIL As Date = GlobalVariable.DateDeTravail.ToShortDateString

                                                    Dim encoder As Boolean = True

                                                    Dim nombreDeNuiteAEncoder As Integer = 0

                                                    If GlobalVariable.AgenceActuelle.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 Then

                                                        nombreDeNuiteAEncoder = Functions.nombreDeJourAInsererDansLEncodeur(DATE_ENTTRE, DATE_DE_TRAVAIL, CODE_RESERVATION)

                                                        If nombreDeNuiteAEncoder = 0 Then
                                                            encoder = False
                                                        End If

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                                'numberOfHoursToSpend = CType((DateTimeDepart - DateTimeArrivee).TotalHours, Int32)
                            End If

                            '-------------------------------------------- IMPRESSION DES DOCUMENTS -------------------------------------------------

                            Dim montantParNuitee As Double = 0

                            'la fiche de confirmation ou de contrat s'imrpirme uniquement si c'est la premiere reservation
                            If Not exist Then

                                Dim dialog As DialogResult

                                If GunaRadioButtonSalleFete.Checked Then

                                    If True Then

                                        If GunaComboBoxTypeDeDocSalle.SelectedIndex = 0 Then

                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                dialog = MessageBox.Show("Télécharger La fiche de confirmation ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                            Else
                                                dialog = MessageBox.Show("Download Hotel Registration Form ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                            End If
                                        Else
                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                dialog = MessageBox.Show("Télécharger Dévis estimatif ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                            Else
                                                dialog = MessageBox.Show("Download Quotation ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                            End If
                                        End If

                                    End If

                                Else

                                    If True Then

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            dialog = MessageBox.Show("Télécharger La fiche de confirmation ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        Else
                                            dialog = MessageBox.Show("Download confirmation form ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        End If

                                    End If

                                End If


                                If dialog = DialogResult.Yes Then
                                    'e.Cancel = True

                                    'Génération des documents concernants les salles Confirmation de réservation

                                    'DOCUMENT DE LA SALLE DE FETE
                                    If GunaRadioButtonSalleFete.Checked Then

                                        If Not exist Then

                                            'CONFIRMATION DE RESERVATION

                                            Double.TryParse(GunaTextBoxMontantReelSalle.Text, montantParNuitee)

                                            If GunaComboBoxTypeDeDocSalle.SelectedIndex = 0 Then
                                                Functions.GenerationDeConfirmationReservation(CODE_RESERVATION, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle)
                                            Else
                                                Impression.devisEstimatifDeSalleDeFete(CODE_RESERVATION, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle)
                                            End If

                                        Else

                                        End If

                                    End If

                                    'dialog = MessageBox.Show("Télécharger La fiche de confirmation ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                End If

                            End If

                            Dim CODE_RESERVATAION_ As String = CODE_RESERVATION
                            Dim NOM_PRENOM_ As String = Trim(GunaTextBoxNomPrenom.Text)
                            Dim ARRIVAL_ As Date = GunaDateTimePickerArrivee.Value.ToShortDateString()
                            Dim DEPART_ As Date = GunaDateTimePickerDepart.Value.ToShortDateString()
                            Dim TEMP_A_FAIRE_ As Integer = GunaTextBoxTempsAFaire.Text
                            Dim TYPE_CHAMBRE_ As String = GunaTextBoxLibelleTYpe.Text
                            Dim NUM_CHAMBRE_ As String = GunaTextBoxNumeroChambre.Text
                            Dim MONTANT_PAR_NUITEE_ As Double = montantParNuitee
                            Dim HEURE_ARRIVEE_ As DateTime = GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem
                            Dim HEURE_DEPART_ As DateTime = GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem
                            Dim TYPE_CHAMBRE_SALLE_ As String = GlobalVariable.typeChambreOuSalle

                            Dim args As ArgumentType = New ArgumentType()

                            args.CODE_RESERVATAION = CODE_RESERVATAION_
                            args.NOM_PRENOM = NOM_PRENOM_
                            args.ARRIVAL = ARRIVAL_
                            args.DEPART = DEPART_
                            args.TEMP_A_FAIRE = TEMP_A_FAIRE_
                            args.TYPE_CHAMBRE = TYPE_CHAMBRE_
                            args.NUM_CHAMBRE = NUM_CHAMBRE_
                            args.MONTANT_PAR_NUITEE = MONTANT_PAR_NUITEE_
                            args.HEURE_ARRIVEE = HEURE_ARRIVEE_
                            args.HEURE_DEPART = HEURE_DEPART_
                            args.TYPE_CHAMBRE_SALLE = TYPE_CHAMBRE_SALLE_
                            args.EMAIL = EMAIL
                            args.TELEPHONE_CLIENT = TELEPHONE_CLIENT

                            GunaLabelNumReservation.Text = CODE_RESERVATION

                            '-----------------------------------------------------

                            'GESTION DES GRATUITEES - PERMET D'INSERER LA RESERVATION DANS LA TABLE gratuitee_de_resa
                            gestionDelaGratuiteeDeLaReservation()

                            'GESTION DES PRISES EN CHARGES DE LA RESERVATION
                            gestionDelaPriseEnChargeDeLaReservation()

                            '---------------------------------------------------------------------------------------------------------------------

                            Dim TYPE_DEPOT_CAUTION As Integer = 0

                            If MONTANT_TOTAL_CAUTION > 0 Then
                                TYPE_DEPOT_CAUTION = 0
                                'cautionEnregistrement(CODE_RESERVATION, 0, GunaTextBoxMontantCaution.Text, TYPE)
                                cautionEnregistrement(CODE_RESERVATION, 0, MONTANT_TOTAL_CAUTION, TYPE_DEPOT_CAUTION)
                            End If

                            If DEPOT_DE_GARANTIE > 0 Then
                                TYPE_DEPOT_CAUTION = 1
                                cautionEnregistrement(CODE_RESERVATION, 0, DEPOT_DE_GARANTIE, TYPE_DEPOT_CAUTION)
                            End If


                            'TabControlHbergement.SelectedIndex = 0

                            'VidageDesChampsPourNouvelleReservation()

                            '-------------------------------------------------------------------------------------------------
                            'RSERVATION NORMALE

                            'Clearing all the informations found in the the reseravtion field
                            'emtptyRegistrationFields()

                            'We set all the global variables used for update to their original values


                            'Renitialisation des dates en plus de la date de travail après avoir vidé les variables globales
                            ReinitialisationDesDates()

                            Functions.SiplifiedClearTextBox(Me)

                            'On masque les tarifs associés au client si existe 
                            GunaComboBoxCodeTarif.Visible = False
                            GunaLabelCodeTarif.Visible = False

                            'ReservationList()

                            'Desactivation du bouton de gestion de groupe
                            GunaCheckBoxReservationDeGroupe.Checked = False

                            reservationButtonToDisplay()

                            GunaCheckBoxPetitDejeuenerInclus.Checked = False
                            GunaCheckBoxTaxeSejour.Checked = False
                            GunaTextBoxPetitDejeuner.Visible = False
                            GunaTextBoxPetitDejeunerRoutage.Visible = False

                            'Obtention des informations pour les statistiques
                            Dim stat As New statistiques()

                            stat.ObtenirDerniereStatistique()

                            Dim codeDelaDerniereStatistique As String = stat.ObtenirDerniereStatistique()

                            GlobalVariable.informationDesStatistiques = Functions.getElementByCode(codeDelaDerniereStatistique, "statistiques", "CODE_STATISTIQUE")

                            GunaTextBoxBC.Visible = False

                            GunaButtonCheckOut.Visible = False

                            GunaTextBoxNbreAdulte.Text = 0

                            'CARDEX

                            VidageDesChampsPourNouvelleReservation()


                            If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                                If envoieConfirmationDeReservation Then

                                    '1- MESSAGE WHATSAPP

                                    If SEND_WHATSAP Then

                                        WHATSAPP_OU_EMAIL = 0
                                        args.WHATSAPP_OU_EMAIL = WHATSAPP_OU_EMAIL
                                        args.action = ARG_ACTION

                                        backGroundWorkerToCall(args)

                                    End If

                                    '2- MESSAGE PAR MAIL

                                    If SEND_MAIL Then

                                        WHATSAPP_OU_EMAIL = 1
                                        args.WHATSAPP_OU_EMAIL = WHATSAPP_OU_EMAIL
                                        args.action = ARG_ACTION

                                        backGroundWorkerToCall(args)

                                    End If

                                End If

                            End If

                            '-----------------------------------------------------

                            Me.Cursor = Cursors.Default

                        End If

                    Else

                        Dim infoSupResa As DataTable = Functions.getElementByCode(GunaLabelNumReservation.Text, "reserve_conf", "CODE_RESERVATION")

                        If infoSupResa.Rows.Count > 0 Then
                            GunaTextBoxNumeroChambre.Text = infoSupResa.Rows(0)("CHAMBRE_ID")
                        End If

                        Dim infoChambreResa As DataTable = Functions.getElementByCode(GunaTextBoxNumeroChambre.Text, "chambre", "CODE_CHAMBRE")

                        If infoChambreResa.Rows.Count > 0 Then
                            GunaTextBoxLibelleChambre.Text = infoChambreResa.Rows(0)("LOCALISATION")
                        End If

                    End If

                End If

            End If
        End If


    End Sub

    '------------------------------ END RESERVATION ----------------------------------


    'When Changing the real price manually we re do calculations
    Private Sub GunaTextBoxMontantAccorde_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantAccorde.TextChanged

        ReservationMoneyCalculation()

        Dim prixAfficher As Double = 0
        Dim prixAccorde As Double = 0

        If Not Trim(GunaTextBoxpPrixAffiche.Text).Equals("") Then
            prixAfficher = GunaTextBoxpPrixAffiche.Text
        End If

        If Not Trim(GunaTextBoxMontantAccorde.Text).Equals("") Then
            prixAccorde = GunaTextBoxMontantAccorde.Text
        End If

        If prixAfficher > 0 Then
            If prixAfficher = prixAccorde Then
                If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then
                    gestionReductionClubElite()
                End If
            End If
        End If

        If GunaCheckBoxGratuitee.Checked Then
            GunaTextBoxMontantAccorde.Text = 0
        End If

    End Sub

    'We automatically fill the user part of the form when when ever a new client is created
    Sub FillingFormFromNewlyCreatedUserData()

        If (GlobalVariable.addUserFromFrontOffice = True) Then

            GunaTextBoxNomPrenom.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("NOM_PRENOM").ToString)
            GunaTextBoxTelClient.Text = GlobalVariable.userAddedFromFrontOffice.Rows(0)("TELEPHONE").ToString
            GunaTextBoxClientEmail.Text = GlobalVariable.userAddedFromFrontOffice.Rows(0)("EMAIL").ToString
            GunaTextBoxCNI.Text = GlobalVariable.userAddedFromFrontOffice.Rows(0)("CNI").ToString
            GunaTextBoxRefClient.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("CODE_CLIENT").ToString)
            GlobalVariable.codeClient = GlobalVariable.userAddedFromFrontOffice.Rows(0)("CODE_CLIENT").ToString
            'GunaTextBoxRefClient.Text = Trim(Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("CODE_CLIENT").ToString))
            GunaTextBoxSiteWeb.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("SITE_INTERNET").ToString)
            GunaTextBoxTelClient.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("TELEPHONE"))
            GunaTextBoxNomJeuneFille.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("NOM_JEUNE_FILLE"))
            GunaTextBoxTypeClient.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("TYPE_CLIENT"))
            GunaDateTimePickerDateNaissance.Value = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("DATE_DE_NAISSANCE"))
            GunaTextBoxLieu.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("LIEU_DE_NAISSANCE"))
            GunaTextBoxNationalite.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("NATIONALITE"))
            GunaTextBoxPaysResidence.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("PAYS_RESIDENCE"))
            GunaTextBoxProfession.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("PROFESSION"))
            GunaTextBoxNumeroCompte.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("NUM_COMPTE"))
            GunaTextBoxRue.Text = Trim(GlobalVariable.userAddedFromFrontOffice.Rows(0)("ADRESSE"))
            GunaTextBoxVilleDeResidence.Text = GlobalVariable.userAddedFromFrontOffice.Rows(0)("VILLE_DE_RESIDENCE")
            GunaTextBoxModeTransport.Text = GlobalVariable.userAddedFromFrontOffice.Rows(0)("MODE_TRANSPORT")
            GunaTextBoxNumVehicule.Text = GlobalVariable.userAddedFromFrontOffice.Rows(0)("NUM_VEHICULE")
            GunaTextBoxVenantDe.Text = GlobalVariable.userAddedFromFrontOffice.Rows(0)("VILLE_DE_RESIDENCE")

            'Client ajouté a partir du front desk chargement de l'entreprise du client
            Dim Entreprise As DataTable = Functions.getElementByCode(GlobalVariable.userAddedFromFrontOffice.Rows(0)("CODE_ENTREPRISE"), "client", "CODE_CLIENT")

            If Entreprise.Rows.Count > 0 Then
                GunaTextBoxEntrepriseDuclient.Text = Trim(Entreprise.Rows(0)("NOM_PRENOM"))
            End If

        End If

        'We determine which button to display depending on the information that have been filled
        reservationButtonToDisplay()

    End Sub

    Public Sub MainWindowManualActivation()

        GunaLabelNbreDeNavette.Text = "(" & Functions.alerteNavette() & ")"
        GunaLabelNbreDeNavette.ForeColor = Color.Red

        Me.Refresh()

        ' GlobalVariable.cloturer = True lorsque l'on cloture une journee
        If GlobalVariable.cloturer Then

            GunaDateTimePickerArriveeDepart.Value = GlobalVariable.DateDeTravail
            GunaDateTimePickerDepartDepert.Value = GlobalVariable.DateDeTravail.AddDays(1)
            GunaDateTimePickerDebutEnChambre.Value = GlobalVariable.DateDeTravail
            GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail
            GunaDateTimePickerDepart.Value = GlobalVariable.DateDeTravail
            GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail.ToShortDateString
            GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
            GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail

            'Clearing all the informations found in the the reseravtion field
            VidageDesChampsPourNouvelleReservation()
            'Functions.emptyFields(Me)

            'We set all the global variables used for update to their original values
            Functions.EmtyGlobalVariablesContainingCodeToUpdate()
            ReinitialisationDesDates()

            'Functions.SiplifiedClearTextBox(Me)

            'On masque les tarifs associés au client si existe 
            GunaComboBoxCodeTarif.Visible = False
            GunaLabelCodeTarif.Visible = False

            GlobalVariable.cloturer = False

        End If

        'Loading Tarif from front desk, as it has an influence on Prix réel
        If GlobalVariable.tarifFromFrontDesk Then

            Dim tarif As DataTable = Functions.getElementByCode(GlobalVariable.tarifFromFrontDeskCode, "tarif_prix", "ID_TARIF")

            If GlobalVariable.typeChambreOuSalle = "salle" Then

                If tarif.Rows.Count >= 0 Then
                    GunaTextBoxMontantReelSalle.Text = Format(tarif.Rows(0)("PRIX_TARIF1"), "#,##0")
                End If

            End If

            GlobalVariable.tarifFromFrontDeskCode = ""
            GlobalVariable.tarifFromFrontDesk = False

        End If


        'We update our values from Planning pannel
        If GlobalVariable.ComingFromPlanning Then

            GunaLabelNumReservation.Visible = True
            GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")
            'We set back the value to false
            GlobalVariable.ComingFromPlanning = False

        End If

        If Not GlobalVariable.chambreOuSalleFromFrontDesk = "" Then

            'ON ne peut mettre que ceux qui sont libre propre
            Dim chambre As DataTable = Functions.getElementByCode(GlobalVariable.chambreOuSalleFromFrontDesk, "chambre", "CODE_CHAMBRE")

            'We want to attribute the code of the romm that was select in the room list coming from the frontdesk
            If chambre.Rows.Count > 0 Then

                Dim chambreId As Integer = 0
                Integer.TryParse(chambre.Rows(0)("ID_CHAMBRE"), chambreId)
                GlobalVariable.idChambre = chambreId
                GlobalVariable.codeChambre = chambre.Rows(0)("CODE_CHAMBRE").ToString
                GunaTextBoxNumeroChambre.Text = chambre.Rows(0)("CODE_CHAMBRE").ToString
                GunaTextBoxLibelleChambre.Text = chambre.Rows(0)("LOCALISATION").ToString
                'GunaTextBoxSuperficie.Text = chambre.Rows(0)("SUPERFICIE").ToString
                'GunaTextBoxSuperficie.Text = chambre.Rows(0)("CAPACITE").ToString

                GunaDataGridViewRoom.Visible = False

            End If

            GlobalVariable.chambreOuSalleFromFrontDesk = ""

        End If

        If GlobalVariable.addCategorieFromFrontOffice Then

            ' We add the information obtained after a double click on the Room Type Categorie list

            If Not GlobalVariable.CategorieAddedFromFrontOffice Is Nothing Then

                If GlobalVariable.CategorieAddedFromFrontOffice.Rows.Count > 0 Then

                    GunaTextBoxCodeTypeDeChambre.Text = GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("CODE_TYPE_CHAMBRE")

                    GunaTextBoxLibelleTYpe.Text = GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("LIBELLE_TYPE_CHAMBRE")

                    Dim PrixAffiche As Double = 0
                    Double.TryParse(GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("PRIX"), PrixAffiche)
                    GunaTextBoxpPrixAffiche.Text = Format(PrixAffiche, "#,##0")

                    Dim prixAccorde As Double = 0
                    'Double.TryParse(GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("PRIX"), prixAccorde)

                    Dim prix As Double = 0

                    If GunaCheckBoxDayUse.Checked Then
                        prix = Double.Parse(GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("MONTANT_SIESTE"))
                    Else
                        prix = Double.Parse(GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("PRIX"))
                    End If

                    prixAccorde = prix

                    GunaTextBoxpPrixAffiche.Text = Format(Double.Parse(prix), "#,##0")
                    'LE PRIX DU TYPE DE CHAMBRE NE DOIT PAS MODIFIER LE PRIX DE VENTE (0) EN CAS DE GRATUITEE

                    If GunaCheckBoxGratuitee.Checked Then
                        If GunaCheckBoxGratuiteInfo.Checked Then
                            If Not Trim(GunaTextBoxAuthoriseePar.Text).Equals("") Then
                                prixAccorde = 0
                            End If
                        End If
                    End If

                    GunaTextBoxMontantAccorde.Text = Format(prixAccorde, "#,##0")
                    'GunaTextBoxCodeType.Text = GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("CODE_TYPE_CHAMBRE")

                    If GlobalVariable.typeChambreOuSalle = "salle" Then

                        GunaTextBoxMontantAfficherSalle.Text = Format(GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("PRIX"), "#,##0")
                        GunaTextBoxMontantReelSalle.Text = Format(GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("PRIX"), "#,##0")
                        GunaTextBoxSuperficie.Text = Format(GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("SUPERFICIE"), "#,##0")
                        GunaTextBoxCapacite.Text = Format(GlobalVariable.CategorieAddedFromFrontOffice.Rows(0)("CAPACITE"), "#,##0")

                    End If

                End If

            End If

            'GunaTextBoxNumeroChambre.BaseColor = Color.White
            GunaTextBoxNumeroChambre.Enabled = True

            GunaTextBoxNumeroChambre.Text = ""
            GunaTextBoxLibelleChambre.Text = ""

            GlobalVariable.addCategorieFromFrontOffice = False

        End If

        'Refreshing the value of the Solde 
        If Not GlobalVariable.codeClientToUpdate = "" Then


            GunaLabelSolde.Text = Format(Functions.SituationDeReservation(GunaLabelNumReservation.Text), "#,##0")

            'We print the reservation  number or code
            GunaLabelNumReservation.Visible = True
            GunaLabelNumReservation.Text = GlobalVariable.codeReservationToUpdate
            GunaLabelNumReservation.Refresh()

        End If

        If GlobalVariable.addUserFromFrontOffice Then

            FillingFormFromNewlyCreatedUserData()

            GlobalVariable.addUserFromFrontOffice = False

        End If

        'We activated the main form as we come from MainCouranteJournaliere
        If (GlobalVariable.fromMainCouranteJournaliereToFrontOffice) Then

            TabControlHbergement.SelectedIndex = 0

            affectingValuesToFields()

            GunaDataGridViewRoomType.Visible = False

            'We set the value that permit to know that we come fron MainCouranteJournaliere to Default
            GlobalVariable.fromMainCouranteJournaliereToFrontOffice = False

        End If

        Dim solde As Double = 0

        Double.TryParse(GunaLabelSolde.Text, solde)

        If 0 > solde Then
            GunaLabelSolde.ForeColor = Color.Red
        ElseIf solde = 0 Then
            GunaLabelSolde.ForeColor = Color.Black
        Else
            GunaLabelSolde.ForeColor = Color.Green
        End If

        GunaDataGridViewRoomType.Visible = False
        GunaDataGridViewClient.Visible = False
        GunaDataGridViewRoom.Visible = False
        GunaDataGridViewPhone.Visible = False

    End Sub

    'Update the amount when ever the arhes (Avances) changes
    Private Sub GunaTextBoxAvance_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxAvance.TextChanged

        'We automatically field information of the newly registered client
        ReservationMoneyCalculation()

    End Sub

    'END OF FILLING OF FORM FOR REGISTRATION

    '-------------------------------------------------- CHECKIN MANAGEMENT BUTTON ------------------------------------------------------
    Dim web As New WebBrowser
    Dim web0 As New WebBrowser
    Dim web1 As New WebBrowser
    Dim web2 As New WebBrowser
    Dim web3 As New WebBrowser
    Dim web4 As New WebBrowser

    Private Sub miseAjourDeRegelementApresCreationDeMainCourante(ByVal NUM_RESERVATION As String, ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, Optional ByVal DEPOSIT_YES_NO As Integer = 0)

        'ON DOIT VERIFIER SI LA RESERVATION DONT ON CREEE LA LIGNE DE MAINCOURANTE EST ASSOCIE A UN REGLEMENT EN ESPECE FAITE LORS DE LA RESA

        If DEPOSIT_YES_NO = 0 Then


        End If

        Dim ensembleDesReglementsPasse As DataTable = Functions.getElementByCode(NUM_RESERVATION, "reglement", "CODE_RESERVATION")

        Dim MONTANT_VERSE As Double = 0

        If ensembleDesReglementsPasse.Rows.Count > 0 Then

            Dim encaissementPasse As Double = 0

            Dim FIELDVALUE As Double = 0

            Dim TABLE_TO_UPDATE As String = ""
            TABLE_TO_UPDATE = "main_courante_journaliere"
            Dim FIELD_TO_UPDATE As String = ""
            Dim MODE_REGLEMENT_PASSE As String = ""

            For i = 0 To ensembleDesReglementsPasse.Rows.Count - 1

                MONTANT_VERSE = ensembleDesReglementsPasse.Rows(i)("MONTANT_VERSE")
                MODE_REGLEMENT_PASSE = ensembleDesReglementsPasse.Rows(i)("MODE_REGLEMENT")

                FIELD_TO_UPDATE = ReglementForm.champEncaissementAMettreAjours(MODE_REGLEMENT_PASSE)

                Dim mainCourantes As New MainCourantes()

                If DEPOSIT_YES_NO = 1 Then

                    FIELD_TO_UPDATE = "ARRHES"

                    'ON MET A JOURS L'ARRHES (DEPOSIT) POUR EQUILIBRER LE MONTANT A REPORTER
                    mainCourantes.UpdateArrhesMainCourante(CODE_MAIN_COURANTE_JOURNALIERE, TABLE_TO_UPDATE, FIELD_TO_UPDATE, MONTANT_VERSE)

                ElseIf DEPOSIT_YES_NO = 0 Then
                    mainCourantes.updateMainCouranteJournaliereModeReglement(CODE_MAIN_COURANTE_JOURNALIERE, TABLE_TO_UPDATE, FIELD_TO_UPDATE, MONTANT_VERSE)
                    If CDate(ensembleDesReglementsPasse.Rows(i)("DATE_REGLEMENT")).ToShortDateString < CDate(GlobalVariable.DateDeTravail).ToShortDateString Then
                        Functions.updateOfFields(TABLE_TO_UPDATE, FIELD_TO_UPDATE, MONTANT_VERSE * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)
                    End If
                End If

            Next

        End If

    End Sub

    Private Sub GunaButtonCheckIn_Click(sender As Object, e As EventArgs) Handles GunaButtonCheckIn.Click

        Dim facturationAnticipe As Boolean = True
        'On doit vérifier que la date de sortie n'est jamais inférieure a la date de travail
        Dim dayDiff = CType((GlobalVariable.DateDeTravail - GunaDateTimePickerDepart.Value).TotalHours, Int32)

        If dayDiff > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir vérifier la da de départ", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please check the departure date", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            If GunaComboBoxSourceReservation.SelectedIndex = -1 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Bien vouloir choisir une source de réservation", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Please select a reservation source", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else

                If GunaTextBoxNbrePersonne.Text > 0 Then

                    Dim CHAMBRE_ID As String = ""

                    If Not Trim(GunaTextBoxNumeroChambre.Text) = "" Then
                        CHAMBRE_ID = Trim(GunaTextBoxNumeroChambre.Text)
                    Else
                        CHAMBRE_ID = "-"
                    End If

                    If Not Functions.clientDejaEnChambre(CHAMBRE_ID) Then

                        Dim messageDeConfirmation As String = ""
                        GlobalVariable.duplicationDeReservation = False

                        'DAY USE ou SEJOURS

                        If GunaCheckBoxDayUse.Checked Then

                            If GlobalVariable.actualLanguageValue = 1 Then
                                messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Type de Chambre : " & GunaTextBoxLibelleTYpe.Text & "; N° Chambre : " & GunaTextBoxNumeroChambre.Text & Chr(13) & " Durée : " & GunaComboBoxHeureArrivee.SelectedItem.ToString & " - " & GunaComboBoxHeureDepart.SelectedItem.ToString & " soit (" & GunaTextBoxTempsAFaire.Text & ") Heure(s)" & Chr(13) & "Tarif réel : " & GunaTextBoxMontantAccorde.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                            Else
                                messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Room Type : " & GunaTextBoxLibelleTYpe.Text & "; Room N° : " & GunaTextBoxNumeroChambre.Text & Chr(13) & " Period : " & GunaComboBoxHeureArrivee.SelectedItem.ToString & " - " & GunaComboBoxHeureDepart.SelectedItem.ToString & " for (" & GunaTextBoxTempsAFaire.Text & ") Hour(s)" & Chr(13) & "Real Price : " & GunaTextBoxMontantAccorde.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                            End If

                        Else

                            If True Then

                                'GESTION DES SALLES
                                Dim nomEvent As String = ""

                                Dim infoSupEvent As DataTable = Functions.getElementByCode(GunaComboBoxEvenement.SelectedValue.ToString, "evenement", "CODE_EVENEMENT")

                                If infoSupEvent.Rows.Count > 0 Then
                                    nomEvent = infoSupEvent.Rows(0)("LIBELLE")
                                End If

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Type de Chambre : " & GunaTextBoxLibelleTYpe.Text & "; N° Chambre : " & GunaTextBoxNumeroChambre.Text & Chr(13) & "Période : " & GunaDateTimePickerArrivee.Value.ToShortDateString & " - " & GunaDateTimePickerDepart.Value.ToShortDateString & " soit (" & GunaTextBoxTempsAFaire.Text & ") Jour(s)" & Chr(13) & "Tarif réel : " & GunaTextBoxMontantAccorde.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

                                Else
                                    messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Room Type : " & GunaTextBoxLibelleTYpe.Text & "; Room N° : " & GunaTextBoxNumeroChambre.Text & Chr(13) & "Period : " & GunaDateTimePickerArrivee.Value.ToShortDateString & " - " & GunaDateTimePickerDepart.Value.ToShortDateString & " i.e" & GunaTextBoxTempsAFaire.Text & ") Day(s)" & Chr(13) & "Real Price : " & GunaTextBoxMontantAccorde.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

                                End If
                            End If

                        End If

                        Dim dialogCheckIn As DialogResult = MessageBox.Show(messageDeConfirmation, "Confirmation de Check In", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                        If dialogCheckIn = DialogResult.OK Then

                            'DEBUT ON SE RASSURE QUE LE NUMERO DE CHAMBRE N'EST PAS VIDE OU EXISTE VRAIMENT -------------------------------------

                            Dim continuer As Boolean = False

                            Dim dialog01 As DialogResult

                            Dim message As String = ""

                            If Trim(GunaTextBoxNumeroChambre.Text).Equals("") Or Trim(GunaTextBoxNumeroChambre.Text).Equals("-") Then

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    message = "Bien vouloir saisir un numéro de chambre !!"
                                Else
                                    message = "please type in a room number !!"
                                End If
                            Else

                                Dim roomInfoSuo As DataTable = Functions.getElementByCode(GunaTextBoxNumeroChambre.Text, "chambre", "CODE_CHAMBRE")

                                If roomInfoSuo.Rows.Count > 0 Then
                                    continuer = True
                                Else

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        message = "Bien vouloir saisir un numéro de chambre valide !!"
                                    Else
                                        message = "please type in a valide room number !!"
                                    End If
                                End If

                            End If

                            If Not continuer Then
                                dialog01 = MessageBox.Show(message, "CheckIn Impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                            'END ON SE RASSURE QUE LE NUMERO DE CHAMBRE N'EST PAS VIDE OU EXISTE VRAIMENT -------------------------------------

                            If continuer Then

                                Me.Cursor = Cursors.WaitCursor

                                Dim CODE_TARIF_RESERVATION As String = ""

                                If GlobalVariable.tarificationDynamiqueActif Then

                                    If GunaComboBoxCodeTarif.SelectedIndex >= 0 Then

                                        If GunaComboBoxCodeTarif.Visible Then

                                            CODE_TARIF_RESERVATION = GunaComboBoxCodeTarif.SelectedValue.ToString()
                                        End If

                                    End If

                                End If

                                Dim TELEPHONE_CLIENT As String = Trim(GunaTextBoxTelClient.Text)
                                Dim EMAIL As String = Trim(GunaTextBoxClientEmail.Text)

                                Dim BC_ENTREPRISE As String = GunaTextBoxBC.Text

                                If Trim(GunaTextBoxMontantCaution.Text) = "" Then
                                    GunaTextBoxMontantCaution.Text = 0
                                End If

                                LabelNatureReservation.Visible = False

                                Dim solde As Double = 0

                                Double.TryParse(GunaLabelSolde.Text, solde)

                                If 0 > solde Then
                                    GunaLabelSolde.ForeColor = Color.Red
                                ElseIf solde = 0 Then
                                    GunaLabelSolde.ForeColor = Color.Black
                                Else
                                    GunaLabelSolde.ForeColor = Color.Green
                                End If

                                'On masque les tarifs associés au client si existe 
                                GunaComboBoxCodeTarif.Visible = False
                                GunaLabelCodeTarif.Visible = False

                                Dim ADULTES As Integer = GunaTextBoxNbreAdulte.Text
                                Dim ENFANTS As Integer = GunaTextBoxNbreEnfant.Text

                                If GunaRadioButtonMailOui.Checked Then
                                    GlobalVariable.RECEVOIR_EMAIL = 1
                                Else
                                    GlobalVariable.RECEVOIR_EMAIL = 0
                                End If

                                If GunaRadioButtonWhatsAppOui.Checked Then
                                    GlobalVariable.RECEVOIR_SMS = 1
                                Else
                                    GlobalVariable.RECEVOIR_SMS = 0
                                End If

                                Dim DAY_USE As Integer = 0

                                If GunaCheckBoxDayUse.Checked Then
                                    DAY_USE = 1
                                End If

                                Dim MENSUEL As Integer = 0

                                Dim HEBDOMADAIRE As Integer = 0

                                Dim CLIENT_ID As String = GunaTextBoxRefClient.Text

                                Dim UTILISATEUR_ID As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                                Dim AGENCE_ID As String = GlobalVariable.codeAgence

                                Dim NOM_CLIENT As String = Trim(GunaTextBoxNomPrenom.Text)

                                'ROUTAGE PETIT DEJEUNER
                                Dim PETIT_DEJEUNER_ROUTAGE As Double = 0

                                If GunaCheckBoxPetitDejRoutage.Checked Then
                                    Dim pdjRoutage As Double = 0
                                    Double.TryParse(GunaTextBoxPetitDejeunerRoutage.Text, pdjRoutage)
                                    PETIT_DEJEUNER_ROUTAGE = pdjRoutage
                                End If

                                'ROUTAGE LOGEMENT
                                Dim CHAMBRE_ROUTAGE As String = ""

                                If GunaCheckBoxChambreRoutage.Checked Then
                                    If GunaComboBoxChambreRoutage.SelectedIndex >= 0 Then
                                        CHAMBRE_ROUTAGE = GunaComboBoxChambreRoutage.SelectedValue.ToString
                                    End If
                                End If

                                Dim ETAT_NOTE_RESERVATION As String


                                If GlobalVariable.typeChambreOuSalle = "chambre" Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        ETAT_NOTE_RESERVATION = "EN CHAMBRE"

                                    Else
                                        ETAT_NOTE_RESERVATION = "IN HOUSE"

                                    End If

                                ElseIf GlobalVariable.typeChambreOuSalle = "salle" Then

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        ETAT_NOTE_RESERVATION = "EN SALLE"

                                    Else
                                        ETAT_NOTE_RESERVATION = "IN HALL"
                                    End If

                                End If

                                Dim ROUTAGE As String = ""

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    ROUTAGE = "NON"
                                Else
                                    ROUTAGE = "NO"
                                End If

                                If GunaCheckBoxChambreRoutage.Checked Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        ROUTAGE = "OUI"
                                    Else
                                        ROUTAGE = "YES"
                                    End If
                                End If

                                Dim SOURCE_RESERVATION As String = ""

                                If GunaComboBoxSourceReservation.SelectedIndex >= 0 Then
                                    SOURCE_RESERVATION = GunaComboBoxSourceReservation.SelectedValue.ToString
                                End If

                                Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxCodeEntrepriseDuClient.Text)
                                Dim NOM_ENTREPRISE As String = Trim(GunaTextBoxEntrepriseDuclient.Text)

                                Dim VENANT_DE As String = GunaTextBoxVenantDe.Text
                                Dim SE_RENDANT_A As String = GunaTextBoxSerendantA.Text
                                Dim RAISON As String = GunaComboBoxTypeReservation.SelectedItem.ToString

                                If Trim(GunaTextBoxPetitDejeuner.Text) = "" Then
                                    GunaTextBoxPetitDejeuner.Text = 0
                                End If

                                Dim PETIT_DEJEUNER As Double = GunaTextBoxPetitDejeuner.Text

                                Dim AFFICHER_PRIX As Integer = 1

                                If Not GunaCheckBoxAfficherPrix.Checked Then
                                    AFFICHER_PRIX = 0
                                End If

                                Dim BFK_COST As Double = 0
                                If Not Trim(GunaTextBoxBreakFastCost.Text).Equals("") Then
                                    BFK_COST = GunaTextBoxBreakFastCost.Text
                                End If

                                '----------------- dates obtained when ever the resting days change
                                'working perfectly
                                Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.SelectedItem

                                Dim DateTimeDepartStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureDepart.SelectedItem

                                Dim DateTimeArrivee As DateTime = DateTime.ParseExact(DateTimeArriveeStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
                                Dim DateTimeDepart As DateTime = DateTime.ParseExact(DateTimeDepartStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)

                                'Dim DATE_ENTTRE As Date = GlobalVariable.DATE_ENTTRE
                                Dim DATE_ENTTRE As Date = GunaDateTimePickerArrivee.Value.ToShortDateString
                                Dim HEURE_ENTREE As String = DateTimeArrivee
                                'Dim DATE_SORTIE As Date = GlobalVariable.DATE_SORTIE
                                Dim DATE_SORTIE As Date = GunaDateTimePickerDepart.Value.ToShortDateString
                                Dim HEURE_SORTIE As String = DateTimeDepart

                                Dim TYPE_CHAMBRE_OU_SALLE As String = "salle"

                                If GunaRadioButtonMailOui.Checked Then
                                    GlobalVariable.RECEVOIR_EMAIL = 1
                                End If

                                If Trim(GunaTextBoxNbrePersonne.Text) = "" Then
                                    GunaTextBoxNbrePersonne.Text = 0
                                End If

                                Dim NB_PERSONNES As Integer = GunaTextBoxNbrePersonne.Text
                                Dim RECEVOIR_EMAIL As Integer = GlobalVariable.RECEVOIR_EMAIL
                                Dim RECEVOIR_SMS As Integer = GlobalVariable.RECEVOIR_SMS
                                Dim ETAT_RESERVATION As Integer = 1
                                Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
                                Dim HEURE_CREATION As DateTime = DateTime.Now().ToString("hh:mm:ss")
                                Dim MONTANT_TOTAL_CAUTION As Double = GunaTextBoxMontantCaution.Text
                                Dim MOTIF_ETAT As String = ""
                                Dim DATE_ETAT As Date = GlobalVariable.DateDeTravail
                                Dim MONTANT_ACCORDE As Double = 0

                                Dim DEBUT_HEURE As Date = CDate(DateTimeArrivee).ToShortTimeString
                                Dim FIN_HEURE As Date = CDate(DateTimeDepart).ToShortTimeString

                                Dim NOMBRE_HEURE As Integer = 1

                                If GunaCheckBoxDayUse.Checked Then
                                    NOMBRE_HEURE = CType((FIN_HEURE - DEBUT_HEURE).TotalHours, Int32)
                                End If

                                If GlobalVariable.typeChambreOuSalle = "salle" Then
                                    If Not Trim(GunaTextBoxMontantReelSalle.Text) = "" Then
                                        MONTANT_ACCORDE = Double.Parse(GunaTextBoxMontantReelSalle.Text) * NOMBRE_HEURE
                                    End If
                                ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then
                                    If Not Trim(GunaTextBoxMontantAccorde.Text) = "" Then
                                        MONTANT_ACCORDE = Double.Parse(GunaTextBoxMontantAccorde.Text) * NOMBRE_HEURE
                                    End If
                                End If

                                Dim updatedSolde As Double = 0

                                'RESERVATION DE GROUPE
                                Dim GROUPE As String = ""

                                If GunaCheckBoxReservationDeGroupe.Checked Then
                                    GROUPE = Trim(GunaTextBoxCodeDeGroupe.Text)
                                End If

                                'Dim CODE_RESERVATION = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")
                                Dim CODE_RESERVATION = GunaLabelNumReservation.Text

                                Dim reservation As New Reservation()
                                Dim mainCourante As New MainCourantes()
                                Dim reglement As New Reglement()
                                Dim occupationChambre As New OccupationChambre()
                                Dim facture As New Facture()

                                Dim compte As New Compte()
                                Dim caisse As New Caisse()

                                'Inserting a new reservation after checking that the reservation does not already exist

                                ' variables declarations 

                                '-------------------------------- OCCUPATION CHAMBRE ------------------------------
                                Dim CODE_OCCUPATION_CHAMBRE = Functions.GeneratingRandomCodeWithSpecifications("occupation_chambre", "OC")
                                Dim MONTANT_HT As Double = MONTANT_ACCORDE
                                Dim TAXE As Double = 0
                                Dim MONTANT_TTC As Double = 0
                                Dim DATE_OCCUPATION As Date = DATE_ENTTRE
                                'Dim OBSERVATIONS As String =""
                                Dim COMMENTAIRE1 As String = ""
                                Dim COMMENTAIRE2 As String = ""
                                Dim COMMENTAIRE3 As String = ""
                                Dim COMMENTAIRE4 As String = ""
                                Dim DATE_LIBERATION As Date = DATE_SORTIE
                                Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                Dim DATE_PREMIERE_ARRIVEE As Date = DATE_ENTTRE
                                Dim TYPE_RESERVATION As String = ""
                                Dim PDJ_INCLUS As String = ""
                                Dim TAXE_SEJOURS_INCLUS As String = ""
                                Dim TVA_INCLUS As String = ""
                                Dim CODE_CLIENT_REEL As String = CLIENT_ID

                                '------------------------------- REGLEMENT ----------------------------------------------

                                If GunaTextBoxDepotDeGarantie.Text = "" Then
                                    GunaTextBoxDepotDeGarantie.Text = 0
                                End If

                                Dim DEPOT_DE_GARANTIE As Double = Double.Parse(GunaTextBoxDepotDeGarantie.Text)

                                'Dim NUM_REGLEMENT As String = Functions.GeneratingRandomCode("reglement", "RGL")
                                Dim NUM_FACTURE As String = ""
                                Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                Dim montantVerse As Double = 0
                                Double.TryParse(GunaTextBoxAvance.Text, montantVerse)
                                Dim MONTANT_VERSE As Double = montantVerse
                                Dim DATE_REGLEMENT As Date = GlobalVariable.DateDeTravail

                                Dim MODE_REGLEMENT As String = ""
                                Dim REF_REGLEMENT As String = ""

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MODE_REGLEMENT = "Garantie"
                                    REF_REGLEMENT = "DEPOT DE GARANTIE DE " & "[" & NOM_CLIENT & " / " & CHAMBRE_ID & "]"
                                Else
                                    MODE_REGLEMENT = "Guarantee"
                                    REF_REGLEMENT = "GURANTEE DEPOSIT OF " & "[" & NOM_CLIENT & " / " & CHAMBRE_ID & "]"
                                End If

                                Dim CODE_MODE As String = ""
                                Dim IMPRIMER As Double = 0

                                Dim NUMERO_BLOC_NOTE = ""
                                Dim MODE_REG_INFO_SUP_1 = ""
                                Dim MODE_REG_INFO_SUP_2 = ""
                                Dim MODE_REG_INFO_SUP_3 = ""

                                '----------- MAIN COURANTES ------------------------------
                                Dim CODE_MAIN_COURANTE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante", "MC")
                                Dim CODE_CLIENT As String = GlobalVariable.codeClient
                                Dim CODE_CHAMBRE As String = GlobalVariable.codeChambre
                                Dim ETAT_CHAMBRE As String = 1
                                Dim CODE_AGENCE As String = AGENCE_ID

                                '----------- MAIN COURANTE GENERALE ------------------------------

                                Dim CODE_MAIN_COURANTE_GENERALE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante_generale", "MCG")
                                Dim DATE_MAIN_COURANTE As Date = GlobalVariable.DateDeTravail
                                Dim PDJ_FOOD As Double = 0
                                Dim PDJ_BOISSON As Double = 0
                                Dim DEJEUNER_FOOD As Double = 0
                                Dim DEJEUNER_BOISSON As Double = 0
                                Dim DINER_FOOD As Double = 0
                                Dim DINER_BOISSON As Double = 0
                                Dim BANQUET_FOOD As Double = 0
                                Dim BANQUET_BOISSON As Double = 0
                                Dim BAR_MATIN As Double = 0
                                Dim BAR_SOIR As Double = 0
                                Dim DIVERS As Double = 0

                                Dim TAUX_OCCUPATION_PCT As Double = 0 'TAUX_OCCUPATION_PCT USED AS TAXE DE SEJOUR
                                Dim POSTER_TAX As Double = 0

                                If GunaCheckBoxTaxeSejour.Checked Then
                                    If Not Trim(GunaTextBoxTaxeSejour.Text).Equals("") Then
                                        TAUX_OCCUPATION_PCT = GunaTextBoxTaxeSejour.Text
                                        POSTER_TAX = GunaTextBoxTaxeSejour.Text
                                    End If
                                Else
                                    Functions.DeleteElementByCode(CODE_RESERVATION, "taxe_sejour_collectee", "NUM_RESERVATION")
                                End If

                                Dim TOTAL_JOUR As Double = MONTANT_ACCORDE + TAUX_OCCUPATION_PCT
                                Dim REPORT_VEILLE As Double = 0
                                Dim TOTAL_GENERAL As Double = MONTANT_ACCORDE + TAUX_OCCUPATION_PCT
                                Dim NUM_RESERVATION = CODE_RESERVATION
                                Dim DEDUCTION As Double = 0
                                Dim ENCAISSEMENT_ESPECE As Double = 0
                                Dim ENCAISSEMENT_CHEQUE As Double = 0
                                Dim ENCAISSEMENT_CARTE_CREDIT As Double = 0
                                Dim A_REPORTER As Double = (MONTANT_ACCORDE + TAUX_OCCUPATION_PCT) * -1
                                Dim OBSERVATIONS As String = ""
                                Dim TYPE_CHAMBRE As String = GunaTextBoxCodeTypeDeChambre.Text
                                Dim INDICE_FREQUENTATION As Double = 0
                                Dim INDICE_FREQUENTATION_PCT As Double = 0
                                Dim TAUX_OCCUPATION As Double = 0

                                Dim CLIENTS_ATTENDUS As Integer = 0
                                Dim CLIENTS_EN_CHAMBRE As Integer = GunaTextBoxNbrePersonne.Text
                                Dim CHAMBRES_DISPONIBLES As Integer = 0
                                Dim TOTAL_HORS_SERVICE As Integer = 0
                                Dim CHAMBRES_HORS_SERVICE As Integer = 0
                                Dim TOTAL_FICTIVES As Integer = 0
                                Dim CHAMBRES_FICTIVES As Integer = 0
                                Dim NOMBRE_MESSAGES As Integer = 0
                                Dim TOTAL_GRATUITES As Double = 0
                                Dim CHAMBRES_GRATUITES As Integer = 0
                                Dim TOTAL_NON_FACTUREES As Double = 0
                                Dim CHAMBRES_NON_FACTUREES As Integer = 0

                                '----------- MAIN COURANTE JOURNALIERE ------------------------------

                                Dim CODE_MAIN_COURANTE_JOURNALIERE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante_journaliere", "MCJ")
                                Dim PDJ As Double = 0
                                Dim DEJEUNER As Double = 0
                                Dim DINER As Double = 0
                                Dim CAFE As Double = 0
                                Dim BAR As Double = 0
                                Dim CAVE As Double = 0
                                Dim AUTRE As Double = 0

                                Dim SOUS_TOTAL1 As Double = 0

                                If GunaCheckBoxPetitDejeuenerInclus.Checked Then

                                    Dim petitDejeuner As Double = 0
                                    Double.TryParse(GunaTextBoxPetitDejeuner.Text, petitDejeuner)
                                    SOUS_TOTAL1 = petitDejeuner 'On gère les taxes séjours par apport la valeur SOUS_TOTAL1 de la main courante journaliere

                                End If

                                Dim Location As Double = 0
                                Dim TELE As Double = 0
                                Dim FAX As Double = 0
                                Dim LINGE As Double = 0
                                Dim SOUS_TOTAL2 As Double = 0
                                Dim DEBITEUR As Double = 0
                                Dim ARRHES As Double = 0

                                '------------------------------- compte -----------------------------

                                Dim INTITULE As String = ""
                                Dim NUMERO_COMPTE As String = ""
                                Dim TOTAL_DEBIT As Double = GlobalVariable.MONTANT_TOTAL
                                Dim TOTAL_CREDIT As Double = GlobalVariable.avance
                                Dim SOLDE_COMPTE As Double = TOTAL_CREDIT - TOTAL_DEBIT

                                Dim SENS_DU_SOLDE As String = ""

                                If (TOTAL_DEBIT < TOTAL_CREDIT) Then
                                    SENS_DU_SOLDE = "crediteur+++++++++++++++++++++"
                                ElseIf (TOTAL_CREDIT < TOTAL_DEBIT) Then
                                    SENS_DU_SOLDE = "debiteur++++++++++++++++++++++"
                                Else
                                    SENS_DU_SOLDE = "equilibre+++++++++++++++++++++"
                                End If

                                Dim TYPE_DE_COMPTE As String = "debiteur"

                                '--------------------------- FORFAIT SALLE

                                Dim nbreCafe As Integer = 0
                                Dim cafePu As Double = 0
                                Dim dejeunerNbre As Integer = 0
                                Dim dejeunerPu As Double = 0
                                Dim dinerNbre As Integer = 0
                                Dim dinerPu As Double = 0
                                Dim traiteurNbre As Integer = 0
                                Dim traiteurPu As Double = 0

                                Double.TryParse(GunaTextBox35.Text, nbreCafe)
                                Double.TryParse(GunaTextBoxForfaitCafe.Text, cafePu)
                                Double.TryParse(GunaTextBox30.Text, dejeunerNbre)
                                Double.TryParse(GunaTextBoxForfatiDejeuner.Text, dejeunerPu)
                                Double.TryParse(GunaTextBox25.Text, dinerNbre)
                                Double.TryParse(GunaTextBoxForfaitDiner.Text, dinerPu)
                                Double.TryParse(GunaTextBox13.Text, traiteurNbre)
                                Double.TryParse(GunaTextBoxForfaitTraiteur.Text, traiteurPu)

                                Dim NBRE__CAFE = nbreCafe
                                Dim PU_CAFE = cafePu
                                Dim NBRE_DEJEUNER = dejeunerNbre
                                Dim PU_DEJEUNER = dejeunerPu
                                Dim NBRE_DINER = dinerNbre
                                Dim PU_DINER = dinerPu
                                Dim NBRE_TRAITEUR = traiteurNbre
                                Dim PU_TRAITEUR = traiteurPu
                                Dim decorationCast As Double = 0
                                Double.TryParse(GunaTextBoxDecoration.Text, decorationCast)
                                Dim DECORATION = decorationCast

                                Dim LOCATION_MATERIEL As Double = 0
                                Dim AUTRES As Double = 0

                                If Not Trim(GunaTextBoxMateriel.Text) = "" Then
                                    LOCATION_MATERIEL = GunaTextBoxMateriel.Text
                                End If

                                If Not Trim(GunaTextBoxAutres.Text) = "" Then
                                    AUTRES = GunaTextBoxAutres.Text
                                End If

                                Dim CODE_EVENEMENT = ""
                                Dim LIBELLE_EVENEMENT = ""

                                If GunaComboBoxEvenement.SelectedIndex >= 0 Then
                                    CODE_EVENEMENT = GunaComboBoxEvenement.SelectedValue

                                    Dim evenement As DataTable = Functions.getElementByCode("CODE_EVENEMENT", "evenement", "CODE_EVENEMENT")

                                    If evenement.Rows.Count > 0 Then
                                        LIBELLE_EVENEMENT = evenement.Rows(0)("evenement")
                                    End If

                                End If

                                Dim NBRE_GOUTER As Integer = 0
                                Dim PU_GOUTER As Double = 0
                                Dim NBRE_COCKTAIL As Integer = 0
                                Dim PU_COCKTAIL As Double = 0

                                If Not Trim(GunaTextBoxQteGouter.Text) = "" Then
                                    NBRE_GOUTER = GunaTextBoxQteGouter.Text
                                End If

                                If Not Trim(GunaTextBoxPrixGouter.Text) = "" Then
                                    PU_GOUTER = GunaTextBoxPrixGouter.Text
                                End If

                                If Not Trim(GunaTextBoxCocktail.Text) = "" Then
                                    NBRE_COCKTAIL = GunaTextBoxCocktail.Text
                                End If

                                If Not Trim(GunaTextBoxPUCocktail.Text) = "" Then
                                    PU_COCKTAIL = GunaTextBoxPUCocktail.Text
                                End If

                                '------------------------------- addition ---------------------------------------------------------

                                Dim HEURE_PAUSE_CAFE As String = ""
                                If GunaComboBoxHeureCafe.SelectedIndex >= 0 Then
                                    HEURE_PAUSE_CAFE = GunaComboBoxHeureCafe.SelectedItem
                                End If

                                Dim HEURE_PAUSE_DEJEUNER As String = ""
                                If GunaComboBoxHeureDej.SelectedIndex >= 0 Then
                                    HEURE_PAUSE_DEJEUNER = GunaComboBoxHeureDej.SelectedItem
                                End If

                                Dim HEURE_DINER As String = ""
                                If GunaComboBoxHeureDiner.SelectedIndex >= 0 Then
                                    HEURE_DINER = GunaComboBoxHeureDiner.SelectedItem
                                End If

                                Dim HEURE_GOUTER As String = ""
                                If GunaComboBoxHeureGouter.SelectedIndex >= 0 Then
                                    HEURE_GOUTER = GunaComboBoxHeureGouter.SelectedItem
                                End If

                                Dim HEURE_COCKTAIL As String = ""
                                If GunaComboBoxHeureCocktail.SelectedIndex >= 0 Then
                                    HEURE_COCKTAIL = GunaComboBoxHeureCocktail.SelectedItem
                                End If

                                Dim VIDEO_PROJ As Integer = 0
                                If GunaCheckBoxVidOui.Checked Then
                                    VIDEO_PROJ = 1
                                ElseIf GunaCheckBoxVidNon.Checked Then
                                    VIDEO_PROJ = 0
                                Else
                                    VIDEO_PROJ = 0
                                End If

                                Dim SONO As Integer = 0
                                If GunaCheckBoxSonoOui.Checked Then
                                    SONO = 1
                                ElseIf GunaCheckBoxSonoNon.Checked Then
                                    SONO = 0
                                Else
                                    SONO = 0
                                End If

                                Dim COUVERTS As Integer = 0
                                If GunaCheckBoxCouvOui.Checked Then
                                    COUVERTS = 1
                                ElseIf GunaCheckBoxCouvNon.Checked Then
                                    COUVERTS = 0
                                Else
                                    COUVERTS = 0
                                End If

                                Dim TABLE_CHAISE As Integer = 0
                                If GunaCheckBoxTableOui.Checked Then
                                    TABLE_CHAISE = 1
                                ElseIf GunaCheckBoxTableNon.Checked Then
                                    TABLE_CHAISE = 0
                                Else
                                    TABLE_CHAISE = 0
                                End If

                                Dim EAU_PTE_QTE As Integer = 0
                                If Not Trim(GunaTextBox47.Text) = "" Then
                                    EAU_PTE_QTE = GunaTextBox47.Text
                                End If

                                Dim EAU_PTE_MONTANT As Double = 0
                                If Not Trim(GunaTextBoxMontantEauPetiteBouteille.Text) = "" Then
                                    EAU_PTE_MONTANT = GunaTextBoxMontantEauPetiteBouteille.Text
                                End If

                                Dim EAU_GRDE_QTE As Integer = 0
                                If Not Trim(GunaTextBox10.Text) = "" Then
                                    EAU_GRDE_QTE = GunaTextBox10.Text
                                End If

                                Dim EAU_GRDE_MONTANT As Double = 0
                                If Not Trim(GunaTextBox68.Text) = "" Then
                                    EAU_GRDE_MONTANT = GunaTextBox68.Text
                                End If

                                Dim BOISSONS_GAZEUSES_QTE As Integer = 0
                                If Not Trim(GunaTextBox48.Text) = "" Then
                                    BOISSONS_GAZEUSES_QTE = GunaTextBox48.Text
                                End If

                                Dim BOISSONS_GAZEUSES_MONTANT As Double = 0
                                If Not Trim(GunaTextBox62.Text) = "" Then
                                    BOISSONS_GAZEUSES_MONTANT = GunaTextBox62.Text
                                End If

                                Dim BIERES_QTE As Integer = 0
                                If Not Trim(GunaTextBox50.Text) = "" Then
                                    BIERES_QTE = GunaTextBox50.Text
                                End If

                                Dim BIERES_MONTANT As Double = 0
                                If Not Trim(GunaTextBox61.Text) = "" Then
                                    BIERES_MONTANT = GunaTextBox61.Text
                                End If

                                Dim VIN_ROUGE_QTE As Integer = 0
                                If Not Trim(GunaTextBox54.Text) = "" Then
                                    VIN_ROUGE_QTE = GunaTextBox54.Text
                                End If

                                Dim VIN_ROUGE_MONTANT As Double = 0
                                If Not Trim(GunaTextBox59.Text) = "" Then
                                    VIN_ROUGE_MONTANT = GunaTextBox59.Text
                                End If

                                Dim VIN_ROSE_QTE As Integer = 0
                                If Not Trim(GunaTextBox63.Text) = "" Then
                                    VIN_ROSE_QTE = GunaTextBox63.Text
                                End If

                                Dim VIN_ROSE_MONTANT As Double = 0
                                If Not Trim(GunaTextBox64.Text) = "" Then
                                    VIN_ROSE_MONTANT = GunaTextBox64.Text
                                End If

                                Dim BOISSONS_EXT_QTE As Integer = 0
                                If Not Trim(GunaTextBox36.Text) = "" Then
                                    BOISSONS_EXT_QTE = GunaTextBox36.Text
                                End If

                                Dim BOISSONS_EXT_MONTANT As Double = 0
                                If Not Trim(GunaTextBox57.Text) = "" Then
                                    BOISSONS_EXT_MONTANT = GunaTextBox57.Text
                                End If

                                Dim DROIT_DE_BOUCHON As Double = 0
                                If Not Trim(GunaTextBoxDroitDeBouchon.Text) = "" Then
                                    DROIT_DE_BOUCHON = GunaTextBoxDroitDeBouchon.Text
                                End If

                                Dim MISE_EN_PLACE As Integer = 0 ' U

                                If GunaCheckBoxU.Checked Then
                                    MISE_EN_PLACE = 1
                                ElseIf GunaCheckBoxEcole.Checked Then
                                    MISE_EN_PLACE = 2 ' Ecole
                                ElseIf GunaCheckBoxTheatre.Checked Then
                                    MISE_EN_PLACE = 3 ' Theatre
                                ElseIf GunaCheckBoxRectangle.Checked Then
                                    MISE_EN_PLACE = 4 ' Rectangle
                                ElseIf GunaCheckBoxCocktail.Checked Then
                                    MISE_EN_PLACE = 5 'Cocktail
                                ElseIf GunaCheckBoxBanquet.Checked Then
                                    MISE_EN_PLACE = 6 'Banquet
                                End If

                                Dim CLOISONNEMENT As Integer = 0
                                If GunaCheckBox2.Checked Then
                                    CLOISONNEMENT = 2
                                ElseIf GunaCheckBox9.Checked Then
                                    CLOISONNEMENT = 3 ' Ecole
                                Else
                                    CLOISONNEMENT = 0
                                End If
                                '--------------------------------------------------------------------------------------------------

                                Dim reservationConf As New Reservation()

                                'CHECKIN DIRECT CAR ON A AUCUNE EXISTENCE DE LA RESA

                                '-------------------------------------- MOUCHARDS ---------------------------------------------------
                                Dim ACTION As String = ""

                                If GunaCheckBoxDayUse.Checked Then

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        ACTION = "CHECKIN [CHAMBRE " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " DU " & DEBUT_HEURE & " - " & FIN_HEURE & "]"

                                    Else
                                        ACTION = "CHECKIN [ROOM " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " FROM " & DEBUT_HEURE & " - " & FIN_HEURE & "]"

                                    End If
                                Else

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        ACTION = "CHECKIN [CHAMBRE " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " DU " & DATE_ENTTRE & " - " & DATE_SORTIE & "]"

                                    Else
                                        ACTION = "CHECKIN [ROOM " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " FROM " & DATE_ENTTRE & " - " & DATE_SORTIE & "]"

                                    End If
                                End If

                                User.mouchard(ACTION)
                                '-------------------------------------------------------------------------------------------------------------------------

                                Dim CODE_SUIVI As String = Functions.GeneratingRandomCodeWithSpecifications("suivi_des_reservations", "SVR")
                                Dim RESERVATION_PAR As String = ""
                                Dim CHECKIN_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                Dim CHECKOUT_PAR As String = ""
                                Dim DELOGEMENT_PAR As String = ""

                                '-------------------------------------- TARIFICATION DYNAMIQUE EN UTILISANT UN FICHIER TEXT --------------------------------------------------------------

                                'Dim tarif As New Tarifs

                                If (GlobalVariable.codeReservationToUpdate = "") Then
                                    'CHECKIN DIRECT
                                    If GlobalVariable.tarificationDynamiqueActif Then

                                        Dim DateDebut As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

                                        Dim tarif As New Tarifs

                                        'TRAITEMENT D'UN CKECKIN DIRECT DONC FICHIER TEXT DE TARIFICATION INEXISTANT DONC ON VA LE CREER
                                        tarif.determinationDesMontantPourTouteLaPeriodeDelaReservation(DateDebut, CODE_RESERVATION, CODE_TARIF_RESERVATION, DATE_ENTTRE, DATE_SORTIE, TYPE_CHAMBRE)

                                    End If

                                    'DIRECT CHECKIN
                                    User.suiviDesReservations(CODE_SUIVI, CODE_RESERVATION, RESERVATION_PAR, CHECKIN_PAR, CHECKOUT_PAR, DELOGEMENT_PAR)
                                    Dim operation As Integer = 0 'INSERTION 

                                    gestionDesNavettes(operation, CODE_RESERVATION)

                                    'Direct checkIn as the reservation has not been saved before
                                    'We check if the code of the reservation already exist in the database
                                    If Not Functions.entryCodeExists(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION") Then

                                        If reservationConf.insertReservationConf(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, HEBDOMADAIRE, BC_ENTREPRISE, TYPE_CHAMBRE, TYPE_CHAMBRE_OU_SALLE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE) Then

                                            'FACTURATION ANTICIPE
                                            If facturationAnticipe Then
                                                reservation.facturationEnAvance(CODE_RESERVATION, POSTER_TAX)
                                            End If

                                            Dim TABLE As String = "reserve_conf"

                                            reservation.updatePetitDejeuner(PETIT_DEJEUNER, CODE_RESERVATION, TABLE, AFFICHER_PRIX, BFK_COST)

                                            If GlobalVariable.typeChambreOuSalle = "salle" Then
                                                reservation.insertForfait(CODE_RESERVATION, NBRE__CAFE, PU_CAFE, NBRE_DEJEUNER, PU_DEJEUNER, NBRE_DINER, PU_DINER, NBRE_TRAITEUR, PU_TRAITEUR, DECORATION, LOCATION_MATERIEL, AUTRES, CODE_EVENEMENT, LIBELLE_EVENEMENT, NBRE_GOUTER, PU_GOUTER, NBRE_COCKTAIL, PU_COCKTAIL, HEURE_PAUSE_CAFE, HEURE_PAUSE_DEJEUNER, HEURE_DINER, HEURE_GOUTER, HEURE_COCKTAIL, VIDEO_PROJ, SONO, COUVERTS, TABLE_CHAISE, EAU_PTE_QTE, EAU_PTE_MONTANT, EAU_GRDE_QTE, EAU_GRDE_MONTANT, BOISSONS_GAZEUSES_QTE, BOISSONS_GAZEUSES_MONTANT, BIERES_QTE, BIERES_MONTANT, VIN_ROUGE_QTE, VIN_ROUGE_MONTANT, VIN_ROSE_QTE, VIN_ROSE_MONTANT, BOISSONS_EXT_QTE, BOISSONS_EXT_MONTANT, DROIT_DE_BOUCHON, MISE_EN_PLACE, CLOISONNEMENT)
                                            End If

                                            'We update the checkin button so not to display the checkin button again
                                            reservation.updateReservationConfCheckIn(CODE_RESERVATION)

                                            'We update the room if everythig is ok

                                            '-------------------------- OCCUPATION CHAMBRE--------------------------
                                            If Not Functions.entryCodeExists(CODE_OCCUPATION_CHAMBRE, "occupation_chambre", "CODE_OCCUPATION_CHAMBRE") Then

                                                If occupationChambre.insertOccupationChambre(CODE_OCCUPATION_CHAMBRE, CODE_RESERVATION, CODE_CHAMBRE, MONTANT_HT, TAXE, MONTANT_TTC, DATE_OCCUPATION, ETAT_CHAMBRE, OBSERVATIONS, COMMENTAIRE1, COMMENTAIRE2, COMMENTAIRE3, COMMENTAIRE4, DATE_LIBERATION, CODE_UTILISATEUR_CREA, DATE_PREMIERE_ARRIVEE, TYPE_RESERVATION, PDJ_INCLUS, TAXE_SEJOURS_INCLUS, TVA_INCLUS, CODE_CLIENT_REEL, CODE_AGENCE) Then

                                                End If

                                            End If

                                            '----------- MAIN COURANTES ------------------------------

                                            'We check if the the main courante already exist
                                            If Not Functions.entryCodeExists(CODE_MAIN_COURANTE, "main_courante", "CODE_MAIN_COURANTE") Then

                                                'If mainCourante.insertMainCourante(CODE_MAIN_COURANTE, CODE_CLIENT, CODE_RESERVATION, CODE_CHAMBRE, ETAT_CHAMBRE, ETAT_RESERVATION, DATE_ETAT, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                                'End If

                                            End If

                                            '----------- MAIN COURANTE GENERALE ------------------------------

                                            'We check if the the main courante generale already exist
                                            If Not Functions.entryCodeExists(CODE_MAIN_COURANTE_GENERALE, "main_courante_generale", "CODE_MAIN_COURANTE_GENERALE") Then

                                                'If mainCourante.insertMainCouranteGenerale(CODE_MAIN_COURANTE_GENERALE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ_FOOD, PDJ_BOISSON, DEJEUNER_FOOD, DEJEUNER_BOISSON, DINER_FOOD, DINER_BOISSON, BANQUET_FOOD, BANQUET_BOISSON, BAR_MATIN, BAR_SOIR, DIVERS, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                                'End If

                                            End If

                                            '----------- MAIN COURANTE JOURNALIERE ------------------------------

                                            'We check if the the main courante journaliere already exist
                                            If Not Functions.entryCodeExists(CODE_MAIN_COURANTE, "main_courante_journaliere", "CODE_MAIN_COURANTE_JOURNALIERE") Then

                                                ETAT_CHAMBRE = 1

                                                If mainCourante.insertMainCouranteJournaliere(CODE_MAIN_COURANTE_JOURNALIERE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, Location, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                                    '-------------------UTILISE POUR LES RESERVATION DONT L'ENCAISSEMENT EST FAIT AVANT L'ENREGISTREMENT -------------------------
                                                    miseAjourDeRegelementApresCreationDeMainCourante(NUM_RESERVATION, CODE_MAIN_COURANTE_JOURNALIERE)
                                                    '------------------------------------------------------------------------------------------------------

                                                End If

                                            End If

                                        End If

                                    Else
                                        ' the generated code already exist

                                    End If

                                Else
                                    'CHECKIN INDIRECT
                                    'LA RESERVATION A ETE ENREGISTREE AU PREALABLE 

                                    'Checkin from reservation meaning the reseravtion has been saved earlier

                                    'AVANT DE MIGRER ON DOIT ENREGISTERE D'EVENTUELLE MODIFICATION

                                    'As the Global variable codeReservationToUpdate is not empty => update reservation
                                    ' we determine if the reservation is found in reservation or reserve_conf
                                    CODE_RESERVATION = GlobalVariable.codeReservationToUpdate
                                    CHAMBRE_ID = GlobalVariable.codeChambre

                                    'DIRECT CHECKIN
                                    User.updateSuiviDesReservations("CHECKIN_PAR", CHECKIN_PAR, CODE_RESERVATION)

                                    Dim operation As Integer = 1 'UPDATE
                                    gestionDesNavettes(operation, CODE_RESERVATION)

                                    'We have to search where the reservtion to update is found either in reservation or reserve_conf
                                    Dim reservationTable As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION")

                                    If reservationTable.Rows.Count > 0 Then

                                        If reservation.updateReservation(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, HEBDOMADAIRE, BC_ENTREPRISE, TYPE_CHAMBRE, TYPE_CHAMBRE_OU_SALLE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE) Then

                                            Dim TABLE As String = "reserve_conf"

                                            reservation.updatePetitDejeuner(PETIT_DEJEUNER, CODE_RESERVATION, TABLE, AFFICHER_PRIX, BFK_COST)

                                            'So we migrate the  entry from reservation to reserve_conf
                                            If reservationConf.insertReservationMigration(CODE_RESERVATION) Then

                                                'FACTURATION ANTICIPE
                                                If facturationAnticipe Then
                                                    reservation.facturationEnAvance(CODE_RESERVATION, POSTER_TAX)
                                                End If

                                                Functions.DeleteElementByCode(CODE_RESERVATION, "reservation", "CODE_RESERVATION")
                                                'We change the status of the checkin field to yes as it was initialise to 0
                                                reservation.updateReservationConfCheckIn(CODE_RESERVATION)
                                            End If

                                            'GESTION DE NOUVELLE RESERVATION
                                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                                'reservation.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reservation", GunaLabelSolde.Text)
                                                updatedSolde = Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate)
                                                reservation.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reservation", updatedSolde)
                                            End If

                                            If GlobalVariable.typeChambreOuSalle = "salle" Then
                                                reservation.updateForfait(CODE_RESERVATION, NBRE__CAFE, PU_CAFE, NBRE_DEJEUNER, PU_DEJEUNER, NBRE_DINER, PU_DINER, NBRE_TRAITEUR, PU_TRAITEUR, DECORATION, LOCATION_MATERIEL, AUTRES, CODE_EVENEMENT, LIBELLE_EVENEMENT, NBRE_GOUTER, PU_GOUTER, NBRE_COCKTAIL, PU_COCKTAIL, HEURE_PAUSE_CAFE, HEURE_PAUSE_DEJEUNER, HEURE_DINER, HEURE_GOUTER, HEURE_COCKTAIL, VIDEO_PROJ, SONO, COUVERTS, TABLE_CHAISE, EAU_PTE_QTE, EAU_PTE_MONTANT, EAU_GRDE_QTE, EAU_GRDE_MONTANT, BOISSONS_GAZEUSES_QTE, BOISSONS_GAZEUSES_MONTANT, BIERES_QTE, BIERES_MONTANT, VIN_ROUGE_QTE, VIN_ROUGE_MONTANT, VIN_ROSE_QTE, VIN_ROSE_MONTANT, BOISSONS_EXT_QTE, BOISSONS_EXT_MONTANT, DROIT_DE_BOUCHON, MISE_EN_PLACE, CLOISONNEMENT)
                                            End If

                                            '---------------------------------------------------------------
                                            CODE_MAIN_COURANTE_JOURNALIERE = GlobalVariable.codeMainCouranteJournaliereToUpdate

                                            NUM_RESERVATION = GlobalVariable.codeReservationToUpdate

                                            ETAT_CHAMBRE = 1

                                            'CHEKCIN D'UNE RESA AVEC MAINCOURANTE JOURNALIERE QUI SERA JUSTE UTILISE APRES BASCULEMENT DE reserve vers reserve_conf

                                            Dim tableMainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

                                            If tableMainCouranteJournaliere.Rows.Count > 0 Then

                                                If mainCourante.updateMainCouranteJournaliere(CODE_MAIN_COURANTE_JOURNALIERE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, Location, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                                    Dim ensembleDesReglementsPasse As DataTable = Functions.getElementByCode(NUM_RESERVATION, "reglement", "CODE_RESERVATION")

                                                    If ensembleDesReglementsPasse.Rows.Count > 0 Then

                                                        Dim encaissementPasse As Double = 0

                                                        Dim FIELDVALUE As Double = 0

                                                        Dim TABLE_TO_UPDATE As String = ""
                                                        TABLE_TO_UPDATE = "main_courante_journaliere"
                                                        Dim FIELD_TO_UPDATE As String = ""
                                                        Dim MODE_REGLEMENT_PASSE As String = ""

                                                        Dim MONTANT_VERSE_RESERVE As Double = 0

                                                        For i = 0 To ensembleDesReglementsPasse.Rows.Count - 1

                                                            MONTANT_VERSE_RESERVE = ensembleDesReglementsPasse.Rows(i)("MONTANT_VERSE")
                                                            MODE_REGLEMENT_PASSE = ensembleDesReglementsPasse.Rows(i)("MODE_REGLEMENT")

                                                            FIELD_TO_UPDATE = ReglementForm.champEncaissementAMettreAjours(MODE_REGLEMENT_PASSE)

                                                            Dim mainCourantes As New MainCourantes()
                                                            'INSETION SUR LA MAINCOURANTE DES REGLEMENTS ULTERIEURES
                                                            mainCourantes.updateMainCouranteJournaliereModeReglement(CODE_MAIN_COURANTE_JOURNALIERE, TABLE_TO_UPDATE, FIELD_TO_UPDATE, MONTANT_VERSE_RESERVE)

                                                            If CDate(ensembleDesReglementsPasse.Rows(i)("DATE_REGLEMENT")).ToShortDateString < CDate(GlobalVariable.DateDeTravail).ToShortDateString Then
                                                                Functions.updateOfFields(TABLE_TO_UPDATE, FIELD_TO_UPDATE, MONTANT_VERSE_RESERVE * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)
                                                            End If

                                                        Next

                                                    End If

                                                End If

                                            Else

                                                'CHEKCIN D'UNE RESA SANS MAINCOURANTE JOURNALIERE CAR  ELLE A ETE CREE UN JOUR ANTERIEUR DONC PLUS D'EXISTENCE DE LA PREMIERE MAINCOURANTE
                                                'LA MAINCOURANTE N'EST PAS ASSOCIE A UNE RESA AVEC LA DATE DU JOUR
                                                'EN PLUS ON DOIT VERIFIER SI IL EXISTE D'EVENTUEL ARRHES
                                                ETAT_CHAMBRE = 1

                                                CODE_CLIENT = GlobalVariable.ReservationToUpdate.Rows(0)("CLIENT_ID")
                                                NOM_CLIENT = GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT")

                                                CODE_MAIN_COURANTE_JOURNALIERE = Functions.GeneratingRandomCodeWithSpecifications("main_courante_journaliere", "MCJ")

                                                If mainCourante.insertMainCouranteJournaliere(CODE_MAIN_COURANTE_JOURNALIERE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, Location, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                                    'MISE A ZERO DU MONTANT A REPORTER *****-*****

                                                    'ON DOIT VERIFIER SI LA RESERVATION DONT ON CREEE LA LIGNE DE MAINCOURANTE EST ASSOCIE A UN REGLEMENT EN ESPECE FAITE LORS DE LA RESA

                                                    Dim DEPOSIT_YES_NO As Integer = 1

                                                    miseAjourDeRegelementApresCreationDeMainCourante(NUM_RESERVATION, CODE_MAIN_COURANTE_JOURNALIERE, DEPOSIT_YES_NO)

                                                End If

                                            End If

                                            '---------------------------------------------------------------
                                        End If

                                    Else

                                    End If

                                    '-------------------------- OCCUPATION CHAMBRE--------------------------
                                    'If Not Functions.entryCodeExists(CODE_OCCUPATION_CHAMBRE, "occupation_chambre", "CODE_OCCUPATION_CHAMBRE") Then

                                    If occupationChambre.insertOccupationChambre(CODE_OCCUPATION_CHAMBRE, CODE_RESERVATION, CODE_CHAMBRE, MONTANT_HT, TAXE, MONTANT_TTC, DATE_OCCUPATION, ETAT_CHAMBRE, OBSERVATIONS, COMMENTAIRE1, COMMENTAIRE2, COMMENTAIRE3, COMMENTAIRE4, DATE_LIBERATION, CODE_UTILISATEUR_CREA, DATE_PREMIERE_ARRIVEE, TYPE_RESERVATION, PDJ_INCLUS, TAXE_SEJOURS_INCLUS, TVA_INCLUS, CODE_CLIENT_REEL, CODE_AGENCE) Then

                                    End If

                                    'End If

                                End If

                                '-------------------------- UPDATE ROOM --------------------------------
                                Dim updateQuery As String = "UPDATE `chambre` SET `ETAT_CHAMBRE`=@ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@code"

                                Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                                command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
                                command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.occupee_sale
                                command.Parameters.Add("@code", MySqlDbType.VarChar).Value = Trim(GunaTextBoxNumeroChambre.Text)
                                'Opening the connection
                                'connect.openConnection()

                                'Excuting the command and testing if everything went on well
                                If (command.ExecuteNonQuery() = 1) Then
                                    'connect.closeConnection()
                                End If

                                '-------------------------------------------- TAXE SEJOUR COLLECTE ---------------------------------------

                                If GunaCheckBoxTaxeSejour.Checked Then

                                    Functions.DeleteElementByCode(CODE_RESERVATION, "taxe_sejour_collectee", "NUM_RESERVATION")

                                    'Insertion des lignes dans taxe séjours collectées TAXE_SEJOURS_COLLECTEE
                                    Dim insertQueryTaxe As String = "INSERT INTO `taxe_sejour_collectee` (`CODE_CATEGORIE_HOTEL`, `CODE_CLIENT`, `NUM_RESERVATION`, `NUM_FACTURE`, `CODE_CHAMBRE`, `TAXE_SEJOUR_COLLECTEE`, `DATE_FACTURATION_TAXE`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`) VALUES (@valu1,@valu2,@valu3,@valu4,@valu5,@valu6,@valu7,@valu8,@valu9,@valu10)"

                                    Dim commandTaxe As New MySqlCommand(insertQueryTaxe, GlobalVariable.connect)

                                    commandTaxe.Parameters.Add("@valu1", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CATEGORIE_HOTEL")
                                    commandTaxe.Parameters.Add("@valu2", MySqlDbType.VarChar).Value = CLIENT_ID
                                    commandTaxe.Parameters.Add("@valu3", MySqlDbType.VarChar).Value = CODE_RESERVATION
                                    commandTaxe.Parameters.Add("@valu4", MySqlDbType.VarChar).Value = ""
                                    commandTaxe.Parameters.Add("@valu5", MySqlDbType.VarChar).Value = CHAMBRE_ID

                                    Dim TaxeSejour As Double
                                    Double.TryParse(GunaTextBoxTaxeSejour.Text, TaxeSejour)
                                    commandTaxe.Parameters.Add("@valu6", MySqlDbType.Double).Value = TaxeSejour

                                    commandTaxe.Parameters.Add("@valu7", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
                                    commandTaxe.Parameters.Add("@valu8", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
                                    commandTaxe.Parameters.Add("@valu9", MySqlDbType.VarChar).Value = GlobalVariable.codeUser
                                    commandTaxe.Parameters.Add("@valu10", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                                    'Opening the connection
                                    'connect.openConnection()

                                    'Excuting the command and testing if everything went on well
                                    If (commandTaxe.ExecuteNonQuery() = 1) Then
                                        'connect.closeConnection()
                                    Else
                                        'connect.closeConnection()
                                    End If

                                End If

                                'GESTION DES ENCAISSEMENTS ICI

                                '----------------------------------- ENCAISSEMENT + DEPOT DE GARANTIE --------------------------------------------------------

                                If DEPOT_DE_GARANTIE > 0 Then

                                    Dim NUM_REGLEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("reglement", "RGL")

                                    MONTANT_VERSE = DEPOT_DE_GARANTIE

                                    'reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                End If

                                If Not Trim(GunaTextBoxPaiement.Text).Equals("") Then

                                    If Double.Parse(GunaTextBoxPaiement.Text) > 0 Then

                                        Dim NUM_REGLEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("reglement", "RGL")

                                        MONTANT_VERSE = GunaTextBoxPaiement.Text

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            MODE_REGLEMENT = "Espèce"
                                            REF_REGLEMENT = "ENCAISSEMENT (" & MODE_REGLEMENT & ") DE " & "[" & NOM_CLIENT & " / " & CHAMBRE_ID & "]"
                                        Else
                                            MODE_REGLEMENT = "Cash"
                                            REF_REGLEMENT = "CASHED IN (" & MODE_REGLEMENT & ") FROM " & "[" & NOM_CLIENT & " / " & CHAMBRE_ID & "]"
                                        End If

                                        ' reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                        'MISE AJOURS DE LA MAINCOURANTE APRES VERSEMENT DE L'ESPECE AU MOMENT DE LA CREATION DE RESERVATION

                                        Dim TABLE As String = ""
                                        Dim FIELD As String = ""

                                        FIELD = "ENCAISSEMENT_ESPECE"

                                        TABLE = "main_courante_journaliere"

                                        Dim FIELDVALUE As Double = MONTANT_VERSE

                                        Dim mainCourantes As New MainCourantes()

                                        ' mainCourantes.updateMainCouranteJournaliereModeReglement(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                                    End If

                                End If

                                '--------------------------------------- GESTION DE LA MISE A JOURS DU SOLDE DE LA RESERVATION ----------------------------

                                Dim reservationToUpdateInReservation As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reservation", "CODE_RESERVATION")

                                'SOIT DANS RESERVATION
                                Dim SOLDE_RESERVATION As Double = 0

                                If reservationToUpdateInReservation.Rows.Count > 0 Then

                                    'MISE JOURS DU SOLDE DE LA RESERVATION
                                    updatedSolde = Functions.SituationDeReservation(CODE_RESERVATION)
                                    SOLDE_RESERVATION = updatedSolde
                                    reservation.updateSoldeReservation(CODE_RESERVATION, "reservation", updatedSolde)

                                Else

                                    'OU DANS RESERVATION
                                    Dim reservationToUpdateInReserve_conf As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                                    If reservationToUpdateInReserve_conf.Rows.Count > 0 Then

                                        updatedSolde = Functions.SituationDeReservation(CODE_RESERVATION)
                                        SOLDE_RESERVATION = updatedSolde
                                        reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", updatedSolde)

                                    End If

                                End If

                                '---------------------------------------EN CODAGE DES CARTE-------------------------------------------
                                'Gestion de l'encodage

                                If GlobalVariable.typeChambreOuSalle = "chambre" Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        MessageBox.Show("HEBERGEMENT DE " & NOM_CLIENT & " DU  " & DATE_ENTTRE & " AU " & DATE_SORTIE & " enregistré avec succès!!", "Logement", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    Else
                                        MessageBox.Show("ACCOMMODATION OF " & NOM_CLIENT & " FROM  " & DATE_ENTTRE & " TO " & DATE_SORTIE & " successfully saved !!", "Accommodation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    End If

                                ElseIf GlobalVariable.typeChambreOuSalle = "salle" Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        MessageBox.Show("LOCATION DE SALLE DE " & NOM_CLIENT & " DU  " & DATE_ENTTRE & " AU " & DATE_SORTIE & " enregistré avec succès !!", "Logement", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    Else
                                        MessageBox.Show("HALL RENTING " & NOM_CLIENT & " FROM  " & DATE_ENTTRE & " TO " & DATE_SORTIE & " sucessfully saved !!", "Lodging", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    End If
                                End If

                                '-------------------------------------------- IMPRESSION DES DOCUMENTS -------------------------------------------------

                                Dim montantParNuitee As Double = 0

                                Dim dialog As DialogResult

                                If GlobalVariable.typeChambreOuSalle = "chambre" Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        dialog = MessageBox.Show("Télécharger La fiche de police ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                    Else
                                        dialog = MessageBox.Show("Download Hotel Registration Form ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                    End If
                                ElseIf GlobalVariable.typeChambreOuSalle = "salle" Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        dialog = MessageBox.Show("Télécharger Le contrat de location ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    Else
                                        dialog = MessageBox.Show("Download renting contract ", "Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                    End If
                                End If

                                If dialog = DialogResult.No Then
                                    'e.Cancel = True
                                Else

                                    'Génération des documents concernants les salles Confirmation de réservation

                                    'DOCUMENT DE LA SALLE DE FETE
                                    If GunaRadioButtonSalleFete.Checked Then

                                        If GlobalVariable.codeReservationToUpdate = "" Then

                                            'CONFIRMATION DE RESERVATION CAS DE CHECKIN DIRECT

                                            Double.TryParse(GunaTextBoxMontantReelSalle.Text, montantParNuitee)

                                            'CONTRAT DE POLICE
                                            'Functions.GenerationDeFicheDePolice(CODE_RESERVATION, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle)

                                            Impression.contratDeLocationDeSalleDeFete(CODE_RESERVATION, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle)

                                            'Functions.GenerationDeConfirmationReservation(GunaLabelNumReservation.Text, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GunaDateTimeHeureArrive.Value.ToLongTimeString, GunaDateTimePickerHeureDepart.Value.ToLongTimeString, GlobalVariable.typeChambreOuSalle)

                                        Else

                                            'MessageBox.Show("Sélectionner un Document à imprimer!", "Impression de Document", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        End If

                                    End If

                                End If

                                '-------------------------------------------- GESTION DES TRACES DES UTILISATEURS ----------------------------------------------------------

                                Dim ACTION_FAITE As String = GunaButtonCheckIn.Text
                                Dim FAITE_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

                                reservation.insertTrace(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, HEBDOMADAIRE, BC_ENTREPRISE, TYPE_CHAMBRE, ACTION_FAITE, FAITE_PAR, TYPE_CHAMBRE_OU_SALLE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE, SOLDE_RESERVATION)

                                Dim CODE_RESERVATAION_ As String = CODE_RESERVATION
                                Dim NOM_PRENOM_ As String = Trim(GunaTextBoxNomPrenom.Text)
                                Dim ARRIVAL_ As Date = GunaDateTimePickerArrivee.Value.ToShortDateString()
                                Dim DEPART_ As Date = GunaDateTimePickerDepart.Value.ToShortDateString()
                                Dim TEMP_A_FAIRE_ As Integer = GunaTextBoxTempsAFaire.Text
                                Dim TYPE_CHAMBRE_ As String = GunaTextBoxLibelleTYpe.Text
                                Dim NUM_CHAMBRE_ As String = GunaTextBoxNumeroChambre.Text
                                Dim MONTANT_PAR_NUITEE_ As Double = montantParNuitee
                                Dim HEURE_ARRIVEE_ As DateTime = GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem
                                Dim HEURE_DEPART_ As DateTime = GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem
                                Dim TYPE_CHAMBRE_SALLE_ As String = GlobalVariable.typeChambreOuSalle
                                Dim TELEPHONE As String = GunaTextBoxTelClient.Text

                                Dim args As ArgumentType = New ArgumentType()

                                args.CODE_RESERVATAION = CODE_RESERVATAION_
                                args.NOM_PRENOM = NOM_PRENOM_
                                args.ARRIVAL = ARRIVAL_
                                args.DEPART = DEPART_
                                args.TEMP_A_FAIRE = TEMP_A_FAIRE_
                                args.TYPE_CHAMBRE = TYPE_CHAMBRE_
                                args.NUM_CHAMBRE = NUM_CHAMBRE_
                                args.MONTANT_PAR_NUITEE = MONTANT_PAR_NUITEE_
                                args.HEURE_ARRIVEE = HEURE_ARRIVEE_
                                args.HEURE_DEPART = HEURE_DEPART_
                                args.TYPE_CHAMBRE_SALLE = TYPE_CHAMBRE_SALLE_
                                args.EMAIL = EMAIL
                                args.TELEPHONE_CLIENT = TELEPHONE_CLIENT

                                Dim sendMailChambre As Boolean = False
                                Dim sendWhatsAppChambre As Boolean = False

                                Dim sendMailSalle As Boolean = False
                                Dim sendWhatsAppSalle As Boolean = False

                                If True Then

                                    If GunaRadioButtonMailOui.Checked Then
                                        If Not Trim(EMAIL).Equals("") And EMAIL.Length > 10 Then
                                            sendMailSalle = True
                                        End If
                                    End If

                                    If GunaRadioButtonWhatsAppOui.Checked Then
                                        If TELEPHONE.Length >= 13 Then
                                            sendWhatsAppSalle = True
                                        End If
                                    End If

                                End If

                                'ENVOI DE MESSAGE WHATSAPP AU CLIENT

                                Dim NUITEES As Integer = 0

                                NOMBRE_HEURE = CType((FIN_HEURE - DEBUT_HEURE).TotalHours, Int32)

                                NUITEES = CType((DATE_SORTIE - DATE_ENTTRE).TotalDays, Int32)

                                '---------------------------------------------ENVOI DES MESSAGES WHATSAPP------------------------------------------------------------------------

                                Dim RESA_TYPE As String = ""

                                If NUITEES = 0 Then

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        RESA_TYPE = "HEURE(S)"
                                    Else
                                        RESA_TYPE = "HOUR(S)"
                                    End If
                                    NUITEES = NOMBRE_HEURE
                                    MONTANT_ACCORDE = MONTANT_ACCORDE / NOMBRE_HEURE

                                Else

                                    If GlobalVariable.actualLanguageValue = 1 Then

                                        RESA_TYPE = "NUITEE(S)"
                                    Else

                                        RESA_TYPE = "NIGHT(S)"
                                    End If

                                End If

                                Dim NoReception = GlobalVariable.AgenceActuelle.Rows(0)("NUMERO_RECEPTION")
                                Dim NoTelChambre = GlobalVariable.AgenceActuelle.Rows(0)("NUMERO_RECEPTION_CHAMBRE")

                                If GlobalVariable.actualLanguageValue = 1 Then

                                    whatsAppMessage = "CHECKIN " & Chr(13) & " -/ PAR : " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & Chr(13) & " -/ A : " & Now().ToShortTimeString & Chr(13) & " -/ ARRIVEE : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & " -/ DEPART : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & " -/ " & RESA_TYPE & " : " & NUITEES & Chr(13) & " -/ CLIENT : " & NOM_CLIENT & Chr(13) & "-/ TYPE DE CHAMBRE : " & TYPE_CHAMBRE & Chr(13) & " -/ CHAMBRE : " & CHAMBRE_ID & Chr(13) & " -/ MONTANT :  " & MONTANT_ACCORDE & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " */ MONTANT TOTAL : " & NUITEES * MONTANT_ACCORDE & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                                    _whatsAppMessage = Chr(13) & "Cher " & NOM_CLIENT & Chr(13) & Chr(13) & "C'est avec plaisir que nous vous souhaitons la bienvenue à " & GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE") & ", nous sommes ravis de vous accueillir parmi nous. " & Chr(13) & Chr(13) & " Pour toute demande, notre équipe est à votre écoute à la réception ou en composant le " & NoTelChambre & " sur le téléphone de votre chambre ou via notre portable au " & NoReception & "." & Chr(13) & Chr(13) & "Nous vous remercions d'avoir choisi " & GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE") & " pour votre séjour. " & Chr(13) & Chr(13) & " Cordialement"

                                Else
                                    whatsAppMessage = "CHECKIN " & Chr(13) & " -/ BY : " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & Chr(13) & " -/ AT : " & Now().ToShortTimeString & Chr(13) & " -/ ARRIVAL : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & " -/ DEPARTURE : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & " -/ " & RESA_TYPE & " : " & NUITEES & Chr(13) & " -/ CLIENT : " & NOM_CLIENT & Chr(13) & "-/ ROOM TYPE : " & TYPE_CHAMBRE & Chr(13) & " -/ ROOM : " & CHAMBRE_ID & Chr(13) & " -/ AMOUNT :  " & MONTANT_ACCORDE & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " */ TOTAL AMOUNT : " & NUITEES * MONTANT_ACCORDE & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                                    _whatsAppMessage = Chr(13) & "Dear " & NOM_CLIENT & Chr(13) & Chr(13) & " We are delighted to welcome you to " & GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE") & ", for any query, please do not hesitate to contact our team at reception or by calling " & NoTelChambre & " on your room telephone or via our mobile on " & NoReception & "." & Chr(13) & Chr(13) & "  Thank you for choosing " & GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE") & " for your stay. " & Chr(13) & Chr(13) & "Kind regards"

                                End If

                                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                                    Dim mobile_number As String = listeOfTelephoneNumbers()

                                    args.action = 0
                                    args.whatsAppMessage = whatsAppMessage
                                    args.mobile_number = mobile_number

                                    backGroundWorkerToCall(args)
                                    'Functions.ultrMessageSimpleText(whatsAppMessage, mobile_number)

                                End If

                                '---------------------------------------------ENVOI DES MESSAGES WHATSAPP------------------------------------------------------------------------

                                GunaLabelNumReservation.Text = CODE_RESERVATION
                                'Desactivation du bouton de gestion des groupes
                                GunaCheckBoxReservationDeGroupe.Checked = False

                                'GESTION DES GRATUITEES
                                gestionDelaGratuiteeDeLaReservation()

                                'GESTION DES PRISES EN CHARGES DE LA RESERVATION
                                gestionDelaPriseEnChargeDeLaReservation()

                                'RSERVATION NORMALE

                                Dim TYPE_DEPOT_CAUTION As Integer = 0

                                If MONTANT_TOTAL_CAUTION > 0 Then
                                    TYPE_DEPOT_CAUTION = 0
                                    'cautionEnregistrement(CODE_RESERVATION, 0, GunaTextBoxMontantCaution.Text, TYPE)
                                    cautionEnregistrement(CODE_RESERVATION, 0, MONTANT_TOTAL_CAUTION, TYPE_DEPOT_CAUTION)
                                End If

                                If DEPOT_DE_GARANTIE > 0 Then
                                    TYPE_DEPOT_CAUTION = 1
                                    cautionEnregistrement(CODE_RESERVATION, 0, DEPOT_DE_GARANTIE, TYPE_DEPOT_CAUTION)
                                End If

                                A_REPORTER = Functions.SituationDeReservation(CODE_RESERVATION)

                                Functions.updateOfFields("main_courante_journaliere", "A_REPORTER", A_REPORTER, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)

                                'cautionEnregistrement(CODE_RESERVATION, 0, GunaTextBoxMontantCaution.Text)

                                'Clearing all the informations found in the the reseravtion field

                                'emtptyRegistrationFields()

                                'We set all the global variables used for update to their original values
                                Functions.EmtyGlobalVariablesContainingCodeToUpdate()
                                ReinitialisationDesDates()

                                'We prevent from choosing a room if a room type is not first choosen
                                'GunaTextBoxNumeroChambre.BaseColor = Color.Beige
                                GunaTextBoxNumeroChambre.Enabled = True

                                Functions.SiplifiedClearTextBox(Me)

                                'On masque les tarifs associés au client si existe 
                                GunaComboBoxCodeTarif.Visible = False
                                GunaLabelCodeTarif.Visible = False

                                'ReservationList()

                                'We update the buttons to display
                                reservationButtonToDisplay()

                                GunaComboBoxHeureArrivee.SelectedItem = "120000"
                                GunaComboBoxHeureDepart.SelectedItem = "120000"

                                GunaCheckBoxPetitDejeuenerInclus.Checked = False
                                GunaCheckBoxTaxeSejour.Checked = False
                                GunaTextBoxPetitDejeuner.Visible = False
                                GunaTextBoxPetitDejeunerRoutage.Visible = False

                                'Obtention des informations pour les statistiques
                                Dim stat As New statistiques()

                                stat.ObtenirDerniereStatistique()

                                Dim codeDelaDerniereStatistique As String = stat.ObtenirDerniereStatistique()

                                GlobalVariable.informationDesStatistiques = Functions.getElementByCode(codeDelaDerniereStatistique, "statistiques", "CODE_STATISTIQUE")

                                GunaTextBoxBC.Visible = False

                                GunaButtonCheckOut.Visible = False

                                GunaTextBoxNbreAdulte.Text = 0

                                If continuer Then
                                    VidageDesChampsPourNouvelleReservation()
                                End If

                                Dim WHATSAPP_OU_MAIL As Integer = 0
                                'WHATSAPP_OU_MAIL = 0 ' WHATSAPP
                                'WHATSAPP_OU_MAIL = 1 ' EMAIL


                                If sendMailChambre Then
                                    WHATSAPP_OU_MAIL = 1
                                    args.WHATSAPP_OU_EMAIL = 1
                                    If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                                        args.action = 4

                                        backGroundWorkerToCall(args)

                                    End If

                                End If

                                If sendMailSalle Then
                                    WHATSAPP_OU_MAIL = 1
                                    args.WHATSAPP_OU_EMAIL = 1
                                    If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                                        args.action = 5

                                        backGroundWorkerToCall(args)

                                    End If
                                End If

                                If sendWhatsAppChambre Then
                                    WHATSAPP_OU_MAIL = 0
                                    args.WHATSAPP_OU_EMAIL = 0
                                    If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                                        args.action = 4
                                        backGroundWorkerToCall(args)

                                    End If
                                End If

                                If sendWhatsAppSalle Then

                                    If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                                        WHATSAPP_OU_MAIL = 0
                                        args.WHATSAPP_OU_EMAIL = WHATSAPP_OU_MAIL
                                        args.action = 5

                                        backGroundWorkerToCall(args)

                                    End If
                                End If

                                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                                    args.action = 0
                                    args.whatsAppMessage = _whatsAppMessage
                                    args.mobile_number = TELEPHONE_CLIENT

                                    backGroundWorkerToCall(args)

                                End If

                                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                                    args.action = 10
                                    args.whatsAppMessage = GlobalVariable.AgenceActuelle.Rows(0)("PROMO_CLUB_ELITE_IN")
                                    args.mobile_number = TELEPHONE_CLIENT

                                    backGroundWorkerToCall(args)

                                End If

                                If True Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        dialog = MessageBox.Show("Voulez-vous effectuer un encaissement", "Encaissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    Else
                                        dialog = MessageBox.Show("Do you want to Cash In Money", "Cas In", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    End If

                                    If Not dialog = DialogResult.No Then
                                        MiniReglementForm.GunaTextBoxCodeResa.Text = CODE_RESERVATION
                                        MiniReglementForm.GunaTextBoxChambre.Text = CHAMBRE_ID
                                        MiniReglementForm.Show()
                                        MiniReglementForm.TopMost = True
                                    End If
                                End If

                                Me.Cursor = Cursors.Default

                            End If

                        End If

                    Else

                        GunaTextBoxNumeroChambre.Clear()

                        If Trim(CHAMBRE_ID).Equals("") Or Trim(CHAMBRE_ID).Equals("-") Then

                            Dim Message As String = ""

                            If GunaRadioButtonSalleFete.Checked Then

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    Message = "Bien vouloir saisir un numéro de salle valide xx!!"
                                Else
                                    Message = "Please type in a valide hole !!"

                                End If
                            End If


                            MessageBox.Show(Message, "Check In Impossible", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else

                            If GunaRadioButtonSalleFete.Checked Then

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MessageBox.Show("Ce numéro de salle est déjà occupé et ne figure pas parmis les propositions", "Check In Impossible", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    MessageBox.Show("This hall is already occupied, select from the list of proposals", "Check In Impossible", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                            End If

                        End If

                    End If


                Else

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bien vouloir indiquer le nombre de personne", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Please Indicate the Number of Pax", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            End If
        End If


    End Sub

    Dim whatsAppMessage As String = ""
    Dim _whatsAppMessage As String = ""

    '--------------------------------------- CHECKOUT MANAGEMENT ----------------------------------------
    Private Sub GunaButtonCheckOut_Click(sender As Object, e As EventArgs) Handles GunaButtonCheckOut.Click

        'ON DOIT DETERMINER SI POUR LES CLIENTS A SEJOUR NORMAL ON DOIT PERMETTRE LE CHECK-OUT APRES CLOTURE DE FACTURE

        'On doit vérifier que la date de sortie n'est jamais inférieure a la date de travail
        Dim dayDiff = CType((GlobalVariable.DateDeTravail - GunaDateTimePickerDepart.Value).TotalHours, Int32)

        If dayDiff > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir vérifier la da de départ", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please check the departure date", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            Dim dt As DataTable

            Dim messageDeConfirmation As String = ""
            GlobalVariable.duplicationDeReservation = False

            Dim imposerCloture As Boolean = False

            'ON VERIFIE QUE L'OPTION DE CLOTURE DE FACTURE EST ACTIVE
            If GlobalVariable.AgenceActuelle.Rows(0)("CLOTURE_FACTURE") = 1 Then
                imposerCloture = True
            End If

            Dim factureCloturee As Boolean = True

            If imposerCloture Then
                'ON NE DOIT GERER QUE LES SEJOURS NORMAUX
                If Not GunaCheckBoxDayUse.Checked Then

                    'ON NE PEUT PORDUIRE UNE FACTURE SI IL Y'A PAS DE CHARGES

                    Dim infoSupLigneFactureDeResa As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "ligne_facture", "CODE_RESERVATION")

                    If infoSupLigneFactureDeResa.Rows.Count > 0 Then

                        Dim infoSupFactureDeResa As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "facture", "CODE_RESERVATION")

                        If Not infoSupFactureDeResa.Rows.Count > 0 Then


                            If GlobalVariable.actualLanguageValue = 1 Then
                                messageDeConfirmation = "Bien vouloir produire la facture de " & GunaTextBoxNomPrenom.Text
                            Else
                                messageDeConfirmation = "Please produce de bill of " & GunaTextBoxNomPrenom.Text
                            End If

                            Dim dialog As DialogResult = MessageBox.Show(messageDeConfirmation, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            If dialog = DialogResult.OK Then
                                FolioForm.Close()
                                FolioForm.Show()
                                FolioForm.TopMost = True
                            End If

                            factureCloturee = False

                        End If

                    End If

                End If

            End If

            'LA FACTURE DU CLIENT A ETE PRODUITE OU ALORS IN NE POSSEDE PAS DE CHARGE

            If factureCloturee Then

                'DAY USE ou SEJOURS
                If GunaCheckBoxDayUse.Checked Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Type de Chambre : " & GunaTextBoxLibelleTYpe.Text & "; N° Chambre: " & GunaTextBoxNumeroChambre.Text & Chr(13) & " Durée : " & GunaComboBoxHeureArrivee.SelectedItem.ToString & " - " & GunaComboBoxHeureDepart.SelectedItem.ToString & " soit (" & GunaTextBoxTempsAFaire.Text & ") Heure(s)" & Chr(13) & "Tarif réel : " & GunaTextBoxMontantAccorde.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

                    Else
                        messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Room Type : " & GunaTextBoxLibelleTYpe.Text & "; Room N° : " & GunaTextBoxNumeroChambre.Text & Chr(13) & " Period : " & GunaComboBoxHeureArrivee.SelectedItem.ToString & " - " & GunaComboBoxHeureDepart.SelectedItem.ToString & " i.e (" & GunaTextBoxTempsAFaire.Text & ") Hour(s)" & Chr(13) & "Real Price : " & GunaTextBoxMontantAccorde.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

                    End If

                Else

                    If True Then

                        'GESTION DES SALLES
                        Dim nomEvent As String = ""

                        Dim infoSupEvent As DataTable = Functions.getElementByCode(GunaComboBoxEvenement.SelectedValue.ToString, "evenement", "CODE_EVENEMENT")

                        If infoSupEvent.Rows.Count > 0 Then
                            nomEvent = infoSupEvent.Rows(0)("LIBELLE")
                        End If


                        If GlobalVariable.actualLanguageValue = 1 Then
                            messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Type de Salle : " & GunaTextBoxLibelleTYpe.Text & "; Salle: " & GunaTextBoxNumeroChambre.Text & Chr(13) & "Pour: " & nomEvent & Chr(13) & "Période: " & GunaDateTimePickerArrivee.Value.ToShortDateString & " - " & GunaDateTimePickerDepart.Value.ToShortDateString & " soit (" & GunaTextBoxTempsAFaire.Text & ") Jour(s)" & Chr(13) & "Tarif réel : " & GunaTextBoxMontantReelSalle.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                        Else
                            messageDeConfirmation = "Client : " & GunaTextBoxNomPrenom.Text & Chr(13) & "Hall Type : " & GunaTextBoxLibelleTYpe.Text & "; Hall : " & GunaTextBoxNumeroChambre.Text & Chr(13) & "For : " & nomEvent & Chr(13) & "Period : " & GunaDateTimePickerArrivee.Value.ToShortDateString & " - " & GunaDateTimePickerDepart.Value.ToShortDateString & " that is (" & GunaTextBoxTempsAFaire.Text & ") Days(s)" & Chr(13) & "Real Price : " & GunaTextBoxMontantReelSalle.Text & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                        End If

                    End If

                End If

                Dim messageTitle As String = ""

                If GlobalVariable.actualLanguageValue = 1 Then
                    messageTitle = "Confirmation de CheckOut"
                Else
                    messageTitle = "Check Out Confirmation"
                End If

                Dim dialogCheckOutConfirm As DialogResult = MessageBox.Show(messageDeConfirmation, messageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                If dialogCheckOutConfirm = DialogResult.OK Then

                    Me.Cursor = Cursors.WaitCursor

                    Dim TELEPHONE_CLIENT As String = Trim(GunaTextBoxTelClient.Text)
                    Dim EMAIL As String = Trim(GunaTextBoxClientEmail.Text)

                    Dim ETAT_NOTE_RESERVATION As String = "CHECKOUT"

                    Dim BC_ENTREPRISE As String = GunaTextBoxBC.Text

                    Dim DAY_USE As Integer = 0

                    If GunaCheckBoxDayUse.Checked Then
                        DAY_USE = 1
                    End If

                    Dim MENSUEL As Integer = 0

                    Dim HEBDOMADAIRE As Integer = 0

                    If Trim(GunaTextBoxMontantCaution.Text) = "" Then
                        GunaTextBoxMontantCaution.Text = 0
                    End If

                    LabelNatureReservation.Visible = False

                    'We change the color of the label depending on if the label the value is negatif or positif

                    'On masque les tarifs associés au client si existe 
                    GunaComboBoxCodeTarif.Visible = False
                    GunaLabelCodeTarif.Visible = False

                    'GunaLabelNumReservation.Visible = False 'We hide reservation code

                    '------------------------------------------ VARIEBLES------------------------------------------------
                    Dim TYPE_CHAMBRE_OU_SALLE As String = "salle"

                    'Dim ETAT_NOTE_RESERVATION As String = ""

                    'ETAT_NOTE_RESERVATION = "CHECK OUT"

                    If Trim(GunaTextBoxNbreAdulte.Text).Equals("") Then

                        If GlobalVariable.typeChambreOuSalle = "salle" Then
                            GunaTextBoxNbreAdulte.Text = 0
                        ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then
                            GunaTextBoxNbreAdulte.Text = 0
                        End If

                    End If

                    If Trim(GunaTextBoxNbreEnfant.Text).Equals("") Then
                        GunaTextBoxNbreEnfant.Text = 0
                    End If

                    If GunaRadioButtonMailOui.Checked Then
                        GlobalVariable.RECEVOIR_EMAIL = 1
                    End If

                    If GunaRadioButtonWhatsAppOui.Checked Then
                        GlobalVariable.RECEVOIR_SMS = 1
                    End If

                    Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxCodeEntrepriseDuClient.Text)
                    Dim NOM_ENTREPRISE As String = Trim(GunaTextBoxEntrepriseDuclient.Text)

                    'Dim CLIENT_ID As String = GlobalVariable.codeClient
                    Dim CLIENT_ID As String = Trim(GunaTextBoxRefClient.Text)

                    Dim UTILISATEUR_ID As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                    'Dim CHAMBRE_ID As String = GlobalVariable.codeChambre
                    Dim CHAMBRE_ID As String = Trim(GunaTextBoxNumeroChambre.Text)

                    Dim AGENCE_ID As String = GlobalVariable.codeAgence

                    Dim NOM_CLIENT As String = Trim(GunaTextBoxNomPrenom.Text)

                    If Trim(GunaTextBoxPetitDejeuner.Text) = "" Then
                        GunaTextBoxPetitDejeuner.Text = 0
                    End If

                    Dim PETIT_DEJEUNER As Double = GunaTextBoxPetitDejeuner.Text

                    Dim AFFICHER_PRIX As Integer = 1

                    If Not GunaCheckBoxAfficherPrix.Checked Then
                        AFFICHER_PRIX = 0
                    End If

                    Dim BFK_COST As Double = 0
                    If Not Trim(GunaTextBoxBreakFastCost.Text).Equals("") Then
                        BFK_COST = GunaTextBoxBreakFastCost.Text
                    End If
                    ' ----------------------------- GESTION DU DAY USE ----------------------------------------------------------------------------------------
                    Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.SelectedItem

                    Dim DateTimeDepartStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureDepart.SelectedItem

                    Dim DateTimeArrivee As DateTime = DateTime.ParseExact(DateTimeArriveeStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
                    Dim DateTimeDepart As DateTime = DateTime.ParseExact(DateTimeDepartStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)

                    'Dim DATE_ENTTRE As Date = GlobalVariable.DATE_ENTTRE
                    Dim DATE_ENTTRE As Date = GunaDateTimePickerArrivee.Value.ToShortDateString
                    Dim HEURE_ENTREE As String = DateTimeArrivee
                    'Dim DATE_SORTIE As Date = GlobalVariable.DATE_SORTIE
                    Dim DATE_SORTIE As Date = GunaDateTimePickerDepart.Value.ToShortDateString
                    Dim HEURE_SORTIE As String = DateTimeDepart

                    'Dim ADULTES As Integer = GlobalVariable.ADULTES
                    Dim ADULTES As Integer = Integer.Parse(GunaTextBoxNbreAdulte.Text)
                    Dim ENFANTS As Integer = Integer.Parse(GunaTextBoxNbreEnfant.Text)
                    ' Dim NB_PERSONNES As Integer = ENFANTS + ADULTES

                    If Trim(GunaTextBoxNbrePersonne.Text) = "" Then
                        GunaTextBoxNbrePersonne.Text = 0
                    End If

                    Dim NB_PERSONNES As Integer = GunaTextBoxNbrePersonne.Text
                    Dim RECEVOIR_EMAIL As Integer = GlobalVariable.RECEVOIR_EMAIL
                    Dim RECEVOIR_SMS As Integer = GlobalVariable.RECEVOIR_SMS
                    Dim ETAT_RESERVATION As Integer = 0
                    Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
                    Dim HEURE_CREATION As DateTime = DateTime.Now().ToString("hh:mm:ss")
                    Dim MONTANT_TOTAL_CAUTION As Double = GunaTextBoxMontantCaution.Text
                    Dim MOTIF_ETAT As String = ""
                    Dim DATE_ETAT As Date = GlobalVariable.DateDeTravail
                    Dim MONTANT_ACCORDE As Double = 0

                    If GlobalVariable.typeChambreOuSalle = "salle" Then
                        If Not Trim(GunaTextBoxMontantReelSalle.Text) = "" Then
                            MONTANT_ACCORDE = Double.Parse(GunaTextBoxMontantReelSalle.Text)
                        End If
                    ElseIf GlobalVariable.typeChambreOuSalle = "chambre" Then
                        If Not Trim(GunaTextBoxMontantAccorde.Text) = "" Then
                            MONTANT_ACCORDE = Double.Parse(GunaTextBoxMontantAccorde.Text)
                        End If
                    End If

                    Dim GROUPE As String = GunaTextBoxCodeDeGroupe.Text
                    'Dim CODE_RESERVATION = Functions.GeneratingRandomCode("reservation", "REA")
                    Dim CODE_RESERVATION As String = Trim(GunaLabelNumReservation.Text)

                    Dim reservation As New Reservation()
                    Dim mainCourante As New MainCourantes()
                    Dim reglement As New Reglement()
                    Dim occupationChambre As New OccupationChambre()
                    Dim facture As New Facture()
                    Dim ligneFacture As New LigneFacture()
                    Dim compte As New Compte()

                    'Inserting a new reservation after checking that the reservation does not already exist

                    ' variables declarations 

                    '-------------------------------- OCCUPATION CHAMBRE ------------------------------

                    Dim CODE_OCCUPATION_CHAMBRE = Functions.GeneratingRandomCodeWithSpecifications("occupation_chambre", "OC")
                    Dim MONTANT_HT As Double = 0
                    Dim TAXE As Double = 0
                    Dim MONTANT_TTC As Double = 0
                    Dim DATE_OCCUPATION As Date = GlobalVariable.DateDeTravail
                    'Dim OBSERVATIONS As String =""
                    Dim COMMENTAIRE1 As String = ""
                    Dim COMMENTAIRE2 As String = ""
                    Dim COMMENTAIRE3 As String = ""
                    Dim COMMENTAIRE4 As String = ""
                    Dim DATE_LIBERATION As Date = GlobalVariable.DateDeTravail
                    Dim CODE_UTILISATEUR_CREA As String = ""
                    Dim DATE_PREMIERE_ARRIVEE As Date = GlobalVariable.DateDeTravail
                    Dim TYPE_RESERVATION As String = ""
                    Dim PDJ_INCLUS As String = ""
                    Dim TAXE_SEJOURS_INCLUS As String = ""
                    Dim TVA_INCLUS As String = ""
                    Dim CODE_CLIENT_REEL As String = ""

                    '------------------------------- REGLEMENT ----------------------------------------------

                    If GunaTextBoxDepotDeGarantie.Text = "" Then
                        GunaTextBoxDepotDeGarantie.Text = 0
                    End If

                    Dim DEPOT_DE_GARANTIE As Double = Double.Parse(GunaTextBoxDepotDeGarantie.Text)

                    Dim NUM_REGLEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("reglement", "RGL")
                    Dim NUM_FACTURE As String = ""
                    Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                    Dim MONTANT_VERSE As Double = 0
                    Dim DATE_REGLEMENT As Date = GlobalVariable.DateDeTravail
                    Dim MODE_REGLEMENT As String = ""
                    Dim REF_REGLEMENT As String = ""
                    Dim CODE_MODE As String = ""
                    Dim IMPRIMER As Double = 0

                    '----------- MAIN COURANTES ------------------------------
                    Dim CODE_MAIN_COURANTE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante", "MC")
                    Dim CODE_CLIENT As String = GlobalVariable.codeClient
                    Dim CODE_CHAMBRE As String = GlobalVariable.codeChambre
                    Dim ETAT_CHAMBRE As String = 0
                    Dim CODE_AGENCE As String = AGENCE_ID

                    '----------- MAIN COURANTE GENERALE ------------------------------

                    Dim TAUX_OCCUPATION_PCT As Double = 0 'TAUX_OCCUPATION_PCT USED AS TAXE DE SEJOUR
                    Dim POSTER_TAX As Double = 0 'TAUX_OCCUPATION_PCT USED AS TAXE DE SEJOUR

                    If GunaCheckBoxTaxeSejour.Checked Then
                        If Not Trim(GunaTextBoxTaxeSejour.Text).Equals("") Then
                            TAUX_OCCUPATION_PCT = GunaTextBoxTaxeSejour.Text
                            POSTER_TAX = GunaTextBoxTaxeSejour.Text
                        End If
                    Else
                        Functions.DeleteElementByCode(CODE_RESERVATION, "taxe_sejour_collectee", "NUM_RESERVATION")
                    End If

                    Dim CODE_MAIN_COURANTE_GENERALE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante_generale", "MCG")
                    Dim DATE_MAIN_COURANTE As Date = GlobalVariable.DateDeTravail
                    Dim PDJ_FOOD As Double = 0
                    Dim PDJ_BOISSON As Double = 0
                    Dim DEJEUNER_FOOD As Double = 0
                    Dim DEJEUNER_BOISSON As Double = 0
                    Dim DINER_FOOD As Double = 0
                    Dim DINER_BOISSON As Double = 0
                    Dim BANQUET_FOOD As Double = 0
                    Dim BANQUET_BOISSON As Double = 0
                    Dim BAR_MATIN As Double = 0
                    Dim BAR_SOIR As Double = 0
                    Dim DIVERS As Double = 0
                    Dim TOTAL_JOUR As Double = MONTANT_ACCORDE + TAUX_OCCUPATION_PCT
                    Dim REPORT_VEILLE As Double = 0
                    Dim TOTAL_GENERAL As Double = MONTANT_ACCORDE + TAUX_OCCUPATION_PCT
                    Dim NUM_RESERVATION = CODE_RESERVATION
                    Dim DEDUCTION As Double = 0
                    Dim ENCAISSEMENT_ESPECE As Double = 0
                    Dim ENCAISSEMENT_CHEQUE As Double = 0
                    Dim ENCAISSEMENT_CARTE_CREDIT As Double = 0
                    'Dim A_REPORTER As Double = MONTANT_ACCORDE + TAUX_OCCUPATION_PCT
                    Dim A_REPORTER As Double = Functions.SituationDeReservation(CODE_RESERVATION)
                    Dim OBSERVATIONS As String = ""
                    Dim TYPE_CHAMBRE As String = GunaTextBoxCodeTypeDeChambre.Text
                    Dim INDICE_FREQUENTATION As Double = 0
                    Dim INDICE_FREQUENTATION_PCT As Double = 0
                    Dim TAUX_OCCUPATION As Double = 0

                    Dim CLIENTS_ATTENDUS As Integer = 0
                    Dim CLIENTS_EN_CHAMBRE As Integer = GunaTextBoxNbrePersonne.Text
                    Dim CHAMBRES_DISPONIBLES As Integer = 0
                    Dim TOTAL_HORS_SERVICE As Integer = 0
                    Dim CHAMBRES_HORS_SERVICE As Integer = 0
                    Dim TOTAL_FICTIVES As Integer = 0
                    Dim CHAMBRES_FICTIVES As Integer = 0
                    Dim NOMBRE_MESSAGES As Integer = 0
                    Dim TOTAL_GRATUITES As Double = 0
                    Dim CHAMBRES_GRATUITES As Integer = 0
                    Dim TOTAL_NON_FACTUREES As Double = 0
                    Dim CHAMBRES_NON_FACTUREES As Integer = 0

                    '--------------------------- FORFAIT SALLE
                    Dim nbreCafe As Integer = 0
                    Dim cafePu As Double = 0
                    Dim dejeunerNbre As Integer = 0
                    Dim dejeunerPu As Double = 0
                    Dim dinerNbre As Integer = 0
                    Dim dinerPu As Double = 0
                    Dim traiteurNbre As Integer = 0
                    Dim traiteurPu As Double = 0

                    Double.TryParse(GunaTextBox35.Text, nbreCafe)
                    Double.TryParse(GunaTextBoxForfaitCafe.Text, cafePu)
                    Double.TryParse(GunaTextBox30.Text, dejeunerNbre)
                    Double.TryParse(GunaTextBoxForfatiDejeuner.Text, dejeunerPu)
                    Double.TryParse(GunaTextBox25.Text, dinerNbre)
                    Double.TryParse(GunaTextBoxForfaitDiner.Text, dinerPu)
                    Double.TryParse(GunaTextBox13.Text, traiteurNbre)
                    Double.TryParse(GunaTextBoxForfaitTraiteur.Text, traiteurPu)

                    Dim NBRE__CAFE = nbreCafe
                    Dim PU_CAFE = cafePu
                    Dim NBRE_DEJEUNER = dejeunerNbre
                    Dim PU_DEJEUNER = dejeunerPu
                    Dim NBRE_DINER = dinerNbre
                    Dim PU_DINER = dinerPu
                    Dim NBRE_TRAITEUR = traiteurNbre
                    Dim PU_TRAITEUR = traiteurPu
                    Dim decorationCast As Double = 0
                    Double.TryParse(GunaTextBoxDecoration.Text, decorationCast)
                    Dim DECORATION = decorationCast

                    Dim LOCATION_MATERIEL As Double = 0
                    Dim AUTRES As Double = 0

                    If Not Trim(GunaTextBoxMateriel.Text) = "" Then
                        LOCATION_MATERIEL = GunaTextBoxMateriel.Text
                    End If

                    If Not Trim(GunaTextBoxAutres.Text) = "" Then
                        AUTRES = GunaTextBoxAutres.Text
                    End If

                    Dim CODE_EVENEMENT = ""
                    Dim LIBELLE_EVENEMENT = ""

                    If GunaComboBoxEvenement.SelectedIndex >= 0 Then

                        CODE_EVENEMENT = GunaComboBoxEvenement.SelectedValue

                        Dim evenement As DataTable = Functions.getElementByCode("CODE_EVENEMENT", "evenement", "CODE_EVENEMENT")

                        If evenement.Rows.Count > 0 Then
                            LIBELLE_EVENEMENT = evenement.Rows(0)("evenement")
                        End If

                    End If

                    Dim NBRE_GOUTER As Integer = 0
                    Dim PU_GOUTER As Double = 0
                    Dim NBRE_COCKTAIL As Integer = 0
                    Dim PU_COCKTAIL As Double = 0

                    If Not Trim(GunaTextBoxQteGouter.Text) = "" Then
                        NBRE_GOUTER = GunaTextBoxQteGouter.Text
                    End If

                    If Not Trim(GunaTextBoxPrixGouter.Text) = "" Then
                        PU_GOUTER = GunaTextBoxPrixGouter.Text
                    End If

                    If Not Trim(GunaTextBoxCocktail.Text) = "" Then
                        NBRE_COCKTAIL = GunaTextBoxCocktail.Text
                    End If

                    If Not Trim(GunaTextBoxPUCocktail.Text) = "" Then
                        PU_COCKTAIL = GunaTextBoxPUCocktail.Text
                    End If

                    '----------------------------------- addition --------------------------------------------------------

                    Dim HEURE_PAUSE_CAFE As String = ""
                    If GunaComboBoxHeureCafe.SelectedIndex >= 0 Then
                        HEURE_PAUSE_CAFE = GunaComboBoxHeureCafe.SelectedItem
                    End If

                    Dim HEURE_PAUSE_DEJEUNER As String = ""
                    If GunaComboBoxHeureDej.SelectedIndex >= 0 Then
                        HEURE_PAUSE_DEJEUNER = GunaComboBoxHeureDej.SelectedItem
                    End If

                    Dim HEURE_DINER As String = ""
                    If GunaComboBoxHeureDiner.SelectedIndex >= 0 Then
                        HEURE_DINER = GunaComboBoxHeureDiner.SelectedItem
                    End If

                    Dim HEURE_GOUTER As String = ""
                    If GunaComboBoxHeureGouter.SelectedIndex >= 0 Then
                        HEURE_GOUTER = GunaComboBoxHeureGouter.SelectedItem
                    End If

                    Dim HEURE_COCKTAIL As String = ""
                    If GunaComboBoxHeureCocktail.SelectedIndex >= 0 Then
                        HEURE_COCKTAIL = GunaComboBoxHeureCocktail.SelectedItem
                    End If

                    Dim VIDEO_PROJ As Integer = 0
                    If GunaCheckBoxVidOui.Checked Then
                        VIDEO_PROJ = 1
                    ElseIf GunaCheckBoxVidNon.Checked Then
                        VIDEO_PROJ = 0
                    Else
                        VIDEO_PROJ = 0
                    End If

                    Dim SONO As Integer = 0
                    If GunaCheckBoxSonoOui.Checked Then
                        SONO = 1
                    ElseIf GunaCheckBoxSonoNon.Checked Then
                        SONO = 0
                    Else
                        SONO = 0
                    End If

                    Dim COUVERTS As Integer = 0
                    If GunaCheckBoxCouvOui.Checked Then
                        COUVERTS = 1
                    ElseIf GunaCheckBoxCouvNon.Checked Then
                        COUVERTS = 0
                    Else
                        COUVERTS = 0
                    End If

                    Dim TABLE_CHAISE As Integer = 0
                    If GunaCheckBoxTableOui.Checked Then
                        TABLE_CHAISE = 1
                    ElseIf GunaCheckBoxTableNon.Checked Then
                        TABLE_CHAISE = 0
                    Else
                        TABLE_CHAISE = 0
                    End If

                    Dim EAU_PTE_QTE As Integer = 0
                    If Not Trim(GunaTextBox47.Text) = "" Then
                        EAU_PTE_QTE = GunaTextBox47.Text
                    End If

                    Dim EAU_PTE_MONTANT As Double = 0
                    If Not Trim(GunaTextBoxMontantEauPetiteBouteille.Text) = "" Then
                        EAU_PTE_MONTANT = GunaTextBoxMontantEauPetiteBouteille.Text
                    End If

                    Dim EAU_GRDE_QTE As Integer = 0
                    If Not Trim(GunaTextBox10.Text) = "" Then
                        EAU_GRDE_QTE = GunaTextBox10.Text
                    End If

                    Dim EAU_GRDE_MONTANT As Double = 0
                    If Not Trim(GunaTextBox68.Text) = "" Then
                        EAU_GRDE_MONTANT = GunaTextBox68.Text
                    End If

                    Dim BOISSONS_GAZEUSES_QTE As Integer = 0
                    If Not Trim(GunaTextBox48.Text) = "" Then
                        BOISSONS_GAZEUSES_QTE = GunaTextBox48.Text
                    End If

                    Dim BOISSONS_GAZEUSES_MONTANT As Double = 0
                    If Not Trim(GunaTextBox62.Text) = "" Then
                        BOISSONS_GAZEUSES_MONTANT = GunaTextBox62.Text
                    End If

                    Dim BIERES_QTE As Integer = 0
                    If Not Trim(GunaTextBox50.Text) = "" Then
                        BIERES_QTE = GunaTextBox50.Text
                    End If

                    Dim BIERES_MONTANT As Double = 0
                    If Not Trim(GunaTextBox61.Text) = "" Then
                        BIERES_MONTANT = GunaTextBox61.Text
                    End If

                    Dim VIN_ROUGE_QTE As Integer = 0
                    If Not Trim(GunaTextBox54.Text) = "" Then
                        VIN_ROUGE_QTE = GunaTextBox54.Text
                    End If

                    Dim VIN_ROUGE_MONTANT As Double = 0
                    If Not Trim(GunaTextBox59.Text) = "" Then
                        VIN_ROUGE_MONTANT = GunaTextBox59.Text
                    End If

                    Dim VIN_ROSE_QTE As Integer = 0
                    If Not Trim(GunaTextBox63.Text) = "" Then
                        VIN_ROSE_QTE = GunaTextBox63.Text
                    End If

                    Dim VIN_ROSE_MONTANT As Double = 0
                    If Not Trim(GunaTextBox64.Text) = "" Then
                        VIN_ROSE_MONTANT = GunaTextBox64.Text
                    End If

                    Dim BOISSONS_EXT_QTE As Integer = 0
                    If Not Trim(GunaTextBox36.Text) = "" Then
                        BOISSONS_EXT_QTE = GunaTextBox36.Text
                    End If

                    Dim BOISSONS_EXT_MONTANT As Double = 0
                    If Not Trim(GunaTextBox57.Text) = "" Then
                        BOISSONS_EXT_MONTANT = GunaTextBox57.Text
                    End If

                    Dim DROIT_DE_BOUCHON As Double = 0
                    If Not Trim(GunaTextBoxDroitDeBouchon.Text) = "" Then
                        DROIT_DE_BOUCHON = GunaTextBoxDroitDeBouchon.Text
                    End If

                    Dim MISE_EN_PLACE As Integer = 0 ' U

                    If GunaCheckBoxU.Checked Then
                        MISE_EN_PLACE = 1
                    ElseIf GunaCheckBoxEcole.Checked Then
                        MISE_EN_PLACE = 2 ' Ecole
                    ElseIf GunaCheckBoxTheatre.Checked Then
                        MISE_EN_PLACE = 3 ' Theatre
                    ElseIf GunaCheckBoxRectangle.Checked Then
                        MISE_EN_PLACE = 4 ' Rectangle
                    ElseIf GunaCheckBoxCocktail.Checked Then
                        MISE_EN_PLACE = 5 'Cocktail
                    ElseIf GunaCheckBoxBanquet.Checked Then
                        MISE_EN_PLACE = 6 'Banquet
                    End If

                    Dim CLOISONNEMENT As Integer = 0
                    If GunaCheckBox2.Checked Then
                        CLOISONNEMENT = 2
                    ElseIf GunaCheckBox9.Checked Then
                        CLOISONNEMENT = 3 ' Ecole
                    Else
                        CLOISONNEMENT = 0
                    End If
                    '-----------------------------------------------------------------------------------------------------
                    '----------- MAIN COURANTE JOURNALIERE ------------------------------

                    Dim CODE_MAIN_COURANTE_JOURNALIERE As String = Functions.GeneratingRandomCodeWithSpecifications("main_courante_journaliere", "MCJ")
                    Dim PDJ As Double = 0
                    Dim DEJEUNER As Double = 0
                    Dim DINER As Double = 0
                    Dim CAFE As Double = 0
                    Dim BAR As Double = 0
                    Dim CAVE As Double = 0
                    Dim AUTRE As Double = 0
                    Dim SOUS_TOTAL1 As Double = 0
                    Dim Location As Double = 0
                    Dim TELE As Double = 0
                    Dim FAX As Double = 0
                    Dim LINGE As Double = 0
                    Dim SOUS_TOTAL2 As Double = 0
                    Dim DEBITEUR As Double = 0
                    Dim ARRHES As Double = 0

                    If GunaCheckBoxPetitDejeuenerInclus.Checked Then

                        Dim petitDejeuner As Double = 0
                        Double.TryParse(GunaTextBoxPetitDejeuner.Text, petitDejeuner)
                        SOUS_TOTAL1 = petitDejeuner 'On gère les petit dejeuener inclus par apport a la valeur SOUS_TOTAL1 de la main courante journaliere

                    End If

                    '------------------------------- compte -----------------------------

                    Dim INTITULE As String = ""
                    Dim NUMERO_COMPTE As String = ""
                    Dim TOTAL_DEBIT As Double = GlobalVariable.MONTANT_TOTAL
                    Dim TOTAL_CREDIT As Double = GlobalVariable.avance
                    Dim SOLDE_COMPTE As Double = TOTAL_CREDIT - TOTAL_DEBIT

                    Dim SENS_DU_SOLDE As String = ""

                    If (TOTAL_DEBIT < TOTAL_CREDIT) Then
                        SENS_DU_SOLDE = "crediteur------------------------------------"
                    ElseIf (TOTAL_CREDIT < TOTAL_DEBIT) Then
                        SENS_DU_SOLDE = "debiteur-------------------------------------"
                    End If

                    Dim TYPE_DE_COMPTE As String = "debiteur"

                    Dim reservationConf As New Reservation()


                    'ROUTAGE PETIT DEJEUNER
                    Dim PETIT_DEJEUNER_ROUTAGE As Double = 0

                    If GunaCheckBoxPetitDejRoutage.Checked Then
                        Dim pdjRoutage As Double = 0
                        Double.TryParse(GunaTextBoxPetitDejeunerRoutage.Text, pdjRoutage)
                        PETIT_DEJEUNER_ROUTAGE = pdjRoutage
                    End If

                    'ROUTAGE LOGEMENT
                    Dim CHAMBRE_ROUTAGE As String = ""

                    If GunaCheckBoxChambreRoutage.Checked Then
                        If GunaComboBoxChambreRoutage.SelectedIndex >= 0 Then
                            CHAMBRE_ROUTAGE = GunaComboBoxChambreRoutage.SelectedValue.ToString
                        End If
                    End If

                    Dim VENANT_DE As String = GunaTextBoxVenantDe.Text
                    Dim SE_RENDANT_A As String = GunaTextBoxSerendantA.Text

                    Dim SOURCE_RESERVATION As String = ""

                    If GunaComboBoxSourceReservation.SelectedIndex >= 0 Then
                        SOURCE_RESERVATION = GunaComboBoxSourceReservation.SelectedValue.ToString
                    End If

                    Dim ROUTAGE As String = ""

                    If GlobalVariable.actualLanguageValue = 1 Then
                        ROUTAGE = "NON"
                    Else
                        ROUTAGE = "NO"
                    End If

                    If GunaCheckBoxChambreRoutage.Checked Then
                        If GlobalVariable.actualLanguageValue = 1 Then
                            ROUTAGE = "OUI"
                        Else
                            ROUTAGE = "YES"
                        End If
                    End If

                    Dim RAISON As String = ""

                    If GunaComboBoxTypeReservation.Items.Count > 0 Then
                        RAISON = GunaComboBoxTypeReservation.SelectedItem.ToString
                    End If

                    If GunaCheckBoxDayUse.Checked Then
                        DAY_USE = 1
                    End If

                    '-------------------------GESTION DE LIBERATION DES CHAMBRES POUR LES METTRES DANS DES CHAMBRES FICTIVE----------

                    ' Dim Solde As Double = Functions.SituationDuClient(GlobalVariable.codeClientToUpdate)
                    Dim Solde As Double = Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate)

                    Dim dialogCheckOut As DialogResult

                    If Not Solde = 0 Then

                        'Si nous avons un solde negatif ou positif

                        'dialogCheckOut = MessageBox.Show("Votre Solde est négatif voulez-vous continuer?", "Check out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                        If Solde < 0 Then

                            If GlobalVariable.actualLanguageValue = 1 Then
                                dialogCheckOut = MessageBox.Show("Impossible d'effectuer un Checkout avec un Solde Négatif !!!", "Check out", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            Else
                                dialogCheckOut = MessageBox.Show("Impossible to check out with a negatif Balance !!!", "Check out", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            End If

                        ElseIf Solde > 0 Then

                            If GlobalVariable.actualLanguageValue = 1 Then
                                dialogCheckOut = MessageBox.Show("Impossible d'effectuer un Checkout avec un Solde Positif !!!" & Chr(13) & " Bien vouloir procéder à un remboursement ", "Check out", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            Else
                                dialogCheckOut = MessageBox.Show("Impossible to check out with a positif !!!" & Chr(13) & " Please proceed to a refund ", "Check out", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            End If

                        End If

                        If dialogCheckOut = DialogResult.OK Then
                            ReglementForm.Close()
                            ReglementForm.Show()
                            ReglementForm.TopMost = True
                        End If

                    Else

                        'ON DOIT DTERMINER SI LE CHECKOUT EST FAISABLE CONCERNANT LES DAY USE

                        Dim continuer As Boolean = False

                        If GunaCheckBoxDayUse.Checked Then

                            Dim infoProcedureDayUse As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reglement", "CODE_RESERVATION")

                            If infoProcedureDayUse.Rows.Count > 0 Then
                                continuer = True
                            Else

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MessageBox.Show("Bien vouloir effectuer la procédure des Day Use " & Chr(13) & "(Facturation Manuelle en suite un Encaissement) !!!", "Day Use", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else
                                    MessageBox.Show("Please perform the Day Use procedure " & Chr(13) & " (Manual Billing & Cas In) !!!  ", "Day Use", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If

                            End If

                        Else

                            continuer = True

                        End If

                        If continuer Then

                            '-------------------------------------------- GESTION DES TRACES DES UTILISATEURS ----------------------------------------------------------

                            Dim ACTION_FAITE As String = GunaButtonCheckOut.Text
                            Dim FAITE_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

                            reservation.insertTrace(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, HEBDOMADAIRE, BC_ENTREPRISE, TYPE_CHAMBRE, ACTION_FAITE, FAITE_PAR, TYPE_CHAMBRE_OU_SALLE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE)

                            '------------------------ NORMAL CHECKOUT CAR SOLDE SUPEIEUR A ZERO -----------------------------

                            '-------------------------------------- MOUCHARDS ---------------------------------------------------
                            Dim ACTION As String = ""

                            If GlobalVariable.actualLanguageValue = 1 Then
                                ACTION = "CHECKOUT [CHAMBRE " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " DU " & DATE_ENTTRE & " - " & DATE_SORTIE & "]"
                            Else
                                ACTION = "CHECKOUT [ROOM " & GunaTextBoxNumeroChambre.Text & " / " & NOM_CLIENT & " FROM " & DATE_ENTTRE & " - " & DATE_SORTIE & "]"
                            End If
                            '----------------------------------------------------------------------------------------------------

                            If Not (GlobalVariable.codeReservationToUpdate = "") Then

                                User.mouchard(ACTION)

                                'Checkout meaning the reseravtion has been saved earlier
                                CODE_RESERVATION = GlobalVariable.codeReservationToUpdate

                                Dim CODE_SUIVI As String = Functions.GeneratingRandomCodeWithSpecifications("suivi_des_reservations", "SVR")
                                Dim CHECKOUT_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                                User.updateSuiviDesReservations("CHECKOUT_PAR", CHECKOUT_PAR, CODE_RESERVATION)

                                Dim operation As Integer = 1 'UPDATE
                                gestionDesNavettes(operation, CODE_RESERVATION)

                                'MISE AJOUR DE L'ETAT DE LA CHAMBRE

                                If reservationConf.updateReservationConf(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, "", DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, HEBDOMADAIRE, BC_ENTREPRISE, TYPE_CHAMBRE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE) Then

                                End If

                                If Not GlobalVariable.codeReservationToUpdate = "" Then
                                    'reservation.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reservation", GunaLabelSolde.Text)
                                    Dim updatedSolde As Double = Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate)
                                    reservation.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reservation", updatedSolde)
                                End If

                                'If GlobalVariable.typeChambreOuSalle = "salle" Then
                                'reservation.updateForfait(CODE_RESERVATION, NBRE__CAFE, PU_CAFE, NBRE_DEJEUNER, PU_DEJEUNER, NBRE_DINER, PU_DINER, NBRE_TRAITEUR, PU_TRAITEUR, DECORATION, LOCATION_MATERIEL, AUTRES, CODE_EVENEMENT, LIBELLE_EVENEMENT, NBRE_GOUTER, PU_GOUTER, NBRE_COCKTAIL, PU_COCKTAIL, HEURE_PAUSE_CAFE, HEURE_PAUSE_DEJEUNER, HEURE_DINER, HEURE_GOUTER, HEURE_COCKTAIL, VIDEO_PROJ, SONO, COUVERTS, TABLE_CHAISE, EAU_PTE_QTE, EAU_PTE_MONTANT, EAU_GRDE_QTE, EAU_GRDE_MONTANT, BOISSONS_GAZEUSES_QTE, BOISSONS_GAZEUSES_MONTANT, BIERES_QTE, BIERES_MONTANT, VIN_ROUGE_QTE, VIN_ROUGE_MONTANT, VIN_ROSE_QTE, VIN_ROSE_MONTANT, BOISSONS_EXT_QTE, BOISSONS_EXT_MONTANT, DROIT_DE_BOUCHON, MISE_EN_PLACE, CLOISONNEMENT)
                                'End If

                                'We update the checkin button so no to display the checkin button again
                                reservation.updateReservationConfCheckIn(CODE_RESERVATION)

                                'We update the room if everythig is ok

                                '--------------------------  COMPTE --------------------------

                                CODE_CLIENT = GlobalVariable.codeClientToUpdate
                                NUMERO_COMPTE = GlobalVariable.codeCompteToUpdate

                                'If compte.updateCompte(INTITULE, NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT, SOLDE_COMPTE, DATE_CREATION, TYPE_DE_COMPTE, SENS_DU_SOLDE) Then
                                'End If

                                '-------------------------- REGLEMENT --------------------------
                                If (Not Functions.entryCodeExists(NUM_REGLEMENT, "reglement", "NUM_REGLEMENT")) And (Not GlobalVariable.avance = 0) Then

                                    NUM_REGLEMENT = GlobalVariable.codeFactureToUpdate
                                    REF_REGLEMENT = GlobalVariable.codeReglementToUpdate
                                    CODE_RESERVATION = GlobalVariable.codeReservationToUpdate
                                    CODE_CLIENT = GlobalVariable.codeClientToUpdate

                                    'If reglement.updateReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT) Then

                                    'End If

                                End If

                                '-------------------------- OCCUPATION CHAMBRE--------------------------
                                'If Not Functions.entryCodeExists(CODE_OCCUPATION_CHAMBRE, "occupation_chambre", "CODE_OCCUPATION_CHAMBRE") Then

                                CODE_RESERVATION = GlobalVariable.codeReservationToUpdate
                                CODE_CHAMBRE = GlobalVariable.codeChambreToUpdate
                                CODE_CLIENT_REEL = GlobalVariable.codeClientToUpdate

                                If occupationChambre.insertOccupationChambre(CODE_OCCUPATION_CHAMBRE, CODE_RESERVATION, CODE_CHAMBRE, MONTANT_HT, TAXE, MONTANT_TTC, DATE_OCCUPATION, ETAT_CHAMBRE, OBSERVATIONS, COMMENTAIRE1, COMMENTAIRE2, COMMENTAIRE3, COMMENTAIRE4, DATE_LIBERATION, CODE_UTILISATEUR_CREA, DATE_PREMIERE_ARRIVEE, TYPE_RESERVATION, PDJ_INCLUS, TAXE_SEJOURS_INCLUS, TVA_INCLUS, CODE_CLIENT_REEL, CODE_AGENCE) Then

                                End If

                                'End If


                                'We check if the the main courante journaliere already exist
                                If Not Functions.entryCodeExists(CODE_MAIN_COURANTE, "main_courante_journaliere", "CODE_MAIN_COURANTE_JOURNALIERE") Then

                                    'If mainCourante.updateMainCouranteJournaliere(CODE_MAIN_COURANTE_JOURNALIERE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, Location, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE_CHAMBRE_OU_SALLE) Then

                                    'End If

                                End If

                                'End If


                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MessageBox.Show("Check Out de " & NOM_CLIENT & " du " & DATE_ENTTRE & " au " & DATE_SORTIE & " effectué avec succès!!", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Else
                                    MessageBox.Show("Check Out of " & NOM_CLIENT & " from " & DATE_ENTTRE & " to " & DATE_SORTIE & " done successfully !!", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                End If
                                'GunaButtonCheckOut.Visible = False

                            End If

                            '-------------------------- UPDATE ROOM --------------------------------
                            Dim updateQuery As String = "UPDATE `chambre` Set `ETAT_CHAMBRE`=@ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE =@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@code "

                            Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                            command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
                            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = GlobalVariable.codeChambre
                            command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_sale

                            '---------UN CLIENT DONT ON A FAIT LE CHECKOUT NE DOIT PLUS APPARAITRE SUR LA MAINS COURANTES ------------------------------------

                            '1- ON DOIT METTERE A JOUR L'ETAT DE LA RESERVATION DONT ON A FAIT LE CHEKOUT POUR QU'IL N'APPARAISSENT PLUS SUR LA MAIN COURANTE

                            Dim ETAT_MAIN_COURANTE As Integer = 1

                            reservation.miseAjourEtatMainCourante(GlobalVariable.codeMainCouranteJournaliereToUpdate, ETAT_MAIN_COURANTE)

                            'CHANGEMENT DE L'ETAT DE LA RESERVATION
                            reservation.etatReservation(CODE_RESERVATION, ETAT_RESERVATION, ETAT_NOTE_RESERVATION)
                            '---------------------------------------------------------------------------------------------------------------------------------

                            '---------------------------------------------ENVOI DES MESSAGES WHATSAPP------------------------------------------------------------------------
                            Dim NUITEES As Integer = 0

                            Dim NOMBRE_HEURE As Integer = CType((DateTimeDepart - DateTimeArrivee).TotalHours, Int32)
                            NUITEES = CType((DATE_SORTIE - DATE_ENTTRE).TotalDays, Int32)

                            Dim RESA_TYPE As String = ""

                            If NUITEES = 0 Then


                                If GlobalVariable.actualLanguageValue = 1 Then
                                    RESA_TYPE = "HEURE(S)"
                                Else
                                    RESA_TYPE = "HOUR(S)"
                                End If

                                NUITEES = NOMBRE_HEURE
                            Else
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    RESA_TYPE = "NUITEE(S)"

                                Else
                                    RESA_TYPE = "NIGHT(S)"

                                End If

                            End If

                            Dim NoReception = GlobalVariable.AgenceActuelle.Rows(0)("NUMERO_RECEPTION")
                            Dim NoTelChambre = GlobalVariable.AgenceActuelle.Rows(0)("NUMERO_RECEPTION_CHAMBRE")

                            If GlobalVariable.actualLanguageValue = 1 Then
                                whatsAppMessage = "CHECKOUT " & Chr(13) & " -/ PAR : " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & Chr(13) & " -/ A : " & Now().ToShortTimeString & Chr(13) & " -/ ARRIVEE : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & " -/ DEPART : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & " -/ " & RESA_TYPE & " : " & NUITEES & Chr(13) & " -/ CLIENT : " & NOM_CLIENT & Chr(13) & " -/ TYPE DE CHAMBRE : " & TYPE_CHAMBRE & Chr(13) & " -/ CHAMBRE : " & CHAMBRE_ID & Chr(13) & " -/ MONTANT :  " & MONTANT_ACCORDE & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " */ MONTANT TOTAL : " & NUITEES * MONTANT_ACCORDE
                                _whatsAppMessage = Chr(13) & "Cher " & NOM_CLIENT & Chr(13) & Chr(13) & "Merci d'avoir séjourné parmi nous à " & GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE") & "." & Chr(13) & Chr(13) & "Nous espérons que votre séjour a été agréable et espérons que vous continuerez à utiliser notre hôtel pour vos besoins d'hébergement dans un proche avenir." & Chr(13) & Chr(13) & " Si vous avez des suggestions concernant notre établissement, nous serons heureux de vous écouter au " & NoReception & "." & Chr(13) & Chr(13) & "Nous nous réjouissons d’avance de vous servir lors de votre prochain voyage." & Chr(13) & Chr(13) & " Cordialement"
                            Else
                                whatsAppMessage = "DEPARTURE " & Chr(13) & " -/ BY : " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & Chr(13) & " -/ AT : " & Now().ToShortTimeString & Chr(13) & " -/ ARRIVAL : " & DATE_ENTTRE & " " & CDate(HEURE_ENTREE).ToShortTimeString & Chr(13) & " -/ DEPARTURE : " & DATE_SORTIE & " " & CDate(HEURE_SORTIE).ToShortTimeString & Chr(13) & " -/ " & RESA_TYPE & " : " & NUITEES & Chr(13) & " -/ CLIENT : " & NOM_CLIENT & Chr(13) & " -/ ROOM TYPE : " & TYPE_CHAMBRE & Chr(13) & " -/ ROOM : " & CHAMBRE_ID & Chr(13) & " -/ AMOUNT :  " & MONTANT_ACCORDE & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & " */ MONTANT TOTAL : " & NUITEES * MONTANT_ACCORDE
                                _whatsAppMessage = Chr(13) & "Dear " & NOM_CLIENT & Chr(13) & Chr(13) & "Thank you for staying with us at " & GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE") & "." & Chr(13) & Chr(13) & "We hope you enjoyed your stay and hope you will continue to use our hotel for your accommodation needs in the near future." & Chr(13) & Chr(13) & " If you have any suggestions regarding our establishment, we would be delighted to hear from you at " & NoReception & "." & Chr(13) & Chr(13) & "We look forward To serving you On your Next trip." & Chr(13) & Chr(13) & "Kind regards"
                            End If

                            Dim lStatus As Integer
                            Dim CardNo As Integer = 0
                            Dim RoomNo As String

                            RoomNo = CHAMBRE_ID


                            Dim args As ArgumentType = New ArgumentType()

                            If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                                Dim mobile_number As String = listeOfTelephoneNumbers()

                                args.action = 0
                                args.whatsAppMessage = whatsAppMessage
                                args.mobile_number = mobile_number

                                backGroundWorkerToCall(args)

                                'Functions.ultrMessageSimpleText(whatsAppMessage, mobile_number)

                            End If

                            '---------------------------------------------ENVOI DES MESSAGES WHATSAPP------------------------------------------------------------------------

                            'Excuting the command and testing if everything went on well
                            If (command.ExecuteNonQuery() = 1) Then
                                'connect.closeConnection()
                            End If

                            'GunaLabelNumReservation.Text = CODE_RESERVATION
                            'GESTION DES GRATUITEES
                            gestionDelaGratuiteeDeLaReservation()

                            'GESTION DES PRISES EN CHARGES DE LA RESERVATION
                            gestionDelaPriseEnChargeDeLaReservation()

                            'Gestion du désencodage

                            GunaLabelSolde.ForeColor = Color.Black

                            Dim ZenoLockForm As New ZenoLockForm()

                            Dim dialog As New DialogResult()

                            Dim args_ As New ArgumentType

                            If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                                args_.action = 0
                                args_.whatsAppMessage = _whatsAppMessage
                                args_.mobile_number = TELEPHONE_CLIENT

                                backGroundWorkerToCall(args_)

                            End If

                            dt = GlobalVariable.ReservationToUpdate

                            VidageDesChampsPourNouvelleReservation()

                            'We empty the fields
                            emtptyRegistrationFields()

                            'ReservationList()

                            'We update the buttons to display
                            reservationButtonToDisplay()

                            'we set all the global variables used for updates using code
                            Functions.EmtyGlobalVariablesContainingCodeToUpdate()
                            ReinitialisationDesDates()

                            'We prevent from choosing a room if a room type is not first choosen
                            'GunaTextBoxNumeroChambre.BaseColor = Color.Beige
                            GunaTextBoxNumeroChambre.Enabled = True

                            GunaLabelSolde.ForeColor = Color.Black
                            GunaLabelSolde.Text = 0

                            GunaCheckBoxPetitDejeuenerInclus.Checked = False
                            GunaCheckBoxTaxeSejour.Checked = False
                            GunaTextBoxPetitDejeuner.Visible = False
                            GunaTextBoxPetitDejeunerRoutage.Visible = False

                            reservationButtonToDisplay()

                            GunaButtonCheckOut.Visible = False

                            GunaTextBoxBC.Visible = False

                            GunaTextBoxNbreAdulte.Text = 0

                        End If

                    End If

                    If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then

                        Dim elite_traitement As Boolean = True

                        If elite_traitement Then
                            Dim elite As New ClubElite()
                            elite.remplissageDesChampsPermettantLeUpGradingDuClient_(CODE_CLIENT, dt)
                        End If

                    End If

                    Me.Cursor = Cursors.Default

                End If

            End If
        End If

    End Sub

    Public Function listeOfTelephoneNumbers() As String

        Dim mobile_number As String

        If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_1")).Equals("") Then
            mobile_number = GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_1")
        End If

        If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_2")).Equals("") Then
            If Trim(mobile_number).Equals("") Then
                mobile_number = GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_2")
            Else
                mobile_number += "," & GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_2")
            End If
        End If

        If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_3")).Equals("") Then
            If Trim(mobile_number).Equals("") Then
                mobile_number = GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_3")
            Else
                mobile_number += "," & GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_3")
            End If
        End If

        If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_4")).Equals("") Then
            If Trim(mobile_number).Equals("") Then
                mobile_number = GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_4")
            Else
                mobile_number += "," & GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_4")
            End If
        End If

        If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_5")).Equals("") Then
            If Trim(mobile_number).Equals("") Then
                mobile_number = GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_5")
            Else
                mobile_number += "," & GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_5")
            End If
        End If

        If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_6")).Equals("") Then
            If Trim(mobile_number).Equals("") Then
                mobile_number = GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_6")
            Else
                mobile_number += "," & GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_6")
            End If
        End If

        If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_7")).Equals("") Then
            If Trim(mobile_number).Equals("") Then
                mobile_number = GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_7")
            Else
                mobile_number += "," & GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_7")
            End If
        End If

        Return mobile_number

    End Function
    '--------------------------------------------------- TABS GESTION DES ATTENDUS - EN CHAMBRES - DEPARTS --------------------------------------
    '-----------------------------------------------------------------------TABS MANAGEMENT ---------------------------------------------------------------
    '--------------------------------------- GRSTION DES RESERVATIONS --------------------------------------------------------
    Public Sub ReservationList(ByVal searchField As String, ByVal searchValue As String, Optional ByVal DateSearch As String = "")

        Dim query As String = ""
        Dim query1 As String = ""
        Dim query01 As String = ""
        Dim table As New DataTable()
        Dim table01 As New DataTable()


        'SI L'ON SE CONNECTE AVEC UN PROFILE AYANT LA GESTION DE LA FISCALITE

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FISCALITE") = 1 Then

            If searchField = "all" Then

                query1 = "Select NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf, source_reservation WHERE TYPE=@TYPE AND FSC=@FSC AND reserve_conf.SOURCE_RESERVATION = source_reservation.CODE_SOURCE_RESERVATION ORDER BY CHAMBRE_ID ASC"

                Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
                command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command1.Parameters.Add("@FSC", MySqlDbType.Int32).Value = 1

                Dim adapter1 As New MySqlDataAdapter(command1)
                Dim table1 As New DataTable()
                adapter1.Fill(table1)

            ElseIf searchField = "entreprise" Or searchField = "individuelle" Or searchField = "groupe" Then

                Dim custom As String = ""

                If searchField = "entreprise" Then
                    custom = " NOM_ENTREPRISE NOT IN ('', ' ')"
                ElseIf searchField = "individuelle" Then
                    custom = " NOM_ENTREPRISE IN ('', ' ')"
                ElseIf searchField = "groupe" Then
                    custom = " GROUPE NOT IN ('', ' ')"
                End If

                'query1 = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE FSC=@FSC AND DAY_USE=@DAY_USE AND TYPE=@TYPE AND " & custom & " ORDER BY CHAMBRE_ID ASC"
                query1 = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE FSC=@FSC AND TYPE=@TYPE AND " & custom & " ORDER BY CHAMBRE_ID ASC"

                Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
                command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command1.Parameters.Add("@FSC", MySqlDbType.Int32).Value = 1

                Dim adapter1 As New MySqlDataAdapter(command1)
                Dim table1 As New DataTable()
                adapter1.Fill(table1)

                table.Merge(table1)


            Else

                query1 = "Select NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE TYPE=@TYPE AND FSC=@FSC AND DAY_USE=@DAY_USE AND " & searchField & "  LIKE '%" & searchValue & "%' ORDER BY CHAMBRE_ID ASC"

                Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
                command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command1.Parameters.Add("@searchField", MySqlDbType.VarChar).Value = searchValue
                command1.Parameters.Add("@DAY_USE", MySqlDbType.Int64).Value = 0
                command1.Parameters.Add("@FSC", MySqlDbType.Int64).Value = 1

                Dim adapter1 As New MySqlDataAdapter(command1)
                Dim table1 As New DataTable()
                adapter1.Fill(table1)

                table.Merge(table1)

            End If

        Else

            If searchField = "all" Then

                query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reservation WHERE TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)
                command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

                Dim adapter As New MySqlDataAdapter(command)

                adapter.Fill(table)

                query1 = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

                Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
                command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

                Dim adapter1 As New MySqlDataAdapter(command1)
                Dim table1 As New DataTable()
                adapter1.Fill(table1)

                table.Merge(table1)

            ElseIf searchField = "entreprise" Or searchField = "individuelle" Or searchField = "groupe" Then

                Dim custom As String = ""

                If searchField = "entreprise" Then
                    custom = " NOM_ENTREPRISE NOT IN ('', ' ')"
                ElseIf searchField = "individuelle" Then
                    custom = " NOM_ENTREPRISE IN ('', ' ')"
                ElseIf searchField = "groupe" Then
                    custom = " GROUPE NOT IN ('', ' ')"
                End If

                query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reservation WHERE TYPE=@TYPE AND " & custom & " ORDER BY CHAMBRE_ID ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)
                command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

                Dim adapter As New MySqlDataAdapter(command)

                adapter.Fill(table)

                query1 = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE TYPE=@TYPE AND " & custom & " ORDER BY CHAMBRE_ID ASC"

                Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
                command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

                Dim adapter1 As New MySqlDataAdapter(command1)
                Dim table1 As New DataTable()
                adapter1.Fill(table1)

                table.Merge(table1)


            Else

                query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reservation WHERE TYPE=@TYPE AND " & searchField & " LIKE '%" & searchValue & "%' ORDER BY CHAMBRE_ID ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)
                command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command.Parameters.Add("@searchField", MySqlDbType.VarChar).Value = searchValue

                Dim adapter As New MySqlDataAdapter(command)

                adapter.Fill(table)

                query1 = "Select NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE TYPE=@TYPE AND " & searchField & "  LIKE '%" & searchValue & "%' ORDER BY CHAMBRE_ID ASC"

                Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
                command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command1.Parameters.Add("@searchField", MySqlDbType.VarChar).Value = searchValue

                Dim adapter1 As New MySqlDataAdapter(command1)
                Dim table1 As New DataTable()
                adapter1.Fill(table1)

                table.Merge(table1)

            End If

        End If

        If (table.Rows.Count > 0) Then

            GunaDataGridViewReservationList.DataSource = table

            GunaDataGridViewReservationList.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            GunaDataGridViewReservationList.DefaultCellStyle.SelectionForeColor = Color.White
            GunaDataGridViewReservationList.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewReservationList.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For i = 0 To GunaDataGridViewReservationList.Rows.Count - 1

                If GunaDataGridViewReservationList.Rows(i).Cells("SOLDE").Value < 0 Then
                    GunaDataGridViewReservationList.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                    GunaDataGridViewReservationList.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If

            Next

        Else

            GunaDataGridViewReservationList.Columns.Clear()

        End If

    End Sub




    ''--------------------------- START ATTENDUS TAB ---------------------------------

    'we empty the datagrid whe tab when activated

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlHbergement.Selected

        DataGridViewAttenduPanel.Columns.Clear()

        DataGridViewEnChambre.Columns.Clear()

        DataGridViewDepartTab.Columns.Clear()

    End Sub

    Dim nombreDesAttendus As Integer = 0
    Dim nombreDesEnChambres As Integer = 0
    Dim nombreDesDeparts As Integer = 0

    Public Sub ListeDesAttendues()

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GunaDateTimePickerFin.Value.ToString("yyyy-MM-dd")

        If (GunaDateTimePickerDebut.Value <= GunaDateTimePickerFin.Value) Then

            Dim query As String = ""

            If GlobalVariable.attribuerChambre = True Then

                query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reservation WHERE DATE_ENTTRE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND ETAT_RESERVATION= 0 AND CHAMBRE_ID IN ('','-') ORDER BY CHAMBRE_ID ASC"

            Else

                query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reservation WHERE DATE_ENTTRE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND ETAT_RESERVATION= 0 ORDER BY CHAMBRE_ID ASC"

            End If
            'On Affiche toute reservation dont la date d'entree figure entre les deux dates saisies

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            'command.Parameters.Add("@CHAMBRE_ID", MySqlDbType.VarChar).Value = "-"

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                DataGridViewAttenduPanel.DataSource = table

                DataGridViewAttenduPanel.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
                DataGridViewAttenduPanel.DefaultCellStyle.SelectionForeColor = Color.White
                DataGridViewAttenduPanel.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
                DataGridViewAttenduPanel.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DataGridViewAttenduPanel.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
                DataGridViewAttenduPanel.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                For i = 0 To DataGridViewAttenduPanel.Rows.Count - 1

                    If DataGridViewAttenduPanel.Rows(i).Cells("SOLDE").Value < 0 Then
                        DataGridViewAttenduPanel.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        DataGridViewAttenduPanel.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    End If

                Next

            Else

                DataGridViewAttenduPanel.Columns.Clear()

            End If

            'connect.closeConnection()
        Else

            DataGridViewAttenduPanel.Columns.Clear()

        End If


    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherArrivee.Click

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()
        'ReinitialisationDesDates()

        DataGridViewAttenduPanel.Columns.Clear()

        ListeDesAttendues()

        If DataGridViewAttenduPanel.Rows.Count > 0 Then
            GunaLabelNbreAttendu.Text = "(" & DataGridViewAttenduPanel.Rows.Count & ")"
        Else
            GunaLabelNbreAttendu.Text = "(0)"
        End If

    End Sub


    ''--------------------------- START EN CHAMBRE TAB ---------------------------------

    '---------------------------------------- LIVE SEARCH -------------------------------------

    Public Sub ListeDesEnChambres()

        'On affiche toutes les reserv_conf dont la date saisie est entre la d'entrée et la date de sortie (inclusif)

        Dim DateDebut As Date = GunaDateTimePickerDebutEnChambre.Value.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewEnChambre.DataSource = table

            DataGridViewEnChambre.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            DataGridViewEnChambre.DefaultCellStyle.SelectionForeColor = Color.White
            DataGridViewEnChambre.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
            DataGridViewEnChambre.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridViewEnChambre.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
            DataGridViewEnChambre.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridViewEnChambre.Columns("RESERVATION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewEnChambre.Columns("CHAMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewEnChambre.Columns("NOM CLIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For i = 0 To DataGridViewEnChambre.Rows.Count - 1

                If DataGridViewEnChambre.Rows(i).Cells("SOLDE").Value < 0 Then
                    DataGridViewEnChambre.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                    DataGridViewEnChambre.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If

            Next

        Else

            DataGridViewEnChambre.Columns.Clear()

        End If

        'connect.closeConnection()

    End Sub

    'When we select a date an press the print button
    Private Sub GunaButtonEnChambre_Click(sender As Object, e As EventArgs) Handles GunaButtonEnChambreAfficher.Click

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()
        'ReinitialisationDesDates()

        DataGridViewEnChambre.Columns.Clear()

        ListeDesEnChambres()

        If DataGridViewEnChambre.Rows.Count > 0 Then
            GunaLabelNbreEnChambre.Text = "(" & DataGridViewEnChambre.Rows.Count & ")"
        Else
            GunaLabelNbreEnChambre.Text = "(0)"
        End If

    End Sub

    ''--------------------------- END EN CHAMBRE TAB ---------------------------------


    '-------------------------------------- START DEPART PANEL -------------------------------
    Public Sub ListeDesDeparts()

        Dim DateDebut As Date = GunaDateTimePickerArriveeDepart.Value.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GunaDateTimePickerDepartDepert.Value.ToString("yyyy-MM-dd")

        If (GunaDateTimePickerArriveeDepart.Value <= GunaDateTimePickerDepartDepert.Value) Then

            Dim query As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE DATE_SORTIE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                DataGridViewDepartTab.DataSource = table

                DataGridViewDepartTab.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
                DataGridViewDepartTab.DefaultCellStyle.SelectionForeColor = Color.White
                DataGridViewDepartTab.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
                DataGridViewDepartTab.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DataGridViewDepartTab.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
                DataGridViewDepartTab.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                For i = 0 To DataGridViewDepartTab.Rows.Count - 1

                    If DataGridViewDepartTab.Rows(i).Cells("SOLDE").Value < 0 Then
                        DataGridViewDepartTab.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        DataGridViewDepartTab.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    End If

                Next

            Else

                DataGridViewDepartTab.Columns.Clear()

            End If

            'connect.closeConnection()
        End If

    End Sub

    'outputting the elements of the departure tab at the font office depending on two dates and departure date
    Private Sub GunaButtonAfficherDepart_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherDepart.Click

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()
        'ReinitialisationDesDates()

        DataGridViewDepartTab.Columns.Clear()

        ListeDesDeparts()

        If DataGridViewDepartTab.Rows.Count > 0 Then
            GunaLabelNbreDeparts.Text = "(" & DataGridViewDepartTab.Rows.Count & ")"
        Else
            GunaLabelNbreDeparts.Text = "(0)"
        End If

    End Sub

    '-------------------------------------- END DEPART PANEL -------------------------------

    '---------------------------------------------------FACTURATION MANAGEMENT

    '------------------------------------FACTURATION BASED ON THE ARTICLE FAMILY ONLY FOR IN ROOM-----------------------------------------------
    'On ne peut facturer ceux qui sont en chambre
    Private Sub FacturationDesEnChambres()

        If Not GlobalVariable.codeReservationToUpdate = "" Then
            'As we come from the MainCouranteReception 
            Dim clientInRoom As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

            If clientInRoom.Rows.Count > 0 Then
                'We selected the room in reserve_conf hence reservation has been checkedIn
                If clientInRoom.Rows(0)("ETAT_RESERVATION") = 1 Then
                    'We can output the the facturationForm has our reservation is a checked reservation with out checkout
                    FacturationForm.Show()
                End If
            End If

        End If

    End Sub

    'Facturation based on the bar/restaurant (clicked at front desk) family
    Private Sub GunaButtonBar_Click(sender As Object, e As EventArgs)

        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "BAR"
        FacturationForm.Show()
        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)

    End Sub

    'Facturation based on the bar/restaurant (clicked at front desk) family
    Private Sub GunaButtonRestaurant_Click(sender As Object, e As EventArgs)

        GlobalVariable.checkInFacturation = True
        GlobalVariable.ArticleFamily = "RESTAURANT"
        FacturationForm.Show()
        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk

    End Sub

    'Facturation based on the services (clicked at front desk) family
    Private Sub GunaButtonServices_Click(sender As Object, e As EventArgs)

        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "SERVICES"

        FacturationForm.Show()

    End Sub

    'Facturation based on the salon de beaute (clicked at front desk) family
    Private Sub GunaButtonSalonDeBeaute_Click(sender As Object, e As EventArgs)
        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "SALON DE BEAUTE"
        FacturationForm.Show()

    End Sub

    'Facturation based on boutique
    Private Sub GunaButtonBoutique_Click(sender As Object, e As EventArgs)
        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "BOUTIQUE"

        FacturationForm.Show()

    End Sub

    Private Sub GunaButtonCyberCafe_Click(sender As Object, e As EventArgs)
        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "BUSINESS CENTER"

        FacturationForm.Show()

    End Sub

    Private Sub GunaButtonAutres_Click(sender As Object, e As EventArgs)
        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "AUTRES"

        FacturationForm.Show()

    End Sub

    Private Sub GunaButtonLoisir_Click(sender As Object, e As EventArgs)
        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "LOISIRS"

        FacturationForm.Show()

    End Sub

    Private Sub GunaButtonKiosque_Click(sender As Object, e As EventArgs)
        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "KIOSQUE A JOURNAUX"

        FacturationForm.Show()
    End Sub

    Private Sub GunaButtonSport_Click(sender As Object, e As EventArgs)

        FacturationForm.Close()

        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "SPORTS"

        FacturationForm.Show()

    End Sub

    Private Sub GunaButtonBlanchisserie_Click(sender As Object, e As EventArgs)

        FacturationForm.Close()

        FacturationForm.TopMost = True
        FacturationForm.Location = New System.Drawing.Point(10, 104)
        'To know if we come from the frontdesk
        GlobalVariable.checkInFacturation = True

        GlobalVariable.ArticleFamily = "BLANCHISSERIE"

        FacturationForm.Show()
    End Sub

    '---------------------------------- SITUATION DU CLIENT EN DOUBLE CLIQUANT SUR LE SOLDE ----------------------------------

    'When we double click on solde textbox we open SituationClientForm

    Private Sub GunaPanelSolde_DoubleClick(sender As Object, e As EventArgs) Handles GunaPanelSolde.DoubleClick

        SituationClientForm.Close()
        SituationClientForm.Show()
        SituationClientForm.TopMost = True

    End Sub

    Private Sub GunaLabelSolde_DoubleClick(sender As Object, e As EventArgs) Handles GunaLabelSolde.DoubleClick

        SituationClientForm.Close()
        SituationClientForm.Show()
        SituationClientForm.TopMost = True

    End Sub

    '---------------------------------- SITUATION DU CLIENT ----------------------------------


    'CHANGEMENT DE LABEL DES DATES POUR CHAQUE TAB-----------------------------------

    'Tab En chambre
    'En cas de changement de date on renomme les labelles pour chaque tab
    Private Sub GunaDateTimePickerDebutEnChambre_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDebutEnChambre.ValueChanged
        GunaLabel50.Text = GunaDateTimePickerDebutEnChambre.Value.ToShortDateString()
    End Sub

    'Tab Departs
    Private Sub GunaDateTimePickerArriveeDepart_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerArriveeDepart.ValueChanged
        GunaLabelDateDepartFin.Text = GunaDateTimePickerDepartDepert.Value.ToShortDateString()
        GunaLabelDateDepartDebut.Text = GunaDateTimePickerArriveeDepart.Value.ToShortDateString()
    End Sub

    Private Sub GunaDateTimePickerDepartDepert_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDepartDepert.ValueChanged
        GunaLabelDateDepartFin.Text = GunaDateTimePickerDepartDepert.Value.ToShortDateString()
        GunaLabelDateDepartDebut.Text = GunaDateTimePickerArriveeDepart.Value.ToShortDateString()
    End Sub

    'Tab Attendus
    Private Sub GunaDateTimePickerDebut_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDebut.ValueChanged
        GunaLabel53.Text = GunaDateTimePickerFin.Value.ToShortDateString()
        GunaLabel54.Text = GunaDateTimePickerDebut.Value.ToShortDateString()
    End Sub

    Private Sub GunaDateTimePickerFin_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerFin.ValueChanged
        GunaLabel53.Text = GunaDateTimePickerFin.Value.ToShortDateString()
        GunaLabel54.Text = GunaDateTimePickerDebut.Value.ToShortDateString()
    End Sub

    '--------------------------------------------------- GESTION DES DATAGRIDS DES ENTENDUS - EN CHAMBRES - DEPARTS ---------------

    '------------------------------------- LOADING OF THE CONTENT OF A TAB INTO THE FRONT DESK ---------------------------------------------
    'EN CHAMBRE GRID
    Private Sub DataGridViewEnChambre_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEnChambre.CellDoubleClick

        viderDocumentDatagrids()
        VidageDesChampsPourNouvelleReservation()

        If e.RowIndex >= 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelNatureReservation.Text = "EN CHAMBRE"
            Else
                LabelNatureReservation.Text = "IN HOUSE"
            End If

            Dim row As DataGridViewRow

            row = Me.DataGridViewEnChambre.Rows(e.RowIndex)

            GlobalVariable.codeReservationToUpdate = row.Cells("RESERVATION").Value.ToString

            'We first search in reservation 
            GlobalVariable.ReservationToUpdate = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION")

            If Not GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                'not found in reservation so, we search in reserve
                GlobalVariable.ReservationToUpdate = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

                'Variable to print or not checkout button
                GlobalVariable.reserveConfCheckInState = GlobalVariable.ReservationToUpdate(0)("CHECKIN")
            End If

            GlobalVariable.codeClientToUpdate = GlobalVariable.ReservationToUpdate(0)("CLIENT_ID")
            GlobalVariable.ClientToUpdate = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "client", "CODE_CLIENT")

            'On selectionne code_main_courante
            Dim tableMainCourante As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante", "CODE_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCourante.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteToUpdate = tableMainCourante.Rows(0)("CODE_MAIN_COURANTE")
                GlobalVariable.MainCouranteToUpdate = tableMainCourante
            End If

            Dim ETAT_MAIN_COURANTE As Integer = 0

            'On selectionne code_main_courante_generale
            Dim tableMainCouranteGenerale As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_generale", "NUM_RESERVATION", ETAT_MAIN_COURANTE, "ETAT_MAIN_COURANTE")
            'Dim tableMainCouranteGenerale As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "main_courante_generale", "NUM_RESERVATION")

            If tableMainCouranteGenerale.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteGeneraleToUpdate = tableMainCouranteGenerale.Rows(0)("CODE_MAIN_COURANTE_GENERALE")
                GlobalVariable.MainCouranteGeneraleToUpdate = tableMainCouranteGenerale
            End If

            'On selectionne code_main_courante_journaliere
            Dim tableMainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", ETAT_MAIN_COURANTE, "ETAT_MAIN_COURANTE")

            If tableMainCouranteJournaliere.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteJournaliereToUpdate = tableMainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                GlobalVariable.MainCouranteJournaliereToUpdate = tableMainCouranteJournaliere
                mainCouranteJournaliere = tableMainCouranteJournaliere
            End If

            'On selectionne NUM_REGLEMENT
            Dim tableReglement As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reglement", "CODE_RESERVATION")

            If tableReglement.Rows.Count > 0 Then
                'GlobalVariable.codeReglementToUpdate = tableReglement.Rows(0)("NUM_REGLEMENT")
                'GlobalVariable.ReglementToUpdate = tableReglement
            End If

            'On selectionne CODE_OCCUPATION_CHAMBRE
            Dim tableOccupationChambre As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "occupation_chambre", "CODE_RESERVATION")
            If tableOccupationChambre.Rows.Count > 0 Then
                'GlobalVariable.codeOccupationchambreToUpdate = tableOccupationChambre.Rows(0)("CODE_OCCUPATION_CHAMBRE")
                'GlobalVariable.OccupationchambreToUpdate = tableOccupationChambre
            End If

            'On selectionne NUM_FACTURE
            Dim tableFacture As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "facture", "CODE_RESERVATION")

            If tableFacture.Rows.Count > 0 Then

                ' GlobalVariable.codeFactureToUpdate = tableFacture.Rows(0)("CODE_FACTURE")
                'GlobalVariable.FactureToUpdate = tableFacture

            End If

            'On selectionne le compte du client using CODE_COMPTE
            Dim tableCompte As DataTable = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "compte", "CODE_CLIENT")

            If tableCompte.Rows.Count > 0 Then

                GlobalVariable.codeCompteToUpdate = tableCompte.Rows(0)("NUMERO_COMPTE")
                GlobalVariable.sensDuSoldeDuCompte = tableCompte.Rows(0)("SENS_DU_SOLDE")
                GlobalVariable.CompteToUpdate = tableCompte

            End If

            GlobalVariable.codeChambreToUpdate = GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID")
            GlobalVariable.ChambreToUpdate = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")

            'As the two values below can not more be updated when we come from maincouranteReception because of the event leave
            GlobalVariable.codeChambre = GlobalVariable.codeChambreToUpdate

            If GunaRadioButtonSalleFete.Checked Then

                Dim chambrePourType As DataTable
                Dim typeChambre As DataTable

                If GlobalVariable.ChambreToUpdate.Rows.Count > 0 Then
                    typeChambre = Functions.getElementByCode(GlobalVariable.ChambreToUpdate.Rows(0)("CODE_TYPE_CHAMBRE"), "type_chambre", "CODE_TYPE_CHAMBRE")
                Else
                    chambrePourType = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")
                    If chambrePourType.Rows.Count > 0 Then
                        Dim CODE_TYPE_CHAMBRE As String = chambrePourType.Rows(0)("CODE_TYPE_CHAMBRE")
                        typeChambre = Functions.getElementByCode(CODE_TYPE_CHAMBRE, "type_chambre", "CODE_TYPE_CHAMBRE")
                    End If
                End If

                If Not typeChambre Is Nothing Then

                    If typeChambre.Rows.Count > 0 Then
                        GunaTextBoxCapacite.Text = typeChambre.Rows(0)("CAPACITE")
                        GunaTextBoxSuperficie.Text = typeChambre.Rows(0)("SUPERFICIE")
                    End If

                End If

                'Gestion des Forfaits de la salle

                Dim Forfait As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "forfait_salle", "CODE_RESERVATION")

                If Forfait.Rows.Count > 0 Then

                    GunaTextBox35.Text = Forfait.Rows(0)("NBRE__CAFE")
                    GunaTextBoxForfaitCafe.Text = Format(Forfait.Rows(0)("PU_CAFE"), "#,##0")
                    GunaTextBox30.Text = Forfait.Rows(0)("NBRE_DEJEUNER")
                    GunaTextBoxForfatiDejeuner.Text = Format(Forfait.Rows(0)("PU_DEJEUNER"), "#,##0")
                    GunaTextBox25.Text = Forfait.Rows(0)("NBRE_DINER")
                    GunaTextBoxForfaitDiner.Text = Format(Forfait.Rows(0)("PU_DINER"), "#,##0")
                    GunaTextBox13.Text = Forfait.Rows(0)("NBRE_TRAITEUR")
                    GunaTextBoxForfaitTraiteur.Text = Format(Forfait.Rows(0)("PU_TRAITEUR"), "#,##0")
                    GunaTextBoxDecoration.Text = Format(Forfait.Rows(0)("DECORATION"), "#,##0")

                    GunaTextBoxMateriel.Text = Format(Forfait.Rows(0)("LOCATION_MATERIEL"), "#,##0")
                    GunaTextBoxAutres.Text = Format(Forfait.Rows(0)("AUTRES"), "#,##0")

                    GunaComboBoxEvenement.SelectedValue = Forfait.Rows(0)("CODE_EVENEMENT")

                    '------------- addition -----------------------------------------------

                    GunaTextBoxQteGouter.Text = Forfait.Rows(0)("NBRE_GOUTER")
                    GunaTextBoxPrixGouter.Text = Format(Forfait.Rows(0)("PU_GOUTER"), "#,##0")

                    GunaTextBoxCocktail.Text = Format(Forfait.Rows(0)("NBRE_COCKTAIL"), "#,##0")
                    GunaTextBoxPUCocktail.Text = Format(Forfait.Rows(0)("PU_COCKTAIL"), "#,##0")

                    GunaComboBoxHeureCafe.Items.Add(Forfait.Rows(0)("HEURE_PAUSE_CAFE"))
                    GunaComboBoxHeureCafe.SelectedItem = Forfait.Rows(0)("HEURE_PAUSE_CAFE")
                    GunaComboBoxHeureDej.Items.Add(Forfait.Rows(0)("HEURE_PAUSE_DEJEUNER"))
                    GunaComboBoxHeureDej.SelectedItem = Forfait.Rows(0)("HEURE_PAUSE_DEJEUNER")
                    GunaComboBoxHeureDiner.Items.Add(Forfait.Rows(0)("HEURE_DINER"))
                    GunaComboBoxHeureDiner.SelectedItem = Forfait.Rows(0)("HEURE_DINER")
                    GunaComboBoxHeureGouter.Items.Add(Forfait.Rows(0)("HEURE_GOUTER"))
                    GunaComboBoxHeureGouter.SelectedItem = Forfait.Rows(0)("HEURE_GOUTER")
                    GunaComboBoxHeureCocktail.Items.Add(Forfait.Rows(0)("HEURE_COCKTAIL"))
                    GunaComboBoxHeureCocktail.SelectedItem = Forfait.Rows(0)("HEURE_COCKTAIL")

                    'QUANTITE

                    GunaTextBox47.Text = Forfait.Rows(0)("EAU_PTE_QTE")
                    GunaTextBox48.Text = Forfait.Rows(0)("BOISSONS_GAZEUSES_QTE")
                    GunaTextBox54.Text = Forfait.Rows(0)("VIN_ROUGE_QTE")
                    GunaTextBox63.Text = Forfait.Rows(0)("VIN_ROSE_QTE")
                    GunaTextBox10.Text = Forfait.Rows(0)("EAU_GRDE_QTE")
                    GunaTextBox50.Text = Forfait.Rows(0)("BIERES_QTE")
                    GunaTextBox36.Text = Forfait.Rows(0)("BOISSONS_EXT_QTE")

                    'MONTANT
                    GunaTextBoxMontantEauPetiteBouteille.Text = Format(Forfait.Rows(0)("EAU_PTE_MONTANT"), "#,##0")
                    GunaTextBox68.Text = Format(Forfait.Rows(0)("EAU_GRDE_MONTANT"), "#,##0")
                    GunaTextBox62.Text = Format(Forfait.Rows(0)("BOISSONS_GAZEUSES_MONTANT"), "#,##0")
                    GunaTextBox61.Text = Format(Forfait.Rows(0)("BIERES_MONTANT"), "#,##0")
                    GunaTextBox59.Text = Format(Forfait.Rows(0)("VIN_ROUGE_MONTANT"), "#,##0")
                    GunaTextBox57.Text = Format(Forfait.Rows(0)("VIN_ROSE_MONTANT"), "#,##0")
                    GunaTextBox64.Text = Format(Forfait.Rows(0)("BOISSONS_EXT_MONTANT"), "#,##0")
                    GunaTextBoxDroitDeBouchon.Text = Format(Forfait.Rows(0)("DROIT_DE_BOUCHON"), "#,##0")

                    If Forfait.Rows(0)("VIDEO_PROJ") = 1 Then
                        GunaCheckBoxVidOui.Checked = True
                        GunaCheckBoxVidNon.Checked = False
                    Else
                        GunaCheckBoxVidNon.Checked = True
                        GunaCheckBoxVidOui.Checked = False
                    End If

                    If Forfait.Rows(0)("SONO") = 1 Then
                        GunaCheckBoxSonoOui.Checked = True
                        GunaCheckBoxSonoNon.Checked = False
                    Else
                        GunaCheckBoxSonoNon.Checked = True
                        GunaCheckBoxSonoOui.Checked = False
                    End If

                    If Forfait.Rows(0)("COUVERTS") = 1 Then
                        GunaCheckBoxCouvOui.Checked = True
                        GunaCheckBoxCouvNon.Checked = False
                    Else
                        GunaCheckBoxCouvNon.Checked = True
                        GunaCheckBoxCouvOui.Checked = False
                    End If

                    If Forfait.Rows(0)("TABLE_CHAISE") = 1 Then
                        GunaCheckBoxTableOui.Checked = True
                        GunaCheckBoxTableNon.Checked = False
                    Else
                        GunaCheckBoxTableNon.Checked = True
                        GunaCheckBoxTableOui.Checked = False
                    End If

                    If Forfait.Rows(0)("MISE_EN_PLACE") = 1 Then
                        GunaCheckBoxEcole.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 2 Then
                        GunaCheckBoxTheatre.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 3 Then
                        GunaCheckBoxRectangle.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 4 Then
                        GunaCheckBoxCocktail.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 5 Then
                        GunaCheckBoxBanquet.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 0 Then
                        GunaCheckBoxU.Checked = True
                    End If

                    If Forfait.Rows(0)("CLOISONNEMENT") = 2 Then
                        GunaCheckBox2.Checked = True
                    ElseIf Forfait.Rows(0)("CLOISONNEMENT") = 3 Then
                        GunaCheckBox9.Checked = True
                    End If

                End If

            End If

            affectingValuesToFields()

            If Not GlobalVariable.codeReservationToUpdate = "" Then

                GunaLabelNumReservation.Visible = True
                GunaLabelNumReservation.Text = GlobalVariable.codeReservationToUpdate

            End If

            'We hide all the Datagrid used for custom filling

            GunaDataGridViewRoomType.Visible = False
            GunaDataGridViewClient.Visible = False
            GunaDataGridViewRoom.Visible = False
            GunaDataGridViewPhone.Visible = False

            TabControlHbergement.SelectedIndex = 0

            GunaDataGridViewRoomType.Visible = False

        End If

    End Sub

    'RESERVATION GRID
    Private Sub GunaDataGridViewReservationList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewReservationList.CellDoubleClick

        viderDocumentDatagrids()
        VidageDesChampsPourNouvelleReservation()

        If e.RowIndex >= 0 Then

            LabelNatureReservation.Visible = True

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewReservationList.Rows(e.RowIndex)

            GlobalVariable.codeReservationToUpdate = row.Cells("RESERVATION").Value.ToString

            'We first search in reservation 
            GlobalVariable.ReservationToUpdate = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION")

            If Not GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                'not found in reservation so, we search in reserve_conf
                GlobalVariable.ReservationToUpdate = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

                'GESTION DES ETATS DE RESERVATIONS CONFIRMEE
                If GlobalVariable.ReservationToUpdate.Rows(0)("ETAT_RESERVATION") = 1 Then
                    If GlobalVariable.typeChambreOuSalle = "chambre" Then
                        If GlobalVariable.actualLanguageValue = 1 Then
                            LabelNatureReservation.Text = "EN CHAMBRE"

                        Else
                            LabelNatureReservation.Text = "IN HOUSE"

                        End If
                    ElseIf GlobalVariable.typeChambreOuSalle = "salle" Then

                        If GlobalVariable.actualLanguageValue = 1 Then
                            LabelNatureReservation.Text = "EN SALLE"
                        Else
                            LabelNatureReservation.Text = "IN HALL"
                        End If
                    End If
                Else
                    LabelNatureReservation.Text = "CHECKOUT"

                End If

            Else

                'GESTION DES ETATS DE RESERVATIONS
                If GlobalVariable.ReservationToUpdate.Rows(0)("ETAT_RESERVATION") = 0 Then
                    If GlobalVariable.actualLanguageValue = 1 Then
                        LabelNatureReservation.Text = "ATTENDUES"

                    Else
                        LabelNatureReservation.Text = "EXPECTED"

                    End If
                Else

                    If GlobalVariable.actualLanguageValue = 1 Then
                        LabelNatureReservation.Text = "ANNULEE"

                    Else
                        LabelNatureReservation.Text = "CANCELED"

                    End If
                End If

            End If

            'Variable to print or not checkout button
            GlobalVariable.reserveConfCheckInState = GlobalVariable.ReservationToUpdate(0)("CHECKIN")

            GlobalVariable.codeClientToUpdate = GlobalVariable.ReservationToUpdate(0)("CLIENT_ID")

            'MessageBox.Show(GlobalVariable.codeClientToUpdate & " - " & GlobalVariable.codeReservationToUpdate & "-" & GlobalVariable.ReservationToUpdate(0)("CLIENT_ID"))
            GlobalVariable.ClientToUpdate = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "client", "CODE_CLIENT")

            'On selectionne code_main_courante
            Dim tableMainCourante As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante", "CODE_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCourante.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteToUpdate = tableMainCourante.Rows(0)("CODE_MAIN_COURANTE")
                GlobalVariable.MainCouranteToUpdate = tableMainCourante
            End If

            'On selectionne code_main_courante_generale
            Dim tableMainCouranteGenerale As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_generale", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCouranteGenerale.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteGeneraleToUpdate = tableMainCouranteGenerale.Rows(0)("CODE_MAIN_COURANTE_GENERALE")
                GlobalVariable.MainCouranteGeneraleToUpdate = tableMainCouranteGenerale
            End If

            'On selectionne code_main_courante_journaliere
            'Dim tableMainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            Dim tableMainCouranteJournaliere As DataTable

            'ON DOIT PRENDRE LA MAINCOURANTE SELON L'ETAT DE LA RESERVATION EN CE QUI CONCERNE LA LISTE DE TOUTES LES RESERVATIONS

            'MessageBox.Show(LabelNatureReservation.Text & " " & GlobalVariable.codeReservationToUpdate & " YES")

            If Trim(LabelNatureReservation.Text) = "CHECKOUT" Then
                tableMainCouranteJournaliere = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 1, "ETAT_MAIN_COURANTE")
            ElseIf Trim(LabelNatureReservation.Text) = "EN CHAMBRE" Or LabelNatureReservation.Text = "EN SALLE" Or Trim(LabelNatureReservation.Text) = "IN HOUSE" Or LabelNatureReservation.Text = "IN HALL" Then
                tableMainCouranteJournaliere = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")
            ElseIf Trim(LabelNatureReservation.Text) = "ANNULEE" Or Trim(LabelNatureReservation.Text) = "CANCELED" Then
                tableMainCouranteJournaliere = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 2, "ETAT_MAIN_COURANTE")
            ElseIf Trim(LabelNatureReservation.Text) = "ATTENDUES" Or Trim(LabelNatureReservation.Text) = "EXPECTED" Then
                tableMainCouranteJournaliere = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")
            Else
                'GESTION DES DAY USE
                tableMainCouranteJournaliere = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 1, "ETAT_MAIN_COURANTE")
            End If

            If tableMainCouranteJournaliere.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteJournaliereToUpdate = tableMainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                GlobalVariable.MainCouranteJournaliereToUpdate = tableMainCouranteJournaliere
                mainCouranteJournaliere = tableMainCouranteJournaliere
            End If

            'On selectionne NUM_REGLEMENT
            Dim tableReglement As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reglement", "CODE_RESERVATION")

            If tableReglement.Rows.Count > 0 Then
                GlobalVariable.codeReglementToUpdate = tableReglement.Rows(0)("NUM_REGLEMENT")
                GlobalVariable.ReglementToUpdate = tableReglement
            End If

            'On selectionne CODE_OCCUPATION_CHAMBRE
            Dim tableOccupationChambre As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "occupation_chambre", "CODE_RESERVATION")
            If tableOccupationChambre.Rows.Count > 0 Then
                GlobalVariable.codeOccupationchambreToUpdate = tableOccupationChambre.Rows(0)("CODE_OCCUPATION_CHAMBRE")
                GlobalVariable.OccupationchambreToUpdate = tableOccupationChambre
            End If

            'On selectionne NUM_FACTURE
            Dim tableFacture As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "facture", "CODE_RESERVATION")

            If tableFacture.Rows.Count > 0 Then

                GlobalVariable.codeFactureToUpdate = tableFacture.Rows(0)("CODE_FACTURE")
                GlobalVariable.FactureToUpdate = tableFacture

            End If

            'On selectionne le compte du client using CODE_COMPTE
            Dim tableCompte As DataTable = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "compte", "CODE_CLIENT")

            If tableCompte.Rows.Count > 0 Then

                GlobalVariable.codeCompteToUpdate = tableCompte.Rows(0)("NUMERO_COMPTE")
                GlobalVariable.sensDuSoldeDuCompte = tableCompte.Rows(0)("SENS_DU_SOLDE")
                GlobalVariable.CompteToUpdate = tableCompte

            End If

            GlobalVariable.codeChambreToUpdate = GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID")
            GlobalVariable.ChambreToUpdate = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")

            'As the two values below can not more be updated when we come from maincouranteReception because of the event leave
            GlobalVariable.codeChambre = GlobalVariable.codeChambreToUpdate

            If GunaRadioButtonSalleFete.Checked Then

                Dim chambrePourType As DataTable
                Dim typeChambre As DataTable

                If GlobalVariable.ChambreToUpdate.Rows.Count > 0 Then
                    typeChambre = Functions.getElementByCode(GlobalVariable.ChambreToUpdate.Rows(0)("CODE_TYPE_CHAMBRE"), "type_chambre", "CODE_TYPE_CHAMBRE")
                Else
                    chambrePourType = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")
                    If chambrePourType.Rows.Count > 0 Then
                        Dim CODE_TYPE_CHAMBRE As String = chambrePourType.Rows(0)("CODE_TYPE_CHAMBRE")
                        typeChambre = Functions.getElementByCode(CODE_TYPE_CHAMBRE, "type_chambre", "CODE_TYPE_CHAMBRE")
                    End If
                End If

                If Not typeChambre Is Nothing Then

                    If typeChambre.Rows.Count > 0 Then
                        GunaTextBoxCapacite.Text = typeChambre.Rows(0)("CAPACITE")
                        GunaTextBoxSuperficie.Text = typeChambre.Rows(0)("SUPERFICIE")
                    End If

                End If

                'Gestion des Forfaits de la salle

                Dim Forfait As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "forfait_salle", "CODE_RESERVATION")

                If Forfait.Rows.Count > 0 Then

                    GunaTextBox35.Text = Forfait.Rows(0)("NBRE__CAFE")
                    GunaTextBoxForfaitCafe.Text = Forfait.Rows(0)("PU_CAFE")
                    GunaTextBox30.Text = Forfait.Rows(0)("NBRE_DEJEUNER")
                    GunaTextBoxForfatiDejeuner.Text = Forfait.Rows(0)("PU_DEJEUNER")
                    GunaTextBox25.Text = Forfait.Rows(0)("NBRE_DINER")
                    GunaTextBoxForfaitDiner.Text = Forfait.Rows(0)("PU_DINER")
                    GunaTextBox13.Text = Forfait.Rows(0)("NBRE_TRAITEUR")
                    GunaTextBoxForfaitTraiteur.Text = Forfait.Rows(0)("PU_TRAITEUR")
                    GunaTextBoxDecoration.Text = Forfait.Rows(0)("DECORATION")

                    GunaTextBoxMateriel.Text = Format(Forfait.Rows(0)("LOCATION_MATERIEL"), "#,##0")
                    GunaTextBoxAutres.Text = Format(Forfait.Rows(0)("AUTRES"), "#,##0")

                    GunaComboBoxEvenement.SelectedValue = Forfait.Rows(0)("CODE_EVENEMENT")


                    '------------- addition -----------------------------------------------

                    GunaTextBoxQteGouter.Text = Forfait.Rows(0)("NBRE_GOUTER")
                    GunaTextBoxPrixGouter.Text = Format(Forfait.Rows(0)("PU_GOUTER"), "#,##0")

                    GunaTextBoxCocktail.Text = Format(Forfait.Rows(0)("NBRE_COCKTAIL"), "#,##0")
                    GunaTextBoxPUCocktail.Text = Format(Forfait.Rows(0)("PU_COCKTAIL"), "#,##0")

                    GunaComboBoxHeureCafe.Items.Add(Forfait.Rows(0)("HEURE_PAUSE_CAFE"))
                    GunaComboBoxHeureCafe.SelectedItem = Forfait.Rows(0)("HEURE_PAUSE_CAFE")
                    GunaComboBoxHeureDej.Items.Add(Forfait.Rows(0)("HEURE_PAUSE_DEJEUNER"))
                    GunaComboBoxHeureDej.SelectedItem = Forfait.Rows(0)("HEURE_PAUSE_DEJEUNER")
                    GunaComboBoxHeureDiner.Items.Add(Forfait.Rows(0)("HEURE_DINER"))
                    GunaComboBoxHeureDiner.SelectedItem = Forfait.Rows(0)("HEURE_DINER")
                    GunaComboBoxHeureGouter.Items.Add(Forfait.Rows(0)("HEURE_GOUTER"))
                    GunaComboBoxHeureGouter.SelectedItem = Forfait.Rows(0)("HEURE_GOUTER")
                    GunaComboBoxHeureCocktail.Items.Add(Forfait.Rows(0)("HEURE_COCKTAIL"))
                    GunaComboBoxHeureCocktail.SelectedItem = Forfait.Rows(0)("HEURE_COCKTAIL")

                    'QUANTITE

                    GunaTextBox47.Text = Forfait.Rows(0)("EAU_PTE_QTE")
                    GunaTextBox48.Text = Forfait.Rows(0)("BOISSONS_GAZEUSES_QTE")
                    GunaTextBox54.Text = Forfait.Rows(0)("VIN_ROUGE_QTE")
                    GunaTextBox63.Text = Forfait.Rows(0)("VIN_ROSE_QTE")
                    GunaTextBox10.Text = Forfait.Rows(0)("EAU_GRDE_QTE")
                    GunaTextBox50.Text = Forfait.Rows(0)("BIERES_QTE")
                    GunaTextBox36.Text = Forfait.Rows(0)("BOISSONS_EXT_QTE")

                    'MONTANT
                    GunaTextBoxMontantEauPetiteBouteille.Text = Format(Forfait.Rows(0)("EAU_PTE_MONTANT"), "#,##0")
                    GunaTextBox68.Text = Format(Forfait.Rows(0)("EAU_GRDE_MONTANT"), "#,##0")
                    GunaTextBox62.Text = Format(Forfait.Rows(0)("BOISSONS_GAZEUSES_MONTANT"), "#,##0")
                    GunaTextBox61.Text = Format(Forfait.Rows(0)("BIERES_MONTANT"), "#,##0")
                    GunaTextBox59.Text = Format(Forfait.Rows(0)("VIN_ROUGE_MONTANT"), "#,##0")
                    GunaTextBox57.Text = Format(Forfait.Rows(0)("VIN_ROSE_MONTANT"), "#,##0")
                    GunaTextBox64.Text = Format(Forfait.Rows(0)("BOISSONS_EXT_MONTANT"), "#,##0")
                    GunaTextBoxDroitDeBouchon.Text = Format(Forfait.Rows(0)("DROIT_DE_BOUCHON"), "#,##0")

                    If Forfait.Rows(0)("VIDEO_PROJ") = 1 Then
                        GunaCheckBoxVidOui.Checked = True
                        GunaCheckBoxVidNon.Checked = False
                    Else
                        GunaCheckBoxVidNon.Checked = True
                        GunaCheckBoxVidOui.Checked = False
                    End If

                    If Forfait.Rows(0)("SONO") = 1 Then
                        GunaCheckBoxSonoOui.Checked = True
                        GunaCheckBoxSonoNon.Checked = False
                    Else
                        GunaCheckBoxSonoNon.Checked = True
                        GunaCheckBoxSonoOui.Checked = False
                    End If

                    If Forfait.Rows(0)("COUVERTS") = 1 Then
                        GunaCheckBoxCouvOui.Checked = True
                        GunaCheckBoxCouvNon.Checked = False
                    Else
                        GunaCheckBoxCouvNon.Checked = True
                        GunaCheckBoxCouvOui.Checked = False
                    End If

                    If Forfait.Rows(0)("TABLE_CHAISE") = 1 Then
                        GunaCheckBoxTableOui.Checked = True
                        GunaCheckBoxTableNon.Checked = False
                    Else
                        GunaCheckBoxTableNon.Checked = True
                        GunaCheckBoxTableOui.Checked = False
                    End If

                    If Forfait.Rows(0)("MISE_EN_PLACE") = 1 Then
                        GunaCheckBoxEcole.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 2 Then
                        GunaCheckBoxTheatre.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 3 Then
                        GunaCheckBoxRectangle.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 4 Then
                        GunaCheckBoxCocktail.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 5 Then
                        GunaCheckBoxBanquet.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 0 Then
                        GunaCheckBoxU.Checked = True
                    End If

                    If Forfait.Rows(0)("CLOISONNEMENT") = 2 Then
                        GunaCheckBox2.Checked = True
                    ElseIf Forfait.Rows(0)("CLOISONNEMENT") = 3 Then
                        GunaCheckBox9.Checked = True
                    End If

                End If

            End If

            GunaDataGridViewRoomType.Visible = False

            'We hide all the Datagrid used for custom filling

            GunaDataGridViewRoomType.Visible = False
            GunaDataGridViewClient.Visible = False
            GunaDataGridViewRoom.Visible = False
            GunaDataGridViewPhone.Visible = False

            'TabControlHbergement.SelectedIndex = 0

            If Not GlobalVariable.codeReservationToUpdate = "" Then

                GunaLabelNumReservation.Visible = True
                GunaLabelNumReservation.Text = GlobalVariable.codeReservationToUpdate

            End If

            affectingValuesToFields()
            TabControlHbergement.SelectedIndex = 0

            GunaDataGridViewRoomType.Visible = False

        End If

    End Sub

    'ATTENDUS GRID
    Private Sub DataGridViewAttenduPanel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewAttenduPanel.CellDoubleClick

        viderDocumentDatagrids()
        VidageDesChampsPourNouvelleReservation()

        If e.RowIndex >= 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelNatureReservation.Text = "ATTENDUE"
            Else
                LabelNatureReservation.Text = "EXPECTED"
            End If

            Dim row As DataGridViewRow

            row = Me.DataGridViewAttenduPanel.Rows(e.RowIndex)

            GlobalVariable.codeReservationToUpdate = row.Cells("RESERVATION").Value.ToString

            'We first search in reservation 
            GlobalVariable.ReservationToUpdate = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION")

            If Not GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                'not found in reservation so, we search in reserve_conf
                GlobalVariable.ReservationToUpdate = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

            End If

            'Variable to print or not checkout button
            GlobalVariable.reserveConfCheckInState = GlobalVariable.ReservationToUpdate(0)("CHECKIN")

            GlobalVariable.codeClientToUpdate = GlobalVariable.ReservationToUpdate(0)("CLIENT_ID")
            GlobalVariable.ClientToUpdate = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "client", "CODE_CLIENT")

            'On selectionne code_main_courante
            Dim tableMainCourante As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante", "CODE_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCourante.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteToUpdate = tableMainCourante.Rows(0)("CODE_MAIN_COURANTE")
                GlobalVariable.MainCouranteToUpdate = tableMainCourante
            End If

            'On selectionne code_main_courante_generale
            Dim tableMainCouranteGenerale As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_generale", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCouranteGenerale.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteGeneraleToUpdate = tableMainCouranteGenerale.Rows(0)("CODE_MAIN_COURANTE_GENERALE")
                GlobalVariable.MainCouranteGeneraleToUpdate = tableMainCouranteGenerale
            End If

            'On selectionne code_main_courante_journaliere
            Dim tableMainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCouranteJournaliere.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteJournaliereToUpdate = tableMainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                GlobalVariable.MainCouranteJournaliereToUpdate = tableMainCouranteJournaliere
                mainCouranteJournaliere = tableMainCouranteJournaliere

            Else

                GlobalVariable.codeMainCouranteJournaliereToUpdate = ""
                GlobalVariable.MainCouranteJournaliereToUpdate = Nothing
                mainCouranteJournaliere = Nothing

            End If

            'On selectionne NUM_REGLEMENT
            Dim tableReglement As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reglement", "CODE_RESERVATION")

            If tableReglement.Rows.Count > 0 Then
                GlobalVariable.codeReglementToUpdate = tableReglement.Rows(0)("NUM_REGLEMENT")
                GlobalVariable.ReglementToUpdate = tableReglement
            End If

            'On selectionne CODE_OCCUPATION_CHAMBRE
            Dim tableOccupationChambre As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "occupation_chambre", "CODE_RESERVATION")
            If tableOccupationChambre.Rows.Count > 0 Then
                GlobalVariable.codeOccupationchambreToUpdate = tableOccupationChambre.Rows(0)("CODE_OCCUPATION_CHAMBRE")
                GlobalVariable.OccupationchambreToUpdate = tableOccupationChambre
            End If

            'On selectionne NUM_FACTURE
            Dim tableFacture As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "facture", "CODE_RESERVATION")

            If tableFacture.Rows.Count > 0 Then

                GlobalVariable.codeFactureToUpdate = tableFacture.Rows(0)("CODE_FACTURE")
                GlobalVariable.FactureToUpdate = tableFacture

            End If

            'On selectionne le compte du client using CODE_COMPTE
            Dim tableCompte As DataTable = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "compte", "CODE_CLIENT")

            If tableCompte.Rows.Count > 0 Then

                GlobalVariable.codeCompteToUpdate = tableCompte.Rows(0)("NUMERO_COMPTE")
                GlobalVariable.sensDuSoldeDuCompte = tableCompte.Rows(0)("SENS_DU_SOLDE")
                GlobalVariable.CompteToUpdate = tableCompte

            End If

            GlobalVariable.codeChambreToUpdate = GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID")
            GlobalVariable.ChambreToUpdate = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")

            'As the two values below can not more be updated when we come from maincouranteReception because of the event leave
            GlobalVariable.codeChambre = GlobalVariable.codeChambreToUpdate


            If GunaRadioButtonSalleFete.Checked Then

                Dim chambrePourType As DataTable
                Dim typeChambre As DataTable

                If GlobalVariable.ChambreToUpdate.Rows.Count > 0 Then
                    typeChambre = Functions.getElementByCode(GlobalVariable.ChambreToUpdate.Rows(0)("CODE_TYPE_CHAMBRE"), "type_chambre", "CODE_TYPE_CHAMBRE")
                Else
                    chambrePourType = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")
                    If chambrePourType.Rows.Count > 0 Then
                        Dim CODE_TYPE_CHAMBRE As String = chambrePourType.Rows(0)("CODE_TYPE_CHAMBRE")
                        typeChambre = Functions.getElementByCode(CODE_TYPE_CHAMBRE, "type_chambre", "CODE_TYPE_CHAMBRE")
                    End If
                End If

                If Not typeChambre Is Nothing Then

                    If typeChambre.Rows.Count > 0 Then
                        GunaTextBoxCapacite.Text = typeChambre.Rows(0)("CAPACITE")
                        GunaTextBoxSuperficie.Text = typeChambre.Rows(0)("SUPERFICIE")
                    End If

                End If

                'Gestion des Forfaits de la salle

                Dim Forfait As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "forfait_salle", "CODE_RESERVATION")

                If Forfait.Rows.Count > 0 Then

                    GunaTextBox35.Text = Forfait.Rows(0)("NBRE__CAFE")
                    GunaTextBoxForfaitCafe.Text = Forfait.Rows(0)("PU_CAFE")
                    GunaTextBox30.Text = Forfait.Rows(0)("NBRE_DEJEUNER")
                    GunaTextBoxForfatiDejeuner.Text = Forfait.Rows(0)("PU_DEJEUNER")
                    GunaTextBox25.Text = Forfait.Rows(0)("NBRE_DINER")
                    GunaTextBoxForfaitDiner.Text = Forfait.Rows(0)("PU_DINER")
                    GunaTextBox13.Text = Forfait.Rows(0)("NBRE_TRAITEUR")
                    GunaTextBoxForfaitTraiteur.Text = Forfait.Rows(0)("PU_TRAITEUR")
                    GunaTextBoxDecoration.Text = Forfait.Rows(0)("DECORATION")

                    GunaTextBoxMateriel.Text = Format(Forfait.Rows(0)("LOCATION_MATERIEL"), "#,##0")
                    GunaTextBoxAutres.Text = Format(Forfait.Rows(0)("AUTRES"), "#,##0")

                    GunaComboBoxEvenement.SelectedValue = Forfait.Rows(0)("CODE_EVENEMENT")


                    '------------- addition -----------------------------------------------

                    GunaTextBoxQteGouter.Text = Forfait.Rows(0)("NBRE_GOUTER")
                    GunaTextBoxPrixGouter.Text = Format(Forfait.Rows(0)("PU_GOUTER"), "#,##0")

                    GunaTextBoxCocktail.Text = Format(Forfait.Rows(0)("NBRE_COCKTAIL"), "#,##0")
                    GunaTextBoxPUCocktail.Text = Format(Forfait.Rows(0)("PU_COCKTAIL"), "#,##0")

                    GunaComboBoxHeureCafe.Items.Add(Forfait.Rows(0)("HEURE_PAUSE_CAFE"))
                    GunaComboBoxHeureCafe.SelectedItem = Forfait.Rows(0)("HEURE_PAUSE_CAFE")
                    GunaComboBoxHeureDej.Items.Add(Forfait.Rows(0)("HEURE_PAUSE_DEJEUNER"))
                    GunaComboBoxHeureDej.SelectedItem = Forfait.Rows(0)("HEURE_PAUSE_DEJEUNER")
                    GunaComboBoxHeureDiner.Items.Add(Forfait.Rows(0)("HEURE_DINER"))
                    GunaComboBoxHeureDiner.SelectedItem = Forfait.Rows(0)("HEURE_DINER")
                    GunaComboBoxHeureGouter.Items.Add(Forfait.Rows(0)("HEURE_GOUTER"))
                    GunaComboBoxHeureGouter.SelectedItem = Forfait.Rows(0)("HEURE_GOUTER")
                    GunaComboBoxHeureCocktail.Items.Add(Forfait.Rows(0)("HEURE_COCKTAIL"))
                    GunaComboBoxHeureCocktail.SelectedItem = Forfait.Rows(0)("HEURE_COCKTAIL")

                    'QUANTITE

                    GunaTextBox47.Text = Forfait.Rows(0)("EAU_PTE_QTE")
                    GunaTextBox48.Text = Forfait.Rows(0)("BOISSONS_GAZEUSES_QTE")
                    GunaTextBox54.Text = Forfait.Rows(0)("VIN_ROUGE_QTE")
                    GunaTextBox63.Text = Forfait.Rows(0)("VIN_ROSE_QTE")
                    GunaTextBox10.Text = Forfait.Rows(0)("EAU_GRDE_QTE")
                    GunaTextBox50.Text = Forfait.Rows(0)("BIERES_QTE")
                    GunaTextBox36.Text = Forfait.Rows(0)("BOISSONS_EXT_QTE")

                    'MONTANT
                    GunaTextBoxMontantEauPetiteBouteille.Text = Format(Forfait.Rows(0)("EAU_PTE_MONTANT"), "#,##0")
                    GunaTextBox68.Text = Format(Forfait.Rows(0)("EAU_GRDE_MONTANT"), "#,##0")
                    GunaTextBox62.Text = Format(Forfait.Rows(0)("BOISSONS_GAZEUSES_MONTANT"), "#,##0")
                    GunaTextBox61.Text = Format(Forfait.Rows(0)("BIERES_MONTANT"), "#,##0")
                    GunaTextBox59.Text = Format(Forfait.Rows(0)("VIN_ROUGE_MONTANT"), "#,##0")
                    GunaTextBox57.Text = Format(Forfait.Rows(0)("VIN_ROSE_MONTANT"), "#,##0")
                    GunaTextBox64.Text = Format(Forfait.Rows(0)("BOISSONS_EXT_MONTANT"), "#,##0")
                    GunaTextBoxDroitDeBouchon.Text = Format(Forfait.Rows(0)("DROIT_DE_BOUCHON"), "#,##0")

                    If Forfait.Rows(0)("VIDEO_PROJ") = 1 Then
                        GunaCheckBoxVidOui.Checked = True
                        GunaCheckBoxVidNon.Checked = False
                    Else
                        GunaCheckBoxVidNon.Checked = True
                        GunaCheckBoxVidOui.Checked = False
                    End If

                    If Forfait.Rows(0)("SONO") = 1 Then
                        GunaCheckBoxSonoOui.Checked = True
                        GunaCheckBoxSonoNon.Checked = False
                    Else
                        GunaCheckBoxSonoNon.Checked = True
                        GunaCheckBoxSonoOui.Checked = False
                    End If

                    If Forfait.Rows(0)("COUVERTS") = 1 Then
                        GunaCheckBoxCouvOui.Checked = True
                        GunaCheckBoxCouvOui.Checked = False
                    Else
                        GunaCheckBoxCouvNon.Checked = True
                        GunaCheckBoxCouvOui.Checked = False
                    End If

                    If Forfait.Rows(0)("TABLE_CHAISE") = 1 Then
                        GunaCheckBoxTableOui.Checked = True
                        GunaCheckBoxTableNon.Checked = False
                    Else
                        GunaCheckBoxTableNon.Checked = True
                        GunaCheckBoxTableOui.Checked = False
                    End If

                    If Forfait.Rows(0)("MISE_EN_PLACE") = 1 Then
                        GunaCheckBoxEcole.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 2 Then
                        GunaCheckBoxTheatre.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 3 Then
                        GunaCheckBoxRectangle.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 4 Then
                        GunaCheckBoxCocktail.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 5 Then
                        GunaCheckBoxBanquet.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 0 Then
                        GunaCheckBoxU.Checked = True
                    End If

                    If Forfait.Rows(0)("CLOISONNEMENT") = 2 Then
                        GunaCheckBox2.Checked = True
                    ElseIf Forfait.Rows(0)("CLOISONNEMENT") = 3 Then
                        GunaCheckBox9.Checked = True
                    End If

                End If

            End If

            'Affecting values mostly for calculations
            affectingValuesToFields()

            GunaDataGridViewRoomType.Visible = False

            'We hide all the Datagrid used for custom filling

            GunaDataGridViewRoomType.Visible = False
            GunaDataGridViewClient.Visible = False
            GunaDataGridViewRoom.Visible = False
            GunaDataGridViewPhone.Visible = False

            TabControlHbergement.SelectedIndex = 0

            If Not GlobalVariable.codeReservationToUpdate = "" Then

                GunaLabelNumReservation.Visible = True
                GunaLabelNumReservation.Text = GlobalVariable.codeReservationToUpdate

            End If

            TabControlHbergement.SelectedIndex = 0
            GunaDataGridViewRoomType.Visible = False

        End If

    End Sub

    'DEPART GRID
    Private Sub DataGridViewDepartTab_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDepartTab.CellDoubleClick

        viderDocumentDatagrids()
        VidageDesChampsPourNouvelleReservation()

        If e.RowIndex >= 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelNatureReservation.Text = "EN CHAMBRE"
            Else
                LabelNatureReservation.Text = "IN HOUSE"
            End If

            Dim row As DataGridViewRow

            row = Me.DataGridViewDepartTab.Rows(e.RowIndex)

            GlobalVariable.codeReservationToUpdate = Trim(row.Cells("RESERVATION").Value.ToString)

            'We first search in reservation 
            GlobalVariable.ReservationToUpdate = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION")

            If Not GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                'not found in reservation so, we search in reserve
                GlobalVariable.ReservationToUpdate = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

                'Variable to print or not checkout button
                GlobalVariable.reserveConfCheckInState = GlobalVariable.ReservationToUpdate(0)("CHECKIN")
            End If

            GlobalVariable.codeClientToUpdate = GlobalVariable.ReservationToUpdate(0)("CLIENT_ID")
            GlobalVariable.ClientToUpdate = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "client", "CODE_CLIENT")

            'On selectionne code_main_courante
            Dim tableMainCourante As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante", "CODE_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCourante.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteToUpdate = tableMainCourante.Rows(0)("CODE_MAIN_COURANTE")
                GlobalVariable.MainCouranteToUpdate = tableMainCourante
            End If

            'On selectionne code_main_courante_generale
            Dim tableMainCouranteGenerale As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_generale", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCouranteGenerale.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteGeneraleToUpdate = tableMainCouranteGenerale.Rows(0)("CODE_MAIN_COURANTE_GENERALE")
                GlobalVariable.MainCouranteGeneraleToUpdate = tableMainCouranteGenerale
            End If

            'On selectionne code_main_courante_journaliere
            Dim tableMainCouranteJournaliere As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "main_courante_journaliere", "NUM_RESERVATION", 0, "ETAT_MAIN_COURANTE")

            If tableMainCouranteJournaliere.Rows.Count > 0 Then
                GlobalVariable.codeMainCouranteJournaliereToUpdate = tableMainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                GlobalVariable.MainCouranteJournaliereToUpdate = tableMainCouranteJournaliere
                mainCouranteJournaliere = tableMainCouranteJournaliere
            End If

            'On selectionne NUM_REGLEMENT
            Dim tableReglement As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reglement", "CODE_RESERVATION")

            If tableReglement.Rows.Count > 0 Then
                GlobalVariable.codeReglementToUpdate = tableReglement.Rows(0)("NUM_REGLEMENT")
                GlobalVariable.ReglementToUpdate = tableReglement
            End If

            'On selectionne CODE_OCCUPATION_CHAMBRE
            Dim tableOccupationChambre As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "occupation_chambre", "CODE_RESERVATION")
            If tableOccupationChambre.Rows.Count > 0 Then
                GlobalVariable.codeOccupationchambreToUpdate = tableOccupationChambre.Rows(0)("CODE_OCCUPATION_CHAMBRE")
                GlobalVariable.OccupationchambreToUpdate = tableOccupationChambre
            End If

            'On selectionne NUM_FACTURE
            Dim tableFacture As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "facture", "CODE_RESERVATION")

            If tableFacture.Rows.Count > 0 Then

                GlobalVariable.codeFactureToUpdate = tableFacture.Rows(0)("CODE_FACTURE")
                GlobalVariable.FactureToUpdate = tableFacture

            End If

            'On selectionne le compte du client using CODE_COMPTE
            Dim tableCompte As DataTable = Functions.getElementByCode(GlobalVariable.codeClientToUpdate, "compte", "CODE_CLIENT")

            If tableCompte.Rows.Count > 0 Then

                GlobalVariable.codeCompteToUpdate = tableCompte.Rows(0)("NUMERO_COMPTE")
                GlobalVariable.sensDuSoldeDuCompte = tableCompte.Rows(0)("SENS_DU_SOLDE")
                GlobalVariable.CompteToUpdate = tableCompte

            End If

            GlobalVariable.codeChambreToUpdate = GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID")
            GlobalVariable.ChambreToUpdate = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")

            'As the two values below can not more be updated when we come from maincouranteReception because of the event leave
            GlobalVariable.codeChambre = GlobalVariable.codeChambreToUpdate

            If GunaRadioButtonSalleFete.Checked Then

                Dim chambrePourType As DataTable
                Dim typeChambre As DataTable

                If GlobalVariable.ChambreToUpdate.Rows.Count > 0 Then
                    typeChambre = Functions.getElementByCode(GlobalVariable.ChambreToUpdate.Rows(0)("CODE_TYPE_CHAMBRE"), "type_chambre", "CODE_TYPE_CHAMBRE")
                Else
                    chambrePourType = Functions.getElementByCode(GlobalVariable.codeChambreToUpdate, "chambre", "CODE_CHAMBRE")
                    If chambrePourType.Rows.Count > 0 Then
                        Dim CODE_TYPE_CHAMBRE As String = chambrePourType.Rows(0)("CODE_TYPE_CHAMBRE")
                        typeChambre = Functions.getElementByCode(CODE_TYPE_CHAMBRE, "type_chambre", "CODE_TYPE_CHAMBRE")
                    End If
                End If

                If Not typeChambre Is Nothing Then

                    If typeChambre.Rows.Count > 0 Then
                        GunaTextBoxCapacite.Text = typeChambre.Rows(0)("CAPACITE")
                        GunaTextBoxSuperficie.Text = typeChambre.Rows(0)("SUPERFICIE")
                    End If

                End If

                'Gestion des Forfaits de la salle

                Dim Forfait As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "forfait_salle", "CODE_RESERVATION")

                If Forfait.Rows.Count > 0 Then

                    GunaTextBox35.Text = Forfait.Rows(0)("NBRE__CAFE")
                    GunaTextBoxForfaitCafe.Text = Forfait.Rows(0)("PU_CAFE")
                    GunaTextBox30.Text = Forfait.Rows(0)("NBRE_DEJEUNER")
                    GunaTextBoxForfatiDejeuner.Text = Forfait.Rows(0)("PU_DEJEUNER")
                    GunaTextBox25.Text = Forfait.Rows(0)("NBRE_DINER")
                    GunaTextBoxForfaitDiner.Text = Forfait.Rows(0)("PU_DINER")
                    GunaTextBox13.Text = Forfait.Rows(0)("NBRE_TRAITEUR")
                    GunaTextBoxForfaitTraiteur.Text = Forfait.Rows(0)("PU_TRAITEUR")
                    GunaTextBoxDecoration.Text = Forfait.Rows(0)("DECORATION")

                    GunaTextBoxMateriel.Text = Format(Forfait.Rows(0)("LOCATION_MATERIEL"), "#,##0")
                    GunaTextBoxAutres.Text = Format(Forfait.Rows(0)("AUTRES"), "#,##0")

                    GunaComboBoxEvenement.SelectedValue = Forfait.Rows(0)("CODE_EVENEMENT")

                    '------------- addition -----------------------------------------------

                    GunaTextBoxQteGouter.Text = Forfait.Rows(0)("NBRE_GOUTER")
                    GunaTextBoxPrixGouter.Text = Format(Forfait.Rows(0)("PU_GOUTER"), "#,##0")

                    GunaTextBoxCocktail.Text = Format(Forfait.Rows(0)("NBRE_COCKTAIL"), "#,##0")
                    GunaTextBoxPUCocktail.Text = Format(Forfait.Rows(0)("PU_COCKTAIL"), "#,##0")

                    GunaComboBoxHeureCafe.Items.Add(Forfait.Rows(0)("HEURE_PAUSE_CAFE"))
                    GunaComboBoxHeureCafe.SelectedItem = Forfait.Rows(0)("HEURE_PAUSE_CAFE")
                    GunaComboBoxHeureDej.Items.Add(Forfait.Rows(0)("HEURE_PAUSE_DEJEUNER"))
                    GunaComboBoxHeureDej.SelectedItem = Forfait.Rows(0)("HEURE_PAUSE_DEJEUNER")
                    GunaComboBoxHeureDiner.Items.Add(Forfait.Rows(0)("HEURE_DINER"))
                    GunaComboBoxHeureDiner.SelectedItem = Forfait.Rows(0)("HEURE_DINER")
                    GunaComboBoxHeureGouter.Items.Add(Forfait.Rows(0)("HEURE_GOUTER"))
                    GunaComboBoxHeureGouter.SelectedItem = Forfait.Rows(0)("HEURE_GOUTER")
                    GunaComboBoxHeureCocktail.Items.Add(Forfait.Rows(0)("HEURE_COCKTAIL"))
                    GunaComboBoxHeureCocktail.SelectedItem = Forfait.Rows(0)("HEURE_COCKTAIL")

                    'QUANTITE

                    GunaTextBox47.Text = Forfait.Rows(0)("EAU_PTE_QTE")
                    GunaTextBox48.Text = Forfait.Rows(0)("BOISSONS_GAZEUSES_QTE")
                    GunaTextBox54.Text = Forfait.Rows(0)("VIN_ROUGE_QTE")
                    GunaTextBox63.Text = Forfait.Rows(0)("VIN_ROSE_QTE")
                    GunaTextBox10.Text = Forfait.Rows(0)("EAU_GRDE_QTE")
                    GunaTextBox50.Text = Forfait.Rows(0)("BIERES_QTE")
                    GunaTextBox36.Text = Forfait.Rows(0)("BOISSONS_EXT_QTE")

                    'MONTANT
                    GunaTextBoxMontantEauPetiteBouteille.Text = Format(Forfait.Rows(0)("EAU_PTE_MONTANT"), "#,##0")
                    GunaTextBox68.Text = Format(Forfait.Rows(0)("EAU_GRDE_MONTANT"), "#,##0")
                    GunaTextBox62.Text = Format(Forfait.Rows(0)("BOISSONS_GAZEUSES_MONTANT"), "#,##0")
                    GunaTextBox61.Text = Format(Forfait.Rows(0)("BIERES_MONTANT"), "#,##0")
                    GunaTextBox59.Text = Format(Forfait.Rows(0)("VIN_ROUGE_MONTANT"), "#,##0")
                    GunaTextBox57.Text = Format(Forfait.Rows(0)("VIN_ROSE_MONTANT"), "#,##0")
                    GunaTextBox64.Text = Format(Forfait.Rows(0)("BOISSONS_EXT_MONTANT"), "#,##0")
                    GunaTextBoxDroitDeBouchon.Text = Format(Forfait.Rows(0)("DROIT_DE_BOUCHON"), "#,##0")

                    If Forfait.Rows(0)("VIDEO_PROJ") = 1 Then
                        GunaCheckBoxVidOui.Checked = True
                        GunaCheckBoxVidNon.Checked = False
                    Else
                        GunaCheckBoxVidNon.Checked = True
                        GunaCheckBoxVidOui.Checked = False
                    End If

                    If Forfait.Rows(0)("SONO") = 1 Then
                        GunaCheckBoxSonoOui.Checked = True
                        GunaCheckBoxSonoNon.Checked = False
                    Else
                        GunaCheckBoxSonoNon.Checked = True
                        GunaCheckBoxSonoOui.Checked = False
                    End If

                    If Forfait.Rows(0)("COUVERTS") = 1 Then
                        GunaCheckBoxCouvOui.Checked = True
                        GunaCheckBoxCouvOui.Checked = False
                    Else
                        GunaCheckBoxCouvNon.Checked = True
                        GunaCheckBoxCouvOui.Checked = False
                    End If

                    If Forfait.Rows(0)("TABLE_CHAISE") = 1 Then
                        GunaCheckBoxTableOui.Checked = True
                        GunaCheckBoxTableNon.Checked = False
                    Else
                        GunaCheckBoxTableNon.Checked = True
                        GunaCheckBoxTableOui.Checked = False
                    End If

                    If Forfait.Rows(0)("MISE_EN_PLACE") = 1 Then
                        GunaCheckBoxEcole.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 2 Then
                        GunaCheckBoxTheatre.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 3 Then
                        GunaCheckBoxRectangle.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 4 Then
                        GunaCheckBoxCocktail.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 5 Then
                        GunaCheckBoxBanquet.Checked = True
                    ElseIf Forfait.Rows(0)("MISE_EN_PLACE") = 0 Then
                        GunaCheckBoxU.Checked = True
                    End If

                    If Forfait.Rows(0)("CLOISONNEMENT") = 2 Then
                        GunaCheckBox2.Checked = True
                    ElseIf Forfait.Rows(0)("CLOISONNEMENT") = 3 Then
                        GunaCheckBox9.Checked = True
                    End If

                End If

            End If

            affectingValuesToFields()

            If Not GlobalVariable.codeReservationToUpdate = "" Then

                GunaLabelNumReservation.Visible = True
                GunaLabelNumReservation.Text = GlobalVariable.codeReservationToUpdate

            End If

            'We hide all the Datagrid used for custom filling

            GunaDataGridViewRoomType.Visible = False
            GunaDataGridViewClient.Visible = False
            GunaDataGridViewRoom.Visible = False
            GunaDataGridViewPhone.Visible = False
            'We hide all the Datagrid used for custom filling

            TabControlHbergement.SelectedIndex = 0
            GunaDataGridViewRoomType.Visible = False

        End If

    End Sub

    '--------------------------------------------------- END GESTION DES ENTENDUS - EN CHAMBRES - DEPARTS ---------------

    '--------------------------------------------- PLANNING PANNEL MANEGEMNT ----------------------------------------------

    Dim dateEntree As Date
    Dim dateDeSortie As Date
    Dim codeChambreSelectionnee As String
    Dim firstCell As Boolean = True
    Dim secondCell As Boolean = True

    'Coordinate of the selected cells OnMouseUp and OnMouseDown
    Dim m As Integer
    Dim r As Integer
    Dim n As Integer
    Dim s As Integer

    'Coordinates of the first and last cell
    Dim DisplayPoint1 As Point
    Dim DisplayPoint2 As Point

    'Used to dtermine the lenght of the selected cells
    Dim numberOfCellsSelected As Integer = 0
    Dim widthOfSelectedCells As Integer = 0

    Dim heightOfCells As Integer = 0

    Private Function comparaisonDeDatePourPositionnementEntree(ByVal Date_1 As Date, ByVal Date_2 As Date) As Date

        Dim numberOfDays As Integer = DateDiff(DateInterval.Day, Date_1, Date_2)

        'If Date_1.ToShortDateString = Date_2.ToShortDateString Then
        If numberOfDays = 0 Then
            'ON AFFICHE LA RESA A PARTIR DE LA DATE D'ENTREE = LA DATE DE DEBUT
            Return Date_1 'OU Return Date_2
            'ElseIf Date_1.ToShortDateString > Date_2.ToShortDateString Then
        ElseIf numberOfDays < 0 Then
            'ON AFFICHE LA RESA A PARTIR DE LA DATE DE DEBUT
            Return Date_1
            ' ElseIf Date_1.ToShortDateString < Date_2.ToShortDateString Then
        ElseIf numberOfDays > 0 Then
            'ON AFFICHE LA RESA A PARTIR DE LA DATE D'ENTREE
            Return Date_2
        End If

    End Function

    Private Function comparaisonDeDatePourPositionnementSortie(ByVal Date_1 As Date, ByVal Date_2 As Date) As Date

        Dim numberOfDays As Integer = DateDiff(DateInterval.Day, Date_1, Date_2)

        'If Date_1.ToShortDateString = Date_2.ToShortDateString Then
        If numberOfDays = 0 Then
            'ON AFFICHE LA RESA A PARTIR DE LA DATE D'ENTREE = LA DATE DE DEBUT
            Return Date_1 'OU Return Date_2
            'ElseIf Date_1.ToShortDateString > Date_2.ToShortDateString Then
        ElseIf numberOfDays < 0 Then
            'ON AFFICHE LA RESA A PARTIR DE LA DATE DE DEBUT
            Return Date_2
            ' ElseIf Date_1.ToShortDateString < Date_2.ToShortDateString Then
        ElseIf numberOfDays > 0 Then
            'ON AFFICHE LA RESA A PARTIR DE LA DATE D'ENTREE
            Return Date_1
        End If

    End Function

    Public Function dateAPartiDeIndexDelaColonne(ByVal premiereDateAffichable As Date, ByVal colonneIndex As Integer) As Date

        Return premiereDateAffichable.AddDays(colonneIndex)

    End Function

    'We change the label of the front desk depending on the active tab
    Public Sub nomDuLabelAAficher()

        If GunaRadioButtonSalleFete.Checked Then

            If TabControlHbergement.SelectedIndex = 0 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaFrontDeskLabel.Text = "RESERVATION SALLE DE FETE"
                Else
                    GunaFrontDeskLabel.Text = "PARTY HALL BOOKING"
                End If
            ElseIf TabControlHbergement.SelectedIndex = 1 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaFrontDeskLabel.Text = "RESERVATIONS"

                Else
                    GunaFrontDeskLabel.Text = "BOOKINGS"

                End If
            ElseIf TabControlHbergement.SelectedIndex = 2 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaFrontDeskLabel.Text = "SALLES RESERVEES"

                Else
                    GunaFrontDeskLabel.Text = "BOOKED HALLS"

                End If
            ElseIf TabControlHbergement.SelectedIndex = 3 Then


                If GlobalVariable.actualLanguageValue = 1 Then
                    TabControlHbergement.SelectedTab.Text = "Salle Occupée"
                    GunaFrontDeskLabel.Text = "SALLES OCCUPEES"
                Else
                    TabControlHbergement.SelectedTab.Text = "Occupied Halls"
                    GunaFrontDeskLabel.Text = "OCCUPIED HALLS"
                End If
            ElseIf TabControlHbergement.SelectedIndex = 4 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaFrontDeskLabel.Text = "DEPARTS"

                Else
                    GunaFrontDeskLabel.Text = "DUE OUT"

                End If
            End If

        End If

    End Sub

    Private Sub emptySearchFieldReservation()

        'Clearing of search form field
        GunaTextBoxClient.Clear()
        GunaTextBoxNumResa.Clear()
        GunaTextBoxParEntreprise.Clear()
        GunaTextBoxSourceResa.Clear()
        GunaTextBoxNumGroupe.Clear()
        GunaTextBoxTypeChambre.Clear()

    End Sub

    Private Sub TabControlHbergement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlHbergement.SelectedIndexChanged

        GunaLabelNbreDeparts.Text = "(0)"
        GunaLabelNbreEnChambre.Text = "(0)"
        GunaLabelNbreAttendu.Text = "(0)"
        GunaLabelNbreResa.Text = "(0)"

        GlobalVariable.typeChambreOuSalle = "salle"

        'On s'aasutre les tabs des arrivé est vide à l'ouverture
        DataGridViewAttenduPanel.Columns.Clear()
        DataGridViewEnChambre.Columns.Clear()
        DataGridViewDepartTab.Columns.Clear()
        GunaDataGridViewReservationList.Columns.Clear()

        nomDuLabelAAficher()

        If Not TabControlHbergement.SelectedIndex = 1 Then
            GunaDataGridViewReservationList.Columns.Clear()
        End If

        If TabControlHbergement.SelectedIndex = 0 Then

            GunaButtonVider.Visible = True
            GunaButtonQuitter.Visible = True

            If GlobalVariable.typeChambreOuSalle = "salle" Then
                GunaComboBoxImpressionSalle.Visible = True
            End If

            ImprimerDocChambreSalle.Visible = True
            GunaButtonEnvoyer.Visible = True

        Else

            ImprimerDocChambreSalle.Visible = False
            GunaButtonEnvoyer.Visible = False
            GunaButtonVider.Visible = False
            GunaButtonQuitter.Visible = False

            GunaComboBoxImpressionSalle.Visible = False

        End If

        'POUR NE PERMETTRE QUE D'AFFICHER LES RESERVATIONS SANS CHAMBRES SI TELLE EST LE CAS
        If Not TabControlHbergement.SelectedIndex = 2 Then
            If GlobalVariable.attribuerChambre = True Then
                GlobalVariable.attribuerChambre = False
            End If
        End If

        'Le statut ne doit être visible que en cas de modification

        If Trim(GunaLabelNumReservation.Text).Equals("num") Then
            GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")
        End If

    End Sub

    ' ------------------------------------------------ END PLANNING MANAGAMENT ----------------------------------------------


    '------------------------------------------------ FILLING OF CLIENT INFORMATION USING THE PHONE NUMBER ------------------------------

    'We select a client from front desk depending on his number

    Private Sub GunaTextBoxTelClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTelClient.TextChanged

        GunaDataGridViewPhone.Visible = True

        If Not Trim(GunaTextBoxTelClient.Text).Equals("") Then

            Dim Query As String = "SELECT NOM_PRENOM, EMAIL From client WHERE TELEPHONE LIKE '%" & GunaTextBoxTelClient.Text & "%'"
            Dim command As New MySqlCommand(Query, GlobalVariable.connect)
            Dim table As New DataTable
            Dim adapter_1 As New MySqlDataAdapter(command)
            adapter_1.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaDataGridViewPhone.DataSource = table
            Else
                GunaDataGridViewPhone.Columns.Clear()
                GunaDataGridViewPhone.Visible = False
            End If

            If Trim(GunaTextBoxTelClient.Text).Equals("") Then
                GunaDataGridViewPhone.Visible = False
                GunaRadioButtonWhatsAppNon.Checked = True
            Else

                If Trim(GlobalVariable.codeReservationToUpdate).Equals("") Then
                    If GunaTextBoxTelClient.TextLength = 13 Then
                        GunaRadioButtonWhatsAppOui.Checked = True
                    Else
                        GunaRadioButtonWhatsAppNon.Checked = True
                    End If

                Else
                    GunaRadioButtonWhatsAppNon.Checked = True
                End If

            End If

        Else

            GunaDataGridViewPhone.Visible = False

        End If

    End Sub

    'Filling the other fields concerning the room type when we click on the custom Datagrid
    Private Sub GunaDataGridViewPhone_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPhone.CellClick

    End Sub

    Private Sub GunaButtonListeDesCategorieDeChambre_Click(sender As Object, e As EventArgs) Handles GunaButtonListeDesCategorieDeChambre.Click

        If GunaRadioButtonSalleFete.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        End If
        'To be set back after a double click on the categorie list

        GlobalVariable.addCategorieFromFrontOffice = True

        RoomTypeForm.Show()

    End Sub

    '------------------------------------------------ END FILLING OF CLIENT INFORMATION USING THE PHONE NUMBER ---------------------------


    '------------------------------------------------ MANAGING SEJOUR AND PETIT DEJEUNER CHECK BOX --------------------------
    Private Sub GunaCheckBoxTaxeSejour_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTaxeSejour.CheckedChanged

        If GunaCheckBoxTaxeSejour.Checked Then

            GunaTextBoxTaxeSejour.Visible = True

            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim getUserQuery = "SELECT LIBELLE, CATEGORIE_HOTEL, MONTANT_TAXE FROM category_hotel_taxe_sejour_collectee INNER JOIN agence WHERE category_hotel_taxe_sejour_collectee.LIBELLE = agence.CATEGORIE_HOTEL"
            Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

            adapter.SelectCommand = Command
            adapter.Fill(table)

            If table.Rows.Count > 0 Then

                Dim TaxeSejour As Double
                Double.TryParse(table.Rows(0)("MONTANT_TAXE"), TaxeSejour)
                GunaTextBoxTaxeSejour.Visible = True
                GunaTextBoxTaxeSejour.Text = Format(TaxeSejour, "#,##0")

            Else

            End If

        Else
            GunaTextBoxTaxeSejour.Visible = False
            GunaTextBoxTaxeSejour.Clear()
        End If

    End Sub

    Private Sub GunaCheckBoxPetitDejeuenerInclus_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxPetitDejeuenerInclus.CheckedChanged

        If GunaCheckBoxPetitDejeuenerInclus.Checked Then

            GunaTextBoxPetitDejeuner.Visible = True
            GunaTextBoxPetitDejeuner.Text = 1
            GunaTextBoxBreakFastCost.Visible = True

        Else

            GunaTextBoxPetitDejeuner.Visible = False
            GunaTextBoxPetitDejeuner.Text = 0
            GunaTextBoxBreakFastCost.Visible = False
            GunaTextBoxBreakFastCost.Text = 0

        End If

    End Sub

    Private Sub GunaCheckBoxPetitDejRoutage_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxPetitDejRoutage.CheckedChanged

        If GunaCheckBoxPetitDejRoutage.Checked Then
            GunaTextBoxPetitDejeunerRoutage.Visible = False
            GunaTextBoxPetitDejeunerRoutage.Text = 1
        Else
            GunaTextBoxPetitDejeunerRoutage.Visible = False
            GunaTextBoxPetitDejeunerRoutage.Text = 0
        End If

    End Sub

    Private Sub GunaCheckBoxChambreRoutage_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxChambreRoutage.Click

        If GunaCheckBoxChambreRoutage.Checked Then

            GunaTextBoxPrixChambreRoutage.Visible = True
            GunaTextBoxPrixChambreRoutage.Text = GunaTextBoxMontantAccorde.Text

        Else

            GunaTextBoxPrixChambreRoutage.Visible = False

        End If

    End Sub

    '------------------------------------------------------ END CHECK BOX -----------------------------------------------------------


    '---------------------------GESTION DES CHECKBOXES POUR RESERVATION CHAMBRE OU SALLE DE FETE -------------------------------

    '--------------------------------- SALLE DE FETE

    Public Sub setTableUsedForAutocompletionToFalse()

        GunaDataGridViewRoomType.Visible = False
        GunaDataGridViewClient.Visible = False
        GunaDataGridViewRoom.Visible = False
        GunaDataGridViewPhone.Visible = False

    End Sub

    Public Sub valeurAZero()

        GunaTextBoxForfaitCafe.Text = 0
        GunaTextBoxForfatiDejeuner.Text = 0
        GunaTextBoxForfaitDiner.Text = 0
        GunaTextBoxForfaitTraiteur.Text = 0
        GunaTextBoxPrixGouter.Text = 0
        GunaTextBoxPUCocktail.Text = 0

        GunaTextBoxDecoration.Text = 0
        GunaTextBoxMateriel.Text = 0
        GunaTextBoxAutres.Text = 0
        GunaTextBoxMontantReelSalle.Text = 0

    End Sub


    Private Sub GunaRadioButtonSalleFete_Click(sender As Object, e As EventArgs) Handles GunaRadioButtonSalleFete.Click

    End Sub

    Public Sub GestionDesButtonDImpressionDesDocuments()

        If TabControlHbergement.SelectedIndex = 0 Then
            GunaComboBoxImpressionSalle.Visible = True
        End If

    End Sub
    '------------------------- GESTION DU CALCUL TOTAL DU COUT DE LA SALLE

    Public Function sumAReglerPourSalle()

        Dim val1 = 0
        Dim val2 = 0
        Dim val3 = 0
        Dim val4 = 0
        Dim val5 = 0
        Dim val6 = 0
        Dim val7 = 0
        Dim val8 = 0
        Dim val9 = 0
        Dim val10 = 0
        Dim val11 = 0
        Dim val12 = 0
        Dim val13 = 0
        Dim val14 = 0
        Dim val15 = 0
        Dim val16 = 0
        Dim val17 = 0
        Dim val18 = 0

        Dim qte11 = 0
        Dim qte12 = 0
        Dim qte13 = 0
        Dim qte14 = 0
        Dim qte15 = 0
        Dim qte16 = 0
        Dim qte17 = 0

        Double.TryParse(GunaTextBox47.Text, qte11)
        Double.TryParse(GunaTextBox48.Text, qte12)
        Double.TryParse(GunaTextBox54.Text, qte13)
        Double.TryParse(GunaTextBox63.Text, qte14)
        Double.TryParse(GunaTextBox10.Text, qte15)
        Double.TryParse(GunaTextBox50.Text, qte16)
        Double.TryParse(GunaTextBox36.Text, qte17)

        Double.TryParse(GunaTextBoxTPause.Text, val1)
        Double.TryParse(GunaTextBoxTDej.Text, val2)
        Double.TryParse(GunaTextBoxTDinner.Text, val3)
        Double.TryParse(GunaTextBoxTTraiteur.Text, val4)
        Double.TryParse(GunaTextBoxPrixTotalGouter.Text, val9)
        Double.TryParse(GunaTextBoxTGouter.Text, val10)

        Double.TryParse(GunaTextBoxMontantReelSalle.Text, val5)
        Double.TryParse(GunaTextBoxDecoration.Text, val6)
        Double.TryParse(GunaTextBoxMateriel.Text, val7)
        Double.TryParse(GunaTextBoxAutres.Text, val8)

        Double.TryParse(GunaTextBoxMontantEauPetiteBouteille.Text, val11)
        Double.TryParse(GunaTextBox62.Text, val12)
        Double.TryParse(GunaTextBox59.Text, val13)
        Double.TryParse(GunaTextBox64.Text, val14)
        Double.TryParse(GunaTextBox68.Text, val15)
        Double.TryParse(GunaTextBox61.Text, val16)
        Double.TryParse(GunaTextBox57.Text, val17)
        Double.TryParse(GunaTextBoxDroitDeBouchon.Text, val18)

        Return val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + (val11 * qte11) + (val12 * qte12) + (val13 * qte13) + (val14 * qte14) + (val15 * qte15) + (val16 * qte16) + (val17 * qte17) + val18

    End Function

    'Café
    Private Sub GunaTextBox40_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxForfaitCafe.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0

        Double.TryParse(GunaTextBoxForfaitCafe.Text, prix)
        Integer.TryParse(GunaTextBox35.Text, quantite)
        GunaTextBoxTPause.Text = Format(prix * quantite, "#,##0")
        ' GunaTextBoxForfaitCafe.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)

    End Sub

    Private Sub montanTotalDeLocationSalle(ByVal nombreDeJourTotal As Integer)

        If GunaCheckBoxDayUse.Checked Then
            nombreDeJourTotal = 1
        End If

        GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")

    End Sub

    Private Sub GunaTextBox35_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox35.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0
        Double.TryParse(GunaTextBoxForfaitCafe.Text, prix)
        Integer.TryParse(GunaTextBox35.Text, quantite)
        GunaTextBoxTPause.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)

        If Trim(GunaTextBoxNombreDePersonneDelaSalleDeFete.Text) = "" Then
            GunaTextBoxNombreDePersonneDelaSalleDeFete.Text = 0
        End If

        GunaTextBoxNombreDePersonneDelaSalleDeFete.Text += quantite

    End Sub

    'Déjeuner

    Private Sub GunaTextBoxForfatiDejeuner_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxForfatiDejeuner.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0
        Double.TryParse(GunaTextBoxForfatiDejeuner.Text, prix)
        Integer.TryParse(GunaTextBox30.Text, quantite)
        GunaTextBoxTDej.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)

    End Sub

    Private Sub GunaTextBox30_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox30.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0
        Double.TryParse(GunaTextBoxForfatiDejeuner.Text, prix)
        Integer.TryParse(GunaTextBox30.Text, quantite)
        GunaTextBoxTDej.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)

        If Trim(GunaTextBoxNombreDePersonneDelaSalleDeFete.Text) = "" Then
            GunaTextBoxNombreDePersonneDelaSalleDeFete.Text = 0
        End If

        GunaTextBoxNombreDePersonneDelaSalleDeFete.Text += quantite

    End Sub

    'Dinner

    Private Sub GunaTextBoxForfaitDiner_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxForfaitDiner.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0
        Double.TryParse(GunaTextBoxForfaitDiner.Text, prix)
        Integer.TryParse(GunaTextBox25.Text, quantite)
        GunaTextBoxTDinner.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)

    End Sub

    Private Sub GunaTextBox25_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox25.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0
        Double.TryParse(GunaTextBoxForfaitDiner.Text, prix)
        Integer.TryParse(GunaTextBox25.Text, quantite)
        GunaTextBoxTDinner.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)
        If Trim(GunaTextBoxNombreDePersonneDelaSalleDeFete.Text) = "" Then
            GunaTextBoxNombreDePersonneDelaSalleDeFete.Text = 0
        End If

        GunaTextBoxNombreDePersonneDelaSalleDeFete.Text += quantite

    End Sub


    'Traiteur
    Private Sub GunaTextBox34_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxForfaitTraiteur.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0
        Double.TryParse(GunaTextBoxForfaitTraiteur.Text, prix)
        Integer.TryParse(GunaTextBox13.Text, quantite)
        GunaTextBoxTTraiteur.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBox13_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox13.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0
        Double.TryParse(GunaTextBoxForfaitTraiteur.Text, prix)
        Integer.TryParse(GunaTextBox13.Text, quantite)
        GunaTextBoxTTraiteur.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")

        montanTotalDeLocationSalle(nombreDeJourTotal)

        If Trim(GunaTextBoxNombreDePersonneDelaSalleDeFete.Text) = "" Then
            GunaTextBoxNombreDePersonneDelaSalleDeFete.Text = 0
        End If

        GunaTextBoxNombreDePersonneDelaSalleDeFete.Text += quantite

    End Sub


    Private Sub GunaTextBoxMontantReelSalle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantReelSalle.TextChanged

        Dim montantAccorde As Double = 0
        'Conservation du montant accordé
        Double.TryParse(GunaTextBoxMontantReelSalle.Text, montantAccorde)
        GlobalVariable.MONTANT_ACCORDE = montantAccorde
        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBoxDecoration_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxDecoration.TextChanged

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    '------------------------------- GESTION DES IMPRESSIONS DES DOCUMENTS -------------------------------------------------------------
    ' DOCS LIES AUX CHAMBRES 
    '-------CONFIRMATION DE RESERVATION ---------------------

    Private Sub Imprimer_Click(sender As Object, e As EventArgs) Handles ImprimerDocChambreSalle.Click
        Dim montantParNuitee As Double = 0

        If GunaLabelNumReservation.Text = "num" Then

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune Réservation sélectionnée !", "Impression de Document", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No room selected !", "Print document", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If

        'Génération des documents concernants les salles Confirmation de réservation
        If GunaRadioButtonSalleFete.Checked Then

            If GunaComboBoxImpressionSalle.SelectedIndex = 0 Then

                'CONFIRMATION DE RESERVATION

                Double.TryParse(GunaTextBoxMontantReelSalle.Text, montantParNuitee)

                Functions.GenerationDeConfirmationReservation(GunaLabelNumReservation.Text, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle)

            ElseIf GunaComboBoxImpressionSalle.SelectedIndex = 1 Then
                'CONTRAT DE POLICE
                If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then

                    'Functions.GenerationDeFicheDePolice(GunaLabelNumReservation.Text, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle)

                    Impression.contratDeLocationDeSalleDeFete(GunaLabelNumReservation.Text, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle)

                Else


                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bien vouloir enregistrer la réservation", "Generate PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Please save the booking", "Generate PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End If

            ElseIf GunaComboBoxImpressionSalle.SelectedIndex = 2 Then
                Impression.devisEstimatifDeSalleDeFete(GunaLabelNumReservation.Text, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle)
            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Sélectionner un Document à imprimer !", "Impression de Document", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("Choose a document to print !", "Impression de Document", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If

            GunaComboBoxImpressionSalle.SelectedIndex = 2

        End If

    End Sub


    Private Sub GunaButtonEnvoyer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnvoyer.Click

        Dim args As ArgumentType = New ArgumentType()

        args.CODE_RESERVATAION = GunaLabelNumReservation.Text
        args.NOM_PRENOM = GunaTextBoxNomPrenom.Text
        args.ARRIVAL = GunaDateTimePickerArrivee.Value.ToShortDateString()
        args.DEPART = GunaDateTimePickerDepart.Value.ToShortDateString()
        args.TEMP_A_FAIRE = GunaTextBoxTempsAFaire.Text
        args.TYPE_CHAMBRE = GunaTextBoxLibelleTYpe.Text
        args.NUM_CHAMBRE = GunaTextBoxNumeroChambre.Text
        args.HEURE_ARRIVEE = GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem
        args.HEURE_DEPART = GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem
        args.TYPE_CHAMBRE_SALLE = GlobalVariable.typeChambreOuSalle
        args.EMAIL = GunaTextBoxClientEmail.Text
        args.TELEPHONE_CLIENT = GunaTextBoxTelClient.Text

        Dim WHATSAPP_MAIL As Integer = 2

        Dim montantParNuitee As Double = 0

        If GunaRadioButtonMailOui.Checked Then
            WHATSAPP_MAIL = 1
        End If

        If GunaRadioButtonWhatsAppOui.Checked Then
            WHATSAPP_MAIL = 0
        End If

        args.WHATSAPP_OU_EMAIL = WHATSAPP_MAIL

        If WHATSAPP_MAIL = 2 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir sélectionner une méthode d'envoie ", "Envoie de Document", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Please choose a mean to send  ", "Send Document", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Else

            'Génération des documents concernants les salles Confirmation de réservation
            If GunaRadioButtonSalleFete.Checked Then

                If GunaComboBoxImpressionSalle.SelectedIndex = 0 Then

                    'CONFIRMATION DE RESERVATION

                    Double.TryParse(GunaTextBoxMontantReelSalle.Text, montantParNuitee)

                    args.action = 1
                    'RapportApresCloture.GenerationDeConfirmationReservation(GunaLabelNumReservation.Text, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle, GunaTextBoxClientEmail.Text, GunaTextBoxTelClient.Text, WHATSAPP_MAIL)

                ElseIf GunaComboBoxImpressionSalle.SelectedIndex = 1 Then
                    'CONTRAT DE POLICE
                    If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then
                        args.action = 5
                        'RapportApresCloture.contratDeLocationDeSalleDeFete(GunaLabelNumReservation.Text, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle, GunaTextBoxClientEmail.Text, GunaTextBoxTelClient.Text, WHATSAPP_MAIL)
                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Bien vouloir enregistrer la réservation", "Generate PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Please save then booking", "Generate PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If

                ElseIf GunaComboBoxImpressionSalle.SelectedIndex = 2 Then
                    args.action = 2
                    'RapportApresCloture.devisEstimatifDeSalleDeFete(GunaLabelNumReservation.Text, GunaTextBoxNomPrenom.Text, GunaDateTimePickerArrivee.Value.ToShortDateString(), GunaDateTimePickerDepart.Value.ToShortDateString(), GunaTextBoxTempsAFaire.Text, GunaTextBoxLibelleTYpe.Text, GunaTextBoxNumeroChambre.Text, montantParNuitee, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureArrivee.SelectedItem, GlobalVariable.DateDeTravail + " " + GunaComboBoxHeureDepart.SelectedItem, GlobalVariable.typeChambreOuSalle, GunaTextBoxClientEmail.Text, GunaTextBoxTelClient.Text, WHATSAPP_MAIL)
                Else
                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Sélectionner un Document à envoyer!", "Envoi de Document", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Select a Document to be sent !", "Send Document", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End If

                If WHATSAPP_MAIL = 1 Or WHATSAPP_MAIL = 0 Then
                    backGroundWorkerToCall(args)
                End If

                GunaComboBoxImpressionSalle.SelectedIndex = 2

            End If

        End If

    End Sub

    Public Sub viderDocumentDatagrids()

        GunaDataGridViewDesFactures.Columns.Clear()
        GunaDataGridViewListeDesReglement.Columns.Clear()

    End Sub

    'Listing the room
    Private Sub GunaButtonRoomSearchButton_Click(sender As Object, e As EventArgs) Handles GunaButtonRoomSearchButton.Click

        If GunaRadioButtonSalleFete.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        Else
            GlobalVariable.typeChambreOuSalle = "chambre"
        End If

        'To load a room from a window based on conditions
        GlobalVariable.chambreOuSalleFromFrontDesk = Trim(GunaTextBoxCodeTypeDeChambre.Text)

        RoomForm.Close()
        RoomForm.Show()
        RoomForm.TopMost = True

    End Sub

    'BUtton to Load a promo code when chambre is selected
    Private Sub GunaButtonPromo_Click(sender As Object, e As EventArgs) Handles GunaButtonPromoSalle.Click, GunaButtonPromo.Click

        TarifForm.Close()

        GlobalVariable.tarifFromFrontDesk = True

        TarifForm.Show()
        TarifForm.TopMost = True

    End Sub

    ' Card paiment management
    Private Sub GunaTextBoxPaiement_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPaiement.TextChanged

        If Not Trim(GunaTextBoxPaiement.Text).Equals("") Then
            Dim paiement As Double = 0
            Double.TryParse(GunaTextBoxPaiement.Text, paiement)
            GlobalVariable.cardPaiement = paiement
        End If

    End Sub

    'GEstion du contenu du bouton paiment au niveau du front desk
    Private Sub GunaButtonPayer_Click(sender As Object, e As EventArgs) Handles GunaButtonPayer.Click

        GlobalVariable.typeDeClientAFacturer = ""

        GlobalVariable.ouvertureDelaFenetreDeReglementApArtirDu = "reception"

        ReglementForm.Close()
        ReglementForm.Show()
        ReglementForm.TopMost = True

    End Sub

    Private Sub GunaButton3_Click_1(sender As Object, e As EventArgs) Handles GunaButtonVider.Click

        GunaButtonCheckOut.Visible = False

        LabelNatureReservation.Visible = False

        Dim dialog As DialogResult

        If GlobalVariable.actualLanguageValue = 1 Then
            dialog = MessageBox.Show("Ceci aura pour effet de vider tous les champs! " & Chr(13) & "Voulez-vous continuer", "Effacement du Front desk ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Else

            dialog = MessageBox.Show("This action will empty all the fields ! " & Chr(13) & "Do you want to continue ", "Erase from Front desk ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        End If

        If dialog = DialogResult.Yes Then

            VidageDesChampsPourNouvelleReservation()

            TabControlHbergement.SelectedIndex = 0

        End If

    End Sub

    'Client form
    Private Sub GunaButtonModifierClient_Click(sender As Object, e As EventArgs) Handles GunaButtonModifierClient.Click

        GlobalVariable.editUserFromFrontOffice = True

        Dim CODE_CLIENT As String = GunaTextBoxRefClient.Text

        Dim client As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

        If client.Rows.Count > 0 Then

            ClientForm.Show()

            ClientForm.TabControl1.SelectedIndex = 0

            ClientForm.GunaTextBoxCodeClient.Text = client.Rows(0)("CODE_CLIENT")
            ClientForm.GunaTextBoxNomRaisonSociale.Text = client.Rows(0)("NOM_CLIENT")
            ClientForm.GunaDataGridViewClientExistant.Visible = False
            ClientForm.GunaTextBoxPrenom.Text = client.Rows(0)("PRENOMS")
            ClientForm.GunaTextBox12.Text = client.Rows(0)("ADRESSE")
            ClientForm.MaskedTextBoxTelephone.Text = client.Rows(0)("TELEPHONE")
            ClientForm.GunaDateTimePicker1.Value = client.Rows(0)("DATE_DE_NAISSANCE")
            ClientForm.GunaTextBox6.Text = client.Rows(0)("LIEU_DE_NAISSANCE")
            ClientForm.GunaTextBoxNomDeJeunneFille.Text = client.Rows(0)("NOM_JEUNE_FILLE")
            ClientForm.GunaTextBoxFax.Text = client.Rows(0)("FAX")
            ClientForm.GunaTextBoxEmail.Text = client.Rows(0)("EMAIL")

            '------------------------------------------------------------------------
            'GunaTextBoxNationalite.Text = client.Rows(0)("NATIONALITE")

            'GunaComboBoxPays.SelectedValue = client.Rows(0)("PAYS_RESIDENCE")

            ClientForm.GunaComboBoxPays.SelectedValue = client.Rows(0)("PAYS_RESIDENCE")

            If Trim(ClientForm.GunaTextBoxNationalite.Text).Equals("") Then

                'ClientForm.FillingAllComboxBox()

                Dim PAYS As String = ClientForm.GunaComboBoxPays.SelectedValue.ToString()
                Dim infoSup As DataTable

                If GlobalVariable.actualLanguageValue = 0 Then

                    infoSup = Functions.getElementByCode(PAYS, "pays", "NOM_PAYS_EN")

                    If infoSup.Rows.Count > 0 Then
                        ClientForm.GunaTextBoxNationalite.Text = infoSup.Rows(0)("NATIONALITE_EN")
                    End If

                Else

                    infoSup = Functions.getElementByCode(PAYS, "pays", "NOM_PAYS_FR")

                    If infoSup.Rows.Count > 0 Then
                        ClientForm.GunaTextBoxNationalite.Text = infoSup.Rows(0)("NATIONALITE_FR")
                    End If

                End If

            End If

            '-------------------------------------------------------------------------
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

            Dim compte As DataTable = Functions.getElementByCode(ClientForm.GunaTextBoxCodeClient.Text, "compte", "CODE_CLIENT")

            If compte.Rows.Count > 0 Then

                If Not Trim(compte.Rows(0)("NUMERO_COMPTE")) = "" Then
                    'LE NUMERO DE COMPTE EXISTE
                    ClientForm.GUnaTextBoxNumCompteReal.Text = Trim(compte.Rows(0)("NUMERO_COMPTE")) ' NUMERO DE COMPTE
                Else
                    'ClientForm.GUnaTextBoxNumCompteReal.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", INDICE_DE_COMPTE))
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

                'ClientForm.GUnaTextBoxNumCompteReal.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", INDICE_DE_COMPTE))

            End If

            '-------------------------------------------------------------

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

            'connect.closeConnection()

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


            If GlobalVariable.actualLanguageValue = 1 Then
                ClientForm.GunaButtonEnregistrerClient.Text = "Sauvegarder"

            Else
                ClientForm.GunaButtonEnregistrerClient.Text = "Update"
            End If

            ClientForm.TopMost = True

        End If

    End Sub

    Dim attribuerChambre As Boolean = True

    Public Sub VidageDesChampsPourNouvelleReservation()

        'GlobalVariable.connectClose()

        'GlobalVariable.connecFunction()

        GunaComboBoxHeureArrivee.Enabled = True

        GunaLabelCodeTarif.Text = "CODE TARIF"
        GunaLabelCodeTarif.Visible = False

        suivieDesReservationsVisibilte()

        GunaTextBoxMontantAccorde.Enabled = True

        'GunaRadioButtonWhatsAppNon.Checked = True
        GunaRadioButtonWhatsAppOui.Checked = True
        GunaRadioButtonWhatsAppOui.Enabled = True

        AutoLoadRoomForRouting()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaButtonReservation.Text = "Booking"
        Else
            GunaButtonReservation.Text = "Réserver"
        End If

        GunaComboBoxHeureArrivee.Enabled = True
        GunaComboBoxHeureDepart.Enabled = True

        nettoyageDesInfoPriseEnCharge()

        nettoyageDesGratuitees()

        GunaCheckBoxGratuitee.Enabled = True
        GunaCheckBoxDayUse.Enabled = True

        'REINISIALISATION DES BOUTONS DE GESTION DES RESERVATIONDE GROUPE
        If GunaCheckBoxReservationDeGroupe.Checked Then

            GunaCheckBoxReservationDeGroupe.Checked = False

            EtatDuBoutonDeGestionDesReservationDeGroupe()

            GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")

        End If

        GunaTextBoxPetitDejeuner.Text = 0
        GunaCheckBoxGratuitee.Checked = False
        'CHECK BOXE TAXE SEJOUR COLLECTE ET PETIT DEJEUENER
        GunaCheckBoxTaxeSejour.Checked = False
        GunaTextBoxTaxeSejour.Visible = False

        GunaCheckBoxPetitDejeuenerInclus.Checked = False
        GunaTextBoxPetitDejeuner.Visible = False

        'Document du front desk
        GunaDataGridViewDesFactures.Columns.Clear()
        GunaDataGridViewListeDesReglement.Columns.Clear()

        'Instruction de routage
        GunaCheckBoxPetitDejRoutage.Checked = False
        GunaCheckBoxChambreRoutage.Checked = False
        GunaTextBoxPetitDejeunerRoutage.Visible = False
        GunaTextBoxPrixChambreRoutage.Visible = False

        Functions.ClearTextBox(Me)
        GunaLabelSolde.Text = 0
        GunaLabelSolde.ForeColor = Color.Black

        GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()

        ReinitialisationDesDates()

        'Initialisation du nombre de personne
        GunaTextBoxNbreAdulte.Text = 0
        GunaTextBoxNbrePersonne.Text = GunaTextBoxNbreAdulte.Text
        GunaTextBoxNbreEnfant.Text = 0

        GunaCheckBoxPetitDejeuenerInclus.Checked = False
        GunaCheckBoxTaxeSejour.Checked = False

        GunaTextBoxCompteDebiteur.Visible = False
        GunaTextBoxBC.Visible = False

        GunaDateTimePickerArrivee.Enabled = True
        GunaDateTimePickerDepart.Enabled = True
        GunaButtonReservation.Enabled = True
        GunaButtonCheckIn.Enabled = True
        GunaButtonAnnulerResa.Enabled = True

        GunaButtonCheckOut.Enabled = True
        GunaCheckBoxDayUse.Enabled = True

        GunaCheckBoxGratuitee.Enabled = True
        GunaCheckBoxReservationDeGroupe.Enabled = True

        GunaTextBoxCodeTypeDeChambre.Enabled = True
        'GunaTextBoxLibelleTYpe.Enabled = True
        GunaButtonListeDesCategorieDeChambre.Enabled = True
        GunaTextBoxNumeroChambre.Enabled = True
        'GunaTextBoxLibelleChambre.Enabled = True
        GunaTextBoxNomPrenom.Enabled = True
        GunaTextBoxEntrepriseDuclient.Enabled = True

        GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerDepart.Value = GlobalVariable.DateDeTravail.AddDays(1)

        GunaLabelNumReservation.Visible = True
        GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")

        If GunaComboBoxTypeReservation.Items.Count > 0 Then

            GunaComboBoxTypeReservation.SelectedIndex = 0

        End If


        If GunaComboBoxSourceReservation.Items.Count > 0 Then

            Dim infoSupSource As New DataTable()

            If GlobalVariable.actualLanguageValue = 0 Then

                infoSupSource = Functions.getElementByCode("WALK IN", "SOURCE_RESERVATION", "SOURCE_RESERVATION")

                If infoSupSource.Rows.Count > 0 Then
                    'GunaComboBoxSourceReservation.SelectedValue = infoSupSource.Rows(0)("CODE_SOURCE_RESERVATION")
                End If

            Else

                infoSupSource = Functions.getElementByCode("COMPTOIR", "SOURCE_RESERVATION", "SOURCE_RESERVATION")

                If infoSupSource.Rows.Count > 0 Then
                    'GunaComboBoxSourceReservation.SelectedValue = infoSupSource.Rows(0)("CODE_SOURCE_RESERVATION")
                End If

            End If

        End If

        GunaComboBoxSourceReservation.SelectedIndex = -1

    End Sub

    Private Sub EtatDuBoutonDeGestionDesReservationDeGroupe()

        'On affiche code du groupe selon si le bouton est cochet et 
        'ne doit être modifiable que si c'est une réservation n'étant pas liée a une entreprise

        If GunaCheckBoxReservationDeGroupe.Checked Then

            GunaTextBoxCodeDeGroupe.Visible = True

            If GlobalVariable.codeReservationToUpdate = "" Then
                GunaTextBoxCodeDeGroupe.Text = Functions.GeneratingRandomCodeWithSpecifications("reservation", "")
            Else
                GunaTextBoxCodeDeGroupe.Text = GlobalVariable.ReservationToUpdate.Rows(0)("GROUPE")
            End If

            GunaTextBoxCodeDeGroupe.Visible = True
        Else
            GunaTextBoxCodeDeGroupe.Clear()
            GunaTextBoxCodeDeGroupe.Visible = False
        End If

    End Sub

    'CLICK SUR LE BOUTON DE RESERVATION EN GROUPE
    Private Sub GunaCheckBoxReservationDeGroupe_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxReservationDeGroupe.Click

        EtatDuBoutonDeGestionDesReservationDeGroupe()

    End Sub


    'CREATION D"UNE STRUCTURE DEVRANT CONTENIR CHAQUE TYPE DE CHAMBRE / RANGEE / COLONNE

    Structure enteteDuTableauDispobiliteEtTarif
        Dim nomDuTypeDeChambre As String
        Dim rowIndex As Integer
        Dim colonneIndex As Integer
    End Structure

    Public Function TauxOccupationGlobal(ByVal dateActuelle As Date) As Double

        Dim rooms As New Room()
        Dim room As DataTable = rooms.ActiveRoomsOnly()

        Dim DateDebut As Date = dateActuelle.ToString("yyyy-MM-dd")

        Dim nobreDeReservations As Integer = 0

        'EN CHAMBRE
        Dim queryEnChambre As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

        Dim commandEnChambre As New MySqlCommand(queryEnChambre, GlobalVariable.connect)
        commandEnChambre.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapterEnChambre As New MySqlDataAdapter(commandEnChambre)
        Dim tableEnChambre As New DataTable()
        adapterEnChambre.Fill(tableEnChambre)

        If (tableEnChambre.Rows.Count > 0) Then
            nobreDeReservations = tableEnChambre.Rows.Count
        End If

        'ATTENDUES
        'Dim DateFin As Date = GunaDateTimePickerDepartDepert.Value.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        If (DateDebut <= DateFin) Then

            Dim queryAttendue As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',NB_PERSONNES As 'PERSONNE(S)' FROM reservation WHERE DATE_ENTTRE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND ETAT_RESERVATION = @ETAT_RESERVATION ORDER BY CHAMBRE_ID ASC"

            Dim ETAT_RESERVATION As Integer = 0
            Dim commandAttendue As New MySqlCommand(queryAttendue, GlobalVariable.connect)
            commandAttendue.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
            commandAttendue.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int64).Value = ETAT_RESERVATION

            Dim adapterAttendue As New MySqlDataAdapter(commandAttendue)
            Dim tableAttendue As New DataTable()
            adapterAttendue.Fill(tableAttendue)

            If (tableAttendue.Rows.Count > 0) Then
                nobreDeReservations += tableAttendue.Rows.Count
            End If

        End If

        If room.Rows.Count > 0 Then
            Return (nobreDeReservations / room.Rows.Count) * 100
        Else
            Return 0
        End If

    End Function

    Private Sub suivieDesReservationsVisibilte()

        GunaLabelResa.Visible = False
        GunaLabel155.Visible = False
        GunaLabel153.Visible = False
        GunaLabel156.Visible = False
        GunaLabel154.Visible = False
        GunaLabel157.Visible = False
        GunaLabel158.Visible = False
        GunaLabel159.Visible = False
        GunaLabel160.Visible = False
        GunaLabel161.Visible = False

    End Sub

    '------------------------------ GESTION DES IMPRESSION DES FACTURES ET REGLEMENT DU CLIENT -----------------------------------------------

    Dim TotalFacture As Double = 0


    Private Sub GunaButtonPrintFromDetailsClick(sender As Object, e As EventArgs) Handles GunaButtonPrintFactureDetails.Click

        GlobalVariable.DocumentToGenerate = "facture"

        If GunaDataGridViewDesFactures.Rows.Count > 0 Then

            Functions.DocumentToPrint(GunaDataGridViewDesFactures.CurrentRow.Cells("CODE").Value.ToString, "lign_facture", "CODE_FACTURE", GlobalVariable.codeClientToUpdate, GunaLabelNumReservation.Text)

        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub


    ' ----------------------------------------------- LIVE SEARCH NEW MODEL --------------------------------------------------

    Private Sub GunaTextBoxClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxClient.TextChanged

        If Trim(GunaTextBoxClient.Text) = "" Then
            GunaDataGridViewNameSearch.Visible = False
        Else
            Recherche.RechercherClient(GunaDataGridViewNameSearch, GunaTextBoxClient.Text, "NOM_PRENOM")
        End If

    End Sub

    Private Sub GunaTextBoxNumResa_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNumResa.TextChanged

        If Trim(GunaTextBoxNumResa.Text) = "" Then
            GunaDataGridViewNumRea.Visible = False
        Else
            Recherche.RechercherParText(GunaDataGridViewNumRea, GunaTextBoxNumResa.Text, "CODE_RESERVATION")
        End If

    End Sub

    Private Sub GunaTextBoxParEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxParEntreprise.TextChanged

        If Trim(GunaTextBoxParEntreprise.Text) = "" Then
            GunaDataGridViewEntrepriseSearch.Visible = False
        Else
            Recherche.RechercherClient(GunaDataGridViewEntrepriseSearch, GunaTextBoxParEntreprise.Text, "NOM_PRENOM", "ENTREPRISE")
        End If

    End Sub

    Private Sub GunaTextBoxNumGroupe_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNumGroupe.TextChanged

        If Trim(GunaTextBoxNumGroupe.Text) = "" Then
            GunaDataGridViewGroupe.Visible = False
        Else
            Recherche.RechercherParText(GunaDataGridViewGroupe, GunaTextBoxNumGroupe.Text, "GROUPE")
        End If

    End Sub

    Private Sub GunaTextBoxTypeChambre_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTypeChambre.TextChanged

        If Trim(GunaTextBoxTypeChambre.Text) = "" Then
            GunaDataGridViewTypeChambre.Visible = False
        Else
            Recherche.RechercherParText(GunaDataGridViewTypeChambre, GunaTextBoxTypeChambre.Text, "CHAMBRE_ID")
        End If

    End Sub

    Private Sub GunaTextBoxSourceResa_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxSourceResa.TextChanged

        If Trim(GunaTextBoxSourceResa.Text) = "" Then
            GunaDataGridViewSourceRea.Visible = False
        Else
            Recherche.RechercherParText(GunaDataGridViewSourceRea, GunaTextBoxSourceResa.Text, "SOURCE_RESERVATION")
        End If

    End Sub

    'PANNEAU DE RESERVATION 
    Public Sub tarifToDisplay(ByVal CODE_ENTREPRISE As String, ByVal CODE_TYPE_CEHAMBRE As String)

        Dim prixParNuitee As Double = 0

        If (Not CODE_ENTREPRISE = "") And (Not CODE_TYPE_CEHAMBRE = "") Then

            Dim tarif As New Tarifs

            'ON SELECTIONNE L'ENSEMBLE DES TARIFS
            Dim ListOftarif As DataTable = tarif.SelectDistinctTarif()

            GunaComboBoxCodeTarif.DataSource = ListOftarif
            GunaComboBoxCodeTarif.ValueMember = "CODE_TARIF"
            GunaComboBoxCodeTarif.DisplayMember = "LIBELLE_TARIF"

            Dim TarifDuclientActuel As DataTable

            'L'entreprise existe et est associée a un tarif
            Dim FillingListquery As String = "SELECT PRIX_TARIF1,LIBELLE_TARIF, PRIX_TARIF_ENCOURS, CODE_CLIENT,CODE_TARIF FROM tarif_client INNER JOIN tarif_prix WHERE tarif_client.ID_TARIF_PRIX = tarif_prix.ID_TARIF AND CODE_CLIENT=@CODE_CLIENT AND CODE_TYPE=@CODE_TYPE"


            Dim command As New MySqlCommand(FillingListquery, GlobalVariable.connect)
            command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = Trim(CODE_ENTREPRISE)
            command.Parameters.Add("@CODE_TYPE", MySqlDbType.VarChar).Value = Trim(CODE_TYPE_CEHAMBRE)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            TarifDuclientActuel = table

            Dim prixDuTarif As Double = 0

            If TarifDuclientActuel.Rows.Count > 0 Then

                If TarifDuclientActuel.Rows(0)("PRIX_TARIF_ENCOURS") = 0 Then

                    prixDuTarif = TarifDuclientActuel.Rows(0)("TARIF_PRIX1")

                Else

                    prixDuTarif = TarifDuclientActuel.Rows(0)("PRIX_TARIF_ENCOURS")

                End If

            End If

        End If

    End Sub

    Private Sub GunaTextBoxEntrepriseDuclient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxEntrepriseDuclient.TextChanged

        If Trim(GunaTextBoxEntrepriseDuclient.Text) = "" Then

            GunaTextBoxCompteDebiteur.Visible = False
            GunaTextBoxBC.Visible = False
            GunaDataGridViewEntrepriseDuClient.Visible = False
            GunaTextBoxCodeEntrepriseDuClient.Clear()

            'SI ON EFFACE L'ENTREPRISE ASSOCIE A L'INVIDU ON  DOIT RECHERCHER LE COMPTE DE L'INDIVIDU POUR L'AFFICHER SI ACTIVER
            If Not Trim(GunaTextBoxRefClient.Text).Equals("") Then
                gestionDesComptesDebiteurLorsDesReservationsIndividu(Trim(GunaTextBoxRefClient.Text))
            End If

        Else

            'GunaTextBoxCompteDebiteur.Visible = True
            'GunaTextBoxBC.Visible = True

            GunaDataGridViewEntrepriseDuClient.Visible = True

            Dim TYPE_CLIENT = "ENTREPRISE"
            Dim TYPE_CLIENT_ = "COMPANY"

            Dim query As String = "SELECT NOM_CLIENT From client, compte 
                WHERE NOM_CLIENT Like '%" & GunaTextBoxEntrepriseDuclient.Text & "%' 
                AND TYPE_CLIENT=@TYPE_CLIENT AND client.CODE_CLIENT = compte.CODE_CLIENT AND ETAT_DU_COMPTE=@ETAT_DU_COMPTE AND ETAT_DU_COMPTE=@ETAT_DU_COMPTE
                OR
                NOM_CLIENT Like '%" & GunaTextBoxEntrepriseDuclient.Text & "%' AND TYPE_CLIENT=@TYPE_CLIENT_ AND client.CODE_CLIENT = compte.CODE_CLIENT 
                AND ETAT_DU_COMPTE=@ETAT_DU_COMPTE"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
            command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = TYPE_CLIENT
            command.Parameters.Add("@TYPE_CLIENT_", MySqlDbType.VarChar).Value = TYPE_CLIENT_
            command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = 1

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                GunaDataGridViewEntrepriseDuClient.DataSource = table
            Else
                GunaDataGridViewEntrepriseDuClient.Columns.Clear()
                GunaDataGridViewEntrepriseDuClient.Visible = False
            End If

            GunaTextBox11.Text = GunaTextBoxEntrepriseDuclient.Text

            If Trim(GunaTextBoxEntrepriseDuclient.Text).Equals("") Then

                GunaTextBoxCodeEntrepriseDuClient.Clear()
                GunaLabelCodeTarif.Visible = False
                GunaComboBoxCodeTarif.Visible = False
                GunaDataGridViewEntrepriseDuClient.Visible = False

            End If

        End If

    End Sub

    Private Sub GunaDataGridViewEntrepriseDuClient_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewEntrepriseDuClient.CellClick

        GunaDataGridViewEntrepriseDuClient.Visible = False

        If e.RowIndex >= 0 Then

            If Trim(GunaTextBoxEntrepriseDuclient.Text) = "" Then
                GunaTextBoxCompteDebiteur.Visible = False
                GunaTextBoxBC.Visible = False
            Else
                GunaTextBoxCompteDebiteur.Visible = True
                GunaTextBoxBC.Visible = True
            End If

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewEntrepriseDuClient.Rows(e.RowIndex)

            Dim company As DataTable = Functions.getElementByCode(Trim(row.Cells("NOM_CLIENT").Value.ToString), "client", "NOM_CLIENT")

            If company.Rows.Count > 0 Then

                GunaTextBoxEntrepriseDuclient.Text = Trim(company.Rows(0)("NOM_CLIENT"))
                GunaTextBoxCodeEntrepriseDuClient.Text = Trim(company.Rows(0)("CODE_CLIENT"))

                GunaDataGridViewEntrepriseDuClient.Visible = False

                Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxCodeEntrepriseDuClient.Text)
                Dim CODE_TYPE_CEHAMBRE As String = Trim(GunaTextBoxCodeTypeDeChambre.Text)

                'On recherche si l'entreprise associé au client a une tarification
                tarifToDisplay(CODE_ENTREPRISE, CODE_TYPE_CEHAMBRE)

                gestionDesComptesDebiteurLorsDesReservations(CODE_ENTREPRISE)

                If Trim(company.Rows(0)("CODE_ELITE")).Equals("") Then
                    'GunaLabel7.Visible = False
                    'GunaTextBoxCodeElite.Visible = False
                    'GunaTextBoxCodeElite.Text = ""
                Else
                    GunaLabelElite.Visible = True
                    GunaTextBoxCodeElite.Visible = True
                    GunaTextBoxCodeElite.Text = company.Rows(0)("CODE_ELITE")
                End If

            End If

            'connect.closeConnection()


        End If

    End Sub

    Public Sub gestionDesComptesDebiteurLorsDesReservationsIndividu(ByVal CODE_ENTREPRISE As String) 'GESTION DU PLAFONDS DU COMPTE

        '---------------------- GESTION DES COMPTES DEBITEUR ENTREPRISE ASSOCIE A LA RESERVATION ----------------

        'SELECTION DU COMPTE DE L'ENTREPRISE ACTUEL
        Dim compte As DataTable = Functions.getElementByCode(CODE_ENTREPRISE, "compte", "CODE_CLIENT")

        If compte.Rows.Count > 0 Then

            'MessageBox.Show(compte.Rows(0)("NUMERO_COMPTE"))

            If Not Trim(compte.Rows(0)("CODE_CLIENT")).Equals("") Then

                If compte.Rows(0)("ETAT_DU_COMPTE") = 1 Then
                    'COMPTE ACTIF

                    GunaTextBoxCompteDebiteur.Visible = True
                    GunaTextBoxBC.Visible = False

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
            End If

        Else

        End If

        GunaTextBoxCompteDebiteur.ForeColor = Color.White

        '---------------------- END GESTION DES COMPTES DEBITEUR ENTREPRISE ASSOCIE A LA RESERVATION --------------

    End Sub

    Public Sub gestionDesComptesDebiteurLorsDesReservations(ByVal CODE_ENTREPRISE As String) 'GESTION DU PLAFONDS DU COMPTE

        '---------------------- GESTION DES COMPTES DEBITEUR ENTREPRISE ASSOCIE A LA RESERVATION ----------------

        'SELECTION DU COMPTE DE L'ENTREPRISE ACTUEL
        Dim compte As DataTable = Functions.getElementByCode(CODE_ENTREPRISE, "compte", "CODE_CLIENT")

        If compte.Rows.Count > 0 Then

            If Not Trim(compte.Rows(0)("CODE_CLIENT")).Equals("") Then


                If compte.Rows(0)("ETAT_DU_COMPTE") = 1 Then
                    'COMPTE ACTIF

                    GunaTextBoxCompteDebiteur.Visible = True
                    GunaTextBoxBC.Visible = True

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

                Else

                    'GunaTextBoxCompteDebiteur.Text = ""
                    'GunaTextBoxCompteDebiteur.BaseColor = Color.White
                    'COMPTE INACTIF
                    'GunaTextBoxCompteDebiteur.BaseColor = Color.Red
                    'GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE") & " (Inactif)"

                End If

            End If

            'GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")
            'GunaTextBoxCompteDebiteur.ForeColor = Color.White

        Else

            'GunaTextBoxCompteDebiteur.Visible = False
            'GunaTextBoxBC.Visible = False

        End If

        If Trim(GunaTextBoxEntrepriseDuclient.Text) = "" Then
            GunaTextBoxCompteDebiteur.Visible = False
            GunaTextBoxBC.Visible = False
        End If

        GunaTextBoxCompteDebiteur.ForeColor = Color.White

        '---------------------- END GESTION DES COMPTES DEBITEUR ENTREPRISE ASSOCIE A LA RESERVATION --------------

    End Sub

    'GESTION DES CHAMPS DE RECHERCHE
    Private Sub GunaButtonArricherReservation_Click(sender As Object, e As EventArgs) Handles GunaButtonArricherReservation.Click

        If GunaComboBoxFiltre.SelectedIndex = -1 Then

            'LES FILTRES

            If Not Trim(GunaTextBoxClient.Text).Equals("") Then
                ReservationList("NOM_CLIENT", Trim(GunaTextBoxClient.Text))
            ElseIf Not Trim(GunaTextBoxNumResa.Text).Equals("") Then
                ReservationList("CODE_RESERVATION", Trim(GunaTextBoxNumResa.Text))
            ElseIf Not Trim(GunaTextBoxParEntreprise.Text).Equals("") Then
                ReservationList("NOM_ENTREPRISE", Trim(GunaTextBoxParEntreprise.Text))
            ElseIf Not Trim(GunaTextBoxSourceResa.Text).Equals("") Then
                ReservationList("SOURCE_RESERVATION", Trim(GunaTextBoxSourceResa.Text))
            ElseIf Not Trim(GunaTextBoxNumGroupe.Text).Equals("") Then
                ReservationList("GROUPE", Trim(GunaTextBoxNumGroupe.Text))
            ElseIf Not Trim(GunaTextBoxTypeChambre.Text).Equals("") Then
                ReservationList("CHAMBRE_ID", Trim(GunaTextBoxTypeChambre.Text))
            Else
                Recherche.RechercherParDate(GunaDataGridViewReservationList, GunaDateTimePickerParDateArrivee.Value, GunaDateTimePickerParDateDepart.Value)
            End If

        ElseIf GunaComboBoxFiltre.SelectedIndex = 0 Then
            ReservationList("entreprise", "NOM_ENTREPRISE")
        ElseIf GunaComboBoxFiltre.SelectedIndex = 1 Then
            ReservationList("groupe", "GROUPE")
        ElseIf GunaComboBoxFiltre.SelectedIndex = 2 Then
            ReservationList("individuelle", "")
        ElseIf GunaComboBoxFiltre.SelectedIndex = 3 Then
            ReservationList("all", "none")
        End If

        If GunaDataGridViewReservationList.Rows.Count > 0 Then
            GunaLabelNbreResa.Text = "(" & GunaDataGridViewReservationList.Rows.Count & ")"
        Else
            GunaLabelNbreResa.Text = "(0)"
        End If
        'We empty the search field field after reservation 
        emptySearchFieldReservation()

    End Sub

    'Nom de client
    Private Sub GunaDataGridViewNameSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewNameSearch.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewNameSearch.Rows(e.RowIndex)

            GunaTextBoxClient.Text = Trim(row.Cells("NOM_PRENOM").Value.ToString())

            GunaDataGridViewNameSearch.Visible = False

        End If

    End Sub

    'Num Rea
    Private Sub GunaDataGridViewNumRea_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewNumRea.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewNumRea.Rows(e.RowIndex)

            GunaTextBoxNumResa.Text = Trim(row.Cells("CODE_RESERVATION").Value.ToString())

            GunaDataGridViewNumRea.Visible = False

        End If

    End Sub

    'Entreprise
    Private Sub GunaDataGridViewEntrepriseSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewEntrepriseSearch.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewEntrepriseSearch.Rows(e.RowIndex)

            GunaTextBoxParEntreprise.Text = Trim(row.Cells("NOM_PRENOM").Value.ToString())

            GunaDataGridViewEntrepriseSearch.Visible = False

        End If

    End Sub

    Private Sub GunaDataGridViewSourceRea_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewSourceRea.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewSourceRea.Rows(e.RowIndex)

            GunaTextBoxSourceResa.Text = Trim(row.Cells("SOURCE_RESERVATION").Value.ToString())

            GunaDataGridViewSourceRea.Visible = False

        End If

    End Sub

    Private Sub GunaDataGridViewGroupe_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewGroupe.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewGroupe.Rows(e.RowIndex)

            GunaTextBoxNumGroupe.Text = Trim(row.Cells("GROUPE").Value.ToString())

            GunaDataGridViewGroupe.Visible = False

        End If

    End Sub

    Private Sub GunaDataGridViewTypeChambre_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewTypeChambre.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewTypeChambre.Rows(e.RowIndex)

            GunaTextBoxTypeChambre.Text = Trim(row.Cells("CHAMBRE_ID").Value.ToString())

            GunaDataGridViewTypeChambre.Visible = False

        End If

    End Sub

    Private Sub showZenlockFormAsync()

        ZenoLockForm.Show()
        ZenoLockForm.TopMost = True

    End Sub

    'Affichage des documents
    Private Sub GunaButton3_Click_2(sender As Object, e As EventArgs) Handles GunaButtonAffichageDesDocuments.Click

        If Not Trim(GunaTextBoxRefClient.Text).Equals("") Then
            ListeDesFacturesEtReglementPourUneReservation()
        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir charger une réservation !!", "Facturation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Pleas load a new booking !!", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If



        End If

    End Sub

    Public Sub ficheTechniqueDeManifestation()

        GunaTextBoxNoMClient.Text = GunaTextBoxNomPrenom.Text
        GunaTextBox11.Text = GunaTextBoxEntrepriseDuclient.Text
        GunaTextBox12.Text = GunaTextBoxTelClient.Text
        GunaTextBox17.Text = GunaTextBoxClientEmail.Text
        GunaTextBox14.Text = ""

        '---------------------------------------------------------
        'selection de l'evenement a partir du code
        If GunaComboBoxEvenement.SelectedIndex >= 0 Then

            Dim CODE_EVENEMENT As String = GunaComboBoxEvenement.SelectedValue.ToString
            Dim evenement As DataTable = Functions.getElementByCode(CODE_EVENEMENT, "evenement", "CODE_EVENEMENT")

            If evenement.Rows.Count > 0 Then
                GunaTextBox22.Text = evenement.Rows(0)("LIBELLE")
            End If

        End If

        'GunaTextBox24.Text = GlobalVariable.societe.Rows(0)("VILLE")
        GunaTextBox24.Text = GunaTextBoxLibelleTYpe.Text

        GunaTextBox32.Text = GunaTextBoxNbrePersonne.Text

        GunaTextBox27.Text = GunaDateTimePickerArrivee.Value.ToShortDateString

        If Trim(GlobalVariable.codeReservationToUpdate) = "" Then
            GunaCheckBoxVidOui.Checked = True
            GunaCheckBoxSonoOui.Checked = True
            GunaCheckBoxCouvOui.Checked = True
            GunaCheckBoxTableOui.Checked = True
        End If

        Dim salle As DataTable = Functions.getElementByCode(GunaTextBoxNumeroChambre.Text, "chambre", "CODE_CHAMBRE")

        If salle.Rows.Count > 0 Then
            GunaTextBox66.Text = salle.Rows(0)("LIBELLE_CHAMBRE")
        End If

        GunaTextBoxMontantSalleManifest.Text = GunaTextBoxMontantReelSalle.Text

        'MONTANT GLOBAL
        GunaTextBoxMontantGlobal.Text = GunaTextBoxGrandTotal.Text

    End Sub

    Private Sub TabControlGestionReservation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlGestionReservation.SelectedIndexChanged
        GunaDataGridViewDesFactures.Columns.Clear()
        'GunaGroupBoxStatistiques
        GunaDataGridViewListeDesReglement.Columns.Clear()

        If TabControlGestionReservation.SelectedIndex = 2 Then

            If GlobalVariable.typeChambreOuSalle = "salle" Then
                'If Trim(GlobalVariable.codeReservationToUpdate) = "" Then
                'AINSI L'INITIALISATION DES DE LA FICHE DE MANIFESTATION SE FERA UNIQUEMENT A LA CREATION
                ficheTechniqueDeManifestation()
                'End If
            End If

        ElseIf Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then
            GunaDataGridViewListeDesReglement.Columns.Clear()
            GunaDataGridViewDesFactures.Columns.Clear()
        End If

        If TabControlGestionReservation.SelectedIndex = 1 Then

            'ON NE FACTURE PAS LES CLIENTS QUI NE SONT PAS EN CHAMBRES

            If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then

                Dim ETAT_RESERVATION As Integer = 1

                Dim resa As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION", ETAT_RESERVATION, "ETAT_RESERVATION")

                If Not resa.Rows.Count > 0 Then

                    TabControlGestionReservation.SelectedIndex = 0

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Vous ne pouvez facturer que les en chambres !!", "Facturation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("You can only bill In house !!", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            End If

        End If

    End Sub

    'Gestion des siestes et nuites
    Private Sub GunaCheckBoxDayUse_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDayUse.Click

        If GunaCheckBoxDayUse.Checked Then

            GunaButtonTarifAppliquable.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTotalHeure.Text = "Nombre de heures"
                GunaLabelPrixParNuitee.Text = "Prix par heure"
                GunaLabelPrixSejours.Text = "Prix de la sieste"
                GunaLabelTempsAFaire.Text = "Total heure(s)"
            Else
                GunaLabelTotalHeure.Text = "Number of hours"
                GunaLabelPrixParNuitee.Text = "Price per hour"
                GunaLabelPrixSejours.Text = "Day use price"
                GunaLabelTempsAFaire.Text = "Total hour(s)"
            End If

            If GlobalVariable.typeChambreOuSalle = "salle" Then
                GunaDateTimePickerDepart.Value = GunaDateTimePickerArrivee.Value
            Else
                GunaDateTimePickerDepart.Value = GlobalVariable.DateDeTravail
                GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail
            End If

            Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.SelectedItem

            Dim DateTimeDepartStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureDepart.SelectedItem

            Dim DateTimeArrivee As DateTime = CDate(DateTimeArriveeStringFormat).ToLongTimeString
            Dim DateTimeDepart As DateTime = CDate(DateTimeDepartStringFormat).ToLongTimeString

            Dim numberOfHoursToSpend As Integer = 0
            numberOfHoursToSpend = CType((DateTimeDepart - DateTimeArrivee).TotalHours, Int32)

            GunaComboBoxHeureDepart.Items.Clear()

            If numberOfHoursToSpend > 0 Then
                GunaTextBoxTempsAFaire.Text = numberOfHoursToSpend
            Else
                GunaTextBoxTempsAFaire.Text = 0
            End If

            GunaComboBoxHeureArrivee.Items.Clear()

            Dim timeString As String = Now().ToLongTimeString
            GunaComboBoxHeureArrivee.Items.Add(timeString)

            GunaComboBoxHeureArrivee.SelectedItem = timeString

            GunaComboBoxHeureDepart.Items.Add(CDate(GunaComboBoxHeureArrivee.Text).AddHours(1))

            GunaComboBoxHeureDepart.SelectedIndex = 0

        Else

            GunaComboBoxHeureArrivee.Items.Clear()
            GunaComboBoxHeureArrivee.Items.Add("12:00:00")
            GunaComboBoxHeureArrivee.SelectedItem = "12:00:00"

            GunaComboBoxHeureDepart.Items.Clear()
            GunaComboBoxHeureDepart.Items.Add("12:00:00")
            GunaComboBoxHeureDepart.SelectedItem = "12:00:00"

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTotalHeure.Text = "Nombre de nuitée(s)"
                GunaLabelPrixParNuitee.Text = "Prix par nuitée"
                GunaLabelPrixSejours.Text = "Prix du séjours"
                GunaLabelTempsAFaire.Text = "Total nuitées"

            Else
                GunaLabelTotalHeure.Text = "Number of days"
                GunaLabelPrixParNuitee.Text = "Price per night"
                GunaLabelPrixSejours.Text = "Price of stay"
                GunaLabelTempsAFaire.Text = "Total nights"

            End If

            GunaDateTimePickerDepart.Value = GlobalVariable.DateDeTravail.AddDays(1)
            GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail

            GunaTextBoxTempsAFaire.Visible = True

        End If

        Dim CODE_TYPE_CHAMBRE As String = GunaTextBoxCodeTypeDeChambre.Text
        prixHebergementAUtiliser(CODE_TYPE_CHAMBRE)

    End Sub

    Private Sub GunaComboBoxHeureDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxHeureDepart.SelectedIndexChanged

        If GunaCheckBoxDayUse.Checked Then

            Dim DateTimeArriveeStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.SelectedItem

            Dim DateTimeDepartStringFormat As String = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureDepart.SelectedItem

            'Dim DateTimeArrivee As DateTime = DateTime.ParseExact(DateTimeArriveeStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
            Dim DateTimeArrivee As DateTime = CDate(DateTimeArriveeStringFormat).ToLongTimeString
            'Dim DateTimeDepart As DateTime = DateTime.ParseExact(DateTimeDepartStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
            Dim DateTimeDepart As DateTime = CDate(DateTimeDepartStringFormat).ToLongTimeString

            Dim numberOfHoursToSpend As Integer = 0
            numberOfHoursToSpend = CType((DateTimeDepart - DateTimeArrivee).TotalHours, Int32)

            If numberOfHoursToSpend > 0 Then
                GunaTextBoxTempsAFaire.Text = numberOfHoursToSpend
            Else
                GunaTextBoxTempsAFaire.Text = 0
            End If

            '-----------------------------

        End If

    End Sub

    Private Sub GunaComboBoxHeureArrivee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxHeureArrivee.SelectedIndexChanged

        If GunaCheckBoxDayUse.Checked Then

            GunaComboBoxHeureDepart.Items.Add(Now().AddHours(1).ToLongTimeString())
            GunaComboBoxHeureArrivee.Items.Add(Now().ToLongTimeString())

            Dim DateTimeArriveeStringFormat As String = ""
            Dim DateTimeDepartStringFormat As String = ""

            If GunaComboBoxHeureArrivee.Items.Count >= 0 Then
                DateTimeArriveeStringFormat = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureArrivee.SelectedItem
            End If

            If GunaComboBoxHeureDepart.Items.Count >= 0 Then
                DateTimeDepartStringFormat = Format(GlobalVariable.DateDeTravail, "yyyy-MM-dd") + " " + GunaComboBoxHeureDepart.SelectedItem
            End If

            'Dim DateTimeArrivee As DateTime = DateTime.ParseExact(DateTimeArriveeStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
            Dim DateTimeArrivee As DateTime = CDate(DateTimeArriveeStringFormat).ToLongTimeString
            'Dim DateTimeDepart As DateTime = DateTime.ParseExact(DateTimeDepartStringFormat, "yyyy-MM-dd HH:mm:ss", Nothing)
            Dim DateTimeDepart As DateTime = CDate(DateTimeDepartStringFormat).ToLongTimeString

            Dim numberOfHoursToSpend As Integer = 1
            numberOfHoursToSpend = CType((DateTimeDepart - DateTimeArrivee).TotalHours, Int32)

            If numberOfHoursToSpend > 0 Then
                GunaTextBoxTempsAFaire.Text = numberOfHoursToSpend
            Else
                GunaTextBoxTempsAFaire.Text = 0
            End If

            '-----------------------------
        End If

    End Sub

    ' ------------------ END GESTION DES SIESTE-----------------------------------

    Public Sub ActivationOuDesactivationDeToutLesBoutonsApresUnCheckOUt()

        If Trim(LabelNatureReservation.Text) = "CHECKOUT" Then

            GunaDateTimePickerArrivee.Enabled = False
            GunaComboBoxHeureArrivee.Enabled = False
            GunaDateTimePickerDepart.Enabled = False
            GunaComboBoxHeureDepart.Enabled = False
            GunaCheckBoxDayUse.Enabled = False
            GunaCheckBoxGratuitee.Enabled = False
            GunaTextBoxTempsAFaire.Enabled = False
            GunaTextBoxCodeTypeDeChambre.Enabled = False
            GunaButtonListeDesCategorieDeChambre.Enabled = False
            GunaTextBoxNomPrenom.Enabled = False
            GunaTextBoxEntrepriseDuclient.Enabled = False
            GunaTextBoxCodeDeGroupe.Enabled = False
            GunaCheckBoxReservationDeGroupe.Enabled = False
            GunaButtonReservation.Enabled = False
            GunaTextBoxNumeroChambre.Enabled = False
            GunaButtonRoomSearchButton.Enabled = False
            GunaComboBoxHeureArrivee.Enabled = False
            GunaComboBoxHeureDepart.Enabled = False


        Else

            GunaComboBoxHeureArrivee.Enabled = True
            GunaComboBoxHeureDepart.Enabled = True

            GunaDateTimePickerArrivee.Enabled = True
            GunaComboBoxHeureArrivee.Enabled = True
            GunaDateTimePickerDepart.Enabled = True
            GunaComboBoxHeureDepart.Enabled = True
            GunaCheckBoxDayUse.Enabled = True
            GunaTextBoxTempsAFaire.Enabled = True
            GunaTextBoxCodeTypeDeChambre.Enabled = True
            GunaButtonListeDesCategorieDeChambre.Enabled = True
            GunaTextBoxNomPrenom.Enabled = True
            GunaTextBoxEntrepriseDuclient.Enabled = True
            GunaTextBoxCodeDeGroupe.Enabled = True
            GunaCheckBoxReservationDeGroupe.Enabled = True
            GunaButtonReservation.Enabled = True
            GunaTextBoxNumeroChambre.Enabled = True
            GunaButtonRoomSearchButton.Enabled = True


        End If


    End Sub

    Public Shared Function SituationDeCaisseEspeces(ByVal DateDeSituation As Date) As DataTable

        Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT AND MODE_REGLEMENT=@MODE_REGLEMENT ORDER BY DATE_REGLEMENT DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        'If GlobalVariable.actualLanguageValue = 1 Then
        'command.Parameters.Add("@MODE_REGLEMENT", MySqlDbType.VarChar).Value = "Espèce"
        'Else
        command.Parameters.Add("@MODE_REGLEMENT", MySqlDbType.VarChar).Value = "Cash"
        'End If

        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function SituationDeCaisseJournaliere() As Double

        Dim situationDeCaisse As DataTable = SituationDeCaisseEspeces(GlobalVariable.DateDeTravail)

        Dim TotalFacture As Double = 0

        If situationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To situationDeCaisse.Rows.Count - 1
                TotalFacture += situationDeCaisse.Rows(i)("MONTANT_VERSE")
            Next

            Dim situationDeCaisseCasDeRemboursement As DataTable = Functions.SituationDeCaisseCasDeRemboursement(GlobalVariable.DateDeTravail)

            Dim TotalRembourse As Double = 0
            'On selection l'ensemble des remboursement d'un jour donné
            If situationDeCaisseCasDeRemboursement.Rows.Count > 0 Then

                For j = 0 To situationDeCaisseCasDeRemboursement.Rows.Count - 1
                    TotalRembourse += situationDeCaisseCasDeRemboursement.Rows(j)("MONTANT_HT")
                Next

                'On soustrait les montant remboursé des montants encaissé
                TotalFacture -= TotalRembourse

            End If

        End If

        Return TotalFacture

    End Function


    'NE PAS PERMETTRE LE CHECKIN D'UNE CHAMBRE OCCUPEE

    Private Sub chambreOccupeOuPas(ByVal CODE_CHAMBRE As String)

        'On affiche toutes les reserv_conf dont la date saisie est entre la d'entrée et la date de sortie (inclusif)

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE AND CHAMBRE_ID=@CODE_CHAMBRE ORDER BY CHAMBRE_ID ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If Not table.Rows.Count > 0 Then
            GunaButtonCheckIn.Visible = True
        End If

    End Sub


    Private Sub TimerToRefreshClock_Tick(sender As Object, e As EventArgs) Handles TimerToRefreshClock.Tick

        If Not Trim(GunaTextBoxNomPrenom.Text) = "" Then

            Dim CODE_CLIENT As String = GunaTextBoxRefClient.Text
            gestionDesComptesDebiteurLorsDesReservationsIndividu(CODE_CLIENT)

        End If

        If Not Trim(GunaTextBoxEntrepriseDuclient.Text) = "" Then

            Dim CODE_ENTREPRISE As String = GunaTextBoxCodeEntrepriseDuClient.Text
            gestionDesComptesDebiteurLorsDesReservations(CODE_ENTREPRISE)

        End If

        'RAFRAICHISSEMENT DU SOLDE D'UN CLIENT EN CHAMBRE
        If Not GlobalVariable.codeReservationToUpdate = "" Then

            'Dim solde As Double = Double.Parse(Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate))
            Dim solde As Double = Double.Parse(Functions.SituationDeReservation(GunaLabelNumReservation.Text))
            GunaLabelSolde.Text = Format(solde, "#,##0")

            If 0 > solde Then
                GunaLabelSolde.ForeColor = Color.Red
            ElseIf solde = 0 Then
                GunaLabelSolde.ForeColor = Color.Black
            Else
                GunaLabelSolde.ForeColor = Color.Green
            End If

        End If

        '-------------------------------------------- BOUTON A IMPRIMER DES DOCUMENTS ------------------------------------------------

        If TabControlHbergement.SelectedIndex = 0 Then
            GunaComboBoxImpressionSalle.Visible = True

            ImprimerDocChambreSalle.Visible = True
            GunaButtonEnvoyer.Visible = True
        Else
            GunaComboBoxImpressionSalle.Visible = False
            ImprimerDocChambreSalle.Visible = False
            GunaButtonEnvoyer.Visible = False
        End If

        'ON AFFICHE LE CHECKIN EN DATE DE SORTIE POUR LES EN CHAMBRES
        If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then

            Dim resa As DataTable

            If CDate(GlobalVariable.DateDeTravail).ToShortDateString = GunaDateTimePickerDepart.Value.ToShortDateString Then

                resa = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

                If resa.Rows.Count > 0 Then
                    If resa.Rows(0)("ETAT_RESERVATION") = 1 Then
                        GunaButtonCheckOut.Visible = True
                    Else
                        If resa.Rows(0)("ETAT_RESERVATION") = 0 Then
                            GunaButtonReservation.Enabled = False
                        Else
                            GunaButtonReservation.Enabled = True
                        End If
                        GunaButtonCheckOut.Visible = False
                    End If
                Else
                    GunaButtonCheckOut.Visible = False
                End If

            Else
                GunaButtonCheckOut.Visible = False
            End If

            Dim CODE_CHAMBRE As String = Trim(GunaTextBoxNumeroChambre.Text)

            If CDate(GlobalVariable.DateDeTravail).ToShortDateString = GunaDateTimePickerArrivee.Value.ToShortDateString Then

                resa = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reservation", "CODE_RESERVATION")

                If resa.Rows.Count > 0 Then
                    If resa.Rows(0)("ETAT_RESERVATION") = 0 Then
                        GunaButtonCheckIn.Visible = True

                        'ON CONTROLE SI LA CHAMBRE EST DEJA OCCUPE POUR LES RESERVATIONS FUTURS
                        chambreOccupeOuPas(CODE_CHAMBRE)

                    Else
                        If resa.Rows(0)("ETAT_RESERVATION") = 2 Then
                            GunaButtonReservation.Enabled = False
                        Else
                            GunaButtonReservation.Enabled = True
                        End If
                        GunaButtonCheckIn.Visible = False
                    End If
                Else
                    GunaButtonCheckIn.Visible = False
                End If

            Else
                GunaButtonCheckIn.Visible = False
            End If

        Else
            GunaButtonCheckOut.Visible = False
            'GunaButtonCheckIn.Visible = False
        End If

        reservationButtonToDisplay()

        TimerToRefreshClock.Stop()

    End Sub

    Private Sub TabControlListeDesDocumentsFacturesEtReglement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlListeDesDocumentsFacturesEtReglement.SelectedIndexChanged

        GunaDataGridViewDesFactures.Columns.Clear()
        'GunaGroupBoxStatistiques
        GunaDataGridViewListeDesReglement.Columns.Clear()

    End Sub

    'GESTION DES INSTRUCTIONS DE FACTURATION
    Private Sub GunaCheckBoxPDJFact_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxPDJFact.CheckedChanged

        If GunaCheckBoxPDJFact.Checked Then
            GunaTextBoxPDJInstruc.Visible = True
        Else
            GunaTextBoxPDJInstruc.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBoxBoisson_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxBoisson.CheckedChanged

        If GunaCheckBoxBoisson.Checked Then
            GunaTextBoxBoissonFact.Visible = True
        Else
            GunaTextBoxBoissonFact.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBoxNavette_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxNavette.CheckedChanged

        If GunaCheckBoxNavette.Checked Then
            GunaTextBoxNavetteVal.Visible = True
        Else
            GunaTextBoxNavetteVal.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBoxDinner_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxDinner.CheckedChanged

        If GunaCheckBoxDinner.Checked Then
            GunaTextBoxDinnerInstrucfact.Visible = True
        Else
            GunaTextBoxDinnerInstrucfact.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBoxBlanchisserieFact_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxBlanchisserieFact.CheckedChanged

        If GunaCheckBoxBlanchisserieFact.Checked Then
            GunaTextBoxBlanchFact.Visible = True
        Else
            GunaTextBoxBlanchFact.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBoxSalleConfFact_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxSalleConfFact.CheckedChanged

        If GunaCheckBoxSalleConfFact.Checked Then
            GunaTextBoxSalleConfFact.Visible = True
        Else
            GunaTextBoxSalleConfFact.Visible = False
        End If

    End Sub

    Private Sub resaParTypeOuSource(ByVal NATURE As String)

        If NATURE = "source" Then

        ElseIf NATURE = "type" Then

        End If

        Dim query As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reservation WHERE  TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As DataTable

        adapter.Fill(table)

        Dim query1 As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE  TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)

        table.Merge(table1)

    End Sub

    Private Sub GunaDataGridViewDesFactures_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewDesFactures.CellDoubleClick

        GunaDataGridViewDetailsFacture.Columns.Clear()

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewDesFactures.Rows(e.RowIndex)

            Dim CODE_FACTURE As String = row.Cells("CODE").Value.ToString

            DetailDeFacture(CODE_FACTURE)

            GunaTextBoxFactureDeDetail.Text = CODE_FACTURE

            TabControlListeDesDocumentsFacturesEtReglement.SelectedIndex = 2

        End If

    End Sub

    Structure SituationFacture

        Dim dateOperation
        Dim libelleOperation
        Dim Debit
        Dim quantite

    End Structure

    '--------------------------------------------------------------------------------------
    Public Sub DetailDeFacture(ByVal CODE_FACTURE As String)

        'Dim query As String = "SELECT CODE_FACTURE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC FROM ligne_facture WHERE CODE_FACTURE = @CODE_FACTURE AND ETAT_FACTURE = 1 ORDER BY DATE_FACTURE ASC"
        Dim query As String = "SELECT DATE_FACTURE AS DATE, LIBELLE_FACTURE as 'LIBELLE' , QUANTITE , MONTANT_TTC as 'MONTANT'FROM ligne_facture WHERE CODE_FACTURE = @CODE_FACTURE AND ETAT_FACTURE = 1 ORDER BY DATE_FACTURE ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        Dim adapter As New MySqlDataAdapter(command)
        Dim tableFacture As New DataTable()

        adapter.Fill(tableFacture)

        'Enfin on insere le tout dans notre datagrid
        If (tableFacture.Rows.Count > 0) Then

            GunaDataGridViewDetailsFacture.Columns.Clear()

            GunaDataGridViewDetailsFacture.DataSource = tableFacture

            GunaDataGridViewDetailsFacture.Columns(3).DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewDetailsFacture.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'Sorting the elements of situation client
            'GunaDataGridViewDetailsFactures.Sort(GunaDataGridViewDetailsFactures.Columns(1), ListSortDirection.Descending)

        End If

    End Sub

    'IMPRESSION FROM DETAILS
    Private Sub GunaButtonPrintFromDetails_Click(sender As Object, e As EventArgs) Handles GunaButtonPrintFromDetails.Click

        GlobalVariable.DocumentToGenerate = "facture"

        If GunaDataGridViewDetailsFacture.Rows.Count > 0 Then

            Functions.DocumentToPrint(GunaTextBoxFactureDeDetail.Text, "lign_facture", "CODE_FACTURE", GlobalVariable.codeClientToUpdate, GunaLabelNumReservation.Text)

        End If

    End Sub

    'DETAILS DE LA PRISE EN CHARGES

    Private Sub GunaCheckBoxGratuitee_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxGratuitee.CheckedChanged

        If GunaCheckBoxGratuitee.Checked Then
            GunaCheckBoxGratuiteInfo.Checked = True
            TabControlInfoClientSup.SelectedIndex = 3
        Else
            GunaCheckBoxGratuiteInfo.Checked = False
            TabControlInfoClientSup.SelectedIndex = 0
        End If

    End Sub


    Private Sub GunaCheckBoxGratuitee_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxGratuitee.Click

        If GunaCheckBoxGratuitee.Checked Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRATUITEE_HEBERGEMENT") = 1 Then

                    GunaCheckBoxGratuiteInfo.Checked = True
                    TabControlInfoClientSup.SelectedIndex = 3

                Else

                    GunaCheckBoxGratuitee.Checked = False

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Vous n'avez pas le droit necessaire pour effectuer une gratuitée", "Gestion de Gratuitée", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("You d'ont have the necessary right to make it free", "Free", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If

            Else
                GunaCheckBoxGratuiteInfo.Checked = False
            End If

        Else
            GunaCheckBoxGratuiteInfo.Checked = False
            TabControlInfoClientSup.SelectedIndex = 0
        End If


    End Sub



    Private Sub GunaCheckBoxGratuiteInfo_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxGratuiteInfo.CheckedChanged

        If GunaCheckBoxGratuiteInfo.Checked Then

            GunaLabelQuthoriseePar.Visible = True
            GunaTextBoxAuthoriseePar.Visible = True
            GunaLabelRemarque.Visible = True
            GunaTextBoxRemarque.Visible = True

        Else

            GunaTextBoxMontantAccorde.Text = GunaTextBoxpPrixAffiche.Text
            GunaLabelCodeTarif.Visible = False
            GunaComboBoxCodeTarif.Visible = False
            GunaLabelQuthoriseePar.Visible = False
            GunaTextBoxAuthoriseePar.Visible = False
            GunaLabelRemarque.Visible = False
            GunaTextBoxRemarque.Visible = False

            GunaTextBoxAuthoriseePar.Clear()
            GunaTextBoxRemarque.Clear()

        End If

    End Sub

    Private Sub GunaCheckBoxDejeuner_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxDejeuner.CheckedChanged

        If GunaCheckBoxDejeuner.Checked Then
            GunaTextBoxDejeuener.Visible = True
        Else
            GunaTextBoxDejeuener.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBoxLogement_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxLogement.CheckedChanged

        If GunaCheckBoxLogement.Checked Then
            GunaTextBoxLogement.Visible = True
        Else
            GunaTextBoxLogement.Visible = False
        End If

    End Sub

    Private Sub gestionDelaPriseEnChargeDeLaReservation(Optional ByVal CODE_RESERVATION As String = "")

        If Not Trim(CODE_RESERVATION) = "" Then 'SI LE CODE DE RESA EXISTE

            'MessageBox.Show(CODE_RESERVATION)

            'AFFICHAGE DES INFORMATION DE PRISSE EN CHARGE 
            'MAIS AVANT, 
            'ON RECHERCHE SI LA RESA EST INSCRITE DANS LA TABLE DES GRATUITEES
            Dim resaPriseEnCharge As DataTable = Functions.getElementByCode(CODE_RESERVATION, "prise_en_charge_resa", "CODE_RESERVATION")

            If resaPriseEnCharge.Rows.Count > 0 Then
                'SI OUI
                GunaCheckBoxLogement.Checked = True
                GunaTextBoxLogement.Text = Format(resaPriseEnCharge.Rows(0)("LOGEMENT"), "#,##0")

                GunaCheckBoxSalleConfFact.Checked = True
                GunaTextBoxSalleConfFact.Text = Format(resaPriseEnCharge.Rows(0)("SALLE_CONFERENCE"), "#,##0")

                GunaCheckBoxDejeuner.Checked = True
                GunaTextBoxDejeuener.Text = Format(resaPriseEnCharge.Rows(0)("DEJEUNER"), "#,##0")

                GunaCheckBoxDinner.Checked = True
                GunaTextBoxDinnerInstrucfact.Text = Format(resaPriseEnCharge.Rows(0)("DINER"), "#,##0")

                GunaCheckBoxPDJFact.Checked = True
                GunaTextBoxPDJInstruc.Text = Format(resaPriseEnCharge.Rows(0)("PETIT_DEJEUNER"), "#,##0")

                GunaCheckBoxBoisson.Checked = True
                GunaTextBoxBoissonFact.Text = Format(resaPriseEnCharge.Rows(0)("BOISSONS"), "#,##0")

                GunaCheckBoxNavette.Checked = True
                GunaTextBoxNavetteVal.Text = Format(resaPriseEnCharge.Rows(0)("NAVETTE"), "#,##0")

                GunaCheckBoxBlanchisserieFact.Checked = True
                GunaTextBoxBlanchFact.Text = Format(resaPriseEnCharge.Rows(0)("BLANCHISSERIE"), "#,##0")

            End If

        Else

            'INSERTION DES INFORMATIONS DE PRISSE EN CHARGE 

            If GunaTextBoxLogement.Text = "" Then
                GunaTextBoxLogement.Text = 0
            End If

            If GunaTextBoxSalleConfFact.Text = "" Then
                GunaTextBoxSalleConfFact.Text = 0
            End If

            If GunaTextBoxDejeuener.Text = "" Then
                GunaTextBoxDejeuener.Text = 0
            End If

            If GunaTextBoxDinnerInstrucfact.Text = "" Then
                GunaTextBoxDinnerInstrucfact.Text = 0
            End If

            If GunaTextBoxPDJInstruc.Text = "" Then
                GunaTextBoxPDJInstruc.Text = 0
            End If

            If GunaTextBoxBoissonFact.Text = "" Then
                GunaTextBoxBoissonFact.Text = 0
            End If

            If GunaTextBoxNavetteVal.Text = "" Then
                GunaTextBoxNavetteVal.Text = 0
            End If

            If GunaTextBoxBlanchFact.Text = "" Then
                GunaTextBoxBlanchFact.Text = 0
            End If

            If Not Trim(GunaTextBoxBC.Text) = "" Then

                Dim PETIT_DEJEUNER As Double = Double.Parse(GunaTextBoxPDJInstruc.Text)
                Dim DEJEUNER As Double = Double.Parse(GunaTextBoxDejeuener.Text)
                Dim DINER As Double = Double.Parse(GunaTextBoxDinnerInstrucfact.Text)
                Dim LOGEMENT As Double = Double.Parse(GunaTextBoxLogement.Text)
                Dim BOISSONS As Double = Double.Parse(GunaTextBoxBoissonFact.Text)
                Dim NAVETTE As Double = Double.Parse(GunaTextBoxNavetteVal.Text)
                Dim BLANCHISSERIE As Double = Double.Parse(GunaTextBoxBlanchFact.Text)
                Dim SALLE_CONFERENCE As Double = Double.Parse(GunaTextBoxSalleConfFact.Text)
                Dim CODE_RESERVATION_NEW As String = GunaLabelNumReservation.Text

                Dim AUTHORISATION As String = ""
                Dim REMARQUE As String = ""

                Dim DATE_PRISE_EN_CHARGE As Date = GlobalVariable.DateDeTravail
                Dim TABLE As String = "prise_en_charge_resa"

                Dim reservation As New Reservation()

                'PERMET LA MISE A JOURS EN CAS D'EXITENCE SINON NOUVELLE AJOUT
                Functions.DeleteElementByCode(CODE_RESERVATION_NEW, TABLE, "CODE_RESERVATION")

                reservation.insertionInformationPriseEnChargeResa(PETIT_DEJEUNER, DEJEUNER, DINER, LOGEMENT, BOISSONS, NAVETTE, BLANCHISSERIE, SALLE_CONFERENCE, CODE_RESERVATION_NEW, DATE_PRISE_EN_CHARGE, TABLE, AUTHORISATION, REMARQUE)

                'EFFACEMENT DES CHAMPS APRES INSERTION
                nettoyageDesInfoPriseEnCharge()

            End If

        End If

    End Sub

    Public Sub nettoyageDesInfoPriseEnCharge()

        GunaTextBoxLogement.Text = 0
        GunaTextBoxSalleConfFact.Text = 0
        GunaTextBoxDejeuener.Text = 0
        GunaTextBoxDinnerInstrucfact.Text = 0
        GunaTextBoxPDJInstruc.Text = 0
        GunaTextBoxBoissonFact.Text = 0
        GunaTextBoxNavetteVal.Text = 0
        GunaTextBoxBlanchFact.Text = 0

        GunaCheckBoxLogement.Checked = False
        GunaCheckBoxDejeuner.Checked = False
        GunaCheckBoxPDJFact.Checked = False
        GunaCheckBoxDinner.Checked = False
        GunaCheckBoxBoisson.Checked = False
        GunaCheckBoxNavette.Checked = False
        GunaCheckBoxBlanchisserieFact.Checked = False
        GunaCheckBoxSalleConfFact.Checked = False


    End Sub

    Public Sub nettoyageDesGratuitees()

        GunaTextBoxLogementGrat.Text = 0
        GunaTextBoxSalleConfGrat.Text = 0
        GunaTextBoxDejeunerGrat.Text = 0
        GunaTextBoxDinerGrat.Text = 0
        GunaTextBoxPDJGrat.Text = 0
        GunaTextBoxBoissonGrat.Text = 0
        GunaTextBoxNavetteGrat.Text = 0
        GunaTextBoxBlanchiGrat.Text = 0

        GunaTextBoxAuthoriseePar.Clear()
        GunaTextBoxRemarque.Clear()

        GunaCheckBoxlogementGrat.Checked = False

        GunaCheckBox8.Checked = False
        GunaCheckBox6.Checked = False
        GunaCheckBox4.Checked = False
        GunaCheckBox7.Checked = False
        GunaCheckBox5.Checked = False
        GunaCheckBox3.Checked = False
        GunaCheckBox1.Checked = False

        GunaCheckBoxGratuitee.Checked = False

    End Sub

    Private Sub GunaCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxlogementGrat.CheckedChanged
        'LOGEMENT
        If GunaCheckBoxlogementGrat.Checked Then
            GunaTextBoxLogementGrat.Visible = True
        Else
            GunaTextBoxLogementGrat.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox8.CheckedChanged
        'PDJ
        If GunaCheckBox8.Checked Then
            GunaTextBoxPDJGrat.Visible = True
        Else
            GunaTextBoxPDJGrat.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox6.CheckedChanged
        'DEJEUNER
        If GunaCheckBox6.Checked Then
            GunaTextBoxDejeunerGrat.Visible = True
        Else
            GunaTextBoxDejeunerGrat.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox4.CheckedChanged

        'DINER
        If GunaCheckBox4.Checked Then
            GunaTextBoxDinerGrat.Visible = True
        Else
            GunaTextBoxDinerGrat.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox7.CheckedChanged
        'BOISSONS
        If GunaCheckBox7.Checked Then
            GunaTextBoxBoissonGrat.Visible = True
        Else
            GunaTextBoxBoissonGrat.Visible = False
        End If
    End Sub

    Private Sub GunaCheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox5.CheckedChanged
        'NAVETTE
        If GunaCheckBox5.Checked Then
            GunaTextBoxNavetteGrat.Visible = True
        Else
            GunaTextBoxNavetteGrat.Visible = False
        End If
    End Sub

    Private Sub GunaCheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox3.CheckedChanged
        'BLANCHISSERIE
        If GunaCheckBox3.Checked Then
            GunaTextBoxBlanchiGrat.Visible = True
        Else
            GunaTextBoxBlanchiGrat.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged
        'SALLE DE CONFERENCE
        If GunaCheckBox1.Checked Then
            GunaTextBoxSalleConfGrat.Visible = True
        Else
            GunaTextBoxSalleConfGrat.Visible = False
        End If

    End Sub

    'DETAILS DES GRATUITES

    Private Sub gestionDelaGratuiteeDeLaReservation(Optional ByVal CODE_RESERVATION As String = "")

        'AFFICHAGE OU MODIFICATION DES ELEMENTS PRIS EN CHARGES

        If Not Trim(CODE_RESERVATION) = "" Then 'SI LE CODE DE RESA EXISTE

            '1- AFFICHAGE DES ELEMENTS PRIS EN CHARGES

            'AFFICHAGE DES INFORMATION DE PRISSE EN CHARGE 
            'MAIS AVANT, 
            'ON RECHERCHE SI LA RESA EST INSCRITE DANS LA TABLE DES GRATUITEES
            Dim resaGratuitee As DataTable = Functions.getElementByCode(CODE_RESERVATION, "gratuitee_de_resa", "CODE_RESERVATION")

            If resaGratuitee.Rows.Count > 0 Then
                'SI OUI
                If resaGratuitee.Rows(0)("ETAT") = 1 Then
                    GunaCheckBoxGratuitee.Checked = True
                Else
                    GunaCheckBoxGratuitee.Checked = False
                End If

                If resaGratuitee.Rows(0)("ETAT") = 1 Then

                    GunaCheckBoxlogementGrat.Checked = True
                    GunaTextBoxLogementGrat.Text = Format(resaGratuitee.Rows(0)("LOGEMENT"), "#,##0")

                    GunaCheckBox1.Checked = True
                    GunaTextBoxSalleConfGrat.Text = Format(resaGratuitee.Rows(0)("SALLE_CONFERENCE"), "#,##0")

                    GunaCheckBox6.Checked = True
                    GunaTextBoxDejeunerGrat.Text = Format(resaGratuitee.Rows(0)("DEJEUNER"), "#,##0")

                    GunaCheckBox4.Checked = True
                    GunaTextBoxDinerGrat.Text = Format(resaGratuitee.Rows(0)("DINER"), "#,##0")

                    GunaCheckBox8.Checked = True
                    GunaTextBoxPDJGrat.Text = Format(resaGratuitee.Rows(0)("PETIT_DEJEUNER"), "#,##0")

                    GunaCheckBox7.Checked = True
                    GunaTextBoxBoissonGrat.Text = Format(resaGratuitee.Rows(0)("BOISSONS"), "#,##0")

                    GunaCheckBox5.Checked = True
                    GunaTextBoxNavetteGrat.Text = Format(resaGratuitee.Rows(0)("NAVETTE"), "#,##0")

                    GunaCheckBox3.Checked = True
                    GunaTextBoxBlanchiGrat.Text = Format(resaGratuitee.Rows(0)("BLANCHISSERIE"), "#,##0")

                    GunaTextBoxAuthoriseePar.Text = resaGratuitee.Rows(0)("AUTHORISATION")

                    GunaTextBoxRemarque.Text = resaGratuitee.Rows(0)("REMARQUE")

                    affectationDuPrixDelaGratuiteeDeLaReservation()

                End If

            End If

        Else

            '2- INSERTION DES MONTANTS DES ELEMENTS PRIS EN CHARGES

            'INSERTION DES INFORMATIONS DE PRISSE EN CHARGE 
            If GunaTextBoxLogementGrat.Text = "" Then
                GunaTextBoxLogementGrat.Text = 0
            End If

            If GunaTextBoxSalleConfGrat.Text = "" Then
                GunaTextBoxSalleConfGrat.Text = 0
            End If

            If GunaTextBoxDejeunerGrat.Text = "" Then
                GunaTextBoxDejeunerGrat.Text = 0
            End If

            If GunaTextBoxDinerGrat.Text = "" Then
                GunaTextBoxDinerGrat.Text = 0
            End If

            If GunaTextBoxPDJGrat.Text = "" Then
                GunaTextBoxPDJGrat.Text = 0
            End If

            If GunaTextBoxBoissonGrat.Text = "" Then
                GunaTextBoxBoissonGrat.Text = 0
            End If

            If GunaTextBoxNavetteGrat.Text = "" Then
                GunaTextBoxNavetteGrat.Text = 0
            End If

            If GunaTextBoxBlanchiGrat.Text = "" Then
                GunaTextBoxBlanchiGrat.Text = 0
            End If

            Dim ETAT As Integer = 0

            If GunaCheckBoxGratuitee.Checked Then

                ETAT = 1

                Dim PETIT_DEJEUNER As Double = Double.Parse(GunaTextBoxPDJGrat.Text)
                Dim DEJEUNER As Double = Double.Parse(GunaTextBoxDejeunerGrat.Text)
                Dim DINER As Double = Double.Parse(GunaTextBoxDinerGrat.Text)
                Dim LOGEMENT As Double = Double.Parse(GunaTextBoxLogementGrat.Text)
                Dim BOISSONS As Double = Double.Parse(GunaTextBoxBoissonGrat.Text)
                Dim NAVETTE As Double = Double.Parse(GunaTextBoxNavetteGrat.Text)
                Dim BLANCHISSERIE As Double = Double.Parse(GunaTextBoxBlanchiGrat.Text)
                Dim SALLE_CONFERENCE As Double = Double.Parse(GunaTextBoxSalleConfGrat.Text)
                Dim CODE_RESERVATION_NEW As String = GunaLabelNumReservation.Text

                Dim AUTHORISATION As String = GunaTextBoxAuthoriseePar.Text
                Dim REMARQUE As String = GunaTextBoxRemarque.Text

                Dim DATE_PRISE_EN_CHARGE As Date = GlobalVariable.DateDeTravail
                Dim TABLE As String = "gratuitee_de_resa" ' CONTIENT LE MONTANT DES ELEMETS PRIS EN CHARGES

                Dim reservation As New Reservation()

                'PERMET LA MISE A JOURS EN CAS D'EXITENCE SINON NOUVELLE AJOUT
                Functions.DeleteElementByCode(CODE_RESERVATION_NEW, TABLE, "CODE_RESERVATION")

                reservation.insertionInformationPriseEnChargeResa(PETIT_DEJEUNER, DEJEUNER, DINER, LOGEMENT, BOISSONS, NAVETTE, BLANCHISSERIE, SALLE_CONFERENCE, CODE_RESERVATION_NEW, DATE_PRISE_EN_CHARGE, TABLE, AUTHORISATION, REMARQUE, ETAT)

                'EFFACEMENT DES CHAMPS APRES INSERTION
                nettoyageDesGratuitees()

            End If

            Functions.updateOfFields("gratuitee_de_resa", "ETAT", ETAT, "CODE_RESERVATION", CODE_RESERVATION, 1)

        End If

    End Sub

    Private Sub affectationDuPrixDelaGratuiteeDeLaReservation()

        If GunaCheckBoxGratuitee.Checked Then

            Dim tarif As DataTable = Functions.getElementByCode("GRATUITEE", "tarif", "LIBELLE_TARIF")

            If tarif.Rows.Count > 0 Then

                If Trim(GunaTextBoxAuthoriseePar.Text).Equals("") Then

                    GunaTextBoxMontantAccorde.Text = GunaTextBoxpPrixAffiche.Text
                    GunaComboBoxCodeTarif.Visible = False
                    GunaLabelCodeTarif.Visible = False

                Else

                    GunaComboBoxCodeTarif.DataSource = tarif
                    GunaComboBoxCodeTarif.ValueMember = "CODE_TARIF"
                    GunaComboBoxCodeTarif.DisplayMember = "LIBELLE_TARIF"

                    GunaComboBoxCodeTarif.SelectedValue = tarif.Rows(0)("CODE_TARIF")

                    GunaComboBoxCodeTarif.Visible = True
                    GunaLabelCodeTarif.Visible = True
                    GunaTextBoxMontantAccorde.Text = 0

                End If

            End If

        Else

        End If

    End Sub

    Private Sub remplissageDelaGratuitee()

        If GunaCheckBoxGratuitee.Checked Then

            Dim tarif As DataTable = Functions.getElementByCode("GRATUITEE", "tarif", "LIBELLE_TARIF")

            If tarif.Rows.Count > 0 Then

                If Not Trim(GunaTextBoxAuthoriseePar.Text).Equals("") Then

                    GunaComboBoxCodeTarif.DataSource = tarif
                    GunaComboBoxCodeTarif.ValueMember = "CODE_TARIF"
                    GunaComboBoxCodeTarif.DisplayMember = "LIBELLE_TARIF"

                    GunaComboBoxCodeTarif.SelectedValue = tarif.Rows(0)("CODE_TARIF")

                    GunaComboBoxCodeTarif.Visible = True
                    GunaLabelCodeTarif.Visible = True
                    GunaTextBoxMontantAccorde.Text = 0

                Else
                    GunaTextBoxMontantAccorde.Text = GunaTextBoxpPrixAffiche.Text
                    GunaComboBoxCodeTarif.Visible = False
                    GunaLabelCodeTarif.Visible = False
                End If

            End If

        Else

        End If

    End Sub

    'AFFICHAGE DES INFORMATIONS DE GRATUITEES
    Private Sub GunaTextBoxAuthoriseePar_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxAuthoriseePar.TextChanged
        affectationDuPrixDelaGratuiteeDeLaReservation()
    End Sub

    '---------------------------------------------------------------

    Private Sub GunaTextBoxNbrePersonne_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNbrePersonne.TextChanged

        If GlobalVariable.typeChambreOuSalle = "salle" Then

            GunaTextBox35.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox30.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox25.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox13.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBoxQteGouter.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBoxCocktail.Text = GunaTextBoxNbrePersonne.Text

        End If

    End Sub


    Private Sub GunaTextBoxMateriel_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMateriel.TextChanged

        'Dim montantDeco As Double = 0

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBoxAutres_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxAutres.TextChanged

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'montanTotalDeLocationSalle(nombreDeJourTotal)
        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaCheckBoxVidOui_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxVidOui.CheckedChanged
        If GunaCheckBoxVidOui.Checked Then
            GunaCheckBoxVidNon.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxVidNon_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxVidNon.CheckedChanged
        If GunaCheckBoxVidNon.Checked Then
            GunaCheckBoxVidOui.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxSonoOui_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxSonoOui.CheckedChanged
        If GunaCheckBoxSonoOui.Checked Then
            GunaCheckBoxSonoNon.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxSonoNon_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxSonoNon.CheckedChanged
        If GunaCheckBoxSonoNon.Checked Then
            GunaCheckBoxSonoOui.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxCouvOui_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxCouvOui.CheckedChanged
        If GunaCheckBoxCouvOui.Checked Then
            GunaCheckBoxCouvNon.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxCouvNon_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxCouvNon.CheckedChanged
        If GunaCheckBoxCouvNon.Checked Then
            GunaCheckBoxCouvOui.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxTableOui_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTableOui.CheckedChanged
        If GunaCheckBoxTableOui.Checked Then
            GunaCheckBoxTableNon.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxTableNon_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTableNon.CheckedChanged
        If GunaCheckBoxTableNon.Checked Then
            GunaCheckBoxTableOui.Checked = False
        End If
    End Sub

    'CLOISONNEMENT
    Private Sub GunaCheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles GunaCheckBox2.CheckedChanged
        If GunaCheckBox2.Checked Then
            GunaCheckBox9.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox9.CheckedChanged
        If GunaCheckBox9.Checked Then
            GunaCheckBox2.Checked = False
        End If
    End Sub

    'AMENAGEMENT

    Private Sub GunaCheckBoxU_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxU.CheckedChanged

        If GunaCheckBoxU.Checked Then
            GunaCheckBoxEcole.Checked = False
            GunaCheckBoxTheatre.Checked = False
            GunaCheckBoxRectangle.Checked = False
            GunaCheckBoxCocktail.Checked = False
            GunaCheckBoxBanquet.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxEcole_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxEcole.CheckedChanged
        If GunaCheckBoxEcole.Checked Then
            GunaCheckBoxTheatre.Checked = False
            GunaCheckBoxRectangle.Checked = False
            GunaCheckBoxCocktail.Checked = False
            GunaCheckBoxBanquet.Checked = False
            GunaCheckBoxU.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTheatre.CheckedChanged
        If GunaCheckBoxTheatre.Checked Then
            GunaCheckBoxEcole.Checked = False
            GunaCheckBoxRectangle.Checked = False
            GunaCheckBoxCocktail.Checked = False
            GunaCheckBoxBanquet.Checked = False
            GunaCheckBoxU.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxRectangle.CheckedChanged
        If GunaCheckBoxRectangle.Checked Then
            GunaCheckBoxTheatre.Checked = False
            GunaCheckBoxEcole.Checked = False
            GunaCheckBoxCocktail.Checked = False
            GunaCheckBoxBanquet.Checked = False
            GunaCheckBoxU.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxCocktail.CheckedChanged
        If GunaCheckBoxCocktail.Checked Then
            GunaCheckBoxTheatre.Checked = False
            GunaCheckBoxRectangle.Checked = False
            GunaCheckBoxEcole.Checked = False
            GunaCheckBoxBanquet.Checked = False
            GunaCheckBoxU.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxBanquet.CheckedChanged
        If GunaCheckBoxBanquet.Checked Then
            GunaCheckBoxTheatre.Checked = False
            GunaCheckBoxRectangle.Checked = False
            GunaCheckBoxCocktail.Checked = False
            GunaCheckBoxEcole.Checked = False
            GunaCheckBoxU.Checked = False
        End If
    End Sub

    Private Sub GunaTextBoxPrixGouter_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPrixGouter.TextChanged

        If Trim(GunaTextBoxPrixGouter.Text) = "" Then
            GunaTextBoxPrixGouter.Text = 0
        End If

        If Trim(GunaTextBoxQteGouter.Text) = "" Then
            GunaTextBoxQteGouter.Text = 0
        End If

        GunaTextBoxPrixTotalGouter.Text = Format(Double.Parse(GunaTextBoxPrixGouter.Text) * Integer.Parse(GunaTextBoxQteGouter.Text), "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBoxCocktail_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCocktail.TextChanged

        If Trim(GunaTextBoxCocktail.Text) = "" Then
            GunaTextBoxCocktail.Text = 0
        End If

        If Trim(GunaTextBoxPUCocktail.Text) = "" Then
            GunaTextBoxPUCocktail.Text = 0
        End If

        GunaTextBoxTGouter.Text = Format(Double.Parse(GunaTextBoxPUCocktail.Text) * Integer.Parse(GunaTextBoxCocktail.Text), "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBox5_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPUCocktail.TextChanged

        If Trim(GunaTextBoxCocktail.Text) = "" Then
            GunaTextBoxCocktail.Text = 0
        End If

        If Trim(GunaTextBoxPUCocktail.Text) = "" Then
            GunaTextBoxPUCocktail.Text = 0
        End If

        GunaTextBoxTGouter.Text = Format(Double.Parse(GunaTextBoxPUCocktail.Text) * Integer.Parse(GunaTextBoxCocktail.Text), "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)

    End Sub

    Private Sub GunaTextBox60_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantEauPetiteBouteille.TextChanged

        If Trim(GunaTextBoxMontantEauPetiteBouteille.Text) = "" Then
            GunaTextBoxMontantEauPetiteBouteille.Text = 0
        End If

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")
        montanTotalDeLocationSalle(nombreDeJourTotal)

    End Sub

    Private Sub GunaTextBox62_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox62.TextChanged
        If Trim(GunaTextBox62.Text) = "" Then
            GunaTextBox62.Text = 0
        End If

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")

        montanTotalDeLocationSalle(nombreDeJourTotal)

    End Sub

    Private Sub GunaTextBox59_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox59.TextChanged
        If Trim(GunaTextBox59.Text) = "" Then
            GunaTextBox59.Text = 0
        End If

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")

        montanTotalDeLocationSalle(nombreDeJourTotal)

    End Sub

    Private Sub GunaTextBox64_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox64.TextChanged
        If Trim(GunaTextBox64.Text) = "" Then
            GunaTextBox64.Text = 0
        End If

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")

        montanTotalDeLocationSalle(nombreDeJourTotal)

    End Sub

    Private Sub GunaTextBox68_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox68.TextChanged
        If Trim(GunaTextBox68.Text) = "" Then
            GunaTextBox68.Text = 0
        End If

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBox61_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox61.TextChanged
        If Trim(GunaTextBox61.Text) = "" Then
            GunaTextBox61.Text = 0
        End If

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBox57_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox57.TextChanged
        If Trim(GunaTextBox57.Text) = "" Then
            GunaTextBox57.Text = 0
        End If

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBoxDroitDeBouchon_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxDroitDeBouchon.TextChanged
        If Trim(GunaTextBoxDroitDeBouchon.Text) = "" Then
            GunaTextBoxDroitDeBouchon.Text = 0
        End If

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0

        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)

        montanTotalDeLocationSalle(nombreDeJourTotal)
    End Sub

    Private Sub GunaTextBoxGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxGrandTotal.TextChanged

        If GlobalVariable.typeChambreOuSalle = "salle" Then
            GunaTextBoxMontantGlobal.Text = GunaTextBoxGrandTotal.Text
        Else
            GunaTextBoxMontantGlobal.Text = 0
        End If

    End Sub

    '------------------------- GESTION DES DAY USES --------------------------------------------------------
    Private Sub GunaComboBoxHeureArrivee_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureArrivee.Click


        If GlobalVariable.actualLanguageValue = 1 Then
            TimePickerForm.GunaLabelTitreHeure.Text = "HEURE D'ARRIVEE"

        Else
            TimePickerForm.GunaLabelTitreHeure.Text = "ARRIVAL TIME"

        End If

        TimePickerForm.Show()
        TimePickerForm.Location = New Point(165, 250)
        TimePickerForm.TopMost = True

    End Sub

    Private Sub GunaComboBoxHeureDepart_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureDepart.Click

        If GlobalVariable.actualLanguageValue = 1 Then
            TimePickerForm.GunaLabelTitreHeure.Text = "HEURE DE DEPART"

        Else
            TimePickerForm.GunaLabelTitreHeure.Text = "DEPARTURE TIME"

        End If


        TimePickerForm.Show()
        TimePickerForm.Location = New Point(410, 250)
        TimePickerForm.TopMost = True

    End Sub

    Private Sub GunaTextBoxTotal_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTotal.TextChanged

        If GunaTextBoxTotal.Text = "" Then
            GunaTextBoxTotal.Text = 0
        End If

        If GunaTextBoxprixRepas.Text = "" Then
            GunaTextBoxprixRepas.Text = 0
        End If

        If GunaTextBoxTempsAFaire.Text = "" Then
            GunaTextBoxTempsAFaire.Text = 0
        End If

        If GunaTextBoxServiceEtProduitSup.Text = "" Then
            GunaTextBoxServiceEtProduitSup.Text = 0
        End If

        GunaTextBoxMontantARegler.Text = Format(Double.Parse(GunaTextBoxTotal.Text) + Double.Parse(GunaTextBoxprixRepas.Text) + Double.Parse(GunaTextBoxServiceEtProduitSup.Text), "#,##0")

    End Sub

    Private Sub GunaTextBoxprixRepas_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxprixRepas.TextChanged
        If GunaTextBoxTotal.Text = "" Then
            GunaTextBoxTotal.Text = 0
        End If

        If GunaTextBoxprixRepas.Text = "" Then
            GunaTextBoxprixRepas.Text = 0
        End If

        If GunaTextBoxTempsAFaire.Text = "" Then
            GunaTextBoxTempsAFaire.Text = 0
        End If

        If GunaTextBoxServiceEtProduitSup.Text = "" Then
            GunaTextBoxServiceEtProduitSup.Text = 0
        End If

        GunaTextBoxMontantARegler.Text = Format(Double.Parse(GunaTextBoxTotal.Text) + Double.Parse(GunaTextBoxprixRepas.Text) + Double.Parse(GunaTextBoxServiceEtProduitSup.Text), "#,##0")
    End Sub

    Private Sub GunaTextBoxServiceEtProduitSup_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxServiceEtProduitSup.TextChanged
        If GunaTextBoxTotal.Text = "" Then
            GunaTextBoxTotal.Text = 0
        End If

        If GunaTextBoxprixRepas.Text = "" Then
            GunaTextBoxprixRepas.Text = 0
        End If

        If GunaTextBoxTempsAFaire.Text = "" Then
            GunaTextBoxTempsAFaire.Text = 0
        End If

        If GunaTextBoxServiceEtProduitSup.Text = "" Then
            GunaTextBoxServiceEtProduitSup.Text = 0
        End If

        GunaTextBoxMontantARegler.Text = Format(Double.Parse(GunaTextBoxTotal.Text) + Double.Parse(GunaTextBoxprixRepas.Text) + Double.Parse(GunaTextBoxServiceEtProduitSup.Text), "#,##0")
    End Sub

    Private Sub GunaComboBoxHeureCafe_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureCafe.Click
        TimePickerForm.GunaLabelTitreHeure.Text = "HEURE PAUSE CAFE"
        If GlobalVariable.actualLanguageValue = 1 Then

        Else

        End If

        TimePickerForm.Show()
        TimePickerForm.Location = New Point(865, 374)
        TimePickerForm.TopMost = True
    End Sub

    Private Sub GunaComboBoxHeureDej_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureDej.Click
        TimePickerForm.GunaLabelTitreHeure.Text = "HEURE PAUSE DEJEUNER"
        If GlobalVariable.actualLanguageValue = 1 Then

        Else

        End If


        TimePickerForm.Show()
        TimePickerForm.Location = New Point(865, 400)
        TimePickerForm.TopMost = True
    End Sub

    Private Sub GunaComboBoxHeureDiner_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureDiner.Click
        TimePickerForm.GunaLabelTitreHeure.Text = "HEURE PAUSE DINER"

        If GlobalVariable.actualLanguageValue = 1 Then

        Else

        End If


        TimePickerForm.Show()
        TimePickerForm.Location = New Point(865, 426)
        TimePickerForm.TopMost = True
    End Sub

    Private Sub GunaComboBoxHeureGouter_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureGouter.Click
        TimePickerForm.GunaLabelTitreHeure.Text = "HEURE DU GOUTER"

        If GlobalVariable.actualLanguageValue = 1 Then

        Else

        End If

        TimePickerForm.Show()
        TimePickerForm.Location = New Point(865, 478)
        TimePickerForm.TopMost = True
    End Sub

    Private Sub GunaComboBoxHeureCocktail_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureCocktail.Click
        TimePickerForm.GunaLabelTitreHeure.Text = "HEURE DU COCKTAIL"

        If GlobalVariable.actualLanguageValue = 1 Then

        Else

        End If

        TimePickerForm.Show()
        TimePickerForm.Location = New Point(865, 503)
        TimePickerForm.TopMost = True
    End Sub

    Private Sub GunaTextBoxClientEmail_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxClientEmail.TextChanged
        GunaTextBox17.Text = GunaTextBoxClientEmail.Text

        If Trim(GunaTextBoxClientEmail.Text).Equals("") Then
            GunaRadioButtonEmailNon.Checked = True
        Else
            If GunaTextBoxClientEmail.Text.Length <= 10 Then
                GunaRadioButtonEmailNon.Checked = True
            End If
        End If

    End Sub

    Private Sub GunaTextBoxBC_validated(sender As Object, e As EventArgs) Handles GunaTextBoxBC.Validated

        If Trim(GunaTextBoxBC.Text) = "" Then
            TabControlInfoClientSup.SelectedIndex = 0
        Else
            TabControlInfoClientSup.SelectedIndex = 2
        End If

    End Sub


    'RECUPERATION PRIX DE LA RESERVATION DANS UN FICHIER TEXT

    Private Sub GunaButtonTarifAppliquable_Click(sender As Object, e As EventArgs) Handles GunaButtonTarifAppliquable.Click

        TarificationDeReservationForm.Show()
        TarificationDeReservationForm.TopMost = True

    End Sub

    Private Sub GunaButtonPreference_Click(sender As Object, e As EventArgs) Handles GunaButtonPreference.Click

        If Not Trim(GunaTextBoxRefClient.Text).Equals("") Then

            If Not Trim(GunaTextBoxNomPrenom.Text).Equals("") Then

                PreferenceDuClientForm.Show()
                PreferenceDuClientForm.TopMost = True

                PreferenceDuClientForm.GunaLabelNomDuClient.Text = Trim(GunaTextBoxNomPrenom.Text)

            End If

        Else
            ClientForm.Show()
            ClientForm.TopMost = True

            historiqueApartirDuCardex()

            ClientForm.TabControl1.SelectedIndex = 3
        End If

    End Sub

    Private Sub GunaButton18_Click(sender As Object, e As EventArgs) Handles GunaButtonFactures.Click

        ClientForm.Show()
        ClientForm.TopMost = True

        historiqueApartirDuCardex()

        ClientForm.TabControl1.SelectedIndex = 2
        ClientForm.TabControl2.SelectedIndex = 0

    End Sub

    Private Sub GunaButtonSejours_Click(sender As Object, e As EventArgs) Handles GunaButtonSejours.Click

        ClientForm.Show()
        ClientForm.TopMost = True

        historiqueApartirDuCardex()

        ClientForm.TabControl1.SelectedIndex = 2
        ClientForm.TabControl2.SelectedIndex = 1

    End Sub

    '------------------------ GESTION TIME PICKER ----------------------------------------------------------

    'HISTORIQUES A PARTIR DU CARDEX

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

        'On rempli la description du client pour des eventuelles modifications

        Dim CodeClient As String = GunaTextBoxRefClient.Text
        ClientForm.GunaTextBoxCodeClient.Text = GunaTextBoxRefClient.Text

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

                If client.Rows(0)("TYPE_CLIENT").Equals("INDIVIDUEL") Or client.Rows(0)("TYPE_CLIENT").Equals("INDIVIDUAL") Then
                    ClientForm.GunaComboBoxTypeDeFiltre.SelectedIndex = 0
                ElseIf client.Rows(0)("TYPE_CLIENT").Equals("ENTREPRISE") Or client.Rows(0)("TYPE_CLIENT").Equals("COMPANY") Then
                    ClientForm.GunaComboBoxTypeDeFiltre.SelectedIndex = 1
                End If

                Functions.AffectingTitleToAForm(ClientForm.GunaTextBoxNomRaisonSociale.Text + " " + ClientForm.GunaTextBoxPrenom.Text, ClientForm.GunaLabelTitreForm)

                'AssignACompanyToClient()

                'ONT CHARGENT LES DONNEES DES TARIF DU CLIENT

                Dim tarifs As New Tarifs

                ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Clear()

                If tarifs.SelectionDesForfaitsDuClient(client.Rows(0)("CODE_CLIENT")).Rows.Count > 0 Then
                    ClientForm.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.DataSource = tarifs.SelectionDesForfaitsDuClient(client.Rows(0)("CODE_CLIENT"))
                End If

                If ClientForm.GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or ClientForm.GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Then

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


            If GlobalVariable.actualLanguageValue = 1 Then
                ClientForm.GunaButtonEnregistrerClient.Text = "Sauvegarder"

            Else
                ClientForm.GunaButtonEnregistrerClient.Text = "Update"

            End If

        Else
            ClientForm.GunaComboBoxTypeDeFiltre.SelectedIndex = 2
        End If

        ClientForm.GunaComboBoxTypeDeFiltre.Enabled = False

    End Sub

    Private Sub GunaButtonCoChambrier_Click(sender As Object, e As EventArgs) Handles GunaButtonCoChambrier.Click

        CoChambrierForm.Show()
        CoChambrierForm.TopMost = True

    End Sub

    Private Sub GunaComboBoxFiltre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxFiltre.SelectedIndexChanged

        If GunaComboBoxFiltre.SelectedIndex >= 0 Then
            GunaCheckBoxUtiliserFiltre.Checked = False
        Else
            GunaCheckBoxUtiliserFiltre.Checked = True
        End If

    End Sub

    Private Sub GunaCheckBoxUtiliserFiltre_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxUtiliserFiltre.CheckedChanged

        If GunaCheckBoxUtiliserFiltre.Checked Then
            If GunaComboBoxFiltre.SelectedIndex >= 0 Then
                GunaComboBoxFiltre.SelectedIndex = -1
            End If
        End If

    End Sub

    Private Sub GunaCheckBoxDateFictive_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDateFictive.Click

        If GunaCheckBoxDateFictive.Checked Then
            GunaDateTimePickerDateDeTravailFictif.Visible = True
            GlobalVariable.DateDeTravail = GunaDateTimePickerDateDeTravailFictif.Value.ToShortDateString
        Else
            GunaDateTimePickerDateDeTravailFictif.Visible = False
            GlobalVariable.DateDeTravail = Functions.ObtenirDateDeTravail()
            GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail
        End If

    End Sub

    Private Sub GunaDateTimePickerDateDeTravailFictif_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDateDeTravailFictif.ValueChanged

        If GunaCheckBoxDateFictive.Checked Then
            GunaDateTimePickerDateDeTravailFictif.Visible = True
            GlobalVariable.DateDeTravail = GunaDateTimePickerDateDeTravailFictif.Value.ToShortDateString
            GunaDateTimePickerArrivee.Value = GlobalVariable.DateDeTravail
        End If

    End Sub

    Private Sub GunaComboBoxHeureNavette_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureDepartNavette.Click
        TimePickerForm.GunaLabelTitreHeure.Text = "HEURE DE DEPART NAVETTE"

        If GlobalVariable.actualLanguageValue = 1 Then

        Else

        End If

        TimePickerForm.Show()
        TimePickerForm.Location = New Point(300, 200)
        TimePickerForm.TopMost = True
    End Sub

    Private Sub GunaComboBox6_Click(sender As Object, e As EventArgs) Handles GunaComboBoxHeureNavetteArrivee.Click
        TimePickerForm.GunaLabelTitreHeure.Text = "HEURE D'ARRIVER NAVETTE"

        If GlobalVariable.actualLanguageValue = 1 Then

        Else

        End If

        TimePickerForm.Show()
        TimePickerForm.Location = New Point(300, 200)
        TimePickerForm.TopMost = True
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxLieuDepart.SelectedIndexChanged

        If GunaComboBoxLieuDepart.SelectedIndex = 2 Then
            GunaTextBox8.Visible = True
        Else
            GunaTextBox8.Visible = False
        End If

    End Sub

    Private Sub GunaComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxLieuArrive.SelectedIndexChanged

        If GunaComboBoxLieuArrive.SelectedIndex = 2 Then
            GunaTextBox6.Visible = True
        Else
            GunaTextBox6.Visible = False
        End If

    End Sub

    Private Sub masquerPickOffNavette(ByVal type As Integer)

        If type = 2 Or type = 3 Then

            'GunaLabel152.Visible = False
            'GunaComboBoxLieuArrive.Visible = False
            'GunaTextBox6.Visible = False
            GunaDateTimePicker2.Visible = True
            GunaComboBoxHeureNavetteArrivee.Visible = True

            If type = 2 Then
                GunaLabel151.Text = "Compagnie"
                If GlobalVariable.actualLanguageValue = 1 Then

                Else

                End If
                GunaTextBoxVol.Visible = True
                GunaLabel164.Visible = True
            Else
                GunaLabel151.Text = "Comment"
                If GlobalVariable.actualLanguageValue = 1 Then

                Else

                End If
                GunaTextBoxVol.Visible = False
                GunaLabel164.Visible = False
            End If

        Else

            GunaTextBoxVol.Visible = True
            GunaLabel164.Visible = True
            GunaLabel151.Text = "Comment"
            If GlobalVariable.actualLanguageValue = 1 Then

            Else

            End If
            'GunaLabel152.Visible = True
            'GunaComboBoxLieuArrive.Visible = True
            GunaDateTimePicker2.Visible = False
            GunaComboBoxHeureNavetteArrivee.Visible = False

        End If

    End Sub

    Private Sub gestionDesNavettes(ByVal operation As Integer, ByVal CODE_RESERVATION As String)

        Dim resa As New Reservation()

        Dim COMPANIE As String = GunaTextBoxCompagnie.Text
        Dim VOL As String = GunaTextBoxVol.Text

        Dim TYPE_DE_TRAJET As String = ""
        Dim INDEX_TYPE_DE_TRAJET As Integer = 0

        If GunaComboBoxTypeDeTrajet.SelectedIndex >= 0 Then
            TYPE_DE_TRAJET = GunaComboBoxTypeDeTrajet.SelectedItem
            INDEX_TYPE_DE_TRAJET = GunaComboBoxTypeDeTrajet.SelectedIndex
        End If

        Dim NBRE_PERSONNE As Integer = 0

        If Not Trim(GunaTextBox34.Text).Equals("") Then
            NBRE_PERSONNE = GunaTextBox34.Text
        End If

        Dim DEPART As String = ""
        Dim AUTRE_DEPART As String = ""
        Dim DATE_DEPART As Date
        Dim HEURE_DEPART As String = ""

        If GunaComboBoxLieuDepart.SelectedIndex >= 0 Then

            DEPART = GunaComboBoxLieuDepart.SelectedItem

            AUTRE_DEPART = GunaTextBox8.Text

            DATE_DEPART = GunaDateTimePicker1.Value.ToShortDateString()

            If GunaComboBoxHeureDepartNavette.Items.Count > 0 Then
                HEURE_DEPART = GunaComboBoxHeureDepartNavette.SelectedItem
            End If

        End If

        Dim ARRIVER As String = ""
        Dim AUTRE_ARRIVE As String = ""
        Dim HEURE_ARRIVEE As String = ""
        Dim DATE_ARRIVEE As Date

        If GunaComboBoxLieuArrive.SelectedIndex >= 0 Then

            ARRIVER = GunaComboBoxLieuArrive.SelectedItem

            AUTRE_ARRIVE = GunaTextBox6.Text

            If INDEX_TYPE_DE_TRAJET = 2 Or INDEX_TYPE_DE_TRAJET = 3 Then
                DATE_ARRIVEE = GunaDateTimePicker2.Value.ToShortDateString()

                If GunaComboBoxHeureNavetteArrivee.Items.Count > 0 Then
                    HEURE_ARRIVEE = GunaComboBoxHeureNavetteArrivee.SelectedItem
                End If
            End If

        End If

        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail.ToShortDateString()

        If operation = 0 Then 'INSERTION DANS LA BASE DE DONNEE

            If Not Trim(COMPANIE).Equals("") Then

                resa.insertionDesNavettes(CODE_RESERVATION, COMPANIE, VOL, TYPE_DE_TRAJET, NBRE_PERSONNE, DEPART, AUTRE_DEPART, ARRIVER, AUTRE_ARRIVE, DATE_DEPART, HEURE_ARRIVEE, DATE_ARRIVEE, HEURE_DEPART, DATE_CREATION)

                GunaComboBoxLieuArrive.SelectedIndex = -1
                GunaComboBoxLieuDepart.SelectedIndex = -1
                GunaComboBoxTypeDeTrajet.SelectedIndex = -1
                GunaComboBoxHeureNavetteArrivee.SelectedIndex = -1
                GunaComboBoxHeureDepartNavette.SelectedIndex = -1

            End If

        ElseIf operation = 1 Then 'MISE A JOURS DE LA BASE DE DONNEE

            If Not Trim(COMPANIE).Equals("") Then

                Dim infoSupNavette As DataTable = Functions.getElementByCode(CODE_RESERVATION, "navette", "CODE_RESERVATION")

                If infoSupNavette.Rows.Count > 0 Then

                    resa.UpdateDesNavettes(CODE_RESERVATION, COMPANIE, VOL, TYPE_DE_TRAJET, NBRE_PERSONNE, DEPART, AUTRE_DEPART, ARRIVER, AUTRE_ARRIVE, DATE_DEPART, HEURE_ARRIVEE, DATE_ARRIVEE, HEURE_DEPART, DATE_CREATION)

                    GunaComboBoxLieuArrive.SelectedIndex = -1
                    GunaComboBoxLieuDepart.SelectedIndex = -1
                    GunaComboBoxTypeDeTrajet.SelectedIndex = -1
                    GunaComboBoxHeureNavetteArrivee.SelectedIndex = -1
                    GunaComboBoxHeureDepartNavette.SelectedIndex = -1

                Else

                    resa.insertionDesNavettes(CODE_RESERVATION, COMPANIE, VOL, TYPE_DE_TRAJET, NBRE_PERSONNE, DEPART, AUTRE_DEPART, ARRIVER, AUTRE_ARRIVE, DATE_DEPART, HEURE_ARRIVEE, DATE_ARRIVEE, HEURE_DEPART, DATE_CREATION)

                    GunaComboBoxLieuArrive.SelectedIndex = -1
                    GunaComboBoxLieuDepart.SelectedIndex = -1
                    GunaComboBoxTypeDeTrajet.SelectedIndex = -1
                    GunaComboBoxHeureNavetteArrivee.SelectedIndex = -1
                    GunaComboBoxHeureDepartNavette.SelectedIndex = -1

                    GunaLabelNbreDeNavette.Text = "(" & Functions.alerteNavette() & ")"

                End If


            End If

        ElseIf operation = 2 Then 'AFFICHAGE DES INFORMATION DE LA NAVETTE

            Dim infoSupNavette As DataTable = Functions.getElementByCode(CODE_RESERVATION, "navette", "CODE_RESERVATION")

            If infoSupNavette.Rows.Count > 0 Then

                GunaTextBoxCompagnie.Text = infoSupNavette.Rows(0)("COMPANIE")
                GunaTextBoxVol.Text = infoSupNavette.Rows(0)("VOL")
                GunaTextBox34.Text = infoSupNavette.Rows(0)("NBRE_PERSONNE")

                GunaComboBoxTypeDeTrajet.SelectedItem = infoSupNavette.Rows(0)("TYPE_DE_TRAJET")

                GunaComboBoxLieuDepart.SelectedItem = infoSupNavette.Rows(0)("DEPART")
                GunaTextBox8.Text = infoSupNavette.Rows(0)("AUTRE_DEPART")

                If infoSupNavette.Rows(0)("DATE_DEPART").ToShortDateString() <= GunaDateTimePicker1.MaxDate And infoSupNavette.Rows(0)("DATE_DEPART").ToShortDateString() >= GunaDateTimePicker1.MinDate Then
                    GunaDateTimePicker1.Value = infoSupNavette.Rows(0)("DATE_DEPART").ToShortDateString()
                Else
                    GunaDateTimePicker1.Value = GlobalVariable.DateDeTravail.ToShortDateString()
                End If

                GunaComboBoxHeureDepartNavette.Items.Clear()
                GunaComboBoxHeureDepartNavette.Items.Add(infoSupNavette.Rows(0)("HEURE_DEPART"))
                GunaComboBoxHeureDepartNavette.SelectedItem = infoSupNavette.Rows(0)("HEURE_DEPART")

                GunaComboBoxLieuArrive.SelectedItem = infoSupNavette.Rows(0)("ARRIVER")
                GunaTextBox6.Text = infoSupNavette.Rows(0)("AUTRE_ARRIVE")

                If infoSupNavette.Rows(0)("DATE_ARRIVEE").ToShortDateString() <= GunaDateTimePicker2.MaxDate And infoSupNavette.Rows(0)("DATE_ARRIVEE").ToShortDateString() >= GunaDateTimePicker2.MinDate Then
                    GunaDateTimePicker2.Value = infoSupNavette.Rows(0)("DATE_ARRIVEE").ToShortDateString()
                Else
                    GunaDateTimePicker2.Value = GlobalVariable.DateDeTravail.ToShortDateString()
                End If

                GunaComboBoxHeureNavetteArrivee.Items.Clear()
                GunaComboBoxHeureNavetteArrivee.Items.Add(infoSupNavette.Rows(0)("HEURE_ARRIVEE"))
                GunaComboBoxHeureNavetteArrivee.SelectedItem = infoSupNavette.Rows(0)("HEURE_ARRIVEE")

            End If

        End If

    End Sub

    Private Sub GunaButton25_Click(sender As Object, e As EventArgs) Handles GunaButton25.Click

    End Sub

    Private Sub GunaComboBoxTypeDeTrajet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeTrajet.SelectedIndexChanged

        masquerPickOffNavette(GunaComboBoxTypeDeTrajet.SelectedIndex)

    End Sub

    Private Sub GunaRadioButtonSalleFete_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonSalleFete.CheckedChanged


        GunaDataGridViewReservationList.Columns.Clear()

        setTableUsedForAutocompletionToFalse()

        GunaTextBoxNbreAdulte.Text = 0
        GunaTextBoxNbrePersonne.Text = GunaTextBoxNbreAdulte.Text

        GunaLabelSolde.Text = 0

        If GunaRadioButtonSalleFete.Checked Then

            GunaTextBoxSerendantA.Text = GlobalVariable.AgenceActuelle.Rows(0)("VILLE")

            GunaTextBoxNbrePersonne.Text = 0

            GunaTextBox35.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox30.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox25.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox13.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBoxQteGouter.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBoxCocktail.Text = GunaTextBoxNbrePersonne.Text

            GunaTextBoxNbrePersonne.BaseColor = Color.White
            GunaTextBoxNbrePersonne.Enabled = True

            GunaButtonPromo.Visible = False

            GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")

            nomDuLabelAAficher()

            GlobalVariable.typeChambreOuSalle = "salle"

            GunaCheckBoxPetitDejeuenerInclus.Visible = False
            GunaCheckBoxTaxeSejour.Visible = False

            emtptyRegistrationFields()


            GlobalVariable.typeChambreOuSalle = "salle"

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabel52.Text = "SALLES OCCUPEES DU : "
                TabPage3.Text = "Salle Occupée"
                If TabControlHbergement.SelectedIndex = 3 Then
                    TabControlHbergement.SelectedTab.Text = "Salle Occupée"
                    GunaFrontDeskLabel.Text = "SALLE(S) OCCUPEE(S)"
                End If

                If TabControlHbergement.SelectedIndex = 0 Then
                    GunaFrontDeskLabel.Text = "RESERVATION SALLE DE FETE"
                End If

                If TabControlHbergement.SelectedIndex = 1 Then
                    GunaFrontDeskLabel.Text = "RESERVATIONS"
                End If
            Else
                GunaLabel52.Text = "HALL OCCUPIED FROM : "
                TabPage3.Text = "Occupied Hall"
                If TabControlHbergement.SelectedIndex = 3 Then
                    TabControlHbergement.SelectedTab.Text = "Occupied Hall"
                    GunaFrontDeskLabel.Text = "OCCUPIED HALL(S)"
                End If

                If TabControlHbergement.SelectedIndex = 0 Then
                    GunaFrontDeskLabel.Text = "PARTY HALL BOOKING"
                End If

                If TabControlHbergement.SelectedIndex = 1 Then
                    GunaFrontDeskLabel.Text = "BOOKINGS"
                End If
            End If

            GunaRadioButtonSalleFete.Visible = True
            GunaComboBoxImpressionSalle.Visible = True

            GunaTextBoxSuperficie.Visible = True
            GunaButtonLectureDeCarte.Visible = False

            '----------------------------- LEFT TAB -----------------

            '------------------------------- DETAILS SALLE

            If GlobalVariable.actualLanguageValue = 1 Then

                GunaGroupBoxDetailChambre.Text = "Détails de la Salle"
                GunaLabelLibelleTypeChambreSalle.Text = "Type de Salle"
                GunaLabelNumeroChambre.Text = "Nom Salle"

                TabControlGestionReservation.SelectedIndex = 0

                GunaPanelSalleReservation.Visible = True
                GunaTextBoxCapacite.Visible = True


            Else

                GunaGroupBoxDetailChambre.Text = "Hall details"
                GunaLabelLibelleTypeChambreSalle.Text = "Hall Type"
                GunaLabelNumeroChambre.Text = "Hall Name"

                TabControlGestionReservation.SelectedIndex = 0

                GunaPanelSalleReservation.Visible = True
                GunaTextBoxCapacite.Visible = True

            End If

            valeurAZero()

            'ON CHARGE DYNAMIQUEMENT LA LISTE DES EVENEMENTS

            AutoLoadEventList()

            VidageDesChampsPourNouvelleReservation()

        End If

        GestionDesButtonDImpressionDesDocuments()

    End Sub

    Private Sub GunaRadioButtonWhatsAppOui_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonWhatsAppOui.CheckedChanged

        If GunaRadioButtonWhatsAppOui.Checked Then

            If Trim(GunaTextBoxTelClient.Text).Equals("") Or GunaTextBoxTelClient.Text.Length < 13 Then
                GunaRadioButtonWhatsAppOui.Checked = False
                GunaRadioButtonWhatsAppNon.Checked = True
            End If

        End If


    End Sub

    Private Sub GunaRadioButtonMailOui_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonMailOui.CheckedChanged

        If GunaRadioButtonMailOui.Checked Then


            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir saisir une adresse email valide", "Envoyer un document", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Pleas type in a valide email ", "Send document", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            If Trim(GunaTextBoxClientEmail.Text).Equals("") Then
                GunaRadioButtonEmailNon.Checked = True
            Else
                If GunaTextBoxClientEmail.Text.Length <= 10 Then
                    GunaRadioButtonEmailNon.Checked = True
                End If
            End If

        End If

    End Sub

    Private Sub EMAILToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EMAILToolStripMenuItem.Click

    End Sub

    Private Sub WHATSAPPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WHATSAPPToolStripMenuItem.Click

        GlobalVariable.DocumentToGenerate = "facture"


        Dim TELEPHONE As String = GlobalVariable.ClientToUpdate.Rows(0)("TELEPHONE")

        If Not Trim(TELEPHONE).Equals("") And TELEPHONE.Length >= 13 Then
            Dim args As ArgumentType = New ArgumentType()
            args.action = 6
            backGroundWorkerToCall(args)
        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Numéro de téléphone invalide", "Envoyer un document", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Invalid phone number ", "Send document", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        End If

    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork

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

    '-----------------------------------

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

    Private Sub BackgroundWorker16_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker16.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker17_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker17.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker18_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker18.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker19_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker19.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker20_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker20.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker21_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker21.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker22_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker22.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker23_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker23.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub


    Private Sub documentToBeSendUsingBackGroundWorker(ByVal args As ArgumentType)

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        ElseIf args.action = 1 Then
            'SALLE CONFIRMATION
            DocumentsGenerationClass.GenerationDeConfirmationReservation(args.CODE_RESERVATAION, args.NOM_PRENOM, args.ARRIVAL, args.DEPART, args.TEMP_A_FAIRE, args.TYPE_CHAMBRE, args.NUM_CHAMBRE, args.MONTANT_PAR_NUITEE, args.HEURE_ARRIVEE, args.HEURE_DEPART, args.TYPE_CHAMBRE_SALLE, args.EMAIL, args.TELEPHONE_CLIENT, args.WHATSAPP_OU_EMAIL)
        ElseIf args.action = 2 Then
            'DEVIS ESTIMATIF
            DocumentsGenerationClass.devisEstimatifDeSalleDeFete(args.CODE_RESERVATAION, args.NOM_PRENOM, args.ARRIVAL, args.DEPART, args.TEMP_A_FAIRE, args.TYPE_CHAMBRE, args.NUM_CHAMBRE, args.MONTANT_PAR_NUITEE, args.HEURE_ARRIVEE, args.HEURE_DEPART, args.TYPE_CHAMBRE_SALLE, args.EMAIL, args.TELEPHONE_CLIENT, args.WHATSAPP_OU_EMAIL)
        ElseIf args.action = 3 Then
            'CHAMBRE CONFIRMATION
            DocumentsGenerationClass.GenerationDeConfirmationReservation(args.CODE_RESERVATAION, args.NOM_PRENOM, args.ARRIVAL, args.DEPART, args.TEMP_A_FAIRE, args.TYPE_CHAMBRE, args.NUM_CHAMBRE, args.MONTANT_PAR_NUITEE, args.HEURE_ARRIVEE, args.HEURE_DEPART, args.TYPE_CHAMBRE_SALLE, args.EMAIL, args.TELEPHONE_CLIENT, args.WHATSAPP_OU_EMAIL)
        ElseIf args.action = 4 Then
            'FICHE DE POLICE
            DocumentsGenerationClass.GenerationDeFicheDePolice(args.CODE_RESERVATAION, args.NOM_PRENOM, args.ARRIVAL, args.DEPART, args.TEMP_A_FAIRE, args.TYPE_CHAMBRE, args.NUM_CHAMBRE, args.MONTANT_PAR_NUITEE, args.HEURE_ARRIVEE, args.HEURE_DEPART, args.TYPE_CHAMBRE_SALLE, args.EMAIL, args.WHATSAPP_OU_EMAIL)
        ElseIf args.action = 5 Then
            'CONTRAT DE LOCATION SALLE
            DocumentsGenerationClass.contratDeLocationDeSalleDeFete(args.CODE_RESERVATAION, args.NOM_PRENOM, args.ARRIVAL, args.DEPART, args.TEMP_A_FAIRE, args.TYPE_CHAMBRE, args.NUM_CHAMBRE, args.MONTANT_PAR_NUITEE, args.HEURE_ARRIVEE, args.HEURE_DEPART, args.TYPE_CHAMBRE_SALLE, args.EMAIL, args.TELEPHONE_CLIENT, args.WHATSAPP_OU_EMAIL)
        ElseIf args.action = 6 Or args.action = 7 Then

            Dim WHATSAPP_OU_EMAIL As Integer = 0

            If args.action = 7 Then
                WHATSAPP_OU_EMAIL = 1
            End If

            DocumentsGenerationClass.DocumentFactureToSend(GunaDataGridViewDesFactures.CurrentRow.Cells("CODE").Value.ToString, "lign_facture", "CODE_FACTURE", GlobalVariable.codeClientToUpdate, GunaLabelNumReservation.Text, WHATSAPP_OU_EMAIL)
        ElseIf args.action = 8 Or args.action = 9 Then

            Dim WHATSAPP_OU_EMAIL As Integer = 0

            If args.action = 9 Then
                WHATSAPP_OU_EMAIL = 1
            End If

            DocumentsGenerationClass.DocumentFactureToSend(GunaDataGridViewListeDesReglement.CurrentRow.Cells("CODE").Value.ToString, "reglement", "NUM_REGLEMENT", GlobalVariable.codeClientToUpdate, GunaLabelNumReservation.Text, WHATSAPP_OU_EMAIL)

        ElseIf args.action = 10 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        End If

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
        ElseIf Not BackgroundWorker16.IsBusy Then
            BackgroundWorker16.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker17.IsBusy Then
            BackgroundWorker17.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker18.IsBusy Then
            BackgroundWorker18.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker19.IsBusy Then
            BackgroundWorker19.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker20.IsBusy Then
            BackgroundWorker20.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker21.IsBusy Then
            BackgroundWorker21.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker22.IsBusy Then
            BackgroundWorker22.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker23.IsBusy Then
            BackgroundWorker23.RunWorkerAsync(args)
        End If

    End Sub

    Private Sub GunaButtonTraces_Click(sender As Object, e As EventArgs) Handles GunaButtonTraces.Click

        GlobalVariable.DocumentToGenerate = "MOUCHARDS"

        RapportFacturesForm.GunaTextBoxCodeResa.Text = GunaLabelNumReservation.Text
        RapportFacturesForm.GunaCheckBoxPropResa.Checked = False
        RapportFacturesForm.Show()
        RapportFacturesForm.TopMost = True

    End Sub

    Private Sub GunaCheckBoxReservationDeGroupe_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxReservationDeGroupe.CheckedChanged

        If Not Trim(GlobalVariable.codeReservationToUpdate).Equals("") Then
            If GunaCheckBoxReservationDeGroupe.Checked Then
                GunaButtonSynthese.Visible = True
            Else
                GunaButtonSynthese.Visible = False
            End If
        End If

    End Sub

    Private Sub GunaButtonSynthese_Click(sender As Object, e As EventArgs) Handles GunaButtonSynthese.Click

        FabricationDeProformaForm.Show()
        FabricationDeProformaForm.TopMost = True

    End Sub

    Private Sub GunaButtonHebergement_Click(sender As Object, e As EventArgs) Handles GunaButtonHebergement.Click

        FabricationDeProformaForm.Show()
        FabricationDeProformaForm.TopMost = True

    End Sub

    Private Sub GunaTextBoxCodeElite_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCodeElite.TextChanged

        If Trim(GunaTextBoxCodeElite.Text).Equals("") Then

            GunaLabelCodeTarif.Visible = False
            GunaComboBoxCodeEliteMember.Visible = False

            If GlobalVariable.typeChambreOuSalle = "chambre" Then
                GunaTextBoxMontantAccorde.Text = GunaTextBoxpPrixAffiche.Text
            Else
                GunaTextBoxMontantReelSalle.Text = GunaTextBoxMontantAfficherSalle.Text
            End If

        Else

            If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then
                gestionReductionClubElite()
            End If

        End If

    End Sub

    Public Sub gestionReductionClubElite()

        If Not Trim(GunaTextBoxCodeElite.Text).Equals("") Then

            Dim CODE_CLIENT As String = GunaTextBoxRefClient.Text
            Dim CODE_ELITE As String = GunaTextBoxCodeElite.Text
            Dim elite As New ClubElite()
            Dim dt As DataTable = elite.infoDuCodeElite(CODE_ELITE)

            Dim MEMBRE As String = ""

            If dt.Rows.Count > 0 Then

                MEMBRE = dt.Rows(0)("MEMBRE")
                GunaComboBoxCodeEliteMember.Visible = True
                GunaLabelCodeTarif.Visible = True
                GunaLabelCodeTarif.Text = "ELITE"
                GunaComboBoxCodeEliteMember.DataSource = Nothing
                GunaComboBoxCodeEliteMember.DataSource = dt
                GunaComboBoxCodeEliteMember.ValueMember = "TYPE_MEMBRE"
                GunaComboBoxCodeEliteMember.DisplayMember = "TYPE_MEMBRE"

                If GlobalVariable.ReservationToUpdate Is Nothing Then

                    Dim MONTANT_ACCORDE As Double = 0

                    If GlobalVariable.typeChambreOuSalle = "chambre" Then
                        If Not Trim(GunaTextBoxMontantAccorde.Text).Equals("") Then
                            MONTANT_ACCORDE = GunaTextBoxMontantAccorde.Text
                        End If
                    Else
                        If Not Trim(GunaTextBoxMontantReelSalle.Text).Equals("") Then
                            MONTANT_ACCORDE = GunaTextBoxMontantReelSalle.Text
                        End If
                    End If

                    Dim DISCOUNT As Double = MONTANT_ACCORDE - ((dt.Rows(0)("REDUCTION_ACCORDEE") / 100) * MONTANT_ACCORDE)

                    If GlobalVariable.typeChambreOuSalle = "chambre" Then
                        GunaTextBoxMontantAccorde.Text = Format(DISCOUNT, "#,##0")
                    Else
                        GunaTextBoxMontantReelSalle.Text = Format(DISCOUNT, "#,##0")
                    End If

                End If

                If MEMBRE = "SILVER" Then
                    GunaComboBoxCodeEliteMember.BaseColor = Color.Silver
                    GunaComboBoxCodeEliteMember.ForeColor = Color.White
                ElseIf MEMBRE = "GOLD" Then
                    GunaComboBoxCodeEliteMember.BaseColor = Color.Gold
                    GunaComboBoxCodeEliteMember.ForeColor = Color.White
                ElseIf MEMBRE = "PLATINUM" Then
                    GunaComboBoxCodeEliteMember.BaseColor = Color.DarkSlateGray
                    GunaComboBoxCodeEliteMember.ForeColor = Color.White
                End If

            End If

        End If

    End Sub

    Private Sub GunaAdvenceButton7_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton7.Click

        DepotGarantieForm.Show()
        DepotGarantieForm.TopMost = True
    End Sub

    Public Function prixHebergementAUtiliser(ByVal CODE_TYPE_CHAMBRE As String)

        If Not Trim(CODE_TYPE_CHAMBRE).Equals("") Then

            Dim type_chambre As DataTable = Functions.getElementByCode(CODE_TYPE_CHAMBRE, "type_chambre", "CODE_TYPE_CHAMBRE")

            If type_chambre.Rows.Count > 0 Then

                Dim prix As Double = 0

                If GunaCheckBoxDayUse.Checked Then
                    prix = type_chambre.Rows(0)("MONTANT_SIESTE")
                Else
                    prix = type_chambre.Rows(0)("PRIX")
                End If

                GunaTextBoxpPrixAffiche.Text = Format(Double.Parse(prix), "#,##0")
                GunaTextBoxMontantAccorde.Text = Format(Double.Parse(prix), "#,##0")

            End If

        End If

    End Function

    'ANNULATION DE RESERVATION
    Private Sub GunaButtonAnnulerReservation_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnulerResa.Click

        '-------------------------------- OCCUPATION CHAMBRE ------------------------------

        'On ne peut pas annuler si la reservation est asscociee a un depot de garatie ou un paiment

        Dim arrhes As Double = 0
        Dim solde As Double = 0

        If Not Trim(GunaTextBoxDepotDeGarantie.Text).Equals("") Then
            arrhes = GunaTextBoxDepotDeGarantie.Text
        End If

        If Not Trim(GunaLabelSolde.Text).Equals("") Then
            solde = GunaLabelSolde.Text
        End If

        Dim continuer As Boolean = True

        If arrhes > 0 Or solde > 0 Then
            continuer = False
        End If

        If continuer Then

            Dim CODE_OCCUPATION_CHAMBRE = Functions.GeneratingRandomCodeWithSpecifications("occupation_chambre", "")
            Dim MONTANT_HT As Double = 0

            If Not Trim(GunaTextBoxMontantAccorde.Text) = "" Then
                MONTANT_HT = Double.Parse(GunaTextBoxMontantAccorde.Text)
            End If

            Dim TAXE As Double = 0
            Dim MONTANT_TTC As Double = 0
            Dim DATE_OCCUPATION As Date = GunaDateTimePickerArrivee.Value.ToShortDateString()
            'Dim OBSERVATIONS As String =""
            Dim COMMENTAIRE1 As String = ""
            Dim COMMENTAIRE2 As String = ""
            Dim COMMENTAIRE3 As String = ""
            Dim COMMENTAIRE4 As String = ""
            Dim DATE_LIBERATION As Date = GunaDateTimePickerDepart.Value.ToShortDateString()
            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
            Dim DATE_PREMIERE_ARRIVEE As Date = GlobalVariable.DateDeTravail
            Dim TYPE_RESERVATION As String = GlobalVariable.typeChambreOuSalle
            Dim PDJ_INCLUS As String = ""
            Dim TAXE_SEJOURS_INCLUS As String = ""
            Dim TVA_INCLUS As String = ""
            Dim CODE_CLIENT_REEL As String = GunaTextBoxRefClient.Text
            Dim OBSERVATIONS As String = ""
            Dim CODE_CHAMBRE = GunaTextBoxNumeroChambre.Text
            Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            Dim STATUT_RESERVATION As String = ""

            If GlobalVariable.actualLanguageValue = 1 Then
                STATUT_RESERVATION = "ANNULEE"
            Else
                STATUT_RESERVATION = "CANCELED"
            End If


            Dim Reservation As New Reservation
            Dim occupationChambre As New OccupationChambre()
            Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate
            Dim dialog As DialogResult

            Dim dayDiff = CType((GlobalVariable.DateDeTravail - GunaDateTimePickerDepart.Value).TotalHours, Int32)

            If dayDiff >= 0 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Bien vouloir vérifier la date de départ", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Please check the departure date", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    dialog = MessageBox.Show("Voulez vous vraiment Annuler cette réservation ", "Annulation de réservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                Else
                    dialog = MessageBox.Show("Do you really want to cancel this booking ", "Booking cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                End If

                If dialog = DialogResult.No Then

                Else

                    Me.Cursor = Cursors.WaitCursor

                    'MOTIF ANNULATION
                    '----------------------------------------------
                    Dim motifDelogement As String = ""

                    If GlobalVariable.actualLanguageValue = 1 Then
                        motifDelogement = InputBox("ANNULATION ", "Motif de l'annulation", "")

                    Else
                        motifDelogement = InputBox("CANCELATION ", "Reason for canceling", "")

                    End If

                    OBSERVATIONS = motifDelogement

                    '------------------------------------------------
                    Dim ETAT_RESERVATION As Integer

                    'ANNULATION DE LA RESERVATION 
                    Dim reservationToUpdateInReservation As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reservation", "CODE_RESERVATION")

                    'SOIT DANS RESERVATION
                    If reservationToUpdateInReservation.Rows.Count > 0 Then

                        'ANNULATION DE LA RESERVATION
                        ETAT_RESERVATION = 2 'RESERVATION ANNULEE
                        Reservation.AnnulationDeReservation(CODE_RESERVATION, "reservation", ETAT_RESERVATION, STATUT_RESERVATION)

                    Else

                        'OU DANS RESERVATION
                        Dim reservationToUpdateInReserve_conf As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                        If reservationToUpdateInReserve_conf.Rows.Count > 0 Then

                            ETAT_RESERVATION = 2
                            '2 = RESERVATION ANNULEE; 1 = RESERVATION ABOUTI ; 0 = RESERVATION ANNULEE NORMALEMENT VIA UN CHECK OUT A LA BONNE DATE DE DEPART
                            'Reservation.AnnulationDeReservation(CODE_RESERVATION, "reserve_conf", ETAT_RESERVATION)

                        End If

                    End If

                    Dim ETAT_NOTE_RESERVATION As String = "ANNULEE"

                    If reservationToUpdateInReservation.Rows.Count > 0 Then

                        Dim ACTION_FAITE As String = GunaButtonAnnulerResa.Text
                        Dim FAITE_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

                        Dim CLIENT_ID = reservationToUpdateInReservation.Rows(0)("CLIENT_ID")
                        Dim UTILISATEUR_ID = reservationToUpdateInReservation.Rows(0)("UTILISATEUR_ID")
                        Dim CHAMBRE_ID = reservationToUpdateInReservation.Rows(0)("CHAMBRE_ID")
                        Dim AGENCE_ID = reservationToUpdateInReservation.Rows(0)("AGENCE_ID")
                        Dim NOM_CLIENT = reservationToUpdateInReservation.Rows(0)("NOM_CLIENT")
                        Dim DATE_ENTTRE = reservationToUpdateInReservation.Rows(0)("DATE_ENTTRE")
                        Dim HEURE_ENTREE = reservationToUpdateInReservation.Rows(0)("HEURE_ENTREE")
                        Dim DATE_SORTIE = reservationToUpdateInReservation.Rows(0)("DATE_SORTIE")
                        Dim HEURE_SORTIE = reservationToUpdateInReservation.Rows(0)("HEURE_SORTIE")
                        Dim ADULTES = reservationToUpdateInReservation.Rows(0)("ADULTES")
                        Dim NB_PERSONNES = reservationToUpdateInReservation.Rows(0)("NB_PERSONNES")
                        Dim ENFANTS = reservationToUpdateInReservation.Rows(0)("ENFANTS")
                        Dim RECEVOIR_EMAIL = reservationToUpdateInReservation.Rows(0)("RECEVOIR_EMAIL")
                        Dim RECEVOIR_SMS = reservationToUpdateInReservation.Rows(0)("RECEVOIR_SMS")
                        Dim DATE_CREATION = reservationToUpdateInReservation.Rows(0)("DATE_CREATION")
                        Dim HEURE_CREATION = reservationToUpdateInReservation.Rows(0)("HEURE_CREATION")
                        Dim MONTANT_TOTAL_CAUTION = reservationToUpdateInReservation.Rows(0)("MONTANT_TOTAL_CAUTION")
                        Dim MOTIF_ETAT = reservationToUpdateInReservation.Rows(0)("MOTIF_ETAT")
                        Dim DATE_ETAT = reservationToUpdateInReservation.Rows(0)("DATE_ETAT")
                        Dim MONTANT_ACCORDE = reservationToUpdateInReservation.Rows(0)("MONTANT_ACCORDE")
                        Dim GROUPE = reservationToUpdateInReservation.Rows(0)("GROUPE")
                        Dim DEPOT_DE_GARANTIE = reservationToUpdateInReservation.Rows(0)("DEPOT_DE_GARANTIE")
                        Dim DAY_USE = reservationToUpdateInReservation.Rows(0)("DAY_USE")
                        Dim MENSUEL = reservationToUpdateInReservation.Rows(0)("MENSUEL")
                        Dim HEBDOMADAIRE = reservationToUpdateInReservation.Rows(0)("HEBDOMADAIRE")
                        Dim BC_ENTREPRISE = reservationToUpdateInReservation.Rows(0)("BC_ENTREPRISE")
                        Dim TYPE_CHAMBRE = reservationToUpdateInReservation.Rows(0)("TYPE_CHAMBRE")
                        Dim TYPE_CHAMBRE_OU_SALLE = reservationToUpdateInReservation.Rows(0)("TYPE")
                        Dim PETIT_DEJEUNER_ROUTAGE = reservationToUpdateInReservation.Rows(0)("PETIT_DEJEUNER_ROUTAGE")
                        Dim CHAMBRE_ROUTAGE = reservationToUpdateInReservation.Rows(0)("CHAMBRE_ROUTAGE")
                        Dim VENANT_DE = reservationToUpdateInReservation.Rows(0)("VENANT_DE")
                        Dim SE_RENDANT_A = reservationToUpdateInReservation.Rows(0)("SE_RENDANT_A")
                        Dim RAISON = reservationToUpdateInReservation.Rows(0)("RAISON")
                        Dim SOURCE_RESERVATION = reservationToUpdateInReservation.Rows(0)("SOURCE_RESERVATION")
                        Dim ROUTAGE = reservationToUpdateInReservation.Rows(0)("ROUTAGE")
                        Dim CODE_ENTREPRISE = reservationToUpdateInReservation.Rows(0)("CODE_ENTREPRISE")
                        Dim NOM_ENTREPRISE = reservationToUpdateInReservation.Rows(0)("NOM_ENTREPRISE")

                        Reservation.insertTrace(CODE_RESERVATION, CLIENT_ID, UTILISATEUR_ID, CHAMBRE_ID, AGENCE_ID, NOM_CLIENT, DATE_ENTTRE, HEURE_ENTREE, DATE_SORTIE, HEURE_SORTIE, ADULTES, NB_PERSONNES, ENFANTS, RECEVOIR_EMAIL, RECEVOIR_SMS, ETAT_RESERVATION, DATE_CREATION, HEURE_CREATION, MONTANT_TOTAL_CAUTION, MOTIF_ETAT, DATE_ETAT, MONTANT_ACCORDE, GROUPE, DEPOT_DE_GARANTIE, DAY_USE, MENSUEL, HEBDOMADAIRE, BC_ENTREPRISE, TYPE_CHAMBRE, ACTION_FAITE, FAITE_PAR, TYPE_CHAMBRE_OU_SALLE, PETIT_DEJEUNER_ROUTAGE, CHAMBRE_ROUTAGE, VENANT_DE, SE_RENDANT_A, RAISON, SOURCE_RESERVATION, ROUTAGE, ETAT_NOTE_RESERVATION, CODE_ENTREPRISE, NOM_ENTREPRISE)

                    End If

                    '-------------------------------------- MOUCHARDS ---------------------------------------------------
                    Dim ACTION As String = ""

                    If GlobalVariable.actualLanguageValue = 1 Then
                        ACTION = "ANNULATION DE LA RESERVATION [CHAMBRE " & GunaTextBoxNumeroChambre.Text & " / " & GunaTextBoxNomPrenom.Text & "  MOTIF : " & OBSERVATIONS & "]"

                    Else
                        ACTION = "BOOKING CANCELATION [ROOM " & GunaTextBoxNumeroChambre.Text & " / " & GunaTextBoxNomPrenom.Text & "  REASON : " & OBSERVATIONS & "]"

                    End If

                    User.mouchard(ACTION)
                    '----------------------------------------------------------------------------------------------------

                    User.updateSuiviDesReservations("ANNULER_PAR", GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), CODE_RESERVATION)

                    'UPDATE THE ROOM
                    Dim updateQuery1 As String = "UPDATE `chambre` SET `ETAT_CHAMBRE`=@ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@code"

                    Dim command1 As New MySqlCommand(updateQuery1, GlobalVariable.connect)

                    command1.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int32).Value = 0
                    command1.Parameters.Add("@code", MySqlDbType.VarChar).Value = GlobalVariable.codeChambre
                    command1.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = GlobalVariable.libre_propre

                    If (command1.ExecuteNonQuery() = 1) Then
                        'connect.closeConnection()
                    End If

                    'trace de l'annulation de reservation 
                    Dim ETAT_CHAMBRE As Integer = 1

                    If occupationChambre.insertOccupationChambre(CODE_OCCUPATION_CHAMBRE, CODE_RESERVATION, CODE_CHAMBRE, MONTANT_HT, TAXE, MONTANT_TTC, DATE_OCCUPATION, ETAT_CHAMBRE, OBSERVATIONS, COMMENTAIRE1, COMMENTAIRE2, COMMENTAIRE3, COMMENTAIRE4, DATE_LIBERATION, CODE_UTILISATEUR_CREA, DATE_PREMIERE_ARRIVEE, TYPE_RESERVATION, PDJ_INCLUS, TAXE_SEJOURS_INCLUS, TVA_INCLUS, CODE_CLIENT_REEL, CODE_AGENCE) Then

                    End If

                    'ANNULATIIO DE RESERVATION MAINCOURANTE = 2
                    'MISE A JOURS DE LA MAIN COURANTE JOURNALIERE DE LA CHAMBRE ANNULEE

                    Dim updateQuery2 As String = "UPDATE `main_courante_journaliere` SET `ETAT_MAIN_COURANTE`=@ETAT_MAIN_COURANTE WHERE NUM_RESERVATION=@NUM_RESERVATION"

                    Dim command2 As New MySqlCommand(updateQuery2, GlobalVariable.connect)

                    command2.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 2
                    command2.Parameters.Add("@NUM_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

                    If (command2.ExecuteNonQuery() = 1) Then
                        'connect.closeConnection()
                    End If

                    'MISE A JOURS DE LA MAIN COURANTE GENERALE DE LA CHAMBRE ANNULEE

                    Dim updateQuery3 As String = "UPDATE `main_courante_generale` SET `ETAT_MAIN_COURANTE`=@ETAT_MAIN_COURANTE WHERE NUM_RESERVATION=@NUM_RESERVATION"

                    Dim command3 As New MySqlCommand(updateQuery3, GlobalVariable.connect)

                    command3.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 2
                    command3.Parameters.Add("@NUM_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

                    If (command3.ExecuteNonQuery() = 1) Then
                        'connect.closeConnection()
                    End If

                    Reservation.updateEtatReservationNote(CODE_RESERVATION, "reservation", ETAT_NOTE_RESERVATION)

                    'RSERVATION NORMALE

                    'Clearing all the informations found in the the reseravtion field
                    emtptyRegistrationFields()

                    'We set all the global variables used for update to their original values
                    Functions.EmtyGlobalVariablesContainingCodeToUpdate()

                    'Renitialisation des dates en plus de la date de travail après avoir vidé les variables globales
                    ReinitialisationDesDates()

                    Functions.SiplifiedClearTextBox(Me)

                    'On masque les tarifs associés au client si existe 
                    GunaComboBoxCodeTarif.Visible = False
                    GunaLabelCodeTarif.Visible = False

                    'Desactivation du bouton de gestion de groupe
                    GunaCheckBoxReservationDeGroupe.Checked = False

                    ReservationList("all", "none")

                    'Used to know which button to display among enregistrer, checkin, checkout, annuler
                    reservationButtonToDisplay()

                    GunaCheckBoxPetitDejeuenerInclus.Checked = False
                    GunaCheckBoxTaxeSejour.Checked = False
                    GunaTextBoxPetitDejeuner.Visible = False
                    GunaTextBoxPetitDejeunerRoutage.Visible = False


                    'Obtention des informations pour les statistiques
                    Dim stat As New statistiques()

                    stat.ObtenirDerniereStatistique()

                    Dim codeDelaDerniereStatistique As String = stat.ObtenirDerniereStatistique()

                    'DERNIER STATISTIQUE
                    GlobalVariable.informationDesStatistiques = Functions.getElementByCode(codeDelaDerniereStatistique, "statistiques", "CODE_STATISTIQUE")

                    GlobalVariable.entierAnnulation = -1

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Réservation annulée avec succès", "Annulation de Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Booking successfully canceled", "Booking cancelation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    GunaButtonCheckOut.Visible = False

                    GlobalVariable.entierAnnulation = 0

                    VidageDesChampsPourNouvelleReservation()

                    Me.Cursor = Cursors.Default

                End If

            End If

        Else

            Dim shortMessage As String = ""

            If arrhes > 0 Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    shortMessage = " , the reservation is associated to an arrhes"
                Else
                    shortMessage = " , la reservation est associée à un dépot de garantie"
                End If
            ElseIf solde > 0 Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    shortMessage = ", the reservation has a positif balance"
                Else
                    shortMessage = ", la reservation a un solde positif"
                End If
            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Impossible d'annuler" & shortMessage, "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Impossible to cancel" & shortMessage, "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub RestaurantBookingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GlobalVariable.typeChambreOuSalle = "salle"

        GunaPanelSalleReservation.Visible = True
        GunaPanelSalleReservation.Top = True

        VidageDesChampsPourNouvelleReservation()

        TabControlHbergement.SelectedIndex = 0

        GunaLabelNumReservation.Visible = True
        GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")

        Dim language As New Languages()
        language.receptionReservation(GlobalVariable.actualLanguageValue)

        If Not GlobalVariable.codeReservationToUpdate = "" Then
            LabelNatureReservation.Visible = True
        Else
            LabelNatureReservation.Visible = False
        End If

        'RAPPORT RECEPTION 
        '--------------------------------------------------------------------

        'Raison reservation business ou loisirs
        GunaComboBoxTypeReservation.SelectedIndex = 0 'Non confirmée

        'GunaTextBoxNumeroChambre.visible = True
        'Initialisation du nombre de personne
        GunaTextBoxNbreAdulte.Text = 0
        GunaTextBoxNbrePersonne.Text = GunaTextBoxNbreAdulte.Text

        'GlobalVariable.typeChambreOuSalle = "chambre"

        'IMPRESSION DES DOCS LIES AUX CHAMBRES OU SALLE
        If TabControlHbergement.SelectedIndex = 0 Then

            GunaComboBoxImpressionSalle.Visible = True

            ImprimerDocChambreSalle.Visible = True
            GunaButtonEnvoyer.Visible = True


        Else

            GunaComboBoxImpressionSalle.Visible = False
            ImprimerDocChambreSalle.Visible = False
            GunaButtonEnvoyer.Visible = False

        End If

        setTableUsedForAutocompletionToFalse()

        '--------------------------------------------- FRONT OFFICE PANNEL MANEGEMNT -------------------------------------------
        'We charge all the information concerning the agency into a variable that will be used trough out the programme
        'GlobalVariable.AgenceActuelle = Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("NUM_AGENCE"), "agence", "CODE_AGENCE")


        'Theme color
        If GlobalVariable.AgenceActuelle.Rows.Count > 0 Then

            GlobalVariable.codeAgence = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

            If Not GlobalVariable.AgenceActuelle.Rows(0)("VILLE") = "" Then
                GunaTextBoxSerendantA.Text = GlobalVariable.AgenceActuelle.Rows(0)("VILLE")
                GunaTextBoxVenantDe.Text = ""
            End If

            If GlobalVariable.AgenceActuelle.Rows(0)("TARIFICATION_DYNAMIQUE") = 1 Then
                GunaButtonTarifAppliquable.Visible = True
                GlobalVariable.tarificationDynamiqueActif = True
            ElseIf GlobalVariable.AgenceActuelle.Rows(0)("TARIFICATION_DYNAMIQUE") = 0 Then
                GunaButtonTarifAppliquable.Visible = False
                GlobalVariable.tarificationDynamiqueActif = False
            End If

        Else

        End If

        ''AutoLoad Room for routing
        'AutoLoadRoomForRouting()

        'Auload room source
        AutoLoadRoomReservationSource()

        Dim infoSupSource As DataTable

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then
                GunaCheckBoxDateFictive.Visible = True
            Else
                GunaCheckBoxDateFictive.Visible = False
            End If

        End If

        'affichageParDefautDesReservations()


        GunaDataGridViewReservationList.Columns.Clear()

        setTableUsedForAutocompletionToFalse()

        GunaTextBoxNbreAdulte.Text = 0
        GunaTextBoxNbrePersonne.Text = GunaTextBoxNbreAdulte.Text

        GunaLabelSolde.Text = 0

        If GunaRadioButtonSalleFete.Checked Then

            GunaTextBoxSerendantA.Text = GlobalVariable.AgenceActuelle.Rows(0)("VILLE")

            GunaTextBoxNbrePersonne.Text = 0

            GunaTextBox35.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox30.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox25.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBox13.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBoxQteGouter.Text = GunaTextBoxNbrePersonne.Text
            GunaTextBoxCocktail.Text = GunaTextBoxNbrePersonne.Text

            GunaTextBoxNbrePersonne.BaseColor = Color.White
            GunaTextBoxNbrePersonne.Enabled = True

            GunaButtonPromo.Visible = False

            GunaLabelNumReservation.Text = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")

            nomDuLabelAAficher()

            GlobalVariable.typeChambreOuSalle = "salle"

            GunaCheckBoxPetitDejeuenerInclus.Visible = False
            GunaCheckBoxTaxeSejour.Visible = False

            emtptyRegistrationFields()

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabel52.Text = "SALLES OCCUPEES DU : "
                TabPage3.Text = "Salle Occupée"
                If TabControlHbergement.SelectedIndex = 3 Then
                    TabControlHbergement.SelectedTab.Text = "Salle Occupée"
                    GunaFrontDeskLabel.Text = "SALLE(S) OCCUPEE(S)"
                End If

                If TabControlHbergement.SelectedIndex = 0 Then
                    GunaFrontDeskLabel.Text = "RESERVATION SALLE DE FETE"
                End If

                If TabControlHbergement.SelectedIndex = 1 Then
                    GunaFrontDeskLabel.Text = "RESERVATIONS"
                End If
            Else
                GunaLabel52.Text = "HALL OCCUPIED FROM : "
                TabPage3.Text = "Occupied Hall"
                If TabControlHbergement.SelectedIndex = 3 Then
                    TabControlHbergement.SelectedTab.Text = "Occupied Hall"
                    GunaFrontDeskLabel.Text = "OCCUPIED HALL(S)"
                End If

                If TabControlHbergement.SelectedIndex = 0 Then
                    GunaFrontDeskLabel.Text = "PARTY HALL BOOKING"
                End If

                If TabControlHbergement.SelectedIndex = 1 Then
                    GunaFrontDeskLabel.Text = "BOOKINGS"
                End If
            End If

            GunaRadioButtonSalleFete.Visible = True
            GunaComboBoxImpressionSalle.Visible = True

            GunaTextBoxSuperficie.Visible = True
            GunaButtonLectureDeCarte.Visible = False

            '----------------------------- LEFT TAB -----------------

            '------------------------------- DETAILS SALLE

            If GlobalVariable.actualLanguageValue = 1 Then

                GunaGroupBoxDetailChambre.Text = "Détails de la Salle"
                GunaLabelLibelleTypeChambreSalle.Text = "Type de Salle"
                GunaLabelNumeroChambre.Text = "Nom Salle"

                TabControlGestionReservation.SelectedIndex = 0

                GunaPanelSalleReservation.Visible = True
                GunaTextBoxCapacite.Visible = True

            Else

                GunaGroupBoxDetailChambre.Text = "Hall details"
                GunaLabelLibelleTypeChambreSalle.Text = "Hall Type"
                GunaLabelNumeroChambre.Text = "Hall Name"

                TabControlGestionReservation.SelectedIndex = 0

                GunaPanelSalleReservation.Visible = True
                GunaTextBoxCapacite.Visible = True


            End If

            valeurAZero()

            'ON CHARGE DYNAMIQUEMENT LA LISTE DES EVENEMENTS

            AutoLoadEventList()

            'VidageDesChampsPourNouvelleReservation()

        End If

        GestionDesButtonDImpressionDesDocuments()


        GunaDateTimePicker1.Value = GlobalVariable.DateDeTravail
        GunaDateTimePicker2.Value = GlobalVariable.DateDeTravail

        GunaTextBoxTempsAFaire.Text = 1

        GunaComboBoxTypeDeDocSalle.Visible = True
        GunaComboBoxTypeDeDocSalle.SelectedIndex = 1
        GunaComboBoxImpressionSalle.SelectedIndex = 2

    End Sub

    Private Sub GunaTextBox47_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox47.TextChanged
        sumAReglerPourSalle()
    End Sub

    Private Sub GunaTextBox48_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox48.TextChanged
        sumAReglerPourSalle()
    End Sub

    Private Sub GunaTextBox54_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox54.TextChanged
        sumAReglerPourSalle()
    End Sub

    Private Sub GunaTextBox63_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox63.TextChanged
        sumAReglerPourSalle()
    End Sub

    Private Sub GunaTextBox10_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox10.TextChanged
        sumAReglerPourSalle()
    End Sub

    Private Sub GunaTextBox50_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox50.TextChanged
        sumAReglerPourSalle()
    End Sub

    Private Sub GunaTextBox36_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox36.TextChanged
        sumAReglerPourSalle()
    End Sub

    Private Sub GunaTextBoxQteGouter_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxQteGouter.TextChanged

        Dim prix As Double = 0
        Dim quantite As Integer = 0
        Double.TryParse(GunaTextBoxPrixGouter.Text, prix)
        Integer.TryParse(GunaTextBoxQteGouter.Text, quantite)
        GunaTextBoxPrixTotalGouter.Text = Format(prix * quantite, "#,##0")

        GunaTextBoxMontantTotalSalle.Text = Format(sumAReglerPourSalle(), "#,##0")

        Dim nombreDeJourTotal As Integer = 0
        Integer.TryParse(GunaTextBoxTempsAFaire.Text, nombreDeJourTotal)
        'GunaTextBoxGrandTotal.Text = Format(sumAReglerPourSalle() * nombreDeJourTotal, "#,##0")

        montanTotalDeLocationSalle(nombreDeJourTotal)

        If Trim(GunaTextBoxNombreDePersonneDelaSalleDeFete.Text) = "" Then
            GunaTextBoxNombreDePersonneDelaSalleDeFete.Text = 0
        End If

        'GunaTextBoxNombreDePersonneDelaSalleDeFete.Text += quantite

    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click

        Dim CODE_RESERVATION As String = DataGridViewEnChambre.CurrentRow.Cells("Reservation").Value.ToString

        GlobalVariable.codeReservationToUpdate = CODE_RESERVATION

        Dim DATE_ENTTRE As Date = DataGridViewEnChambre.CurrentRow.Cells(2).Value.ToString

        Dim continuer As Boolean = False

        '1- ON NE PEUT ANNULER QUE LE JOUR DU CHECKIN
        If DATE_ENTTRE.ToShortDateString() = GlobalVariable.DateDeTravail.ToShortDateString() Then
            continuer = True
        End If

        If continuer Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Annuler cette Réservation", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                dialog = MessageBox.Show("Do you really want to Cancel this Reservation", "Cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            Dim nombreDeDuplication As Integer = 1

            If dialog = DialogResult.Yes Then

                GlobalVariable.fenetreDouvervetureDeCaisse = "annulerReservation"
                TransfertDeClientEntreCaissierForm.Show()
                TransfertDeClientEntreCaissierForm.TopMost = True

                If GlobalVariable.actualLanguageValue = 1 Then
                    TransfertDeClientEntreCaissierForm.GunaButtonEnregistrer.Text = "Valider"
                Else
                    TransfertDeClientEntreCaissierForm.GunaButtonEnregistrer.Text = "Validate"
                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Vous ne pouvez plus Annuler cette Réservation", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                MessageBox.Show("You can't more Cancel this Reservation", "Cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

        End If

    End Sub

    Public Sub annulationCheckin()

        Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate

        If DataGridViewEnChambre.Rows.Count > 0 Then

            Dim nombreDeDuplication As Integer = 1

            If nombreDeDuplication > 0 Then

                For i = 1 To nombreDeDuplication
                    Functions.DuplicateRowFromDataGrid(DataGridViewEnChambre, CODE_RESERVATION, "reserve_conf", "ID_RESERVATION")
                Next

                DataGridViewEnChambre.Columns.Clear()

                '2- SUPPRESSION DE LA RESERVATION DANS RESERVE_CONF
                Functions.DeleteElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                '3- Annulation de la charge de Location ou Hebergement

                Dim infoSupLigneFacture As DataTable = Functions.getElementByCode(CODE_RESERVATION, "ligne_facture", "CODE_RESERVATION")
                '1- INSCRIRE LA CONTRE ECRITURE 
                '1-1. TESTER SI CHARGES OU REGLEMENT

                Dim Motif As String = "ANNULATION"

                If GlobalVariable.actualLanguageValue = 0 Then
                    Motif = "CANCELLATION"
                End If

                If infoSupLigneFacture.Rows.Count > 0 Then

                    For i = 0 To infoSupLigneFacture.Rows.Count - 1

                        Dim debit As Double = infoSupLigneFacture.Rows(i)("MONTANT_TTC")
                        Dim ID_LIGNE_FACTURE = infoSupLigneFacture.Rows(i)("ID_LIGNE_FACTURE")

                        If debit > 0 Then

                            Dim insert As String = "INSERT INTO ligne_facture (`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`, `GRIFFE_UTILISATEUR`, `VALEUR_CONSO`, `ETAT`) 
                                    SELECT `CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`, `GRIFFE_UTILISATEUR`, `VALEUR_CONSO`, `ETAT` FROM ligne_facture WHERE ID_LIGNE_FACTURE = @ID_LIGNE_FACTURE"

                            Dim command As New MySqlCommand(insert, GlobalVariable.connect)

                            command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.VarChar).Value = ID_LIGNE_FACTURE
                            command.ExecuteNonQuery()

                            Dim nomDelaTable As String = "ligne_facture"

                            Dim infoSupArticle As DataTable = Functions.getElementByCode(ID_LIGNE_FACTURE, nomDelaTable, "ID_LIGNE_FACTURE")

                            Dim NEW_LIBELLE As String = ""
                            Dim MONTANT_HT As Double = 0
                            Dim PRIX_UNITAIRE_TTC As Double = 0
                            Dim MONTANT_TTC As Double = 0
                            Dim POINT_DE_VENTE As String = ""
                            Dim FUSIONNEE As String = ""

                            If infoSupArticle.Rows.Count > 0 Then
                                NEW_LIBELLE = infoSupArticle.Rows(0)("LIBELLE_FACTURE")
                                MONTANT_HT = infoSupArticle.Rows(0)("MONTANT_HT")
                                PRIX_UNITAIRE_TTC = infoSupArticle.Rows(0)("PRIX_UNITAIRE_TTC")
                                MONTANT_TTC = infoSupArticle.Rows(0)("MONTANT_TTC")
                                POINT_DE_VENTE = infoSupArticle.Rows(0)("TYPE_LIGNE_FACTURE")
                                FUSIONNEE = infoSupArticle.Rows(0)("FUSIONNEE")
                            End If

                            Dim NEW_ID_LIGNE_FACTURE As Integer = Functions.latInsertedElementId(nomDelaTable, "ID_LIGNE_FACTURE")

                            Dim nomDuChamp As String = "LIBELLE_FACTURE"
                            Dim ValeurDuChamp As String = Motif.ToUpper() & " " & NEW_LIBELLE
                            Dim nomDuChampDuCode As String = "ID_LIGNE_FACTURE"
                            Dim valeurDuChampDuCode As Integer = NEW_ID_LIGNE_FACTURE
                            Dim variableType As Integer = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "CODE_UTILISATEUR_CREA"
                            ValeurDuChamp = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                            variableType = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "CODE_FACTURE"
                            ValeurDuChamp = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")
                            variableType = 2

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "MONTANT_HT"
                            ValeurDuChamp = MONTANT_HT * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "PRIX_UNITAIRE_TTC"
                            ValeurDuChamp = PRIX_UNITAIRE_TTC * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                            nomDuChamp = "MONTANT_TTC"
                            ValeurDuChamp = MONTANT_TTC * -1
                            variableType = 1

                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                        End If

                    Next

                End If

                '4- SUPPRESSION DE LA RESERVATION DANS LA MAINCOURANTE DU JOUR
                Functions.deleteElementByDate(CODE_RESERVATION, "main_courante_journaliere", "NUM_RESERVATION", "DATE_MAIN_COURANTE", GlobalVariable.DateDeTravail)

                '5- Affichage de la reservation
                ListeDesEnChambres()

                passwordVerifivationForm.Close()

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Réservation Annulée avec succès", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Reservation successfully canceled", "Cancelation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

            GlobalVariable.fenetreDouvervetureDeCaisse = ""

        End If

        GlobalVariable.codeReservationToUpdate = ""

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click

        If DataGridViewEnChambre.Rows.Count > 0 Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Dupliquer cette Réservation", "Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Else
                dialog = MessageBox.Show("Do you really want to duplicate the reservation", "Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            End If
            If Not dialog = DialogResult.No Then

                Dim myValue As String = ""
                If GlobalVariable.actualLanguageValue = 1 Then
                    myValue = InputBox("Nombre de Duplication", "Duplication", "")

                Else
                    myValue = InputBox("Number of Duplication", "Duplication", "")

                End If
                Dim nombreDeDuplication As Integer = 0

                Integer.TryParse(myValue, nombreDeDuplication)

                If nombreDeDuplication > 0 Then

                    For i = 1 To nombreDeDuplication
                        Functions.DuplicateRowFromDataGrid(DataGridViewEnChambre, DataGridViewEnChambre.CurrentRow.Cells("Reservation").Value.ToString, "reserve_conf", "ID_RESERVATION")
                    Next

                    DataGridViewEnChambre.Columns.Clear()

                    ListeDesEnChambres()

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Réservation dupliquée avec succès", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Booking duplicated successfully", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune ligne à Dupliquer !", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No liine to duplicate !", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        If DataGridViewEnChambre.Rows.Count > 0 Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Dupliquer cette Réservation", "Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Else
                dialog = MessageBox.Show("Do you really want to duplicate the reservation", "Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            End If
            If Not dialog = DialogResult.No Then

                Dim myValue As String = ""
                If GlobalVariable.actualLanguageValue = 1 Then
                    myValue = InputBox("Nombre de Duplication", "Duplication", "")

                Else
                    myValue = InputBox("Number of Duplication", "Duplication", "")

                End If
                Dim nombreDeDuplication As Integer = 0

                Integer.TryParse(myValue, nombreDeDuplication)

                If nombreDeDuplication > 0 Then

                    For i = 1 To nombreDeDuplication
                        Functions.DuplicateRowFromDataGrid(DataGridViewEnChambre, DataGridViewEnChambre.CurrentRow.Cells("Reservation").Value.ToString, "reserve_conf", "ID_RESERVATION")
                    Next

                    DataGridViewEnChambre.Columns.Clear()

                    ListeDesEnChambres()

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Réservation dupliquée avec succès", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Booking duplicated successfully", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune ligne à Dupliquer !", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No line to Duplicate !", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        Dim CODE_RESERVATION As String = DataGridViewEnChambre.CurrentRow.Cells("Reservation").Value.ToString

        GlobalVariable.codeReservationToUpdate = CODE_RESERVATION

        Dim DATE_ENTTRE As Date = DataGridViewEnChambre.CurrentRow.Cells(2).Value.ToString

        Dim continuer As Boolean = False

        '1- ON NE PEUT ANNULER QUE LE JOUR DU CHECKIN
        If DATE_ENTTRE.ToShortDateString() = GlobalVariable.DateDeTravail.ToShortDateString() Then
            continuer = True
        End If

        If continuer Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Annuler cette Réservation", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                dialog = MessageBox.Show("Do you really want to Cancel this Reservation", "Cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            Dim nombreDeDuplication As Integer = 1

            If dialog = DialogResult.Yes Then

                GlobalVariable.fenetreDouvervetureDeCaisse = "annulerReservation"
                TransfertDeClientEntreCaissierForm.Show()
                TransfertDeClientEntreCaissierForm.TopMost = True

                If GlobalVariable.actualLanguageValue = 1 Then
                    TransfertDeClientEntreCaissierForm.GunaButtonEnregistrer.Text = "Valider"
                Else
                    TransfertDeClientEntreCaissierForm.GunaButtonEnregistrer.Text = "Validate"
                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Vous ne pouvez plus Annuler cette Réservation", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                MessageBox.Show("You can't more Cancel this Reservation", "Cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

        End If

    End Sub

    Private Sub CheckInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckInToolStripMenuItem.Click

    End Sub

End Class


