Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Wizard

    'Dim connect As New DataBaseManipulation()

    Dim couleurDuPanneauActif As Color
    Dim panneauActif As String = ""
    Dim panneauPrecedent As String = ""
    Dim panneauSuivant As String = ""

    Private Sub Wizard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Inserting room categories into combobox
        SalleCategoriesListFromDataBase()

        'Listing all the salle
        salleListe()

        SalleTypeList()

        'Filling the country and twon list in the combox box of the tax panel
        FillingCountryTownComboBox()

        'Listing all the rooms categories in the TypeChambre Panel
        roomCategoriesList()

        'Listing all the rooms categories symboles in the TypeChambre Panel
        RoomSymboleList()

        'Listing room Categories from database
        roomCategoriesListFromDataBase()

        'connect.closeConnection()

        GunaPanelWizardWelcome.Show()
        GunaPanelCreationDeChambre.Hide()
        GunaPanelTaxes.Hide()
        GunaPanelTypeDeChambre.Hide()
        GunaPanelCreationSalleDeFete.Hide()

    End Sub

    'GESTION DES BOUTONS SUIVANT DES DIVERS PANNEAUX

    'Bouton Suivant du Panneau Welcome de configuration 
    Private Sub GunaButtonSuivantWizard_Click_1(sender As Object, e As EventArgs) Handles GunaButtonSuivantWizard.Click

        If Not (TextBoxNomSociete.Text.Trim().Equals("")) And Not (TextBoxAgenceActuelle.Text.Trim().Equals("")) Then

            'Listing all the rooms categories in the TypeChambre Panel
            roomCategoriesList()

            'Listing all the rooms categories symboles in the TypeChambre Panel
            RoomSymboleList()

            'vérification d'existence de la société et d'une agence dans la base de donné

            Dim RAISON_SOCIALE As String = TextBoxNomSociete.Text
            Dim NOM_AGENCE As String = TextBoxAgenceActuelle.Text

            Dim connect As New DataBaseManipulation()

            'We determine if it is the first connexion by searching a society in database
            Dim existQuery As String = "SELECT * From societe"
            Dim existAgencyQuery As String = "SELECT * From agence"

            Dim commandCompany As New MySqlCommand(existQuery, GlobalVariable.connect)
            Dim commandAgency As New MySqlCommand(existAgencyQuery, GlobalVariable.connect)

            Dim adapterCompany As New MySqlDataAdapter(commandCompany)
            Dim adapterAgency As New MySqlDataAdapter(commandAgency)

            Dim tableCompany As New DataTable()
            Dim tableAgency As New DataTable()

            adapterCompany.Fill(tableCompany)
            adapterAgency.Fill(tableAgency)


            '------------------- AGENCY MANGEMENT -------------------------


            'Gestion du Thème choisis

            If (GunaRadioButtonColorBlue.Checked) Then
                GlobalVariable.couleurTheme = "Color.FromArgb(200, 52, 152, 219)"
            ElseIf (GunaRadioButtonColorGrey.Checked) Then
                GlobalVariable.couleurTheme = "Color.FromArgb(200, 149, 165, 166)"
            Else
                GlobalVariable.couleurTheme = "Color.FromArgb(205, 255, 255, 255)"
            End If

            'We take the agency code to be used allover the program
            Dim CODE_AGENCE = Functions.GeneratingRandomCode("agence", "")
            GlobalVariable.codeAgence = CODE_AGENCE

            'If something exist (company) in database when am in welcome pannel then previous button has been pressed
            If (tableAgency.Rows.Count > 0) Then
                'connect.closeConnection()
                'Delete the database
                Dim deleteQeury As String = "DELETE FROM agence"
                Dim commandDeleteAgency As New MySqlCommand(deleteQeury, GlobalVariable.connect)

                'Opening the connection
                connect.openConnection()

                'Generating random Code

                'Excuting the command and testing if everything went on well after deleting
                If (commandDeleteAgency.ExecuteNonQuery() = 1) Then

                    Dim insertAfterDelete As String = "INSERT INTO `agence` (`NOM_AGENCE`,`CODE_AGENCE`,`COULEUR_THEME`) VALUES (@NOM_AGENCE,@CODE_AGENCE, @COULEUR_THEME)"

                    Dim commandAfterDelete As New MySqlCommand(insertAfterDelete, GlobalVariable.connect)

                    commandAfterDelete.Parameters.Add("@NOM_AGENCE", MySqlDbType.VarChar).Value = NOM_AGENCE
                    commandAfterDelete.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
                    commandAfterDelete.Parameters.Add("@COULEUR_THEME", MySqlDbType.VarChar).Value = GlobalVariable.couleurTheme

                    'Opening the connection
                    connect.openConnection()

                    'Excuting the commandAfterDelete and testing if everything went on well
                    If (commandAfterDelete.ExecuteNonQuery() = 1) Then
                        'connect.closeConnection()
                        'MessageBox.Show("Modification d'agence enregistréeavec succès!!", "Nom Agence", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        'connect.closeConnection()
                        MessageBox.Show("Erreur lors de la modification!!", "Nom Agence", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    'connect.closeConnection()

                Else

                    'Si une erreur se produit lors de l'exécution de la requette
                    'connect.closeConnection()

                End If

            Else
                'on insère directment car c'est premiere apparition du panneau welcome

                Dim insertQuery As String = "INSERT INTO `agence` (`NOM_AGENCE`,`CODE_AGENCE`, `COULEUR_THEME`) VALUES (@NOM_AGENCE, @CODE_AGENCE, @COULEUR_THEME)"

                Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

                command.Parameters.Add("@NOM_AGENCE", MySqlDbType.VarChar).Value = NOM_AGENCE
                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
                command.Parameters.Add("@COULEUR_THEME", MySqlDbType.VarChar).Value = GlobalVariable.couleurTheme

                'Opening the connection
                connect.openConnection()

                'Excuting the command and testing if everything went on well
                If (command.ExecuteNonQuery() = 1) Then
                    'connect.closeConnection()
                    'MessageBox.Show("Nom d'agence enregistré avec succès!!", "Nom Agence", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    'connect.closeConnection()
                    MessageBox.Show("Erreur lors de l'enregistrement!!", "Nom Agence", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If

            '---------------------- END AGENCY MANAGEMENT ---------------------------

            '---------------------- COMPANY MANAGEMENT -----------------------------

            'Generating Random Code
            Dim CODE_SOCIETE = Functions.GeneratingRandomCode("societe", "")
            GlobalVariable.codeSociete = CODE_SOCIETE

            'If something exist (company) in database when am in welcome pannel then previous button has been pressed
            If (tableCompany.Rows.Count > 0) Then
                'connect.closeConnection()
                'Delete the database
                Dim deleteQeury As String = "DELETE FROM societe"
                Dim commandDeleteCompany As New MySqlCommand(deleteQeury, GlobalVariable.connect)

                'Opening the connection
                connect.openConnection()

                'Excuting the command and testing if everything went on well after deleting
                If (commandDeleteCompany.ExecuteNonQuery() = 1) Then

                    Dim insertAfterDelete As String = "INSERT INTO `societe` (`RAISON_SOCIALE`,`CODE_SOCIETE`,`CODE_AGENCE_ACTUEL`) VALUES (@RAISON_SOCIALE, @CODE_SOCIETE,@CODE_AGENCE_ACTUEL)"

                    Dim commandAfterDelete As New MySqlCommand(insertAfterDelete, GlobalVariable.connect)

                    commandAfterDelete.Parameters.Add("@RAISON_SOCIALE", MySqlDbType.VarChar).Value = RAISON_SOCIALE
                    commandAfterDelete.Parameters.Add("@CODE_SOCIETE", MySqlDbType.VarChar).Value = CODE_SOCIETE
                    commandAfterDelete.Parameters.Add("@CODE_AGENCE_ACTUEL", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

                    'Opening the connection
                    connect.openConnection()

                    'Excuting the commandAfterDelete and testing if everything went on well
                    If (commandAfterDelete.ExecuteNonQuery() = 1) Then
                        'connect.closeConnection()
                        'MessageBox.Show("Modification enregistrée avec succès!!", "Nom Société", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        'connect.closeConnection()
                        MessageBox.Show("Erreur lors de la modification!!", "Nom Société", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    'connect.closeConnection()

                Else

                    'Si une erreur se produit lors de l'exécution de la requette
                    'connect.closeConnection()

                End If

            Else
                'on insère directment car c'est premiere apparition du panneau welcome

                Dim insertQuery As String = "INSERT INTO `societe` (`RAISON_SOCIALE`,`CODE_SOCIETE`,`CODE_AGENCE_ACTUEL`) VALUES (@RAISON_SOCIALE, @CODE_SOCIETE,@CODE_AGENCE_ACTUEL)"

                Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

                command.Parameters.Add("@RAISON_SOCIALE", MySqlDbType.VarChar).Value = RAISON_SOCIALE
                command.Parameters.Add("@CODE_SOCIETE", MySqlDbType.VarChar).Value = CODE_SOCIETE
                command.Parameters.Add("@CODE_AGENCE_ACTUEL", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

                'Opening the connection
                connect.openConnection()

                'Excuting the command and testing if everything went on well
                If (command.ExecuteNonQuery() = 1) Then
                    'connect.closeConnection()
                    'MessageBox.Show("Nom enregistré avec succès!!", "Nom Société", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    'connect.closeConnection()
                    MessageBox.Show("Erreur lors de l'enregistrement!!", "Nom Société", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

            GunaPanelWizardWelcome.Hide()
            GunaPanelTaxes.Show()
            GunaPanelTypeDeChambre.Hide()
            GunaPanelCreationDeChambre.Hide()
            GunaPanelCreationSalleDeFete.Hide()

            'Coloration des intitulés des panneau actifs
            couleurDuPanneauActif = Color.FromArgb(200, 230, 126, 34)
            PanelTaxes.BackColor = Color.White
            PanelTypeDeChambre.BackColor = Color.White
            PanelWelcomeTax.BackColor = couleurDuPanneauActif

        Else
            'Of the field of the welcome panel is empty
            MessageBox.Show("Bien vouloir remplir tous les champs !!", "Welcome Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    '------------------- END COMPANY INSERTION MANAGMENT

    'Bouton Suivant du Panneau Taxe de chambre de configuration 
    Private Sub GunaButtonSuivantTaxe_Click(sender As Object, e As EventArgs) Handles GunaButtonSuivantTaxe.Click

        ' Refresh the Room Categories List
        roomCategoriesList()

        'Récupération du nom de la société à modifier pour le mettre à jour avec les nouvelle infos
        Dim existQuery As String = "SELECT * From societe"

        Dim commandCompany As New MySqlCommand(existQuery, GlobalVariable.connect)

        Dim adapterCompany As New MySqlDataAdapter(commandCompany)
        Dim tableCompany As New DataTable()
        adapterCompany.Fill(tableCompany)

        If (tableCompany.Rows.Count > 0) Then
            '---------------------------------INSERTING A SELECTED VALUE OF COMBOBOX INITIALLY FROM DATABSE INTO A VARIABLE
            Dim ID_SOCIETE As Integer = tableCompany.Rows(0)("ID_SOCIETE")
            Dim CODE_SOCIETE As String = tableCompany.Rows(0)("CODE_SOCIETE")
            Dim TAUX_CHAMBRE As Double = NumericUpDownTauxChambre.Value
            Dim TAUX_REPAS As Double = NumericUpDownTauxRepas.Value
            Dim TAUX_PRODUIT As Double = NumericUpDownTauxProduit.Value
            Dim TAUX_TVA As Double = NumericUpDownTva.Value

            '---------------- INSERTING A SELECTED VALUE OF COMBOBOX INITIALLY FROM DATABSE INTO A VARIABLE-------------------------
            Dim VILLE As String = GunaComboBoxVille.SelectedValue
            Dim PAYS As String = GunaComboBoxPays.SelectedValue
            Dim CODE_MONNAIE As String = GunaComboBoxSymbole.SelectedValue

            'Mise à jour des données la société existante
            Dim updateQuery As String = "UPDATE `societe` SET CODE_SOCIETE=@CODE_SOCIETE, TAUX_CHAMBRE=@TAUX_CHAMBRE, VILLE=@VILLE, TAUX_REPAS=@TAUX_REPAS, PAYS=@PAYS, TAUX_PRODUIT=@TAUX_PRODUIT,TAUX_TVA=@TAUX_TVA,CODE_MONNAIE=@CODE_MONNAIE, CODE_AGENCE_ACTUEL=@CODE_AGENCE_ACTUEL WHERE ID_SOCIETE = @ID_SOCIETE"
            Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

            command.Parameters.Add("@ID_SOCIETE", MySqlDbType.Int32).Value = ID_SOCIETE
            command.Parameters.Add("@CODE_SOCIETE", MySqlDbType.VarChar).Value = CODE_SOCIETE
            command.Parameters.Add("@TAUX_CHAMBRE", MySqlDbType.Double).Value = TAUX_CHAMBRE
            command.Parameters.Add("@VILLE", MySqlDbType.VarChar).Value = VILLE
            command.Parameters.Add("@TAUX_REPAS", MySqlDbType.Double).Value = TAUX_REPAS
            command.Parameters.Add("@PAYS", MySqlDbType.VarChar).Value = PAYS
            command.Parameters.Add("@TAUX_PRODUIT", MySqlDbType.Double).Value = TAUX_PRODUIT
            command.Parameters.Add("@TAUX_TVA", MySqlDbType.Double).Value = TAUX_TVA
            command.Parameters.Add("@CODE_MONNAIE", MySqlDbType.VarChar).Value = CODE_MONNAIE
            command.Parameters.Add("@CODE_AGENCE_ACTUEL", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

            'Opening the connection
            'connect.openConnection()

            'Excuting the command and testing if everything went on well
            If (command.ExecuteNonQuery() = 1) Then
                'connect.closeConnection()
            Else
                'connect.closeConnection()
            End If

        End If

        'Affichage et masquage des divers panneaux
        GunaPanelWizardWelcome.Hide()
        GunaPanelTaxes.Hide()
        GunaPanelTypeDeChambre.Show()
        GunaPanelCreationDeChambre.Hide()
        GunaPanelCreationSalleDeFete.Hide()

        'Coloration des intitulés des panneau actifs
        couleurDuPanneauActif = Color.FromArgb(200, 230, 126, 34)
        PanelWelcomeTypeDeChambre.BackColor = couleurDuPanneauActif
        PanelTaxesType.BackColor = couleurDuPanneauActif

    End Sub

    'Bouton Suivant du Panneau Catégorie de chambre 
    Private Sub GunaButtonSuivantType_Click(sender As Object, e As EventArgs) Handles GunaButtonSuivantType.Click

        RoomSymboleList()

        'Refreshing the content of the categories DropDownList
        roomCategoriesListFromDataBase()

        'Affichage et masquage des différents panneaux
        GunaPanelWizardWelcome.Hide()
        GunaPanelTaxes.Hide()
        GunaPanelTypeDeChambre.Hide()
        GunaPanelCreationDeChambre.Show()
        GunaPanelCreationSalleDeFete.Hide()

        'Coloration des intitulés des panneaux actifs
        couleurDuPanneauActif = Color.FromArgb(200, 230, 126, 34)
        PanelWelcomeCreation.BackColor = couleurDuPanneauActif
        PanelTaxesCreation.BackColor = couleurDuPanneauActif
        PanelTypeCreation.BackColor = couleurDuPanneauActif

    End Sub

    'Bouton Suivant du Panneau de Creation de chambres
    Private Sub GunaButtonSuivantCreationChambre_Click(sender As Object, e As EventArgs) Handles GunaButtonSuivantCreationChambre.Click

        GunaPanelWizardWelcome.Hide()
        GunaPanelTaxes.Hide()
        GunaPanelTypeDeChambre.Hide()
        GunaPanelCreationDeChambre.Hide()
        GunaPanelCreationSalleDeFete.Show()

        'Coloration des intitulés des panneaux actifs
        'couleurDuPanneauActif = Color.FromArgb(200, 230, 126, 34)
        'PanelWelcomeCreation.BackColor = couleurDuPanneauActif
        'PanelTaxesCreation.BackColor = couleurDuPanneauActif
        'PanelTypeCreation.BackColor = couleurDuPanneauActif
        'PanelCreationChambre.BackColor = couleurDuPanneauActif

        'Coloration des intitulés des panneaux actifs
        couleurDuPanneauActif = Color.FromArgb(200, 230, 126, 34)
        Panel21.BackColor = couleurDuPanneauActif
        Panel20.BackColor = couleurDuPanneauActif
        Panel22.BackColor = couleurDuPanneauActif
        Panel23.BackColor = couleurDuPanneauActif


    End Sub


    'END GESTION DES BOUTONS SUIVANTS DES DIVERS PANNEAUX

    'GESTION DES BOUTONS PRECEDENT DES DIVERS PANNEAUX

    'Bouton Précédent du panneau Taxes
    Private Sub GunaButtonTaxesPrecedent_Click_1(sender As Object, e As EventArgs) Handles GunaButtonTaxesPrecedent.Click

        GunaPanelWizardWelcome.Show()
        GunaPanelTaxes.Hide()
        GunaPanelTypeDeChambre.Hide()
        GunaPanelCreationSalleDeFete.Hide()
        GunaPanelCreationDeChambre.Hide()

    End Sub

    'Bouton Précédent du Panneau Type De Chambre
    Private Sub GunaButtonpPrecedentTypeDeChambre_Click(sender As Object, e As EventArgs) Handles GunaButtonpPrecedentTypeDeChambre.Click
        GunaPanelWizardWelcome.Hide()
        GunaPanelTaxes.Show()
        GunaPanelTypeDeChambre.Hide()
        GunaPanelCreationDeChambre.Hide()
        GunaPanelCreationSalleDeFete.Hide()
    End Sub

    'Bouton Précédent du panneau de création des chambres
    Private Sub GunaButtonPrecedentChambre_Click(sender As Object, e As EventArgs) Handles GunaButtonPrecedentChambre.Click
        GunaPanelWizardWelcome.Hide()
        GunaPanelTaxes.Hide()
        GunaPanelTypeDeChambre.Show()
        GunaPanelCreationDeChambre.Hide()
        GunaPanelCreationSalleDeFete.Hide()
    End Sub

    'END GESTION DES BOUTONS PRECEDENT DES DIVERS PANNEAUX

    ' GESTION DES BOUTONS ANNULER DES DIVERS PANNEAUX
    Private Sub GunaButtonAnnulerWelcome_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnulerWizard.Click
        AccueilForm.Show()
        Me.Close()
    End Sub

    Private Sub GunaButtonTaxesAnnuler_Click(sender As Object, e As EventArgs) Handles GunaButtonTaxesAnnuler.Click
        AccueilForm.Show()
        Me.Close()
    End Sub

    Private Sub GunaButtonTypeDeChambreAnnuler_Click(sender As Object, e As EventArgs) Handles GunaButtonTypeDeChambreAnnuler.Click
        AccueilForm.Show()
        Me.Close()
    End Sub

    Private Sub GunaButtonCreationChambre_Click(sender As Object, e As EventArgs) Handles GunaButtonCreationChambre.Click
        AccueilForm.Show()
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    ' END GESTION DES BOUTONS ANNULER DES DIVERS PANNEAUX

    'CATEGORIES CHAMBRES
    'Gestion de l'ajout et misa à jours des catégories de chambre du panneau catégorie des chambres
    Private Sub GunaButtonAjouterCategorie_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterCategorie.Click

        Dim typeChambre As New RoomType()

        Dim LIBELLE_TYPE_CHAMBRE = GunaTextBoxTypeDeChambre.Text
        Dim DESCRIPTION = ""
        Dim prixCast As Double = 0
        Double.TryParse(GunaTextBoxPrixType.Text, prixCast)
        Dim PRIX As Double = prixCast
        Dim CODE_TYPE_CHAMBRE As String = GunaTextBoxCodeTypeChambre.Text
        Dim DATE_CREATION As Date = Date.Now()
        Dim CODE_UTILISATEUR_MODIF As String = ""
        Dim DATE_MODIFICATION As Date = Date.Now()
        Dim CODE_AGENCE As String = ""
        Dim NOMBRE_LIT_UNE_PLACE As Integer = GunaNumericNbreDeLitUnePlace.Value
        Dim NOMBRE_LIT_DEUX_PLACES As Integer = GunaNumericNbreLitDeuxPlaces.Value

        If Not Functions.entryCodeExists(GunaTextBoxTypeDeChambre.Text, "type_chambre", "LIBELLE_TYPE_CHAMBRE") And Not afterDoubleClickOnRoomCategoryListRow Then

            If typeChambre.InsertOnStartUp(LIBELLE_TYPE_CHAMBRE, PRIX, CODE_TYPE_CHAMBRE, DATE_CREATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, NOMBRE_LIT_UNE_PLACE, NOMBRE_LIT_DEUX_PLACES) Then

                'We rest the values of our fields
                GunaTextBoxCodeTypeChambre.Clear()
                GunaTextBoxTypeDeChambre.Clear()
                GunaNumericNbreDeLitUnePlace.Value = 0
                GunaNumericNbreLitDeuxPlaces.Value = 1
                GunaTextBoxPrixType.Text = 0

                'Listing all the rooms categories
                roomCategoriesList()

            End If

            'connect.closeConnection()
        Else

            'La Categorie existe deja alors on verifie si c'est une mise a jours ou une nouvelle saisie

            If afterDoubleClickOnRoomCategoryListRow Then
                'Cas de misse à jour
                'We update the room categorie
                CODE_TYPE_CHAMBRE = codeRoomCategorieToUpdate
                If typeChambre.UpdateChambreOnCreation(CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE, PRIX, CODE_UTILISATEUR_MODIF, DATE_MODIFICATION, CODE_AGENCE, NOMBRE_LIT_UNE_PLACE, NOMBRE_LIT_DEUX_PLACES) Then

                    'Listing all the rooms categories
                    roomCategoriesList()

                    'We rest the values of our fields
                    GunaTextBoxCodeTypeChambre.Clear()
                    GunaTextBoxTypeDeChambre.Clear()
                    GunaNumericNbreDeLitUnePlace.Value = 0
                    GunaNumericNbreLitDeuxPlaces.Value = 1
                    GunaTextBoxPrixType.Text = 0

                End If

                afterDoubleClickOnRoomCategoryListRow = False

            Else
                'Cas d'une nouvelle saisie deja existante dans la base de donne
                MessageBox.Show("Cette categorie de chambre existe deja !!", "Configurations", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

    End Sub

    'Function to list the rooms categories present
    Sub roomCategoriesList()

        'Filling of the list of room categories on the right (datagrid)
        Dim FillingListquery As String = "SELECT CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE AS 'TYPE CHAMBRE',PRIX,NOMBRE_LIT_UNE_PLACE AS 'UNE PLACE' ,NOMBRE_LIT_DEUX_PLACES AS 'DEUX PLACES' FROM type_chambre WHERE TYPE=@TYPE ORDER BY LIBELLE_TYPE_CHAMBRE ASC"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        'commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        commandList.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            'We display the button to delete an element from datagrid iff it has at atleast a line
            GunaButtonEffacerCategorie.Visible = True

            DataGridViewRoomCategorie.DataSource = tableList

            GunaTextBoxCodeTypeChambre.Clear()
            GunaTextBoxTypeDeChambre.Clear()
            GunaNumericNbreDeLitUnePlace.Value = 0
            GunaNumericNbreLitDeuxPlaces.Value = 1
            GunaTextBoxPrixType.Text = 0

            'We hide the code column
            'DataGridViewRoomCategorie.Columns(0).Visible = False

        Else

            'We hide the button to delete an element from datagrid as it has no line
            GunaButtonEffacerCategorie.Visible = False

        End If

        'connect.closeConnection()

    End Sub

    'Fillin the Country and town Combobox with data from database
    Sub FillingCountryTownComboBox()

        'Country
        Dim FillingListquery As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            FillingListquery = "SELECT * FROM pays ORDER BY NOM_PAYS_FR ASC"
        Else
            FillingListquery = "SELECT * FROM pays ORDER BY NOM_PAYS_EN ASC"
        End If
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            GunaComboBoxPays.DataSource = tableList

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaComboBoxPays.ValueMember = "NOM_PAYS_FR"
                GunaComboBoxPays.DisplayMember = "NOM_PAYS_FR"
            Else
                GunaComboBoxPays.ValueMember = "NOM_PAYS_EN"
                GunaComboBoxPays.DisplayMember = "NOM_PAYS_EN"
            End If

        End If

        'connect.closeConnection()

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
        'connect.closeConnection()

        'Currency Symbole
        Dim FillingListquery2 As String = "SELECT * FROM monnaie ORDER BY MONNAIE ASC"
        Dim commandList2 As New MySqlCommand(FillingListquery2, GlobalVariable.connect)

        Dim adapterList2 As New MySqlDataAdapter(commandList2)
        Dim tableList2 As New DataTable()
        adapterList2.Fill(tableList2)

        GlobalVariable.Monnaie = tableList2

        If (tableList2.Rows.Count > 0) Then

            GunaComboBoxSymbole.DataSource = tableList2
            GunaComboBoxSymbole.ValueMember = "CODE_MONNAIE"
            GunaComboBoxSymbole.DisplayMember = "SYMBOLE"

        End If

        'connect.closeConnection()
    End Sub

    'Inserting room categories into combobox
    Sub roomCategoriesListFromDataBase()

        '---------------------- COMBOX BOX VS DATABASE - INSERT DATA INTO COMBOBOX FROM DATABASE ----------------

        'Connecting combobox with Database so as to attribute symboles to room categories (COMBOBOX VS DATABASE)

        Dim FillingListquery As String = "SELECT * FROM type_chambre WHERE TYPE=@TYPE ORDER BY LIBELLE_TYPE_CHAMBRE ASC "
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        'commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        commandList.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            GunaComboBoxTypeDeChambre.DataSource = tableList
            GunaComboBoxTypeDeChambre.ValueMember = "ID_TYPE_CHAMBRE"
            GunaComboBoxTypeDeChambre.DisplayMember = "LIBELLE_TYPE_CHAMBRE"

        End If

    End Sub

    '-------------------------EDITION DES CATEGORIES DE CHAMBRE ---------------
    'We edit the value of a selected row in the datagrid of the room category list

    'Variable To know if we are dealing with and existing entry to update or typing a new entry whose name already exist
    'In the last case the entry shouldnot be inserted
    Dim afterDoubleClickOnRoomCategoryListRow As Boolean = False
    Dim codeRoomCategorieToUpdate As String

    Private Sub DataGridViewRoomCategorie_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewRoomCategorie.CellDoubleClick

        afterDoubleClickOnRoomCategoryListRow = True

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow = DataGridViewRoomCategorie.Rows(e.RowIndex)

            codeRoomCategorieToUpdate = row.Cells(0).Value.ToString

            GunaTextBoxTypeDeChambre.Text = row.Cells(1).Value.ToString
            GunaTextBoxPrixType.Text = Format(Double.Parse(row.Cells(2).Value), "#,##0")
            GunaNumericNbreDeLitUnePlace.Value = Integer.Parse(row.Cells(3).Value)
            GunaNumericNbreLitDeuxPlaces.Value = Integer.Parse(row.Cells(4).Value)
            GunaTextBoxCodeTypeChambre.Text = row.Cells(0).Value.ToString


        End If

    End Sub


    'PANNEAU DE CREATION DE CATEGORIE DE CHAMBRE

    'Deleting from room categories datagrid
    Private Sub GunaButtonEffacerCategorie_Click(sender As Object, e As EventArgs) Handles GunaButtonEffacerCategorie.Click

        'Wether to display this button or not is determine in the function: roomCategoriesList()

        'Deleting elements from data grid of room categories
        For Each row As DataGridViewRow In DataGridViewRoomCategorie.SelectedRows

            Functions.DeleteElementByCode(DataGridViewRoomCategorie.CurrentRow.Cells(0).Value.ToString, "type_chambre", "CODE_TYPE_CHAMBRE")

        Next

        'Listing all the rooms categories in the TypeChambre Panel for refreshing purpose
        roomCategoriesList()

        'We determine if yes or no to display the delete button again

    End Sub

    'Updating the list of room categories
    Private Sub GunaButtonWizardAjouterChambre_Click(sender As Object, e As EventArgs) Handles GunaButtonWizardAjouterChambre.Click

        RoomSymboleList()

        Dim Chambre As New Room()

        Dim CODE_CHAMBRE As String = GunaTextBoxCodeChambre.Text
        Dim CODE_TYPE_CHAMBRE = Functions.getElementByCode(GunaComboBoxTypeDeChambre.SelectedValue, "type_chambre", "ID_TYPE_CHAMBRE").Rows(0)("CODE_TYPE_CHAMBRE")
        Dim CODE_CATEGORY_CHAMBRE = ""
        Dim LIBELLE_CHAMBRE = ""
        Dim ETAT_CHAMBRE = 0
        Dim ETAT_CHAMBRE_NOTE As String = GlobalVariable.libre_sale
        Dim LOCALISATION As String = ""
        Dim NUM_COMPTE As String = ""

        Dim roomType As DataTable = Functions.getElementByCode(GunaComboBoxTypeDeChambre.SelectedValue, "type_chambre", "ID_TYPE_CHAMBRE")

        Dim PRIX = roomType.Rows(0)("PRIX")
        Dim FICITIF As Integer = 0
        Dim LOCK_NO As String = ""
        Dim GUEST_DAI As String = ""
        Dim DATE_CREATION As Date = Now()
        Dim CODE_AGENCE As String = ""

        If Chambre.Insert(CODE_CHAMBRE, CODE_TYPE_CHAMBRE, CODE_CATEGORY_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE, LOCALISATION, NUM_COMPTE, PRIX, FICITIF, LOCK_NO, GUEST_DAI, DATE_CREATION, CODE_AGENCE) Then
            GunaTextBoxCodeChambre.Text = ""
        End If

        RoomSymboleList()

    End Sub

    'Displayting or Outputting the room categories names created before and the corresponding symbole in dataViewGrid
    Sub RoomSymboleList()

        'Filling of the list of room categories on the right with their symboles
        Dim FillingListquery As String = "SELECT ID_CHAMBRE, CODE_CHAMBRE AS 'CODE CHAMBRE', CODE_TYPE_CHAMBRE AS 'TYPE', PRIX, ETAT_CHAMBRE_NOTE As ETAT FROM chambre WHERE TYPE=@TYPE"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        'commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        commandList.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            DataGridViewRoomSymbole.DataSource = tableList

            'We hide the colmunn of the Code to use it in order to update
            DataGridViewRoomSymbole.Columns(0).Visible = False

        End If

        'roomCategoriesListFromDataBase()

        'connect.closeConnection()

    End Sub

    'Refreshing the datagrid
    Private Sub GunaPanelCreationDeChambre_Enter(sender As Object, e As EventArgs) Handles GunaPanelCreationDeChambre.Enter
        ' Refresh the Room Categories List
        roomCategoriesList()
    End Sub

    '-------------------------------------------- GESTION DE LA SALLE DE FETE --------------------------------------------------------------

    'Inserting room categories into combobox
    Sub SalleCategoriesListFromDataBase()

        '---------------------- COMBOX BOX VS DATABASE - INSERT DATA INTO COMBOBOX FROM DATABASE ----------------

        'Connecting combobox with Database so as to attribute symboles to room categories (COMBOBOX VS DATABASE)

        Dim FillingListquery As String = "SELECT * FROM type_chambre WHERE TYPE=@TYPE ORDER BY LIBELLE_TYPE_CHAMBRE ASC "
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        'commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        commandList.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            GunaComboBoxTypeSalleForName.DataSource = tableList
            GunaComboBoxTypeSalleForName.ValueMember = "ID_TYPE_CHAMBRE"
            GunaComboBoxTypeSalleForName.DisplayMember = "LIBELLE_TYPE_CHAMBRE"

        End If

    End Sub


    ' NOM DES SALLES 
    'Displayting or Outputting the room categories names created before and the corresponding symbole in dataViewGrid
    Sub SalleTypeList()

        'Filling of the list of room categories on the right with their symboles
        Dim FillingListquery As String = "SELECT ID_CHAMBRE, CODE_CHAMBRE AS 'CODE SALLE', CODE_TYPE_CHAMBRE AS 'TYPE SALLE', PRIX, ETAT_CHAMBRE_NOTE As ETAT FROM chambre WHERE TYPE=@TYPE"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        'commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        commandList.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            DataGridViewNomDesSalles.DataSource = tableList

            'We hide the colmunn of the Code to use it in order to update
            DataGridViewNomDesSalles.Columns(0).Visible = False

        End If

        'roomCategoriesListFromDataBase()

        'connect.closeConnection()

    End Sub

    Private Sub GunaButtonPrecedentCreationSalle_Click(sender As Object, e As EventArgs) Handles GunaButtonPrecedentCreationSalle.Click

        GunaPanelWizardWelcome.Hide()
        GunaPanelTaxes.Hide()
        GunaPanelTypeDeChambre.Hide()
        GunaPanelCreationDeChambre.Show()
        GunaPanelCreationSalleDeFete.Hide()

    End Sub

    Private Sub GunaButtonSuivantCreationSalle_Click(sender As Object, e As EventArgs) Handles GunaButtonSuivantCreationSalle.Click

        HomeForm.Show()

        Me.Close()

        GunaPanelWizardWelcome.Hide()
        GunaPanelTaxes.Hide()
        GunaPanelTypeDeChambre.Hide()
        GunaPanelCreationDeChambre.Hide()
        GunaPanelCreationSalleDeFete.Hide()

    End Sub

    Private Sub GunaButtonAnnulerCreationSalle_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnulerCreationSalle.Click

        AccueilForm.Show()

        Me.Close()

    End Sub

    'Liste des salles a afficher
    ' TYPE DE SALLE
    Private Sub salleListe()

        'Filling of the list of room categories on the right (datagrid)
        Dim FillingListquery As String = "SELECT CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE AS 'TYPE CHAMBRE',PRIX, CAPACITE FROM type_chambre WHERE TYPE=@TYPE ORDER BY LIBELLE_TYPE_CHAMBRE ASC"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        'commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        commandList.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            'We display the button to delete an element from datagrid iff it has at atleast a line

            DataGridViewSalle.DataSource = tableList

            GunaTextBoxTypeSalle.Clear()
            GunaTextBoxSymbole.Clear()
            GunaTextBoxPrix.Text = 0
            GunaTextBoxCapacite.Text = 0

            'We hide the code column
            'DataGridViewRoomCategorie.Columns(0).Visible = False

        Else

            'We hide the button to delete an element from datagrid as it has no line
            DataGridViewSalle.Visible = False

        End If

        'connect.closeConnection()
    End Sub


    'Enregistrement du type de salle
    Private Sub GunaButtonAjouterTypeSalle_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouterTypeSalle.Click

        Dim typeChambre As New RoomType()

        Dim LIBELLE_TYPE_CHAMBRE = GunaTextBoxTypeSalle.Text
        Dim DESCRIPTION = ""
        Dim prixCast As Double = 0
        Double.TryParse(GunaTextBoxPrix.Text, prixCast)
        Dim PRIX As Double = prixCast
        Dim CODE_TYPE_CHAMBRE As String = GunaTextBoxSymbole.Text
        Dim DATE_CREATION As Date = Date.Now()
        Dim CODE_UTILISATEUR_MODIF As String = ""
        Dim DATE_MODIFICATION As Date = Date.Now()
        Dim CODE_AGENCE As String = ""
        Dim capaciteCast As Integer = 0
        Dim CAPACITE As Integer = Integer.Parse(GunaTextBoxCapacite.Text)
        Dim TYPE As String = "salle"

        If Not Functions.entryCodeExists(GunaTextBoxTypeDeChambre.Text, "type_chambre", "LIBELLE_TYPE_CHAMBRE") And Not afterDoubleClickOnRoomCategoryListRow Then

            If typeChambre.InsertOnStartUpSalle(LIBELLE_TYPE_CHAMBRE, PRIX, CODE_TYPE_CHAMBRE, DATE_CREATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, CAPACITE, TYPE) Then

                'We rest the values of our fields
                GunaTextBoxTypeSalle.Clear()
                GunaTextBoxSymbole.Clear()
                GunaTextBoxPrix.Text = 0
                GunaTextBoxCapacite.Text = 0

                'Listing all the salle
                salleListe()

            End If

            'connect.closeConnection()
        Else

            'La Categorie existe deja alors on verifie si c'est une mise a jours ou une nouvelle saisie

            If afterDoubleClickOnRoomCategoryListRow Then
                'Cas de misse à jour
                'We update the room categorie
                CODE_TYPE_CHAMBRE = codeRoomCategorieToUpdate
                If typeChambre.UpdateChambreOnCreationSalle(CODE_TYPE_CHAMBRE, LIBELLE_TYPE_CHAMBRE, PRIX, CODE_UTILISATEUR_MODIF, DATE_MODIFICATION, CODE_AGENCE, CAPACITE) Then

                    'Listing all the salle
                    salleListe()

                    'We rest the values of our fields
                    GunaTextBoxTypeSalle.Clear()
                    GunaTextBoxSymbole.Clear()
                    GunaTextBoxPrix.Text = 0
                    GunaTextBoxCapacite.Text = 0

                End If

                'afterDoubleClickOnRoomCategoryListRow = False

            Else
                'Cas d'une nouvelle saisie deja existante dans la base de donne
                MessageBox.Show("Ce type de salle existe deja !!", "Configurations", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

        'We refresh the salle type
        SalleCategoriesListFromDataBase()

        'Refresh the rooms
        salleListe()

    End Sub

    Private Sub GunaButtonNomDeSalle_Click(sender As Object, e As EventArgs) Handles GunaButtonNomDeSalle.Click

        Dim Chambre As New Room()

        Dim CODE_CHAMBRE As String = GunaTextBoxNomSalle.Text
        Dim CODE_TYPE_CHAMBRE = Functions.getElementByCode(GunaComboBoxTypeSalleForName.SelectedValue, "type_chambre", "ID_TYPE_CHAMBRE").Rows(0)("CODE_TYPE_CHAMBRE")
        Dim CODE_CATEGORY_CHAMBRE = ""
        Dim LIBELLE_CHAMBRE = ""
        Dim ETAT_CHAMBRE = 0
        Dim ETAT_CHAMBRE_NOTE As String = GlobalVariable.libre_sale
        Dim LOCALISATION As String = ""
        Dim NUM_COMPTE As String = ""

        Dim roomType As DataTable = Functions.getElementByCode(GunaComboBoxTypeSalleForName.SelectedValue, "type_chambre", "ID_TYPE_CHAMBRE")

        Dim PRIX = roomType.Rows(0)("PRIX")
        Dim FICITIF As Integer = 0
        Dim LOCK_NO As String = ""
        Dim GUEST_DAI As String = ""
        Dim DATE_CREATION As Date = Now()
        Dim CODE_AGENCE As String = ""
        Dim TYPE As String = "salle"

        If Chambre.Insert(CODE_CHAMBRE, CODE_TYPE_CHAMBRE, CODE_CATEGORY_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE, LOCALISATION, NUM_COMPTE, PRIX, FICITIF, LOCK_NO, GUEST_DAI, DATE_CREATION, CODE_AGENCE, TYPE) Then
            GunaTextBoxCodeChambre.Text = ""
        End If

        SalleTypeList()

    End Sub


    '--------------------------------------------END GESTION DE LA SALLE DE FETE --------------------------------------------------------------


End Class