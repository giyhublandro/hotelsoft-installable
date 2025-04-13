Option Infer On
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.IO

Public Class GenerationForm
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub


    Dim CODE As String = ""
    Dim RECIPIENT As String = ""

    Private Sub GenerationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.authetification(GlobalVariable.actualLanguageValue)

        Dim configCustom As New ConfigCustomizationClass()
        Dim formName As String = "authentification"
        configCustom.customization(formName)

        GunaComboBoxAction.SelectedIndex = 0

        Dim Query As String = "SELECT NOM_UTILISATEUR, utilisateurs.CODE_UTILISATEUR, CORRECTIONS From utilisateurs, utilisateur_acces WHERE utilisateurs.CATEG_UTILISATEUR=utilisateur_acces.CODE_PROFIL AND CORRECTIONS=@CORRECTIONS"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@CORRECTIONS", MySqlDbType.Int32).Value = 1

        Dim tableCaissier As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(tableCaissier)

        If (tableCaissier.Rows.Count > 0) Then

            GunaComboBoxUtilisateur.DataSource = tableCaissier
            GunaComboBoxUtilisateur.ValueMember = "CODE_UTILISATEUR"
            GunaComboBoxUtilisateur.DisplayMember = "NOM_UTILISATEUR"

        End If

    End Sub

    Private Sub GunaButtonAfficherValidee_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherValidee.Click

        'WebView21.CoreWebView2.Navigate(addressBar.Text)

        Dim licence As New Licence()

        If GunaComboBoxUtilisateur.SelectedIndex >= 0 Then

            If GunaComboBoxUtilisateur IsNot Nothing Then

                Dim Message As String = ""
                Dim title As String = ""
                If GlobalVariable.actualLanguageValue = 1 Then
                    Message = "CODE D'AUTHETIFICATION ENOVOYE A " & GunaComboBoxUtilisateur.SelectedValue.ToString.ToUpper()
                title = "CODE D'AUTHETIFICATION"
                Else
                    title = "AUTHETIFICATION CODE"
                    Message = "AUTHETIFICATION CODE SEND TO " & GunaComboBoxUtilisateur.SelectedValue.ToString.ToUpper()
                End If

                Dim ACTION As Integer = GunaComboBoxAction.SelectedIndex
                Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail

                licence.authentification_code(ACTION, DATE_CREATION, CODE)

                Functions.ultrMessageSimpleText(CODE + " : " + GunaComboBoxAction.SelectedItem, RECIPIENT)

                'Functions.sendSms(RECIPIENT, CODE)

                GunaLabel2.Text = Message
                GunaLabel2.Visible = True

            End If

        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        Dim ETAT As Integer = 1

        If Trim(GunaTextBoxCode.Text).Equals("") Then

            GunaLabel1.Text = "Bien vouloir saisir un Code"
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaLabel1.Text = "Please Key in a Code"
            End If
            GunaLabel1.ForeColor = Color.Red
            GunaLabel1.Visible = True

        Else

            Dim CODE_VERIF As String = Trim(GunaTextBoxCode.Text)
            Dim authentification As DataTable = Functions.getElementByCode(CODE_VERIF, "authentification_code", "CODE")

            If authentification.Rows.Count > 0 Then

                If authentification.Rows(0)("ETAT") = 0 Then

                    Functions.updateOfFields("authentification_code", "ETAT", ETAT, "CODE", CODE_VERIF, 0)

                    If authentification.Rows(0)("ACTION") = 0 Then 'EDITION DU PRIX

                        If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then
                            MainWindow.GunaTextBoxMontantAccorde.Enabled = True
                        End If

                    ElseIf authentification.Rows(0)("ACTION") = 1 Then

                        If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then
                            MainWindow.annulationCheckin()
                        ElseIf GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 1 Then
                            RestaurantBookingForm.annulationCheckin()
                        End If

                    ElseIf authentification.Rows(0)("ACTION") = 2 Then

                        Me.Close()

                        SituationClientForm.chargeCancellation()

                    ElseIf authentification.Rows(0)("ACTION") = 3 Then

                        Me.Close()

                        SituationClientForm.discountOnCharge()

                    End If

                    Me.Close()

                Else
                    GunaLabel1.Text = "Ce code a déjà été utilisé"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        GunaLabel1.Text = "This code has been used already"
                    End If
                    GunaLabel1.ForeColor = Color.Red
                    GunaLabel1.Visible = True
                End If

            Else

                GunaLabel1.Text = "Ce code est invalide"
                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaLabel1.Text = "This is an invalid Code"
                End If
                GunaLabel1.ForeColor = Color.Red
                GunaLabel1.Visible = True

            End If

        End If

    End Sub

    Private Sub GunaTextBoxCode_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCode.TextChanged

        If Trim(GunaTextBoxCode.Text).Equals("") Then
            GunaLabel1.Text = ""
            GunaLabel1.ForeColor = Color.Black
            GunaLabel1.Visible = False
        End If

    End Sub

    Private Sub GunaComboBoxUtilisateur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUtilisateur.SelectedIndexChanged

        If GunaComboBoxUtilisateur.SelectedIndex >= 0 Then

            Dim CODE_UTILISATEUR As String = GunaComboBoxUtilisateur.SelectedValue.ToString

            Dim user As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "utilisateurs", "CODE_UTILISATEUR")

            If user.Rows.Count > 0 Then
                RECIPIENT = user.Rows(0)("TELEPHONE")
            End If

            Dim url As String = "https://api.avlytext.com/v1/sms?api_key=YqGVfzYQogJawDyZXbP8v1hgcjkZj0IC3uMqsKuQVtkWy0pP0l66490hCLTXcEhLPsk4&sender=HOTELSOFT&recipient="
            CODE = Functions.authentificationCode("authentification_code", "")

        End If

    End Sub

End Class