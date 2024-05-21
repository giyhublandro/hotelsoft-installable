Public Class ActivationForm

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub ActivationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim languages As New Languages()

        languages.activation(GlobalVariable.actualLanguageValue)

        Dim licence As New Licence()

        licence.gestionDesLicence()

    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click

        If GlobalVariable.licenceExipre Then
            GlobalVariable.licenceExipre = False

            MainWindow.Close()
            'Application.ExitThread()

            AccueilForm.Show()

        End If

        Me.Close()

    End Sub

    Private Sub GunaButtonActiver_Click(sender As Object, e As EventArgs) Handles GunaButtonActiver.Click

        Dim license As New Licence()

        Dim serialKey As String = ""
        Dim originalString As String = ""

        serialKey = GunaTextBox5.Text & "" & GunaTextBox4.Text & "" & GunaTextBox3.Text & "" & GunaTextBox2.Text & "" & GunaTextBox1.Text & ""

        Dim serialLenght As Integer = 0
        Dim longueurMaximale As Integer = 25

        serialLenght = serialKey.Length

        If Not Trim(serialKey).Equals("") Then

            If serialLenght = longueurMaximale Then

                '-VERIFICATION DE LA CONCORDANCES DES DONNEES VIA UNE EXTRACTION ET VERIFICATION DU CONTENU

                '1- MANIPULATION D'EXTRACTION 

                originalString = license.retranchementDeCaractere(license.renversementDeLaChaine(serialKey))

                Dim extractedChaine As String = license.insertionDeSeparateur(originalString)

                Dim extractArr As String() = license.extractionDesDonnees(extractedChaine)

                Dim serialType As Integer = Integer.Parse(extractArr(0))

                Dim periodeDebutString = extractArr(1)
                Dim periodeFinString = extractArr(2)

                Dim numberConnectionDaysLeft As Integer = Integer.Parse(extractArr(3))

                '1.1- ON DOIT SE RASSURE QUE LES CHAINES DE DATE EXTRAITES ONT UN FORMAT DE DATE CORRECT

                '1.1.1- ON VERIFIE LA CHAINE DATE DEBUT

                Dim formatDeDateCorrect As Boolean = license.formatDeDateCorrect(periodeDebutString)

                If formatDeDateCorrect Then

                    '1.1.2- ON VERIFIE LA CHAINE DATE FIN

                    formatDeDateCorrect = license.formatDeDateCorrect(periodeFinString)

                    If formatDeDateCorrect Then

                        'LE FORMAT DES DEUX CHAINES DE DATE SONT CORRECTS

                        '1.2- ON PEUT PROCEDER A LA CONVERSION DES CHAINES DE DATE EN DATE A PROPREMENT PARLER

                        Dim periodeDebut As Date = license.transformStringIntoDate(periodeDebutString).ToShortDateString

                        Dim periodeFin As Date = license.transformStringIntoDate(periodeFinString).ToShortDateString

                        '1.3- ON DETERMINE LA NATURE DE LA CLE D'ACTIVATION A FIN D'EFFECTUER LES VERIFICATIONS APPROPRIE

                        If serialType = 0 Then
                            'SERIAL KEY : NOMBRE DE CONNECTION
                            Dim jours As Integer = (periodeFin - periodeDebut).TotalDays()

                            If Not jours = 0 Then
                                'LES DATES NE CORRESPONDENT PAS 
                                errorMessage()
                            Else

                                If numberConnectionDaysLeft > 0 Then
                                    successMessage(serialKey, numberConnectionDaysLeft)
                                End If

                            End If

                        ElseIf serialType = 1 Then
                            'SERIAL KEY : PERIODIQUE
                            Dim duree As Integer = (periodeFin - periodeDebut).TotalDays()

                            If duree = 0 Then
                                'LES DATES NE CORRESPONDENT PAS 
                                errorMessage()
                            Else
                                'ON SE RASSURE QUE LE NOMBRE DE JOUR EST > 0
                                If numberConnectionDaysLeft > 0 Then
                                    'ON SE RASSURE QUE 
                                    If numberConnectionDaysLeft = duree Then
                                        successMessage(serialKey, numberConnectionDaysLeft)
                                    Else
                                        errorMessage()
                                    End If

                                Else
                                    errorMessage()
                                End If

                            End If

                        ElseIf serialType = 2 Then
                            'SERIAL KEY : TRIAL
                        ElseIf serialType = 3 Then
                            'SERIAL KEY : PREMIUM
                        End If

                    Else
                        'LE FORMAT DE DATE DE FIN EST INCORRECTE 
                        errorMessage()
                    End If

                Else
                    'LE FORMAT DE DATE DE DEBUT EST INCORRECTE 
                    errorMessage()
                End If

            Else
                errorMessage()
            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Please type in the Serial Key !!"
                languageTitle = "Hotel Soft Activation"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Bien vouloir saisir la clé d'activation !!"
                languageTitle = "Activation Hotel Soft"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub errorMessage()

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "The Serial Key is incorrect !!"
            languageTitle = "Hotel Soft Activation"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Mauvaise Clé d'Activation"
            languageTitle = "Activation Hotel Soft"
        End If

        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    Private Sub successMessage(ByVal serialKey As String, ByVal numberConnectionDaysLeft As Integer)

        Dim license As New Licence()

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "Hotel Soft activated successfully"
            languageTitle = "Hotel Soft Activation"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Hotel Soft activé avec succès"
            languageTitle = "Activation Hotel Soft"
        End If

        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        license.insertionDeNouvelleCle(serialKey, numberConnectionDaysLeft)

        If GlobalVariable.actualLanguageValue = 0 Then
            AccueilForm.GunaButtonSeConnecter.Text = "Login"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            AccueilForm.GunaButtonSeConnecter.Text = "Se connecter"
        End If

        Me.Close()

    End Sub

End Class