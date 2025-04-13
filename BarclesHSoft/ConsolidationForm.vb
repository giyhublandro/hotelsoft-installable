Public Class ConsolidationForm
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Public Sub deplacemntDeLigne(ByVal GridDepart As DataGridView, ByVal GridArrive As DataGridView)

        For Each row As DataGridViewRow In GridDepart.Rows

            If row.Selected = True Then

                Dim selectedgrid As DataGridViewRow = row
                GridDepart.Rows.Remove(selectedgrid)
                GridArrive.Rows.Add(selectedgrid)

            End If

        Next

    End Sub

    Private Sub GunaButtonVersDroite_Click(sender As Object, e As EventArgs) Handles GunaButtonVersDroite.Click

        deplacemntDeLigne(GunaDataGridView1, GunaDataGridView2)

    End Sub

    Private Sub GunaButtonVersGauche_Click(sender As Object, e As EventArgs) Handles GunaButtonVersGauche.Click

        Dim NUMERO_BLOC_NOTE As String = ""
        Dim CONSOLIDATE As String = ""
        For Each row As DataGridViewRow In GunaDataGridView3.Rows
            'Deconsolidation
            If row.Selected = True Then

                NUMERO_BLOC_NOTE = row.Cells(0).Value.ToString

                Dim infoSup As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If infoSup.Rows.Count > 0 Then
                    CONSOLIDATE = infoSup.Rows(0)("CONSOLIDATE")
                End If

                Functions.updateOfFields("ligne_facture_bloc_note", "CONSOLIDATE", "", "CONSOLIDATE", CONSOLIDATE, 2)

            End If

        Next


        autoloadBlocNote()

    End Sub

    Private Sub ConsolidationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.consolidation(GlobalVariable.actualLanguageValue)
        autoloadBlocNote()

    End Sub

    Private Sub autoloadBlocNote()

        'C- VISUALISATION DE LA LISTE DES BLOC NOTES

        Dim ETAT_BLOC_NOTE As Integer = 0 'NON CLOTURER
        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim caisse As New Caisse()

        'Dim blocNoteAvisualiser As DataTable = Caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        ETAT_BLOC_NOTE = 1 'CLOTURE DONC A REGLER
        Dim blocNoteAvisualiser As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

        'blocNoteAvisualiser.Merge(blocNoteAvisualiser2)

        clearColumns()

        If blocNoteAvisualiser.Rows.Count > 0 Then

            addColumns()

            Dim CONSOLIDATE As String = ""

            For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                Dim ETAT_NOTE As String = ""

                Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString

                Dim infoSup As DataTable = Functions.getElementByCode(blocNoteAvisualiser.Rows(i)(0), "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If infoSup.Rows.Count > 0 Then
                    CONSOLIDATE = infoSup.Rows(0)("CONSOLIDATE")
                End If

                If GlobalVariable.actualLanguageValue = 0 Then

                    If blocNoteAvisualiser.Rows(i)("STATE") = 0 Then
                        ETAT_NOTE = "TO CLOSE"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                        ETAT_NOTE = "TO BE PAID"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 2 Then
                        ETAT_NOTE = "PAID"
                    End If

                    If Trim(CONSOLIDATE).Equals("") Then
                        GunaDataGridView1.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), blocNoteAvisualiser.Rows(i)("AMOUNT"), ETAT_NOTE, TEMPS)
                    Else
                        GunaDataGridView3.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), blocNoteAvisualiser.Rows(i)("AMOUNT"), ETAT_NOTE, TEMPS)
                    End If

                    GunaDataGridView1.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridView1.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridView3.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridView3.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 0 Then
                        ETAT_NOTE = "A CLOTURER"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                        ETAT_NOTE = "A REGLER"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 2 Then
                        ETAT_NOTE = "REGLE"
                    End If

                    If Trim(CONSOLIDATE).Equals("") Then
                        GunaDataGridView1.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), blocNoteAvisualiser.Rows(i)("MONTANT"), ETAT_NOTE, TEMPS)
                    Else
                        GunaDataGridView3.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), blocNoteAvisualiser.Rows(i)("MONTANT"), ETAT_NOTE, TEMPS)
                    End If

                    GunaDataGridView1.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridView1.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    GunaDataGridView3.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridView3.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End If

            Next

        End If

        If GunaDataGridView1.Rows.Count > 0 Then
            GunaDataGridView1.Rows(0).Selected = True
        End If

        If GunaDataGridView3.Rows.Count > 0 Then
            GunaDataGridView3.Rows(0).Selected = True
        End If

    End Sub

    Private Sub GunaButtonConsolider_Click(sender As Object, e As EventArgs) Handles GunaButtonConsolider.Click

        Dim CONSOLIDATE As String = Now().ToLongTimeString
        Dim NUMERO_BLOC_NOTE As String = ""

        If GunaDataGridView2.Rows.Count > 0 Then

            For i = 0 To GunaDataGridView2.Rows.Count - 1

                NUMERO_BLOC_NOTE = GunaDataGridView2.Rows(i).Cells(0).Value.ToString

                Functions.updateOfFields("ligne_facture_bloc_note", "CONSOLIDATE", CONSOLIDATE, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 2)

                Functions.updateOfFields("ligne_facture", "CONSOLIDATE", CONSOLIDATE, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 2)

            Next

            clearColumns()

            addColumns()

            autoloadBlocNote()

        End If

    End Sub

    Private Sub clearColumns()

        GunaDataGridView1.Columns.Clear()
        GunaDataGridView2.Columns.Clear()
        GunaDataGridView3.Columns.Clear()

    End Sub

    Private Sub addColumns()

        If GlobalVariable.actualLanguageValue = 0 Then

            GunaDataGridView1.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
            GunaDataGridView1.Columns.Add("AMOUNT", "AMOUNT")
            GunaDataGridView1.Columns.Add("STATE", "STATE")
            GunaDataGridView1.Columns.Add("TIME", "TIME")

            GunaDataGridView2.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
            GunaDataGridView2.Columns.Add("AMOUNT", "AMOUNT")
            GunaDataGridView2.Columns.Add("STATE", "STATE")
            GunaDataGridView2.Columns.Add("TIME", "TIME")

            GunaDataGridView3.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
            GunaDataGridView3.Columns.Add("AMOUNT", "AMOUNT")
            GunaDataGridView3.Columns.Add("STATE", "STATE")
            GunaDataGridView3.Columns.Add("TIME", "TIME")

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            GunaDataGridView1.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
            GunaDataGridView1.Columns.Add("MONTANT", "MONTANT")
            GunaDataGridView1.Columns.Add("ETAT", "ETAT")
            GunaDataGridView1.Columns.Add("TEMPS", "TEMPS")

            GunaDataGridView2.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
            GunaDataGridView2.Columns.Add("MONTANT", "MONTANT")
            GunaDataGridView2.Columns.Add("ETAT", "ETAT")
            GunaDataGridView2.Columns.Add("TEMPS", "TEMPS")

            GunaDataGridView3.Columns.Add("NUMERO BLOC NOTE", "NUMERO BLOC NOTE")
            GunaDataGridView3.Columns.Add("MONTANT", "MONTANT")
            GunaDataGridView3.Columns.Add("ETAT", "ETAT")
            GunaDataGridView3.Columns.Add("TEMPS", "TEMPS")

        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        autoloadBlocNote()
    End Sub

End Class