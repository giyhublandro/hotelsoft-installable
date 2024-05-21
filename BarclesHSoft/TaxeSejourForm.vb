Imports MySql.Data.MySqlClient

Public Class TaxeSejourForm

    'Dim Connect As New DataBaseManipulation

    Private Sub TaxeSejourForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Close()
    End Sub

    Public Sub categorieHotelEtMontantTaxeSejour()

        'REFRESHING information from database
        Dim query As String = "SELECT `CODE_CATEGORIE_HOTEL` As 'CODE CATEGORIE HOTEL', `LIBELLE`, `MONTANT_TAXE` AS 'MONTANT TAXE', `DATE_CREATION` As 'DATE CREATION'  FROM `category_hotel_taxe_sejour_collectee` "
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridView1.DataSource = table
            GunaTextBoxLibelle.Clear()
            GunaTextBoxCodeCategorieHotel.Clear()

        End If


    End Sub

    'Saving a new entry into database
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_CATEGORIE_HOTEL = ""
        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        'If category code is empty then we have to insert else we update
        If (GunaTextBoxCodeCategorieHotel.Text.Trim().Equals("")) Then

            CODE_CATEGORIE_HOTEL = Functions.GeneratingRandomCode("category_hotel_taxe_sejour_collectee", "CAC")
        Else
            CODE_CATEGORIE_HOTEL = GunaTextBoxCodeCategorieHotel.Text
        End If

        Dim LIBELLE = GunaTextBoxLibelle.Text

        Dim PAIE_TAXE_SEJOUR = GunaTextBoxMontantTaxeSejour.Text
        Dim DATE_CREATION = GlobalVariable.DateDeTravail

        Dim hotelCatgory As New TAxeSejour

        'company verifyfields function
        If (True) Then
            'Code field empty, then it is a new entry
            If (GunaTextBoxCodeCategorieHotel.Text.Trim().Equals("")) Then
                'check if the new entry  alreaday exist before insertion
                If Not hotelCatgory.hotelCategoryExists(CODE_CATEGORIE_HOTEL, LIBELLE) Then
                    'As the new entry does not exist then we insert it, and check the result
                    If hotelCatgory.insertHotelCategory(CODE_CATEGORIE_HOTEL, LIBELLE, PAIE_TAXE_SEJOUR, DATE_CREATION, CODE_UTILISATEUR) Then
                        MessageBox.Show("Nouvelle Catégorie hotel enregistré avec succès", "Création d'une catégorie hotel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'We empty the fields
                        Functions.SiplifiedClearTextBox(Me)
                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création d'une Catgeorie hotel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Cette categorie hotel existe déjà, Essayer à nouveau", "Création d'une categorie hotel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                'Code filed not empty so, we update the existing entry using the code
                If Not (GunaTextBoxLibelle.Text.Trim.Equals("")) Then

                    If hotelCatgory.updateHotelCategory(CODE_CATEGORIE_HOTEL, LIBELLE, PAIE_TAXE_SEJOUR) Then
                        MessageBox.Show("Catégorie Mise à jour !!", "Mise à d'une Catgeorie hotel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Remplir tous les champs!!", "Mise à d'une Catgeorie hotel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création d'une categorie hotel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    '----------------------------- LIVE SEARCH -------------------------------------


    'Reorganise when enteringinto live search by code
    Private Sub GunaTextBoxLiveSearch_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT `CODE_CATEGORIE_HOTEL` As 'CODE CATEGORIE HOTEL', `LIBELLE`, `MONTANT_TAXE` AS 'MONTANT TAXE', `DATE_CREATION` As 'DATE CREATION' FROM category_hotel_taxe_sejour_collectee ORDER BY LIBELLE ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            DataGridView1.DataSource = table

            DataGridView1.Columns("MONTANT TAXE").DefaultCellStyle.Format = "#,##0"
            DataGridView1.Columns("MONTANT TAXE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        'Connect.closeConnection()

    End Sub

    'Searching based on hotel category name
    Private Sub GunaTextBoxLiveSearchlibelle_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT * FROM category_hotel_taxe_sejour_collectee WHERE LIBELLE LIKE '%" & GunaTextBoxLiveSearchlibelle.Text & "%'"
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'DataGridView1.DataSource = table
        'Else

        'End If

        ''Connect.closeConnection()

    End Sub

    Private Sub GunaTextBoxLiveSearchlibelle_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT * FROM category_hotel_taxe_sejour_collectee ORDER BY LIBELLE ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            DataGridView1.DataSource = table
        End If

        'Connect.closeConnection()


    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        '--------------------------- FILL INPUT WITH DATA FROM DATAGRID FOR UPDAT---------------------------
        'Taking data from datagridView and insert into textBox for update

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)

            GunaTextBoxLibelle.Text = row.Cells("LIBELLE").Value.ToString
            GunaTextBoxCodeCategorieHotel.Text = row.Cells("CODE CATEGORIE HOTEL").Value.ToString
            GunaTextBoxMontantTaxeSejour.Text = row.Cells("MONTANT TAXE").Value.ToString

        End If

    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        categorieHotelEtMontantTaxeSejour()
    End Sub
End Class