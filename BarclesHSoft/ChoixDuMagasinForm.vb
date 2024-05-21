Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ChoixDuMagasinForm

    Private Sub ChoixDuMagasinForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.choixDuMagasin(GlobalVariable.actualLanguageValue)

        'Loading other 'article families cureently called article type into a combobox
        Dim existQuery As String = "SELECT CODE_UTILISATEUR, CODE_MAGAZIN, LIBELLE_MAGASIN FROM `utilisateur_magazin`,`magasin` WHERE CODE_UTILISATEUR = @CODE_UTILISATEUR AND utilisateur_magazin.CODE_MAGAZIN=magasin.CODE_MAGASIN "

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = Trim(GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR"))

        Dim adapter As New MySqlDataAdapter(command)
        Dim lesMagasins As New DataTable()
        adapter.Fill(lesMagasins)

        If lesMagasins.Rows.Count > 0 Then

            GunaComboBoxMagasins.DataSource = lesMagasins
            'GunaComboBoxChambreRoutage.ValueMember = "CODE_FAMILLE"
            GunaComboBoxMagasins.ValueMember = "CODE_MAGAZIN"
            GunaComboBoxMagasins.DisplayMember = "LIBELLE_MAGASIN"

        End If

    End Sub

    Private Sub GunaButtonOuvrirSession_Click(sender As Object, e As EventArgs) Handles GunaButtonOuvrirSession.Click

        GlobalVariable.shiftActuel = GunaComboBoxShift.SelectedIndex
        GlobalVariable.magasinActuel = GunaComboBoxMagasins.SelectedValue.ToString

        Functions.inventaireJournalierTextFile(GlobalVariable.magasinActuel, GlobalVariable.shiftActuel, 0)

        If GlobalVariable.billetageAPartirDe = "bar" Then

            BarRestaurantForm.autoLoadMagasinActuel()

            '0 : shift du matin
            '1 : shift du soir
            '2 : shift de nuit

        End If

        Me.Close()

    End Sub

    Private Sub GunaComboBoxShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxShift.SelectedIndexChanged

        If GunaComboBoxShift.SelectedIndex >= 0 Then

            If GunaComboBoxMagasins.SelectedIndex >= 0 Then
                GunaButtonOuvrirSession.Enabled = True
            Else
                GunaButtonOuvrirSession.Enabled = False
            End If

        Else
            GunaButtonOuvrirSession.Enabled = False
        End If

    End Sub

    Private Sub GunaComboBoxMagasins_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxMagasins.SelectedIndexChanged

        If GunaComboBoxMagasins.SelectedIndex >= 0 Then

            If GunaComboBoxShift.SelectedIndex >= 0 Then
                GunaButtonOuvrirSession.Enabled = True
            Else
                GunaButtonOuvrirSession.Enabled = False
            End If

        Else
            GunaButtonOuvrirSession.Enabled = False
        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub
End Class