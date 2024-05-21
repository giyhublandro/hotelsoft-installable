Imports MySql.Data.MySqlClient

Public Class DepenseFamilyForm

    'Dim connect As New DataBaseManipulation()

    Private Sub ArticleFamilyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Functions.AffectingTitleToAForm("PLAN COMPTABLE", GunaLabelGestCompteGeneraux)

        TabControl1.SelectedIndex = 1

    End Sub

    Private Sub plan_comptable()

        Dim FillingListquery As String = "SELECT COMPTE, INTITULE FROM plan_comptable ORDER BY COMPTE ASC"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        GunaDataGridViewPlanComptable.Columns.Clear()

        If tableList.Rows.Count > 0 Then
            GunaDataGridViewPlanComptable.DataSource = tableList
        End If

    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewPlanComptable.Rows.Count > 0 Then

            Dim COMPTE As String = GunaDataGridViewPlanComptable.CurrentRow.Cells("COMPTE").Value.ToString

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supprimer le compte " & COMPTE & " ?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewPlanComptable, GunaDataGridViewPlanComptable.CurrentRow.Cells("COMPTE").Value.ToString, "plan_comptable", "COMPTE")

                GunaDataGridViewPlanComptable.Columns.Clear()

                plan_comptable()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonEnregistrer_Click_1(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim COMPTE As Integer = GunaTextBoxCompte.Text
        Dim OLD_COMPTE As Integer = 0

        If Not Trim(GunaTextBoxOldCompte.Text) = "" Then
            OLD_COMPTE = GunaTextBoxOldCompte.Text
        End If

        Dim INTITULE As String = GunaTextBoxIntitule.Text

        If GunaButtonEnregistrer.Text = "Sauvegarder" Then
            Functions.DeleteElementByCode(OLD_COMPTE, "plan_comptable", "COMPTE")
            GunaButtonEnregistrer.Text = "Enregistrer"
            MessageBox.Show("Compte mise à jours avec succès !!", "Gestion de Compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Compte crée avec succès !!", "Gestion de Compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Dim account As New Compte()

        account.insertPlanComptable(INTITULE, COMPTE)

        TabControl1.SelectedIndex = 1

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        GunaDataGridViewPlanComptable.Visible = True
        plan_comptable()
    End Sub

    Private Sub GunaDataGridViewPlanComptable_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanComptable.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPlanComptable.Rows(e.RowIndex)

            GunaTextBoxOldCompte.Text = row.Cells("COMPTE").Value.ToString
            GunaTextBoxCompte.Text = row.Cells("COMPTE").Value.ToString
            GunaTextBoxIntitule.Text = row.Cells("INTITULE").Value.ToString

            TabControl1.SelectedIndex = 0

        End If

    End Sub

    Private Sub GunaTextBoxRefArticleMatiere_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefCompte.TextChanged

        If GunaCheckBoxSearch.Checked Then

            If Trim(GunaTextBoxRefCompte.Text) = "" Then
                GunaDataGridViewPlanComptable.Columns.Clear()
                GunaDataGridViewPlanComptable.Visible = False
            Else

                GunaDataGridViewPlanComptable.Visible = True

                'REFRESHING information from database for instant visualisation 
                Dim query As String = "SELECT COMPTE, INTITULE FROM plan_comptable WHERE COMPTE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' OR INTITULE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' ORDER BY COMPTE ASC"
                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                If (table.Rows.Count > 0) Then
                    GunaDataGridViewPlanComptable.DataSource = table
                Else
                    GunaDataGridViewPlanComptable.Columns.Clear()
                End If

            End If

        Else
            GunaDataGridViewPlanComptable.Visible = True
        End If

    End Sub

    Private Sub GunaTextBoxCompte_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCompte.TextChanged

        If GunaButtonEnregistrer.Text = "Enregistrer" And Trim(GunaTextBoxIntitule.Text).Equals("") Then
            GunaDataGridViewCompte.Visible = False
        End If

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant

        getArticleQuery = "SELECT COMPTE FROM plan_comptable WHERE COMPTE LIKE '%" & Trim(GunaTextBoxCompte.Text) & "%' ORDER BY COMPTE ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewCompte.Visible = True
            GunaDataGridViewCompte.DataSource = table
        Else
            GunaDataGridViewCompte.Columns.Clear()
            GunaDataGridViewCompte.Visible = False
        End If

        If GunaTextBoxCompte.Text = "" Then
            GunaDataGridViewCompte.Visible = False
        End If

    End Sub

    Private Sub GunaTextBoxIntitule_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxIntitule.TextChanged

        If GunaButtonEnregistrer.Text = "Enregistrer" And Trim(GunaTextBoxIntitule.Text).Equals("") Then
            GunaDataGridViewIntitule.Visible = False
        End If

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant

        getArticleQuery = "SELECT INTITULE FROM plan_comptable WHERE INTITULE LIKE '%" & Trim(GunaTextBoxIntitule.Text) & "%' ORDER BY INTITULE ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            GunaDataGridViewIntitule.Visible = True
            GunaDataGridViewIntitule.DataSource = table
        Else
            GunaDataGridViewIntitule.Columns.Clear()
            GunaDataGridViewIntitule.Visible = False
        End If

        If Trim(GunaTextBoxIntitule.Text) = "" Then
            GunaDataGridViewIntitule.Visible = False
        End If

    End Sub

End Class