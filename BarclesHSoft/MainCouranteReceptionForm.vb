Imports MySql.Data.MySqlClient

Public Class MainCouranteReceptionForm

    'Dim connect As New DataBaseManipulation()

    Private Sub MainCouranteReceptionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim langue As New Languages()
        langue.MainCouranteReception(GlobalVariable.actualLanguageValue)

        DataGridViewMainCouranteReception.Columns.Clear()

        GunaLabelDateMainCourante.Text = GunaDateTimePickerDebut.Value.ToShortDateString()

        If GlobalVariable.AncienneMainCourante Then

            GunaDateTimePickerDebut.Enabled = True
            GunaDateTimePicker1Fin.Enabled = True

            GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
            GunaDateTimePicker1Fin.Value = GlobalVariable.DateDeTravail

        Else

            GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail.AddDays(-1)
            GunaDateTimePicker1Fin.Value = GlobalVariable.DateDeTravail.AddDays(-1)

            GunaDateTimePickerDebut.Enabled = True
            GunaDateTimePicker1Fin.Enabled = False

        End If
        'ListeDesMainCourantesDujours()

        GunaDateTimePicker1Fin.MaxDate = GlobalVariable.DateDeTravail
        GunaDateTimePickerDebut.MaxDate = GlobalVariable.DateDeTravail

    End Sub

    Private Sub ListeDesMainCourantesDujours()

        Dim changerSigne As Integer = -1

        If Not GlobalVariable.AncienneMainCourante Then

            'MAINCOURANTE JOURNALIERE
            Dim dateTravail As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
            Dim dateMainCourante As Date = GunaDateTimePickerDebut.Value.ToShortDateString

            Functions.AffectingTitleToAForm("MAIN COURANTE JOURNALIERE", GunaLabelGestCompteGeneraux)

            Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToString("yyyy-MM-dd")
            Dim DateFin As Date = GunaDateTimePicker1Fin.Value.ToString("yyyy-MM-dd")

            'GunaDateTimePickerDebut.Enabled = False
            ' GunaDateTimePicker1Fin.Enabled = False
            GunaButtonImprimer.Visible = True
            GunaButtonAfficher.Visible = True

            'RESERVATION 
            Dim ETAT_MAIN_COURANTE As Integer = 0

            If dateMainCourante < dateTravail Then
                ETAT_MAIN_COURANTE = 1
            End If

            'AND ETAT_MAIN_COURANTE=@ETAT_MAIN_COURANTE

            Dim getUserQuery1 = "SELECT CHAMBRE_ID As 'CHAMBRE', DAY_USE, NUM_RESERVATION, ARRHES, main_courante_journaliere.NOM_CLIENT As 'NOM & PRENOM', DATE_ENTTRE As 'DATE ARRIVEE',
            DATE_SORTIE As 'DATE DEPART', NB_PERSONNES As 'NBRE DE PAX', PDJ, DEJEUNER, DINER,CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE',
            ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_journaliere.NUM_RESERVATION As 'RESERVATION', 
            main_courante_journaliere.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_journaliere.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR,
            main_courante_journaliere.SERVICES AS 'SERVICES', main_courante_journaliere.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_journaliere.BOUTIQE AS 'BOUTIQUE',
            main_courante_journaliere.CYBERCAFE As 'BUSINESS CENTER', main_courante_journaliere.SPORTS As 'SPORTS' , main_courante_journaliere.LOISIRS As 'LOISIRS',
            TOTAL_JOUR, main_courante_journaliere.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_journaliere.BLANCHISSERIE As BLANCHISSERIE, main_courante_journaliere.AUTRES As 'AUTRES'
            , TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER', HEURE_ENTREE, HEURE_SORTIE,
            TAUX_OCCUPATION_PCT As 'TAXE DE SEJOUR', ANTICIPE, DAY_USE FROM main_Courante_journaliere, reserve_conf WHERE DATE_MAIN_COURANTE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
            AND DATE_MAIN_COURANTE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND main_Courante_journaliere.NUM_RESERVATION = reserve_conf.CODE_RESERVATION 
            AND reserve_conf.TYPE=@TYPE ORDER BY CODE_CHAMBRE ASC"

            Dim command1 As New MySqlCommand(getUserQuery1, GlobalVariable.connect)

            'command1.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
            'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 0
            command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = ETAT_MAIN_COURANTE
            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.DocumentToGenerate

            Dim adapter1 As New MySqlDataAdapter(command1)

            Dim table As New DataTable()

            adapter1.Fill(table)

            '-------------------------------------------------------- MAINCOURANTE ----------------------------------------------

            Dim getUserQuery01 = "SELECT CODE_CHAMBRE As 'CHAMBRE', NUM_RESERVATION, ARRHES, main_courante_autres.NOM_CLIENT As 'NOM & PRENOM', PDJ, DEJEUNER, DINER, CAVE, CAFE, DIVERS, ENCAISSEMENT_ESPECE AS 'ESPECES', ENCAISSEMENT_CHEQUE AS 'CHEQUE', ENCAISSEMENT_CARTE_CREDIT As 'CARTE CREDIT', TELE AS 'MOBILE MONEY', main_Courante_autres.NUM_RESERVATION As 'RESERVATION', main_courante_autres.MONTANT_ACCORDE AS 'HEBERGEMENT', main_courante_autres.BAR_RESTAURANT AS 'BAR/RESTAURANT', BAR, main_courante_autres.SERVICES AS 'SERVICES', main_courante_autres.SALON_DE_BEAUTE AS 'SALON DE BEAUTE', main_courante_autres.BOUTIQE AS 'BOUTIQUE', main_courante_autres.CYBERCAFE As 'BUSINESS CENTER', main_courante_autres.SPORTS As 'SPORTS' , main_courante_autres.LOISIRS As 'LOISIRS', TOTAL_JOUR, main_courante_autres.KIOSQUE_A_JOURNAUX as 'JOURNAUX', main_courante_autres.BLANCHISSERIE As BLANCHISSERIE, main_courante_autres.AUTRES As 'AUTRES', TOTAL_JOUR As 'RECETTE DU JOUR', REPORT_VEILLE As 'REPORT VEILLE', TOTAL_GENERAL As 'TOTAL GENERAL', A_REPORTER As 'A REPORTER' FROM main_Courante_autres WHERE DATE_MAIN_COURANTE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE >='" & DateDebut.ToString("yyyy-MM-dd") & "' ORDER BY main_courante_autres.NOM_CLIENT ASC"

            Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

            'command1.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
            'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 0
            'command1.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int32).Value = 1
            command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.DocumentToGenerate

            Dim adapter01 As New MySqlDataAdapter(command01)

            Dim table0 As New DataTable()

            adapter01.Fill(table0)

            '--------------------------------------------------------------------------------------------------------------------

            If table.Rows.Count > 0 Then

                DataGridViewMainCouranteReception.Columns.Clear()
                DataGridViewMainCouranteReception.Rows.Clear()

                '------------------ ADD COLUMNS --------------------

                DataGridViewMainCouranteReception.Columns.Add("CHAMBRE", "CHAMBRE")
                DataGridViewMainCouranteReception.Columns.Add("NOM_PRENOM", "NOM & PRENOM")
                DataGridViewMainCouranteReception.Columns.Add("ARRIVEE", "ARRIVEE")
                DataGridViewMainCouranteReception.Columns.Add("DEPART", "DEPART")
                DataGridViewMainCouranteReception.Columns.Add("NUITEE", "NUITEE")
                DataGridViewMainCouranteReception.Columns.Add("NBRE_PAX", "NBRE PAX")
                DataGridViewMainCouranteReception.Columns.Add("HEBERGEMENT", "HEBERGEMENT")
                DataGridViewMainCouranteReception.Columns.Add("TAXE", "TAXE")
                DataGridViewMainCouranteReception.Columns.Add("PDJ", "PDJ")
                DataGridViewMainCouranteReception.Columns.Add("DEJEUNER", "DEJEUNER")
                DataGridViewMainCouranteReception.Columns.Add("DINER", "DINER")
                DataGridViewMainCouranteReception.Columns.Add("BAR", "BAR")
                DataGridViewMainCouranteReception.Columns.Add("BLANCHISSERIE", "BLANCHISSERIE")
                DataGridViewMainCouranteReception.Columns.Add("AUTRES", "AUTRES")
                DataGridViewMainCouranteReception.Columns.Add("RECETTE_DU_JOUR", "RECETTE DU JOUR") 'TOTAL DU JOUR
                DataGridViewMainCouranteReception.Columns.Add("REPORT_VEILLE", "REPORT VEILLE")
                DataGridViewMainCouranteReception.Columns.Add("TOTAL_GENERAL", "TOTAL GENERAL")
                DataGridViewMainCouranteReception.Columns.Add("ESPECES", "ESPECES")
                DataGridViewMainCouranteReception.Columns.Add("CARTE", "CARTE")
                DataGridViewMainCouranteReception.Columns.Add("MOBILE_MONEY", "MOBILE MONEY")
                DataGridViewMainCouranteReception.Columns.Add("A_REPORTER", "A REPORTER")
                DataGridViewMainCouranteReception.Columns.Add("CODE_RESERVATION", "CODE RESERVATION")

                '------------------ FAILED COLUMNS -----------------

                Dim enChambre As Boolean = False

                For i = 0 To table.Rows.Count - 1

                    enChambre = False
                    Dim DAY_USE As Integer = table.Rows(i)("DAY_USE")
                    Dim NUMERO_RESERVATION As String = table.Rows(i)("NUM_RESERVATION")

                    '----------------------------------------------- TAXE DE SEJOURS ------------------------------------------------------

                    '-----------------------------------------------END TAXE DE SEJOURS ---------------------------------------------------

                    Dim RESTAURANT As Double = table.Rows(i)("PDJ") + table.Rows(i)("DEJEUNER") + table.Rows(i)("DINER")
                    Dim BAR As Double = table.Rows(i)("CAFE") + table.Rows(i)("CAVE") + table.Rows(i)("DIVERS")

                    'Dim RESTAURANT As Double = table.Rows(i)("CAVE") + table.Rows(i)("DIVERS") + table.Rows(i)("CAFE")

                    Dim AUTRES_VENTE As Double = table.Rows(i)("SERVICES") + table.Rows(i)("SALON DE BEAUTE") + table.Rows(i)("BOUTIQUE") + table.Rows(i)("BUSINESS CENTER") + table.Rows(i)("SPORTS") + table.Rows(i)("LOISIRS") + table.Rows(i)("JOURNAUX") + table.Rows(i)("AUTRES")

                    Dim TOTAL_RECETTE As Double = 0

                    Dim nuits As Integer = 0

                    Dim arrivee As Date = CDate(table.Rows(i)("DATE ARRIVEE")).ToShortDateString
                    Dim depart As Date = CDate(table.Rows(i)("DATE DEPART")).ToShortDateString

                    If dateMainCourante >= arrivee And dateMainCourante <= depart Then
                        enChambre = True
                    End If

                    Dim HEBERGEMENT As Double = table.Rows(i)("HEBERGEMENT")
                    Dim taxeDeSejours As Double = table.Rows(i)("TAXE DE SEJOUR")
                    Dim taxeDeSejourDansLigneFacture As Double = 0

                    Dim RETRANCHEMENTHEBERGEMENT As Double = 0
                    Dim RETRANCHEMENTTAXEDESEJOUR As Double = 0
                    Dim TAXE_DE_SEJOUR_REELLE As Double = 0

                    'CALCUL DU SEJOURS ECOULE

                    ' If dateTravail <= depart Then
                    'nuits = CType((dateTravail - arrivee).TotalDays, Int64)
                    'Else
                    'nuits = CType((depart - arrivee).TotalDays, Int64)
                    'End If

                    nuits = CType((depart - arrivee).TotalDays, Int64)

                    Dim PAX As Integer = table.Rows(i)("NBRE DE PAX")

                    If PAX <= 0 Then
                        PAX = 1
                    End If

                    Dim SERVICE As String = ""

                    'ON DOIT DETERMINER QUELLE EST LE VRAI MONTANT DE LA TAXE DE SEJOUR

                    If GlobalVariable.actualLanguageValue = 1 Then
                        SERVICE = "TAXE DE SEJOURS"
                    Else
                        SERVICE = "TOURIST TAX"
                    End If

                    'VA AIDER A RETIRER LES TAXES DE SEJOURS EN TROP
                    TAXE_DE_SEJOUR_REELLE = Functions.totalDunServiceUnCertainJourSpecifique(dateMainCourante, SERVICE, table.Rows(i)("NUM_RESERVATION"))

                    If depart.ToString("yyyy-MM-dd") = dateMainCourante.ToString("yyyy-MM-dd") Then

                        If table.Rows(i)("DAY_USE") = 0 Then

                            RETRANCHEMENTHEBERGEMENT = HEBERGEMENT
                            RETRANCHEMENTTAXEDESEJOUR = taxeDeSejours

                            HEBERGEMENT = 0
                            taxeDeSejours = 0

                        Else
                            'AUTRES_VENTE -= table.Rows(i)("HEBERGEMENT")
                        End If

                    Else

                    End If

                    If HEBERGEMENT < 0 Then
                        HEBERGEMENT = 0
                    End If

                    Dim TAXE_EN_TROP_NEGATIVE As Double = 0

                    'ON DOIT MULTIPLIER LE DAY USE PAR LE NOMBRE D'HEURE
                    If table.Rows(i)("DAY_USE") = 1 Then

                        Dim DEBUT As Date = CDate(table.Rows(i)("HEURE_ENTREE")).ToShortTimeString
                        Dim FIN As Date = CDate(table.Rows(i)("HEURE_SORTIE")).ToShortTimeString

                        Dim NombreHeure As Integer = 0

                        NombreHeure = CType((FIN - DEBUT).TotalHours, Int32)

                    End If

                    If AUTRES_VENTE < 0 Then
                        AUTRES_VENTE = 0
                    End If

                    Dim TOTAL_ENCAISSEMENT As Double = table.Rows(i)("ESPECES") + table.Rows(i)("CARTE CREDIT") + table.Rows(i)("MOBILE MONEY") + table.Rows(i)("CHEQUE")

                    If (RESTAURANT + BAR) = table.Rows(i)("BAR/RESTAURANT") Then
                        TOTAL_RECETTE = AUTRES_VENTE + HEBERGEMENT + table.Rows(i)("BAR/RESTAURANT") + table.Rows(i)("BLANCHISSERIE")
                    ElseIf RESTAURANT + BAR = table.Rows(i)("BAR/RESTAURANT") Then
                        TOTAL_RECETTE = AUTRES_VENTE + HEBERGEMENT + RESTAURANT + BAR + table.Rows(i)("BLANCHISSERIE")
                    Else
                        TOTAL_RECETTE = table.Rows(i)("BAR/RESTAURANT") + AUTRES_VENTE + HEBERGEMENT + table.Rows(i)("BLANCHISSERIE")
                    End If

                    Dim A_REPORTER_SOLDE As Double = 0
                    Dim TOTAL_GENERAL_DU_JOUR As Double = 0
                    Dim TOTAL_CARTE As Double = 0
                    Dim RECETTE_TOTAL_DU_JOUR As Double = 0

                    'DataGridViewMainCouranteReception.Rows.Add(table.Rows(i)("CHAMBRE"), table.Rows(i)("NOM & PRENOM"), CDate(table.Rows(i)("DATE ARRIVEE")).ToShortDateString, CDate(table.Rows(i)("DATE DEPART")).ToShortDateString, nuits, PAX, HEBERGEMENT, taxeDeSejours, table.Rows(i)("PDJ"), table.Rows(i)("DEJEUNER"), table.Rows(i)("DINER"), table.Rows(i)("BAR"), table.Rows(i)("BLANCHISSERIE"), AUTRES_VENTE, (table.Rows(i)("RECETTE DU JOUR") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR), table.Rows(i)("REPORT VEILLE") * changerSigne, (table.Rows(i)("TOTAL GENERAL") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR) * changerSigne, table.Rows(i)("ESPECES"), table.Rows(i)("CARTE CREDIT") + table.Rows(i)("CHEQUE"), table.Rows(i)("MOBILE MONEY"), (table.Rows(i)("A REPORTER") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR - table.Rows(i)("ARRHES")) * changerSigne, table.Rows(i)("NUM_RESERVATION"))
                    'TOTAL_GENERAL_DU_JOUR = (table.Rows(i)("TOTAL GENERAL") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR) * changerSigne

                    TOTAL_GENERAL_DU_JOUR = (table.Rows(i)("TOTAL GENERAL") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR) * changerSigne
                    TOTAL_CARTE = table.Rows(i)("CARTE CREDIT") + table.Rows(i)("CHEQUE")
                    RECETTE_TOTAL_DU_JOUR = (table.Rows(i)("RECETTE DU JOUR") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR)
                    A_REPORTER_SOLDE = (table.Rows(i)("A REPORTER") - RETRANCHEMENTHEBERGEMENT - RETRANCHEMENTTAXEDESEJOUR - table.Rows(i)("ARRHES")) * changerSigne

                    Dim TAXE_EN_TROP As Double = 0

                    If taxeDeSejours >= TAXE_DE_SEJOUR_REELLE Then
                        TAXE_EN_TROP = taxeDeSejours - TAXE_DE_SEJOUR_REELLE
                    Else

                    End If

                    If arrivee.ToString("yyyy-MM-dd") = dateMainCourante.ToString("yyyy-MM-dd") Then
                        If TAXE_EN_TROP > 0 Then
                            TAXE_EN_TROP_NEGATIVE = TAXE_EN_TROP
                        End If
                    End If

                    If table.Rows(i)("ANTICIPE") = 1 Then 'BEFORE FACTURATION EN AVANCE

                        TAXE_EN_TROP = 0

                        A_REPORTER_SOLDE = table.Rows(i)("A REPORTER")

                        If dateMainCourante >= dateTravail Then
                            'LES DONNEES N'ETANT PAS ENCORE ARRETER ON PEUT LIRE LA SOURCE VARIABLE

                            If GlobalVariable.actualLanguageValue = 1 Then
                                SERVICE = "HEBERGEMENT"
                            Else
                                SERVICE = "ACCOMMODATION"
                            End If

                            HEBERGEMENT = Functions.totalDunServiceUnCertainJourSpecifique(dateMainCourante, SERVICE, table.Rows(i)("NUM_RESERVATION"))

                            If GlobalVariable.actualLanguageValue = 1 Then
                                SERVICE = "TAXE DE SEJOURS"
                            Else
                                SERVICE = "TOURIST TAX"
                            End If

                            taxeDeSejours = Functions.totalDunServiceUnCertainJourSpecifique(dateMainCourante, SERVICE, table.Rows(i)("NUM_RESERVATION"))

                            If dateMainCourante = depart Then
                                If DAY_USE = 0 Then
                                    RECETTE_TOTAL_DU_JOUR += (HEBERGEMENT + taxeDeSejours)
                                    TOTAL_GENERAL_DU_JOUR += (HEBERGEMENT + taxeDeSejours) * changerSigne
                                End If
                            End If

                            'TOTAL_GENERAL_DU_JOUR += taxeDeSejours + HEBERGEMENT

                        End If

                    End If

                    If enChambre Then
                        DataGridViewMainCouranteReception.Rows.Add(table.Rows(i)("CHAMBRE"), table.Rows(i)("NOM & PRENOM"), CDate(table.Rows(i)("DATE ARRIVEE")).ToShortDateString, CDate(table.Rows(i)("DATE DEPART")).ToShortDateString, nuits, PAX, HEBERGEMENT, TAXE_DE_SEJOUR_REELLE, table.Rows(i)("PDJ"), table.Rows(i)("DEJEUNER"), table.Rows(i)("DINER"), table.Rows(i)("BAR"), table.Rows(i)("BLANCHISSERIE"), AUTRES_VENTE, RECETTE_TOTAL_DU_JOUR - TAXE_EN_TROP, (table.Rows(i)("REPORT VEILLE")) * changerSigne + TAXE_EN_TROP - TAXE_EN_TROP_NEGATIVE, TOTAL_GENERAL_DU_JOUR + TAXE_EN_TROP, table.Rows(i)("ESPECES"), TOTAL_CARTE, table.Rows(i)("MOBILE MONEY"), A_REPORTER_SOLDE + TAXE_EN_TROP, table.Rows(i)("NUM_RESERVATION"))
                    End If

                    RETRANCHEMENTHEBERGEMENT = 0
                    RETRANCHEMENTTAXEDESEJOUR = 0

                Next

                'MAINcourantes comptoires
                For i = 0 To table0.Rows.Count - 1

                    Dim RESTAURANT As Double = table0.Rows(i)("PDJ") + table0.Rows(i)("DEJEUNER") + table0.Rows(i)("DINER")
                    Dim BAR As Double = table0.Rows(i)("CAFE") + table0.Rows(i)("CAVE") + table0.Rows(i)("DIVERS")

                    'Dim RESTAURANT As Double = table0.Rows(i)("CAVE") + table0.Rows(i)("DIVERS") + table0.Rows(i)("CAFE")

                    Dim AUTRES_VENTE As Double = table0.Rows(i)("SERVICES") + table0.Rows(i)("SALON DE BEAUTE") + table0.Rows(i)("BOUTIQUE") + table0.Rows(i)("BUSINESS CENTER") + table0.Rows(i)("SPORTS") + table0.Rows(i)("LOISIRS") + table0.Rows(i)("JOURNAUX") + table0.Rows(i)("AUTRES")

                    Dim TOTAL_RECETTE As Double = 0

                    Dim TOTAL_ENCAISSEMENT As Double = table0.Rows(i)("ESPECES") + table0.Rows(i)("CARTE CREDIT") + table0.Rows(i)("MOBILE MONEY") + table0.Rows(i)("CHEQUE")

                    'TOTAL_RECETTE = AUTRES_VENTE + table0.Rows(i)("BAR/RESTAURANT") + table0.Rows(i)("BLANCHISSERIE")

                    If (RESTAURANT + BAR) = table0.Rows(i)("BAR/RESTAURANT") And (RESTAURANT + table0.Rows(i)("BAR")) = table0.Rows(i)("BAR/RESTAURANT") Then
                        TOTAL_RECETTE = AUTRES_VENTE + table0.Rows(i)("BAR/RESTAURANT") + table0.Rows(i)("BLANCHISSERIE")
                    Else
                        TOTAL_RECETTE = AUTRES_VENTE + RESTAURANT + BAR + table0.Rows(i)("BLANCHISSERIE")
                    End If

                    Dim TYPE_CLIENT As String = "CLIENT COMPTOIR"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        TYPE_CLIENT = "WALK IN"
                    End If

                    DataGridViewMainCouranteReception.Rows.Add("-", TYPE_CLIENT, CDate(GunaDateTimePickerDebut.Value).ToShortDateString, CDate(GunaDateTimePickerDebut.Value).ToShortDateString, 0, 0, 0, 0, table0.Rows(i)("PDJ"), table0.Rows(i)("DEJEUNER"), table0.Rows(i)("DINER"), table0.Rows(i)("BAR"), table0.Rows(i)("BLANCHISSERIE"), AUTRES_VENTE, table0.Rows(i)("RECETTE DU JOUR"), table0.Rows(i)("REPORT VEILLE") * changerSigne, table0.Rows(i)("TOTAL GENERAL") * changerSigne, table0.Rows(i)("ESPECES"), table0.Rows(i)("CARTE CREDIT") + table0.Rows(i)("CHEQUE"), table0.Rows(i)("MOBILE MONEY"), table0.Rows(i)("A REPORTER") * changerSigne, "-")

                Next

                'DataGridViewMainCouranteReception.Visible = True
                'DataGridViewMainCouranteReception.DataSource = table

                DataGridViewMainCouranteReception.Columns("HEBERGEMENT").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("HEBERGEMENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("NBRE_PAX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridViewMainCouranteReception.Columns("PDJ").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("PDJ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("TAXE").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("TAXE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridViewMainCouranteReception.Columns("DEJEUNER").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("DEJEUNER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("DINER").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("DINER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("BAR").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("BAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("ESPECES").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("ESPECES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("CARTE").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("CARTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("MOBILE_MONEY").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("MOBILE_MONEY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("BLANCHISSERIE").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("BLANCHISSERIE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("RECETTE_DU_JOUR").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("RECETTE_DU_JOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("REPORT_VEILLE").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("REPORT_VEILLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("TOTAL_GENERAL").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("TOTAL_GENERAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("CODE_RESERVATION").Visible = False

                'DataGridViewMainCouranteReception.Columns("ENCAISSEMENT").DefaultCellStyle.Format = "#,##0"
                'DataGridViewMainCouranteReception.Columns("ENCAISSEMENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridViewMainCouranteReception.Columns("A_REPORTER").DefaultCellStyle.Format = "#,##0"
                DataGridViewMainCouranteReception.Columns("A_REPORTER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Else

                'DataGridViewMainCouranteReception.Visible = False
                DataGridViewMainCouranteReception.Columns.Clear()

            End If

        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        'GunaDateTimePickerDebut.Enabled = False
        'GunaButtonImprimer.Visible = False
        Me.Close()
    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'Click so as to output the main_courante_journaliere based on the typed date

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimer.Click

        Functions.RapportMainCourante(DataGridViewMainCouranteReception, GunaDateTimePickerDebut.Value, GunaDateTimePicker1Fin.Value)
        'connect.closeConnection()

    End Sub

    'Loading the reservation on which we double clicked at the level of main courante journaliere to the front office
    'We take reservations found in the list of main_courante_journaliere to the front desk

    'Update the value of the label when the date changes
    Private Sub GunaDateTimePickerDebut_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDebut.ValueChanged

        GunaLabelDateMainCourante.Text = GunaDateTimePickerDebut.Value.ToShortDateString()
        DataGridViewMainCouranteReception.Columns.Clear()
        If Not GlobalVariable.AncienneMainCourante Then
            GunaDateTimePicker1Fin.Value = GunaDateTimePickerDebut.Value
        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        ListeDesMainCourantesDujours()

        If DataGridViewMainCouranteReception.Rows.Count > 0 Then
            GunaButtonImprimer.Visible = True
        Else
            GunaButtonImprimer.Visible = False
        End If

    End Sub

    Private Sub GunaDateTimePicker1Fin_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePicker1Fin.ValueChanged

        If Not GlobalVariable.AncienneMainCourante Then
            'GunaDateTimePickerDebut.Value = GunaDateTimePicker1Fin.Value
        End If

    End Sub

    Private Sub DataGridViewMainCouranteReception_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewMainCouranteReception.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.DataGridViewMainCouranteReception.Rows(e.RowIndex)

            GlobalVariable.codeReservationToUpdate = row.Cells("CODE_RESERVATION").Value.ToString

            Dim infoResa As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

            If infoResa.Rows.Count > 0 Then

                GlobalVariable.codeClientToUpdate = infoResa.Rows(0)("CLIENT_ID")

                SituationClientForm.Show()

                SituationClientForm.GunaButtonFacturer.Text = "Imprimer"
                SituationClientForm.GunaButtonPayer.Visible = False

                SituationClientForm.TopMost = True

            End If

        End If

    End Sub

End Class