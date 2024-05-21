Imports MySql.Data.MySqlClient

Public Class PanierForm

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.Close()
    End Sub

    Private Sub PanierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CODE_ARTICLE As String = GunaTextBoxCodeArticle.Text

        Dim article As DataTable = Functions.GetAllElementsOnCondition(CODE_ARTICLE, "article", "CODE_ARTICLE")

        If article.Rows.Count > 0 Then

            GunaLabelPu.Text = Format(article.Rows(0)("PRIX_VENTE_HT"), "#,##0")

            Dim Qte As Integer = GunaNumericQte.Value
            Dim Pu As Double = article.Rows(0)("PRIX_VENTE_HT")

            Dim total As Double = Qte * Pu

            GunaLabelPrixTotal.Text = Format(total, "#,##0")

        End If

        OutPutLigneFacture()

    End Sub

    Private Sub GunaNumeric1_ValueChanged(sender As Object, e As EventArgs) Handles GunaNumericQte.ValueChanged

        Dim CODE_ARTICLE As String = GunaTextBoxCodeArticle.Text

        Dim article As DataTable = Functions.GetAllElementsOnCondition(CODE_ARTICLE, "article", "CODE_ARTICLE")

        If article.Rows.Count > 0 Then

            GunaLabelPu.Text = Format(article.Rows(0)("PRIX_VENTE_HT"), "#,##0")

            Dim Qte As Integer = GunaNumericQte.Value
            Dim Pu As Double = article.Rows(0)("PRIX_VENTE_HT")

            Dim total As Double = Qte * Pu

            GunaLabelPrixTotal.Text = Format(total, "#,##0")

        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        Dim ligne_facture As New LigneFacture()
        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim nombreDeBlocNote As Integer = 1

        Dim allBlocNote As DataTable = Functions.allTableFields("ligne_facture_bloc_note")

        If allBlocNote.Rows.Count > 0 Then
            nombreDeBlocNote = allBlocNote.Rows.Count
        End If

        Dim sequensageDesBlocNotes As String = ""

        If nombreDeBlocNote < 10 Then
            sequensageDesBlocNotes = "00" & nombreDeBlocNote

        ElseIf nombreDeBlocNote < 100 Then
            sequensageDesBlocNotes = "0" & nombreDeBlocNote
        Else
            sequensageDesBlocNotes = "" & nombreDeBlocNote
        End If

        Dim NUMERO_BLOC_NOTE_VERIF As String = sequensageDesBlocNotes
        Dim NUMERO_BLOC_NOTE As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR") & GlobalVariable.DateDeTravail.ToString("ddMM") & "-" & sequensageDesBlocNotes

        Dim infoSupClient As DataTable = Functions.getElementByCode("CLIENT COMPTOIR", "client", "NOM_CLIENT")

        Dim CODE_CLIENT As String = ""

        If infoSupClient.Rows.Count > 0 Then
            CODE_CLIENT = infoSupClient.Rows(0)("CODE_CLIENT")
        End If

        Dim CODE_FACTURE As String = GunaTextBoxCodeFacture.Text

        ligne_facture.InsertLigneBlocNoteCommande(NUMERO_BLOC_NOTE, GunaTextBoxCodeFacture.Text, CODE_CLIENT, DATE_CREATION, CODE_CAISSIER, NUMERO_BLOC_NOTE_VERIF)

        Dim ETAT As Integer = 0
        Dim MONTANT_BLOC_NOTE As Double = 0

        For i = 0 To GunaDataGridViewLigneFacture.Rows.Count - 1

            MONTANT_BLOC_NOTE += GunaDataGridViewLigneFacture.Rows(i).Cells("MONTANT TTC").Value

            Dim updateQuery As String = "UPDATE `ligne_facture_temp` SET `NUMERO_BLOC_NOTE` = @NUMERO_BLOC_NOTE, CODE_FACTURE=@CODE_FACTURE WHERE ID_LIGNE_FACTURE = @ID_LIGNE_FACTURE"

            Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)

            commandupdateQuery.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = GunaDataGridViewLigneFacture.Rows(i).Cells("ID_LIGNE_FACTURE").Value
            commandupdateQuery.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE
            commandupdateQuery.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE

            commandupdateQuery.ExecuteNonQuery()

        Next

        Functions.updateOfFields("ligne_facture_bloc_note", "MONTANT_BLOC_NOTE", MONTANT_BLOC_NOTE, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 1)

        Functions.updateOfFields("ligne_facture_bloc_note", "ETAT", ETAT, "NUMERO_BLOC_NOTE", NUMERO_BLOC_NOTE, 0)

        'updateBlocNoteCommandeClient(NUMERO_BLOC_NOTE, ETAT, MONTANT)

        CustomCommandForm.Label3.Text = "(" & 0 & ")"

        CustomCommandForm.GunaTextBoxCodeFacture.Text = Functions.GeneratingRandomCodeWithSpecifications("ligne_facture_bloc_note", "CL")
        GunaTextBoxCodeFacture.Text = CustomCommandForm.GunaTextBoxCodeFacture.Text

        Dim languageMessage As String = ""
        Dim languageTitle As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = ""
            languageTitle = ""
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Commande enregistrée avec succès "
            languageTitle = "Prise de commande"
        End If

        GunaDataGridViewLigneFacture.Columns.Clear()

        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        CustomCommandForm.keyInformation()

        Me.Close()

    End Sub

    Dim nombreArticle As Integer = 0

    Private Sub GunaButtonAjouterAuPanier_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterAuPanier.Click

        Me.Cursor = Cursors.WaitCursor

        Dim proceder As Boolean = False

        Dim CODE_ARTICLE As String = GunaTextBoxCodeArticle.Text

        'proceder = BarRestaurantForm.gestionDesStocks(CODE_ARTICLE)

        ' If proceder Then
        If True Then

            Dim LIBELLE_FACTURE = ""
            Dim FUSIONNEE As String = ""
            Dim TYPE_LIGNE_FACTURE As String = ""

            Dim infoSupArticle As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

            If infoSupArticle.Rows.Count > 0 Then
                LIBELLE_FACTURE = infoSupArticle.Rows(0)("DESIGNATION_FR")
                FUSIONNEE = infoSupArticle.Rows(0)("CODE_SOUS_FAMILLE")
                TYPE_LIGNE_FACTURE = infoSupArticle.Rows(0)("TYPE_ARTICLE")
            End If

            'MessageBox.Show(GlobalVariable.DateDeTravail)

            Dim DateDeSituation As Date = GlobalVariable.DateDeTravail.ToShortDateString

            Dim CODE_FACTURE As String = GunaTextBoxCodeFacture.Text
            Dim CODE_RESERVATION As String = ""
            Dim CODE_MOUVEMENT As String = ""
            Dim CODE_CHAMBRE As String = ""
            Dim CODE_MODE_PAIEMENT As String = ""
            Dim NUMERO_PIECE As String = ""
            Dim CODE_LOT As String = ""
            Dim MONTANT_HT = GunaLabelPrixTotal.Text
            Dim TAXE = 0
            Dim QUANTITE As Double = GunaNumericQte.Value
            Dim PRIX_UNITAIRE_TTC = GunaLabelPu.Text
            Dim MONTANT_TTC = GunaLabelPrixTotal.Text
            Dim DATE_FACTURE = DateDeSituation
            Dim HEURE_FACTURE = Now().ToLongTimeString
            Dim ETAT_FACTURE = 0
            Dim DATE_OCCUPATION = DateDeSituation
            Dim HEURE_OCCUPATION = Now().ToLongTimeString
            Dim NUMERO_SERIE As String = ""
            Dim NUMERO_ORDRE = 0
            Dim DESCRIPTION As String = ""
            Dim CODE_UTILISATEUR_CREA As String = ""
            Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            Dim MONTANT_REMISE As Double = 0
            Dim MONTANT_TAXE As Double = 0
            Dim NUMERO_SERIE_DEBUT As String = ""
            Dim NUMERO_SERIE_FIN As String = ""
            Dim CODE_MAGASIN As String = GlobalVariable.magasinActuel

            Dim TYPPE_ As String = "comptoir"
            Dim TABLE_LIGNE As String = "ligne_facture_temp"
            Dim NUMERO_BLOC_NOTE As String = ""
            Dim GRIFFE_UTILISATEUR = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")
            Dim VALEUR_CONSO As Double = 0

            Dim ligne_facture As New LigneFacture

            If ligne_facture.insertLigneFactureTemp(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPPE_, TABLE_LIGNE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO) Then
                'FUSIONNEE : UTILISE COMME SOUS FAMILLE DE L'ARTICLE
            End If

            GunaComboBoxUniteOuConso.Visible = False

            OutPutLigneFacture()

            Me.Close()

        End If

        'After adding a line we clear the article field
        clearArticleFields()

        'SI L'ON EST ENTRAINE D'AJOUTER DANS LE CADRE D'UNE MODIFICATION

        CustomCommandForm.keyInformation()

        Me.Cursor = Cursors.Default

    End Sub


    Public Sub clearArticleFields()

        GunaNumericQte.Value = 1
        GunaLabelPu.Text = 0
        GunaLabelPrixTotal.Text = 0
        GunaTextBoxCodeArticle.Clear()

    End Sub

    Public Sub OutPutLigneFacture()

        Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

        Dim query As String = ""

        'POUR LES EVENEMENTS SUIVANTS CODE_DE_RESERVATION
        'POUR LES AUTRES SUIVANTS EN CHAMBRE ET COMPTOIR CODE_FACTURE

        If GlobalVariable.actualLanguageValue = 0 Then

            query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'ITEM',PRIX_UNITAIRE_TTC As 'UNIT PRICE', 
                ligne_facture_temp.QUANTITE AS QUANTITY, MONTANT_HT AS 'AMOUNT ET', MONTANT_TTC AS 'AMOUNT IT', GRIFFE_UTILISATEUR AS 'USER' 
                , CODE_LOT FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            query = "SELECT ID_LIGNE_FACTURE, TYPE_LIGNE_FACTURE, ligne_facture_temp.CODE_ARTICLE As 'ARTICLE', LIBELLE_FACTURE AS 'DESIGNATION',PRIX_UNITAIRE_TTC As 'PU TTC',
                ligne_facture_temp.QUANTITE, MONTANT_HT AS 'MONTANT HT', MONTANT_TTC AS 'MONTANT TTC', GRIFFE_UTILISATEUR AS 'GRIFFE UTILISATEUR' 
                , CODE_LOT FROM ligne_facture_temp WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND CODE_FACTURE =@CODE_FACTURE ORDER BY ID_LIGNE_FACTURE DESC"

        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = GunaTextBoxCodeFacture.Text

        Dim table As New DataTable()

        adapter.Fill(table)

        If GlobalVariable.typeDeClientAFacturer = "comptoir" Then
            GunaDataGridViewLigneFacture.Columns.Clear()
        End If

        If table.Rows.Count > 0 Then

            GunaDataGridViewLigneFacture.DataSource = table

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaDataGridViewLigneFacture.Columns("UNIT PRICE").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("UNIT PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GunaDataGridViewLigneFacture.Columns("QUANTITY").DefaultCellStyle.Format = "#,##0.00"
                GunaDataGridViewLigneFacture.Columns("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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
            'GunaDataGridViewLigneFacture.Columns.Clear()
        End If

    End Sub

End Class