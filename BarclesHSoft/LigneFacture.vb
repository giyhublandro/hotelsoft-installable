Imports System.IO
Imports MySql.Data.MySqlClient

Public Class LigneFacture
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    Public Function insertLigneFactureGratuite(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String, ByVal CODE_MOUVEMENT As String, ByVal CODE_CHAMBRE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUMERO_PIECE As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal QUANTITE As Double, ByVal PRIX_UNITAIRE_TTC As Double, ByVal MONTANT_TTC As Double, ByVal DATE_FACTURE As Date, ByVal HEURE_FACTURE As DateTime, ByVal ETAT_FACTURE As Integer, ByVal DATE_OCCUPATION As Date, ByVal HEURE_OCCUPATION As DateTime, ByVal LIBELLE_FACTURE As String, ByVal TYPE_LIGNE_FACTURE As String, ByVal NUMERO_SERIE As String, ByVal NUMERO_ORDRE As Integer, ByVal DESCRIPTION As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal MONTANT_REMISE As Double, ByVal MONTANT_TAXE As Double, ByVal NUMERO_SERIE_DEBUT As String, ByVal NUMERO_SERIE_FIN As String, ByVal CODE_MAGASIN As String, ByVal FUSIONNEE As String, Optional ByVal TYPE As String = "chambre", Optional ByVal NUMERO_BLOC_NOTE As String = "chambre", Optional ByVal GRIFFE_UTILISATEUR As String = "", Optional ByVal VALEUR_CONSO As Double = 0) As Boolean

        Dim insertQuery As String = "INSERT INTO `ligne_facture_gratuite` (`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`,`GRIFFE_UTILISATEUR`,`VALEUR_CONSO`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_MOUVEMENT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUMERO_PIECE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = QUANTITE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = PRIX_UNITAIRE_TTC
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value14", MySqlDbType.Date).Value = DATE_FACTURE
        command.Parameters.Add("@value15", MySqlDbType.DateTime).Value = HEURE_FACTURE
        command.Parameters.Add("@value16", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@value17", MySqlDbType.Date).Value = DATE_OCCUPATION
        command.Parameters.Add("@value18", MySqlDbType.DateTime).Value = HEURE_OCCUPATION
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = LIBELLE_FACTURE
        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = TYPE_LIGNE_FACTURE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = NUMERO_SERIE
        command.Parameters.Add("@value22", MySqlDbType.Int64).Value = NUMERO_ORDRE
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = NUMERO_SERIE_DEBUT
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = NUMERO_SERIE_FIN
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = FUSIONNEE
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = GRIFFE_UTILISATEUR
        command.Parameters.Add("@value35", MySqlDbType.Double).Value = VALEUR_CONSO

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

    'insert a new client Catgeory
    Public Function insertLigneFacture(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String, ByVal CODE_MOUVEMENT As String, ByVal CODE_CHAMBRE As String,
                                       ByVal CODE_MODE_PAIEMENT As String, ByVal NUMERO_PIECE As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String,
                                       ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal QUANTITE As Double, ByVal PRIX_UNITAIRE_TTC As Double,
                                       ByVal MONTANT_TTC As Double, ByVal DATE_FACTURE As Date, ByVal HEURE_FACTURE As DateTime, ByVal ETAT_FACTURE As Integer,
                                       ByVal DATE_OCCUPATION As Date, ByVal HEURE_OCCUPATION As DateTime, ByVal LIBELLE_FACTURE As String,
                                       ByVal TYPE_LIGNE_FACTURE As String, ByVal NUMERO_SERIE As String, ByVal NUMERO_ORDRE As Integer, ByVal DESCRIPTION As String,
                                       ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal MONTANT_REMISE As Double, ByVal MONTANT_TAXE As Double,
                                       ByVal NUMERO_SERIE_DEBUT As String, ByVal NUMERO_SERIE_FIN As String, ByVal CODE_MAGASIN As String, ByVal FUSIONNEE As String,
                                       Optional ByVal TYPE As String = "chambre", Optional ByVal NUMERO_BLOC_NOTE As String = "chambre",
                                       Optional ByVal GRIFFE_UTILISATEUR As String = "", Optional ByVal VALEUR_CONSO As Double = 0) As Boolean

        Dim insertQuery As String = "INSERT INTO `ligne_facture` (`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`,`GRIFFE_UTILISATEUR`,`VALEUR_CONSO`) 
        VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_MOUVEMENT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUMERO_PIECE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = QUANTITE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = PRIX_UNITAIRE_TTC
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value14", MySqlDbType.Date).Value = DATE_FACTURE
        command.Parameters.Add("@value15", MySqlDbType.DateTime).Value = HEURE_FACTURE
        command.Parameters.Add("@value16", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@value17", MySqlDbType.Date).Value = DATE_OCCUPATION
        command.Parameters.Add("@value18", MySqlDbType.DateTime).Value = HEURE_OCCUPATION
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = LIBELLE_FACTURE
        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = TYPE_LIGNE_FACTURE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = NUMERO_SERIE
        command.Parameters.Add("@value22", MySqlDbType.Int64).Value = NUMERO_ORDRE
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = NUMERO_SERIE_DEBUT
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = NUMERO_SERIE_FIN
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = FUSIONNEE
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = GRIFFE_UTILISATEUR
        command.Parameters.Add("@value35", MySqlDbType.Double).Value = VALEUR_CONSO

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

    'INSERTION DES LIGNES DU PAYMASTER
    Public Function insertLigneFacturePM(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String, ByVal CODE_MOUVEMENT As String, ByVal CODE_CHAMBRE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUMERO_PIECE As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal QUANTITE As Double, ByVal PRIX_UNITAIRE_TTC As Double, ByVal MONTANT_TTC As Double, ByVal DATE_FACTURE As Date, ByVal HEURE_FACTURE As DateTime, ByVal ETAT_FACTURE As Integer, ByVal DATE_OCCUPATION As Date, ByVal HEURE_OCCUPATION As DateTime, ByVal LIBELLE_FACTURE As String, ByVal TYPE_LIGNE_FACTURE As String, ByVal NUMERO_SERIE As String, ByVal NUMERO_ORDRE As Integer, ByVal DESCRIPTION As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal MONTANT_REMISE As Double, ByVal MONTANT_TAXE As Double, ByVal NUMERO_SERIE_DEBUT As String, ByVal NUMERO_SERIE_FIN As String, ByVal CODE_MAGASIN As String, ByVal FUSIONNEE As String, Optional ByVal TYPE As String = "chambre", Optional ByVal NUMERO_BLOC_NOTE As String = "chambre", Optional ByVal GRIFFE_UTILISATEUR As String = "", Optional ByVal VALEUR_CONSO As Double = 0) As Boolean

        Dim insertQuery As String = "INSERT INTO `ligne_facture_pm` (`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`,`GRIFFE_UTILISATEUR`,`VALEUR_CONSO`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_MOUVEMENT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUMERO_PIECE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = QUANTITE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = PRIX_UNITAIRE_TTC
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value14", MySqlDbType.Date).Value = DATE_FACTURE
        command.Parameters.Add("@value15", MySqlDbType.DateTime).Value = HEURE_FACTURE
        command.Parameters.Add("@value16", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@value17", MySqlDbType.Date).Value = DATE_OCCUPATION
        command.Parameters.Add("@value18", MySqlDbType.DateTime).Value = HEURE_OCCUPATION
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = LIBELLE_FACTURE
        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = TYPE_LIGNE_FACTURE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = NUMERO_SERIE
        command.Parameters.Add("@value22", MySqlDbType.Int64).Value = NUMERO_ORDRE
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = NUMERO_SERIE_DEBUT
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = NUMERO_SERIE_FIN
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = FUSIONNEE
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = GRIFFE_UTILISATEUR
        command.Parameters.Add("@value35", MySqlDbType.Double).Value = VALEUR_CONSO

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
    'create a function to update the selected reservation
    Public Function updateLigneFacture(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String, ByVal CODE_MOUVEMENT As String, ByVal CODE_CHAMBRE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUMERO_PIECE As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal QUANTITE As Double, ByVal PRIX_UNITAIRE_TTC As Double, ByVal MONTANT_TTC As Double, ByVal DATE_FACTURE As Date, ByVal HEURE_FACTURE As DateTime, ByVal ETAT_FACTURE As Integer, ByVal DATE_OCCUPATION As Date, ByVal HEURE_OCCUPATION As DateTime, ByVal LIBELLE_FACTURE As String, ByVal TYPE_LIGNE_FACTURE As String, ByVal NUMERO_SERIE As String, ByVal NUMERO_ORDRE As Integer, ByVal DESCRIPTION As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal MONTANT_REMISE As Double, ByVal MONTANT_TAXE As Double, ByVal NUMERO_SERIE_DEBUT As String, ByVal NUMERO_SERIE_FIN As String, ByVal CODE_MAGASIN As String, ByVal FUSIONNEE As String) As Boolean

        Dim updateQuery As String = "UPDATE `ligne_facture` Set `CODE_FACTURE`=@value2,`CODE_RESERVATION`=@value3,`CODE_MOUVEMENT`=@value4,`CODE_CHAMBRE`=@value5,`CODE_MODE_PAIEMENT`=@value6,`NUMERO_PIECE`=@value7,`CODE_ARTICLE`=@value8,`CODE_LOT`=@value9,`MONTANT_HT`=@value10,`TAXE`=@value11,`QUANTITE`=@value12,`PRIX_UNITAIRE_TTC`=@value13,`MONTANT_TTC`=@value14,`DATE_FACTURE`=@value15,`HEURE_FACTURE`=@value16,`ETAT_FACTURE`=@value17,`DATE_OCCUPATION`=@value18,`HEURE_OCCUPATION`=@value19,`LIBELLE_FACTURE`=@value20,`TYPE_LIGNE_FACTURE`=@value21,`NUMERO_SERIE`=@value22,`NUMERO_ORDRE`=@value23,`DESCRIPTION`=@value24,`CODE_UTILISATEUR_CREA`=@value25,`CODE_AGENCE`=@value26,`MONTANT_REMISE`=@value27,`MONTANT_TAXE`=@value28,`NUMERO_SERIE_DEBUT`=@value29,`NUMERO_SERIE_FIN`=@value30,`CODE_MAGASIN`=@value31,`FUSIONNEE`=@value32 WHERE CODE_FACTURE=@CODE_FACTURE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_MOUVEMENT
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NUMERO_PIECE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value12", MySqlDbType.Int32).Value = QUANTITE
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = PRIX_UNITAIRE_TTC
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value15", MySqlDbType.Date).Value = DATE_FACTURE
        command.Parameters.Add("@value16", MySqlDbType.String).Value = HEURE_FACTURE
        command.Parameters.Add("@value17", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@value18", MySqlDbType.Date).Value = DATE_OCCUPATION
        command.Parameters.Add("@value19", MySqlDbType.String).Value = HEURE_OCCUPATION
        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = LIBELLE_FACTURE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = TYPE_LIGNE_FACTURE
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = NUMERO_SERIE
        command.Parameters.Add("@value23", MySqlDbType.Int64).Value = NUMERO_ORDRE
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value28", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = NUMERO_SERIE_DEBUT
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = NUMERO_SERIE_FIN
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = FUSIONNEE

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

    'create a function to update the selected reservation
    Public Function InsertLigneBlocNoteCommande(ByVal NUMERO_BLOC_NOTE As String, ByVal CODE_FACTURE As String, ByVal CODE_CLIENT As String,
                                                ByVal DATE_CREATION As Date, ByVal CODE_CAISSIER As String, ByVal NUMERO_BLOC_NOTE_VERIF As String,
                                                 ByVal Optional CODE_CLIENT_FIDEL As String = "", ByVal Optional CODE_ELITE As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `ligne_facture_bloc_note`(NUMERO_BLOC_NOTE, CODE_FACTURE, CODE_CLIENT, DATE_CREATION, CODE_CAISSIER, NUMERO_BLOC_NOTE_VERIF, CODE_CLIENT_FIDEL, CODE_ELITE) 
        VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @CODE_CLIENT_FIDEL, @CODE_ELITE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value4", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE_VERIF
        command.Parameters.Add("@CODE_CLIENT_FIDEL", MySqlDbType.VarChar).Value = CODE_CLIENT_FIDEL
        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = CODE_ELITE


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

    'insert a new client Catgeory
    Public Function insertLigneFactureTemp(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String, ByVal CODE_MOUVEMENT As String, ByVal CODE_CHAMBRE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUMERO_PIECE As String, ByVal CODE_ARTICLE As String, ByVal CODE_LOT As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal QUANTITE As Double, ByVal PRIX_UNITAIRE_TTC As Double, ByVal MONTANT_TTC As Double, ByVal DATE_FACTURE As Date, ByVal HEURE_FACTURE As DateTime, ByVal ETAT_FACTURE As Integer, ByVal DATE_OCCUPATION As Date, ByVal HEURE_OCCUPATION As DateTime, ByVal LIBELLE_FACTURE As String, ByVal TYPE_LIGNE_FACTURE As String, ByVal NUMERO_SERIE As String, ByVal NUMERO_ORDRE As Integer, ByVal DESCRIPTION As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_AGENCE As String, ByVal MONTANT_REMISE As Double, ByVal MONTANT_TAXE As Double, ByVal NUMERO_SERIE_DEBUT As String, ByVal NUMERO_SERIE_FIN As String, ByVal CODE_MAGASIN As String, ByVal FUSIONNEE As String, Optional ByVal TYPE As String = "chambre", Optional ByVal TABLE_LIGNE As String = "ligne_facture", Optional ByVal NUMERO_BLOC_NOTE As String = "", Optional ByVal GRIFFE_UTILISATEUR As String = "", Optional ByVal VALEUR_CONSO As Double = 0) As Boolean

        Dim insertQuery As String = "INSERT INTO `" & TABLE_LIGNE & "`(`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE`,`GRIFFE_UTILISATEUR`, `VALEUR_CONSO`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_MOUVEMENT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = NUMERO_PIECE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_LOT
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = QUANTITE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = PRIX_UNITAIRE_TTC
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value14", MySqlDbType.Date).Value = DATE_FACTURE
        command.Parameters.Add("@value15", MySqlDbType.DateTime).Value = HEURE_FACTURE
        command.Parameters.Add("@value16", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@value17", MySqlDbType.Date).Value = DATE_OCCUPATION
        command.Parameters.Add("@value18", MySqlDbType.DateTime).Value = HEURE_OCCUPATION
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = LIBELLE_FACTURE
        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = TYPE_LIGNE_FACTURE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = NUMERO_SERIE
        command.Parameters.Add("@value22", MySqlDbType.Int64).Value = NUMERO_ORDRE
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = NUMERO_SERIE_DEBUT
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = NUMERO_SERIE_FIN
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = FUSIONNEE
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = GRIFFE_UTILISATEUR

        command.Parameters.Add("@value35", MySqlDbType.Double).Value = VALEUR_CONSO

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

    Public Function conversionUniteDeVenteAUniteDeDestockage(ByVal unite As DataTable, ByVal QUANTITE_A_CONVERTIR As Double) As Double
        'CONVERSION DE LA PETITE UNITE A L'AGRANDE UNITE
        Dim QUANTITE_CONVERTIE As Double = 0

        If unite.Rows.Count > 0 Then
            If unite.Rows(0)("VALEUR_NUMERIQUE") > 0 Then
                QUANTITE_CONVERTIE = QUANTITE_A_CONVERTIR / unite.Rows(0)("VALEUR_NUMERIQUE")
            End If
        End If

        Return QUANTITE_CONVERTIE

    End Function

    Public Function MigrationDeLigneFatureTempVersLigneFactureComptoire(ByVal CODE_BLOC_NOTE_TEMP As String)

        Dim ligneFactureTempContent As DataTable

        Dim mainCourantes As New MainCourantes()

        ligneFactureTempContent = Functions.getElementByCode(CODE_BLOC_NOTE_TEMP, "ligne_facture_temp", "NUMERO_BLOC_NOTE")

        Dim CODE_ARTICLE As String = ""
        Dim NATURE As String = ""

        'A INSERER DANS commande_cuisine si l'article est associé a une fiche technique

        Dim PRIX_VENTE As Double = 0

        If ligneFactureTempContent.Rows.Count > 0 Then

            For i = 0 To ligneFactureTempContent.Rows.Count - 1

                Dim CODE_FACTURE As String = ligneFactureTempContent.Rows(i)("CODE_FACTURE")
                Dim CODE_RESERVATION As String = ligneFactureTempContent.Rows(i)("CODE_RESERVATION")
                Dim CODE_MOUVEMENT As String = ligneFactureTempContent.Rows(i)("CODE_MOUVEMENT")
                Dim CODE_CHAMBRE As String = ligneFactureTempContent.Rows(i)("CODE_CHAMBRE")
                Dim CODE_MODE_PAIEMENT As String = ligneFactureTempContent.Rows(i)("CODE_MODE_PAIEMENT")
                Dim NUMERO_PIECE As String = ligneFactureTempContent.Rows(i)("NUMERO_PIECE")

                Dim POINT_DE_VENTE As String = ligneFactureTempContent.Rows(i)("TYPE_LIGNE_FACTURE")

                CODE_ARTICLE = ligneFactureTempContent.Rows(i)("CODE_ARTICLE")

                Dim LIBELLE_FACTURE As String = ligneFactureTempContent.Rows(i)("LIBELLE_FACTURE")

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                Dim CONTENANCE As Double = 0

                Dim ficheTechnique As DataTable

                Dim NOM_ARTICLE As String = ""

                Dim NOMBRE_DE_PORTION As Double = 0

                Dim articleInfo As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                Dim reduction As Boolean = False

                If Not articleInfo.Rows.Count > 0 Then

                    CODE_ARTICLE = ligneFactureTempContent.Rows(i)("NUMERO_SERIE_DEBUT")
                    articleInfo = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                    reduction = True

                End If

                Dim unite As DataTable

                Dim OLD_FUSIONNEE As String = ligneFactureTempContent.Rows(i)("FUSIONNEE")

                Dim FUSIONNEE As String = ligneFactureTempContent.Rows(i)("FUSIONNEE")
                Dim PRIX_UNITAIRE_TTC As Double = ligneFactureTempContent.Rows(i)("PRIX_UNITAIRE_TTC")
                PRIX_VENTE = ligneFactureTempContent.Rows(i)("PRIX_UNITAIRE_TTC")
                Dim MONTANT_TTC As Double = ligneFactureTempContent.Rows(i)("MONTANT_TTC")
                Dim HEURE_FACTURE As DateTime = ligneFactureTempContent.Rows(i)("HEURE_FACTURE")

                Dim FAMILLE_ARTICLE As String = ""

                If articleInfo.Rows.Count > 0 Then

                    '----------------------- END GESTION DU REMPLISSAGE DE LA MAIN COURANTE JOURNALIERE -------------------------------

                    Dim TABLE As String = "main_courante_autres"

                    Dim ETAT_MAIN_COURANTE As Integer = 0

                    Dim main_courante_autres As DataTable = Functions.getElementByOnCodeAndDate(ETAT_MAIN_COURANTE, "main_courante_autres", "ETAT_MAIN_COURANTE", GlobalVariable.DateDeTravail, "main_courante_autres")

                    Dim CODE_MAIN_COURANTE_AUTRES As String = ""

                    If main_courante_autres.Rows.Count > 0 Then
                        '-SI OUI MISE AJOURS
                        CODE_MAIN_COURANTE_AUTRES = main_courante_autres.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

                    End If

                    FAMILLE_ARTICLE = articleInfo.Rows(0)("CODE_FAMILLE")

                    Dim FIELDVALUE As Double = MONTANT_TTC

                    Dim FIELD As String = ""

                    If Trim(FAMILLE_ARTICLE) = "BOISSONS" Then
                        'TRAITEMENT DES BOISSONS
                        FIELD = "BAR"
                        mainCourantes.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_AUTRES, TABLE, FIELD, FIELDVALUE)

                        If FUSIONNEE = "EAU MINERAL" Then
                            FIELD = "CAFE"
                            mainCourantes.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_AUTRES, TABLE, FIELD, FIELDVALUE)
                        Else
                            If ligneFactureTempContent.Rows(i)("VALEUR_CONSO") > 0 Then
                                FIELD = "DIVERS" 'CONSOMMATION
                                mainCourantes.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_AUTRES, TABLE, FIELD, FIELDVALUE)
                            Else
                                FIELD = "CAVE"
                                mainCourantes.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_AUTRES, TABLE, FIELD, FIELDVALUE)
                            End If
                        End If

                    ElseIf Trim(FAMILLE_ARTICLE) = "ALIMENTS(REPAS)" Then

                        'ON EXCLU LES REPAS DE TYPE PETIT DEJEUENER DU CONTROLE DU TEMPS
                        'If FUSIONNEE = "PETIT DEJEUNER" Then
                        If FUSIONNEE = "PETIT DEJEUNER" Then
                            FIELD = "PDJ"
                        Else
                            'TRAITEMENTS DES ALIMENTS
                            '1- ON DOIT DETERMINER LA NATURE EN PASSANT L'HEURE DE VENTE DE L'ARTICLE
                            Dim momentDeVente As Date = CDate(HEURE_FACTURE).ToLongTimeString

                            NATURE = determintationDeLaNatureDuRePas(momentDeVente)

                            '2- DETERMINATION DU CHAMP A METTRE AJOUR DANS 

                            'If NATURE = "PETIT DEJEUNER" Then
                            'FIELD = "PDJ"
                            If Trim(NATURE).Equals("DEJEUNER") Then
                                FIELD = "DEJEUNER"
                            ElseIf Trim(NATURE).Equals("DINER") Then
                                FIELD = "DINER"
                            Else
                                FIELD = "DEJEUNER"
                            End If

                        End If

                        mainCourantes.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_AUTRES, TABLE, FIELD, FIELDVALUE)

                    Else
                        FUSIONNEE = ligneFactureTempContent.Rows(i)("FUSIONNEE")
                    End If

                    'ActivationForm.Show()
                    'ActivationForm.TopMost = True
                    'ActivationForm.GunaTextBoxMessage.Text = "FUSIONNE : " & FUSIONNEE & " NATURE : " & NATURE & " FIELD : " & FIELD & " FAMILLE : " & FAMILLE_ARTICLE
                    'Dim PDJ As Double = 0 'PETITE DEJEUNER
                    'Dim DEJEUNER As Double = 0 'DEJEUNER
                    'Dim DINER As Double = 0 'DINER
                    'Dim CAFE As Double = 0 'EAU MINERAL
                    'Dim BAR As Double = 0 'FAMILLE ARTICLE = BOISSONS
                    'Dim CAVE As Double = 0 '
                    'Dim DIVERS As Double = 0 'CONSOMMATION

                    '--------------------------------------------------------------------------------------------------------------

                    '----------------------- GESTION DU REMPLISSAGE DE LA MAIN COURANTE AUTRES -------------------------------

                    NOM_ARTICLE = articleInfo.Rows(0)("DESIGNATION_FR")

                    If Not reduction Then

                        If GlobalVariable.AgenceActuelle.Rows(0)("GERER_STOCK") = 0 Then
                            QUANTITE_AVANT_MOVEMENT = articleInfo.Rows(0)("QUANTITE")
                        Else
                            QUANTITE_AVANT_MOVEMENT = Economat.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(GlobalVariable.magasinActuel, CODE_ARTICLE)
                        End If

                        CMUP = articleInfo.Rows(0)("PRIX_ACHAT_HT")

                        CONTENANCE = articleInfo.Rows(0)("CONTENANCE")

                        ficheTechnique = Functions.getElementByCode(articleInfo.Rows(0)("CODE_CLE"), "fiche_technique", "CODE_FICHE_TECHNIQUE")

                        Dim UNITE_COMPTAGE As String = articleInfo.Rows(0)("UNITE_COMPTAGE")

                        unite = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    End If

                End If

                miseAjourDeLaMainCouranteParApportAPlusieursPointDeVente(NOM_ARTICLE, POINT_DE_VENTE, MONTANT_TTC)

                Dim CODE_LOT As String = "" 'CONTIENT L'UNITE DE DESTOCKAGE

                If Not ligneFactureTempContent.Rows(i)("CODE_LOT") Is Nothing Then
                    CODE_LOT = ligneFactureTempContent.Rows(i)("CODE_LOT")
                End If

                Dim MONTANT_HT As Double = ligneFactureTempContent.Rows(i)("MONTANT_HT")
                Dim TAXE As Double = ligneFactureTempContent.Rows(i)("TAXE")

                Dim QUANTITE As Double = 0

                Dim QUANTITE_LIGNE_FACTURE As Double = ligneFactureTempContent.Rows(i)("QUANTITE")

                Dim DATE_FACTURE As Date = ligneFactureTempContent.Rows(i)("DATE_FACTURE")

                Dim ETAT_FACTURE As Integer = ligneFactureTempContent.Rows(i)("ETAT_FACTURE")
                Dim DATE_OCCUPATION As Date = ligneFactureTempContent.Rows(i)("DATE_OCCUPATION")
                Dim HEURE_OCCUPATION As DateTime = ligneFactureTempContent.Rows(i)("HEURE_OCCUPATION")

                Dim TYPE_LIGNE_FACTURE As String = ligneFactureTempContent.Rows(i)("TYPE_LIGNE_FACTURE")
                Dim NUMERO_SERIE As String = ligneFactureTempContent.Rows(i)("NUMERO_SERIE")
                Dim NUMERO_ORDRE As Integer = ligneFactureTempContent.Rows(i)("NUMERO_ORDRE")
                Dim DESCRIPTION As String = ligneFactureTempContent.Rows(i)("DESCRIPTION")
                Dim CODE_UTILISATEUR_CREA As String = ligneFactureTempContent.Rows(i)("CODE_UTILISATEUR_CREA")
                Dim CODE_AGENCE As String = ligneFactureTempContent.Rows(i)("CODE_AGENCE")
                Dim MONTANT_REMISE As Double = ligneFactureTempContent.Rows(i)("MONTANT_REMISE")
                Dim MONTANT_TAXE As Double = ligneFactureTempContent.Rows(i)("MONTANT_TAXE")
                Dim NUMERO_SERIE_DEBUT As String = ligneFactureTempContent.Rows(i)("NUMERO_SERIE_DEBUT")
                Dim NUMERO_SERIE_FIN As String = ligneFactureTempContent.Rows(i)("NUMERO_SERIE_FIN")
                Dim CODE_MAGASIN As String = ligneFactureTempContent.Rows(i)("CODE_MAGASIN")
                Dim TYPE As String = ligneFactureTempContent.Rows(i)("TYPE")
                Dim NUMERO_BLOC_NOTE As String = ligneFactureTempContent.Rows(i)("NUMERO_BLOC_NOTE")
                Dim GRIFFE_UTILISATEUR As String = ligneFactureTempContent.Rows(i)("GRIFFE_UTILISATEUR")
                Dim VALEUR_CONSO As Double = ligneFactureTempContent.Rows(i)("VALEUR_CONSO")

                insertLigneFacture(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE_LIGNE_FACTURE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO)

                'MISE A JOURS DE LA FUSIONNEE DANS LIGNE FACTURES
                'PAS BESOINS DE METTRE A JOURS SI ON TRAITE LE PETIT DEJEUNER

                If FAMILLE_ARTICLE = "ALIMENTS(REPAS)" Then
                    If Not FUSIONNEE = "PETIT DEJEUNER" Then
                        miseAjoursSousFamilleArticleDansLigneFacture(CODE_FACTURE, NATURE, CODE_ARTICLE)
                    End If
                End If

                Dim econom As New Economat()

                If Not reduction Then

                    'MISE A JOUR DE LA QUANTITE DES LIGNE L'ARTICLE COMPOSE

                    'LA QUANTITE A DESTOCKER EST FONCTION DE LA GRANDE UNITE DE STOCKAGE
                    ' CAR NECESSISTANT DES CONVERSIONDE DE L'UNITE DE VENTE -> L'UNITE DE STOCKAGE:
                    '1- ON STOCK EN GRANDE UNITE PRINCIPALEMENT
                    '2- ON VENT EN PETITE UNITE 
                    '3- ON DECREMENTE LE STOCK EN GRANDE UNITE
                    '3.1- DONC IL EST NECESSAIRE DE RECONVERTIR DE L'UNITE DE VENTE (PETITE UNITE OU CONSO) VERS LA GRANDE UNITE POUR UNE EQUIVALENCE LORS DE LA SOUSATRACTION

                    'CONVERSION DE LA GRANDE QUANTITE EN UNITE DE STOCKAGE

                    'QUANTITE EST EN UNITE DE VENTE => PETITE UNITE

                    Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")


                    If True Then

                        Dim TABLE_SOURCEA_DESTOCKER As String = "article"
                        Dim QUANTITE_ARTICLE_A_DESTOCKER As Double = Functions.conversionEnPlusPetiteUnite(CODE_ARTICLE, QUANTITE_LIGNE_FACTURE, CODE_LOT) * -1 'UNITE_DE_VENTE

                        If ligneFactureTempContent.Rows(i)("VALEUR_CONSO") > 0 Then
                            CODE_LOT = "CONSOMMATION"
                        End If

                        'L'ARTICLE ETANT A LA CARTE IL NE FAIT PAS L'OBJET D'UN SUIVIE DE STOCK
                        If ficheTechnique.Rows.Count > 0 Then
                            Dim QUANTITE_ARTICLE_A_DESTOCKER_PLAT As Double = 0
                            econom.gestionStockagesEtDeStockages(Trim(CODE_ARTICLE), TABLE_SOURCEA_DESTOCKER, QUANTITE_ARTICLE_A_DESTOCKER_PLAT)
                        Else

                            If GlobalVariable.magasinActuel.Equals("") Then
                                econom.gestionStockagesEtDeStockages(Trim(CODE_ARTICLE), TABLE_SOURCEA_DESTOCKER, QUANTITE_ARTICLE_A_DESTOCKER)
                            Else
                                econom.miseAjourQuantiteTotalRestant(CODE_ARTICLE)
                            End If

                        End If

                        ' INSCRIPTION DES LIGNES DE MOUVEMENTS

                        Dim entre_en_stock As Double = 0

                        Dim sortie_de_stock As Double = Double.Parse(QUANTITE_ARTICLE_A_DESTOCKER) * -1 ' ENTRER DES VALEURS POSITIVES

                        Dim DATE_PEREMPTION As Date

                        Dim LIBELLE_MOUVEMENT As String = "vente article"

                        Dim TYPE_MOUVEMENT As String = "sortie de stock"

                        Dim QUANTITE_ENTREE As Double = 0
                        Dim QUANTITE_SORTIE As Double = sortie_de_stock
                        Dim VALEUR_ENTREE As Double = 0
                        Dim VALEUR_SORTIE As String = sortie_de_stock

                        Dim ETAT_MOUVEMENT As String = ""
                        Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                        'GESTION DES LIGNES DE MOUVEMENT SSI NOUS GERONS LES BON DE RECEPTION VALIDE

                        Dim CODE_BORDEREAUX_MOV As String = "vente"

                        'INSERTION DU MOVEMENT DE STOCK
                        If ficheTechnique.Rows.Count > 0 Then
                            QUANTITE_SORTIE = QUANTITE
                        End If

                        If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, GlobalVariable.codeAgence, CODE_BORDEREAUX_MOV, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                        End If

                        ' END INSCRIPTION DES LIGNES DE MOUVEMENTS

                        Dim ETAT_BORDEREAU As Integer = 0

                        'ON VERIFIE SI L'ARTICLE APPARTIENT A UNE FICHE TECHNIQUE AUQUEL CAS ON VA DESTOCKER LES ELEMENTS LE CONSTITUANT

                        'Dim ficheTechnique As DataTable = Functions.getElementByCode(Trim(CODE_ARTICLE), "fiche_technique", "CODE_ARTICLE")

                        If ficheTechnique.Rows.Count > 0 Then

                            'GESTION DES COMMANDES CUISINES ------------------------

                            NOMBRE_DE_PORTION = QUANTITE_LIGNE_FACTURE 'NOMBRE D'UNITE VENDU

                            If NOMBRE_DE_PORTION < 0 Then
                                NOMBRE_DE_PORTION *= -1
                            End If

                            Dim RANDOM_CODE As String = Functions.GeneratingRandomCodePanne("article", "")

                            Dim CODE_FICHE_TECHNIQUE As String = ficheTechnique.Rows(0)("CODE_FICHE_TECHNIQUE")

                            Dim article As New Article()

                            Dim CODE_ARTICLE_FICHE = CODE_ARTICLE

                            Dim DATE_PREPARATION As Date = GlobalVariable.DateDeTravail

                            article.commandeCuisine(CODE_ARTICLE_FICHE, NOM_ARTICLE, CODE_FICHE_TECHNIQUE, NOMBRE_DE_PORTION, DATE_PREPARATION, RANDOM_CODE, PRIX_VENTE)

                        End If

                    End If

                End If

            Next
            Return True
        Else
            Return False
        End If

    End Function

    Public Function determintationDeLaNatureDuRePas(ByVal momentDeVente As Date) As String

        Dim temps1 As DateTime = "6:00:00"
        Dim temps2 As DateTime = "10:00:00"
        Dim temps3 As DateTime = "17:59:00"
        Dim temps4 As DateTime = "22:00:00"

        Dim tempsDeVente As DateTime = momentDeVente.ToLongTimeString
        Dim natureRepas As String

        If tempsDeVente >= temps1 And tempsDeVente <= temps2 Then
            natureRepas = " DEJEUNER"
        ElseIf tempsDeVente > temps2 And tempsDeVente <= temps3 Then
            natureRepas = "DEJEUNER"
        ElseIf tempsDeVente > temps3 And tempsDeVente <= temps4 Then
            natureRepas = "DINER"
        Else
            natureRepas = "DINER"
        End If

        Return natureRepas

    End Function

    Public Sub miseAjoursSousFamilleArticleDansLigneFacture(ByVal CODE_FACTURE As String, ByVal NATURE As String, ByVal CODE_ARTICLE As String)

        Dim updateQuery As String = "UPDATE `ligne_facture` SET `FUSIONNEE`=@NATURE WHERE CODE_FACTURE=@CODE_FACTURE AND CODE_ARTICLE=@CODE_ARTICLE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@NATURE", MySqlDbType.VarChar).Value = NATURE

        command.ExecuteNonQuery()

    End Sub

    'PERMETTRE LA MISE A JOURS DE LA MAINCOURANTE SUIVANT PLUSIEURS POINT DE VENTE AINSI PLUS BESOINS DE SEPARER LES ELEMENTS DU BLOC NOTES

    Public Sub miseAjourDeLaMainCouranteParApportAPlusieursPointDeVente(ByVal nomArticle As String, ByVal pointDeVente As String, ByVal montantPointDeVente As Double, ByVal Optional ANNULATION As Integer = 0)

        Dim BAR_RESTAURANT As Double
        Dim SERVICES As Double
        Dim SALON_DE_BEAUTE As Double
        Dim BOUTIQE As Double
        Dim BUSINESS_CENTER As Double
        Dim AUTRES As Double
        Dim SPORTS As Double
        Dim KIOSQUE_A_JOURNAUX As Double
        Dim LOISIRS As Double
        Dim BLANCHISSERIE As Double

        'GunaTextBoxMontantTTCGeneral.Text = OLD_MONTANT_TTC

        If pointDeVente = "BAR" Or pointDeVente = "RESTAURANT" Then

            If ANNULATION = 1 Then
                BAR_RESTAURANT = montantPointDeVente * -1
            Else
                BAR_RESTAURANT = montantPointDeVente
            End If

            SERVICES = 0
            SALON_DE_BEAUTE = 0
            BOUTIQE = 0
            BUSINESS_CENTER = 0
            AUTRES = 0
            SPORTS = 0
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "SERVICES" Then

            BAR_RESTAURANT = 0

            'AU CAS OU LE SERVICE EST DE TYPE LOCATION SALLE OU HEBERGEMENT ALORS ON NE MET PAS AJOUR LE CHAMP DU SERVICE DANS LA MAINCOURANTE JOURNALIERE
            If nomArticle.Contains("HEBERGEMENT") Or nomArticle.Contains("LOCATION SALLE") Or nomArticle.Contains("HALL RENTING") Or nomArticle.Contains("ACCOMMODATION") Then

                'ON DOIT DETERMINER SI ON N'A PAS A FAIRE A UNE DAY USE AU QUEL CAS ON DOIT DONNER UNE VALEUR A SERVICE.

                Dim infoResa As DataTable = Functions.getElementByCode(GlobalVariable.codeReservationToUpdate, "reserve_conf", "CODE_RESERVATION")

                If infoResa.Rows.Count > 0 Then

                    If infoResa.Rows(0)("DAY_USE") = 1 Then
                        'DAY USE
                        SERVICES = 0
                    Else
                        'SEJOURS

                        'GESTION DES ANNULATIONS DEPUIS LA FENETRE DE SITUATION DU CLIENT

                        If ANNULATION = 1 Then
                            SERVICES = montantPointDeVente * -1
                        Else
                            SERVICES = montantPointDeVente
                        End If

                    End If

                End If

            Else

                If ANNULATION = 1 Then
                    SERVICES = montantPointDeVente * -1
                Else
                    SERVICES = montantPointDeVente
                End If

            End If

            SALON_DE_BEAUTE = 0
            BOUTIQE = 0
            BUSINESS_CENTER = 0
            AUTRES = 0
            SPORTS = 0
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "SALON DE BEAUTE" Then

            BAR_RESTAURANT = 0
            SERVICES = 0

            If ANNULATION = 1 Then
                SALON_DE_BEAUTE = montantPointDeVente * -1
            Else
                SALON_DE_BEAUTE = montantPointDeVente
            End If

            BOUTIQE = 0
            BUSINESS_CENTER = 0
            AUTRES = 0
            SPORTS = 0
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "BOUTIQUE" Then

            BAR_RESTAURANT = 0
            SERVICES = 0
            SALON_DE_BEAUTE = 0

            If ANNULATION = 1 Then
                BOUTIQE = montantPointDeVente * -1
            Else
                BOUTIQE = montantPointDeVente
            End If

            BUSINESS_CENTER = 0
            AUTRES = 0
            SPORTS = 0
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "BUSINESS CENTER" Then

            BAR_RESTAURANT = 0
            SERVICES = 0
            SALON_DE_BEAUTE = 0
            BOUTIQE = 0

            If ANNULATION = 1 Then
                BUSINESS_CENTER = montantPointDeVente * -1
            Else
                BUSINESS_CENTER = montantPointDeVente
            End If

            AUTRES = 0
            SPORTS = 0
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "AUTRES" Then

            BAR_RESTAURANT = 0
            SERVICES = 0
            SALON_DE_BEAUTE = 0
            BOUTIQE = 0
            BUSINESS_CENTER = 0

            If ANNULATION = 1 Then
                AUTRES = montantPointDeVente * -1
            Else
                AUTRES = montantPointDeVente
            End If

            SPORTS = 0
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "SPORTS" Then

            BAR_RESTAURANT = 0
            SERVICES = 0
            SALON_DE_BEAUTE = 0
            BOUTIQE = 0
            BUSINESS_CENTER = 0
            AUTRES = 0
            If ANNULATION = 1 Then
                SPORTS = montantPointDeVente * -1
            Else
                SPORTS = montantPointDeVente
            End If
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "LOISIRS" Then

            BAR_RESTAURANT = 0
            SERVICES = 0
            SALON_DE_BEAUTE = 0
            BOUTIQE = 0
            BUSINESS_CENTER = 0
            AUTRES = 0
            SPORTS = 0
            If ANNULATION = 1 Then
                LOISIRS = montantPointDeVente * -1

            Else
                LOISIRS = montantPointDeVente

            End If
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "KIOSQUE A JOURNAUX" Then

            BAR_RESTAURANT = 0
            SERVICES = 0
            SALON_DE_BEAUTE = 0
            BOUTIQE = 0
            BUSINESS_CENTER = 0
            AUTRES = 0
            SPORTS = 0
            LOISIRS = 0
            If ANNULATION = 1 Then
                KIOSQUE_A_JOURNAUX = montantPointDeVente * -1
            Else
                KIOSQUE_A_JOURNAUX = montantPointDeVente
            End If
            BLANCHISSERIE = 0

        ElseIf pointDeVente = "BLANCHISSERIE" Then

            BAR_RESTAURANT = 0
            SERVICES = 0
            SALON_DE_BEAUTE = 0
            BOUTIQE = 0
            BUSINESS_CENTER = 0
            AUTRES = 0
            SPORTS = 0
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            If ANNULATION = 1 Then
                BLANCHISSERIE = montantPointDeVente * -1
            Else
                BLANCHISSERIE = montantPointDeVente
            End If

        Else

            BAR_RESTAURANT = 0
            SERVICES = 0
            SALON_DE_BEAUTE = 0
            BOUTIQE = 0
            BUSINESS_CENTER = 0
            If ANNULATION = 1 Then
                AUTRES = montantPointDeVente * -1

            Else
                AUTRES = montantPointDeVente

            End If
            SPORTS = 0
            LOISIRS = 0
            KIOSQUE_A_JOURNAUX = 0
            BLANCHISSERIE = 0

        End If

        Dim mainCourantes As New MainCourantes()

        Dim CODE_MAIN_COURANTE_JOURNALIERE As String = ""
        Dim CODE_MAIN_COURANTE_GENERALE As String = ""

        If GlobalVariable.typeDeClientAFacturer = "en chambre" Or GlobalVariable.typeDeClientAFacturer = "evenement" Or Not GlobalVariable.codeReservationToUpdate = "" Then

            If Not GlobalVariable.codeReservationToUpdate = "" Then

                'When we access the facturation form from frontdesk

                CODE_MAIN_COURANTE_JOURNALIERE = GlobalVariable.codeMainCouranteJournaliereToUpdate
                CODE_MAIN_COURANTE_GENERALE = GlobalVariable.codeMainCouranteGeneraleToUpdate

            End If

            'BUSINESS_CENTER = CYBERCAFE

            mainCourantes.updateMainCouranteAfterFacturation("journaliere", CODE_MAIN_COURANTE_JOURNALIERE, BAR_RESTAURANT, SERVICES, SALON_DE_BEAUTE, BOUTIQE, BUSINESS_CENTER, AUTRES, SPORTS, LOISIRS, KIOSQUE_A_JOURNAUX, BLANCHISSERIE)

            'mainCourantes.updateMainCouranteAfterFacturation("generale", CODE_MAIN_COURANTE_GENERALE, BAR_RESTAURANT, SERVICES, SALON_DE_BEAUTE, BOUTIQE, BUSINESS_CENTER, AUTRES, SPORTS, LOISIRS, KIOSQUE_A_JOURNAUX, BLANCHISSERIE)

        ElseIf GlobalVariable.typeDeClientAFacturer = "comptoir" Then

            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            Dim CODE_MAIN_COURANTE_AUTRES As String = ""
            'TRAITEMENT DE LA MAIN COURANTE_AUTRE

            '1- VERIFICATION DE L'EXISTENCE D'UNE LIGNE DE MAIN_COURANTE_AUTRE EN DATE DU JOURS AVEC COMME ETAT = 0
            Dim ETAT_MAIN_COURANTE As Integer = 0

            Dim main_courante_autres As DataTable = Functions.getElementByOnCodeAndDate(ETAT_MAIN_COURANTE, "main_courante_autres", "ETAT_MAIN_COURANTE", GlobalVariable.DateDeTravail, "main_courante_autres")

            If main_courante_autres.Rows.Count > 0 Then

                '-SI OUI MISE AJOURS
                CODE_MAIN_COURANTE_AUTRES = main_courante_autres.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

                mainCourantes.updateMainCouranteAfterFacturation("main_courante_autres", CODE_MAIN_COURANTE_AUTRES, BAR_RESTAURANT, SERVICES, SALON_DE_BEAUTE, BOUTIQE, BUSINESS_CENTER, AUTRES, SPORTS, LOISIRS, KIOSQUE_A_JOURNAUX, BLANCHISSERIE)

            End If

        End If

    End Sub

    Public Function MigrationDeLigneFatureTempVersLigneFactureEnChambre(ByVal CODE_RESERVATION_TEMP As String) As Boolean

        Dim ligneFactureTempContent As New DataTable()

        Dim mainsCourante As New MainCourantes()

        ligneFactureTempContent = Functions.getElementByCode(CODE_RESERVATION_TEMP, "ligne_facture_temp", "CODE_RESERVATION")

        Dim CODE_ARTICLE As String = ""
        Dim NATURE As String = ""

        Dim PRIX_VENTE As Double = 0

        If ligneFactureTempContent.Rows.Count > 0 Then

            For i = 0 To ligneFactureTempContent.Rows.Count - 1

                Dim CODE_FACTURE As String = ligneFactureTempContent.Rows(i)("CODE_FACTURE")
                Dim CODE_RESERVATION As String = ligneFactureTempContent.Rows(i)("CODE_RESERVATION")
                Dim CODE_MOUVEMENT As String = ligneFactureTempContent.Rows(i)("CODE_MOUVEMENT")
                Dim CODE_CHAMBRE As String = ligneFactureTempContent.Rows(i)("CODE_CHAMBRE")
                Dim CODE_MODE_PAIEMENT As String = ligneFactureTempContent.Rows(i)("CODE_MODE_PAIEMENT")
                Dim NUMERO_PIECE As String = ligneFactureTempContent.Rows(i)("NUMERO_PIECE")
                Dim POINT_DE_VENTE As String = ligneFactureTempContent.Rows(i)("TYPE_LIGNE_FACTURE")
                CODE_ARTICLE = ligneFactureTempContent.Rows(i)("CODE_ARTICLE")

                Dim LIBELLE_FACTURE As String = ligneFactureTempContent.Rows(i)("LIBELLE_FACTURE") & " [" & CODE_CHAMBRE & "]"

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                Dim NOMBRE_DE_PORTION As Double = 0

                '-------------------------

                Dim CONTENANCE As Double = 0

                Dim articleInfo As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                Dim reduction As Boolean = False

                'ON DETERMINE SI LA LIGNE EST REDUCTION OU PAS

                If Not articleInfo.Rows.Count > 0 Then

                    CODE_ARTICLE = ligneFactureTempContent.Rows(i)("NUMERO_SERIE_DEBUT")
                    articleInfo = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                    reduction = True

                End If

                Dim unite As DataTable
                '-----------------------
                Dim ficheTechnique As DataTable

                Dim NOM_ARTICLE As String = ""

                Dim FUSIONNEE As String = ligneFactureTempContent.Rows(i)("FUSIONNEE")
                Dim PRIX_UNITAIRE_TTC As Double = ligneFactureTempContent.Rows(i)("PRIX_UNITAIRE_TTC")
                PRIX_VENTE = ligneFactureTempContent.Rows(i)("PRIX_UNITAIRE_TTC")
                Dim MONTANT_TTC As Double = ligneFactureTempContent.Rows(i)("MONTANT_TTC")
                Dim HEURE_FACTURE As DateTime = ligneFactureTempContent.Rows(i)("HEURE_FACTURE")

                Dim FAMILLE_ARTICLE As String = ""

                If articleInfo.Rows.Count > 0 Then

                    '----------------------- END GESTION DU REMPLISSAGE DE LA MAIN COURANTE JOURNALIERE -------------------------------

                    Dim TABLE As String = "main_courante_journaliere"
                    Dim CODE_MAIN_COURANTE_JOURNALIERE As String = GlobalVariable.codeMainCouranteJournaliereToUpdate

                    FAMILLE_ARTICLE = articleInfo.Rows(0)("CODE_FAMILLE")

                    Dim FIELDVALUE As Double = MONTANT_TTC
                    Dim FIELD As String = ""

                    If Trim(FAMILLE_ARTICLE) = "BOISSONS" Then
                        'TRAITEMENT DES BOISSONS
                        FIELD = "BAR"
                        mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                        If FUSIONNEE = "EAU MINERAL" Then
                            FIELD = "CAFE"
                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                        Else
                            If ligneFactureTempContent.Rows(i)("VALEUR_CONSO") > 0 Then
                                FIELD = "DIVERS" 'CONSOMMATION
                                mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                            Else
                                FIELD = "CAVE"
                                mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                            End If
                        End If

                    ElseIf Trim(FAMILLE_ARTICLE) = "ALIMENTS(REPAS)" Then

                        'ON EXCLU LES REPAS DE TYPE PETIT DEJEUENER DU CONTROLE DU TEMPS
                        'If FUSIONNEE = "PETIT DEJEUNER" Then
                        If FUSIONNEE = "PETIT DEJEUNER" Then
                            FIELD = "PDJ"
                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                        Else

                            'TRAITEMENTS DES ALIMENTS DE TYPE DEJEUENER/DINER

                            '1- ON DOIT DETERMINER LA NATURE EN PASSANT L'HEURE DE VENTE DE L'ARTICLE
                            Dim momentDeVente As Date = CDate(HEURE_FACTURE).ToLongTimeString

                            NATURE = Trim(determintationDeLaNatureDuRePas(momentDeVente))

                            '2- DETERMINATION DU CHAMP A METTRE AJOUR DANS 

                            If Trim(NATURE).Equals("DEJEUNER") Then
                                FIELD = "DEJEUNER"
                            ElseIf Trim(NATURE).Equals("DINER") Then
                                FIELD = "DINER"
                            Else
                                FIELD = "DEJEUNER"
                            End If

                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                        End If

                    Else
                        FUSIONNEE = ligneFactureTempContent.Rows(i)("FUSIONNEE")
                    End If

                    'Dim PDJ As Double = 0 'PETITE DEJEUNER
                    'Dim DEJEUNER As Double = 0 'DEJEUNER
                    'Dim DINER As Double = 0 'DINER
                    'Dim CAFE As Double = 0 'EAU MINERAL
                    'Dim BAR As Double = 0 'FAMILLE ARTICLE = BOISSONS
                    'Dim CAVE As Double = 0 '
                    'Dim DIVERS As Double = 0 'CONSOMMATION

                    '--------------------------------------------------------------------------------------------------------------

                    NOM_ARTICLE = articleInfo.Rows(0)("DESIGNATION_FR")

                    If Not reduction Then

                        If GlobalVariable.magasinActuel.Equals("") Then
                            QUANTITE_AVANT_MOVEMENT = articleInfo.Rows(0)("QUANTITE")
                        Else
                            QUANTITE_AVANT_MOVEMENT = Economat.QuantiteDunArticleQuelconqueDansUnMagasinQuelconque(GlobalVariable.magasinActuel, CODE_ARTICLE)
                        End If

                        'QUANTITE_AVANT_MOVEMENT = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("QUANTITE")
                        CMUP = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE").Rows(0)("PRIX_ACHAT_HT")

                        CONTENANCE = articleInfo.Rows(0)("CONTENANCE")

                        'FICHE TECHNIQUE DE L'ARTICLE EN VENTE
                        ficheTechnique = Functions.getElementByCode(articleInfo.Rows(0)("CODE_CLE"), "fiche_technique", "CODE_FICHE_TECHNIQUE")
                        'CODE_CLE = CODE_FICHE_TECHNIQUE

                        Dim UNITE_COMPTAGE As String = articleInfo.Rows(0)("UNITE_COMPTAGE")

                        unite = Functions.getElementByCode(UNITE_COMPTAGE, "unite_comptage", "CODE_UNITE_DE_COMPTAGE")

                    End If

                End If

                'If FUSIONNEE.Equals("HEBERGEMENT") Or FUSIONNEE.Equals("ACCOMMODATION") Then
                'POINT_DE_VENTE = "MONTANT_ACCORDE"
                'End If

                'MISE A JOURS DE LA MAINCOURANTE PAR APPORT A CHAQUE POINT DE VENTE
                miseAjourDeLaMainCouranteParApportAPlusieursPointDeVente(NOM_ARTICLE, POINT_DE_VENTE, MONTANT_TTC)

                If FUSIONNEE.Equals("HEBERGEMENT") Or FUSIONNEE.Equals("ACCOMMODATION") Then
                    'ON DOIT RETRANCHER LE MONTANT DU SERVICE
                    Dim CODE_MAIN_COURANTE_JOURNALIERE As String = GlobalVariable.codeMainCouranteJournaliereToUpdate
                    Functions.updateOfFieldsAddSubtract("main_courante_journaliere", POINT_DE_VENTE, MONTANT_TTC * -1, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)
                    Functions.updateOfFieldsAddSubtract("main_courante_journaliere", "MONTANT_ACCORDE", MONTANT_TTC, "CODE_MAIN_COURANTE_JOURNALIERE", CODE_MAIN_COURANTE_JOURNALIERE, 1)
                End If

                Dim CODE_LOT As String = ligneFactureTempContent.Rows(i)("CODE_LOT")
                Dim MONTANT_HT As Double = ligneFactureTempContent.Rows(i)("MONTANT_HT")
                Dim TAXE As Double = ligneFactureTempContent.Rows(i)("TAXE")

                Dim QUANTITE_LIGNE_FACTURE As Double = ligneFactureTempContent.Rows(i)("QUANTITE")
                'TRAITEMENT DES CONSOMMATIONS

                Dim DATE_FACTURE As Date = ligneFactureTempContent.Rows(i)("DATE_FACTURE")

                Dim ETAT_FACTURE As Integer = ligneFactureTempContent.Rows(i)("ETAT_FACTURE")
                Dim DATE_OCCUPATION As Date = ligneFactureTempContent.Rows(i)("DATE_OCCUPATION")
                Dim HEURE_OCCUPATION As DateTime = ligneFactureTempContent.Rows(i)("HEURE_OCCUPATION")

                Dim TYPE_LIGNE_FACTURE As String = ligneFactureTempContent.Rows(i)("TYPE_LIGNE_FACTURE")
                Dim NUMERO_SERIE As String = ligneFactureTempContent.Rows(i)("NUMERO_SERIE")
                Dim NUMERO_ORDRE As Integer = ligneFactureTempContent.Rows(i)("NUMERO_ORDRE")
                Dim DESCRIPTION As String = ligneFactureTempContent.Rows(i)("DESCRIPTION")
                Dim CODE_UTILISATEUR_CREA As String = ligneFactureTempContent.Rows(i)("CODE_UTILISATEUR_CREA")
                Dim CODE_AGENCE As String = ligneFactureTempContent.Rows(i)("CODE_AGENCE")
                Dim MONTANT_REMISE As Double = ligneFactureTempContent.Rows(i)("MONTANT_REMISE")
                Dim MONTANT_TAXE As Double = ligneFactureTempContent.Rows(i)("MONTANT_TAXE")
                Dim NUMERO_SERIE_DEBUT As String = ligneFactureTempContent.Rows(i)("NUMERO_SERIE_DEBUT")
                Dim NUMERO_SERIE_FIN As String = ligneFactureTempContent.Rows(i)("NUMERO_SERIE_FIN")
                Dim CODE_MAGASIN As String = ligneFactureTempContent.Rows(i)("CODE_MAGASIN")

                Dim TYPE As String = ligneFactureTempContent.Rows(i)("TYPE")
                Dim NUMERO_BLOC_NOTE As String = ligneFactureTempContent.Rows(i)("NUMERO_BLOC_NOTE")
                Dim GRIFFE_UTILISATEUR As String = ligneFactureTempContent.Rows(i)("GRIFFE_UTILISATEUR")
                Dim VALEUR_CONSO As Double = ligneFactureTempContent.Rows(i)("VALEUR_CONSO")

                insertLigneFacture(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE_LIGNE_FACTURE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TYPE, NUMERO_BLOC_NOTE, GRIFFE_UTILISATEUR, VALEUR_CONSO)

                'MISE A JOURS DE LA FUSIONNEE DANS LIGNE FACTURES

                If FAMILLE_ARTICLE = "ALIMENTS(REPAS)" Then
                    If Not FUSIONNEE = "PETIT DEJEUNER" Then
                        miseAjoursSousFamilleArticleDansLigneFacture(CODE_FACTURE, NATURE, CODE_ARTICLE)
                    End If
                End If

                '------------------------------------------
                Dim econom As New Economat()

                'ON SE RASSURE DE PAS EFFECTIVE GERER LES QUANTITE POUR LES REMISE

                If Not reduction Then

                    'MISE A JOUR DE LA QUANTITE DES LIGNE L'ARTICLE COMPOSE

                    'LA QUANTITE A DESTOCKER EST FONCTION DE LA GRANDE UNITE DE STOCKAGE
                    ' CAR NECESSISTANT DES CONVERSION DE DE L'UNITE DE VENTE -> L'UNITE DE STOCKAGE:
                    '1- ON STOCK EN GRANDE UNITE PRINCIPALEMENT
                    '2- ON VENT EN PETITE UNITE 
                    '3- ON DECREMENTE LE STOCK EN GRANDE UNITE
                    '3.1- DONC IL EST NECESSAIRE DE RECONVERTIR DE L'UNITE DE VENTE (PETITE UNITE OU CONSO) VERS LA GRANDE UNITE POUR UNE EQUIVALENCE LORS DE LA SOUSATRACTION

                    'CONVERSION DE LA GRANDE QUANTITE EN UNITE DE STOCKAGE

                    'QUANTITE EST EN UNITE DE VENTE => PETITE UNITE

                    Dim gestionDesStock As Integer = Functions.getElementByCode(CODE_AGENCE, "agence", "CODE_AGENCE").Rows(0)("GERER_STOCK")

                    Dim valeurDeConversion As Double = 0

                    Dim TABLE_SOURCEA_DESTOCKER As String = "article"
                    Dim QUANTITE_ARTICLE_A_DESTOCKER As Double = Functions.conversionEnPlusPetiteUnite(CODE_ARTICLE, QUANTITE_LIGNE_FACTURE, CODE_LOT) * -1 'CODE_LOT = UNITE_DE_VENTE

                    'L'ARTICLE ETANT A LA CARTE IL NE FAIT PAS L'OBJET D'UN SUIVIE DE STOCK
                    If ficheTechnique.Rows.Count > 0 Then
                        Dim QUANTITE_ARTICLE_A_DESTOCKER_PLAT As Double = 0
                        econom.gestionStockagesEtDeStockages(Trim(CODE_ARTICLE), TABLE_SOURCEA_DESTOCKER, QUANTITE_ARTICLE_A_DESTOCKER_PLAT)
                    Else
                        'econom.gestionStockagesEtDeStockages(Trim(CODE_ARTICLE), TABLE_SOURCEA_DESTOCKER, QUANTITE_ARTICLE_A_DESTOCKER)

                        If GlobalVariable.magasinActuel.Equals("") Then
                            econom.gestionStockagesEtDeStockages(Trim(CODE_ARTICLE), TABLE_SOURCEA_DESTOCKER, QUANTITE_ARTICLE_A_DESTOCKER)
                        Else
                            econom.miseAjourQuantiteTotalRestant(CODE_ARTICLE)
                        End If

                    End If

                    'INSCRIPTION DES LIGNES DE MOUVEMENTS

                    Dim entre_en_stock As Double = 0

                    Dim sortie_de_stock As Double = QUANTITE_ARTICLE_A_DESTOCKER * -1

                    Dim DATE_PEREMPTION As Date

                    Dim LIBELLE_MOUVEMENT As String = "vente article"

                    Dim TYPE_MOUVEMENT As String = "sortie de stock"

                Dim QUANTITE_ENTREE As Double = 0
                    Dim QUANTITE_SORTIE As Double = sortie_de_stock
                    Dim VALEUR_ENTREE As Double = 0
                Dim VALEUR_SORTIE As String = sortie_de_stock

                Dim ETAT_MOUVEMENT As String = ""
                Dim DATE_MOUVEMENT As Date = GlobalVariable.DateDeTravail

                    'GESTION DES LIGNES DE MOUVEMENT SSI NOUS GERONS LES BON DE RECEPTION VALIDE

                    If ligneFactureTempContent.Rows(i)("VALEUR_CONSO") > 0 Then
                        CODE_LOT = "CONSOMMATION"
                    End If

                    Dim CODE_BORDEREAUX_MOV As String = "vente"

                    'INSERTION DU MOVEMENT DE STOCK
                    If econom.insertLigneMovement(CODE_MOUVEMENT, LIBELLE_MOUVEMENT, TYPE_MOUVEMENT, ETAT_MOUVEMENT, DATE_MOUVEMENT, CODE_MAGASIN, CODE_ARTICLE, CODE_LOT, QUANTITE_ENTREE, QUANTITE_SORTIE, VALEUR_ENTREE, VALEUR_SORTIE, CODE_UTILISATEUR_CREA, GlobalVariable.codeAgence, CODE_BORDEREAUX_MOV, QUANTITE_AVANT_MOVEMENT, CMUP) Then

                    End If

                    ' END INSCRIPTION DES LIGNES DE MOUVEMENTS

                    'LES ARTICLES A LA CARTE SONT DESTOCKER A LA VENTE PAR APPORT A LEUR FICHE TECHNIQUE
                    'pour un destockages deux conditions sont necessaires:
                    '1- Etre un article a la carte
                    '2- Etre un article compose dertmine par une fiche technique

                    '--------------------------------

                    Dim ETAT_BORDEREAU As Integer = 0
                    'ON VERIFIE SI L'ARTICLE APPARTIENT A UNE FICHE TECHNIQUE AUQUEL CAS ON VA DESTOCKER LES ELEMENTS LE CONSTITUANT

                    'Dim ficheTechnique As DataTable = Functions.getElementByCode(Trim(CODE_ARTICLE), "fiche_technique", "CODE_ARTICLE")
                    'Dim ficheTechnique As DataTable = Functions.getElementByCode(ligneFactureTempContent.Rows(i)("CODE_CLE"), "fiche_technique", "CODE_ARTICLE")

                    If ficheTechnique.Rows.Count > 0 Then

                        'GESTION DES COMMANDES CUISINES ------------------------
                        NOMBRE_DE_PORTION = QUANTITE_LIGNE_FACTURE

                        If NOMBRE_DE_PORTION < 0 Then
                            NOMBRE_DE_PORTION = NOMBRE_DE_PORTION * -1
                        End If

                        Dim RANDOM_CODE As String = Functions.GeneratingRandomCodePanne("article", "")

                        Dim CODE_FICHE_TECHNIQUE As String = ficheTechnique.Rows(0)("CODE_FICHE_TECHNIQUE")

                        Dim article As New Article()

                        Dim CODE_ARTICLE_FICHE = CODE_ARTICLE

                        Dim DATE_PREPARATION As Date = GlobalVariable.DateDeTravail

                        article.commandeCuisine(CODE_ARTICLE_FICHE, NOM_ARTICLE, CODE_FICHE_TECHNIQUE, NOMBRE_DE_PORTION, DATE_PREPARATION, RANDOM_CODE, PRIX_VENTE)

                    End If

                End If

            Next

            Return True

        Else

            Return False

        End If

    End Function

    'create a function to update the selected reservation
    Public Function UpdateBlocNote(ByVal NUMERO_BLOC_NOTE As String, ByVal ETAT_BLOC_NOTE As Integer) As Boolean

        Dim updateQuery As String = "UPDATE `ligne_facture_bloc_note` SET `ETAT_BLOC_NOTE`=@value1 WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@value1", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

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

    'MET L'ETAT DE TOUTES LES LIGNES A ZERO POUR QU'ELLE NE S'AFFICHE PLUS PARTICULIEREMENT POUR LES VENTES EN CHAMBRE APRES TRANSFERT DU BILLETAGE
    Public Function UpdateEtatLigneFacture(ByVal CODE_UTILISATEUR As String, ByVal ETAT_FACTURE As Integer, ByVal CODE_FACTURE_RECETTE As String)

        '1- SELECTION DES LIGNES DU CAISSIER ACTUEL

        'ETAT_FACTURE EST UTILISE POUR L'EMPACKATAGE DES FACTURES

        'NUMERO_SERIE : CODE_RECETTE

        Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

        'Dim updateQuery As String = "UPDATE `ligne_facture` SET `ETAT_FACTURE` = @ETAT_FACTURE, `NUMERO_SERIE` = @CODE_FACTURE_RECETTE WHERE CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA AND CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_SERIE= @CODE_FACTURE_EMPTY"


        '------------------------------------------------------------------------------------------------------------------------------------------------------

        'ON DOIT INSERER LE CODE DE LA TRANSACTION UNIQUEMENT DANS LES LIGNES DE FACTURE EN RELATION AVEC UN NUMERO DE BLOC NOTE
        'CAR LES REGLEMETS SONT FAITS AU COMPTANT

        'Dim ligneFacture As New LigneFacture()
        Dim caisseGest As New Caisse()

        Dim CODE_CAISSIER As String = CODE_UTILISATEUR

        Dim NUMERO_BLOC_NOTE As String = ""

        Dim blocNoteDuCaissierActuel As DataTable = caisseGest.BlocNoteDunCaissierQuelconqueCloture(DateDeSituation, CODE_CAISSIER)

        If blocNoteDuCaissierActuel.Rows.Count > 0 Then

            'ON MET AJOURS LES ETAT DES LIGNES COMPTOIRS
            'LES LIGNES ASSOCIEES AUX COMPTOIRS DOIVENT PORTER LES CODE_TRANSACTION_RECETTE ET ETAT_FACTURE = 1 '
            'CAR ETANT UNE VENTE DU BAR ETAT_FACTURE = 1 SACHANT ETAT_FACTURE DES VENTES DE LA RECEPTION NE 
            'PEUT PRENDRE POUR VALEUR 1 UNIQUEMENT A LA CLOTURE DES FACTURES

            For i = 0 To blocNoteDuCaissierActuel.Rows.Count - 1

                NUMERO_BLOC_NOTE = blocNoteDuCaissierActuel.Rows(i)("NUMERO_BLOC_NOTE")

                Dim updateQuery As String = "UPDATE `ligne_facture` SET `ETAT`= @ETAT, ETAT_FACTURE=@ETAT_FACTURE, `NUMERO_SERIE` = @CODE_FACTURE_RECETTE WHERE CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA AND CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_SERIE= @CODE_FACTURE_EMPTY AND NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION"

                Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT_FACTURE
                command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
                command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
                command.Parameters.Add("@CODE_FACTURE_RECETTE", MySqlDbType.VarChar).Value = CODE_FACTURE_RECETTE
                command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
                command.Parameters.Add("@CODE_FACTURE_EMPTY", MySqlDbType.VarChar).Value = ""
                command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = "-" 'PERMET DE NE PAS PRENDRE LES VENTES EN CHAMBRE DANS LE CAS OU C'EST UN RECEPTIONNIST QUI FAIT LA VENTE
                command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE

                command.ExecuteNonQuery()

            Next

        End If

        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'ON MET AJOURS LES ETAT DES LIGNES EN CHAMBRES
        'LES LIGNES ASSOCIEES AUX EN CHAMBRES NE DOIVENT PAS PORTER LES CODE_TRANSACTION_RECETTE 

        Dim updateQuery2 As String = "UPDATE `ligne_facture` SET `ETAT` = @ETAT, `NUMERO_SERIE` = @CODE_FACTURE_RECETTE WHERE CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA AND CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND NUMERO_SERIE= @CODE_FACTURE_EMPTY AND NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

        Dim command2 As New MySqlCommand(updateQuery2, GlobalVariable.connect)

        command2.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT_FACTURE
        command2.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command2.Parameters.Add("@CODE_FACTURE_RECETTE", MySqlDbType.VarChar).Value = CODE_FACTURE_RECETTE
        'command2.Parameters.Add("@CODE_FACTURE_RECETTE", MySqlDbType.VarChar).Value = ""
        command2.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command2.Parameters.Add("@CODE_FACTURE_EMPTY", MySqlDbType.VarChar).Value = ""
        command2.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = ""

        command2.ExecuteNonQuery()

        '------------------------------------------------------------------------------------------------------------------------------------------------------

        'ON INSERT LE CODE DE LA FACTURE DE LA RECETTE DANS LE MODE DE REGLEMENT POUR LE RETROUVER AU NIVEAU DE LA CAISSE PRINCIPALE
        Dim updateQuery1 As String = "UPDATE `reglement` SET `CODE_MODE`= @CODE_FACTURE_RECETTE, ETAT=@ETAT WHERE CODE_CAISSIER=@CODE_CAISSIER AND CODE_AGENCE=@CODE_AGENCE AND DATE_REGLEMENT >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND CODE_MODE=@OLD_CODE_MODE "

        Dim command1 As New MySqlCommand(updateQuery1, GlobalVariable.connect)

        command1.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 1 'POUR LA RECEPTION
        command1.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command1.Parameters.Add("@CODE_FACTURE_RECETTE", MySqlDbType.VarChar).Value = CODE_FACTURE_RECETTE
        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command1.Parameters.Add("@OLD_CODE_MODE", MySqlDbType.VarChar).Value = ""

        command1.ExecuteNonQuery()

    End Function

    Public Function updateLigneFactureClotureFolio_(ByVal CODE_FACTURE As String, ByVal NEW_CODE_FACTURE As String, ByVal ETAT_FACTURE As Integer, ByVal CODE_ARTICLE As String, CODE_RESERVATION As String, ByVal ID_LIGNE_FACTURE As Integer) As Boolean

        Dim updateQuery As String = ""

        If Trim(CODE_RESERVATION) = "" Then
            'EMPACKATAGE POUR LES TRANSFERT VERS COMPTE INDIVIDUEL OU PAYMASTER (AU NIVEAU DU MODE DE REGLEMENT)
            updateQuery = "UPDATE `ligne_facture` Set `CODE_FACTURE`=@NEW_CODE_FACTURE,`ETAT_FACTURE`=@ETAT_FACTURE WHERE CODE_FACTURE=@CODE_FACTURE AND CODE_ARTICLE=@CODE_ARTICLE AND ETAT_FACTURE=@ETAT_FACTURE_OLD AND ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"
        Else
            'EMPACKATAGE POUR LES TRANSFERT VERS ENTREPRISE (CLOTURE AU NIVEAU DU FOLIO)
            'CAR LE CODE DE LA RESERVATION EST DONNEE
            updateQuery = "UPDATE `ligne_facture` Set `CODE_FACTURE`=@NEW_CODE_FACTURE,`ETAT_FACTURE`=@ETAT_FACTURE WHERE CODE_FACTURE=@CODE_FACTURE AND CODE_ARTICLE=@CODE_ARTICLE AND CODE_RESERVATION=@CODE_RESERVATION AND ETAT_FACTURE=@ETAT_FACTURE_OLD AND ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"
        End If

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        command.Parameters.Add("@NEW_CODE_FACTURE", MySqlDbType.VarChar).Value = NEW_CODE_FACTURE
        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@ETAT_FACTURE_OLD", MySqlDbType.Int64).Value = 0
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = ID_LIGNE_FACTURE

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


    'CLoture des lignes de facture d'un Folio a fin de generer la facture a proprement parler
    Public Function updateLigneFactureClotureFolio(ByVal CODE_FACTURE As String, ByVal NEW_CODE_FACTURE As String, ByVal ETAT_FACTURE As Integer, ByVal CODE_ARTICLE As String, CODE_RESERVATION As String) As Boolean

        Dim updateQuery As String = ""

        If Trim(CODE_RESERVATION) = "" Then
            'EMPACKATAGE POUR LES TRANSFERT VERS COMPTE INDIVIDUEL OU PAYMASTER (AU NIVEAU DU MODE DE REGLEMENT)
            updateQuery = "UPDATE `ligne_facture` Set `CODE_FACTURE`=@NEW_CODE_FACTURE,`ETAT_FACTURE`=@ETAT_FACTURE WHERE CODE_FACTURE=@CODE_FACTURE AND CODE_ARTICLE=@CODE_ARTICLE AND ETAT_FACTURE=@ETAT_FACTURE_OLD"
        Else
            'EMPACKATAGE POUR LES TRANSFERT VERS ENTREPRISE (CLOTURE AU NIVEAU DU FOLIO)
            'CAR LE CODE DE LA RESERVATION EST DONNEE
            updateQuery = "UPDATE `ligne_facture` Set `CODE_FACTURE`=@NEW_CODE_FACTURE,`ETAT_FACTURE`=@ETAT_FACTURE WHERE CODE_FACTURE=@CODE_FACTURE AND CODE_ARTICLE=@CODE_ARTICLE AND CODE_RESERVATION=@CODE_RESERVATION AND ETAT_FACTURE=@ETAT_FACTURE_OLD"
        End If

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        command.Parameters.Add("@NEW_CODE_FACTURE", MySqlDbType.VarChar).Value = NEW_CODE_FACTURE
        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@ETAT_FACTURE_OLD", MySqlDbType.Int64).Value = 0
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

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

    Public Function UpdateEtatLigneFacturePourClientComptoireApreCloture(ByVal NUMERO_BLOC_NOTE As String, ByVal ETAT As Integer) As Boolean

        'Dim updateQuery As String = "UPDATE `ligne_facture_bloc_note` SET `ETAT_FACTURE`=@ETAT_FACTURE, ETAT_BLOC_NOTE=@ETAT_BLOC_NOTE WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"
        Dim updateQuery As String = "UPDATE `ligne_facture_bloc_note` SET `ETAT`=@ETAT WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@ETAT", MySqlDbType.Int32).Value = ETAT

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

    'On met a jour les lignes du bloc note pour permettre l'equilibre avant cloture de caisse 
    Public Function UpdateEtatLigneFacturePourClientComptoire(ByVal NUMERO_BLOC_NOTE As String, ByVal ETAT_FACTURE As Integer, ByVal ETAT_BLOC_NOTE As Integer) As Boolean

        'Dim updateQuery As String = "UPDATE `ligne_facture_bloc_note` SET `ETAT_FACTURE`=@ETAT_FACTURE, ETAT_BLOC_NOTE=@ETAT_BLOC_NOTE WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"
        Dim updateQuery As String = "UPDATE `ligne_facture_bloc_note` SET `ETAT_FACTURE`=@ETAT_FACTURE, ETAT_BLOC_NOTE=@ETAT_BLOC_NOTE WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function UpdateEtatLigneFactureGratuite(ByVal UTILISATEUR As String, ByVal ETAT As Integer, ByVal DateDeSituation As Date) As Boolean

        Dim updateQuery As String = "UPDATE `ligne_facture_gratuite` SET `ETAT` = @ETAT WHERE CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA AND CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "'"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = UTILISATEUR
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function
    Public Function UpdateEtatLigneFactureLorsDeAucuneRecette(ByVal UTILISATEUR As String, ByVal ETAT As Integer, ByVal DateDeSituation As Date) As Boolean

        Dim updateQuery As String = "UPDATE `ligne_facture` SET `ETAT` = @ETAT WHERE CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA AND CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "'"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = UTILISATEUR
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function
    'JOURNAL DES VENTES

    ' ----------------------- RAPPORT DES VENTES -------------------------
    Public Function ListeDesCategoriesDArticleVendusMagasin(ByVal DateDebut As Date, ByVal DateFin As Date, Optional ByVal CODE_CAISSIER As String = "", Optional ByVal CODE_MAGASIN As String = "") As DataTable

        Dim Query As String = ""

        If Trim(CODE_CAISSIER) = "" Then

            Query = "SELECT DISTINCT FUSIONNEE As 'SOUS FAMILLE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_MAGASIN=@CODE_MAGASIN AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY FUSIONNEE ASC"
        Else
            'SELECTION DES FAMIILE UNIQUEMENT VENDU PAR LE CAISSIER EN COURS
            Query = "SELECT DISTINCT FUSIONNEE As 'SOUS FAMILLE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_MAGASIN=@CODE_MAGASIN AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') AND CODE_UTILISATEUR_CREA=@CODE_CAISSIER ORDER BY FUSIONNEE ASC"

        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesCategoriesDArticleVendusParRubrique(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer, Optional ByVal CODE_CAISSIER As String = "") As DataTable

        Dim Query As String = ""

        If ETAT_FACTURE = 4 Then

            If Trim(CODE_CAISSIER) = "" Then
                Query = "SELECT DISTINCT FUSIONNEE As 'SOUS FAMILLE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE 
            AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' 
            AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') AND TYPE=@TYPE
            ORDER BY FUSIONNEE ASC"
            Else
                'SELECTION DES FAMIILE UNIQUEMENT VENDU PAR LE CAISSIER EN COURS
                Query = "SELECT DISTINCT FUSIONNEE As 'SOUS FAMILLE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' 
            AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') AND CODE_UTILISATEUR_CREA=@CODE_CAISSIER 
            AND TYPE=@TYPE
            ORDER BY FUSIONNEE ASC"
            End If

        Else

            If Trim(CODE_CAISSIER) = "" Then
                Query = "SELECT DISTINCT FUSIONNEE As 'SOUS FAMILLE' FROM ligne_facture,ligne_facture_bloc_note WHERE CODE_AGENCE=@CODE_AGENCE 
                AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' 
                AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') AND 
                AND ligne_facture_bloc_note.ETAT_FACTURE=@ETAT_FACTURE AND ligne_facture_bloc_note.NUMERO_BLOC_NOTE = ligne_facture.NUMERO_BLOC_NOTE
                ORDER BY FUSIONNEE ASC"
            Else
                'SELECTION DES FAMIILE UNIQUEMENT VENDU PAR LE CAISSIER EN COURS
                Query = "SELECT DISTINCT FUSIONNEE As 'SOUS FAMILLE' FROM ligne_facture,ligne_facture_bloc_note WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') AND CODE_UTILISATEUR_CREA=@CODE_CAISSIER 
                AND ligne_facture_bloc_note.ETAT_FACTURE=@ETAT_FACTURE AND ligne_facture_bloc_note.NUMERO_BLOC_NOTE = ligne_facture.NUMERO_BLOC_NOTE
                ORDER BY FUSIONNEE ASC"
            End If


        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '1- CATEGORIES PARENTS
    Public Function ListeDesCategoriesDArticleVendus(ByVal DateDebut As Date, ByVal DateFin As Date, Optional ByVal CODE_CAISSIER As String = "") As DataTable

        Dim Query As String = ""

        If Trim(CODE_CAISSIER) = "" Then
            Query = "SELECT DISTINCT FUSIONNEE As 'SOUS FAMILLE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY FUSIONNEE ASC"
        Else
            'SELECTION DES FAMIILE UNIQUEMENT VENDU PAR LE CAISSIER EN COURS
            Query = "SELECT DISTINCT FUSIONNEE As 'SOUS FAMILLE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') AND CODE_UTILISATEUR_CREA=@CODE_CAISSIER ORDER BY FUSIONNEE ASC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '2- LISTE DES VENTES
    Public Function ListeDesArticlesVendus(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE AS ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL'  FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') AND CODE_UTILISATEUR_CREA = @CODE_UTILISATEUR"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesArticlesVendusJournalier(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE AS ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL'  FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesArticlesVendusInventaireMagasin(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String, ByVal CODE_MAGASIN As String) As DataTable

        Dim Query As String = ""
        ', LIBELLE_FACTURE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', FUSIONNEE 
        If Not Trim(CODE_UTILISATEUR) = "" Then
            'Query = "SELECT DISTINCT Trim(CODE_ARTICLE), PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND FUSIONNEE NOT IN ('HEBERGEMENT','') ORDER BY DATE_FACTURE DESC"

            Query = "SELECT DISTINCT CODE_ARTICLE FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_MAGASIN=@CODE_MAGASIN AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY LIBELLE_FACTURE ASC"

        Else
            'Query = "SELECT DISTINCT CODE_ARTICLE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','') ORDER BY DATE_FACTURE DESC"
            Query = "SELECT DISTINCT CODE_ARTICLE FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_MAGASIN=@CODE_MAGASIN  AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS') ORDER BY LIBELLE_FACTURE ASC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function


    Public Function ListeDesArticlesVendusInventaire(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String) As DataTable

        Dim Query As String = ""
        ', LIBELLE_FACTURE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', FUSIONNEE 
        If Not Trim(CODE_UTILISATEUR) = "" Then
            'Query = "SELECT DISTINCT Trim(CODE_ARTICLE), PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND FUSIONNEE NOT IN ('HEBERGEMENT','') ORDER BY DATE_FACTURE DESC"

            Query = "SELECT DISTINCT CODE_ARTICLE FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY LIBELLE_FACTURE ASC"

        Else
            'Query = "SELECT DISTINCT CODE_ARTICLE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','') ORDER BY DATE_FACTURE DESC"
            Query = "SELECT DISTINCT CODE_ARTICLE FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY LIBELLE_FACTURE ASC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesPointsDeVente(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String) As DataTable

        Dim Query As String = ""

        If Not Trim(CODE_UTILISATEUR) = "" Then

            Query = "SELECT DISTINCT CODE_MAGASIN FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR ORDER BY LIBELLE_FACTURE ASC"
        Else
            Query = "SELECT DISTINCT CODE_MAGASIN FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY LIBELLE_FACTURE ASC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        'command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function


    Public Function ListeDesArticlesVendusInventairePArFAmilleMagasin(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String, ByVal CategoriePArent As String, ByVal CODE_MAGASIN As String) As DataTable

        Dim Query As String = ""

        If Not Trim(CODE_UTILISATEUR) = "" Then
            'Query = "SELECT DISTINCT CODE_ARTICLE, LIBELLE_FACTURE,PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND AND FUSIONNEE=@CATEGORIE_PARENT ORDER BY DATE_FACTURE DESC"
            Query = "SELECT DISTINCT CODE_ARTICLE FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND CODE_MAGASIN=@CODE_MAGASIN AND FUSIONNEE=@CATEGORIE_PARENT ORDER BY LIBELLE_FACTURE ASC"
        Else
            Query = "SELECT DISTINCT CODE_ARTICLE FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_MAGASIN=@CODE_MAGASIN AND FUSIONNEE=@CATEGORIE_PARENT ORDER BY LIBELLE_FACTURE ASC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent
        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesArticlesVendusInventairePArFAmille(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String, ByVal CategoriePArent As String) As DataTable

        Dim Query As String = ""

        If Not Trim(CODE_UTILISATEUR) = "" Then
            'Query = "SELECT DISTINCT CODE_ARTICLE, LIBELLE_FACTURE,PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND AND FUSIONNEE=@CATEGORIE_PARENT ORDER BY DATE_FACTURE DESC"
            Query = "SELECT DISTINCT CODE_ARTICLE FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND FUSIONNEE=@CATEGORIE_PARENT ORDER BY LIBELLE_FACTURE ASC"
        Else
            Query = "SELECT DISTINCT CODE_ARTICLE FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE=@CATEGORIE_PARENT ORDER BY LIBELLE_FACTURE ASC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesArticlesVendusInventaireIndividuelParFamilleMagasin(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String, ByVal CODE_ARTICLE As String, ByVal CATEGORIE_PARENT As String, ByVal CODE_MAGASIN As String) As DataTable

        Dim Query As String = ""

        If Not Trim(CODE_UTILISATEUR) = "" Then
            Query = "SELECT LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND CODE_ARTICLE=@CODE_ARTICLE AND FUSIONNEE=@CATEGORIE_PARENT AND CODE_MAGASIN=@CODE_MAGASIN AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"
        Else
            Query = "SELECT LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_MAGASIN=@CODE_MAGASIN AND CODE_ARTICLE=@CODE_ARTICLE AND FUSIONNEE=@CATEGORIE_PARENT AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CATEGORIE_PARENT
        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesArticlesVendusInventaireIndividuelParFamille(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String, ByVal CODE_ARTICLE As String, ByVal CATEGORIE_PARENT As String) As DataTable

        Dim Query As String = ""

        If Not Trim(CODE_UTILISATEUR) = "" Then
            Query = "SELECT LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND CODE_ARTICLE=@CODE_ARTICLE AND FUSIONNEE=@CATEGORIE_PARENT AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"
        Else
            Query = "SELECT LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_ARTICLE=@CODE_ARTICLE AND FUSIONNEE=@CATEGORIE_PARENT AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CATEGORIE_PARENT

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesArticlesVendusInventaireIndividuelMagasin(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String, ByVal CODE_ARTICLE As String, ByVal CODE_MAGASIN As String) As DataTable

        Dim Query As String = ""

        If Not Trim(CODE_UTILISATEUR) = "" Then
            Query = "SELECT LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND CODE_MAGASIN=@CODE_MAGASIN AND CODE_ARTICLE=@CODE_ARTICLE AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"
        Else
            Query = "SELECT LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL' FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_MAGASIN=@CODE_MAGASIN AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_ARTICLE=@CODE_ARTICLE AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function ListeDesArticlesVendusInventaireIndividuel(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_UTILISATEUR As String, ByVal CODE_ARTICLE As String) As DataTable

        Dim Query As String = ""

        If Not Trim(CODE_UTILISATEUR) = "" Then
            Query = "SELECT LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL', CODE_LOT FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR AND CODE_ARTICLE=@CODE_ARTICLE AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"
        Else
            Query = "SELECT LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL', CODE_LOT FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_ARTICLE=@CODE_ARTICLE AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY DATE_FACTURE DESC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '2- LISTE DES VENTES
    Public Function ListeDesArticlesVendusPeriodique(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE AS ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL'  FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE NOT IN ('HEBERGEMENT','','TAXE DE SEJOURS','HALL RENTING','ACCOMMODATION','TOURIST TAX','LOCATION SALLE') ORDER BY LIBELLE_FACTURE ASC"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '3- LISTE DES VENTES GRATUITES
    Public Function ListeDesArticlesVendusGratuitementParFamilleMagasin(ByVal CategoriePArent As String, ByVal DateDebut As Date, ByVal DateFin As Date, CODE_MAGASIN As String, ByVal CODE_UTILISATEUR As String) As DataTable

        Dim Query As String

        If Trim(CODE_UTILISATEUR) = "" Then

            Query = "SELECT CODE_ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL'  FROM ligne_facture_gratuite WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_MAGASIN=@CODE_MAGASIN AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE=@CATEGORIE_PARENT AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR"

        Else

            Query = "SELECT CODE_ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL'  FROM ligne_facture_gratuite WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_MAGASIN=@CODE_MAGASIN AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE=@CATEGORIE_PARENT"

        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent
        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '3- LISTE DES VENTES GRATUITES PAR FAMILLE
    Public Function ListeDesArticlesVendusGratuitementParFamille(ByVal CategoriePArent As String, ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL'  FROM ligne_facture_gratuite WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE=@CATEGORIE_PARENT"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '4- LISTE DES VENTES GRATUITES PAR FAMILLE POUR UN CAISSIER
    Public Function ListeDesArticlesVendusGratuitementParFamilleCaissier(ByVal CategoriePArent As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_CAISSIER As String) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL'  FROM ligne_facture_gratuite WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE=@CATEGORIE_PARENT AND CODE_UTILISATEUR_CREA=@CODE_CAISSIER"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent
        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '3- LISTE DES VENTES GRATUITES
    Public Function ListeDesArticlesVendusGratuitementParFamilleCaissierParRubrique(ByVal CategoriePArent As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_CAISSIER As String, ByVal ETAT_FACTURE As Integer) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL'  
        FROM ligne_facture_gratuite WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "'
        AND FUSIONNEE=@CATEGORIE_PARENT AND CODE_UTILISATEUR_CREA=@CODE_CAISSIER AND ligne_facture_bloc_note.ETAT_FACTURE=@ETAT_FACTURE AND ligne_facture_bloc_note.NUMERO_BLOC_NOTE = ligne_facture.NUMERO_BLOC_NOTE"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent
        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function


    '4- LISTE DES VENTES SUIVANT LA CATEGORIE PARENTS
    Public Function ListeDesArticlesVendusParFamille(ByVal CategoriePArent As String, ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE AS ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS 'MONTANT TOTAL'  FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE=@CATEGORIE_PARENT"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '5- LISTE DES VENTES SUIVANT LA CATEGORIE PARENTS
    Public Function ListeDesArticlesVendusParFamilleDunCaissier(ByVal CategoriePArent As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_CAISSIER As String) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE AS ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS 'MONTANT TOTAL'  FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND FUSIONNEE=@CATEGORIE_PARENT AND CODE_UTILISATEUR_CREA = @CODE_CAISSIER"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent
        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '6- LISTE DES VENDEURS SUR UNE PERIODE
    Public Function ListeDesVendeurs(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim Query As String = "SELECT DISTINCT CODE_UTILISATEUR_CREA AS CAISSIER FROM ligne_facture WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_AGENCE=@CODE_AGENCE"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '7- LISTE DES VENTES SUR UNE PERIODE PAR RUBRIQUE COMPTOIR-EN CHAMBRE-OFFRES-DEBITEURS-EN SALLE

    Public Function ListeDesArticlesVendusParFamilleDunCaissierParRubrique(ByVal CategoriePArent As String, ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_CAISSIER As String, ByVal ETAT_FACTURE As Integer) As DataTable

        Dim Query As String = ""

        If ETAT_FACTURE = 4 Then
            Query = "SELECT CODE_ARTICLE AS ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS 'MONTANT TOTAL'  FROM ligne_facture
            WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "'
            AND FUSIONNEE=@CATEGORIE_PARENT AND CODE_UTILISATEUR_CREA = @CODE_CAISSIER 
            AND TYPE=@TYPE"
        Else
            Query = "SELECT CODE_ARTICLE AS ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS 'MONTANT TOTAL'  FROM ligne_facture, ligne_facture_bloc_note
            WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "'
            AND FUSIONNEE=@CATEGORIE_PARENT AND CODE_UTILISATEUR_CREA = @CODE_CAISSIER 
            AND ligne_facture_bloc_note.ETAT_FACTURE=@ETAT_FACTURE AND ligne_facture_bloc_note.NUMERO_BLOC_NOTE = ligne_facture.NUMERO_BLOC_NOTE"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent
        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "salle"

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Shared Function ListeDesArticlesVendusGratuitement(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim Query As String = "SELECT CODE_ARTICLE, LIBELLE_FACTURE AS 'LIBELLE ARTICLE', ligne_facture_gratuite.QUANTITE, PRIX_UNITAIRE_TTC AS 'PRIX UNITAIRE', MONTANT_TTC AS'MONTANT TOTAL', NOM_UTILISATEUR, NUMERO_BLOC_NOTE
        FROM ligne_facture_gratuite, utilisateurs WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' 
        AND ligne_facture_gratuite.CODE_UTILISATEUR_CREA = utilisateurs.CODE_UTILISATEUR"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    'CHANGEMENT DES LIBELLES DES ARTICLES LORS DE TRANSFERT: COMPTOIR -> EN CHAMBRE; COMPTOIR -> COMPTE ; COMPTOIR->INDIVIDU; EN CHAMBRE -> EN CHAMBRE
    'EN RELATION AVEC UN NUMERO DE BLOC_NOTE

    Public Sub changementLibelleArticle(ByVal CODE_ARTICLE As String, ByVal NUMERO_BLOC_NOTE_OU_RESERVATION As String, ByVal SUFFIX_LIBELLE_ARTICLE As String, ByVal ID_LIGNE_FACTURE As Integer)

        'CHANGEMENT DE DEPUIS LE BAR

        'Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim ligne_bloc_note As DataTable = Functions.GetAllElementsOnTwoConditions(NUMERO_BLOC_NOTE_OU_RESERVATION, "ligne_facture", "NUMERO_BLOC_NOTE", CODE_ARTICLE, "CODE_ARTICLE")

        '1- COMPTOIR VERS CHAMBRE
        If ligne_bloc_note.Rows.Count > 0 Then

            For i = 0 To ligne_bloc_note.Rows.Count - 1

                Dim updateQuery As String = "UPDATE `ligne_facture` SET LIBELLE_FACTURE=@LIBELLE_FACTURE WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE AND CODE_ARTICLE=@CODE_ARTICLE AND ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"

                Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                Dim NEW_NUMERO_BLOC_NOTE As String = ""

                command.Parameters.Add("@LIBELLE_FACTURE", MySqlDbType.VarChar).Value = ligne_bloc_note.Rows(i)("LIBELLE_FACTURE") & " [" & SUFFIX_LIBELLE_ARTICLE & "]"
                command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = ligne_bloc_note.Rows(i)("CODE_ARTICLE")
                command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE_OU_RESERVATION
                command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = ID_LIGNE_FACTURE

                command.ExecuteNonQuery()

            Next

        Else

            '2- CHAMBRE VERS CHAMBRE
            'CHANGEMENT DE DEPUIS LA RECEPTION
            Dim ligne_reservation As DataTable = Functions.GetAllElementsOnTwoConditions(NUMERO_BLOC_NOTE_OU_RESERVATION, "ligne_facture", "CODE_RESERVATION", CODE_ARTICLE, "CODE_ARTICLE")

            Dim DateDeSituation As Date = GlobalVariable.DateDeTravail

            If ligne_reservation.Rows.Count > 0 Then

                For i = 0 To ligne_reservation.Rows.Count - 1

                    'ActivationForm.Show()
                    'ActivationForm.TopMost = True
                    'ActivationForm.GunaTextBoxMessage.Text = CODE_ARTICLE & " " & SUFFIX_LIBELLE_ARTICLE & " " & NUMERO_BLOC_NOTE_OU_RESERVATION & " " & ligne_reservation.Rows(i)("LIBELLE_FACTURE") & SUFFIX_LIBELLE_ARTICLE

                    'Dim updateQuery As String = "UPDATE `ligne_facture` SET LIBELLE_FACTURE=@LIBELLE_FACTURE WHERE CODE_RESERVATION=@CODE_RESERVATION AND CODE_ARTICLE=@CODE_ARTICLE AND CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT =@ETAT"

                    Dim updateQuery As String = "UPDATE `ligne_facture` SET LIBELLE_FACTURE=@LIBELLE_FACTURE WHERE CODE_RESERVATION=@CODE_RESERVATION AND CODE_ARTICLE=@CODE_ARTICLE AND ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"

                    Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                    Dim NEW_NUMERO_BLOC_NOTE As String = ""

                    command.Parameters.Add("@LIBELLE_FACTURE", MySqlDbType.VarChar).Value = ligne_reservation.Rows(i)("LIBELLE_FACTURE") & SUFFIX_LIBELLE_ARTICLE
                    command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = Trim(ligne_reservation.Rows(i)("CODE_ARTICLE"))
                    command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = Trim(NUMERO_BLOC_NOTE_OU_RESERVATION)
                    command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = ID_LIGNE_FACTURE
                    command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0

                    command.ExecuteNonQuery()

                Next

            End If

        End If

    End Sub

    'DEPLACEMENT DES CHARGES DE LA MAINCOURANTE AUTRES POUR LA MAINOURANTE JOURNALIERE
    Public Sub deplacementDesLigneDeMainCouranteAMainCourante(ByVal ID_LIGNE_FACTURE As Integer, ByVal CODE_ARTICLE As String, ByVal CODE_MAIN_COURANTE_JOURNALIERE_1 As String, ByVal CODE_MAIN_COURANTE_JOURNALIERE_2 As String, ByVal TABLE_1 As String, ByVal TABLE_2 As String)

        Dim infoligneArticle As DataTable = Functions.getElementByCode(ID_LIGNE_FACTURE, "ligne_facture", "ID_LIGNE_FACTURE")

        If infoligneArticle.Rows.Count > 0 Then

            Dim mainsCourante As New MainCourantes()

            Dim FIELD As String = ""
            Dim NATURE As String = ""
            Dim FAMILLE_ARTICLE As String = ""
            Dim FUSIONNEE As String = infoligneArticle.Rows(0)("FUSIONNEE")
            Dim HEURE_FACTURE As DateTime = infoligneArticle.Rows(0)("HEURE_FACTURE")

            Dim FIELDVALUE As Double = infoligneArticle.Rows(0)("MONTANT_TTC")

            Dim articleInfo As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

            If articleInfo.Rows.Count > 0 Then
                FAMILLE_ARTICLE = articleInfo.Rows(0)("CODE_FAMILLE")
            End If
            '---------------------------------------------------------------------

            If FAMILLE_ARTICLE = "BOISSONS" Then
                'TRAITEMENT DES BOISSONS
                FIELD = "BAR"

                mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_1, TABLE_1, FIELD, FIELDVALUE * -1)

                mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_2, FIELD, FIELDVALUE)

                If FUSIONNEE = "EAU MINERAL" Then
                    FIELD = "CAFE"
                    mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_1, TABLE_1, FIELD, FIELDVALUE * -1)

                    mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_2, FIELD, FIELDVALUE)
                Else
                    If infoligneArticle.Rows(0)("VALEUR_CONSO") > 0 Then
                        FIELD = "DIVERS" 'CONSOMMATION
                        mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_1, TABLE_1, FIELD, FIELDVALUE * -1)

                        mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_2, FIELD, FIELDVALUE)
                    Else
                        FIELD = "CAVE"
                        mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_1, TABLE_1, FIELD, FIELDVALUE * -1)

                        mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_2, FIELD, FIELDVALUE)
                    End If
                End If

            ElseIf FAMILLE_ARTICLE = "ALIMENTS(REPAS)" Then

                'ON EXCLU LES REPAS DE TYPE PETIT DEJEUENER DU CONTROLE DU TEMPS
                'If FUSIONNEE = "PETIT DEJEUNER" Then
                If FUSIONNEE = "PETIT DEJEUNER" Then
                    FIELD = "PDJ"
                Else

                    'TRAITEMENTS DES ALIMENTS DE TYPE DEJEUENER/DINER

                    '1- ON DOIT DETERMINER LA NATURE EN PASSANT L'HEURE DE VENTE DE L'ARTICLE
                    Dim momentDeVente As Date = CDate(HEURE_FACTURE).ToLongTimeString

                    NATURE = determintationDeLaNatureDuRePas(momentDeVente)

                    '2- DETERMINATION DU CHAMP A METTRE AJOUR DANS 

                    'If NATURE = "PETIT DEJEUNER" Then
                    'FIELD = "PDJ"

                    If NATURE = "DEJEUNER" Then
                        FIELD = "DEJEUNER"
                    ElseIf NATURE = "DINER" Then
                        FIELD = "DINER"
                    Else
                        FIELD = "DEJEUNER"
                    End If

                End If

                mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_1, TABLE_1, FIELD, FIELDVALUE * -1)

                mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_2, FIELD, FIELDVALUE)

            Else

                FIELD = "REPORT_VEILLE"

                If GlobalVariable.actualLanguageValue = 1 Then

                    If Trim(FUSIONNEE).Equals("HEBERGEMENT") Then

                        'MISE A JOUR DE LA MAINCOURANTE DE RETRANCHEMENT
                        mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_1, TABLE_1, FIELD, FIELDVALUE * -1)

                        'MISE A JOUR DE LA MAINCOURANTE D'AJOUT
                        mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_2, FIELD, FIELDVALUE)

                    End If

                Else

                    If Trim(FUSIONNEE).Equals("ACCOMMODATION") Then

                        'MISE A JOUR DE LA MAINCOURANTE DE RETRANCHEMENT
                        mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_1, TABLE_1, FIELD, FIELDVALUE * -1)

                        'MISE A JOUR DE LA MAINCOURANTE D'AJOUT
                        mainsCourante.updateMainCouranteJournaliereEtAutresApresTransfert(CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_2, FIELD, FIELDVALUE)

                    End If

                End If

            End If
            '---------------------------------------------------------------------

        End If

    End Sub

    'DETERMINER LE CODE DES MAINCOURANTES A MANIPULER

    Public Function codeDesMainsCourantesAMettreAJours(ByVal ETAT_MAIN_COURANTE As Integer, ByVal DATE_MAIN_COURANTE As Date, ByVal TABLE_NAME As String, ByVal Optional NUM_RESERVATION As String = "") As DataTable

        Dim getUserQuery As String = ""

        If Not Trim(NUM_RESERVATION) = "" Then
            getUserQuery = "SELECT CODE_MAIN_COURANTE_JOURNALIERE FROM " & TABLE_NAME & " WHERE DATE_MAIN_COURANTE >= '" & DATE_MAIN_COURANTE.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE <='" & DATE_MAIN_COURANTE.ToString("yyyy-MM-dd") & "' AND ETAT_MAIN_COURANTE=@ETAT_MAIN_COURANTE AND NUM_RESERVATION=@NUM_RESERVATION"
        Else
            getUserQuery = "SELECT CODE_MAIN_COURANTE_JOURNALIERE FROM " & TABLE_NAME & " WHERE DATE_MAIN_COURANTE >= '" & DATE_MAIN_COURANTE.ToString("yyyy-MM-dd") & "' AND DATE_MAIN_COURANTE <='" & DATE_MAIN_COURANTE.ToString("yyyy-MM-dd") & "' AND ETAT_MAIN_COURANTE=@ETAT_MAIN_COURANTE"
        End If

        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Command.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int64).Value = ETAT_MAIN_COURANTE
        Command.Parameters.Add("@NUM_RESERVATION", MySqlDbType.VarChar).Value = NUM_RESERVATION

        Dim adapter As New MySqlDataAdapter()
        Dim table As New DataTable()

        adapter.SelectCommand = Command
        adapter.Fill(table)

        Return table

    End Function

    'TRANSFERT DES LIGNES DE CHARGE DU BAR (COMPTOIR) VERS LES EN CHAMBRES

    Public Sub transfertDeLigneChargeDuComptoireVersEnChambre(ByVal CODE_ARTICLE As String, ByVal NUMERO_BLOC_NOTE As String, ByVal CODE_CHAMBRE As String, ByVal CODE_RESERVATION As String, ByVal NOM_CLIENT As String, ByVal ID_LIGNE_FACTURE As Integer)

        Dim SUFFIX_LIBELLE_ARTICLE As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            SUFFIX_LIBELLE_ARTICLE = "COMPTOIR VERS / " & NOM_CLIENT & " " & CODE_CHAMBRE & ""
        Else
            SUFFIX_LIBELLE_ARTICLE = "WALK IN TO / " & NOM_CLIENT & " " & CODE_CHAMBRE & ""
        End If

        changementLibelleArticle(CODE_ARTICLE, NUMERO_BLOC_NOTE, SUFFIX_LIBELLE_ARTICLE, ID_LIGNE_FACTURE)

        Dim updateQuery As String = "UPDATE `ligne_facture` SET NUMERO_BLOC_NOTE=@NEW_NUMERO_BLOC_NOTE, CODE_MODE_PAIEMENT=@NOM_CLIENT, CODE_RESERVATION=@CODE_RESERVATION, CODE_CHAMBRE=@CODE_CHAMBRE 
        WHERE CODE_ARTICLE=@CODE_ARTICLE AND NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE AND ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        Dim NEW_NUMERO_BLOC_NOTE As String = ""

        command.Parameters.Add("@NEW_NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NEW_NUMERO_BLOC_NOTE 'EST UNE CHAINE VIDE
        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.VarChar).Value = NOM_CLIENT
        command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = ID_LIGNE_FACTURE

        command.ExecuteNonQuery()

        '----------------------------------- TRAITEMENT DU BASCULEMENT -----------------------------------------------------------------------

        Dim CODE_MAIN_COURANTE_JOURNALIERE_1 As String = "" 'CODE_MAIN_COURANTE DE RETRANCHEMENT
        Dim CODE_MAIN_COURANTE_JOURNALIERE_2 As String = "" 'CODE_MAIN_COURANTE D'AJOUT

        Dim TABLE_1 As String = "main_courante_autres" 'TABLE DE RETRANCHEMENT
        Dim ETAT_MAIN_COURANTE As Integer = 0
        Dim DATE_MAIN_COURANTE As Date = GlobalVariable.DateDeTravail

        'POUR LA MAINCOURANTE COMPTOIR LA DATE EST SUFFIASANTE POUR OBTENIR LE CODE
        Dim DATA_TABLE_1 As DataTable = codeDesMainsCourantesAMettreAJours(ETAT_MAIN_COURANTE, DATE_MAIN_COURANTE, TABLE_1)

        If DATA_TABLE_1.Rows.Count > 0 Then

            CODE_MAIN_COURANTE_JOURNALIERE_1 = DATA_TABLE_1.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

            'POUR LA MAINCOURANTE JOURNALIERE EN PLUS DE LA DATE IL FAUT LE CODE DE LA RESA
            Dim TABLE_2 As String = "main_courante_journaliere" ' TABLE D'AJOUT
            Dim DATA_TABLE_2 As DataTable = codeDesMainsCourantesAMettreAJours(ETAT_MAIN_COURANTE, DATE_MAIN_COURANTE, TABLE_2, CODE_RESERVATION)

            If DATA_TABLE_2.Rows.Count > 0 Then

                CODE_MAIN_COURANTE_JOURNALIERE_2 = DATA_TABLE_2.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

                '--------------------------------------- BASCULEMENT ENTRE NMAINS COURANTES ----------------------------------------------------
                deplacementDesLigneDeMainCouranteAMainCourante(ID_LIGNE_FACTURE, CODE_ARTICLE, CODE_MAIN_COURANTE_JOURNALIERE_1, CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_1, TABLE_2)

            End If

        End If

        '---------------------------------------------------------------------------------------------------------------------------------

    End Sub

    'TRANSFERT DE RESA A RESA
    Public Sub transfertDeLigneChargeEnChambreVersEnChambre(ByVal CODE_ARTICLE As String, ByVal CODE_CHAMBRE As String, ByVal NEW_CODE_RESERVATION As String, ByVal OLD_CODE_RESERVATION As String, ByVal CODE_FACTURE As String, ByVal NOM_CLIENT As String, ByVal ID_LIGNE_FACTURE As Integer)

        Dim SUFFIX_LIBELLE_ARTICLE As String = " VERS " & NOM_CLIENT & "/" & CODE_CHAMBRE & ""

        changementLibelleArticle(CODE_ARTICLE, OLD_CODE_RESERVATION, SUFFIX_LIBELLE_ARTICLE, ID_LIGNE_FACTURE)

        Dim updateQuery As String = "UPDATE `ligne_facture` Set CODE_RESERVATION=@NEW_CODE_RESERVATION, CODE_CHAMBRE=@CODE_CHAMBRE,CODE_MODE_PAIEMENT =@NOM_CLIENT 
        WHERE CODE_ARTICLE=@CODE_ARTICLE AND CODE_RESERVATION=@OLD_CODE_RESERVATION AND CODE_FACTURE=@CODE_FACTURE AND ID_LIGNE_FACTURE=@ID_LIGNE_FACTURE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@OLD_CODE_RESERVATION", MySqlDbType.VarChar).Value = OLD_CODE_RESERVATION
        command.Parameters.Add("@NEW_CODE_RESERVATION", MySqlDbType.VarChar).Value = NEW_CODE_RESERVATION
        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.VarChar).Value = NOM_CLIENT
        command.Parameters.Add("@ID_LIGNE_FACTURE", MySqlDbType.Int64).Value = ID_LIGNE_FACTURE

        command.ExecuteNonQuery()

        '----------------------------------- TRAITEMENT DU BASCULEMENT -----------------------------------------------------------------------

        Dim CODE_MAIN_COURANTE_JOURNALIERE_1 As String = "" 'CODE_MAIN_COURANTE DE RETRANCHEMENT
        Dim CODE_MAIN_COURANTE_JOURNALIERE_2 As String = "" 'CODE_MAIN_COURANTE D'AJOUT

        Dim TABLE_1 As String = "main_courante_journaliere" 'TABLE DE RETRANCHEMENT
        Dim ETAT_MAIN_COURANTE As Integer = 0
        Dim DATE_MAIN_COURANTE As Date = GlobalVariable.DateDeTravail

        'POUR LA MAINCOURANTE JOURNALIERE EN PLUS DE LA DATE IL FAUT LE CODE DE LA RESA
        Dim DATA_TABLE_1 As DataTable = codeDesMainsCourantesAMettreAJours(ETAT_MAIN_COURANTE, DATE_MAIN_COURANTE, TABLE_1, OLD_CODE_RESERVATION)

        If DATA_TABLE_1.Rows.Count > 0 Then
            CODE_MAIN_COURANTE_JOURNALIERE_1 = DATA_TABLE_1.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

            'POUR LA MAINCOURANTE JOURNALIERE EN PLUS DE LA DATE IL FAUT LE CODE DE LA RESA
            Dim TABLE_2 As String = "main_courante_journaliere" ' TABLE D'AJOUT
            Dim DATA_TABLE_2 As DataTable = codeDesMainsCourantesAMettreAJours(ETAT_MAIN_COURANTE, DATE_MAIN_COURANTE, TABLE_2, NEW_CODE_RESERVATION)

            If DATA_TABLE_2.Rows.Count > 0 Then

                CODE_MAIN_COURANTE_JOURNALIERE_2 = DATA_TABLE_2.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")

                '------------------------------------------------------ BASCULEMENT ENTRE MAINS COURANTES ------------------------------------------------------------------
                'ON NE MET PAS AJOURS LES MAINCOURANTES A FIN QUE LES CONSOMMATIONS DE CHACUN FIGURE SUR LA MAIN COURANTE EN TOUT INSTANT

                'CETTE FONCTION CI-DESSOUS EST NECESSAIRE POUR DEPLACER LES CHARGES DE CONSOMMATION D'UNE RESERVATION AUNE AUTRE
                'deplacementDesLigneDeMainCouranteAMainCourante(ID_LIGNE_FACTURE, CODE_ARTICLE, CODE_MAIN_COURANTE_JOURNALIERE_1, CODE_MAIN_COURANTE_JOURNALIERE_2, TABLE_1, TABLE_2)

            End If

        End If

        '---------------------------------------------------------------------------------------------------------------------------------

    End Sub

    'MISE A JOURS DE LA SITUATION DU CLIENT APRES ANNULATION DE CHARGE 

    Public Sub miseAjoursApresAnnulationDeChargeDepuisLaSituationDuCLient(ByVal ID_LIGNE_FACTURE As Integer)

        Dim CODE_RESERVATION As String = ""

        Dim ligneFactureTempContent As New DataTable()

        Dim mainsCourante As New MainCourantes()

        ligneFactureTempContent = Functions.getElementByCode(ID_LIGNE_FACTURE, "ligne_facture", "ID_LIGNE_FACTURE")

        Dim CODE_ARTICLE As String = ""
        Dim NATURE As String = ""

        Dim PRIX_VENTE As Double = 0

        If ligneFactureTempContent.Rows.Count > 0 Then

            For i = 0 To ligneFactureTempContent.Rows.Count - 1

                Dim CODE_FACTURE As String = ligneFactureTempContent.Rows(i)("CODE_FACTURE")
                CODE_RESERVATION = ligneFactureTempContent.Rows(i)("CODE_RESERVATION")
                Dim CODE_MOUVEMENT As String = ligneFactureTempContent.Rows(i)("CODE_MOUVEMENT")
                Dim CODE_CHAMBRE As String = ligneFactureTempContent.Rows(i)("CODE_CHAMBRE")
                Dim CODE_MODE_PAIEMENT As String = ligneFactureTempContent.Rows(i)("CODE_MODE_PAIEMENT")
                Dim NUMERO_PIECE As String = ligneFactureTempContent.Rows(i)("NUMERO_PIECE")
                Dim POINT_DE_VENTE As String = ligneFactureTempContent.Rows(i)("TYPE_LIGNE_FACTURE")
                CODE_ARTICLE = ligneFactureTempContent.Rows(i)("CODE_ARTICLE")

                Dim LIBELLE_FACTURE As String = ligneFactureTempContent.Rows(i)("LIBELLE_FACTURE") & " [" & CODE_CHAMBRE & "]"

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                Dim NOMBRE_DE_PORTION As Double = 0

                '-------------------------

                Dim CONTENANCE As Double = 0

                Dim articleInfo As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                Dim reduction As Boolean = False

                'ON DETERMINE SI LA LIGNE EST REDUCTION OU PAS

                If Not articleInfo.Rows.Count > 0 Then

                    CODE_ARTICLE = ligneFactureTempContent.Rows(i)("NUMERO_SERIE_DEBUT")
                    articleInfo = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                    reduction = True

                End If

                Dim unite As DataTable
                '-----------------------
                Dim ficheTechnique As DataTable

                Dim NOM_ARTICLE As String = ""

                Dim FUSIONNEE As String = ligneFactureTempContent.Rows(i)("FUSIONNEE")
                Dim PRIX_UNITAIRE_TTC As Double = ligneFactureTempContent.Rows(i)("PRIX_UNITAIRE_TTC")
                PRIX_VENTE = ligneFactureTempContent.Rows(i)("PRIX_UNITAIRE_TTC")
                Dim MONTANT_TTC As Double = ligneFactureTempContent.Rows(i)("MONTANT_TTC")
                Dim HEURE_FACTURE As DateTime = ligneFactureTempContent.Rows(i)("HEURE_FACTURE")

                Dim FAMILLE_ARTICLE As String = ""

                If articleInfo.Rows.Count > 0 Then

                    '----------------------- END GESTION DU REMPLISSAGE DE LA MAIN COURANTE JOURNALIERE -------------------------------

                    Dim TABLE As String = "main_courante_journaliere"
                    Dim CODE_MAIN_COURANTE_JOURNALIERE As String = GlobalVariable.codeMainCouranteJournaliereToUpdate

                    FAMILLE_ARTICLE = articleInfo.Rows(0)("CODE_FAMILLE")

                    Dim FIELDVALUE As Double = MONTANT_TTC
                    Dim FIELD As String = ""

                    If Trim(FAMILLE_ARTICLE) = "BOISSONS" Then
                        'TRAITEMENT DES BOISSONS
                        FIELD = "BAR"
                        mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                        If FUSIONNEE = "EAU MINERAL" Then
                            FIELD = "CAFE"
                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                        Else
                            If ligneFactureTempContent.Rows(i)("VALEUR_CONSO") > 0 Then
                                FIELD = "DIVERS" 'CONSOMMATION
                                mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                            Else
                                FIELD = "CAVE"
                                mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                            End If
                        End If

                    ElseIf Trim(FAMILLE_ARTICLE) = "ALIMENTS(REPAS)" Then

                        'ON EXCLU LES REPAS DE TYPE PETIT DEJEUENER DU CONTROLE DU TEMPS
                        'If FUSIONNEE = "PETIT DEJEUNER" Then
                        If FUSIONNEE = "PETIT DEJEUNER" Then
                            FIELD = "PDJ"
                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                        Else

                            'TRAITEMENTS DES ALIMENTS DE TYPE DEJEUENER/DINER

                            '1- ON DOIT DETERMINER LA NATURE EN PASSANT L'HEURE DE VENTE DE L'ARTICLE
                            Dim momentDeVente As Date = CDate(HEURE_FACTURE).ToLongTimeString

                            NATURE = Trim(determintationDeLaNatureDuRePas(momentDeVente))

                            '2- DETERMINATION DU CHAMP A METTRE AJOUR DANS 

                            If Trim(NATURE).Equals("DEJEUNER") Then
                                FIELD = "DEJEUNER"
                            ElseIf Trim(NATURE).Equals("DINER") Then
                                FIELD = "DINER"
                            Else
                                FIELD = "DEJEUNER"
                            End If

                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                        End If

                    Else
                        FUSIONNEE = ligneFactureTempContent.Rows(i)("FUSIONNEE")
                    End If

                    'Dim PDJ As Double = 0 'PETITE DEJEUNER
                    'Dim DEJEUNER As Double = 0 'DEJEUNER
                    'Dim DINER As Double = 0 'DINER
                    'Dim CAFE As Double = 0 'EAU MINERAL
                    'Dim BAR As Double = 0 'FAMILLE ARTICLE = BOISSONS
                    'Dim CAVE As Double = 0 '
                    'Dim DIVERS As Double = 0 'CONSOMMATION

                    '--------------------------------------------------------------------------------------------------------------

                    NOM_ARTICLE = articleInfo.Rows(0)("DESIGNATION_FR")

                End If

                Dim ANNULATION As Integer = 1

                'MISE A JOURS DE LA MAINCOURANTE PAR APPORT A CHAQUE POINT DE VENTE
                miseAjourDeLaMainCouranteParApportAPlusieursPointDeVente(NOM_ARTICLE, POINT_DE_VENTE, MONTANT_TTC, ANNULATION)

                If FAMILLE_ARTICLE = "ALIMENTS(REPAS)" Then
                    If Not FUSIONNEE = "PETIT DEJEUNER" Then
                        miseAjoursSousFamilleArticleDansLigneFacture(CODE_FACTURE, NATURE, CODE_ARTICLE)
                    End If
                End If

            Next

        Else

        End If


    End Sub

    'MISE A JOURS DE LA SITUATION DU CLIENT APRES ANNULATION DE CHARGE 

    Public Sub miseAjoursApresTransfertDeChargeDepuisLaSituationDuCLient(ByVal ID_LIGNE_FACTURE As Integer)

        Dim CODE_RESERVATION As String = ""

        Dim ligneFactureTempContent As New DataTable()

        Dim mainsCourante As New MainCourantes()

        ligneFactureTempContent = Functions.getElementByCode(ID_LIGNE_FACTURE, "ligne_facture", "ID_LIGNE_FACTURE")

        Dim CODE_ARTICLE As String = ""
        Dim NATURE As String = ""

        Dim PRIX_VENTE As Double = 0

        If ligneFactureTempContent.Rows.Count > 0 Then

            For i = 0 To ligneFactureTempContent.Rows.Count - 1

                Dim CODE_FACTURE As String = ligneFactureTempContent.Rows(i)("CODE_FACTURE")
                CODE_RESERVATION = ligneFactureTempContent.Rows(i)("CODE_RESERVATION")
                Dim CODE_MOUVEMENT As String = ligneFactureTempContent.Rows(i)("CODE_MOUVEMENT")
                Dim CODE_CHAMBRE As String = ligneFactureTempContent.Rows(i)("CODE_CHAMBRE")
                Dim CODE_MODE_PAIEMENT As String = ligneFactureTempContent.Rows(i)("CODE_MODE_PAIEMENT")
                Dim NUMERO_PIECE As String = ligneFactureTempContent.Rows(i)("NUMERO_PIECE")
                Dim POINT_DE_VENTE As String = ligneFactureTempContent.Rows(i)("TYPE_LIGNE_FACTURE")
                CODE_ARTICLE = ligneFactureTempContent.Rows(i)("CODE_ARTICLE")

                Dim LIBELLE_FACTURE As String = ligneFactureTempContent.Rows(i)("LIBELLE_FACTURE") & " [" & CODE_CHAMBRE & "]"

                Dim QUANTITE_AVANT_MOVEMENT As Double = 0
                Dim CMUP As Double = 0

                Dim NOMBRE_DE_PORTION As Double = 0

                '-------------------------

                Dim CONTENANCE As Double = 0

                Dim articleInfo As DataTable = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                Dim reduction As Boolean = False

                'ON DETERMINE SI LA LIGNE EST REDUCTION OU PAS

                If Not articleInfo.Rows.Count > 0 Then

                    CODE_ARTICLE = ligneFactureTempContent.Rows(i)("NUMERO_SERIE_DEBUT")
                    articleInfo = Functions.getElementByCode(CODE_ARTICLE, "article", "CODE_ARTICLE")

                    reduction = True

                End If

                Dim unite As DataTable
                '-----------------------
                Dim ficheTechnique As DataTable

                Dim NOM_ARTICLE As String = ""

                Dim FUSIONNEE As String = ligneFactureTempContent.Rows(i)("FUSIONNEE")
                Dim PRIX_UNITAIRE_TTC As Double = ligneFactureTempContent.Rows(i)("PRIX_UNITAIRE_TTC")
                PRIX_VENTE = ligneFactureTempContent.Rows(i)("PRIX_UNITAIRE_TTC")
                Dim MONTANT_TTC As Double = ligneFactureTempContent.Rows(i)("MONTANT_TTC") * -1
                Dim HEURE_FACTURE As DateTime = ligneFactureTempContent.Rows(i)("HEURE_FACTURE")

                Dim FAMILLE_ARTICLE As String = ""

                If articleInfo.Rows.Count > 0 Then

                    '----------------------- END GESTION DU REMPLISSAGE DE LA MAIN COURANTE JOURNALIERE -------------------------------

                    Dim TABLE As String = "main_courante_journaliere"
                    Dim CODE_MAIN_COURANTE_JOURNALIERE As String = GlobalVariable.codeMainCouranteJournaliereToUpdate

                    FAMILLE_ARTICLE = articleInfo.Rows(0)("CODE_FAMILLE")

                    Dim FIELDVALUE As Double = MONTANT_TTC
                    Dim FIELD As String = ""

                    If Trim(FAMILLE_ARTICLE) = "BOISSONS" Then
                        'TRAITEMENT DES BOISSONS
                        FIELD = "BAR"
                        mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                        If FUSIONNEE = "EAU MINERAL" Then
                            FIELD = "CAFE"
                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                        Else
                            If ligneFactureTempContent.Rows(i)("VALEUR_CONSO") > 0 Then
                                FIELD = "DIVERS" 'CONSOMMATION
                                mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                            Else
                                FIELD = "CAVE"
                                mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                            End If
                        End If

                    ElseIf Trim(FAMILLE_ARTICLE) = "ALIMENTS(REPAS)" Then

                        'ON EXCLU LES REPAS DE TYPE PETIT DEJEUENER DU CONTROLE DU TEMPS
                        'If FUSIONNEE = "PETIT DEJEUNER" Then
                        If FUSIONNEE = "PETIT DEJEUNER" Then
                            FIELD = "PDJ"
                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)
                        Else

                            'TRAITEMENTS DES ALIMENTS DE TYPE DEJEUENER/DINER

                            '1- ON DOIT DETERMINER LA NATURE EN PASSANT L'HEURE DE VENTE DE L'ARTICLE
                            Dim momentDeVente As Date = CDate(HEURE_FACTURE).ToLongTimeString

                            NATURE = Trim(determintationDeLaNatureDuRePas(momentDeVente))

                            '2- DETERMINATION DU CHAMP A METTRE AJOUR DANS 

                            If Trim(NATURE).Equals("DEJEUNER") Then
                                FIELD = "DEJEUNER"
                            ElseIf Trim(NATURE).Equals("DINER") Then
                                FIELD = "DINER"
                            Else
                                FIELD = "DEJEUNER"
                            End If

                            mainsCourante.updateMainCouranteJournaliereConsommationBarRestau(CODE_MAIN_COURANTE_JOURNALIERE, TABLE, FIELD, FIELDVALUE)

                        End If

                    Else
                        FUSIONNEE = ligneFactureTempContent.Rows(i)("FUSIONNEE")
                    End If

                    'Dim PDJ As Double = 0 'PETITE DEJEUNER
                    'Dim DEJEUNER As Double = 0 'DEJEUNER
                    'Dim DINER As Double = 0 'DINER
                    'Dim CAFE As Double = 0 'EAU MINERAL
                    'Dim BAR As Double = 0 'FAMILLE ARTICLE = BOISSONS
                    'Dim CAVE As Double = 0 '
                    'Dim DIVERS As Double = 0 'CONSOMMATION

                    '--------------------------------------------------------------------------------------------------------------

                    NOM_ARTICLE = articleInfo.Rows(0)("DESIGNATION_FR")

                End If

                Dim ANNULATION As Integer = 1

                'MISE A JOURS DE LA MAINCOURANTE PAR APPORT A CHAQUE POINT DE VENTE
                miseAjourDeLaMainCouranteParApportAPlusieursPointDeVente(NOM_ARTICLE, POINT_DE_VENTE, MONTANT_TTC, ANNULATION)

                If FAMILLE_ARTICLE = "ALIMENTS(REPAS)" Then
                    If Not FUSIONNEE = "PETIT DEJEUNER" Then
                        miseAjoursSousFamilleArticleDansLigneFacture(CODE_FACTURE, NATURE, CODE_ARTICLE)
                    End If
                End If

            Next

        Else

        End If

    End Sub

    'create a function to update the selected reservation
    Public Function insertGestionDesShifts(ByVal DATE_SHIFT As Date, ByVal INDEX_SHIFT As Integer, ByVal CODE_UTILISATEUR As String, ByVal CODE_MAGASIN As String, ByVal NOM_UTILISATEUR As String, ByVal HEURE_ARRIVEE As String, ByVal HEURE_DEPART As String, ByVal CHEMIN_DEBUT As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `gesion_des_shifts`(`DATE_SHIFT`, `INDEX_SHIFT`, `CODE_UTILISATEUR`, `NOM_UTILISATEUR`, `HEURE_ARRIVEE`, `HEURE_DEPART`, `CHEMIN_DEBUT`,`CODE_MAGASIN`) 
                                        VALUES (@DATE_SHIFT,@INDEX_SHIFT, @CODE_UTILISATEUR, @NOM_UTILISATEUR, @HEURE_ARRIVEE, @HEURE_DEPART, @CHEMIN_DEBUT, @CODE_MAGASIN)"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@DATE_SHIFT", MySqlDbType.Date).Value = DATE_SHIFT
        command.Parameters.Add("@INDEX_SHIFT", MySqlDbType.Int32).Value = INDEX_SHIFT
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@NOM_UTILISATEUR", MySqlDbType.VarChar).Value = NOM_UTILISATEUR
        command.Parameters.Add("@HEURE_ARRIVEE", MySqlDbType.VarChar).Value = HEURE_ARRIVEE
        command.Parameters.Add("@HEURE_DEPART", MySqlDbType.VarChar).Value = HEURE_DEPART
        command.Parameters.Add("@CHEMIN_DEBUT", MySqlDbType.VarChar).Value = CHEMIN_DEBUT

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

    Public Function updateHeureDepartGestionDesShifts(ByVal HEURE_DEPART As String, ByVal CHEMIN_FIN As String, ByVal CODE_UTILISATEUR As String, ByVal CODE_MAGASIN As String, ByVal DateDebut As Date) As Boolean

        Dim insertQuery As String = ""

        insertQuery = "UPDATE `gesion_des_shifts` SET `HEURE_DEPART`=@HEURE_DEPART, CHEMIN_FIN=@CHEMIN_FIN, DATE_DE_CONTROLE_FIN=@DATE_DE_CONTROLE_FIN
        WHERE CODE_UTILISATEUR = @CODE_UTILISATEUR AND CODE_MAGASIN=@CODE_MAGASIN AND DATE_SHIFT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SHIFT <='" & DateDebut.ToString("yyyy-MM-dd") & "'"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@HEURE_DEPART", MySqlDbType.VarChar).Value = HEURE_DEPART
        command.Parameters.Add("@DATE_DE_CONTROLE_FIN", MySqlDbType.DateTime).Value = Date.Now()
        command.Parameters.Add("@CHEMIN_FIN", MySqlDbType.VarChar).Value = CHEMIN_FIN
        command.Parameters.Add("@CODE_MAGASIN", MySqlDbType.VarChar).Value = CODE_MAGASIN
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function existenceDuShiftDunUtilisateur(ByVal CODE_UTILISATEUR As String, ByVal DATE_SHIFT As Date) As DataTable

        Dim DateDebut As Date = DATE_SHIFT

        Dim query As String = "SELECT * FROM gesion_des_shifts WHERE DATE_SHIFT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SHIFT <='" & DateDebut.ToString("yyyy-MM-dd") & "' AND CODE_UTILISATEUR=@CODE_UTILISATEUR"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function VenteNetParPointDeVente(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CategoriePArent As String) As Double

        Dim Query As String = ""

        Query = "SELECT * FROM ligne_facture WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND TYPE_LIGNE_FACTURE=@CATEGORIE_PARENT ORDER BY TYPE_LIGNE_FACTURE ASC"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@CATEGORIE_PARENT", MySqlDbType.VarChar).Value = CategoriePArent

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Dim montantTotal As Double = 0

        For i = 0 To table.Rows.Count - 1
            montantTotal += table.Rows(i)("MONTANT_TTC")
        Next

        Return montantTotal

    End Function


    Public Function VenteNetHeberment(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal TYPE_CHAMBRE As String, ByVal INCOM_GENERATED_CASHED_IN As Integer) As Double

        Dim Query As String = ""

        If INCOM_GENERATED_CASHED_IN = 0 Then 'CHIFFRES D'AFFAIRES

            Query = "SELECT MONTANT_TTC, TYPE_CHAMBRE FROM ligne_facture, reserve_conf 
            WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateDebut.ToString("yyyy-MM-dd") & "' 
            AND TYPE_CHAMBRE=@TYPE_CHAMBRE AND ligne_facture.CODE_RESERVATION = reserve_conf.CODE_RESERVATION AND FUSIONNEE IN ('HEBERGEMENT','ACCOMMODATION') ORDER BY TYPE_LIGNE_FACTURE ASC"

        ElseIf INCOM_GENERATED_CASHED_IN = 1 Then 'ARGENT EFFECTIVEMENT ENCAISSE

            If GlobalVariable.actualLanguageValue = 1 Then
                Query = "SELECT MONTANT_VERSE, TYPE_CHAMBRE FROM reglement, reserve_conf 
                WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <='" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND TYPE_CHAMBRE=@TYPE_CHAMBRE AND reglement.CODE_RESERVATION = reserve_conf.CODE_RESERVATION AND MODE_REGLEMENT IN ('Espèce','Virement Bancaire','MTN Money', 'ORANGE Money', 'Carte Credit')"

            Else
                Query = "SELECT MONTANT_VERSE, TYPE_CHAMBRE FROM reglement, reserve_conf 
                WHERE DATE_REGLEMENT >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <='" & DateDebut.ToString("yyyy-MM-dd") & "' 
                AND TYPE_CHAMBRE=@TYPE_CHAMBRE AND reglement.CODE_RESERVATION = reserve_conf.CODE_RESERVATION AND MODE_REGLEMENT IN ('Cash','Credit Card','MTN Money', 'ORANGE Money','Bank Transfer')"

            End If

        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = TYPE_CHAMBRE

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Dim montantTotal As Double = 0

        For i = 0 To table.Rows.Count - 1

            If INCOM_GENERATED_CASHED_IN = 0 Then
                montantTotal += table.Rows(i)("MONTANT_TTC")
            Else
                montantTotal += table.Rows(i)("MONTANT_VERSE")
            End If

        Next

        Return montantTotal

    End Function

    Public Function VenteNetHebermentNuits(ByVal DateDebut As Date, ByVal TYPE_CHAMBRE As String) As Integer

        Dim Query As String = ""

        Dim query01 As String = "SELECT * FROM reserve_conf WHERE DATE_SORTIE > '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE_CHAMBRE=@TYPE_CHAMBRE "

        Dim command01 As New MySqlCommand(query01, GlobalVariable.connect)
        command01.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
        Dim adapter01 As New MySqlDataAdapter(command01)
        Dim table As New DataTable()
        adapter01.Fill(table)

        Return table.Rows.Count

    End Function


    Public Sub updateMontantEncaissementDansBlocNote(ByVal BLOC_NOTE_EN_COURS As String, ByVal MONTANT_REGLEMENT As Double)

        Dim updateQuery As String = "UPDATE ligne_facture_bloc_note SET MONTANT_ENCAISSEMENT = MONTANT_ENCAISSEMENT + @MONTANT_ENCAISSEMENT WHERE NUMERO_BLOC_NOTE = @BLOC_NOTE_EN_COURS"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@MONTANT_ENCAISSEMENT", MySqlDbType.Double).Value = MONTANT_REGLEMENT
        command.Parameters.Add("@BLOC_NOTE_EN_COURS", MySqlDbType.VarChar).Value = BLOC_NOTE_EN_COURS

        command.ExecuteNonQuery()

    End Sub

End Class
