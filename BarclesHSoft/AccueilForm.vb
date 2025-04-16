Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Imports System.IO

Public Class AccueilForm

    'Dim connect As New DataBaseManipulation()

    'Asynchronous load of forms

    Private Sub ChangeDate()

        'Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MMM/yyyy hh:mm:ss")
        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonSeConnecter.Click

        If GunaButtonSeConnecter.Text = "Se connecter" Or GunaButtonSeConnecter.Text = "Login" Then
            GunaLineTextBoxUsername.Select()
            GunaTransitionAnimation.Show(PanelConnexion)
            GunaTransitionAnimation.Hide(PanelAccueil)
        Else

            Dim licence As New Licence()
            licence.gestionDesLicence()

            ActivationForm.Show()
            ActivationForm.TopMost = True

        End If

    End Sub

    Private Sub GunaButtonAnnulerAccueil_Click(sender As Object, e As EventArgs) Handles GunaButtonAnnulerAccueil.Click

        GunaLabelNomUtilisateur.Text = ""
        GunaLabelNomUtilisateur.Visible = False
        GunaLineTextBoxUsername.Clear()
        GunaLineTextBoxMotDePasse.Clear()
        GunaCheckBoxVersion.Checked = False
        GunaLabelVersion.Visible = False
        GunaComboBoxVersion.Visible = False
        GunaTransitionAnimation.Show(PanelAccueil)
        GunaTransitionAnimation.Hide(PanelConnexion)

    End Sub

    Private Sub GunaButtonOuvrirSession_Click(sender As Object, e As EventArgs) Handles GunaButtonOuvrirSession.Click
        'login

        Dim premiereConnexion As Boolean = True

        Dim loginQuery As String = ""

        If GlobalVariable.databaseType = "MYSQL" Then
            loginQuery = "SELECT * FROM utilisateurs WHERE CODE_UTILISATEUR = @CODE_UTILISATEUR AND PASSWORD_UTILISATEUR = @PASSWORD_UTILISATEUR"
        ElseIf GlobalVariable.databaseType = "ODBC" Or GlobalVariable.databaseType = "ACCESS" Then
            loginQuery = "SELECT * FROM utilisateurs WHERE CODE_UTILISATEUR = ? AND PASSWORD_UTILISATEUR = ?"
        End If

        Dim table As New DataTable()

        Dim languageMessage As String = ""
        Dim languageTitle As String = ""
        Dim actionLanguage As String = ""

        If (verifyFields("login")) Then

            If GlobalVariable.databaseType = "MYSQL" Then

                Dim command As MySqlCommand

                command = New MySqlCommand(loginQuery, GlobalVariable.connect)
                command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = GunaLineTextBoxUsername.Text
                command.Parameters.Add("@PASSWORD_UTILISATEUR", MySqlDbType.VarChar).Value = GunaLineTextBoxMotDePasse.Text

                table.Load(command.ExecuteReader())

            ElseIf GlobalVariable.databaseType = "ODBC" Or GlobalVariable.databaseType = "ACCESS" Then

                'Dim selCommand As New OdbcCommand(loginQuery, GlobalVariable.sqlConnection)
                'selCommand.Parameters.Add("@CODE_UTILISATEUR", OdbcType.VarChar).Value = GunaLineTextBoxUsername.Text
                'selCommand.Parameters.Add("@PASSWORD_UTILISATEUR", OdbcType.VarChar).Value = GunaLineTextBoxMotDePasse.Text

                'Dim reader As OdbcDataReader = selCommand.ExecuteReader()

                'table.Load(reader)

            End If

            Dim client As String = ""

            If table.Rows.Count > 0 Then
                client = table.Rows(0)("NOM_UTILISATEUR")
            End If

            If Trim(client.ToUpper()).Equals("CLIENT") Then

                If table.Rows.Count > 0 Then

                    GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

                    GlobalVariable.societe = Functions.allTableFields("societe")

                    GlobalVariable.codeAgence = table.Rows(0)("NUM_AGENCE")

                    GlobalVariable.AgenceActuelle = Functions.getElementByCode(GlobalVariable.codeAgence, "agence", "CODE_AGENCE")

                    GlobalVariable.ConnectedUser = table

                End If

                CustomCommandForm.Show()
                Me.Close()

            Else

                If table.Rows.Count > 0 Then
                    Dim page As Integer = 1
                    Dim mainwindow As New MainWindow()
                    'mainwindow.StatusDesChambres(page) 'Icon des chambres au niveau du dashboard
                    '-------------------------GESTION DES INFORMATIONS AGENCES ET INFORMATIONS DU CLIENT ------------------------------------------

                    GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

                    GlobalVariable.societe = Functions.allTableFields("societe")

                    GlobalVariable.codeAgence = table.Rows(0)("NUM_AGENCE")

                    GlobalVariable.AgenceActuelle = Functions.getElementByCode(GlobalVariable.codeAgence, "agence", "CODE_AGENCE")

                    GlobalVariable.ConnectedUser = table

                    'GESTION DES DROITS D'ACCES DE L'UTILISATEUR ACTUELEMENT CONNECTE
                    'LA GESTION DES DROITS IMPLIQUE L'ACTIVATION OU DEASCTION DES BOUTONS ET PANNEAUX

                    '1- GESTION DES MENUS A AFFICHER

                    Dim AccesUtilisateurActuel As DataTable = AccessRight.DroitAccesUtilisateurActuel(Trim(GlobalVariable.ConnectedUser(0)("CATEG_UTILISATEUR")))
                    GlobalVariable.DroitAccesDeUtilisateurConnect = AccesUtilisateurActuel

                    '---------------------------------------------------------------------------------------------------
                    'We keep the information of the current connected user


                    'get the user id
                    Dim ID_UTILISATEUR As Integer = Convert.ToInt32(table.Rows(0)(0))

                    'Make the User id Global on all classes and forms
                    GlobalVariable.idClient = ID_UTILISATEUR

                    'show the nex window form
                    'We determine if it is the first connexion by searching a society in database
                    Dim existQuery As String = "SELECT * From societe"

                    Dim commandCompany As New MySqlCommand(existQuery, GlobalVariable.connect)

                    Dim adapterCompany As New MySqlDataAdapter(commandCompany)
                    Dim tableCompany As New DataTable()
                    adapterCompany.Fill(tableCompany)

                    Dim NOM_USER As String = ""

                    If (tableCompany.Rows.Count > 0) Then

                        'MISE A ZERO DE TOUS CONCERNANT L'UTILISATEUR ACTUEL
                        Dim CODE_CAISSE As String = ""
                        Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                        Dim ACTION As String = ""

                        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

                            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 1 Then

                                Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                                If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                                    CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

                                    Dim ETAT_CAISSE As Integer = 0
                                    Dim caissier As New Caisse()

                                    NOM_USER = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

                                End If

                            End If

                        Else

                        End If

                        If GlobalVariable.actualLanguageValue = 0 Then
                            actionLanguage = "CONNEXION DE "
                        Else
                            actionLanguage = "LOGIN OF "
                        End If

                        ACTION = actionLanguage & NOM_USER

                        User.mouchard(ACTION)

                        '---------------------------------------------------------------------------------
                        HomeForm.Show()
                        HomeForm.TopMost = True
                        HomeForm.BringToFront()

                        Dim licenceInfo As DataTable = Functions.allTableFields("licence")
                        Dim licence As New Licence()

                        'SI ON TRAITE UNE LICENCE AUTRE QUE CELLE PAR DEFAUT ON DOIT EFFECTUER DES RETRANCHEMENTS

                        If licenceInfo.Rows.Count > 0 Then

                            If Not licenceInfo.Rows(0)("CODE_LICENCE") = "DEFAULT" Then
                                licence.reductionDeNombreDeDemarrageParDefaut(1, licenceInfo.Rows(0)("CODE_LICENCE"))
                            End If

                        End If

                    Else

                        Wizard.Close()
                        Wizard.Show()
                        Wizard.TopMost = True

                        Me.Close()

                    End If

                Else

                    Dim ACTION As String = ""


                    If GlobalVariable.actualLanguageValue = 1 Then 'FRENCH
                        languageMessage = "CODE UTILISATEUR ET/OU MOT DE PASS INVALIDE"
                        languageTitle = "Erreur de Connexion"
                        actionLanguage = "ECHEC DE TENTATIVE DE CONNEXION"
                    Else
                        languageMessage = "INVALIDE USER AND/OR PASSWORD"
                        languageTitle = "Login Error"
                        actionLanguage = "CONNECTION FAILURE"
                    End If

                    ACTION = actionLanguage

                    'User.mouchard(ACTION)

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            End If

        Else

            Dim ACTION As String = ""

            If GlobalVariable.actualLanguageValue = 1 Then 'FRENCH
                languageMessage = "Bien vouloir remplir tous les champs"
                languageTitle = "Champ(s) vide(s)"
                actionLanguage = "ECHEC DE TENTATIVE DE CONNEXION"
            Else
                languageMessage = "Please fill all the field(s)"
                languageTitle = "Empty field(s)"
                actionLanguage = "CONNECTION FAILURE"
            End If

            ACTION = actionLanguage

            'User.mouchard(ACTION)

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    'Function to check empty fields
    Public Function verifyFields(ByVal operation As String) As Boolean

        Dim check As Boolean = False

        'if it is a login operation
        If (operation = "login") Then
            If (GunaLineTextBoxUsername.Text.Trim().Equals("") Or GunaLineTextBoxMotDePasse.Text.Trim().Equals("")) Then
                check = False
            Else
                check = True
            End If
        End If

        Return check

    End Function

    'minimizing the window
    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'closing the window
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click

        Me.Close()
        Application.ExitThread()

    End Sub

    ' We print the name of the current user when we loss focus on the user name input
    Private Sub GunaLineTextBoxUsername_Leave(sender As Object, e As EventArgs) Handles GunaLineTextBoxUsername.Leave

        Dim table As New DataTable()

        'Dim query As String = "SELECT * FROM utilisateurs WHERE CODE_UTILISATEUR=@CODE_UTILISATEUR AND NUM_AGENCE=@NUM_AGENCE"

        If GlobalVariable.databaseType = "MYSQL" Then

            Dim query As String = "SELECT * FROM utilisateurs WHERE CODE_UTILISATEUR=@CODE_UTILISATEUR"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = GunaLineTextBoxUsername.Text
            command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

            table.Load(command.ExecuteReader())

            'connect.closeConnection()

        ElseIf GlobalVariable.databaseType = "ODBC" Or GlobalVariable.databaseType = "ACCESS" Then

            'Dim query As String = "SELECT * FROM utilisateurs WHERE CODE_UTILISATEUR=?"

            'Dim selCommand As New OdbcCommand(query, GlobalVariable.sqlConnection)
            'selCommand.Parameters.Add("@CODE_UTILISATEUR", OdbcType.VarChar).Value = GunaLineTextBoxUsername.Text
            'selCommand.Parameters.Add("@NUM_AGENCE", OdbcType.VarChar).Value = GlobalVariable.codeAgence

            'table.Load(selCommand.ExecuteReader())

        End If

        If (table.Rows.Count > 0) Then

            GunaLabelNomUtilisateur.ForeColor = Color.White
            GunaLabelNomUtilisateur.Visible = True
            GunaLabelNomUtilisateur.Text = table.Rows(0)("NOM_UTILISATEUR")
            GlobalVariable.userId = table.Rows(0)("ID_UTILISATEUR")
            GlobalVariable.ConnectedUser = Functions.getElementByCode(GlobalVariable.userId, "utilisateurs", "ID_UTILISATEUR")

        Else

            Dim languageMessage As String = ""

            If GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Aucun n'utilisateur ne correspond !!"
            Else
                languageMessage = "No user corresponding !!"
            End If

            GunaLabelNomUtilisateur.Visible = True
            GunaLabelNomUtilisateur.Text = languageMessage
            GunaLabelNomUtilisateur.ForeColor = Color.Red

        End If

        'connect.closeConnection()

    End Sub

    Private Sub AccueilForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ChangeDate()

        GunaLabelHotelName.Text = ""
        Functions.emptyConnectionVariable()
        Functions.EmtyGlobalVariablesContainingCodeToUpdate()

        GlobalVariable.databaseType = "MYSQL"
        GlobalVariable.softwareVersion = "barcleshsoftdb"
        'GlobalVariable.connecFunction()

        If GlobalVariable.databaseType = "MYSQL" Then
            GlobalVariable.connecFunction()
            'GlobalVariable.connect.OpenAsync()
        ElseIf GlobalVariable.databaseType = "ACCESS" Then
            'GlobalVariable.sqlConnection.OpenAsync()
        End If

        'GESTION DES LICENCES DU LOGICIELS

        'FONCTION POUR UNE SEULE AGENCE POUR LE MOMENT

        GlobalVariable.AgenceActuelle = Functions.allTableFields("agence")
        GlobalVariable.societe = Functions.allTableFields("societe")

        If GlobalVariable.AgenceActuelle.Rows.Count > 0 Then

            'LANGUE 
            Dim langue As New Languages()

            GlobalVariable.actualLanguageValue = GlobalVariable.AgenceActuelle.Rows(0)("LANGUE")
            langue.autoLoadLanguage(GunaComboBoxLangue, GlobalVariable.actualLanguageValue)

            GlobalVariable.defaultLanguage = GlobalVariable.AgenceActuelle.Rows(0)("LANGUE")

            'GunaComboBoxLangue.SelectedIndex = GlobalVariable.defaultLanguage
            GunaComboBoxLangue.SelectedIndex = 0

            langue.accueil(GlobalVariable.defaultLanguage)

            Dim doc As New Tarifs

            Dim dossierParentHotelSoft As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO")

            Dim nomDuDossierRapport As String = "RAPPORTS"
            Dim nomDuDossierReservation As String = "RESERVATIONS"
            Dim nomDuDossierDataBase As String = "HSDB"

            'CREATION DES REPERTOIRES CLES

            doc.creationDeRepertoire(dossierParentHotelSoft & "\" & nomDuDossierRapport)
            doc.creationDeRepertoire(dossierParentHotelSoft & "\" & nomDuDossierReservation)
            doc.creationDeRepertoire(dossierParentHotelSoft & "\" & nomDuDossierDataBase)

            If GlobalVariable.AgenceActuelle.Rows(0)("CONFIG") = 1 Then

                GlobalVariable.config = Functions.allTableFields("config")

                If GlobalVariable.config.Rows.Count > 0 Then

                    If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then 'HOTEL
                        GunaPictureBoxRestaurant.Visible = False
                        GunaPictureBoxHotel.Visible = True
                        If GlobalVariable.actualLanguageValue = 0 Then
                            GunaLabelTitle.Text = GlobalVariable.config.Rows(0)("DESCRIPTION_1_E") '"HOTEL MANAGEMENT SOFTWARES"
                        Else
                            GunaLabelTitle.Text = GlobalVariable.config.Rows(0)("DESCRIPTION_1_F") '"LOGICIELS DE GESTION HÔTELIERE"
                        End If
                    ElseIf GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 1 Then 'RESTAURANT
                        GunaPictureBoxRestaurant.Visible = True
                        GunaPictureBoxHotel.Visible = False
                        If GlobalVariable.actualLanguageValue = 0 Then
                            GunaLabelTitle.Text = GlobalVariable.config.Rows(0)("DESCRIPTION_2_E") '"RESTAURANT MANAGEMENT SOFTWARE"
                        Else
                            GunaLabelTitle.Text = GlobalVariable.config.Rows(0)("DESCRIPTION_2_F") '"LOGICIEL DE GESTION DE RESTAURANT"
                        End If
                    End If

                    If GlobalVariable.actualLanguageValue = 0 Then
                        TextBoxRights.Text = GlobalVariable.config.Rows(0)("SPEC_1E")
                        TextBox2.Text = GlobalVariable.config.Rows(0)("SPEC_2E")
                        TextBox3.Text = GlobalVariable.config.Rows(0)("SPEC_3E")
                        TextBox1.Text = GlobalVariable.config.Rows(0)("SPEC_4E")
                    Else
                        TextBoxRights.Text = GlobalVariable.config.Rows(0)("SPEC_1F")
                        TextBox2.Text = GlobalVariable.config.Rows(0)("SPEC_2F")
                        TextBox3.Text = GlobalVariable.config.Rows(0)("SPEC_3F")
                        TextBox1.Text = GlobalVariable.config.Rows(0)("SPEC_4F")
                    End If

                    Dim backColorString As String = GlobalVariable.config.Rows(0)("SCHEME_COLOR")
                    Dim backSecondaryColorString As String = GlobalVariable.config.Rows(0)("SCHEME_SECONDARY_COLOR")
                    Dim textColorString As String = GlobalVariable.config.Rows(0)("TEXT_PRIMARY_COLOR")
                    Dim textSecondaryColorString As String = GlobalVariable.config.Rows(0)("TEXT_SECONDARY_COLOR")

                    Dim paramCouleur() As String
                    Dim paramSecondaryCouleur() As String
                    Dim paramSecondaryTextCouleur() As String
                    Dim paramPrimaryTextCouleur() As String

                    paramCouleur = Functions.returningColorFromString(backColorString)
                    paramSecondaryCouleur = Functions.returningColorFromString(backSecondaryColorString)
                    paramSecondaryTextCouleur = Functions.returningColorFromString(textSecondaryColorString)
                    paramPrimaryTextCouleur = Functions.returningColorFromString(textColorString)

                    If paramCouleur(1).Equals("") Then

                        PanelAccueil.BackColor = Color.FromName(paramCouleur(0))
                        GunaPanel1.BackColor = Color.FromName(paramCouleur(0))
                        TextBoxRights.BackColor = Color.FromName(paramCouleur(0))
                        TextBox2.BackColor = Color.FromName(paramCouleur(0))
                        TextBox2.ForeColor = Color.FromName(paramPrimaryTextCouleur(0))
                        TextBox3.BackColor = Color.FromName(paramCouleur(0))
                        TextBox3.ForeColor = Color.FromName(paramPrimaryTextCouleur(0))
                        TextBox1.BackColor = Color.FromName(paramCouleur(0))
                        TextBox1.ForeColor = Color.FromName(paramPrimaryTextCouleur(0))
                        GunaPanelFormTop.BackColor = Color.FromName(paramCouleur(0))
                        GunaButtonSeConnecter.BaseColor = Color.FromName(paramSecondaryCouleur(0))
                        GunaLabelTitle.ForeColor = Color.FromName(paramCouleur(0))
                        GunaButtonAnnulerAccueil.BaseColor = Color.FromName(paramSecondaryCouleur(0))
                        GunaButtonOuvrirSession.BaseColor = Color.FromName(paramSecondaryCouleur(0))

                    Else

                        PanelAccueil.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                        GunaPanel1.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                        TextBoxRights.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                        TextBoxRights.ForeColor = Color.FromArgb(Integer.Parse(paramPrimaryTextCouleur(0)), Integer.Parse(paramPrimaryTextCouleur(1)), Integer.Parse(paramPrimaryTextCouleur(2)), Integer.Parse(paramPrimaryTextCouleur(3)))
                        TextBox2.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                        TextBox2.ForeColor = Color.FromArgb(Integer.Parse(paramPrimaryTextCouleur(0)), Integer.Parse(paramPrimaryTextCouleur(1)), Integer.Parse(paramPrimaryTextCouleur(2)), Integer.Parse(paramPrimaryTextCouleur(3)))
                        TextBox3.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                        TextBox3.ForeColor = Color.FromArgb(Integer.Parse(paramPrimaryTextCouleur(0)), Integer.Parse(paramPrimaryTextCouleur(1)), Integer.Parse(paramPrimaryTextCouleur(2)), Integer.Parse(paramPrimaryTextCouleur(3)))
                        TextBox1.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                        TextBox1.ForeColor = Color.FromArgb(Integer.Parse(paramPrimaryTextCouleur(0)), Integer.Parse(paramPrimaryTextCouleur(1)), Integer.Parse(paramPrimaryTextCouleur(2)), Integer.Parse(paramPrimaryTextCouleur(3)))
                        GunaPanelFormTop.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                        GunaButtonSeConnecter.BaseColor = Color.FromArgb(Integer.Parse(paramSecondaryCouleur(0)), Integer.Parse(paramSecondaryCouleur(1)), Integer.Parse(paramSecondaryCouleur(2)), Integer.Parse(paramSecondaryCouleur(3)))
                        GunaLabelTitle.ForeColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                        GunaButtonAnnulerAccueil.BaseColor = Color.FromArgb(Integer.Parse(paramSecondaryCouleur(0)), Integer.Parse(paramSecondaryCouleur(1)), Integer.Parse(paramSecondaryCouleur(2)), Integer.Parse(paramSecondaryCouleur(3)))
                        GunaButtonOuvrirSession.BaseColor = Color.FromArgb(Integer.Parse(paramSecondaryCouleur(0)), Integer.Parse(paramSecondaryCouleur(1)), Integer.Parse(paramSecondaryCouleur(2)), Integer.Parse(paramSecondaryCouleur(3)))

                    End If

                End If

            Else
                'ORIGINAL

                GunaPictureBoxCustom.Visible = False
                GunaLabelHotelName.Visible = False

                If GlobalVariable.AgenceActuelle.Rows(0)("HOTEL") = 0 Then
                    GunaPictureBoxRestaurant.Visible = False
                    GunaPictureBoxHotel.Visible = True
                    GunaPictureBoxHotel.BringToFront()
                Else
                    GunaPictureBoxRestaurant.Visible = True
                    GunaPictureBoxRestaurant.BringToFront()
                    GunaPictureBoxHotel.Visible = False

                    If GlobalVariable.actualLanguageValue = 0 Then
                        GunaLabelTitle.Text = "RESTAURANT MANAGEMENT SOFTWARE"
                    Else
                        GunaLabelTitle.Text = "LOGICIEL DE GESTION DE RESTAURANT"
                    End If

                End If
            End If

        End If

        Dim licence As New Licence()

        'CREATION DE LA TABLE DES GEATION DE LICENCE SI ELLE N.EXISTE PAS
        licence.creationDeLaTableDeLicence()

        licence.gestionDesLicence()

        Functions.insertionDuNumeroDeCompteDansLesFacturesNePossedantPas()
        Functions.RetablissementDesResteAPayerNegatifEnPositif()

        If GlobalVariable.actualLanguageValue = 1 Then

            '-------- Chambres ----------------------------------
            GlobalVariable.libre_propre = "Libre propre"
            GlobalVariable.occupee_propre = "Occupée propre"
            GlobalVariable.libre_sale = "Libre sale"
            GlobalVariable.occupee_sale = "Occupée sale"
            GlobalVariable.hors_service = "Hors Service"
            GlobalVariable.reserver = "Réservée"

            '-------- Bordereaux --------------------------------
            GlobalVariable.bon_reception = "Bon de Réception"
            'GlobalVariable.bon_requisition = "Bon de Réquisition"
            GlobalVariable.bon_requisition = "Demande d'Achat"
            GlobalVariable.inventaire = "Inventaire"
            GlobalVariable.sortie = "Sortie"
            GlobalVariable.sortie_exceptionnelle = "Sortie Exceptionnelle"
            GlobalVariable.retour_marchandise = "Retour Marchandises"
            GlobalVariable.transfert_inter = "Transfert Inter Magasin"
            GlobalVariable.entree_exceptionnelle = "Entrée Exceptionnelle"
            GlobalVariable.bon_approvisi = "Bon Approvisionnement"
            GlobalVariable.bon_cmd = "Bon de Commande"
            GlobalVariable.list_du_marche = "Liste du Marché"

        Else

            '-------- Chambres ----------------------------------
            GlobalVariable.libre_propre = "Free clean"
            GlobalVariable.occupee_propre = "Occupied clean"
            GlobalVariable.libre_sale = "Free dirty"
            GlobalVariable.occupee_sale = "Occupied dirty"
            GlobalVariable.hors_service = "Out of service"
            GlobalVariable.reserver = "Reserved"

            '-------- Bordereaux --------------------------------
            GlobalVariable.bon_reception = "Delivery slip"
            GlobalVariable.bon_requisition = "Requisition"
            GlobalVariable.inventaire = "Inventory"
            GlobalVariable.sortie = "Exit slip"
            GlobalVariable.sortie_exceptionnelle = "Exceptional Exit"
            GlobalVariable.retour_marchandise = "Product Return"
            GlobalVariable.transfert_inter = "Inter Store Transfer"
            GlobalVariable.entree_exceptionnelle = "Exceptional Entry"
            GlobalVariable.bon_approvisi = "Store Requisition"
            GlobalVariable.bon_cmd = "Order slip"
            GlobalVariable.list_du_marche = "Market List"

        End If

        'Number inscription
        If Not GlobalVariable.AgenceActuelle Is Nothing Then

            If GlobalVariable.AgenceActuelle.Rows.Count > 0 Then

                Dim TEL As String = "+237670756690"
                Dim EMAIL As String = "kamdemlandrygaetan@gmail.com"
                Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("WHATSAPP_7")).Equals(TEL) Then
                    Functions.updateOfFields("agence", "WHATSAPP_7", TEL, "CODE_AGENCE", CODE_AGENCE, 2)
                End If

                If Not Trim(GlobalVariable.AgenceActuelle.Rows(0)("EMAIL_7")).Equals(EMAIL) Then
                    Functions.updateOfFields("agence", "EMAIL_7", EMAIL, "CODE_AGENCE", CODE_AGENCE, 2)
                End If

            End If

        End If

        getFtpServer()

        Dim showCustomImage As Boolean = False

        If GlobalVariable.AgenceActuelle.Rows(0)("CONFIG") = 1 Then
            If GlobalVariable.config.Rows.Count > 0 Then
                showCustomImage = True
            End If
        End If

        If showCustomImage Then

            GunaPictureBoxCustom.Visible = True
            GunaPictureBoxCustom.Top = True
            GunaPictureBoxHotel.Visible = True
            GunaLabelHotelName.Visible = True
            GunaLabelHotelName.Text = GlobalVariable.AgenceActuelle.Rows(0)("NOM_AGENCE")

            '----------------------------
            GunaPictureBoxCustom.Visible = True
            GunaPictureBoxCustom.BringToFront()

            GunaLabelHotelName.Visible = True
            GunaLabelHotelName.BringToFront()

            GunaPictureBoxHotel.Visible = False
            GunaPictureBoxRestaurant.Visible = False
            PictureBox1.Image = Global.BarclesHSoft.My.Resources.Resources.h1

            'ChangeDate()

        Else
            GunaPictureBoxHotel.Visible = True

            GunaPictureBoxCustom.Visible = False
            GunaLabelHotelName.Visible = False

            GunaLabelTitle.BringToFront()
            GunaPictureBoxHotel.Visible = True
            GunaPictureBoxHotel.BringToFront()
        End If

        GunaLabelTitle.Visible = True
        GunaLabelTitle.BringToFront()

    End Sub

    'VERSION OF THE SOFTWARE
    Private Sub GunaCheckBoxVersion_Click(sender As Object, e As EventArgs) Handles GunaCheckBoxVersion.Click

        Dim language As New Languages()

        language.autoLoadVersionLanguage(GlobalVariable.actualLanguageValue)

        If GunaCheckBoxVersion.Checked Then

            GunaLineTextBoxUsername.Clear()
            GunaLineTextBoxMotDePasse.Clear()
            GunaLabelNomUtilisateur.Visible = False

            GunaComboBoxVersion.Visible = True
            GunaLabelVersion.Visible = True

            If GunaComboBoxVersion.Items.Count = 2 Then
                GunaComboBoxVersion.SelectedIndex = 1
            End If

            GlobalVariable.softwareVersion = "barcleshsoftdbdemo"

            GlobalVariable.connecFunction()

        Else

            GunaComboBoxVersion.Visible = False
            GunaLabelVersion.Visible = False

            If GunaComboBoxVersion.Items.Count > 0 Then
                GunaComboBoxVersion.SelectedIndex = 0
            End If

            GlobalVariable.softwareVersion = "barcleshsoftdb"

            GlobalVariable.connecFunction()

        End If

        GunaLabelNomUtilisateur.Text = ""
        GunaLineTextBoxUsername.Clear()
        GunaLineTextBoxMotDePasse.Clear()

    End Sub

    Private Sub GunaComboBoxVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxVersion.SelectedIndexChanged

        If GunaComboBoxVersion.SelectedIndex = 1 Then
            GlobalVariable.softwareVersion = "barcleshsoftdbdemo"
        ElseIf GunaComboBoxVersion.SelectedIndex = 0 Then
            GlobalVariable.softwareVersion = "barcleshsoftdb"
        End If

    End Sub

    Private Sub GunaComboBoxLangue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxLangue.SelectedIndexChanged

        'LANGUE

        'Dim selectedLanguage As Integer

        'If False Then

        'If GunaComboBoxLangue.SelectedIndex >= 0 Then

        'selectedLanguage = GunaComboBoxLangue.SelectedIndex

        'If Not (selectedLanguage = GlobalVariable.actualLanguageValue) Then

        'GlobalVariable.actualLanguageValue = selectedLanguage

        'Dim langue As New Languages()

        'Dim languageValue As Integer = GunaComboBoxLangue.SelectedIndex

        'langue.autoLoadLanguage(GunaComboBoxLangue, languageValue)

        'GunaComboBoxLangue.SelectedIndex = selectedLanguage

        'langue.accueil(languageValue)

        'End If

        'End If

        'End If



    End Sub

    Private Sub GunaButtonOuvrirSession_KeyDown(sender As Object, e As KeyEventArgs) Handles GunaLineTextBoxMotDePasse.KeyDown

        If e.KeyCode = Keys.Enter Then

            Dim premiereConnexion As Boolean = True

            Dim loginQuery As String = ""

            If GlobalVariable.databaseType = "MYSQL" Then
                loginQuery = "SELECT * FROM utilisateurs WHERE CODE_UTILISATEUR = @CODE_UTILISATEUR AND PASSWORD_UTILISATEUR = @PASSWORD_UTILISATEUR"
            ElseIf GlobalVariable.databaseType = "ODBC" Or GlobalVariable.databaseType = "ACCESS" Then
                loginQuery = "SELECT * FROM utilisateurs WHERE CODE_UTILISATEUR = ? AND PASSWORD_UTILISATEUR = ?"
            End If

            Dim table As New DataTable()

            Dim languageMessage As String = ""
            Dim languageTitle As String = ""
            Dim actionLanguage As String = ""

            If (verifyFields("login")) Then

                If GlobalVariable.databaseType = "MYSQL" Then

                    Dim command As MySqlCommand

                    command = New MySqlCommand(loginQuery, GlobalVariable.connect)
                    command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = GunaLineTextBoxUsername.Text
                    command.Parameters.Add("@PASSWORD_UTILISATEUR", MySqlDbType.VarChar).Value = GunaLineTextBoxMotDePasse.Text

                    table.Load(command.ExecuteReader())

                ElseIf GlobalVariable.databaseType = "ODBC" Or GlobalVariable.databaseType = "ACCESS" Then

                    'Dim selCommand As New OdbcCommand(loginQuery, GlobalVariable.sqlConnection)
                    'selCommand.Parameters.Add("@CODE_UTILISATEUR", OdbcType.VarChar).Value = GunaLineTextBoxUsername.Text
                    'selCommand.Parameters.Add("@PASSWORD_UTILISATEUR", OdbcType.VarChar).Value = GunaLineTextBoxMotDePasse.Text

                    'Dim reader As OdbcDataReader = selCommand.ExecuteReader()

                    'table.Load(reader)

                End If

                Dim client As String = ""

                If table.Rows.Count > 0 Then
                    client = table.Rows(0)("NOM_UTILISATEUR")
                End If

                If Trim(client.ToUpper()).Equals("CLIENT") Then

                    If table.Rows.Count > 0 Then

                        GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

                        GlobalVariable.societe = Functions.allTableFields("societe")

                        GlobalVariable.codeAgence = table.Rows(0)("NUM_AGENCE")

                        GlobalVariable.AgenceActuelle = Functions.getElementByCode(GlobalVariable.codeAgence, "agence", "CODE_AGENCE")

                        GlobalVariable.ConnectedUser = table

                    End If

                    CustomCommandForm.Show()
                    Me.Close()

                Else

                    If table.Rows.Count > 0 Then

                        'Dim page As Integer = 1
                        'Dim mainwindow As New MainWindow()
                        'MainWindow.StatusDesChambres(page) 'Icon des chambres au niveau du dashboard
                        '-------------------------GESTION DES INFORMATIONS AGENCES ET INFORMATIONS DU CLIENT ------------------------------------------

                        GlobalVariable.DateDeTravail = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

                        GlobalVariable.societe = Functions.allTableFields("societe")

                        GlobalVariable.codeAgence = table.Rows(0)("NUM_AGENCE")

                        GlobalVariable.AgenceActuelle = Functions.getElementByCode(GlobalVariable.codeAgence, "agence", "CODE_AGENCE")

                        GlobalVariable.ConnectedUser = table

                        'GESTION DES DROITS D'ACCES DE L'UTILISATEUR ACTUELEMENT CONNECTE
                        'LA GESTION DES DROITS IMPLIQUE L'ACTIVATION OU DEASCTION DES BOUTONS ET PANNEAUX

                        '1- GESTION DES MENUS A AFFICHER

                        Dim AccesUtilisateurActuel As DataTable = AccessRight.DroitAccesUtilisateurActuel(Trim(GlobalVariable.ConnectedUser(0)("CATEG_UTILISATEUR")))
                        GlobalVariable.DroitAccesDeUtilisateurConnect = AccesUtilisateurActuel

                        '---------------------------------------------------------------------------------------------------
                        'We keep the information of the current connected user


                        'get the user id
                        Dim ID_UTILISATEUR As Integer = Convert.ToInt32(table.Rows(0)(0))

                        'Make the User id Global on all classes and forms
                        GlobalVariable.idClient = ID_UTILISATEUR

                        'show the nex window form
                        'We determine if it is the first connexion by searching a society in database
                        Dim existQuery As String = "SELECT * From societe"

                        Dim commandCompany As New MySqlCommand(existQuery, GlobalVariable.connect)

                        Dim adapterCompany As New MySqlDataAdapter(commandCompany)
                        Dim tableCompany As New DataTable()
                        adapterCompany.Fill(tableCompany)

                        Dim NOM_USER As String = ""

                        If (tableCompany.Rows.Count > 0) Then

                            'MISE A ZERO DE TOUS CONCERNANT L'UTILISATEUR ACTUEL
                            Dim CODE_CAISSE As String = ""
                            Dim CODE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                            Dim ACTION As String = ""

                            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows.Count > 0 Then

                                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 1 Then

                                    Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                                    If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                                        CODE_CAISSE = CAISSE_UTILISATEUR.Rows(0)("CODE_CAISSE")

                                        Dim ETAT_CAISSE As Integer = 0
                                        Dim caissier As New Caisse()

                                        NOM_USER = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

                                    End If

                                End If

                            Else

                            End If

                            If GlobalVariable.actualLanguageValue = 0 Then
                                actionLanguage = "CONNEXION DE "
                            Else
                                actionLanguage = "LOGIN OF "
                            End If

                            ACTION = actionLanguage & NOM_USER

                            User.mouchard(ACTION)

                            '---------------------------------------------------------------------------------
                            HomeForm.Show()
                            HomeForm.TopMost = True
                            HomeForm.BringToFront()

                            Dim licenceInfo As DataTable = Functions.allTableFields("licence")
                            Dim licence As New Licence()

                            'SI ON TRAITE UNE LICENCE AUTRE QUE CELLE PAR DEFAUT ON DOIT EFFECTUER DES RETRANCHEMENTS

                            If licenceInfo.Rows.Count > 0 Then

                                If Not licenceInfo.Rows(0)("CODE_LICENCE") = "DEFAULT" Then
                                    licence.reductionDeNombreDeDemarrageParDefaut(1, licenceInfo.Rows(0)("CODE_LICENCE"))
                                End If

                            End If

                        Else

                            Wizard.Close()
                            Wizard.Show()
                            Wizard.TopMost = True

                            Me.Close()

                        End If

                    Else

                        Dim ACTION As String = ""


                        If GlobalVariable.actualLanguageValue = 1 Then 'FRENCH
                            languageMessage = "CODE UTILISATEUR ET/OU MOT DE PASS INVALIDE"
                            languageTitle = "Erreur de Connexion"
                            actionLanguage = "ECHEC DE TENTATIVE DE CONNEXION"
                        Else
                            languageMessage = "INVALIDE USER AND/OR PASSWORD"
                            languageTitle = "Login Error"
                            actionLanguage = "CONNECTION FAILURE"
                        End If

                        ACTION = actionLanguage

                        'User.mouchard(ACTION)

                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If

                End If

            Else

                Dim ACTION As String = ""

                If GlobalVariable.actualLanguageValue = 1 Then 'FRENCH
                    languageMessage = "Bien vouloir remplir tous les champs"
                    languageTitle = "Champ(s) vide(s)"
                    actionLanguage = "ECHEC DE TENTATIVE DE CONNEXION"
                Else
                    languageMessage = "Please fill all the field(s)"
                    languageTitle = "Empty field(s)"
                    actionLanguage = "CONNECTION FAILURE"
                End If

                ACTION = actionLanguage

                'User.mouchard(ACTION)

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        End If

    End Sub

    Private Sub getFtpServer()
        GlobalVariable.server_ftp = Functions.allTableFields("serveur_ftp")
    End Sub

End Class
