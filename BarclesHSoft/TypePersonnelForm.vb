Imports MySql.Data.MySqlClient

Public Class TypePersonnelForm

    'Dim Connect As New DataBaseManipulation

    Public Sub typeDePersonnelListe()

        'REFRESHING information from database
        Dim query As String = "SELECT `ID_TYPE_PERSONNEL`, `CODE_TYPE_PERSONNEL`, `LIBELLE_TYPE_PERSONNEL` AS 'LIBELLE', `CODE_UTILISATEUR_CREA`, `DATE_CREATION` As 'DATE CREATION' FROM `type_personnel` ORDER BY LIBELLE_TYPE_PERSONNEL ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewTypePersonnel.DataSource = table

            GunaLabelNombreClient.Text = "(" & table.Rows.Count & ")"
            GunaLabelNombreClient.Visible = True
            GunaTextBoxLibelle.Clear()
            GunaTextBoxCodePersonnel.Clear()

        Else
            'MessageBox.Show("No record found!")
        End If

        DataGridViewTypePersonnel.Columns(0).Visible = False
        DataGridViewTypePersonnel.Columns(1).Visible = False
        DataGridViewTypePersonnel.Columns(3).Visible = False
        DataGridViewTypePersonnel.Columns(4).Visible = False

    End Sub
    'Saving a new entry into database
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_TYPE_PERSONNEL = ""
        Dim CODE_UTILISATEUR = ""
        'If category code is empty then we have to insert else we update
        If (GunaTextBoxCodePersonnel.Text.Trim().Equals("")) Then
            CODE_TYPE_PERSONNEL = Functions.GeneratingRandomCode("type_personnel", "TYP")
        Else
            CODE_TYPE_PERSONNEL = GunaTextBoxCodePersonnel.Text
        End If

        Dim LIBELLE = GunaTextBoxLibelle.Text

        Dim DATE_CREATION = Now()

        Dim typePersonnel As New TypePersonnel

        'company verifyfields function
        If (True) Then
            'Code field empty, then it is a new entry
            If (GunaTextBoxCodePersonnel.Text.Trim().Equals("")) Then
                'check if the new entry  alreaday exist before insertion
                If Not typePersonnel.typePersonnelExist(CODE_TYPE_PERSONNEL, LIBELLE) Then

                    If GunaButtonEnregistrer.Text = "Enregistrer" Then
                        'As the new entry does not exist then we insert it, and check the result
                        If typePersonnel.insertTypePersonnel(CODE_TYPE_PERSONNEL, LIBELLE, DATE_CREATION, CODE_UTILISATEUR) Then
                            MessageBox.Show("Nouveau type de personnel enregistré avec succès", "Création d'un type de personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Functions.SiplifiedClearTextBox(Me)
                        Else
                            MessageBox.Show("Un problème lors de la création !!", "Création d'un type de Personnel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    End If

                Else
                    MessageBox.Show("Cette ce type existe déjà, Essayer à nouveau", "Création d'un type de personnel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                'Code filed not empty so, we update the existing entry using the code
                If Not (GunaTextBoxLibelle.Text.Trim.Equals("")) Then

                    If typePersonnel.updateTypePersonnel(CODE_TYPE_PERSONNEL, LIBELLE, CODE_UTILISATEUR) Then
                        MessageBox.Show("Type de personnel mise à jours avec succès", "Type de personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Functions.SiplifiedClearTextBox(Me)
                    End If
                Else
                    MessageBox.Show("Remplir tous les champs!!", "Mise à d'un type de Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création d'un Type de Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    '--------------------------- FILL INPUT WITH DATA FROM DATAGRID FOR UPDAT---------------------------
    'Taking data from datagridView and insert into textBox for update
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow
            row = Me.DataGridViewTypePersonnel.Rows(e.RowIndex)

            GunaTextBoxLibelle.Text = row.Cells("LIBELLE_TYPE_PERSONNEL").Value.ToString
            GunaTextBoxCodePersonnel.Text = row.Cells("CODE_TYPE_PERSONNEL").Value.ToString

        End If

    End Sub

    '---------------------------------------- LIVE SEARCH -------------------------------------
    'Live Search implémentation based on hotel category code
    Private Sub GunaTextBoxLiveSearch_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT * FROM type_personnel WHERE CODE_TYPE_PERSONNEL LIKE '%" & GunaTextBoxLiveSeqrcchByCode.Text & "%'"
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'DataGridView1.DataSource = table
        'Else

        'End If

        'Connect.closeConnection()

    End Sub

    'Reorganise when enteringinto live search by code
    Private Sub GunaTextBoxLiveSearch_Enter(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT * FROM type_personnel ORDER BY CODE_TYPE_PERSONNEL ASC"
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'DataGridView1.DataSource = table
        'End If

        'Connect.closeConnection()

    End Sub

    'Searching based on hotel category name
    Private Sub GunaTextBoxLiveSeqrchByLibelle_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT * FROM type_personnel WHERE LIBELLE_TYPE_PERSONNEL LIKE '%" & GunaTextBoxLiveSeqrchByLibelle.Text & "%'"
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'DataGridView1.DataSource = table
        'Else

        'End If

        'Connect.closeConnection()

    End Sub

    Private Sub TypePersonnelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If DataGridViewTypePersonnel.Rows.Count > 0 Then

            DataGridViewTypePersonnel.Columns(0).Visible = False
            DataGridViewTypePersonnel.Columns(1).Visible = False
            DataGridViewTypePersonnel.Columns(3).Visible = False
            DataGridViewTypePersonnel.Columns(5).Visible = False
            DataGridViewTypePersonnel.Columns(6).Visible = False

        End If

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Close()
    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        typeDePersonnelListe()
    End Sub

    Private Sub GunaButtonAnnuler_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnuler.Click
        Me.Close()
    End Sub

    Private Sub DataGridViewTypePersonnel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewTypePersonnel.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.DataGridViewTypePersonnel.Rows(e.RowIndex)

            TabControl1.SelectedIndex = 0

            Dim typePersonnel As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE_TYPE_PERSONNEL").Value.ToString), "type_personnel", "CODE_TYPE_PERSONNEL")

            If typePersonnel.Rows.Count > 0 Then

                GunaTextBoxCodePersonnel.Text = typePersonnel.Rows(0)("CODE_TYPE_PERSONNEL")
                GunaTextBoxLibelle.Text = typePersonnel.Rows(0)("LIBELLE_TYPE_PERSONNEL")

                GunaTextBoxTypePersonnel.Clear()

            End If

        End If

    End Sub

    Private Sub SupprimerFicheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerFicheToolStripMenuItem.Click

        Dim CODE_TYPE_PERSONNEL As String = DataGridViewTypePersonnel.CurrentRow.Cells("CODE_TYPE_PERSONNEL").Value.ToString
        Dim LIBELLE As String = DataGridViewTypePersonnel.CurrentRow.Cells("LIBELLE").Value.ToString

        Dim dialog As DialogResult
        dialog = MessageBox.Show("Voulez-vous vraiment Supprimer : " & LIBELLE, "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else

            'SUPPRESSION DES LIGNES DE LA FICHE SUPPRIMEE
            Functions.DeleteElementByCode(CODE_TYPE_PERSONNEL, "type_personnel", "CODE_TYPE_PERSONNEL")

            DataGridViewTypePersonnel.Columns.Clear()

            typeDePersonnelListe()

            MessageBox.Show("Vous avez supprimé " & LIBELLE & " avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Functions.SiplifiedClearTextBox(Me)

        End If

    End Sub

    Private Sub GunaTextBoxTypePersonnel_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTypePersonnel.TextChanged

        If Trim(GunaTextBoxTypePersonnel.Text).Equals("") Then
            DataGridViewTypePersonnel.Columns.Clear()
            GunaLabelNombreClient.Text = "(0)"

        Else

            'REFRESHING information from database

            Dim query As String = "SELECT `ID_TYPE_PERSONNEL`, `CODE_TYPE_PERSONNEL`, `LIBELLE_TYPE_PERSONNEL` AS 'LIBELLE', `CODE_UTILISATEUR_CREA`, `DATE_CREATION` As 'DATE CREATION' FROM `type_personnel` WHERE LIBELLE_TYPE_PERSONNEL LIKE '% " & GunaTextBoxTypePersonnel.Text & "%' ORDER BY LIBELLE_TYPE_PERSONNEL ASC"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            DataGridViewTypePersonnel.Columns.Clear()

            If (table.Rows.Count > 0) Then

                DataGridViewTypePersonnel.DataSource = table

                GunaLabelNombreClient.Text = "(" & table.Rows.Count & ")"
                GunaLabelNombreClient.Visible = True
                GunaTextBoxLibelle.Clear()
                GunaTextBoxCodePersonnel.Clear()

                DataGridViewTypePersonnel.Columns(0).Visible = False
                DataGridViewTypePersonnel.Columns(1).Visible = False
                DataGridViewTypePersonnel.Columns(3).Visible = False
                DataGridViewTypePersonnel.Columns(4).Visible = False

            Else

            End If

        End If

    End Sub
End Class