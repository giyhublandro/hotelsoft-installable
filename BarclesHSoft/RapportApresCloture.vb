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

                If GlobalVariable.actualLanguageValue = 0 Then

                    If GlobalVariable.DocumentToGenerate = "situation caisse" Then
                        pdfCell = New PdfPCell(New Paragraph("               CASHIER SIGNATURE                                               ACCOUNTANT SIGNATURE"))
                    ElseIf GlobalVariable.DocumentToGenerate = "DST" Then
                        pdfCell = New PdfPCell(New Paragraph(""))
                    ElseIf GlobalVariable.DocumentToGenerate = "reglement" Or GlobalVariable.DocumentToGenerate = "facture" Then
                        pdfCell = New PdfPCell(New Paragraph("               CLIENT SIGNATURE                                                    HOTEL SIGNATURE"))
                    Else
                        pdfCell = New PdfPCell(New Paragraph("               CLIENT SIGNATURE                                                    HOTEL SIGNATURE"))
                    End If
                Else
                    If GlobalVariable.DocumentToGenerate = "situation caisse" Then
                        pdfCell = New PdfPCell(New Paragraph("               SIGNATURE DU CAISSIER                                               SIGNATURE DU COMPTABLE"))
                    ElseIf GlobalVariable.DocumentToGenerate = "DST" Then
                        pdfCell = New PdfPCell(New Paragraph(""))
                    ElseIf GlobalVariable.DocumentToGenerate = "reglement" Or GlobalVariable.DocumentToGenerate = "facture" Then
                        pdfCell = New PdfPCell(New Paragraph("               SIGNATURE DU CLIENT                                                    SIGNATURE DE L'HOTEL"))
                    Else
                        pdfCell = New PdfPCell(New Paragraph("               SIGNATURE DU CLIENT                                                    SIGNATURE DE L'HOTEL"))
                    End If

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

                pdfCell = New PdfPCell(New Paragraph(PIEDS_L2 & Chr(13) & PIEDS_L3 & Chr(13) & GlobalVariable.AgenceActuelle.Rows(0)("MARQUEUR_PIEDS_PAGE") & GlobalVariable.DateDeTravail & "-" & Now().ToLongTimeString, font2))
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

                pdfCell = New PdfPCell(New Paragraph(PIEDS_L2 & Chr(13) & PIEDS_L3 & Chr(13) & GlobalVariable.AgenceActuelle.Rows(0)("MARQUEUR_PIEDS_PAGE") & GlobalVariable.DateDeTravail & "-" & Now().ToLongTimeString, font2))
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

    Public Shared Async Sub docBondeCommande(ByVal fichier As String, ByVal bloc_note As String)

        Dim bodyText As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            bodyText = "BLOC NOTE No " & bloc_note
        Else
            bodyText = "RECEIPT No " & bloc_note
        End If

        Dim tireDocument As String = bodyText
        Dim nmessageOuDocument As Integer = 1
        Dim typeDeDocument As Integer = 0

        Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument)

    End Sub

    Public Shared Sub RapportMainCourante(ByVal dateMainCouranteDebut As Date, ByVal dateMainCouranteFin As Date, Optional renvoie As Boolean = False)

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


        Dim nomDuDossierRapport As String = "RAPPORTS\MAINCOURANTES_CUMUL"

        Dim filePathAndDirectory As String = ""

        filePathAndDirectory = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & dateMainCouranteDebut.ToString("ddMMyy") & dateMainCouranteFin.ToString("ddMMyy")

        Dim fichier As String = ""

        '--------------------------------------------------------------
        Dim dtRapport As DataTable = Functions.verificationExistenceCheminDesRapportsDuJours(dateMainCouranteDebut)

        If GlobalVariable.actualLanguageValue = 1 Then
            titreFichier = "MAIN COURANTE CUMULE"
            tireDocument = titreFichier & " DU " & dateMainCouranteDebut.ToShortDateString & " AU " & dateMainCouranteFin.ToShortDateString
        Else
            titreFichier = "CUMULATED FINANCIAL REPORT"
            tireDocument = titreFichier & " FROM " & dateMainCouranteDebut.ToShortDateString & " TO " & dateMainCouranteFin.ToShortDateString
        End If

        If dtRapport.Rows.Count > 0 Then

            If Not Trim(dtRapport.Rows(0)("CHEMIN_MAINCOURANTE_CUMUL")).Equals("") Then
                fichier = dtRapport.Rows(0)("CHEMIN_MAINCOURANTE_CUMUL")
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

        'envoieDocumentMailCloture(fichier, tireDocument, bodyText, dateMainCouranteDebut)

        Dim nmessageOuDocument As Integer = 1
        Dim typeDeDocument As Integer = 0

        Functions.ultrMessage(fichier, nmessageOuDocument, tireDocument, bodyText, typeDeDocument)

        '--------------------------------------------------------------

    End Sub

    Public Shared Async Sub impressionEconomat(ByVal dt As DataGridView, ByVal title As String, ByVal totalAchat As Double, ByVal totalVente As Double,
                                         ByVal numeroBon As String, ByVal ETAT_BORDEREAUX As Integer, Optional ByVal nomTiers As String = "", Optional ByVal libelle As String = "",
                                         Optional ByVal reference As String = "", Optional ByVal observations As String = "", Optional ByVal typeBordereau As String = "", Optional from As String = "")

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        If True Then

            Dim MODIFIER As String = ""
            Dim bordoro As DataTable = Functions.getElementByCode(numeroBon, "bordereaux", "CODE_BORDEREAUX")
            If bordoro.Rows.Count > 0 Then
                MODIFIER = bordoro.Rows(0)("MODIFIER")
            End If

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

                titreFichier = title & " (" & libelle & " - " & numeroBon & ") " & MODIFIER
                '& "(" & libelle & "/" & numeroBon & ")"
                tireDocument = titreFichier & " DU " & GlobalVariable.DateDeTravail.ToShortDateString
                If GlobalVariable.actualLanguageValue = 0 Then
                    tireDocument = titreFichier & " OF " & GlobalVariable.DateDeTravail.ToShortDateString
                End If
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

                    If GlobalVariable.actualLanguageValue = 0 Then

                        Dim p0 As Paragraph = New Paragraph(Chr(13) & Chr(13) & title & " No :  " & infoSupBon.Rows(0)("CODE_BORDEREAUX") & Chr(13) & "LABEL: " & infoSupBon.Rows(0)("LIBELLE_BORDEREAUX") & Chr(13) & "REFERENCE: " & infoSupBon.Rows(0)("REF_BORDEREAUX") & Chr(13) & "SEEKING: " & infoSupBon.Rows(0)("NON_TIERS") & Chr(13) & Chr(13), pRow)
                        p0.Alignment = Element.ALIGN_LEFT
                        pdfDoc.Add(p0)

                        Dim p3 As Paragraph = New Paragraph(title.ToUpper() & " OF " & " " & dateDebut & Chr(13) & "FOR THE PERIOD " & CDate(infoSupBon.Rows(0)("DATE_DU")).ToShortDateString & " - " & CDate(infoSupBon.Rows(0)("DATE_AU")).ToShortDateString, pRow)
                        p3.Alignment = Element.ALIGN_LEFT

                        pdfDoc.Add(p3)

                    Else

                        Dim p0 As Paragraph = New Paragraph(Chr(13) & Chr(13) & title & " NUMERO :  " & infoSupBon.Rows(0)("CODE_BORDEREAUX") & Chr(13) & "LIBELLE: " & infoSupBon.Rows(0)("LIBELLE_BORDEREAUX") & Chr(13) & "REFERENCE: " & infoSupBon.Rows(0)("REF_BORDEREAUX") & Chr(13) & "DEMANDEUR: " & infoSupBon.Rows(0)("NON_TIERS") & Chr(13) & Chr(13), pRow)
                        p0.Alignment = Element.ALIGN_LEFT
                        pdfDoc.Add(p0)

                        Dim p3 As Paragraph = New Paragraph(title.ToUpper() & " DU " & " " & dateDebut & Chr(13) & "POUR LA PERIODE DU " & CDate(infoSupBon.Rows(0)("DATE_DU")).ToShortDateString & " AU " & CDate(infoSupBon.Rows(0)("DATE_AU")).ToShortDateString, pRow)
                        p3.Alignment = Element.ALIGN_LEFT

                        pdfDoc.Add(p3)

                    End If

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
                If GlobalVariable.actualLanguageValue = 0 Then
                    p02 = New Paragraph(Chr(13) & "FORCASTING (NUMBER OF PAX)" & Chr(13) & Chr(13), pRow)
                End If
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
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell002 = New PdfPCell(New Paragraph("IN HOUSE", fontTotal1))
                End If
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                pdfCell002 = New PdfPCell(New Paragraph("PASSANT", fontTotal1))
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell002 = New PdfPCell(New Paragraph("WALK IN", fontTotal1))
                End If
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                pdfCell002 = New PdfPCell(New Paragraph("TRAITEURS", fontTotal1))
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell002 = New PdfPCell(New Paragraph("CATERING", fontTotal1))
                End If
                pdfCell002.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell002.MinimumHeight = 5
                pdfCell002.Border = 0

                pdfTable002.AddCell(pdfCell002)

                pdfCell002 = New PdfPCell(New Paragraph("EVENEMENTIEL", fontTotal1))
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell002 = New PdfPCell(New Paragraph("EVENTS", fontTotal1))
                End If
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
                            If GlobalVariable.actualLanguageValue = 0 Then
                                pdfCell = New PdfPCell(New Paragraph("ITEM", fontTotal1))
                            End If
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph("UNITE", fontTotal1))
                            If GlobalVariable.actualLanguageValue = 0 Then
                                pdfCell = New PdfPCell(New Paragraph("UNIT", fontTotal1))
                            End If
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5
                            'pdfCell.PaddingLeft = 5.0F
                            'pdfCell.Border = 0

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph("QTE", fontTotal1))
                            If GlobalVariable.actualLanguageValue = 0 Then
                                pdfCell = New PdfPCell(New Paragraph("QTY", fontTotal1))
                            End If
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                            pdfCell.MinimumHeight = 5
                            'pdfCell.PaddingLeft = 5.0F
                            'pdfCell.Border = 0

                            pdfTable.AddCell(pdfCell)

                            pdfCell = New PdfPCell(New Paragraph("PU", fontTotal1))
                            If GlobalVariable.actualLanguageValue = 0 Then
                                pdfCell = New PdfPCell(New Paragraph("UP", fontTotal1))
                            End If
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
                                    If GlobalVariable.actualLanguageValue = 0 Then
                                        pdfCell = New PdfPCell(New Paragraph("ITEM", fontTotal1))
                                    End If
                                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                                    pdfCell.MinimumHeight = 5

                                    pdfTable.AddCell(pdfCell)

                                    pdfCell = New PdfPCell(New Paragraph(dt_.Rows(0)("UNITE"), font1))
                                    If GlobalVariable.actualLanguageValue = 0 Then
                                        pdfCell = New PdfPCell(New Paragraph("UNIT", fontTotal1))
                                    End If
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
                    If GlobalVariable.actualLanguageValue = 0 Then
                        p0030 = New Paragraph(Chr(13) & "TOTAL : " & Format(totaux, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), pRow)
                    End If
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
                If GlobalVariable.actualLanguageValue = 0 Then
                    p030 = New Paragraph(Chr(13) & "MARKET HISTORY " & date_1 & " - " & date_2, pRow)
                End If
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
                        If GlobalVariable.actualLanguageValue = 0 Then
                            pdfCell = New PdfPCell(New Paragraph("ITEM", fontTotal1))
                        End If
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
                                If GlobalVariable.actualLanguageValue = 0 Then
                                    pdfCell = New PdfPCell(New Paragraph("ITEM", fontTotal1))
                                End If
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

                If GlobalVariable.actualLanguageValue = 0 Then

                    If ETAT_BORDEREAUX = 0 Then
                        bodyText = "You have ," & tireDocument.ToUpper() & Chr(13) & " to CONTROLE. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer this e-mail !!"
                        MESSAGE = "You have ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " to CONTROLE "
                        OBJET = tireDocument.ToUpper()
                    ElseIf ETAT_BORDEREAUX = 1 Then
                        bodyText = "You have ," & tireDocument.ToUpper() & Chr(13) & " to VERIFY. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer this e-mail !!"
                        MESSAGE = "You have ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " to VERIFY"
                        OBJET = tireDocument.ToUpper()
                    ElseIf ETAT_BORDEREAUX = 2 Then
                        bodyText = "You have ," & tireDocument.ToUpper() & Chr(13) & " to VALIDATE. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer this e-mail !!"
                        MESSAGE = "You have ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " to VALIDATE "
                        OBJET = tireDocument.ToUpper()
                    ElseIf ETAT_BORDEREAUX = 3 Then
                        bodyText = "You have ," & tireDocument.ToUpper() & Chr(13) & " to ORDER. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer this e-mail !!"
                        MESSAGE = "You have ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " to ORDER "
                        OBJET = tireDocument.ToUpper()
                    ElseIf ETAT_BORDEREAUX = 4 Then
                        bodyText = "Steps of ," & tireDocument.ToUpper() & Chr(13) & " donne successfully. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer this e-mail !!"
                        MESSAGE = "Steps of ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & "donne successfully"
                        OBJET = tireDocument.ToUpper()
                    End If

                Else

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
                If GlobalVariable.actualLanguageValue = 0 Then
                    tireDocument = title.ToUpper() & " OF " & (Date.Now().ToString("ddMMyyHHmmss"))
                End If
                Dim sousTitreDocument As String = ""

                sousTitreDocument = tireDocument

                '---------------------------------------------------------------------------------------------------------------
                Dim titreFichier As String = ""

                titreFichier = title & " (" & libelle & " - " & numeroBon & ")" & MODIFIER
                '& "(" & libelle & "/" & numeroBon & ")"
                tireDocument = titreFichier & " DU " & GlobalVariable.DateDeTravail.ToShortDateString
                If GlobalVariable.actualLanguageValue = 0 Then
                    tireDocument = titreFichier & " OF " & GlobalVariable.DateDeTravail.ToShortDateString
                End If
                Dim nomDuDossierRapport As String = "RAPPORTS\ECONOMAT"

                Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

                My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

                Dim fichier As String = filePathAndDirectory & "\" & titreFichier & " DU " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"
                If GlobalVariable.actualLanguageValue = 0 Then
                    fichier = filePathAndDirectory & "\" & titreFichier & " OF " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"
                End If
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
                If GlobalVariable.actualLanguageValue = 0 Then
                    p3 = New Paragraph(Chr(13) & title.ToUpper() & " OF " & " " & GlobalVariable.DateDeTravail & Chr(13) & Chr(13), pRow)
                End If
                p3.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p3)

                Dim infoSupBon As DataTable = Functions.getElementByCode(numeroBon, "bordereaux", "CODE_BORDEREAUX")

                If infoSupBon.Rows.Count > 0 Then

                    If GlobalVariable.actualLanguageValue = 0 Then

                    Else

                    End If

                    Dim p0 As Paragraph = New Paragraph(Chr(13) & title & " No :  " & infoSupBon.Rows(0)("CODE_BORDEREAUX") & Chr(13) & "LABEL: " & infoSupBon.Rows(0)("LIBELLE_BORDEREAUX") & Chr(13) & "REFERENCE: " & infoSupBon.Rows(0)("REF_BORDEREAUX") & Chr(13) & "THIRD PARTY: " & infoSupBon.Rows(0)("NON_TIERS") & Chr(13) & Chr(13), pRow)
                    p0.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p0)

                Else

                    If GlobalVariable.actualLanguageValue = 0 Then
                        Dim p0 As Paragraph = New Paragraph(Chr(13) & title & " No :  " & numeroBon & Chr(13) & "LABEL: " & libelle & Chr(13) & "REFERENCE: " & reference & Chr(13) & "THIRD PARTY: " & nomTiers & Chr(13) & Chr(13), pRow)
                        p0.Alignment = Element.ALIGN_LEFT

                        pdfDoc.Add(p0)
                    Else
                        Dim p0 As Paragraph = New Paragraph(Chr(13) & title & " NUMERO :  " & numeroBon & Chr(13) & "LIBELLE: " & libelle & Chr(13) & "REFERENCE: " & reference & Chr(13) & "TIERS: " & nomTiers & Chr(13) & Chr(13), pRow)
                        p0.Alignment = Element.ALIGN_LEFT

                        pdfDoc.Add(p0)
                    End If


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
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell = New PdfPCell(New Paragraph("ITEM", fontTotal))
                End If
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("QTE", fontTotal))
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell = New PdfPCell(New Paragraph("QTY", fontTotal))
                End If
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfCell.MinimumHeight = 5
                'pdfCell.PaddingLeft = 5.0F
                'pdfCell.Border = 0

                pdfTable.AddCell(pdfCell)

                pdfCell = New PdfPCell(New Paragraph("PU", fontTotal))
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell = New PdfPCell(New Paragraph("UP", fontTotal))
                End If
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

                If GlobalVariable.actualLanguageValue = 0 Then
                    If ETAT_BORDEREAUX = 0 Then
                        bodyText = "You have ," & tireDocument.ToUpper() & Chr(13) & " to CONTROLE. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer to this e-mail !!"
                        MESSAGE = "You have ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " to CONTROLE "
                        OBJET = tireDocument.ToUpper()
                    ElseIf ETAT_BORDEREAUX = 1 Then
                        bodyText = "You have ," & tireDocument.ToUpper() & Chr(13) & " to VERIFY. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer to this e-mail !!"
                        MESSAGE = "You have ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " à VERIFY "
                        OBJET = tireDocument.ToUpper()
                    ElseIf ETAT_BORDEREAUX = 2 Then
                        bodyText = "You have ," & tireDocument.ToUpper() & Chr(13) & " to VALIDATE. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer to this e-mail !!"
                        MESSAGE = "You have ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " to VALIDATE "
                        OBJET = tireDocument.ToUpper()
                    ElseIf ETAT_BORDEREAUX = 3 Then
                        bodyText = "You have ," & tireDocument.ToUpper() & Chr(13) & " to ORDER. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer to this e-mail !!"
                        MESSAGE = "Vous avez un ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " to ORDER "
                        OBJET = tireDocument.ToUpper()
                    ElseIf ETAT_BORDEREAUX = 4 Then
                        bodyText = "Steps of ," & tireDocument.ToUpper() & Chr(13) & " donne successfully. Attachement : " & titreFichier.ToUpper() & Chr(13) & ". Barclés Hôtel Soft" & Chr(13) & ". Do not answer to this e-mail !!"
                        MESSAGE = "Steps of ," & tireDocument.ToUpper() & " [" & titreFichier.ToUpper() & "]" & " donne successfully"
                        OBJET = tireDocument.ToUpper()
                    End If
                Else
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

                If GlobalVariable.actualLanguageValue = 0 Then
                    'mail.Subject = Titre
                    mail.Subject = "NIGHT AUDIT REPORT " & dateTravail
                    'mail.Body = bodyText
                    mail.Body = "Receive our greeting, attachement of the night audit of " & dateTravail & ". Barclés Hôtel Soft. Do not answer to this mail !!"

                Else
                    'mail.Subject = Titre
                    mail.Subject = "RAPPORT DE CLOTURE DU " & dateTravail
                    'mail.Body = bodyText
                    mail.Body = "Recevez nos salutations, Merci de bien vouloir trouver ci joint les rapports de la cloture du " & dateTravail & ". Barclés Hôtel Soft. Ne pas répondre a ce mail !!"

                End If

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

                    If Not Trim(dtRapport.Rows(0)("CHEMIN_DEPENSE")).Equals("") Then
                        attachment = New System.Net.Mail.Attachment(dtRapport.Rows(0)("CHEMIN_DEPENSE"))
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
                'MessageBox.Show(ex.Message, "Envoi de mail Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
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
                'MessageBox.Show(ex.Message, "Envoi de mail", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try

        Else

            Functions.noInternetMessage()

        End If

    End Sub

    Public Shared Async Sub GenerationDeConfirmationReservationOldPerfect(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, ByVal email As String, ByVal TELEPHONE As String, ByVal WHATSAPP_OU_EMAIL As Integer)

        Dim societe As DataTable = Functions.allTableFields("societe")

        Dim CODE_MONNAIE As String = ""

        If societe.Rows.Count > 0 Then
            CODE_MONNAIE = societe.Rows(0)("CODE_MONNAIE")
        End If

        Dim titreFichier As String = "CONFIRMATION DE RESERVATION DE " & client
        If GlobalVariable.actualLanguageValue = 0 Then
            titreFichier = "BOOKING CONFIRMATION OF " & client
        End If
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

    End Sub

    Public Shared Sub docJournalDesVentesShift(ByVal dtCategoryParent As DataTable, ByVal DateDebut As Date, ByVal DateFin As Date)

        Dim societe As DataTable = Functions.allTableFields("societe")

        Dim TotalCommande As Double = 0

        Dim tireDocument As String = ""
        Dim titreFichier As String = ""

        Dim filePathAndDirectory As String = ""

        Dim nomDuDossierRapport As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            If GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT" Then

                nomDuDossierRapport = "RAPPORTS\JOURNAL_DES_VENTES_SHIFT"
                tireDocument = "SALES HISTORY OF THE SHIFT " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " " & Date.Now().ToString("ddMMyyHHmmss")
                titreFichier = "SALES HISTORY OF THE SHIFT OF " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

                filePathAndDirectory = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy") & "\" & GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")

            Else

                nomDuDossierRapport = "RAPPORTS\JOURNAL_DES_VENTES"
                tireDocument = "SALE HISTORY OF " & GlobalVariable.DateDeTravail & " " & Date.Now().ToString("ddMMyyHHmmss")
                titreFichier = "JSALE HISTORY OF " & GlobalVariable.DateDeTravail

                filePathAndDirectory = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")

            End If

        Else


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

        End If

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim fichier As String = ""

        If True Then

            fichier = filePathAndDirectory & "\" & titreFichier & " DU " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"
            If GlobalVariable.actualLanguageValue = 0 Then
                fichier = filePathAndDirectory & "\" & titreFichier & " OF " & GlobalVariable.DateDeTravail.ToString("ddMMyy") & ".pdf"
            End If
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
                If GlobalVariable.actualLanguageValue = 0 Then
                    p0 = New Paragraph(Chr(13) & " SALES HISTORY OF : " & DateDebut & " BY " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & Chr(13), pRow)
                End If
                p0.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p0)

            Else

                Dim p0 As Paragraph = New Paragraph(Chr(13) & " JOURNAL DES VENTES DU : " & DateDebut & Chr(13) & " AU " & DateFin & " DE " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR"), pRow)
                If GlobalVariable.actualLanguageValue = 0 Then
                    p0 = New Paragraph(Chr(13) & " SALES HISTORY FROM : " & DateDebut & Chr(13) & " - " & DateFin & " OF " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR"), pRow)
                End If
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
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell = New PdfPCell(New Paragraph("ITEM", pColumn))
                    End If
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("PU", pColumn))
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell = New PdfPCell(New Paragraph("UP", pColumn))
                    End If
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 15
                    'pdfCell.PaddingLeft = 5.0F
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("QTE", pColumn))
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell = New PdfPCell(New Paragraph("QTY", pColumn))
                    End If
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

                    '---------------------GRATITE----------------------------------
                    Dim freeTExt As String = " GRATUITES : "
                    If GlobalVariable.actualLanguageValue = 0 Then
                        freeTExt = " OFFERS : "
                    End If
                    Dim p7 As Paragraph = New Paragraph(freeTExt & Chr(13) & Chr(13), pRow)
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
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell = New PdfPCell(New Paragraph("ITEM", pColumn))
                    End If
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 5
                    'pdfCell.PaddingLeft = 5.0F
                    'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable2.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("PU", pColumn))
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell = New PdfPCell(New Paragraph("UP", pColumn))
                    End If
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell.MinimumHeight = 5
                    'pdfCell.PaddingLeft = 5.0F
                    pdfTable2.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph("QTE", pColumn))
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell = New PdfPCell(New Paragraph("QTY", pColumn))
                    End If
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
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell4 = New PdfPCell(New Paragraph("TOTAL SALES", pColumn))
                End If
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
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell4 = New PdfPCell(New Paragraph("TOTAL OFFERED", pColumn))
                End If
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
                If GlobalVariable.actualLanguageValue = 0 Then
                    pdfCell4 = New PdfPCell(New Paragraph("NET SALES", pColumn))
                End If
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
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell04 = New PdfPCell(New Paragraph("WALK IN", pColumn))
                    End If
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph("VENTE EN CHAMBRE", pRow1))
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell04 = New PdfPCell(New Paragraph("IN HOUSE", pColumn))
                    End If
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph("OFFRES EN CHAMBRE", pRow1))
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell04 = New PdfPCell(New Paragraph("IN HOUSE OFFER", pColumn))
                    End If
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph("AUTRES OFFRES", pRow1))
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell04 = New PdfPCell(New Paragraph("OTHER OFFER", pColumn))
                    End If
                    pdfCell04.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfCell04.MinimumHeight = 10
                    pdfCell04.Colspan = 2
                    pdfCell04.PaddingLeft = 15.0F
                    pdfTable04.AddCell(pdfCell04)

                    pdfCell04 = New PdfPCell(New Paragraph("VERS COMPTE", pRow1))
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell04 = New PdfPCell(New Paragraph("ACCOUNT", pColumn))
                    End If
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

                If GlobalVariable.actualLanguageValue = 0 Then
                    Dim p002 As Paragraph = New Paragraph(Chr(13) & "Hold at an amount of : " & Functions.NBLTENGLISH(totalDesDesVentes - totalDesDesVentes2) & " " & societe.Rows(0)("CODE_MONNAIE") & Chr(13) & Chr(13), pRow)
                    p002.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p002)

                    pdfDoc.Close()


                Else
                    Dim p002 As Paragraph = New Paragraph(Chr(13) & "Arrêter la présente à la somme de : " & Functions.NBLT(totalDesDesVentes - totalDesDesVentes2) & " " & societe.Rows(0)("CODE_MONNAIE") & Chr(13) & Chr(13), pRow)
                    p002.Alignment = Element.ALIGN_LEFT

                    pdfDoc.Add(p002)

                    pdfDoc.Close()

                End If

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
