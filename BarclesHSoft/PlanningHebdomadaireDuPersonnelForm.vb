Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.ComponentModel

Public Class PlanningHebdomadaireDuPersonnelForm

    Dim connect As New DataBaseManipulation()

    Private Sub PlannningListe(ByVal CODE_TYPE_PERSONNEL As String)

        Dim infoPlanning As DataTable = Functions.allTableFieldsOnConditionOrganised("planning_hebdomadaire", "CODE_TYPE_PERSONNEL", CODE_TYPE_PERSONNEL, "INTITULE_PLANNING")

        If infoPlanning.Rows.Count > 0 Then

            GunaDataGridViewPlanning.Columns.Clear()
            GunaDataGridViewPlanning.DataSource = infoPlanning

            For i = 0 To GunaDataGridViewPlanning.Columns.Count - 1

                If i = 0 Or i = 2 Or i = 5 Or i = 7 Then
                    GunaDataGridViewPlanning.Columns(i).Visible = False
                End If

            Next

        End If


    End Sub

    Private Sub planningContenantHoraire()

        Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxTypePersonnel.SelectedValue.ToString

        'Dim query04 As String = "SELECT INTITULE_PLANNING,ID_PLANNING_HORAIRE, planning_hebdomadaire_horaire.CODE_PLANNING 
        'FROM `planning_horaire`, `planning_hebdomadaire_horaire`, `planning_hebdomadaire`  
        'WHERE planning_hebdomadaire_horaire.ID_HORAIRE =planning_horaire.ID_HORAIRE AND planning_hebdomadaire.CODE_PLANNING = planning_horaire.CODE_PLANNING
        'And CODE_TYPE_PERSONNEL =@CODE_TYPE_PERSONNEL ORDER BY INTITULE_PLANNING ASC"

        Dim query04 As String = "SELECT DISTINCT planning_hebdomadaire.CODE_PLANNING, INTITULE_PLANNING, CODE_TYPE_PERSONNEL FROM `planning_hebdomadaire` INNER JOIN `planning_horaire`  
                        WHERE planning_hebdomadaire.CODE_PLANNING = planning_horaire.CODE_PLANNING
                            AND CODE_TYPE_PERSONNEL =@CODE_TYPE_PERSONNEL ORDER BY INTITULE_PLANNING ASC"

        Dim command04 As New MySqlCommand(query04, GlobalVariable.connect)
        command04.Parameters.Add("@CODE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL

        Dim adapter04 As New MySqlDataAdapter(command04)
        Dim horraireAffectesAuxPlannings As New DataTable()
        adapter04.Fill(horraireAffectesAuxPlannings)

        If horraireAffectesAuxPlannings.Rows.Count > 0 Then

            GunaComboBoxPlannintContenantHoraire.DataSource = horraireAffectesAuxPlannings
            GunaComboBoxPlannintContenantHoraire.ValueMember = "CODE_PLANNING"
            GunaComboBoxPlannintContenantHoraire.DisplayMember = "INTITULE_PLANNING"

        End If

    End Sub

    Private Sub horaireListe()

        Dim infoPlanning As DataTable = Functions.allTableFieldsOrganised("planning_hebdomadaire_horaire", "DATE_DE_CONTROLE")

        If infoPlanning.Rows.Count > 0 Then

            GunaDataGridViewHoraire.Columns.Clear()
            GunaDataGridViewHoraire.DataSource = infoPlanning

            For i = 0 To GunaDataGridViewHoraire.Columns.Count - 1

                If i = 0 Or i > 4 Then
                    GunaDataGridViewHoraire.Columns(i).Visible = False
                End If

            Next

        End If


    End Sub

    Private Sub PlanningHebdomadaireDuPersonnelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        setPlanningDateAndTime()

        GunaDateTimePickerDispoDebut.Value = GlobalVariable.DateDeTravail.ToShortDateString

        Dim departement As String = ""

        If GunaComboBoxTypePersonnel.SelectedIndex >= 0 Then

            departement = GunaComboBoxTypePersonnel.SelectedValue.ToString()

            PlannningListe(departement)

            horaireListe()

        End If

        If GunaCheckBoxTous.Checked Then
            GunaComboBoxTypePersonnel.SelectedIndex = -1
            GunaComboBoxTypePersonnel.Enabled = False
            PersonnelLIst(departement)
        Else
            autoLoadProfil()
            GunaComboBoxTypePersonnel.Enabled = True
        End If

        activateSave()

        horaireListe()

        planningContenantHoraire()

        listeDesPlanningComplet()

        GunaDateTimePickerDispoFin.Value = GunaDateTimePickerDispoDebut.Value.AddDays(12)

    End Sub

    Sub PersonnelLIst(ByVal departement As String)

        If Trim(departement).Equals("") Then

            Dim personnel As DataTable = Functions.allTableFields("personnel")

            If personnel.Rows.Count > 0 Then

                For i = 0 To personnel.Rows.Count - 1

                    Dim typePersonnel As DataTable = Functions.getElementByCode(personnel.Rows(i)("CODE_TYPE_PERSONNEL"), "type_personnel", "CODE_TYPE_PERSONNEL")

                    GunaDataGridViewFolio1.Rows.Add(personnel.Rows(i)("CODE_PERSONNEL"), personnel.Rows(i)("MATRICULE"), personnel.Rows(i)("NOM_PERSONNEL"), personnel.Rows(i)("PRENOM_PERSONNEL"), typePersonnel.Rows(0)("LIBELLE_TYPE_PERSONNEL"))

                Next

                GunaDataGridViewFolio1.Columns("CODE").Visible = False
                GunaDataGridViewFolio2.Columns("CODE_PERSONNEL").Visible = False

            End If

        Else

            Dim personnel As DataTable = Functions.getElementByCode(departement, "personnel", "CODE_TYPE_PERSONNEL")

            If personnel.Rows.Count > 0 Then

                For i = 0 To personnel.Rows.Count - 1

                    Dim typePersonnel As DataTable = Functions.getElementByCode(personnel.Rows(i)("CODE_TYPE_PERSONNEL"), "type_personnel", "CODE_TYPE_PERSONNEL")

                    GunaDataGridViewFolio1.Rows.Add(personnel.Rows(i)("CODE_PERSONNEL"), personnel.Rows(i)("MATRICULE"), personnel.Rows(i)("NOM_PERSONNEL"), personnel.Rows(i)("PRENOM_PERSONNEL"), typePersonnel.Rows(0)("LIBELLE_TYPE_PERSONNEL"))

                Next

                GunaDataGridViewFolio1.Columns("CODE").Visible = False
                GunaDataGridViewFolio2.Columns("CODE_PERSONNEL").Visible = False

            End If

        End If



    End Sub

    Private Sub setPlanningDateAndTime()

        Dim planning As DataTable = Functions.allTableFields("planning_hebdomadaire")

        'We check if planning is not empty

        If planning.Rows.Count > 0 Then

            'we get the last inserted planning to obtain it dates
            Dim lastPlanningElementCode As String = Functions.latInsertedElementCode("planning_hebdomadaire", "CODE_PLANNING")

            GunaDateTimePicker1.Value = Functions.getElementByCode(lastPlanningElementCode, "planning_hebdomadaire", "CODE_PLANNING").Rows(0)("DATE_DEBUT").AddDays(1)

            GunaLabelDateTravaille.Text = GunaDateTimePicker1.Value.ToLongDateString()

        Else

            'Initialisation du temps du planning 
            GunaDateTimePicker1.Value = Date.Now().ToLongDateString

            GunaLabelDateTravaille.Text = GunaDateTimePicker1.Value.ToLongDateString()

        End If


    End Sub

    'We can only save there is sometinh in th right datagrid
    Private Sub activateSave()

        If GunaDataGridViewFolio2.Rows.Count > 0 Then
            GunaButtonEnregistrerPlanning.Visible = True
        Else
            GunaButtonEnregistrerPlanning.Visible = False
        End If

    End Sub

    Private Sub autoLoadProfil()

        Dim profils As String = "SELECT CODE_TYPE_PERSONNEL, LIBELLE_TYPE_PERSONNEL FROM type_personnel ORDER BY LIBELLE_TYPE_PERSONNEL ASC"
        Dim commandprofilsList As New MySqlCommand(profils, GlobalVariable.connect)

        Dim adapterprofilsList As New MySqlDataAdapter(commandprofilsList)
        Dim tableprofilsList As New DataTable()
        adapterprofilsList.Fill(tableprofilsList)

        If tableprofilsList.Rows.Count > 0 Then

            GunaComboBoxTypePersonnel.DataSource = tableprofilsList
            GunaComboBoxTypePersonnel.ValueMember = "CODE_TYPE_PERSONNEL"
            GunaComboBoxTypePersonnel.DisplayMember = "LIBELLE_TYPE_PERSONNEL"

            GunaComboBoxListeDesDepartements.DataSource = tableprofilsList
            GunaComboBoxListeDesDepartements.ValueMember = "CODE_TYPE_PERSONNEL"
            GunaComboBoxListeDesDepartements.DisplayMember = "LIBELLE_TYPE_PERSONNEL"

        End If

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonFermer_Click(sender As Object, e As EventArgs) Handles GunaButtonFermer.Click
        Me.Close()
    End Sub

    'Enregistrement du planning
    Private Sub GunaButtonEnregistrerPlanning_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerPlanning.Click

        Dim departement As String = ""

        If GunaComboBoxTypePersonnel.SelectedIndex >= 0 Then
            departement = GunaComboBoxTypePersonnel.SelectedValue.ToString()
        End If

        'Enregistrement du planning
        Dim planning As New ServicesEtage()

        Dim CODE_PLANNING_HORAIRE_PERSONNEL As String = Functions.GeneratingRandomCodeWithSpecifications("planning_horaire_personnel", "")
        Dim CODE_PLANNING As String = GunaComboBoxPlannintContenantHoraire.SelectedValue.ToString
        Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxTypePersonnel.SelectedValue.ToString
        Dim DATE_DEBUT As Date = GunaDateTimePicker1.Value.ToShortDateString()
        Dim HEURE_DEBUT As DateTime = GunaDateTimePickerAu.Value.ToShortTimeString()

        Dim CODE_PERSONNEL As String = ""

        Dim service As New ServicesEtage

        For i = 0 To GunaDataGridViewFolio2.Rows.Count - 1

            CODE_PERSONNEL = GunaDataGridViewFolio2.Rows(i).Cells("CODE_PERSONNEL").Value.ToString
            service.insertPlanningHorairePersonnel(CODE_PLANNING_HORAIRE_PERSONNEL, CODE_PERSONNEL, CODE_TYPE_PERSONNEL, CODE_PLANNING)

        Next

        MessageBox.Show("Personnel affecté au " & GunaLabelDateTravaille.Text & " avec succès", "PLanning Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'We clean the right datargid and refresh the left one
        GunaDataGridViewFolio1.Rows.Clear()
        GunaDataGridViewFolio2.Rows.Clear()

        GunaDateTimePicker1.Value = GunaDateTimePicker1.Value.AddDays(1)

        PersonnelLIst(departement)

        listeDesPlanningComplet()

        activateSave()

    End Sub

    'Basculement du folio1 pour le folio2
    Private Sub GunaButtonAJouterUn_Click(sender As Object, e As EventArgs) Handles GunaButtonMoveLeftToRight.Click

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
            GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio2.Rows.Add(selectedgrid)
        End If

        activateSave()

    End Sub

    'Basculement du folio2 pour le folio1
    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButtonMoveRightToLeft.Click

        If GunaDataGridViewFolio2.SelectedRows.Count > 0 Then
            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio2.SelectedRows(0)
            GunaDataGridViewFolio2.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio1.Rows.Add(selectedgrid)
        End If

        activateSave()

    End Sub

    'Move everything found in the left to the right
    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButtonAllToRight.Click

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio1.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
                GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio2.Rows.Add(selectedgrid)
            Loop

        End If

        activateSave()

    End Sub

    'Move everything found in the right to the left
    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButtonAllToLeft.Click

        If GunaDataGridViewFolio2.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio2.SelectedRows.Count > 0
                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio2.SelectedRows(0)
                GunaDataGridViewFolio2.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio1.Rows.Add(selectedgrid)
            Loop

        End If

        activateSave()

    End Sub

    Private Sub GunaDateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePicker1.ValueChanged

        GunaLabelDateTravaille.Text = GunaDateTimePicker1.Value.ToShortDateString
        GunaLabel7.Text = GunaDateTimePickerAu.Value.ToShortDateString

        GunaDateTimePickerAu.Value = GunaDateTimePicker1.Value.AddDays(7)

        activateSave()

    End Sub

    Private Sub GunaCheckBoxTous_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxTous.Click

        GunaDataGridViewFolio1.Rows.Clear()

        Dim departement As String = ""

        If GunaCheckBoxTous.Checked Then
            GunaComboBoxTypePersonnel.SelectedIndex = -1
            GunaComboBoxTypePersonnel.Enabled = False
        Else
            autoLoadProfil()
            GunaComboBoxTypePersonnel.SelectedIndex = -1
            GunaComboBoxTypePersonnel.Enabled = True
        End If

        If GunaComboBoxTypePersonnel.SelectedIndex >= 0 Then
            departement = GunaComboBoxTypePersonnel.SelectedValue.ToString
        End If

        PersonnelLIst(departement)

    End Sub

    Private Sub GunaComboBoxTypePersonnel_SelectedValueChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypePersonnel.SelectedValueChanged

        If GunaComboBoxTypePersonnel.SelectedIndex >= 0 Then

            GunaDataGridViewFolio1.Rows.Clear()
            GunaDataGridViewFolio2.Rows.Clear()

            Dim departement As String = GunaComboBoxTypePersonnel.SelectedValue.ToString
            PersonnelLIst(departement)

            GunaComboBoxPlannintContenantHoraire.DataSource = Nothing

            planningContenantHoraire()

        End If

    End Sub

    Private Sub GunaDateTimePickerAu_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerAu.ValueChanged

        GunaLabel7.Text = GunaDateTimePickerAu.Value.ToShortDateString

        activateSave()

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        If GunaComboBoxListeDesDepartements.SelectedIndex >= 0 Then

            If Trim(GunaTextBoxIntitulePlanning.Text).Equals("") Then

                MessageBox.Show("Bien vouloir donner un intitulé au planning ", "PLanning Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                Dim planning As New ServicesEtage()

                Dim CODE_PLANNING As String = Functions.GeneratingRandomCode("planning_hebdomadaire", "")
                Dim INTITULE_PLANNING As String = GunaTextBoxIntitulePlanning.Text
                Dim DATE_DEBUT As Date = GunaDateTimePicker1.Value.ToShortDateString()
                Dim DATE_FIN As DateTime = GunaDateTimePickerAu.Value.ToShortDateString()

                Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxListeDesDepartements.SelectedValue.ToString

                If Not Trim(GunaTextBoxCodePlanning.Text).Equals("") Then

                    CODE_PLANNING = GunaTextBoxCodePlanning.Text

                    Dim insertQuery As String = "UPDATE `planning_hebdomadaire` SET `INTITULE_PLANNING`=@INTITULE_PLANNING, `DATE_DEBUT`=@DATE_DEBUT,
                        `DATE_FIN`=@DATE_FIN,`CODE_TYPE_PERSONNEL`=@CODE_TYPE_PERSONNEL WHERE CODE_PLANNING = @CODE_PLANNING"

                    Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

                    command.Parameters.Add("@INTITULE_PLANNING", MySqlDbType.VarChar).Value = INTITULE_PLANNING
                    command.Parameters.Add("@DATE_DEBUT", MySqlDbType.Date).Value = DATE_DEBUT
                    command.Parameters.Add("@DATE_FIN", MySqlDbType.Date).Value = DATE_FIN
                    command.Parameters.Add("@CODE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
                    command.Parameters.Add("@CODE_PLANNING", MySqlDbType.VarChar).Value = CODE_PLANNING

                    command.ExecuteNonQuery()

                Else
                    planning.insert(INTITULE_PLANNING, CODE_PLANNING, DATE_DEBUT, DATE_FIN, CODE_TYPE_PERSONNEL)
                End If

                GunaTextBoxCodePlanning.Clear()

                PlannningListe(CODE_TYPE_PERSONNEL)

                GunaTextBoxIntitulePlanning.Clear()

            End If

        Else

        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        Dim ID_HORAIRE = GunaTextBoxCodeHoraire.Text
        Dim CODE_PLANNING As String = GunaTextBoxCodeHoraire.Text
        Dim HEUR_DEBUT As String = MaskedTextBoxheureDebut.Text
        Dim HEURE_FIN As String = MaskedTextBoxHureFin.Text

        Dim service As New ServicesEtage

        If Not Trim(GunaTextBoxCodeHoraire.Text).Equals("") Then

            Dim insertQuery As String = "UPDATE `planning_hebdomadaire_horaire` SET `HEURE_DEBUT`=@HEURE_DEBUT,`HEURE_FIN`=@HEURE_FIN,`HEURE_DEBUT_FIN`=@HEURE_DEBUT_FIN WHERE `ID_HORAIRE`=@ID_HORAIRE "

            Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

            command.Parameters.Add("@ID_HORAIRE", MySqlDbType.Int64).Value = ID_HORAIRE
            command.Parameters.Add("@HEURE_DEBUT", MySqlDbType.VarChar).Value = HEUR_DEBUT
            command.Parameters.Add("@HEURE_FIN", MySqlDbType.VarChar).Value = HEURE_FIN
            command.Parameters.Add("@HEURE_DEBUT_FIN", MySqlDbType.VarChar).Value = HEUR_DEBUT & " - " & HEURE_FIN

            command.ExecuteNonQuery()

        Else
            service.insertHoraire(CODE_PLANNING, HEUR_DEBUT, HEURE_FIN)
        End If

        horaireListe()

        GunaTextBoxCodeHoraire.Clear()
        MaskedTextBoxheureDebut.Clear()
        MaskedTextBoxHureFin.Clear()

    End Sub

    Private Sub GunaComboBoxListeDesDepartements_SelectedValueChanged(sender As Object, e As EventArgs) Handles GunaComboBoxListeDesDepartements.SelectedValueChanged

        If GunaComboBoxListeDesDepartements.SelectedIndex >= 0 Then

            GunaDataGridViewPlanning.DataSource = Nothing

            Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxListeDesDepartements.SelectedValue.ToString()

            Dim infoSupPlanning As DataTable = Functions.getElementByCode(CODE_TYPE_PERSONNEL, "type_personnel", "CODE_TYPE_PERSONNEL")

            If infoSupPlanning.Rows.Count > 0 Then
                PlannningListe(CODE_TYPE_PERSONNEL)
            End If

        End If

    End Sub

    Private Sub GunaButton16_Click(sender As Object, e As EventArgs) Handles GunaButton16.Click

        Me.Cursor = Cursors.WaitCursor

        DisponibiliteEtTarifs(GunaDateTimePickerDispoDebut.Value.ToShortDateString, GunaDateTimePickerDispoFin.Value.ToShortDateString)

        Me.Cursor = Cursors.Default

    End Sub

    Public Sub DisponibiliteEtTarifs(ByVal DateDebut As Date, DateFin As Date)

        GunaDataGridViewPlanningHoraire.Columns.Clear()

        '0- ON SELECTIONNE CHAQUE TYPE DE CHAMBRE

        Dim existQuery As String = "SELECT * From planning_hebdomadaire ORDER BY INTITULE_PLANNING ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim planning As New DataTable()
        adapter.Fill(planning)

        Dim TauxTotal As Double = 0

        Dim dateDuJour As Date

        If planning.Rows.Count > 0 Then

            Dim listeDesTypeChambreEtLocalisation(planning.Rows.Count) As enteteDuTableauDispobiliteEtTarif

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaDataGridViewPlanningHoraire.Columns.Add("PLANNING", "PLANNING")
                GunaDataGridViewPlanningHoraire.Columns.Add("DATA", "")

            Else
                GunaDataGridViewPlanningHoraire.Columns.Add("PLANNING", "PLANNING")
                GunaDataGridViewPlanningHoraire.Columns.Add("DATA", "")

            End If

            Dim nombreDeJour As Integer = DateDiff(DateInterval.Day, DateDebut, DateFin)

            For k = 0 To nombreDeJour - 1
                '1- ON AFFICHE LES DATES DU JOURS
                GunaDataGridViewPlanningHoraire.Columns.Add(DateDebut.AddDays(k).ToString("ddd d MMM"), DateDebut.AddDays(k).ToString("ddd d MMM"))
            Next

            'VARIABLE UTILISEE POUR DETERMINER LES LIGNES DE DONNEES A AFFICHER
            Dim j As Integer = 0

            Dim n = 6 'NOMBRE DE LIGNE SANS TARIFICATIONS POUR CHAQUE TYPE DE CHAMBRE
            Dim t = 0 'NOMBRE DE TARIFICATION ASSOCIE A UN TYPE DE CHAMBRE
            Dim r = 2 'NOMBRE DE SAUT AVANT DEBUT D'ECRITURE D'UN TYPE DE CHAMBRE

            Dim rowTypeChambre = 0
            Dim rowDebutTarif = 0

            Dim actuelRow As Integer = 0

            Dim m As Integer = 0

            For i = 0 To planning.Rows.Count - 1

                actuelRow += 1
                GunaDataGridViewPlanningHoraire.Rows.Add("")

                actuelRow += 1
                rowTypeChambre = actuelRow
                GunaDataGridViewPlanningHoraire.Rows.Add(planning.Rows(i)("INTITULE_PLANNING"))

                listeDesTypeChambreEtLocalisation(i).planning = planning.Rows(i)("INTITULE_PLANNING")
                listeDesTypeChambreEtLocalisation(i).rowIndex = actuelRow
                listeDesTypeChambreEtLocalisation(i).colonneIndex = 0

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaDataGridViewPlanningHoraire.Columns("PLANNING").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GunaDataGridViewPlanningHoraire.Columns("PLANNING").Frozen = True
                Else
                    GunaDataGridViewPlanningHoraire.Columns("PLANNING").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GunaDataGridViewPlanningHoraire.Columns("PLANNING").Frozen = True
                End If


                '3- GESTION DES TARIFICATIONS
                '-----------------------------------------------------------------------------------------------------------------------------------------

                'ON PRENDS LES prix_tarif associé a la tarification_dynamique activé (ETAT = 1)
                'AINSI L'ACTIVATION OU DESACTIVATION D'UN TARIF DYNAMIQUE DETERMINE SON AFFICHAGE OU NON

                Dim HEURE_DEBUT_FIN As String = ""

                If i = 0 Then
                    m = 1
                Else
                    m += 2
                End If

                For k = 0 To nombreDeJour - 1

                    HEURE_DEBUT_FIN = ""

                    dateDuJour = DateDebut.AddDays(k).ToShortDateString

                    If True Then

                        'ON DETERMINE SI ON A UNE TARIFICATION SPECIFIQUE PERIODIQUE (EDITION DE MASSE) QUI DEVRA REMPLACER LE TARIF PUBLIC EN CETTE DATE LA 
                        'PAR APPORT A CE TYPE DE CHAMBRE ET LA DATE EN COURS DONC LA DATE QUE NOUS SOMMES ENTRAINE DE PARCOURIR
                        'ELLE DEVRA ETRE ACTIVE

                        Dim query04 As String = "SELECT `HEURE_DEBUT`, `HEURE_FIN`, DATE_DEBUT, DATE_FIN, HEURE_DEBUT_FIN, planning_hebdomadaire_horaire.CODE_PLANNING FROM `planning_horaire`, `planning_hebdomadaire_horaire` 
                        WHERE planning_horaire.CODE_PLANNING=@CODE_PLANNING AND planning_hebdomadaire_horaire.ID_HORAIRE =planning_horaire.ID_HORAIRE 
                            AND DATE_DEBUT <= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_FIN >='" & dateDuJour.ToString("yyyy-MM-dd") & "'"
                        Dim ETAT_HORAIRE_PLANNINg As Integer = 1

                        Dim command04 As New MySqlCommand(query04, GlobalVariable.connect)
                        'command04.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT_HORAIRE_PLANNINg
                        command04.Parameters.Add("@CODE_PLANNING", MySqlDbType.VarChar).Value = planning.Rows(i)("CODE_PLANNING")

                        Dim adapter04 As New MySqlDataAdapter(command04)
                        Dim horraireAffectesAuxPlannings As New DataTable()
                        adapter04.Fill(horraireAffectesAuxPlannings)

                        If horraireAffectesAuxPlannings.Rows.Count > 0 Then

                            For p = 0 To horraireAffectesAuxPlannings.Rows.Count - 1

                                'SI LA DATE ACTUEL SE TROUVE DANS L'INTERVALE PERIODIQUE LE MONTANT A AFFICHER DOIT ETRE CELUI DE L'INTERVALE
                                'disponibilite_tarif_specifique_periodique

                                Dim DATE_DEBUT As Date = CDate(horraireAffectesAuxPlannings.Rows(p)("DATE_DEBUT")).ToShortDateString
                                Dim DATE_FIN As Date = CDate(horraireAffectesAuxPlannings.Rows(p)("DATE_FIN")).ToShortDateString

                                If DATE_DEBUT.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DATE_FIN.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                    GunaDataGridViewPlanningHoraire.Rows(rowDebutTarif + m).Cells(k + 2).Value = horraireAffectesAuxPlannings.Rows(p)("HEURE_DEBUT_FIN")

                                    If k Mod 2 = 0 Then
                                        GunaDataGridViewPlanningHoraire.Rows(rowDebutTarif + m).Cells(k + 2).Style.BackColor = Color.LightGray
                                    End If

                                    GunaDataGridViewPlanningHoraire.Rows(rowDebutTarif + m).Cells(k + 2).Style.ForeColor = Color.Black

                                End If

                            Next

                        Else

                            HEURE_DEBUT_FIN = ""

                            GunaDataGridViewPlanningHoraire.Rows(rowDebutTarif + m).Cells(k + 2).Value = HEURE_DEBUT_FIN
                            If k Mod 2 = 0 Then
                                GunaDataGridViewPlanningHoraire.Rows(rowDebutTarif + m).Cells(k + 2).Style.BackColor = Color.LightGray
                            End If
                            GunaDataGridViewPlanningHoraire.Rows(rowDebutTarif + m).Cells(k + 2).Style.ForeColor = Color.Red

                        End If

                    End If

                Next

            Next

        End If

    End Sub

    Structure enteteDuTableauDispobiliteEtTarif
        Dim planning As String
        Dim rowIndex As Integer
        Dim colonneIndex As Integer
    End Structure


    Private Sub GunaButtonEditionDeMasse_Click(sender As Object, e As EventArgs) Handles GunaButtonEditionDeMasse.Click

        AffectationHoraireAuPlanningForm.Show()
        AffectationHoraireAuPlanningForm.TopMost = True

    End Sub

    Private Sub GunaDateTimePickerDispoFin_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDispoFin.ValueChanged
        Me.Cursor = Cursors.WaitCursor

        DisponibiliteEtTarifs(GunaDateTimePickerDispoDebut.Value.ToShortDateString, GunaDateTimePickerDispoFin.Value.ToShortDateString)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GunaDataGridViewPlanning_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanning.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPlanning.Rows(e.RowIndex)

            GunaTextBoxCodePlanning.Text = row.Cells("CODE_PLANNING").Value
            GunaTextBoxIntitulePlanning.Text = row.Cells("INTITULE_PLANNING").Value
            GunaComboBoxListeDesDepartements.SelectedValue = row.Cells("CODE_TYPE_PERSONNEL").Value.ToString

            GunaDateTimePicker1.Value = CDate(row.Cells("DATE_DEBUT").Value).ToShortDateString
            GunaDateTimePickerAu.Value = CDate(row.Cells("DATE_FIN").Value).ToShortDateString

        End If

    End Sub

    Private Sub GunaDataGridViewHoraire_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewHoraire.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewHoraire.Rows(e.RowIndex)

            GunaTextBoxCodeHoraire.Text = row.Cells("ID_HORAIRE").Value

            MaskedTextBoxheureDebut.Text = row.Cells("HEURE_DEBUT").Value
            MaskedTextBoxHureFin.Text = row.Cells("HEURE_FIN").Value

        End If

    End Sub

    Dim languageTitle As String = ""
    Dim languageMessage As String = ""

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewPlanning.Rows.Count > 0 Then

            Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxListeDesDepartements.SelectedValue.ToString

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "Do you really want to delete : " & GunaDataGridViewPlanning.CurrentRow.Cells(1).Value.ToString

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Suppression"
                languageMessage = "Voulez-vous vraiment Supprimer : " & GunaDataGridViewPlanning.CurrentRow.Cells(1).Value.ToString
            End If
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else


                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Delete"
                    languageMessage = "Assignation successfully deleted"

                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Supression"
                    languageMessage = "Planning supprimé avec succès"

                End If

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewPlanning, GunaDataGridViewPlanning.CurrentRow.Cells("CODE_PLANNING").Value.ToString, "planning_hebdomadaire", "CODE_PLANNING")

                GunaDataGridViewPlanning.Columns.Clear()

                PlannningListe(CODE_TYPE_PERSONNEL)

            End If

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "No user to be deleted!"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Supression"
                languageMessage = "Aucune utilisateur à suprimer!"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        If GunaDataGridViewPlanning.Rows.Count > 0 Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "Do you really want to delete : " & GunaDataGridViewHoraire.CurrentRow.Cells(3).Value.ToString

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Suppression"
                languageMessage = "Voulez-vous vraiment Supprimer : " & GunaDataGridViewHoraire.CurrentRow.Cells(3).Value.ToString
            End If
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else


                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Delete"
                    languageMessage = "Assignation successfully deleted"

                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Supression"
                    languageMessage = "Horaire supprimée avec succès"

                End If

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewHoraire, GunaDataGridViewHoraire.CurrentRow.Cells("ID_HORAIRE").Value.ToString, "planning_hebdomadaire_horaire", "ID_HORAIRE")

                GunaDataGridViewHoraire.Columns.Clear()

                horaireListe()

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "No user to be deleted!"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Supression"
                languageMessage = "Aucune utilisateur à suprimer!"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 0 Then
            planningContenantHoraire()
        End If

    End Sub

    Private Sub GunaComboBoxPlannintContenantHoraire_SelectedValueChanged(sender As Object, e As EventArgs) Handles GunaComboBoxPlannintContenantHoraire.SelectedValueChanged

        If GunaComboBoxPlannintContenantHoraire.SelectedIndex >= 0 Then

            Dim CODE_PLANNING As String = GunaComboBoxPlannintContenantHoraire.SelectedValue.ToString

            Dim infoSupPlanning As DataTable = Functions.getElementByCode(CODE_PLANNING, "planning_hebdomadaire", "CODE_PLANNING")

            If infoSupPlanning.Rows.Count > 0 Then
                GunaLabelDateTravaille.Text = infoSupPlanning.Rows(0)("DATE_DEBUT")
                GunaLabel7.Text = infoSupPlanning.Rows(0)("DATE_FIN")
            End If

        End If

    End Sub


    Private Sub listeDesPlanningComplet()

        'ON SELECTIONNE UNIQUEMENT LES PLANNING ASSOCIE AU PERSONNEL POUR NE PAS VOIR L'ENSEMBLE DES PLANNINGS MEME CEUX NON AFFECTES AUX PERSONNELS

        Dim query04 As String = "SELECT DISTINCT planning_horaire_personnel.CODE_TYPE_PERSONNEL, LIBELLE_TYPE_PERSONNEL FROM `planning_horaire_personnel`, type_personnel 
            WHERE planning_horaire_personnel.CODE_TYPE_PERSONNEL = type_personnel.CODE_TYPE_PERSONNEL ORDER BY CODE_TYPE_PERSONNEL ASC"

        Dim command04 As New MySqlCommand(query04, GlobalVariable.connect)
        'command04.Parameters.Add("@CODE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL

        Dim adapter04 As New MySqlDataAdapter(command04)
        Dim planningHebdomadaire As New DataTable()
        adapter04.Fill(planningHebdomadaire)

        If planningHebdomadaire.Rows.Count > 0 Then

            GunaDataGridViewPlanningHebdomadaire.DataSource = Nothing
            GunaDataGridViewPlanningHebdomadaire.DataSource = planningHebdomadaire

            If GunaDataGridViewPlanningHebdomadaire.Columns.Count - 1 Then

                For i = 0 To GunaDataGridViewPlanningHebdomadaire.Columns.Count - 1

                    If i = 0 Then
                        GunaDataGridViewPlanningHebdomadaire.Columns(i).Visible = False
                    End If

                Next

            End If

        End If

    End Sub

    Private Sub GunaDataGridViewPlanningHebdomadaire_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanningHebdomadaire.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPlanningHebdomadaire.Rows(e.RowIndex)

            Dim CODE_TYPE_PERSONNEL = row.Cells("CODE_TYPE_PERSONNEL").Value

            'SELECTION L'ENSEMEBLE DES ELEMENETS DE PLANNINGS ASSOCIES AUX PERSONNEL (SUR L'ENSEMEBLE DES SHIFTS)
            Dim infoSupPlanningHorairePersonnel As DataTable = Functions.getElementByCode(CODE_TYPE_PERSONNEL, "planning_horaire_personnel", "CODE_TYPE_PERSONNEL")

            If infoSupPlanningHorairePersonnel.Rows.Count > 0 Then

                Dim infoSupPlanning As DataTable = Functions.getElementByCode(infoSupPlanningHorairePersonnel.Rows(0)("CODE_PLANNING"), "planning_hebdomadaire", "CODE_PLANNING")

                If infoSupPlanning.Rows.Count > 0 Then
                    Impression.planningPersonnel(infoSupPlanningHorairePersonnel, infoSupPlanning)
                Else

                End If
            Else

            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        If GunaDataGridViewPlanningHebdomadaire.Rows.Count > 0 Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "Do you really want to delete : " & GunaDataGridViewPlanningHebdomadaire.CurrentRow.Cells(1).Value.ToString

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Suppression"
                languageMessage = "Voulez-vous vraiment Supprimer : " & GunaDataGridViewPlanningHebdomadaire.CurrentRow.Cells(1).Value.ToString
            End If
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Delete"
                    languageMessage = "Assignation successfully deleted"

                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Supression"
                    languageMessage = "Horaire supprimée avec succès"

                End If

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewPlanningHebdomadaire, GunaDataGridViewPlanningHebdomadaire.CurrentRow.Cells("CODE_TYPE_PERSONNEL").Value.ToString, "planning_horaire_personnel", "CODE_TYPE_PERSONNEL")

                GunaDataGridViewPlanningHebdomadaire.Columns.Clear()

                listeDesPlanningComplet()

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "No user to be deleted!"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Supression"
                languageMessage = "Aucune utilisateur à suprimer!"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
End Class