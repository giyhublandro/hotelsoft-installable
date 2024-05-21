Imports MySql.Data.MySqlClient

Public Class PannesForm

    'Dim connect As New DataBaseManipulation()

    Private Sub PanneForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If GlobalVariable.TypePanne = "famille" Then

            GunaLabelGestCompteGeneraux.Text = "Création et mise à jour des familles de Pannes"
            GunaComboBoxFamillePane.Visible = False
            GunaLabelParent.Visible = False

        ElseIf GlobalVariable.TypePanne = "sous famille" Then

            GunaLabelGestCompteGeneraux.Text = "Création et mise à jour des sous familles de Pannes"
            GunaComboBoxFamillePane.Visible = True
            GunaLabelParent.Visible = True

            AutoLoadFamilleParent()

        End If

        GunaComboBoxType.SelectedIndex = 0

        'panneTypeList()

    End Sub

    Public Sub AutoLoadFamilleParent()

        'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes

        'Dim familleParent As DataTable = Functions.GetAllElementsOnCondition("famille", "famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE")
        Dim familleParent As DataTable = Functions.allTableFieldsOnConditionOrganisedString("famille_et_sous_famille_panne", "TYPE_FAMILLE_OU_SOUS_FAMILLE", "famille", "LIBELLE")

        If familleParent.Rows.Count > 0 Then

            GunaComboBoxFamillePane.DataSource = familleParent
            GunaComboBoxFamillePane.ValueMember = "LIBELLE"
            GunaComboBoxFamillePane.DisplayMember = "LIBELLE"

        End If

    End Sub

    Public Sub panneTypeList()

        Dim query As String = ""

        If GlobalVariable.TypePanne = "famille" Then

            query = "SELECT `CODE_PANNE` AS CODE, `LIBELLE`, `DESCRIPTION` FROM `famille_et_sous_famille_panne` WHERE CODE_AGENCE = @CODE_AGENCE AND TYPE_FAMILLE_OU_SOUS_FAMILLE=@TYPE ORDER BY LIBELLE ASC"

        ElseIf GlobalVariable.TypePanne = "sous famille" Then

            query = "SELECT `CODE_PANNE` AS CODE, `LIBELLE`, `DESCRIPTION`, `PARENT` FROM `famille_et_sous_famille_panne` WHERE CODE_AGENCE = @CODE_AGENCE AND TYPE_FAMILLE_OU_SOUS_FAMILLE=@TYPE ORDER BY LIBELLE ASC "

        End If

        'Dim query As String = "SELECT * FROM type_chambre ORDER BY LIBELLE_TYPE_CHAMBRE"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle(0)("CODE_AGENCE")
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.TypePanne

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridView1.DataSource = table

            DataGridView1.Columns("CODE").Visible = False

        Else
            DataGridView1.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub


    'Function to check empty fields
    Public Function verifyFields() As Boolean

        Dim check As Boolean = False

        If (GunaTextBoxLibelle.Text.Trim().Equals("")) Then
            check = False
        Else
            check = True
        End If

        Return check

    End Function

    'Insertion d'une nouvelle ligne
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_AGENCE = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        Dim CODE_PANNE As String = Functions.GeneratingRandomCodeWithSpecifications("famille_et_sous_famille_panne", "")
        Dim LIBELLE As String = GunaTextBoxLibelle.Text
        Dim DESCRIPTION As String = GunaTextBoxDescription.Text
        Dim TYPE_FAMILLE_OU_SOUS_FAMILLE As String = GlobalVariable.TypePanne

        Dim TYPE As Integer = GunaComboBoxType.SelectedIndex
        Dim PARENT As String = ""

        If GunaComboBoxFamillePane.SelectedIndex >= 0 And GlobalVariable.TypePanne = "sous famille" Then
            PARENT = GunaComboBoxFamillePane.SelectedValue.ToString
        End If

        Dim panne As New Panne

        If GunaButtonEnregistrer.Text = "Sauvegarder" Then
            CODE_PANNE = GunaTextBoxCode.Text
            'We update the value of the row in case of any change
            If panne.Update(CODE_PANNE, LIBELLE, DESCRIPTION, TYPE_FAMILLE_OU_SOUS_FAMILLE, CODE_AGENCE, PARENT, TYPE) Then
                MessageBox.Show("Mise à jour effectuée avec succès", "Création de " & GlobalVariable.TypePanne & " de Panne", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            GunaButtonEnregistrer.Text = "Enregistrer
"
        Else
            'company verifyfields function
            If (verifyFields()) Then
                'check if the company alreday exist

                If Not Functions.entryCodeExists(CODE_PANNE, "famille_et_sous_famille_panne", "CODE_PANNE") Then

                    If panne.Insert(CODE_PANNE, LIBELLE, DESCRIPTION, TYPE_FAMILLE_OU_SOUS_FAMILLE, CODE_AGENCE, PARENT, TYPE) Then

                        MessageBox.Show("Nouvelle " & GlobalVariable.TypePanne & " enregistré avec succès", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                Else
                    MessageBox.Show("Ce " & GlobalVariable.TypePanne & " existe déjà, Essayer à nouveau", GlobalVariable.TypePanne & " Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        'We refresh the room type list
        'panneTypeList()

        Functions.ClearTextBox(Me)

    End Sub

    'We double to update a row
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

        'When we doubleclick on the room category datagrid it is either for update or for bringing the selected row to front desk

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.DataGridView1.Rows(e.RowIndex)


            Dim panne As DataTable = Functions.getElementByCode(row.Cells("CODE").Value.ToString, "famille_et_sous_famille_panne", "CODE_PANNE")

            If panne.Rows.Count > 0 Then

                GunaTextBoxCode.Text = panne.Rows(0)("CODE_PANNE")
                GunaTextBoxLibelle.Text = panne.Rows(0)("LIBELLE")
                GunaTextBoxDescription.Text = panne.Rows(0)("DESCRIPTION")

                If GunaComboBoxFamillePane.SelectedIndex >= 0 And GlobalVariable.TypePanne = "sous famille" Then

                    GunaComboBoxFamillePane.SelectedValue = panne.Rows(0)("PARENT")

                End If

            End If

            GunaButtonEnregistrer.Text = "Sauvegarder"

        End If

    End Sub

    '--------------------------------------------LIVE SEARCH --------------------------------------------------------------------
    'Searching based on name
    Private Sub GunaTextBoxLiveSearchlibelle_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT `CODE_PANNE` AS CODE, `LIBELLE`, `DESCRIPTION` FROM `famille_et_sous_famille_panne` WHERE LIBELLE LIKE '%" & GunaTextBoxLibeleTypeChambre.Text & "%' AND CODE_AGENCE = @CODE_AGENCE AND TYPE_FAMILLE_OU_SOUS_FAMILLE=@TYPE ORDER BY LIBELLE ASC"

        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle(0)("CODE_AGENCE")
        'Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.TypePanne

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'DataGridView1.DataSource = table
        'Else

        'End If

        ''connect.closeConnection()


    End Sub

    Private Sub GunaTextBoxLiveSearchlibelle_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT `CODE_PANNE` AS CODE, `LIBELLE`, `DESCRIPTION` FROM `famille_et_sous_famille_panne` WHERE CODE_AGENCE = @CODE_AGENCE AND TYPE_FAMILLE_OU_SOUS_FAMILLE=@TYPE ORDER BY LIBELLE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle(0)("CODE_AGENCE")
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.TypePanne

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            DataGridView1.DataSource = table
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    'SUPRESSION DES ELEMENTS DE LA LISTE
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If DataGridView1.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supprimer cette Réservation?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(DataGridView1, DataGridView1.CurrentRow.Cells("CODE").Value.ToString, "famille_et_sous_famille_panne", "CODE_PANNE")

                DataGridView1.Columns.Clear()

                panneTypeList()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        panneTypeList()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        DataGridView1.Columns.Clear()
    End Sub



End Class