Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Facture
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new invoice
    Public Function insertFacture(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String, ByVal CODE_COMMANDE As String, ByVal NUMERO_TABLE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUM_MOUVEMENT As String, ByVal DATE_FACTURE As Date, ByVal CODE_CLIENT As String, ByVal CODE_COMMERCIAL As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal MONTANT_TTC As Double, ByVal AVANCE As Double, ByVal RESTE_A_PAYER As Double, ByVal DATE_PAIEMENT As Date, ByVal ETAT_FACTURE As String, ByVal LIBELLE_FACTURE As String, ByVal MONTANT_TRANSPORT As Double, ByVal MONTANT_REMISE As Double, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_UTILISATEUR_ANNULE As String, ByVal CODE_UTILISATEUR_VALIDE As String, ByVal NOM_CLIENT_FACTURE As String, ByVal MONTANT_AVANCE As Double, ByVal CODE_AGENCE As String, ByVal GRIFFE_UTILISATEUR As String, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim insertQuery As String = "INSERT INTO `facture`(`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_COMMANDE`, `NUMERO_TABLE`, `CODE_MODE_PAIEMENT`, `NUM_MOUVEMENT`, `DATE_FACTURE`, `CODE_CLIENT`, `CODE_COMMERCIAL`, `MONTANT_HT`, `TAXE`, `MONTANT_TTC`, `AVANCE`, `RESTE_A_PAYER`, `DATE_PAIEMENT`, `ETAT_FACTURE`, `LIBELLE_FACTURE`, `MONTANT_TRANSPORT`, `MONTANT_REMISE`, `CODE_UTILISATEUR_CREA`, `CODE_UTILISATEUR_ANNULE`, `CODE_UTILISATEUR_VALIDE`, `NOM_CLIENT_FACTURE`, `MONTANT_AVANCE`, `CODE_AGENCE`, `GRIFFE_UTILISATEUR`, `TYPE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@GRIFFE_UTILISATEUR, @value27)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_COMMANDE
        command.Parameters.Add("@value5", MySqlDbType.String).Value = NUMERO_TABLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NUM_MOUVEMENT
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_FACTURE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_COMMERCIAL
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = AVANCE
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = RESTE_A_PAYER
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_PAIEMENT
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = ETAT_FACTURE
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = LIBELLE_FACTURE
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = MONTANT_TRANSPORT
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_ANNULE
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_VALIDE
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = NOM_CLIENT_FACTURE
        command.Parameters.Add("@value25", MySqlDbType.Double).Value = MONTANT_AVANCE
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value27", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@GRIFFE_UTILISATEUR", MySqlDbType.VarChar).Value = GRIFFE_UTILISATEUR

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
    Public Function updateFacture(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String, ByVal CODE_COMMANDE As String, ByVal NUMERO_TABLE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUM_MOUVEMENT As String, ByVal DATE_FACTURE As String, ByVal CODE_CLIENT As String, ByVal CODE_COMMERCIAL As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal MONTANT_TTC As Double, ByVal AVANCE As Double, ByVal RESTE_A_PAYER As Double, ByVal DATE_PAIEMENT As Date, ByVal ETAT_FACTURE As String, ByVal LIBELLE_FACTURE As String, ByVal MONTANT_TRANSPORT As Double, ByVal MONTANT_REMISE As Double, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_UTILISATEUR_ANNULE As String, ByVal CODE_UTILISATEUR_VALIDE As String, ByVal NOM_CLIENT_FACTURE As String, ByVal MONTANT_AVANCE As Double, ByVal CODE_AGENCE As String) As Boolean

        Dim updateQuery As String = "UPDATE `facture` SET `CODE_FACTURE`=@value2,`CODE_RESERVATION`=@value3,`CODE_COMMANDE`=@value4,`NUMERO_TABLE`=@value5,`CODE_MODE_PAIEMENT`=@value6,`NUM_MOUVEMENT`=@value7,`DATE_FACTURE`=@value8,`CODE_CLIENT`=@value9,`CODE_COMMERCIAL`=@value10,`MONTANT_HT`=@value11,`TAXE`=@value12,`MONTANT_TTC`=@value13,`AVANCE`=@value14,`RESTE_A_PAYER`=@value15,`DATE_PAIEMENT`=@value16,`ETAT_FACTURE`=@value17,`LIBELLE_FACTURE`=@value18,`MONTANT_TRANSPORT`=@value19,`MONTANT_REMISE`=@value20,`CODE_UTILISATEUR_CREA`=@value21,`CODE_UTILISATEUR_ANNULE`=@value22,`CODE_UTILISATEUR_VALIDE`=@value23,`NOM_CLIENT_FACTURE`=@value24,`MONTANT_AVANCE`=@value25,`CODE_AGENCE`=@value26  WHERE CODE_FACTURE=@CODE_FACTURE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_COMMANDE
        command.Parameters.Add("@value5", MySqlDbType.String).Value = NUMERO_TABLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NUM_MOUVEMENT
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_FACTURE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_COMMERCIAL
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = AVANCE
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = RESTE_A_PAYER
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_PAIEMENT
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = ETAT_FACTURE
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = LIBELLE_FACTURE
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = MONTANT_TRANSPORT
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_ANNULE
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_VALIDE
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = NOM_CLIENT_FACTURE
        command.Parameters.Add("@value25", MySqlDbType.Double).Value = MONTANT_AVANCE
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = CODE_AGENCE

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

    'Saving the values of ligne_Facture into the corresponding Facture at the facturation uppong clicking on the save button in facturation 
    Public Function updateFactureBeforeSave(ByVal CODE_FACTURE As String, ByVal MONTANT_HT As Double, ByVal MONTANT_TTC As Double, ByVal RESTE_A_PAYER As Double, ByVal MONTANT_REMISE As Double, MONTANT_AVANCE As Double) As Boolean

        Dim updateQuery As String = "UPDATE `facture` SET `MONTANT_HT`=@value11,`MONTANT_TTC`=@value13,`RESTE_A_PAYER`=@value15,`MONTANT_REMISE`=@value20,`MONTANT_AVANCE`=@value25  WHERE CODE_FACTURE=@CODE_FACTURE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        Dim TAXE As Double = MONTANT_TTC - MONTANT_HT
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_TTC
        'command.Parameters.Add("@value14", MySqlDbType.Double).Value = AVANCE
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = RESTE_A_PAYER
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value25", MySqlDbType.Double).Value = MONTANT_AVANCE

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
    Public Function updateFactureAfterReglement(ByVal CODE_FACTURE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal RESTE_A_PAYER As Double, ByVal DATE_PAIEMENT As Date, ByVal ETAT_FACTURE As String, ByVal MONTANT_AVANCE As Double) As Boolean

        Dim updateQuery As String = "UPDATE `facture` SET `CODE_MODE_PAIEMENT`=@CODE_MODE_PAIEMENT,`RESTE_A_PAYER`=@RESTE_A_PAYER,`DATE_PAIEMENT`=@DATE_PAIEMENT,`ETAT_FACTURE`=@ETAT_FACTURE,`MONTANT_AVANCE`=MONTANT_AVANCE + @MONTANT_AVANCE WHERE CODE_FACTURE=@CODE_FACTURE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE

        command.Parameters.Add("@CODE_MODE_PAIEMENT", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT

        command.Parameters.Add("@RESTE_A_PAYER", MySqlDbType.Double).Value = RESTE_A_PAYER
        command.Parameters.Add("@DATE_PAIEMENT", MySqlDbType.Date).Value = DATE_PAIEMENT
        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.VarChar).Value = ETAT_FACTURE
        command.Parameters.Add("@MONTANT_AVANCE", MySqlDbType.Double).Value = MONTANT_AVANCE
        'command.Parameters.Add("@value27", MySqlDbType.Double).Value = LIBELLE_FACTURE


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

    '-------------------------------------------------- FACTURE LIE A UNE RESERVATION D'UN CLIENT -------------------------------------------------------

    Public Function ListeDesFactureDeLaReservationEncours(ByVal CODE_RESERVATION As String) As DataTable

        Dim Query As String = "SELECT CODE_FACTURE As 'CODE', LIBELLE_FACTURE AS 'LIBELLE', DATE_FACTURE As 'DATE', MONTANT_TTC AS 'TOTAL TTC', AVANCE, RESTE_A_PAYER AS 'RESTE A PAYER'  FROM FACTURE WHERE CODE_RESERVATION=@CODE_RESERVATION AND CODE_AGENCE=@CODE_AGENCE"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function MigrationDeLigneFatureTempVersLigneFactureComptoire(ByVal NUMERO_BLOC_NOTE As String) As Boolean

        Dim Query As String = "INSERT INTO `ligne_facture`(`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`,`NUMERO_BLOC_NOTE`) SELECT DISTINCT `CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`, `NUMERO_BLOC_NOTE` FROM `ligne_facture_temp` WHERE NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)
        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        'Opening the connection
        'connect.openConnection()

        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    '------------------------------ RAPPORTS  --------------------------------

    Public Function ListeDesFacturePourRapport(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim Query As String = "SELECT CODE_FACTURE As 'CODE', LIBELLE_FACTURE AS 'LIBELLE', NOM_CLIENT_FACTURE AS 'NOM CLIENT',DATE_FACTURE As 'DATE', CODE_RESERVATION AS 'RESERVATION', MONTANT_TTC AS 'TOTAL TTC', AVANCE, RESTE_A_PAYER AS 'RESTE A PAYER', CODE_CLIENT  FROM FACTURE WHERE CODE_AGENCE=@CODE_AGENCE AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE >='" & DateDebut.ToString("yyyy-MM-dd") & "' "

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    '


    Public Function factureReglee(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        'Dim Query As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, NOM_CLIENT AS 'ENTREPRISE', RELANCE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, NUMERO_COMPTE, DELAI_DE_PAIEMENT AS DELAI FROM facture, client, compte WHERE facture.CODE_CLIENT = client.CODE_CLIENT AND TYPE_CLIENT=@TYPE_CLIENT AND compte.CODE_CLIENT = client.CODE_CLIENT AND client.CODE_AGENCE=@CODE_AGENCE ORDER BY DATE_FACTURE ASC "
        Dim Query As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, NOM_CLIENT AS 'ENTREPRISE', RELANCE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, NUMERO_COMPTE, DELAI_DE_PAIEMENT AS DELAI FROM facture, client, compte WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND facture.CODE_CLIENT = client.CODE_CLIENT AND compte.CODE_CLIENT = client.CODE_CLIENT AND client.CODE_AGENCE=@CODE_AGENCE ORDER BY DATE_FACTURE ASC "

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        'Dim TYPE_CLIENT As String = "ENTREPRISE"

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = TYPE_CLIENT

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Dim Query1 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, INTITULE AS 'ENTREPRISE', RELANCE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, NUMERO_COMPTE, DELAI_DE_PAIEMENT AS DELAI FROM facture, compte WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND facture.CODE_CLIENT = compte.NUMERO_COMPTE AND CODE_AGENCE=@CODE_AGENCE ORDER BY DATE_FACTURE ASC "

        Dim command1 As New MySqlCommand(Query1, GlobalVariable.connect)

        'Dim TYPE_CLIENT As String = "ENTREPRISE"

        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = TYPE_CLIENT

        Dim adapterList1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()


        adapterList1.Fill(table1)

        table.Merge(table1)

        Return table

    End Function

    Public Function lettreDeRelance(ByVal DateDeTravail As Date) As DataTable

        'Dim Query As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, NOM_CLIENT AS 'ENTREPRISE', RELANCE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, NUMERO_COMPTE, DELAI_DE_PAIEMENT AS DELAI FROM facture, client, compte WHERE facture.CODE_CLIENT = client.CODE_CLIENT AND TYPE_CLIENT=@TYPE_CLIENT AND compte.CODE_CLIENT = client.CODE_CLIENT AND client.CODE_AGENCE=@CODE_AGENCE ORDER BY DATE_FACTURE ASC "
        Dim Query As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, NOM_CLIENT AS 'ENTREPRISE', RELANCE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, NUMERO_COMPTE, DELAI_DE_PAIEMENT AS DELAI, RESTE_A_PAYER FROM facture, client, compte WHERE facture.CODE_CLIENT = client.CODE_CLIENT AND compte.CODE_CLIENT = client.CODE_CLIENT AND client.CODE_AGENCE=@CODE_AGENCE ORDER BY DATE_FACTURE ASC "

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        'Dim TYPE_CLIENT As String = "ENTREPRISE"

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = TYPE_CLIENT

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Dim Query1 As String = "SELECT CODE_FACTURE As REFERENCE, DATE_FACTURE AS DATE, INTITULE AS 'ENTREPRISE', RELANCE, LIBELLE_FACTURE AS LIBELLE, MONTANT_TTC AS MONTANT, MONTANT_AVANCE AS 'MONTANT SOLDE', LETTRAGE, NUMERO_COMPTE, DELAI_DE_PAIEMENT AS DELAI FROM facture, compte WHERE facture.CODE_CLIENT = compte.NUMERO_COMPTE AND CODE_AGENCE=@CODE_AGENCE ORDER BY DATE_FACTURE ASC "

        Dim command1 As New MySqlCommand(Query1, GlobalVariable.connect)

        'Dim TYPE_CLIENT As String = "ENTREPRISE"

        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        'command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = TYPE_CLIENT

        Dim adapterList1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()


        adapterList1.Fill(table1)

        table.Merge(table1)

        Return table

    End Function

    'MISE AJOURS DE ETAT_FACTURE : POUR NE PLUS AFFICHER LES FACTURES DANS LES RELANCES

    Public Sub updateFactureApresRelance(ByVal CODE_FACTURE As String, ByVal RELANCE As Integer)

        Dim insertQuery As String = ""

        insertQuery = "UPDATE `facture` SET `RELANCE`=@RELANCE WHERE CODE_FACTURE=@CODE_FACTURE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@RELANCE", MySqlDbType.Int64).Value = RELANCE

        command.ExecuteNonQuery()

    End Sub

    Public Function insertTransfertRecette(ByVal CODE_FACTURE As String, ByVal CODE_RESERVATION As String, ByVal CODE_COMMANDE As String, ByVal NUMERO_TABLE As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUM_MOUVEMENT As String, ByVal DATE_FACTURE As Date, ByVal CODE_CLIENT As String, ByVal CODE_COMMERCIAL As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal MONTANT_TTC As Double, ByVal AVANCE As Double, ByVal RESTE_A_PAYER As Double, ByVal DATE_PAIEMENT As Date, ByVal ETAT_FACTURE As String, ByVal LIBELLE_FACTURE As String, ByVal MONTANT_TRANSPORT As Double, ByVal MONTANT_REMISE As Double, ByVal CODE_UTILISATEUR_CREA As String, ByVal CODE_UTILISATEUR_ANNULE As String, ByVal CODE_UTILISATEUR_VALIDE As String, ByVal NOM_CLIENT_FACTURE As String, ByVal MONTANT_AVANCE As Double, ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim insertQuery As String = "INSERT INTO `transfert_recette`(`CODE_FACTURE`, `CODE_RESERVATION`, `CODE_COMMANDE`, `NUMERO_TABLE`, `CODE_MODE_PAIEMENT`, `NUM_MOUVEMENT`, `DATE_FACTURE`, `CODE_CLIENT`, `CODE_COMMERCIAL`, `MONTANT_HT`, `TAXE`, `MONTANT_TTC`, `AVANCE`, `RESTE_A_PAYER`, `DATE_PAIEMENT`, `ETAT_FACTURE`, `LIBELLE_FACTURE`, `MONTANT_TRANSPORT`, `MONTANT_REMISE`, `CODE_UTILISATEUR_CREA`, `CODE_UTILISATEUR_ANNULE`, `CODE_UTILISATEUR_VALIDE`, `NOM_CLIENT_FACTURE`, `MONTANT_AVANCE`, `CODE_AGENCE`, `TYPE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_COMMANDE
        command.Parameters.Add("@value5", MySqlDbType.String).Value = NUMERO_TABLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NUM_MOUVEMENT
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_FACTURE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_COMMERCIAL
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = AVANCE
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = RESTE_A_PAYER
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_PAIEMENT
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = ETAT_FACTURE
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = LIBELLE_FACTURE
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = MONTANT_TRANSPORT
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = MONTANT_REMISE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_ANNULE
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_VALIDE
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = NOM_CLIENT_FACTURE
        command.Parameters.Add("@value25", MySqlDbType.Double).Value = MONTANT_AVANCE
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value27", MySqlDbType.VarChar).Value = TYPE

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

End Class
