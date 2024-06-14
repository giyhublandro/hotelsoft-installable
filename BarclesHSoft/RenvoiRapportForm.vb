Imports MySql.Data.MySqlClient



Public Class RenvoiRapportForm

    Public Class ArgumentType

        'action = 0 : ultrMessageSimpleText
        Public action As Integer
        Public whatsAppMessage As String
        Public mobile_number As String
        Public dt As DataTable
        Public DateDebut As Date
        Public DateFin As Date
        Public fichier As String

    End Class

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaCheckBoxTousCocher_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTousCocher.CheckedChanged

        If GunaCheckBoxTousCocher.Checked Then
            GunaCheckBoxMaincouranteJournaliere.Checked = True
            GunaCheckBoxMaincouranteCumule.Checked = True
        Else
            GunaCheckBoxMaincouranteJournaliere.Checked = False
            GunaCheckBoxMaincouranteCumule.Checked = False
        End If

    End Sub

    Private Sub GunaButtonEnvoyer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnvoyer.Click

        'MAINCOURANTE JOURNALIERE

        Dim DateDebut As Date = GunaDateTimePickerDateMainCouranteJournaliere.Value.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GunaDateTimePickerDateMainCouranteJournaliere.Value.ToString("yyyy-MM-dd")

        'MAINCOURANTE JOURNALIERE CUMULE
        Dim DateDebut_1 As Date = GunaDateTimePickerMCCDu.Value.ToString("yyyy-MM-dd")
        Dim DateFin_1 As Date = GunaDateTimePickerMCCAu.Value.ToString("yyyy-MM-dd")

        Dim changerSigne As Integer = -1

        If GunaCheckBoxMaincouranteJournaliere.Checked Then

            Dim dtRapport As DataTable = Functions.verificationExistenceCheminDesRapportsDuJours(DateDebut)
            Dim fichier As String = ""

            Dim args As ArgumentType = New ArgumentType()
            args.action = 1
            'args.dt = dt
            args.DateDebut = DateDebut
            args.DateFin = DateFin

            If dtRapport.Rows.Count > 0 Then

                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                    If dtRapport.Rows(0)("CHEMIN_MAINCOURANTE").Equals("") Then

                        Dim document As Integer = 1
                        Functions.docMainCourante(dt, DateDebut, DateFin, document)

                    End If

                End If

                backGroundWorkerToCall(args)

            Else

                Dim chambre_salle As String = "chambre"
                CloturerForm.ListeDesMainCourantesDujours(DateDebut, DateFin, chambre_salle)

                Dim DATE_TRAVAIL As Date = DateDebut
                Dim insertQuery As String = "INSERT INTO `rapport_auto` (`DATE_TRAVAIL`) VALUES (@DATE_TRAVAIL)"
                Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
                command.Parameters.Add("@DATE_TRAVAIL", MySqlDbType.Date).Value = DATE_TRAVAIL
                command.ExecuteNonQuery()

                Dim document As Integer = 1
                Functions.docMainCourante(CloturerForm.dt, DateDebut, DateFin, document)

                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                    backGroundWorkerToCall(args)
                End If

            End If

        End If

        If GunaCheckBoxMaincouranteCumule.Checked Then

            Me.Cursor = Cursors.WaitCursor

            Dim dt As New DataTable()

            dt.Columns.Add("CHAMBRE")
            dt.Columns.Add("NOM_PRENOM")
            dt.Columns.Add("ARRIVEE")
            dt.Columns.Add("DEPART")
            dt.Columns.Add("NUITEE")
            dt.Columns.Add("NBRE_PAX")
            dt.Columns.Add("HEBERGEMENT")
            dt.Columns.Add("TAXE")
            dt.Columns.Add("PDJ")
            dt.Columns.Add("DEJEUNER")
            dt.Columns.Add("DINER")
            dt.Columns.Add("BAR")
            dt.Columns.Add("BLANCHISSERIE")
            dt.Columns.Add("AUTRES")
            dt.Columns.Add("RECETTE_DU_JOUR") 'TOTAL DU JOUR
            dt.Columns.Add("REPORT_VEILLE")
            dt.Columns.Add("TOTAL_GENERAL")
            dt.Columns.Add("ESPECES")
            dt.Columns.Add("CARTE")
            dt.Columns.Add("MOBILE_MONEY")
            dt.Columns.Add("A_REPORTER")
            dt.Columns.Add("CODE_RESERVATION")

            Dim getDistinctClient As String = "SELECT * FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateFin_1.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut_1.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

            Dim command0 As New MySqlCommand(getDistinctClient, GlobalVariable.connect)

            command0.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

            Dim adapter0 As New MySqlDataAdapter(command0)

            Dim reservation As New DataTable()

            adapter0.Fill(reservation)

            If reservation.Rows.Count > 0 Then

                '------------------ ADD COLUMNS --------------------

                '------------------ FAILED COLUMNS -----------------

                For j = 0 To reservation.Rows.Count - 1

                    Dim getUserQuery1 = "SELECT NUM_RESERVATION, ARRHES, DATE_MAIN_COURANTE, main_courante_journaliere.NOM_CLIENT As 'NOM & PRENOM',  PDJ, DEJEUNER, DINER,CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_journaliere.NUM_RESERVATION As 'RESERVATION', main_courante_journaliere.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_journaliere.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_journaliere.SERVICES AS 'SERVICES', main_courante_journaliere.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_journaliere.BOUTIQE AS 'BOUTIQUE', main_courante_journaliere.CYBERCAFE As 'BUSINESS CENTER', main_courante_journaliere.SPORTS As 'SPORTS' , main_courante_journaliere.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_journaliere.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_journaliere.BLANCHISSERIE As BLANCHISSERIE, main_courante_journaliere.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER', TAUX_OCCUPATION_PCT As 'TAXE DE SEJOUR' FROM main_Courante_journaliere WHERE DATE_MAIN_COURANTE <= '" & DateFin_1.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateDebut_1.ToString("yyyy-MM-dd") & "' AND main_Courante_journaliere.NUM_RESERVATION = @NUM_RESERVATION ORDER BY CODE_CHAMBRE ASC"

                    Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)

                    command1.Parameters.Add("@NUM_RESERVATION", MySqlDbType.VarChar).Value = reservation.Rows(j)("CODE_RESERVATION")

                    Dim adapter1 As New MySqlDataAdapter(command1)

                    Dim table As New DataTable()

                    adapter1.Fill(table)

                    If table.Rows.Count > 0 Then

                        'POUR CHAQUE NOUVELLE RESERVATION 

                        Dim NUITEES As Integer = 0
                        Dim PAX As Integer = 0
                        Dim AUTRES_VENTE As Double = 0
                        Dim TOTAL_RECETTE As Double = 0
                        Dim HEBERGEMENT As Double = 0
                        Dim PDJ As Double = 0
                        Dim DEJEUNER As Double = 0
                        Dim DINER As Double = 0
                        Dim BAR As Double = 0
                        Dim RECETTE_DU_JOUR As Double = 0
                        Dim REPORT_VEILLE As Double = 0
                        Dim BLANCHISSERIE As Double = 0
                        Dim TOTAL_GENERAL As Double = 0
                        Dim ESPECES As Double = 0
                        Dim CARTE_CREDIT As Double = 0
                        Dim MOBILE_MONEY As Double = 0
                        Dim A_REPORTER As Double = 0
                        Dim TAXE As Double = 0
                        Dim RESTAURANT As Double = 0
                        Dim taxeDeSejours As Double = 0
                        Dim TOTAL_ENCAISSEMENT As Double = 0

                        Dim ARRHES As Double = 0
                        Dim CHEQUE As Double = 0

                        Dim RETRANCHEMENTHEBERGEMENT As Double = 0
                        Dim RETRANCHEMENTTAXEDESEJOUR As Double = 0

                        Dim arrivee As Date = CDate(reservation.Rows(j)("DATE_ENTTRE")).ToShortDateString
                        Dim depart As Date = CDate(reservation.Rows(j)("DATE_SORTIE")).ToShortDateString

                        NUITEES = CType((depart - arrivee).TotalDays, Int64)

                        PAX = reservation.Rows(j)("NB_PERSONNES")

                        If PAX <= 0 Then
                            PAX = 1
                        End If

                        For i = 0 To table.Rows.Count - 1

                            '----------------------------------------------------- NEW ------------------------------------------------------------------

                            PDJ += table.Rows(i)("PDJ")
                            DEJEUNER += table.Rows(i)("DEJEUNER")
                            DINER += table.Rows(i)("DINER")

                            RESTAURANT += table.Rows(i)("PDJ") + table.Rows(i)("DEJEUNER") + table.Rows(i)("DINER")
                            BAR += table.Rows(i)("CAFE") + table.Rows(i)("CAVE") + table.Rows(i)("DIVERS")

                            'Dim RESTAURANT As Double = table.Rows(i)("CAVE") + table.Rows(i)("DIVERS") + table.Rows(i)("CAFE")

                            AUTRES_VENTE += table.Rows(i)("SERVICES") + table.Rows(i)("SALON DE BEAUTE") + table.Rows(i)("BOUTIQUE") + table.Rows(i)("BUSINESS CENTER") + table.Rows(i)("SPORTS") + table.Rows(i)("LOISIRS") + table.Rows(i)("JOURNAUX") + table.Rows(i)("AUTRES")

                            'Dim dateTravail As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
                            Dim dateMainCourante As Date = table.Rows(i)("DATE_MAIN_COURANTE").ToShortDateString

                            HEBERGEMENT += table.Rows(i)("HEBERGEMENT")
                            taxeDeSejours += table.Rows(i)("TAXE DE SEJOUR")

                            'CALCUL DU SEJOURS ECOULE

                            ' If dateTravail <= depart Then
                            'nuits = CType((dateTravail - arrivee).TotalDays, Int64)
                            'Else
                            'nuits = CType((depart - arrivee).TotalDays, Int64)
                            'End If

                            If depart.ToString("yyyy-MM-dd") = dateMainCourante.ToString("yyyy-MM-dd") Then

                                If reservation.Rows(j)("DAY_USE") = 0 Then

                                    RETRANCHEMENTHEBERGEMENT = table.Rows(i)("HEBERGEMENT")
                                    RETRANCHEMENTTAXEDESEJOUR = table.Rows(i)("TAXE DE SEJOUR")

                                    'HEBERGEMENT = 0
                                    'taxeDeSejours = 0

                                Else
                                    'AUTRES_VENTE -= table.Rows(i)("HEBERGEMENT")
                                End If

                            End If

                            If HEBERGEMENT < 0 Then
                                HEBERGEMENT = 0
                            End If

                            'ON DOIT MULTIPLIER LE DAY USE PAR LE NOMBRE D'HEURE
                            If reservation.Rows(j)("DAY_USE") = 1 Then

                                Dim DEBUT As Date = CDate(reservation.Rows(j)("HEURE_ENTREE")).ToShortTimeString
                                Dim FIN As Date = CDate(reservation.Rows(j)("HEURE_SORTIE")).ToShortTimeString

                                Dim NombreHeure As Integer = 0

                                NombreHeure = CType((FIN - DEBUT).TotalHours, Int32)

                                'HEBERGEMENT *= NombreHeure

                                'AUTRES_VENTE -= HEBERGEMENT

                            End If

                            If AUTRES_VENTE < 0 Then
                                AUTRES_VENTE = 0
                            End If

                            TOTAL_ENCAISSEMENT += table.Rows(i)("ESPECES") + table.Rows(i)("CARTE CREDIT") + table.Rows(i)("MOBILE MONEY") + table.Rows(i)("CHEQUE")

                            ESPECES += table.Rows(i)("ESPECES")
                            CARTE_CREDIT += table.Rows(i)("CARTE CREDIT")
                            CHEQUE += table.Rows(i)("CHEQUE")
                            MOBILE_MONEY += table.Rows(i)("MOBILE MONEY")
                            ARRHES += table.Rows(i)("ARRHES")

                            If (RESTAURANT + BAR) = table.Rows(i)("BAR/RESTAURANT") Then
                                TOTAL_RECETTE += AUTRES_VENTE + HEBERGEMENT + table.Rows(i)("BAR/RESTAURANT") + table.Rows(i)("BLANCHISSERIE")
                            ElseIf RESTAURANT + BAR = table.Rows(i)("BAR/RESTAURANT") Then
                                TOTAL_RECETTE += AUTRES_VENTE + HEBERGEMENT + RESTAURANT + BAR + table.Rows(i)("BLANCHISSERIE")
                            Else
                                TOTAL_RECETTE += table.Rows(i)("BAR/RESTAURANT") + AUTRES_VENTE + HEBERGEMENT + table.Rows(i)("BLANCHISSERIE")
                            End If

                            REPORT_VEILLE += 0

                            RECETTE_DU_JOUR += table.Rows(i)("RECETTE DU JOUR")
                            '----------------------------------------------------------------------------------------------------------------------------

                        Next

                        HEBERGEMENT = HEBERGEMENT - RETRANCHEMENTHEBERGEMENT
                        taxeDeSejours = taxeDeSejours - RETRANCHEMENTTAXEDESEJOUR

                        RECETTE_DU_JOUR += AUTRES_VENTE
                        TOTAL_GENERAL = HEBERGEMENT + taxeDeSejours + PDJ + DEJEUNER + DINER + BAR + BLANCHISSERIE + AUTRES_VENTE

                        A_REPORTER = TOTAL_GENERAL - TOTAL_ENCAISSEMENT

                        dt.Rows.Add(reservation.Rows(j)("CHAMBRE_ID"), reservation.Rows(j)("NOM_CLIENT"), CDate(reservation.Rows(j)("DATE_ENTTRE")).ToShortDateString, CDate(reservation.Rows(j)("DATE_SORTIE")).ToShortDateString, NUITEES, PAX, HEBERGEMENT, taxeDeSejours, PDJ, DEJEUNER, DINER, BAR, BLANCHISSERIE, AUTRES_VENTE, (RECETTE_DU_JOUR - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR), REPORT_VEILLE * changerSigne, TOTAL_GENERAL * changerSigne, ESPECES, CARTE_CREDIT + CHEQUE, MOBILE_MONEY, (A_REPORTER - ARRHES) * changerSigne, reservation.Rows(j)("CODE_RESERVATION"))

                        RETRANCHEMENTHEBERGEMENT = 0
                        RETRANCHEMENTTAXEDESEJOUR = 0


                    End If

                Next

                '-------------------------------------------------------------CLIENT COMPTOIR ---------------------------------------------------

                Dim getUserQuery02 = "SELECT CODE_CHAMBRE As 'CHAMBRE', NUM_RESERVATION, main_courante_autres.NOM_CLIENT As 'NOM & PRENOM', PDJ, DEJEUNER, DINER, CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_autres.NUM_RESERVATION As 'RESERVATION', main_courante_autres.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_autres.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_autres.SERVICES AS 'SERVICES', main_courante_autres.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_autres.BOUTIQE AS 'BOUTIQUE', main_courante_autres.CYBERCAFE As 'BUSINESS CENTER', main_courante_autres.SPORTS As 'SPORTS' , main_courante_autres.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_autres.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_autres.BLANCHISSERIE As BLANCHISSERIE, main_courante_autres.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER' FROM main_Courante_autres WHERE DATE_MAIN_COURANTE <= '" & DateFin_1.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateDebut_1.ToString("yyyy-MM-dd") & "' ORDER BY main_courante_autres.NOM_CLIENT ASC"

                Dim command02 As New MySqlCommand(getUserQuery02, GlobalVariable.connect)

                'command1.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
                'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 0
                'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 1
                'command02.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

                Dim adapter02 As New MySqlDataAdapter(command02)

                Dim table02 As New DataTable()

                adapter02.Fill(table02)

                If table02.Rows.Count > 0 Then

                    Dim CHAMBRE As String = "-"
                    Dim NOM_PRENOM As String = "CLIENT COMPTOIR"
                    Dim DATE_ARRIVEE As Date = DateDebut_1.ToShortDateString
                    Dim DATE_DEPART As Date = DateFin_1.ToShortDateString
                    Dim dateTravail As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
                    Dim DATE_MAIN_COURANTE As Date
                    Dim NUITEES As Integer = 0
                    Dim PAX As Integer = 0
                    Dim AUTRES_VENTE As Double = 0
                    Dim TOTAL_RECETTE As Double = 0
                    Dim HEBERGEMENT As Double = 0
                    Dim PDJ As Double = 0
                    Dim DEJEUNER As Double = 0
                    Dim DINER As Double = 0
                    Dim BAR As Double = 0
                    Dim RECETTE_DU_JOUR As Double = 0
                    Dim REPORT_VEILLE As Double = 0
                    Dim BLANCHISSERIE As Double = 0
                    Dim TOTAL_GENERAL As Double = 0
                    Dim ESPECES As Double = 0
                    Dim CARTE_CREDIT As Double = 0
                    Dim MOBILE_MONEY As Double = 0
                    Dim A_REPORTER As Double = 0
                    Dim TAXE As Double = 0

                    Dim ARRHES As Double = 0
                    Dim CHEQUE As Double = 0

                    For i = 0 To table02.Rows.Count - 1

                        ESPECES += table02.Rows(i)("ESPECES")
                        CARTE_CREDIT += table02.Rows(i)("CARTE CREDIT")
                        MOBILE_MONEY += table02.Rows(i)("MOBILE MONEY")
                        CHEQUE += table02.Rows(i)("CHEQUE")

                        TOTAL_GENERAL += table02.Rows(i)("TOTAL GENERAL")

                        If DATE_MAIN_COURANTE = dateTravail Then
                            RECETTE_DU_JOUR += table02.Rows(i)("HEBERGEMENT") + table02.Rows(i)("PDJ") + table02.Rows(i)("DEJEUNER") + table02.Rows(i)("DINER") + table02.Rows(i)("BAR") + table02.Rows(i)("BLANCHISSERIE")
                        End If

                        AUTRES_VENTE += table02.Rows(i)("SERVICES") + table02.Rows(i)("SALON DE BEAUTE") + table02.Rows(i)("BOUTIQUE") + table02.Rows(i)("BUSINESS CENTER") + table02.Rows(i)("SPORTS") + table02.Rows(i)("LOISIRS") + table02.Rows(i)("JOURNAUX") + table02.Rows(i)("AUTRES")

                        HEBERGEMENT += table02.Rows(i)("HEBERGEMENT")
                        PDJ += table02.Rows(i)("PDJ")
                        DEJEUNER += table02.Rows(i)("DEJEUNER")
                        DINER += table02.Rows(i)("DINER")
                        BAR += table02.Rows(i)("BAR")
                        BLANCHISSERIE += table02.Rows(i)("BLANCHISSERIE")

                    Next

                    A_REPORTER = TOTAL_GENERAL - (ESPECES + CARTE_CREDIT + MOBILE_MONEY - CHEQUE)

                    dt.Rows.Add(CHAMBRE, NOM_PRENOM, DateDebut_1.ToShortDateString, DateFin_1.ToShortDateString, NUITEES, PAX, HEBERGEMENT, TAXE, PDJ, DEJEUNER, DINER, BAR, BLANCHISSERIE, AUTRES_VENTE, RECETTE_DU_JOUR, REPORT_VEILLE * changerSigne, TOTAL_GENERAL * changerSigne, ESPECES, CARTE_CREDIT + CHEQUE, MOBILE_MONEY, (A_REPORTER - ARRHES) * changerSigne, "-")

                End If

            End If

            If dt.Rows.Count > 0 Then

                Dim args As ArgumentType = New ArgumentType()
                args.action = 3 ' MAINCOURANTE CUMULEE
                args.dt = dt
                args.DateDebut = DateDebut_1
                args.DateFin = DateFin_1

                If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                    backGroundWorkerToCall(args)
                End If

            End If

            Me.Cursor = Cursors.Default

        End If

        If True Then
            'Me.Close()
        End If

    End Sub

    Private Sub RenvoiRapportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaDateTimePickerDateMainCouranteJournaliere.MaxDate = GlobalVariable.DateDeTravail.ToShortDateString
        GunaDateTimePickerMCCDu.MaxDate = GlobalVariable.DateDeTravail.ToShortDateString
        GunaDateTimePickerMCCDu.Value = GlobalVariable.DateDeTravail.AddDays(-7)
        GunaDateTimePickerMCCAu.MaxDate = GlobalVariable.DateDeTravail.ToShortDateString
        GunaDateTimePickerMCCAu.Value = GlobalVariable.DateDeTravail

    End Sub


    Public Sub backGroundWorkerToCall(ByVal args As ArgumentType)

        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker2.IsBusy Then
            BackgroundWorker2.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker3.IsBusy Then
            BackgroundWorker3.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker4.IsBusy Then
            BackgroundWorker4.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker5.IsBusy Then
            BackgroundWorker5.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker6.IsBusy Then
            BackgroundWorker6.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker7.IsBusy Then
            BackgroundWorker7.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker8.IsBusy Then
            BackgroundWorker8.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker9.IsBusy Then
            BackgroundWorker9.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker10.IsBusy Then
            BackgroundWorker10.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker11.IsBusy Then
            BackgroundWorker11.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker12.IsBusy Then
            BackgroundWorker12.RunWorkerAsync(args)
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker6_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker6.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker7_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker7.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker8_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker8.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker9_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker9.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker10_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker10.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    '-----------------------------------

    Private Sub BackgroundWorker11_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker11.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub BackgroundWorker12_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker12.DoWork

        Dim args As ArgumentType = e.Argument

        documentToBeSendUsingBackGroundWorker(args)

    End Sub

    Private Sub documentToBeSendUsingBackGroundWorker(ByVal args As ArgumentType)

        Dim renvoie As Boolean = True

        If args.action = 0 Then
            'FOR RAPPORT FINANCIER
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        ElseIf args.action = 1 Then
            'FOR MAINCOURANTE
            RapportApresCloture.RapportMainCourante(args.DateDebut, args.DateFin, renvoie)
        ElseIf args.action = 2 Then
            'INTRODUCTORY MESSAGE TO MAINCOURANTE
            Functions.ultrMessageSimpleText(args.whatsAppMessage, args.mobile_number)
        ElseIf args.action = 3 Then
            'MAINCOURANTE CUMUL
            RapportApresCloture.RapportMainCouranteCumul(args.dt, args.DateDebut, args.DateFin, renvoie)
        ElseIf args.action = 4 Then

        ElseIf args.action = 5 Then

        ElseIf args.action = 6 Or args.action = 7 Then

        ElseIf args.action = 8 Or args.action = 9 Then

        End If

    End Sub

End Class