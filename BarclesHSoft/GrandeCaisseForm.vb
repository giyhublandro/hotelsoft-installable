Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class GrandeCaisseForm

    'Destinée à contenir l'ensemble des fatures du client pour des mis à jours

    'Dim connect As New DataBaseManipulation()

    Public Sub AutoLoadBanque()

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

            GunaComboBoxBanqueEmet.DataSource = table
            GunaComboBoxBanqueEmet.ValueMember = "CODE_BANQUE"
            GunaComboBoxBanqueEmet.DisplayMember = "NOM_BANQUE"

        Else
            GunaComboBoxBanque.Items.Clear()
            GunaComboBoxBanqueEmettrice.Items.Clear()
        End If

    End Sub

    Dim caisseCommune As Boolean = False

    Private Sub GrandeCaisseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Trim(GlobalVariable.grandeCaisse).Equals("") Then
            caisseCommune = True
        End If

        Dim language As New Languages()
        language.grandeCaisse(GlobalVariable.actualLanguageValue)

        If GlobalVariable.AgenceActuelle.Rows(0)("CONFIG") = 1 Then

            GlobalVariable.config = Functions.allTableFields("config")

            If GlobalVariable.config.Rows.Count > 0 Then

                Dim backColorString As String = GlobalVariable.config.Rows(0)("SCHEME_COLOR")
                Dim backSecondaryColorString As String = GlobalVariable.config.Rows(0)("SCHEME_SECONDARY_COLOR")
                Dim textColorString As String = GlobalVariable.config.Rows(0)("TEXT_PRIMARY_COLOR")
                Dim textSecondaryColorString As String = GlobalVariable.config.Rows(0)("TEXT_SECONDARY_COLOR")

                Dim paramCouleur() As String
                Dim paramSecondaryCouleur() As String
                Dim paramSecondaryTextCouleur() As String
                Dim paramPrimaryTextCouleur() As String

                paramCouleur = Functions.returningColorFromString(backColorString)
                paramSecondaryCouleur = Functions.returningColorFromString(backSecondaryColorString)
                paramSecondaryTextCouleur = Functions.returningColorFromString(textSecondaryColorString)
                paramPrimaryTextCouleur = Functions.returningColorFromString(textColorString)

                If paramCouleur(1).Equals("") Then
                    GunaPanel1.BackColor = Color.FromName(paramCouleur(0))
                    GunaPanel3.BackColor = Color.FromName(paramCouleur(0))
                Else
                    GunaPanel3.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                    GunaPanel1.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                End If

            End If

        End If
        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then
            GunaCheckBoxDateFictive.Visible = True
        Else
            GunaCheckBoxDateFictive.Visible = False
        End If

        AutoLoadBanque()

        GunaComboBoxTypeDeFiltre.SelectedIndex = -1

        GunaImageButtonFermer.Visible = True
        GunaImageButtonFermer.BringToFront()

        GunaTextBoxMontantVerse.Text = 0

        'Setting a value for the paiment mode on load
        GunaComboBoxModeReglement.SelectedIndex = 0

        GunaComboBoxNatureOperation.SelectedIndex = 0

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 0 Then

            PanelSituationCaisse.BackColor = Color.LightGreen
            PanelSortieFonds.BackColor = Color.LightGreen
            GunaButtonOuvertureFermeture.Visible = False

        Else
            indicateurDEtatDeCaisse()
        End If

        TabControl1.SelectedIndex = 0

        rafraichissementDelaFenetre()

    End Sub

    Public Sub GestionOuvertureDeCaisse()

        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

        Dim CODE_CAISSE As String = ""

        Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

        If CAISSE_UTILISATEUR.Rows.Count > 0 Then

            CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

        End If

        Dim ETAT_CAISSE As Integer = 1
        Dim caissier As New Caisse()

        caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

        If GlobalVariable.actualLanguageValue = 1 Then
            MessageBox.Show("Caisse ouverte avec succès", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Cash Register successfully opened", "Cash Register", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Public Sub indicateurDEtatDeCaisse()

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") Then

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim caisse As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If caisse.Rows.Count > 0 Then

                Dim CODE_CAISSE As String = caisse.Rows(0)("CODE_CAISSE")

                If caisse.Rows(0)("ETAT_CAISSE") = 0 Then

                    PanelSituationCaisse.BackColor = Color.Red
                    PanelSortieFonds.BackColor = Color.Red
                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaButtonOuvertureFermeture.Text = "Ouvrir Caisse"
                    Else
                        GunaButtonOuvertureFermeture.Text = "Open Cash Register"
                    End If
                    GunaButtonEnregistrerReglement.Enabled = False

                    LabelSituationCaisse.Text = 0
                    LabelSortiesDeFonds.Text = 0

                Else

                    GunaButtonEnregistrerReglement.Enabled = True

                    PanelSituationCaisse.BackColor = Color.LightGreen
                    PanelSortieFonds.BackColor = Color.LightGreen
                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaButtonOuvertureFermeture.Text = "Fermer Caisse"
                    Else
                        GunaButtonOuvertureFermeture.Text = "Close Cash Register"
                    End If
                    rafraichissementDelaFenetre()

                End If

            End If

        End If

    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Public Sub SituationDeCaisse()

        Dim CODE_CAISSIER_PRINCIPALE As String = ""
        Dim CODE_CAISSIER_CONNECTED As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim TYPE_CAISSE As String = "Caisse principale"

        Dim infoCaisse As DataTable = Functions.getElementByCode(TYPE_CAISSE, "caisse", "TYPE_CAISSE")

        If infoCaisse.Rows.Count = 1 Then
            CODE_CAISSIER_PRINCIPALE = infoCaisse.Rows(0)("CODE_UTILISATEUR")
        End If

        Dim getUserQuery As String = ""

        If Not caisseCommune Then

            'Caisse Unique

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 0 Then
                'LECTURE SEULE
                'getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND CODE_CAISSIER=@CODE_CAISSIER AND MODE_REGLEMENT= @MODE_REGLEMENT  ORDER BY ID_REGLEMENT DESC"
                getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND MODE_REGLEMENT IN ('Espèce','Cash')  ORDER BY ID_REGLEMENT DESC"

            Else
                'LECTURE ET ECRITURE
                getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND CODE_CAISSIER = @CODE_CAISSIER_CONNECTED AND MODE_REGLEMENT IN ('Espèce','Cash') ORDER BY ID_REGLEMENT DESC"
            End If

        Else

            'Caisse Commune

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 0 Then
                'LECTURE SEULE
                'getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND CODE_CAISSIER=@CODE_CAISSIER AND MODE_REGLEMENT= @MODE_REGLEMENT  ORDER BY ID_REGLEMENT DESC"
                getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND MODE_REGLEMENT IN ('Espèce','Cash') ORDER BY ID_REGLEMENT DESC"

            Else
                'LECTURE ET ECRITURE
                getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND MODE_REGLEMENT IN ('Espèce','Cash') ORDER BY ID_REGLEMENT DESC"
            End If

        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER_PRINCIPALE
        command.Parameters.Add("@CODE_CAISSIER_CONNECTED", MySqlDbType.VarChar).Value = CODE_CAISSIER_CONNECTED
        command.Parameters.Add("@IMPRIMER", MySqlDbType.Int64).Value = 3

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        'Dim SituationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)
        Dim SituationDeCaisse As DataTable = dt

        Dim TotalFacture As Double = 0
        Dim SortieDeFonds As Double = 0

        If SituationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To SituationDeCaisse.Rows.Count - 1

                'ON CALCUL LES SORTIES DE FONDS
                If SituationDeCaisse.Rows(i)("MONTANT_VERSE") < 0 Then
                    SortieDeFonds += SituationDeCaisse.Rows(i)("MONTANT_VERSE")
                ElseIf SituationDeCaisse.Rows(i)("MONTANT_VERSE") >= 0 Then
                    TotalFacture += SituationDeCaisse.Rows(i)("MONTANT_VERSE")
                End If

            Next

            Dim situationDeCaisseReelle As Double = 0

            If TotalFacture + SortieDeFonds > 0 Then
                situationDeCaisseReelle = TotalFacture + SortieDeFonds
            End If

            LabelSituationCaisse.Text = Format(situationDeCaisseReelle, "#,##0")
            LabelSortiesDeFonds.Text = Format(SortieDeFonds * -1, "#,##0")

        Else
            LabelSituationCaisse.Text = 0
            LabelSortiesDeFonds.Text = 0
        End If

    End Sub

    'Autocompletion using live search trick (Custom AutoCompletion) ----------------------- CUSTOM AUTOCOMPLETION ----------------------
    Private Sub GunaTextBoxNom_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNom.TextChanged

        If GunaComboBoxTypeDeFiltre.SelectedIndex >= 0 Then

            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim getQuery As String = ""

            'Si l'article n'existe pas alors on efface toute les informations le concernant
            If Trim(GunaTextBoxNom.Text).Equals("") Then
                GunaDataGridViewBonDeCommande.Visible = False
            End If

            'Determining from which table to search for the articles

            getQuery = "SELECT CODE_BORDEREAUX, LIBELLE_BORDEREAUX FROM bordereaux WHERE LIBELLE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxNom.Text) & "%' AND TYPE_BORDEREAUX =@TYPE_BORDEREAUX  AND ETAT_BORDEREAU =@ETAT_BORDEREAU OR CODE_BORDEREAUX LIKE '%" & Trim(GunaTextBoxNom.Text) & "%' AND TYPE_BORDEREAUX =@TYPE_BORDEREAUX  AND ETAT_BORDEREAU =@ETAT_BORDEREAU ORDER BY LIBELLE_BORDEREAUX ASC"

            Dim ETAT_DU_BORDEREAU As Integer = 4

            Dim Command As New MySqlCommand(getQuery, GlobalVariable.connect)
            Command.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = GlobalVariable.bon_cmd
            'On ne sélectionne que les bordereaux de type commande n'ayant pas encore été traitée (réception après commande)
            Command.Parameters.Add("@ETAT_BORDEREAU", MySqlDbType.Int64).Value = ETAT_DU_BORDEREAU
            adapter.SelectCommand = Command
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaDataGridViewBonDeCommande.Visible = True
                GunaDataGridViewBonDeCommande.DataSource = table
            Else
                GunaDataGridViewBonDeCommande.Columns.Clear()
                GunaDataGridViewBonDeCommande.Visible = False
            End If

            If Trim(GunaTextBoxNom.Text = "") Then
                GunaDataGridViewBonDeCommande.Visible = False
            End If

        End If

    End Sub

    Structure SituationClient

        Dim REFERENCE
        Dim DATE_OPERATION
        Dim NATURE
        Dim LIBELLE
        Dim MONTANT
        Dim MONTANT_SOLDE
        Dim SOLDE

    End Structure

    'Retrait de toute les fature liés au client pour regmelent ou encaissement

    Private Sub transactionsEnAttente(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer)

        'ETAT_FACTURE = 0
        '1- DEMANDE DE DECAISSEMENT ECONOMAT
        '2- RECETTE JOURNALIERE TRANSFEREE OK

        'Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT FROM transfert_recette WHERE ETAT_FACTURE = @ETAT_FACTURE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY DATE_FACTURE DESC"

        Dim query2 As String = "SELECT ID_FACTURE, CODE_FACTURE As REFERENCE, DATE_FACTURE as DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, CODE_COMMANDE FROM transfert_recette WHERE ETAT_FACTURE = @ETAT_FACTURE AND MONTANT_TTC > 0 ORDER BY ID_FACTURE DESC"
        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)

        command2.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
        'command2.Parameters.Add("@CODE_COMMANDE", MySqlDbType.VarChar).Value = NATURE

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationClient

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        GunaDataGridViewRecetteTransactionEnAttente.Rows.Clear()

        For j = 0 To tableFacture.Rows.Count - 1

            'totalFacture = totalFacture + tableFacture.Rows(j)("MONTANT")

            If tableFacture.Rows(j)("CODE_COMMANDE") = "DEMANDE DE DECAISSEMENT" Or tableFacture.Rows(j)("CODE_COMMANDE") = "DISBURSEMENT REQUEST" Then
            Else
                'TRANSFERT DE RECETTE DEPUIS UN POINT DE VENTE
                GunaDataGridViewRecetteTransactionEnAttente.Rows.Add(tableFacture.Rows(j)("ID_FACTURE"), tableFacture.Rows(j)("REFERENCE"), CDate(tableFacture.Rows(j)("DATE")).ToShortDateString, tableFacture.Rows(j)("LIBELLE"), Format(tableFacture.Rows(j)("MONTANT"), "#,##0"))
            End If

            'GunaDataGridViewTransactionEnAttente.Columns("").DefaultCellStyle =

        Next

        GunaDataGridViewRecetteTransactionEnAttente.Sort(GunaDataGridViewRecetteTransactionEnAttente.Columns(0), ListSortDirection.Descending)

    End Sub

    Private Sub decaissementsEnAttente(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer)

        'ETAT_FACTURE = 0
        '1- DEMANDE DE DECAISSEMENT ECONOMAT OK
        '2- RECETTE JOURNALIERE TRANSFEREE 

        'Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT FROM transfert_recette WHERE ETAT_FACTURE = @ETAT_FACTURE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY DATE_FACTURE DESC"

        Dim query2 As String = "SELECT ID_FACTURE, CODE_FACTURE As REFERENCE, DATE_FACTURE as DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, CODE_COMMANDE FROM transfert_recette WHERE ETAT_FACTURE = @ETAT_FACTURE ORDER BY ID_FACTURE DESC"
        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)

        command2.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
        'command2.Parameters.Add("@CODE_COMMANDE", MySqlDbType.VarChar).Value = NATURE

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        GunaDataGridViewDecaissement.Rows.Clear()

        If tableFacture.Rows.Count > 0 Then

            For j = 0 To tableFacture.Rows.Count - 1

                If tableFacture.Rows(j)("CODE_COMMANDE") = "DEMANDE DE DECAISSEMENT" Or tableFacture.Rows(j)("CODE_COMMANDE") = "DISBURSEMENT REQUEST" Then
                    'EN RAPPORT AVEC UN BON DE COMMANDE OU UNE DEMANDE DE REAPPROVISIONNEMENT DE LA PETITE CAISSE
                    GunaDataGridViewDecaissement.Rows.Add(tableFacture.Rows(j)("ID_FACTURE"), tableFacture.Rows(j)("REFERENCE"), CDate(tableFacture.Rows(j)("DATE")).ToShortDateString, tableFacture.Rows(j)("LIBELLE"), Format(tableFacture.Rows(j)("MONTANT"), "#,##0"))
                End If

            Next

        End If

        If Not GunaDataGridViewDecaissement Is Nothing Then

            If GunaDataGridViewDecaissement.Rows.Count > 0 Then
                'GunaDataGridViewDecaissement.Sort(GunaDataGridViewDecaissement.Columns(2), ListSortDirection.Descending)
            End If

        End If

    End Sub

    Private Sub transactionsTraitees(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer)

        '------------------------------------------------------------------- FACTURES ---------------------------------------------------------------------------------------------

        'Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT AVANCE', LETTRAGE  FROM transfert_recette WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE = @ETAT_FACTURE ORDER BY DATE_FACTURE DESC"

        Dim query2 As String = ""

        If Not caisseCommune Then
            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                query2 = "SELECT ID_FACTURE, CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT AVANCE', LETTRAGE, CODE_COMMANDE FROM transfert_recette WHERE ETAT_FACTURE = @ETAT_FACTURE AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA ORDER BY ID_FACTURE DESC"
            Else
                query2 = "SELECT ID_FACTURE, CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT AVANCE', LETTRAGE, CODE_COMMANDE FROM transfert_recette WHERE ETAT_FACTURE = @ETAT_FACTURE  ORDER BY ID_FACTURE DESC"
            End If
        Else
            query2 = "SELECT ID_FACTURE, CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT AVANCE', LETTRAGE, CODE_COMMANDE FROM transfert_recette WHERE ETAT_FACTURE = @ETAT_FACTURE  ORDER BY ID_FACTURE DESC"
        End If

        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)

        command2.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
        command2.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim traitees As New DataTable()

        adapter2.Fill(traitees)

        Dim tailleDuTableau As Integer = traitees.Rows.Count

        'On crée une structure de tableau
        'Dim toutesLesTraitees(tailleDuTableau) As SituationClient

        Dim niemElementDutableau As Integer = 0

        Dim totalTraitees As Double = 0
        Dim totalReglement As Double = 0

        GunaDataGridViewTransactionTerminee.Rows.Clear()

        'Enfin on insere le tout dans notre datagrid

        For k = 0 To traitees.Rows.Count - 1

            totalTraitees += traitees.Rows(k)("MONTANT")

            If traitees.Rows(k)("CODE_COMMANDE") = "DEMANDE DE DECAISSEMENT" Or traitees.Rows(k)("CODE_COMMANDE") = "DISBURSEMENT REQUEST" Then
                GunaDataGridViewTransactionTerminee.Rows.Add(traitees.Rows(k)("REFERENCE"), CDate(traitees.Rows(k)("DATE")).ToShortDateString, traitees.Rows(k)("LIBELLE"), Format(traitees.Rows(k)("MONTANT"), "#,##0"), "")
            Else
                GunaDataGridViewTransactionTerminee.Rows.Add(traitees.Rows(k)("REFERENCE"), CDate(traitees.Rows(k)("DATE")).ToShortDateString, traitees.Rows(k)("LIBELLE"), "", Format(traitees.Rows(k)("MONTANT"), "#,##0"))
            End If

        Next
        '-------------------------------------------------- END FACTURE ----------------------------------------------------------------------

        '----------------------------------------------- REGLEMENT -----------------------------------------------------------

        Dim query3 As String = ""

        'query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE NUMERO_BLOC_NOTE = @NATURE AND DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER = 3 OR NUMERO_BLOC_NOTE = @NATURE_2 AND DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY DATE_REGLEMENT DESC"

        'MODE LECTURE ON DOIT AFFICHER PAR APPORT AU CODE DE L'UTILISATEUR

        If Not caisseCommune Then
            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                query3 = "SELECT ID_REGLEMENT, REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE NUMERO_BLOC_NOTE = @NATURE AND IMPRIMER = 3 AND CODE_CAISSIER=@CODE_CAISSIER OR NUMERO_BLOC_NOTE = @NATURE_2 AND IMPRIMER = 3 AND CODE_CAISSIER=@CODE_CAISSIER ORDER BY ID_REGLEMENT DESC"
            Else
                query3 = "SELECT ID_REGLEMENT, REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE NUMERO_BLOC_NOTE = @NATURE AND IMPRIMER = 3 OR NUMERO_BLOC_NOTE = @NATURE_2 AND IMPRIMER = 3 ORDER BY ID_REGLEMENT DESC"
            End If
        Else
            query3 = "SELECT ID_REGLEMENT, REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE NUMERO_BLOC_NOTE = @NATURE AND IMPRIMER = 3 OR NUMERO_BLOC_NOTE = @NATURE_2 AND IMPRIMER = 3 ORDER BY ID_REGLEMENT DESC"
        End If

        'CODE_MODE = CODE_FACTURE
    

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        If GlobalVariable.actualLanguageValue = 1 Then
            command3.Parameters.Add("@NATURE", MySqlDbType.VarChar).Value = "ENTREE DE FONDS"
            command3.Parameters.Add("@NATURE_2", MySqlDbType.VarChar).Value = "SORTIE DE FONDS"
        Else
            command3.Parameters.Add("@NATURE", MySqlDbType.VarChar).Value = "CASH INFLOW"
            command3.Parameters.Add("@NATURE_2", MySqlDbType.VarChar).Value = "CASH OUTFLOW"
        End If

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        If tableReglement.Rows.Count > 0 Then

            For k = 0 To tableReglement.Rows.Count - 1

                totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                If tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTREE DE FONDS" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "CASH INFLOW" Then
                    GunaDataGridViewTransactionTerminee.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))
                Else
                    GunaDataGridViewTransactionTerminee.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE") * -1, "#,##0"), "")
                End If

            Next

        End If

        '---------------------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub ListeDesFacturesEtReglements(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NATURE As String)

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------
        GunaDataGridViewReglement.Rows.Clear()
        GunaDataGridViewReglement.Visible = True
        GunaDataGridViewDetailsFactures.Visible = False


        Dim totalReglement As Double = 0
        'CODE_MODE = CODE_FACTURE
        'On selectionne l'ensemble des reglement du client n'incluant pas les remboursements
        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE FROM reglement WHERE NUMERO_BLOC_NOTE = @NATURE AND DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER = 0 ORDER BY ID_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        'command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command3.Parameters.Add("@NATURE", MySqlDbType.VarChar).Value = NATURE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        If tableReglement.Rows.Count > 0 Then

            For k = 0 To tableReglement.Rows.Count - 1

                totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                GunaDataGridViewReglement.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), tableReglement.Rows(k)("REF_REGLEMENT"), tableReglement.Rows(k)("MODE_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))

            Next

        End If


        'GunaTextBoxSoldeCompte.Text = Format(Double.Parse(totalReglement), "#,##0")


    End Sub

    'When we double click on a cell of our custom datagrid (client d) used for autocompletion
    Private Sub GunaDataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBonDeCommande.CellClick

        GunaDataGridViewBonDeCommande.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewBonDeCommande.Rows(e.RowIndex)

            Dim CodeClient As String = ""
            Dim numeroCompte As String = ""

            If GunaComboBoxTypeDeFiltre.SelectedItem = "Paymaster" Then

                numeroCompte = row.Cells("NUMERO_COMPTE").Value.ToString

                Dim compte As DataTable = Functions.getElementByCode(numeroCompte, "compte", "NUMERO_COMPTE")

                If compte.Rows.Count > 0 Then

                    GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")

                    GunaTextBoxClientAFacturer.Text = compte.Rows(0)("INTITULE")

                    GunaTextBoxSoldeCompte.Text = Format(compte.Rows(0)("SOLDE_COMPTE"), "#,##0")
                    GunaTextBoxPersonneAContacter.Text = compte.Rows(0)("PERSONNE_A_CONTACTER")
                    GunaTextBoxContactPaiement.Text = compte.Rows(0)("CONTACT_PAIEMENT")
                    GunaTextBoxAdressePaiement.Text = compte.Rows(0)("ADRESSE_DE_FACTURATION")
                    GunaTextBoxDelaiPaiement.Text = compte.Rows(0)("DELAI_DE_PAIEMENT")

                    GunaTextBoxPlafonds.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0")

                    'ListeDesFacturesEtReglementsSuivantUnComptePaymaster(numeroCompte)

                End If

                GunaTextBoxNom.Clear()

            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then

                CodeClient = row.Cells("CODE_CLIENT").Value.ToString

                GunaTextBoxCodeEntreprise.Text = CodeClient

                Dim client As DataTable = Functions.getElementByCode(CodeClient, "client", "CODE_CLIENT")

                If client.Rows.Count > 0 Then

                    GunaTextBoxClientAFacturer.Text = client.Rows(0)("NOM_PRENOM")

                    Dim compte As DataTable = Functions.getElementByCode(Trim(CodeClient), "compte", "CODE_CLIENT")

                    If compte.Rows.Count > 0 Then

                        GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")

                        GunaTextBoxSoldeCompte.Text = Format(compte.Rows(0)("SOLDE_COMPTE"), "#,##0")
                        GunaTextBoxPersonneAContacter.Text = compte.Rows(0)("PERSONNE_A_CONTACTER")
                        GunaTextBoxContactPaiement.Text = compte.Rows(0)("CONTACT_PAIEMENT")
                        GunaTextBoxAdressePaiement.Text = compte.Rows(0)("ADRESSE_DE_FACTURATION")
                        GunaTextBoxDelaiPaiement.Text = compte.Rows(0)("DELAI_DE_PAIEMENT")

                        GunaTextBoxPlafonds.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0")

                    End If

                    GunaTextBoxNom.Clear()

                    'We take all the invoice of the current user for reglement and insert the values of the field of RegelementForm
                    'ListeDesFacturesEtReglements(CodeClient)

                    Dim factures As DataTable = Functions.getElementByCode(CodeClient, "facture", "CODE_CLIENT")

                    If factures.Rows.Count > 0 Then

                        Dim ChiffresAffaire As Double = 0

                        For j = 0 To factures.Rows.Count - 1
                            ChiffresAffaire += factures.Rows(j)("MONTANT_TTC")
                        Next

                        'GunaTextBoxChiffreAffaire.Text = Format(ChiffresAffaire, "#,##0")

                    End If

                    GunaTextBoxAPayer.Text = 0

                    GunaTextBoxSolde.Text = 0

                    GunaTextBoxMontantVerse.Text = 0

                    If GunaComboBoxNatureOperation.SelectedIndex >= 0 Then
                        GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " " & Trim(GunaTextBoxClientAFacturer.Text) & " " & Date.Now().ToShortDateString
                    End If

                End If

            End If

        End If

    End Sub

    Structure SituationFacture

        Dim dateOperation
        Dim libelleOperation
        Dim Debit
        Dim Credit

    End Structure

    Public Sub DetailDeFacture(ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_FACTURE As Date, ByVal CODE_FACTURE As String)

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim infoRecette As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_FACTURE, "transfert_recette", "CODE_FACTURE", CODE_AGENCE, "CODE_AGENCE")

        If infoRecette.Rows.Count > 0 Then

            If Not Trim(infoRecette.Rows(0)("NUMERO_TABLE")) = "" Then

                Dim CODE_BORDEREAU As String = infoRecette.Rows(0)("NUMERO_TABLE") 'CODE DU BON DE COMMANDE

                Dim econom As New Economat()
                'LA LIGNE DE TRANSFERT EST UN DECAISSEMENT ASSOCIE A UN BON DE COMMANDE

                GunaDataGridViewDetailsFactures.Rows.Clear()

                Dim elementDuBordereau As DataTable = econom.ArticleDunBordereauQuelconque(CODE_BORDEREAU, "ligne_bordereaux")

                Dim QUANTITE As Double = 0
                Dim PRIX_ACHAT As Double = 0
                Dim COUT_DU_STOCK As Double = 0
                Dim UNITE As String = 0

                For i = 0 To elementDuBordereau.Rows.Count - 1

                    'Dim CODE_BORDEREAUX As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("UNITE")
                    Dim DESIGNATION As String = elementDuBordereau.Rows(i)("DESIGNATION")
                    'Dim CODE_ARTICLE As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE ARTICLE")

                    If GlobalVariable.actualLanguageValue = 0 Then

                        QUANTITE = elementDuBordereau.Rows(i)("QUANTITY")
                        PRIX_ACHAT = elementDuBordereau.Rows(i)("UNIT PRICE")
                        COUT_DU_STOCK = elementDuBordereau.Rows(i)("TOTAL PRICE")
                        UNITE = elementDuBordereau.Rows(i)("UNIT")

                    Else

                        QUANTITE = elementDuBordereau.Rows(i)("QUANTITE")
                        PRIX_ACHAT = elementDuBordereau.Rows(i)("PRIX UNITAIRE")
                        COUT_DU_STOCK = elementDuBordereau.Rows(i)("PRIX TOTAL")
                        UNITE = elementDuBordereau.Rows(i)("UNITE")

                    End If

                    GunaDataGridViewDetailsFactures.Rows.Add(DESIGNATION, QUANTITE, Format(COUT_DU_STOCK, "#,##0"), UNITE)

                Next

            Else
                'LA LIGNE DE TRANSFERT EST UN APPROVISIONNEMENT DE FONDS ET  N'EST PAS ASSOCIE A UN BON DE COMMANDE

                Dim query As String = "SELECT CODE_FACTURE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC FROM ligne_facture WHERE CODE_UTILISATEUR_CREA = @CODE_UTILISATEUR_CREA AND ETAT_FACTURE = 1 AND DATE_FACTURE >= '" & DATE_FACTURE.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DATE_FACTURE.ToString("yyyy-MM-dd") & "' AND NUMERO_SERIE=@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE ASC"
                If caisseCommune Then
                    query = "SELECT CODE_FACTURE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC FROM ligne_facture WHERE ETAT_FACTURE = 1 AND DATE_FACTURE >= '" & DATE_FACTURE.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DATE_FACTURE.ToString("yyyy-MM-dd") & "' AND NUMERO_SERIE=@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE ASC"
                End If

                Dim command As New MySqlCommand(query, GlobalVariable.connect)
                command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
                command.Parameters.Add("@DATE_FACTURE", MySqlDbType.Date).Value = DATE_FACTURE
                command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

                Dim adapter As New MySqlDataAdapter(command)
                Dim tableFacture As New DataTable()

                adapter.Fill(tableFacture)

                Dim tailleDuTableau As Integer = tableFacture.Rows.Count

                'On crée une structure de tableau
                Dim toutesLesFactures(tailleDuTableau) As SituationFacture

                Dim niemElementDutableau As Integer = 0

                Dim totalFacture As Double = 0

                'Puis dans notre structure on ajoute les factures a la suite des reglements

                For i = 0 To tableFacture.Rows.Count - 1

                    toutesLesFactures(i).dateOperation = CDate(tableFacture.Rows(i)("DATE_FACTURE")).ToShortDateString
                    toutesLesFactures(i).Debit = tableFacture.Rows(i)("MONTANT_TTC")
                    toutesLesFactures(i).Credit = 0
                    toutesLesFactures(i).libelleOperation = tableFacture.Rows(i)("LIBELLE_FACTURE")

                    totalFacture = totalFacture + tableFacture.Rows(i)("MONTANT_TTC")

                Next

                'Enfin on insere le tout dans notre datagrid
                If (toutesLesFactures.Length > 0) Then

                    GunaDataGridViewDetailsFactures.Rows.Clear()

                    For i = 0 To toutesLesFactures.Length - 1

                        If Not toutesLesFactures(i).libelleOperation = "" Then
                            'GunaDataGridViewDetailsFactures.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"))
                        End If

                    Next

                    'Sorting the elements of situation client
                    GunaDataGridViewDetailsFactures.Sort(GunaDataGridViewDetailsFactures.Columns(1), ListSortDirection.Descending)

                End If

                'GunaTextBoxSolde.Text = Format(totalFacture, "#,##0")

                Dim montantAPayer As Double = 0

                'We affect values to the textbox below the datagrid
                'GunaTextBoxAPayer.Text = Format(totalFacture, "#,##0")

                '--------------------------------------------------------------REGLEMENTS-------------------------------------------------------------------------
                'Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, CODE_MODE FROM reglement WHERE CODE_MODE=@CODE_FACTURE AND ETAT = 1 AND DATE_REGLEMENT >= '" & GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd") & "' ORDER BY MODE_REGLEMENT ASC"
                Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, CODE_MODE FROM reglement WHERE CODE_MODE=@CODE_FACTURE AND ETAT = 1 ORDER BY ID_REGLEMENT DESC"

                Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

                command3.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE 'CODE MODE = CODE DE LA FACTURE OU VERSEMENT DE LA RECETTE
                command3.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA

                'command3.Parameters.Add("@CODE_MODE", MySqlDbType.VarChar).Value = CODE_MODE

                Dim adapter3 As New MySqlDataAdapter(command3)
                Dim tableReglement As New DataTable()

                adapter3.Fill(tableReglement)

                Dim tailleDuTableauReg As Integer = tableFacture.Rows.Count

                'On crée une structure de tableau
                Dim toutesLesReg(tailleDuTableauReg) As SituationClient

                Dim niemElementDutableauReg As Integer = 0

                Dim totalReglement As Double = 0

                GunaDataGridViewReglement.Rows.Clear()

                For k = 0 To tableReglement.Rows.Count - 1

                    totalReglement = totalReglement + tableReglement.Rows(k)("MONTANT_VERSE")

                    GunaDataGridViewReglement.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), tableReglement.Rows(k)("REF_REGLEMENT"), tableReglement.Rows(k)("MODE_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))

                Next
                '---------------------------------------------------------------------------------------------------------------------------------------

                GunaTextBoxSolde.Enabled = False
                GunaTextBoxAPayer.Enabled = False

            End If

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
            GunaTextBoxSolde.Text = Format(APayer - montantVerse, "#,##0")
        End If

        If montantVerse > 0 Then
            GunaTextBoxMontantEnChiffre.Text = Functions.NBLT(montantVerse)
            'GunaTextBoxMontantEnChiffre.Text = Functions.NumberToTextEnglish(montantVerse)
        Else
            GunaTextBoxMontantEnChiffre.Clear()
        End If

    End Sub

    'We save the reglement form information
    Private Sub GunaButtonEnregistrerClient_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerReglement.Click


        Dim NUM_COMPTE = GunaTextBoxRefCompte.Text
        Me.Cursor = Cursors.WaitCursor

        GunaButtonBilletage.Visible = False

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 1 Then

            'Même si on a le droit a la caisse on doit encore être associé à une caisse pour pouvoir encaisser

            If Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "caisse", "CODE_UTILISATEUR").Rows.Count > 0 Then

                Dim ETAT_CAISSE As Integer = 0

                Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                Dim CODE_CAISSE As String = ""
                Dim PERMETTRE_ENCAISSEMENT As Boolean = False

                Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")
                Dim TYPE_CAISSE As String = ""

                If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                    ETAT_CAISSE = CAISSE_UTILISATEUR.Rows(0)("ETAT_CAISSE")

                    'MEME SI LE BOUTON D'ENCAISSEMENT EST VISIBLE ON DOIT ENCAISSER SSI ON A UNE CAISSE DE TYPE PRINCIPALE

                    If Trim(CAISSE_UTILISATEUR.Rows(0)("TYPE_CAISSE")).Equals("Caisse principale") Then
                        PERMETTRE_ENCAISSEMENT = True
                    End If

                End If

                If ETAT_CAISSE = 0 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bien vouloir ouvrir votre caisse!!", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Please open your cash register!", "Cash Register", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    GlobalVariable.fenetreDouvervetureDeCaisse = "caissier"

                    passwordVerifivationForm.Show()
                    passwordVerifivationForm.TopMost = True

                Else

                    'ON DOIT AVOIR UNE CAISSE DE TYPE PRINCIPALE AVANT DE POUVOIR EN CAISSER

                    If PERMETTRE_ENCAISSEMENT Then

                        'ON DOIT SE RASSURE QUE LE MONTANT VERSE EST EGAL A CELUI A VERSER

                        If Trim(GunaTextBoxMontantVerse.Text) = "" Then
                            GunaTextBoxMontantVerse.Text = 0
                        End If

                        If Trim(GunaTextBoxAPayer.Text) = "" Then
                            GunaTextBoxAPayer.Text = 0
                        End If

                        Dim montantVerse As Double = Trim(GunaTextBoxMontantVerse.Text)
                        Dim montantAttendu As Double = Trim(GunaTextBoxAPayer.Text)

                        Dim save As Boolean = False

                        'ON DETERMINE SI ON A LE DROIT D'ENREGISTRER LE REGLEMENT

                        If GunaComboBoxNatureOperation.SelectedItem = "ENTREE DE FONDS" Or GunaComboBoxNatureOperation.SelectedItem = "CASH INFLOW" Then
                            'EN CAS D'APROVISIONNEMENT LE MONTANT DOIT ETRE POSITIF
                            If montantVerse > 0 Then
                                save = True
                            End If

                        Else

                            'POUR LES AUTRES CAS ON DOIT ENTRER LE MONTANT EXACT ATTENDU

                            If GunaComboBoxNatureOperation.SelectedItem = "SORTIE DE FONDS" Or GunaComboBoxNatureOperation.SelectedItem = "CASH OUTFLOW" Then

                                'EN CAS DE DECAISSEMENT LA CAISSE DOIT AVOIR UN MONTANT SUFFISANT PERMETTANT LE DECAISSEMENT

                                If Trim(LabelSituationCaisse.Text) = "" Then
                                    LabelSituationCaisse.Text = 0
                                End If

                                'EN CAS DE SORTIE DE FONDS ON DOIT VERIFIER QUE LE SOLDE EST SUFFISAMENT GRAND
                                If montantVerse > Double.Parse(LabelSituationCaisse.Text) Then
                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        MessageBox.Show("Le solde de votre caisse est insuffisant !", "Decaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Else
                                        MessageBox.Show("Your Cash register balance is insufficient !", "Disbursement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If
                                    GunaTextBoxMontantVerse.Clear()
                                Else

                                    If GlobalVariable.decaissemtnAssocie = "remboursement petite caisse" Or GlobalVariable.decaissemtnAssocie = "petty cash reimbursement" Then
                                        'SI C'EST EN RAPPORT AVEC UNE DEMANDE DE DECAISSEMENT PAR APPORT A LA PETITE CAISSE
                                        If montantVerse = montantAttendu Then
                                            save = True
                                        End If

                                    ElseIf GlobalVariable.decaissemtnAssocie = "Bon commande" Then
                                        'SI C'EST EN RAPPORT AVEC UNE DEMANDE DE DECAISSEMENT PAR APPORT A UN BON DE COMMANDE
                                        If montantVerse = montantAttendu Then
                                            save = True
                                        End If

                                    Else
                                        save = True
                                    End If

                                    'SINON 

                                End If

                            Else

                                'EN CAS D'ENTREE DE RECETTE

                                If montantVerse = montantAttendu Then
                                    save = True
                                End If

                            End If

                        End If

                        If save Then

                            Dim CODE_CLIENT As String = ""

                            Dim CODE_RESERVATION As String = Trim(GunaTextBoxCodeReservation.Text)

                            If GunaTextBoxMontantVerse.Text = "" Then
                                GunaTextBoxMontantVerse.Text = 0
                            End If

                            Dim MODE_REG_INFO_SUP_1 As String = ""
                            Dim MODE_REG_INFO_SUP_2 As String = ""
                            Dim MODE_REG_INFO_SUP_3 As Date = Date.Now().ToShortDateString

                            If GunaComboBoxModeReglement.SelectedIndex = 1 Then
                                MODE_REG_INFO_SUP_1 = GunaComboBoxBanqueEmet.SelectedValue.ToString
                                MODE_REG_INFO_SUP_2 = GunaTextBoxCheque.Text
                            ElseIf GunaComboBoxModeReglement.SelectedIndex = 2 Then
                                MODE_REG_INFO_SUP_1 = MaskedTextBoxNumeroCarte.Text
                                MODE_REG_INFO_SUP_2 = MaskedTextBoxCVV.Text
                                MODE_REG_INFO_SUP_3 = GunaDateTimePickerDateExpiration.Value.ToShortDateString()
                            ElseIf GunaComboBoxModeReglement.SelectedIndex = 3 Then
                                MODE_REG_INFO_SUP_1 = GunaTextBoxEntreprise.Text
                                MODE_REG_INFO_SUP_2 = GunaTextBoxNumeroCompte.Text
                            ElseIf GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then
                                MODE_REG_INFO_SUP_1 = GunaTextBoxContact.Text
                            ElseIf GunaComboBoxModeReglement.SelectedIndex = 6 Then
                                MODE_REG_INFO_SUP_1 = GunaComboBoxAvoir.SelectedValue.ToString
                            End If

                            'If Double.Parse(GunaTextBoxMontantVerse.Text) >= Double.Parse(GunaTextBoxAPayer.Text) Then

                            'SI LE MONTANT VERSE > 0

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

                                Dim NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "")

                                Dim NUM_FACTURE = Trim(GunaTextBoxCodeFacture.Text) 'CODE DE LA FACTURE EN COURS DE REGLEMENT

                                Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                Dim MONTANT_VERSE = Double.Parse(GunaTextBoxMontantVerse.Text)

                                Dim DATE_REGLEMENT = GlobalVariable.DateDeTravail
                                Dim MODE_REGLEMENT = GunaComboBoxModeReglement.SelectedItem
                                Dim MODE_REGLEMENT_INDEX As Integer = GunaComboBoxModeReglement.SelectedIndex
                                Dim REF_REGLEMENT = Trim(GunaTextBoxReference.Text)
                                Dim CODE_MODE = Trim(GunaTextBoxCodeFacture.Text)
                                Dim IMPRIMER = 3
                                Dim CODE_AGENCE = GlobalVariable.codeAgence

                                Dim NUMERO_BLOC_NOTE As String = GunaComboBoxNatureOperation.SelectedItem 'NATURE OPERATION PRINCIPALEMENT POUR RETROUVER LES APPROVISIONNENENT

                                Dim MainForm As New MainWindow()

                                Dim insererDepense As Boolean = False

                                If True Then

                                    Dim messageText As String = ""
                                    Dim CODE_CATEGORY_DEPENSE As String = GunaTextBoxRefCompte.Text 'NUMERO COMPTE EXPLOITATION

                                    If GunaComboBoxNatureOperation.SelectedItem = "SORTIE DE FONDS" Or GunaComboBoxNatureOperation.SelectedItem = "CASH OUTFLOW" Then

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            messageText = "Fonds sortie avec succès !!"
                                        Else
                                            messageText = "Fund successfully released !"
                                        End If

                                        'On ne doit inserer ddans le compte que si on a defini on compte d'exploitation
                                        Dim infoCompte As DataTable = Functions.getElementByCode(CODE_CATEGORY_DEPENSE, "compte_exploitation", "COMPTE")

                                        If infoCompte.Rows.Count > 0 Then
                                            insererDepense = True
                                        End If

                                        '------------------------------- DEMANDE DE REAPPROVISIONNEMENT DE LA PETITE CAISSE -------------------------------------------------

                                        If GlobalVariable.decaissemtnAssocie = "remboursement petite caisse" Or GlobalVariable.decaissemtnAssocie = "petty cash reimbursement" Then

                                            Dim infoSupRecette As DataTable = Functions.getElementByCode(NUM_FACTURE, "transfert_recette", "CODE_FACTURE")

                                            If infoSupRecette.Rows.Count > 0 Then

                                                Dim MONTANT_SORTIE_ As Double = 0
                                                Dim CODE_CAISSIER_ As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                                Dim MONTANT_VERSE_ As Double = MONTANT_VERSE
                                                Dim DATE_REGLEMENT_ As String = GlobalVariable.DateDeTravail
                                                Dim MODE_REGLEMENT_ As String = GunaComboBoxModeReglement.SelectedItem.ToString
                                                Dim REF_REGLEMENT_ As String = "REMBOURSEMENT DE FONDS PAR " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
                                                Dim SERVICE_DEMANDEUR_ As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                                                Dim ETAT_ As Integer = 2
                                                Dim NOM_DU_RECEVEUR_ = infoSupRecette.Rows(0)("NOM_CLIENT_FACTURE")
                                                Dim CNI_RECEVEUR_ = ""

                                                Dim NATURE_OPERATION_ As Integer = 0
                                                Dim APPROUVE_PAR_ As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
                                                Dim MODE_REG_INFO_SUP_1_ As String = ""
                                                Dim MODE_REG_INFO_SUP_2_ As String = ""
                                                Dim MODE_REG_INFO_SUP_3_ = Date.Now().ToShortDateString

                                                Dim CODE_CAISSE_ As String = infoSupRecette.Rows(0)("CODE_MODE_PAIEMENT")

                                                reglement.insertPetiteCaisseLigne(NUM_REGLEMENT, MONTANT_SORTIE_, CODE_CAISSIER_, MONTANT_VERSE_, DATE_REGLEMENT_, MODE_REGLEMENT_, REF_REGLEMENT_, SERVICE_DEMANDEUR_, ETAT_, CODE_AGENCE, NOM_DU_RECEVEUR_, CNI_RECEVEUR_, CODE_CAISSE_, NATURE_OPERATION_, APPROUVE_PAR_, MODE_REG_INFO_SUP_1_, MODE_REG_INFO_SUP_2_, MODE_REG_INFO_SUP_3_)

                                                GlobalVariable.decaissemtnAssocie = ""

                                            End If

                                        End If

                                        '------------------------------------------------------------------------------------------------------------------------------------

                                    ElseIf GunaComboBoxNatureOperation.SelectedItem = "ENTREE DE FONDS" Or GunaComboBoxNatureOperation.SelectedItem = "CASH INFLOW" Then
                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            messageText = "Fonds entré avec succès !!"
                                        Else
                                            messageText = "Fund successfully entered !"
                                        End If
                                    ElseIf GunaComboBoxNatureOperation.SelectedItem = "ENTREE DE RECETTE" Or GunaComboBoxNatureOperation.SelectedItem = "ENTERING REVENUE" Then
                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            messageText = "Recette encaissée avec succès !!"
                                        Else
                                            messageText = "Revenue Successfully cashed!"
                                        End If
                                    End If

                                    If True Then

                                        If GunaComboBoxNatureOperation.SelectedItem = "SORTIE DE FONDS" Or GunaComboBoxNatureOperation.SelectedItem = "CASH OUTFLOW" Then
                                            MONTANT_VERSE *= -1
                                        End If

                                        'ENCAISSEMENT NORMAL klg
                                        reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3, NUM_COMPTE)

                                        Dim depense As New Depense()

                                        'GESTION DE LA CATEGORISATION DES DEPENSES

                                        If insererDepense Then

                                            Dim FAMILLE As String = GunaTextBoxiNTITUTLE.Text 'INTITULE COMPTE EXPLOITATION
                                            Dim SOUS_FAMILLE As String = NUM_REGLEMENT 'CODE DEPENSE
                                            Dim CODE As String = Functions.GeneratingRandomCodePanne("regroupement_depenses", "")
                                            Dim LIBELLE As String = REF_REGLEMENT
                                            Dim MONTANT As Double = MONTANT_VERSE * -1

                                            depense.insertCategorieDepense(CODE_CATEGORY_DEPENSE, FAMILLE, SOUS_FAMILLE, CODE, LIBELLE, MONTANT, CODE_AGENCE, GlobalVariable.DateDeTravail)

                                            GunaTextBoxRefCompte.Clear()

                                        End If

                                        Dim Cashier As New Caisse()

                                        Dim ETAT As Integer = 3

                                        reglement.UpdateEtatReglementPourClientComptoire(NUM_REGLEMENT, ETAT)
                                        'MISE A JOUR DE LA CAISSE DE LA CAISSIERE

                                        ' Cashier.updateSoldeCaisse(CODE_CAISSIER, MONTANT_VERSE)

                                        If GlobalVariable.actualLanguageValue = 1 Then
                                            MessageBox.Show(messageText, "Caise Principale ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Else
                                            MessageBox.Show(messageText, "Main Cash Register ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If

                                    End If

                                    'INSERTION DE INFORMATIONS POUR LES REGLEMENTS ASSOCIES AUX BANQUES
                                    If GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 7 Then

                                        Dim banque As New Banque()
                                        Dim CODE_BANQUE As String = ""

                                        If MODE_REGLEMENT_INDEX = 1 Then

                                            If GunaComboBoxBanqueEmettrice.SelectedIndex >= 0 Then
                                                CODE_BANQUE = GunaComboBoxBanqueEmettrice.SelectedValue.ToString
                                            End If

                                        End If

                                        If MODE_REGLEMENT_INDEX = 2 Then

                                            If GunaComboBoxBanque.SelectedIndex >= 0 Then
                                                CODE_BANQUE = GunaComboBoxBanque.SelectedValue.ToString
                                            End If

                                        End If

                                        Dim MODE_REGELEMENT As String = GunaComboBoxModeReglement.SelectedItem
                                        Dim CODE_REGLEMENT As String = NUM_REGLEMENT
                                        Dim DEBIT As Double = 0
                                        Dim CREDIT As Double = GunaTextBoxMontantVerse.Text
                                        Dim CODE_TRANSCATION As String = Functions.GeneratingRandomCodePanne("banque_transaction", "")

                                        'INFORMATION SUPLLEMTAIRE LIEES A LA CARTE DE CREDIT
                                        banque.insertBanqueTransactions(CODE_BANQUE, MODE_REGELEMENT, CODE_REGLEMENT, DEBIT, CREDIT, CODE_AGENCE, CODE_TRANSCATION)

                                    End If

                                    'Mise a jours du solde de la caisse du caissier actuellement connecté en plus
                                    'caisse.updateSoldeCaisse(CODE_CAISSIER, MONTANT_VERSE)

                                    'MISE A JOURS DU COMPTE DU CLIENT SI RATTACHE A UNE ENTREPRISE

                                    Dim compte As New Compte()

                                    Dim compteEntreprise As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                                    If compteEntreprise.Rows.Count > 0 Then

                                        Dim NUMERO_COMPTE As String = compteEntreprise.Rows(0)("NUMERO_COMPTE")

                                        Dim TOTAL_DEBIT As Double = 0
                                        Dim TOTAL_CREDIT As Double = 0

                                        If GunaComboBoxModeReglement.SelectedIndex = 0 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 3 Or GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then

                                            TOTAL_CREDIT = Double.Parse(GunaTextBoxMontantVerse.Text)

                                        End If

                                        'MISE AJOURS DU COMPTE DE L'ENTREPRISE
                                        compte.updateCompteAlaClotureDuFolio(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT)

                                    Else

                                        Dim NUMERO_COMPTE As String = GunaTextBoxCompteDebiteur.Text

                                        Dim TOTAL_DEBIT As Double = 0
                                        Dim TOTAL_CREDIT As Double = 0

                                        If GunaComboBoxModeReglement.SelectedIndex = 0 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 3 Or GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then

                                            TOTAL_CREDIT = Double.Parse(GunaTextBoxMontantVerse.Text)

                                        End If

                                        If GunaComboBoxTypeDeFiltre.SelectedItem = "Paymaster" Then
                                            compte.updateCompteApresTrasnfert(NUMERO_COMPTE, TOTAL_DEBIT, TOTAL_CREDIT)
                                        Else
                                            compte.updateCompteAlaClotureDuFolio(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT)
                                        End If

                                    End If

                                    GunaTextBoxMontantVerse.Text = 0

                                End If

                                If Trim(GunaComboBoxNatureOperation.SelectedItem) = "ENTREE DE RECETTE" Or Trim(GunaComboBoxNatureOperation.SelectedItem) = "SORTIE DE FONDS" Or Trim(GunaComboBoxNatureOperation.SelectedItem) = "ENTERING REVENUE" Or Trim(GunaComboBoxNatureOperation.SelectedItem) = "CASH OUTFLOW" Then

                                    ' ***************************************** REGLEMENTS DE L'ENSEMBLE DES FACTURES SELECTIONNEES 6yeEJKvNRXWoMJSbWe4Gnmck43zLGXLBRCdE6xsD9tZ4

                                    ReglementDesFacturesSelectionnees(montantVerse)

                                End If

                                effacementDesDetails()

                                rafraichissementDelaFenetre()

                                affichages()

                                GlobalVariable.decaissemtnAssocie = ""

                                GunaTextBoxCodeFacture.Clear()

                                GunaTextBoxReferenceRecette.Clear()

                            Else

                                'Montant versé inférieur au montant 

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MessageBox.Show("Bien vouloir saisir un montant correcte !", "Encaissement / Decaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else
                                    MessageBox.Show("Please enter a correct amount !", "Inflow / Outflow", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                                GunaTextBoxMontantVerse.Text = 0

                            End If

                        Else

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Bien vouloir saisir un montant correcte ! ", "Encaissement / Decaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                MessageBox.Show("Please enter a correct amount !", "Inflow / Outflow", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            GunaTextBoxMontantVerse.Text = 0

                        End If

                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Votre caisse ne permet d'effectuer des encaissement !!", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Your cash register does not allow Cash In !!!", "Cash register management", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If

                End If

            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Vous n'avez pas encore de caisse !", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Vous n'avez pas encore de caisse !", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Else
            MessageBox.Show("You don't have a cash register yet !", "Cash register management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If GlobalVariable.actualLanguageValue = 1 Then

            Else

            End If
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Dim changementEffectue As Boolean = False

    'We refresh the content of the Folio Datagrids each time a new reglement is done
    Private Sub ReglementForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        If changementEffectue Then

            effacementDesDetails()

            'If GunaComboBoxTypeDeFiltre.SelectedItem = "Recette" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Recette en Attente" Then
            'Dim NATURE As String = "ENTREE DE RECETTE"
            'Dim ETAT_FACTURE As Integer = 0
            'ListeDesFacturesEtReglements(Trim(GunaTextBoxCodeEntreprise.Text), GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value, ETAT_FACTURE, NATURE)
            'End If

            changementEffectue = False

        End If

    End Sub

    Private Sub GunaTextBoxEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxEntreprise.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxEntreprise.Text).Equals("") Then

            GunaTextBoxEntreprise.Clear()

            GunaDataGridViewCompany.Visible = False

        End If

        GunaDataGridViewCompany.Visible = True

        Dim query As String = "Select NOM_CLIENT From client WHERE NOM_CLIENT Like '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT 
        OR NOM_CLIENT Like '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT_"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "ENTREPRISE"
        command.Parameters.Add("@TYPE_CLIENT_", MySqlDbType.VarChar).Value = "COMPANY"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

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

    Private Sub GunaDataGridViewCompany_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewCompany.CellContentClick

        GunaDataGridViewCompany.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewCompany.Rows(e.RowIndex)
            Dim company As DataTable = Functions.getElementByCode(row.Cells("NOM_CLIENT").Value.ToString, "client", "NOM_CLIENT")

            GunaTextBoxEntreprise.Text = row.Cells("NOM_CLIENT").Value.ToString
            'GunaTextBoxEntreprise.Text = company.Rows(0)("CODE_CLIENT")

            Dim client As DataTable = Functions.getElementByCode(Trim(GunaTextBoxEntreprise.Text), "client", "NOM_PRENOM")
            Dim codeClient As String = client.Rows(0)("CODE_CLIENT")

            Dim compte As DataTable = Functions.getElementByCode(codeClient, "compte", "CODE_CLIENT")

            If compte.Rows.Count > 0 Then
                GunaTextBoxNumeroCompte.Text = compte.Rows(0)("CODE_CLIENT")
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaTextBoxNumeroCompte.Text = "Pas de Compte"
                Else
                    GunaTextBoxNumeroCompte.Text = "No Account"
                End If
            End If

            GunaDataGridViewCompany.Visible = False

            'connect.closeConnection()

        End If

    End Sub

    Private Sub GunaComboBoxModereglement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxModeReglement.SelectedIndexChanged

        If GunaComboBoxModeReglement.SelectedIndex = 2 Then

            GunaPanelSupplementCarte.Visible = True
            LabelDateExpiration.Visible = True
            LabelNumCarte.Visible = True
            LabelCVV.Visible = True
            GunaComboBoxBanque.Visible = True
            Label14.Visible = True
            GunaPanelSupplementCarte.BringToFront()

        Else

            GunaPanelSupplementCarte.Visible = False
            LabelDateExpiration.Visible = False
            LabelNumCarte.Visible = False
            LabelCVV.Visible = False
            GunaComboBoxBanque.Visible = False
            Label14.Visible = False

        End If

        If GunaComboBoxModeReglement.SelectedIndex = 1 Then
            GunaPanelSupplementCheque.Visible = True
            LabelBanqueEmettrice.Visible = True
            LabelNumCompte.Visible = True
            GunaComboBoxBanqueEmet.Visible = True
            GunaPanelSupplementCheque.BringToFront()
        Else
            GunaPanelSupplementCheque.Visible = False
            LabelBanqueEmettrice.Visible = False
            LabelNumCompte.Visible = False
            GunaComboBoxBanqueEmet.Visible = False

        End If


        If GunaComboBoxModeReglement.SelectedIndex = 3 Then
            LabelEntreprise.Visible = True
            GunaTextBoxEntreprise.Visible = True
            LabelNumeroCompte.Visible = True
            GunaTextBoxNumeroCompte.Visible = True

        Else
            LabelEntreprise.Visible = False
            GunaTextBoxEntreprise.Visible = False
            GunaTextBoxNumeroCompte.Visible = False
            LabelNumeroCompte.Visible = False

        End If

        If GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then
            LabelContact.Visible = True
            GunaTextBoxContact.Visible = True
        Else
            LabelContact.Visible = False
            GunaTextBoxContact.Visible = False
        End If

        GunaTextBoxMontantVerse.Text = 0

        If GunaComboBoxModeReglement.SelectedIndex = 6 Then

            GunaComboBoxNatureOperation.SelectedItem = "REGLEMENT"

            Dim CODE_ENTREPRISE As String = Trim(GunaTextBoxCodeEntreprise.Text)

            AutoLoadDesAvoir(CODE_ENTREPRISE)

            'Label1Avoir.BringToFront()
            'GunaComboBoxAvoir.BringToFront()

            Label1Avoir.Visible = True
            GunaTextBoxMontantAvoir.Visible = True
            LabelMontant.Visible = True

            GunaComboBoxAvoir.Visible = True

        Else
            Label1Avoir.Visible = False
            GunaComboBoxAvoir.Visible = False
            GunaTextBoxMontantAvoir.Visible = False
            LabelMontant.Visible = False

            GunaTextBoxCodeDeLAvoir.Clear()

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

    Private Sub GunaImageButtonReduce_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButtonFermer_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    'NATURE DE L'OPERATION EN COURS
    Private Sub GunaComboBoxNatureOperation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNatureOperation.SelectedIndexChanged

        GunaTextBoxAPayer.Text = 0

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                GunaButtonEnregistrerReglement.Enabled = True
            Else
                GunaButtonEnregistrerReglement.Enabled = False
            End If

        End If

        If GunaComboBoxNatureOperation.SelectedItem = "SORTIE DE FONDS" Or GunaComboBoxNatureOperation.SelectedItem = "CASH OUTFLOW" Then

            'NE DOIT APPARAITRE QUE LORSQU'ON SOUAHITE EFFECTUER DES DEPENSES A PROPREMENT PARLER

            If Not Trim(GlobalVariable.decaissemtnAssocie) = "" Or Trim(GunaTextBoxReferenceRecette.Text) = "" Then

                GlobalVariable.categorisationDeDepense = ""
                ' Me.TopMost = False
                'GestionDesDepensesForm.Show()
                'GestionDesDepensesForm.TopMost = True

                GunaPanelGestionDePense.Visible = True

            End If

        Else
            GunaPanelGestionDePense.Visible = False
        End If

        If GunaComboBoxNatureOperation.SelectedIndex >= 0 Then
            GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " [ " & GunaComboBoxModeReglement.SelectedItem & " ] " & Trim(GunaTextBoxClientAFacturer.Text) & " " & Date.Now().ToShortDateString
        End If

    End Sub

    'VISUALISATION DES DETAILS D'UNE FACTUE QUELCONQUE

    Private Sub GunaDataGridViewListeFacture_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewTransactionTerminee.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewTransactionTerminee.Rows(e.RowIndex)

            Dim CODE_FACTURE As String = row.Cells("REFERENCE").Value.ToString

            Dim REGLEMENT As Double = 0

            If Not Trim(row.Cells("MONTANT_SOLDE").Value.ToString) = "" Then
                REGLEMENT = row.Cells("MONTANT_SOLDE").Value
            End If

            Dim A_ENCAISSER = row.Cells("MONTANT").Value

            If REGLEMENT = 0 Then
                GunaButtonEnregistrerReglement.Enabled = True
            Else
                GunaButtonEnregistrerReglement.Enabled = False
            End If

            'GunaTextBoxCodeReservation.Text = CODE_FACTURE ' USED FOR CODE FACTURE
            GunaTextBoxCodeFacture.Text = CODE_FACTURE ' USED FOR CODE FACTURE

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            Dim infoRecette As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_FACTURE, "transfert_recette", "CODE_FACTURE", CODE_AGENCE, "CODE_AGENCE")

            If infoRecette.Rows.Count > 0 Then

                Dim CODE_UTILISATEUR_CREA As String = infoRecette.Rows(0)("CODE_UTILISATEUR_CREA")
                Dim DATE_FACTURE As Date = infoRecette.Rows(0)("DATE_FACTURE")

                GunaTextBoxAPayer.Text = A_ENCAISSER

                'AFFICHER LES DETAILS DE REGLEMENTS SI ON TRAITE LES RECETTES, LES LIGNES DE COMMANDE SI ON TRAITE UN BON DE COMMANDE
                DetailDeFacture(CODE_UTILISATEUR_CREA, DATE_FACTURE, CODE_FACTURE)

                If infoRecette.Rows(0)("CODE_COMMANDE") = "ENTREE DE RECETTE" Or infoRecette.Rows(0)("CODE_COMMANDE") = "ENTERING REVENUE" Then
                    'ON DOIT AFFICHER LES LIGNES DE REGELEMENTS
                    GunaDataGridViewDetailsFactures.Visible = False
                    GunaDataGridViewReglement.Visible = True

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaComboBoxNatureOperation.SelectedItem = "ENTREE DE RECETTE"
                    Else
                        GunaComboBoxNatureOperation.SelectedItem = "ENTERING REVENUE"
                    End If

                    GlobalVariable.billetageAPartirDe = "caisse"

                    Dim REFERENCE_TRANSACTION As String = CODE_FACTURE
                    GunaTextBoxReferenceRecette.Text = CODE_FACTURE

                    Dim coupure As DataTable = Functions.getElementByCode(REFERENCE_TRANSACTION, "transfert_recette_coupures", "REFERENCE_TRANSACTION")

                    If coupure.Rows.Count > 0 Then
                        GunaButtonBilletage.Visible = True
                    Else
                        GunaButtonBilletage.Visible = False
                    End If

                ElseIf infoRecette.Rows(0)("CODE_COMMANDE") = "DEMANDE DE DECAISSEMENT" Or infoRecette.Rows(0)("CODE_COMMANDE") = "DISBURSEMENT REQUEST" Then

                    If Trim(infoRecette.Rows(0)("NUMERO_TABLE")) = "" Then
                        'LE DECAISSEMENT N'EST PAS ASSOCIE A UN BON DE COMMANDE (1- DEMANDE DE REAPPROVISIONNEMENT DE PETITE CAISSE)
                        GunaDataGridViewDetailsFactures.Visible = False
                        GunaDataGridViewReglement.Visible = False
                    Else
                        'LE DECAISSEMENT EST ASSOCIE A UN BON DE COMMANDE
                        GunaDataGridViewDetailsFactures.Visible = True
                        GunaDataGridViewReglement.Visible = False
                    End If

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaComboBoxNatureOperation.SelectedItem = "SORTIE DE FONDS"
                    Else
                        GunaComboBoxNatureOperation.SelectedItem = "CASH OUTFLOW"
                    End If

                End If

                GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " " & Trim(GunaTextBoxClientAFacturer.Text) & " " & Date.Now().ToShortDateString & " [ " & CODE_FACTURE & " ] "

                afficherButtonEnregistrement(CODE_FACTURE)

            End If

        End If

    End Sub

    Public Sub afficherButtonEnregistrement(ByVal CODE_FACTURE As String)

        'ON NE DOIT PAS AFFICHER LE BOUTON D'ENREGISTREMENT SI ON A PAS LE DROIT D'ECRITURE

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 0 Then
            GunaButtonEnregistrerReglement.Visible = False
        Else

            Dim facture As DataTable = Functions.getElementByCode(Trim(CODE_FACTURE), "transfert_recette", "CODE_FACTURE")

            If facture.Rows.Count > 0 Then
                'SI DEJA REGLE
                If facture.Rows(0)("RESTE_A_PAYER") = 0 Then
                    GunaButtonEnregistrerReglement.Visible = False
                Else
                    GunaButtonEnregistrerReglement.Visible = True
                End If
            Else
                'SI ON A PAS DEJA FAIT UN DOUBLE CLICK SUR LA RECETTE ATRAITER
                GunaButtonEnregistrerReglement.Visible = False
            End If

        End If

    End Sub

    Private Sub effacementDesDetails()

        GunaDataGridViewDetailsFactures.Rows.Clear()
        GunaDataGridViewReglement.Rows.Clear()

        GunaTextBoxCodeFacture.Clear()

        GunaTextBoxAPayer.Text = 0
        GunaTextBoxMontantVerse.Text = 0
        GunaTextBoxSolde.Text = 0

        GunaTextBoxReference.Clear()

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaComboBoxNatureOperation.SelectedItem = "AVOIR"
        Else
            GunaComboBoxNatureOperation.SelectedItem = "CREDIT NOTE"
        End If

        GunaComboBoxModeReglement.SelectedIndex = 0

        GunaTextBoxCodeFacture.Clear()

    End Sub

    'EFFACEMENT DU DATAGRID DES DETAILS
    Private Sub GunaButtonEffacerDetail_Click(sender As Object, e As EventArgs) Handles GunaButtonEffacerDetail.Click

        effacementDesDetails()

        GunaTextBoxReference.Clear()

    End Sub

    Public Sub AutoLoadDesAvoir(ByVal CODE_ENTREPRISE As String)

        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT) FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 1 AND CODE_MODE = @CODE_MODE AND MONTANT_VERSE > 0 ORDER BY ID_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim CODE_MODE As String = "AVOIR"

        If GlobalVariable.actualLanguageValue = 1 Then
            CODE_MODE = "CREDIT NOTE"
        End If

        command3.Parameters.Add("@CODE_MODE", MySqlDbType.VarChar).Value = CODE_MODE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        If (tableReglement.Rows.Count > 0) Then

            GunaComboBoxAvoir.DataSource = tableReglement
            'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
            GunaComboBoxAvoir.ValueMember = "NUM_REGLEMENT"
            GunaComboBoxAvoir.DisplayMember = "REF_REGLEMENT"

        End If

    End Sub

    Private Sub GunaComboBoxAvoir_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxAvoir.SelectedIndexChanged

        If GunaComboBoxAvoir.SelectedIndex >= 0 Then

            Dim Avoir As DataTable = Functions.getElementByCode(GunaComboBoxAvoir.SelectedValue.ToString, "reglement", "NUM_REGLEMENT")

            If Avoir.Rows.Count > 0 Then

                'ON UTILISE QUE LES AVOIR A VALEUR NEGATIVE POUR REGLER
                If Avoir.Rows(0)("MONTANT_VERSE") > 0 Then

                    'POUR CHAQUE AVOIR ON DOIT DETERMINER SI IL A DEJA ETE UTILISE POUR REGLER DES FACTURES
                    ' SI OUI
                    '1- ON DOIT RECUPERER TOUTS LES AVOIR A VALEUR NEGATIVE ASSOCIER A LA VOIR ORIGINAL 
                    '- ON RECHERCHE LES AVOIRS AYANT POUR CODE DE LETTRAGE LE CODE DE L'AVOIR ORIGINAL
                    'A FIN DE DETERMINER LE SOLDE DE L'AVOIR ORIGINAL A UTILISER DONC A AFFICHER
                    Dim CODE_AVOIR_ORIGINAL As String = Avoir.Rows(0)("NUM_REGLEMENT")

                    Dim avoirNegatifDeLAvoirOriginal As DataTable = Functions.getElementByCode(CODE_AVOIR_ORIGINAL, "reglement", "LETTRAGE")

                    If avoirNegatifDeLAvoirOriginal.Rows.Count > 0 Then

                        Dim MONTANT_TOTAL_DEJA_UTILISE As Double = 0

                        For i = 0 To avoirNegatifDeLAvoirOriginal.Rows.Count - 1
                            MONTANT_TOTAL_DEJA_UTILISE += avoirNegatifDeLAvoirOriginal.Rows(i)("MONTANT_VERSE")
                        Next

                        GunaTextBoxMontantAvoir.Text = Format(Avoir.Rows(0)("MONTANT_VERSE") + MONTANT_TOTAL_DEJA_UTILISE, "#,##0")
                        GunaTextBoxMontantVerse.Text = Format(Avoir.Rows(0)("MONTANT_VERSE") + MONTANT_TOTAL_DEJA_UTILISE, "#,##0")

                    Else

                        'SI NON 
                        '1- ON AFFICHE SON MONTANT ORIGINAL

                        GunaTextBoxMontantAvoir.Text = Format(Avoir.Rows(0)("MONTANT_VERSE"), "#,##0")
                        GunaTextBoxMontantVerse.Text = Format(Avoir.Rows(0)("MONTANT_VERSE"), "#,##0")

                    End If

                    GunaTextBoxCodeDeLAvoir.Text = Avoir.Rows(0)("NUM_REGLEMENT")

                End If

            End If

        End If

    End Sub

    'REGLEMENT DE L'ENSEMBLE DES FACTURES SELECTIONNEES

    Structure Facture
        Dim CODE_FACTURE
    End Structure

    Dim ENSEMBLE_DES_FACTURES(10) As Facture

    Private Sub TransférerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransférerToolStripMenuItem.Click

        Dim MONTANT_TOTAL_DES_FACTURES As Double = 0
        Dim CODE_FACTURE As String = ""

        If GunaDataGridViewTransactionTerminee.Rows.Count > 0 Then

            Dim i As Integer = 0

            For Each row As DataGridViewRow In GunaDataGridViewTransactionTerminee.SelectedRows

                CODE_FACTURE = Trim(row.Cells(0).Value.ToString)

                MONTANT_TOTAL_DES_FACTURES += Double.Parse(Trim(row.Cells(7).Value))

                ENSEMBLE_DES_FACTURES(i).CODE_FACTURE = CODE_FACTURE

                i += 1

            Next

            GunaTextBoxAPayer.Text = Format(Math.Abs(MONTANT_TOTAL_DES_FACTURES), "#,##0")

            GunaComboBoxNatureOperation.SelectedItem = "REGLEMENT"

        End If

    End Sub

    Private Sub ReglementDesFacturesSelectionnees(ByVal montantVerse As Double)

        'CETTE PROCEDURE CE CONTENTE DE METTRE A JOURS LES ETATS DES FACTURES (DEBIT, CREDIT, AVANCE, SOLDE)
        'RECUPERATION DU CODE DE REGLEMENT INSERER
        Dim tableName As String = "reglement"
        Dim codeFieldName As String = "NUM_REGLEMENT"

        Dim CODE_REGLEMENT As String = Functions.latInsertedElementCode(tableName, codeFieldName)

        Dim facture As New Facture()

        Dim montantTotalAPayer As Double = 0

        If Trim(GunaTextBoxMontantVerse.Text) = "" Then
            GunaTextBoxMontantVerse.Text = 0
        End If

        Dim factureSelectionnee As DataTable

        'ENSEMBLE DES FACTURES SELECTIONNEES

        'Dim CODE_FACTURE As String = GunaTextBoxCodeReservation.Text 'code facture
        Dim CODE_FACTURE As String = GunaTextBoxCodeFacture.Text 'code facture
        Dim CODE_MODE_PAIEMENT As String = GunaComboBoxModeReglement.SelectedItem
        Dim DATE_PAIEMENT As Date = GlobalVariable.DateDeTravail
        Dim ETAT_FACTURE As String = 1
        Dim MONTANT_AVANCE As Double = 0
        Dim RESTE_A_PAYER As Double = 0

        'montantTotalAPayer += Functions.getElementByCode(CODE_FACTURE, "facture", "CODE_FACTURE").Rows(i)("MONTANT_TTC")
        factureSelectionnee = Functions.getElementByCode(CODE_FACTURE, "transfert_recette", "CODE_FACTURE")

        'TANT QUE LE MONTANT VERSE EST ENCORE SUFFISAMENT GRAND POUR REGLER LES FACTURES


        'ActivationForm.Show()
        'ActivationForm.TopMost = True
        'ActivationForm.GunaTextBoxMessage.Text = CODE_FACTURE


        If factureSelectionnee.Rows.Count > 0 And montantVerse > 0 Then

            Dim MONTANT_FACTURE_ENCOURS As Double = Double.Parse(factureSelectionnee.Rows(0)("MONTANT_TTC"))
            'ON DETERMINE SI LA FACTURE EST DEJA REGLE OU NON
            If Not Double.Parse(factureSelectionnee.Rows(0)("RESTE_A_PAYER")) = 0 Then

                If montantVerse >= MONTANT_FACTURE_ENCOURS Then

                    MONTANT_AVANCE = MONTANT_FACTURE_ENCOURS
                    RESTE_A_PAYER = MONTANT_FACTURE_ENCOURS - MONTANT_AVANCE

                    montantVerse -= MONTANT_AVANCE

                Else

                    MONTANT_AVANCE = montantVerse
                    RESTE_A_PAYER = MONTANT_FACTURE_ENCOURS - MONTANT_AVANCE

                    montantVerse -= MONTANT_AVANCE

                End If

                Dim updateQuery As String = "UPDATE `transfert_recette` SET `CODE_MODE_PAIEMENT`=@CODE_MODE_PAIEMENT, `RESTE_A_PAYER`=@RESTE_A_PAYER, `DATE_PAIEMENT`=@DATE_PAIEMENT, `ETAT_FACTURE`=@ETAT_FACTURE, `MONTANT_AVANCE`=MONTANT_AVANCE + @MONTANT_AVANCE, CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA WHERE CODE_FACTURE=@CODE_FACTURE"

                Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

                command.Parameters.Add("@CODE_MODE_PAIEMENT", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT

                command.Parameters.Add("@RESTE_A_PAYER", MySqlDbType.Double).Value = RESTE_A_PAYER
                command.Parameters.Add("@DATE_PAIEMENT", MySqlDbType.Date).Value = DATE_PAIEMENT
                command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
                command.Parameters.Add("@MONTANT_AVANCE", MySqlDbType.Double).Value = MONTANT_AVANCE

                command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                command.ExecuteNonQuery()

            End If

        End If

        'MISE A JOURS DU LETTRAGE PAR APPORT AU CODE DE REGLEMENT

        'SI ON UTILISE UN AVOIR POUR REGLER :
        '1- ON CREE UN AVOIR A VALEUR NEGATIVE PERMETTANT DE DEDUIRE DE L'AVOIR ORIGINAL 
        '2- LE LETTRAGE DU NOUVELLE AVOIR ET LES FACTURE SERA CELUI DE L'AVOIR ORIGINAL (AVOIR DONT ON DEDUIRA LES MONTANT DE FACTURES)

        'SINON 
        '1- ON CREE UN REGLEMENT DONT SON CODE SERA UTILISE COMME LETTRAGE

        Dim LETTRAGE As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then

            If GunaComboBoxModeReglement.SelectedItem = "Avoir" Then
                LETTRAGE = GunaTextBoxCodeDeLAvoir.Text
            Else
                LETTRAGE = CODE_REGLEMENT ' VALEUR DU LETTRAGE
            End If

        Else

            If GunaComboBoxModeReglement.SelectedItem = "Credit Note" Then
                LETTRAGE = GunaTextBoxCodeDeLAvoir.Text
            Else
                LETTRAGE = CODE_REGLEMENT ' VALEUR DU LETTRAGE
            End If

        End If

        'FACTURE
        Dim TABLE As String = "transfert_recette"
        Dim CONDITION_FIELD_NAME As String = "CODE_FACTURE" ' 
        Dim CONDITION_FIELD_VALUE As String = CODE_FACTURE

        miseAJourDuLettrage(TABLE, LETTRAGE, CONDITION_FIELD_NAME, CONDITION_FIELD_VALUE)

        'REGLEMENT
        TABLE = "reglement"
        CONDITION_FIELD_NAME = "NUM_REGLEMENT" '
        CONDITION_FIELD_VALUE = CODE_REGLEMENT
        miseAJourDuLettrage(TABLE, LETTRAGE, CONDITION_FIELD_NAME, CONDITION_FIELD_VALUE)

    End Sub

    Public Sub miseAJourDuLettrage(ByVal TABLE As String, ByVal LETTRAGE As String, ByVal CONDITION_FIELD_NAME As String, ByVal CONDITION_FIELD_VALUE As String)

        Dim insertQuery As String = "UPDATE " & TABLE & " SET `LETTRAGE`=@LETTRAGE WHERE " & CONDITION_FIELD_NAME & " =@CONDITION_FIELD_VALUE"

        Dim command1 As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command1.Parameters.Add("@CONDITION_FIELD_VALUE", MySqlDbType.VarChar).Value = CONDITION_FIELD_VALUE
        command1.Parameters.Add("@LETTRAGE", MySqlDbType.VarChar).Value = LETTRAGE

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        command1.ExecuteNonQuery()

    End Sub

    Private Sub GunaComboBoxTypeDeFiltre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeFiltre.SelectedIndexChanged

        effacementDesDetails()

        GunaTextBoxReference.Clear()

        Functions.SiplifiedClearTextBox(Me)

        'GunaDataGridViewListeFacture.Rows.Clear()
        GunaDataGridViewReglement.Rows.Clear()

        Dim infoSup As String = ""

        Dim caisse As DataTable = Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "caisse", "CODE_UTILISATEUR")
        If caisse.Rows.Count > 0 Then
            infoSup = " [ " & caisse.Rows(0)("LIBELLE_CAISSE") & " ] "
        End If

        GunaTextBoxCodeFacture.Clear()

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                GunaButtonEnregistrerReglement.Enabled = True
            Else
                GunaButtonEnregistrerReglement.Enabled = False
            End If

        End If

        If GunaComboBoxNatureOperation.SelectedIndex >= 0 Then
            'GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " " & Trim(GunaTextBoxClientAFacturer.Text) & " " & Date.Now().ToShortDateString & " " & infoSup
        End If

    End Sub

    'AFFICHAGE FACTURES SUIVANT UNE PERIODE
    Private Sub GunaButtonAfficherLesFacturesEtReglement_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLesFacturesEtReglement.Click

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
            GunaButtonEnregistrerReglement.Enabled = True
        Else
            GunaButtonEnregistrerReglement.Enabled = False
        End If

        'GunaDataGridViewListeFacture.Rows.Clear()
        Dim NATURE As String = ""

        Dim CODE_CLIENT As String = GunaTextBoxCodeEntreprise.Text

        If GlobalVariable.actualLanguageValue = 1 Then

            If GunaComboBoxTypeDeFiltre.SelectedItem = "ENTREE DE RECETTE" Then
                NATURE = "ENTREE DE RECETTE"
            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "ENTREE DE FONDS" Then
                NATURE = "ENTREE DE FONDS"
            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "SORTIE DE FONDS" Then
                NATURE = "SORTIE DE FONDS" 'ENSEMBLE DES APPROVISIONNEMENT
            End If

        Else

            If GunaComboBoxTypeDeFiltre.SelectedItem = "ENTERING REVENUE" Then
                NATURE = "ENTERING REVENUE"
            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "CASH INFLOW" Then
                NATURE = "CASH INFLOW"
            ElseIf GunaComboBoxTypeDeFiltre.SelectedItem = "CASH OUTFLOW" Then
                NATURE = "CASH OUTFLOW" 'ENSEMBLE DES APPROVISIONNEMENT
            End If

        End If

        ListeDesFacturesEtReglements(GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value, NATURE)

    End Sub

    Private Sub GunaButtonOuvertureFermeture_Click(sender As Object, e As EventArgs) Handles GunaButtonOuvertureFermeture.Click

        If GunaButtonOuvertureFermeture.Text = "Ouvrir Caisse" Or GunaButtonOuvertureFermeture.Text = "Open Cash Register" Then

            GlobalVariable.fenetreDouvervetureDeCaisse = "caissier"

            passwordVerifivationForm.Show()
            passwordVerifivationForm.TopMost = True

        ElseIf GunaButtonOuvertureFermeture.Text = "Fermer Caisse" Or GunaButtonOuvertureFermeture.Text = "Close Cash Register" Then

            Dim ETAT_CAISSE As Integer = 0
            Dim caissier As New Caisse()
            Dim CODE_CAISSE As String = ""

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim infoCaisse As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR", CODE_AGENCE, "CODE_AGENCE")

            If infoCaisse.Rows.Count > 0 Then

                CODE_CAISSE = infoCaisse.Rows(0)("CODE_CAISSE")

                caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                indicateurDEtatDeCaisse()

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show(CODE_CAISSE & " Caisse fermée avec succès !", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(CODE_CAISSE & " Cash register closed successfully!", "Cash register management", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                GunaDataGridViewTransactionTerminee.Rows.Clear()
                GunaTextBoxSoldeCompte.Clear()

            End If

        End If

    End Sub

    Public Sub rafraichissementDelaFenetre()

        'kklg

        'SITUATION DE CAISSE
        SituationDeCaisse()

        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail

        Dim ETAT_FACTURE As Integer = 1
        '---------------------------- OLD WAY ----------------------------------------------------------------------------------------------------
        'listeDesOperationsParNature(DateDebut, DateFin, ETAT_FACTURE)

        'If GunaDataGridViewTransactionTerminee.Rows.Count > 0 Then
        'GunaDataGridViewTransactionTerminee.Sort(GunaDataGridViewTransactionTerminee.Columns(1), ListSortDirection.Descending)
        'End If

        'transactionsTraitees(DateDebut, DateFin, ETAT_FACTURE)
        '-----------------------------------------------------------------------------------------------------------------------------------------
        ETAT_FACTURE = 0

        transactionsEnAttente(DateDebut, DateFin, ETAT_FACTURE)

        GunaComboBoxNatureOperation.SelectedIndex = 0

        '---------------------------- NEW WAY -------------------------

    End Sub

    Private Sub GunaImageButtonFermer_Click_1(sender As Object, e As EventArgs) Handles GunaImageButtonFermer.Click
        Me.Close()
    End Sub

    'TRAITEMENTS DES TRANSACTIONS EN ATTENTES

    Private Sub GunaDataGridViewTransactionEnAttente_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRecetteTransactionEnAttente.CellDoubleClick

        Dim etatDeCaisse As String = GunaButtonOuvertureFermeture.Text
        Dim continuer As Boolean = False
        Dim message As String = ""
        Dim title As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            If etatDeCaisse.Equals("Fermer Caisse") Then
                continuer = True
            Else
                message = "Bien vouloir ouvrir votre caisse !!"
                title = "Gestion de caisse"

            End If
        Else
            If etatDeCaisse.Equals("Close Cash Register") Then
                continuer = True
            Else
                message = "Please open your Cash Register !!"
                title = "Cash Register Management"
            End If

        End If

        If continuer Then
            If e.RowIndex >= 0 Then

                GunaTextBoxMontantVerse.Text = 0
                GunaDataGridViewReglement.Visible = True
                GunaDataGridViewDetailsFactures.Visible = False

                Dim row As DataGridViewRow

                row = Me.GunaDataGridViewRecetteTransactionEnAttente.Rows(e.RowIndex)

                Dim CODE_FACTURE As String = row.Cells("REFERENCE_ATTENTE").Value.ToString
                Dim LIBELLE As String = row.Cells("DataGridViewTextBoxColumn5").Value.ToString
                'Dim REGLEMENT = row.Cells("MONTANT_ATTENTE").Value
                Dim A_ENCAISSER = row.Cells("MONTANT_ATTENTE").Value

                'GunaTextBoxCodeReservation.Text = CODE_FACTURE ' USED FOR CODE FACTURE
                GunaTextBoxCodeFacture.Text = CODE_FACTURE ' USED FOR CODE FACTURE

                Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                Dim infoRecette As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_FACTURE, "transfert_recette", "CODE_FACTURE", CODE_AGENCE, "CODE_AGENCE")

                If infoRecette.Rows.Count > 0 Then

                    Dim CODE_UTILISATEUR_CREA As String = infoRecette.Rows(0)("CODE_UTILISATEUR_CREA")
                    Dim DATE_FACTURE As Date = infoRecette.Rows(0)("DATE_FACTURE")

                    GunaTextBoxAPayer.Text = A_ENCAISSER

                    'AFFICHAGE DES DETAILS (ENSEMBLE DES REGLEMENTS ASSOCIE LA RECETTE)
                    DetailDeFacture(CODE_UTILISATEUR_CREA, DATE_FACTURE, CODE_FACTURE)

                    If infoRecette.Rows(0)("CODE_COMMANDE") = "ENTREE DE RECETTE" Or infoRecette.Rows(0)("CODE_COMMANDE") = "ENTERING REVENUE" Then
                        'ON DOIT AFFICHER LES LIGNES DE REGELEMENTS
                        GunaDataGridViewDetailsFactures.Visible = False
                        GunaDataGridViewReglement.Visible = True

                        If GlobalVariable.actualLanguageValue = 1 Then
                            GunaComboBoxNatureOperation.SelectedItem = "ENTREE DE RECETTE"
                        Else
                            GunaComboBoxNatureOperation.SelectedItem = "ENTERING REVENUE"
                        End If

                        Dim REFERENCE_TRANSACTION As String = CODE_FACTURE

                        GlobalVariable.billetageAPartirDe = "caisse"

                        GunaTextBoxReferenceRecette.Text = CODE_FACTURE

                        Dim coupure As DataTable = Functions.getElementByCode(REFERENCE_TRANSACTION, "transfert_recette_coupures", "REFERENCE_TRANSACTION")

                        If coupure.Rows.Count > 0 Then
                            GunaButtonBilletage.Visible = True
                            'PERMETTRE DE RETROUVER LE BILLETAGE
                        Else
                            GunaButtonBilletage.Visible = False
                        End If

                    ElseIf infoRecette.Rows(0)("CODE_COMMANDE") = "DEMANDE DE DECAISSEMENT" Or infoRecette.Rows(0)("CODE_COMMANDE") = "DISBURSEMENT REQUEST" Then

                        If Trim(infoRecette.Rows(0)("NUMERO_TABLE")) = "" Then 'NUMERO_TABLE : BON_DE_COMMANDE
                            'LE DECAISSEMENT N'EST PAS ASSOCIE A UN BON DE COMMANDE (1- DEMANDE DE REAPPROVISIONNEMENT DE PETITE CAISSE)
                            GunaDataGridViewDetailsFactures.Visible = False
                            GunaDataGridViewReglement.Visible = False

                            'GlobalVariable.decaissemtnAssocie = "Petite caisse"

                        Else
                            'LE DECAISSEMENT EST ASSOCIE A UN BON DE COMMANDE
                            GunaDataGridViewDetailsFactures.Visible = True
                            GunaDataGridViewReglement.Visible = False

                            GlobalVariable.decaissemtnAssocie = "Bon commande"
                            If GlobalVariable.actualLanguageValue = 1 Then

                            Else

                            End If
                        End If

                        If GlobalVariable.actualLanguageValue = 1 Then
                            GunaComboBoxNatureOperation.SelectedItem = "SORTIE DE FONDS"
                        Else
                            GunaComboBoxNatureOperation.SelectedItem = "CASH OUTFLOW"
                        End If

                    End If

                    GunaTextBoxReference.Text = LIBELLE & " [ " & GunaComboBoxNatureOperation.SelectedItem & " " & Trim(GunaTextBoxClientAFacturer.Text) & " " & Date.Now().ToShortDateString & " / " & CODE_FACTURE & " ] "

                    'AFFICHE OU PAS DU BOUTTON 
                    afficherButtonEnregistrement(CODE_FACTURE)

                End If

            End If
        Else

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaButtonImprimerListeDesComptes_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerListeDesComptes.Click

        Dim motif As String = GunaTextBoxReference.Text
        Dim nature = ""
        Dim typeOperation As Integer
        Dim montant As Double = GunaTextBoxMontantVerse.Text

        If GlobalVariable.actualLanguageValue = 1 Then
            If GunaComboBoxNatureOperation.SelectedItem = "ENTREE DE FONDS" Then
                nature = "BON D'ENTREE EN CAISSE"
                typeOperation = 1
            ElseIf GunaComboBoxNatureOperation.SelectedItem = "SORTIE DE FONDS" Then
                nature = "BON DE SORTIE DE CAISSE"
                typeOperation = 2
            End If
        Else
            If GunaComboBoxNatureOperation.SelectedItem = "CASH INFLOW" Then
                nature = "CASH INFLOW SLIP"
                typeOperation = 1
            ElseIf GunaComboBoxNatureOperation.SelectedItem = "CASH OUTFLOW" Then
                nature = "CASH INFLOW SLIP"
                typeOperation = 2
            End If
        End If

        Impression.Bons(motif, nature, typeOperation, montant)

    End Sub

    Private Sub GunaButtonBilletage_Click(sender As Object, e As EventArgs) Handles GunaButtonBilletage.Click

        GlobalVariable.billetageAPartirDe = "caisse"

        Dim REFERENCE_TRANSACTION As String = GunaTextBoxReferenceRecette.Text

        Dim coupure As DataTable = Functions.getElementByCode(REFERENCE_TRANSACTION, "transfert_recette_coupures", "REFERENCE_TRANSACTION")

        If coupure.Rows.Count > 0 Then
            BilletageForm.Show()
            BilletageForm.TopMost = True
        End If

    End Sub

    Private Sub GunaDataGridViewDecaissement_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewDecaissement.CellDoubleClick

        'GESTION DES DECAISSEMENTS

        '1- BON DE COMMANDE
        '2- PETITE CAISSE

        If e.RowIndex >= 0 Then

            GunaDataGridViewReglement.Visible = False
            GunaDataGridViewDetailsFactures.Visible = True

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewDecaissement.Rows(e.RowIndex)

            Dim CODE_FACTURE As String = row.Cells("REFERENCE_ATTENTE_2").Value.ToString
            Dim LIBELLE_FACTURE As String = row.Cells("DataGridViewTextBoxColumn6").Value.ToString
            'Dim REGLEMENT = row.Cells("MONTANT_ATTENTE").Value
            Dim A_ENCAISSER = row.Cells("MONTANT_ATTENTE_2").Value

            'GunaTextBoxCodeReservation.Text = CODE_FACTURE ' USED FOR CODE FACTURE
            GunaTextBoxCodeFacture.Text = CODE_FACTURE ' USED FOR CODE FACTURE

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            Dim infoRecette As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_FACTURE, "transfert_recette", "CODE_FACTURE", CODE_AGENCE, "CODE_AGENCE")

            If infoRecette.Rows.Count > 0 Then

                Dim CODE_UTILISATEUR_CREA As String = infoRecette.Rows(0)("CODE_UTILISATEUR_CREA")
                Dim DATE_FACTURE As Date = infoRecette.Rows(0)("DATE_FACTURE")

                DetailDeFacture(CODE_UTILISATEUR_CREA, DATE_FACTURE, CODE_FACTURE)

                If infoRecette.Rows(0)("CODE_COMMANDE") = "ENTREE DE RECETTE" Or infoRecette.Rows(0)("CODE_COMMANDE") = "ENTERING REVENUE" Then

                    'ON DOIT AFFICHER LES LIGNES DE REGELEMENTS

                    GunaDataGridViewDetailsFactures.Visible = False
                    GunaDataGridViewReglement.Visible = True

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaComboBoxNatureOperation.SelectedItem = "ENTREE DE RECETTE"
                    Else
                        GunaComboBoxNatureOperation.SelectedItem = "ENTERING REVENUE"
                    End If

                    Dim REFERENCE_TRANSACTION As String = CODE_FACTURE

                    GlobalVariable.billetageAPartirDe = "caisse"

                    GunaTextBoxReferenceRecette.Text = CODE_FACTURE

                    Dim coupure As DataTable = Functions.getElementByCode(REFERENCE_TRANSACTION, "transfert_recette_coupures", "REFERENCE_TRANSACTION")

                    If coupure.Rows.Count > 0 Then
                        GunaButtonBilletage.Visible = True
                        'PERMETTRE DE RETROUVER LE BILLETAGE
                    Else
                        GunaButtonBilletage.Visible = False
                    End If

                ElseIf infoRecette.Rows(0)("CODE_COMMANDE") = "DEMANDE DE DECAISSEMENT" Or infoRecette.Rows(0)("CODE_COMMANDE") = "DISBURSEMENT REQUEST" Then

                    If Trim(infoRecette.Rows(0)("NUMERO_TABLE")) = "" Then 'NUMERO_TABLE : BON_DE_COMMANDE
                        'LE DECAISSEMENT N'EST PAS ASSOCIE A UN BON DE COMMANDE (1- DEMANDE DE REAPPROVISIONNEMENT DE PETITE CAISSE)

                        GlobalVariable.decaissemtnAssocie = "remboursement petite caisse"

                        GunaDataGridViewDetailsFactures.Visible = False
                        GunaDataGridViewReglement.Visible = False

                        'GlobalVariable.decaissemtnAssocie = "Petite caisse"

                    Else
                        'LE DECAISSEMENT EST ASSOCIE A UN BON DE COMMANDE
                        GunaDataGridViewDetailsFactures.Visible = True
                        GunaDataGridViewReglement.Visible = False

                        GlobalVariable.decaissemtnAssocie = "Bon commande"

                    End If

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaComboBoxNatureOperation.SelectedItem = "SORTIE DE FONDS"
                    Else
                        GunaComboBoxNatureOperation.SelectedItem = "CASH OUTFLOW"
                    End If

                End If

                GunaTextBoxAPayer.Text = A_ENCAISSER

                GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " [ " & LIBELLE_FACTURE & " " & Trim(GunaTextBoxClientAFacturer.Text) & " " & Date.Now().ToShortDateString & " / " & CODE_FACTURE & " ] "

                'AFFICHE OU PAS DU BOUTTON ENREGISTRER
                afficherButtonEnregistrement(CODE_FACTURE)

            End If

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        GunaTextBoxSoldeCompte.Text = 0

        Dim total As Double = 0
        Dim total2 As Double = 0

        If TabControl1.SelectedIndex = 0 Then
            For i = 0 To GunaDataGridViewRecetteTransactionEnAttente.Rows.Count - 1
                total += GunaDataGridViewRecetteTransactionEnAttente.Rows(i).Cells("MONTANT_ATTENTE").Value
            Next

            GunaTextBoxSoldeCompte.Text = Format(total, "#,##0")

        ElseIf TabControl1.SelectedIndex = 1 Then
            For i = 0 To GunaDataGridViewDecaissement.Rows.Count - 1
                total += GunaDataGridViewDecaissement.Rows(i).Cells("MONTANT_ATTENTE_2").Value
            Next
            GunaTextBoxSoldeCompte.Text = Format(total, "#,##0")

        ElseIf TabControl1.SelectedIndex = 2 Then
            For i = 0 To GunaDataGridViewFondsSorties.Rows.Count - 1
                total += GunaDataGridViewFondsSorties.Rows(i).Cells("DataGridViewTextBoxColumn9").Value
            Next
            GunaTextBoxSoldeCompte.Text = Format(total, "#,##0")
        ElseIf TabControl1.SelectedIndex = 3 Then

            For i = 0 To GunaDataGridViewFondsEntree.Rows.Count - 1
                total += GunaDataGridViewFondsEntree.Rows(i).Cells("DataGridViewTextBoxColumn15").Value
            Next
            GunaTextBoxSoldeCompte.Text = Format(total, "#,##0")
        ElseIf TabControl1.SelectedIndex = 4 Then
            For i = 0 To GunaDataGridViewRecetteEntree.Rows.Count - 1
                total += GunaDataGridViewRecetteEntree.Rows(i).Cells("DataGridViewTextBoxColumn20").Value
            Next
            GunaTextBoxSoldeCompte.Text = Format(total, "#,##0")
        ElseIf TabControl1.SelectedIndex = 5 Then

            For i = 0 To GunaDataGridViewTransactionTerminee.Rows.Count - 1

                If Not Trim(GunaDataGridViewTransactionTerminee.Rows(i).Cells("MONTANT").Value.ToString).Equals("") Then
                    total += Double.Parse(GunaDataGridViewTransactionTerminee.Rows(i).Cells("MONTANT").Value.ToString)
                End If

                If Not Trim(GunaDataGridViewTransactionTerminee.Rows(i).Cells("MONTANT_SOLDE").Value.ToString).Equals("") Then
                    total2 += Double.Parse(GunaDataGridViewTransactionTerminee.Rows(i).Cells("MONTANT_SOLDE").Value.ToString)
                End If

            Next

            GunaTextBoxSoldeCompte.Text = Format(total2 - total, "#,##0")

        ElseIf TabControl1.SelectedIndex = 6 Then

            GunaDateTimePickerDebutCompta.Value = GlobalVariable.DateDeTravail
            GunaDateTimePickerFinCompta.Value = GlobalVariable.DateDeTravail

            Banques()

            For i = 0 To GunaDataGridViewJournalBancaire.Rows.Count - 1
                total += GunaDataGridViewJournalBancaire.Rows(i).Cells("DataGridViewTextBoxColumn25").Value
            Next

            GunaTextBoxSoldeCompte.Text = Format(total, "#,##0")

        End If

        If GlobalVariable.actualLanguageValue = 1 Then

            If TabControl1.SelectedIndex = 0 Then
                GunaLabel3.Text = "TRANSACTIONS DE RECETTE EN ATTENTES"
            ElseIf TabControl1.SelectedIndex = 1 Then
                GunaLabel3.Text = "DEMANDES DE DECAISSEMENT EN ATTENTES"
            ElseIf TabControl1.SelectedIndex = 2 Then
                GunaLabel3.Text = "FONDS SORTIES"
            ElseIf TabControl1.SelectedIndex = 3 Then
                GunaLabel3.Text = "FONDS ENTREES"
            ElseIf TabControl1.SelectedIndex = 4 Then
                GunaLabel3.Text = "RECETTES ENTREES"
            ElseIf TabControl1.SelectedIndex = 5 Then
                GunaLabel3.Text = "TRANSACTIONS TERMINEES"
            ElseIf TabControl1.SelectedIndex = 6 Then
                GunaLabel3.Text = "JOURNAL BANCAIRE"
            End If

        Else

            If TabControl1.SelectedIndex = 0 Then
                GunaLabel3.Text = "PENDING REVENUE TRANSACTIONS"
            ElseIf TabControl1.SelectedIndex = 1 Then
                GunaLabel3.Text = "PENDING DISBURSEMENT REQUESTS"
            ElseIf TabControl1.SelectedIndex = 2 Then
                GunaLabel3.Text = "FUNDS OUTFLOW"
            ElseIf TabControl1.SelectedIndex = 3 Then
                GunaLabel3.Text = "FUNDS INFOW"
            ElseIf TabControl1.SelectedIndex = 4 Then
                GunaLabel3.Text = "INCOMING REVENUE"
            ElseIf TabControl1.SelectedIndex = 5 Then
                GunaLabel3.Text = "COMPLETED TRANSACTIONS"
            ElseIf TabControl1.SelectedIndex = 6 Then
                GunaLabel3.Text = "BANK LOG"
            End If

        End If

        affichages()

    End Sub

    Private Sub affichages()

        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail

        Dim ETAT_FACTURE As Integer = 0

        If TabControl1.SelectedIndex = 0 Then
            '"PENDING REVENUE TRANSACTIONS"

        ElseIf TabControl1.SelectedIndex = 1 Then
            '"PENDING DISBURSEMENT REQUESTS"
            decaissementsEnAttente(DateDebut, DateFin, ETAT_FACTURE)
        ElseIf TabControl1.SelectedIndex = 2 Then
            '"FUNDS OUTFLOW"
            fondsSorties(DateDebut, DateFin, ETAT_FACTURE)
        ElseIf TabControl1.SelectedIndex = 3 Then
            '"FUNDS INFOW"
            fondsEntrees(DateDebut, DateFin, ETAT_FACTURE)
        ElseIf TabControl1.SelectedIndex = 4 Then
            '"INCOMING REVENUE"
            recettes(DateDebut, DateFin, ETAT_FACTURE)
        ElseIf TabControl1.SelectedIndex = 5 Then
            '"COMPLETED TRANSACTIONS"
            ETAT_FACTURE = 1

            transactionsTraitees(DateDebut, DateFin, ETAT_FACTURE)

            If GunaDataGridViewTransactionTerminee.Rows.Count > 0 Then
                GunaDataGridViewTransactionTerminee.Sort(GunaDataGridViewTransactionTerminee.Columns(1), ListSortDirection.Descending)
            End If

        ElseIf TabControl1.SelectedIndex = 6 Then
            '"BANK LOG"
        End If
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        'TRANSACTIONS EN ATTENTES
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click

        'Transactions Terminées
        Dim ETAT_FACTURE As Integer = 0
        '---------------------------- OLD WAY ----------------------------------------------------------------------------------------------------
        'listeDesOperationsParNature(DateDebut, DateFin, ETAT_FACTURE)
        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail
        'decaissementsEnAttente(DateDebut, DateFin, ETAT_FACTURE)

        TabControl1.SelectedIndex = 1

    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click

        'Transactions Terminées
        Dim ETAT_FACTURE As Integer = 0
        '---------------------------- OLD WAY ----------------------------------------------------------------------------------------------------
        'listeDesOperationsParNature(DateDebut, DateFin, ETAT_FACTURE)
        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail
        'fondsSorties(DateDebut, DateFin, ETAT_FACTURE)

        TabControl1.SelectedIndex = 2
    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click

        'Transactions Terminées
        Dim ETAT_FACTURE As Integer = 0
        '---------------------------- OLD WAY ----------------------------------------------------------------------------------------------------
        'listeDesOperationsParNature(DateDebut, DateFin, ETAT_FACTURE)
        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail
        'fondsEntrees(DateDebut, DateFin, ETAT_FACTURE)

        TabControl1.SelectedIndex = 3
    End Sub

    Private Sub GunaAdvenceButton7_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton7.Click

        'Transactions Terminées
        Dim ETAT_FACTURE As Integer = 0
        '---------------------------- OLD WAY ----------------------------------------------------------------------------------------------------
        'listeDesOperationsParNature(DateDebut, DateFin, ETAT_FACTURE)
        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail
        'recettes(DateDebut, DateFin, ETAT_FACTURE)

        TabControl1.SelectedIndex = 4
    End Sub

    Private Sub GunaAdvenceButton6_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton6.Click

        TabControl1.SelectedIndex = 6
    End Sub

    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click

        'Transactions Terminées
        Dim ETAT_FACTURE As Integer = 1
        '---------------------------- OLD WAY ----------------------------------------------------------------------------------------------------
        'listeDesOperationsParNature(DateDebut, DateFin, ETAT_FACTURE)
        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail
        'transactionsTraitees(DateDebut, DateFin, ETAT_FACTURE)

        If GunaDataGridViewTransactionTerminee.Rows.Count > 0 Then
            'GunaDataGridViewTransactionTerminee.Sort(GunaDataGridViewTransactionTerminee.Columns(1), ListSortDirection.Descending)
        End If

        TabControl1.SelectedIndex = 5

    End Sub

    Private Sub GunaAdvenceButton9_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton9.Click
        GlobalVariable.typeDeCompte = "exploitation"
        DepenseFamilyForm.Show()
        DepenseFamilyForm.TopMost = True
        DepenseFamilyForm.TabControl1.SelectedIndex = 2
    End Sub

    Private Sub listeDesOperationsParNature(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer)
        'kklg
        '------------------------------------------------------------------- FACTURES ---------------------------------------------------------------------------------------------
        'Dim totalTraitees As Double = 0
        Dim totalReglement As Double = 0

        '-------------------------------------------------- END FACTURE ----------------------------------------------------------------------

        '----------------------------------------------- REGLEMENT -----------------------------------------------------------

        Dim query3 As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                    If Not caisseCommune Then
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE')  AND CODE_CAISSIER=@CODE_UTILISATEUR_CREA ORDER BY ID_REGLEMENT DESC"
                    Else
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE') ORDER BY ID_REGLEMENT DESC"
                    End If
                Else
                    query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE') ORDER BY ID_REGLEMENT DESC"
                End If

            Else


                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                    If Not caisseCommune Then
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW')  AND CODE_CAISSIER=@CODE_UTILISATEUR_CREA ORDER BY ID_REGLEMENT DESC"
                    Else
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"
                    End If
                Else
                    query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"
                End If

            End If

        End If

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        GunaDataGridViewFondsEntree.Rows.Clear()
        GunaDataGridViewRecetteEntree.Rows.Clear()
        'GunaDataGridViewFondsSorties.Rows.Clear()

        If tableReglement.Rows.Count > 0 Then

            For k = 0 To tableReglement.Rows.Count - 1

                totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                If tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTREE DE FONDS" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "CASH INFLOW" Then

                    GunaDataGridViewFondsEntree.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))

                    'GunaDataGridViewFondsEntree.Sort(GunaDataGridViewFondsEntree.Columns(1), ListSortDirection.Descending)

                ElseIf tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTREE DE RECETTE" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTERING REVENUE" Then

                    GunaDataGridViewRecetteEntree.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))

                    'GunaDataGridViewRecetteEntree.Sort(GunaDataGridViewRecetteEntree.Columns(1), ListSortDirection.Descending)

                ElseIf tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "SORTIE DE FONDS" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "CASH OUTFLOW" Then

                    GunaDataGridViewFondsSorties.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE") * -1, "#,##0"), "")

                    ' GunaDataGridViewFondsSorties.Sort(GunaDataGridViewFondsSorties.Columns(1), ListSortDirection.Descending)

                End If

            Next

        End If

        '---------------------------------------------------------------------------------------------------------------------

        'GunaDataGridViewListeFacture.Sort(GunaDataGridViewListeFacture.Columns(1), ListSortDirection.Descending)

    End Sub

    Private Sub fondsSorties(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer)
        'kklg
        '------------------------------------------------------------------- FACTURES ---------------------------------------------------------------------------------------------
        'Dim totalTraitees As Double = 0
        Dim totalReglement As Double = 0

        '-------------------------------------------------- END FACTURE ----------------------------------------------------------------------

        '----------------------------------------------- REGLEMENT -----------------------------------------------------------

        Dim query3 As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

            If Not caisseCommune Then
                'La caisse principale n'etant pas commune
                If GlobalVariable.actualLanguageValue = 1 Then

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE')  AND CODE_CAISSIER=@CODE_UTILISATEUR_CREA ORDER BY ID_REGLEMENT DESC"
                    Else
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE') ORDER BY ID_REGLEMENT DESC"
                    End If

                Else

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW')  AND CODE_CAISSIER=@CODE_UTILISATEUR_CREA ORDER BY ID_REGLEMENT DESC"
                    Else
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"
                    End If

                End If

            Else

                'Caisse Principale Commune

                If GlobalVariable.actualLanguageValue = 1 Then
                    query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE') ORDER BY ID_REGLEMENT DESC"
                Else
                    query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"
                End If

            End If

        End If

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        GunaDataGridViewFondsSorties.Rows.Clear()

        If tableReglement.Rows.Count > 0 Then

            For k = 0 To tableReglement.Rows.Count - 1

                totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                If tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "SORTIE DE FONDS" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "CASH OUTFLOW" Then

                    GunaDataGridViewFondsSorties.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE") * -1, "#,##0"), "")

                End If

            Next

        End If

        '---------------------------------------------------------------------------------------------------------------------

        GunaDataGridViewFondsSorties.Sort(GunaDataGridViewFondsSorties.Columns(1), ListSortDirection.Descending)

    End Sub

    Private Sub fondsEntrees(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer)
        'kklg
        '------------------------------------------------------------------- FACTURES ---------------------------------------------------------------------------------------------
        'Dim totalTraitees As Double = 0
        Dim totalReglement As Double = 0

        '-------------------------------------------------- END FACTURE ----------------------------------------------------------------------

        '----------------------------------------------- REGLEMENT -----------------------------------------------------------

        Dim query3 As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

            If Not caisseCommune Then
                If GlobalVariable.actualLanguageValue = 1 Then

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE')  AND CODE_CAISSIER=@CODE_UTILISATEUR_CREA ORDER BY ID_REGLEMENT DESC"
                    Else
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE') ORDER BY ID_REGLEMENT DESC"
                    End If

                Else

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW')  AND CODE_CAISSIER=@CODE_UTILISATEUR_CREA ORDER BY ID_REGLEMENT DESC"
                    Else
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"
                    End If

                End If
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE') ORDER BY ID_REGLEMENT DESC"
                Else
                    query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"
                End If
            End If


        End If

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        GunaDataGridViewFondsEntree.Rows.Clear()

        If tableReglement.Rows.Count > 0 Then

            For k = 0 To tableReglement.Rows.Count - 1

                totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                If tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTREE DE FONDS" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "CASH INFLOW" Then
                    GunaDataGridViewFondsEntree.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))
                End If

            Next

        End If

        '---------------------------------------------------------------------------------------------------------------------

        GunaDataGridViewFondsEntree.Sort(GunaDataGridViewFondsEntree.Columns(1), ListSortDirection.Descending)

    End Sub

    Private Sub recettes(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer)
        'kklg
        '------------------------------------------------------------------- FACTURES ---------------------------------------------------------------------------------------------
        'Dim totalTraitees As Double = 0
        Dim totalReglement As Double = 0

        '-------------------------------------------------- END FACTURE ----------------------------------------------------------------------

        '----------------------------------------------- REGLEMENT -----------------------------------------------------------

        Dim query3 As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

            If Not caisseCommune Then
                If GlobalVariable.actualLanguageValue = 1 Then

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE')  AND CODE_CAISSIER=@CODE_UTILISATEUR_CREA ORDER BY ID_REGLEMENT DESC"
                    Else
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE') ORDER BY ID_REGLEMENT DESC"
                    End If

                Else

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 1 Then
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW')  AND CODE_CAISSIER=@CODE_UTILISATEUR_CREA ORDER BY ID_REGLEMENT DESC"
                    Else
                        query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"
                    End If

                End If
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS','ENTREE DE RECETTE') ORDER BY ID_REGLEMENT DESC"

                Else
                    query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTERING REVENUE','CASH INFLOW','CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"

                End If
            End If


        End If

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        GunaDataGridViewRecetteEntree.Rows.Clear()

        If tableReglement.Rows.Count > 0 Then

            For k = 0 To tableReglement.Rows.Count - 1

                totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                If tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTREE DE RECETTE" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTERING REVENUE" Then

                    GunaDataGridViewRecetteEntree.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))
                End If

            Next

        End If

        '---------------------------------------------------------------------------------------------------------------------

        GunaDataGridViewRecetteEntree.Sort(GunaDataGridViewRecetteEntree.Columns(1), ListSortDirection.Descending)

    End Sub

    Private Sub journalBancaire(ByVal DateDebut As Date, ByVal DateFin As Date)

        Dim CODE_BANQUE As String = GunaComboBoxBanqueEmettrice.SelectedValue.ToString

        Dim query3 As String = "SELECT DATE_REGLEMENT, REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE 
               FROM reglement, banque_transaction WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND banque_transaction.CODE_BANQUE =@CODE_BANQUE AND reglement.NUM_REGLEMENT = banque_transaction.CODE_REGLEMENT ORDER BY DATE_REGLEMENT DESC"

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_BANQUE", MySqlDbType.VarChar).Value = CODE_BANQUE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        Dim totalReglement As Double = 0

        If tableReglement.Rows.Count > 0 Then

            For k = 0 To tableReglement.Rows.Count - 1

                totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                GunaDataGridViewJournalBancaire.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), tableReglement.Rows(k)("MODE_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))

                'GunaDataGridViewJournalBancaire.Sort(GunaDataGridViewJournalBancaire.Columns(1), ListSortDirection.Descending)
            Next

        End If

    End Sub

    Private Sub Banques()

        Dim query As String = "SELECT * From banque ORDER BY NOM_BANQUE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

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

    End Sub

    Private Sub GunaComboBoxBanqueEmettrice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxBanqueEmettrice.SelectedIndexChanged

        GunaDataGridViewJournalBancaire.Rows.Clear()

    End Sub

    Private Sub GunaButtonImprimerSituation_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerSituation.Click

        Dim title As String = ""

        If TabControl1.SelectedIndex = 0 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                title = "TRANSACTIONS DE RECETTE EN ATTENTES"

            Else
                title = "ENTERING REVENUE PENDING TRANSACTIONS"

            End If
            Impression.listeDesOperations(GunaDataGridViewRecetteTransactionEnAttente, title, TabControl1.SelectedIndex)
        ElseIf TabControl1.SelectedIndex = 1 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                title = "DEMANDES DE DECAISSEMENT EN ATTENTES"

            Else
                title = "PENDING DISBURSEMENT REQUEST"

            End If
            Impression.listeDesOperations(GunaDataGridViewDecaissement, title, TabControl1.SelectedIndex)
        ElseIf TabControl1.SelectedIndex = 2 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                title = "FONDS SORTIES"

            Else
                title = "ASH OUTFLOW"

            End If
            Impression.listeDesOperations(GunaDataGridViewFondsSorties, title, TabControl1.SelectedIndex)
        ElseIf TabControl1.SelectedIndex = 3 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                title = "FONDS ENTREES"

            Else
                title = "CASH INFLOW"

            End If
            Impression.listeDesOperations(GunaDataGridViewFondsEntree, title, TabControl1.SelectedIndex)
        ElseIf TabControl1.SelectedIndex = 4 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                title = "RECETTES ENTREES"

            Else
                title = "REVENUES"

            End If
            Impression.listeDesOperations(GunaDataGridViewRecetteEntree, title, TabControl1.SelectedIndex)
        ElseIf TabControl1.SelectedIndex = 5 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                title = "TRANSACTIONS TERMINEES"

            Else
                title = "COMPLETED TRANSACTIONS"

            End If
            Impression.listeDesOperations(GunaDataGridViewTransactionTerminee, title, TabControl1.SelectedIndex)
        ElseIf TabControl1.SelectedIndex = 6 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                title = "JOURNAL BANCAIRE"

            Else
                title = "BANK LOG"

            End If
            Dim BANQUE As String = Functions.getElementByCode(GunaComboBoxBanqueEmettrice.SelectedValue.ToString, "banque", "CODE_BANQUE").Rows(0)("NOM_BANQUE")

            Impression.listeDesOperations(GunaDataGridViewJournalBancaire, title, TabControl1.SelectedIndex, BANQUE)

        End If

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        If GunaComboBoxBanqueEmettrice.SelectedIndex >= 0 Then

            Dim DateDebut As Date = GunaDateTimePickerDebutCompta.Value.ToShortDateString
            Dim DateFin As Date = GunaDateTimePickerFinCompta.Value.ToShortDateString

            journalBancaire(DateDebut, DateFin)

        End If

    End Sub

    Private Sub GunaCheckBoxDateFictive_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDateFictive.Click

        If GunaCheckBoxDateFictive.Checked Then
            GunaDateTimePickerDateDeTravailFictif.Visible = True
            GlobalVariable.DateDeTravail = GunaDateTimePickerDateDeTravailFictif.Value.ToShortDateString
        Else
            GunaDateTimePickerDateDeTravailFictif.Visible = False
            GlobalVariable.DateDeTravail = Functions.ObtenirDateDeTravail()
            GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail
        End If

    End Sub
    'RAFRAICHISSEMENT DES TRANSACTIONS EN ATTENTE

    Private Sub GunaDateTimePickerDateDeTravailFictif_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDateDeTravailFictif.ValueChanged

        If GunaCheckBoxDateFictive.Checked Then
            GunaDateTimePickerDateDeTravailFictif.Visible = True
            GlobalVariable.DateDeTravail = GunaDateTimePickerDateDeTravailFictif.Value.ToShortDateString

            GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail
        End If

    End Sub

    Private Sub GunaButtonRefresh_Click(sender As Object, e As EventArgs) Handles GunaButtonRefresh.Click

        rafraichissementDelaFenetre()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        rafraichissementDelaFenetre()

    End Sub

    Private Sub GunaTextBoxCompte_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefCompte.TextChanged

        If Trim(GunaTextBoxRefCompte.Text) = "" Then

            GunaTextBoxMoisEncours.Clear()
            GunaTextBoxMoisDernier.Clear()
            GunaTextBoxiNTITUTLE.Clear()
            GunaDataGridViewPlanComptable.Columns.Clear()
            GunaDataGridViewPlanComptable.Visible = False

        Else

            'REFRESHING information from database for instant visualisation 
            Dim query As String = "SELECT COMPTE, INTITULE FROM compte_exploitation WHERE COMPTE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' OR INTITULE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' AND NATURE_COMPTE = 0 ORDER BY INTITULE ASC"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaDataGridViewPlanComptable.Visible = True
                GunaDataGridViewPlanComptable.DataSource = table
            Else
                'GunaDataGridViewPlanComptable.Columns.Clear()
                GunaDataGridViewPlanComptable.Visible = False
            End If

        End If

    End Sub

    Private Sub GunaDataGridViewPlanComptable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanComptable.CellClick

        Dim dateDebut As Date = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail)
        Dim dateFin As Date = GlobalVariable.DateDeTravail

        Dim dateDebut_1 As Date = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail.AddMonths(-1))
        Dim dateFin_1 As Date = Functions.lastDayOfMonth(GlobalVariable.DateDeTravail.AddMonths(-1))

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPlanComptable.Rows(e.RowIndex)

            GunaTextBoxRefCompte.Text = row.Cells("COMPTE").Value.ToString
            Dim CODE_CATEGORY_DEPENSE As String = GunaTextBoxRefCompte.Text
            Dim comptePlan As DataTable = Functions.getElementByCode(GunaTextBoxRefCompte.Text, "compte_exploitation", "COMPTE")

            Dim NATURE_COMPTE As Integer = 0

            If comptePlan.Rows.Count > 0 Then
                GunaTextBoxiNTITUTLE.Text = comptePlan.Rows(0)("INTITULE")
                GunaTextBoxMoisEncours.Text = Format(Functions.montantDucompteExploitation(dateDebut, dateFin, CODE_CATEGORY_DEPENSE, NATURE_COMPTE), "#,##0")
                GunaTextBoxMoisDernier.Text = Format(Functions.montantDucompteExploitation(dateDebut_1, dateFin_1, CODE_CATEGORY_DEPENSE, NATURE_COMPTE), "#,##0")
            End If

            GunaDataGridViewPlanComptable.Visible = False

        End If

    End Sub

End Class