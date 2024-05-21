Public Class TimePickerForm

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        If GunaLabelTitreHeure.Text = "HEURE DE DEPART" Then
            MainWindow.GunaComboBoxHeureDepart.Items.Remove(MainWindow.GunaComboBoxHeureDepart.SelectedItem)
            MainWindow.GunaComboBoxHeureDepart.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureDepart.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "HEURE D'ARRIVEE" Then
            MainWindow.GunaComboBoxHeureArrivee.Items.Remove(MainWindow.GunaComboBoxHeureArrivee.SelectedItem)
            MainWindow.GunaComboBoxHeureArrivee.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureArrivee.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "HEURE PAUSE CAFE" Then
            MainWindow.GunaComboBoxHeureCafe.Items.Remove(MainWindow.GunaComboBoxHeureCafe.SelectedItem)
            MainWindow.GunaComboBoxHeureCafe.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureCafe.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "HEURE PAUSE DEJEUNER" Then
            MainWindow.GunaComboBoxHeureDej.Items.Remove(MainWindow.GunaComboBoxHeureDej.SelectedItem)
            MainWindow.GunaComboBoxHeureDej.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureDej.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "HEURE PAUSE DINER" Then
            MainWindow.GunaComboBoxHeureDiner.Items.Remove(MainWindow.GunaComboBoxHeureDiner.SelectedItem)
            MainWindow.GunaComboBoxHeureDiner.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureDiner.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "HEURE DU GOUTER" Then
            MainWindow.GunaComboBoxHeureGouter.Items.Remove(MainWindow.GunaComboBoxHeureGouter.SelectedItem)
            MainWindow.GunaComboBoxHeureGouter.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureGouter.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "HEURE DU COCKTAIL" Then
            MainWindow.GunaComboBoxHeureCocktail.Items.Remove(MainWindow.GunaComboBoxHeureCocktail.SelectedItem)
            MainWindow.GunaComboBoxHeureCocktail.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureCocktail.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "HEURE DE DEPART NAVETTE" Then
            MainWindow.GunaComboBoxHeureDepartNavette.Items.Remove(MainWindow.GunaComboBoxHeureDepartNavette.SelectedItem)
            MainWindow.GunaComboBoxHeureDepartNavette.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureDepartNavette.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "HEURE D'ARRIVER NAVETTE" Then
            MainWindow.GunaComboBoxHeureNavetteArrivee.Items.Remove(MainWindow.GunaComboBoxHeureNavetteArrivee.SelectedItem)
            MainWindow.GunaComboBoxHeureNavetteArrivee.Items.Add(GunaLabelTime.Text)
            MainWindow.GunaComboBoxHeureNavetteArrivee.SelectedItem = GunaLabelTime.Text
        ElseIf GunaLabelTitreHeure.Text = "INTERVENTION" Then
            MainWindowTechnique.GunaTextBoxHeureIntervention.Text = GunaLabelTime.Text
        End If

        Me.Close()

    End Sub

    Private Sub GunaComboBoxHeure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxHeure.SelectedIndexChanged
        GunaLabelTime.Text = GunaComboBoxHeure.SelectedItem & ":" & GunaComboBoxMinutes.SelectedItem & ":00"
    End Sub

    Private Sub GunaComboBoxMinutes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxMinutes.SelectedIndexChanged
        GunaLabelTime.Text = GunaComboBoxHeure.SelectedItem & ":" & GunaComboBoxMinutes.SelectedItem & ":00"
    End Sub

    Private Sub TimePickerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaComboBoxHeure.SelectedItem = "12"
        GunaComboBoxMinutes.SelectedItem = "00"
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Me.Close()
    End Sub
End Class