Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class MainWindowComptabiliteForm

    'Dim connect As New DataBaseManipulation()
    Structure SituationClient

        Dim REFERENCE
        Dim DATE_OPERATION
        Dim NATURE
        Dim LIBELLE
        Dim MONTANT
        Dim MONTANT_SOLDE
        Dim SOLDE

    End Structure

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click

        Functions.exitApplicationThread()

        'Dim dialog As DialogResult

        '       Using form = New Form() With {.TopMost = True}
        '      dialog = MessageBox.Show("Voulez-vous vraiment fermer", "Fermer BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '     End Using

        'If dialog = DialogResult.Yes Then
        'Application.ExitThread()
        'End If
    End Sub

    Dim page As Integer = 1

    Private Sub ReceptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceptionToolStripMenuItem.Click

        MainWindow.GunaDataGridViewResaDashBoard.Columns.Clear()

        Functions.EmtyGlobalVariablesContainingCodeToUpdate()

        MainWindow.ReinitialisationDesDates()

        Me.Activate()

        MainWindow.GunaGroupBoxRoomStatus.Controls.Clear()
        'PanelGraphiques.Controls.Clear()
        MainWindow.GunaGroupBoxStatistiques.Controls.Clear()
        MainWindow.elementsDesChambres()
        MainWindow.contenuStatistique()
        MainWindow.StatistiquesDesChambres()
        MainWindow.StatusDesChambres(page)

        MainWindow.GunaShadowPanelReservation.Hide()
        MainWindow.PanelEnregistrement.Hide()

        MainWindow.PanelTableauDeBords.Show()
        MainWindow.GunaShadowPanelReception.Show()

        MainWindow.Show()

        Me.Close()

    End Sub

    Private Sub MainWindowComptabiliteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.comptabiliteForm(GlobalVariable.actualLanguageValue)
        language.side_menu_compabilite(GlobalVariable.actualLanguageValue)

        GunaComboBoxTypeCaution.SelectedIndex = 0

        GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail

        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail

        Dim menuAccess As New AccessRight()

        menuAccess.accesAuxModules(GlobalVariable.DroitAccesDeUtilisateurConnect, ReceptionToolStripMenuItem, RESERVATIONToolStripMenuItem, SERVICEDETAGEToolStripMenuItem, BarRestaurationToolStripMenuItem, ComptabilitéToolStripMenuItem, ECONOMATToolStripMenuItem, TECHNIQUEToolStripMenuItem, ToolStripMenuItem1)

        menuAccess.administrationDuModule(GlobalVariable.DroitAccesDeUtilisateurConnect, ToolStripMenuItemSession, ToolStripMenuItemConfig, ToolStripMenuItemServTech, ToolStripMenuItemSecurite, ClôturerToolStripMenuItem, ToolStripSeparatorCloture, FermerCaisseToolStripMenuItem, OuvrirCaisseToolStripMenuItem, ToolStripSeparator2)

        GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

        'TITRE DE LA FENETRE
        TabControlComptabilite.SelectedIndex = 1

        'TITRE DE LA FENETRE
        If GlobalVariable.softwareVersion = "barcleshsoftdbdemo" Then
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR") + " (DEMO) "
        Else
            GunaLabelTitreDeLaFenetre.Text = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        End If

        If GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelTabEncours.Text = "LISTE DES COMPTES"
        Else
            GunaLabelTabEncours.Text = "LIST OF ACCOUNTS"
        End If

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FISCALITE") = 0 Then
            GunaCheckBoxFiscalite.Visible = False
        Else
            GunaCheckBoxFiscalite.Visible = True
            GunaTextBoxTauxVisibilite.Text = GlobalVariable.AgenceActuelle.Rows(0)("FISCALITE")
        End If

        Functions.RetablissementDesResteAPayerNegatifEnPositif()

        If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 1 Then
            ReceptionToolStripMenuItem.Visible = False
            RESERVATIONToolStripMenuItem.Visible = False
            SERVICEDETAGEToolStripMenuItem.Visible = False
            TECHNIQUEToolStripMenuItem.Visible = False
            ToolStripMenuItemServTech.Visible = False
        End If

        GunaComboBoxTypeCompte.SelectedIndex = 0
        GunaComboBoxSensSolde.SelectedIndex = 0

    End Sub

    Private Sub RESERVATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESERVATIONToolStripMenuItem.Click

        MainWindow.TabControlHbergement.SelectedIndex = 1
        MainWindow.GunaShadowPanelReception.Hide()
        MainWindow.PanelTableauDeBords.Hide()

        MainWindow.GunaShadowPanelReservation.Show()

        MainWindow.PanelEnregistrement.Show()

        MainWindow.Show()

        Me.Close()

    End Sub

    Private Sub SERVICEDETAGEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SERVICEDETAGEToolStripMenuItem.Click

        GlobalVariable.typeChambreOuSalle = "chambre"

        'RoomForm.TopMost = True
        'RoomForm.Location = New System.Drawing.Point(10, 110)
        'RoomForm.Show()

        MainWindowServiceEtageForm.Visible = True

        Me.Close()

    End Sub

    Private Sub BarRestaurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarRestaurationToolStripMenuItem.Click

        GlobalVariable.typeDeClientAFacturer = "comptoir"

        If Trim(GlobalVariable.AgenceActuelle.Rows(0)("CAISSE_ENREGISTREUSE_1")).Equals("") Then
            BarRestaurantForm.Show()
            BarRestaurantForm.GunaLabelHeader.Text = "COMPTOIR"
        Else
            BarRestaurantCaisseEnregistreuseForm.Show()
            BarRestaurantCaisseEnregistreuseForm.GunaLabelHeader.Text = "COMPTOIR"
        End If

        Me.Close()

    End Sub

    Private Sub ECONOMATToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ECONOMATToolStripMenuItem.Click

        MainWindowEconomat.Show()

        Me.Close()

    End Sub

    Private Sub TECHNIQUEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TECHNIQUEToolStripMenuItem.Click

        MainWindowTechnique.Show()

        Me.Close()

    End Sub

    Private Sub GunaAdvenceButton12_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton12.Click
        TabControlComptabilite.SelectedIndex = 0
    End Sub

    Private Sub GunaAdvenceButton11_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton11.Click
        TabControlComptabilite.SelectedIndex = 1
    End Sub

    Private Sub GunaAdvenceButton10_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonAgedBillsButton.Click
        TabControlComptabilite.SelectedIndex = 2
    End Sub

    Private Sub GunaAdvenceButton25_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton25.Click
        TabControlComptabilite.SelectedIndex = 3
    End Sub

    Private Sub GunaAdvenceButton29_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton29.Click
        GunaDateTimePickerDebutCompta.Value = GlobalVariable.DateDeTravail
        GunaDateTimePickerFinCompta.Value = GlobalVariable.DateDeTravail
        TabControlComptabilite.SelectedIndex = 5
    End Sub


    Private Sub TabControlComptabilite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlComptabilite.SelectedIndexChanged

        If TabControlComptabilite.SelectedIndex = 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "GESTION DES COMPTES"
            Else
                GunaLabelTabEncours.Text = "ACCOUNT MANAGEMENT"
            End If

            If Trim(GunaButtonAjouterCompte.Text).Equals("Enregistrer") Or Trim(GunaButtonAjouterCompte.Text).Equals("Save") Then
                GunaTextBoxNumeroCompte.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", "41"))
            End If

        ElseIf TabControlComptabilite.SelectedIndex = 1 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "LISTE DES COMPTES"
            Else
                GunaLabelTabEncours.Text = "LIST OF ACOUNTS"
            End If
        ElseIf TabControlComptabilite.SelectedIndex = 2 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "FACTURES AGEES"
            Else
                GunaLabelTabEncours.Text = "OLDER BILLS"
            End If
        ElseIf TabControlComptabilite.SelectedIndex = 3 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "CAUTIONS"
            Else
                GunaLabelTabEncours.Text = "COVER"
            End If
        ElseIf TabControlComptabilite.SelectedIndex = 4 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "JOURNAL"
            Else
                GunaLabelTabEncours.Text = "HISTORY"
            End If
        ElseIf TabControlComptabilite.SelectedIndex = 5 Then
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "RAPPORTS"
            Else
                GunaLabelTabEncours.Text = "REPORTS"
            End If
        ElseIf TabControlComptabilite.SelectedIndex = 6 Then
            GunaDataGridViewLettreDeRelance.Columns.Clear()
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "LETTRES DE RELANCE"
            Else
                GunaLabelTabEncours.Text = "REMINDER LETTERS"
            End If
        ElseIf TabControlComptabilite.SelectedIndex = 7 Then
            GunaDataGridViewFacturesRegle.Columns.Clear()
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "FACTURES REGLEES"
            Else
                GunaLabelTabEncours.Text = "CLEARED BILLS"
            End If
        ElseIf TabControlComptabilite.SelectedIndex = 7 Then
            GunaDataGridViewFacturesRegle.Columns.Clear()
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaLabelTabEncours.Text = "CAISSE"
            Else
                GunaLabelTabEncours.Text = "CASHIER"
            End If
        End If

        DataGridViewListeDesComptes.Columns.Clear()
        GunaDataGridViewJournalLIste.Columns.Clear()
        GunaDataGridViewCaution.Columns.Clear()
        GunaDataGridViewFactureAgee.Columns.Clear()
        GunaDataGridViewJournalLIste.Columns.Clear()
        GunaDataGridViewLettreDeRelance.Columns.Clear()

    End Sub

    Private Sub GunaButtonAjouterCompte_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterCompte.Click

        Dim NUMERO_COMPTE = GunaTextBoxNumeroCompte.Text

        Dim INTITULE = GunaTextBoxIntituleCompte.Text
        Dim TOTAL_DEBIT = 0
        Dim TOTAL_CREDIT = 0
        Dim SOLDE_COMPTE = 0
        Dim DATE_CREATION = GlobalVariable.DateDeTravail
        Dim TYPE_DE_COMPTE As String = GunaComboBoxTypeCompte.SelectedItem
        Dim SENS_DU_SOLDE As String = GunaComboBoxSensSolde.SelectedItem

        If Not Trim(GunaTextBoxIntituleCompte.Text).Equals("") Then


            Dim ETAT_DU_COMPTE As Integer = 0

            If GunaCheckBoxActivationDesactivationDuCompte.Checked Then
                ETAT_DU_COMPTE = 1
            Else
                ETAT_DU_COMPTE = 0
            End If

            Dim PERSONNE_A_CONTACTER = Trim(GunaTextBoxPersonneAContacter.Text)
            Dim CONTACT_PAIEMENT = Trim(GunaTextBoxContactPourPaiement.Text)
            Dim ADRESSE_DE_FACTURATION = Trim(GunaTextBoxAdresseDeFacturation.Text)
            Dim PLAFONDS_DU_COMPTE As String = Double.Parse(GunaTextBoxMontantPlafondsDuCompte.Text)

            Dim DELAI_DE_PAIEMENT = Trim(NumericUpDownDelaiDePaiement.Text)

            Dim account As New GeneralAccount()

            'company verifyfields function
            If (True) Then

                'Code field empty, then it is a new entry
                If (GunaButtonAjouterCompte.Text = "Enregistrer") Or (GunaButtonAjouterCompte.Text = "Save") Then
                    'check if the new entry  alreaday exist before insertion
                    If Not account.accountExists(NUMERO_COMPTE, INTITULE) Then
                        'As the new entry does not exist then we insert it, and check the result
                        If account.Insert(INTITULE, NUMERO_COMPTE, TOTAL_DEBIT, TOTAL_CREDIT, SOLDE_COMPTE, DATE_CREATION, TYPE_DE_COMPTE, SENS_DU_SOLDE, PLAFONDS_DU_COMPTE, ETAT_DU_COMPTE, PERSONNE_A_CONTACTER, CONTACT_PAIEMENT, ADRESSE_DE_FACTURATION, DELAI_DE_PAIEMENT) Then

                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Nouveau compte enregistré avec succès", "Création de compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("New Account created", "Account creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Else
                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Un problème lors de la création !!", "Création de compte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                MessageBox.Show("Problem during creation !!", "Account creation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If

                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Ce compte  existe déjà, Essayer à nouveau", "Création de compte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            MessageBox.Show("This account already exist, Try again", "Account creation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If

                    Functions.SiplifiedClearTextBox(Me)

                    NumericUpDownDelaiDePaiement.Text = 0
                    GunaTextBoxMontantPlafondsDuCompte.Text = 0

                Else
                    'label field not empty so, we update the existing entry using the code
                    If (GunaButtonAjouterCompte.Text = "Sauvegarder") Or (GunaButtonAjouterCompte.Text = "Update") Then
                        If account.Update(INTITULE, NUMERO_COMPTE, TOTAL_DEBIT, TOTAL_CREDIT, SOLDE_COMPTE, DATE_CREATION, TYPE_DE_COMPTE, SENS_DU_SOLDE, PLAFONDS_DU_COMPTE, ETAT_DU_COMPTE, PERSONNE_A_CONTACTER, CONTACT_PAIEMENT, ADRESSE_DE_FACTURATION, DELAI_DE_PAIEMENT) Then
                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Compte Mise à jour !! avec succès", "Création de compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Account updated successfully", "Account update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Problème lors de la misa à jour du Compte!!", "Mise à du compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Problem when updating!!", "Account update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Remplir tous les champs!!", "Mise à du compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Please fill all the fields", "Account update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If

                    TabControlComptabilite.SelectedIndex = 1

                    If GlobalVariable.actualLanguageValue = 1 Then
                        GunaButtonAjouterCompte.Text = "Enregistrer"
                    Else
                        GunaButtonAjouterCompte.Text = "Save"
                    End If

                    Functions.SiplifiedClearTextBox(Me)

                    NumericUpDownDelaiDePaiement.Text = 0
                    GunaTextBoxMontantPlafondsDuCompte.Text = 0

                End If

            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Bien vouloir remplir tous les champs!!", "Account Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Please fill all the fields!!", "Account Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Account Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please fill all the fields!!", "Account Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If


    End Sub

    Private Sub DataGridViewListeDesComptes_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewListeDesComptes.CellDoubleClick

        If e.RowIndex >= 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonAjouterCompte.Text = "Sauvegarder"
            Else
                GunaButtonAjouterCompte.Text = "Update"
            End If

            Dim row As DataGridViewRow
            row = Me.DataGridViewListeDesComptes.Rows(e.RowIndex)

            GunaTextBoxIntituleCompte.Text = row.Cells("INTITULE").Value.ToString
            GunaComboBoxTypeCompte.SelectedItem = row.Cells("TYPE DE COMPTE").Value.ToString
            GunaComboBoxSensSolde.SelectedItem = row.Cells("SENS DU SOLDE").Value.ToString
            GunaTextBoxNumeroCompte.Text = row.Cells("NUMERO DE COMPTE").Value.ToString
            Dim NUM_COMPTE As String = row.Cells("NUMERO DE COMPTE").Value.ToString

            'ATTRIBUTION DES INFORMATION DE COMPTE FINANCE

            Dim compte As DataTable = Functions.getElementByCode(Trim(GunaTextBoxNumeroCompte.Text), "compte", "NUMERO_COMPTE")

            If compte.Rows.Count > 0 Then

                GunaTextBoxPersonneAContacter.Text = Trim(compte.Rows(0)("PERSONNE_A_CONTACTER")) ' INTITULE DE COMPTE
                GunaTextBoxContactPourPaiement.Text = Trim(compte.Rows(0)("CONTACT_PAIEMENT")) ' INTITULE DE COMPTE
                GunaTextBoxAdresseDeFacturation.Text = Trim(compte.Rows(0)("ADRESSE_DE_FACTURATION")) ' INTITULE DE COMPTE

                GunaTextBoxMontantPlafondsDuCompte.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0")

                NumericUpDownDelaiDePaiement.Text = Trim(compte.Rows(0)("DELAI_DE_PAIEMENT"))

                Dim DATE_CREATION As Date = CDate(compte.Rows(0)("DATE_CREATION")).ToShortDateString
                Dim DATE_ACTUEL As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

                GunaTextBoxJoursExistence.Text = CType((DATE_ACTUEL - DATE_CREATION).TotalDays, Int32)

                Dim ETAT_DU_COMPTE As Integer = compte.Rows(0)("ETAT_DU_COMPTE")
                Dim PLAFONDS As Double = compte.Rows(0)("PLAFONDS_DU_COMPTE")

                gestionActivationDesComptes(ETAT_DU_COMPTE, PLAFONDS)

                If compte.Rows(0)("ETAT_DU_COMPTE") = 1 Then
                    GunaCheckBoxActivationDesactivationDuCompte.Checked = True
                Else
                    GunaCheckBoxActivationDesactivationDuCompte.Checked = False
                    GunaCheckBoxActivationDesactivationDuCompte.Enabled = False
                End If

                Dim detenteur As DataTable = Functions.getElementByCode(NUM_COMPTE, "client", "NUM_COMPTE")

                If detenteur.Rows.Count > 0 Then
                    'ON VERIFIE SI LE NUMERO_DE_COMPTE EST ASSOCIE A UN CLIENT
                    Dim CA As Double = 0

                    Dim CODE_CLIENT As String = detenteur.Rows(0)("CODE_CLIENT")
                    GunaTextBoxNomClient.Text = detenteur.Rows(0)("NOM_PRENOM")
                    GunaTextBoxProfession.Text = detenteur.Rows(0)("PROFESSION")

                    Dim CODE_ENTREPRISE As String = detenteur.Rows(0)("CODE_ENTREPRISE")

                    Dim entreprise As DataTable = Functions.getElementByCode(CODE_ENTREPRISE, "client", "CODE_CLIENT")

                    Dim factures As DataTable = Functions.getElementByCode(CODE_CLIENT, "facture", "CODE_CLIENT")

                    If entreprise.Rows.Count > 0 Then
                        'ON VERIFIE SI LE CLIENT EST ASSOCIE A UNE ENTREPRISE
                        GunaTextBoxEntreprise.Text = entreprise.Rows(0)("NOM_PRENOM")
                        CODE_CLIENT = entreprise.Rows(0)("CODE_CLIENT")

                        factures = Functions.getElementByCode(CODE_CLIENT, "facture", "CODE_CLIENT")

                    End If

                    If factures.Rows.Count > 0 Then

                        Dim ChiffresAffaire As Double = 0
                        For j = 0 To factures.Rows.Count - 1
                            ChiffresAffaire += factures.Rows(j)("MONTANT_TTC")
                        Next

                        CA = Format(ChiffresAffaire, "#,##0")

                    End If

                    GunaTextBoxCA.Text = Format(CA, "#,##0")

                End If

            End If

            TabControlComptabilite.SelectedIndex = 0

        End If

    End Sub

    Public Function updateEtatCompte(ByVal NUMERO_COMPTE As String, ByVal ETAT_DU_COMPTE As Integer) As Boolean

        Dim updateQuery As String = "UPDATE `compte` SET `ETAT_DU_COMPTE`=@ETAT_DU_COMPTE WHERE NUMERO_COMPTE=@NUMERO_COMPTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE

        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.VarChar).Value = NUMERO_COMPTE

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Sub gestionActivationDesComptes(ByVal ETAT_DU_COMPTE As Integer, ByVal PLAFONDS As Double)

        Dim PLAFONDS_COMPARE As Double = 250000

        If ETAT_DU_COMPTE = 1 Then

            GunaCheckBoxActivationDesactivationDuCompte.Enabled = True

            GunaButtonvERIFIER.Visible = False
            PictureBoxNext1.Visible = False
            GunaButtonActivation.Visible = False

        ElseIf ETAT_DU_COMPTE = 0 Then

            GunaCheckBoxActivationDesactivationDuCompte.Enabled = False

            If PLAFONDS <= PLAFONDS_COMPARE Then

                'ACTIVATION DIRECTE
                GunaButtonvERIFIER.Visible = True

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonvERIFIER.Text = "Activer"
                Else
                    GunaButtonvERIFIER.Text = "Activate"
                End If

                PictureBoxNext1.Visible = False
                GunaButtonActivation.Visible = False

            Else

                'ACTIVATION PROCEDURAL
                GunaButtonvERIFIER.Visible = True

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonvERIFIER.Text = "Vérifier"
                Else
                    GunaButtonvERIFIER.Text = "Checked"
                End If
                PictureBoxNext1.Visible = False
                GunaButtonActivation.Visible = False

            End If


        ElseIf ETAT_DU_COMPTE = 2 Then

            GunaCheckBoxActivationDesactivationDuCompte.Enabled = False

            GunaButtonvERIFIER.Visible = True
            GunaButtonvERIFIER.Enabled = False
            'GunaButtonvERIFIER.Text = "Vérifier"

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonvERIFIER.Text = "Vérifier"
            Else
                GunaButtonvERIFIER.Text = "Checked"
            End If
            PictureBoxNext1.Visible = True
            GunaButtonActivation.Visible = True

        End If

    End Sub

    Private Sub GunaButtonAfficherLaListeDesComptes_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLaListeDesComptes.Click

        Dim account As New GeneralAccount()

        Dim ETAT_DU_COMPTE As Integer = 1

        If GunaCheckBoxNonActiver.Checked Then
            ETAT_DU_COMPTE = 0
        End If

        If GunaCheckBoxAttenteActivation.Checked Then
            ETAT_DU_COMPTE = 2
        End If

        If GunaCheckBoxToutes.Checked Then
            ETAT_DU_COMPTE = 1
        End If

        DataGridViewListeDesComptes.DataSource = account.listeDesComptesActifOuPas(ETAT_DU_COMPTE)

        DataGridViewListeDesComptes.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewListeDesComptes.Columns("INTITULE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        DataGridViewListeDesComptes.Columns("DEBIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewListeDesComptes.Columns("DEBIT").DefaultCellStyle.Format = "#,##0"

        DataGridViewListeDesComptes.Columns("CREDIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewListeDesComptes.Columns("CREDIT").DefaultCellStyle.Format = "#,##0"

        DataGridViewListeDesComptes.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewListeDesComptes.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"

        DataGridViewListeDesComptes.Columns("CODE_CLIENT").Visible = False

    End Sub

    '---------------------------------- GESTION DU JOURNAL -----------------------------
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonSaveJournal.Click

        Dim CODE_JOURNAL = GunaTextBoxCodeJOurnal.Text

        Dim LIBELLE_JOURNAL = GunaTextBoxLibelleJournal.Text

        Dim DATE_CREATION = GlobalVariable.DateDeTravail


        Dim account As New GeneralAccount()

        'company verifyfields function
        If (True) Then

            'Code field empty, then it is a new entry
            If (GunaButtonSaveJournal.Text = "Enregistrer") Or (GunaButtonSaveJournal.Text = "Save") Then
                'check if the new entry  alreaday exist before insertion
                If Not account.journaltExists(CODE_JOURNAL, LIBELLE_JOURNAL) Then
                    'As the new entry does not exist then we insert it, and check the result
                    If account.InsertJournal(CODE_JOURNAL, LIBELLE_JOURNAL, DATE_CREATION) Then

                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Nouveau Journal enregistré avec succès", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else

                        End If

                        'We empty the fields

                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Un problème lors de la création !!", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        Else

                        End If
                    End If

                Else
                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Ce Journal  existe déjà, Essayer à nouveau", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                    End If
                End If
            Else
                'label field not empty so, we update the existing entry using the code
                If (GunaButtonSaveJournal.Text = "Sauvegarder") Or (GunaButtonSaveJournal.Text = "Update") Then

                    If account.UpdateJournal(CODE_JOURNAL, LIBELLE_JOURNAL) Then
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Journal Mis à jour !! avec succès", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                        End If

                    Else
                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Problème lors de la mise à jour du Journal!!", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else

                        End If
                    End If
                Else
                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Remplir tous les champs!!", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                    End If

                End If

                'TabControlComptabilite.SelectedIndex = 1

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonSaveJournal.Text = "Enregistrer"

                Else
                    GunaButtonSaveJournal.Text = "Save"

                End If

            End If
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création d'une categorie client", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

            End If

        End If

        Functions.SiplifiedClearTextBox(Me)
        GunaDataGridViewJournalLIste.Columns.Clear()

    End Sub

    Private Sub GunaDataGridViewJournalLIste_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewJournalLIste.CellDoubleClick
        If e.RowIndex >= 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonSaveJournal.Text = "Sauvegarder"
            Else
                GunaButtonSaveJournal.Text = "Update"
            End If


            Dim row As DataGridViewRow
                row = Me.GunaDataGridViewJournalLIste.Rows(e.RowIndex)

                GunaTextBoxCodeJOurnal.Text = row.Cells("CODE JOURNAL").Value.ToString
                GunaTextBoxLibelleJournal.Text = row.Cells("LIBELLE JOURNAL").Value.ToString

            End If
    End Sub

    Private Sub GunaButtonAfficherJournal_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherJournal.Click
        Dim account As New GeneralAccount()
        GunaDataGridViewJournalLIste.DataSource = account.listeDesJournaux()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaLabel20_Click(sender As Object, e As EventArgs) Handles GunaLabelNotification.Click
        NotificationsForm.GunaTextBoxFromWhichWindow.Text = "finance"
        NotificationsForm.Close()
        NotificationsForm.TopMost = True
        NotificationsForm.Show()

        NotificationsForm.GunaLabelTitle.Text = "BOITE DE RECEPTION : MESSAGES NON LUS"

        NotificationsForm.TopMost = True
        NotificationsForm.Show()

        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then

            NotificationsForm.GunaDataGridViewNotification.Columns.Clear()

            NotificationsForm.GunaDataGridViewNotification.DataSource = notifications

            NotificationsForm.GunaDataGridViewNotification.Columns("ID_NOTIFICATION").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_PROFIL").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("CODE_AGENCE").Visible = False
            NotificationsForm.GunaDataGridViewNotification.Columns("ETAT_NOTIFCATION").Visible = False

        End If

    End Sub

    'REGLEMENTS ET LETTRAGE
    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        ReglementLettrageForm.Close()
        ReglementLettrageForm.Show()
        ReglementLettrageForm.TopMost = True
    End Sub

    'IMPRESSION DE LA LISTE DES COMPTES
    Private Sub GunaButtonImprimerListeDesComptes_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerListeDesComptes.Click

        If DataGridViewListeDesComptes.Rows.Count > 0 Then
            Impression.listeDesComptesDebiteurs(DataGridViewListeDesComptes)
        End If

    End Sub

    'ENTREPRISE POUR RAPPORTS
    Private Sub GunaTextBoxNom_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNom.TextChanged


        GunaDataGridViewDetails.Visible = True

        Dim query As String = "SELECT NOM_PRENOM, CODE_CLIENT FROM client WHERE NOM_PRENOM LIKE '%" & GunaTextBoxNom.Text & "%' AND TYPE_CLIENT = @TYPE_CLIENT"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        If GlobalVariable.actualLanguageValue = 1 Then
            command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "ENTREPRISE"
        Else
            command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "COMPANY"
        End If

        Dim adapter As New MySqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewDetails.DataSource = table
        Else
            GunaDataGridViewDetails.Columns.Clear()
            GunaDataGridViewDetails.Visible = False
        End If

        If GunaTextBoxNom.Text = "" Then
            GunaDataGridViewDetails.Visible = False
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaDataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewDetails.CellClick

        GunaDataGridViewDetails.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewDetails.Rows(e.RowIndex)

            Dim CodeClient As String = row.Cells("CODE_CLIENT").Value.ToString

            GunaTextBoxCodeEntreprise.Text = CodeClient


            Dim client As DataTable = Functions.getElementByCode(CodeClient, "client", "CODE_CLIENT")

            If client.Rows.Count > 0 Then

                'GunaTextBoxClientAFacturer.Text = client.Rows(0)("NOM_PRENOM")

                Dim compte As DataTable = Functions.getElementByCode(Trim(CodeClient), "compte", "CODE_CLIENT")

                If compte.Rows.Count > 0 Then

                    'GunaTextBoxCompteDebiteur.Text = compte.Rows(0)("NUMERO_COMPTE")

                    'GunaTextBoxSoldeCompte.Text = compte.Rows(0)("SOLDE_COMPTE")
                    'GunaTextBoxPersonneAContacter.Text = compte.Rows(0)("PERSONNE_A_CONTACTER")
                    'GunaTextBoxContactPaiement.Text = compte.Rows(0)("CONTACT_PAIEMENT")
                    'GunaTextBoxAdressePaiement.Text = compte.Rows(0)("ADRESSE_DE_FACTURATION")
                    'GunaTextBoxDelaiPaiement.Text = compte.Rows(0)("DELAI_DE_PAIEMENT")

                    'GunaTextBoxPlafonds.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0")

                End If

            End If

        End If

    End Sub

    Dim reportTotPrint As String = ""

    'LISTE DES RAPPORTS
    Private Sub GunaButtonEtatDesChambres_Click_1(sender As Object, e As EventArgs) Handles GunaButtonEtatDesChambres.Click
        reportTotPrint = "relance"

        PanelApport.Visible = True

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "LETTRES DE RELANCES"

        Else
            LabelTypeDeRapport.Text = "REMINDER LETTERS"

        End If

    End Sub

    Private Sub GunaButton12_CLICK(sender As Object, e As EventArgs) Handles GunaButton12.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "MOVEMENTS DE STOCK"

        Else
            LabelTypeDeRapport.Text = "STOCK MOVEMENTS"

        End If

        reportTotPrint = "movements"
        PanelApport.Visible = True
    End Sub

    Private Sub GunaButton13_Click(sender As Object, e As EventArgs) Handles GunaButton13.Click
        LabelTypeDeRapport.Text = "BALANCE"
        reportTotPrint = "balance"
        PanelApport.Visible = True
    End Sub

    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs) Handles GunaButton2.Click

        index = 0
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "HISTORIQUES DES FACTURES"

        Else
            LabelTypeDeRapport.Text = "INVOICE HISTORY"

        End If
        reportTotPrint = "factures"
        PanelApport.Visible = True

        datagridAfiicher(index)

    End Sub

    Private Sub GunaButton18_Click_1(sender As Object, e As EventArgs) Handles GunaButton18.Click

        index = 1

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "FONDS SORTIES"
        Else
            LabelTypeDeRapport.Text = "FUNDS OUTPUT"

        End If
        reportTotPrint = "fondsSorties"
        PanelApport.Visible = True
        datagridAfiicher(index)

    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click

        index = 2
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "FONDS ENTREES"
        Else
            LabelTypeDeRapport.Text = "FUNDS INPUT"
        End If

        reportTotPrint = "fondsEntrees"
        PanelApport.Visible = True
        datagridAfiicher(index)

    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click

        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "COMPTES FOURNISSEURS"

        Else
            LabelTypeDeRapport.Text = "ACCOUNTS PAYABLE"

        End If
        reportTotPrint = "compteFournisseur"
        PanelApport.Visible = True

    End Sub

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click
        index = 3
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "RECETTES ENTREES"
        Else
            LabelTypeDeRapport.Text = "INCOMING REVENUE"
        End If
        reportTotPrint = "recettesEntrees"
        PanelApport.Visible = True
        datagridAfiicher(index)
    End Sub

    Private Sub GunaButton19_Click(sender As Object, e As EventArgs) Handles GunaButton19.Click
        index = 4
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "TRANSACTIONS TERMINEES"

        Else
            LabelTypeDeRapport.Text = "COMPLETED TRANSACTIONS"
        End If
        reportTotPrint = "transactionsTerminees"
        PanelApport.Visible = True

        datagridAfiicher(index)

    End Sub

    Private Sub GunaButton11_Click(sender As Object, e As EventArgs) Handles GunaButton11.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "JOURNAL DES VENTES"

        Else
            LabelTypeDeRapport.Text = "SALES LOG"
        End If

        reportTotPrint = "ventes"
        PanelApport.Visible = True
    End Sub

    Private Sub GunaButton10_Click(sender As Object, e As EventArgs) Handles GunaButton10.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "JOURNAL DE CAISSE"

        Else
            LabelTypeDeRapport.Text = "CASHIER LOG"
        End If
        reportTotPrint = "journalDeCaisse"
        PanelApport.Visible = True
    End Sub

    Private Sub GunaButton9_Click(sender As Object, e As EventArgs) Handles GunaButton9.Click

        index = 5
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "JOURNAL BANCAIRE"

        Else
            LabelTypeDeRapport.Text = "BANK LOG"

        End If
        reportTotPrint = "journalDeBanque"
        PanelApport.Visible = True

        datagridAfiicher(index)
        Banques()

    End Sub

    Private Sub affichageInfoBanque(ByVal index As Integer)

        If index = 5 Then
            GunaComboBoxBanqueEmettrice.Visible = True
            LabelBanque.Visible = True
        Else
            GunaComboBoxBanqueEmettrice.Visible = False
            LabelBanque.Visible = False
        End If

    End Sub

    Private Sub GunaButton8_Click(sender As Object, e As EventArgs) Handles GunaButton8.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            LabelTypeDeRapport.Text = "TAXES SEJOURS COLLECTEES"

        Else
            LabelTypeDeRapport.Text = "TOURIST TAXES COLLECTED"

        End If
        reportTotPrint = "taxesSejours"
        PanelApport.Visible = True
    End Sub

    'LETTRE DE RELANCE
    Private Sub GunaAdvenceButtonRelance_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonRelance.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelTabEncours.Text = "LETTRES DE RELANCE"
        Else
            GunaLabelTabEncours.Text = "REMINDER LETTERS"
        End If

        TabControlComptabilite.SelectedIndex = 6

    End Sub

    'IMPRESSION DES DOCUMENTS DE RELANCE
    Private Sub GunaDataGridViewLettreDeRelance_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewLettreDeRelance.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewLettreDeRelance.Rows(e.RowIndex)

            Dim ENTREPRISE As String = row.Cells("NOM_CLIENT").Value.ToString
            Dim NUMERO_FACTURE As String = row.Cells("REFERENCE_LETTRE").Value.ToString
            Dim LIBELLE_FACTURE As String = row.Cells("LIBELLE_LETTRE").Value.ToString
            Dim DATE_FACTURE As Date = row.Cells("DATE_LETTRE").Value.ToString
            Dim SOLDE As Double = row.Cells("SOLDE_LETTRE").Value * -1 ' POUR NE PAS AFFICHER DE SOLDE NEGATIF

            Dim RELANCE As Integer = 1

            Dim facture As New Facture()

            facture.updateFactureApresRelance(NUMERO_FACTURE, RELANCE)

            Impression.lettreDeRelance(ENTREPRISE, NUMERO_FACTURE, LIBELLE_FACTURE, DATE_FACTURE, SOLDE)

            GunaDataGridViewLettreDeRelance.Columns.Clear()
            GunaDataGridViewLettreDeRelance.Rows.Clear()

        End If

    End Sub

    ''AFFICHER LES FACTURES REGLES
    Private Sub AfficherFactureRegle()

        GunaDataGridViewFacturesRegle.Rows.Clear()
        GunaDataGridViewFacturesRegle.Columns.Clear()

        Dim Facture As New Facture()

        Dim DateDeTravail As Date = GlobalVariable.DateDeTravail

        Dim listeDesFactures As DataTable = Facture.factureReglee(GunaDateTimePickerDebut.Value, GunaDateTimePickerFin.Value)

        Dim NombreDeJourPasse As Integer = 0

        'AJOUT DES COLUMNS

        If listeDesFactures.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaDataGridViewFacturesRegle.Columns.Add("REFERENCE_LETTRE", "REFERENCE")
                GunaDataGridViewFacturesRegle.Columns.Add("DATE_LETTRE", "DATE FACTURE")
                GunaDataGridViewFacturesRegle.Columns.Add("LIBELLE_LETTRE", "LIBELLE")
                GunaDataGridViewFacturesRegle.Columns.Add("NOM_CLIENT", "ENTREPRISE")
                GunaDataGridViewFacturesRegle.Columns.Add("DEBIT_LETTRE", "DEBIT")
                GunaDataGridViewFacturesRegle.Columns.Add("CREDIT_LETTRE", "CREDIT")
                GunaDataGridViewFacturesRegle.Columns.Add("SOLDE_LETTRE", "SOLDE")
                GunaDataGridViewFacturesRegle.Columns.Add("LIBELLE_DELAI", "DELAI")
                GunaDataGridViewFacturesRegle.Columns.Add("RELANCE", "RELANCE FAITE")
            Else
                GunaDataGridViewFacturesRegle.Columns.Add("REFERENCE_LETTRE", "REFERENCE")
                GunaDataGridViewFacturesRegle.Columns.Add("DATE_LETTRE", "BILLING DATE")
                GunaDataGridViewFacturesRegle.Columns.Add("LIBELLE_LETTRE", "NAME")
                GunaDataGridViewFacturesRegle.Columns.Add("NOM_CLIENT", "COMPANY")
                GunaDataGridViewFacturesRegle.Columns.Add("DEBIT_LETTRE", "DEBIT")
                GunaDataGridViewFacturesRegle.Columns.Add("CREDIT_LETTRE", "CREDIT")
                GunaDataGridViewFacturesRegle.Columns.Add("SOLDE_LETTRE", "BALANCE")
                GunaDataGridViewFacturesRegle.Columns.Add("LIBELLE_DELAI", "DEADLINE")
                GunaDataGridViewFacturesRegle.Columns.Add("RELANCE", "REMINDED")
            End If



            Dim DATE_DU_JOUR As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

            For i = 0 To listeDesFactures.Rows.Count - 1

                Dim DATE_CREATION_FACTURE As Date = CDate(listeDesFactures.Rows(i)("DATE")).ToShortDateString

                NombreDeJourPasse = DateDiff(DateInterval.Day, DATE_CREATION_FACTURE, DATE_DU_JOUR)

                Dim JOUR As String = "jour"

                Dim RELANCE As String = "NON"

                If GlobalVariable.actualLanguageValue = 0 Then
                    JOUR = "day"
                    RELANCE = "NO"
                End If

                If listeDesFactures.Rows(i)("RELANCE") = 1 Then
                    RELANCE = "OUI"
                End If

                If listeDesFactures.Rows(i)("DELAI") > 1 Then
                    JOUR = "jours"
                    If GlobalVariable.actualLanguageValue = 0 Then
                        JOUR = "days"
                    End If
                End If



                'SI LE NOMBRE DE JOUR PASSE EST SUPERIEUR AU DELAI ALORS IL DOIT ETRE RELANCE
                'If NombreDeJourPasse >= listeDesFactures.Rows(i)("DELAI") Then

                Dim SOLDE As Double = listeDesFactures.Rows(i)("MONTANT SOLDE") - listeDesFactures.Rows(i)("MONTANT")

                'ON NE DOIT PAS AFFICHER LES FACTURES REGLES
                If SOLDE >= 0 Then

                    GunaDataGridViewFacturesRegle.Rows.Add(listeDesFactures.Rows(i)("REFERENCE"), Date.Parse(listeDesFactures.Rows(i)("DATE")).ToShortDateString, listeDesFactures.Rows(i)("LIBELLE"), listeDesFactures.Rows(i)("ENTREPRISE"), listeDesFactures.Rows(i)("MONTANT"), listeDesFactures.Rows(i)("MONTANT SOLDE"), SOLDE, listeDesFactures.Rows(i)("DELAI") & " " & JOUR, RELANCE)

                End If

            Next

            GunaDataGridViewFacturesRegle.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            GunaDataGridViewFacturesRegle.DefaultCellStyle.SelectionForeColor = Color.White

            GunaDataGridViewFacturesRegle.Columns("LIBELLE_LETTRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            GunaDataGridViewFacturesRegle.Columns("LIBELLE_DELAI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewFacturesRegle.Columns("LIBELLE_DELAI").Visible = False

            GunaDataGridViewFacturesRegle.Columns("NOM_CLIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            GunaDataGridViewFacturesRegle.Columns("DEBIT_LETTRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFacturesRegle.Columns("DEBIT_LETTRE").DefaultCellStyle.Format = "#,##0"

            GunaDataGridViewFacturesRegle.Columns("CREDIT_LETTRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFacturesRegle.Columns("CREDIT_LETTRE").DefaultCellStyle.Format = "#,##0"

            GunaDataGridViewFacturesRegle.Columns("SOLDE_LETTRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFacturesRegle.Columns("SOLDE_LETTRE").DefaultCellStyle.Format = "#,##0"

            GunaDataGridViewFacturesRegle.Columns("RELANCE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GunaDataGridViewFacturesRegle.Columns("RELANCE").Visible = False

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune facture réglée en date du " & GlobalVariable.DateDeTravail, "Gestion des relances", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No Bill cleared on the " & GlobalVariable.DateDeTravail, "Reminder Management", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        End If

    End Sub

    'AFFICHER LES LETTRES DE RELANCES
    Private Sub AfficherLettredeRelance_Click(sender As Object, e As EventArgs) Handles AfficherLettredeRelance.Click

        GunaDataGridViewLettreDeRelance.Rows.Clear()
        GunaDataGridViewLettreDeRelance.Columns.Clear()

        Dim Facture As New Facture()

        Dim DateDeTravail As Date = GlobalVariable.DateDeTravail

        Dim listeDesFactures As DataTable = Facture.lettreDeRelance(DateDeTravail)

        Dim NombreDeJourPasse As Integer = 0

        'AJOUT DES COLUMNS

        If listeDesFactures.Rows.Count > 0 Then

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaDataGridViewLettreDeRelance.Columns.Add("REFERENCE_LETTRE", "REFERENCE")
                GunaDataGridViewLettreDeRelance.Columns.Add("DATE_LETTRE", "DATE FACTURE")
                GunaDataGridViewLettreDeRelance.Columns.Add("LIBELLE_LETTRE", "LIBELLE")
                GunaDataGridViewLettreDeRelance.Columns.Add("NOM_CLIENT", "CLIENT")
                GunaDataGridViewLettreDeRelance.Columns.Add("DEBIT_LETTRE", "DEBIT")
                GunaDataGridViewLettreDeRelance.Columns.Add("CREDIT_LETTRE", "CREDIT")
                GunaDataGridViewLettreDeRelance.Columns.Add("SOLDE_LETTRE", "SOLDE")
                GunaDataGridViewLettreDeRelance.Columns.Add("LIBELLE_DELAI", "DELAI")
                GunaDataGridViewLettreDeRelance.Columns.Add("RELANCE", "RELANCE FAITE")
            Else
                GunaDataGridViewLettreDeRelance.Columns.Add("REFERENCE_LETTRE", "REFERENCE")
                GunaDataGridViewLettreDeRelance.Columns.Add("DATE_LETTRE", "BILLING DATE")
                GunaDataGridViewLettreDeRelance.Columns.Add("LIBELLE_LETTRE", "NAME")
                GunaDataGridViewLettreDeRelance.Columns.Add("NOM_CLIENT", "CLIENT")
                GunaDataGridViewLettreDeRelance.Columns.Add("DEBIT_LETTRE", "DEBIT")
                GunaDataGridViewLettreDeRelance.Columns.Add("CREDIT_LETTRE", "CREDIT")
                GunaDataGridViewLettreDeRelance.Columns.Add("SOLDE_LETTRE", "BALANCE")
                GunaDataGridViewLettreDeRelance.Columns.Add("LIBELLE_DELAI", "DEADLINE")
                GunaDataGridViewLettreDeRelance.Columns.Add("RELANCE", "REMINDED")
            End If

            Dim DATE_DU_JOUR As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString

            If listeDesFactures.Rows.Count > 0 Then

                For i = 0 To listeDesFactures.Rows.Count - 1

                    Dim DATE_CREATION_FACTURE As Date = CDate(listeDesFactures.Rows(i)("DATE")).ToShortDateString

                    NombreDeJourPasse = DateDiff(DateInterval.Day, DATE_CREATION_FACTURE, DATE_DU_JOUR)

                    Dim JOUR As String = "jour"

                    Dim RELANCE As String = "NON"

                    If GlobalVariable.actualLanguageValue = 0 Then
                        JOUR = "day"
                        RELANCE = "NO"
                    End If

                    If listeDesFactures.Rows(i)("RELANCE") = 1 Then
                        RELANCE = "OUI"
                    End If

                    If listeDesFactures.Rows(i)("DELAI") > 1 Then
                        JOUR = "jours"
                        If GlobalVariable.actualLanguageValue = 0 Then
                            JOUR = "days"
                        End If
                    End If

                    'SI LE NOMBRE DE JOUR PASSE EST SUPERIEUR AU DELAI ALORS IL DOIT ETRE RELANCE
                    If NombreDeJourPasse >= listeDesFactures.Rows(i)("DELAI") Then

                        Dim SOLDE As Double = listeDesFactures.Rows(i)("MONTANT SOLDE") - listeDesFactures.Rows(i)("MONTANT")

                        'ON NE DOIT PAS AFFICHER LES FACTURES REGLES
                        If SOLDE < 0 Then

                            GunaDataGridViewLettreDeRelance.Rows.Add(listeDesFactures.Rows(i)("REFERENCE"), Date.Parse(listeDesFactures.Rows(i)("DATE")).ToShortDateString, listeDesFactures.Rows(i)("LIBELLE"), listeDesFactures.Rows(i)("ENTREPRISE"), listeDesFactures.Rows(i)("MONTANT"), listeDesFactures.Rows(i)("MONTANT SOLDE"), SOLDE, listeDesFactures.Rows(i)("DELAI") & " " & JOUR, RELANCE)

                        End If

                    End If

                Next

                GunaDataGridViewLettreDeRelance.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
                GunaDataGridViewLettreDeRelance.DefaultCellStyle.SelectionForeColor = Color.White

                GunaDataGridViewLettreDeRelance.Columns("LIBELLE_LETTRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                GunaDataGridViewLettreDeRelance.Columns("LIBELLE_DELAI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLettreDeRelance.Columns("NOM_CLIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                GunaDataGridViewLettreDeRelance.Columns("DEBIT_LETTRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewLettreDeRelance.Columns("DEBIT_LETTRE").DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewLettreDeRelance.Columns("CREDIT_LETTRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewLettreDeRelance.Columns("CREDIT_LETTRE").DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewLettreDeRelance.Columns("SOLDE_LETTRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GunaDataGridViewLettreDeRelance.Columns("SOLDE_LETTRE").DefaultCellStyle.Format = "#,##0"

                GunaDataGridViewLettreDeRelance.Columns("RELANCE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End If


        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune relance à faire en date du " & GlobalVariable.DateDeTravail, "Gestion des relances", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No reminder to do done on the " & GlobalVariable.DateDeTravail, "Reminder Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    'LISTE CAUTIONS

    Private Function listeDesCautions(ByVal entrepriseOuReservation As Integer) As DataTable

        Dim table As New DataTable()
        Dim table1 As New DataTable()

        Dim query As String = ""
        Dim query1 As String = ""

        If entrepriseOuReservation = 0 Then

            query = "SELECT reservation.NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CODE', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', MONTANT_ACCORDE AS 'MONTANT ACCORDE', reservation.CODE_RESERVATION AS 'RESERVATION', DEBIT, CREDIT, SOLDE AS 'SOLDE CAUTION', caution.RAISON, caution.CODE_CAUTION FROM reservation, caution WHERE reservation.CODE_RESERVATION=caution.CODE_RESERVATION ORDER BY ID_RESERVATION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            query1 = "SELECT reserve_conf.NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CODE', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', MONTANT_ACCORDE AS 'MONTANT ACCORDE', reserve_conf.CODE_RESERVATION AS 'RESERVATION', DEBIT, CREDIT, SOLDE AS 'SOLDE CAUTION', caution.RAISON, caution.CODE_CAUTION FROM reserve_conf, caution WHERE reserve_conf.CODE_RESERVATION=caution.CODE_RESERVATION ORDER BY ID_RESERVATION DESC"

            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)

            Dim adapter1 As New MySqlDataAdapter(command1)

            adapter1.Fill(table1)

            table.Merge(table1)

            Return table

        Else

            query = "SELECT caution.NOM_CLIENT As 'NOM CLIENT' ,  DEBIT, CREDIT, SOLDE AS 'SOLDE CAUTION', caution.DATE_CREATION As 'DATE ENCAISSEMENT', CODE_CAUTION FROM client, caution WHERE caution.CODE_RESERVATION=client.CODE_CLIENT ORDER BY caution.DATE_CREATION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            Return table

        End If

    End Function

    Private Sub listeDesCautionsArrange()

        GunaDataGridViewCaution.Columns.Clear()

        GunaDataGridViewCaution.DataSource = listeDesCautions(GunaComboBoxTypeCaution.SelectedIndex)

        GunaDataGridViewCaution.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
        GunaDataGridViewCaution.DefaultCellStyle.SelectionForeColor = Color.White

        GunaDataGridViewCaution.Columns("DEBIT").DefaultCellStyle.Format = "#,##0"
        GunaDataGridViewCaution.Columns("CREDIT").DefaultCellStyle.Format = "#,##0"

        GunaDataGridViewCaution.Columns("DEBIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GunaDataGridViewCaution.Columns("CREDIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GunaDataGridViewCaution.Columns("SOLDE CAUTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GunaDataGridViewCaution.Columns("SOLDE CAUTION").DefaultCellStyle.Format = "#,##0"

        If GunaComboBoxTypeCaution.SelectedIndex = 0 Then
            GunaDataGridViewCaution.Columns("MONTANT ACCORDE").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewCaution.Columns("MONTANT ACCORDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewCaution.Columns("RAISON").Visible = False
        End If

        GunaDataGridViewCaution.Columns("CODE_CAUTION").Visible = False

    End Sub


    Private Sub GunaButtonAfficherCaution_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherCaution.Click
        listeDesCautionsArrange()
    End Sub

    Private Sub TransférerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransférerToolStripMenuItem.Click

        If GunaDataGridViewCaution.Rows.Count > 0 Then

            For Each row As DataGridViewRow In GunaDataGridViewCaution.SelectedRows

                If GunaComboBoxTypeCaution.SelectedIndex = 0 Then
                    Dim CODE_RESERVATION As String = row.Cells("RESERVATION").Value.ToString

                    CautionRemboursement.GunaTextBoxCaution.Text = Format(row.Cells("CREDIT").Value, "#,##0")
                    'CautionRemboursement.GunaTextBoxMotifDifference.Text = row.Cells("RAISON").Value.ToString
                    CautionRemboursement.GunaTextBoxMontantARembourser.Text = Format(row.Cells("DEBIT").Value, "#,##0")
                    CautionRemboursement.GunaTextBoxCodeCaution.Text = CODE_RESERVATION

                    CautionRemboursement.Show()
                    'MainWindow.cautionEnregistrement(CODE_RESERVATION, 0, GunaTextBoxMontantCaution.Text)

                Else

                    Dim CODE_CAUTION As String = row.Cells("CODE_CAUTION").Value.ToString

                    CautionRemboursement.GunaTextBoxCaution.Text = Format(row.Cells("CREDIT").Value, "#,##0")
                    'CautionRemboursement.GunaTextBoxMotifDifference.Text = row.Cells("RAISON").Value.ToString
                    CautionRemboursement.GunaTextBoxMontantARembourser.Text = Format(row.Cells("DEBIT").Value, "#,##0")
                    CautionRemboursement.GunaTextBoxCodeCaution.Text = CODE_CAUTION

                    CautionRemboursement.Show()
                    'MainWindow.cautionEnregistrement(CODE_RESERVATION, 0, GunaTextBoxMontantCaution.Text)

                End If

            Next

            'RAFRAICHISSEMENT DES LIGNES DE CAUTION

            Me.Activate()

        End If

    End Sub

    Private Sub MainWindowComptabiliteForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        listeDesCautionsArrange()
    End Sub

    Private Sub DétailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DétailsToolStripMenuItem.Click

        If GunaDataGridViewCaution.Rows.Count > 0 Then

            If GunaComboBoxTypeCaution.SelectedIndex = 0 Then

                For Each row As DataGridViewRow In GunaDataGridViewCaution.SelectedRows

                    Dim CODE_RESERVATION As String = row.Cells("RESERVATION").Value.ToString

                    CautionRemboursement.GunaTextBoxCaution.Text = Format(row.Cells("CREDIT").Value, "#,##0")
                    CautionRemboursement.GunaTextBoxMotifDifference.Text = row.Cells("RAISON").Value.ToString
                    CautionRemboursement.GunaLabelMontantARembourser.Text = "Montant remboursé : "
                    CautionRemboursement.GunaTextBoxMontantARembourser.Text = Format(row.Cells("DEBIT").Value, "#,##0")
                    CautionRemboursement.GunaTextBoxCodeCaution.Text = CODE_RESERVATION
                    CautionRemboursement.GunaButtonRembourser.Visible = False
                    CautionRemboursement.Show()

                Next

            Else

            End If


        End If

    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        If GlobalVariable.actualLanguageValue = 1 Then
            GunaLabelTabEncours.Text = "FACTURES REGLEES"

        Else
            GunaLabelTabEncours.Text = "CLEARED BILLS"

        End If
        TabControlComptabilite.SelectedIndex = 7
    End Sub

    Private Sub GunaButton14_Click(sender As Object, e As EventArgs) Handles GunaButton14.Click
        AfficherFactureRegle()
    End Sub

    Private Sub GunaTextBoxIntituleCompte_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxIntituleCompte.TextChanged

    End Sub

    Dim INDICE_DE_COMPTE As String = ""

    'CUISINE
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor

        MainWindowCuisineForm.Show()
        ArticleForm.Show()

        ArticleForm.Location = New Point(90, 110)
        ArticleForm.TopMost = True

        Me.Close()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TimerToRefreshClock_Tick(sender As Object, e As EventArgs) Handles TimerToRefreshClock.Tick

        'GESTION DES NOTIFICATIONS
        Dim notifications As DataTable = Functions.GetAllElementsOnTwoConditions(GlobalVariable.ConnectedUser.Rows(0)("CATEG_UTILISATEUR"), "notification", "CODE_PROFIL", 0, "ETAT_NOTIFCATION")

        If notifications.Rows.Count > 0 Then
            GunaLabelNotification.Text = "(" & notifications.Rows.Count & ")"
        Else

        End If

    End Sub

    Private Sub GunaCheckBoxActiver_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxNonActiver.Click

        DataGridViewListeDesComptes.Columns.Clear()

        If GunaCheckBoxNonActiver.Checked Then
            GunaCheckBoxAttenteActivation.Checked = False
            GunaCheckBoxToutes.Checked = False
        End If

    End Sub

    Private Sub GunaButtonvERIFIER_Click(sender As Object, e As EventArgs) Handles GunaButtonvERIFIER.Click

        Dim NUMERO_COMPTE As String = GunaTextBoxNumeroCompte.Text
        Dim ETAT_DU_COMPTE As Integer = 2

        Dim message As String = "Compte vérifié avec succès"
        Dim Title As String = "Vérification de compte"

        If GlobalVariable.actualLanguageValue = 0 Then
            message = "Account successfully verified"
            Title = "Account verification"
        End If

        If GunaButtonvERIFIER.Text = "Activer" Or GunaButtonvERIFIER.Text = "Activate" Then
            ETAT_DU_COMPTE = 1
            message = "Compte activé avec succès"
            Title = "Activation de compte"
            If GlobalVariable.actualLanguageValue = 0 Then
                message = "Account successfully activated"
                Title = "Account activation"
            End If
        Else
            GunaButtonvERIFIER.Text = "Vérifier"
            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonvERIFIER.Text = "Check"
            End If
        End If

        updateEtatCompte(NUMERO_COMPTE, ETAT_DU_COMPTE)

        GunaButtonAjouterCompte.Text = "Enregistrer"

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaButtonAjouterCompte.Text = "Save"
        End If

        GunaButtonvERIFIER.Visible = False
        PictureBoxNext1.Visible = False
        GunaButtonActivation.Visible = False

        Functions.SiplifiedClearTextBox(Me)

        NumericUpDownDelaiDePaiement.Text = 0
        GunaTextBoxMontantPlafondsDuCompte.Text = 0

        MessageBox.Show(message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

        TabControlComptabilite.SelectedIndex = 1

    End Sub

    Private Sub GunaButtonActivation_Click(sender As Object, e As EventArgs) Handles GunaButtonActivation.Click

        Dim NUMERO_COMPTE As String = GunaTextBoxNumeroCompte.Text
        Dim ETAT_DU_COMPTE As Integer = 1

        updateEtatCompte(NUMERO_COMPTE, ETAT_DU_COMPTE)

        TabControlComptabilite.SelectedIndex = 1

        Functions.SiplifiedClearTextBox(Me)

        NumericUpDownDelaiDePaiement.Text = 0
        GunaTextBoxMontantPlafondsDuCompte.Text = 0


        GunaButtonvERIFIER.Visible = False
        PictureBoxNext1.Visible = False
        GunaButtonActivation.Visible = False

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaButtonAjouterCompte.Text = "Save"
            MessageBox.Show("Account successfully activated", "Account Management", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            GunaButtonAjouterCompte.Text = "Enregistrer"
            MessageBox.Show("Compte activé avec succès", "Gestion de compte", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub GunaCheckBoxAttenteActivation_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxAttenteActivation.Click

        DataGridViewListeDesComptes.Columns.Clear()

        If GunaCheckBoxAttenteActivation.Checked Then
            GunaCheckBoxNonActiver.Checked = False
            GunaCheckBoxToutes.Checked = False
        End If

    End Sub

    Private Sub GunaCheckBoxToutes_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxToutes.Click

        If GunaCheckBoxToutes.Checked Then
            GunaCheckBoxNonActiver.Checked = False
            GunaCheckBoxAttenteActivation.Checked = False
        End If

    End Sub

    Private Sub GunaAdvenceButtonCaisse_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButtonCaisse.Click

        GlobalVariable.grandeCaisse = ""

        'POUR VISUALISER LA CAISSE PRINCIAPLE IL FAUT AVOIR UN LE DOIT DE LECTURE

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_LECTURE") = 1 Then
            GrandeCaisseForm.Show()
            GrandeCaisseForm.TopMost = True
        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Vous ne pouvez pas visualiser la caisse principale !!", "Gestion de Caisse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("You cannot view the main cash Box !!", "Cash Box Manamgement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Private Sub ApprovisionnementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApprovisionnementToolStripMenuItem.Click
        BonApprovisionnementForm.Show()
        BonApprovisionnementForm.TopMost = True
    End Sub

    Dim index As Integer = -1

    Private Sub GunaButton16_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        Dim DateDebut As Date = GunaDateTimePickerDebutCompta.Value.ToShortDateString
        Dim DateFin As Date = GunaDateTimePickerFinCompta.Value.ToShortDateString

        listeDesOperationsParNature(DateDebut, DateFin, index)

    End Sub

    Private Sub listeDesOperationsParNature(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal index As Integer)

        'datagridAfiicher(index)

        'ActivationForm.Show()
        'ActivationForm.TopMost = True
        'ActivationForm.GunaTextBoxMessage.Text = index

        GunaDataGridViewFonds.Rows.Clear()

        If index = 1 Or index = 2 Or index = 3 Then

            Dim tableReglement As New DataTable()

            '1/- ENTREES / SORTIES / RECETTES /

            'CODE_MODE = CODE_FACTURE

            Dim query3 As String = ""

            If index = 1 Then
                'query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER = @IMPRIMER AND `IMPRIMER` = 3 AND `NUMERO_BLOC_NOTE` LIKE 'SORTIE DE FONDS' ORDER BY ID_REGLEMENT DESC"
                query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER = @IMPRIMER AND `IMPRIMER` = 3 AND `NUMERO_BLOC_NOTE` IN ('SORTIE DE FONDS', 'CASH OUTFLOW') ORDER BY ID_REGLEMENT DESC"
                ActivationForm.GunaTextBoxMessage.Text = "SORTIE"
            ElseIf index = 2 Then
                'query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER = @IMPRIMER AND `NUMERO_BLOC_NOTE` LIKE 'ENTREE DE FONDS' ORDER BY ID_REGLEMENT DESC"
                query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER = @IMPRIMER AND `NUMERO_BLOC_NOTE` IN ('ENTREE DE FONDS', 'CASH INFLOW') ORDER BY ID_REGLEMENT DESC"
                ActivationForm.GunaTextBoxMessage.Text = "ENTREE"
            ElseIf index = 3 Then
                ActivationForm.GunaTextBoxMessage.Text = "RECETTE"
                'query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER = @IMPRIMER AND `NUMERO_BLOC_NOTE` LIKE 'ENTREE DE RECETTE' ORDER BY ID_REGLEMENT DESC"
                query3 = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE FROM reglement WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND IMPRIMER = @IMPRIMER AND `NUMERO_BLOC_NOTE` IN ('ENTREE DE RECETTE', 'ENTERING REVENUE') ORDER BY ID_REGLEMENT DESC"
            End If

            Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
            command3.Parameters.Add("@IMPRIMER", MySqlDbType.Int64).Value = 3
            Dim adapter3 As New MySqlDataAdapter(command3)

            Dim totalReglement As Double = 0

            adapter3.Fill(tableReglement)

            'GunaDataGridViewJournalBancaire.Rows.Clear()

            If tableReglement.Rows.Count > 0 Then

                GunaButtonImprimerSituation.Visible = True

                For k = 0 To tableReglement.Rows.Count - 1

                    totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                    If tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTREE DE FONDS" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "CASH INFLOW" Then
                        GunaDataGridViewFonds.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))
                    ElseIf tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTREE DE RECETTE" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTERING REVENUE" Then
                        GunaDataGridViewFonds.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))
                    ElseIf tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "SORTIE DE FONDS" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "CASH OUTFLOW" Then
                        GunaDataGridViewFonds.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE") * -1, "#,##0"), "")
                    End If

                Next

            Else
                GunaButtonImprimerSituation.Visible = False
            End If

        ElseIf index = 0 Then

            '/- LISTE DES FACTURES

            Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, CODE_CLIENT
            FROM facture WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
            AND ETAT_FACTURE = 1 ORDER BY ID_FACTURE DESC"

            Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)

            'command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = NUMERO_COMPTE_PAYMASTER
            'command2.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

            Dim adapter2 As New MySqlDataAdapter(command2)
            Dim tableFacture2 As New DataTable()

            adapter2.Fill(tableFacture2)

            Dim tailleDuTableau As Integer = tableFacture2.Rows.Count

            'On crée une structure de tableau
            Dim toutesLesFactures(tailleDuTableau) As SituationClient

            Dim niemElementDutableau As Integer = 0

            Dim totalFacture As Double = 0
            Dim totalReglement As Double = 0

            GunaDataGridViewListeFacture.Rows.Clear()

            'niemElementDutableau += 1

            'Enfin on insere le tout dans notre datagrid

            For j = 0 To tableFacture2.Rows.Count - 1

                totalFacture += tableFacture2.Rows(j)("MONTANT")

                GunaDataGridViewListeFacture.Rows.Add(tableFacture2.Rows(j)("REFERENCE"), CDate(tableFacture2.Rows(j)("DATE")).ToShortDateString, "FACTURE", tableFacture2.Rows(j)("LIBELLE"), tableFacture2.Rows(j)("LETTRAGE"), Format(tableFacture2.Rows(j)("MONTANT"), "#,##0"), Format(tableFacture2.Rows(j)("MONTANT SOLDE"), "#,##0"), Format(Double.Parse(tableFacture2.Rows(j)("MONTANT SOLDE")) - Double.Parse(tableFacture2.Rows(j)("MONTANT")), "#,##0"), tableFacture2.Rows(j)("CODE_CLIENT"))

            Next

        ElseIf index = 4 Then

            '/- TRANSACTIONS TERMINEES

            '------------------------------------------------------------------- FACTURES ---------------------------------------------------------------------------------------------

            Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT AVANCE', LETTRAGE, CODE_COMMANDE  FROM transfert_recette WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE = @ETAT_FACTURE ORDER BY ID_FACTURE DESC"
            'Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT AVANCE', LETTRAGE, CODE_COMMANDE FROM transfert_recette WHERE ETAT_FACTURE = @ETAT_FACTURE ORDER BY DATE_FACTURE DESC"
            Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)

            command2.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = 1
            'command2.Parameters.Add("@CODE_COMMANDE", MySqlDbType.VarChar).Value = NATURE

            Dim adapter2 As New MySqlDataAdapter(command2)
            Dim traitees As New DataTable()

            adapter2.Fill(traitees)

            Dim tailleDuTableau As Integer = traitees.Rows.Count

            'On crée une structure de tableau
            'Dim toutesLesTraitees(tailleDuTableau) As SituationClient

            Dim niemElementDutableau As Integer = 0

            Dim totalTraitees As Double = 0
            Dim totalReglement As Double = 0

            GunaDataGridViewFonds.Rows.Clear()

            'Enfin on insere le tout dans notre datagrid

            For k = 0 To traitees.Rows.Count - 1

                totalTraitees += traitees.Rows(k)("MONTANT")

                If traitees.Rows(k)("CODE_COMMANDE") = "DEMANDE DE DECAISSEMENT" Or traitees.Rows(k)("CODE_COMMANDE") = "DISBURSEMENT REQUEST" Then
                    GunaDataGridViewFonds.Rows.Add(traitees.Rows(k)("REFERENCE"), CDate(traitees.Rows(k)("DATE")).ToShortDateString, traitees.Rows(k)("LIBELLE"), Format(traitees.Rows(k)("MONTANT"), "#,##0"), "")
                Else
                    GunaDataGridViewFonds.Rows.Add(traitees.Rows(k)("REFERENCE"), CDate(traitees.Rows(k)("DATE")).ToShortDateString, traitees.Rows(k)("LIBELLE"), "", Format(traitees.Rows(k)("MONTANT"), "#,##0"))
                End If

            Next
            '-------------------------------------------------- END FACTURE ----------------------------------------------------------------------

            '----------------------------------------------- REGLEMENT -----------------------------------------------------------

            'CODE_MODE = CODE_FACTURE
            'On selectionne l'ensemble des reglement du client n'incluant pas les remboursements
            Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE 
            FROM reglement WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' 
            AND IMPRIMER = 3 AND NUMERO_BLOC_NOTE IN ('ENTREE DE FONDS','SORTIE DE FONDS', 'CASH OUTFLOW', 'CASH INTFLOW') ORDER BY ID_REGLEMENT DESC"

            Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

            'command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
            command3.Parameters.Add("@NATURE", MySqlDbType.VarChar).Value = "ENTREE DE FONDS"
            command3.Parameters.Add("@NATURE_2", MySqlDbType.VarChar).Value = "SORTIE DE FONDS"

            Dim adapter3 As New MySqlDataAdapter(command3)
            Dim tableReglement As New DataTable()

            adapter3.Fill(tableReglement)

            If tableReglement.Rows.Count > 0 Then

                For k = 0 To tableReglement.Rows.Count - 1

                    totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                    If tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "ENTREE DE FONDS" Or tableReglement.Rows(k)("NUMERO_BLOC_NOTE") = "CASH INFLOW" Then

                        GunaDataGridViewFonds.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))

                    Else

                        GunaDataGridViewFonds.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE") * -1, "#,##0"), "")

                    End If

                Next

                ' GunaDataGridViewFondsEntree.Sort(GunaDataGridViewFondsEntree.Columns(1), ListSortDirection.Descending)

            End If

            '---------------------------------------------------------------------------------------------------------------------

            If GunaDataGridViewFonds.Rows.Count > 0 Then
                GunaButtonImprimerSituation.Visible = True
            Else
                GunaButtonImprimerSituation.Visible = False
            End If

        ElseIf index = 5 Then

            '/- JOURNAL BANCAIRE
            Dim CODE_BANQUE As String = GunaComboBoxBanqueEmettrice.SelectedValue.ToString

            GunaDataGridViewJournalBancaire.Rows.Clear()

            journalBancaire(CODE_BANQUE, DateDebut, DateFin)

            If GunaDataGridViewJournalBancaire.Rows.Count > 0 Then
                GunaButtonImprimerSituation.Visible = True
            Else
                GunaButtonImprimerSituation.Visible = False
            End If

        End If

        '---------------------------------------------------------------------------------------------------------------------

        'GunaDataGridViewListeFacture.Sort(GunaDataGridViewListeFacture.Columns(1), ListSortDirection.Descending)

    End Sub

    Public Sub datagridAfiicher(ByVal index As Integer)

        affichageInfoBanque(index)

        GunaDataGridViewListeFacture.Visible = False
        GunaDataGridViewFonds.Visible = False
        GunaDataGridViewJournalBancaire.Visible = False
        GunaButtonImprimerSituation.Visible = False

        If index = 0 Then
            GunaDataGridViewListeFacture.Visible = True
            GunaDataGridViewListeFacture.Rows.Clear()
        ElseIf index = 1 Or index = 2 Or index = 3 Or index = 4 Then
            GunaDataGridViewFonds.Visible = True
            GunaDataGridViewFonds.Rows.Clear()
        ElseIf index = 5 Then
            GunaDataGridViewJournalBancaire.Visible = True
            GunaDataGridViewJournalBancaire.Rows.Clear()
        End If

    End Sub

    Private Sub journalBancaire(ByVal CODE_BANQUE As String, ByVal dateDebut As Date, ByVal DateFin As Date)

        '1- AVEC LE CODE DE LA BANQUE ON RECUPERE TOUTES LES REFERENCES DE LIGE DE REGLEMENT ASSOCIE AU CODE DE LA BANQUE DANS LA TABLE banque_transaction
        '2- PUIS EN UTILISANT CHAQUE REFERENCE DE REGLEMENT ON VA CHERCHER LES INFORMATIONS Y AFFERENTES

        Dim reglementDeLaBanque As DataTable = Functions.getElementByCode(CODE_BANQUE, "banque_transaction", "CODE_BANQUE")

        If reglementDeLaBanque.Rows.Count > 0 Then

            Dim CODE_REGLEMENT As String

            GunaDataGridViewJournalBancaire.Rows.Clear()

            For j = 0 To reglementDeLaBanque.Rows.Count - 1

                CODE_REGLEMENT = reglementDeLaBanque.Rows(j)("CODE_REGLEMENT")


                ' Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE 
                'From reglement WHERE ETAT = 1 AND DATE_REGLEMENT >= '" & dateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND NUM_REGLEMENT=@CODE_REGLEMENT ORDER BY DATE_REGLEMENT DESC"

                Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT , NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, CODE_MODE , LETTRAGE, NUMERO_BLOC_NOTE 
                FROM reglement WHERE DATE_REGLEMENT >= '" & dateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND NUM_REGLEMENT=@CODE_REGLEMENT ORDER BY ID_REGLEMENT DESC"

                Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
                command3.Parameters.Add("@CODE_REGLEMENT", MySqlDbType.VarChar).Value = CODE_REGLEMENT

                Dim adapter3 As New MySqlDataAdapter(command3)
                Dim tableReglement As New DataTable()

                adapter3.Fill(tableReglement)

                Dim totalReglement As Double = 0

                If tableReglement.Rows.Count > 0 Then

                    For k = 0 To tableReglement.Rows.Count - 1

                        totalReglement += tableReglement.Rows(k)("MONTANT_VERSE")

                        GunaDataGridViewJournalBancaire.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, tableReglement.Rows(k)("REF_REGLEMENT"), tableReglement.Rows(k)("MODE_REGLEMENT"), Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"))

                    Next

                End If

            Next

        End If

        '---------------------------------------------------------------------------------------------------------------------

        GunaDataGridViewJournalBancaire.Sort(GunaDataGridViewJournalBancaire.Columns(1), ListSortDirection.Descending)

    End Sub

    Private Sub Banques()

        Dim query As String = "SELECT * From banque ORDER BY NOM_BANQUE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxBanqueEmettrice.DataSource = table
            GunaComboBoxBanqueEmettrice.ValueMember = "CODE_BANQUE"
            GunaComboBoxBanqueEmettrice.DisplayMember = "NOM_BANQUE"

        Else
            GunaComboBoxBanqueEmettrice.Items.Clear()
        End If

    End Sub

    Private Sub GunaComboBoxBanqueEmettrice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxBanqueEmettrice.SelectedIndexChanged

        GunaDataGridViewJournalBancaire.Rows.Clear()
        GunaButtonImprimerSituation.Visible = False

    End Sub

    Private Sub GunaButtonImprimerSituation_Click(sender As Object, e As EventArgs) Handles GunaButtonImprimerSituation.Click

        Dim title As String = ""

        Dim indexForPrint As Integer = -1

        Dim dateAfficher As String = ""

        If GunaDateTimePickerDebutCompta.Value.ToShortDateString = GunaDateTimePickerFinCompta.Value.ToShortDateString Then
            dateAfficher = GunaDateTimePickerDebutCompta.Value.ToShortDateString.ToString
        Else
            dateAfficher = " DU " & GunaDateTimePickerDebutCompta.Value.ToShortDateString.ToString & " AU " & GunaDateTimePickerFinCompta.Value.ToShortDateString.ToString
        End If

        If index = 1 Then
            title = "JOURNAL DE SORTIE DE CAISSE" '"FONDS SORTIES"

            If GlobalVariable.actualLanguageValue = 0 Then
                title = "CASH OUTFLOW"
            End If

            indexForPrint = 2
            Impression.listeDesOperations(GunaDataGridViewFonds, title, indexForPrint, "", dateAfficher & Now().ToString("hhmm"))
        ElseIf index = 2 Then
            title = "JOURNAL DES ENTREES DE CAISSE" '"FONDS ENTREES"
            If GlobalVariable.actualLanguageValue = 0 Then
                title = "CASH INFLOW"
            End If
            indexForPrint = 3
            Impression.listeDesOperations(GunaDataGridViewFonds, title, indexForPrint, "", dateAfficher & Now().ToString("hhmm"))
        ElseIf index = 3 Then
            title = "RECETTES ENTREES"
            If GlobalVariable.actualLanguageValue = 0 Then
                title = "REVENUES"
            End If
            indexForPrint = 4
            Impression.listeDesOperations(GunaDataGridViewFonds, title, indexForPrint, "", dateAfficher & Now().ToString("hhmm"))
        ElseIf index = 4 Then
            title = "JOURNAL DE CAISSE" '"TRANSACTIONS TERMINEES"
            If GlobalVariable.actualLanguageValue = 0 Then
                title = "COMPLETETED TRANSACTIONS"
            End If
            indexForPrint = 5
            Impression.listeDesOperations(GunaDataGridViewFonds, title, indexForPrint, "", dateAfficher & Now().ToString("hhmm"))
        ElseIf index = 5 Then

            title = "JOURNAL BANCAIRE"
            If GlobalVariable.actualLanguageValue = 0 Then
                title = "BANK LOG"
            End If
            indexForPrint = 6

            Dim BANQUE As String = ""

            Dim infoBanque As DataTable = Functions.getElementByCode(GunaComboBoxBanqueEmettrice.SelectedValue.ToString, "banque", "CODE_BANQUE")

            If infoBanque.Rows.Count > 0 Then
                BANQUE = infoBanque.Rows(0)("NOM_BANQUE")
            End If

            Impression.listeDesOperations(GunaDataGridViewJournalBancaire, title, indexForPrint, BANQUE, dateAfficher & Now().ToString("hhmm"))

        End If

    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click

        If GunaDataGridViewListeFacture.Rows.Count > 0 Then

            Dim NATURE_OPERATION As String = GunaDataGridViewListeFacture.CurrentRow.Cells("NATURE").Value.ToString

            Dim CODE_CLIENT_COMPTE As String = GunaDataGridViewListeFacture.CurrentRow.Cells("CODE_CLIENT").Value.ToString

            If Trim(NATURE_OPERATION) = "FACTURE" Then

                GlobalVariable.DocumentToGenerate = "facture"

                If GunaDataGridViewListeFacture.Rows.Count > 0 Then
                    Functions.DocumentToPrint(GunaDataGridViewListeFacture.CurrentRow.Cells("REFERENCE").Value.ToString, "lign_facture", "CODE_FACTURE", CODE_CLIENT_COMPTE, "")
                End If

            ElseIf Trim(NATURE_OPERATION) = "REGLEMENT" Then

                GlobalVariable.DocumentToGenerate = "reglement"

                Functions.DocumentToPrint(GunaDataGridViewListeFacture.CurrentRow.Cells("REFERENCE").Value.ToString, "reglement", "NUM_REGLEMENT", CODE_CLIENT_COMPTE, "")

            End If

        Else
            'MessageBox.Show("OUps", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub GunaButton16_Click_1(sender As Object, e As EventArgs) Handles GunaButton16.Click

        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataGridView

        If index = 0 Then
            dt = GunaDataGridViewListeFacture
        ElseIf index = 1 Or index = 2 Or index = 3 Or index = 4 Then
            dt = GunaDataGridViewFonds
        ElseIf index = 5 Then
            dt = GunaDataGridViewJournalBancaire
        End If

        Dim title As String = ""

        Dim indexForPrint As Integer = -1

        Dim dateAfficher As String = ""

        If GunaDateTimePickerDebutCompta.Value.ToShortDateString = GunaDateTimePickerFinCompta.Value.ToShortDateString Then
            dateAfficher = GunaDateTimePickerDebutCompta.Value.ToString("ddMMyy")
        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                dateAfficher = " FROM " & GunaDateTimePickerDebutCompta.Value.ToString("ddMMyy") & " TO " & GunaDateTimePickerFinCompta.Value.ToString("ddMMyy")

            Else
                dateAfficher = " DU " & GunaDateTimePickerDebutCompta.Value.ToString("ddMMyy") & " AU " & GunaDateTimePickerFinCompta.Value.ToString("ddMMyy")

            End If
        End If

        If index = 1 Then
            title = "FONDS SORTIES"
            If GlobalVariable.actualLanguageValue = 0 Then
                title = "CASH OUTFLOW"
            End If
            indexForPrint = 2
            Impression.exportationversExcel(GunaDataGridViewFonds, title & " " & dateAfficher & Now().ToString("hhmm"))
        ElseIf index = 2 Then
            title = "FONDS ENTREES"
            If GlobalVariable.actualLanguageValue = 0 Then
                title = "CASH INFLOW"
            End If
            indexForPrint = 3
            Impression.exportationversExcel(GunaDataGridViewFonds, title & " " & dateAfficher & Now().ToString("hhmm"))
        ElseIf index = 3 Then
            title = "RECETTES ENTREES"
            If GlobalVariable.actualLanguageValue = 0 Then
                title = "REVENUES"
            End If
            indexForPrint = 4
            Impression.exportationversExcel(GunaDataGridViewFonds, title & " " & dateAfficher & Now().ToString("hhmm"))
        ElseIf index = 4 Then
            title = "TRANSACTIONS TERMINEES"
            If GlobalVariable.actualLanguageValue = 0 Then
                title = "COMPLETETED TRANSACTIONS"
            End If
            indexForPrint = 5
            Impression.exportationversExcel(GunaDataGridViewFonds, title & " " & dateAfficher & Now().ToString("hhmm"))
        ElseIf index = 5 Then

            Dim BANQUE As String = ""

            Dim infoBanque As DataTable = Functions.getElementByCode(GunaComboBoxBanqueEmettrice.SelectedValue.ToString, "banque", "CODE_BANQUE")

            If infoBanque.Rows.Count > 0 Then
                BANQUE = infoBanque.Rows(0)("NOM_BANQUE")
            End If

            title = "JOURNAL BANCAIRE " & BANQUE

            If GlobalVariable.actualLanguageValue = 0 Then
                title = "BANK LOG OF " & BANQUE
            End If

            indexForPrint = 6
            Impression.exportationversExcel(GunaDataGridViewJournalBancaire, title & " " & dateAfficher & Now().ToString("hhmm"))

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SageModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SageModelToolStripMenuItem.Click

        MiniSageCompatibiliteForm.Show()
        MiniSageCompatibiliteForm.TopMost = True

    End Sub

    Private Sub GunaCheckBoxFiscalite_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFiscalite.Click

        If GunaCheckBoxFiscalite.Checked Then

            FiscaliteForm.Show()
            FiscaliteForm.TopMost = True
            GunaCheckBoxFiscalite.Checked = False

        Else
            GunaTextBoxTauxVisibilite.Visible = False
            GunaLabel17.Visible = False
            GunaButtonEnregistrerFiscValue.Visible = False
        End If

    End Sub

    Private Sub GunaButtonEnregistrerFiscValue_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerFiscValue.Click

        Dim FISCALITE As Double = 0

        If Not Trim(GunaTextBoxTauxVisibilite.Text).Equals("") Then
            FISCALITE = GunaTextBoxTauxVisibilite.Text

            Dim TableName As String = "agence"
            Dim fieldName As String = "FISCALITE"
            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            Functions.updateOfFields(TableName, fieldName, FISCALITE, "CODE_AGENCE", CODE_AGENCE, 1)

            If GlobalVariable.actualLanguageValue = 0 Then
                MessageBox.Show("Visible reservation rate successfully modified", "Taxation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Taux de réservation visible modifié avec succès", "Fiscalité", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            GlobalVariable.AgenceActuelle = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE")

        End If

    End Sub

    Private Sub rechercherDeCompteParFiltre(ByVal CRITERE As String, ByVal CRITERE_VALUE As String)

        Dim account As New GeneralAccount()

        Dim ETAT_DU_COMPTE As Integer = 1

        If GunaCheckBoxNonActiver.Checked Then
            ETAT_DU_COMPTE = 0
        End If

        If GunaCheckBoxAttenteActivation.Checked Then
            ETAT_DU_COMPTE = 2
        End If

        If GunaCheckBoxToutes.Checked Then
            ETAT_DU_COMPTE = 1
        End If

        DataGridViewListeDesComptes.DataSource = account.listeDesComptesActifOuPasParCritere(ETAT_DU_COMPTE, CRITERE, CRITERE_VALUE)

        'rechercherDeCompteParFiltre(CRITERE, CRITERE_VALUE)

        If DataGridViewListeDesComptes.Rows.Count > 0 Then

            DataGridViewListeDesComptes.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridViewListeDesComptes.Columns("INTITULE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridViewListeDesComptes.Columns("DEBIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridViewListeDesComptes.Columns("DEBIT").DefaultCellStyle.Format = "#,##0"

            DataGridViewListeDesComptes.Columns("CREDIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridViewListeDesComptes.Columns("CREDIT").DefaultCellStyle.Format = "#,##0"

            DataGridViewListeDesComptes.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridViewListeDesComptes.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"

        End If

    End Sub

    Private Sub GunaTextBoxClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxClient.TextChanged

        If GunaCheckBoxRecherche.Checked Then

            Dim CRITERE As String = "INTITULE"
            Dim CRITERE_VALUE As String = GunaTextBoxClient.Text

            rechercherDeCompteParFiltre(CRITERE, CRITERE_VALUE)

        End If

    End Sub

    Private Sub GunaCheckBoxRecherche_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxRecherche.CheckedChanged

        If DataGridViewListeDesComptes.Rows.Count > 0 Then
            DataGridViewListeDesComptes.DataSource = Nothing
        End If

    End Sub

    Private Sub GunaTextBoxNumResa_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNumResa.TextChanged

        If GunaCheckBoxRecherche.Checked Then

            Dim CRITERE As String = "NUMERO_COMPTE"
            Dim CRITERE_VALUE As String = GunaTextBoxNumResa.Text

            rechercherDeCompteParFiltre(CRITERE, CRITERE_VALUE)

        End If

    End Sub

    Private Sub GunaTextBoxParEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxParEntreprise.TextChanged

        If GunaCheckBoxRecherche.Checked Then

            Dim CRITERE As String = "INTITULE"
            Dim CRITERE_VALUE As String = GunaTextBoxParEntreprise.Text

            rechercherDeCompteParFiltre(CRITERE, CRITERE_VALUE)

        End If

    End Sub

    Private Sub GunaTextBoxSourceResa_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxSourceResa.TextChanged
        If GunaCheckBoxRecherche.Checked Then

            Dim CRITERE As String = "PERSONNE_A_CONTACTER"
            Dim CRITERE_VALUE As String = GunaTextBoxSourceResa.Text

            rechercherDeCompteParFiltre(CRITERE, CRITERE_VALUE)

        End If
    End Sub

    Private Sub ToolStripMenuItem119_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem119.Click
        Dim dialog As DialogResult

        If GlobalVariable.actualLanguageValue = 1 Then
            dialog = MessageBox.Show("Voulez-vous vraiment fermer ", "Fermer BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            dialog = MessageBox.Show("Do you really want to close your session ", "Close BarclesHSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If

        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else

            Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

            Dim CODE_CAISSE As String = ""

            Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

            If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

            End If

            Dim ETAT_CAISSE As Integer = 0
            Dim caissier As New Caisse()

            'caissier.ouvertureFermetureDeCaisse(CODE_CAISSE, ETAT_CAISSE)

            Dim Action As String = ""

            If GlobalVariable.actualLanguageValue = 1 Then
                Action = "DECONNEXION DE " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")

            Else
                Action = "LOG OUT OF " & GlobalVariable.ConnectedUser(0)("NOM_UTILISATEUR")

            End If

            User.mouchard(Action)

            HomeForm.Close()

            AccueilForm.Close()

            AccueilForm.Show()

            Me.Close()

        End If
    End Sub

    Private Sub ToolStripMenuItem117_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem117.Click

        GlobalVariable.changerMotDePasseDepuis = "comptabilite"

        ChangePasswordForm.Show()
        ChangePasswordForm.TopMost = True

    End Sub

    Private Sub PrévisionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrévisionToolStripMenuItem.Click

        GlobalVariable.categorisationDeDepense = "prevision"

        GestionDesDepensesForm.TopMost = True
        GestionDesDepensesForm.Show()

    End Sub

    Private Sub PlanComptableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanComptableToolStripMenuItem.Click

        GlobalVariable.typeDeCompte = "comptable"
        DepenseFamilyForm.Close()
        DepenseFamilyForm.Show()
        DepenseFamilyForm.TopMost = True

    End Sub

    Private Sub ComptesDExploitationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComptesDExploitationsToolStripMenuItem.Click

        GlobalVariable.typeDeCompte = "exploitation"

        DepenseFamilyForm.Close()
        DepenseFamilyForm.Show()
        DepenseFamilyForm.TopMost = True

    End Sub

    Private Sub FacturesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturesToolStripMenuItem.Click

        Dim NUMERO_COMPTE As String = DataGridViewListeDesComptes.CurrentRow.Cells(0).Value.ToString

        Dim CODE_CLIENT As String = DataGridViewListeDesComptes.CurrentRow.Cells(8).Value.ToString

        Dim infoSupClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")
        Dim TYPE_CLIENT As String = ""
        Dim clientIndex As Integer = 2

        If infoSupClient.Rows.Count > 0 Then

            TYPE_CLIENT = infoSupClient.Rows(0)("TYPE_CLIENT")

            If TYPE_CLIENT.Equals("ENTREPRISE") Or TYPE_CLIENT.Equals("COMPANY") Then
                clientIndex = 1
            Else
                clientIndex = 0
            End If

        End If

        ReglementLettrageForm.Show()
        ReglementLettrageForm.GunaComboBoxTypeDeFiltre.SelectedIndex = clientIndex

    End Sub

    Private Sub GunaButtonFactureAgees_Click(sender As Object, e As EventArgs) Handles GunaButtonFactureAgees.Click

        Dim getUserQuery As String = "SELECT DISTINCT CODE_CLIENT FROM `facture` WHERE RESTE_A_PAYER > 0"

        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(Command)
        Dim table As New DataTable()

        adapter.Fill(table)

        Dim compte As New Compte()

        Dim tailleDuTableau As Integer = table.Rows.Count

        Dim agedBill(tailleDuTableau) As Compte.FactureAgees
        agedBill = compte.facturesAgees()

        GunaDataGridViewFactureAgee.Columns.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaDataGridViewFactureAgee.Columns.Add("DEBTOR", "DEBTOR")
            GunaDataGridViewFactureAgee.Columns.Add("TOTAL", "TOTAL")
            GunaDataGridViewFactureAgee.Columns.Add("ON GOING", "ON GOING")
            GunaDataGridViewFactureAgee.Columns.Add("V1", "D <= 31")
            GunaDataGridViewFactureAgee.Columns.Add("V2", "D <= 60")
            GunaDataGridViewFactureAgee.Columns.Add("V3", "D <= 90")
            GunaDataGridViewFactureAgee.Columns.Add("V4", "D <= 121")
            GunaDataGridViewFactureAgee.Columns.Add("V5", "D > 121")
        Else
            GunaDataGridViewFactureAgee.Columns.Add("DEBITEUR", "DEBITEUR")
            GunaDataGridViewFactureAgee.Columns.Add("TOTAL", "TOTAL")
            GunaDataGridViewFactureAgee.Columns.Add("EN COURS", "EN COURS")
            GunaDataGridViewFactureAgee.Columns.Add("V1", "J <= 31")
            GunaDataGridViewFactureAgee.Columns.Add("V2", "J <= 60")
            GunaDataGridViewFactureAgee.Columns.Add("V3", "J <= 90")
            GunaDataGridViewFactureAgee.Columns.Add("V4", "J <= 121")
            GunaDataGridViewFactureAgee.Columns.Add("V5", "J > 121")
        End If

        If GunaDataGridViewFactureAgee.Rows.Count > 0 Then

            For i = 0 To agedBill.Length - 1
                GunaDataGridViewFactureAgee.Rows.Add(agedBill(i).debiteur, Format(agedBill(i).total, "#,##0"), Format(agedBill(i).v0, "#,##0"), Format(agedBill(i).v1, "#,##0"), Format(agedBill(i).v2, "#,##0"), Format(agedBill(i).v3, "#,##0"), Format(agedBill(i).v4, "#,##0"), Format(agedBill(i).v5, "#,##0"))
            Next

            GunaButton15.Visible = True

            GunaDataGridViewFactureAgee.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            GunaDataGridViewFactureAgee.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFactureAgee.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFactureAgee.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFactureAgee.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFactureAgee.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFactureAgee.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewFactureAgee.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'GunaDataGridViewFactureAgee.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
        Else
            GunaButton15.Visible = False
        End If

    End Sub

    Private Sub GunaButton15_Click(sender As Object, e As EventArgs) Handles GunaButton15.Click

        If True Then

        End If

        Impression.printAgedBills(GunaDataGridViewFactureAgee, GunaLabelTabEncours.Text)

    End Sub

    Dim add As Integer = 1

    Private Sub GunaTextBox8_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBox8.TextChanged

        Dim Facture As New Facture()

        If True Then
            Dim DateDeTravail As Date = GlobalVariable.DateDeTravail
            Dim CRITERE As String = "LIBELLE_FACTURE"
            Dim CRITERE_VALUE As String = GunaTextBox8.Text

            'Dim listeDesFactures As DataTable =
            'GunaDataGridView1.DataSource = Facture.lettreDeRelanceLike(DateDeTravail, CRITERE, CRITERE_VALUE)
        End If

        If Not Trim(GunaTextBox8.Text).Equals("") Then

        End If

    End Sub
End Class