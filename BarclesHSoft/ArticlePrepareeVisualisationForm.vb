Imports MySql.Data.MySqlClient

Public Class ArticlePrepareeVisualisationForm
    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.Close()
    End Sub

    Private Sub ArticlePrepareeVisualisationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.articlePrepareeVisualisation(GlobalVariable.actualLanguageValue)

        listeDesArticlesPreparees()

    End Sub

    Private Sub listeDesArticlesPreparees()

        Dim DateDebut As Date = GlobalVariable.DateDeTravail

        Dim query As String = ""

        Dim CODE_FICHE_TECHNIQUE As String = ArticleForm.GunaTextBoxCodeFicheTechnique.Text

        If GlobalVariable.actualLanguageValue = 0 Then

            query = "SELECT CODE_ARTICLE, CODE_FICHE_TECHNIQUE, NOM_ARTICLE AS 'ITEM', QUANTITE_PREPARE AS 'QUANTITY', PRIX_VENTE AS 'PRICE' FROM fiche_technique_article_prepare WHERE DATE_PREPARATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_FICHE_TECHNIQUE = @CODE_FICHE_TECHNIQUE"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            query = "SELECT CODE_ARTICLE, CODE_FICHE_TECHNIQUE, NOM_ARTICLE AS 'ARTICLE', QUANTITE_PREPARE AS 'QUANTITE', PRIX_VENTE AS 'PRIX VENTE' FROM fiche_technique_article_prepare WHERE DATE_PREPARATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_PREPARATION >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_FICHE_TECHNIQUE = @CODE_FICHE_TECHNIQUE"

        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then

            GunaDataGridViewArticle.DataSource = table

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaDataGridViewArticle.Columns("PRICE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaDataGridViewArticle.Columns("PRIX VENTE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridViewArticle.Columns("PRIX VENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            GunaDataGridViewArticle.Columns("CODE_ARTICLE").Visible = False
            GunaDataGridViewArticle.Columns("CODE_FICHE_TECHNIQUE").Visible = False

            'GunaDataGridViewArticle.Columns("PRIX VENTE").DefaultCellStyle.Format = "n2"

        End If

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub SupprimerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem1.Click

        If GunaDataGridViewArticle.Rows.Count > 0 Then

            Dim CODE_FICHE As String = GunaDataGridViewArticle.CurrentRow.Cells("CODE_FICHE_TECHNIQUE").Value.ToString
            Dim CODE_ARTICLE As String = GunaDataGridViewArticle.CurrentRow.Cells("CODE_ARTICLE").Value.ToString
            Dim LIBELLE_FICHE As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                LIBELLE_FICHE = GunaDataGridViewArticle.CurrentRow.Cells("ITEM").Value.ToString()
                languageMessage = "Do you really want to delete the item : " & LIBELLE_FICHE
                languageTitle = "Delete confirmation"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                LIBELLE_FICHE = GunaDataGridViewArticle.CurrentRow.Cells("ARTICLE").Value.ToString()
                languageMessage = "Voulez-vous vraiment Supprimer l'article: " & LIBELLE_FICHE
                languageTitle = "Demande de suppression"
            End If

            Dim dialog As DialogResult
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                'SUPPRESSION DES LIGNES DE LA FICHE SUPPRIMEE
                Functions.DeleteElementOnTwoConditions(CODE_FICHE, "fiche_technique_article_prepare", "CODE_FICHE_TECHNIQUE", "CODE_ARTICLE", CODE_ARTICLE)

                GunaDataGridViewArticle.Columns.Clear()

                listeDesArticlesPreparees()

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = LIBELLE_FICHE & " succesffully deleted "
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = LIBELLE_FICHE & " supprimé avec succès "
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "No Item to be deleted"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Aucune article à suprimer!"
            End If

            MessageBox.Show(languageMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

End Class