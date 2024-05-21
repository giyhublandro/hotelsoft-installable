Imports MySql.Data.MySqlClient

Public Class ClientCategoryForm

    'Dim Connect As New DataBaseManipulation

    Private Sub ClientCategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControlCategClient.SelectedIndex = 1
    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Close()
    End Sub

    'Saving a new entry into database
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_TYPE_CLIENT = ""

        'If category code is empty then we have to insert else we update
        If (GunaTextBoxCodeCatgeoryClient.Text.Trim().Equals("")) Then

            CODE_TYPE_CLIENT = Functions.GeneratingRandomCode("categorie_client", "CAC")
        Else
            CODE_TYPE_CLIENT = GunaTextBoxCodeCatgeoryClient.Text
        End If

        Dim LIBELLE = GunaTextBoxLibelle.Text
        Dim PAIE_TAXE

        If (GunaCheckBoxTaxeSejourApplicable.Checked = True) Then
            PAIE_TAXE = 1
        Else
            PAIE_TAXE = 0
        End If

        Dim PAIE_TAXE_SEJOUR = PAIE_TAXE
        Dim DATE_CREATION = Now()
        Dim TAUX_EXONERATION_TVA = 0
        Dim POURCENTAGE_REMISE = 0
        Dim POURCENTAGE_RISTOURNE = 0
        Dim CODE_UTILISATEUR = ""

        Dim clientCatgory As New CilentCategory

        'company verifyfields function
        If (True) Then
            'Code field empty, then it is a new entry
            If (GunaTextBoxCodeCatgeoryClient.Text.Trim().Equals("")) Then
                'check if the new entry  alreaday exist before insertion
                If Not clientCatgory.clientCategoryExists(CODE_TYPE_CLIENT, LIBELLE) Then
                    'As the new entry does not exist then we insert it, and check the result
                    If clientCatgory.insertClienCategory(CODE_TYPE_CLIENT, LIBELLE, PAIE_TAXE_SEJOUR, DATE_CREATION, TAUX_EXONERATION_TVA, POURCENTAGE_REMISE, POURCENTAGE_RISTOURNE, CODE_UTILISATEUR) Then
                        MessageBox.Show("Nouvelle Catégorie client enregistré avec succès", "Création d'une catégorie client", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'We empty the fields

                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création d'une Catgeorie client", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Cette categorie client existe déjà, Essayer à nouveau", "Création d'une categorie client", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                'Code filed not empty so, we update the existing entry using the code
                If Not (GunaTextBoxLibelle.Text.Trim.Equals("")) Then

                    If clientCatgory.updateClientCategory(CODE_TYPE_CLIENT, LIBELLE, PAIE_TAXE_SEJOUR, DATE_CREATION, TAUX_EXONERATION_TVA, POURCENTAGE_REMISE, POURCENTAGE_RISTOURNE, CODE_UTILISATEUR) Then
                        MessageBox.Show("Catégorie Mise à jour !!", "Mise à d'une Catgeorie client", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Remplir tous les champs!!", "Mise à d'une Catgeorie client", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création d'une categorie client", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'REFRESHING information from database
        Dim query As String = "SELECT CODE_TYPE_CLIENT AS 'CODE', LIBELLE, DATE_CREATION As 'DATE CREATION'  FROM categorie_client"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewCategClient.DataSource = table
            GunaTextBoxLibelle.Clear()
            GunaTextBoxCodeCatgeoryClient.Clear()
            GunaCheckBoxTaxeSejourApplicable.Checked = False

        Else
            'MessageBox.Show("No record found!")
        End If

        TabControlCategClient.SelectedIndex = 1

    End Sub



    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        Me.Close()

    End Sub

    Private Sub DataGridViewCategClient_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCategClient.CellDoubleClick

        If e.RowIndex >= 0 Then

            TabControlCategClient.SelectedIndex = 0

            Dim row As DataGridViewRow
            row = Me.DataGridViewCategClient.Rows(e.RowIndex)

            GunaTextBoxLibelle.Text = row.Cells("LIBELLE").Value.ToString
            GunaTextBoxCodeCatgeoryClient.Text = row.Cells("CODE").Value.ToString

        End If

    End Sub

    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        'REFRESHING information from database
        Dim query As String = "SELECT CODE_TYPE_CLIENT AS 'CODE', LIBELLE, DATE_CREATION As 'DATE CREATION'  FROM categorie_client"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewCategClient.Columns.Clear()

            DataGridViewCategClient.DataSource = table
            GunaTextBoxLibelle.Clear()
            GunaTextBoxCodeCatgeoryClient.Clear()
            GunaCheckBoxTaxeSejourApplicable.Checked = False

        Else
            DataGridViewCategClient.Columns.Clear()
        End If

    End Sub
End Class