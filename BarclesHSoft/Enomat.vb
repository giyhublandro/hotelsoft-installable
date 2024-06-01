
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Economat

    '1- GESTION DES MAGASIN LIGNES 9
    '2- GESTION DES LOTS 122
    '3- GESTION DES LOTS 122

    ' --------------------------------------------- GESTION DES MAGASINS --------------------------------------------------

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'CREATION DE MAGASIN
    Public Function insert(ByVal CODE_MAGASIN As String, ByVal LIBELLE_MAGASIN As String, ByVal GESTION_PAR_LOT As String, ByVal ADRESSE As String, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal TYPE_MAGASIN As String, ByVal CODE_AGENCE As String, ByVal PRIX_UTILISE As Integer, ByVal PRIX_CONSO_UTILISE As Integer, Optional ByVal NOM_PETIT_MAGASIN As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `magasin`(`CODE_MAGASIN`, `LIBELLE_MAGASIN`, `GESTION_PAR_LOT`, `ADRESSE`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `TYPE_MAGASIN`, `CODE_AGENCE`, `PRIX_UTILISE`,`PRIX_CONSO_UTILISE` ,`NOM_PETIT_MAGASIN`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10, @PRIX_UTILISE, @PRIX_CONSO_UTILISE, @value11)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE_MAGASIN
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = GESTION_PAR_LOT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = TYPE_MAGASIN
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = NOM_PETIT_MAGASIN
        command.Parameters.Add("@PRIX_UTILISE", MySqlDbType.Int64).Value = PRIX_UTILISE
        command.Parameters.Add("@PRIX_CONSO_UTILISE", MySqlDbType.Int64).Value = PRIX_CONSO_UTILISE

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

    'MISE A JOUR DE MAGASIN
    Public Function update(ByVal CODE_MAGASIN As String, ByVal LIBELLE_MAGASIN As String, ByVal GESTION_PAR_LOT As String, ByVal ADRESSE As String, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal TYPE_MAGASIN As String, ByVal CODE_AGENCE As String, ByVal PRIX_UTILISE As Integer, ByVal PRIX_CONSO_UTILISE As Integer, Optional ByVal NOM_PETIT_MAGASIN As String = "") As Boolean

        Dim upDateQuery As String = "UPDATE `magasin` SET `CODE_MAGASIN`=@value2, `LIBELLE_MAGASIN`=@value3,`GESTION_PAR_LOT`=@value4, `ADRESSE`=@value5, `DATE_MODIFICATION`=@value8,`CODE_UTILISATEUR_MODIF`=@value9,`TYPE_MAGASIN`=@value10, `PRIX_UTILISE`=@PRIX_UTILISE, `CODE_AGENCE`=@value11, `NOM_PETIT_MAGASIN`=@value12, PRIX_CONSO_UTILISE=@PRIX_CONSO_UTILISE WHERE CODE_MAGASIN=@CODE_MAGASIN"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_MAGASIN
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = GESTION_PAR_LOT
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = TYPE_MAGASIN
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = NOM_PETIT_MAGASIN
        command.Parameters.Add("@PRIX_UTILISE", MySqlDbType.Int64).Value = PRIX_UTILISE
        command.Parameters.Add("@PRIX_CONSO_UTILISE", MySqlDbType.Int64).Value = PRIX_CONSO_UTILISE

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

    'AFFECTATION DE MAGASIN A UN UTILISATEUR

    Public Function affectationMagasin(ByVal CODE_MAGASIN As String, ByVal CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `utilisateur_magazin`(`CODE_MAGAZIN`,`CODE_UTILISATEUR`) VALUES (@value1,@value2)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

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

    'LISTE DES UTILISATEURS DE MAGASINS
    Public Function ListeDesUtilisateursDuMagasin(ByVal CODE_MAGASIN As String) As DataTable 'Liste des utilisateurs affectés a un magasin

        'WRONG NOT WORKIN ATALL

        Dim Query As String = "SELECT utilisateurs.CODE_UTILISATEUR As 'CODE UTILISATEUR',NOM_UTILISATEUR, CATEG_UTILISATEUR AS 'CATEGORIE UTILISATEUR', CODE_MAGAZIN AS 'CODE MAGASIN' From utilisateurs INNER JOIN utilisateur_magazin WHERE utilisateurs.CODE_UTILISATEUR=utilisateur_magazin.CODE_UTILISATEUR AND utilisateur_magazin.CODE_MAGAZIN=@CODE_MAGAZIN"
        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@CODE_MAGAZIN", MySqlDbType.VarChar).Value = CODE_MAGASIN

        Dim tableUtilisateurDuMagasin As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(tableUtilisateurDuMagasin)

        Return tableUtilisateurDuMagasin

        'connect.closeConnection()

    End Function

    ' --------------------------------------------- END  GESTION DES MAGASINS --------------------------------------------------

    ' --------------------------------------------- GESTION DES LOTS -----------------------------------------------------------

    'CREATION ET MISE A JOURS DES LOTS

    Public Function insertLot(ByVal CODE_LOT As String, ByVal LIBELLE_LOT As String, ByVal COMMENTAIRE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `lot`(`CODE_LOT`, `LIBELLE_LOT`, `COMMENTAIRE`) VALUES (@value2,@value3,@value4)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_LOT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = COMMENTAIRE

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
        End If

    End Function

    Public Function updateLot(ByVal CODE_LOT As String, ByVal LIBELLE_LOT As String, ByVal COMMENTAIRE As String) As Boolean

        Dim upDateQuery As String = "UPDATE `lot` SET `LIBELLE_LOT`=@value3,`COMMENTAIRE`=@value4 WHERE CODE_LOT=@CODE_LOT"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_LOT", MySqlDbType.VarChar).Value = CODE_LOT

        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_LOT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = COMMENTAIRE
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

    ' --------------------------------------------- END GESTION DES LOTS -------------------------------------------------------

    '----------------------------------------------- GESTION DES FOURNISSEURS --------------------------------------------------
    'INSERTION DE FOURNISSEUR
    Public Function insertFournisseur(ByVal NOM_FOURNISSEUR As String, ByVal CODE_FOURNISSEUR As String, ByVal POURCENTAGE_REMISE As String, ByVal ADRESSE As String, ByVal TELEPHONE As String, ByVal FAX As String, ByVal NUMERO_COMPTE As String, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `fournisseur`(`NOM_FOURNISSEUR`, `CODE_FOURNISSEUR`, `POURCENTAGE_REMISE`, `ADRESSE`, `TELEPHONE`, `FAX`, `NUMERO_COMPTE`, `CODE_AGENCE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = NOM_FOURNISSEUR
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_FOURNISSEUR
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = NUMERO_COMPTE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_AGENCE

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
        End If

    End Function

    'MISE A JOUR DE FOURNISSEUR
    Public Function updateFournisseur(ByVal NOM_FOURNISSEUR As String, ByVal CODE_FOURNISSEUR As String, ByVal POURCENTAGE_REMISE As String, ByVal ADRESSE As String, ByVal TELEPHONE As String, ByVal FAX As String, ByVal NUMERO_COMPTE As String, ByVal CODE_AGENCE As String) As Boolean

        Dim upDateQuery As String = "UPDATE `fournisseur` SET `NOM_FOURNISSEUR`=@value2,`POURCENTAGE_REMISE`=@value4,`ADRESSE`=@value5,`TELEPHONE`=@value6,`FAX`=@value7,`NUMERO_COMPTE`=@value8,`CODE_AGENCE`=@value9 WHERE CODE_FOURNISSEUR = @CODE_FOURNISSEUR"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = NOM_FOURNISSEUR
        command.Parameters.Add("@CODE_FOURNISSEUR", MySqlDbType.VarChar).Value = CODE_FOURNISSEUR
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = NUMERO_COMPTE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_AGENCE

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


    '------------------------------------------------- END GESTION DES FOURNISSEURS --------------------------------

    '-------------------------------------------- GESTION DES BORDEREAUX ------------------------------------------------

    'CREATION DES BORDEREAUX
    Public Function insertBordereau(ByVal CODE_BORDEREAUX As String, ByVal TYPE_BORDEREAUX As String, ByVal REF_BORDEREAUX As String, ByVal LIBELLE_BORDEREAUX As String, ByVal CODE_TIERS As String, ByVal NON_TIERS As String, ByVal DATE_BORDEREAU As Date, ByVal OBSERVATIONS As String, ByVal MONTANT_HT As Double, ByVal MONTANT_TAXE As Double, ByVal MONTANT_TTC As Double, ByVal MONTANT_PAYER As Double, ByVal VALIDE As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal CODE_MAGASIN As String, Optional ByVal CODE_SOUS_MAGASIN As String = "", Optional ByVal ETAT_BORDEREAU As Integer = 0) As Boolean

        Dim insertQuery As String = "INSERT INTO `bordereaux` (`CODE_BORDEREAUX`, `TYPE_BORDEREAUX`, `REF_BORDEREAUX`, `LIBELLE_BORDEREAUX`, `CODE_TIERS`, `NON_TIERS`, `DATE_BORDEREAU`, `OBSERVATIONS`, `MONTANT_HT`, `MONTANT_TAXE`, `MONTANT_TTC`, `MONTANT_PAYER`, `VALIDE`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `CODE_MAGASIN`,`CODE_SOUS_MAGASIN`,`ETAT_BORDEREAU`) VALUES (@value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11,  @value12, @value13,  @value14, @value15, @value16, @value17, @value18, @value19)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = REF_BORDEREAUX
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = LIBELLE_BORDEREAUX
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_TIERS
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NON_TIERS
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_BORDEREAU
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_PAYER
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = VALIDE
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value16", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = CODE_SOUS_MAGASIN
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = ETAT_BORDEREAU

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

    'MISE A JOUR DES BORDEREAUX
    Public Function updateBordereau(ByVal CODE_BORDEREAUX As String, ByVal TYPE_BORDEREAUX As String, ByVal REF_BORDEREAUX As String, ByVal LIBELLE_BORDEREAUX As String, ByVal CODE_TIERS As String, ByVal NON_TIERS As String, ByVal DATE_BORDEREAU As Date, ByVal OBSERVATIONS As String, ByVal MONTANT_HT As Double, ByVal MONTANT_TAXE As Double, ByVal MONTANT_TTC As Double, ByVal MONTANT_PAYER As Double, ByVal VALIDE As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal CODE_MAGASIN As String, Optional ByVal CODE_SOUS_MAGASIN As String = "") As Boolean

        Dim upDateQuery As String = "UPDATE `bordereaux` SET `TYPE_BORDEREAUX`=@value3,`REF_BORDEREAUX`=@value4,`LIBELLE_BORDEREAUX`=@value5,`CODE_TIERS`=@value6,`NON_TIERS`=@value7`OBSERVATIONS`=@value9,`MONTANT_HT`=@value10,`MONTANT_TAXE`=@value11,`MONTANT_TTC`=@value12,`MONTANT_PAYER`=@value13,`VALIDE`=@value14,`CODE_UTILISATEUR_CREA`=@value15,`CODE_AGENCE`=@value16,`CODE_MAGASIN`=@value17,`CODE_SOUS_MAGASIN`=@value18 WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_MAGASIN=@CODE_MAGASIN"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = REF_BORDEREAUX
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = LIBELLE_BORDEREAUX
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_TIERS
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NON_TIERS
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_PAYER
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = VALIDE
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value16", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = CODE_SOUS_MAGASIN

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

    ' -------------------------------- GESTION DES ARTICLES DU BORDERAUX ----------------------------------

    'CREATION DES LIGNES DU BORDEREAUX
    Public Function insertLigneBordereau(ByVal CODE_BORDEREAUX As String, ByVal CODE_LIGNE As String, ByVal CODE_MAGASIN As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal QUANTITE As Double, ByVal QUANTITE_ENTREE_STOCK As Double, ByVal DATE_PEREMPTION As Date, ByVal PRIX_UNITAIRE_HT As Double, ByVal PRIX_UNITAIRE_TTC As Double, ByVal PRIX_TOTAL_HT As Double, ByVal PRIX_TOTAL_TTC As Double, ByVal NUM_SERIE_DEBUT As String, ByVal NUM_SERIE_FIN As String, ByVal COUT_DU_STOCK As Double, Optional ByVal CODE_SOUS_MAGASIN As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `ligne_bordereaux`(`CODE_BORDEREAUX`, `CODE_LIGNE`, `CODE_MAGASIN`, `CODE_ARTICLE`, `CODE_LOT`, `QUANTITE`, `QUANTITE_ENTREE_STOCK`, `DATE_PEREMPTION`, `PRIX_UNITAIRE_HT`, `PRIX_UNITAIRE_TTC`, `PRIX_TOTAL_HT`, `PRIX_TOTAL_TTC`, `NUM_SERIE_DEBUT`, `NUM_SERIE_FIN`,`CODE_SOUS_MAGASIN`, `COUT_DU_STOCK`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16, @value17)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_LIGNE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = QUANTITE
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = QUANTITE_ENTREE_STOCK
        command.Parameters.Add("@value9", MySqlDbType.Date).Value = DATE_PEREMPTION
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = PRIX_UNITAIRE_HT
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = PRIX_UNITAIRE_TTC
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = PRIX_TOTAL_HT
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = PRIX_TOTAL_TTC
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = NUM_SERIE_DEBUT
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = NUM_SERIE_FIN
        command.Parameters.Add("@value16", MySqlDbType.VarChar).Value = CODE_SOUS_MAGASIN
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = COUT_DU_STOCK

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

    'MISE A JOUR DES LIGNE DU BORDEREAUX
    Public Function updateLigneBordereau(ByVal CODE_BORDEREAUX As String, ByVal CODE_LIGNE As String, ByVal CODE_MAGASIN As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal QUANTITE As Double, ByVal QUANTITE_ENTREE_STOCK As Double, ByVal DATE_PEREMPTION As Date, ByVal PRIX_UNITAIRE_HT As Double, ByVal PRIX_UNITAIRE_TTC As Double, ByVal PRIX_TOTAL_HT As Double, ByVal PRIX_TOTAL_TTC As Double, ByVal NUM_SERIE_DEBUT As String, ByVal NUM_SERIE_FIN As String) As Boolean

        Dim upDateQuery As String = "UPDATE `ligne_bordereaux` SET `CODE_BORDEREAUX`=@value2,`CODE_LIGNE`=@value3,`CODE_MAGASIN`=@value4,`CODE_ARTICLE`=@value5,`CODE_LOT`=@value6,`QUANTITE`=@value7,`QUANTITE_ENTREE_STOCK`=@value8,`DATE_PEREMPTION`=@value9,`PRIX_UNITAIRE_HT`=@value10,`PRIX_UNITAIRE_TTC`=@value11,`PRIX_TOTAL_HT`=@value12,`PRIX_TOTAL_TTC`=@value13,`NUM_SERIE_DEBUT`=@value14,`NUM_SERIE_FIN`=@value15 WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_MAGASIN=@CODE_MAGASIN "

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_LIGNE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = QUANTITE
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = QUANTITE_ENTREE_STOCK
        command.Parameters.Add("@value9", MySqlDbType.Date).Value = DATE_PEREMPTION
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = PRIX_UNITAIRE_HT
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = PRIX_UNITAIRE_TTC
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = PRIX_TOTAL_HT
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = PRIX_TOTAL_TTC
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = NUM_SERIE_DEBUT
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = NUM_SERIE_FIN

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


    ' GESTION DES LIGNES DU BORDEREAU

    Public Sub freeligneBordereauTempElements(ByVal CODE_AGENCE As String, ByVal CODE_USER As String)

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "DELETE FROM bordereau_ligne_temp WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_USER=@CODE_USER"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        Command.Parameters.Add("@CODE_USER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        adapter.SelectCommand = Command
        adapter.Fill(table)

    End Sub

    Public Function ligneBordereauTempElementsSuivantBordoro(ByVal CODE_AGENCE As String, ByVal CODE_BORDEREAUX As String) As DataTable

        Dim FillingListquery As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            FillingListquery = "SELECT ID_LIGNE_BORDEREAU, `CODE_ARTICLE` As 'CODE ARTICLE', `DESIGNATION`, `QUANTITE` AS 'QUANTITY', 
        `PRIX_VENTE` As 'SELLING PRICE', `PRIX_ACHAT` AS 'UNIT PRICE' , `COUT_DU_STOCK` As 'TOTAL PRICE', `EN_STOCK` As 'STOCK', UNITE_COMPTAGE As 'UNIT' 
         FROM `bordereau_ligne_temp` WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_BORDEREAU=@CODE_BORDEREAUX"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            FillingListquery = "SELECT ID_LIGNE_BORDEREAU, `CODE_ARTICLE` As 'CODE ARTICLE', `DESIGNATION`, `QUANTITE`, 
        `PRIX_VENTE` As 'PRIX VENTE', `PRIX_ACHAT` AS 'PRIX UNITAIRE' , `COUT_DU_STOCK` As 'PRIX TOTAL', `EN_STOCK` As 'EN STOCK', UNITE_COMPTAGE As 'UNITE' 
        FROM `bordereau_ligne_temp` WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_BORDEREAU=@CODE_BORDEREAUX"

        End If

        'Dim FillingListquery As String = "SELECT `CODE_ARTICLE` As 'CODE ARTICLE', `DESIGNATION`, `QUANTITE`, `EN_STOCK` As 'EN STOCK', `PRIX_VENTE` As 'PRIX VENTE', `PRIX_ACHAT` AS 'PRIX ACHAT' , `COUT_DU_STOCK` As 'COUT DU STOCK',`DATE_PEREMPTION` As 'DATE DE PEREMPTION' FROM `bordereau_ligne_temp` WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_USER=@CODE_USER"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        'commandList.Parameters.Add("@CODE_USER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        commandList.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function



    Public Function ligneBordereauTempElements(ByVal CODE_AGENCE As String, ByVal CODE_USER As String) As DataTable

        Dim FillingListquery As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            FillingListquery = "SELECT ID_LIGNE_BORDEREAU, `CODE_ARTICLE` As 'CODE ARTICLE', `DESIGNATION`, `QUANTITE` AS 'QUANTITY', 
        `PRIX_VENTE` As 'SELLING PRICE', `PRIX_ACHAT` AS 'UNIT PRICE' , `COUT_DU_STOCK` As 'TOTAL PRICE', `EN_STOCK` As 'STOCK', UNITE_COMPTAGE As 'UNIT' 
         FROM `bordereau_ligne_temp` WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_USER=@CODE_USER"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            FillingListquery = "SELECT ID_LIGNE_BORDEREAU, `CODE_ARTICLE` As 'CODE ARTICLE', `DESIGNATION`, `QUANTITE`, 
        `PRIX_VENTE` As 'PRIX VENTE', `PRIX_ACHAT` AS 'PRIX UNITAIRE' , `COUT_DU_STOCK` As 'PRIX TOTAL', `EN_STOCK` As 'EN STOCK', UNITE_COMPTAGE As 'UNITE' 
        FROM `bordereau_ligne_temp` WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_USER=@CODE_USER"

        End If

        'Dim FillingListquery As String = "SELECT `CODE_ARTICLE` As 'CODE ARTICLE', `DESIGNATION`, `QUANTITE`, `EN_STOCK` As 'EN STOCK', `PRIX_VENTE` As 'PRIX VENTE', `PRIX_ACHAT` AS 'PRIX ACHAT' , `COUT_DU_STOCK` As 'COUT DU STOCK',`DATE_PEREMPTION` As 'DATE DE PEREMPTION' FROM `bordereau_ligne_temp` WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_USER=@CODE_USER"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        commandList.Parameters.Add("@CODE_USER", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function


    'CREATION DES LIGNES DU BORDEREAUX TEMPORAIRE
    Public Function insertLigneBordereauTemp(ByVal CODE_ARTICLE As String, ByVal DESIGNATION As String, ByVal QUANTITE As Double, ByVal EN_STOCK As Double, ByVal PRIX_VENTE As Double, ByVal PRIX_ACHAT As Double, ByVal DATE_PEREMPTION As Date, ByVal CODE_AGENCE As String, ByVal CODE_BORDEREAU As String, ByVal UNITE_COMPTAGE As String, ByVal CODE_USER As String, Optional ByVal COUT_DU_STOCK As Double = 0) As Boolean

        Dim insertQuery As String = "INSERT INTO `bordereau_ligne_temp`(`CODE_ARTICLE`, `DESIGNATION`, `QUANTITE`, `EN_STOCK`, `PRIX_VENTE`, `PRIX_ACHAT`, `DATE_PEREMPTION`, `CODE_AGENCE`, `CODE_BORDEREAU`, `UNITE_COMPTAGE`, `CODE_USER`,`COUT_DU_STOCK`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@CODE_BORDEREAU,@UNITE_COMPTAGE, @value10, @value11)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        If Trim(UNITE_COMPTAGE) = "" Then
            UNITE_COMPTAGE = "PAS D'UNITE"
        End If

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = DESIGNATION
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = QUANTITE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = EN_STOCK
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = PRIX_VENTE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = PRIX_ACHAT
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = DATE_PEREMPTION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@CODE_BORDEREAU", MySqlDbType.VarChar).Value = CODE_BORDEREAU
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_USER
        command.Parameters.Add("@UNITE_COMPTAGE", MySqlDbType.VarChar).Value = UNITE_COMPTAGE
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = COUT_DU_STOCK

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

    Public Function insertLigneBordereauAnnuler(ByVal CODE_ARTICLE As String, ByVal DESIGNATION As String, ByVal QUANTITE As Double, ByVal EN_STOCK As Double, ByVal PRIX_VENTE As Double, ByVal PRIX_ACHAT As Double, ByVal DATE_PEREMPTION As Date, ByVal CODE_AGENCE As String, ByVal CODE_BORDEREAU As String, ByVal UNITE_COMPTAGE As String, ByVal CODE_USER As String, Optional ByVal COUT_DU_STOCK As Double = 0) As Boolean

        Dim insertQuery As String = "INSERT INTO `bordereau_ligne_annuler`(`CODE_ARTICLE`, `DESIGNATION`, `QUANTITE`, `EN_STOCK`, `PRIX_VENTE`, `PRIX_ACHAT`, `DATE_PEREMPTION`, `CODE_AGENCE`, `CODE_BORDEREAU`, `UNITE`, `CODE_USER`,`COUT_DU_STOCK`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9, @UNITE_COMPTAGE , @value10, @value11)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = DESIGNATION
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = QUANTITE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = EN_STOCK
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = PRIX_VENTE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = PRIX_ACHAT
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = DATE_PEREMPTION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_BORDEREAU
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_USER
        command.Parameters.Add("@UNITE_COMPTAGE", MySqlDbType.VarChar).Value = UNITE_COMPTAGE
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = COUT_DU_STOCK

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

    'MISE A JOUR DES LIGNE DU BORDEREAUX TEMPORAIRE
    Public Function updateLigneBordereauTemp(ByVal CODE_BORDEREAUX As String, ByVal CODE_ARTICLE As String, ByVal QUANTITE As Double, ByVal QUANTITE_ENTREE_STOCK As Double, ByVal DATE_PEREMPTION As Date, ByVal PRIX_TOTAL_HT As Double, ByVal PRIX_TOTAL_TTC As Double) As Boolean

        Dim upDateQuery As String = "UPDATE `ligne_bordereaux_temp` SET `CODE_ARTICLE`=@value5, `QUANTITE`=@value7, `QUANTITE_ENTREE_STOCK`=@value8, `DATE_PEREMPTION`=@value9, `PRIX_TOTAL_HT`=@value12, `PRIX_TOTAL_TTC`=@value13 WHERE CODE_ARTICLE=@CODE_ARTICLE AND CODE_BORDEREAUX=@CODE_BORDEREAUX"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = QUANTITE
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = QUANTITE_ENTREE_STOCK
        command.Parameters.Add("@value9", MySqlDbType.Date).Value = DATE_PEREMPTION

        command.Parameters.Add("@value12", MySqlDbType.Double).Value = PRIX_TOTAL_HT
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = PRIX_TOTAL_TTC

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

    '--------------------------------------- END GESTION DES BORDEREAUX -------------------------------------------

    '--------------------------------------- MOVEMENT DE STOCK ---------------------------------------------------------------

    Public Function insertLigneMovement(ByVal CODE_MOUVEMENT As String, ByVal LIBELLE_MOUVEMENT As String, ByVal TYPE_MOUVEMENT As String, ByVal ETAT_MOUVEMENT As String, ByVal DATE_MOUVEMENT As Date, ByVal CODE_MAGASIN As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal QUANTITE_ENTREE As Double, ByVal QUANTITE_SORTIE As Double, ByVal VALEUR_ENTREE As Double, ByVal VALEUR_SORTIE As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal CODE_BORDEREAU As String, ByVal QUANTITE_AVANT_MOVEMENT As Double, ByVal CMUP As Double) As Boolean

        Dim insertQuery As String = "INSERT INTO `mouvement_stock`(`CODE_MOUVEMENT`, `LIBELLE_MOUVEMENT`, `TYPE_MOUVEMENT`, `ETAT_MOUVEMENT`, `DATE_MOUVEMENT`, `CODE_MAGASIN`, `CODE_ARTICLE`, `CODE_LOT`, `QUANTITE_ENTREE`, `QUANTITE_SORTIE`, `VALEUR_ENTREE`, `VALEUR_SORTIE`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `CODE_BORDEREAU`, `QUANTITE_AVANT_MOVEMENT`,`CMUP`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15, @value16, @value17)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_MOUVEMENT
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE_MOUVEMENT
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = TYPE_MOUVEMENT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = ETAT_MOUVEMENT
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_MOUVEMENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = QUANTITE_ENTREE
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = QUANTITE_SORTIE
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = VALEUR_ENTREE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = VALEUR_SORTIE
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_BORDEREAU
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = QUANTITE_AVANT_MOVEMENT
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = CMUP

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

    'MISE A JOUR DES LIGNE DU BORDEREAUX
    Public Function updateLigneMovement(ByVal CODE_MOUVEMENT As String, ByVal LIBELLE_MOUVEMENT As String, ByVal TYPE_MOUVEMENT As String, ByVal ETAT_MOUVEMENT As String, ByVal DATE_MOUVEMENT As Date, ByVal CODE_MAGASIN As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal QUANTITE_ENTREE As Double, ByVal QUANTITE_SORTIE As Double, ByVal VALEUR_ENTREE As Double, ByVal VALEUR_SORTIE As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal CODE_BORDEREAU As String) As Boolean

        Dim upDateQuery As String = "UPDATE `mouvement_stock` SET `CODE_MOUVEMENT`=@value1,`LIBELLE_MOUVEMENT`=@value2,`TYPE_MOUVEMENT`=@value3,`ETAT_MOUVEMENT`=@value4,`DATE_MOUVEMENT`=@value5,`CODE_MAGASIN`=@value6,`CODE_ARTICLE`=@value7,`CODE_LOT`=@value8,`QUANTITE_ENTREE`=@value9,`QUANTITE_SORTIE`=@value10,`VALEUR_ENTREE`=@value11,`VALEUR_SORTIE`=@value12,`CODE_UTILISATEUR_CREA`=@value13,`CODE_AGENCE`=@value14,`CODE_BORDEREAU`=@value15  WHERE CODE_AGENCE=@AGENCE AND CODE_MAGASIN=@CODE_MAGASIN "

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_MOUVEMENT
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE_MOUVEMENT
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = TYPE_MOUVEMENT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = ETAT_MOUVEMENT
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_MOUVEMENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = QUANTITE_ENTREE
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = QUANTITE_SORTIE
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = VALEUR_ENTREE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = VALEUR_SORTIE
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_BORDEREAU

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

    'Sélection de tous les bordereaux d'un certains type

    Public Shared Function allTableFieldsOrganised(ByVal TYPE_BORDEREAUX As String, ByVal ETAT_BORDEREAU As String, ByVal DATE_DEBUT As Date, ByVal DATE_FIN As Date) As DataTable

        Dim FillingListquery As String = ""

        If TYPE_BORDEREAUX = GlobalVariable.bon_reception Then

            FillingListquery = "SELECT `CODE_BORDEREAUX` As `CODE BORDEREAUX`, `TYPE_BORDEREAUX` AS 'TYPE DE BORDEREAU', `REF_BORDEREAUX` AS REFERENCE,
            `LIBELLE_BORDEREAUX` As 'LIBELLE', `NON_TIERS` AS 'NOM TIERS', `DATE_BORDEREAU` AS 'DATE BORDEREAU', `VALIDE` AS 'ETAT', `OBSERVATIONS`, 
            `MONTANT_HT` as 'MONTANT', `CODE_UTILISATEUR_CREA` As 'MAGASINIER', `CODE_MAGASIN` AS 'MAGASIN SOURCE', `CODE_SOUS_MAGASIN` As 'MAGASIN DESTINATION' 
            FROM `bordereaux` WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND DATE_BORDEREAU >= '" & DATE_DEBUT.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DATE_FIN.ToString("yyyy-MM-dd") & "'
            ORDER BY ID_BORDEREAUX DESC"

        ElseIf TYPE_BORDEREAUX = GlobalVariable.bon_requisition Or TYPE_BORDEREAUX = GlobalVariable.bon_cmd Or TYPE_BORDEREAUX = GlobalVariable.sortie Or TYPE_BORDEREAUX = GlobalVariable.bon_approvisi Or TYPE_BORDEREAUX = GlobalVariable.list_du_marche Then

            FillingListquery = "SELECT `CODE_BORDEREAUX` As `CODE BORDEREAUX`, `TYPE_BORDEREAUX` AS 'TYPE DE BORDEREAU', `REF_BORDEREAUX` AS REFERENCE,
            `LIBELLE_BORDEREAUX` As 'LIBELLE', `NON_TIERS` AS 'NOM TIERS', `DATE_BORDEREAU` AS 'DATE BORDEREAU',`VALIDE` AS 'ETAT', `OBSERVATIONS`, 
            `MONTANT_HT` as 'MONTANT', `CODE_UTILISATEUR_CREA` As 'MAGASINIER', `CODE_MAGASIN` AS 'MAGASIN SOURCE', `CODE_SOUS_MAGASIN` As 'MAGASIN DESTINATION'
            FROM `bordereaux` WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND DATE_BORDEREAU >= '" & DATE_DEBUT.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DATE_FIN.ToString("yyyy-MM-dd") & "'
            ORDER BY ID_BORDEREAUX DESC"

        ElseIf TYPE_BORDEREAUX = GlobalVariable.transfert_inter Then

            FillingListquery = "SELECT `CODE_BORDEREAUX` As `CODE BORDEREAUX`, `TYPE_BORDEREAUX` AS 'TYPE DE BORDEREAU', `REF_BORDEREAUX` AS REFERENCE, 
            `LIBELLE_BORDEREAUX` As 'LIBELLE', `NON_TIERS` AS 'NOM TIERS', `DATE_BORDEREAU` AS 'DATE BORDEREAU',`VALIDE` AS 'ETAT', `OBSERVATIONS`,
            `MONTANT_HT` as 'MONTANT', `CODE_UTILISATEUR_CREA` As 'MAGASINIER', `CODE_MAGASIN` AS 'MAGASIN SOURCE', `CODE_SOUS_MAGASIN` As 'MAGASIN DESTINATION' 
            FROM `bordereaux` WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND DATE_BORDEREAU >= '" & DATE_DEBUT.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DATE_FIN.ToString("yyyy-MM-dd") & "' ORDER BY ID_BORDEREAUX DESC"

        ElseIf TYPE_BORDEREAUX = GlobalVariable.sortie_exceptionnelle Or TYPE_BORDEREAUX = GlobalVariable.entree_exceptionnelle Or TYPE_BORDEREAUX = GlobalVariable.inventaire Then

            FillingListquery = "SELECT `CODE_BORDEREAUX` As `CODE BORDEREAUX`, `TYPE_BORDEREAUX` AS 'TYPE DE BORDEREAU', `REF_BORDEREAUX` AS REFERENCE,
            `LIBELLE_BORDEREAUX` As 'LIBELLE', `NON_TIERS` AS 'NOM TIERS', `DATE_BORDEREAU` AS 'DATE BORDEREAU',`VALIDE` AS 'ETAT', `OBSERVATIONS`, 
            `MONTANT_HT` as 'MONTANT', `CODE_UTILISATEUR_CREA` As 'MAGASINIER', `CODE_MAGASIN` AS 'MAGASIN SOURCE', `CODE_SOUS_MAGASIN` As 'MAGASIN DESTINATION' 
            FROM `bordereaux` WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND DATE_BORDEREAU >= '" & DATE_DEBUT.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DATE_FIN.ToString("yyyy-MM-dd") & "'
            ORDER BY ID_BORDEREAUX DESC"

        End If

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        'GlobalVariable.'connect.closeConnection()

        Return tableList

    End Function

    'RAPPORT DE L'ECONOMAT
    Public Shared Function allTableFieldsOrganisedBetweenDates(ByVal TYPE_BORDEREAUX As String, ByVal ETAT_BORDEREAU As String, ByVal DATE_DEBUT As Date, ByVal DATE_FIN As Date) As DataTable

        Dim FillingListquery As String = ""

        'FillingListquery = "SELECT `CODE_BORDEREAUX` As `CODE BORDEREAUX`, `TYPE_BORDEREAUX` AS 'TYPE DE BORDEREAU', `REF_BORDEREAUX` AS REFERENCE, `LIBELLE_BORDEREAUX` As 'LIBELLE', `NON_TIERS` AS 'NOM TIERS', `DATE_BORDEREAU` AS 'DATE BORDEREAU',`VALIDE` AS 'ETAT', `OBSERVATIONS`, `MONTANT_HT` as 'MONTANT HT', `MONTANT_TAXE`, `MONTANT_TTC`, `MONTANT_PAYER`, `VALIDE` AS 'ETAT', `CODE_UTILISATEUR_CREA` As 'MAGASINIER', `CODE_MAGASIN` AS 'MAGASIN SOURCE', `CODE_SOUS_MAGASIN` As 'MAGASIN DESTINATION' FROM `bordereaux` WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND DATE_BORDEREAU >= '" & DATE_DEBUT.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DATE_FIN.ToString("yyyy-MM-dd") & "' ORDER BY LIBELLE_BORDEREAUX ASC"
        FillingListquery = "SELECT `CODE_BORDEREAUX` As `CODE BORDEREAUX`, `TYPE_BORDEREAUX` AS 'TYPE DE BORDEREAU', `REF_BORDEREAUX` AS REFERENCE, `LIBELLE_BORDEREAUX` As 'LIBELLE', `NON_TIERS` AS 'NOM TIERS', `DATE_BORDEREAU` AS 'DATE BORDEREAU', `VALIDE` AS 'ETAT', `OBSERVATIONS`, `MONTANT_HT` as 'MONTANT', `CODE_UTILISATEUR_CREA` As 'MAGASINIER', `CODE_MAGASIN` AS 'MAGASIN SOURCE', `CODE_SOUS_MAGASIN` As 'MAGASIN DESTINATION' FROM `bordereaux` WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND DATE_BORDEREAU >= '" & DATE_DEBUT.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DATE_FIN.ToString("yyyy-MM-dd") & "' ORDER BY LIBELLE_BORDEREAUX ASC"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        'GlobalVariable.'connect.closeConnection()

        Return tableList

    End Function

    '------------------------------------- END MOVEMENT DE STOCK --------------------------------------------------------------

    'Selection des articles d'un bordereau
    Public Shared Function ArticleDunBordereauQuelconque(ByVal CODE_BORDEREAUX As String, ByVal TABLE_NAME As String) As DataTable

        Dim FillingListquery As String = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            FillingListquery = "SELECT article.CODE_ARTICLE As 'CODE ARTICLE', DESIGNATION_FR AS `DESIGNATION`, `QUANTITE_ENTREE_STOCK` As 'QUANTITY',  `PRIX_UNITAIRE_TTC` As 'SELLING PRICE', `PRIX_UNITAIRE_HT` AS 'UNIT PRICE', `COUT_DU_STOCK` As 'TOTAL PRICE', article.QUANTITE AS 'STOCK', NUM_SERIE_DEBUT AS 'UNIT' FROM " & TABLE_NAME & " INNER JOIN article WHERE article.CODE_ARTICLE = " & TABLE_NAME & ".CODE_ARTICLE AND CODE_BORDEREAUX = @CODE_BORDEREAUX ORDER BY DESIGNATION_FR ASC"
        Else
            FillingListquery = "SELECT article.CODE_ARTICLE As 'CODE ARTICLE', DESIGNATION_FR AS `DESIGNATION`, `QUANTITE_ENTREE_STOCK` As 'QUANTITE',  `PRIX_UNITAIRE_TTC` As 'PRIX VENTE', `PRIX_UNITAIRE_HT` AS 'PRIX UNITAIRE', `COUT_DU_STOCK` As 'PRIX TOTAL', article.QUANTITE AS 'EN STOCK', NUM_SERIE_DEBUT AS 'UNITE' FROM " & TABLE_NAME & " INNER JOIN article WHERE article.CODE_ARTICLE = " & TABLE_NAME & ".CODE_ARTICLE AND CODE_BORDEREAUX = @CODE_BORDEREAUX ORDER BY DESIGNATION_FR ASC"
        End If

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        'GlobalVariable.'connect.closeConnection()

        Return tableList

    End Function

    'Function de stockage et de destokage

    'MISE A JOURS DES QUANTITE D'ARTICLES LORS DES ENTREES EN MAGASINS

    Public Shared Function gestionStockagesEtDeStockages(ByVal CODE_ARTICLE As String, ByVal TABLE_SOURCE As String, ByVal QUANTITE_DESTOCKER As Double, Optional ByVal CODE_DESTINATION As String = "") As Boolean

        Dim upDateQuery As String = ""
        Dim nouvelleQuantite As Double

        If TABLE_SOURCE = "article" Then

            Dim arti As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

            If arti.Rows.Count > 0 Then

                nouvelleQuantite = arti.Rows(0)("QUANTITE") + QUANTITE_DESTOCKER 'AVEC DES VIRGULES

                upDateQuery = "UPDATE `article` SET `QUANTITE`= @QUANTITE WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_ARTICLE=@CODE_ARTICLE"

                Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

                command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                command.Parameters.Add("@QUANTITE", MySqlDbType.Double).Value = nouvelleQuantite

                If (command.ExecuteNonQuery() = 1) Then
                    'connect.closeConnection()
                    Return True
                Else
                    'connect.closeConnection()
                    Return False
                End If

            End If

        End If

    End Function

    'INSCRIPTION DES PERSONNE TRAITANT LES BORDEREAUX

    Public Function inscriptionDesPerosnnesTraitantLesBordereaux(ByVal CODE_BORDEREAUX As String, ByVal GRIFFE_UTILISATEUR As String, ByVal CHAMP_A_METTRE_A_JOUR As String)

        If CHAMP_A_METTRE_A_JOUR = "SAVED" Then
            CHAMP_A_METTRE_A_JOUR = "ENREGISTRER"
        ElseIf True Then

        ElseIf True Then

        End If

        Dim upDateQuery As String = "UPDATE `bordereaux` SET " & CHAMP_A_METTRE_A_JOUR & "=@GRIFFE_UTILISATEUR WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_BORDEREAUX=@CODE_BORDEREAUX"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        command.Parameters.Add("@GRIFFE_UTILISATEUR", MySqlDbType.VarChar).Value = GRIFFE_UTILISATEUR

        'Excuting the command and testing if everything went on well
        command.ExecuteNonQuery()

    End Function


    'Mise ajours de l'état du bon de commande ayant conduit au Bon de Réception
    'Question de plus les rappeler lors des rédaction des bons de réceptions
    Public Function updateBordereauDeCommandeAyantConduitAuBordereauDeReception(ByVal CODE_BORDEREAUX As String, ByVal ETAT_BORDEREAU As String, Optional ByVal TYPE_BORDERO As String = "") As Boolean

        Dim upDateQuery As String = "UPDATE `bordereaux` SET ETAT_BORDEREAU =@ETAT_BORDEREAU, VALIDE=@VALIDE WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_BORDEREAUX=@CODE_BORDEREAUX"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        Dim VALIDE As String = ""
        Dim GRIFFE_UTILISATEUR As String = GlobalVariable.ConnectedUser.Rows(0)("GRIFFE_UTILISATEUR")
        Dim CHAMP_A_METTRE_A_JOUR As String = ""

        If ETAT_BORDEREAU = 0 Then
            VALIDE = "NON CONTROLE" ' POUR LE BC
            CHAMP_A_METTRE_A_JOUR = "ENREGISTRER"
            inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)
        ElseIf ETAT_BORDEREAU = 1 Then
            VALIDE = "CONTROLER" ' POUR LE BC
            CHAMP_A_METTRE_A_JOUR = VALIDE
            inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)

            'SI ON TRAITE UN BON D'APPROVISIONNEMENT ALORS ON DOIT :
            '1- CHARGER LE NOM DE LA PERSONNE QUI A CONTROLE
            '2- FAIRE PASSER L'ETAT DU BORDEREAU DE 1 à 3 DIRECTEMENT

            If Not Trim(TYPE_BORDERO) = "" And TYPE_BORDERO = GlobalVariable.bon_approvisi Then
                ETAT_BORDEREAU = 3
            End If

        ElseIf ETAT_BORDEREAU = 2 Then
            VALIDE = "VERIFIER" ' POUR LE BC
            CHAMP_A_METTRE_A_JOUR = VALIDE
            inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)
        ElseIf ETAT_BORDEREAU = 3 Then

            VALIDE = "VALIDER" ' POUR LE BC
            CHAMP_A_METTRE_A_JOUR = VALIDE
            inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)

        ElseIf ETAT_BORDEREAU = 4 Then
            VALIDE = "COMMANDER" 'POUR LE BC
            CHAMP_A_METTRE_A_JOUR = VALIDE
            inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)
        ElseIf ETAT_BORDEREAU = 5 Then
            VALIDE = "COMMANDER" ' POUR LE BON DE COMMANDE
            CHAMP_A_METTRE_A_JOUR = VALIDE
            inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)
        ElseIf ETAT_BORDEREAU = 6 Then
            VALIDE = "CONTROLER" ' POUR LE BORDEREAU DE RECEPTION APRES VALIDATION
            CHAMP_A_METTRE_A_JOUR = "CONTROLER"
            inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)
            VALIDE = "RECEPTIONNER"
        ElseIf ETAT_BORDEREAU = 7 Then
            VALIDE = "ANNULER"
            CHAMP_A_METTRE_A_JOUR = VALIDE
            inscriptionDesPerosnnesTraitantLesBordereaux(CODE_BORDEREAUX, GRIFFE_UTILISATEUR, CHAMP_A_METTRE_A_JOUR)
        End If

        'MISE A JOURS DE L'ETAT DU BORDEREAU DE LA NOTE ET DE LA VALEUR DE LA NOTE
        command.Parameters.Add("@ETAT_BORDEREAU", MySqlDbType.Int64).Value = ETAT_BORDEREAU

        command.Parameters.Add("@VALIDE", MySqlDbType.VarChar).Value = VALIDE

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function transformerRequisitionEnBonDeCommande(ByVal CODE_BORDEREAUX As String, ByVal TYPE_DE_BORDERO As String) As Boolean

        Dim upDateQuery As String = "UPDATE `bordereaux` SET TYPE_BORDEREAUX =@TYPE_BORDEREAUX WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_BORDEREAUX=@CODE_BORDEREAUX"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_BORDEREAUX", MySqlDbType.VarChar).Value = CODE_BORDEREAUX
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        command.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = TYPE_DE_BORDERO

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    'SELECTION DE LA QUANTITE TOTAL D'UN ARTICLE QUELCONQUE DANS UN MAGASIN QUELCONQUE
    Public Shared Function QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(ByVal CODE_MAGASIN As String, ByVal CODE_ARTICLE As String) As Double

        Dim FillingListquery As String = "SELECT * FROM mouvement_stock WHERE CODE_ARTICLE = @CODE_ARTICLE AND CODE_MAGASIN = @CODE_MAGASIN"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
        commandList.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim QuantiteArticleEnMagasin As New DataTable()

        adapterList.Fill(QuantiteArticleEnMagasin)

        Dim quantite As Double = 0

        If QuantiteArticleEnMagasin.Rows.Count > 0 Then

            For i = 0 To QuantiteArticleEnMagasin.Rows.Count - 1

                quantite += QuantiteArticleEnMagasin.Rows(i)("QUANTITE_ENTREE") - QuantiteArticleEnMagasin.Rows(i)("QUANTITE_SORTIE")

            Next

        End If

        Return quantite

    End Function

    Public Shared Function QuantiteTotalDansLaResidence(ByVal CODE_ARTICLE As String) As Double

        Dim FillingListquery As String = "SELECT * FROM mouvement_stock WHERE CODE_ARTICLE = @CODE_ARTICLE"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim QuantiteArticleEnMagasin As New DataTable()

        adapterList.Fill(QuantiteArticleEnMagasin)

        Dim quantite As Double = 0

        If QuantiteArticleEnMagasin.Rows.Count > 0 Then

            For i = 0 To QuantiteArticleEnMagasin.Rows.Count - 1
                quantite += QuantiteArticleEnMagasin.Rows(i)("QUANTITE_ENTREE") - QuantiteArticleEnMagasin.Rows(i)("QUANTITE_SORTIE")
            Next

        End If

        Return quantite

    End Function

    Public Shared Sub miseAjourQuantiteTotalRestant(ByVal CODE_ARTICLE As String)

        Dim quantite As Double = QuantiteTotalDansLaResidence(CODE_ARTICLE)

        Functions.updateOfFields("article", "QUANTITE", quantite, "CODE_ARTICLE", CODE_ARTICLE, 1)

    End Sub

    'CALCUL DU COUT MOUYEN UNITAIRE PONDERE ET MISE A JOUR DU PRIX D'ACHAT DE L'ARTICLE
    Public Shared Sub CoutMoyenUnitairePondereDunArticleQuelconque(ByVal CODE_ARTICLE As String)

        Dim FillingListquery As String = "SELECT COUT_DU_STOCK, TYPE_BORDEREAUX FROM ligne_bordereaux, bordereaux 
        WHERE CODE_ARTICLE = @CODE_ARTICLE AND ligne_bordereaux.CODE_BORDEREAUX =bordereaux.CODE_BORDEREAUX AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        commandList.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        commandList.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = GlobalVariable.bon_reception

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim QuantiteArticleEnMagasin As New DataTable()

        adapterList.Fill(QuantiteArticleEnMagasin)

        Dim valeurDuStock As Double = 0

        If QuantiteArticleEnMagasin.Rows.Count > 0 Then

            For i = 0 To QuantiteArticleEnMagasin.Rows.Count - 1
                valeurDuStock += QuantiteArticleEnMagasin.Rows(i)("COUT_DU_STOCK")
            Next

        End If

        Dim stockTotal As Double = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("QUANTITE")

        Dim CoutMoyenUnitairePondere As Double = 0

        If stockTotal > 0 And stockTotal < 0 Then
            CoutMoyenUnitairePondere = Math.Round(valeurDuStock / stockTotal, 0)
        End If

        Dim updateQuery As String = "UPDATE `article` SET `PRIX_ACHAT_HT`=@PRIX_ACHAT_HT WHERE CODE_ARTICLE=@CODE_ARTICLE_UPDATE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@PRIX_ACHAT_HT", MySqlDbType.Double).Value = CoutMoyenUnitairePondere
        command.Parameters.Add("@CODE_ARTICLE_UPDATE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        command.ExecuteNonQuery()

    End Sub

    'DEFINITION DES UNITE DE COMPTAGES
    Public Function insertUniteDeComptage(ByVal GRANDE_UNITE As String, ByVal PETITE_UNITE As String, ByVal CODE_GRANDE_UNITE As String, ByVal CODE_PETITE_UNITE As String, ByVal VALEUR_NUMERIQUE As Double, ByVal CODE_UNITE_DE_COMPTAGE As String, ByVal TYPE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `unite_comptage`(`GRANDE_UNITE`, `PETITE_UNITE`, `CODE_GRANDE_UNITE`, `CODE_PETITE_UNITE`, `VALEUR_NUMERIQUE`, `CODE_UNITE_DE_COMPTAGE`,`TYPE`) VALUES (@value2, @value3, @value4, @value5, @value6, @value7, @TYPE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = GRANDE_UNITE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = PETITE_UNITE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_GRANDE_UNITE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_PETITE_UNITE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = VALEUR_NUMERIQUE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_UNITE_DE_COMPTAGE
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = TYPE

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

    'END ECONOMAT 

    Public Function updateUniteDeComptage(ByVal GRANDE_UNITE As String, ByVal PETITE_UNITE As String, ByVal CODE_GRANDE_UNITE As String, ByVal CODE_PETITE_UNITE As String, ByVal VALEUR_NUMERIQUE As Double, ByVal CODE_UNITE_DE_COMPTAGE As String, ByVal TYPE As String) As Boolean

        Dim updateQuery As String = "UPDATE `unite_comptage` SET `GRANDE_UNITE`=@value2,`PETITE_UNITE`=@value3,`CODE_GRANDE_UNITE`=@value4,`CODE_PETITE_UNITE`=@value5,`VALEUR_NUMERIQUE`=@value6,`TYPE`=@TYPE WHERE CODE_UNITE_DE_COMPTAGE=@CODE_UNITE_DE_COMPTAGE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = GRANDE_UNITE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = PETITE_UNITE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_GRANDE_UNITE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_PETITE_UNITE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = VALEUR_NUMERIQUE
        command.Parameters.Add("@CODE_UNITE_DE_COMPTAGE", MySqlDbType.VarChar).Value = CODE_UNITE_DE_COMPTAGE
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = TYPE

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

    '-------------------------------------- RAPPORT DE L'ECONOMAT -----------------------------------------------------------

    'PRODUCTION DU RESTAURANT

    Public Function productionDuRestaurant(ByVal CODE_ARTICLE As String, ByVal DATE_DEBUT As Date, ByVal DATE_FIN As Date) As DataTable

        Dim FillingListquery As String = ""

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        commandList.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim productionDuRestaurantDataTable As New DataTable()

        adapterList.Fill(productionDuRestaurantDataTable)

        Return productionDuRestaurantDataTable

    End Function

    'MODIFICATION DIRECTEMENT SUR LE DATAGRID

    Public Function affichageDesEntreesSortiePeriodique(ByVal DateDebut As Date, DateFin As Date, ByVal entreeSortie As Integer, ByVal globalIndividuel As Integer) As DataTable

        Dim TYPE_BORDEREAUX_1 As String = ""
        Dim TYPE_BORDEREAUX_2 As String = ""

        Dim FillingListquery As String = ""

        If entreeSortie = 0 Then
            TYPE_BORDEREAUX_1 = GlobalVariable.bon_reception
            TYPE_BORDEREAUX_2 = GlobalVariable.entree_exceptionnelle
        Else
            TYPE_BORDEREAUX_1 = GlobalVariable.sortie
            TYPE_BORDEREAUX_2 = GlobalVariable.sortie_exceptionnelle
        End If

        'FillingListquery = "SELECT `CODE_BORDEREAUX` As `CODE BORDEREAUX`, `TYPE_BORDEREAUX` AS 'TYPE DE BORDEREAU', `REF_BORDEREAUX` AS REFERENCE, `LIBELLE_BORDEREAUX` As 'LIBELLE', `NON_TIERS` AS 'NOM TIERS', `DATE_BORDEREAU` AS 'DATE BORDEREAU', `VALIDE` AS 'ETAT', `OBSERVATIONS`, `MONTANT_HT` as 'MONTANT', `CODE_UTILISATEUR_CREA` As 'MAGASINIER', `CODE_MAGASIN` AS 'MAGASIN SOURCE', `CODE_SOUS_MAGASIN` As 'MAGASIN DESTINATION' FROM `bordereaux`, article, ligne_bordereaux WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX_1 AND DATE_BORDEREAU >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DateFin.ToString("yyyy-MM-dd") & "' AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE OR TYPE_BORDEREAUX=@TYPE_BORDEREAUX_2 AND DATE_BORDEREAU >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY LIBELLE_BORDEREAUX ASC"

        FillingListquery = "SELECT `DATE_BORDEREAU` AS 'DATE',  DESIGNATION_FR AS DESIGNATION, NUM_SERIE_DEBUT AS UNITE, ligne_bordereaux.QUANTITE As 'QTE AVANT MOVT', QUANTITE_ENTREE_STOCK AS 'QTE EN MOVT', PRIX_UNITAIRE_HT AS 'PRIX UNITAIRE', PRIX_TOTAL_HT AS 'TOTAL', magasin.LIBELLE_MAGASIN AS 'MAGASIN' FROM `bordereaux`, ligne_bordereaux, article, magasin WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX_1 AND DATE_BORDEREAU >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DateFin.ToString("yyyy-MM-dd") & "' AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND magasin.CODE_MAGASIN = ligne_bordereaux.CODE_MAGASIN OR TYPE_BORDEREAUX=@TYPE_BORDEREAUX_2 AND DATE_BORDEREAU >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DateFin.ToString("yyyy-MM-dd") & "' AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND magasin.CODE_MAGASIN = ligne_bordereaux.CODE_MAGASIN ORDER BY DATE_BORDEREAU DESC"

        'article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE
        ',  DESIGNATION_FR AS DESIGNATION

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
        commandList.Parameters.Add("@TYPE_BORDEREAUX_2", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_2

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        Return tableList

    End Function

    Public Function affichageDesEntreesSortiePeriodiqueSpecifique(ByVal DateDebut As Date, DateFin As Date, ByVal entreeSortie As Integer, ByVal globalIndividuel As Integer, ByVal CODE_MAGASIN As String) As DataTable

        Dim TYPE_BORDEREAUX_1 As String = ""
        Dim TYPE_BORDEREAUX_2 As String = ""
        Dim TYPE_BORDEREAUX_3 As String = ""

        Dim FillingListquery As String = ""

        If entreeSortie = 0 Then
            TYPE_BORDEREAUX_1 = GlobalVariable.bon_reception
            TYPE_BORDEREAUX_2 = GlobalVariable.entree_exceptionnelle
            TYPE_BORDEREAUX_3 = GlobalVariable.transfert_inter
        Else
            TYPE_BORDEREAUX_1 = GlobalVariable.sortie
            TYPE_BORDEREAUX_2 = GlobalVariable.sortie_exceptionnelle
        End If

        FillingListquery = "SELECT `DATE_BORDEREAU` AS 'DATE',  DESIGNATION_FR AS DESIGNATION, NUM_SERIE_DEBUT AS UNITE, ligne_bordereaux.QUANTITE As 'QTE AVANT MOVT', QUANTITE_ENTREE_STOCK AS 'QTE EN MOVT', PRIX_UNITAIRE_HT AS 'PRIX UNITAIRE', PRIX_TOTAL_HT AS 'TOTAL', magasin.LIBELLE_MAGASIN AS 'MAGASIN' 
        FROM `bordereaux`, ligne_bordereaux, article, magasin WHERE TYPE_BORDEREAUX=@TYPE_BORDEREAUX_1 AND DATE_BORDEREAU >= '" & DateDebut.ToString("yyyy-MM-dd") & "'
        AND DATE_BORDEREAU <='" & DateFin.ToString("yyyy-MM-dd") & "' AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND
        article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND magasin.CODE_MAGASIN = ligne_bordereaux.CODE_MAGASIN AND magasin.CODE_MAGASIN = @CODE_MAGASIN OR TYPE_BORDEREAUX=@TYPE_BORDEREAUX_2 AND
        DATE_BORDEREAU >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DateFin.ToString("yyyy-MM-dd") & "' AND
        bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND magasin.CODE_MAGASIN = ligne_bordereaux.CODE_MAGASIN 
        AND magasin.CODE_MAGASIN = @CODE_MAGASIN
        OR TYPE_BORDEREAUX=@TYPE_BORDEREAUX_3 AND DATE_BORDEREAU >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_BORDEREAU <='" & DateFin.ToString("yyyy-MM-dd") & "' AND
        bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX AND article.CODE_ARTICLE = ligne_bordereaux.CODE_ARTICLE AND magasin.CODE_MAGASIN = ligne_bordereaux.CODE_SOUS_MAGASIN 
        AND magasin.CODE_MAGASIN = @CODE_MAGASIN
        ORDER BY DATE_BORDEREAU DESC"

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@TYPE_BORDEREAUX_1", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_1
        commandList.Parameters.Add("@TYPE_BORDEREAUX_2", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_2
        commandList.Parameters.Add("@TYPE_BORDEREAUX_3", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX_3
        commandList.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        Return tableList

    End Function

    Public Function historiquesArticlePlusHautBasPrix(ByVal CODE_ARTICLE As String, ByVal TYPE_PRIX As Integer) As Double

        Dim FillingListquery As String = ""

        Dim TYPE_BORDEREAUX As String = GlobalVariable.bon_reception

        If TYPE_PRIX = 0 Then
            FillingListquery = "SELECT MIN(PRIX_UNITAIRE_HT) AS 'PRIX' FROM bordereaux, ligne_bordereaux WHERE CODE_ARTICLE=@CODE_ARTICLE AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX"
        ElseIf TYPE_PRIX = 1 Then
            'FillingListquery = "SELECT MAX(PRIX_UNITAIRE_HT) AS 'PRIX' FROM ligne_bordereaux WHERE CODE_ARTICLE=@CODE_ARTICLE" 'AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX
            FillingListquery = "SELECT PRIX_UNITAIRE_HT AS 'PRIX' FROM bordereaux, ligne_bordereaux WHERE CODE_ARTICLE=@CODE_ARTICLE AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX ORDER BY ID_LIGNE_BORDEREAU DESC"
        ElseIf TYPE_PRIX = 2 Then
            FillingListquery = "SELECT AVG(PRIX_UNITAIRE_HT) AS 'PRIX' FROM bordereaux, ligne_bordereaux WHERE CODE_ARTICLE=@CODE_ARTICLE AND TYPE_BORDEREAUX=@TYPE_BORDEREAUX AND bordereaux.CODE_BORDEREAUX = ligne_bordereaux.CODE_BORDEREAUX"
        End If

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        commandList.Parameters.Add("@TYPE_BORDEREAUX", MySqlDbType.VarChar).Value = TYPE_BORDEREAUX

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim table As New DataTable()

        adapterList.Fill(table)

        If table.Rows.Count > 0 Then

            If Not IsDBNull(table.Rows(0).Item(0)) Then

                If table.Rows.Count > 0 Then
                    Return table.Rows(0)("PRIX")
                Else
                    Return 0
                End If

            Else
                Return 0
            End If

        End If

    End Function

    Public Shared Function inventaireJornalierDuBarRestaurant(ByVal CODE_MAGASIN As String,
                                                              ByVal CODE_ARTICLE As String,
                                                              ByVal DATE_DE_CONTROLE_DEBUT As DateTime,
                                                              ByVal DATE_DE_CONTROLE_SHIFT_FIN As DateTime,
                                                              ByVal natureInformation As Integer,
                                                              ByVal DATE_CONTROL As Date)

        'MessageBox.Show(DATE_DE_CONTROLE_DEBUT & " - " & DATE_DE_CONTROLE_DEBUT.ToLocalTime & " / " & DATE_DE_CONTROLE_SHIFT_FIN & " - " & DATE_DE_CONTROLE_SHIFT_FIN.ToLocalTime)

        'SI natureInformation = [1,2,3,4]
        '1- STOCK INITIAL
        '2- ENTREES DE STOCK
        '3- SORTIES DE STOCK
        '4- STOCK FINAL

        Dim FillingListquery As String = ""

        Dim HEURE_DEBUT_SHIFT As DateTime = DATE_DE_CONTROLE_DEBUT.ToLongTimeString
        Dim HEURE_FIN_SHIFT As DateTime = DATE_DE_CONTROLE_SHIFT_FIN.ToLongTimeString
        Dim HEURE_MOVT As DateTime
        Dim quantite As Double = 0

        Dim dateDebut As Date = CDate(DATE_DE_CONTROLE_DEBUT.ToLongTimeString).ToShortDateString()
        Dim dateFin As Date = CDate(DATE_DE_CONTROLE_SHIFT_FIN.ToLongTimeString).ToShortDateString()
        'MessageBox.Show(HEURE_DEBUT_SHIFT & " / " & HEURE_MOVT & " / " & HEURE_FIN_SHIFT)

        'MessageBox.Show(HEURE_DEBUT_SHIFT & " - " & HEURE_FIN_SHIFT)

        'ON DOIT SE RASSURER QUE LA DATE DE MOUVEMENT EST TOUJOURS = A LA DATE DE CONTROLE
        'POUR LES CAS DE FACTURATION UNE FOIS LA JOURNEE PASSEE PAR EXAMPLE

        '1- ON SELECTIONNE TOUS LES MOUVEMENTS DES ARTICLES D'UNE DATE
        If natureInformation = 2 Or natureInformation = 3 Then
            FillingListquery = "SELECT * FROM mouvement_stock WHERE CODE_ARTICLE = @CODE_ARTICLE AND CODE_MAGASIN = @CODE_MAGASIN 
            AND DATE_MOUVEMENT >= '" & DATE_CONTROL.ToString("yyyy-MM-dd") & "' 
            AND DATE_MOUVEMENT <='" & DATE_CONTROL.ToString("yyyy-MM-dd") & "'"
        ElseIf natureInformation = 4 Then
            FillingListquery = "SELECT * FROM mouvement_stock WHERE CODE_ARTICLE = @CODE_ARTICLE AND CODE_MAGASIN = @CODE_MAGASIN 
            AND DATE_MOUVEMENT <='" & DATE_CONTROL.ToString("yyyy-MM-dd") & "'"
        End If

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
        commandList.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
        commandList.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim QuantiteArticle As New DataTable()
        adapterList.Fill(QuantiteArticle)

        Dim k = 0

        Dim days As Integer = CType((CDate(DATE_DE_CONTROLE_SHIFT_FIN) - CDate(DATE_DE_CONTROLE_DEBUT)).TotalDays, Int32)

        If QuantiteArticle.Rows.Count > 0 Then

            For i = 0 To QuantiteArticle.Rows.Count - 1
                k = 0
                HEURE_MOVT = QuantiteArticle.Rows(i)("DATE_DE_CONTROLE").ToLongTimeString

                If natureInformation = 1 Or natureInformation = 4 Then

                    quantite += QuantiteArticle.Rows(i)("QUANTITE_ENTREE") - QuantiteArticle.Rows(i)("QUANTITE_SORTIE")

                ElseIf natureInformation = 2 Then

                    If HEURE_DEBUT_SHIFT = HEURE_FIN_SHIFT Then

                        If HEURE_MOVT >= HEURE_DEBUT_SHIFT Then
                            quantite += QuantiteArticle.Rows(i)("QUANTITE_ENTREE")
                        End If

                    Else

                        If days = 0 Then

                            If HEURE_MOVT >= HEURE_DEBUT_SHIFT And HEURE_MOVT <= HEURE_FIN_SHIFT Then
                                quantite += QuantiteArticle.Rows(i)("QUANTITE_ENTREE")
                            End If

                        ElseIf days > 0 Then
                            quantite += QuantiteArticle.Rows(i)("QUANTITE_ENTREE")
                        End If

                    End If

                ElseIf natureInformation = 3 Then
                    'SORTIE
                    If HEURE_DEBUT_SHIFT = HEURE_FIN_SHIFT Then

                        If HEURE_MOVT >= HEURE_DEBUT_SHIFT Then
                            quantite += QuantiteArticle.Rows(i)("QUANTITE_SORTIE")
                        End If

                    Else

                        If days = 0 Then

                            If HEURE_MOVT >= HEURE_DEBUT_SHIFT And HEURE_MOVT <= HEURE_FIN_SHIFT Then
                                quantite += Math.Abs(QuantiteArticle.Rows(i)("QUANTITE_SORTIE"))
                            End If

                        ElseIf days > 0 Then
                            quantite += Math.Abs(QuantiteArticle.Rows(i)("QUANTITE_SORTIE"))
                        End If

                    End If

                End If

            Next

        End If

        Return Math.Abs(quantite)

    End Function

End Class
