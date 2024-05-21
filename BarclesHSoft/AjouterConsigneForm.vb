Public Class AjouterConsigneForm
    Private Sub GunaButtonLectureDeCarte_Click(sender As Object, e As EventArgs) Handles GunaButtonLectureDeCarte.Click
        Me.Close()
        GlobalVariable.AjouterConsigneFormRole = ""
    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub AjouterConsigneForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.ajouterConsigne(GlobalVariable.actualLanguageValue)

        If GlobalVariable.AjouterConsigneFormRole = "Nouvelle" Then
            ' GunaLabel1.Text = "SAISIR UNE CONSIGNE :"
        ElseIf GlobalVariable.AjouterConsigneFormRole = "Commenter" Then
            'GunaLabel1.Text = "SAISIR UN COMMENTAIRE : "
        End If

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterConsigne.Click

        Dim cahierConsigne As New Consigne()

        If GlobalVariable.AjouterConsigneFormRole = "Nouvelle" Then
            'insertion d'une consigne
            Dim CODE_CONSIGNE As String = Functions.GeneratingRandomCode("cahier_consigne", "CON")
            Dim HEURE_CONSIGNE As Date = Date.Now()
            Dim DATE_CONSIGNE As Date = GlobalVariable.DateDeTravail
            Dim AUTEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")
            Dim CONSIGNE As String = Trim(GunaTextBoxConsigne.Text)

            cahierConsigne.insertConsigne(CODE_CONSIGNE, DATE_CONSIGNE, AUTEUR, CONSIGNE, HEURE_CONSIGNE)

            Dim DateDebut As Date = GlobalVariable.DateDeTravail
            Dim DateFin As Date = GlobalVariable.DateDeTravail
            Dim ETAT_CONSIGNE As Integer = 0

            CahierDeConsigneForm.listeDesConsignes(DateDebut, DateFin, ETAT_CONSIGNE)

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Instruction added successfully"
                languageTitle = "Instruction"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Consigne ajoutée avec succès"
                languageTitle = "Consigne"
            End If

            Dim nombreDeConsingne As Integer = Functions.alerteConsignes()
            MainWindow.GunaLabelNombreDeConsigne.Text = "(" & nombreDeConsingne & ")"

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf GlobalVariable.AjouterConsigneFormRole = "Commenter" Then

            'insertion d'un commentaire pour une consigne

            Dim CODE_CONSIGNE As String = Trim(CahierDeConsigneForm.GunaTextBoxCodeConsigneSelectionne.Text)
            Dim DATE_CONSIGNE As Date = Date.Now()
            Dim AUTEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")
            Dim COMMENTAIRE As String = Trim(GunaTextBoxConsigne.Text)

            cahierConsigne.insertConsigneLigne(CODE_CONSIGNE, DATE_CONSIGNE, AUTEUR, COMMENTAIRE)

            CahierDeConsigneForm.GunaDataGridViewConsigneComment.Columns.Clear()

            CahierDeConsigneForm.GunaDataGridViewConsigneComment.DataSource = cahierConsigne.listeDesCommentaireDuneConsigne(CODE_CONSIGNE)

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Comment added successfully"
                languageTitle = "Comment"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Consigne ajoutée avec succès"
                languageTitle = "Consigne"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        Me.Close()

    End Sub

End Class