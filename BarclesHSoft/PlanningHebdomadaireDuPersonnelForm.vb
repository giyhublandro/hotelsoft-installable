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

            GunaDataGridViewPlanning.Columns.Add("ID_PLANNING_HEBDOMADAIRE", "ID_PLANNING_HEBDOMADAIRE")
            GunaDataGridViewPlanning.Columns.Add("PLANNING", "PLANNING")
            GunaDataGridViewPlanning.Columns.Add("CODE_PLANNING", "CODE_PLANNING")
            GunaDataGridViewPlanning.Columns.Add("DATE_DEBUT", "DATE_DEBUT")
            GunaDataGridViewPlanning.Columns.Add("DATE_FIN", "DATE_FIN")
            GunaDataGridViewPlanning.Columns.Add("CODE_TYPE_PERSONNEL", "CODE_TYPE_PERSONNEL")

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaDataGridViewPlanning.Columns.Add("DATE", "CREATION DATE")
            Else
                GunaDataGridViewPlanning.Columns.Add("DATE", "DATE CREATION")
            End If
            GunaDataGridViewPlanning.Columns.Add("CODE_AGENCE", "CODE_AGENCE")

            For k = 0 To infoPlanning.Rows.Count - 1
                GunaDataGridViewPlanning.Rows.Add(infoPlanning.Rows(k)(0), infoPlanning.Rows(k)(1), infoPlanning.Rows(k)(2), infoPlanning.Rows(k)(3), infoPlanning.Rows(k)(4), infoPlanning.Rows(k)(5), infoPlanning.Rows(k)(6), infoPlanning.Rows(k)(7))
            Next

            For i = 0 To GunaDataGridViewPlanning.Columns.Count - 1

                If Not i = 1 Then
                    GunaDataGridViewPlanning.Columns(i).Visible = False
                End If

            Next

        End If


    End Sub

    Private Sub planningContenantHoraire()

        Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxTypePersonnel.SelectedValue.ToString

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
            GunaDataGridViewHoraire.Columns.Add("ID_HORAIRE", "ID_HORAIRE")
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaDataGridViewHoraire.Columns.Add("HEURE_DEBUT", "HEURE DEBUT")
                GunaDataGridViewHoraire.Columns.Add("HEURE_FIN", "HEURE FIN")
                GunaDataGridViewHoraire.Columns.Add("HEURE_DEBUT_FIN", "DEBUT - FIN")
            Else
                GunaDataGridViewHoraire.Columns.Add("HEURE_DEBUT", "START TIME")
                GunaDataGridViewHoraire.Columns.Add("HEURE_FIN", "END TIME")
                GunaDataGridViewHoraire.Columns.Add("HEURE_DEBUT_FIN", "START - END")
            End If
            GunaDataGridViewHoraire.Columns.Add("DATE_DE_CONTROLE", "DATE_DE_CONTROLE")
            GunaDataGridViewHoraire.Columns.Add("CODE_PLANNING", "CODE_PLANNING")
            'GunaDataGridViewHoraire.DataSource = infoPlanning

            For k = 0 To infoPlanning.Rows.Count - 1
                GunaDataGridViewHoraire.Rows.Add(infoPlanning.Rows(k)(0), infoPlanning.Rows(k)(1), infoPlanning.Rows(k)(2), infoPlanning.Rows(k)(3), infoPlanning.Rows(k)(4), infoPlanning.Rows(k)(5))
            Next

            For i = 0 To GunaDataGridViewHoraire.Columns.Count - 1

                If i = 0 Or i > 3 Then
                    GunaDataGridViewHoraire.Columns(i).Visible = False
                End If

            Next

        End If


    End Sub

    Private Sub PlanningHebdomadaireDuPersonnelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.PlanningHebdomadaireDuPersonnel(GlobalVariable.actualLanguageValue)

        setPlanningDateAndTime()

        'GunaDateTimePickerDispoDebut.Value = GlobalVariable.DateDeTravail.ToShortDateString

        GunaDateTimePickerDispoFin.Value = GunaDateTimePickerDispoDebut.Value.AddDays(7)

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

        'GunaDateTimePickerDispoFin.Value = GunaDateTimePickerDispoDebut.Value.AddDays(12)

        GunaDataGridViewFolio1.Columns.Clear()
        GunaDataGridViewFolio2.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaDataGridViewFolio1.Columns.Add("CODE_PRESONNEL", "CODE PRESONNEL")
            GunaDataGridViewFolio1.Columns.Add("MATRICULE", "MATRICULE")
            GunaDataGridViewFolio1.Columns.Add("NOM", "NOM")
            GunaDataGridViewFolio1.Columns.Add("PRENOM", "PRENOM")
            GunaDataGridViewFolio1.Columns.Add("POST", "POSTE")
            GunaDataGridViewFolio1.Columns.Add("SHIFT", "SHIFT")
            GunaDataGridViewFolio1.Columns.Add("OFF_DAY", "OFF")
            GunaDataGridViewFolio1.Columns.Add("SHIFT_CODE", "SHIFT CODE")

            GunaDataGridViewFolio2.Columns.Add("CODE_PRESONNEL", "CODE PRESONNEL")
            GunaDataGridViewFolio2.Columns.Add("MATRICULE", "MATRICULE")
            GunaDataGridViewFolio2.Columns.Add("NOM", "NOM")
            GunaDataGridViewFolio2.Columns.Add("PRENOM", "PRENOM")
            GunaDataGridViewFolio2.Columns.Add("POST", "POSTE")
            GunaDataGridViewFolio2.Columns.Add("SHIFT", "SHIFT")
            GunaDataGridViewFolio2.Columns.Add("OFF_DAY", "OFF")
            GunaDataGridViewFolio2.Columns.Add("SHIFT_CODE", "SHIFT CODE")
        Else
            GunaDataGridViewFolio1.Columns.Add("CODE_PRESONNEL", "CODE PRESONNEL")
            GunaDataGridViewFolio1.Columns.Add("MATRICULE", "MATRICULE")
            GunaDataGridViewFolio1.Columns.Add("FIRST_NAME", "FIRST NAME")
            GunaDataGridViewFolio1.Columns.Add("LAST_NAME", "LAST NAME")
            GunaDataGridViewFolio1.Columns.Add("POST", "POST")
            GunaDataGridViewFolio1.Columns.Add("SHIFT", "SHIFT")
            GunaDataGridViewFolio1.Columns.Add("OFF_DAY", "OFF")
            GunaDataGridViewFolio1.Columns.Add("SHIFT_CODE", "SHIFT CODE")

            GunaDataGridViewFolio2.Columns.Add("CODE_PRESONNEL", "CODE PRESONNEL")
            GunaDataGridViewFolio2.Columns.Add("MATRICULE", "MATRICULE")
            GunaDataGridViewFolio2.Columns.Add("FIRST_NAME", "FIRST NAME")
            GunaDataGridViewFolio2.Columns.Add("LAST_NAME", "LAST NAME")
            GunaDataGridViewFolio2.Columns.Add("POST", "POST")
            GunaDataGridViewFolio2.Columns.Add("SHIFT", "SHIFT")
            GunaDataGridViewFolio2.Columns.Add("OFF_DAY", "OFF")
            GunaDataGridViewFolio2.Columns.Add("SHIFT_CODE", "SHIFT CODE")
        End If

        GunaDataGridViewFolio1.Columns(0).Visible = False
        GunaDataGridViewFolio2.Columns(0).Visible = False

        GunaDataGridViewFolio1.Columns(1).Visible = False
        GunaDataGridViewFolio2.Columns(1).Visible = False

        GunaDataGridViewFolio1.Columns(6).Visible = False
        GunaDataGridViewFolio1.Columns(5).Visible = False
        GunaDataGridViewFolio2.Columns(4).Visible = False

        GunaDataGridViewFolio1.Columns(4).Visible = False

        GunaDataGridViewFolio1.Columns(7).Visible = False
        GunaDataGridViewFolio2.Columns(7).Visible = False

        Dim showCustomImage As Boolean = False

        If GlobalVariable.AgenceActuelle.Rows(0)("CONFIG") = 1 Then
            If GlobalVariable.config.Rows.Count > 0 Then
                showCustomImage = True
            End If
        End If

        If showCustomImage Then

            Dim buttonPanel As Integer = 1
            GunaPanel1.BackColor = Functions.colorationWindow(buttonPanel)
            GunaPanel3.BackColor = Functions.colorationWindow(buttonPanel)

            buttonPanel = 0
            GunaButtonMoveLeftToRight.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonAllToRight.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonMoveRightToLeft.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonAllToLeft.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButton3.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonEnregistrerPlanning.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButton1.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButton2.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButton16.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonEditionDeMasse.BaseColor = Functions.colorationWindow(buttonPanel)

            buttonPanel = 2
            GunaButtonMoveLeftToRight.ForeColor = Functions.colorationWindow(buttonPanel)
            GunaButtonAllToRight.ForeColor = Functions.colorationWindow(buttonPanel)

        End If

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

                'GunaDataGridViewFolio1.Columns("CODE").Visible = False
                'GunaDataGridViewFolio2.Columns("CODE_PERSONNEL").Visible = False

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

            'GunaLabelDbutProg.Text = GunaDateTimePicker1.Value.ToLongDateString()

        Else

            'Initialisation du temps du planning 
            GunaDateTimePicker1.Value = Date.Now().ToLongDateString

            'GunaLabelDbutProg.Text = GunaDateTimePicker1.Value.ToLongDateString()

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

            GunaComboBoxProfilPlanning.DataSource = tableprofilsList
            GunaComboBoxProfilPlanning.ValueMember = "CODE_TYPE_PERSONNEL"
            GunaComboBoxProfilPlanning.DisplayMember = "LIBELLE_TYPE_PERSONNEL"

        End If

    End Sub

    Private Sub autoLoadProfilPlanning()

        Dim profils As String = "SELECT CODE_TYPE_PERSONNEL, LIBELLE_TYPE_PERSONNEL FROM type_personnel ORDER BY LIBELLE_TYPE_PERSONNEL ASC"
        Dim commandprofilsList As New MySqlCommand(profils, GlobalVariable.connect)

        Dim adapterprofilsList As New MySqlDataAdapter(commandprofilsList)
        Dim tableprofilsList As New DataTable()
        adapterprofilsList.Fill(tableprofilsList)

        If tableprofilsList.Rows.Count > 0 Then

            GunaComboBoxProfilPlanning.DataSource = tableprofilsList
            GunaComboBoxProfilPlanning.ValueMember = "CODE_TYPE_PERSONNEL"
            GunaComboBoxProfilPlanning.DisplayMember = "LIBELLE_TYPE_PERSONNEL"

        End If

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
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
        Dim CODE_PROGRAMME As String = Functions.GeneratingRandomCodeWithSpecifications("planning", "")

        Dim CODE_PLANNING As String = ""
        If GunaComboBoxPlannintContenantHoraire.SelectedIndex >= 0 Then
            CODE_PLANNING = GunaComboBoxPlannintContenantHoraire.SelectedValue.ToString()
        End If

        Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxTypePersonnel.SelectedValue.ToString
        Dim DATE_DEBUT As Date = GunaDateTimePicker1.Value.ToShortDateString()
        Dim HEURE_DEBUT As DateTime = GunaDateTimePickerAu.Value.ToShortTimeString()

        Dim DEBUT_PROG As Date = GunaDateTimePickerProgStartDate.Value.ToShortDateString
        Dim CODE_PERSONNEL As String = ""

        Dim DAY_OFF As Date
        Dim service As New ServicesEtage

        For i = 0 To GunaDataGridViewFolio2.Rows.Count - 1

            DAY_OFF = CDate(GunaDataGridViewFolio2.Rows(i).Cells(6).Value.ToString).ToShortDateString
            CODE_PERSONNEL = GunaDataGridViewFolio2.Rows(i).Cells(0).Value.ToString
            CODE_PLANNING = GunaDataGridViewFolio2.Rows(i).Cells(7).Value.ToString
            service.insertPlanningHorairePersonnel(CODE_PLANNING_HORAIRE_PERSONNEL, CODE_PERSONNEL, CODE_TYPE_PERSONNEL, CODE_PLANNING, DEBUT_PROG, CODE_PROGRAMME, DAY_OFF)

        Next

        Dim DATE_DEBUT_PROG = GunaDateTimePickerProgStartDate.Value.ToShortDateString
        Dim DATE_FIN_PROG = GunaDateTimePickerProgStartDate.Value.AddDays(6).ToShortDateString
        Dim INTITULE_DEPARTMENT = ""

        Dim infoSup As DataTable = Functions.getElementByCode(CODE_TYPE_PERSONNEL, "type_personnel", "CODE_TYPE_PERSONNEL")
        If infoSup.Rows.Count > 0 Then
            INTITULE_DEPARTMENT = infoSup.Rows(0)("LIBELLE_TYPE_PERSONNEL")
        End If

        service.insertPlanning(DATE_DEBUT_PROG, DATE_FIN_PROG, CODE_TYPE_PERSONNEL, INTITULE_DEPARTMENT, CODE_PROGRAMME)

        '-----------------------------------------------------------------------------------------------------------------------

        service.planning_programme(CODE_TYPE_PERSONNEL, CODE_PROGRAMME, DATE_DEBUT_PROG, DATE_FIN_PROG)

        '-----------------------------------------------------------------------------------------------------------------------

        If GlobalVariable.actualLanguageValue = 1 Then
            MessageBox.Show("Personnel affecté au " & GunaLabelDbutProg.Text & " avec succès", "PLanning Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Personnel successfully affected on " & GunaLabelDbutProg.Text, "Personnel PLanning", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

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

        Dim SHIFT As String = GunaComboBoxPlannintContenantHoraire.SelectedValue.ToString
        Dim DAY_OFF As Date

        If GunaCheckBoxOff.Checked Then
            DAY_OFF = GunaDateTimePickerOffDay.Value.ToShortDateString
        End If

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then

            Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
            GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
            GunaDataGridViewFolio2.Rows.Add(selectedgrid)

            Dim index As Integer = GunaDataGridViewFolio2.Rows.Count - 1
            GunaDataGridViewFolio2.Rows(index).Cells(5).Value = SHIFT

            Dim infoShift As DataTable = Functions.getElementByCode(SHIFT, "planning_hebdomadaire", "CODE_PLANNING")
            If infoShift.Rows.Count > 0 Then
                GunaDataGridViewFolio2.Rows(index).Cells(5).Value = infoShift.Rows(0)("INTITULE_PLANNING")
            End If

            GunaDataGridViewFolio2.Rows(index).Cells(6).Value = DAY_OFF.ToShortDateString
            GunaDataGridViewFolio2.Rows(index).Cells(7).Value = SHIFT

        End If

        activateSave()

        GunaCheckBoxOff.Checked = False

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

        Dim SHIFT As String = GunaComboBoxPlannintContenantHoraire.SelectedValue.ToString
        Dim DAY_OFF As Date

        If GunaCheckBoxOff.Checked Then
            DAY_OFF = GunaDateTimePickerOffDay.Value.ToShortDateString
        End If

        If GunaDataGridViewFolio1.SelectedRows.Count > 0 Then

            Do While GunaDataGridViewFolio1.SelectedRows.Count > 0

                Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)
                GunaDataGridViewFolio1.Rows.Remove(selectedgrid)
                GunaDataGridViewFolio2.Rows.Add(selectedgrid)

                Dim index As Integer = GunaDataGridViewFolio2.Rows.Count - 1
                GunaDataGridViewFolio2.Rows(index).Cells(5).Value = SHIFT

                GunaDataGridViewFolio2.Rows(index).Cells(6).Value = DAY_OFF.ToShortDateString

                Dim infoShift As DataTable = Functions.getElementByCode(SHIFT, "planning_hebdomadaire", "CODE_PLANNING")
                If infoShift.Rows.Count > 0 Then
                    GunaDataGridViewFolio2.Rows(index).Cells(5).Value = infoShift.Rows(0)("INTITULE_PLANNING")
                End If

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

            listeDesPlanningComplet()

        End If

    End Sub

    Private Sub GunaDateTimePickerAu_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerAu.ValueChanged

        GunaLabelFinProg.Text = GunaDateTimePickerAu.Value.ToLongDateString

        activateSave()

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        If GunaComboBoxListeDesDepartements.SelectedIndex > 0 Then

            If Trim(GunaTextBoxIntitulePlanning.Text).Equals("") Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Bien vouloir donner un intitulé au planning ", "Planning Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Please give a Title to your planning ", "Personnel Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

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

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir choisir un département ", "Planning Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please choose a department ", "Personnel Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

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

        Dim CODE_TYPE_PERSONNEL As String = ""
        If GunaComboBoxProfilPlanning.SelectedIndex > 0 Then
            CODE_TYPE_PERSONNEL = GunaComboBoxProfilPlanning.SelectedValue.ToString
        End If

        Dim existQuery As String = "SELECT * From planning_hebdomadaire WHERE CODE_TYPE_PERSONNEL=@CODE_TYPE_PERSONNEL ORDER BY INTITULE_PLANNING ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
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
                'GunaDataGridViewPlanningHoraire.Columns.Add(DateDebut.AddDays(k).ToString("ddd d MMM"), DateDebut.AddDays(k).ToString("ddd d MMM"))
                GunaDataGridViewPlanningHoraire.Columns.Add(DateDebut.AddDays(k).ToString("dddd"), DateDebut.AddDays(k).ToString("dddd"))
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

            If GunaDataGridViewPlanningHoraire.Rows.Count > 0 Then
                GunaDataGridViewPlanningHoraire.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If

        End If

    End Sub

    Structure enteteDuTableauDispobiliteEtTarif
        Dim planning As String
        Dim rowIndex As Integer
        Dim colonneIndex As Integer
    End Structure


    Private Sub GunaButtonEditionDeMasse_Click(sender As Object, e As EventArgs) Handles GunaButtonEditionDeMasse.Click

        AffectationHoraireAuPlanningForm.GunaTextBoxCodeDepart.Text = GunaComboBoxProfilPlanning.SelectedValue.ToString
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

            GunaTextBoxCodePlanning.Text = row.Cells(2).Value
            GunaTextBoxIntitulePlanning.Text = row.Cells(1).Value
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

        If GunaDataGridViewHoraire.Rows.Count > 0 Then

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "Do you really want to delete : " & GunaDataGridViewHoraire.CurrentRow.Cells(3).Value.ToString

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Suppression"
                languageMessage = "Voulez-vous vraiment Supprimer : " & GunaDataGridViewHoraire.CurrentRow.Cells(3).Value.ToString
            End If
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.Yes Then

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Delete"
                    languageMessage = "Hours successfully deleted"

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
                languageMessage = "No hours to be deleted!"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Supression"
                languageMessage = "Aucune Horaire à supprimer!"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 0 Then
            planningContenantHoraire()
        End If

        If TabControl1.SelectedIndex = 2 Then

        End If

    End Sub

    Private Sub GunaComboBoxPlannintContenantHoraire_SelectedValueChanged(sender As Object, e As EventArgs) Handles GunaComboBoxPlannintContenantHoraire.SelectedValueChanged

        If GunaComboBoxPlannintContenantHoraire.SelectedIndex >= 0 Then

            Dim CODE_PLANNING As String = GunaComboBoxPlannintContenantHoraire.SelectedValue.ToString

            Dim infoSupPlanning As DataTable = Functions.getElementByCode(CODE_PLANNING, "planning_hebdomadaire", "CODE_PLANNING")

            If infoSupPlanning.Rows.Count > 0 Then
                'GunaLabelDbutProg.Text = infoSupPlanning.Rows(0)("DATE_DEBUT")
                'GunaLabelFinProg.Text = infoSupPlanning.Rows(0)("DATE_FIN")
            End If

        End If

    End Sub


    Private Sub listeDesPlanningComplet()

        'ON SELECTIONNE UNIQUEMENT LES PLANNING ASSOCIE AU PERSONNEL POUR NE PAS VOIR L'ENSEMBLE DES PLANNINGS MEME CEUX NON AFFECTES AUX PERSONNELS
        Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxTypePersonnel.SelectedValue.ToString
        Dim query As String = ""
        If GlobalVariable.actualLanguageValue = 1 Then
            query = "SELECT `CODE_PROGRAMME`,`CODE_TYPE_PERSONNEL`,`INTITULE_DEPARTMENT` AS 'DEPARTEMENT', `DATE_DEBUT_PROG` AS DU ,`DATE_FIN_PROG` AS AU FROM `planning` WHERE CODE_TYPE_PERSONNEL=@CODE_TYPE_PERSONNEL ORDER BY DATE_DEBUT_PROG DESC"
        Else
            query = "SELECT `CODE_PROGRAMME`,`CODE_TYPE_PERSONNEL`, `INTITULE_DEPARTMENT` AS DEPARTMENT, `DATE_DEBUT_PROG` AS 'FROM', `DATE_FIN_PROG` AS 'TO' FROM `planning` WHERE CODE_TYPE_PERSONNEL=@CODE_TYPE_PERSONNEL ORDER BY DATE_DEBUT_PROG DESC"
        End If
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL


        Dim adapter As New MySqlDataAdapter(command)
        Dim dt As New DataTable()
        adapter.Fill(dt)

        GunaDataGridViewPlanningHebdomadaire.DataSource = Nothing

        If dt.Rows.Count > 0 Then
            GunaDataGridViewPlanningHebdomadaire.DataSource = dt
            GunaDataGridViewPlanningHebdomadaire.Columns(0).Visible = False
            GunaDataGridViewPlanningHebdomadaire.Columns(1).Visible = False
        End If

    End Sub

    Private Sub GunaDataGridViewPlanningHebdomadaire_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanningHebdomadaire.CellDoubleClick

        If GunaDataGridViewPlanningHebdomadaire.CurrentRow.Selected Then

            Dim row As DataGridViewRow
            row = Me.GunaDataGridViewPlanningHebdomadaire.Rows(e.RowIndex)

            Dim CODE_TYPE_PERSONNEL = row.Cells("CODE_TYPE_PERSONNEL").Value
            Dim CODE_PROGRAMME = row.Cells("CODE_PROGRAMME").Value

            'SELECTION DE L'ENSEMEBLE DES ELEMENETS DE PLANNINGS ASSOCIES AUX PERSONNEL (SUR L'ENSEMEBLE DES SHIFTS)
            Dim infoSupPlanningHorairePersonnel As DataTable = Functions.getElementByCode(CODE_PROGRAMME, "planning_horaire_personnel", "CODE_PROGRAMME")

            If infoSupPlanningHorairePersonnel.Rows.Count > 0 Then

                Dim infoSupPlanning As DataTable = Functions.getElementByCode(infoSupPlanningHorairePersonnel.Rows(0)("CODE_TYPE_PERSONNEL"), "planning_hebdomadaire", "CODE_TYPE_PERSONNEL")

                If infoSupPlanning.Rows.Count > 0 Then
                    Impression.planningPersonnel(infoSupPlanningHorairePersonnel, infoSupPlanning)
                End If

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

            If dialog = DialogResult.Yes Then

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

    Private Sub GunaDateTimePickerDispoDebut_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDispoDebut.ValueChanged
        GunaDateTimePickerDispoFin.Value = GunaDateTimePickerDispoDebut.Value.AddDays(7)
    End Sub

    Private Sub GunaComboBoxProfilPlanning_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxProfilPlanning.SelectedIndexChanged

        GunaDataGridViewPlanningHoraire.Columns.Clear()

        If GunaComboBoxProfilPlanning.SelectedIndex > 0 Then
            GunaButtonEditionDeMasse.Visible = True
        Else
            GunaButtonEditionDeMasse.Visible = False
        End If

    End Sub

    Private Sub GunaDateTimePickerProgStartDate_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerProgStartDate.ValueChanged

        GunaLabelDbutProg.Text = GunaDateTimePickerProgStartDate.Value.ToLongDateString
        GunaLabelFinProg.Text = GunaDateTimePickerProgStartDate.Value.AddDays(6).ToLongDateString

        Dim ActualDate As Date = GunaDateTimePickerProgStartDate.Value
        Dim dateDeTravail As Date = GlobalVariable.DateDeTravail

        GunaDateTimePickerOffDay.MaxDate = GunaDateTimePickerProgStartDate.Value.AddDays(6).ToShortDateString
        GunaDateTimePickerOffDay.MinDate = ActualDate

    End Sub

    Private Sub GunaDataGridViewPlanningHebdomadaire_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanningHebdomadaire.CellClick

        If GunaDataGridViewPlanningHebdomadaire.CurrentRow.Selected Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPlanningHebdomadaire.Rows(e.RowIndex)

            Dim CODE_PROGRAMME = row.Cells("CODE_PROGRAMME").Value

            AffichageDetailProgramme(CODE_PROGRAMME)

        End If



    End Sub

    Private Sub AffichageDetailProgramme(ByVal CODE_PROGRAMME As String)

        Dim dt As DataTable = Functions.getElementByCode(CODE_PROGRAMME, "planning_horaire_personnel", "CODE_PROGRAMME")
        Dim CODE_PERSONNEL As String = ""
        Dim NOM_PERSONNEL As String = ""
        Dim PRENOM_PERSONNEL As String = ""
        Dim CODE_PLANNING As String = ""
        Dim SHIFT As String = ""
        Dim ID As Integer = 0
        Dim DAY_OFF As Date

        GunaDataGridViewDetailPlanning.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 1 Then

            GunaDataGridViewDetailPlanning.Columns.Add("ID", "ID")
            GunaDataGridViewDetailPlanning.Columns.Add("CODE_PLANNING_HORAIRE_PERSONNEL", "CODE PRESONNEL")
            GunaDataGridViewDetailPlanning.Columns.Add("NOM", "NOM")
            GunaDataGridViewDetailPlanning.Columns.Add("PRENOM", "PRENOM")
            GunaDataGridViewDetailPlanning.Columns.Add("SHIFT", "SHIFT")
            GunaDataGridViewDetailPlanning.Columns.Add("CODE_PROGRAMME", "CODE_PROGRAMME")
            GunaDataGridViewDetailPlanning.Columns.Add("OFF", "OFF")

        Else

            GunaDataGridViewDetailPlanning.Columns.Add("ID", "ID")
            GunaDataGridViewDetailPlanning.Columns.Add("CODE_PLANNING_HORAIRE_PERSONNEL", "CODE PRESONNEL")
            GunaDataGridViewDetailPlanning.Columns.Add("FIRST_NAME", "FIRST NAME")
            GunaDataGridViewDetailPlanning.Columns.Add("LAST_NAME", "LAST NAME")
            GunaDataGridViewDetailPlanning.Columns.Add("SHIFT", "SHIFT")
            GunaDataGridViewDetailPlanning.Columns.Add("CODE_PROGRAMME", "CODE_PROGRAMME")
            GunaDataGridViewDetailPlanning.Columns.Add("OFF", "OFF")

        End If

        If dt.Rows.Count > 0 Then

            For i = 0 To dt.Rows.Count - 1
                ID = dt.Rows(i)("ID_PLANNING_HORAIRE_PERSONNEL")
                CODE_PERSONNEL = dt.Rows(i)("CODE_PERSONNEL")
                CODE_PLANNING = dt.Rows(i)("CODE_PLANNING")
                CODE_PROGRAMME = dt.Rows(i)("CODE_PROGRAMME")
                DAY_OFF = dt.Rows(i)("DAY_OFF")
                Dim infoPerso As DataTable = Functions.getElementByCode(CODE_PERSONNEL, "personnel", "CODE_PERSONNEL")
                If infoPerso.Rows.Count > 0 Then
                    NOM_PERSONNEL = infoPerso.Rows(0)("NOM_PERSONNEL")
                    PRENOM_PERSONNEL = infoPerso.Rows(0)("PRENOM_PERSONNEL")
                End If

                Dim infoPlan As DataTable = Functions.getElementByCode(CODE_PLANNING, "planning_hebdomadaire", "CODE_PLANNING")
                If infoPlan.Rows.Count > 0 Then
                    SHIFT = infoPlan.Rows(0)("INTITULE_PLANNING")
                End If
                GunaDataGridViewDetailPlanning.Rows.Add(ID, dt.Rows(i)("CODE_PLANNING_HORAIRE_PERSONNEL"), NOM_PERSONNEL, PRENOM_PERSONNEL, SHIFT, CODE_PROGRAMME, CDate(DAY_OFF).ToShortDateString)
            Next

            GunaDataGridViewDetailPlanning.Rows(0).Selected = True

        End If

        GunaDataGridViewDetailPlanning.Columns(0).Visible = False
        GunaDataGridViewDetailPlanning.Columns(1).Visible = False
        GunaDataGridViewDetailPlanning.Columns(5).Visible = False

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        If GunaDataGridViewDetailPlanning.CurrentRow.Selected Then

            Dim CODE_PROGRAMME As String = GunaDataGridViewDetailPlanning.CurrentRow.Cells(5).Value.ToString

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "Do you really want to delete : " & GunaDataGridViewDetailPlanning.CurrentRow.Cells(1).Value.ToString

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Suppression"
                languageMessage = "Voulez-vous vraiment Supprimer : " & GunaDataGridViewDetailPlanning.CurrentRow.Cells(1).Value.ToString
            End If
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.Yes Then

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Delete"
                    languageMessage = "Shift successfully deleted"

                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Supression"
                    languageMessage = "Shift supprimé avec succès"
                End If

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewDetailPlanning, GunaDataGridViewDetailPlanning.CurrentRow.Cells("ID").Value.ToString, "planning_horaire_personnel", "ID_PLANNING_HORAIRE_PERSONNEL")

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                AffichageDetailProgramme(CODE_PROGRAMME)

            End If

        End If
    End Sub

    Private Sub GunaCheckBoxOff_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxOff.CheckedChanged
        If GunaCheckBoxOff.Checked Then
            GunaDateTimePickerOffDay.Enabled = True
        Else
            GunaDateTimePickerOffDay.Enabled = False
        End If
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click

        Dim row As DataGridViewRow
        'row = Me.GunaDataGridViewPlanningHebdomadaire.Rows(e.RowIndex)

        'Dim CODE_TYPE_PERSONNEL = row.Cells("CODE_TYPE_PERSONNEL").Value
        'Dim CODE_PROGRAMME = row.Cells("CODE_PROGRAMME").Value

        Dim DateDeSituation As Date = GunaDateTimePicker2.Value.ToShortDateString
        Dim getUserQuery = "SELECT DISTINCT CODE_PROGRAMME FROM planning_horaire_personnel WHERE DEBUT_PROG >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DEBUT_PROG <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "'"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Dim adapter As New MySqlDataAdapter
        Dim infoSupPlanningHorairePersonnel As New DataTable()
        adapter.SelectCommand = command
        adapter.Fill(infoSupPlanningHorairePersonnel)

        If infoSupPlanningHorairePersonnel.Rows.Count > 0 Then
            Impression.planningPersonnelGlobal(infoSupPlanningHorairePersonnel, GunaDateTimePicker2.Value.ToShortDateString)
        End If

    End Sub

End Class