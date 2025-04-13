Imports MySql.Data.MySqlClient

Public Class FastFoodForm

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

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub FastFoodForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GlobalVariable.typeDeClientAFacturer = "comptoir"
        GunaComboBoxCommandeStatus.SelectedIndex = 0

        Dim language As New Languages()

        language.fastFood(GlobalVariable.actualLanguageValue)

        If GlobalVariable.actualLanguageValue = 0 Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("BAR_FAST_FOOD") = 1 Then
                Label21.Text = "BAR SALES"
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("RESTAURANT_FAST_FOOD") = 1 Then
                Label21.Text = "RESTAURANT SALES"
            End If


            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("RESTAURANT_FAST_FOOD") = 1 And GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("BAR_FAST_FOOD") = 1 Then
                Label21.Text = "BAR / RESTAURANT SALES"
            End If

            Label1.Text = "BAR / RESTAURANT SALES"

        Else

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("BAR_FAST_FOOD") = 1 Then
                Label21.Text = "VENTES DU BAR"
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("RESTAURANT_FAST_FOOD") = 1 Then
                Label21.Text = "VENTES RESTAURANT"
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("RESTAURANT_FAST_FOOD") = 1 And GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("BAR_FAST_FOOD") = 1 Then
                'Label21.Text = "VENTES BAR / RESTAURANT"
            End If

            Label1.Text = "VENTES BAR / RESTAURANT"

        End If

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail

        GunaComboBoxCommandeStatus.SelectedIndex = 0

        TimerOuvert.Start()

        AutoLoadOfBlocNoteOuvert()
        AutoLoadOfBlocNoteAPayer()
        'AutoLoadOfBlocNotePaid()

        SituationDeCaisseJournaliere()

        indicateurDEtatDeCaisse()

        resumeDesVentesDuJours(GlobalVariable.DateDeTravail)

        GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

    End Sub

    Dim CODE_FACTURE As String = ""
    Dim NUMERO_BLOC_NOTE As String = ""

    Public Function elemenets_de_commande(ByVal CODE_FACTURE As String) As DataTable

        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

        Dim query As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',PRIX_UNITAIRE_TTC As 'PU', 
                ligne_facture_temp.QUANTITE AS QTY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', GRIFFE_UTILISATEUR AS 'CASHIER', SERVEUR AS SERVER  
                , CODE_LOT, SORTIE FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND
                CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC',
                ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'CAISSIER', SERVEUR 
                , CODE_LOT, SORTIE FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' 
                AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"

        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        Dim adapter As New MySqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If Not table.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then

                query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',PRIX_UNITAIRE_TTC As 'PU', 
                ligne_facture.QUANTITE AS QTY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', GRIFFE_UTILISATEUR AS 'CASHIER', SERVEUR AS SERVER  
                , CODE_LOT, SORTIE FROM ligne_facture WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND
                CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC',
                ligne_facture.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'CAISSIER', SERVEUR 
                , CODE_LOT, SORTIE FROM ligne_facture WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' 
                AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"

            End If

            Dim command_ As New MySqlCommand(query, GlobalVariable.connect)
            command_.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

            Dim adapter_ As New MySqlDataAdapter(command_)

            adapter_.Fill(table)

        End If

        Return table

    End Function

    Public Sub OutPutLigneFacture(ByVal CODE_FACTURE As String)

        Dim table As DataTable = elemenets_de_commande(CODE_FACTURE)

        GunaDataGridViewLigneFacture.Columns.Clear()

        If table.Rows.Count > 0 Then

            GunaDataGridViewLigneFacture.DataSource = table
            GunaLabel8.Text = table.Rows.Count

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewLigneFacture.Columns("PU").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("PU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("QTY").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("AMOUNT ET").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("AMOUNT ET").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("AMOUNT ET").Visible = False
                GunaDataGridViewLigneFacture.Columns("AMOUNT IT").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("AMOUNT IT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("PU TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("MONTANT HT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("MONTANT HT").Visible = False
                GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("MONTANT TTC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            End If

            GunaDataGridViewLigneFacture.Columns("ARTICLE").Visible = False
            GunaDataGridViewLigneFacture.Columns("ID_LIGNE_FACTURE").Visible = False
            GunaDataGridViewLigneFacture.Columns("TYPE_LIGNE_FACTURE").Visible = False
            GunaDataGridViewLigneFacture.Columns("CODE_LOT").Visible = False

        Else
            GunaLabel8.Text = 0
        End If

        enAttenteDeLivraison(table)

        If GunaDataGridViewLigneFacture.Rows.Count > 0 Then
            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("SERVEUR") = 1 Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaDataGridViewLigneFacture.Columns("CASHIER").Visible = False
                Else
                    GunaDataGridViewLigneFacture.Columns("CAISSIER").Visible = False
                End If
            ElseIf GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("SERVEUR") = 0 Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    GunaDataGridViewLigneFacture.Columns("CASHIER").Visible = False
                Else
                    GunaDataGridViewLigneFacture.Columns("CAISSIER").Visible = False
                End If
            End If
        End If

        nombreDeBoissonOuRepasSorti()

        SituationDeCaisseJournaliere()

        resumeDesVentesDuJours(GlobalVariable.DateDeTravail)
        'TimerRefresh.Start()

    End Sub

    Public Sub nombreDeBoissonOuRepasSorti()

        If GunaDataGridViewBarRestaurant.Rows.Count > 0 Then
            GunaDataGridViewBarRestaurant.Rows(0).Selected = True
            GunaLabel5.Text = GunaDataGridViewBarRestaurant.Rows.Count
        Else
            GunaLabel5.Text = 0
        End If

        If GunaDataGridViewBarRestaurantSortie.Rows.Count > 0 Then
            GunaLabel6.Text = GunaDataGridViewBarRestaurantSortie.Rows.Count
        Else
            GunaLabel6.Text = 0
        End If

    End Sub

    Public Sub enAttenteDeLivraison(ByVal table As DataTable)

        GunaDataGridViewBarRestaurant.Columns.Clear()
        GunaDataGridViewBarRestaurantSortie.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then

            '1- ELEMENTS DU BAR / RESTAURANT

            GunaDataGridViewBarRestaurant.Columns.Add("ITEM", "ITEM")
            GunaDataGridViewBarRestaurant.Columns.Add("PU", "PU")
            GunaDataGridViewBarRestaurant.Columns.Add("QTY", "QTY")
            GunaDataGridViewBarRestaurant.Columns.Add("AMOUNT IT", "AMOUNT IT")
            GunaDataGridViewBarRestaurant.Columns.Add("SERVER", "SERVER")
            GunaDataGridViewBarRestaurant.Columns.Add("ID_LIGNE_FACTURE", "ID_LIGNE_FACTURE")

            GunaDataGridViewBarRestaurantSortie.Columns.Add("ITEM", "ITEM")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("PU", "PU")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("QTY", "QTY")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("AMOUNT IT", "AMOUNT IT")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("SERVER", "SERVER")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("ID_LIGNE_FACTURE", "ID_LIGNE_FACTURE")

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            '1- ELEMENTS DU BAR / RESTAURANT

            GunaDataGridViewBarRestaurant.Columns.Add("DESIGNATION", "DESIGNATION")
            GunaDataGridViewBarRestaurant.Columns.Add("PU TTC", "PU TTC")
            GunaDataGridViewBarRestaurant.Columns.Add("QUANTITE", "QUANTITE")
            GunaDataGridViewBarRestaurant.Columns.Add("MONTANT TTC", "MONTANT TTC")
            GunaDataGridViewBarRestaurant.Columns.Add("SERVEUR", "SERVEUR")
            GunaDataGridViewBarRestaurant.Columns.Add("ID_LIGNE_FACTURE", "ID_LIGNE_FACTURE")

            GunaDataGridViewBarRestaurantSortie.Columns.Add("DESIGNATION", "DESIGNATION")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("PU TTC", "PU TTC")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("QUANTITE", "QUANTITE")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("MONTANT TTC", "MONTANT TTC")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("SERVEUR", "SERVEUR")
            GunaDataGridViewBarRestaurantSortie.Columns.Add("ID_LIGNE_FACTURE", "ID_LIGNE_FACTURE")

        End If

        If table.Rows.Count > 0 Then

            Dim nombreTotal As Integer = table.Rows.Count

            For i = 0 To table.Rows.Count - 1

                If table.Rows(i)("SORTIE") = 0 Then

                    If GlobalVariable.DroitAccesDeUtilisateurConnect(0)("RESTAURANT_FAST_FOOD") = 1 Or GlobalVariable.DroitAccesDeUtilisateurConnect(0)("BAR_FAST_FOOD") = 1 Then

                        If GlobalVariable.DroitAccesDeUtilisateurConnect(0)("BAR_FAST_FOOD") = 1 Then
                            If table.Rows(i)("TYPE_LIGNE_FACTURE").Equals("BAR") Then
                                If GlobalVariable.actualLanguageValue = 0 Then
                                    GunaDataGridViewBarRestaurant.Rows.Add(table.Rows(i)("ITEM"), Format(table.Rows(i)("PU"), "#,##0"), Format(table.Rows(i)("QTY"), "#,##0"), Format(table.Rows(i)("AMOUNT IT"), "#,##0"), table.Rows(i)("SERVER").ToUpper, table.Rows(i)("ID_LIGNE_FACTURE"))
                                Else
                                    GunaDataGridViewBarRestaurant.Rows.Add(table.Rows(i)("DESIGNATION"), Format(table.Rows(i)("PU TTC"), "#,##0"), Format(table.Rows(i)("QUANTITE"), "#,##0"), Format(table.Rows(i)("MONTANT TTC"), "#,##0"), table.Rows(i)("SERVEUR").ToUpper, table.Rows(i)("ID_LIGNE_FACTURE"))
                                End If
                            End If
                        End If

                        If GlobalVariable.DroitAccesDeUtilisateurConnect(0)("RESTAURANT_FAST_FOOD") = 1 Then
                            If table.Rows(i)("TYPE_LIGNE_FACTURE").Equals("RESTAURANT") Then
                                If GlobalVariable.actualLanguageValue = 0 Then
                                    GunaDataGridViewBarRestaurant.Rows.Add(table.Rows(i)("ITEM"), Format(table.Rows(i)("PU"), "#,##0"), Format(table.Rows(i)("QTY"), "#,##0"), Format(table.Rows(i)("AMOUNT IT"), "#,##0"), table.Rows(i)("SERVER").ToUpper, table.Rows(i)("ID_LIGNE_FACTURE"))
                                Else
                                    GunaDataGridViewBarRestaurant.Rows.Add(table.Rows(i)("DESIGNATION"), Format(table.Rows(i)("PU TTC"), "#,##0"), Format(table.Rows(i)("QUANTITE"), "#,##0"), Format(table.Rows(i)("MONTANT TTC"), "#,##0"), table.Rows(i)("SERVEUR").ToUpper, table.Rows(i)("ID_LIGNE_FACTURE"))
                                End If
                            End If
                        End If

                    End If

                ElseIf table.Rows(i)("SORTIE") = 1 Then

                    If GlobalVariable.DroitAccesDeUtilisateurConnect(0)("RESTAURANT_FAST_FOOD") = 1 Or GlobalVariable.DroitAccesDeUtilisateurConnect(0)("BAR_FAST_FOOD") = 1 Then

                        If GlobalVariable.DroitAccesDeUtilisateurConnect(0)("BAR_FAST_FOOD") = 1 Then
                            If table.Rows(i)("TYPE_LIGNE_FACTURE").Equals("BAR") Then
                                If GlobalVariable.actualLanguageValue = 0 Then
                                    GunaDataGridViewBarRestaurantSortie.Rows.Add(table.Rows(i)("ITEM"), Format(table.Rows(i)("PU"), "#,##0"), Format(table.Rows(i)("QTY"), "#,##0"), Format(table.Rows(i)("AMOUNT IT"), "#,##0"), table.Rows(i)("SERVER").ToString.ToUpper, table.Rows(i)("ID_LIGNE_FACTURE"))
                                Else
                                    GunaDataGridViewBarRestaurantSortie.Rows.Add(table.Rows(i)("DESIGNATION"), Format(table.Rows(i)("PU TTC"), "#,##0"), Format(table.Rows(i)("QUANTITE"), "#,##0"), Format(table.Rows(i)("MONTANT TTC"), "#,##0"), table.Rows(i)("SERVEUR").ToString.ToUpper, table.Rows(i)("ID_LIGNE_FACTURE"))
                                End If
                            End If
                        End If

                        If GlobalVariable.DroitAccesDeUtilisateurConnect(0)("RESTAURANT_FAST_FOOD") = 1 Then
                            If table.Rows(i)("TYPE_LIGNE_FACTURE").Equals("RESTAURANT") Then
                                If GlobalVariable.actualLanguageValue = 0 Then
                                    GunaDataGridViewBarRestaurantSortie.Rows.Add(table.Rows(i)("ITEM"), Format(table.Rows(i)("PU"), "#,##0"), Format(table.Rows(i)("QTY"), "#,##0"), Format(table.Rows(i)("AMOUNT IT"), "#,##0"), table.Rows(i)("SERVER").ToString.ToUpper, table.Rows(i)("ID_LIGNE_FACTURE"))
                                Else
                                    GunaDataGridViewBarRestaurantSortie.Rows.Add(table.Rows(i)("DESIGNATION"), Format(table.Rows(i)("PU TTC"), "#,##0"), Format(table.Rows(i)("QUANTITE"), "#,##0"), Format(table.Rows(i)("MONTANT TTC"), "#,##0"), table.Rows(i)("SERVEUR").ToString.ToUpper, table.Rows(i)("ID_LIGNE_FACTURE"))
                                End If
                            End If
                        End If

                    End If
                End If

            Next

            If GunaDataGridViewBarRestaurant.Rows.Count > 0 Then
                GunaDataGridViewBarRestaurant.Rows(0).Selected = True
            End If

            NUMERO_BLOC_NOTE = GunaTextBoxNumBlocNote.Text
            Dim infoLigneFacture As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")

            If infoLigneFacture.Rows.Count > 0 Then

                Dim tout As Boolean = True

                For j = 0 To infoLigneFacture.Rows.Count - 1
                    If infoLigneFacture.Rows(j)("SORTIE") = 0 Then
                        tout = False
                        Exit For
                    End If
                Next

                If tout Then
                    Dim ETAT_BLOC_NOTE As Integer = 0
                    autoCloture(ETAT_BLOC_NOTE)
                End If

            End If

        End If

        GunaDataGridViewBarRestaurantSortie.Columns(5).Visible = False
        GunaDataGridViewBarRestaurant.Columns(5).Visible = False

    End Sub

    Public Sub autoCloture(ByVal ETAT_BLOC_NOTE As Integer)

        TimerFermer.Stop()
        TimerOuvert.Stop()

        Dim SORTIE As Integer = 1

        'Dim facturation As New LigneFacture()

        'facturation.MigrationDeLigneFatureTempVersLigneFactureComptoire(NUMERO_BLOC_NOTE)
        'ETAT_BLOC_NOTE = 1

        ETAT_BLOC_NOTE = 3
        Functions.updateOfFields("ligne_facture_bloc_note", "ETAT_BLOC_NOTE", ETAT_BLOC_NOTE, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 0)
        'Au met a jour le champ sortie de lgne_facture pour ne plus toucher la fonction des insertions
        Functions.updateOfFields("ligne_facture", "SORTIE", SORTIE, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 0)
        Functions.DeleteElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")

        AutoLoadOfBlocNoteAPayer()
        AutoLoadOfBlocNoteOuvert()

        TimerFermer.Start()
        TimerOuvert.Start()

    End Sub

    Public Sub regulationBlocNote(ByVal ETAT_BLOC_NOTE As Integer, ByVal NUMERO_BLOC_NOTE As String)

        Dim tout As Boolean = True

        Dim infoLigneFacture As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_temp", "NUMERO_BLOC_NOTE")
        If infoLigneFacture.Rows.Count > 0 Then
            For j = 0 To infoLigneFacture.Rows.Count - 1
                If infoLigneFacture.Rows(j)("SORTIE") = 0 Then
                    tout = False
                    Exit For
                End If
            Next
        End If

        If tout Then
            ETAT_BLOC_NOTE = 0
            autoCloture(ETAT_BLOC_NOTE)
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir livrer tous les éléments de la commande", "Clôture Commande", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Please deliver all the elements of the order", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Public Sub AutoLoadOfBlocNoteOuvert()

        Dim caisse As New Caisse()

        'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes a cloturer et a regler par apport a un caissier et un a la date de travail

        Dim ETAT_BLOC_NOTE As Integer = 1 'CLOTURER
        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

        'C- VISUALISATION DE LA LISTE DES BLOC NOTES
        Dim blocNoteAvisualiser As DataTable = caisse.AutoLoadBlocNoteVisualisationClasFastFoods(DateDeSituation, ETAT_BLOC_NOTE)

        GunaDataGridViewBlocNoteOuvert.Columns.Clear()

        If blocNoteAvisualiser.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaDataGridViewBlocNoteOuvert.Columns.Add("NUMERO", "NUMERO")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("MONTANT", "MONTANT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("ETAT", "ETAT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("SERVEUR", "SERVEUR")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("TEMPS", "TEMPS")
            Else
                GunaDataGridViewBlocNoteOuvert.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("AMOUNT", "AMOUNT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("STATE", "STATE")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("SERVER", "SERVER")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("TIME", "TIME")
            End If

            For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                If GlobalVariable.actualLanguageValue = 0 Then

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                    Dim SERVEUR As String = blocNoteAvisualiser.Rows(i)("SERVER")

                    If blocNoteAvisualiser.Rows(i)("STATE") = 0 Then
                        ETAT_NOTE = "OPENED"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                        ETAT_NOTE = "CLOSED"
                    End If

                    If blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                        GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), Format(blocNoteAvisualiser.Rows(i)("AMOUNT"), "#,##0"), ETAT_NOTE, SERVEUR.ToUpper, TEMPS)
                    End If

                    GunaDataGridViewBlocNoteOuvert.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteOuvert.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Else

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                    Dim SERVEUR As String = blocNoteAvisualiser.Rows(i)("SERVEUR")

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 0 Then
                        ETAT_NOTE = "OUVERT"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                        ETAT_NOTE = "FERME"
                    End If

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                        GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteAvisualiser.Rows(i)("MONTANT"), "#,##0"), ETAT_NOTE, SERVEUR.ToUpper, TEMPS)
                    End If

                    GunaDataGridViewBlocNoteOuvert.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteOuvert.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End If

            Next

        End If

        If GunaDataGridViewBlocNoteOuvert.Rows.Count > 0 Then
            GunaLabelCommande.Text = GunaDataGridViewBlocNoteOuvert.Rows.Count
        Else
            GunaLabelCommande.Text = 0
        End If

    End Sub


    Public Sub AutoLoadOfBlocNotePaid()

        Dim caisse As New Caisse()

        'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes a cloturer et a regler par apport a un caissier et un a la date de travail

        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

        Dim ETAT_BLOC_NOTE As Integer = 2 'REGLER
        Dim blocNoteAvisualiser As DataTable = caisse.AutoLoadBlocNoteVisualisationClasFastFoods(DateDeSituation, ETAT_BLOC_NOTE)

        GunaDataGridViewBlocNoteFermee.Columns.Clear()

        If blocNoteAvisualiser.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaDataGridViewBlocNoteFermee.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNoteFermee.Columns.Add("MONTANT", "MONTANT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("SERVEUR", "SERVEUR")
            Else
                GunaDataGridViewBlocNoteFermee.Columns.Add("RECEIPT", "RECEIPT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("AMOUNT", "AMOUNT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("SERVER", "SERVER")
            End If

            For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                If GlobalVariable.actualLanguageValue = 0 Then

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                    Dim SERVEUR As String = blocNoteAvisualiser.Rows(i)("SERVER")

                    If blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                        ETAT_NOTE = "CLOSED"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 2 Then
                        ETAT_NOTE = "PAID"
                    End If

                    If blocNoteAvisualiser.Rows(i)("STATE") = 2 Then
                        GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), Format(blocNoteAvisualiser.Rows(i)("AMOUNT"), "#,##0"), SERVEUR.ToUpper)
                    End If

                    GunaDataGridViewBlocNoteFermee.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteFermee.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Else

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                    Dim SERVEUR As String = blocNoteAvisualiser.Rows(i)("SERVEUR")

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                        ETAT_NOTE = "FERMÉ"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 2 Then
                        ETAT_NOTE = "REGLÉ"
                    End If

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 2 Then
                        GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteAvisualiser.Rows(i)("MONTANT"), "#,##0"), SERVEUR.ToUpper)
                    End If

                    GunaDataGridViewBlocNoteFermee.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteFermee.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End If

            Next

        End If

        If GunaDataGridViewBlocNoteFermee.Rows.Count > 0 Then
            GunaLabel7.Text = GunaDataGridViewBlocNoteFermee.Rows.Count
        Else
            GunaLabel7.Text = 0
        End If

    End Sub


    Public Sub AutoLoadOfBlocNoteAPayer()

        Dim caisse As New Caisse()

        'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes a cloturer et a regler par apport a un caissier et un a la date de travail

        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

        Dim ETAT_BLOC_NOTE As Integer = 3 'NON CLOTURER
        Dim blocNoteAvisualiser As DataTable = caisse.AutoLoadBlocNoteVisualisationClasFastFoods(DateDeSituation, ETAT_BLOC_NOTE)

        GunaDataGridViewBlocNoteFermee.Columns.Clear()

        If blocNoteAvisualiser.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaDataGridViewBlocNoteFermee.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNoteFermee.Columns.Add("MONTANT", "MONTANT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("SERVEUR", "SERVEUR")
            Else
                GunaDataGridViewBlocNoteFermee.Columns.Add("RECEIPT", "RECEIPT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("AMOUNT", "AMOUNT")
                GunaDataGridViewBlocNoteFermee.Columns.Add("SERVER", "SERVER")
            End If

            For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                If GlobalVariable.actualLanguageValue = 0 Then

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                    Dim SERVEUR As String = blocNoteAvisualiser.Rows(i)("SERVER")

                    If blocNoteAvisualiser.Rows(i)("STATE") = 1 Or blocNoteAvisualiser.Rows(i)("STATE") = 3 Then
                        ETAT_NOTE = "CLOSED"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 2 Then
                        ETAT_NOTE = "PAID"
                    End If

                    If GunaComboBoxCommandeStatus.SelectedIndex = 0 Then
                        If blocNoteAvisualiser.Rows(i)("STATE") = 3 Then
                            GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), Format(blocNoteAvisualiser.Rows(i)("AMOUNT"), "#,##0"), SERVEUR.ToUpper)
                        End If
                    End If

                    GunaDataGridViewBlocNoteFermee.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteFermee.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Else

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                    Dim SERVEUR As String = blocNoteAvisualiser.Rows(i)("SERVEUR")

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                        ETAT_NOTE = "FERMÉ"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 2 Then
                        ETAT_NOTE = "REGLÉ"
                    End If

                    If GunaComboBoxCommandeStatus.SelectedIndex = 0 Then
                        If blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                            GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteAvisualiser.Rows(i)("MONTANT"), "#,##0"), SERVEUR.ToUpper)
                        End If
                    End If

                    GunaDataGridViewBlocNoteFermee.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteFermee.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End If

            Next

        End If

        If GunaDataGridViewBlocNoteFermee.Rows.Count > 0 Then
            GunaLabel7.Text = GunaDataGridViewBlocNoteFermee.Rows.Count
        Else
            GunaLabel7.Text = 0
        End If

    End Sub

    Public Sub AutoLoadOfBlocNote_()

        Dim caisse As New Caisse()

        'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes a cloturer et a regler par apport a un caissier et un a la date de travail

        Dim ETAT_BLOC_NOTE As Integer = 0 'NON CLOTURER
        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

        'C- VISUALISATION DE LA LISTE DES BLOC NOTES

        Dim blocNoteAvisualiser As DataTable = caisse.AutoLoadBlocNoteVisualisationClasFastFoods(DateDeSituation, ETAT_BLOC_NOTE)

        ETAT_BLOC_NOTE = 1 'CLOTURE DONC A REGLER
        Dim blocNoteAvisualiser2 As DataTable = caisse.AutoLoadBlocNoteVisualisationClasFastFoods(DateDeSituation, ETAT_BLOC_NOTE)

        ETAT_BLOC_NOTE = 2 'CLOTURE 
        Dim blocNoteAvisualiser3 As DataTable = caisse.AutoLoadBlocNoteVisualisationClasFastFoods(DateDeSituation, ETAT_BLOC_NOTE)

        blocNoteAvisualiser.Merge(blocNoteAvisualiser2)

        GunaDataGridViewBlocNoteOuvert.Columns.Clear()
        GunaDataGridViewBlocNoteFermee.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaDataGridViewBlocNoteFermee.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
            GunaDataGridViewBlocNoteFermee.Columns.Add("MONTANT", "MONTANT")
            GunaDataGridViewBlocNoteFermee.Columns.Add("SERVEUR", "SERVEUR")
        Else
            GunaDataGridViewBlocNoteFermee.Columns.Add("RECEIPT", "RECEIPT")
            GunaDataGridViewBlocNoteFermee.Columns.Add("AMOUNT", "AMOUNT")
            GunaDataGridViewBlocNoteFermee.Columns.Add("SERVER", "SERVER")
        End If

        If blocNoteAvisualiser.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then

                GunaDataGridViewBlocNoteOuvert.Columns.Add("NUMERO", "NUMERO")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("MONTANT", "MONTANT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("ETAT", "ETAT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("SERVEUR", "SERVEUR")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("TEMPS", "TEMPS")

            Else
                GunaDataGridViewBlocNoteOuvert.Columns.Add("RECEIPT NUMBER", "RECEIPT NUMBER")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("AMOUNT", "AMOUNT")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("STATE", "STATE")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("SERVER", "SERVER")
                GunaDataGridViewBlocNoteOuvert.Columns.Add("TIME", "TIME")
            End If

            For i = 0 To blocNoteAvisualiser.Rows.Count - 1

                If GlobalVariable.actualLanguageValue = 0 Then

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                    Dim SERVEUR As String = blocNoteAvisualiser.Rows(i)("SERVER")

                    If blocNoteAvisualiser.Rows(i)("STATE") = 0 Then
                        ETAT_NOTE = "OPENED"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                        ETAT_NOTE = "CLOSED"
                    ElseIf blocNoteAvisualiser.Rows(i)("STATE") = 2 Then
                        ETAT_NOTE = "PAID"
                    End If

                    If blocNoteAvisualiser.Rows(i)("STATE") = 0 Then
                        GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), Format(blocNoteAvisualiser.Rows(i)("AMOUNT"), "#,##0"), ETAT_NOTE, SERVEUR.ToUpper, TEMPS)
                    Else

                        If GunaComboBoxCommandeStatus.SelectedIndex = 0 Then
                            If blocNoteAvisualiser.Rows(i)("STATE") = 1 Then
                                GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser.Rows(i)("RECEIPT NUMBER"), Format(blocNoteAvisualiser.Rows(i)("AMOUNT"), "#,##0"), SERVEUR.ToUpper)
                            End If
                        End If

                    End If

                    GunaDataGridViewBlocNoteOuvert.Columns("AMOUNT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteOuvert.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Else

                    Dim ETAT_NOTE As String = ""
                    Dim TEMPS As String = CDate(blocNoteAvisualiser.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                    Dim SERVEUR As String = blocNoteAvisualiser.Rows(i)("SERVEUR")

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 0 Then
                        ETAT_NOTE = "OUVERT"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                        ETAT_NOTE = "FERMÉ"
                    ElseIf blocNoteAvisualiser.Rows(i)("ETAT") = 2 Then
                        ETAT_NOTE = "REGLÉ"
                    End If

                    If blocNoteAvisualiser.Rows(i)("ETAT") = 0 Then
                        GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteAvisualiser.Rows(i)("MONTANT"), "#,##0"), ETAT_NOTE, SERVEUR.ToUpper, TEMPS)
                    Else

                        If GunaComboBoxCommandeStatus.SelectedIndex = 0 Then
                            If blocNoteAvisualiser.Rows(i)("ETAT") = 1 Then
                                GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteAvisualiser.Rows(i)("MONTANT"), "#,##0"), SERVEUR.ToUpper)
                            End If
                        End If

                    End If

                    GunaDataGridViewBlocNoteOuvert.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
                    GunaDataGridViewBlocNoteOuvert.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End If

            Next

        End If

        For i = 0 To blocNoteAvisualiser3.Rows.Count - 1

            Dim ETAT_NOTE As String = ""
            Dim TEMPS As String = CDate(blocNoteAvisualiser3.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString


            If GlobalVariable.actualLanguageValue = 0 Then

                Dim SERVEUR As String = blocNoteAvisualiser3.Rows(i)("SERVER")

                If blocNoteAvisualiser3.Rows(i)("STATE") = 0 Then
                    ETAT_NOTE = "OPENED"
                ElseIf blocNoteAvisualiser3.Rows(i)("STATE") = 1 Then
                    ETAT_NOTE = "CLOSED"
                ElseIf blocNoteAvisualiser3.Rows(i)("STATE") = 2 Then
                    ETAT_NOTE = "PAID"
                End If

                If GunaComboBoxCommandeStatus.SelectedIndex = 1 Then
                    If blocNoteAvisualiser3.Rows(i)("STATE") = 2 Then
                        GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser3.Rows(i)("RECEIPT NUMBER"), Format(blocNoteAvisualiser3.Rows(i)("AMOUNT"), "#,##0"), SERVEUR.ToUpper)
                    End If
                End If

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                Dim SERVEUR As String = blocNoteAvisualiser3.Rows(i)("SERVEUR")

                If blocNoteAvisualiser3.Rows(i)("ETAT") = 0 Then
                    ETAT_NOTE = "OUVERT"
                ElseIf blocNoteAvisualiser3.Rows(i)("ETAT") = 1 Then
                    ETAT_NOTE = "FERMÉ"
                ElseIf blocNoteAvisualiser3.Rows(i)("ETAT") = 2 Then
                    ETAT_NOTE = "REGLÉ"
                End If

                If GunaComboBoxCommandeStatus.SelectedIndex = 1 Then
                    If blocNoteAvisualiser3.Rows(i)("ETAT") = 2 Then
                        GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteAvisualiser3.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteAvisualiser3.Rows(i)("MONTANT"), "#,##0"), SERVEUR.ToUpper)
                    End If
                End If

            End If

        Next

        If GunaDataGridViewBlocNoteOuvert.Rows.Count > 0 Then
            GunaLabelCommande.Text = GunaDataGridViewBlocNoteOuvert.Rows.Count
        Else
            GunaLabelCommande.Text = 0
        End If

        If GunaDataGridViewBlocNoteFermee.Rows.Count > 0 Then
            GunaLabel7.Text = GunaDataGridViewBlocNoteFermee.Rows.Count
        Else
            GunaLabel7.Text = 0
        End If


    End Sub

    Private Sub TimerOuvert_Tick(sender As Object, e As EventArgs) Handles TimerOuvert.Tick
        AutoLoadOfBlocNoteOuvert()
    End Sub

    Private Sub TimerFermer_Tick(sender As Object, e As EventArgs) Handles TimerFermer.Tick

        If GunaComboBoxCommandeStatus.SelectedIndex = 0 Then
            AutoLoadOfBlocNoteAPayer()
        Else
            AutoLoadOfBlocNotePaid()
        End If

    End Sub

    Private Sub GunaDataGridViewBlocNoteOuvert_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBlocNoteOuvert.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = GunaDataGridViewBlocNoteOuvert.Rows(e.RowIndex)

            Dim NUMERO_BLOC_NOTE As String = Trim(row.Cells(0).Value.ToString)
            'Dim CODE_FACTURE As String = ""
            Dim blocNoteEnCours As DataTable

            blocNoteEnCours = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

            If blocNoteEnCours.Rows.Count > 0 Then

                CODE_FACTURE = blocNoteEnCours.Rows(0)("CODE_FACTURE")
                GunaTextBoxNumBlocNote.Text = blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE")
                GunaTextBoxEtatBlocNote.Text = blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE")

                Dim ListeDesArticlesDeCetteComandes As DataTable = Functions.GetAllElementsOnCondition(blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE"), "ligne_facture_temp", "NUMERO_BLOC_NOTE")

                If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then

                    OutPutLigneFacture(CODE_FACTURE)

                End If

            End If

        End If

    End Sub

    Private Sub GunaButtonAjouterLigne_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click

        GunaLabel5.Text = 0
        GunaLabel6.Text = 0

        If GunaDataGridViewBarRestaurant.Rows.Count > 0 Then

            Dim ETAT_BORDEREAU As Integer = 1
            Dim NOMBRE As Double = 0

            Dim econom As New Economat()
            Dim SORTIE_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            For Each row As DataGridViewRow In GunaDataGridViewBarRestaurant.SelectedRows

                Dim ID_LIGNE_FACTURE As Integer = row.Cells("ID_LIGNE_FACTURE").Value
                Dim article As DataTable = Functions.getElementByCode(ID_LIGNE_FACTURE, "ligne_facture_temp", "ID_LIGNE_FACTURE")
                Dim SORTIE As Integer = 1
                If article.Rows.Count > 0 Then
                    Functions.updateOfFields("ligne_facture_temp", "SORTIE", SORTIE, "ID_LIGNE_FACTURE", ID_LIGNE_FACTURE, 0)
                    Functions.updateOfFields("ligne_facture_temp", "SORTIE_PAR", SORTIE_PAR, "ID_LIGNE_FACTURE", ID_LIGNE_FACTURE, 2)
                End If

            Next

        End If

        Dim table As DataTable = elemenets_de_commande(CODE_FACTURE)
        enAttenteDeLivraison(table)
        nombreDeBoissonOuRepasSorti()

        resumeDesVentesDuJours(GlobalVariable.DateDeTravail)

    End Sub

    Private Sub GunaDataGridViewBlocNoteOuvert_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBlocNoteOuvert.CellDoubleClick

        Dim NOM_CLIENT As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            NOM_CLIENT = "WALK IN"
        Else
            NOM_CLIENT = "COMPTOIR"
        End If

        Dim NUM_FACTURE As String = CODE_FACTURE
        Dim CHAMBRE As String = ""
        Dim BLOC_A_REGLER As String = GunaTextBoxNumBlocNote.Text
        Dim dt As DataGridView = GunaDataGridViewLigneFacture

        If dt.Rows.Count > 0 Then
            Impression.commandeImpression(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE, BLOC_A_REGLER)
        End If

        Me.TopMost = False

    End Sub

    Private Sub GunaDataGridViewBlocNoteFermee_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBlocNoteFermee.CellClick

        If e.RowIndex >= 0 Then

            If GunaDataGridViewBlocNoteFermee.CurrentRow.Selected Then
                Dim row As DataGridViewRow

                row = GunaDataGridViewBlocNoteFermee.Rows(e.RowIndex)

                Dim NUMERO_BLOC_NOTE As String = Trim(row.Cells(0).Value.ToString)
                'Dim CODE_FACTURE As String = ""
                Dim blocNoteEnCours As DataTable

                blocNoteEnCours = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

                If blocNoteEnCours.Rows.Count > 0 Then

                    CODE_FACTURE = blocNoteEnCours.Rows(0)("CODE_FACTURE")
                    GunaTextBoxNumBlocNote.Text = blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE")
                    GunaTextBoxEtatBlocNote.Text = blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE")

                    Dim ListeDesArticlesDeCetteComandes As DataTable = Functions.GetAllElementsOnCondition(blocNoteEnCours.Rows(0)("NUMERO_BLOC_NOTE"), "ligne_facture", "NUMERO_BLOC_NOTE")

                    If ListeDesArticlesDeCetteComandes.Rows.Count > 0 Then
                        OutPutLigneFacture(CODE_FACTURE)
                    End If

                End If

            End If

        End If

    End Sub

    Private Sub GunaDataGridViewBlocNoteFermee_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBlocNoteFermee.CellDoubleClick

        GlobalVariable.blocNoteARegler = GunaTextBoxNumBlocNote.Text

        Dim NUMERO_BLOC_NOTE As String = GunaTextBoxNumBlocNote.Text

        Dim blocNoteEnCours As DataTable

        blocNoteEnCours = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

        If blocNoteEnCours.Rows.Count > 0 Then

            If blocNoteEnCours.Rows(0)("ETAT_BLOC_NOTE") = 3 Then

                GlobalVariable.typeDeClientAFacturer = "comptoir"
                GlobalVariable.codeClientDevantRegler = blocNoteEnCours.Rows(0)("CODE_CLIENT")
                GlobalVariable.blocNoteARegler = NUMERO_BLOC_NOTE

                ReglementForm.Close()
                ReglementForm.Show()
                ReglementForm.TopMost = True

            Else

                Dim NOM_CLIENT As String = ""

                If GlobalVariable.actualLanguageValue = 0 Then
                    NOM_CLIENT = "WALK IN"
                Else
                    NOM_CLIENT = "COMPTOIR"
                End If

                Dim NUM_FACTURE As String = CODE_FACTURE
                Dim CHAMBRE As String = ""
                Dim BLOC_A_REGLER As String = GunaTextBoxNumBlocNote.Text
                Dim dt As DataGridView = GunaDataGridViewLigneFacture

                If dt.Rows.Count > 0 Then
                    Impression.commandeImpression(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE, BLOC_A_REGLER)
                End If

                Me.TopMost = False

            End If

        End If

    End Sub

    Private Sub GunaComboBoxCommandeStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCommandeStatus.SelectedIndexChanged

        If GunaComboBoxCommandeStatus.SelectedIndex = 0 Then
            AutoLoadOfBlocNoteAPayer()
        ElseIf GunaComboBoxCommandeStatus.SelectedIndex = 1 Then
            AutoLoadOfBlocNotePaid()
        End If

    End Sub

    Private Sub LabelSituationCaisse_DoubleClick(sender As Object, e As EventArgs) Handles LabelSituationCaisse.DoubleClick

        GlobalVariable.DocumentToGenerate = "situation caisse"
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Functions.DocumentToPrintSituation(CODE_CAISSIER, "reglement", "CODE_CAISSIER", GlobalVariable.DateDeTravail)
        GlobalVariable.DocumentToGenerate = ""

        Me.TopMost = False

    End Sub

    Private Sub PanelSituationCaisse_DoubleClick(sender As Object, e As EventArgs) Handles PanelSituationCaisse.DoubleClick

        GlobalVariable.DocumentToGenerate = "situation caisse"
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Functions.DocumentToPrintSituation(CODE_CAISSIER, "reglement", "CODE_CAISSIER", GlobalVariable.DateDeTravail)
        GlobalVariable.DocumentToGenerate = ""

        Me.TopMost = False

    End Sub

    Public Sub SituationDeCaisseJournaliere()

        Dim situationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

        Dim TotalFacture As Double = 0

        If situationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To situationDeCaisse.Rows.Count - 1
                TotalFacture += situationDeCaisse.Rows(i)("MONTANT_VERSE")
            Next

            Dim situationDeCaisseCasDeRemboursement As DataTable = Functions.SituationDeCaisseCasDeRemboursement(GlobalVariable.DateDeTravail)

            Dim TotalRembourse As Double = 0
            'On selection l'ensemble des remboursement d'un jour donné
            If situationDeCaisseCasDeRemboursement.Rows.Count > 0 Then

                For j = 0 To situationDeCaisseCasDeRemboursement.Rows.Count - 1
                    TotalRembourse += situationDeCaisseCasDeRemboursement.Rows(j)("MONTANT_HT")
                Next

                'On soustrait les montant remboursé des montants encaissé
                TotalFacture -= TotalRembourse

            End If

            LabelSituationCaisse.Text = Format(TotalFacture, "#,##0")

        Else
            LabelSituationCaisse.Text = 0
        End If

    End Sub

    Public Sub indicateurDEtatDeCaisse()

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 1 Then

            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim caisse As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If caisse.Rows.Count > 0 Then

                If caisse.Rows(0)("ETAT_CAISSE") = 0 Then
                    FermerCaisseToolStripMenuItem.Visible = False
                    OuvrirCaisseToolStripMenuItem.Visible = True
                    PanelSituationCaisse.BackColor = Color.Red
                    GunaButtonAjouterLigne.Enabled = False
                Else
                    FermerCaisseToolStripMenuItem.Visible = True
                    OuvrirCaisseToolStripMenuItem.Visible = False
                    PanelSituationCaisse.BackColor = Color.LightGreen
                    GunaButtonAjouterLigne.Enabled = True
                End If

            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem117_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem117.Click

        'PERMET DE DETERMINER QUELLE FENETRE DOIT ETRE FERMEE AVEC CHANGEMENT DU MOT POUR RECONNECTION AVEC LE NOUVEAU MOT DE PASSE
        GlobalVariable.changerMotDePasseDepuis = "fast_food"

        ChangePasswordForm.Show()
        ChangePasswordForm.TopMost = True

    End Sub

    Private Sub OuvrirCaisseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirCaisseToolStripMenuItem.Click

        Dim gestionStock As Integer = GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK")
        Dim continuer As Boolean = True 'PAR DEFAUT POURSUIVRE POUR GERER LE CAS DE NON ACTIVATION DE LA GESTION DES STOCK

        If continuer Then

            GlobalVariable.fenetreDouvervetureDeCaisse = "fast_food"

            '1- VERIFICATION DE DROIT DE CAISSE
            If Integer.Parse(GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE")) = 1 Then

                '2- VERIFICATION DE CAISSE

                Dim possedeUneCaisse As Boolean = False

                Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                possedeUneCaisse = Functions.detentionDeCaisse(CODE_UTILISATEUR)

                If possedeUneCaisse Then

                    passwordVerifivationForm.Show()
                    passwordVerifivationForm.TopMost = True

                    indicateurDEtatDeCaisse()

                Else

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Vous n'avez pas de caisse", "Gestion Caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("You don't have a cash box", "Cash box management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Vous n'avez pas droit a une caisse", "Gestion Caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("You don't have the right to own a cash box", "Cash box Management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

        End If

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub FermerCaisseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerCaisseToolStripMenuItem.Click

        Dim args As ArgumentType = New ArgumentType()
        Dim dtParentCategory As DataTable

        GlobalVariable.fenetreDouvervetureDeCaisse = "fast_food"
        GlobalVariable.billetageAPartirDe = "fast_food"

        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim caissier As New Caisse()
        Dim nombreDeBlocNoteNonCloturer As Integer = existenceDeBlocNoteOuvert()

        Dim envoiDeRapport As Boolean = False

        '1- ON SE RASSURE QUE TOUS LES BLOCS NOTES SONT CLOTURES

        Dim messageDePasDeVente As String = ""

        If nombreDeBlocNoteNonCloturer = 0 Then

            '2- ON SE RASSURE QUE lA CAISSE EST EQUILIBREE EN COMPARANT LES VENTES COMPTOIRS ET ENCAISSEMENTS

            Dim especes As Double = Functions.SituationDeCaisseEspeces(GlobalVariable.DateDeTravail, CODE_CAISSIER)

            Dim CODE_CAISSE As String = ""
            Dim CODE_UTILISATEUR As String = ""
            Dim CAISSE_UTILISATEUR As DataTable
            Dim ETAT_CAISSE As Integer = 0

            Dim TotalDesVentes As Double = 0
            Dim TotalEncaisse As Double = 0

            Double.TryParse(LabelTotalVenteComptoire.Text, TotalDesVentes)
            Double.TryParse(LabelSituationCaisse.Text, TotalEncaisse)

            'LE CONTROL NE DOIT ETRE FAIT QUE POUR LES PERSONNES DU BAR-RESTAURANT

            GlobalVariable.billetageAPartirDe = "fast_food"

            Dim continuer As Boolean = True

            If continuer Then

                '3- ON DETERMINE SI ON A EFFECTUE DES ENCAISSEMENTS EN ESPECES

                CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                CAISSE_UTILISATEUR = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                If especes = 0 Then

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "No sales to be transfered"
                        languageTitle = "Cash Transfer"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Aucune recette à transférer"
                        languageTitle = "Transfert de Caisse"
                    End If

                    messageDePasDeVente = languageMessage

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                        CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

                        FermerCaisseToolStripMenuItem.Visible = False

                        OuvrirCaisseToolStripMenuItem.Visible = True

                    End If

                    caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                    'A- MISE A JOUR DES ENCAISSEMENTS

                    'MISE AJOURS DE ETAT (REGLEMENT) : POUR NE PLUS PRENDRE EN COMPTE LES REGLEMENTS APRES CLOTURE

                    Dim encaissementDuCaissierActuel As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)

                    Dim ETAT As Integer = 1
                    Dim NUM_REGLEMENT As String = ""
                    Dim reglement As New Reglement()

                    If encaissementDuCaissierActuel.Rows.Count > 0 Then

                        For i = 0 To encaissementDuCaissierActuel.Rows.Count - 1
                            NUM_REGLEMENT = encaissementDuCaissierActuel.Rows(i)("NUM_REGLEMENT")
                            reglement.UpdateEtatReglementPourClientComptoire(NUM_REGLEMENT, ETAT)
                        Next

                    End If

                    '------------------------------------------------------------------------------------------------------------------------------

                    'B- MISE A JOUR DES BLOCS NOTES

                    'MISE AJOURS DE ETAT_FACTURE (LIGNE_BLOC_NOTE) : POUR NE PLUS PRENDRE LES LIGNES DE BLOC NOTES APRES CLOTURE

                    Dim ligneFacture As New LigneFacture()
                    Dim caisseGest As New Caisse()

                    Dim NUMERO_BLOC_NOTE As String = ""

                    Dim ETAT_ = 1  ' BLOC NOTE PLUS PRIS EN COMPTE DANS LES VENTES DU JOURS
                    Dim ETAT_BLOC_NOTE As Integer = 2

                    Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

                    Dim blocNoteDuCaissierActuel As DataTable = caisseGest.BlocNoteDunCaissierQuelconque(DateDeSituation, CODE_CAISSIER)

                    If blocNoteDuCaissierActuel.Rows.Count > 0 Then

                        For i = 0 To blocNoteDuCaissierActuel.Rows.Count - 1

                            If GlobalVariable.actualLanguageValue = 0 Then
                                NUMERO_BLOC_NOTE = blocNoteDuCaissierActuel.Rows(i)("NUMERO_BLOC_NOTE")
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                NUMERO_BLOC_NOTE = blocNoteDuCaissierActuel.Rows(i)("NUMERO_BLOC_NOTE")
                            End If

                            ligneFacture.UpdateEtatLigneFacturePourClientComptoireApreCloture(NUMERO_BLOC_NOTE, ETAT_) 'ligne_facture_bloc_note

                        Next

                    End If

                    'C- MISE A JOURS DES LIGNES FACTURES 

                    Dim ligne_facture As New LigneFacture()

                    Dim UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                    ligne_facture.UpdateEtatLigneFactureLorsDeAucuneRecette(UTILISATEUR, ETAT, DateDeSituation)

                    ligne_facture.UpdateEtatLigneFactureGratuite(UTILISATEUR, ETAT, DateDeSituation)

                    'ON DOIT CLOTURER AUSSI LES VENTES DES EN CHAMBRES EN PLUS DES CLIENTS COMPTOIRS

                    '------------------------------------------------------------------------------------------------------------------------------

                    GlobalVariable.transfertDeCaisseVersCaissiere = False 'PERMET DE CONTROLLER QUE VENDEUR EST D'ACCORDS AVEC LES MONTANTS RENSEIGNEES

                    indicateurDEtatDeCaisse()

                    'ON SE RASSURE QUE TOUS LES ETAT_FACTURE QUI SONT PASSE A ZERO 1 ET N'ETANT PAS ASSOCIE A NUMERO DE FACTURE REPASSE A ZERO
                    CloturerForm.miseAjoursDesLignesDeChargeDeHebergementPasAssocieAUneFacture(GlobalVariable.DateDeTravail)

                    '-----------------------------------------------

                    'CHARGEMENT DU FICHIER DE VENTILATION DU SHIFT APRES CLOTURE DE CAISSE

                    '-----------------------------------------------

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Successfully closed"
                        languageTitle = "Cash Management"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Caisse fermée avec succès !"
                        languageTitle = "Gestion de caisse"
                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    envoiDeRapport = True

                    Dim caisse As New Caisse()

                    If True Then

                        Dim EN_CHAMBRE As Double = 0
                        Dim COMPTOIR As Double = LabelTotalVenteComptoire.Text
                        Dim COMPTE As Double = LabelVenteVersCompte.Text
                        Dim GRATUITEE As Double = 0
                        Dim GRATUITE_EN_CHAMBRE As Double = 0
                        Dim EN_SALLE As Double = 0
                        Dim TOTAL_VENTE As Double = GunaTextBoxTotalDesVentesJournaliere.Text
                        Dim DATE_VENTE As Date = GlobalVariable.DateDeTravail
                        Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                        If CAISSE_UTILISATEUR.Rows.Count > 0 Then
                            CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")
                        End If

                        caisse.resume_vente_journaliere(EN_CHAMBRE, COMPTOIR, COMPTE, GRATUITEE, GRATUITE_EN_CHAMBRE, EN_SALLE, TOTAL_VENTE, DATE_VENTE, CODE_UTILISATEUR, CODE_AGENCE, CODE_CAISSE)

                        GunaTextBoxTotalDesVentesJournaliere.Text = 0
                        LabelSituationCaisse.Text = 0
                        LabelTotalVenteComptoire.Text = 0
                        LabelVenteVersCompte.Text = 0

                        'BackgroundWorker1.RunWorkerAsync()

                        'GESTION DES SHIFTS

                        Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel
                        Dim SHIFT_VALUE As Integer = GlobalVariable.shiftActuel
                        Dim DEBUT_FIN As Integer = 1 'METTRE A JOUR LE STOCK DE FIN

                        Functions.inventaireJournalierTextFile(CODE_MAGASIN, SHIFT_VALUE, DEBUT_FIN)

                        If GlobalVariable.AgenceActuelle.Rows(0)("MESSAGE_WHATSAPP") = 1 Then

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

                            If dtParentCategory.Rows.Count > 0 Then
                                backGroundWorkerToCall(args)
                            End If

                        End If

                    End If

                Else

                    BilletageForm.Close()
                    BilletageForm.Show()
                    BilletageForm.TopMost = True

                End If

            Else

                Dim dialog As DialogResult

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Your balance is negative we have to equilibrate in order to close the shift !!"
                    languageTitle = "Debtor fund"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Le solde de la caisse est débiteur elle sera équilibrée à fin de permettre sa clôture !!"
                    languageTitle = "Caisse Débiteur"
                End If

                dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If dialog = DialogResult.No Then
                    'e.Cancel = True
                Else
                    ComparaisonVenteReglement.Close()
                    ComparaisonVenteReglement.Show()
                    ComparaisonVenteReglement.TopMost = True
                End If

                GlobalVariable.transfertDeCaisseVersCaissiere = False

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Please close all the receipts !!"
                languageTitle = "Receipt Management"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Bien vouloir clôturer tous les blocs notes ouverts !!"
                languageTitle = "Gestion des blocs notes"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub


    Public Function existenceDeBlocNoteOuvert() As Integer

        Dim caisseGest As New Caisse()

        Dim NUMERO_BLOC_NOTE As String = ""

        'On selectionne l'ensemble des reglements du client payés ou pas lié à la réservation
        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
        ' Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim blocNoteDuCaissierActuel As DataTable = caisseGest.FastFoodBlocNoteDunCaissierQuelconque(DateDeSituation)

        Dim nombreDeBlocNoteNonCloturer As Integer = 0

        For i = 0 To blocNoteDuCaissierActuel.Rows.Count - 1

            If GlobalVariable.actualLanguageValue = 0 Then
                If blocNoteDuCaissierActuel.Rows(i)("ETAT_BLOC_NOTE") = 0 Then
                    nombreDeBlocNoteNonCloturer += 1
                End If
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                If blocNoteDuCaissierActuel.Rows(i)("ETAT_BLOC_NOTE") = 0 Then
                    nombreDeBlocNoteNonCloturer += 1
                End If
            End If

        Next

        Return nombreDeBlocNoteNonCloturer

    End Function


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
        End If

    End Sub

    Private Sub GunaTextBox2_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox2.TextChanged

        If Trim(GunaTextBox2.Text).Equals("") Then

            'TimerRefresh.Stop()

            AutoLoadOfBlocNoteOuvert()

        Else

            'TimerRefresh.Start()


            Dim DateDebut As Date = GlobalVariable.DateDeTravail
            Dim DateFin As Date = GlobalVariable.DateDeTravail
            Dim query As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                query = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE, DATE_DE_CONTROLE, CODE_UTILISATEUR, SERVEUR AS SERVER FROM ligne_facture_bloc_note, utilisateurs 
                WHERE NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBox2.Text) & "%' AND ligne_facture_bloc_note.DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND ligne_facture_bloc_note.DATE_CREATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION AND utilisateurs.CODE_UTILISATEUR = ligne_facture_bloc_note.SERVEUR ORDER BY NUMERO_BLOC_NOTE ASC"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                query = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT, DATE_DE_CONTROLE, SERVEUR FROM ligne_facture_bloc_note, utilisateurs 
                WHERE NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBox2.Text) & "%' AND ligne_facture_bloc_note.DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND ligne_facture_bloc_note.DATE_CREATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION AND utilisateurs.CODE_UTILISATEUR = ligne_facture_bloc_note.SERVEUR ORDER BY NUMERO_BLOC_NOTE ASC"
            End If

            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = ""
            command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int16).Value = 0

            Dim adapter As New MySqlDataAdapter(command)
            Dim blocNoteSurUnePeriode As New DataTable()

            adapter.Fill(blocNoteSurUnePeriode)

            Dim ETAT_NOTE As String = ""

            If (blocNoteSurUnePeriode.Rows.Count > 0) Then

                GunaDataGridViewBlocNoteOuvert.Rows.Clear()

                For i = 0 To blocNoteSurUnePeriode.Rows.Count - 1

                    If GlobalVariable.actualLanguageValue = 0 Then

                        Dim TEMPS As String = CDate(blocNoteSurUnePeriode.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                        Dim SERVEUR As String = blocNoteSurUnePeriode.Rows(i)("SERVER")

                        If blocNoteSurUnePeriode.Rows(i)("STATE") = 0 Then
                            ETAT_NOTE = "OPENED"
                        ElseIf blocNoteSurUnePeriode.Rows(i)("STATE") = 1 Then
                            ETAT_NOTE = "CLOSED"
                        ElseIf blocNoteSurUnePeriode.Rows(i)("STATE") = 2 Then
                            ETAT_NOTE = "PAID"
                        End If

                        GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteSurUnePeriode.Rows(i)("RECEIPT NUMBER"), Format(blocNoteSurUnePeriode.Rows(i)("AMOUNT"), "#,##0"), ETAT_NOTE, SERVEUR.ToUpper, TEMPS)

                    ElseIf GlobalVariable.actualLanguageValue = 1 Then

                        Dim TEMPS As String = CDate(blocNoteSurUnePeriode.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                        Dim SERVEUR As String = blocNoteSurUnePeriode.Rows(i)("SERVEUR")

                        If blocNoteSurUnePeriode.Rows(i)("ETAT") = 0 Then
                            ETAT_NOTE = "OUVERT"
                        ElseIf blocNoteSurUnePeriode.Rows(i)("ETAT") = 1 Then
                            ETAT_NOTE = "FERMÉ"
                        ElseIf blocNoteSurUnePeriode.Rows(i)("ETAT") = 2 Then
                            ETAT_NOTE = "REGLÉ"
                        End If

                        GunaDataGridViewBlocNoteOuvert.Rows.Add(blocNoteSurUnePeriode.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteSurUnePeriode.Rows(i)("MONTANT"), "#,##0"), ETAT_NOTE, SERVEUR.ToUpper, TEMPS)

                    End If

                Next

            Else
                GunaDataGridViewBlocNoteOuvert.Rows.Clear()
            End If

        End If

    End Sub

    Private Sub GunaTextBoxCodeClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCodeClient.TextChanged


        If Trim(GunaTextBoxCodeClient.Text).Equals("") Then

            'TimerRefresh.Stop()

            AutoLoadOfBlocNoteAPayer()

        Else

            'TimerRefresh.Start()

            Dim ETAT_BLOC_NOTE As Integer = 0

            If GunaComboBoxCommandeStatus.SelectedIndex = 0 Then
                ETAT_BLOC_NOTE = 1
            ElseIf GunaComboBoxCommandeStatus.SelectedIndex = 1 Then
                ETAT_BLOC_NOTE = 2
            End If

            Dim DateDebut As Date = GlobalVariable.DateDeTravail
            Dim DateFin As Date = GlobalVariable.DateDeTravail
            Dim query As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then

                query = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE, DATE_DE_CONTROLE, CODE_UTILISATEUR, SERVEUR AS SERVER FROM ligne_facture_bloc_note, utilisateurs 
                WHERE NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBoxCodeClient.Text) & "%' or MONTANT_BLOC_NOTE LIKE '%" & Trim(GunaTextBoxCodeClient.Text) & "%' AND ligne_facture_bloc_note.DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND ligne_facture_bloc_note.DATE_CREATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION AND utilisateurs.CODE_UTILISATEUR = ligne_facture_bloc_note.SERVEUR ORDER BY NUMERO_BLOC_NOTE ASC"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                query = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT, DATE_DE_CONTROLE, SERVEUR FROM ligne_facture_bloc_note, utilisateurs 
                WHERE NUMERO_BLOC_NOTE LIKE '%" & Trim(GunaTextBoxCodeClient.Text) & "%' AND ligne_facture_bloc_note.DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND ligne_facture_bloc_note.DATE_CREATION <= '" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION AND utilisateurs.CODE_UTILISATEUR = ligne_facture_bloc_note.SERVEUR ORDER BY NUMERO_BLOC_NOTE ASC"
            End If

            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = ""
            command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int16).Value = ETAT_BLOC_NOTE

            Dim adapter As New MySqlDataAdapter(command)
            Dim blocNoteSurUnePeriode As New DataTable()

            adapter.Fill(blocNoteSurUnePeriode)

            Dim ETAT_NOTE As String = ""

            If (blocNoteSurUnePeriode.Rows.Count > 0) Then

                GunaDataGridViewBlocNoteFermee.Rows.Clear()

                For i = 0 To blocNoteSurUnePeriode.Rows.Count - 1

                    If GlobalVariable.actualLanguageValue = 0 Then

                        Dim TEMPS As String = CDate(blocNoteSurUnePeriode.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                        Dim SERVEUR As String = blocNoteSurUnePeriode.Rows(i)("SERVER")

                        If blocNoteSurUnePeriode.Rows(i)("STATE") = 0 Then
                            ETAT_NOTE = "OPNED"
                        ElseIf blocNoteSurUnePeriode.Rows(i)("STATE") = 1 Then
                            ETAT_NOTE = "CLOSED"
                        ElseIf blocNoteSurUnePeriode.Rows(i)("STATE") = 2 Then
                            ETAT_NOTE = "PAID"
                        End If

                        GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteSurUnePeriode.Rows(i)("RECEIPT NUMBER"), Format(blocNoteSurUnePeriode.Rows(i)("AMOUNT"), "#,##0"), SERVEUR.ToUpper)
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then

                        Dim TEMPS As String = CDate(blocNoteSurUnePeriode.Rows(i)("DATE_DE_CONTROLE")).ToLongTimeString
                        Dim SERVEUR As String = blocNoteSurUnePeriode.Rows(i)("SERVEUR")

                        If blocNoteSurUnePeriode.Rows(i)("ETAT") = 0 Then
                            ETAT_NOTE = "OUVERT"
                        ElseIf blocNoteSurUnePeriode.Rows(i)("ETAT") = 1 Then
                            ETAT_NOTE = "FERMÉ"
                        ElseIf blocNoteSurUnePeriode.Rows(i)("ETAT") = 2 Then
                            ETAT_NOTE = "REGLÉ"
                        End If

                        GunaDataGridViewBlocNoteFermee.Rows.Add(blocNoteSurUnePeriode.Rows(i)("NUMERO BLOC NOTE"), Format(blocNoteSurUnePeriode.Rows(i)("MONTANT"), "#,##0"), SERVEUR.ToUpper)

                    End If

                Next

            Else
                GunaDataGridViewBlocNoteFermee.Rows.Clear()
            End If

        End If

    End Sub


    Public Sub resumeDesVentesDuJours(ByVal DateDeSituation As Date)

        Dim MontantTotalDesVenteDuComptoire As Double = 0
        Dim MontantTotalDesVenteDesEnChambres As Double = 0
        Dim MontantTotalDesVente As Double = 0
        Dim MontantTotalDesVenteDesVersCompte As Double = 0
        Dim MontantTotalDesVenteDesGratuite As Double = 0
        Dim MontantTotalDesVenteDesGratuiteEnChambre As Double = 0
        Dim MontantTotalDesVenteEvenement As Double = 0

        Dim ETAT As Integer = 0 ' ON CHOISI LES LIGNES A ZERO AINSI UNE FOIS LA CAISSER FERME CELLE-CI N'APPARAITRONS PLUS

        Dim caissier As New Caisse()

        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        'BlocNoteDunCaissierQuelconque = > PRENANT EN COMPTE L'ETAT = 0 -> DONC FACTURE DONC L'EQUILIBRE N'A PAS ETE EFFECTUE: NON EQUILIBRE

        Dim totalDesBlocNotesEnCours As DataTable = caissier.FastFoodBlocNoteDunCaissierQuelconque(DateDeSituation)
        Dim ligne_facture As DataTable
        Dim count As Boolean = False

        Dim SORTIE_PAR As String = ""
        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR").ToString.ToUpper
        Dim totalJour As Double = 0

        If totalDesBlocNotesEnCours.Rows.Count > 0 Then

            Dim NUMERO_BLOC_NOTE As String = ""

            For k = 0 To totalDesBlocNotesEnCours.Rows.Count - 1

                count = False
                NUMERO_BLOC_NOTE = totalDesBlocNotesEnCours.Rows(k)("NUMERO_BLOC_NOTE")

                ligne_facture = caissier.FastFoodLigneDunCaissierQuelconque(DateDeSituation, NUMERO_BLOC_NOTE)

                For j = 0 To ligne_facture.Rows.Count - 1

                    SORTIE_PAR = ligne_facture.Rows(j)("SORTIE_PAR").ToString.ToUpper

                    If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("BAR_FAST_FOOD") = 1 Or GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("RESTAURANT_FAST_FOOD") = 1 Then

                        If Trim(ligne_facture.Rows(j)("TYPE_LIGNE_FACTURE")).Equals("BAR") Then
                            count = True
                        ElseIf Trim(ligne_facture.Rows(j)("TYPE_LIGNE_FACTURE")).Equals("RESTAURANT") Then
                            count = True
                        End If

                    End If

                    If count Then

                        If CODE_UTILISATEUR.Equals(SORTIE_PAR) Then

                            If totalDesBlocNotesEnCours.Rows(k)("ETAT_FACTURE") = 0 Then ' COMPTOIR
                                MontantTotalDesVenteDuComptoire += ligne_facture.Rows(j)("MONTANT_TTC")
                            ElseIf totalDesBlocNotesEnCours.Rows(k)("ETAT_FACTURE") = 2 Then 'GRATUITEE
                                MontantTotalDesVenteDesGratuite += ligne_facture.Rows(j)("MONTANT_TTC")
                            ElseIf totalDesBlocNotesEnCours.Rows(k)("ETAT_FACTURE") = 3 Then 'COMPTE DEBITEUR
                                MontantTotalDesVenteDesVersCompte += ligne_facture.Rows(j)("MONTANT_TTC")
                            ElseIf totalDesBlocNotesEnCours.Rows(k)("ETAT_FACTURE") = 1 Then 'VENTE EN CHAMBRE
                                MontantTotalDesVenteDesEnChambres += ligne_facture.Rows(j)("MONTANT_TTC")
                            End If

                        End If

                        totalJour += ligne_facture.Rows(j)("MONTANT_TTC")

                    End If

                Next

            Next

        Else
            'GunaAdvenceButtonAppro.Text = DateDeSituation & " - " & CODE_CAISSIER
        End If

        LabelTotalVenteComptoire.Text = Format(MontantTotalDesVenteDuComptoire, "#,##0")
        LabelVenteTotalJour.Text = Format(totalJour, "#,##0")

        LabelVenteVersCompte.Text = Format(MontantTotalDesVenteDesVersCompte, "#,##0")

        Dim type_salle_chambre As String = "salle"

        MontantTotalDesVente = MontantTotalDesVenteDuComptoire + MontantTotalDesVenteDesEnChambres + MontantTotalDesVenteDesVersCompte + MontantTotalDesVenteDesGratuite + MontantTotalDesVenteEvenement
        GunaTextBoxTotalDesVentesJournaliere.Text = Format(MontantTotalDesVente, "#,##0")

        '--------------------------------------------------------------------------------------------------------
        Dim getUserQuery01 = "SELECT * FROM ligne_facture_gratuite, reserve_conf WHERE CODE_UTILISATEUR_CREA = @CODE_CAISSIER AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT AND ligne_facture_gratuite.CODE_RESERVATION =  reserve_conf.CODE_RESERVATION ORDER BY DATE_FACTURE DESC"

        Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

        command01.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        command01.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT
        Dim adapter01 As New MySqlDataAdapter

        Dim dt01 As New DataTable()

        adapter01.SelectCommand = command01
        adapter01.Fill(dt01)

        If dt01.Rows.Count > 0 Then

            For j = 0 To dt01.Rows.Count - 1
                If Not Trim(dt01.Rows(j)("CODE_RESERVATION")) = "-" Then
                    MontantTotalDesVenteDesGratuiteEnChambre += dt01.Rows(j)("MONTANT_TTC")
                End If
            Next

        End If

    End Sub

    Public Sub GestionOuvertureDeCaisse()

        Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

        Dim CODE_CAISSE As String = ""

        Dim message As String = ""

        'Droit d'acces a la caisse 
        If Integer.Parse(GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE")) = 1 Then

            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

                OuvrirCaisseToolStripMenuItem.Visible = False

                FermerCaisseToolStripMenuItem.Visible = True

                Dim ETAT_CAISSE As Integer = 1
                Dim caissier As New Caisse()

                caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

                If GlobalVariable.actualLanguageValue = 0 Then
                    message = "Successfully opened"
                    languageTitle = "Funds Management"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    message = "Caisse ouverte avec succès"
                    languageTitle = "Gestion de caisse"
                End If
                '-----------------------------------------------

                'CHARGEMENT DU FICHIER DE VENTILATION DU SHIFT AVANT CLOTURE DE CAISSE


                '-----------------------------------------------

            Else
                If GlobalVariable.actualLanguageValue = 0 Then
                    message = "You don't manage cash"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    message = "Vous n'avez pas de caisse"
                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                message = "You don't have the right to own a box"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                message = "Vous n'avez pas droit à la caisse"
            End If

        End If

        If GlobalVariable.actualLanguageValue = 0 Then
            languageTitle = "Funds Management"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageTitle = "Gestion de caisse"
        End If

        MessageBox.Show(message, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub GunaDataGridViewBarRestaurantSortie_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBarRestaurantSortie.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim NOM_CLIENT As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                NOM_CLIENT = "WALK IN"
            Else
                NOM_CLIENT = "COMPTOIR"
            End If

            Dim NUM_FACTURE As String = CODE_FACTURE
            Dim CHAMBRE As String = ""
            Dim BLOC_A_REGLER As String = GunaTextBoxNumBlocNote.Text
            Dim dt As DataGridView = GunaDataGridViewBarRestaurantSortie

            If dt.Rows.Count > 0 Then
                Impression.commandeImpressionFastFood(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE, BLOC_A_REGLER)
            End If

            Me.TopMost = False

        End If

    End Sub

    Private Sub GunaDataGridViewBarRestaurant_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewBarRestaurant.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim NOM_CLIENT As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                NOM_CLIENT = "WALK IN"
            Else
                NOM_CLIENT = "COMPTOIR"
            End If

            Dim NUM_FACTURE As String = CODE_FACTURE
            Dim CHAMBRE As String = ""
            Dim BLOC_A_REGLER As String = GunaTextBoxNumBlocNote.Text
            Dim dt As DataGridView = GunaDataGridViewBarRestaurant

            If dt.Rows.Count > 0 Then
                Impression.commandeImpressionFastFood(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE, BLOC_A_REGLER)
            End If

            Me.TopMost = False

        End If

    End Sub

    Private Sub LabelVenteTotalJour_DoubleClick(sender As Object, e As EventArgs) Handles LabelVenteTotalJour.DoubleClick

        GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT"

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim titre As String = "BAR - RESTAURANT"
        Dim ETAT_FACTURE As Integer = 0

        Dim ligneFacture As New LigneFacture()
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim dtParentCategory As DataTable = ligneFacture.ListeDesCategoriesDArticleVendusParRubriqueFastFood(DateDebut, DateFin, ETAT_FACTURE, CODE_CAISSIER)

        Impression.inventaireDesVentesFastFood(DateDebut, DateFin, CODE_CAISSIER, titre)

        Me.TopMost = False

    End Sub

    Private Sub Panel4_DoubleClick(sender As Object, e As EventArgs) Handles Panel4.DoubleClick
        journalDesVentesDuShiftImprimer()
    End Sub

    Private Sub journalDesVentesDuShiftImprimer()

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT"
        Dim ligneFacture As New LigneFacture()
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim dtParentCategory As DataTable = ligneFacture.ListeDesCategoriesDArticleVendus(DateDebut, DateFin, CODE_CAISSIER)

        Impression.journalDesVentes(dtParentCategory, DateDebut, DateFin)

    End Sub

    Private Sub LabelTotalVenteComptoire_DoubleClick(sender As Object, e As EventArgs) Handles LabelTotalVenteComptoire.DoubleClick
        inventaireDesVentes()
    End Sub

    Private Sub Panel3_DoubleClick(sender As Object, e As EventArgs) Handles Panel3.DoubleClick
        inventaireDesVentes()
    End Sub

    Private Sub GunaTextBoxTotalDesVentesJournaliere_Click(sender As Object, e As EventArgs) Handles GunaTextBoxTotalDesVentesJournaliere.Click
        inventaireDesVentes()
    End Sub

    Public Sub journalDesVentesDuBarOuRestaurant()

        GlobalVariable.DocumentToGenerate = "JOURNAL DES VENTES SHIFT"

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim titre As String = ""
        Dim ETAT_FACTURE As Integer = 0

        Dim label As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("BAR_FAST_FOOD") = 1 Then
            label = "BAR"
        ElseIf GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("RESTAURANT_FAST_FOOD") = 1 Then
            label = "RESTAURANT"
        End If

        If GlobalVariable.actualLanguageValue = 1 Then

            If ETAT_FACTURE = 0 Then
                titre = "JOURNAL DES VENTES DU " & label
            ElseIf ETAT_FACTURE = 3 Then
                titre = "JOURNAL DES VENTES TRANSFERES VERS COMPTES"
            End If

        Else

            If ETAT_FACTURE = 0 Then
                titre = label & " SALES"
            ElseIf ETAT_FACTURE = 3 Then
                titre = "SALES TRANSFERED TO DEBTOR ACCOUNTS"
            End If

        End If

        Dim ligneFacture As New LigneFacture()
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim dtParentCategory As DataTable = ligneFacture.ListeDesCategoriesDArticleVendusParRubriqueFastFood(DateDebut, DateFin, ETAT_FACTURE, CODE_CAISSIER)

        Impression.journalDesVentesDuShiftParRubriqueFastFood(dtParentCategory, DateDebut, DateFin, titre, ETAT_FACTURE)

        Me.TopMost = False

    End Sub

    Public Sub inventaireDesVentes()

        GlobalVariable.DocumentToGenerate = "INVENTAIRE DES VENTES"

        Dim DateDebut As Date = GlobalVariable.DateDeTravail
        Dim DateFin As Date = GlobalVariable.DateDeTravail
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim LIBELLE As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("BAR_FAST_FOOD") = 1 Then
            LIBELLE = "BAR"
        ElseIf GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("RESTAURANT_FAST_FOOD") = 1 Then
            LIBELLE = "RESTAURANT"
        End If

        If GlobalVariable.actualLanguageValue = 1 Then
            LIBELLE = "JOURNAL DES VENTES DU " & LIBELLE & " "
        Else
            LIBELLE = LIBELLE & " SALES "
        End If

        Dim ventes As New LigneFacture()

        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim ListeDesVentes As New DataTable()

        ListeDesVentes = ventes.ListeDesArticlesVendusInventaireFastFood(DateDebut, DateFin, CODE_UTILISATEUR)

        If ListeDesVentes.Rows.Count > 0 Then

            DataGridViewRapports.Columns.Clear()
            DataGridViewRapports.Rows.Clear()

            DataGridViewRapports.Columns.Add("ARTICLE", "ARTICLE")
            DataGridViewRapports.Columns.Add("QUANTITE", "QTE VENDU")
            DataGridViewRapports.Columns.Add("STOCK", "STOCK ACTUEL")
            DataGridViewRapports.Columns.Add("PU", "PRIX UNITAIRE")
            DataGridViewRapports.Columns.Add("PA", "PRIX ACHAT")
            DataGridViewRapports.Columns.Add("MONTANT", "MONTANT TOTAL")
            DataGridViewRapports.Columns.Add("MARGE", "MARGE")

            Dim articleIndividuel As New DataTable()

            For i = 0 To ListeDesVentes.Rows.Count - 1

                Dim CODE_ARTICLE As String = ListeDesVentes.Rows(i)("CODE_ARTICLE")
                'Dim LIBELLE_FACTURE As String = ListeDesVentes.Rows(i)("LIBELLE_FACTURE")

                Dim LIBELLE_FACTURE As String = ""
                Dim FAMILLE As String = ""
                Dim SUIVIE As String = ""

                Dim PA As Double = 0
                Dim STOCK As Double = 0

                Dim infoArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                If infoArticle.Rows.Count > 0 Then

                    LIBELLE_FACTURE = infoArticle.Rows(0)("DESIGNATION_FR")
                    PA = infoArticle.Rows(0)("COUT_U_MOYEN_PONDERE")

                    SUIVIE = infoArticle.Rows(0)("METHODE_SUIVI_STOCK")

                    'If Trim(SUIVIE).Equals("Suivi simple") Then
                    STOCK = infoArticle.Rows(0)("QUANTITE")
                    'Else

                    'End If

                End If

                Dim PRIXMOYENUNITAIRE As Double = 0
                Dim QUANTITE As Double = 0
                Dim MONTANT As Double = 0

                Dim UNITE_DE_VENTE As String = ""

                articleIndividuel = ventes.ListeDesArticlesVendusInventaireIndividuelFastFood(DateDebut, DateFin, CODE_UTILISATEUR, CODE_ARTICLE)

                '------------------------------ NEW 18.08.2023 ------------------------------------------------

                Dim QUANITE_CORRECTE_FORMAT = Functions.affichageQteDansUnFormatCorrect(CODE_ARTICLE, QUANTITE)

                '----------------------------------------------------------------------------------------------

                For j = 0 To articleIndividuel.Rows.Count - 1

                    UNITE_DE_VENTE = articleIndividuel.Rows(j)("CODE_LOT")

                    QUANTITE += articleIndividuel.Rows(j)("QUANTITE")
                    MONTANT += articleIndividuel.Rows(j)("MONTANT TOTAL")

                    If QUANTITE > 0 Then
                        PRIXMOYENUNITAIRE = MONTANT / QUANTITE
                    End If

                    QUANITE_CORRECTE_FORMAT += Functions.conversionEnPlusPetiteUnite(CODE_ARTICLE, articleIndividuel.Rows(j)("QUANTITE"), UNITE_DE_VENTE)

                Next

                Dim MARGE As Double = MONTANT - (QUANTITE * PA)

                'DataGridViewRapports.Rows.Add(LIBELLE_FACTURE, QUANTITE, STOCK, PRIXMOYENUNITAIRE, PA, MONTANT, MARGE)

                QUANITE_CORRECTE_FORMAT = Functions.affichageQteDansUnFormatCorrect(CODE_ARTICLE, QUANITE_CORRECTE_FORMAT)
                Dim STOCK_CORRECTE_FORMAT = Functions.affichageQteDansUnFormatCorrect(CODE_ARTICLE, STOCK)

                If Not Trim(LIBELLE_FACTURE).Equals("LIBELLE_FACTURE") Then
                    DataGridViewRapports.Rows.Add(LIBELLE_FACTURE, QUANITE_CORRECTE_FORMAT, STOCK_CORRECTE_FORMAT, PRIXMOYENUNITAIRE, PA, MONTANT, MARGE)
                End If

            Next

            DataGridViewRapports.Columns("MONTANT").DefaultCellStyle.Format = "#,##0"
            DataGridViewRapports.Columns("MONTANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewRapports.Columns("PU").DefaultCellStyle.Format = "#,##0"
            DataGridViewRapports.Columns("PU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewRapports.Columns("STOCK").DefaultCellStyle.Format = "#,##0.00"
            DataGridViewRapports.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridViewRapports.Columns("PA").DefaultCellStyle.Format = "#,##0"
            DataGridViewRapports.Columns("PA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewRapports.Columns("MARGE").DefaultCellStyle.Format = "#,##0"
            DataGridViewRapports.Columns("MARGE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewRapports.Columns("QUANTITE").DefaultCellStyle.Format = "#,##0.00"
            DataGridViewRapports.Columns("QUANTITE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End If

        Impression.inventaireDesVentes(DataGridViewRapports, DateDebut, DateFin, CODE_CAISSIER, LIBELLE)

        Me.TopMost = False

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        TimerOuvert.Stop()
        AutoLoadOfBlocNoteOuvert()
        TimerOuvert.Start()
    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click

        GlobalVariable.blocNoteARegler = GunaTextBoxNumBlocNote.Text

        Dim NUMERO_BLOC_NOTE As String = GunaTextBoxNumBlocNote.Text

        Dim blocNoteEnCours As DataTable

        blocNoteEnCours = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

        If blocNoteEnCours.Rows.Count > 0 Then

            Dim NOM_CLIENT As String = ""

            If GlobalVariable.actualLanguageValue = 0 Then
                NOM_CLIENT = "WALK IN"
            Else
                NOM_CLIENT = "COMPTOIR"
            End If

            Dim NUM_FACTURE As String = CODE_FACTURE
            Dim CHAMBRE As String = ""
            Dim BLOC_A_REGLER As String = GunaTextBoxNumBlocNote.Text
            Dim dt As DataGridView = GunaDataGridViewLigneFacture

            If dt.Rows.Count > 0 Then
                Impression.commandeImpression(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE, BLOC_A_REGLER)
            End If

            Me.TopMost = False

        End If

    End Sub

    Private Sub ToolStripMenuItem119_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem119.Click

        Dim dialog As DialogResult

        Dim Action As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "Do you really wan to close"
            languageTitle = "Close BarclesHSoft"
            Action = "DECONNECTION OF " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Voulez-vous vraiment fermer"
            languageTitle = "Fermer BarclesHSoft"
            Action = "DECONNEXION DE " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")
        End If

        dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.Yes Then

            Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

            Dim CODE_CAISSE As String = ""

            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

            End If

            Dim ETAT_CAISSE As Integer = 0
            Dim caissier As New Caisse()

            User.mouchard(Action)

            HomeForm.Close()

            AccueilForm.Close()

            AccueilForm.Show()

            Me.Close()

        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim blocNoteEnCours As DataTable

        If GunaDataGridViewBlocNoteOuvert.CurrentRow.Selected Then

            Dim row As DataGridViewRow = GunaDataGridViewBlocNoteOuvert.CurrentRow
            Dim NUMERO_BLOC_NOTE As String = Trim(row.Cells(0).Value.ToString)

            blocNoteEnCours = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")

            If blocNoteEnCours.Rows.Count > 0 Then

                Dim NOM_CLIENT As String = ""

                If GlobalVariable.actualLanguageValue = 0 Then
                    NOM_CLIENT = "WALK IN"
                Else
                    NOM_CLIENT = "COMPTOIR"
                End If

                Dim NUM_FACTURE As String = CODE_FACTURE
                Dim CHAMBRE As String = ""
                Dim BLOC_A_REGLER As String = GunaTextBoxNumBlocNote.Text
                Dim dt As DataGridView = GunaDataGridViewLigneFacture

                If dt.Rows.Count > 0 Then
                    Impression.commandeImpression(dt, NOM_CLIENT, NUM_FACTURE, CHAMBRE, BLOC_A_REGLER)
                End If

                Me.TopMost = False

            End If

        End If

    End Sub

    Private Sub ClôturerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClôturerToolStripMenuItem1.Click

        If GunaDataGridViewBlocNoteOuvert.CurrentRow.Selected Then

            Dim row As DataGridViewRow
            row = GunaDataGridViewBlocNoteOuvert.CurrentRow

            Dim NUMERO_BLOC_NOTE As String = Trim(row.Cells(0).Value.ToString)
            Dim ETAT_BLOC_NOTE As Integer = 0

            regulationBlocNote(ETAT_BLOC_NOTE, NUMERO_BLOC_NOTE)

        End If

    End Sub

End Class