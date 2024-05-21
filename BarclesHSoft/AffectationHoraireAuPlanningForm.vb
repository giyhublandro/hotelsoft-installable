Imports MySql.Data.MySqlClient

Public Class AffectationHoraireAuPlanningForm

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonEditionDeMasse_Click(sender As Object, e As EventArgs) Handles GunaButtonEditionDeMasse.Click
        planning_horaire()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs)
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub AutoloadPlanningEtHoraire()

        '1- PLANNING HEBDOMADAIRE
        Dim plannings As String = "SELECT * FROM planning_hebdomadaire ORDER BY INTITULE_PLANNING ASC"
        Dim commandplanningsList As New MySqlCommand(plannings, GlobalVariable.connect)

        Dim adapterplanningsList As New MySqlDataAdapter(commandplanningsList)
        Dim tableplanningsList As New DataTable()
        adapterplanningsList.Fill(tableplanningsList)

        If tableplanningsList.Rows.Count > 0 Then

            GunaComboBoxPlanning.DataSource = tableplanningsList
            GunaComboBoxPlanning.ValueMember = "CODE_PLANNING"
            GunaComboBoxPlanning.DisplayMember = "INTITULE_PLANNING"

        End If

        '1- HORAIRE
        Dim horaire As String = "SELECT * FROM planning_hebdomadaire_horaire ORDER BY ID_HORAIRE ASC"
        Dim commandhorairesList As New MySqlCommand(horaire, GlobalVariable.connect)

        Dim adapterhorairesList As New MySqlDataAdapter(commandhorairesList)
        Dim tablehorairesList As New DataTable()
        adapterhorairesList.Fill(tablehorairesList)

        If tablehorairesList.Rows.Count > 0 Then

            GunaComboBoxHoraire.DataSource = tablehorairesList
            GunaComboBoxHoraire.ValueMember = "ID_HORAIRE"
            GunaComboBoxHoraire.DisplayMember = "HEURE_DEBUT_FIN"

        End If

    End Sub

    Private Sub planning_horaire()

        'Dim dateDuJour As Date = GlobalVariable.DateDeTravail

        'Dim query04 As String = "SELECT `HEURE_DEBUT`, `HEURE_FIN`, DATE_DEBUT, DATE_FIN, HEURE_DEBUT_FIN, planning_hebdomadaire_horaire.CODE_PLANNING FROM `planning_horaire`, `planning_hebdomadaire_horaire` 
        '   WHERE planning_horaire.CODE_PLANNING=@CODE_PLANNING AND planning_hebdomadaire_horaire.ID_HORAIRE =planning_horaire.ID_HORAIRE 
        '      AND DATE_FIN >='" & dateDuJour.ToString("yyyy-MM-dd") & "'"

        Dim query04 As String = "SELECT INTITULE_PLANNING , planning_horaire.DATE_DEBUT, planning_horaire.DATE_FIN, HEURE_DEBUT_FIN AS 'HORAIRE', planning_horaire.ID_HORAIRE, planning_horaire.CODE_PLANNING, ID_PLANNING_HORAIRE FROM `planning_horaire`, `planning_hebdomadaire_horaire`, planning_hebdomadaire
                        WHERE planning_hebdomadaire_horaire.ID_HORAIRE =planning_horaire.ID_HORAIRE AND planning_hebdomadaire.CODE_PLANNING=planning_horaire.CODE_PLANNING ORDER BY ID_HORAIRE DESC"

        Dim ETAT_HORAIRE_PLANNINg As Integer = 1

        Dim command04 As New MySqlCommand(query04, GlobalVariable.connect)
        'command04.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT_HORAIRE_PLANNINg
        'command04.Parameters.Add("@CODE_PLANNING", MySqlDbType.VarChar).Value = planning.Rows(i)("CODE_PLANNING")

        Dim adapter04 As New MySqlDataAdapter(command04)
        Dim horraireAffectesAuxPlannings As New DataTable()
        adapter04.Fill(horraireAffectesAuxPlannings)

        If horraireAffectesAuxPlannings.Rows.Count > 0 Then

            GunaDataGridViewPlanning.Columns.Clear()

            GunaDataGridViewPlanning.DataSource = horraireAffectesAuxPlannings

            For i = 0 To GunaDataGridViewPlanning.Columns.Count - 1

                If i > 3 Then
                    GunaDataGridViewPlanning.Columns(i).Visible = False
                End If

            Next

        End If


    End Sub

    Private Sub AffectationHoraireAuPlanningForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaDateTimePickerDispoDebut.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerDispoFin.Value = GlobalVariable.DateDeTravail

        AutoloadPlanningEtHoraire()

    End Sub

    Private Sub GunaButtonAppliquerTarifSpecifique_Click(sender As Object, e As EventArgs) Handles GunaButtonAppliquerTarifSpecifique.Click

        Dim ID_PLANNING_HORAIRE = GunaTextBoxID_HORAIRE_PLANNING.Text
        Dim CODE_PLANNING As String = GunaComboBoxPlanning.SelectedValue.ToString
        Dim ID_HORAIRE As Integer = GunaComboBoxHoraire.SelectedValue
        Dim DATE_DEBUT As Date = GunaDateTimePickerDispoDebut.Value.ToShortDateString
        Dim DATE_FIN As Date = GunaDateTimePickerDispoFin.Value.ToShortDateString

        Dim service As New ServicesEtage()

        If GunaButtonAppliquerTarifSpecifique.Text = "Modifier" Or GunaButtonAppliquerTarifSpecifique.Text = "Modify" Then

            Functions.DeleteElementByCode(ID_PLANNING_HORAIRE, "planning_horaire", "ID_PLANNING_HORAIRE")

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAppliquerTarifSpecifique.Text = "Affecter"
            ElseIf GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonAppliquerTarifSpecifique.Text = "Assign"
            End If

        End If

        service.insertHorairePlanning(CODE_PLANNING, ID_HORAIRE, DATE_DEBUT, DATE_FIN)

        GunaTextBoxID_HORAIRE_PLANNING.Text = ""

        planning_horaire()

        Me.Cursor = Cursors.WaitCursor

        PlanningHebdomadaireDuPersonnelForm.DisponibiliteEtTarifs(PlanningHebdomadaireDuPersonnelForm.GunaDateTimePickerDispoDebut.Value.ToShortDateString, PlanningHebdomadaireDuPersonnelForm.GunaDateTimePickerDispoFin.Value.ToShortDateString)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GunaDateTimePickerDispoDebut_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDispoDebut.ValueChanged

        GunaDateTimePickerDispoFin.Value = GunaDateTimePickerDispoDebut.Value

    End Sub

    Private Sub GunaButtonTerminer_Click(sender As Object, e As EventArgs) Handles GunaButtonTerminer.Click
        Me.Cursor = Cursors.WaitCursor

        PlanningHebdomadaireDuPersonnelForm.DisponibiliteEtTarifs(PlanningHebdomadaireDuPersonnelForm.GunaDateTimePickerDispoDebut.Value.ToShortDateString, PlanningHebdomadaireDuPersonnelForm.GunaDateTimePickerDispoFin.Value.ToShortDateString)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GunaDataGridViewPlanning_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanning.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPlanning.Rows(e.RowIndex)

            GunaTextBoxID_HORAIRE_PLANNING.Text = row.Cells("ID_PLANNING_HORAIRE").Value

            GunaComboBoxPlanning.SelectedValue = row.Cells("CODE_PLANNING").Value
            GunaComboBoxHoraire.SelectedValue = row.Cells("ID_HORAIRE").Value
            GunaDateTimePickerDispoDebut.Value = CDate(row.Cells("DATE_DEBUT").Value).ToShortDateString
            GunaDateTimePickerDispoFin.Value = CDate(row.Cells("DATE_FIN").Value).ToShortDateString

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAppliquerTarifSpecifique.Text = "Modifier"
            ElseIf GlobalVariable.actualLanguageValue = 2 Then
                GunaButtonAppliquerTarifSpecifique.Text = "Modify"
            End If

        End If

    End Sub


    Dim languageTitle As String = ""
    Dim languageMessage As String = ""

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewPlanning.Rows.Count > 0 Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "Do you really want to delete : " & GunaDataGridViewPlanning.CurrentRow.Cells(0).Value.ToString & " " & GunaDataGridViewPlanning.CurrentRow.Cells(3).Value.ToString

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Suppression"
                languageMessage = "Voulez-vous vraiment Supprimer : " & GunaDataGridViewPlanning.CurrentRow.Cells(0).Value.ToString & " " & GunaDataGridViewPlanning.CurrentRow.Cells(3).Value.ToString
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
                    languageMessage = "Affectation supprimée avec succès"

                End If

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewPlanning, GunaDataGridViewPlanning.CurrentRow.Cells("ID_PLANNING_HORAIRE").Value.ToString, "planning_horaire", "ID_PLANNING_HORAIRE")

                GunaDataGridViewPlanning.Columns.Clear()

                planning_horaire()

                Me.Cursor = Cursors.WaitCursor

                PlanningHebdomadaireDuPersonnelForm.DisponibiliteEtTarifs(PlanningHebdomadaireDuPersonnelForm.GunaDateTimePickerDispoDebut.Value.ToShortDateString, PlanningHebdomadaireDuPersonnelForm.GunaDateTimePickerDispoFin.Value.ToShortDateString)

                Me.Cursor = Cursors.Default

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