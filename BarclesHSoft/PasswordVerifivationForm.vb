Public Class passwordVerifivationForm
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Dim languageMessag As String = ""
    Dim languageAction As String = ""

    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        If Not Trim(GlobalVariable.TransfertDeElementDeCaisse).Equals("") Then
            'TRANSFERT DE BLOC NOTE ENTRE CAISSE
            Dim infoUtilisateurATransferer As DataTable = Functions.getElementByCode(Trim(GlobalVariable.TransfertDeElementDeCaisse), "utilisateurs", "CODE_UTILISATEUR")

            If infoUtilisateurATransferer.Rows.Count > 0 Then

                If infoUtilisateurATransferer.Rows(0)("PASSWORD_UTILISATEUR").Equals(GunaTextBoxPasswordVerification.Text) Then

                    If GlobalVariable.fenetreDouvervetureDeCaisse = "petite caisse" Or GlobalVariable.billetageAPartirDe = "petite caisse" Then

                        'TRANSFERT APPARENT DU CONTENU LA PETITE CAISSE

                        Dim NEW_CODE_CAISSIER As String = Trim(GlobalVariable.TransfertDeElementDeCaisse)

                        Dim ETAT_CAISSE As Integer = 0
                        Dim caissier As New Caisse()
                        Dim CODE_CAISSE As String = PetiteCaisseForm.GunaTextBoxCodePetiteCaisse.Text

                        caissier.ouvertureFermetureDePetiteCaisse(CODE_CAISSE, ETAT_CAISSE)

                        'PetiteCaisseForm.GestionOuvertureDeCaisse()

                        PetiteCaisseForm.indicateurDEtatDeCaisse()

                        '--------------------------------------- GENERATION DU BON DE PETITE CAISSE --------------------------------------------------------
                        Dim NB1 As Integer = BilletageForm.GunaTextBox35.Text
                        Dim NB2 As Integer = BilletageForm.GunaTextBox30.Text
                        Dim NB3 As Integer = BilletageForm.GunaTextBox25.Text
                        Dim NB4 As Integer = BilletageForm.GunaTextBox13.Text
                        Dim NB5 As Integer = BilletageForm.GunaTextBoxNB5.Text
                        Dim NP1 As Integer = BilletageForm.GunaTextBox9.Text
                        Dim NP2 As Integer = BilletageForm.GunaTextBox20.Text
                        Dim NP3 As Integer = BilletageForm.GunaTextBox15.Text
                        Dim NP4 As Integer = BilletageForm.GunaTextBox10.Text
                        Dim NP5 As Integer = BilletageForm.GunaTextBox8.Text
                        Dim NP6 As Integer = BilletageForm.GunaTextBox5.Text
                        Dim NP7 As Integer = BilletageForm.GunaTextBoxNP7.Text

                        Dim NB1T1 As Double = BilletageForm.GunaTextBoxNB1T1.Text
                        Dim NB2T2 As Double = BilletageForm.GunaTextBoxNB2T2.Text
                        Dim NB3T3 As Double = BilletageForm.GunaTextBoxNB3T3.Text
                        Dim NB4T4 As Double = BilletageForm.GunaTextBoxNB4T4.Text
                        Dim NB5T5 As Double = BilletageForm.GunaTextBoxNB5T5.Text
                        Dim NP1T1 As Double = BilletageForm.GunaTextBox2.Text
                        Dim NP2T2 As Double = BilletageForm.GunaTextBox3.Text
                        Dim NP3T3 As Double = BilletageForm.GunaTextBox6.Text
                        Dim NP4T4 As Double = BilletageForm.GunaTextBox14.Text
                        Dim NP5T5 As Double = BilletageForm.GunaTextBox11.Text
                        Dim NP6T6 As Double = BilletageForm.GunaTextBox18.Text
                        Dim NP7T7 As Double = BilletageForm.GunaTextBoxNP7T7.Text

                        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
                        Dim GRAND_TOTAL As Double = Double.Parse(BilletageForm.LabelSituationCaisse.Text)

                        'TRAITEMENT DE PETITE CAISSE

                        Dim FORM_NAME As String = "petite_caisse"
                        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        Dim REFERENCE_TRANSACTION As String = Functions.GeneratingRandomCodeWithSpecifications("transfert_recette_coupures", "BT")

                        Dim caisse As New Caisse()

                        caisse.insertBilletage(NB1, NB2, NB3, NB4, NB5, NP1, NP2, NP3, NP4, NP5, NP6, NP7, NB1T1, NB2T2, NB3T3, NB4T4, NB5T5, NP1T1, NP2T2, NP3T3, NP4T4, NP5T5, NP6T6, NP7T7, CODE_CAISSIER, REFERENCE_TRANSACTION, DATE_CREATION, GRAND_TOTAL)

                        Dim LIBELLE_TRANSFERT As String = ""

                        If GlobalVariable.actualLanguageValue = 0 Then
                            LIBELLE_TRANSFERT = "CASH FLOW SITUATION AFTER TRANSFERT OF " & GlobalVariable.DateDeTravail & " BY " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
                            languageAction = "Cash Flow Management"
                            languageMessag = "Cash Flow transfered and closed successfully"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            LIBELLE_TRANSFERT = "SITUATION DE PETITE CAISSE APRES CLOTURE DU " & GlobalVariable.DateDeTravail & " PAR " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
                            languageAction = "Gestion de caisse"
                            languageMessag = "Caisse transférée et fermée avec succès"
                        End If


                        Dim DEBIT As Double = Double.Parse(BilletageForm.LabelMontantSorti.Text)
                        Dim CREDIT As Double = Double.Parse(BilletageForm.LabelSituationCaisse.Text)

                        '-----------------------------------------------------------------------------------------------------------------------------------
                        MessageBox.Show(languageMessag, languageAction, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Functions.BonDeCaisseDeTransfert(CODE_CAISSIER, REFERENCE_TRANSACTION, LIBELLE_TRANSFERT, DEBIT, CREDIT, REFERENCE_TRANSACTION, FORM_NAME)

                        Me.Close()

                        BilletageForm.Close()

                    Else
                        'DEPUIS LE BAR RESTAURANT

                        Dim NEW_CODE_CAISSIER As String = Trim(GlobalVariable.TransfertDeElementDeCaisse) 'CODE DE L'UTISATEUR VERS LEQUEL ON SOUHAITE ENVOYER LE BLOC NOTE SI ON EST AU BAR 

                        BarRestaurantForm.TransfertDeBlocNoteAvantPassassionDeService(NEW_CODE_CAISSIER)

                        Me.Close()

                        GlobalVariable.TransfertDeElementDeCaisse = ""

                    End If

                    GlobalVariable.fenetreDouvervetureDeCaisse = ""

                Else

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessag = "Wrong Password"
                        languageAction = "Cash Flow Management"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessag = "Mauvais mot de passe"
                        languageAction = "Gestion de caisse"
                    End If

                    MessageBox.Show(languageMessag, languageAction, MessageBoxButtons.OK, MessageBoxIcon.Error)

                    GunaTextBoxPasswordVerification.Clear()

                End If

            End If

        ElseIf Not Trim(GlobalVariable.fenetreDouvervetureDeCaisse).Equals("") Then

            'VERIFICATION POUR OUVERTURE DE CAISSE

            If GlobalVariable.ConnectedUser.Rows(0)("PASSWORD_UTILISATEUR").Equals(GunaTextBoxPasswordVerification.Text) Then

                If GlobalVariable.fenetreDouvervetureDeCaisse = "bar" Then

                    BarRestaurantForm.GestionOuvertureDeCaisse()

                    BarRestaurantForm.indicateurDEtatDeCaisse()

                    Me.Close()

                ElseIf GlobalVariable.fenetreDouvervetureDeCaisse = "reception" Then

                    MainWindow.GestionOuvertureDeCaisse()

                    MainWindow.indicateurDEtatDeCaisse()

                    FacturationForm.indicateurDEtatDeCaisse()

                    Me.Close()

                    Dim tentativeEncaissement As Integer = Integer.Parse(GunaTextBoxApresTentativeEncaissemtn.Text)

                    If tentativeEncaissement = 1 Then

                        ReglementForm.Show()
                        ReglementForm.TopMost = True

                        ReglementForm.GunaTextBoxMontantVerse.Text = GunaTextBoxMontantQueLonVeutRegler.Text

                    End If

                ElseIf GlobalVariable.fenetreDouvervetureDeCaisse = "comptable" Then

                    ReglementLettrageForm.GestionOuvertureDeCaisse()

                    ReglementLettrageForm.indicateurDEtatDeCaisse()

                    Me.Close()

                ElseIf GlobalVariable.fenetreDouvervetureDeCaisse = "petite caisse" Then

                    PetiteCaisseForm.GestionOuvertureDeCaisse()

                    PetiteCaisseForm.indicateurDEtatDeCaisse()

                    Me.Close()

                ElseIf GlobalVariable.fenetreDouvervetureDeCaisse = "caissier" Then

                    GrandeCaisseForm.GestionOuvertureDeCaisse()

                    GrandeCaisseForm.indicateurDEtatDeCaisse()

                    Me.Close()

                End If

                GlobalVariable.fenetreDouvervetureDeCaisse = ""

            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessag = "Wrong Password"
                    languageAction = "Cash Flow Management"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessag = "Mauvais mot de passe"
                    languageAction = "Gestion de caisse"
                End If

                MessageBox.Show(languageMessag, languageAction, MessageBoxButtons.OK, MessageBoxIcon.Error)

                GunaTextBoxPasswordVerification.Clear()

            End If

        End If

        'passwordVerifivationForm.GunaTextBoxQueLonVeutRegler.Text = GunaTextBoxMontantVerse.Text

    End Sub

    'UTILISE POUR L'OUVERTURE DE CAISSE UNIQUEMENT
    Private Sub passwordVerifivationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.passwordVerification(GlobalVariable.actualLanguageValue)

        If Not Trim(GlobalVariable.TransfertDeElementDeCaisse).Equals("") Then

            Dim infoUtilisateurATransferer As DataTable = Functions.getElementByCode(Trim(GlobalVariable.TransfertDeElementDeCaisse), "utilisateurs", "CODE_UTILISATEUR")

            If infoUtilisateurATransferer.Rows.Count > 0 Then
                GunaLabelNomAuth.Text = infoUtilisateurATransferer.Rows(0)("NOM_UTILISATEUR")
            End If

        ElseIf Not Trim(GlobalVariable.fenetreDouvervetureDeCaisse).Equals("") Then
            GunaLabelNomAuth.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        End If

    End Sub

End Class