Imports MySql.Data.MySqlClient

Public Class TransfertDeClientEntreCaissierForm
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButtonClose.Click
        Me.Close()
    End Sub

    Public Sub UtilisateurDesCAisses()

        If GlobalVariable.billetageAPartirDe = "petite caisse" Then

            Dim CODE_CAISSE As String = PetiteCaisseForm.GunaTextBoxCodePetiteCaisse.Text

            Dim Query As String = "SELECT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR From utilisateurs, utilisateur_caisse, petite_caisse 
            WHERE petite_caisse.CODE_CAISSE = @CODE_CAISSE AND utilisateur_caisse.CODE_CAISSE = petite_caisse.CODE_CAISSE AND utilisateur_caisse.CODE_UTILISATEUR=utilisateurs.CODE_UTILISATEUR"

            Dim command As New MySqlCommand(Query, GlobalVariable.connect)
            'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            command.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE

            Dim tableCaissier As New DataTable
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(tableCaissier)

            If (tableCaissier.Rows.Count > 0) Then

                GunaComboBoxUtilisateurDeCaisse.DataSource = tableCaissier
                GunaComboBoxUtilisateurDeCaisse.ValueMember = "CODE_UTILISATEUR"
                GunaComboBoxUtilisateurDeCaisse.DisplayMember = "NOM_UTILISATEUR"

            End If

        ElseIf GlobalVariable.billetageAPartirDe = "bar" Then

            Dim Query As String = "SELECT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR, GRANDE_CAISSE From utilisateurs INNER JOIN utilisateur_acces WHERE utilisateurs.CATEG_UTILISATEUR=utilisateur_acces.CODE_PROFIL AND GRANDE_CAISSE=@GRANDE_CAISSE"
            Dim command As New MySqlCommand(Query, GlobalVariable.connect)
            'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            command.Parameters.Add("@GRANDE_CAISSE", MySqlDbType.Int32).Value = 1

            Dim tableCaissier As New DataTable
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(tableCaissier)

            If (tableCaissier.Rows.Count > 0) Then

                GunaComboBoxUtilisateurDeCaisse.DataSource = tableCaissier
                GunaComboBoxUtilisateurDeCaisse.ValueMember = "CODE_UTILISATEUR"
                GunaComboBoxUtilisateurDeCaisse.DisplayMember = "NOM_UTILISATEUR"

            End If
        End If

    End Sub

    Private Sub TransfertDeClientEntreCaissierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.TransfertDeClientEntreCaissier(GlobalVariable.actualLanguageValue)

        UtilisateurDesCAisses()

        If GunaComboBoxUtilisateurDeCaisse.Items.Count > 0 Then
            If GunaComboBoxUtilisateurDeCaisse.SelectedIndex >= 0 Then
                GunaButtonEnregistrer.Enabled = True
            Else
                GunaButtonEnregistrer.Enabled = False
            End If
        Else
            GunaButtonEnregistrer.Enabled = False
        End If
    End Sub

    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Me.Close()

        passwordVerifivationForm.Show()
        passwordVerifivationForm.TopMost = True

    End Sub

    Private Sub GunaComboBoxUtilisateurDeCaisse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUtilisateurDeCaisse.SelectedIndexChanged
        'UTILISATEURS DE CAISSE -> VERIFICATION DES MOTS DE PASSSES
        GlobalVariable.TransfertDeElementDeCaisse = GunaComboBoxUtilisateurDeCaisse.SelectedValue.ToString

    End Sub

End Class