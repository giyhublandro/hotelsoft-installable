Imports MySql.Data.MySqlClient

Public Class BilletageForm

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

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub BilletageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.billetage(GlobalVariable.actualLanguageValue)

        GunaTextBoxNB1T1.Text = Format(10000, "#,##0")
        GunaTextBoxNB2T2.Text = Format(5000, "#,##0")
        GunaTextBoxNB3T3.Text = Format(2000, "#,##0")
        GunaTextBoxNB4T4.Text = Format(1000, "#,##0")
        GunaTextBoxNB5T5.Text = Format(500, "#,##0")

        'SELON SI ON APPELLE LE BILLETAGE DEPUIS LE BAR OU LA RECEPTION

        If GlobalVariable.billetageAPartirDe = "reception" Then

            SituationDeCaisseJournaliere()
            afficherButtonTrasnfert()

        ElseIf GlobalVariable.billetageAPartirDe = "comptable" Then

            SituationDeCaisseEspecesMensuelle()

            Dim totalRecette As Double = 0
            Dim recette As DataTable = SituationDeCaisseEspecesMensuelle()

            If recette.Rows.Count > 0 Then

                For i = 0 To recette.Rows.Count - 1
                    totalRecette += recette.Rows(i)("MONTANT_VERSE")
                Next

                LabelSituationCaisse.Text = Format(totalRecette, "#,##0")

            End If

            afficherButtonTrasnfert()

        ElseIf GlobalVariable.billetageAPartirDe = "bar" Then

            SituationDeCaisseJournaliere()

            afficherButtonTrasnfert()

        ElseIf GlobalVariable.billetageAPartirDe = "petite caisse" Then

            LabelSituationCaisse.Text = Format(PetiteCaisseForm.LabelSituationCaisse.Text, "#,##0")
            LabelMontantSorti.Text = Format(PetiteCaisseForm.LabelDepense.Text, "#,##0")

            SituationDeCaisseJournaliere()

            afficherButtonTrasnfert()

            Label2.Visible = True
            Panel1.Visible = True
            LabelMontantSorti.Visible = True

            GunaTextBox22.BaseColor = Color.Pink
            GunaButtonSaveFacturation.Enabled = False

        ElseIf GlobalVariable.billetageAPartirDe = "caisse" Then

            'PERMET DE VOIR LE BILLETAGE AU NIVEAU DES GRANDES CAISSES

            PanelSituationCaisse.Visible = False
            LabelSituationCaisse.Visible = False
            GunaButtonSaveFacturation.Visible = False
            Label5.Visible = False

            Dim REFERENCE_TRANSACTION As String = GrandeCaisseForm.GunaTextBoxReferenceRecette.Text

            Dim coupure As DataTable = Functions.getElementByCode(REFERENCE_TRANSACTION, "transfert_recette_coupures", "REFERENCE_TRANSACTION")

            If coupure.Rows.Count > 0 Then

                GunaTextBox22.Text = Format(coupure.Rows(0)("GRAND_TOTAL"), "#,##0")
                GunaTextBox22.BaseColor = Color.LightGreen

                GunaTextBox35.Text = Format(coupure.Rows(0)("NB1"), "#,##0")
                GunaTextBoxNB1T1.Text = Format(coupure.Rows(0)("NB1T1"), "#,##0")
                GunaTextBox30.Text = Format(coupure.Rows(0)("NB2"), "#,##0")
                GunaTextBox25.Text = Format(coupure.Rows(0)("NB3"), "#,##0")
                GunaTextBox13.Text = Format(coupure.Rows(0)("NB4"), "#,##0")
                GunaTextBoxNB5.Text = Format(coupure.Rows(0)("NB5"), "#,##0")
                GunaTextBox9.Text = Format(coupure.Rows(0)("NP1"), "#,##0")
                GunaTextBox20.Text = Format(coupure.Rows(0)("NP2"), "#,##0")
                GunaTextBox15.Text = Format(coupure.Rows(0)("NP3"), "#,##0")
                GunaTextBox10.Text = Format(coupure.Rows(0)("NP4"), "#,##0")
                GunaTextBox8.Text = Format(coupure.Rows(0)("NP5"), "#,##0")
                GunaTextBox5.Text = Format(coupure.Rows(0)("NP6"), "#,##0")
                '------------------------
                GunaTextBoxNP7.Text = Format(coupure.Rows(0)("NP7"), "#,##0")

                GunaTextBoxNB2T2.Text = Format(coupure.Rows(0)("NB2T2"), "#,##0")
                GunaTextBoxNB3T3.Text = Format(coupure.Rows(0)("NB3T3"), "#,##0")
                GunaTextBoxNB4T4.Text = Format(coupure.Rows(0)("NB4T4"), "#,##0")
                GunaTextBoxNB5T5.Text = Format(coupure.Rows(0)("NB5T5"), "#,##0")
                GunaTextBox2.Text = Format(coupure.Rows(0)("NP1T1"), "#,##0")
                GunaTextBox3.Text = Format(coupure.Rows(0)("NP2T2"), "#,##0")
                GunaTextBox6.Text = Format(coupure.Rows(0)("NP3T3"), "#,##0")
                GunaTextBox14.Text = Format(coupure.Rows(0)("NP4T4"), "#,##0")
                GunaTextBox11.Text = Format(coupure.Rows(0)("NP5T5"), "#,##0")
                GunaTextBox18.Text = Format(coupure.Rows(0)("NP6T6"), "#,##0")
                '-----------------------------
                GunaTextBoxNP7T7.Text = Format(coupure.Rows(0)("NP7T7"), "#,##0")

            End If

        End If

        Functions.magasinActuelEtShiftDunUtilisateur()

    End Sub

    Public Shared Function SituationDeCaisseEspeces(ByVal DateDeSituation As Date) As DataTable

        Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT AND MODE_REGLEMENT=@MODE_REGLEMENT ORDER BY DATE_REGLEMENT DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        command.Parameters.Add("@MODE_REGLEMENT", MySqlDbType.VarChar).Value = "Cash"
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Shared Function SituationDeCaisseEspecesMensuelle() As DataTable

        Dim DateDebutStat As Date = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail)
        Dim DateFinStat As Date = Functions.lastDayOfMonth(GlobalVariable.DateDeTravail)

        Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & DateDebutStat.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFinStat.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT AND MODE_REGLEMENT=@MODE_REGLEMENT ORDER BY DATE_REGLEMENT DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        If GlobalVariable.actualLanguageValue = 0 Then
            command.Parameters.Add("@MODE_REGLEMENT", MySqlDbType.VarChar).Value = "Cash"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            command.Parameters.Add("@MODE_REGLEMENT", MySqlDbType.VarChar).Value = "Espèce"
        End If

        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Sub SituationDeCaisseJournaliere()

        Dim situationDeCaisse As DataTable = SituationDeCaisseEspeces(GlobalVariable.DateDeTravail)

        Dim TotalFacture As Double = 0

        If situationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To situationDeCaisse.Rows.Count - 1
                TotalFacture += situationDeCaisse.Rows(i)("MONTANT_VERSE")
            Next

            'Dim situationDeCaisseCasDeRemboursement As DataTable = Functions.SituationDeCaisseCasDeRemboursement(GlobalVariable.DateDeTravail)

            'Dim TotalRembourse As Double = 0
            'On selection l'ensemble des remboursement d'un jour donné
            'If situationDeCaisseCasDeRemboursement.Rows.Count > 0 Then

            'For j = 0 To situationDeCaisseCasDeRemboursement.Rows.Count - 1
            'lRembourse += situationDeCaisseCasDeRemboursement.Rows(j)("MONTANT_HT")
            'Next

            'On soustrait les montant remboursé des montants encaissé
            'TotalFacture -= TotalRembourse

            'End If

            LabelSituationCaisse.Text = Format(TotalFacture, "#,##0")

        Else
            LabelSituationCaisse.Text = 0
        End If

    End Sub

    Private Sub GunaTextBox35_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox35.TextChanged

        If Trim(GunaTextBox35.Text) = "" Then
            GunaTextBox35.Text = 0
        End If

        If Trim(GunaTextBoxNB1T1.Text) = "" Then
            GunaTextBoxNB1T1.Text = 0
        End If

        GunaTextBox37.Text = Format(Double.Parse(GunaTextBox35.Text) * GunaTextBoxNB1T1.Text, "#,##0")

        sommeTotalBillets()

    End Sub

    Private Sub GunaTextBox30_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox30.TextChanged

        If Trim(GunaTextBoxNB2T2.Text) = "" Then
            GunaTextBoxNB2T2.Text = 0
        End If

        If Trim(GunaTextBox30.Text) = "" Then
            GunaTextBox30.Text = 0
        End If
        GunaTextBox33.Text = Format(Double.Parse(GunaTextBox30.Text) * Double.Parse(GunaTextBoxNB2T2.Text), "#,##0")

        sommeTotalBillets()

    End Sub

    Private Sub GunaTextBox25_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox25.TextChanged

        If Trim(GunaTextBox25.Text) = "" Then
            GunaTextBox25.Text = 0
        End If

        If GunaTextBoxNB3T3.Text = "" Then
            GunaTextBoxNB3T3.Text = 0
        End If

        GunaTextBox31.Text = Format(Double.Parse(GunaTextBox25.Text) * Double.Parse(GunaTextBoxNB3T3.Text), "#,##0")

        sommeTotalBillets()

    End Sub

    Private Sub GunaTextBox13_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox13.TextChanged
        If Trim(GunaTextBoxNB4T4.Text) = "" Then
            GunaTextBoxNB4T4.Text = 0
        End If

        If Trim(GunaTextBox13.Text) = "" Then
            GunaTextBox13.Text = 0
        End If

        GunaTextBox29.Text = Format(Double.Parse(GunaTextBox13.Text) * Double.Parse(GunaTextBoxNB4T4.Text), "#,##0")

        sommeTotalBillets()

    End Sub

    Private Sub GunaTextBoxQteGouter_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNB5.TextChanged

        If Trim(GunaTextBoxNB5T5.Text) = "" Then
            GunaTextBoxNB5T5.Text = 0
        End If

        If Trim(GunaTextBoxNB5.Text) = "" Then
            GunaTextBoxNB5.Text = 0
        End If

        GunaTextBoxPrixTotalGouter.Text = Format(Double.Parse(GunaTextBoxNB5.Text) * Double.Parse(GunaTextBoxNB5T5.Text), "#,##0")

        sommeTotalBillets()

    End Sub

    Public Sub sommeTotalBillets()

        If Trim(GunaTextBoxPrixTotalGouter.Text) = "" Then
            GunaTextBoxPrixTotalGouter.Text = 0
        End If

        If Trim(GunaTextBox29.Text) = "" Then
            GunaTextBox29.Text = 0
        End If

        If Trim(GunaTextBox31.Text) = "" Then
            GunaTextBox31.Text = 0
        End If

        If Trim(GunaTextBox33.Text) = "" Then
            GunaTextBox33.Text = 0
        End If

        If Trim(GunaTextBox37.Text) = "" Then
            GunaTextBox37.Text = 0
        End If

        GunaTextBox7.Text = Format(Double.Parse(GunaTextBoxPrixTotalGouter.Text) + Double.Parse(GunaTextBox29.Text) + Double.Parse(GunaTextBox31.Text) + Double.Parse(GunaTextBox33.Text) + Double.Parse(GunaTextBox37.Text), "#,##0")

        If Trim(GunaTextBox7.Text) = "" Then
            GunaTextBox7.Text = 0
        End If

        If Trim(GunaTextBox21.Text) = "" Then
            GunaTextBox21.Text = 0
        End If

        GunaTextBox22.Text = Format(Double.Parse(GunaTextBox7.Text) + Double.Parse(GunaTextBox21.Text), "#,##0")

        afficherButtonTrasnfert()

    End Sub

    Public Sub afficherButtonTrasnfert()

        Dim situationCaisse As Double = 0

        Dim montantBilletage As Double = 0

        If Not Trim(LabelSituationCaisse.Text) = "" Then
            Double.TryParse(LabelSituationCaisse.Text, situationCaisse)
        End If

        If situationCaisse > 0 Then

            If Not Trim(GunaTextBox22.Text) = "" Then
                Double.TryParse(GunaTextBox22.Text, montantBilletage)
            End If

            If situationCaisse = montantBilletage Then
                GunaButtonSaveFacturation.Enabled = True
                GunaTextBox22.BaseColor = Color.LightGreen
            Else
                GunaButtonSaveFacturation.Enabled = False
                GunaTextBox22.BaseColor = Color.Pink
            End If

        Else

            GunaButtonSaveFacturation.Enabled = False
            GunaTextBox22.BaseColor = Color.Pink

        End If

    End Sub

    Private Sub GunaTextBox9_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox9.TextChanged

        If Trim(GunaTextBox9.Text) = "" Then
            GunaTextBox9.Text = 0
        End If

        If Trim(GunaTextBox2.Text) = "" Then
            GunaTextBox2.Text = 0
        End If

        GunaTextBox4.Text = Format(GunaTextBox9.Text * GunaTextBox2.Text, "#,##0")
        sommeTotalPeices()

    End Sub

    Private Sub GunaTextBox20_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox20.TextChanged
        If Trim(GunaTextBox20.Text) = "" Then
            GunaTextBox20.Text = 0
        End If

        If Trim(GunaTextBox3.Text) = "" Then
            GunaTextBox3.Text = 0
        End If
        GunaTextBox16.Text = Format(GunaTextBox20.Text * GunaTextBox3.Text, "#,##0")
        sommeTotalPeices()
    End Sub

    Private Sub GunaTextBox15_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox15.TextChanged
        If Trim(GunaTextBox15.Text) = "" Then
            GunaTextBox15.Text = 0
        End If

        If Trim(GunaTextBox6.Text) = "" Then
            GunaTextBox6.Text = 0
        End If
        GunaTextBox1.Text = Format(GunaTextBox15.Text * GunaTextBox6.Text, "#,##0")
        sommeTotalPeices()
    End Sub

    Private Sub GunaTextBox10_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox10.TextChanged
        If Trim(GunaTextBox10.Text) = "" Then
            GunaTextBox10.Text = 0
        End If

        If Trim(GunaTextBox14.Text) = "" Then
            GunaTextBox14.Text = 0
        End If
        GunaTextBox17.Text = Format(GunaTextBox10.Text * GunaTextBox14.Text, "#,##0")
        sommeTotalPeices()
    End Sub

    Private Sub GunaTextBox8_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox8.TextChanged
        If Trim(GunaTextBox8.Text) = "" Then
            GunaTextBox8.Text = 0
        End If

        If Trim(GunaTextBox11.Text) = "" Then
            GunaTextBox11.Text = 0
        End If
        GunaTextBox19.Text = Format(GunaTextBox8.Text * GunaTextBox11.Text, "#,##0")
        sommeTotalPeices()
    End Sub

    Private Sub GunaTextBox5_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox5.TextChanged
        If Trim(GunaTextBox5.Text) = "" Then
            GunaTextBox5.Text = 0
        End If

        If Trim(GunaTextBox18.Text) = "" Then
            GunaTextBox18.Text = 0
        End If
        GunaTextBox12.Text = Format(GunaTextBox5.Text * GunaTextBox18.Text, "#,##0")
        sommeTotalPeices()
    End Sub

    Private Sub GunaTextBoxNP7_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNP7.TextChanged

        If Trim(GunaTextBoxNP7.Text) = "" Then
            GunaTextBoxNP7.Text = 0
        End If

        If Trim(GunaTextBoxNP7T7.Text) = "" Then
            GunaTextBoxNP7T7.Text = 0
        End If

        GunaTextBox23.Text = Format(GunaTextBoxNP7T7.Text * GunaTextBoxNP7.Text, "#,##0")

        sommeTotalPeices()

    End Sub

    Public Sub sommeTotalPeices()

        If Trim(GunaTextBox12.Text) = "" Then
            GunaTextBox12.Text = 0
        End If

        If Trim(GunaTextBox19.Text) = "" Then
            GunaTextBox19.Text = 0
        End If

        If Trim(GunaTextBox17.Text) = "" Then
            GunaTextBox17.Text = 0
        End If

        If Trim(GunaTextBox1.Text) = "" Then
            GunaTextBox1.Text = 0
        End If

        If Trim(GunaTextBox16.Text) = "" Then
            GunaTextBox16.Text = 0
        End If

        If Trim(GunaTextBox4.Text) = "" Then
            GunaTextBox4.Text = 0
        End If

        If Trim(GunaTextBox22.Text) = "" Then
            GunaTextBox22.Text = 0
        End If

        If Trim(GunaTextBox23.Text) = "" Then
            GunaTextBox23.Text = 0
        End If

        GunaTextBox21.Text = Format(Double.Parse(GunaTextBox12.Text) + Double.Parse(GunaTextBox19.Text) + Double.Parse(GunaTextBox17.Text) + Double.Parse(GunaTextBox1.Text) + Double.Parse(GunaTextBox16.Text) + Double.Parse(GunaTextBox4.Text) + Double.Parse(GunaTextBox23.Text), "#,##0")

        If Trim(GunaTextBox7.Text) = "" Then
            GunaTextBox7.Text = 0
        End If

        If Trim(GunaTextBox21.Text) = "" Then
            GunaTextBox21.Text = 0
        End If

        GunaTextBox22.Text = Format(Double.Parse(GunaTextBox7.Text) + Double.Parse(GunaTextBox21.Text), "#,##0")

        afficherButtonTrasnfert()

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Dim RECETTE_A_TRANSFERER

    Private Sub GunaButtonSaveFacturation_Click(sender As Object, e As EventArgs) Handles GunaButtonSaveFacturation.Click

        Dim args As ArgumentType = New ArgumentType()
        Dim dtParentCategory As DataTable

        Dim closeMe As Boolean = False

        If GlobalVariable.billetageAPartirDe = "petite caisse" Then

            'LE TRAITEMENT DONC LA FERMETURE DE PTITE CAISSE NE NECESSITE PAS LE TRANSFERTS DE FONDS MAIS PLUS TOT UNE PASSATION DE CAISSE
            TransfertDeClientEntreCaissierForm.Close()
            TransfertDeClientEntreCaissierForm.Show()
            TransfertDeClientEntreCaissierForm.TopMost = True

        Else

            Dim continuer As Boolean = True
            Dim dialog_1 As DialogResult

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Do you want to transfer your funds"
                languageTitle = "Funds Transfer"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Voulez-vous Transférer votre recette à la caissière "
                languageTitle = "Transfert de Caisse"
            End If

            dialog_1 = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            If dialog_1 = DialogResult.No Then

                GlobalVariable.transfertDeCaisseVersCaissiere = False

                continuer = False

            Else

                GlobalVariable.transfertDeCaisseVersCaissiere = True

                If GlobalVariable.billetageAPartirDe = "reception" Or GlobalVariable.billetageAPartirDe = "comptable" Then

                    'FacturationForm.Close()

                    Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                    Dim CODE_CAISSE As String = ""

                    Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                    If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                        CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

                        MainWindow.FermerCaisseToolStripMenuItem.Visible = False

                        MainWindow.OuvrirCaisseToolStripMenuItem.Visible = True

                    End If

                    Dim ETAT_CAISSE As Integer = 0

                    Dim caissier As New Caisse()

                    caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                    RECETTE_A_TRANSFERER = LabelSituationCaisse.Text

                    'PENSER AUSSI A FAIRE CECI LORS DE FERMETURE DE CAISSE A LA CLOTURE

                    Dim encaissementDuCaissierActuel As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

                    If Not encaissementDuCaissierActuel Is Nothing Then

                        If encaissementDuCaissierActuel.Rows.Count > 0 Then

                            Dim ETAT As Integer = 1
                            Dim NUM_REGLEMENT As String = ""
                            Dim reglement As New Reglement()

                            For i = 0 To encaissementDuCaissierActuel.Rows.Count - 1

                                NUM_REGLEMENT = Trim(encaissementDuCaissierActuel.Rows(i)("NUM_REGLEMENT"))

                                reglement.UpdateEtatReglementPourClientComptoire(NUM_REGLEMENT, ETAT)

                            Next

                            BarRestaurantForm.traitementDeRecettePourTransfertVersLaCaissePrincipale(RECETTE_A_TRANSFERER, CODE_UTILISATEUR)

                        End If

                    End If

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Funds successfully transfered "
                        languageTitle = "Funds Transfer"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Recètte transférée et Caisse fermée avec succès !"
                        languageTitle = "Transfert de Caisse"
                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)


                    '-----------------------------------------------

                    'CHARGEMENT DU FICHIER DE VENTILATION DU SHIFT APRES CLOTURE DE CAISSE

                    '-----------------------------------------------

                    'CHARGEMENT DU FICHIER DE VENTILATION DU SHIFT APRES CLOTURE DE CAISSE

                    'GESTION DES SHIFTS

                    Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                    Dim SHIFT_VALUE As Integer = GlobalVariable.shiftActuel
                    Dim DEBUT_FIN As Integer = 1 'METTRE A JOUR LE STOCK DE FIN

                    Functions.inventaireJournalierTextFile(CODE_MAGASIN, SHIFT_VALUE, DEBUT_FIN)

                    '-----------------------------------------------


                ElseIf GlobalVariable.billetageAPartirDe = "bar" Then

                    'AU NIVEAU DU BAR AVANT CLOTURE ON DOIT VERIFIER QUE LES CAISSES SONT EQUILIBREES

                    Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                    Dim CODE_CAISSE As String = ""

                    Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                    If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                        CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

                        BarRestaurantForm.FermerCaisseToolStripMenuItem.Visible = False

                        BarRestaurantForm.OuvrirCaisseToolStripMenuItem.Visible = True

                    End If

                    Dim ETAT_CAISSE As Integer = 0
                    Dim caissier As New Caisse()

                    caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                    'MISE AJOURS DE ETAT (REGLEMENT) : POUR NE PLUS PRENDRE EN COMPTE LES REGLEMENTS APRES CLOTURE

                    Dim encaissementDuCaissierActuel As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

                    Dim ETAT As Integer = 1
                    Dim NUM_REGLEMENT As String = ""
                    Dim reglement As New Reglement()

                    RECETTE_A_TRANSFERER = 0

                    If Not encaissementDuCaissierActuel Is Nothing Then

                        If encaissementDuCaissierActuel.Rows.Count > 0 Then

                            For i = 0 To encaissementDuCaissierActuel.Rows.Count - 1

                                NUM_REGLEMENT = Trim(encaissementDuCaissierActuel.Rows(i)("NUM_REGLEMENT"))
                                If GlobalVariable.actualLanguageValue = 0 Then

                                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                                End If

                                If Trim(encaissementDuCaissierActuel.Rows(i)("MODE_REGLEMENT")) = "Espèce" Or Trim(encaissementDuCaissierActuel.Rows(i)("MODE_REGLEMENT")) = "Cash" Then
                                    RECETTE_A_TRANSFERER += encaissementDuCaissierActuel.Rows(i)("MONTANT_VERSE")
                                End If

                                reglement.UpdateEtatReglementPourClientComptoire(NUM_REGLEMENT, ETAT)

                            Next

                        End If

                    End If

                    Dim ETAT_FACTURE As Integer = 1 ' BLOC NOTE PLUS PRIS EN COMPTE DANS LES VENTES DU JOURS ET AUSSI UTILISE POUR LES LIGNES DE FACTURE
                    '------------------------------------------------------------------------------------------------------------------------------

                    'MISE AJOURS DE ETAT_FACTURE (LIGNE_BLOC_NOTE) : POUR NE PLUS PRENDRE LES LIGNES DE BLOC NOTES APRES CLOTURE

                    Dim ligneFacture As New LigneFacture()
                    Dim caisseGest As New Caisse()

                    Dim NUMERO_BLOC_NOTE As String = ""

                    Dim ETAT_BLOC_NOTE As Integer = 2 'CONDITION DONT DEVRA REMPLIR LES BLOC NOTES A CLOTURER
                    Dim ETAT_ = 1
                    Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

                    Dim blocNoteDuCaissierActuel As DataTable = caisseGest.BlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

                    If Not encaissementDuCaissierActuel Is Nothing Then

                        If encaissementDuCaissierActuel.Rows.Count > 0 Then

                            For i = 0 To blocNoteDuCaissierActuel.Rows.Count - 1

                                NUMERO_BLOC_NOTE = blocNoteDuCaissierActuel.Rows(i)("NUMERO_BLOC_NOTE")
                                'MISE AJOURS DE BLOCS NOTE
                                ligneFacture.UpdateEtatLigneFacturePourClientComptoireApreCloture(NUMERO_BLOC_NOTE, ETAT_)

                            Next

                        End If

                    End If

                    '------------------------------------------------------------------------------------------------------------------------------

                    Dim caisse As New Caisse()

                    If True Then

                        Dim EN_CHAMBRE As Double = BarRestaurantForm.LabelTotalVenteEnChambre.Text
                        Dim EN_SALLE As Double = BarRestaurantForm.LabelVenteEvent.Text
                        Dim COMPTOIR As Double = BarRestaurantForm.LabelTotalVenteComptoire.Text
                        Dim COMPTE As Double = BarRestaurantForm.LabelVenteVersCompte.Text
                        Dim GRATUITEE As Double = BarRestaurantForm.LabelVenteOfferte.Text
                        Dim GRATUITE_EN_CHAMBRE As Double = BarRestaurantForm.LabelOffresEnChambre.Text
                        Dim TOTAL_VENTE As Double = BarRestaurantForm.GunaTextBoxTotalDesVentesJournaliere.Text
                        Dim DATE_VENTE As Date = GlobalVariable.DateDeTravail
                        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                        If CAISSE_UTILISATEUR.Rows.Count > 0 Then
                            CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")
                        End If

                        caisse.resume_vente_journaliere(EN_CHAMBRE, COMPTOIR, COMPTE, GRATUITEE, GRATUITE_EN_CHAMBRE, EN_SALLE, TOTAL_VENTE, DATE_VENTE, CODE_UTILISATEUR, CODE_AGENCE, CODE_CAISSE)

                    End If

                    '-----------------------------------------------

                    'CHARGEMENT DU FICHIER DE VENTILATION DU SHIFT APRES CLOTURE DE CAISSE

                    'GESTION DES SHIFTS

                    Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                    Dim SHIFT_VALUE As Integer = GlobalVariable.shiftActuel
                    Dim DEBUT_FIN As Integer = 1 'METTRE A JOUR LE STOCK DE FIN

                    Functions.inventaireJournalierTextFile(CODE_MAGASIN, SHIFT_VALUE, DEBUT_FIN)
                    '-----------------------------------------------

                    BarRestaurantForm.FermerCaisseToolStripMenuItem.Visible = False

                    BarRestaurantForm.OuvrirCaisseToolStripMenuItem.Visible = True

                    BarRestaurantForm.GunaTextBoxTotalDesVentesJournaliere.Text = 0
                    BarRestaurantForm.LabelTotalVenteEnChambre.Text = 0
                    BarRestaurantForm.LabelTotalVenteComptoire.Text = 0
                    BarRestaurantForm.LabelVenteOfferte.Text = 0
                    BarRestaurantForm.LabelVenteVersCompte.Text = 0
                    BarRestaurantForm.LabelSituationCaisse.Text = 0
                    BarRestaurantForm.LabelOffresEnChambre.Text = 0
                    BarRestaurantForm.LabelVenteEvent.Text = 0
                    BarRestaurantForm.LabelSituationCaisse.Text = 0

                    '-------------------------------------------------- GESTION DU TRANSFERT DE RECETTE -----------------------------------------------

                    BarRestaurantForm.traitementDeRecettePourTransfertVersLaCaissePrincipale(RECETTE_A_TRANSFERER, CODE_UTILISATEUR)

                    ligneFacture.UpdateEtatLigneFactureGratuite(CODE_UTILISATEUR, ETAT, DateDeSituation)
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Funds transfered and main cashier register successfully closed !"
                        languageTitle = "Main cashier register transfer"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Recette de caisse transférée et caisse fermée avec succès !"
                        languageTitle = "Transfert de caisse"
                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'ON ENVOI LE RAPPORT DE VENTE APRES LA CLOTURE JOURNEE OU DU SHIFT

                    Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
                    Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

                    GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT"
                    'Dim ligneFacture_ As New LigneFacture()
                    Dim CODE_CAISSIER_ As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                    dtParentCategory = ligneFacture.ListeDesCategoriesDArticleVendus(DateDebut, DateFin, CODE_CAISSIER_)

                    args.action = 0 'JOURNAL DES VENTES DU SHIFT
                    args.dt = dtParentCategory
                    args.DateDebut = DateDebut
                    args.DateFin = DateFin

                    GlobalVariable.transfertDeCaisseVersCaissiere = False 'PERMET DE CONTROLLER QUE VENDEUR EST D'ACCORDS AVEC LES MONTANTS RENSEIGNEES

                    GlobalVariable.transfertDeCaisseVersCaissiere = False

                    BarRestaurantForm.indicateurDEtatDeCaisse()

                    'RapportApresCloture.journalDesVentes(dtParentCategory, DateDebut, DateFin)

                End If

            End If

            'ENREGISTREMENT DU BILLETAGE

            Dim FORM_NAME As String = ""

            If GlobalVariable.billetageAPartirDe = "reception" Or GlobalVariable.billetageAPartirDe = "bar" Or GlobalVariable.billetageAPartirDe = "petite caisse" Then

                Dim NB1 As Integer = GunaTextBox35.Text
                Dim NB2 As Integer = GunaTextBox30.Text
                Dim NB3 As Integer = GunaTextBox25.Text
                Dim NB4 As Integer = GunaTextBox13.Text
                Dim NB5 As Integer = GunaTextBoxNB5.Text
                Dim NP1 As Integer = GunaTextBox9.Text
                Dim NP2 As Integer = GunaTextBox20.Text
                Dim NP3 As Integer = GunaTextBox15.Text
                Dim NP4 As Integer = GunaTextBox10.Text
                Dim NP5 As Integer = GunaTextBox8.Text
                Dim NP6 As Integer = GunaTextBox5.Text
                Dim NP7 As Integer = GunaTextBoxNP7.Text

                Dim NB1T1 As Double = GunaTextBoxNB1T1.Text
                Dim NB2T2 As Double = GunaTextBoxNB2T2.Text
                Dim NB3T3 As Double = GunaTextBoxNB3T3.Text
                Dim NB4T4 As Double = GunaTextBoxNB4T4.Text
                Dim NB5T5 As Double = GunaTextBoxNB5T5.Text
                Dim NP1T1 As Double = GunaTextBox2.Text
                Dim NP2T2 As Double = GunaTextBox3.Text
                Dim NP3T3 As Double = GunaTextBox6.Text
                Dim NP4T4 As Double = GunaTextBox14.Text
                Dim NP5T5 As Double = GunaTextBox11.Text
                Dim NP6T6 As Double = GunaTextBox18.Text
                Dim NP7T7 As Double = GunaTextBoxNP7T7.Text

                Dim REFERENCE_TRANSACTION As String = ""

                Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
                Dim GRAND_TOTAL As Double = RECETTE_A_TRANSFERER

                'SELECTION DU DERNIER ELEMENT DE LA TRANSACTION

                Dim caisse As New Caisse()

                If continuer Then

                    Dim adapter As New MySqlDataAdapter
                    Dim lastRecetteTransfere As New DataTable
                    Dim getUserQuery = "SELECT * FROM transfert_recette WHERE CODE_UTILISATEUR_CREA = @CODE_UTILISATEUR_CREA ORDER BY ID_FACTURE DESC"

                    Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
                    Command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_CAISSIER
                    adapter.SelectCommand = Command

                    adapter.Fill(lastRecetteTransfere)

                    If lastRecetteTransfere.Rows.Count > 0 Then
                        REFERENCE_TRANSACTION = lastRecetteTransfere.Rows(0)("CODE_FACTURE")
                    End If

                    caisse.insertBilletage(NB1, NB2, NB3, NB4, NB5, NP1, NP2, NP3, NP4, NP5, NP6, NP7, NB1T1, NB2T2, NB3T3, NB4T4, NB5T5, NP1T1, NP2T2, NP3T3, NP4T4, NP5T5, NP6T6, NP7T7, CODE_CAISSIER, REFERENCE_TRANSACTION, DATE_CREATION, GRAND_TOTAL)

                    'GENERATION DU BON DE TRANSFERT DE CAISSE

                    Dim LIBELLE_TRANSFERT As String = "TRANSFERT DE RECETTE PAR  " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " ( " & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] "
                    If GlobalVariable.actualLanguageValue = 0 Then
                        LIBELLE_TRANSFERT = "FUNDS TRANSFERED BY  " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " ( " & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] "
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        LIBELLE_TRANSFERT = "TRANSFERT DE RECETTE PAR  " & GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") & " ( " & GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR") & " ) [ " & GlobalVariable.DateDeTravail & " ] "
                    End If

                    Dim DEBIT As Double = 0
                    Dim CREDIT As Double = RECETTE_A_TRANSFERER

                    closeMe = True

                    Functions.BonDeCaisseDeTransfert(CODE_CAISSIER, REFERENCE_TRANSACTION, LIBELLE_TRANSFERT, DEBIT, CREDIT, REFERENCE_TRANSACTION, FORM_NAME)

                End If

            End If

        End If

        If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then

            If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

                If dtParentCategory IsNot Nothing Then

                    If dtParentCategory.Rows.Count > 0 Then
                        backGroundWorkerToCall(args)
                    End If

                End If

            End If

        End If

        'ON SE RASSURE QUE TOUS LES ETAT_FACTURE QUI SONT PASSE A ZERO 1 ET N'ETANT PAS ASSOCIE A NUMERO DE FACTURE REPASSE A ZERO
        CloturerForm.miseAjoursDesLignesDeChargeDeHebergementPasAssocieAUneFacture(GlobalVariable.DateDeTravail)

        If closeMe Then
            Me.Close()
        End If

    End Sub

    Public Sub backGroundWorkerToCall(ByVal args As ArgumentType)

        If Not BackgroundWorker2.IsBusy Then
            BackgroundWorker2.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker3.IsBusy Then
            BackgroundWorker3.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker4.IsBusy Then
            BackgroundWorker4.RunWorkerAsync(args)
        ElseIf Not BackgroundWorker5.IsBusy Then
            BackgroundWorker5.RunWorkerAsync(args)
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


    Private Sub documentToBeSendUsingBackGroundWorker(ByVal args As ArgumentType)

        If args.action = 0 Then
            'FOR RAPPORT FINANCIER
            RapportApresCloture.docJournalDesVentesShift(args.dt, args.DateDebut, args.DateFin)
        ElseIf args.action = 1 Then

        ElseIf args.action = 2 Then

        ElseIf args.action = 3 Then

        ElseIf args.action = 4 Then

        ElseIf args.action = 5 Then

        End If

    End Sub


End Class