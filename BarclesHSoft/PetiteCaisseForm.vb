Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class PetiteCaisseForm

    'Destinée à contenir l'ensemble des fatures du client pour des mis à jours

    'Dim connect As New DataBaseManipulation()

    Public Class ArgumentType

        'action = 0 : ultrMessageSimpleText
        Public action As Integer
        Public whatsAppMessage As String
        Public mobile_number As String

    End Class

    Public Sub autoLoadNatureFonds()

        If GlobalVariable.actualLanguageValue = 1 Then

            GunaComboBoxNatureMovt.Items.Add("ENTREE DE FONDS") ' INDEX = 0
            GunaComboBoxNatureMovt.Items.Add("SORTIE DE FONDS") ' INDEX = 1
            GunaComboBoxNatureMovt.Items.Add("DEMANDE DE FONDS") ' INDEX = 2
            GunaComboBoxNatureMovt.Items.Add("ENTREES EN ATTENTES") ' INDEX = 3

        Else

            GunaComboBoxNatureMovt.Items.Add("INCOMING FUNDS") ' INDEX = 0
            GunaComboBoxNatureMovt.Items.Add("DISCHARGE OF FUNDS") ' INDEX = 1
            GunaComboBoxNatureMovt.Items.Add("REQUEST FOR FUNDS") ' INDEX = 2
            GunaComboBoxNatureMovt.Items.Add("WAITING ENTRIES") ' INDEX = 3

        End If


    End Sub

    Public Sub autoLoadDiversFournisseurs()

        Dim profils As String = "SELECT * FROM `fournisseur` ORDER BY NOM_FOURNISSEUR ASC"
        Dim command As New MySqlCommand(profils, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxFournisseur.DataSource = table
            GunaComboBoxFournisseur.ValueMember = "CODE_FOURNISSEUR"
            GunaComboBoxFournisseur.DisplayMember = "NOM_FOURNISSEUR"

        End If

    End Sub

    Public Sub autoLoadDiversServices()

        Dim profils As String = "SELECT CODE_PROFIL, NOM_PROFIL FROM utilisateur_acces ORDER BY NOM_PROFIL ASC"
        Dim commandprofilsList As New MySqlCommand(profils, GlobalVariable.connect)

        Dim adapterprofilsList As New MySqlDataAdapter(commandprofilsList)
        Dim tableprofilsList As New DataTable()
        adapterprofilsList.Fill(tableprofilsList)

        If (tableprofilsList.Rows.Count > 0) Then

            GunaComboBoxProfilUtilisateur.DataSource = tableprofilsList
            GunaComboBoxProfilUtilisateur.ValueMember = "CODE_PROFIL"
            GunaComboBoxProfilUtilisateur.DisplayMember = "NOM_PROFIL"

        End If

    End Sub

    Private Sub ReglementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.petiteCaisse(GlobalVariable.actualLanguageValue)

        Label7.Text = GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

        GunaTextBoxCaissier.Visible = False

        autoLoadDiversFournisseurs()

        autoLoadNatureFonds()

        autoLoadDiversServices()

        GunaComboBoxNatureMovt.SelectedIndex = 1

        GunaLabelIndexTitreMouvement.Text = GunaComboBoxNatureMovt.SelectedItem

        GunaCheckBoxToutVoir.Checked = True

        GunaTextBoxNom.Text = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        GunaTextBoxCaissier.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

        GunaImageButtonFermer.Visible = True
        GunaImageButtonReduce.Visible = True
        GunaImageButtonFermer.BringToFront()
        GunaImageButtonReduce.BringToFront()

        GunaLabelIndexTitreMouvement.Visible = False

        GunaDataGridViewTransactionPetiteCaisse.Columns.Clear()

        Dim reglemt As New Reglement()

        GunaTextBoxMontantVerse.Text = 0

        Dim CODE_CAISSE As String = Trim(GunaTextBoxCodePetiteCaisse.Text)
        reglemt.SituationDePetiteCaisse(LabelDepense, LabelSituationCaisse, CODE_CAISSE)

        GunaComboBoxModereglement.SelectedIndex = 0

        indicateurDEtatDeCaisse()

        Timer1.Start()

    End Sub

    Public Function listeDesMouvementsDeFondsEnAttentes(ByVal ETAT As Integer, ByVal NATURE_OPERATION As Integer) As DataTable

        'ENTREE = 1 
        'DEMANDE = 2
        'SORTIE = 0
        'ENTREE_TRAITEE = 3
        'DEMANDE_TRAITEE = 5
        'SORTIE_TRAITEE = 4

        'ETAT = 6 'ENTREE ET SORTIE NON TRAITEE (0 & 1)

        Dim query3 As String = ""

        If ETAT = 6 Then
            query3 = "SELECT * FROM petite_caisse_ligne WHERE CODE_AGENCE = @CODE_AGENCE AND CODE_CAISSE = @CODE_CAISSE ORDER BY DATE_REGLEMENT DESC "
        Else
            query3 = "SELECT * FROM petite_caisse_ligne WHERE CODE_AGENCE = @CODE_AGENCE AND CODE_CAISSE = @CODE_CAISSE AND ETAT=@ETAT AND NATURE_OPERATION=@NATURE_OPERATION ORDER BY DATE_REGLEMENT DESC "
        End If

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
        command3.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command3.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = Trim(GunaTextBoxCodeUserFiltre.Text)
        command3.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = GunaTextBoxCodePetiteCaisse.Text
        command3.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT
        command3.Parameters.Add("@NATURE_OPERATION", MySqlDbType.Int64).Value = NATURE_OPERATION

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        'ETAT = 0 : ENTREES
        'ETAT = 1 : SORTIES
        'ETAT = 2 : DEMANDES

        If ETAT = 0 Or ETAT = 1 Or ETAT = 2 Then

            GunaDataGridViewRemboursementEnAttente.Columns.Clear()

            If tableReglement.Rows.Count > 0 Then

                Dim tailleDuTableau As Integer = tableReglement.Rows.Count

                'On crée une structure de tableau
                Dim toutesLesFactures(tailleDuTableau) As SituationClient

                Dim niemElementDutableau As Integer = 0

                Dim totalFacture As Double = 0
                Dim totalReglement As Double = 0

                'Insertion des reglements dans notre structure
                For i = 0 To tableReglement.Rows.Count - 1

                    toutesLesFactures(i).dateOperation = CDate(tableReglement.Rows(i)("DATE_REGLEMENT")).ToShortDateString & " " & CDate(tableReglement.Rows(i)("HEURE_OPERATION")).ToLongTimeString
                    toutesLesFactures(i).Debit = tableReglement.Rows(i)("MONTANT_SORTIE")

                    If tableReglement.Rows(i)("MONTANT_VERSE") < 0 Then
                        toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE") * -1
                    Else
                        toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
                    End If

                    toutesLesFactures(i).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")
                    toutesLesFactures(i).numReglement = tableReglement.Rows(i)("NUM_REGLEMENT")
                    toutesLesFactures(i).receveur = tableReglement.Rows(i)("NOM_DU_RECEVEUR")
                    toutesLesFactures(i).approuve = tableReglement.Rows(i)("APPROUVE_PAR")

                    Dim infoUser As DataTable = Functions.getElementByCode(tableReglement.Rows(i)("CODE_CAISSIER"), "utilisateurs", "CODE_UTILISATEUR")

                    If infoUser.Rows.Count > 0 Then
                        toutesLesFactures(i).effectue = infoUser.Rows(0)("NOM_UTILISATEUR")
                    End If

                    totalReglement += tableReglement.Rows(i)("MONTANT_VERSE")
                    niemElementDutableau = i

                Next

                'Enfin on insere le tout dans notre datagrid
                If (toutesLesFactures.Length > 0) Then

                    GunaDataGridViewRemboursementEnAttente.Columns.Clear()

                    GunaDataGridViewRemboursementEnAttente.Columns.Add("DATE", "Date")
                    GunaDataGridViewRemboursementEnAttente.Columns.Add("REFERENCE", "Référence")
                    GunaDataGridViewRemboursementEnAttente.Columns.Add("DESCRIPTION", "Description")
                    GunaDataGridViewRemboursementEnAttente.Columns.Add("MONTANT_RETIRE", "Montant retiré")
                    GunaDataGridViewRemboursementEnAttente.Columns.Add("MONTANT_DEPOSE", "Montant déposé")
                    GunaDataGridViewRemboursementEnAttente.Columns.Add("RECEVEUR", "Receveur")
                    GunaDataGridViewRemboursementEnAttente.Columns.Add("APPROUVE_PAR", "Approuvé par")
                    GunaDataGridViewRemboursementEnAttente.Columns.Add("EFFECTUE PAR", "Effectué par")

                    For i = 0 To toutesLesFactures.Length - 1

                        If Not toutesLesFactures(i).libelleOperation = "" Then
                            GunaDataGridViewRemboursementEnAttente.Rows.Add(toutesLesFactures(i).dateOperation, toutesLesFactures(i).numReglement, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"), toutesLesFactures(i).receveur, toutesLesFactures(i).approuve, toutesLesFactures(i).effectue)
                        End If

                    Next

                End If

            End If

        Else

            If tableReglement.Rows.Count > 0 Then
                Return tableReglement
            End If

        End If

    End Function

    Public Function listeDesMouvementsDeFonds(ByVal ETAT As Integer, ByVal NATURE_OPERATION As Integer) As DataTable

        'ENTREE = 1 
        'DEMANDE = 2
        'SORTIE = 0
        'ENTREE_TRAITEE = 3
        'DEMANDE_TRAITEE = 5
        'SORTIE_TRAITEE = 4

        'ETAT = 6 'ENTREE ET SORTIE NON TRAITEE (0 & 1)

        Dim query3 As String = ""

        If ETAT = 6 Then
            query3 = "SELECT * FROM petite_caisse_ligne WHERE CODE_AGENCE = @CODE_AGENCE AND CODE_CAISSE = @CODE_CAISSE ORDER BY DATE_REGLEMENT DESC "
        Else
            query3 = "SELECT * FROM petite_caisse_ligne WHERE CODE_AGENCE = @CODE_AGENCE AND CODE_CAISSE = @CODE_CAISSE AND ETAT=@ETAT AND NATURE_OPERATION=@NATURE_OPERATION ORDER BY DATE_REGLEMENT DESC "
        End If

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
        command3.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command3.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = Trim(GunaTextBoxCodeUserFiltre.Text)
        command3.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = GunaTextBoxCodePetiteCaisse.Text
        command3.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT
        command3.Parameters.Add("@NATURE_OPERATION", MySqlDbType.Int64).Value = NATURE_OPERATION

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        'ETAT = 0 : ENTREES
        'ETAT = 1 : SORTIES
        'ETAT = 2 : DEMANDES

        If ETAT = 0 Or ETAT = 1 Or ETAT = 2 Then

            GunaDataGridViewTransactionPetiteCaisse.Columns.Clear()

            If tableReglement.Rows.Count > 0 Then

                Dim tailleDuTableau As Integer = tableReglement.Rows.Count

                'On crée une structure de tableau
                Dim toutesLesFactures(tailleDuTableau) As SituationClient

                Dim niemElementDutableau As Integer = 0

                Dim totalFacture As Double = 0
                Dim totalReglement As Double = 0

                'Insertion des reglements dans notre structure
                For i = 0 To tableReglement.Rows.Count - 1

                    toutesLesFactures(i).dateOperation = CDate(tableReglement.Rows(i)("DATE_REGLEMENT")).ToShortDateString & " " & CDate(tableReglement.Rows(i)("HEURE_OPERATION")).ToLongTimeString
                    toutesLesFactures(i).Debit = tableReglement.Rows(i)("MONTANT_SORTIE")

                    If tableReglement.Rows(i)("MONTANT_VERSE") < 0 Then
                        toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE") * -1
                    Else
                        toutesLesFactures(i).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
                    End If

                    toutesLesFactures(i).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")
                    toutesLesFactures(i).numReglement = tableReglement.Rows(i)("NUM_REGLEMENT")
                    toutesLesFactures(i).receveur = tableReglement.Rows(i)("NOM_DU_RECEVEUR")
                    toutesLesFactures(i).approuve = tableReglement.Rows(i)("APPROUVE_PAR")

                    Dim infoUser As DataTable = Functions.getElementByCode(tableReglement.Rows(i)("CODE_CAISSIER"), "utilisateurs", "CODE_UTILISATEUR")

                    If infoUser.Rows.Count > 0 Then
                        toutesLesFactures(i).effectue = infoUser.Rows(0)("NOM_UTILISATEUR")
                    End If

                    totalReglement += tableReglement.Rows(i)("MONTANT_VERSE")
                    niemElementDutableau = i

                Next

                'Enfin on insere le tout dans notre datagrid
                If (toutesLesFactures.Length > 0) Then

                    GunaDataGridViewTransactionPetiteCaisse.Columns.Clear()

                    GunaDataGridViewTransactionPetiteCaisse.Columns.Add("DATE", "Date")
                    GunaDataGridViewTransactionPetiteCaisse.Columns.Add("REFERENCE", "Référence")
                    GunaDataGridViewTransactionPetiteCaisse.Columns.Add("DESCRIPTION", "Description")
                    GunaDataGridViewTransactionPetiteCaisse.Columns.Add("MONTANT_RETIRE", "Montant retiré")
                    GunaDataGridViewTransactionPetiteCaisse.Columns.Add("MONTANT_DEPOSE", "Montant déposé")
                    GunaDataGridViewTransactionPetiteCaisse.Columns.Add("RECEVEUR", "Receveur")
                    GunaDataGridViewTransactionPetiteCaisse.Columns.Add("APPROUVE_PAR", "Approuvé par")
                    GunaDataGridViewTransactionPetiteCaisse.Columns.Add("EFFECTUE PAR", "Effectué par")

                    For i = 0 To toutesLesFactures.Length - 1

                        If Not toutesLesFactures(i).libelleOperation = "" Then
                            GunaDataGridViewTransactionPetiteCaisse.Rows.Add(toutesLesFactures(i).dateOperation, toutesLesFactures(i).numReglement, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"), toutesLesFactures(i).receveur, toutesLesFactures(i).approuve, toutesLesFactures(i).effectue)
                        End If

                    Next

                    'GunaDataGridViewTransactionPetiteCaisse.Columns("NUM_REGLEMENT").Visible = False
                    'Sorting the elements of situation client
                    'GunaDataGridView1.DataSource.Sort(GunaDataGridView1.DataSource.Columns(-1), ListSortDirection.Descending)

                End If

            End If

        Else

            If tableReglement.Rows.Count > 0 Then
                Return tableReglement
            End If

        End If

    End Function

    Public Sub SituationDeCaisseJournaliere()

        '---------------------------------------------------------- WORKING PERFECTLY -------------------------------------------------------------

        'Dim situationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

        'Dim TotalFacture As Double = 0

        'If situationDeCaisse.Rows.Count > 0 Then
        'On selection l'ensemble des reglements d'un jour donné
        'For i = 0 To situationDeCaisse.Rows.Count - 1
        'TotalFacture += situationDeCaisse.Rows(i)("MONTANT_VERSE")
        'Next

        'Dim situationDeCaisseCasDeRemboursement As DataTable = Functions.SituationDeCaisseCasDeRemboursement(GlobalVariable.DateDeTravail)

        'Dim TotalRembourse As Double = 0
        'On selection l'ensemble des remboursement d'un jour donné
        'If situationDeCaisseCasDeRemboursement.Rows.Count > 0 Then

        'For j = 0 To situationDeCaisseCasDeRemboursement.Rows.Count - 1
        'TotalRembourse += situationDeCaisseCasDeRemboursement.Rows(j)("MONTANT_HT")
        'Next

        'On soustrait les montant remboursé des montants encaissé
        'TotalFacture -= TotalRembourse

        'End If

        'LabelSituationCaisse.Text = Format(TotalFacture, "#,##0")

        'Else
        'LabelSituationCaisse.Text = 0
        'End If

        '--------------------------------------------------------- WORKING PERFECTLY ---------------------------------------------------------------

    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButtonReduce.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButtonFermer.Click
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonOuvertureFermeture.Click

        If GunaButtonOuvertureFermeture.Text = "Ouvrir Caisse" Or GunaButtonOuvertureFermeture.Text = "Open Petty Cash" Then

            passwordVerifivationForm.Close()

            GlobalVariable.fenetreDouvervetureDeCaisse = "petite caisse"

            passwordVerifivationForm.Show()
            passwordVerifivationForm.TopMost = True

        ElseIf GunaButtonOuvertureFermeture.Text = "Fermer Caisse" Or GunaButtonOuvertureFermeture.Text = "Close Petty Cash" Then

            BilletageForm.Close()

            GlobalVariable.billetageAPartirDe = "petite caisse"
            GlobalVariable.fenetreDouvervetureDeCaisse = "petite caisse"

            BilletageForm.Show()
            BilletageForm.TopMost = True

            BilletageForm.LabelSituationCaisse.Text = Format(Double.Parse(LabelSituationCaisse.Text), "#,##0")
            BilletageForm.LabelMontantSorti.Text = Format(Double.Parse(LabelDepense.Text), "#,##0")

        End If

        indicateurDEtatDeCaisse()

    End Sub

    Structure SituationClient

        Dim dateOperation
        Dim libelleOperation
        Dim Debit
        Dim Credit
        Dim numReglement
        Dim receveur
        Dim approuve
        Dim effectue

    End Structure

    Public Sub GestionOuvertureDeCaisse()

        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

        Dim CODE_CAISSE As String = ""

        Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "utilisateur_caisse", "CODE_UTILISATEUR")

        If CAISSE_UTILISATEUR.Rows.Count > 0 Then

            CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

            'Dim caisse As DataTable = Functions.getElementByCode(CODE_CAISSE, "petite_caisse", "CODE_CAISSE")

        End If

        Dim ETAT_CAISSE As Integer = 1
        Dim caissier As New Caisse()

        caissier.ouvertureFermetureDePetiteCaisse(CODE_CAISSE, ETAT_CAISSE)

        MessageBox.Show("Caisse ouverte avec succès", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Public Sub indicateurDEtatDeCaisse()

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("PETITE_CAISSE") = 1 Then

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim utilisateur_caisse As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "utilisateur_caisse", "CODE_UTILISATEUR")

            If utilisateur_caisse.Rows.Count > 0 Then

                Dim CODE_CAISSE As String = utilisateur_caisse.Rows(0)("CODE_CAISSE")

                Dim caisse As DataTable = Functions.getElementByCode(CODE_CAISSE, "petite_caisse", "CODE_CAISSE")

                If caisse.Rows(0)("ETAT_CAISSE") = 0 Then

                    PanelTotalSortie.BackColor = Color.Red
                    PanelSituationCaisse.BackColor = Color.Red

                    GunaButtonOuvertureFermeture.Text = "Ouvrir Caisse"

                    LabelSituationCaisse.Text = 0
                    LabelDepense.Text = 0
                    GunaDataGridViewTransactionPetiteCaisse.Columns.Clear()

                Else

                    PanelTotalSortie.BackColor = Color.LightGreen
                    PanelSituationCaisse.BackColor = Color.LightGreen

                    GunaButtonOuvertureFermeture.Text = "Fermer Caisse"

                End If

            End If

        End If

        Dim ETAT As Integer = 0
        AffichageDesLigneDePetitesCaisse(ETAT)

        If GunaComboBoxNatureMovt.SelectedIndex = 3 Then
            TabControl1.SelectedIndex = 1
        Else
            TabControl1.SelectedIndex = 0
        End If

    End Sub



    'We save the reglement form information
    Private Sub GunaButtonEnregistrerClient_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerReglement.Click

        Me.Cursor = Cursors.WaitCursor

        If Trim(GunaTextBoxMontantVerse.Text) = "" Then
            GunaTextBoxMontantVerse.Text = 0
        End If
        'Seule ceux qui ont le droit d'avoir accès à la caisse peuvent encaisser

        Dim CODE_CAISSE As String = ""

        Dim effacementDesChamps As Boolean = False

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("PETITE_CAISSE") = 1 Then

            'Même si on a le droit a la caisse on doit encore être associé à une caisse pour pouvoir encaisser

            Dim infoUtilisateurCaisse As DataTable = Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "utilisateur_caisse", "CODE_UTILISATEUR")

            Dim MONTANT_PLAFONDS As Double = 0

            If Not Trim(GunaTextBoxPLafonds.Text).Equals("") Then
                MONTANT_PLAFONDS = Double.Parse(GunaTextBoxPLafonds.Text)
            End If

            Dim TOTAL_SORTIE As Double = Double.Parse(LabelDepense.Text)
            Dim TOTAL_EN_CAISSE As Double = Double.Parse(LabelSituationCaisse.Text)

            Dim CODE_MONNAIE As String = " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

            Dim nomDelaTable As String = "petite_caisse_ligne"

            If Not Trim(GunaTextBoxCodeRefrence.Text).Equals("") Then

                If Not Trim(GunaTextBoxMotif.Text).Equals("") Then

                    Dim NATURE_OPERATION As Integer = GunaComboBoxNatureMovt.SelectedIndex

                    Dim APPROUVE_PAR As String = GunaTextBoxApprouvePar.Text

                    'DEMANDE DE FONDS DU PROPRIATAIRE DE LA PETITE CAISSE

                    If GunaComboBoxNatureMovt.SelectedIndex = 2 Then '"DEMANDE DE FONDS "

                        Dim RECETTE_A_TRANSFERER As Double = 0

                        If Not Trim(GunaTextBoxMontantVerse.Text).Equals("") Then
                            RECETTE_A_TRANSFERER = GunaTextBoxMontantVerse.Text
                        End If

                        If RECETTE_A_TRANSFERER > 0 Then

                            Dim message As String = ""
                            Dim envoyer As Boolean = False

                            'ON TEST LES DIFFERENTS SCENARI

                            If RECETTE_A_TRANSFERER > MONTANT_PLAFONDS Then
                                message = "Le montant demandé est supérieur au plafonds !!"
                            Else

                                If TOTAL_SORTIE = 0 Then

                                    If TOTAL_EN_CAISSE = 0 Then
                                        envoyer = True
                                    Else
                                        If TOTAL_EN_CAISSE > 0 Then

                                            If TOTAL_EN_CAISSE + RECETTE_A_TRANSFERER <= MONTANT_PLAFONDS Then
                                                envoyer = True
                                                effacementDesChamps = True
                                            Else
                                                message = "Vous pouvez faire une demande d'un montant maximal de " & Chr(13) & Format(MONTANT_PLAFONDS - TOTAL_EN_CAISSE, "#,##0") & CODE_MONNAIE
                                            End If

                                        End If
                                    End If

                                Else

                                    If TOTAL_EN_CAISSE = 0 Then
                                        envoyer = True
                                    Else

                                        If TOTAL_EN_CAISSE > 0 Then

                                            If TOTAL_EN_CAISSE + RECETTE_A_TRANSFERER <= MONTANT_PLAFONDS Then
                                                envoyer = True
                                                effacementDesChamps = True
                                            Else
                                                message = "Vous pouvez faire une demande d'un montant maximal de " & Chr(13) & Format(MONTANT_PLAFONDS - TOTAL_EN_CAISSE, "#,##0") & CODE_MONNAIE
                                            End If

                                        End If

                                    End If

                                End If

                            End If

                            '2- ON SE RASSURE QUE LE MONTANT ENVOYE EST SUPERIEUR A ZERO

                            If envoyer Then

                                Dim nomDuChamp As String = ""
                                Dim ValeurDuChamp As String = ""
                                Dim nomDuChampDuCode As String = "NUM_REGLEMENT" 'POUR LE WHERE DE LA REQUETTE
                                Dim valeurDuChampDuCode As String = ""
                                Dim variableType As Integer = 0

                                Dim CODE_TRANSFERT_RECETTE As String = Functions.GeneratingRandomCode("transfert_recette", "TR")

                                effacementDesChamps = True
                                message = GunaComboBoxNatureMovt.SelectedItem & " éffectué avec succès !!"

                                Dim CODE_SYNTHESE As String = Functions.GeneratingRandomCode("petite_caisse_ligne_synthese", "PCLS")

                                traitementDeRecettePourTransfertVersLaCaissePrincipale(RECETTE_A_TRANSFERER, CODE_TRANSFERT_RECETTE)

                                'ON DOIT CHANGER L'ETAT DE CHAQUE LIGNE DE SORTIE DE FONDS SELECTIONS

                                If GunaDataGridViewTransactionPetiteCaisse.Rows.Count > 0 Then

                                    rapportLigneSyntheseDePtiteCaisse(RECETTE_A_TRANSFERER, CODE_SYNTHESE)

                                    Dim NUM_REGLEMENT As String = ""

                                    For Each row As DataGridViewRow In GunaDataGridViewTransactionPetiteCaisse.SelectedRows

                                        NUM_REGLEMENT = Trim(row.Cells("REFERENCE").Value.ToString)

                                        '1- MISE A JOURS DE L'ETAT DE LA LIGNE
                                        nomDuChamp = "ETAT"
                                        ValeurDuChamp = "1"
                                        valeurDuChampDuCode = NUM_REGLEMENT

                                        Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                                        '2- INSERTION DU CODE DE TRANSFERT EN MODE UPDATE
                                        nomDuChamp = "CODE_SYNTHESE"
                                        ValeurDuChamp = CODE_SYNTHESE
                                        variableType = 2 'VARIABLE DE TYPE STRING

                                        Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                                    Next

                                    '2- ON CHANGE L'ETAT DE TOUS LES ENTREES DE FONDS ET ON REMPLACE PAR UNE LIGNE QUI DETERMINE LE MONTANT EN CAISSE

                                    Dim ETAT As Integer = 0
                                    Dim NATURE_OPERATION_ENTREE As Integer = 0

                                    Dim entreeDeFonds As DataTable = Functions.GetAllElementsOnTwoConditions(ETAT, "petite_caisse_ligne", "ETAT", NATURE_OPERATION_ENTREE, "NATURE_OPERATION")

                                    If entreeDeFonds.Rows.Count > 0 Then

                                        For i = 0 To entreeDeFonds.Rows.Count - 1

                                            NUM_REGLEMENT = entreeDeFonds.Rows(i)("NUM_REGLEMENT")

                                            nomDuChamp = "ETAT"
                                            ValeurDuChamp = "1"
                                            variableType = 0 ' VARIABLE DE TYPE INTEGER
                                            valeurDuChampDuCode = NUM_REGLEMENT

                                            Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                                        Next

                                    End If

                                    '3- INSERTION D'UNE LIGNE NEGATIVE EN REMPLACEMENT AUX ENTREES RETIREES

                                    Dim MONTANT_SORTIE As Double = 0
                                    Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                    Dim MONTANT_VERSE As Double = Double.Parse(LabelSituationCaisse.Text) * -1
                                    Dim DATE_REGLEMENT As String = GlobalVariable.DateDeTravail
                                    Dim MODE_REGLEMENT As String = "Espèces"
                                    Dim REF_REGLEMENT As String = "SOLDE EN CAISSE APRES DEMANDE DE FONDS PAR " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
                                    Dim SERVICE_DEMANDEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                    ETAT = 0
                                    Dim CODE_AGENCE = GlobalVariable.codeAgence
                                    Dim NOM_DU_RECEVEUR = ""
                                    Dim CNI_RECEVEUR = ""

                                    NATURE_OPERATION = 0
                                    APPROUVE_PAR = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
                                    Dim MODE_REG_INFO_SUP_1 As String = ""
                                    Dim MODE_REG_INFO_SUP_2 As String = ""
                                    Dim MODE_REG_INFO_SUP_3 As String = Date.Now().ToShortDateString

                                    CODE_CAISSE = GunaTextBoxCodePetiteCaisse.Text

                                    Dim reglement As New Reglement()

                                    reglement.insertPetiteCaisseLigne(NUM_REGLEMENT, MONTANT_SORTIE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, SERVICE_DEMANDEUR, ETAT, CODE_AGENCE, NOM_DU_RECEVEUR, CNI_RECEVEUR, CODE_CAISSE, NATURE_OPERATION, APPROUVE_PAR, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                End If

                                nomDuChamp = "CODE_SYNTHESE"
                                ValeurDuChamp = CODE_SYNTHESE
                                variableType = 2 'VARIABLE DE TYPE STRING

                                Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                                MessageBox.Show(message, "Gestion de Petite Caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else
                                MessageBox.Show(message, "Gestion de Petite Caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                        Else

                            Dim message As String = "Bien vouloir saisir un montant correct !!"
                            MessageBox.Show(message, "Gestion de Petite Caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    Else

                        'GESTION DES ENTREES ET DES SORTIES

                        If infoUtilisateurCaisse.Rows.Count > 0 Then

                            Dim ETAT_CAISSE As Integer = 0

                            Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                            CODE_CAISSE = infoUtilisateurCaisse.Rows(0)("CODE_CAISSE")

                            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_CAISSE, "petite_caisse", "CODE_CAISSE")

                            If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                                ETAT_CAISSE = CAISSE_UTILISATEUR.Rows(0)("ETAT_CAISSE")

                            End If

                            If ETAT_CAISSE = 0 Then

                                MessageBox.Show("Bien vouloir ouvrir votre caisse!!", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                GlobalVariable.fenetreDouvervetureDeCaisse = "petite caisse"

                                passwordVerifivationForm.Show()
                                passwordVerifivationForm.TopMost = True

                            Else

                                Dim MODE_REG_INFO_SUP_1 As String = GunaTextBoxReference.Text 'REFERENCE DE FACTURE PAR EXEMPLE
                                Dim MODE_REG_INFO_SUP_2 As String = GunaTextBoxNomDuReceveur.Text 'NOM DU RECEVEUR
                                Dim MODE_REG_INFO_SUP_3 As String = Date.Now().ToShortDateString

                                'NATURE_OPERATION = 0 : ENTREE FONDS
                                'NATURE_OPERATION = 1 : SORTIE FONDS
                                'NATURE_OPERATION = 2 : DEMANDE DE FONDS

                                'If Double.Parse(GunaTextBoxMontantVerse.Text) >= Double.Parse(GunaTextBoxAPayer.Text) Then
                                If Double.Parse(GunaTextBoxMontantVerse.Text) > 0 Then

                                    'We update the state of the values of the invoice
                                    Dim facture As New LigneFacture()

                                    'We have to update each facture in the list of the client facture
                                    Dim montanVerse As Double = GunaTextBoxMontantVerse.Text

                                    Dim CNI_RECEVEUR As String = GunaTextBoxCNIDuReceveur.Text 'CNI DU RECEVEUR

                                    'GESTION DES ENCAISSEMENTS
                                    'Insert a line into reglement
                                    Dim reglement As New Reglement()
                                    Dim caisse As New Caisse()

                                    Dim NUM_REGLEMENT As String = GunaTextBoxCodeRefrence.Text

                                    Dim MONTANT_SORTIE As Double
                                    Dim MONTANT_VERSE = Double.Parse(GunaTextBoxMontantVerse.Text)

                                    If GunaComboBoxNatureMovt.SelectedIndex = 0 Then
                                        'ENTREE DE FONDS
                                        MONTANT_SORTIE = 0
                                        MONTANT_VERSE = Double.Parse(GunaTextBoxMontantVerse.Text)
                                    Else
                                        'SORTIE DE FONDS
                                        MONTANT_SORTIE = Double.Parse(GunaTextBoxMontantVerse.Text)
                                        MONTANT_VERSE = 0
                                    End If

                                    Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                                    Dim DATE_REGLEMENT = GlobalVariable.DateDeTravail
                                    Dim MODE_REGLEMENT = GunaComboBoxModereglement.SelectedItem

                                    Dim REF_REGLEMENT As String = GunaTextBoxReference.Text

                                    Dim SERVICE_DEMANDEUR = "" 'SERVICE DEMANDEUR

                                    'SI ON NE TRAITE PAS LES ENTREES DE FONDS CAR LES SORTIE ET DEMANDES DE FONDS NECESSSITE DE CONNAITRE LE SERVICE DEMANDEUR

                                    If GunaCheckBoxTiers.Checked Then
                                        'TRAITEMENT DES TIERS
                                        SERVICE_DEMANDEUR = GunaComboBoxFournisseur.SelectedValue.ToString()
                                    Else
                                        SERVICE_DEMANDEUR = GunaComboBoxProfilUtilisateur.SelectedValue.ToString()
                                    End If

                                    Dim ETAT = 0
                                    Dim CODE_AGENCE = GlobalVariable.codeAgence
                                    Dim NOM_DU_RECEVEUR As String = GunaTextBoxNomDuReceveur.Text

                                    Dim message As String = ""

                                    '------------------------ reglement -------------------

                                    If GunaComboBoxNatureMovt.SelectedIndex = 0 Then

                                        'ENTREE DE FONDS => ON NE DOIT JAMAIS AVOIR UN SOLDE SUPERIEUR AU PLAFONDS POUR LES ENTREES DE FONDS

                                        If TOTAL_EN_CAISSE + MONTANT_VERSE <= MONTANT_PLAFONDS Then

                                            'ON DOIT VERIFIER QUE CE N'EST PAS LA PREMIERE DEMANDE QUI EST DIRECTE OU  ALORS QUE L'ON NE PASSE PAS PAR LES ENTREES EN ATTENTES
                                            'CAR A PART LA PREMIERE ENTREE TOUTES LES AUTRES ENTREES EN CAISSE SE FERONT PAR LES ENTREES EN ATTENTES

                                            If Not Trim(GunaTextBoxRefEntreeEnAttntes.Text).Equals("") Then

                                                Dim intoTransacEnAttente As DataTable = Functions.getElementByCode(GunaTextBoxRefEntreeEnAttntes.Text, "petite_caisse_ligne", "NUM_REGLEMENT")

                                                If intoTransacEnAttente.Rows.Count > 0 Then

                                                    '-----------------------------------------------------------------------------
                                                    Dim NUM_REGLEMENT_ As String = ""

                                                    For Each row As DataGridViewRow In GunaDataGridViewRemboursementEnAttente.SelectedRows

                                                        NUM_REGLEMENT_ = Trim(row.Cells("REFERENCE").Value.ToString)

                                                        '1- MISE A JOURS DE L'ETAT DE LA LIGNE
                                                        Dim nomDuChamp As String = "ETAT"
                                                        Dim ValeurDuChamp = "0"
                                                        Dim valeurDuChampDuCode As String = NUM_REGLEMENT_
                                                        Dim nomDuChampDuCode As String = "NUM_REGLEMENT"
                                                        Dim variableType As Integer = 2 'VARIABLE DE TYPE STRING

                                                        Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                                                        Dim CODE_SYNTHESE As String = Functions.GeneratingRandomCode("petite_caisse_ligne_synthese", "PCLS")
                                                        '2- INSERTION DU CODE DE TRANSFERT EN MODE UPDATE
                                                        nomDuChamp = "CODE_SYNTHESE"
                                                        ValeurDuChamp = CODE_SYNTHESE

                                                        'Functions.updateOfFields(nomDelaTable, nomDuChamp, ValeurDuChamp, nomDuChampDuCode, valeurDuChampDuCode, variableType)

                                                    Next
                                                    '-----------------------------------------------------------------------------

                                                End If

                                                GunaTextBoxRefEntreeEnAttntes.Text = ""

                                            Else

                                                reglement.insertPetiteCaisseLigne(NUM_REGLEMENT, MONTANT_SORTIE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, SERVICE_DEMANDEUR, ETAT, CODE_AGENCE, NOM_DU_RECEVEUR, CNI_RECEVEUR, CODE_CAISSE, NATURE_OPERATION, APPROUVE_PAR, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                            End If

                                            effacementDesChamps = True
                                            message = GunaComboBoxNatureMovt.SelectedItem & " éffectué avec succès !!"

                                            reglement.UpdateMontantSortieEtTotalEnCaissePetiteCaisseLigne(CODE_CAISSE, NATURE_OPERATION, MONTANT_VERSE)

                                            MessageBox.Show(message, "Petite caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        Else
                                            message = "Vous pouvez faire une entrée d'un montant maximum de " & Chr(13) & Format(MONTANT_PLAFONDS - TOTAL_EN_CAISSE, "#,##0") & CODE_MONNAIE
                                            MessageBox.Show(message, "Petite caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End If

                                    ElseIf GunaComboBoxNatureMovt.SelectedIndex = 1 Then

                                        'SORTIE DE FONDS => LE MONTANT A SORTIR NE DOIT JAMAIS ETRE SUPERIEUR AU MONTANT EN CAISSE

                                        If TOTAL_EN_CAISSE >= MONTANT_SORTIE Then

                                            reglement.insertPetiteCaisseLigne(NUM_REGLEMENT, MONTANT_SORTIE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, SERVICE_DEMANDEUR, ETAT, CODE_AGENCE, NOM_DU_RECEVEUR, CNI_RECEVEUR, CODE_CAISSE, NATURE_OPERATION, APPROUVE_PAR, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                            effacementDesChamps = True

                                            message = GunaComboBoxNatureMovt.SelectedItem & " éffectué avec succès !!"

                                            reglement.UpdateMontantSortieEtTotalEnCaissePetiteCaisseLigne(CODE_CAISSE, NATURE_OPERATION, MONTANT_SORTIE)

                                            MessageBox.Show(message, "Petite caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                            Dim NOM_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

                                            whatsAppMessage = "SORTIE DE FONDS PETITE CAISSE " & Chr(13) & "-/ MONTANT : " & MONTANT_SORTIE & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE") & " POUR : " & GunaTextBoxMotif.Text & " PAR : " & NOM_UTILISATEUR & " LE : " & GlobalVariable.DateDeTravail & " " & Now().ToShortTimeString & " SERVICE DEMANDEUR :  " & SERVICE_DEMANDEUR & " RECEVEUR : " & NOM_DU_RECEVEUR

                                            Dim mobile_number As String = MainWindow.listeOfTelephoneNumbers()

                                            'If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                                            'Functions.ultrMessageSimpleText(whatsAppMessage, mobile_number)
                                            'End If

                                            Dim args As New ArgumentType()
                                            args.action = 0
                                            args.whatsAppMessage = whatsAppMessage
                                            args.mobile_number = mobile_number

                                        Else
                                            message = "Vous pouvez faire une sortie d'un montant maximum de " & Chr(13) & Format(TOTAL_EN_CAISSE, "#,##0") & CODE_MONNAIE
                                            MessageBox.Show(message, "Petite caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End If

                                    End If

                                Else
                                    'Montant versé inférieur au montant 
                                    MessageBox.Show("Bien vouloir saisir un montant correcte!", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    GunaTextBoxMontantVerse.Text = 0

                                End If

                            End If

                        Else

                            MessageBox.Show("Vous ne pouvez pas encaisser, car vous n'avez aucune caisse! ", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If

                    End If

                Else
                    MessageBox.Show("Bien vouloir entrer un motif! ", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Bien vouloir remplir la Rérérence !!", "Gestion de Petite Caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBox.Show("Vous n'êtes pas abilité à encaisser! ", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        indicateurDEtatDeCaisse()

        If effacementDesChamps Then

            Dim rglemt As New Reglement()

            GunaTextBoxMotif.Clear()

            rglemt.SituationDePetiteCaisse(LabelDepense, LabelSituationCaisse, CODE_CAISSE)

            'Dim ETAT As Integer = 0
            'AffichageDesLigneDePetitesCaisse(ETAT)

            GunaTextBoxCodeRefrence.Clear()
            GunaTextBoxMotif.Clear()
            GunaTextBoxNomDuReceveur.Clear()
            GunaTextBoxCNIDuReceveur.Clear()
            GunaTextBoxApprouvePar.Clear()
            GunaTextBoxMontantVerse.Text = 0

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Dim whatsAppMessage As String = ""

    Dim web1 As New WebBrowser
    Dim web2 As New WebBrowser
    Dim web3 As New WebBrowser
    Dim web4 As New WebBrowser
    Dim web5 As New WebBrowser

    'SITUATION DE CAISSE
    Private Sub PanelSituationCaisse_DoubleClick(sender As Object, e As EventArgs) Handles PanelSituationCaisse.DoubleClick, PanelTotalSortie.DoubleClick

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

    'Nature du mouvement entree ou sortie
    Private Sub GunaComboBoxNatureMovt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNatureMovt.SelectedIndexChanged

        GunaTextBoxMontantVerse.Text = 0

        '"ENTREE DE FONDS" ' INDEX = 0
        '"SORTIE DE FONDS" ' INDEX = 1
        '"DEMANDE DE FONDS" ' INDEX = 2
        'Entree

        GunaTextBoxNomDuReceveur.Text = ""
        GunaTextBoxCNIDuReceveur.Text = ""
        GunaTextBoxRefEntreeEnAttntes.Text = ""
        GunaTextBoxMontantVerse.Text = 0

        Dim NATURE_OPERATION As Integer = 0

        'SI L'ON LE TRAITE PAS LES DEMANDES DE DECAISSEMENT ON DOIT TOJOURS ETRE LE TAB 1


        If Not GunaComboBoxNatureMovt.SelectedIndex = 0 Then

            PanelServiceDemandeur.Visible = True
            GunaPaneInfoSupReceveur.Visible = True

            GunaCheckBoxTiers.Visible = False
            GunaPanelTiers.Visible = False

        Else

        End If

        Dim infopetiteCaisse As DataTable = Functions.allTableFields("petite_caisse_ligne")

        If GunaComboBoxNatureMovt.SelectedIndex = 1 Then

            GunaButtonImprimerListeDesComptes.Visible = True

            GunaLabelIndexTitreMouvement.Text = "SORTIES DES FONDS"
            GunaCheckBoxTiers.Visible = True

            GunaTextBoxMontantVerse.Enabled = True
            GunaTextBoxMontantVerse.BaseColor = Color.White

            If infopetiteCaisse.Rows.Count <= 0 Then
                GunaTextBoxMontantVerse.Enabled = False
            End If

        ElseIf GunaComboBoxNatureMovt.SelectedIndex = 0 Then

            GunaButtonImprimerListeDesComptes.Visible = True

            GunaLabelIndexTitreMouvement.Text = "ENTREES DES FONDS"
            GunaCheckBoxTiers.Visible = False
            GunaPanelTiers.Visible = False

            GunaTextBoxNomDuReceveur.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
            GunaTextBoxCNIDuReceveur.Text = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")

            GunaTextBoxMontantVerse.Enabled = True
            GunaTextBoxMontantVerse.BaseColor = Color.White

        ElseIf GunaComboBoxNatureMovt.SelectedIndex = 2 Then

            GunaButtonImprimerListeDesComptes.Visible = True
            GunaCheckBoxTiers.Visible = False
            GunaLabelIndexTitreMouvement.Text = "DEMANDE DE FONDS"

            GunaTextBoxNomDuReceveur.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
            GunaTextBoxCNIDuReceveur.Text = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")

            'SI ON A DES SORTIE DE CAISSE NON CLOTURE ALORS LE MONTANT DE LA DEMANDE DEPEND DE LA SELECTION DES LIGNES DE SORTIE
            If GunaDataGridViewTransactionPetiteCaisse.Rows.Count > 0 Then

                GunaTextBoxMontantVerse.Enabled = False
                GunaTextBoxMontantVerse.BaseColor = Color.LightPink

            Else

                GunaTextBoxMontantVerse.Enabled = True
                GunaTextBoxMontantVerse.BaseColor = Color.White

            End If

        ElseIf GunaComboBoxNatureMovt.SelectedIndex = 3 Then

            'GunaComboBoxNatureMovt.SelectedIndex = 3

            GunaButtonImprimerListeDesComptes.Visible = True
            GunaCheckBoxTiers.Visible = False
            GunaLabelIndexTitreMouvement.Text = "DEMANDE EN ATTENTES"

        End If

        Timer1.Start()

    End Sub

    Dim CODE_CAISSE_ACTUEL As String = ""

    Private Sub GunaTextBox1_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxParCaissier.TextChanged, GunaTextBoxCodeUserFiltre.TextChanged, GunaTextBoxCodePetiteCaisse.TextChanged

        CODE_CAISSE_ACTUEL = GunaTextBoxCodePetiteCaisse.Text

        GunaDataGridView2.Visible = True

        If GunaTextBoxParCaissier.Text = "" Then
            GunaDataGridView2.Visible = False
        End If

        Dim query As String = "SELECT NOM_UTILISATEUR FROM utilisateurs, utilisateur_acces, utilisateur_caisse WHERE utilisateurs.CATEG_UTILISATEUR = utilisateur_acces.CODE_PROFIL AND utilisateur_acces.PETITE_CAISSE = 1 AND NOM_UTILISATEUR LIKE '%" & GunaTextBoxParCaissier.Text & "%' AND utilisateur_caisse.CODE_CAISSE=@CODE_CAISSE"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        command.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE_ACTUEL
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridView2.DataSource = table
        Else
            GunaDataGridView2.Columns.Clear()
            GunaDataGridView2.Visible = False
        End If

        If GunaTextBoxParCaissier.Text = "" Then
            GunaDataGridView2.Visible = False
        End If

    End Sub

    Private Sub GunaDataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridView2.CellClick

        GunaDataGridView2.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridView2.Rows(e.RowIndex)

            Dim NomUserFiltret As String = row.Cells("NOM_UTILISATEUR").Value.ToString
            GunaTextBoxParCaissier.Text = NomUserFiltret
            Dim client As DataTable = Functions.getElementByCode(NomUserFiltret, "utilisateurs", "NOM_UTILISATEUR")
            GunaTextBoxCodeUserFiltre.Text = client.Rows(0)("CODE_UTILISATEUR")

            GunaDataGridView2.Visible = False

        End If

    End Sub

    'Affichage des mouvements de fonds suivant un filtre
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        GunaCheckBoxToutVoir.Checked = False

        GunaTextBoxCodeUserFiltre.Clear()
        GunaDataGridView2.Visible = False

    End Sub

    Private Sub GunaCheckBoxToutVoir_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxToutVoir.Click

        GunaTextBoxCodeUserFiltre.Clear()
        GunaDataGridView2.Visible = False

        If GunaCheckBoxToutVoir.Checked Then

        Else

        End If

    End Sub

    Public Sub rapportLigneSyntheseDePtiteCaisse(ByVal RECETTE_A_TRANSFERER As Double, ByVal CODE_SYNTHESE As String)

        '1- GENERATION DE LA LIGNE DE TRANSACTION QUI SERA VISIBLE AU NIVEAU DE LA CAISSE PRINCIPALE SOUS FORME DE FACTURE

        'Variables for filling the facturation data
        Dim infoSup As String = ""

        Dim caisse As DataTable = Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "utilisateur_caisse", "CODE_UTILISATEUR")
        If caisse.Rows.Count > 0 Then

            Dim PetiteCaisse As DataTable = Functions.getElementByCode(caisse.Rows(0)("CODE_CAISSE"), "petite_caisse", "CODE_CAISSE")

            If True Then
                infoSup = " [ " & PetiteCaisse.Rows(0)("LIBELLE_CAISSE") & " ] "
            End If

        End If

        Dim DATE_SYNTHESE As Date = GlobalVariable.DateDeTravail

        Dim MONTANT_DEBIT As Double = RECETTE_A_TRANSFERER

        Dim LIBELLE As String = "RAPPORT DE SORTIE DES FONDS  " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " ( " & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] / " & infoSup

        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR") 'CODE_DU CAISSIER

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim caisseSql As New Caisse()

        Dim CODE_CAISSE As String = GunaTextBoxCodePetiteCaisse.Text

        caisseSql.insertPetiteCaisseLigneSynthese(LIBELLE, DATE_SYNTHESE, MONTANT_DEBIT, CODE_SYNTHESE, CODE_CAISSE, CODE_UTILISATEUR, CODE_AGENCE)

    End Sub


    Public Sub traitementDeRecettePourTransfertVersLaCaissePrincipale(ByVal RECETTE_A_TRANSFERER As Double, ByVal CODE_FACTURE As String)

        '1- GENERATION DE LA LIGNE DE TRANSACTION QUI SERA VISIBLE AU NIVEAU DE LA CAISSE PRINCIPALE SOUS FORME DE FACTURE

        'Variables for filling the facturation data
        Dim infoSup As String = ""

        Dim CODE_MODE_PAIEMENT As String = ""

        'ON SELECTIONNE LES PETITES CAISSES

        Dim caisse As DataTable = Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "utilisateur_caisse", "CODE_UTILISATEUR")

        If caisse.Rows.Count > 0 Then

            Dim PetiteCaisse As DataTable = Functions.getElementByCode(caisse.Rows(0)("CODE_CAISSE"), "petite_caisse", "CODE_CAISSE")

            If PetiteCaisse.Rows.Count > 0 Then
                infoSup = " [ " & PetiteCaisse.Rows(0)("LIBELLE_CAISSE") & " ] "
                CODE_MODE_PAIEMENT = caisse.Rows(0)("CODE_CAISSE")
            End If

        End If

        Dim CODE_RESERVATION As String = ""
        Dim CODE_CLIENT As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim NOM_CLIENT_FACTURE As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        Dim CODE_COMMANDE As String = "DEMANDE DE DECAISSEMENT"
        Dim NUMERO_TABLE As String = ""

        Dim NUM_MOUVEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("transfert_recette", "")
        Dim DATE_FACTURE As Date = GlobalVariable.DateDeTravail

        Dim CODE_COMMERCIAL As String = ""

        Dim MONTANT_HT As Double = RECETTE_A_TRANSFERER
        Dim TAXE As Double = 0
        Dim MONTANT_TTC As Double = RECETTE_A_TRANSFERER
        Dim AVANCE As Double = 0
        Dim RESTE_A_PAYER As Double = RECETTE_A_TRANSFERER * -1
        Dim DATE_PAIEMENT As Date
        Dim ETAT_FACTURE As String = 0
        Dim LIBELLE_FACTURE As String = "DEMANDE DE REMBOURSEMENT PAR  " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " ( " & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] / " & infoSup
        Dim MONTANT_TRANSPORT As Double = 0
        Dim MONTANT_REMISE As Double = 0
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR") 'CODE_DU CAISSIER
        Dim CODE_UTILISATEUR_ANNULE As String = ""
        Dim CODE_UTILISATEUR_VALIDE As String = ""

        Dim MONTANT_AVANCE As Double = 0
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim facture As New Facture()

        If facture.insertTransfertRecette(CODE_FACTURE, CODE_RESERVATION, CODE_COMMANDE, NUMERO_TABLE, CODE_MODE_PAIEMENT, NUM_MOUVEMENT, DATE_FACTURE, CODE_CLIENT, CODE_COMMERCIAL, MONTANT_HT, TAXE, MONTANT_TTC, AVANCE, RESTE_A_PAYER, DATE_PAIEMENT, ETAT_FACTURE, LIBELLE_FACTURE, MONTANT_TRANSPORT, MONTANT_REMISE, CODE_UTILISATEUR_CREA, CODE_UTILISATEUR_ANNULE, CODE_UTILISATEUR_VALIDE, NOM_CLIENT_FACTURE, MONTANT_AVANCE, CODE_AGENCE) Then

        End If

        '2- INSERTATION DU MONTANT DES COUPURES

    End Sub

    Private Sub GunaButtonImprimerListeDesComptes_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerListeDesComptes.Click

        Dim motif As String = GunaTextBoxMotif.Text
        Dim nature = ""
        Dim typeOperation As Integer
        Dim montant As Double = GunaTextBoxMontantVerse.Text

        If GunaComboBoxNatureMovt.SelectedItem = "ENTREE DE FONDS" Then
            nature = "BON D'ENTREE EN CAISSE"
            typeOperation = 1
        ElseIf GunaComboBoxNatureMovt.SelectedItem = "SORTIE DE FONDS" Then
            nature = "BON DE SORTIE DE CAISSE"
            typeOperation = 2
        ElseIf GunaComboBoxNatureMovt.SelectedItem = "DEMANDE DE FONDS" Then
            nature = "FICHE DE DEMANDE DE FONDS"
            typeOperation = 3
        End If

        Impression.Bons(motif, nature, typeOperation, montant)

    End Sub

    Private Sub GunaCheckBoxTiers_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTiers.CheckedChanged

        If GunaCheckBoxTiers.Checked Then

            'LES FOURNISSEURS NE SONT VISIBLE QUE SI ON TRAITE LES SORTIE DE FONDS
            If GunaComboBoxNatureMovt.SelectedIndex >= 0 Then
                If GunaComboBoxNatureMovt.SelectedIndex = 1 Then
                    GunaPanelTiers.Visible = True
                End If
            End If

            PanelServiceDemandeur.Visible = False
        Else

            'EN CAS DE TRAITEMENT DES ENTREES DE FONDS LE SERVICE DEMANDEUR EST CELUI DE LA PERSONNE ACTUELLEMENT CONNECTEE
            If GunaComboBoxNatureMovt.SelectedIndex = 1 Then
                GunaComboBoxProfilUtilisateur.SelectedValue = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
            End If

            GunaPanelTiers.Visible = False
            PanelServiceDemandeur.Visible = True

        End If

    End Sub

    Private Sub GunaTextBoxMotif_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMotif.TextChanged

        If Trim(GunaTextBoxMotif.Text).Equals("") Then
            GunaTextBoxReference.Text = ""
        Else
            GunaTextBoxReference.Text = GunaTextBoxMotif.Text & " (" & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " - " & Now() & ")"
        End If

    End Sub

    Public Sub AffichageDesLigneDePetitesCaisse(ByVal ETAT As Integer)

        Dim CODE_CAISSE As String = GunaTextBoxCodePetiteCaisse.Text

        'AFFICHAGE DES LIGNES DONT L'ETAT ET LA NATURE DE L'OPERATION CORRESPONDANT EXCEPTION DEMANDE DE FONDS

        Dim NATURE_OPERATION As Integer = GunaComboBoxNatureMovt.SelectedIndex

        If GunaComboBoxNatureMovt.SelectedIndex >= 0 Then

            'QUAND ON VEUT FAIRE UNE DEMANDE DE FONDS ON DOIT AFFICHER LES SORTIES NON CLOTURE CAR ELLE DETERMINE LE MONTANT DE LA DEMANDE
            'LORSQUE NOUS NE TRAITONS PAS LE PREMIER APPROVISIONNEMENT DE LA PETITE CAISSE
            If GunaComboBoxNatureMovt.SelectedIndex = 2 Then
                NATURE_OPERATION = 1
            End If

        End If

        'LES LIGNES DES TABS A AFFICHER

        listeDesMouvementsDeFonds(ETAT, NATURE_OPERATION)

        ETAT = 2
        NATURE_OPERATION = 0
        listeDesMouvementsDeFondsEnAttentes(ETAT, NATURE_OPERATION)

        Dim reglemt As New Reglement()

        reglemt.SituationDePetiteCaisse(LabelDepense, LabelSituationCaisse, CODE_CAISSE)

    End Sub



    'SELECTION DE TOUTES LES LIGNES SORTIES POUR DETERMINER LE MONTANT DE LA DEMANDE 

    Private Sub GunaDataGridViewTransactionPetiteCaisse_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewTransactionPetiteCaisse.CellClick

        If e.RowIndex >= 0 Then

            'ON FAIT LE CALCUL AUTOMATIQUE POUR LES DEMANDES DE FONDS

            If GunaComboBoxNatureMovt.SelectedIndex = 2 Then

                If GunaDataGridViewTransactionPetiteCaisse.Rows.Count > 0 Then

                    Dim montantDuTransfert As Double = 0

                    For Each row As DataGridViewRow In GunaDataGridViewTransactionPetiteCaisse.SelectedRows
                        montantDuTransfert += Trim(row.Cells("MONTANT_RETIRE").Value)
                        GunaDataGridViewTransactionPetiteCaisse.RowsDefaultCellStyle.SelectionBackColor = Color.Indigo
                        GunaDataGridViewTransactionPetiteCaisse.RowsDefaultCellStyle.SelectionForeColor = Color.White
                    Next

                    GunaTextBoxMontantVerse.Text = Format(montantDuTransfert, "#,##0")

                End If

            End If

        End If

    End Sub

    Private Sub GunaButtonHistoriques_Click(sender As Object, e As EventArgs) Handles GunaButtonHistoriques.Click

        SynthesePetiteCaisseForm.Show()
        SynthesePetiteCaisseForm.TopMost = True

    End Sub

    Private Sub GunaDataGridViewRemboursementEnAttente_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRemboursementEnAttente.CellDoubleClick

        If e.RowIndex >= 0 Then

            'ON FAIT LE CALCUL AUTOMATIQUE POUR LES DEMANDES DE FONDS
            'GunaComboBoxNatureMovt.SelectedIndex = 0

            If GunaDataGridViewRemboursementEnAttente.Rows.Count > 0 Then

                Dim montantDuTransfert As Double = 0

                For Each row As DataGridViewRow In GunaDataGridViewRemboursementEnAttente.SelectedRows

                    montantDuTransfert += Trim(row.Cells("MONTANT_DEPOSE").Value)
                    GunaDataGridViewRemboursementEnAttente.RowsDefaultCellStyle.SelectionBackColor = Color.Indigo
                    GunaDataGridViewRemboursementEnAttente.RowsDefaultCellStyle.SelectionForeColor = Color.White
                    GunaTextBoxRefEntreeEnAttntes.Text = row.Cells("REFERENCE").Value.ToString
                    GunaTextBoxCodeRefrence.Text = row.Cells("REFERENCE").Value.ToString
                    GunaTextBoxMotif.Text = row.Cells("DESCRIPTION").Value.ToString

                Next

                GunaTextBoxMontantVerse.Text = Format(montantDuTransfert, "#,##0")

            End If

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        GunaTextBoxRefEntreeEnAttntes.Clear()
        GunaTextBoxMontantVerse.Clear()

        If TabControl1.SelectedIndex = 1 Then

            Dim ETAT As Integer = 2
            Dim NATURE_OPERATION As Integer = 0

            listeDesMouvementsDeFondsEnAttentes(ETAT, NATURE_OPERATION)

            GunaComboBoxNatureMovt.SelectedIndex = 0

            GunaTextBoxMontantVerse.Enabled = False
            GunaTextBoxMontantVerse.BaseColor = Color.LightPink

            GunaDataGridViewTransactionPetiteCaisse.DefaultCellStyle.SelectionBackColor = Color.White

        Else

            GunaDataGridViewRemboursementEnAttente.DefaultCellStyle.SelectionBackColor = Color.White

            GunaTextBoxMontantVerse.Enabled = True
            GunaTextBoxMontantVerse.BaseColor = Color.White

        End If

    End Sub

    Private Sub documentToBeSendUsingBackGroundWorker(ByVal args As ArgumentType)

        If args.action = 0 Then
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        Else

        End If

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker6_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker6.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker7_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker7.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker8_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker8.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker9_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker9.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub backGroundWorkerToCall(ByVal args As ArgumentType)

        If Not BackgroundWorker2.IsBusy Then
            BackgroundWorker2.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker5.IsBusy Then
            BackgroundWorker5.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker6.IsBusy Then
            BackgroundWorker6.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker7.IsBusy Then
            BackgroundWorker7.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker8.IsBusy Then
            BackgroundWorker8.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker9.IsBusy Then
            BackgroundWorker9.RunWorkerAsync(args)
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        indicateurDEtatDeCaisse()

        Timer1.Stop()

    End Sub

End Class