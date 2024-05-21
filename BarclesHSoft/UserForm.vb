Imports MySql.Data.MySqlClient

Public Class UserForm

    'Dim connect As New DataBaseManipulation()

    'utilisateurs_acces : LIste ds profils et droits
    'utilisateur_acces_profil : assignation d'un profil a un utilisateur

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Close()
    End Sub

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()

        language.user(GlobalVariable.actualLanguageValue)

        userList()

        profilList()

        LoadingAgenceAndUserTypeFromDataBase()

    End Sub

    Private Sub LoadingAgenceAndUserTypeFromDataBase()

        'Agence
        Dim FillingListquery As String = "SELECT * FROM agence ORDER BY NOM_AGENCE ASC"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()
        adapterList.Fill(tableList)

        If (tableList.Rows.Count > 0) Then

            GunaComboBoxAgenceTravailUtilisateur.DataSource = tableList
            GunaComboBoxAgenceTravailUtilisateur.ValueMember = "CODE_AGENCE"
            GunaComboBoxAgenceTravailUtilisateur.DisplayMember = "NOM_AGENCE"

        End If

        'Profil
        Dim profils As String = "SELECT CODE_PROFIL, NOM_PROFIL FROM utilisateur_acces ORDER BY NOM_PROFIL ASC"
        Dim commandprofilsList As New MySqlCommand(profils, GlobalVariable.connect)

        Dim adapterprofilsList As New MySqlDataAdapter(commandprofilsList)
        Dim tableprofilsList As New DataTable()
        adapterprofilsList.Fill(tableprofilsList)

        If (tableprofilsList.Rows.Count > 0) Then

            GunaComboBoxProfilUtilisateur.DataSource = tableprofilsList
            GunaComboBoxProfilUtilisateur.ValueMember = "CODE_PROFIL"
            GunaComboBoxProfilUtilisateur.DisplayMember = "NOM_PROFIL"

        End If
        'Town

        'connect.closeConnection()

    End Sub

    Private Sub userList()

        Dim query As String = ""
        If GlobalVariable.actualLanguageValue = 0 Then
            query = "SELECT NOM_UTILISATEUR AS 'USER', NOM_AGENCE AS 'WORKING AGENCY', NOM_PROFIL AS 'PROFILE', utilisateurs.DATE_CREATION AS 'CREATION DATE'FROM utilisateurs, agence, utilisateur_acces WHERE  utilisateurs.NUM_AGENCE = agence.CODE_AGENCE AND utilisateur_acces.CODE_PROFIL = utilisateurs.CATEG_UTILISATEUR ORDER BY NOM_UTILISATEUR ASC"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            query = "SELECT NOM_UTILISATEUR AS 'UTILISATEUR', NOM_AGENCE AS 'AGENCE DE TRAVAIL', NOM_PROFIL AS 'PROFIL', utilisateurs.DATE_CREATION AS 'DATE CREATION' FROM utilisateurs, agence, utilisateur_acces WHERE  utilisateurs.NUM_AGENCE = agence.CODE_AGENCE AND utilisateur_acces.CODE_PROFIL = utilisateurs.CATEG_UTILISATEUR ORDER BY NOM_UTILISATEUR ASC"

        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewUser.DataSource = table
        Else
            GunaDataGridViewUser.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    Private Sub profilList()

        Dim query As String = ""
        If GlobalVariable.actualLanguageValue = 0 Then
            query = "SELECT CODE_PROFIL As 'PROFILE CODE', NOM_PROFIL AS 'PROFILE NAME' FROM utilisateur_acces ORDER BY NOM_PROFIL ASC"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            query = "SELECT CODE_PROFIL As 'CODE DU PROFIL', NOM_PROFIL AS 'NOM DU PROFIL' FROM utilisateur_acces ORDER BY NOM_PROFIL ASC"
        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewProfil.DataSource = table
        Else
            GunaDataGridViewProfil.Columns.Clear()
        End If

        'connect.closeConnection()

    End Sub

    'Function to check empty fields
    Public Function verifyFields(ByVal operation As String) As Boolean

        Dim check As Boolean = False

        'if it is a register operation
        If (operation = "register") Then
            If (GunaTextBoxNomUtilisateur.Text.Trim().Equals("") _
                    Or GunaTextBoxGriffeUtilisateur.Text.Trim().Equals("") _
                    Or GunaTextBoxConfimerMotDePasseUtilisateur.Text.Trim().Equals("") _
                    Or GunaTextBoxMotDePasseUtilisateur.Text.Trim().Equals("")) Then
                check = False

            Else

                check = True

            End If
        End If

        Return check

    End Function


    Private Sub emtyFieldsAfterSaving()

        GunaTextBoxCodeUtilisateur.Text = ""
        GunaTextBoxNomUtilisateur.Text = ""
        GunaTextBoxGriffeUtilisateur.Text = ""

        If GunaComboBoxProfilUtilisateur.SelectedIndex > 1 Then
            GunaComboBoxProfilUtilisateur.SelectedIndex = 1
        ElseIf GunaComboBoxProfilUtilisateur.SelectedIndex >= 0 Then
            GunaComboBoxProfilUtilisateur.SelectedIndex = 0
        Else
            GunaComboBoxProfilUtilisateur.SelectedIndex = -1
        End If

        GunaTextBoxMotDePasseUtilisateur.Text = ""
        DateTimePickerDebutAccesUtilisateur.Value = Now()
        DateTimePickerFinAccesUtilisateur.Value = Now()
        GunaComboBoxAgenceTravailUtilisateur.SelectedIndex = 0
        GunaTextBoxConfimerMotDePasseUtilisateur.Text = ""

    End Sub

    Public Sub unCheckAccessRight()

        GunaCheckBoxCaissePrincipaleLecture.Checked = False
        GunaCheckBoxCaissePrincipaleEcriture.Checked = False
        GunaCheckBoxFiscalite.Checked = False

        GunaCheckBoxDashboard.Checked = False
        GunaCheckBoxPlanning.Checked = False
        GunaCheckBoxArrivee.Checked = False
        GunaCheckBoxEnChambre.Checked = False
        GunaCheckBoxDeparts.Checked = False
        GunaCheckBoxAttribuerChambre.Checked = False
        GunaCheckBoxMessage.Checked = False
        GunaCheckBoxFacuration.Checked = False
        GunaCheckBoxCloture.Checked = False
        GunaCheckBoxRapports.Checked = False
        GunaCheckBoxCardex.Checked = False
        GunaCheckBoxNouvelleResa.Checked = False
        GunaCheckBoxModifierResa.Checked = False
        GunaCheckBoxFichePolice.Checked = False
        GunaCheckBoxDisponibilite.Checked = False
        GunaCheckBoxPlanChambre.Checked = False
        GunaCheckBoxRapportResa.Checked = False
        GunaCheckBoxStatutsChambre.Checked = False
        GunaCheckBoxHistoriques.Checked = False
        GunaCheckBoxHS.Checked = False
        GunaCheckBoxObjets.Checked = False
        GunaCheckBoxRapportServiceEtage.Checked = False
        GunaCheckBoxClientEnchambre.Checked = False
        GunaCheckBoxEvents.Checked = False
        GunaCheckBoxComptoire.Checked = False
        GunaCheckBoxBarRapports.Checked = False
        GunaCheckBox28.Checked = False
        GunaCheckBox30.Checked = False
        GunaCheckBoxReglementEtLettrage.Checked = False
        GunaCheckBox34.Checked = False
        GunaCheckBox36.Checked = False
        GunaCheckBoxMovt.Checked = False
        GunaCheckBoxInventaire.Checked = False
        GunaCheckBoxFicheProduit.Checked = False
        GunaCheckBoxFournisseur.Checked = False
        GunaCheckBoxEconomatRapports.Checked = False
        GunaCheckBoxPetiteCaisse.Checked = False
        GunaCheckBoxGrandeCaisse.Checked = False
        GunaCheckBoxPetitMagasin.Checked = False
        GunaCheckBoxGrandMagasin.Checked = False
        GunaCheckBoxSession.Checked = False
        GunaCheckBoxConfiguration.Checked = False
        GunaCheckBoxAdminServiceTechnique.Checked = False
        GunaCheckBoxSecurite.Checked = False
        GunaCheckBoxFamillePanne.Checked = False
        GunaCheckBoxSousFamillePanne.Checked = False
        GunaCheckBoxDemandeIntervention.Checked = False
        GunaCheckBoxIntervention.Checked = False
        GunaCheckBoxTechniqueRapports.Checked = False

        GunaCheckBoxRapportResa.Checked = False
        GunaCheckBoxRechercheResa.Checked = False
        GunaCheckBoxPromoteur.Checked = False

        GunaCheckBoxGratuiteeHebergement.Checked = False
        GunaCheckBoxImprimerFB.Checked = False

        GunaCheckBoxRapportServiceEtage.Checked = False
        GunaCheckBoxNettoyage.Checked = False
        GunaCheckBoxDebutNettoyage.Checked = False
        GunaCheckBoxFinNettoyage.Checked = False
        GunaCheckBoxControllerNettoyage.Checked = False
        GunaCheckBoxEtatChambres.Checked = False

        GunaCheckBoxEconomatRapports.Checked = False
        GunaCheckBoxBC.Checked = False
        GunaCheckBoxValider.Checked = False
        GunaCheckBoxCommander.Checked = False
        GunaCheckBoxBR.Checked = False

        GunaCheckBoxMagasins.Checked = False
        GunaCheckBoxFicheTechnique.Checked = False
        GunaCheckBoxlisteDesBons.Checked = False

        GunaCheckBoxControler.Checked = False
        GunaCheckBoxVerification.Checked = False

        GunaCheckBox28.Checked = False
        GunaCheckBox30.Checked = False
        GunaCheckBoxReglementEtLettrage.Checked = False
        GunaCheckBox34.Checked = False
        GunaCheckBox36.Checked = False


        '-------------- main menu
        GunaCheckBoxReception.Checked = False
        GunaCheckBoxReservation.Checked = False
        GunaCheckBoxServiceEtage.Checked = False
        GunaCheckBoxBarRestaurant.Checked = False
        GunaCheckBoxCompatbilite.Checked = False
        GunaCheckBoxEconomat.Checked = False
        GunaCheckBoxCaissesMagasins.Checked = False
        GunaCheckBoxAdministration.Checked = False
        GunaCheckBoxMenuTechnique.Checked = False
        GunaCheckBoxMenuCuisine.Checked = False

        '------------------------------------------
        GunaCheckBox6.Checked = False
        GunaCheckBox7.Checked = False

        GunaCheckBox2.Checked = False
        GunaCheckBox4.Checked = False
        GunaCheckBox3.Checked = False
        GunaCheckBox1.Checked = False
        GunaCheckBox5.Checked = False

        '---------cuiine
        GunaCheckBox9.Checked = False
        GunaCheckBox8.Checked = False
        GunaCheckBox10.Checked = False
        GunaCheckBox11.Checked = False
        GunaCheckBox12.Checked = False
        GunaCheckBox13.Checked = False
        GunaCheckBox14.Checked = False

        DASHBOARD = 0
        PLANNING = 0
        ARRIVEES = 0
        EN_CHAMBRES = 0
        DEPARTS = 0
        ATTRIBUER_CHAMBRE = 0
        MESSAGES = 0
        FACTURATION = 0
        CLOTURE = 0
        RAPPORT_RECEPTION = 0
        CARDEX = 0
        NOUVELLE_RESERVATION = 0
        MODIFIER_RESERVATION = 0
        FICHE_DE_POLICE = 0
        DISPONIBILITE_ET_TARIFS = 0
        PLAN_DE_CHAMBRE = 0
        RAPPORT_RESERVATION = 0
        STATUTS_DES_CHAMBRES = 0
        HISTORIQUES_DES_CHAMBRES = 0
        HORS_SERVICES = 0
        OBJETS_TROUVES_PERDUS = 0
        RAPPORT_SERVICE_ETAGE = 0
        CLIENT_EN_CHAMBRE_FACTURATION = 0
        PAYMASTER_FACTURATION = 0
        AU_COMPTANT_FACTURATION = 0
        RAPPORT_BAR_RESTAURANT = 0
        GESTION_DES_COMPTES = 0
        LISTE_DES_COMPTES = 0
        RECHARGE = 0
        CAUTIONS = 0
        RAPPORT_COMPTABILITE = 0
        MOUVEMENT = 0
        INVENTAIRE = 0
        FICHE_DE_PRODUIT = 0
        FOURNISSEURS = 0
        RAPPORT_ECONOMAT = 0
        PETITE_CAISSE = 0
        GRANDE_CAISSE = 0
        PETIT_MAGAZIN = 0
        GRAND_MAGAZIN = 0
        SESSION_ADMIN = 0
        CONFIGURATION = 0
        SERVICE_TECHNIQUE = 0
        SECURITE = 0
        MENU_RECEPTION = 0
        MENU_RESERVATION = 0
        MENU_ADMINISTRATEUR = 0
        MENU_SERVICE_ETAGE = 0
        MENU_BAR_RESTAURANT = 0
        MENU_COMPTABILITE = 0
        MENU_ECONOMAT = 0
        MENU_TECHNIQUE = 0
        Panne = 0
        SOUS_PANNE = 0
        DEMANDE_INTERVENTION = 0
        INTERVENTION = 0
        RAPPORT_TECHNIQUE = 0
        RAPPORT_PROMOTEUR = 0
        RECHERCHER_RESA = 0
        NETTOYAGE = 0
        DEBUT_NETTOYAGE = 0
        FIN_NETTOYAGE = 0
        CONTROLLER_NETTOYAGE = 0
        ETAT_CHAMBRE = 0
        BON_COMMANDE = 0
        FICHE_TECHNIQUE = 0
        LISTE_DES_BONS = 0
        BON_RECEPTION = 0
        VALIDER = 0
        CONTROLER = 0
        COMMANDER = 0
        MAGASINS = 0
        VERIFICATION = 0
        CAISSE_PRINCIPALE_LECTURE = 0
        CAISSE_PRINCIPALE_ECRITURE = 0
        FACTURES_AGEES = 0
        FACTURES_COMPTABILITE = 0
        CAISSE_PRINCIPALE = 0
        LETTRE_RELANCE = 0
        GESTION_BLOC_NOTES = 0
        APPROVISIONNEMENT = 0
        CORRECTIONS = 0
        FISCALITE = 0
        MENU_CUISINE = 0
        IMPRIMER_FB = 0
        GRATUITEE_HEBERGEMENT = 0

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    'Saving the data into database after clicking on button enregistrer
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        'Register
        Dim CODE_UTILISATEUR As String = GunaTextBoxCodeUtilisateur.Text
        Dim NOM_UTILISATEUR As String = GunaTextBoxNomUtilisateur.Text
        Dim GRIFFE_UTILISATEUR As String = GunaTextBoxGriffeUtilisateur.Text

        Dim CATEG_UTILISATEUR As String = "" 'ok
        Dim POSTE_UTILISATEUR As String = ""

        If GunaComboBoxProfilUtilisateur.SelectedIndex >= 0 Then
            CATEG_UTILISATEUR = GunaComboBoxProfilUtilisateur.SelectedValue    'ok
            POSTE_UTILISATEUR = GunaComboBoxProfilUtilisateur.SelectedValue    'ok
        End If

        Dim AGENCE_TRAV_NUMBER As Integer = 0
        Dim AGENCE_CREATE_NUMBER As Integer = 0
        Dim PASSWORD_UTILISATEUR As String = GunaTextBoxMotDePasseUtilisateur.Text
        Dim DEBUT_ACCES As Date = DateTimePickerDebutAccesUtilisateur.Value.ToShortDateString
        Dim FIN_ACCES As Date = DateTimePickerFinAccesUtilisateur.Value.ToShortDateString
        Dim NOM_CONNEXION As String = " "
        Dim DATE_CHANGE_PWD As Date = GlobalVariable.DateDeTravail
        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim DATE_EXPIRATION As Date = DateTimePickerFinAccesUtilisateur.Value.ToShortDateString
        Dim DATE_DERNIERE_MAJ As Date = GlobalVariable.DateDeTravail

        Dim CODE_UTILISATEUR_MAJ As String = ""
        Dim ETAT_UTILISATEUR As String = " "
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        'Dim CODE_UTILISATEUR_CREA As String = ""
        Dim PEUT_FAIRE_REMISE As String = " "
        Dim PRIX_VENTE_MODIFIABLE As String = " "
        Dim PEUT_FAIRE_DEDUCTION_CLIENT As String = " "
        Dim PEUT_ANNULER_COMMANDE As String = " "
        Dim PEUT_CLOTURER_MAIN_COURANTE As String = " "
        Dim CONNEXION_DISTANTE As String = " "
        Dim PEUT_ATTRIBUER_GRATUITE As String = " "
        Dim PEUT_MODIFIER_TAXE_SEJOUR As String = " "
        Dim LANGUE_PAR_DEFAUT As String = " "
        Dim NUM_AGENCE As String = GunaComboBoxAgenceTravailUtilisateur.SelectedValue.ToString

        Dim user As New User()
        Dim access As New AccessRight()

        'Functions.DeleteElementByCode(CODE_UTILISATEUR, "utilisateur_acces", "CODE_UTILISATEUR")

        'user verifyfields function
        If (verifyFields("register")) Then
            'check if the user name alreday exist

            If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Update" Then

                Dim OLD_CODE_UTILISATEUR As String = GunaTextBoxUserCodeOld.Text

                If (System.String.Compare(GunaTextBoxMotDePasseUtilisateur.Text, GunaTextBoxConfimerMotDePasseUtilisateur.Text) = 0) Then

                    If user.updateUser(CODE_UTILISATEUR, NOM_UTILISATEUR, GRIFFE_UTILISATEUR, CATEG_UTILISATEUR, AGENCE_TRAV_NUMBER, AGENCE_CREATE_NUMBER, PASSWORD_UTILISATEUR, DEBUT_ACCES, FIN_ACCES, NOM_CONNEXION, DATE_CHANGE_PWD, DATE_CREATION, DATE_EXPIRATION, DATE_DERNIERE_MAJ, POSTE_UTILISATEUR, CODE_UTILISATEUR_MAJ, ETAT_UTILISATEUR, CODE_UTILISATEUR_CREA, PEUT_FAIRE_REMISE, PRIX_VENTE_MODIFIABLE, PEUT_FAIRE_DEDUCTION_CLIENT, PEUT_ANNULER_COMMANDE, PEUT_CLOTURER_MAIN_COURANTE, CONNEXION_DISTANTE, PEUT_ATTRIBUER_GRATUITE, PEUT_MODIFIER_TAXE_SEJOUR, LANGUE_PAR_DEFAUT, NUM_AGENCE, OLD_CODE_UTILISATEUR) Then

                        Dim CODE_PROFIL As String = CATEG_UTILISATEUR

                        access.updateUserAccessProfil(CODE_PROFIL, CODE_UTILISATEUR, OLD_CODE_UTILISATEUR)

                        user.updateUserCaisseMagasin(CODE_UTILISATEUR, OLD_CODE_UTILISATEUR)

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "User updated successfully"
                            languageTitle = "Users Management"
                            GunaButtonEnregistrer.Text = "Save"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Utilisateur mise à jours avec succès"
                            languageTitle = "Gestion des utilisateurs"
                            GunaButtonEnregistrer.Text = "Enregistrer"
                        End If

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        userList()

                        profilList()

                        emtyFieldsAfterSaving()

                    End If

                Else

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "The two password are not identical !"
                        languageTitle = "Users Management"

                        GunaButtonEnregistrer.Text = "Save"

                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Les deux mots de passes ne correspondent pas !"
                        languageTitle = "Gestion des utilisateurs"

                        GunaButtonEnregistrer.Text = "Enregistrer"

                    End If

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else

                If Not user.usernameExists(CODE_UTILISATEUR, NOM_UTILISATEUR) Then
                    'comparing the two password
                    If (System.String.Compare(GunaTextBoxMotDePasseUtilisateur.Text, GunaTextBoxConfimerMotDePasseUtilisateur.Text) = 0) Then
                        'add the new user

                        If user.insertUser(CODE_UTILISATEUR, NOM_UTILISATEUR, GRIFFE_UTILISATEUR, CATEG_UTILISATEUR, AGENCE_TRAV_NUMBER, AGENCE_CREATE_NUMBER, PASSWORD_UTILISATEUR, DEBUT_ACCES, FIN_ACCES, NOM_CONNEXION, DATE_CHANGE_PWD, DATE_CREATION, DATE_EXPIRATION, DATE_DERNIERE_MAJ, POSTE_UTILISATEUR, CODE_UTILISATEUR_MAJ, ETAT_UTILISATEUR, CODE_UTILISATEUR_CREA, PEUT_FAIRE_REMISE, PRIX_VENTE_MODIFIABLE, PEUT_FAIRE_DEDUCTION_CLIENT, PEUT_ANNULER_COMMANDE, PEUT_CLOTURER_MAIN_COURANTE, CONNEXION_DISTANTE, PEUT_ATTRIBUER_GRATUITE, PEUT_MODIFIER_TAXE_SEJOUR, LANGUE_PAR_DEFAUT, NUM_AGENCE) Then

                            Dim CODE_PROFIL As String = CATEG_UTILISATEUR

                            access.InsertUserAccessProfil(CODE_PROFIL, CODE_UTILISATEUR)

                            If GlobalVariable.actualLanguageValue = 0 Then
                                languageMessage = "New user successfully created "
                                languageTitle = "Users Management"

                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                languageMessage = "Nouvel utilisateur enregistré avec succès"
                                languageTitle = "Gestion des utilisateurs"

                            End If

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            GunaTextBoxCodeUtilisateur.Text = ""
                            GunaTextBoxNomUtilisateur.Text = ""
                            GunaTextBoxGriffeUtilisateur.Text = ""
                            GunaTextBoxMotDePasseUtilisateur.Text = ""
                            DateTimePickerDebutAccesUtilisateur.Value.ToShortDateString()
                            DateTimePickerFinAccesUtilisateur.Value.ToShortDateString()

                            userList()

                            profilList()

                            emtyFieldsAfterSaving()

                        Else
                            If GlobalVariable.actualLanguageValue = 0 Then
                                languageMessage = "A problem"
                                languageTitle = "Users Management"
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                languageMessage = "Un problème"
                                languageTitle = "Gestion des Utilisateurs"
                            End If
                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            GunaTextBoxMotDePasseUtilisateur.Clear()
                            GunaTextBoxConfimerMotDePasseUtilisateur.Clear()

                        End If

                    Else

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "The passwords are not identicals "
                            languageTitle = "Users Management"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Les mots de passes ne sont pas identiques"
                            languageTitle = "Gestion des Utilisateurs"
                        End If
                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "This user already exist !!"
                        languageTitle = "Gestion des Utilisateurs"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Cette utilisateur existe déjà !!"
                        languageTitle = "Gestion des Utilisateurs"
                    End If
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

            GunaTextBoxUserCodeOld.Clear()

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Please fill all the fields !!"
                languageTitle = "Users Management"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Bien vouloir remplir tous les champs !!"
                languageTitle = "Gestion des Utilisateurs"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        GunaDataGridViewUser.Columns.Clear()

        userList()

    End Sub

    'Doublick click on row for editing the selected user
    Private Sub GunaDataGridViewUser_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewUser.CellDoubleClick

        Dim row As DataGridViewRow

        row = Me.GunaDataGridViewUser.Rows(e.RowIndex)

        TabControlUtilisateurProfil.SelectedIndex = 0

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaButtonEnregistrer.Text = "Update"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            GunaButtonEnregistrer.Text = "Sauvegarder"
        End If

        Dim userToUpdate As DataTable

        If GlobalVariable.actualLanguageValue = 0 Then
            userToUpdate = Functions.getElementByCode(row.Cells("USER").Value, "utilisateurs", "NOM_UTILISATEUR")
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            userToUpdate = Functions.getElementByCode(row.Cells("UTILISATEUR").Value, "utilisateurs", "NOM_UTILISATEUR")
        End If

        GunaTextBoxUserCodeOld.Text = userToUpdate.Rows(0)("CODE_UTILISATEUR")
        GunaTextBoxCodeUtilisateur.Text = userToUpdate.Rows(0)("CODE_UTILISATEUR")
        GunaTextBoxNomUtilisateur.Text = userToUpdate.Rows(0)("NOM_UTILISATEUR")
        GunaTextBoxGriffeUtilisateur.Text = userToUpdate.Rows(0)("GRIFFE_UTILISATEUR")
        GunaComboBoxProfilUtilisateur.SelectedValue = userToUpdate.Rows(0)("CATEG_UTILISATEUR")
        GunaTextBoxMotDePasseUtilisateur.Text = userToUpdate.Rows(0)("PASSWORD_UTILISATEUR")
        DateTimePickerDebutAccesUtilisateur.Value = userToUpdate.Rows(0)("DEBUT_ACCES")
        DateTimePickerFinAccesUtilisateur.Value = userToUpdate.Rows(0)("FIN_ACCES")
        GunaComboBoxAgenceTravailUtilisateur.SelectedValue = userToUpdate.Rows(0)("NUM_AGENCE")
        GunaTextBoxConfimerMotDePasseUtilisateur.Text = GunaTextBoxMotDePasseUtilisateur.Text

        'We can't change the column below uppon editing
        GunaTextBoxCodeUtilisateur.Enabled = True
        'GunaTextBoxCodeUtilisateur.BaseColor = Color.Pink

        If Not Trim(GunaTextBoxCodeUtilisateur.Text).Equals(GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")) Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CORRECTIONS") = 1 Then

                GunaTextBoxMotDePasseUtilisateur.Enabled = True
                GunaTextBoxMotDePasseUtilisateur.BaseColor = Color.White

                GunaTextBoxConfimerMotDePasseUtilisateur.Enabled = True
                GunaTextBoxConfimerMotDePasseUtilisateur.BaseColor = Color.White

            Else

                GunaTextBoxMotDePasseUtilisateur.Enabled = False
                GunaTextBoxMotDePasseUtilisateur.BaseColor = Color.Pink

                GunaTextBoxConfimerMotDePasseUtilisateur.Enabled = False
                GunaTextBoxConfimerMotDePasseUtilisateur.BaseColor = Color.Pink

            End If

        Else

            GunaTextBoxMotDePasseUtilisateur.Enabled = False
            GunaTextBoxMotDePasseUtilisateur.BaseColor = Color.Pink

            GunaTextBoxConfimerMotDePasseUtilisateur.Enabled = False
            GunaTextBoxConfimerMotDePasseUtilisateur.BaseColor = Color.Pink

        End If

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    '------------------------------------- DROITS D'ACCES ---------------------------------------------

    Dim DASHBOARD As Integer = 0
    Dim PLANNING As Integer = 0
    Dim ARRIVEES As Integer = 0
    Dim EN_CHAMBRES As Integer = 0
    Dim DEPARTS As Integer = 0
    Dim ATTRIBUER_CHAMBRE As Integer = 0
    Dim MESSAGES As Integer = 0
    Dim FACTURATION As Integer = 0
    Dim CLOTURE As Integer = 0
    Dim RAPPORT_RECEPTION As Integer = 0
    Dim CARDEX As Integer = 0
    Dim NOUVELLE_RESERVATION As Integer = 0
    Dim MODIFIER_RESERVATION As Integer = 0
    Dim FICHE_DE_POLICE As Integer = 0
    Dim DISPONIBILITE_ET_TARIFS As Integer = 0
    Dim PLAN_DE_CHAMBRE As Integer = 0
    Dim RAPPORT_RESERVATION As Integer = 0
    Dim STATUTS_DES_CHAMBRES As Integer = 0
    Dim HISTORIQUES_DES_CHAMBRES As Integer = 0
    Dim HORS_SERVICES As Integer = 0
    Dim OBJETS_TROUVES_PERDUS As Integer = 0
    Dim RAPPORT_SERVICE_ETAGE As Integer = 0
    Dim CLIENT_EN_CHAMBRE_FACTURATION As Integer = 0
    Dim PAYMASTER_FACTURATION As Integer = 0
    Dim AU_COMPTANT_FACTURATION As Integer = 0
    Dim RAPPORT_BAR_RESTAURANT As Integer = 0
    Dim GESTION_DES_COMPTES As Integer = 0
    Dim LISTE_DES_COMPTES As Integer = 0
    Dim RECHARGE As Integer = 0
    Dim CAUTIONS As Integer = 0
    Dim RAPPORT_COMPTABILITE As Integer = 0
    Dim MOUVEMENT As Integer = 0
    Dim INVENTAIRE As Integer = 0
    Dim FICHE_DE_PRODUIT As Integer = 0
    Dim FOURNISSEURS As Integer = 0
    Dim RAPPORT_ECONOMAT As Integer = 0
    Dim PETITE_CAISSE As Integer = 0
    Dim GRANDE_CAISSE As Integer = 0
    Dim CAISSE_PRINCIPALE_LECTURE As Integer = 0
    Dim CAISSE_PRINCIPALE_ECRITURE As Integer = 0
    Dim PETIT_MAGAZIN As Integer = 0
    Dim GRAND_MAGAZIN As Integer = 0
    Dim SESSION_ADMIN As Integer = 0
    Dim CONFIGURATION As Integer = 0
    Dim SERVICE_TECHNIQUE As Integer = 0
    Dim SECURITE As Integer = 0
    Dim GRATUITEE_HEBERGEMENT As Integer = 0
    Dim IMPRIMER_FB As Integer = 0

    '---------------------------
    Dim RAPPORT_PROMOTEUR As Integer = 0
    Dim RECHERCHER_RESA As Integer = 0
    Dim NETTOYAGE As Integer = 0
    Dim DEBUT_NETTOYAGE As Integer = 0
    Dim FIN_NETTOYAGE As Integer = 0
    Dim CONTROLLER_NETTOYAGE As Integer = 0
    Dim ETAT_CHAMBRE As Integer = 0
    Dim BON_COMMANDE As Integer = 0
    Dim FICHE_TECHNIQUE As Integer = 0
    Dim LISTE_DES_BONS As Integer = 0
    Dim BON_RECEPTION As Integer = 0
    Dim VALIDER As Integer = 0
    Dim CONTROLER As Integer = 0
    Dim COMMANDER As Integer = 0
    Dim VERIFICATION As Integer = 0
    Dim MAGASINS As Integer = 0
    '---------------------------

    Dim MENU_TECHNIQUE As Integer = 0
    Dim Panne As Integer = 0
    Dim SOUS_PANNE As Integer = 0
    Dim DEMANDE_INTERVENTION As Integer = 0
    Dim INTERVENTION As Integer = 0
    Dim RAPPORT_TECHNIQUE As Integer = 0

    '--------------------- LE MENU ACCESIBBLES

    Dim MENU_RECEPTION As Integer = 0
    Dim MENU_RESERVATION As Integer = 0
    Dim MENU_ADMINISTRATEUR As Integer = 0
    Dim MENU_SERVICE_ETAGE As Integer = 0
    Dim MENU_BAR_RESTAURANT As Integer = 0
    Dim MENU_COMPTABILITE As Integer = 0
    Dim MENU_ECONOMAT As Integer = 0

    '--------------------------------------------------
    Dim FACTURES_AGEES As Integer = 0
    Dim FACTURES_COMPTABILITE As Integer = 0
    Dim CAISSE_PRINCIPALE As Integer = 0
    Dim LETTRE_RELANCE As Integer = 0
    Dim GESTION_BLOC_NOTES As Integer = 0
    Dim APPROVISIONNEMENT As Integer = 0
    Dim CORRECTIONS As Integer = 0

    Dim FISCALITE As Integer = 0

    '---------------------------- CUISINE -------------------
    Dim COMMANDE_CUI As Integer = 0
    Dim MATIERE_ARTICLE_CUI As Integer = 0
    Dim FICHE_TECHNIQUE_CUI As Integer = 0
    Dim LISTE_MARCHE_CUI As Integer = 0
    Dim LISTE_ARTICLE_MATIERE_CUI As Integer = 0
    Dim LISTE_FT_CUI As Integer = 0
    Dim RAPPORTS_CUI As Integer = 0
    Dim MENU_CUISINE As Integer = 0

    'RECEPTION ACCESS
    Private Sub GunaCheckBoxReception_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxReception.Click

        If GunaCheckBoxReception.Checked Then

            GunaCheckBoxDashboard.Checked = True
            GunaCheckBoxPlanning.Checked = True
            GunaCheckBoxArrivee.Checked = True
            GunaCheckBoxEnChambre.Checked = True
            GunaCheckBoxDeparts.Checked = True
            GunaCheckBoxAttribuerChambre.Checked = True
            GunaCheckBoxMessage.Checked = True
            GunaCheckBoxFacuration.Checked = True
            GunaCheckBoxCloture.Checked = True
            GunaCheckBoxRapports.Checked = True
            GunaCheckBoxPromoteur.Checked = True
            GunaCheckBoxGratuiteeHebergement.Checked = True

            DASHBOARD = 1
            GRATUITEE_HEBERGEMENT = 1
            PLANNING = 1
            ARRIVEES = 1
            EN_CHAMBRES = 1
            DEPARTS = 1
            ATTRIBUER_CHAMBRE = 1
            MESSAGES = 1
            FACTURATION = 1
            CLOTURE = 1
            RAPPORT_RECEPTION = 1
            RAPPORT_PROMOTEUR = 1
            MENU_RECEPTION = 1

        Else

            GunaCheckBoxDashboard.Checked = False
            GunaCheckBoxPlanning.Checked = False
            GunaCheckBoxArrivee.Checked = False
            GunaCheckBoxEnChambre.Checked = False
            GunaCheckBoxDeparts.Checked = False
            GunaCheckBoxAttribuerChambre.Checked = False
            GunaCheckBoxMessage.Checked = False
            GunaCheckBoxFacuration.Checked = False
            GunaCheckBoxCloture.Checked = False
            GunaCheckBoxRapports.Checked = False
            GunaCheckBoxPromoteur.Checked = False
            GunaCheckBoxGratuiteeHebergement.Checked = False

            DASHBOARD = 0
            GRATUITEE_HEBERGEMENT = 0
            PLANNING = 0
            ARRIVEES = 0
            EN_CHAMBRES = 0
            DEPARTS = 0
            ATTRIBUER_CHAMBRE = 0
            MESSAGES = 0
            FACTURATION = 0
            CLOTURE = 0
            RAPPORT_RECEPTION = 0
            RAPPORT_PROMOTEUR = 0
            MENU_RECEPTION = 0

        End If

    End Sub

    'RESERVATION ACCESS
    Private Sub GunaCheckBoxReservation_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxReservation.Click

        If GunaCheckBoxReservation.Checked Then

            GunaCheckBoxCardex.Checked = True
            GunaCheckBoxNouvelleResa.Checked = True
            GunaCheckBoxModifierResa.Checked = True
            GunaCheckBoxFichePolice.Checked = True
            GunaCheckBoxDisponibilite.Checked = True
            GunaCheckBoxPlanChambre.Checked = True
            GunaCheckBoxRapportResa.Checked = True
            GunaCheckBoxRechercheResa.Checked = True

            CARDEX = 1
            NOUVELLE_RESERVATION = 1
            MODIFIER_RESERVATION = 1
            FICHE_DE_POLICE = 1
            DISPONIBILITE_ET_TARIFS = 1
            PLAN_DE_CHAMBRE = 1
            RAPPORT_RESERVATION = 1
            RECHERCHER_RESA = 1
            MENU_RESERVATION = 1

        Else

            GunaCheckBoxCardex.Checked = False
            GunaCheckBoxNouvelleResa.Checked = False
            GunaCheckBoxModifierResa.Checked = False
            GunaCheckBoxFichePolice.Checked = False
            GunaCheckBoxDisponibilite.Checked = False
            GunaCheckBoxPlanChambre.Checked = False
            GunaCheckBoxRapportResa.Checked = False
            GunaCheckBoxRechercheResa.Checked = False

            CARDEX = 0
            NOUVELLE_RESERVATION = 0
            MODIFIER_RESERVATION = 0
            FICHE_DE_POLICE = 0
            DISPONIBILITE_ET_TARIFS = 0
            PLAN_DE_CHAMBRE = 0
            RAPPORT_RESERVATION = 0
            RECHERCHER_RESA = 0
            MENU_RESERVATION = 0

        End If

    End Sub

    'SERVICE ETAGE ACCESS
    Private Sub GunaCheckBox12_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxServiceEtage.Click

        If GunaCheckBoxServiceEtage.Checked Then

            GunaCheckBoxStatutsChambre.Checked = True
            GunaCheckBoxHistoriques.Checked = True
            GunaCheckBoxHS.Checked = True
            GunaCheckBoxObjets.Checked = True
            GunaCheckBoxRapportServiceEtage.Checked = True
            GunaCheckBoxNettoyage.Checked = True
            GunaCheckBoxDebutNettoyage.Checked = True
            GunaCheckBoxFinNettoyage.Checked = True
            GunaCheckBoxControllerNettoyage.Checked = True
            GunaCheckBoxEtatChambres.Checked = True

            STATUTS_DES_CHAMBRES = 1
            HISTORIQUES_DES_CHAMBRES = 1
            HORS_SERVICES = 1
            OBJETS_TROUVES_PERDUS = 1
            RAPPORT_SERVICE_ETAGE = 1
            NETTOYAGE = 1
            DEBUT_NETTOYAGE = 1
            FIN_NETTOYAGE = 1
            CONTROLLER_NETTOYAGE = 1
            ETAT_CHAMBRE = 1
            MENU_SERVICE_ETAGE = 1

        Else

            GunaCheckBoxStatutsChambre.Checked = False
            GunaCheckBoxHistoriques.Checked = False
            GunaCheckBoxHS.Checked = False
            GunaCheckBoxObjets.Checked = False
            GunaCheckBoxRapportServiceEtage.Checked = False
            GunaCheckBoxNettoyage.Checked = False
            GunaCheckBoxDebutNettoyage.Checked = False
            GunaCheckBoxFinNettoyage.Checked = False
            GunaCheckBoxControllerNettoyage.Checked = False
            GunaCheckBoxEtatChambres.Checked = False

            STATUTS_DES_CHAMBRES = 0
            HISTORIQUES_DES_CHAMBRES = 0
            HORS_SERVICES = 0
            OBJETS_TROUVES_PERDUS = 0
            RAPPORT_SERVICE_ETAGE = 0
            NETTOYAGE = 0
            DEBUT_NETTOYAGE = 0
            FIN_NETTOYAGE = 0
            CONTROLLER_NETTOYAGE = 0
            ETAT_CHAMBRE = 0
            MENU_SERVICE_ETAGE = 0

        End If

    End Sub

    'BAR RESTAURANT D'ETAGE
    Private Sub GunaCheckBoxBarRestaurant_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxBarRestaurant.Click

        If GunaCheckBoxBarRestaurant.Checked Then

            GunaCheckBoxClientEnchambre.Checked = True
            GunaCheckBoxEvents.Checked = True
            GunaCheckBoxComptoire.Checked = True
            GunaCheckBoxBarRapports.Checked = True

            GunaCheckBox6.Checked = True
            GunaCheckBox7.Checked = True
            GunaCheckBoxImprimerFB.Checked = True

            CLIENT_EN_CHAMBRE_FACTURATION = 1
            IMPRIMER_FB = 1
            PAYMASTER_FACTURATION = 1
            AU_COMPTANT_FACTURATION = 1
            RAPPORT_BAR_RESTAURANT = 1

            MENU_BAR_RESTAURANT = 1

            GESTION_BLOC_NOTES = 1
            APPROVISIONNEMENT = 1

        Else

            GunaCheckBoxClientEnchambre.Checked = False
            GunaCheckBoxEvents.Checked = False
            GunaCheckBoxComptoire.Checked = False
            GunaCheckBoxBarRapports.Checked = False

            GunaCheckBox6.Checked = False
            GunaCheckBox7.Checked = False
            GunaCheckBoxImprimerFB.Checked = False

            CLIENT_EN_CHAMBRE_FACTURATION = 0
            IMPRIMER_FB = 0
            PAYMASTER_FACTURATION = 0
            AU_COMPTANT_FACTURATION = 0
            RAPPORT_BAR_RESTAURANT = 0

            MENU_BAR_RESTAURANT = 0

            GESTION_BLOC_NOTES = 0
            APPROVISIONNEMENT = 0

        End If

    End Sub

    'COMPTABILITE
    Private Sub GunaCheckBoxCompatbilite_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxCompatbilite.Click

        If GunaCheckBoxCompatbilite.Checked Then

            GunaCheckBox28.Checked = True
            GunaCheckBox30.Checked = True
            GunaCheckBoxReglementEtLettrage.Checked = True
            GunaCheckBox34.Checked = True
            GunaCheckBox36.Checked = True

            GunaCheckBox2.Checked = True
            GunaCheckBox4.Checked = True
            GunaCheckBox3.Checked = True
            GunaCheckBox5.Checked = True
            GunaCheckBoxFiscalite.Checked = True

            GESTION_DES_COMPTES = 1
            LISTE_DES_COMPTES = 1
            RECHARGE = 1 'REGLEMENT ET LETTRAGE
            CAUTIONS = 1
            RAPPORT_COMPTABILITE = 1

            MENU_COMPTABILITE = 1

            FACTURES_AGEES = 1
            FACTURES_COMPTABILITE = 1
            CAISSE_PRINCIPALE = 1
            LETTRE_RELANCE = 1
            FISCALITE = 1

        Else

            GunaCheckBoxFiscalite.Checked = False

            GunaCheckBox28.Checked = False
            GunaCheckBox30.Checked = False
            GunaCheckBoxReglementEtLettrage.Checked = False
            GunaCheckBox34.Checked = False
            GunaCheckBox36.Checked = False

            GunaCheckBox2.Checked = False
            GunaCheckBox4.Checked = False
            GunaCheckBox3.Checked = False
            GunaCheckBox5.Checked = False

            GESTION_DES_COMPTES = 0
            LISTE_DES_COMPTES = 0
            RECHARGE = 0
            CAUTIONS = 0
            RAPPORT_COMPTABILITE = 0

            MENU_COMPTABILITE = 0

            FACTURES_AGEES = 0
            FACTURES_COMPTABILITE = 0
            CAISSE_PRINCIPALE = 0
            LETTRE_RELANCE = 0
            FISCALITE = 0

        End If

    End Sub

    'ECONOMAT
    Private Sub GunaCheckBoxEconomat_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxEconomat.Click

        If GunaCheckBoxEconomat.Checked Then

            GunaCheckBoxMovt.Checked = True
            GunaCheckBoxInventaire.Checked = True
            GunaCheckBoxFicheProduit.Checked = True
            GunaCheckBoxFournisseur.Checked = True
            GunaCheckBoxEconomatRapports.Checked = True
            GunaCheckBoxBC.Checked = True
            GunaCheckBoxValider.Checked = True
            GunaCheckBoxCommander.Checked = True
            GunaCheckBoxBR.Checked = True
            GunaCheckBoxValider.Checked = True
            GunaCheckBoxMagasins.Checked = True
            GunaCheckBoxFicheTechnique.Checked = True
            GunaCheckBoxlisteDesBons.Checked = True

            GunaCheckBoxControler.Checked = True
            GunaCheckBoxVerification.Checked = True

            MOUVEMENT = 1
            INVENTAIRE = 1
            FICHE_DE_PRODUIT = 1

            FOURNISSEURS = 1
            RAPPORT_ECONOMAT = 1
            BON_COMMANDE = 1
            FICHE_TECHNIQUE = 1
            LISTE_DES_BONS = 1
            BON_RECEPTION = 1
            VALIDER = 1
            CONTROLER = 1
            COMMANDER = 1
            VERIFICATION = 1
            MAGASINS = 1

            MENU_ECONOMAT = 1
        Else

            GunaCheckBoxMovt.Checked = False
            GunaCheckBoxInventaire.Checked = False
            GunaCheckBoxFicheProduit.Checked = False
            GunaCheckBoxFournisseur.Checked = False
            GunaCheckBoxEconomatRapports.Checked = False
            GunaCheckBoxBC.Checked = False
            GunaCheckBoxValider.Checked = False
            GunaCheckBoxCommander.Checked = False
            GunaCheckBoxBR.Checked = False
            GunaCheckBoxValider.Checked = False
            GunaCheckBoxMagasins.Checked = False
            GunaCheckBoxFicheTechnique.Checked = False
            GunaCheckBoxlisteDesBons.Checked = False

            GunaCheckBoxControler.Checked = False
            GunaCheckBoxVerification.Checked = False

            LISTE_DES_BONS = 0
            MOUVEMENT = 0
            INVENTAIRE = 0
            FICHE_DE_PRODUIT = 0
            FICHE_TECHNIQUE = 0
            FOURNISSEURS = 0
            RAPPORT_ECONOMAT = 0
            BON_COMMANDE = 0
            BON_RECEPTION = 0
            VALIDER = 0
            CONTROLER = 0
            COMMANDER = 0
            MAGASINS = 0
            VERIFICATION = 0
            MENU_ECONOMAT = 0

        End If

        'ECONOMAT ET MAGAZIN

    End Sub

    Private Sub GunaCheckBoxCaisses_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxCaissesMagasins.Click

        If GunaCheckBoxCaissesMagasins.Checked Then

            GunaCheckBoxPetiteCaisse.Checked = True
            GunaCheckBoxGrandeCaisse.Checked = True
            GunaCheckBoxPetitMagasin.Checked = True
            GunaCheckBoxGrandMagasin.Checked = True
            GunaCheckBoxCaissePrincipaleLecture.Checked = True
            GunaCheckBoxCaissePrincipaleEcriture.Checked = True

            PETITE_CAISSE = 1
            GRANDE_CAISSE = 1
            PETIT_MAGAZIN = 1
            GRAND_MAGAZIN = 1
            CAISSE_PRINCIPALE_LECTURE = 1
            CAISSE_PRINCIPALE_ECRITURE = 1

        Else

            GunaCheckBoxPetiteCaisse.Checked = False
            GunaCheckBoxGrandeCaisse.Checked = False
            GunaCheckBoxPetitMagasin.Checked = False
            GunaCheckBoxGrandMagasin.Checked = False
            GunaCheckBoxCaissePrincipaleLecture.Checked = False
            GunaCheckBoxCaissePrincipaleEcriture.Checked = False

            PETITE_CAISSE = 0
            GRANDE_CAISSE = 0
            PETIT_MAGAZIN = 0
            GRAND_MAGAZIN = 0
            CAISSE_PRINCIPALE_LECTURE = 0
            CAISSE_PRINCIPALE_ECRITURE = 0

        End If

    End Sub

    'ADMINISTRATION
    Private Sub GunaCheckBoxAdministration_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxAdministration.Click

        If GunaCheckBoxAdministration.Checked Then

            GunaCheckBoxSession.Checked = True
            GunaCheckBoxConfiguration.Checked = True
            GunaCheckBoxAdminServiceTechnique.Checked = True
            GunaCheckBoxSecurite.Checked = True

            SESSION_ADMIN = 1
            CONFIGURATION = 1
            SERVICE_TECHNIQUE = 1
            SECURITE = 1

            MENU_ADMINISTRATEUR = 1

        Else
            GunaCheckBoxSession.Checked = False
            GunaCheckBoxConfiguration.Checked = False
            GunaCheckBoxAdminServiceTechnique.Checked = False
            GunaCheckBoxSecurite.Checked = False

            SESSION_ADMIN = 0
            CONFIGURATION = 0
            SERVICE_TECHNIQUE = 0
            SECURITE = 0

            MENU_ADMINISTRATEUR = 0

        End If

    End Sub

    Private Sub GunaCheckBoxMenuTechnique_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxMenuTechnique.Click

        If GunaCheckBoxMenuTechnique.Checked Then

            GunaCheckBoxFamillePanne.Checked = True
            GunaCheckBoxSousFamillePanne.Checked = True
            GunaCheckBoxDemandeIntervention.Checked = True
            GunaCheckBoxIntervention.Checked = True
            GunaCheckBoxTechniqueRapports.Checked = True

            MENU_TECHNIQUE = 1
            Panne = 1
            SOUS_PANNE = 1
            DEMANDE_INTERVENTION = 1
            INTERVENTION = 1
            RAPPORT_TECHNIQUE = 1

        Else

            GunaCheckBoxFamillePanne.Checked = False
            GunaCheckBoxSousFamillePanne.Checked = False
            GunaCheckBoxDemandeIntervention.Checked = False
            GunaCheckBoxIntervention.Checked = False
            GunaCheckBoxTechniqueRapports.Checked = False

            MENU_TECHNIQUE = 0
            Panne = 0
            SOUS_PANNE = 0
            DEMANDE_INTERVENTION = 0
            INTERVENTION = 0
            RAPPORT_TECHNIQUE = 0

        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrerProfil.Click

        Dim access As New AccessRight()

        Dim CODE_UTILISATEUR As String = ""
        Dim CODE_PROFIL As String = GunaTextBoxCodeProfil.Text
        Dim OLD_CODE_PROFIL As String = GunaTextBoxOldCodeProfil.Text
        Dim NOM_PROFIL As String = GunaTextBoxNomProfil.Text

        '2KLG

        If GunaButtonEnregistrerProfil.Text = "Sauvegarder" Or GunaButtonEnregistrerProfil.Text = "Update" Then

            If access.UpdateAccessRight(CODE_PROFIL, NOM_PROFIL, DASHBOARD, PLANNING, ARRIVEES, EN_CHAMBRES, DEPARTS, ATTRIBUER_CHAMBRE, MESSAGES, FACTURATION, CLOTURE, RAPPORT_RECEPTION, CARDEX, NOUVELLE_RESERVATION, MODIFIER_RESERVATION, FICHE_DE_POLICE, DISPONIBILITE_ET_TARIFS, PLAN_DE_CHAMBRE, RAPPORT_RESERVATION, STATUTS_DES_CHAMBRES, HISTORIQUES_DES_CHAMBRES, HORS_SERVICES, OBJETS_TROUVES_PERDUS, RAPPORT_SERVICE_ETAGE, CLIENT_EN_CHAMBRE_FACTURATION, PAYMASTER_FACTURATION, AU_COMPTANT_FACTURATION, RAPPORT_BAR_RESTAURANT, GESTION_DES_COMPTES, LISTE_DES_COMPTES, RECHARGE, CAUTIONS, RAPPORT_COMPTABILITE, MOUVEMENT, INVENTAIRE, FICHE_DE_PRODUIT, FOURNISSEURS, RAPPORT_ECONOMAT, PETITE_CAISSE, GRANDE_CAISSE, PETIT_MAGAZIN, GRAND_MAGAZIN, SESSION_ADMIN, CONFIGURATION, SERVICE_TECHNIQUE, SECURITE, MENU_RECEPTION, MENU_RESERVATION, MENU_ADMINISTRATEUR, MENU_SERVICE_ETAGE, MENU_BAR_RESTAURANT, MENU_COMPTABILITE, MENU_ECONOMAT, CODE_UTILISATEUR, MENU_TECHNIQUE, Panne, SOUS_PANNE, DEMANDE_INTERVENTION, INTERVENTION, RAPPORT_TECHNIQUE, RAPPORT_PROMOTEUR, RECHERCHER_RESA, NETTOYAGE, DEBUT_NETTOYAGE, FIN_NETTOYAGE, CONTROLLER_NETTOYAGE, ETAT_CHAMBRE, BON_COMMANDE, FICHE_TECHNIQUE, LISTE_DES_BONS, BON_RECEPTION, VALIDER, CONTROLER, COMMANDER, MAGASINS, VERIFICATION, CAISSE_PRINCIPALE_LECTURE, CAISSE_PRINCIPALE_ECRITURE, FACTURES_AGEES, FACTURES_COMPTABILITE, CAISSE_PRINCIPALE, LETTRE_RELANCE, GESTION_BLOC_NOTES, APPROVISIONNEMENT, CORRECTIONS, FISCALITE, MENU_CUISINE, IMPRIMER_FB, GRATUITEE_HEBERGEMENT, OLD_CODE_PROFIL) Then

                'ON APPLIQUE LE CHANGEMENT DU CODE DE PROFIL DANSN UTILISATEUR ACCES
                access.updateUserAccessProfil_2(CODE_PROFIL, OLD_CODE_PROFIL)

                'ON APPLIQUE LE CHANGEMENT DU CODE DE PROFIL DANSN UTILISATEURS
                access.updateUserCateg(CODE_PROFIL, OLD_CODE_PROFIL)

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Profile successfully updated"
                    languageTitle = "Profiles Management"
                    GunaButtonEnregistrerProfil.Text = "Create"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Profil mise à jour avec succès"
                    languageTitle = "Gestion des Profils"
                    GunaButtonEnregistrerProfil.Text = "Créer"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                GunaTextBoxCodeProfil.Clear()
                GunaTextBoxNomProfil.Clear()

                unCheckAccessRight()

                userList()

                profilList()

                emtyFieldsAfterSaving()

                GunaTextBoxOldCodeProfil.Clear()

            Else
                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Error during profile creation"
                    languageTitle = "Profile creation"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Erreur lors de la création du profil"
                    languageTitle = "Création de Profil"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            If access.InsertAccessRight(CODE_PROFIL, NOM_PROFIL, DASHBOARD, PLANNING, ARRIVEES, EN_CHAMBRES, DEPARTS, ATTRIBUER_CHAMBRE, MESSAGES, FACTURATION, CLOTURE, RAPPORT_RECEPTION, CARDEX, NOUVELLE_RESERVATION, MODIFIER_RESERVATION, FICHE_DE_POLICE, DISPONIBILITE_ET_TARIFS, PLAN_DE_CHAMBRE, RAPPORT_RESERVATION, STATUTS_DES_CHAMBRES, HISTORIQUES_DES_CHAMBRES, HORS_SERVICES, OBJETS_TROUVES_PERDUS, RAPPORT_SERVICE_ETAGE, CLIENT_EN_CHAMBRE_FACTURATION, PAYMASTER_FACTURATION, AU_COMPTANT_FACTURATION, RAPPORT_BAR_RESTAURANT, GESTION_DES_COMPTES, LISTE_DES_COMPTES, RECHARGE, CAUTIONS, RAPPORT_COMPTABILITE, MOUVEMENT, INVENTAIRE, FICHE_DE_PRODUIT, FOURNISSEURS, RAPPORT_ECONOMAT, PETITE_CAISSE, GRANDE_CAISSE, PETIT_MAGAZIN, GRAND_MAGAZIN, SESSION_ADMIN, CONFIGURATION, SERVICE_TECHNIQUE, SECURITE, MENU_RECEPTION, MENU_RESERVATION, MENU_ADMINISTRATEUR, MENU_SERVICE_ETAGE, MENU_BAR_RESTAURANT, MENU_COMPTABILITE, MENU_ECONOMAT, CODE_UTILISATEUR, MENU_TECHNIQUE, Panne, SOUS_PANNE, DEMANDE_INTERVENTION, INTERVENTION, RAPPORT_TECHNIQUE, RAPPORT_PROMOTEUR, RECHERCHER_RESA, NETTOYAGE, DEBUT_NETTOYAGE, FIN_NETTOYAGE, CONTROLLER_NETTOYAGE, ETAT_CHAMBRE, BON_COMMANDE, FICHE_TECHNIQUE, LISTE_DES_BONS, BON_RECEPTION, VALIDER, CONTROLER, COMMANDER, MAGASINS, VERIFICATION, CAISSE_PRINCIPALE_LECTURE, CAISSE_PRINCIPALE_ECRITURE, FACTURES_AGEES, FACTURES_COMPTABILITE, CAISSE_PRINCIPALE, LETTRE_RELANCE, GESTION_BLOC_NOTES, APPROVISIONNEMENT, CORRECTIONS, FISCALITE, MENU_CUISINE, IMPRIMER_FB, GRATUITEE_HEBERGEMENT) Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "New profile successfully created"
                    languageTitle = "Profile creation"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Nouveau profil créé avec succès"
                    languageTitle = "Création de Profil"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                GunaTextBoxCodeProfil.Clear()
                GunaTextBoxNomProfil.Clear()

                unCheckAccessRight()

                userList()

                profilList()

                emtyFieldsAfterSaving()

            Else
                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Error during profile creation"
                    languageTitle = "Profile creation"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Erreur lors de la création du profil"
                    languageTitle = "Création de Profil"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        End If

        'On rafraichi en cas de changement
        LoadingAgenceAndUserTypeFromDataBase()

    End Sub

    'SUPPRESSION DES UTILISATEURS
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewUser.Rows.Count > 0 Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "Do you really want to delete : " & GunaDataGridViewUser.CurrentRow.Cells("USER").Value.ToString

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Suppression"
                languageMessage = "Voulez-vous vraiment Supprimer : " & GunaDataGridViewUser.CurrentRow.Cells("UTILISATEUR").Value.ToString
            End If
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else


                If GlobalVariable.actualLanguageValue = 0 Then
                    languageTitle = "Delete"
                    languageMessage = "user successfully deleted"
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewUser, GunaDataGridViewUser.CurrentRow.Cells("USER").Value.ToString, "utilisateurs", "NOM_UTILISATEUR")

                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageTitle = "Supression"
                    languageMessage = "Utiliateur supprimé avec succès"
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewUser, GunaDataGridViewUser.CurrentRow.Cells("UTILISATEUR").Value.ToString, "utilisateurs", "NOM_UTILISATEUR")

                End If

                GunaDataGridViewUser.Columns.Clear()

                userList()

                profilList()

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "No user to be deleted!"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Supression"
                languageMessage = "Aucune utilisateur à suprimer!"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaDataGridViewProfil_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewProfil.CellDoubleClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewProfil.Rows(e.RowIndex)
            Dim profil As DataTable

            If GlobalVariable.actualLanguageValue = 0 Then
                GunaButtonEnregistrerProfil.Text = "Update"
                profil = Functions.getElementByCode(Trim(row.Cells("PROFILE CODE").Value.ToString), "utilisateur_acces", "CODE_PROFIL")
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                GunaButtonEnregistrerProfil.Text = "Sauvegarder"
                profil = Functions.getElementByCode(Trim(row.Cells("CODE DU PROFIL").Value.ToString), "utilisateur_acces", "CODE_PROFIL")
            End If

            If profil.Rows.Count > 0 Then

                GunaTextBoxOldCodeProfil.Text = profil.Rows(0)("CODE_PROFIL")
                GunaTextBoxCodeProfil.Text = profil.Rows(0)("CODE_PROFIL")
                GunaTextBoxNomProfil.Text = profil.Rows(0)("NOM_PROFIL")

                'SOUS ELEMENETs DES MENUS
                'GESTION DES PROFILS

                '1- RECEPTION

                If Integer.Parse(profil.Rows(0)("DASHBOARD")) = 1 Then
                    GunaCheckBoxDashboard.Checked = True
                    DASHBOARD = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("PLANNING")) = 1 Then
                    GunaCheckBoxPlanning.Checked = True
                    PLANNING = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("GRATUITEE_HEBERGEMENT")) = 1 Then
                    GunaCheckBoxGratuiteeHebergement.Checked = True
                    GRATUITEE_HEBERGEMENT = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("ARRIVEES")) = 1 Then
                    GunaCheckBoxArrivee.Checked = True
                    ARRIVEES = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("EN_CHAMBRES")) = 1 Then
                    GunaCheckBoxEnChambre.Checked = True
                    EN_CHAMBRES = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("DEPARTS")) = 1 Then
                    DEPARTS = 1
                    GunaCheckBoxDeparts.Checked = True
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("ATTRIBUER_CHAMBRE")) = 1 Then
                    GunaCheckBoxAttribuerChambre.Checked = True
                    ATTRIBUER_CHAMBRE = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("MESSAGES")) = 1 Then
                    GunaCheckBoxMessage.Checked = True
                    MESSAGES = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("FACTURATION")) = 1 Then
                    GunaCheckBoxFacuration.Checked = True
                    FACTURATION = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("CLOTURE")) = 1 Then
                    GunaCheckBoxCloture.Checked = True
                    CLOTURE = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_RECEPTION")) = 1 Then
                    GunaCheckBoxRapports.Checked = True
                    RAPPORT_RECEPTION = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_PROMOTEUR")) = 1 Then
                    GunaCheckBoxPromoteur.Checked = True
                    RAPPORT_PROMOTEUR = 1
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_RECEPTION")) = 1 Then
                    GunaCheckBoxRapports.Checked = True
                    RAPPORT_RECEPTION = 1
                    MENU_RECEPTION = 1
                End If


                '2- RESERVATION

                If Integer.Parse(profil.Rows(0)("CARDEX")) = 1 Then
                    GunaCheckBoxCardex.Checked = True
                    CARDEX = 1
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("RECHERCHER_RESA")) = 1 Then
                    GunaCheckBoxRechercheResa.Checked = True
                    RECHERCHER_RESA = 1
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("NOUVELLE_RESERVATION")) = 1 Then
                    GunaCheckBoxNouvelleResa.Checked = True
                    NOUVELLE_RESERVATION = 1
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("MODIFIER_RESERVATION")) = 1 Then
                    GunaCheckBoxModifierResa.Checked = True
                    MODIFIER_RESERVATION = 1
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("FICHE_DE_POLICE")) = 1 Then
                    GunaCheckBoxFichePolice.Checked = True
                    FICHE_DE_POLICE = 1
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("DISPONIBILITE_ET_TARIFS")) = 1 Then
                    GunaCheckBoxDisponibilite.Checked = True
                    DISPONIBILITE_ET_TARIFS = 1
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("PLAN_DE_CHAMBRE")) = 1 Then
                    GunaCheckBoxPlanChambre.Checked = True
                    PLAN_DE_CHAMBRE = 1
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("DISPONIBILITE_ET_TARIFS")) = 1 Then
                    DISPONIBILITE_ET_TARIFS = 1
                    GunaCheckBoxDisponibilite.Checked = True
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_RESERVATION")) = 1 Then
                    RAPPORT_RESERVATION = 1
                    GunaCheckBoxRapportResa.Checked = True
                    MENU_RESERVATION = 1
                End If

                '3- SERVICE ETAGE

                If Integer.Parse(profil.Rows(0)("STATUTS_DES_CHAMBRES")) = 1 Then
                    STATUTS_DES_CHAMBRES = 1
                    GunaCheckBoxStatutsChambre.Checked = True
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("HISTORIQUES_DES_CHAMBRES")) = 1 Then
                    GunaCheckBoxHistoriques.Checked = True
                    HISTORIQUES_DES_CHAMBRES = 1
                    MENU_RESERVATION = 1
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("NETTOYAGE")) Then

                    GunaCheckBoxNettoyage.Checked = True
                    NETTOYAGE = 1
                    MENU_SERVICE_ETAGE = 1

                End If

                If Integer.Parse(profil.Rows(0)("DEBUT_NETTOYAGE")) = 1 Then
                    GunaCheckBoxDebutNettoyage.Checked = True
                    DEBUT_NETTOYAGE = 1
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("CONTROLLER_NETTOYAGE")) = 1 Then
                    GunaCheckBoxControllerNettoyage.Checked = True
                    CONTROLLER_NETTOYAGE = 1
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("FIN_NETTOYAGE")) = 1 Then
                    GunaCheckBoxFinNettoyage.Checked = True
                    FIN_NETTOYAGE = 1
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("ETAT_CHAMBRE")) = 1 Then
                    GunaCheckBoxEtatChambres.Checked = True
                    ETAT_CHAMBRE = 1
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("HORS_SERVICES")) = 1 Then
                    GunaCheckBoxHS.Checked = True
                    HORS_SERVICES = 1
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("OBJETS_TROUVES_PERDUS")) = 1 Then
                    GunaCheckBoxObjets.Checked = True
                    OBJETS_TROUVES_PERDUS = 1
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_SERVICE_ETAGE")) = 1 Then
                    GunaCheckBoxRapportServiceEtage.Checked = True
                    RAPPORT_SERVICE_ETAGE = 1
                    MENU_SERVICE_ETAGE = 1
                End If

                '4- ECONOMAT

                If Integer.Parse(profil.Rows(0)("MOUVEMENT")) = 1 Then
                    GunaCheckBoxMovt.Checked = True
                    MOUVEMENT = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("BON_COMMANDE")) = 1 Then
                    GunaCheckBoxBC.Checked = True
                    BON_COMMANDE = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("VALIDER")) = 1 Then
                    GunaCheckBoxValider.Checked = True
                    VALIDER = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("VERIFICATION")) = 1 Then
                    GunaCheckBoxVerification.Checked = True
                    VERIFICATION = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("COMMANDER")) = 1 Then
                    GunaCheckBoxCommander.Checked = True
                    COMMANDER = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("BON_RECEPTION")) = 1 Then
                    GunaCheckBoxBR.Checked = True
                    BON_RECEPTION = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("CONTROLER")) = 1 Then
                    GunaCheckBoxControler.Checked = True
                    CONTROLER = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("MAGASINS")) = 1 Then
                    GunaCheckBoxMagasins.Checked = True
                    MAGASINS = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("FICHE_TECHNIQUE")) = 1 Then
                    GunaCheckBoxFicheTechnique.Checked = True
                    FICHE_TECHNIQUE = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("LISTE_DES_BONS")) = 1 Then
                    GunaCheckBoxlisteDesBons.Checked = True
                    LISTE_DES_BONS = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("FOURNISSEURS")) = 1 Then
                    GunaCheckBoxFournisseur.Checked = True
                    FOURNISSEURS = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("INVENTAIRE")) = 1 Then
                    GunaCheckBoxInventaire.Checked = True
                    INVENTAIRE = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("FICHE_DE_PRODUIT")) = 1 Then
                    GunaCheckBoxFicheProduit.Checked = True
                    FICHE_DE_PRODUIT = 1
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_ECONOMAT")) = 1 Then
                    GunaCheckBoxEconomatRapports.Checked = True
                    RAPPORT_ECONOMAT = 1
                    MENU_ECONOMAT = 1
                End If

                '5- BAR-RESTAURANT

                If Integer.Parse(profil.Rows(0)("CLIENT_EN_CHAMBRE_FACTURATION")) = 1 Then
                    GunaCheckBoxClientEnchambre.Checked = True
                    CLIENT_EN_CHAMBRE_FACTURATION = 1
                    MENU_BAR_RESTAURANT = 1
                End If

                If Integer.Parse(profil.Rows(0)("PAYMASTER_FACTURATION")) = 1 Then 'EVENT FACTURATION
                    GunaCheckBoxEvents.Checked = True
                    PAYMASTER_FACTURATION = 1
                    MENU_BAR_RESTAURANT = 1
                End If


                If Integer.Parse(profil.Rows(0)("AU_COMPTANT_FACTURATION")) = 1 Then
                    GunaCheckBoxComptoire.Checked = True
                    AU_COMPTANT_FACTURATION = 1
                    MENU_BAR_RESTAURANT = 1
                End If

                If Integer.Parse(profil.Rows(0)("IMPRIMER_FB")) = 1 Then
                    GunaCheckBoxImprimerFB.Checked = True
                    IMPRIMER_FB = 1
                    MENU_BAR_RESTAURANT = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_BAR_RESTAURANT")) = 1 Then
                    GunaCheckBoxBarRapports.Checked = True
                    RAPPORT_BAR_RESTAURANT = 1
                    MENU_BAR_RESTAURANT = 1
                End If

                If Integer.Parse(profil.Rows(0)("GESTION_BLOC_NOTES")) = 1 Then
                    GunaCheckBox6.Checked = True
                    GESTION_BLOC_NOTES = 1
                    MENU_BAR_RESTAURANT = 1
                End If

                If Integer.Parse(profil.Rows(0)("APPROVISIONNEMENT")) = 1 Then
                    GunaCheckBox7.Checked = True
                    APPROVISIONNEMENT = 1
                    MENU_BAR_RESTAURANT = 1
                End If

                '6- SERVICE TECHNIQUE

                If Integer.Parse(profil.Rows(0)("PANNE")) = 1 Then
                    Panne = 1
                    MENU_TECHNIQUE = 1
                    GunaCheckBoxFamillePanne.Checked = True
                End If

                If Integer.Parse(profil.Rows(0)("SOUS_PANNE")) = 1 Then
                    GunaCheckBoxSousFamillePanne.Checked = True
                    SOUS_PANNE = 1
                    MENU_TECHNIQUE = 1
                End If


                If Integer.Parse(profil.Rows(0)("DEMANDE_INTERVENTION")) = 1 Then
                    GunaCheckBoxDemandeIntervention.Checked = True
                    DEMANDE_INTERVENTION = 1
                    MENU_TECHNIQUE = 1
                End If

                If Integer.Parse(profil.Rows(0)("INTERVENTION")) = 1 Then
                    GunaCheckBoxIntervention.Checked = True
                    INTERVENTION = 1
                    MENU_TECHNIQUE = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_TECHNIQUE")) = 1 Then
                    GunaCheckBoxTechniqueRapports.Checked = True
                    RAPPORT_TECHNIQUE = 1
                    MENU_TECHNIQUE = 1
                End If

                '7- COMPTABILITE

                If Integer.Parse(profil.Rows(0)("GESTION_DES_COMPTES")) = 1 Then
                    GunaCheckBox28.Checked = True
                    GESTION_DES_COMPTES = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("LISTE_DES_COMPTES")) = 1 Then
                    GunaCheckBox30.Checked = True
                    LISTE_DES_COMPTES = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("RECHARGE")) = 1 Then
                    GunaCheckBoxReglementEtLettrage.Checked = True
                    RECHARGE = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("CAUTIONS")) = 1 Then
                    GunaCheckBox34.Checked = True
                    CAUTIONS = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("FACTURES_AGEES")) = 1 Then
                    GunaCheckBox2.Checked = True
                    FACTURES_AGEES = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("FACTURES_COMPTABILITE")) = 1 Then
                    GunaCheckBox4.Checked = True
                    FACTURES_COMPTABILITE = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("CAISSE_PRINCIPALE")) = 1 Then
                    GunaCheckBox3.Checked = True
                    CAISSE_PRINCIPALE = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("LETTRE_RELANCE")) = 1 Then
                    GunaCheckBox5.Checked = True
                    LETTRE_RELANCE = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("FISCALITE")) = 1 Then
                    GunaCheckBoxFiscalite.Checked = True
                    FISCALITE = 1
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("RAPPORT_COMPTABILITE")) = 1 Then
                    GunaCheckBox36.Checked = True
                    RAPPORT_COMPTABILITE = 1
                    MENU_COMPTABILITE = 1
                End If

                '8 CUISINE A GERER

                'CAISSES

                If Integer.Parse(profil.Rows(0)("PETITE_CAISSE")) = 1 Then
                    GunaCheckBoxPetiteCaisse.Checked = True
                    GunaCheckBoxCaissesMagasins.Checked = True
                    PETITE_CAISSE = 1
                    'MENU_TECHNIQUE = 1
                End If

                If Integer.Parse(profil.Rows(0)("GRANDE_CAISSE")) = 1 Then
                    GunaCheckBoxGrandeCaisse.Checked = True
                    GunaCheckBoxCaissesMagasins.Checked = True
                    GRANDE_CAISSE = 1
                    'MENU_TECHNIQUE = 1
                End If

                If Integer.Parse(profil.Rows(0)("GRAND_MAGAZIN")) = 1 Then
                    GunaCheckBoxGrandMagasin.Checked = True
                    GunaCheckBoxCaissesMagasins.Checked = True
                    GRAND_MAGAZIN = 1
                    'MENU_TECHNIQUE = 1
                End If

                If Integer.Parse(profil.Rows(0)("PETIT_MAGAZIN")) = 1 Then
                    GunaCheckBoxPetitMagasin.Checked = True
                    GunaCheckBoxCaissesMagasins.Checked = True
                    PETIT_MAGAZIN = 1
                    'MENU_TECHNIQUE = 1
                End If

                If Integer.Parse(profil.Rows(0)("CAISSE_PRINCIPALE_ECRITURE")) = 1 Then
                    GunaCheckBoxCaissePrincipaleEcriture.Checked = True
                    GunaCheckBoxCaissesMagasins.Checked = True
                    CAISSE_PRINCIPALE_ECRITURE = 1
                    'MENU_TECHNIQUE = 1
                End If

                If Integer.Parse(profil.Rows(0)("CAISSE_PRINCIPALE_LECTURE")) = 1 Then
                    GunaCheckBoxCaissePrincipaleLecture.Checked = True
                    GunaCheckBoxCaissesMagasins.Checked = True
                    CAISSE_PRINCIPALE_LECTURE = 1
                    'MENU_TECHNIQUE = 1
                End If

                'ADMINISTRATION


                'MENUS
                If Integer.Parse(profil.Rows(0)("MENU_RESERVATION")) = 1 Then
                    GunaCheckBoxReservation.Checked = True
                    MENU_RESERVATION = 1
                End If

                If Integer.Parse(profil.Rows(0)("MENU_RECEPTION")) = 1 Then
                    GunaCheckBoxReception.Checked = True
                    MENU_RECEPTION = 1
                End If

                If Integer.Parse(profil.Rows(0)("MENU_ECONOMAT")) = 1 Then
                    GunaCheckBoxEconomat.Checked = True
                    MENU_ECONOMAT = 1
                End If

                If Integer.Parse(profil.Rows(0)("MENU_SERVICE_ETAGE")) = 1 Then
                    GunaCheckBoxServiceEtage.Checked = True
                    MENU_SERVICE_ETAGE = 1
                End If

                If Integer.Parse(profil.Rows(0)("MENU_BAR_RESTAURANT")) = 1 Then
                    GunaCheckBoxBarRestaurant.Checked = True
                    MENU_BAR_RESTAURANT = 1
                End If

                If Integer.Parse(profil.Rows(0)("MENU_COMPTABILITE")) = 1 Then
                    GunaCheckBoxCompatbilite.Checked = True
                    MENU_COMPTABILITE = 1
                End If

                If Integer.Parse(profil.Rows(0)("MENU_TECHNIQUE")) = 1 Then
                    GunaCheckBoxMenuTechnique.Checked = True
                    MENU_TECHNIQUE = 1
                End If

                If Integer.Parse(profil.Rows(0)("MENU_CUISINE")) = 1 Then
                    GunaCheckBoxMenuCuisine.Checked = True
                    MENU_CUISINE = 1
                End If

                'ADMINISTRATION

                If Integer.Parse(profil.Rows(0)("SESSION_ADMIN")) = 1 Then
                    GunaCheckBoxAdministration.Checked = True
                    GunaCheckBoxSession.Checked = True
                    MENU_ADMINISTRATEUR = 1
                    SESSION_ADMIN = 1
                End If

                If Integer.Parse(profil.Rows(0)("CONFIGURATION")) = 1 Then
                    GunaCheckBoxAdministration.Checked = True
                    GunaCheckBoxConfiguration.Checked = True
                    CONFIGURATION = 1
                    MENU_ADMINISTRATEUR = 1
                End If

                If Integer.Parse(profil.Rows(0)("SERVICE_TECHNIQUE")) = 1 Then
                    GunaCheckBoxAdministration.Checked = True
                    GunaCheckBoxAdminServiceTechnique.Checked = True
                    SERVICE_TECHNIQUE = 1
                    MENU_ADMINISTRATEUR = 1
                End If

                If Integer.Parse(profil.Rows(0)("SECURITE")) = 1 Then
                    GunaCheckBoxAdministration.Checked = True
                    GunaCheckBoxSecurite.Checked = True
                    SECURITE = 1
                    MENU_ADMINISTRATEUR = 1
                End If

                If Integer.Parse(profil.Rows(0)("CLOTURE")) = 1 Then
                    GunaCheckBoxCloture.Checked = True
                    CLOTURE = 1
                End If

                If Integer.Parse(profil.Rows(0)("CORRECTIONS")) = 1 Then
                    GunaCheckBox1.Checked = True
                    CORRECTIONS = 1
                End If

                TabControlUtilisateurProfil.SelectedIndex = 1

            End If

        End If

    End Sub

    Private Sub TabControlUtilisateurProfil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlUtilisateurProfil.SelectedIndexChanged

        If Not TabControlUtilisateurProfil.SelectedIndex = 1 Then

            GunaTextBoxCodeProfil.Clear()
            GunaTextBoxNomProfil.Clear()
            emtyFieldsAfterSaving()

            unCheckAccessRight()

        Else

        End If

        If TabControlUtilisateurProfil.SelectedIndex = 0 Then
            GunaButtonEnregistrer.Visible = True
        Else
            GunaButtonEnregistrer.Visible = False
        End If

    End Sub

    Private Sub SupprimerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem1.Click

        If GunaDataGridViewProfil.Rows.Count > 0 Then

            Dim dialog As DialogResult
            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Do you really want to delete the profile : " & GunaDataGridViewProfil.CurrentRow.Cells("PROFILE CODE").Value.ToString
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Voulez-vous vraiment Supprimer le profil : " & GunaDataGridViewProfil.CurrentRow.Cells("CODE DU PROFIL").Value.ToString
                languageTitle = "Suppression"
            End If
            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewProfil, GunaDataGridViewProfil.CurrentRow.Cells("PROFILE CODE").Value.ToString, "utilisateur_acces", "CODE_PROFIL")

                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewProfil, GunaDataGridViewProfil.CurrentRow.Cells("CODE DU PROFIL").Value.ToString, "utilisateur_acces", "CODE_PROFIL")

                End If

                GunaDataGridViewProfil.Columns.Clear()

                userList()

                profilList()
                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Profile successfully deleted"
                    languageTitle = "Delete"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Profil supprimé avec succès"
                    languageTitle = "Suppression"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            If GlobalVariable.actualLanguageValue = 0 Then
                languageTitle = "Delete"
                languageMessage = "No profile to be deleted!"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageTitle = "Supression"
                languageMessage = "Aucune profil à supprimer!"
            End If
            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    'GESTION DES PROFILS

    '1- RECEPTION

    Private Sub GunaCheckBoxDashboard_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDashboard.Click
        If GunaCheckBoxDashboard.Checked Then
            DASHBOARD = 1
            MENU_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
        Else
            'GunaCheckBoxReception.Checked = False
            DASHBOARD = 0
        End If
    End Sub

    Private Sub GunaCheckBoxGratuiteeHebergement_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxGratuiteeHebergement.Click

        If GunaCheckBoxGratuiteeHebergement.Checked Then
            GRATUITEE_HEBERGEMENT = 1
            MENU_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            GRATUITEE_HEBERGEMENT = 0
        End If

    End Sub

    Private Sub GunaCheckBoxPlanning_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxPlanning.Click
        If GunaCheckBoxPlanning.Checked Then
            PLANNING = 1
            MENU_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
        Else
            'GunaCheckBoxReception.Checked = False
            PLANNING = 0
        End If
    End Sub

    Private Sub GunaCheckBoxArrivee_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxArrivee.Click
        If GunaCheckBoxArrivee.Checked Then
            ARRIVEES = 1
            MENU_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
        Else
            'GunaCheckBoxReception.Checked = False
            ARRIVEES = 0
        End If
    End Sub

    Private Sub GunaCheckBoxEnChambre_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxEnChambre.Click
        If GunaCheckBoxEnChambre.Checked Then
            EN_CHAMBRES = 1
            MENU_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
        Else
            'GunaCheckBoxReception.Checked = False
            EN_CHAMBRES = 0
        End If
    End Sub

    Private Sub GunaCheckBoxDeparts_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDeparts.Click
        If GunaCheckBoxDeparts.Checked Then
            DEPARTS = 1
            MENU_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
        Else
            'GunaCheckBoxReception.Checked = False
            DEPARTS = 0
        End If
    End Sub

    Private Sub GunaCheckBoxAttribuerChambre_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxAttribuerChambre.Click
        If GunaCheckBoxAttribuerChambre.Checked Then
            ATTRIBUER_CHAMBRE = 1
            MENU_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
        Else
            'GunaCheckBoxReception.Checked = False
            ATTRIBUER_CHAMBRE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxMessage_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxMessage.Click
        If GunaCheckBoxMessage.Checked Then
            MESSAGES = 1
            MENU_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
        Else
            ' GunaCheckBoxReception.Checked = False
            MESSAGES = 0
        End If
    End Sub

    Private Sub GunaCheckBoxFacuration_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFacuration.Click
        If GunaCheckBoxFacuration.Checked Then
            FACTURATION = 1
            GunaCheckBoxReception.Checked = True
            MENU_RECEPTION = 1
        Else
            'GunaCheckBoxReception.Checked = False
            FACTURATION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxCloture_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxCloture.Click
        If GunaCheckBoxCloture.Checked Then
            CLOTURE = 1
            GunaCheckBoxReception.Checked = True
            MENU_RECEPTION = 1
        Else
            ' GunaCheckBoxReception.Checked = False
            CLOTURE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxRapports_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxRapports.Click
        If GunaCheckBoxRapports.Checked Then
            RAPPORT_RECEPTION = 1
            GunaCheckBoxReception.Checked = True
            MENU_RECEPTION = 1
        Else
            'GunaCheckBoxReception.Checked = False
            RAPPORT_RECEPTION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxPromoteur_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxPromoteur.Click
        If GunaCheckBoxPromoteur.Checked Then
            RAPPORT_PROMOTEUR = 1
            GunaCheckBoxReception.Checked = True
            MENU_RECEPTION = 1
        Else
            'GunaCheckBoxReception.Checked = False
            RAPPORT_PROMOTEUR = 0
        End If
    End Sub


    '2- RESERVATION

    Private Sub GunaCheckBoxCardex_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxCardex.Click
        If GunaCheckBoxCardex.Checked Then
            CARDEX = 1
            GunaCheckBoxReservation.Checked = True
            MENU_RESERVATION = 1
        Else
            'GunaCheckBoxReservation.Checked = False
            CARDEX = 0
        End If
    End Sub

    Private Sub GunaCheckBoxRechercheResa_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxRechercheResa.Click
        If GunaCheckBoxRechercheResa.Checked Then
            RECHERCHER_RESA = 1
            GunaCheckBoxReservation.Checked = True
            MENU_RESERVATION = 1
        Else
            ' GunaCheckBoxReservation.Checked = False
            RECHERCHER_RESA = 0
        End If
    End Sub

    Private Sub GunaCheckBoxNouvelleResa_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxNouvelleResa.Click
        If GunaCheckBoxNouvelleResa.Checked Then
            NOUVELLE_RESERVATION = 1
            GunaCheckBoxReservation.Checked = True
            MENU_RESERVATION = 1
        Else
            ' GunaCheckBoxReservation.Checked = False
            NOUVELLE_RESERVATION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxModifierResa_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxModifierResa.Click
        If GunaCheckBoxModifierResa.Checked Then
            MODIFIER_RESERVATION = 1
            GunaCheckBoxReservation.Checked = True
            MENU_RESERVATION = 1
        Else
            'GunaCheckBoxReservation.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxFichePolice_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFichePolice.Click
        If GunaCheckBoxFichePolice.Checked Then
            FICHE_DE_POLICE = 1
            GunaCheckBoxReservation.Checked = True
            MENU_RESERVATION = 1
        Else
            'GunaCheckBoxReservation.Checked = False
            FICHE_DE_POLICE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxDisponibilite_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDisponibilite.Click
        If GunaCheckBoxDisponibilite.Checked Then
            DISPONIBILITE_ET_TARIFS = 1
            GunaCheckBoxReservation.Checked = True
            MENU_RESERVATION = 1
        Else
            'GunaCheckBoxReservation.Checked = False
            DISPONIBILITE_ET_TARIFS = 0
        End If
    End Sub

    Private Sub GunaCheckBoxPlanChambre_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxPlanChambre.Click
        If GunaCheckBoxPlanChambre.Checked Then
            PLAN_DE_CHAMBRE = 1
            GunaCheckBoxReservation.Checked = True
            MENU_RESERVATION = 1
        Else
            'GunaCheckBoxReservation.Checked = False
            PLAN_DE_CHAMBRE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxRapportResa_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxRapportResa.Click
        If GunaCheckBoxRapportResa.Checked Then
            RAPPORT_RESERVATION = 1
            GunaCheckBoxReservation.Checked = True
            MENU_RESERVATION = 1
        Else
            'GunaCheckBoxReservation.Checked = False
            RAPPORT_RESERVATION = 0
        End If
    End Sub

    '3- SERVICE ETAGE
    Private Sub GunaCheckBoxStatutsChambre_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxStatutsChambre.Click
        If GunaCheckBoxStatutsChambre.Checked Then
            STATUTS_DES_CHAMBRES = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            ' GunaCheckBoxServiceEtage.Checked = False
            STATUTS_DES_CHAMBRES = 0
        End If
    End Sub

    Private Sub GunaCheckBoxHistoriques_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxHistoriques.Click
        If GunaCheckBoxHistoriques.Checked Then
            HISTORIQUES_DES_CHAMBRES = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            'GunaCheckBoxServiceEtage.Checked = False
            HISTORIQUES_DES_CHAMBRES = 0
        End If
    End Sub

    Private Sub GunaCheckBoxNettoyage_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxNettoyage.Click
        If GunaCheckBoxNettoyage.Checked Then
            NETTOYAGE = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            'GunaCheckBoxServiceEtage.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxDebutNettoyage_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDebutNettoyage.Click
        If GunaCheckBoxDebutNettoyage.Checked Then
            DEBUT_NETTOYAGE = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            'GunaCheckBoxServiceEtage.Checked = False
            NETTOYAGE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxFinNettoyage_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFinNettoyage.Click
        If GunaCheckBoxFinNettoyage.Checked Then
            FIN_NETTOYAGE = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            'GunaCheckBoxServiceEtage.Checked = False
            FIN_NETTOYAGE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxControllerNettoyage_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxControllerNettoyage.Click
        If GunaCheckBoxControllerNettoyage.Checked Then
            CONTROLLER_NETTOYAGE = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            'GunaCheckBoxServiceEtage.Checked = False
            CONTROLLER_NETTOYAGE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxEtatChambres_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxEtatChambres.Click
        If GunaCheckBoxEtatChambres.Checked Then
            ETAT_CHAMBRE = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            'GunaCheckBoxServiceEtage.Checked = False
            ETAT_CHAMBRE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxHS_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxHS.Click
        If GunaCheckBoxHS.Checked Then
            HORS_SERVICES = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            'GunaCheckBoxServiceEtage.Checked = False
            HORS_SERVICES = 0
        End If
    End Sub

    Private Sub GunaCheckBoxObjets_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxObjets.Click
        If GunaCheckBoxObjets.Checked Then
            OBJETS_TROUVES_PERDUS = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            ' GunaCheckBoxServiceEtage.Checked = False
            OBJETS_TROUVES_PERDUS = 0
        End If
    End Sub

    Private Sub GunaCheckBoxRapportServiceEtage_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxRapportServiceEtage.Click
        If GunaCheckBoxRapportServiceEtage.Checked Then
            RAPPORT_SERVICE_ETAGE = 1
            GunaCheckBoxServiceEtage.Checked = True
            MENU_SERVICE_ETAGE = 1
        Else
            'GunaCheckBoxServiceEtage.Checked = False
            RAPPORT_SERVICE_ETAGE = 0
        End If
    End Sub

    '4- ECONOMAT
    Private Sub GunaCheckBoxMovt_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxMovt.Click
        If GunaCheckBoxMovt.Checked Then
            MOUVEMENT = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            MOUVEMENT = 0
        End If
    End Sub

    Private Sub GunaCheckBoxVerification_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxVerification.Click

        If GunaCheckBoxVerification.Checked Then
            VERIFICATION = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            VERIFICATION = 0
        End If

    End Sub
    Private Sub GunaCheckBoxBC_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxBC.Click
        If GunaCheckBoxBC.Checked Then
            BON_COMMANDE = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            BON_COMMANDE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxValider_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxValider.Click

        If GunaCheckBoxValider.Checked Then
            VALIDER = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            VALIDER = 0
        End If

    End Sub

    Private Sub GunaCheckBoxCommander_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxCommander.Click

        If GunaCheckBoxCommander.Checked Then
            COMMANDER = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            COMMANDER = 0
        End If

    End Sub

    Private Sub GunaCheckBoxBR_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxBR.Click
        If GunaCheckBoxBR.Checked Then
            BON_RECEPTION = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            BON_RECEPTION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxValiderBR_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxControler.Click
        If GunaCheckBoxControler.Checked Then
            CONTROLER = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            CONTROLER = 0
        End If
    End Sub

    Private Sub GunaCheckBoxMagasins_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxMagasins.Click
        If GunaCheckBoxMagasins.Checked Then
            MAGASINS = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            ' GunaCheckBoxEconomat.Checked = False
            MAGASINS = 0
        End If
    End Sub

    Private Sub GunaCheckBoxFicheTechnique_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFicheTechnique.Click
        If GunaCheckBoxFicheTechnique.Checked Then
            FICHE_TECHNIQUE = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            FICHE_TECHNIQUE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxlisteDesBons_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxlisteDesBons.Click
        If GunaCheckBoxlisteDesBons.Checked Then
            LISTE_DES_BONS = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxFournisseur_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFournisseur.Click
        If GunaCheckBoxFournisseur.Checked Then
            FOURNISSEURS = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            FOURNISSEURS = 0
        End If
    End Sub

    Private Sub GunaCheckBoxEconomatRapports_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxEconomatRapports.Click
        If GunaCheckBoxEconomatRapports.Checked Then
            RAPPORT_ECONOMAT = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            RAPPORT_ECONOMAT = 0
        End If
    End Sub

    Private Sub GunaCheckBoxInventaire_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxInventaire.Click
        If GunaCheckBoxInventaire.Checked Then
            INVENTAIRE = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            INVENTAIRE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxFicheProduit_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFicheProduit.Click
        If GunaCheckBoxFicheProduit.Checked Then
            FICHE_DE_PRODUIT = 1
            GunaCheckBoxEconomat.Checked = True
            MENU_ECONOMAT = 1
        Else
            'GunaCheckBoxEconomat.Checked = False
            FICHE_DE_PRODUIT = 0
        End If
    End Sub

    'BAR-RESTAURANT
    Private Sub GunaCheckBoxClientEnchambre_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxClientEnchambre.Click
        If GunaCheckBoxClientEnchambre.Checked Then
            CLIENT_EN_CHAMBRE_FACTURATION = 1
            GunaCheckBoxBarRestaurant.Checked = True
            MENU_BAR_RESTAURANT = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            CLIENT_EN_CHAMBRE_FACTURATION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxPaymaster_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxEvents.Click
        If GunaCheckBoxEvents.Checked Then
            PAYMASTER_FACTURATION = 1 'EVENEMENTS
            GunaCheckBoxBarRestaurant.Checked = True
            MENU_BAR_RESTAURANT = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            PAYMASTER_FACTURATION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxComptoire_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxComptoire.Click
        If GunaCheckBoxComptoire.Checked Then
            AU_COMPTANT_FACTURATION = 1
            GunaCheckBoxBarRestaurant.Checked = True
            MENU_BAR_RESTAURANT = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            AU_COMPTANT_FACTURATION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxImprimerFB_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxImprimerFB.Click
        If GunaCheckBoxImprimerFB.Checked Then
            IMPRIMER_FB = 1
            GunaCheckBoxBarRestaurant.Checked = True
            MENU_BAR_RESTAURANT = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            IMPRIMER_FB = 0
        End If
    End Sub

    Private Sub GunaCheckBoxBarRapports_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxBarRapports.Click
        If GunaCheckBoxBarRapports.Checked Then
            RAPPORT_BAR_RESTAURANT = 1
            GunaCheckBoxBarRestaurant.Checked = True
            MENU_BAR_RESTAURANT = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            RAPPORT_BAR_RESTAURANT = 0
        End If
    End Sub

    'SERVICE TECHNIQUE
    Private Sub GunaCheckBoxFamillePanne_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFamillePanne.Click
        If GunaCheckBoxFamillePanne.Checked Then
            Panne = 1
            GunaCheckBoxMenuTechnique.Checked = True
            MENU_TECHNIQUE = 1
        Else
            'GunaCheckBoxMenuTechnique.Checked = False
            Panne = 0
        End If
    End Sub

    Private Sub GunaCheckBoxSousFamillePanne_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxSousFamillePanne.Click
        If GunaCheckBoxSousFamillePanne.Checked Then
            SOUS_PANNE = 1
            GunaCheckBoxMenuTechnique.Checked = True
            MENU_TECHNIQUE = 1
        Else
            SOUS_PANNE = 0
            'GunaCheckBoxMenuTechnique.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBoxDemandeIntervention_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxDemandeIntervention.Click
        If GunaCheckBoxDemandeIntervention.Checked Then
            DEMANDE_INTERVENTION = 1
            GunaCheckBoxMenuTechnique.Checked = True
            MENU_TECHNIQUE = 1
        Else
            'GunaCheckBoxMenuTechnique.Checked = False
            DEMANDE_INTERVENTION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxIntervention_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxIntervention.Click
        If GunaCheckBoxIntervention.Checked Then
            INTERVENTION = 1
            GunaCheckBoxMenuTechnique.Checked = True
            MENU_TECHNIQUE = 1
        Else
            'GunaCheckBoxMenuTechnique.Checked = False
            INTERVENTION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxTechniqueRapports_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxTechniqueRapports.Click
        If GunaCheckBoxTechniqueRapports.Checked Then
            RAPPORT_TECHNIQUE = 1
            GunaCheckBoxMenuTechnique.Checked = True
            MENU_TECHNIQUE = 1
        Else
            ' GunaCheckBoxMenuTechnique.Checked = False
            RAPPORT_TECHNIQUE = 0
        End If
    End Sub

    'CAISSES
    Private Sub GunaCheckBoxPetiteCaisse_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxPetiteCaisse.Click
        If GunaCheckBoxPetiteCaisse.Checked Then
            PETITE_CAISSE = 1
            GunaCheckBoxCaissesMagasins.Checked = True
        Else
            PETITE_CAISSE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxGrandeCaisse_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxGrandeCaisse.Click
        If GunaCheckBoxGrandeCaisse.Checked Then
            GRANDE_CAISSE = 1
            GunaCheckBoxCaissesMagasins.Checked = True
        Else
            GRANDE_CAISSE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxPetitMagasin_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxPetitMagasin.Click
        If GunaCheckBoxPetitMagasin.Checked Then
            PETIT_MAGAZIN = 1
            GunaCheckBoxCaissesMagasins.Checked = True
        Else
            PETIT_MAGAZIN = 0
        End If
    End Sub

    Private Sub GunaCheckBoxGrandMagasin_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxGrandMagasin.Click
        If GunaCheckBoxGrandMagasin.Checked Then
            GRAND_MAGAZIN = 1
            GunaCheckBoxCaissesMagasins.Checked = True
        Else
            GRAND_MAGAZIN = 0
        End If
    End Sub

    'ADMINISTRATION
    Private Sub GunaCheckBoxSession_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxSession.Click
        If GunaCheckBoxSession.Checked Then
            SESSION_ADMIN = 1
            GunaCheckBoxAdministration.Checked = True
            MENU_ADMINISTRATEUR = 1
        Else
            'GunaCheckBoxAdministration.Checked = False
            SESSION_ADMIN = 0
        End If
    End Sub

    Private Sub GunaCheckBoxConfiguration_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxConfiguration.Click
        If GunaCheckBoxConfiguration.Checked Then
            CONFIGURATION = 1
            GunaCheckBoxAdministration.Checked = True
            MENU_ADMINISTRATEUR = 1
        Else
            ' GunaCheckBoxAdministration.Checked = False
            CONFIGURATION = 0
        End If
    End Sub

    Private Sub GunaCheckBoxAdminServiceTechnique_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxAdminServiceTechnique.Click
        If GunaCheckBoxAdminServiceTechnique.Checked Then
            SERVICE_TECHNIQUE = 1
            GunaCheckBoxAdministration.Checked = True
            MENU_ADMINISTRATEUR = 1
        Else
            SERVICE_TECHNIQUE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxSecurite_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxSecurite.Click
        If GunaCheckBoxSecurite.Checked Then
            SECURITE = 1
            GunaCheckBoxAdministration.Checked = True
            MENU_ADMINISTRATEUR = 1
        Else
            SECURITE = 0
        End If

    End Sub

    Private Sub GunaCheckBoxCaissePrincipaleLecture_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxCaissePrincipaleLecture.Click

        If GunaCheckBoxCaissePrincipaleLecture.Checked Then
            CAISSE_PRINCIPALE_LECTURE = 1
            GunaCheckBoxCaissesMagasins.Checked = True
        Else
            CAISSE_PRINCIPALE_LECTURE = 0
        End If

    End Sub

    Private Sub GunaCheckBoxCaissePrincipaleEcriture_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxCaissePrincipaleEcriture.Click

        If GunaCheckBoxCaissePrincipaleEcriture.Checked Then

            CAISSE_PRINCIPALE_ECRITURE = 1

            GunaCheckBoxCaissePrincipaleLecture.Checked = True
            GunaCheckBoxCaissesMagasins.Checked = True

            CAISSE_PRINCIPALE_LECTURE = 1

        Else
            CAISSE_PRINCIPALE_ECRITURE = 0
        End If

    End Sub

    'COMPATBILITE
    Private Sub GunaCheckBox28_Click(sender As Object, e As EventArgs) Handles GunaCheckBox28.Click
        If GunaCheckBox28.Checked Then
            GESTION_DES_COMPTES = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            GESTION_DES_COMPTES = 0
        End If
    End Sub

    Private Sub GunaCheckBox30_Click(sender As Object, e As EventArgs) Handles GunaCheckBox30.Click
        If GunaCheckBox30.Checked Then
            LISTE_DES_COMPTES = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            LISTE_DES_COMPTES = 0
        End If
    End Sub

    Private Sub GunaCheckBoxReglementEtLettrage_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxReglementEtLettrage.Click
        If GunaCheckBoxReglementEtLettrage.Checked Then
            RECHARGE = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            RECHARGE = 0
        End If
    End Sub

    Private Sub GunaCheckBox34_Click(sender As Object, e As EventArgs) Handles GunaCheckBox34.Click
        If GunaCheckBox34.Checked Then
            CAUTIONS = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            CAUTIONS = 0
        End If
    End Sub

    Private Sub GunaCheckBox2_Click(sender As Object, e As EventArgs) Handles GunaCheckBox2.Click
        If GunaCheckBox2.Checked Then
            FACTURES_AGEES = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            FACTURES_AGEES = 0
        End If
    End Sub

    Private Sub GunaCheckBox4_Click(sender As Object, e As EventArgs) Handles GunaCheckBox4.Click
        If GunaCheckBox4.Checked Then
            FACTURES_COMPTABILITE = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            FACTURES_COMPTABILITE = 0
        End If
    End Sub

    Private Sub GunaCheckBox3_Click(sender As Object, e As EventArgs) Handles GunaCheckBox3.Click
        If GunaCheckBox3.Checked Then
            CAISSE_PRINCIPALE = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            CAISSE_PRINCIPALE = 0
        End If
    End Sub

    Private Sub GunaCheckBoxFiscalite_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxFiscalite.Click
        If GunaCheckBoxFiscalite.Checked Then
            FISCALITE = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            FISCALITE = 0
        End If
    End Sub

    Private Sub GunaCheckBox5_Click(sender As Object, e As EventArgs) Handles GunaCheckBox5.Click
        If GunaCheckBox5.Checked Then
            LETTRE_RELANCE = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            LETTRE_RELANCE = 0
        End If
    End Sub

    Private Sub GunaCheckBox36_Click(sender As Object, e As EventArgs) Handles GunaCheckBox36.Click, GunaCheckBoxFiscalite.Click
        If GunaCheckBox36.Checked Then
            RAPPORT_COMPTABILITE = 1
            GunaCheckBoxCompatbilite.Checked = True
            MENU_COMPTABILITE = 1
        Else
            RAPPORT_COMPTABILITE = 0
        End If
    End Sub

    Private Sub GunaCheckBox6_Click(sender As Object, e As EventArgs) Handles GunaCheckBox6.Click
        If GunaCheckBox6.Checked Then
            GESTION_BLOC_NOTES = 1
            GunaCheckBoxBarRestaurant.Checked = True
            MENU_COMPTABILITE = 1
        Else
            GESTION_BLOC_NOTES = 0
        End If
    End Sub

    Private Sub GunaCheckBox7_Click(sender As Object, e As EventArgs) Handles GunaCheckBox7.Click
        If GunaCheckBox7.Checked Then
            APPROVISIONNEMENT = 1
            GunaCheckBoxBarRestaurant.Checked = True
            MENU_COMPTABILITE = 1
        Else
            APPROVISIONNEMENT = 0
        End If
    End Sub

    Private Sub GunaCheckBox1_Click(sender As Object, e As EventArgs) Handles GunaCheckBox1.Click

        If GunaCheckBox1.Checked Then
            CORRECTIONS = 1
        Else
            CORRECTIONS = 0
        End If

    End Sub

    'CUISINE
    Private Sub GunaCheckBoxCuisine_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxMenuCuisine.Click

        If GunaCheckBoxMenuCuisine.Checked Then

            GunaCheckBox9.Checked = True
            GunaCheckBox8.Checked = True
            GunaCheckBox10.Checked = True
            GunaCheckBox11.Checked = True
            GunaCheckBox12.Checked = True
            GunaCheckBox13.Checked = True
            GunaCheckBox14.Checked = True

            COMMANDE_CUI = 1
            MATIERE_ARTICLE_CUI = 1
            FICHE_TECHNIQUE_CUI = 1
            LISTE_MARCHE_CUI = 1
            LISTE_ARTICLE_MATIERE_CUI = 1
            LISTE_FT_CUI = 1
            RAPPORTS_CUI = 1
            MENU_CUISINE = 1

        Else

            GunaCheckBox9.Checked = False
            GunaCheckBox8.Checked = False
            GunaCheckBox10.Checked = False
            GunaCheckBox11.Checked = False
            GunaCheckBox12.Checked = False
            GunaCheckBox13.Checked = False
            GunaCheckBox14.Checked = False

            COMMANDE_CUI = 0
            MATIERE_ARTICLE_CUI = 0
            FICHE_TECHNIQUE_CUI = 0
            LISTE_MARCHE_CUI = 0
            LISTE_ARTICLE_MATIERE_CUI = 0
            LISTE_FT_CUI = 0
            RAPPORTS_CUI = 0
            MENU_CUISINE = 0

        End If

    End Sub


    Private Sub GunaCheckBox9_Click(sender As Object, e As EventArgs) Handles GunaCheckBox9.Click

        If GunaCheckBox9.Checked Then
            COMMANDE_CUI = 1
            GunaCheckBoxMenuCuisine.Checked = True
            MENU_CUISINE = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            COMMANDE_CUI = 0
        End If

    End Sub

    Private Sub GunaCheckBox8_Click(sender As Object, e As EventArgs) Handles GunaCheckBox8.Click
        If GunaCheckBox8.Checked Then
            MATIERE_ARTICLE_CUI = 1
            GunaCheckBoxMenuCuisine.Checked = True
            MENU_CUISINE = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            MATIERE_ARTICLE_CUI = 0
        End If
    End Sub

    Private Sub GunaCheckBox10_Click(sender As Object, e As EventArgs) Handles GunaCheckBox10.Click
        If GunaCheckBox10.Checked Then
            FICHE_TECHNIQUE_CUI = 1
            GunaCheckBoxMenuCuisine.Checked = True
            MENU_CUISINE = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            FICHE_TECHNIQUE_CUI = 0
        End If
    End Sub

    Private Sub GunaCheckBox11_Click(sender As Object, e As EventArgs) Handles GunaCheckBox11.Click

        If GunaCheckBox11.Checked Then
            LISTE_MARCHE_CUI = 1
            GunaCheckBoxMenuCuisine.Checked = True
            MENU_CUISINE = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            LISTE_MARCHE_CUI = 0
        End If

    End Sub

    Private Sub GunaCheckBox12_Click_1(sender As Object, e As EventArgs) Handles GunaCheckBox12.Click

        If GunaCheckBox12.Checked Then
            LISTE_ARTICLE_MATIERE_CUI = 1
            GunaCheckBoxMenuCuisine.Checked = True
            MENU_CUISINE = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            LISTE_ARTICLE_MATIERE_CUI = 0
        End If

    End Sub

    Private Sub GunaCheckBox13_Click(sender As Object, e As EventArgs) Handles GunaCheckBox13.Click
        If GunaCheckBox13.Checked Then
            LISTE_FT_CUI = 1
            GunaCheckBoxMenuCuisine.Checked = True
            MENU_CUISINE = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            LISTE_FT_CUI = 0
        End If
    End Sub

    Private Sub GunaCheckBox14_Click(sender As Object, e As EventArgs) Handles GunaCheckBox14.Click
        If GunaCheckBox14.Checked Then
            RAPPORTS_CUI = 1
            GunaCheckBoxMenuCuisine.Checked = True
            MENU_CUISINE = 1
        Else
            'GunaCheckBoxBarRestaurant.Checked = False
            RAPPORTS_CUI = 0
        End If
    End Sub
End Class