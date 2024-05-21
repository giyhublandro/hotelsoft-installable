Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class ClientForm

    'Database connection management
    'Dim connect As New DataBaseManipulation()

    Private Sub GunaImageButton3_Click(sender As Object, e As EventArgs) Handles GunaImageButton3.Click

        'On empêche de vouloir charger les donnée du client dans le frontdesk car le formulaire est non rempli bien que on appelé le formulaire du client partant du front desk

        If GlobalVariable.addUserFromFrontOffice = True Then
            GlobalVariable.addUserFromFrontOffice = False
        End If

        Me.Close()

        'Close()
    End Sub

    Public Sub clientList()

        Dim query As String = ""

        If GunaCheckBoxTous.Checked Then
            'ON AFFICHE L'ENSEMBLE DES CLIENTS
            query = "SELECT CODE_CLIENT AS 'CODE CLIENT', NOM_PRENOM AS 'NOM & PRENOM', EMAIL AS 'E-MAIL', TELEPHONE , NUM_COMPTE AS 'NUMERO DE COMPTE',  NATIONALITE, PROFESSION FROM client WHERE CODE_AGENCE=@CODE_AGENCE ORDER BY NOM_PRENOM ASC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaDataGridViewClient.DataSource = table
            Else
                GunaDataGridViewClient.Columns.Clear()
            End If

        Else

            'FILTRER LES CLIENTS

            Dim CRITERE_DE_RECHERCHE As String = ""
            Dim CRITERE_DE_RECHERCHE_VALUE As String = ""

            If Not Trim(GunaTextBoxRefClient.Text) = "" Then
                CRITERE_DE_RECHERCHE_VALUE = GunaTextBoxRefClient.Text
                CRITERE_DE_RECHERCHE = "CODE_CLIENT"

            ElseIf Not Trim(GunaTextBoxNomClient.Text) = "" Then
                CRITERE_DE_RECHERCHE_VALUE = GunaTextBoxNomClient.Text
                CRITERE_DE_RECHERCHE = "NOM_PRENOM"

            ElseIf Not Trim(GunaTextBoxTelephone.Text) = "" Then
                CRITERE_DE_RECHERCHE_VALUE = GunaTextBoxTelephone.Text
                CRITERE_DE_RECHERCHE = "TELEPHONE"

            ElseIf Not Trim(GunaTextBoxCodeEntreprise.Text) = "" Then
                CRITERE_DE_RECHERCHE_VALUE = GunaTextBoxCodeEntreprise.Text
                CRITERE_DE_RECHERCHE = "NOM_PRENOM"

            Else

                CRITERE_DE_RECHERCHE_VALUE = GunaDateTimePickerCreation.Value.ToShortDateString
                CRITERE_DE_RECHERCHE = "DATE_CREATION"

            End If

            'MessageBox.Show(CRITERE_DE_RECHERCHE & " - " & CRITERE_DE_RECHERCHE_VALUE)

            If CRITERE_DE_RECHERCHE = "DATE_CREATION" Then

                'ON AFFICHE L'ENSEMBLE DES CLIENTS
                query = "SELECT CODE_CLIENT AS 'CODE CLIENT', NOM_PRENOM AS 'NOM & PRENOM', EMAIL AS 'E-MAIL', TELEPHONE , NUM_COMPTE AS 'NUMERO DE COMPTE',  NATIONALITE, PROFESSION FROM client WHERE CODE_AGENCE=@CODE_AGENCE AND " & CRITERE_DE_RECHERCHE & ">='" & CRITERE_DE_RECHERCHE_VALUE & "' AND " & CRITERE_DE_RECHERCHE & "<='" & CRITERE_DE_RECHERCHE_VALUE & "' ORDER BY NOM_PRENOM ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                Dim adapter As New MySqlDataAdapter(command)
                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                'command.Parameters.Add("@CRITERE_DE_RECHERCHE_VALUE", MySqlDbType.VarChar).Value = CRITERE_DE_RECHERCHE_VALUE
                Dim table As New DataTable()
                adapter.Fill(table)

                If (table.Rows.Count > 0) Then
                    GunaDataGridViewClient.DataSource = table
                Else
                    GunaDataGridViewClient.Columns.Clear()
                End If

            Else

                'ON AFFICHE L'ENSEMBLE DES CLIENTS
                query = "SELECT CODE_CLIENT AS 'CODE CLIENT', NOM_PRENOM AS 'NOM & PRENOM', EMAIL AS 'E-MAIL', TELEPHONE , NUM_COMPTE AS 'NUMERO DE COMPTE',  NATIONALITE, PROFESSION FROM client WHERE CODE_AGENCE=@CODE_AGENCE AND " & CRITERE_DE_RECHERCHE & "=@CRITERE_DE_RECHERCHE_VALUE ORDER BY NOM_PRENOM ASC"

                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                Dim adapter As New MySqlDataAdapter(command)
                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                command.Parameters.Add("@CRITERE_DE_RECHERCHE_VALUE", MySqlDbType.VarChar).Value = CRITERE_DE_RECHERCHE_VALUE
                Dim table As New DataTable()
                adapter.Fill(table)

                If (table.Rows.Count > 0) Then
                    GunaDataGridViewClient.DataSource = table

                Else
                    GunaDataGridViewClient.Columns.Clear()
                End If

            End If

        End If

        GunaTextBoxRefClient.Clear()
        GunaTextBoxNomClient.Clear()
        GunaTextBoxTelephone.Clear()
        GunaTextBoxCodeEntreprise.Clear()

        GunaDateTimePickerCreation.Value = GlobalVariable.DateDeTravail

        Functions.CleanTitleOfForms(GunaLabelTitreForm)

        'connect.closeConnection()

    End Sub

    Private Function nombreDeClientEnregistre()

        Dim query As String = "SELECT CODE_CLIENT AS 'CODE CLIENT', NOM_PRENOM AS 'NOM & PRENOM', EMAIL AS 'E-MAIL', TELEPHONE , NUM_COMPTE AS 'NUMERO DE COMPTE',  NATIONALITE, PROFESSION FROM client WHERE CODE_AGENCE=@CODE_AGENCE ORDER BY NOM_PRENOM ASC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim nombreDeClient As Integer = 0

        If (table.Rows.Count > 0) Then
            nombreDeClient = table.Rows.Count
        End If

        Return nombreDeClient

    End Function

    Private Sub ClientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.client(GlobalVariable.actualLanguageValue)

        MaskedTextBox1.Text = GlobalVariable.DateDeTravail

        GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Clear()

        If GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Count > 0 Then
            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Clear()
        End If

        GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Clear()

        'GunaLabelNombreClient.Text = "( " & nombreDeClientEnregistre() & " )"

        If Trim(GunaTextBoxCodeClient.Text) = "" Then
            GunaButtonEnregistrerTarifs.Enabled = False
        Else
            GunaButtonEnregistrerTarifs.Enabled = True
        End If

        If GlobalVariable.addUserFromFrontOffice Then
            TabControl1.SelectedIndex = 0
        Else
            TabControl1.SelectedIndex = 4
        End If

        'On charge les colonnes du datagrid des tarifs
        GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.BringToFront()

        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("ID_TARIF_PRIX", "ID")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("CODE_TARIF", "CODE APPLIQUE")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("TYPE_TARIF", "TYPE TARIF")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("CODE_TYPE", "CODE TYPE")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF_ENCOURS", "PRIX ENCOURS")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF1", "PRIX 1")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF2", "PRIX 2")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF3", "PRIX 3")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF4", "PRIX 4")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF5", "PRIX 5")

        'We hide the datagrid for displaying company
        GunaDataGridViewCompany.Visible = False

        'Chargin country and and town
        FillingAllComboxBox()

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaComboBoxPays.SelectedIndex = 36
            GunaComboBoxTypeClient.SelectedValue = "INDIVIDUAL"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            GunaComboBoxPays.SelectedIndex = 38
            GunaComboBoxTypeClient.SelectedValue = "INDIVIDUEL"
        End If

        'Loading data into datagrid concerning the tarifs
        ListeDesTarifsAppliquableAuClient()

        GunaComboBoxCivilite.SelectedIndex = 0

        'MEMBRE DU CLUB ELITE

        Dim typeDeMembre As DataTable = Functions.allTableFieldsOrganised("club_elite_membre", "ID_CLUB_ELITE_MEMBRE")

        If typeDeMembre.Rows.Count > 0 Then

            GunaComboBoxEliteClub.DataSource = typeDeMembre
            GunaComboBoxEliteClub.DisplayMember = "MEMBRE"
            GunaComboBoxEliteClub.ValueMember = "MEMBRE"

        End If

    End Sub

    Public Sub ListeDesTarifsAppliquableAuClient()

        'Country
        Dim tableListTarifs As DataTable = allTableFields("tarif_prix")

        If (tableListTarifs.Rows.Count > 0) Then

            'GunaComboBoxCodeTarif.DataSource = tableListTarifs
            'GunaComboBoxCodeTarif.ValueMember = "ID_TARIF"
            'GunaComboBoxCodeTarif.DisplayMember = "CODE_TARIF" & "-" & "CODE_TARIF"

        End If

    End Sub

    Function allTableFields(ByVal tableName As String) As DataTable

        Dim FillingListquery As String = "SELECT * FROM " & tableName
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        Return tableList

        'connect.closeConnection()

    End Function

    'Selecting an entry from any database using the code
    Function selectEntryFromTable(ByVal tableName As String, ByVal conditionField As String, ByVal Id As Integer) As DataTable

        Dim entryQuery As String = "SELECT * FROM " & tableName & " WHERE " & conditionField & " = @Id"

        Dim commandList As New MySqlCommand(entryQuery, GlobalVariable.connect)
        commandList.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim entry As New DataTable()

        adapterList.Fill(entry)

        Return entry

        'connect.closeConnection()

    End Function

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
        Dim tableListVille As DataTable = allTableFields("ville")

        If (tableListVille.Rows.Count > 0) Then

            'GunaComboBoxVille.DataSource = tableListVille
            'GunaComboBoxVille.ValueMember = "NOM_VILLE"
            'GunaComboBoxVille.DisplayMember = "NOM_VILLE"

        End If

        'connect.closeConnection()

        'client categorie
        Dim FillingListquery As String = "SELECT * FROM categorie_client ORDER BY LIBELLE"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        Dim tableListClientCategory As DataTable = tableList

        If (tableListClientCategory.Rows.Count > 0) Then

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaComboBoxTypeClient.DataSource = tableListClientCategory
                GunaComboBoxTypeClient.ValueMember = "LIBELLE_EN"
                GunaComboBoxTypeClient.DisplayMember = "LIBELLE_EN"

            Else

                GunaComboBoxTypeClient.DataSource = tableListClientCategory
                GunaComboBoxTypeClient.ValueMember = "LIBELLE"
                GunaComboBoxTypeClient.DisplayMember = "LIBELLE"

            End If

        End If

    End Sub

    'Inserting the client into database

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerClient.Click

        If Trim(GunaTextBoxNomRaisonSociale.Text).Equals("") Then

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Bien vouloir remplir le Nom / Raison Sociale", "Création d'un client", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please fill the First Name / Company Name", "Customer creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            If GunaComboBoxTypeClient.SelectedValue IsNot Nothing Then

                'On desactive le bouton permettant d'affecter des prix a un client
                GunaButtonEnregistrerTarifs.Enabled = False

                Dim MODE_TRANSPORT = ""

                If GunaComboBoxModeTransport.SelectedIndex >= 0 Then
                    MODE_TRANSPORT = GunaComboBoxModeTransport.SelectedItem
                End If

                Dim CIVILITE As String = ""
                Dim CODE_ELITE As String = GunaTextBoxCodeMembreElite.Text

                If GunaComboBoxCivilite.Visible Then
                    CIVILITE = GunaComboBoxCivilite.SelectedItem
                End If

                Dim INTITULE As String = GunaTextBoxIntituleDeCompte.Text
                Dim NUM_VEHICULE = GunaTextBoxNumVehicule.Text
                Dim MARQUE_VEHICULE = GunaTextBoxMarqueVehicule.Text
                Dim CODE_CLIENT = Functions.GeneratingRandomCode("client", "CL")
                Dim NOM_CLIENT = GunaTextBoxNomRaisonSociale.Text
                Dim PRENOMS = GunaTextBoxPrenom.Text
                Dim ADRESSE = GunaTextBox12.Text
                Dim TELEPHONE = MaskedTextBoxTelephone.Text
                Dim DATE_DE_NAISSANCE = GunaDateTimePicker1.Value
                Dim LIEU_DE_NAISSANCE = GunaTextBox6.Text
                Dim NOM_JEUNE_FILLE = GunaTextBoxNomDeJeunneFille.Text
                Dim FAX = GunaTextBoxFax.Text
                Dim EMAIL = GunaTextBoxEmail.Text
                Dim NUM_COMPTE = Trim(GUnaTextBoxNumCompteReal.Text)
                Dim NATIONALITE = GunaTextBoxNationalite.Text
                Dim PAYS_RESIDENCE = GunaComboBoxPays.SelectedValue
                Dim NUM_COMPTE_COLLECTIF = GUnaTextBoxNumCompteReal.Text
                Dim TYPE_CLIENT = ""

                If GunaComboBoxTypeClient.SelectedValue IsNot Nothing Then
                    TYPE_CLIENT = GunaComboBoxTypeClient.SelectedValue.ToString
                End If

                Dim SITE_INTERNET = GunaTextBoxSiteWeb.Text
                Dim CODE_AGENCE = GlobalVariable.codeAgence
                'Dim CODE_UTILISATEUR_MODIF = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                Dim CODE_UTILISATEUR_MODIF = ""
                Dim PROFESSION = GunaTextBoxProfession.Text
                Dim CNI = GunaTextBoxCni.Text
                'Dim VILLE_DE_RESIDENCE = GunaComboBoxVille.SelectedValue
                Dim VILLE_DE_RESIDENCE = GunaTextBox5.Text
                Dim CODE_MODE_PAIEMENT = GunaComboBoxModeReglement.SelectedItem
                Dim CODE_ENTREPRISE As String = GunaTextBoxEntreprise.Text
                'if the client type is not a company and and the company name is not empty then we have a client associated to a comapny

                If GunaComboBoxTypeClient.SelectedValue IsNot Nothing Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        If Not Trim(GunaTextBoxCompanyName.Text) = "" And Not GunaComboBoxTypeClient.SelectedValue.ToString = "ENTREPRISE" Then
                            'We assigne the company to the client which is not of type company
                            CODE_ENTREPRISE = GunaTextBoxEntreprise.Text
                        End If
                    Else
                        If Not Trim(GunaTextBoxCompanyName.Text) = "" And Not GunaComboBoxTypeClient.SelectedValue.ToString = "COMPANY" Then
                            'We assigne the company to the client which is not of type company
                            CODE_ENTREPRISE = GunaTextBoxEntreprise.Text
                        End If
                    End If

                End If

                Dim DATE_MODIFICATION As Date = Date.Now().ToShortDateString

                Dim PLAFONDS_DU_COMPTE As Double = 0

                If Not Trim(GunaTextBoxMontantPlafondsDuCompte.Text) = "" Then
                    PLAFONDS_DU_COMPTE = GunaTextBoxMontantPlafondsDuCompte.Text
                End If

                Dim ETAT_DU_COMPTE As Integer = 0

                If GunaCheckBoxActivationDesactivationDuCompte.Checked Then
                    ETAT_DU_COMPTE = 1
                End If

                Dim PERSONNE_A_CONTACTER = Trim(GunaTextBoxPersonneAContacter.Text)
                Dim CONTACT_PAIEMENT = Trim(GunaTextBoxContactPourPaiement.Text)
                Dim ADRESSE_DE_FACTURATION = Trim(GunaTextBoxAdresseDeFacturation.Text)

                Dim DELAI_DE_PAIEMENT = Trim(NumericUpDownDelaiDePaiement.Text)

                If Not Trim(NumericUpDownDelaiDePaiement.Text) = "" Then
                    DELAI_DE_PAIEMENT = NumericUpDownDelaiDePaiement.Text
                End If

                Dim TVA As Integer = 1

                If Not GunaCheckBoxTVA.Checked Then
                    TVA = 0
                End If

                Dim client As New Client

                'GESTION DES TARIFS APPLIQUES AUX CLIENTS

                Dim tarifClient As New Tarifs

                'POUR LA TRADUCTION MODIER LE TYPE DANS LA CLASSE CLIENT

                'company verifyfields function
                'If Not Trim(GunaTextBoxCni.Text) = "" Then
                If True Then

                    If GunaButtonEnregistrerClient.Text = "Sauvegarder" Or GunaButtonEnregistrerClient.Text = "Update" Then

                        CODE_CLIENT = GunaTextBoxCodeClient.Text
                        'We update the information of the user

                        If client.Update(CODE_CLIENT, NOM_CLIENT, NOM_JEUNE_FILLE, PRENOMS, ADRESSE, TELEPHONE, FAX, EMAIL, NUM_COMPTE, NATIONALITE, DATE_DE_NAISSANCE, LIEU_DE_NAISSANCE, PAYS_RESIDENCE, VILLE_DE_RESIDENCE, PROFESSION, CNI, CODE_MODE_PAIEMENT, NUM_COMPTE_COLLECTIF, TYPE_CLIENT, SITE_INTERNET, CODE_UTILISATEUR_MODIF, CODE_ENTREPRISE, MODE_TRANSPORT, NUM_VEHICULE, MARQUE_VEHICULE, TVA, CIVILITE, CODE_ELITE) Then 'Client update query

                            'CREATION DE COMPTE FINANCE POUR L'UTILISATEUR ACTUEL

                            Dim Compte As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                            If Compte.Rows.Count <= 0 Then
                                'EN CAS DE PAS DE COMPTE ON CREE UN NOUEAU
                                CreationDeCompteUtilisateur(CODE_CLIENT)
                            Else
                                'MISE AJOURS DES COMPTES UTILISATEUR
                                If Trim(Compte.Rows(0)("NUMERO_COMPTE")) = "" Then
                                    Functions.DeleteElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")
                                    CreationDeCompteUtilisateur(CODE_CLIENT)
                                Else
                                    updateCompteUtilisateur(CODE_CLIENT, INTITULE, INTITULE, PLAFONDS_DU_COMPTE, ETAT_DU_COMPTE, PERSONNE_A_CONTACTER, CONTACT_PAIEMENT, ADRESSE_DE_FACTURATION, DELAI_DE_PAIEMENT)
                                End If

                            End If

                            If Not GlobalVariable.editUserFromFrontOffice Then

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MessageBox.Show("Client Mise à jours avec succès", "Mise à jour d'un client", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    MessageBox.Show("Customer successfully updated", "Customer updating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                            End If

                            If GlobalVariable.actualLanguageValue = 1 Then
                                GunaButtonEnregistrerClient.Text = "Enregistrer"
                            Else
                                GunaButtonEnregistrerClient.Text = "Add"
                            End If

                        End If

                        'REMPLISSAGE DU DATAGRID CONTENANT LES INFORMATIONS DU CLIENT A METTRE A JOURS.
                        'MAIS AVANT ON SUPPRIME D'ABORDS

                        Dim tarifDuClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "tarif_client", "CODE_CLIENT")

                        If tarifDuClient.Rows.Count > 0 Then
                            Functions.DeleteElementByCode(CODE_CLIENT, "tarif_client", "CODE_CLIENT")
                        End If

                        'MISE A JOURS DES TARIFS D'UN CLIENT

                        If GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Count > 0 Then

                            For i = 0 To GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Count - 1
                                tarifClient.insertTarifClient(CODE_CLIENT, GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows(i).Cells("ID_TARIF_PRIX").Value, GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows(i).Cells("PRIX_TARIF_ENCOURS").Value)
                            Next

                        End If

                        'On vide le datagrid
                        GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Clear()

                        'NB: 'A CHAQUE FOIS QUE LA REFERENCE DU CLIENT AU NIVEAU DU FRONT DESK CHANGE, ON DOIT VERIFIER SI IL N'EST PAS ASSOCIE A UNE ENTREPRISE
                        'SI OUI ON LUI DONNE ON TARIF OBTENU EN UTILISANT LA FONCTION DE CALCUL DU MONTANT DE LA RESERVATION
                    Else

                        'CREATION DE COMPTE FINANCE POUR L'UTILISATEUR ACTUEL
                        CreationDeCompteUtilisateur(CODE_CLIENT)

                        NUM_COMPTE = Trim(numeroDeCompte) 'OBTAIN AFTER DE CREATION OF ACCOUNT NUMBER AS GLOBAL VARIABLE

                        'check if the client alreday exist as it is a new client
                        If Not client.typeClientExists(CODE_CLIENT) Then

                            If client.Insert(CODE_CLIENT, NOM_CLIENT, NOM_JEUNE_FILLE, PRENOMS, ADRESSE, TELEPHONE, FAX, EMAIL, NUM_COMPTE, NATIONALITE, DATE_DE_NAISSANCE, LIEU_DE_NAISSANCE, PAYS_RESIDENCE, VILLE_DE_RESIDENCE, PROFESSION, CNI, CODE_MODE_PAIEMENT, NUM_COMPTE_COLLECTIF, TYPE_CLIENT, SITE_INTERNET, CODE_AGENCE, CODE_UTILISATEUR_MODIF, CODE_ENTREPRISE, MODE_TRANSPORT, NUM_VEHICULE, MARQUE_VEHICULE, TVA, CIVILITE, CODE_ELITE) Then

                                If Not Trim(GunaTextBoxCompanyName.Text) = "" And Not GunaComboBoxTypeClient.SelectedValue.ToString = "ENTREPRISE" Then

                                    CODE_ENTREPRISE = GunaTextBoxEntreprise.Text

                                    Dim updateQuery As String = "UPDATE `client` SET `CODE_ENTREPRISE`=@CODE_ENTREPRISE WHERE CODE_CLIENT=@CODE_CLIENT"

                                    Dim commandUpdate As New MySqlCommand(updateQuery, GlobalVariable.connect)

                                    commandUpdate.Parameters.Add("@CODE_ENTREPRISE", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
                                    'CODE_CLIENT = Functions.latInsertedElementCode("client", "CODE_CLIENT")


                                    commandUpdate.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
                                    ' commandUpdate.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

                                    'Opening the connection
                                    'connect.openConnection()

                                    'Excuting the command and testing if everything went on well
                                    If (commandUpdate.ExecuteNonQuery() = 1) Then
                                        'connect.closeConnection()
                                    Else
                                        MessageBox.Show("Oups")
                                    End If

                                End If

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MessageBox.Show("Nouveau client enregistré avec succès", "Création d'un client", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Else
                                    MessageBox.Show("New customer successfully added", "Customer creation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                                GunaLabelNombreClient.Text = "(" & nombreDeClientEnregistre() & ")"

                                'We instert the tarifs affected to the client

                                If GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Count > 0 Then
                                    'MessageBox.Show(CODE_CLIENT)

                                    For i = 0 To GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Count - 1
                                        tarifClient.insertTarifClient(CODE_CLIENT, GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows(i).Cells("ID_TARIF_PRIX").Value, GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows(i).Cells("PRIX_TARIF_ENCOURS").Value)
                                    Next

                                End If

                                GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Clear()

                                'We empty the fields

                                'Outputting the information of a user that was added from front office interface
                                If GlobalVariable.addUserFromFrontOffice = True Then

                                    Dim query As String = "SELECT * FROM client"
                                    Dim adapter As New MySqlDataAdapter

                                    Dim table As New DataTable()
                                    Dim command As New MySqlCommand(query, GlobalVariable.connect)

                                    adapter.SelectCommand = command
                                    adapter.Fill(table)

                                    If (table.Rows.Count > 0) Then
                                        Dim idClient As Integer
                                        'Selecting the last inserted element
                                        Integer.TryParse(table.Rows(table.Rows.Count - 1)("ID_CLIENT").ToString, idClient)
                                        Dim idLastInsert = idClient

                                        'We get the id of the client ine=serted by callin gthe client form from the font office
                                        GlobalVariable.userAddedFromFrontOffice = selectEntryFromTable("client", "ID_CLIENT", idLastInsert)

                                        'We activate the main window so as to be able to field the information of thenewly resgitered client
                                        MainWindow.MainWindowManualActivation()

                                        MainWindow.GunaTextBoxVenantDe.Text = VILLE_DE_RESIDENCE

                                        Me.Close()

                                    Else

                                    End If

                                    'connect.closeConnection()

                                End If

                            Else
                                If GlobalVariable.actualLanguageValue = 1 Then
                                    MessageBox.Show("Un problème lors de la création !!", "Création d'un client", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                Else
                                    MessageBox.Show("An issue occured during customer creation !!", "Customer creation", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                End If
                            End If
                        Else
                            If GlobalVariable.actualLanguageValue = 1 Then
                                MessageBox.Show("Ce client existe déjà, Essayer à nouveau", "Création d'un client", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                MessageBox.Show("This customer already exist, Please try again", "Custormer creation", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            End If
                        End If

                    End If

                Else
                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bien vouloir remplir le champs CNI/NUI !!", "Création d'un client", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("please fill de field ID/UIN !!", "Customer creation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End If

                'We refresh the client list
                'clientList()

                'connect.closeConnection()

                'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Clear()

                If GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Count > 0 Then
                    GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Clear()
                End If

                GunaTextBoxMontantPlafondsDuCompte.Text = 0

                TabControl1.SelectedIndex = 4

                If GlobalVariable.editUserFromFrontOffice Then

                    GlobalVariable.editUserFromFrontOffice = False

                    GlobalVariable.addUserFromFrontOffice = True

                    Dim query As String = "SELECT * FROM client WHERE CODE_CLIENT=@CODE_CLIENT"
                    Dim adapter As New MySqlDataAdapter

                    Dim table As New DataTable()
                    Dim command As New MySqlCommand(query, GlobalVariable.connect)
                    command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = GunaTextBoxCodeClient.Text

                    adapter.SelectCommand = command
                    adapter.Fill(table)

                    If (table.Rows.Count > 0) Then

                        'We get the id of the client ine=serted by callin gthe client form from the font office
                        GlobalVariable.userAddedFromFrontOffice = table

                        'We activate the main window so as to be able to field the information of thenewly resgitered client
                        MainWindow.MainWindowManualActivation()
                    End If

                    Me.Close()

                End If

                Functions.ClearTextBox(Me)

                If Not GunaCheckBoxTVA.Checked Then
                    GunaCheckBoxTVA.Checked = True
                End If

                If GunaComboBoxTypeClient.Items.Count > 0 Then
                    creationDuCompteDebiteur()
                    GUnaTextBoxNumCompteReal.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", INDICE_DE_COMPTE))
                End If

                If GunaComboBoxPays.Items.Count > 0 Then
                    GunaTextBoxNationalite.Text = NATIONALITE
                End If

            Else

                If GlobalVariable.actualLanguageValue = 1 Then
                    MessageBox.Show("Choisir un type de client", "Gestion des Clients", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Choose the client type", "Client Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    'Create a Function to return an entry using its id
    Public Function getElementById(ByVal Code As String, ByVal tableName As String, ByVal ConditionTable As String) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable()
        Dim getUserQuery = "SELECT * From " & tableName & " WHERE " & ConditionTable & "=@conditionTable"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@conditionTable", MySqlDbType.VarChar).Value = Code
        adapter.SelectCommand = Command
        adapter.Fill(table)

        'connect.closeConnection()

        Return table

    End Function

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnuler.Click

        'On empêche de vouloir charger les donnée du client dans le frontdesk car le formulaire est non rempli bien que on appelé le formulaire du client partant du front desk

        If GlobalVariable.addUserFromFrontOffice = True Then
            GlobalVariable.addUserFromFrontOffice = False
        End If

        Me.Close()

    End Sub

    'Assigning a company to a CLient

    Public Sub AssignACompanyToClient()



    End Sub

    Private Sub GunaTextBoxEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxEntreprise.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxEntreprise.Text).Equals("") Then

            GunaTextBoxCompanyName.Clear()

            GunaDataGridViewCompany.Visible = False

        End If

        GunaDataGridViewCompany.Visible = True

        Dim query As String = "Select NOM_CLIENT From client WHERE NOM_CLIENT Like '%" & GunaTextBoxEntreprise.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "Entreprise"
        command.Parameters.Add("@ENTREPRISE", MySqlDbType.VarChar).Value = GunaComboBoxTypeClient.SelectedValue

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewCompany.DataSource = table
        Else
            GunaDataGridViewCompany.Columns.Clear()
            GunaDataGridViewCompany.Visible = False
        End If

        If GunaTextBoxEntreprise.Text.Trim().Equals("") Then
            GunaDataGridViewCompany.Columns.Clear()
            GunaDataGridViewCompany.Visible = False
        End If


    End Sub

    Private Sub GunaDataGridViewCompany_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewCompany.CellClick

        GunaDataGridViewCompany.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewCompany.Rows(e.RowIndex)
            Dim company As DataTable = Functions.getElementByCode(row.Cells("NOM_CLIENT").Value.ToString, "client", "NOM_CLIENT")

            GunaTextBoxCompanyName.Text = row.Cells("NOM_CLIENT").Value.ToString
            GunaTextBoxEntreprise.Text = company.Rows(0)("CODE_CLIENT")

            GunaDataGridViewCompany.Visible = False

            'connect.closeConnection()

        End If

    End Sub

    '--------------------------------------------------------------------
    'GESTION DE LA TARIFICATION APPLICABLE AU CLIENT

    Private Sub GunaTextBoxCodeAAppliquer_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCodeAAppliquer.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxCodeAAppliquer.Text).Equals("") Then

            GunaTextBoxCodeApplique.Text = ""
            GunaTextBoxTypeTarif.Text = ""
            GunaTextBoxCodeType.Text = ""
            GunaTextBoxIDTarifPrix.Text = 0

            GunaTextBoxPrix1.Clear()
            GunaTextBoxPrix2.Clear()
            GunaTextBoxPrix3.Clear()
            GunaTextBoxPrix4.Clear()
            GunaTextBoxPrix5.Clear()

            GunaDataGridViewTarifsAppliquable.Visible = False

        End If

        GunaDataGridViewTarifsAppliquable.Visible = True

        'Dim query As String = "Select ID_TARIf, CODE_TARIF, CODE_TYPE,PRIX_TARIF1 From tarif_prix WHERE CODE_TARIF Like '%" & GunaTextBoxCodeAAppliquer.Text & "%' OR LIBELLE_TARIF LIKE '%" & GunaTextBoxCodeAAppliquer.Text & "%' "
        Dim CODE_TARIF_DYNAMIQUE As String = ""

        Dim query As String = "Select ID_TARIf, CODE_TARIF, CODE_TYPE,PRIX_TARIF1 From tarif_prix WHERE CODE_TARIF Like '%" & GunaTextBoxCodeAAppliquer.Text & "%' OR LIBELLE_TARIF LIKE '%" & GunaTextBoxCodeAAppliquer.Text & "%' AND CODE_TARIF_DYNAMIQUE=@CODE_TARIF_DYNAMIQUE"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_TARIF_DYNAMIQUE", MySqlDbType.VarChar).Value = CODE_TARIF_DYNAMIQUE
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            GunaDataGridViewTarifsAppliquable.DataSource = table

        Else
            GunaDataGridViewTarifsAppliquable.Columns.Clear()
            GunaDataGridViewTarifsAppliquable.Visible = False
        End If

        If GunaTextBoxCodeAAppliquer.Text.Trim().Equals("") Then
            GunaDataGridViewTarifsAppliquable.Columns.Clear()
            GunaDataGridViewTarifsAppliquable.Visible = False
        End If

        If GunaDataGridViewTarifsAppliquable.Columns.Count > 0 Then
            GunaDataGridViewTarifsAppliquable.Columns("ID_TARIf").Visible = False
        End If

        'connect.closeConnection()

    End Sub

    'On sélectionne un tarif à appliquer

    Private Sub GunaDataGridViewTarifsAppliquable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewTarifsAppliquable.CellClick

        GunaDataGridViewTarifsAppliquable.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewTarifsAppliquable.Rows(e.RowIndex)
            Dim tarif As DataTable = Functions.getElementByCode(row.Cells("ID_TARIF").Value.ToString, "tarif_prix", "ID_TARIF")

            If tarif.Rows.Count > 0 Then

                GunaTextBoxCodeApplique.Text = tarif.Rows(0)("CODE_TARIF") & " - " & tarif.Rows(0)("LIBELLE_TARIF")
                GunaTextBoxTypeTarif.Text = tarif.Rows(0)("TYPE_TARIF")
                GunaTextBoxCodeType.Text = tarif.Rows(0)("CODE_TYPE")

                GunaTextBoxPrix1.Text = Format(tarif.Rows(0)("PRIX_TARIF1"), "#,##0")
                GunaTextBoxPrix2.Text = Format(tarif.Rows(0)("PRIX_TARIF2"), "#,##0")
                GunaTextBoxPrix3.Text = Format(tarif.Rows(0)("PRIX_TARIF3"), "#,##0")
                GunaTextBoxPrix4.Text = Format(tarif.Rows(0)("PRIX_TARIF4"), "#,##0")
                GunaTextBoxPrix5.Text = Format(tarif.Rows(0)("PRIX_TARIF5"), "#,##0")

                GunaTextBoxIDTarifPrix.Text = tarif.Rows(0)("ID_TARIF")

                GunaTextBoxCodeAAppliquer.Text = tarif.Rows(0)("CODE_TARIF")

            End If

            If Not Trim(GunaTextBoxCodeClient.Text).Equals("") Then
                GunaButtonEnregistrerTarifs.Enabled = True
            Else
                GunaButtonEnregistrerTarifs.Enabled = False
            End If

            GunaDataGridViewTarifsAppliquable.Visible = False

            'connect.closeConnection()

        End If

    End Sub

    'On ajoute le tarif selectionné au datagridview
    'Le plan tarifaire applique sera utilisé au niveau du frontdesk a chaque changement du code client fonction du code client

    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerTarifs.Click

        Dim tarifClient As New Tarifs()

        If GunaButtonEnregistrerClient.Text = "Sauvegarder" Or GunaButtonEnregistrerClient.Text = "Update" Then

            Dim CODE_CLIENT As String = GunaTextBoxCodeClient.Text
            Dim PRIX_TARIF_ENCOURS As Double = 0

            If Not GunaButtonEnregistrerTarifs.Text = "Enregistrer" Or Not GunaButtonEnregistrerTarifs.Text = "Add" Then

                Dim ID_TARIF_PRIX As Integer = GunaTextBoxIDTarifPrix.Text
                'MODIFIER UN TARIF NEGOCIE
                Functions.DeleteElementByCode(ID_TARIF_PRIX, "tarif_client", "ID_TARIF_PRIX")

                If GlobalVariable.actualLanguageValue = 1 Then
                    GunaButtonEnregistrerTarifs.Text = "Enregistrer"

                Else
                    GunaButtonEnregistrerTarifs.Text = "Add"

                End If

            End If

            If P1.Checked Then
                If Not Trim(GunaTextBoxPrix1.Text).Equals("") Then
                    PRIX_TARIF_ENCOURS = GunaTextBoxPrix1.Text
                End If
            ElseIf P2.Checked Then
                If Not Trim(GunaTextBoxPrix2.Text).Equals("") Then
                    PRIX_TARIF_ENCOURS = GunaTextBoxPrix2.Text
                End If
            ElseIf P3.Checked Then
                If Not Trim(GunaTextBoxPrix3.Text).Equals("") Then
                    PRIX_TARIF_ENCOURS = GunaTextBoxPrix3.Text
                End If
            ElseIf P4.Checked Then
                If Not Trim(GunaTextBoxPrix4.Text).Equals("") Then
                    PRIX_TARIF_ENCOURS = GunaTextBoxPrix4.Text
                End If
            ElseIf P5.Checked Then
                If Not Trim(GunaTextBoxPrix5.Text).Equals("") Then
                    PRIX_TARIF_ENCOURS = GunaTextBoxPrix5.Text
                End If
            End If

            tarifClient.insertTarifClient(CODE_CLIENT, Integer.Parse(GunaTextBoxIDTarifPrix.Text), PRIX_TARIF_ENCOURS)

            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Clear()

            tarifsAffectesAuxClient(CODE_CLIENT)

        ElseIf GunaButtonEnregistrerClient.Text = "Enregistrer" Or GunaButtonEnregistrerClient.Text = "Add" Then

            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Add(GunaTextBoxIDTarifPrix.Text, GunaTextBoxCodeApplique.Text, GunaTextBoxTypeTarif.Text, GunaTextBoxCodeType.Text, Format(Double.Parse(GunaTextBoxPrix1.Text), "#,##0"), Format(Double.Parse(GunaTextBoxPrix1.Text), "#,##0"), Format(Double.Parse(GunaTextBoxPrix2.Text), "#,##0"), Format(Double.Parse(GunaTextBoxPrix3.Text), "#,##0"), Format(Double.Parse(GunaTextBoxPrix4.Text), "#,##0"), Format(Double.Parse(GunaTextBoxPrix5.Text), "#,##0"))

        End If

        GunaButtonEnregistrerTarifs.Enabled = False

        GunaTextBoxCodeAAppliquer.Clear()

        GunaTextBoxIDTarifPrix.Clear()

        GunaTextBoxCodeAAppliquer.TabIndex = 95

        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns(0).Visible = False

    End Sub

    'Supression d'une ligne de tarifs prix client
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows.Count > 0 Then

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 1 Then
                dialog = MessageBox.Show("Voulez-vous vraiment Supprimer ce tarif ", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Else
                dialog = MessageBox.Show("Do you really want to delete this price ", "Price Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            End If

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                Dim isSelected As Boolean = Convert.ToBoolean(GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.CurrentRow.Cells("ID_TARIF_PRIX").Value)

                If isSelected Then

                    Dim ID_TARIF_PRIX = GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.CurrentRow.Cells("ID_TARIF_PRIX").Value.ToString

                    If Not Trim(GunaTextBoxCodeClient.Text) = "" Then

                        Dim CODE_CLIENT As String = Trim(GunaTextBoxCodeClient.Text)

                        Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewTarifsAuquelOnAEffecteDesPrix, ID_TARIF_PRIX, "tarif_client", "ID_TARIF_PRIX")

                        tarifsAffectesAuxClient(CODE_CLIENT)

                    Else

                        'As the line is still in the datagrid we have to delete a ligne in the datagrid
                        'code to delete a row from datagaird

                    End If

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Price successfully deleted", "Price delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                Else

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bien vouloir sélectionner un tarif ", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Please select a price ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End If

            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Nothing selected !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If


    End Sub

    Dim numeroDeCompte As String = ""

    Private Sub tarifsAffectesAuxClient(ByVal CODE_CLIENT As String)

        Dim tarifClient As New Tarifs()

        If tarifClient.SelectionDesForfaitsDuClient(CODE_CLIENT).Rows.Count > 0 Then

            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Clear()
            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.DataSource = tarifClient.SelectionDesForfaitsDuClient(CODE_CLIENT)

            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns("ID_TARIF_PRIX").Visible = False

        Else
            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.DataSource = Nothing
        End If


    End Sub

    Private Sub updateCompteUtilisateur(ByVal CODE_CLIENT As String, ByVal NUMERO_COMPTE As String, ByVal INTITULE As String, ByVal PLAFONDS_DU_COMPTE As Double, ByVal ETAT_DU_COMPTE As Integer, ByVal PERSONNE_A_CONTACTER As String, ByVal CONTACT_PAIEMENT As String, ByVal ADRESSE_DE_FACTURATION As String, ByVal DELAI_DE_PAIEMENT As Integer)

        Dim compte As New Compte()

        compte.miseAjourDesInfoDuCompteUtilisateur(CODE_CLIENT, NUMERO_COMPTE, INTITULE, PLAFONDS_DU_COMPTE, ETAT_DU_COMPTE, PERSONNE_A_CONTACTER, CONTACT_PAIEMENT, ADRESSE_DE_FACTURATION, DELAI_DE_PAIEMENT)

    End Sub

    Private Sub CreationDeCompteUtilisateur(ByVal CODE_CLIENT As String)

        Dim compte As New Compte()

        Dim INTITULE As String = Trim(GunaTextBoxNomRaisonSociale.Text)

        If Trim(GunaTextBoxMontantPlafondsDuCompte.Text) = "" Then
            GunaTextBoxMontantPlafondsDuCompte.Text = 0
        End If

        Dim NUMERO_COMPTE As String = Trim(GUnaTextBoxNumCompteReal.Text)

        Dim TOTAL_DEBIT As Double = 0
        Dim TOTAL_CREDIT As Double = 0
        Dim SOLDE_COMPTE As Double = 0
        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim TYPE_DE_COMPTE As String = "Autre Compte"
        Dim SENS_DU_SOLDE As String = "Débiteur"

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

        If Trim(NumericUpDownDelaiDePaiement.Text) = "" Then
            NumericUpDownDelaiDePaiement.Text = 0
        End If
        Dim DELAI_DE_PAIEMENT = Trim(NumericUpDownDelaiDePaiement.Text)

        numeroDeCompte = Trim(GUnaTextBoxNumCompteReal.Text)

        compte.insertCompte(INTITULE, NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT, SOLDE_COMPTE, DATE_CREATION, TYPE_DE_COMPTE, SENS_DU_SOLDE, PLAFONDS_DU_COMPTE, ETAT_DU_COMPTE, PERSONNE_A_CONTACTER, CONTACT_PAIEMENT, ADRESSE_DE_FACTURATION, DELAI_DE_PAIEMENT)

    End Sub

    Dim INTITULE As String = ""

    Dim INDICE_DE_COMPTE As Integer

    Private Sub GunaComboBoxTypeClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeClient.SelectedIndexChanged

        If GunaComboBoxTypeClient.SelectedValue IsNot Nothing Then

            If GunaComboBoxTypeClient.SelectedValue.ToString = "ENTREPRISE" Or GunaComboBoxTypeClient.SelectedValue.ToString = "COMPANY" Then

                If GlobalVariable.actualLanguageValue = 0 Then

                    GunaLabelCivilite.Text = "Civility"
                    GunaLabel4.Text = "Company Name *"
                    GunaLabel5.Text = "Taxpayer number*"
                    GunaLabel6.Text = "Commercial register"
                    GunaLabel7.Text = "Business sector"
                    GunaLabel11.Text = "Creation date"
                    GunaLabel8.Text = "Place of creation"
                    GunaLabel24.Text = "Town of central agency"
                    GunaLabel10.Text = "Country"
                    GunaLabelLabelEntreprise.Text = "company"

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    GunaLabelCivilite.Text = "Civilité"
                    GunaLabel4.Text = "Raison sociale *"
                    GunaLabel5.Text = "Numéro de contribuable *"
                    GunaLabel6.Text = "Registre de commerce"
                    GunaLabel7.Text = "Secteur d'activité"
                    GunaLabel11.Text = "Date de création"
                    GunaLabel8.Text = "Lieu de création"
                    GunaLabel24.Text = "Ville agence centrale"
                    GunaLabel10.Text = "Pays"
                    GunaLabelLabelEntreprise.Text = "entreprise"

                End If


                GunaTextBoxNationalite.Visible = False
                GunaLabel9.Visible = False

                GunaLabelLqbelCni.Visible = False
                GunaTextBoxCni.Visible = False
                GunaLabel39.Visible = False
                GunaLabel30.Visible = False
                MaskedTextBoxPieceDu.Visible = False
                GunaLabel38.Visible = False
                GunaTextBoxPieceA.Visible = False

                GunaLabelLabelEntreprise.Visible = False
                GunaTextBoxEntreprise.Visible = False
                GunaTextBoxCompanyName.Visible = False

                'CHAMP OBLIGATOIRE

                GunaLabelObli1.Visible = True
                GunaLabelObli2.Visible = True
                GunaLabelObli3.Visible = True
                GunaLabelObli4.Visible = True
                GunaLabelObli5.Visible = True
                GunaLabelObli6.Visible = True
                GunaLabelObli7.Visible = True

            Else

                If GlobalVariable.actualLanguageValue = 0 Then

                    GunaLabelCivilite.Text = "Civility"
                    GunaLabel4.Text = "Fisrt Name"
                    GunaLabel5.Text = "Maiden name"
                    GunaLabel6.Text = "Surname"
                    GunaLabel7.Text = "Profession"
                    GunaLabel11.Text = "Date of birth"
                    GunaLabel8.Text = "Place of birth"
                    GunaLabel24.Text = "Town of residence"
                    GunaLabel10.Text = "Country of residence"

                ElseIf GlobalVariable.actualLanguageValue = 1 Then

                    GunaLabelCivilite.Text = "Civilité"
                    GunaLabel4.Text = "Nom"
                    GunaLabel5.Text = "Nom de jeune fille"
                    GunaLabel6.Text = "Prénom"
                    GunaLabel7.Text = "Profession"
                    GunaLabel11.Text = "Date de naissance"
                    GunaLabel8.Text = "Lieu de naissance"
                    GunaLabel24.Text = "Ville de résidence"
                    GunaLabel10.Text = "Pays de résidence"

                End If

                GunaTextBoxNationalite.Visible = True
                GunaLabel9.Visible = True

                GunaLabelLqbelCni.Visible = True
                GunaLabel39.Visible = True
                GunaLabel30.Visible = True
                MaskedTextBoxPieceDu.Visible = True
                GunaLabel38.Visible = True
                GunaTextBoxPieceA.Visible = True
                GunaTextBoxCni.Visible = True
                GunaTextBoxCni.Text = ""
                GunaLabelLabelEntreprise.Visible = True
                GunaTextBoxEntreprise.Visible = True
                GunaTextBoxCompanyName.Visible = True

                'CHAMP OBLIGATOIRE

                GunaLabelObli1.Visible = False
                GunaLabelObli2.Visible = False
                GunaLabelObli3.Visible = False
                GunaLabelObli4.Visible = False
                GunaLabelObli5.Visible = False
                GunaLabelObli6.Visible = False
                GunaLabelObli7.Visible = False

            End If


        End If


        creationDuCompteDebiteur()

        If GunaComboBoxPays.SelectedIndex >= 0 Then

            Dim PAYS As String = GunaComboBoxPays.SelectedValue.ToString()
            Dim infoSup As DataTable

            If GlobalVariable.actualLanguageValue = 0 Then

                infoSup = Functions.getElementByCode(PAYS, "pays", "NOM_PAYS_EN")

                If infoSup.Rows.Count > 0 Then
                    GunaTextBoxNationalite.Text = infoSup.Rows(0)("NATIONALITE_EN")
                End If

            Else

                infoSup = Functions.getElementByCode(PAYS, "pays", "NOM_PAYS_FR")

                If infoSup.Rows.Count > 0 Then
                    GunaTextBoxNationalite.Text = infoSup.Rows(0)("NATIONALITE_FR")
                End If

            End If

        End If

        If GunaComboBoxTypeClient.SelectedValue IsNot Nothing Then

            If GunaComboBoxTypeClient.SelectedValue.ToString = "INDIVIDUEL" Or GunaComboBoxTypeClient.SelectedValue.ToString = "INDIVIDUAL" Then
                GunaLabelCivilite.Visible = True
                GunaComboBoxCivilite.Visible = True
            Else
                GunaLabelCivilite.Visible = False
                GunaComboBoxCivilite.Visible = False
            End If

        End If

        GUnaTextBoxNumCompteReal.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", INDICE_DE_COMPTE))

        GunaTextBoxIntituleDeCompte.Text = INTITULE

    End Sub

    Private Sub creationDuCompteDebiteur()

        If GunaComboBoxTypeClient.SelectedIndex >= 0 Then

            If GunaComboBoxTypeClient.SelectedValue.ToString = "INDIVIDUEL" Or GunaComboBoxTypeClient.SelectedValue.ToString = "INDIVIDUAL" Then
                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text) & " " & Trim(GunaTextBoxPrenom.Text)
                INDICE_DE_COMPTE = "415"
            ElseIf GunaComboBoxTypeClient.SelectedValue.ToString = "ENTREPRISE" Or GunaComboBoxTypeClient.SelectedValue.ToString = "COMPANY" Then
                INDICE_DE_COMPTE = "412"
            ElseIf GunaComboBoxTypeClient.SelectedValue.ToString = "COMPTOIR" Or GunaComboBoxTypeClient.SelectedValue.ToString = "WALK IN" Then
                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text) & " " & Trim(GunaTextBoxPrenom.Text)
                INDICE_DE_COMPTE = "411"
            ElseIf GunaComboBoxTypeClient.SelectedValue.ToString = "GROUPE" Or GunaComboBoxTypeClient.SelectedValue.ToString = "GROUP" Then
                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text) & " " & Trim(GunaTextBoxPrenom.Text)
                INDICE_DE_COMPTE = "414"
            ElseIf GunaComboBoxTypeClient.SelectedValue.ToString = "PAYMASTER" Then
                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text) & " " & Trim(GunaTextBoxPrenom.Text)
                INDICE_DE_COMPTE = "416"
            ElseIf GunaComboBoxTypeClient.SelectedValue.ToString = "EVENEMENTIEL" Or GunaComboBoxTypeClient.SelectedValue.ToString = "EVENT" Then
                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text) & " " & Trim(GunaTextBoxPrenom.Text)
                INDICE_DE_COMPTE = "413"
            End If

        End If


    End Sub
    'Affichage des clients après clique sur le bouton d'affichage
    Private Sub GunaButtonAfficherClient_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherClient.Click

        GunaLabelNombreClient.Text = "( " & nombreDeClientEnregistre() & " )"
        clientList()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 0 Then
            GunaButtonAnnuler.Visible = True
            GunaButtonEnregistrerClient.Visible = True
            GunaLabelNote.Visible = True
        Else
            GunaButtonAnnuler.Visible = False
            GunaButtonEnregistrerClient.Visible = False
            GunaLabelNote.Visible = False
        End If

        GunaDataGridViewClient.Columns.Clear()

        creationDuCompteDebiteur()

        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("ID_TARIF_PRIX", "ID")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("CODE_TARIF", "CODE APPLIQUE")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("TYPE_TARIF", "TYPE TARIF")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("CODE_TYPE", "CODE TYPE")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF_ENCOURS", "PRIX ENCOURS")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF1", "PRIX 1")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF2", "PRIX 2")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF3", "PRIX 3")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF4", "PRIX 4")
        'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF5", "PRIX 5")

    End Sub

    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs)

    End Sub

    'CNI Ogligatoire
    Private Sub GunaTextBoxCni_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCni.TextChanged

        If Trim(GunaTextBoxCni.Text) = "" Then
            GunaButtonEnregistrerClient.Visible = False
        Else
            If Not (MaskedTextBoxTelephone.Text) = "" Then
                GunaButtonEnregistrerClient.Visible = True
            End If
        End If

        champDeCompteObligatoire()

    End Sub

    'GESTION DES CHAMPS OBLIGATOIRE DES COMPTES
    Private Sub champDeCompteObligatoire()

        Dim compteur As Integer = 0

        If GunaComboBoxTypeClient.SelectedIndex >= 0 Then

            If GunaComboBoxTypeClient.SelectedValue.ToString = "ENTREPRISE" Or GunaComboBoxTypeClient.SelectedValue.ToString = "COMPANY" Then

                If Trim(GUnaTextBoxNumCompteReal.Text).Equals("") Then
                    GunaButtonEnregistrerClient.Visible = False

                    If compteur > 0 Then
                        compteur -= 1
                    End If

                Else
                    compteur += 1
                End If

                If Trim(GunaTextBoxMontantPlafondsDuCompte.Text).Equals("") Then
                    GunaButtonEnregistrerClient.Visible = False

                    If compteur > 0 Then
                        compteur -= 1
                    End If

                Else
                    compteur += 1
                End If

                If Trim(GunaTextBoxPersonneAContacter.Text).Equals("") Then
                    GunaButtonEnregistrerClient.Visible = False

                    If compteur > 0 Then
                        compteur -= 1
                    End If

                Else
                    compteur += 1
                End If

                If Trim(GunaTextBoxContactPourPaiement.Text).Equals("") Then
                    GunaButtonEnregistrerClient.Visible = False

                    If compteur > 0 Then
                        compteur -= 1
                    End If

                Else
                    compteur += 1
                End If

                If Trim(GunaTextBoxAdresseDeFacturation.Text).Equals("") Then
                    GunaButtonEnregistrerClient.Visible = False

                    If compteur > 0 Then
                        compteur -= 1
                    End If

                Else
                    compteur += 1
                End If

                If Trim(NumericUpDownDelaiDePaiement.Text).Equals("") Then
                    GunaButtonEnregistrerClient.Visible = False

                    If compteur > 0 Then
                        compteur -= 1
                    End If

                Else
                    compteur += 1
                End If

            End If

            If compteur = 6 Then
                GunaButtonEnregistrerClient.Visible = True
            End If

            'MessageBox.Show(compteur)

        Else

        End If

    End Sub

    'TELEPHONE OBLIGATOIRE
    Private Sub MaskedTextBoxTelephone_TextChanged(sender As Object, e As EventArgs) Handles MaskedTextBoxTelephone.TextChanged

        If GunaComboBoxTypeClient.SelectedIndex = 0 Then

            If Trim(GunaTextBoxNomRaisonSociale.Text) = "" Or Trim(MaskedTextBoxTelephone.Text) = "" Or Trim(GunaTextBoxNomDeJeunneFille.Text) = "" Then
                GunaButtonEnregistrerClient.Visible = False
            Else
                GunaButtonEnregistrerClient.Visible = True
            End If

        Else

            If Trim(MaskedTextBoxTelephone.Text) = "" Then
                GunaButtonEnregistrerClient.Visible = False
            Else
                If Not (GunaTextBoxCni.Text) = "" Then
                    GunaButtonEnregistrerClient.Visible = True
                End If
            End If

        End If

        champDeCompteObligatoire()

    End Sub

    'RAISON SOCIALE OBLIGATOIRE
    Private Sub GunaTextBoxNomRaisonSociale_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNomRaisonSociale.TextChanged

        '-------------------------------------------------------------------------------------------

        If Trim(GunaTextBoxNomRaisonSociale.Text).Equals("") Then
            GunaDataGridViewClientExistant.Visible = False
        Else
            GunaDataGridViewClientExistant.Visible = True
        End If

        Dim query As String = "SELECT NOM_CLIENT From client WHERE NOM_PRENOM Like '%" & GunaTextBoxNomRaisonSociale.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = GunaComboBoxTypeClient.SelectedValue

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewClientExistant.DataSource = table
        Else
            GunaDataGridViewClientExistant.Columns.Clear()
            GunaDataGridViewClientExistant.Visible = False
        End If

        If GunaTextBoxNomRaisonSociale.Text.Trim().Equals("") Then
            GunaDataGridViewClientExistant.Columns.Clear()
            GunaDataGridViewClientExistant.Visible = False
        End If

        '-------------------------------------------------------------------------------------------


        If GunaComboBoxTypeClient.SelectedIndex = 0 Then

            If Trim(GunaTextBoxNomRaisonSociale.Text) = "" Or Trim(MaskedTextBoxTelephone.Text) = "" Or Trim(GunaTextBoxNomDeJeunneFille.Text) = "" Then
                GunaButtonEnregistrerClient.Visible = False
            Else
                GunaButtonEnregistrerClient.Visible = True
            End If

        End If

        If GunaComboBoxTypeClient.SelectedIndex >= 0 Then

            Dim TYPE_CLIENT As String = GunaComboBoxTypeClient.SelectedValue.ToString

            If TYPE_CLIENT.Equals("ENTREPRISE") Or TYPE_CLIENT.Equals("COMPANY") Then
                'POUR LES ENTREPRISES ON NE DOIT PRENDRE QUE LA RAISON SOCIALE
                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text)
                GunaTextBoxIntituleDeCompte.Text = INTITULE

            Else

                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text) & " " & Trim(GunaTextBoxPrenom.Text)
                GunaTextBoxIntituleDeCompte.Text = INTITULE

            End If

        End If

        champDeCompteObligatoire()

    End Sub

    'NUM CONTRIBUABLE OBLLIGATOIRE
    Private Sub GunaTextBoxNomDeJeunneFille_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNomDeJeunneFille.TextChanged

        If GunaComboBoxTypeClient.SelectedIndex = 0 Then

            If Trim(GunaTextBoxNomRaisonSociale.Text) = "" Or Trim(MaskedTextBoxTelephone.Text) = "" Or Trim(GunaTextBoxNomDeJeunneFille.Text) = "" Then
                GunaButtonEnregistrerClient.Visible = False
            Else
                GunaButtonEnregistrerClient.Visible = True
            End If

        End If

        champDeCompteObligatoire()

    End Sub

    Private Sub GunaTextBoxPrenom_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPrenom.TextChanged

        If GunaComboBoxTypeClient.SelectedIndex >= 0 Then

            Dim TYPE_CLIENT As String = GunaComboBoxTypeClient.SelectedValue.ToString

            If TYPE_CLIENT.Equals("ENTREPRISE") Then
                'POUR LES ENTREPRISES ON NE DOIT PRENDRE QUE LA RAISON SOCIALE
                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text)
                GunaTextBoxIntituleDeCompte.Text = INTITULE

            Else

                INTITULE = Trim(GunaTextBoxNomRaisonSociale.Text) & " " & Trim(GunaTextBoxPrenom.Text)
                GunaTextBoxIntituleDeCompte.Text = INTITULE

            End If

        End If

    End Sub

    'CRITERES DE RECHERCHES

    'CODE CLIENT
    Private Sub GunaTextBoxRefClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefClient.TextChanged

        If Trim(GunaTextBoxRefClient.Text) = "" Then
            GunaDataGridViewRefClient.Columns.Clear()
            GunaDataGridViewRefClient.Visible = False
        Else
            Recherche.RechercheGenerale(GunaDataGridViewRefClient, "client", "CODE_CLIENT", Trim(GunaTextBoxRefClient.Text), "CODE_CLIENT")
        End If

    End Sub

    Private Sub GunaDataGridViewRefClient_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewRefClient.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewRefClient.Rows(e.RowIndex)

            GunaTextBoxRefClient.Text = Trim(row.Cells("CODE_CLIENT").Value.ToString())

            GunaDataGridViewRefClient.Visible = False

        End If

    End Sub

    'NOM DU CLIENT

    Private Sub GunaTextBoxNomClient_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNomClient.TextChanged

        If Trim(GunaTextBoxNomClient.Text) = "" Then
            GunaDataGridViewNomClient.Columns.Clear()
            GunaDataGridViewNomClient.Visible = False
        Else
            Recherche.RechercheGenerale(GunaDataGridViewNomClient, "client", "NOM_PRENOM", Trim(GunaTextBoxNomClient.Text), "NOM_PRENOM")
        End If

    End Sub

    Private Sub GunaDataGridViewNomClient_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewNomClient.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewNomClient.Rows(e.RowIndex)

            GunaTextBoxNomClient.Text = Trim(row.Cells("NOM_PRENOM").Value.ToString())

            GunaDataGridViewNomClient.Visible = False

        End If

    End Sub

    'TELEPHONE
    Private Sub GunaTextBoxTelephone_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxTelephone.TextChanged

        If Trim(GunaTextBoxTelephone.Text) = "" Then
            GunaDataGridViewTelephone.Columns.Clear()
            GunaDataGridViewTelephone.Visible = False

        Else
            Recherche.RechercheGenerale(GunaDataGridViewTelephone, "client", "TELEPHONE", Trim(GunaTextBoxTelephone.Text), "TELEPHONE")
        End If

    End Sub

    Private Sub GunaDataGridViewTelephone_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewTelephone.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewTelephone.Rows(e.RowIndex)

            GunaTextBoxTelephone.Text = Trim(row.Cells("TELEPHONE").Value.ToString())

            GunaDataGridViewTelephone.Visible = False

        End If

    End Sub

    'ENTREPRISE
    Private Sub GunaTextBoxCodeEntreprise_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCodeEntreprise.TextChanged

        If Trim(GunaTextBoxCodeEntreprise.Text) = "" Then
            GunaDataGridViewEntreprise.Columns.Clear()
            GunaDataGridViewEntreprise.Visible = False
        Else
            Recherche.RechercheGenerale(GunaDataGridViewEntreprise, "client", "NOM_PRENOM", Trim(GunaTextBoxCodeEntreprise.Text), "NOM_PRENOM")
        End If

    End Sub

    Private Sub GunaDataGridViewEntreprise_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewEntreprise.CellClick

        If (e.RowIndex >= 0) Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewEntreprise.Rows(e.RowIndex)

            GunaTextBoxCodeEntreprise.Text = Trim(row.Cells("NOM_PRENOM").Value.ToString())

            GunaDataGridViewEntreprise.Visible = False

        End If

    End Sub

    Private Sub GunaTextBoxAdresseDeFacturation_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxAdresseDeFacturation.TextChanged
        champDeCompteObligatoire()
    End Sub

    Private Sub GunaTextBoxPersonneAContacter_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPersonneAContacter.TextChanged
        champDeCompteObligatoire()
    End Sub

    Private Sub GunaTextBoxContactPourPaiement_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxContactPourPaiement.TextChanged
        champDeCompteObligatoire()
    End Sub

    Private Sub NumericUpDownDelaiDePaiement_TextChanged(sender As Object, e As EventArgs) Handles NumericUpDownDelaiDePaiement.TextChanged
        champDeCompteObligatoire()
    End Sub

    Private Sub GunaTextBoxMontantPlafondsDuCompte_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantPlafondsDuCompte.TextChanged
        champDeCompteObligatoire()
    End Sub

    Public Sub listeDesReservationsDuClient(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal typeClient As Integer)

        Dim query01 As String = ""
        Dim query02 As String = ""
        Dim CODE_CLIENT As String = GunaTextBoxCodeClient.Text

        If typeClient = 0 Then 'INDIVIDUEL

            query01 = "SELECT DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', LIBELLE_TYPE_CHAMBRE As 'TYPE DE CHAMBRE' , CHAMBRE_ID AS 'CHAMBRE', MONTANT_ACCORDE AS 'PRIX/NUITEE', SOLDE_RESERVATION AS 'SOLDE', ETAT_NOTE_RESERVATION AS 'STATUT' FROM reserve_conf, type_chambre WHERE DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CLIENT_ID =@CODE_CLIENT AND reserve_conf.TYPE_CHAMBRE=type_chambre.CODE_TYPE_CHAMBRE ORDER BY DATE_ENTTRE DESC"

            query02 = "SELECT DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', LIBELLE_TYPE_CHAMBRE As 'TYPE DE CHAMBRE' , CHAMBRE_ID AS 'CHAMBRE', MONTANT_ACCORDE AS 'PRIX/NUITEE', SOLDE_RESERVATION AS 'SOLDE', ETAT_NOTE_RESERVATION AS 'STATUT' FROM reservation, type_chambre WHERE DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CLIENT_ID =@CODE_CLIENT AND reservation.TYPE_CHAMBRE=type_chambre.CODE_TYPE_CHAMBRE ORDER BY DATE_ENTTRE DESC"

        ElseIf typeClient = 1 Then ' ENTREPRISE

            query01 = "SELECT DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', LIBELLE_TYPE_CHAMBRE As 'TYPE DE CHAMBRE' , CHAMBRE_ID AS 'CHAMBRE', MONTANT_ACCORDE AS 'PRIX/NUITEE', SOLDE_RESERVATION AS 'SOLDE', ETAT_NOTE_RESERVATION AS 'STATUT' FROM reserve_conf, type_chambre WHERE DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_ENTREPRISE =@CODE_CLIENT AND reserve_conf.TYPE_CHAMBRE=type_chambre.CODE_TYPE_CHAMBRE ORDER BY DATE_ENTTRE DESC"

            query02 = "SELECT DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', LIBELLE_TYPE_CHAMBRE As 'TYPE DE CHAMBRE' , CHAMBRE_ID AS 'CHAMBRE', MONTANT_ACCORDE AS 'PRIX/NUITEE', SOLDE_RESERVATION AS 'SOLDE', ETAT_NOTE_RESERVATION AS 'STATUT' FROM reservation, type_chambre WHERE DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_ENTREPRISE =@CODE_CLIENT AND reservation.TYPE_CHAMBRE=type_chambre.CODE_TYPE_CHAMBRE ORDER BY DATE_ENTTRE DESC"

            'query01 = "SELECT CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_ENTREPRISE =@CODE_CLIENT ORDER BY DATE_ENTTRE DESC"

            'query02 = "SELECT CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reservation WHERE DATE_ENTTRE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_ENTREPRISE =@CODE_CLIENT ORDER BY DATE_ENTTRE DESC"

        End If

        Dim command01 As New MySqlCommand(query01, GlobalVariable.connect)
        command01.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        Dim adapter01 As New MySqlDataAdapter(command01)
        Dim table01 As New DataTable()
        adapter01.Fill(table01)

        Dim command02 As New MySqlCommand(query02, GlobalVariable.connect)
        command02.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        Dim adapter02 As New MySqlDataAdapter(command02)
        Dim table02 As New DataTable()
        adapter02.Fill(table02)

        table01.Merge(table02)

        GunaDataGridViewResaDuClient.Columns.Clear()

        If table01.Rows.Count > 0 Then

            GunaDataGridViewResaDuClient.DataSource = table01

            GunaDataGridViewResaDuClient.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            GunaDataGridViewResaDuClient.DefaultCellStyle.SelectionForeColor = Color.White
            GunaDataGridViewResaDuClient.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewResaDuClient.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewResaDuClient.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewResaDuClient.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridViewResaDuClient.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If
        '-----------------------------------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click

        Dim DateDebut As Date = GunaDateTimePickerCreationCompte.Value.ToShortDateString
        Dim DateFin As Date = GunaDateTimePicker2.Value.ToShortDateString

        Dim typeClient As Integer = 0

        Dim CODE_CLIENT As String = GunaTextBoxCodeClient.Text

        Dim infoSupClient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

        If infoSupClient.Rows.Count > 0 Then

            If infoSupClient.Rows(0)("TYPE_CLIENT") = "ENTREPRISE" Then
                typeClient = 1
            ElseIf infoSupClient.Rows(0)("TYPE_CLIENT") = "INDIVIDUEL" Then
                typeClient = 0
            End If

            listeDesReservationsDuClient(DateDebut, DateFin, typeClient)

        End If

    End Sub

    Public Function listeDesPreferences()

        Dim CODE_CLIENT As String = GunaTextBoxCodeClient.Text

        Dim preferences As DataTable = Functions.allTableFieldsOnConditionOrganised("prefernces_du_client", "CODE_CLIENT", CODE_CLIENT, "PREFERENCE")

        GunaDataGridViewPreferences.Columns.Clear()

        If preferences.Rows.Count > 0 Then

            GunaDataGridViewPreferences.DataSource = preferences

            GunaDataGridViewPreferences.Columns("ID_PREF_CLIENT").Visible = False
            GunaDataGridViewPreferences.Columns("CODE_PREFERENCE").Visible = False
            GunaDataGridViewPreferences.Columns("CODE_CLIENT").Visible = False

        End If


    End Function

    Private Sub GunaButtonAjoutPreference_Click(sender As Object, e As EventArgs) Handles GunaButtonAjoutPreference.Click

        Dim CODE_CLIENT As String = GunaTextBoxCodeClient.Text
        Dim PREFERENCE As String = GunaTextBoxPreference.Text
        Dim CODE_PREFERENCE As String = Functions.GeneratingRandomCodeWithSpecifications("prefernces_du_client", "")

        Dim preferenceDuClient As New Client()

        If Trim(GunaTextBoxCodePreference.Text).Equals("") Then
            preferenceDuClient.insertPreferences(CODE_CLIENT, PREFERENCE, CODE_PREFERENCE)

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Préférence ajoutée avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Preference added successfully", "Preference", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            CODE_PREFERENCE = GunaTextBoxCodePreference.Text

            Functions.DeleteElementByCode(CODE_PREFERENCE, "prefernces_du_client", "CODE_PREFERENCE")

            preferenceDuClient.insertPreferences(CODE_CLIENT, PREFERENCE, CODE_PREFERENCE)

            If GlobalVariable.actualLanguageValue = 1 Then
                MessageBox.Show("Préférence mise à jours avec succès", "Préférence", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Preference successfully updated", "Preference", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

        listeDesPreferences()

        GunaTextBoxPreference.Text = ""
        GunaTextBoxCodePreference.Clear()

    End Sub

    Private Sub GunaButtonAfficherLesPreferences_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLesPreferences.Click
        listeDesPreferences()
    End Sub

    Private Sub GunaDataGridViewPreferences_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPreferences.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPreferences.Rows(e.RowIndex)

            GunaTextBoxCodePreference.Text = row.Cells("CODE_PREFERENCE").Value.ToString()
            GunaTextBoxPreference.Text = row.Cells("PREFERENCE").Value.ToString()

        End If

    End Sub

    '------------------------------------------------- START REGLEMENT ET LETTRAGE DU FROM CLIENT FORM ------------------------------------------
    Structure Facture
        Dim CODE_FACTURE
    End Structure

    Dim ENSEMBLE_DES_FACTURES(10) As Facture

    Private Sub GunaDataGridViewListeFacture_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewListeFacture.CellClick

        Dim MONTANT_TOTAL_DES_FACTURES As Double = 0
        Dim CODE_FACTURE As String = ""

        If GunaDataGridViewListeFacture.Rows.Count > 0 Then

            Dim i As Integer = 0

            Dim TOTAL_LIGNE_FACTURE = 0

            For Each row As DataGridViewRow In GunaDataGridViewListeFacture.SelectedRows

                CODE_FACTURE = Trim(row.Cells(0).Value.ToString)

                If Trim(row.Cells(7).Value.ToString) = "" Then
                    TOTAL_LIGNE_FACTURE = 0
                Else
                    TOTAL_LIGNE_FACTURE = Double.Parse(Trim(row.Cells(7).Value))
                End If

                MONTANT_TOTAL_DES_FACTURES += Double.Parse(TOTAL_LIGNE_FACTURE)

                ENSEMBLE_DES_FACTURES(i).CODE_FACTURE = CODE_FACTURE

                i += 1

            Next

            GunaTextBoxAPayer.Text = Format(Math.Abs(MONTANT_TOTAL_DES_FACTURES), "#,##0")
            GunaTextBoxSolde.Text = Format(Math.Abs(MONTANT_TOTAL_DES_FACTURES), "#,##0")

        End If

        GunaComboBoxNatureOperation.SelectedItem = "REGLEMENT"

    End Sub

    Structure SituationFacture

        Dim dateOperation
        Dim libelleOperation
        Dim Debit
        Dim Credit

    End Structure

    Structure SituationClient

        Dim REFERENCE
        Dim DATE_OPERATION
        Dim NATURE
        Dim LIBELLE
        Dim MONTANT
        Dim MONTANT_SOLDE
        Dim SOLDE

    End Structure

    Private Sub GunaDataGridViewListeFacture_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewListeFacture.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewListeFacture.Rows(e.RowIndex)

            Dim CODE_FACTURE As String = row.Cells("REFERENCE").Value.ToString

            Dim NATURE As String = row.Cells("NATURE").Value.ToString

            If Trim(GunaTextBoxCompteDebiteur.Text).Equals("") And Trim(GunaTextBoxCodeEntreprise.Text).Equals("") Then

                Dim CODE_CLIENT As String = ""

                If Not IsNothing(row.Cells("CODE_CLIENT").Value.ToString) Then

                    CODE_CLIENT = row.Cells("CODE_CLIENT").Value.ToString

                    Dim infoLigneFacture As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "NUMERO_COMPTE")

                    If infoLigneFacture.Rows.Count > 0 Then
                        GunaTextBoxCompteDebiteur.Text = infoLigneFacture.Rows(0)("NUMERO_COMPTE")
                        GunaTextBoxInconnu.Text = infoLigneFacture.Rows(0)("NUMERO_COMPTE")
                        GunaComboBoxTypeDeFiltre.SelectedItem = "Compte"
                    Else

                        infoLigneFacture = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

                        If infoLigneFacture.Rows.Count > 0 Then

                            GunaTextBoxInconnu.Text = infoLigneFacture.Rows(0)("CODE_CLIENT")
                            GunaTextBoxCodeEntreprise.Text = infoLigneFacture.Rows(0)("CODE_CLIENT")

                            If Trim(infoLigneFacture.Rows(0)("TYPE_CLIENT")).Equals("ENTREPRISE") Then
                                GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise"
                            Else
                                GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel"
                            End If

                        End If

                    End If

                End If

            End If

            If NATURE = "FACTURE" Then

                GunaTextBoxCodeFacture.Text = Trim(CODE_FACTURE)

                DetailDeFacture(CODE_FACTURE)

                Dim facture As DataTable = Functions.getElementByCode(CODE_FACTURE, "facture", "CODE_FACTURE")

                If facture.Rows.Count > 0 Then
                    'MessageBox.Show(facture.Rows(0)("RESTE_A_PAYER"))
                    If facture.Rows(0)("RESTE_A_PAYER") = 0 Then
                        GunaButtonEnregistrerReglement.Visible = False
                    Else
                        GunaButtonEnregistrerReglement.Visible = True
                    End If
                End If

            Else

            End If

        End If

    End Sub

    Private Sub ListeDesFacturesEtReglements(ByVal CODE_CLIENT As String, ByVal DateDebut As Date, ByVal DateFin As Date)

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------

        Dim CODE_ENTREPRISE As String = Trim(CODE_CLIENT)

        Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, CODE_CLIENT FROM facture WHERE ETAT_FACTURE = 1 AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
        command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command2.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        'MessageBox.Show(CODE_RESERVATION & " - " & CODE_ENTREPRISE & " / " & tableFacture.Rows.Count)

        'On selectionne l'ensemble des reglement du client n'incluant pas les remboursements
        'Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT) FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND CODE_RESERVATION =@CODE_RESERVATION AND IMPRIMER = 1 AND CODE_MODE = @CODE_MODE ORDER BY DATE_REGLEMENT DESC"
        'Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT) FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 1 AND CODE_MODE = @CODE_MODE ORDER BY DATE_REGLEMENT DESC"
        Dim query3 As String = "SELECT REF_REGLEMENT, MODE_REGLEMENT ,NUM_REGLEMENT, MONTANT_VERSE, DATE_REGLEMENT, TRIM(MODE_REGLEMENT), CODE_MODE , LETTRAGE FROM reglement WHERE CODE_CLIENT = @CODE_CLIENT AND IMPRIMER = 2 ORDER BY DATE_REGLEMENT DESC"
        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)

        command3.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command3.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim CODE_MODE As String = "AVOIR"
        'command3.Parameters.Add("@CODE_MODE", MySqlDbType.VarChar).Value = CODE_MODE

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationClient

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        GunaDataGridViewListeFacture.Rows.Clear()

        'niemElementDutableau += 1

        'Enfin on insere le tout dans notre datagrid

        For j = 0 To tableFacture.Rows.Count - 1

            totalFacture = totalFacture + tableFacture.Rows(j)("MONTANT")

            GunaDataGridViewListeFacture.Rows.Add(tableFacture.Rows(j)("REFERENCE"), CDate(tableFacture.Rows(j)("DATE")).ToShortDateString, "FACTURE", tableFacture.Rows(j)("LIBELLE"), tableFacture.Rows(j)("LETTRAGE"), Format(tableFacture.Rows(j)("MONTANT"), "#,##0"), Format(tableFacture.Rows(j)("MONTANT SOLDE"), "#,##0"), Format(Double.Parse(tableFacture.Rows(j)("MONTANT SOLDE")) - Double.Parse(tableFacture.Rows(j)("MONTANT")), "#,##0"))

        Next

        For k = 0 To tableReglement.Rows.Count - 1

            totalReglement = totalReglement + tableReglement.Rows(k)("MONTANT_VERSE")

            Dim AVOIR As String = "REGLEMENT"

            If Not Trim(tableReglement.Rows(k)("CODE_MODE")).Equals("") Then
                AVOIR = tableReglement.Rows(k)("CODE_MODE")
            End If

            GunaDataGridViewListeFacture.Rows.Add(tableReglement.Rows(k)("NUM_REGLEMENT"), CDate(tableReglement.Rows(k)("DATE_REGLEMENT")).ToShortDateString, AVOIR, tableReglement.Rows(k)("REF_REGLEMENT"), tableReglement.Rows(k)("LETTRAGE"), "", Format(tableReglement.Rows(k)("MONTANT_VERSE"), "#,##0"), "")

        Next

    End Sub

    Private Sub GunaButtonAfficherLesFacturesEtReglement_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficherLesFacturesEtReglement.Click

        GunaDataGridViewListeFacture.Rows.Clear()

        If GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Then
            'We take all the invoice of the current user for reglement and insert the values of the field of RegelementForm
            Dim CODE_CLIENT As String = GunaTextBoxCodeEntreprise.Text
            ListeDesFacturesEtReglements(CODE_CLIENT, GunaDateTimePickerDebutClientForm.Value, GunaDateTimePickerFinClientForm.Value)
        End If

    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click

        If GunaDataGridViewListeFacture.Rows.Count > 0 Then

            Dim NATURE_OPERATION As String = GunaDataGridViewListeFacture.CurrentRow.Cells("NATURE").Value.ToString

            Dim CODE_CLIENT_COMPTE As String = ""

            If GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Then
                CODE_CLIENT_COMPTE = GunaTextBoxCodeEntreprise.Text
            End If

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
            MessageBox.Show("OUps", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub TransférerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransférerToolStripMenuItem.Click

        Dim NATURE_OPERATION As String = GunaDataGridViewListeFacture.CurrentRow.Cells("NATURE").Value.ToString

        If Trim(NATURE_OPERATION) = "FACTURE" Then

            Dim MONTANT_TOTAL_DES_FACTURES As Double = 0
            Dim CODE_FACTURE As String = ""


            If GunaDataGridViewListeFacture.Rows.Count > 0 Then

                Dim i As Integer = 0

                For Each row As DataGridViewRow In GunaDataGridViewListeFacture.SelectedRows

                    CODE_FACTURE = Trim(row.Cells(0).Value.ToString)

                    MONTANT_TOTAL_DES_FACTURES += Double.Parse(Trim(row.Cells(7).Value))

                    ENSEMBLE_DES_FACTURES(i).CODE_FACTURE = CODE_FACTURE

                    i += 1

                Next

                GunaTextBoxAPayer.Text = Format(Math.Abs(MONTANT_TOTAL_DES_FACTURES), "#,##0")

                GunaComboBoxNatureOperation.SelectedItem = "REGLEMENT"

            End If

        Else
            'REGLEMENT DES REGLEMENTS
        End If


    End Sub

    Public Sub DetailDeFacture(ByVal CODE_FACTURE As String)

        Dim query As String = "SELECT CODE_FACTURE, DATE_FACTURE, LIBELLE_FACTURE, MONTANT_TTC FROM ligne_facture WHERE CODE_FACTURE = @CODE_FACTURE AND ETAT_FACTURE = 1 ORDER BY DATE_FACTURE DESC"
        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        Dim adapter As New MySqlDataAdapter(command)
        Dim tableFacture As New DataTable()

        adapter.Fill(tableFacture)

        Dim query1 As String = "SELECT NUM_REGLEMENT, NUM_FACTURE, MONTANT_VERSE, DATE_REGLEMENT, REF_REGLEMENT FROM reglement WHERE NUM_FACTURE = @CODE_FACTURE AND IMPRIMER = 1 ORDER BY DATE_REGLEMENT DESC"
        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim tableReglement As New DataTable()

        adapter1.Fill(tableReglement)

        Dim tailleDuTableau As Integer = tableFacture.Rows.Count + tableReglement.Rows.Count

        'On crée une structure de tableau
        Dim toutesLesFactures(tailleDuTableau) As SituationFacture

        Dim niemElementDutableau As Integer = 0

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        'Puis dans notre structure on ajoute les factures a la suite des reglements
        Dim n = tableFacture.Rows.Count

        For i = 0 To tableFacture.Rows.Count - 1

            toutesLesFactures(i).dateOperation = CDate(tableFacture.Rows(i)("DATE_FACTURE")).ToShortDateString
            toutesLesFactures(i).Debit = tableFacture.Rows(i)("MONTANT_TTC")
            toutesLesFactures(i).Credit = 0
            toutesLesFactures(i).libelleOperation = tableFacture.Rows(i)("LIBELLE_FACTURE")

            totalFacture = totalFacture + tableFacture.Rows(i)("MONTANT_TTC")

        Next

        For i = 0 To tableReglement.Rows.Count - 1

            toutesLesFactures(n).dateOperation = CDate(tableReglement.Rows(i)("DATE_REGLEMENT")).ToShortDateString
            toutesLesFactures(n).Debit = 0
            toutesLesFactures(n).Credit = tableReglement.Rows(i)("MONTANT_VERSE")
            toutesLesFactures(n).libelleOperation = tableReglement.Rows(i)("REF_REGLEMENT")

            totalReglement += tableReglement.Rows(i)("MONTANT_VERSE")

            n += 1

        Next

        'Enfin on insere le tout dans notre datagrid
        If (toutesLesFactures.Length > 0) Then

            GunaDataGridViewDetailsFactures.Rows.Clear()

            For i = 0 To toutesLesFactures.Length - 1

                If Not toutesLesFactures(i).libelleOperation = "" Then
                    GunaDataGridViewDetailsFactures.Rows.Add(CDate(toutesLesFactures(i).dateOperation).ToShortDateString, toutesLesFactures(i).libelleOperation, Format(toutesLesFactures(i).Debit, "#,##0"), Format(toutesLesFactures(i).Credit, "#,##0"))
                End If

            Next

            'Sorting the elements of situation client
            GunaDataGridViewDetailsFactures.Sort(GunaDataGridViewDetailsFactures.Columns(1), ListSortDirection.Descending)

        End If

        GunaTextBoxSolde.Text = Format(totalFacture, "#,##0")

        Dim montantAPayer As Double = 0

        GunaComboBoxNatureOperation.SelectedItem = "REMBOURSEMENT"

        'We affect values to the textbox below the datagrid
        'GunaTextBoxAPayer.Text = Format(totalFacture, "#,##0")

        Dim solde As Double = 0

        Double.TryParse(GunaTextBoxAPayer.Text, solde)
        Dim soldeAregler = solde
        GunaTextBoxSolde.Text = GunaTextBoxAPayer.Text
        'Solde = Debit - credit

        If soldeAregler >= 0 Then '

            GunaComboBoxNatureOperation.SelectedItem = "REGLEMENT"

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelMontantAPayer.Text = "Montant à payer"
                LabelSolde.Text = "Solde à payer"
            Else
                LabelSolde.Text = "Balance to Pay"
                LabelMontantAPayer.Text = "Amount to Pay"
            End If

            GunaTextBoxMontantVerse.Text = 0

            GunaTextBoxReference.Text = GunaComboBoxNatureOperation.SelectedItem & " " & GunaTextBoxNomRaisonSociale.Text & " " & Date.Now()
            'we enable the button as we can pay
            'GunaButtonEnregistrerReglement.Enabled = True

        Else

            ' means we dont have some thing to pay solde a regler is nothing also

            GunaTextBoxAPayer.Text = Format(Double.Parse(GunaTextBoxAPayer.Text) * -1, "#,##0")
            GunaTextBoxMontantVerse.Text = 0

            'We desactivate the button that permit to save as there is nothing to pay
            'GunaButtonEnregistrerReglement.Enabled = False

            If GlobalVariable.actualLanguageValue = 1 Then
                LabelMontantAPayer.Text = "Montant à rembourser"
                LabelSolde.Text = "Solde à rembourser"
                GunaTextBoxReference.Text = "REBOURSEMENT " & GunaTextBoxNomRaisonSociale.Text & " " & GlobalVariable.DateDeTravail
            Else
                LabelMontantAPayer.Text = "Montant to Refund"
                LabelSolde.Text = "Balance to Refund"
                GunaTextBoxReference.Text = "REFUND " & GunaTextBoxNomRaisonSociale.Text & " " & GlobalVariable.DateDeTravail
            End If

        End If

        GunaTextBoxSolde.Enabled = False
        GunaTextBoxAPayer.Enabled = False

    End Sub

    Private Sub GunaButtonEnregistrerClient_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerReglement.Click

        Me.Cursor = Cursors.WaitCursor

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") Then

            'Même si on a le droit a la caisse on doit encore être associé à une caisse pour pouvoir encaisser

            If Functions.getElementByCode(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR"), "caisse", "CODE_UTILISATEUR").Rows.Count > 0 Then

                Dim ETAT_CAISSE As Integer = 0

                Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                Dim CODE_CAISSE As String = ""

                Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                If CAISSE_UTILISATEUR.Rows.Count > 0 Then
                    ETAT_CAISSE = CAISSE_UTILISATEUR.Rows(0)("ETAT_CAISSE")
                End If

                If ETAT_CAISSE = 0 Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        MessageBox.Show("Bien vouloir ouvrir votre caisse!!", "Gestion de caisse", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        MessageBox.Show("Please open your cash box !!", "Cash Box", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    GlobalVariable.fenetreDouvervetureDeCaisse = "reception"

                    passwordVerifivationForm.Show()
                    passwordVerifivationForm.TopMost = True

                Else

                    Dim montantVerse As Double = GunaTextBoxMontantVerse.Text

                    Dim CODE_CLIENT As String = ""

                    Dim CODE_RESERVATION As String = Trim(GunaTextBoxCodeReservation.Text)

                    CODE_CLIENT = Trim(GunaTextBoxCodeEntreprise.Text)

                    If Trim(GunaTextBoxMontantVerse.Text) = "" Then
                        GunaTextBoxMontantVerse.Text = 0
                    End If

                    Dim MODE_REG_INFO_SUP_1 As String = ""
                    Dim MODE_REG_INFO_SUP_2 As String = ""
                    Dim MODE_REG_INFO_SUP_3 As Date = Date.Now().ToShortDateString

                    If GunaComboBoxModeReglementPratique.SelectedIndex = 1 Then
                        MODE_REG_INFO_SUP_1 = GunaComboBoxBanqueEmettrice.SelectedValue.ToString
                        MODE_REG_INFO_SUP_2 = GunaTextBoxCheque.Text
                    ElseIf GunaComboBoxModeReglementPratique.SelectedIndex = 2 Then
                        MODE_REG_INFO_SUP_1 = MaskedTextBoxNumeroCarte.Text
                        MODE_REG_INFO_SUP_2 = MaskedTextBoxCVV.Text
                        MODE_REG_INFO_SUP_3 = GunaDateTimePickerDateExpiration.Value.ToShortDateString()
                    ElseIf GunaComboBoxModeReglementPratique.SelectedIndex = 3 Then
                        MODE_REG_INFO_SUP_1 = GunaTextBoxEntreprise.Text
                        MODE_REG_INFO_SUP_2 = GunaTextBoxNumeroCompte.Text
                    ElseIf GunaComboBoxModeReglementPratique.SelectedIndex = 4 Or GunaComboBoxModeReglementPratique.SelectedIndex = 5 Then
                        MODE_REG_INFO_SUP_1 = GunaTextBoxContact.Text
                    ElseIf GunaComboBoxModeReglementPratique.SelectedIndex = 7 Then 'virement bancaire
                        MODE_REG_INFO_SUP_1 = GunaComboBoxBanqueVirement.SelectedValue.ToString
                        MODE_REG_INFO_SUP_2 = GunaTextBoxReferenceVirement.Text
                    End If

                    'If Double.Parse(GunaTextBoxMontantVerse.Text) >= Double.Parse(GunaTextBoxAPayer.Text) Then
                    If Double.Parse(GunaTextBoxMontantVerse.Text) > 0 Then

                        'We update the state of the values of the invoice
                        Dim facture As New LigneFacture()

                        'We have to update each facture in the list of the client facture
                        Dim montanVerse As Double = GunaTextBoxMontantVerse.Text
                        Dim montanVerseAvantRetranchement As Double = 0

                        'GESTION DES ENCAISSEMENTS
                        'Insert a line into reglement
                        Dim reglement As New Reglement()
                        Dim caisse As New Caisse()

                        Dim NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "")

                        Dim NUM_FACTURE = Trim(GunaTextBoxCodeFacture.Text)

                        Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                        Dim MONTANT_VERSE = Double.Parse(GunaTextBoxMontantVerse.Text)

                        Dim DATE_REGLEMENT = GlobalVariable.DateDeTravail

                        Dim MODE_REGLEMENT As String = ""

                        If GunaComboBoxModeReglementPratique.SelectedIndex >= 0 Then
                            MODE_REGLEMENT = GunaComboBoxModeReglementPratique.SelectedItem
                        End If

                        'Dim MODE_REGLEMENT = GunaComboBoxModeReglement.SelectedItem
                        'Dim MODE_REGLEMENT_INDEX As Integer = GunaComboBoxModeReglement.SelectedIndex
                        Dim MODE_REGLEMENT_INDEX As Integer = GunaComboBoxModeReglementPratique.SelectedIndex
                        Dim REF_REGLEMENT = Trim(GunaTextBoxReference.Text)
                        Dim CODE_MODE = ""
                        Dim IMPRIMER = 2
                        Dim CODE_AGENCE = GlobalVariable.codeAgence

                        '------------------- RECEPTION -----------------
                        'IMPRIMER = 0 : REGLEMENT NOUVELLEMENT GENERE
                        'IMPRIMER = 1 : REGLEMENT CLOTURE DANS LE FOLIO

                        '------------------ BAR / RECEPTION ------------
                        'ETAT = 0 : REGLEMENT NOUVELLEMENT GENERE
                        'ETAT = 1 : REGLEMENT CLOTURE LORS DE LA FERMETURE DE CAISSE POUR NE PLUS L'AFFICHER

                        '----------------- COMPTABILITE ---------------
                        'IMPRIMER = 2 : REGLEMENT NOUVELLEMENT GENERE

                        '----------------- CAISSIER(E) PRINCIPAL(E) -------------------
                        'IMPRIMER = 3 : REGLEMENT NOUVELLEMENT GENERE

                        Dim NUMERO_BLOC_NOTE As String = ""

                        Dim MainForm As New MainWindow()

                        'CAS DE REMBOURSEMENT
                        If Trim(LabelMontantAPayer.Text).Equals("Montant à rembourser") Then

                            Dim factureDeRemboursement As New Facture()

                            Dim CODE_FACTURE As String = Functions.GeneratingRandomCode("facture", "")
                            Dim CODE_COMMANDE As String = ""
                            Dim NUMERO_TABLE As String = ""
                            Dim CODE_MODE_PAIEMENT As String = MODE_REGLEMENT
                            Dim NUM_MOUVEMENT As String = ""
                            Dim DATE_FACTURE As String = GlobalVariable.DateDeTravail
                            Dim CODE_COMMERCIAL As String = ""
                            Dim MONTANT_HT As Double = MONTANT_VERSE
                            Dim TAXE As Double = 0
                            Dim MONTANT_TTC As Double = MONTANT_VERSE
                            Dim AVANCE As Double = MONTANT_VERSE
                            Dim RESTE_A_PAYER As Double = 0
                            Dim DATE_PAIEMENT As Date = GlobalVariable.DateDeTravail
                            Dim ETAT_FACTURE As String = 0
                            Dim LIBELLE_FACTURE As String = GunaTextBoxReference.Text
                            Dim MONTANT_TRANSPORT As Double = 0
                            Dim MONTANT_REMISE As Double = 0
                            Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                            Dim CODE_UTILISATEUR_ANNULE As String = ""
                            Dim CODE_UTILISATEUR_VALIDE As String = ""
                            Dim NOM_CLIENT_FACTURE As String = GunaTextBoxNomRaisonSociale.Text
                            Dim MONTANT_AVANCE As Double = 0
                            Dim TYPE As String = GlobalVariable.typeChambreOuSalle

                            If True Then
                                'apres insertion dans la facture on insère dans ligne facture

                                Dim ligneFactureDeremboursement As New LigneFacture()

                                Dim CODE_MOUVEMENT As String = ""
                                Dim CODE_CHAMBRE As String = ""

                                If GlobalVariable.ReservationToUpdate.Rows.Count > 0 Then
                                    CODE_CHAMBRE = GlobalVariable.ReservationToUpdate.Rows(0)("CHAMBRE_ID")
                                End If

                                Dim NUMERO_PIECE As String = ""
                                Dim CODE_ARTICLE As String = ""
                                Dim CODE_LOT As String = ""
                                Dim QUANTITE As Double = 1
                                Dim PRIX_UNITAIRE_TTC As Double = MONTANT_VERSE

                                Dim HEURE_FACTURE As DateTime = Now().ToShortTimeString()

                                Dim DATE_OCCUPATION As Date = GlobalVariable.DateDeTravail
                                Dim HEURE_OCCUPATION As DateTime = Now().ToShortTimeString()

                                Dim TYPE_LIGNE_FACTURE As String = "Remboursement"
                                Dim NUMERO_SERIE As String = ""
                                Dim NUMERO_ORDRE As String = ""
                                Dim DESCRIPTION As String = ""
                                Dim MONTANT_TAXE As Double = 0
                                Dim NUMERO_SERIE_DEBUT As String = ""
                                Dim NUMERO_SERIE_FIN As String = ""
                                Dim CODE_MAGASIN As String = ""
                                Dim FUSIONNEE As String = ""

                                If ligneFactureDeremboursement.insertLigneFacture(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, NUMERO_BLOC_NOTE) Then

                                    If GlobalVariable.actualLanguageValue = 1 Then
                                        MessageBox.Show("Remboursement effectué avec succès", "Remboursement", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    Else
                                        MessageBox.Show("Refund successfully done", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    End If

                                    'Mise a jours du solde de la caisse du caissier actuellement connecté en moins
                                    'caisse.updateSoldeCaisse(CODE_CAISSIER, MONTANT_VERSE * -1)

                                End If

                            End If

                        Else

                            Dim messageText As String = ""

                            If GlobalVariable.actualLanguageValue = 1 Then
                                messageText = "Règlement enregistré avec succès !!"
                            Else
                                messageText = "Payment made successfully !!"
                            End If

                            If Trim(GunaComboBoxNatureOperation.SelectedItem) = "AVOIR" Then
                                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "AV")
                                CODE_MODE = "AVOIR"
                                messageText = "Avoir enregistré avec succès !!"
                            End If

                            If GunaComboBoxModeReglement.SelectedItem = "Avoir" Then

                                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "AV")
                                CODE_MODE = "AVOIR"
                                MONTANT_VERSE = MONTANT_VERSE * -1

                                If GlobalVariable.actualLanguageValue = 1 Then
                                    messageText = "Règlement réalisé avec un avoir !!"

                                Else
                                    messageText = "Payment made successfully !!"
                                End If

                                'REGELEMENT AVEC AVOIR

                                If (MONTANT_VERSE * -1) <= Double.Parse(GunaTextBoxAPayer.Text) Then
                                    Dim MONTANT_VERSE_PAR_AVOIR As Double = Double.Parse(GunaTextBoxAPayer.Text) * -1

                                    reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE_PAR_AVOIR, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                                End If

                            Else

                                'REGELEMENT NORMAL
                                reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT_VERSE, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                            End If

                            'INSERTION DE INFORMATIONS POUR LES REGLEMENTS ASSOCIES AUX BANQUES
                            If GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 7 Then

                                Dim banque As New Banque()
                                Dim CODE_BANQUE As String = ""

                                If MODE_REGLEMENT_INDEX = 1 Then

                                    If GunaComboBoxBanqueEmettrice.SelectedIndex >= 0 Then
                                        CODE_BANQUE = GunaComboBoxBanqueEmettrice.SelectedValue.ToString
                                    End If

                                End If

                                If MODE_REGLEMENT_INDEX = 2 Then

                                    If GunaComboBoxBanque.SelectedIndex >= 0 Then
                                        CODE_BANQUE = GunaComboBoxBanque.SelectedValue.ToString
                                    End If

                                End If

                                If MODE_REGLEMENT_INDEX = 7 Then

                                    If GunaComboBoxBanqueVirement.SelectedIndex >= 0 Then
                                        CODE_BANQUE = GunaComboBoxBanqueVirement.SelectedValue.ToString
                                    End If

                                End If

                                Dim MODE_REGELEMENT As String = GunaComboBoxModeReglement.SelectedItem
                                Dim CODE_REGLEMENT As String = NUM_REGLEMENT
                                Dim DEBIT As Double = 0
                                Dim CREDIT As Double = GunaTextBoxMontantVerse.Text
                                Dim CODE_TRANSCATION As String = Functions.GeneratingRandomCodePanne("banque_transaction", "")

                                'INFORMATION SUPLLEMTAIRE LIEES A LA CARTE DE CREDIT
                                banque.insertBanqueTransactions(CODE_BANQUE, MODE_REGELEMENT, CODE_REGLEMENT, DEBIT, CREDIT, CODE_AGENCE, CODE_TRANSCATION)


                            End If


                            'Mise a jours du solde de la caisse du caissier actuellement connecté en plus
                            'caisse.updateSoldeCaisse(CODE_CAISSIER, MONTANT_VERSE)

                            'MISE A JOURS DU COMPTE DU CLIENT SI RATTACHE A UNE ENTREPRISE

                            Dim compte As New Compte()

                            Dim compteEntreprise As DataTable = Functions.getElementByCode(CODE_CLIENT, "compte", "CODE_CLIENT")

                            If compteEntreprise.Rows.Count > 0 Then

                                Dim NUMERO_COMPTE As String = compteEntreprise.Rows(0)("NUMERO_COMPTE")

                                Dim TOTAL_DEBIT As Double = 0
                                Dim TOTAL_CREDIT As Double = 0

                                If GunaComboBoxModeReglement.SelectedIndex = 0 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 3 Or GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then

                                    TOTAL_CREDIT = Double.Parse(GunaTextBoxMontantVerse.Text)

                                End If

                                'MISE AJOURS DU COMPTE DE L'ENTREPRISE
                                compte.updateCompteAlaClotureDuFolio(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT)

                            Else

                                Dim NUMERO_COMPTE As String = GunaTextBoxCompteDebiteur.Text

                                Dim TOTAL_DEBIT As Double = 0
                                Dim TOTAL_CREDIT As Double = 0

                                If GunaComboBoxModeReglement.SelectedIndex = 0 Or GunaComboBoxModeReglement.SelectedIndex = 1 Or GunaComboBoxModeReglement.SelectedIndex = 2 Or GunaComboBoxModeReglement.SelectedIndex = 3 Or GunaComboBoxModeReglement.SelectedIndex = 4 Or GunaComboBoxModeReglement.SelectedIndex = 5 Then

                                    TOTAL_CREDIT = Double.Parse(GunaTextBoxMontantVerse.Text)

                                End If

                                If GunaComboBoxTypeDeFiltre.SelectedItem = "Compte" Then
                                    compte.updateCompteApresTrasnfert(NUMERO_COMPTE, TOTAL_DEBIT, TOTAL_CREDIT)
                                Else
                                    compte.updateCompteAlaClotureDuFolio(NUMERO_COMPTE, CODE_CLIENT, TOTAL_DEBIT, TOTAL_CREDIT)
                                End If

                            End If

                            MessageBox.Show(messageText, "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            'We set back montPAyer to 0
                            GunaTextBoxMontantVerse.Text = 0

                        End If

                        If Trim(GunaComboBoxNatureOperation.SelectedItem) = "REGLEMENT" Then

                            '****************************** REGLEMENTS DE L'ENSEMBLE DES FACTURES SELECTIONNEES* **************************************************************************
                            '2klg
                            ReglementDesFacturesSelectionnees(montantVerse)

                        End If

                        effacementDesDetails()

                        ListeDesFacturesEtReglements(Trim(GunaTextBoxCodeEntreprise.Text), GunaDateTimePickerDebutClientForm.Value, GunaDateTimePickerFinClientForm.Value)

                    Else

                        'Montant versé inférieur au montant 

                        If GlobalVariable.actualLanguageValue = 1 Then
                            MessageBox.Show("Bien vouloir saisir un montant correcte!", "Encaissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        Else
                            MessageBox.Show("Type in a correct amount!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If

                        GunaTextBoxMontantVerse.Text = 0

                    End If

                    'Facturation des en chambres
                    Dim reservation As New Reservation()

                    GunaTextBoxCodeFacture.Clear()

                End If

                If GunaComboBoxTypeDeFiltre.SelectedItem = "Entreprise" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individuel" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Individual" Or GunaComboBoxTypeDeFiltre.SelectedItem = "Company" Then
                    'We take all the invoice of the current user for reglement and insert the values of the field of RegelementForm
                    Dim CODE_CLIENT As String = GunaTextBoxCodeEntreprise.Text
                    ListeDesFacturesEtReglements(CODE_CLIENT, GunaDateTimePickerDebutClientForm.Value, GunaDateTimePickerFinClientForm.Value)
                End If

            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ReglementDesFacturesSelectionnees(ByVal montantVerse As Double)

        'CETTE PROCEDURE CE CONTENTE DE METTRE A JOURS LES ETATS DES FACTURES (DEBIT, CREDIT, AVANCE, SOLDE)
        'RECUPERATION DU CODE DE REGLEMENT INSERER
        Dim tableName As String = "reglement"
        Dim codeFieldName As String = "NUM_REGLEMENT"

        Dim CODE_REGLEMENT As String = Functions.latInsertedElementCode(tableName, codeFieldName)

        Dim facture As New Facture()

        Dim montantTotalAPayer As Double = 0

        If Trim(GunaTextBoxMontantVerse.Text) = "" Then
            GunaTextBoxMontantVerse.Text = 0
        End If

        Dim factureSelectionnee As DataTable

        'ENSEMBLE DES FACTURES SELECTIONNEES

        For i = 0 To ENSEMBLE_DES_FACTURES.Length - 1

            Dim CODE_FACTURE As String = ENSEMBLE_DES_FACTURES(i).CODE_FACTURE
            Dim CODE_MODE_PAIEMENT As String = GunaComboBoxModeReglementPratique.SelectedItem.ToString
            Dim DATE_PAIEMENT As Date = GlobalVariable.DateDeTravail
            Dim ETAT_FACTURE As String = 1
            Dim MONTANT_AVANCE As Double = 0
            Dim RESTE_A_PAYER As Double = 0

            'montantTotalAPayer += Functions.getElementByCode(CODE_FACTURE, "facture", "CODE_FACTURE").Rows(i)("MONTANT_TTC")
            factureSelectionnee = Functions.getElementByCode(CODE_FACTURE, "facture", "CODE_FACTURE")

            'TANT QUE LE MONTANT VERSE EST ENCORE SUFFISAMENT GRAND POUR REGLER LES FACTURES

            If factureSelectionnee.Rows.Count > 0 And montantVerse >= 0 Then

                Dim MONTANT_FACTURE_ENCOURS As Double = Double.Parse(factureSelectionnee.Rows(0)("MONTANT_TTC"))
                'ON DETERMINE SI LA FACTURE EST DEJA REGLE OU NON
                If Not Double.Parse(factureSelectionnee.Rows(0)("RESTE_A_PAYER")) = 0 Then

                    'MessageBox.Show(" VERSE: " & montantVerse & " - CODE: " & CODE_FACTURE & " - ENCOURS: " & MONTANT_FACTURE_ENCOURS)

                    If montantVerse >= MONTANT_FACTURE_ENCOURS Then

                        MONTANT_AVANCE = MONTANT_FACTURE_ENCOURS
                        RESTE_A_PAYER = MONTANT_FACTURE_ENCOURS - MONTANT_AVANCE

                        montantVerse -= MONTANT_AVANCE

                    Else

                        MONTANT_AVANCE = montantVerse
                        RESTE_A_PAYER = MONTANT_FACTURE_ENCOURS - MONTANT_AVANCE

                        montantVerse -= MONTANT_AVANCE

                    End If

                    'Dim updateQuery As String = "UPDATE `facture` SET `CODE_MODE_PAIEMENT`=@CODE_MODE_PAIEMENT, `RESTE_A_PAYER`=@RESTE_A_PAYER, `DATE_PAIEMENT`=@DATE_PAIEMENT, `ETAT_FACTURE`=@ETAT_FACTURE, `MONTANT_AVANCE`=MONTANT_AVANCE + @MONTANT_AVANCE WHERE CODE_FACTURE=@CODE_FACTURE"
                    Dim updateQuery As String = "UPDATE `facture` SET `CODE_MODE_PAIEMENT`=@CODE_MODE_PAIEMENT, `DATE_PAIEMENT`=@DATE_PAIEMENT, `ETAT_FACTURE`=@ETAT_FACTURE, `MONTANT_AVANCE`=MONTANT_AVANCE + @MONTANT_AVANCE, AVANCE = MONTANT_AVANCE, `RESTE_A_PAYER`= MONTANT_TTC - MONTANT_AVANCE WHERE CODE_FACTURE=@CODE_FACTURE"

                    Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                    command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

                    command.Parameters.Add("@CODE_MODE_PAIEMENT", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT

                    'command.Parameters.Add("@RESTE_A_PAYER", MySqlDbType.Double).Value = RESTE_A_PAYER
                    command.Parameters.Add("@DATE_PAIEMENT", MySqlDbType.Date).Value = DATE_PAIEMENT
                    command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
                    command.Parameters.Add("@MONTANT_AVANCE", MySqlDbType.Double).Value = MONTANT_AVANCE

                    command.ExecuteNonQuery()

                End If

            End If

            'MISE A JOURS DU LETTRAGE PAR APPORT AU CODE DE REGLEMENT

            'SI ON UTILISE UN AVOIR POUR REGLER :
            '1- ON CREE UN AVOIR A VALEUR NEGATIVE PERMETTANT DE DEDUIRE DE L'AVOIR ORIGINAL 
            '2- LE LETTRAGE DU NOUVELLE AVOIR ET LES FACTURE SERA CELUI DE L'AVOIR ORIGINAL (AVOIR DONT ON DEDUIRA LES MONTANT DE FACTURES)

            'SINON 
            '1- ON CREE UN REGLEMENT DONT SON CODE SERA UTILISE COMME LETTRAGE

            Dim LETTRAGE As String = ""

            LETTRAGE = CODE_REGLEMENT
            'LETTRAGE = CODE_FACTURE ' VALEUR DU LETTRAGE DOIT PLUTOT ETRE LE CODE FACTURE POUR PERMETTRE L'IDENTIFCATION DES REGLEMENTS PARTIELS

            'FACTURE
            Dim TABLE As String = "facture"
            Dim CONDITION_FIELD_NAME As String = "CODE_FACTURE" ' 
            Dim CONDITION_FIELD_VALUE As String = CODE_FACTURE

            miseAJourDuLettrage(TABLE, LETTRAGE, CONDITION_FIELD_NAME, CONDITION_FIELD_VALUE)

            'REGLEMENT
            TABLE = "reglement"
            CONDITION_FIELD_NAME = "NUM_REGLEMENT" '
            CONDITION_FIELD_VALUE = CODE_REGLEMENT
            miseAJourDuLettrage(TABLE, LETTRAGE, CONDITION_FIELD_NAME, CONDITION_FIELD_VALUE)

        Next

        For i = 0 To ENSEMBLE_DES_FACTURES.Length - 1
            ENSEMBLE_DES_FACTURES(i).CODE_FACTURE = ""
        Next

    End Sub

    Public Sub miseAJourDuLettrage(ByVal TABLE As String, ByVal LETTRAGE As String, ByVal CONDITION_FIELD_NAME As String, ByVal CONDITION_FIELD_VALUE As String)

        Dim insertQuery As String = "UPDATE " & TABLE & " SET `LETTRAGE`=@LETTRAGE WHERE " & CONDITION_FIELD_NAME & " = @CONDITION_FIELD_VALUE"

        Dim command1 As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command1.Parameters.Add("@CONDITION_FIELD_VALUE", MySqlDbType.VarChar).Value = CONDITION_FIELD_VALUE
        command1.Parameters.Add("@LETTRAGE", MySqlDbType.VarChar).Value = LETTRAGE

        command1.ExecuteNonQuery()

    End Sub

    Private Sub effacementDesDetails()

        GunaDataGridViewDetailsFactures.Rows.Clear()
        GunaTextBoxCodeFacture.Clear()

        GunaTextBoxAPayer.Text = 0
        GunaTextBoxMontantVerse.Text = 0
        'GunaTextBoxSolde.Text = 0

        GunaTextBoxReference.Clear()

        GunaComboBoxModeReglement.SelectedIndex = 0

    End Sub

    Private Sub GunaComboBoxModeReglementPratique_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxModeReglementPratique.SelectedIndexChanged

        If GunaComboBoxModeReglementPratique.SelectedIndex = 2 Then
            GunaPanelSupplementCarte.Visible = True
            LabelDateExpiration.Visible = True
            LabelNumCarte.Visible = True
            Label18.Visible = True
            LabelCVV.Visible = True
            GunaPanelSupplementCarte.BringToFront()
        Else
            GunaPanelSupplementCarte.Visible = False
            LabelDateExpiration.Visible = False
            LabelNumCarte.Visible = False
            LabelCVV.Visible = False
            Label18.Visible = False

        End If

        If GunaComboBoxModeReglementPratique.SelectedIndex = 1 Then
            GunaPanelSupplementCheque.Visible = True
            LabelBanqueEmettrice.Visible = True
            LabelNumCompte.Visible = True
            GunaPanelSupplementCheque.BringToFront()
        Else
            GunaPanelSupplementCheque.Visible = False
            LabelBanqueEmettrice.Visible = False
            LabelNumCompte.Visible = False

        End If


        If GunaComboBoxModeReglementPratique.SelectedIndex = 3 Then
            GunaPanelPriseEncharge.Visible = True

            LabelEntreprise.Visible = True
            GunaTextBoxEntreprise.Visible = True
            LabelNumeroCompte.Visible = True
            GunaTextBoxNumeroCompte.Visible = True

        Else
            LabelEntreprise.Visible = False
            GunaTextBoxEntreprise.Visible = False
            GunaTextBoxNumeroCompte.Visible = False
            LabelNumeroCompte.Visible = False
            GunaPanelPriseEncharge.Visible = False

        End If

        If GunaComboBoxModeReglementPratique.SelectedIndex = 7 Then
            GunaPanelVirement.Visible = True
            Label20.Visible = True
            Label19.Visible = True
            GunaTextBoxReferenceVirement.Visible = True
        Else
            GunaPanelVirement.Visible = False
            Label20.Visible = False
            Label19.Visible = False
        End If

        If GunaComboBoxModeReglementPratique.SelectedIndex = 4 Or GunaComboBoxModeReglementPratique.SelectedIndex = 5 Then
            GunaPanelMobileMOney.Visible = True
            LabelContact.Visible = True
            GunaTextBoxContact.Visible = True
        Else
            GunaPanelMobileMOney.Visible = False
            LabelContact.Visible = False
            GunaTextBoxContact.Visible = False
        End If

        If GunaComboBoxModeReglementPratique.SelectedIndex = 6 Or GunaComboBoxModeReglementPratique.SelectedIndex = 1 Then
            GunaButtonEnregistrerReglement.Visible = True
        End If

        GunaTextBoxMontantVerse.Text = 0

    End Sub

    Private Sub GunaTextBoxSolde_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxSolde.TextChanged

        Dim balance As Double = 0

        Double.TryParse(GunaTextBoxSolde.Text, balance)

        If balance < 0 Then
            'LabelSolde.Text = "Solde à rembourser"
        Else
            'LabelSolde.Text = "Solde à payer"
        End If

    End Sub

    Private Sub GunaTextBoxPriseEnCharge_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPriseEnCharge.TextChanged

        'Si code de chambre n'existe pas alors on efface toute les informations le concernant
        If Trim(GunaTextBoxPriseEnCharge.Text).Equals("") Then

            GunaTextBoxPriseEnCharge.Clear()

            GunaDataGridViewPriseEnCharge.Visible = False

        End If

        GunaDataGridViewPriseEnCharge.Visible = True

        Dim query As String = "Select NOM_CLIENT From client WHERE NOM_CLIENT Like '%" & GunaTextBoxPriseEnCharge.Text & "%' AND CODE_AGENCE=@CODE_AGENCE AND TYPE_CLIENT=@TYPE_CLIENT"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "ENTREPRISE"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewPriseEnCharge.DataSource = table
        Else
            GunaDataGridViewPriseEnCharge.Columns.Clear()
            GunaDataGridViewPriseEnCharge.Visible = False
        End If

        If GunaTextBoxPriseEnCharge.Text.Trim().Equals("") Then
            GunaDataGridViewPriseEnCharge.Columns.Clear()
            GunaDataGridViewPriseEnCharge.Visible = False
        End If

        'connect.closeConnection()

    End Sub

    Private Sub GunaDataGridViewPriseEnCharge_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPriseEnCharge.CellClick

        GunaDataGridViewPriseEnCharge.Visible = False

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPriseEnCharge.Rows(e.RowIndex)
            Dim company As DataTable = Functions.getElementByCode(row.Cells("NOM_CLIENT").Value.ToString, "client", "NOM_CLIENT")

            GunaTextBoxPriseEnCharge.Text = row.Cells("NOM_CLIENT").Value.ToString
            'GunaTextBoxEntreprise.Text = company.Rows(0)("CODE_CLIENT")

            Dim client As DataTable = Functions.getElementByCode(Trim(GunaTextBoxPriseEnCharge.Text), "client", "NOM_PRENOM")
            Dim codeClient As String = client.Rows(0)("CODE_CLIENT")

            Dim compte As DataTable = Functions.getElementByCode(codeClient, "compte", "CODE_CLIENT")

            If compte.Rows.Count > 0 Then
                GunaTextBoxNumeroCompte.Text = compte.Rows(0)("CODE_CLIENT")
            Else
                GunaTextBoxNumeroCompte.Text = "Pas de compte"
            End If

            GunaDataGridViewPriseEnCharge.Visible = False

            'connect.closeConnection()

        End If

    End Sub

    Public Sub AutoLoadBanque()

        Dim query As String = "SELECT * From banque ORDER BY NOM_BANQUE ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            GunaComboBoxBanque.DataSource = table
            GunaComboBoxBanque.ValueMember = "CODE_BANQUE"
            GunaComboBoxBanque.DisplayMember = "NOM_BANQUE"

            GunaComboBoxBanqueEmettrice.DataSource = table
            GunaComboBoxBanqueEmettrice.ValueMember = "CODE_BANQUE"
            GunaComboBoxBanqueEmettrice.DisplayMember = "NOM_BANQUE"

            GunaComboBoxBanqueVirement.DataSource = table
            GunaComboBoxBanqueVirement.ValueMember = "CODE_BANQUE"
            GunaComboBoxBanqueVirement.DisplayMember = "NOM_BANQUE"

        Else
            GunaComboBoxBanque.Items.Clear()
            GunaComboBoxBanqueEmettrice.Items.Clear()
            GunaComboBoxBanqueVirement.Items.Clear()
        End If

    End Sub

    Private Sub GunaDataGridViewClient_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewClient.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewClient.Rows(e.RowIndex)

            Dim CodeClient As String = row.Cells("CODE CLIENT").Value.ToString()

            TabControl1.SelectedIndex = 0

            'On rempli la description du client pour des eventuelles modifications

            Dim client As DataTable = Functions.getElementByCode(CodeClient, "client", "CODE_CLIENT")

            GunaTextBoxCodeClient.Text = client.Rows(0)("CODE_CLIENT")
            GunaTextBoxNomRaisonSociale.Text = client.Rows(0)("NOM_CLIENT")
            GunaTextBoxPrenom.Text = client.Rows(0)("PRENOMS")
            GunaTextBox12.Text = client.Rows(0)("ADRESSE")
            MaskedTextBoxTelephone.Text = client.Rows(0)("TELEPHONE")
            GunaDateTimePicker1.Value = client.Rows(0)("DATE_DE_NAISSANCE")
            GunaTextBox6.Text = client.Rows(0)("LIEU_DE_NAISSANCE")
            GunaTextBoxNomDeJeunneFille.Text = client.Rows(0)("NOM_JEUNE_FILLE")
            GunaTextBoxFax.Text = client.Rows(0)("FAX")
            GunaTextBoxEmail.Text = client.Rows(0)("EMAIL")
            GunaComboBoxCivilite.SelectedItem = client.Rows(0)("CIVILITE")
            GunaTextBoxCodeMembreElite.Text = client.Rows(0)("CODE_ELITE")

            GunaDataGridViewClientExistant.Visible = False
            '------------------------------------------------------------------------
            'GunaTextBoxNationalite.Text = client.Rows(0)("NATIONALITE")

            'GunaComboBoxPays.SelectedValue = client.Rows(0)("PAYS_RESIDENCE")

            GunaComboBoxPays.SelectedValue = client.Rows(0)("PAYS_RESIDENCE")

            If Trim(GunaTextBoxNationalite.Text).Equals("") Then
                Dim PAYS As String = GunaComboBoxPays.SelectedValue.ToString()
                Dim infoSup As DataTable

                If GlobalVariable.actualLanguageValue = 0 Then

                    infoSup = Functions.getElementByCode(PAYS, "pays", "NOM_PAYS_EN")

                    If infoSup.Rows.Count > 0 Then
                        GunaTextBoxNationalite.Text = infoSup.Rows(0)("NATIONALITE_EN")
                    End If

                Else

                    infoSup = Functions.getElementByCode(PAYS, "pays", "NOM_PAYS_FR")

                    If infoSup.Rows.Count > 0 Then
                        GunaTextBoxNationalite.Text = infoSup.Rows(0)("NATIONALITE_FR")
                    End If

                End If

            End If

            '-------------------------------------------------------------------------
            'GUnaTextBoxNumCompteReal.Text = client.Rows(0)("NUM_COMPTE_COLLECTIF")
            GunaComboBoxTypeClient.SelectedValue = client.Rows(0)("TYPE_CLIENT")
            GunaTextBoxSiteWeb.Text = client.Rows(0)("SITE_INTERNET")
            GunaTextBoxProfession.Text = client.Rows(0)("PROFESSION")
            GunaTextBoxCni.Text = client.Rows(0)("CNI")
            'GunaComboBoxVille.SelectedValue = client.Rows(0)("VILLE_DE_RESIDENCE")
            GunaTextBox5.Text = client.Rows(0)("VILLE_DE_RESIDENCE")
            GunaComboBoxModeReglement.SelectedItem = client.Rows(0)("CODE_MODE_PAIEMENT")
            GunaComboBoxModeTransport.SelectedItem = client.Rows(0)("MODE_TRANSPORT")
            GunaTextBoxNumVehicule.Text = client.Rows(0)("NUM_VEHICULE")

            GunaTextBoxMarqueVehicule.Text = client.Rows(0)("MARQUE_VEHICULE")
            GunaTextBoxEntreprise.Text = client.Rows(0)("CODE_ENTREPRISE")

            If client.Rows(0)("TVA") = 1 Then
                GunaCheckBoxTVA.Checked = True
            Else
                GunaCheckBoxTVA.Checked = False
            End If

            'LE NUMERO DE COMPTE N'EXISTE PAS DONC NUMERO DE COMPTE PROVIENT DES INFOS DU CLIENT
            GUnaTextBoxNumCompteReal.Text = client.Rows(0)("NUM_COMPTE")

            'ATTRIBUTION DES INFORMATION DE COMPTE FINANCE

            Dim compte As DataTable = Functions.getElementByCode(GunaTextBoxCodeClient.Text, "compte", "CODE_CLIENT")

            If compte.Rows.Count > 0 Then

                If Not Trim(compte.Rows(0)("NUMERO_COMPTE")) = "" Then
                    'LE NUMERO DE COMPTE EXISTE
                    GUnaTextBoxNumCompteReal.Text = Trim(compte.Rows(0)("NUMERO_COMPTE")) ' NUMERO DE COMPTE
                Else
                    GUnaTextBoxNumCompteReal.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", INDICE_DE_COMPTE))
                End If

                GunaTextBoxIntituleDeCompte.Text = Trim(compte.Rows(0)("INTITULE")) ' INTITULE DE COMPTE

                GunaTextBoxPersonneAContacter.Text = Trim(compte.Rows(0)("PERSONNE_A_CONTACTER")) ' INTITULE DE COMPTE
                GunaTextBoxContactPourPaiement.Text = Trim(compte.Rows(0)("CONTACT_PAIEMENT")) ' INTITULE DE COMPTE
                GunaTextBoxAdresseDeFacturation.Text = Trim(compte.Rows(0)("ADRESSE_DE_FACTURATION")) ' INTITULE DE COMPTE

                If compte.Rows(0)("PLAFONDS_DU_COMPTE") >= 0 Then
                    GunaTextBoxMontantPlafondsDuCompte.Text = Format(compte.Rows(0)("PLAFONDS_DU_COMPTE"), "#,##0.00")
                Else
                    GunaTextBoxMontantPlafondsDuCompte.Text = 0
                End If

                If compte.Rows(0)("DELAI_DE_PAIEMENT") >= 0 Then
                    NumericUpDownDelaiDePaiement.Text = Trim(compte.Rows(0)("DELAI_DE_PAIEMENT"))
                Else
                    NumericUpDownDelaiDePaiement.Text = 0
                End If

                If compte.Rows(0)("ETAT_DU_COMPTE") = 1 Then
                    GunaCheckBoxActivationDesactivationDuCompte.Checked = True
                Else
                    GunaCheckBoxActivationDesactivationDuCompte.Checked = False
                End If

            Else

                GUnaTextBoxNumCompteReal.Text = Trim(Functions.GeneratingRandomCodeAccountNumber("compte", INDICE_DE_COMPTE))

            End If

            '-------------------------------------------------------------

            If Not Trim(GunaTextBoxEntreprise.Text).Equals("") Then

                Dim infoSupEntreprise As DataTable = Functions.getElementByCode(GunaTextBoxEntreprise.Text, "client", "CODE_CLIENT")
                If infoSupEntreprise.Rows.Count > 0 Then
                    GunaTextBoxCompanyName.Text = infoSupEntreprise.Rows(0)("NOM_PRENOM")
                Else
                    GunaTextBoxEntreprise.Clear()
                End If

            End If

            Functions.AffectingTitleToAForm(GunaTextBoxNomRaisonSociale.Text + " " + GunaTextBoxPrenom.Text, GunaLabelTitreForm)

            'AssignACompanyToClient()

            'ONT CHARGENT LES DONNEES DES TARIF DU CLIENT

            Dim tarifs As New Tarifs

            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Clear()

            Dim CODE_CLIENT = client.Rows(0)("CODE_CLIENT")

            tarifsAffectesAuxClient(CODE_CLIENT)

            'connect.closeConnection()

            'ON rempli les entetes du datagrid des tarif pour éviterqu'il ne se répète
            GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.BringToFront()
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("ID_TARIF_PRIX", "ID")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("CODE_TARIF", "CODE APPLIQUE")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("TYPE_TARIF", "TYPE TARIF")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("CODE_TYPE", "CODE TYPE")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF_ENCOURS", "PRIX ENCOURS")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF1", "PRIX 1")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF2", "PRIX 2")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF3", "PRIX 3")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF4", "PRIX 4")
            'GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Columns.Add("PRIX_TARIF5", "PRIX 5")

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrerClient.Text = "Sauvegarder"
            Else
                GunaButtonEnregistrerClient.Text = "Update"
            End If

        End If

    End Sub

    Public Sub situationDuClientEntreprise(ByVal CODE_CLIENT As String)

        ' ------------------------------ display of information into datagrid in the form dateOperation-Libelle-Debit-Credit -----------------------------

        Dim CODE_ENTREPRISE As String = Trim(CODE_CLIENT)

        'Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE  FROM facture WHERE ETAT_FACTURE = 1 AND CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        Dim query2 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE  FROM facture WHERE CODE_CLIENT=@CODE_CLIENT ORDER BY DATE_FACTURE DESC"
        Dim command2 As New MySqlCommand(query2, GlobalVariable.connect)
        command2.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        'command2.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim adapter2 As New MySqlDataAdapter(command2)
        Dim tableFacture As New DataTable()

        adapter2.Fill(tableFacture)

        Dim totalFacture As Double = 0
        Dim totalReglement As Double = 0

        For j = 0 To tableFacture.Rows.Count - 1
            totalFacture = totalFacture + tableFacture.Rows(j)("MONTANT")
            totalReglement += tableFacture.Rows(j)("MONTANT SOLDE")
        Next

        GunaTextBoxSoldeCompte.Text = Format(Double.Parse(totalReglement) - Double.Parse(totalFacture), "#,##0")

    End Sub

    Private Sub GunaTextBoxPreference_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxPreference.TextChanged

    End Sub

    Private Sub GunaComboBoxPays_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxPays.SelectedIndexChanged

        If GunaComboBoxPays.SelectedIndex >= 0 Then

            Dim PAYS As String = GunaComboBoxPays.SelectedValue.ToString()
            Dim infoSup As DataTable

            If GlobalVariable.actualLanguageValue = 0 Then

                infoSup = Functions.getElementByCode(PAYS, "pays", "NOM_PAYS_EN")

                If infoSup.Rows.Count > 0 Then
                    GunaTextBoxNationalite.Text = infoSup.Rows(0)("NATIONALITE_EN")
                End If

            Else

                infoSup = Functions.getElementByCode(PAYS, "pays", "NOM_PAYS_FR")

                If infoSup.Rows.Count > 0 Then
                    GunaTextBoxNationalite.Text = infoSup.Rows(0)("NATIONALITE_FR")
                End If

            End If

        End If

    End Sub

    Private Sub GunaButton2_Click_2(sender As Object, e As EventArgs) Handles GunaButton2.Click

        TabControl1.SelectedIndex = 0

        GunaButtonEnregistrerClient.Visible = False

    End Sub

    Private Sub GunaDataGridViewTarifsAuquelOnAEffecteDesPrix_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewTarifsAuquelOnAEffecteDesPrix.Rows(e.RowIndex)

            Dim ID_TARIF_PRIX As Integer = row.Cells("ID_TARIF_PRIX").Value.ToString()
            Dim PRIX_TARIF_ENCOURS As Double = row.Cells("PRIX_TARIF_ENCOURS").Value.ToString()

            GunaTextBoxIDTarifPrix.Text = ID_TARIF_PRIX

            GunaButtonEnregistrerTarifs.Text = "Sauvegarder"

            Dim tarif As DataTable = Functions.getElementByCode(ID_TARIF_PRIX, "tarif_prix", "ID_TARIF")

            If tarif.Rows.Count > 0 Then

                GunaTextBoxCodeApplique.Text = tarif.Rows(0)("CODE_TARIF") & " - " & tarif.Rows(0)("LIBELLE_TARIF")
                GunaTextBoxTypeTarif.Text = tarif.Rows(0)("TYPE_TARIF")
                GunaTextBoxCodeType.Text = tarif.Rows(0)("CODE_TYPE")

                GunaTextBoxPrix1.Text = Format(tarif.Rows(0)("PRIX_TARIF1"), "#,##0")
                GunaTextBoxPrix2.Text = Format(tarif.Rows(0)("PRIX_TARIF2"), "#,##0")
                GunaTextBoxPrix3.Text = Format(tarif.Rows(0)("PRIX_TARIF3"), "#,##0")
                GunaTextBoxPrix4.Text = Format(tarif.Rows(0)("PRIX_TARIF4"), "#,##0")
                GunaTextBoxPrix5.Text = Format(tarif.Rows(0)("PRIX_TARIF5"), "#,##0")

                If PRIX_TARIF_ENCOURS = Double.Parse(GunaTextBoxPrix1.Text) Then
                    If Not Trim(GunaTextBoxPrix1.Text).Equals("") Then
                        P1.Checked = True
                    End If
                ElseIf PRIX_TARIF_ENCOURS = Double.Parse(GunaTextBoxPrix2.Text) Then
                    If Not Trim(GunaTextBoxPrix2.Text).Equals("") Then
                        P2.Checked = True
                    End If
                ElseIf PRIX_TARIF_ENCOURS = Double.Parse(GunaTextBoxPrix3.Text) Then
                    If Not Trim(GunaTextBoxPrix3.Text).Equals("") Then
                        P3.Checked = True
                    End If
                ElseIf PRIX_TARIF_ENCOURS = Double.Parse(GunaTextBoxPrix4.Text) Then
                    If Not Trim(GunaTextBoxPrix4.Text).Equals("") Then
                        P4.Checked = True
                    End If
                ElseIf PRIX_TARIF_ENCOURS = Double.Parse(GunaTextBoxPrix5.Text) Then
                    If Not Trim(GunaTextBoxPrix5.Text).Equals("") Then
                        P5.Checked = True
                    End If
                End If
                GunaTextBoxIDTarifPrix.Text = tarif.Rows(0)("ID_TARIF")

                GunaTextBoxCodeAAppliquer.Text = tarif.Rows(0)("CODE_TARIF")

            End If

            If Not Trim(GunaTextBoxCodeClient.Text).Equals("") Then
                GunaButtonEnregistrerTarifs.Enabled = True
            Else
                GunaButtonEnregistrerTarifs.Enabled = False
            End If

            GunaDataGridViewTarifsAppliquable.Visible = False

        End If

    End Sub

    Private Sub GunaTextBoxNomRaisonSociale_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxNomRaisonSociale.Leave
        GunaDataGridViewClientExistant.Visible = False
        GunaDataGridViewClientExistant.Columns.Clear()
    End Sub

    Private Sub MaskedTextBox1_TextChanged(sender As Object, e As EventArgs) Handles MaskedTextBox1.TextChanged, MaskedTextBoxPieceDu.TextChanged

        If Not MaskedTextBox1.Text.Equals("  /  /") Then

            Dim phone As String = Trim(MaskedTextBox1.Text)

            If phone.Length = 10 Then

                If Not MaskedTextBox1.Text.Contains("_") Then

                    If Not MaskedTextBox1.Text.Contains("_") Then

                        GunaDateTimePicker1.Value = CDate(MaskedTextBox1.Text).ToShortDateString

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub GunaButtonExporter_Click(sender As Object, e As EventArgs) Handles GunaButtonExporter.Click

        Me.Cursor = Cursors.WaitCursor

        Dim index As Integer = 6
        Dim indexForPrint As Integer = 7
        Dim title As String = "LISTE DES CLIENTS "

        Dim dateAfficher As Date = GlobalVariable.DateDeTravail.ToShortDateString

        Impression.exportationDuCardexVersExcel(GunaDataGridViewClient, title)

        Me.Cursor = Cursors.Default

    End Sub

    Dim message As String = ""
    Dim title As String = ""

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
                    message = "Impossible de créer la Carte Elite, ce client a déjà une Carte Elite."
                    title = "Gestion Des Cartes Elites"
                Else
                    message = "Impossible to create the Elite Card, This user already have one."
                    title = "Elite Card Management"
                End If

                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                exist = Functions.GetAllElementsOnCondition(ID_CARTE_ELITE, "club_elite_membre_client", "ID_CARTE_ELITE")

                If (exist.Rows.Count > 0) And (GunaButtonCreateEliteCarte.Text = "Créer" Or GunaButtonCreateEliteCarte.Text = "Create") Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        message = "Impossible de créer la Carte Elite, cette carte est déjà attribuée."
                        title = "Gestion Des Cartes Elites"
                    Else
                        message = "Impossible to create the Elite Card, this Card is already used."
                        title = "Elite Card Management"
                    End If

                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else

                    If GunaButtonCreateEliteCarte.Text = "Créer" Or GunaButtonCreateEliteCarte.Text = "Create" Then

                        elite.affectationElite(TYPE_MEMBRE, CODE_CLIENT_CARTE, ID_CARTE_ELITE)

                        If GlobalVariable.actualLanguageValue = 1 Then
                            message = "Carte Elite Crée avec succès"
                            title = "Gestion Des Cartes Elites"
                        Else
                            message = "Elite Carte Successfully Created"
                            title = "Elite Card Management"
                        End If

                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        elite.updateAffectationElite(TYPE_MEMBRE, CODE_CLIENT_CARTE, ID_CARTE_ELITE, ID_CARTE_ELITE_OLD)

                        If GlobalVariable.actualLanguageValue = 1 Then
                            message = "Carte Elite Mise à jour avec succès"
                            title = "Gestion Des Cartes Elites"
                        Else
                            message = "Elite Carte Successfully updated"
                            title = "Elite Card Management"
                        End If

                        If GlobalVariable.actualLanguageValue = 1 Then
                            GunaButtonCreateEliteCarte.Text = "Enregistrer"
                        Else
                            GunaButtonCreateEliteCarte.Text = "Save"
                        End If

                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    Functions.updateOfFields("client", "CODE_ELITE", ID_CARTE_ELITE, "CODE_CLIENT", CODE_CLIENT_CARTE, 2)

                End If

                GunaDataGridViewCodeEliteMembre.DataSource = Nothing

                Dim UPGRADE As Integer = 0
                listEliteCode(UPGRADE, GunaDataGridViewToUpgrade)

                GunaTextBoxCodeClientCarte.Text = ""
                GunaTextBoxNomClientCarte.Text = ""
                GunaTextBoxIdCarteMembre.Text = ""
                GunaTextBoxOldIdCarte.Text = ""

            End If

        Else

            If GlobalVariable.actualLanguageValue = 1 Then
                message = "Bien vouloir Remplir tous les champs"
                title = "Gestion Des Cartes Elites"
            Else
                message = "Please Fill all the fields"
                title = "Elite Card Management"
            End If

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)

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

    Private Sub listEliteCode(ByVal UPGRADE As Integer, ByVal dt As DataGridView)

        Dim elite As New ClubElite()
        elite.list(dt, UPGRADE)
        If GunaDataGridViewCodeEliteMembre.Rows.Count > 0 Then

            If UPGRADE = 0 Then
                GunaDataGridViewCodeEliteMembre.Columns(6).Visible = False
                GunaLabel46.Text = "(" & dt.Rows.Count & ")"
            ElseIf UPGRADE = 1 Then
                GunaDataGridViewToUpgrade.Columns(6).Visible = False
                GunaLabel48.Text = "(" & dt.Rows.Count & ")"
            End If

        Else
            GunaLabel46.Text = "(" & 0 & ")"
        End If

    End Sub


    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click

        Dim UPGRADE As Integer = 0

        GunaTextBoxLike.Clear()
        listEliteCode(UPGRADE, GunaDataGridViewCodeEliteMembre)

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

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim CODE_ELITE As String = GunaDataGridViewCodeEliteMembre.CurrentRow.Cells(2).Value.ToString()
        Dim CODE_CLIENT As String = GunaDataGridViewCodeEliteMembre.CurrentRow.Cells(6).Value.ToString()

        Dim elite As New ClubElite()

        Dim dt As DataTable = elite.historiquesAccummulationDesPoints(CODE_ELITE, CODE_CLIENT)

        If dt.Rows.Count > 0 Then
            GunaDataGridViewHistoriquesDesPoints.DataSource = Nothing
            GunaDataGridViewHistoriquesDesPoints.DataSource = dt
            TabControl1.SelectedIndex = 6
        End If

    End Sub

    'LISTE DES PERSONNES POUVANT UPGRADE AU STATUT SUPERIEUR
    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click

        Dim UPGRADE As Integer = 1

        GunaTextBoxLike.Clear()
        listEliteCode(UPGRADE, GunaDataGridViewToUpgrade)

    End Sub

End Class