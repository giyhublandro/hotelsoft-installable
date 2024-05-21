Public Class BrowserForm

    Private Sub BrowserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        addressBar.Text = "https://coup-de-balai.hotelsoft.cm/php/user.php?user_list"
        'InitializeComponent()

        getValue_ClickAsync()


    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        webView.CoreWebView2.Navigate(addressBar.Text)

    End Sub

    Private Sub addressBar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles addressBar.KeyDown

        If e.KeyCode = Keys.Enter Then

            If Not addressBar.Text.Contains("://") Then
                addressBar.Text = "https://" + addressBar.Text
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
        getValue_ClickAsync()
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