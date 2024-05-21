Imports MySql.Data.MySqlClient


Public Class CoChambrierForm
    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub GunaTextBoxNomPrenom_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNomPrenom.TextChanged


        If Trim(GunaTextBoxNomPrenom.Text).Equals("") Then

        End If

        GunaDataGridViewClient.Visible = True

        Dim Query As String = "SELECT NOM_PRENOM, EMAIL From client WHERE NOM_PRENOM LIKE '%" & GunaTextBoxNomPrenom.Text & "%'"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewClient.DataSource = table
        Else
            GunaDataGridViewClient.Columns.Clear()
            GunaDataGridViewClient.Visible = False
        End If

        If GunaTextBoxNomPrenom.Text = "" Then
            GunaDataGridViewClient.Visible = False
        End If
    End Sub

    Private Sub GunaDataGridViewClient_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewClient.CellClick

        GunaDataGridViewClient.Visible = False

        Dim row As DataGridViewRow

        row = Me.GunaDataGridViewClient.Rows(e.RowIndex)

        Dim query As String = "SELECT * FROM client WHERE NOM_PRENOM = @NOM_PRENOM AND EMAIL=@EMAIL"
        Dim adapter As New MySqlDataAdapter

        Dim table As New DataTable()
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = Trim(row.Cells("NOM_PRENOM").Value.ToString())
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = row.Cells("EMAIL").Value.ToString()

        adapter.SelectCommand = command
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            Dim Add As Boolean = True
            Dim CODE_RESERVATION As String = MainWindow.GunaLabelNumReservation.Text
            Dim CODE_CLIENT As String = table.Rows(0)("CODE_CLIENT")

            'ON SE RASSURE QUE LE NOM DU CLIENT N'EXISTE PAS DEJA 
            For Each rowCoChambrier As DataGridViewRow In GunaDataGridViewCoChambrier.SelectedRows

                If CODE_RESERVATION = rowCoChambrier.Cells("CODE_RESERVATION").Value.ToString() And CODE_CLIENT = rowCoChambrier.Cells("CODE_CLIENT").Value.ToString() Then
                    Add = False
                End If

            Next

            If add Then

                GunaDataGridViewCoChambrier.Rows.Add(CODE_CLIENT, table.Rows(0)("NOM_PRENOM"), CODE_RESERVATION)

                GunaDataGridViewCoChambrier.Columns(0).Visible = False
                GunaDataGridViewCoChambrier.Columns(2).Visible = False

                GunaLabelNmbreCoChambrier.Text = GunaDataGridViewCoChambrier.Rows.Count

            Else
                MessageBox.Show("Ce Co Chambrier est déjà enregistré !!", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        GunaTextBoxNomPrenom.Clear()

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        'INSERTION DES CO-CHAMBRIERS

        Functions.DeleteElementByCode(MainWindow.GunaLabelNumReservation.Text, "cochambrier", "CODE_RESERVATION")

        Dim CODE_CLIENT As String = ""
        Dim NOM_PRENOM As String = ""
        Dim CODE_RESERVATION As String = ""

        Dim cochambrier As New Reservation()

        For i = 0 To GunaDataGridViewCoChambrier.Rows.Count - 1

            CODE_CLIENT = GunaDataGridViewCoChambrier.Rows(i).Cells(0).Value.ToString
            NOM_PRENOM = GunaDataGridViewCoChambrier.Rows(i).Cells(1).Value.ToString
            CODE_RESERVATION = GunaDataGridViewCoChambrier.Rows(i).Cells(2).Value.ToString

            cochambrier.coChambrier(CODE_CLIENT, NOM_PRENOM, CODE_RESERVATION)
        Next

        MessageBox.Show("Co Chambrier enregistré !!", "Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

    End Sub

    Private Sub CoChambrierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CODE_RESERVATION As String = MainWindow.GunaLabelNumReservation.Text

        Dim infoCoChambrier As DataTable = Functions.getElementByCode(CODE_RESERVATION, "cochambrier", "CODE_RESERVATION")

        If infoCoChambrier.Rows.Count > 0 Then

            For i = 0 To infoCoChambrier.Rows.Count - 1

                GunaDataGridViewCoChambrier.Rows.Add(infoCoChambrier.Rows(i)("CODE_CLIENT"), infoCoChambrier.Rows(i)("NOM_PRENOM"), infoCoChambrier.Rows(i)("CODE_RESERVATION"))

                GunaDataGridViewCoChambrier.Columns(0).Visible = False
                GunaDataGridViewCoChambrier.Columns(2).Visible = False

            Next

            GunaLabelNmbreCoChambrier.Text = infoCoChambrier.Rows.Count

        End If

    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        Dim CODE_CLIENT As String = ""
        Dim NOM_PRENOM As String = ""
        Dim CODE_RESERVATION As String = ""

        For Each row As DataGridViewRow In GunaDataGridViewCoChambrier.SelectedRows

            GunaDataGridViewCoChambrier.Rows.Remove(row)

            CODE_CLIENT = row.Cells(0).Value.ToString()
            NOM_PRENOM = row.Cells(1).Value.ToString
            CODE_RESERVATION = row.Cells(2).Value.ToString

            Functions.DeleteElementOnTwoConditions(CODE_RESERVATION, "cochambrier", "CODE_RESERVATION", "CODE_CLIENT", CODE_CLIENT)

        Next

    End Sub

End Class