Imports MySql.Data.MySqlClient
Imports System.IO

Public Class AgencyForm

    'Dim connect As New DataBaseManipulation()

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""
    Dim languageQuery As String = ""

    Private Sub AgencyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.agency(GlobalVariable.actualLanguageValue)
        language.autoLoadLanguageAgence(GunaComboBoxLangue, GlobalVariable.actualLanguageValue)

        getFtpServerInfo()

        GunaComboBoxLangue.SelectedIndex = GlobalVariable.AgenceActuelle.Rows(0)("langue")
        'GunaComboBoxLangue.SelectedIndex = 0

        'TabControl1.TabPages.Remove(TabPageAdresseReseau)
        'TabControl1.TabPages.Add(TabPageAdresseReseau)

        'We load the combobox with content from database
        CountryAndTownFromDataBase()

        TabControl1.SelectedIndex = 2

        'PERMET DE METTRE A JOURS LES INFORMATIONS LES TYPES DE CAMBRE DANS reserve_conf, reservation et reserve_temp
        'Functions.miseAjourDesDuTYpeDeChambreDansLeReservations()

        'PERMET DE METTRE A JOURS LES INFORMATIONS LES TYPES DE CAMBRE DANS reserve_conf, reservation et reserve_temp
        'Functions.miseAjourReglementBanqueTransaction()

        loadLogoTypes()



        Dim showCustomImage As Boolean = False

        If GlobalVariable.AgenceActuelle.Rows(0)("CONFIG") = 1 Then
            If GlobalVariable.config.Rows.Count > 0 Then
                showCustomImage = True
            End If
        End If

        If showCustomImage Then

            Dim buttonPanel As Integer = 1
            GunaPanel1.BackColor = Functions.colorationWindow(buttonPanel)
            GunaLinePanelTop.BackColor = Functions.colorationWindow(buttonPanel)

            buttonPanel = 0 'Button Background
            GunaButtonUpload.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonFermer.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonEnregistrer.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButton2.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButton1.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonEnregistrerEnTete.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonCoinGauche.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonCoinDroit.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButtonSecondSave.BaseColor = Functions.colorationWindow(buttonPanel)
            GunaButton4.BaseColor = Functions.colorationWindow(buttonPanel)

        End If

    End Sub

    Private Sub loadLogoTypes()

        GunaComboBoxHeader.Items.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaComboBoxHeader.Items.Add("LOGO CENTERED")
            GunaComboBoxHeader.Items.Add("TEXT CENTERED")
        Else
            GunaComboBoxHeader.Items.Add("LOGO AU CENTRE")
            GunaComboBoxHeader.Items.Add("TEXT AU CENTRE")
        End If

        GunaComboBoxHeader.SelectedIndex = 0

    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Close()
    End Sub


    '---------------------------------LIST OF AGENCIES---------------------------------------

    Private Sub CountryAndTownFromDataBase()

        'Country
        Dim FillingListquery As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            FillingListquery = "SELECT * FROM pays ORDER BY NOM_PAYS_EN ASC"
        Else
            FillingListquery = "SELECT * FROM pays ORDER BY NOM_PAYS_FR ASC"
        End If

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            GunaComboBoxPays.DataSource = tableList

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaComboBoxPays.ValueMember = "NOM_PAYS_EN"
                GunaComboBoxPays.DisplayMember = "NOM_PAYS_EN"
            Else
                GunaComboBoxPays.ValueMember = "NOM_PAYS_FR"
                GunaComboBoxPays.DisplayMember = "NOM_PAYS_FR"
            End If


        End If

        'Town
        Dim FillingListquery1 As String = "SELECT * FROM ville ORDER BY NOM_VILLE ASC"
        Dim commandList1 As New MySqlCommand(FillingListquery1, GlobalVariable.connect)

        Dim adapterList1 As New MySqlDataAdapter(commandList1)
        Dim tableList1 As New DataTable()
        adapterList1.Fill(tableList1)

        If (tableList1.Rows.Count > 0) Then

            GunaComboBoxVille.DataSource = tableList1
            GunaComboBoxVille.ValueMember = "NOM_VILLE"
            GunaComboBoxVille.DisplayMember = "NOM_VILLE"

        End If

        'Hotel categories
        'Town
        Dim FillingListquery2 As String = "SELECT * FROM category_hotel_taxe_sejour_collectee ORDER BY LIBELLE ASC"
        Dim commandList2 As New MySqlCommand(FillingListquery2, GlobalVariable.connect)

        Dim adapterList2 As New MySqlDataAdapter(commandList2)
        Dim tableList2 As New DataTable()
        adapterList2.Fill(tableList2)

        If (tableList2.Rows.Count > 0) Then

            GunaComboBoxCategorie.DataSource = tableList2
            GunaComboBoxCategorie.ValueMember = "CODE_CATEGORIE_HOTEL"
            GunaComboBoxCategorie.DisplayMember = "LIBELLE"

        End If

        'connect.closeConnection()

    End Sub

    Private Sub refreshDataGrid()

        'Dim query As String = "SELECT NOM_AGENCE As 'NOM AGENCE', FAX, EMAIL, TELEPHONE, VILLE, BOITE_POSTALE AS 'BP', PAYS, RUE, CATEGORIE_HOTEL AS 'CATEGORIE HOTEL', DATE_CREATION AS 'DATE CREATION'  FROM agence WHERE CODE_AGENCE = @CODE_AGENCE ORDER BY CODE_AGENCE ASC"

        If GlobalVariable.actualLanguageValue = 0 Then 'english
            languageQuery = "SELECT NOM_AGENCE As 'AGENCY NAME', FAX, EMAIL, TELEPHONE, VILLE AS TOWN, BOITE_POSTALE AS 'P.O BOX', PAYS As COUNTRY, RUE AS STREET, CATEGORIE_HOTEL AS 'HOTEL CATEGORY', DATE_CREATION AS 'CREATION DATE', CODE_AGENCE FROM agence ORDER BY CODE_AGENCE ASC"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageQuery = "SELECT NOM_AGENCE As 'NOM AGENCE', FAX, EMAIL, TELEPHONE, VILLE, BOITE_POSTALE AS 'BP', PAYS, RUE, CATEGORIE_HOTEL AS 'CATEGORIE HOTEL', DATE_CREATION AS 'DATE CREATION', CODE_AGENCE  FROM agence ORDER BY CODE_AGENCE ASC"
        End If

        Dim query As String = languageQuery

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewAgence.DataSource = table
            GunaDataGridViewAgence.Columns("CODE_AGENCE").Visible = False
        Else
            GunaDataGridViewAgence.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    '--------------------------------------DESCRIPTION OF AGENCIES-------------------------------

    'Function to check empty fields
    Public Function verifyFields() As Boolean

        Dim check As Boolean = False

        If (GunaTextBoxBp.Text.Trim().Equals("") _
                    Or GunaTextBoxNom.Text.Trim().Equals("") _
                    Or GunaTextBoxfax.Text.Trim().Equals("") _
                    Or GunaTextBoxEmail.Text.Trim().Equals("") _
                    Or GunaTextBoxRue.Text.Trim().Equals("") _
                    Or GunaTextBoxTelephone.Text.Trim().Equals("")) Then
            check = False

        Else

            check = True

        End If

        Return check

    End Function

    'Saving New Agency
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click, GunaButtonSecondSave.Click

        GunaCheckBoxHotelSoftAssistance.Checked = False

        Dim CODE_AGENCE = GunaTextBoxNumero.Text
        Dim BOITE_POSTALE = GunaTextBoxBp.Text
        Dim NOM_AGENCE = GunaTextBoxNom.Text

        Dim VILLE As String = ""

        If GunaComboBoxVille.SelectedIndex >= 0 Then
            VILLE = GunaComboBoxVille.SelectedValue.ToString
        End If

        Dim PAYS = ""

        If GunaComboBoxPays.SelectedIndex >= 0 Then
            PAYS = GunaComboBoxPays.SelectedValue.ToString
        End If

        Dim FAX = GunaTextBoxfax.Text
        Dim EMAIL = GunaTextBoxEmail.Text
        Dim RUE = GunaTextBoxRue.Text
        'Dim CATEGORIE_HOTEL = GunaComboBoxCategorie.Text
        Dim CATEGORIE_HOTEL = GunaComboBoxCategorie.Text
        Dim TELEPHONE = GunaTextBoxTelephone.Text
        Dim GERER_STOCK = 0
        Dim WHATSAPP_1 = GunaTextBoxWhats1.Text
        Dim WHATSAPP_2 = GunaTextBoxWhats2.Text
        Dim WHATSAPP_3 = GunaTextBoxWhats3.Text
        Dim WHATSAPP_4 = GunaTextBoxWhats4.Text
        Dim WHATSAPP_5 = GunaTextBoxWhats5.Text
        Dim WHATSAPP_6 = GunaTextBoxWhats6.Text
        Dim WHATSAPP_7 = GunaTextBoxWhats7.Text

        Dim EMAIL_1 As String = GunaTextBoxEmail_1.Text
        Dim EMAIL_2 As String = GunaTextBoxEmail_2.Text
        Dim EMAIL_3 As String = GunaTextBoxEmail_3.Text
        Dim EMAIL_4 As String = GunaTextBoxEmail_4.Text
        Dim EMAIL_5 As String = GunaTextBoxEmail_5.Text
        Dim EMAIL_6 As String = GunaTextBoxEmail_6.Text
        Dim EMAIL_7 As String = GunaTextBoxEmail_7.Text

        Dim LANGUE As Integer = GunaComboBoxLangue.SelectedIndex
        Dim HOTEL As Integer = GunaComboBoxHotel.SelectedIndex

        Dim TARIFICATION_DYNAMIQUE As Integer = 0

        If GunaCheckBoxTarificationDynamique.Checked Then
            TARIFICATION_DYNAMIQUE = 1
        End If

        Dim SESSION_UNIQUE As Integer = 0

        If GunaCheckBoxSessionUniqueAuBar.Checked Then
            SESSION_UNIQUE = 1
        End If

        Dim CHEMIN_SAUVEGARDE_AUTO As String = GunaTextBoxCheminSauvegardeAuto.Text
        Dim NUMERO_RECEPTION As String = GunaTextBoxFixeReception.Text
        Dim NUMERO_RECEPTION_CHAMBRE As String = GunaTextBoxChambreReception.Text

        'Gestion de stock ou pas 
        If RadioButtonGererStock.Checked Then
            GERER_STOCK = 1
        Else
            GERER_STOCK = 0
        End If

        Dim CLOTURE_MULTIPLE As Integer = 0

        If GunaCheckBoxAthoriserClotureMultiple.Checked Then
            CLOTURE_MULTIPLE = 1
        End If


        Dim SERRURES As Integer = 0

        If GunaCheckBoxSerrure.Checked Then
            SERRURES = 1
        End If

        Dim MESSAGE_WHATSAPP As Integer = 0

        If GunaCheckBoxMessageWhatsApp.Checked Then
            MESSAGE_WHATSAPP = 1
        End If

        Dim HEBDOMADAIRE As Integer = 0

        If GunaCheckBoxHebdomadaire.Checked Then
            HEBDOMADAIRE = 1
        End If

        Dim CLOTURE_FACTURE As Integer = 0

        If GunaCheckBoxClotureFacture.Checked Then
            CLOTURE_FACTURE = 1
        End If

        Dim PRIX_BAR_RESTAU_MODIFIABLE As Integer = 0

        If GunaCheckBoxPrixBarFix.Checked Then
            PRIX_BAR_RESTAU_MODIFIABLE = 1
        End If

        Dim PAYER_AVANT_ENCODAGE As Integer = 0

        If GunaCheckBoxPayerAvantEncodage.Checked Then
            PAYER_AVANT_ENCODAGE = 1
        End If

        Dim BLOQUER_PRIX_HEBERGEMENT As Integer = 0

        If GunaCheckBoxBloquerPrixHebergement.Checked Then
            BLOQUER_PRIX_HEBERGEMENT = 1
        End If

        Dim CLUB_ELITE As Integer = 0

        If GunaCheckBoxClubElite.Checked Then
            CLUB_ELITE = 1
        End If

        Dim PRINT_B7 As Integer = 0

        If GunaCheckBoxImprimerB7.Checked Then
            PRINT_B7 = 1
        End If

        Dim MENSUALITE As Integer = 0
        If GunaCheckBoxfacturationMensuelle.Checked Then
            MENSUALITE = 1
        End If

        Dim NUM_BLOC_NOTE_AUTOMATIQUE As Integer = 0
        If GunaCheckBoxBlocNoteAuto.Checked Then
            NUM_BLOC_NOTE_AUTOMATIQUE = 1
        End If

        Dim REDUCTION_GLOBAL_FACTURE As Integer = 0
        If GunaCheckBoxReducFacture.Checked Then
            REDUCTION_GLOBAL_FACTURE = 1
        End If

        Dim INVERSER_SIGNE_FACTURE As Integer = 0
        If GunaCheckBoxInverserSigne.Checked Then
            INVERSER_SIGNE_FACTURE = 1
        End If

        Dim CONFIG As Integer = 0
        If GunaCheckBoxConfigs.Checked Then
            CONFIG = 1
        End If

        Dim MONTANT_NAVETTE As Double = 0

        If Not Trim(GunaTextBoxMontantNavette.Text).Equals("") Then
            MONTANT_NAVETTE = GunaTextBoxMontantNavette.Text
        End If

        Dim DIRECTION As String = GunaTextBoxDirection.Text

        Dim CAISSE_ENREGISTREUSE_1 As String = GunaTextBoxMac1.Text
        Dim CAISSE_ENREGISTREUSE_2 As String = GunaTextBoxMac2.Text

        Dim PROMO_CLUB_ELITE As String = GunaTextBoxPromoEliteCheckOut.Text
        Dim PROMO_CLUB_ELITE_IN As String = GunaTextBoxPromoEliteCheckIn.Text
        Dim LIEN_EXTERNE As String = GunaTextBoxLienExterne.Text

        Dim NOMBRE_DE_TABLE As String = GunaTextBoxTables.Text
        Dim TOKEN As String = GunaTextBoxToken.Text
        Dim ID As String = GunaTextBoxId.Text

        Dim MAIL_USER_NAME As String = GunaTextBoxEmailUserName.Text
        Dim MAIL_PASSWORD As String = GunaTextBoxEpassWord.Text

        Dim MAX_VISITE As Integer = GunaTextBoxVisitMax.Text
        Dim clearChecKBox As Boolean = False

        Dim agency As New Agency()

        'We insert the actual content of the agency into data base

        'agency verifyfields function
        If (verifyFields()) Then

            If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Save" Then

                If agency.UpdateCompany(NOM_AGENCE, CODE_AGENCE, FAX, EMAIL, TELEPHONE, VILLE, BOITE_POSTALE, PAYS, RUE, CATEGORIE_HOTEL, WHATSAPP_1, WHATSAPP_2, WHATSAPP_3, WHATSAPP_4, WHATSAPP_5, WHATSAPP_6, WHATSAPP_7, EMAIL_1, EMAIL_2, EMAIL_3, EMAIL_4, EMAIL_5, EMAIL_6, EMAIL_7, GERER_STOCK, CLOTURE_MULTIPLE, CHEMIN_SAUVEGARDE_AUTO, TARIFICATION_DYNAMIQUE, SESSION_UNIQUE, SERRURES, MESSAGE_WHATSAPP, CLOTURE_FACTURE, LANGUE, PRIX_BAR_RESTAU_MODIFIABLE, PAYER_AVANT_ENCODAGE, BLOQUER_PRIX_HEBERGEMENT, CLUB_ELITE, PRINT_B7, MENSUALITE, HEBDOMADAIRE, MONTANT_NAVETTE, NUMERO_RECEPTION, NUMERO_RECEPTION_CHAMBRE, DIRECTION, CAISSE_ENREGISTREUSE_1, CAISSE_ENREGISTREUSE_2, PROMO_CLUB_ELITE, PROMO_CLUB_ELITE_IN, HOTEL, LIEN_EXTERNE, NUM_BLOC_NOTE_AUTOMATIQUE, NOMBRE_DE_TABLE, REDUCTION_GLOBAL_FACTURE, INVERSER_SIGNE_FACTURE, CONFIG, TOKEN, ID, MAIL_USER_NAME, MAIL_PASSWORD, MAX_VISITE) Then

                    GunaCheckBox1.Checked = False
                    GunaButtonSecondSave.Visible = False
                    '--------------- UPDATE CACHET----------------------------------------------------------------------------------
                    Dim ms As New MemoryStream()
                    GunaPictureBoxLogo.Image.Save(ms, GunaPictureBoxLogo.Image.RawFormat)
                    Dim img As Byte() = ms.GetBuffer()

                    If img IsNot Nothing Then

                        If ms.Length > 0 Then
                            Dim updateQuery As String = "UPDATE `agence` SET `CACHET` = @CACHET WHERE CODE_AGENCE = @CODE_AGENCE"
                            Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)
                            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
                            command.Parameters.Add("@CACHET", MySqlDbType.Blob).Value = ms.ToArray()
                            command.ExecuteNonQuery()
                        End If

                    End If

                    '----------------------------------------------------------------------------------------------------------------
                    'agency.
                    GlobalVariable.AgenceActuelle = Functions.getElementByCode(GunaTextBoxNumero.Text, "agence", "CODE_AGENCE")

                    'We empty the fields
                    GunaTextBoxNumero.Text = ""
                    GunaTextBoxBp.Text = ""
                    GunaTextBoxNom.Text = ""
                    GunaComboBoxVille.SelectedIndex = 0
                    GunaComboBoxPays.SelectedIndex = 0
                    GunaTextBoxfax.Text = ""
                    GunaTextBoxEmail.Text = ""
                    GunaTextBoxRue.Text = ""
                    GunaTextBoxTelephone.Text = ""

                    GunaTextBoxWhats1.Clear()
                    GunaTextBoxWhats2.Clear()
                    GunaTextBoxWhats3.Clear()
                    GunaTextBoxWhats4.Clear()
                    GunaTextBoxWhats5.Clear()
                    GunaTextBoxWhats6.Clear()
                    GunaTextBoxWhats7.Clear()

                    GunaTextBoxCheminSauvegardeAuto.Clear()

                    GunaTextBoxEmail_1.Clear()
                    GunaTextBoxEmail_2.Clear()
                    GunaTextBoxEmail_3.Clear()
                    GunaTextBoxEmail_4.Clear()
                    GunaTextBoxEmail_5.Clear()
                    GunaTextBoxEmail_6.Clear()
                    GunaTextBoxEmail_7.Clear()
                    GunaTextBoxPromoEliteCheckOut.Clear()
                    GunaTextBoxPromoEliteCheckIn.Clear()
                    GunaTextBoxLienExterne.Clear()
                    GunaTextBoxTables.Text = 0

                    If Functions.allTableFields("category_hotel_taxe_sejour_collectee").Rows.Count > 0 Then
                        GunaComboBoxCategorie.SelectedIndex = 0
                    End If

                    Dim room As New Room

                    If GunaCheckBoxRoomChange.Checked Then

                        If GunaComboBoxLangue.SelectedIndex >= 0 Then
                            room.roomChangeL(GunaComboBoxLangue.SelectedIndex)
                        End If

                        GunaCheckBoxRoomChange.Checked = False

                    End If

                End If

                If GlobalVariable.actualLanguageValue = 0 Then

                    languageMessage = "Agency successfully updated"
                    languageTitle = "Agency"
                    GunaButtonEnregistrer.Text = "Add"

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    languageMessage = "Agence mise à jours avec succès"
                    languageTitle = "Agence"
                    GunaButtonEnregistrer.Text = "Enregistrer"

                End If

                clearChecKBox = True

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                CODE_AGENCE = Functions.GeneratingRandomCode("agence", "AG")

                'check if the agency alreday exist
                If Not agency.AgencyExists(CODE_AGENCE, NOM_AGENCE) Then

                    If agency.InsertAgency(NOM_AGENCE, CODE_AGENCE, FAX, EMAIL, TELEPHONE, VILLE, BOITE_POSTALE, PAYS, RUE, CATEGORIE_HOTEL, WHATSAPP_1, WHATSAPP_2, WHATSAPP_3, WHATSAPP_4, WHATSAPP_5, WHATSAPP_6, WHATSAPP_7, EMAIL_1, EMAIL_2, EMAIL_3, EMAIL_4, EMAIL_5, EMAIL_6, EMAIL_7, GERER_STOCK, CLOTURE_MULTIPLE, CHEMIN_SAUVEGARDE_AUTO, TARIFICATION_DYNAMIQUE, SESSION_UNIQUE, SERRURES, MESSAGE_WHATSAPP, CLOTURE_FACTURE, LANGUE, PRIX_BAR_RESTAU_MODIFIABLE, PAYER_AVANT_ENCODAGE, BLOQUER_PRIX_HEBERGEMENT, CLUB_ELITE, PRINT_B7, MENSUALITE, HEBDOMADAIRE, MONTANT_NAVETTE, NUMERO_RECEPTION, NUMERO_RECEPTION_CHAMBRE, DIRECTION) Then

                        If GlobalVariable.actualLanguageValue = 0 Then

                            languageMessage = "New Agency successfully Created"
                            languageTitle = "Agency creation"

                        ElseIf GlobalVariable.actualLanguageValue = 1 Then

                            languageMessage = "Nouvelle Agence enregistrée avec succès"
                            languageTitle = "Création d'Agence"

                        End If

                        clearChecKBox = True

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'We empty the fields
                        GunaTextBoxNumero.Text = ""
                        GunaTextBoxBp.Text = ""
                        GunaTextBoxNom.Text = ""
                        GunaComboBoxVille.SelectedIndex = 0
                        GunaComboBoxPays.SelectedIndex = 0
                        GunaTextBoxfax.Text = ""
                        GunaTextBoxEmail.Text = ""
                        GunaTextBoxRue.Text = ""
                        GunaTextBoxTelephone.Text = ""

                        GunaTextBoxWhats1.Clear()
                        GunaTextBoxWhats2.Clear()
                        GunaTextBoxWhats3.Clear()
                        GunaTextBoxWhats4.Clear()
                        GunaTextBoxWhats5.Clear()
                        GunaTextBoxPromoEliteCheckOut.Clear()
                        GunaTextBoxPromoEliteCheckIn.Clear()

                        GunaTextBoxEmail_1.Clear()
                        GunaTextBoxEmail_2.Clear()
                        GunaTextBoxEmail_3.Clear()
                        GunaTextBoxEmail_4.Clear()
                        GunaTextBoxEmail_5.Clear()

                        GunaTextBoxCheminSauvegardeAuto.Clear()

                        GunaComboBoxCategorie.SelectedIndex = 0

                        Functions.ClearTextBox(Me)

                        GunaTextBoxMac1.Text = ""
                        GunaTextBoxMac2.Text = ""

                    Else

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "Error during creation !!"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Un problème lors de la création !!"
                        End If

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If
                Else

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "This agency already exist, try again"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Cette Agence existe déjà, Essayer à nouveau"
                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then

                languageMessage = "Please, fill all the fields !!"
                languageTitle = "Agency creation"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                languageMessage = "Bien vouloir remplir tous les champs !!"
                languageTitle = "Création d'Agence"

            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        'We refresh the datagrid content
        'refreshDataGrid()

        If clearChecKBox Then

            RadioButtonGererStock.Checked = False
            GunaCheckBoxAthoriserClotureMultiple.Checked = False
            GunaCheckBoxTarificationDynamique.Checked = False
            GunaCheckBoxSessionUniqueAuBar.Checked = False
            GunaCheckBoxSerrure.Checked = False
            GunaCheckBoxMessageWhatsApp.Checked = False
            GunaCheckBoxClotureFacture.Checked = False
            GunaCheckBoxPrixBarFix.Checked = False
            GunaCheckBoxPayerAvantEncodage.Checked = False
            GunaCheckBoxBloquerPrixHebergement.Checked = False
            GunaCheckBoxImprimerB7.Checked = False
            GunaCheckBoxClubElite.Checked = False
            GunaCheckBoxfacturationMensuelle.Checked = False
            GunaCheckBoxHebdomadaire.Checked = False
            GunaCheckBoxMac1.Checked = False
            GunaCheckBoxMac2.Checked = False
            GunaCheckBoxBlocNoteAuto.Checked = False
            GunaCheckBoxInverserSigne.Checked = False
            GunaCheckBoxReducFacture.Checked = False
            GunaCheckBoxConfigs.Checked = False

            GunaDataGridViewAgence.Columns.Clear()

            TabControl1.SelectedIndex = 2

        End If

    End Sub

    'To modify the conetent of an agency after double clik on datagrid
    Private Sub GunaDataGridViewAgence_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewAgence.CellDoubleClick

        Dim row As DataGridViewRow

        If GunaDataGridViewAgence.Rows(e.RowIndex).Selected Then

            row = Me.GunaDataGridViewAgence.Rows(e.RowIndex)

            Dim CODE_AGENCE As String = row.Cells("CODE_AGENCE").Value.ToString

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonEnregistrer.Text = "Save"
                GunaButtonEnregistrerEnTete.Text = "Save"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrer.Text = "Sauvegarder"
                GunaButtonEnregistrerEnTete.Text = "Sauvegarder"

            End If


            Dim agencyToUpdate As DataTable = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE")

            If agencyToUpdate.Rows.Count > 0 Then

                GunaButtonSecondSave.Visible = True
                GunaTextBoxNumero.Text = agencyToUpdate.Rows(0)("CODE_AGENCE")
                GunaTextBoxBp.Text = agencyToUpdate.Rows(0)("BOITE_POSTALE")
                GunaTextBoxNom.Text = agencyToUpdate.Rows(0)("NOM_AGENCE")
                GunaComboBoxVille.SelectedValue = agencyToUpdate.Rows(0)("VILLE")
                GunaComboBoxPays.SelectedValue = agencyToUpdate.Rows(0)("PAYS")
                GunaTextBoxfax.Text = agencyToUpdate.Rows(0)("FAX")
                GunaTextBoxEmail.Text = agencyToUpdate.Rows(0)("EMAIL")
                GunaTextBoxRue.Text = agencyToUpdate.Rows(0)("RUE")
                GunaTextBoxTelephone.Text = agencyToUpdate.Rows(0)("TELEPHONE")

                GunaTextBoxFixeReception.Text = agencyToUpdate.Rows(0)("NUMERO_RECEPTION")
                GunaTextBoxChambreReception.Text = agencyToUpdate.Rows(0)("NUMERO_RECEPTION_CHAMBRE")

                GunaTextBoxMontantNavette.Text = Format(agencyToUpdate.Rows(0)("MONTANT_NAVETTE"), "#,##0")
                GunaTextBoxDirection.Text = agencyToUpdate.Rows(0)("DIRECTION")
                GunaTextBoxMac1.Text = agencyToUpdate.Rows(0)("CAISSE_ENREGISTREUSE_1")
                GunaTextBoxMac2.Text = agencyToUpdate.Rows(0)("CAISSE_ENREGISTREUSE_2")
                GunaTextBoxPromoEliteCheckOut.Text = agencyToUpdate.Rows(0)("PROMO_CLUB_ELITE")
                GunaTextBoxPromoEliteCheckIn.Text = agencyToUpdate.Rows(0)("PROMO_CLUB_ELITE_IN")
                GunaTextBoxLienExterne.Text = agencyToUpdate.Rows(0)("LIEN_EXTERNE")
                GunaTextBoxTables.Text = agencyToUpdate.Rows(0)("NOMBRE_DE_TABLE")
                GunaTextBoxToken.Text = agencyToUpdate.Rows(0)("TOKEN")
                GunaTextBoxId.Text = agencyToUpdate.Rows(0)("ID")
                GunaTextBoxEmailUserName.Text = agencyToUpdate.Rows(0)("MAIL_USER_NAME")
                GunaTextBoxEpassWord.Text = agencyToUpdate.Rows(0)("MAIL_PASSWORD")
                GunaTextBoxVisitMax.Text = agencyToUpdate.Rows(0)("MAX_VISITE")

                Dim LIBELLE As String = agencyToUpdate.Rows(0)("CATEGORIE_HOTEL")

                Dim infoSupCategHotel As DataTable = Functions.getElementByCode(LIBELLE, "category_hotel_taxe_sejour_collectee", "LIBELLE")

                If infoSupCategHotel.Rows.Count > 0 Then
                    GunaComboBoxCategorie.SelectedValue = infoSupCategHotel.Rows(0)("CODE_CATEGORIE_HOTEL")
                End If

                GunaTextBoxCheminSauvegardeAuto.Text = agencyToUpdate.Rows(0)("CHEMIN_SAUVEGARDE_AUTO")

                GunaComboBoxHotel.SelectedIndex = agencyToUpdate.Rows(0)("HOTEL")

                GunaTextBoxWhats1.Text = agencyToUpdate.Rows(0)("WHATSAPP_1")
                GunaTextBoxWhats2.Text = agencyToUpdate.Rows(0)("WHATSAPP_2")
                GunaTextBoxWhats3.Text = agencyToUpdate.Rows(0)("WHATSAPP_3")
                GunaTextBoxWhats4.Text = agencyToUpdate.Rows(0)("WHATSAPP_4")
                GunaTextBoxWhats5.Text = agencyToUpdate.Rows(0)("WHATSAPP_5")
                GunaTextBoxWhats6.Text = agencyToUpdate.Rows(0)("WHATSAPP_6")
                GunaTextBoxWhats7.Text = agencyToUpdate.Rows(0)("WHATSAPP_7")

                GunaTextBoxEmail_1.Text = agencyToUpdate.Rows(0)("EMAIL_1")
                GunaTextBoxEmail_2.Text = agencyToUpdate.Rows(0)("EMAIL_2")
                GunaTextBoxEmail_3.Text = agencyToUpdate.Rows(0)("EMAIL_3")
                GunaTextBoxEmail_4.Text = agencyToUpdate.Rows(0)("EMAIL_4")
                GunaTextBoxEmail_5.Text = agencyToUpdate.Rows(0)("EMAIL_5")
                GunaTextBoxEmail_6.Text = agencyToUpdate.Rows(0)("EMAIL_6")
                GunaTextBoxEmail_7.Text = agencyToUpdate.Rows(0)("EMAIL_7")

                GunaComboBoxLangue.SelectedIndex = GlobalVariable.AgenceActuelle.Rows(0)("LANGUE")

                If Not IsDBNull(GlobalVariable.AgenceActuelle.Rows(0)("CACHET")) Then
                    Dim img() As Byte
                    img = GlobalVariable.AgenceActuelle.Rows(0)("CACHET")
                    Dim mStream As New MemoryStream(img)
                    If Not Image.FromStream(mStream) Is Nothing Then
                        GunaPictureBoxLogo.Image = Image.FromStream(mStream)
                    End If
                End If

            End If

            If agencyToUpdate.Rows(0)("NUM_BLOC_NOTE_AUTOMATIQUE") = 0 Then
                GunaCheckBoxBlocNoteAuto.Checked = False
            ElseIf agencyToUpdate.Rows(0)("NUM_BLOC_NOTE_AUTOMATIQUE") = 1 Then
                GunaCheckBoxBlocNoteAuto.Checked = True
            End If

            If agencyToUpdate.Rows(0)("GERER_STOCK") = 0 Then
                RadioButtonGererStock.Checked = False
            ElseIf agencyToUpdate.Rows(0)("GERER_STOCK") = 1 Then
                RadioButtonGererStock.Checked = True
            End If

            If agencyToUpdate.Rows(0)("CLOTURE_FACTURE") = 0 Then
                GunaCheckBoxClotureFacture.Checked = False
            Else
                GunaCheckBoxClotureFacture.Checked = True
            End If

            If agencyToUpdate.Rows(0)("SESSION_UNIQUE") = 0 Then
                GunaCheckBoxSessionUniqueAuBar.Checked = False
            ElseIf agencyToUpdate.Rows(0)("SESSION_UNIQUE") = 1 Then
                GunaCheckBoxSessionUniqueAuBar.Checked = True
            End If

            If agencyToUpdate.Rows(0)("TARIFICATION_DYNAMIQUE") = 0 Then
                GunaCheckBoxTarificationDynamique.Checked = False
            ElseIf agencyToUpdate.Rows(0)("TARIFICATION_DYNAMIQUE") = 1 Then
                GunaCheckBoxTarificationDynamique.Checked = True
            End If

            If agencyToUpdate.Rows(0)("CLOTURE_MULTIPLE") = 0 Then
                GunaCheckBoxAthoriserClotureMultiple.Checked = False
            ElseIf agencyToUpdate.Rows(0)("CLOTURE_MULTIPLE") = 1 Then
                GunaCheckBoxAthoriserClotureMultiple.Checked = True
            End If

            If agencyToUpdate.Rows(0)("SERRURES") = 0 Then
                GunaCheckBoxSerrure.Checked = False
            ElseIf agencyToUpdate.Rows(0)("SERRURES") = 1 Then
                GunaCheckBoxSerrure.Checked = True
            End If

            If agencyToUpdate.Rows(0)("PRIX_BAR_RESTAU_MODIFIABLE") = 0 Then
                GunaCheckBoxPrixBarFix.Checked = False
            ElseIf agencyToUpdate.Rows(0)("PRIX_BAR_RESTAU_MODIFIABLE") = 1 Then
                GunaCheckBoxPrixBarFix.Checked = True
            End If

            If agencyToUpdate.Rows(0)("MESSAGE_WHATSAPP") = 0 Then
                GunaCheckBoxMessageWhatsApp.Checked = False
            ElseIf agencyToUpdate.Rows(0)("MESSAGE_WHATSAPP") = 1 Then
                GunaCheckBoxMessageWhatsApp.Checked = True
            End If

            If agencyToUpdate.Rows(0)("PAYER_AVANT_ENCODAGE") = 0 Then
                GunaCheckBoxPayerAvantEncodage.Checked = False
            ElseIf agencyToUpdate.Rows(0)("PAYER_AVANT_ENCODAGE") = 1 Then
                GunaCheckBoxPayerAvantEncodage.Checked = True
            End If

            If agencyToUpdate.Rows(0)("BLOQUER_PRIX_HEBERGEMENT") = 0 Then
                GunaCheckBoxBloquerPrixHebergement.Checked = False
            ElseIf agencyToUpdate.Rows(0)("BLOQUER_PRIX_HEBERGEMENT") = 1 Then
                GunaCheckBoxBloquerPrixHebergement.Checked = True
            End If

            If agencyToUpdate.Rows(0)("CLUB_ELITE") = 0 Then
                GunaCheckBoxClubElite.Checked = False
            ElseIf agencyToUpdate.Rows(0)("CLUB_ELITE") = 1 Then
                GunaCheckBoxClubElite.Checked = True
            End If

            If agencyToUpdate.Rows(0)("PRINT_B7") = 0 Then
                GunaCheckBoxImprimerB7.Checked = False
            ElseIf agencyToUpdate.Rows(0)("PRINT_B7") = 1 Then
                GunaCheckBoxImprimerB7.Checked = True
            End If

            If agencyToUpdate.Rows(0)("MENSUALITE") = 0 Then
                GunaCheckBoxfacturationMensuelle.Checked = False
            ElseIf agencyToUpdate.Rows(0)("MENSUALITE") = 1 Then
                GunaCheckBoxfacturationMensuelle.Checked = True
            End If

            If agencyToUpdate.Rows(0)("HEBDOMADAIRE") = 0 Then
                GunaCheckBoxHebdomadaire.Checked = False
            ElseIf agencyToUpdate.Rows(0)("HEBDOMADAIRE") = 1 Then
                GunaCheckBoxHebdomadaire.Checked = True
            End If

            If agencyToUpdate.Rows(0)("REDUCTION_GLOBAL_FACTURE") = 0 Then
                GunaCheckBoxReducFacture.Checked = False
            ElseIf agencyToUpdate.Rows(0)("REDUCTION_GLOBAL_FACTURE") = 1 Then
                GunaCheckBoxReducFacture.Checked = True
            End If

            If agencyToUpdate.Rows(0)("INVERSER_SIGNE_FACTURE") = 0 Then
                GunaCheckBoxInverserSigne.Checked = False
            ElseIf agencyToUpdate.Rows(0)("INVERSER_SIGNE_FACTURE") = 1 Then
                GunaCheckBoxInverserSigne.Checked = True
            End If

            If agencyToUpdate.Rows(0)("CONFIG") = 0 Then
                GunaCheckBoxConfigs.Checked = False
            ElseIf agencyToUpdate.Rows(0)("CONFIG") = 1 Then
                GunaCheckBoxConfigs.Checked = True
            End If

            Dim papierEnTete As DataTable = Functions.getElementByCode(CODE_AGENCE, "papier_entete", "CODE_AGENCE")

            If papierEnTete.Rows.Count > 0 Then

                loadLogoTypes()

                GunaComboBoxHeader.SelectedIndex = papierEnTete.Rows(0)("UTILISE")

                GunaTextBoxCodePapier.Text = papierEnTete.Rows(0)("CODE_PAPIER")
                GunaTextBoxTeteLigne1.Text = papierEnTete.Rows(0)("EN_TETE_L1")
                GunaTextBoxTeteLigne2.Text = papierEnTete.Rows(0)("EN_TETE_L2")
                GunaTextBoxTeteLigne3.Text = papierEnTete.Rows(0)("EN_TETE_L3")
                GunaTextBoxTeteLigne4.Text = papierEnTete.Rows(0)("EN_TETE_L4")
                GunaTextBoxPieds1.Text = papierEnTete.Rows(0)("PIEDS_L1")
                GunaTextBoxPieds2.Text = papierEnTete.Rows(0)("PIEDS_L2")
                GunaTextBoxPieds3.Text = papierEnTete.Rows(0)("PIEDS_L3")

                If Not IsDBNull(papierEnTete.Rows(0)("IMAGE_1")) Then

                    Dim img() As Byte
                    img = papierEnTete.Rows(0)("IMAGE_1")

                    Dim mStream As New MemoryStream(img)

                    GunaPictureBoxGauche.Image = Image.FromStream(mStream)

                End If

                If Not IsDBNull(papierEnTete.Rows(0)("IMAGE_2")) Then

                    Dim img() As Byte
                    img = papierEnTete.Rows(0)("IMAGE_2")

                    Dim mStream As New MemoryStream(img)

                    GunaPictureBoxCoinDroit.Image = Image.FromStream(mStream)

                End If

            End If

            TabControl1.SelectedIndex = 0

        End If

    End Sub

    Private Sub GunaButtonFermer_Click(sender As Object, e As EventArgs) Handles GunaButtonFermer.Click

        Me.Close()

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        refreshDataGrid()

    End Sub

    Private Sub GunaButtonCoinGauche_Click(sender As Object, e As EventArgs) Handles GunaButtonCoinGauche.Click

        Dim opf As New OpenFileDialog
        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF) | *.jpg;*.png;*.gif"

        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim ImagePath As String = opf.FileName
            GunaPictureBoxGauche.Image = Image.FromFile(opf.FileName)

        End If

    End Sub

    Private Sub GunaButtonCoinDroit_Click(sender As Object, e As EventArgs) Handles GunaButtonCoinDroit.Click

        Dim opf As New OpenFileDialog
        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF) | *.jpg;*.png;*.gif"

        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim ImagePath As String = opf.FileName
            GunaPictureBoxCoinDroit.Image = Image.FromFile(opf.FileName)

        End If

    End Sub

    'ENREGISTREMENT DES PAPIERS EN TETE
    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerEnTete.Click

        Dim letterHead As DataTable = Functions.allTableFields("papier_entete")

        If letterHead.Rows.Count > 0 Then

            If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Save" Then

                ''--------------------------------------------------------------------------------------

                Dim agency As New Agency()

                Dim CODE_PAPIER As String = Functions.GeneratingRandomCodePanne("papier_entete", "PE")
                Dim EN_TETE_L1 As String = GunaTextBoxTeteLigne1.Text
                Dim EN_TETE_L2 As String = GunaTextBoxTeteLigne2.Text
                Dim EN_TETE_L3 As String = GunaTextBoxTeteLigne3.Text
                Dim EN_TETE_L4 As String = GunaTextBoxTeteLigne4.Text
                Dim PIEDS_L1 As String = GunaTextBoxPieds1.Text
                Dim PIEDS_L2 As String = GunaTextBoxPieds2.Text
                Dim PIEDS_L3 As String = GunaTextBoxPieds3.Text
                Dim CODE_AGENCE As String = GlobalVariable.codeAgence
                Dim UTILISE As Integer = GunaComboBoxHeader.SelectedIndex

                If GunaButtonEnregistrerEnTete.Text = "Sauvegarder" Or GunaButtonEnregistrerEnTete.Text = "Save" Then

                    CODE_PAPIER = GunaTextBoxCodePapier.Text

                    Functions.DeleteElementOnTwoConditions(CODE_PAPIER, "papier_entete", "CODE_PAPIER", "CODE_AGENCE", CODE_AGENCE)

                End If

                If agency.InsertPiedsDePage(CODE_PAPIER, EN_TETE_L1, EN_TETE_L2, EN_TETE_L3, EN_TETE_L4, PIEDS_L1, PIEDS_L2, PIEDS_L3, CODE_AGENCE, UTILISE) Then

                    Dim ms1 As New MemoryStream()

                    If Not GunaPictureBoxGauche.Image Is Nothing Then

                        Dim ms As New MemoryStream()
                        GunaPictureBoxGauche.Image.Save(ms, GunaPictureBoxGauche.Image.RawFormat)

                        Dim img As Byte() = ms.GetBuffer()

                        If ms.Length > 0 Then

                            Dim updateQuery As String = "UPDATE `papier_entete` SET `IMAGE_1`=@IMAGE_1 WHERE CODE_AGENCE = @CODE_AGENCE"

                            Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
                            command.Parameters.Add("@IMAGE_1", MySqlDbType.Blob).Value = ms.ToArray()

                            command.ExecuteNonQuery()

                        End If

                    End If

                    If Not GunaPictureBoxCoinDroit.Image Is Nothing Then

                        GunaPictureBoxCoinDroit.Image.Save(ms1, GunaPictureBoxCoinDroit.Image.RawFormat)

                        Dim img1 As Byte() = ms1.GetBuffer()

                        If ms1.Length > 0 Then

                            Dim updateQuery As String = "UPDATE `papier_entete` SET `IMAGE_2`=@IMAGE_2 WHERE CODE_AGENCE = @CODE_AGENCE"

                            Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
                            command.Parameters.Add("@IMAGE_2", MySqlDbType.Blob).Value = ms1.ToArray()

                            command.ExecuteNonQuery()

                        End If

                    End If

                    If GunaButtonEnregistrerEnTete.Text = "Enregistrer" Or GunaButtonEnregistrerEnTete.Text = "Add" Then
                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageTitle = "Invalid Agency"
                            languageMessage = "Header and Footer successfully created !!"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageTitle = "Agence Invalide"
                            languageMessage = "En tête créee avec succès !!, Création de PAPIER EN TETE"
                        End If

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ElseIf GunaButtonEnregistrerEnTete.Text = "Sauvegarder" Or GunaButtonEnregistrerEnTete.Text = "Save" Then

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageTitle = "Invalid Agency"
                            languageMessage = "Header and Footer successfully updated !!"
                            GunaButtonEnregistrerEnTete.Text = "Save"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageTitle = "Agence Invalide"
                            languageMessage = "En tête mise à jours avec succès !!"
                            GunaButtonEnregistrerEnTete.Text = "Enregistrer"
                        End If

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    Functions.SiplifiedClearTextBox(Me)

                    If GlobalVariable.actualLanguageValue = 0 Then
                        GunaButtonEnregistrer.Text = "Add"
                    Else
                        GunaButtonEnregistrer.Text = "Enregistrer"
                    End If

                End If

                '---------------------------------------------------------------------------------------

            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Agence"
                    languageMessage = "Header and Footer already set !!"
                    GunaButtonEnregistrerEnTete.Text = "Save"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Agency"
                    languageMessage = "Papier En tête déjà configuré !!"
                    GunaButtonEnregistrerEnTete.Text = "Enregistrer"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If


    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewAgence.CurrentRow.Selected Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") Then

                Dim NOM_AGENCE As String = ""
                Dim CODE_AGENCE As String = GunaDataGridViewAgence.CurrentRow.Cells("CODE_AGENCE").Value.ToString

                If GlobalVariable.actualLanguageValue = 0 Then
                    NOM_AGENCE = GunaDataGridViewAgence.CurrentRow.Cells("AGENCY NAME").Value.ToString
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    NOM_AGENCE = GunaDataGridViewAgence.CurrentRow.Cells("NOM AGENCE").Value.ToString
                End If

                Dim dialog As DialogResult

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Dou you really want to delete " & NOM_AGENCE
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Voulez-vous vraiment Supprimer " & NOM_AGENCE
                    languageTitle = "Suppression"
                End If

                dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If dialog = DialogResult.No Then
                    'e.Cancel = True
                Else

                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewAgence, GunaDataGridViewAgence.CurrentRow.Cells("CODE_AGENCE").Value.ToString, "agence", "CODE_AGENCE")

                    GunaDataGridViewAgence.Columns.Clear()

                    refreshDataGrid()

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Deleted successfully"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Vous avez supprimé avec succès"
                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Nothing to be deleted !"
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Aucune ligne à suprimer !"
                languageTitle = "Supression"
            End If

            'MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub GunaButton5_Click_1(sender As Object, e As EventArgs)

        Impression.headerPreview(GunaComboBoxHeader.SelectedIndex)

    End Sub

    Private Sub GunaComboBoxHeader_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxHeader.SelectedIndexChanged

        If GunaComboBoxHeader.SelectedIndex = 1 Then
            GunaPictureBox2.Visible = False
            GunaPictureBox1.Visible = True
        Else
            GunaPictureBox2.Visible = True
            GunaPictureBox1.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxHotelSoftAssistance.CheckedChanged
        If GunaCheckBoxHotelSoftAssistance.Checked Then
            GunaPanelAssistance.Visible = True
        Else
            GunaPanelAssistance.Visible = False
        End If
    End Sub

    Private Sub GunaButtonUpload_Click(sender As Object, e As EventArgs) Handles GunaButtonUpload.Click

        Dim opf As New OpenFileDialog
        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF) | *.jpg;*.png;*.gif"

        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim ImagePath As String = opf.FileName
            GunaPictureBoxLogo.Image = Image.FromFile(opf.FileName)
            'GunaPictureBoxLogo.ImageLocation = ImagePath

        End If

    End Sub

    Private Sub GunaCheckBoxMac1_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxMac1.Click

        If GunaCheckBoxMac1.Checked Then
            GunaTextBoxMac1.Text = Functions.getMacAddresse()
        Else
            GunaTextBoxMac1.Text = ""
        End If

    End Sub

    Private Sub GunaCheckBoxMac2_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxMac2.Click

        If GunaCheckBoxMac2.Checked Then
            GunaTextBoxMac2.Text = Functions.getMacAddresse()
        Else
            GunaTextBoxMac2.Text = ""
        End If

    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        If GunaCheckBox1.Visible Then
            GunaCheckBox1.Visible = False
        Else
            GunaCheckBox1.Visible = True
        End If
    End Sub

    Private Sub GunaCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox2.CheckedChanged

        If GunaCheckBox2.Checked Then
            ConfigForm.Show()
            ConfigForm.TopMost = True
        Else
            ConfigForm.Close()
        End If

    End Sub

    Private Sub GunaCheckBox3_Click(sender As Object, e As EventArgs) Handles GunaCheckBox3.Click

        If GunaCheckBox3.Checked Then
            GunaLabel43.Visible = True
            GunaTextBoxWhats7.Visible = True
            GunaTextBoxEmail_7.Visible = True
        Else
            GunaLabel43.Visible = False
            GunaTextBoxWhats7.Visible = False
            GunaTextBoxEmail_7.Visible = False
        End If

    End Sub

    Private Sub GunaCheckBox1_Click(sender As Object, e As EventArgs) Handles GunaCheckBox1.Click
        If GunaCheckBox1.Checked Then
            GunaCheckBoxConfigs.Visible = True
            GunaShadowPanel3.Visible = True
        Else
            GunaCheckBoxConfigs.Visible = False
            GunaCheckBox1.Visible = False
            GunaShadowPanel3.Visible = False

        End If
    End Sub

    Private Sub GunaCheckBoxConfigs_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxConfigs.Click
        If GunaCheckBoxConfigs.Checked Then
            GunaCheckBoxConfigs.Visible = True
            GunaShadowPanel3.Visible = True
        Else
            GunaCheckBoxConfigs.Visible = False
            GunaShadowPanel3.Visible = False
            GunaCheckBox1.Visible = False
            GunaCheckBox1.Checked = False
        End If
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click

        Dim HOTE As String = GunaTextBox10.Text
        Dim NOM_UTILISATEUR As String = GunaTextBox12.Text
        Dim COM_PORT As Integer = GunaTextBox22.Text
        Dim DELAI As Integer = -1
        If Not Trim(GunaTextBox1.Text).Equals("") Then
            DELAI = GunaTextBox1.Text
        End If
        Dim MOT_DE_PASSE As String = GunaTextBox13.Text
        Dim MYSQL_DUMP As String = GunaTextBox11.Text

        Dim agence As New Agency()

        Dim answer As Boolean = agence.serveur_ftp(HOTE, NOM_UTILISATEUR, COM_PORT, DELAI, MOT_DE_PASSE, MYSQL_DUMP)

        If answer Then

            If GlobalVariable.actualLanguageValue = 0 Then

                languageMessage = "FTP information successfully updated"
                languageTitle = "FTP"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                languageMessage = "Serveur FTP mise à jours avec succès"
                languageTitle = "Agence"

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then

                languageMessage = "FTP information Error"
                languageTitle = "FTP"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                languageMessage = "Serveur FTP Erreur"
                languageTitle = "Agence"

            End If
        End If

        GlobalVariable.server_ftp = Functions.allTableFields("serveur_ftp")

        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub getFtpServerInfo()

        GunaTextBox10.Text = GlobalVariable.server_ftp.Rows(0)("HOTE")
        GunaTextBox12.Text = GlobalVariable.server_ftp.Rows(0)("NOM_UTILISATEUR")
        GunaTextBox22.Text = GlobalVariable.server_ftp.Rows(0)("COM_PORT")
        GunaTextBox1.Text = GlobalVariable.server_ftp.Rows(0)("DELAI")
        GunaTextBox13.Text = GlobalVariable.server_ftp.Rows(0)("MOT_DE_PASSE")
        GunaTextBox11.Text = GlobalVariable.server_ftp.Rows(0)("MYSQL_DUMP")
        GunaTextBox2.Text = GlobalVariable.server_ftp.Rows(0)("CHEMIN")
        GunaTextBox23.Text = GlobalVariable.server_ftp.Rows(0)("FICHIER")

    End Sub

End Class