Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class ReglementForm

    'Destinée à contenir l'ensemble des fatures du client pour des mis à jours

    'Dim connect As New DataBaseManipulation()

    Dim dt As DataGridView

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

    Private Sub ReglementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'GlobalVariable.typeDeClientAFacturer = "en chambre"
        Dim language As New Languages()

        language.reglement(GlobalVariable.actualLanguageValue)

        encaissementAvantEnregistrementDeReservation = False

        GunaImageButtonFermer.Visible = True
        GunaImageButtonReduce.Visible = True
        GunaImageButtonFermer.BringToFront()
        GunaImageButtonReduce.BringToFront()

        'Si l'on vient du folio il sera d'bord ferme
        If Not Trim(GlobalVariable.ComingFromFolio1FactureType) = "" Then
            FolioForm.Close()
        End If

        GunaTextBoxMontantVerse.Text = 0
        '---------------------------------------- CONTENT OF REGLEMENTFORM COMING FROM THE FRONTDESK ---------------------------------

        'We initialise the content of reglementForm with information coming from the frontdesk: Solde-SistuationClient-Reglement

        '1- OUVERTURE DE LA FENETRE DE REGLEMENT APRES RAPPEL D'UNE RESA
        'If Not GlobalVariable.codeReservationToUpdate = "" And Not GlobalVariable.typeDeClientAFacturer = "comptoir" Then
        If Not GlobalVariable.codeReservationToUpdate = "" Then
            Dim resa As New Reservation()
            GunaLabelBlocNoteARegler.Text = ""
            GlobalVariable.typeDeClientAFacturer = "en chambre"

            'LE NUMERO DE RESA EXISTE DONC ON NE TRAITE PAS LE CLIENT COMPTOIR
            If Not GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                'GunaTextBoxNom.Visible = False

                'GESTION DES ENTREPRISE ASSOCIE A UN CLIENT

                If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then

                    Dim DEPOT_DE_GARANTIE As Double = GlobalVariable.ReservationToUpdate.Rows(0)("DEPOT_DE_GARANTIE")

                    If DEPOT_DE_GARANTIE > 0 Then
                        GunaCheckBoxArrhes.Visible = True
                    Else

                        Dim CODE_RESERVATION_CLIENT As String = GlobalVariable.codeClientToUpdate
                        Dim infoSupDepot As DataTable = resa.infoCautionUtilisableDepot(CODE_RESERVATION_CLIENT)
                        If infoSupDepot.Rows.Count > 0 Then
                            GunaCheckBoxArrhes.Visible = True
                        Else
                            GunaCheckBoxArrhes.Visible = False
                        End If

                    End If

                    If Not Trim(GlobalVariable.ReservationToUpdate.Rows(0)("NOM_ENTREPRISE")) = "" Then

                        'Si la reservation est associe a une entreprise alors le reglement doit etre au nom de l'entreprise
                        Dim CODE_CLIENT As String = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")
                        GunaTextBoxClientAFacturer.Text = GlobalVariable.ReservationToUpdate.Rows(0)("NOM_ENTREPRISE")
                        GunaTextBoxNom.Text = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")

                        Dim infoSupClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")
                        If infoSupClient.Rows.Count > 0 Then
                            GunaTextBoxCodeElite.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_ELITE")
                        End If

                        ComptoireEtEnChambreReglementOuFacturation(GunaTextBoxNom.Text)

                    ElseIf GlobalVariable.ClientToUpdate.Rows.Count > 0 Then

                        GunaTextBoxNom.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_CLIENT")
                        GunaTextBoxClientAFacturer.Text = GlobalVariable.ClientToUpdate.Rows(0)("NOM_PRENOM")
                        GunaTextBoxCodeElite.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_ELITE")
                        ComptoireEtEnChambreReglementOuFacturation(GlobalVariable.codeClientToUpdate)

                    Else

                        'Si le client ou le code client n'existe pas on va le chercher en utilisant le numéro de réservation

                        GlobalVariable.ClientToUpdate = Functions.getElementByCode(GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT"), "client", "NOM_PRENOM")

                        If GlobalVariable.ClientToUpdate.Rows.Count > 0 Then

                            If Not Trim(GlobalVariable.ClientToUpdate.Rows(0)("NOM_ENTREPRISE")) = "" Then
                                GunaTextBoxNom.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_ENTREPRISE")
                                GunaTextBoxClientAFacturer.Text = GlobalVariable.ClientToUpdate.Rows(0)("NOM_ENTREPRISE")
                                GunaTextBoxCodeElite.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_ELITE")
                            Else
                                GunaTextBoxNom.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_CLIENT")
                                GunaTextBoxClientAFacturer.Text = GlobalVariable.ClientToUpdate.Rows(0)("NOM_PRENOM")
                                GunaTextBoxCodeElite.Text = GlobalVariable.ClientToUpdate.Rows(0)("CODE_ELITE")
                            End If

                            'ComptoireEtEnChambreReglementOuFacturation(GlobalVariable.ClientToUpdate.Rows(0)("CODE_CLIENT"))
                            ComptoireEtEnChambreReglementOuFacturation(GunaTextBoxNom.Text)

                        End If

                    End If

                    GunaTextBoxNom.Visible = False

                Else

                    'FACTURATION DES EN CHAMBRES POUR LA BLANCHISSERIE


                End If

            End If


        Else

            '2- OUVERTURE DU REGLEMENT APRES DEMANDE DE REGLEMENT D'UN BLOC NOTE

            If GlobalVariable.typeDeClientAFacturer = "comptoir" And Not Trim(GlobalVariable.blocNoteARegler) = "" Then

                ' ---------------------- CLIENT COMPTOIRE -------------------------------

                'LIGNE DE LA FACTURE A REGLER
                dt = BarRestaurantForm.GunaDataGridViewLigneFacture

                Dim ClientDevantRegler As DataTable = Functions.getElementByCode(GlobalVariable.codeClientDevantRegler, "client", "CODE_CLIENT")

                If ClientDevantRegler.Rows.Count > 0 Then

                    GunaLabelBlocNoteARegler.Visible = True
                    GunaLabelBlocNoteARegler.Text = GlobalVariable.blocNoteARegler

                    GunaTextBoxNom.Text = ClientDevantRegler.Rows(0)("CODE_CLIENT")
                    GunaTextBoxClientAFacturer.Text = ClientDevantRegler.Rows(0)("NOM_PRENOM")
                    GunaTextBoxCodeElite.Text = BarRestaurantForm.GunaTextBoxCodeElite.Text
                    GunaTextBoxCodeClientFidele.Text = BarRestaurantForm.GunaTextBoxRefClient.Text

                    ComptoireEtEnChambreReglementOuFacturation(GlobalVariable.codeClientDevantRegler)

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "ENCAISSEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & GunaTextBoxClientAFacturer.Text & "[" & GunaLabelBlocNoteARegler.Text & "]"
                    Else
                        GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "CASH In (" & GunaComboBoxModereglement.SelectedItem & ") FROM " & GunaTextBoxClientAFacturer.Text & "[" & GunaLabelBlocNoteARegler.Text & "]"
                    End If

                Else
                    GunaLabelBlocNoteARegler.Visible = False
                End If

            Else

                '3- OUVERTURE REGLEMENT POUR UN ENCAISSEMENT D'UNE RESERVATION NON ENREGISTREE / ENCAISSEMENT AVANT ENREGISTREMENT DE RESERVATION

                encaissementAvantEnregistrementDeReservation = True

                Dim CODE_CAHMBRE As String = MainWindow.GunaTextBoxNumeroChambre.Text

                Dim infoClient As DataTable = Functions.getElementByCode(MainWindow.GunaTextBoxCodeEntrepriseDuClient.Text, "client", "CODE_CLIENT")

                If Not infoClient.Rows.Count > 0 Then
                    infoClient = Functions.getElementByCode(MainWindow.GunaTextBoxRefClient.Text, "client", "CODE_CLIENT")
                End If

                If infoClient.Rows.Count > 0 Then

                    GunaTextBoxNom.Text = infoClient.Rows(0)("CODE_CLIENT")
                    GunaTextBoxClientAFacturer.Text = infoClient.Rows(0)("NOM_PRENOM")
                    GunaTextBoxCodeElite.Text = infoClient.Rows(0)("CODE_ELITE")
                    Dim solde As Double = 0
                    solde = Double.Parse(Functions.SituationDeReservation(MainWindow.GunaLabelNumReservation.Text))

                    'GunaTextBoxAPayer.Text = Format(solde, "#,##0")

                    If solde > 0 Then
                        GunaCheckBoxRemboursement.Checked = True
                    Else
                        GunaCheckBoxRemboursement.Checked = False
                    End If

                    ComptoireEtEnChambreReglementOuFacturation(GunaTextBoxNom.Text)

                Else
                    GunaTextBoxClientAFacturer.Clear()
                    GunaTextBoxReference.Clear()
                End If

            End If

        End If

        '----------------------------------------END  CONTENT OF REGLEMENTFORM COMING FROM THE FRONTDESK ---------------------------------

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

        If Not GlobalVariable.cardPaiement = 0 Then
            GunaTextBoxMontantVerse.Text = Format(GlobalVariable.cardPaiement, "#,##0")
        End If

        'Ensemble des règlements

        SituationDeCaisseJournaliere()

        indicateurDEtatDeCaisse()

        If Trim(GunaTextBoxNom.Text).Equals("") Then
            GunaButtonEnregistrerReglement.Enabled = False
            GunaTextBoxReference.Clear()
        Else
            GunaButtonEnregistrerReglement.Enabled = True
        End If

        If GunaCheckBoxRemboursement.Checked Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrerReglement.Text = "Rembourser"
            Else
                GunaButtonEnregistrerReglement.Text = "Refund"
            End If
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrerReglement.Text = "Encaisser"
            Else
                GunaButtonEnregistrerReglement.Text = "Cash In"
            End If
        End If

        GunaTextBoxNom.Visible = False

        Label14.Text = GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

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

    'Autocompletion using live search trick (Custom AutoCompletion) ----------------------- CUSTOM AUTOCOMPLETION ----------------------
    Private Sub GunaTextBoxNom_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNom.TextChanged, GunaTextBoxNumFacture.TextChanged, GunaTextBoxCodeDepot.TextChanged, GunaTextBoxMontantDepot.TextChanged

        GunaDataGridView2.Visible = True

        Dim query As String = "Select NOM_PRENOM, facture.CODE_CLIENT, EMAIL, CODE_FACTURE FROM client INNER JOIN facture WHERE facture.CODE_CLIENT = client.CODE_CLIENT And NOM_PRENOM Like '%" & GunaTextBoxNom.Text & "%' AND ETAT_FACTURE = 0"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridView2.DataSource = table
        Else
            GunaDataGridView2.Columns.Clear()
            GunaDataGridView2.Visible = False
        End If

        If GunaTextBoxNom.Text = "" Then
            GunaDataGridView2.Visible = False
        End If

        'connect.closeConnection()

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
    Private Sub ComptoireEtEnChambreReglementOuFacturation(ByVal CODE_CLIENT As String)

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------

        If Not GlobalVariable.codeReservationToUpdate = "" Then

            'En caissement pour client en chambre

            Dim CodeClient As String = GlobalVariable.codeClientToUpdate

            If Not GlobalVariable.codeClientToUpdate = "" Then
                CodeClient = GlobalVariable.codeClientToUpdate
            Else

                If Functions.getElementByCode(GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT"), "client", "NOM_PRENOM").Rows.Count > 0 Then
                    CodeClient = Functions.getElementByCode(GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT"), "client", "NOM_PRENOM").Rows(0)("CODE_CLIENT")
                Else

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Aucun client associé à cette Réservation !!", "Situation Réservation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("No client associated to the reservation !!", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If
                End If

            End If

            'On selectionne l'ensemble des factures du client payés ou pas
            'Dim query2 As String = "SELECT facture.CODE_FACTURE, ligne_facture.CODE_MODE_PAIEMENT,facture.DATE_FACTURE, ligne_facture.LIBELLE_FACTURE, QUANTITE, facture.MONTANT_TTC FROM ligne_facture INNER JOIN facture WHERE ligne_facture.CODE_FACTURE = facture.CODE_FACTURE AND facture.CODE_CLIENT = @CODE_CLIENT AND facture.CODE_RESERVATION = @CODE_RESERVATION AND facture.ETAT_FACTURE = 0 ORDER BY DATE_FACTURE DESC"
            Dim query2 As String = "SELECT CODE_FACTURE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC, CODE_ARTICLE, ID_LIGNE_FACTURE FROM ligne_facture WHERE CODE_RESERVATION = @CODE_RESERVATION AND ETAT_FACTURE = 0 ORDER BY DATE_FACTURE DESC"
            Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
            command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CodeClient
            command2.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GlobalVariable.codeReservationToUpdate

            Dim adapter2 As New MySqlDataAdapter(command2)
            Dim tableFacture As New DataTable()

            adapter2.Fill(tableFacture)

            'SI LA RESERVATION EST RATTACHE A UNE ENTREPRISE ALORS LE CODE_ENTREPRISE EST UTILISE COMME CODE CLIENT
            If Not Trim(GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")).Equals("") Then
                CodeClient = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")
            End If

            'On selectionne l'ensemble des reglement du client n'incluant pas les remboursements
            'Dim query3 As String = "SELECT REF_REGLEMENT,MODE_REGLEMENT ,NUM_REGLEMENT,MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT), ID_REGLEMENT FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND CODE_RESERVATION =@CODE_RESERVATION AND IMPRIMER = 0 ORDER BY DATE_REGLEMENT DESC"
            Dim query3 As String = "SELECT REF_REGLEMENT,MODE_REGLEMENT ,NUM_REGLEMENT,MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT), ID_REGLEMENT FROM reglement WHERE CODE_RESERVATION =@CODE_RESERVATION AND IMPRIMER = 0 ORDER BY DATE_REGLEMENT DESC"

            Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
            command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CodeClient
            command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = GlobalVariable.codeReservationToUpdate

            Dim adapter3 As New MySqlDataAdapter(command3)
            Dim tableReglement As New DataTable()

            adapter3.Fill(tableReglement)

            Dim tailleDuTableau As Integer = tableReglement.Rows.Count + tableFacture.Rows.Count

            'On crée une structure de tableau
            Dim toutesLesFactures(tailleDuTableau) As SituationClient

            Dim niemElementDutableau As Integer = 0

            Dim totalFacture As Double = 0
            Dim totalReglement As Double = 0

            'Insertion des reglements dans notre structure
            For i = 0 To tableReglement.Rows.Count - 1

                toutesLesFactures(i).Id = tableReglement.Rows(i)("ID_REGLEMENT")
                toutesLesFactures(i).dateOperation = tableReglement.Rows(i)("DATE_REGLEMENT")
                toutesLesFactures(i).Debit = 0
                toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
                toutesLesFactures(i).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")
                toutesLesFactures(i).Article = ""
                toutesLesFactures(i).Code = tableReglement.Rows(i)("NUM_REGLEMENT")

                totalReglement = totalReglement + tableReglement.Rows(i)("MONTANT_VERSE")
                niemElementDutableau = i

            Next

            niemElementDutableau += 1

            'Puis dans notre structure on ajoute les factures a la suite des reglements
            For i = 0 To tableFacture.Rows.Count - 1

                toutesLesFactures(niemElementDutableau).dateOperation = tableFacture.Rows(i)("DATE_FACTURE")
                toutesLesFactures(niemElementDutableau).Debit = tableFacture.Rows(i)("MONTANT_TTC")
                toutesLesFactures(niemElementDutableau).Credit = 0
                toutesLesFactures(niemElementDutableau).libelleOperation = tableFacture.Rows(i)("LIBELLE_FACTURE")
                toutesLesFactures(niemElementDutableau).Article = tableFacture.Rows(i)("CODE_ARTICLE")
                toutesLesFactures(niemElementDutableau).Code = tableFacture.Rows(i)("CODE_FACTURE")
                toutesLesFactures(niemElementDutableau).Id = tableFacture.Rows(i)("ID_LIGNE_FACTURE")

                totalFacture = totalFacture + tableFacture.Rows(i)("MONTANT_TTC")
                niemElementDutableau += 1


            Next

            'Enfin on insere le tout dans notre datagrid
            If (toutesLesFactures.Length > 0) Then

                For i = 0 To toutesLesFactures.Length - 1

                    If Not toutesLesFactures(i).libelleOperation = "" Then
                        GunaDataGridViewLigneFactureReglement.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0.00"), Format(toutesLesFactures(i).Credit, "#,##0.00"), toutesLesFactures(i).Article, toutesLesFactures(i).Code, toutesLesFactures(i).Id)
                    End If

                Next

                GunaDataGridViewLigneFactureReglement.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

                'Sorting the elements of situation client
                'GunaDataGridViewLigneFactureReglement.DataSource.Sort(GunaDataGridViewLigneFactureReglement.DataSource.Columns(0), ListSortDirection.Descending)

            End If

            Dim montantAPayer As Double = 0

            GunaCheckBoxRemboursement.Visible = True

            'We affect values to the textbox below the datagrid
            GunaTextBoxAPayer.Text = Format(totalFacture - totalReglement, "#,##0")
            Dim solde As Double = 0

            Double.TryParse(GunaTextBoxAPayer.Text, solde)
            Dim soldeAregler = solde
            GunaTextBoxSolde.Text = GunaTextBoxAPayer.Text
            'Solde = Debit - credit

            If soldeAregler >= 0 Then '

                GunaCheckBoxRemboursement.Checked = False

                If GlobalVariable.actualLanguageValue = 1 Then
                    LabelMontantAPayer.Text = "Montant à Payer"
                    LabelSolde.Text = "Solde à payer"

                    GunaTextBoxMontantVerse.Text = 0

                    GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "ENCAISEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & GunaTextBoxClientAFacturer.Text & " " & Date.Now()
                Else
                    LabelMontantAPayer.Text = "Amount to Pay"
                    LabelSolde.Text = "Balance to Pay"

                    GunaTextBoxMontantVerse.Text = 0

                    GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "CASH IN (" & GunaComboBoxModereglement.SelectedItem & ") FROM " & GunaTextBoxClientAFacturer.Text & " " & Date.Now()
                End If
                'we enable the button as we can pay
                'GunaButtonEnregistrerReglement.Enabled = True

            Else

                GunaCheckBoxRemboursement.Checked = True

                ' means we dont have some thing to pay solde a regler is nothing also

                If GlobalVariable.actualLanguageValue = 1 Then
                    LabelMontantAPayer.Text = "Montant à rembourser"
                    LabelSolde.Text = "Solde à rembourser"
                    GunaTextBoxAPayer.Text = Format(Double.Parse(GunaTextBoxAPayer.Text) * -1, "#,##0")
                    GunaTextBoxMontantVerse.Text = 0
                    GunaTextBoxReference.Text = "REBOURSEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & GunaTextBoxClientAFacturer.Text & " " & GlobalVariable.DateDeTravail

                Else
                    LabelMontantAPayer.Text = "Amount to Refund"
                    LabelSolde.Text = "Balance to Refund"
                    GunaTextBoxAPayer.Text = Format(Double.Parse(GunaTextBoxAPayer.Text) * -1, "#,##0")
                    GunaTextBoxMontantVerse.Text = 0
                    GunaTextBoxReference.Text = "REFUND (" & GunaComboBoxModereglement.SelectedItem & ") OF " & GunaTextBoxClientAFacturer.Text & " " & GlobalVariable.DateDeTravail

                End If

                'We desactivate the button that permit to save as there is nothing to pay
                'GunaButtonEnregistrerReglement.Enabled = False

            End If

            GunaTextBoxSolde.Enabled = False
            GunaTextBoxAPayer.Enabled = False

        ElseIf GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            'Règlement des factures POUR CLIENT COMPTOIRE ------------------------------------------------

            'On ne règle pas le contenus des commandes simplement mais l'ensemble des commandes en relation avec un client
            Dim ListeDesFacturesDuBlocNote As DataTable = Functions.GetAllElementsOnCondition(Trim(GlobalVariable.blocNoteARegler), "ligne_facture", "NUMERO_BLOC_NOTE")

            If ListeDesFacturesDuBlocNote.Rows.Count > 0 Then

                Dim tailleDuTableau As Integer = ListeDesFacturesDuBlocNote.Rows.Count
                'On crée une structure de tableau
                Dim toutesLesFactures(tailleDuTableau) As SituationClient

                Dim totalFacture As Double = 0
                Dim totalReglement As Double = 0

                'Puis dans notre structure on ajoute les factures
                For i = 0 To tailleDuTableau - 1

                    toutesLesFactures(i).dateOperation = ListeDesFacturesDuBlocNote.Rows(i)("DATE_FACTURE")
                    toutesLesFactures(i).Debit = ListeDesFacturesDuBlocNote.Rows(i)("MONTANT_TTC")
                    toutesLesFactures(i).Credit = 0
                    toutesLesFactures(i).libelleOperation = ListeDesFacturesDuBlocNote.Rows(i)("LIBELLE_FACTURE")
                    toutesLesFactures(i).Article = ListeDesFacturesDuBlocNote.Rows(i)("CODE_ARTICLE")
                    toutesLesFactures(i).Code = ListeDesFacturesDuBlocNote.Rows(i)("CODE_FACTURE")
                    toutesLesFactures(i).Id = ListeDesFacturesDuBlocNote.Rows(i)("ID_LIGNE_FACTURE")

                    totalFacture = totalFacture + ListeDesFacturesDuBlocNote.Rows(i)("MONTANT_TTC")

                Next

                GunaTextBoxAPayer.Text = Format(totalFacture, "#,##0")
                GunaTextBoxSolde.Text = Format(totalFacture, "#,##0")

                'Enfin on insere le tout dans notre datagrid
                If (toutesLesFactures.Length > 0) Then

                    For i = 0 To toutesLesFactures.Length - 1

                        If Not toutesLesFactures(i).libelleOperation = "" Then
                            GunaDataGridViewLigneFactureReglement.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0.00"), Format(toutesLesFactures(i).Credit, "#,##0.00"), toutesLesFactures(i).Article, toutesLesFactures(i).Code, toutesLesFactures(i).Id)
                        End If

                    Next

                    'Sorting the elements of situation client
                    'GunaDataGridView1.DataSource.Sort(GunaDataGridView1.DataSource.Columns(-1), ListSortDirection.Descending)

                End If

                'GunaTextBoxSolde.Text = Format(totalReglement - totalFacture, "#,##0")

                FacturationForm.AutoLoadOfBlocNote()

                'connect.closeConnection()

            End If

        ElseIf encaissementAvantEnregistrementDeReservation Then

            'NOUVELLE ENCAISSEMENT DES RESERVATION DES NON ENREGISTREE

            'En caissement pour client en chambre

            Dim CodeClient As String = GunaTextBoxNom.Text

            Dim query3 As String = "SELECT REF_REGLEMENT,MODE_REGLEMENT ,NUM_REGLEMENT,MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, ID_REGLEMENT FROM reglement WHERE CODE_RESERVATION =@CODE_RESERVATION AND IMPRIMER = 0 ORDER BY DATE_REGLEMENT DESC"

            Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
            command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CodeClient
            command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = MainWindow.GunaLabelNumReservation.Text

            Dim adapter3 As New MySqlDataAdapter(command3)
            Dim tableReglement As New DataTable()

            adapter3.Fill(tableReglement)

            Dim tailleDuTableau As Integer = tableReglement.Rows.Count

            'On crée une structure de tableau
            Dim toutesLesFactures(tailleDuTableau) As SituationClient

            Dim niemElementDutableau As Integer = 0

            Dim totalFacture As Double = 0
            Dim totalReglement As Double = 0

            'Insertion des reglements dans notre structure
            For i = 0 To tableReglement.Rows.Count - 1

                toutesLesFactures(i).Id = tableReglement.Rows(i)("ID_REGLEMENT")
                toutesLesFactures(i).dateOperation = tableReglement.Rows(i)("DATE_REGLEMENT")
                toutesLesFactures(i).Debit = 0
                toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
                toutesLesFactures(i).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")
                toutesLesFactures(i).Article = ""
                toutesLesFactures(i).Code = tableReglement.Rows(i)("NUM_REGLEMENT")

                totalReglement += tableReglement.Rows(i)("MONTANT_VERSE")

            Next

            'Enfin on insere le tout dans notre datagrid
            If (toutesLesFactures.Length > 0) Then

                For i = 0 To toutesLesFactures.Length - 1

                    If Not toutesLesFactures(i).libelleOperation = "" Then
                        GunaDataGridViewLigneFactureReglement.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0.00"), Format(toutesLesFactures(i).Credit, "#,##0.00"), toutesLesFactures(i).Article, toutesLesFactures(i).Code, toutesLesFactures(i).Id)
                    End If

                Next

                GunaDataGridViewLigneFactureReglement.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

                'Sorting the elements of situation client
                'GunaDataGridViewLigneFactureReglement.DataSource.Sort(GunaDataGridViewLigneFactureReglement.DataSource.Columns(0), ListSortDirection.Descending)

            End If

            Dim montantAPayer As Double = 0

            GunaCheckBoxRemboursement.Visible = True

            'We affect values to the textbox below the datagrid
            GunaTextBoxAPayer.Text = Format(totalFacture - totalReglement, "#,##0")
            Dim solde As Double = 0

            Double.TryParse(GunaTextBoxAPayer.Text, solde)
            Dim soldeAregler = solde
            GunaTextBoxSolde.Text = GunaTextBoxAPayer.Text
            'Solde = Debit - credit

            If soldeAregler >= 0 Then '

                GunaCheckBoxRemboursement.Checked = False

                If GlobalVariable.actualLanguageValue = 1 Then
                    LabelMontantAPayer.Text = "Montant à payer"
                    LabelSolde.Text = "Solde à payer"

                    GunaTextBoxMontantVerse.Text = 0

                    GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "ENCAISEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & GunaTextBoxClientAFacturer.Text & " " & Date.Now()

                Else

                    LabelMontantAPayer.Text = "Amount to Pay"
                    LabelSolde.Text = "Balance to Pay"

                    GunaTextBoxMontantVerse.Text = 0

                    GunaTextBoxReference.Text = DEPOT_GARANTIE_PAR & "CASH IN (" & GunaComboBoxModereglement.SelectedItem & ") FROM " & GunaTextBoxClientAFacturer.Text & " " & Date.Now()

                End If



            Else

                GunaCheckBoxRemboursement.Checked = True

                ' means we dont have some thing to pay solde a regler is nothing also

                If GlobalVariable.actualLanguageValue = 1 Then
                    LabelMontantAPayer.Text = "Montant à rembourser"
                    LabelSolde.Text = "Solde à rembourser"
                    GunaTextBoxAPayer.Text = Format(Double.Parse(GunaTextBoxAPayer.Text) * -1, "#,##0")
                    GunaTextBoxMontantVerse.Text = 0

                    GunaTextBoxReference.Text = "REBOURSEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & GunaTextBoxClientAFacturer.Text & " " & GlobalVariable.DateDeTravail

                Else
                    LabelMontantAPayer.Text = "Amount to Refund"
                    LabelSolde.Text = "Balance to Refund"
                    GunaTextBoxAPayer.Text = Format(Double.Parse(GunaTextBoxAPayer.Text) * -1, "#,##0")
                    GunaTextBoxMontantVerse.Text = 0

                    GunaTextBoxReference.Text = "REFUND (" & GunaComboBoxModereglement.SelectedItem & ") OF " & GunaTextBoxClientAFacturer.Text & " " & GlobalVariable.DateDeTravail

                End If


                'We desactivate the button that permit to save as there is nothing to pay
                'GunaButtonEnregistrerReglement.Enabled = False

            End If

            GunaTextBoxSolde.Enabled = False
            GunaTextBoxAPayer.Enabled = False

        End If

    End Sub

    'When we double click on a cell of our custom datagrid (client d) used for autocompletion
    Private Sub GunaDataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridView2.CellDoubleClick

        GunaDataGridView2.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridView2.Rows(e.RowIndex)

            Dim CodeClient As String = row.Cells("CODE_CLIENT").Value.ToString
            GunaTextBoxNom.Text = CodeClient
            Dim client As DataTable = Functions.getElementByCode(CodeClient, "client", "CODE_CLIENT")
            GunaTextBoxClientAFacturer.Text = client.Rows(0)("NOM_PRENOM")

            'We take all the invoice of the current user for reglement and insert the values of the field of RegelementForm
            ComptoireEtEnChambreReglementOuFacturation(CodeClient)

        End If

    End Sub

    'On recalcul le solde lorsque le montant versé varie
    Private Sub GunaTextBoxMontantVerse_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantVerse.TextChanged

        Dim APayer As Double = 0
        Dim montantVerse As Double = 0
        Dim solde As Double = 0

        Double.TryParse(GunaTextBoxAPayer.Text, APayer)
        Double.TryParse(GunaTextBoxMontantVerse.Text, montantVerse)

        If Not APayer = 0 Then
            GunaTextBoxSolde.Text = APayer - montantVerse

            If Not GunaButtonEnregistrerReglement.Enabled Then

                If Trim(GunaTextBoxClientAFacturer.Text).Equals("") Then
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
                    If Trim(GunaTextBoxClientAFacturer.Text).Equals("") Then
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
    'We save the reglement form information
    Private Sub GunaButtonEnregistrerClient_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerReglement.Click

        'ETAT_BLOC_NOTE = 0 : COMPTOIR
        'ETAT_BLOC_NOTE = 1 : EN CHAMBRE
        'ETAT_BLOC_NOTE = 2 : GRATUITEE
        'ETAT_BLOC_NOTE = 3 : COMPTE

        Dim CODE_CAUTION As String = GunaTextBoxCodeDepot.Text
        Dim DEPOT_DE_GARANTIE As Double = 0
        Dim DEPOT_DE_GARANTIE_VERIF As Double = 0

        Dim encaisserAvecSansLeDepotDeGarantie As Boolean = True

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

            If Trim(GunaTextBoxClientAFacturer.Text).Equals("") Then

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

                If GunaCheckBoxRemboursement.Checked Then

                    'ON AVISE L'UTILISATEUR QU'IL EST ENTRAIN DE FAIRE UN REMBOURSEMENT
                    Dim dialog1 As DialogResult

                    If GlobalVariable.actualLanguageValue = 1 Then
                        dialog1 = MessageBox.Show("Voulez-vous effectuer un remboursement de " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & "Si non veuillez décocher le bouton remboursement", "Remboursement", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        dialogTitle = "Encaissement"

                    Else
                        dialog1 = MessageBox.Show("Do you want to refund an amount of " & Format(Double.Parse(GunaTextBoxMontantVerse.Text), "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & Chr(13) & "If no please check off the refund button", "Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        dialogTitle = "Cash In"
                    End If

                    If dialog1 = DialogResult.No Then
                        continuer = False
                    End If

                Else

                    'ON AVISE L'UTILISATEUR QU'IL N'EST ENTRAIN DE FAIRE UN REMBOURSEMENT
                    Dim dialog1 As DialogResult
                    dialog1 = MessageBox.Show(messageText, dialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If dialog1 = DialogResult.No Then
                        continuer = False
                    End If

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

                                If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                                    If Not TOTAL_FACTURE = (TOTAL_REGLEMENT + MONTANT_DEJA_REGLE) Then

                                        blocNoteTermine = False
                                        fermer = False

                                    End If

                                End If

                                '-------------------------------------------------------------------------------

                                Dim MODE_REG_INFO_SUP_1 As String = ""
                                Dim MODE_REG_INFO_SUP_2 As String = ""
                                Dim MODE_REG_INFO_SUP_3 As Date = GlobalVariable.DateDeTravail.ToShortDateString

                                '1- ******************** MODE DE REGLREMENT TRANSFERT VERS LA CHAMBRE (7) : TRANSFERT DE CHARGE VERS LES EN CHAMBRES

                                If GunaComboBoxModereglement.SelectedIndex = 7 Then

                                    '1- A PARTIR DU BAR RETSURANT - CLIENT COMPTOIR
                                    'APPEL DEPUIS LE BAR RESTAURANT GESTION DES BLOC NOTES

                                    If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                                        If GunaComboBoxModereglement.SelectedIndex = 7 Then
                                            MODE_REG_INFO_SUP_1 = GunaComboBoxCodeChambre.SelectedValue.ToString
                                            MODE_REG_INFO_SUP_2 = GunaTextBoxNomClient.Text
                                        End If

                                        'Dim ligneFacture As New LigneFacture()

                                        Dim NOM_CLIENT As String = GunaTextBoxNomClient.Text
                                        NUMERO_BLOC_NOTE = GlobalVariable.blocNoteARegler

                                        If GunaDataGridViewLigneFactureReglement.Rows.Count > 0 Then

                                            If blocNoteTermine Then '**

                                                For i = 0 To GunaDataGridViewLigneFactureReglement.Rows.Count - 1

                                                    Dim CODE_ARTICLE As String = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("Article").Value
                                                    Dim ID_LIGNE_FACTURE As Integer = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("Id").Value

                                                    LigneFacture.transfertDeLigneChargeDuComptoireVersEnChambre(CODE_ARTICLE, NUMERO_BLOC_NOTE, CODE_CHAMBRE_, CODE_RESERVATION_, NOM_CLIENT, ID_LIGNE_FACTURE)

                                                Next

                                            End If

                                        End If

                                        Dim reservation As New Reservation()

                                        'On met a jours le solde de la reservation
                                        reservation.updateSoldeReservation(CODE_RESERVATION_, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION_))
                                        Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION_)
                                        'Supression du bloc note ayant ete transfere vers un client enchambre
                                        'Functions.DeleteElementByCode(GlobalVariable.blocNoteARegler, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                                        'ON MET A JOUR LE BLOC NOTE

                                        ETAT_FACTURE_POUR_EN_CHAMBRE = 1
                                        ETAT_BLOC_NOTE = 2
                                        'Dim NUMERO_BLOC_NOTE As String = GunaLabelBlocNoteARegler.Text
                                        'Dim LigneFacture As New LigneFacture()

                                        If blocNoteTermine Then '**

                                            If GlobalVariable.actualLanguageValue = 1 Then
                                                MessageBox.Show("Transfert vers la chambre " & CODE_CHAMBRE_ & " effectué avec succès !!", "Transfert de Charges", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Else
                                                MessageBox.Show("Transfer to the room " & CODE_CHAMBRE_ & " done successfully !!", "Charge transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            End If

                                            GlobalVariable.blocNoteARegler = ""

                                            fermer = True

                                            LigneFacture.UpdateBlocNote(NUMERO_BLOC_NOTE, ETAT_BLOC_NOTE) '007

                                            'Functions.updateOfFields("ligne_facture_bloc_note", "MONTANT_ENCAISSEMENT", TOTAL_REGLEMENT, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 1)

                                        End If

                                    Else
                                        '2- A PARTIR DE LA RECEPTION

                                        If GunaDataGridViewLigneFactureReglement.Rows.Count > 0 Then

                                            Dim montantDuTransfert As Double = 0

                                            For Each row As DataGridViewRow In GunaDataGridViewLigneFactureReglement.SelectedRows
                                                montantDuTransfert += Trim(row.Cells("Debit").Value)
                                            Next

                                            GunaTextBoxMontantATransferer.Text = Format(montantDuTransfert, "#,##0.00")

                                        End If
                                        'APPEL DEPUIS LA RECEPTION GESTION DES EN CHAMBRES

                                        Dim ligne_facture As New LigneFacture()

                                        Dim NEW_CODE_RESERVATION As String = GunaTextBoxCodeReservation.Text
                                        Dim OLD_CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate

                                        For Each row As DataGridViewRow In GunaDataGridViewLigneFactureReglement.SelectedRows

                                            Dim NOM_CLIENT As String = GunaTextBoxNomClient.Text
                                            Dim CODE_ARTICLE As String = row.Cells("Article").Value.ToString
                                            Dim CODE_CHAMBRE As String = GunaTextBoxCodeChambre.Text

                                            'Dim CODE_FACTURE_ARTICLE As String = row.Cells("code").Value.ToString
                                            Dim CODE_FACTURE_ARTICLE As String = row.Cells("codeFacture").Value.ToString
                                            Dim ID_LIGNE_FACTURE As String = row.Cells("Id").Value.ToString

                                            ligne_facture.transfertDeLigneChargeEnChambreVersEnChambre(CODE_ARTICLE, CODE_CHAMBRE, NEW_CODE_RESERVATION, OLD_CODE_RESERVATION, CODE_FACTURE_ARTICLE, NOM_CLIENT, ID_LIGNE_FACTURE)

                                        Next

                                        Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, NEW_CODE_RESERVATION)
                                        Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, OLD_CODE_RESERVATION)

                                        For Each row As DataGridViewRow In GunaDataGridViewLigneFactureReglement.SelectedRows
                                            GunaDataGridViewLigneFactureReglement.Rows.RemoveAt(row.Index)
                                        Next

                                        Dim reservation As New Reservation()

                                        Dim CODE_RESERVATION = GunaTextBoxCodeReservation.Text
                                        Dim CODE_RESERVATION_TO_UPDATE = GlobalVariable.codeReservationToUpdate

                                        'On met a jours le solde de la nouvelle reservation
                                        reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))
                                        Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION)
                                        'On met a jours le solde de l'ancienne reservation
                                        reservation.updateSoldeReservation(CODE_RESERVATION_TO_UPDATE, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION_TO_UPDATE))
                                        Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION_TO_UPDATE)

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            MessageBox.Show("Transfert effectué vers la chambre ( " & GunaTextBoxCodeChambre.Text & " ) avec succès ! ", "Transfert de charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Else
                                            MessageBox.Show("Transfer to the room ( " & GunaTextBoxCodeChambre.Text & " ) done successfully ! ", "Charge transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If

                                        GunaTextBoxSolde.Text = 0

                                        GunaPanelTransfertEnChambre.Visible = False

                                        fermer = True

                                    End If

                                ElseIf GunaComboBoxModereglement.SelectedIndex = 3 Or GunaComboBoxModereglement.SelectedIndex = 8 Then

                                    '1- EN PACKATAGE DES CHARGES POUR LA PRODUCTION D'UNE FACTURE

                                    If typeDeCompte = "entreprise" Then
                                        empackatageDesLignesDeChargesPourFacture()
                                    End If

                                    If typeDeCompte = "individuel" Then

                                        If GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "INDIVIDUEL" Then

                                            empackatageDesLignesDeChargesPourFacture()

                                        ElseIf GunaComboBoxCompteIndividuelOuPaymaster.SelectedItem = "COMPTE" Then

                                            Dim NUMERO_DU_COMPTE As String = GunaTextBoxNumeroCompte.Text

                                            'SI LE NUMERO DE BLOC NOTE N'EST PAS VIDE ALORS ON EST AU COMPTOIR
                                            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
                                                If blocNoteTermine Then '**
                                                    transfertDeComptoirVersComptePaymaster(NUMERO_DU_COMPTE)
                                                End If
                                            Else
                                                transfertEnChambreVersComptePaymaster(NUMERO_DU_COMPTE)
                                            End If

                                        End If

                                    End If

                                    If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                                        ETAT_FACTURE_POUR_COMPTE = 3
                                        ETAT_BLOC_NOTE = 2
                                        NUMERO_BLOC_NOTE = GunaLabelBlocNoteARegler.Text

                                    End If

                                    GunaDataGridViewLigneFactureReglement.Columns.Clear()

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        MessageBox.Show("Transfert effectué vers le compte " & GunaTextBoxNumeroCompte.Text & " (" & GunaTextBoxEntreprise.Text & ")" & " réalisé avec succès ! ", "Transfert de charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Else
                                        MessageBox.Show("Transfer to the account " & GunaTextBoxNumeroCompte.Text & " (" & GunaTextBoxEntreprise.Text & ")" & " done successfully ! ", "Charge transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If

                                    GunaTextBoxReference.Clear()
                                    GunaTextBoxEntreprise.Clear()
                                    GunaTextBoxEntreprise.Clear()

                                    GunaTextBoxAPayer.Text = 0
                                    GunaTextBoxMontantVerse.Text = 0
                                    GunaTextBoxSolde.Text = 0

                                    fermer = True

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

                                        Dim CODE_CLIENT As String = GunaTextBoxNom.Text

                                        'GESTION DES ENCAISSEMENTS
                                        'Insert a line into reglement
                                        Dim reglement As New Reglement()
                                        Dim caisse As New Caisse()

                                        Dim NUM_FACTURE = GunaTextBoxNumFacture.Text

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
                                        Dim CODE_RESERVATION As String = "-"

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
                                        'En cas d'un encaissement
                                        'If Trim(LabelMontantAPayer.Text).Equals("Montant à rembourser") Then

                                        If GunaCheckBoxRemboursement.Checked Then

                                            Dim factureDeRemboursement As New Facture()

                                            Dim CODE_FACTURE As String = Functions.GeneratingRandomCodeWithSpecifications("facture", "")
                                            Dim CODE_COMMANDE As String = ""
                                            Dim NUMERO_TABLE As String = ""
                                            Dim CODE_MODE_PAIEMENT As String = MODE_REGLEMENT
                                            Dim NUM_MOUVEMENT As String = ""
                                            Dim DATE_FACTURE As String = GlobalVariable.DateDeTravail
                                            Dim CODE_COMMERCIAL As String = ""
                                            Dim MONTANT_HT As Double = MONTANT_VERSE
                                            Dim TAXE As Double = 0
                                            Dim MONTANT_TTC As Double = MONTANT_VERSE
                                            Dim AVANCE As Double = 0
                                            Dim RESTE_A_PAYER As Double = 0
                                            Dim DATE_PAIEMENT As Date = GlobalVariable.DateDeTravail
                                            Dim ETAT_FACTURE As String = 0
                                            Dim LIBELLE_FACTURE As String = GunaTextBoxReference.Text
                                            Dim MONTANT_TRANSPORT As Double = 0
                                            Dim MONTANT_REMISE As Double = 0
                                            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                            Dim CODE_UTILISATEUR_ANNULE As String = ""
                                            Dim CODE_UTILISATEUR_VALIDE As String = ""
                                            Dim NOM_CLIENT_FACTURE As String = GunaTextBoxClientAFacturer.Text
                                            Dim MONTANT_AVANCE As Double = 0
                                            Dim TYPE As String = GlobalVariable.typeChambreOuSalle

                                            If True Then
                                                'apres insertion dans la facture on insère dans ligne facture

                                                '---------------------------------------- INSERTION DE REGLEMENT DANS LIGNE FACTURE ---------------------------------
                                                Dim ligneFactureDeremboursement As New LigneFacture()

                                                Dim CODE_MOUVEMENT As String = ""
                                                Dim CODE_CHAMBRE As String = "-"

                                                If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                                                    CODE_CHAMBRE = GlobalVariable.ReservationToUpdate.Rows(0)("CHAMBRE_ID")
                                                Else
                                                    If encaissementAvantEnregistrementDeReservation Then
                                                        CODE_CHAMBRE = MainWindow.GunaTextBoxNumeroChambre.Text
                                                    End If
                                                End If

                                                Dim NUMERO_PIECE As String = GunaTextBoxNom.Text
                                                Dim CODE_ARTICLE As String = ""
                                                Dim CODE_LOT As String = ""
                                                Dim QUANTITE As Double = 1
                                                Dim PRIX_UNITAIRE_TTC As Double = MONTANT_VERSE

                                                Dim HEURE_FACTURE As DateTime = Now().ToShortTimeString()

                                                Dim DATE_OCCUPATION As Date = GlobalVariable.DateDeTravail
                                                Dim HEURE_OCCUPATION As DateTime = Now().ToShortTimeString()

                                                Dim TYPE_LIGNE_FACTURE As String = "Remboursement"
                                                Dim NUMERO_SERIE As String = ""
                                                Dim NUMERO_ORDRE As Integer = 0
                                                Dim DESCRIPTION As String = ""
                                                Dim MONTANT_TAXE As Double = 0
                                                Dim NUMERO_SERIE_DEBUT As String = ""
                                                Dim NUMERO_SERIE_FIN As String = ""
                                                Dim CODE_MAGASIN As String = ""
                                                Dim FUSIONNEE As String = ""

                                                '---------------------------------------- END INSERTION DE REGLEMENT DANS LIGNE FACTURE ---------------------------------
                                                NUM_FACTURE = GunaTextBoxReference.Text
                                                '---------------------------------------- INSERTION DE REGLEMENT DANS REGLEMENT EN DEBIT NEGATIF --------------------
                                                reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE * -1, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                                '--------------------------------------------------------------------------------------------------------------------
                                                Dim FIELD = champEncaissementAMettreAjours(MODE_REGLEMENT)
                                                Dim FIELDVALUE As Double = MONTANT_VERSE
                                                Dim CODE_MAIN_COURANTE_JOURNALIERE As String = GlobalVariable.codeMainCouranteJournaliereToUpdate

                                                Dim TABLE = "main_courante_journaliere"

                                                If GunaCheckBoxRemboursement.Checked Then
                                                    FIELDVALUE *= -1
                                                End If
                                                Dim maincourantes As New MainCourantes()

                                                maincourantes.updateMainCouranteJournaliereModeReglement(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                                            End If

                                            'GRATUITE VERS LES EN CHAMBRES


                                        ElseIf reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3) Then

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

                                                For i = 0 To dt.Rows.Count - 1

                                                    Dim CODE_MOUVEMENT As String = ""
                                                    Dim CODE_CHAMBRE As String = ""

                                                    If Not GlobalVariable.codeReservationToUpdate = "" Then
                                                        CODE_CHAMBRE = GlobalVariable.codeChambre
                                                    End If

                                                    Dim CODE_MODE_PAIEMENT As String = MODE_REGLEMENT
                                                    Dim NUMERO_PIECE As String = GunaTextBoxNom.Text
                                                    Dim CODE_ARTICLE As String = dt.Rows(i).Cells("ARTICLE").Value
                                                    Dim CODE_LOT As String = ""
                                                    Dim MONTANT_HT As Double = 0
                                                    Dim QUANTITE As Double = 0
                                                    Dim MONTANT_TTC As Double = 0
                                                    Dim PRIX_UNITAIRE_TTC As Double = 0
                                                    Dim TYPE_LIGNE_FACTURE As String = "GRATUITE"
                                                    Dim LIBELLE_FACTURE As String = ""

                                                    If GlobalVariable.actualLanguageValue = 1 Then
                                                        MONTANT_HT = dt.Rows(i).Cells("MONTANT HT").Value
                                                        QUANTITE = dt.Rows(i).Cells("QUANTITE").Value
                                                        MONTANT_TTC = dt.Rows(i).Cells("MONTANT TTC").Value
                                                        PRIX_UNITAIRE_TTC = dt.Rows(i).Cells("PU TTC").Value
                                                        LIBELLE_FACTURE = dt.Rows(i).Cells("DESIGNATION").Value & CODE_CHAMBRE_LIBELLE
                                                    Else
                                                        MONTANT_HT = dt.Rows(i).Cells("AMOUNT ET").Value
                                                        QUANTITE = dt.Rows(i).Cells("QUANTITY").Value
                                                        MONTANT_TTC = dt.Rows(i).Cells("AMOUNT IT").Value
                                                        PRIX_UNITAIRE_TTC = dt.Rows(i).Cells("UNIT PRICE").Value
                                                        TYPE_LIGNE_FACTURE = "FREE" '**
                                                        LIBELLE_FACTURE = dt.Rows(i).Cells("ITEM").Value & CODE_CHAMBRE_LIBELLE
                                                    End If

                                                    Dim TAXE As Double = 0

                                                    Dim DATE_FACTURE As Date = GlobalVariable.DateDeTravail
                                                    Dim HEURE_FACTURE As DateTime = Date.Now()
                                                    Dim ETAT_FACTURE As Integer = 0
                                                    Dim DATE_OCCUPATION As Date = GlobalVariable.DateDeTravail
                                                    Dim HEURE_OCCUPATION As DateTime = Date.Now()

                                                    Dim NUMERO_SERIE As String = ""
                                                    Dim NUMERO_ORDRE As Integer = 0
                                                    Dim DESCRIPTION As String = ""
                                                    Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                                    'Dim CODE_AGENCE As String = dt.Rows(i).Cells("CODE_AGENCE").Value
                                                    Dim MONTANT_REMISE As Double = 0
                                                    Dim MONTANT_TAXE As Double = 0
                                                    Dim NUMERO_SERIE_DEBUT As String = ""
                                                    Dim NUMERO_SERIE_FIN As String = ""
                                                    Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                                                    Dim FUSIONNEE As String = ""

                                                    '-------------------------------------------------------------------------------------------------------------

                                                    If GunaLabelBlocNoteARegler.Visible Then
                                                        'Client comptoir
                                                        Dim infoSupArticle As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_ARTICLE, "ligne_facture", "CODE_ARTICLE", NUMERO_BLOC_NOTE, "NUMERO_BLOC_NOTE")

                                                        If infoSupArticle.Rows.Count > 0 Then
                                                            FUSIONNEE = infoSupArticle.Rows(0)("FUSIONNEE")
                                                            NUMERO_SERIE_DEBUT = infoSupArticle.Rows(0)("TYPE_LIGNE_FACTURE")
                                                            TYPE_LIGNE_FACTURE = infoSupArticle.Rows(0)("TYPE_LIGNE_FACTURE")
                                                        End If

                                                    Else
                                                        'Client en chambre
                                                        Dim infoSupArticle As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_ARTICLE, "ligne_facture", "CODE_ARTICLE", CODE_RESERVATION, "CODE_RESERVATION")

                                                        If infoSupArticle.Rows.Count > 0 Then
                                                            FUSIONNEE = infoSupArticle.Rows(0)("FUSIONNEE")
                                                            NUMERO_SERIE_DEBUT = infoSupArticle.Rows(0)("TYPE_LIGNE_FACTURE")
                                                            TYPE_LIGNE_FACTURE = infoSupArticle.Rows(0)("TYPE_LIGNE_FACTURE")
                                                        End If

                                                    End If

                                                    '--------------------------------------------------------------------------------------------------------------
                                                    Dim TYPE As String = ""
                                                    'Dim NUMERO_BLOC_NOTE As String = ligneFactureTempContent.Rows(i)("NUMERO_BLOC_NOTE").Value
                                                    Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")

                                                    ligneDeGratuite.insertLigneFactureGratuite(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, NUMERO_BLOC_NOTE)

                                                Next

                                                Dim ETAT_FACTURE_POUR_GRATUITE As Integer = 2 'ETAT MATERIALISANT LA GRATUITEE
                                                ETAT_BLOC_NOTE = 2

                                                LigneFacture.UpdateEtatLigneFacturePourClientComptoire(NUMERO_BLOC_NOTE, ETAT_FACTURE_POUR_GRATUITE, ETAT_BLOC_NOTE) 'ligne_facture_bloc_note

                                            End If

                                            'We set back montPAyer to 0
                                            GunaTextBoxMontantVerse.Text = 0

                                            If Not GlobalVariable.blocNoteARegler = "" Then

                                                NUMERO_BLOC_NOTE = Trim(GlobalVariable.blocNoteARegler)
                                                ETAT_BLOC_NOTE = 2 'ETAT DE BLOC NOTE PAYE 

                                                If blocNoteTermine Then '**
                                                    facture.UpdateBlocNote(NUMERO_BLOC_NOTE, ETAT_BLOC_NOTE) '007
                                                End If

                                            End If

                                            '-----------------------------------------------------------------------------------------------------------------------------
                                            'MISE A JOURS DU MONTANT A REPORTER DE LA MAIN COURANTE

                                            Dim mainCourantes As New MainCourantes()

                                            Dim mainCouranteInfo As DataTable

                                            Dim TABLE As String = ""
                                            Dim FIELD As String = ""
                                            Dim tableName As String = ""

                                            Dim CODE_MAIN_COURANTE As String = ""

                                            Dim FIELDVALUE As Double = MONTANT_REGLEMENT

                                            If Not GlobalVariable.blocNoteARegler = "" Then

                                                Dim ETAT_MAIN_COURANTE As Integer = 0
                                                Dim DATE_TRAVAIL As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

                                                tableName = "main_courante_autres"

                                                mainCouranteInfo = Functions.getElementByOnCodeAndDate(ETAT_MAIN_COURANTE, tableName, "ETAT_MAIN_COURANTE", DATE_TRAVAIL, tableName)

                                                If mainCouranteInfo.Rows.Count > 0 Then

                                                    CODE_MAIN_COURANTE = mainCouranteInfo.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

                                                    Dim CODE_MAIN_COURANTE_JOURNALIERE As String = mainCouranteInfo.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
                                                    TABLE = "main_courante_autres"
                                                    FIELD = champEncaissementAMettreAjours(modeReglement)

                                                    'If Not GunaComboBoxModereglement.SelectedIndex = 6 Then
                                                    mainCourantes.updateMainCouranteJournaliereModeReglement(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                                                    'End If
                                                    Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                                                    If blocNoteTermine Then '**
                                                        Functions.DeleteElementOnTwoConditions(GlobalVariable.blocNoteARegler, "ligne_facture_temp", "NUMERO_BLOC_NOTE", "CODE_UTILISATEUR_CREA", CODE_UTILISATEUR_CREA)
                                                    End If

                                                End If

                                                If GlobalVariable.actualLanguageValue = 1 Then
                                                    MessageBox.Show("Règlement effectué avec succès **", "Règlement", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                Else
                                                    MessageBox.Show("Cash in successful", "Cash In", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                End If

                                                If indexReglement = 0 Or indexReglement = 1 Or indexReglement = 2 Or indexReglement = 4 Or indexReglement = 5 Or indexReglement = 9 Then
                                                    If GlobalVariable.AgenceActuelle.Rows(0)("CLUB_ELITE") = 1 Then
                                                        pointsDesClientsComptoirs(CODE_CLIENT_FIDELE, MONTANT_REGLEMENT)
                                                    End If
                                                End If

                                            ElseIf Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then

                                                'MISE AJOURS DES MAINS COURANTES POUR PRODUCTION DU DES MAINSCOURANTES

                                                'MAINCOURANTE JOURANLIERE

                                                FIELD = champEncaissementAMettreAjours(modeReglement)

                                                Dim CODE_MAIN_COURANTE_JOURNALIERE As String = GlobalVariable.codeMainCouranteJournaliereToUpdate

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

                                            GunaTextBoxNom.Text = CODE_CLIENT

                                            If Not GlobalVariable.codeClientDevantRegler = "" Then
                                                GunaTextBoxNom.Text = GlobalVariable.codeClientDevantRegler
                                            End If

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
                                    If Not GlobalVariable.codeReservationToUpdate = "" Then

                                        MainWindow.MainWindowManualActivation()

                                        'We aactivate the ReglementForm To refresh the values of the DataGrids in the Folio
                                        Me.Refresh()

                                        'Facturation des en chambres
                                        Dim reservation As New Reservation()
                                        Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate

                                        'MessageBox.Show(Functions.SituationDeReservation(CODE_RESERVATION))
                                        reservation.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", Functions.SituationDeReservation(CODE_RESERVATION))
                                        Functions.miseAJourDuMontantAReporter(GlobalVariable.DateDeTravail, CODE_RESERVATION)

                                        fermer = True

                                    End If

                                    GlobalVariable.cardPaiement = 0

                                    MainWindow.GunaTextBoxPaiement.Text = 0

                                    If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then

                                        'MISE A JOURS DU COMPTE DU CLIENT SI PAS RATTACHE A UNE ENTREPRISE OU LE COMPTE DE L'INDIVIDU

                                        Dim compte As New Compte()
                                        Dim CODE_CLIENT As String = ""

                                        If Not GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE").Equals("") Then
                                            CODE_CLIENT = GlobalVariable.ReservationToUpdate.Rows(0)("CODE_ENTREPRISE")
                                        Else
                                            CODE_CLIENT = GlobalVariable.ReservationToUpdate.Rows(0)("CLIENT_ID")
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

                                        Dim DEPOT_DE_GARANTIE_RESA As Double = GlobalVariable.ReservationToUpdate.Rows(0)("DEPOT_DE_GARANTIE")
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

                                'GESTION DES REGLEMENTS PARTIELS ICI

                                If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                                    If Not blocNoteTermine Then
                                        MONTANT_DEJA_REGLE += MONTANT_REGLEMENT
                                        'GunaTextBoxMontantVerse.Text = Format(MONTANT_TOTAL_A_REGLER - MONTANT_REGLEMENT, "#,##0")
                                        GunaTextBoxMontantVerse.Text = Format(MONTANT_TOTAL_A_REGLER - MONTANT_DEJA_REGLE, "#,##0")
                                    End If

                                    '1- ON MET AJOUR LE MONTANT DU REGLEMENT
                                    LigneFacture.updateMontantEncaissementDansBlocNote(NUMERO_BLOC_NOTE, MONTANT_REGLEMENT)

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

                            If Not GlobalVariable.ReservationToUpdate Is Nothing Then

                                If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then

                                    Dim CODE_RESERVATION As String = GlobalVariable.ReservationToUpdate(0)("CODE_RESERVATION")

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
                            Dim codeReservation As String = ""

                            If Not GlobalVariable.codeReservationToUpdate = "" Then
                                codeReservation = GlobalVariable.codeReservationToUpdate
                            Else
                                codeReservation = "-"
                            End If

                            Functions.DocumentToPrintComptoire(codeDernierReglement, "reglement", "NUM_REGLEMENT", GunaTextBoxNom.Text, dt, codeReservation, GunaTextBoxCodeDepot.Text)

                        End If

                        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

                            If blocNoteTermine Then
                                'RAFRAICHISSEMENT DES BLOC NOTES
                                BarRestaurantForm.GunaTextBoxNomPrenom.Text = ""
                                BarRestaurantForm.manualRefresh()

                                'ON SELECTION PAR DEFAUT UN BLOC NOTES APRES REGLEMENT DES AUTRES BLOCS NOTES

                                If BarRestaurantForm.GunaComboBoxListeDesComandes.Items.Count > 0 Then
                                    BarRestaurantForm.GunaComboBoxListeDesComandes.SelectedIndex = 0
                                    GlobalVariable.blocNoteARegler = BarRestaurantForm.GunaComboBoxListeDesComandes.SelectedValue.ToString
                                Else
                                    BarRestaurantForm.GunaDataGridViewLigneFacture.DataSource = Nothing
                                    GlobalVariable.blocNoteARegler = ""
                                End If

                                If GunaComboBoxModereglement.SelectedIndex = 6 Then
                                    Functions.retranchementDesGratuiteeDeLaMainCourante(NUMERO_BLOC_NOTE)
                                End If

                                Me.Close()

                                Functions.DeleteElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")



                                fermer = False

                                GunaTextBoxNumFacture.Clear()

                            End If

                        Else

                            If Not Trim(GlobalVariable.codeReservationToUpdate) = "" Then
                                Me.Close()
                            End If

                        End If

                    End If

                    '--------------------------------------------------------------------------------------------------------------------------
                    'RAFRAICHISSEMENT DES INFORMATION DE RESERVATION DE LA RECEPTION 

                    If encaissementAvantEnregistrementDeReservation Then 'ENCAISSEMENT POUR UNE RESA NON ENREGISTREE

                        Dim solde As Double = Double.Parse(Functions.SituationDeReservation(MainWindow.GunaLabelNumReservation.Text))
                        MainWindow.GunaLabelSolde.Text = Format(solde, "#,##0")

                        If 0 > solde Then
                            MainWindow.GunaLabelSolde.ForeColor = Color.Red
                        Else
                            MainWindow.GunaLabelSolde.ForeColor = Color.Black
                        End If

                        If MainWindow.GunaRadioButtonChambre.Checked Then

                            If 0 < MainWindow.GunaLabelSolde.Text Then
                                MainWindow.GunaTextBoxMontantARegler.Text = Format(MainWindow.GunaTextBoxTotal.Text - solde, "#,##0")
                            End If

                        End If

                    End If

                    '----------------------------------------------------------------------------------------------------------------------------

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

        'ElseIf typeDeCompte = "individuel" Then

        ' query = "SELECT INTITULE, NUMERO_COMPTE From compte WHERE INTITULE LIKE '%" & GunaTextBoxEntreprise.Text & "%' AND ETAT_DU_COMPTE =@ETAT_DU_COMPTE ORDER BY INTITULE ASC"

        'Dim command As New MySqlCommand(query, GlobalVariable.connect)
        'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE

        'Dim adapter As New MySqlDataAdapter(command)

        'adapter.Fill(table)


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

        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            If True Then

                Dim infoSupBlocNoteEnCour As DataTable = Functions.getElementByCode(GlobalVariable.blocNoteARegler, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If infoSupBlocNoteEnCour.Rows.Count > 0 Then

                    Dim TOTAL_FACTURE As Double = infoSupBlocNoteEnCour.Rows(0)("MONTANT_BLOC_NOTE")
                    Dim TOTAL_REGLEMENT As Double = infoSupBlocNoteEnCour.Rows(0)("MONTANT_ENCAISSEMENT")

                    GunaTextBoxMontantVerse.Text = Format(TOTAL_FACTURE - TOTAL_REGLEMENT, "#,##0")
                    MONTANT_DEJA_REGLE = TOTAL_REGLEMENT

                End If

            End If

        Else
            GunaTextBoxMontantVerse.Text = GunaTextBoxAPayer.Text
        End If

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

        Dim chambre As String = "" 'PRENDRA UNE VALEUR SEULEMENT POUR LES CLIENT EN CHAMBRE

        If Not Trim(GlobalVariable.codeChambreToUpdate) = "" Then
            chambre = "[" & GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT") & " / " & GlobalVariable.codeChambreToUpdate & "]"
        Else

            If encaissementAvantEnregistrementDeReservation Then
                chambre = "[" & GunaTextBoxClientAFacturer.Text & " / " & MainWindow.GunaTextBoxNumeroChambre.Text & "]"
            Else
                chambre = " [" & GunaLabelBlocNoteARegler.Text & "]"
            End If

        End If

        If GunaCheckBoxRemboursement.Checked Then
            'GunaTextBoxReference.Text = "REMBOURSEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & GunaTextBoxClientAFacturer.Text & chambre
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxReference.Text = "REMBOURSEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & chambre
            Else
                GunaTextBoxReference.Text = "REFUND (" & GunaComboBoxModereglement.SelectedItem & ") OF " & chambre
            End If

        Else

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


    Private Sub GunaCheckBoxRemboursement_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxRemboursement.Click

        Dim chambre As String = ""

        If Not Trim(GlobalVariable.codeChambreToUpdate) = "" Then
            chambre = "[" & GlobalVariable.ReservationToUpdate.Rows(0)("NOM_CLIENT") & " / " & GlobalVariable.codeChambreToUpdate & "]"
        Else
            If encaissementAvantEnregistrementDeReservation Then
                chambre = "[" & MainWindow.GunaTextBoxNomPrenom.Text & " / " & MainWindow.GunaTextBoxNumeroChambre.Text & "]"
            Else
                chambre = " [" & GunaLabelBlocNoteARegler.Text & "]"
            End If
        End If

        If GunaCheckBoxRemboursement.Checked Then

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelMontantAPayer.Text = "Montant à rembourser"
                LabelSolde.Text = "Solde à rembourser"
            Else
                LabelMontantAPayer.Text = "Amount to refund"
                LabelSolde.Text = "Balance to refund"
            End If

            If Trim(GunaTextBoxSolde.Text).Equals("") Then
                GunaTextBoxSolde.Text = 0
            End If

            If Trim(GunaTextBoxAPayer.Text).Equals("") Then
                GunaTextBoxAPayer.Text = 0
            End If

            GunaTextBoxSolde.Text = Format(Double.Parse(GunaTextBoxAPayer.Text) * -1, "#,##0")

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxReference.Text = "REMBOURSEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & chambre

            Else
                GunaTextBoxReference.Text = "REFUND (" & GunaComboBoxModereglement.SelectedItem & ") OF " & chambre

            End If
        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaTextBoxReference.Text = "ENCAISSEMENT (" & GunaComboBoxModereglement.SelectedItem & ") DE " & chambre

            Else
                GunaTextBoxReference.Text = "CASH IN (" & GunaComboBoxModereglement.SelectedItem & ") OF " & chambre

            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelMontantAPayer.Text = "Montant à payer"
                LabelSolde.Text = "Solde à payer"

            Else
                LabelMontantAPayer.Text = "Amount to Pay"
                LabelSolde.Text = "Balance to Pay"

            End If

            GunaTextBoxSolde.Text = 0

        End If

        If GunaCheckBoxRemboursement.Checked Then
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrerReglement.Text = "Rembourser"
            Else
                GunaButtonEnregistrerReglement.Text = "Refund"
            End If
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrerReglement.Text = "Encaisser"
            Else
                GunaButtonEnregistrerReglement.Text = "Cash In"
            End If
        End If

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

    Public Sub empackatageDesLignesDeChargesPourFacture()

        '1- ON CREE UNE FACTURE PUIS ON MODIFIE LE CODE FACTURE DES LIGNES DE CHARGES A FIN QUELLE PORTE LE CODE DE LA FACTURE NOUVELLEMENT CREEE

        Dim CODE_CLIENT As String = ""
        Dim NUMERO_COMPTE As String = GunaTextBoxNumeroCompte.Text

        ' SI LE CODE CLIENT EST VIDE ALORS ON TRAITE LES COMPTES PYAMASTER
        If Not Trim(GunaAdvenceButtonCodeClientDuCompte.Text) = "" Then
            CODE_CLIENT = GunaAdvenceButtonCodeClientDuCompte.Text
        Else
            CODE_CLIENT = NUMERO_COMPTE
        End If

        Dim LIBELLE_FACTURE = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            LIBELLE_FACTURE = "TRANSFERT DES CHARGES DE " & GunaTextBoxClientAFacturer.Text & " VERS LE COMPTE " & GunaTextBoxNumeroCompte.Text

        Else
            LIBELLE_FACTURE = "CHARGES OF " & GunaTextBoxClientAFacturer.Text & " TRANSFERED TO THE ACCOUNT " & GunaTextBoxNumeroCompte.Text

        End If

        Dim NOM_CLIENT_FACTURE = GunaTextBoxNom.Text

        Dim NUMERO_BLOC_NOTE As String = GunaLabelBlocNoteARegler.Text

        Dim CODE_RESERVATION As String = "-"

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        If Not GlobalVariable.codeReservationToUpdate = "" Then
            CODE_RESERVATION = GlobalVariable.codeReservationToUpdate
        End If

        Dim facture As New Facture()
        Dim ligneFacture As New LigneFacture()
        Dim reglement As New Reglement()
        Dim compte As New Compte()

        Dim CODE_FACTURE As String = Functions.GeneratingRandomCodeWithSpecifications("facture", "")
        Dim CODE_COMMANDE As String = ""
        Dim NUMERO_TABLE As String = GunaLabelBlocNoteARegler.Text
        Dim CODE_MODE_PAIEMENT As String = GunaComboBoxModereglement.SelectedItem

        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim NUM_MOUVEMENT As String = ""
        Dim DATE_FACTURE As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
        Dim CODE_COMMERCIAL As String = ""
        Dim AVANCE As Double = 0

        Dim RESTE_A_PAYER As Double = 0
        Dim MONTANT_HT As Double = 0
        Dim TAXE As Double = 0
        Dim MONTANT_TTC As Double = 0

        If Not Trim(GunaTextBoxAPayer.Text).Equals("") Then
            RESTE_A_PAYER = Double.Parse(GunaTextBoxAPayer.Text)
            MONTANT_HT = Double.Parse(GunaTextBoxAPayer.Text)
            MONTANT_TTC = Double.Parse(GunaTextBoxAPayer.Text)
        End If


        Dim DATE_PAIEMENT As Date = GlobalVariable.DateDeTravail
        Dim ETAT_FACTURE As Integer = 1



        Dim MONTANT_TRANSPORT As Double = 0
        Dim MONTANT_REMISE As Double = 0
        Dim CODE_UTILISATEUR_ANNULE As String = ""
        Dim CODE_UTILISATEUR_VALIDE As String = ""
        Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")

        Dim MONTANT_AVANCE As Double = 0

        CODE_COMMANDE = NUMERO_COMPTE 'CODE COMMANDE = NUMERO DE COMPTE

        If facture.insertFacture(CODE_FACTURE, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT, TAXE, MONTANT_TTC, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, LIBELLE_FACTURE, MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE, GRIFFE_UTILISATEUR) Then

            'Next
            Dim OLD_CODE_FACTURE As String = ""

            'MISE A JOURS DU CODE_FACTURE DES LIGNES POUR CORRESPONDRE A CELLE DE LA FACTURE

            For i = 0 To GunaDataGridViewLigneFactureReglement.Rows.Count - 1

                'mettre a jour le code_facture et etat_fature des lignes actuels contenu dans l

                OLD_CODE_FACTURE = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("codeFacture").Value.ToString
                Dim CODE_ARTICLE As String = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("Article").Value.ToString

                'POUR UN TRAITEMENT VERITABLE UNIQUE DES LIGNES REPOSER SUR L'ID DE LIGNE_FACTURE
                'Dim ID_LIGNE_FACTURE As Integer = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("Id").Value
                Dim NEW_CODE_FACTURE As String = CODE_FACTURE

                Dim NUM_REGLEMENT As String = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("codeFacture").Value.ToString

                Dim IMPRIMER As Integer = 1

                reglement.updateReglementClotureFolio(NUM_REGLEMENT, NEW_CODE_FACTURE, IMPRIMER, CODE_ARTICLE, CODE_RESERVATION)

                ETAT_FACTURE = 1

                ligneFacture.updateLigneFactureClotureFolio(OLD_CODE_FACTURE, NEW_CODE_FACTURE, ETAT_FACTURE, CODE_ARTICLE, CODE_RESERVATION)

            Next

            '1- ENVOI DES CHARGES DU PERSONNEL VERS UN COMPTE : COMPTOIRE (BLOC NOTE) -> COMPTE

            If GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            End If

            Dim TOTAL_DEBIT As Double = MONTANT_TTC
            Dim TOTAL_CREDIT As Double = 0

            'MISE A JOURS DU COMPTE DU CLIENT N'ETANT PAS FORCEMENT RATTACHE A UN CLIENT => DONC MISE A JOURS DU COMPTE
            compte.updateCompteApresTrasnfert(NUMERO_COMPTE, TOTAL_DEBIT, TOTAL_CREDIT)

            If Not GlobalVariable.codeReservationToUpdate = "" Then

                Dim reservationUpdate As New Reservation()

                Dim updatedSolde As Double = Functions.SituationDeReservation(GlobalVariable.codeReservationToUpdate)

                reservationUpdate.updateSoldeReservation(GlobalVariable.codeReservationToUpdate, "reserve_conf", updatedSolde)

            End If

        End If

    End Sub

    Public Function upDateEtatGeneral(ByVal TABLE As String, ByVal NOM_DU_CHAMP_ETAT As String, ByVal VALEUR_ETAT As Integer, ByVal ID_LIGNE_FACTURE As Integer)

        Dim updateQuery As String = "UPDATE " & TABLE & " SET " & NOM_DU_CHAMP_ETAT & "=@VALEUR_ETAT WHERE ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@VALEUR_ETAT", MySqlDbType.Int64).Value = VALEUR_ETAT
        command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = ID_LIGNE_FACTURE

        command.ExecuteNonQuery()

    End Function

    Public Sub transfertEnChambreVersComptePaymaster(ByVal COMPTE_PAYMASTER As String)

        Dim caissier As New Caisse()
        Dim ligneFacture As New LigneFacture()

        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim COMPTE_GENERAL As String = ""

        Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate
        Dim MONTANT_A_TRANSFERER As Double = 0
        Dim DEBIT As Double = 0
        Dim CREDIT As Double = 0
        Dim infoDuCompte As DataTable = Functions.getElementByCode(COMPTE_PAYMASTER, "compte", "NUMERO_COMPTE")

        If infoDuCompte.Rows.Count > 0 Then

            For Each row As DataGridViewRow In GunaDataGridViewLigneFactureReglement.SelectedRows

            Next

            If Not Trim(CODE_RESERVATION).Equals("") Then

                '----------------------------------------------------------------------------------------------
                Dim CODE_ARTICLE As String = ""
                Dim ID_LIGNE_FACTURE As Integer

                Dim VALEUR_ETAT As Integer = 1

                Dim TABLE As String = "ligne_facture"
                Dim NOM_DU_CHAMP_ETAT_1 As String = "ETAT_FACTURE"
                Dim NOM_DU_CHAMP_ETAT_2 As String = "ETAT"

                For i = 0 To GunaDataGridViewLigneFactureReglement.Rows.Count - 1

                    DEBIT = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("Debit").Value
                    CREDIT = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("Credit").Value

                    CODE_ARTICLE = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("Debit").Value.ToString
                    ID_LIGNE_FACTURE = GunaDataGridViewLigneFactureReglement.Rows(i).Cells("Id").Value

                    Dim SUFFIX_LIBELLE_ARTICLE As String = " VERS COMPTE (" & COMPTE_PAYMASTER & ")" & " "

                    ligneFacture.changementLibelleArticle(CODE_ARTICLE, CODE_RESERVATION, SUFFIX_LIBELLE_ARTICLE, ID_LIGNE_FACTURE)

                    'MISE AJOURS DES ETAT DES LIGNES FACTURES WORKING PERFECTLY
                    'upDateEtatGeneral(TABLE, NOM_DU_CHAMP_ETAT_1, VALEUR_ETAT, ID_LIGNE_FACTURE)

                    'upDateEtatGeneral(TABLE, NOM_DU_CHAMP_ETAT_2, VALEUR_ETAT, ID_LIGNE_FACTURE)

                Next

                MONTANT_A_TRANSFERER = Math.Abs(DEBIT - CREDIT)

                '----------------------------------------------------------------------------------------------

                '------------------ GESTION DU PAYMASTER -----------------------------

                Dim NUMERO_COMPTE As String = ""

                Dim compteCaisse As New Compte()

                Dim TOTAL_DEBIT As Double = 0

                'ON VEUT LE COMPTE GENERAL DE LA CAISSE ACTUEL POUR L'INSTANT NOUS CONSIDERONS QUE : CODE_CAISSE = COMPTE_GENERAL
                Dim infoCompteCaisse As DataTable = Functions.getElementByCode(CODE_CAISSIER, "caisse", "CODE_UTILISATEUR")

                If infoCompteCaisse.Rows.Count > 0 Then
                    NUMERO_COMPTE = infoCompteCaisse.Rows(0)("CODE_CAISSE") 'CODE_CAISSE
                End If

                TOTAL_DEBIT = Double.Parse(MONTANT_A_TRANSFERER)

                'MISE AJOUR DU COMPTE PAYMASTER

                Dim SOLDE_AVANT_MVT As Double = infoDuCompte.Rows(0)("SOLDE_COMPTE")

                'Basculement du montant excedantaire dans un compte paymaster : PM1001
                'compteCaisse.updateCompteAuDebitEtSolde(COMPTE_PAYMASTER, TOTAL_DEBIT)

                'insertion dans mouvements de comptes
                Dim NUM_COMPTE As String = NUMERO_COMPTE 'CODE CAISSIER

                Dim CODE_TIERS As String = CODE_CAISSIER
                Dim TYPE_TIERS As String = CODE_RESERVATION
                Dim DATE_MVT As Date = GlobalVariable.DateDeTravail
                Dim LIBELLE_MVT As String = ""

                If GlobalVariable.actualLanguageValue = 1 Then
                    LIBELLE_MVT = "TRANSFERT DE " & CODE_RESERVATION & " VERS LE COMPTE " & COMPTE_PAYMASTER 'INFORMATION SUR LA LIGNE FACTURE
                Else
                    LIBELLE_MVT = "CHARGES OF " & CODE_RESERVATION & " TRANSFERED ONTO THE ACCOUNT " & COMPTE_PAYMASTER 'INFORMATION SUR LA LIGNE FACTURE
                End If
                'Dim MONTANT_MVT As Double = MONTANT_BLOC_NOTE
                Dim MONTANT_MVT As Double = TOTAL_DEBIT

                Dim TYPE_MVT As String = "Débiteur"
                Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                compteCaisse.insertCompteMovement(NUM_COMPTE, CODE_TIERS, TYPE_TIERS, DATE_MVT, LIBELLE_MVT, MONTANT_MVT, SOLDE_AVANT_MVT, TYPE_MVT, CODE_AGENCE, COMPTE_PAYMASTER, COMPTE_GENERAL)

                '---------------------------------------------------------------------
                empackatageDesLignesDeChargesPourFacture()

            End If

            GunaTextBoxMontantATransferer.Clear()

        Else

            'MessageBox.Show("Le compte " & COMPTE_PAYMASTER & " est inexistant " & Chr(13) & " Bien vouloir le créer pour permettre un transfert !!", "GESTION DE COMPTE", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    Public Sub transfertDeComptoirVersComptePaymaster(ByVal COMPTE_PAYMASTER As String)

        Dim caissier As New Caisse()
        Dim ligneFacture As New LigneFacture()

        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim COMPTE_GENERAL As String = ""

        Dim NUMERO_BLOC_NOTE As String = GunaLabelBlocNoteARegler.Text

        Dim infoDuCompte As DataTable = Functions.getElementByCode(COMPTE_PAYMASTER, "compte", "NUMERO_COMPTE")

        If infoDuCompte.Rows.Count > 0 Then

            If Not Trim(NUMERO_BLOC_NOTE).Equals("") Then

                Dim blocNote As DataTable = Functions.GetAllElementsOnTwoConditions(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE", CODE_CAISSIER, "CODE_CAISSIER")

                Dim totalMontantDuBlocNote As Double = 0

                If blocNote.Rows.Count > 0 Then
                    totalMontantDuBlocNote = Double.Parse(blocNote.Rows(0)("MONTANT_BLOC_NOTE"))
                End If

                Dim ligneBocNote As DataTable = caissier.LigneDunBlocNoteQuelconque(NUMERO_BLOC_NOTE)

                If ligneBocNote.Rows.Count > 0 Then

                    '-----------------------------CHANGEMENT DES LIBELLES------------------------------------------
                    Dim SUFFIX_LIBELLE_ARTICLE As String = ""

                    If GlobalVariable.actualLanguageValue = 1 Then
                        SUFFIX_LIBELLE_ARTICLE = " COMPTOIR VERS COMPTE (" & COMPTE_PAYMASTER & ")" & " "
                    Else
                        SUFFIX_LIBELLE_ARTICLE = " WALK IN ONTO THE ACCOUNT (" & COMPTE_PAYMASTER & ")" & " "
                    End If
                    '-----------------------------------------------------------------------

                    '------------------ GESTION DU PAYMASTER -----------------------------

                    Dim NUMERO_COMPTE As String = ""

                    Dim compteCaisse As New Compte()

                    Dim TOTAL_DEBIT As Double = 0

                    'ON VEUT LE COMPTE GENERAL DE LA CAISSE ACTUEL POUR L'INSTANT NOUS CONSIDERONS QUE : CODE_CAISSE = COMPTE_GENERAL
                    Dim infoCompteCaisse As DataTable = Functions.getElementByCode(CODE_CAISSIER, "caisse", "CODE_UTILISATEUR")

                    If infoCompteCaisse.Rows.Count > 0 Then
                        NUMERO_COMPTE = infoCompteCaisse.Rows(0)("CODE_CAISSE") 'CODE_CAISSE
                    End If

                    'ON RECUPERE LE MONTANT TOTAL DE CHAQUE VENTE AU COMPTOIRE EN RELATION AVEC UN BLOC NOTE
                    TOTAL_DEBIT = Double.Parse(totalMontantDuBlocNote)

                    'MISE AJOUR DU COMPTE PAYMASTER

                    Dim SOLDE_AVANT_MVT As Double = infoDuCompte.Rows(0)("SOLDE_COMPTE")

                    'Basculement du montant excedantaire dans un compte paymaster : PM1001
                    'compteCaisse.updateCompteAuDebitEtSolde(COMPTE_PAYMASTER, TOTAL_DEBIT)

                    Dim MONTANT_BLOC_NOTE As Double = 0

                    Dim CODE_ARTICLE As String = ""
                    Dim ID_LIGNE_FACTURE As Integer

                    For k = 0 To ligneBocNote.Rows.Count - 1

                        ID_LIGNE_FACTURE = ligneBocNote.Rows(k)("ID_LIGNE_FACTURE")

                        CODE_ARTICLE = ligneBocNote.Rows(k)("CODE_ARTICLE")

                        ligneFacture.changementLibelleArticle(CODE_ARTICLE, NUMERO_BLOC_NOTE, SUFFIX_LIBELLE_ARTICLE, ID_LIGNE_FACTURE)

                        '------------------- GESTION DE CHAQUE LIGNE DE BLOC NOTE ------------------------

                        If GlobalVariable.actualLanguageValue = 1 Then
                            MONTANT_BLOC_NOTE += ligneBocNote.Rows(k)("MONTANT TOTAL")
                        Else
                            MONTANT_BLOC_NOTE += ligneBocNote.Rows(k)("TOTAL AMOUNT")
                        End If



                        Dim CODE_BLOC_NOTE As String = NUMERO_BLOC_NOTE
                        Dim ETAT_FACTURE As Integer = 3 ' BLOC NOTE PLUS PRIS EN COMPTE DANS LES VENTES DU JOURS
                        Dim ETAT_BLOC_NOTE As Integer = 2

                        'ETAT_BLOC_NOTE = 0 : NON CLOTURER
                        'ETAT_BLOC_NOTE = 1 : CLOTURER DONC A REGLER
                        'ETAT_BLOC_NOTE = 2 : REGLER

                        'ETAT_FACTURE = 0 : ' BLOC NOTE PRIS EN COMPTE DANS LES VENTES DU JOURS
                        'ETAT_FACTURE = 1 : ' BLOC NOTE PAS PRIS EN COMPTE DANS LES VENTES DU JOURS

                        'On met a jours les lignes des bloc note pour retirer leur montant dans le montant des ventes du jours
                        'ligneFacture.UpdateEtatLigneFacturePourClientComptoire(CODE_BLOC_NOTE, ETAT_FACTURE, ETAT_BLOC_NOTE)

                        '---------------------------------------------------------------------------------

                    Next

                    'insertion dans mouvements de comptes
                    Dim NUM_COMPTE As String = NUMERO_COMPTE 'CODE CAISSIER

                    Dim CODE_TIERS As String = CODE_CAISSIER
                    Dim TYPE_TIERS As String = NUMERO_BLOC_NOTE
                    Dim DATE_MVT As Date = GlobalVariable.DateDeTravail
                    Dim LIBELLE_MVT As String = "" 'INFORMATION SUR LA LIGNE FACTURE

                    If GlobalVariable.actualLanguageValue = 1 Then
                        LIBELLE_MVT = "TRANSFERT DU BLOC NOTE / NUMERO TABLE " & NUMERO_BLOC_NOTE 'INFORMATION SUR LA LIGNE FACTURE

                    Else
                        LIBELLE_MVT = "NOTEPAD TRANSFER / TABLE NUMBER " & NUMERO_BLOC_NOTE 'INFORMATION SUR LA LIGNE FACTURE

                    End If

                    'Dim MONTANT_MVT As Double = MONTANT_BLOC_NOTE
                    Dim MONTANT_MVT As Double = TOTAL_DEBIT

                    Dim TYPE_MVT As String = "Débiteur"
                    Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                    compteCaisse.insertCompteMovement(NUM_COMPTE, CODE_TIERS, TYPE_TIERS, DATE_MVT, LIBELLE_MVT, MONTANT_MVT, SOLDE_AVANT_MVT, TYPE_MVT, CODE_AGENCE, COMPTE_PAYMASTER, COMPTE_GENERAL)

                    '---------------------------------------------------------------------
                    empackatageDesLignesDeChargesPourFacture()

                End If

            End If

            'NETTOYAGE ligne_facture_temp : ON RETIRE CHAQUE BLOC NOTE DANS ligne_facture_temp
            'Functions.DeleteElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")

            GunaTextBoxMontantATransferer.Clear()

        Else

            'MessageBox.Show("Le compte " & COMPTE_PAYMASTER & " est inexistant " & Chr(13) & " Bien vouloir le créer pour permettre un transfert !!", "GESTION DE COMPTE", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

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
            If GlobalVariable.ReservationToUpdate IsNot Nothing Then

                If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                    TYPE_CHAMBRE = GlobalVariable.ReservationToUpdate.Rows(0)("TYPE_CHAMBRE")
                    VALEUR_DE_LA_NUITEE = GlobalVariable.ReservationToUpdate.Rows(0)("MONTANT_ACCORDE")
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
End Class