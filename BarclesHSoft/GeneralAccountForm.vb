Imports MySql.Data.MySqlClient

Public Class GeneralAccountForm

    'Dim connect As New DataBaseManipulation()

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Close()
    End Sub

    'Total number of entries
    Function TotalNumberOfElementsInTable(ByVal tableToCountElements As String) As Integer

        Dim existQuery As String = "SELECT * From " & tableToCountElements

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            Return table.Rows.Count
        Else
            'Connect.closeConnection()
            Return 0
        End If

    End Function

    Private Sub ListeDesComptes()

        Dim query1 As String = "SELECT `INTITULE`, `NUMERO_COMPTE` As 'NUMERO COMPTE', `CODE_CLIENT` AS NOM , `TOTAL_DEBIT` As 'TOTAL DEBIT', `TOTAL_CREDIT` As 'TOTAL CREDIT', `SOLDE_COMPTE` AS 'SOLDE COMPTE', compte.DATE_CREATION AS 'DATE CREATION', `TYPE_DE_COMPTE` As 'TYPE DE COMPTE', `SENS_DU_SOLDE` As 'SENS DU SOLDE'  FROM `compte` WHERE ETAT_DU_COMPTE = @ETAT_DU_COMPTE1 ORDER BY NUMERO_COMPTE ASC"

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@ETAT_DU_COMPTE1", MySqlDbType.Int64).Value = 1
        command1.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = ""

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()

        adapter1.Fill(table1)

        'table.Merge(table1)

        If (table1.Rows.Count > 0) Then

            DataGridViewListeDesComptes.DataSource = table1
            GunaTextBoxIntituleCompte.Clear()
            GunaTextBoxNumCompte.Clear()

        End If

    End Sub

    Private Sub GunaButtonAjouterCompte_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterCompte.Click

        'COMPTE DU BAR RESTAURANT : PM1001

        Dim NUMERO_COMPTE = GunaTextBoxNumCompte.Text

        Dim INTITULE = GunaTextBoxIntituleCompte.Text
        Dim TOTAL_DEBIT = 0
        Dim TOTAL_CREDIT = 0
        Dim SOLDE_COMPTE = 0
        Dim DATE_CREATION = Date.Now()

        Dim TYPE_DE_COMPTE = ""
        If GunaComboBoxTypeCompte.SelectedIndex >= 0 Then
            TYPE_DE_COMPTE = GunaComboBoxTypeCompte.SelectedItem
        End If

        Dim SENS_DU_SOLDE = ""
        If GunaComboBoxSensSolde.SelectedIndex >= 0 Then
            SENS_DU_SOLDE = GunaComboBoxSensSolde.SelectedItem
        End If

        Dim ETAT_DU_COMPTE As Integer = 0

        If GunaCheckBoxActivationDesactivationDuCompte.Checked Then
            ETAT_DU_COMPTE = 1
        Else
            ETAT_DU_COMPTE = 0
        End If

        Dim PERSONNE_A_CONTACTER = Trim(GunaTextBoxPersonneAContacter.Text)
        Dim CONTACT_PAIEMENT = Trim(GunaTextBoxContactPourPaiement.Text)
        Dim ADRESSE_DE_FACTURATION = Trim(GunaTextBoxAdresseDeFacturation.Text)
        Dim PLAFONDS_DU_COMPTE As String = Double.Parse(GunaTextBoxMontantPlafondsDuCompte.Text)

        Dim DELAI_DE_PAIEMENT = Trim(NumericUpDownDelaiDePaiement.Text)

        Dim account As New GeneralAccount()

        'company verifyfields function
        If (True) Then

            'Code field empty, then it is a new entry
            If (GunaButtonAjouterCompte.Text.Trim().Equals("Enregistrer")) Then
                'check if the new entry  alreaday exist before insertion
                If Not account.accountExists(NUMERO_COMPTE, INTITULE) Then
                    'As the new entry does not exist then we insert it, and check the result
                    If account.Insert(INTITULE, NUMERO_COMPTE, TOTAL_DEBIT, TOTAL_CREDIT, SOLDE_COMPTE, DATE_CREATION, TYPE_DE_COMPTE, SENS_DU_SOLDE, PLAFONDS_DU_COMPTE, ETAT_DU_COMPTE, PERSONNE_A_CONTACTER, CONTACT_PAIEMENT, ADRESSE_DE_FACTURATION, DELAI_DE_PAIEMENT) Then
                        MessageBox.Show("Nouveau compte enregistré avec succès", "Création de compte", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'We empty the fields

                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création de compte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Ce compte  existe déjà, Essayer à nouveau", "Création d'une categorie clientde compte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                'label field not empty so, we update the existing entry using the code
                If Not (GunaTextBoxIntituleCompte.Text.Trim.Equals("")) Then

                    If account.Update(INTITULE, NUMERO_COMPTE, TOTAL_DEBIT, TOTAL_CREDIT, SOLDE_COMPTE, DATE_CREATION, TYPE_DE_COMPTE, SENS_DU_SOLDE, PLAFONDS_DU_COMPTE, ETAT_DU_COMPTE, PERSONNE_A_CONTACTER, CONTACT_PAIEMENT, ADRESSE_DE_FACTURATION, DELAI_DE_PAIEMENT) Then
                        MessageBox.Show("Compte Mise à jour !! avec succès", "Création de compte", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        GunaButtonAjouterCompte.Text = "Enregistrer"

                    Else

                        MessageBox.Show("Problème lors de la misa à jour du Compte!!", "Mise à du compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Remplir tous les champs!!", "Mise à du compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création d'une categorie client", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        GunaComboBoxTypeCompte.SelectedItem = -1
        GunaComboBoxSensSolde.SelectedItem = -1

        TabControl1.SelectedIndex = 1

        Functions.SiplifiedClearTextBox(Me)

        NumericUpDownDelaiDePaiement.Text = 0
        GunaTextBoxMontantPlafondsDuCompte.Text = 0


    End Sub

    '--------------------------- FILL INPUT WITH DATA FROM DATAGRID FOR UPDAT---------------------------
    'Taking data from datagridView and insert into textBox for update
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewListeDesComptes.CellDoubleClick

        GunaButtonAjouterCompte.Text = "Sauvegarder"

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow
            row = Me.DataGridViewListeDesComptes.Rows(e.RowIndex)

            GunaTextBoxIntituleCompte.Text = row.Cells("INTITULE").Value.ToString
            GunaComboBoxTypeCompte.SelectedItem = Trim(row.Cells("TYPE DE COMPTE").Value.ToString)
            GunaComboBoxSensSolde.SelectedItem = Trim(row.Cells("SENS DU SOLDE").Value.ToString)
            GunaTextBoxNumCompte.Text = Trim(row.Cells("NUMERO COMPTE").Value.ToString)

            'ATTRIBUTION DES INFORMATION DE COMPTE FINANCE

            Dim compte As DataTable = Functions.getElementByCode(Trim(GunaTextBoxNumCompte.Text), "compte", "NUMERO_COMPTE")

            If compte.Rows.Count > 0 Then

                GunaTextBoxPersonneAContacter.Text = Trim(compte.Rows(0)("PERSONNE_A_CONTACTER")) ' INTITULE DE COMPTE
                GunaTextBoxContactPourPaiement.Text = Trim(compte.Rows(0)("CONTACT_PAIEMENT")) ' INTITULE DE COMPTE
                GunaTextBoxAdresseDeFacturation.Text = Trim(compte.Rows(0)("ADRESSE_DE_FACTURATION")) ' INTITULE DE COMPTE

                GunaTextBoxMontantPlafondsDuCompte.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0")

                NumericUpDownDelaiDePaiement.Text = Trim(compte.Rows(0)("DELAI_DE_PAIEMENT"))

                If compte.Rows(0)("ETAT_DU_COMPTE") = 1 Then
                    GunaCheckBoxActivationDesactivationDuCompte.Checked = True
                Else
                    GunaCheckBoxActivationDesactivationDuCompte.Checked = False
                End If

            End If

            TabControl1.SelectedIndex = 0

        End If

    End Sub

    Private Sub GeneralAccountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        ListeDesComptes()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        DataGridViewListeDesComptes.Columns.Clear()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    '--------------------------------- END LIVE SEARCH -------------------------------------------

End Class