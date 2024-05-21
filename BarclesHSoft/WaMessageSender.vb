Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization

Public Class WaMessageSender

    ''' TODO: Replace the following with your gateway instance ID, Forever Green client ID and secret below:
    Private Const INSTANCE_ID As String = "45"
    Private Const CLIENT_ID As String = "info@barcles.com"
    Private Const CLIENT_SECRET As String = "483f79e13f2f46cdbb4e6c9e62f0e097"

    Private Const API_URL As String = "http://api.whatsmate.net/v3/whatsapp/single/text/message/" + INSTANCE_ID

    Public Function sendMessage(ByVal number As String, ByVal message As String) As Boolean
        Dim success As Boolean = True
        Dim webClient As New WebClient()

        Try
            Dim payloadObj As New Payload(number, message)
            Dim serializer As New JavaScriptSerializer()
            Dim postData As String = serializer.Serialize(payloadObj)

            webClient.Headers("content-type") = "application/json"
            webClient.Headers("X-WM-CLIENT-ID") = CLIENT_ID
            webClient.Headers("X-WM-CLIENT-SECRET") = CLIENT_SECRET

            webClient.Encoding = Encoding.UTF8
            Dim response As String = webClient.UploadString(API_URL, postData)
            Console.WriteLine(response)

        Catch webEx As WebException
            Dim res As HttpWebResponse = DirectCast(webEx.Response, HttpWebResponse)
            'Dim stream As Stream = res.GetResponseStream()
            'Dim reader As New StreamReader(stream)
            'Dim body As String = reader.ReadToEnd()

            Console.WriteLine(res.StatusCode)
            'Console.WriteLine(body)
            success = False
        End Try

        Return success
    End Function


    Private Class Payload
        Public number As String
        Public message As String

        Sub New(ByVal num As String, ByVal msg As String)
            number = num
            message = msg
        End Sub
    End Class

End Class
