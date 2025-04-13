Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Imports System.IO

Public Class ProfilChoixForm

    Private Sub GunaButtonAjouter_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouter.Click

        If GunaComboBoxProfils.SelectedIndex >= 0 Then

            Dim CATEG_UTILISATEUR As String = GunaComboBoxProfils.SelectedValue.ToString
            Dim AccesUtilisateurActuel As DataTable = AccessRight.DroitAccesUtilisateurActuel(Trim(CATEG_UTILISATEUR))

            GlobalVariable.DroitAccesDeUtilisateurConnect = AccesUtilisateurActuel

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_RESERVATION") = 1 Then
                    HomeForm.GunaButtonMenuReservation.Enabled = True
                    HomeForm.GunaButtonReservation.Enabled = True
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_RECEPTION") = 1 Then
                    HomeForm.GunaButtonMenuReception.Enabled = True
                    HomeForm.GunaButtonReception.Enabled = True
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_ECONOMAT") = 1 Then
                    HomeForm.GunaButtonMenuEconomat.Enabled = True
                    HomeForm.GunaButtonEconomat.Enabled = True
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_SERVICE_ETAGE") = 1 Then
                    HomeForm.GunaButtonMenuService.Enabled = True
                    HomeForm.GunaButtonServiceEtage.Enabled = True
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_BAR_RESTAURANT") = 1 Then
                    HomeForm.GunaButtonMenuBarRestaurant.Enabled = True
                    HomeForm.GunaButtonBarResturant.Enabled = True
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_COMPTABILITE") = 1 Then
                    HomeForm.GunaButtonMenuComptabilite.Enabled = True
                    HomeForm.GunaButtonCompatbilite.Enabled = True
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_TECHNIQUE") = 1 Then
                    HomeForm.GunaButtonMenuTechnique.Enabled = True
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_CUISINE") = 1 Then
                    HomeForm.GunaButtonCuisine.Enabled = True
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_MARKETING") = 1 Then
                    HomeForm.GunaButtonMarketing.Enabled = True
                End If

            End If

            Me.Close()

        End If

    End Sub

    Private Sub ProfilChoixForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim languages As New Languages()
        languages.profilChoix(GlobalVariable.actualLanguageValue)

        HomeForm.GunaButtonMenuReservation.Enabled = False
        HomeForm.GunaButtonReservation.Enabled = False

        HomeForm.GunaButtonMenuReception.Enabled = False
        HomeForm.GunaButtonReception.Enabled = False

        HomeForm.GunaButtonMenuEconomat.Enabled = False
        HomeForm.GunaButtonEconomat.Enabled = False

        HomeForm.GunaButtonMenuService.Enabled = False
        HomeForm.GunaButtonServiceEtage.Enabled = False

        HomeForm.GunaButtonMenuBarRestaurant.Enabled = False
        HomeForm.GunaButtonBarResturant.Enabled = False

        HomeForm.GunaButtonMenuComptabilite.Enabled = False
        HomeForm.GunaButtonCompatbilite.Enabled = False

        HomeForm.GunaButtonMenuTechnique.Enabled = False
        HomeForm.GunaButtonCuisine.Enabled = False
        HomeForm.GunaButtonMarketing.Enabled = False

        'HomeForm.GunaButtonChoixProfil.Visible = True

        profilListProfilMultiple()
    End Sub

    Public Sub profilListProfilMultiple()

        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim profils As String = "SELECT utilisateur_acces.CODE_PROFIL, NOM_PROFIL FROM utilisateur_acces, utilisateur_acces_profil 
        WHERE utilisateur_acces_profil.CODE_UTILISATEUR=@CODE_UTILISATEUR AND utilisateur_acces.CODE_PROFIL = utilisateur_acces_profil.CODE_PROFIL ORDER BY NOM_PROFIL ASC"

        Dim commandprofilsList As New MySqlCommand(profils, GlobalVariable.connect)

        Dim adapterprofilsList As New MySqlDataAdapter(commandprofilsList)
        commandprofilsList.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        Dim tableprofilsList As New DataTable()
        adapterprofilsList.Fill(tableprofilsList)

        If (tableprofilsList.Rows.Count > 0) Then

            GunaComboBoxProfils.DataSource = tableprofilsList
            GunaComboBoxProfils.ValueMember = "CODE_PROFIL"
            GunaComboBoxProfils.DisplayMember = "NOM_PROFIL"

        End If

    End Sub

    Private Sub GunaComboBoxProfils_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxProfils.SelectedIndexChanged

        Me.Cursor = Cursors.Default

    End Sub

End Class