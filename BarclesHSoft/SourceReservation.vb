Imports MySql.Data.MySqlClient

Public Class SourceReservation

    'Dim Connect As New DataBaseManipulation

    Private Sub TaxeSejourForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SourceReservationList()

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Close()
    End Sub

    Public Sub SourceReservationList()

        'REFRESHING information from database
        Dim query As String = "SELECT CODE_SOURCE_RESERVATION As 'CODE SOURCE', SOURCE_RESERVATION AS 'NOM DE LA SOURCE', TAUX_COMMISSION As 'TAUX COMMISSION', COMMISSION, COULEUR, COULEUR_FONT FROM source_reservation ORDER BY SOURCE_RESERVATION ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridView1.DataSource = table

            DataGridView1.Columns("TAUX COMMISSION").DefaultCellStyle.Format = "#,##0"
            DataGridView1.Columns("TAUX COMMISSION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridView1.Columns("COMMISSION").DefaultCellStyle.Format = "#,##0"
            DataGridView1.Columns("COMMISSION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridView1.Columns("COULEUR").Visible = False
            DataGridView1.Columns("COULEUR_FONT").Visible = False

            GunaTextBoxLibelle.Clear()
            GunaTextBoxCodeSourceReservation.Clear()

        Else
            'MessageBox.Show("No record found!")
        End If

    End Sub

    'Saving a new entry into database
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_SOURCE_RESERVATION = ""
        Dim TAUX_COMMISSION As Double = 0
        Dim COM As Double = 0
        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim COULEUR As String = GunaTextBoxBgColoration.BaseColor.ToString
        Dim COULEUR_FONT As String = GunaLabelTextColorationFont.ForeColor.ToString
        'If category code is empty then we have to insert else we update
        If (GunaTextBoxCodeSourceReservation.Text.Trim().Equals("")) Then

            CODE_SOURCE_RESERVATION = Functions.GeneratingRandomCode("source_reservation", "SR")
        Else
            CODE_SOURCE_RESERVATION = GunaTextBoxCodeSourceReservation.Text
        End If

        Dim LIBELLE = GunaTextBoxLibelle.Text

        Double.TryParse(GunaTextBoxTauxCommission.Text, COM)

        TAUX_COMMISSION = COM
        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail

        Dim sourceReservation As New Reservation()

        'company verifyfields function
        If (True) Then
            'Code field empty, then it is a new entry
            If (GunaTextBoxCodeSourceReservation.Text.Trim().Equals("")) Then
                'check if the new entry  alreaday exist before insertion
                If Not sourceReservation.sourceReservationExists(CODE_SOURCE_RESERVATION) Then
                    'As the new entry does not exist then we insert it, and check the result
                    If sourceReservation.insertSourceReservation(CODE_SOURCE_RESERVATION, LIBELLE, TAUX_COMMISSION, DATE_CREATION, CODE_UTILISATEUR, COULEUR, COULEUR_FONT) Then
                        MessageBox.Show("Nouvelle Source enregistrée avec succès", "Source Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'We empty the fields
                        GunaTextBoxBgColoration.BaseColor = Color.White
                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création d'une Source de Réservation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Cette Source existe déjà, Essayer à nouveau", "Source Réservation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                'Code filed not empty so, we update the existing entry using the code
                If Not (GunaTextBoxLibelle.Text.Trim.Equals("")) Then

                    If sourceReservation.updateSourceReservation(CODE_SOURCE_RESERVATION, LIBELLE, TAUX_COMMISSION, COULEUR, COULEUR_FONT) Then
                        MessageBox.Show("Source Mise à jour !!", "Mise à d'une Source", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        GunaTextBoxBgColoration.BaseColor = Color.White
                    End If
                Else
                    MessageBox.Show("Remplir tous les champs!!", "Mise à d'une Source", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Source Réservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Functions.SiplifiedClearTextBox(Me)

        GunaLabelTextColorationFont.ForeColor = Color.Black
        GunaTextBoxBgColoration.BaseColor = Color.White

        SourceReservationList()

    End Sub

    '--------------------------- FILL INPUT WITH DATA FROM DATAGRID FOR UPDAT---------------------------
    'Taking data from datagridView and insert into textBox for update

    '---------------------------------------- LIVE SEARCH -------------------------------------

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Me.Close()
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        Me.Close()
    End Sub

    'SUPPRESSION D'UNE  LIGNE
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If DataGridView1.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supperimer cette " & Chr(13) & " Source de Réservation?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                Functions.DeleteRowFromDataGridGeneral(DataGridView1, DataGridView1.CurrentRow.Cells("CODE SOURCE").Value.ToString, "source_reservation", "CODE_SOURCE_RESERVATION")

                DataGridView1.Columns.Clear()

                SourceReservationList()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaButtonColoration_Click(sender As Object, e As EventArgs) Handles GunaButtonColoration.Click

        If ColorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            GunaTextBoxBgColoration.BaseColor = ColorDialog.Color
            GunaTextBoxPreview.BaseColor = ColorDialog.Color
        End If

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click

        If ColorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            GunaLabelTextColorationFont.ForeColor = ColorDialog.Color
            GunaTextBoxPreview.ForeColor = ColorDialog.Color
        End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)

            GunaTextBoxCodeSourceReservation.Text = row.Cells("CODE SOURCE").Value.ToString
            GunaTextBoxTauxCommission.Text = row.Cells("TAUX COMMISSION").Value.ToString

            Dim colorString As String = row.Cells("COULEUR").Value.ToString
            Dim colorForeString As String = row.Cells("COULEUR_FONT").Value.ToString

            Dim paramCouleur() As String

            If Trim(colorString.ToString).Equals("") Then
                'GunaTextBoxColoration.BaseColor = Color.Red
                GunaTextBoxBgColoration.BaseColor = Color.FromArgb(255, 64, 0, 128)
            Else
                paramCouleur = Functions.returningColorFromString(colorString)

                If paramCouleur(1).Equals("") Then
                    GunaTextBoxBgColoration.BaseColor = Color.FromName(paramCouleur(0))
                Else
                    GunaTextBoxBgColoration.BaseColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                End If

            End If

            If Trim(colorForeString.ToString).Equals("") Then
                'GunaTextBoxColoration.BaseColor = Color.Red
                GunaTextBoxBgColoration.BaseColor = Color.FromArgb(255, 64, 0, 128)
            Else
                paramCouleur = Functions.returningColorFromString(colorForeString)

                If paramCouleur(1).Equals("") Then
                    GunaLabelTextColorationFont.ForeColor = Color.FromName(paramCouleur(0))
                Else
                    GunaLabelTextColorationFont.ForeColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                End If

            End If

            GunaTextBoxLibelle.Text = row.Cells("NOM DE LA SOURCE").Value.ToString

        End If

    End Sub



    Private Sub GunaLabelTextColorationFont_ForeColorChanged(sender As Object, e As EventArgs) Handles GunaLabelTextColorationFont.ForeColorChanged

        GunaTextBoxPreview.Text = GunaTextBoxLibelle.Text
        GunaTextBoxPreview.ForeColor = GunaLabelTextColorationFont.ForeColor
        GunaTextBoxPreview.BaseColor = GunaTextBoxBgColoration.BaseColor

    End Sub

    Private Sub GunaTextBoxBgColoration_BackColorChanged(sender As Object, e As EventArgs) Handles GunaTextBoxBgColoration.BackColorChanged
        GunaTextBoxPreview.Text = GunaTextBoxLibelle.Text
        GunaTextBoxPreview.ForeColor = GunaLabelTextColorationFont.ForeColor
        GunaTextBoxPreview.BaseColor = GunaTextBoxBgColoration.BaseColor
    End Sub

    Private Sub GunaTextBoxLibelle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxLibelle.TextChanged

        GunaTextBoxPreview.Text = GunaTextBoxLibelle.Text
        GunaTextBoxPreview.ForeColor = GunaLabelTextColorationFont.ForeColor
        GunaTextBoxPreview.BaseColor = GunaTextBoxBgColoration.BaseColor

    End Sub

End Class