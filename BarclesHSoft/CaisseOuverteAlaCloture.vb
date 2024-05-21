Imports MySql.Data.MySqlClient

Public Class CaisseOuverteAlaCloture

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.caisseOuverteAlaClot(GlobalVariable.actualLanguageValue)

        Me.TopMost = True

        verificationDesCaisseOuverte()

    End Sub

    Private Sub verificationDesCaisseOuverte()

        GunaDataGridViewCaisseOuverte.Rows.Clear()

        Dim caissier As New Caisse()

        Dim ETAT_CAISSE As Integer = 1

        Dim toutesLesCaisseSontFermees As Boolean = False

        'We find tarif based on the code of the client
        Dim FillingListquery As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            FillingListquery = "SELECT `CODE_CAISSE` As 'CASH REGISTER CODE', `LIBELLE_CAISSE` AS 'CASH REGISTER NAME', `CODE_UTILISATEUR` As 'USER CODE' FROM caisse WHERE ETAT_CAISSE= @ETAT_CAISSE"
        Else
            FillingListquery = "SELECT `CODE_CAISSE` As 'CODE CAISSE', `LIBELLE_CAISSE` AS 'LIBELLE CAISSE', `CODE_UTILISATEUR` As 'CODE UTILISATEUR' FROM caisse WHERE ETAT_CAISSE= @ETAT_CAISSE"
        End If

        Dim commandList1 As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList1.Parameters.Add("@ETAT_CAISSE", MySqlDbType.VarChar).Value = ETAT_CAISSE

        Dim adapterList1 As New MySqlDataAdapter(commandList1)
        Dim lesCaisses As New DataTable()

        adapterList1.Fill(lesCaisses)

        Dim btn As New DataGridViewButtonColumn()

        If lesCaisses.Rows.Count > 0 Then
            'GunaDataGridViewCaisseOuverte.DataSource = lesCaisses

            GunaDataGridViewCaisseOuverte.ColumnCount = 3

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewCaisseOuverte.Columns(0).Name = "CASH REGISTER CODE"
                GunaDataGridViewCaisseOuverte.Columns(1).Name = "CASH REGISTER NAME"

                GunaDataGridViewCaisseOuverte.Columns(2).Name = "USER CODE"

            Else

                GunaDataGridViewCaisseOuverte.Columns(0).Name = "CODE CAISSE"
                GunaDataGridViewCaisseOuverte.Columns(1).Name = "LIBELLE CAISSE"

                GunaDataGridViewCaisseOuverte.Columns(2).Name = "CODE UTILISATEUR"


            End If

            Dim TotalDesVentes As Double = 0
            Dim TotalEncaisse As Double = 0

            Dim buttonName As String = ""
            Dim buttonText As String = ""

            Dim row As String()
            Dim CODE_CAISSE As String
            Dim CODE_UTILISATEUR As String

            For i = 0 To lesCaisses.Rows.Count - 1


                Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

                If GlobalVariable.actualLanguageValue = 0 Then

                    CODE_CAISSE = Trim(lesCaisses.Rows(i)("CASH REGISTER CODE"))
                    CODE_UTILISATEUR = Trim(lesCaisses.Rows(i)("USER CODE"))

                    row = New String() {CODE_CAISSE, lesCaisses.Rows(i)("CASH REGISTER NAME"), CODE_UTILISATEUR}

                Else
                    CODE_CAISSE = Trim(lesCaisses.Rows(i)("CODE CAISSE"))
                    CODE_UTILISATEUR = Trim(lesCaisses.Rows(i)("CODE UTILISATEUR"))

                    row = New String() {CODE_CAISSE, lesCaisses.Rows(i)("LIBELLE CAISSE"), CODE_UTILISATEUR}

                End If

                GunaDataGridViewCaisseOuverte.Rows.Add(row)

                'SELECTION DEL'ENSEMBLE DES BLOC NOTES NON CLOTURE ASSOCIE AUX VENTES COMTOIRES
                Dim totalVenteCaissier As DataTable = caissier.BlocNoteDunCaissierQuelconquePourEquilibre(DateDeSituation, CODE_UTILISATEUR)

                If totalVenteCaissier.Rows.Count > 0 Then

                    For j = 0 To totalVenteCaissier.Rows.Count - 1
                        TotalDesVentes += totalVenteCaissier.Rows(j)("MONTANT_BLOC_NOTE")
                    Next

                End If

                Dim totalDesEncaissement As DataTable = caissier.SituationDeCaisseDunCaissierQuelconque(DateDeSituation, CODE_UTILISATEUR)

                If totalDesEncaissement.Rows.Count > 0 Then

                    For j = 0 To totalDesEncaissement.Rows.Count - 1
                        TotalEncaisse += totalDesEncaissement.Rows(j)("MONTANT_VERSE")
                    Next

                End If

                Dim Solde As Double = TotalDesVentes - TotalEncaisse

                If Solde = 0 Then
                    'CAISSE EQUILIBRE
                    buttonName = CODE_UTILISATEUR
                    If GlobalVariable.actualLanguageValue = 0 Then
                        buttonText = "Close"
                    Else
                        buttonText = "Fermer"
                    End If

                ElseIf Solde > 0 Then 'Total des 

                    'CAISSE DEBITEUR'
                    buttonName = CODE_UTILISATEUR
                    If GlobalVariable.actualLanguageValue = 0 Then
                        buttonText = "Equilibrate"
                    Else
                        buttonText = "Equilibrer"
                    End If

                ElseIf Solde < 0 Then
                    'CAISSE CREDITEUR'
                    buttonName = CODE_UTILISATEUR
                    If GlobalVariable.actualLanguageValue = 0 Then
                        buttonText = "Close"
                    Else
                        buttonText = "Fermer"
                    End If

                End If

                btn.HeaderText = "Action"
                btn.Text = buttonText
                btn.Name = buttonName
                btn.UseColumnTextForButtonValue = True

            Next

            GunaDataGridViewCaisseOuverte.Columns.Add(btn)

            'MessageBox.Show()
            'TOUTES LES CAISSES SONT MAINTENANT EQUILIBRE ET CLOTURE ALORS ONT CONTINUENT AVEC LE PROCESSUS DE CLOTURE
        ElseIf Not Trim(GlobalVariable.gestionDeCaisseAvantCloture) = "" Then

            CloturerForm.Close()
            CloturerForm.Show()
            CloturerForm.TopMost = True

            Me.Close()

        End If

        'GunaDataGridViewCaisseOuverte.Columns(3).Visible = False

    End Sub


    Private Sub GunaDataGridViewCaisseOuverte_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridViewCaisseOuverte.CellClick

        If e.ColumnIndex = 3 Then
            'MsgBox(("Row : " + e.RowIndex.ToString & "  Col : ") + e.ColumnIndex.ToString)

            'Dim CODE_CAISSIER As String = GunaDataGridViewCaisseOuverte.Columns(e.ColumnIndex).Name
            'Dim CODE_CAISSIER As String = GunaDataGridViewCaisseOuverte.CurrentCell.Value

            Dim cel As DataGridViewButtonCell

            Dim CODE_CAISSIER As String = ""
            Dim CODE_CAISSE As String = ""

            cel = CType(GunaDataGridViewCaisseOuverte.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewButtonCell)
            CODE_CAISSIER = GunaDataGridViewCaisseOuverte.Rows(e.RowIndex).Cells(2).Value
            CODE_CAISSE = GunaDataGridViewCaisseOuverte.Rows(e.RowIndex).Cells(0).Value

            If cel.Value = "Fermer" Or cel.Value = "Close" Then

                Dim ETAT_CAISSE As Integer = 0
                Dim caissier As New Caisse()

                caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                GlobalVariable.gestionDeCaisseAvantCloture = CODE_CAISSIER

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Cash register " & CODE_CAISSE & " successfully closed !"
                    languageTitle = "Closing of cash register"
                Else
                    languageMessage = "Caisse " & CODE_CAISSE & " fermée avec succès !"
                    languageTitle = "Fermeture de caisse"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                '----------------------------------------------------------------------------------------------------------------------

                'ON DETERMINE SI ON DOIT FAIRE UN TRANSFERT DE CAISSE
                Dim especes As Double = 0
                especes = Functions.SituationDeCaisseEspeces(GlobalVariable.DateDeTravail, CODE_CAISSIER)

                'EN CAS D'ESPECES ON DOIT TRANSFERER LE MONTANT ET TRAITER LA GESTION DES SHIFTS ET RESUME DEVENTES
                transfertDeRecetteAlaCloture(CODE_CAISSIER, especes)

                If especes > 0 Then
                    'transfertDeRecetteAlaCloture(CODE_CAISSIER)
                End If

                Me.Activate()

                '----------------------------------------------------------------------------------------------------------------------

            ElseIf cel.Value = "Equilibrer" Or cel.Value = "Equilibrate" Then

                GlobalVariable.gestionDeCaisseAvantCloture = CODE_CAISSIER

                ComparaisonVenteReglement.Close()
                ComparaisonVenteReglement.Show()
                ComparaisonVenteReglement.TopMost = True

                Me.Close()

            End If

            'MessageBox.Show(cel.Value, "In")
        End If

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub CaisseOuverteAlaCloture_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        verificationDesCaisseOuverte()
    End Sub

    Public Sub transfertDeRecetteAlaCloture(ByVal CODE_CAISSIER As String, Optional ByVal ESPECE As Double = 0)

        '1- TRAITER LES VENTES DU CAISSIER

        Dim ligneFacture As New LigneFacture()
        Dim caisseGest As New Caisse()

        Dim NUMERO_BLOC_NOTE As String = ""

        Dim ETAT As Integer = 1 ' BLOC NOTE PLUS PRIS EN COMPTE DANS LES VENTES DU JOURS
        Dim ETAT_BLOC_NOTE As Integer = 2

        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

        'MODIFICATION DE BLOC NOTES
        Dim blocNoteDuCaissierActuel As DataTable = caisseGest.BlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        For i = 0 To blocNoteDuCaissierActuel.Rows.Count - 1
            NUMERO_BLOC_NOTE = blocNoteDuCaissierActuel.Rows(i)("NUMERO_BLOC_NOTE")
            ligneFacture.UpdateEtatLigneFacturePourClientComptoireApreCloture(NUMERO_BLOC_NOTE, ETAT) 'ligne_facture_bloc_note
        Next

        '2- TRAITER LES REGLEMENTS DU CAISSIER EN DETERMINANT LE MONTANT A TRANSFERER

        Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT ORDER BY DATE_REGLEMENT DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        'command.Parameters.Add("@MODE_REGLEMENT", MySqlDbType.VarChar).Value = "Espèce"
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0

        Dim adapter As New MySqlDataAdapter

        Dim encaissementDuCaissierActuel As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(encaissementDuCaissierActuel)

        Dim RECETTE_A_TRANSFERER As Double = 0

        Dim NUM_REGLEMENT As String = ""
        Dim reglement As New Reglement()

        For i = 0 To encaissementDuCaissierActuel.Rows.Count - 1

            NUM_REGLEMENT = Trim(encaissementDuCaissierActuel.Rows(i)("NUM_REGLEMENT"))

            If Trim(encaissementDuCaissierActuel.Rows(i)("MODE_REGLEMENT")) = "Espèce" Or Trim(encaissementDuCaissierActuel.Rows(i)("MODE_REGLEMENT")) = "Cash" Then
                RECETTE_A_TRANSFERER += encaissementDuCaissierActuel.Rows(i)("MONTANT_VERSE")
            End If

            reglement.UpdateEtatReglementPourClientComptoire(NUM_REGLEMENT, ETAT)

        Next

        '2- TRANSFERER LES FONDS

        If ESPECE > 0 Then

            'CONETIENT LA FUNCTION QUI TRAITERA LA MISE A JOURS DES LIGNES_FACTURES ET TRANSFERT DES FONDS
            BarRestaurantForm.traitementDeRecettePourTransfertVersLaCaissePrincipale(RECETTE_A_TRANSFERER, CODE_CAISSIER)

        End If

        Dim ligneBlocNoteDuCaissierActuel As DataTable = caisseGest.ligneDesBlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

        If ligneBlocNoteDuCaissierActuel.Rows.Count > 0 Then

            For i = 0 To ligneBlocNoteDuCaissierActuel.Rows.Count - 1

                Dim ID_LIGNE_FACTURE As Integer = ligneBlocNoteDuCaissierActuel.Rows(i)("ID_LIGNE_FACTURE")
                Dim updateQuery As String = "UPDATE `ligne_facture` SET `ETAT`= @ETAT WHERE ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE AND CODE_RESERVATION =@CODE_RESERVATION"
                Dim command_ As New MySqlCommand(updateQuery, GlobalVariable.connect)

                command_.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1
                command_.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.VarChar).Value = ID_LIGNE_FACTURE
                command_.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                command_.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = "-" 'PERMET DE NE PAS PRENDRE LES VENTES EN CHAMBRE DANS LE CAS OU C'EST UN RECEPTIONNIST QUI FAIT LA VENTE

                command_.ExecuteNonQuery()

            Next

        End If

        'TRANSFERT DE CAISSE A LA CLOTURE DE 
        'Functions.BonDeCaisseDeTransfert(CODE_CAISSIER, REFERENCE_TRANSACTION, LIBELLE_TRANSFERT, DEBIT, CREDIT)
        Dim infoSupCaissier As DataTable = Functions.getElementByCode(CODE_CAISSIER, "caisse", "CODE_UTILISATEUR")
        Dim CODE_CAISSE As String = ""
        Dim NOM_UTILISATEUR As String = ""

        If infoSupCaissier.Rows.Count > 0 Then
            CODE_CAISSE = infoSupCaissier.Rows(0)("CODE_CAISSE")
        End If

        '------------------------------------------ MISE A JOUR DE GESTION DE SHIFT DU CAISSIER DONT ON FERME LA CAISSE 

        If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 1 Then

            Dim DATE_SHIFT As Date = DateDeSituation.ToShortDateString
            'UNIQUEMENT SI ON GERE LES STOCKS

            Dim ligne_facture As New LigneFacture()
            Dim shiftExist As DataTable = ligne_facture.existenceDuShiftDunUtilisateur(CODE_CAISSIER, DATE_SHIFT)

            If shiftExist.Rows.Count > 0 Then

                Dim CODE_MAGASIN As String = shiftExist.Rows(0)("CODE_MAGASIN")
                Dim SHIFT_VALUE As Integer = shiftExist.Rows(0)("INDEX_SHIFT")
                NOM_UTILISATEUR = shiftExist.Rows(0)("NOM_UTILISATEUR")
                Dim DEBUT_FIN As Integer = 1 'METTRE A JOUR LE STOCK DE FIN
                Dim NIGHT_AUDIT As Integer = 1

                Functions.inventaireJournalierTextFile(CODE_MAGASIN, SHIFT_VALUE, DEBUT_FIN, NIGHT_AUDIT, CODE_CAISSIER, NOM_UTILISATEUR)

            End If

        End If

        '---------------------------------------- INSERTION DES RESUMES DE VENTE JOURNALIERE GESTION DE SHITFT 

        Dim EN_CHAMBRE As Double = 0
        Dim COMPTOIR As Double = 0
        Dim COMPTE As Double = 0
        Dim GRATUITEE As Double = 0
        Dim GRATUITE_EN_CHAMBRE As Double = 0
        Dim EN_SALLE As Double = 0

        Dim caisse As New Caisse()

        Dim ligneFactureBlocNote As DataTable = caisseGest.BlocNoteDunCaissierQuelconqueCloture(DateDeSituation, CODE_CAISSIER)

        If ligneFactureBlocNote.Rows.Count > 0 Then

            For i = 0 To ligneFactureBlocNote.Rows.Count - 1

                If ligneFactureBlocNote.Rows(i)("ETAT_FACTURE") = 0 Then
                    COMPTOIR += ligneFactureBlocNote.Rows(i)("MONTANT_BLOC_NOTE")
                ElseIf ligneFactureBlocNote.Rows(i)("ETAT_FACTURE") = 1 Then
                    EN_CHAMBRE += ligneFactureBlocNote.Rows(i)("MONTANT_BLOC_NOTE")
                ElseIf ligneFactureBlocNote.Rows(i)("ETAT_FACTURE") = 3 Then
                    COMPTE += ligneFactureBlocNote.Rows(i)("MONTANT_BLOC_NOTE")
                ElseIf ligneFactureBlocNote.Rows(i)("ETAT_FACTURE") = 2 Then
                    GRATUITEE += ligneFactureBlocNote.Rows(i)("MONTANT_BLOC_NOTE")
                End If

            Next

        End If

        Dim getUserQuery01 = "SELECT * FROM ligne_facture_gratuite, reserve_conf WHERE CODE_UTILISATEUR_CREA = @CODE_CAISSIER AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT AND ligne_facture_gratuite.CODE_RESERVATION =  reserve_conf.CODE_RESERVATION ORDER BY DATE_FACTURE DESC"

        Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

        ETAT = 0

        command01.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command01.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT
        Dim adapter01 As New MySqlDataAdapter

        Dim dt01 As New DataTable()

        adapter01.SelectCommand = command01
        adapter01.Fill(dt01)

        If dt01.Rows.Count > 0 Then

            For j = 0 To dt01.Rows.Count - 1
                If Not Trim(dt01.Rows(j)("CODE_RESERVATION")) = "-" Then
                    GRATUITE_EN_CHAMBRE += dt01.Rows(j)("MONTANT_TTC")
                End If
            Next

        End If

        Dim TOTAL_VENTE As Double = EN_CHAMBRE + COMPTOIR + COMPTE + GRATUITEE + EN_SALLE
        Dim DATE_VENTE As Date = GlobalVariable.DateDeTravail.ToShortDateString
        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        caisse.resume_vente_journaliere(EN_CHAMBRE, COMPTOIR, COMPTE, GRATUITEE, GRATUITE_EN_CHAMBRE, EN_SALLE, TOTAL_VENTE, DATE_VENTE, CODE_CAISSIER, CODE_AGENCE, CODE_CAISSE)

        '-------------------------------------------------------------------------------------------------------------------------------------

    End Sub

End Class