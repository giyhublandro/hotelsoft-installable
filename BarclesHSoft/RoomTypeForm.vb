Imports MySql.Data.MySqlClient

Public Class RoomTypeForm

    'Dim connect As New DataBaseManipulation()

    Private Sub RoomTypeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.roomType(GlobalVariable.actualLanguageValue)

        DataGridViewRoomTypeListe.Columns.Clear()

        TabControl1.SelectedIndex = 1

        GunaLabel2.Visible = False
        GunaLabel3.Visible = False
        GunaTextBoxSuperficie.Visible = False
        GunaTextBoxCapacite.Visible = False

        If GlobalVariable.addCategorieFromFrontOffice = True Then

            If MainWindow.GunaRadioButtonChambre.Checked Then
                GunaRadioButtonChambre.Visible = True
                GunaRadioButtonSalle.Visible = False
            Else
                GunaRadioButtonChambre.Visible = False
                GunaRadioButtonSalle.Visible = True
                GunaRadioButtonSalle.Checked = True
            End If

            If GunaRadioButtonChambre.Checked Then
                GlobalVariable.typeChambreOuSalle = "chambre"
            ElseIf GunaRadioButtonSalle.Checked Then
                GlobalVariable.typeChambreOuSalle = "salle"
            End If

            roomTypeList()

        Else
            DataGridViewRoomTypeListe.Columns.Clear()
        End If

    End Sub

    Public Sub roomTypeList()

        Dim query As String = ""

        If GlobalVariable.typeChambreOuSalle = "chambre" Then
            query = "SELECT `LIBELLE_TYPE_CHAMBRE` AS LIBELLE, `DESCRIPTION`, `PRIX`, `CODE_TYPE_CHAMBRE` AS 'CODE TYPE', TAUX_CHARGE_FIXE As 'TAUX CHARGES FIXES', `NOMBRE_LIT_UNE_PLACE` AS 'LIT UNE PLACE', `NOMBRE_LIT_DEUX_PLACES` As 'LIT DEUX PLACES' FROM type_chambre WHERE TYPE=@TYPE ORDER BY LIBELLE_TYPE_CHAMBRE ASC"
        ElseIf GlobalVariable.typeChambreOuSalle = "salle" Then
            query = "SELECT `LIBELLE_TYPE_CHAMBRE` AS LIBELLE, `DESCRIPTION`, `PRIX`, `CODE_TYPE_CHAMBRE` AS 'CODE TYPE', `CAPACITE`, `SUPERFICIE`, TAUX_CHARGE_FIXE As 'TAUX CHARGES FIXES' FROM type_chambre WHERE TYPE=@TYPE ORDER BY LIBELLE_TYPE_CHAMBRE ASC"
        End If

        'Dim query As String = "SELECT * FROM type_chambre ORDER BY LIBELLE_TYPE_CHAMBRE"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle(0)("CODE_AGENCE")
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            DataGridViewRoomTypeListe.DataSource = table
            DataGridViewRoomTypeListe.Columns("PRIX").DefaultCellStyle.Format = "#,##0"
            DataGridViewRoomTypeListe.Columns("PRIX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Else
            DataGridViewRoomTypeListe.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        ' prevents from loading something that does not exist
        GlobalVariable.addCategorieFromFrontOffice = False
        Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        ' prevents from loading something that does not exist
        GlobalVariable.addCategorieFromFrontOffice = False
        Close()
    End Sub

    'Function to check empty fields
    Public Function verifyFields() As Boolean

        Dim check As Boolean = False

        If (GunaTextBoxDescription.Text.Trim().Equals("") _
                    Or GunaTextBoxCode.Text.Trim().Equals("") _
                    Or GunaTextBoxLibelle.Text.Trim().Equals("") _
                    Or GunaTextBoxPrix.Text.Trim().Equals("")) Then
            check = False

        Else

            check = True

        End If

        Return check

    End Function

    'Insertion d'une nouvelle ligne
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim LIBELLE_TYPE_CHAMBRE = GunaTextBoxLibelle.Text
        Dim DESCRIPTION = GunaTextBoxDescription.Text
        Dim PRIX = GunaTextBoxPrix.Text
        Dim CODE_TYPE_CHAMBRE = GunaTextBoxCode.Text
        Dim OLD_CODE_TYPE_CHAMBRE = GunaTextBoxOldCodeTypeChambre.Text
        Dim DATE_CREATION = Now()
        Dim CODE_UTILISATEUR_MODIF = ""
        Dim DATE_MODIFICATION = Now()
        Dim CODE_AGENCE = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim CODE_TYPE As String = ""
        Dim SUPERFICIE As Double = 0
        Dim CAPACITE As Double = 0

        Dim TAUX_CHARGE_FIXE As Double = GunaTextBoxTauxChargeFixe.Text

        If GlobalVariable.typeChambreOuSalle = "salle" Then

            Dim superficieSalle As Double = 0
            Dim capaciteSalle As Double = 0
            Double.TryParse(GunaTextBoxSuperficie.Text, superficieSalle)
            SUPERFICIE = superficieSalle
            Double.TryParse(GunaTextBoxCapacite.Text, capaciteSalle)
            CAPACITE = capaciteSalle

        End If

        Dim roomType As New RoomType

        If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then

            'We update the value of the row in case of any change
            If roomType.UpdateChambre(LIBELLE_TYPE_CHAMBRE, DESCRIPTION, PRIX, CODE_TYPE_CHAMBRE, CODE_UTILISATEUR_MODIF, DATE_MODIFICATION, TAUX_CHARGE_FIXE, CODE_AGENCE, OLD_CODE_TYPE_CHAMBRE, SUPERFICIE, CAPACITE, CODE_TYPE) Then

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Mise à jour effectuée avec succès", "Création de Type", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GunaButtonEnregistrer.Text = "Enregistrer"
                Else
                    MessageBox.Show("Update successfully done", "Type creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GunaButtonEnregistrer.Text = "Save"
                End If

                GunaTextBoxOldCodeTypeChambre.Clear()

            End If

            'We empty the fields
            GunaTextBoxCode.Text = ""
            GunaTextBoxLibelle.Text = ""
            GunaTextBoxPrix.Text = ""
            GunaTextBoxDescription.Text = ""
            GunaTextBoxSuperficie.Text = ""

            Functions.SiplifiedClearTextBox(Me)
            GunaTextBoxTauxChargeFixe.Text = 50

        Else
            'company verifyfields function

            If (verifyFields()) Then
                'check if the company alreday exist
                If Not roomType.typeChambreExists(CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE) Then

                    If GunaRadioButtonChambre.Checked Then
                        GlobalVariable.typeChambreOuSalle = "chambre"
                        CODE_TYPE = GlobalVariable.typeChambreOuSalle
                    ElseIf GunaRadioButtonSalle.Checked Then
                        GlobalVariable.typeChambreOuSalle = "salle"
                        CODE_TYPE = GlobalVariable.typeChambreOuSalle
                    End If

                    If GlobalVariable.typeChambreOuSalle = "chambre" Then

                        If roomType.Insert(LIBELLE_TYPE_CHAMBRE, DESCRIPTION, PRIX, CODE_TYPE_CHAMBRE, DATE_CREATION, CODE_UTILISATEUR_MODIF, DATE_MODIFICATION, TAUX_CHARGE_FIXE, CODE_AGENCE) Then

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Nouveau Type de Chambre enregistré avec succès", "Création de Type de chambre", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("New type of room successfully created", "Room Type creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                            'We empty the fields
                            GunaTextBoxCode.Text = ""
                            GunaTextBoxLibelle.Text = ""
                            GunaTextBoxPrix.Text = ""
                            GunaTextBoxDescription.Text = ""
                            GunaTextBoxSuperficie.Text = ""

                            Functions.SiplifiedClearTextBox(Me)

                            GunaTextBoxTauxChargeFixe.Text = 50

                        Else

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Un problème lors de la création !!", "Création de Type de chambre", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            Else
                                MessageBox.Show("Problem during creation !!", "Room type creation", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            End If

                        End If

                        Functions.ClearTextBox(Me)

                    ElseIf GlobalVariable.typeChambreOuSalle = "salle" Then

                        If roomType.Insert(LIBELLE_TYPE_CHAMBRE, DESCRIPTION, PRIX, CODE_TYPE_CHAMBRE, DATE_CREATION, CODE_UTILISATEUR_MODIF, DATE_MODIFICATION, TAUX_CHARGE_FIXE, CODE_AGENCE, SUPERFICIE, CAPACITE, CODE_TYPE) Then

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Nouveau Type de Salle enregistré avec succès", "Création de Type de Salle", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else
                                MessageBox.Show("New type of hall successfully created", "Hall Type creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If


                            'We empty the fields
                            GunaTextBoxCode.Text = ""
                            GunaTextBoxLibelle.Text = ""
                            GunaTextBoxPrix.Text = ""
                            GunaTextBoxDescription.Text = ""
                            GunaTextBoxSuperficie.Text = ""

                            Functions.SiplifiedClearTextBox(Me)
                            GunaTextBoxTauxChargeFixe.Text = 50

                        Else

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Un problème lors de la création !!", "Création de Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            Else
                                MessageBox.Show("Issue during creation !!", "Creation of type", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            End If

                        End If

                        Functions.ClearTextBox(Me)

                    End If

                Else
                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Ce Type existe déjà, Essayer à nouveau", "Type Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    Else
                        MessageBox.Show("This type already exist, Please try another", "Type Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création de Type", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("Please fill all the fields !!", "Type creation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If

        End If

        GunaTextBoxTauxChargeFixe.Text = "50"
        GunaTextBoxSuperficie.Text = "0"
        GunaTextBoxCapacite.Text = "0"

        DataGridViewRoomTypeListe.Columns.Clear()

    End Sub

    'We double to update a row
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewRoomTypeListe.CellDoubleClick

        'When we doubleclick on the room category datagrid it is either for update or for bringing the selected row to front desk

        RoomForm.DataGridViewRoomListe.Columns.Clear()

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.DataGridViewRoomTypeListe.Rows(e.RowIndex)

            If GlobalVariable.addCategorieFromFrontOffice Then

                'We come from the front desk to fill the room form part of the front desk
                GlobalVariable.CategorieAddedFromFrontOffice = Functions.getElementByCode(row.Cells("CODE TYPE").Value.ToString, "type_Chambre", "CODE_TYPE_CHAMBRE")

                'We make sure it is possible to Choose a room if a room type is choosen first
                'We set back the diasbled values after checkin or save

                MainWindow.MainWindowManualActivation()

                MainWindow.reservationButtonToDisplay()

                If MainWindow.GunaRadioButtonSalleFete.Checked Then
                    GlobalVariable.typeChambreOuSalle = "salle"
                ElseIf MainWindow.GunaRadioButtonChambre.Checked Then
                    GlobalVariable.typeChambreOuSalle = "chambre"
                End If

                If GlobalVariable.typeChambreOuSalle = "salle" Then

                    If Trim(MainWindow.GunaTextBoxMontantAfficherSalle.Text).Equals("") Then
                        MainWindow.GunaTextBoxMontantAfficherSalle.Text = Format(row.Cells("PRIX").Value, "#,##0")
                        MainWindow.GunaTextBoxMontantReelSalle.Text = Format(row.Cells("PRIX").Value, "#,##0")
                    End If

                End If

                Me.Close()

            Else

                GunaTextBoxCode.Text = row.Cells("CODE TYPE").Value.ToString
                GunaTextBoxOldCodeTypeChambre.Text = row.Cells("CODE TYPE").Value.ToString
                GunaTextBoxLibelle.Text = row.Cells("LIBELLE").Value.ToString
                GunaTextBoxPrix.Text = Format(row.Cells("PRIX").Value, "#,##0")
                GunaTextBoxDescription.Text = row.Cells("DESCRIPTION").Value.ToString
                GunaTextBoxTauxChargeFixe.Text = row.Cells("TAUX CHARGES FIXES").Value

                If GlobalVariable.typeChambreOuSalle = "salle" Then

                    GunaTextBoxSuperficie.Text = Format(row.Cells("SUPERFICIE").Value, "#,##0")
                    GunaTextBoxCapacite.Text = Format(row.Cells("CAPACITE").Value, "#,##0")

                End If

                'We change the text of the enregistrer butTon from enregistrer to save normql update


                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonEnregistrer.Text = "Sauvegarder"
                Else
                    GunaButtonEnregistrer.Text = "Update"
                End If

                TabControl1.SelectedIndex = 0

            End If

        End If

    End Sub

    '--------------------------------------------LIVE SEARCH --------------------------------------------------------------------

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
        ElseIf GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
        End If

        roomTypeList()

    End Sub

    Private Sub GunaRadioButtonChambre_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonChambre.CheckedChanged

        DataGridViewRoomTypeListe.Columns.Clear()

        If GunaRadioButtonChambre.Checked Then
            GlobalVariable.typeChambreOuSalle = "chambre"
            Functions.SiplifiedClearTextBox(Me)
        End If

        libelleDelaFenetre()

        GunaLabel2.Visible = False
        GunaLabel3.Visible = False
        GunaTextBoxSuperficie.Visible = False
        GunaTextBoxCapacite.Visible = False

    End Sub

    Private Sub libelleDelaFenetre()

        If GlobalVariable.actualLanguageValue = 1 Then

            If TabControl1.SelectedIndex = 0 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "CREATION TYPE DE CHAMBRE"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "CREATION TYPE DE SALLE"
                End If
            Else
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LISTE DES TYPES DE CHAMBRES"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LISTE DES TYPES DE SALLES"
                End If
            End If


        Else


            If TabControl1.SelectedIndex = 0 Then
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "ROOM TYPE CREATION"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "HALL TYPE CREATION"
                End If
            Else
                If GunaRadioButtonChambre.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LISTE OF TYPE OF ROOMS"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GunaLabelGestCompteGeneraux.Text = "LIST OF TYPES OF HALLS"
                End If
            End If


        End If

    End Sub

    Private Sub GunaRadioButtonSalle_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonSalle.CheckedChanged

        DataGridViewRoomTypeListe.Columns.Clear()

        If GunaRadioButtonSalle.Checked Then
            GlobalVariable.typeChambreOuSalle = "salle"
            Functions.SiplifiedClearTextBox(Me)
        End If

        libelleDelaFenetre()

        GunaLabel2.Visible = True
        GunaLabel3.Visible = True
        GunaTextBoxSuperficie.Visible = True
        GunaTextBoxCapacite.Visible = True

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        libelleDelaFenetre()
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If DataGridViewRoomTypeListe.Rows.Count > 0 Then

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Supprimer " & DataGridViewRoomTypeListe.CurrentRow.Cells("CODE TYPE").Value.ToString, "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Else
                dialog = MessageBox.Show("Do you really want to delete " & DataGridViewRoomTypeListe.CurrentRow.Cells("CODE TYPE").Value.ToString, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            End If

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else
                Functions.DeleteRowFromDataGridGeneral(DataGridViewRoomTypeListe, DataGridViewRoomTypeListe.CurrentRow.Cells("CODE TYPE").Value.ToString, "type_chambre", "CODE_TYPE_CHAMBRE")

                DataGridViewRoomTypeListe.Columns.Clear()

                If GunaRadioButtonChambre.Checked Then
                    GlobalVariable.typeChambreOuSalle = "chambre"
                ElseIf GunaRadioButtonSalle.Checked Then
                    GlobalVariable.typeChambreOuSalle = "salle"
                End If

                roomTypeList()

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("You have successfully deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If


            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune ligne à supprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Nothing to be deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Private Sub GunaTextBoxPrix_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPrix.TextChanged

        If GunaCheckBoxPourcentage.Checked Then

            Dim TAUX_CHARGE_FIXE As Double = 0

            If Not Trim(GunaTextBoxTauxChargeFixe.Text).Equals("") Then
                TAUX_CHARGE_FIXE = GunaTextBoxTauxChargeFixe.Text
            End If

            If Not Trim(GunaTextBoxPrix.Text).Equals("") Then

                If Double.Parse(GunaTextBoxPrix.Text) > 0 Then
                    GunaTextBoxMontatnChargeFixe.Text = Format((TAUX_CHARGE_FIXE * GunaTextBoxPrix.Text) / 100, "#,##0")
                End If

            End If

        Else

            '2- LE MONTANT DETERMINE LE POURCENTAGE

            Dim MONTANT_CHARGE_VARIABLE As Double = 0

            If Not Trim(GunaTextBoxMontatnChargeFixe.Text).Equals("") Then
                MONTANT_CHARGE_VARIABLE = GunaTextBoxMontatnChargeFixe.Text
            End If

            If Not Trim(GunaTextBoxPrix.Text).Equals("") Then

                If Double.Parse(GunaTextBoxPrix.Text) > 0 Then
                    GunaTextBoxTauxChargeFixe.Text = Format((MONTANT_CHARGE_VARIABLE * 100) / GunaTextBoxPrix.Text, "#,##0")
                End If

            End If

        End If

    End Sub

    Private Sub GunaTextBoxTauxChargeFixe_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTauxChargeFixe.TextChanged

        If GunaCheckBoxPourcentage.Checked Then

            '1- LE POURCENTAGE DETERMINE LE MONTANT

            Dim TAUX_CHARGE_FIXE As Double = 0

            If Not Trim(GunaTextBoxTauxChargeFixe.Text).Equals("") Then
                TAUX_CHARGE_FIXE = GunaTextBoxTauxChargeFixe.Text
            End If

            If Not Trim(GunaTextBoxPrix.Text).Equals("") Then

                GunaTextBoxMontatnChargeFixe.Text = Format((TAUX_CHARGE_FIXE * GunaTextBoxPrix.Text) / 100, "#,##0")

            End If

        Else

            '2- LE MONTANT DETERMINE LE POURCENTAGE

            'Dim MONTANT_CHARGE_VARIABLE As Double = 0

            If Not Trim(GunaTextBoxMontatnChargeFixe.Text).Equals("") Then
                'MONTANT_CHARGE_VARIABLE = GunaTextBoxMontatnChargeFixe.Text
            End If

            If Not Trim(GunaTextBoxPrix.Text).Equals("") Then

                If Double.Parse(GunaTextBoxPrix.Text) > 0 Then
                    'GunaTextBoxTauxChargeFixe.Text = Format((MONTANT_CHARGE_VARIABLE * 100) / GunaTextBoxPrix.Text, "#,##0")
                End If

            End If

        End If

    End Sub

    Private Sub GunaCheckBoxPourcentage_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxPourcentage.CheckedChanged

        If GunaCheckBoxPourcentage.Checked Then
            GunaTextBoxMontatnChargeFixe.Enabled = False
            GunaTextBoxMontatnChargeFixe.BaseColor = Color.LightPink
            GunaTextBoxTauxChargeFixe.Enabled = True
            GunaTextBoxTauxChargeFixe.BaseColor = Color.White
        Else
            GunaTextBoxMontatnChargeFixe.Enabled = True
            GunaTextBoxTauxChargeFixe.Enabled = False
            GunaTextBoxMontatnChargeFixe.BaseColor = Color.White
            GunaTextBoxTauxChargeFixe.BaseColor = Color.LightPink
        End If

    End Sub

    Private Sub GunaTextBoxMontatnChargeFixe_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontatnChargeFixe.TextChanged, GunaTextBoxMontantVariable.TextChanged

        If Not GunaCheckBoxPourcentage.Checked Then

            '2- LE MONTANT DETERMINE LE POURCENTAGE

            Dim MONTANT_CHARGE_VARIABLE As Double = 0

            If Not Trim(GunaTextBoxMontatnChargeFixe.Text).Equals("") Then
                MONTANT_CHARGE_VARIABLE = GunaTextBoxMontatnChargeFixe.Text
            End If

            If Not Trim(GunaTextBoxPrix.Text).Equals("") Then

                If Double.Parse(GunaTextBoxPrix.Text) > 0 Then
                    GunaTextBoxTauxChargeFixe.Text = Format((MONTANT_CHARGE_VARIABLE * 100) / GunaTextBoxPrix.Text, "#,##0")

                End If

            End If

        End If

        If Not Trim(GunaTextBoxPrix.Text).Equals("") Then
            GunaTextBoxMontantVariable.Text = Format(Double.Parse(GunaTextBoxPrix.Text) - Double.Parse(GunaTextBoxMontatnChargeFixe.Text), "#,##0")
        Else
            GunaTextBoxMontantVariable.Text = 0
        End If

    End Sub

End Class