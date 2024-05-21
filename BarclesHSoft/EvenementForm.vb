Imports MySql.Data.MySqlClient

Public Class EvenementForm

    'Dim Connect As New DataBaseManipulation

    Private Sub ClientCategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControlEvenement.SelectedIndex = 1
    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Close()
    End Sub

    'Saving a new entry into database
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim evene As New Evenement()

        Dim CODE_EVENEMENT As String = Functions.GeneratingRandomCodePanne("evenement", "EVE")
        Dim LIBELLE As String = GunaTextBoxLibelle.Text
        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        'company verifyfields function
        If (True) Then
            'Code field empty, then it is a new entry
            If GunaButtonEnregistrer.Text = "Enregistrer" Then
                'check if the new entry  alreaday exist before insertion
                If Not evene.eventExists(CODE_EVENEMENT, LIBELLE) Then
                    'As the new entry does not exist then we insert it, and check the result
                    If evene.insertEvent(CODE_EVENEMENT, LIBELLE, DATE_CREATION, CODE_AGENCE) Then
                        MessageBox.Show("Nouvelle Evènement enregistré avec succès", "Création d'évènement", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'We empty the fields
                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création d'évènement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Cette évènement existe déjà, Essayer à nouveau", "Création d'évènement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                'Code filed not empty so, we update the existing entry using the code
                If GunaButtonEnregistrer.Text = "Sauvegarder" Then

                    CODE_EVENEMENT = GunaTextBoxCodeeVENT.Text

                    If evene.updateEvent(CODE_EVENEMENT, LIBELLE) Then
                        MessageBox.Show("Evènement Mise à jours !!", "Mise à jours d'évènement", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Remplir tous les champs!!", "Mise à jours d'évènement", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                GunaButtonEnregistrer.Text = "Enregistrer"

            End If
        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création d'évènement", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'REFRESHING information from database
        Dim query As String = "SELECT CODE_EVENEMENT AS 'CODE', LIBELLE  FROM evenement"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewEvenement.DataSource = table

            GunaTextBoxLibelle.Clear()
            GunaTextBoxCodeeVENT.Clear()

        Else
            'MessageBox.Show("No record found!")
        End If

        TabControlEvenement.SelectedIndex = 1

    End Sub



    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        Me.Close()

    End Sub

    Private Sub DataGridViewCategClient_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEvenement.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Sauvegarder"

            TabControlEvenement.SelectedIndex = 0

            Dim row As DataGridViewRow
            row = Me.DataGridViewEvenement.Rows(e.RowIndex)

            GunaTextBoxLibelle.Text = row.Cells("LIBELLE").Value.ToString

            GunaLabelIntitule.Text = "MISE AJOURS DE " & GunaTextBoxLibelle.Text

            GunaTextBoxCodeeVENT.Text = row.Cells("CODE").Value.ToString

        End If

    End Sub

    Private Sub afficherEvenement()

        'REFRESHING information from database
        Dim query As String = "SELECT CODE_EVENEMENT AS 'CODE', LIBELLE  FROM evenement"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewEvenement.Columns.Clear()

            DataGridViewEvenement.DataSource = table

            DataGridViewEvenement.Columns("CODE").Visible = False

            GunaTextBoxLibelle.Clear()
            GunaTextBoxCodeeVENT.Clear()

        Else
            DataGridViewEvenement.Columns.Clear()
        End If


    End Sub

    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        afficherEvenement()

    End Sub

    Private Sub TabControlEvenement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlEvenement.SelectedIndexChanged

        If TabControlEvenement.SelectedIndex = 0 Then
            GunaLabelIntitule.Text = "LISTE DES EVENEMENTS"
        End If

    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If DataGridViewEvenement.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supprimer " & DataGridViewEvenement.CurrentRow.Cells("LIBELLE").Value.ToString & " ?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(DataGridViewEvenement, DataGridViewEvenement.CurrentRow.Cells("CODE").Value.ToString, "evenement", "CODE_EVENEMENT")

                afficherEvenement()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub
End Class