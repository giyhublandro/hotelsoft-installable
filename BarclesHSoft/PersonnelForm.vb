Imports System.IO
Imports MySql.Data.MySqlClient

Public Class PersonnelForm

    'Database connection management
    'Dim connect As New DataBaseManipulation()

    Private Sub PersonnelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TabControl1.SelectedIndex = 1

        'PersonnelList()

        FillingAllComboxBox()

    End Sub

    Public Sub PersonnelList()

        Dim query As String = "SELECT `ID_PERSONNEL`, `CODE_PERSONNEL`, `NOM_PERSONNEL`,  `PRENOM_PERSONNEL`, `MATRICULE`, `NOM_JEUNE_FILLE`, `DATE_NAISSANCE`, `LIEU_NAISSANCE`, `NOM_PERE`, `NOM_MERE`, `PROFESSION`, `SEXE`, `NUMERO_CNI`, personnel.CODE_TYPE_PERSONNEL, `ADRESSE`, `TELEPHONE`, `FAX`, `EMAIL`, personnel.CODE_UTILISATEUR_CREA, personnel.DATE_CREATION, `CHEMIN_PHOTO`,`LIBELLE_TYPE_PERSONNEL`, `SALAIRE` FROM personnel,type_personnel WHERE personnel.CODE_TYPE_PERSONNEL = type_personnel.CODE_TYPE_PERSONNEL AND personnel.CODE_AGENCE=@CODE_AGENCE ORDER BY NOM_PERSONNEL ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewPersonnel.DataSource = table
        Else
            GunaDataGridViewPersonnel.Columns.Clear()
        End If

        If GunaDataGridViewPersonnel.Rows.Count > 0 Then

            GunaDataGridViewPersonnel.Columns("ID_PERSONNEL").Visible = False
            GunaDataGridViewPersonnel.Columns("CODE_PERSONNEL").Visible = False
            GunaDataGridViewPersonnel.Columns("CHEMIN_PHOTO").Visible = False
            GunaDataGridViewPersonnel.Columns("CODE_UTILISATEUR_CREA").Visible = False
            GunaDataGridViewPersonnel.Columns("CODE_TYPE_PERSONNEL").Visible = False
            GunaDataGridViewPersonnel.Columns("CODE_TYPE_PERSONNEL").Visible = False
            GunaDataGridViewPersonnel.Columns("SALAIRE").DefaultCellStyle.Format = "#,##0"

        End If

        'connect.closeConnection()

    End Sub

    'Loading data from database into comboboxes
    Sub FillingAllComboxBox()

        'Country
        Dim query As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            query = "SELECT  UPPER(`NOM_PAYS_EN`) AS NOM_PAYS_EN, `NATIONALITE_EN`, `NOM_PAYS_FR`, `NATIONALITE_FR`, `nicename` FROM `pays` ORDER BY NOM_PAYS_EN ASC"
        Else
            query = "SELECT  `NOM_PAYS_EN`, `NATIONALITE_EN`, UPPER(`NOM_PAYS_FR`) AS NOM_PAYS_FR, `NATIONALITE_FR`, `nicename` FROM `pays` ORDER BY NOM_PAYS_FR ASC"
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        Dim tableListPays As New DataTable()
        adapter.Fill(tableListPays)

        If (tableListPays.Rows.Count > 0) Then

            GunaComboBoxPays.DataSource = tableListPays

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaComboBoxPays.ValueMember = "NOM_PAYS_EN"
                GunaComboBoxPays.DisplayMember = "NOM_PAYS_EN"
            Else
                GunaComboBoxPays.ValueMember = "NOM_PAYS_FR"
                GunaComboBoxPays.DisplayMember = "NOM_PAYS_FR"
            End If


        End If

        'connect.closeConnection()

        'Town
        Dim tqbleTypePersonnel As DataTable = Functions.allTableFields("type_personnel")

        If (tqbleTypePersonnel.Rows.Count > 0) Then

            GunaComboBoxTypePersonnel.DataSource = tqbleTypePersonnel
            GunaComboBoxTypePersonnel.ValueMember = "CODE_TYPE_PERSONNEL"
            GunaComboBoxTypePersonnel.DisplayMember = "LIBELLE_TYPE_PERSONNEL"

        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonEnregistrerClient_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerPersonnel.Click

        Dim CODE_PERSONNEL As String = Functions.GeneratingRandomCode("personnel", "")
        Dim MATRICULE As String = GunaTextBoxMatricule.Text
        Dim NOM_PERSONNEL As String = GunaTextBoxNom.Text
        Dim NOM_JEUNE_FILLE As String = GunaTextBoxNomDeJeunneFille.Text
        Dim PRENOM_PERSONNEL As String = GunaTextBoxPrenom.Text
        Dim DATE_NAISSANCE As Date = GunaDateTimePickerDateNaissance.Value.ToShortDateString()
        Dim LIEU_NAISSANCE As String = GunaTextBoxLieuDeNaissance.Text
        Dim NOM_PERE As String = GunaTextBoxNomPere.Text
        Dim NOM_MERE As String = GunaTextBoxNomMere.Text
        Dim PROFESSION As String = GunaTextBoxProfession.Text
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim SEXE As String = GunaComboBoxSexe.SelectedItem
        Dim NUMERO_CNI As String = GunaTextBoxCni.Text
        Dim CODE_TYPE_PERSONNEL As String = GunaComboBoxTypePersonnel.SelectedValue
        Dim ADRESSE As String = GunaTextBoxAdresse.Text
        Dim TELEPHONE As String = MaskedTextBoxTelephone.Text
        Dim FAX As String = GunaTextBoxFax.Text
        Dim EMAIL As String = GunaTextBoxEmail.Text
        Dim CODE_UTILISATEUR_CREA As String = ""
        Dim DATE_CREATION As Date = Date.Now()
        Dim CHEMIN_PHOTO As String = ""
        Dim SALAIRE As Double = 0

        If Not Trim(GunaTextBoxSalaire.Text) = "" Then
            SALAIRE = GunaTextBoxSalaire.Text
        End If

        Dim personnel As New TypePersonnel()

        If (True) Then

            If GunaButtonEnregistrerPersonnel.Text = "Sauvegarder" Then

                'We update the information of the user
                CODE_PERSONNEL = GunaTextBoxCodePersonnel.Text 'We prevent the code from having a newly created code

                If personnel.updatePersonnel(CODE_PERSONNEL, MATRICULE, NOM_PERSONNEL, NOM_JEUNE_FILLE, PRENOM_PERSONNEL, DATE_NAISSANCE, LIEU_NAISSANCE, NOM_PERE, NOM_MERE, PROFESSION, SEXE, NUMERO_CNI, CODE_TYPE_PERSONNEL, ADRESSE, TELEPHONE, FAX, EMAIL, CHEMIN_PHOTO, SALAIRE) Then 'update query
                    MessageBox.Show("Personnel Mise à jour avec succès", "Mise à jour d'un Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GunaButtonEnregistrerPersonnel.Text = "Enregistrer
"
                End If

            Else

                'check if the client alreday exist
                If Not personnel.PersonnelExist(CODE_PERSONNEL, NOM_PERSONNEL) Then

                    If personnel.insertPersonnel(CODE_PERSONNEL, MATRICULE, NOM_PERSONNEL, NOM_JEUNE_FILLE, PRENOM_PERSONNEL, DATE_NAISSANCE, LIEU_NAISSANCE, NOM_PERE, NOM_MERE, PROFESSION, CODE_AGENCE, SEXE, NUMERO_CNI, CODE_TYPE_PERSONNEL, ADRESSE, TELEPHONE, FAX, EMAIL, CODE_UTILISATEUR_CREA, DATE_CREATION, CHEMIN_PHOTO, SALAIRE) Then

                        MessageBox.Show("Nouveau Personnel enregistré avec succès", "Création d'un Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Un problème lors de la création !!", "Création d'un Personnel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Ce Personnel existe déjà, Essayer à nouveau", "Création d'un Personnel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création d'un Personnel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Functions.ClearTextBox(Me)

        'We refresh the Personnel list
        'PersonnelList()

        'connect.closeConnection()

        'TabControl1.SelectedIndex = 1

    End Sub

    'Editing the personnel list

    'When double click on the list for update
    Private Sub GunaDataGridViewPersonnel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPersonnel.CellDoubleClick

        Dim CodePersonnel As String = ""
        Dim personnel As DataTable

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPersonnel.Rows(e.RowIndex)

            CodePersonnel = row.Cells("CODE_PERSONNEL").Value.ToString()

            personnel = Functions.getElementByCode(CodePersonnel, "personnel", "CODE_PERSONNEL")

            'On rempli la description des eventuelles modifications

            'connect.closeConnection()

            GunaButtonEnregistrerPersonnel.Text = "Sauvegarder"

            GunaTextBoxCodePersonnel.Text = personnel.Rows(0)("CODE_PERSONNEL")

            GunaTextBoxMatricule.Text = personnel.Rows(0)("MATRICULE")
            GunaTextBoxNom.Text = personnel.Rows(0)("NOM_PERSONNEL")
            GunaTextBoxNomDeJeunneFille.Text = personnel.Rows(0)("NOM_JEUNE_FILLE")
            GunaTextBoxPrenom.Text = personnel.Rows(0)("PRENOM_PERSONNEL")
            GunaDateTimePickerDateNaissance.Value = personnel.Rows(0)("DATE_NAISSANCE")
            GunaTextBoxLieuDeNaissance.Text = personnel.Rows(0)("LIEU_NAISSANCE")
            GunaTextBoxNomPere.Text = personnel.Rows(0)("NOM_PERE")
            GunaTextBoxNomMere.Text = personnel.Rows(0)("NOM_MERE")
            GunaTextBoxProfession.Text = personnel.Rows(0)("PROFESSION")

            GunaComboBoxSexe.SelectedItem = personnel.Rows(0)("SEXE")
            GunaTextBoxCni.Text = personnel.Rows(0)("NUMERO_CNI")
            GunaComboBoxTypePersonnel.SelectedValue = personnel.Rows(0)("CODE_TYPE_PERSONNEL")
            GunaTextBoxAdresse.Text = personnel.Rows(0)("ADRESSE")
            MaskedTextBoxTelephone.Text = personnel.Rows(0)("TELEPHONE")
            GunaTextBoxFax.Text = personnel.Rows(0)("FAX")
            GunaTextBoxEmail.Text = personnel.Rows(0)("EMAIL")
            GunaTextBoxSalaire.Text = Format(personnel.Rows(0)("SALAIRE"), "#,##0")

            GunaDataGridViewPersonnel.Columns.Clear()

            TabControl1.SelectedIndex = 0

        End If

    End Sub

    '---------------------------------------------- LIVE SEARCH ----------------------------------------------
    'Reorganise when we enter the button for search
    Private Sub GunaTextBoxcCode_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT CODE_PERSONNEL, MATRICULE, NOM_PERSONNEL AS 'NOM', PRENOM_PERSONNEL AS 'PRENOM' FROM personnel WHERE CODE_AGENCE=@CODE_AGENCE ORDER BY NOM_PERSONNEL ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewPersonnel.DataSource = table
        Else
            GunaDataGridViewPersonnel.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    'LIve search based on the code
    Private Sub GunaTextBoxcCode_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT * FROM personnel WHERE CODE_PERSONNEL LIKE '%" & GunaTextBoxCode.Text & "%' OR MATRICULE LIKE '%" & GunaTextBoxCode.Text & "%' AND CODE_AGENCE=@CODE_AGENCE ORDER BY CODE_PERSONNEL ASC "
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)
        'Command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'GunaDataGridViewPersonnel.DataSource = table
        'Else
        'GunaDataGridViewPersonnel.Columns.Clear()
        'End If

        ''connect.closeConnection()

    End Sub

    'live search  based on the name
    Private Sub GunaTextBoxDesig_TextChanged(sender As Object, e As EventArgs)

        'Dim query As String = "SELECT * FROM personnel WHERE NOM_PERSONNEL LIKE '%" & GunaTextBoxDesig.Text & "%' AND CODE_AGENCE=@CODE_AGENCE ORDER BY NOM_PERSONNEL ASC"
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)
        'Command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        'Dim adapter As New MySqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)

        'If (table.Rows.Count > 0) Then
        'GunaDataGridViewPersonnel.DataSource = table

        'Else
        'GunaDataGridViewPersonnel.Columns.Clear()
        'End If

        ''connect.closeConnection()

    End Sub

    Private Sub GunaTextBoxDesig_Enter(sender As Object, e As EventArgs)

        Dim query As String = "SELECT * FROM personnel WHERE CODE_AGENCE=@CODE_AGENCE ORDER BY NOM_PERSONNEL ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewPersonnel.DataSource = table
        Else
            GunaDataGridViewPersonnel.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        PersonnelList()
    End Sub
End Class