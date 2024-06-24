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

End Class