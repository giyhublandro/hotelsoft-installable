Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class MainwindoMarketinngForm
    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Functions.ClosingOpenedConnection()
        Functions.exitApplicationThread()
    End Sub

    Private Sub MainwindoMarketinngForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaLabel38.Text = GlobalVariable.DateDeTravail

        Dim language As New Languages()
        language.marketing(GlobalVariable.actualLanguageValue)

        'TITRE DE LA FENETRE
        If GlobalVariable.softwareVersion = "barcleshsoftdbdemo" Then
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") + " (DEMO) "

        ElseIf GlobalVariable.softwareVersion = "barcleshsoftdb" Then
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        End If

        GunaLabel38.Text = GlobalVariable.DateDeTravail
        GunaLabelTemps.Text = Now().ToLongTimeString()

        Dim typeDeMembre As DataTable = Functions.allTableFieldsOrganised("club_elite_membre", "ID_CLUB_ELITE_MEMBRE")

        If typeDeMembre.Rows.Count > 0 Then

            GunaComboBoxEliteClub.DataSource = typeDeMembre
            GunaComboBoxEliteClub.DisplayMember = "MEMBRE"
            GunaComboBoxEliteClub.ValueMember = "MEMBRE"

        End If

        GunaComboBoxEliteClub.SelectedIndex = 0

        GunaDateTimePickerParDateDbut.Value = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail)
        GunaDateTimePickerDateFin.Value = GlobalVariable.DateDeTravail

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GunaLabelTemps.Text = Now().ToLongTimeString()
    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub GunaAdvenceButton6_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton6.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub GunaButtonAfficherClient_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherClient.Click
        clientList()
    End Sub

    Public Sub clientList()

        Dim query As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            query = "SELECT CODE_CLIENT AS 'CODE CLIENT', NOM_PRENOM AS 'NOM & PRENOM', EMAIL AS 'E-MAIL', TELEPHONE , NUM_COMPTE AS 'NUMERO DE COMPTE',  NATIONALITE, PROFESSION , CODE_ELITE AS 'CODE ELITE' FROM client WHERE CODE_AGENCE=@CODE_AGENCE ORDER BY NOM_PRENOM ASC"
        ElseIf GlobalVariable.actualLanguageValue = 0 Then
            query = "SELECT CODE_CLIENT AS 'CODE CLIENT', NOM_PRENOM AS 'NAME', EMAIL AS 'E-MAIL', TELEPHONE , NUM_COMPTE AS 'ACCOUNT',  NATIONALITE AS 'NATIONALITY', PROFESSION, CODE_ELITE AS 'ELITE CODE' FROM client WHERE CODE_AGENCE=@CODE_AGENCE ORDER BY NOM_PRENOM ASC"
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewClient.DataSource = table
            GunaLabelNombreClient.Text = "( " & table.Rows.Count & " )"
        Else
            GunaDataGridViewClient.Columns.Clear()
            GunaLabelNombreClient.Text = "( 0 )"
        End If

        GunaDataGridViewClient.Columns(0).Visible = False
        GunaDataGridViewClient.Columns(4).Visible = False
        GunaDataGridViewClient.Columns(5).Visible = False

        GunaTextBoxRefClient.Clear()

    End Sub

    Private Sub GunaTextBoxRefClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefClient.TextChanged

        If Not Trim(GunaTextBoxRefClient.Text).Equals("") Then

            Dim query As String = ""
            Dim valeurARechercher As String = GunaTextBoxRefClient.Text

            If GlobalVariable.actualLanguageValue = 1 Then
                query = "SELECT CODE_CLIENT AS 'CODE CLIENT', NOM_PRENOM AS 'NOM & PRENOM', EMAIL AS 'E-MAIL', TELEPHONE , NUM_COMPTE AS 'NUMERO DE COMPTE',  NATIONALITE, PROFESSION, CODE_ELITE AS 'CODE ELITE' 
                FROM client
                WHERE CODE_CLIENT LIKE '%" & valeurARechercher & "%' OR NOM_PRENOM LIKE '%" & valeurARechercher & "%' OR EMAIL LIKE '%" & valeurARechercher & "%' OR CODE_ELITE LIKE '%" & valeurARechercher & "%'
                ORDER BY NOM_PRENOM ASC"
            ElseIf GlobalVariable.actualLanguageValue = 0 Then
                query = "SELECT CODE_CLIENT AS 'CODE CLIENT', NOM_PRENOM AS 'NAME', EMAIL AS 'E-MAIL', TELEPHONE , NUM_COMPTE AS 'ACCOUNT',  NATIONALITE AS 'NATIONALITY', PROFESSION, CODE_ELITE AS 'ELITE CODE' 
                FROM client 
                WHERE CODE_CLIENT LIKE '%" & valeurARechercher & "%' OR NOM_PRENOM LIKE '%" & valeurARechercher & "%' OR EMAIL LIKE '%" & valeurARechercher & "%' OR CODE_ELITE LIKE '%" & valeurARechercher & "%'
                ORDER BY NOM_PRENOM ASC"
            End If

            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                GunaDataGridViewClient.DataSource = table
                GunaLabelNombreClient.Text = "( " & table.Rows.Count & " )"

                GunaDataGridViewClient.Columns(0).Visible = False
                GunaDataGridViewClient.Columns(4).Visible = False
                GunaDataGridViewClient.Columns(5).Visible = False
            Else
                GunaDataGridViewClient.Columns.Clear()
                GunaLabelNombreClient.Text = "( 0 )"
            End If
        End If

    End Sub

    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        TabControl1.SelectedIndex = 2
    End Sub

    Dim title As String = ""
    Dim Message As String = ""

    Private Sub GunaButtonCreateEliteCarte_Click(sender As Object, e As EventArgs) Handles GunaButtonCreateEliteCarte.Click

        'CREATION DES CARTES DE MEMBRE

        If Not Trim(GunaTextBoxIdCarteMembre.Text).Equals("") And Not Trim(GunaTextBoxCodeClientCarte.Text).Equals("") Then

            Dim TYPE_MEMBRE As String = GunaComboBoxEliteClub.SelectedValue.ToString
            Dim ID_CARTE_ELITE As String = Trim(GunaTextBoxIdCarteMembre.Text)
            Dim ID_CARTE_ELITE_OLD As String = Trim(GunaTextBoxOldIdCarte.Text)
            Dim NOM_CLIENT_CARTE As String = GunaTextBoxNomClientCarte.Text
            Dim CODE_CLIENT_CARTE As String = Trim(GunaTextBoxCodeClientCarte.Text)

            Dim exist As DataTable = Functions.GetAllElementsOnCondition(CODE_CLIENT_CARTE, "club_elite_membre_client", "CODE_CLIENT_CARTE")

            Dim elite As New ClubElite()

            If (exist.Rows.Count > 0) And (GunaButtonCreateEliteCarte.Text = "Créer" Or GunaButtonCreateEliteCarte.Text = "Create") Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    Message = "Impossible de créer la Carte Elite, ce client a déjà une Carte Elite."
                    title = "Gestion Des Cartes Elites"
                Else
                    Message = "Impossible to create the Elite Card, This user already have one."
                    title = "Elite Card Management"
                End If

                MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                exist = Functions.GetAllElementsOnCondition(ID_CARTE_ELITE, "club_elite_membre_client", "ID_CARTE_ELITE")

                If (exist.Rows.Count > 0) And (GunaButtonCreateEliteCarte.Text = "Créer" Or GunaButtonCreateEliteCarte.Text = "Create") Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        Message = "Impossible de créer la Carte Elite, cette carte est déjà attribuée."
                        title = "Gestion Des Cartes Elites"
                    Else
                        Message = "Impossible to create the Elite Card, this Card is already used."
                        title = "Elite Card Management"
                    End If

                    MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else

                    If GunaButtonCreateEliteCarte.Text = "Créer" Or GunaButtonCreateEliteCarte.Text = "Create" Then

                        elite.affectationElite(TYPE_MEMBRE, CODE_CLIENT_CARTE, ID_CARTE_ELITE)

                        If GlobalVariable.actualLanguageValue = 1 Then
                            Message = "Carte Elite Crée avec succès"
                            title = "Gestion Des Cartes Elites"
                        Else
                            Message = "Elite Carte Successfully Created"
                            title = "Elite Card Management"
                        End If

                        MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        elite.updateAffectationElite(TYPE_MEMBRE, CODE_CLIENT_CARTE, ID_CARTE_ELITE, ID_CARTE_ELITE_OLD)

                        If GlobalVariable.actualLanguageValue = 1 Then
                            Message = "Carte Elite Mise à jour avec succès"
                            title = "Gestion Des Cartes Elites"
                        Else
                            Message = "Elite Carte Successfully updated"
                            title = "Elite Card Management"
                        End If

                        If GlobalVariable.actualLanguageValue = 1 Then
                            GunaButtonCreateEliteCarte.Text = "Enregistrer"
                        Else
                            GunaButtonCreateEliteCarte.Text = "Save"
                        End If

                        MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    Functions.updateOfFields("client", "CODE_ELITE", ID_CARTE_ELITE, "CODE_CLIENT", CODE_CLIENT_CARTE, 2)

                End If

                GunaDataGridViewCodeEliteMembre.DataSource = Nothing

                Dim UPGRADE As Integer = 0
                'listEliteCode(UPGRADE, GunaDataGridViewToUpgrade)

                GunaTextBoxCodeClientCarte.Text = ""
                GunaTextBoxNomClientCarte.Text = ""
                GunaTextBoxIdCarteMembre.Text = ""
                GunaTextBoxOldIdCarte.Text = ""

            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                Message = "Bien vouloir Remplir tous les champs"
                title = "Gestion Des Cartes Elites"
            Else
                Message = "Please Fill all the fields"
                title = "Elite Card Management"
            End If

            MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub


    Private Sub listEliteCode(ByVal UPGRADE As Integer, ByVal dt As DataGridView)

        Dim elite As New ClubElite()
        elite.list(dt, UPGRADE)

        If UPGRADE = 0 Then

            If GunaDataGridViewCodeEliteMembre.Rows.Count > 0 Then
                GunaDataGridViewCodeEliteMembre.Columns(6).Visible = False
                GunaLabel46.Text = "(" & dt.Rows.Count & ")"
            Else
                GunaLabel46.Text = "(" & 0 & ")"
            End If

        ElseIf UPGRADE = 1 Then

            ' If GunaDataGridViewToUpgrade.Rows.Count > 0 Then

            'GunaDataGridViewToUpgrade.Columns(6).Visible = False
            'GunaLabel48.Text = "(" & dt.Rows.Count & ")"

            'Else
            'GunaLabel48.Text = "(" & 0 & ")"
            'End If

        End If

    End Sub

    Private Sub GunaTextBoxNomClientCarte_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNomClientCarte.TextChanged

        If Trim(GunaTextBoxNomClientCarte.Text).Equals("") Then
            GunaDataGridView1.Visible = False
            GunaTextBoxCodeClientCarte.Clear()
        Else
            GunaDataGridView1.Visible = True
        End If

        Dim query As String = "SELECT NOM_PRENOM, CODE_CLIENT From client WHERE NOM_PRENOM LIKE '%" & GunaTextBoxNomClientCarte.Text & "%' AND CODE_ELITE=@CODE_ELITE"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = ""

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridView1.DataSource = table
        Else
            GunaDataGridView1.Columns.Clear()
            GunaDataGridView1.Visible = False
        End If

        If GunaTextBoxNomClientCarte.Text.Trim().Equals("") Then
            GunaDataGridView1.Columns.Clear()
            GunaDataGridView1.Visible = False
        End If

    End Sub

    Private Sub GunaTextBoxLike_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxLike.TextChanged
        Dim UPGRADE As Integer = 0
        Dim elite As New ClubElite()
        Dim id_carte_nom_client As String = GunaTextBoxLike.Text
        elite.list(GunaDataGridViewCodeEliteMembre, UPGRADE, id_carte_nom_client)
        If GunaDataGridViewCodeEliteMembre.Rows.Count > 0 Then
            GunaLabel46.Text = "(" & GunaDataGridViewCodeEliteMembre.Rows.Count & ")"
            GunaDataGridViewCodeEliteMembre.Columns(6).Visible = False
        Else
            GunaLabel46.Text = "(" & 0 & ")"
        End If
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        Dim UPGRADE As Integer = 0

        GunaTextBoxLike.Clear()
        listEliteCode(UPGRADE, GunaDataGridViewCodeEliteMembre)
    End Sub

    Private Sub GunaDataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridView1.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridView1.Rows(e.RowIndex)

            Dim CodeClient As String = row.Cells("CODE_CLIENT").Value.ToString()

            'On rempli la description du client pour des eventuelles modifications

            Dim client As DataTable = Functions.getElementByCode(CodeClient, "client", "CODE_CLIENT")

            GunaTextBoxCodeClientCarte.Text = client.Rows(0)("CODE_CLIENT")
            GunaTextBoxNomClientCarte.Text = client.Rows(0)("NOM_PRENOM")

            GunaDataGridView1.Visible = False

        End If

    End Sub

    Private Sub GunaDataGridViewCodeEliteMembre_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewCodeEliteMembre.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewCodeEliteMembre.Rows(e.RowIndex)

            GunaTextBoxIdCarteMembre.Text = row.Cells(2).Value.ToString()
            Dim CODE_CLIENT As String = row.Cells(6).Value.ToString()

            Dim infoSupClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

            If infoSupClient.Rows.Count > 0 Then
                GunaTextBoxNomClientCarte.Text = infoSupClient.Rows(0)("NOM_PRENOM")
            End If

            GunaTextBoxCodeClientCarte.Text = row.Cells(6).Value.ToString()
            GunaTextBoxOldIdCarte.Text = row.Cells(2).Value.ToString()
            GunaComboBoxEliteClub.SelectedValue = row.Cells(0).Value.ToString()

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonCreateEliteCarte.Text = "Sauvegarder"
            Else
                GunaButtonCreateEliteCarte.Text = "Update"
            End If

            GunaDataGridView1.Visible = False

        End If


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        GunaDataGridViewHistoriquesDesPoints.DataSource = Nothing

        If GunaDataGridViewCodeEliteMembre.CurrentRow.Selected Then

            Dim CODE_ELITE As String = GunaDataGridViewCodeEliteMembre.CurrentRow.Cells(2).Value.ToString()
            Dim CODE_CLIENT As String = GunaDataGridViewCodeEliteMembre.CurrentRow.Cells(6).Value.ToString()

            Dim elite As New ClubElite()

            Dim dt As DataTable = elite.historiquesAccummulationDesPoints(CODE_ELITE, CODE_CLIENT)

            If dt.Rows.Count > 0 Then
                GunaDataGridViewHistoriquesDesPoints.DataSource = dt
            End If

        End If

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs)

    End Sub
End Class