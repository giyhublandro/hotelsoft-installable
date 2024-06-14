Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Imports System.Net.Mail

Imports MySql.Data.MySqlClient
Imports System.Data.Odbc

Class HeaderFooter

    Inherits PdfPageEventHelper

    Dim societe As DataTable = Functions.allTableFields("societe")

    Dim CODE_AGENCE As String = GlobalVariable.codeAgence

    Dim UTILISE As Integer = 1

    Public Overrides Async Sub OnEndPage(writer As PdfWriter, document As Document)

        Dim papierEnTete As DataTable = Functions.getElementByCode(CODE_AGENCE, "papier_entete", "CODE_AGENCE")

        Dim HeaderFont As New Font(iTextSharp.text.Font.FontFamily.COURIER, 22, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font1 As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font2 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font4 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font3 As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

        Dim pdfCell As PdfPCell = Nothing

        Dim img() As Byte
        img = societe.Rows(0)("LOGO")

        Dim img2() As Byte
        img2 = papierEnTete.Rows(0)("IMAGE_2")

        Dim img1() As Byte
        img1 = papierEnTete.Rows(0)("IMAGE_1")

        Dim mStream As New MemoryStream(img)
        Dim mStream2 As New MemoryStream(img2)
        Dim mStream1 As New MemoryStream(img1)

        Dim logo As Image
        logo = Image.GetInstance(img)
        logo.ScalePercent(65.0F)

        Dim IMAGE_2 As Image
        IMAGE_2 = Image.GetInstance(img2)
        IMAGE_2.ScalePercent(18.0F)

        Dim IMAGE_1 As Image
        IMAGE_1 = Image.GetInstance(img1)
        IMAGE_1.ScalePercent(18.0F)

        Dim pHeader As New PdfPTable(1)
        pHeader.TotalWidth = document.PageSize.Width
        pHeader.DefaultCell.Border = 0

        Dim pHeaderSubTitle As New PdfPTable(1)
        pHeaderSubTitle.TotalWidth = document.PageSize.Width
        pHeaderSubTitle.DefaultCell.Border = 0

        Dim pHeaderSubTitle1 As New PdfPTable(1)
        pHeaderSubTitle1.TotalWidth = document.PageSize.Width
        pHeaderSubTitle1.DefaultCell.Border = 0

        '------------------------------------------------------------------ START HEADER ----------------------------------------------------------------------------------

        If papierEnTete.Rows.Count > 0 Then

            Dim EN_TETE_L1 = papierEnTete.Rows(0)("EN_TETE_L1")
            Dim EN_TETE_L2 = papierEnTete.Rows(0)("EN_TETE_L2")
            Dim EN_TETE_L3 = papierEnTete.Rows(0)("EN_TETE_L3")
            Dim EN_TETE_L4 = papierEnTete.Rows(0)("EN_TETE_L4")
            Dim PIEDS_L1 = papierEnTete.Rows(0)("PIEDS_L1")
            Dim PIEDS_L2 = papierEnTete.Rows(0)("PIEDS_L2")
            Dim PIEDS_L3 = papierEnTete.Rows(0)("PIEDS_L3")

            If papierEnTete.Rows(0)("UTILISE") = 1 Then

                Dim pdfTable As New PdfPTable(3) 'Number of columns

                pdfTable.TotalWidth = document.PageSize.Width
                pdfTable.LockedWidth = True
                pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                'pdfTable.HeaderRows = 1

                Dim widths As Single() = New Single() {2.4F, 10.0F, 2.4F}
                pdfTable.SetWidths(widths)

                pdfCell = New PdfPCell(logo)
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.Border = 0
                pdfCell.PaddingLeft = 15.0F
                pdfTable.AddCell(pdfCell)

                Dim mtable As PdfPTable = New PdfPTable(1)
                mtable.WidthPercentage = 100
                mtable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

                pdfCell = New PdfPCell(New Paragraph(societe.Rows(0)("RAISON_SOCIALE"), HeaderFont))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0 'used to remove borders on the cells

                mtable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(EN_TETE_L1 & Chr(13), font1))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0 'used to remove borders on the cells

                mtable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(EN_TETE_L2, font3))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0 'used to remove borders on the cells

                mtable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(EN_TETE_L3, font3))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0 'used to remove borders on the cells

                mtable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(EN_TETE_L4, font3))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0 'used to remove borders on the cells

                mtable.DefaultCell.BorderWidth = 0
                pdfTable.DefaultCell.BorderWidth = 0

                mtable.AddCell(pdfCell)

                pdfTable.AddCell(mtable)

                pdfCell = New PdfPCell(IMAGE_2)
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.Border = 0
                pdfCell.PaddingRight = 15.0F

                If document.PageNumber = 1 Then
                    pdfTable.AddCell(pdfCell)
                    pdfTable.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 155, writer.DirectContent)
                Else
                    pdfTable.AddCell(pdfCell)
                End If

                '----------------------------------------------------------------------------------------------------------------------------------------------------------------

                If GlobalVariable.DocumentToGenerate = "situation caisse" Then
                    pdfCell = New PdfPCell(New Paragraph("               SIGNATURE DU CAISSIER                                               SIGNATURE DU COMPTABLE"))
                ElseIf GlobalVariable.DocumentToGenerate = "DST" Then
                    pdfCell = New PdfPCell(New Paragraph(""))
                ElseIf GlobalVariable.DocumentToGenerate = "reglement" Or GlobalVariable.DocumentToGenerate = "facture" Then
                    pdfCell = New PdfPCell(New Paragraph("               SIGNATURE DU CLIENT                                                    SIGNATURE DE L'HOTEL"))
                Else
                    pdfCell = New PdfPCell(New Paragraph("               SIGNATURE DU CLIENT                                                    SIGNATURE DE L'HOTEL"))
                End If

                pdfTable.AddCell(pdfCell)

                Dim pFooter As New PdfPTable(1)
                pFooter.TotalWidth = document.PageSize.Width
                pdfCell.PaddingLeft = 15.0F
                pFooter.DefaultCell.Border = 0

                pdfCell = New PdfPCell(New Paragraph(PIEDS_L1, font4))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 15.0F
                pdfCell.Border = 0
                pFooter.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(PIEDS_L2 & Chr(13) & PIEDS_L3 & Chr(13) & " BARCLES HOTEL SOFT " & GlobalVariable.DateDeTravail & "-" & Now().ToLongTimeString, font2))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 15.0F
                pdfCell.Border = 0
                pFooter.AddCell(pdfCell)

                'pFooter.WriteSelectedRows(0, -1, 0, document.GetBottom(document.BottomMargin) - 23, writer.DirectContent)
                pFooter.WriteSelectedRows(0, -1, 0, 55, writer.DirectContent)

                'COIN INFERIEUR GAUCHE
                Dim pFooterLeft As New PdfPTable(1)
                pFooterLeft.TotalWidth = document.PageSize.Width
                pdfCell.PaddingLeft = 15.0F
                pFooterLeft.DefaultCell.Border = 0

                pdfCell = New PdfPCell(IMAGE_1)
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                pdfCell.PaddingLeft = 15.0F
                pdfCell.Border = 0
                pFooterLeft.AddCell(pdfCell)
                'pFooterLeft.WriteSelectedRows(0, -1, 0, document.GetBottom(document.BottomMargin) + 15, writer.DirectContent)
                pFooterLeft.WriteSelectedRows(0, -1, 0, 95, writer.DirectContent)


            ElseIf papierEnTete.Rows(0)("UTILISE") = 0 Then


                Dim mtable As PdfPTable = New PdfPTable(1)
                mtable.WidthPercentage = 100
                mtable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

                '--------------------------------------------------------------

                Dim pdfTable As New PdfPTable(2) 'Number of columns

                pdfTable.TotalWidth = document.PageSize.Width
                pdfTable.LockedWidth = True
                pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT

                Dim widths As Single() = New Single() {30.0F, 70.0F}
                pdfTable.SetWidths(widths)

                pdfCell = New PdfPCell(logo)
                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell.MinimumHeight = 15
                pdfCell.Border = 0
                pdfCell.PaddingLeft = 15.0F
                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(societe.Rows(0)("RAISON_SOCIALE"), HeaderFont))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0 'used to remove borders on the cells
                mtable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(Chr(13) & EN_TETE_L1 & Chr(13) & EN_TETE_L2 & Chr(13) & EN_TETE_L3 & Chr(13) & EN_TETE_L4, font1))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 5.0F
                pdfCell.MinimumHeight = 15
                pdfCell.Border = 0 'used to remove borders on the cells
                mtable.AddCell(pdfCell)

                mtable.DefaultCell.BorderWidth = 0
                pdfTable.DefaultCell.BorderWidth = 0

                If document.PageNumber = 1 Then
                    pdfTable.AddCell(mtable)
                    pdfTable.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 155, writer.DirectContent)
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------

                Dim pFooter As New PdfPTable(1)
                pFooter.TotalWidth = document.PageSize.Width
                pdfCell.PaddingLeft = 15.0F
                pdfCell.MinimumHeight = 15
                pFooter.DefaultCell.Border = 0

                pdfCell = New PdfPCell(New Paragraph(PIEDS_L1, font4))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 15.0F
                pdfCell.MinimumHeight = 15
                pdfCell.Border = 0
                pFooter.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(PIEDS_L2 & Chr(13) & PIEDS_L3 & Chr(13) & " BARCLES HOTEL SOFT " & GlobalVariable.DateDeTravail & "-" & Now().ToLongTimeString, font2))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.PaddingLeft = 15.0F
                pdfCell.MinimumHeight = 15
                pdfCell.Border = 0
                pFooter.AddCell(pdfCell)

                pFooter.WriteSelectedRows(0, -1, 0, 55, writer.DirectContent)

            End If

        End If

    End Sub

End Class

'-------------------------- HEADER ------------------------------------------------

Public Class RapportApresCloture

    Public Shared Async Sub RapportMainCourante(ByVal dateMainCouranteDebut As Date, ByVal dateMainCouranteFin As Date, Optional renvoie As Boolean = False)

        Dim changerSigne As Integer = -1

        Dim societe As DataTable = Functions.allTableFields("societe")
        Dim TotalFacture As Double = 0

        Dim tireDocument As String = ""
        Dim titreFichier As String = ""

        Dim nomDuDossierRapport As String = "RAPPORTS\MAINCOURANTES"
        Dim filePathAndDirectory As String = ""
        filePathAndDirectory = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & dateMainCouranteDebut.ToString("ddMMyy")

        Dim dtRapport As DataTable = Functions.verificationExistenceCheminDesRapportsDuJours(dateMainCouranteDebut)
        Dim fichier As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            titreFichier = "MAIN COURANTE JOURNALIERE"
            tireDocument = titreFichier & " DU " & dateMainCouranteDebut.ToShortDateString
        Else
            titreFichier = "DAILY FINANCIAL REPORT"
            tireDocument = titreFichier & " OF " & dateMainCouranteDebut.ToShortDateString
        End If

        If dtRapport.Rows.Count > 0 Then

            If Not Trim(dtRapport.Rows(0)("CHEMIN_MAINCOURANTE")).Equals("") Then
                fichier = dtRapport.Rows(0)("CHEMIN_MAINCOURANTE")
            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    fichier = filePathAndDirectory & "\" & titreFichier & " DU " & dateMainCouranteDebut.ToString("ddMMyy") & ".pdf"
                Else
                    fichier = filePathAndDirectory & "\" & titreFichier & " OF " & dateMainCouranteDebut.ToString("ddMMyy") & ".pdf"
                End If

            End If

        Else

            My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

            If Not renvoie Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    fichier = filePathAndDirectory & "\" & titreFichier & " DU " & GlobalVariable.DateDeTravail.AddDays(-1).ToString("ddMMyy") & ".pdf"
                Else
                    fichier = filePathAndDirectory & "\" & titreFichier & " OF " & GlobalVariable.DateDeTravail.AddDays(-1).ToString("ddMMyy") & ".pdf"
                End If

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    fichier = filePathAndDirectory & "\" & titreFichier & " DU " & dateMainCouranteDebut.ToString("ddMMyy") & ".pdf"
                Else
                    fichier = filePathAndDirectory & "\" & titreFichier & " OF " & dateMainCouranteDebut.ToString("ddMMyy") & ".pdf"
                End If

            End If

        End If

        Dim bodyText As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            bodyText = "Recevez nos salutations," & Chr(13) & " Merci de bien vouloir trouver ci joint la " & tireDocument.ToLower() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
        Else
            bodyText = "Receive our greetings," & Chr(13) & " Attachement " & tireDocument.ToLower() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do no respond to this mail !!"
        End If

        envoieDocumentMailCloture(fichier, tireDocument, bodyText, dateMainCouranteDebut)

        'envoieDocumentMailCloture_2(tireDocument, bodyText, dateMainCouranteDebut)

        Dim nmessageOuDocument As Integer = 1
        Dim typeDeDocument As Integer = 0

        Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument)

    End Sub

    Public Shared Async Sub RapportMainCouranteCumul(ByVal dt As DataTable, ByVal dateMainCouranteDebut As Date, ByVal dateMainCouranteFin As Date, Optional renvoie As Boolean = False)

        Dim changerSigne As Integer = -1

        Dim societe As DataTable = Functions.allTableFields("societe")
        Dim TotalFacture As Double = 0

        Dim tireDocument As String = ""
        Dim titreFichier As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            titreFichier = "MAIN COURANTE CUMULE"
            tireDocument = titreFichier & " DU " & dateMainCouranteDebut.ToShortDateString & " AU " & dateMainCouranteFin.ToShortDateString
        Else
            titreFichier = "CUMULATED FINANCIAL REPORT"
            tireDocument = titreFichier & " FROM " & dateMainCouranteDebut.ToShortDateString & " TO " & dateMainCouranteFin.ToShortDateString
        End If

        Dim nomDuDossierRapport As String = "RAPPORTS\MAINCOURANTES_CUMUL"

        Dim filePathAndDirectory As String = ""


        filePathAndDirectory = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & dateMainCouranteDebut.ToString("ddMMyy") & dateMainCouranteFin.ToString("ddMMyy")

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim fichier As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            fichier = filePathAndDirectory & "\" & titreFichier & " DU " & dateMainCouranteDebut.ToString("ddMMyy") & " AU " & dateMainCouranteFin.ToString("ddMMyy") & ".pdf"
        Else
            fichier = filePathAndDirectory & "\" & titreFichier & " OF " & dateMainCouranteDebut.ToString("ddMMyy") & " TO " & dateMainCouranteFin.ToString("ddMMyy") & ".pdf"
        End If

        'Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
        Dim pdfDoc As New Document(PageSize.A3.Rotate, 20, 20, 80, 40)

        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
        Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font1 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        Dim pdfTable As New PdfPTable(21) 'Number of columns
        pdfTable.TotalWidth = 1150.0F
        pdfTable.LockedWidth = True
        pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfTable.HeaderRows = 1

        Dim widths As Single() = New Single() {6.0F, 26.0F, 10.0F, 10.0F, 7.0F, 6.0F, 10.0F, 10.0F, 10.0F, 10.0F, 10.0F, 10.0F, 10.0F, 10.0F, 11.0F, 11.0F, 12.0F, 10.0F, 10.0F, 10.0F, 12.0F}
        pdfTable.SetWidths(widths)

        Dim pdfCell As PdfPCell = Nothing

        pdfWrite.PageEvent = New HeaderFooter

        pdfDoc.Open()

        Dim p10 As Paragraph = New Paragraph(Chr(13) & Chr(13) & tireDocument & Chr(13) & Chr(13) & Chr(13))
        p10.Alignment = Element.ALIGN_CENTER
        pdfDoc.Add(p10)

        If GlobalVariable.actualLanguageValue = 0 Then

            pdfCell = New PdfPCell(New Paragraph("RM", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("FIRST & LAST NAME", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("ARRIVAL", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DEPART.", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("NIGHT", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("PAX", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("ROOM RATE.", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            'pdfCell.Rotation = 270
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("TAXES", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            'pdfCell.Rotation = 270
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BFAST", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("LUNCH", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DINNER", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BAR", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("LAUNDRY", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("MISC.", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("REVENUE", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BROUGHT FORWARD", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("GROSSE REVENUE", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("CASH", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BANK CARD", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("MOBILE MONEY", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("TO CARRY FORWARD", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

        Else

            pdfCell = New PdfPCell(New Paragraph("CH", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("NOM & PRENOM", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("ARRIVEE", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DEPART", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("NUITS", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("PAX", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("HEBERG.", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            'pdfCell.Rotation = 270
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("TAXE", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            'pdfCell.Rotation = 270
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("PDEJ", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DEJ", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DINER", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BAR", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BLANCHI.", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("AUTRES", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("RECETTE JOUR", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("REPORT VEILLE", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("TOTAL GENERAL", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("ESPECES", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("CARTE", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("MOBILE MONEY", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("A REPORTER", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

        End If


        Dim vertiPax As Integer = 0
        Dim vertiHebergement As Double = 0
        Dim vertiBar As Double = 0
        Dim vertiPDJ As Double = 0
        Dim vertiDEJ As Double = 0
        Dim vertiDinner As Double = 0
        Dim vertiBlanchisserie As Double = 0
        Dim vertiAutres As Double = 0
        Dim vertiRecetteJour As Double = 0
        Dim vertiReportVeille As Double = 0
        Dim vertiTotalGeneral As Double = 0
        Dim vertiEncaissementEspeces As Double = 0
        Dim vertiCarte As Double = 0
        Dim vertiMobile As Double = 0
        Dim vertiAReporter As Double = 0
        Dim vertiNmbreNuitee As Integer = 0
        Dim totalChanbre As Integer = 0
        Dim vertiTaxe As Integer = 0

        Dim nobreResa As Integer = 0

        If dt.Rows.Count > 0 Then

            nobreResa = dt.Rows.Count

            Dim MONTANT_CHARGE As Double = 0

            For i = 0 To dt.Rows.Count - 1

                For j = 0 To dt.Columns.Count - 1

                    'ON NE DOIT TRAITER LA DERNIERE COLONNE CAR ELLE CONTIENT LE NUMERO DE RESERVATION
                    'UTILISE POUR AFFICHER LES INFORMATIONS DES CLIENTS SUR LA MAINCOURANTE

                    If j < dt.Columns.Count - 1 Then

                        If j = 15 Or j = 16 Or j = 20 Then
                            changerSigne = -1
                        Else
                            changerSigne = 1
                        End If

                        If j = 2 Or j = 3 Then
                            pdfCell = New PdfPCell(New Paragraph(CDate(dt.Rows(i)(j).ToString).ToShortDateString, pRow))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        ElseIf j > 4 Then

                            MONTANT_CHARGE = 0
                            Double.TryParse(dt.Rows(i)(j).ToString, MONTANT_CHARGE)

                            pdfCell = New PdfPCell(New Paragraph(Format(MONTANT_CHARGE * changerSigne, "#,##0"), pRow))
                            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT

                        Else
                            pdfCell = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRow))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        End If

                        'pdfCell.MinimumHeight = 15
                        'pdfCell.PaddingLeft = 5.0F
                        'pdfCell.HorizontalAlignment = Element.ALIGN_LEFT

                        pdfTable.AddCell(pdfCell)

                        If j = 3 + 1 Then
                            'vertiNmbreNuitee += dt.Rows(i)(j)
                        ElseIf j = 4 + 1 Then
                            vertiPax += dt.Rows(i)(j)
                        ElseIf j = 5 + 1 Then
                            vertiHebergement += dt.Rows(i)(j)
                        ElseIf j = 6 + 1 Then
                            vertiTaxe += dt.Rows(i)(j)
                        ElseIf j = 7 + 1 Then
                            vertiPDJ += dt.Rows(i)(j)
                        ElseIf j = 8 + 1 Then
                            vertiDEJ += dt.Rows(i)(j)
                        ElseIf j = 9 + 1 Then
                            vertiDinner += dt.Rows(i)(j)
                        ElseIf j = 10 + 1 Then
                            vertiBar += dt.Rows(i)(j)
                        ElseIf j = 11 + 1 Then
                            vertiBlanchisserie += dt.Rows(i)(j)
                        ElseIf j = 12 + 1 Then
                            vertiAutres += dt.Rows(i)(j)
                        ElseIf j = 13 + 1 Then
                            vertiRecetteJour += dt.Rows(i)(j)
                        ElseIf j = 14 + 1 Then
                            vertiReportVeille += dt.Rows(i)(j)
                        ElseIf j = 15 + 1 Then
                            vertiTotalGeneral += dt.Rows(i)(j)
                        ElseIf j = 16 + 1 Then
                            vertiEncaissementEspeces += dt.Rows(i)(j)
                        ElseIf j = 17 + 1 Then
                            vertiCarte += dt.Rows(i)(j)
                        ElseIf j = 18 + 1 Then
                            vertiMobile += dt.Rows(i)(j)
                        ElseIf j = 19 + 1 Then
                            vertiAReporter += dt.Rows(i)(j)
                        End If

                    End If

                Next

            Next

            pdfCell = New PdfPCell(New Paragraph("", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.Border = 0
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.Border = 0
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            pdfCell.Border = 0
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.Border = 0
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            'pdfCell = New PdfPCell(New Paragraph(vertiNmbreNuitee, pColumn))
            pdfCell = New PdfPCell(New Paragraph("", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.Border = 0
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(vertiPax, pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiHebergement, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            'pdfCell.Rotation = 270
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiTaxe, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            'pdfCell.Rotation = 270
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiPDJ, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiDEJ, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiDinner, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiBar, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiBlanchisserie, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiAutres, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiRecetteJour, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.Rotation = 270
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiReportVeille, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiTotalGeneral, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiEncaissementEspeces, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiCarte, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY

            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiMobile, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY

            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(vertiAReporter, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            'pdfCell.Rotation = 270
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY

            pdfTable.AddCell(pdfCell)

            pdfDoc.Add(pdfTable)

            If True Then

                '--------------------------------- en chambre -----------------------------------------------
                Dim enChambre As Double = 0

                Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & dateMainCouranteDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & dateMainCouranteDebut.ToString("yyyy-MM-dd") & "' AND DAY_USE = @DAY_USE AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)
                command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command.Parameters.Add("@DAY_USE", MySqlDbType.Int64).Value = 0

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                If table.Rows.Count > 0 Then
                    enChambre = table.Rows.Count
                End If
                '--------------------------------------------------------------------------------------------

                '--------------------------------- depart ---------------------------------------------------
                Dim depart As Double = 0

                Dim query1 As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_SORTIE >= '" & dateMainCouranteDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & dateMainCouranteDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND DAY_USE = @DAY_USE ORDER BY CHAMBRE_ID ASC"

                Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
                command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
                command1.Parameters.Add("@DAY_USE", MySqlDbType.Int64).Value = 0

                Dim adapter1 As New MySqlDataAdapter(command1)
                Dim table1 As New DataTable()
                adapter1.Fill(table1)

                If (table1.Rows.Count > 0) Then
                    depart = table1.Rows.Count
                End If
                '--------------------------------------------------------------------------------------------

                Dim rooms As New Room()

                Dim HSRooms As Integer = rooms.HSRoomsOnly().Rows.Count
                Dim roomsOnly As Integer = rooms.roomsOnly().Rows.Count

                Dim occupe As Integer = enChambre - depart

                Dim vendable As Integer = roomsOnly - HSRooms
                Dim disponible As Integer = vendable - occupe

                If GlobalVariable.actualLanguageValue = 1 Then

                    Dim p1 As Paragraph = New Paragraph(Chr(13) & "STATISTIQUES" & Chr(13) & Chr(13))
                    p1.Alignment = Element.ALIGN_CENTER
                    'pdfDoc.Add(p1)

                Else

                    Dim p1 As Paragraph = New Paragraph(Chr(13) & "STATISTICS" & Chr(13) & Chr(13))
                    p1.Alignment = Element.ALIGN_CENTER
                    'pdfDoc.Add(p1)

                End If

                Dim pdfTable1 As New PdfPTable(6) 'Number of columns
                pdfTable1.TotalWidth = 1120.0F
                pdfTable1.LockedWidth = True
                pdfTable1.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfTable1.HeaderRows = 1

                Dim widths1 As Single() = New Single() {10.0F, 10.0F, 10.0F, 10.0F, 10.0F, 10.0F}
                pdfTable1.SetWidths(widths1)

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("TAUX D'OCCUPATION SANS CHAMBRES HORS SERVICES : " & Format(occupe * 100 / vendable, "#,##0.00") & " %", pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("HOTEL OCCUPATION RATE EXCLUDING OUT OF ORDER ROOMS : " & Format(occupe * 100 / vendable, "#,##0.00") & " %", pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("TAUX D'OCCUPATION AVEC CHAMBRES HORS SERVICES : " & Format(occupe * 100 / roomsOnly, "#,##0.00") & " %", pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("HOTEL OCCUPATION RATE INCLUDING OUT OF ORDER ROOMS : " & Format(occupe * 100 / roomsOnly, "#,##0.00") & " %", pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("PRIX MOYENS : " & Format(vertiHebergement / occupe, "#,##0.0") & " " & societe.Rows(0)("CODE_MONNAIE"), pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("AVERAGE DAILY RATE : " & Format(vertiHebergement / occupe, "#,##0.0") & " " & societe.Rows(0)("CODE_MONNAIE"), pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("", pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("", pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("", pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)
                '-----------------------------------------

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("CHAMBRES DISPONIBLES", pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("AVAILABLE ROOMS", pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("CHAMBRES VENDUES", pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("ROOMS SOLD", pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("CHAMBRES HORS SERVICES", pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("NUMBER OF ROOMS OUT OF ORDER", pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(disponible & " / " & vendable, pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(occupe & " / " & vendable, pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(HSRooms & " / " & roomsOnly, pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("", pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 6
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("", pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 6
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("SIGNATURE RECEPTION", pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("RECEPTIONIST'S SIGNATURE", pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("SIGNATURE CONTROLEUR", pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("CONTROLLER'S SIGNATURE", pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)

                If GlobalVariable.actualLanguageValue = 1 Then
                    pdfCell = New PdfPCell(New Paragraph("SIGNATURE DIRECTEUR", pColumn))

                Else
                    pdfCell = New PdfPCell(New Paragraph("MANAGER'S SIGNATURE", pColumn))

                End If

                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("----------------", pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("----------------", pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0
                pdfCell.Colspan = 2
                pdfTable1.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("----------------", pColumn))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 15
                pdfCell.PaddingLeft = 5.0F
                pdfCell.Colspan = 2
                pdfCell.Border = 0
                pdfTable1.AddCell(pdfCell)

                'pdfDoc.Add(pdfTable1)

            End If

            pdfDoc.Close()

            Dim bodyText As String = ""

            If GlobalVariable.actualLanguageValue = 1 Then
                bodyText = "Recevez nos salutations," & Chr(13) & " Merci de bien vouloir trouver ci joint la " & tireDocument.ToLower() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"

            Else
                bodyText = "Receive our greetings," & Chr(13) & " Attachement " & tireDocument.ToLower() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do no respond to this mail !!"

            End If

            'envoieDocumentMail(fichier, tireDocument, bodyText)

            Dim nmessageOuDocument As Integer = 1
            Dim typeDeDocument As Integer = 0

            'If GlobalVariable.actualLanguageValue = 1 Then
            'bodyText = "Recevez nos salutations," & Chr(13) & " Merci de bien vouloir trouver ci joint la " & tireDocument.ToLower() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce message !!"
            'Else
            'bodyText = "Receive our greetings," & Chr(13) & " Attachement " & tireDocument.ToLower() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do no respond to this message !!"
            'End If

            Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument)

        Else
            MessageBox.Show("Aucune Ligne de Fatcure à imprimer!")
        End If

    End Sub

    Public Shared Async Sub impressionEconomat(ByVal dt As DataGridView, ByVal title As String, ByVal totalAchat As Double, ByVal totalVente As Double,
                                         ByVal numeroBon As String, ByVal ETAT_BORDEREAUX As Integer, Optional ByVal nomTiers As String = "", Optional ByVal libelle As String = "",
                                         Optional ByVal reference As String = "", Optional ByVal observations As String = "", Optional ByVal typeBordereau As String = "", Optional from As String = "")

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        If True Then

            If typeBordereau.Equals(GlobalVariable.list_du_marche) Then

                Dim TYPE_BORDEREAUX_1 As String = GlobalVariable.list_du_marche

                Dim FillingListquery As String = ""
                Dim FillingListquery01 As String = ""
                Dim FillingListquery02 As String = ""

                Dim societe As DataTable = Functions.allTableFields("societe")

                Dim TotalCommande As Double = 0

                Dim tireDocument As String = title.ToUpper() & " DU " & (Date.Now().ToString("ddMMyyHHmmss"))

                Dim sousTitreDocument As String = ""

                sousTitreDocument = tireDocument

                Dim titreFichier As String = ""

                titreFichier = title & " (" & libelle & " - " & numeroBon & ")"
                '& "(" & libelle & "/" & numeroBon & ")"
                tireDocument = titreFichier & " DU " & GlobalVariable.DateDeTravail.ToShortDateString

                Dim nomDuDossierRapport As String = "RAPPORTS\ECONOMAT"

                Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

                My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

                Dim fichier As String = filePathAndDirectory & "\" & titreFichier & " DU " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"

                Dim CODE_BORDEREAUX As String = ""

                Dim GrandTotalAchat As Double = 0

                Dim totaux As Double = 0

                Dim pdfDoc As New Document(PageSize.A4, 40, 20, 80, 60)
                Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
                Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim pRowFirst As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fontTotal1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim font1 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

                pdfWrite.PageEvent = New HeaderFooter

                pdfDoc.Open()

                Dim p0003 As Paragraph = New Paragraph(GlobalVariable.societe.Rows(0)("RAISON_SOCIALE") & Chr(13) & Chr(13), pRowFirst)
                p0003.Alignment = Element.ALIGN_CENTER

                'pdfDoc.Add(p0003)

                Dim infoSupBon As DataTable = Functions.getElementByCode(numeroBon, "bordereaux", "CODE_BORDEREAUX")

                Dim dateDebut As Date
                Dim dateDu As Date
                Dim dateAu As Date
                Dim passant As Integer = 0

                '1- INSERTION DES EN TETE DES 

                If infoSupBon.Rows.Count > 0 Then

                    CODE_BORDEREAUX = numeroBon

                    dateDebut = infoSupBon.Rows(0)("DATE_BORDEREAU")

                    dateDu = infoSupBon.Rows(0)("DATE_DU")
                    dateAu = infoSupBon.Rows(0)("DATE_AU")
                    passant = infoSupBon.Rows(0)("PASSANT")

                    Dim p0 As Paragraph = New Paragraph(Chr(13) & Chr(13) & title & " NUMERO :  " & infoSupBon.Rows(0)("CODE_BORDEREAUX") & Chr(13) & "LIBELLE: " & infoSupBon.Rows(0)("LIBELLE_BORDEREAUX") & Chr(13) & "REFERENCE: " & infoSupBon.Rows(0)("REF_BORDEREAUX") & Chr(13) & "DEMANDEUR: " & infoSupBon.Rows(0)("NON_TIERS") & Chr(13) & Chr(13), pRow)
                    p0.Alignment = Element.ALIGN_LEFT
                    pdfDoc.Add(p0)

                    Dim p3 As Paragraph = New Paragraph(title.ToUpper() & " DU " & " " & dateDebut & Chr(13) & "POUR LA PERIODE DU " & CDate(infoSupBon.Rows(0)("DATE_DU")).ToShortDateString & " AU " & CDate(infoSupBon.Rows(0)("DATE_AU")).ToShortDateString, pRow)
                    p3.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p3)

                End If

                '----------------------------------------------------------------------------------------------------------------------------------
                Dim p001 As Paragraph = New Paragraph(Chr(13) & "NOMBRE DE CLIENT LOGES", pRow)
                p001.Alignment = Element.ALIGN_LEFT
                pdfDoc.Add(p001)

                Dim pdfTable001 As New PdfPTable(8) 'Number of columns
                pdfTable001.TotalWidth = 555.0F
                pdfTable001.LockedWidth = True
                pdfTable001.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfTable001.HeaderRows = 1

                Dim widths001 As Single() = New Single() {25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F}

                pdfTable001.SetWidths(widths001)

                Dim pdfCell001 As PdfPCell = Nothing

                pdfCell001 = New PdfPCell(New Paragraph("", fontTotal1))
                pdfCell001.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell001.MinimumHeight = 5
                pdfCell001.Colspan = 8
                pdfCell001.Border = 0
                pdfTable001.AddCell(pdfCell001)

                For i = 0 To 7

                    pdfCell001 = New PdfPCell(New Paragraph(dateDu.AddDays(i), fontTotal1))
                    pdfCell001.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell001.MinimumHeight = 5
                    pdfCell001.Border = 0
                    pdfTable001.AddCell(pdfCell001)

                Next

                Dim nombreDeClient As Integer = 0
                Dim nombreClientLoges As Integer = 0

                For i = 0 To 7

                    nombreDeClient = Functions.nombreDeClientEnChambre(dateDu.AddDays(i), "chambre")
                    nombreClientLoges += Functions.nombreDeClientEnChambre(dateDu.AddDays(i), "chambre")

                    pdfCell001 = New PdfPCell(New Paragraph(nombreDeClient, fontTotal1))
                    pdfCell001.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell001.MinimumHeight = 5
                    pdfCell001.Border = 0
                    pdfTable001.AddCell(pdfCell001)

                Next

                pdfDoc.Add(pdfTable001)

                '----------------------------------------------------------------------------------------------------------------------------------

                Dim p02 As Paragraph = New Paragraph(Chr(13) & "PREVISION (NOMBRE DE PERSONNE)" & Chr(13) & Chr(13), pRow)
                p02.Alignment = Element.ALIGN_LEFT
                pdfDoc.Add(p02)

                Dim pdfTable002 As New PdfPTable(4) 'Number of columns
                pdfTable002.TotalWidth = 555.0F
                pdfTable002.LockedWidth = True
                pdfTable002.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfTable002.HeaderRows = 1
                pdfTable002.PaddingTop = 50

                Dim widths002 As Single() = New Single() {25.0F, 25.0F, 25.0F, 25.0F}

                pdfTable002.SetWidths(widths002)

                Dim pdfCell002 As PdfPCell = Nothing

                pdfCell002 = New PdfPCell(New Paragraph("CLIENT LOGES", fontTotal1))
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                pdfCell002 = New PdfPCell(New Paragraph("PASSANT", fontTotal1))
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                pdfCell002 = New PdfPCell(New Paragraph("TRAITEURS", fontTotal1))
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                pdfCell002 = New PdfPCell(New Paragraph("EVENEMENTIEL", fontTotal1))
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                Dim nombre As Integer = 0

                Dim nombreDeTable As Integer = 2

                pdfCell002 = New PdfPCell(New Paragraph(nombreClientLoges, fontTotal1))
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                For i = 0 To nombreDeTable

                    Dim table As DataTable = Functions.nombreDeTraiteur(dateDu.AddDays(0).ToShortDateString(), dateDu.AddDays(6).ToShortDateString(), "salle")
                    nombre = 0

                    If Not table Is Nothing Then

                        If i = 0 Then

                        ElseIf i = 1 Then
                            For j = 0 To table.Rows.Count - 1
                                nombre += table.Rows(j)("NB_PERSONNES")
                            Next
                        Else
                            nombre = table.Rows.Count
                        End If

                    End If

                    If i = 0 Then
                        nombre += passant
                    End If

                    pdfCell002 = New PdfPCell(New Paragraph(nombre, fontTotal1))
                    pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell002.MinimumHeight = 5
                    pdfCell002.Border = 0
                    pdfTable002.AddCell(pdfCell002)

                Next

                pdfDoc.Add(pdfTable002)

                If True Then

                    If True Then

                        totalAchat = 0

                        FillingListquery = "SELECT DISTINCT ligne_bordereaux.CODE_ARTICLE FROM `bordereaux`, ligne_bordereaux, article WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX=@CODE_BORDEREAUX ORDER BY ID_LIGNE_BORDEREAU DESC"

                        'article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE
                        ',  DESIGNATION_FR AS DESIGNATION

                        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
                        commandList.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                        commandList.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                        Dim adapterList As New MySqlDataAdapter(commandList)
                        Dim articleList As New DataTable()

                        adapterList.Fill(articleList)

                        If articleList.Rows.Count > 0 Then

                            Dim p003_ As Paragraph = New Paragraph(Chr(13) & Chr(13) & Chr(13), pRow)
                            p003_.Alignment = Element.ALIGN_LEFT
                            pdfDoc.Add(p003_)


                            Dim p003 As Paragraph = New Paragraph(Chr(13) & Chr(13), pRow)
                            p003.Alignment = Element.ALIGN_LEFT
                            pdfDoc.Add(p003)

                            Dim pdfTable As New PdfPTable(6) 'Number of columns
                            pdfTable.TotalWidth = 555.0F
                            pdfTable.LockedWidth = True
                            pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                            pdfTable.HeaderRows = 1

                            Dim widths As Single() = New Single() {10.0F, 65.0F, 25.0F, 20.0F, 25.0F, 25.0F}

                            pdfTable.SetWidths(widths)

                            Dim pdfCell As PdfPCell = Nothing

                            pdfCell = New PdfPCell(New Paragraph("No", fontTotal1))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph("DESIGNATION", fontTotal1))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph("UNITE", fontTotal1))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5
                            'pdfCell.PaddingLeft = 5.0F
                            'pdfCell.Border = 0

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph("QTE", fontTotal1))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5
                            'pdfCell.PaddingLeft = 5.0F
                            'pdfCell.Border = 0

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph("PU", fontTotal1))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5
                            'pdfCell.PaddingLeft = 5.0F
                            'pdfCell.Border = 0

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph("TOTAL", fontTotal1))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5
                            'pdfCell.PaddingLeft = 5.0F
                            'pdfCell.Border = 0

                            pdfTable.AddCell(pdfCell)

                            For l = 0 To articleList.Rows.Count - 1

                                '----------------------------------------------

                                Dim FillingListquery03 As String = ""

                                FillingListquery03 = "SELECT `DATE_BORDEREAU` AS 'DATE',  DESIGNATION_FR AS 'DESIGNATION', NUM_SERIE_DEBUT AS 'UNITE', ligne_bordereaux.QUANTITE As 'QTE AVANT MOVT', QUANTITE_ENTREE_STOCK AS 'QTE EN MOVT', PRIX_UNITAIRE_HT AS 'PRIX UNITAIRE', PRIX_TOTAL_HT AS 'TOTAL' FROM `bordereaux`, ligne_bordereaux, article WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND ligne_bordereaux.CODE_ARTICLE =@CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX = @CODE_BORDEREAUX ORDER BY ID_LIGNE_BORDEREAU DESC"

                                Dim commandList03 As New MySqlCommand(FillingListquery03, GlobalVariable.connect)
                                commandList03.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                                commandList03.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = articleList.Rows(l)("CODE_ARTICLE")
                                commandList03.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                                Dim adapterList03 As New MySqlDataAdapter(commandList03)
                                Dim dt_ As New DataTable()

                                adapterList03.Fill(dt_)

                                If dt_.Rows.Count > 0 Then

                                    Dim qteTotal As Double = 0
                                    Dim montantTotal As Double = 0

                                    For m = 0 To dt_.Rows.Count - 1
                                        qteTotal += dt_.Rows(m)("QTE EN MOVT")
                                        montantTotal += dt_.Rows(m)("TOTAL")
                                        totalAchat += dt_.Rows(m)("TOTAL")
                                        GrandTotalAchat += dt_.Rows(m)("TOTAL")
                                        totaux += dt_.Rows(m)("TOTAL")
                                    Next

                                    pdfCell = New PdfPCell(New Paragraph(l + 1, font1))
                                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                    pdfCell.MinimumHeight = 5

                                    pdfTable.AddCell(pdfCell)

                                    pdfCell = New PdfPCell(New Paragraph(dt_.Rows(0)("DESIGNATION"), font1))
                                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                    pdfCell.MinimumHeight = 5

                                    pdfTable.AddCell(pdfCell)

                                    pdfCell = New PdfPCell(New Paragraph(dt_.Rows(0)("UNITE"), font1))
                                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                    pdfCell.MinimumHeight = 5

                                    pdfTable.AddCell(pdfCell)

                                    pdfCell = New PdfPCell(New Paragraph(Format(qteTotal, "#,##0.0"), font1))
                                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                                    pdfCell.MinimumHeight = 5

                                    pdfTable.AddCell(pdfCell)

                                    If qteTotal > 0 Then
                                        pdfCell = New PdfPCell(New Paragraph(Format(montantTotal / qteTotal, "#,##0"), font1))
                                    Else
                                        pdfCell = New PdfPCell(New Paragraph(Format(dt_.Rows(0)("PRIX UNITAIRE"), "#,##0"), font1))
                                    End If

                                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                                    pdfCell.MinimumHeight = 5

                                    pdfTable.AddCell(pdfCell)

                                    pdfCell = New PdfPCell(New Paragraph(Format(montantTotal, "#,##0"), font1))
                                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                                    pdfCell.MinimumHeight = 5

                                    pdfTable.AddCell(pdfCell)

                                End If
                                '----------------------------------------------

                            Next

                            pdfCell = New PdfPCell(New Paragraph("TOTAL : ", fontTotal))
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5
                            'pdfCell.PaddingLeft = 5.0F
                            pdfCell.Border = 0
                            pdfCell.Colspan = 4

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph(Format(GrandTotalAchat, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), fontTotal))
                            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                            pdfCell.MinimumHeight = 5
                            pdfCell.Colspan = 2
                            pdfCell.Border = 0

                            pdfTable.AddCell(pdfCell)

                            pdfDoc.Add(pdfTable)

                        End If

                    End If
                    Dim p0030 As Paragraph = New Paragraph(Chr(13) & "TOTAUX : " & Format(totaux, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), pRow)
                    p0030.Alignment = Element.ALIGN_CENTER
                    pdfDoc.Add(p0030)


                End If

                '------------------------------------------------------- HISTORIQUES DES LISTES PASSES --------------------------------------------------------

                Dim GrandTotalAchat_ As Double = 0
                Dim totalAchat_ As Double = 0

                Dim date_1 As Date
                Dim date_2 As Date


                date_1 = dateDebut.AddDays(-7).ToShortDateString
                date_2 = dateDebut.AddDays(-1).ToShortDateString


                Dim p030 As Paragraph = New Paragraph(Chr(13) & "HISTORIQUES DU MARCHE " & date_1 & " AU " & date_2, pRow)
                p030.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p030)

                If True Then

                    totalAchat_ = 0

                    Dim FillingListquery_ As String = "SELECT DISTINCT ligne_bordereaux.CODE_ARTICLE FROM `bordereaux`, ligne_bordereaux, article WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX=@CODE_BORDEREAUX ORDER BY ID_LIGNE_BORDEREAU DESC"

                    'article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE
                    ',  DESIGNATION_FR AS DESIGNATION

                    Dim commandList_ As New MySqlCommand(FillingListquery_, GlobalVariable.connect)
                    commandList_.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                    commandList_.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                    Dim adapterList_ As New MySqlDataAdapter(commandList_)
                    Dim articleList_ As New DataTable()

                    adapterList_.Fill(articleList_)

                    If articleList_.Rows.Count > 0 Then

                        Dim p003 As Paragraph = New Paragraph(Chr(13) & Chr(13), pRow)
                        p003.Alignment = Element.ALIGN_LEFT

                        pdfDoc.Add(p003)

                        Dim pdfTable As New PdfPTable(8) 'Number of columns
                        pdfTable.TotalWidth = 555.0F
                        pdfTable.LockedWidth = True
                        pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                        pdfTable.HeaderRows = 1

                        Dim widths As Single() = New Single() {65.0F, 20.0F, 20.0F, 20.0F, 20.0F, 20.0F, 20.0F, 20.0F}

                        pdfTable.SetWidths(widths)

                        Dim pdfCell As PdfPCell = Nothing

                        pdfCell = New PdfPCell(New Paragraph("DESIGNATION", fontTotal1))
                        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                        pdfCell.MinimumHeight = 5

                        pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(date_1.ToShortDateString, fontTotal1))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 5

                        pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(1).ToShortDateString, fontTotal1))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 5

                        pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(2).ToShortDateString, fontTotal1))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 5
                        'pdfCell.PaddingLeft = 5.0F
                        'pdfCell.Border = 0

                        pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(3).ToShortDateString, fontTotal1))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 5
                        'pdfCell.PaddingLeft = 5.0F
                        'pdfCell.Border = 0

                        pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(4).ToShortDateString, fontTotal1))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 5
                        'pdfCell.PaddingLeft = 5.0F
                        'pdfCell.Border = 0

                        pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(5).ToShortDateString, fontTotal1))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 5
                        'pdfCell.PaddingLeft = 5.0F
                        'pdfCell.Border = 0

                        pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(6).ToShortDateString, fontTotal1))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 5
                        'pdfCell.PaddingLeft = 5.0F
                        'pdfCell.Border = 0

                        pdfTable.AddCell(pdfCell)

                        For l = 0 To articleList_.Rows.Count - 1

                            '----------------------------------------------

                            Dim FillingListquery03_ As String = "SELECT `DATE_BORDEREAU` AS 'DATE',  DESIGNATION_FR AS 'DESIGNATION', NUM_SERIE_DEBUT AS 'UNITE', ligne_bordereaux.QUANTITE As 'QTE AVANT MOVT', QUANTITE_ENTREE_STOCK AS 'QTE EN MOVT', PRIX_UNITAIRE_HT AS 'PRIX UNITAIRE', PRIX_TOTAL_HT AS 'TOTAL' FROM `bordereaux`, ligne_bordereaux, article WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND ligne_bordereaux.CODE_ARTICLE =@CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX = @CODE_BORDEREAUX ORDER BY ID_LIGNE_BORDEREAU DESC"

                            Dim commandList03_ As New MySqlCommand(FillingListquery03_, GlobalVariable.connect)
                            commandList03_.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                            commandList03_.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = articleList_.Rows(l)("CODE_ARTICLE")
                            commandList03_.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                            Dim adapterList03_ As New MySqlDataAdapter(commandList03_)
                            Dim dt_ As New DataTable()

                            adapterList03_.Fill(dt_)

                            If dt_.Rows.Count > 0 Then

                                Dim qteTotal_ As Double = 0
                                Dim montantTotal_ As Double = 0

                                For m = 0 To dt_.Rows.Count - 1
                                    qteTotal_ += dt_.Rows(m)("QTE EN MOVT")
                                    montantTotal_ += dt_.Rows(m)("TOTAL")
                                    totalAchat_ += dt_.Rows(m)("TOTAL")
                                    GrandTotalAchat_ += dt_.Rows(m)("TOTAL")
                                Next

                                pdfCell = New PdfPCell(New Paragraph(dt_.Rows(0)("DESIGNATION"), font1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                Dim CODE_ARTICLE As String = articleList_.Rows(l)("CODE_ARTICLE")

                                Dim montant As Double = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.ToShortDateString)

                                If montant = 0 Then
                                    pdfCell = New PdfPCell(New Paragraph("", font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                End If

                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(1).ToShortDateString)

                                If montant = 0 Then
                                    pdfCell = New PdfPCell(New Paragraph("", font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                End If

                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(2).ToShortDateString)

                                If montant = 0 Then
                                    pdfCell = New PdfPCell(New Paragraph("", font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                End If

                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(3).ToShortDateString)

                                If montant = 0 Then
                                    pdfCell = New PdfPCell(New Paragraph("", font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                End If

                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(4).ToShortDateString)

                                If montant = 0 Then
                                    pdfCell = New PdfPCell(New Paragraph("", font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                End If
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(5).ToShortDateString)

                                If montant = 0 Then
                                    pdfCell = New PdfPCell(New Paragraph("", font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                End If
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(6).ToShortDateString)

                                If montant = 0 Then
                                    pdfCell = New PdfPCell(New Paragraph("", font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                End If
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                            End If
                            '----------------------------------------------

                        Next

                        pdfCell = New PdfPCell(New Paragraph("TOTAL : ", fontTotal))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 7
                        'pdfCell.PaddingLeft = 5.0F
                        pdfCell.Border = 0
                        pdfCell.Colspan = 4

                        'pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(Format(totalAchat_, "#,##0"), fontTotal))
                        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                        pdfCell.MinimumHeight = 5
                        'pdfCell.PaddingLeft = 5.0F
                        pdfCell.Border = 0

                        'pdfTable.AddCell(pdfCell)

                        pdfDoc.Add(pdfTable)

                    End If

                End If

                '----------------------------------------------------------------------------------------------------------------------------------------------

                pdfDoc.Close()

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim bodyText As String = ""

                '------------------------------------SENDING OF NOTIFICATION -------------------------------------------------------------------------------------------------------------------------------------------
                Dim sendMessage As New User()

                Dim CODE_PROFIL As String = "ECONOME"
                Dim MESSAGE As String = ""
                Dim OBJET As String = ""
                Dim EXPEDITEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
                Dim DATE_ENVOI As Date = GlobalVariable.DateDeTravail

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                If ETAT_BORDEREAUX = 0 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à CONTRÔLER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à CONTRÔLER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 1 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à VERIFIER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VERIFIER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 2 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à VALIDER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VALIDER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 3 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à COMMANDER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à COMMANDER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 4 Then
                    bodyText = "Parcours du ," & tireDocument.ToUpper() & Chr(13) & " effectué avec succès. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Parcours du ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " effectué avec succès"
                    OBJET = tireDocument.ToUpper()
                End If

                sendMessage.sendMessage(CODE_PROFIL, MESSAGE.ToUpper(), OBJET, DATE_ENVOI, EXPEDITEUR)

                'envoieDocumentMailEconomat(fichier, tireDocument, bodyText, ETAT_BORDEREAUX)

                Dim nmessageOuDocument As Integer = 1
                Dim typeDeDocument As Integer = 0
                Dim phoneNumber As String = ""

                Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument, phoneNumber, ETAT_BORDEREAUX)

            Else

                Dim societe As DataTable = Functions.allTableFields("societe")

                Dim TotalCommande As Double = 0

                Dim tireDocument As String = title.ToUpper() & " DU " & (Date.Now().ToString("ddMMyyHHmmss"))

                Dim sousTitreDocument As String = ""

                sousTitreDocument = tireDocument

                '---------------------------------------------------------------------------------------------------------------
                Dim titreFichier As String = ""

                titreFichier = title & " (" & libelle & " - " & numeroBon & ")"
                '& "(" & libelle & "/" & numeroBon & ")"
                tireDocument = titreFichier & " DU " & GlobalVariable.DateDeTravail.ToShortDateString

                Dim nomDuDossierRapport As String = "RAPPORTS\ECONOMAT"

                Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

                My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

                Dim fichier As String = filePathAndDirectory & "\" & titreFichier & " DU " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"

                '---------------------------------------------------------------------------------------------------------------
                Dim pdfDoc As New Document(PageSize.A4, 40, 20, 80, 40)
                'Dim pdfDoc As New Document(PageSize.A4, 40, 5, 5, 5)
                Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
                Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim font1 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

                pdfWrite.PageEvent = New HeaderFooter

                pdfDoc.Open()

                Dim p3 As Paragraph = New Paragraph(Chr(13) & title.ToUpper() & " DU " & " " & GlobalVariable.DateDeTravail & Chr(13) & Chr(13), pRow)
                p3.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p3)

                Dim infoSupBon As DataTable = Functions.getElementByCode(numeroBon, "bordereaux", "CODE_BORDEREAUX")

                If infoSupBon.Rows.Count > 0 Then

                    Dim p0 As Paragraph = New Paragraph(Chr(13) & title & " NUMERO :  " & infoSupBon.Rows(0)("CODE_BORDEREAUX") & Chr(13) & "LIBELLE: " & infoSupBon.Rows(0)("LIBELLE_BORDEREAUX") & Chr(13) & "REFERENCE: " & infoSupBon.Rows(0)("REF_BORDEREAUX") & Chr(13) & "TIERS: " & infoSupBon.Rows(0)("NON_TIERS") & Chr(13) & Chr(13), pRow)
                    p0.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p0)

                Else

                    Dim p0 As Paragraph = New Paragraph(Chr(13) & title & " NUMERO :  " & numeroBon & Chr(13) & "LIBELLE: " & libelle & Chr(13) & "REFERENCE: " & reference & Chr(13) & "TIERS: " & nomTiers & Chr(13) & Chr(13), pRow)
                    p0.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p0)

                End If

                'Dim pdfTable As New PdfPTable(8) 'Number of columns
                Dim pdfTable As New PdfPTable(5) 'Number of columns
                pdfTable.TotalWidth = 555.0F
                pdfTable.LockedWidth = True
                pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfTable.HeaderRows = 1

                'Dim widths As Single() = New Single() {25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F}
                Dim widths As Single() = New Single() {15.0F, 60.0F, 15.0F, 15.0F, 15.0F}

                pdfTable.SetWidths(widths)

                Dim pdfCell As PdfPCell = Nothing

                pdfCell = New PdfPCell(New Paragraph("REF.", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("LIBELLE", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("QTE", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("PU", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("TOTAL", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                For j = 0 To dt.Rows.Count - 1

                    For k = 0 To dt.Columns.Count - 1

                        If k = 6 Or k = 1 Or k = 2 Or k = 3 Or k = 5 Then

                            If Not Trim(dt.Rows(j).Cells(k).Value.ToString).Equals("") Then

                                If k = 5 Or k = 6 Then
                                    pdfCell = New PdfPCell(New Paragraph(Format(dt.Rows(j).Cells(k).Value, "#,##0"), font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(dt.Rows(j).Cells(k).Value, font1))
                                End If

                            End If

                            If k = 1 Then
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            ElseIf k = 2 Then
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                            ElseIf k = 3 Then
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            ElseIf k = 5 Or k = 6 Then
                                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                            End If

                            pdfCell.MinimumHeight = 5

                            pdfTable.AddCell(pdfCell)

                        End If

                    Next

                Next

                pdfCell = New PdfPCell(New Paragraph("TOTAL", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0
                pdfCell.Colspan = 4

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(Format(totalAchat, "#,##0"), fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfDoc.Add(pdfTable)

                Dim p03 As Paragraph = New Paragraph(Chr(13) & "OBSERVATIONS : " & observations & Chr(13), font1)
                p03.Alignment = Element.ALIGN_LEFT

                pdfDoc.Add(p03)

                '------------------------------------------------------------------------

                pdfDoc.Close()

                'Process.Start(sfd.FileName)

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim bodyText As String = ""

                '------------------------------------SENDING OF NOTIFICATION -------------------------------------------------------------------------------------------------------------------------------------------
                Dim sendMessage As New User()

                Dim CODE_PROFIL As String = "ECONOME"
                Dim MESSAGE As String = ""
                Dim OBJET As String = ""
                Dim EXPEDITEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
                Dim DATE_ENVOI As Date = GlobalVariable.DateDeTravail

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                If ETAT_BORDEREAUX = 0 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à CONTRÔLER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à CONTRÔLER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 1 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à VERIFIER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VERIFIER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 2 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à VALIDER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VALIDER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 3 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à COMMANDER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à COMMANDER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 4 Then
                    bodyText = "Parcours du ," & tireDocument.ToUpper() & Chr(13) & " effectué avec succès. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Parcours du ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " effectué avec succès"
                    OBJET = tireDocument.ToUpper()
                End If

                sendMessage.sendMessage(CODE_PROFIL, MESSAGE.ToUpper(), OBJET, DATE_ENVOI, EXPEDITEUR)

                'envoieDocumentMailEconomat(fichier, tireDocument, bodyText, ETAT_BORDEREAUX)

                Dim nmessageOuDocument As Integer = 1
                Dim typeDeDocument As Integer = 0
                Dim phoneNumber As String = ""

                Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument, phoneNumber, ETAT_BORDEREAUX)


            End If

        Else

        End If


    End Sub

    Public Shared Async Sub impressionEconomatOld(ByVal dt As DataGridView, ByVal title As String, ByVal totalAchat As Double, ByVal totalVente As Double,
                                         ByVal numeroBon As String, ByVal ETAT_BORDEREAUX As Integer, Optional ByVal nomTiers As String = "", Optional ByVal libelle As String = "",
                                         Optional ByVal reference As String = "", Optional ByVal observations As String = "", Optional ByVal typeBordereau As String = "", Optional from As String = "")

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        If True Then

            If typeBordereau.Equals(GlobalVariable.list_du_marche) Then

                Dim TYPE_BORDEREAUX_1 As String = GlobalVariable.list_du_marche

                Dim FillingListquery As String = ""
                Dim FillingListquery01 As String = ""
                Dim FillingListquery02 As String = ""

                Dim societe As DataTable = Functions.allTableFields("societe")

                Dim TotalCommande As Double = 0

                Dim tireDocument As String = title.ToUpper() & " DU " & (Date.Now().ToString("ddMMyyHHmmss"))

                Dim sousTitreDocument As String = ""

                sousTitreDocument = tireDocument

                Dim titreFichier As String = ""

                titreFichier = title & " (" & libelle & " - " & numeroBon & ")"
                '& "(" & libelle & "/" & numeroBon & ")"
                tireDocument = titreFichier & " DU " & GlobalVariable.DateDeTravail.ToShortDateString

                Dim nomDuDossierRapport As String = "RAPPORTS\ECONOMAT"

                Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

                My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

                Dim fichier As String = filePathAndDirectory & "\" & titreFichier & " DU " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"

                Dim CODE_BORDEREAUX As String = ""

                Dim GrandTotalAchat As Double = 0

                Dim totaux As Double = 0

                Dim pdfDoc As New Document(PageSize.A4, 40, 20, 80, 40)
                Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
                Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim pRowFirst As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fontTotal1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim font1 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

                pdfWrite.PageEvent = New HeaderFooter

                pdfDoc.Open()

                Dim p0003 As Paragraph = New Paragraph(GlobalVariable.societe.Rows(0)("RAISON_SOCIALE") & Chr(13) & Chr(13), pRowFirst)
                p0003.Alignment = Element.ALIGN_CENTER

                'pdfDoc.Add(p0003)

                Dim infoSupBon As DataTable = Functions.getElementByCode(numeroBon, "bordereaux", "CODE_BORDEREAUX")

                Dim dateDebut As Date
                Dim dateDu As Date
                Dim dateAu As Date
                Dim passant As Integer = 0

                '1- INSERTION DES EN TETE DES 

                If infoSupBon.Rows.Count > 0 Then

                    CODE_BORDEREAUX = numeroBon

                    dateDebut = infoSupBon.Rows(0)("DATE_BORDEREAU")

                    dateDu = infoSupBon.Rows(0)("DATE_DU")
                    dateAu = infoSupBon.Rows(0)("DATE_AU")
                    passant = infoSupBon.Rows(0)("PASSANT")

                    Dim p0 As Paragraph = New Paragraph(Chr(13) & title & " NUMERO :  " & infoSupBon.Rows(0)("CODE_BORDEREAUX") & Chr(13) & "LIBELLE: " & infoSupBon.Rows(0)("LIBELLE_BORDEREAUX") & Chr(13) & "REFERENCE: " & infoSupBon.Rows(0)("REF_BORDEREAUX") & Chr(13) & "DEMANDEUR: " & infoSupBon.Rows(0)("NON_TIERS") & Chr(13) & Chr(13), pRow)
                    p0.Alignment = Element.ALIGN_LEFT
                    pdfDoc.Add(p0)

                    Dim p3 As Paragraph = New Paragraph(title.ToUpper() & " DU " & " " & dateDebut & Chr(13) & "POUR LA PERIODE DU " & CDate(infoSupBon.Rows(0)("DATE_DU")).ToShortDateString & " AU " & CDate(infoSupBon.Rows(0)("DATE_AU")).ToShortDateString, pRow)
                    p3.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p3)

                End If

                '----------------------------------------------------------------------------------------------------------------------------------
                Dim p001 As Paragraph = New Paragraph(Chr(13) & "NOMBRE DE CLIENT LOGES", pRow)
                p001.Alignment = Element.ALIGN_LEFT
                pdfDoc.Add(p001)

                Dim pdfTable001 As New PdfPTable(8) 'Number of columns
                pdfTable001.TotalWidth = 555.0F
                pdfTable001.LockedWidth = True
                pdfTable001.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfTable001.HeaderRows = 1

                Dim widths001 As Single() = New Single() {25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F}

                pdfTable001.SetWidths(widths001)

                Dim pdfCell001 As PdfPCell = Nothing

                pdfCell001 = New PdfPCell(New Paragraph("", fontTotal1))
                pdfCell001.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell001.MinimumHeight = 5
                pdfCell001.Colspan = 8
                pdfCell001.Border = 0
                pdfTable001.AddCell(pdfCell001)

                For i = 0 To 7

                    pdfCell001 = New PdfPCell(New Paragraph(dateDu.AddDays(i), fontTotal1))
                    pdfCell001.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell001.MinimumHeight = 5
                    pdfCell001.Border = 0
                    pdfTable001.AddCell(pdfCell001)

                Next

                Dim nombreDeClient As Integer = 0

                For i = 0 To 7

                    nombreDeClient = Functions.nombreDeClientEnChambre(dateDu.AddDays(i), "chambre")

                    pdfCell001 = New PdfPCell(New Paragraph(nombreDeClient, fontTotal1))
                    pdfCell001.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell001.MinimumHeight = 5
                    pdfCell001.Border = 0
                    pdfTable001.AddCell(pdfCell001)

                Next

                pdfDoc.Add(pdfTable001)

                '----------------------------------------------------------------------------------------------------------------------------------

                Dim p02 As Paragraph = New Paragraph(Chr(13) & "PREVISION (NOMBRE DE PERSONNE)" & Chr(13) & Chr(13), pRow)
                p02.Alignment = Element.ALIGN_LEFT
                pdfDoc.Add(p02)

                Dim pdfTable002 As New PdfPTable(3) 'Number of columns
                pdfTable002.TotalWidth = 555.0F
                pdfTable002.LockedWidth = True
                pdfTable002.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfTable002.HeaderRows = 1
                pdfTable002.PaddingTop = 50

                Dim widths002 As Single() = New Single() {25.0F, 25.0F, 25.0F}

                pdfTable002.SetWidths(widths002)

                Dim pdfCell002 As PdfPCell = Nothing

                pdfCell002 = New PdfPCell(New Paragraph("PASSANT", fontTotal1))
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                pdfCell002 = New PdfPCell(New Paragraph("TRAITEURS", fontTotal1))
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                pdfCell002 = New PdfPCell(New Paragraph("EVENEMENTIEL", fontTotal1))
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                Dim nombre As Integer = 0

                Dim nombreDeTable As Integer = 2

                For i = 0 To nombreDeTable

                    Dim table As DataTable = Functions.nombreDeTraiteur(dateDu.AddDays(0).ToShortDateString(), dateDu.AddDays(6).ToShortDateString(), "salle")
                    nombre = 0

                    If Not table Is Nothing Then

                        If i = 0 Then

                        ElseIf i = 1 Then
                            For j = 0 To table.Rows.Count - 1
                                nombre += table.Rows(j)("NB_PERSONNES")
                            Next
                        Else
                            nombre = table.Rows.Count
                        End If

                    End If

                    If i = 0 Then
                        nombre += passant
                    End If

                    pdfCell002 = New PdfPCell(New Paragraph(nombre, fontTotal1))
                    pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell002.MinimumHeight = 5
                    pdfCell002.Border = 0
                    pdfTable002.AddCell(pdfCell002)

                Next

                pdfDoc.Add(pdfTable002)


                '2. FAMILLES D'ARTICLES / MATIERES

                FillingListquery02 = "SELECT DISTINCT CODE_SOUS_FAMILLE FROM article, bordereaux, ligne_bordereaux WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX = @CODE_BORDEREAUX ORDER BY DATE_BORDEREAU DESC"

                Dim commandList02 As New MySqlCommand(FillingListquery02, GlobalVariable.connect)
                commandList02.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                commandList02.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                Dim adapterList02 As New MySqlDataAdapter(commandList02)
                Dim tableListFamille As New DataTable()

                adapterList02.Fill(tableListFamille)

                If tableListFamille.Rows.Count > 0 Then

                    '3- LISTES DES ARTICLES  (PAR MAGASIN ET PAR FAMILLE)

                    For t = 0 To tableListFamille.Rows.Count - 1

                        GrandTotalAchat = 0

                        If True Then

                            totalAchat = 0

                            FillingListquery = "SELECT DISTINCT ligne_bordereaux.CODE_ARTICLE FROM `bordereaux`, ligne_bordereaux, article WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX=@CODE_BORDEREAUX AND article.CODE_SOUS_FAMILLE = @CODE_SOUS_FAMILLE ORDER BY ID_LIGNE_BORDEREAU DESC"

                            'article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE
                            ',  DESIGNATION_FR AS DESIGNATION

                            Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
                            commandList.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                            commandList.Parameters.Add("@CODE_SOUS_FAMILLE", MySqlDbType.VarChar).Value = tableListFamille.Rows(t)("CODE_SOUS_FAMILLE")
                            commandList.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                            Dim adapterList As New MySqlDataAdapter(commandList)
                            Dim articleList As New DataTable()

                            adapterList.Fill(articleList)

                            If articleList.Rows.Count > 0 Then

                                Dim p003_ As Paragraph = New Paragraph(Chr(13) & Chr(13) & Chr(13), pRow)
                                p003_.Alignment = Element.ALIGN_LEFT
                                pdfDoc.Add(p003_)


                                Dim p003 As Paragraph = New Paragraph(Chr(13) & "FAMILLE : " & tableListFamille.Rows(t)("CODE_SOUS_FAMILLE") & Chr(13) & Chr(13), pRow)
                                p003.Alignment = Element.ALIGN_LEFT
                                pdfDoc.Add(p003)

                                Dim pdfTable As New PdfPTable(6) 'Number of columns
                                pdfTable.TotalWidth = 555.0F
                                pdfTable.LockedWidth = True
                                pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                                pdfTable.HeaderRows = 1

                                Dim widths As Single() = New Single() {10.0F, 65.0F, 25.0F, 20.0F, 25.0F, 25.0F}

                                pdfTable.SetWidths(widths)

                                Dim pdfCell As PdfPCell = Nothing

                                pdfCell = New PdfPCell(New Paragraph("No", fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph("DESIGNATION", fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph("UNITE", fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph("QTE", fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph("PU", fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph("TOTAL", fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                For l = 0 To articleList.Rows.Count - 1

                                    '----------------------------------------------

                                    Dim FillingListquery03 As String = ""

                                    FillingListquery03 = "SELECT `DATE_BORDEREAU` AS 'DATE',  DESIGNATION_FR AS 'DESIGNATION', NUM_SERIE_DEBUT AS 'UNITE', ligne_bordereaux.QUANTITE As 'QTE AVANT MOVT', QUANTITE_ENTREE_STOCK AS 'QTE EN MOVT', PRIX_UNITAIRE_HT AS 'PRIX UNITAIRE', PRIX_TOTAL_HT AS 'TOTAL' FROM `bordereaux`, ligne_bordereaux, article WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND article.CODE_SOUS_FAMILLE = @CODE_SOUS_FAMILLE AND ligne_bordereaux.CODE_ARTICLE =@CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX = @CODE_BORDEREAUX ORDER BY ID_LIGNE_BORDEREAU DESC"

                                    Dim commandList03 As New MySqlCommand(FillingListquery03, GlobalVariable.connect)
                                    commandList03.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                                    commandList03.Parameters.Add("@CODE_SOUS_FAMILLE", MySqlDbType.VarChar).Value = tableListFamille.Rows(t)("CODE_SOUS_FAMILLE")
                                    commandList03.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = articleList.Rows(l)("CODE_ARTICLE")
                                    commandList03.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                                    Dim adapterList03 As New MySqlDataAdapter(commandList03)
                                    Dim dt_ As New DataTable()

                                    adapterList03.Fill(dt_)

                                    If dt_.Rows.Count > 0 Then

                                        Dim qteTotal As Double = 0
                                        Dim montantTotal As Double = 0

                                        For m = 0 To dt_.Rows.Count - 1
                                            qteTotal += dt_.Rows(m)("QTE EN MOVT")
                                            montantTotal += dt_.Rows(m)("TOTAL")
                                            totalAchat += dt_.Rows(m)("TOTAL")
                                            GrandTotalAchat += dt_.Rows(m)("TOTAL")
                                            totaux += dt_.Rows(m)("TOTAL")
                                        Next

                                        pdfCell = New PdfPCell(New Paragraph(l + 1, font1))
                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        pdfCell = New PdfPCell(New Paragraph(dt_.Rows(0)("DESIGNATION"), font1))
                                        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        pdfCell = New PdfPCell(New Paragraph(dt_.Rows(0)("UNITE"), font1))
                                        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        pdfCell = New PdfPCell(New Paragraph(Format(qteTotal, "#,##0.0"), font1))
                                        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        If qteTotal > 0 Then
                                            pdfCell = New PdfPCell(New Paragraph(Format(montantTotal / qteTotal, "#,##0"), font1))
                                        Else
                                            pdfCell = New PdfPCell(New Paragraph(Format(dt_.Rows(0)("PRIX UNITAIRE"), "#,##0"), font1))
                                        End If

                                        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        pdfCell = New PdfPCell(New Paragraph(Format(montantTotal, "#,##0"), font1))
                                        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                    End If
                                    '----------------------------------------------

                                Next

                                pdfCell = New PdfPCell(New Paragraph("TOTAL : ", fontTotal))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                pdfCell.Border = 0
                                pdfCell.Colspan = 4

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(Format(GrandTotalAchat, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), fontTotal))
                                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                                pdfCell.MinimumHeight = 5
                                pdfCell.Colspan = 2
                                pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                pdfDoc.Add(pdfTable)

                            End If

                        End If

                    Next

                    Dim p0030 As Paragraph = New Paragraph(Chr(13) & "TOTAUX : " & Format(totaux, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), pRow)
                    p0030.Alignment = Element.ALIGN_CENTER
                    pdfDoc.Add(p0030)


                End If

                '------------------------------------------------------- HISTORIQUES DES LISTES PASSES --------------------------------------------------------

                Dim GrandTotalAchat_ As Double = 0
                Dim totalAchat_ As Double = 0

                Dim date_1 As Date
                Dim date_2 As Date


                date_1 = dateDebut.AddDays(-7).ToShortDateString
                date_2 = dateDebut.AddDays(-1).ToShortDateString


                Dim p030 As Paragraph = New Paragraph(Chr(13) & "HISTORIQUES DU MARCHE " & date_1 & " AU " & date_2, pRow)
                p030.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p030)

                Dim FillingListquery02_ As String = "SELECT DISTINCT CODE_SOUS_FAMILLE FROM article, bordereaux, ligne_bordereaux WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX = @CODE_BORDEREAUX ORDER BY DATE_BORDEREAU DESC"

                Dim commandList02_ As New MySqlCommand(FillingListquery02_, GlobalVariable.connect)
                commandList02_.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                commandList02_.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                Dim adapterList02_ As New MySqlDataAdapter(commandList02)
                Dim tableListFamille_ As New DataTable()

                adapterList02_.Fill(tableListFamille_)

                If tableListFamille_.Rows.Count > 0 Then

                    '3- LISTES DES ARTICLES  (PAR MAGASIN ET PAR FAMILLE)

                    For t = 0 To tableListFamille_.Rows.Count - 1

                        If True Then

                            totalAchat_ = 0

                            Dim FillingListquery_ As String = "SELECT DISTINCT ligne_bordereaux.CODE_ARTICLE FROM `bordereaux`, ligne_bordereaux, article WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX=@CODE_BORDEREAUX AND article.CODE_SOUS_FAMILLE = @CODE_SOUS_FAMILLE ORDER BY ID_LIGNE_BORDEREAU DESC"

                            'article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE
                            ',  DESIGNATION_FR AS DESIGNATION

                            Dim commandList_ As New MySqlCommand(FillingListquery_, GlobalVariable.connect)
                            commandList_.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                            commandList_.Parameters.Add("@CODE_SOUS_FAMILLE", MySqlDbType.VarChar).Value = tableListFamille_.Rows(t)("CODE_SOUS_FAMILLE")
                            commandList_.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                            Dim adapterList_ As New MySqlDataAdapter(commandList_)
                            Dim articleList_ As New DataTable()

                            adapterList_.Fill(articleList_)

                            If articleList_.Rows.Count > 0 Then

                                Dim p003 As Paragraph = New Paragraph(Chr(13) & "FAMILLE : " & tableListFamille_.Rows(t)("CODE_SOUS_FAMILLE") & Chr(13) & Chr(13), pRow)
                                p003.Alignment = Element.ALIGN_LEFT

                                pdfDoc.Add(p003)

                                Dim pdfTable As New PdfPTable(8) 'Number of columns
                                pdfTable.TotalWidth = 555.0F
                                pdfTable.LockedWidth = True
                                pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                                pdfTable.HeaderRows = 1

                                Dim widths As Single() = New Single() {65.0F, 20.0F, 20.0F, 20.0F, 20.0F, 20.0F, 20.0F, 20.0F}

                                pdfTable.SetWidths(widths)

                                Dim pdfCell As PdfPCell = Nothing

                                pdfCell = New PdfPCell(New Paragraph("DESIGNATION", fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(date_1.ToShortDateString, fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(1).ToShortDateString, fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(2).ToShortDateString, fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(3).ToShortDateString, fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(4).ToShortDateString, fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(5).ToShortDateString, fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(date_1.AddDays(6).ToShortDateString, fontTotal1))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                'pdfCell.Border = 0

                                pdfTable.AddCell(pdfCell)

                                For l = 0 To articleList_.Rows.Count - 1

                                    '----------------------------------------------

                                    Dim FillingListquery03_ As String = "SELECT `DATE_BORDEREAU` AS 'DATE',  DESIGNATION_FR AS 'DESIGNATION', NUM_SERIE_DEBUT AS 'UNITE', ligne_bordereaux.QUANTITE As 'QTE AVANT MOVT', QUANTITE_ENTREE_STOCK AS 'QTE EN MOVT', PRIX_UNITAIRE_HT AS 'PRIX UNITAIRE', PRIX_TOTAL_HT AS 'TOTAL' FROM `bordereaux`, ligne_bordereaux, article WHERE TYPE_BORDEREAUX IN ('" & TYPE_BORDEREAUX_1 & "') AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND article.CODE_SOUS_FAMILLE = @CODE_SOUS_FAMILLE AND ligne_bordereaux.CODE_ARTICLE =@CODE_ARTICLE AND bordereaux.CODE_BORDEREAUX = @CODE_BORDEREAUX ORDER BY ID_LIGNE_BORDEREAU DESC"

                                    Dim commandList03_ As New MySqlCommand(FillingListquery03_, GlobalVariable.connect)
                                    commandList03_.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
                                    commandList03_.Parameters.Add("@CODE_SOUS_FAMILLE", MySqlDbType.VarChar).Value = tableListFamille_.Rows(t)("CODE_SOUS_FAMILLE")
                                    commandList03_.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = articleList_.Rows(l)("CODE_ARTICLE")
                                    commandList03_.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

                                    Dim adapterList03_ As New MySqlDataAdapter(commandList03_)
                                    Dim dt_ As New DataTable()

                                    adapterList03_.Fill(dt_)

                                    If dt_.Rows.Count > 0 Then

                                        Dim qteTotal_ As Double = 0
                                        Dim montantTotal_ As Double = 0

                                        For m = 0 To dt_.Rows.Count - 1
                                            qteTotal_ += dt_.Rows(m)("QTE EN MOVT")
                                            montantTotal_ += dt_.Rows(m)("TOTAL")
                                            totalAchat_ += dt_.Rows(m)("TOTAL")
                                            GrandTotalAchat_ += dt_.Rows(m)("TOTAL")
                                        Next

                                        pdfCell = New PdfPCell(New Paragraph(dt_.Rows(0)("DESIGNATION"), font1))
                                        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        Dim CODE_ARTICLE As String = articleList_.Rows(l)("CODE_ARTICLE")

                                        Dim montant As Double = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.ToShortDateString)

                                        If montant = 0 Then
                                            pdfCell = New PdfPCell(New Paragraph("", font1))
                                        Else
                                            pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                        End If

                                        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(1).ToShortDateString)

                                        If montant = 0 Then
                                            pdfCell = New PdfPCell(New Paragraph("", font1))
                                        Else
                                            pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                        End If

                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(2).ToShortDateString)

                                        If montant = 0 Then
                                            pdfCell = New PdfPCell(New Paragraph("", font1))
                                        Else
                                            pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                        End If

                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(3).ToShortDateString)

                                        If montant = 0 Then
                                            pdfCell = New PdfPCell(New Paragraph("", font1))
                                        Else
                                            pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                        End If

                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(4).ToShortDateString)

                                        If montant = 0 Then
                                            pdfCell = New PdfPCell(New Paragraph("", font1))
                                        Else
                                            pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                        End If
                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(5).ToShortDateString)

                                        If montant = 0 Then
                                            pdfCell = New PdfPCell(New Paragraph("", font1))
                                        Else
                                            pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                        End If
                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                        montant = Functions.historiquesDuMarche(CODE_ARTICLE, date_1.AddDays(6).ToShortDateString)

                                        If montant = 0 Then
                                            pdfCell = New PdfPCell(New Paragraph("", font1))
                                        Else
                                            pdfCell = New PdfPCell(New Paragraph(Format(montant, "#,##0"), font1))
                                        End If
                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                        pdfCell.MinimumHeight = 5

                                        pdfTable.AddCell(pdfCell)

                                    End If
                                    '----------------------------------------------

                                Next

                                pdfCell = New PdfPCell(New Paragraph("TOTAL : ", fontTotal))
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                                pdfCell.MinimumHeight = 7
                                'pdfCell.PaddingLeft = 5.0F
                                pdfCell.Border = 0
                                pdfCell.Colspan = 4

                                'pdfTable.AddCell(pdfCell)

                                pdfCell = New PdfPCell(New Paragraph(Format(totalAchat_, "#,##0"), fontTotal))
                                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                                pdfCell.MinimumHeight = 5
                                'pdfCell.PaddingLeft = 5.0F
                                pdfCell.Border = 0

                                'pdfTable.AddCell(pdfCell)

                                pdfDoc.Add(pdfTable)

                            End If

                        End If

                    Next

                End If

                '----------------------------------------------------------------------------------------------------------------------------------------------

                pdfDoc.Close()

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim bodyText As String = ""

                '------------------------------------SENDING OF NOTIFICATION -------------------------------------------------------------------------------------------------------------------------------------------
                Dim sendMessage As New User()

                Dim CODE_PROFIL As String = "ECONOME"
                Dim MESSAGE As String = ""
                Dim OBJET As String = ""
                Dim EXPEDITEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
                Dim DATE_ENVOI As Date = GlobalVariable.DateDeTravail

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                If ETAT_BORDEREAUX = 0 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à CONTRÔLER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à CONTRÔLER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 1 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à VERIFIER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VERIFIER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 2 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à VALIDER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VALIDER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 3 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à COMMANDER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à COMMANDER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 4 Then
                    bodyText = "Parcours du ," & tireDocument.ToUpper() & Chr(13) & " effectué avec succès. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Parcours du ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " effectué avec succès"
                    OBJET = tireDocument.ToUpper()
                End If

                sendMessage.sendMessage(CODE_PROFIL, MESSAGE.ToUpper(), OBJET, DATE_ENVOI, EXPEDITEUR)

                'envoieDocumentMailEconomat(fichier, tireDocument, bodyText, ETAT_BORDEREAUX)

                Dim nmessageOuDocument As Integer = 1
                Dim typeDeDocument As Integer = 0
                Dim phoneNumber As String = ""

                Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument, phoneNumber, ETAT_BORDEREAUX)

            Else

                Dim societe As DataTable = Functions.allTableFields("societe")

                Dim TotalCommande As Double = 0

                Dim tireDocument As String = title.ToUpper() & " DU " & (Date.Now().ToString("ddMMyyHHmmss"))

                Dim sousTitreDocument As String = ""

                sousTitreDocument = tireDocument

                '---------------------------------------------------------------------------------------------------------------
                Dim titreFichier As String = ""

                titreFichier = title & " (" & libelle & " - " & numeroBon & ")"
                '& "(" & libelle & "/" & numeroBon & ")"
                tireDocument = titreFichier & " DU " & GlobalVariable.DateDeTravail.ToShortDateString

                Dim nomDuDossierRapport As String = "RAPPORTS\ECONOMAT"

                Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

                My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

                Dim fichier As String = filePathAndDirectory & "\" & titreFichier & " DU " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"

                '---------------------------------------------------------------------------------------------------------------
                Dim pdfDoc As New Document(PageSize.A4, 40, 20, 80, 40)
                'Dim pdfDoc As New Document(PageSize.A4, 40, 5, 5, 5)
                Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
                Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim font1 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

                pdfWrite.PageEvent = New HeaderFooter

                pdfDoc.Open()

                Dim p3 As Paragraph = New Paragraph(Chr(13) & title.ToUpper() & " DU " & " " & GlobalVariable.DateDeTravail & Chr(13) & Chr(13), pRow)
                p3.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p3)

                Dim infoSupBon As DataTable = Functions.getElementByCode(numeroBon, "bordereaux", "CODE_BORDEREAUX")

                If infoSupBon.Rows.Count > 0 Then

                    Dim p0 As Paragraph = New Paragraph(Chr(13) & title & " NUMERO :  " & infoSupBon.Rows(0)("CODE_BORDEREAUX") & Chr(13) & "LIBELLE: " & infoSupBon.Rows(0)("LIBELLE_BORDEREAUX") & Chr(13) & "REFERENCE: " & infoSupBon.Rows(0)("REF_BORDEREAUX") & Chr(13) & "TIERS: " & infoSupBon.Rows(0)("NON_TIERS") & Chr(13) & Chr(13), pRow)
                    p0.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p0)

                Else

                    Dim p0 As Paragraph = New Paragraph(Chr(13) & title & " NUMERO :  " & numeroBon & Chr(13) & "LIBELLE: " & libelle & Chr(13) & "REFERENCE: " & reference & Chr(13) & "TIERS: " & nomTiers & Chr(13) & Chr(13), pRow)
                    p0.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p0)

                End If

                'Dim pdfTable As New PdfPTable(8) 'Number of columns
                Dim pdfTable As New PdfPTable(5) 'Number of columns
                pdfTable.TotalWidth = 555.0F
                pdfTable.LockedWidth = True
                pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfTable.HeaderRows = 1

                'Dim widths As Single() = New Single() {25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F, 25.0F}
                Dim widths As Single() = New Single() {15.0F, 60.0F, 15.0F, 15.0F, 15.0F}

                pdfTable.SetWidths(widths)

                Dim pdfCell As PdfPCell = Nothing

                pdfCell = New PdfPCell(New Paragraph("REF.", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("LIBELLE", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("QTE", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("PU", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("TOTAL", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                For j = 0 To dt.Rows.Count - 1

                    For k = 0 To dt.Columns.Count - 1

                        If k = 0 Or k = 1 Or k = 2 Or k = 4 Or k = 5 Then

                            If Not Trim(dt.Rows(j).Cells(k).Value.ToString).Equals("") Then

                                If k = 4 Or k = 5 Then
                                    pdfCell = New PdfPCell(New Paragraph(Format(dt.Rows(j).Cells(k).Value, "#,##0"), font1))
                                Else
                                    pdfCell = New PdfPCell(New Paragraph(dt.Rows(j).Cells(k).Value, font1))
                                End If

                            End If

                            If k = 0 Then
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            ElseIf k = 1 Then
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                            ElseIf k = 2 Then
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            ElseIf k = 4 Or k = 5 Then
                                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                            End If

                            pdfCell.MinimumHeight = 5

                            pdfTable.AddCell(pdfCell)

                        End If

                    Next

                Next

                pdfCell = New PdfPCell(New Paragraph("TOTAL", fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0
                pdfCell.Colspan = 4

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph(Format(totalAchat, "#,##0"), fontTotal))
                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfDoc.Add(pdfTable)

                Dim p03 As Paragraph = New Paragraph(Chr(13) & "OBSERVATIONS : " & observations & Chr(13), font1)
                p03.Alignment = Element.ALIGN_LEFT

                pdfDoc.Add(p03)

                '------------------------------------------------------------------------

                pdfDoc.Close()

                'Process.Start(sfd.FileName)

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim bodyText As String = ""

                '------------------------------------SENDING OF NOTIFICATION -------------------------------------------------------------------------------------------------------------------------------------------
                Dim sendMessage As New User()

                Dim CODE_PROFIL As String = "ECONOME"
                Dim MESSAGE As String = ""
                Dim OBJET As String = ""
                Dim EXPEDITEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR")
                Dim DATE_ENVOI As Date = GlobalVariable.DateDeTravail

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                If ETAT_BORDEREAUX = 0 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à CONTRÔLER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à CONTRÔLER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 1 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à VERIFIER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VERIFIER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 2 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à VALIDER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VALIDER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 3 Then
                    bodyText = "Vous avez un ," & tireDocument.ToUpper() & Chr(13) & " à COMMANDER. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à COMMANDER "
                    OBJET = tireDocument.ToUpper()
                ElseIf ETAT_BORDEREAUX = 4 Then
                    bodyText = "Parcours du ," & tireDocument.ToUpper() & Chr(13) & " effectué avec succès. Vous trouverez ci joint : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"
                    MESSAGE = "Parcours du ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " effectué avec succès"
                    OBJET = tireDocument.ToUpper()
                End If

                sendMessage.sendMessage(CODE_PROFIL, MESSAGE.ToUpper(), OBJET, DATE_ENVOI, EXPEDITEUR)

                'envoieDocumentMailEconomat(fichier, tireDocument, bodyText, ETAT_BORDEREAUX)

                Dim nmessageOuDocument As Integer = 1
                Dim typeDeDocument As Integer = 0
                Dim phoneNumber As String = ""

                Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument, phoneNumber, ETAT_BORDEREAUX)


            End If

        Else

        End If


    End Sub

    Private Declare Function InternetGetConnectedState Lib "wininet" (ByRef conn As Long, ByVal val As Long) As Boolean


    Public Shared Async Sub envoieDocumentMailCloture_(ByVal fichier As String, ByVal Titre As String, ByVal bodyText As String, ByVal dateTravail As Date, Optional i As Integer = 0)

        Dim Out As Integer

        Dim haveInternet As Boolean = Functions.checkInternetCOnnection()

        If haveInternet Then

            Try

                'ENVOI DES RAPPORTS PAR MAIL

                Dim emailTo As String = ""
                Dim emailFrom As String = "rapport@hotelsoft.cm"

                Dim mail As New MailMessage()
                Dim SmtpServer As New SmtpClient("mail67.lwspanel.com")
                mail.From = New MailAddress(emailFrom)

                Dim mail_ As New MailMessage()
                Dim SmtpServer_ As New SmtpClient("mail67.lwspanel.com")
                mail_.From = New MailAddress(emailFrom)

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_1")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_1")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_2")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_2")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_3")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_3")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_4")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_4")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_5")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_5")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                'mail.Subject = Titre
                mail.Subject = "RAPPORT DE CLOTURE DU " & dateTravail
                'mail.Body = bodyText
                mail.Body = "Recevez nos salutations, Merci de bien vouloir trouver ci joint les rapports de la cloture du " & dateTravail & ". Barclés Hôtel Soft. Ne pas répondre a ce mail !!"

                '--------------------- LISTE OF ATTACHEMENTS ------------------------
                'For Each sA As String In listeOfAttachement
                'mail.Attachments.Add(New Attachment(sA))
                'Next
                '--------------------------------------------------------------------

                Dim attachment As System.Net.Mail.Attachment

                Dim dtRapport As DataTable = Functions.verificationExistenceCheminDesRapportsDuJours(dateTravail)

                If dtRapport.Rows.Count > 0 Then

                    If i = 0 Then

                        attachment = New System.Net.Mail.Attachment(fichier)
                        mail.Attachments.Add(attachment)

                        If Not Trim(dtRapport.Rows(0)("CHEMIN_MAINCOURANTE_CUMUL")).Equals("") Then
                            attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_MAINCOURANTE_CUMUL"))
                            mail.Attachments.Add(attachment)
                        End If

                        If Not Trim(dtRapport.Rows(0)("CHEMIN_REGLEMENT")).Equals("") Then
                            attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_REGLEMENT"))
                            mail.Attachments.Add(attachment)
                        End If

                    Else

                        If Not Trim(dtRapport.Rows(0)("CHEMIN_INVENTAIRES_DES_VENTES")).Equals("") Then
                            attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_INVENTAIRES_DES_VENTES"))
                            mail.Attachments.Add(attachment)
                        End If

                        If Not Trim(dtRapport.Rows(0)("CHEMIN_INVENTAIRES")).Equals("") Then
                            attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_INVENTAIRES"))
                            mail.Attachments.Add(attachment)
                        End If

                        If Not Trim(dtRapport.Rows(0)("CHEMIN_VENTES")).Equals("") Then
                            attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_VENTES"))
                            mail.Attachments.Add(attachment)
                        End If

                    End If

                End If

                SmtpServer.Port = 587

                SmtpServer.Credentials = New System.Net.NetworkCredential("rapport@hotelsoft.cm", "H@telsoft2022")

                SmtpServer.EnableSsl = False

                If mail.Attachments.Count > 0 Then
                    SmtpServer.Send(mail)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Envoi de mail Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try

        Else

            Functions.noInternetMessage()

        End If

    End Sub

    Public Shared Async Sub envoieDocumentMailCloture(ByVal fichier As String, ByVal Titre As String, ByVal bodyText As String, ByVal dateTravail As Date)

        Dim Out As Integer

        Dim haveInternet As Boolean = Functions.checkInternetCOnnection()

        If haveInternet Then

            Try

                'ENVOI DES RAPPORTS PAR MAIL

                Dim emailTo As String = ""
                Dim emailFrom As String = "rapports@barcleshotelsoft.com"

                Dim mail As New MailMessage()
                Dim SmtpServer As New SmtpClient("mail55.lwspanel.com")
                mail.From = New MailAddress(emailFrom)

                Dim mail_ As New MailMessage()
                Dim SmtpServer_ As New SmtpClient("mail55.lwspanel.com")
                mail_.From = New MailAddress(emailFrom)

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_1")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_1")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_2")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_2")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_3")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_3")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_4")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_4")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_5")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_5")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_6")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_6")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_7")).Equals("") Then
                    emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_7")
                    mail.[To].Add(emailTo)
                    mail_.[To].Add(emailTo)
                End If
                'mail.Subject = Titre
                mail.Subject = "RAPPORT DE CLOTURE DU " & dateTravail
                'mail.Body = bodyText
                mail.Body = "Recevez nos salutations, Merci de bien vouloir trouver ci joint les rapports de la cloture du " & dateTravail & ". Barclés Hôtel Soft. Ne pas répondre a ce mail !!"

                '--------------------- LISTE OF ATTACHEMENTS ------------------------
                'For Each sA As String In listeOfAttachement
                'mail.Attachments.Add(New Attachment(sA))
                'Next
                '--------------------------------------------------------------------

                Dim attachment As System.Net.Mail.Attachment

                Dim dtRapport As DataTable = Functions.verificationExistenceCheminDesRapportsDuJours(dateTravail)

                If dtRapport.Rows.Count > 0 Then

                    attachment = New System.Net.Mail.Attachment(fichier)
                    mail.Attachments.Add(attachment)

                    If Not Trim(dtRapport.Rows(0)("CHEMIN_MAINCOURANTE_CUMUL")).Equals("") Then
                        attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_MAINCOURANTE_CUMUL"))
                        mail.Attachments.Add(attachment)
                    End If

                    If Not Trim(dtRapport.Rows(0)("CHEMIN_VENTES")).Equals("") Then
                        attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_VENTES"))
                        mail.Attachments.Add(attachment)
                    End If

                    If Not Trim(dtRapport.Rows(0)("CHEMIN_REGLEMENT")).Equals("") Then
                        attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_REGLEMENT"))
                        mail.Attachments.Add(attachment)
                    End If

                    If Not Trim(dtRapport.Rows(0)("CHEMIN_VENTES")).Equals("") Then
                        attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_VENTES"))
                        mail.Attachments.Add(attachment)
                    End If

                    If Not Trim(dtRapport.Rows(0)("CHEMIN_INVENTAIRES")).Equals("") Then
                        attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_INVENTAIRES"))
                        mail.Attachments.Add(attachment)
                    End If

                    If Not Trim(dtRapport.Rows(0)("CHEMIN_INVENTAIRES_DES_VENTES")).Equals("") Then
                        attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_INVENTAIRES_DES_VENTES"))
                        mail.Attachments.Add(attachment)
                    End If


                End If

                SmtpServer.Port = 587

                SmtpServer.Credentials = New System.Net.NetworkCredential("rapports@barcleshotelsoft.com", "H@telsoft2014")

                SmtpServer.EnableSsl = False

                If mail.Attachments.Count > 0 Then
                    SmtpServer.Send(mail)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Envoi de mail Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try

        Else

            Functions.noInternetMessage()

        End If

    End Sub

    Public Shared Async Sub envoieDocumentMailEconomat(ByVal fichier As String, ByVal Titre As String, ByVal bodyText As String, ByVal ETAT_BORDEREAU As Integer)

        Dim Out As Integer

        Dim haveInternet As Boolean = Functions.checkInternetCOnnection()

        'InternetGetConnectedState(Out, 0) = = True

        If haveInternet Then

            Try

                Dim web As New WebBrowser()

                'ENVOI DES RAPPORTS PAR MAIL

                Dim emailTo As String = "kamdemlandrygaetan@gmail.com"
                Dim emailFrom As String = "rapport@hotelsoft.cm"

                Dim mail As New MailMessage()
                'Dim SmtpServer As New SmtpClient("smtp.gmail.com")
                Dim SmtpServer As New SmtpClient("mail53.lwspanel.com")
                mail.From = New MailAddress(emailFrom)

                'CONTROLEUR
                If ETAT_BORDEREAU = 0 Then
                    If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_3")).Equals("") Then
                        emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_3")
                        mail.[To].Add(emailTo)
                    End If
                End If

                'COMPTABLE :  VERIFIER
                If ETAT_BORDEREAU = 1 Then
                    If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_2")).Equals("") Then
                        emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_2")
                        mail.[To].Add(emailTo)
                    End If
                End If

                'PDG : VALIDER
                If ETAT_BORDEREAU = 2 Then
                    If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_5")).Equals("") Then
                        emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_5")
                        mail.[To].Add(emailTo)
                    End If
                End If

                'ECONOM : COMMANDER
                If ETAT_BORDEREAU = 3 Then
                    If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_1")).Equals("") Then
                        emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_1")
                        mail.[To].Add(emailTo)
                    End If
                End If

                'DG AU COURANT DE TOUT

                If ETAT_BORDEREAU = 4 Then
                    If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_4")).Equals("") Then
                        emailTo = GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_4")
                        mail.[To].Add(emailTo)
                    End If
                End If

                mail.Subject = Titre
                mail.Body = bodyText

                '--------------------- LISTE OF ATTACHEMENTS ------------------------
                'For Each sA As String In listeOfAttachement
                'mail.Attachments.Add(New Attachment(sA))
                'Next
                '--------------------------------------------------------------------

                Dim attachment As System.Net.Mail.Attachment
                attachment = New System.Net.Mail.Attachment(fichier)

                mail.Attachments.Add(attachment)

                SmtpServer.Port = 587
                'SmtpServer.Credentials = New System.Net.NetworkCredential("kamdemlandrygaetan@gmail.com", "2Klg16051990")
                SmtpServer.Credentials = New System.Net.NetworkCredential("rapport@hotelsoft.cm", "H@telsoft2022")
                'SmtpServer.UseDefaultCredentials = True
                SmtpServer.EnableSsl = False

                SmtpServer.Send(mail)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Envoi de mail", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try

        Else

            Functions.noInternetMessage()

        End If

    End Sub

    Public Shared Async Sub GenerationDeFicheDePolice(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, ByVal Email As String, ByVal WHATSAPP_OU_MAIL As Integer)

        Dim societe As DataTable = Functions.allTableFields("societe")
        Dim clientInformation As DataTable = Functions.getElementByCode(client, "client", "NOM_PRENOM")
        Dim Reservation As DataTable

        Reservation = Functions.getElementByCode(NumConfirmation, "reservation", "CODE_RESERVATION")

        If Not Reservation.Rows.Count > 0 Then
            Reservation = Functions.getElementByCode(NumConfirmation, "reserve_conf", "CODE_RESERVATION")
        End If

        '------------------------------------------------------------------------------------------------------

        Dim titreFichier As String = "FICHE DE POLICE DE " & client

        Dim nomDuDossierRapport As String = "ENVOI\FICHE DE POLICE"

        Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim fichier As String = filePathAndDirectory & "\" & titreFichier & ".pdf"

        '------------------------------------------------------------------------------------------------------

        'Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
        Dim pdfDoc As New Document(PageSize.A4, 20, 20, 80, 40)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
        Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim pColumnEnlish As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.ITALIC, BaseColor.BLUE)
        Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim fontPolicyFrenchTitle As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim fontPolicyFrenchText As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim fontPolicyEnglishText As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.ITALIC, BaseColor.BLUE)
        Dim fontPolicyEnglishTextChunk As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC, BaseColor.BLUE)

        Dim Libelle As String
        Dim LibelleJour As String
        Dim LibelleReservation As String
        Dim TitreDuDocument As String

        If GlobalVariable.typeChambreOuSalle = "salle" Then

            Libelle = "Location de Salle"
            LibelleJour = "Jour"
            LibelleReservation = "CONTRAT DE RESERVATION N°: "
            TitreDuDocument = "CONTRAT"

        Else

            Libelle = "Hébergement"
            LibelleJour = "nuitée"
            LibelleReservation = "FICHE DE RESERVATION N°: "
            TitreDuDocument = "FICHE DE POLICE / HOTEL REGISTRATION FORM"

        End If

        pdfWrite.PageEvent = New HeaderFooter

        pdfDoc.Open()

        Dim p1 As Paragraph = New Paragraph(Chr(13) & TitreDuDocument & Chr(13) & Chr(13), pColumn)
        p1.Alignment = Element.ALIGN_CENTER
        pdfDoc.Add(p1)

        Dim intro As String = "Cher(e) Mr/Mme:" & client & ", Merci d'avoir choisi de séjourner avec nous a " & societe.Rows(0)("RAISON_SOCIALE") & ". Nous avons le plaisir de confirmer votre réservation comme suit : " & Chr(13) & Chr(13)

        'pdfDoc.Add(New Paragraph(intro, font1))e

        '---------------------------------------------------------------------------------------------------------------------------------------------

        Dim pdfTable3 As New PdfPTable(6) 'Number of columns

        pdfTable3.TotalWidth = 550.0F
        pdfTable3.LockedWidth = True
        pdfTable3.HorizontalAlignment = Element.ALIGN_RIGHT
        'pdfTable3.HeaderRows = 1

        '-------------------------------

        Dim frenchPhrase = New Paragraph("RENSEIGNEMENTS PERSONNELS / ", pColumn)
        Dim englishPhrase = New Paragraph("PERSONAL INFORMATION" & Chr(13) & " ", pColumnEnlish)


        Dim pdfTable31 As New PdfPTable(2)
        pdfTable31.LockedWidth = True
        Dim pdfCell31 As PdfPCell = Nothing
        Dim widths31 As Single() = New Single() {20.0F, 20.0F}
        pdfTable31.SetWidths(widths31)

        pdfCell31 = New PdfPCell(frenchPhrase)

        pdfCell31.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell31.Border = 0
        pdfTable31.AddCell(pdfCell31)

        pdfCell31 = New PdfPCell(frenchPhrase)

        pdfCell31.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell31.Border = 0
        pdfTable31.AddCell(pdfCell31)
        '-------------------------------
        Dim widths3 As Single() = New Single() {20.0F, 30.0F, 20.0F, 23.0F, 22.0F, 22.0F}
        pdfTable3.SetWidths(widths3)

        Dim pdfCell3 As PdfPCell = Nothing
        pdfCell3 = New PdfPCell(New Paragraph("RENSEIGNEMENTS PERSONNELS / PERSONAL INFORMATION" & Chr(13) & " ", pColumn))

        'pdfCell3 = New PdfPCell(New Paragraph(LibelleReservation & Chr(13) & Chr(13) & "Nom (en gros caractère) : " & Chr(13) & "(Surname in block block capitals)" & Chr(13) & Chr(13) & "Nom de jeune fille : " & Chr(13) & "(Madein name if applicable)" & Chr(13) & Chr(13) & "Prénom : " & Chr(13) & "(Christian name)" & Chr(13) & Chr(13) & "Date de Naissance : " & Chr(13) & "(Date of birth)" & Chr(13) & Chr(13) & "Lieu de Naissance : " & Chr(13) & "(Place of birth)" & Chr(13) & Chr(13) & "Nationalité : " & Chr(13) & "(Nationality)" & Chr(13) & Chr(13) & "CNI/NIU : " & Chr(13) & "(ID Card)" & Chr(13) & Chr(13) & "Pays de résidence : " & Chr(13) & "(Country of permanance residence)" & Chr(13) & Chr(13) & "Téléphone : " & Chr(13) & "(Telephone)" & Chr(13) & Chr(13) & "Adresse : " & Chr(13) & "(Adress)" & Chr(13) & Chr(13) & "Profession : " & Chr(13) & "(Occupation)", font1))

        pdfCell3.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell3.Colspan = 6
        pdfCell3.Border = 0
        pdfTable3.AddCell(pdfCell3)

        'pdfCell3 = New PdfPCell(New Paragraph(NumConfirmation & Chr(13) & Chr(13) & clientInformation.Rows(0)("NOM_CLIENT") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("NOM_JEUNE_FILLE") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("PRENOMS") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("DATE_DE_NAISSANCE") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("LIEU_DE_NAISSANCE") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("NATIONALITE") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("CNI") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("PAYS_RESIDENCE") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("TELEPHONE") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("ADRESSE") & Chr(13) & Chr(13) & Chr(13) & clientInformation.Rows(0)("PROFESSION"), pColumn))

        pdfCell3 = New PdfPCell(New Paragraph("Nom / " & Chr(13) & "Name : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("NOM_CLIENT"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Prénom / " & Chr(13) & "First name : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("PRENOMS"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Nom de jeune fille / " & Chr(13) & "Modern name : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("NOM_JEUNE_FILLE"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Date de naissance / " & Chr(13) & "Date of birth : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("DATE_DE_NAISSANCE"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Lieu de naissance / " & Chr(13) & "Place of birth : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("LIEU_DE_NAISSANCE"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Nationalité / " & Chr(13) & "Nationality : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("NATIONALITE"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Télephone / " & Chr(13) & "Phone : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("TELEPHONE"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Whatsapp / " & Chr(13) & "", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph("", font1))
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("CNI / Passport / " & Chr(13) & "ID Card / Passport : ", font1))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("CNI"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Adresse mail / " & Chr(13) & "E-mail addresse", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("EMAIL"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        'pdfCell3 = New PdfPCell(New Paragraph("Véhicule M / " & Chr(13) & "Car brand :", font1))
        'pdfTable3.AddCell(pdfCell3)
        'pdfCell3 = New PdfPCell(New Paragraph("", fontTotal))
        'pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        'pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Num Véhicule / " & Chr(13) & "Car reg. : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(clientInformation.Rows(0)("NUM_VEHICULE"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Couleur / " & Chr(13) & "Color", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph("", fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Venant de / " & Chr(13) & "Coming from :", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(Reservation.Rows(0)("VENANT_DE"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Se rendant à / " & Chr(13) & "Going to : ", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(Reservation.Rows(0)("SE_RENDANT_A"), fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfCell3 = New PdfPCell(New Paragraph("Nbre de Pax / " & Chr(13) & "Number of guest", font1))
        pdfTable3.AddCell(pdfCell3)
        pdfCell3 = New PdfPCell(New Paragraph(Reservation.Rows(0)("NB_PERSONNES").ToString, fontTotal))
        pdfCell31.HorizontalAlignment = Element.ALIGN_MIDDLE
        pdfTable3.AddCell(pdfCell3)

        pdfDoc.Add(pdfTable3)

        Dim pdfTable03 As New PdfPTable(6) 'Number of columns

        pdfTable03.TotalWidth = 550.0F
        pdfTable03.LockedWidth = True
        pdfTable03.HorizontalAlignment = Element.ALIGN_RIGHT
        'pdfTable03.HeaderRows = 1

        Dim widths03 As Single() = New Single() {20.0F, 30.0F, 18.0F, 25.0F, 22.0F, 22.0F}
        pdfTable03.SetWidths(widths03)

        Dim pdfCell03 As PdfPCell = Nothing
        pdfCell03 = New PdfPCell(New Paragraph(Chr(13) & "INFORMATIONS DE RESERVATION / BOOKING INFORMATION" & Chr(13) & " ", pColumn))

        pdfCell03.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell03.Colspan = 6
        pdfCell03.Border = 0
        pdfTable03.AddCell(pdfCell03)

        Dim MONTANT_TAXE_DE_SEJOUR As Double = 0

        Dim taxe_sejour As DataTable = Functions.getElementByCode(Reservation.Rows(0)("CODE_RESERVATION"), "taxe_sejour_collectee", "NUM_RESERVATION")

        If taxe_sejour.Rows.Count > 0 Then
            MONTANT_TAXE_DE_SEJOUR = taxe_sejour.Rows(0)("TAXE_SEJOUR_COLLECTEE")
        End If

        pdfCell03 = New PdfPCell(New Paragraph("N° de réservation / " & Chr(13) & "booking number : ", font1))
        pdfTable03.AddCell(pdfCell03)
        pdfCell03 = New PdfPCell(New Paragraph(Reservation.Rows(0)("CODE_RESERVATION"), fontTotal))
        pdfCell03.Colspan = 5
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Date d'arrivée / " & Chr(13) & "Arrival date : ", font1))
        pdfTable03.AddCell(pdfCell03)
        pdfCell03 = New PdfPCell(New Paragraph(CDate(Reservation.Rows(0)("DATE_ENTTRE")).ToShortDateString & " " & CDate(Reservation.Rows(0)("HEURE_ENTREE")).ToShortTimeString, fontTotal))
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Date de départ / " & Chr(13) & "Departure date: : ", font1))
        pdfTable03.AddCell(pdfCell03)
        pdfCell03 = New PdfPCell(New Paragraph(CDate(Reservation.Rows(0)("DATE_SORTIE")).ToShortDateString & " " & CDate(Reservation.Rows(0)("HEURE_SORTIE")).ToShortTimeString, fontTotal))
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Nb nuit(s) / " & Chr(13) & "Nb of night(s) : ", font1))
        pdfTable03.AddCell(pdfCell03)
        pdfCell03 = New PdfPCell(New Paragraph(Integer.Parse((Reservation.Rows(0)("DATE_SORTIE") - Reservation.Rows(0)("DATE_ENTTRE")).Days), fontTotal))
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Type de chambre /" & Chr(13) & "Room type : ", font1))
        pdfTable03.AddCell(pdfCell03)

        Dim nomTypeDeChambre As String = ""

        Dim infoRoomType As DataTable = Functions.getElementByCode(Reservation.Rows(0)("TYPE_CHAMBRE"), "type_chambre", "CODE_TYPE_CHAMBRE")

        If infoRoomType.Rows.Count > 0 Then
            nomTypeDeChambre = infoRoomType.Rows(0)("LIBELLE_TYPE_CHAMBRE")
        Else
            nomTypeDeChambre = Reservation.Rows(0)("TYPE_CHAMBRE")
        End If

        pdfCell03 = New PdfPCell(New Paragraph(nomTypeDeChambre, fontTotal))
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("N° de chambre / " & Chr(13) & "Room number : ", font1))
        pdfTable03.AddCell(pdfCell03)
        pdfCell03 = New PdfPCell(New Paragraph(Reservation.Rows(0)("CHAMBRE_ID").ToString, fontTotal))
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Tarif de chambre / " & Chr(13) & "Room rate : ", font1))
        pdfTable03.AddCell(pdfCell03)

        If Reservation.Rows(0)("AFFICHER_PRIX") = 1 Then
            pdfCell03 = New PdfPCell(New Paragraph(Format(Reservation.Rows(0)("MONTANT_ACCORDE") + MONTANT_TAXE_DE_SEJOUR, "#,##0").ToString & " " & societe.Rows(0)("CODE_MONNAIE"), fontTotal))
        ElseIf Reservation.Rows(0)("AFFICHER_PRIX") = 0 Then
            pdfCell03 = New PdfPCell(New Paragraph("/", fontTotal))
        End If
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph(Chr(13) & "REGLEMENT INTERIEUR ET CONDITIONS / TERMS AND CONDITIONS" & Chr(13) & " ", pColumn))
        pdfCell03.Border = 0
        pdfCell03.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Article 1 : Accueil / Check-in", fontPolicyFrenchTitle))
        pdfCell03.HorizontalAlignment = HorizontalAlignment.Left
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("L’Hotel se réserve le droit de ne pas recevoir ou annuler le séjour des clients dont la tenue est indécente et négligée ainsi que, les clients dont le comportement est contraire aux bonnes mœurs et à l’ordre public. Toute personne désireuse de loger à l’hôtel est tenue de faire connaître son identité et celle des personnes qui l’accompagnent.", fontPolicyFrenchText))
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("The Hotel reserves the right not to accept or cancel the stay of customers whose dress is indecent and negligent as well as guests whose behavior is contrary to morality and public order. Anyone wishing to stay at the hotel is required to make known their identity and that of their visitors", fontPolicyEnglishText))
        pdfCell03.Border = 0
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Article 2 : Heure de départ / Departure time", fontPolicyFrenchTitle))
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("La chambre doit être libérées avant 12h (midi) le jour de départ. Les départs tardifs, jusqu'à 14h, pourraient être autorisés selon la disponibilité. Les départs tardifs, jusqu'à 16h, pourraient être autorisés, le jour même, selon la disponibilité et moyennant des frais de 50% du tarif de la nuitée, plus taxes applicables. Tout départ tardif (après 16h) entraînera des frais équivalent à une nuit au tarif affiché, plus taxes applicables.", fontPolicyFrenchText))
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Rooms must be vacated before 12 noon on the day of departure. Late check-outs, up to 2 p.m., may be permitted depending on availability. Late departures, until 4 p.m., may be authorized the same day, depending on availability and for a fee of 50% of the overnight rate, plus applicable taxes. Any late departure (after 4 p.m.) will incur a charge equivalent to one night at the displayed rate, plus applicable taxes.", fontPolicyEnglishText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Article 3 : Gestion des cartes clefs / Keycard management", fontPolicyFrenchTitle))
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("La clef de la chambre doit être restituée le jour du départ. En cas de perte ou de non restitution, l’hôtel se réserve le droit de vous facturer le montant de 5 000 FCFA.", fontPolicyFrenchText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("The room keycard must be returned upon departure. In the event of loss or non-return, the hotel reserves the right to charge you the amount of 5,000 FCFA.", fontPolicyEnglishText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Article 4 : Nuisances et respect des autres clients / Nuisances and respect for other customers", fontPolicyFrenchTitle))
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Pour le respect et le repos des autres clients, veillez à ne pas claquer les portes ni à faire trop de bruit, particulièrement entre 22h00 et 8h00. Tout bruit de voisinage lié au comportement d’une personne sous sa responsabilité, pourra amener l’hôtelier à inviter le client à quitter l’établissement.", fontPolicyFrenchText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("For the respect of the peaceful rest of other customers, be careful not to slam the doors or make too much noise, especially between 10:00 p.m. and 8:00 a.m. Any neighborhood noise related to the behavior of the guest or any of his visitor, may lead to eviction.", fontPolicyEnglishText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Article 5 : Parking / Use of car park", fontPolicyFrenchTitle))
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Un parking privé en extérieur est proposé à nos clients. Nous déclinons toute responsabilité en cas de perte/vol/dégradation dans l'enceinte du parking.", fontPolicyFrenchText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("A private outdoor parking is available to our customers. We decline all responsibility in the event of loss/theft/damage within the car park.", fontPolicyEnglishText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Article 6 : Acceptation du règlement et conditions générales de vente / Acceptance of terms and conditions", fontPolicyFrenchTitle))
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Le règlement intérieur de l’hôtel s’applique à l’ensemble des réservations. Tout séjour entraîne l’acceptation des conditions particulières et du règlement intérieur de l’hôtel. Le non-respect des dispositions ci-dessus entraîne la résiliation immédiate du contrat.", fontPolicyFrenchText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("These rules are applicable to all reservations. Any stay entails acceptance of the the above motioned conditions and internal rules of the hotel. Failure to comply with the above provisions will result in the immediate termination of the contract.", fontPolicyEnglishText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        '---------------------------------------------------------- signature-------------------------+++++++++++--------------------------------------


        pdfCell03 = New PdfPCell(New Paragraph(Chr(13) & "Signature du client /", pColumn))
        pdfCell03.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph(Chr(13) & "Date / " & GlobalVariable.DateDeTravail.ToShortDateString, pColumn))
        pdfCell03.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)

        Dim CODE_RESERVATION As String = Reservation.Rows(0)("CODE_RESERVATION")
        Dim CHECKIN_PAR As String = ""

        Dim infoSuiviReservation As DataTable = Functions.getElementByCode(CODE_RESERVATION, "suivi_des_reservations", "CODE_RESERVATION")

        If infoSuiviReservation.Rows.Count > 0 Then
            CHECKIN_PAR = infoSuiviReservation.Rows(0)("CHECKIN_PAR")

            Dim infoUser As DataTable = Functions.getElementByCode(CHECKIN_PAR, "utilisateurs", "GRIFFE_UTILISATEUR")

            If infoUser.Rows.Count > 0 Then
                CHECKIN_PAR = infoUser.Rows(0)("NOM_UTILISATEUR")
            End If

        Else
            CHECKIN_PAR = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        End If

        pdfCell03 = New PdfPCell(New Paragraph(Chr(13) & "Enregistré par / ", pColumn))
        pdfCell03.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)


        pdfCell03 = New PdfPCell(New Paragraph("Guest signature : ", fontPolicyEnglishText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)


        pdfCell03 = New PdfPCell(New Paragraph("Date :  ", fontPolicyEnglishText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("Checked in by /", fontPolicyEnglishText))
        pdfCell03.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("", pColumn))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("", pColumn))
        pdfCell03.HorizontalAlignment = Element.ALIGN_JUSTIFIED
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph(CHECKIN_PAR, fontTotal))
        'pdfCell03 = New PdfPCell(New Paragraph("", fontTotal))
        pdfCell03.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell03.Border = 0
        pdfCell03.Colspan = 2
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph(Chr(13) & Chr(13) & "NOUS VOUS SOUHAITONS UN AGRÉABLE SÉJOUR", pColumn))
        pdfCell03.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfCell03 = New PdfPCell(New Paragraph("WE WISH YOU A PLEASANT STAY", pColumnEnlish))
        pdfCell03.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell03.Border = 0
        pdfCell03.Colspan = 6
        pdfTable03.AddCell(pdfCell03)

        pdfDoc.Add(pdfTable03)

        pdfDoc.Close()

        Dim Titre As String = "FICHE DE RENSEIGNEMENT DE " & client

        Dim bodyText As String = "Ci jointe votre fiche de renseignement"

        If WHATSAPP_OU_MAIL = 1 Then

            envoieDocumentMailClient(fichier, Titre, bodyText, Email)

        ElseIf WHATSAPP_OU_MAIL = 0 Then

            Dim nmessageOuDocument As Integer = 1
            Dim typeDeDocument As Integer = 2
            Dim phoneNumber As String = clientInformation.Rows(0)("TELEPHONE")

            Functions.ultrMessage(fichier, nmessageOuDocument, Titre, bodyText, typeDeDocument, phoneNumber)

        End If

    End Sub

    Public Shared Async Sub devisEstimatifDeSalleDeFete(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, ByVal EMAIL As String, ByVal TELEPHONE As String, ByVal WHATSAPP_OU_EMAIL As Integer)

        If Not NumConfirmation = "num" Then

            'Dim dlg As New PrintDialog
            'dlg.ShowDialog()

            Dim societe As DataTable = Functions.allTableFields("societe")

            Dim CODE_MONNAIE As String = ""

            If societe.Rows.Count > 0 Then
                CODE_MONNAIE = societe.Rows(0)("CODE_MONNAIE")
            End If

            Dim titreFichier As String = "DEVIS LOCATION SALLE " & client & (Date.Now().ToString("ddMMyyHHmmss"))

            Dim nomDuDossierRapport As String = "ENVOI\DEVIS"

            Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

            My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

            Dim fichier As String = filePathAndDirectory & "\" & titreFichier & ".pdf"

            Dim clientInformation As DataTable = Functions.getElementByCode(client, "client", "NOM_PRENOM")
            Dim Reservation As DataTable

            Reservation = Functions.getElementByCode(NumConfirmation, "reservation", "CODE_RESERVATION")

            If Not Reservation.Rows.Count > 0 Then
                Reservation = Functions.getElementByCode(NumConfirmation, "reserve_conf", "CODE_RESERVATION")
            End If

            Dim salle As DataTable = Functions.getElementByCode(Codehebergement, "chambre", "CODE_CHAMBRE")

            Dim HEURE_ENTREE As String = ""
            Dim HEURE_DEPART As String = ""

            If Reservation.Rows.Count > 0 Then

                HEURE_ENTREE = CDate(Reservation.Rows(0)("HEURE_ENTREE")).ToLongTimeString
                HEURE_DEPART = CDate(Reservation.Rows(0)("HEURE_SORTIE")).ToLongTimeString

            End If

            Dim forfaitSalle As DataTable = Functions.getElementByCode(NumConfirmation, "forfait_salle", "CODE_RESERVATION")

            Dim EVENEMENT As String = ""
            Dim CODE_EVENEMENT As String = ""

            Dim VIDEO_PROJ As String = "NON"
            Dim SONO As String = "NON"
            Dim COUVERTS As String = "NON"
            Dim TABLE_CHAISE As String = "NON"
            Dim DECORATION As String = "NON"
            Dim LOCATION_MATERIEL As String = "NON"
            Dim MISE_EN_PLACE As Integer = 0 ' U
            Dim DISPOSITION As String = "U"

            If forfaitSalle.Rows.Count > 0 Then

                CODE_EVENEMENT = forfaitSalle.Rows(0)("CODE_EVENEMENT")

                Dim infoSupEvent As DataTable = Functions.getElementByCode(CODE_EVENEMENT, "evenement", "CODE_EVENEMENT")

                If infoSupEvent.Rows.Count > 0 Then

                    EVENEMENT = infoSupEvent.Rows(0)("LIBELLE")

                End If

                If forfaitSalle.Rows(0)("VIDEO_PROJ") = 1 Then
                    VIDEO_PROJ = "OUI"
                End If

                If forfaitSalle.Rows(0)("SONO") = 1 Then
                    SONO = "OUI"
                End If

                If forfaitSalle.Rows(0)("COUVERTS") = 1 Then
                    COUVERTS = "OUI"
                End If

                If forfaitSalle.Rows(0)("TABLE_CHAISE") = 1 Then
                    TABLE_CHAISE = "OUI"
                End If

                If forfaitSalle.Rows(0)("DECORATION") > 0 Then
                    DECORATION = "OUI"
                End If

                If forfaitSalle.Rows(0)("LOCATION_MATERIEL") > 0 Then
                    LOCATION_MATERIEL = "OUI"
                End If

                If MISE_EN_PLACE = 1 Then
                    DISPOSITION = "U"
                ElseIf MISE_EN_PLACE = 2 Then
                    DISPOSITION = "Ecole"
                ElseIf MISE_EN_PLACE = 3 Then
                    DISPOSITION = "Theatre"
                ElseIf MISE_EN_PLACE = 4 Then
                    DISPOSITION = "Rectangle"
                ElseIf MISE_EN_PLACE = 5 Then
                    DISPOSITION = "Cocktail"
                ElseIf MISE_EN_PLACE = 6 Then
                    DISPOSITION = "Banquet"
                End If

            End If

            Dim LIBELLE_CHAMBRE As String = ""
            Dim DEPOT_DE_GARANTIE As Double = 0

            If salle.Rows.Count > 0 Then
                LIBELLE_CHAMBRE = salle.Rows(0)("LIBELLE_CHAMBRE")
            End If


            'Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
            Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
            Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font3 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim HeaderFont As New Font(Font.FontFamily.COURIER, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim fontInfoSup As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            Dim Libelle As String
            Dim LibelleJour As String
            Dim LibelleReservation As String
            Dim TitreDuDocument As String

            If GlobalVariable.typeChambreOuSalle = "salle" Then

                Libelle = "Location de Salle"
                LibelleJour = "Jour"
                LibelleReservation = "DEVIS ESTIMATIF DE LOCATION DE SALLE"
                TitreDuDocument = "DEVIS ESTIMATIF DE LOCATION DE SALLE"

            End If

            pdfWrite.PageEvent = New HeaderFooter()

            pdfDoc.Open()

            '------------------------------------------------------------------------
            Dim pdfCell As PdfPCell = Nothing

            Dim p0 As Paragraph = New Paragraph(Chr(13) & Chr(13) & societe.Rows(0)("VILLE") & ", " & GlobalVariable.DateDeTravail, font1)
            p0.Alignment = Element.ALIGN_RIGHT
            pdfDoc.Add(p0)

            Dim p1 As Paragraph = New Paragraph(TitreDuDocument & Chr(13) & Chr(13), font2)
            p1.Alignment = Element.ALIGN_CENTER
            pdfDoc.Add(p1)

            Dim intro As String = "Nom du client : " & client & Chr(13) & Chr(13)

            pdfDoc.Add(New Paragraph(intro, pColumn))

            Dim p03 As String = "Désignation des locaux à louer : "
            pdfDoc.Add(New Paragraph(p03, pColumn))

            Dim p3 As String = LIBELLE_CHAMBRE & " dont la disposition sera en " & DISPOSITION & " et située à / au " & societe.Rows(0)("RUE") & " - " & societe.Rows(0)("VILLE") & Chr(13) & Chr(13)
            '& " ainsi que ses dépendances qui sont désignées ci-dessous " & Chr(13) & "• Chambre," & Chr(13) & "• Parking, " & Chr(13) & "• Cave, " & Chr(13) & "• Cambuse, " & Chr(13) & "•	 Cuisine, " & Chr(13) & "• Vestiaires, " & Chr(13) & "• Jardin." & Chr(13) & Chr(13)
            pdfDoc.Add(New Paragraph(p3, font1))

            Dim p8 As String = "Durée : "
            pdfDoc.Add(New Paragraph(p8, font2))

            Dim p9 As String = "Du " & DateDebut & " à " & HEURE_ENTREE & " jusqu’au " & DateFin & " à " & HEURE_DEPART & Chr(13) & Chr(13)
            pdfDoc.Add(New Paragraph(p9, font1))

            Dim p4 As String = "Equipements mis à disposition du preneur" & Chr(13) & Chr(13)
            pdfDoc.Add(New Paragraph(p4, font2))

            '----------------------------------------

            Dim pdfTable As New PdfPTable(6) 'Number of columns
            pdfTable.TotalWidth = 530.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {30.0F, 10.0F, 30.0F, 10.0F, 30.0F, 10.0F}

            pdfTable.SetWidths(widths)

            pdfCell = New PdfPCell(New Paragraph("EQUIPEMENT", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("EQUIPEMENT", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("EQUIPEMENT", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DECORATION", font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(DECORATION, font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("LOCATION MATERIEL", font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(LOCATION_MATERIEL, font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.AddCell(pdfCell)


            pdfCell = New PdfPCell(New Paragraph("VIDEO PROJECTEUR", font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(VIDEO_PROJ, font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.AddCell(pdfCell)

            '-----------------------

            pdfCell = New PdfPCell(New Paragraph("SONORISATION", font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(SONO, font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("COUVERTS", font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(COUVERTS, font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("TABLES + CHAISES", font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(TABLE_CHAISE, font1))
            pdfCell.MinimumHeight = 15
            pdfCell.PaddingLeft = 5.0F
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.AddCell(pdfCell)

            pdfDoc.Add(pdfTable)


            Dim p12 As String = "Dévis" & Chr(13) & Chr(13)
            pdfDoc.Add(New Paragraph(p12, font2))

            'PERIODE DU SEJOURS : COUT TOTAL DE LA RESA
            Dim periodeDeLaResa As Integer = DateDiff(DateInterval.Day, Reservation.Rows(0)("DATE_ENTTRE"), Reservation.Rows(0)("DATE_SORTIE"))

            DEPOT_DE_GARANTIE = Reservation.Rows(0)("DEPOT_DE_GARANTIE")
            Dim CODE_RESERVATION = Reservation.Rows(0)("CODE_RESERVATION")
            Dim CAUTION As Double = Reservation.Rows(0)("MONTANT_TOTAL_CAUTION")

            Dim encaissement As Double = 0
            Dim solde As Double = 0

            Dim reglement As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reglement", "CODE_RESERVATION")

            For i = 0 To reglement.Rows.Count - 1
                encaissement += reglement.Rows(i)("MONTANT_VERSE")
            Next

            If periodeDeLaResa = 0 Then
                periodeDeLaResa = 1
            End If

            Dim MONTANT_ACCORDE As Double = Reservation.Rows(0)("MONTANT_ACCORDE")

            solde = MONTANT_ACCORDE * periodeDeLaResa

            solde -= encaissement + DEPOT_DE_GARANTIE

            '---------------------------------------------------------------------------------------------------------------------------

            Dim pdfTable01 As New PdfPTable(5) 'Number of columns
            pdfTable01.TotalWidth = 530.0F
            pdfTable01.LockedWidth = True
            pdfTable01.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfTable01.HeaderRows = 1

            Dim widths01 As Single() = New Single() {10.0F, 70.0F, 15.0F, 20.0F, 20.0F}

            pdfTable01.SetWidths(widths01)

            Dim montantTotal As Double = 0

            pdfCell = New PdfPCell(New Paragraph("No", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DESIGNATION", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("QTE", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("PU", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            '------------------------1----------------------------

            pdfCell = New PdfPCell(New Paragraph("1-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("LOCATION SALLE", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa, "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(MONTANT_ACCORDE, "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * MONTANT_ACCORDE, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += periodeDeLaResa * MONTANT_ACCORDE

            '----------------------------------------------------

            '------------------------2----------------------------

            pdfCell = New PdfPCell(New Paragraph("2-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DECORATION", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("DECORATION"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("DECORATION"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("DECORATION")

            '----------------------------------------------------

            '------------------------3----------------------------

            pdfCell = New PdfPCell(New Paragraph("3-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("LOCATION MATERIEL", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("LOCATION_MATERIEL"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("LOCATION_MATERIEL"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("LOCATION_MATERIEL")

            '----------------------------------------------------

            '------------------------4----------------------------

            pdfCell = New PdfPCell(New Paragraph("4-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DIVERS", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("AUTRES"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("AUTRES"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("AUTRES")

            '----------------------------------------------------

            '------------------------5----------------------------

            pdfCell = New PdfPCell(New Paragraph("5-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("PAUSE CAFE", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE__CAFE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_CAFE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("PU_CAFE") * forfaitSalle.Rows(0)("NBRE__CAFE"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE__CAFE") * forfaitSalle.Rows(0)("PU_CAFE")

            '----------------------------------------------------

            '------------------------6----------------------------

            pdfCell = New PdfPCell(New Paragraph("6-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("PAUSE DEJEUNER", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DEJEUNER"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_DEJEUNER"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DEJEUNER") * forfaitSalle.Rows(0)("PU_DEJEUNER"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DEJEUNER") * forfaitSalle.Rows(0)("PU_DEJEUNER")

            '----------------------------------------------------

            '------------------------7----------------------------

            pdfCell = New PdfPCell(New Paragraph("7-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("PAUSE DINER", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DINER"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_DINER"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DINER") * forfaitSalle.Rows(0)("PU_DINER"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DINER") * forfaitSalle.Rows(0)("PU_DINER")

            '----------------------------------------------------

            '------------------------8----------------------------

            pdfCell = New PdfPCell(New Paragraph("8-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("TRAITEURS", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_TRAITEUR"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_TRAITEUR"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_TRAITEUR") * forfaitSalle.Rows(0)("PU_TRAITEUR"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_TRAITEUR") * forfaitSalle.Rows(0)("PU_TRAITEUR")

            '----------------------------------------------------

            '------------------------9----------------------------

            pdfCell = New PdfPCell(New Paragraph("9-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("GOUTER", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_GOUTER"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_GOUTER"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_GOUTER") * forfaitSalle.Rows(0)("PU_GOUTER"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_GOUTER") * forfaitSalle.Rows(0)("PU_GOUTER")

            '----------------------------------------------------

            '------------------------10----------------------------

            pdfCell = New PdfPCell(New Paragraph("10-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("COCKTAILS", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_COCKTAIL"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_COCKTAIL"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_COCKTAIL") * forfaitSalle.Rows(0)("PU_COCKTAIL"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_COCKTAIL") * forfaitSalle.Rows(0)("PU_COCKTAIL")

            '----------------------------------------------------

            '------------------------11----------------------------

            pdfCell = New PdfPCell(New Paragraph("11-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("EAU PETITE BOUTEILLE", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_PTE_QTE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            If forfaitSalle.Rows(0)("EAU_PTE_QTE") > 0 Then
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("EAU_PTE_MONTANT") / forfaitSalle.Rows(0)("EAU_PTE_QTE")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_PTE_MONTANT"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("EAU_PTE_MONTANT")

            '----------------------------------------------------

            '------------------------12----------------------------

            pdfCell = New PdfPCell(New Paragraph("12-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("EAU GRANDE BOUTEILLE", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_GRDE_QTE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            If forfaitSalle.Rows(0)("EAU_GRDE_QTE") > 0 Then
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("EAU_GRDE_MONTANT") / forfaitSalle.Rows(0)("EAU_GRDE_QTE")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_GRDE_MONTANT"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("EAU_GRDE_MONTANT")

            '----------------------------------------------------

            '------------------------13----------------------------

            pdfCell = New PdfPCell(New Paragraph("13-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BOISSONS GAZEUSES", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            If forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE") > 0 Then
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT") / forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT")

            '----------------------------------------------------

            '------------------------14----------------------------

            pdfCell = New PdfPCell(New Paragraph("14-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BIERES", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BIERES_QTE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            If forfaitSalle.Rows(0)("BIERES_QTE") > 0 Then
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BIERES_MONTANT") / forfaitSalle.Rows(0)("BIERES_QTE")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BIERES_MONTANT"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("BIERES_MONTANT")

            '----------------------------------------------------

            '------------------------15----------------------------

            pdfCell = New PdfPCell(New Paragraph("15-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("VIN ROUGE", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROUGE_QTE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            If forfaitSalle.Rows(0)("VIN_ROUGE_QTE") > 0 Then
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT") / forfaitSalle.Rows(0)("VIN_ROUGE_QTE")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT")

            '----------------------------------------------------
            '------------------------16----------------------------

            pdfCell = New PdfPCell(New Paragraph("16-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("VIN ROSE", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROSE_QTE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            If forfaitSalle.Rows(0)("VIN_ROSE_QTE") > 0 Then
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT") / forfaitSalle.Rows(0)("VIN_ROSE_QTE")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT")

            '----------------------------------------------------
            '------------------------17----------------------------

            pdfCell = New PdfPCell(New Paragraph("17-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BOISSONS EXTERIEURES", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_EXT_QTE"), "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            If forfaitSalle.Rows(0)("BOISSONS_EXT_QTE") > 0 Then
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("VIN_ROSE_MONTANT") / forfaitSalle.Rows(0)("BOISSONS_EXT_QTE")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROSE_MONTANT"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("VIN_ROSE_MONTANT")

            '----------------------------------------------------
            '------------------------18----------------------------

            pdfCell = New PdfPCell(New Paragraph("18-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DROIT DE BOUCHON", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)


            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("DROIT_DE_BOUCHON"), "#,##0"), font1))

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("DROIT_DE_BOUCHON"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("DROIT_DE_BOUCHON")

            '----------------------------------------------------

            '------------------------19----------------------------
            Dim forfaitSalle_hebergement As DataTable = Functions.getElementByCode(NumConfirmation, "forfait_salle_hebergement", "CODE_RESERVATION")

            Dim HEBERGEMENT_PRIS_EN_CHARGE As Double = 0
            Dim NBRE_NUITEE As Double = 0
            Dim ENCAISSEMENT_PRIS_EN_CHARGE As Double = 0

            If forfaitSalle_hebergement.Rows.Count > 0 Then

                HEBERGEMENT_PRIS_EN_CHARGE = forfaitSalle_hebergement.Rows(0)("HEBERGEMENT")
                NBRE_NUITEE = forfaitSalle_hebergement.Rows(0)("NBRE_NUITEE")
                ENCAISSEMENT_PRIS_EN_CHARGE = forfaitSalle_hebergement.Rows(0)("ENCAISSEMENT")


                If HEBERGEMENT_PRIS_EN_CHARGE > 0 Then

                    pdfCell = New PdfPCell(New Paragraph("19-", font1))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable01.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("HEBERGEMENT", font1))
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    pdfTable01.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Format(NBRE_NUITEE, "#,##0"), font1))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable01.AddCell(pdfCell)

                    Dim MONTANT_ACCORDE_PRIS_EN_CHARGE As Double = 0

                    If NBRE_NUITEE > 0 Then
                        MONTANT_ACCORDE_PRIS_EN_CHARGE = HEBERGEMENT_PRIS_EN_CHARGE / NBRE_NUITEE
                    End If

                    pdfCell = New PdfPCell(New Paragraph(Format(MONTANT_ACCORDE_PRIS_EN_CHARGE, "#,##0"), font1))

                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable01.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Format(HEBERGEMENT_PRIS_EN_CHARGE, "#,##0"), pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable01.AddCell(pdfCell)

                End If

                If ENCAISSEMENT_PRIS_EN_CHARGE > 0 Then

                    pdfCell = New PdfPCell(New Paragraph("20-", font1))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable01.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("ENCAISSEMENT", font1))
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    pdfTable01.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable01.AddCell(pdfCell)


                    pdfCell = New PdfPCell(New Paragraph(Format(ENCAISSEMENT_PRIS_EN_CHARGE, "#,##0"), font1))

                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable01.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Format(ENCAISSEMENT_PRIS_EN_CHARGE, "#,##0"), pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable01.AddCell(pdfCell)

                End If

                montantTotal += HEBERGEMENT_PRIS_EN_CHARGE - ENCAISSEMENT_PRIS_EN_CHARGE

            End If
            '----------------------------------------------------
            pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            pdfCell.Colspan = 4
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(montantTotal, "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)
            pdfDoc.Add(pdfTable01)

            Dim p007 As String = Chr(13) & "Arrêter à la somme de : " & Functions.NBLT(montantTotal).ToUpper & " " & societe.Rows(0)("CODE_MONNAIE")
            pdfDoc.Add(New Paragraph(p007, pColumn))

            pdfDoc.Add(pdfCell)

            Dim p07 As String = Chr(13) & "           SIGNATURE DU CLIENT                                                            SIGNATURE DE L'HOTEL          "
            pdfDoc.Add(New Paragraph(p07, pColumn))
            pdfDoc.Add(pdfCell)

            '---------------------------------------------------------------------------------------------------------------------------
            pdfDoc.Close()

            Dim Titre As String = "DEVIS DE LOCATION DE SALLE"

            Dim bodyText As String = "Ci jointe votre dévis de location de salle"

            If WHATSAPP_OU_EMAIL = 1 Then
                envoieDocumentMailClient(fichier, Titre, bodyText, EMAIL)
            Else

                Dim nmessageOuDocument As Integer = 1
                Dim typeDeDocument As Integer = 2
                Dim phoneNumber As String = TELEPHONE

                Functions.ultrMessage(fichier, nmessageOuDocument, titreFichier, bodyText, typeDeDocument, phoneNumber)

            End If

        Else

            MessageBox.Show("Bien vouloir enregistrer la réservation", "Generate PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If


    End Sub

    Public Shared Async Sub GenerationDeConfirmationReservationOldPerfect(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, ByVal email As String, ByVal TELEPHONE As String, ByVal WHATSAPP_OU_EMAIL As Integer)

        Dim societe As DataTable = Functions.allTableFields("societe")

        Dim CODE_MONNAIE As String = ""

        If societe.Rows.Count > 0 Then
            CODE_MONNAIE = societe.Rows(0)("CODE_MONNAIE")
        End If

        Dim titreFichier As String = "CONFIRMATION DE RESERVATION DE " & client

        Dim nomDuDossierRapport As String = "ENVOI\CONFIRMATION DE RESA"

        Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim fichier As String = filePathAndDirectory & "\" & titreFichier & ".pdf"

        'Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
        Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
        Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

        Dim Libelle As String
        Dim LibelleJour As String

        If GlobalVariable.typeChambreOuSalle = "salle" Then
            Libelle = "Location de Salle"
            LibelleJour = "Jour"
        Else
            Libelle = "Hébergement"
            LibelleJour = "nuitée"
        End If

        pdfWrite.PageEvent = New HeaderFooter

        pdfDoc.Open()

        Dim infoSupResa As DataTable = Functions.getElementByCode(NumConfirmation, "reservation", "CODE_RESERVATION")

        If Not infoSupResa.Rows.Count > 0 Then
            infoSupResa = Functions.getElementByCode(NumConfirmation, "reserve_conf", "CODE_RESERVATION")
        End If

        Dim DEPOT_DE_GARANTIE As Double = 0
        Dim CAUTION As Double = 0

        Dim MONTANT_TAXE_DE_SEJOUR As Double = 0

        If infoSupResa.Rows.Count > 0 Then

            DEPOT_DE_GARANTIE = infoSupResa.Rows(0)("DEPOT_DE_GARANTIE")
            CAUTION = infoSupResa.Rows(0)("MONTANT_TOTAL_CAUTION")

            If tarif = 0 Then
                tarif = infoSupResa.Rows(0)("MONTANT_ACCORDE")
            End If

            Dim taxe_sejour As DataTable = Functions.getElementByCode(NumConfirmation, "taxe_sejour_collectee", "NUM_RESERVATION")

            If taxe_sejour.Rows.Count > 0 Then
                MONTANT_TAXE_DE_SEJOUR = taxe_sejour.Rows(0)("TAXE_SEJOUR_COLLECTEE")
            End If

        End If

        Dim p1 As Paragraph = New Paragraph(Chr(13) & Chr(13) & "CONFIRMATION DE RESERVATION" & Chr(13) & "Date:" & Now() & Chr(13) & Chr(13))
        p1.Alignment = Element.ALIGN_CENTER
        pdfDoc.Add(p1)

        Dim intro As String = ""
        'Dim intro As String = "Cher(e) Mr/Mme:" & client & ", Merci d'avoir choisi de séjourner au sein de :  " & societe.Rows(0)("RAISON_SOCIALE") & ". Nous avons le plaisir de confirmer votre réservation comme suit : " & Chr(13) & Chr(13)

        If GlobalVariable.typeChambreOuSalle = "salle" Then
            intro = "Cher(e) Mr/Mme:" & client & ", Merci d'avoir choisi d'organiser votre évènement chez nous ( " & societe.Rows(0)("RAISON_SOCIALE") & "). Nous avons le plaisir de confirmer votre réservation comme suit : " & Chr(13) & Chr(13)
        Else
            intro = "Cher(e) Mr/Mme:" & client & ", Merci d'avoir choisi de séjourner au sein de :  " & societe.Rows(0)("RAISON_SOCIALE") & ". Nous avons le plaisir de confirmer votre réservation comme suit : " & Chr(13) & Chr(13)
        End If

        pdfDoc.Add(New Paragraph(intro, font1))

        Dim MONTANT_HT As Double = Integer.Parse(NbreNuitee) * (Double.Parse(tarif) + MONTANT_TAXE_DE_SEJOUR)

        'Dim termes As String = "• Numéro de confirmation :" & NumConfirmation & Chr(13) & "• Nom du client : " & client & Chr(13) & "• Date d’arrivée : " & DateDebut & Chr(13) & "• Date de départ : " & DateFin & Chr(13) & "• Nombre de " & LibelleJour & " :" & NbreNuitee & Chr(13) & "• " & Libelle & " : " & hebergement & "-" & Codehebergement & Chr(13) & "• Tarif par nuit : " & Format(tarif, "#,##0") & Chr(13) & "• Heure d'enregistrement : " & CDate(HeureEntree).ToLongTimeString & Chr(13) & "• Heure de départ : " & CDate(heureDepart).ToLongTimeString & Chr(13) & " • Total Séjours: " & Format(MONTANT_HT, "#,##0") & " " & CODE_MONNAIE & Chr(13)

        Dim termes As String = ""

        If GlobalVariable.typeChambreOuSalle = "salle" Then
            termes = "• Numéro de confirmation :" & NumConfirmation & Chr(13) & "• Nom du client : " & client & Chr(13) & "• Date d’arrivée : " & DateDebut & Chr(13) & "• Date de départ : " & DateFin & Chr(13) & "• Nombre de " & LibelleJour & " :" & NbreNuitee & Chr(13) & "• " & Libelle & " : " & hebergement & "-" & Codehebergement & Chr(13) & "• Tarif par jour : " & Format(tarif + MONTANT_TAXE_DE_SEJOUR, "#,##0") & Chr(13) & "• Heure d'arrivée : " & CDate(HeureEntree).ToLongTimeString & Chr(13) & "• Heure de départ : " & CDate(heureDepart).ToLongTimeString & Chr(13) & "• Total : " & Format(MONTANT_HT, "#,##0") & " " & CODE_MONNAIE & Chr(13) & "• Caution : " & Format(CAUTION, "#,##0") & " " & CODE_MONNAIE & Chr(13) & "• Dépot de garantie : " & Format(DEPOT_DE_GARANTIE, "#,##0") & " " & CODE_MONNAIE & Chr(13)
        Else
            'termes = "• Numéro de confirmation :" & NumConfirmation & Chr(13) & "• Nom du client : " & client & Chr(13) & "• Date d’arrivée : " & DateDebut & Chr(13) & "• Date de départ : " & DateFin & Chr(13) & "• Nombre de " & LibelleJour & " :" & NbreNuitee & Chr(13) & "• " & Libelle & " : " & hebergement & "-" & Codehebergement & Chr(13) & "• Tarif par nuit : " & Format(tarif + MONTANT_TAXE_DE_SEJOUR, "#,##0") & Chr(13) & "• Heure d'arrivée : " & CDate(HeureEntree).ToLongTimeString & Chr(13) & "• Heure de départ : " & CDate(heureDepart).ToLongTimeString & Chr(13) & "• Total : " & Format(MONTANT_HT, "#,##0") & " " & CODE_MONNAIE & Chr(13)
            termes = "• Numéro de confirmation : " & NumConfirmation & Chr(13) & "• Nom du client : " & client & Chr(13) & "• Date d’arrivée : " & DateDebut & Chr(13) & "• Date de départ : " & DateFin & Chr(13) & "• Nombre de " & LibelleJour & " :" & NbreNuitee & Chr(13) & "• " & Libelle & " : " & hebergement & " - " & Codehebergement & Chr(13) & "• Tarif par nuit : " & Format(tarif, "#,##0") & " " & CODE_MONNAIE & Chr(13) & "• Taxe de séjour applicable par nuit : " & Format(MONTANT_TAXE_DE_SEJOUR, "#,##0") & " " & CODE_MONNAIE & Chr(13) & "• Heure d'arrivée : " & CDate(HeureEntree).ToLongTimeString & Chr(13) & "• Heure de départ : " & CDate(heureDepart).ToLongTimeString & Chr(13) & "• Total du séjour : " & Format(MONTANT_HT, "#,##0") & " " & CODE_MONNAIE & Chr(13)
        End If

        pdfDoc.Add(New Paragraph(termes, font1))

        Dim info1Header As String = "INFORMATION PRATIQUE" & Chr(13)
        Dim p2 As Paragraph = New Paragraph(info1Header, font2)
        p2.Alignment = Element.ALIGN_CENTER
        pdfDoc.Add(p2)

        Dim info1 As String = societe.Rows(0)("RAISON_SOCIALE") & " fera selon ses efforts commerciaux raisonnables pour répondre à tous vos besoins particuliers. Si vous avez des exigences spécifiques que vous souhaitez que nous considérions, veuillez nous contacter dans les plus brefs délais." & Chr(13) & Chr(13)
        pdfDoc.Add(New Paragraph(info1, font1))

        Dim info2Header As String = "CONDITION DE VENTE" & Chr(13)
        Dim p3 As Paragraph = New Paragraph(info2Header, font2)
        p3.Alignment = Element.ALIGN_CENTER
        pdfDoc.Add(p3)

        Dim info2 As String = "Le tarif par nuit indiqué s’entend par logement (chambre), pour le nombre de personnes et la/les date(s) préalablement sélectionnées, sauf indication contraire (forfaits). Cependant, vous devrez payer la taxe de séjour supplémentaires à votre arrivée à l'hôtel" & Chr(13) & Chr(13)
        pdfDoc.Add(New Paragraph(info2, font1))

        Dim info3Header As String = "POLITIQUE DE RÉSERVATION" & Chr(13)
        Dim p4 As Paragraph = New Paragraph(info3Header, font2)
        p4.Alignment = Element.ALIGN_CENTER
        pdfDoc.Add(p4)

        Dim info3 As String = "Politique de garantie : Toutes les réservations doivent être garanties par un règlement équivalent au tarif de la première nuit, plus taxes applicables au moment de la réservation. Ceci ne concerne pas les réservations non-remboursables, pour lesquelles la totalité du prépaiement est conservé." & Chr(13) & Chr(13)

        pdfDoc.Add(New Paragraph(info3, font1))

        Dim info4 As String = "Politique d’annulation : Vous pouvez annuler votre réservation sans pénalité jusqu'à 24 heures ou plus avant le jour de votre arrivée (heure locale), sauf si autrement spécifié sur votre réservation. Si vous annulez après cette période, veuillez noter que des frais d'annulation équivalent à la première nuit, plus taxes applicables seront appliqués et possiblement certains frais additionnels." & Chr(13) & Chr(13)

        pdfDoc.Add(New Paragraph(info4, font1))

        Dim info5 As String = "Politique enfants : Hébergement gratuit pour les enfants de moins de 12 ans partageant la chambre de leurs parents, dans la limite du nombre maximum de personnes par type de chambre autorisé. Le nombre d'enfants doit être indiqué lors de la réservation." & Chr(13)

        pdfDoc.Add(New Paragraph(info5, font1))

        Dim info6 As String = "Nous nous réjouissons sincèrement d’avance d'avoir le plaisir de vous accueillir."

        pdfDoc.Add(New Paragraph(info6, font1))

        pdfDoc.Close()

        Dim Titre As String = "FICHE DE CONFIRMATION DE RESERVATION"

        Dim bodyText As String = "Ci jointe votre fiche de confirmation de reservation"

        If WHATSAPP_OU_EMAIL = 1 Then
            envoieDocumentMailClient(fichier, Titre, bodyText, email)
        ElseIf WHATSAPP_OU_EMAIL = 0 Then

            Dim nmessageOuDocument As Integer = 1
            Dim typeDeDocument As Integer = 2
            Dim phoneNumber As String = TELEPHONE

            Functions.ultrMessage(fichier, nmessageOuDocument, Titre, bodyText, typeDeDocument, phoneNumber)

        End If

    End Sub

    Public Shared Async Sub GenerationDeConfirmationReservation(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, ByVal email As String, ByVal TELEPHONE As String, ByVal WHATSAPP_OU_EMAIL As Integer)

        'DEFINITION DES TROIS TABLES

        ' ----------------------------------------- TWO TABLES INTO A MAIN TABLE --------------------------------------------------
        Dim mtable As PdfPTable = New PdfPTable(2)
        mtable.WidthPercentage = 100
        mtable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

        Dim tableRight As PdfPTable = New PdfPTable(1)
        tableRight.WidthPercentage = 100
        tableRight.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

        Dim tableLeft As PdfPTable = New PdfPTable(1)
        tableLeft.WidthPercentage = 100
        tableLeft.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

        Dim pdfCell As PdfPCell = Nothing

        Dim societe As DataTable = Functions.allTableFields("societe")

        Dim CODE_MONNAIE As String = ""

        If societe.Rows.Count > 0 Then
            CODE_MONNAIE = societe.Rows(0)("CODE_MONNAIE")
        End If

        Dim titreFichier As String = "CONFIRMATION DE RESERVATION DE " & client & " " & Now().ToString("ddMMyyHms")
        Dim nomDuDossierRapport As String = "ENVOI\CONFIRMATION DE RESA"

        Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")
        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim fichier As String = filePathAndDirectory & "\" & titreFichier & ".pdf"
        '-------------- START NEW -----------------------------------------

        'Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
        Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
        Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

        Dim Libelle As String = ""
        Dim LibelleJour As String = ""
        Dim libelleMontant As String = ""
        Dim nombreDeMois As Integer = 0
        Dim libelleNombreDeMois As String = ""

        pdfWrite.PageEvent = New HeaderFooter

        pdfDoc.Open()

        Dim infoSupResa As DataTable = Functions.getElementByCode(NumConfirmation, "reservation", "CODE_RESERVATION")

        If Not infoSupResa.Rows.Count > 0 Then
            infoSupResa = Functions.getElementByCode(NumConfirmation, "reserve_conf", "CODE_RESERVATION")
        End If

            Dim DEPOT_DE_GARANTIE As Double = 0
            Dim CAUTION As Double = 0
            Dim PAX As Integer = 1
            Dim MENSUEL As Integer = 0

            If infoSupResa.Rows.Count > 0 Then
                DEPOT_DE_GARANTIE = infoSupResa.Rows(0)("DEPOT_DE_GARANTIE")
                CAUTION = infoSupResa.Rows(0)("MONTANT_TOTAL_CAUTION")
                PAX = infoSupResa.Rows(0)("NB_PERSONNES")
                MENSUEL = infoSupResa.Rows(0)("MENSUEL")
            End If

        If GlobalVariable.typeChambreOuSalle = "salle" Then

            Libelle = "Type Salle :"
            LibelleJour = "Jour(s) :"
            libelleMontant = "Montant Location :"

        Else

            If MENSUEL = 0 Then
                Libelle = "Type Chambre :"
                LibelleJour = "Nuitée(s) : "
                libelleMontant = "Tarif TTC"
            Else
                Libelle = "Type Logement :"
                LibelleJour = "Jour(s) :"
                libelleMontant = "Loyer Mensuel :"
            End If

        End If

        Dim intro As String = ""

            Dim MONTANT_TAXE_DE_SEJOUR As Double = 0

            Dim taxe_sejour As DataTable = Functions.getElementByCode(NumConfirmation, "taxe_sejour_collectee", "NUM_RESERVATION")

            If taxe_sejour.Rows.Count > 0 Then
                MONTANT_TAXE_DE_SEJOUR = taxe_sejour.Rows(0)("TAXE_SEJOUR_COLLECTEE")
            End If

            Dim MONTANT_HT As Double = Integer.Parse(NbreNuitee) * (Double.Parse(tarif) + MONTANT_TAXE_DE_SEJOUR)

            If MENSUEL = 1 Then
                MONTANT_HT = (Double.Parse(tarif) + MONTANT_TAXE_DE_SEJOUR)
            End If

            Dim termes As String = ""

        '0-TOP INFORMATION
        Dim p0 As Paragraph = New Paragraph(Chr(13) & Chr(13) & "CONFIRMATION DE RESERVATION No " & NumConfirmation & Chr(13), pColumn)
        p0.Alignment = Element.ALIGN_CENTER
            pdfDoc.Add(p0)

        Dim p1 As Paragraph = New Paragraph(Chr(13) & "Nous avons le plaisir de confirmer votre réservation No " & NumConfirmation & Chr(13) & Chr(13), font1)
        p1.Alignment = Element.ALIGN_CENTER
            pdfDoc.Add(p1)

            '1-LEFT TABLE ---------------------------------------------------------------
            '1.1- INFORMATION DU CLIENT

            Dim MONTANT_NAVETTE As Double = GlobalVariable.AgenceActuelle.Rows(0)("MONTANT_NAVETTE")
            Dim DIRECTION As String = GlobalVariable.AgenceActuelle.Rows(0)("DIRECTION")

            Dim infoSupClient As DataTable = Functions.getElementByCode(client, "client", "NOM_PRENOM")
            Dim nom As String = ""
            Dim prenom As String = ""
            Dim adresse As String = ""
        Dim tel As String = ""
        Dim mode_reglement As String = "-"
            Dim civilite As String = ""
            Dim clientAdditionnel As Integer = 0

        If infoSupClient.Rows.Count > 0 Then
            nom = Trim(infoSupClient.Rows(0)("NOM_CLIENT"))
            prenom = Trim(infoSupClient.Rows(0)("PRENOMS"))
            adresse = Trim(infoSupClient.Rows(0)("ADRESSE"))
            tel = Trim(infoSupClient.Rows(0)("TELEPHONE"))
            email = Trim(infoSupClient.Rows(0)("EMAIL"))
            If Not IsDBNull(infoSupClient.Rows(0)("CODE_MODE_PAIEMENT")) Then
                mode_reglement = infoSupClient.Rows(0)("CODE_MODE_PAIEMENT")
            End If
            civilite = infoSupClient.Rows(0)("CIVILITE")
        End If

        Dim tL1 As PdfPTable = New PdfPTable(2)
            tL1.WidthPercentage = 100
            pdfCell = New PdfPCell(New Paragraph("Information du client", pColumn))
            pdfCell.Border = 0
            pdfCell.BorderWidthBottom = 1
            pdfCell.Colspan = 2
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tL1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Nom : ", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tL1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(civilite & " " & nom, font1))
            pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Prénom : ", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tL1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(prenom, font1))
            pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Adresse :", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tL1.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(adresse, font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.Border = 0
        tL1.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("Email :", font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL1.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(email, font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.Border = 0
        tL1.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("Tel :", font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL1.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(tel, font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.Border = 0
        tL1.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Chr(13) & "Client additionnel", font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL1.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Chr(13) & clientAdditionnel, font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.Border = 0
        tL1.AddCell(pdfCell)

        tableLeft.AddCell(tL1)

        Dim tL2 As PdfPTable = New PdfPTable(1)
        tL2.WidthPercentage = 100

        pdfCell = New PdfPCell(New Paragraph(Chr(12) & "Garantie", pColumn))
        pdfCell.Border = 0
        pdfCell.BorderWidthBottom = 1
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL2.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Chr(13) & "Sans dépôt de garantie, cette réservation est valable jusqu’à 18h00 le jour d’arrivée." & Chr(13), font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL2.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Chr(13) & "Si la chambre est garantie, votre réservation est maintenue en cas d'arrivée après 18h00 également toute la nuit. Sont considérés comme garanties pour une réservation de chambre : " & Chr(13) & "•	Une carte de crédit (Visa ou Mastercard) " & Chr(13) & "•	Le prépaiement d'une nuitée, en espèce ou par virement bancaire." & Chr(13), font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL2.AddCell(pdfCell)

        tableLeft.AddCell(tL2)

        Dim tL3 As PdfPTable = New PdfPTable(1)
        tL3.WidthPercentage = 100

        pdfCell = New PdfPCell(New Paragraph(Chr(12) & "Annulation", pColumn))
        pdfCell.Border = 0
        pdfCell.BorderWidthBottom = 1
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL3.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Chr(13) & "Cette réservation devra être annulée au plus tard à 23h59, la veille de l'arrivée afin d'éviter les pénalités d'annulation ou de non présentation." & Chr(13), font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL3.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Chr(13) & "A l'enregistrement la réception vérifiera les informations relatives à votre séjour. Le tarif offert est fonction de votre date d'arrivée et de la durée de votre séjour. Un départ anticipé ou un séjour prolongé pourra entrainer une modification du tarif." & Chr(13), font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL3.AddCell(pdfCell)

        tableLeft.AddCell(tL3)

        Dim tL4 As PdfPTable = New PdfPTable(1)
        tL4.WidthPercentage = 100

        pdfCell = New PdfPCell(New Paragraph(Chr(12) & "Direction", pColumn))
        pdfCell.Border = 0
        pdfCell.BorderWidthBottom = 1
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL4.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Chr(12) & DIRECTION, font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL4.AddCell(pdfCell)

        tableLeft.AddCell(tL4)

        '-------------------------------------------------------------------------------------

        Dim tL5 As PdfPTable = New PdfPTable(1)
        tL5.WidthPercentage = 100

        pdfCell = New PdfPCell(New Paragraph("", pColumn))
        pdfCell.Border = 0
        pdfCell.BorderWidthBottom = 1
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        tL5.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("La Direction", pColumn))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        tL5.AddCell(pdfCell)

        Dim img() As Byte
        img = GlobalVariable.AgenceActuelle.Rows(0)("CACHET")

        Dim mStream As New MemoryStream(img)
        Dim cachet As Image
        cachet = Image.GetInstance(img)
        cachet.ScalePercent(10.0F)

        pdfCell = New PdfPCell(New Paragraph(Chr(13) & Chr(13) & "", pColumn))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        tL5.AddCell(pdfCell)

        pdfCell = New PdfPCell(cachet)
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        tL5.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Chr(12) & "Date :" & Now() & Chr(13), font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tL5.AddCell(pdfCell)

        tableLeft.AddCell(tL5)

        '2- RIGHT TABLE -------------------------------------------------------------

        Dim tR1 As PdfPTable = New PdfPTable(2)
            tR1.WidthPercentage = 100

            pdfCell = New PdfPCell(New Paragraph("Votre séjour", pColumn))
            pdfCell.Border = 0
            pdfCell.BorderWidthBottom = 1
            pdfCell.Colspan = 2
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Arrivé : ", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(DateDebut & " à " & CDate(HeureEntree).ToLongTimeString, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Départ : ", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(DateFin & " à " & CDate(heureDepart).ToLongTimeString, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Nombre de pers. : ", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(PAX, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Libelle, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(hebergement, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(LibelleJour, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(NbreNuitee, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(libelleMontant, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(tarif, "#,##0") & " " & CODE_MONNAIE, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Taxe de séjour ", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(MONTANT_TAXE_DE_SEJOUR, "#,##0") & " " & CODE_MONNAIE, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Chr(13) & "Total du séjour TTC ", pColumn))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Chr(13) & Format(MONTANT_HT, "#,##0") & " " & CODE_MONNAIE, pColumn))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Chr(13) & "Pour vos futurs séjours, les réservations sont possibles sur les sites www.hotelsoft.cm ou nous vous garantissons le meilleur tarif disponible. Aucun frais de réservation ne sera perçu. Le règlement de l'ensemble ou du solde des prestations se fera directement auprès de l'hôtel" & Chr(13) & Chr(13), font1))
            pdfCell.Border = 0
            pdfCell.Colspan = 2
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        tR1.AddCell(pdfCell)

        tableRight.AddCell(tR1)

            Dim tR2 As PdfPTable = New PdfPTable(1)
            tR2.WidthPercentage = 100

            pdfCell = New PdfPCell(New Paragraph(Chr(13) & "Modalité", pColumn))
            pdfCell.Border = 0
            pdfCell.BorderWidthBottom = 1
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR2.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Chr(13) & "L'heure de départ est fixée à 12h minimum." & Chr(13) & "L'occupation prolongée de la chambre jusqu'à 16h entrainera la facturation de 50% du tarif appliqué et au-delà de 16h, la nuitée complète." & Chr(13), font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR2.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Chr(13) & "Les enregistrements commencent à partir de 14h." & Chr(13) & "Les arrivées matinales ne sont pas garanties." & Chr(13) & "A la demande, elles seront facturées à 100% du tarif confirmé avant 8h30 et à 50% pour une arrivée entre 8h30 et 12h." & Chr(13), font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR2.AddCell(pdfCell)

            tableRight.AddCell(tR2)

            Dim tR3 As PdfPTable = New PdfPTable(1)
            tR3.WidthPercentage = 100

            pdfCell = New PdfPCell(New Paragraph(Chr(12) & "Transport", pColumn))
            pdfCell.Border = 0
            pdfCell.BorderWidthBottom = 1
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR3.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Chr(13) & GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE") & " " & GlobalVariable.AgenceActuelle.Rows(0)("VILLE") & " offre une navette pour les transferts aéroport. " & Chr(13) & " Les transferts aéroport sont facturés à " & MONTANT_NAVETTE & " " & CODE_MONNAIE & " par personne entre (18h-08h)", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR3.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Chr(13) & "L'hôtel a également la possibilité de vous mettre en contact direct avec un service de taxis sécurisés " & Chr(13), font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR3.AddCell(pdfCell)

            tableRight.AddCell(tR3)

            mtable.AddCell(tableLeft)

            mtable.AddCell(tableRight)

            pdfDoc.Add(mtable)

            '-------------- END NEW -------------------------------------------

            pdfDoc.Close()

        Dim Titre As String = "FICHE DE CONFIRMATION DE RESERVATION"

        Dim bodyText As String = "Ci jointe votre fiche de confirmation de reservation"

        If WHATSAPP_OU_EMAIL = 1 Then
            envoieDocumentMailClient(fichier, Titre, bodyText, email)
        ElseIf WHATSAPP_OU_EMAIL = 0 Then

            Dim nmessageOuDocument As Integer = 1
            Dim typeDeDocument As Integer = 2
            Dim phoneNumber As String = TELEPHONE

            Functions.ultrMessage(fichier, nmessageOuDocument, Titre, bodyText, typeDeDocument, phoneNumber)

        End If

    End Sub

    Public Shared Async Sub envoieDocumentMailClient(ByVal fichier As String, ByVal Titre As String, ByVal bodyText As String, ByVal Email As String)

        Dim haveInternet As Boolean = Functions.checkInternetCOnnection()

        If haveInternet Then

            Try
                'ENVOI DES RAPPORTS PAR MAIL

                If Not Trim(Email).Equals("") Then

                    Dim emailTo As String = Email
                    Dim emailFrom As String = "rapport@hotelsoft.cm"

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
                    'SmtpServer.Credentials = New System.Net.NetworkCredential("kamdemlandrygaetan@gmail.com", "2Klg16051990")
                    SmtpServer.Credentials = New System.Net.NetworkCredential("rapport@hotelsoft.cm", "H@telsoft2022")
                    'SmtpServer.UseDefaultCredentials = True
                    SmtpServer.EnableSsl = False

                    SmtpServer.Send(mail)

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Envoi de mail", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try

        Else

            Functions.noInternetMessage()

        End If

    End Sub

    Public Shared Async Sub contratDeLocationDeSalleDeFete(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, ByVal emaiL As String, ByVal TELEPHONE As String, ByVal WHATSAPP_OU_MAIL As Integer)

        Dim titreFichier As String = "CONTRAT DE LOCATION DE SALLE DE " & client

        Dim nomDuDossierRapport As String = "ENVOI\CONTRAT"

        Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim fichier As String = filePathAndDirectory & "\" & titreFichier & ".pdf"

        Dim societe As DataTable = Functions.allTableFields("societe")
        Dim clientInformation As DataTable = Functions.getElementByCode(client, "client", "NOM_PRENOM")
        Dim Reservation As DataTable

        Reservation = Functions.getElementByCode(NumConfirmation, "reservation", "CODE_RESERVATION")

        If Not Reservation.Rows.Count > 0 Then
            Reservation = Functions.getElementByCode(NumConfirmation, "reserve_conf", "CODE_RESERVATION")
        End If

        Dim salle As DataTable = Functions.getElementByCode(Codehebergement, "chambre", "CODE_CHAMBRE")

        Dim HEURE_ENTREE As String = ""
        Dim HEURE_DEPART As String = ""

        If Reservation.Rows.Count > 0 Then
            HEURE_ENTREE = CDate(Reservation.Rows(0)("HEURE_ENTREE")).ToLongTimeString
            HEURE_DEPART = CDate(Reservation.Rows(0)("HEURE_SORTIE")).ToLongTimeString
            If tarif = 0 Then
                tarif = Reservation.Rows(0)("MONTANT_ACCORDE")
            End If
        End If

        Dim forfaitSalle As DataTable = Functions.getElementByCode(NumConfirmation, "forfait_salle", "CODE_RESERVATION")

        Dim EVENEMENT As String = ""
        Dim CODE_EVENEMENT As String = ""

        Dim VIDEO_PROJ As String = "NON"
        Dim SONO As String = "NON"
        Dim COUVERTS As String = "NON"
        Dim TABLE_CHAISE As String = "NON"
        Dim DECORATION As String = "NON"
        Dim LOCATION_MATERIEL As String = "NON"
        Dim MISE_EN_PLACE As Integer = 0 ' U
        Dim DISPOSITION As String = "U"

        If forfaitSalle.Rows.Count > 0 Then

            CODE_EVENEMENT = forfaitSalle.Rows(0)("CODE_EVENEMENT")

            Dim infoSupEvent As DataTable = Functions.getElementByCode(CODE_EVENEMENT, "evenement", "CODE_EVENEMENT")

            If infoSupEvent.Rows.Count > 0 Then

                EVENEMENT = infoSupEvent.Rows(0)("LIBELLE")

            End If

            If forfaitSalle.Rows(0)("VIDEO_PROJ") = 1 Then
                VIDEO_PROJ = "OUI"
            End If

            If forfaitSalle.Rows(0)("SONO") = 1 Then
                SONO = "OUI"
            End If

            If forfaitSalle.Rows(0)("COUVERTS") = 1 Then
                COUVERTS = "OUI"
            End If

            If forfaitSalle.Rows(0)("TABLE_CHAISE") = 1 Then
                TABLE_CHAISE = "OUI"
            End If

            If forfaitSalle.Rows(0)("DECORATION") > 0 Then
                DECORATION = "OUI"
            End If

            If forfaitSalle.Rows(0)("LOCATION_MATERIEL") > 0 Then
                LOCATION_MATERIEL = "OUI"
            End If

            If MISE_EN_PLACE = 1 Then
                DISPOSITION = "U"
            ElseIf MISE_EN_PLACE = 2 Then
                DISPOSITION = "Ecole"
            ElseIf MISE_EN_PLACE = 3 Then
                DISPOSITION = "Theatre"
            ElseIf MISE_EN_PLACE = 4 Then
                DISPOSITION = "Rectangle"
            ElseIf MISE_EN_PLACE = 5 Then
                DISPOSITION = "Cocktail"
            ElseIf MISE_EN_PLACE = 6 Then
                DISPOSITION = "Banquet"
            End If

        End If

        Dim LIBELLE_CHAMBRE As String = ""
        Dim DEPOT_DE_GARANTIE As Double = 0

        If salle.Rows.Count > 0 Then
            LIBELLE_CHAMBRE = salle.Rows(0)("LIBELLE_CHAMBRE")
        End If

        Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
        Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font3 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim HeaderFont As New Font(Font.FontFamily.COURIER, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim fontInfoSup As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        Dim Libelle As String
        Dim LibelleJour As String
        Dim LibelleReservation As String
        Dim TitreDuDocument As String

        If GlobalVariable.typeChambreOuSalle = "salle" Then

            Libelle = "Location de Salle"
            LibelleJour = "Jour"
            LibelleReservation = "CONTRAT DE LOCATION DE SALLE"
            TitreDuDocument = "CONTRAT DE LOCATION DE SALLE"

        End If

        pdfWrite.PageEvent = New HeaderFooter()

        pdfDoc.Open()

        '------------------------------------------------------------------------
        Dim pdfCell As PdfPCell = Nothing

        Dim p0 As Paragraph = New Paragraph(Chr(13) & Chr(13) & societe.Rows(0)("VILLE") & ", " & GlobalVariable.DateDeTravail, font1)
        p0.Alignment = Element.ALIGN_RIGHT
        pdfDoc.Add(p0)

        Dim p1 As Paragraph = New Paragraph(Chr(13) & TitreDuDocument & Chr(13) & Chr(13), font2)
        p1.Alignment = Element.ALIGN_CENTER
        pdfDoc.Add(p1)

        Dim intro As String = "Entre les soussignés : " & Chr(13) & societe.Rows(0)("RAISON_SOCIALE") & ". Ci-après désigné « le bailleur » " & Chr(13) & " ET " & Chr(13) & client & ". Ci-après désigné « Le preneur » ; " & Chr(13) & " Il a été arrêté et convenu ce qui suit : " & Chr(13) & Chr(13)

        pdfDoc.Add(New Paragraph(intro, font1))

        Dim p2 As String = "Article 1 : Désignation des locaux loués"
        pdfDoc.Add(New Paragraph(p2, font2))

        Dim p3 As String = "Le présent contrat concerne la salle dénommée " & LIBELLE_CHAMBRE & " dont la disposition sera en " & DISPOSITION & " et située à / au " & societe.Rows(0)("RUE") & " - " & societe.Rows(0)("VILLE") & Chr(13) & Chr(13)
        '& " ainsi que ses dépendances qui sont désignées ci-dessous " & Chr(13) & "• Chambre," & Chr(13) & "• Parking, " & Chr(13) & "• Cave, " & Chr(13) & "• Cambuse, " & Chr(13) & "•	 Cuisine, " & Chr(13) & "• Vestiaires, " & Chr(13) & "• Jardin." & Chr(13) & Chr(13)
        pdfDoc.Add(New Paragraph(p3, font1))

        Dim p4 As String = "Article 2 : Equipements mis à disposition du preneur" & Chr(13) & Chr(13)
        pdfDoc.Add(New Paragraph(p4, font2))

        '----------------------------------------

        Dim pdfTable As New PdfPTable(6) 'Number of columns
        pdfTable.TotalWidth = 530.0F
        pdfTable.LockedWidth = True
        pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfTable.HeaderRows = 1

        Dim widths As Single() = New Single() {30.0F, 10.0F, 30.0F, 10.0F, 30.0F, 10.0F}

        pdfTable.SetWidths(widths)

        pdfCell = New PdfPCell(New Paragraph("EQUIPEMENT", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("EQUIPEMENT", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("EQUIPEMENT", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("DECORATION", font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(DECORATION, font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("LOCATION MATERIEL", font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(LOCATION_MATERIEL, font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfTable.AddCell(pdfCell)


        pdfCell = New PdfPCell(New Paragraph("VIDEO PROJECTEUR", font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(VIDEO_PROJ, font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfTable.AddCell(pdfCell)

        '-----------------------

        pdfCell = New PdfPCell(New Paragraph("SONORISATION", font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(SONO, font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("COUVERTS", font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(COUVERTS, font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("TABLES + CHAISES", font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(TABLE_CHAISE, font1))
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfTable.AddCell(pdfCell)

        pdfDoc.Add(pdfTable)

        '----------------------------------------

        'Dim p5 As String = "L’équipement de base mis à disposition se compose de : " & Chr(13) & "• Tables ," & Chr(13) & "• Parking, " & Chr(13) & "• Nappes, " & Chr(13) & "• Couverts, " & Chr(13) & "•	 Serviettes de tables , " & Chr(13) & "•  Chaises, " & Chr(13) & "• Vidéo-projecteur," & Chr(13) & "• 	  Sonorisation, " & Chr(13) & "•  DJ" & Chr(13) & "Ce matériel devra être restitué en parfait état de propreté et de fonctionnement. Un inventaire de ce matériel sera effectué lors des états des lieux qui seront dressés à l’entrée et à la sortie de la salle. " & Chr(13) & " Toutes autres fournitures sont à la charge du preneur." & Chr(13) & Chr(13)
        'pdfDoc.Add(New Paragraph(p5, font1))

        Dim p6 As String = Chr(13) & "Article 3 : Utilisation de la salle louée"
        pdfDoc.Add(New Paragraph(p6, font2))

        Dim p7 As String = "Le preneur loue la salle pour organiser : " & EVENEMENT & Chr(13) & Chr(13)
        pdfDoc.Add(New Paragraph(p7, font1))

        Dim p8 As String = "Article 4 : Début et fin du contrat de location"
        pdfDoc.Add(New Paragraph(p8, font2))

        Dim p9 As String = "Le preneur loue la salle à partir du " & DateDebut & " à " & HEURE_ENTREE & " jusqu’au " & DateFin & " à " & HEURE_DEPART & " Afin que l’état des lieux d’entrée puisse être dressé, il s’engage à se présenter le jour du début de la location. " & Chr(13) & " À la fin de location, le preneur devra restituer la salle à l’heure prévue. Il devra rester le temps nécessaire pour permettre l’établissement de l’état des lieux de sortie. " & Chr(13) & Chr(13)
        pdfDoc.Add(New Paragraph(p9, font1))

        Dim p10 As String = "Article 5 : Obligations du bailleur"
        pdfDoc.Add(New Paragraph(p10, font2))

        Dim p11 As String = "Le bailleur est tenu de mettre le local à la disposition du preneur à la date et à l’heure convenues pour le début de la location. Il est précisé qu’en cas d’accident ou d’incendie, sa responsabilité ne sera engagée que s’il n’y a pas plus de " & Reservation.Rows(0)("NB_PERSONNES") & " personnes présentes lors de l’événement organisé par le preneur."
        pdfDoc.Add(New Paragraph(p11, font1))

        pdfDoc.NewPage()

        Dim p12 As String = "Article 6 : Obligations du preneur"
        pdfDoc.Add(New Paragraph(p12, font2))

        'PERIODE DU SEJOURS : COUT TOTAL DE LA RESA
        Dim periodeDeLaResa As Integer = DateDiff(DateInterval.Day, Reservation.Rows(0)("DATE_ENTTRE"), Reservation.Rows(0)("DATE_SORTIE"))

        DEPOT_DE_GARANTIE = Reservation.Rows(0)("DEPOT_DE_GARANTIE")
        Dim CODE_RESERVATION = Reservation.Rows(0)("CODE_RESERVATION")
        Dim CAUTION As Double = Reservation.Rows(0)("MONTANT_TOTAL_CAUTION")

        Dim encaissement As Double = 0
        Dim solde As Double = 0

        Dim reglement As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reglement", "CODE_RESERVATION")

        For i = 0 To reglement.Rows.Count - 1
            encaissement += reglement.Rows(i)("MONTANT_VERSE")
        Next

        If periodeDeLaResa = 0 Then
            periodeDeLaResa = 1
        End If

        Dim MONTANT_ACCORDE As Double = Reservation.Rows(0)("MONTANT_ACCORDE")

        solde = MONTANT_ACCORDE * periodeDeLaResa

        solde -= encaissement + DEPOT_DE_GARANTIE

        Dim p013 As String = "Le preneur à : " & Chr(13) & "• Payer les arrhes, soit " & Format(CAUTION, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE") & " et le dépôt de garantie, soit " & Format(DEPOT_DE_GARANTIE, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE") & " lors de la signature du présent contrat; " & Chr(13)
        '& "• Payer le solde du, soit " & Format(solde, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE") & " au plus tard le " & DateDebut & " ;" & Chr(13) & Chr(13)
        pdfDoc.Add(New Paragraph(p013, font1))

        Dim p13 As String = "• Le preneur s’engage à Payer : " & Chr(13) & Chr(13)
        pdfDoc.Add(New Paragraph(p13, font1))

        '---------------------------------------------------------------------------------------------------------------------------

        Dim pdfTable01 As New PdfPTable(5) 'Number of columns
        pdfTable01.TotalWidth = 530.0F
        pdfTable01.LockedWidth = True
        pdfTable01.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfTable01.HeaderRows = 1

        Dim widths01 As Single() = New Single() {10.0F, 70.0F, 15.0F, 20.0F, 20.0F}

        pdfTable01.SetWidths(widths01)

        Dim montantTotal As Double = 0

        pdfCell = New PdfPCell(New Paragraph("No", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("DESIGNATION", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("QTE", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("PU", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        '------------------------1----------------------------

        pdfCell = New PdfPCell(New Paragraph("1-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("LOCATION SALLE", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa, "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(MONTANT_ACCORDE, "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * MONTANT_ACCORDE, "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += periodeDeLaResa * MONTANT_ACCORDE

        '----------------------------------------------------

        '------------------------2----------------------------

        pdfCell = New PdfPCell(New Paragraph("2-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("DECORATION", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("DECORATION"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("DECORATION"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("DECORATION")

        '----------------------------------------------------

        '------------------------3----------------------------

        pdfCell = New PdfPCell(New Paragraph("3-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("LOCATION MATERIEL", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("LOCATION_MATERIEL"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("LOCATION_MATERIEL"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("LOCATION_MATERIEL")

        '----------------------------------------------------

        '------------------------4----------------------------

        pdfCell = New PdfPCell(New Paragraph("4-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("DIVERS", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("AUTRES"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("AUTRES"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("AUTRES")

        '----------------------------------------------------

        '------------------------5----------------------------

        pdfCell = New PdfPCell(New Paragraph("5-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("PAUSE CAFE", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE__CAFE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_CAFE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("PU_CAFE") * forfaitSalle.Rows(0)("NBRE__CAFE"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE__CAFE") * forfaitSalle.Rows(0)("PU_CAFE")

        '----------------------------------------------------

        '------------------------6----------------------------

        pdfCell = New PdfPCell(New Paragraph("6-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("PAUSE DEJEUNER", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DEJEUNER"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_DEJEUNER"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DEJEUNER") * forfaitSalle.Rows(0)("PU_DEJEUNER"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DEJEUNER") * forfaitSalle.Rows(0)("PU_DEJEUNER")

        '----------------------------------------------------

        '------------------------7----------------------------

        pdfCell = New PdfPCell(New Paragraph("7-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("PAUSE DINER", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DINER"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_DINER"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DINER") * forfaitSalle.Rows(0)("PU_DINER"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_DINER") * forfaitSalle.Rows(0)("PU_DINER")

        '----------------------------------------------------

        '------------------------8----------------------------

        pdfCell = New PdfPCell(New Paragraph("8-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("TRAITEURS", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_TRAITEUR"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_TRAITEUR"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_TRAITEUR") * forfaitSalle.Rows(0)("PU_TRAITEUR"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_TRAITEUR") * forfaitSalle.Rows(0)("PU_TRAITEUR")

        '----------------------------------------------------

        '------------------------9----------------------------

        pdfCell = New PdfPCell(New Paragraph("9-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("GOUTER", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_GOUTER"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_GOUTER"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_GOUTER") * forfaitSalle.Rows(0)("PU_GOUTER"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_GOUTER") * forfaitSalle.Rows(0)("PU_GOUTER")

        '----------------------------------------------------

        '------------------------10----------------------------

        pdfCell = New PdfPCell(New Paragraph("10-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("COCKTAILS", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_COCKTAIL"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("PU_COCKTAIL"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_COCKTAIL") * forfaitSalle.Rows(0)("PU_COCKTAIL"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += periodeDeLaResa * forfaitSalle.Rows(0)("NBRE_COCKTAIL") * forfaitSalle.Rows(0)("PU_COCKTAIL")

        '----------------------------------------------------

        '------------------------11----------------------------

        pdfCell = New PdfPCell(New Paragraph("11-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("EAU PETITE BOUTEILLE", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_PTE_QTE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        If forfaitSalle.Rows(0)("EAU_PTE_QTE") > 0 Then
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("EAU_PTE_MONTANT") / forfaitSalle.Rows(0)("EAU_PTE_QTE")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_PTE_MONTANT"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("EAU_PTE_MONTANT")

        '----------------------------------------------------

        '------------------------12----------------------------

        pdfCell = New PdfPCell(New Paragraph("12-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("EAU GRANDE BOUTEILLE", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_GRDE_QTE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        If forfaitSalle.Rows(0)("EAU_GRDE_QTE") > 0 Then
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("EAU_GRDE_MONTANT") / forfaitSalle.Rows(0)("EAU_GRDE_QTE")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_GRDE_MONTANT"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("EAU_GRDE_MONTANT")

        '----------------------------------------------------

        '------------------------13----------------------------

        pdfCell = New PdfPCell(New Paragraph("13-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("BOISSONS GAZEUSES", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        If forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE") > 0 Then
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT") / forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT")

        '----------------------------------------------------

        '------------------------14----------------------------

        pdfCell = New PdfPCell(New Paragraph("14-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("BIERES", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BIERES_QTE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        If forfaitSalle.Rows(0)("BIERES_QTE") > 0 Then
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BIERES_MONTANT") / forfaitSalle.Rows(0)("BIERES_QTE")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BIERES_MONTANT"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("BIERES_MONTANT")

        '----------------------------------------------------

        '------------------------15----------------------------

        pdfCell = New PdfPCell(New Paragraph("15-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("VIN ROUGE", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROUGE_QTE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        If forfaitSalle.Rows(0)("VIN_ROUGE_QTE") > 0 Then
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT") / forfaitSalle.Rows(0)("VIN_ROUGE_QTE")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT")

        '----------------------------------------------------
        '------------------------16----------------------------

        pdfCell = New PdfPCell(New Paragraph("16-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("VIN ROSE", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROSE_QTE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        If forfaitSalle.Rows(0)("VIN_ROSE_QTE") > 0 Then
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT") / forfaitSalle.Rows(0)("VIN_ROSE_QTE")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT")

        '----------------------------------------------------
        '------------------------17----------------------------

        pdfCell = New PdfPCell(New Paragraph("17-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("BOISSONS EXTERIEURES", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_EXT_QTE"), "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        If forfaitSalle.Rows(0)("BOISSONS_EXT_QTE") > 0 Then
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("VIN_ROSE_MONTANT") / forfaitSalle.Rows(0)("BOISSONS_EXT_QTE")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROSE_MONTANT"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("VIN_ROSE_MONTANT")

        '----------------------------------------------------
        '------------------------18----------------------------

        pdfCell = New PdfPCell(New Paragraph("18-", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("DROIT DE BOUCHON", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(1, "#,##0"), font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)


        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("DROIT_DE_BOUCHON"), "#,##0"), font1))

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("DROIT_DE_BOUCHON"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("DROIT_DE_BOUCHON")

        '----------------------------------------------------

        pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        pdfCell.Colspan = 4
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(montantTotal, "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)
        pdfDoc.Add(pdfTable01)

        Dim p007 As String = Chr(13) & Chr(13) & "Arrêter à la somme de : " & Functions.NBLT(montantTotal).ToUpper & " " & societe.Rows(0)("CODE_MONNAIE")
        pdfDoc.Add(New Paragraph(p007, pColumn))

        pdfDoc.Add(pdfCell)

        Dim p07 As String = Chr(13) & Chr(13) & "           SIGNATURE DU CLIENT                                              SIGNATURE DE L'HOTEL"
        pdfDoc.Add(New Paragraph(p07, pColumn))
        pdfDoc.Add(pdfCell)

        '---------------------------------------------------------------------------------------------------------------------------
        pdfDoc.Close()

        Dim Titre As String = "CONTRAT DE LOCATION DE SALLE"

        Dim bodyText As String = "Ci jointe votre contrat de location de salle"

        If WHATSAPP_OU_MAIL = 1 Then
            envoieDocumentMailClient(fichier, Titre, bodyText, emaiL)
        ElseIf WHATSAPP_OU_MAIL = 0 Then

            Dim nmessageOuDocument As Integer = 1
            Dim typeDeDocument As Integer = 2
            Dim phoneNumber As String = TELEPHONE

            Functions.ultrMessage(fichier, nmessageOuDocument, titreFichier, bodyText, typeDeDocument, phoneNumber)

        End If

    End Sub

    Public Shared Sub docJournalDesVentesShift(ByVal dtCategoryParent As DataTable, ByVal DateDebut As Date, ByVal DateFin As Date)

        Dim societe As DataTable = Functions.allTableFields("societe")

        Dim TotalCommande As Double = 0

        Dim tireDocument As String = ""
        Dim titreFichier As String = ""

        Dim filePathAndDirectory As String = ""

        Dim nomDuDossierRapport As String = ""

        If GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT" Then

            nomDuDossierRapport = "RAPPORTS\JOURNAL_DES_VENTES_SHIFT"
            tireDocument = "JOURNAL DES VENTES DU SHIFT DE " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " " & Date.Now().ToString("ddMMyyHHmmss")
            titreFichier = "JOURNAL DES VENTES DE SHIFT DE " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

            filePathAndDirectory = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy") & "\" & GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")

        Else

            nomDuDossierRapport = "RAPPORTS\JOURNAL_DES_VENTES"
            tireDocument = "JOURNAL DES VENTES DU " & GlobalVariable.DateDeTravail & " " & Date.Now().ToString("ddMMyyHHmmss")
            titreFichier = "JOURNAL DES VENTES DE " & GlobalVariable.DateDeTravail

            filePathAndDirectory = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

        End If

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim fichier As String = ""

        If True Then

            fichier = filePathAndDirectory & "\" & titreFichier & " DU " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"

            Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
            'Dim pdfDoc As New Document(PageSize.B7, 5, 5, 5, 5)
            Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font1 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            Dim pdfCell As PdfPCell = Nothing

            pdfWrite.PageEvent = New HeaderFooter

            pdfDoc.Open()

            Dim p1 As Paragraph = New Paragraph(societe.Rows(0)("RAISON_SOCIALE") & Chr(13) & "***", pColumn)
            p1.Alignment = Element.ALIGN_CENTER

            'pdfDoc.Add(p1)

            Dim p3 As Paragraph = New Paragraph(Chr(13) & Date.Now() & Chr(13), pColumn)
            p3.Alignment = Element.ALIGN_CENTER

            pdfDoc.Add(p3)

            If DateDebut = DateFin Then

                Dim p0 As Paragraph = New Paragraph(Chr(13) & " JOURNAL DES VENTES DU : " & DateDebut & " DE " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & Chr(13), pRow)
                p0.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p0)

            Else

                Dim p0 As Paragraph = New Paragraph(Chr(13) & " JOURNAL DES VENTES DU : " & DateDebut & Chr(13) & " AU " & DateFin & " DE " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR"), pRow)
                p0.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p0)

            End If

            Dim totalDesDesVentesDeLaFamille As Double = 0
            Dim totalDesDesVentes As Double = 0

            Dim totalDesDesVentesDeLaFamille2 As Double = 0
            Dim totalDesDesVentes2 As Double = 0

            Dim ListeDesResumeDesVentes As DataTable

            If dtCategoryParent.Rows.Count > 0 Then

                For i = 0 To dtCategoryParent.Rows.Count - 1
                    'VENTES
                    Dim pdfTable As New PdfPTable(4) 'Number of columns
                    pdfTable.TotalWidth = 520.0F
                    pdfTable.LockedWidth = True
                    pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfTable.HeaderRows = 1

                    Dim widths As Single() = New Single() {67.0F, 10.0F, 8.0F, 15.0F}

                    pdfTable.SetWidths(widths)

                    totalDesDesVentesDeLaFamille = 0

                    Dim ligneFacture As New LigneFacture()
                    Dim CategoriePArent As String = dtCategoryParent.Rows(i)("SOUS FAMILLE")

                    Dim p2 As Paragraph = New Paragraph(i + 1 & "-" & CategoriePArent & Chr(13) & Chr(13), pRow)
                    p2.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p2)

                    pdfCell = New PdfPCell(New Paragraph("DESIGNATION", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("PU", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("QTE", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable.AddCell(pdfCell)

                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    'pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable.AddCell(pdfCell)

                    'ARTICLE D'UNE FAMILLE QUELCONQUE

                    Dim dt As DataTable

                    If GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES" Then
                        dt = ligneFacture.ListeDesArticlesVendusParFamille(CategoriePArent, DateDebut, DateFin)
                        ListeDesResumeDesVentes = Impression.resumeDesVentesGlobal(DateDebut, DateFin)
                    ElseIf GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT" Then
                        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        ListeDesResumeDesVentes = Impression.resumeDesVentesQuotidienne(DateDebut, DateFin, CODE_CAISSIER)
                        dt = ligneFacture.ListeDesArticlesVendusParFamilleDunCaissier(CategoriePArent, DateDebut, DateFin, CODE_CAISSIER)
                    End If

                    Dim totalQte As Integer = 0
                    Dim totalQte2 As Integer = 0

                    If dt.Rows.Count > 0 Then

                        For j = 0 To dt.Rows.Count - 1

                            totalDesDesVentesDeLaFamille += dt.Rows(j)("MONTANT TOTAL")
                            totalDesDesVentes += dt.Rows(j)("MONTANT TOTAL")

                            pdfCell = New PdfPCell(New Paragraph(dt.Rows(j)("LIBELLE ARTICLE"), font1))
                            pdfCell.MinimumHeight = 5
                            pdfCell.PaddingLeft = 5.0F
                            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph(Format(dt.Rows(j)("PRIX UNITAIRE"), "#,##0"), font1))
                            pdfCell.MinimumHeight = 5
                            pdfCell.PaddingLeft = 5.0F
                            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                            pdfTable.AddCell(pdfCell)

                            Dim QUANTITE As Double = dt.Rows(j)("QUANTITE")

                            If QUANTITE = 0 Then
                                QUANTITE = dt.Rows(j)("MONTANT TOTAL") / dt.Rows(j)("PRIX UNITAIRE")
                            End If

                            pdfCell = New PdfPCell(New Paragraph(Format(QUANTITE, "#,##0"), font1))
                            pdfCell.MinimumHeight = 5
                            pdfCell.PaddingLeft = 5.0F
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph(Format(dt.Rows(j)("MONTANT TOTAL"), "#,##0"), font1))
                            pdfCell.MinimumHeight = 5
                            pdfCell.PaddingLeft = 5.0F
                            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT

                            totalQte += QUANTITE

                            pdfTable.AddCell(pdfCell)

                        Next

                    End If

                    pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    pdfCell.Colspan = 2
                    pdfCell.Border = 0
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Format(totalQte, "#,##0"), pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    pdfCell.Border = 0
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable.AddCell(pdfCell)

                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY

                    pdfCell = New PdfPCell(New Paragraph(Format(totalDesDesVentesDeLaFamille, "#,##0"), pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell.MinimumHeight = 15
                    pdfCell.Border = 0
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable.AddCell(pdfCell)

                    pdfDoc.Add(pdfTable)

                    '---------------------GRATUITE----------------------------------

                    Dim p7 As Paragraph = New Paragraph(" GRATUITES : " & Chr(13) & Chr(13), pRow)
                    p7.Alignment = Element.ALIGN_CENTER

                    Dim pdfTable2 As New PdfPTable(4) 'Number of columns
                    pdfTable2.TotalWidth = 520.0F
                    pdfTable2.LockedWidth = True
                    pdfTable2.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfTable2.HeaderRows = 1

                    Dim widths2 As Single() = New Single() {67.0F, 10.0F, 8.0F, 15.0F}

                    pdfTable2.SetWidths(widths2)

                    totalDesDesVentesDeLaFamille2 = 0

                    Dim ligneFacture2 As New LigneFacture()
                    'Dim CategoriePArent2 As String = dtCategoryParent.Rows(i)("SOUS FAMILLE")

                    Dim p8 As Paragraph = New Paragraph("FAMILLE D'ARTICLE: " & CategoriePArent & Chr(13) & Chr(13), font1)
                    p8.Alignment = Element.ALIGN_LEFT

                    'pdfDoc.Add(p2)

                    pdfCell = New PdfPCell(New Paragraph("DESIGNATION", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 5
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable2.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("PU", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 5
                    'pdfCell.PaddingLeft = 5.0F
                    pdfTable2.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("QTE", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 5
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable2.AddCell(pdfCell)

                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    'pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 5
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable2.AddCell(pdfCell)

                    'ARTICLE D'UNE FAMILLE QUELCONQUE
                    Dim dtGratuite As DataTable = ligneFacture.ListeDesArticlesVendusGratuitementParFamille(CategoriePArent, DateDebut, DateFin)

                    If dtGratuite.Rows.Count > 0 Then

                        pdfDoc.Add(p7)

                        totalDesDesVentesDeLaFamille2 = 0

                        For j = 0 To dtGratuite.Rows.Count - 1

                            totalDesDesVentesDeLaFamille2 += dtGratuite.Rows(j)("MONTANT TOTAL")
                            totalDesDesVentes2 += dtGratuite.Rows(j)("MONTANT TOTAL")

                            pdfCell = New PdfPCell(New Paragraph(dtGratuite.Rows(j)("LIBELLE ARTICLE"), font1))
                            pdfCell.MinimumHeight = 5
                            pdfCell.PaddingLeft = 5.0F
                            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                            pdfTable2.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph(Format(dtGratuite.Rows(j)("PRIX UNITAIRE"), "#,##0"), font1))
                            pdfCell.MinimumHeight = 5
                            pdfCell.PaddingLeft = 5.0F
                            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                            pdfTable2.AddCell(pdfCell)

                            Dim QUANTITE As Double = dtGratuite.Rows(j)("QUANTITE")

                            If QUANTITE = 0 Then
                                QUANTITE = dtGratuite.Rows(j)("MONTANT TOTAL") / dtGratuite.Rows(j)("PRIX UNITAIRE")
                            End If

                            totalQte2 += QUANTITE

                            pdfCell = New PdfPCell(New Paragraph(Format(QUANTITE, "#,##0"), font1))
                            pdfCell.MinimumHeight = 5
                            pdfCell.PaddingLeft = 5.0F
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfTable2.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph(Format(dtGratuite.Rows(j)("MONTANT TOTAL"), "#,##0"), font1))
                            pdfCell.MinimumHeight = 5
                            pdfCell.PaddingLeft = 5.0F
                            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT

                            pdfTable2.AddCell(pdfCell)

                        Next

                    End If

                    If Double.Parse(totalDesDesVentesDeLaFamille2) > 0 Then

                        pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 15
                        pdfCell.Colspan = 2
                        pdfCell.Border = 0
                        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                        pdfTable2.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(Format(totalQte2, "#,##0"), pColumn))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfCell.MinimumHeight = 15
                        pdfCell.Border = 0
                        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                        pdfTable2.AddCell(pdfCell)

                        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                        'pdfTable.AddCell(pdfCell)

                        pdfCell = New PdfPCell(New Paragraph(Format(totalDesDesVentesDeLaFamille2, "#,##0"), pColumn))
                        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                        pdfCell.MinimumHeight = 15
                        pdfCell.Border = 0
                        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                        pdfTable2.AddCell(pdfCell)

                    End If

                    pdfDoc.Add(pdfTable2)

                    '----------------------------- END GRATUITE --------------------------

                Next

                '------------------------------------------------------------------------

                Dim p11 As Paragraph = New Paragraph(Chr(13), pRow)
                p11.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p11)

                Dim pdfTable4 As New PdfPTable(2) 'Number of columns

                pdfTable4.TotalWidth = 520.0F
                pdfTable4.LockedWidth = True
                pdfTable4.HorizontalAlignment = Element.ALIGN_RIGHT
                'pdfTable4.HeaderRows = 1

                Dim widths4 As Single() = New Single() {60.0F, 20.0F}
                pdfTable4.SetWidths(widths4)

                Dim pdfCell4 As PdfPCell = Nothing

                pdfCell4 = New PdfPCell(New Paragraph("TOTAL DES VENTES : ", pRow))
                pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell4.MinimumHeight = 18
                pdfCell4.PaddingLeft = 15.0F
                pdfCell4.Border = 0
                pdfTable4.AddCell(pdfCell4)

                pdfCell4 = New PdfPCell(New Paragraph(Format(totalDesDesVentes, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE"), pRow))
                pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell4.MinimumHeight = 18
                pdfCell4.PaddingLeft = 15.0F
                pdfCell4.Border = 0
                pdfTable4.AddCell(pdfCell4)

                pdfCell4 = New PdfPCell(New Paragraph("TOTAL DES GRATUITEES : ", pRow))
                pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell4.MinimumHeight = 18
                pdfCell4.PaddingLeft = 15.0F
                pdfCell4.Border = 0
                pdfTable4.AddCell(pdfCell4)

                pdfCell4 = New PdfPCell(New Paragraph(Format(totalDesDesVentes2, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE"), pRow))
                pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell4.MinimumHeight = 18
                pdfCell4.PaddingLeft = 15.0F
                pdfCell4.Border = 0
                pdfTable4.AddCell(pdfCell4)

                pdfCell4 = New PdfPCell(New Paragraph("VENTE NET : ", pRow))
                pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell4.MinimumHeight = 18
                pdfCell4.PaddingLeft = 15.0F
                pdfCell4.Border = 0
                pdfTable4.AddCell(pdfCell4)

                pdfCell4 = New PdfPCell(New Paragraph(Format(totalDesDesVentes - totalDesDesVentes2, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE"), pRow))
                pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell4.MinimumHeight = 18
                pdfCell4.PaddingLeft = 15.0F
                pdfCell4.Border = 0
                pdfTable4.AddCell(pdfCell4)

                pdfDoc.Add(pdfTable4)


                '--------------------- RESUMES DES VENTES -------------------------------

                If ListeDesResumeDesVentes.Rows.Count > 0 Then

                    Dim compte As Double = 0
                    Dim gratuitee As Double = 0
                    Dim chambre As Double = 0
                    Dim comptoir As Double = 0
                    Dim offreEnChambre As Double = 0

                    For i = 0 To ListeDesResumeDesVentes.Rows.Count - 1
                        compte += ListeDesResumeDesVentes(i)("COMPTE")
                        gratuitee += ListeDesResumeDesVentes(i)("GRATUITEE")
                        chambre += ListeDesResumeDesVentes(i)("EN_CHAMBRE")
                        comptoir += ListeDesResumeDesVentes(i)("COMPTOIR")
                        offreEnChambre += ListeDesResumeDesVentes(i)("GRATUITE_EN_CHAMBRE")
                    Next

                    Dim pdfTable04 As New PdfPTable(10) 'Number of columns

                    pdfTable04.TotalWidth = 520.0F
                    pdfTable04.LockedWidth = True
                    pdfTable04.HorizontalAlignment = Element.ALIGN_RIGHT
                    'pdfTable04.HeaderRows = 1

                    Dim widths04 As Single() = New Single() {15.0F, 15.0F, 16.0F, 16.0F, 17.0F, 17.0F, 17.0F, 17.0F, 14.0F, 14.0F}
                    pdfTable04.SetWidths(widths04)

                    Dim pdfCell04 As PdfPCell = Nothing

                    pdfCell04 = New PdfPCell(New Paragraph("VENTE COMPTOIR", pRow1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph("VENTE EN CHAMBRE", pRow1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph("OFFRES EN CHAMBRE", pRow1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph("AUTRES OFFRES", pRow1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph("VERS COMPTE", pRow1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    '-------------------------- HEADER END --------------------------

                    pdfCell04 = New PdfPCell(New Paragraph(Format(comptoir, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE"), font1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph(Format(chambre, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE"), font1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph(Format(offreEnChambre, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE"), font1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph(Format(gratuitee - offreEnChambre, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE"), font1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph(Format(compte, "#,##0") & " " & societe.Rows(0)("CODE_MONNAIE"), font1))
                    pdfCell04.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfDoc.Add(pdfTable04)

                End If


                ' ------------------------------------------------------------------------------------------------
                Dim p002 As Paragraph = New Paragraph(Chr(13) & "Arrêter la présente à la somme de : " & Functions.NBLT(totalDesDesVentes - totalDesDesVentes2) & " " & societe.Rows(0)("CODE_MONNAIE") & Chr(13) & Chr(13), pRow)
                p002.Alignment = Element.ALIGN_LEFT

                pdfDoc.Add(p002)

                pdfDoc.Close()

                Dim bodyText As String = ""

                If GlobalVariable.actualLanguageValue = 1 Then
                    bodyText = "Recevez nos salutations," & Chr(13) & " Merci de bien vouloir trouver ci joint la " & tireDocument.ToLower() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Ne pas répondre a ce mail !!"

                Else
                    bodyText = "Receive our greetings," & Chr(13) & " Attachement " & tireDocument.ToLower() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do no respond to this mail !!"

                End If

                'kklg
                'envoieDocumentMailCloture(fichier, tireDocument, bodyText, DateDebut)

                Dim nmessageOuDocument As Integer = 1 'MESSAGE ET DOCUMENTS
                Dim typeDeDocument As Integer = 0

                Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument)

            End If

        End If

    End Sub


End Class
