Public Class priceDetailForm
    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub priceDetailForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dt As DataGridView = MainWindowEconomat.GunaDataGridViewLigneArticleCommande

        GunaDataGridViewHistoriquesDesPRix.Columns.Add("ARTICLE", "ARTICLE")
        GunaDataGridViewHistoriquesDesPRix.Columns.Add("PRIX LE PLUS BAS", "PRIX LE PLUS BAS")
        GunaDataGridViewHistoriquesDesPRix.Columns.Add("DERNIER PRIX", "DERNIER PRIX")
        GunaDataGridViewHistoriquesDesPRix.Columns.Add("PRIX MOYEN", "PRIX MOYEN")

        Dim CODE_ARTICLE As String = ""
        Dim NOM_ARTICLE As String = ""
        Dim BAS_PRIX As Double = 0
        Dim DERNIER_PRIX As Double = 0
        Dim MOYENNE_PRIX As Double = 0

        Dim economat As New Economat()
        If dt.Rows.Count > 0 Then

            For i = 0 To dt.Rows.Count - 1

                CODE_ARTICLE = dt.Rows(i).Cells("CODE ARTICLE").Value.ToString
                NOM_ARTICLE = dt.Rows(i).Cells("DESIGNATION").Value.ToString

                BAS_PRIX = economat.historiquesArticlePlusHautBasPrix(CODE_ARTICLE, 0)
                DERNIER_PRIX = economat.historiquesArticlePlusHautBasPrix(CODE_ARTICLE, 1)
                MOYENNE_PRIX = economat.historiquesArticlePlusHautBasPrix(CODE_ARTICLE, 2)

                GunaDataGridViewHistoriquesDesPRix.Rows.Add(NOM_ARTICLE, Format(BAS_PRIX, "#,##0"), Format(DERNIER_PRIX, "#,##0"), Format(MOYENNE_PRIX, "#,##0"))

            Next

        End If

    End Sub


End Class