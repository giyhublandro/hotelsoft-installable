Imports MySql.Data.MySqlClient

Public Class FabricationDeProformaForm

    Private Sub autoloadDifferentGroupe()

        Dim query As String = "SELECT DISTINCT GROUPE FROM reservation WHERE ETAT_RESERVATION = 0 AND GROUPE NOT IN ('') ORDER BY GROUPE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim query_ As String = "SELECT DISTINCT GROUPE FROM reserve_conf WHERE ETAT_RESERVATION = 1 AND GROUPE NOT IN ('') ORDER BY GROUPE ASC"

        Dim command_ As New MySqlCommand(query_, GlobalVariable.connect)

        Dim adapter_ As New MySqlDataAdapter(command_)
        Dim table_ As New DataTable()
        adapter_.Fill(table_)

        table.Merge(table_)

        If (table.Rows.Count > 0) Then

            GunaComboBoxGroupe.DataSource = table
            GunaComboBoxGroupe.ValueMember = "GROUPE"
            GunaComboBoxGroupe.DisplayMember = "GROUPE"

        End If

        GunaComboBoxGroupe.SelectedValue = MainWindow.GunaTextBoxCodeDeGroupe.Text

    End Sub


    Private Sub GunaImageButton3_Click(sender As Object, e As EventArgs) Handles GunaImageButton3.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FabricationDeProformaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.FabricationDeProforma(GlobalVariable.actualLanguageValue)

        autoloadDifferentGroupe()

        ' Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToString("yyyy-MM-dd")
        'Dim DateFin As Date = GunaDateTimePickerFin.Value.ToString("yyyy-MM-dd")

        'If (GunaDateTimePickerDebut.Value <= GunaDateTimePickerFin.Value) Then

        reservationDunGroupe()

        If MainWindow.GunaRadioButtonChambre.Checked Then
            GunaCheckBoxSalle.Checked = False
            GunaButtonEnvoyer.Visible = False
        ElseIf MainWindow.GunaRadioButtonSalleFete.Checked Then
            GunaCheckBoxSalle.Checked = True
            GunaButtonEnvoyer.Visible = True
        End If

    End Sub

    Private Sub reservationDunGroupe()

        If GunaComboBoxGroupe.SelectedIndex >= 0 Then

            Dim GROUPE As String = GunaComboBoxGroupe.SelectedValue.ToString

            Dim query As String = ""
            Dim query_ As String = ""

            query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE, CODE_ENTREPRISE, NOM_ENTREPRISE FROM reservation WHERE ETAT_RESERVATION= 0 AND GROUPE =@GROUPE ORDER BY CHAMBRE_ID ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@GROUPE", MySqlDbType.VarChar).Value = GROUPE

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            query_ = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE, CODE_ENTREPRISE, NOM_ENTREPRISE FROM reserve_conf WHERE ETAT_RESERVATION = 1 AND GROUPE = @GROUPE ORDER BY CHAMBRE_ID ASC"

            Dim command_ As New MySqlCommand(query_, GlobalVariable.connect)
            command_.Parameters.Add("@GROUPE", MySqlDbType.VarChar).Value = GROUPE

            Dim adapter_ As New MySqlDataAdapter(command_)
            Dim table_ As New DataTable()
            adapter_.Fill(table_)

            table.Merge(table_)

            GunaDataGridView.DataSource = Nothing

            If (table.Rows.Count > 0) Then

                GunaDataGridView.DataSource = table

                GunaDataGridView.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
                GunaDataGridView.DefaultCellStyle.SelectionForeColor = Color.White
                GunaDataGridView.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridView.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridView.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridView.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridView.Columns("CODE_ENTREPRISE").Visible = False
                GunaDataGridView.Columns("NOM_ENTREPRISE").Visible = False

            Else

                GunaDataGridView.Columns.Clear()

            End If

            If GunaDataGridView.Rows.Count > 0 Then

                If Not Trim(GunaDataGridView.Rows(0).Cells("NOM_ENTREPRISE").Value.ToString).Equals("") Then
                    GunaTextBoxClient.Text = GunaDataGridView.Rows(0).Cells("NOM_ENTREPRISE").Value.ToString
                Else
                    GunaTextBoxClient.Text = GunaDataGridView.Rows(0).Cells("NOM CLIENT").Value.ToString
                End If

            End If

        Else

            GunaDataGridView.Columns.Clear()

        End If

    End Sub

    Private Sub GunaComboBoxGroupe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxGroupe.SelectedIndexChanged

        reservationDunGroupe()

    End Sub

    Private Sub ImprimerDocChambreSalle_Click(sender As Object, e As EventArgs) Handles ImprimerDocChambreSalle.Click

        If GunaDataGridView.Rows.Count > 0 Then
            Functions.fabricationProforma(GunaDataGridView, GunaTextBoxClient.Text)
        End If

    End Sub

    Private Sub GunaButtonEnvoyer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnvoyer.Click

        If GunaDataGridView.Rows.Count > 0 Then

            Dim HEBERGEMENT As Double = 0

            Dim totalSejour As Double = 0
            Dim ENCAISSEMENT As Double = 0
            Dim TAxeSejour As Double = 0

            Dim dateEntree As Date
            Dim dateSortie As Date

            Dim nbreNuitee As Integer = 0
            Dim nbreNuiteeTotal As Integer = 0

            Dim CODE_RESERVATION As String = ""

            For Each row As DataGridViewRow In GunaDataGridView.SelectedRows

                CODE_RESERVATION = row.Cells("RESERVATION").Value.ToString
                dateEntree = CDate(row.Cells("DATE ENTREE").Value.ToString).ToShortDateString
                dateSortie = CDate(row.Cells("DATE SORTIE").Value.ToString).ToShortDateString
                nbreNuitee = CType((dateSortie - dateEntree).TotalDays, Int32)
                nbreNuiteeTotal += nbreNuitee
                totalSejour += nbreNuitee * row.Cells("PRIX/NUITEE").Value

                Dim reglement As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reglement", "CODE_RESERVATION")

                If reglement.Rows.Count > 0 Then

                    For j = 0 To reglement.Rows.Count - 1
                        ENCAISSEMENT += reglement.Rows(j)("MONTANT_VERSE")
                    Next

                End If

                Dim infoTaxe As DataTable = Functions.getElementByCode(CODE_RESERVATION, "taxe_sejour_collectee", "NUM_RESERVATION")

                If infoTaxe.Rows.Count > 0 Then

                    For j = 0 To infoTaxe.Rows.Count - 1
                        TAxeSejour += infoTaxe.Rows(j)("TAXE_SEJOUR_COLLECTEE") * nbreNuitee
                    Next

                End If

            Next

            HEBERGEMENT = TAxeSejour + totalSejour

            If HEBERGEMENT > 0 Then

                Dim CODE_FORFAIT_HEBERGEMENT As String = Functions.GeneratingRandomCodeWithSpecifications("forfait_salle", "")

                CODE_RESERVATION = MainWindow.GunaLabelNumReservation.Text

                Dim NBRE_NUITEE As Integer = nbreNuiteeTotal

                Functions.DeleteElementByCode(CODE_RESERVATION, "forfait_salle_hebergement", "CODE_RESERVATION")

                Dim resa As New Reservation()

                resa.insertForfaitSalleHebergement(CODE_RESERVATION, CODE_FORFAIT_HEBERGEMENT, HEBERGEMENT, ENCAISSEMENT, NBRE_NUITEE)

            End If

            Me.Close()

            MessageBox.Show("Réservation(s) sélectionnée(s) ajoutée(s) !", "Prise en charge Hébergement", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

End Class