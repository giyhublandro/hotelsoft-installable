Imports MySql.Data.MySqlClient

Public Class TarifForm

    'Dim Connect As New DataBaseManipulation

    Private Sub TarifForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Liste des tarifs
        tarifList()

        'Liste des différents prix de tarifs
        tarifPrixList()

        'Chargement des tarifs dynamique
        AutoLoadOfTarifDynamiqueRate()

        If GunaComboBoxTarificationDynamique.Items.Count > 0 Then
            GunaComboBoxTarificationDynamique.SelectedIndex = -1
        End If

        If GlobalVariable.tarifFromFrontDesk Then
            TabControl1.SelectedIndex = 1
        Else
            TabControl1.SelectedIndex = 0
        End If

        GunaComboBoxEtatTarifDynamique.Items.Add("Désactiver") 'INDEX = ETAT = 0
        GunaComboBoxEtatTarifDynamique.Items.Add("Activer") 'INDEX = ETAT = 1

        GunaComboBoxEtatTarifDynamique.SelectedIndex = 0

    End Sub

    'List of tarif +  prix
    Private Sub tarifPrixList()

        Dim query As String = ""

        Dim table As New DataTable()
        Dim table1 As New DataTable()

        If GlobalVariable.tarifFromFrontDesk Then

            'AFFICHAGE DES TARIFICATIONS DEPUIS LA FENETRE DE CREATION DE RESERVATION
            Dim promo As String = "PROMO"
            Dim forfait As String = "Promo"

            'query = "SELECT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE', DESCRIPTION_TARIF AS 'DESCRIPTION', TYPE_TARIF AS 'TYPE TARIF',CODE_TYPE AS 'CODE TYPE',PRIX_TARIF1 AS 'PRIX 1', PRIX_TARIF2 AS 'PRIX 2', PRIX_TARIF3 AS 'PRIX 3', PRIX_TARIF4 AS 'PRIX 4', PRIX_TARIF5 AS 'PRIX 5', DATE_CREATION AS 'DATE CREATION', ID_TARIF AS 'ID TARIF' FROM tarif_prix WHERE CODE_TARIF=@PROMO OR CODE_TARIF=@FORFAIT ORDER BY LIBELLE_TARIF ASC"

            query = "SELECT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE', TYPE_TARIF AS 'TYPE TARIF',CODE_TYPE AS 'CODE TYPE',PRIX_TARIF1 AS 'PRIX 1', PRIX_TARIF2 AS 'PRIX 2', PRIX_TARIF3 AS 'PRIX 3', PRIX_TARIF4 AS 'PRIX 4', PRIX_TARIF5 AS 'PRIX 5', DATE_CREATION AS 'DATE CREATION', ID_TARIF AS 'ID TARIF' FROM tarif_prix WHERE CODE_TARIF=@PROMO OR CODE_TARIF=@FORFAIT ORDER BY LIBELLE_TARIF ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            command.Parameters.Add("@PROMO", MySqlDbType.VarChar).Value = "PROMO"
            command.Parameters.Add("@FORFAIT", MySqlDbType.VarChar).Value = "FORFAIT"

            adapter.Fill(table)

        Else

            If GunaCheckBoxDynamique.Checked Then

                '1- TARIFICATION DYNAMIQUE

                query = "SELECT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE TARIF', LIBELLE_TARIF_DYNAMIQUE As 'TYPE TARIF DYNAMIQUE',DESCRIPTION_TARIF AS 'DESCRIPTION', TYPE_TARIF AS 'TYPE TARIF', CODE_TYPE AS 'CODE TYPE',PRIX_TARIF1 AS 'PRIX 1', PRIX_TARIF2 AS 'PRIX 2', PRIX_TARIF3 AS 'PRIX 3', PRIX_TARIF4 AS 'PRIX 4', PRIX_TARIF5 AS 'PRIX 5', ID_TARIF AS 'ID TARIF' FROM tarif_prix, tarification_dynamique WHERE tarif_prix.CODE_TARIF_DYNAMIQUE = tarification_dynamique.CODE_TARIF_DYNAMIQUE ORDER BY LIBELLE_TARIF ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                Dim adapter As New MySqlDataAdapter(command)

                adapter.Fill(table)

            Else

                '1- TARIF NEGOCIE

                'INSERT INTO `barcleshsoftdb`.`tarif` (`ID_TARIF`, `CODE_TARIF`, `LIBELLE_TARIF`, `DESCRIPTION_TARIF`, `TYPE_TARIF`, `CODE_TYPE`, `PRIX_TARIF1`, `PRIX_TARIF2`, `PRIX_TARIF3`, `PRIX_TARIF4`, `PRIX_TARIF5`, `DATE_CREATION`) VALUES (NULL, 'GRA', 'GRATUITEE', 'GRATUITEE', '', '', '0', '0', '0', '0', '0', '2022-04-07 11:44:38');
                Dim query1 As String = "SELECT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE TARIF', DESCRIPTION_TARIF AS 'DESCRIPTION', TYPE_TARIF AS 'TYPE TARIF', CODE_TYPE AS 'CODE TYPE',PRIX_TARIF1 AS 'PRIX 1', PRIX_TARIF2 AS 'PRIX 2', PRIX_TARIF3 AS 'PRIX 3', PRIX_TARIF4 AS 'PRIX 4', PRIX_TARIF5 AS 'PRIX 5', ID_TARIF AS 'ID TARIF' FROM tarif_prix WHERE CODE_TARIF_DYNAMIQUE=@CODE_TARIF_DYNAMIQUE ORDER BY LIBELLE_TARIF ASC"

                Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
                command1.Parameters.Add("@CODE_TARIF_DYNAMIQUE", MySqlDbType.VarChar).Value = ""

                Dim adapter1 As New MySqlDataAdapter(command1)

                adapter1.Fill(table1)

                table.Merge(table1)

            End If


        End If

        If (table.Rows.Count > 0) Then

            If GunaDataGridViewAffectationTarifPrix.Columns.Count > 0 Then
                GunaDataGridViewAffectationTarifPrix.Columns.Clear()
            End If

            GunaDataGridViewAffectationTarifPrix.DataSource = table

            GunaDataGridViewAffectationTarifPrix.Columns("ID TARIF").Visible = False
            GunaDataGridViewAffectationTarifPrix.Columns("TYPE TARIF").Visible = False

            GunaDataGridViewAffectationTarifPrix.Columns("PRIX 1").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewAffectationTarifPrix.Columns("PRIX 2").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewAffectationTarifPrix.Columns("PRIX 3").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewAffectationTarifPrix.Columns("PRIX 4").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewAffectationTarifPrix.Columns("PRIX 5").DefaultCellStyle.Format = "#,##0"

        Else
            GunaDataGridViewAffectationTarifPrix.Columns.Clear()
        End If

        AutoLoadOfTarif()

        Functions.CleanTitleOfForms(NomDuTarif)

        'Connect.closeConnection()

    End Sub

    'List of tarifs
    Public Sub tarifList()

        Dim query As String = "SELECT DISTINCT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE', DESCRIPTION_TARIF AS 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM tarif ORDER BY LIBELLE_TARIF ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            DataGridViewListeDesTarifs.DataSource = table
        Else
            DataGridViewListeDesTarifs.Columns.Clear()
        End If

        AutoLoadOfTarif()

        'Connect.closeConnection()

        Functions.CleanTitleOfForms(NomDuTarif)

        NomDuTarif.Visible = False

    End Sub

    'Function to check empty fields
    Public Function verifyFields() As Boolean

        Dim check As Boolean = False

        If (GunaTextBoxCodeTarif.Text.Trim().Equals("") _
                    Or GunaTextBoxLibelle.Text.Trim().Equals("") _
                    Or GunaTextBoxPrix1.Text.Trim().Equals("")) Then
            check = False

        Else

            check = True

        End If

        Return check

    End Function

    'Insertion d'une nouvelle ligne 
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim prix1 As Double = 0
        Dim prix2 As Double = 0
        Dim prix3 As Double = 0
        Dim prix4 As Double = 0
        Dim prix5 As Double = 0

        Double.TryParse(GunaTextBoxPrix1.Text, prix1)
        Double.TryParse(GunaTextBoxPrix2.Text, prix2)
        Double.TryParse(GunaTextBoxPrix3.Text, prix3)
        Double.TryParse(GunaTextBoxPrix4.Text, prix4)
        Double.TryParse(GunaTextBoxPrix5.Text, prix5)

        Dim CODE_TARIF As String = ""
        Dim LIBELLE_TARIF As String = ""
        Dim DESCRIPTION_TARIF As String = ""

        Dim CODE_TARIF_DYNAMIQUE As String = ""

        If GunaComboBoxTarificationDynamique.SelectedIndex >= 0 Then
            CODE_TARIF_DYNAMIQUE = GunaComboBoxTarificationDynamique.SelectedValue.ToString()
        End If
        'The Code used at the creation of a tarif is is empty then we are affecting values to a tarif

        If Not GunaComboBoxCodeTarif.SelectedValue = "" Then

            CODE_TARIF = GunaComboBoxCodeTarif.SelectedValue

            LIBELLE_TARIF = Functions.getElementByCode(CODE_TARIF, "tarif", "CODE_TARIF").Rows(0)("LIBELLE_TARIF")
            DESCRIPTION_TARIF = Functions.getElementByCode(CODE_TARIF, "tarif", "CODE_TARIF").Rows(0)("DESCRIPTION_TARIF")

        End If

        Dim TYPE_TARIF = GunaComboBoxTypeTarif.SelectedItem.ToString

        Dim PRIX_TARIF1 = prix1
        Dim PRIX_TARIF2 = prix2
        Dim PRIX_TARIF3 = prix3
        Dim PRIX_TARIF4 = prix4
        Dim PRIX_TARIF5 = prix5

        Dim CODE_TYPE = GunaComboBoxCodeTypeTarif.SelectedValue

        Dim tarif As New Tarifs

        If GunaButtonEnregistrer.Text = "Sauvegarder" Then

            'We update the value of the row in case of any change
            If tarif.update("", LIBELLE_TARIF, DESCRIPTION_TARIF, TYPE_TARIF, CODE_TYPE, PRIX_TARIF1, PRIX_TARIF2, PRIX_TARIF3, PRIX_TARIF4, PRIX_TARIF5, "tarif_prix", GlobalVariable.codeTarifPrixToUpdate) Then

                MessageBox.Show("Mise à jour effectuée avec succès", "Création de Tarif", MessageBoxButtons.OK, MessageBoxIcon.Information)

                tarif.updateCritere(CODE_TARIF, CODE_TARIF_DYNAMIQUE, CODE_TYPE)

                GlobalVariable.codeTarifPrixToUpdate = ""

            End If

            GunaButtonEnregistrer.Text = "Enregistrer"

        Else
            'company verifyfields function
            If (True) Then
                'check if the company alreday exist

                Dim controleExistence As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_TARIF, "tarif_prix", "CODE_TARIF", CODE_TYPE, "CODE_TYPE")

                If Not controleExistence.Rows.Count > 0 Then

                    If Trim(GunaTextBoxCodeTarif.Text) = "" Then

                        If tarif.insert(CODE_TARIF, LIBELLE_TARIF, DESCRIPTION_TARIF, TYPE_TARIF, CODE_TYPE, PRIX_TARIF1, PRIX_TARIF2, PRIX_TARIF3, PRIX_TARIF4, PRIX_TARIF5, "tarif_prix") Then
                            MessageBox.Show("Nouveau Type de Tarif enregistré avec succès", "Création de Tarif", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            tarif.updateCritere(CODE_TARIF, CODE_TARIF_DYNAMIQUE, CODE_TYPE)

                        Else
                            MessageBox.Show("Un problème lors de la création !!", "Création de Tarif", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    End If

                Else
                    MessageBox.Show("Cette configuration tarifaire existe déjà, Essayer à nouveau", "Type Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création de Type", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        'We refresh the room type list
        tarifList()

        'Liste des différents prix de tarifs
        tarifPrixList()

        Functions.ClearTextBox(Me)

        GunaComboBoxCodeTypeTarif.SelectedIndex = -1
        GunaComboBoxTypeTarif.SelectedIndex = -1
        GunaComboBoxTarificationDynamique.SelectedIndex = -1

    End Sub

    'We double to update a row
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewListeDesTarifs.CellDoubleClick

        'When we doubleclick on the room category datagrid it is either for update or for bringing the selected row to front desk

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.DataGridViewListeDesTarifs.Rows(e.RowIndex)

            If GlobalVariable.tarifFromFrontDesk Then

                'We select a room by doucliking when coming from frontdesk

                Dim mainWindow As New MainWindow()

                'We make sure it is possible to Choose a room if a room type is choosen first
                'We set back the diasbled values after checkin or save
                GlobalVariable.tarifFromFrontDeskCode = Trim(row.Cells("ID TARIF").Value.ToString)

                mainWindow.Activate()

                Me.Close()

            Else

                'We come from the front desk to fill the room form part of the front desk
                Dim tarif As DataTable = Functions.getElementByCode(row.Cells("CODE TARIF").Value.ToString, "tarif", "CODE_TARIF")

                GunaTextBoxCodeTarif.Text = tarif.Rows(0)("CODE_TARIF")
                GunaTextBoxLibelle.Text = tarif.Rows(0)("LIBELLE_TARIF")
                GunaTextBoxDescriptionTarif.Text = tarif.Rows(0)("DESCRIPTION_TARIF")

                'GunaComboBoxTypeTarif.SelectedItem = tarif.Rows(0)("TYPE_TARIF") 'Chambre, Salle ou articles...
                'GunaComboBoxCodeTypeTarif.SelectedValue = tarif.Rows(0)("CODE_TYPE") 'Code de chambre, code article ...
                'GunaComboBoxCodeTarif.SelectedValue = tarif.Rows(0)("CODE_TARIF") ' code du tarif

                'GunaTextBoxPrix1.Text = Format(tarif.Rows(0)("PRIX_TARIF1"), "#,##0")
                'GunaTextBoxPrix2.Text = Format(tarif.Rows(0)("PRIX_TARIF2"), "#,##0")
                'GunaTextBoxPrix3.Text = Format(tarif.Rows(0)("PRIX_TARIF3"), "#,##0")
                'GunaTextBoxPrix4.Text = Format(tarif.Rows(0)("PRIX_TARIF4"), "#,##0")
                'GunaTextBoxPrix5.Text = Format(tarif.Rows(0)("PRIX_TARIF5"), "#,##0")

            End If

            Functions.AffectingTitleToAForm(GunaTextBoxLibelle.Text, NomDuTarif)

            'We change the text of the enregistrer butTon from enregistrer to save normql update
            GunaButtonEnregistrer.Text = "Sauvegarder"

            GunaButtonAjouterTarif.Text = "Sauvegarder"

        End If

    End Sub

    '--------------------------------------------LIVE SEARCH --------------------------------------------------------------------

    'Live Search implémentation based on CODE
    Private Sub GunaTextBoxLiveSearch_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT DISTINCT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE', DESCRIPTION_TARIF AS 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM tarif WHERE CODE_TARIF LIKE '%" & GunaTextBoxLiveSearchCode.Text & "%' ORDER BY LIBELLE_TARIF ASC"
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'DataGridView1.DataSource = table
        'Else
        'DataGridView1.Columns.Clear()
        'End If

        ''Connect.closeConnection()

    End Sub

    'Reorganise when entering into live search by code
    Private Sub GunaTextBoxLiveSearch_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT DISTINCT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE', DESCRIPTION_TARIF AS 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM tarif ORDER BY LIBELLE_TARIF ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            DataGridViewListeDesTarifs.DataSource = table
        End If

        'Connect.closeConnection()

    End Sub

    'Searching based on name
    Private Sub GunaTextBoxLiveSearchlibelle_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT DISTINCT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE', DESCRIPTION_TARIF AS 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM tarif WHERE LIBELLE_TARIF LIKE '%" & GunaTextBoxLiveSearchlibelle.Text & "%' ORDER BY LIBELLE_TARIF ASC"
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'DataGridView1.DataSource = table
        'Else

        'End If

        'Connect.closeConnection()

    End Sub

    Private Sub GunaTextBoxLiveSearchlibelle_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT DISTINCT CODE_TARIF As 'CODE TARIF', LIBELLE_TARIF AS 'LIBELLE', DESCRIPTION_TARIF AS 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM tarif ORDER BY LIBELLE_TARIF ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            DataGridViewListeDesTarifs.DataSource = table
        End If

        'Connect.closeConnection()

    End Sub

    Private Sub GunaImageButton7_Click(sender As Object, e As EventArgs) Handles GunaImageButton7.Click
        GlobalVariable.tarifFromFrontDeskCode = ""
        GlobalVariable.tarifFromFrontDesk = False
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        GlobalVariable.tarifFromFrontDeskCode = ""
        GlobalVariable.tarifFromFrontDesk = False
        Me.Close()
    End Sub

    'When we change the selected index of type_tarif, we automatically load the type_code
    Private Sub GunaComboBoxTypeCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeTarif.SelectedIndexChanged

        Dim typeCode As DataTable
        Dim member As String = ""
        Dim value As String = ""

        If GunaComboBoxTypeTarif.SelectedItem = "Article" Then

            typeCode = Functions.allTableFields("famille")
            member = "LIBELLE_FAMILLE"
            value = "CODE_FAMILLE"

        ElseIf GunaComboBoxTypeTarif.SelectedItem = "Chambre" Then

            typeCode = Functions.getElementByCode("chambre", "type_chambre", "TYPE")
            member = "LIBELLE_TYPE_CHAMBRE"
            value = "CODE_TYPE_CHAMBRE"

        ElseIf GunaComboBoxTypeTarif.SelectedItem = "Groupe article" Then

        ElseIf GunaComboBoxTypeTarif.SelectedItem = "Salle" Then

            typeCode = Functions.getElementByCode("salle", "type_chambre", "TYPE")
            member = "LIBELLE_TYPE_CHAMBRE"
            value = "CODE_TYPE_CHAMBRE"

        End If

        If GunaComboBoxTypeTarif.SelectedIndex >= 0 Then

            If (typeCode.Rows.Count > 0) Then

                GunaComboBoxCodeTypeTarif.DataSource = typeCode
                GunaComboBoxCodeTypeTarif.ValueMember = value
                GunaComboBoxCodeTypeTarif.DisplayMember = member

                GunaComboBoxCodeTypeTarif.Enabled = True

            Else

                GunaComboBoxCodeTypeTarif.Enabled = False

            End If

        End If

        'Connect.closeConnection()

    End Sub

    'Adding of New Tarif
    Private Sub GunaButtonAjouterTarif_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterTarif.Click

        Dim CODE_TARIF = GunaTextBoxCodeTarif.Text
        Dim LIBELLE_TARIF = GunaTextBoxLibelle.Text
        Dim DESCRIPTION_TARIF = GunaTextBoxDescriptionTarif.Text

        Dim tarif As New Tarifs

        If GunaButtonEnregistrer.Text = "Sauvegarder" Then

            'We update the value of the row in case of any change
            If tarif.update(CODE_TARIF, LIBELLE_TARIF, DESCRIPTION_TARIF) Then
                MessageBox.Show("Mise à jour effectuée avec succès", "Création de Tarif", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            GunaButtonEnregistrer.Text = "Enregistrer"
            GunaButtonAjouterTarif.Text = "Ajouter"

        Else
            'company verifyfields function
            If Not LIBELLE_TARIF = "" And Not CODE_TARIF = "" Then
                'check if the company alreday exist
                If Not tarif.forfaitExists(LIBELLE_TARIF, LIBELLE_TARIF) Then

                    If tarif.insert(CODE_TARIF, LIBELLE_TARIF, DESCRIPTION_TARIF) Then
                        MessageBox.Show("Nouveau Type de Tarif enregistré avec succès", "Création de Tarif", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création de Tarif", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Ce Type existe déjà, Essayer à nouveau", "Type Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création de Type", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        'We refresh the room type list
        tarifList()

        Functions.ClearTextBox(Me)

    End Sub

    Private Sub AutoLoadOfTarif()

        Dim tarif As New Tarifs

        Dim ListOftarif As DataTable = tarif.SelectDistinctTarif()

        GunaComboBoxCodeTarif.DataSource = ListOftarif
        GunaComboBoxCodeTarif.ValueMember = "CODE_TARIF"
        GunaComboBoxCodeTarif.DisplayMember = "LIBELLE_TARIF"

    End Sub

    Private Sub AutoLoadOfTarifDynamiqueRate()

        Dim tarif As New Tarifs

        Dim ListOftarifDynamique As DataTable = tarif.selectionDeTarifDynamique("")

        GunaComboBoxTarificationDynamique.DataSource = ListOftarifDynamique
        GunaComboBoxTarificationDynamique.ValueMember = "CODE_TARIF_DYNAMIQUE"
        GunaComboBoxTarificationDynamique.DisplayMember = "LIBELLE_TARIF_DYNAMIQUE"

    End Sub

    'When we double click on the Datagrid of tarif_prix - affecting price to tarifs
    Private Sub GunaDataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewAffectationTarifPrix.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewAffectationTarifPrix.Rows(e.RowIndex)

            'We are trying to load a tarif from frontdesk
            If GlobalVariable.tarifFromFrontDesk Then

                'We select a room by doucliking when coming from frontdesk

                Dim mainWindow As New MainWindow()

                'We make sure it is possible to Choose a room if a room type is choosen first
                'We set back the diasbled values after checkin or save
                GlobalVariable.tarifFromFrontDeskCode = Trim(row.Cells("ID TARIF").Value.ToString)

                mainWindow.Activate()

                Me.Close()

            Else

                Dim tarifId As Integer = 0
                Integer.TryParse(row.Cells("ID TARIF").Value.ToString, tarifId)

                Dim tarif As DataTable = Functions.getElementByCode(tarifId, "tarif_prix", "ID_TARIF")

                If tarif.Rows.Count > 0 Then

                    GunaComboBoxTypeTarif.SelectedItem = Trim(tarif.Rows(0)("TYPE_TARIF")) 'Chambre, Salle ou articles...
                    GunaComboBoxCodeTypeTarif.SelectedValue = tarif.Rows(0)("CODE_TYPE") 'Code de chambre, code article ...
                    GunaComboBoxCodeTarif.SelectedValue = tarif.Rows(0)("CODE_TARIF") ' code du tarif

                    GunaTextBoxPrix1.Text = Format(tarif.Rows(0)("PRIX_TARIF1"), "#,##0")
                    GunaTextBoxPrix2.Text = Format(tarif.Rows(0)("PRIX_TARIF2"), "#,##0")
                    GunaTextBoxPrix3.Text = Format(tarif.Rows(0)("PRIX_TARIF3"), "#,##0")
                    GunaTextBoxPrix4.Text = Format(tarif.Rows(0)("PRIX_TARIF4"), "#,##0")
                    GunaTextBoxPrix5.Text = Format(tarif.Rows(0)("PRIX_TARIF5"), "#,##0")

                    GunaComboBoxTarificationDynamique.SelectedValue = tarif.Rows(0)("CODE_TARIF_DYNAMIQUE")

                    GlobalVariable.codeTarifPrixToUpdate = tarif.Rows(0)("ID_TARIF")

                    Functions.AffectingTitleToAForm(tarif.Rows(0)("LIBELLE_TARIF"), NomDuTarif)

                End If

            End If

            'We change the text of the enregistrer butTon from enregistrer to save normql update
            GunaButtonEnregistrer.Text = "Sauvegarder"

            GunaButtonAjouterTarif.Text = "Sauvegarder"

        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerTaux.Click

        'ENREGISTREMENT / SAUVEGARDE DE TARIFICATION DYNAMIQUE

        Dim tarif As New Tarifs
        Dim message As String = ""
        Dim CRITERE As Integer = 0

        If GunaComboBoxCritere.SelectedIndex >= 0 Then

            If GunaComboBoxCritere.SelectedIndex = 0 Then
                CRITERE = 0 ' PAR APPORT AU TAUX D'OCCUPATION
            ElseIf GunaComboBoxCritere.SelectedIndex = 1 Then
                CRITERE = 1 ' PAR APPORT AU NOMBRE DE NUITEE
            End If

        End If

        Dim LIBELLE_TARIF_DYNAMIQUE As String = GunaTextBoxLibelleTArifDynamique.Text

        'CRITERE DE REDUCTION 
        Dim INTERVAL_1 As Double = NumericUpDownI1.Value
        Dim INTERVAL_2 As Double = NumericUpDownI2.Value
        Dim INTERVAL_3 As Double = NumericUpDownI3.Value
        Dim INTERVAL_4 As Double = NumericUpDownI4.Value
        Dim INTERVAL_5 As Double = NumericUpDownI5.Value

        'POURCENTAGE DE REDUCTION 
        Dim INTERVAL_11 As Double = 0
        Dim INTERVAL_22 As Double = 0
        Dim INTERVAL_33 As Double = 0
        Dim INTERVAL_44 As Double = 0
        Dim INTERVAL_55 As Double = 0

        Dim ETAT As Integer = 0

        If GunaComboBoxEtatTarifDynamique.SelectedIndex >= 0 Then
            ETAT = GunaComboBoxEtatTarifDynamique.SelectedIndex
        End If

        If Not Trim(GunaTextBoxP1.Text).Equals("") Then
            INTERVAL_11 = GunaTextBoxP1.Text
        End If

        If Not Trim(GunaTextBoxP2.Text).Equals("") Then
            INTERVAL_22 = GunaTextBoxP2.Text
        End If

        If Not Trim(GunaTextBoxP3.Text).Equals("") Then
            INTERVAL_33 = GunaTextBoxP3.Text
        End If

        If Not Trim(GunaTextBoxP4.Text).Equals("") Then
            INTERVAL_44 = GunaTextBoxP4.Text
        End If

        If Not Trim(GunaTextBoxP5.Text).Equals("") Then
            INTERVAL_55 = GunaTextBoxP5.Text
        End If

        Dim UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim CODE_TARIF_DYNAMIQUE As String = Functions.GeneratingRandomCodePanne("tarification_dynamique", "")

        If Trim(GunaButtonEnregistrerTaux.Text).Equals("Enregistrer") Then
            message = "Nouvelle tarification dynamique enregistrée !!"
        Else
            message = "Tarification dynamique mise à jour !!"
            CODE_TARIF_DYNAMIQUE = GunaTextBoxCodeTarifTaux.Text
            Functions.DeleteElementByCode(CODE_TARIF_DYNAMIQUE, "tarification_dynamique", "CODE_TARIF_DYNAMIQUE")
            GunaButtonEnregistrerTaux.Text = "Enregistrer"
        End If

        If Trim(GunaTextBoxLibelleTArifDynamique.Text).Equals("") Then
            message = "Bien vouloir remplir le libéllé !!"
            MessageBox.Show(message, "TARIFICATION DYNAMIQUE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            tarif.insertTarifDynamique(CRITERE, LIBELLE_TARIF_DYNAMIQUE, INTERVAL_1, INTERVAL_2, INTERVAL_3, INTERVAL_4, INTERVAL_5, INTERVAL_11, INTERVAL_22, INTERVAL_33, INTERVAL_44, INTERVAL_55, UTILISATEUR_CREA, CODE_TARIF_DYNAMIQUE, ETAT)
            MessageBox.Show(message, "TARIFICATION DYNAMIQUE", MessageBoxButtons.OK, MessageBoxIcon.Information)

            AffichageDesTarificationsDynamique()

            NumericUpDownI1.Value = 0
            NumericUpDownI2.Value = 0
            NumericUpDownI3.Value = 0
            NumericUpDownI4.Value = 0
            NumericUpDownI5.Value = 0

            NumericUpDownLI1.Value = 0
            NumericUpDownLI2.Value = 0
            NumericUpDownLI3.Value = 0
            NumericUpDownLI4.Value = 0
            NumericUpDownLI5.Value = 0

            GunaTextBoxP1.Clear()
            GunaTextBoxP2.Clear()
            GunaTextBoxP3.Clear()
            GunaTextBoxP4.Clear()
            GunaTextBoxP5.Clear()
            GunaTextBoxCodeTarifTaux.Clear()
            GunaTextBoxLibelleTArifDynamique.Clear()

            GunaLabel6.Text = "CREATION DE TARRIFICATION DYNAMIQUE"

        End If

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownI1.ValueChanged
        NumericUpDownLI2.Value = NumericUpDownI1.Value + 1
    End Sub

    Private Sub NumericUpDown7_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownI2.ValueChanged
        NumericUpDownLI3.Value = NumericUpDownI2.Value + 1
    End Sub

    Private Sub NumericUpDown10_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownI3.ValueChanged
        NumericUpDownLI4.Value = NumericUpDownI3.Value + 1
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownI4.ValueChanged
        NumericUpDownLI5.Value = NumericUpDownI4.Value + 1
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        AutoLoadOfTarifDynamiqueRate()

        GunaComboBoxTarificationDynamique.SelectedIndex = -1

        If TabControl1.SelectedIndex = 2 Then

            NumericUpDownLI1.Value = 0

            GunaComboBoxCritere.SelectedIndex = 0

            'AFFICHAGE DES TARIFICATIONS DYNAMIQUE
            AffichageDesTarificationsDynamique()

        ElseIf TabControl1.SelectedIndex = 3 Then

            GunaDateTimePickerEditionDebut.Value = GlobalVariable.DateDeTravail
            GunaDateTimePickerEditionFin.Value = GlobalVariable.DateDeTravail.AddDays(7)

        End If

    End Sub

    Public Sub AffichageDesTarificationsDynamique()

        GunaDataGridVieListeTarifDynamique.Columns.Clear()

        GunaDataGridVieListeTarifDynamique.Columns.Add("LIBELLE_TARIF_DYNAMIQUE", "LIBELLE")
        GunaDataGridVieListeTarifDynamique.Columns.Add("CRITERE", "CRITERE")
        GunaDataGridVieListeTarifDynamique.Columns.Add("INTERVAL_1", ">")
        GunaDataGridVieListeTarifDynamique.Columns.Add("REDUCTION_1", "REDUCT 1")
        GunaDataGridVieListeTarifDynamique.Columns.Add("INTERVAL_2", "<>")
        GunaDataGridVieListeTarifDynamique.Columns.Add("REDUCTION_2", "REDUCT 2")
        GunaDataGridVieListeTarifDynamique.Columns.Add("INTERVAL_3", "<>")
        GunaDataGridVieListeTarifDynamique.Columns.Add("REDUCTION_3", "REDUCT 3")
        GunaDataGridVieListeTarifDynamique.Columns.Add("INTERVAL_4", "<>")
        GunaDataGridVieListeTarifDynamique.Columns.Add("REDUCTION_4", "REDUCT 4")
        GunaDataGridVieListeTarifDynamique.Columns.Add("INTERVAL_5", "<>")
        GunaDataGridVieListeTarifDynamique.Columns.Add("REDUCTION_5", "REDUCT 5")
        GunaDataGridVieListeTarifDynamique.Columns.Add("INTERVAL_6", "<")
        GunaDataGridVieListeTarifDynamique.Columns.Add("ETAT", "ETAT")
        GunaDataGridVieListeTarifDynamique.Columns.Add("CODE_TARIF_DYNAMIQUE", "CODE_TARIF_DYNAMIQUE")

        GunaDataGridVieListeTarifDynamique.Rows.Clear()

        Dim tarif As New Tarifs()

        Dim listeDestarificationsDynamique As DataTable = tarif.selectionDeTarifDynamique("")

        If Not listeDestarificationsDynamique Is Nothing Then

            If listeDestarificationsDynamique.Rows.Count > 0 Then

                Dim CRITERE As String = ""
                Dim LIBELLE As String = ""
                Dim CODE_TARIF_DYNAMIQUE As String = ""

                Dim I1 As Double = 0
                Dim I2 As Double = 0
                Dim I3 As Double = 0
                Dim I4 As Double = 0
                Dim I5 As Double = 0
                Dim I6 As Double = 0

                Dim R1 As Double = 0
                Dim R2 As Double = 0
                Dim R3 As Double = 0
                Dim R4 As Double = 0
                Dim R5 As Double = 0
                Dim R6 As Double = 0

                Dim ETAT As String = ""

                For i = 0 To listeDestarificationsDynamique.Rows.Count - 1

                    If listeDestarificationsDynamique.Rows(i)("CRITERE") = 0 Then
                        CRITERE = "TAUX D'OCCUPATION"
                    ElseIf listeDestarificationsDynamique.Rows(i)("CRITERE") = 1 Then
                        CRITERE = "NOMBRE DE NUITEE"
                    End If

                    LIBELLE = listeDestarificationsDynamique.Rows(i)("LIBELLE_TARIF_DYNAMIQUE")
                    CODE_TARIF_DYNAMIQUE = listeDestarificationsDynamique.Rows(i)("CODE_TARIF_DYNAMIQUE")

                    I2 = listeDestarificationsDynamique.Rows(i)("INTERVAL_1")
                    I3 = listeDestarificationsDynamique.Rows(i)("INTERVAL_2")
                    I4 = listeDestarificationsDynamique.Rows(i)("INTERVAL_3")
                    I5 = listeDestarificationsDynamique.Rows(i)("INTERVAL_4")
                    I6 = listeDestarificationsDynamique.Rows(i)("INTERVAL_5")

                    R1 = listeDestarificationsDynamique.Rows(i)("INTERVAL_11")
                    R2 = listeDestarificationsDynamique.Rows(i)("INTERVAL_22")
                    R3 = listeDestarificationsDynamique.Rows(i)("INTERVAL_33")
                    R4 = listeDestarificationsDynamique.Rows(i)("INTERVAL_44")
                    R5 = listeDestarificationsDynamique.Rows(i)("INTERVAL_55")

                    If listeDestarificationsDynamique.Rows(i)("ETAT") = 0 Then
                        ETAT = "Désactiver"
                    ElseIf listeDestarificationsDynamique.Rows(i)("ETAT") = 1 Then
                        ETAT = "Activer"
                    End If

                    GunaDataGridVieListeTarifDynamique.Rows.Add(LIBELLE, CRITERE, I1, R1 & " %", I2, R2 & " %", I3, R3 & " %", I4, R4 & " %", I5, R5 & " %", I6, ETAT, CODE_TARIF_DYNAMIQUE)

                Next

                GunaDataGridVieListeTarifDynamique.Columns("CODE_TARIF_DYNAMIQUE").Visible = False

                GunaDataGridVieListeTarifDynamique.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridVieListeTarifDynamique.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridVieListeTarifDynamique.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridVieListeTarifDynamique.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GunaDataGridVieListeTarifDynamique.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End If

        End If

    End Sub

    'EDITION DES TARIFICATION DYNAMIQUE

    Private Sub GunaDataGridVieListeTarifDynamique_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridVieListeTarifDynamique.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaLabel6.Text = "MISE A JOUR  DE TARRIFICATION DYNAMIQUE"
            GunaButtonEnregistrerTaux.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.GunaDataGridVieListeTarifDynamique.Rows(e.RowIndex)

            GunaTextBoxCodeTarifTaux.Text = row.Cells("CODE_TARIF_DYNAMIQUE").Value.ToString

            Dim TypeDeTarifDynamique As DataTable = Functions.getElementByCode(Trim(GunaTextBoxCodeTarifTaux.Text), "tarification_dynamique", "CODE_TARIF_DYNAMIQUE")

            If TypeDeTarifDynamique.Rows.Count > 0 Then

                GunaTextBoxLibelleTArifDynamique.Text = TypeDeTarifDynamique.Rows(0)("LIBELLE_TARIF_DYNAMIQUE")

                NumericUpDownI1.Value = TypeDeTarifDynamique.Rows(0)("INTERVAL_1")
                GunaTextBoxP1.Text = TypeDeTarifDynamique.Rows(0)("INTERVAL_11")

                NumericUpDownI2.Value = TypeDeTarifDynamique.Rows(0)("INTERVAL_2")
                GunaTextBoxP2.Text = TypeDeTarifDynamique.Rows(0)("INTERVAL_22")

                NumericUpDownI3.Value = TypeDeTarifDynamique.Rows(0)("INTERVAL_3")
                GunaTextBoxP3.Text = TypeDeTarifDynamique.Rows(0)("INTERVAL_33")

                NumericUpDownI4.Value = TypeDeTarifDynamique.Rows(0)("INTERVAL_4")
                GunaTextBoxP4.Text = TypeDeTarifDynamique.Rows(0)("INTERVAL_44")

                NumericUpDownI5.Value = TypeDeTarifDynamique.Rows(0)("INTERVAL_5")
                GunaTextBoxP5.Text = TypeDeTarifDynamique.Rows(0)("INTERVAL_55")

                GunaComboBoxEtatTarifDynamique.SelectedIndex = TypeDeTarifDynamique.Rows(0)("ETAT")

            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click

        Dim CODE_TARIFICATION_DYNAMIQUE As String = GunaDataGridVieListeTarifDynamique.CurrentRow.Cells("CODE_TARIF_DYNAMIQUE").Value.ToString()

        Dim LIBELLE As String = GunaDataGridVieListeTarifDynamique.CurrentRow.Cells("LIBELLE_TARIF_DYNAMIQUE").Value.ToString

        Dim dialog As DialogResult
        dialog = MessageBox.Show("Voulez-vous vraiment Supprimer la tarification dynamique " & LIBELLE & " ?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else

            Functions.DeleteRowFromDataGrid(GunaDataGridVieListeTarifDynamique, CODE_TARIFICATION_DYNAMIQUE, "tarification_dynamique", "CODE_TARIF_DYNAMIQUE")

            AffichageDesTarificationsDynamique()

            MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaComboBoxCodeTypeTarif_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCodeTypeTarif.SelectedIndexChanged

        GunaTextBoxPrix1.Text = 0
        GunaTextBoxPrix2.Text = 0
        GunaTextBoxPrix3.Text = 0
        GunaTextBoxPrix4.Text = 0
        GunaTextBoxPrix5.Text = 0

        'A CHAQUE CHANGEMENT ON DOIT DETERMINER LE MONTANT DONT ON DOIT EFFECTUER DES REDUCTIONS.

        GunaComboBoxTarificationDynamique.SelectedIndex = -1

        If GunaComboBoxCodeTypeTarif.SelectedIndex >= 0 Then
            'ON TRAITE UN TYPE DE CHAMBRE PAR EXAMPLE
            If GunaComboBoxTypeTarif.SelectedIndex > 0 Then

                'TRAITEMENT DES CHAMBRES
                If Trim(GunaComboBoxTypeTarif.SelectedItem).Equals("Chambre") Or Trim(GunaComboBoxTypeTarif.SelectedItem).Equals("Salle") Then
                    Dim CODE_TYPE = GunaComboBoxCodeTypeTarif.SelectedValue.ToString

                    Dim infoType As DataTable = Functions.getElementByCode(CODE_TYPE, "type_chambre", "CODE_TYPE_CHAMBRE")

                    If infoType.Rows.Count > 0 Then
                        GunaTextBoxPrixTypeDeChambre.Text = Format(infoType.Rows(0)("PRIX"), "#,##0")
                        GunaTextBoxTauxChargeVariable.Text = infoType.Rows(0)("TAUX_CHARGE_FIXE")
                    End If

                End If

            End If

        End If

    End Sub

    Private Sub GunaComboBoxTarificationDynamique_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTarificationDynamique.SelectedIndexChanged

        'AFFECTATION DES PRIX DE FACON AUTOMATIQUE A CHAQUE CHANGEMENT DE TARIFI DYNAMIQUE
        If GunaComboBoxTarificationDynamique.SelectedIndex >= 0 Then

            Dim TAUX_DE_CHARGE As Double = 0

            If Not Trim(GunaTextBoxTauxChargeVariable.Text).Equals("") Then
                TAUX_DE_CHARGE = GunaTextBoxTauxChargeVariable.Text
            End If

            GunaButtonEnregistrer.Visible = True

            Dim CODE_TARIF_DYNAMIQUE As String = GunaComboBoxTarificationDynamique.SelectedValue.ToString

            Dim infoTarifDynamique As DataTable = Functions.getElementByCode(CODE_TARIF_DYNAMIQUE, "tarification_dynamique", "CODE_TARIF_DYNAMIQUE")

            If infoTarifDynamique.Rows.Count > 0 Then

                Dim PRIX_LE_PLUS_BAS As Double = 0 'MONTANT LE PLUS BAS DONT ON PEUT VENDRE LA CHAMBRE
                Dim PRIX_VARIABLE As Double = 0 'MONTANT VARIABLE => MONTANT SUR LEQUEL ON VA CALCULER LA MAJORATION

                Dim MONTANT_ROOM_TYPE As Double = 0

                Dim MONTANT_DE_LA_MAJORATION As Double = 0

                If Not Trim(GunaTextBoxPrixTypeDeChambre.Text).Equals("") Then

                    MONTANT_ROOM_TYPE = Double.Parse(GunaTextBoxPrixTypeDeChambre.Text)

                    PRIX_LE_PLUS_BAS = TAUX_DE_CHARGE * MONTANT_ROOM_TYPE / 100

                    PRIX_VARIABLE = MONTANT_ROOM_TYPE - PRIX_LE_PLUS_BAS

                End If

                'ON CALCUL LE MONTANT DE REDUCTION A PARTIR DU MONTANT VARIABLE DDU TYPE DE CHAMBRE SUIVANT LES TAUX ET INTERVAL

                GunaTextBoxPrix1.Text = Format(PRIX_LE_PLUS_BAS + (infoTarifDynamique.Rows(0)("INTERVAL_11") / 100 * PRIX_VARIABLE), "#,##0")
                GunaTextBoxPrix2.Text = Format(PRIX_LE_PLUS_BAS + (infoTarifDynamique.Rows(0)("INTERVAL_22") / 100 * PRIX_VARIABLE), "#,##0")
                GunaTextBoxPrix3.Text = Format(PRIX_LE_PLUS_BAS + (infoTarifDynamique.Rows(0)("INTERVAL_33") / 100 * PRIX_VARIABLE), "#,##0")
                GunaTextBoxPrix4.Text = Format(PRIX_LE_PLUS_BAS + (infoTarifDynamique.Rows(0)("INTERVAL_44") / 100 * PRIX_VARIABLE), "#,##0")
                GunaTextBoxPrix5.Text = Format(PRIX_LE_PLUS_BAS + (infoTarifDynamique.Rows(0)("INTERVAL_55") / 100 * PRIX_VARIABLE), "#,##0")

            End If

        Else
            GunaButtonEnregistrer.Visible = False
        End If

    End Sub

    Private Sub GunaButtonEditionDeMasse_Click(sender As Object, e As EventArgs) Handles GunaButtonEditionDeMasse.Click

        Me.Cursor = Cursors.WaitCursor

        If GunaDataGridViewEditionDeMasse.Rows.Count > 0 Then
            GunaDataGridViewEditionDeMasse.Columns.Clear()
        End If

        editionDeMasseForm.Show()
        editionDeMasseForm.TopMost = True

        Me.Cursor = Cursors.Default

    End Sub

    '------------------------- EDITION DE MASSE -------------------------------------------------

    Public Function listeDesEditionsDeMasse(ByVal dateDebut As Date, ByVal dateFin As Date) As DataTable

        Dim query As String = ""

        If GunaCheckBoxFiltreDate.Checked Then
            query = "SELECT * FROM `disponibilite_tarif_specifique_periodique` WHERE DEBUT_PERIODE >= '" & dateDebut.ToString("yyyy-MM-dd") & "' AND FIN_PERIODE <='" & dateFin.ToString("yyyy-MM-dd") & "' ORDER BY DEBUT_PERIODE ASC, FIN_PERIODE ASC"
        Else
            query = "SELECT * FROM `disponibilite_tarif_specifique_periodique` ORDER BY DEBUT_PERIODE ASC, FIN_PERIODE ASC"
        End If

        'On Affiche toute reservation dont la date d'entree figure entre les deux dates saisies

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim TYPE_CHAMBRE As String = ""
        Dim TYPE_TARIF As String = ""

        Dim ETAT As String = ""

        If (table.Rows.Count > 0) Then

            GunaDataGridViewEditionDeMasse.Columns.Clear()

            GunaDataGridViewEditionDeMasse.Columns.Add("TYPE_CHAMBRE", "TYPE CHAMBRE")
            GunaDataGridViewEditionDeMasse.Columns.Add("CODE_TARIF", " TARIF")
            GunaDataGridViewEditionDeMasse.Columns.Add("DEBUT_PERIODE", "DU")
            GunaDataGridViewEditionDeMasse.Columns.Add("FIN_PERIODE", "AU")
            GunaDataGridViewEditionDeMasse.Columns.Add("MONTANT", "MONTANT")
            GunaDataGridViewEditionDeMasse.Columns.Add("ETAT", "ETAT")
            GunaDataGridViewEditionDeMasse.Columns.Add("CODE_DISPO_TARIF_SPECIFIC", "CODE_DISPO_TARIF_SPECIFIC")

            For i = 0 To table.Rows.Count - 1

                If Integer.Parse(table.Rows(i)("ETAT")) = 1 Then
                    ETAT = "Activer"
                ElseIf Integer.Parse(table.Rows(i)("ETAT")) = 0 Then
                    ETAT = "Désactiver"
                End If

                Dim infoTArif As DataTable = Functions.getElementByCode(table.Rows(i)("CODE_TARIF"), "tarif_prix", "CODE_TARIF")

                If infoTArif.Rows.Count > 0 Then
                    TYPE_TARIF = infoTArif.Rows(0)("LIBELLE_TARIF")
                End If

                Dim infoTypeChambre As DataTable = Functions.getElementByCode(table.Rows(i)("CODE_TYPE_CHAMBRE"), "type_chambre", "CODE_TYPE_CHAMBRE")

                If infoTypeChambre.Rows.Count > 0 Then
                    TYPE_CHAMBRE = infoTypeChambre.Rows(0)("LIBELLE_TYPE_CHAMBRE")
                End If

                GunaDataGridViewEditionDeMasse.Rows.Add(TYPE_CHAMBRE, TYPE_TARIF, CDate(table.Rows(i)("DEBUT_PERIODE")).ToShortDateString, CDate(table.Rows(i)("FIN_PERIODE")).ToShortDateString, Format(table.Rows(i)("MONTANT"), "#,##0"), ETAT, table.Rows(i)("CODE_DISPO_TARIF_SPECIFIC"))

            Next

            GunaDataGridViewEditionDeMasse.Columns("CODE_DISPO_TARIF_SPECIFIC").Visible = False

        Else
            GunaDataGridViewEditionDeMasse.Columns.Clear()
        End If


    End Function

    Private Sub GunaButtonAfficherEditionDeMasse_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherEditionDeMasse.Click

        Dim dateDebut As Date = GunaDateTimePickerEditionDebut.Value.ToShortDateString
        Dim dateFin As Date = GunaDateTimePickerEditionFin.Value.ToShortDateString

        listeDesEditionsDeMasse(dateDebut, dateFin)

    End Sub

    Private Sub GunaDataGridViewEditionDeMasse_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewEditionDeMasse.CellDoubleClick

        Me.Cursor = Cursors.WaitCursor

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewEditionDeMasse.Rows(e.RowIndex)

            Dim CODE_DISPO_TARIF_SPECIFIC As String = row.Cells("CODE_DISPO_TARIF_SPECIFIC").Value.ToString

            editionDeMasseForm.GunaButtonAppliquerTarifSpecifique.Text = "Sauvegarder"
            editionDeMasseForm.GunaTextBoxCodeTarifDynamiquePeriodique.Text = CODE_DISPO_TARIF_SPECIFIC

            'ON SELECTIONNE LES ELEMENTS DE LA TARIFICATION DE MASSE

            If GunaDataGridViewEditionDeMasse.Rows.Count > 0 Then
                GunaDataGridViewEditionDeMasse.Columns.Clear()
            End If

            editionDeMasseForm.Show()
            editionDeMasseForm.TopMost = True

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim CODE_DISPO_TARIF_SPECIFIC As String = GunaDataGridViewEditionDeMasse.CurrentRow.Cells("CODE_DISPO_TARIF_SPECIFIC").Value.ToString()

        Dim TYPE_CHAMBRE As String = GunaDataGridViewEditionDeMasse.CurrentRow.Cells("TYPE_CHAMBRE").Value.ToString
        Dim CODE_TARIF As String = GunaDataGridViewEditionDeMasse.CurrentRow.Cells("CODE_TARIF").Value.ToString

        Dim dialog As DialogResult
        dialog = MessageBox.Show("Voulez-vous vraiment Supprimer l'édition de masse " & TYPE_CHAMBRE & " - " & CODE_TARIF & " ?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else

            Functions.DeleteRowFromDataGrid(GunaDataGridViewEditionDeMasse, CODE_DISPO_TARIF_SPECIFIC, "disponibilite_tarif_specifique_periodique", "CODE_DISPO_TARIF_SPECIFIC")

            Dim dateDebut As Date = GunaDateTimePickerEditionDebut.Value.ToShortDateString
            Dim dateFin As Date = GunaDateTimePickerEditionFin.Value.ToShortDateString

            listeDesEditionsDeMasse(dateDebut, dateFin)

            MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        Dim ID_TARIF_PRIX As Integer = GunaDataGridViewAffectationTarifPrix.CurrentRow.Cells("ID TARIF").Value

        Dim LIBELLE As String = GunaDataGridViewAffectationTarifPrix.CurrentRow.Cells("LIBELLE TARIF").Value.ToString

        Dim dialog As DialogResult
        dialog = MessageBox.Show("Voulez-vous vraiment Supprimer l'affectation de tarif " & LIBELLE & " ?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else

            Functions.DeleteRowFromDataGrid(GunaDataGridViewAffectationTarifPrix, ID_TARIF_PRIX, "tarif_prix", "ID_TARIF")

            tarifPrixList()

            MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If


    End Sub

    Private Sub GunaCheckBoxIndividuel_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDynamique.Click

        'GESTION DE LA TARIFICATION DYNAMIQUE
        If GunaCheckBoxDynamique.Checked Then

            GunaComboBoxTarificationDynamique.Visible = True
            GunaButtonEnregistrer.Visible = False

            GunaTextBoxPrix1.Enabled = False
            GunaTextBoxPrix2.Enabled = False
            GunaTextBoxPrix3.Enabled = False
            GunaTextBoxPrix4.Enabled = False
            GunaTextBoxPrix5.Enabled = False

        Else

            'GESTION DE LA TARIFICATION INDIVIDUEL OU ENTREPRISE
            GunaComboBoxTarificationDynamique.Visible = False
            GunaButtonEnregistrer.Visible = True

            GunaTextBoxPrix1.Enabled = True
            GunaTextBoxPrix2.Enabled = True
            GunaTextBoxPrix3.Enabled = True
            GunaTextBoxPrix4.Enabled = True
            GunaTextBoxPrix5.Enabled = True

        End If

        tarifPrixList()
        GunaLabel20.Visible = True
        GunaComboBoxTarificationDynamique.SelectedIndex = -1

    End Sub

    Private Sub GunaComboBoxCodeTarif_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCodeTarif.SelectedIndexChanged
        GunaTextBoxPrix1.Text = 0
        GunaTextBoxPrix2.Text = 0
        GunaTextBoxPrix3.Text = 0
        GunaTextBoxPrix4.Text = 0
        GunaTextBoxPrix5.Text = 0
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If DataGridViewListeDesTarifs.Rows.Count > 0 Then

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supprimer ce tarif ", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                'Dim isSelected As Boolean = Convert.ToBoolean(DataGridViewListeDesTarifs.CurrentRow.Cells("CODE TARIF").Value.ToString)

                If True Then

                    Dim CODE_TARIF = DataGridViewListeDesTarifs.CurrentRow.Cells("CODE TARIF").Value.ToString

                    Functions.DeleteRowFromDataGridGeneral(DataGridViewListeDesTarifs, CODE_TARIF, "tarif", "CODE_TARIF")

                    MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    tarifList()

                Else
                    MessageBox.Show("Bien vouloir sélectionner un tarif ", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        Else

            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If


    End Sub


End Class