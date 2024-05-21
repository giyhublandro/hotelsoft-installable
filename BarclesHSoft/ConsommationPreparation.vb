Imports MySql.Data.MySqlClient

Public Class ConsommationPreparation
    Private Sub ConsommationPreparation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        uniteDeConsommation()

    End Sub

    Public Sub uniteDeConsommation()

        'Dim uniteDeComptage As DataTable = Functions.allTableFields("unite_comptage")
        Dim uniteDeComptage As DataTable = Functions.allTableFieldsOnConditionOrganised("unite_comptage", "TYPE", "Consommation", "GRANDE_UNITE")

        If (uniteDeComptage.Rows.Count > 0) Then

            GunaComboBoxUniteDeCompatage.DataSource = uniteDeComptage
            'GunaComboBoxUniteDeCompatage.ValueMember = "CODE_FAMILLE"
            GunaComboBoxUniteDeCompatage.ValueMember = "CODE_UNITE_DE_COMPTAGE"
            GunaComboBoxUniteDeCompatage.DisplayMember = "GRANDE_UNITE"

        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaComboBoxUniteDeCompatage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUniteDeCompatage.SelectedIndexChanged

        Dim CODE_UNITE As String = GunaComboBoxUniteDeCompatage.SelectedValue.ToString

        Dim UNITE As DataTable = Functions.getElementByCode(CODE_UNITE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

        If UNITE.Rows.Count > 0 Then
            GunaTextBoxUniteDeStockage.Text = UNITE.Rows(0)("VALEUR_NUMERIQUE")
        End If

    End Sub

    Private Sub GunaTextBoxBoisson_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxBoisson.TextChanged

        If GunaTextBoxBoisson.Text = "" Then

            GunaDataGridViewExisting.Visible = False

        End If

        'Si l'article n'existe pas alors on efface toute les informations le concernant
        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        getArticleQuery = "SELECT DESIGNATION_FR FROM article WHERE DESIGNATION_FR LIKE '%" & Trim(GunaTextBoxBoisson.Text) & "%' AND TYPE =@TYPE ORDER BY DESIGNATION_FR ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "article"
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaDataGridViewExisting.Visible = True
            GunaDataGridViewExisting.DataSource = table
        Else
            GunaDataGridViewExisting.Columns.Clear()
            GunaDataGridViewExisting.Visible = False
        End If

        If Trim(GunaTextBoxBoisson.Text) = "" Then
            GunaDataGridViewExisting.Visible = False
        End If

    End Sub

    Private Sub GunaDataGridViewExisting_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewExisting.CellContentClick

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewExisting.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE DESIGNATION_FR=@DESIGNATION_FR ORDER BY DESIGNATION_FR ASC"
            Dim adapter As New MySqlDataAdapter
            Dim Article As New DataTable
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@DESIGNATION_FR", MySqlDbType.VarChar).Value = row.Cells("DESIGNATION_FR").Value.ToString

            adapter.SelectCommand = command
            adapter.Fill(Article)

            If (Article.Rows.Count > 0) Then

                'codeArticle = Article.Rows(0)("CODE_ARTICLE")
                'Double.TryParse(GunaTextBoxQuantite.Text, quantite)
                'GunaTextBoxMontantHT.Text = Format(Article.Rows(0)("PRIX_VENTE_HT"), "#,##0")
                'Double.TryParse(GunaTextBoxMontantHT.Text, montant)
                'GunaTextBoxMontantHT.Text = Format(quantite * montant, "#,##0")
                'Double.TryParse(GunaTextBoxTVA.Text, TVA)
                'montantHT = (quantite * montant)
                'GunaTextBoxMontantTTC.Text = Format((montantHT * TVA) / 100 + montantHT, "#,##0")

                'GunaTextBoxSousFamilleArticle.Text = Article.Rows(0)("CODE_SOUS_FAMILLE")

                'GunaTextBoxArticle.Text = Article.Rows(0)("DESIGNATION_FR")
                'GunaTextBoxStock.Text = Article.Rows(0)("QUANTITE")


                If Article.Rows(0)("DESIGNATION_FR") = "CONSOMMATION" Then
                    'ConsommationPreparation.Show()
                Else

                End If

                'GunaDataGridViewArticle.Visible = False

            Else

                'We clear the article field if nothing is found when we click on the custom datagrid
                'clearArticleFields()

            End If

            GunaDataGridViewExisting.Visible = False

        End If

    End Sub

End Class