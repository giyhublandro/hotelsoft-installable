Public Class TarificationDeReservationForm

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonEdit_Click(sender As Object, e As EventArgs) Handles GunaButtonEdit.Click

        GunaDataGridViewTarifs.Columns(1).ReadOnly = False
        GunaDataGridViewTarifs.Columns(0).ReadOnly = True

        GunaButtonSave.Visible = True
        GunaButtonEdit.Visible = False

    End Sub

    Private Sub GunaButtonSave_Click(sender As Object, e As EventArgs) Handles GunaButtonSave.Click

        GunaButtonEdit.Visible = True
        GunaButtonSave.Visible = False

        'ON EFFACE LE FICHIER DE CETTE RESERVATION PUIS ON INSCRIT LES NOUVELLES VALEURS
        'DANS LE MEME FICHIER TEXT QUI A PERMI SON AFFICHAGE

        Dim tarif As New Tarifs

        Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate

        Dim repertoire As String = "RESERVATIONS"
        Dim cheminDuFichierText As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & repertoire

        If GunaDataGridViewTarifs.Rows.Count > 0 Then

            tarif.chargementDuTableauDansUnFichierText(CODE_RESERVATION, cheminDuFichierText, GunaDataGridViewTarifs)

        End If

        listeDesTarification(CODE_RESERVATION, cheminDuFichierText)

        GunaDataGridViewTarifs.Columns(1).ReadOnly = True
        GunaDataGridViewTarifs.Columns(0).ReadOnly = True

    End Sub

    Private Sub facturationAvenir(ByVal TYPE_FACTURATION As Integer)

        GunaDataGridViewTarifs.Columns.Add("DATE", "DATE")
        GunaDataGridViewTarifs.Columns.Add("MONTANT", "MONTANT")

        If TYPE_FACTURATION = 1 Then 'HEBDOMADAIRE

        ElseIf TYPE_FACTURATION = 2 Then 'DAY_USE

        ElseIf TYPE_FACTURATION = 3 Then 'MENSUEL

        ElseIf TYPE_FACTURATION = 0 Then 'JOURNALIER

        End If

        detailSejourMensuelHebdo(TYPE_FACTURATION)

        GunaButtonEdit.Visible = False
        GunaButtonSave.Visible = False

    End Sub


    Private Sub TarificationDeReservationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaDataGridViewTarifs.ReadOnly = False
        Dim HEBDO As Integer = 1
        Dim DAY_USE As Integer = 2
        Dim MENSUEL As Integer = 3
        Dim JOURNALIER As Integer = 0

        If MainWindow.GunaCheckBoxHebdo.Checked Then
            facturationAvenir(HEBDO)
        ElseIf MainWindow.GunaCheckBoxDayUse.Checked Then
            facturationAvenir(DAY_USE)
        ElseIf MainWindow.GunaCheckBoxMensuel.Checked Then
            facturationAvenir(MENSUEL)
        Else

            If GlobalVariable.AgenceActuelle.Rows(0)("TARIFICATION_DYNAMIQUE") = 1 Then

                If Not Trim(GlobalVariable.codeReservationToUpdate).Equals("") Then

                    Dim CODE_RESERVATION As String = GlobalVariable.codeReservationToUpdate

                    Dim repertoire As String = "RESERVATIONS"

                    Dim cheminDuFichierText As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & repertoire

                    listeDesTarification(CODE_RESERVATION, cheminDuFichierText)

                Else
                    GunaButtonEdit.Visible = False
                End If

            Else
                facturationAvenir(JOURNALIER)
            End If

        End If

    End Sub

    Public Sub listeDesTarification(ByVal CODE_RESERVATION As String, ByVal cheminDuFichierText As String)

        Dim tarif As New Tarifs

        Dim infotarifs As DataTable = tarif.chargementDuFichierTextDansUnTableau(CODE_RESERVATION, cheminDuFichierText)

        If Not infotarifs Is Nothing Then

            If infotarifs.Rows.Count > 0 Then

                If GunaDataGridViewTarifs.Columns.Count > 0 Then
                    GunaDataGridViewTarifs.Columns.Clear()
                End If

                GunaDataGridViewTarifs.Columns.Add("DATE", "DATE")
                GunaDataGridViewTarifs.Columns.Add("MONTANT", "MONTANT")

                For i = 0 To infotarifs.Rows.Count - 1
                    GunaDataGridViewTarifs.Rows.Add(CDate(infotarifs.Rows(i)(0)).ToShortDateString, Format(Double.Parse(infotarifs.Rows(i)(1)), "#,##0"))
                Next

            End If

        End If

    End Sub

    Public Function detailSejourMensuelHebdo(ByVal TYPE_FACTURATION As Integer)

        Dim HEBDO_MENSUEL
        Dim totalSejour As Double = 0
        Dim DATE_ARRIVEE As Date = MainWindow.GunaDateTimePickerArrivee.Value
        Dim DATE_DEPART As Date = MainWindow.GunaDateTimePickerDepart.Value

        Dim numberOfWeeks As Integer = 0
        Dim numberOfDays As Integer = 0
        Dim numberOfMonths As Integer = 0

        Dim monthNumberArrivee As Integer = 0
        Dim monthNumberDepart As Integer = 0
        Dim dayNumberSortie As Integer = 0
        Dim dayNumberEntree As Integer = 0

        Dim tempsAFaire As Integer = CType((DATE_DEPART - DATE_ARRIVEE).TotalDays, Int32)

        Dim prix As Double = 0
        Dim prixJournalier As Double = 0

        If Not Trim(MainWindow.GunaTextBoxMontantAccorde.Text).Equals("") Then

            prix = MainWindow.GunaTextBoxMontantAccorde.Text

            If MainWindow.GunaCheckBoxHebdo.Checked Then

                HEBDO_MENSUEL = 0
                '2- ON DETERMINE LE NOMBRE DE JOUR APRES EXTRACTION DES SEMAINES POUR ATTEINDRE LA DATE DE DEPART 
                numberOfDays = tempsAFaire Mod 7

                '1- ON DETERMINE LE NOMBRE DE SEMAINE A FAIRE PAR APPORT AU NOMBRE DE JOUR EXISTANT ENTRE L'ARRIVEE ET DEPART
                numberOfWeeks = ((tempsAFaire - numberOfDays) / 7)

                prixJournalier = MainWindow.calculJournalierHebdoMensuel(HEBDO_MENSUEL, prix)

                totalSejour = (numberOfWeeks * prix) + (numberOfDays * prixJournalier)

                For i = 0 To numberOfWeeks - 1
                    GunaDataGridViewTarifs.Rows.Add(DATE_ARRIVEE.AddDays(i * 7).ToShortDateString, Format(prix, "#,##0"))
                    If i = (numberOfWeeks - 1) Then
                        DATE_ARRIVEE = DATE_ARRIVEE.AddDays((i + 1) * 7)
                    End If
                Next

                For i = 0 To numberOfDays - 1
                    GunaDataGridViewTarifs.Rows.Add((DATE_ARRIVEE.AddDays(i)).ToShortDateString, Format(prixJournalier, "#,##0"))
                Next

            ElseIf MainWindow.GunaCheckBoxMensuel.Checked Then

                HEBDO_MENSUEL = 1
                '1- ON DETERMINE LE NOMBRE DE MOIS A FAIRE PAR APPORT A L'ARRIVEE ET DEPART
                '1.1- ON DETERMINE LES ECARTS DE MOIS ENTRE L'ARRIVEE ET DEPART
                monthNumberArrivee = Month(DATE_ARRIVEE)
                monthNumberDepart = Month(DATE_DEPART)

                dayNumberSortie = DATE_DEPART.Day()
                dayNumberEntree = DATE_ARRIVEE.Day()

                numberOfMonths = monthNumberDepart - monthNumberArrivee
                If dayNumberSortie < dayNumberEntree Then
                    numberOfMonths -= 1
                End If

                prixJournalier = MainWindow.calculJournalierHebdoMensuel(HEBDO_MENSUEL, prix)

                If numberOfMonths = 0 Then

                    numberOfDays = tempsAFaire
                    totalSejour = (numberOfDays * prixJournalier)

                Else

                    For i = 0 To numberOfMonths

                        If i = numberOfMonths Then

                            numberOfDays = dayNumberSortie - dayNumberEntree

                            If dayNumberSortie >= dayNumberEntree Then
                                numberOfDays = dayNumberSortie - dayNumberEntree
                            ElseIf dayNumberSortie < dayNumberEntree Then
                                numberOfDays = Math.Abs(CType((DATE_DEPART - DATE_ARRIVEE.AddMonths(numberOfMonths)).TotalDays, Int32))
                            End If

                        End If
                    Next

                End If

                For i = 0 To numberOfMonths - 1
                    GunaDataGridViewTarifs.Rows.Add(DATE_ARRIVEE.AddMonths(i).ToShortDateString, Format(prix, "#,##0"))
                    If i = (numberOfMonths - 1) Then
                        DATE_ARRIVEE = DATE_ARRIVEE.AddMonths(i + 1)
                    End If
                Next

                For i = 0 To numberOfDays - 1
                    GunaDataGridViewTarifs.Rows.Add((DATE_ARRIVEE.AddDays(i)).ToShortDateString, Format(prixJournalier, "#,##0"))
                Next

            End If

        End If

    End Function

End Class