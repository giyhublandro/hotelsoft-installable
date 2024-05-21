Imports MySql.Data.MySqlClient

Public Class MiniSageNouveauDocumentComptableForm
    Private Sub MiniSageNouveauDocumentComptableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaTextBoxRaisonSociale.Text = GlobalVariable.societe.Rows(0)("RAISON_SOCIALE")

    End Sub

    Private Sub Enregistrer_Click_1(sender As Object, e As EventArgs) Handles Enregistrer.Click

        'Enregistrement du dossier comptable

    End Sub

    Private Sub GunaTextBoxCompteIntitule_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCompteIntitule.TextChanged

        If Not Trim(GunaTextBoxCompteIntitule.Text).Equals("") Then

            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Dim getArticleQuery As String = ""

            'Si l'article n'existe pas alors on efface toute les informations le concernant

            getArticleQuery = "SELECT COMPTE, INTITULE FROM plan_comptable WHERE COMPTE LIKE '%" & Trim(GunaTextBoxCompteIntitule.Text) & "%' OR INTITULE LIKE '%" & Trim(GunaTextBoxCompteIntitule.Text) & "%' ORDER BY COMPTE ASC"

            Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
            adapter.SelectCommand = Command
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaDataGridViewPlanComptable.Visible = True
                GunaDataGridViewPlanComptable.DataSource = table
            Else
                GunaDataGridViewPlanComptable.Columns.Clear()
                GunaDataGridViewPlanComptable.Visible = False
            End If

            If GunaTextBoxCompteIntitule.Text = "" Then
                GunaDataGridViewPlanComptable.Visible = False
            End If

        Else

            planComptable()

        End If

    End Sub

    Private Sub planComptable()

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant

        getArticleQuery = "SELECT COMPTE, INTITULE FROM plan_comptable ORDER BY COMPTE ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        GunaDataGridViewPlanComptable.Columns.Clear()

        If table.Rows.Count > 0 Then
            GunaDataGridViewPlanComptable.Visible = True
            GunaDataGridViewPlanComptable.DataSource = table
        Else
            GunaDataGridViewPlanComptable.Columns.Clear()
            GunaDataGridViewPlanComptable.Visible = False
        End If
    End Sub

    Private Sub GunaDataGridViewPlanComptable_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanComptable.CellDoubleClick

        'AFFICHAGE DE LA FENETRE PORTANT LE NOM DU COMPTE

        If e.RowIndex >= 0 Then

            GunaPanelAddComptePlanComptable.Visible = True
            GunaPanelRecherchePlanComptablePanel.Visible = False

            GunaButtonAjouterCompte.Text = "Modifier"

            Dim row As DataGridViewRow
            row = Me.GunaDataGridViewPlanComptable.Rows(e.RowIndex)

            GunaTextBoxIntiule.Text = row.Cells("INTITULE").Value.ToString
            GunaTextBoxCompteDelete.Text = row.Cells("COMPTE").Value.ToString
            GunaTextBoxNumCompte.Text = row.Cells("COMPTE").Value.ToString

            GunaTextBoxCompteIntitule.Clear()

        End If

    End Sub

    Private Sub AjouterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterToolStripMenuItem.Click

        If TabControlPlan.SelectedIndex = 0 Then

            Me.Text = "Ajouter un compte" 'DANS LE PLAN COMPTABLE

            Me.GunaPanelPlan.BringToFront()
            GunaPanelAddComptePlanComptable.Visible = True
            GunaPanelRecherchePlanComptablePanel.Visible = False

        ElseIf TabControlPlan.SelectedIndex = 1 Then

            'PLAN TIERS

            TabControlPlan.SelectedIndex = 3

        ElseIf TabControlPlan.SelectedIndex = 2 Then

            'PLAN ANALYTIQUE

            TabControlPlan.SelectedIndex = 4

        End If


    End Sub

    Private Sub GunaButtonAjouterCompte_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterCompte.Click

        'Ajouter un nouveau compte

        Dim ecritureComptable As New EcritureComptable()

        Dim COMPTE As String = GunaTextBoxNumCompte.Text
        Dim COMPTE_A_SUPPRIMER As String = GunaTextBoxCompteDelete.Text
        Dim INTITULE As String = GunaTextBoxIntiule.Text
        Dim message As String = ""

        If GunaButtonAjouterCompte.Text = "Ajouter" Then

            Dim infoCompte As DataTable = Functions.getElementByCode(COMPTE, "plan_comptable", "COMPTE")

            If infoCompte.Rows.Count > 0 Then
                message = "Ce numéro de coompte existe déjà !!"
            Else
                infoCompte = Functions.getElementByCode(INTITULE, "plan_comptable", "INTITULE")

                If infoCompte.Rows.Count > 0 Then
                    message = "Cet intitulé de compte existe déjà !!"
                Else

                    GunaPanelAddComptePlanComptable.Visible = False
                    GunaPanelRecherchePlanComptablePanel.Visible = True

                    ecritureComptable.InsertCompte(COMPTE, INTITULE)
                    message = "Nouveau compte ajouté avec succès !!"

                    GunaTextBoxNumCompte.Clear()
                    GunaTextBoxIntiule.Clear()
                    planComptable()
                End If

            End If

        Else

            Functions.DeleteElementByCode(COMPTE_A_SUPPRIMER, "plan_comptable", "COMPTE")

            ecritureComptable.InsertCompte(COMPTE, INTITULE)

            GunaPanelAddComptePlanComptable.Visible = False
            GunaPanelRecherchePlanComptablePanel.Visible = True

            planComptable()

            GunaTextBoxNumCompte.Clear()
            GunaTextBoxIntiule.Clear()
            GunaTextBoxCompteDelete.Clear()

            message = "Compte modifié avec succès !!"

        End If

        MessageBox.Show(message, "Plan comptable", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub SupprimerLélémentSélectionnéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerLélémentSélectionnéToolStripMenuItem.Click

        If TabControlPlan.SelectedIndex = 0 Then

            'DANS LE PLAN COMPTABLE 

            Dim COMPTE As String = GunaDataGridViewPlanComptable.CurrentRow.Cells("COMPTE").Value.ToString

            Dim INTITULE As String = GunaDataGridViewPlanComptable.CurrentRow.Cells("INTITULE").Value.ToString

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment supprimer le compte " & COMPTE & " " & INTITULE & " ?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If Not dialog = DialogResult.No Then
                Functions.DeleteRowFromDataGrid(GunaDataGridViewPlanComptable, COMPTE, "plan_comptable", "COMPTE")

                planComptable()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        ElseIf TabControlPlan.SelectedIndex = 1 Then

        ElseIf TabControlPlan.SelectedIndex = 2 Then

        End If

    End Sub

    Private Sub GunaComboBoxTypeJournal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeJournal.SelectedIndexChanged

        If GunaComboBoxTypeJournal.SelectedIndex = 2 Then
            'PERMET LA CONFIG DES JOURNAUX DE TYPES TRESORERIE
            GunaPanelConfiTypeTresorerie.Visible = True
            GunaPanelConfiTypeTresorerie.BringToFront()


            Dim classDuCompte As String = "5"
            Dim ecritureComptable As New EcritureComptable()

            ecritureComptable.compteDeClasseSpecifiqueDuPlan(classDuCompte, GunaComboBoxCompteTresorerie)

        Else
            GunaPanelConfiTypeTresorerie.Visible = False
        End If

    End Sub

    Private Sub GunaComboBoxCompteTresorerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCompteTresorerie.SelectedIndexChanged

        'ON SELECTIONNE LE NUMERO DE COMPTE

        If GunaComboBoxCompteTresorerie.SelectedIndex >= 0 Then
            GunaTextBoxNumCompteTresorerie.Text = GunaComboBoxCompteTresorerie.SelectedValue.ToString
        End If

    End Sub

    Private Sub GunaDataGridViewJournauxDeSaisie_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewJournauxDeSaisie.CellDoubleClick

        If e.RowIndex >= 0 Then

            TabControlJournauxDeSaisie.SelectedIndex = 1

        End If

    End Sub


End Class