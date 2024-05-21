Imports MySql.Data.MySqlClient

Public Class EliteClubForm

    'Dim connect As New DataBaseManipulation()

    Private Sub ArticleGroupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If GlobalVariable.actualLanguageValue = 1 Then

            GunaDataGridView1.Columns.Add("CONFIGURATIONS", "CONFIGURATIONS")
            GunaDataGridView1.Columns.Add("SILVER", "SILVER")
            GunaDataGridView1.Columns.Add("GOLD", "GOLD")
            GunaDataGridView1.Columns.Add("PLATINUM", "PLATINUM")

        Else

            GunaDataGridView1.Columns.Add("SETTINGS", "SETTINGS")
            GunaDataGridView1.Columns.Add("SILVER", "SILVER")
            GunaDataGridView1.Columns.Add("GOLD", "GOLD")
            GunaDataGridView1.Columns.Add("PLATINUM", "PLATINUM")

        End If

        Dim elite As DataTable = Functions.allTableFieldsOrganised("club_elite_membre", "ID_CLUB_ELITE_MEMBRE")

        If elite.Rows.Count > 0 Then

            Dim j = 0

            For i = 2 To elite.Columns.Count - 1

                If GlobalVariable.actualLanguageValue = 1 Then

                    If (i = 2) Then
                        GunaDataGridView1.Rows.Add("ELIGIBILITE EN NUITS", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 3) Then
                        GunaDataGridView1.Rows.Add("ELIGIBILITE EN SEJOURS", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 4) Then
                        GunaDataGridView1.Rows.Add("ELIGIBILITE EN POINTS", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 5) Then
                        GunaDataGridView1.Rows.Add("REDUCTION ACCORDEE (%)", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 6) Then
                        GunaDataGridView1.Rows.Add("VALEUR FINANCIERE DU POINT", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 7) Then
                        GunaDataGridView1.Rows.Add("PALIER DE DEPENSE", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 8) Then
                        GunaDataGridView1.Rows.Add("POINT PAR PALIER DE DEPENSE", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 9) Then
                        GunaDataGridView1.Rows.Add("NUITEES = UNE NUITEE", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 10) Then
                        GunaDataGridView1.Rows.Add("SEJOURS = UNE NUITEE", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    End If

                Else

                    If (i = 2) Then
                        GunaDataGridView1.Rows.Add("ELIGIBILITY IN NIGHTS", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 3) Then
                        GunaDataGridView1.Rows.Add("ELIGIBILITY IN STAYS", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 4) Then
                        GunaDataGridView1.Rows.Add("ELIGIBILITY IN POINTS", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 5) Then
                        GunaDataGridView1.Rows.Add("DISCOUNT GRANTED (%)", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 6) Then
                        GunaDataGridView1.Rows.Add("POINT FINANCIAL VALUE", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 7) Then
                        GunaDataGridView1.Rows.Add("INTERVAL OF EXPEND", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 8) Then
                        GunaDataGridView1.Rows.Add("POINT PER INTERVAL OF EXPEND", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 9) Then
                        GunaDataGridView1.Rows.Add("NIGHTS = ONE NIGHT", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    ElseIf (i = 10) Then
                        GunaDataGridView1.Rows.Add("STAY = ONE NIGHT", elite.Rows(j)(i), elite.Rows(j + 1)(i), elite.Rows(j + 2)(i))
                    End If

                End If

            Next

        Else

            If GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridView1.Rows.Add("ELIGIBILITE EN NUITS", 0, 15, 30)
                GunaDataGridView1.Rows.Add("ELIGIBILITE EN SEJOURS", 0, 5, 15)
                GunaDataGridView1.Rows.Add("ELIGIBILITE EN POINTS", 0, 10000, 20000)
                GunaDataGridView1.Rows.Add("REDUCTION ACCORDEE (%)", 5, 10, 15)
                GunaDataGridView1.Rows.Add("VALEUR FINANCIERE DU POINT", 25, 25, 25)
                GunaDataGridView1.Rows.Add("A DEPENSER POUR DES POINTS", 1000, 1000, 1000)
                GunaDataGridView1.Rows.Add("POINT PAR PALIER DE DEPENSE", 40, 50, 70)
                GunaDataGridView1.Rows.Add("NUITEES = UNE NUITEE", 10, 10, 10)
                GunaDataGridView1.Rows.Add("SEJOURS = UNE NUITEE", 5, 5, 5)

            Else

                GunaDataGridView1.Rows.Add("ELIGIBILITY IN NIGHTS", 0, 15, 30)
                GunaDataGridView1.Rows.Add("ELIGIBILITY IN STAYS", 0, 5, 15)
                GunaDataGridView1.Rows.Add("ELIGIBILITY IN POINTS", 0, 10000, 20000)
                GunaDataGridView1.Rows.Add("DISCOUNT GRANTED (%)", 5, 10, 15)
                GunaDataGridView1.Rows.Add("POINT FINANCIAL VALUE", 25, 25, 25)
                GunaDataGridView1.Rows.Add("INTERVAL OF EXPEND", 1000, 1000, 1000)
                GunaDataGridView1.Rows.Add("POINT PER INTERVAL OF EXPEND", 40, 50, 70)
                GunaDataGridView1.Rows.Add("NIGHTS = ONE NIGHT", 10, 10, 10)
                GunaDataGridView1.Rows.Add("STAY = ONE NIGHTE", 5, 5, 5)

            End If

        End If

        GunaDataGridView1.Columns(0).ReadOnly = True
        GunaDataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Close()
    End Sub

    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim message As String = ""
        Dim title As String = ""

        Dim query As String = "SELECT * FROM club_elite_membre"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim elite As New ClubElite()

        If Not table.Rows.Count > 0 Then

            For i = 1 To GunaDataGridView1.Columns.Count - 1

                Dim MEMBRE As String = ""

                If i = 1 Then
                    MEMBRE = "SILVER"
                ElseIf i = 2 Then
                    MEMBRE = "GOLD"
                ElseIf i = 3 Then
                    MEMBRE = "PLATINUM"
                End If

                Dim ELIGIBILITE_NUITS As Integer = GunaDataGridView1.Rows(0).Cells(i).Value
                Dim ELIGIBILITE_POINTS As Integer = GunaDataGridView1.Rows(1).Cells(i).Value
                Dim ELIGIBILITE_SEJOURS As Integer = GunaDataGridView1.Rows(2).Cells(i).Value
                Dim REDUCTION_ACCORDEE As Double = GunaDataGridView1.Rows(3).Cells(i).Value
                Dim VAEUR_DU_POINT As Double = GunaDataGridView1.Rows(4).Cells(i).Value
                Dim PALIER_DE_DEPENSE As Double = GunaDataGridView1.Rows(5).Cells(i).Value
                Dim POINT_PAR_PALIER_DE_DEPENSE As Integer = GunaDataGridView1.Rows(6).Cells(i).Value
                Dim NOMBRE_NUITEE_EGALE_A_UNE_NUITEE As Integer = GunaDataGridView1.Rows(7).Cells(i).Value
                Dim NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE As Integer = GunaDataGridView1.Rows(8).Cells(i).Value

                elite.insertConfigElite(MEMBRE, ELIGIBILITE_NUITS, ELIGIBILITE_POINTS, ELIGIBILITE_SEJOURS, REDUCTION_ACCORDEE, VAEUR_DU_POINT, PALIER_DE_DEPENSE, POINT_PAR_PALIER_DE_DEPENSE, NOMBRE_NUITEE_EGALE_A_UNE_NUITEE, NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE)

            Next

            If GlobalVariable.actualLanguageValue = 1 Then
                message = "Configurations du CLub ELite crées avec succès"
                title = "Club Elite "
            Else
                message = "ELite Club Settings successfully created"
                title = "Elite Club"
            End If

        Else

            For i = 1 To GunaDataGridView1.Columns.Count - 1

                Dim MEMBRE As String = ""

                If i = 1 Then
                    MEMBRE = "SILVER"
                ElseIf i = 2 Then
                    MEMBRE = "GOLD"
                ElseIf i = 3 Then
                    MEMBRE = "PLATINUM"
                End If

                Dim ELIGIBILITE_NUITS As Integer = GunaDataGridView1.Rows(0).Cells(i).Value
                Dim ELIGIBILITE_POINTS As Integer = GunaDataGridView1.Rows(1).Cells(i).Value
                Dim ELIGIBILITE_SEJOURS As Integer = GunaDataGridView1.Rows(2).Cells(i).Value
                Dim REDUCTION_ACCORDEE As Double = GunaDataGridView1.Rows(3).Cells(i).Value
                Dim VAEUR_DU_POINT As Double = GunaDataGridView1.Rows(4).Cells(i).Value
                Dim PALIER_DE_DEPENSE As Double = GunaDataGridView1.Rows(5).Cells(i).Value
                Dim POINT_PAR_PALIER_DE_DEPENSE As Integer = GunaDataGridView1.Rows(6).Cells(i).Value
                Dim NOMBRE_NUITEE_EGALE_A_UNE_NUITEE As Integer = GunaDataGridView1.Rows(7).Cells(i).Value
                Dim NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE As Integer = GunaDataGridView1.Rows(8).Cells(i).Value

                elite.updateConfigElite(MEMBRE, ELIGIBILITE_NUITS, ELIGIBILITE_POINTS, ELIGIBILITE_SEJOURS, REDUCTION_ACCORDEE, VAEUR_DU_POINT, PALIER_DE_DEPENSE, POINT_PAR_PALIER_DE_DEPENSE, NOMBRE_NUITEE_EGALE_A_UNE_NUITEE, NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE)

            Next

            If GlobalVariable.actualLanguageValue = 1 Then
                message = "Configurations du Club Elite mise à jours avec succès"
                title = "Club Elite "
            Else
                message = "ELite Club Settings successfully updated"
                title = "Elite Club"
            End If

        End If

        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.Close()
    End Sub

End Class