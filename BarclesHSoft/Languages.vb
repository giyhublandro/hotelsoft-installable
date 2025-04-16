Public Class Languages

    Public Sub autoLoadLanguage(ByVal GunaComboBoxLangue As ComboBox, ByVal ActualLanguageValue As Integer)

        GunaComboBoxLangue.Items.Clear()

        If ActualLanguageValue = 1 Then ' FRENCH
            'GunaComboBoxLangue.Items.Add("Anglais")
            GunaComboBoxLangue.Items.Add("Français")
        ElseIf ActualLanguageValue = 0 Then 'ENGLISH
            GunaComboBoxLangue.Items.Add("English")
            'GunaComboBoxLangue.Items.Add("French")
        End If

        'GunaComboBoxLangue.SelectedIndex = GlobalVariable.defaultLanguage

    End Sub

    Public Sub autoLoadLanguageAgence(ByVal GunaComboBoxLangue As ComboBox, ByVal ActualLanguageValue As Integer)

        GunaComboBoxLangue.Items.Clear()

        If ActualLanguageValue = 1 Then ' FRENCH
            GunaComboBoxLangue.Items.Add("Anglais")
            GunaComboBoxLangue.Items.Add("Français")
        ElseIf ActualLanguageValue = 0 Then 'ENGLISH
            GunaComboBoxLangue.Items.Add("English")
            GunaComboBoxLangue.Items.Add("French")
        End If

    End Sub

    Public Sub rapportsFacture(ByVal ActualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 1 Then

            RapportFacturesForm.GunaButtonAfficher.Text = "Afficher"
            RapportFacturesForm.GunaButtonImprimer.Text = "Imprimer"
            RapportFacturesForm.GunaLabel35.Text = "Du"
            RapportFacturesForm.GunaLabel4.Text = "Au"
            RapportFacturesForm.GunaCheckBoxParFamille.Text = "Par famille"
            RapportFacturesForm.GunaCheckBoxTous.Text = "Tous"

        Else

            RapportFacturesForm.GunaButtonAfficher.Text = "View"
            RapportFacturesForm.GunaButtonImprimer.Text = "Print"
            RapportFacturesForm.GunaLabel35.Text = "From"
            RapportFacturesForm.GunaLabel4.Text = "To"
            RapportFacturesForm.GunaCheckBoxParFamille.Text = "Order by Family"
            RapportFacturesForm.GunaCheckBoxTous.Text = "All"

        End If

    End Sub


    Public Sub facturation(ByVal ActualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 1 Then

            FacturationForm.GunaCheckBoxChangeSecteur.Text = "Autres Points de Ventes"
            FacturationForm.GunaButtonLecture.Text = "Lire Carte"
            FacturationForm.Label6.Text = "Solde"
            FacturationForm.Label7.Text = "TVA"
            FacturationForm.Label8.Text = "Montant"
            FacturationForm.GunaButtonNouveauBloc.Text = "Nouveau"

            FacturationForm.LabelNumeroChambre.Text = "Chambre N°"
            FacturationForm.LabelBlocNoteOuTable.Text = "Table / No Bloc Note"
            FacturationForm.GunaLabelHeader.Text = "FACTURATION"
            FacturationForm.GunaButtonFermer.Text = "Fermer"
            FacturationForm.GunaButtonSaveFacturation.Text = "Enregistrer"
            FacturationForm.GunaButton3.Text = "Imprimer"
            FacturationForm.GunaButtonnNouvelleFacture.Text = "Nouveau"
            FacturationForm.GunaAdvenceButtonLectureDeCarte.Text = "LIRE CARTE"
            FacturationForm.Label5.Text = "Situation caisse"
            FacturationForm.Label9.Text = "Détails de la Facture"
            FacturationForm.Label25.Text = "Réduction"
            FacturationForm.GunaButtonAjouterLigne.Text = "Ajouter"
            FacturationForm.Label13.Text = "Montant TTC"
            FacturationForm.Label21.Text = "Remise (%)"
            FacturationForm.LibelleFacturation.Text = "CLIENT EN CHAMBRE"

            FacturationForm.Label11.Text = "Quantité"
            FacturationForm.Label12.Text = "Prix Unitaire"
            FacturationForm.Label23.Text = "Stock Economat"


            FacturationForm.SupprimerToolStripMenuItem.Text = "Supprimer"

        Else

            FacturationForm.SupprimerToolStripMenuItem.Text = "Delete"

            FacturationForm.GunaCheckBoxChangeSecteur.Text = "Other points of sales"
            FacturationForm.GunaButtonLecture.Text = "Read Card"
            FacturationForm.Label6.Text = "Balance"
            FacturationForm.Label7.Text = "VAT"
            FacturationForm.Label8.Text = "Amount"
            FacturationForm.GunaButtonNouveauBloc.Text = "Add"

            FacturationForm.LabelNumeroChambre.Text = "Room N°"
            FacturationForm.LabelBlocNoteOuTable.Text = "Table / Receipt Number"
            FacturationForm.GunaLabelHeader.Text = "BILLING"
            FacturationForm.GunaButtonFermer.Text = "Close"
            FacturationForm.GunaButtonSaveFacturation.Text = "Save"
            FacturationForm.GunaButton3.Text = "Print"
            FacturationForm.GunaButtonnNouvelleFacture.Text = "New"
            FacturationForm.GunaAdvenceButtonLectureDeCarte.Text = "READ CARD"
            FacturationForm.Label5.Text = "Cashier Balance"
            FacturationForm.Label9.Text = "Billing Details"
            FacturationForm.Label25.Text = "Reduction"
            FacturationForm.GunaButtonAjouterLigne.Text = "Add"
            FacturationForm.Label13.Text = "AMount IVAT"
            FacturationForm.Label21.Text = "Discount (%)"
            FacturationForm.LibelleFacturation.Text = "CLIENT IN HOUSE"

            FacturationForm.Label11.Text = "Quantity"
            FacturationForm.Label12.Text = "Unit Price"
            FacturationForm.Label23.Text = "Inventory"

        End If

    End Sub

    Public Sub autoLoadModeReglement(ByVal ActualLanguageValue As Integer)

        ReglementForm.GunaComboBoxModereglement.Items.Clear()
        ReglementForm.GunaComboBoxCritereElite.Items.Clear()

        If ActualLanguageValue = 1 Then ' FRENCH

            ReglementForm.GunaComboBoxModereglement.Items.Add("Cash") '0
            ReglementForm.GunaComboBoxModereglement.Items.Add("Chèque") '1
            ReglementForm.GunaComboBoxModereglement.Items.Add("Carte Bancaire") '2
            ReglementForm.GunaComboBoxModereglement.Items.Add("Prise en charge") '3
            ReglementForm.GunaComboBoxModereglement.Items.Add("MTN Money") '4
            ReglementForm.GunaComboBoxModereglement.Items.Add("ORANGE Money") '5
            ReglementForm.GunaComboBoxModereglement.Items.Add("Gratuitée") '6
            ReglementForm.GunaComboBoxModereglement.Items.Add("Transfert En Chambre") '7
            ReglementForm.GunaComboBoxModereglement.Items.Add("Transfert Vers Compte Débiteur") '8
            ReglementForm.GunaComboBoxModereglement.Items.Add("Virement Bancaire") '9
            ReglementForm.GunaComboBoxModereglement.Items.Add("Club Elite") '10

            ReglementForm.GunaComboBoxCritereElite.Items.Add("Points")
            ReglementForm.GunaComboBoxCritereElite.Items.Add("Nuits")
            ReglementForm.GunaComboBoxCritereElite.Items.Add("Séjours")


        ElseIf ActualLanguageValue = 0 Then 'ENGLISH

            ReglementForm.GunaComboBoxModereglement.Items.Add("Cash")
            ReglementForm.GunaComboBoxModereglement.Items.Add("Cheque")
            ReglementForm.GunaComboBoxModereglement.Items.Add("Credit Card")
            ReglementForm.GunaComboBoxModereglement.Items.Add("Taking charge")
            ReglementForm.GunaComboBoxModereglement.Items.Add("MTN Money")
            ReglementForm.GunaComboBoxModereglement.Items.Add("ORANGE Money")
            ReglementForm.GunaComboBoxModereglement.Items.Add("Free")
            ReglementForm.GunaComboBoxModereglement.Items.Add("Room Transfer")
            ReglementForm.GunaComboBoxModereglement.Items.Add("Transfer to Debtor Account")
            ReglementForm.GunaComboBoxModereglement.Items.Add("Bank Transfer")
            ReglementForm.GunaComboBoxModereglement.Items.Add("Elite Club")

            ReglementForm.GunaComboBoxCritereElite.Items.Add("Points")
            ReglementForm.GunaComboBoxCritereElite.Items.Add("Nights")
            ReglementForm.GunaComboBoxCritereElite.Items.Add("Stay")

            ReglementForm.GunaButtonDepotDeGarantie.Text = "Arrhes Reference"

            ReglementForm.GunaComboBoxCompteIndividuelOuPaymaster.Items.Clear()
            ReglementForm.GunaComboBoxCompteIndividuelOuPaymaster.Items.Add("INDIVIDUAL")
            ReglementForm.GunaComboBoxCompteIndividuelOuPaymaster.Items.Add("ACCOUNT")

        End If

    End Sub

    Public Sub autoLoadModeReglementMini(ByVal ActualLanguageValue As Integer)

        MiniReglementForm.GunaComboBoxModereglement.Items.Clear()
        MiniReglementForm.GunaComboBoxCritereElite.Items.Clear()

        If ActualLanguageValue = 1 Then ' FRENCH

            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Cash") '0
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Chèque") '1
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Carte Bancaire") '2
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Prise en charge") '3
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("MTN Money") '4
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("ORANGE Money") '5
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Gratuitée") '6
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Transfert En Chambre") '7
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Transfert Vers Compte Débiteur") '8
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Virement Bancaire") '9
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Club Elite") '10

            MiniReglementForm.GunaComboBoxCritereElite.Items.Add("Points")
            MiniReglementForm.GunaComboBoxCritereElite.Items.Add("Nuits")
            MiniReglementForm.GunaComboBoxCritereElite.Items.Add("Séjours")

        ElseIf ActualLanguageValue = 0 Then 'ENGLISH

            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Cash")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Cheque")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Credit Card")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Taking charge")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("MTN Money")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("ORANGE Money")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Free")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Room Transfer")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Transfer to Debtor Account")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Bank Transfer")
            MiniReglementForm.GunaComboBoxModereglement.Items.Add("Elite Club")

            MiniReglementForm.GunaComboBoxCritereElite.Items.Add("Points")
            MiniReglementForm.GunaComboBoxCritereElite.Items.Add("Nights")
            MiniReglementForm.GunaComboBoxCritereElite.Items.Add("Stay")

            MiniReglementForm.GunaButtonDepotDeGarantie.Text = "Arrhes Reference"

        End If

    End Sub

    Public Sub autoLoadVersionLanguage(ByVal ActualLanguageValue As Integer)

        AccueilForm.GunaComboBoxVersion.Items.Clear()

        If ActualLanguageValue = 1 Then ' 
            AccueilForm.GunaComboBoxVersion.Items.Add("Complète")
            AccueilForm.GunaComboBoxVersion.Items.Add("Démonstration")
        ElseIf ActualLanguageValue = 0 Then
            AccueilForm.GunaComboBoxVersion.Items.Add("Complete")
            AccueilForm.GunaComboBoxVersion.Items.Add("Practise")
        End If

        AccueilForm.GunaComboBoxVersion.SelectedIndex = 0

    End Sub

    Public Sub accueil(ByVal ActualLanguageValue As Integer)

        'ActualLanguageValue = 1 : FRENCH
        'ActualLanguageValue = 0 : ENGLISH

        If ActualLanguageValue = 0 Then ' 

            AccueilForm.GunaLabelNomUtilisateur.Text = "No user corresponding !!"

            AccueilForm.GunaLabelLangue.Text = "Language"

            '------------------------------------------------
            'SELON SI ON DOIT ENCORE SE CONNECTER OU PAS

            Dim licence As New Licence()
            Dim licenceDefault As DataTable = Functions.allTableFields("licence")

            If licenceDefault.Rows.Count > 0 Then

                If licenceDefault.Rows(0)("CODE_LICENCE") = "DEFAULT" Then

                    'ON NE DOIT PLUS DECREMENTE LORSQUE L'ON ATTEINT 0 
                    If licenceDefault.Rows(0)("NC") > 0 Then

                        'licence.reductionDeNombreDeDemarrageParDefaut(1, licenceDefault.Rows(0)("CODE_LICENCE"))

                        If licenceDefault.Rows(0)("NC") = 0 Then
                            AccueilForm.GunaButtonSeConnecter.Text = "ACTIVATE HOTEL SOFT"
                        Else
                            AccueilForm.GunaButtonSeConnecter.Text = "Login"
                        End If

                    Else

                        If licenceDefault.Rows(0)("NC") = 0 Then
                            AccueilForm.GunaButtonSeConnecter.Text = "ACTIVATE HOTEL SOFT"
                        Else
                            AccueilForm.GunaButtonSeConnecter.Text = "Login"
                        End If

                    End If

                Else

                    'TRAITEMENT DES AUTRES TYPE DE LICENCE

                    Dim license As New Licence()
                    Dim serialKey As String = licenceDefault.Rows(0)("CODE_LICENCE")
                    Dim NC As Integer = licenceDefault.Rows(0)("NC")

                    '---------------------------------------
                    If license.licenceVerification(serialKey) Then
                        If license.licenceValidityVerification(serialKey, NC) Then
                            AccueilForm.GunaButtonSeConnecter.Text = "Login"
                        Else
                            AccueilForm.GunaButtonSeConnecter.Text = "ACTIVATE HOTEL SOFT"
                        End If
                    Else
                        AccueilForm.GunaButtonSeConnecter.Text = "ACTIVATE HOTEL SOFT"
                    End If
                    '---------------------------------------

                End If

            Else
                AccueilForm.GunaButtonSeConnecter.Text = "ACTIVATE HOTEL SOFT"
            End If
            '------------------------------------------------

            AccueilForm.GunaLabelUser.Text = "User :"
            AccueilForm.GunaLabelPwd.Text = "Password :"
            AccueilForm.GunaButtonAnnulerAccueil.Text = "Cancel"
            AccueilForm.GunaButtonOuvrirSession.Text = "Open a Session"
            AccueilForm.GunaLabelTitle.Text = "HOTEL MANAGEMENT SOFTWARES"
            AccueilForm.TextBoxRights.Text = "Copyrights BARCLES HOTEL SOFT,  2021 Allrights Reserved"
            AccueilForm.TextBox2.Text = "By BARCLES DIGITAL TECHNOLOGIES Cameroon"

        ElseIf ActualLanguageValue = 1 Then

            AccueilForm.GunaLabelNomUtilisateur.Text = "Aucun n'utilisateur ne correspond !!"

            AccueilForm.GunaLabelLangue.Text = "Langue"

            '------------------------------------------------
            'SELON SI ON DOIT ENCORE SE CONNECTER OU PAS

            Dim licence As New Licence()
            Dim licenceDefault As DataTable = Functions.allTableFields("licence")

            If licenceDefault.Rows.Count > 0 Then

                If licenceDefault.Rows(0)("CODE_LICENCE") = "DEFAULT" Then

                    'ON NE DOIT PLUS DECREMENTE LORSQUE L'ON ATTEINT 0 
                    If licenceDefault.Rows(0)("NC") > 0 Then

                        'licence.reductionDeNombreDeDemarrageParDefaut(1, licenceDefault.Rows(0)("CODE_LICENCE"))

                        If licenceDefault.Rows(0)("NC") = 0 Then
                            AccueilForm.GunaButtonSeConnecter.Text = "ACTIVER HOTEL SOFT"
                        Else
                            AccueilForm.GunaButtonSeConnecter.Text = "Se connecter"
                        End If

                    Else

                        If licenceDefault.Rows(0)("NC") = 0 Then
                            AccueilForm.GunaButtonSeConnecter.Text = "ACTIVER HOTEL SOFT"
                        Else
                            AccueilForm.GunaButtonSeConnecter.Text = "Se connecter"
                        End If

                    End If

                Else

                    'TRAITEMENT DES AUTRES TYPE DE LICENCE

                    Dim license As New Licence()
                    Dim serialKey As String = licenceDefault.Rows(0)("CODE_LICENCE")
                    Dim NC As Integer = licenceDefault.Rows(0)("NC")

                    '---------------------------------------
                    If license.licenceVerification(serialKey) Then

                        If license.licenceValidityVerification(serialKey, NC) Then
                            AccueilForm.GunaButtonSeConnecter.Text = "Se connecter"
                        Else
                            AccueilForm.GunaButtonSeConnecter.Text = "ACTIVER HOTEL SOFT"
                        End If

                    Else
                        AccueilForm.GunaButtonSeConnecter.Text = "ACTIVER HOTEL SOFT"
                    End If
                    '---------------------------------------

                End If

            Else
                AccueilForm.GunaButtonSeConnecter.Text = "ACTIVER HOTEL SOFT"
            End If

            AccueilForm.GunaLabelUser.Text = "Utilisateur :"
            AccueilForm.GunaLabelPwd.Text = "Mot de passe :"
            AccueilForm.GunaButtonAnnulerAccueil.Text = "Annuler"
            AccueilForm.GunaButtonOuvrirSession.Text = "Ouvrir une Session"
            AccueilForm.GunaLabelTitle.Text = "LOGICIELS DE GESTION HÔTELIERE"
            AccueilForm.TextBoxRights.Text = "Copyrights BARCLES HOTEL SOFT,  2021 Tous droits réservés"
            AccueilForm.TextBox2.Text = "Par BARCLES DIGITAL TECHNOLOGIES Cameroun"
        End If

        autoLoadVersionLanguage(ActualLanguageValue)

    End Sub

    Public Sub home(ByVal ActualLanguageValue As Integer)

        'ActualLanguageValue = 1 : FRENCH
        'ActualLanguageValue = 0 : ENGLISH

        If ActualLanguageValue = 0 Then ' 

            HomeForm.GunaButtonAccueil1.Text = "HOME"
            HomeForm.GunaButtonAccueil.Text = "HOME"
            HomeForm.GunaButtonMenuReception.Text = "RECEPTION"
            HomeForm.GunaButtonMenuReservation.Text = "BOOKING"
            HomeForm.GunaButtonReservation.Text = "BOOKING"
            HomeForm.GunaButtonMenuService.Text = "HOUSE KEEPING"
            HomeForm.GunaButtonServiceEtage.Text = "HOUSE KEEPING"
            HomeForm.GunaButtonCuisine.Text = "KITCHEN"
            HomeForm.GunaButtonMenuBarRestaurant.Text = "BAR / RESTAURANT"
            HomeForm.GunaButtonMenuComptabilite.Text = "ACCOUNTING"
            HomeForm.GunaButtonCompatbilite.Text = "ACCOUNTING AND FINANCE"
            HomeForm.GunaButtonMenuEconomat.Text = "PURCHASING"
            HomeForm.GunaButtonEconomat.Text = "PURCHASING"
            HomeForm.GunaButtonMenuTechnique.Text = "TECHNICAL"
            HomeForm.GunaLabel2.Text = "MODULES OF BARCLES HOTELSOFT"
            HomeForm.GunaAdvenceButtonLectureDeCarte.Text = "READ CARD"

            '------------------------------------------------------------------
            HomeForm.GunaButton7.Text = "DASHBOARD"
            HomeForm.GunaButton8.Text = "PLANNING"
            HomeForm.GunaButton9.Text = "IN HOUSE"
            HomeForm.GunaButton10.Text = "DEPARTURES"
            HomeForm.GunaButton11.Text = "ASSIGN ROOM"
            HomeForm.GunaButton12.Text = "ASSIGN ROOM"
            HomeForm.GunaButton33.Text = "INSTRUCTIONS BOOK"

            '------------------------------------------
            HomeForm.GunaButton21.Text = "CARDEX"
            HomeForm.GunaButton22.Text = "SEARCH"
            HomeForm.GunaButton6.Text = "NEW BOOKING"
            HomeForm.GunaButton23.Text = "MODIFY BOOKING"
            HomeForm.GunaButton24.Text = "AVAILABILITY AND RATES"
            HomeForm.GunaButton25.Text = "REPORTS"

            '------------------------------------------
            HomeForm.GunaButton31.Text = "CLEANING"
            HomeForm.GunaButton30.Text = "PLANNING"
            HomeForm.GunaButton29.Text = "ROOM STATE"
            HomeForm.GunaButton37.Text = "HISTORY"
            HomeForm.GunaButton38.Text = "OUT OF ORDER"
            HomeForm.GunaButton39.Text = "LOST / FOUND OBJECTS"
            HomeForm.GunaButton40.Text = "ROOM STATUS"

            '------------------------------------------
            HomeForm.GunaButton5.Text = "IN HOUSE"
            HomeForm.GunaButton26.Text = "WALK IN"
            HomeForm.GunaButton27.Text = "EVENTS"
            HomeForm.GunaButton34.Text = "RECEIPT MANAGEMENT"
            HomeForm.GunaButton41.Text = "REQUISITION"
            HomeForm.GunaButton42.Text = "PETTY CASH FLOAT"
            HomeForm.GunaButton43.Text = "REPORTS"

            '------------------------------------------
            HomeForm.GunaButton17.Text = "ORDER"
            HomeForm.GunaButton18.Text = "TECHNICAL SHEET"
            HomeForm.GunaButton19.Text = "RECEIPT"
            HomeForm.GunaButton20.Text = "VOUCHER LIST"
            HomeForm.GunaButton36.Text = "VENDORS"
            HomeForm.GunaButton50.Text = "STORES"
            HomeForm.GunaButton51.Text = "REPORTS"

            '------------------------------------------
            HomeForm.GunaButton13.Text = "ACCOUNTS"
            HomeForm.GunaButton14.Text = "REGULATIONS & LETTERING"
            HomeForm.GunaButton15.Text = "AGED BILLS"
            HomeForm.GunaButton16.Text = "BILLS"
            HomeForm.GunaButton35.Text = "RELAUNCH"
            HomeForm.GunaButton49.Text = "BAIL"
            HomeForm.GunaButton48.Text = "CAISSE"
            HomeForm.GunaButtonChoixProfil.Text = "PROFILS"

        ElseIf ActualLanguageValue = 1 Then

            HomeForm.GunaButtonAccueil1.Text = "ACCUEIL"
            HomeForm.GunaButtonMenuReception.Text = "ACCUEIL"
            HomeForm.GunaButtonMenuReception.Text = "RECEPTION"
            HomeForm.GunaButtonMenuReservation.Text = "RESERVATION"
            HomeForm.GunaButtonReservation.Text = "RESERVATION"
            HomeForm.GunaButtonMenuService.Text = "SERVICE ETAGE"
            HomeForm.GunaButtonServiceEtage.Text = "SERVICE ETAGE"
            HomeForm.GunaButtonCuisine.Text = "CUISINE"
            HomeForm.GunaButtonMenuBarRestaurant.Text = "BAR / RESTAURANT"
            HomeForm.GunaButtonMenuComptabilite.Text = "COMPTABILITE"
            HomeForm.GunaButtonCompatbilite.Text = "COMPTABILITE ET FINANCES"
            HomeForm.GunaButtonMenuEconomat.Text = "ECONOMAT"
            HomeForm.GunaButtonEconomat.Text = "ECONOMAT"
            HomeForm.GunaButtonMenuTechnique.Text = "TECHNIQUE"
            HomeForm.GunaLabel2.Text = "MODULES DE BARCLES HOTELSOFT"
            HomeForm.GunaAdvenceButtonLectureDeCarte.Text = "LIRE CARTE"

            '------------------------------------------------------------------
            HomeForm.GunaButton7.Text = "TABLEAU DE BORDS"
            HomeForm.GunaButton8.Text = "PLANNING"
            HomeForm.GunaButton9.Text = "EN CHAMBRE"
            HomeForm.GunaButton10.Text = "DEPARTS"
            HomeForm.GunaButton11.Text = "ATTRIBUER CHAMBRE"
            HomeForm.GunaButton12.Text = "PETITE CAISSE"
            HomeForm.GunaButton33.Text = "CAHIER DES CONSIGNES"

            '------------------------------------------
            HomeForm.GunaButton21.Text = "CARDEX"
            HomeForm.GunaButton22.Text = "RECHERCHER"
            HomeForm.GunaButton6.Text = "NOUVELLE RESERVATION"
            HomeForm.GunaButton23.Text = "MODIFIER RESERVATION"
            HomeForm.GunaButton24.Text = "DISPONIBILITE ET TARIFS"
            HomeForm.GunaButton25.Text = "RAPPORTS"

            '------------------------------------------
            HomeForm.GunaButton31.Text = "NETTOYAGE"
            HomeForm.GunaButton30.Text = "PLANNING"
            HomeForm.GunaButton29.Text = "ETATS DES CHAMBRES"
            HomeForm.GunaButton37.Text = "HISTORIQUES"
            HomeForm.GunaButton38.Text = "HORS SERVICES"
            HomeForm.GunaButton39.Text = "OBJETS TROUVES / PERDUS"
            HomeForm.GunaButton40.Text = "STATUTS DES CHAMBRES"

            '------------------------------------------
            HomeForm.GunaButton5.Text = "EN CHAMBRE"
            HomeForm.GunaButton26.Text = "COMPTOIR"
            HomeForm.GunaButton27.Text = "EVENEMENTIEL"
            HomeForm.GunaButton34.Text = "GESTION DES BLOC NOTES"
            HomeForm.GunaButton41.Text = "APPROVISIONNEMENT"
            HomeForm.GunaButton42.Text = "PETITE CAISSE"
            HomeForm.GunaButton43.Text = "RAPPORTS"

            '------------------------------------------
            HomeForm.GunaButton17.Text = "COMMANDE"
            HomeForm.GunaButton18.Text = "FICHE TECHNIQUE"
            HomeForm.GunaButton19.Text = "BON DE RECEPTION"
            HomeForm.GunaButton20.Text = "LISTE DES BONS"
            HomeForm.GunaButton36.Text = "FOURNISSEURS"
            HomeForm.GunaButton50.Text = "MAGASINS"
            HomeForm.GunaButton51.Text = "RAPPORTS"

            '------------------------------------------
            HomeForm.GunaButton13.Text = "COMPTES"
            HomeForm.GunaButton14.Text = "REGLEMENTS ET LETTRAGE"
            HomeForm.GunaButton15.Text = "FACTURES AGEES"
            HomeForm.GunaButton16.Text = "FACTURES"
            HomeForm.GunaButton35.Text = "RELANCES"
            HomeForm.GunaButton49.Text = "CAUTION"
            HomeForm.GunaButton48.Text = "CAISSE"

        End If

    End Sub


    Public Sub activation(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then

            ActivationForm.GunaLabelTitre.Text = "ACTIVATION OF HOTEL SOFT BY BARCLES"
            ActivationForm.GunaButtonActiver.Text = "ACTIVATE"

        ElseIf ActualLanguageValue = 1 Then

            ActivationForm.GunaLabelTitre.Text = "ACTIVATION DE HOTEL SOFT PAR BARCLES"
            ActivationForm.GunaButtonActiver.Text = "ACTIVER"

        End If

    End Sub

    Public Sub agency(ByVal ActualLanguageValue As Integer)

        AgencyForm.GunaComboBoxHotel.Items.Clear()

        If ActualLanguageValue = 0 Then
            AgencyForm.GunaComboBoxHotel.Items.Add("HOTEL")
            AgencyForm.GunaComboBoxHotel.Items.Add("RESTAURANT")
            'AgencyForm.GunaComboBoxHotel.Items.Add("CAR RENTAL")
        Else
            AgencyForm.GunaComboBoxHotel.Items.Add("HOTEL")
            AgencyForm.GunaComboBoxHotel.Items.Add("RESTAURANT")
            'AgencyForm.GunaComboBoxHotel.Items.Add("LOCATION VEHICULE")
        End If

        If ActualLanguageValue = 0 Then

            AgencyForm.GunaLabel53.Text = "CheckIn Elite Club Message"
            AgencyForm.GunaLabel62.Text = "Visit Max Time"
            AgencyForm.LinkLabel1.Text = "SETTINGS"
            AgencyForm.GunaLabel41.Text = "Letter Head"
            AgencyForm.GunaLabel54.Text = "External Link"
            AgencyForm.GunaLabelGestCompany.Text = "MANAGEMENT OF COMPANY AGENCIES"
            AgencyForm.GunaButtonSecondSave.Text = "Update"
            AgencyForm.GunaCheckBoxBlocNoteAuto.Text = "AUTOMATIC RECEIPT NUMBER"
            AgencyForm.GunaLabel54.Text = "External Link"
            AgencyForm.GunaCheckBoxClotureFacture.Text = "CLOSE CLIENT BILLS"
            AgencyForm.GunaCheckBoxInverserSigne.Text = "REMOVE SIGNS ON BILLS"
            AgencyForm.GunaCheckBoxConfigs.Text = "SETTINGS"
            AgencyForm.GunaCheckBoxReducFacture.Text = "GLOBAL DISCOUNT ON BILLS"

            AgencyForm.TabControl1.TabPages(0).Text = "Agency Address"
            AgencyForm.TabControl1.TabPages(1).Text = "Network Address"
            AgencyForm.TabControl1.TabPages(2).Text = "List of Agencies"
            AgencyForm.TabControl1.TabPages(3).Text = "Header / Footer"
            AgencyForm.TabControl1.TabPages(4).Text = "Contacts"
            AgencyForm.TabControl1.TabPages(6).Text = "Fonctionalities"

            '-------------------------------
            AgencyForm.GunaGroupBox1.Text = "Agency Information"
            AgencyForm.GunaLabel2.Text = "Agency N°"
            AgencyForm.GunaLabel32.Text = "Agency Name"
            AgencyForm.GunaLabel4.Text = "P.O Box"
            AgencyForm.GunaLabel5.Text = "Town"
            AgencyForm.GunaLabel6.Text = "Country"
            AgencyForm.GunaLabel1.Text = "Phone"
            AgencyForm.GunaLabel8.Text = "Street"
            AgencyForm.GunaLabel33.Text = "Hotel Category"
            AgencyForm.GunaLabel31.Text = "Automatic Save Path"
            AgencyForm.GunaButtonFermer.Text = "Close"
            AgencyForm.GunaButtonEnregistrer.Text = "Add"
            AgencyForm.GunaCheckBoxSessionUniqueAuBar.Text = "SINGLE SESSION"
            AgencyForm.GunaCheckBoxAthoriserClotureMultiple.Text = "GRANT MULTIPLE CLOSURE"
            AgencyForm.RadioButtonGererStock.Text = "STOCK MANAGEMENT"
            AgencyForm.GunaCheckBoxTarificationDynamique.Text = "DYNAMIC PRICING"

            '-------------------------------
            AgencyForm.GunaButton2.Text = "View"
            AgencyForm.GunaButton1.Text = "Print"

            '-------------------------------
            AgencyForm.GunaLabel9.Text = "HEADER"
            AgencyForm.GunaLabel20.Text = "FOOTER"
            AgencyForm.GunaLabel24.Text = "LEFT CORNER"
            AgencyForm.GunaLabel25.Text = "RIGHT CORNER"
            AgencyForm.GunaButtonCoinGauche.Text = "UPLOAD LOGO"
            AgencyForm.GunaButtonCoinDroit.Text = "UPLOAD LOGO"
            AgencyForm.GunaButtonEnregistrerEnTete.Text = "Register"
            AgencyForm.GunaLabel10.Text = "Line 1"
            AgencyForm.GunaLabel17.Text = "Line 2"
            AgencyForm.GunaLabel18.Text = "Line 3"
            AgencyForm.GunaLabel19.Text = "Line 4"
            AgencyForm.GunaLabel21.Text = "Line 1"
            AgencyForm.GunaLabel22.Text = "Line 2"
            AgencyForm.GunaLabel23.Text = "Line 3"

            '-------------------------------------
            AgencyForm.GunaLabel34.Text = "PURCHASE : "
            AgencyForm.GunaLabel36.Text = "ACCOUNTANT : "
            AgencyForm.GunaLabel37.Text = "CONTROLER : "
            AgencyForm.GunaLabel27.Text = "GD : "
            AgencyForm.GunaLabel40.Text = "BGD : "

            AgencyForm.GunaCheckBoxSerrure.Text = "LOCKS"

            AgencyForm.SupprimerToolStripMenuItem.Text = "Delete"

            AgencyForm.GunaLabel46.Text = "Languages"

            AgencyForm.GunaCheckBoxBloquerPrixHebergement.Text = "BLOCK ACCOMMODATION PRICE"
            AgencyForm.GunaCheckBoxPayerAvantEncodage.Text = "PAY BEFORE ISSUE CARD"

            AgencyForm.GunaCheckBoxClubElite.Text = "ELITE CLUB"
            AgencyForm.GunaCheckBoxImprimerB7.Text = "PRINT RECEIPT ON B7"
            AgencyForm.GunaButton4.Text = "Save"

        ElseIf ActualLanguageValue = 1 Then

            AgencyForm.GunaCheckBoxClotureFacture.Text = "CLOTURE DES FACTURES CLIENTS"

            AgencyForm.GunaLabelGestCompany.Text = "GESTION DES AGENCES DE LA SOCIETE"
            AgencyForm.TabControl1.TabPages(0).Text = "Adresse Agence"
            AgencyForm.TabControl1.TabPages(1).Text = "Adresse Réseau"
            AgencyForm.TabControl1.TabPages(2).Text = "Liste des Agences"
            AgencyForm.TabControl1.TabPages(3).Text = "Entête / Pieds de Page"
            AgencyForm.TabControl1.TabPages(4).Text = "Contacts"

            '-------------------------------
            AgencyForm.GunaGroupBox1.Text = "Information d'Agence"
            AgencyForm.GunaLabel2.Text = "N° Agence"
            AgencyForm.GunaLabel32.Text = "Nom Agence"
            AgencyForm.GunaLabel4.Text = "Boite Postale"
            AgencyForm.GunaLabel5.Text = "Ville"
            AgencyForm.GunaLabel6.Text = "Pays"
            AgencyForm.GunaLabel1.Text = "Téléphone"
            AgencyForm.GunaLabel8.Text = "Rue"
            AgencyForm.GunaLabel33.Text = "Catégorie Hôtel"
            AgencyForm.GunaLabel31.Text = "Chemin de Sauvegarde Automatique"
            AgencyForm.GunaButtonFermer.Text = "Fermer"
            AgencyForm.GunaButtonEnregistrer.Text = "Enregistrer"
            AgencyForm.GunaCheckBoxSessionUniqueAuBar.Text = "SESSION UNIQUE AU BAR"
            AgencyForm.GunaCheckBoxAthoriserClotureMultiple.Text = "AUTHORISER CLOTURE MULTIPLE"
            AgencyForm.RadioButtonGererStock.Text = "GERER STOCK"
            AgencyForm.GunaCheckBoxTarificationDynamique.Text = "TARIFICATION DYNAMIQUE"

            '-------------------------------
            AgencyForm.GunaButton2.Text = "Afficher"
            AgencyForm.GunaButton1.Text = "Imprimer"

            '-------------------------------
            AgencyForm.GunaLabel9.Text = "EN TETE"
            AgencyForm.GunaLabel20.Text = "PIEDS DE PAGE"
            AgencyForm.GunaLabel24.Text = "COIN GAUCHE"
            AgencyForm.GunaLabel25.Text = "COIN DROIT"
            AgencyForm.GunaButtonCoinGauche.Text = "UPLOAD LOGO"
            AgencyForm.GunaButtonCoinDroit.Text = "UPLOAD LOGO"
            AgencyForm.GunaButtonEnregistrerEnTete.Text = "Enregistrer"
            AgencyForm.GunaLabel10.Text = "Ligne 1"
            AgencyForm.GunaLabel17.Text = "Ligne 2"
            AgencyForm.GunaLabel18.Text = "Ligne 3"
            AgencyForm.GunaLabel19.Text = "Ligne 4"
            AgencyForm.GunaLabel21.Text = "Ligne 1"
            AgencyForm.GunaLabel22.Text = "Ligne 2"
            AgencyForm.GunaLabel23.Text = "Ligne 3"

            '-------------------------------------
            AgencyForm.GunaLabel34.Text = "ECONOM : "
            AgencyForm.GunaLabel36.Text = "COMPTABLE : "
            AgencyForm.GunaLabel37.Text = "CONTROLEUR : "
            AgencyForm.GunaLabel27.Text = "DG : "
            AgencyForm.GunaLabel40.Text = "PDG : "

            AgencyForm.GunaCheckBoxSerrure.Text = "SERRURES"

            AgencyForm.SupprimerToolStripMenuItem.Text = "Supprimer"

            AgencyForm.GunaLabel46.Text = "Langue"

            AgencyForm.GunaCheckBoxBloquerPrixHebergement.Text = "BLOQUER PRIX HEBERGEMENT"
            AgencyForm.GunaCheckBoxPayerAvantEncodage.Text = "PAYER AVANT ENCODAGE"
            AgencyForm.GunaCheckBoxClubElite.Text = "CLUB ELITE"
            AgencyForm.GunaCheckBoxImprimerB7.Text = "IMPRIMER RECU B7"

        End If

    End Sub

    Public Sub changePassword(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            ChangePasswordForm.GunaButtonEnregistrer.Text = "Save"
            ChangePasswordForm.GunaButton3.Text = "Cancel"
            ChangePasswordForm.GunaLabel2.Text = "user"
            ChangePasswordForm.GunaLabel3.Text = "Old Password"
            ChangePasswordForm.GunaLabel4.Text = "New Password"
            ChangePasswordForm.GunaLabel5.Text = "Confirm Password"
            ChangePasswordForm.GunaLabelGestUsers.Text = "Change Password"

        ElseIf ActualLanguageValue = 1 Then
            ChangePasswordForm.GunaButtonEnregistrer.Text = "Enregistrer"
            ChangePasswordForm.GunaButton3.Text = "Annuler"
            ChangePasswordForm.GunaLabel2.Text = "Utilsiateur"
            ChangePasswordForm.GunaLabel3.Text = "Ancien Mot de Passe"
            ChangePasswordForm.GunaLabel4.Text = "Nouveau Mot de Passe"
            ChangePasswordForm.GunaLabel5.Text = "Confirmer Mot de Passe"
            ChangePasswordForm.GunaLabelGestUsers.Text = "Changement du Mot de Passe"
        End If

    End Sub

    Public Sub autoloadShift(ByVal ActualLanguageValue As Integer)

        ChoixDuMagasinForm.GunaComboBoxShift.Items.Clear()

        If ActualLanguageValue = 0 Then
            ChoixDuMagasinForm.GunaComboBoxShift.Items.Add("Morning Shift")
            ChoixDuMagasinForm.GunaComboBoxShift.Items.Add("Afternoon Shift")
            ChoixDuMagasinForm.GunaComboBoxShift.Items.Add("Evening Shift")
        Else
            ChoixDuMagasinForm.GunaComboBoxShift.Items.Add("Shift du Matin")
            ChoixDuMagasinForm.GunaComboBoxShift.Items.Add("Shift du Soir")
            ChoixDuMagasinForm.GunaComboBoxShift.Items.Add("Shift de Nuit")
        End If

    End Sub

    Public Sub choixDuMagasin(ByVal ActualLanguageValue As Integer)

        autoloadShift(ActualLanguageValue)

        If ActualLanguageValue = 0 Then
            ChoixDuMagasinForm.GunaLabel1.Text = "Working Store"
            ChoixDuMagasinForm.GunaButtonOuvrirSession.Text = "Save"
            ChoixDuMagasinForm.GunaButton1.Text = "Close"
            ChoixDuMagasinForm.GunaLabel2.Text = "Shift"
        ElseIf ActualLanguageValue = 1 Then
            ChoixDuMagasinForm.GunaLabel1.Text = "Choisir le Magasin de Travail"
            ChoixDuMagasinForm.GunaButtonOuvrirSession.Text = "Enregistrer"
        End If

    End Sub

    Public Sub cahierDeConsigne(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            CahierDeConsigneForm.GunaButtonSupprimerConsigne.Text = "DELETE"
            CahierDeConsigneForm.GunaButtonNouvelle.Text = "NEW"
            CahierDeConsigneForm.GroupBoxFiltre.Text = "Filters"
            CahierDeConsigneForm.GunaCheckBoxFait.Text = "Donne"
            CahierDeConsigneForm.GunaButtonValiderConsigne.Text = "Donne"
            CahierDeConsigneForm.GunaLabel3.Text = "From"
            CahierDeConsigneForm.GunaLabel4.Text = "To"
            CahierDeConsigneForm.GunaButtonFiltrer.Text = "Filter"
            CahierDeConsigneForm.GunaLabelTitreDeLaFenetre.Text = "INSTRUCTIONS BOOK"
            CahierDeConsigneForm.GunaButtonComment.Text = "Comment"
        ElseIf ActualLanguageValue = 1 Then
            CahierDeConsigneForm.GunaButtonSupprimerConsigne.Text = "SUPPRIMER"
            CahierDeConsigneForm.GunaButtonNouvelle.Text = "NOUVELLE"
            CahierDeConsigneForm.GroupBoxFiltre.Text = "Filtres"
            CahierDeConsigneForm.GunaCheckBoxFait.Text = "Faite"
            CahierDeConsigneForm.GunaButtonValiderConsigne.Text = "Faite"
            CahierDeConsigneForm.GunaLabel3.Text = "Date Début"
            CahierDeConsigneForm.GunaLabel4.Text = "Date Fin"
            CahierDeConsigneForm.GunaButtonFiltrer.Text = "Filtrer"
            CahierDeConsigneForm.GunaLabelTitreDeLaFenetre.Text = "CAHIER DES CONSIGNES"
            CahierDeConsigneForm.GunaButtonComment.Text = "Commenter"
        End If

    End Sub

    Public Sub ajouterConsigne(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then

            If GlobalVariable.AjouterConsigneFormRole = "Nouvelle" Then
                AjouterConsigneForm.GunaLabel1.Text = "TYPE AN INSTRUCTION :"
            Else
                AjouterConsigneForm.GunaLabel1.Text = "TYPE A COMMENT :"
            End If

            AjouterConsigneForm.GunaButtonLectureDeCarte.Text = "Close"
            AjouterConsigneForm.GunaButtonAjouterConsigne.Text = "Add"

        ElseIf ActualLanguageValue = 1 Then

            If GlobalVariable.AjouterConsigneFormRole = "Nouvelle" Then
                AjouterConsigneForm.GunaLabel1.Text = "SAISIR UNE CONSIGNE :"
            Else
                AjouterConsigneForm.GunaLabel1.Text = "SAISIR UN COMMENTAIRE :"
            End If

            AjouterConsigneForm.GunaButtonLectureDeCarte.Text = "Fermer"
            AjouterConsigneForm.GunaButtonAjouterConsigne.Text = "Ajouter"

        End If

    End Sub

    Public Sub articleFamily(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then

            If GlobalVariable.typeFamilleOuSousFamille = "famille" Then  'POINT DE VENTE

                ArticleFamilyForm.GunaLabelGestCompteGeneraux.Text = "SALE POINTS MANAGEMENT"

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then 'CATEGORIE Then

                ArticleFamilyForm.GunaLabelGestCompteGeneraux.Text = "MANAGEMENT OF ITEM CATEGORIES"

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then 'FAMILLE

                ArticleFamilyForm.GunaLabelCategorie.Text = "Item Category"
                ArticleFamilyForm.GunaLabelGestCompteGeneraux.Text = "MANAGEMENT OF ITEM FAMILY"

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then 'SOUS FAMILLE

                ArticleFamilyForm.GunaLabelCategorie.Text = "Item Category"
                ArticleFamilyForm.GunaLabelFamilleArticle.Text = "Item Family"

                ArticleFamilyForm.GunaLabelGestCompteGeneraux.Text = "MANAGEMENT OF ITEMS SUB FAMILY"

            End If

            ArticleFamilyForm.TabControl1.TabPages(0).Text = "Description"
            ArticleFamilyForm.TabControl1.TabPages(1).Text = "List"
            ArticleFamilyForm.GunaLabel11.Text = "Code"
            ArticleFamilyForm.GunaLabel4.Text = "Wording"
            ArticleFamilyForm.GunaLabel2.Text = "Description"
            ArticleFamilyForm.GunaButton1.Text = "Cancel"
            ArticleFamilyForm.GunaButtonEnregistrer.Text = "Add"
            ArticleFamilyForm.GunaButtonAfficher.Text = "View"
            ArticleFamilyForm.SupprimerToolStripMenuItem.Text = "Delete"

        ElseIf ActualLanguageValue = 1 Then

            If GlobalVariable.typeFamilleOuSousFamille = "famille" Then  'POINT DE VENTE

                ArticleFamilyForm.GunaLabelGestCompteGeneraux.Text = "GESTION DES POINTS DE VENTES"

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then 'CATEGORIE Then

                ArticleFamilyForm.GunaLabelGestCompteGeneraux.Text = "GESTION DES CATEGORIES D'ARTICLE"

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then 'FAMILLE

                ArticleFamilyForm.GunaLabelCategorie.Text = "Catégorie d'Article"
                ArticleFamilyForm.GunaLabelGestCompteGeneraux.Text = "GESTION DES FAMILLES D'ARTICLE"

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then 'SOUS FAMILLE

                ArticleFamilyForm.GunaLabelCategorie.Text = "Catégorie d'Article"
                ArticleFamilyForm.GunaLabelFamilleArticle.Text = "Famille d'Article"

                ArticleFamilyForm.GunaLabelGestCompteGeneraux.Text = "GESTION DES SOUS FAMILLES D'ARTICLE"

            End If

            ArticleFamilyForm.GunaButtonAfficher.Text = "Afficher"
            ArticleFamilyForm.TabControl1.TabPages(0).Text = "Description"
            ArticleFamilyForm.TabControl1.TabPages(1).Text = "Liste"
            ArticleFamilyForm.GunaLabel11.Text = "Code"
            ArticleFamilyForm.GunaLabel4.Text = "Libellé"
            ArticleFamilyForm.GunaLabel2.Text = "Description"
            ArticleFamilyForm.GunaButton1.Text = "Annuler"
            ArticleFamilyForm.GunaButtonEnregistrer.Text = "Enregistrer"
            ArticleFamilyForm.SupprimerToolStripMenuItem.Text = "Supprimer"

        End If

    End Sub

    Public Sub articlePrepareeVisualisation(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            ArticlePrepareeVisualisationForm.GunaLabelTitle.Text = "PREPARED ITEMS"
            ArticlePrepareeVisualisationForm.SupprimerToolStripMenuItem1.Text = "Delete"
        ElseIf ActualLanguageValue = 1 Then
            ArticlePrepareeVisualisationForm.GunaLabelTitle.Text = "ARTICLE(S) PREPARE(S)"
            ArticlePrepareeVisualisationForm.SupprimerToolStripMenuItem1.Text = "Supprimer"
        End If

    End Sub

    Public Sub banque(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            BankForm.GunaLabelGestCompteGeneraux.Text = "BANK LIST"
            BankForm.SupprimerToolStripMenuItem.Text = "Delete"
            BankForm.GunaButton1.Text = "Close"
            BankForm.GunaButtonEnregistrerBanque.Text = "Add"
            BankForm.GunaLabel3.Text = "Bank Name"
            BankForm.GunaLabel5.Text = "Account Number"
            BankForm.GunaLabel4.Text = "Address"
            BankForm.GunaLabel6.Text = "Telephone"
            BankForm.GunaLabel7.Text = "Fax"
            BankForm.GunaLabel8.Text = "E-Mail"
            BankForm.TabControl1.TabPages(0).Text = "Description"
            BankForm.TabControl1.TabPages(1).Text = "List"
        ElseIf ActualLanguageValue = 1 Then
            BankForm.GunaLabelGestCompteGeneraux.Text = "LISTE DES BANQUES"
            BankForm.SupprimerToolStripMenuItem.Text = "Supprimer"
            BankForm.GunaButton1.Text = "Fermer"
            BankForm.GunaButtonEnregistrerBanque.Text = "Enregistrer"
            BankForm.GunaLabel3.Text = "Nom de la Banque"
            BankForm.GunaLabel5.Text = "Numéro de Compte"
            BankForm.GunaLabel4.Text = "Adresse"
            BankForm.GunaLabel6.Text = "Téléphone"
            BankForm.GunaLabel7.Text = "Fax"
            BankForm.GunaLabel8.Text = "E-Mail"
            BankForm.TabControl1.TabPages(0).Text = "Description"
            BankForm.TabControl1.TabPages(1).Text = "Liste"
        End If

    End Sub

    Public Sub passwordVerification(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then ' 
            passwordVerifivationForm.GunaLabel4.Text = "Password"
            passwordVerifivationForm.GunaButtonEnregistrer.Text = "Open"
        ElseIf ActualLanguageValue = 1 Then
            passwordVerifivationForm.GunaLabel4.Text = "Mot de Passe"
            passwordVerifivationForm.GunaButtonEnregistrer.Text = "Ouvrir"
        End If

    End Sub


    Public Sub barRestaurantMini(ByVal ActualLanguageValue As Integer)

        BarRestaurantCaisseEnregistreuseForm.ClôturerToolStripMenuItem.Visible = False
        BarRestaurantCaisseEnregistreuseForm.ToolStripSeparatorCloture.Visible = False

        If ActualLanguageValue = 0 Then '

            'only up
            BarRestaurantCaisseEnregistreuseForm.GunaButton12.Text = "BAR DAILY INVENTORY FORM"
            BarRestaurantCaisseEnregistreuseForm.GunaButton1.Text = "STORE INVENTORY"
            BarRestaurantCaisseEnregistreuseForm.GunaButton2.Text = "SALES INVENTORYY"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonCaisseJournalier.Text = "SHIFT CASH REGISTER STATE"
            BarRestaurantCaisseEnregistreuseForm.GunaButton3.Text = "SALES VENTILATION FORM"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonVenteShift.Text = "SALES HISTORY - SHIFT"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonListePetitDejeuner.Text = "ENTITLED TO BREAKFAST"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonInventaire.Text = "INVENTORY FORM"
            BarRestaurantCaisseEnregistreuseForm.Label29.Text = "Receipt No"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItem2.Text = "Print"

            BarRestaurantCaisseEnregistreuseForm.GunaButtonCaisseGlobal.Text = "DAILY CASH REGISTER STATE"
            BarRestaurantCaisseEnregistreuseForm.GunaButton14.Text = "PERIODIC CASH REGISTER HISTORY"
            BarRestaurantCaisseEnregistreuseForm.GunaButton5.Text = "PETTY CASH FLOW HISTORY"

            '---------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonFacturationDesEnChambres.Text = "IN HOUSE"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonAuComptant.Text = "WALK IN"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonEvent.Text = "EVENT"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonGesBloc.Text = "RECEIPT MANAGEMENT"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonAppro.Text = "REQUISITION"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonPetiteCaisse.Text = "PETTY CASH"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonRapportBar.Text = "REPORTS"

            '---------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.Label21.Text = "WALK IN SALE"
            BarRestaurantCaisseEnregistreuseForm.Label22.Text = "IN HOUSE SALE"
            BarRestaurantCaisseEnregistreuseForm.Label2.Text = "FREE SALE"
            BarRestaurantCaisseEnregistreuseForm.Label4.Text = "TRANSFERED ACCOUNT"
            BarRestaurantCaisseEnregistreuseForm.Label24.Text = "TOTAL SALES"

            '--------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.GunaLabelHeader.Text = "WALK IN"
            BarRestaurantCaisseEnregistreuseForm.GunaCheckBoxChangeSecteur.Text = "Sale Points"
            BarRestaurantCaisseEnregistreuseForm.LabelRef.Text = "Account" 'Account
            BarRestaurantCaisseEnregistreuseForm.Label1.Text = "Loyal Client" 'Loyal customer
            BarRestaurantCaisseEnregistreuseForm.LabelBlocNoteOuTable.Text = "Table" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.GunaButtonFactures.Text = "Bills" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.GunaButtonNouveauBloc.Text = "Add" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.LibelleFacturation.Text = "BAR BILLING" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.LabelBlocNoteOuvert.Text = "OPENED RECEIPTS" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.LabelBlocNoteTraitee.Text = "CLOSED RECEIPTS"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonAjouterLigne.Text = "Add"
            BarRestaurantCaisseEnregistreuseForm.Label13.Text = "Montant TTC"
            BarRestaurantCaisseEnregistreuseForm.Label12.Text = "Unit Price"
            BarRestaurantCaisseEnregistreuseForm.Label11.Text = "Quantity"
            BarRestaurantCaisseEnregistreuseForm.Label10.Text = "Item"
            BarRestaurantCaisseEnregistreuseForm.Label19.Text = "Discount (%)"
            BarRestaurantCaisseEnregistreuseForm.Label25.Text = "Discount"
            BarRestaurantCaisseEnregistreuseForm.Label8.Text = "Amount"
            BarRestaurantCaisseEnregistreuseForm.GunaCheckBoxLecteurRFID.Text = "RFID Reader" 'RFDI Reader
            BarRestaurantCaisseEnregistreuseForm.Label20.Text = "Stock Magasin"
            BarRestaurantCaisseEnregistreuseForm.Label23.Text = "Stock Economat"
            BarRestaurantCaisseEnregistreuseForm.Label6.Text = "Account Balance"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonRefresh.Text = "Refresh"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonSaveFacturation.Text = "Save"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonImprimer.Text = "Print"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonnNouvelleFacture.Text = "New"
            BarRestaurantCaisseEnregistreuseForm.Label9.Text = "EVENTS"
            BarRestaurantCaisseEnregistreuseForm.LabelSoldeEvent.Text = "BALANCE"
            BarRestaurantCaisseEnregistreuseForm.LabelNumeroChambre.Text = "Room N°"
            BarRestaurantCaisseEnregistreuseForm.Label5.Text = "BALANCE"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonLectureDeCarte.Text = "READ CARD"

            '--------------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.GunaGroupBox1.Text = "SEARCH"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel86.Text = "RECEIPT NUMBER"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonArricherBlocNotes.Text = "Afficher"
            BarRestaurantCaisseEnregistreuseForm.GunaLabelListe.Text = "LISTE OF RECEIPTS"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel3.Text = "RECEIPTS DETAILS"
            BarRestaurantCaisseEnregistreuseForm.GunaGroupBoxCreationBordereau.Text = "Slip Creation"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonNouveau.Text = "New"
            BarRestaurantCaisseEnregistreuseForm.GunaGroupBoxListeDesBordereaux.Text = "Slip Content"
            BarRestaurantCaisseEnregistreuseForm.LabelBon.Text = "STORE REQUISITION"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel89.Text = "Voucher Type"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel93.Text = "Voucher Wording"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel97.Text = "Employee"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel91.Text = "Employee"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel92.Text = "Observation"
            BarRestaurantCaisseEnregistreuseForm.GunaLabelMagasinDeDestination.Text = "Receiving Store"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonAjouterLigneAppro.Text = "Add"
            BarRestaurantCaisseEnregistreuseForm.Label33.Text = "ITEM"
            BarRestaurantCaisseEnregistreuseForm.LabelQuantite.Text = "QTY"
            BarRestaurantCaisseEnregistreuseForm.LabelCout.Text = "UP"
            BarRestaurantCaisseEnregistreuseForm.Label30.Text = "UNIT"
            BarRestaurantCaisseEnregistreuseForm.Label31.Text = "Stock Qty "
            BarRestaurantCaisseEnregistreuseForm.Label32.Text = "Lowest"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonEnregistrer.Text = "Emit"
            BarRestaurantCaisseEnregistreuseForm.GunaCheckBox1.Text = "RFID Reader"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonImpressionDirecteAppro.Text = "Print"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonAccueil.Text = "Home"
            BarRestaurantCaisseEnregistreuseForm.Label26.Text = "PURCHASE AMOUNT"
            BarRestaurantCaisseEnregistreuseForm.Label28.Text = "SALE AMOUNT"

            BarRestaurantCaisseEnregistreuseForm.RetirerToolStripMenuItem.Text = "Remove"
            BarRestaurantCaisseEnregistreuseForm.ImprimerToolStripMenuItem.Text = "Print"
            BarRestaurantCaisseEnregistreuseForm.TransférerToolStripMenuItem.Text = "Transfert"
            BarRestaurantCaisseEnregistreuseForm.SupprimerToolStripMenuItem.Text = "Delete"
            BarRestaurantCaisseEnregistreuseForm.SupprimerToolStripMenuItem1.Text = "Delete"

            BarRestaurantCaisseEnregistreuseForm.GunaButtonArricherBlocNotes.Text = "View"
            BarRestaurantCaisseEnregistreuseForm.Label29Evenement.Text = "EVENT"

            '-----------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            BarRestaurantCaisseEnregistreuseForm.RESERVATIONToolStripMenuItem.Text = "BOOKING"
            BarRestaurantCaisseEnregistreuseForm.SERVICEDETAGEToolStripMenuItem.Text = "HOUSE KEEPING"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemCusine.Text = "KITCHEN"
            BarRestaurantCaisseEnregistreuseForm.ComptabilitéToolStripMenuItem.Text = "ACCOUNTING AND FINANCES"
            BarRestaurantCaisseEnregistreuseForm.ECONOMATToolStripMenuItem.Text = "PURCHASE"
            BarRestaurantCaisseEnregistreuseForm.TECHNIQUEToolStripMenuItem.Text = "TECHNICAL"

            '-----------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.SupprimerToolStripMenuItem2.Text = "Delete"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemSupLigneBlocNoteGestBlocNote.Text = "Delete"

            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemSession.Text = "SESSION"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItem117.Text = "Change password"
            BarRestaurantCaisseEnregistreuseForm.FermerCaisseToolStripMenuItem.Text = "Close cash Register"
            BarRestaurantCaisseEnregistreuseForm.PETITEToolStripMenuItem.Text = "Petty Cash Flow"
            BarRestaurantCaisseEnregistreuseForm.OuvrirCaisseToolStripMenuItem.Text = "Open Cash Register"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItem119.Text = "Close Session"

            BarRestaurantCaisseEnregistreuseForm.ChoisirMagasinDeTravailToolStripMenuItem.Text = "Change the working store"

            BarRestaurantCaisseEnregistreuseForm.TransférerToolStripMenuItem.Text = "Transfer"
            BarRestaurantCaisseEnregistreuseForm.SupprimerToolStripMenuItem2.Text = "Delete"
            BarRestaurantCaisseEnregistreuseForm.SupprimerToolStripMenuItem.Text = "Delete"
            BarRestaurantCaisseEnregistreuseForm.ImprimerToolStripMenuItem1.Text = "Print"
            BarRestaurantCaisseEnregistreuseForm.ImprimerToolStripMenuItem.Text = "Print"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItem1.Text = "Print"
            BarRestaurantCaisseEnregistreuseForm.Label3.Text = "Server"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonRapportDesVentes.Text = "DAILY SALES HISTORY"
            BarRestaurantCaisseEnregistreuseForm.GunaButton13.Text = "PERIODIC SALES HISTORY"

            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemConfig.Text = "SETTINGS"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemServTech.Text = "TECHNICAL"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemSecurite.Text = "SECURITY"

        ElseIf ActualLanguageValue = 1 Then

            '---------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonFacturationDesEnChambres.Text = "EN CHAMBRE"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonAuComptant.Text = "COMPTOIR"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonEvent.Text = "EVENEMENTIEL"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonGesBloc.Text = "GESTION DES BLOC NOTES"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonAppro.Text = "APPROVISIONNEMENT"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonPetiteCaisse.Text = "PETITE CAISSE"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonRapportBar.Text = "RAPPORTS"

            '---------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.Label21.Text = "VENTE COMPTOIR"
            BarRestaurantCaisseEnregistreuseForm.Label22.Text = "VENTE EN CHAMBRE"
            BarRestaurantCaisseEnregistreuseForm.Label2.Text = "OFFRES"
            BarRestaurantCaisseEnregistreuseForm.Label4.Text = "TRANSFERT COMPTE"
            BarRestaurantCaisseEnregistreuseForm.Label24.Text = "TOTAL VENTES"

            '--------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.GunaLabelHeader.Text = "COMPTOIR"
            BarRestaurantCaisseEnregistreuseForm.GunaCheckBoxChangeSecteur.Text = "Points de Vente"
            BarRestaurantCaisseEnregistreuseForm.LabelRef.Text = "Journal" 'Account
            BarRestaurantCaisseEnregistreuseForm.Label1.Text = "Clients maison" 'Loyal customer
            BarRestaurantCaisseEnregistreuseForm.LabelBlocNoteOuTable.Text = "Table" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.GunaButtonFactures.Text = "Factures" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.GunaButtonNouveauBloc.Text = "Ajouter" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.LibelleFacturation.Text = "FACTURATION BAR" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.LabelBlocNoteOuvert.Text = "BLOC NOTES EN COURS" 'Receipt Number
            BarRestaurantCaisseEnregistreuseForm.LabelBlocNoteTraitee.Text = "BLOC NOTES TRAITES"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonAjouterLigne.Text = "Ajouter"
            BarRestaurantCaisseEnregistreuseForm.Label13.Text = "Montant TTC"
            BarRestaurantCaisseEnregistreuseForm.Label12.Text = "Prix Unitaire"
            BarRestaurantCaisseEnregistreuseForm.Label11.Text = "Quantité"
            BarRestaurantCaisseEnregistreuseForm.Label10.Text = "Article"
            BarRestaurantCaisseEnregistreuseForm.Label19.Text = "Remise (%)"
            BarRestaurantCaisseEnregistreuseForm.Label25.Text = "Réduction"
            BarRestaurantCaisseEnregistreuseForm.Label8.Text = "Montant"
            BarRestaurantCaisseEnregistreuseForm.GunaCheckBoxLecteurRFID.Text = "Lecteur RFID" 'RFDI Reader
            BarRestaurantCaisseEnregistreuseForm.Label20.Text = "Stock Magasin"
            BarRestaurantCaisseEnregistreuseForm.Label23.Text = "Stock Economat"
            BarRestaurantCaisseEnregistreuseForm.Label6.Text = "Situation Caisse"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonRefresh.Text = "Rafrachir"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonSaveFacturation.Text = "Enregistrer"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonImprimer.Text = "Imprimer"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonnNouvelleFacture.Text = "Nouveau"
            BarRestaurantCaisseEnregistreuseForm.Label9.Text = "EVENEMENTS"
            BarRestaurantCaisseEnregistreuseForm.LabelSoldeEvent.Text = "SOLDE"
            BarRestaurantCaisseEnregistreuseForm.LabelNumeroChambre.Text = "Chambre N°"
            BarRestaurantCaisseEnregistreuseForm.Label5.Text = "SOLDE"
            BarRestaurantCaisseEnregistreuseForm.GunaAdvenceButtonLectureDeCarte.Text = "LIRE CARTE"
            BarRestaurantCaisseEnregistreuseForm.Label29Evenement.Text = "EVENEMENT"
            '--------------------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.GunaGroupBox1.Text = "RECHERCHER"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel86.Text = "NUMERO BLOC NOTE"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonArricherBlocNotes.Text = "Afficher"
            BarRestaurantCaisseEnregistreuseForm.GunaLabelListe.Text = "LISTE DES BLOC NOTES"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel3.Text = "DETAILS DES BLOCS NOTES"
            BarRestaurantCaisseEnregistreuseForm.GunaGroupBoxCreationBordereau.Text = "Création de Bordereau"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonNouveau.Text = "Nouveau"
            BarRestaurantCaisseEnregistreuseForm.GunaGroupBoxListeDesBordereaux.Text = "Contenu du bordereau"
            BarRestaurantCaisseEnregistreuseForm.LabelBon.Text = "APPROVISIONNEMENT"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel89.Text = "Type de bordereau"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel93.Text = "Libellé Bordereau"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel97.Text = "Employé"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel91.Text = "Employé"
            BarRestaurantCaisseEnregistreuseForm.GunaLabel92.Text = "Observation"
            BarRestaurantCaisseEnregistreuseForm.GunaLabelMagasinDeDestination.Text = "Magasin de Réception"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonAjouterLigneAppro.Text = "Ajouter"
            BarRestaurantCaisseEnregistreuseForm.Label33.Text = "ARTICLE"
            BarRestaurantCaisseEnregistreuseForm.LabelQuantite.Text = "QTE"
            BarRestaurantCaisseEnregistreuseForm.LabelCout.Text = "PU"
            BarRestaurantCaisseEnregistreuseForm.Label30.Text = "UNITE"
            BarRestaurantCaisseEnregistreuseForm.Label31.Text = "Qté En Stock"
            BarRestaurantCaisseEnregistreuseForm.Label32.Text = "Seuile"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonEnregistrer.Text = "Emettre"
            BarRestaurantCaisseEnregistreuseForm.GunaCheckBox1.Text = "Lecteur RFID"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonImpressionDirecteAppro.Text = "Imprimer"
            BarRestaurantCaisseEnregistreuseForm.GunaButtonAccueil.Text = "Accueil"
            BarRestaurantCaisseEnregistreuseForm.Label26.Text = "MONTANT ACHAT"
            BarRestaurantCaisseEnregistreuseForm.Label28.Text = "MONTANT VENTE"

            BarRestaurantCaisseEnregistreuseForm.RetirerToolStripMenuItem.Text = "Retirer"
            BarRestaurantCaisseEnregistreuseForm.ImprimerToolStripMenuItem.Text = "Imprimer"
            BarRestaurantCaisseEnregistreuseForm.TransférerToolStripMenuItem.Text = "Transférer"
            BarRestaurantCaisseEnregistreuseForm.SupprimerToolStripMenuItem.Text = "Supprimer"
            BarRestaurantCaisseEnregistreuseForm.SupprimerToolStripMenuItem1.Text = "Supprimer"

            BarRestaurantCaisseEnregistreuseForm.GunaButtonArricherBlocNotes.Text = "Afficher"

            '-----------------------------------------------------------------
            BarRestaurantCaisseEnregistreuseForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            BarRestaurantCaisseEnregistreuseForm.RESERVATIONToolStripMenuItem.Text = "RESERVATION"
            BarRestaurantCaisseEnregistreuseForm.SERVICEDETAGEToolStripMenuItem.Text = "SERVICE ETAGE"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemCusine.Text = "CUISINE"
            BarRestaurantCaisseEnregistreuseForm.ComptabilitéToolStripMenuItem.Text = "COMPATBILITE ET FINANCES"
            BarRestaurantCaisseEnregistreuseForm.ECONOMATToolStripMenuItem.Text = "ECONOMAT"
            BarRestaurantCaisseEnregistreuseForm.TECHNIQUEToolStripMenuItem.Text = "TECHNIQUE"

            BarRestaurantCaisseEnregistreuseForm.SupprimerToolStripMenuItem2.Text = "Supprimer"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemSupLigneBlocNoteGestBlocNote.Text = "Supprimer"

            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItemSession.Text = "SESSION"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItem117.Text = "Changer mot de passe"
            BarRestaurantCaisseEnregistreuseForm.FermerCaisseToolStripMenuItem.Text = "Fermer Caisse"
            BarRestaurantCaisseEnregistreuseForm.PETITEToolStripMenuItem.Text = "Petite Caisse"
            BarRestaurantCaisseEnregistreuseForm.OuvrirCaisseToolStripMenuItem.Text = "Ouvrir Caisse"
            BarRestaurantCaisseEnregistreuseForm.ToolStripMenuItem119.Text = "Fermer Session"
            BarRestaurantCaisseEnregistreuseForm.ChoisirMagasinDeTravailToolStripMenuItem.Text = "Choisir Magasin de Travail"

        End If

        autoLoadEmployeeMini(GlobalVariable.actualLanguageValue)

        autoLoadSlipTypeMini(GlobalVariable.actualLanguageValue)

    End Sub

    Public Sub autoLoadBIllState(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            FastFoodForm.GunaComboBoxCommandeStatus.Items.Clear()
            FastFoodForm.GunaComboBoxCommandeStatus.Items.Add("Pending Payment")
            FastFoodForm.GunaComboBoxCommandeStatus.Items.Add("Paid")
        End If

    End Sub

    Public Sub fastFood(ByVal ActualLanguageValue As Integer)

        FastFoodForm.ClôturerToolStripMenuItem.Visible = True
        FastFoodForm.ToolStripSeparatorCloture.Visible = False

        If ActualLanguageValue = 0 Then '

            FastFoodForm.Label21.Text = "SALES"
            FastFoodForm.Label2.Text = "CASH BALANCE"
            FastFoodForm.Label4.Text = "INTO ACCOUNT"
            FastFoodForm.Label24.Text = "TOTAL SALES"

            FastFoodForm.GunaLabel3.Text = "GIVEN OUT"
            FastFoodForm.GunaButtonAjouterLigne.Text = "Delivered"
            FastFoodForm.GunaLabel4.Text = "PENDING ITEMS"

            FastFoodForm.ToolStripMenuItemSession.Text = "SESSION"
            FastFoodForm.ToolStripMenuItem117.Text = "Change password"
            FastFoodForm.FermerCaisseToolStripMenuItem.Text = "Close cash Register"
            FastFoodForm.ClôturerToolStripMenuItem.Text = "Night Audit"
            FastFoodForm.OuvrirCaisseToolStripMenuItem.Text = "Open Cash Register"
            FastFoodForm.ToolStripMenuItem119.Text = "Close Session"

            FastFoodForm.GunaButton1.Text = "Refresh"
            FastFoodForm.ImprimerToolStripMenuItem.Text = "Print"
            FastFoodForm.ClôturerToolStripMenuItem1.Text = "Close"

        End If

        autoLoadBIllState(GlobalVariable.actualLanguageValue)

    End Sub

    Public Sub barRestaurant(ByVal ActualLanguageValue As Integer)

        BarRestaurantForm.ClôturerToolStripMenuItem.Visible = False
        BarRestaurantForm.ToolStripSeparatorCloture.Visible = False

        If ActualLanguageValue = 0 Then '
            'only up
            BarRestaurantForm.DépensesToolStripMenuItem.Text = "Expenditures"
            BarRestaurantForm.ToolStripMenuItemConfig.Text = "SETTINGS"
            BarRestaurantForm.ToolStripMenuItemServTech.Text = "TECHNICAL"
            BarRestaurantForm.ToolStripMenuItemSecurite.Text = "SECURITY"
            BarRestaurantForm.GunaButton12.Text = "BAR DAILY INVENTORY FORM"
            BarRestaurantForm.GunaButton12.Text = "BAR DAILY INVENTORY FORM"
            BarRestaurantForm.Label29.Text = "Receipt No"
            BarRestaurantForm.GunaButton1.Text = "STORE INVENTORY"
            BarRestaurantForm.GunaButton2.Text = "SALES INVENTORYY"
            BarRestaurantForm.GunaButtonCaisseJournalier.Text = "SHIFT CASH REGISTER STATE"
            BarRestaurantForm.GunaButton3.Text = "SALES VENTILATION FORM"
            BarRestaurantForm.GunaButtonVenteShift.Text = "SALES HISTORY - SHIFT"
            BarRestaurantForm.GunaButtonListePetitDejeuner.Text = "ENTITLED TO BREAKFAST"
            BarRestaurantForm.GunaButtonInventaire.Text = "INVENTORY FORM"
            BarRestaurantForm.GunaButtonCaisseGlobal.Text = "DAILY CASH REGISTER STATE"
            BarRestaurantForm.GunaButton14.Text = "PERIODIC CASH REGISTER HISTORY"
            BarRestaurantForm.GunaButton5.Text = "PETTY CASH FLOW HISTORY"
            BarRestaurantForm.ToolStripMenuItem2.Text = "Print"

            '---------------------------------------------------------------------
            BarRestaurantForm.GunaAdvenceButtonFacturationDesEnChambres.Text = "IN HOUSE"
            BarRestaurantForm.GunaAdvenceButtonAuComptant.Text = "WALK IN"
            BarRestaurantForm.GunaAdvenceButtonEvent.Text = "EVENT"
            BarRestaurantForm.GunaAdvenceButtonGesBloc.Text = "RECEIPT MANAGEMENT"
            BarRestaurantForm.GunaAdvenceButtonAppro.Text = "REQUISITION"
            BarRestaurantForm.GunaAdvenceButtonPetiteCaisse.Text = "PETTY CASH"
            BarRestaurantForm.GunaAdvenceButtonRapportBar.Text = "REPORTS"

            '---------------------------------------------------------------------
            BarRestaurantForm.Label21.Text = "WALK IN SALE"
            BarRestaurantForm.Label22.Text = "IN HOUSE SALE"
            BarRestaurantForm.Label2.Text = "FREE SALE"
            BarRestaurantForm.Label4.Text = "TRANSFERED ACCOUNT"
            BarRestaurantForm.Label24.Text = "TOTAL SALES"
            BarRestaurantForm.Label24.Text = "TOTAL SALES"
            BarRestaurantForm.Label3.Text = "Server"

            '--------------------------------------------------------------------
            BarRestaurantForm.GunaLabelHeader.Text = "WALK IN"
            BarRestaurantForm.GunaCheckBoxChangeSecteur.Text = "Sale Points"
            BarRestaurantForm.LabelRef.Text = "Account" 'Account
            BarRestaurantForm.Label1.Text = "Loyal Client" 'Loyal customer
            BarRestaurantForm.LabelBlocNoteOuTable.Text = "Table" 'Receipt Number
            BarRestaurantForm.GunaButtonFactures.Text = "Bills" 'Receipt Number
            BarRestaurantForm.GunaButtonNouveauBloc.Text = "Add" 'Receipt Number
            BarRestaurantForm.LibelleFacturation.Text = "BAR BILLING" 'Receipt Number
            BarRestaurantForm.LabelBlocNoteOuvert.Text = "OPENED RECEIPTS" 'Receipt Number
            BarRestaurantForm.LabelBlocNoteTraitee.Text = "CLOSED RECEIPTS"
            BarRestaurantForm.GunaButtonAjouterLigne.Text = "Add"
            BarRestaurantForm.Label13.Text = "Montant TTC"
            BarRestaurantForm.Label12.Text = "Unit Price"
            BarRestaurantForm.Label11.Text = "Quantity"
            BarRestaurantForm.Label10.Text = "Item"
            BarRestaurantForm.Label19.Text = "Discount (%)"
            BarRestaurantForm.Label25.Text = "Discount"
            BarRestaurantForm.Label8.Text = "Amount"
            BarRestaurantForm.GunaCheckBoxLecteurRFID.Text = "RFID Reader" 'RFDI Reader
            BarRestaurantForm.Label20.Text = "Stock Magasin"
            BarRestaurantForm.Label23.Text = "Stock Economat"
            BarRestaurantForm.Label6.Text = "Account Balance"
            BarRestaurantForm.GunaButtonRefresh.Text = "Refresh"
            BarRestaurantForm.GunaButtonSaveFacturation.Text = "Save"
            BarRestaurantForm.GunaButtonImprimer.Text = "Print Bill"
            BarRestaurantForm.GunaButtonnNouvelleFacture.Text = "New"
            BarRestaurantForm.Label9.Text = "EVENTS"
            BarRestaurantForm.LabelSoldeEvent.Text = "BALANCE"
            BarRestaurantForm.LabelNumeroChambre.Text = "Room N°"
            BarRestaurantForm.Label5.Text = "BALANCE"
            BarRestaurantForm.GunaAdvenceButtonLectureDeCarte.Text = "READ CARD"

            '--------------------------------------------------------------------------
            BarRestaurantForm.GunaGroupBox1.Text = "SEARCH"
            BarRestaurantForm.GunaLabel86.Text = "RECEIPT NUMBER"
            BarRestaurantForm.GunaButtonArricherBlocNotes.Text = "Afficher"
            BarRestaurantForm.GunaLabelListe.Text = "LISTE OF RECEIPTS"
            BarRestaurantForm.GunaLabel3.Text = "RECEIPTS DETAILS"
            BarRestaurantForm.GunaGroupBoxCreationBordereau.Text = "Slip Creation"
            BarRestaurantForm.GunaButtonNouveau.Text = "New"
            BarRestaurantForm.GunaGroupBoxListeDesBordereaux.Text = "Slip Content"
            BarRestaurantForm.LabelBon.Text = "STORE REQUISITION"
            BarRestaurantForm.GunaLabel89.Text = "Voucher Type"
            BarRestaurantForm.GunaLabel93.Text = "Voucher Wording"
            BarRestaurantForm.GunaLabel97.Text = "Employee"
            BarRestaurantForm.GunaLabel91.Text = "Employee"
            BarRestaurantForm.GunaLabel92.Text = "Observation"
            BarRestaurantForm.GunaLabelMagasinDeDestination.Text = "Receiving Store"
            BarRestaurantForm.GunaButtonAjouterLigneAppro.Text = "Add"
            BarRestaurantForm.Label33.Text = "ITEM"
            BarRestaurantForm.LabelQuantite.Text = "QTY"
            BarRestaurantForm.LabelCout.Text = "UP"
            BarRestaurantForm.Label30.Text = "UNIT"
            'BarRestaurantForm.Label31.Text = "Stock Qty "
            BarRestaurantForm.Label32.Text = "Lowest"
            BarRestaurantForm.GunaButtonEnregistrer.Text = "Emit"
            BarRestaurantForm.GunaCheckBox1.Text = "RFID Reader"
            BarRestaurantForm.GunaButtonImpressionDirecteAppro.Text = "Print"
            BarRestaurantForm.GunaButtonAccueil.Text = "Home"
            BarRestaurantForm.Label26.Text = "PURCHASE AMOUNT"
            BarRestaurantForm.Label28.Text = "SALE AMOUNT"

            BarRestaurantForm.RetirerToolStripMenuItem.Text = "Remove"
            BarRestaurantForm.ImprimerToolStripMenuItem.Text = "Print"
            BarRestaurantForm.TransférerToolStripMenuItem.Text = "Transfert"
            BarRestaurantForm.SupprimerToolStripMenuItem.Text = "Delete"
            BarRestaurantForm.SupprimerToolStripMenuItem1.Text = "Delete"
            BarRestaurantForm.EchangerToolStripMenuItem.Text = "Exchange"

            BarRestaurantForm.GunaButtonArricherBlocNotes.Text = "View"
            BarRestaurantForm.Label29Evenement.Text = "EVENT"

            '-----------------------------------------------------------------
            BarRestaurantForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            BarRestaurantForm.RESERVATIONToolStripMenuItem.Text = "BOOKING"
            BarRestaurantForm.SERVICEDETAGEToolStripMenuItem.Text = "HOUSE KEEPING"
            BarRestaurantForm.ToolStripMenuItemCusine.Text = "KITCHEN"
            BarRestaurantForm.ComptabilitéToolStripMenuItem.Text = "ACCOUNTING AND FINANCES"
            BarRestaurantForm.ECONOMATToolStripMenuItem.Text = "PURCHASE"
            BarRestaurantForm.TECHNIQUEToolStripMenuItem.Text = "TECHNICAL"

            '-----------------------------------------------------------------------
            BarRestaurantForm.SupprimerToolStripMenuItem2.Text = "Delete"
            BarRestaurantForm.ToolStripMenuItemSupLigneBlocNoteGestBlocNote.Text = "Delete"

            BarRestaurantForm.ToolStripMenuItemSession.Text = "SESSION"
            BarRestaurantForm.ToolStripMenuItem117.Text = "Change password"
            BarRestaurantForm.FermerCaisseToolStripMenuItem.Text = "Close cash Register"
            BarRestaurantForm.PETITEToolStripMenuItem.Text = "Petty Cash Flow"
            BarRestaurantForm.OuvrirCaisseToolStripMenuItem.Text = "Open Cash Register"
            BarRestaurantForm.ToolStripMenuItem119.Text = "Close Session"

            BarRestaurantForm.ChoisirMagasinDeTravailToolStripMenuItem.Text = "Change the working store"

            BarRestaurantForm.TransférerToolStripMenuItem.Text = "Transfer"
            BarRestaurantForm.SupprimerToolStripMenuItem2.Text = "Delete"
            BarRestaurantForm.SupprimerToolStripMenuItem.Text = "Delete"
            BarRestaurantForm.ImprimerToolStripMenuItem1.Text = "Print"
            BarRestaurantForm.ImprimerToolStripMenuItem.Text = "Print"
            BarRestaurantForm.ToolStripMenuItem1.Text = "Print"
            BarRestaurantForm.GunaButtonRapportDesVentes.Text = "DAILY SALES HISTORY"
            BarRestaurantForm.GunaButton13.Text = "PERIODIC SALES HISTORY"

            BarRestaurantForm.GunaButton4.Text = "SALES REVENUES BAR - RESTAURANT"
            BarRestaurantForm.GunaButton6.Text = "SALES REVENUES PER STAFF (WAITERS - WAITRESSES)"
            BarRestaurantForm.GunaButton7.Text = "SALES REVENUES GROUPED BY ISSUER"
            BarRestaurantForm.GunaButtonProductionReceptionnists.Text = "REPORT OF PRODUCTIVITY"

            BarRestaurantForm.GunaButton9.Text = "Consolidate"

            BarRestaurantForm.GunaButtonOnL.Text = "Online Order"

        ElseIf ActualLanguageValue = 1 Then

            BarRestaurantForm.GunaButtonOnL.Text = "Commande en Ligne"

            '---------------------------------------------------------------------
            BarRestaurantForm.GunaAdvenceButtonFacturationDesEnChambres.Text = "EN CHAMBRE"
            BarRestaurantForm.GunaAdvenceButtonAuComptant.Text = "COMPTOIR"
            BarRestaurantForm.GunaAdvenceButtonEvent.Text = "EVENEMENTIEL"
            BarRestaurantForm.GunaAdvenceButtonGesBloc.Text = "GESTION DES BLOC NOTES"
            BarRestaurantForm.GunaAdvenceButtonAppro.Text = "APPROVISIONNEMENT"
            BarRestaurantForm.GunaAdvenceButtonPetiteCaisse.Text = "PETITE CAISSE"
            BarRestaurantForm.GunaAdvenceButtonRapportBar.Text = "RAPPORTS"

            '---------------------------------------------------------------------
            BarRestaurantForm.Label21.Text = "VENTE COMPTOIR"
            BarRestaurantForm.Label22.Text = "VENTE EN CHAMBRE"
            BarRestaurantForm.Label2.Text = "OFFRES"
            BarRestaurantForm.Label4.Text = "TRANSFERT COMPTE"
            BarRestaurantForm.Label24.Text = "TOTAL VENTES"

            '--------------------------------------------------------------------
            BarRestaurantForm.GunaLabelHeader.Text = "COMPTOIR"
            BarRestaurantForm.GunaCheckBoxChangeSecteur.Text = "Points de Vente"
            BarRestaurantForm.LabelRef.Text = "Journal" 'Account
            BarRestaurantForm.Label1.Text = "Clients maison" 'Loyal customer
            BarRestaurantForm.LabelBlocNoteOuTable.Text = "Table" 'Receipt Number
            BarRestaurantForm.GunaButtonFactures.Text = "Factures" 'Receipt Number
            BarRestaurantForm.GunaButtonNouveauBloc.Text = "Ajouter" 'Receipt Number
            BarRestaurantForm.LibelleFacturation.Text = "FACTURATION BAR" 'Receipt Number
            BarRestaurantForm.LabelBlocNoteOuvert.Text = "BLOC NOTES EN COURS" 'Receipt Number
            BarRestaurantForm.LabelBlocNoteTraitee.Text = "BLOC NOTES TRAITES"
            BarRestaurantForm.GunaButtonAjouterLigne.Text = "Ajouter"
            BarRestaurantForm.Label13.Text = "Montant TTC"
            BarRestaurantForm.Label12.Text = "Prix Unitaire"
            BarRestaurantForm.Label11.Text = "Quantité"
            BarRestaurantForm.Label10.Text = "Article"
            BarRestaurantForm.Label19.Text = "Remise (%)"
            BarRestaurantForm.Label25.Text = "Réduction"
            BarRestaurantForm.Label8.Text = "Montant"
            BarRestaurantForm.GunaCheckBoxLecteurRFID.Text = "Lecteur RFID" 'RFDI Reader
            BarRestaurantForm.Label20.Text = "Stock Magasin"
            BarRestaurantForm.Label23.Text = "Stock Economat"
            BarRestaurantForm.Label6.Text = "Situation Caisse"
            BarRestaurantForm.GunaButtonRefresh.Text = "Rafrachir"
            BarRestaurantForm.GunaButtonSaveFacturation.Text = "Enregistrer"
            BarRestaurantForm.GunaButtonImprimer.Text = "Imprimer"
            BarRestaurantForm.GunaButtonnNouvelleFacture.Text = "Nouveau"
            BarRestaurantForm.Label9.Text = "EVENEMENTS"
            BarRestaurantForm.LabelSoldeEvent.Text = "SOLDE"
            BarRestaurantForm.LabelNumeroChambre.Text = "Chambre N°"
            BarRestaurantForm.Label5.Text = "SOLDE"
            BarRestaurantForm.GunaAdvenceButtonLectureDeCarte.Text = "LIRE CARTE"
            BarRestaurantForm.Label29Evenement.Text = "EVENEMENT"
            '--------------------------------------------------------------------------
            BarRestaurantForm.GunaGroupBox1.Text = "RECHERCHER"
            BarRestaurantForm.GunaLabel86.Text = "NUMERO BLOC NOTE"
            BarRestaurantForm.GunaButtonArricherBlocNotes.Text = "Afficher"
            BarRestaurantForm.GunaLabelListe.Text = "LISTE DES BLOC NOTES"
            BarRestaurantForm.GunaLabel3.Text = "DETAILS DES BLOCS NOTES"
            BarRestaurantForm.GunaGroupBoxCreationBordereau.Text = "Création de Bordereau"
            BarRestaurantForm.GunaButtonNouveau.Text = "Nouveau"
            BarRestaurantForm.GunaGroupBoxListeDesBordereaux.Text = "Contenu du bordereau"
            BarRestaurantForm.LabelBon.Text = "APPROVISIONNEMENT"
            BarRestaurantForm.GunaLabel89.Text = "Type de bordereau"
            BarRestaurantForm.GunaLabel93.Text = "Libellé Bordereau"
            BarRestaurantForm.GunaLabel97.Text = "Employé"
            BarRestaurantForm.GunaLabel91.Text = "Employé"
            BarRestaurantForm.GunaLabel92.Text = "Observation"
            BarRestaurantForm.GunaLabelMagasinDeDestination.Text = "Magasin de Réception"
            BarRestaurantForm.GunaButtonAjouterLigneAppro.Text = "Ajouter"
            BarRestaurantForm.Label33.Text = "ARTICLE"
            BarRestaurantForm.LabelQuantite.Text = "QTE"
            BarRestaurantForm.LabelCout.Text = "PU"
            BarRestaurantForm.Label30.Text = "UNITE"
            'BarRestaurantForm.Label31.Text = "Qté En Stock"
            BarRestaurantForm.Label32.Text = "Seuile"
            BarRestaurantForm.GunaButtonEnregistrer.Text = "Emettre"
            BarRestaurantForm.GunaCheckBox1.Text = "Lecteur RFID"
            BarRestaurantForm.GunaButtonImpressionDirecteAppro.Text = "Imprimer"
            BarRestaurantForm.GunaButtonAccueil.Text = "Accueil"
            BarRestaurantForm.Label26.Text = "MONTANT ACHAT"
            BarRestaurantForm.Label28.Text = "MONTANT VENTE"

            BarRestaurantForm.RetirerToolStripMenuItem.Text = "Retirer"
            BarRestaurantForm.ImprimerToolStripMenuItem.Text = "Imprimer"
            BarRestaurantForm.TransférerToolStripMenuItem.Text = "Transférer"
            BarRestaurantForm.SupprimerToolStripMenuItem.Text = "Supprimer"
            BarRestaurantForm.SupprimerToolStripMenuItem1.Text = "Supprimer"

            BarRestaurantForm.GunaButtonArricherBlocNotes.Text = "Afficher"

            '-----------------------------------------------------------------
            BarRestaurantForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            BarRestaurantForm.RESERVATIONToolStripMenuItem.Text = "RESERVATION"
            BarRestaurantForm.SERVICEDETAGEToolStripMenuItem.Text = "SERVICE ETAGE"
            BarRestaurantForm.ToolStripMenuItemCusine.Text = "CUISINE"
            BarRestaurantForm.ComptabilitéToolStripMenuItem.Text = "COMPATBILITE ET FICNANCES"
            BarRestaurantForm.ECONOMATToolStripMenuItem.Text = "ECONOMAT"
            BarRestaurantForm.TECHNIQUEToolStripMenuItem.Text = "TECHNIQUE"

            BarRestaurantForm.SupprimerToolStripMenuItem2.Text = "Supprimer"
            BarRestaurantForm.ToolStripMenuItemSupLigneBlocNoteGestBlocNote.Text = "Supprimer"

            BarRestaurantForm.ToolStripMenuItemSession.Text = "SESSION"
            BarRestaurantForm.ToolStripMenuItem117.Text = "Changer mot de passe"
            BarRestaurantForm.FermerCaisseToolStripMenuItem.Text = "Fermer Caisse"
            BarRestaurantForm.PETITEToolStripMenuItem.Text = "Petite Caisse"
            BarRestaurantForm.OuvrirCaisseToolStripMenuItem.Text = "Ouvrir Caisse"
            BarRestaurantForm.ToolStripMenuItem119.Text = "Fermer Session"
            BarRestaurantForm.ChoisirMagasinDeTravailToolStripMenuItem.Text = "Choisir Magasin de Travail"

        End If

        autoLoadEmployee(GlobalVariable.actualLanguageValue)

        autoLoadSlipType(GlobalVariable.actualLanguageValue)

    End Sub

    Public Sub FabricationDeProforma(ByVal actualLanguageValue As Integer)

        If actualLanguageValue = 0 Then

            FabricationDeProformaForm.GunaLabel2.Text = "Group Number"
            FabricationDeProformaForm.ImprimerDocChambreSalle.Text = "Print"
            FabricationDeProformaForm.GunaButtonEnvoyer.Text = "Add to Estimate"
            FabricationDeProformaForm.GunaLabelGestCompteGeneraux.Text = "ESTABLISHMENT OF ESTIMATE"

        Else

            FabricationDeProformaForm.GunaLabel2.Text = "Numéro de Groupe"
            FabricationDeProformaForm.ImprimerDocChambreSalle.Text = "Imprimer"
            FabricationDeProformaForm.GunaButtonEnvoyer.Text = "Ajouter au Devis"
            FabricationDeProformaForm.GunaLabelGestCompteGeneraux.Text = "ETABLISSEMENT DE PROFORMA"

        End If

    End Sub

    Public Sub receptionReservation(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then ' 

            MainWindow.GunaComboBoxFiltre.Items.Clear()
            MainWindow.GunaComboBoxFiltre.Items.Add("Company")
            MainWindow.GunaComboBoxFiltre.Items.Add("Group")
            MainWindow.GunaComboBoxFiltre.Items.Add("Individuals")
            MainWindow.GunaComboBoxFiltre.Items.Add("All the reservations")

            MainWindow.ClubEliteToolStripMenuItem.Text = "Elite Club"
            MainWindow.GunaGroupRecherche.Text = "SEARCH CRITERIA"
            MainWindow.GunaGroupBox3.Text = "SEARCH CRITERIA"
            MainWindow.GunaGroupBox11.Text = "SEARCH CRITERIA"
            MainWindow.GunaGroupBox12.Text = "SEARCH CRITERIA"

            MainWindow.GunaButton28.Text = "SALES VENTILATION FORM"

            MainWindow.GunaButtonSynthese.Text = "Summary Doc"
            MainWindow.GunaCheckBoxMensuel.Text = "Monthly"
            MainWindow.GunaCheckBoxHebdo.Text = "Weekly"
            '---------------------------------------------------------------------
            MainWindow.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindow.RESERVATIONToolStripMenuItem.Text = "BOOKING"
            MainWindow.SERVICEDETAGEToolStripMenuItem.Text = "HOUSE KEEPING"
            MainWindow.CUISINEToolStripMenuItem.Text = "KITCHEN"
            MainWindow.BarRestaurationToolStripMenuItem.Text = "BAR / RESTAURANT"
            MainWindow.ComptabilitéToolStripMenuItem.Text = "ACCOUNTING AND FINANCES"
            MainWindow.ECONOMATToolStripMenuItem.Text = "PURCHASE"
            MainWindow.TECHNIQUEToolStripMenuItem.Text = "TECHNICAL"

            '-------------------------------------------------------------------------------
            MainWindow.GunaAdvenceButtonDashBoard.Text = "DASHBOARD"
            MainWindow.GunaAdvenceButtonPlanning.Text = "PLANNING"
            MainWindow.GunaAdvenceButton27.Text = "ARRIVALS"
            MainWindow.GunaAdvenceButtonEnChambre.Text = "IN HOUSE"
            MainWindow.GunaAdvenceButtonDepartsList.Text = "DUE OUT"
            MainWindow.GunaAdvenceButtonAttribuerChambre.Text = "ATTRIBUTE ROOM"
            MainWindow.GunaAdvenceButton21.Text = "PETTY CASH"
            MainWindow.GunaAdvenceButton33.Text = "INSTRUCTIONS BOOK"
            MainWindow.GunaAdvenceRapports.Text = "REPORTS"
            MainWindow.GunaAdvenceButton6.Text = "CARDEX"
            MainWindow.GunaAdvenceButton22.Text = "SEARCH"
            MainWindow.GunaAdvenceButton5.Text = "NEW BOOKING"
            MainWindow.GunaAdvenceButton4.Text = "EDIT BOOKING"
            MainWindow.GunaAdvenceButton23.Text = "AVAILABILITY AND RATES"
            MainWindow.GunaAdvenceButton24.Text = "ROOM PLAN"
            MainWindow.GunaAdvenceButton30.Text = "REPORTS"
            MainWindow.GunaRadioButtonChambre.Text = "Accommodation"
            MainWindow.GunaRadioButtonSalleFete.Text = "Party Hall"
            MainWindow.GunaButtonPayer.Text = "Pay"
            MainWindow.GunaLabel42.Text = "Balance"
            MainWindow.GunaButtonAjouterClient.Text = "Add a client"
            MainWindow.GunaButtonModifierClient.Text = "Edit client"
            MainWindow.GunaGroupBox5.Text = "Client details"
            MainWindow.GunaGroupBoxDetailChambre.Text = "Room details"
            MainWindow.GunaGroupBox4.Text = "Period of stay"
            MainWindow.GunaCheckBoxGratuitee.Text = "Free"
            MainWindow.GunaLabel4.Text = "Arrival"
            MainWindow.GunaLabel5.Text = "Departure"
            MainWindow.GunaLabelTempsAFaire.Text = "Total nights"
            MainWindow.GunaLabelLibelleTypeChambreSalle.Text = "Room type"
            MainWindow.GunaLabelNumeroChambre.Text = "Room N°"
            MainWindow.GunaButtonLectureDeCarte.Text = "CARD"
            MainWindow.GunaButtonPreference.Text = "Preference"
            MainWindow.GunaButtonFactures.Text = "Bills"
            MainWindow.GunaButtonSejours.Text = "Stay"
            MainWindow.GunaButtonRegistreDesVisites.Text = "Visitation register"
            MainWindow.GunaLabel10.Text = "Company"

            '-----------------------------------------------------------------------------------
            MainWindow.ToolStripMenuItemSession.Text = "SESSION"
            MainWindow.BonApprovisionnementToolStripMenuItem.Text = "Request"
            MainWindow.ChangerMagasinToolStripMenuItem.Text = "Choose working store"
            MainWindow.ToolStripMenuItem117.Text = "Change password"
            MainWindow.FermerCaisseToolStripMenuItem.Text = "Close cash Register"
            MainWindow.PETITEToolStripMenuItem.Text = "Petty Cash Flow"
            MainWindow.OuvrirCaisseToolStripMenuItem.Text = "Open Cash Register"
            MainWindow.ClôturerToolStripMenuItem.Text = "Night Audit"
            MainWindow.ToolStripMenuItemConfig.Text = "SETTINGS"
            MainWindow.ToolStripMenuItemServTech.Text = "TECHNICAL SERVICE"
            MainWindow.ToolStripMenuItemSecurite.Text = "SECURITY"
            MainWindow.ToolStripMenuItem119.Text = "Close Session"
            MainWindow.VisiteurToolStripMenuItem.Text = "Visit Management"

            '------------------------------------------------------------------
            MainWindow.GunaFrontDeskLabel.Text = "ROOM BOOKING"
            MainWindow.ImprimerDocChambreSalle.Text = "Print"
            MainWindow.GunaButtonEnvoyer.Text = "Send"
            MainWindow.GunaButtonQuitter.Text = "Quit"
            MainWindow.GunaButtonVider.Text = "Flush"
            MainWindow.GunaRadioButtonEmailNon.Text = "No"
            MainWindow.GunaRadioButtonMailOui.Text = "Yes"
            MainWindow.GunaRadioButtonWhatsAppNon.Text = "No"
            MainWindow.GunaRadioButtonWhatsAppOui.Text = "Yes"
            MainWindow.GunaCheckBoxAfficherPrix.Text = "Show price on Registration form"
            MainWindow.GunaButtonAnnulerResa.Text = "Cancel"
            MainWindow.GunaButton25.Text = "Shuttle B."
            MainWindow.GunaButtonCoChambrier.Text = "Companions"
            MainWindow.GunaLabel8.Text = "Name *"
            MainWindow.GunaLabel131.Text = "WORKING DATE : "
            MainWindow.GunaButtonArricherReservation.Text = "View"
            MainWindow.GunaButtonAfficherArrivee.Text = "View"
            MainWindow.GunaButtonEnChambreAfficher.Text = "View"
            MainWindow.GunaButtonAfficherDepart.Text = "View"
            MainWindow.GunaCheckBoxPetitDejeuenerInclus.Text = "Break Fast included"
            MainWindow.GunaCheckBoxTaxeSejour.Text = "Stay tax"
            MainWindow.GunaLabelPrixReel.Text = "Real price"
            '----------------------------------------------------------------------------------------------

            MainWindow.GunaGroupBoxRoomStatus.Text = "Rooms Status"
            MainWindow.GunaAdvenceButton1.Text = "Refresh"
            MainWindow.GunaLabelGraphiques.Text = "Statistics"
            MainWindow.GunaGroupBoxStatistiques.Text = "Activities of the Day"
            MainWindow.GunaGroupBoxArriveDepart.Text = "Arrivals, Due Out and In House"
            MainWindow.GunaLabel51.Text = "BOOKINGS"
            MainWindow.GunaAdvenceButtonArrivee.Text = "Arrivals"
            MainWindow.GunaAdvenceButtonDeparts.Text = "Due Out"
            MainWindow.GunaAdvenceButtonSejour.Text = "In House"
            MainWindow.GunaAdvenceButtonNouvelleReservation.Text = "New Booking"
            MainWindow.GunaAdvenceButtonImpression.Text = "Print"
            MainWindow.Quitter.Text = "HOME"
            MainWindow.GunaLabel95.Text = "INCOME BY FAMILY"
            MainWindow.GunaTextBoxHebergementTitre.Text = "Accommodation"
            MainWindow.GunaTextBoxAutresTitre.Text = "Others"

            MainWindow.GunaLabel97.Text = "ROOM STATUS"
            MainWindow.GunaLabelSale.Text = "Dirty"
            MainWindow.GunaLabelEncours.Text = "On going"
            MainWindow.GunaLabelAinspecter.Text = "To inspect"
            MainWindow.GunaLabelPropre.Text = "Clean"
            MainWindow.GunaLabelHorsService.Text = "Out of order"
            MainWindow.GunaLabel113.Text = "OCCUPATION RATE"
            MainWindow.GunaLabel12.Text = "DAYLY"
            MainWindow.GunaLabel114.Text = "OCCUPATION RATE BY ROOM TYPE (%)"
            MainWindow.GunaLabelDuMoisDernier.Text = "LAST MONTH"
            MainWindow.GunaLabelDuMoisActuel.Text = "ACTUAL MONTH"

            '-----------------------------------------------------------
            MainWindow.GunaLabel29.Text = "Number"
            MainWindow.GunaLabel30.Text = "Person(s)"
            MainWindow.GunaLabel31.Text = "Adult(s)"
            MainWindow.GunaLabel32.Text = "Children"
            MainWindow.GunaLabel33.Text = "Base price"

            '--------------------------------------------------------------
            MainWindow.GunaLabelElite.Text = "Elite"
            MainWindow.GunaLabel11.Text = "ID/UIN"
            MainWindow.GunaCheckBoxReservationDeGroupe.Text = "Group Booking"
            MainWindow.GunaLabel22.Text = "Telephone"
            MainWindow.GunaLabel21.Text = "Coming from"
            MainWindow.GunaLabel27.Text = "Transport Mode"
            MainWindow.GunaLabel26.Text = "Vehicule N°"
            MainWindow.GunaLabel80.Text = "Booking Type"
            MainWindow.GunaLabel79.Text = "Booking source"
            MainWindow.GunaLabel46.Text = "Payment"
            MainWindow.GunaLabel158.Text = "MOVE :"
            MainWindow.GunaLabel160.Text = "CANCEL :"
            MainWindow.GunaLabel23.Text = "Going to"

            MainWindow.GunaLabelPrixSejours.Text = "Stay price"
            MainWindow.GunaGroupBox1.Text = "Routing Instructions"
            MainWindow.GunaGroupBox6.Text = "Payment"
            MainWindow.GunaCheckBoxPetitDejRoutage.Text = "F & B"
            MainWindow.GunaCheckBoxChambreRoutage.Text = "Room"
            MainWindow.GunaLabel45.Text = "Room"
            MainWindow.GunaLabel45.Text = "Room"
            MainWindow.GunaLabel39.Text = "Food price"
            MainWindow.GunaLabel40.Text = "Additional Services"
            MainWindow.GunaLabel37.Text = "Total accommodation"
            MainWindow.GunaLabel41.Text = "Amount to Pay"

            MainWindow.GunaLabel56.Text = "ARRIVALS OF :"
            MainWindow.GunaLabel52.Text = "IN HOUSE OF :"
            MainWindow.GunaLabel47.Text = "DUE OUT OF :"

            '----------------------------------------------------

            MainWindow.GunaButtonMainCouranteJOurnaliere.Text = "DAILY FINANCIAL REPORT - ACCOMMODATION"
            MainWindow.GunaButtonMainCouranteCummulee.Text = "CUMULATED FINANCIAL REPORT - ACCOMMODATION"
            MainWindow.GunaButtonMainCouranteEvents.Text = "DAILY FINANCIAL REPORT - EVENTS"
            MainWindow.GunaButtonMainCouranteCumulEvents.Text = "CUMULATED FINANCIAL REPORT - EVENTS"
            MainWindow.GunaButtonEvenements.Text = "EVENTS"
            MainWindow.GunaButton8.Text = "BILLS"
            MainWindow.GunaButton1.Text = "SALES INVETRORY"
            MainWindow.GunaButtonEnChambre.Text = "BALANCE VERIFICATIONS"
            MainWindow.GunaButton10.Text = "RESERVATIONS"
            MainWindow.GunaButton4.Text = "EXPECTED"
            MainWindow.GunaButton7.Text = "ARRIVED"
            MainWindow.GunaButtonRapportDSt.Text = "POLICE REPORT"

            MainWindow.GunaButtonCheckOutReservation.Text = "CHECKOUT RESERVATIONS"
            MainWindow.GunaButton19.Text = "CANCELED BOOKING"
            MainWindow.GunaButtonResaParSource.Text = "RESERVATION BY SOURCE"
            MainWindow.GunaButtonResaParTypeResa.Text = "RESERVATIONS BY TYPE"
            MainWindow.GunaButtonNoShow.Text = "NO SHOW & CANCELATION"
            MainWindow.GunaButtonTopPeoducers.Text = "TOP PRODUCERS"
            MainWindow.GunaButton21.Text = "DISCOUNT CONTROL"
            MainWindow.GunaButtonRapportDayUse.Text = "DAY USE / CONTROL OF LATE DEPARTURE"
            MainWindow.GunaButtonRapportNonDayUse.Text = "STAY / CONTROL OF LATE DEPARTURE"
            MainWindow.GunaButtonEtatDesChambres.Text = "ROOM STATES"
            MainWindow.GunaButton11.Text = "BAR-RESTAURANT VENTILATION FORM"
            MainWindow.GunaButton12.Text = "BAR DAILY INVENTORY FORM"
            MainWindow.GunaButtonStatJournaliere.Text = "DAILY STATISTICS"
            MainWindow.GunaButtonListePetitDejeuner.Text = "LISTE PETIT DEJEUNER"
            MainWindow.GunaButton22.Text = "DEBTORS LIST"
            MainWindow.GunaButton15.Text = "MONTHLY SITUATION"
            MainWindow.GunaButtonPromoteur.Text = "MANAGER"
            MainWindow.GunaButtonVenteShift.Text = "SALES HISTORY - SHIFT"
            MainWindow.GunaButtonRapportDesVentes.Text = "DAILY SALES HISTORY"
            MainWindow.GunaButton13.Text = "PERIODIC SALES HISTORY"
            MainWindow.GunaButtonCaisseJournalier.Text = "CASH REGISTER STATE - SHIFT"
            MainWindow.GunaButtonCaisseGlobal.Text = "DAILY CASH REGISTER STATE"
            MainWindow.GunaButton14.Text = "PERIODIC CASH REGISTER HISTORY"
            MainWindow.GunaButton5.Text = "PETTY CASH FLOW HISTORY"
            MainWindow.GunaButton23.Text = "POS ORDER HISTORY"
            MainWindow.GunaButton2.Text = "HOME"

            MainWindow.GunaButton24.Text = "SHUTTLE BUSES"
            MainWindow.GunaButtonListePetitDejeuner.Text = "ENTITLED TO BREAKFAST"

            MainWindow.TabControlHbergement.TabPages(0).Text = "Registration"
            MainWindow.TabControlHbergement.TabPages(1).Text = "Reservations"
            MainWindow.TabControlHbergement.TabPages(2).Text = "Arrivals"
            MainWindow.TabControlHbergement.TabPages(3).Text = "In House"
            MainWindow.TabControlHbergement.TabPages(4).Text = "Due Out"

            MainWindow.TabControlGestionReservation.TabPages(0).Text = "Payment"
            MainWindow.TabControlGestionReservation.TabPages(1).Text = "Billing"
            MainWindow.TabControlGestionReservation.TabPages(2).Text = "Documents"
            MainWindow.TabControlGestionReservation.TabPages(3).Text = "Event Form"

            MainWindow.GunaButtonAfficherPlanning.Text = "View"

            MainWindow.GunaButtonAfficherPlanning.Text = "View"
            MainWindow.Label2.Text = "AVAILABILITIES AND RATES"
            MainWindow.GunaButton16.Text = "View"
            MainWindow.GunaButtonEditionDeMasse.Text = "Bulk Edit"
            MainWindow.GunaButton6.Text = "HOME"

            MainWindow.TabControlListeDesDocumentsFacturesEtReglement.TabPages(0).Text = "Bills"
            MainWindow.TabControlListeDesDocumentsFacturesEtReglement.TabPages(1).Text = "Receipts"
            MainWindow.TabControlListeDesDocumentsFacturesEtReglement.TabPages(2).Text = "Bill details"
            MainWindow.TabControlListeDesDocumentsFacturesEtReglement.TabPages(3).Text = "Others"
            MainWindow.GunaButtonAffichageDesDocuments.Text = "View"

            MainWindow.GunaLabel64.Text = "EVENT"
            MainWindow.GunaLabel78.Text = "Decoration"
            MainWindow.GunaLabel62.Text = "Material Renting"
            MainWindow.GunaLabel67.Text = "Base Price"
            MainWindow.GunaLabelPrixReelSalle.Text = "Real Price"
            MainWindow.GunaLabelAutres.Text = "Others"
            MainWindow.GunaLabel129.Text = "Time"
            MainWindow.GunaLabel69.Text = "Price / Person"
            MainWindow.GunaLabel71.Text = "Total Amount"
            MainWindow.GunaLabel77.Text = "Amount to Pay"
            MainWindow.GunaLabel65.Text = "EVENT TECHNICAL SHEET"

            MainWindow.GunaLabel91.Text = "NAME :"
            MainWindow.GunaLabel103.Text = "COMPANY :"
            MainWindow.GunaButtonHebergement.Text = "Accommodation"
            MainWindow.GunaLabel165.Text = "Accommodation"
            MainWindow.GunaLabel122.Text = "SERVICES TO OFFER"
            MainWindow.GunaLabel140.Text = "HALL ORGANISATION"

            MainWindow.ToolStripMenuItemDupliquer.Text = "Duplicate"
            MainWindow.ToolStripMenuItemSupprimer.Text = "Delete"
            MainWindow.ToolStripMenuItem3.Text = "Cancel"

            MainWindow.GunaAdvenceButton2.Text = "ELITE CLUB"

            MainWindow.GunaButtonPeriodicAccommodationReport.Text = "ACCOMMODATION SALES REVENUE"
            MainWindow.GunaButton27.Text = "SALES REVENUE PER DEPARTMENTS"
            MainWindow.GunaButton15.Text = "DETAILED MONTHLY SALES REVENUE"

            MainWindow.GunaButtonAfficherDst.Text = "View"
            MainWindow.GunaLabelDu.Text = "From"
            MainWindow.GunaLabel61.Text = "To"
            MainWindow.GunaButtonImpressionPourDST.Text = "Print"

            MainWindow.GunaButtonBar.Text = "Bar"
            MainWindow.GunaButtonRestaurant.Text = "Restaurant"
            MainWindow.GunaButtonServices.Text = "Services"
            MainWindow.GunaButtonSalonDeBeaute.Text = "Beauty Salon"
            MainWindow.GunaButtonBoutique.Text = "Shop"
            MainWindow.GunaButtonLoisir.Text = "Leasure"
            MainWindow.GunaButtonKiosque.Text = "News Stand"
            MainWindow.GunaButtonBlanchisserie.Text = "Laundry"
            MainWindow.GunaButtonAutres.Text = "Others"
            MainWindow.GunaButtonFamilleArticle.Text = "Article Category"
            MainWindow.GunaButton18.Text = "Article Family"
            MainWindow.GunaButtonSousFamilleArticle.Text = "Article Sub Family"
            MainWindow.GunaButtonArticles.Text = "Articles"
            MainWindow.GunaButton20.Text = "Sales Points"
            MainWindow.GunaButtonMatieres.Text = "Materials"
            MainWindow.GunaButtonPrintFromDetails.Text = "Print"
            MainWindow.GunaButtonPrintFactureDetails.Text = "Print"
            MainWindow.GunaLabel105.Text = "Phone No"
            MainWindow.GunaLabel109.Text = "EVENT"
            MainWindow.GunaLabel110.Text = "At"
            MainWindow.GunaLabel118.Text = "Pax"
            MainWindow.GunaLabel120.Text = "Global Amount"
            MainWindow.GunaLabel148.Text = "Hall to Rent"
            MainWindow.GunaLabel149.Text = "Amount"
            MainWindow.GunaLabel148.Text = "Hall to Rent"
            MainWindow.GunaLabel144.Text = "Video Projector"
            MainWindow.GunaLabel145.Text = "Sound System"
            MainWindow.GunaLabel146.Text = "Flatwares"
            MainWindow.GunaLabel147.Text = "Tables + Chairs"
            MainWindow.GunaLabel135.Text = "Quantity"
            MainWindow.GunaLabel136.Text = "Unit Price"
            MainWindow.GunaLabel147.Text = "Tables + Chairs"
            MainWindow.GunaLabel138.Text = "Quantity"
            MainWindow.GunaLabel139.Text = "Unit Price"
            MainWindow.GunaLabel133.Text = "Water Little Bottle"
            MainWindow.GunaLabel130.Text = "Soft Drinks"
            MainWindow.GunaLabel134.Text = "Vin Rouge"
            MainWindow.GunaLabel137.Text = "Pink Wine"
            MainWindow.GunaLabel150.Text = "Water Big Bottle"
            MainWindow.GunaLabel132.Text = "Beers"
            MainWindow.GunaLabel128.Text = "External Drinks"
            MainWindow.GunaLabel143.Text = "Corkage"
            MainWindow.GunaLabel165.Text = "Accommodation"
            MainWindow.GunaButtonHebergement.Text = "Accommodation"
            MainWindow.GunaLabel142.Text = "Set Up"
            MainWindow.GunaCheckBoxEcole.Text = "School"
            MainWindow.GunaCheckBoxTheatre.Text = "Theater"
            MainWindow.GunaCheckBoxRectangle.Text = "Rectangular"
            MainWindow.GunaLabel141.Text = "Confinement :"
            MainWindow.GunaCheckBox2.Text = "In 2"
            MainWindow.GunaCheckBox9.Text = "In 3"
            MainWindow.GunaCheckBoxVidOui.Text = "YES"
            MainWindow.GunaCheckBoxVidNon.Text = "NO"
            MainWindow.GunaCheckBoxSonoOui.Text = "YES"
            MainWindow.GunaCheckBoxSonoNon.Text = "NO"
            MainWindow.GunaCheckBoxCouvOui.Text = "YES"
            MainWindow.GunaCheckBoxCouvNon.Text = "NO"
            MainWindow.GunaCheckBoxTableOui.Text = "YES"
            MainWindow.GunaCheckBoxTableNon.Text = "NO"
            MainWindow.GunaButtonProductionReceptionnists.Text = "RECEPTIONNIST PRODUCTIVITY"
            MainWindow.GunaButtonPrixMoyens.Text = "AVERAGE PRICES"
            MainWindow.GunaButtonStatDashBoard.Text = "OCCUPANCY RATE"
            MainWindow.GunaButtonRapportAutomatique.Text = "AUTO REPORTS"

            '---------------only up

            MainWindow.ClubEliteToolStripMenuItem.Text = "Elite Club"
            MainWindow.GunaAdvenceButton7.Text = "ARRHES"

            MainWindow.GunaButtonSynthese.Text = "Summary Doc"
            MainWindow.GunaButtonBar.Text = "Bar"
            MainWindow.GunaButtonRestaurant.Text = "Restaurant"
            MainWindow.GunaButtonServices.Text = "Services"
            MainWindow.GunaButtonSalonDeBeaute.Text = "Beauty Salon"
            MainWindow.GunaButtonBoutique.Text = "Shop"
            MainWindow.GunaButtonLoisir.Text = "Leasure"
            MainWindow.GunaButtonKiosque.Text = "News Stand"
            MainWindow.GunaButtonBlanchisserie.Text = "Laundry"
            MainWindow.GunaButtonAutres.Text = "Others"
            MainWindow.GunaButtonFamilleArticle.Text = "Article Category"
            MainWindow.GunaButton18.Text = "Article Family"
            MainWindow.GunaButtonSousFamilleArticle.Text = "Article Sub Family"
            MainWindow.GunaButtonArticles.Text = "Articles"
            MainWindow.GunaButton20.Text = "Sales Points"
            MainWindow.GunaButtonMatieres.Text = "Materials"
            MainWindow.GunaButtonPrintFromDetails.Text = "Print"
            MainWindow.GunaButtonPrintFactureDetails.Text = "Print"
            MainWindow.GunaLabel105.Text = "Phone No"
            MainWindow.GunaLabel109.Text = "EVENT"
            MainWindow.GunaLabel110.Text = "At"
            MainWindow.GunaLabel118.Text = "Pax"
            MainWindow.GunaLabel120.Text = "Global Amount"
            MainWindow.GunaLabel148.Text = "Hall to Rent"
            MainWindow.GunaLabel149.Text = "Amount"
            MainWindow.GunaLabel148.Text = "Hall to Rent"
            MainWindow.GunaLabel144.Text = "Video Projector"
            MainWindow.GunaLabel145.Text = "Sound System"
            MainWindow.GunaLabel146.Text = "Flatwares"
            MainWindow.GunaLabel147.Text = "Tables + Chairs"
            MainWindow.GunaLabel135.Text = "Quantity"
            MainWindow.GunaLabel136.Text = "Unit Price"
            MainWindow.GunaLabel147.Text = "Tables + Chairs"
            MainWindow.GunaLabel138.Text = "Quantity"
            MainWindow.GunaLabel139.Text = "Unit Price"
            MainWindow.GunaLabel133.Text = "Water Little Bottle"
            MainWindow.GunaLabel130.Text = "Soft Drinks"
            MainWindow.GunaLabel134.Text = "Vin Rouge"
            MainWindow.GunaLabel137.Text = "Pink Wine"
            MainWindow.GunaLabel150.Text = "Water Big Bottle"
            MainWindow.GunaLabel132.Text = "Beers"
            MainWindow.GunaLabel128.Text = "External Drinks"
            MainWindow.GunaLabel143.Text = "Corkage"
            MainWindow.GunaLabel165.Text = "Accommodation"
            MainWindow.GunaButtonHebergement.Text = "Accommodation"
            MainWindow.GunaLabel142.Text = "Set Up"
            MainWindow.GunaCheckBoxEcole.Text = "School"
            MainWindow.GunaCheckBoxTheatre.Text = "Theater"
            MainWindow.GunaCheckBoxRectangle.Text = "Rectangular"
            MainWindow.GunaLabel141.Text = "Confinement :"
            MainWindow.GunaCheckBox2.Text = "In 2"
            MainWindow.GunaCheckBox9.Text = "In 3"
            MainWindow.GunaCheckBoxVidOui.Text = "YES"
            MainWindow.GunaCheckBoxVidNon.Text = "NO"
            MainWindow.GunaCheckBoxSonoOui.Text = "YES"
            MainWindow.GunaCheckBoxSonoNon.Text = "NO"
            MainWindow.GunaCheckBoxCouvOui.Text = "YES"
            MainWindow.GunaCheckBoxCouvNon.Text = "NO"
            MainWindow.GunaCheckBoxTableOui.Text = "YES"
            MainWindow.GunaCheckBoxTableNon.Text = "NO"
            MainWindow.GunaButtonProductionReceptionnists.Text = "RECEPTIONNIST PRODUCTIVITY"
            MainWindow.GunaButtonPrixMoyens.Text = "AVERAGE PRICES"
            MainWindow.GunaButtonStatDashBoard.Text = "OCCUPANCY RATE"
            MainWindow.GunaButtonRapportAutomatique.Text = "AUTO REPORTS"

            MainWindow.GunaComboBoxImpressionSalle.Items.Clear()
            MainWindow.GunaComboBoxImpressionSalle.Items.Add("Reservation Confirmation")
            MainWindow.GunaComboBoxImpressionSalle.Items.Add("Contract")
            MainWindow.GunaComboBoxImpressionSalle.Items.Add("Quotation")

            MainWindow.GunaComboBoxImpressionChambre.Items.Clear()
            MainWindow.GunaComboBoxImpressionChambre.Items.Add("Reservation Confirmation")
            MainWindow.GunaComboBoxImpressionChambre.Items.Add("Registration Form")

            MainWindow.GunaLabel44.Text = "Arrhes"
            MainWindow.GunaGroupRecherche.Text = "SEARCH"
            MainWindow.GunaLabel34.Text = "CLIENT NAME"
            MainWindow.GunaLabel66.Text = "RESERVATION No"
            MainWindow.GunaLabel83.Text = "COMPANY"
            MainWindow.GunaLabel85.Text = "RESERVATION SOURCE"
            MainWindow.GunaLabel84.Text = "GROUP No"
            MainWindow.GunaLabel86.Text = "ROOM"
            MainWindow.GunaLabel87.Text = "From"
            MainWindow.GunaLabel82.Text = "To"

            MainWindow.GunaGroupBox3.Text = "SEARCH"
            MainWindow.GunaLabel104.Text = "CLIENT NAME"
            MainWindow.GunaLabel102.Text = "RESERVATION No"
            MainWindow.GunaLabel99.Text = "COMPANY"
            MainWindow.GunaLabel90.Text = "RESERVATION SOURCE"
            MainWindow.GunaLabel98.Text = "GROUP No"
            MainWindow.GunaLabel96.Text = "ROOM"
            MainWindow.GunaLabel100.Text = "From"
            MainWindow.GunaLabel101.Text = "To"

            MainWindow.GunaGroupBox11.Text = "SEARCH"
            MainWindow.GunaLabel119.Text = "CLIENT NAME"
            MainWindow.GunaLabel117.Text = "RESERVATION No"
            MainWindow.GunaLabel112.Text = "COMPANY"
            MainWindow.GunaLabel6.Text = "RESERVATION SOURCE"
            MainWindow.GunaLabel106.Text = "GROUP No"
            MainWindow.GunaLabel9.Text = "ROOM"
            MainWindow.GunaLabel115.Text = "From"

            MainWindow.GunaGroupBox12.Text = "SEARCH"
            MainWindow.GunaLabel126.Text = "CLIENT NAME"
            MainWindow.GunaLabel125.Text = "RESERVATION No"
            MainWindow.GunaLabel123.Text = "COMPANY"
            MainWindow.GunaLabel35.Text = "RESERVATION SOURCE"
            MainWindow.GunaLabel121.Text = "GROUP No"
            MainWindow.GunaLabel116.Text = "ROOM"
            MainWindow.GunaLabel124.Text = "From"
            MainWindow.GunaLabel127.Text = "To"

            MainWindow.GunaButtonHandOverForm.Text = "HAND OVER FORM"
            MainWindow.SauvegardeBaseDeDonnéeToolStripMenuItem.Text = "Export / Tranfer DB"

        ElseIf ActualLanguageValue = 1 Then

            MainWindow.GunaButtonImpressionPourDST.Text = "Imprimer"
            MainWindow.GunaButton17.Text = "FICHE D'EFFECTIF JOURNALIER"

            MainWindow.GunaAdvenceButton2.Text = "CLUB ELITE"
            MainWindow.ClubEliteToolStripMenuItem.Text = "Club Elite"

            '---------------Salle de Fete -------------------------------------
            MainWindow.GunaLabel122.Text = "PRESTATIONS A OFFRIR"
            MainWindow.GunaLabel140.Text = "AMENAGEMENT DE LA SALLE"
            MainWindow.GunaLabel91.Text = "NOM  :"
            MainWindow.GunaLabel103.Text = "SOCIETE :"
            MainWindow.GunaButtonHebergement.Text = "Hébergement"
            MainWindow.GunaLabel165.Text = "Hébergement"

            MainWindow.GunaLabel65.Text = "FICHE TECHNIQUE DE MANIFESTATION"
            MainWindow.GunaLabel71.Text = "Montant Total"
            MainWindow.GunaLabel77.Text = "Montant à Régler"

            MainWindow.GunaLabel64.Text = "EVENEMENT"
            MainWindow.GunaLabel78.Text = "Décoration"
            MainWindow.GunaLabel62.Text = "Location Matériel"
            MainWindow.GunaLabel67.Text = "Tarif de Base"
            MainWindow.GunaLabelPrixReelSalle.Text = "Tarif Accordé"
            MainWindow.GunaLabelAutres.Text = "Autres"
            MainWindow.GunaLabel129.Text = "Heure"
            MainWindow.GunaLabel69.Text = "Prix / Personne"

            MainWindow.GunaButtonSynthese.Text = "Doc Synthèse"
            MainWindow.GunaButton2.Text = "ACCUEIL"
            MainWindow.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindow.RESERVATIONToolStripMenuItem.Text = "RESERVATION"
            MainWindow.SERVICEDETAGEToolStripMenuItem.Text = "SERVICE D'ETAGE"
            MainWindow.CUISINEToolStripMenuItem.Text = "CUISINE"
            MainWindow.BarRestaurationToolStripMenuItem.Text = "BAR / RESTAURANT"
            MainWindow.ComptabilitéToolStripMenuItem.Text = "COMPTABILITE ET FINANCE"
            MainWindow.ECONOMATToolStripMenuItem.Text = "ECONOMAT"
            MainWindow.TECHNIQUEToolStripMenuItem.Text = "TECHNIQUE"
            MainWindow.VisiteurToolStripMenuItem.Text = "Gestion des Visites"
            '-------------------------------------------------------------------------------
            MainWindow.GunaAdvenceButtonDashBoard.Text = "DASHBOARD"
            MainWindow.GunaAdvenceButtonPlanning.Text = "PLANNING"
            MainWindow.GunaAdvenceButton27.Text = "ARRIVEES"
            MainWindow.GunaAdvenceButtonEnChambre.Text = "EN CHAMBRE"
            MainWindow.GunaAdvenceButtonDepartsList.Text = "DEPARTS"
            MainWindow.GunaAdvenceButtonAttribuerChambre.Text = "ATTRIBUER CHAMBRE"
            MainWindow.GunaAdvenceButton21.Text = "PETITE CAISSE"
            MainWindow.GunaAdvenceButton33.Text = "CAHIER DES CONSIGNES"
            MainWindow.GunaAdvenceRapports.Text = "RAPPORTS"
            MainWindow.GunaAdvenceButton6.Text = "CARDEX"
            MainWindow.GunaAdvenceButton22.Text = "RECHERCHE"
            MainWindow.GunaAdvenceButton5.Text = "NOUVELLE RESERVATION"
            MainWindow.GunaAdvenceButton4.Text = "MODIFIER RESERVATION"
            MainWindow.GunaAdvenceButton23.Text = "DISPONIBILITES ET TARIFS"
            MainWindow.GunaAdvenceButton24.Text = "PLAN DE CHAMBRE"
            MainWindow.GunaAdvenceButton30.Text = "RAPPORTS"
            MainWindow.GunaRadioButtonChambre.Text = "Hébergement"
            MainWindow.GunaRadioButtonSalleFete.Text = "Salle de fête"
            MainWindow.GunaButtonPayer.Text = "Payer"
            MainWindow.GunaLabel42.Text = "Solde"
            MainWindow.GunaButtonAjouterClient.Text = "Ajouter un client"
            MainWindow.GunaButtonModifierClient.Text = "Modifier client"
            MainWindow.GunaGroupBox5.Text = "Détails du client"
            MainWindow.GunaGroupBoxDetailChambre.Text = "Détails de la chambre"
            MainWindow.GunaGroupBox4.Text = "Période du séjours"
            MainWindow.GunaCheckBoxGratuitee.Text = "Gratuitée"
            MainWindow.GunaLabel4.Text = "Arrivée"
            MainWindow.GunaLabel5.Text = "Départ"
            MainWindow.GunaLabelTempsAFaire.Text = "Total nuuitées"
            MainWindow.GunaLabelLibelleTypeChambreSalle.Text = "Type Chambre"
            MainWindow.GunaLabelNumeroChambre.Text = "Chambre N°"
            MainWindow.GunaButtonLectureDeCarte.Text = "CARTE"
            MainWindow.GunaButtonPreference.Text = "Préférence"
            MainWindow.GunaButtonFactures.Text = "Factures"
            MainWindow.GunaButtonSejours.Text = "Séjours"
            MainWindow.GunaLabelPrixReel.Text = "Prix réel"
            MainWindow.GunaLabel10.Text = "Entreprise"
            '-----------------------------------------------------------------------------------
            MainWindow.ToolStripMenuItemSession.Text = "SESSION"
            MainWindow.BonApprovisionnementToolStripMenuItem.Text = "Approvisionner"
            MainWindow.ChangerMagasinToolStripMenuItem.Text = "Choisir Magasin de Travail"
            MainWindow.ToolStripMenuItem117.Text = "Changer mot de passe"
            MainWindow.FermerCaisseToolStripMenuItem.Text = "Fermer Caisse"
            MainWindow.PETITEToolStripMenuItem.Text = "Petite Caisse"
            MainWindow.OuvrirCaisseToolStripMenuItem.Text = "Ouvrir Caisse"
            MainWindow.ClôturerToolStripMenuItem.Text = "Clôturer"
            MainWindow.ToolStripMenuItemConfig.Text = "CONFIGURATION"
            MainWindow.ToolStripMenuItemServTech.Text = "SERVICE TECHNIQUE"
            MainWindow.ToolStripMenuItemSecurite.Text = "SECURITE"
            MainWindow.ToolStripMenuItem119.Text = "Fermer Session"
            '------------------------------------------------------------------
            MainWindow.GunaFrontDeskLabel.Text = "RESERVATION CHAMBRE"
            MainWindow.ImprimerDocChambreSalle.Text = "Imprimer"
            MainWindow.GunaButtonEnvoyer.Text = "Envoyer"
            MainWindow.GunaButtonQuitter.Text = "Quitter"
            MainWindow.GunaButtonVider.Text = "Vider"
            MainWindow.GunaRadioButtonEmailNon.Text = "Non"
            MainWindow.GunaRadioButtonMailOui.Text = "Oui"
            MainWindow.GunaRadioButtonWhatsAppNon.Text = "Non"
            MainWindow.GunaRadioButtonWhatsAppOui.Text = "Oui"
            MainWindow.GunaCheckBoxAfficherPrix.Text = "Afficher le prix sur la fiche de police"
            MainWindow.GunaButtonAnnulerResa.Text = "Annuler"
            MainWindow.GunaButton25.Text = "Navettes"
            MainWindow.GunaButtonCoChambrier.Text = "Compagnons"
            MainWindow.GunaLabel8.Text = "Nom *"
            MainWindow.GunaLabel131.Text = "DATE DE TRAVAIL : "
            MainWindow.GunaButtonArricherReservation.Text = "Afficher"
            MainWindow.GunaButtonAfficherArrivee.Text = "Afficher"
            MainWindow.GunaButtonEnChambreAfficher.Text = "Afficher"
            MainWindow.GunaButtonAfficherDepart.Text = "Afficher"
            MainWindow.GunaCheckBoxPetitDejeuenerInclus.Text = "Petit Déjeuner inclus"
            MainWindow.GunaCheckBoxTaxeSejour.Text = "Taxe séjour"

            '----------------------------------------------------------------------------------------------

            MainWindow.GunaGroupBoxRoomStatus.Text = "Statuts des Chambres"
            MainWindow.GunaAdvenceButton1.Text = "Rafraichir"
            MainWindow.GunaLabelGraphiques.Text = "Statistiques"
            MainWindow.GunaGroupBoxStatistiques.Text = "Activités du jour"
            MainWindow.GunaGroupBoxArriveDepart.Text = "Arrivés, Départs et Séjours"
            MainWindow.GunaLabel51.Text = "RESERVATIONS"
            MainWindow.GunaAdvenceButtonArrivee.Text = "Arrivées"
            MainWindow.GunaAdvenceButtonDeparts.Text = "Départs"
            MainWindow.GunaAdvenceButtonSejour.Text = "Séjours"
            MainWindow.GunaAdvenceButtonNouvelleReservation.Text = "Nouvelle Resa"
            MainWindow.GunaAdvenceButtonImpression.Text = "Imprimer"
            MainWindow.Quitter.Text = "ACCUEIL"
            MainWindow.GunaLabel95.Text = "REVENU PAR FAMILLE"
            MainWindow.GunaTextBoxHebergementTitre.Text = "Hébergement"
            MainWindow.GunaTextBoxAutresTitre.Text = "Autres"

            MainWindow.GunaLabel97.Text = "STATUTS DES CHAMBRES"
            MainWindow.GunaLabelSale.Text = "Sale"
            MainWindow.GunaLabelEncours.Text = "En cours"
            MainWindow.GunaLabelAinspecter.Text = "A inspecter"
            MainWindow.GunaLabelPropre.Text = "Propre"
            MainWindow.GunaLabelHorsService.Text = "Hors Service"
            MainWindow.GunaLabel113.Text = "TAUX D'OCCUPATION"
            MainWindow.GunaLabel12.Text = "JOURNALIER"
            MainWindow.GunaLabel114.Text = "TAUX D'OCCUPATION PAR TYPE DE CHAMBRE (%)"
            MainWindow.GunaLabelDuMoisDernier.Text = "MOIS DERNIER"
            MainWindow.GunaLabelDuMoisActuel.Text = "MOIS EN COURS"

            '-----------------------------------------------------------
            MainWindow.GunaLabel29.Text = "Nombre"
            MainWindow.GunaLabel30.Text = "Personne(s)"
            MainWindow.GunaLabel31.Text = "Adulte(s)"
            MainWindow.GunaLabel32.Text = "Enfant(s)"
            MainWindow.GunaLabel33.Text = "Tarif de base"

            '--------------------------------------------------------------
            MainWindow.GunaLabelElite.Text = "Elite"
            MainWindow.GunaLabel11.Text = "CNI/NIU"
            MainWindow.GunaCheckBoxReservationDeGroupe.Text = "Réservation de groupe"
            MainWindow.GunaLabel22.Text = "Téléphone"
            MainWindow.GunaLabel21.Text = "Venant de"
            MainWindow.GunaLabel27.Text = "Mode Transport"
            MainWindow.GunaLabel26.Text = "Véhicule N°"
            MainWindow.GunaLabel80.Text = "Type Réservation"
            MainWindow.GunaLabel79.Text = "Source réservation"
            MainWindow.GunaLabel46.Text = "Paiement"
            MainWindow.GunaLabel158.Text = "DELOGER :"
            MainWindow.GunaLabel160.Text = "ANNULER :"

            MainWindow.GunaLabel23.Text = "Se rendant à"
            MainWindow.GunaLabelPrixSejours.Text = "Prix du séjour"
            MainWindow.GunaGroupBox1.Text = "Instructions de Routage"
            MainWindow.GunaGroupBox6.Text = "Paiement"
            MainWindow.GunaCheckBoxPetitDejRoutage.Text = "Bar / Restaurant" '"Petit Déjeuner"
            MainWindow.GunaCheckBoxChambreRoutage.Text = "Chambre"
            MainWindow.GunaLabel45.Text = "Chambre"
            MainWindow.GunaLabel45.Text = "Chambre"
            MainWindow.GunaLabel39.Text = "Prix des repas"
            MainWindow.GunaLabel40.Text = "Services et produits sup"
            MainWindow.GunaLabel37.Text = "Total hébergement"
            MainWindow.GunaLabel41.Text = "Montant à régler"

            MainWindow.GunaLabel56.Text = "ARRIVEES DU :"
            MainWindow.GunaLabel52.Text = "EN CHAMBRES DU :"
            MainWindow.GunaLabel47.Text = "DEPART(S) DU :"

            '----------------------------------------------------

            MainWindow.GunaButtonMainCouranteJOurnaliere.Text = "MAIN COURANTE (JOURNALIERE) - HEBERGEMENT"
            MainWindow.GunaButtonMainCouranteCummulee.Text = "MAIN COURANTE (CUMUL) - HEBERGEMENT"
            MainWindow.GunaButtonMainCouranteEvents.Text = "MAIN COURANTE (JOURNALIERE) - EVENEMENTS"
            MainWindow.GunaButtonMainCouranteCumulEvents.Text = "MAIN COURANTE (CUMUL) - EVENEMENTS"
            MainWindow.GunaButtonEvenements.Text = "EVENEMENTS"
            MainWindow.GunaButton8.Text = "FACTURES"
            MainWindow.GunaButton1.Text = "INVENTAIRES DES VENTES"
            MainWindow.GunaButtonEnChambre.Text = "VERIFICATION DES SOLDES"
            MainWindow.GunaButton10.Text = "RESERVATIONS"
            MainWindow.GunaButton4.Text = "ATTENDUES"
            MainWindow.GunaButton7.Text = "ARRIVEES"
            MainWindow.GunaButtonRapportDSt.Text = "RAPPORT DST"

            MainWindow.GunaButtonCheckOutReservation.Text = "SEJOURS CLOTURES"
            MainWindow.GunaButton19.Text = "RESERVATIONS ANNULEES"
            MainWindow.GunaButtonResaParSource.Text = "RESERVATIONS PAR SOURCE"
            MainWindow.GunaButtonResaParTypeResa.Text = "RESERVATIONS PAR TYPE"
            MainWindow.GunaButtonNoShow.Text = "NO SHOW & ANNULATION"
            MainWindow.GunaButtonTopPeoducers.Text = "TOP PRODUCERS"
            MainWindow.GunaButton21.Text = "ECARTS TARIFAIRES"
            MainWindow.GunaButtonRapportDayUse.Text = "DAY USE / CONTROLE DES DEPARTS TARDIFS"
            MainWindow.GunaButtonRapportNonDayUse.Text = "SEJOURS / CONTROLE DES DEPARTS TARDIFS"
            MainWindow.GunaButtonEtatDesChambres.Text = "ETAT DES CHAMBRES"
            MainWindow.GunaButton11.Text = "FICHE DE VENTILATION BAR-RESTAURANT"
            MainWindow.GunaButton12.Text = " FICHE D'INVENTAIRE JOURNALIERE BAR"
            MainWindow.GunaButtonStatJournaliere.Text = "STATISTIQUES JOURNALIERE"
            MainWindow.GunaButtonListePetitDejeuner.Text = "LISTE PETIT DEJEUNER"
            MainWindow.GunaButton22.Text = "LISTE DES DEBITEURS"
            MainWindow.GunaButton15.Text = "SITUATION GLOBAL MENSUEL"
            MainWindow.GunaButtonPromoteur.Text = "PROMOTEUR"
            MainWindow.GunaButtonVenteShift.Text = "JOURNAL DES VENTES - SHIFT"
            MainWindow.GunaButtonRapportDesVentes.Text = "JOURNAL DES VENTES CUMUL JOURNALIER"
            MainWindow.GunaButton13.Text = "JOURNAL DES VENTES PERIODIQUES"
            MainWindow.GunaButtonCaisseJournalier.Text = "SITUATION DE CAISSE DU SHIFT"
            MainWindow.GunaButtonCaisseGlobal.Text = "SITUATION DE CAISSE CUMUL JOURNALIER"
            MainWindow.GunaButton14.Text = "SITUATION DE CAISSE PERIODIQUE"
            MainWindow.GunaButton5.Text = "JOURNAL DE PETITE CAISSE"
            MainWindow.GunaButton23.Text = "JOURNAL DES BONS DE COMMANDE"

            MainWindow.GunaButton24.Text = "NAVETTES"
            MainWindow.GunaButtonListePetitDejeuner.Text = "LISTE PETIT DEJEUNER"

            '----------------------------------------------
            MainWindow.TabControlHbergement.TabPages(0).Text = "Enregistrement"
            MainWindow.TabControlHbergement.TabPages(1).Text = "Réservations"
            MainWindow.TabControlHbergement.TabPages(2).Text = "Arrivées"
            MainWindow.TabControlHbergement.TabPages(3).Text = "En Chambre"
            MainWindow.TabControlHbergement.TabPages(4).Text = "Départs"

            MainWindow.TabControlGestionReservation.TabPages(0).Text = "Règlement"
            MainWindow.TabControlGestionReservation.TabPages(1).Text = "Facturation"
            MainWindow.TabControlGestionReservation.TabPages(2).Text = "Documents"
            MainWindow.TabControlGestionReservation.TabPages(3).Text = "Fiche de Manifestation"

            MainWindow.GunaButtonAfficherPlanning.Text = "Afficher"
            MainWindow.Label2.Text = "DISPONIBILITES ET TARIFS"
            MainWindow.GunaButton16.Text = "Afficher"
            MainWindow.GunaButtonEditionDeMasse.Text = "Edition de Masse"
            MainWindow.GunaButton6.Text = "ACCUEIL"

            '------------------------------------------------------------------------------------------------

            MainWindow.TabControlListeDesDocumentsFacturesEtReglement.TabPages(0).Text = "Factures"
            MainWindow.TabControlListeDesDocumentsFacturesEtReglement.TabPages(1).Text = "Reglements"
            MainWindow.TabControlListeDesDocumentsFacturesEtReglement.TabPages(2).Text = "Détails Facture"
            MainWindow.TabControlListeDesDocumentsFacturesEtReglement.TabPages(3).Text = "Autres"
            MainWindow.GunaButtonAffichageDesDocuments.Text = "Afficher"
            MainWindow.GunaButtonRegistreDesVisites.Text = "Registre des Visites"

            MainWindow.ToolStripMenuItemDupliquer.Text = "Dupliquer"
            MainWindow.ToolStripMenuItemSupprimer.Text = "Supprimer"

            MainWindow.GunaButtonPeriodicAccommodationReport.Text = "RAPPORT DES HEBERGEMENTS"
            MainWindow.GunaButton27.Text = "SITUATION NET PAR SERVICE"
            MainWindow.GunaButton15.Text = "SITUATION GLOBAL MENSUEL"

            MainWindow.GunaButtonAfficherDst.Text = "Afficher"
            MainWindow.GunaLabelDu.Text = "Du"
            MainWindow.GunaLabel61.Text = "Au"

        End If

    End Sub

    Public Sub autoLoadEmployee(ByVal actualLanguage As Integer)

        BarRestaurantForm.GunaComboBoxTypeTiers.Items.Clear()

        If actualLanguage = 0 Then
            BarRestaurantForm.GunaComboBoxTypeTiers.Items.Add("Employee")
        ElseIf actualLanguage = 1 Then
            BarRestaurantForm.GunaComboBoxTypeTiers.Items.Add("Personnel")
        End If

        BarRestaurantForm.GunaComboBoxTypeTiers.SelectedIndex = 0

    End Sub

    Public Sub autoLoadSlipType(ByVal actualLanguage As Integer)

        BarRestaurantForm.GunaComboBoxTypeBordereau.Items.Clear()

        If actualLanguage = 0 Then
            'BarRestaurantForm.GunaComboBoxTypeBordereau.Items.Add("Store Requisition")
            BarRestaurantForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.transfert_inter)
        ElseIf actualLanguage = 1 Then
            'BarRestaurantForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.bon_approvisi)
            BarRestaurantForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.transfert_inter)
        End If

        BarRestaurantForm.GunaComboBoxTypeBordereau.SelectedIndex = 0

    End Sub

    Public Sub autoLoadEmployeeMini(ByVal actualLanguage As Integer)

        BarRestaurantCaisseEnregistreuseForm.GunaComboBoxTypeTiers.Items.Clear()

        If actualLanguage = 0 Then
            BarRestaurantCaisseEnregistreuseForm.GunaComboBoxTypeTiers.Items.Add("Employee")
        ElseIf actualLanguage = 1 Then
            BarRestaurantCaisseEnregistreuseForm.GunaComboBoxTypeTiers.Items.Add("Personnel")
        End If

        BarRestaurantCaisseEnregistreuseForm.GunaComboBoxTypeTiers.SelectedIndex = 0

    End Sub

    Public Sub autoLoadSlipTypeMini(ByVal actualLanguage As Integer)

        BarRestaurantCaisseEnregistreuseForm.GunaComboBoxTypeBordereau.Items.Clear()

        If actualLanguage = 0 Then
            BarRestaurantCaisseEnregistreuseForm.GunaComboBoxTypeBordereau.Items.Add("Store Requisition")
        ElseIf actualLanguage = 1 Then
            BarRestaurantCaisseEnregistreuseForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.bon_approvisi)
        End If

        BarRestaurantCaisseEnregistreuseForm.GunaComboBoxTypeBordereau.SelectedIndex = 0

    End Sub
    Public Sub situationClient(ByVal actualLanguage As Integer)

        If actualLanguage = 0 Then

            SituationClientForm.GunaButtonFacturer.Text = "Bill"
            SituationClientForm.GunaButtonPayer.Text = "Cash In"
            SituationClientForm.GunaButton1.Text = "Cancel"
            SituationClientForm.GunaLabelGestCompteGeneraux.Text = "SITUATION OF  :"

            SituationClientForm.GunaLabel23.Text = "Balance"
            SituationClientForm.LabelChambre.Text = "Room"
            SituationClientForm.LabelNomClient.Text = "Client Name"

            SituationClientForm.TransférerToolStripMenuItem.Text = "Transfer"
            SituationClientForm.AnnulerToolStripMenuItem.Text = "Cancel"
            SituationClientForm.RéductionToolStripMenuItem.Text = "Discount"

            SituationClientForm.GunaButtonAnnulerTransfert.Text = "Cancel"
            SituationClientForm.GunaButtonTransferer.Text = "Transfer"

        Else

            SituationClientForm.GunaButtonFacturer.Text = "Facturer"
            SituationClientForm.GunaButtonPayer.Text = "Encaisser"
            SituationClientForm.GunaButton1.Text = "Annuler"
            SituationClientForm.GunaLabelGestCompteGeneraux.Text = "SITUATION DE  :"

            SituationClientForm.GunaLabel23.Text = "Solde"
            SituationClientForm.LabelChambre.Text = "Chambre"
            SituationClientForm.LabelNomClient.Text = "Nom du client"

            SituationClientForm.TransférerToolStripMenuItem.Text = "Transférer"
            SituationClientForm.AnnulerToolStripMenuItem.Text = "Annuler"
            SituationClientForm.RéductionToolStripMenuItem.Text = "Réduction"

            SituationClientForm.GunaButtonAnnulerTransfert.Text = "Annuler"
            SituationClientForm.GunaButtonTransferer.Text = "Transférer"

        End If

    End Sub

    Public Sub folio(ByVal actualLanguage As Integer)

        If actualLanguage = 0 Then

            FolioForm.GunaButtonCloturerFolio1.Text = "Close"
            FolioForm.GunaButtonCloturerFolio2.Text = "Close"
            FolioForm.GunaButtonCloturerFolio3.Text = "Close"
            FolioForm.GunaButtonCloturerFolio4.Text = "Close"

            FolioForm.GunaButtonPayer.Text = "Pay"
            FolioForm.GunaButtonPayerFolio2.Text = "Pay"
            FolioForm.GunaButtonPayerFolio3.Text = "Pay"
            FolioForm.GunaButtonPayerFolio4.Text = "Pay"

            FolioForm.GunaButtonImprimerFolio1.Text = "Print"
            FolioForm.GunaButtonImprimerFolio2.Text = "Print"
            FolioForm.GunaButtonImprimerFolio3.Text = "Print"
            FolioForm.GunaButtonImprimerFolio4.Text = "Print"

            FolioForm.GunaButtonFermer.Text = "Cancel"
            FolioForm.GunaLabel4.Text = "Bill"
            FolioForm.GunaLabelGestCompteGeneraux.Text = "Print Bill :"

            FolioForm.GunaCheckBoxTousLesCompagnons.Text = "All"
            FolioForm.GunaLabel7.Text = "COMPANY"

        Else

            FolioForm.GunaButtonCloturerFolio1.Text = "Clôturer"
            FolioForm.GunaButtonCloturerFolio2.Text = "Clôturer"
            FolioForm.GunaButtonCloturerFolio3.Text = "Clôturer"
            FolioForm.GunaButtonCloturerFolio4.Text = "Clôturer"

            FolioForm.GunaButtonPayer.Text = "Payer"
            FolioForm.GunaButtonPayerFolio2.Text = "Payer"
            FolioForm.GunaButtonPayerFolio3.Text = "Payer"
            FolioForm.GunaButtonPayerFolio4.Text = "Payer"

            FolioForm.GunaButtonImprimerFolio1.Text = "Imprimer"
            FolioForm.GunaButtonImprimerFolio2.Text = "Imprimer"
            FolioForm.GunaButtonImprimerFolio3.Text = "Imprimer"
            FolioForm.GunaButtonImprimerFolio4.Text = "Imprimer"

            FolioForm.GunaButtonFermer.Text = "Fermer"
            FolioForm.GunaLabel4.Text = "Facturer"
            FolioForm.GunaLabelGestCompteGeneraux.Text = "Imprimer Facture :"

            FolioForm.GunaCheckBoxTousLesCompagnons.Text = "Tous"
            FolioForm.GunaLabel7.Text = "ENTREPRISE"

        End If

    End Sub

    Public Sub ZenoLock(ByVal actualLanguage As Integer)

        If actualLanguage = 0 Then

            ZenoLockForm.GunaLabel8.Text = "HOTEL ID"
            ZenoLockForm.GunaLabel10.Text = "CARD N°"
            ZenoLockForm.GunaLabel11.Text = "CARD ID"
            ZenoLockForm.GunaLabel12.Text = "LOCK N°"
            ZenoLockForm.GunaLabel13.Text = "NIGHT(S)"
            ZenoLockForm.GunaLabel16.Text = "COMMENT"
            ZenoLockForm.GunaLabel15.Text = "DEPARTURE"
            ZenoLockForm.GunaLabel9.Text = "ARRIVAL"
            ZenoLockForm.GunaCheckBoxVisite.Text = "VISIT"
            ZenoLockForm.STATUS.Text = "RESULTS"
            ZenoLockForm.GunaLabel17.Text = "STATUS"
            ZenoLockForm.GunaButtonChemin.Text = "Save Path"
            ZenoLockForm.GunaCheckBoxConfiguration.Text = "SETTINGS"
            ZenoLockForm.GunaLabel3.Text = "ENCODE FOR VISIT"
            ZenoLockForm.GunaLabel6.Text = "ROOM TYPE: "
            ZenoLockForm.GunaLabel19.Text = "LAST : "
            ZenoLockForm.GunaLabel14.Text = "ROOM N° : "
            ZenoLockForm.GunaLabel4.Text = "ROOM TYPE : "
            ZenoLockForm.GunaLabel5.Text = "PRICE : "
            ZenoLockForm.GunaLabel7.Text = "CLIENT : "
            ZenoLockForm.GunaLabelGestCompteGeneraux.Text = "ACCESS CARD MANAGEMENT"

            ZenoLockForm.GunaButton2.Text = "Close"
            ZenoLockForm.B_Start.Text = "Start Session"
            ZenoLockForm.B_End.Text = "End Session"
            ZenoLockForm.B_NewKey.Text = "Encode Card"
            ZenoLockForm.B_ReadKey.Text = "Read Card"
            ZenoLockForm.B_DupKey.Text = "Duplicate Card"
            ZenoLockForm.B_CheckOut.Text = "Check Out"
            ZenoLockForm.B_EraseKey.Text = "Erase Card"

        ElseIf actualLanguage = 1 Then

            ZenoLockForm.GunaLabel8.Text = "ID HOTEL"
            ZenoLockForm.GunaLabel10.Text = "N° CARTE"
            ZenoLockForm.GunaLabel11.Text = "ID CARTE"
            ZenoLockForm.GunaLabel12.Text = "LOCK N°"
            ZenoLockForm.GunaLabel13.Text = "NUIT(S)"
            ZenoLockForm.GunaLabel16.Text = "COMMENTAIRE"
            ZenoLockForm.GunaLabel15.Text = "DATE DEPART"
            ZenoLockForm.GunaLabel9.Text = "DATE ARRIVEE"
            ZenoLockForm.GunaCheckBoxVisite.Text = "VISITE"
            ZenoLockForm.STATUS.Text = "RESULTATS"
            ZenoLockForm.GunaLabel17.Text = "STATUTS"
            ZenoLockForm.GunaButtonChemin.Text = "Enregistrer chemin"
            ZenoLockForm.GunaCheckBoxConfiguration.Text = "Paramètres"
            ZenoLockForm.GunaLabel3.Text = "ENCODAGE POUR VISITE"
            ZenoLockForm.GunaLabel6.Text = "TYPE CHAMBRE : "
            ZenoLockForm.GunaLabel19.Text = "DUREE : "
            ZenoLockForm.GunaLabel14.Text = "N° CHAMBRE : "
            ZenoLockForm.GunaLabel4.Text = "TYPE CHAMBRE : "
            ZenoLockForm.GunaLabel5.Text = "PRIX : "
            ZenoLockForm.GunaLabel7.Text = "CLIENT : "
            ZenoLockForm.GunaLabelGestCompteGeneraux.Text = "GESTION DES CARTES D'ACCES"

            ZenoLockForm.GunaButton2.Text = "Fermer"
            ZenoLockForm.B_Start.Text = "Démarrer Session"
            ZenoLockForm.B_End.Text = "Terminer Session"
            ZenoLockForm.B_NewKey.Text = "Encoder carte"
            ZenoLockForm.B_ReadKey.Text = "Lire Carte"
            ZenoLockForm.B_DupKey.Text = "Dupliquer Carte"
            ZenoLockForm.B_CheckOut.Text = "Check Out"
            ZenoLockForm.B_EraseKey.Text = "Effacer Carte"

        End If

    End Sub

    Public Sub user(ByVal actualLanguage As Integer)

        If actualLanguage = 0 Then

            UserForm.TabControlUtilisateurProfil.TabPages(0).Text = "Form"
            UserForm.TabControlUtilisateurProfil.TabPages(1).Text = "Access Rights"
            UserForm.TabControlUtilisateurProfil.TabPages(2).Text = "Access Rights Continuity"
            UserForm.TabControlUtilisateurProfil.TabPages(3).Text = "Profiles"

            UserForm.GunaGroupBox1.Text = "Creation of users"
            UserForm.GunaLabel2.Text = "user code"
            UserForm.GunaLabel1.Text = "User Name"
            UserForm.GunaLabel4.Text = "Agency"
            UserForm.GunaLabel7.Text = "user Profile"
            UserForm.GunaLabel5.Text = "Password"
            UserForm.GunaLabel6.Text = "Password Confirmation"
            UserForm.GunaLabel8.Text = "Access Period"
            UserForm.GunaLabel3.Text = "User Brand"
            UserForm.GunaLabelGestUsers.Text = "USER MANAGEMENT"

            '----------------------------------------------------------------------
            UserForm.GunaCheckBoxReception.Text = "RECEPTION"
            UserForm.GunaCheckBoxReservation.Text = "BOOKING"
            UserForm.GunaCheckBoxServiceEtage.Text = "HOUSE KEEPING"
            UserForm.GunaCheckBoxCompatbilite.Text = "ACCOUNTING AND FINANCE"
            UserForm.GunaCheckBoxEconomat.Text = "PURCHASE"
            UserForm.GunaCheckBoxBarRestaurant.Text = "BAR / RESTAURANT"
            UserForm.GunaCheckBoxMenuTechnique.Text = "TECHNICAL"
            UserForm.GunaCheckBoxCaissesMagasins.Text = "CASHIER AND STORE"
            UserForm.GunaCheckBoxAdministration.Text = "ADMINISTRATION"

            UserForm.GunaCheckBoxDashboard.Text = "DASHBOARD"
            UserForm.GunaCheckBoxPlanning.Text = "PLANNING"
            UserForm.GunaCheckBoxArrivee.Text = "ARRIVAL"
            UserForm.GunaCheckBoxEnChambre.Text = "IN HOUSE"
            UserForm.GunaCheckBoxDeparts.Text = "OUT DUE"
            UserForm.GunaCheckBoxAttribuerChambre.Text = "ASSIGN ROOM"
            UserForm.GunaCheckBoxMessage.Text = "INSTRUCTIONS BOOK"
            UserForm.GunaCheckBoxFacuration.Text = "PETTY CASH"
            UserForm.GunaCheckBoxCloture.Text = "NIGHT AUDIT"
            UserForm.GunaCheckBoxRapports.Text = "REPORT"
            UserForm.GunaCheckBoxPromoteur.Text = "PROMOTER"

            UserForm.GunaCheckBoxCardex.Text = "PROFILES"
            UserForm.GunaCheckBoxRechercheResa.Text = "SEARCH BOOKING"
            UserForm.GunaCheckBoxNouvelleResa.Text = "NEW BOOKING"
            UserForm.GunaCheckBoxModifierResa.Text = "EDIT BOOKING"
            UserForm.GunaCheckBoxFichePolice.Text = "GUEST REGISTRATION"
            UserForm.GunaCheckBoxDisponibilite.Text = "AVAILABILITY AND RATES"
            UserForm.GunaCheckBoxPlanChambre.Text = "ROOM PLAN"
            UserForm.GunaCheckBoxRapportResa.Text = "REPORTS"

            UserForm.GunaCheckBoxStatutsChambre.Text = "ROOM STATUS"
            UserForm.GunaCheckBoxHistoriques.Text = "ROOM HSITORY"
            UserForm.GunaCheckBoxNettoyage.Text = "CLEANING"
            UserForm.GunaCheckBoxDebutNettoyage.Text = "START CLEANING"
            UserForm.GunaCheckBoxFinNettoyage.Text = "END CLEANING"
            UserForm.GunaCheckBoxControllerNettoyage.Text = "CONTROL CLEANING"
            UserForm.GunaCheckBoxEtatChambres.Text = "ROOMS STATE"
            UserForm.GunaCheckBoxHS.Text = "OUT OF ORDER"
            UserForm.GunaCheckBoxObjets.Text = "FOUND AND LOST OBJECTS"
            UserForm.GunaCheckBoxRapportServiceEtage.Text = "REPORTS"

            UserForm.GunaCheckBox28.Text = "ACCOUNT MANAGEMENT"
            UserForm.GunaCheckBox30.Text = "DEBTORS"
            UserForm.GunaCheckBoxReglementEtLettrage.Text = "ACCOUNT RECEIVING (AR)"
            UserForm.GunaCheckBox34.Text = "DEPOSIT"
            UserForm.GunaCheckBox36.Text = "REPORTS"
            UserForm.GunaCheckBox4.Text = "BILLS"
            UserForm.GunaCheckBox3.Text = "MAIN CASHIER REGISTER"
            UserForm.GunaCheckBox2.Text = "AGED BIILS"
            UserForm.GunaCheckBox5.Text = "RELAUNCHES"

            UserForm.GunaCheckBoxMovt.Text = "MOVEMENT"
            UserForm.GunaCheckBoxBC.Text = "PURCHASE ORDER"
            UserForm.GunaCheckBoxBR.Text = "DELIVERY ORDER"
            UserForm.GunaCheckBoxControler.Text = "CONTROL"
            UserForm.GunaCheckBoxVerification.Text = "VERIFICATION"
            UserForm.GunaCheckBoxValider.Text = "VALIDATE"
            UserForm.GunaCheckBoxCommander.Text = "ORDER"
            UserForm.GunaCheckBoxMagasins.Text = "STORES"
            UserForm.GunaCheckBoxFicheTechnique.Text = "TECHNICAL SHEET"
            UserForm.GunaCheckBoxlisteDesBons.Text = "VOUCHER LIST"
            UserForm.GunaCheckBoxFournisseur.Text = "SUPPLIERS"
            UserForm.GunaCheckBoxEconomatRapports.Text = "REPORTS"
            UserForm.GunaCheckBoxInventaire.Text = "INVENTORY"
            UserForm.GunaCheckBoxFicheProduit.Text = "PRODUCT SHEET"

            UserForm.GunaCheckBoxClientEnchambre.Text = "IN HOUSE"
            UserForm.GunaCheckBoxEvents.Text = "EVENTS"
            UserForm.GunaCheckBoxComptoire.Text = "WALK IN"
            UserForm.GunaCheckBoxBarRapports.Text = "REPORTS"

            UserForm.GunaCheckBoxFamillePanne.Text = "BREAKDOWN FAMILY"
            UserForm.GunaCheckBoxSousFamillePanne.Text = "BREAKDOWN SUB FAMILY"
            UserForm.GunaCheckBoxDemandeIntervention.Text = "SEEK INTERVENTION"
            UserForm.GunaCheckBoxIntervention.Text = "INTERVENTION"
            UserForm.GunaCheckBoxTechniqueRapports.Text = "REPORTS"

            UserForm.GunaCheckBoxPetiteCaisse.Text = "PETTY CASH FLOAT"
            UserForm.GunaCheckBoxGrandeCaisse.Text = "CASH REGISTER"
            UserForm.GunaCheckBoxCaissePrincipaleEcriture.Text = "CASH REGISTER WRITING"
            UserForm.GunaCheckBoxCaissePrincipaleLecture.Text = "CASH REGISTER READING"
            UserForm.GunaCheckBoxPetitMagasin.Text = "SMALL STORE"
            UserForm.GunaCheckBoxGrandMagasin.Text = "BIG STORE"

            UserForm.GunaCheckBoxSession.Text = "SESSION"
            UserForm.GunaCheckBoxConfiguration.Text = "SETTINGS"
            UserForm.GunaCheckBoxAdminServiceTechnique.Text = "TECHNICAL"
            UserForm.GunaCheckBoxSecurite.Text = "SECURITY"
            UserForm.GunaCheckBox1.Text = "CORRECTION / DELETE"

            UserForm.GunaButtonEnregistrerProfil.Text = "Create"
            UserForm.GunaButton1.Text = "Fermer"
            UserForm.GunaButtonEnregistrer.Text = "Save"

            UserForm.GunaLabel16.Text = "PROFILE CODE"
            UserForm.GunaLabel9.Text = "PROFILE NAME"
            UserForm.GunaCheckBoxBarRapports.Text = "REPORTS"

            UserForm.GunaCheckBox6.Text = "RECEIPTS MANAGEMENT"
            UserForm.GunaCheckBox7.Text = "REQUISITION"

            UserForm.SupprimerToolStripMenuItem.Text = "Delete"
            UserForm.SupprimerToolStripMenuItem1.Text = "Delete"
            UserForm.ToolStripMenuItem1.Text = "Delete"
            UserForm.GunaButton1.Text = "Close"

            UserForm.GunaGroupBox2.Text = "Multiple Profil"
            UserForm.GunaLabel12.Text = "User"
            UserForm.GunaLabel11.Text = "User Profil"
            UserForm.GunaButtonAjouter.Text = "Add"

        ElseIf actualLanguage = 1 Then

            UserForm.GunaGroupBox1.Text = "Création d'Utilisateurs"
            UserForm.GunaLabel2.Text = "Code Utilisateur"
            UserForm.GunaLabel1.Text = "Nom Utilisateur"
            UserForm.GunaLabel4.Text = "Agence de travail"
            UserForm.GunaLabel7.Text = "Profil utilisateur"
            UserForm.GunaLabel5.Text = "Mot de Passe"
            UserForm.GunaLabel6.Text = "Confirmer Mot de Passe"
            UserForm.GunaLabel8.Text = "Période d'accès"
            UserForm.GunaLabel3.Text = "Griffe utilisateur"
            UserForm.GunaLabelGestUsers.Text = "GESTION DES UTILISATEURS"

            '----------------------------------------------------------------------
            UserForm.GunaCheckBoxReception.Text = "RECEPTION"
            UserForm.GunaCheckBoxReservation.Text = "RESERVATION"
            UserForm.GunaCheckBoxServiceEtage.Text = "SERVICE D'ETAGE"
            UserForm.GunaCheckBoxCompatbilite.Text = "COMPTABILITES ET FINANCES"
            UserForm.GunaCheckBoxEconomat.Text = "ECONNOMAT"
            UserForm.GunaCheckBoxBarRestaurant.Text = "BAR / RESTAURANT"
            UserForm.GunaCheckBoxMenuTechnique.Text = "TECHNIQUE"
            UserForm.GunaCheckBoxCompatbilite.Text = "ACCOUNTING AND FINANCE"
            UserForm.GunaCheckBoxCaissesMagasins.Text = "CAISSE ET MAGASIN"
            UserForm.GunaCheckBoxAdministration.Text = "ADMINISTRATION"

            UserForm.GunaCheckBoxDashboard.Text = "DASHBOARD"
            UserForm.GunaCheckBoxPlanning.Text = "PLANNING"
            UserForm.GunaCheckBoxArrivee.Text = "ARRIVEES"
            UserForm.GunaCheckBoxEnChambre.Text = "EN CHAMBRE"
            UserForm.GunaCheckBoxDeparts.Text = "DEPARTS"
            UserForm.GunaCheckBoxAttribuerChambre.Text = "ATTRIBUER CHAMBRE"
            UserForm.GunaCheckBoxMessage.Text = "CAHIER DES CONSIGNES"
            UserForm.GunaCheckBoxFacuration.Text = "PETITE CAISSE"
            UserForm.GunaCheckBoxCloture.Text = "CLOTURE"
            UserForm.GunaCheckBoxRapports.Text = "RAPPORTS"
            UserForm.GunaCheckBoxPromoteur.Text = "PROMOTEUR"

            UserForm.GunaCheckBoxCardex.Text = "CARDEX"
            UserForm.GunaCheckBoxRechercheResa.Text = "RECHERCHER RESERVATION"
            UserForm.GunaCheckBoxNouvelleResa.Text = "NOUVELLE RESERVATION"
            UserForm.GunaCheckBoxModifierResa.Text = "MODIFIER RESERVAION"
            UserForm.GunaCheckBoxFichePolice.Text = "FICHE DE POLICE"
            UserForm.GunaCheckBoxDisponibilite.Text = "DISPONIBILITES ET TARIFS"
            UserForm.GunaCheckBoxPlanChambre.Text = "PLAN DE CHAMBRE"
            UserForm.GunaCheckBoxRapportResa.Text = "RAPPORTS"

            UserForm.GunaCheckBoxStatutsChambre.Text = "STATUTS DES CHAMBRES"
            UserForm.GunaCheckBoxHistoriques.Text = "HISTORIQUES DES CHAMBRES"
            UserForm.GunaCheckBoxNettoyage.Text = "NETTOYAGE"
            UserForm.GunaCheckBoxDebutNettoyage.Text = "DEBUT NETTOYAGE"
            UserForm.GunaCheckBoxFinNettoyage.Text = "FIN NETTOYAGE"
            UserForm.GunaCheckBoxControllerNettoyage.Text = "CONTROLER NETTOYAGE"
            UserForm.GunaCheckBoxEtatChambres.Text = "ETAT DES CHAMBRES"
            UserForm.GunaCheckBoxHS.Text = "Hors Service"
            UserForm.GunaCheckBoxObjets.Text = "OBJETS TROUVES / PERDUS"
            UserForm.GunaCheckBoxRapportServiceEtage.Text = "RAPPORTS"

            UserForm.GunaCheckBox28.Text = "GESTION DES COMPTES"
            UserForm.GunaCheckBox30.Text = "DEBITEURS"
            UserForm.GunaCheckBoxReglementEtLettrage.Text = "REGLEMENTS ET LETTRAGE"
            UserForm.GunaCheckBox34.Text = "CAUTIONS"
            UserForm.GunaCheckBox36.Text = "RAPPORTS"
            UserForm.GunaCheckBox4.Text = "FACTURES"
            UserForm.GunaCheckBox3.Text = "CAISSE"
            UserForm.GunaCheckBox2.Text = "FACTURES AGEES"
            UserForm.GunaCheckBox5.Text = "RELANCES"

            UserForm.GunaCheckBoxMovt.Text = "MOUVEMENT"
            UserForm.GunaCheckBoxBC.Text = GlobalVariable.bon_cmd
            UserForm.GunaCheckBoxBR.Text = "BON DE RECEPTION"
            UserForm.GunaCheckBoxControler.Text = "CONTROLER"
            UserForm.GunaCheckBoxVerification.Text = "VERIFICATION"
            UserForm.GunaCheckBoxValider.Text = "VALIDER"
            UserForm.GunaCheckBoxCommander.Text = "COMMANDER"
            UserForm.GunaCheckBoxMagasins.Text = "MAGASINS"
            UserForm.GunaCheckBoxFicheTechnique.Text = "FICHES TECHNIQUES"
            UserForm.GunaCheckBoxlisteDesBons.Text = "LISTE DES BONS"
            UserForm.GunaCheckBoxFournisseur.Text = "FOURNISSEURS"
            UserForm.GunaCheckBoxEconomatRapports.Text = "RAPPORTS"
            UserForm.GunaCheckBoxInventaire.Text = GlobalVariable.bon_requisition
            UserForm.GunaCheckBoxFicheProduit.Text = "FICHE DE PRODUIT"

            UserForm.GunaCheckBoxClientEnchambre.Text = "EN CHAMBRE"
            UserForm.GunaCheckBoxEvents.Text = "EVENEMENTIEL"
            UserForm.GunaCheckBoxComptoire.Text = "AU COMPTANT"
            UserForm.GunaCheckBoxBarRapports.Text = "RAPPORTS"

            UserForm.GunaCheckBoxFamillePanne.Text = "FAMILLE PANNE"
            UserForm.GunaCheckBoxSousFamillePanne.Text = "FAMILLE SOUS PANNE"
            UserForm.GunaCheckBoxDemandeIntervention.Text = "DEMANDE INTERVENTION"
            UserForm.GunaCheckBoxIntervention.Text = "INTERVENTION"
            UserForm.GunaCheckBoxTechniqueRapports.Text = "RAPPORTS"

            UserForm.GunaCheckBoxPetiteCaisse.Text = "PETITE CAISSE"
            UserForm.GunaCheckBoxGrandeCaisse.Text = "GRANDE CAISSE"
            UserForm.GunaCheckBoxCaissePrincipaleEcriture.Text = "CAISSE PRINCIPALE ECRITURE"
            UserForm.GunaCheckBoxCaissePrincipaleLecture.Text = "CAISSE PRINCIPALE LECTURE"
            UserForm.GunaCheckBoxPetitMagasin.Text = "PETIT MAGASIN"
            UserForm.GunaCheckBoxGrandMagasin.Text = "GRAND MAGASIN"

            UserForm.GunaCheckBoxSession.Text = "SESSION"
            UserForm.GunaCheckBoxConfiguration.Text = "CONFIGURATIONS"
            UserForm.GunaCheckBoxAdminServiceTechnique.Text = "SERVICE TECHNIQUE"
            UserForm.GunaCheckBoxSecurite.Text = "SECURITE"
            UserForm.GunaCheckBox1.Text = "CORRECTION / SUPPRESSION"

            UserForm.GunaButtonEnregistrerProfil.Text = "Créer"
            UserForm.GunaButton1.Text = "Fermer"
            UserForm.GunaButtonEnregistrer.Text = "Enregistrer"

            UserForm.GunaLabel16.Text = "CODE DU PROFIL"
            UserForm.GunaLabel9.Text = "NOM DU PROFIL"
            UserForm.GunaCheckBoxBarRapports.Text = "RAPPORTS"

            UserForm.GunaCheckBox6.Text = "GESTION DES BLOC NOTES"
            UserForm.GunaCheckBox7.Text = "APPROVISIONNEMENT"

            UserForm.SupprimerToolStripMenuItem.Text = "Supprimer"
            UserForm.SupprimerToolStripMenuItem1.Text = "Supprimer"

            UserForm.GunaButton1.Text = "Fermer"

        End If

    End Sub

    Public Sub billetage(ByVal actualLanguage As Integer)

        If actualLanguage = 0 Then

            BilletageForm.GunaLabelTitreDeLaFenetre.Text = "TIKECTING"
            BilletageForm.GunaLabel3.Text = "COINS"
            BilletageForm.GunaLabel2.Text = "BANK NOTES"
            BilletageForm.Label5.Text = "CASHIER BALANCE"
            BilletageForm.Label2.Text = "AMOUNT OUT"
            BilletageForm.GunaButtonSaveFacturation.Text = "TRANSFER"
            BilletageForm.GunaLabel70.Text = "NUMBER"
            BilletageForm.GunaLabel69.Text = "BANK NOTE"
            BilletageForm.GunaLabel68.Text = "TOTAL"

            BilletageForm.GunaLabel6.Text = "NUMBER"
            BilletageForm.GunaLabel5.Text = "COINS"
            BilletageForm.GunaLabel4.Text = "TOTAL"

        ElseIf actualLanguage = 1 Then

            BilletageForm.GunaLabelTitreDeLaFenetre.Text = "BILLETERIE"
            BilletageForm.GunaLabel3.Text = "PIECES"
            BilletageForm.GunaLabel2.Text = "BILLETS"
            BilletageForm.Label5.Text = "SOLDE EN CAISSE"
            BilletageForm.Label2.Text = "MONTANT SORTI"
            BilletageForm.GunaButtonSaveFacturation.Text = "TRANSFERER"
            BilletageForm.GunaLabel70.Text = "NOMBRE"
            BilletageForm.GunaLabel69.Text = "COUPURES"
            BilletageForm.GunaLabel68.Text = "TOTAL"

            BilletageForm.GunaLabel6.Text = "NOMBRE"
            BilletageForm.GunaLabel5.Text = "PIECES"
            BilletageForm.GunaLabel4.Text = "TOTAL"

        End If

    End Sub

    Public Sub petiteCaisse(ByVal actualLanguage As Integer)

        If actualLanguage = 0 Then

            PetiteCaisseForm.GunaLabelGestCompteGeneraux.Text = "PETTTY CASH"
            PetiteCaisseForm.LabelMontantAPayer.Text = "Movement Type"
            PetiteCaisseForm.Label6.Text = "Maximum Amount"
            PetiteCaisseForm.Label10.Text = "Reference"
            PetiteCaisseForm.Label1.Text = "Pay Out through"
            PetiteCaisseForm.LabelMotif.Text = "Reason"

            PetiteCaisseForm.Label3.Text = "Amount"
            PetiteCaisseForm.LabelSolde.Text = "Amount Removed"
            PetiteCaisseForm.Label2.Text = "Balance"
            PetiteCaisseForm.GunaButtonOuvertureFermeture.Text = "Close Petty Cash"
            PetiteCaisseForm.GunaButtonImprimerListeDesComptes.Text = "Print"
            PetiteCaisseForm.GunaButtonEnregistrerReglement.Text = "Save"

            PetiteCaisseForm.LabelRef.Text = "Wording"

            PetiteCaisseForm.LabelNomReceveur.Text = "Handed To"
            PetiteCaisseForm.Label9.Text = "Approved By"
            PetiteCaisseForm.LabelCNI.Text = "ID No"

        ElseIf actualLanguage = 1 Then

            PetiteCaisseForm.GunaLabelGestCompteGeneraux.Text = "PETITE CAISSE"
            PetiteCaisseForm.LabelMontantAPayer.Text = "Type de Mouvement"
            PetiteCaisseForm.Label6.Text = "Montant du Plafonds"
            PetiteCaisseForm.Label10.Text = "Référence"
            PetiteCaisseForm.Label1.Text = "Mode de Sortie"
            PetiteCaisseForm.LabelMotif.Text = "Motif"

            PetiteCaisseForm.Label3.Text = "Montant"
            PetiteCaisseForm.LabelSolde.Text = "Montant retiré"
            PetiteCaisseForm.Label2.Text = "Solde en caisse"
            PetiteCaisseForm.GunaButtonOuvertureFermeture.Text = "Fermer Caisse"
            PetiteCaisseForm.GunaButtonImprimerListeDesComptes.Text = "Imprimer"
            PetiteCaisseForm.GunaButtonEnregistrerReglement.Text = "Enregistrer"


            PetiteCaisseForm.LabelRef.Text = "Libéllé"
            PetiteCaisseForm.LabelNomReceveur.Text = "Nom du receveur"
            PetiteCaisseForm.Label9.Text = "APPROUVE PAR"
            PetiteCaisseForm.LabelCNI.Text = "CNI"

        End If

    End Sub

    Public Sub bonApprovisionnement(ByVal actualLangauge As Integer)

        If actualLangauge = 0 Then

            BonApprovisionnementForm.TabControlEconomat.TabPages(0).Text = "Slip"
            BonApprovisionnementForm.GunaLabel89.Text = "Slip type"
            BonApprovisionnementForm.GunaGroupBoxCreationBordereau.Text = "Slip Creation"
            BonApprovisionnementForm.GunaLabelTitreDeLaFenetreBonApp.Text = "STORE REQUISITION"
            BonApprovisionnementForm.GunaLabelDateDeTravailLabel.Text = "WORKING DATE"
            BonApprovisionnementForm.GunaLabel93.Text = "Slip Wording"
            BonApprovisionnementForm.GunaGroupBoxListeDesBordereaux.Text = "Slip Content"
            BonApprovisionnementForm.Label6.Text = "COST AMOUNT"
            BonApprovisionnementForm.Label8.Text = "SELLING AMOUNT"
            BonApprovisionnementForm.GunaButtonImpressionDirecte.Text = "Print"
            BonApprovisionnementForm.GunaButtonEnregistrer.Text = "Emit"
            BonApprovisionnementForm.GunaButtonAjouterLigne.Text = "Add"
            BonApprovisionnementForm.GunaLabelMagasinDeDestination.Text = "Receiving Store"
            BonApprovisionnementForm.Label10.Text = "ITEM"
            BonApprovisionnementForm.LabelQuantite.Text = "QTY"
            BonApprovisionnementForm.LabelCout.Text = "UP"
            BonApprovisionnementForm.Label1.Text = "UNIT"
            BonApprovisionnementForm.GunaCheckBoxLecteurRFID.Text = "RFID reader"
            BonApprovisionnementForm.Label12.Text = "Qty Seuile"
            BonApprovisionnementForm.Label14.Text = "Qty Big Unit"
            BonApprovisionnementForm.Label2.Text = "Qty Small Unit"
            BonApprovisionnementForm.LabelQuantiteEnMagasinSource.Text = "Qty Receiving store"
            BonApprovisionnementForm.LabelQteEnMagasinDeDestination.Text = "Qty Receiving store"

            BonApprovisionnementForm.GunaButton1.Text = "New"
            BonApprovisionnementForm.LabelBon.Text = "STORE REQUISITION"

        ElseIf actualLangauge = 1 Then

            BonApprovisionnementForm.TabControlEconomat.TabPages(0).Text = "Bordereau"
            BonApprovisionnementForm.GunaGroupBoxCreationBordereau.Text = "Création de Bordereau"
            BonApprovisionnementForm.GunaLabel89.Text = "Type de Bordereau"
            BonApprovisionnementForm.GunaLabelTitreDeLaFenetreBonApp.Text = "DEMANDE APPROVISIONNEMENT"
            BonApprovisionnementForm.GunaLabelDateDeTravailLabel.Text = "DATE DE TRAVAIL"
            BonApprovisionnementForm.GunaLabel93.Text = "Libellé Bordereau"
            BonApprovisionnementForm.GunaGroupBoxListeDesBordereaux.Text = "Contenu du Bordereau"
            BonApprovisionnementForm.Label6.Text = "MONTANT ACHAT"
            BonApprovisionnementForm.Label8.Text = "MONTANT VENTE"
            BonApprovisionnementForm.GunaButtonImpressionDirecte.Text = "Imprimer"
            BonApprovisionnementForm.GunaButtonEnregistrer.Text = "Emettre"
            BonApprovisionnementForm.GunaButtonAjouterLigne.Text = "Ajouter"
            BonApprovisionnementForm.GunaLabelMagasinDeDestination.Text = "Receiving Store"
            BonApprovisionnementForm.Label10.Text = "ARTICLE"
            BonApprovisionnementForm.LabelQuantite.Text = "QTE"
            BonApprovisionnementForm.LabelCout.Text = "PU"
            BonApprovisionnementForm.Label1.Text = "UNITE"
            BonApprovisionnementForm.GunaCheckBoxLecteurRFID.Text = "Lecteur RFID"
            BonApprovisionnementForm.Label12.Text = "Qté Seuile"
            BonApprovisionnementForm.Label14.Text = "Qté Gde Unité"
            BonApprovisionnementForm.Label2.Text = "Qté Pte Unité"
            BonApprovisionnementForm.LabelQuantiteEnMagasinSource.Text = "Qté Magasin Source"
            BonApprovisionnementForm.LabelQteEnMagasinDeDestination.Text = "Qté Magasin Destination"
            BonApprovisionnementForm.GunaButton1.Text = "Nouveau"
            BonApprovisionnementForm.LabelBon.Text = "BON D'APPROVISIONNEMENT"

        End If

        autoLoadEmployeeRecep(actualLangauge)

        autoLoadSlipTypeRecep(actualLangauge)

    End Sub

    Public Sub autoLoadEmployeeRecep(ByVal actualLanguage As Integer)

        BonApprovisionnementForm.GunaComboBoxTypeTiers.Items.Clear()

        If actualLanguage = 0 Then
            BonApprovisionnementForm.GunaComboBoxTypeTiers.Items.Add("Employee")
        ElseIf actualLanguage = 1 Then
            BonApprovisionnementForm.GunaComboBoxTypeTiers.Items.Add("Personnel")
        End If

        BonApprovisionnementForm.GunaComboBoxTypeTiers.SelectedIndex = 0

    End Sub

    Public Sub autoLoadSlipTypeRecep(ByVal actualLanguage As Integer)

        BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Clear()

        If actualLanguage = 0 Then
            BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.transfert_inter)
            BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.sortie_exceptionnelle)
        ElseIf actualLanguage = 1 Then
            BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.transfert_inter)
            BonApprovisionnementForm.GunaComboBoxTypeBordereau.Items.Add(GlobalVariable.sortie_exceptionnelle)
        End If

        BonApprovisionnementForm.GunaComboBoxTypeBordereau.SelectedIndex = 0

    End Sub

    Public Sub caisseOuverteAlaClot(ByVal actualLangauge As Integer)

        If actualLangauge = 0 Then
            CaisseOuverteAlaCloture.GunaLabelTitreDeLaFenetre.Text = "OPENED CASH REGISTER MANAGEMENT"
        ElseIf actualLangauge = 1 Then
            CaisseOuverteAlaCloture.GunaLabelTitreDeLaFenetre.Text = "GESTION DES CAISSES OUVERTES"
        End If

    End Sub

    Public Sub venteVsReglement(ByVal actualLangauge As Integer)

        If actualLangauge = 0 Then

            ComparaisonVenteReglement.GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail
            ComparaisonVenteReglement.GunaButtonEquilibrer.Text = "EQUILIBRATE"
            ComparaisonVenteReglement.GunaButtonAnnuler.Text = "CANCEL"
            ComparaisonVenteReglement.GunaLabel2.Text = "SALES"
            ComparaisonVenteReglement.GunaLabel3.Text = "PAIEMENTS"
            ComparaisonVenteReglement.GunaLabel4.Text = "RECEIPT DETAILS"
            ComparaisonVenteReglement.GunaLabelLabelTransfert.Text = "TRANSFER TO PAYMASTER"
            ComparaisonVenteReglement.GunaLabelTitreDeLaFenetre.Text = "PAIEMENTS VS SALES"
            ComparaisonVenteReglement.GunaButtonTransfertPaymaster.Text = "TRANSFER"

        ElseIf actualLangauge = 1 Then

            ComparaisonVenteReglement.GunaLabelDateDeTravail.Text = GlobalVariable.DateDeTravail
            ComparaisonVenteReglement.GunaButtonEquilibrer.Text = "EQUILIBRER"
            ComparaisonVenteReglement.GunaButtonAnnuler.Text = "ANNULER"
            ComparaisonVenteReglement.GunaLabel2.Text = "VENTES"
            ComparaisonVenteReglement.GunaLabel3.Text = "ENCAISSEMENTS"
            ComparaisonVenteReglement.GunaLabel4.Text = "DETAILS D'UN BLOC NOTE"
            ComparaisonVenteReglement.GunaLabelLabelTransfert.Text = "TRANSFERER VERS LE PAYMASTER"
            ComparaisonVenteReglement.GunaLabelTitreDeLaFenetre.Text = "ENCAISSEMENTS VS VENTES"
            ComparaisonVenteReglement.GunaButtonTransfertPaymaster.Text = "TRANSFERER"

        End If

    End Sub

    Public Sub cautionRembours(ByVal actualLangauge As Integer)

        If actualLangauge = 0 Then

            CautionRemboursement.GunaLabelMontantARembourser.Text = "Amount to Pay back : "
            CautionRemboursement.GunaButtonRembourser.Text = "Pay Back"
            CautionRemboursement.GunaLabelmOTIF.Text = "Reason for partial pay back of arrhes"

        Else
            CautionRemboursement.GunaLabelMontantARembourser.Text = "Montant à Rembourser : "
            CautionRemboursement.GunaButtonRembourser.Text = "Rembourser"
            CautionRemboursement.GunaLabelmOTIF.Text = "Raison du remboursement partielle de la caution"

        End If

    End Sub

    Public Sub TransfertDeClientEntreCaissier(ByVal actualLangauge As Integer)

        If actualLangauge = 0 Then

            TransfertDeClientEntreCaissierForm.GunaLabel2.Text = "CHOOSING A CASHIER"
            TransfertDeClientEntreCaissierForm.GunaLabel4.Text = "Choose a cashier"
            TransfertDeClientEntreCaissierForm.GunaButtonEnregistrer.Text = "Transfer"

        Else

            TransfertDeClientEntreCaissierForm.GunaLabel2.Text = "SELECTION DE CAISSIER"
            TransfertDeClientEntreCaissierForm.GunaLabel4.Text = "Choisir un caissier"
            TransfertDeClientEntreCaissierForm.GunaButtonEnregistrer.Text = "Transférer"

        End If

    End Sub

    Public Sub UniteDeComptage(ByVal actualLangauge As Integer)

        If actualLangauge = 0 Then

            UniteDeComptageForm.GunalabelUniteDecComptage.Text = "UNIT MANAGEMENT"
            UniteDeComptageForm.TabControl1.TabPages(0).Text = "Descrition of unit"
            UniteDeComptageForm.TabControl1.TabPages(1).Text = "List of units"
            UniteDeComptageForm.GunaButton1.Text = "Close"
            UniteDeComptageForm.GunaButtonEnregistrer.Text = "Save"
            UniteDeComptageForm.GunaLabel7.Text = "Unit for"
            UniteDeComptageForm.GunaLabel4.Text = "Selling unit Name"
            UniteDeComptageForm.GunaLabelCodeUniteDestockage.Text = "Selling unit code"
            UniteDeComptageForm.GunaLabel3.Text = "Storage unit name"
            UniteDeComptageForm.GunaLabel2.Text = "Storage unit code"
            UniteDeComptageForm.GunaLabel6.Text = "conversion value"
            UniteDeComptageForm.ImprimerToolStripMenuItemSupressionCaisse.Text = "Delete"
            UniteDeComptageForm.GunaLabel5.Text = "NB : STORAGE UNIT = SELLING UNIT * CONVERSION VALUE"

        Else

            UniteDeComptageForm.GunalabelUniteDecComptage.Text = "GESTION DES CONDITIONNEMENTS"
            UniteDeComptageForm.TabControl1.TabPages(0).Text = "Description Unité de conditionnement"
            UniteDeComptageForm.TabControl1.TabPages(1).Text = "Liste des Unité de conditionnement"
            UniteDeComptageForm.GunaButton1.Text = "Fermer"
            UniteDeComptageForm.GunaButtonEnregistrer.Text = "Enregistrer"
            UniteDeComptageForm.GunaLabel7.Text = "Unité pour"
            UniteDeComptageForm.GunaLabel4.Text = "Libellé Unité de Destockage"
            UniteDeComptageForm.GunaLabelCodeUniteDestockage.Text = "Code Unité de Destockage"
            UniteDeComptageForm.GunaLabel3.Text = "Libellé Unité de Stockage"
            UniteDeComptageForm.GunaLabel2.Text = "Code Unité de Stockage"
            UniteDeComptageForm.GunaLabel6.Text = "Valeur de conversion"
            UniteDeComptageForm.GunaLabel5.Text = "NB : UNITE DE  STOCKAGE = UNITE DE DESTOCKAGE * VALEUR DE CONVERSION"

            UniteDeComptageForm.ImprimerToolStripMenuItemSupressionCaisse.Text = "Supprimer"

        End If

        autoLoadUnitType(actualLangauge)

    End Sub

    Public Sub autoLoadUnitType(ByVal actualLangauge As Integer)

        If actualLangauge = 0 Then
            UniteDeComptageForm.GunaComboBoxUnitePour.Items.Add("Others")
            UniteDeComptageForm.GunaComboBoxUnitePour.Items.Add("Shot")
        Else
            UniteDeComptageForm.GunaComboBoxUnitePour.Items.Add("Autres")
            UniteDeComptageForm.GunaComboBoxUnitePour.Items.Add("Consommation")
        End If

    End Sub

    Public Sub autoLoadCivilte(ByVal actualLanguageValue As Integer)

        If actualLanguageValue = 0 Then

            ClientForm.GunaComboBoxCivilite.Items.Add("Mr.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Mrs.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Miss.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Dr.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Me.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Prof.")
            ClientForm.GunaComboBoxCivilite.Items.Add("S.E.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Mgr.")
            ClientForm.GunaComboBoxCivilite.Items.Add("R.P")
            ClientForm.GunaComboBoxCivilite.Items.Add("S.M.")


        ElseIf actualLanguageValue = 1 Then

            ClientForm.GunaComboBoxCivilite.Items.Add("M.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Mme.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Mlle.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Dr.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Me.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Pr.")
            ClientForm.GunaComboBoxCivilite.Items.Add("S.E.")
            ClientForm.GunaComboBoxCivilite.Items.Add("Mgr.")
            ClientForm.GunaComboBoxCivilite.Items.Add("R.P")
            ClientForm.GunaComboBoxCivilite.Items.Add("S.M.")


        End If

    End Sub

    Public Sub clientFormModeReglement(ByVal actualLanguageValue As Integer)

        ClientForm.GunaComboBoxModeReglementPratique.Items.Clear()

        If actualLanguageValue = 1 Then ' FRENCH

            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Espèce") '0
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Chèque") '1
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Carte Bancaire") '2
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Prise en charge") '3
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("MTN Money") '4
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("ORANGE Money") '5
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Avoir") '6
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Virement Bancaire") '9
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Gratuitée") '6


        ElseIf actualLanguageValue = 0 Then 'ENGLISH

            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Cash")
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Cheque")
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Credit Card")
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Taking charge")
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("MTN Money")
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("ORANGE Money")
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Credit Note")
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Bank Transfer")
            ClientForm.GunaComboBoxModeReglementPratique.Items.Add("Free")

        End If

    End Sub

    Public Sub client(ByVal actualLanguageValue As Integer)

        ClientForm.GunaComboBoxTypeDeFiltre.Items.Clear()

        autoLoadCivilte(actualLanguageValue)
        clientFormModeReglement(actualLanguageValue)

        If actualLanguageValue = 0 Then

            ClientForm.GunaComboBoxTypeDeFiltre.Items.Add("Individual")
            ClientForm.GunaComboBoxTypeDeFiltre.Items.Add("Company")
            ClientForm.GunaComboBoxTypeDeFiltre.Items.Add("Account")

            ClientForm.GunaLabel40.Text = "Elite Member Code"
            ClientForm.GunaLabelGestCompteGeneraux.Text = "Client Management"
            ClientForm.GunaLabel2.Text = "Client Code"
            ClientForm.GunaLabel3.Text = "Type of Client"
            ClientForm.GunaLabel4.Text = "First Name *"
            ClientForm.GunaLabel6.Text = "Surname"
            ClientForm.GunaLabel5.Text = "Maiden name"
            ClientForm.GunaLabel7.Text = "Profession"
            ClientForm.GunaLabel11.Text = "Date of birth"
            ClientForm.GunaLabel8.Text = "Place of birth"
            ClientForm.GunaLabel10.Text = "Country of residence"
            ClientForm.GunaLabel24.Text = "Town of residence"
            ClientForm.GunaLabelLabelEntreprise.Text = "Company"
            ClientForm.GunaLabel9.Text = "Nationality"
            ClientForm.GunaLabelLqbelCni.Text = "ID / UIN / PASSPORT *"
            ClientForm.GunaLabel14.Text = "Payment choice"
            ClientForm.GunaLabel15.Text = "Addresse"
            ClientForm.GunaLabel16.Text = "Telephone *"
            ClientForm.GunaLabel17.Text = "Fax"
            ClientForm.GunaLabel18.Text = "E-Mail"
            ClientForm.GunaLabel20.Text = "Web site"
            ClientForm.GunaLabel19.Text = "Transport mode "
            ClientForm.GunaLabel13.Text = "Car brand"
            ClientForm.GunaLabel25.Text = "Immatriculation number"
            ClientForm.GunaLabel33.Text = "DEBTOR ACCOUNT INFORMATIONS"
            ClientForm.GunaLabel21.Text = "Account Number"
            ClientForm.GunaLabel12.Text = "Account name"
            ClientForm.GunaLabel31.Text = "Account limit amount"
            ClientForm.GunaLabel32.Text = "Activate account"
            ClientForm.GunaCheckBoxActivationDesactivationDuCompte.Text = "YES"
            ClientForm.GunaLabel22.Text = "Name of the person to contact"
            ClientForm.GunaLabel37.Text = "Payment deadline"
            ClientForm.GunaLabel35.Text = "Contact"
            ClientForm.GunaLabel36.Text = "Billing Addresse"
            ClientForm.GunaButtonAnnuler.Text = "Cancel"
            ClientForm.GunaButtonEnregistrerClient.Text = "Add"
            ClientForm.GunaLabel34.Text = "CLIENT INFORMATIONS"
            ClientForm.GunaButton2.Text = "New Client"
            ClientForm.GunaButtonAfficherClient.Text = "View"
            ClientForm.GunaGroupBox12.Text = "SEARCH CRITERIA"
            ClientForm.GunaLabel116.Text = "CLIENT REFERENCE"
            ClientForm.GunaLabel126.Text = "CLIENT NAME"
            ClientForm.GunaLabel29.Text = "TELEPHONE "
            ClientForm.GunaLabel123.Text = "ELITE CODE"
            ClientForm.GunaButtonListClientsTab.Text = "Client List"
            ClientForm.GunaLabel28.Text = "CREATION DATE"

            ClientForm.GunaButtonAjoutPreference.Text = "Add"
            ClientForm.GunaButtonAfficherLesPreferences.Text = "View"

            ClientForm.GunaLabelNote.Text = "NB: Obligatory fileds ( * )"

            ClientForm.TabControl1.TabPages(0).Text = "Description"
            ClientForm.TabControl1.TabPages(1).Text = "Prices"
            ClientForm.TabControl1.TabPages(2).Text = "Situation"
            ClientForm.TabControl1.TabPages(3).Text = "Preference"
            ClientForm.TabControl1.TabPages(4).Text = "List"
            ClientForm.TabControl1.TabPages(5).Text = "Elite Club"

            ClientForm.SupprimerToolStripMenuItem.Text = "Delete"
            ClientForm.ImprimerToolStripMenuItem.Text = "Print"
            ClientForm.TransférerToolStripMenuItem.Text = "Pay"

            ClientForm.GunaLabel23.Text = "Preferences"

            ClientForm.GunaButtonCreateEliteCarte.Text = "Create"
            ClientForm.GunaButton3.Text = "View"
            ClientForm.GunaGroupBox1.Text = "CREATION OF ELITE CLUB MEMBERSHIP CARDS"
            ClientForm.GunaGroupBox2.Text = "CARDS AWARDED"
            ClientForm.GunaLabel43.Text = "Member type"
            ClientForm.GunaLabel42.Text = "Card identifier"
            ClientForm.GunaLabel44.Text = "CARD ID / MEMBER TYPE / CLIENT NAME"

            ClientForm.GunaButtonEnregistrerClient.Text = "Save"
            ClientForm.GunaButtonAnnuler.Text = "Cancel"
            ClientForm.Label1.Text = "PAYMENT METHOD"
            ClientForm.Label2.Text = "OPERATION"
            ClientForm.LabelMontantAPayer.Text = "Amount to Pay"
            ClientForm.Label3.Text = "Amount"
            ClientForm.LabelSolde.Text = "Balance"
            ClientForm.Label14.Text = "Generated Incom"
            ClientForm.Label4.Text = "Balance"
            ClientForm.Label13.Text = "From"
            ClientForm.Label15.Text = "To"
            ClientForm.GunaButtonAfficherLesFacturesEtReglement.Text = "View"
            ClientForm.ImprimerToolStripMenuItem.Text = "Print"
            ClientForm.TransférerToolStripMenuItem.Text = "Pay"
            ClientForm.GunaButtonEnregistrerReglement.Text = "Save"

            ClientForm.TabControl2.TabPages(0).Text = "Bills"
            ClientForm.TabControl2.TabPages(1).Text = "Stay"

            ClientForm.GunaButtonEnregistrerTarifs.Text = "Add"
            ClientForm.GunaLabel27.Text = "Applicable Code"
            ClientForm.GunaLabelApplique.Text = "Code"
            ClientForm.GunaLabelTypeCode.Text = "Rate Type"
            ClientForm.GunaLabel26.Text = "Code Type"

        ElseIf actualLanguageValue = 1 Then

            ClientForm.GunaComboBoxTypeDeFiltre.Items.Add("Individuel")
            ClientForm.GunaComboBoxTypeDeFiltre.Items.Add("Entreprise")
            ClientForm.GunaComboBoxTypeDeFiltre.Items.Add("Compte")

            ClientForm.TabControl1.TabPages(5).Text = "Club Elite"
            ClientForm.GunaButtonCreateEliteCarte.Text = "Créer"

            ClientForm.GunaButton3.Text = "Afficher"
            ClientForm.GunaGroupBox1.Text = "CREATION DES CARTES DES MEMBRES DU CLUB ELITE"
            ClientForm.GunaGroupBox2.Text = "CARTES ATTRIBUEES"
            ClientForm.GunaLabel43.Text = "Type de Membre"
            ClientForm.GunaLabel42.Text = "Identifiant de la carte"
            ClientForm.GunaLabel44.Text = "ID CARTE / TYPE MEMBRE / NOM CLIENT"

            ClientForm.GunaLabel40.Text = "Code Membre Elite"
            ClientForm.GunaLabel2.Text = "Code Client"
            ClientForm.GunaLabel3.Text = "Type Client"
            ClientForm.GunaLabel4.Text = "Nom"
            ClientForm.GunaLabel6.Text = "Prénom"
            ClientForm.GunaLabel5.Text = "Nom de Jeune fille"
            ClientForm.GunaLabel7.Text = "Profession"
            ClientForm.GunaLabel11.Text = "Date de naissance"
            ClientForm.GunaLabel8.Text = "Lieu de naissance"
            ClientForm.GunaLabel10.Text = "Pays de Résidence"
            ClientForm.GunaLabel24.Text = "Ville de Résidence"
            ClientForm.GunaLabelLabelEntreprise.Text = "Entreprise"
            ClientForm.GunaLabel9.Text = "Nationalité"
            ClientForm.GunaLabelLqbelCni.Text = "CNI / NIU / PASSPORT *"
            ClientForm.GunaLabel14.Text = "Mode de Règlement"
            ClientForm.GunaLabel15.Text = "Adresse"
            ClientForm.GunaLabel16.Text = "Téléphone *"
            ClientForm.GunaLabel17.Text = "Fax"
            ClientForm.GunaLabel18.Text = "E-Mail"
            ClientForm.GunaLabel20.Text = "Site web"
            ClientForm.GunaLabel19.Text = "Mode Transport"
            ClientForm.GunaLabel13.Text = "Marque du véhicule"
            ClientForm.GunaLabel25.Text = "Numéro du véhicule"
            ClientForm.GunaLabel33.Text = "INFORMATIONS DU COMPTE DEBITEUR"
            ClientForm.GunaLabel21.Text = "Numéro de compte"
            ClientForm.GunaLabel12.Text = "Intitulé du compte"
            ClientForm.GunaLabel31.Text = "Montant plafonds du compte"
            ClientForm.GunaLabel32.Text = "Compte Actif"
            ClientForm.GunaCheckBoxActivationDesactivationDuCompte.Text = "OUI"
            ClientForm.GunaLabel22.Text = "Nom de la personne à contacter"
            ClientForm.GunaLabel37.Text = "Delai de paiement"
            ClientForm.GunaLabel35.Text = "Contact"
            ClientForm.GunaLabel36.Text = "Adresse de Facturation"
            ClientForm.GunaButtonAnnuler.Text = "Annuler"
            ClientForm.GunaButtonEnregistrerClient.Text = "Enregistrer"
            ClientForm.GunaLabel34.Text = "INFORMATIONS DU CLIENT"
            ClientForm.GunaButton2.Text = "Nouveau Client"
            ClientForm.GunaButtonAfficherClient.Text = "Afficher"
            'ClientForm.GunaCheckBoxTous.Text = "Afficher tous les clients"
            ClientForm.GunaGroupBox12.Text = "CRITERES DE RECHERCHE"
            ClientForm.GunaLabel116.Text = "REFERENCE CLIENT"
            ClientForm.GunaLabel126.Text = "NOM CLIENT"
            ClientForm.GunaLabel29.Text = "TELEPHONE *"
            ClientForm.GunaLabel123.Text = "ENTREPRISE"
            ClientForm.GunaLabel28.Text = "DATE DE CREATION"

            ClientForm.GunaButtonAjoutPreference.Text = "Ajouter"
            ClientForm.GunaButtonAfficherLesPreferences.Text = "Afficher"

            ClientForm.GunaLabelNote.Text = "NB: Champs obligatoires ( * )"

            ClientForm.TabControl1.TabPages(0).Text = "Description"
            ClientForm.TabControl1.TabPages(1).Text = "Tarifs"
            ClientForm.TabControl1.TabPages(2).Text = "Situation"
            ClientForm.TabControl1.TabPages(3).Text = "Préférences"
            ClientForm.GunaLabel23.Text = "Préférences"
            ClientForm.TabControl1.TabPages(4).Text = "Liste"

            ClientForm.SupprimerToolStripMenuItem.Text = "Supprimer"
            ClientForm.ImprimerToolStripMenuItem.Text = "Imprimer"
            ClientForm.TransférerToolStripMenuItem.Text = "Régler"

            ClientForm.GunaButtonEnregistrerClient.Text = "Enregistrer"
            ClientForm.GunaButtonAnnuler.Text = "Annuler"
            ClientForm.Label1.Text = "MODE DE REGLEMENT"
            ClientForm.Label2.Text = "OPERATION"
            ClientForm.LabelMontantAPayer.Text = "Montant à Payer"
            ClientForm.Label3.Text = "Montant à Versé"
            ClientForm.LabelSolde.Text = "Solde"
            ClientForm.Label14.Text = "Chiffres d'affaire"
            ClientForm.Label4.Text = "Solde"
            ClientForm.Label3.Text = "Du"
            ClientForm.Label15.Text = "Au"
            ClientForm.GunaButtonAfficherLesFacturesEtReglement.Text = "Afficher"
            ClientForm.ImprimerToolStripMenuItem.Text = "Imprimer"
            ClientForm.TransférerToolStripMenuItem.Text = "Régler"
            ClientForm.GunaButtonEnregistrerReglement.Text = "Enregistrer"



        End If

    End Sub

    Public Sub cloture(ByVal actualLanguageValue As Integer)

        If actualLanguageValue = 0 Then

            CloturerForm.GunaButtonCloturer.Text = "Night Audit"
            CloturerForm.GunaButtonTerminer.Text = "Finished"
            CloturerForm.GunaButtonAnnuler.Text = "Cancel"
            CloturerForm.GunaLabel3.Text = "1 - Depatures of the day to be done"
            CloturerForm.GunaLabel2.Text = "2- Closing of cash Boxes"
            CloturerForm.GunaLabel4.Text = "3- Expected  moved to No Show"
            CloturerForm.GunaLabel6.Text = "4- Saving Data"
            CloturerForm.GunaLabelGestCompteGeneraux.Text = "NIGHT AUDIT"
            CloturerForm.GroupBox1.Text = "Control before Night Audit of the :"

        Else

            CloturerForm.GunaButtonCloturer.Text = "Clôturer"
            CloturerForm.GunaButtonTerminer.Text = "Terminer"
            CloturerForm.GunaButtonAnnuler.Text = "Annuler"
            CloturerForm.GunaLabel3.Text = "1 - Départs du jours à effectuer"
            CloturerForm.GunaLabel2.Text = "2- Clôture des caisses"
            CloturerForm.GunaLabel4.Text = "3- Réservations du jour non arrivée"
            CloturerForm.GunaLabel6.Text = "4- Sauvegarde des données"
            CloturerForm.GunaLabelGestCompteGeneraux.Text = "CLOTURE DE JOURNEE"
            CloturerForm.GroupBox1.Text = "Contrôle Avant cloture du :"

        End If

    End Sub

    Public Sub room(ByVal actualLanguageValue As Integer)

        If actualLanguageValue = 0 Then

            RoomForm.GunaButtonAfficherLaListeDesChambres.Text = "View"
            RoomForm.GunaButtonImprimer.Text = "Print"

            RoomForm.GunaRadioButtonChambre.Text = "Rooms"

            RoomForm.GunaRadioButtonSalle.Text = "Halls"
            RoomForm.GunaLabelGestCompteGeneraux.Text = "LIST OF ROOMS"
            RoomForm.GunaButtonEnregistrer.Text = "Save"

        Else

            RoomForm.GunaButtonAfficherLaListeDesChambres.Text = "Afficher"
            RoomForm.GunaButtonImprimer.Text = "Imprimer"
            RoomForm.GunaRadioButtonChambre.Text = "Chambres"
            RoomForm.GunaRadioButtonSalle.Text = "Salles"

            RoomForm.GunaLabelGestCompteGeneraux.Text = "LISTE DES CHAMBRES"

        End If

    End Sub

    Public Sub roomType(ByVal actualLanguageValue As Integer)

        If actualLanguageValue = 0 Then

            RoomTypeForm.GunaRadioButtonChambre.Text = "Rooms"
            RoomTypeForm.GunaRadioButtonSalle.Text = "Halls"
            RoomTypeForm.GunaLabelGestCompteGeneraux.Text = "ROOMS TYPE"
            RoomTypeForm.GunaLabel8.Text = "Code"
            RoomTypeForm.GunaLabel6.Text = "Name"
            RoomTypeForm.GunaLabel2.Text = "Surface Area"
            RoomTypeForm.GunaLabel3.Text = "Capacity"
            RoomTypeForm.GunaLabel7.Text = "Description"
            RoomTypeForm.GunaLabel5.Text = "Dayly Rate"
            RoomTypeForm.GunaLabel4.Text = "Percentage"
            RoomTypeForm.GunaLabel9.Text = "Lowest Price"
            RoomTypeForm.GunaLabel11.Text = "Variable Amount"
            RoomTypeForm.GunaLabel1.Text = "Close"
            RoomTypeForm.GunaButtonEnregistrer.Text = "Save"
            RoomTypeForm.GunaCheckBoxPourcentage.Text = "Percentage"
            RoomTypeForm.GunaCheckBoxPourcentage.Text = "Percentage"
            RoomTypeForm.GunaButtonAfficher.Text = "View"
            RoomTypeForm.TabControl1.TabPages(0).Text = "Description"
            RoomTypeForm.TabControl1.TabPages(1).Text = "List"

            RoomTypeForm.GunaLabel12.Text = "Weekly Rate"
            RoomTypeForm.GunaLabelMensuel.Text = "Monthly Rate"
            RoomTypeForm.GunaLabelSieste.Text = "Day use Rate"

        Else

            RoomTypeForm.GunaRadioButtonChambre.Text = "Chambres"
            RoomTypeForm.GunaRadioButtonSalle.Text = "Salles"
            RoomTypeForm.GunaLabelGestCompteGeneraux.Text = "TYPE DE CHAMBRES"
            RoomTypeForm.GunaLabel8.Text = "Code"
            RoomTypeForm.GunaLabel6.Text = "Libellé"
            RoomTypeForm.GunaLabel2.Text = "Superficie"
            RoomTypeForm.GunaLabel3.Text = "Capacité"
            RoomTypeForm.GunaLabel7.Text = "Description"
            RoomTypeForm.GunaLabel5.Text = "Prix Journalier"
            RoomTypeForm.GunaLabel4.Text = "Pourcentage"
            RoomTypeForm.GunaLabel9.Text = "Prix le Plus Bas"
            RoomTypeForm.GunaLabel11.Text = "Montant variable"
            RoomTypeForm.GunaLabel1.Text = "Fermer"
            RoomTypeForm.GunaButtonEnregistrer.Text = "Enregistrer"
            RoomTypeForm.GunaCheckBoxPourcentage.Text = "Pourcentage"
            RoomTypeForm.GunaCheckBoxPourcentage.Text = "Pourcentage"
            RoomTypeForm.GunaButtonAfficher.Text = "Afficher"
            RoomTypeForm.TabControl1.TabPages(0).Text = "Description"
            RoomTypeForm.TabControl1.TabPages(1).Text = "Liste"

        End If

    End Sub

    Public Sub Minireglement(ByVal actualLanguageValue As Integer)

        autoLoadModeReglementMini(actualLanguageValue)

        If actualLanguageValue = 0 Then

            MiniReglementForm.GunaLabelGestCompteGeneraux.Text = "CASH IN"
            MiniReglementForm.LabelMontantAPayer.Text = "Amount to Pay"
            MiniReglementForm.Label3.Text = "Received amount"
            MiniReglementForm.LabelSolde.Text = "Balance"
            MiniReglementForm.GunaButtonEnregistrerReglement.Text = "Cash In"
            MiniReglementForm.Label2.Text = "Balance"
            MiniReglementForm.Label6.Text = "Reference"
            MiniReglementForm.Label1.Text = "Pay through"
            MiniReglementForm.LabelContact.Text = "Transaction Reference"
            MiniReglementForm.LabelRemarque.Text = "Remark"
            MiniReglementForm.GunaCheckBoxOffresEnChambre.Text = "In House"
            MiniReglementForm.Label10.Text = "Client's Name"
            MiniReglementForm.Label10.Text = "Client's Name"

        Else

            MiniReglementForm.GunaLabelGestCompteGeneraux.Text = "ENCAISSEMENT"
            MiniReglementForm.LabelMontantAPayer.Text = "Montant à Payer"
            MiniReglementForm.Label3.Text = "Montant Versé"
            MiniReglementForm.LabelSolde.Text = "Solde à payer"
            MiniReglementForm.GunaButtonEnregistrerReglement.Text = "Encaisser"
            MiniReglementForm.Label2.Text = "Situation Caisse"
            MiniReglementForm.Label6.Text = "Référence"
            MiniReglementForm.Label1.Text = "Mode de Règlement"

            MiniReglementForm.LabelBanqueEmettrice.Text = "Banque Eméttrice"
            MiniReglementForm.LabelNumCompte.Text = "Numéro de Compte"
            MiniReglementForm.LabelEntreprise.Text = "Entreprise"
            MiniReglementForm.LabelNumeroCompte.Text = "Compte Débiteur"
            MiniReglementForm.LabelContact.Text = "Référence de Transaction"

            MiniReglementForm.LabelRemarque.Text = "Remarque"
            MiniReglementForm.GunaCheckBoxOffresEnChambre.Text = "En Chambre"
            MiniReglementForm.Label10.Text = "Nom du Client"



        End If

    End Sub

    Public Sub reglement(ByVal actualLanguageValue As Integer)

        autoLoadModeReglement(actualLanguageValue)

        If actualLanguageValue = 0 Then

            ReglementForm.GunaLabelGestCompteGeneraux.Text = "CASH IN"
            ReglementForm.Label5.Text = "Client"
            ReglementForm.LabelMontantAPayer.Text = "Amount to Pay"
            ReglementForm.Label3.Text = "Received amount"
            ReglementForm.LabelSolde.Text = "Balance"
            ReglementForm.GunaButtonEnregistrerReglement.Text = "Cash In"
            ReglementForm.Label2.Text = "Balance"
            ReglementForm.Label6.Text = "Reference"
            ReglementForm.Label1.Text = "Pay through"
            ReglementForm.GunaCheckBoxRemboursement.Text = "Refund"
            ReglementForm.LabelContact.Text = "Transaction Reference"
            ReglementForm.LabelRemarque.Text = "Remark"
            ReglementForm.GunaCheckBoxOffresEnChambre.Text = "In House"
            ReglementForm.Label10.Text = "Client's Name"
            ReglementForm.Label10.Text = "Client's Name"

        Else

            ReglementForm.GunaLabelGestCompteGeneraux.Text = "ENCAISSEMENT"
            ReglementForm.Label5.Text = "Client"
            ReglementForm.LabelMontantAPayer.Text = "Montant à Payer"
            ReglementForm.Label3.Text = "Montant Versé"
            ReglementForm.LabelSolde.Text = "Solde à payer"
            ReglementForm.GunaButtonEnregistrerReglement.Text = "Encaisser"
            ReglementForm.Label2.Text = "Situation Caisse"
            ReglementForm.Label6.Text = "Référence"
            ReglementForm.Label1.Text = "Mode de Règlement"
            ReglementForm.GunaCheckBoxRemboursement.Text = "Remboursement"

            ReglementForm.LabelBanqueEmettrice.Text = "Banque Eméttrice"
            ReglementForm.LabelNumCompte.Text = "Numéro de Compte"
            ReglementForm.LabelEntreprise.Text = "Entreprise"
            ReglementForm.LabelNumeroCompte.Text = "Compte Débiteur"
            ReglementForm.LabelContact.Text = "Référence de Transaction"

            ReglementForm.LabelRemarque.Text = "Remarque"
            ReglementForm.GunaCheckBoxOffresEnChambre.Text = "En Chambre"
            ReglementForm.Label10.Text = "Nom du Client"



        End If

    End Sub

    Public Sub register(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then

            RegisterForm.GunaGroupBox1.Text = "Visitor Registration"
            RegisterForm.GunaLabel3.Text = "Visitor's Name"
            RegisterForm.GunaLabel4.Text = "ID CARD No / Passport :"
            RegisterForm.GunaLabel5.Text = "From :"
            RegisterForm.GunaLabel1.Text = "Room"
            RegisterForm.GunaLabel2.Text = "Client name"
            RegisterForm.GunaButton3.Text = "Register"
            RegisterForm.GunaGroupBox2.Text = "List of Visitors"
            RegisterForm.GunaLabelGestUsers.Text = "VISITOR MANAGEMENT"

        ElseIf ActualLanguageValue = 1 Then

            RegisterForm.GunaGroupBox1.Text = "Enregistrement du Visiteur"
            RegisterForm.GunaLabel3.Text = "Nom du visiteur"
            RegisterForm.GunaLabel4.Text = "No CNI / Passport :"
            RegisterForm.GunaLabel5.Text = "Du :"
            RegisterForm.GunaLabel1.Text = "Chambre"
            RegisterForm.GunaLabel2.Text = "Nom du client"
            RegisterForm.GunaButton3.Text = "Enregistrer"
            RegisterForm.GunaGroupBox2.Text = "Liste des Visites"
            RegisterForm.GunaLabelGestUsers.Text = "GESTION DES VISITEURS"


        End If

    End Sub

    Public Sub autoLoadClientTypePayMaster(ByVal ActualLanguageValue As Integer)

        ReglementLettrageForm.GunaComboBoxTypeDeFiltre.Items.Clear()
        GrandeCaisseForm.GunaComboBoxModeReglement.Items.Clear()

        If ActualLanguageValue = 1 Then ' FRENCH

            ReglementLettrageForm.GunaComboBoxTypeDeFiltre.Items.Add("Individuel")
            ReglementLettrageForm.GunaComboBoxTypeDeFiltre.Items.Add("Entreprise")
            ReglementLettrageForm.GunaComboBoxTypeDeFiltre.Items.Add("Compte")

            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("Cash")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("Cheque")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("Carte de crédit")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("Prise en charge")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("MTN Money")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("ORANGE Money")

        ElseIf ActualLanguageValue = 0 Then 'ENGLISH

            ReglementLettrageForm.GunaComboBoxTypeDeFiltre.Items.Add("Individual")
            ReglementLettrageForm.GunaComboBoxTypeDeFiltre.Items.Add("Company")
            ReglementLettrageForm.GunaComboBoxTypeDeFiltre.Items.Add("Account")

            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("Cash")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("Cheque")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("Credit Card")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("Taking charge")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("MTN Money")
            GrandeCaisseForm.GunaComboBoxModeReglement.Items.Add("ORANGE Money")

            GrandeCaisseForm.GunaComboBoxNatureOperation.Items.Clear()
            GrandeCaisseForm.GunaComboBoxNatureOperation.Items.Add("ENTERING REVENUE")
            GrandeCaisseForm.GunaComboBoxNatureOperation.Items.Add("CASH INFLOW")
            GrandeCaisseForm.GunaComboBoxNatureOperation.Items.Add("CASH OUTFLOW")



        End If

        ReglementLettrageForm.GunaComboBoxTypeDeFiltre.SelectedIndex = 0

    End Sub

    Public Sub paymaster(ByVal ActualLanguageValue As Integer)

        autoLoadClientTypePayMaster(ActualLanguageValue)

        If ActualLanguageValue = 0 Then

            ReglementLettrageForm.Label5.Text = "COMPANY"
            ReglementLettrageForm.Label4.Text = "ACCOUNT"
            ReglementLettrageForm.Label12.Text = "MAXIMUM "
            ReglementLettrageForm.Label7.Text = "BALANCE"
            ReglementLettrageForm.Label8.Text = "PERSON TO CONTACT "
            ReglementLettrageForm.Label9.Text = "BILLING ADRESSE "
            ReglementLettrageForm.Label11.Text = "DATELINE "
            ReglementLettrageForm.Label13.Text = "From "
            ReglementLettrageForm.Label15.Text = "To "
            ReglementLettrageForm.GunaLabel2.Text = "INVOICE DETAILS"
            ReglementLettrageForm.Label17.Text = "Debt Situation"
            ReglementLettrageForm.Label16.Text = "Cash balance"
            ReglementLettrageForm.Label14.Text = "Sales figures"
            ReglementLettrageForm.Label1.Text = "PAYMENT METHOD"
            ReglementLettrageForm.Label2.Text = "OPERATION NATURE"
            ReglementLettrageForm.Label21.Text = "RANK : "
            ReglementLettrageForm.GunaButtonAfficherLesFacturesEtReglement.Text = "View"
            ReglementLettrageForm.GunaButtonTransfert.Text = "Transfer Cash"
            ReglementLettrageForm.GunaButtonOuvertureFermeture.Text = "Close Cash Register"
            ReglementLettrageForm.GunaButtonEnregistrerReglement.Text = "Save"
            ReglementLettrageForm.GunaLabel3.Text = "INVOICES AND PAYMENTS"
            ReglementLettrageForm.GunaLabelGestCompteGeneraux.Text = "PAYMENT AND LETTERING"

            ReglementLettrageForm.LabelMontantAPayer.Text = "Amount to Pay"
            ReglementLettrageForm.Label3.Text = "Given Amount"
            ReglementLettrageForm.LabelSolde.Text = "Balance to Pay"

            ReglementLettrageForm.Gunalabel56.Text = "Transaction Reference"
            ReglementLettrageForm.LabelEntreprise.Text = "Company"
            ReglementLettrageForm.LabelNumeroCompte.Text = "Debtor Account"
            ReglementLettrageForm.LabelNumCarte.Text = "Card Number"
            ReglementLettrageForm.LabelDateExpiration.Text = "Expire"
            ReglementLettrageForm.Label18.Text = "Bank"
            ReglementLettrageForm.Label20.Text = "Bank"
            ReglementLettrageForm.Label19.Text = "Rerence"
            ReglementLettrageForm.LabelBanqueEmettrice.Text = "Emitting Bank"
            ReglementLettrageForm.LabelNumCompte.Text = "Cheque number"
            ReglementLettrageForm.Label24.Text = "List of Security Deposits"
            ReglementLettrageForm.Label23.Text = "Amount"
            ReglementLettrageForm.Label23.Text = "Transaction Reference"
            ReglementLettrageForm.GunaButtonEffacerDetail.Text = "Clear"

            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Clear()

            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Cash")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Cheque")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Credit Card")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Taking charge")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("MTN Money")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("ORANGE Money")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Credit Note")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Bank Transfer")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Cover")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Arrhes")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Deduction")
            ReglementLettrageForm.GunaComboBoxModeReglement.Items.Add("Free")

            ReglementLettrageForm.ImprimerToolStripMenuItem.Text = "Print Detailed Invoice"
            ReglementLettrageForm.ImprimerFactureSynthèseToolStripMenuItem.Text = "Print Summarised Invoice"
            ReglementLettrageForm.TransférerToolStripMenuItem.Text = "Pay"
            ReglementLettrageForm.RéductionToolStripMenuItem.Text = "Discount"

        ElseIf ActualLanguageValue = 1 Then

            ReglementLettrageForm.Label5.Text = "ENTREPRISE"
            ReglementLettrageForm.Label4.Text = "N° COMPTE"
            ReglementLettrageForm.Label12.Text = "PLAFONDS "
            ReglementLettrageForm.Label7.Text = "SOLDE "
            ReglementLettrageForm.Label8.Text = "PERSONNE A CONTACTER "
            ReglementLettrageForm.Label9.Text = "ADRESSE DE FACTURATION "
            ReglementLettrageForm.Label11.Text = "DELAI DE PAIEMENT "
            ReglementLettrageForm.Label13.Text = "Du "
            ReglementLettrageForm.GunaLabel3.Text = "FACTURES ET REGLEMENTS"
            ReglementLettrageForm.Label15.Text = "Au "
            ReglementLettrageForm.GunaLabel2.Text = "DETAILS DE FACTURE"
            ReglementLettrageForm.Label17.Text = "Situation des dettes"
            ReglementLettrageForm.Label16.Text = "Solde en caisse"
            ReglementLettrageForm.Label14.Text = "Chiffres d'affaire"
            ReglementLettrageForm.Label1.Text = "MODE DE REGLEMENT"
            ReglementLettrageForm.Label2.Text = "NATURE OPERATION"
            ReglementLettrageForm.Label21.Text = "RANG : "
            ReglementLettrageForm.GunaButtonAfficherLesFacturesEtReglement.Text = "Afficher"
            ReglementLettrageForm.GunaButtonTransfert.Text = "Transférer Caisse"
            ReglementLettrageForm.GunaButtonOuvertureFermeture.Text = "Fermer Caisse"
            ReglementLettrageForm.GunaButtonEnregistrerReglement.Text = "Enregistrer"
            ReglementLettrageForm.GunaLabelGestCompteGeneraux.Text = "REGLEMENTS ET LETTRAGES"

            ReglementLettrageForm.LabelMontantAPayer.Text = "Montant à Payer"
            ReglementLettrageForm.Label3.Text = "Montant Versé"
            ReglementLettrageForm.LabelSolde.Text = "Solde à payer"

            ReglementLettrageForm.Gunalabel56.Text = "Référence de Transaction"
            ReglementLettrageForm.LabelEntreprise.Text = "Entreprise"
            ReglementLettrageForm.LabelNumeroCompte.Text = "Compte Débiteur"
            ReglementLettrageForm.LabelNumCarte.Text = "Numéro de carte"
            ReglementLettrageForm.LabelDateExpiration.Text = "Date Expiration"
            ReglementLettrageForm.Label18.Text = "Banque"
            ReglementLettrageForm.Label20.Text = "Banque"
            ReglementLettrageForm.Label19.Text = "Référence"
            ReglementLettrageForm.LabelBanqueEmettrice.Text = "Banque Emettrice"
            ReglementLettrageForm.LabelNumCompte.Text = "Numéro de chèque"
            ReglementLettrageForm.Label24.Text = "Liste des Dépôt de Garanties"
            ReglementLettrageForm.Label23.Text = "MONTANT"
            ReglementLettrageForm.Label23.Text = "Référence de Transaction"
            ReglementLettrageForm.GunaButtonEffacerDetail.Text = "Effacer"

        End If

    End Sub

    Public Sub grandeCaisse(ByVal ActualLanguageValue As Integer)

        autoLoadClientTypePayMaster(ActualLanguageValue)

        If ActualLanguageValue = 0 Then

            GrandeCaisseForm.GunaLabel3.Text = "PENDING REVENUE TRANSACTIONS"
            GrandeCaisseForm.Label1.Text = "PAYMENT METHOD"
            GrandeCaisseForm.Label2.Text = "OPERATION NATURE"
            GrandeCaisseForm.GunaAdvenceButton1.Text = "PENDING TRANSACTIONS"
            GrandeCaisseForm.GunaAdvenceButton2.Text = "PENDING DISBURSEMENTS"
            GrandeCaisseForm.GunaAdvenceButton3.Text = "CASH OUTFLOW" 'FONDS SORTIES
            GrandeCaisseForm.GunaAdvenceButton4.Text = "CASH INFLOW" 'FONDS ENTREES
            GrandeCaisseForm.GunaAdvenceButton5.Text = "COMPLETED TRANSACTIONS"
            GrandeCaisseForm.GunaAdvenceButton6.Text = "BANK LOG"
            GrandeCaisseForm.GunaAdvenceButton7.Text = "REVENUE"
            GrandeCaisseForm.GunaButtonImprimerSituation.Text = "Print"
            GrandeCaisseForm.GunaButtonAfficherLesFacturesEtReglement.Text = "View"
            GrandeCaisseForm.GunaButtonImprimerListeDesComptes.Text = "View"
            GrandeCaisseForm.GunaButtonEnregistrerReglement.Text = "Save"
            GrandeCaisseForm.LabelMontantAPayer.Text = "Amount to pay"
            GrandeCaisseForm.Label3.Text = "Amount paid"
            GrandeCaisseForm.LabelSolde.Text = "Balance to pay"
            GrandeCaisseForm.GunaButtonOuvertureFermeture.Text = "Close Cash Register"
            GrandeCaisseForm.GunaButtonBilletage.Text = "NOTES"
            GrandeCaisseForm.Label17.Text = "Cash outflow"
            GrandeCaisseForm.Label16.Text = "Cash balance"

            GrandeCaisseForm.GunaButtonRefresh.Text = "REFRESH"
            GrandeCaisseForm.Label13.Text = "From"
            GrandeCaisseForm.Label15.Text = "To"
            GrandeCaisseForm.Label19.Text = "BANK"
            GrandeCaisseForm.GunaLabel9.Text = "From :"
            GrandeCaisseForm.GunaLabel8.Text = "To :"
            GrandeCaisseForm.GunaButtonAfficher.Text = "View"
            GrandeCaisseForm.GunaButtonAfficher.Text = "View"

            '-----------------------------------------------------------------
            GrandeCaisseForm.TabControl1.TabPages(0).Text = "PENDING REVENUE TRANSACTIONS"
            GrandeCaisseForm.GunaAdvenceButton1.Text = "PENDING TRANSACTIONS"
            GrandeCaisseForm.TabControl1.TabPages(1).Text = "PENDING DISBURSEMENTS"
            GrandeCaisseForm.TabControl1.TabPages(2).Text = "CASH OUTFLOW"
            GrandeCaisseForm.TabControl1.TabPages(3).Text = "CASH INFLOW"
            GrandeCaisseForm.TabControl1.TabPages(5).Text = "COMPLETED TRANSACTIONS"
            GrandeCaisseForm.TabControl1.TabPages(6).Text = "BANK LOG"
            GrandeCaisseForm.TabControl1.TabPages(4).Text = "REVENUE"

        ElseIf ActualLanguageValue = 1 Then

            GrandeCaisseForm.GunaLabel3.Text = "TRANSACTIONS DE RECETTE EN ATTENTES"
            GrandeCaisseForm.Label1.Text = "MODE DE REGLEMENT"
            GrandeCaisseForm.Label2.Text = "NATURE OPERATION"
            GrandeCaisseForm.GunaAdvenceButton1.Text = "TRANSACTIONS EN ATTENTES"
            GrandeCaisseForm.GunaAdvenceButton2.Text = "DECAISSEMENTS EN ATTENTES"
            GrandeCaisseForm.GunaAdvenceButton3.Text = "FONDS SORTIES"
            GrandeCaisseForm.GunaAdvenceButton4.Text = "FONDS ENTREES"
            GrandeCaisseForm.GunaAdvenceButton5.Text = "TRANSACTIONS TERMINEES"
            GrandeCaisseForm.GunaAdvenceButton6.Text = "JOURNAL BANCAIRE"
            GrandeCaisseForm.GunaAdvenceButton7.Text = "RECETTE ENTREES"
            GrandeCaisseForm.GunaButtonImprimerSituation.Text = "Imprimer"
            GrandeCaisseForm.GunaButtonAfficherLesFacturesEtReglement.Text = "Afficher"
            GrandeCaisseForm.GunaButtonImprimerListeDesComptes.Text = "Afficher"
            GrandeCaisseForm.GunaButtonEnregistrerReglement.Text = "Enregistrer"
            GrandeCaisseForm.LabelMontantAPayer.Text = "Montant à Payer"
            GrandeCaisseForm.Label3.Text = "Montant Versé"
            GrandeCaisseForm.LabelSolde.Text = "Solde à payer"
            GrandeCaisseForm.GunaButtonOuvertureFermeture.Text = "Fermer Caisse"
            GrandeCaisseForm.GunaButtonBilletage.Text = "BILLETAGE"
            GrandeCaisseForm.Label17.Text = "Sortie de Fonds"
            GrandeCaisseForm.Label16.Text = "Solde en caisse"

            GrandeCaisseForm.GunaButtonRefresh.Text = "RAFRAICHIR"
            GrandeCaisseForm.Label13.Text = "Du"
            GrandeCaisseForm.Label15.Text = "Au"
            GrandeCaisseForm.Label19.Text = "BANQUES"
            GrandeCaisseForm.GunaLabel9.Text = "Du :"
            GrandeCaisseForm.GunaLabel8.Text = "Au :"
            GrandeCaisseForm.GunaButtonAfficher.Text = "Afficher"
            GrandeCaisseForm.GunaButtonAfficher.Text = "Afficher"


        End If

    End Sub

    Public Sub comptabiliteForm(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then

            MainWindowComptabiliteForm.GunaGroupBox2.Text = "SEARCH CRITERIA"
            MainWindowComptabiliteForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindowComptabiliteForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindowComptabiliteForm.RESERVATIONToolStripMenuItem.Text = "BOOKING"
            MainWindowComptabiliteForm.SERVICEDETAGEToolStripMenuItem.Text = "HOUSE KEEPING"
            MainWindowComptabiliteForm.ToolStripMenuItem1.Text = "KITCHEN"
            MainWindowComptabiliteForm.ComptabilitéToolStripMenuItem.Text = "ACCOUNTING AND FINANCES"
            MainWindowComptabiliteForm.ECONOMATToolStripMenuItem.Text = "PURCHASE"
            MainWindowComptabiliteForm.TECHNIQUEToolStripMenuItem.Text = "TECHNICAL"

            MainWindowComptabiliteForm.ToolStripMenuItemSession.Text = "SESSION"
            MainWindowComptabiliteForm.ToolStripMenuItem117.Text = "Change password"
            MainWindowComptabiliteForm.ApprovisionnementToolStripMenuItem.Text = "Request"
            MainWindowComptabiliteForm.FermerCaisseToolStripMenuItem.Text = "Close cash Register"
            MainWindowComptabiliteForm.PETITEToolStripMenuItem.Text = "Petty Cash Flow"
            MainWindowComptabiliteForm.OuvrirCaisseToolStripMenuItem.Text = "Open Cash Register"
            MainWindowComptabiliteForm.ClôturerToolStripMenuItem.Text = "Night Audit"
            MainWindowComptabiliteForm.ToolStripMenuItemConfig.Text = "SETTINGS"
            MainWindowComptabiliteForm.ToolStripMenuItemServTech.Text = "TECHNICAL SERVICE"
            MainWindowComptabiliteForm.ToolStripMenuItemSecurite.Text = "SECURITY"
            MainWindowComptabiliteForm.ToolStripMenuItem119.Text = "Close Session"

            MainWindowComptabiliteForm.GunaAdvenceButton12.Text = "ACCOUNTS"
            MainWindowComptabiliteForm.GunaAdvenceButton11.Text = "DEBTORS"
            MainWindowComptabiliteForm.GunaAdvenceButton1.Text = "PAYMENT AND LETTERING"
            MainWindowComptabiliteForm.GunaAdvenceButtonAgedBillsButton.Text = "OLDER BILLS"
            MainWindowComptabiliteForm.GunaAdvenceButton4.Text = "BILLS"
            MainWindowComptabiliteForm.GunaAdvenceButtonRelance.Text = "REMINDER L."
            MainWindowComptabiliteForm.GunaAdvenceButton25.Text = "COVER"
            MainWindowComptabiliteForm.GunaAdvenceButtonCaisse.Text = "CASHIER"
            MainWindowComptabiliteForm.GunaAdvenceButton29.Text = "REPORTS"

            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(0).Text = "Account Management"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(1).Text = "List of Accounts"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(2).Text = "Older BIlls"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(3).Text = "Cover"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(4).Text = "History"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(5).Text = "Reports"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(6).Text = "Reminder Letter"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(7).Text = "Bills"

            MainWindowComptabiliteForm.GunaLabel2.Text = "Account number"
            MainWindowComptabiliteForm.GunaLabel3.Text = "Account Name"
            MainWindowComptabiliteForm.GunaLabel16.Text = "ACCOUNT INFORMATION"
            MainWindowComptabiliteForm.GunaLabel4.Text = "Account Type"
            MainWindowComptabiliteForm.GunaLabel32.Text = "Activate account"
            MainWindowComptabiliteForm.GunaLabel5.Text = "Direction Balance"
            MainWindowComptabiliteForm.GunaLabel31.Text = "Account Amount limits"
            MainWindowComptabiliteForm.GunaLabel11.Text = "Days of Existence"
            MainWindowComptabiliteForm.GunaLabel22.Text = "Name of person to contact"
            MainWindowComptabiliteForm.GunaLabel36.Text = "Billing address"
            MainWindowComptabiliteForm.GunaLabel37.Text = "Payment terms (days)"
            MainWindowComptabiliteForm.GunaLabelInfoSup.Text = "ADDITIONAL INFORMATION"
            MainWindowComptabiliteForm.GunaLabel13.Text = "Account holder"
            MainWindowComptabiliteForm.GunaLabel14.Text = "Company"
            MainWindowComptabiliteForm.GunaLabel15.Text = "Profession"
            MainWindowComptabiliteForm.GunaButton1.Text = "Close"
            MainWindowComptabiliteForm.GunaButtonvERIFIER.Text = "Checked"
            MainWindowComptabiliteForm.GunaButtonActivation.Text = "Activate"
            MainWindowComptabiliteForm.GunaButtonAjouterCompte.Text = "Save"

            MainWindowComptabiliteForm.GunaLabel10.Text = "YES"

            MainWindowComptabiliteForm.GunaGroupRecherche.Text = "SEARCH CRITERIA"
            MainWindowComptabiliteForm.GunaCheckBoxRecherche.Text = "Search"
            MainWindowComptabiliteForm.GunaCheckBoxToutes.Text = "Show active accounts"
            MainWindowComptabiliteForm.GunaCheckBoxNonActiver.Text = "Show Non active accounts "
            MainWindowComptabiliteForm.GunaCheckBoxAttenteActivation.Text = "Waiting for activation"
            MainWindowComptabiliteForm.GunaLabel34.Text = "COMPANY / CUSTOMER NAME"
            MainWindowComptabiliteForm.GunaLabel66.Text = "ACCOUNT NUMBER"
            MainWindowComptabiliteForm.GunaLabel83.Text = "ACCOUNT NAME"
            MainWindowComptabiliteForm.GunaLabel85.Text = "PERSON TO CONTACT "
            MainWindowComptabiliteForm.GunaLabel84.Text = "TOWN"
            MainWindowComptabiliteForm.GunaButtonAfficherLaListeDesComptes.Text = "View"
            MainWindowComptabiliteForm.GunaButtonImprimerListeDesComptes.Text = "Print"

            MainWindowComptabiliteForm.GunaButton17.Text = "Print"
            MainWindowComptabiliteForm.GunaButtonFactureAgees.Text = "View"
            MainWindowComptabiliteForm.GunaButtonAfficherCaution.Text = "View"
            MainWindowComptabiliteForm.GunaButtonAfficherJournal.Text = "View"
            MainWindowComptabiliteForm.GunaButton14.Text = "View"
            MainWindowComptabiliteForm.AfficherLettredeRelance.Text = "View"
            MainWindowComptabiliteForm.GunaButtonAfficher.Text = "View"
            MainWindowComptabiliteForm.GunaButton16.Text = "Export"
            MainWindowComptabiliteForm.GunaButton5.Text = "Print"
            MainWindowComptabiliteForm.GunaButtonImprimerSituation.Text = "Print"
            MainWindowComptabiliteForm.GunaButtonEnregistrerFiscValue.Text = "Save"
            MainWindowComptabiliteForm.Label13.Text = "SEARCH COMPANY"
            MainWindowComptabiliteForm.LabelBanque.Text = "BANKS"
            MainWindowComptabiliteForm.GunaLabel9.Text = "From"
            MainWindowComptabiliteForm.GunaLabel8.Text = "To"

            MainWindowComptabiliteForm.GunaGroupBox1.Text = "SEARCH CRITERIA"
            MainWindowComptabiliteForm.GunaLabel21.Text = "COMPANY NAME"
            MainWindowComptabiliteForm.GunaLabel20.Text = "ACCOUNT NUMBER"
            MainWindowComptabiliteForm.GunaLabel19.Text = "ACCOUNT NAME"
            MainWindowComptabiliteForm.Label1.Text = "From"
            MainWindowComptabiliteForm.Label15.Text = "To"
            MainWindowComptabiliteForm.GunaButton14.Text = "View"
            MainWindowComptabiliteForm.GunaButton17.Text = "Print"

            MainWindowComptabiliteForm.GunaButton18.Text = "OUTPUT FUNDS"
            MainWindowComptabiliteForm.GunaButton4.Text = "FUNDS INPUTS"
            MainWindowComptabiliteForm.GunaButton7.Text = "RECETTES ENTREES"
            MainWindowComptabiliteForm.GunaButton19.Text = "COMPLETED TRANSACTIONS"
            MainWindowComptabiliteForm.GunaButton2.Text = "BILLS"
            MainWindowComptabiliteForm.GunaButton9.Text = "BANK LOG"
            MainWindowComptabiliteForm.GroupBox1.Text = "HISTORY"
            MainWindowComptabiliteForm.GroupBox2.Text = "LOGS"
            MainWindowComptabiliteForm.GunaButton7.Text = "REVENUES"
            MainWindowComptabiliteForm.FacturesToolStripMenuItem.Text = "Bills"

        ElseIf ActualLanguageValue = 1 Then

            MainWindowComptabiliteForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindowComptabiliteForm.RESERVATIONToolStripMenuItem.Text = "RESERVATION"
            MainWindowComptabiliteForm.SERVICEDETAGEToolStripMenuItem.Text = "SERVICE ETAGE"
            MainWindowComptabiliteForm.ToolStripMenuItem1.Text = "CUISINE"
            MainWindowComptabiliteForm.ComptabilitéToolStripMenuItem.Text = "COMPATBILITE ET FICNANCES"
            MainWindowComptabiliteForm.ECONOMATToolStripMenuItem.Text = "ECONOMAT"
            MainWindowComptabiliteForm.TECHNIQUEToolStripMenuItem.Text = "TECHNIQUE"

            MainWindowComptabiliteForm.ToolStripMenuItemSession.Text = "SESSION"
            MainWindowComptabiliteForm.ApprovisionnementToolStripMenuItem.Text = "Approvisionner"
            MainWindowComptabiliteForm.ToolStripMenuItem117.Text = "Changer mot de passe"
            MainWindowComptabiliteForm.FermerCaisseToolStripMenuItem.Text = "Fermer Caisse"
            MainWindowComptabiliteForm.PETITEToolStripMenuItem.Text = "Petite Caisse"
            MainWindowComptabiliteForm.OuvrirCaisseToolStripMenuItem.Text = "Ouvrir Caisse"
            MainWindowComptabiliteForm.ClôturerToolStripMenuItem.Text = "Clôturer"
            MainWindowComptabiliteForm.ToolStripMenuItemConfig.Text = "CONFIGURATION"
            MainWindowComptabiliteForm.ToolStripMenuItemServTech.Text = "SERVICE TECHNIQUE"
            MainWindowComptabiliteForm.ToolStripMenuItemSecurite.Text = "SECURITE"
            MainWindowComptabiliteForm.ToolStripMenuItem119.Text = "Fermer Session"

            MainWindowComptabiliteForm.GunaAdvenceButton12.Text = "COMPTES"
            MainWindowComptabiliteForm.GunaAdvenceButton11.Text = "DEBITEURS"
            MainWindowComptabiliteForm.GunaAdvenceButton1.Text = "REGLEMENT ET LETTRAGE"
            MainWindowComptabiliteForm.GunaAdvenceButtonAgedBillsButton.Text = "FACTURES AGEES"
            MainWindowComptabiliteForm.GunaAdvenceButton4.Text = "FACTURES"
            MainWindowComptabiliteForm.GunaAdvenceButtonRelance.Text = "RELANCES"
            MainWindowComptabiliteForm.GunaAdvenceButton25.Text = "CAUTIONS"
            MainWindowComptabiliteForm.GunaAdvenceButtonCaisse.Text = "CAISSE"
            MainWindowComptabiliteForm.GunaAdvenceButton29.Text = "RAPPORTS"

            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(0).Text = "Gestion des Comptes"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(1).Text = "Liste de Comptes"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(2).Text = "Factures âgées"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(3).Text = "Cautions"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(4).Text = "Journal"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(5).Text = "Rapports"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(6).Text = "Lettre de Relance"
            MainWindowComptabiliteForm.TabControlComptabilite.TabPages(7).Text = "Factures"

            MainWindowComptabiliteForm.GunaLabel2.Text = "Compte numéro"
            MainWindowComptabiliteForm.GunaLabel3.Text = "Intitulé du Compte"
            MainWindowComptabiliteForm.GunaLabel16.Text = "INFORMATION DU COMPTE"
            MainWindowComptabiliteForm.GunaLabel4.Text = "Type de Compte"
            MainWindowComptabiliteForm.GunaLabel32.Text = "Compte Actif"
            MainWindowComptabiliteForm.GunaLabel5.Text = "Sens Solde"
            MainWindowComptabiliteForm.GunaLabel31.Text = "Montant Plafonds du Compte"
            MainWindowComptabiliteForm.GunaLabel11.Text = "Jours d'Existence"
            MainWindowComptabiliteForm.GunaLabel22.Text = "Nom de la Personne à contacter"
            MainWindowComptabiliteForm.GunaLabel36.Text = "Adresse de facturation"
            MainWindowComptabiliteForm.GunaLabel37.Text = "Délai de Paiement (Jours)"
            MainWindowComptabiliteForm.GunaLabelInfoSup.Text = "INFORMATION SUPPLEMENTAIRE"
            MainWindowComptabiliteForm.GunaLabel13.Text = "Titulaire du compte"
            MainWindowComptabiliteForm.GunaLabel14.Text = "Entreprise"
            MainWindowComptabiliteForm.GunaLabel15.Text = "Profession"
            MainWindowComptabiliteForm.GunaButton1.Text = "Fermer"
            MainWindowComptabiliteForm.GunaButtonvERIFIER.Text = "Vérifier"
            MainWindowComptabiliteForm.GunaButtonActivation.Text = "Activer"
            MainWindowComptabiliteForm.GunaButtonAjouterCompte.Text = "Enregistrer"
            MainWindowComptabiliteForm.GunaLabel10.Text = "OUI"

            MainWindowComptabiliteForm.GunaGroupRecherche.Text = "CRITERES DE RECHERCHE"
            MainWindowComptabiliteForm.GunaCheckBoxRecherche.Text = "Rechercher"
            MainWindowComptabiliteForm.GunaCheckBoxToutes.Text = "Afficher Tous les comptes Actifs"
            MainWindowComptabiliteForm.GunaCheckBoxNonActiver.Text = "Afficher Tous les comptes Non actifs"
            MainWindowComptabiliteForm.GunaCheckBoxAttenteActivation.Text = "En attente d'activation"
            MainWindowComptabiliteForm.GunaLabel34.Text = "RAISON SOCIALE / NOM CLIENT"
            MainWindowComptabiliteForm.GunaLabel66.Text = "NUMERO COMPTE"
            MainWindowComptabiliteForm.GunaLabel83.Text = "INTITUTLE DE COMPTE"
            MainWindowComptabiliteForm.GunaLabel85.Text = "PERSONNE A CONTACTER"
            MainWindowComptabiliteForm.GunaLabel84.Text = "VILLE"
            MainWindowComptabiliteForm.GunaButtonAfficherLaListeDesComptes.Text = "Afficher"
            MainWindowComptabiliteForm.GunaButtonImprimerListeDesComptes.Text = "Imprimer"

            MainWindowComptabiliteForm.GunaButton17.Text = "Imprimer"
            MainWindowComptabiliteForm.GunaButtonFactureAgees.Text = "Afficher"
            MainWindowComptabiliteForm.GunaButtonAfficherCaution.Text = "Afficher"
            MainWindowComptabiliteForm.GunaButtonAfficherJournal.Text = "Afficher"
            MainWindowComptabiliteForm.GunaButton14.Text = "Afficher"
            MainWindowComptabiliteForm.AfficherLettredeRelance.Text = "Afficher"
            MainWindowComptabiliteForm.GunaButtonAfficher.Text = "Afficher"
            MainWindowComptabiliteForm.GunaButton16.Text = "Exporter"
            MainWindowComptabiliteForm.GunaButton5.Text = "Imprimer"
            MainWindowComptabiliteForm.GunaButtonImprimerSituation.Text = "Imprimer"
            MainWindowComptabiliteForm.GunaButtonEnregistrerFiscValue.Text = "Enregistrer"
            MainWindowComptabiliteForm.Label13.Text = "RECHERCHER ENTREPRISE"
            MainWindowComptabiliteForm.LabelBanque.Text = "BANQUES"
            MainWindowComptabiliteForm.GunaLabel9.Text = "Du"
            MainWindowComptabiliteForm.GunaLabel8.Text = "Au"

            MainWindowComptabiliteForm.GunaGroupBox1.Text = "CRITERES DE RECHERCHE"
            MainWindowComptabiliteForm.GunaLabel21.Text = "RAISON SOCIALE"
            MainWindowComptabiliteForm.GunaLabel20.Text = "NUMERO COMPTE"
            MainWindowComptabiliteForm.GunaLabel19.Text = "INTITUTLE DE COMPTE"
            MainWindowComptabiliteForm.Label1.Text = "Du"
            MainWindowComptabiliteForm.Label15.Text = "Au"
            MainWindowComptabiliteForm.GunaButton14.Text = "Afficher"
            MainWindowComptabiliteForm.GunaButton17.Text = "Imprimer"

            MainWindowComptabiliteForm.GunaButton18.Text = "JOURNAL DES SORTIES DE CAISSE"
            MainWindowComptabiliteForm.GunaButton4.Text = "JOURNAL DES ENTREES DE CAISSE"
            MainWindowComptabiliteForm.GunaButton7.Text = "RECETTES ENTREES"
            MainWindowComptabiliteForm.GunaButton19.Text = "JOURNAL DE CAISSE"
            MainWindowComptabiliteForm.GunaButton2.Text = "FACTURES"
            MainWindowComptabiliteForm.GunaButton9.Text = "JOURNAL BANCAIRE"
            MainWindowComptabiliteForm.GroupBox1.Text = "HISTORIQUES"
            MainWindowComptabiliteForm.GroupBox2.Text = "JOURNAUX"

        End If

    End Sub

    Public Sub serviceEtage(ByVal ActualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then

            'only up
            MainWindowServiceEtageForm.GunaButtonAfficherEtatDesChambres.Text = "View"
            MainWindowServiceEtageForm.GunaButtonAfficherLaListeDesChambres.Text = "View"
            MainWindowServiceEtageForm.GunaButtonAfficherHorsService.Text = "View"
            MainWindowServiceEtageForm.GunaButtonHistorique.Text = "View"
            MainWindowServiceEtageForm.GunaButton20.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonImpirmerRapportSEt.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonImprimer.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonImprimerHorsSrvice.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonPrintHistorique.Text = "Print"

            MainWindowServiceEtageForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindowServiceEtageForm.RESERVATIONToolStripMenuItem.Text = "BOOKING"
            MainWindowServiceEtageForm.SERVICEDETAGEToolStripMenuItem.Text = "HOUSE KEEPING"
            MainWindowServiceEtageForm.ToolStripMenuItem57.Text = "KITCHEN"
            MainWindowServiceEtageForm.ComptabilitéToolStripMenuItem.Text = "ACCOUNTING AND FINANCES"
            MainWindowServiceEtageForm.ECONOMATToolStripMenuItem.Text = "PURCHASE"
            MainWindowServiceEtageForm.TECHNIQUEToolStripMenuItem.Text = "TECHNICAL"

            MainWindowServiceEtageForm.ToolStripMenuItemSession.Text = "SESSION"
            MainWindowServiceEtageForm.ToolStripMenuItem117.Text = "Change password"
            MainWindowServiceEtageForm.FermerCaisseToolStripMenuItem.Text = "Close cash Register"
            MainWindowServiceEtageForm.PETITEToolStripMenuItem.Text = "Petty Cash Flow"
            MainWindowServiceEtageForm.OuvrirCaisseToolStripMenuItem.Text = "Open Cash Register"
            MainWindowServiceEtageForm.ClôturerToolStripMenuItem.Text = "Night Audit"
            MainWindowServiceEtageForm.ToolStripMenuItemConfig.Text = "SETTINGS"
            MainWindowServiceEtageForm.ToolStripMenuItemServTech.Text = "TECHNICAL SERVICE"
            MainWindowServiceEtageForm.ToolStripMenuItemSecurite.Text = "SECURITY"
            MainWindowServiceEtageForm.ToolStripMenuItem119.Text = "Close Session"

            MainWindowServiceEtageForm.GunaAdvenceButtonEtatDesChambres.Text = "CLEANING"
            MainWindowServiceEtageForm.GunaAdvenceButton1.Text = "PLANNING"
            MainWindowServiceEtageForm.GunaAdvenceButton2.Text = "ROOMS STATE"
            MainWindowServiceEtageForm.GunaAdvenceButtonHistorique.Text = "HISTORY"
            MainWindowServiceEtageForm.GunaAdvenceButton7.Text = "OUT OF SERVICE"
            MainWindowServiceEtageForm.GunaRadioButtonSalle.Text = "Hall"
            MainWindowServiceEtageForm.GunaAdvenceButton32.Text = "LOST / FOUND"
            MainWindowServiceEtageForm.GunaAdvenceButtonStatutsChambre.Text = "ROOMS STATUS"
            MainWindowServiceEtageForm.GunaAdvenceButton31.Text = "REPORT"
            MainWindowServiceEtageForm.GunaLabelDateDeTravailLabel.Text = "WORKING DATE : "
            MainWindowServiceEtageForm.GunaButtonFermer.Text = "Close"
            MainWindowServiceEtageForm.GunaButtonEnregistrer.Text = "Save"
            MainWindowServiceEtageForm.GunaLabelTypeChambreOuSalle.Text = "Room Type"
            MainWindowServiceEtageForm.GunaLabel21.Text = "Dirty"
            MainWindowServiceEtageForm.GunaLabel22.Text = "On going"
            MainWindowServiceEtageForm.GunaLabel23.Text = "To inspect"
            MainWindowServiceEtageForm.GunaLabel24.Text = "Clean"
            MainWindowServiceEtageForm.GunaLabel25.Text = "Out of Service"
            MainWindowServiceEtageForm.GunaButtonBlanchisserie.Text = "LAUNDRY"
            MainWindowServiceEtageForm.LabelLibelleActif.Text = "ROOM STATUS"
            MainWindowServiceEtageForm.GunaButtonEtatDesChambres.Text = "Refresh"
            MainWindowServiceEtageForm.GunaRadioButtonChambre.Text = "Rooms"

            MainWindowServiceEtageForm.GunaLabel17.Text = "Place where the object was lost"
            MainWindowServiceEtageForm.GunaLabel16.Text = "Date of lost"
            MainWindowServiceEtageForm.GunaLabel5.Text = "Category"
            MainWindowServiceEtageForm.GunaLabel9.Text = "Producer"
            MainWindowServiceEtageForm.GunaLabel8.Text = "Sub Category"
            MainWindowServiceEtageForm.GunaLabel12.Text = "Color"
            MainWindowServiceEtageForm.GunaLabel13.Text = "Color"
            MainWindowServiceEtageForm.GunaLabel14.Text = "Serial Number"
            MainWindowServiceEtageForm.GunaButtonArricherReservation.Text = "View"
            MainWindowServiceEtageForm.GunaGroupBoxRegistre.Text = "LIST OF LOST / FOUND"
            MainWindowServiceEtageForm.GunaLabel19.Text = "LOST AND FOUND"
            MainWindowServiceEtageForm.GunaButtonSaveObjets.Text = "Save"
            MainWindowServiceEtageForm.GunaLabel34.Text = "OBJECT NAME"
            MainWindowServiceEtageForm.GunaGroupRecherche.Text = "SEARCH CRITERIA"
            MainWindowServiceEtageForm.GunaLabel18.Text = "Description / Comment"

            MainWindowServiceEtageForm.GunaButtonAllBottomRightToLeft.Text = "Save"
            MainWindowServiceEtageForm.GunaButtonPrintP1.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonPrintP2.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonPrintP3.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonPrintP4.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonPrintP5.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonPrintP6.Text = "Print"
            MainWindowServiceEtageForm.GunaButtonPlanningDeNettoyage.Text = "CLEANING PLANNING"
            MainWindowServiceEtageForm.GunaButtonRapportNettoyage.Text = "PRODUCTIVITY REPORT"
            MainWindowServiceEtageForm.GunaButtonEtatsDesChambres.Text = "ROOMS STATE"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            MainWindowServiceEtageForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindowServiceEtageForm.RESERVATIONToolStripMenuItem.Text = "RESERVATION"
            MainWindowServiceEtageForm.SERVICEDETAGEToolStripMenuItem.Text = "SERVICE ETAGE"
            MainWindowServiceEtageForm.ToolStripMenuItem57.Text = "CUISINE"
            MainWindowServiceEtageForm.ComptabilitéToolStripMenuItem.Text = "COMPATBILITE ET FICNANCES"
            MainWindowServiceEtageForm.ECONOMATToolStripMenuItem.Text = "ECONOMAT"
            MainWindowServiceEtageForm.TECHNIQUEToolStripMenuItem.Text = "TECHNIQUE"

            MainWindowServiceEtageForm.ToolStripMenuItemSession.Text = "SESSION"
            MainWindowServiceEtageForm.ToolStripMenuItem117.Text = "Changer mot de passe"
            MainWindowServiceEtageForm.FermerCaisseToolStripMenuItem.Text = "Fermer Caisse"
            MainWindowServiceEtageForm.PETITEToolStripMenuItem.Text = "Petite Caisse"
            MainWindowServiceEtageForm.OuvrirCaisseToolStripMenuItem.Text = "Ouvrir Caisse"
            MainWindowServiceEtageForm.ClôturerToolStripMenuItem.Text = "Clôturer"
            MainWindowServiceEtageForm.ToolStripMenuItemConfig.Text = "CONFIGURATION"
            MainWindowServiceEtageForm.ToolStripMenuItemServTech.Text = "SERVICE TECHNIQUE"
            MainWindowServiceEtageForm.ToolStripMenuItemSecurite.Text = "SECURITE"
            MainWindowServiceEtageForm.ToolStripMenuItem119.Text = "Fermer Session"

            MainWindowServiceEtageForm.GunaAdvenceButtonEtatDesChambres.Text = "NETTOYAGE"
            MainWindowServiceEtageForm.GunaAdvenceButton1.Text = "PLANNING"
            MainWindowServiceEtageForm.GunaAdvenceButton2.Text = "ETATS DES CHAMBRES"
            MainWindowServiceEtageForm.GunaAdvenceButtonHistorique.Text = "HISTORIQUES"
            MainWindowServiceEtageForm.GunaAdvenceButton7.Text = "HORS SERVICES"
            MainWindowServiceEtageForm.GunaRadioButtonSalle.Text = "Salles"
            MainWindowServiceEtageForm.GunaAdvenceButton32.Text = "OBJETS TROUVES / PERDUS"
            MainWindowServiceEtageForm.GunaAdvenceButtonStatutsChambre.Text = "STATUTS DES CHAMBRES"
            MainWindowServiceEtageForm.GunaAdvenceButton31.Text = "RAPPORTS"
            MainWindowServiceEtageForm.GunaLabelDateDeTravailLabel.Text = "DATE DE TRAVAIL : "
            MainWindowServiceEtageForm.GunaButtonFermer.Text = "Fermer"
            MainWindowServiceEtageForm.GunaButtonEnregistrer.Text = "Enregistrer"
            MainWindowServiceEtageForm.GunaLabelTypeChambreOuSalle.Text = "Type de Chambre"
            MainWindowServiceEtageForm.GunaLabel21.Text = "Sale"
            MainWindowServiceEtageForm.GunaLabel22.Text = "En cours"
            MainWindowServiceEtageForm.GunaLabel23.Text = "A inspecters"
            MainWindowServiceEtageForm.GunaLabel24.Text = "Propre"
            MainWindowServiceEtageForm.GunaLabel25.Text = "Hors Service"
            MainWindowServiceEtageForm.GunaButtonBlanchisserie.Text = "BLANCHISSERIE"
            MainWindowServiceEtageForm.LabelLibelleActif.Text = "STATUTS DES CHAMBRES"
            MainWindowServiceEtageForm.GunaButtonEtatDesChambres.Text = "Rafraichir"

            MainWindowServiceEtageForm.GunaLabel7.Text = "Libellé"
            MainWindowServiceEtageForm.GunaCheckBoxFictif.Text = "Logement fictif"
            MainWindowServiceEtageForm.GunaLabelEtatChambreOuSalle.Text = "Etat Chambre"
            MainWindowServiceEtageForm.GunaLabel10.Text = "Localisation"
            MainWindowServiceEtageForm.GunaLabel11.Text = "Prix"
            MainWindowServiceEtageForm.GunaButtonFermer.Text = "Fermer"
            MainWindowServiceEtageForm.GunaButtonEnregistrer.Text = "Enregistrer"
            MainWindowServiceEtageForm.GunaButtonAfficherLaListeDesChambres.Text = "Afficher"
            MainWindowServiceEtageForm.GunaLabelMotif.Text = "Motifs"
            MainWindowServiceEtageForm.GunaButtonImprimer.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaButtonImprimerHorsSrvice.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaButtonHistorique.Text = "Afficher"
            MainWindowServiceEtageForm.GunaButtonPrintHistorique.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaGroupBoxTrouvees.Text = "ANNONCE D'OBJETS TROUVES"
            MainWindowServiceEtageForm.GunaButtonAfficherHorsService.Text = "Afficher"
            MainWindowServiceEtageForm.GunaLabel15.Text = "Titre de l'annonce"

            MainWindowServiceEtageForm.GunaLabel17.Text = "Endroit où l'objet a été égaré"
            MainWindowServiceEtageForm.GunaLabel16.Text = "Date de perte"
            MainWindowServiceEtageForm.GunaLabel5.Text = "Catégorie"
            MainWindowServiceEtageForm.GunaLabel9.Text = "Fabricant"
            MainWindowServiceEtageForm.GunaLabel8.Text = "Sous catégorie"
            MainWindowServiceEtageForm.GunaLabel12.Text = "Couleur"
            MainWindowServiceEtageForm.GunaLabel13.Text = "Modèl"
            MainWindowServiceEtageForm.GunaLabel14.Text = "Numéro de série"
            MainWindowServiceEtageForm.GunaButtonArricherReservation.Text = "Afficher"
            MainWindowServiceEtageForm.GunaGroupBoxRegistre.Text = "REGISTRE D'OBJETS PERDUS / TROUVEES"
            MainWindowServiceEtageForm.GunaLabel19.Text = "OBJETS TROUVES / PERDUS"
            MainWindowServiceEtageForm.GunaButtonSaveObjets.Text = "Enregistrer"
            MainWindowServiceEtageForm.GunaLabel34.Text = "NOM DE L'OBJET"
            MainWindowServiceEtageForm.GunaGroupRecherche.Text = "CRITERES DE RECHERCHE"
            MainWindowServiceEtageForm.GunaLabel18.Text = "Description / Commentaire"

            MainWindowServiceEtageForm.GunaButtonAllBottomRightToLeft.Text = "Enregistrer"
            MainWindowServiceEtageForm.GunaButtonPrintP1.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaButtonPrintP2.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaButtonPrintP3.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaButtonPrintP4.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaButtonPrintP5.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaButtonPrintP6.Text = "Imprimer"
            MainWindowServiceEtageForm.GunaButtonPlanningDeNettoyage.Text = "PLANNING DE NETTOYAGE"
            MainWindowServiceEtageForm.GunaButtonRapportNettoyage.Text = "RAPPORT DE PRODUCTIVITE"
            MainWindowServiceEtageForm.GunaButtonEtatsDesChambres.Text = "ETAT DES CHAMBRES"
            MainWindowServiceEtageForm.GunaButton21.Text = "PROVIDERS"
            MainWindowServiceEtageForm.GunaButton1.Text = "LINENS CLEANING"

        End If

    End Sub


    Public Sub etatChambre(ByVal ActualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then
            EtatDeChambreForm.GunaAdvenceButtonDébuter.Text = "Start"
            EtatDeChambreForm.GunaAdvenceButtonFin.Text = "End"
            EtatDeChambreForm.GunaAdvenceButtonTerminer.Text = "Check"
            EtatDeChambreForm.GunaFermer.Text = "Close"
            EtatDeChambreForm.GunaButtonEnregistrerCommentaire.Text = "Save"
        Else

        End If

    End Sub

    Public Sub controllerNettoyage(ByVal ActualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then

            ControllerNettoyageForm.GunaButtonEnregistrer.Text = "Save"
            ControllerNettoyageForm.GunaCheckBoxTousCocher.Text = "Tick All"
            ControllerNettoyageForm.GunaButton1.Text = "Close"
            ControllerNettoyageForm.Guna1.Text = "1. Knock and announce yourself to make sure the room is empty."
            ControllerNettoyageForm.GunaLabel5.Text = "2. Check"
            ControllerNettoyageForm.GunaA.Text = "a. The cleanliness of the room number"
            ControllerNettoyageForm.GunaB.Text = "b. The top of wardrobe"
            ControllerNettoyageForm.GunaC.Text = "c. The porper fonctioning of the locks"
            ControllerNettoyageForm.Guna3.Text = "3. Do a systematic and circulaire control : start from the right, move round the room to come from the left or the reverse."
            ControllerNettoyageForm.Guna4.Text = "4. Check the cleanliness of furniture and appliances"
            ControllerNettoyageForm.Guna5.Text = "5. Check the presence of welcoming paper, linens and hangers"
            ControllerNettoyageForm.Guna6.Text = "6. Make sure the Mini Bar is furnished"
            ControllerNettoyageForm.Guna7.Text = "7. Detect unpleasant smell"
            ControllerNettoyageForm.Guna8.Text = "8. Bathroom : make sure the towels are available and in good state"
            ControllerNettoyageForm.Guna9.Text = "9. Bathroom : Check the sanitary facilities (sink and bidet)"
            ControllerNettoyageForm.Guna10.Text = "10. Cross check to make sure everything is ok"
            ControllerNettoyageForm.Guna11.Text = "11. Close all the doors"

        Else

        End If

    End Sub

    Public Sub article(ByVal ActualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then

            ArticleForm.TabControlArticle.TabPages(0).Text = "Description"
            ArticleForm.TabControlArticle.TabPages(1).Text = "List"
            ArticleForm.TabControlArticle.TabPages(2).Text = "Technical Sheet"
            ArticleForm.TabControlArticle.TabPages(3).Text = "List of Technical Sheet"
            ArticleForm.TabControlArticle.TabPages(4).Text = "Details of Technical Sheet"
            ArticleForm.TabControlArticle.TabPages(5).Text = "Order"

            ArticleForm.GunaLabel69.Text = "Unconfirmed Order"
            ArticleForm.GunaLabel68.Text = "Number of Orders"
            ArticleForm.GunaGroupBox1.Text = "Search Criteria"
            ArticleForm.GunaLabel62.Text = "TECHNICAL SHEET"

            ArticleForm.GunaButtonPreparer.Text = "Prepare >>"
            ArticleForm.GunaButton3.Text = "<< Return"
            ArticleForm.GunaLabel35.Text = "Prepared Order"
            ArticleForm.GunaLabel27.Text = "Pending Order"
            ArticleForm.GunaLabel52.Text = "Number of Orders"
            ArticleForm.GunaLabel48.Text = "Production Cost"
            ArticleForm.GunaLabel41.Text = "Technical Sheet"
            ArticleForm.GunaLabel50.Text = "Number of plate"
            ArticleForm.GunaLabel47.Text = "Total Sales"
            ArticleForm.GunaLabel49.Text = "Production Cost"
            ArticleForm.GunaLabel53.Text = "Grosse profit"
            ArticleForm.GunaButtonImprimerCommandeDuBar.Text = "Print"
            ArticleForm.GunaButtonAfficherLesFacturesEtReglement.Text = "Print"
            'ArticleForm.GunaButtonCloturerFolio2.Text = "Save"
            ArticleForm.GunaCheckBoxPortion.Text = "Produce portions"
            ArticleForm.GunaButtonVisualierArticlePreparee.Text = "View"
            ArticleForm.GunaLabel33.Text = "Technical Sheet"
            ArticleForm.GunaLabel34.Text = "Name of Technical Sheet"
            ArticleForm.GunaButtonAjouterPlat.Text = "Add Plate"
            ArticleForm.GunaLabel6.Text = "Quantity"
            ArticleForm.GunaLabel33.Text = "View"
            ArticleForm.GunaLabel10.Text = "Choose Materials"
            ArticleForm.GunaButtonAjouterLigne.Text = "Add"
            ArticleForm.GunaLabelModifPetiteUnite.Text = "New Unit"
            ArticleForm.GunaLabelUniteDeComptage.Text = "Unit"
            ArticleForm.GunaLabelMagasinDeDestination.Text = "Receiving Store"
            ArticleForm.GunaLabelMagasinDeDestination.Text = "Clearance Store"
            ArticleForm.GunaButtonImprimerFicheTechnique.Text = "Print"
            ArticleForm.GunaButtonAfficherLesFacturesEtReglement.Text = "Print"
            ArticleForm.GunaButtonPreparationDePlat.Text = "Save"
            ArticleForm.GunaButtonCreationDeFiche.Text = "Save"
            ArticleForm.GunaLabel11.Text = "Cost Price :"
            ArticleForm.GunaLabel42.Text = "Misce. :"
            ArticleForm.GunaLabel21.Text = "Average perentage of unsolde :"
            ArticleForm.GunaLabel26.Text = "Profit coefficient :"
            ArticleForm.GunaLabel23.Text = "Selling Price :"
            ArticleForm.GunaLabel44.Text = "Misce. Amount :"
            ArticleForm.GunaLabel31.Text = "Cost price per portion sold :"
            ArticleForm.GunaLabel20.Text = "Cost price per portion Produced :"
            ArticleForm.GunaLabel24.Text = "Grosse Profit :"
            ArticleForm.GunaLabel25.Text = "Profit rate :"
            ArticleForm.CoefFxnDuPrixDeVente.Text = "Profit coefficient depends on the selling price  :"
            ArticleForm.PrixDeVenteFxnDuCoef.Text = "Selling price depends on the profit coefficient"
            ArticleForm.GunaButtonAfficherFiche.Text = "View"

            ArticleForm.GunaLabel13.Text = "Points Of Sales"
            ArticleForm.GunaLabel4.Text = "Item Category"
            ArticleForm.GunaLabel45.Text = "Item Family"
            ArticleForm.GunaLabel46.Text = "Item Sub Family"
            ArticleForm.GunaCheckBoxAlaCarte.Text = "Item on Menu"
            ArticleForm.GunaCheckBoxBoisson.Text = "Drinks"
            ArticleForm.GunaCheckBoxVisibiliteAuBar.Text = "Visible for Sale"
            ArticleForm.GunaLabel19.Text = "Item Code"
            ArticleForm.GunaLabel2.Text = "Name"
            ArticleForm.GunaLabel18.Text = "Stock Management"
            ArticleForm.GunaLabel7.Text = "Storing Unit"
            ArticleForm.GunaLabel28.Text = "Saling Unit"
            ArticleForm.GunaLabel28.Text = "Selling Unit"
            ArticleForm.GunaLabel39.Text = "Volume"
            ArticleForm.GunaLabel37.Text = "Shot Unit"
            ArticleForm.GunaLabel36.Text = "Quantity"
            ArticleForm.GunaLabelNbreDeConso.Text = "Number of Shots"
            ArticleForm.GunaLabel40.Text = "Centi Litre"
            ArticleForm.GunaLabel29.Text = "Centi Litre"
            ArticleForm.GunaLabel38.Text = "Price 1 of Shot"
            ArticleForm.GunaLabel57.Text = "Price 2 of Shot"
            ArticleForm.GunaLabel58.Text = "Price 3 of Shot"
            ArticleForm.GunaLabel59.Text = "Price 4 of Shot"
            ArticleForm.GunaLabel16.Text = "Selling Price 1"
            ArticleForm.GunaLabel54.Text = "Selling Price 2"
            ArticleForm.GunaLabel55.Text = "Selling Price 3"
            ArticleForm.GunaLabel56.Text = "Selling Price 4"
            ArticleForm.GunaLabelFicheTechnique.Text = "Technical Sheet"
            ArticleForm.GunaLabel12.Text = "Stock Quantity"
            ArticleForm.GunaLabelStockEnConso.Text = "Stock Quantity in Shot"
            ArticleForm.GunaButtonFicheDeStock.Text = "Stock Form"
            ArticleForm.GunaButton1.Text = "Cancel"
            ArticleForm.GunaLabel66.Text = "Recommeded Selling Price"
            ArticleForm.GunaLabel66.Text = "Recommeded Buying Price"
            ArticleForm.GunaLabel14.Text = "Minimum Stock of Small Store"
            ArticleForm.GunaLabel3.Text = "Minimum Stock of Big Store"
            ArticleForm.GunaLabel15.Text = "Serial N°"
            ArticleForm.GunaButtonUpload.Text = "Upload Image"
            ArticleForm.GunaButtonEnregistrer.Text = "Create"
            ArticleForm.GunaLabelPrixAchat.Text = "Buying Price"
            ArticleForm.GunaLabel17.Text = "Average Buying Price"
            ArticleForm.GunaButton2.Text = "View"
            ArticleForm.GunaButton5.Text = "Add"
            ArticleForm.GunaGroupBox12.Text = "SEARCH CRITERIA"
            ArticleForm.GunaLabel61.Text = "CREATION DATE"
            ArticleForm.GunaLabel116.Text = "ITEM CODE / NAME"

        End If

    End Sub

    Public Sub MainCouranteReception(ByVal ActualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then

            MainCouranteReceptionForm.GunaLabel3.Text = "DAYLY FINANCIAL REPORT OF"
            MainCouranteReceptionForm.GunaButtonAfficher.Text = "View"
            MainCouranteReceptionForm.GunaButtonImprimer.Text = "Print"
            MainCouranteReceptionForm.GunaLabelGestCompteGeneraux.Text = "DAYLY FINANCIAL REPORT"

        End If

    End Sub

    Public Sub economat(ByVal actualLanguageValue As Integer)

        MainWindowEconomat.TabControlEconomat.TabPages.RemoveAt(2)

        MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Clear()
        MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Clear()
        MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then

            MainWindowEconomat.ToolStripMenuItem1.Text = "Establish Delivery Slip"
            MainWindowEconomat.AnnulerPrécédentToolStripMenuItem.Text = "Cancel Previous Action"
            MainWindowEconomat.ImprimerToolStripMenuItem.Text = "Print"

            MainWindowEconomat.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindowEconomat.RESERVATIONToolStripMenuItem.Text = "BOOKING"
            MainWindowEconomat.SERVICEDETAGEToolStripMenuItem.Text = "HOUSE KEEPING"
            MainWindowEconomat.ToolStripMenuItem53.Text = "KITCHEN"
            MainWindowEconomat.ComptabilitéToolStripMenuItem.Text = "ACCOUNTING AND FINANCES"
            MainWindowEconomat.ECONOMATToolStripMenuItem.Text = "PURCHASE"
            MainWindowEconomat.TECHNIQUEToolStripMenuItem.Text = "TECHNICAL"
            MainWindowEconomat.SupprimerToolStripMenuItem1.Text = "Remove"
            MainWindowEconomat.ToolStripMenuItemSession.Text = "SESSION"
            MainWindowEconomat.ToolStripMenuItem117.Text = "Change password"
            'MainWindowEconomat.ApprovisionnementToolStripMenuItem.Text = "Supply"
            MainWindowEconomat.FermerCaisseToolStripMenuItem.Text = "Close cash Register"
            MainWindowEconomat.PETITEToolStripMenuItem.Text = "Petty Cash Flow"
            MainWindowEconomat.OuvrirCaisseToolStripMenuItem.Text = "Open Cash Register"
            MainWindowEconomat.ClôturerToolStripMenuItem.Text = "Night Audit"
            MainWindowEconomat.ToolStripMenuItemConfig.Text = "SETTINGS"
            MainWindowEconomat.ToolStripMenuItemServTech.Text = "TECHNICAL SERVICE"
            MainWindowEconomat.ToolStripMenuItemSecurite.Text = "SECURITY"
            MainWindowEconomat.ToolStripMenuItem119.Text = "Close Session"

            MainWindowEconomat.GunaAdvenceButton2.Text = "PURCHASE"
            MainWindowEconomat.GunaAdvenceButton20.Text = "TECHNICAL SHEET"
            MainWindowEconomat.GunaAdvenceButton18.Text = "DELIVERY SLIP"
            MainWindowEconomat.GunaAdvenceButton5.Text = "LIST OF SLIPS"
            MainWindowEconomat.GunaAdvenceButton26.Text = "SUPPLIERS"
            MainWindowEconomat.GunaAdvenceButton1.Text = "STORES"
            MainWindowEconomat.GunaAdvenceButton4.Text = "REPORTS"
            MainWindowEconomat.GunaButtonAfficherValidee.Text = "View"
            MainWindowEconomat.GunaLabel107.Text = "Type of Slip"
            MainWindowEconomat.GunaGroupBox12.Text = "SEARCH CRITERIA"

            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Delivery slip")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Requisition")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Inventory")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Exit slip")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Exceptional Exit")
            'MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Product Return")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Inter Store Transfer")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Exceptional Entry")
            'MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Store Requisition")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Order slip")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Market List")

            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Delivery slip")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Requisition")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Inventory")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Exit slip")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Exceptional Exit")
            'MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Product Return")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Inter Store Transfer")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Exceptional Entry")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Order slip")
            'MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Store Requisition")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Market List")

            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Delivery slip")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Requisition")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Inventory")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Exit slip")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Exceptional Exit")
            'MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Product Return")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Inter Store Transfer")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Exceptional Entry")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Order slip")
            'MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Store Requisition")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Market List")

            MainWindowEconomat.TabControlEconomat.TabPages(0).Text = "List of slips"
            MainWindowEconomat.TabControlEconomat.TabPages(1).Text = "Slip"
            MainWindowEconomat.TabControlEconomat.TabPages(2).Text = "Reports"
            MainWindowEconomat.GunaGroupBox7.Text = "Slips"
            MainWindowEconomat.GunaButtonAfficher.Text = "View"
            MainWindowEconomat.GunaButtonImpirmerRapportEconomat.Text = "Print"
            MainWindowEconomat.GroupBox1.Text = "SLIP"
            MainWindowEconomat.GroupBox2.Text = "PRODUCTS"
            MainWindowEconomat.GroupBox3.Text = "STOCK MANAGEMENT"
            MainWindowEconomat.GunaGroupBoxCreationBordereau.Text = "Slip Creation"
            MainWindowEconomat.GunaButton1.Text = "New"
            MainWindowEconomat.GunaButton13.Text = "Empty"
            MainWindowEconomat.GunaCheckBoxPUOuPT.Text = "Unit Price"
            MainWindowEconomat.GunaLabel93.Text = "Name of slip"
            MainWindowEconomat.GunaLabelRefBordero.Text = "Order slip"
            MainWindowEconomat.GunaLabel3.Text = "Period"
            MainWindowEconomat.GunaLabel4.Text = "From"
            MainWindowEconomat.GunaLabel5.Text = "To"
            MainWindowEconomat.GunaGroupBoxListeDesBordereaux.Text = "Slip Content"
            MainWindowEconomat.GunaButtonAnnulerBordereau.Text = "Cancel"
            MainWindowEconomat.GunaButtonDetails.Text = "Price History"
            MainWindowEconomat.GunaButtonImpressionDirecte.Text = "Print"
            MainWindowEconomat.GunaButtonEnregistrer.Text = "Save"
            MainWindowEconomat.GunaButtonCommander.Text = "Order"
            MainWindowEconomat.GunaButtonValider.Text = "Validate"
            MainWindowEconomat.GunaButtonVerification.Text = "Verification"
            MainWindowEconomat.GunaButtonController.Text = "Control"
            MainWindowEconomat.LabelQuantite.Text = "QTY"
            MainWindowEconomat.LabelCout.Text = "UP"
            MainWindowEconomat.Label1.Text = "UNIT"
            MainWindowEconomat.GunaButtonAjouterLigne.Text = "Add"
            MainWindowEconomat.Label9.Text = "Threshold qty"
            MainWindowEconomat.LabelPteUnite.Text = "Small Unit qty"
            MainWindowEconomat.LabelGrdeUnite.Text = "Big Unit qty"
            MainWindowEconomat.Label12.Text = "Lowest Price"
            MainWindowEconomat.Label5.Text = "Last Price"
            MainWindowEconomat.LabelQuantiteEnMagasinSource.Text = "Source Store Qty"
            MainWindowEconomat.LabelQteEnMagasinDeDestination.Text = "Destination Store Qty"
            MainWindowEconomat.GunaCheckBoxLecteurRFID.Text = "RFI Reader"
            MainWindowEconomat.GunaLabelMagasin_1.Text = "Receiving Store"
            MainWindowEconomat.GunaLabelMagasin_2.Text = "Destination Store"
            MainWindowEconomat.GunaLabel91.Text = "Third Party"
            MainWindowEconomat.GunaLabel97.Text = "Type of Third Party"
            MainWindowEconomat.Label6.Text = "COST PRICE"
            MainWindowEconomat.Label8.Text = "SELLING PRICE"
            MainWindowEconomat.Label4.Text = "PROFIT"
            MainWindowEconomat.GunaButton2.Text = "LIST OF SLIPS"
            MainWindowEconomat.GunaButton11.Text = "PRODUCT SHEET (ARTICLES / RAW MATERIALS)"
            MainWindowEconomat.GunaButtonProdRetau.Text = "KITCHEN PRODUCTION"
            MainWindowEconomat.GunaButton4.Text = "TECHNICAL SHEET"
            MainWindowEconomat.GunaButton8.Text = "KITCHEN ORDER"
            MainWindowEconomat.GunaButton12.Text = "STOCK TRACKING SHEET"
            MainWindowEconomat.GunaButton10.Text = "CUMULATED KITCHEN PRODUCTION / ORDER"
            MainWindowEconomat.GunaButtonInventaire.Text = "STOCK INVENTORY"
            MainWindowEconomat.GunaButton6.Text = "INCOMING / OUTGOING GROUPED BY STORE"
            MainWindowEconomat.GunaButton9.Text = "PERIODIC PURCHASE"
            MainWindowEconomat.TransférerToolStripMenuItem.Text = "Print"

            MainWindowEconomat.GunaComboBoxTypeTiers.Items.Clear()
            MainWindowEconomat.GunaComboBoxTypeTiers.Items.Add("Client")
            MainWindowEconomat.GunaComboBoxTypeTiers.Items.Add("Supplier")
            MainWindowEconomat.GunaComboBoxTypeTiers.Items.Add("Personnel")
            MainWindowEconomat.GunaLabel89.Text = "Type of Slip"
            MainWindowEconomat.GunaLabel6.Text = "From"
            MainWindowEconomat.GunaLabel7.Text = "To"
            MainWindowEconomat.GunaButtonPopularMeals.Text = "POPULAR DISHES"

        Else

            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Bon de Réception")
            'MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Bon de Réquisition")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Demande d'Achat")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Inventaire")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Sortie")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Sortie Exceptionnelle")
            'MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Retour Marchandises")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Transfert Inter Magasin")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Entrée Exceptionnelle")
            'MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Bon Approvisionnement")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Bon de Commande")
            MainWindowEconomat.GunaComboBoxTypeBordereau.Items.Add("Liste du Marché")

            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Bon de Réception")
            'MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Bon de Réquisition")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Demande d'Achat")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Inventaire")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Sortie")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Sortie Exceptionnelle")
            'MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Retour Marchandises")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Transfert Inter Magasin")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Entrée Exceptionnelle")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Bon de Commande")
            'MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Bon Approvisionnement")
            MainWindowEconomat.GunaComboBoxTypeDeBordereau.Items.Add("Liste du Marché")

            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Bon de Réception")
            'MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Bon de Réquisition")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Demande d'Achat")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Inventaire")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Sortie")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Sortie Exceptionnelle")
            'MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Retour Marchandises")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Transfert Inter Magasin")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Entrée Exceptionnelle")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Bon de Commande")
            'MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Bon Approvisionnement")
            MainWindowEconomat.GunaComboBoxTypeBorderoRapport.Items.Add("Liste du Marché")

        End If

    End Sub

    Public Sub fournisseur(ByVal actualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then

            FournisseurForm.GunaLabel2.Text = "% Discount"
            FournisseurForm.GunaLabel4.Text = "Name"
            FournisseurForm.GunaLabel10.Text = "Addresse"
            FournisseurForm.GunaLabel5.Text = "Telephone"
            FournisseurForm.GunaLabel6.Text = "Account Number"
            FournisseurForm.GunaLabel8.Text = "Account Name"
            FournisseurForm.GunaButtonEnregistrer.Text = "Save"
            FournisseurForm.GunaButton1.Text = "Cancel"
            FournisseurForm.GunaButtonAfficher.Text = "View"
            FournisseurForm.GunaLabelGestCompteGeneraux.Text = "SUPPLIERS"
            FournisseurForm.GunaCheckBoxBlanchisseur.Text = "LAUNDRY"
            FournisseurForm.TabControl1.TabPages(1).Text = "List"
            FournisseurForm.SupprimerToolStripMenuItem.Text = "Delete"

        End If

    End Sub


    Public Sub depenseFamily(ByVal actualLanguageValue As Integer)

        DepenseFamilyForm.GunaComboBoxModeReglement.Items.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then
            DepenseFamilyForm.GunaButton6.Text = "View"
            DepenseFamilyForm.GunaComboBoxModeReglement.Items.Add("Cash") '0
        Else
            DepenseFamilyForm.GunaButton6.Text = "Afficher"
            DepenseFamilyForm.GunaComboBoxModeReglement.Items.Add("Cash") '0
        End If

    End Sub

    Public Sub depotGarantie(ByVal actualLanguageValue As Integer)

        DepotGarantieForm.GunaComboBoxTypeDepot.Items.Clear()

        If GlobalVariable.actualLanguageValue = 0 Then
            DepotGarantieForm.GunaComboBoxTypeDepot.Items.Add("Reservations")
            DepotGarantieForm.GunaComboBoxTypeDepot.Items.Add("Invidual / Company")
            DepotGarantieForm.GunaLabelTitle.Text = "ARRHES"
            DepotGarantieForm.GunaLabel1.Text = "AMOUNT"
            DepotGarantieForm.GunaButtonEnregistrer.Text = "Save"
            DepotGarantieForm.GunaLabel41.Text = "TOTAL DEBIT"
            DepotGarantieForm.GunaLabel2.Text = "TOTAL CREDIT"
            DepotGarantieForm.GunaLabel4.Text = "BALANCE"
            DepotGarantieForm.GunaLabel5.Text = "TOTAL BALANCE"
        Else
            DepotGarantieForm.GunaComboBoxTypeDepot.Items.Add("Reservations")
            DepotGarantieForm.GunaComboBoxTypeDepot.Items.Add("Entreprise / Inviduelle")
            DepotGarantieForm.GunaLabelTitle.Text = "DEPOT DE GARANTIE"
            DepotGarantieForm.GunaLabel1.Text = "MONTANT"
            DepotGarantieForm.GunaButtonEnregistrer.Text = "Enregistrer"
            DepotGarantieForm.GunaLabel41.Text = "DEBIT"
            DepotGarantieForm.GunaLabel2.Text = "CREDIT"
            DepotGarantieForm.GunaLabel4.Text = "SOLDE"
            DepotGarantieForm.GunaLabel5.Text = "TOTAL SOLDE"
        End If

    End Sub

    Public Sub profilChoix(ByVal actualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then
            ProfilChoixForm.GunaButtonAjouter.Text = "Validate"
            ProfilChoixForm.GunaLabel1.Text = "Profil to be used"
        End If

    End Sub

    Public Sub notification(ByVal actualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then
            NotificationsForm.GunaLabelTitle.Text = "Validate"
            NotificationsForm.GunaButton3.Text = "WRITE"
            NotificationsForm.GunaButton4.Text = "RECEIVED MESSAGES"
            NotificationsForm.GunaButtonMessageLus.Text = "READ MESSAGES"
            NotificationsForm.GunaButtonMessageNonLus.Text = "UN READ MESSAGES"
            NotificationsForm.GunaButtonEnvoyer.Text = "Send"
            NotificationsForm.GunaFermer.Text = "Close"
            NotificationsForm.GunaLabel3.Text = "Subject : "
        End If

    End Sub

    Public Sub mainwindowCuisine(ByVal actualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then

            MainWindowCuisineForm.GunaComboBoxEntreSortie.Items.Clear()
            MainWindowCuisineForm.GunaComboBoxEntreSortie.Items.Add("In")
            MainWindowCuisineForm.GunaComboBoxEntreSortie.Items.Add("Out")

            MainWindowCuisineForm.GunaDataGridViewInventaire.Columns.Clear()
            MainWindowCuisineForm.GunaDataGridViewInventaire.Columns.Add("CODE_ARTICLE", "CODE ARTICLE")
            MainWindowCuisineForm.GunaDataGridViewInventaire.Columns.Add("ITEM", "ITEM")
            MainWindowCuisineForm.GunaDataGridViewInventaire.Columns.Add("QUANTITE_ACTUEL", "STOCK")
            MainWindowCuisineForm.GunaDataGridViewInventaire.Columns.Add("QUANTITE_REEL", "REEL QTY")

            MainWindowCuisineForm.GunaDataGridViewInventaire.Columns(0).Visible = False

            MainWindowCuisineForm.GunaAdvenceButtonCommande.Text = "ORDER"
            MainWindowCuisineForm.GunaAdvenceButtonMatiere.Text = "MATERIAL"
            MainWindowCuisineForm.GunaAdvenceButton20.Text = "ARTICLE"
            MainWindowCuisineForm.GunaAdvenceButton18.Text = "TECHNICAL SHEET"
            MainWindowCuisineForm.GunaAdvenceButton2.Text = "MARKET LIST"
            MainWindowCuisineForm.GunaAdvenceButton5.Text = "LIST OF MATERIAL"
            MainWindowCuisineForm.GunaAdvenceButton26.Text = "LIST OF ARTICLE"
            MainWindowCuisineForm.GunaAdvenceButton1.Text = "LIST OF TECHNICAL SHEET"

            MainWindowCuisineForm.GunaButtonInventaire.Text = "INVENTORY"
            MainWindowCuisineForm.GunaButtonImpressionDirecte.Text = "Print"
            MainWindowCuisineForm.GunaButtonImpirmerRapportEconomat.Text = "Print"
            MainWindowCuisineForm.GunaButtonAfficher.Text = "View"

            MainWindowCuisineForm.ToolStripMenuItemSession.Text = "SESSION"
            MainWindowCuisineForm.ToolStripMenuItem117.Text = "Change password"
            MainWindowCuisineForm.ApprovisionnementToolStripMenuItem.Text = "Request"
            MainWindowCuisineForm.ToolStripMenuItemConfig.Text = "SETTINGS"
            MainWindowCuisineForm.ToolStripMenuItemServTech.Text = "TECHNICAL"
            MainWindowCuisineForm.ToolStripMenuItemSecurite.Text = "SECURITY"

            MainWindowCuisineForm.ReceptionToolStripMenuItem.Text = "RECEPTION"
            MainWindowCuisineForm.RESERVATIONToolStripMenuItem.Text = "BOOKING"
            MainWindowCuisineForm.SERVICEDETAGEToolStripMenuItem.Text = "HOUSE KEEPING"
            MainWindowCuisineForm.CUISINEToolStripMenuItem.Text = "KITCHEN"
            MainWindowCuisineForm.ComptabilitéToolStripMenuItem.Text = "ACCOUNTING AND FINANCES"
            MainWindowCuisineForm.ECONOMATToolStripMenuItem.Text = "PURCHASE"
            MainWindowCuisineForm.TECHNIQUEToolStripMenuItem.Text = "TECHNICAL"

        End If

    End Sub

    Public Sub config(ByVal actualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then
            ConfigForm.GunaButton2.Text = "Save"
        End If

    End Sub

    Public Sub authetification(ByVal actualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then

            GenerationForm.GunaComboBoxAction.Items.Clear()
            GenerationForm.GunaComboBoxAction.Items.Add("Change accommodation price")
            GenerationForm.GunaComboBoxAction.Items.Add("Cancel Check In")
            GenerationForm.GunaComboBoxAction.Items.Add("Cancel Charge")
            GenerationForm.GunaComboBoxAction.Items.Add("Discount")

            GenerationForm.GunaButtonAfficherValidee.Text = "Send"
            GenerationForm.GunaButton1.Text = "Validate"

        End If

    End Sub

    Public Sub marketing(ByVal actualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then
            MainwindoMarketinngForm.GunaLabel131.Text = "WORKNG DATE:"
        End If

    End Sub

    Public Sub consolidation(ByVal actualLanguageValue As Integer)

        If GlobalVariable.actualLanguageValue = 0 Then
            ConsolidationForm.GunaLabel2.Text = "ORDERS"
            ConsolidationForm.GunaButton1.Text = "Cancel"
            ConsolidationForm.GunaButtonConsolider.Text = "Consolidate"
            ConsolidationForm.GunaLabel3.Text = "Consolidated Orders"
            ConsolidationForm.GunaLabel3.Text = "Orders to consolidate"
        End If

    End Sub

    Public Sub side_menu_mainwindow(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            MainWindow.ToolStripMenuItem73.Text = "Tresorerie"
            MainWindow.ToolStripMenuItem96.Text = "Third, Rooms"
            MainWindow.ToolStripMenuItem113.Text = "Fault Type"
            MainWindow.TarifsToolStripMenuItem.Text = "Prices"
            MainWindow.ClubEliteToolStripMenuItem.Text = "Elite Club"
            MainWindow.ToolStripMenuItem75.Text = "General Account"
            MainWindow.ToolStripMenuItem76.Text = "Cash Register"
            MainWindow.BanqueToolStripMenuItem.Text = "Bank"
            MainWindow.FamilleDepenseToolStripMenuItem.Text = "Charts of Account"
            MainWindow.CompteDexploitationToolStripMenuItem.Text = "Exploitation Account"
            MainWindow.ToolStripMenuItem82.Text = "Point of Sales"
            MainWindow.CatégoriesToolStripMenuItem.Text = "Category"
            MainWindow.ToolStripMenuItem83.Text = "Artticle Family"
            MainWindow.FamilleDArToolStripMenuItem.Text = "Article Sub Family"
            MainWindow.FicheTechniqueToolStripMenuItem.Text = "Technical Sheet"
            MainWindow.ToolStripMenuItem93.Text = "Counting Unit"
            MainWindow.MatièresToolStripMenuItem.Text = "Material"
            MainWindow.ToolStripMenuItem4.Text = "Maintenance tools"
            MainWindow.ToolStripMenuItem91.Text = "Store"
            MainWindow.ToolStripMenuItem92.Text = "Store Affectation"
            MainWindow.ToolStripMenuItem97.Text = "Localisation"
            MainWindow.ToolStripMenuItem98.Text = "Price per Client Category"
            MainWindow.ToolStripMenuItem99.Text = "Client Category"
            MainWindow.ToolStripMenuItem100.Text = "Client"
            MainWindow.ToolStripMenuItem101.Text = "Price Client/Article"
            MainWindow.ToolStripMenuItem102.Text = "Client Messages"
            MainWindow.ToolStripMenuItem103.Text = "Type of Personnel"
            MainWindow.ToolStripMenuItem105.Text = "Suppliers"
            MainWindow.ToolStripMenuItem106.Text = "Commercials"
            MainWindow.ToolStripMenuItem107.Text = "Type of Room/Hall"
            MainWindow.ToolStripMenuItem108.Text = "Room/Hall"
            MainWindow.TypeDévènementToolStripMenuItemEvent.Text = "Type of Events"
            MainWindow.ToolStripMenuItem111.Text = "Reservation Source"
            MainWindow.ToolStripMenuItem112.Text = "Tourist Tax"
            MainWindow.ToolStripMenuItem128.Text = "Intervention Slip"
            MainWindow.ToolStripMenuItem123.Text = "Request for Intervention"
            MainWindow.ToolStripMenuItem124.Text = "Instruction Book"
            MainWindow.FamilleDePannesToolStripMenuItem.Text = "Fault Family"
            MainWindow.SousFamillesDePannesToolStripMenuItem.Text = "Fault Sub Family"
            MainWindow.ToolStripMenuItem131.Text = "Snitches"
            MainWindow.ToolStripMenuItem132.Text = "Indicated Faults"
            MainWindow.ToolStripMenuItem133.Text = "Company"
            MainWindow.ToolStripMenuItem134.Text = "Agencies"
            MainWindow.ToolStripMenuItem136.Text = "Users"
            MainWindow.ToolStripMenuItem137.Text = "Register"
            MainWindow.UploaderToolStripMenuItem.Text = "Upload"
            MainWindow.LicenceToolStripMenuItem.Text = "License"
        End If

    End Sub

    Public Sub side_menu_bar_restaurant_form(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            BarRestaurantForm.ToolStripMenuItem73.Text = "Tresorerie"
            BarRestaurantForm.ToolStripMenuItem96.Text = "Third, Rooms"
            BarRestaurantForm.ToolStripMenuItem113.Text = "Fault Type"
            BarRestaurantForm.TarifsToolStripMenuItem.Text = "Prices"
            BarRestaurantForm.ClubEliteToolStripMenuItem.Text = "Elite Club"
            BarRestaurantForm.ToolStripMenuItem75.Text = "General Account"
            BarRestaurantForm.ToolStripMenuItem76.Text = "Cash Register"
            BarRestaurantForm.BanqueToolStripMenuItem.Text = "Bank"
            BarRestaurantForm.ToolStripMenuItem82.Text = "Point of Sales"
            BarRestaurantForm.CatégoriesToolStripMenuItem.Text = "Category"
            BarRestaurantForm.ToolStripMenuItem83.Text = "Artticle Family"
            BarRestaurantForm.FamilleDArToolStripMenuItem.Text = "Article Sub Family"
            BarRestaurantForm.ToolStripMenuItem93.Text = "Counting Unit"
            BarRestaurantForm.MatièresToolStripMenuItem.Text = "Material"
            BarRestaurantForm.ToolStripMenuItem91.Text = "Store"
            BarRestaurantForm.ToolStripMenuItem92.Text = "Store Affectation"
            BarRestaurantForm.ToolStripMenuItem97.Text = "Localisation"
            BarRestaurantForm.ToolStripMenuItem98.Text = "Price per Client Category"
            BarRestaurantForm.ToolStripMenuItem99.Text = "Client Category"
            BarRestaurantForm.ToolStripMenuItem100.Text = "Client"
            BarRestaurantForm.ToolStripMenuItem101.Text = "Price Client/Article"
            BarRestaurantForm.ToolStripMenuItem102.Text = "Client Messages"
            BarRestaurantForm.ToolStripMenuItem103.Text = "Type of Personnel"
            BarRestaurantForm.ToolStripMenuItem105.Text = "Suppliers"
            BarRestaurantForm.ToolStripMenuItem106.Text = "Commercials"
            BarRestaurantForm.ToolStripMenuItem107.Text = "Type of Room/Hall"
            BarRestaurantForm.ToolStripMenuItem108.Text = "Room/Hall"
            BarRestaurantForm.TypeDévènementToolStripMenuItemEvent.Text = "Type of Events"
            BarRestaurantForm.ToolStripMenuItem111.Text = "Reservation Source"
            BarRestaurantForm.ToolStripMenuItem112.Text = "Tourist Tax"
            BarRestaurantForm.ToolStripMenuItem128.Text = "Intervention Slip"
            BarRestaurantForm.ToolStripMenuItem123.Text = "Request for Intervention"
            BarRestaurantForm.ToolStripMenuItem124.Text = "Instruction Book"
            BarRestaurantForm.FamilleDePannesToolStripMenuItem.Text = "Fault Family"
            BarRestaurantForm.SousFamillesDePannesToolStripMenuItem.Text = "Fault Sub Family"
            BarRestaurantForm.ToolStripMenuItem131.Text = "Snitches"
            BarRestaurantForm.ToolStripMenuItem132.Text = "Indicated Faults"
            BarRestaurantForm.ToolStripMenuItem133.Text = "Company"
            BarRestaurantForm.ToolStripMenuItem134.Text = "Agencies"
            BarRestaurantForm.ToolStripMenuItem136.Text = "Users"
            BarRestaurantForm.ToolStripMenuItem137.Text = "Register"
            BarRestaurantForm.LicenceToolStripMenuItem.Text = "License"
        End If

    End Sub

    Public Sub side_menu_compabilite(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            MainWindowComptabiliteForm.ToolStripMenuItem73.Text = "Tresorerie"
            MainWindowComptabiliteForm.ToolStripMenuItem96.Text = "Third, Rooms"
            MainWindowComptabiliteForm.ToolStripMenuItem113.Text = "Fault Type"
            MainWindowComptabiliteForm.TarifsToolStripMenuItem.Text = "Prices"
            MainWindowComptabiliteForm.ToolStripMenuItem75.Text = "General Account"
            MainWindowComptabiliteForm.ToolStripMenuItem76.Text = "Cash Register"
            MainWindowComptabiliteForm.ToolStripMenuItem82.Text = "Point of Sales"
            MainWindowComptabiliteForm.CatégoriesToolStripMenuItem.Text = "Category"
            MainWindowComptabiliteForm.ToolStripMenuItem83.Text = "Artticle Family"
            MainWindowComptabiliteForm.FamilleDArToolStripMenuItem.Text = "Article Sub Family"
            MainWindowComptabiliteForm.ToolStripMenuItem93.Text = "Counting Unit"
            MainWindowComptabiliteForm.MatièresToolStripMenuItem.Text = "Material"
            MainWindowComptabiliteForm.ToolStripMenuItem91.Text = "Store"
            MainWindowComptabiliteForm.ToolStripMenuItem92.Text = "Store Affectation"
            MainWindowComptabiliteForm.ToolStripMenuItem97.Text = "Localisation"
            MainWindowComptabiliteForm.ToolStripMenuItem98.Text = "Price per Client Category"
            MainWindowComptabiliteForm.ToolStripMenuItem99.Text = "Client Category"
            MainWindowComptabiliteForm.ToolStripMenuItem100.Text = "Client"
            MainWindowComptabiliteForm.ToolStripMenuItem101.Text = "Price Client/Article"
            MainWindowComptabiliteForm.ToolStripMenuItem102.Text = "Client Messages"
            MainWindowComptabiliteForm.ToolStripMenuItem103.Text = "Type of Personnel"
            MainWindowComptabiliteForm.ToolStripMenuItem105.Text = "Suppliers"
            MainWindowComptabiliteForm.ToolStripMenuItem106.Text = "Commercials"
            MainWindowComptabiliteForm.ToolStripMenuItem107.Text = "Type of Room/Hall"
            MainWindowComptabiliteForm.ToolStripMenuItem108.Text = "Room/Hall"
            MainWindowComptabiliteForm.ToolStripMenuItem111.Text = "Reservation Source"
            MainWindowComptabiliteForm.ToolStripMenuItem112.Text = "Tourist Tax"
            MainWindowComptabiliteForm.ToolStripMenuItem128.Text = "Intervention Slip"
            MainWindowComptabiliteForm.ToolStripMenuItem123.Text = "Request for Intervention"
            MainWindowComptabiliteForm.ToolStripMenuItem124.Text = "Instruction Book"
            MainWindowComptabiliteForm.FamilleDePannesToolStripMenuItem.Text = "Fault Family"
            MainWindowComptabiliteForm.SousFamillesDePannesToolStripMenuItem.Text = "Fault Sub Family"
            MainWindowComptabiliteForm.ToolStripMenuItem131.Text = "Snitches"
            MainWindowComptabiliteForm.ToolStripMenuItem132.Text = "Indicated Faults"
            MainWindowComptabiliteForm.ToolStripMenuItem133.Text = "Company"
            MainWindowComptabiliteForm.ToolStripMenuItem134.Text = "Agencies"
            MainWindowComptabiliteForm.ToolStripMenuItem136.Text = "Users"
            MainWindowComptabiliteForm.ToolStripMenuItem137.Text = "Register"
            MainWindowComptabiliteForm.LicenceToolStripMenuItem.Text = "License"
            MainWindowComptabiliteForm.SageModelToolStripMenuItem.Text = "Accounting Write-Off"
            MainWindowComptabiliteForm.PrévisionToolStripMenuItem.Text = "Forecast"
        End If

    End Sub

    Public Sub side_menu_house_keeping(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            MainWindowServiceEtageForm.ToolStripMenuItem73.Text = "Tresorerie"
            MainWindowServiceEtageForm.ToolStripMenuItem96.Text = "Third, Rooms"
            MainWindowServiceEtageForm.ToolStripMenuItem113.Text = "Fault Type"
            MainWindowServiceEtageForm.ToolStripMenuItem75.Text = "General Account"
            MainWindowServiceEtageForm.ToolStripMenuItem76.Text = "Cash Register"
            MainWindowServiceEtageForm.ToolStripMenuItem83.Text = "Artticle Family"
            MainWindowServiceEtageForm.ToolStripMenuItem93.Text = "Counting Unit"
            MainWindowServiceEtageForm.MatièresToolStripMenuItem.Text = "Material"
            MainWindowServiceEtageForm.ToolStripMenuItem91.Text = "Store"
            MainWindowServiceEtageForm.ToolStripMenuItem92.Text = "Store Affectation"
            MainWindowServiceEtageForm.ToolStripMenuItem97.Text = "Localisation"
            MainWindowServiceEtageForm.ToolStripMenuItem98.Text = "Price per Client Category"
            MainWindowServiceEtageForm.ToolStripMenuItem99.Text = "Client Category"
            MainWindowServiceEtageForm.ToolStripMenuItem100.Text = "Client"
            MainWindowServiceEtageForm.ToolStripMenuItem101.Text = "Price Client/Article"
            MainWindowServiceEtageForm.ToolStripMenuItem102.Text = "Client Messages"
            MainWindowServiceEtageForm.ToolStripMenuItem103.Text = "Type of Personnel"
            MainWindowServiceEtageForm.ToolStripMenuItem105.Text = "Suppliers"
            MainWindowServiceEtageForm.ToolStripMenuItem106.Text = "Commercials"
            MainWindowServiceEtageForm.ToolStripMenuItem107.Text = "Type of Room/Hall"
            MainWindowServiceEtageForm.ToolStripMenuItem108.Text = "Room/Hall"
            MainWindowServiceEtageForm.ToolStripMenuItem111.Text = "Reservation Source"
            MainWindowServiceEtageForm.ToolStripMenuItem112.Text = "Tourist Tax"
            MainWindowServiceEtageForm.ToolStripMenuItem128.Text = "Intervention Slip"
            MainWindowServiceEtageForm.ToolStripMenuItem123.Text = "Request for Intervention"
            MainWindowServiceEtageForm.ToolStripMenuItem124.Text = "Instruction Book"
            MainWindowServiceEtageForm.FamilleDePannesToolStripMenuItem.Text = "Fault Family"
            MainWindowServiceEtageForm.SousFamillesDePannesToolStripMenuItem.Text = "Fault Sub Family"
            MainWindowServiceEtageForm.ToolStripMenuItem131.Text = "Snitches"
            MainWindowServiceEtageForm.ToolStripMenuItem132.Text = "Indicated Faults"
            MainWindowServiceEtageForm.ToolStripMenuItem133.Text = "Company"
            MainWindowServiceEtageForm.ToolStripMenuItem134.Text = "Agencies"
            MainWindowServiceEtageForm.ToolStripMenuItem136.Text = "Users"
            MainWindowServiceEtageForm.ToolStripMenuItem137.Text = "Register"
            MainWindowServiceEtageForm.LicenceToolStripMenuItem.Text = "License"
            MainWindowServiceEtageForm.ToolStripMenuItem81.Text = "Article/Materials"
        End If

    End Sub

    Public Sub side_menu_kitchen_form(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            MainWindowCuisineForm.ToolStripMenuItem73.Text = "Tresorerie"
            MainWindowCuisineForm.ToolStripMenuItem96.Text = "Third, Rooms"
            MainWindowCuisineForm.ToolStripMenuItem113.Text = "Fault Type"
            MainWindowCuisineForm.TarifsToolStripMenuItem.Text = "Prices"
            MainWindowCuisineForm.ToolStripMenuItem75.Text = "General Account"
            MainWindowCuisineForm.ToolStripMenuItem76.Text = "Cash Register"
            MainWindowCuisineForm.ToolStripMenuItem82.Text = "Point of Sales"
            MainWindowCuisineForm.CatégoriesToolStripMenuItem.Text = "Category"
            MainWindowCuisineForm.ToolStripMenuItem83.Text = "Artticle Family"
            MainWindowCuisineForm.FamilleDArToolStripMenuItem.Text = "Article Sub Family"
            MainWindowCuisineForm.ToolStripMenuItem93.Text = "Counting Unit"
            MainWindowCuisineForm.MatièresToolStripMenuItem.Text = "Material"
            MainWindowCuisineForm.ToolStripMenuItem91.Text = "Store"
            MainWindowCuisineForm.ToolStripMenuItem92.Text = "Store Affectation"
            MainWindowCuisineForm.ToolStripMenuItem97.Text = "Localisation"
            MainWindowCuisineForm.ToolStripMenuItem98.Text = "Price per Client Category"
            MainWindowCuisineForm.ToolStripMenuItem99.Text = "Client Category"
            MainWindowCuisineForm.ToolStripMenuItem100.Text = "Client"
            MainWindowCuisineForm.ToolStripMenuItem101.Text = "Price Client/Article"
            MainWindowCuisineForm.ToolStripMenuItem102.Text = "Client Messages"
            MainWindowCuisineForm.ToolStripMenuItem103.Text = "Type of Personnel"
            MainWindowCuisineForm.ToolStripMenuItem105.Text = "Suppliers"
            MainWindowCuisineForm.ToolStripMenuItem106.Text = "Commercials"
            MainWindowCuisineForm.ToolStripMenuItem107.Text = "Type of Room/Hall"
            MainWindowCuisineForm.ToolStripMenuItem108.Text = "Room/Hall"
            MainWindowCuisineForm.ToolStripMenuItem111.Text = "Reservation Source"
            MainWindowCuisineForm.ToolStripMenuItem112.Text = "Tourist Tax"
            MainWindowCuisineForm.ToolStripMenuItem128.Text = "Intervention Slip"
            MainWindowCuisineForm.ToolStripMenuItem123.Text = "Request for Intervention"
            MainWindowCuisineForm.ToolStripMenuItem124.Text = "Instruction Book"
            MainWindowCuisineForm.FamilleDePannesToolStripMenuItem.Text = "Fault Family"
            MainWindowCuisineForm.SousFamillesDePannesToolStripMenuItem.Text = "Fault Sub Family"
            MainWindowCuisineForm.ToolStripMenuItem131.Text = "Snitches"
            MainWindowCuisineForm.ToolStripMenuItem132.Text = "Indicated Faults"
            MainWindowCuisineForm.ToolStripMenuItem133.Text = "Company"
            MainWindowCuisineForm.ToolStripMenuItem134.Text = "Agencies"
            MainWindowCuisineForm.ToolStripMenuItem136.Text = "Users"
            MainWindowCuisineForm.ToolStripMenuItem137.Text = "Register"
            MainWindowCuisineForm.LicenceToolStripMenuItem.Text = "License"
        End If

    End Sub

    Public Sub side_menu_technique(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            MainWindowTechnique.ToolStripMenuItem73.Text = "Tresorerie"
            MainWindowTechnique.ToolStripMenuItem96.Text = "Third, Rooms"
            MainWindowTechnique.ToolStripMenuItem113.Text = "Fault Type"
            MainWindowTechnique.TarifsToolStripMenuItem.Text = "Prices"
            MainWindowTechnique.ToolStripMenuItem75.Text = "General Account"
            MainWindowTechnique.ToolStripMenuItem76.Text = "Cash Register"
            MainWindowTechnique.ToolStripMenuItem82.Text = "Point of Sales"
            MainWindowTechnique.CatégoriesToolStripMenuItem.Text = "Category"
            MainWindowTechnique.ToolStripMenuItem83.Text = "Artticle Family"
            MainWindowTechnique.FamilleDArToolStripMenuItem.Text = "Article Sub Family"
            MainWindowTechnique.ToolStripMenuItem93.Text = "Counting Unit"
            MainWindowTechnique.MatièresToolStripMenuItem.Text = "Material"
            MainWindowTechnique.ToolStripMenuItem91.Text = "Store"
            MainWindowTechnique.ToolStripMenuItem92.Text = "Store Affectation"
            MainWindowTechnique.ToolStripMenuItem97.Text = "Localisation"
            MainWindowTechnique.ToolStripMenuItem98.Text = "Price per Client Category"
            MainWindowTechnique.ToolStripMenuItem99.Text = "Client Category"
            MainWindowTechnique.ToolStripMenuItem100.Text = "Client"
            MainWindowTechnique.ToolStripMenuItem101.Text = "Price Client/Article"
            MainWindowTechnique.ToolStripMenuItem102.Text = "Client Messages"
            MainWindowTechnique.ToolStripMenuItem103.Text = "Type of Personnel"
            MainWindowTechnique.ToolStripMenuItem105.Text = "Suppliers"
            MainWindowTechnique.ToolStripMenuItem106.Text = "Commercials"
            MainWindowTechnique.ToolStripMenuItem107.Text = "Type of Room/Hall"
            MainWindowTechnique.ToolStripMenuItem108.Text = "Room/Hall"
            MainWindowTechnique.ToolStripMenuItem111.Text = "Reservation Source"
            MainWindowTechnique.ToolStripMenuItem112.Text = "Tourist Tax"
            MainWindowTechnique.ToolStripMenuItem128.Text = "Intervention Slip"
            MainWindowTechnique.ToolStripMenuItem123.Text = "Request for Intervention"
            MainWindowTechnique.ToolStripMenuItem124.Text = "Instruction Book"
            MainWindowTechnique.FamilleDePannesToolStripMenuItem.Text = "Fault Family"
            MainWindowTechnique.SousFamillesDePannesToolStripMenuItem.Text = "Fault Sub Family"
            MainWindowTechnique.ToolStripMenuItem131.Text = "Snitches"
            MainWindowTechnique.ToolStripMenuItem132.Text = "Indicated Faults"
            MainWindowTechnique.ToolStripMenuItem133.Text = "Company"
            MainWindowTechnique.ToolStripMenuItem134.Text = "Agencies"
            MainWindowTechnique.ToolStripMenuItem136.Text = "Users"
            MainWindowTechnique.ToolStripMenuItem137.Text = "Register"
            MainWindowTechnique.LicenceToolStripMenuItem.Text = "License"
        End If

    End Sub

    Public Sub side_menu_purchase(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            MainWindowEconomat.ToolStripMenuItem73.Text = "Tresorerie"
            MainWindowEconomat.ToolStripMenuItem96.Text = "Third, Rooms"
            MainWindowEconomat.ToolStripMenuItem113.Text = "Fault Type"
            MainWindowEconomat.TarifsToolStripMenuItem.Text = "Prices"
            MainWindowEconomat.ToolStripMenuItem75.Text = "General Account"
            MainWindowEconomat.ToolStripMenuItem76.Text = "Cash Register"
            MainWindowEconomat.ToolStripMenuItem82.Text = "Point of Sales"
            MainWindowEconomat.CatégoriesToolStripMenuItem.Text = "Category"
            MainWindowEconomat.ToolStripMenuItem83.Text = "Artticle Family"
            MainWindowEconomat.FamilleDArToolStripMenuItem.Text = "Article Sub Family"
            MainWindowEconomat.ToolStripMenuItem93.Text = "Counting Unit"
            MainWindowEconomat.MatièresToolStripMenuItem.Text = "Material"
            MainWindowEconomat.ToolStripMenuItem91.Text = "Store"
            MainWindowEconomat.ToolStripMenuItem92.Text = "Store Affectation"
            MainWindowEconomat.ToolStripMenuItem97.Text = "Localisation"
            MainWindowEconomat.ToolStripMenuItem98.Text = "Price per Client Category"
            MainWindowEconomat.ToolStripMenuItem99.Text = "Client Category"
            MainWindowEconomat.ToolStripMenuItem100.Text = "Client"
            MainWindowEconomat.ToolStripMenuItem101.Text = "Price Client/Article"
            MainWindowEconomat.ToolStripMenuItem102.Text = "Client Messages"
            MainWindowEconomat.ToolStripMenuItem103.Text = "Type of Personnel"
            MainWindowEconomat.ToolStripMenuItem105.Text = "Suppliers"
            MainWindowEconomat.ToolStripMenuItem106.Text = "Commercials"
            MainWindowEconomat.ToolStripMenuItem107.Text = "Type of Room/Hall"
            MainWindowEconomat.ToolStripMenuItem108.Text = "Room/Hall"
            MainWindowEconomat.ToolStripMenuItem111.Text = "Reservation Source"
            MainWindowEconomat.ToolStripMenuItem112.Text = "Tourist Tax"
            MainWindowEconomat.ToolStripMenuItem128.Text = "Intervention Slip"
            MainWindowEconomat.ToolStripMenuItem123.Text = "Request for Intervention"
            MainWindowEconomat.ToolStripMenuItem124.Text = "Instruction Book"
            MainWindowEconomat.FamilleDePannesToolStripMenuItem.Text = "Fault Family"
            MainWindowEconomat.SousFamillesDePannesToolStripMenuItem.Text = "Fault Sub Family"
            MainWindowEconomat.ToolStripMenuItem131.Text = "Snitches"
            MainWindowEconomat.ToolStripMenuItem132.Text = "Indicated Faults"
            MainWindowEconomat.ToolStripMenuItem133.Text = "Company"
            MainWindowEconomat.ToolStripMenuItem134.Text = "Agencies"
            MainWindowEconomat.ToolStripMenuItem136.Text = "Users"
            MainWindowEconomat.ToolStripMenuItem137.Text = "Register"
            MainWindowEconomat.LicenceToolStripMenuItem.Text = "License"
        End If

    End Sub

    Public Sub exchange(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            ExchangeForm.GunaLabel3.Text = "EXCHANGE"
            ExchangeForm.GunaButtonExchange.Text = "Exchange"
            ExchangeForm.Label11.Text = "Quantity"
            ExchangeForm.Label1.Text = "Unit Price"
        End If

    End Sub

    Public Sub PlanningHebdomadaireDuPersonnel(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            PlanningHebdomadaireDuPersonnelForm.GunaLabelTitle.Text = "Personnel Weekly Program"
            PlanningHebdomadaireDuPersonnelForm.GunaLabel3.Text = "WORKING PERSONNEL FROM:"
            PlanningHebdomadaireDuPersonnelForm.GunaButtonEnregistrerPlanning.Text = "Create"
            PlanningHebdomadaireDuPersonnelForm.GunaLabel5.Text = "Planning Name"
            PlanningHebdomadaireDuPersonnelForm.GunaLabel4.Text = "From:"
            PlanningHebdomadaireDuPersonnelForm.GunaLabel8.Text = "To:"
            PlanningHebdomadaireDuPersonnelForm.GunaLabel12.Text = "Arrival"
            PlanningHebdomadaireDuPersonnelForm.GunaLabel13.Text = "Depart"
            PlanningHebdomadaireDuPersonnelForm.GunaButton2.Text = "Hours"
            PlanningHebdomadaireDuPersonnelForm.GunaButton16.Text = "View"
            PlanningHebdomadaireDuPersonnelForm.SupprimerToolStripMenuItem.Text = "Delete"
            PlanningHebdomadaireDuPersonnelForm.ToolStripMenuItem1.Text = "Delete"
            PlanningHebdomadaireDuPersonnelForm.ToolStripMenuItem2.Text = "Delete"
            PlanningHebdomadaireDuPersonnelForm.ToolStripMenuItem3.Text = "Delete"
            PlanningHebdomadaireDuPersonnelForm.GunaButtonEditionDeMasse.Text = "Assign Time"
            PlanningHebdomadaireDuPersonnelForm.Label2.Text = "Planning and Time Assignation"
            PlanningHebdomadaireDuPersonnelForm.GunaLabel2.Text = "STAFF"
            PlanningHebdomadaireDuPersonnelForm.TabControl1.TabPages(0).Text = "Affecting Planning to Staff"
            PlanningHebdomadaireDuPersonnelForm.TabControl1.TabPages(1).Text = "Creation of Planning & Hours"
            PlanningHebdomadaireDuPersonnelForm.TabControl1.TabPages(2).Text = "Association of Planning and Hours"
            PlanningHebdomadaireDuPersonnelForm.GunaButton3.Text = "Global Program"

        End If

    End Sub

    Public Sub AffectationHoraireAuPlanning(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            AffectationHoraireAuPlanningForm.GunaLabelGestCompany.Text = "Assign Time"
            AffectationHoraireAuPlanningForm.GunaButtonAppliquerTarifSpecifique.Text = "Assign Time"
            AffectationHoraireAuPlanningForm.GunaLabel3.Text = "TIME"
            AffectationHoraireAuPlanningForm.GunaLabel1.Text = "From"
            AffectationHoraireAuPlanningForm.GunaLabel2.Text = "To"
            AffectationHoraireAuPlanningForm.GunaButtonTerminer.Text = "Finished"
            AffectationHoraireAuPlanningForm.SupprimerToolStripMenuItem.Text = "Delete"
            AffectationHoraireAuPlanningForm.GunaButtonEditionDeMasse.Text = "Assigned List"
            AffectationHoraireAuPlanningForm.GunaLabel4.Text = "Assigned List"
            AffectationHoraireAuPlanningForm.TabControl1.TabPages(0).Text = "Assign Time"
        End If

    End Sub

    Public Sub DatabaseBackup(ByVal ActualLanguageValue As Integer)

        If ActualLanguageValue = 0 Then
            DataBaseBackUpForm.GunaLabel1.Text = "Server"
        End If

    End Sub

End Class
