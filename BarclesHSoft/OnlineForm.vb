Public Class OnlineForm

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'Dim url As String = GlobalVariable.AgenceActuelle.Rows(0)("OBKL")
        'webView.CoreWebView2.Navigate(url)
        'Timer1.Stop()
        'Timer2.Start()
    End Sub

    Private Sub webView_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs)
        'Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ' Dim url As String = GlobalVariable.AgenceActuelle.Rows(0)("OBKL")
        'webView.CoreWebView2.Navigate(url)
    End Sub

    Private Sub OnlineForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaButton1.Visible = True
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim url As String = GlobalVariable.AgenceActuelle.Rows(0)("OBKL")
        WebBrowser1.Navigate(url)
    End Sub

End Class