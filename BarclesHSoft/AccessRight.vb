Imports System.IO
Imports MySql.Data.MySqlClient

Public Class AccessRight

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new society
    Public Function InsertAccessRight(ByVal CODE_PROFIL As String, ByVal NOM_PROFIL As String,
                                     ByVal DASHBOARD As Integer,
                                 ByVal PLANNING As Integer,
                                 ByVal ARRIVEES As Integer,
                                 ByVal EN_CHAMBRES As Integer,
        ByVal DEPARTS As Integer,
        ByVal ATTRIBUER_CHAMBRE As Integer,
        ByVal MESSAGES As Integer,
        ByVal FACTURATION As Integer,
        ByVal CLOTURE As Integer,
        ByVal RAPPORT_RECEPTION As Integer,
        ByVal CARDEX As Integer,
        ByVal NOUVELLE_RESERVATION As Integer,
        ByVal MODIFIER_RESERVATION As Integer,
        ByVal FICHE_DE_POLICE As Integer,
        ByVal DISPONIBILITE_ET_TARIFS As Integer,
        ByVal PLAN_DE_CHAMBRE As Integer,
        ByVal RAPPORT_RESERVATION As Integer,
        ByVal STATUTS_DES_CHAMBRES As Integer,
        ByVal HISTORIQUES_DES_CHAMBRES As Integer,
        ByVal HORS_SERVICES As Integer,
        ByVal OBJETS_TROUVES_PERDUS As Integer,
        ByVal RAPPORT_SERVICE_ETAGE As Integer,
        ByVal CLIENT_EN_CHAMBRE_FACTURATION As Integer,
        ByVal PAYMASTER_FACTURATION As Integer,
        ByVal AU_COMPTANT_FACTURATION As Integer,
        ByVal RAPPORT_BAR_RESTAURANT As Integer,
        ByVal GESTION_DES_COMPTES As Integer,
        ByVal LISTE_DES_COMPTES As Integer,
        ByVal RECHARGE As Integer,
        ByVal CAUTIONS As Integer,
        ByVal RAPPORT_COMPTABILITE As Integer,
        ByVal MOUVEMENT As Integer,
        ByVal INVENTAIRE As Integer,
        ByVal FICHE_DE_PRODUIT As Integer,
        ByVal FOURNISSEURS As Integer,
        ByVal RAPPORT_ECONOMAT As Integer,
        ByVal PETITE_CAISSE As Integer,
        ByVal GRANDE_CAISSE As Integer,
        ByVal PETIT_MAGAZIN As Integer,
        ByVal GRAND_MAGAZIN As Integer,
        ByVal SESSION_ADMIN As Integer,
        ByVal CONFIGURATION As Integer,
        ByVal SERVICE_TECHNIQUE As Integer,
        ByVal SECURITE As Integer,
        ByVal MENU_RECEPTION As Integer,
        ByVal MENU_RESERVATION As Integer,
        ByVal MENU_ADMINISTRATEUR As Integer,
        ByVal MENU_SERVICE_ETAGE As Integer,
        ByVal MENU_BAR_RESTAURANT As Integer,
        ByVal MENU_COMPTABILITE As Integer,
        ByVal MENU_ECONOMAT As Integer,
        ByVal CODE_UTILISATEUR As String,
        ByVal MENU_TECHNIQUE As Integer,
        ByVal Panne As Integer,
        ByVal SOUS_PANNE As Integer,
        ByVal DEMANDE_INTERVENTION As Integer,
        ByVal INTERVENTION As Integer,
        ByVal RAPPORT_TECHNIQUE As Integer,
        ByVal RAPPORT_PROMOTEUR As Integer,
        ByVal RECHERCHER_RESA As Integer,
        ByVal NETTOYAGE As Integer,
        ByVal DEBUT_NETTOYAGE As Integer,
        ByVal FIN_NETTOYAGE As Integer,
        ByVal CONTROLLER_NETTOYAGE As Integer,
        ByVal ETAT_CHAMBRE As Integer,
        ByVal BON_COMMANDE As Integer,
        ByVal FICHE_TECHNIQUE As Integer,
        ByVal LISTE_DES_BONS As Integer,
        ByVal BON_RECEPTION As Integer,
        ByVal VALIDER As Integer,
        ByVal CONTROLER As Integer,
        ByVal COMMANDER As Integer,
        ByVal MAGASINS As Integer,
        ByVal VERIFICATION As Integer,
        ByVal CAISSE_PRINCIPALE_LECTURE As Integer,
        ByVal CAISSE_PRINCIPALE_ECRITURE As Integer,
        ByVal FACTURES_AGEES As Integer,
        ByVal FACTURES_COMPTABILITE As Integer,
        ByVal CAISSE_PRINCIPALE As Integer,
        ByVal LETTRE_RELANCE As Integer,
        ByVal GESTION_BLOC_NOTES As Integer,
        ByVal APPROVISIONNEMENT As Integer,
        ByVal CORRECTIONS As Integer,
        ByVal FISCALITE As Integer,
        ByVal MENU_CUISINE As Integer,
        ByVal IMPRIMER_FB As Integer,
        ByVal GRATUITEE_HEBERGEMENT As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `utilisateur_acces`(`CODE_PROFIL`, `NOM_PROFIL`, `DASHBOARD`, `PLANNING`, `ARRIVEES`, `EN_CHAMBRES`, `DEPARTS`, `ATTRIBUER_CHAMBRE`, `MESSAGES`, `FACTURATION`, `CLOTURE`, `RAPPORT_RECEPTION`, `CARDEX`, `NOUVELLE_RESERVATION`, `MODIFIER_RESERVATION`, `FICHE_DE_POLICE`, `DISPONIBILITE_ET_TARIFS`, `PLAN_DE_CHAMBRE`, `RAPPORT_RESERVATION`, `STATUTS_DES_CHAMBRES`, `HISTORIQUES_DES_CHAMBRES`, `HORS_SERVICES`, `OBJETS_TROUVES_PERDUS`, `RAPPORT_SERVICE_ETAGE`, `CLIENT_EN_CHAMBRE_FACTURATION`, `PAYMASTER_FACTURATION`, `AU_COMPTANT_FACTURATION`, `RAPPORT_BAR_RESTAURANT`, `GESTION_DES_COMPTES`, `LISTE_DES_COMPTES`, `RECHARGE`, `CAUTIONS`, `RAPPORT_COMPTABILITE`, `MOUVEMENT`, `INVENTAIRE`, `FICHE_DE_PRODUIT`, `FOURNISSEURS`, `RAPPORT_ECONOMAT`, `PETITE_CAISSE`, `GRANDE_CAISSE`, `PETIT_MAGAZIN`, `GRAND_MAGAZIN`, `SESSION_ADMIN`, `CONFIGURATION`, `SERVICE_TECHNIQUE`, `SECURITE`,`MENU_RECEPTION`, `MENU_RESERVATION`, `MENU_ADMINISTRATEUR`, `MENU_SERVICE_ETAGE`, `MENU_BAR_RESTAURANT`, `MENU_COMPTABILITE`, `MENU_ECONOMAT`, `CODE_UTILISATEUR`, `MENU_TECHNIQUE`, `PANNE`, `SOUS_PANNE`, `DEMANDE_INTERVENTION`, `INTERVENTION`, `RAPPORT_TECHNIQUE`, `RAPPORT_PROMOTEUR`,`RECHERCHER_RESA`,`NETTOYAGE`,`DEBUT_NETTOYAGE`,`FIN_NETTOYAGE`,`CONTROLLER_NETTOYAGE`,`ETAT_CHAMBRE`,`BON_COMMANDE`, `FICHE_TECHNIQUE`,`LISTE_DES_BONS`,`BON_RECEPTION`, `VALIDER`,`CONTROLER`, `COMMANDER`, `MAGASINS`,`VERIFICATION`, `CAISSE_PRINCIPALE_LECTURE`, `CAISSE_PRINCIPALE_ECRITURE`,`FACTURES_AGEES`,`FACTURES_COMPTABILITE`,`CAISSE_PRINCIPALE`,`LETTRE_RELANCE`,`GESTION_BLOC_NOTES`,`APPROVISIONNEMENT`,`CORRECTIONS`, `FISCALITE`, `MENU_CUISINE`,`IMPRIMER_FB`,`GRATUITEE_HEBERGEMENT`)
        VALUES (@CODE_PROFIL, @NOM_PROFIL, @value2,@value3, @value4, @value5, @value6, @value7, @value8, @value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35,@value36,@value37,@value38,@value39,@value40,@value41,@value42,@value43,@value44,@value45,@value46,@value47,@value48,@value49,@value50,@value51,@value52,@value53,@value54,@value55,@value56,@value57,@value58,@value59,@value60,@value61,@value62,@value63,@value64,@value65,@value66,@value67,@value68,@value69,@value70,@value71,@value72,@value73,@value74, @VERIFICATION, @CAISSE_PRINCIPALE_LECTURE, @CAISSE_PRINCIPALE_ECRITURE, @FACTURES_AGEES, @FACTURES_COMPTABILITE, @CAISSE_PRINCIPALE, @LETTRE_RELANCE, @GESTION_BLOC_NOTES, @APPROVISIONNEMENT, @CORRECTIONS, @FISCALITE, @MENU_CUISINE, @IMPRIMER_FB, @GRATUITEE_HEBERGEMENT)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PROFIL", MySqlDbType.VarChar).Value = CODE_PROFIL
        command.Parameters.Add("@NOM_PROFIL", MySqlDbType.VarChar).Value = NOM_PROFIL

        command.Parameters.Add("@value2", MySqlDbType.Int16).Value = DASHBOARD
        command.Parameters.Add("@value3", MySqlDbType.Int16).Value = PLANNING
        command.Parameters.Add("@value4", MySqlDbType.Int16).Value = ARRIVEES
        command.Parameters.Add("@value5", MySqlDbType.Int16).Value = EN_CHAMBRES
        command.Parameters.Add("@value6", MySqlDbType.Int16).Value = DEPARTS
        command.Parameters.Add("@value7", MySqlDbType.Int16).Value = ATTRIBUER_CHAMBRE
        command.Parameters.Add("@value8", MySqlDbType.Int16).Value = MESSAGES
        command.Parameters.Add("@value9", MySqlDbType.Int16).Value = FACTURATION
        command.Parameters.Add("@value10", MySqlDbType.Int16).Value = CLOTURE
        command.Parameters.Add("@value11", MySqlDbType.Int16).Value = RAPPORT_RECEPTION

        command.Parameters.Add("@value12", MySqlDbType.Int16).Value = CARDEX
        command.Parameters.Add("@value13", MySqlDbType.Int16).Value = NOUVELLE_RESERVATION
        command.Parameters.Add("@value14", MySqlDbType.Int16).Value = MODIFIER_RESERVATION
        command.Parameters.Add("@value15", MySqlDbType.Int16).Value = FICHE_DE_POLICE
        command.Parameters.Add("@value16", MySqlDbType.Int16).Value = DISPONIBILITE_ET_TARIFS
        command.Parameters.Add("@value17", MySqlDbType.Int16).Value = PLAN_DE_CHAMBRE
        command.Parameters.Add("@value18", MySqlDbType.Int16).Value = RAPPORT_RESERVATION
        command.Parameters.Add("@value19", MySqlDbType.Int16).Value = STATUTS_DES_CHAMBRES
        command.Parameters.Add("@value20", MySqlDbType.Int16).Value = HISTORIQUES_DES_CHAMBRES
        command.Parameters.Add("@value21", MySqlDbType.Int16).Value = HORS_SERVICES

        command.Parameters.Add("@value22", MySqlDbType.Int16).Value = OBJETS_TROUVES_PERDUS
        command.Parameters.Add("@value23", MySqlDbType.Int16).Value = RAPPORT_SERVICE_ETAGE
        command.Parameters.Add("@value24", MySqlDbType.Int16).Value = CLIENT_EN_CHAMBRE_FACTURATION
        command.Parameters.Add("@value25", MySqlDbType.Int16).Value = PAYMASTER_FACTURATION
        command.Parameters.Add("@value26", MySqlDbType.Int16).Value = AU_COMPTANT_FACTURATION
        command.Parameters.Add("@value27", MySqlDbType.Int16).Value = RAPPORT_BAR_RESTAURANT
        command.Parameters.Add("@value28", MySqlDbType.Int16).Value = GESTION_DES_COMPTES
        command.Parameters.Add("@value29", MySqlDbType.Int16).Value = LISTE_DES_COMPTES
        command.Parameters.Add("@value30", MySqlDbType.Int16).Value = RECHARGE
        command.Parameters.Add("@value31", MySqlDbType.Int16).Value = CAUTIONS

        command.Parameters.Add("@value32", MySqlDbType.Int16).Value = RAPPORT_COMPTABILITE
        command.Parameters.Add("@value33", MySqlDbType.Int16).Value = MOUVEMENT
        command.Parameters.Add("@value34", MySqlDbType.Int16).Value = INVENTAIRE
        command.Parameters.Add("@value35", MySqlDbType.Int16).Value = FICHE_DE_PRODUIT
        command.Parameters.Add("@value36", MySqlDbType.Int16).Value = FOURNISSEURS
        command.Parameters.Add("@value37", MySqlDbType.Int16).Value = RAPPORT_ECONOMAT
        command.Parameters.Add("@value38", MySqlDbType.Int16).Value = PETITE_CAISSE
        command.Parameters.Add("@value39", MySqlDbType.Int16).Value = GRANDE_CAISSE
        command.Parameters.Add("@value40", MySqlDbType.Int16).Value = PETIT_MAGAZIN
        command.Parameters.Add("@value41", MySqlDbType.Int16).Value = GRAND_MAGAZIN
        command.Parameters.Add("@value42", MySqlDbType.Int16).Value = SESSION_ADMIN
        command.Parameters.Add("@value43", MySqlDbType.Int16).Value = CONFIGURATION
        command.Parameters.Add("@value44", MySqlDbType.Int16).Value = SERVICE_TECHNIQUE
        command.Parameters.Add("@value45", MySqlDbType.Int16).Value = SECURITE

        command.Parameters.Add("@value46", MySqlDbType.Int16).Value = MENU_RECEPTION
        command.Parameters.Add("@value47", MySqlDbType.Int16).Value = MENU_RESERVATION
        command.Parameters.Add("@value48", MySqlDbType.Int16).Value = MENU_ADMINISTRATEUR
        command.Parameters.Add("@value49", MySqlDbType.Int16).Value = MENU_SERVICE_ETAGE
        command.Parameters.Add("@value50", MySqlDbType.Int16).Value = MENU_BAR_RESTAURANT
        command.Parameters.Add("@value51", MySqlDbType.Int16).Value = MENU_COMPTABILITE
        command.Parameters.Add("@value52", MySqlDbType.Int16).Value = MENU_ECONOMAT
        command.Parameters.Add("@value53", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@value54", MySqlDbType.Int16).Value = MENU_TECHNIQUE
        command.Parameters.Add("@value55", MySqlDbType.Int16).Value = Panne
        command.Parameters.Add("@value56", MySqlDbType.Int16).Value = SOUS_PANNE
        command.Parameters.Add("@value57", MySqlDbType.Int16).Value = DEMANDE_INTERVENTION
        command.Parameters.Add("@value58", MySqlDbType.Int16).Value = INTERVENTION
        command.Parameters.Add("@value59", MySqlDbType.Int16).Value = RAPPORT_TECHNIQUE

        command.Parameters.Add("@value60", MySqlDbType.Int16).Value = RAPPORT_PROMOTEUR
        command.Parameters.Add("@value61", MySqlDbType.Int16).Value = RECHERCHER_RESA
        command.Parameters.Add("@value62", MySqlDbType.Int16).Value = NETTOYAGE
        command.Parameters.Add("@value63", MySqlDbType.Int16).Value = DEBUT_NETTOYAGE
        command.Parameters.Add("@value64", MySqlDbType.Int16).Value = FIN_NETTOYAGE
        command.Parameters.Add("@value65", MySqlDbType.Int16).Value = CONTROLLER_NETTOYAGE
        command.Parameters.Add("@value66", MySqlDbType.Int16).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value67", MySqlDbType.Int16).Value = BON_COMMANDE
        command.Parameters.Add("@value68", MySqlDbType.Int16).Value = FICHE_TECHNIQUE
        command.Parameters.Add("@value69", MySqlDbType.Int16).Value = LISTE_DES_BONS
        command.Parameters.Add("@value70", MySqlDbType.Int16).Value = BON_RECEPTION

        command.Parameters.Add("@value71", MySqlDbType.Int16).Value = VALIDER
        command.Parameters.Add("@value72", MySqlDbType.Int16).Value = CONTROLER
        command.Parameters.Add("@value73", MySqlDbType.Int16).Value = COMMANDER
        command.Parameters.Add("@value74", MySqlDbType.Int16).Value = MAGASINS
        command.Parameters.Add("@VERIFICATION", MySqlDbType.Int16).Value = VERIFICATION

        command.Parameters.Add("@CAISSE_PRINCIPALE_ECRITURE", MySqlDbType.Int16).Value = CAISSE_PRINCIPALE_ECRITURE
        command.Parameters.Add("@CAISSE_PRINCIPALE_LECTURE", MySqlDbType.Int16).Value = CAISSE_PRINCIPALE_LECTURE

        command.Parameters.Add("@FACTURES_AGEES", MySqlDbType.Int16).Value = FACTURES_AGEES
        command.Parameters.Add("@FACTURES_COMPTABILITE", MySqlDbType.Int16).Value = FACTURES_COMPTABILITE
        command.Parameters.Add("@CAISSE_PRINCIPALE", MySqlDbType.Int16).Value = CAISSE_PRINCIPALE
        command.Parameters.Add("@LETTRE_RELANCE", MySqlDbType.Int16).Value = LETTRE_RELANCE
        command.Parameters.Add("@GESTION_BLOC_NOTES", MySqlDbType.Int16).Value = GESTION_BLOC_NOTES
        command.Parameters.Add("@APPROVISIONNEMENT", MySqlDbType.Int16).Value = APPROVISIONNEMENT
        command.Parameters.Add("@CORRECTIONS", MySqlDbType.Int16).Value = CORRECTIONS

        command.Parameters.Add("@FISCALITE", MySqlDbType.Int16).Value = FISCALITE
        command.Parameters.Add("@MENU_CUISINE", MySqlDbType.Int16).Value = MENU_CUISINE

        command.Parameters.Add("@IMPRIMER_FB", MySqlDbType.Int16).Value = IMPRIMER_FB
        command.Parameters.Add("@GRATUITEE_HEBERGEMENT", MySqlDbType.Int16).Value = GRATUITEE_HEBERGEMENT

        'Opening the connection
        ''connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function UpdateAccessRight(ByVal CODE_PROFIL As String, ByVal NOM_PROFIL As String,
                                     ByVal DASHBOARD As Integer,
                                 ByVal PLANNING As Integer,
                                 ByVal ARRIVEES As Integer,
                                 ByVal EN_CHAMBRES As Integer,
        ByVal DEPARTS As Integer,
        ByVal ATTRIBUER_CHAMBRE As Integer,
        ByVal MESSAGES As Integer,
        ByVal FACTURATION As Integer,
        ByVal CLOTURE As Integer,
        ByVal RAPPORT_RECEPTION As Integer,
        ByVal CARDEX As Integer,
        ByVal NOUVELLE_RESERVATION As Integer,
        ByVal MODIFIER_RESERVATION As Integer,
        ByVal FICHE_DE_POLICE As Integer,
        ByVal DISPONIBILITE_ET_TARIFS As Integer,
        ByVal PLAN_DE_CHAMBRE As Integer,
        ByVal RAPPORT_RESERVATION As Integer,
        ByVal STATUTS_DES_CHAMBRES As Integer,
        ByVal HISTORIQUES_DES_CHAMBRES As Integer,
        ByVal HORS_SERVICES As Integer,
        ByVal OBJETS_TROUVES_PERDUS As Integer,
        ByVal RAPPORT_SERVICE_ETAGE As Integer,
        ByVal CLIENT_EN_CHAMBRE_FACTURATION As Integer,
        ByVal PAYMASTER_FACTURATION As Integer,
        ByVal AU_COMPTANT_FACTURATION As Integer,
        ByVal RAPPORT_BAR_RESTAURANT As Integer,
        ByVal GESTION_DES_COMPTES As Integer,
        ByVal LISTE_DES_COMPTES As Integer,
        ByVal RECHARGE As Integer,
        ByVal CAUTIONS As Integer,
        ByVal RAPPORT_COMPTABILITE As Integer,
        ByVal MOUVEMENT As Integer,
        ByVal INVENTAIRE As Integer,
        ByVal FICHE_DE_PRODUIT As Integer,
        ByVal FOURNISSEURS As Integer,
        ByVal RAPPORT_ECONOMAT As Integer,
        ByVal PETITE_CAISSE As Integer,
        ByVal GRANDE_CAISSE As Integer,
        ByVal PETIT_MAGAZIN As Integer,
        ByVal GRAND_MAGAZIN As Integer,
        ByVal SESSION_ADMIN As Integer,
        ByVal CONFIGURATION As Integer,
        ByVal SERVICE_TECHNIQUE As Integer,
        ByVal SECURITE As Integer,
        ByVal MENU_RECEPTION As Integer,
        ByVal MENU_RESERVATION As Integer,
        ByVal MENU_ADMINISTRATEUR As Integer,
        ByVal MENU_SERVICE_ETAGE As Integer,
        ByVal MENU_BAR_RESTAURANT As Integer,
        ByVal MENU_COMPTABILITE As Integer,
        ByVal MENU_ECONOMAT As Integer,
        ByVal CODE_UTILISATEUR As String,
        ByVal MENU_TECHNIQUE As Integer,
        ByVal Panne As Integer,
        ByVal SOUS_PANNE As Integer,
        ByVal DEMANDE_INTERVENTION As Integer,
        ByVal INTERVENTION As Integer,
        ByVal RAPPORT_TECHNIQUE As Integer,
        ByVal RAPPORT_PROMOTEUR As Integer,
        ByVal RECHERCHER_RESA As Integer,
        ByVal NETTOYAGE As Integer,
        ByVal DEBUT_NETTOYAGE As Integer,
        ByVal FIN_NETTOYAGE As Integer,
        ByVal CONTROLLER_NETTOYAGE As Integer,
        ByVal ETAT_CHAMBRE As Integer,
        ByVal BON_COMMANDE As Integer,
        ByVal FICHE_TECHNIQUE As Integer,
        ByVal LISTE_DES_BONS As Integer,
        ByVal BON_RECEPTION As Integer,
        ByVal VALIDER As Integer,
        ByVal CONTROLER As Integer,
        ByVal COMMANDER As Integer,
        ByVal MAGASINS As Integer,
        ByVal VERIFICATION As Integer,
        ByVal CAISSE_PRINCIPALE_LECTURE As Integer,
        ByVal CAISSE_PRINCIPALE_ECRITURE As Integer,
        ByVal FACTURES_AGEES As Integer,
        ByVal FACTURES_COMPTABILITE As Integer,
        ByVal CAISSE_PRINCIPALE As Integer,
        ByVal LETTRE_RELANCE As Integer,
        ByVal GESTION_BLOC_NOTES As Integer,
        ByVal APPROVISIONNEMENT As Integer,
        ByVal CORRECTIONS As Integer,
        ByVal FISCALITE As Integer,
        ByVal MENU_CUISINE As Integer,
        ByVal IMPRIMER_FB As Integer,
        ByVal GRATUITEE_HEBERGEMENT As Integer,
        ByVal OLD_CODE_PROFIL As String) As Boolean

        Dim insertQuery As String = "UPDATE `utilisateur_acces` SET `CODE_PROFIL`=@CODE_PROFIL,`NOM_PROFIL`=@NOM_PROFIL,`DASHBOARD`=@value4,`PLANNING`=@value5,`ARRIVEES`=@value6,`EN_CHAMBRES`=@value7,`DEPARTS`=@value8,`ATTRIBUER_CHAMBRE`=@value9,`MESSAGES`=@value10,`FACTURATION`=@value11,`CLOTURE`=@value12,`RAPPORT_RECEPTION`=@value13,`CARDEX`=@value14,`NOUVELLE_RESERVATION`=@value15,`MODIFIER_RESERVATION`=@value16,`FICHE_DE_POLICE`=@value17,`DISPONIBILITE_ET_TARIFS`=@value18,`PLAN_DE_CHAMBRE`=@value19,`RAPPORT_RESERVATION`=@value20,`STATUTS_DES_CHAMBRES`=@value21,`HISTORIQUES_DES_CHAMBRES`=@value22,`HORS_SERVICES`=@value23,`OBJETS_TROUVES_PERDUS`=@value24,`RAPPORT_SERVICE_ETAGE`=@value25,`CLIENT_EN_CHAMBRE_FACTURATION`=@value26,`PAYMASTER_FACTURATION`=@value27,`AU_COMPTANT_FACTURATION`=@value28,`RAPPORT_BAR_RESTAURANT`=@value29,`GESTION_DES_COMPTES`=@value30,`LISTE_DES_COMPTES`=@value31,`RECHARGE`=@value32,`CAUTIONS`=@value33,`RAPPORT_COMPTABILITE`=@value34,`MOUVEMENT`=@value35,`INVENTAIRE`=@value36,`FICHE_DE_PRODUIT`=@value37,`FOURNISSEURS`=@value38,`RAPPORT_ECONOMAT`=@value39,`PETITE_CAISSE`=@value40,`GRANDE_CAISSE`=@value41,`PETIT_MAGAZIN`=@value42,`GRAND_MAGAZIN`=@value43,`SESSION_ADMIN`=@value44,`CONFIGURATION`=@value45,`SERVICE_TECHNIQUE`=@value46,`SECURITE`=@value47,`MENU_RECEPTION`=@value48,`MENU_RESERVATION`=@value49,`MENU_ADMINISTRATEUR`=@value50,`MENU_SERVICE_ETAGE`=@value51,`MENU_BAR_RESTAURANT`=@value52,`MENU_COMPTABILITE`=@value53,`MENU_ECONOMAT`=@value54,`CODE_UTILISATEUR`=@value55,`MENU_TECHNIQUE`=@value56,`PANNE`=@value57,`SOUS_PANNE`=@value58,`DEMANDE_INTERVENTION`=@value59,`INTERVENTION`=@value60,`RAPPORT_TECHNIQUE`=@value61,`RAPPORT_PROMOTEUR`=@value62,`RECHERCHER_RESA`=@value63,`NETTOYAGE`=@value64,`DEBUT_NETTOYAGE`=@value65,`FIN_NETTOYAGE`=@value66,`CONTROLLER_NETTOYAGE`=@value67,`ETAT_CHAMBRE`=@value68,`BON_COMMANDE`=@value69,`FICHE_TECHNIQUE`=@value70,`LISTE_DES_BONS`=@value71,`BON_RECEPTION`=@value72,`VALIDER`=@value73,`CONTROLER`=@value74,`COMMANDER`=@value75,`MAGASINS`=@value76, `VERIFICATION` = @VERIFICATION, CAISSE_PRINCIPALE_LECTURE=@CAISSE_PRINCIPALE_LECTURE, CAISSE_PRINCIPALE_ECRITURE=@CAISSE_PRINCIPALE_ECRITURE,FACTURES_AGEES=@FACTURES_AGEES,FACTURES_COMPTABILITE=@FACTURES_COMPTABILITE,CAISSE_PRINCIPALE=@CAISSE_PRINCIPALE, LETTRE_RELANCE=@LETTRE_RELANCE, GESTION_BLOC_NOTES=@GESTION_BLOC_NOTES, APPROVISIONNEMENT=@APPROVISIONNEMENT, CORRECTIONS=@CORRECTIONS, 
        FISCALITE=@FISCALITE, MENU_CUISINE=@MENU_CUISINE, IMPRIMER_FB=@IMPRIMER_FB, GRATUITEE_HEBERGEMENT=@GRATUITEE_HEBERGEMENT
        WHERE CODE_PROFIL=@OLD_CODE_PROFIL"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PROFIL", MySqlDbType.VarChar).Value = CODE_PROFIL
        command.Parameters.Add("@OLD_CODE_PROFIL", MySqlDbType.VarChar).Value = OLD_CODE_PROFIL
        command.Parameters.Add("@CODE_PROFIL_UPDATE", MySqlDbType.VarChar).Value = CODE_PROFIL
        command.Parameters.Add("@NOM_PROFIL", MySqlDbType.VarChar).Value = NOM_PROFIL

        command.Parameters.Add("@value4", MySqlDbType.Int16).Value = DASHBOARD
        command.Parameters.Add("@value5", MySqlDbType.Int16).Value = PLANNING
        command.Parameters.Add("@value6", MySqlDbType.Int16).Value = ARRIVEES
        command.Parameters.Add("@value7", MySqlDbType.Int16).Value = EN_CHAMBRES
        command.Parameters.Add("@value8", MySqlDbType.Int16).Value = DEPARTS
        command.Parameters.Add("@value9", MySqlDbType.Int16).Value = ATTRIBUER_CHAMBRE
        command.Parameters.Add("@value10", MySqlDbType.Int16).Value = MESSAGES
        command.Parameters.Add("@value11", MySqlDbType.Int16).Value = FACTURATION
        command.Parameters.Add("@value12", MySqlDbType.Int16).Value = CLOTURE
        command.Parameters.Add("@value13", MySqlDbType.Int16).Value = RAPPORT_RECEPTION

        command.Parameters.Add("@value14", MySqlDbType.Int16).Value = CARDEX
        command.Parameters.Add("@value15", MySqlDbType.Int16).Value = NOUVELLE_RESERVATION
        command.Parameters.Add("@value16", MySqlDbType.Int16).Value = MODIFIER_RESERVATION
        command.Parameters.Add("@value17", MySqlDbType.Int16).Value = FICHE_DE_POLICE
        command.Parameters.Add("@value18", MySqlDbType.Int16).Value = DISPONIBILITE_ET_TARIFS
        command.Parameters.Add("@value19", MySqlDbType.Int16).Value = PLAN_DE_CHAMBRE
        command.Parameters.Add("@value20", MySqlDbType.Int16).Value = RAPPORT_RESERVATION
        command.Parameters.Add("@value21", MySqlDbType.Int16).Value = STATUTS_DES_CHAMBRES
        command.Parameters.Add("@value22", MySqlDbType.Int16).Value = HISTORIQUES_DES_CHAMBRES
        command.Parameters.Add("@value23", MySqlDbType.Int16).Value = HORS_SERVICES

        command.Parameters.Add("@value24", MySqlDbType.Int16).Value = OBJETS_TROUVES_PERDUS
        command.Parameters.Add("@value25", MySqlDbType.Int16).Value = RAPPORT_SERVICE_ETAGE
        command.Parameters.Add("@value26", MySqlDbType.Int16).Value = CLIENT_EN_CHAMBRE_FACTURATION
        command.Parameters.Add("@value27", MySqlDbType.Int16).Value = PAYMASTER_FACTURATION
        command.Parameters.Add("@value28", MySqlDbType.Int16).Value = AU_COMPTANT_FACTURATION
        command.Parameters.Add("@value29", MySqlDbType.Int16).Value = RAPPORT_BAR_RESTAURANT
        command.Parameters.Add("@value30", MySqlDbType.Int16).Value = GESTION_DES_COMPTES
        command.Parameters.Add("@value31", MySqlDbType.Int16).Value = LISTE_DES_COMPTES
        command.Parameters.Add("@value32", MySqlDbType.Int16).Value = RECHARGE
        command.Parameters.Add("@value33", MySqlDbType.Int16).Value = CAUTIONS

        command.Parameters.Add("@value34", MySqlDbType.Int16).Value = RAPPORT_COMPTABILITE
        command.Parameters.Add("@value35", MySqlDbType.Int16).Value = MOUVEMENT
        command.Parameters.Add("@value36", MySqlDbType.Int16).Value = INVENTAIRE
        command.Parameters.Add("@value37", MySqlDbType.Int16).Value = FICHE_DE_PRODUIT
        command.Parameters.Add("@value38", MySqlDbType.Int16).Value = FOURNISSEURS
        command.Parameters.Add("@value39", MySqlDbType.Int16).Value = RAPPORT_ECONOMAT
        command.Parameters.Add("@value40", MySqlDbType.Int16).Value = PETITE_CAISSE
        command.Parameters.Add("@value41", MySqlDbType.Int16).Value = GRANDE_CAISSE
        command.Parameters.Add("@value42", MySqlDbType.Int16).Value = PETIT_MAGAZIN
        command.Parameters.Add("@value43", MySqlDbType.Int16).Value = GRAND_MAGAZIN
        command.Parameters.Add("@value44", MySqlDbType.Int16).Value = SESSION_ADMIN
        command.Parameters.Add("@value45", MySqlDbType.Int16).Value = CONFIGURATION
        command.Parameters.Add("@value46", MySqlDbType.Int16).Value = SERVICE_TECHNIQUE
        command.Parameters.Add("@value47", MySqlDbType.Int16).Value = SECURITE

        command.Parameters.Add("@value48", MySqlDbType.Int16).Value = MENU_RECEPTION
        command.Parameters.Add("@value49", MySqlDbType.Int16).Value = MENU_RESERVATION
        command.Parameters.Add("@value50", MySqlDbType.Int16).Value = MENU_ADMINISTRATEUR
        command.Parameters.Add("@value51", MySqlDbType.Int16).Value = MENU_SERVICE_ETAGE
        command.Parameters.Add("@value52", MySqlDbType.Int16).Value = MENU_BAR_RESTAURANT
        command.Parameters.Add("@value53", MySqlDbType.Int16).Value = MENU_COMPTABILITE
        command.Parameters.Add("@value54", MySqlDbType.Int16).Value = MENU_ECONOMAT
        command.Parameters.Add("@value55", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@value56", MySqlDbType.Int16).Value = MENU_TECHNIQUE
        command.Parameters.Add("@value57", MySqlDbType.Int16).Value = Panne
        command.Parameters.Add("@value58", MySqlDbType.Int16).Value = SOUS_PANNE
        command.Parameters.Add("@value59", MySqlDbType.Int16).Value = DEMANDE_INTERVENTION
        command.Parameters.Add("@value60", MySqlDbType.Int16).Value = INTERVENTION
        command.Parameters.Add("@value61", MySqlDbType.Int16).Value = RAPPORT_TECHNIQUE

        command.Parameters.Add("@value62", MySqlDbType.Int16).Value = RAPPORT_PROMOTEUR
        command.Parameters.Add("@value63", MySqlDbType.Int16).Value = RECHERCHER_RESA
        command.Parameters.Add("@value64", MySqlDbType.Int16).Value = NETTOYAGE
        command.Parameters.Add("@value65", MySqlDbType.Int16).Value = DEBUT_NETTOYAGE
        command.Parameters.Add("@value66", MySqlDbType.Int16).Value = FIN_NETTOYAGE
        command.Parameters.Add("@value67", MySqlDbType.Int16).Value = CONTROLLER_NETTOYAGE
        command.Parameters.Add("@value68", MySqlDbType.Int16).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value69", MySqlDbType.Int16).Value = BON_COMMANDE
        command.Parameters.Add("@value70", MySqlDbType.Int16).Value = FICHE_TECHNIQUE
        command.Parameters.Add("@value71", MySqlDbType.Int16).Value = LISTE_DES_BONS
        command.Parameters.Add("@value72", MySqlDbType.Int16).Value = BON_RECEPTION

        command.Parameters.Add("@value73", MySqlDbType.Int16).Value = VALIDER
        command.Parameters.Add("@value74", MySqlDbType.Int16).Value = CONTROLER
        command.Parameters.Add("@value75", MySqlDbType.Int16).Value = COMMANDER
        command.Parameters.Add("@value76", MySqlDbType.Int16).Value = MAGASINS
        command.Parameters.Add("@VERIFICATION", MySqlDbType.Int16).Value = VERIFICATION

        command.Parameters.Add("@CAISSE_PRINCIPALE_ECRITURE", MySqlDbType.Int16).Value = CAISSE_PRINCIPALE_ECRITURE
        command.Parameters.Add("@CAISSE_PRINCIPALE_LECTURE", MySqlDbType.Int16).Value = CAISSE_PRINCIPALE_LECTURE

        command.Parameters.Add("@FACTURES_AGEES", MySqlDbType.Int16).Value = FACTURES_AGEES
        command.Parameters.Add("@FACTURES_COMPTABILITE", MySqlDbType.Int16).Value = FACTURES_COMPTABILITE
        command.Parameters.Add("@CAISSE_PRINCIPALE", MySqlDbType.Int16).Value = CAISSE_PRINCIPALE
        command.Parameters.Add("@LETTRE_RELANCE", MySqlDbType.Int16).Value = LETTRE_RELANCE
        command.Parameters.Add("@GESTION_BLOC_NOTES", MySqlDbType.Int16).Value = GESTION_BLOC_NOTES
        command.Parameters.Add("@APPROVISIONNEMENT", MySqlDbType.Int16).Value = APPROVISIONNEMENT
        command.Parameters.Add("@CORRECTIONS", MySqlDbType.Int16).Value = CORRECTIONS

        command.Parameters.Add("@FISCALITE", MySqlDbType.Int16).Value = FISCALITE
        command.Parameters.Add("@MENU_CUISINE", MySqlDbType.Int16).Value = MENU_CUISINE

        command.Parameters.Add("@IMPRIMER_FB", MySqlDbType.Int16).Value = IMPRIMER_FB
        command.Parameters.Add("@GRATUITEE_HEBERGEMENT", MySqlDbType.Int16).Value = GRATUITEE_HEBERGEMENT

        'Opening the connection
        ''connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    'create a function to update the selected agency
    Public Function UpdateCompany(ByVal NOM_AGENCE As String, ByVal CODE_AGENCE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal TELEPHONE As String, ByVal VILLE As String, ByVal BOITE_POSTALE As String, ByVal PAYS As String, ByVal RUE As String, ByVal CATEGORIE_HOTEL As String) As Boolean
        Dim updateQuery As String = "UPDATE `agence` SET NOM_AGENCE=@NOM_AGENCE, CODE_AGENCE=@CODE_AGENCE, FAX=@FAX, EMAIL=@EMAIL, TELEPHONE=@TELEPHONE, VILLE=@VILLE, BOITE_POSTALE=@BOITE_POSTALE, PAYS=@PAYS, RUE=@RUE, CATEGORIE_HOTEL=@CATEGORIE_HOTEL, RUE=@RUE, CATEGORIE_HOTEL=@CATEGORIE_HOTEL WHERE CODE_AGENCE = @NUM_AGENCE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@NOM_AGENCE", MySqlDbType.VarChar).Value = NOM_AGENCE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@FAX", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@TELEPHONE", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@VILLE", MySqlDbType.VarChar).Value = VILLE
        command.Parameters.Add("@BOITE_POSTALE", MySqlDbType.VarChar).Value = BOITE_POSTALE
        command.Parameters.Add("@PAYS", MySqlDbType.VarChar).Value = PAYS
        command.Parameters.Add("@RUE", MySqlDbType.VarChar).Value = RUE
        command.Parameters.Add("@CATEGORIE_HOTEL", MySqlDbType.VarChar).Value = CATEGORIE_HOTEL

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

    Public Function InsertUserAccessProfil(ByVal CODE_PROFIL As String, ByVal CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `utilisateur_acces_profil` (`CODE_PROFIL`,`CODE_UTILISATEUR`) VALUES (@CODE_PROFIL, @CODE_UTILISATEUR)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_PROFIL", MySqlDbType.VarChar).Value = CODE_PROFIL
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        'Opening the connection
        ''connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

    Public Function updateUserAccessProfil_2(ByVal CODE_PROFIL As String, ByVal OLD_CODE_PROFIL As String) As Boolean

        Dim insertQuery As String = "UPDATE `utilisateur_acces_profil` SET `CODE_PROFIL`=@CODE_PROFIL WHERE CODE_PROFIL=@OLD_CODE_PROFIL"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_PROFIL", MySqlDbType.VarChar).Value = CODE_PROFIL
        command.Parameters.Add("@OLD_CODE_PROFIL", MySqlDbType.VarChar).Value = OLD_CODE_PROFIL
        'Opening the connection
        ''connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function


    Public Function updateUserCateg(ByVal CATEG_UTILISATEUR As String, ByVal OLD_CATEG_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "UPDATE `utilisateurs` SET `CATEG_UTILISATEUR`=@CATEG_UTILISATEUR WHERE CATEG_UTILISATEUR=@OLD_CATEG_UTILISATEUR"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command.Parameters.Add("@CATEG_UTILISATEUR", MySqlDbType.VarChar).Value = CATEG_UTILISATEUR
        command.Parameters.Add("@OLD_CATEG_UTILISATEUR", MySqlDbType.VarChar).Value = OLD_CATEG_UTILISATEUR

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function


    Public Function updateUserAccessProfil(ByVal CODE_PROFIL As String, ByVal CODE_UTILISATEUR As String, ByVal OLD_CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "UPDATE `utilisateur_acces_profil` SET `CODE_PROFIL`=@CODE_PROFIL, CODE_UTILISATEUR=@CODE_UTILISATEUR WHERE CODE_UTILISATEUR=@OLD_CODE_UTILISATEUR"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_PROFIL", MySqlDbType.VarChar).Value = CODE_PROFIL
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@OLD_CODE_UTILISATEUR", MySqlDbType.VarChar).Value = OLD_CODE_UTILISATEUR
        'Opening the connection
        ''connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

    'MENU ET BOUTON ACCESSIBLE

    Public Shared Function DroitAccesUtilisateurActuel(ByVal codeProfilUtilisateurActuel As String) As DataTable

        Return Functions.GetAllElementsOnCondition(codeProfilUtilisateurActuel, "utilisateur_acces", "CODE_PROFIL")

    End Function

    Public Shared Function accesAuxModules(ByVal droitsUtilisateur As DataTable, ByVal MENU_RECEPTION As ToolStripMenuItem, ByVal MENU_RESERVATION As ToolStripMenuItem, ByVal MENU_SERVICE As ToolStripMenuItem, ByVal RESTAURANT As ToolStripMenuItem, ByVal MENU_COMPTABILITE As ToolStripMenuItem, ByVal MENU_ECONOMAT As ToolStripMenuItem, ByVal TECHNIQUE As ToolStripMenuItem, ByVal MENU_CUISINE As ToolStripMenuItem)

        If droitsUtilisateur.Rows.Count > 0 Then

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_RESERVATION") = 0 Then
                MENU_RESERVATION.Visible = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_RECEPTION") = 0 Then
                MENU_RECEPTION.Visible = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_ECONOMAT") = 0 Then
                MENU_ECONOMAT.Visible = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_SERVICE_ETAGE") = 0 Then
                MENU_SERVICE.Visible = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_BAR_RESTAURANT") = 0 Then
                RESTAURANT.Visible = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_COMPTABILITE") = 0 Then
                MENU_COMPTABILITE.Visible = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_TECHNIQUE") = 0 Then
                TECHNIQUE.Visible = False
            End If

            If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_CUISINE") = 0 Then
                MENU_CUISINE.Visible = False
            End If

        End If

    End Function

    Public Shared Function administrationDuModule(ByVal droitsUtilisateur As DataTable, ByVal SESSION_ADMIN As ToolStripMenuItem, ByVal CONFIGURATION As ToolStripMenuItem, ByVal SERVICE_TECHNIQUE As ToolStripMenuItem, ByVal SECURITE As ToolStripMenuItem, ByVal CLOTURE As ToolStripMenuItem, ByVal BELOW_CLOTURE_SEPARATOR As ToolStripSeparator, ByVal FERMETURE_CAISSE As ToolStripMenuItem, ByVal OUVRIR_CAISSE As ToolStripMenuItem, ByVal BELOW_FERMETURE_CAISSE_SEPARATOR As ToolStripSeparator)

        If droitsUtilisateur.Rows.Count > 0 Then

            If Not GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_ADMINISTRATEUR") = 0 Then

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("SESSION_ADMIN") = 0 Then
                    SESSION_ADMIN.Visible = False
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CONFIGURATION") = 0 Then
                    CONFIGURATION.Visible = False
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("SERVICE_TECHNIQUE") = 0 Then
                    SERVICE_TECHNIQUE.Visible = False
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("SECURITE") = 0 Then
                    SECURITE.Visible = False
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CLOTURE") = 0 Then
                    CLOTURE.Visible = False
                    BELOW_CLOTURE_SEPARATOR.Visible = False
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("GRANDE_CAISSE") = 0 Then
                    FERMETURE_CAISSE.Visible = False
                    BELOW_FERMETURE_CAISSE_SEPARATOR.Visible = False
                Else
                    Dim CODE_UTILISATEUR = GlobalVariable.ConnectedUser(0)("CODE_UTILISATEUR")

                    Dim CODE_CAISSE As String = ""
                    'on a verifie que l'utilisateur a droit a une caisse 
                    'On verifie que l'utilisateur est associe a une caisse
                    Dim CAISSE_UTILISATEUR As DataTable = Functions.getElementByCode(CODE_UTILISATEUR, "caisse", "CODE_UTILISATEUR")

                    If CAISSE_UTILISATEUR.Rows.Count > 0 Then

                        If CAISSE_UTILISATEUR.Rows(0)("ETAT_CAISSE") = 1 Then
                            FERMETURE_CAISSE.Visible = True
                            OUVRIR_CAISSE.Visible = False
                        Else
                            FERMETURE_CAISSE.Visible = False
                            OUVRIR_CAISSE.Visible = True
                        End If

                    Else
                        FERMETURE_CAISSE.Visible = False
                    End If

                End If

            Else

                SESSION_ADMIN.Visible = False
                CONFIGURATION.Visible = False
                SERVICE_TECHNIQUE.Visible = False
                SECURITE.Visible = False
                CLOTURE.Visible = False
                BELOW_CLOTURE_SEPARATOR.Visible = False

            End If


        End If

    End Function

    Public Shared Function administrationDuModuleCuisine(ByVal droitsUtilisateur As DataTable, ByVal SESSION_ADMIN As ToolStripMenuItem, ByVal CONFIGURATION As ToolStripMenuItem, ByVal SERVICE_TECHNIQUE As ToolStripMenuItem, ByVal SECURITE As ToolStripMenuItem)

        If droitsUtilisateur.Rows.Count > 0 Then

            If Not GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("MENU_ADMINISTRATEUR") = 0 Then

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("SESSION_ADMIN") = 0 Then
                    SESSION_ADMIN.Visible = False
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CONFIGURATION") = 0 Then
                    CONFIGURATION.Visible = False
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("SERVICE_TECHNIQUE") = 0 Then
                    SERVICE_TECHNIQUE.Visible = False
                End If

                If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("SECURITE") = 0 Then
                    SECURITE.Visible = False
                End If

            Else

                SESSION_ADMIN.Visible = False
                CONFIGURATION.Visible = False
                SERVICE_TECHNIQUE.Visible = False
                SECURITE.Visible = False

            End If


        End If

    End Function

End Class


