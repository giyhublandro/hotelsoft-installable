Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Net
Imports System.IO

Public Class FiscaliteForm
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        'Functions.ClosingOpenedConnection()
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaButtonEnregistrerFiscValue_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerFiscValue.Click

        Dim FISCALITE As Double = 0

        If Not Trim(GunaTextBoxTauxVisibilite.Text).Equals("") Then

            FISCALITE = GunaTextBoxTauxVisibilite.Text

            Dim TableName As String = "agence"
            Dim fieldName As String = "FISCALITE"
            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            Dim fielNameValue As Integer = 0
            Dim fieldCodeName As String = ""
            Dim fieldCodeValue As String = ""

            Dim NBRE_CORPORATE As Integer = 0
            Dim NBRE_AUTRES As Integer = 0
            Dim NBRE_TOTAL As Integer = 0

            If Not Trim(GunaTextBoxNbreCorporate.Text).Equals("") Then
                NBRE_CORPORATE = GunaTextBoxNbreCorporate.Text
            End If

            If Not Trim(GunaTextBoxNobreAutres.Text).Equals("") Then
                NBRE_AUTRES = GunaTextBoxNobreAutres.Text
            End If

            If Not Trim(GunaTextBoxNbreTotal.Text).Equals("") Then
                NBRE_TOTAL = GunaTextBoxNbreTotal.Text
            End If

            Dim DU As Date = GunaDateTimePickerParDateDebut.Text
            Dim AU As Date = GunaDateTimePickerParDateDepart.Text

            Dim CA_CORPORATE As Double = 0
            Dim CA_AUTRES As Double = 0
            Dim CA As Double = 0

            If Not Trim(GunaTextBoxCorporate.Text).Equals("") Then
                CA_CORPORATE = GunaTextBoxCorporate.Text
            End If

            If Not Trim(GunaTextBoxAutres.Text).Equals("") Then
                CA_AUTRES = GunaTextBoxAutres.Text
            End If

            If Not Trim(GunaTextBoxCA.Text).Equals("") Then
                CA = GunaTextBoxCA.Text
            End If

            Dim TAUX As Double = FISCALITE
            Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail

            'ENREGISTREMENT DU TAUX DE VISIBILITE

            Functions.updateOfFields(TableName, fieldName, FISCALITE, "CODE_AGENCE", CODE_AGENCE, 1)

            If GlobalVariable.actualLanguageValue = 0 Then

            Else
                'ENREGISTREMENT OU CHANGEMENET D'ETAT DES VARIABLES DES RESSERVATION CONFIRMEE ET DES FACTURES POUR AFFICHAGE AU NIVEAU DE LA RECEPTION
                Dim date_debut As Date = GunaDateTimePickerParDateDebut.Value.ToShortDateString()
                Dim date_Fin As Date = GunaDateTimePickerParDateDepart.Value.ToShortDateString()

                Dim updateQuery As String = "UPDATE reserve_conf SET FSC = 0 
                WHERE DATE_ENTTRE <= '" & date_Fin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & date_debut.ToString("yyyy-MM-dd") & "' "

                Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)
                commandupdateQuery.ExecuteNonQuery()

                updateQuery = "UPDATE facture SET FSC = 0 
                WHERE DATE_FACTURE <= '" & date_Fin.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE >='" & date_debut.ToString("yyyy-MM-dd") & "' "

                Dim commandupdateQuery_ As New MySqlCommand(updateQuery, GlobalVariable.connect)
                commandupdateQuery_.ExecuteNonQuery()

                updateQuery = "UPDATE reglement SET FSC = 0 
                WHERE DATE_REGLEMENT <= '" & date_Fin.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT >='" & date_debut.ToString("yyyy-MM-dd") & "' "

                Dim commandupdateQuery_1 As New MySqlCommand(updateQuery, GlobalVariable.connect)
                commandupdateQuery_1.ExecuteNonQuery()

                For i = 0 To GunaDataGridViewReservationList.Rows.Count - 1

                    'mise a jours de l'etat de reservations 

                    TableName = "reserve_conf"
                    fieldName = "FSC" ' FISCALITE
                    fielNameValue = 1
                    fieldCodeValue = GunaDataGridViewReservationList.Rows(i).Cells("RESERVATION").Value.ToString
                    fieldCodeName = "CODE_RESERVATION"

                    Functions.updateOfFields(TableName, fieldName, fielNameValue, fieldCodeName, fieldCodeValue, 0) '0 : Integer

                    'Mise a jours de l'etat des factures
                    TableName = "facture"
                    fieldName = "FSC" ' FISCALITE
                    fielNameValue = 1
                    fieldCodeValue = GunaDataGridViewReservationList.Rows(i).Cells("RESERVATION").Value.ToString
                    fieldCodeName = "CODE_RESERVATION"

                    Functions.updateOfFields(TableName, fieldName, fielNameValue, fieldCodeName, fieldCodeValue, 0) '0 : integer

                    'Mise a jours de l'etat des reglements
                    TableName = "reglement"
                    fieldName = "FSC" ' FISCALITE
                    fielNameValue = 1
                    fieldCodeValue = GunaDataGridViewReservationList.Rows(i).Cells("RESERVATION").Value.ToString
                    fieldCodeName = "CODE_RESERVATION"

                    Functions.updateOfFields(TableName, fieldName, fielNameValue, fieldCodeName, fieldCodeValue, 0) '0 : integer

                Next

                'ENREGISTREMENT DES DONNEES LIES A LA FISCALITE
                'AVANT ON DOIT VERIFIER SI IL N'EXISTE PAS DEJA DES ENREGISTREMENT POUR CETTE PERIODE

                Dim resa As New Reservation()

                If GunaButtonEnregistrerFiscValue.Text.Equals("Enregistrer") Then
                    resa.insertFiscaliteger(DU, AU, CA_CORPORATE, CA_AUTRES, CA, TAUX, DATE_CREATION, NBRE_CORPORATE, NBRE_AUTRES, NBRE_TOTAL)
                Else
                    Dim ID_FISCALITE As Integer = GunaTextBoxID_FISCALITE.Text
                    resa.updateFiscaliteger(DU, AU, CA_CORPORATE, CA_AUTRES, CA, TAUX, DATE_CREATION, NBRE_CORPORATE, NBRE_AUTRES, NBRE_TOTAL, ID_FISCALITE)
                End If

                GunaButtonEnregistrerFiscValue.Text = "Enregistrer"

                MessageBox.Show("Taux de réservation visible modifié avec succès", "Fiscalité", MessageBoxButtons.OK, MessageBoxIcon.Information)

                GunaDataGridViewReservationList.Columns.Clear()
                GunaTextBoxTauxVisibilite.Text = 0
                GunaTextBoxCA.Text = 0

            End If

            GlobalVariable.AgenceActuelle = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE")

        End If

    End Sub

    Private Sub FiscaliteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaDateTimePickerParDateDebut.Value = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail)
        GunaDateTimePickerParDateDepart.Value = GlobalVariable.DateDeTravail

    End Sub

    Private Sub visualisationDesResaDeLaFiscalite(ByVal date_debut As Date, ByVal date_fin As Date)

        GunaTextBoxTauxVisibilite.Text = GlobalVariable.AgenceActuelle.Rows(0)("FISCALITE")

        Dim query As String = ""
        Dim query1 As String = ""
        Dim query01 As String = ""
        Dim table As New DataTable()
        Dim table01 As New DataTable()
        Dim table1 As New DataTable()

        query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE',
        MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)'
        FROM reserve_conf, source_reservation WHERE TYPE=@TYPE AND reserve_conf.SOURCE_RESERVATION = source_reservation.CODE_SOURCE_RESERVATION 
        AND FSC = @FSC AND DATE_ENTTRE >= '" & date_debut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & date_fin.ToString("yyyy-MM-dd") & "' 
        ORDER BY CHAMBRE_ID ASC "

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
        command.Parameters.Add("@FSC", MySqlDbType.Int32).Value = 1

        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)

        Dim CA As Double = 0
        Dim DUREE As Integer = 0
        Dim arrivee As Date
        Dim depart As Date

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
                    'GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.BackColor = Color.LightPink
                    ' GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.BackColor = Color.White
                    GunaDataGridViewReservationList.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If

                arrivee = CDate(GunaDataGridViewReservationList.Rows(i).Cells("DATE ENTREE").Value.ToString).ToShortDateString
                depart = CDate(GunaDataGridViewReservationList.Rows(i).Cells("DATE SORTIE").Value.ToString).ToShortDateString
                DUREE = CType((depart - arrivee).TotalDays, Int32)

                CA += GunaDataGridViewReservationList.Rows(i).Cells("PRIX/NUITEE").Value * DUREE

            Next

            GunaTextBoxCA.Text = Format(CA, "#,##0")

        Else

            GunaDataGridViewReservationList.Columns.Clear()

        End If

    End Sub

    Private Sub GunaButtonAfficherReservation_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherReservation.Click

        Dim query As String = ""
        Dim query1 As String = ""
        Dim query01 As String = ""
        Dim table As New DataTable()
        Dim table01 As New DataTable()
        Dim table1 As New DataTable()
        Dim DateDebut As Date = GunaDateTimePickerParDateDebut.Value.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GunaDateTimePickerParDateDepart.Value.ToString("yyyy-MM-dd")

        '--------------------------- DETERMINONS LE NOMBRE DE RESERVATION DE TYPE COMPTOIR ------------------------------------------

        Dim CODE_ENTREPRISE As String = ""
        Dim DAY_USE As Integer = 0

        '1- NOMBRE DE RESERVATION TOTAL : POUR DETERMINER LE NOMBRE LIMIT
        '1.1- DETERMINER LA LIMITE : PAR APPORT A CE QU'ON DOIT EXCLURE

        query01 = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', 
        MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' 
        FROM reserve_conf, source_reservation WHERE TYPE=@TYPE AND source_reservation.SOURCE_RESERVATION IN ('COMPTOIR', 'COMPTOIRE', 'WALK IN') 
        AND reserve_conf.SOURCE_RESERVATION = source_reservation.CODE_SOURCE_RESERVATION 
        AND DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
        AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' 
        AND DAY_USE = @DAY_USE AND CODE_ENTREPRISE=@CODE_ENTREPRISE
        ORDER BY CHAMBRE_ID ASC"

        Dim command01 As New MySqlCommand(query01, GlobalVariable.connect)
        command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
        command01.Parameters.Add("@DAY_USE", MySqlDbType.Int16).Value = DAY_USE
        command01.Parameters.Add("@CODE_ENTREPRISE", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        Dim adapter01 As New MySqlDataAdapter(command01)

        adapter01.Fill(table01)

        Dim nombreDeReservationTotal As Integer = table01.Rows.Count

        Dim taux As Double = 0

        If Not Trim(GunaTextBoxTauxVisibilite.Text).Equals("") Then
            taux = GunaTextBoxTauxVisibilite.Text
        End If

        Dim tauxDeVisibilite As Double = Double.Parse(taux) / 100

        Dim LIMITER As Integer = -2
        LIMITER = Math.Round(nombreDeReservationTotal * tauxDeVisibilite)

        If LIMITER > 0 And LIMITER < 1 Then
            LIMITER = 1
        End If

        Dim CA_CORPORATE As Double = 0
        Dim CA_AUTRES As Double = 0

        '----------------------------------------------------------------------------------------------------------------------------
        '2- DETERMINONS LE NOMBRE DE RESERVATION A AFFICHER PAR APPORT A CEUX QU'ON PEUT EXCLURE PRENANT EN COMPTE LE TAUX D'AFFICHAGE
        query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', 
        MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' 
        FROM reserve_conf, source_reservation WHERE TYPE=@TYPE AND source_reservation.SOURCE_RESERVATION IN ('COMPTOIR', 'COMPTOIRE', 'WALK IN') 
        AND reserve_conf.SOURCE_RESERVATION = source_reservation.CODE_SOURCE_RESERVATION 
        AND DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
        AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' 
        AND DAY_USE = @DAY_USE AND CODE_ENTREPRISE=@CODE_ENTREPRISE
        ORDER BY CHAMBRE_ID ASC LIMIT " & LIMITER

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
        command.Parameters.Add("@CODE_ENTREPRISE", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command.Parameters.Add("@DAY_USE", MySqlDbType.Int16).Value = DAY_USE

        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)

        Dim CODE_RESERVATION As String = ""
        Dim infoSupfacture As DataTable

        For i = 0 To table.Rows.Count - 1
            CODE_RESERVATION = table.Rows(i)("RESERVATION")
            infoSupfacture = Functions.getElementByCode(CODE_RESERVATION, "facture", "CODE_RESERVATION")
            If infoSupfacture.Rows.Count > 0 Then
                For j = 0 To infoSupfacture.Rows.Count - 1
                    CA_AUTRES += infoSupfacture.Rows(j)("MONTANT_TTC")
                Next
            End If
        Next

        '--------------------------------------------------------------------------------------------------------------------------------------------------------------
        '3- DETERMINONS LE NOMBRE DE RESERVATION QUE L'ON NE PEUT PAS EXCLURE.
        query1 = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', 
        MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' 
        FROM reserve_conf, source_reservation WHERE TYPE=@TYPE AND source_reservation.SOURCE_RESERVATION NOT IN ('') 
        AND reserve_conf.SOURCE_RESERVATION = source_reservation.CODE_SOURCE_RESERVATION AND CODE_ENTREPRISE NOT IN ('')
        AND DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY CHAMBRE_ID ASC"

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter1 As New MySqlDataAdapter(command1)

        adapter1.Fill(table1)

        For i = 0 To table1.Rows.Count - 1
            CODE_RESERVATION = table1.Rows(i)("RESERVATION")
            infoSupfacture = Functions.getElementByCode(CODE_RESERVATION, "facture", "CODE_RESERVATION")
            If infoSupfacture.Rows.Count > 0 Then
                For j = 0 To infoSupfacture.Rows.Count - 1
                    CA_CORPORATE += infoSupfacture.Rows(j)("MONTANT_TTC")
                Next
            End If
        Next

        table.Merge(table1)

        Dim CA As Double = 0
        Dim DUREE As Integer = 0
        Dim arrivee As Date
        Dim depart As Date

        If (table.Rows.Count > 0) Then

            GunaDataGridViewReservationList.DataSource = table

            GunaTextBoxNbreCorporate.Text = table1.Rows.Count
            GunaTextBoxNobreAutres.Text = LIMITER
            GunaTextBoxNbreTotal.Text = nombreDeReservationTotal + table1.Rows.Count

            GunaTextBox1.Text = LIMITER + table1.Rows.Count & " / " & nombreDeReservationTotal + table1.Rows.Count & " (" & table1.Rows.Count & ")"
            'GunaTextBox1.Text = LIMITER & " / " & nombreDeReservationTotal + table.Rows.Count & " (" & table1.Rows.Count & ")"

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
                    'GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.BackColor = Color.LightPink
                    ' GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.BackColor = Color.White
                    GunaDataGridViewReservationList.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If

                arrivee = CDate(GunaDataGridViewReservationList.Rows(i).Cells("DATE ENTREE").Value.ToString).ToShortDateString
                depart = CDate(GunaDataGridViewReservationList.Rows(i).Cells("DATE SORTIE").Value.ToString).ToShortDateString
                DUREE = CType((depart - arrivee).TotalDays, Int32)

                'CA += GunaDataGridViewReservationList.Rows(i).Cells("PRIX/NUITEE").Value * DUREE

            Next

            CA = CA_AUTRES + CA_CORPORATE
            GunaTextBoxCA.Text = Format(CA, "#,##0")
            GunaTextBoxAutres.Text = Format(CA_AUTRES, "#,##0")
            GunaTextBoxCorporate.Text = Format(CA_CORPORATE, "#,##0")

        Else

            CA = CA_AUTRES + CA_CORPORATE
            GunaTextBoxCA.Text = Format(CA, "#,##0")
            GunaTextBoxAutres.Text = Format(CA_AUTRES, "#,##0")
            GunaTextBoxCorporate.Text = Format(CA_CORPORATE, "#,##0")

            If False Then 'table1.Rows.Count > 0

                GunaDataGridViewReservationList.DataSource = table1

                GunaTextBoxNbreCorporate.Text = table1.Rows.Count
                GunaTextBoxNobreAutres.Text = LIMITER
                GunaTextBoxNbreTotal.Text = nombreDeReservationTotal + table1.Rows.Count

                GunaTextBox1.Text = LIMITER + table1.Rows.Count & " / " & nombreDeReservationTotal + table1.Rows.Count & " (" & table1.Rows.Count & ")"

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
                        'GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.BackColor = Color.LightPink
                        ' GunaDataGridViewReservationList.Columns("SOLDE").DefaultCellStyle.BackColor = Color.White
                        GunaDataGridViewReservationList.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    End If

                    arrivee = CDate(GunaDataGridViewReservationList.Rows(i).Cells("DATE ENTREE").Value.ToString).ToShortDateString
                    depart = CDate(GunaDataGridViewReservationList.Rows(i).Cells("DATE SORTIE").Value.ToString).ToShortDateString
                    DUREE = CType((depart - arrivee).TotalDays, Int32)

                    CA += GunaDataGridViewReservationList.Rows(i).Cells("PRIX/NUITEE").Value * DUREE

                Next

                GunaTextBoxCA.Text = Format(CA, "#,##0")

            Else
                GunaDataGridViewReservationList.Columns.Clear()
            End If

        End If

    End Sub

    Private Sub GunaButton_Click(sender As Object, e As EventArgs) Handles GunaButtonVisualisation.Click
        'visualisationDesResaDeLaFiscalite()
    End Sub

    Private Sub GunaButtonReset_Click(sender As Object, e As EventArgs) Handles GunaButtonReset.Click

        Dim date_debut As Date = GunaDateTimePickerParDateDebut.Value.ToShortDateString()
        Dim date_Fin As Date = GunaDateTimePickerParDateDepart.Value.ToShortDateString()

        Dim updateQuery As String = "UPDATE reserve_conf SET FSC = 0 
        WHERE DATE_ENTTRE <= '" & date_Fin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & date_debut.ToString("yyyy-MM-dd") & "' "

        Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)
        commandupdateQuery.ExecuteNonQuery()

        updateQuery = "UPDATE facture SET FSC = 0 
        WHERE DATE_FACTURE <= '" & date_Fin.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE >='" & date_debut.ToString("yyyy-MM-dd") & "' "

        Dim commandupdateQuery_ As New MySqlCommand(updateQuery, GlobalVariable.connect)
        commandupdateQuery_.ExecuteNonQuery()

    End Sub

    Private Sub affichageFiscalite(ByVal date_debut As Date, ByVal date_fin As Date)

        Dim query As String = "SELECT `ID_FISCALITE`, `DU`, `AU`, `CA_CORPORATE` AS 'CA CORPORATE', `CA_AUTRES` AS 'CA AUTRES',  `CA` AS TOTAL, `TAUX`, `NBRE_CORPORATE` AS '# CORPORATE',
        `NBRE_AUTRES` AS '# AUTRES', `NBRE_TOTAL` AS '# TOTAL', `DATE_CREATION`
        FROM `fiscalite`"
        ' WHERE DU <= '" & date_debut.ToString("yyyy-MM-dd") & "' AND AU >='" & date_fin.ToString("yyyy-MM-dd") & "'
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        'command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
        'command.Parameters.Add("@FSC", MySqlDbType.Int32).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaDataGridView1.DataSource = table
            GunaDataGridView1.Columns(0).Visible = False
            GunaDataGridView1.Columns(3).DefaultCellStyle.Format = "#,##0"
            GunaDataGridView1.Columns(4).DefaultCellStyle.Format = "#,##0"
            GunaDataGridView1.Columns(5).DefaultCellStyle.Format = "#,##0"

        End If

    End Sub

    Private Sub GunaButtonAfficherFiscalite_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherFiscalite.Click

        Dim date_debut As Date = GunaDateTimePicker1.Value.ToShortDateString
        Dim date_Fin As Date = GunaDateTimePicker2.Value.ToShortDateString

        affichageFiscalite(date_debut, date_Fin)

    End Sub

    Private Sub GunaDataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridView1.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrerFiscValue.Text = "Sauvegarder"

            Dim row As DataGridViewRow
            row = Me.GunaDataGridView1.Rows(e.RowIndex)
            Dim ID_FISCALITE As Integer = row.Cells("ID_FISCALITE").Value

            Dim dt As DataTable = Functions.getElementByCode(ID_FISCALITE, "fiscalite", "ID_FISCALITE")

            If dt.Rows.Count > 0 Then

                GunaTextBoxID_FISCALITE.Text = ID_FISCALITE

                Dim date_debut As Date = dt.Rows(0)("DU")
                Dim date_Fin As Date = dt.Rows(0)("AU")

                visualisationDesResaDeLaFiscalite(date_debut, date_Fin)

                GunaTextBoxCA.Text = Format(dt.Rows(0)("CA"), "#,##0")
                GunaTextBoxAutres.Text = Format(dt.Rows(0)("CA_AUTRES"), "#,##0")
                GunaTextBoxCorporate.Text = Format(dt.Rows(0)("CA_CORPORATE"), "#,##0")

                GunaTextBox1.Text = dt.Rows(0)("NBRE_CORPORATE") + dt.Rows(0)("NBRE_AUTRES") & " / " & dt.Rows(0)("NBRE_TOTAL") & " (" & dt.Rows(0)("NBRE_CORPORATE") & ")"

                TabControl1.SelectedIndex = 0

            End If

        End If

    End Sub

End Class