Public Class TimePickerForm

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then

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

        Else

            If GunaLabelTitreHeure.Text = "HEURE DE DEPART" Then
                RestaurantBookingForm.GunaComboBoxHeureDepart.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureDepart.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureDepart.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureDepart.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "HEURE D'ARRIVEE" Then
                RestaurantBookingForm.GunaComboBoxHeureArrivee.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureArrivee.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureArrivee.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureArrivee.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "HEURE PAUSE CAFE" Then
                RestaurantBookingForm.GunaComboBoxHeureCafe.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureCafe.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureCafe.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureCafe.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "HEURE PAUSE DEJEUNER" Then
                RestaurantBookingForm.GunaComboBoxHeureDej.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureDej.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureDej.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureDej.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "HEURE PAUSE DINER" Then
                RestaurantBookingForm.GunaComboBoxHeureDiner.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureDiner.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureDiner.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureDiner.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "HEURE DU GOUTER" Then
                RestaurantBookingForm.GunaComboBoxHeureGouter.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureGouter.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureGouter.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureGouter.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "HEURE DU COCKTAIL" Then
                RestaurantBookingForm.GunaComboBoxHeureCocktail.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureCocktail.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureCocktail.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureCocktail.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "HEURE DE DEPART NAVETTE" Then
                RestaurantBookingForm.GunaComboBoxHeureDepartNavette.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureDepartNavette.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureDepartNavette.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureDepartNavette.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "HEURE D'ARRIVER NAVETTE" Then
                RestaurantBookingForm.GunaComboBoxHeureNavetteArrivee.Items.Remove(RestaurantBookingForm.GunaComboBoxHeureNavetteArrivee.SelectedItem)
                RestaurantBookingForm.GunaComboBoxHeureNavetteArrivee.Items.Add(GunaLabelTime.Text)
                RestaurantBookingForm.GunaComboBoxHeureNavetteArrivee.SelectedItem = GunaLabelTime.Text
            ElseIf GunaLabelTitreHeure.Text = "INTERVENTION" Then

            End If

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