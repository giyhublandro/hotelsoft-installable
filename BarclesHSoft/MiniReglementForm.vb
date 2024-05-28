

Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class MiniReglementForm

    'Destinée à contenir l'ensemble des fatures du client pour des mis à jours

    'Dim connect As New DataBaseManipulation()

    Public Sub indicateurDEtatDeCaisse()

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 1 Then

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim caisse As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If caisse.Rows.Count > 0 Then

                If caisse.Rows(0)("ETAT_CAISSE") = 0 Then

                    PanelSituationCaisse.BackColor = Color.Red
                Else
                    PanelSituationCaisse.BackColor = Color.LightGreen
                End If

            End If

        End If

    End Sub

    Dim encaissementAvantEnregistrementDeReservation As Boolean

    Dim CODE_CLIENT As String = ""
    Dim NOM_CLIENT As String = ""
    Dim CODE_RESERVATION As String = ""
    Dim CODE_ELITE As String = ""
    Dim CODE_CHAMBRE As String = ""

    Private Sub ReglementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'GlobalVariable.typeDeClientAFacturer = "en chambre"
        Dim language As New Languages()

        language.Minireglement(GlobalVariable.actualLanguageValue)

        CODE_RESERVATION = GunaTextBoxCodeResa.Text
        CODE_CHAMBRE = GunaTextBoxChambre.Text
        CODE_ELITE = ""

        Dim infoReservation As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")
        Dim client As DataTable

        If infoReservation.Rows.Count > 0 Then

            CODE_CLIENT = infoReservation.Rows(0)("CLIENT_ID")
            client = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

            NOM_CLIENT = infoReservation.Rows(0)("NOM_CLIENT")

            GunaImageButtonFermer.Visible = True
            GunaImageButtonReduce.Visible = True
            GunaImageButtonFermer.BringToFront()
            GunaImageButtonReduce.BringToFront()

            'Si l'on vient du folio il sera d'bord ferme
            If Not Trim(GlobalVariable.ComingFromFolio1FactureType) = "" Then
                FolioForm.Close()
            End If

            GunaTextBoxMontantVerse.Text = 0

            Dim resa As New Reservation()

            Dim DEPOT_DE_GARANTIE As Double = infoReservation.Rows(0)("DEPOT_DE_GARANTIE")

            If DEPOT_DE_GARANTIE > 0 Then
                GunaCheckBoxArrhes.Visible = True
            Else

                Dim CODE_RESERVATION_CLIENT As String = client.Rows(0)("CODE_CLIENT")
                Dim infoSupDepot As DataTable = resa.infoCautionUtilisableDepot(CODE_RESERVATION_CLIENT)
                If infoSupDepot.Rows.Count > 0 Then
                    GunaCheckBoxArrhes.Visible = True
                Else
                    GunaCheckBoxArrhes.Visible = False
                End If

            End If

            If Not Trim(infoReservation.Rows(0)("NOM_ENTREPRISE")) = "" Then

                'Si la reservation est associe a une entreprise alors le reglement doit etre au nom de l'entreprise
                CODE_CLIENT = infoReservation.Rows(0)("CODE_ENTREPRISE")
                NOM_CLIENT = infoReservation.Rows(0)("NOM_ENTREPRISE")

                Dim infoSupClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")
                If infoSupClient.Rows.Count > 0 Then
                    GunaTextBoxCodeElite.Text = client.Rows(0)("CODE_ELITE")
                End If

                ComptoireEtEnChambreReglementOuFacturation(CODE_CLIENT, CODE_RESERVATION)

            ElseIf client.Rows.Count > 0 Then

                CODE_CLIENT = client.Rows(0)("CODE_CLIENT")
                NOM_CLIENT = client.Rows(0)("NOM_PRENOM")
                GunaTextBoxCodeElite.Text = client.Rows(0)("CODE_ELITE")

                ComptoireEtEnChambreReglementOuFacturation(CODE_CLIENT, CODE_RESERVATION)

            End If

            'Setting a value for the paiment mode on load
            GunaComboBoxModereglement.SelectedIndex = 0

            'Will be set back to empty string after saving the payment
            If GlobalVariable.ComingFromFolio1FactureType = "Entreprise" Then

                LabelEntreprise.Visible = True
                GunaTextBoxEntreprise.Visible = True
                LabelNumeroCompte.Visible = True
                GunaTextBoxNumeroCompte.Visible = True

                GunaComboBoxModereglement.SelectedIndex = 3

            End If

            'Ensemble des règlements

            SituationDeCaisseJournaliere()

            indicateurDEtatDeCaisse()

            If Trim(CODE_CLIENT).Equals("") Then
                GunaButtonEnregistrerReglement.Enabled = False
                GunaTextBoxReference.Clear()
            Else
                GunaButtonEnregistrerReglement.Enabled = True
            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrerReglement.Text = "Encaisser"
            Else
                GunaButtonEnregistrerReglement.Text = "Cash In"
            End If

            Label14.Text = GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

        Else

            Me.Close()

        End If

    End Sub

    Public Sub SituationDeCaisseJournaliere()

        Dim situationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

        Dim TotalFacture As Double = 0

        If situationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To situationDeCaisse.Rows.Count - 1
                TotalFacture += situationDeCaisse.Rows(i)("MONTANT_VERSE")
            Next

            Dim situationDeCaisseCasDeRemboursement As DataTable = Functions.SituationDeCaisseCasDeRemboursement(GlobalVariable.DateDeTravail)

            Dim TotalRembourse As Double = 0
            'On selection l'ensemble des remboursement d'un jour donné
            If situationDeCaisseCasDeRemboursement.Rows.Count > 0 Then

                For j = 0 To situationDeCaisseCasDeRemboursement.Rows.Count - 1
                    TotalRembourse += situationDeCaisseCasDeRemboursement.Rows(j)("MONTANT_HT")
                Next

                'On soustrait les montant remboursé des montants encaissé
                TotalFacture -= TotalRembourse

            End If

            LabelSituationCaisse.Text = Format(TotalFacture, "#,##0")

        Else
            LabelSituationCaisse.Text = 0
        End If

    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButtonReduce.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButtonFermer.Click
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Structure SituationClient

        Dim dateOperation
        Dim libelleOperation
        Dim Debit
        Dim Credit
        Dim Article
        Dim Code
        Dim Id

    End Structure

    'Retrait de toute les fature liés au client pour regmelent ou encaissement
    Private Sub ComptoireEtEnChambreReglementOuFacturation(ByVal CODE_CLIENT As String, ByVal CODE_RESERVATION As String)

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------

        Dim infoReservation As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")
        Dim client As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

        Dim solde As Double = 0
        Dim NOM_CLIENT As String = ""

        If infoReservation.Rows.Count > 0 Then

            solde = Functions.SituationDeReservation(CODE_RESERVATION)

            If Not Trim(infoReservation.Rows(0)("NOM_ENTREPRISE")) = "" Then

                'Si la reservation est associe a une entreprise alors le reglement doit etre au nom de l'entreprise
                CODE_CLIENT = infoReservation.Rows(0)("CODE_ENTREPRISE")
                NOM_CLIENT = infoReservation.Rows(0)("NOM_ENTREPRISE")

                Dim infoSupClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")
                If infoSupClient.Rows.Count > 0 Then
                    GunaTextBoxCodeElite.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_ELITE")
                End If

            ElseIf Client.Rows.Count > 0 Then

                CODE_CLIENT = client.Rows(0)("CODE_CLIENT")
                NOM_CLIENT = client.Rows(0)("NOM_PRENOM")
                GunaTextBoxCodeElite.Text = client.Rows(0)("CODE_ELITE")

            End If

        End If

        If Not Trim(CODE_CLIENT).Equals("") Then

            Dim montantAPayer As Double = 0

            GunaTextBoxAPayer.Text = Format(Math.Abs(solde), "#,##0")

            Dim soldeAregler = Math.Abs(solde)
            GunaTextBoxSolde.Text = GunaTextBoxAPayer.Text
            'Solde = Debit - credit

            If solde <= 0 Then '

                If GlobalVariable.actualLanguageValue = 1 Then

                    LabelMontantAPayer.Text = "Montant à Payer"
                    LabelSolde.Text = "Solde à payer"

                    GunaTextBoxMontantVerse.Text = 0

                    GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "ENCAISEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & NOM_CLIENT & " " & Date.Now()

                Else
                    LabelMontantAPayer.Text = "Amount to Pay"
                    LabelSolde.Text = "Balance to Pay"

                    GunaTextBoxMontantVerse.Text = 0

                    GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "CASH IN (" & GunaComboBoxModereglement.SelectedItem & ") FROM " & NOM_CLIENT & " " & Date.Now()
                End If
                'we enable the button as we can pay
                'GunaButtonEnregistrerReglement.Enabled = True

            End If

            GunaTextBoxSolde.Enabled = False
            GunaTextBoxAPayer.Enabled = False

        End If

    End Sub


    Private Sub GunaTextBoxMontantVerse_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantVerse.TextChanged

        Dim APayer As Double = 0
        Dim montantVerse As Double = 0
        Dim solde As Double = 0

        Double.TryParse(GunaTextBoxAPayer.Text, APayer)
        Double.TryParse(GunaTextBoxMontantVerse.Text, montantVerse)

        If Not APayer = 0 Then

            GunaTextBoxSolde.Text = APayer - montantVerse

            If Not GunaButtonEnregistrerReglement.Enabled Then

                If Trim(NOM_CLIENT).Equals("") Then
                    GunaButtonEnregistrerReglement.Enabled = False
                Else
                    GunaButtonEnregistrerReglement.Enabled = True
                End If

            End If

        End If

        If GunaComboBoxModereglement.SelectedIndex = 0 Then

            If Not Trim(GunaTextBoxMontantVerse.Text).Equals("") Then
                If Trim(GunaTextBoxMontantVerse.Text).Equals("0") Then
                    GunaButtonEnregistrerReglement.Enabled = False
                Else
                    If Trim(NOM_CLIENT).Equals("") Then
                        GunaButtonEnregistrerReglement.Enabled = False
                    Else
                        GunaButtonEnregistrerReglement.Enabled = True
                    End If
                End If
            Else

                GunaButtonEnregistrerReglement.Enabled = False
            End If

        End If

        If GunaComboBoxModereglement.SelectedIndex = 10 Then

            If GunaComboBoxCritereElite.SelectedIndex = 0 Then
                Dim MONTANT_TOTAL_DES_POINTS As Double = 0
                Dim MONTANT_MONTANT_A_VERSE As Double = 0

                If Not Trim(GunaTextBoxMontantVerse.Text).Equals("") Then
                    MONTANT_MONTANT_A_VERSE = GunaTextBoxMontantVerse.Text
                End If

                If Not Trim(GunaTextBoxValeurTotalCritere.Text).Equals("") Then
                    MONTANT_TOTAL_DES_POINTS = GunaTextBoxValeurTotalCritere.Text
                End If

                If MONTANT_MONTANT_A_VERSE > MONTANT_TOTAL_DES_POINTS Then
                    GunaButtonEnregistrerReglement.Enabled = False
                Else
                    GunaButtonEnregistrerReglement.Enabled = True
                End If

            ElseIf True Then

            ElseIf True Then

            End If
        End If

    End Sub

    Public Sub pointsDesClientsComptoirs(ByVal CODE_CLIENT As String, ByVal MONTANT_REGLEMENT As Double)

        If GlobalVariable.typeDeClientAFacturer.Equals("comptoir") Then
            Dim eliteClub As New ClubElite()
            eliteClub.augmentationDesPointsDesClientsComptoirs(CODE_CLIENT, MONTANT_REGLEMENT)
        End If

    End Sub


    Dim dt As DataGridView

    Private Sub GunaButtonEnregistrerClient_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerReglement.Click

        'ETAT_BLOC_NOTE = 0 : COMPTOIR
        'ETAT_BLOC_NOTE = 1 : EN CHAMBRE
        'ETAT_BLOC_NOTE = 2 : GRATUITEE
        'ETAT_BLOC_NOTE = 3 : COMPTE

        Dim CODE_CAUTION As String = GunaTextBoxCodeDepot.Text
        Dim DEPOT_DE_GARANTIE As Double = 0
        Dim DEPOT_DE_GARANTIE_VERIF As Double = 0

        Dim encaisserAvecSansLeDepotDeGarantie As Boolean = True

        Dim infoSupResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

        If GunaCheckBoxArrhes.Checked Then

            If Trim(CODE_CAUTION).Equals("") Then
                GunaCheckBoxArrhes.Checked = False
            Else
                DEPOT_DE_GARANTIE = GunaTextBoxMontantVerse.Text
                DEPOT_DE_GARANTIE_VERIF = GunaTextBoxMontantDepot.Text

                If DEPOT_DE_GARANTIE > DEPOT_DE_GARANTIE_VERIF Then
                    encaisserAvecSansLeDepotDeGarantie = False
                End If
            End If

        End If


        If Not encaisserAvecSansLeDepotDeGarantie Then

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir saisir un montant correcte ! ", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Please type in a correct amount ", "Cash In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            GunaTextBoxMontantVerse.Text = Format(DEPOT_DE_GARANTIE_VERIF, "#,##0")

        Else

            If Trim(NOM_CLIENT).Equals("") Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Bien vouloir rappeler une réservation pour encaissment ! ", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Please Open a reservation before Cashing In ", "Cash In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else

                Dim indexReglement As Integer = GunaComboBoxModereglement.SelectedIndex
                Dim continuer As Boolean = True
                Dim blocNoteTermine As Boolean = True
                Dim imprimerRecu As Boolean = False

                Dim ETAT_FACTURE_POUR_COMPTE As Integer = -1
                Dim ETAT_FACTURE_POUR_EN_CHAMBRE As Integer = -1
                Dim ETAT_BLOC_NOTE As Integer
                Dim NUMERO_BLOC_NOTE As String = ""
                Dim LigneFacture As New LigneFacture()

                Dim CODE_CHAMBRE_ As String = GunaTextBoxCodeChambre.Text
                Dim CODE_CLIENT_EN_CHAMBRE_ As String = GunaTextBoxCodeClient.Text
                Dim CODE_RESERVATION_ As String = GunaTextBoxCodeReservation.Text

                Dim VAEUR_DU_POINT As Double = 0
                Dim CODE_CLIENT_FIDELE As String = GunaTextBoxCodeClientFidele.Text
                'ON DOIT SE RASSURER QUE L'UTILISATEUR VEUT VRAIMENT FAIRE UN REMBOURSEMENT
                Dim messageText As String = ""

                If Trim(GunaTextBoxMontantVerse.Text).Equals("") Then
                    GunaTextBoxMontantVerse.Text = 0
                End If

                If GunaComboBoxModereglement.SelectedIndex = 0 Or GunaComboBoxModereglement.SelectedIndex = 1 Or GunaComboBoxModereglement.SelectedIndex = 2 Or
                GunaComboBoxModereglement.SelectedIndex = 4 Or GunaComboBoxModereglement.SelectedIndex = 5 Or GunaComboBoxModereglement.SelectedIndex = 9 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        messageText = "Voulez-vous effectuer un encaissement de " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & " (" & GunaComboBoxModereglement.SelectedItem & ") "
                    Else
                        messageText = "Do you want to cash in an amount of " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & " (" & GunaComboBoxModereglement.SelectedItem & ") "

                    End If

                ElseIf GunaComboBoxModereglement.SelectedIndex = 3 Or GunaComboBoxModereglement.SelectedIndex = 6 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        messageText = "Voulez-vous effectuer une " & GunaComboBoxModereglement.SelectedItem & " de " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

                    Else
                        messageText = "You are about to pay through " & GunaComboBoxModereglement.SelectedItem & " an amount " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                    End If
                ElseIf GunaComboBoxModereglement.SelectedIndex = 7 Or GunaComboBoxModereglement.SelectedIndex = 8 Then


                    If GlobalVariable.actualLanguageValue = 1 Then
                        messageText = "Voulez-vous effectuer un " & GunaComboBoxModereglement.SelectedItem & " de " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                    Else
                        messageText = "You are about to pay through" & GunaComboBoxModereglement.SelectedItem & " an amount " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                    End If

                ElseIf GunaComboBoxModereglement.SelectedIndex = 10 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        messageText = "Voulez-vous effectuer un paiement via " & GunaComboBoxModereglement.SelectedItem & " de " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                    Else
                        messageText = "You are about to pay through " & GunaComboBoxModereglement.SelectedItem & " an amount " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")
                    End If

                End If

                Dim dialogTitle As String = ""

                'ON AVISE L'UTILISATEUR QU'IL N'EST ENTRAIN DE FAIRE UN REMBOURSEMENT
                Dim dialog1 As DialogResult
                dialog1 = MessageBox.Show(messageText, dialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If dialog1 = DialogResult.No Then
                    continuer = False
                End If

                If continuer Then

                    Dim modeReglement As String = GunaComboBoxModereglement.SelectedItem
                    Dim NUM_REGLEMENT = Functions.GeneratingRandomCodeWithSpecifications("reglement", "")

                    Dim fermer As Boolean = True

                    Dim MONTANT_REGLEMENT As Double = Double.Parse(GunaTextBoxMontantVerse.Text)
                    Dim MONTANT_TOTAL_A_REGLER As Double = Double.Parse(GunaTextBoxAPayer.Text)

                    Dim montantCredit As Double = 0

                    If Trim(GunaTextBoxMontantVerse.Text) = "" Then
                        GunaTextBoxMontantVerse.Text = 0
                    End If
                    'Seule ceux qui ont le droit d'avoir accès à la caisse peuvent encaisser

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 1 Then

                        'Même si on a le droit a la caisse on doit encore être associé à une caisse pour pouvoir encaisser

                        If Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "caisse", "CODE_UTILISATEUR").Rows.Count > 0 Then

                            Dim ETAT_CAISSE As Integer = 0

                            Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                            Dim CODE_CAISSE As String = ""

                            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                            If CAISSE_UTILISATEUR.Rows.Count > 0 Then
                                ETAT_CAISSE = CAISSE_UTILISATEUR.Rows(0)("ETAT_CAISSE")
                            End If

                            If ETAT_CAISSE = 0 Then

                                'ON DOIT SE RASSURER QUE LE MAGASIN ET SHIFT ON ETE CHOISI AVANT 
                                'DE PERMETTRE D'OUVRIR LA CAISSE

                                Dim gestionStock As Integer = GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK")
                                Dim choixShiftMagasin As Boolean = True
                                'PAR DEFAUT POURSUIVRE POUR GERER LE CAS DE NON ACTIVATION DE LA GESTION DES STOCK

                                'ON NE DOIT PAS POUVOUR OUVRIR SA CAISSE SI LA GESTION DES STOCKS EST ACTIVE
                                'ET QUE L'ON A PAS ENCORE CHOISI SON MAGASIN ET CHOISI UN SHIFT

                                If gestionStock = 1 Then

                                    choixShiftMagasin = False

                                    If GlobalVariable.magasinActuel.Equals("") Then
                                        Functions.magasinActuelEtShiftDunUtilisateur()
                                    Else
                                        choixShiftMagasin = True
                                    End If

                                End If

                                If choixShiftMagasin Then

                                    passwordVerifivationForm.Close()

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        MessageBox.Show("Bien vouloir ouvrir votre caisse !!", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Else
                                        MessageBox.Show("Please open your cash register !!", "Cash register", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If

                                    GlobalVariable.fenetreDouvervetureDeCaisse = "reception"

                                    passwordVerifivationForm.Show()
                                    passwordVerifivationForm.TopMost = True

                                    passwordVerifivationForm.GunaTextBoxMontantQueLonVeutRegler.Text = GunaTextBoxMontantVerse.Text
                                    passwordVerifivationForm.GunaTextBoxApresTentativeEncaissemtn.Text = 1

                                End If

                            Else

                                '** Tous les elements dont la non execution a permit a ce que le logiciel ne se ferme plus
                                Me.Cursor = Cursors.WaitCursor
                                '------------------------------ DEBUT DU TRAITEMENT DE REGLEMENT ----------------------------------------------

                                '-------------------------------------------------------------------------------
                                Dim TOTAL_FACTURE As Double = Double.Parse(GunaTextBoxAPayer.Text)
                                Dim TOTAL_REGLEMENT As Double = Double.Parse(GunaTextBoxMontantVerse.Text)

                                '-------------------------------------------------------------------------------

                                Dim MODE_REG_INFO_SUP_1 As String = ""
                                Dim MODE_REG_INFO_SUP_2 As String = ""
                                Dim MODE_REG_INFO_SUP_3 As Date = GlobalVariable.DateDeTravail.ToShortDateString

                                '1- ******************** MODE DE REGLREMENT TRANSFERT VERS LA CHAMBRE (7) : TRANSFERT DE CHARGE VERS LES EN CHAMBRES

                                If GunaComboBoxModereglement.SelectedIndex = 7 Then

                                ElseIf GunaComboBoxModereglement.SelectedIndex = 3 Or GunaComboBoxModereglement.SelectedIndex = 8 Then

                                Else

                                    Dim POINTS As Integer = 0
                                    'AUTRES MODE DE REGLEMENTS
                                    If GunaComboBoxModereglement.SelectedIndex = 1 Or GunaComboBoxModereglement.SelectedIndex = 9 Then ' CHEQUE & VIREMENT
                                        If GunaComboBoxBanqueEmettrice.SelectedIndex >= 0 Then
                                            MODE_REG_INFO_SUP_1 = GunaComboBoxBanqueEmettrice.SelectedValue.ToString
                                        End If
                                        MODE_REG_INFO_SUP_2 = GunaTextBoxCheque.Text
                                    ElseIf GunaComboBoxModereglement.SelectedIndex = 2 Then ' CARTE DE CREDIT
                                        MODE_REG_INFO_SUP_1 = MaskedTextBoxNumeroCarte.Text
                                        MODE_REG_INFO_SUP_2 = MaskedTextBoxCVV.Text
                                        MODE_REG_INFO_SUP_3 = GunaDateTimePickerDateExpiration.Value.ToShortDateString()

                                    ElseIf GunaComboBoxModereglement.SelectedIndex = 3 Or GunaComboBoxModereglement.SelectedIndex = 8 Then ' TRANSFERT VERS COMPTES
                                        MODE_REG_INFO_SUP_1 = GunaTextBoxEntreprise.Text
                                        MODE_REG_INFO_SUP_2 = GunaTextBoxNumeroCompte.Text

                                    ElseIf GunaComboBoxModereglement.SelectedIndex = 4 Or GunaComboBoxModereglement.SelectedIndex = 5 Then ' MOBILE MONEY
                                        MODE_REG_INFO_SUP_1 = GunaTextBoxContact.Text
                                    ElseIf GunaComboBoxModereglement.SelectedIndex = 6 Then ' GRATUITEES
                                        MODE_REG_INFO_SUP_1 = GunaTextBoxAuthorisation.Text
                                        MODE_REG_INFO_SUP_2 = GunaTextBoxRemarque.Text

                                    ElseIf GunaComboBoxModereglement.SelectedIndex = 10 Then ' FIDELITE
                                        MODE_REG_INFO_SUP_1 = GunaComboBoxCritereElite.SelectedItem
                                        MODE_REG_INFO_SUP_2 = GunaTextBoxValeurDuPoint.Text

                                    End If

                                    'If Double.Parse(GunaTextBoxMontantVerse.Text) >= Double.Parse(GunaTextBoxAPayer.Text) Then
                                    If Double.Parse(GunaTextBoxMontantVerse.Text) > 0 Then

                                        'We update the state of the values of the invoice
                                        Dim facture As New LigneFacture()

                                        'We have to update each facture in the list of the client facture
                                        Dim montanVerse As Double = GunaTextBoxMontantVerse.Text
                                        Dim montanVerseAvantRetranchement As Double = 0


                                        'GESTION DES ENCAISSEMENTS
                                        'Insert a line into reglement
                                        Dim reglement As New Reglement()
                                        Dim caisse As New Caisse()

                                        Dim NUM_FACTURE = ""

                                        Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                        Dim MONTANT_VERSE = Double.Parse(GunaTextBoxMontantVerse.Text)
                                        montantCredit = MONTANT_VERSE
                                        Dim DATE_REGLEMENT As Date = CDate(GlobalVariable.DateDeTravail)
                                        Dim MODE_REGLEMENT = GunaComboBoxModereglement.SelectedItem

                                        If Not Trim(GunaTextBoxValeurDuPoint.Text).Equals("") Then
                                            VAEUR_DU_POINT = 0
                                        End If

                                        If GunaComboBoxModereglement.SelectedIndex = 10 Then
                                            MODE_REGLEMENT = MODE_REGLEMENT & " [" & GunaComboBoxCritereElite.SelectedItem & "]"
                                            POINTS = Double.Parse(GunaTextBoxMontantVerse.Text) / GunaTextBoxValeurDuPoint.Text
                                        End If

                                        Dim REF_REGLEMENT = GunaTextBoxReference.Text
                                        Dim CODE_MODE = ""
                                        Dim IMPRIMER = 0
                                        Dim CODE_AGENCE = GlobalVariable.codeAgence

                                        NUMERO_BLOC_NOTE = GlobalVariable.blocNoteARegler

                                        If Not GlobalVariable.codeReservationToUpdate = "" Then
                                            CODE_RESERVATION = GlobalVariable.codeReservationToUpdate
                                        Else
                                            If encaissementAvantEnregistrementDeReservation Then
                                                CODE_RESERVATION = MainWindow.GunaLabelNumReservation.Text
                                            End If
                                        End If

                                        If GunaComboBoxModereglement.SelectedIndex = 6 Then

                                            If GunaCheckBoxOffresEnChambre.Checked Then
                                                If GunaComboBoxNumChambreGrat.SelectedIndex >= 0 Then
                                                    CODE_RESERVATION = GunaComboBoxNumChambreGrat.SelectedValue.ToString
                                                End If
                                            End If

                                        End If

                                        '******************************************** REMBOURSEMENT *********************************
                                        If reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3) Then

                                            'Mise a jours du solde de la caisse du caissier actuellement connecté en plus


                                            ' ********************************* GRATUITEE ****************************************

                                            If Not GunaComboBoxModereglement.SelectedIndex = 6 Then
                                                caisse.updateSoldeCaisse(CODE_CAISSIER, MONTANT_VERSE)
                                                SituationDeCaisseJournaliere()
                                            Else

                                                ' ************************************ MODE DE REGLEMENT GRATUITEES  *********** GESTION DES GRTUITES (6)' 

                                                GunaComboBoxModereglement.SelectedIndex = 6 'GESTION DES GRATUITES

                                                Dim CODE_CHAMBRE_LIBELLE As String = ""

                                                If GunaCheckBoxOffresEnChambre.Checked Then

                                                    If GunaComboBoxNumChambreGrat.SelectedIndex >= 0 Then

                                                        CODE_RESERVATION = GunaComboBoxNumChambreGrat.SelectedValue.ToString

                                                        CODE_CHAMBRE_LIBELLE = " [" & GunaTextBoxCodeChambreGrat.Text & "]"

                                                    End If

                                                End If

                                                reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE * -1, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                                'INSERTION DES GRATUITES POUR LE JOURNA DES VENTES

                                                Dim ligneDeGratuite As New LigneFacture()

                                                Dim CODE_FACTURE As String = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture", "")

                                                Dim ETAT_FACTURE_POUR_GRATUITE As Integer = 2 'ETAT MATERIALISANT LA GRATUITEE
                                                ETAT_BLOC_NOTE = 2

                                                LigneFacture.UpdateEtatLigneFacturePourClientComptoire(NUMERO_BLOC_NOTE, ETAT_FACTURE_POUR_GRATUITE, ETAT_BLOC_NOTE) 'ligne_facture_bloc_note

                                            End If

                                            'We set back montPAyer to 0
                                            GunaTextBoxMontantVerse.Text = 0

                                            '-----------------------------------------------------------------------------------------------------------------------------
                                            'MISE A JOURS DU MONTANT A REPORTER DE LA MAIN COURANTE

                                            Dim ETAT_MAIN_COURANTE As Integer = 0
                                            Dim DATE_TRAVAIL As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

                                            Dim tableName As String = "main_courante_journaliere"

                                            Dim mainCouranteInfo As DataTable = Functions.getElementByOnCodeAndDate(ETAT_MAIN_COURANTE, tableName, "ETAT_MAIN_COURANTE", DATE_TRAVAIL, tableName, CODE_RESERVATION)

                                            Dim mainCourantes As New MainCourantes()

                                            Dim TABLE As String = ""
                                            Dim FIELD As String = ""

                                            Dim CODE_MAIN_COURANTE As String = ""

                                            Dim FIELDVALUE As Double = MONTANT_REGLEMENT

                                            If mainCouranteInfo.Rows.Count > 0 Then

                                                'MISE AJOURS DES MAINS COURANTES POUR PRODUCTION DU DES MAINSCOURANTES

                                                'MAINCOURANTE JOURANLIERE

                                                FIELD = champEncaissementAMettreAjours(modeReglement)

                                                Dim CODE_MAIN_COURANTE_JOURNALIERE As String = mainCouranteInfo.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

                                                CODE_MAIN_COURANTE = CODE_MAIN_COURANTE_JOURNALIERE

                                                TABLE = "main_courante_journaliere"

                                                If GunaCheckBoxRemboursement.Checked Then
                                                    FIELDVALUE *= -1
                                                End If

                                                mainCourantes.updateMainCouranteJournaliereModeReglement(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                                                If GlobalVariable.actualLanguageValue = 1 Then
                                                    MessageBox.Show("Encaissement effectué avec succès", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                Else
                                                    MessageBox.Show("Cash In successful", "cash In", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                End If

                                                If indexReglement = 0 Or indexReglement = 1 Or indexReglement = 2 Or indexReglement = 4 Or indexReglement = 5 Or indexReglement = 9 Then
                                                    If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then
                                                        pointsDesClientsComptoirs(CODE_CLIENT_FIDELE, MONTANT_REGLEMENT)
                                                    End If
                                                End If

                                            ElseIf encaissementAvantEnregistrementDeReservation Then

                                                If GlobalVariable.actualLanguageValue = 1 Then
                                                    MessageBox.Show("Encaissement effectué avec succès", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                Else
                                                    MessageBox.Show("Cash In successful", "cash In", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                End If

                                                If indexReglement = 0 Or indexReglement = 1 Or indexReglement = 2 Or indexReglement = 4 Or indexReglement = 5 Or indexReglement = 9 Then
                                                    If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then
                                                        pointsDesClientsComptoirs(CODE_CLIENT_FIDELE, MONTANT_REGLEMENT)
                                                    End If
                                                End If

                                            End If

                                            '----------------------------------------------------------------------------------------------------------------------------

                                            'fermer = True **

                                            'COMME ON TRAITE LES GRATUITES ON NE DOIT PAS AVOIR DE MONTANT A REPORTER POUR LES
                                            '-EN CHAMBRES ET LES COMPTOIR

                                            '- RETRANCHEMENT DU MONTANT DES GRATUITES DES MONTANTS A REPORTER

                                            If GunaComboBoxModereglement.SelectedIndex = 6 Then 'GRATUITEES

                                                Dim updateQuery As String = "UPDATE " & TABLE & " SET A_REPORTER = A_REPORTER - @FIELDVALUE WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

                                                Dim command10 As New MySqlCommand(updateQuery, GlobalVariable.connect)

                                                command10.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE
                                                command10.Parameters.Add("@FIELDVALUE", MySqlDbType.Double).Value = FIELDVALUE

                                                'command10.ExecuteNonQuery()

                                            End If

                                        Else

                                            fermer = False

                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                MessageBox.Show("Montant non encaissé !", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            Else
                                                MessageBox.Show("Amount not cashed in !", "Cash In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            End If

                                        End If

                                        'We set back the value of the global value used to know the person to charge for individual or company

                                        'GESTION DES CLUB ELITE

                                        If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then

                                            If GunaComboBoxModereglement.SelectedIndex = 10 Then

                                                Dim elite As New ClubElite()

                                                If GunaComboBoxCritereElite.SelectedIndex = 0 Then

                                                    Dim SEJOURS As Integer = 0
                                                    Dim NUITS As Integer = 0
                                                    Dim CODE_ELITE As String = GunaTextBoxCodeElite.Text
                                                    elite.update_club_elite_membre_client(SEJOURS, NUITS, POINTS * -1, CODE_ELITE)

                                                    Dim infoCodeClient As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_CLIENT_FIDELE, "club_elite_membre_client", "CODE_CLIENT_CARTE", CODE_ELITE, "ID_CARTE_ELITE")
                                                    Dim ACTUEL As Double = 0
                                                    Dim AVANT As Double = 0

                                                    If infoCodeClient.Rows.Count > 0 Then
                                                        ACTUEL = infoCodeClient.Rows(0)("POINTS")
                                                    End If

                                                    AVANT = ACTUEL - POINTS * -1

                                                    Dim VALEUR_FINANCIERE As Double = ACTUEL * VAEUR_DU_POINT
                                                    elite.historiques_des_points(ACTUEL, AVANT, CODE_ELITE, CODE_CLIENT, POINTS * -1, VALEUR_FINANCIERE)

                                                End If

                                            End If

                                        End If

                                        If GlobalVariable.ComingFromFolio1FactureType = "Entreprise" Or GlobalVariable.ComingFromFolio1FactureType = "Company" Then

                                            LabelEntreprise.Visible = False
                                            GunaTextBoxEntreprise.Visible = False
                                            LabelNumeroCompte.Visible = False
                                            GunaTextBoxNumeroCompte.Visible = False

                                            GlobalVariable.ComingFromFolio1FactureType = ""

                                        End If

                                        'Demande d'impression de document apres reglement

                                        If GunaComboBoxModereglement.SelectedIndex = 2 Or GunaComboBoxModereglement.SelectedIndex = 1 Or GunaComboBoxModereglement.SelectedIndex = 9 Then

                                            Dim banque As New Banque()
                                            Dim CODE_BANQUE As String = ""

                                            If GunaComboBoxModereglement.SelectedIndex = 1 Or GunaComboBoxModereglement.SelectedIndex = 9 Then

                                                If GunaComboBoxBanqueEmettrice.SelectedIndex >= 0 Then
                                                    CODE_BANQUE = GunaComboBoxBanqueEmettrice.SelectedValue.ToString
                                                End If

                                            End If

                                            If GunaComboBoxModereglement.SelectedIndex = 2 Then

                                                If GunaComboBoxBanque.SelectedIndex >= 0 Then
                                                    CODE_BANQUE = GunaComboBoxBanque.SelectedValue.ToString
                                                End If

                                            End If

                                            Dim MODE_REGELEMENT As String = modeReglement
                                            Dim CODE_REGLEMENT As String = NUM_REGLEMENT
                                            Dim DEBIT As Double = 0
                                            Dim CREDIT As Double = MONTANT_REGLEMENT
                                            Dim CODE_TRANSCATION As String = Functions.GeneratingRandomCodeWithSpecifications("banque_transaction", "")

                                            'INFORMATION SUPLLEMTAIRE LIEES A LA CARTE DE CREDIT
                                            banque.insertBanqueTransactions(CODE_BANQUE, MODE_REGELEMENT, CODE_REGLEMENT, DEBIT, CREDIT, CODE_AGENCE, CODE_TRANSCATION)

                                        End If

                                        Dim dialog As DialogResult

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            dialog = MessageBox.Show("Voulez-vous Imprimer Le reçu ", "Impression de reçu", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        Else
                                            dialog = MessageBox.Show("Do you want to print the receipt ", "Receipt printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        End If

                                        If dialog = DialogResult.No Then
                                            'e.Cancel = True
                                        Else

                                            imprimerRecu = True

                                            GlobalVariable.DocumentToGenerate = "reglement"

                                        End If

                                        'On ouvre le folio qui a etet ferme
                                        If Not Trim(GlobalVariable.ComingFromFolio1FactureType) = "" Then

                                            FolioForm.Close()

                                            FolioForm.Show()
                                            FolioForm.TopMost = True

                                        End If

                                    Else

                                        'Montant versé inférieur au montant 
                                        fermer = False

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            MessageBox.Show("Bien vouloir saisir un montant correcte!", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Else
                                            MessageBox.Show("Please type in a correct amount !", "Cash in", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End If

                                        GunaTextBoxMontantVerse.Text = 0

                                    End If

                                    'We have to activate the MainWindow so as to refresh the value of the GunaLabelSolde in the activated event of the MainWindow
                                    If Not CODE_RESERVATION = "" Then

                                        'Facturation des en chambres
                                        Dim reservation As New Reservation()

                                        'MessageBox.Show(Functions.SituationDeReservation(CODE_RESERVATION))
                                        reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))
                                        Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION)

                                        fermer = True

                                    End If

                                    GlobalVariable.cardPaiement = 0

                                    If Not Trim(CODE_RESERVATION) = "" Then

                                        'MISE A JOURS DU COMPTE DU CLIENT SI PAS RATTACHE A UNE ENTREPRISE OU LE COMPTE DE L'INDIVIDU

                                        Dim compte As New Compte()
                                        Dim CODE_CLIENT As String = ""

                                        If Not infoSupResa.Rows(0)("CODE_ENTREPRISE").Equals("") Then
                                            CODE_CLIENT = infoSupResa.Rows(0)("CODE_ENTREPRISE")
                                        Else
                                            CODE_CLIENT = infoSupResa.Rows(0)("CLIENT_ID")
                                        End If

                                        Dim compteEntreprise As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                                        If compteEntreprise.Rows.Count > 0 Then

                                            Dim NUMERO_COMPTE As String = compteEntreprise.Rows(0)("NUMERO_COMPTE")

                                            Dim TOTAL_DEBIT As Double = 0
                                            Dim TOTAL_CREDIT As Double = 0

                                            If GunaComboBoxModereglement.SelectedIndex = 0 Or GunaComboBoxModereglement.SelectedIndex = 1 Or GunaComboBoxModereglement.SelectedIndex = 2 Or GunaComboBoxModereglement.SelectedIndex = 3 Or GunaComboBoxModereglement.SelectedIndex = 4 Or GunaComboBoxModereglement.SelectedIndex = 5 Or GunaComboBoxModereglement.SelectedIndex = 9 Then
                                                TOTAL_CREDIT = Double.Parse(montantCredit)
                                            End If

                                            compte.updateCompteAlaClotureDuFolio(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT)

                                        End If

                                        Dim DEPOT_DE_GARANTIE_RESA As Double = infoSupResa.Rows(0)("DEPOT_DE_GARANTIE")
                                        Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate
                                        Dim reservation As New Reservation
                                        Dim updatedSolde As Double = Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate)
                                        reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", updatedSolde)

                                        'ON DOIT METTRE A JOUR LE DEPOT DE GARANTIE CONTENU DANS LA RESERVATION ET LA TABLE DE GESTION DES DEPOTS DE GARANTIE

                                        If GunaCheckBoxArrhes.Checked Then
                                            Dim SOLDE As Double = 0
                                            Dim infoDepot As DataTable = Functions.getElementByCode(CODE_CAUTION, "caution", "CODE_CAUTION")
                                            If infoDepot.Rows.Count > 0 Then
                                                Dim CREDIT As Double = infoDepot.Rows(0)("CREDIT")
                                                Dim DEBIT As Double = infoDepot.Rows(0)("DEBIT")
                                                SOLDE = infoDepot.Rows(0)("SOLDE")

                                                reservation.miseAjourDesDepotDeGarantiesRreservation(CODE_RESERVATION, DEPOT_DE_GARANTIE, DEPOT_DE_GARANTIE_RESA)

                                                reservation.miseAjourDesDepotDeGaranties(CODE_CAUTION, DEPOT_DE_GARANTIE)

                                                If DEBIT + DEPOT_DE_GARANTIE = CREDIT Then
                                                    Dim ETAT_DEPOT As String = "Consommé"
                                                    If GlobalVariable.actualLanguageValue = 0 Then
                                                        ETAT_DEPOT = "Consumed"
                                                    End If
                                                    Functions.updateOfFields("caution", "ETAT_DEPOT", ETAT_DEPOT, "CODE_CAUTION", CODE_CAUTION, 2)
                                                End If

                                            End If

                                            If infoDepot.Rows.Count > 0 Then

                                                Dim infoResa As DataTable = Functions.getElementByCode(infoDepot.Rows(0)("CODE_RESERVATION"), "reserve_conf", "CODE_RESERVATION")

                                                If infoResa.Rows.Count > 0 Then
                                                    MainWindow.GunaTextBoxDepotDeGarantie.Text = infoDepot.Rows(0)("SOLDE") - DEPOT_DE_GARANTIE
                                                End If

                                            End If

                                            GunaCheckBoxArrhes.Checked = False

                                        End If

                                    End If

                                    GlobalVariable.ComingFromFolio1FactureType = ""

                                End If

                                Me.Cursor = Cursors.Default

                            End If

                        Else

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Vous ne pouvez pas encaisser, car vous n'avez aucune caisse! ", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                MessageBox.Show("You can't cash in, you dont' have a cash register! ", "Cash In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                        End If

                    Else

                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Vous n'êtes pas abilité à encaisser! ", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        Else
                            MessageBox.Show("You don't have the right to cas in ! ", "Cash In", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If

                    End If

                    Dim doManualRefreshOfMainWindow As Boolean = False
                    If MainWindow.Visible Then
                        doManualRefreshOfMainWindow = True
                    End If

                    If fermer Then

                        If (Not GlobalVariable.typeDeClientAFacturer = "comptoir") And doManualRefreshOfMainWindow Then

                            If Not infoSupResa Is Nothing Then

                                If infoSupResa.Rows.Count > 0 Then

                                    Dim CODE_RESERVATION As String = infoSupResa(0)("CODE_RESERVATION")

                                    Dim solde As Double = Functions.SituationDeReservation(CODE_RESERVATION)

                                    MainWindow.GunaLabelSolde.Text = Format(solde, "#,##0")

                                    If 0 > solde Then
                                        MainWindow.GunaLabelSolde.ForeColor = Color.Red
                                    ElseIf solde = 0 Then
                                        MainWindow.GunaLabelSolde.ForeColor = Color.Black
                                    Else
                                        MainWindow.GunaLabelSolde.ForeColor = Color.Green
                                    End If

                                    MainWindow.MainWindowManualActivation()

                                    MainWindow.Refresh()

                                End If

                            End If

                        End If

                        If blocNoteTermine Then '**

                            If ETAT_FACTURE_POUR_COMPTE > -1 Then
                                LigneFacture.UpdateEtatLigneFacturePourClientComptoire(NUMERO_BLOC_NOTE, ETAT_FACTURE_POUR_COMPTE, ETAT_BLOC_NOTE)
                            End If

                            If ETAT_FACTURE_POUR_EN_CHAMBRE > -1 Then
                                LigneFacture.UpdateEtatLigneFacturePourClientComptoire(NUMERO_BLOC_NOTE, ETAT_FACTURE_POUR_EN_CHAMBRE, ETAT_BLOC_NOTE)
                            End If

                        End If

                        If imprimerRecu Then

                            Dim DernierReglement As DataTable = Functions.allTableFields("reglement")
                            Dim codeDernierReglement As String = DernierReglement.Rows(DernierReglement.Rows.Count - 1)("NUM_REGLEMENT")
                            Dim codeReservation As String = CODE_RESERVATION

                            Functions.DocumentToPrintComptoire(codeDernierReglement, "reglement", "NUM_REGLEMENT", CODE_CLIENT, dt, codeReservation, GunaTextBoxCodeDepot.Text)

                        End If

                        Me.Close()

                    End If

                End If

            End If


        End If

    End Sub

    'We refresh the content of the Folio Datagrids each time a new reglement is done
    Private Sub ReglementForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        Dim Folio As New FolioForm()

        Folio.GunaDataGridViewFolio1.Refresh()

        Folio.GunaDataGridViewFolio2.Refresh()

        Folio.GunaDataGridViewFolio3.Refresh()

        Folio.GunaDataGridViewFolio4.Refresh()

    End Sub

    Private Sub GunaTextBoxEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxEntreprise.TextChanged

        Dim table As New DataTable()
        Dim query As String = ""

        Dim ETAT_DU_COMPTE As Integer = 1

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxEntreprise.Text).Equals("") Then

            GunaButtonEnregistrerReglement.Enabled = False

            GunaTextBoxEntreprise.Clear()
            GunaTextBoxNumeroCompte.Text = ""

            GunaDataGridViewCompany.Visible = False
            GunaButtonEnregistrerReglement.Visible = True

            'GunaTextBoxNumeroCompte.BackColor = Color.White
            GunaTextBoxNumeroCompte.BaseColor = Color.White

        End If

        GunaDataGridViewCompany.Visible = True

        Dim TYPE_CLIENT As String = ""

        If typeDeCompte = "individuel" Then

            If GlobalVariable.actualLanguageValue = 1 Then
                TYPE_CLIENT = "Individuel"
            Else
                TYPE_CLIENT = "Individual"
            End If
        ElseIf typeDeCompte = "entreprise" Then
            If GlobalVariable.actualLanguageValue = 1 Then
                TYPE_CLIENT = "Entreprise"
            Else
                TYPE_CLIENT = "Company"
            End If

        End If

        'If typeDeCompte = "entreprise" Then

        'UN COMPTE DOIT TOUJOURS ETRE ASSOCIE A UN CLIENT SAUF POUR LES COMPTE PAYMASTER

        If typeDeCompte = "individuel" Then

            If GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "INDIVIDUEL" Then
                query = "SELECT NOM_CLIENT, client.CODE_CLIENT From client, compte WHERE NOM_CLIENT LIKE '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT AND compte.NUMERO_COMPTE =client.NUM_COMPTE AND ETAT_DU_COMPTE=@ETAT_DU_COMPTE ORDER BY NOM_CLIENT ASC "
            ElseIf GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "COMPTE" Then
                query = "SELECT INTITULE, NUMERO_COMPTE From compte WHERE INTITULE LIKE '%" & GunaTextBoxEntreprise.Text & "%' AND ETAT_DU_COMPTE =@ETAT_DU_COMPTE AND CODE_CLIENT=@CODE_CLIENT ORDER BY INTITULE ASC"
            End If

        ElseIf typeDeCompte = "entreprise" Then
            'ON AFFICHE QUE LES CLIENT AYANTS UN COMPTE ACTIF
            query = "SELECT NOM_CLIENT, client.CODE_CLIENT From client, compte WHERE NOM_CLIENT LIKE '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT AND compte.NUMERO_COMPTE =client.NUM_COMPTE AND ETAT_DU_COMPTE=@ETAT_DU_COMPTE ORDER BY NOM_CLIENT ASC "
        End If

        If typeDeCompte = "individuel" Or typeDeCompte = "entreprise" Then

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
            command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = TYPE_CLIENT
            command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = ""
            command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

        End If


        If (table.Rows.Count > 0) Then
            GunaDataGridViewCompany.DataSource = table
        Else
            GunaDataGridViewCompany.Columns.Clear()
            GunaDataGridViewCompany.Visible = False
        End If

        If GunaTextBoxEntreprise.Text.Trim().Equals("") Then
            GunaDataGridViewCompany.Columns.Clear()
            GunaDataGridViewCompany.Visible = False
        End If

        'connect.closeConnection()

    End Sub

    Public Sub gestionDesComptesDebiteurLorsDesReservations(ByVal NUMERO_COMPTE As String)

        '---------------------- GESTION DES COMPTES DEBITEUR ENTREPRISE ASSOCIE A LA RESERVATION ----------------

        'SELECTION DU COMPTE DE L'ENTREPRISE ACTUEL
        Dim compte As DataTable = Functions.getElementByCode(NUMERO_COMPTE, "compte", "NUMERO_COMPTE")

        If compte.Rows.Count > 0 Then

            GunaButtonEnregistrerReglement.Visible = False

            'GunaTextBoxCompteDebiteur.Visible = True

            If compte.Rows(0)("ETAT_DU_COMPTE") = 1 Then
                'COMPTE ACTIF

                Dim ETAT_DU_COMPTE As Double = 0

                If Double.Parse(compte.Rows(0)("SOLDE_COMPTE")) < 0 Then
                    ETAT_DU_COMPTE = Double.Parse(compte.Rows(0)("PLAFONDS_DU_COMPTE")) - Math.Abs(Double.Parse(compte.Rows(0)("SOLDE_COMPTE")))
                End If

                If ETAT_DU_COMPTE >= 0 Then
                    'AU DESSUS  
                    GunaTextBoxNumeroCompte.BaseColor = Color.Green
                Else
                    'EN DESSOUS
                    GunaTextBoxNumeroCompte.BaseColor = Color.Red
                End If

                GunaButtonEnregistrerReglement.Visible = True
                'GunaTextBoxNumeroCompte.Text = compte.Rows(0)("NUMERO_COMPTE")

            Else

                'COMPTE INACTIF
                GunaTextBoxNumeroCompte.BaseColor = Color.Red
                GunaTextBoxNumeroCompte.Text = compte.Rows(0)("NUMERO_COMPTE") & " (Inactif)"
                'ON MASQUE LE BOUTON D'ENREGISTREMENT SI LE COMPTE EST INACTIF
                GunaButtonEnregistrerReglement.Visible = False
            End If

        Else

            GunaButtonEnregistrerReglement.Visible = False

        End If

        If Trim(GunaTextBoxEntreprise.Text) = "" Then
            GunaTextBoxNumeroCompte.Text = ""
        End If

        GunaTextBoxNumeroCompte.ForeColor = Color.White
        GunaTextBoxNumeroCompte.TextAlign = HorizontalAlignment.Center
        '----------------------  --------------

    End Sub

    Private Sub GunaDataGridViewCompany_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewCompany.CellClick

        GunaDataGridViewCompany.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewCompany.Rows(e.RowIndex)

            Dim NUMERO_COMPTE As String

            If typeDeCompte = "entreprise" Then

                'Dim company As DataTable = Functions.getElementByCode(row.Cells("NOM_CLIENT").Value.ToString, "client", "NOM_CLIENT")

                Dim CODE_CLIENT As String = row.Cells("CODE_CLIENT").Value.ToString

                GunaAdvenceButtonCodeClientDuCompte.Text = CODE_CLIENT

                GunaTextBoxEntreprise.Text = row.Cells("NOM_CLIENT").Value.ToString
                'GunaTextBoxEntreprise.Text = company.Rows(0)("CODE_CLIENT")

                'Dim client As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

                Dim compte As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                If compte.Rows.Count > 0 Then
                    GunaTextBoxNumeroCompte.Text = compte.Rows(0)("NUMERO_COMPTE")
                    NUMERO_COMPTE = compte.Rows(0)("NUMERO_COMPTE")
                Else
                    GunaTextBoxNumeroCompte.Text = "PAS DE COMPTE"
                End If

            ElseIf typeDeCompte = "individuel" Then

                If GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "INDIVIDUEL" Then

                    Dim CODE_CLIENT As String = row.Cells("CODE_CLIENT").Value.ToString

                    GunaAdvenceButtonCodeClientDuCompte.Text = CODE_CLIENT

                    GunaTextBoxEntreprise.Text = row.Cells("NOM_CLIENT").Value.ToString
                    'GunaTextBoxEntreprise.Text = company.Rows(0)("CODE_CLIENT")

                    'Dim client As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

                    Dim compte As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                    If compte.Rows.Count > 0 Then
                        GunaTextBoxNumeroCompte.Text = compte.Rows(0)("NUMERO_COMPTE")
                        NUMERO_COMPTE = compte.Rows(0)("NUMERO_COMPTE")
                    Else
                        GunaTextBoxNumeroCompte.Text = "PAS DE COMPTE"
                    End If

                ElseIf GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "COMPTE" Then

                    Dim INTITULE_DU_COMPTE As String = row.Cells("INTITULE").Value.ToString

                    NUMERO_COMPTE = row.Cells("NUMERO_COMPTE").Value.ToString

                    GunaTextBoxNumeroCompte.Text = NUMERO_COMPTE

                    GunaTextBoxEntreprise.Text = row.Cells("INTITULE").Value.ToString

                End If

            End If

            If Not Trim(GunaTextBoxNumeroCompte.Text).Equals("") Then
                GunaButtonEnregistrerReglement.Enabled = True
            Else
                GunaButtonEnregistrerReglement.Enabled = False
            End If

            GunaDataGridViewCompany.Visible = False

            gestionDesComptesDebiteurLorsDesReservations(NUMERO_COMPTE)

            'connect.closeConnection()

        End If

    End Sub

    'SITUATION DE CAISSE
    Private Sub PanelSituationCaisse_DoubleClick(sender As Object, e As EventArgs) Handles PanelSituationCaisse.DoubleClick

        GlobalVariable.DocumentToGenerate = "situation caisse"
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Functions.DocumentToPrintSituation(CODE_CAISSIER, "reglement", "CODE_CAISSIER", GlobalVariable.DateDeTravail)
        GlobalVariable.DocumentToGenerate = ""

    End Sub

    Private Sub LabelSituationCaisse_DoubleClick(sender As Object, e As EventArgs) Handles LabelSituationCaisse.DoubleClick

        GlobalVariable.DocumentToGenerate = "situation caisse"
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Functions.DocumentToPrintSituation(CODE_CAISSIER, "reglement", "CODE_CAISSIER", GlobalVariable.DateDeTravail)
        GlobalVariable.DocumentToGenerate = ""

    End Sub

    Private Sub EnChambreGrat()

        'On affiche toutes les reserv_conf dont la date saisie est entre la d'entrée et la date de sortie (inclusif)

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxNumChambreGrat.DataSource = table
            GunaComboBoxNumChambreGrat.ValueMember = "RESERVATION"
            GunaComboBoxNumChambreGrat.DisplayMember = "CHAMBRE"

        End If

        'connect.closeConnection()
    End Sub

    Private Sub EnChambre()

        'On affiche toutes les reserv_conf dont la date saisie est entre la d'entrée et la date de sortie (inclusif)

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE_ID DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxCodeChambre.DataSource = table
            GunaComboBoxCodeChambre.ValueMember = "RESERVATION"
            GunaComboBoxCodeChambre.DisplayMember = "CHAMBRE"

        Else
            GunaButtonEnregistrerReglement.Enabled = False
        End If

        'connect.closeConnection()
    End Sub

    'AU CHANGEMENT DU CODE DE CHAMBRE LORS DU TRANSFERT EN CHAMBRE
    Private Sub GunaComboBoxCodeChambre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCodeChambre.SelectedIndexChanged

        If GunaComboBoxCodeChambre.SelectedIndex >= 0 Then

            Dim CODE_RESERVATION As String = GunaComboBoxCodeChambre.SelectedValue.ToString

            Dim reservationInfo As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

            If reservationInfo.Rows.Count > 0 Then

                GunaTextBoxNomClient.Text = reservationInfo.Rows(0)("NOM_CLIENT")
                GunaTextBoxCodeChambre.Text = reservationInfo.Rows(0)("CHAMBRE_ID")
                GunaTextBoxCodeReservation.Text = reservationInfo.Rows(0)("CODE_RESERVATION")
                GunaTextBoxCodeClient.Text = reservationInfo.Rows(0)("CLIENT_ID")

            End If

        End If

    End Sub

    Dim typeDeCompte As String = ""

    Dim MontantAPayer

    Dim MONTANT_DEJA_REGLE As Double = 0

    Private Sub GunaComboBoxModereglement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxModereglement.SelectedIndexChanged

        'AFFICHAGE AUTOMATIQUE DU PRIX A REGLER OU DU PRIX A ENCAISSER

        If GunaCheckBoxArrhes.Checked Then
            If GlobalVariable.actualLanguageValue = 1 Then
                DEPOT_GARANTIE_PAR = "PAR DEPOT GARANTIE / "
            Else
                DEPOT_GARANTIE_PAR = ""
            End If
        Else
            DEPOT_GARANTIE_PAR = ""
        End If

        GunaComboBoxCritereElite.SelectedIndex = -1

        GunaTextBoxMontantVerse.Text = GunaTextBoxAPayer.Text

        If GunaComboBoxModereglement.SelectedIndex = 10 Then
            GunaPanelClubElite.Visible = True
            GunaComboBoxCritereElite.SelectedIndex = 0
        Else
            GunaPanelClubElite.Visible = False
        End If

        If GunaComboBoxModereglement.SelectedIndex = 2 Then
            GunaPanelSupplementCarte.Visible = True
            LabelDateExpiration.Visible = True
            LabelNumCarte.Visible = True
            GunaButtonEnregistrerReglement.Enabled = True
            LabelCVV.Visible = True
            GunaPanelSupplementCarte.BringToFront()
        Else
            GunaPanelSupplementCarte.Visible = False
            LabelDateExpiration.Visible = False
            LabelNumCarte.Visible = False
            LabelCVV.Visible = False

        End If

        If GunaComboBoxModereglement.SelectedIndex = 0 Then

            If Not Trim(GunaTextBoxMontantVerse.Text).Equals("") Then
                GunaButtonEnregistrerReglement.Enabled = True
            Else
                GunaButtonEnregistrerReglement.Enabled = False
            End If

        End If

        If GunaComboBoxModereglement.SelectedIndex = 8 Then

            If GunaComboBoxCodeChambre.Items.Count > 0 Then
                GunaButtonEnregistrerReglement.Enabled = True
            Else
                GunaButtonEnregistrerReglement.Enabled = False
            End If

        End If

        If GunaComboBoxModereglement.SelectedIndex = 1 Or GunaComboBoxModereglement.SelectedIndex = 9 Then
            GunaPanelSupplementCheque.Visible = True
            LabelBanqueEmettrice.Visible = True
            LabelNumCompte.Visible = True
            GunaPanelSupplementCheque.BringToFront()

            If GunaComboBoxModereglement.SelectedIndex = 1 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    LabelBanqueEmettrice.Text = "Banque Emettrice"
                    LabelNumCompte.Text = "Numéro de chèque"
                Else
                    LabelBanqueEmettrice.Text = "Issuing bank"
                    LabelNumCompte.Text = "Cheque number"
                End If

            ElseIf GunaComboBoxModereglement.SelectedIndex = 2 Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    LabelBanqueEmettrice.Text = "Banque Emettrice"
                    LabelNumCompte.Text = "Référence Transaction"
                Else
                    LabelBanqueEmettrice.Text = "Issuing bank"
                    LabelNumCompte.Text = "Transaction Reference"
                End If

            End If

        Else
            GunaPanelSupplementCheque.Visible = False
            LabelBanqueEmettrice.Visible = False
            LabelNumCompte.Visible = False

        End If

        'TRANSFERT VERS COMPTE
        If GunaComboBoxModereglement.SelectedIndex = 3 Or GunaComboBoxModereglement.SelectedIndex = 8 Then

            GunaButtonEnregistrerReglement.Enabled = False

            PanelTransfertVersCompte.Visible = True
            PanelTransfertVersCompte.BringToFront()
            LabelEntreprise.Visible = True

            If GunaComboBoxModereglement.SelectedIndex = 3 Then
                typeDeCompte = "entreprise"

                If GlobalVariable.actualLanguageValue = 1 Then
                    LabelEntreprise.Text = "ENTREPRISE"
                Else
                    LabelEntreprise.Text = "COMPANY"
                End If

                GunaComboBoxCompteIndividuelOuPaymaster.Visible = False

            ElseIf GunaComboBoxModereglement.SelectedIndex = 8 Then

                typeDeCompte = "individuel"
                GunaComboBoxCompteIndividuelOuPaymaster.Visible = True

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "INDIVIDUEL"
                    LabelEntreprise.Text = "INDIVIDUEL"
                Else
                    GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "INDIVIDUAL"
                    LabelEntreprise.Text = "INDIVIDUAL"
                End If

            End If

            GunaTextBoxMontantVerse.Enabled = False
            GunaTextBoxEntreprise.Visible = True
            LabelNumeroCompte.Visible = True
            GunaTextBoxNumeroCompte.Visible = True

        Else

            GunaTextBoxMontantVerse.Enabled = True
            PanelTransfertVersCompte.Visible = False
            LabelEntreprise.Visible = False
            GunaTextBoxEntreprise.Visible = False
            GunaTextBoxNumeroCompte.Visible = False
            LabelNumeroCompte.Visible = False

        End If

        If GunaComboBoxModereglement.SelectedIndex = 4 Or GunaComboBoxModereglement.SelectedIndex = 5 Then
            LabelContact.Visible = True
            GunaTextBoxContact.Visible = True
        Else
            LabelContact.Visible = False
            GunaTextBoxContact.Visible = False
        End If

        If GunaComboBoxModereglement.SelectedIndex = 6 Then

            GunaPanelGratuite.Visible = True
            LabelAuthorisee.Visible = True
            LabelRemarque.Visible = True

        Else

            GunaPanelGratuite.Visible = False
            LabelAuthorisee.Visible = False
            LabelRemarque.Visible = False

        End If

        'TRANSFERT EN CHAMBRE

        If GunaComboBoxModereglement.SelectedIndex = 7 Then

            Dim MONTANT_TOTAL As Double = 0
            GunaButtonEnregistrerReglement.Enabled = True
            'For Each row As DataGridViewRow In GunaDataGridViewLigneFactureReglement.SelectedRows
            'MONTANT_TOTAL += Double.Parse(Trim(row.Cells("Debit").Value.ToString))
            'Next

            If Not Trim(GunaTextBoxMontantVerse.Text).Equals("") Then
                MONTANT_TOTAL += Double.Parse(GunaTextBoxMontantVerse.Text)
            End If

            GunaTextBoxMontantATransferer.Text = Format(MONTANT_TOTAL, "#,##0")

            GunaTextBoxNomClient.Visible = True
            GunaPanelTransfertEnChambre.Visible = True
            GunaComboBoxCodeChambre.Visible = True
            'GunaTextBoxCodeResa.Visible = False
            LabelChambre.Visible = True
            LabelNomClient.Visible = True

            EnChambre()

        Else

            GunaTextBoxNomClient.Visible = False
            GunaComboBoxCodeChambre.Visible = False
            GunaPanelTransfertEnChambre.Visible = False
            'GunaTextBoxCodeResa.Visible = False
            LabelChambre.Visible = False
            LabelNomClient.Visible = False

        End If

        If GunaComboBoxModereglement.SelectedIndex = 1 Or GunaComboBoxModereglement.SelectedIndex = 9 Then
            GunaComboBoxBanque.Visible = True
            Label7.Visible = True

            Dim query As String = "SELECT * From banque ORDER BY NOM_BANQUE ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaComboBoxBanqueEmettrice.DataSource = table
                GunaComboBoxBanqueEmettrice.ValueMember = "CODE_BANQUE"
                GunaComboBoxBanqueEmettrice.DisplayMember = "NOM_BANQUE"

            Else
                GunaComboBoxBanqueEmettrice.Items.Clear()
            End If

        Else
            GunaComboBoxBanque.Visible = False
            Label7.Visible = False
        End If

        If GunaComboBoxModereglement.SelectedIndex = 2 Then
            GunaComboBoxBanque.Visible = True
            Label7.Visible = True

            Dim query As String = "SELECT * From banque ORDER BY NOM_BANQUE ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then

                GunaComboBoxBanque.DataSource = table
                GunaComboBoxBanque.ValueMember = "CODE_BANQUE"
                GunaComboBoxBanque.DisplayMember = "NOM_BANQUE"

            Else
                GunaComboBoxBanque.Items.Clear()
            End If

        Else
            GunaComboBoxBanque.Visible = False
            Label7.Visible = False
        End If

        Dim chambre As String = "[" & NOM_CLIENT & " / " & CODE_CHAMBRE & "]"

        If GlobalVariable.actualLanguageValue = 1 Then
            If Not Trim(GlobalVariable.blocNoteARegler) = "" Then
                'GunaTextBoxReference.Text = "REGLEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & GunaTextBoxClientAFacturer.Text & chambre
                GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "REGLEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & chambre
            Else
                GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "ENCAISSEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & chambre
            End If
        Else
            If Not Trim(GlobalVariable.blocNoteARegler) = "" Then
                'GunaTextBoxReference.Text = "REGLEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & GunaTextBoxClientAFacturer.Text & chambre
                GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "CASH IN (" & GunaComboBoxModereglement.SelectedItem & ") OF " & chambre
            Else
                GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "CASH IN (" & GunaComboBoxModereglement.SelectedItem & ") OF " & chambre
            End If
        End If

        If GunaComboBoxModereglement.SelectedIndex = 0 Or GunaComboBoxModereglement.SelectedIndex = 4 Or GunaComboBoxModereglement.SelectedIndex = 5 Then
            GunaPanelGestCaisse.Visible = True
        Else
            GunaPanelGestCaisse.Visible = False
        End If

        If GunaComboBoxModereglement.SelectedIndex = 6 Then
            GunaButtonEnregistrerReglement.Visible = False
        Else
            GunaButtonEnregistrerReglement.Visible = True
        End If

        GunaComboBoxCompteIndividuelOuPaymaster.SelectedIndex = 0

    End Sub


    Private Sub GunaTextBoxSolde_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxSolde.TextChanged

        Dim balance As Double = 0

        Double.TryParse(GunaTextBoxSolde.Text, balance)

        If balance < 0 Then
            'LabelSolde.Text = "Solde à rembourser"
        Else
            'LabelSolde.Text = "Solde à payer"
        End If

    End Sub


    Public Function upDateEtatGeneral(ByVal TABLE As String, ByVal NOM_DU_CHAMP_ETAT As String, ByVal VALEUR_ETAT As Integer, ByVal ID_LIGNE_FACTURE As Integer)

        Dim updateQuery As String = "UPDATE " & TABLE & " SET " & NOM_DU_CHAMP_ETAT & "=@VALEUR_ETAT WHERE ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@VALEUR_ETAT", MySqlDbType.Int64).Value = VALEUR_ETAT
        command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = ID_LIGNE_FACTURE

        command.ExecuteNonQuery()

    End Function

    Private Sub PictureBoxClearArticleFields_Click(sender As Object, e As EventArgs) Handles PictureBoxClearArticleFields.Click
        GunaTextBoxEntreprise.Clear()
    End Sub

    Private Sub GunaComboBoxCompteIndividuelOuPaymaster_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCompteIndividuelOuPaymaster.SelectedIndexChanged

        GunaAdvenceButtonCodeClientDuCompte.Text = ""

        If GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "INDIVIDUEL" Then
            LabelEntreprise.Text = "INDIVIDUEL"
        ElseIf GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "COMPTE" Then
            LabelEntreprise.Text = "COMPTE"
        End If

        GunaButtonEnregistrerReglement.Enabled = False

        GunaTextBoxEntreprise.Clear()

    End Sub

    Public Function champEncaissementAMettreAjours(ByVal modeReglement As String) As String

        Dim field As String = ""

        If modeReglement = "Espèce" Or modeReglement = "Cash" Then
            field = "ENCAISSEMENT_ESPECE"
        ElseIf modeReglement = "Chèque" Or modeReglement = "Virement Bancaire" Or modeReglement = "Cheque" Or modeReglement = "Bank Transfer" Then
            field = "ENCAISSEMENT_CHEQUE"
        ElseIf modeReglement = "Carte de crédit" Or modeReglement = "Carte Bancaire" Or modeReglement = "Credit Card" Then
            field = "ENCAISSEMENT_CARTE_CREDIT"
        ElseIf modeReglement = "MTN Money" Or modeReglement = "ORANGE Money" Then
            field = "TELE"
        ElseIf modeReglement = "Gratuitée" Or modeReglement = "Free" Then
            field = "TOTAL_GRATUITES"
        ElseIf modeReglement = "Transfert En chambre" Or modeReglement = "Room Transfer" Then
            field = "CHAMBRES_NON_FACTUREES"
        ElseIf modeReglement = "Transfert Vers Compte Débiteur" Or modeReglement = "Prise en charge" Or modeReglement = "Transfer to Debtor Account" Or modeReglement = "Taking charge" Then
            field = "DEBITEUR"
        Else
            field = "ENCAISSEMENT_CARTE_CREDIT"
        End If

        Return field

    End Function

    Private Sub GunaTextBoxMontantPercu_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantPercu.TextChanged

        If Not Trim(GunaTextBoxMontantVerse.Text) = "" Then
            If Not Trim(GunaTextBoxMontantPercu.Text) = "" Then
                GunaTextBoxMontantRendu.Text = Format(GunaTextBoxMontantPercu.Text - GunaTextBoxMontantVerse.Text)
            End If
        End If

    End Sub

    Private Sub GunaComboBoxNumChambreGrat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNumChambreGrat.SelectedIndexChanged

        If GunaComboBoxNumChambreGrat.SelectedIndex >= 0 Then

            Dim CODE_RESERVATION As String = GunaComboBoxNumChambreGrat.SelectedValue.ToString

            Dim reservationInfo As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

            If reservationInfo.Rows.Count > 0 Then

                GunaTextBoxNomClientGrat.Text = reservationInfo.Rows(0)("NOM_CLIENT")
                GunaTextBoxCodeChambreGrat.Text = reservationInfo.Rows(0)("CHAMBRE_ID")
                GunaTextBoxCodeResaGrat.Text = reservationInfo.Rows(0)("CODE_RESERVATION")
                GunaTextBoxCodeClientGrat.Text = reservationInfo.Rows(0)("CLIENT_ID")

            End If

        End If

    End Sub

    Private Sub GunaCheckBoxOffresEnChambre_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxOffresEnChambre.CheckedChanged

        If GunaCheckBoxOffresEnChambre.Checked Then

            EnChambreGrat()

            GunaComboBoxNumChambreGrat.Visible = True
            Label9.Visible = True
            Label10.Visible = True
            Label10.Visible = True
            GunaTextBoxNomClientGrat.Visible = True

        Else

            GunaComboBoxNumChambreGrat.Visible = False
            Label9.Visible = False
            Label10.Visible = False
            Label10.Visible = False
            GunaTextBoxNomClientGrat.Visible = False

            GunaTextBoxNomClientGrat.Clear()
            GunaTextBoxCodeResaGrat.Clear()
            GunaTextBoxCodeChambreGrat.Clear()
            GunaTextBoxCodeClientGrat.Clear()

            GunaComboBoxNumChambreGrat.DataSource = Nothing

        End If

    End Sub

    Private Sub GunaTextBoxAuthorisation_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxAuthorisation.TextChanged

        If Trim(GunaTextBoxAuthorisation.Text).Equals("") Then
            GunaButtonEnregistrerReglement.Visible = False
        Else
            GunaButtonEnregistrerReglement.Visible = True
        End If

    End Sub

    Private Sub GunaComboBoxECritereElite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCritereElite.SelectedIndexChanged

        If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then

            Label13.Text = GunaComboBoxCritereElite.SelectedItem

            Dim TYPE_CHAMBRE As String = ""
            Dim VALEUR_DE_LA_NUITEE As Double = 0

            Dim infoSupResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

            If infoSupResa IsNot Nothing Then

                If infoSupResa.Rows.Count > 0 Then
                    TYPE_CHAMBRE = infoSupResa.Rows(0)("TYPE_CHAMBRE")
                    VALEUR_DE_LA_NUITEE = infoSupResa.Rows(0)("MONTANT_ACCORDE")
                End If

            End If

            'Dim CODE_CLIENT As String = GunaTextBoxNom.Text
            Dim CODE_CLIENT As String = GunaTextBoxCodeClientFidele.Text

            Dim CODE_ELITE As String = GunaTextBoxCodeElite.Text
            Dim elite As New ClubElite()

            Dim eliteBonus As DataTable = elite.infoDuCodeElite(CODE_ELITE)

            If eliteBonus.Rows.Count > 0 Then

                If GunaComboBoxCritereElite.SelectedIndex = 0 Then
                    'POINTS
                    Dim POINTS As Double = eliteBonus.Rows(0)("POINTS")
                    Dim VAEUR_DU_POINT As Double = eliteBonus.Rows(0)("VAEUR_DU_POINT")
                    GunaTextBoxValeurDuPoint.Text = VAEUR_DU_POINT
                    GunaTextBoxCritere.Text = Format(POINTS, "#,##0")

                    Dim MONTANT_A_PAYER As Double = 0

                    If Not Trim(GunaTextBoxAPayer.Text).Equals("") Then
                        MONTANT_A_PAYER = GunaTextBoxAPayer.Text
                    End If

                    Dim MONTANT_DES_POINTS As Double = POINTS * VAEUR_DU_POINT
                    GunaTextBoxValeurTotalCritere.Text = Format(MONTANT_DES_POINTS, "#,##0")

                    Dim MONTANT_VERSE As Double = 0
                    If MONTANT_DES_POINTS >= MONTANT_A_PAYER Then
                        MONTANT_VERSE = MONTANT_A_PAYER
                    Else
                        MONTANT_VERSE = MONTANT_DES_POINTS
                    End If

                    GunaTextBoxMontantVerse.Text = Format(MONTANT_VERSE, "#,##0")

                    If POINTS > 0 Then
                        GunaButtonEnregistrerReglement.Enabled = True
                    Else
                        GunaButtonEnregistrerReglement.Enabled = False
                    End If

                    'If VAEUR_DU_POINT > 0 Then
                    'GunaTextBoxValeurDuPoint.Text = Format(MONTANT_VERSE / VAEUR_DU_POINT, "#,##0")
                    'End If

                ElseIf GunaComboBoxCritereElite.SelectedIndex = 1 Then
                    'NUITS
                    'NUITS DOIT ETRE SPECFIQUE AU TYPE DE SEJOUR

                    Dim n As Integer = elite.nombreDeNuiteeOuSejour(TYPE_CHAMBRE, CODE_ELITE, CODE_CLIENT, 1)

                    Dim NOMBRE_NUITEE_EGALE_A_UNE_NUITEE As Integer = eliteBonus.Rows(0)("NOMBRE_NUITEE_EGALE_A_UNE_NUITEE")
                    GunaTextBoxCritere.Text = n

                    If n >= NOMBRE_NUITEE_EGALE_A_UNE_NUITEE Then
                        GunaTextBoxValeurTotalCritere.Text = Format(VALEUR_DE_LA_NUITEE, "#,##0")
                        GunaButtonEnregistrerReglement.Enabled = True

                    Else
                        GunaTextBoxValeurTotalCritere.Text = 0
                        GunaButtonEnregistrerReglement.Enabled = False
                    End If

                ElseIf GunaComboBoxCritereElite.SelectedIndex = 2 Then
                    'SEJOURS
                    'SEJOURS DOIT ETRE SPECFIQUE AU TYPE DE SEJOUR
                    Dim n As Integer = elite.nombreDeNuiteeOuSejour(TYPE_CHAMBRE, CODE_ELITE, CODE_CLIENT, 2)
                    GunaTextBoxCritere.Text = n

                    GunaTextBoxValeurTotalCritere.Text = Format(VALEUR_DE_LA_NUITEE, "#,##0.0")

                    Dim NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE As Integer = eliteBonus.Rows(0)("NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE")

                    If n >= NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE Then
                        GunaTextBoxValeurTotalCritere.Text = Format(VALEUR_DE_LA_NUITEE, "#,##0")
                        GunaButtonEnregistrerReglement.Enabled = True
                    Else
                        GunaTextBoxValeurTotalCritere.Text = 0
                        GunaButtonEnregistrerReglement.Enabled = False
                    End If



                End If

            Else

                GunaTextBoxCritere.Visible = False
                Label13.Visible = False
                Label14.Visible = False
                GunaTextBoxValeurTotalCritere.Visible = False

                GunaButtonEnregistrerReglement.Enabled = False

            End If

        End If

    End Sub

    Dim DEPOT_GARANTIE_PAR As String = ""

    Private Sub GunaCheckBoxArrhes_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxArrhes.CheckedChanged


        If GlobalVariable.actualLanguageValue = 1 Then
            DEPOT_GARANTIE_PAR = "PAR DEPOT GARANTIE / "
        Else
            DEPOT_GARANTIE_PAR = ""
        End If

        If Not GunaCheckBoxArrhes.Checked Then

            GunaTextBoxMontantDepot.Text = ""
            GunaTextBoxCodeDepot.Text = ""
            GunaTextBoxRefDepot.Text = ""
            DEPOT_GARANTIE_PAR = ""

            Dim SOLDE As Double = 0
            SOLDE = MainWindow.GunaLabelSolde.Text
            If SOLDE <= 0 Then
                GunaTextBoxMontantVerse.Text = Format(SOLDE * -1)
            End If

            GunaComboBoxModereglement.SelectedIndex = -1
            GunaComboBoxModereglement.SelectedIndex = 0

        End If

        If GunaCheckBoxArrhes.Checked Then
            If Not GunaTextBoxReference.Text.Contains(DEPOT_GARANTIE_PAR) Then
                GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & " " & GunaTextBoxReference.Text
            End If
        End If

    End Sub

    Private Sub GunaButtonDepotDeGarantie_Click(sender As Object, e As EventArgs) Handles GunaButtonDepotDeGarantie.Click
        DepotGarantieForm.Show()
        DepotGarantieForm.TopMost = True
    End Sub

    Private Sub GunaTextBox1_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefDepot.TextChanged

        If Not Trim(GunaTextBoxRefDepot.Text).Equals("") Then
            listeDesCautionsArrange()
        Else
            GunaDataGridViewDepot.Visible = False
            GunaCheckBoxArrhes.Visible = False
        End If

    End Sub

    Public Sub listeDesCautionsArrange()

        GunaDataGridViewDepot.Columns.Clear()

        GunaDataGridViewDepot.DataSource = listeDesDepotsSearch(GunaTextBoxRefDepot.Text)

        If GunaDataGridViewDepot.Rows.Count > 0 Then
            GunaDataGridViewDepot.Visible = True
        Else
            GunaDataGridViewDepot.Visible = False
        End If

    End Sub

    Private Function listeDesDepotsSearch(ByVal reference As String) As DataTable

        Dim table As New DataTable()
        Dim table1 As New DataTable()

        Dim query As String = ""
        Dim query1 As String = ""

        query = "SELECT CODE_CAUTION As REFERENCE, NOM_CLIENT As 'CLIENT' FROM caution WHERE caution.TYPE=1 AND CODE_CAUTION LIKE '%" & reference & "%' ORDER BY CODE_CAUTION DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)

        Return table

    End Function

    Private Sub GunaDataGridViewDepot_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewDepot.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewDepot.Rows(e.RowIndex)

            Dim referenceDepot As String = row.Cells("REFERENCE").Value.ToString()

            Dim infoDepot As DataTable = Functions.getElementByCode(referenceDepot, "caution", "CODE_CAUTION")

            Dim solde As Double = 0

            If infoDepot.Rows.Count > 0 Then

                solde = infoDepot.Rows(0)("SOLDE")

                If solde > 0 Then

                    GunaCheckBoxArrhes.Checked = True
                    GunaTextBoxMontantDepot.Text = solde
                    GunaTextBoxMontantVerse.Text = Format(solde, "#,##0")
                    GunaTextBoxCodeDepot.Text = infoDepot.Rows(0)("CODE_CAUTION")
                    GunaTextBoxRefDepot.Text = infoDepot.Rows(0)("NOM_CLIENT")

                    GunaCheckBoxArrhes.Visible = True
                    GunaCheckBoxArrhes.Checked = True

                Else

                    GunaTextBoxMontantVerse.Text = 0
                    GunaTextBoxMontantDepot.Text = ""
                    GunaTextBoxRefDepot.Text = ""
                    GunaTextBoxCodeDepot.Text = ""
                    GunaCheckBoxArrhes.Checked = False

                    GunaCheckBoxArrhes.Visible = False

                    MessageBox.Show("Ce Dépot de Garantie a déjà été utilisé ", "Garantie", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

            GunaDataGridViewDepot.Visible = False

        End If


    End Sub

    Private Sub GunaCheckBoxRemboursement_Click(sender As Object, e As EventArgs)

    End Sub
End Class