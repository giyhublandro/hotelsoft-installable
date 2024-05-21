Public Class ChangePasswordForm

    Private Sub ChangePasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.changePassword(GlobalVariable.actualLanguageValue)

        GunaTextBoxCeode.Text = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        GunaTextBoxNomUser.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.Close()
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        Me.Close()
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim dialog As DialogResult

        Dim message As String = ""
        Dim title As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            message = "Voulez vous vraiment changer le mot de passe "
            title = "Changement de mot de passe"
        ElseIf GlobalVariable.actualLanguageValue = 0 Then
            message = "Do you want to change your Password "
            title = "Changing Password"
        End If

        dialog = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.No Then


        Else

            Dim utilisateur As New User()

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
            Dim PASSWORD_UTILISATEUR As String = GunaTextBoxNewPasse.Text
            Dim NUM_AGENCE As String = GlobalVariable.codeAgence

            utilisateur.updateUserPassword(CODE_UTILISATEUR, PASSWORD_UTILISATEUR, NUM_AGENCE)

            Dim dialogNew As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                message = "Mot de passe changé avec succès "
                title = "Changement de mot de passe"
            ElseIf GlobalVariable.actualLanguageValue = 0 Then
                message = "Password successfully changed"
                title = "Changing Password"
            End If

            dialogNew = MessageBox.Show(message, title, MessageBoxButtons.OK)

            AccueilForm.Close()
            AccueilForm.Show()

            If GlobalVariable.changerMotDePasseDepuis.Equals("reception") Then
                MainWindow.Close()
            ElseIf GlobalVariable.changerMotDePasseDepuis.Equals("bar") Then
                BarRestaurantForm.Close()
            ElseIf GlobalVariable.changerMotDePasseDepuis.Equals("cuisine") Then
                ArticleForm.Close()
                MainWindowCuisineForm.Close()
            ElseIf GlobalVariable.changerMotDePasseDepuis.Equals("comptabilite") Then
                MainWindowComptabiliteForm.Close()
            ElseIf GlobalVariable.changerMotDePasseDepuis.Equals("economat") Then
                MainWindowEconomat.Close()
            ElseIf GlobalVariable.changerMotDePasseDepuis.Equals("etage") Then
                MainWindowServiceEtageForm.Close()
            ElseIf GlobalVariable.changerMotDePasseDepuis.Equals("technique") Then
                MainWindowTechnique.Close()
            End If

            Me.Close()

        End If

    End Sub

    'Apres validation de l'ancien mot de passe saisie on compare avec ce qui est stocke en ligne


    Private Sub GunaTextBoxAncienPasse_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxAncienPasse.TextChanged

        If Trim(GlobalVariable.ConnectedUser.Rows(0)("PASSWORD_UTILISATEUR")) = Trim(GunaTextBoxAncienPasse.Text) Then

            GunaTextBoxNewPasse.Enabled = True
            GunaTextBoxConfirmPasse.Enabled = True

            GunaTextBoxNewPasse.BaseColor = Color.White
            GunaTextBoxConfirmPasse.BaseColor = Color.White

        Else
            GunaTextBoxNewPasse.Enabled = False
            GunaTextBoxConfirmPasse.Enabled = False

            GunaTextBoxNewPasse.BaseColor = Color.LightPink
            GunaTextBoxConfirmPasse.BaseColor = Color.LightPink

        End If

    End Sub

    Private Sub GunaTextBoxConfirmPasse_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxConfirmPasse.TextChanged

        If Not Trim(GunaTextBoxConfirmPasse.Text).Equals("") Then

            If GunaTextBoxNewPasse.Text = GunaTextBoxConfirmPasse.Text Then
                GunaButtonEnregistrer.Enabled = True
            Else
                GunaButtonEnregistrer.Enabled = False
            End If

        End If
        
    End Sub

End Class