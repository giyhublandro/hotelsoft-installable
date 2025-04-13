Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Imports System.Net.Mail

Imports MySql.Data.MySqlClient
Imports System.Data.Odbc

Public Class DocumentsSendingClass

    Public Sub sendDocument(ByVal fichier As String, ByVal WHATSAPP_OU_MAIL As Integer, ByVal CODE_CLIENT As String, ByVal document As Integer)

        'document = 1 : Confirmation de Reservation Chambre
        'document = 2 : Devis Estimatif
        'document = 3 : Confirmation de Reservation Salle
        'document = 4 : Fiche de police 
        'document = 5 : Hall Rent Contract
        'document = 6 : Receipt
        'document = 7 : Invoice

        Dim NOM_PRENOM As String = ""
        Dim TELEPHONE As String = ""
        Dim EMAIL As String = ""
        Dim Titre As String = ""
        Dim bodyText As String = ""

        Dim nmessageOuDocument As Integer = 1
        Dim typeDeDocument As Integer = 2

        Dim client As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")
        If Client.Rows.Count > 0 Then
            NOM_PRENOM = Client.Rows(0)("NOM_PRENOM")
            EMAIL = Client.Rows(0)("EMAIL")
        End If

        If document = 1 Or document = 3 Then

            Titre = "FICHE DE CONFIRMATION DE RESERVATION DE " & NOM_PRENOM
            bodyText = "Ci jointe votre fiche de confirmation de reservation"

            If GlobalVariable.actualLanguageValue = 0 Then
                Titre = "BOOKING CONFIRMATION FORM OF " & NOM_PRENOM
                bodyText = "Attachement Booking Confirmation"
            End If

        ElseIf document = 2 Then

            Titre = "DEVIS DE LOCATION DE SALLE DE " & NOM_PRENOM
            bodyText = "Ci jointe votre dévis de location de salle"

            If GlobalVariable.actualLanguageValue = 0 Then
                Titre = "HALL RENTING ESTIMATE OF " & NOM_PRENOM
                bodyText = "Attachement Hall Renting Estiamte"
            End If

        ElseIf document = 4 Then

            'FICHE DE POLICE
            Titre = "FICHE DE RENSEIGNEMENT DE " & NOM_PRENOM
            bodyText = "Ci jointe votre fiche de renseignement"
            If GlobalVariable.actualLanguageValue = 0 Then
                Titre = "REGISTRATION FORM OF " & Client.Rows(0)("NOM_PRENOM")
                bodyText = "Attachement Registration Form"
            End If

        ElseIf document = 5 Then

            Titre = "CONTRAT DE LOCATION DE SALLE DE " & NOM_PRENOM
            bodyText = "Ci jointe votre contrat de location de salle"
            If GlobalVariable.actualLanguageValue = 0 Then
                Titre = "HALL RENT CONTRACT OF " & NOM_PRENOM
                bodyText = "Attachement Hall Rent Contract"
            End If

        ElseIf document = 6 Then

            Titre = "FACTURE DE " & NOM_PRENOM
            bodyText = "Ci jointe votre facture"

            If GlobalVariable.actualLanguageValue = 0 Then
                Titre = "INVOICE OF " & NOM_PRENOM
                bodyText = "Attachement Invoice"
            End If

        ElseIf document = 7 Then

            Titre = "RECU DE " & NOM_PRENOM
            bodyText = "Ci jointe votre facture"

            If GlobalVariable.actualLanguageValue = 0 Then
                Titre = "RECEIPT OF " & NOM_PRENOM
                bodyText = "Attachement Receipt"
            End If

        End If

        If WHATSAPP_OU_MAIL = 1 Then
            envoieDocumentMailClient(fichier, Titre, bodyText, EMAIL)
        ElseIf WHATSAPP_OU_MAIL = 0 Then
            Functions.ultrMessage(fichier, nmessageOuDocument, Titre, bodyText, typeDeDocument, TELEPHONE)
        End If

    End Sub

    Public Shared Async Sub envoieDocumentMailClient(ByVal fichier As String, ByVal Titre As String, ByVal bodyText As String, ByVal Email As String)

        Dim haveInternet As Boolean = Functions.checkInternetCOnnection()

        If haveInternet Then

            Try
                'ENVOI DES RAPPORTS PAR MAIL

                If Not Trim(Email).Equals("") Then

                    Dim emailTo As String = Email
                    'Dim emailFrom As String = "rapport@hotelsoft.cm"
                    Dim emailFrom As String = GlobalVariable.AgenceActuelle.Rows(0)("MAIL_USER_NAME")

                    Dim mail As New MailMessage()
                    'Dim SmtpServer As New SmtpClient("smtp.gmail.com")
                    Dim SmtpServer As New SmtpClient("mail53.lwspanel.com")
                    mail.From = New MailAddress(emailFrom)

                    mail.[To].Add(emailTo)

                    Dim attachment As System.Net.Mail.Attachment
                    attachment = New System.Net.Mail.Attachment(fichier)

                    mail.Attachments.Add(attachment)

                    mail.Subject = Titre
                    mail.Body = bodyText

                    SmtpServer.Port = 587

                    Dim userName As String = GlobalVariable.AgenceActuelle.Rows(0)("MAIL_USER_NAME")
                    Dim pwd As String = GlobalVariable.AgenceActuelle.Rows(0)("MAIL_PASSWORD")

                    'SmtpServer.Credentials = New System.Net.NetworkCredential("rapport@hotelsoft.cm", "H@telsoft2022")
                    SmtpServer.Credentials = New System.Net.NetworkCredential(userName, pwd)

                    'SmtpServer.UseDefaultCredentials = True
                    SmtpServer.EnableSsl = False

                    SmtpServer.Send(mail)

                End If

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Envoi de mail", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try

        End If

    End Sub

End Class
