Imports System.IO
Imports MySql.Data.MySqlClient

Public Class RegisterForm

    Private Sub autoLoadRooms()

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT * FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY CHAMBRE_ID ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxEnChambre.DataSource = table
            GunaComboBoxEnChambre.ValueMember = "CHAMBRE_ID"
            GunaComboBoxEnChambre.DisplayMember = "CHAMBRE_ID"

        End If

        GunaComboBoxEnChambre.SelectedIndex = -1

    End Sub

    Private Sub RegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.register(GlobalVariable.actualLanguageValue)

        autoLoadRooms()

        GunaDateTimePickerDateVisite.Value = GlobalVariable.DateDeTravail

        ListeDesVisiteurs()

    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaComboBoxHeureGouter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxEnChambre.SelectedIndexChanged

        If GunaComboBoxEnChambre.SelectedIndex >= 0 Then

            Dim Chambre As String = GunaComboBoxEnChambre.SelectedValue.ToString()

            Dim infoResa As DataTable = Functions.GetAllElementsOnTwoConditions(Chambre, "reserve_conf", "CHAMBRE_ID", 1, "ETAT_RESERVATION")

            If infoResa.Rows.Count > 0 Then
                GunaTextBoxNomCLientEnChambre.Text = infoResa.Rows(0)("NOM_CLIENT")
                GunaTextBoxCodeResa.Text = infoResa.Rows(0)("CODE_RESERVATION")
            End If

        End If

    End Sub

    Public Sub ListeDesVisiteurs()

        'On affiche toutes les reserv_conf dont la date saisie est entre la d'entrée et la date de sortie (inclusif)

        Dim DateVisite As Date = GunaDateTimePickerDateVisite.Value.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT  `NOM_VISITEUR` VISITEUR, `CNI`, `DATE_CNI` AS DU , CHAMBRE , NOM_CLIENT AS 'CLIENT', `NOM_UTILISATEUR` AS PAR , `HEURE_ENTREE` AS A, `HEURE_SORTIE` AS 'HEURE SORTIE',  `DATE_VISITE` AS 'DATE DE VISITE', `CODE_RESERVATION`, `CODE_UTILISATEUR`, `DATE_DE_CONTROLE`, `ID_VISITE`, `CODE_VISITE` FROM visite WHERE DATE_VISITE <= '" & DateVisite.ToString("yyyy-MM-dd") & "' AND DATE_VISITE >='" & DateVisite.ToString("yyyy-MM-dd") & "' ORDER BY NOM_VISITEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaDataGridViewListeVisiteurs.DataSource = table

            If GunaDataGridViewListeVisiteurs.Rows.Count > 0 Then

                For i = 0 To GunaDataGridViewListeVisiteurs.Columns.Count - 1

                    If i > 8 Then
                        GunaDataGridViewListeVisiteurs.Columns(i).Visible = False
                    End If

                Next

            End If

        Else
            GunaDataGridViewListeVisiteurs.DataSource = Nothing
        End If

    End Sub


    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click


        If GunaComboBoxEnChambre.SelectedIndex >= 0 Then

            Dim NOM_VISITEUR As String = GunaTextBox1.Text
            Dim CODE_VISITE As String = Functions.GeneratingRandomCodeWithSpecifications("visite", "")
            Dim CNI As String = GunaTextBox2.Text
            Dim DATE_CNI As Date = GlobalVariable.DateDeTravail
            Dim CODE_RESERVATION As String = GunaTextBoxCodeResa.Text
            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
            Dim NOM_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
            Dim HEURE_ENTREE As String = Now().ToShortTimeString
            Dim HEURE_SORTIE As String = ""
            Dim DATE_VISITE As Date = GlobalVariable.DateDeTravail.ToShortDateString
            Dim CHAMBRE As String = GunaComboBoxEnChambre.SelectedValue.ToString
            Dim NOM_CLIENT As String = GunaTextBoxNomCLientEnChambre.Text

            Dim insertQuery As String = "INSERT INTO `visite`(`NOM_VISITEUR`, `CNI`, `DATE_CNI`, `CODE_RESERVATION`, `CODE_UTILISATEUR`,`HEURE_ENTREE`, `HEURE_SORTIE`,
                `NOM_UTILISATEUR`, `DATE_VISITE`,`CHAMBRE`, `NOM_CLIENT`, `CODE_VISITE`)
                VALUES (@NOM_VISITEUR, @CNI, @DATE_CNI, @CODE_RESERVATION, @CODE_UTILISATEUR, @HEURE_ENTREE, @HEURE_SORTIE, @NOM_UTILISATEUR, @DATE_VISITE , @CHAMBRE, @NOM_CLIENT, @CODE_VISITE)"
            Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

            command.Parameters.Add("@NOM_VISITEUR", MySqlDbType.VarChar).Value = NOM_VISITEUR
            command.Parameters.Add("@CNI", MySqlDbType.VarChar).Value = CNI
            command.Parameters.Add("@DATE_CNI", MySqlDbType.Date).Value = DATE_CNI
            command.Parameters.Add("@DATE_VISITE", MySqlDbType.Date).Value = DATE_VISITE
            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
            command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
            command.Parameters.Add("@NOM_UTILISATEUR", MySqlDbType.VarChar).Value = NOM_UTILISATEUR
            command.Parameters.Add("@HEURE_ENTREE", MySqlDbType.VarChar).Value = HEURE_ENTREE
            command.Parameters.Add("@HEURE_SORTIE", MySqlDbType.VarChar).Value = HEURE_SORTIE
            command.Parameters.Add("@NOM_CLIENT", MySqlDbType.VarChar).Value = NOM_CLIENT
            command.Parameters.Add("@CHAMBRE", MySqlDbType.VarChar).Value = CHAMBRE
            command.Parameters.Add("@CODE_VISITE", MySqlDbType.VarChar).Value = CODE_VISITE

            command.ExecuteNonQuery()

            ListeDesVisiteurs()

            Functions.SiplifiedClearTextBox(Me)
            GunaComboBoxEnChambre.SelectedIndex = -1
            GunaTextBoxCodeResa.Clear()

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                MessageBox.Show("Please choose a room", "Visit management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Bien vouloir choisir une chambre", "Gestion des visites", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub GunaDateTimePickerDateVisite_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePickerDateVisite.ValueChanged

        ListeDesVisiteurs()

    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click

        Dim languageMessage = ""
        Dim languageTitle = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then

            If GunaDataGridViewListeVisiteurs.Rows.Count > 0 Then

                Dim DeleteRow As Boolean = False
                Dim CODE_VISITE As String = GunaDataGridViewListeVisiteurs.CurrentRow.Cells("CODE_VISITE").Value.ToString
                Dim rowToDelete As String = GunaDataGridViewListeVisiteurs.CurrentRow.Cells("VISITEUR").Value.ToString

                Dim dialog As DialogResult

                If GlobalVariable.actualLanguageValue = 1 Then
                    dialog = MessageBox.Show("Voulez-vous vraiment Supprimer Visit" & rowToDelete, "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Else
                    dialog = MessageBox.Show("Do you reaaly want to delete this visit " & rowToDelete, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                End If

                If Not dialog = DialogResult.No Then
                    DeleteRow = True
                End If

                If DeleteRow Then

                    Functions.DeleteRowFromDataGrid(GunaDataGridViewListeVisiteurs, CODE_VISITE, "visite", "CODE_VISITE")

                    Functions.DeleteRowFromDataGrid(GunaDataGridViewListeVisiteurs, CODE_VISITE, "visite", "CODE_VISITE")

                    GunaDataGridViewListeVisiteurs.Columns.Clear()

                    ListeDesVisiteurs()

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("You successfully deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End If

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Aucune ligne à suprimer !", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("No line to delete !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "You don't have the necessary right to delete"
                languageTitle = "Correction"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Vous n'avez pas le droit necessaire pour supprimer"
                languageTitle = "Correction"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub GunaDataGridViewListeVisiteurs_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewListeVisiteurs.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewListeVisiteurs.Rows(e.RowIndex)

            Dim ID_VISITE As Integer = row.Cells("ID_VISITE").Value

            Dim HEURE_SORTIE As String = Now().ToLongTimeString

            If Trim(row.Cells("HEURE SORTIE").Value).Equals("") Then

                Functions.updateOfFields("visite", "HEURE_SORTIE", HEURE_SORTIE, "ID_VISITE", ID_VISITE, 2)

                If GlobalVariable.actualLanguageValue = 0 Then
                    MessageBox.Show("Exit time saved successfully", "Visit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Heure de sortie enregitrée avec succès", "Visite", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ListeDesVisiteurs()

            End If

        End If

    End Sub

End Class