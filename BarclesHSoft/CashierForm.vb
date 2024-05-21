Imports MySql.Data.MySqlClient

Public Class CashierForm

    'Dim connect As New DataBaseManipulation()

    Private Sub CashierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TabControl1.SelectedIndex = 1

        UtilisateurDesCAisses(1) ' GRANDE CAISSE
        UtilisateurDesCAisses(2) ' PETITE CAISSE

        listeDesPetitesCaissesAAfecter()

        GunaComboBoxUtilisateurDePetite.SelectedIndex = -1
        GunaComboBoxUtilisateurDeCaisse.SelectedIndex = -1

        DataGridViewGrandeCaisseListe.Columns.Clear()

    End Sub

    Public Sub UtilisateurDesCAisses(ByVal TypeDeCaisse As Integer)

        '1: GRANDE CAISSE
        '2: PETITE CAISSE

        If TypeDeCaisse = 1 Then

            Dim Query As String = "SELECT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR, GRANDE_CAISSE From utilisateurs INNER JOIN utilisateur_acces WHERE utilisateurs.CATEG_UTILISATEUR=utilisateur_acces.CODE_PROFIL AND GRANDE_CAISSE=@GRANDE_CAISSE ORDER BY NOM_UTILISATEUR ASC"
            Dim command As New MySqlCommand(Query, GlobalVariable.connect)
            'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            command.Parameters.Add("@GRANDE_CAISSE", MySqlDbType.Int32).Value = 1

            Dim tableCaissier As New DataTable
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(tableCaissier)

            If (tableCaissier.Rows.Count > 0) Then

                GunaComboBoxUtilisateurDeCaisse.DataSource = tableCaissier
                GunaComboBoxUtilisateurDeCaisse.ValueMember = "CODE_UTILISATEUR"
                GunaComboBoxUtilisateurDeCaisse.DisplayMember = "NOM_UTILISATEUR"

            End If

        ElseIf TypeDeCaisse = 2 Then

            Dim Query As String = "SELECT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR,PETITE_CAISSE,GRANDE_CAISSE From utilisateurs INNER JOIN utilisateur_acces WHERE utilisateurs.CATEG_UTILISATEUR=utilisateur_acces.CODE_PROFIL AND PETITE_CAISSE=@PETITE_CAISSE ORDER BY NOM_UTILISATEUR ASC"
            Dim command As New MySqlCommand(Query, GlobalVariable.connect)
            'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            command.Parameters.Add("@PETITE_CAISSE", MySqlDbType.Int32).Value = 1

            Dim tableCaissier As New DataTable
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(tableCaissier)

            If (tableCaissier.Rows.Count > 0) Then

                GunaComboBoxUtilisateurDePetite.DataSource = tableCaissier
                GunaComboBoxUtilisateurDePetite.ValueMember = "CODE_UTILISATEUR"
                GunaComboBoxUtilisateurDePetite.DisplayMember = "NOM_UTILISATEUR"

            End If

        End If


        'connect.closeConnection()

    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    'Liste des caisse
    Public Sub caisseList(ByVal TABLE_NAME As String)

        'AFFICHAGE DES GRANDES ET PETITES CAISSES

        Dim query As String = ""

        If TABLE_NAME = "caisse" Then

            'ON AFFICHE QUE LES GRANDES CAISSES ASSOCIE A UN UTILISATEUR

            query = "SELECT CODE_CAISSE AS 'CODE CAISSE', LIBELLE_CAISSE AS 'LIBELLE',SOLDE_CAISSE AS SOLDE, TYPE_CAISSE As 'TYPE DE CAISSE', ETAT_CAISSE As 'ETAT DE CAISSE',  NOM_UTILISATEUR AS UTILISATEUR, CATEG_UTILISATEUR AS 'CATEGORIE' From " & TABLE_NAME & " INNER JOIN utilisateurs WHERE caisse.CODE_UTILISATEUR = utilisateurs.CODE_UTILISATEUR AND CODE_AGENCE= @CODE_AGENCE ORDER BY LIBELLE_CAISSE ASC"

            Dim command1 As New MySqlCommand(query, GlobalVariable.connect)

            command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

            Dim adapter1 As New MySqlDataAdapter(command1)
            Dim table As New DataTable()

            adapter1.Fill(table)

            If (table.Rows.Count > 0) Then

                DataGridViewGrandeCaisseListe.DataSource = table

                DataGridViewGrandeCaisseListe.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
                DataGridViewGrandeCaisseListe.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewGrandeCaisseListe.Columns("ETAT DE CAISSE").Visible = False
                DataGridViewGrandeCaisseListe.Columns("SOLDE").Visible = False

            Else
                DataGridViewGrandeCaisseListe.Columns.Clear()
            End If

        ElseIf TABLE_NAME = "petite_caisse" Then

            query = "SELECT CODE_CAISSE AS 'CODE CAISSE', LIBELLE_CAISSE AS 'LIBELLE', SOLDE_CAISSE AS SOLDE, MONTANT_PLAFONDS As 'MONTANT PLAFONDS', ETAT_CAISSE As 'ETAT DE CAISSE' From petite_caisse WHERE CODE_AGENCE= @CODE_AGENCE ORDER BY LIBELLE_CAISSE ASC"

            Dim command1 As New MySqlCommand(query, GlobalVariable.connect)

            command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

            Dim adapter1 As New MySqlDataAdapter(command1)
            Dim tableCaisse As New DataTable()

            adapter1.Fill(tableCaisse)

            If (tableCaisse.Rows.Count > 0) Then
                GunaDataGridViewPetiteCaisse.DataSource = tableCaisse

                GunaDataGridViewPetiteCaisse.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewPetiteCaisse.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                GunaDataGridViewPetiteCaisse.Columns("ETAT DE CAISSE").Visible = False
                GunaDataGridViewPetiteCaisse.Columns("SOLDE").Visible = False

            Else

                GunaDataGridViewPetiteCaisse.Columns.Clear()

            End If

        End If

    End Sub

    'Création et mis à jours d'une caisse
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_CAISSE As String = CodeCAisse.Text
        Dim LIBELLE_CAISSE As String = GunaTextBoxIntitule.Text
        Dim CODE_UTILISATEUR As String = GunaComboBoxUtilisateurDeCaisse.SelectedValue.ToString
        Dim ETAT_CAISSE As Integer = 0

        If GunaComboBoxEtaitCaisse.SelectedItem = "Ouverte" Then
            ETAT_CAISSE = 1
        Else
            ETAT_CAISSE = 0
        End If

        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim DATE_COMPTABLE As Date = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        'Dim CODE_UTILISATEUR_CREA As String = "hello"
        Dim DATE_MODIFICATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_MODIF As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        'Dim CODE_UTILISATEUR_MODIF As String = "dfdsfd"
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim TYPE_CAISSE As String = GunaComboBoxTtypeDeCaisse.SelectedItem
        Dim NUM_COMPTE As String = GunaTextBoxCompte.Text

        Dim TABLE As String = "caisse"

        Dim caisse As New Caisse()

        'company verifyfields function
        If (True) Then
            'check if the company alreday exist

            If GunaButtonEnregistrer.Text = "Sauvegarder" Then
                'we update the value after double click
                If caisse.update(CODE_CAISSE, LIBELLE_CAISSE, CODE_UTILISATEUR, NUM_COMPTE, ETAT_CAISSE, DATE_CREATION, DATE_COMPTABLE, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TYPE_CAISSE, TABLE) Then
                    MessageBox.Show("Grande Caisse mise à jours avec succès", "Modification de Caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TabControl1.SelectedIndex = 1
                    'Clearing of fields
                    Functions.ClearTextBox(Me)
                End If
                GunaButtonEnregistrer.Text = "Enregistrer"
            Else

                If Not Functions.entryCodeExists(CODE_CAISSE, "caisse", "CODE_CAISSE") Then
                    If caisse.insert(CODE_CAISSE, LIBELLE_CAISSE, CODE_UTILISATEUR, NUM_COMPTE, ETAT_CAISSE, DATE_CREATION, DATE_COMPTABLE, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TYPE_CAISSE, TABLE) Then
                        MessageBox.Show("Nouvelle Caisse enregistrée avec succès", "Création de CAisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Clearing of fields

                        Functions.ClearTextBox(Me)
                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création de Caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Cette Caisse existe déjà, Essayer à nouveau", "Caisse Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création de Caissier", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'We refresh the room list
        'caisseList()

    End Sub

    Private Sub GunaComboBoxUtilisateurDeCaisse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUtilisateurDeCaisse.SelectedIndexChanged

        If GunaComboBoxUtilisateurDeCaisse.SelectedIndex >= 0 Then

            Dim caissier As DataTable = Functions.getElementByCode(GunaComboBoxUtilisateurDeCaisse.SelectedValue.ToString, "utilisateurs", "CODE_UTILISATEUR")
            If caissier.Rows.Count > 0 Then
                GunaTextBoxNomComplet.Text = caissier.Rows(0)("CATEG_UTILISATEUR") & " - " & caissier.Rows(0)("NOM_UTILISATEUR")
            End If

        Else
            GunaTextBoxNomComplet.Clear()
        End If

    End Sub

    'DELETING A LINE IN DATATGRID
    Private Sub ImprimerToolStripMenuItemSupressionCaisse_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItemSupressionCaisse.Click

        If TABLE_NAME = "caisse" Then

            If DataGridViewGrandeCaisseListe.Rows.Count > 0 Then

                Dim dialog As DialogResult
                dialog = MessageBox.Show("Voulez-vous vraiment Supprimer cette caisse" & DataGridViewGrandeCaisseListe.CurrentRow.Cells("CODE CAISSE").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If dialog = DialogResult.No Then
                    'e.Cancel = True
                Else
                    Functions.DeleteRowFromDataGridGeneral(DataGridViewGrandeCaisseListe, DataGridViewGrandeCaisseListe.CurrentRow.Cells("CODE CAISSE").Value.ToString, "caisse", "CODE_CAISSE")

                    DataGridViewGrandeCaisseListe.Columns.Clear()

                    caisseList(TABLE_NAME)

                    MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else
                MessageBox.Show("Aucune ligne à supprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            If GunaDataGridViewPetiteCaisse.Rows.Count > 0 Then

                Dim dialog As DialogResult
                dialog = MessageBox.Show("Voulez-vous vraiment Supprimer cette caisse" & GunaDataGridViewPetiteCaisse.CurrentRow.Cells("CODE CAISSE").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If dialog = DialogResult.No Then
                    'e.Cancel = True
                Else
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewPetiteCaisse, GunaDataGridViewPetiteCaisse.CurrentRow.Cells("CODE CAISSE").Value.ToString, "petite_caisse", "CODE_CAISSE")

                    GunaDataGridViewPetiteCaisse.Columns.Clear()

                    caisseList(TABLE_NAME)

                    MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else
                MessageBox.Show("Aucune ligne à supprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If



    End Sub

    'MODIFICATION OF A CAISSE
    Private Sub DataGridViewCaisseListe_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewGrandeCaisseListe.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaTextBoxNomComplet.Clear()

            'AU DOUBLE CLICK CONTROLLER SI L'ELEMENT SUR LEQUEL ON CLIQUE A LE DROIT D'
            GunaButtonEnregistrer.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.DataGridViewGrandeCaisseListe.Rows(e.RowIndex)

            Dim caisse As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE CAISSE").Value.ToString), "caisse", "CODE_CAISSE")

            If caisse.Rows.Count > 0 Then

                CodeCAisse.Text = caisse.Rows(0)("CODE_CAISSE")
                GunaTextBoxIntitule.Text = caisse.Rows(0)("LIBELLE_CAISSE")
                GunaComboBoxUtilisateurDeCaisse.SelectedValue = caisse.Rows(0)("CODE_UTILISATEUR")
                GunaComboBoxEtaitCaisse.SelectedItem = caisse.Rows(0)("ETAT_CAISSE")
                ' CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                Dim caissier As DataTable = Functions.getElementByCode(caisse.Rows(0)("CODE_UTILISATEUR"), "utilisateurs", "CODE_UTILISATEUR")
                If caissier.Rows.Count > 0 Then
                    GunaTextBoxNomComplet.Text = caissier.Rows(0)("CATEG_UTILISATEUR") & " - " & caissier.Rows(0)("NOM_UTILISATEUR")
                End If
                'Dim CODE_UTILISATEUR_MODIF As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                GunaComboBoxTtypeDeCaisse.SelectedItem = caisse.Rows(0)("TYPE_CAISSE")
                GunaTextBoxCompte.Text = caisse.Rows(0)("NUM_COMPTE")

                If caisse.Rows(0)("ETAT_CAISSE") = 0 Then
                    GunaComboBoxEtaitCaisse.SelectedItem = "Fermée"
                Else
                    GunaComboBoxEtaitCaisse.SelectedItem = "Ouverte"
                End If

                TabControl1.SelectedIndex = 0

            End If

        End If

    End Sub

    Dim TABLE_NAME As String = ""

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherGrandeCaisse.Click
        TABLE_NAME = "caisse"
        caisseList(TABLE_NAME)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 1 Then
            TABLE_NAME = "caisse"
            GunaLabelGestCompteGeneraux.Text = "LISTE DES GRANDES CAISSES"
        ElseIf TabControl1.SelectedIndex = 2 Then
            TABLE_NAME = "petite_caisse"
            GunaLabelGestCompteGeneraux.Text = "LISTE DES PETITES CAISSES"
        ElseIf TabControl1.SelectedIndex = 0 Then

            If TABLE_NAME = "caisse" Then
                GunaLabelGestCompteGeneraux.Text = "CREATION ET GESTION DES GRANDES CAISSES"
            ElseIf TABLE_NAME = "petite_caisse" Then
                GunaLabelGestCompteGeneraux.Text = "CREATION ET GESTION DES PETITES CAISSES"
            End If

        End If

        DataGridViewGrandeCaisseListe.Columns.Clear()

    End Sub

    Private Sub GunaButtonNouvelle_Click(sender As Object, e As EventArgs) Handles GunaButtonGestionPetiteCaisse.Click

        Dim CODE_CAISSE As String = GunaTextBoxCodePetiteCaisse.Text
        Dim LIBELLE_CAISSE As String = GunaTextBoxLibellePEtiteCaisse.Text
        Dim CODE_UTILISATEUR As String = ""
        Dim ETAT_CAISSE As Integer = 0

        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim DATE_COMPTABLE As Date = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        'Dim CODE_UTILISATEUR_CREA As String = "hello"
        Dim DATE_MODIFICATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_MODIF As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        'Dim CODE_UTILISATEUR_MODIF As String = "dfdsfd"
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim TYPE_CAISSE As String = ""

        If GunaComboBoxTtypeDeCaisse.SelectedIndex >= 0 Then
            TYPE_CAISSE = GunaComboBoxTtypeDeCaisse.SelectedItem
        End If

        Dim NUM_COMPTE As String = GunaTextBoxCompte.Text

        Dim MONTANT_PLAFONDS As Double = 5000

        If Not Trim(GunaTextBoxMontantPlafonds.Text).Equals("") Then
            MONTANT_PLAFONDS = GunaTextBoxMontantPlafonds.Text
        End If

        Dim caisse As New Caisse()

        Dim insert As Boolean = False

        'LE CODE NE DOIT PAS ETRE VIDE
        If Not Trim(GunaTextBoxCodePetiteCaisse.Text).Equals("") Then

            'LE LIBELE NE DOIT PAS ETRE VIDE

            If Not Trim(GunaTextBoxLibellePEtiteCaisse.Text).Equals("") Then
                insert = True
            End If

        End If

        'company verifyfields function
        If insert Then
            'check if the company alreday exist

            Dim TABLE As String = "petite_caisse"

            If GunaButtonGestionPetiteCaisse.Text = "Sauvegarder" Then

                'we update the value after double click
                If caisse.update(CODE_CAISSE, LIBELLE_CAISSE, CODE_UTILISATEUR, NUM_COMPTE, ETAT_CAISSE, DATE_CREATION, DATE_COMPTABLE, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TYPE_CAISSE, TABLE, MONTANT_PLAFONDS) Then

                    MessageBox.Show("Petite Caisse Mise à jours avec succès", "Modification de Petite Caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TabControl1.SelectedIndex = 1

                    'Clearing of fields
                    Functions.ClearTextBox(Me)
                End If

                GunaButtonGestionPetiteCaisse.Text = "Créer"

            Else

                If Not Functions.entryCodeExists(CODE_CAISSE, "petite_caisse", "CODE_CAISSE") Then

                    If caisse.insert(CODE_CAISSE, LIBELLE_CAISSE, CODE_UTILISATEUR, NUM_COMPTE, ETAT_CAISSE, DATE_CREATION, DATE_COMPTABLE, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TYPE_CAISSE, TABLE, MONTANT_PLAFONDS) Then

                        MessageBox.Show("Nouvelle Petite Caisse enregistrée avec succès", "Création de Caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Clearing of fields

                        Functions.ClearTextBox(Me)
                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création de Petite Caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Cette Petite Caisse existe déjà, Essayer à nouveau", "Caisse Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

            'ON REMPLI LE DROP DOWN CONTENANT LA LISTE DES PTITES CAISSES POUR AFFECTATION A UN UTILISATEUR
            listeDesPetitesCaissesAAfecter()

            GunaTextBoxMontantPlafonds.Text = 0

        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création de Petite Caissier", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Public Sub listeDesPetitesCaissesAAfecter()

        Dim query As String = "SELECT CODE_CAISSE AS 'CODE CAISSE', LIBELLE_CAISSE AS 'LIBELLE' From petite_caisse WHERE CODE_AGENCE= @CODE_AGENCE ORDER BY LIBELLE_CAISSE ASC"

        Dim command1 As New MySqlCommand(query, GlobalVariable.connect)

        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim tableCaisse As New DataTable()

        adapter1.Fill(tableCaisse)

        If (tableCaisse.Rows.Count > 0) Then

            GunaComboBoxPetiteCaisseAAffecter.DataSource = tableCaisse
            GunaComboBoxPetiteCaisseAAffecter.ValueMember = "CODE CAISSE"
            GunaComboBoxPetiteCaisseAAffecter.DisplayMember = "LIBELLE"

        End If

    End Sub

    Public Function UtilisateurDelaPetiteCaisseSelectionne(ByVal CODE_CAISSE As String) As DataTable

        Dim Query As String = "SELECT utilisateurs.CODE_UTILISATEUR As 'CODE UTILISATEUR',NOM_UTILISATEUR, CATEG_UTILISATEUR AS 'CATEGORIE UTILISATEUR',CODE_CAISSE AS 'CODE CAISSE' From utilisateurs INNER JOIN utilisateur_caisse WHERE utilisateurs.CODE_UTILISATEUR=utilisateur_caisse.CODE_UTILISATEUR AND utilisateur_caisse.CODE_CAISSE=@CODE_CAISSE"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE

        Dim tableUtilisateurDeCaisse As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(tableUtilisateurDeCaisse)

        Return tableUtilisateurDeCaisse

    End Function

    Private Sub GunaComboBoxPetiteCaisseAAffecter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxPetiteCaisseAAffecter.SelectedIndexChanged

        If GunaComboBoxPetiteCaisseAAffecter.SelectedIndex >= 0 Then

            Dim CODE_CAISSE As String = GunaComboBoxPetiteCaisseAAffecter.SelectedValue.ToString()

            GunaTextBoxCodePetiteCaisseAffectation.Text = CODE_CAISSE

            GunaDataGridViewUtilisateurDePtiteCaisseAffecte.Columns.Clear()

            GunaDataGridViewUtilisateurDePtiteCaisseAffecte.DataSource = UtilisateurDelaPetiteCaisseSelectionne(CODE_CAISSE) ' CHARGEMENT DE UTILISATEURS DU MAGAINS ACTUEL

        End If

    End Sub

    Private Sub GunaButtonSaveAffectation_Click(sender As Object, e As EventArgs) Handles GunaButtonSaveAffectation.Click

        If Not Trim(GunaTextBoxCodePetiteCaisseAffectation.Text) = "" Then

            Dim CODE_CAISSE As String = GunaTextBoxCodePetiteCaisseAffectation.Text
            Dim CODE_UTILISATEUR As String = GunaComboBoxUtilisateurDePetite.SelectedValue.ToString
            Dim affectation As New Caisse()

            affectation.affectationCaisse(CODE_CAISSE, CODE_UTILISATEUR)

            GunaDataGridViewUtilisateurDePtiteCaisseAffecte.Columns.Clear()

            GunaDataGridViewUtilisateurDePtiteCaisseAffecte.DataSource = UtilisateurDelaPetiteCaisseSelectionne(CODE_CAISSE)

            GunaButtonSaveAffectation.Visible = True

            'GunaTextBoxCodePetiteCaisseAffectation.Clear()

        End If

    End Sub

    Private Sub GunaComboBoxUtilisateurDePetite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUtilisateurDePetite.SelectedIndexChanged

        If GunaComboBoxUtilisateurDePetite.SelectedIndex >= 0 Then

            Dim caissier As DataTable = Functions.getElementByCode(GunaComboBoxUtilisateurDePetite.SelectedValue.ToString, "utilisateurs", "CODE_UTILISATEUR")
            If caissier.Rows.Count > 0 Then
                GunaTextBoxNomCompletUtilisateurPetiteCaisse.Text = caissier.Rows(0)("CATEG_UTILISATEUR") & " - " & caissier.Rows(0)("NOM_UTILISATEUR")
            End If

        Else
            GunaTextBoxNomCompletUtilisateurPetiteCaisse.Clear()
        End If

    End Sub

    Private Sub GunaButtonAfficherPetiteCaisse_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherPetiteCaisse.Click
        TABLE_NAME = "petite_caisse"
        caisseList(TABLE_NAME)
    End Sub

    Private Sub GunaDataGridViewPetiteCaisse_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPetiteCaisse.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaTextBoxNomCompletUtilisateurPetiteCaisse.Clear()
            GunaTextBoxNomComplet.Clear()

            'AU DOUBLE CLICK CONTROLLER SI L'ELEMENT SUR LEQUEL ON CLIQUE A LE DROIT D'
            GunaButtonGestionPetiteCaisse.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPetiteCaisse.Rows(e.RowIndex)

            Dim caisse As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE CAISSE").Value.ToString), "petite_caisse", "CODE_CAISSE")

            If caisse.Rows.Count > 0 Then

                GunaTextBoxCodePetiteCaisse.Text = caisse.Rows(0)("CODE_CAISSE")
                GunaTextBoxLibellePEtiteCaisse.Text = caisse.Rows(0)("LIBELLE_CAISSE")
                GunaTextBoxMontantPlafonds.Text = Format(caisse.Rows(0)("MONTANT_PLAFONDS"))

                Dim CODE_CAISSE As String = caisse.Rows(0)("CODE_CAISSE")

                GunaTextBoxCodePetiteCaisseAffectation.Text = CODE_CAISSE

                GunaDataGridViewUtilisateurDePtiteCaisseAffecte.Columns.Clear()

                GunaDataGridViewUtilisateurDePtiteCaisseAffecte.DataSource = UtilisateurDelaPetiteCaisseSelectionne(CODE_CAISSE)

                'GunaComboBoxUtilisateurDeCaisse.SelectedValue = caisse.Rows(0)("CODE_UTILISATEUR")
                'GunaComboBoxEtaitCaisse.SelectedItem = caisse.Rows(0)("ETAT_CAISSE")
                ' CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                'Dim caissier As DataTable = Functions.getElementByCode(caisse.Rows(0)("CODE_UTILISATEUR"), "utilisateurs", "CODE_UTILISATEUR")
                'If caissier.Rows.Count > 0 Then
                'GunaTextBoxNomComplet.Text = caissier.Rows(0)("CATEG_UTILISATEUR") & " - " & caissier.Rows(0)("NOM_UTILISATEUR")
                'End If
                'Dim CODE_UTILISATEUR_MODIF As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                'GunaComboBoxTtypeDeCaisse.SelectedItem = caisse.Rows(0)("TYPE_CAISSE")
                'GunaTextBoxCompte.Text = caisse.Rows(0)("NUM_COMPTE")

                If caisse.Rows(0)("ETAT_CAISSE") = 0 Then
                    GunaComboBoxEtaitCaisse.SelectedItem = "Fermée"
                Else
                    GunaComboBoxEtaitCaisse.SelectedItem = "Ouverte"
                End If

                TabControl1.SelectedIndex = 0

            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)



    End Sub
End Class