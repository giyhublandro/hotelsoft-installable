Imports MySql.Data.MySqlClient

Public Class RoutageManuelForm

    Structure SituationCaissier

        'Dim dateOperation
        Dim NUMERO_BLOC_NOTE
        Dim MONTANT

    End Structure

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Dim totalFactureGlob As Double = 0
    Dim totalReglementGlo As Double = 0

    Public Sub AutoLoadDesTypesDePaymaster()

        Dim comptePayMaster = "PM"

        Dim query As String = "SELECT `INTITULE`, `NUMERO_COMPTE`, `CODE_CLIENT`, `TOTAL_DEBIT`, `TOTAL_CREDIT`, `SOLDE_COMPTE`, `DATE_CREATION`, `TYPE_DE_COMPTE`, `SENS_DU_SOLDE` FROM `compte` WHERE NUMERO_COMPTE Like '%" & comptePayMaster & "%' ORDER BY NUMERO_COMPTE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxTypeDePayMaster.DataSource = table
            'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
            GunaComboBoxTypeDePayMaster.ValueMember = "NUMERO_COMPTE"
            GunaComboBoxTypeDePayMaster.DisplayMember = "INTITULE"

        End If

    End Sub

    Public Sub AutoLoadDesReservation()

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)


        If (table.Rows.Count > 0) Then

            GunaComboBoxReservationEnCours.DataSource = table
            'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
            GunaComboBoxReservationEnCours.ValueMember = "RESERVATION"
            GunaComboBoxReservationEnCours.DisplayMember = "NOM CLIENT"

        End If

    End Sub

    Private Sub ComparaisonVenteReglement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'GESTION DES PAYMASTER

        AutoLoadDesTypesDePaymaster()

        'GESTION RESERVATIONS

        AutoLoadDesReservation()


    End Sub

    Private Sub RemplissageDuFolioDesVentes()

        Dim caisseGest As New Caisse()

        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

        Dim CODE_CAISSIER As String = ""

        If Not Trim(GlobalVariable.gestionDeCaisseAvantCloture) = "" Then
            'Gestion de cloture de caisse vant cloture de la journee (Nouvelle date de travail)
            CODE_CAISSIER = Trim(GlobalVariable.gestionDeCaisseAvantCloture)
        Else
            CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        End If

        'Dim tableFacture As DataTable = caisseGest.MontantTotalDesVentesDuJourDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        'Facture ou bloc note associe a un utilisateur
        Dim tableFacture As DataTable = caisseGest.BlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tableFacture.Rows.Count) As SituationCaissier

        Dim totalFacture As Double = 0

        If tableFacture.Rows.Count > 0 Then

            For j = 0 To tableFacture.Rows.Count - 1

                toutesLesFactures(j).NUMERO_BLOC_NOTE = tableFacture.Rows(j)("NUMERO_BLOC_NOTE")
                toutesLesFactures(j).MONTANT = tableFacture.Rows(j)("MONTANT_BLOC_NOTE")

                totalFacture += tableFacture.Rows(j)("MONTANT_BLOC_NOTE")

            Next

            totalFactureGlob = totalFacture

        End If

        'Enfin on insere le tout dans notre datagrid
        If (toutesLesFactures.Length > 0) Then

            For i = 0 To toutesLesFactures.Length - 1

                'GunaDataGridViewFolioPaymaster.Rows.Add(toutesLesFactures(i).NUMERO_BLOC_NOTE, Format(toutesLesFactures(i).MONTANT, "#,##0"))

            Next

        End If

        'GESTION DES ELEMENTS DE TRANSFERT VERS LE COMPTE PAYMASTER

    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    'Equilibrer Les caisses

    Private Sub GunaButtonEquilibre_Click(sender As Object, ByVal e As EventArgs) Handles GunaButtonEquilibrer.Click

        'AFFICHAGE DES INFORMATIONS (COMPTES) LIE A UN TYPE DE PAYMASTER

        Dim COMPTE_PAYMASTER As String = Trim(GunaTextBoxCodePaymaster.Text)

        Dim query As String = "SELECT DISTINCT mvt_compte.NUM_COMPTE, `INTITULE`  FROM `mvt_compte` INNER JOIN compte WHERE COMPTE_PAYMASTER=@COMPTE_PAYMASTER AND compte.NUMERO_COMPTE = mvt_compte.NUM_COMPTE ORDER BY NUMERO_COMPTE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@COMPTE_PAYMASTER", MySqlDbType.VarChar).Value = COMPTE_PAYMASTER

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        Dim query1 As String = "SELECT DISTINCT `CODE_CAISSE` AS 'NUM_COMPTE', `LIBELLE_CAISSE` AS 'INTITULE' FROM `caisse` INNER JOIN mvt_compte WHERE COMPTE_PAYMASTER=@COMPTE_PAYMASTER1 AND caisse.CODE_CAISSE = mvt_compte.NUM_COMPTE ORDER BY CODE_CAISSE ASC"

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@COMPTE_PAYMASTER1", MySqlDbType.VarChar).Value = COMPTE_PAYMASTER

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()

        adapter1.Fill(table1)

        table.Merge(table1)

        If (table.Rows.Count > 0) Then

            GunaDataGridViewFolioPaymaster.Rows.Clear()

            For i = 0 To table.Rows.Count - 1

                GunaDataGridViewFolioPaymaster.Rows.Add(table.Rows(i)("NUM_COMPTE"), table.Rows(i)("INTITULE"))

            Next

        Else

            GunaDataGridViewFolioPaymaster.Rows.Clear()

        End If

        '-----------------------------------------------------------------------------------

        'GunaButtonEquilibrer.Visible = False

        'GunaButtonAnnuler.Visible = True

        'Dim blocNoteAConserver(20) As SituationCaissier

        'Dim j = 0

        'For i = 0 To GunaDataGridViewFolioPaymaster.Rows.Count - 2

        'Dim selectedgrid As DataGridViewRow = GunaDataGridViewFolio1.SelectedRows(0)

        'MessageBox.Show(GunaDataGridViewFolio1.Rows(i).Cells(0).Value.ToString(), "Oups")
        'Dim NUMERO_BLOC_NOTE As String = GunaDataGridViewFolioPaymaster.Rows(i).Cells(0).Value.ToString()

        'Suppression des lignes vides
        'If Not Trim(NUMERO_BLOC_NOTE) = "" Then

        'Dim bloc_note_regle As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "reglement", "NUMERO_BLOC_NOTE")


        'If bloc_note_regle.Rows.Count > 0 Then

        'blocNoteAConserver(j).NUMERO_BLOC_NOTE = GunaDataGridViewFolioPaymaster.Rows(i).Cells(0).Value
        'blocNoteAConserver(j).MONTANT = GunaDataGridViewFolioPaymaster.Rows(i).Cells(1).Value

        'j += 1
        'Else



        'End If

        'End If

        'Next

        'GunaDataGridViewFolioPaymaster.Rows.Clear()

        'For k = 0 To j - 1
        'GunaDataGridViewFolioPaymaster.Rows.Add(blocNoteAConserver(k).NUMERO_BLOC_NOTE, blocNoteAConserver(k).MONTANT)
        ' Next

        'Calcul du solde de chaque folio apres basculement
        'CalculDuSoldeDesFoliosApresBasculement()

    End Sub



    'Visualtion des lignes dun bloc note du folio du paymaster


    'TransfertVers Le PaysMaster

    Private Sub GunaComboBoxTypeDePayMaster_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDePayMaster.SelectedIndexChanged, GunaComboBoxPaymasterDeTransfert.SelectedIndexChanged

        If GunaComboBoxTypeDePayMaster.SelectedIndex >= 0 Then
            GunaTextBoxCodePaymaster.Text = Trim(GunaComboBoxTypeDePayMaster.SelectedValue.ToString)
        End If


    End Sub

    Private Sub GunaComboBoxReservationEnCours_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxReservationEnCours.SelectedIndexChanged

        If GunaComboBoxReservationEnCours.SelectedIndex >= 0 Then

            Dim CODE_RESERVATION As String = Trim(GunaComboBoxReservationEnCours.SelectedValue.ToString)

            GunaTextBoxCodeResa.Text = CODE_RESERVATION

            Dim ChambreDeResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

            If ChambreDeResa.Rows.Count > 0 Then

                GunaTextBoxChambreResa.Text = ChambreDeResa.Rows(0)("CHAMBRE_ID")

            End If

        End If

    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeTransfert.SelectedIndexChanged

        If GunaComboBoxTypeDeTransfert.SelectedIndex >= 0 Then

            If Trim(GunaComboBoxTypeDeTransfert.SelectedItem) = "RESERVATION" Then

                Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

                Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)
                command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                If (table.Rows.Count > 0) Then

                    GunaComboBoxPaymasterDeTransfert.DataSource = table
                    'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
                    GunaComboBoxPaymasterDeTransfert.ValueMember = "RESERVATION"
                    GunaComboBoxPaymasterDeTransfert.DisplayMember = "NOM CLIENT"

                End If

            ElseIf Trim(GunaComboBoxTypeDeTransfert.SelectedItem) = "PAYMASTER" Then

                Dim comptePayMaster = "PM"

                Dim query As String = "SELECT `INTITULE`, `NUMERO_COMPTE`, `CODE_CLIENT`, `TOTAL_DEBIT`, `TOTAL_CREDIT`, `SOLDE_COMPTE`, `DATE_CREATION`, `TYPE_DE_COMPTE`, `SENS_DU_SOLDE` FROM `compte` WHERE NUMERO_COMPTE Like '%" & comptePayMaster & "%' ORDER BY NUMERO_COMPTE ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()

                adapter.Fill(table)

                If (table.Rows.Count > 0) Then

                    GunaComboBoxPaymasterDeTransfert.DataSource = table
                    'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
                    GunaComboBoxPaymasterDeTransfert.ValueMember = "NUMERO_COMPTE"
                    GunaComboBoxPaymasterDeTransfert.DisplayMember = "INTITULE"

                End If

            End If

        End If

    End Sub
End Class