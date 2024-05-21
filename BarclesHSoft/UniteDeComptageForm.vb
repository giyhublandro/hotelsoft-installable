Imports MySql.Data.MySqlClient

Public Class UniteDeComptageForm

    Private Sub UniteDeComptageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.UniteDeComptage(GlobalVariable.actualLanguageValue)

        GunaTextBoxCodeGrandeUnite.Text = Functions.GeneratingRandomCodePanne("unite_comptage", "GU")
        GunaTextBoxCodePetiteUnite.Text = Functions.GeneratingRandomCodePanne("unite_comptage", "PU")

        GunaComboBoxUnitePour.SelectedIndex = 0

        ListeDesUnites()

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Public Sub ListeDesUnites()

        'We load the Type of rooms or salle

        Dim Query As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            Query = "SELECT `GRANDE_UNITE` AS 'BIG UNIT', `CODE_GRANDE_UNITE` AS 'CODE GRANDE UNITE', `VALEUR_NUMERIQUE` As 'NUMERICAL VALUE',`PETITE_UNITE` AS 'SMALL UNIT', `CODE_PETITE_UNITE` As 'CODE PETITE UNITE', `CODE_UNITE_DE_COMPTAGE` AS 'CODE UNITE' FROM `unite_comptage` ORDER BY GRANDE_UNITE ASC"
        Else
            Query = "SELECT `GRANDE_UNITE` AS 'GRANDE UNITE', `CODE_GRANDE_UNITE` AS 'CODE GRANDE UNITE', `VALEUR_NUMERIQUE` As 'VALEUR NUMERIQUE',`PETITE_UNITE` AS 'PETITE UNITE', `CODE_PETITE_UNITE` As 'CODE PETITE UNITE', `CODE_UNITE_DE_COMPTAGE` AS 'CODE UNITE' FROM `unite_comptage` ORDER BY GRANDE_UNITE ASC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim tableUnite As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(tableUnite)

        If (tableUnite.Rows.Count > 0) Then
            DataGridViewUniteListe.DataSource = tableUnite

            DataGridViewUniteListe.Columns("CODE GRANDE UNITE").Visible = False
            DataGridViewUniteListe.Columns("CODE PETITE UNITE").Visible = False
            DataGridViewUniteListe.Columns("CODE UNITE").Visible = False

        Else
            DataGridViewUniteListe.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        If Trim(GunaTextBox5.Text) = "" Then
            GunaTextBox5.Text = 0
        End If

        Dim CODE_UNITE_DE_COMPTAGE As String = GunaTextBox6.Text
        Dim GRANDE_UNITE As String = GunaTextBox2.Text
        Dim PETITE_UNITE As String = GunaTextBox3.Text
        Dim CODE_GRANDE_UNITE As String = GunaTextBoxCodeGrandeUnite.Text
        Dim CODE_PETITE_UNITE As String = GunaTextBoxCodePetiteUnite.Text
        Dim VALEUR_NUMERIQUE As Double = GunaTextBox5.Text

        Dim TYPE = GunaComboBoxUnitePour.SelectedItem.ToString

        Dim economat As New Economat()

        If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then
            'we update the value after double click
            If economat.updateUniteDeComptage(GRANDE_UNITE, PETITE_UNITE, CODE_GRANDE_UNITE, CODE_PETITE_UNITE, VALEUR_NUMERIQUE, CODE_UNITE_DE_COMPTAGE, TYPE) Then

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Updated successfully"
                    languageTitle = "Unité de comptage"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Mise à jours effucté avec succès"
                    languageTitle = "Unité de comptage"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Clearing of fields
                Functions.ClearTextBox(Me)
            End If

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonEnregistrer.Text = "Save"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrer.Text = "Enregistrer"
            End If

        Else
            CODE_UNITE_DE_COMPTAGE = Functions.GeneratingRandomCode("unite_comptage", "")
            If Not Functions.entryCodeExists(CODE_UNITE_DE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE") Then
                If economat.insertUniteDeComptage(GRANDE_UNITE, PETITE_UNITE, CODE_GRANDE_UNITE, CODE_PETITE_UNITE, VALEUR_NUMERIQUE, CODE_UNITE_DE_COMPTAGE, TYPE) Then
                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "New unit successfully created"
                        languageTitle = "Création of unit"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Nouvelle unitée enregistrée avec succès"
                        languageTitle = "Création d'unitée de comptage"
                    End If
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Clearing of fields

                    Functions.ClearTextBox(Me)
                Else
                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "A problem during the creation"
                        languageTitle = "Création of unit"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Problème de creation"
                        languageTitle = "Création d'unitée de comptage"
                    End If
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "this unit already exist"
                    languageTitle = "Création d'unitée de comptage"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Cette unité existe déjà, Essayer à nouveau"
                    languageTitle = "Création d'unitée de comptage"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

        TabControl1.SelectedIndex = 1

        GunaTextBoxCodeGrandeUnite.Text = Functions.GeneratingRandomCodePanne("unite_comptage", "GU")
        GunaTextBoxCodePetiteUnite.Text = Functions.GeneratingRandomCodePanne("unite_comptage", "PU")

    End Sub

    Private Sub DataGridViewUniteListe_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewUniteListe.CellDoubleClick

        If e.RowIndex >= 0 Then

            'AU DOUBLE CLICK CONTROLLER SI L'ELEMENT SUR LEQUEL ON CLIQUE A LE DROIT D'

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonEnregistrer.Text = "Update"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrer.Text = "Sauvegarder"
            End If

            Dim row As DataGridViewRow

            row = Me.DataGridViewUniteListe.Rows(e.RowIndex)

            Dim unite As DataTable = Functions.getElementByCode(Trim(row.Cells("CODE UNITE").Value.ToString), "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

            If unite.Rows.Count > 0 Then

                GunaTextBox6.Text = unite.Rows(0)("CODE_UNITE_DE_COMPTAGE")
                GunaTextBox2.Text = unite.Rows(0)("GRANDE_UNITE")
                GunaTextBox3.Text = unite.Rows(0)("PETITE_UNITE")
                GunaTextBoxCodeGrandeUnite.Text = unite.Rows(0)("CODE_GRANDE_UNITE")
                GunaTextBoxCodePetiteUnite.Text = unite.Rows(0)("CODE_PETITE_UNITE")
                GunaTextBox5.Text = unite.Rows(0)("VALEUR_NUMERIQUE")

                GunaComboBoxUnitePour.SelectedItem = unite.Rows(0)("TYPE")

                TabControl1.SelectedIndex = 0

            End If

        End If
    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Me.Close()
    End Sub
    'Rafraichissement au changement de tabControl
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        ListeDesUnites()
    End Sub

    Private Sub ImprimerToolStripMenuItemSupressionCaisse_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItemSupressionCaisse.Click

        If DataGridViewUniteListe.Rows.Count > 0 Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Do you really want to delete " & DataGridViewUniteListe.CurrentRow.Cells("BIG UNIT").Value.ToString
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Voulez-vous vraiment Supprimer " & DataGridViewUniteListe.CurrentRow.Cells("GRANDE UNITE").Value.ToString
                languageTitle = "Supression"
            End If
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(DataGridViewUniteListe, DataGridViewUniteListe.CurrentRow.Cells("CODE UNITE").Value.ToString, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                DataGridViewUniteListe.Columns.Clear()

                ListeDesUnites()

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "You have deleted the unit successfully"
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Vous avez supprimé avec succès"
                    languageTitle = "Supression"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Nothing to be deleted"
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Aucune ligne à suprimer!"
                languageTitle = "Supression"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaComboBoxUnitePour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxUnitePour.SelectedIndexChanged

        If GunaComboBoxUnitePour.SelectedItem = "Autres" Or GunaComboBoxUnitePour.SelectedItem = "Others" Then

            GunaLabelCodeUniteDestockage.Visible = True
            GunaTextBoxCodePetiteUnite.Visible = True

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaLabel2.Text = "Storage unit code"
                GunaLabel3.Text = "Storage unit name"
                GunaLabel6.Text = "conversion value"

            Else
                GunaLabel2.Text = "Code Unité de Stockage"
                GunaLabel3.Text = "Libellé unité de Stockage"
                GunaLabel6.Text = "Valeur de conversion"

            End If

            GunaLabel4.Visible = True
            GunaTextBox3.Visible = True

        ElseIf GunaComboBoxUnitePour.SelectedItem = "Consommation" Or GunaComboBoxUnitePour.SelectedItem = "Shot" Then

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaLabel2.Text = "Shot unit code"
                GunaLabel3.Text = "Shot unit name"

                GunaLabel6.Text = "Quantity"

            Else

                GunaLabel2.Text = "Code Unité de consommation"
                GunaLabel3.Text = "Libellé unité de Consommation"

                GunaLabel6.Text = "Quantité"

            End If

            GunaLabelCodeUniteDestockage.Visible = False
            GunaTextBoxCodePetiteUnite.Visible = False

            GunaLabel4.Visible = False
            GunaTextBox3.Visible = False

        End If

    End Sub

End Class