Imports MySql.Data.MySqlClient

Public Class MAgasinForm

    'Dim connect As New DataBaseManipulation()

    Private Sub MAgasinForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TabControl1.SelectedIndex = 1

        'UtilisateurDeMagasin()

        'ListeDesMagasins()

    End Sub

    Public Sub listeDesMagasinsAAfecter()

        Dim query As String = "SELECT CODE_MAGASIN AS 'CODE MAGASIN', LIBELLE_MAGASIN AS 'LIBELLE' From magasin WHERE CODE_AGENCE= @CODE_AGENCE ORDER BY LIBELLE_MAGASIN ASC"

        Dim command1 As New MySqlCommand(query, GlobalVariable.connect)

        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim tableMagasin As New DataTable()

        adapter1.Fill(tableMagasin)

        If (tableMagasin.Rows.Count > 0) Then

            GunaComboBoxMagasinsAAffecter.DataSource = tableMagasin
            GunaComboBoxMagasinsAAffecter.ValueMember = "CODE MAGASIN"
            GunaComboBoxMagasinsAAffecter.DisplayMember = "LIBELLE"

        End If

    End Sub

    Public Sub UtilisateurDeMagasin(ByVal CODE_MAGASIN As String)

        'ON NE CHARGE QUE CEUX QUI ONT DROIT AUX MAGASINS

        '1- CHARGEMENT DE CEUX QUI DROIT SEULEMENT A UN GRAND MAGASIN OU A UN PETIT MAGASIN

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim magasin As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_MAGASIN, "magasin", "CODE_MAGASIN", CODE_AGENCE, "CODE_AGENCE")

        Dim Query As String = ""

        If magasin.Rows.Count > 0 Then

            If Not Trim(magasin.Rows(0)("NOM_PETIT_MAGASIN")) = "" Then
                '1- TRAITEMENT DE PETIT MAGASIN -> SELECTION DES PERSONNES AYANT DROIT AU PETIT MAGASIN
                ' Query = "SELECT DISTINCT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR, PETIT_MAGAZIN , GRAND_MAGAZIN From utilisateurs INNER JOIN utilisateur_acces WHERE utilisateurs.CODE_UTILISATEUR=utilisateur_acces.CODE_UTILISATEUR AND GRAND_MAGAZIN =@GRAND_MAGASIN OR PETIT_MAGAZIN =@PETIT_MAGASIN ORDER BY NOM_UTILISATEUR ASC"

                Query = "SELECT DISTINCT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR, PETIT_MAGAZIN  From utilisateurs, utilisateur_acces WHERE utilisateurs.CATEG_UTILISATEUR=utilisateur_acces.CODE_PROFIL AND PETIT_MAGAZIN =@PETIT_MAGASIN ORDER BY NOM_UTILISATEUR ASC"

            ElseIf Trim(magasin.Rows(0)("NOM_PETIT_MAGASIN")) = "" Then
                '2- TRAITEMENT DE GRAND MAGASIN -> SELECTION DES PERSONNES AYANT DROIT AU GRAND MAGASIN

                Query = "SELECT DISTINCT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR, GRAND_MAGAZIN From utilisateurs, utilisateur_acces WHERE utilisateurs.CATEG_UTILISATEUR=utilisateur_acces.CODE_PROFIL AND GRAND_MAGAZIN =@GRAND_MAGASIN ORDER BY NOM_UTILISATEUR ASC"

            End If

            Dim command As New MySqlCommand(Query, GlobalVariable.connect)
            'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            command.Parameters.Add("@GRAND_MAGASIN", MySqlDbType.Int32).Value = 1
            command.Parameters.Add("@PETIT_MAGASIN", MySqlDbType.Int32).Value = 1

            Dim tableMagasin As New DataTable
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(tableMagasin)

            If (tableMagasin.Rows.Count > 0) Then

                GunaComboBoxUtilisateurDeMagasin.DataSource = tableMagasin
                GunaComboBoxUtilisateurDeMagasin.ValueMember = "CODE_UTILISATEUR"
                GunaComboBoxUtilisateurDeMagasin.DisplayMember = "NOM_UTILISATEUR"

            End If

            'connect.closeConnection()

        End If


    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    'Liste des caisse
    Public Sub ListeDesMagasins()

        Dim query As String = "SELECT CODE_MAGASIN AS 'CODE MAGASIN', LIBELLE_MAGASIN AS 'LIBELLE', GESTION_PAR_LOT AS 'GESTION PAR LOT', TYPE_MAGASIN As 'TYPE DE MAGASIN', ADRESSE From magasin WHERE CODE_AGENCE= @CODE_AGENCE ORDER BY LIBELLE_MAGASIN ASC"

        Dim command1 As New MySqlCommand(query, GlobalVariable.connect)

        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table As New DataTable()

        adapter1.Fill(table)

        If (table.Rows.Count > 0) Then
            DataGridViewMagasin.DataSource = table
        Else
            DataGridViewMagasin.Columns.Clear()
        End If

    End Sub

    'Création et mis à jours d'une caisse
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_MAGASIN As String = CodeMagasin.Text

        Dim NOM_PETIT_MAGASIN As String = ""

        If GunaComboBoxTypeArticle.SelectedIndex >= 0 Then
            NOM_PETIT_MAGASIN = GunaComboBoxTypeArticle.SelectedValue.ToString
        End If

        Dim LIBELLE_MAGASIN As String = GunaTextBoxIntitule.Text
        Dim GESTION_PAR_LOT As String = Trim(GunaComboBoxGestionParLot.SelectedItem)
        Dim ADRESSE As String = GunaTextBoxAdresse.Text
        Dim DATE_CREATION As String = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim DATE_MODIFICATION As String = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_MODIF As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim TYPE_MAGASIN As String = GunaComboBoxTypeDeMagasin.SelectedItem
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim PRIX_UTILISE As Integer = 0
        Dim PRIX_CONSO_UTILISE As Integer = 0

        If GunaComboBoxPrixUtilise.Text = "Prix 1" Then
            PRIX_UTILISE = 1
        ElseIf GunaComboBoxPrixUtilise.Text = "Prix 2" Then
            PRIX_UTILISE = 2
        ElseIf GunaComboBoxPrixUtilise.Text = "Prix 3" Then
            PRIX_UTILISE = 3
        ElseIf GunaComboBoxPrixUtilise.Text = "Prix 4" Then
            PRIX_UTILISE = 4
        End If

        If GunaComboBoxPrixConso.Text = "Prix 1" Then
            PRIX_CONSO_UTILISE = 1
        ElseIf GunaComboBoxPrixConso.Text = "Prix 2" Then
            PRIX_CONSO_UTILISE = 2
        ElseIf GunaComboBoxPrixConso.Text = "Prix 3" Then
            PRIX_CONSO_UTILISE = 3
        ElseIf GunaComboBoxPrixConso.Text = "Prix 4" Then
            PRIX_CONSO_UTILISE = 4
        End If


        Dim CODE_UTILISATEUR As String = ""

        If GunaComboBoxUtilisateurDeMagasin.SelectedIndex >= 0 Then
            CODE_UTILISATEUR = GunaComboBoxUtilisateurDeMagasin.SelectedValue.ToString()
        End If

        Dim economat As New Economat()

        'company verifyfields function
        If (True) Then
            'check if the company alreday exist

            If GunaButtonEnregistrer.Text = "Sauvegarder" Then
                'we update the value after double click
                If economat.update(CODE_MAGASIN, LIBELLE_MAGASIN, GESTION_PAR_LOT, ADRESSE, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, TYPE_MAGASIN, CODE_AGENCE, PRIX_UTILISE, PRIX_CONSO_UTILISE, NOM_PETIT_MAGASIN) Then
                    MessageBox.Show("Magsin mis à jours avec succès", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TabControl1.SelectedIndex = 1
                    'Clearing of fields
                    Functions.ClearTextBox(Me)
                End If

                GunaDataGridViewUtilisateurMagasin.Columns.Clear()

                GunaButtonEnregistrer.Text = "Enregistrer"

                GunaButtonSaveAffectation.Visible = False

            Else

                If Not Trim(CODE_MAGASIN).Equals("") Then

                    If Not Functions.entryCodeExists(CODE_MAGASIN, "magasin", "CODE_MAGASIN") Then
                        If economat.insert(CODE_MAGASIN, LIBELLE_MAGASIN, GESTION_PAR_LOT, ADRESSE, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, TYPE_MAGASIN, CODE_AGENCE, PRIX_UTILISE, PRIX_CONSO_UTILISE, NOM_PETIT_MAGASIN) Then
                            MessageBox.Show("Nouveau magasin enregistré avec succès", "Création ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'Clearing of fields

                            Functions.ClearTextBox(Me)
                        Else
                            MessageBox.Show("Un problème lors de la création !!", "Création ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Ce magasin existe déjà, Essayer à nouveau", "Magasin Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If
                Else

                    MessageBox.Show("Bien vouloir attribuer un code au magasin !!", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        DataGridViewMagasin.Columns.Clear()

        'We refresh the room list
        'ListeDesMagasins()

        MainWindowEconomat.AutoLoadlisteMagasinSource()

        MainWindowEconomat.Activate()

    End Sub

    Private Sub GunaComboBoxUtilisateurDeCaisse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUtilisateurDeMagasin.SelectedIndexChanged

        Dim magasinier As DataTable = Functions.getElementByCode(GunaComboBoxUtilisateurDeMagasin.SelectedValue.ToString, "utilisateurs", "CODE_UTILISATEUR")

        If magasinier.Rows.Count > 0 Then
            GunaButtonSaveAffectation.Visible = True
            GunaTextBoxNomComplet.Text = magasinier.Rows(0)("CATEG_UTILISATEUR") & " - " & magasinier.Rows(0)("NOM_UTILISATEUR")
        End If

    End Sub

    'DELETING A LINE IN DATATGRID
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        'SUPPRESION D'UN MAGASIN
        If DataGridViewMagasin.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supperimer ce magasin: " & DataGridViewMagasin.CurrentRow.Cells("CODE MAGASIN").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(DataGridViewMagasin, DataGridViewMagasin.CurrentRow.Cells("CODE MAGASIN").Value.ToString, "magasin", "CODE_MAGASIN")

                DataGridViewMagasin.Columns.Clear()

                ListeDesMagasins()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    'MODIFICATION DE MAGASIN
    Private Sub DataGridViewCaisseListe_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewMagasin.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonSaveAffectation.Visible = True

            GunaDataGridViewUtilisateurMagasin.Columns.Clear()

            Dim economat As New Economat()

            'AU DOUBLE CLICK CONTROLLER SI L'ELEMENT SUR LEQUEL ON CLIQUE A LE DROIT D'
            GunaButtonEnregistrer.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.DataGridViewMagasin.Rows(e.RowIndex)

            Dim magasin As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE MAGASIN").Value.ToString), "magasin", "CODE_MAGASIN")

            If magasin.Rows.Count > 0 Then

                CodeMagasin.Text = magasin.Rows(0)("CODE_MAGASIN")
                GunaTextBoxIntitule.Text = magasin.Rows(0)("LIBELLE_MAGASIN")
                'GunaComboBoxUtilisateurDeMagasin.SelectedValue = magasin.Rows(0)("CODE_UTILISATEUR")
                GunaComboBoxGestionParLot.SelectedItem = magasin.Rows(0)("GESTION_PAR_LOT")
                GunaTextBoxAdresse.Text = magasin.Rows(0)("ADRESSE")
                GunaTextBoxCodeMagazinAffectation.Text = magasin.Rows(0)("CODE_MAGASIN")
                GunaTextBoxLibelleMagasin.Text = magasin.Rows(0)("LIBELLE_MAGASIN")
                'Dim caissier As DataTable = Functions.getElementByCode(magasin.Rows(0)("CODE_UTILISATEUR"), "utilisateurs", "CODE_UTILISATEUR")
                'If caissier.Rows.Count > 0 Then
                'GunaTextBoxNomComplet.Text = caissier.Rows(0)("CATEG_UTILISATEUR") & " - " & caissier.Rows(0)("NOM_UTILISATEUR")
                'End If
                'Dim CODE_UTILISATEUR_MODIF As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                GunaComboBoxTypeDeMagasin.SelectedItem = magasin.Rows(0)("TYPE_MAGASIN")

                If Trim(magasin.Rows(0)("TYPE_MAGASIN")) = "Petit magasin" Then
                    'GunaComboBoxTypeArticle.Visible = True
                    GunaComboBoxTypeArticle.SelectedItem = magasin.Rows(0)("NOM_PETIT_MAGASIN")
                Else
                    GunaComboBoxTypeArticle.Visible = False
                End If

                If magasin.Rows(0)("PRIX_UTILISE") = 1 Then
                    GunaComboBoxPrixUtilise.SelectedItem = "Prix 1"
                ElseIf magasin.Rows(0)("PRIX_UTILISE") = 2 Then
                    GunaComboBoxPrixUtilise.SelectedItem = "Prix 2"
                ElseIf magasin.Rows(0)("PRIX_UTILISE") = 3 Then
                    GunaComboBoxPrixUtilise.SelectedItem = "Prix 3"
                ElseIf magasin.Rows(0)("PRIX_UTILISE") = 4 Then
                    GunaComboBoxPrixUtilise.SelectedItem = "Prix 4"
                End If

                If magasin.Rows(0)("PRIX_CONSO_UTILISE") = 1 Then
                    GunaComboBoxPrixConso.SelectedItem = "Prix 1"
                ElseIf magasin.Rows(0)("PRIX_CONSO_UTILISE") = 2 Then
                    GunaComboBoxPrixConso.SelectedItem = "Prix 2"
                ElseIf magasin.Rows(0)("PRIX_CONSO_UTILISE") = 3 Then
                    GunaComboBoxPrixConso.SelectedItem = "Prix 3"
                ElseIf magasin.Rows(0)("PRIX_CONSO_UTILISE") = 4 Then
                    GunaComboBoxPrixConso.SelectedItem = "Prix 4"
                End If

                TabControl1.SelectedIndex = 0

            End If

        End If

        'GunaDataGridViewUtilisateurMagasin.Columns.Clear()

    End Sub

    '-----------------------------------------LIVE SEARCH IMPLEMENTATION----------------------------------------------------

    'Reorganise when we enter the button for search
    Private Sub GunaTextBoxcCode_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT CODE_MAGASIN AS 'CODE MAGASIN', LIBELLE_MAGASIN AS 'LIBELLE', GESTION_PAR_LOT AS 'GESTION PAR LOT', TYPE_MAGASIN As 'TYPE DE MAGASIN', ADRESSE From magasin INNER JOIN utilisateurs WHERE CODE_AGENCE= @CODE_AGENCE ORDER BY LIBELLE_MAGASIN ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewMagasin.DataSource = table

        Else
            DataGridViewMagasin.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.Close()
    End Sub

    'Affectation de magasin a un utilisateur
    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButtonSaveAffectation.Click


        If Not Trim(GunaTextBoxCodeMagazinAffectation.Text) = "" Then

            Dim CODE_MAGASIN As String = GunaTextBoxCodeMagazinAffectation.Text
            Dim CODE_UTILISATEUR As String = GunaComboBoxUtilisateurDeMagasin.SelectedValue.ToString
            Dim affectation As New Economat()

            affectation.affectationMagasin(CODE_MAGASIN, CODE_UTILISATEUR)

            GunaDataGridViewUtilisateurMagasin.Columns.Clear()

            GunaDataGridViewUtilisateurMagasin.DataSource = affectation.ListeDesUtilisateursDuMagasin(GunaTextBoxCodeMagazinAffectation.Text)

            GunaButtonSaveAffectation.Visible = False

        End If

    End Sub

    'Suppression des utilisateurs affecté a un magasin

    Private Sub SupprimerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem1.Click

        If GunaDataGridViewUtilisateurMagasin.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supperimer ce magasin: " & GunaDataGridViewUtilisateurMagasin.CurrentRow.Cells("CODE MAGASIN").Value.ToString & "?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewUtilisateurMagasin, GunaDataGridViewUtilisateurMagasin.CurrentRow.Cells("CODE UTILISATEUR").Value.ToString, "utilisateur_magazin", "CODE_UTILISATEUR", "CODE_MAGAZIN", GunaDataGridViewUtilisateurMagasin.CurrentRow.Cells("CODE MAGASIN").Value.ToString)

                GunaDataGridViewUtilisateurMagasin.Columns.Clear()

                Dim economat As New Economat()
                GunaDataGridViewUtilisateurMagasin.DataSource = economat.ListeDesUtilisateursDuMagasin(GunaTextBoxCodeMagazinAffectation.Text)

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        DataGridViewMagasin.Columns.Clear()
        ListeDesMagasins()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        GunaButtonEnregistrer.Visible = False

        If TabControl1.SelectedIndex = 2 Then
            listeDesMagasinsAAfecter()
        ElseIf TabControl1.SelectedIndex = 0 Then
            GunaButtonEnregistrer.Visible = True
        Else
            GunaTextBoxCodeMagazinAffectation.Clear()
        End If
        'DataGridViewMagasin.Columns.Clear()
    End Sub

    'Au changement du type de magasin: central ou petit magasin
    Private Sub GunaComboBoxTypeDeMagasin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeMagasin.SelectedIndexChanged, GunaComboBoxPrixUtilise.SelectedIndexChanged, GunaComboBoxPrixConso.SelectedIndexChanged

        If GunaComboBoxTypeDeMagasin.SelectedItem = "Petit magasin" Then

            'GunaLabel13.Visible = True
            'GunaComboBoxTypeArticle.Visible = True

            Dim tableFamille As DataTable = Functions.allTableFields("famille")

            If (tableFamille.Rows.Count > 0) Then

                GunaComboBoxTypeArticle.DataSource = tableFamille
                'GunaComboBoxTypeArticle.ValueMember = "CODE_FAMILLE"
                GunaComboBoxTypeArticle.ValueMember = "LIBELLE_FAMILLE"
                GunaComboBoxTypeArticle.DisplayMember = "LIBELLE_FAMILLE"

            End If

        Else

            GunaLabel13.Visible = False
            GunaComboBoxTypeArticle.Visible = False

        End If

    End Sub

    Private Sub GunaComboBoxMagasinsAAffecter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxMagasinsAAffecter.SelectedIndexChanged

        If GunaComboBoxMagasinsAAffecter.SelectedIndex >= 0 Then

            Dim CODE_MAGASIN As String = GunaComboBoxMagasinsAAffecter.SelectedValue.ToString()
            GunaTextBoxCodeMagazinAffectation.Text = CODE_MAGASIN

            GunaDataGridViewUtilisateurMagasin.Columns.Clear()

            UtilisateurDeMagasin(CODE_MAGASIN) ' CHARGEMENT DE UTILISATEURS DU MAGAINS ACTUEL

            Dim ListeDesaffectation As New Economat()

            GunaDataGridViewUtilisateurMagasin.DataSource = ListeDesaffectation.ListeDesUtilisateursDuMagasin(CODE_MAGASIN)

        End If

    End Sub

End Class