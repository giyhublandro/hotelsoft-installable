
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Caisse

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    Public Function resume_vente_journaliere(ByVal EN_CHAMBRE As Double, ByVal COMPTOIR As Double, ByVal COMPTE As Double, ByVal GRATUITEE As Double, ByVal GRATUITE_EN_CHAMBRE As Double, ByVal EN_SALLE As Double, ByVal TOTAL_VENTE As Double, ByVal DATE_VENTE As Date, ByVal CODE_UTILISATEUR As String, ByVal CODE_AGENCE As String, ByVal CODE_CAISSE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `resume_vente_journaliere`(`EN_CHAMBRE`, `COMPTOIR`, `COMPTE`, `GRATUITEE`,`GRATUITE_EN_CHAMBRE`,`EN_SALLE`, `TOTAL_VENTE`, `DATE_VENTE`, `CODE_UTILISATEUR`, `CODE_AGENCE`, `CODE_CAISSE`) VALUES (@EN_CHAMBRE, @COMPTOIR, @COMPTE, @GRATUITEE,@GRATUITE_EN_CHAMBRE, @EN_SALLE, @TOTAL_VENTE, @DATE_VENTE, @CODE_UTILISATEUR, @CODE_AGENCE, @CODE_CAISSE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@EN_CHAMBRE", MySqlDbType.Double).Value = EN_CHAMBRE
        command.Parameters.Add("@EN_SALLE", MySqlDbType.Double).Value = EN_SALLE
        command.Parameters.Add("@COMPTOIR", MySqlDbType.Double).Value = COMPTOIR
        command.Parameters.Add("@COMPTE", MySqlDbType.Double).Value = COMPTE
        command.Parameters.Add("@GRATUITEE", MySqlDbType.Double).Value = GRATUITEE
        command.Parameters.Add("@GRATUITE_EN_CHAMBRE", MySqlDbType.Double).Value = GRATUITE_EN_CHAMBRE
        command.Parameters.Add("@TOTAL_VENTE", MySqlDbType.Double).Value = TOTAL_VENTE
        command.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@DATE_VENTE", MySqlDbType.Date).Value = DATE_VENTE

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

    Public Function insertPetiteCaisseLigneSynthese(ByVal LIBELLE As String, ByVal DATE_SYNTHESE As Date, ByVal MONTANT_DEBIT As Double, ByVal CODE_SYNTHESE As String, ByVal CODE_CAISSE As String, ByVal CODE_UTILISATEUR As String, ByVal CODE_AGENCE As String) As Boolean


        Dim insertQuery As String = "INSERT INTO `petite_caisse_ligne_synthese`(`LIBELLE`, `DATE_SYNTHESE`, `MONTANT_DEBIT`, `CODE_SYNTHESE`, `CODE_CAISSE`, `CODE_UTILISATEUR`,`CODE_AGENCE`) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value2", MySqlDbType.Date).Value = DATE_SYNTHESE
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = MONTANT_DEBIT
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_SYNTHESE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_CAISSE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_AGENCE

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

    Public Function insert(ByVal CODE_CAISSE As String, ByVal LIBELLE_CAISSE As String, ByVal CODE_UTILISATEUR As String, ByVal NUM_COMPTE As String, ByVal ETAT_CAISSE As Integer, ByVal DATE_CREATION As Date, ByVal DATE_COMPTABLE As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_AGENCE As String, ByVal TYPE_CAISSE As String, ByVal TABLE As String, Optional ByVal MONTANT_PLAFONDS As Double = 0) As Boolean

        Dim insertQuery As String = ""

        If TABLE = "petite_caisse" Then

            insertQuery = "INSERT INTO " & TABLE & " (`CODE_CAISSE`, `LIBELLE_CAISSE`, `CODE_UTILISATEUR`, `NUM_COMPTE`, `ETAT_CAISSE`,`DATE_CREATION`, `DATE_COMPTABLE`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`, `TYPE_CAISSE`, `MONTANT_PLAFONDS`) VALUES (@value1,@value2,@value3,@value4,@value5,@value7,@value8,@value9,@value10,@value11,@value12,@value13, @MONTANT_PLAFONDS)"

        Else

            insertQuery = "INSERT INTO " & TABLE & " (`CODE_CAISSE`, `LIBELLE_CAISSE`, `CODE_UTILISATEUR`, `NUM_COMPTE`, `ETAT_CAISSE`,`DATE_CREATION`, `DATE_COMPTABLE`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`, `TYPE_CAISSE`) VALUES (@value1,@value2,@value3,@value4,@value5,@value7,@value8,@value9,@value10,@value11,@value12,@value13)"

        End If

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_CAISSE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE_CAISSE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = NUM_COMPTE
        command.Parameters.Add("@value5", MySqlDbType.Int64).Value = ETAT_CAISSE
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_COMPTABLE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value10", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = TYPE_CAISSE
        command.Parameters.Add("@MONTANT_PLAFONDS", MySqlDbType.Double).Value = MONTANT_PLAFONDS
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

    'create a function to update the selected row
    Public Function update(ByVal CODE_CAISSE As String, ByVal LIBELLE_CAISSE As String, ByVal CODE_UTILISATEUR As String, ByVal NUM_COMPTE As String, ByVal ETAT_CAISSE As Integer, ByVal DATE_CREATION As Date, ByVal DATE_COMPTABLE As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_AGENCE As String, ByVal TYPE_CAISSE As String, ByVal TABLE As String, Optional ByVal MONTANT_PLAFONDS As Double = 0) As Boolean

        Dim insertQuery As String = ""

        If TABLE = "petite_caisse" Then

            'PETITE CAISSE

            insertQuery = "UPDATE " & TABLE & " SET `LIBELLE_CAISSE`=@value3, `CODE_UTILISATEUR`=@value4, `NUM_COMPTE`=@value5, `ETAT_CAISSE`=@value6, `DATE_MODIFICATION`=@value11, `CODE_UTILISATEUR_MODIF`=@value12, `TYPE_CAISSE`=@value14, MONTANT_PLAFONDS=@MONTANT_PLAFONDS WHERE CODE_CAISSE=@CODE_CAISSE"

        Else

            'PETITE GRANDE CAISSE

            insertQuery = "UPDATE " & TABLE & " SET `LIBELLE_CAISSE`=@value3, `CODE_UTILISATEUR`=@value4, `NUM_COMPTE`=@value5, `ETAT_CAISSE`=@value6, `DATE_MODIFICATION`=@value11, `CODE_UTILISATEUR_MODIF`=@value12, `TYPE_CAISSE`=@value14 WHERE CODE_CAISSE=@CODE_CAISSE"

        End If

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_CAISSE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = NUM_COMPTE
        command.Parameters.Add("@value6", MySqlDbType.Int64).Value = ETAT_CAISSE
        command.Parameters.Add("@value11", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = TYPE_CAISSE
        command.Parameters.Add("@MONTANT_PLAFONDS", MySqlDbType.Double).Value = MONTANT_PLAFONDS

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

    Public Function ouvertureFermetureDePetiteCaisse(ByVal CODE_CAISSE As String, ByVal ETAT_CAISSE As Integer) As Boolean

        Dim insertQuery As String = "UPDATE `petite_caisse` SET `ETAT_CAISSE`=@value6 WHERE CODE_CAISSE=@CODE_CAISSE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value6", MySqlDbType.Int64).Value = ETAT_CAISSE
        command.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE

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

    Public Function ouvertureFermetureDeCaisse(ByVal CODE_CAISSE As String, ByVal ETAT_CAISSE As Integer) As Boolean

        Dim insertQuery As String = "UPDATE `caisse` SET `ETAT_CAISSE`=@value6 WHERE CODE_CAISSE=@CODE_CAISSE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value6", MySqlDbType.Int64).Value = ETAT_CAISSE
        command.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE

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

    'MISE A JOURS DU CODE CLIENT

    Public Function updateSoldeCaisse(ByVal CODE_CAISSIER As String, ByVal MONTANT As Double) As Boolean

        Dim insertQuery As String = "UPDATE caisse SET SOLDE_CAISSE=SOLDE_CAISSE + @MONTANT WHERE CODE_UTILISATEUR=@CODE_UTILISATEUR"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.String).Value = CODE_CAISSIER
        command.Parameters.Add("@MONTANT", MySqlDbType.Double).Value = MONTANT

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

    Public Function MontantTotalDesVentesDuJourDunCaissierQuelconque(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String) As DataTable

        Dim MontantTotalDesVente As Double = 0

        Dim getUserQuery = "SELECT * FROM ligne_facture WHERE CODE_UTILISATEUR_CREA = @CODE_CAISSIER AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' ORDER BY DATE_FACTURE DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        If dt.Rows.Count > 0 Then

            For j = 0 To dt.Rows.Count - 1
                MontantTotalDesVente += dt.Rows(j)("MONTANT_HT")
            Next

        End If

        'Return MontantTotalDesVente
        Return dt

    End Function

    Public Shared Function SituationDeCaisseDunCaissierQuelconque(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String) As DataTable

        Dim getUserQuery = "SELECT * FROM reglement WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_REGLEMENT >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_REGLEMENT <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT ORDER BY DATE_REGLEMENT DESC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Dim ETAT As Integer = 0

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    'PRENANT EN COMPTE L'ETAT = 0 : NON EQUILIBRE
    Public Shared Function BlocNoteDunCaissierQuelconquePourEquilibre(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String) As DataTable

        'Dim getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE IN (0,2,3) AND ETAT = @ETAT ORDER BY NUMERO_BLOC_NOTE ASC"
        Dim getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE IN (0) AND ETAT = @ETAT ORDER BY NUMERO_BLOC_NOTE ASC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        'Dim ETAT_FACTURE As Integer = 0

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = 0

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function


    Public Shared Function ligneDesBlocNoteDunCaissierQuelconque(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String) As DataTable

        'Dim getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE = @ETAT_FACTURE ORDER BY NUMERO_BLOC_NOTE ASC"

        Dim getUserQuery = ""

        If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
            getUserQuery = "SELECT * FROM ligne_facture WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT ORDER BY NUMERO_BLOC_NOTE ASC"
        Else
            getUserQuery = "SELECT * FROM ligne_facture WHERE CODE_UTILISATEUR_CREA = @CODE_CAISSIER AND DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT=@ETAT ORDER BY NUMERO_BLOC_NOTE ASC"
        End If


        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        'Dim ETAT_FACTURE As Integer = 0

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT", MySqlDbType.Int32).Value = 0

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function


    Public Shared Function FastFoodBlocNoteDunCaissierQuelconque(ByVal DateDeSituation As Date) As DataTable

        Dim getUserQuery = ""

        getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE IN (0,1,2,3)"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        'Dim ETAT_FACTURE As Integer = 0

        'command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT", MySqlDbType.Int32).Value = 0
        'command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Shared Function FastFoodLigneDunCaissierQuelconque(ByVal DateDeSituation As Date, ByVal NUMERO_BLOC_NOTE As String) As DataTable

        Dim getUserQuery = ""

        getUserQuery = "SELECT MONTANT_TTC, TYPE_LIGNE_FACTURE, SORTIE_PAR FROM ligne_facture
        WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' 
        AND SORTIE=@SORTIE AND NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        command.Parameters.Add("@SORTIE", MySqlDbType.Int32).Value = 1
        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        'command.Parameters.Add("@SORTIE_PAR", MySqlDbType.VarChar).Value = SORTIE_PAR

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Dim getUserQuery_ = ""

        getUserQuery_ = "SELECT MONTANT_TTC, TYPE_LIGNE_FACTURE, SORTIE_PAR FROM ligne_facture_temp
        WHERE DATE_FACTURE >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' 
        AND SORTIE=@SORTIE AND NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE"

        Dim command_ As New MySqlCommand(getUserQuery_, GlobalVariable.connect)
        command_.Parameters.Add("@SORTIE", MySqlDbType.Int32).Value = 1
        command_.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        'command_.Parameters.Add("@SORTIE_PAR", MySqlDbType.VarChar).Value = SORTIE_PAR

        Dim adapter_ As New MySqlDataAdapter

        Dim dt_ As New DataTable()

        adapter_.SelectCommand = command_
        adapter_.Fill(dt_)

        dt.Merge(dt_)

        Return dt

    End Function

    Public Shared Function BlocNoteDunCaissierQuelconque(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String) As DataTable

        'Dim getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE = @ETAT_FACTURE ORDER BY NUMERO_BLOC_NOTE ASC"

        Dim getUserQuery = ""

        If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
            getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE IN (0,1,2,3) AND ETAT=@ETAT ORDER BY NUMERO_BLOC_NOTE ASC"
        Else
            getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE IN (0,1,2,3) AND ETAT=@ETAT ORDER BY NUMERO_BLOC_NOTE ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        'Dim ETAT_FACTURE As Integer = 0

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT", MySqlDbType.Int32).Value = 0
        'command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int64).Value = ETAT_FACTURE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Shared Function BlocNoteDunCaissierQuelconqueCloture(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String) As DataTable

        Dim getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT = @ETAT ORDER BY NUMERO_BLOC_NOTE ASC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Dim ETAT As Integer = 1

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command

        adapter.Fill(dt)

        Return dt

    End Function

    Public Shared Function LigneDunBlocNoteQuelconquePartantDuNumResa(ByVal CODE_RESERVATION As String, ByVal NUMERO_BLOC_NOTE As String) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            getUserQuery = "SELECT LIBELLE_FACTURE As 'ITEM' , QUANTITE as QUANTITY, PRIX_UNITAIRE_TTC AS 'UNIT PRICE' , MONTANT_TTC AS 'TOTAL AMOUNT', CODE_ARTICLE, ID_LIGNE_FACTURE 
                From ligne_facture Where CODE_RESERVATION = @CODE_RESERVATION AND NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE Order By LIBELLE_FACTURE ASC"
        Else
            getUserQuery = "SELECT LIBELLE_FACTURE As 'LIBELLE ARTICLE' , QUANTITE, PRIX_UNITAIRE_TTC AS 'PU', MONTANT_TTC AS 'MONTANT TOTAL', CODE_ARTICLE, ID_LIGNE_FACTURE 
                From ligne_facture Where CODE_RESERVATION = @CODE_RESERVATION AND NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE Order By LIBELLE_FACTURE ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command

        adapter.Fill(dt)

        If Not dt.Rows.Count > 0 Then

            getUserQuery = "Select LIBELLE_FACTURE As 'LIBELLE ARTICLE' , QUANTITE, PRIX_UNITAIRE_TTC AS 'PU', MONTANT_TTC AS 'MONTANT TOTAL', CODE_ARTICLE, ID_LIGNE_FACTURE 
                From ligne_facture Where NUMERO_SERIE_FIN = @NUMERO_BLOC_NOTE Order By LIBELLE_FACTURE ASC"

            Dim command01 As New MySqlCommand(getUserQuery, GlobalVariable.connect)

            command01.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
            command01.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE

            Dim adapter01 As New MySqlDataAdapter
            adapter01.SelectCommand = command01

            adapter01.Fill(dt)

        End If

        Return dt

    End Function


    Public Shared Function LigneDunBlocNoteQuelconque(ByVal NUMERO_BLOC_NOTE As String) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            getUserQuery = "Select LIBELLE_FACTURE As 'ITEM' , QUANTITE as QUANTITY, PRIX_UNITAIRE_TTC AS 'UNIT PRICE' , MONTANT_TTC AS 'TOTAL AMOUNT', CODE_ARTICLE, ID_LIGNE_FACTURE 
                From ligne_facture Where NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE Order By LIBELLE_FACTURE ASC"

        Else
            getUserQuery = "Select LIBELLE_FACTURE As 'LIBELLE ARTICLE' , QUANTITE, PRIX_UNITAIRE_TTC AS 'PU', MONTANT_TTC AS 'MONTANT TOTAL', CODE_ARTICLE, ID_LIGNE_FACTURE 
                From ligne_facture Where NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE Order By LIBELLE_FACTURE ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command

        adapter.Fill(dt)

        If dt.Rows.Count > 0 Then
            Return dt
        Else

            Dim getUserQuery01 = "Select LIBELLE_FACTURE As 'LIBELLE ARTICLE' , QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL', CODE_ARTICLE, ID_LIGNE_FACTURE FROM ligne_facture WHERE NUMERO_SERIE_FIN = @NUMERO_BLOC_NOTE ORDER BY LIBELLE_FACTURE ASC"

            If GlobalVariable.actualLanguageValue = 0 Then
                getUserQuery01 = "Select LIBELLE_FACTURE As 'ITEM' , QUANTITE AS QUANTITY, MONTANT_TTC AS 'TOTAL AMOUNT', CODE_ARTICLE, ID_LIGNE_FACTURE 
                FROM ligne_facture WHERE NUMERO_SERIE_FIN = @NUMERO_BLOC_NOTE ORDER BY LIBELLE_FACTURE ASC"

            Else
                getUserQuery01 = "Select LIBELLE_FACTURE As 'LIBELLE ARTICLE' , QUANTITE, MONTANT_TTC AS 'MONTANT TOTAL', CODE_ARTICLE, ID_LIGNE_FACTURE 
                FROM ligne_facture WHERE NUMERO_SERIE_FIN = @NUMERO_BLOC_NOTE ORDER BY LIBELLE_FACTURE ASC"

            End If

            Dim command01 As New MySqlCommand(getUserQuery01, GlobalVariable.connect)

            command01.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
            Dim adapter01 As New MySqlDataAdapter

            adapter01.SelectCommand = command01

            adapter01.Fill(dt)

            If dt.Rows.Count > 0 Then
                Return dt
            Else

                If GlobalVariable.actualLanguageValue = 0 Then
                    getUserQuery = "SELECT LIBELLE_FACTURE As 'ITEM' , QUANTITE as QUANTITY, PRIX_UNITAIRE_TTC AS 'UNIT PRICE' , MONTANT_TTC AS 'TOTAL AMOUNT', CODE_ARTICLE, ID_LIGNE_FACTURE 
                From ligne_facture_temp Where NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE Order By LIBELLE_FACTURE ASC"

                Else
                    getUserQuery = "SELECT LIBELLE_FACTURE As 'LIBELLE ARTICLE' , QUANTITE, PRIX_UNITAIRE_TTC AS 'PU', MONTANT_TTC AS 'MONTANT TOTAL', CODE_ARTICLE, ID_LIGNE_FACTURE 
                From ligne_facture_temp Where NUMERO_BLOC_NOTE = @NUMERO_BLOC_NOTE Order By LIBELLE_FACTURE ASC"
                End If

                Dim command_ As New MySqlCommand(getUserQuery, GlobalVariable.connect)

                command_.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
                Dim adapter_ As New MySqlDataAdapter

                adapter_.SelectCommand = command_

                adapter_.Fill(dt)

            End If

        End If

        Return dt

    End Function

    Public Function AutoLoadBlocNoteEnChambre(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String, ByVal ETAT_BLOC_NOTE As Integer, ByVal CODE_RESERVATION As String) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
            getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY NUMERO_BLOC_NOTE ASC"
        Else
            getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY NUMERO_BLOC_NOTE ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Dim ETAT_FACTURE As Integer = 0

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function


    Public Function AutoLoadBlocNote(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String, ByVal ETAT_BLOC_NOTE As Integer) As DataTable

        Dim getUserQuery = ""
        'SESSION UNIQUE VEUT DIRE QUE 
        If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
            getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY NUMERO_BLOC_NOTE ASC"
        Else
            getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY NUMERO_BLOC_NOTE ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Dim ETAT_FACTURE As Integer = 0

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = ""
        command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function



    Public Function AutoLoadBlocNoteFastFood(ByVal DateDeSituation As Date, ByVal ETAT_BLOC_NOTE As Integer) As DataTable

        Dim getUserQuery = ""
        'SESSION UNIQUE VEUT DIRE QUE 
        getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE ORDER BY NUMERO_BLOC_NOTE ASC"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Dim ETAT_FACTURE As Integer = 0

        'command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = ""
        command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function lesDifferentsServeur(ByVal dateDeTravail As Date)

        '----------------------------------------------------------------------------------
        Dim query4 As String = "SELECT DISTINCT CODE_CAISSIER FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & dateDeTravail.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <='" & dateDeTravail.ToString("yyyy-MM-dd") & "'"

        Dim command4 As New MySqlCommand(query4, GlobalVariable.connect)
        command4.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter4 As New MySqlDataAdapter(command4)
        Dim dt As New DataTable()
        adapter4.Fill(dt)

        Return dt
        '----------------------------------------------------------------------------------

    End Function

    Public Function AutoLoadBlocNoteVisualisationClasFastFoodsVerif(ByVal DateDeSituation As Date, ByVal ETAT_BLOC_NOTE As Integer) As DataTable

        Dim getUserQuery = ""

        getUserQuery = "SELECT * FROM ligne_facture_bloc_note
            WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' 
            AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE ORDER BY NUMERO_BLOC_NOTE ASC"


        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        'command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        'command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = ""
        command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function AutoLoadBlocNoteVisualisationClasFastFoods(ByVal DateDeSituation As Date, ByVal ETAT_BLOC_NOTE As Integer) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE, ligne_facture_bloc_note.DATE_DE_CONTROLE, SERVEUR AS SERVER FROM ligne_facture_bloc_note, utilisateurs 
            WHERE ligne_facture_bloc_note.DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ligne_facture_bloc_note.DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' 
            AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND utilisateurs.CODE_UTILISATEUR = ligne_facture_bloc_note.SERVEUR ORDER BY NUMERO_BLOC_NOTE ASC"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT, ligne_facture_bloc_note.DATE_DE_CONTROLE, SERVEUR FROM ligne_facture_bloc_note, utilisateurs 
            WHERE ligne_facture_bloc_note.DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ligne_facture_bloc_note.DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' 
            AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND utilisateurs.CODE_UTILISATEUR = ligne_facture_bloc_note.SERVEUR ORDER BY NUMERO_BLOC_NOTE ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        'command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = ""
        command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function AutoLoadBlocNoteVisualisationClass(ByVal DateDeSituation As Date, ByVal CODE_CAISSIER As String, ByVal ETAT_BLOC_NOTE As Integer) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
                getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE, DATE_DE_CONTROLE FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY NUMERO_BLOC_NOTE ASC"
            Else
                getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE, DATE_DE_CONTROLE FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY NUMERO_BLOC_NOTE ASC"
            End If

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            If GlobalVariable.AgenceActuelle.Rows(0)("SESSION_UNIQUE") = 0 Then
                getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT, DATE_DE_CONTROLE FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY NUMERO_BLOC_NOTE ASC"
            Else
                getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT, DATE_DE_CONTROLE FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateDeSituation.ToString("yyyy-MM-dd") & "' AND ETAT_BLOC_NOTE = @ETAT_BLOC_NOTE AND CODE_RESERVATION=@CODE_RESERVATION ORDER BY NUMERO_BLOC_NOTE ASC"

            End If

        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = ""
        command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function blocNOteSurUnePeriodeDuCaissier(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_CAISSIER As String) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then
            'getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT, ETAT_BLOC_NOTE As STATE FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"
            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT, ETAT_FACTURE As STATE FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            'getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"
            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_FACTURE As ETAT FROM ligne_facture_bloc_note WHERE CODE_CAISSIER = @CODE_CAISSIER AND DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        'command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function blocNOteSurUnePeriodeFiltre(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal ETAT_FACTURE As Integer) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_FACTURE As STATE FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE=@ETAT_FACTURE ORDER BY NUMERO_BLOC_NOTE ASC"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_FACTURE As ETAT FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_FACTURE=@ETAT_FACTURE ORDER BY NUMERO_BLOC_NOTE ASC"

        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@ETAT_FACTURE", MySqlDbType.Int32).Value = ETAT_FACTURE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function blocNoteVentilation(ByVal DateDebut As Date, ByVal DateFin As Date, ByVal CODE_CAISSIER As String) As DataTable

        Dim getUserQuery = ""

        If CODE_CAISSIER.Equals("") Then
            getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE_VERIF ASC"
        Else
            getUserQuery = "SELECT * FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND CODE_CAISSIER=@CODE_CAISSIER ORDER BY NUMERO_BLOC_NOTE_VERIF ASC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function blocNOteSurUnePeriode(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            'getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"
            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_FACTURE As STATE FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            'getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"
            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_FACTURE As ETAT FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"

        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        'command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        'command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    Public Function TransfertElementDeCaisseAvantPassassion(ByVal NUMERO_BLOC_NOTE As String, ByVal NEW_CODE_CAISSIER As String) As Boolean

        Dim insertQuery As String = "UPDATE `ligne_facture_bloc_note` SET `CODE_CAISSIER`=@NEW_CODE_CAISSIER WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@NEW_CODE_CAISSIER", MySqlDbType.VarChar).Value = NEW_CODE_CAISSIER
        command.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            'Dim insertQuery1 As String = "UPDATE `ligne_facture` SET `CODE_CAISSIER`=@NEW_CODE_CAISSIER WHERE NUMERO_BLOC_NOTE=@NUMERO_BLOC_NOTE"

            'Dim command1 As New MySqlCommand(insertQuery1, GlobalVariable.connect)

            'command1.Parameters.Add("@NEW_CODE_CAISSIER", MySqlDbType.VarChar).Value = NEW_CODE_CAISSIER
            'command1.Parameters.Add("@NUMERO_BLOC_NOTE", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function affectationCaisse(ByVal CODE_CAISSE As String, ByVal CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `utilisateur_caisse`(`CODE_CAISSE`,`CODE_UTILISATEUR`) VALUES (@value1, @value2)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_CAISSE
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

    Public Function insertBilletage(ByVal NB1 As Integer, ByVal NB2 As Integer, ByVal NB3 As Integer, ByVal NB4 As Integer, ByVal NB5 As Integer, ByVal NP1 As Integer, ByVal NP2 As Integer, ByVal NP3 As Integer, ByVal NP4 As Integer, ByVal NP5 As Integer, ByVal NP6 As Integer, ByVal NP7 As Integer, ByVal NB1T1 As Double, ByVal NB2T2 As Double, ByVal NB3T3 As Double, ByVal NB4T4 As Double, ByVal NB5T5 As Double, ByVal NP1T1 As Double, ByVal NP2T2 As Double, ByVal NP3T3 As Double, ByVal NP4T4 As Double, ByVal NP5T5 As Double, ByVal NP6T6 As Double, ByVal NP7T7 As Double, ByVal CODE_CAISSIER As String, ByVal REFERENCE_TRANSACTION As String, ByVal DATE_CREATION As Date, ByVal GRAND_TOTAL As Double) As Boolean

        Dim insertQuery As String = "INSERT INTO `transfert_recette_coupures`(`NB1`, `NB2`, `NB3`, `NB4`, `NB5`, `NP1`, `NP2`, `NP3`, `NP4`, `NP5`, `NP6`, `NB1T1`, `NB2T2`, `NB3T3`, `NB4T4`, `NB5T5`, `NP1T1`, `NP2T2`, `NP3T3`, `NP4T4`, `NP5T5`, `NP6T6`, `CODE_CAISSIER`, `REFERENCE_TRANSACTION`, `DATE_CREATION`, `GRAND_TOTAL`, `NP7`, `NP7T7`) VALUES (@value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11, @value12, @value13, @value14, @value15, @value16, @value17, @value18, @value19, @value20, @value21, @value22, @value23, @value24, @value25, @value26, @value27, @NP7, @NP7T7)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.Int64).Value = NB1
        command.Parameters.Add("@value3", MySqlDbType.Int64).Value = NB2
        command.Parameters.Add("@value4", MySqlDbType.Int64).Value = NB3
        command.Parameters.Add("@value5", MySqlDbType.Int64).Value = NB4
        command.Parameters.Add("@value6", MySqlDbType.Int64).Value = NB5
        command.Parameters.Add("@value7", MySqlDbType.Int64).Value = NP1
        command.Parameters.Add("@value8", MySqlDbType.Int64).Value = NP2
        command.Parameters.Add("@value9", MySqlDbType.Int64).Value = NP3
        command.Parameters.Add("@value10", MySqlDbType.Int64).Value = NP4
        command.Parameters.Add("@value11", MySqlDbType.Int64).Value = NP5
        command.Parameters.Add("@value12", MySqlDbType.Int64).Value = NP6
        command.Parameters.Add("@NP7", MySqlDbType.Int64).Value = NP7

        command.Parameters.Add("@value13", MySqlDbType.Double).Value = NB1T1
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = NB2T2
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = NB3T3
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = NB4T4
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = NB5T5
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = NP1T1
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = NP2T2
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = NP3T3
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = NP4T4
        command.Parameters.Add("@value22", MySqlDbType.Double).Value = NP5T5
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = NP6T6
        command.Parameters.Add("@NP7T7", MySqlDbType.Double).Value = NP7T7

        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = CODE_CAISSIER
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = REFERENCE_TRANSACTION
        command.Parameters.Add("@value26", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = GRAND_TOTAL

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function venteEnSalleSurUnePeriode(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim getUserQuery = ""

        If GlobalVariable.actualLanguageValue = 0 Then

            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'RECEIPT NUMBER', MONTANT_BLOC_NOTE As AMOUNT , ETAT_BLOC_NOTE As STATE FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"

        ElseIf GlobalVariable.actualLanguageValue = 1 Then

            getUserQuery = "SELECT NUMERO_BLOC_NOTE AS 'NUMERO BLOC NOTE', MONTANT_BLOC_NOTE As MONTANT , ETAT_BLOC_NOTE As ETAT FROM ligne_facture_bloc_note WHERE DATE_CREATION >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_CREATION <= '" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY NUMERO_BLOC_NOTE ASC"

        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        'command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER
        'command.Parameters.Add("@ETAT_BLOC_NOTE", MySqlDbType.Int64).Value = ETAT_BLOC_NOTE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function


End Class
