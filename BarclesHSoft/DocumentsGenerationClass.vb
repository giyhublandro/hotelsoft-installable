Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Imports System.Net.Mail

Imports MySql.Data.MySqlClient
Imports System.Data.Odbc

Public Class DocumentsGenerationClass

    '1- CONFIRMATION DE RESERVATION
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

        'Dim titreFichier As String = "CONFIRMATION DE RESERVATION DE " & client & " " & Now().ToString("ddMMyyHms")
        Dim titreFichier As String = "CONFIRMATION DE RESERVATION DE " & client & " " & NumConfirmation
        If GlobalVariable.actualLanguageValue = 0 Then
            titreFichier = "BOOKING CONFIRMATION OF " & client & " " & NumConfirmation
        End If
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

        Dim HEBDOMADAIRE As Integer = 0
        Dim HEBDO_MENSUEL As Integer = -1
        Dim CODE_TYPE_CHAMBRE As String = ""

        If infoSupResa.Rows.Count > 0 Then
            DEPOT_DE_GARANTIE = infoSupResa.Rows(0)("DEPOT_DE_GARANTIE")
            CAUTION = infoSupResa.Rows(0)("MONTANT_TOTAL_CAUTION")
            PAX = infoSupResa.Rows(0)("NB_PERSONNES")
            MENSUEL = infoSupResa.Rows(0)("MENSUEL")
            HEBDOMADAIRE = infoSupResa.Rows(0)("HEBDOMADAIRE")
            CODE_TYPE_CHAMBRE = infoSupResa.Rows(0)("TYPE_CHAMBRE")
        End If

        If MENSUEL = 1 Then
            HEBDO_MENSUEL = 1
        ElseIf HEBDOMADAIRE = 1 Then
            HEBDO_MENSUEL = 0
        End If


        If GlobalVariable.actualLanguageValue = 0 Then

            If TypeRea = "salle" Then

                Libelle = "Hall Type :"
                LibelleJour = "Day(s) :"
                libelleMontant = "Montant Location :"

            Else

                If HEBDO_MENSUEL = 0 Then

                    Libelle = "Type Logement : "
                    LibelleJour = "Jour(s) : "
                    libelleMontant = "Loyer Hebdomadaire : "

                ElseIf HEBDO_MENSUEL = 1 Then

                    Libelle = "Type Logement : "
                    LibelleJour = "Day(s) : "
                    libelleMontant = "Loyer Mensuel : "

                Else

                    Libelle = "Room Type : "
                    LibelleJour = "Night(s) : "
                    libelleMontant = "Rate : "

                End If

            End If

        Else


            If TypeRea = "salle" Then

                Libelle = "Type Salle :"
                LibelleJour = "Jour(s) :"
                libelleMontant = "Montant Location :"

            Else

                If HEBDO_MENSUEL = 0 Then

                    Libelle = "Type Logement : "
                    LibelleJour = "Jour(s) : "
                    libelleMontant = "Loyer Hebdomadaire : "

                ElseIf HEBDO_MENSUEL = 1 Then

                    Libelle = "Type Logement : "
                    LibelleJour = "Jour(s) : "
                    libelleMontant = "Loyer Mensuel : "

                Else

                    Libelle = "Type Chambre : "
                    LibelleJour = "Nuitée(s) : "
                    libelleMontant = "Tarif TTC : "

                End If

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

        Dim detail As String = Functions.detailSejourMensuelHebdo(DateDebut, DateFin, HEBDO_MENSUEL)

        pdfCell = New PdfPCell(New Paragraph(NbreNuitee & " (" & detail & ")", font1))
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

        If HEBDO_MENSUEL = 0 Or HEBDO_MENSUEL = 1 Then

            pdfCell = New PdfPCell(New Paragraph("Tarif Journalier : ", font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

            Dim tarifJournalier As Double = Functions.calculJournalierHebdoMensuel(HEBDO_MENSUEL, tarif)

            pdfCell = New PdfPCell(New Paragraph(Format(tarifJournalier, "#,##0") & " " & CODE_MONNAIE, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
            tR1.AddCell(pdfCell)

        End If
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

        If HEBDO_MENSUEL = 0 Or HEBDO_MENSUEL = 1 Then
            MONTANT_HT = MONTANT_TAXE_DE_SEJOUR + Functions.prixSejourMensuelHebdo(CODE_TYPE_CHAMBRE, HEBDO_MENSUEL, DateDebut, DateFin, tarif)
        End If

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

        'kklg

    End Sub

    '2- FICHE DE POLICE
    Public Shared Async Sub GenerationDeFicheDePolice(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, Optional ByVal Email As String = "", Optional ByVal WHATSAPP_OU_MAIL As Integer = 0)

        Dim societe As DataTable = Functions.allTableFields("societe")
        Dim clientInformation As DataTable = Functions.getElementByCode(client, "client", "NOM_PRENOM")
        Dim Reservation As DataTable

        Reservation = Functions.getElementByCode(NumConfirmation, "reservation", "CODE_RESERVATION")

        If Not Reservation.Rows.Count > 0 Then
            Reservation = Functions.getElementByCode(NumConfirmation, "reserve_conf", "CODE_RESERVATION")
        End If

        '------------------------------------------------------------------------------------------------------

        Dim titreFichier As String = "FICHE DE POLICE DE " & client.ToUpper & " " & NumConfirmation

        If GlobalVariable.actualLanguageValue = 0 Then
            titreFichier = "REGISTRATION FORM OF " & client.ToUpper & " " & NumConfirmation
        End If

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

        'kklg

    End Sub

    '3- DEVIS ESTIMATIFS
    Public Shared Async Sub devisEstimatifDeSalleDeFete(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, ByVal EMAIL As String, ByVal TELEPHONE As String, ByVal WHATSAPP_OU_EMAIL As Integer)

        If Not NumConfirmation = "num" Then

            'Dim dlg As New PrintDialog
            'dlg.ShowDialog()

            Dim societe As DataTable = Functions.allTableFields("societe")

            Dim CODE_MONNAIE As String = ""

            If societe.Rows.Count > 0 Then
                CODE_MONNAIE = societe.Rows(0)("CODE_MONNAIE")
            End If

            Dim titreFichier As String = "DEVIS LOCATION SALLE " & client & " " & NumConfirmation
            If GlobalVariable.actualLanguageValue = 0 Then
                titreFichier = "HALL RENTING ESTIMATE OF " & client & " " & NumConfirmation
            End If
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

            If GlobalVariable.actualLanguageValue = 0 Then
                VIDEO_PROJ = "NO"
                SONO = "NO"
                COUVERTS = "NO"
                TABLE_CHAISE = "NO"
                DECORATION = "NO"
                LOCATION_MATERIEL = "NO"
            End If

            If forfaitSalle.Rows.Count > 0 Then

                CODE_EVENEMENT = forfaitSalle.Rows(0)("CODE_EVENEMENT")

                Dim infoSupEvent As DataTable = Functions.getElementByCode(CODE_EVENEMENT, "evenement", "CODE_EVENEMENT")

                If infoSupEvent.Rows.Count > 0 Then
                    EVENEMENT = infoSupEvent.Rows(0)("LIBELLE")
                End If

                If forfaitSalle.Rows(0)("VIDEO_PROJ") = 1 Then
                    VIDEO_PROJ = "OUI"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        VIDEO_PROJ = "YES"
                    End If
                End If

                If forfaitSalle.Rows(0)("SONO") = 1 Then
                    SONO = "OUI"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        SONO = "YES"
                    End If
                End If

                If forfaitSalle.Rows(0)("COUVERTS") = 1 Then
                    COUVERTS = "OUI"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        COUVERTS = "YES"
                    End If
                End If

                If forfaitSalle.Rows(0)("TABLE_CHAISE") = 1 Then
                    TABLE_CHAISE = "OUI"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        TABLE_CHAISE = "YES"
                    End If
                End If

                If forfaitSalle.Rows(0)("DECORATION") > 0 Then
                    DECORATION = "OUI"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        DECORATION = "YES"
                    End If
                End If

                If forfaitSalle.Rows(0)("LOCATION_MATERIEL") > 0 Then
                    LOCATION_MATERIEL = "OUI"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        LOCATION_MATERIEL = "YES"
                    End If
                End If

                If GlobalVariable.actualLanguageValue = 0 Then

                    If MISE_EN_PLACE = 1 Then
                        DISPOSITION = "U"
                    ElseIf MISE_EN_PLACE = 2 Then
                        DISPOSITION = "School"
                    ElseIf MISE_EN_PLACE = 3 Then
                        DISPOSITION = "Theatre"
                    ElseIf MISE_EN_PLACE = 4 Then
                        DISPOSITION = "Rectangular"
                    ElseIf MISE_EN_PLACE = 5 Then
                        DISPOSITION = "Cocktail"
                    ElseIf MISE_EN_PLACE = 6 Then
                        DISPOSITION = "Banquet"
                    End If

                Else

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

                If GlobalVariable.actualLanguageValue = 0 Then
                    Libelle = "Hall Renting"
                    LibelleJour = "Day"
                    LibelleReservation = "ESTIMATE OF HALL RENTING"
                    TitreDuDocument = "ESTIMATE OF HALL RENTING"
                End If

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

            If GlobalVariable.actualLanguageValue = 1 Then
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

            Else

                Dim intro As String = "Client : " & client & Chr(13) & Chr(13)

                pdfDoc.Add(New Paragraph(intro, pColumn))

                Dim p03 As String = "Designation of premises for rent : "
                pdfDoc.Add(New Paragraph(p03, pColumn))

                Dim p3 As String = LIBELLE_CHAMBRE & " whose arrangement will be in " & DISPOSITION & " and located at/at " & societe.Rows(0)("RUE") & " - " & societe.Rows(0)("VILLE") & Chr(13) & Chr(13)
                '& " ainsi que ses dépendances qui sont désignées ci-dessous " & Chr(13) & "• Chambre," & Chr(13) & "• Parking, " & Chr(13) & "• Cave, " & Chr(13) & "• Cambuse, " & Chr(13) & "•	 Cuisine, " & Chr(13) & "• Vestiaires, " & Chr(13) & "• Jardin." & Chr(13) & Chr(13)
                pdfDoc.Add(New Paragraph(p3, font1))

                Dim p8 As String = "Durée : "
                pdfDoc.Add(New Paragraph(p8, font2))

                Dim p9 As String = "From " & DateDebut & " at " & HEURE_ENTREE & " until " & DateFin & " at " & HEURE_DEPART & Chr(13) & Chr(13)
                pdfDoc.Add(New Paragraph(p9, font1))

                Dim p4 As String = "Equipment made available to the lessee" & Chr(13) & Chr(13)
                pdfDoc.Add(New Paragraph(p4, font2))

            End If

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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("EQUIPMENT RENTAL", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("VIDEO PROJECTOR", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("SOUND", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("CUTLERY", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("TABLES + CHAIRS", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                p12 = "Estimate" & Chr(13) & Chr(13)
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("QTY", pColumn))
            End If
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("PU", pColumn))
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("UP", pColumn))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("HALL RENTAL", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("EQUIPMENT RENTAL", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("MISCELLANEOUS", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("COFFEE BREAK", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("LUNCH BREAK", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("DINNER BREAK", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("CATERERS", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("TASTE", font1))
            End If
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
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("SMALL BOTTLE WATER", font1))
            End If
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
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("EAU_PTE_MONTANT")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_PTE_MONTANT") * forfaitSalle.Rows(0)("EAU_PTE_QTE"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("EAU_PTE_MONTANT") * forfaitSalle.Rows(0)("EAU_PTE_QTE")

            '----------------------------------------------------

            '------------------------12----------------------------

            pdfCell = New PdfPCell(New Paragraph("12-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("EAU GRANDE BOUTEILLE", font1))
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("LARGE BOTTLE WATER", font1))
            End If
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
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("EAU_GRDE_MONTANT")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_GRDE_MONTANT") * forfaitSalle.Rows(0)("EAU_GRDE_QTE"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("EAU_GRDE_MONTANT") * forfaitSalle.Rows(0)("EAU_GRDE_QTE")

            '----------------------------------------------------

            '------------------------13----------------------------

            pdfCell = New PdfPCell(New Paragraph("13-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BOISSONS GAZEUSES", font1))
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("SOFT DRINKS", font1))
            End If
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
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT") * forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT") * forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE")

            '----------------------------------------------------

            '------------------------14----------------------------

            pdfCell = New PdfPCell(New Paragraph("14-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BIERES", font1))
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("BEERS", font1))
            End If
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
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BIERES_MONTANT")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BIERES_MONTANT") * forfaitSalle.Rows(0)("BIERES_QTE"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("BIERES_MONTANT") * forfaitSalle.Rows(0)("BIERES_QTE")

            '----------------------------------------------------

            '------------------------15----------------------------

            pdfCell = New PdfPCell(New Paragraph("15-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("VIN ROUGE", font1))
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("RED WINE", font1))
            End If
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
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT") * forfaitSalle.Rows(0)("VIN_ROUGE_QTE"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT") * forfaitSalle.Rows(0)("VIN_ROUGE_QTE")

            '----------------------------------------------------
            '------------------------16----------------------------

            pdfCell = New PdfPCell(New Paragraph("16-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("VIN ROSE", font1))
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("PINK WINE", font1))
            End If
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
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("VIN_ROSE_MONTANT")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROSE_MONTANT") * forfaitSalle.Rows(0)("VIN_ROSE_QTE"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("VIN_ROSE_MONTANT") * forfaitSalle.Rows(0)("VIN_ROSE_QTE")

            '----------------------------------------------------
            '------------------------17----------------------------

            pdfCell = New PdfPCell(New Paragraph("17-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("BOISSONS EXTERIEURES", font1))
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("EXTERNAL DRINKS", font1))
            End If
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
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT")), "#,##0"), font1))
            Else
                pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
            End If

            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT") * forfaitSalle.Rows(0)("BOISSONS_EXT_QTE"), "#,##0"), pColumn))
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            montantTotal += forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT") * forfaitSalle.Rows(0)("BOISSONS_EXT_QTE")

            '----------------------------------------------------

            '------------------------18----------------------------

            pdfCell = New PdfPCell(New Paragraph("18-", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.MinimumHeight = 15
            'pdfCell.PaddingLeft = 5.0F
            'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable01.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("DROIT DE BOUCHON", font1))
            If GlobalVariable.actualLanguageValue = 0 Then
                pdfCell = New PdfPCell(New Paragraph("CORKAGE", font1))
            End If
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
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell = New PdfPCell(New Paragraph("ACCOMMODATION", font1))
                    End If
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
                    If GlobalVariable.actualLanguageValue = 0 Then
                        pdfCell = New PdfPCell(New Paragraph("COLLECTION", font1))
                    End If
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

            If GlobalVariable.actualLanguageValue = 0 Then
                Dim p007 As String = Chr(13) & "Stop at the sum of : " & Functions.NBLTENGLISH(montantTotal).ToUpper & " " & societe.Rows(0)("CODE_MONNAIE")
                pdfDoc.Add(New Paragraph(p007, pColumn))

                pdfDoc.Add(pdfCell)

                Dim p07 As String = Chr(13) & "           CLIENT'S SIGNATURE                                                           HOTEL'S SIGNATURE         "
                pdfDoc.Add(New Paragraph(p07, pColumn))
                pdfDoc.Add(pdfCell)

            Else
                Dim p007 As String = Chr(13) & "Arrêter à la somme de : " & Functions.NBLT(montantTotal).ToUpper & " " & societe.Rows(0)("CODE_MONNAIE")
                pdfDoc.Add(New Paragraph(p007, pColumn))

                pdfDoc.Add(pdfCell)

                Dim p07 As String = Chr(13) & "           SIGNATURE DU CLIENT                                                            SIGNATURE DE L'HOTEL          "
                pdfDoc.Add(New Paragraph(p07, pColumn))
                pdfDoc.Add(pdfCell)

            End If

            '---------------------------------------------------------------------------------------------------------------------------
            pdfDoc.Close()

            'kklg

        End If

    End Sub

    '4- CONTRAT DE LOCATIONDE SALLE
    Public Shared Async Sub contratDeLocationDeSalleDeFete(ByVal NumConfirmation As String, ByVal client As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal NbreNuitee As Integer, ByVal hebergement As String, ByVal Codehebergement As String, ByVal tarif As Double, ByVal HeureEntree As DateTime, ByVal heureDepart As DateTime, ByVal TypeRea As String, ByVal emaiL As String, ByVal TELEPHONE As String, ByVal WHATSAPP_OU_MAIL As Integer)

        Dim titreFichier As String = "CONTRAT DE LOCATION DE SALLE DE " & client & " " & NumConfirmation

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
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("EAU_PTE_MONTANT")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_PTE_MONTANT") * forfaitSalle.Rows(0)("EAU_PTE_QTE"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("EAU_PTE_MONTANT") * forfaitSalle.Rows(0)("EAU_PTE_QTE")

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
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("EAU_GRDE_MONTANT")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("EAU_GRDE_MONTANT") * forfaitSalle.Rows(0)("EAU_GRDE_QTE"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("EAU_GRDE_MONTANT") * forfaitSalle.Rows(0)("EAU_GRDE_QTE")

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
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT") * forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_MONTANT") * forfaitSalle.Rows(0)("BOISSONS_GAZEUSES_QTE")

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
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BIERES_MONTANT")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BIERES_MONTANT") * forfaitSalle.Rows(0)("BIERES_QTE"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("BIERES_MONTANT") * forfaitSalle.Rows(0)("BIERES_QTE")

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
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT") * forfaitSalle.Rows(0)("VIN_ROUGE_QTE"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("VIN_ROUGE_MONTANT") * forfaitSalle.Rows(0)("VIN_ROUGE_QTE")

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
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("VIN_ROSE_MONTANT")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("VIN_ROSE_MONTANT") * forfaitSalle.Rows(0)("VIN_ROSE_QTE"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("VIN_ROSE_MONTANT") * forfaitSalle.Rows(0)("VIN_ROSE_QTE")

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
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT")), "#,##0"), font1))
        Else
            pdfCell = New PdfPCell(New Paragraph(Format(Math.Round(0), "#,##0"), font1))
        End If

        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph(Format(forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT") * forfaitSalle.Rows(0)("BOISSONS_EXT_QTE"), "#,##0"), pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfCell.MinimumHeight = 15
        'pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable01.AddCell(pdfCell)

        montantTotal += forfaitSalle.Rows(0)("BOISSONS_EXT_MONTANT") * forfaitSalle.Rows(0)("BOISSONS_EXT_QTE")

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

        'kklg

    End Sub

    '5- FACTURES / REGLEMENTS
    Public Shared Sub DocumentFactureToSend(ByVal ElementToDuplicate As String, ByVal Table As String, ByVal ColumnTitle As String, ByVal client As String, Optional ByVal reservationNum As String = "", Optional ByVal WHATSAPP_OU_EMAIL As Integer = 2)

        Dim titreFichier As String = ""

        Dim nomDuDossierRapport As String = ""

        If GlobalVariable.DocumentToGenerate = "facture" Then
            nomDuDossierRapport = "ENVOI\FACTURES"
            titreFichier = "Facture de " & GlobalVariable.ClientToUpdate.Rows(0)("NOM_PRENOM") & " " & (Date.Now().ToString("ddMMyyHHmmss"))

        Else
            nomDuDossierRapport = "ENVOI\RECUS"
            titreFichier = "Recu de " & GlobalVariable.ClientToUpdate.Rows(0)("NOM_PRENOM") & " " & (Date.Now().ToString("ddMMyyHHmmss"))
        End If

        Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.ToString("ddMMyy")
        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim TELEPHONE As String = GlobalVariable.ClientToUpdate.Rows(0)("TELEPHONE")
        Dim EMAIL As String = GlobalVariable.ClientToUpdate.Rows(0)("EMAIL")

        Dim fichier As String = filePathAndDirectory & "\" & titreFichier & ".pdf"

        Dim societe As DataTable = Functions.allTableFields("societe")
        Dim TotalFacture As Double = 0
        'Dim totalNormal As Double = 0
        Dim totalTVA As Double = 0
        Dim TAxeSejour As Double = 0
        Dim SoldeNet As Double = 0
        Dim TotalVersement As Double = 0

        Dim dt As DataTable
        Dim elements As DataTable
        Dim dtReg As DataTable

        Dim tousLesElemetsDeFacture As New DataTable()

        tousLesElemetsDeFacture.Columns.Add("DATE_ELEMENT", GetType(Date))
        tousLesElemetsDeFacture.Columns.Add("LIBELLE")
        tousLesElemetsDeFacture.Columns.Add("QUANTITE")
        tousLesElemetsDeFacture.Columns.Add("MONTANT")

        Dim tireDocument As String = ""

        Dim exonere As Boolean = False

        Dim CODE_RESERVATION As String = ""
        Dim Date_facture_reglement As Date
        Dim infoSupFacture As DataTable

        Dim CODE_FACTURE_REGLEMENT As String = ElementToDuplicate

        If Not Trim(GlobalVariable.codeReservationToUpdate).Equals("") Then
            'SI LE CODE DE RESERVATION EXISTE
            exonere = Functions.exonereDelaTVAComplet(GlobalVariable.codeReservationToUpdate)
        Else

            'SI LE CODE DE RESERVATION N'EXISTE PAS ON DOIT LE TROUVER DANS LA RESERVATIONS


            infoSupFacture = Functions.getElementByCode(CODE_FACTURE_REGLEMENT, "facture", "CODE_FACTURE")

            If infoSupFacture.Rows.Count > 0 Then
                CODE_RESERVATION = infoSupFacture.Rows(0)("CODE_RESERVATION")
                exonere = Functions.exonereDelaTVAComplet(CODE_RESERVATION)
                Date_facture_reglement = infoSupFacture.Rows(0)("DATE_FACTURE")
            End If

        End If

        If GlobalVariable.DocumentToGenerate = "facture" Then
            infoSupFacture = Functions.getElementByCode(CODE_FACTURE_REGLEMENT, "facture", "CODE_FACTURE")
            If infoSupFacture.Rows.Count > 0 Then
                Date_facture_reglement = infoSupFacture.Rows(0)("DATE_FACTURE")
                CODE_RESERVATION = infoSupFacture.Rows(0)("CODE_RESERVATION")
            End If
        Else
            infoSupFacture = Functions.getElementByCode(CODE_FACTURE_REGLEMENT, "reglement", "NUM_REGLEMENT")
            If infoSupFacture.Rows.Count > 0 Then
                Date_facture_reglement = infoSupFacture.Rows(0)("DATE_REGLEMENT")
                CODE_RESERVATION = infoSupFacture.Rows(0)("CODE_RESERVATION")
            End If
        End If

        If GlobalVariable.DocumentToGenerate = "facture" Then

            tireDocument = "FACTURE N° : "
            'titreFichier = "FACTURE DE "

            dt = Functions.GetAllElementsOnCondition(ElementToDuplicate, "ligne_facture", "CODE_FACTURE")

            dtReg = Functions.GetAllElementsOnCondition(ElementToDuplicate, "reglement", "NUM_FACTURE")

            For i = 0 To dt.Rows.Count - 1

                Dim LIBELLE As String = dt.Rows(i)("LIBELLE_FACTURE").ToString.ToUpper()

                If Not LIBELLE.Contains("TAXE DE SEJOUR") Then
                    'TotalFacture += Functions.prelevementDeTaxeSurUnMontant(dt.Rows(i)("MONTANT_TTC")) 'calcul de la somme apres prelevement de la taxe
                    TotalFacture += Functions.NonprelevementDeTaxeSurUnMontant(dt.Rows(i)("MONTANT_TTC")) 'calcul de la somme apres prelevement de la taxe
                    totalTVA += Functions.prelevementDeTaxeSurUnMontantPOurCalcul(dt.Rows(i)("MONTANT_TTC")) 'calcul de la somme des taxes prelevees
                Else

                    If LIBELLE.Contains("TAXE DE SEJOUR") Then
                        TAxeSejour += Functions.NonprelevementDeTaxeSurUnMontant(dt.Rows(i)("MONTANT_TTC"))
                    End If

                End If

                tousLesElemetsDeFacture.Rows.Add(CDate(dt.Rows(i)("DATE_FACTURE")).ToShortDateString, dt.Rows(i)("LIBELLE_FACTURE").ToString, dt.Rows(i)("QUANTITE"), dt.Rows(i)("MONTANT_TTC"))

                'TotalFacture += prelevementDeTaxeSurUnMontant(dt.Rows(i)("MONTANT_TTC"))
                'totalTVA += prelevementDeTaxeSurUnMontantPOurCalcul(dt.Rows(i)("MONTANT_TTC"))
                'totalNormal += totalNormal + dt.Rows(i)("MONTANT_TTC")

            Next

            If exonere Then
                totalTVA = 0
            End If

            If dtReg.Rows.Count > 0 Then

                Dim n As Integer = 0

                For i = 0 To dtReg.Rows.Count - 1

                    TotalVersement += Functions.NonprelevementDeTaxeSurUnMontant(dtReg.Rows(i)("MONTANT_VERSE"))

                    n = i + 1

                    tousLesElemetsDeFacture.Rows.Add(CDate(dtReg.Rows(i)("DATE_REGLEMENT").ToShortDateString), dtReg.Rows(i)("REF_REGLEMENT").ToString, dtReg.Rows(i)("QUANTITE"), dtReg.Rows(i)("MONTANT_VERSE") * -1)

                Next

            End If

        ElseIf GlobalVariable.DocumentToGenerate = "reglement" Then

            tireDocument = "RECU N° : "

            dtReg = Functions.GetAllElementsOnCondition(ElementToDuplicate, "reglement", "NUM_REGLEMENT")

            If dtReg.Rows.Count > 0 Then

                Dim n As Integer = 0

                For i = 0 To dtReg.Rows.Count - 1

                    TotalFacture += dtReg.Rows(i)("MONTANT_VERSE")

                    tousLesElemetsDeFacture.Rows.Add(CDate(dtReg.Rows(i)("DATE_REGLEMENT").ToShortDateString), dtReg.Rows(i)("REF_REGLEMENT").ToString, dtReg.Rows(i)("QUANTITE"), dtReg.Rows(i)("MONTANT_VERSE"))

                Next

            End If

        End If

        If tousLesElemetsDeFacture.Rows.Count > 0 Then
            'REORGANISATION PAR ORDRE DE DATE DECROISSANTE
            elements = Functions.chargementTemporaireDesElementsDeFacturePourImpression(tousLesElemetsDeFacture)
        End If

        Dim nomClient As String = ""

        Dim reservationToPrint As DataTable = Functions.getElementByCode(reservationNum, "reserve_conf", "CODE_RESERVATION")

        If reservationToPrint.Rows.Count > 0 Then

            If Not Trim(GlobalVariable.ReservationToUpdate(0)("CODE_ENTREPRISE")) = "" Then
                nomClient = GlobalVariable.ReservationToUpdate(0)("NOM_ENTREPRISE") & " ( " & GlobalVariable.ReservationToUpdate(0)("NOM_CLIENT") & " )"
            ElseIf Functions.getElementByCode(client, "client", "CODE_CLIENT").Rows.Count > 0 Then
                nomClient = Functions.getElementByCode(client, "client", "CODE_CLIENT").Rows(0)("NOM_PRENOM")
            End If

        Else

            If Functions.getElementByCode(client, "client", "CODE_CLIENT").Rows.Count > 0 Then
                nomClient = Functions.getElementByCode(client, "client", "CODE_CLIENT").Rows(0)("NOM_PRENOM")
            End If

        End If

        Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 40)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(fichier, FileMode.Create))

        Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim fontTotal As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font1 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        Dim pdfTable As New PdfPTable(4) 'Number of columns
        pdfTable.TotalWidth = 530.0F
        pdfTable.LockedWidth = True
        pdfTable.HorizontalAlignment = Element.ALIGN_RIGHT
        pdfTable.HeaderRows = 1

        Dim widths As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}

        pdfTable.SetWidths(widths)

        Dim pdfCell As PdfPCell = Nothing

        pdfWrite.PageEvent = New HeaderFooter

        pdfDoc.Open()

        Dim dateArrivee As Date
        Dim dateDepart As Date

        Dim p10 As Paragraph
        Dim infoSupResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")
        If infoSupResa.Rows.Count > 0 Then
            dateArrivee = infoSupResa.Rows(0)("DATE_ENTTRE")
            dateDepart = infoSupResa.Rows(0)("DATE_SORTIE")
            p10 = New Paragraph(Chr(13) & Chr(13) & Chr(13) & tireDocument & ElementToDuplicate & Chr(13) & "DATE : " & Date_facture_reglement & Chr(13) & "Date arrivée : " & dateArrivee.ToShortDateString & Chr(13) & "Date départ : " & dateDepart.ToShortDateString & Chr(13), pColumn)
        Else
            p10 = New Paragraph(Chr(13) & Chr(13) & Chr(13) & tireDocument & ElementToDuplicate & Chr(13) & "DATE : " & Date_facture_reglement & Chr(13), pColumn)
        End If

        p10.Alignment = Element.ALIGN_LEFT

        pdfDoc.Add(p10)

        Dim termes As String = ""

        Dim clientInformation As DataTable

        'If GlobalVariable.typeDeClientAFacturer = "en chambre" Then

        'SI ON TRAITE UNE RESERVATION

        If Not Trim(reservationNum).Equals("") Then

            If Not Trim(GlobalVariable.ReservationToUpdate(0)("CODE_ENTREPRISE")) = "" Then
                clientInformation = Functions.getElementByCode(GlobalVariable.ReservationToUpdate(0)("CODE_ENTREPRISE"), "client", "CODE_CLIENT")
            Else
                clientInformation = Functions.getElementByCode(client, "client", "CODE_CLIENT")
            End If

            If Not Trim(GlobalVariable.ReservationToUpdate(0)("CODE_ENTREPRISE")) = "" Then

                If clientInformation.Rows.Count > 0 Then

                    termes = Chr(13) & "NOM DU CLIENT : " & clientInformation.Rows(0)("NOM_PRENOM") & "(" & GlobalVariable.ReservationToUpdate(0)("NOM_CLIENT") & ")" & Chr(13) & clientInformation.Rows(0)("NOM_JEUNE_FILLE") & Chr(13) & clientInformation.Rows(0)("PRENOMS") & Chr(13) & "CHAMBRE N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION N° : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13)

                End If

            Else

                If clientInformation.Rows.Count > 0 Then

                    termes = Chr(13) & "NOM DU CLIENT : " & nomClient & Chr(13) & "CHAMBRE N° : " & GlobalVariable.ReservationToUpdate(0)("CHAMBRE_ID") & Chr(13) & "RESERVATION N° : " & GlobalVariable.codeReservationToUpdate & Chr(13) & Chr(13)

                End If

            End If

        Else
            termes = Chr(13) & "NOM DU CLIENT : " & nomClient & Chr(13) & Chr(13)
        End If

        pdfDoc.Add(New Paragraph(termes, pRow))

        pdfCell = New PdfPCell(New Paragraph("DATE", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("DESIGNATION", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("QTE", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("TOTAL", pColumn))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.MinimumHeight = 15
        pdfCell.PaddingLeft = 5.0F
        'pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY
        pdfTable.AddCell(pdfCell)

        If tousLesElemetsDeFacture.Rows.Count > 0 Then

            For i = 0 To tousLesElemetsDeFacture.Rows.Count - 1

                If GlobalVariable.DocumentToGenerate = "facture" Then

                    pdfCell = New PdfPCell(New Paragraph(CDate(elements.Rows(i)("DATE_ELEMT")).ToShortDateString, font1))
                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(elements.Rows(i)("LIBELLE_ELEMENT"), font1))
                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Format(elements.Rows(i)("QUANTITE"), "#,##0"), font1))
                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfCell)

                    'On ne preleve pas de taxe sur les taxes de sejours

                    Dim LIBELLE_TAXE As String = "TAXE DE SEJOUR"
                    Dim LIBELLE_FACTURE As String = elements.Rows(i)("LIBELLE_ELEMENT").ToString.ToUpper()

                    If Not LIBELLE_FACTURE.Contains(LIBELLE_TAXE) Then
                        'pdfCell = New PdfPCell(New Paragraph(Format(prelevementDeTaxeSurUnMontant(dt.Rows(i)("MONTANT_TTC") * -1), "#,##0"), font1))
                        pdfCell = New PdfPCell(New Paragraph(Format(Functions.NonprelevementDeTaxeSurUnMontant(elements.Rows(i)("MONTANT") * -1), "#,##0"), font1))
                    Else
                        pdfCell = New PdfPCell(New Paragraph(Format(Functions.NonprelevementDeTaxeSurUnMontant(elements.Rows(i)("MONTANT") * -1), "#,##0"), font1))
                    End If

                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfTable.AddCell(pdfCell)

                ElseIf GlobalVariable.DocumentToGenerate = "reglement" Then

                    pdfCell = New PdfPCell(New Paragraph(CDate(elements.Rows(i)("DATE_ELEMT")).ToShortDateString, font1))
                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(elements.Rows(i)("LIBELLE_ELEMENT"), font1))
                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Format(elements.Rows(i)("QUANTITE"), "#,##0"), font1))
                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfCell)

                    pdfCell = New PdfPCell(New Paragraph(Format(elements.Rows(i)("MONTANT"), "#,##0"), font1))
                    pdfCell.MinimumHeight = 15
                    pdfCell.PaddingLeft = 5.0F
                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfTable.AddCell(pdfCell)

                End If

            Next

            pdfDoc.Add(pdfTable)

            If GlobalVariable.DocumentToGenerate = "reglement" Then

                '------------------------------------------------------------------------

                Dim pdfTable2 As New PdfPTable(4) 'Number of columns

                pdfTable2.TotalWidth = 530.0F
                pdfTable2.LockedWidth = True
                pdfTable2.HorizontalAlignment = Element.ALIGN_RIGHT
                'pdfTable2.HeaderRows = 1

                'Dim widths2 As Single() = New Single() {5.8F, 1.8F}
                Dim widths2 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                pdfTable2.SetWidths(widths2)

                Dim pdfCell2 As PdfPCell = Nothing

                If GlobalVariable.DocumentToGenerate = "reglement" Then
                    pdfCell2 = New PdfPCell(New Paragraph(Chr(13) & "TOTAL : ", fontTotal))
                Else
                    pdfCell2 = New PdfPCell(New Paragraph(Chr(13) & "TOTAL HT : ", fontTotal))
                End If

                pdfCell2.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell2.MinimumHeight = 18
                pdfCell2.PaddingLeft = 15.0F
                pdfCell2.Border = 0
                pdfCell2.Colspan = 3

                pdfTable2.AddCell(pdfCell2)

                pdfCell2 = New PdfPCell(New Paragraph(Chr(13) & Format(TotalFacture, "#,##0"), fontTotal))
                pdfCell2.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell2.MinimumHeight = 18
                pdfCell2.PaddingLeft = 5.0F
                pdfCell2.Border = 0
                pdfTable2.AddCell(pdfCell2)

                pdfDoc.Add(pdfTable2)

                '-----------------------------------

            End If

            If Not GlobalVariable.DocumentToGenerate = "reglement" Then

                Dim TVA As Double = 0

                If Not exonere Then

                    If societe.Rows(0)("TAUX_TVA") > 0 Then
                        TVA = totalTVA
                    Else
                        TVA = 0
                    End If

                End If


                '----------------------------- TOTAL HT -----------------------------------
                Dim pdfTable06 As New PdfPTable(4)

                pdfTable06.TotalWidth = 530.0F
                pdfTable06.LockedWidth = True
                pdfTable06.HorizontalAlignment = Element.ALIGN_RIGHT

                Dim widths06 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                pdfTable06.SetWidths(widths06)

                Dim pdfCell06 As PdfPCell = Nothing

                '------------------------------ DEBUT RECAPITULATIF OU BILAN ------------------------------------

                pdfCell06 = New PdfPCell(New Paragraph("", fontTotal))
                pdfCell06.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell06.MinimumHeight = 18
                pdfCell06.PaddingLeft = 15.0F
                pdfCell06.Colspan = 4
                pdfCell06.Border = 0
                pdfTable06.AddCell(pdfCell06)

                pdfCell06 = New PdfPCell(New Paragraph("TOTAL HT : ", fontTotal))
                pdfCell06.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell06.MinimumHeight = 18
                pdfCell06.PaddingLeft = 15.0F
                pdfCell06.Colspan = 3
                pdfCell06.Border = 0
                pdfTable06.AddCell(pdfCell06)

                Dim TAXE_SEJOUR As Double = 0

                pdfCell06 = New PdfPCell(New Paragraph(Format(TotalFacture - TVA, "#,##0"), fontTotal))
                pdfCell06.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell06.MinimumHeight = 18
                pdfCell06.PaddingLeft = 5.0F
                pdfCell06.Border = 0
                pdfTable06.AddCell(pdfCell06)

                pdfDoc.Add(pdfTable06)

                '--------------------------------------------------------------------------

                If TAxeSejour >= 0 Then

                    '-----------------------------------

                    Dim pdfTable6 As New PdfPTable(4) 'Number of columns

                    pdfTable6.TotalWidth = 530.0F
                    pdfTable6.LockedWidth = True
                    pdfTable6.HorizontalAlignment = Element.ALIGN_RIGHT
                    'pdfTable4.HeaderRows = 1

                    Dim widths6 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                    pdfTable6.SetWidths(widths6)

                    Dim pdfCell6 As PdfPCell = Nothing

                    pdfCell6 = New PdfPCell(New Paragraph("TAXE DE SEJOURS : ", fontTotal))
                    pdfCell6.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell6.MinimumHeight = 18
                    pdfCell6.PaddingLeft = 15.0F
                    pdfCell6.Colspan = 3
                    pdfCell6.Border = 0
                    pdfTable6.AddCell(pdfCell6)

                    'Dim TAXE_SEJOUR As Double = 0

                    pdfCell6 = New PdfPCell(New Paragraph(Format(TAxeSejour, "#,##0"), fontTotal))
                    pdfCell6.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell6.MinimumHeight = 18
                    pdfCell6.PaddingLeft = 5.0F
                    pdfCell6.Border = 0
                    pdfTable6.AddCell(pdfCell6)

                    pdfDoc.Add(pdfTable6)

                    '-----------------------------------
                End If

                If TVA > 0 Then

                    Dim pdfTable4 As New PdfPTable(4) 'Number of columns

                    pdfTable4.TotalWidth = 530.0F
                    pdfTable4.LockedWidth = True
                    pdfTable4.HorizontalAlignment = Element.ALIGN_RIGHT
                    'pdfTable4.HeaderRows = 1

                    Dim widths4 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                    pdfTable4.SetWidths(widths4)

                    Dim pdfCell4 As PdfPCell = Nothing

                    pdfCell4 = New PdfPCell(New Paragraph("TVA : ", fontTotal))
                    pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell4.MinimumHeight = 18
                    pdfCell4.PaddingLeft = 15.0F
                    pdfCell4.Border = 0
                    pdfCell4.Colspan = 3
                    pdfTable4.AddCell(pdfCell4)

                    pdfCell4 = New PdfPCell(New Paragraph(Format(TVA, "#,##0"), fontTotal))
                    pdfCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell4.MinimumHeight = 18
                    pdfCell4.PaddingLeft = 5.0F
                    pdfCell4.Border = 0
                    pdfTable4.AddCell(pdfCell4)

                    pdfDoc.Add(pdfTable4)


                    Dim pdfTable3 As New PdfPTable(4) 'Number of columns

                    pdfTable3.TotalWidth = 530.0F
                    pdfTable3.LockedWidth = True
                    pdfTable3.HorizontalAlignment = Element.ALIGN_RIGHT
                    'pdfTable3.HeaderRows = 1

                    Dim widths3 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                    pdfTable3.SetWidths(widths3)

                    Dim pdfCell3 As PdfPCell = Nothing

                    pdfCell3 = New PdfPCell(New Paragraph("", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph("----------------", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    'pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph("TOTAL TTC : ", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph(Format(TotalFacture + TAxeSejour, "#,##0"), fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 5.0F
                    pdfCell3.Border = 0
                    pdfTable3.AddCell(pdfCell3)

                    pdfDoc.Add(pdfTable3)

                    '---------------------------------------END INFO TVA --------------------------

                Else

                    '-----------------------------------
                    Dim pdfTable3 As New PdfPTable(4) 'Number of columns

                    pdfTable3.TotalWidth = 530.0F
                    pdfTable3.LockedWidth = True
                    pdfTable3.HorizontalAlignment = Element.ALIGN_RIGHT
                    'pdfTable3.HeaderRows = 1

                    Dim widths3 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                    pdfTable3.SetWidths(widths3)

                    Dim pdfCell3 As PdfPCell = Nothing

                    pdfCell3 = New PdfPCell(New Paragraph("", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph("----------------", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    'pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph("TOTAL : ", fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 15.0F
                    pdfCell3.Border = 0
                    pdfCell3.Colspan = 3
                    pdfTable3.AddCell(pdfCell3)

                    pdfCell3 = New PdfPCell(New Paragraph(Format(TotalFacture + TAxeSejour, "#,##0"), fontTotal))
                    pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    pdfCell3.MinimumHeight = 18
                    pdfCell3.PaddingLeft = 5.0F
                    pdfCell3.Border = 0
                    pdfTable3.AddCell(pdfCell3)

                    pdfDoc.Add(pdfTable3)

                End If

                Dim pdfTable7 As New PdfPTable(4) 'Number of columns

                pdfTable7.TotalWidth = 530.0F
                pdfTable7.LockedWidth = True
                pdfTable7.HorizontalAlignment = Element.ALIGN_RIGHT
                'pdfTable7.HeaderRows = 1

                Dim widths7 As Single() = New Single() {1.3F, 6.5F, 0.6F, 1.5F}
                pdfTable7.SetWidths(widths7)

                Dim pdfCell7 As PdfPCell = Nothing

                SoldeNet = TotalVersement - (TotalFacture + TAxeSejour)

                Dim terme As String = ""

                If SoldeNet > 0 Then
                    terme = "FAVEUR CLIENT : "
                ElseIf SoldeNet = 0 Then
                    terme = "SOLDE NUL : "
                ElseIf 0 > SoldeNet Then
                    terme = "A REGLER : "
                End If

                pdfCell7 = New PdfPCell(New Paragraph(terme, fontTotal))
                pdfCell7.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell7.MinimumHeight = 18
                pdfCell7.PaddingLeft = 15.0F
                pdfCell7.Colspan = 3
                pdfCell7.Border = 0
                pdfTable7.AddCell(pdfCell7)

                If SoldeNet < 0 Then
                    'SoldeNet *= -1
                End If

                pdfCell7 = New PdfPCell(New Paragraph(Format(SoldeNet, "#,##0"), fontTotal))
                pdfCell7.HorizontalAlignment = Element.ALIGN_RIGHT
                pdfCell7.MinimumHeight = 18
                pdfCell7.PaddingLeft = 5.0F
                pdfCell7.Border = 0
                pdfTable7.AddCell(pdfCell7)

                pdfDoc.Add(pdfTable7)

                '----------------------------------------

                Dim chiffreEnLettre = New Paragraph(Chr(13) & Chr(13) & "Arrêter la présente à la somme de : " & Functions.NBLT(TotalFacture + TAxeSejour) & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), pRow)

                pdfDoc.Add(chiffreEnLettre)

                ' -----------------------------------------------------------------------------------------------------
                Dim p2 As Paragraph = New Paragraph(Chr(13) & Chr(13) & "SIGNATURE DU CLIENT                                                    SIGNATURE DE L'HOTEL")
                p2.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p2)

            Else

                Dim chiffreEnLettre = New Paragraph(Chr(13) & Chr(13) & "Reçu la somme de : " & Functions.NBLT(TotalFacture + TAxeSejour) & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE"), pRow)

                pdfDoc.Add(chiffreEnLettre)

                Dim p2 As Paragraph = New Paragraph(Chr(13) & Chr(13) & "                                                                        SIGNATURE DU CLIENT")
                p2.Alignment = Element.ALIGN_CENTER

                pdfDoc.Add(p2)

            End If

        End If


        ' ------------------------------------------------------------------------------------------------

        pdfDoc.Close()

        'kklg

    End Sub

End Class
