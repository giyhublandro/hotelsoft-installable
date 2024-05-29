Imports MySql.Data.MySqlClient

Public Class DepenseFamilyForm

    'Dim connect As New DataBaseManipulation()

    Private Sub ArticleFamilyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If GlobalVariable.typeDeCompte = "exploitation" Then
            Functions.AffectingTitleToAForm("COMPTES D'EXPLOITATIONS", GunaLabelGestCompteGeneraux)
            GunaComboBoxNiveauCompte.Visible = True
            GunaLabel5.Visible = True
        ElseIf GlobalVariable.typeDeCompte = "comptable" Then
            Functions.AffectingTitleToAForm("PLAN COMPTABLE", GunaLabelGestCompteGeneraux)
            GunaComboBoxNiveauCompte.Visible = False
            GunaLabel5.Visible = False
            TabControl1.TabPages.RemoveAt(2)
        End If

        GunaComboBoxNiveauCompte.SelectedIndex = 0
        TabControl1.SelectedIndex = 1

    End Sub

    Private Sub plan_comptable()

        Dim FillingListquery As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then
            FillingListquery = "SELECT COMPTE, INTITULE FROM compte_exploitation ORDER BY COMPTE ASC"
        ElseIf GlobalVariable.typeDeCompte = "comptable" Then
            FillingListquery = "SELECT COMPTE, INTITULE FROM plan_comptable ORDER BY COMPTE ASC"
        End If

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

        Dim COMPTE_PARENT As Integer = 0

        Dim clear As Boolean = False

        If Not Trim(GunaTextBoxCompteParent.Text).Equals("") Then
            If GunaComboBoxNiveauCompte.SelectedIndex = 1 Then
                COMPTE_PARENT = GunaTextBoxCompteParent.Text
            End If
        End If

        Dim OLD_COMPTE As Integer = 0

        If Not Trim(GunaTextBoxOldCompte.Text) = "" Then
            OLD_COMPTE = GunaTextBoxOldCompte.Text
        End If

        Dim INTITULE As String = GunaTextBoxIntitule.Text
        Dim tableName As String = "plan_comptable"

        If GlobalVariable.typeDeCompte = "exploitation" Then
            tableName = "compte_exploitation"
        End If

        If GunaButtonEnregistrer.Text = "Sauvegarder" Then

            Functions.DeleteElementByCode(OLD_COMPTE, tableName, "COMPTE")
            GunaButtonEnregistrer.Text = "Enregistrer"

            clear = True
        Else
            MessageBox.Show("Compte crée avec succès !!", "Gestion de Compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Dim account As New Compte()

        account.insertPlanComptable(INTITULE, COMPTE, COMPTE_PARENT)

        If clear Then

            MessageBox.Show("Compte mise à jours avec succès !!", "Gestion de Compte", MessageBoxButtons.OK, MessageBoxIcon.Information)

            plan_comptable()

            TabControl1.SelectedIndex = 1
            GunaTextBoxCompteParent.Clear()
            GunaTextBoxIntituleCompteParent.Clear()

        End If

        GunaTextBoxCompte.Clear()
        GunaTextBoxIntitule.Clear()
        'TabControl1.SelectedIndex = 1

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

            If GlobalVariable.typeDeCompte = "exploitation" Then

                Dim infoCompte As DataTable = Functions.getElementByCode(GunaTextBoxOldCompte.Text, "compte_exploitation", "COMPTE")

                If infoCompte.Rows.Count > 0 Then

                    If Integer.Parse(infoCompte.Rows(0)("COMPTE_PARENT")) > 0 Then

                        Dim COMPTE_PARENT As Integer = Integer.Parse(infoCompte.Rows(0)("COMPTE_PARENT"))

                        infoCompte = Functions.getElementByCode(COMPTE_PARENT, "compte_exploitation", "COMPTE")

                        If infoCompte.Rows.Count > 0 Then
                            GunaTextBoxCompteParent.Text = COMPTE_PARENT
                            GunaTextBoxIntituleCompteParent.Text = infoCompte.Rows(0)("INTITULE")
                            GunaComboBoxNiveauCompte.Visible = True
                            GunaComboBoxNiveauCompte.SelectedIndex = 1
                            GunaLabel5.Visible = True
                            GunaPanel3.Visible = True
                        End If

                    Else
                        GunaComboBoxNiveauCompte.SelectedIndex = 0
                    End If

                End If

                GunaDataGridViewCompte.Visible = False
                GunaDataGridView2.Visible = False
                GunaDataGridViewIntitule.Visible = False

                GunaComboBoxNiveauCompte.Visible = True

            End If

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

                Dim tableName As String = ""
                If GlobalVariable.typeDeCompte = "comptable" Then
                    tableName = "plan_comptable"
                ElseIf GlobalVariable.typeDeCompte = "exploitation" Then
                    tableName = "compte_exploitation"
                End If

                'REFRESHING information from database for instant visualisation 
                Dim query As String = "SELECT COMPTE, INTITULE FROM " & tableName & " WHERE COMPTE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' OR INTITULE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' ORDER BY COMPTE ASC"
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

        Dim tableName As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then
            tableName = "compte_exploitation"
        Else
            tableName = "plan_comptable"
        End If

        getArticleQuery = "SELECT COMPTE FROM " & tableName & " WHERE COMPTE LIKE '%" & Trim(GunaTextBoxCompte.Text) & "%' ORDER BY COMPTE ASC"

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

        Dim tableName As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then
            tableName = "compte_exploitation"
        Else
            tableName = "plan_comptable"
        End If

        getArticleQuery = "SELECT INTITULE FROM " & tableName & "  WHERE INTITULE LIKE '%" & Trim(GunaTextBoxIntitule.Text) & "%' ORDER BY INTITULE ASC"

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

    Private Sub GunaComboBoxNiveauCompte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNiveauCompte.SelectedIndexChanged

        If GunaComboBoxNiveauCompte.SelectedIndex = 0 Then
            GunaPanel3.Visible = False
        ElseIf GunaComboBoxNiveauCompte.SelectedIndex = 1 Then
            GunaPanel3.Visible = True
        End If

    End Sub

    Private Sub GunaTextBoxIntituleCompteParent_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxIntituleCompteParent.TextChanged

        If Trim(GunaTextBoxIntituleCompteParent.Text).Equals("") Then
            GunaDataGridViewIntitule.Visible = False
        End If

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim compte As String = ""


        compte = "SELECT COMPTE, INTITULE FROM compte_exploitation WHERE INTITULE LIKE '%" & Trim(GunaTextBoxIntituleCompteParent.Text) & "%' OR COMPTE LIKE '%" & Trim(GunaTextBoxIntituleCompteParent.Text) & "%' AND COMPTE_PARENT = 0 ORDER BY INTITULE ASC"

        Dim Command As New MySqlCommand(compte, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            GunaDataGridView2.Visible = True
            GunaDataGridView2.DataSource = table
        Else
            GunaDataGridView2.Columns.Clear()
            GunaDataGridView2.Visible = False
        End If

        If Trim(GunaTextBoxIntituleCompteParent.Text) = "" Then
            GunaDataGridView2.Visible = False
        End If

    End Sub

    Private Sub GunaDataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridView2.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridView2.Rows(e.RowIndex)

            GunaTextBoxCompteParent.Text = row.Cells("COMPTE").Value.ToString
            GunaTextBoxIntituleCompteParent.Text = row.Cells("INTITULE").Value.ToString
            GunaDataGridView2.Visible = False

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 0 Then

            If GlobalVariable.typeDeCompte = "exploitation" Then

                If GunaButtonEnregistrer.Text = "Enregistrer" Then
                    GunaLabel5.Visible = True
                    GunaComboBoxNiveauCompte.Visible = True
                    GunaComboBoxNiveauCompte.SelectedIndex = 0
                End If

            Else

                GunaLabel5.Visible = False
                GunaComboBoxNiveauCompte.Visible = False
                GunaComboBoxNiveauCompte.SelectedIndex = 0

            End If

        End If

    End Sub

    Private Sub compteExploitation()

        Dim FillingListquery As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then

            FillingListquery = "SELECT `CODE`, `CODE_CATEGORY_DEPENSE` AS 'COMPTE', `FAMILLE` AS 'INTITULE', `LIBELLE` AS 'DEPENSE', 
            regroupement_depenses.MONTANT AS 'MONTANT'
            FROM regroupement_depenses, reglement WHERE regroupement_depenses.SOUS_FAMILLE = reglement.NUM_REGLEMENT
            ORDER BY regroupement_depenses.DATE_DE_CONTROLE DESC"

        ElseIf GlobalVariable.typeDeCompte = "comptable" Then
            FillingListquery = "SELECT COMPTE, INTITULE FROM plan_comptable ORDER BY COMPTE ASC"
        End If

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        GunaDataGridView1.Columns.Clear()

        If tableList.Rows.Count > 0 Then
            GunaDataGridView1.DataSource = tableList
            GunaDataGridView1.Columns(0).Visible = False
        Else
            GunaDataGridView1.DataSource = Nothing
        End If

    End Sub


    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        compteExploitation()
    End Sub
End Class