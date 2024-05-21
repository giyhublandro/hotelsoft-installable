Imports MySql.Data.MySqlClient

Public Class ComparaisonVenteReglement

    Structure SituationCaissier

        'Dim dateOperation
        Dim NUMERO_BLOC_NOTE
        Dim MONTANT
        Dim ETAT_FACTURE

    End Structure

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Dim totalFactureGlob As Double = 0
    Dim totalReglementGlo As Double = 0

    Private Sub ComparaisonVenteReglement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.venteVsReglement(GlobalVariable.actualLanguageValue)

        RemplissageDuFolioDesVentes()

        RemplissageDuFolioDesEncaissement()

        elementDeTransfert(totalFactureGlob, totalReglementGlo)

        GunaButtonTransfertPaymaster.Visible = False

        If Not GunaButtonEquilibrer.Visible And Not GunaButtonAnnuler.Visible Then
            GunaButtonRegulariser.Visible = True
        End If

    End Sub

    Private Sub RemplissageDuFolioDesVentes()

        Dim caisseGest As New Caisse()

        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

        Dim CODE_CAISSIER As String = ""

        If Not Trim(GlobalVariable.gestionDeCaisseAvantCloture) = "" Then
            'Gestion de cloture de caisse avant cloture de la journee (Nouvelle date de travail)
            CODE_CAISSIER = Trim(GlobalVariable.gestionDeCaisseAvantCloture)
        Else
            CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        End If

        'Dim tableFacture As DataTable = caisseGest.MontantTotalDesVentesDuJourDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        'Facture ou bloc note associe a un utilisateur
        'ON RECUPERE LES BLOC NOTES DONT ETAT_FACTURE = 0 : POUR NE PLUS PRENDRE CEUX QUI ONT DEJA ETES CLOTURES
        Dim tableFacture As DataTable = caisseGest.BlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tableFacture.Rows.Count) As SituationCaissier

        Dim totalFacture As Double = 0

        Dim ETAT_FACTURE As Integer

        If tableFacture.Rows.Count > 0 Then

            For j = 0 To tableFacture.Rows.Count - 1

                toutesLesFactures(j).NUMERO_BLOC_NOTE = tableFacture.Rows(j)("NUMERO_BLOC_NOTE")
                toutesLesFactures(j).MONTANT = tableFacture.Rows(j)("MONTANT_BLOC_NOTE")
                toutesLesFactures(j).ETAT_FACTURE = tableFacture.Rows(j)("ETAT_FACTURE")

                'SACHANT QU'IL EXISTE PLUSIEURS BLOC NOTES EN RELATION AVEC DIFFERENT ETAT_FACTURE
                'ON DOIT PRENDRE EN COMPTE UNIQUEMENT L'ETAT CONCERNANT LES CLIENTS COMPTOIR
                'C-A-D LES CLIENTS DONT ON DOIT AVOIR UN REGLEMENT

                ETAT_FACTURE = tableFacture.Rows(j)("ETAT_FACTURE")

                If ETAT_FACTURE = 0 Then
                    totalFacture += tableFacture.Rows(j)("MONTANT_BLOC_NOTE")
                End If

            Next

            totalFactureGlob = totalFacture
            GunaTextBoxTotalVenteComptoire.Text = Format(totalFacture, "#,##0")

        End If

        GunaDataGridViewFolioVente.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaDataGridViewFolioVente.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
            GunaDataGridViewFolioVente.Columns.Add("AMOUNT", "AMOUNT")
        Else
            GunaDataGridViewFolioVente.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
            GunaDataGridViewFolioVente.Columns.Add("MONTANT", "MONTANT")
        End If

        'Enfin on insere le tout dans notre datagrid
        If (toutesLesFactures.Length > 0) Then

            For i = 0 To toutesLesFactures.Length - 1

                ETAT_FACTURE = toutesLesFactures(i).ETAT_FACTURE

                If ETAT_FACTURE = 0 Then
                    GunaDataGridViewFolioVente.Rows.Add(toutesLesFactures(i).NUMERO_BLOC_NOTE, Format(toutesLesFactures(i).MONTANT, "#,##0"))
                End If

            Next

        End If

        'GESTION DES ELEMENTS DE TRANSFERT VERS LE COMPTE PAYMASTER

    End Sub

    Private Sub RemplissageDuFolioDesEncaissement()

        Dim caisseGest As New Caisse()

        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

        Dim CODE_CAISSIER As String = ""

        If Not Trim(GlobalVariable.gestionDeCaisseAvantCloture) = "" Then
            'Gestion de cloture de caisse vant cloture de la journee (Nouvelle date de travail)
            CODE_CAISSIER = Trim(GlobalVariable.gestionDeCaisseAvantCloture)
        Else
            CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        End If

        Dim tableReglement As DataTable = caisseGest.SituationDeCaisseDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        Dim tailleDuTableau As Integer = tableReglement.Rows.Count

        Dim toutesLesReglements(tableReglement.Rows.Count) As SituationCaissier

        Dim totalReglement As Double = 0

        GunaDataGridViewFolioRegelement.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaDataGridViewFolioRegelement.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
            GunaDataGridViewFolioRegelement.Columns.Add("AMOUNT", "AMOUNT")
        Else
            GunaDataGridViewFolioRegelement.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
            GunaDataGridViewFolioRegelement.Columns.Add("MONTANT", "MONTANT")
        End If

        If tableReglement.Rows.Count > 0 Then

            For i = 0 To tableReglement.Rows.Count - 1
                'Nous sommes interesse uniquement par les encaissements associes aux bloc note (client comptoire)
                If Not Trim(tableReglement.Rows(i)("NUMERO_BLOC_NOTE")) = "" Then

                    toutesLesReglements(i).NUMERO_BLOC_NOTE = tableReglement.Rows(i)("NUMERO_BLOC_NOTE")
                    toutesLesReglements(i).MONTANT = tableReglement.Rows(i)("MONTANT_VERSE")

                    'Total encaissement d'un bloc note
                    totalReglement += tableReglement.Rows(i)("MONTANT_VERSE")

                End If

            Next

            totalReglementGlo = totalReglement
            GunaTextBoxTotalPercu.Text = Format(totalReglement, "#,##0")

        End If


        'Enfin on insere le tout dans notre datagrid
        If (toutesLesReglements.Length > 0) And tableReglement.Rows.Count > 0 Then

            For i = 0 To toutesLesReglements.Length - 1
                GunaDataGridViewFolioRegelement.Rows.Add(toutesLesReglements(i).NUMERO_BLOC_NOTE, Format(toutesLesReglements(i).MONTANT, "#,##0"))
            Next

        End If

    End Sub

    Private Sub elementDeTransfert(ByVal totalFacture As Double, ByVal totalReglement As Double)

        If totalFacture - totalReglement = 0 Then

            GunaButtonEquilibrer.Visible = False
            GunaButtonTransfertPaymaster.Visible = False
            GunaLabelLabelTransfert.Visible = False
            GunaTextBoxMontantATransferer.Visible = False
            GunaDataGridViewTransfertPaymaster.Visible = False

        ElseIf totalFacture - totalReglement > 0 Then

            GunaButtonEquilibrer.Visible = True
            GunaButtonTransfertPaymaster.Visible = True
            GunaLabelLabelTransfert.Visible = True
            GunaTextBoxMontantATransferer.Visible = True
            GunaDataGridViewTransfertPaymaster.Visible = True

        End If


    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaDataGridViewFolio1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewFolioVente.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim caissier As New Caisse()

            Dim row As DataGridViewRow

            row = GunaDataGridViewFolioVente.Rows(e.RowIndex)

            Dim NUMERO_BLOC_NOTE As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                NUMERO_BLOC_NOTE = Trim(row.Cells("RECEIPT NUMBER").Value.ToString)
            Else
                NUMERO_BLOC_NOTE = Trim(row.Cells("NUMERO BLOC NOTE").Value.ToString)
            End If

            Dim ligneBocNote As DataTable = caissier.LigneDunBlocNoteQuelconque(NUMERO_BLOC_NOTE)

            If ligneBocNote.Rows.Count > 0 Then

                GunaDataGridViewFolio3.Columns.Clear()

                GunaDataGridViewFolio3.DataSource = ligneBocNote

                GunaDataGridViewFolio3.Columns(2).DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewFolio3.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewFolio3.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Dim totalMontantDuBlocNote As Double = 0

                For i = 0 To GunaDataGridViewFolio3.Rows.Count - 1

                    If GlobalVariable.actualLanguageValue = 0 Then
                        totalMontantDuBlocNote += ligneBocNote.Rows(i)("TOTAL AMOUNT")
                    Else
                        totalMontantDuBlocNote += ligneBocNote.Rows(i)("MONTANT TOTAL")
                    End If

                Next

                GunaTextBoxTotalBlocNote.Text = Format(totalMontantDuBlocNote, "#,##0")

            Else

            End If

        End If

    End Sub

    'Equilibrer Les caisses

    Private Sub CalculDuSoldeDesFoliosApresBasculement()

        'On determine le solde du folio PAYMASTER A CHAQUE BASCULEMENT

        Dim numberOfElemntsToTransfer As Integer = GunaDataGridViewTransfertPaymaster.RowCount
        Dim montantTotalATransferer As Double = 0

        If numberOfElemntsToTransfer >= 0 Then

            Dim MontantPaymaster As Double = 0

            For i = 0 To numberOfElemntsToTransfer - 1

                Double.TryParse(GunaDataGridViewTransfertPaymaster.Rows(i).Cells(1).Value, montantTotalATransferer)
                MontantPaymaster += montantTotalATransferer

            Next

            GunaTextBoxMontantATransferer.Text = Format(MontantPaymaster, "#,##0")

        End If

        'On determine le solde du folio 1 A CHQUE BASCULEMENT
        Dim numberOfElemntsFolio1 As Integer = GunaDataGridViewFolioVente.RowCount
        Dim montantTotalFolio1 As Double = 0

        If numberOfElemntsFolio1 >= 0 Then

            Dim montantTotalVenteFolio1 As Double = 0

            For i = 0 To numberOfElemntsFolio1 - 1

                Double.TryParse(GunaDataGridViewFolioVente.Rows(i).Cells(1).Value, montantTotalFolio1)
                montantTotalVenteFolio1 += montantTotalFolio1

            Next

            GunaTextBoxTotalVenteComptoire.Text = Format(montantTotalVenteFolio1, "#,##0")

        End If

    End Sub

    Private Sub retranchementDesReglementsNegatifs(ByVal dt As DataGridView)

        'MISE AJOURS DE ETAT (REGLEMENT) : POUR NE PLUS PRENDRE EN COMPTE LES REGLEMENTS NEGATIF (GRATUITEES) AFIN DE PERMETTRE LA CLOTURE

        Dim ETAT_FACTURE As Integer = 1 ' BLOC NOTE PLUS PRIS EN COMPTE DANS LES VENTES DU JOURS
        Dim ETAT_BLOC_NOTE As Integer = 2
        Dim MONTANT As Double = 0

        Dim ligneFacture As New LigneFacture()

        Dim NUMERO_BLOC_NOTE As String = ""

        For i = 0 To dt.Rows.Count - 1

            If Trim(dt.Rows(i).Cells(1).Value) = "" Then
                MONTANT = 0
            Else
                MONTANT = dt.Rows(i).Cells(1).Value
            End If

            NUMERO_BLOC_NOTE = dt.Rows(i).Cells(0).Value

            'ON MET A JOURS L'ETAT DE LA FACTURE REGLE ENGRATUITE : POUR QUELLE N'APPARAISSENT PLUS DANS LES COMPTES
            If MONTANT < 0 Then
                ligneFacture.UpdateEtatLigneFacturePourClientComptoire(NUMERO_BLOC_NOTE, ETAT_FACTURE, ETAT_BLOC_NOTE)
            End If

        Next

    End Sub

    Private Sub GunaButtonEquilibre_Click(sender As Object, ByVal e As EventArgs) Handles GunaButtonEquilibrer.Click

        Me.Cursor = Cursors.WaitCursor

        GunaButtonEquilibrer.Visible = False

        GunaButtonAnnuler.Visible = True

        GunaButtonTransfertPaymaster.Visible = True

        Dim blocNoteAConserver(20) As SituationCaissier

        Dim j = 0

        GunaDataGridViewTransfertPaymaster.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaDataGridViewTransfertPaymaster.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
            GunaDataGridViewTransfertPaymaster.Columns.Add("AMOUNT", "AMOUNT")
        Else
            GunaDataGridViewTransfertPaymaster.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
            GunaDataGridViewTransfertPaymaster.Columns.Add("MONTANT", "MONTANT")
        End If

        If GunaDataGridViewFolioVente.Rows.Count > 0 Then

            For i = 0 To GunaDataGridViewFolioVente.Rows.Count - 2

                'Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)

                'MessageBox.Show(GunaDataGridViewFolio1.Rows(i).Cells(0).Value.ToString(), "Oups")
                Dim NUMERO_BLOC_NOTE As String = GunaDataGridViewFolioVente.Rows(i).Cells(0).Value.ToString()

                'Suppression des lignes vides
                If Not Trim(NUMERO_BLOC_NOTE) = "" Then

                    'LES BLOCS NOTES DEJA REGLES SI LE NUMERO DE BLOC NOTE SE TROUVE DANS LA FACTURE ET DANS LE REGLEMENTS IL A ETE REGLE : VOIR LES BLOC NOTES A TRANSFERER EN PAYMASTER
                    Dim bloc_note_regle As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "reglement", "NUMERO_BLOC_NOTE")

                    If bloc_note_regle.Rows.Count > 0 Then

                        blocNoteAConserver(j).NUMERO_BLOC_NOTE = GunaDataGridViewFolioVente.Rows(i).Cells(0).Value
                        blocNoteAConserver(j).MONTANT = GunaDataGridViewFolioVente.Rows(i).Cells(1).Value

                        j += 1
                    Else
                        GunaDataGridViewTransfertPaymaster.Rows.Add(GunaDataGridViewFolioVente.Rows(i).Cells(0).Value, GunaDataGridViewFolioVente.Rows(i).Cells(1).Value)
                    End If

                End If

            Next

            GunaDataGridViewFolioVente.Rows.Clear()

            For k = 0 To j - 1
                GunaDataGridViewFolioVente.Rows.Add(blocNoteAConserver(k).NUMERO_BLOC_NOTE, blocNoteAConserver(k).MONTANT)
            Next

            'RETRACHEMENT DES REGLEMENTS A VALEUR NEGATIVES : POUR PERMETTRE LA CLOTURE
            'retranchementDesReglementsNegatifs(GunaDataGridViewFolio2)

            'Calcul du solde de chaque folio apres basculement
            CalculDuSoldeDesFoliosApresBasculement()

        End If

        Me.Cursor = Cursors.Default

        If GunaDataGridViewTransfertPaymaster.Rows.Count > 0 Then
            GunaButtonTransfertPaymaster.Visible = True
            GunaButtonAnnuler.Visible = True
            GunaButtonRegulariser.Visible = False
        Else
            GunaButtonTransfertPaymaster.Visible = False
            GunaButtonAnnuler.Visible = False
            GunaButtonRegulariser.Visible = True
        End If

    End Sub

    'Annulation de l'equilibre
    Private Sub GunaButtonAnnuler_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnuler.Click

        GunaButtonEquilibrer.Visible = True

        GunaButtonAnnuler.Visible = False

        GunaDataGridViewFolioVente.Rows.Clear()

        GunaDataGridViewFolio3.Columns.Clear()

        GunaTextBoxTotalBlocNote.Clear()

        GunaDataGridViewTransfertPaymaster.Rows.Clear()

        RemplissageDuFolioDesVentes()

        elementDeTransfert(totalFactureGlob, totalReglementGlo)

        GunaTextBoxTotalVenteComptoire.Text = Format(totalFactureGlob, "#,##0")

        GunaButtonTransfertPaymaster.Visible = False

        GunaTextBoxMontantATransferer.Text = 0

    End Sub

    'Visualtion des lignes dun bloc note du folio du paymaster
    Private Sub GunaDataGridViewTransfertPaymaster_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewTransfertPaymaster.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim caissier As New Caisse()

            Dim row As DataGridViewRow

            row = GunaDataGridViewTransfertPaymaster.Rows(e.RowIndex)

            Dim NUMERO_BLOC_NOTE As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                NUMERO_BLOC_NOTE = Trim(row.Cells("NRECEIPT NUMBER").Value.ToString)
            Else
                NUMERO_BLOC_NOTE = Trim(row.Cells("NUMERO BLOC NOTE").Value.ToString)
            End If

            Dim ligneBocNote As DataTable = caissier.LigneDunBlocNoteQuelconque(NUMERO_BLOC_NOTE)

            If ligneBocNote.Rows.Count > 0 Then

                GunaDataGridViewFolio3.Columns.Clear()

                GunaDataGridViewFolio3.DataSource = ligneBocNote

                GunaDataGridViewFolio3.Columns(2).DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewFolio3.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewFolio3.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Dim totalMontantDuBlocNote As Double = 0

                For i = 0 To GunaDataGridViewFolio3.Rows.Count - 1
                    If GlobalVariable.actualLanguageValue = 0 Then
                        totalMontantDuBlocNote += ligneBocNote.Rows(i)("TOTAL AMOUNT")
                    Else
                        totalMontantDuBlocNote += ligneBocNote.Rows(i)("MONTANT TOTAL")
                    End If
                Next

                GunaTextBoxTotalBlocNote.Text = Format(totalMontantDuBlocNote, "#,##0")

                GunaDataGridViewFolio3.Columns(3).Visible = False
                GunaDataGridViewFolio3.Columns(4).Visible = False

            Else

            End If

        End If

    End Sub

    'TransfertVers Le PaysMaster - EQUILIBRER LES CAISSES
    Private Sub GunaButtonTransfertPaymaster_Click(sender As Object, e As EventArgs) Handles GunaButtonTransfertPaymaster.Click

        Me.Cursor = Cursors.WaitCursor

        GunaButtonTransfertPaymaster.Visible = False

        Dim caissier As New Caisse()
        Dim ligneFacture As New LigneFacture()

        'COMPTE POUR EQUILIBRER
        Dim COMPTE_PAYMASTER As String = "PM1001"
        Dim COMPTE_GENERAL As String = ""

        'VERIFIONS QU'IL EXISTE UN COMPTE PAYMASTER

        Dim infoDuCompte As DataTable = Functions.getElementByCode(COMPTE_PAYMASTER, "compte", "NUMERO_COMPTE")

        If infoDuCompte.Rows.Count > 0 Then

            'For i = 0 To GunaDataGridViewTransfertPaymaster.RowCount - 1

            Dim NUMERO_BLOC_NOTE As String = ""

            If GunaDataGridViewTransfertPaymaster.Rows.Count > 0 Then

                For i = 0 To infoDuCompte.Rows.Count - 1

                    If GlobalVariable.actualLanguageValue = 0 Then
                        NUMERO_BLOC_NOTE = Trim(GunaDataGridViewTransfertPaymaster.Rows(i).Cells("RECEIPT NUMBER").Value.ToString)
                    Else
                        NUMERO_BLOC_NOTE = Trim(GunaDataGridViewTransfertPaymaster.Rows(i).Cells("NUMERO BLOC NOTE").Value.ToString)
                    End If

                    If Not Trim(NUMERO_BLOC_NOTE).Equals("") Then

                        Dim ligneBocNote As DataTable = caissier.LigneDunBlocNoteQuelconque(NUMERO_BLOC_NOTE)

                        If ligneBocNote.Rows.Count > 0 Then

                            Dim totalMontantDuBlocNote As Double = 0

                            For j = 0 To GunaDataGridViewFolio3.Rows.Count - 1
                                If GlobalVariable.actualLanguageValue = 0 Then
                                    totalMontantDuBlocNote += ligneBocNote.Rows(i)("TOTAL AMOUNT")
                                Else
                                    totalMontantDuBlocNote += ligneBocNote.Rows(i)("MONTANT TOTAL")
                                End If
                            Next

                            '------------------ GESTION DU PAYMASTER -----------------------------

                            Dim NUMERO_COMPTE As String = ""

                            Dim compteCaisse As New Compte()

                            Dim TOTAL_DEBIT As Double = 0

                            Dim CODE_CLIENT As String = ""

                            If Not Trim(GlobalVariable.gestionDeCaisseAvantCloture) = "" Then
                                'Gestion de cloture de caisse vant cloture de la journee (Nouvelle date de travail)
                                CODE_CLIENT = Trim(GlobalVariable.gestionDeCaisseAvantCloture) 'CODE DU CAISSIER DONT ON VEUT FERMER LA CAISSE OBTENU AU MOMENT DE LA CLOTURE - CONTROLE DE BALANCE DE CAISSE AVANT CLOTURE
                            Else
                                CODE_CLIENT = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                            End If

                            'ON VEUT LE COMPTE GENERAL DE LA CAISSE ACTUEL POUR L'INSTANT NOUS CONSIDERONS QUE : CODE_CAISSE = COMPTE_GENERAL
                            Dim infoCompteCaisse As DataTable = Functions.getElementByCode(CODE_CLIENT, "caisse", "CODE_UTILISATEUR")

                            If infoCompteCaisse.Rows.Count > 0 Then
                                NUMERO_COMPTE = infoCompteCaisse.Rows(0)("CODE_CAISSE")
                            End If

                            'ON RECUPERE LE MONTANT TOTAL DE CHAQUE VENTE AU COMPTOIRE EN RELATION AVEC UN BLOC NOTE

                            If GlobalVariable.actualLanguageValue = 0 Then
                                TOTAL_DEBIT = Double.Parse(GunaDataGridViewTransfertPaymaster.Rows(i).Cells("AMOUNT").Value)
                            Else
                                TOTAL_DEBIT = Double.Parse(GunaDataGridViewTransfertPaymaster.Rows(i).Cells("MONTANT").Value)
                            End If

                            'MISE AJOUR DU COMPTE PAYMASTER
                            Dim compte As DataTable = Functions.getElementByCode(COMPTE_PAYMASTER, "compte", "NUMERO_COMPTE")

                            Dim SOLDE_AVANT_MVT As Double

                            If compte.Rows.Count > 0 Then
                                SOLDE_AVANT_MVT = compte.Rows(0)("SOLDE_COMPTE")
                            End If

                            'Basculement du montant excedantaire dans un compte paymaster : PM1001
                            compteCaisse.updateCompteAuDebitEtSolde(COMPTE_PAYMASTER, TOTAL_DEBIT)

                            Dim MONTANT_BLOC_NOTE As Double = 0

                            For k = 0 To ligneBocNote.Rows.Count - 1

                                '------------------- GESTION DE CHAQUE LIGNE DE BLOC NOTE ------------------------

                                If GlobalVariable.actualLanguageValue = 0 Then
                                    MONTANT_BLOC_NOTE += ligneBocNote.Rows(k)("TOTAL AMOUNT")
                                Else
                                    MONTANT_BLOC_NOTE += ligneBocNote.Rows(k)("MONTANT TOTAL")
                                End If

                                Dim ETAT_FACTURE As Integer = 4 ' BLOC NOTE PLUS PRIS EN COMPTE DANS LES VENTES DU JOURS
                                Dim ETAT_BLOC_NOTE As Integer = 2 ' REGLER

                                'ETAT_BLOC_NOTE = 0 : NON CLOTURER
                                'ETAT_BLOC_NOTE = 1 : CLOTURER DONC A REGLER
                                'ETAT_BLOC_NOTE = 2 : REGLER

                                'ETAT_FACTURE = 0 : ' COMPTOIR
                                'ETAT_FACTURE = 1 : ' EN CHAMBRE
                                'ETAT_FACTURE = 2 : ' 
                                'ETAT_FACTURE = 1 : ' BLOC NOTE PAS PRIS EN COMPTE DANS LES VENTES DU JOURS

                                'On met a jours les lignes des bloc note pour retirer leur montant dans le montant des ventes du jours
                                ligneFacture.UpdateEtatLigneFacturePourClientComptoireApreCloture(NUMERO_BLOC_NOTE, 1)

                                '---------------------------------------------------------------------------------

                            Next

                            'insertion dans mouvements de comptes
                            Dim NUM_COMPTE As String = NUMERO_COMPTE

                            Dim CODE_TIERS As String = CODE_CLIENT 'CAISSIER
                            Dim TYPE_TIERS As String = NUMERO_BLOC_NOTE
                            Dim DATE_MVT As Date = GlobalVariable.DateDeTravail

                            Dim LIBELLE_MVT As String = "" 'INFORMATION SUR LA LIGNE FACTURE
                            Dim TYPE_MVT As String = ""
                            If GlobalVariable.actualLanguageValue = 0 Then
                                LIBELLE_MVT = "TRANSFER OF RECEIPT " & NUMERO_BLOC_NOTE 'INFORMATION SUR LA LIGNE FACTURE
                                TYPE_MVT = "Debtor"
                            Else
                                LIBELLE_MVT = "TRANSFERT DU BLOC NOTE / NUMERO TABLE " & NUMERO_BLOC_NOTE 'INFORMATION SUR LA LIGNE FACTURE
                                TYPE_MVT = "Débiteur"
                            End If

                            'Dim MONTANT_MVT As Double = MONTANT_BLOC_NOTE
                            Dim MONTANT_MVT As Double = TOTAL_DEBIT

                            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                            compteCaisse.insertCompteMovement(NUM_COMPTE, CODE_TIERS, TYPE_TIERS, DATE_MVT, LIBELLE_MVT, MONTANT_MVT, SOLDE_AVANT_MVT, TYPE_MVT, CODE_AGENCE, COMPTE_PAYMASTER, COMPTE_GENERAL)

                            '---------------------------------------------------------------------

                        End If

                    End If

                    'NETTOYAGE ligne_facture_temp : ON RETIRE CHAQUE BLOC NOTE DANS ligne_facture_temp
                    Functions.DeleteElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")

                Next

            End If

            GunaDataGridViewTransfertPaymaster.Rows.Clear()

                GunaTextBoxMontantATransferer.Clear()

            GunaButtonAnnuler.Visible = False

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Successful trasnfered onto the account " & COMPTE_PAYMASTER
                languageTitle = "CASH REGISTER MANAGEMENT"
            Else
                languageMessage = "Transfert vers le compte " & COMPTE_PAYMASTER & " effectué avec succès"
                languageTitle = "GESTION DE CAISSE"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'CETTE FENNETRE A ETE OUVERTE DANS LE CADRE DU CONTROL DE CAISSE AVANT CLOTURE
            If Not Trim(GlobalVariable.gestionDeCaisseAvantCloture) = "" Then

                CaisseOuverteAlaCloture.Close()
                CaisseOuverteAlaCloture.Show()
                CaisseOuverteAlaCloture.TopMost = True

                'C'EST APRES TOUS LE PROCESSUS DE CLOTURE QUE LA VARIABLE CI-DESSOUS RECUPERE LA VALEUR NULL
                'GlobalVariable.gestionDeCaisseAvantCloture = ""
                Me.Close()

            End If

            'ON MET A JOURS LE MONTANT TOTAL DES VENTES COMPTOIR A FIN DE PERMETTRE LA CLOTURE
            'MainWindowBarRestaurantForm.LabelTotalVenteComptoire.Text = 0
            BarRestaurantForm.Activate()

            BarRestaurantForm.manualRefresh()

            If BarRestaurantForm.GunaComboBoxListeDesComandes.Items.Count > 0 Then

                BarRestaurantForm.GunaComboBoxListeDesComandes.SelectedIndex = 0
                GlobalVariable.blocNoteARegler = BarRestaurantForm.GunaComboBoxListeDesComandes.SelectedValue

            Else
                GlobalVariable.blocNoteARegler = ""
            End If

            Me.Close()

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "The account  " & COMPTE_PAYMASTER & " does not exit " & Chr(13) & " Please create th account in order to permit transfer !!"
                languageTitle = "ACCOUNT MANAGEMENT"
            Else
                languageMessage = "Le compte " & COMPTE_PAYMASTER & " est inexistant " & Chr(13) & " Bien vouloir le créer pour permettre un transfert !!"
                languageTitle = "GESTION DE COMPTE"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub GunaButtonRegulariser_Click(sender As Object, e As EventArgs) Handles GunaButtonRegulariser.Click

        Dim CODE_CAISSIER As String = ""

        Dim especes As Double = 0

        If Not Trim(GlobalVariable.gestionDeCaisseAvantCloture) = "" Then

            'FENETRE APPELE DEPUIS LA CLOTURE FORM

            'Gestion de cloture de caisse avant cloture de la journee (Nouvelle date de travail)
            CODE_CAISSIER = Trim(GlobalVariable.gestionDeCaisseAvantCloture)

            especes = Functions.SituationDeCaisseEspeces(GlobalVariable.DateDeTravail, CODE_CAISSIER)

            CaisseOuverteAlaCloture.transfertDeRecetteAlaCloture(CODE_CAISSIER, especes)

            Dim ETAT_CAISSE As Integer = 0
            Functions.updateOfFields("caisse", "ETAT_CAISSE", ETAT_CAISSE, "CODE_UTILISATEUR", CODE_CAISSIER, 0)

            CloturerForm.Show()
            CloturerForm.TopMost = True

        Else

            CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
            especes = Functions.SituationDeCaisseEspeces(GlobalVariable.DateDeTravail, CODE_CAISSIER)

            If especes > 0 Then

                BilletageForm.Close()
                BilletageForm.Show()
                BilletageForm.TopMost = True

            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "No sales to be transfered"
                    languageTitle = "Cash Transfer"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Aucune recette à transférer"
                    languageTitle = "Transfert de Caisse"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim ETAT_CAISSE As Integer = 0
                Functions.updateOfFields("caisse", "ETAT_CAISSE", ETAT_CAISSE, "CODE_UTILISATEUR", CODE_CAISSIER, 0)

                BarRestaurantForm.FermerCaisseToolStripMenuItem.Visible = False
                BarRestaurantForm.OuvrirCaisseToolStripMenuItem.Visible = True

                MessageBox.Show("Caisse fermée avec succès !", languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            Me.Close()

        End If

    End Sub

End Class