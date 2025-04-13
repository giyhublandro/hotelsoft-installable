Option Infer On
Imports System.Net
Imports System.Text
Imports System.Web

Public Class BrowserForm

    Private Sub BrowserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Dim url As String = "https://restaurant.bluebirdcomplex.net"
        'webView.CoreWebView2.Navigate(url)


    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        Dim CODE_CLIENT As String = ""
        Dim NOM_CLIENT As String = ""
        Dim NOM_PRENOM As String = ""
        Dim NOM_JEUNE_FILLE As String = ""
        Dim PRENOMS As String = ""
        Dim ADRESSE As String = ""
        Dim TELEPHONE As String = ""
        Dim EMAIL As String = ""
        Dim NATIONALITE As String = ""
        Dim DATE_DE_NAISSANCE As Date
        Dim LIEU_DE_NAISSANCE As String = ""
        Dim PAYS_RESIDENCE As String = ""
        Dim VILLE_DE_RESIDENCE As String = ""
        Dim PROFESSION As String = ""
        Dim CNI As String = ""
        Dim DATE_CREATION As String = ""
        Dim CODE_UTILISATEUR_CREA As String = ""
        Dim TYPE_CLIENT As String = ""
        Dim CODE_AGENCE As String = ""
        Dim CODE_ENTREPRISE As String = ""
        Dim NUM_VEHICULE As String = ""
        Dim CIVILITE As String = ""
        Dim CODE_ELITE As String = ""
        Dim AGENCE As String = ""

        Dim clients As DataTable = Functions.GetAllElementsOnCondition(0, "client", "UPLOADED")

        If clients.Rows.Count > 0 Then

            For i = 0 To clients.Rows.Count - 1

                CODE_CLIENT = clients.Rows(i)("CODE_CLIENT")
                NOM_CLIENT = clients.Rows(i)("NOM_CLIENT")
                NOM_PRENOM = clients.Rows(i)("NOM_PRENOM")
                NOM_JEUNE_FILLE = clients.Rows(i)("NOM_JEUNE_FILLE")
                PRENOMS = clients.Rows(i)("PRENOMS")
                ADRESSE = clients.Rows(i)("ADRESSE")
                TELEPHONE = clients.Rows(i)("TELEPHONE")
                EMAIL = clients.Rows(i)("EMAIL")
                NATIONALITE = clients.Rows(i)("NATIONALITE")
                DATE_DE_NAISSANCE = clients.Rows(i)("DATE_DE_NAISSANCE")
                LIEU_DE_NAISSANCE = clients.Rows(i)("LIEU_DE_NAISSANCE")
                PAYS_RESIDENCE = clients.Rows(i)("PAYS_RESIDENCE")
                VILLE_DE_RESIDENCE = clients.Rows(i)("VILLE_DE_RESIDENCE")
                PROFESSION = clients.Rows(i)("PROFESSION")
                CNI = clients.Rows(i)("CNI")
                DATE_CREATION = clients.Rows(i)("DATE_CREATION")
                TYPE_CLIENT = clients.Rows(i)("TYPE_CLIENT")
                CODE_AGENCE = clients.Rows(i)("CODE_AGENCE")
                CODE_ENTREPRISE = clients.Rows(i)("CODE_ENTREPRISE")
                NUM_VEHICULE = clients.Rows(i)("NUM_VEHICULE")
                CIVILITE = clients.Rows(i)("CIVILITE")
                CODE_ELITE = clients.Rows(i)("CODE_ELITE")
                AGENCE = GlobalVariable.societe.Rows(0)("RAISON_SOCIALE")

                ' addressBar.Text = GlobalVariable.AgenceActuelle.Rows(0)("LIEN_EXTERNE") & "?client&CODE_CLIENT=" & CODE_CLIENT & "&NOM_CLIENT=" & NOM_CLIENT & "&NOM_PRENOM=" & NOM_PRENOM & "&NOM_JEUNE_FILLE=" & NOM_JEUNE_FILLE & "&PRENOMS=" & PRENOMS & "&AGENCE=" & AGENCE & "&CODE_ELITE=" & CODE_ELITE & "&CIVILITE=" & CIVILITE & "&NUM_VEHICULE=" & NUM_VEHICULE & "&CODE_ENTREPRISE=" & CODE_ENTREPRISE & "&CODE_AGENCE=" & CODE_AGENCE & "&TYPE_CLIENT=" & TYPE_CLIENT & "&ADRESSE=" & ADRESSE & "&EMAIL=" & EMAIL & "&PAYS_RESIDENCE=" & PAYS_RESIDENCE & "&NATIONALITE=" & NATIONALITE & "&DATE_DE_NAISSANCE=" & DATE_DE_NAISSANCE & "&DATE_CREATION=" & DATE_CREATION & "&LIEU_DE_NAISSANCE=" & LIEU_DE_NAISSANCE & "&VILLE_DE_RESIDENCE=" & VILLE_DE_RESIDENCE & "&PROFESSION=" & PROFESSION & "&CNI=" & CNI & ""
                'webView.CoreWebView2.Navigate(addressBar.Text)

                'Functions.updateOfFields("client", "UPLOADED", 1, "CODE_CLIENT", CODE_CLIENT, 1)

            Next

        End If

    End Sub

    Private Sub addressBar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles addressBar.KeyDown

        If e.KeyCode = Keys.Enter Then

            If Not addressBar.Text.Contains("://") Then
                'addressBar.Text = "https://" + addressBar.Text
            End If

            webView.CoreWebView2.Navigate(addressBar.Text)

        End If


    End Sub

    Private Function getValue_ClickAsync() As Task

        Dim login As String = "info@barcles.com"
        Dim pwd As String = "B@rcles2015"


        '1--------- PERMET DE RECUPERE LA VALUER D'UN CHAMP--------------------
        'Dim script = "document.getElementById('username').value"
        'Dim username As String = Await webView.CoreWebView2.ExecuteScriptAsync(script)
        'addressBar.Text = username.ToString

        '2- PERMET DE DONNER UNE VALEUR A UN CHAMP
        'Await webView.ExecuteScriptAsync($"document.getElementById('username').value = '" & login & "'")

        '3- CLICK SUR UN BOUTON
        'webView.ExecuteScriptAsync("document.getElementsByClassName(Iiab0gVMeWOd4XcyJGA3 wPxWIS_rJCpwAWksE0s3 Ut3prtt_wDsi7NM_83Jc TuDOVH9WFSdot9jLyXlw EJWUAldA4O1mP0SSFXPm whxYYRnvyHGyGqxO4ici).click()")

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        Dim url As String = "https://booking.com"
        webView.CoreWebView2.Navigate(url)

    End Sub


    Private Sub webView_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles webView.NavigationCompleted
        getValue_ClickAsync()
    End Sub

    Private Sub webView_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles webView.CoreWebView2InitializationCompleted
        Dim login As String = "info@barcles.com"
        Dim pwd As String = "B@rcles2015"

        For i = 0 To 3
            webView.ExecuteScriptAsync($"document.getElementById('username').value = '" & login & "'")
        Next

    End Sub

End Class