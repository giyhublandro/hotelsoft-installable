Imports MySql.Data.MySqlClient

Public Class BlanchisseurForm
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BlanchisseurForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AffichagePrestataire()

        autoload()

        prestataireEnvoie()

        prestataireReception()

        GunaDateTimePickerFrom.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerTo.Value = GlobalVariable.DateDeTravail

        GunaComboBoxTypeDoc.SelectedIndex = 0

    End Sub


    Public Sub AffichagePrestataire()
        '
        Dim query As String = "SELECT `CODE_FOURNISSEUR`, `NOM_FOURNISSEUR`, `PRIX` FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR AND PRIX > 0 ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            For i = 0 To table.Rows.Count - 1

                If table.Rows(i)("PRIX") = 1 Then
                    GunaCheckBox1.Checked = True
                    GunaComboBox1.SelectedValue = table.Rows(i)("CODE_FOURNISSEUR")
                End If

                If table.Rows(i)("PRIX") = 2 Then
                    GunaCheckBox2.Checked = True
                    GunaComboBox2.SelectedValue = table.Rows(i)("CODE_FOURNISSEUR")
                End If

                If table.Rows(i)("PRIX") = 3 Then
                    GunaCheckBox3.Checked = True
                    GunaComboBox3.SelectedValue = table.Rows(i)("CODE_FOURNISSEUR")
                End If

                If table.Rows(i)("PRIX") = 4 Then
                    GunaCheckBox4.Checked = True
                    GunaComboBox4.SelectedValue = table.Rows(i)("CODE_FOURNISSEUR")
                End If

            Next

        End If

    End Sub

    Public Sub wating()

        Dim query As String = "SELECT CODE_ARTICLE, DESIGNATION_FR AS LINGE, PRIX_VENTE6_HT AS 'PRIX 1', PRIX_VENTE7_HT AS 'PRIX 2', PRIX_VENTE8_HT AS 'PRIX 3', PRIX_VENTE9_HT AS 'PRIX 4' FROM article WHERE TYPE=@TYPE AND CODE_FAMILLE IN ('PRESSING') ORDER BY DESIGNATION_FR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "matiere"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewLinges.DataSource = Nothing

            DataGridViewLinges.DataSource = table
            DataGridViewLinges.Columns(0).Visible = False
            DataGridViewLinges.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridViewLinges.Columns(2).DefaultCellStyle.Format = "#,##0"
            DataGridViewLinges.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewLinges.Columns(3).DefaultCellStyle.Format = "#,##0"
            DataGridViewLinges.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewLinges.Columns(4).DefaultCellStyle.Format = "#,##0"
            DataGridViewLinges.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DataGridViewLinges.Columns(5).DefaultCellStyle.Format = "#,##0"
            DataGridViewLinges.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If

    End Sub


    Public Sub linges(ByVal CODE_FOURNISSEUR As String, ByVal fournisseur As DataTable)

        Dim query As String = "SELECT CODE_ARTICLE, DESIGNATION_FR AS LINGE, PRIX_VENTE6_HT AS 'PRIX 1', PRIX_VENTE7_HT AS 'PRIX 2', PRIX_VENTE8_HT AS 'PRIX 3', PRIX_VENTE9_HT AS 'PRIX 4' FROM article WHERE TYPE=@TYPE AND CODE_FAMILLE IN ('PRESSING') ORDER BY DESIGNATION_FR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "matiere"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        DataGridViewLinges.Rows.Clear()

        If (table.Rows.Count > 0) Then

            Dim PRIX As Integer = 0

            If fournisseur.Rows.Count > 0 Then
                PRIX = fournisseur.Rows(0)("PRIX")
            End If

            For i = 0 To table.Rows.Count - 1
                If PRIX = 1 Then
                    DataGridViewLinges.Rows.Add(table.Rows(i)("CODE_ARTICLE"), table.Rows(i)("LINGE"), table.Rows(i)("PRIX 1"))
                ElseIf PRIX = 2 Then
                    DataGridViewLinges.Rows.Add(table.Rows(i)("CODE_ARTICLE"), table.Rows(i)("LINGE"), table.Rows(i)("PRIX 2"))
                ElseIf PRIX = 3 Then
                    DataGridViewLinges.Rows.Add(table.Rows(i)("CODE_ARTICLE"), table.Rows(i)("LINGE"), table.Rows(i)("PRIX 3"))
                ElseIf PRIX = 4 Then
                    DataGridViewLinges.Rows.Add(table.Rows(i)("CODE_ARTICLE"), table.Rows(i)("LINGE"), table.Rows(i)("PRIX 4"))
                End If
            Next

            DataGridViewLinges.Columns(0).Visible = False
            DataGridViewLinges.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridViewLinges.Columns(2).DefaultCellStyle.Format = "#,##0"
            DataGridViewLinges.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If

    End Sub

    Public Sub autoload()

        Dim query As String = "SELECT `CODE_FOURNISSEUR`, `NOM_FOURNISSEUR` FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR AND PRIX > 0 ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxPrestataire.DataSource = table
            GunaComboBoxPrestataire.ValueMember = "CODE_FOURNISSEUR"
            GunaComboBoxPrestataire.DisplayMember = "NOM_FOURNISSEUR"

        End If

    End Sub

    Public Sub prestataireEnvoie()

        Dim query As String = "SELECT `CODE_FOURNISSEUR`, `NOM_FOURNISSEUR` FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR AND PRIX > 0 ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxPrestaireEnvoie.DataSource = table
            GunaComboBoxPrestaireEnvoie.ValueMember = "CODE_FOURNISSEUR"
            GunaComboBoxPrestaireEnvoie.DisplayMember = "NOM_FOURNISSEUR"

        End If

    End Sub

    Public Sub prestataireReception()

        Dim query As String = "SELECT `CODE_FOURNISSEUR`, `NOM_FOURNISSEUR` FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR AND PRIX > 0 ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxPrestaireReception.DataSource = table
            GunaComboBoxPrestaireReception.ValueMember = "CODE_FOURNISSEUR"
            GunaComboBoxPrestaireReception.DisplayMember = "NOM_FOURNISSEUR"

        End If

    End Sub

    Public Sub autoload_1()

        Dim query As String = "SELECT `CODE_FOURNISSEUR`, `NOM_FOURNISSEUR` FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            If GunaCheckBox1.Checked Then
                GunaComboBox1.DataSource = table
                GunaComboBox1.ValueMember = "CODE_FOURNISSEUR"
                GunaComboBox1.DisplayMember = "NOM_FOURNISSEUR"
            Else
                GunaComboBox1.DataSource = Nothing
            End If

        End If

    End Sub


    Public Sub autoload_2()

        Dim query As String = "SELECT `CODE_FOURNISSEUR`, `NOM_FOURNISSEUR` FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            If GunaCheckBox2.Checked Then
                GunaComboBox2.DataSource = table
                GunaComboBox2.ValueMember = "CODE_FOURNISSEUR"
                GunaComboBox2.DisplayMember = "NOM_FOURNISSEUR"
            Else
                GunaComboBox2.DataSource = Nothing
            End If

        End If

    End Sub

    Public Sub autoload_3()

        Dim query As String = "SELECT `CODE_FOURNISSEUR`, `NOM_FOURNISSEUR` FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            If GunaCheckBox3.Checked Then
                GunaComboBox3.DataSource = table
                GunaComboBox3.ValueMember = "CODE_FOURNISSEUR"
                GunaComboBox3.DisplayMember = "NOM_FOURNISSEUR"
            Else
                GunaComboBox3.DataSource = Nothing
            End If

        End If

    End Sub

    Public Sub autoload_4()

        Dim query As String = "SELECT `CODE_FOURNISSEUR`, `NOM_FOURNISSEUR` FROM `fournisseur` WHERE BLANCHISSEUR=@BLANCHISSEUR ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@BLANCHISSEUR", MySqlDbType.Int64).Value = 1

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            If GunaCheckBox4.Checked Then
                GunaComboBox4.DataSource = table
                GunaComboBox4.ValueMember = "CODE_FOURNISSEUR"
                GunaComboBox4.DisplayMember = "NOM_FOURNISSEUR"
            Else
                GunaComboBox4.DataSource = Nothing
            End If

        End If

    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged
        autoload_1()
    End Sub

    Private Sub GunaCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox2.CheckedChanged
        autoload_2()
    End Sub

    Private Sub GunaCheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox3.CheckedChanged
        autoload_3()
    End Sub

    Private Sub GunaCheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox4.CheckedChanged
        autoload_4()
    End Sub

    Private Sub GunaButtonGrilleTarrifaire_Click(sender As Object, e As EventArgs) Handles GunaButtonGrilleTarrifaire.Click

        Dim PRIX As Integer = 0
        Dim updateQuery As String = "UPDATE `fournisseur` SET `PRIX` = @PRIX WHERE PRIX > 0"

        Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)
        commandupdateQuery.Parameters.Add("@PRIX", MySqlDbType.Int64).Value = PRIX

        commandupdateQuery.ExecuteNonQuery()

        Dim CODE_FOURNISSEUR As String = ""

        Dim message As String = ""
        Dim title As String = ""

        If GunaCheckBox1.Checked Then
            CODE_FOURNISSEUR = GunaComboBox1.SelectedValue.ToString
            PRIX = 1 'PRI_VENTE6
        End If

        Functions.updateOfFields("fournisseur", "PRIX", PRIX, "CODE_FOURNISSEUR", CODE_FOURNISSEUR, 1)
        PRIX = 0
        CODE_FOURNISSEUR = ""

        If GunaCheckBox2.Checked Then
            CODE_FOURNISSEUR = GunaComboBox2.SelectedValue.ToString
            PRIX = 2 'PRI_VENTE7
        End If
        Functions.updateOfFields("fournisseur", "PRIX", PRIX, "CODE_FOURNISSEUR", CODE_FOURNISSEUR, 1)
        PRIX = 0
        CODE_FOURNISSEUR = ""


        If GunaCheckBox3.Checked Then
            CODE_FOURNISSEUR = GunaComboBox3.SelectedValue.ToString
            PRIX = 3 'PRI_VENTE8
        End If

        Functions.updateOfFields("fournisseur", "PRIX", PRIX, "CODE_FOURNISSEUR", CODE_FOURNISSEUR, 1)
        PRIX = 0
        CODE_FOURNISSEUR = ""

        If GunaCheckBox4.Checked Then
            CODE_FOURNISSEUR = GunaComboBox4.SelectedValue.ToString
            PRIX = 4 'PRI_VENTE9
        End If
        Functions.updateOfFields("fournisseur", "PRIX", PRIX, "CODE_FOURNISSEUR", CODE_FOURNISSEUR, 1)

        If GlobalVariable.actualLanguageValue = 0 Then
            message = "Prix mise à jour avec succès"
            title = "Price"
        Else
            title = "Prix"
            message = "Price successfully updated"
        End If

        autoload()

        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub DataGridViewLinges_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewLinges.CellEndEdit

        Dim CODE_ARTCICLE As String = DataGridViewLinges.CurrentRow.Cells(0).Value.ToString()
        Dim MONTANT As Double = 0

        If Not Trim(DataGridViewLinges.CurrentRow.Cells(2).Value.ToString).Equals("") Then
            MONTANT = DataGridViewLinges.CurrentRow.Cells(2).Value
        End If

        If GunaComboBoxPrestataire.SelectedIndex >= 0 Then

            Dim CODE_FOURNISSEUR As String = GunaComboBoxPrestataire.SelectedValue.ToString
            Dim fournisseur As DataTable = Functions.getElementByCode(CODE_FOURNISSEUR, "fournisseur", "CODE_FOURNISSEUR")

            Dim PRIX As Integer = 0

            If fournisseur.Rows.Count > 0 Then
                PRIX = fournisseur.Rows(0)("PRIX")
            End If

            If PRIX = 1 Then
                If MONTANT > 0 Then
                    Functions.updateOfFields("article", "PRIX_VENTE6_HT", MONTANT, "CODE_ARTICLE", CODE_ARTCICLE, 1)
                End If
            ElseIf PRIX = 2 Then
                If MONTANT > 0 Then
                    Functions.updateOfFields("article", "PRIX_VENTE7_HT", MONTANT, "CODE_ARTICLE", CODE_ARTCICLE, 1)
                End If

            ElseIf PRIX = 3 Then
                If MONTANT > 0 Then
                    Functions.updateOfFields("article", "PRIX_VENTE8_HT", MONTANT, "CODE_ARTICLE", CODE_ARTCICLE, 1)
                End If
            ElseIf PRIX = 4 Then
                If MONTANT > 0 Then
                    Functions.updateOfFields("article", "PRIX_VENTE9_HT", MONTANT, "CODE_ARTICLE", CODE_ARTCICLE, 1)
                End If
            End If

        End If

    End Sub

    Private Sub GunaComboBoxPrestataire_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxPrestataire.SelectedIndexChanged

        If GunaComboBoxPrestataire.SelectedIndex >= 0 Then

            Dim CODE_FOURNISSEUR As String = GunaComboBoxPrestataire.SelectedValue.ToString
            Dim fournisseur As DataTable = Functions.getElementByCode(CODE_FOURNISSEUR, "fournisseur", "CODE_FOURNISSEUR")

            linges(CODE_FOURNISSEUR, fournisseur)

        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        Dim serviceEtage As New ServicesEtage()

        Dim CODE_ARTICLE As String = ""
        Dim PRIX_UNITAIRE As Double = 0
        Dim QUANTITE As Integer = 0
        Dim MONTANT_TOTAL As Double = 0
        Dim LINGE As String = ""
        Dim CODE_LAVAGE As String = Functions.GeneratingRandomCode("envoie_lavage_linge", "")
        Dim MONTANT As Double = 0
        Dim OBSERVATION As String = GunaTextBoxObservation.Text

        For i = 0 To GunaDataGridView1.Rows.Count - 1

            CODE_ARTICLE = GunaDataGridView1.Rows(i).Cells(1).Value.ToString
            PRIX_UNITAIRE = GunaDataGridView1.Rows(i).Cells(4).Value
            QUANTITE = GunaDataGridView1.Rows(i).Cells(3).Value
            MONTANT_TOTAL = GunaDataGridView1.Rows(i).Cells(5).Value
            LINGE = GunaDataGridView1.Rows(i).Cells(2).Value.ToString

            serviceEtage.envoie_lavage_linge_ligne(CODE_ARTICLE, PRIX_UNITAIRE, QUANTITE, MONTANT_TOTAL, CODE_LAVAGE, LINGE)
            MONTANT += MONTANT_TOTAL

        Next

        Dim INTITULE As String = GunaTextBoxIntitule.Text

        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_FOURNISSEUR As String = GunaComboBoxPrestaireEnvoie.SelectedValue.ToString
        Dim ENVOI As Integer = 0

        serviceEtage.insert_lavage(INTITULE, MONTANT, CODE_LAVAGE, DATE_CREATION, OBSERVATION, CODE_FOURNISSEUR, ENVOI)

        GunaTextBoxObservation.Clear()
        GunaTextBoxIntitule.Clear()
        GunaDataGridView1.Rows.Clear()

        clearField()

        Dim Message As String = ""
        Dim title As String = ""
        If GlobalVariable.actualLanguageValue = 0 Then
            Message = "Document successfully created"
            title = "Envoi"
        Else
            title = "Send"
            Message = "Document crée avec succès"
        End If

        MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub GunaTextBoxArticle_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxArticle.TextChanged

        If Trim(GunaTextBoxArticle.Text).Equals("") Then
            GunaDataGridViewLinge.Visible = False
            GunaButtonAjouterLigne.Visible = False
            clearField()
        Else

            Dim query As String = "SELECT CODE_ARTICLE, DESIGNATION_FR AS LINGE FROM article WHERE TYPE=@TYPE AND CODE_FAMILLE IN ('PRESSING') AND DESIGNATION_FR LIKE '%" & GunaTextBoxArticle.Text & "%' ORDER BY DESIGNATION_FR ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "matiere"

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            GunaDataGridViewLinge.DataSource = Nothing

            If table.Rows.Count > 0 Then
                GunaDataGridViewLinge.Visible = True
                GunaDataGridViewLinge.DataSource = table
                GunaDataGridViewLinge.Columns(0).Visible = False
            Else
                GunaDataGridViewLinge.Visible = False
            End If

        End If

    End Sub

    Private Sub GunaDataGridViewLinge_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLinge.CellClick

        GunaDataGridViewLinge.Visible = False

        If e.RowIndex >= 0 Then

            GunaTextBoxQuantite.Text = 1

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewLinge.Rows(e.RowIndex)

            Dim query As String = "SELECT * FROM article WHERE CODE_ARTICLE=@CODE_ARTICLE ORDER BY DESIGNATION_FR ASC"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = row.Cells("CODE_ARTICLE").Value.ToString

            Dim adapter As New MySqlDataAdapter
            Dim linge As New DataTable

            adapter.SelectCommand = command
            adapter.Fill(linge)

            If linge.Rows.Count > 0 Then

                GunaTextBoxArticle.Text = linge.Rows(0)("DESIGNATION_FR")
                GunaTextBoxCodeArticle.Text = linge.Rows(0)("CODE_ARTICLE")

                Dim MONTANT As Double = 0

                If GunaComboBoxPrestaireEnvoie.SelectedIndex >= 0 Then

                    Dim CODE_FOURNISSEUR As String = GunaComboBoxPrestaireEnvoie.SelectedValue.ToString
                    Dim fournisseur As DataTable = Functions.getElementByCode(CODE_FOURNISSEUR, "fournisseur", "CODE_FOURNISSEUR")

                    Dim PRIX As Integer = 0

                    If fournisseur.Rows.Count > 0 Then
                        PRIX = fournisseur.Rows(0)("PRIX")
                    End If

                    If PRIX = 1 Then
                        MONTANT = linge.Rows(0)("PRIX_VENTE6_HT")
                    ElseIf PRIX = 2 Then
                        MONTANT = linge.Rows(0)("PRIX_VENTE7_HT")
                    ElseIf PRIX = 3 Then
                        MONTANT = linge.Rows(0)("PRIX_VENTE8_HT")
                    ElseIf PRIX = 4 Then
                        MONTANT = linge.Rows(0)("PRIX_VENTE9_HT")
                    End If

                    GunaTextBoxCout.Text = MONTANT
                    GunaButtonAjouterLigne.Visible = True

                End If

            End If

        End If

        GunaDataGridViewLinge.Visible = False

    End Sub

    Private Sub GunaTextBox2_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxIntitule.TextChanged

        If Trim(GunaTextBoxIntitule.Text).Equals("") Then
            GunaButton1.Visible = False
        Else
            GunaButton1.Visible = True
        End If

    End Sub

    Private Sub GunaComboBoxPrestaireEnvoie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxPrestaireEnvoie.SelectedIndexChanged
        clearField()
    End Sub

    Public Sub clearField()
        GunaTextBoxArticle.Clear()
        GunaTextBoxCodeArticle.Clear()
        GunaTextBoxQuantite.Text = 1
        GunaTextBoxCout.Text = 0
    End Sub

    Private Sub GunaButtonAjouterLigne_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterLigne.Click


        Dim CODE_ARTICLE As String = GunaTextBoxCodeArticle.Text
        Dim PRIX_UNITAIRE As Double = GunaTextBoxCout.Text
        Dim QUANTITE As Integer = GunaTextBoxQuantite.Text
        Dim LINGE As String = Trim(GunaTextBoxArticle.Text)
        Dim MONTANT_TOTAL As Double = PRIX_UNITAIRE * QUANTITE
        Dim CODE_LAVAGE As String = Functions.GeneratingRandomCode("envoie_lavage_linge", "")
        Dim ID_LAVAGE_LIGNE As String = ""

        Dim GRAND_TOTAL As Double = 0

        GunaDataGridView1.Rows.Add(ID_LAVAGE_LIGNE, CODE_ARTICLE, LINGE, QUANTITE, PRIX_UNITAIRE, MONTANT_TOTAL, CODE_LAVAGE)

        For i = 0 To GunaDataGridView1.Rows.Count - 1
            GRAND_TOTAL = GunaDataGridView1.Rows(i).Cells(5).Value
        Next

        GunaTextBoxMontantTotal.Text = Format(GRAND_TOTAL, "#,##0")

        clearField()

    End Sub

    Private Sub GunaButtonAfficherValidee_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherValidee.Click

        Dim date_debut As Date = GunaDateTimePickerFrom.Value.ToShortDateString
        Dim date_fin As Date = GunaDateTimePickerTo.Value.ToShortDateString

        listeDesReceptionEnvoies(date_debut, date_fin)

    End Sub

    Public Sub listeDesReceptionEnvoies(ByVal date_debut As Date, ByVal date_fin As Date)

        Dim ENVOI As Integer = GunaComboBoxTypeDoc.SelectedIndex

        Dim query As String = "SELECT `ID_ENVOIE_LAVAGE_LINGE`, `INTITULE`, `MONTANT`, `CODE_LAVAGE`, `OBSERVATION`, `NOM_FOURNISSEUR` AS PRESTATAIRE, envoie_lavage_linge.DATE_DE_CONTROLE 
        FROM envoie_lavage_linge, fournisseur WHERE envoie_lavage_linge.DATE_CREATION  >= '" & date_debut.ToString("yyyy-MM-dd") & "' AND 
        envoie_lavage_linge.DATE_CREATION <='" & date_fin.ToString("yyyy-MM-dd") & "' AND ENVOI=@ENVOI AND envoie_lavage_linge.CODE_FOURNISSEUR = fournisseur.CODE_FOURNISSEUR "

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@ENVOI", MySqlDbType.Int64).Value = ENVOI
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        DataGridViewReceptionEnvoie.DataSource = Nothing

        If table.Rows.Count > 0 Then

            DataGridViewReceptionEnvoie.DataSource = table
            DataGridViewReceptionEnvoie.Columns(0).Visible = False
            DataGridViewReceptionEnvoie.Columns(3).Visible = False
            DataGridViewReceptionEnvoie.Columns(2).DefaultCellStyle.Format = "#,##0"
            DataGridViewReceptionEnvoie.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End If

    End Sub

    Private Sub GunaComboBoxTypeDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDoc.SelectedIndexChanged
        DataGridViewReceptionEnvoie.DataSource = Nothing
    End Sub

    Private Sub DataGridViewReceptionEnvoie_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReceptionEnvoie.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.DataGridViewReceptionEnvoie.Rows(e.RowIndex)

            Dim envoie_reception As DataTable = Functions.getElementByCode(row.Cells("ID_ENVOIE_LAVAGE_LINGE").Value, "envoie_lavage_linge", "ID_ENVOIE_LAVAGE_LINGE")

            If envoie_reception.Rows.Count > 0 Then

                Dim CODE_LAVAGE As String = envoie_reception.Rows(0)("CODE_LAVAGE")
                GunaTextBoxObservation.Text = envoie_reception.Rows(0)("OBSERVATION")
                GunaTextBoxIntitule.Text = envoie_reception.Rows(0)("INTITULE")
                GunaComboBoxPrestaireEnvoie.SelectedValue = envoie_reception.Rows(0)("CODE_FOURNISSEUR")
                GunaTextBoxMontantTotal.Text = Format(envoie_reception.Rows(0)("MONTANT"), "#,##0")
                GunaButton1.Visible = False
                GunaTextBoxCodeEnvoieReception.Text = CODE_LAVAGE

                Dim envoie_lavage_linge_ligne As DataTable = Functions.getElementByCode(CODE_LAVAGE, "envoie_lavage_linge_ligne", "CODE_LAVAGE")

                If envoie_lavage_linge_ligne.Rows.Count > 0 Then
                    Dim CODE_ARTICLE As String = ""
                    Dim PRIX_UNITAIRE As Double = 0
                    Dim QUANTITE As Integer = 0
                    Dim MONTANT_TOTAL As Double = 0
                    Dim LINGE As String = ""
                    Dim ID_LAVAGE_LIGNE As String = ""

                    For i = 0 To envoie_lavage_linge_ligne.Rows.Count - 1

                        CODE_ARTICLE = envoie_lavage_linge_ligne.Rows(i)("CODE_ARTICLE")
                        PRIX_UNITAIRE = envoie_lavage_linge_ligne.Rows(i)("PRIX_UNITAIRE")
                        QUANTITE = envoie_lavage_linge_ligne.Rows(i)("QUANTITE")
                        MONTANT_TOTAL = envoie_lavage_linge_ligne.Rows(i)("MONTANT_TOTAL")
                        LINGE = envoie_lavage_linge_ligne.Rows(i)("LINGE")
                        ID_LAVAGE_LIGNE = envoie_lavage_linge_ligne.Rows(i)("ID_LAVAGE_LIGNE")

                        GunaDataGridView1.Rows.Add(ID_LAVAGE_LIGNE, CODE_ARTICLE, LINGE, QUANTITE, PRIX_UNITAIRE, MONTANT_TOTAL, CODE_LAVAGE)

                    Next

                End If

                TabControl1.SelectedIndex = 1

            End If

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 3 Then
            GunaTextBoxObservation.Clear()
            GunaTextBoxIntitule.Clear()
            GunaDataGridView1.Rows.Clear()
            clearField()
        End If

    End Sub

    Private Sub TransférerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceptionnerToolStripMenuItem.Click
        'IMPRIMER
        If DataGridViewReceptionEnvoie.Rows.Count > 0 Then

            Dim row As DataGridViewRow

            Dim ENVOI As Integer = GunaComboBoxTypeDoc.SelectedIndex

            Dim envoie_reception As DataTable = Functions.getElementByCode(DataGridViewReceptionEnvoie.CurrentRow.Cells("ID_ENVOIE_LAVAGE_LINGE").Value.ToString(), "envoie_lavage_linge", "ID_ENVOIE_LAVAGE_LINGE")

            If envoie_reception.Rows.Count > 0 Then

                Dim CODE_LAVAGE As String = envoie_reception.Rows(0)("CODE_LAVAGE")
                Dim INTITULE As String = envoie_reception.Rows(0)("INTITULE")
                Dim dt As DataTable = Functions.getElementByCode(CODE_LAVAGE, "envoie_lavage_linge_ligne", "CODE_LAVAGE")

                Impression.envoie_reception(dt, ENVOI, CODE_LAVAGE, INTITULE)

            End If

        End If

    End Sub

    Private Sub RéceptionnerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RéceptionnerToolStripMenuItem.Click
        'RECEPTIONNER

        If GunaComboBoxTypeDoc.SelectedIndex = 0 Then

            If DataGridViewReceptionEnvoie.Rows.Count > 0 Then

                Dim row As DataGridViewRow

                Dim envoie_reception As DataTable = Functions.getElementByCode(DataGridViewReceptionEnvoie.CurrentRow.Cells("ID_ENVOIE_LAVAGE_LINGE").Value.ToString(), "envoie_lavage_linge", "ID_ENVOIE_LAVAGE_LINGE")

                If envoie_reception.Rows.Count > 0 Then

                    Dim ETAT As Integer = envoie_reception.Rows(0)("ETAT")

                    If ETAT = 0 Then

                        Dim CODE_LAVAGE As String = envoie_reception.Rows(0)("CODE_LAVAGE")
                        'GunaTextBoxObservation.Text = envoie_reception.Rows(0)("OBSERVATION")
                        'GunaTextBoxIntitule.Text = envoie_reception.Rows(0)("INTITULE")
                        GunaComboBoxPrestaireReception.SelectedValue = envoie_reception.Rows(0)("CODE_FOURNISSEUR")
                        GunaComboBoxPrestaireReception.Enabled = False
                        'GunaTextBoxMontantTotal.Text = Format(envoie_reception.Rows(0)("MONTANT"), "#,##0")
                        'GunaButton1.Visible = False
                        GunaTextBoxReference.Text = CODE_LAVAGE

                        Dim envoie_lavage_linge_ligne As DataTable = Functions.getElementByCode(CODE_LAVAGE, "envoie_lavage_linge_ligne", "CODE_LAVAGE")

                        If envoie_lavage_linge_ligne.Rows.Count > 0 Then

                            Dim CODE_ARTICLE As String = ""
                            Dim PRIX_UNITAIRE As Double = 0
                            Dim QUANTITE As Integer = 0
                            Dim MONTANT_TOTAL As Double = 0
                            Dim LINGE As String = ""
                            Dim ID_LAVAGE_LIGNE As String = ""

                            For i = 0 To envoie_lavage_linge_ligne.Rows.Count - 1

                                CODE_ARTICLE = envoie_lavage_linge_ligne.Rows(i)("CODE_ARTICLE")
                                PRIX_UNITAIRE = envoie_lavage_linge_ligne.Rows(i)("PRIX_UNITAIRE")
                                QUANTITE = envoie_lavage_linge_ligne.Rows(i)("QUANTITE")
                                MONTANT_TOTAL = envoie_lavage_linge_ligne.Rows(i)("MONTANT_TOTAL")
                                LINGE = envoie_lavage_linge_ligne.Rows(i)("LINGE")
                                ID_LAVAGE_LIGNE = envoie_lavage_linge_ligne.Rows(i)("ID_LAVAGE_LIGNE")

                                GunaDataGridView2.Rows.Add(ID_LAVAGE_LIGNE, CODE_ARTICLE, LINGE, QUANTITE, 0, 0, 0, 0, 0, PRIX_UNITAIRE, MONTANT_TOTAL)

                            Next

                        End If

                        TabControl1.SelectedIndex = 2
                        GunaButton2.Visible = True

                    Else

                        Dim Message As String = ""
                        Dim title As String = ""
                        If GlobalVariable.actualLanguageValue = 1 Then
                            Message = "Déjà receptionné"
                            title = "Réception"
                        Else
                            title = "Receive"
                            Message = "Already received"
                        End If

                        MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        GunaButton2.Visible = False

        Dim serviceEtage As New ServicesEtage()

        Dim CODE_ARTICLE As String = ""
        Dim PRIX_UNITAIRE As Double = 0
        Dim QUANTITE As Integer = 0
        Dim MONTANT_TOTAL As Double = 0
        Dim LINGE As String = ""
        Dim CODE_LAVAGE As String = Functions.GeneratingRandomCode("envoie_lavage_linge", "")
        Dim MONTANT As Double = 0
        Dim OBSERVATION As String = ""


        Dim DIFFERENCE As Integer = 0
        Dim QTE_RECU As Integer = 0
        Dim QTE_DECHIRE As Integer = 0
        Dim QTE_DECOLORE As Integer = 0
        Dim QTE_MAL_REPASSE As Integer = 0

        For i = 0 To GunaDataGridView2.Rows.Count - 1

            CODE_ARTICLE = GunaDataGridView2.Rows(i).Cells(1).Value.ToString
            PRIX_UNITAIRE = GunaDataGridView2.Rows(i).Cells(9).Value
            QUANTITE = GunaDataGridView2.Rows(i).Cells(3).Value
            DIFFERENCE = GunaDataGridView2.Rows(i).Cells(5).Value
            QTE_RECU = GunaDataGridView2.Rows(i).Cells(4).Value
            QTE_DECHIRE = GunaDataGridView2.Rows(i).Cells(6).Value
            QTE_DECOLORE = GunaDataGridView2.Rows(i).Cells(7).Value
            QTE_MAL_REPASSE = GunaDataGridView2.Rows(i).Cells(8).Value
            MONTANT_TOTAL = GunaDataGridView2.Rows(i).Cells(10).Value
            LINGE = GunaDataGridView2.Rows(i).Cells(2).Value.ToString

            serviceEtage.envoie_lavage_linge_ligne(CODE_ARTICLE, PRIX_UNITAIRE, QUANTITE, MONTANT_TOTAL, CODE_LAVAGE, LINGE)
            MONTANT += MONTANT_TOTAL

            serviceEtage.envoie_reception_linge_ligne(CODE_ARTICLE, PRIX_UNITAIRE, QUANTITE, MONTANT_TOTAL, CODE_LAVAGE, LINGE, DIFFERENCE, QTE_DECHIRE, QTE_DECOLORE, QTE_MAL_REPASSE, QTE_RECU)

        Next

        Dim INTITULE As String = GunaTextBox1.Text

        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_FOURNISSEUR As String = GunaComboBoxPrestaireReception.SelectedValue.ToString
        Dim ENVOI As Integer = 1
        Dim REFERENCE As String = GunaTextBoxReference.Text

        serviceEtage.insert_lavage(INTITULE, MONTANT, CODE_LAVAGE, DATE_CREATION, OBSERVATION, CODE_FOURNISSEUR, ENVOI, REFERENCE)

        Dim ETAT As Integer = 1

        Functions.updateOfFields("envoie_lavage_linge", "ETAT", ETAT, "CODE_LAVAGE", REFERENCE, 1)

        GunaTextBoxObservation.Clear()
        GunaTextBoxIntitule.Clear()
        GunaTextBoxReference.Clear()
        GunaTextBox1.Clear()
        GunaDataGridView2.Rows.Clear()
        DataGridViewReceptionEnvoie.Rows.Clear()

        clearField()

        Dim Message As String = ""
        Dim title As String = ""
        If GlobalVariable.actualLanguageValue = 0 Then
            Message = "Document successfully created"
            title = "Envoi"
        Else
            title = "Send"
            Message = "Document crée avec succès"
        End If

        MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub GunaDataGridView2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridView2.CellEndEdit
        GunaDataGridView2.CurrentRow.Cells(e.ColumnIndex).Value.ToString()

        Dim c As Integer = e.ColumnIndex

        If c > 0 Then

            If c = 4 Then 'RECU

                'DIFFERENCE = SORTIE - RECU
                Dim difference As Integer = 0

                'GunaDataGridView2.CurrentRow.Cells(c).Value = Math.Abs(GunaDataGridView2.CurrentRow.Cells(c).Value())
                difference = GunaDataGridView2.CurrentRow.Cells(c - 1).Value - GunaDataGridView2.CurrentRow.Cells(c).Value

                If difference < 0 Then
                    difference = 0
                    GunaDataGridView2.CurrentRow.Cells(c).Value = GunaDataGridView2.CurrentRow.Cells(c - 1).Value
                End If

                GunaDataGridView2.CurrentRow.Cells(c + 1).Value = difference

            ElseIf c = 5 Then 'DIFFERENCE

            ElseIf c = 6 Then 'DECHIREE
            ElseIf c = 7 Then 'DECOLORE
            ElseIf c = 8 Then 'REPASSE

            End If

        End If

    End Sub

    Private Sub GunaTextBox1_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox1.TextChanged
        If Trim(GunaTextBox1.Text).Equals("") Then
            GunaButton2.Visible = False
        Else
            GunaButton2.Visible = True
        End If
    End Sub

    Private Sub GunaCheckBox5_Click(sender As Object, e As EventArgs) Handles GunaCheckBox5.Click

        If GunaCheckBox5.Checked Then
            GunaComboBox5.DataSource = loadingOfFamilly()
            GunaComboBox5.ValueMember = "CODE_SOUS_FAMILLE"
            GunaComboBox5.DisplayMember = "LIBELLE_SOUS_FAMILLE"
        Else
            GunaComboBox5.DataSource = Nothing
        End If

    End Sub

    Public Function loadingOfFamilly()

        Dim famille As String = "sous famille"
        Dim query As String = "SELECT CODE_SOUS_FAMILLE , LIBELLE_SOUS_FAMILLE FROM sous_famille WHERE CODE_FAMILLE_PARENT IN ('PRESSING') ORDER BY LIBELLE_SOUS_FAMILLE ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

End Class