Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Reservation
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new entry
    Public Function insertReservation(ByVal CODE_RESERVATION As String, ByVal CLIENT_ID As String, ByVal UTILISATEUR_ID As String, ByVal CHAMBRE_ID As String, ByVal AGENCE_ID As String, ByVal NOM_CLIENT As String, ByVal DATE_ENTTRE As Date, ByVal HEURE_ENTREE As DateTime, ByVal DATE_SORTIE As Date, ByVal HEURE_SORTIE As DateTime, ByVal ADULTES As Integer, ByVal NB_PERSONNES As Integer, ByVal ENFANTS As Integer, ByVal RECEVOIR_EMAIL As String, ByVal RECEVOIR_SMS As Integer, ByVal ETAT_RESERVATION As Integer, ByVal DATE_CREATION As Date, ByVal HEURE_CREATION As String, ByVal MONTANT_TOTAL_CAUTION As Double, ByVal MOTIF_ETAT As String, ByVal DATE_ETAT As Date, ByVal MONTANT_ACCORDE As Double, ByVal GROUPE As String, ByVal DEPOT_DE_GARANTIE As Double, ByVal DAY_USE As Integer, ByVal MENSUEL As Integer, ByVal BC_ENTREPRISE As String, ByVal TYPE_CHAMBRE As String, Optional ByVal TYPE As String = "chambre", Optional ByVal PETIT_DEJEUNER_ROUTAGE As Double = 0, Optional ByVal CHAMBRE_ROUTAGE As String = "", Optional ByVal VENANT_DE As String = "", Optional ByVal SE_RENDANT_A As String = "", Optional ByVal RAISON As String = "", Optional ByVal SOURCE_RESERVATION As String = "", Optional ByVal ROUTAGE As String = "NON", Optional ByVal ETAT_NOTE_RESERVATION As String = "", Optional ByVal CODE_ENTREPRISE As String = "", Optional ByVal NOM_ENTREPRISE As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `reservation`(`CODE_RESERVATION`,`CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`,`DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`,`DEPOT_DE_GARANTIE`, `DAY_USE`, `MENSUEL`, `BC_ENTREPRISE`, `TYPE_CHAMBRE`, `TYPE`, `PETIT_DEJEUNER_ROUTAGE`, `CHAMBRE_ROUTAGE`, `VENANT_DE`, `SE_RENDANT_A`, `RAISON` , `SOURCE_RESERVATION`, `ROUTAGE`, `ETAT_NOTE_RESERVATION`, `CODE_ENTREPRISE`, `NOM_ENTREPRISE`) VALUES (@CODE_RESERVATION,@value2,@value3,@value4,@value5,@NOM_CLIENT,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22, @DEPOT_DE_GARANTIE, @DAY_USE, @MENSUEL, @BC_ENTREPRISE,@TYPE_CHAMBRE, @value23, @value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32, @value33)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        If Trim(CODE_RESERVATION).Equals("") Then
            CODE_RESERVATION = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")
        End If

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CLIENT_ID
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@BC_ENTREPRISE", MySqlDbType.VarChar).Value = BC_ENTREPRISE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = UTILISATEUR_ID
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CHAMBRE_ID
        command.Parameters.Add("@value5", MySqlDbType.String).Value = AGENCE_ID
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.String).Value = NOM_CLIENT
        command.Parameters.Add("@value6", MySqlDbType.Date).Value = DATE_ENTTRE
        command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = HEURE_ENTREE
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_SORTIE
        command.Parameters.Add("@value9", MySqlDbType.DateTime).Value = HEURE_SORTIE
        command.Parameters.Add("@value10", MySqlDbType.Int32).Value = ADULTES
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = NB_PERSONNES
        command.Parameters.Add("@value12", MySqlDbType.Int32).Value = ENFANTS
        command.Parameters.Add("@value13", MySqlDbType.Int32).Value = RECEVOIR_EMAIL
        command.Parameters.Add("@value14", MySqlDbType.Int32).Value = RECEVOIR_SMS
        command.Parameters.Add("@value15", MySqlDbType.Int32).Value = ETAT_RESERVATION
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = HEURE_CREATION
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = MONTANT_TOTAL_CAUTION
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = MOTIF_ETAT
        command.Parameters.Add("@value20", MySqlDbType.Date).Value = DATE_ETAT
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = GROUPE
        command.Parameters.Add("@DEPOT_DE_GARANTIE", MySqlDbType.Double).Value = DEPOT_DE_GARANTIE
        command.Parameters.Add("@DAY_USE", MySqlDbType.Int64).Value = DAY_USE
        command.Parameters.Add("@MENSUEL", MySqlDbType.Int64).Value = MENSUEL
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = PETIT_DEJEUNER_ROUTAGE
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CHAMBRE_ROUTAGE
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = VENANT_DE
        command.Parameters.Add("@value27", MySqlDbType.VarChar).Value = SE_RENDANT_A
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = RAISON
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = SOURCE_RESERVATION
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = ROUTAGE
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = ETAT_NOTE_RESERVATION
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NOM_ENTREPRISE
        command.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = TYPE_CHAMBRE

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

    Public Function updatePetitDejeuner(ByVal PETIT_DEJEUNER As Double, ByVal CODE_RESERVATION As String, ByVal TABLE As String, ByVal AFFICHER_PRIX As Integer, ByVal BFK_COST As Double) As Boolean

        Dim updateQuery As String = "UPDATE " & TABLE & " SET `PETIT_DEJEUNER` = @PETIT_DEJEUNER, AFFICHER_PRIX=@AFFICHER_PRIX, BFK_COST=@BFK_COST WHERE CODE_RESERVATION = @CODE_RESERVATION"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@PETIT_DEJEUNER", MySqlDbType.VarChar).Value = PETIT_DEJEUNER
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@AFFICHER_PRIX", MySqlDbType.Int32).Value = AFFICHER_PRIX
        command.Parameters.Add("@BFK_COST", MySqlDbType.Double).Value = BFK_COST

        'command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = DATE_ETAT
        'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

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
    Public Function updateReservation(ByVal CODE_RESERVATION As String, ByVal CLIENT_ID As String, ByVal UTILISATEUR_ID As String, ByVal CHAMBRE_ID As String, ByVal AGENCE_ID As String, ByVal NOM_CLIENT As String, ByVal DATE_ENTTRE As Date, ByVal HEURE_ENTREE As DateTime, ByVal DATE_SORTIE As Date, ByVal HEURE_SORTIE As DateTime, ByVal ADULTES As Integer, ByVal NB_PERSONNES As Integer, ByVal ENFANTS As Integer, ByVal RECEVOIR_EMAIL As String, ByVal RECEVOIR_SMS As Integer, ByVal ETAT_RESERVATION As Integer, ByVal DATE_CREATION As Date, ByVal HEURE_CREATION As DateTime, ByVal MONTANT_TOTAL_CAUTION As Double, ByVal MOTIF_ETAT As String, ByVal DATE_ETAT As Date, ByVal MONTANT_ACCORDE As Double, ByVal GROUPE As String, ByVal DEPOT_DE_GARANTIE As Double, ByVal DAY_USE As Integer, ByVal MENSUEL As Integer, ByVal BC_ENTREPRISE As String, ByVal TYPE_CHAMBRE As String, Optional ByVal TYPE As String = "chambre", Optional ByVal PETIT_DEJEUNER_ROUTAGE As Double = 0, Optional ByVal CHAMBRE_ROUTAGE As String = "", Optional ByVal VENANT_DE As String = "", Optional ByVal SE_RENDANT_A As String = "", Optional ByVal RAISON As String = "", Optional ByVal SOURCE_RESERVATION As String = "", Optional ByVal ROUTAGE As String = "NON", Optional ByVal ETAT_NOTE_RESERVATION As String = "", Optional ByVal CODE_ENTREPRISE As String = "", Optional ByVal NOM_ENTREPRISE As String = "") As Boolean

        Dim updateQuery As String = "UPDATE `reservation` SET `CODE_RESERVATION`=@value1,`CLIENT_ID`=@value2,`UTILISATEUR_ID`=@value3,`CHAMBRE_ID`=@value4,`AGENCE_ID`=@value5,`NOM_CLIENT`=@NOM_CLIENT,`DATE_ENTTRE`=@value6,`HEURE_ENTREE`=@value7,`DATE_SORTIE`=@value8,`HEURE_SORTIE`=@value9,`ADULTES`=@value10,`NB_PERSONNES`=@value11,`ENFANTS`=@value12,`RECEVOIR_EMAIL`=@value13,`RECEVOIR_SMS`=@value14,`ETAT_RESERVATION`=@value15,`DATE_CREATION`=@value16,`HEURE_CREATION`=@value17,`MONTANT_TOTAL_CAUTION`=@value18,`MOTIF_ETAT`=@value19,`DATE_ETAT`=@value20,`MONTANT_ACCORDE`=@value21,`GROUPE`=@value22, DEPOT_DE_GARANTIE=@DEPOT_DE_GARANTIE , DAY_USE=@DAY_USE, MENSUEL=@MENSUEL, BC_ENTREPRISE=@BC_ENTREPRISE, TYPE_CHAMBRE=@TYPE_CHAMBRE, `TYPE`=@value23, PETIT_DEJEUNER_ROUTAGE=@value24, CHAMBRE_ROUTAGE=@value25, VENANT_DE=@value26, SE_RENDANT_A=@value27, RAISON=@value28, SOURCE_RESERVATION=@value29, ROUTAGE=@value30 , ETAT_NOTE_RESERVATION = @value31 , CODE_ENTREPRISE=@value32 , NOM_ENTREPRISE = @value33 WHERE CODE_RESERVATION=@CODE_RESERVATION"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CLIENT_ID
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@BC_ENTREPRISE", MySqlDbType.VarChar).Value = BC_ENTREPRISE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = UTILISATEUR_ID
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CHAMBRE_ID
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = AGENCE_ID
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.String).Value = NOM_CLIENT
        command.Parameters.Add("@value6", MySqlDbType.Date).Value = DATE_ENTTRE
        command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = HEURE_ENTREE
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_SORTIE
        command.Parameters.Add("@value9", MySqlDbType.DateTime).Value = HEURE_SORTIE
        command.Parameters.Add("@value10", MySqlDbType.Int32).Value = ADULTES
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = NB_PERSONNES
        command.Parameters.Add("@value12", MySqlDbType.Int32).Value = ENFANTS
        command.Parameters.Add("@value13", MySqlDbType.Int32).Value = RECEVOIR_EMAIL
        command.Parameters.Add("@value14", MySqlDbType.Int32).Value = RECEVOIR_SMS
        command.Parameters.Add("@value15", MySqlDbType.Int32).Value = ETAT_RESERVATION
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value17", MySqlDbType.DateTime).Value = HEURE_CREATION
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = MONTANT_TOTAL_CAUTION
        command.Parameters.Add("@value19", MySqlDbType.String).Value = MOTIF_ETAT
        command.Parameters.Add("@value20", MySqlDbType.Date).Value = DATE_ETAT
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value22", MySqlDbType.String).Value = GROUPE
        command.Parameters.Add("@value23", MySqlDbType.String).Value = TYPE
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = PETIT_DEJEUNER_ROUTAGE
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CHAMBRE_ROUTAGE
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = VENANT_DE
        command.Parameters.Add("@value27", MySqlDbType.VarChar).Value = SE_RENDANT_A
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = RAISON
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = SOURCE_RESERVATION
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = ROUTAGE
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = ETAT_NOTE_RESERVATION
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NOM_ENTREPRISE

        command.Parameters.Add("@DEPOT_DE_GARANTIE", MySqlDbType.Double).Value = DEPOT_DE_GARANTIE
        command.Parameters.Add("@DAY_USE", MySqlDbType.Int64).Value = DAY_USE
        command.Parameters.Add("@MENSUEL", MySqlDbType.Int64).Value = MENSUEL
        command.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = TYPE_CHAMBRE

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

    Public Function reservationAllReadyExist(ByVal TABLE_NAME As String, ByVal CODE_RESERVATION As String, ByVal CLIENT_ID As String, ByVal UTILISATEUR_ID As String, ByVal CHAMBRE_ID As String, ByVal AGENCE_ID As String, ByVal NOM_CLIENT As String, ByVal DATE_ENTTRE As Date, ByVal HEURE_ENTREE As DateTime, ByVal DATE_SORTIE As Date, ByVal HEURE_SORTIE As DateTime, ByVal ADULTES As Integer, ByVal NB_PERSONNES As Integer, ByVal ENFANTS As Integer, ByVal RECEVOIR_EMAIL As String, ByVal RECEVOIR_SMS As Integer, ByVal ETAT_RESERVATION As Integer, ByVal DATE_CREATION As Date, ByVal HEURE_CREATION As DateTime, ByVal MONTANT_TOTAL_CAUTION As Double, ByVal MOTIF_ETAT As String, ByVal DATE_ETAT As Date, ByVal MONTANT_ACCORDE As Double, ByVal GROUPE As String, ByVal DEPOT_DE_GARANTIE As Double, ByVal DAY_USE As Integer, ByVal MENSUEL As Integer, ByVal BC_ENTREPRISE As String, ByVal TYPE_CHAMBRE As String, Optional ByVal TYPE As String = "chambre", Optional ByVal PETIT_DEJEUNER_ROUTAGE As Double = 0, Optional ByVal CHAMBRE_ROUTAGE As String = "", Optional ByVal VENANT_DE As String = "", Optional ByVal SE_RENDANT_A As String = "", Optional ByVal RAISON As String = "", Optional ByVal SOURCE_RESERVATION As String = "", Optional ByVal ROUTAGE As String = "NON", Optional ByVal ETAT_NOTE_RESERVATION As String = "", Optional ByVal CODE_ENTREPRISE As String = "", Optional ByVal NOM_ENTREPRISE As String = "") As Boolean

        'SELECT `CODE_RESERVATION`,`CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`,`DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `TYPE`, `SOLDE_RESERVATION`, `SOURCE_RESERVATION` , `PETIT_DEJEUNER_ROUTAGE` , `CHAMBRE_ROUTAGE`,`VENANT_DE`,`SE_RENDANT_A`,`RAISON`,`ROUTAGE`, `ETAT_NOTE_RESERVATION`,`CODE_ENTREPRISE`,`NOM_ENTREPRISE`,`AFFICHER_PRIX`,`DEPOT_DE_GARANTIE`, `DAY_USE`, `BC_ENTREPRISE`, `TYPE_CHAMBRE` FROM reservation WHERE CODE_RESERVATION = @CODE_RESERVATION "

        Dim existQuery As String = "SELECT * FROM " & TABLE_NAME & " WHERE CHAMBRE_ID = @CHAMBRE_ID AND ETAT_RESERVATION = @ETAT_RESERVATION ORDER BY ID_RESERVATION DESC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CHAMBRE_ID", MySqlDbType.VarChar).Value = CHAMBRE_ID
        command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int64).Value = ETAT_RESERVATION

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    'insert a new entry
    Public Function insertReservationConf(ByVal CODE_RESERVATION As String, ByVal CLIENT_ID As String, ByVal UTILISATEUR_ID As String, ByVal CHAMBRE_ID As String, ByVal AGENCE_ID As String, ByVal NOM_CLIENT As String, ByVal DATE_ENTTRE As Date, ByVal HEURE_ENTREE As DateTime, ByVal DATE_SORTIE As Date, ByVal HEURE_SORTIE As DateTime, ByVal ADULTES As Integer, ByVal NB_PERSONNES As Integer, ByVal ENFANTS As Integer, ByVal RECEVOIR_EMAIL As String, ByVal RECEVOIR_SMS As Integer, ByVal ETAT_RESERVATION As Integer, ByVal DATE_CREATION As Date, ByVal HEURE_CREATION As DateTime, ByVal MONTANT_TOTAL_CAUTION As Double, ByVal MOTIF_ETAT As String, ByVal DATE_ETAT As Date, ByVal MONTANT_ACCORDE As Double, ByVal GROUPE As String, ByVal DEPOT_DE_GARANTIE As Double, ByVal DAY_USE As Integer, ByVal MENSUEL As Integer, ByVal BC_ENTREPRISE As String, ByVal TYPE_CHAMBRE As String, Optional ByVal TYPE As String = "chambre", Optional ByVal PETIT_DEJEUNER_ROUTAGE As Double = 0, Optional ByVal CHAMBRE_ROUTAGE As String = "", Optional ByVal VENANT_DE As String = "", Optional ByVal SE_RENDANT_A As String = "", Optional ByVal RAISON As String = "", Optional ByVal SOURCE_RESERVATION As String = "", Optional ByVal ROUTAGE As String = "NON", Optional ByVal ETAT_NOTE_RESERVATION As String = "", Optional ByVal CODE_ENTREPRISE As String = "", Optional ByVal NOM_ENTREPRISE As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `reserve_conf`(`CODE_RESERVATION`,`CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`,`DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `DEPOT_DE_GARANTIE`, `DAY_USE` , `MENSUEL`,`BC_ENTREPRISE`, `TYPE_CHAMBRE`, `TYPE`, `PETIT_DEJEUNER_ROUTAGE`, `CHAMBRE_ROUTAGE`,`VENANT_DE`, `SE_RENDANT_A`, `RAISON`, `SOURCE_RESERVATION`, `ROUTAGE`, `ETAT_NOTE_RESERVATION`,`CODE_ENTREPRISE`,`NOM_ENTREPRISE`) VALUES (@CODE_RESERVATION,@value2,@value3,@value4,@value5,@NOM_CLIENT,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22, @DEPOT_DE_GARANTIE, @DAY_USE, @MENSUEL, @BC_ENTREPRISE, @TYPE_CHAMBRE, @value23, @value24, @value25,   @value26, @value27, @value28, @value29, @value30, @value31, @value32, @value33)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        If Trim(CODE_RESERVATION).Equals("") Then
            CODE_RESERVATION = Functions.GeneratingRandomCodeWithSpecifications("reserve_conf", "RESA")
        End If

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CLIENT_ID
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@BC_ENTREPRISE", MySqlDbType.VarChar).Value = BC_ENTREPRISE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = UTILISATEUR_ID
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CHAMBRE_ID
        command.Parameters.Add("@value5", MySqlDbType.String).Value = AGENCE_ID
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.String).Value = NOM_CLIENT
        command.Parameters.Add("@value6", MySqlDbType.Date).Value = DATE_ENTTRE
        command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = HEURE_ENTREE
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_SORTIE
        command.Parameters.Add("@value9", MySqlDbType.DateTime).Value = HEURE_SORTIE
        command.Parameters.Add("@value10", MySqlDbType.Int32).Value = ADULTES
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = NB_PERSONNES
        command.Parameters.Add("@value12", MySqlDbType.Int32).Value = ENFANTS
        command.Parameters.Add("@value13", MySqlDbType.Int32).Value = RECEVOIR_EMAIL
        command.Parameters.Add("@value14", MySqlDbType.Int32).Value = RECEVOIR_SMS
        command.Parameters.Add("@value15", MySqlDbType.Int32).Value = ETAT_RESERVATION
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value17", MySqlDbType.Date).Value = HEURE_CREATION
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = MONTANT_TOTAL_CAUTION
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = MOTIF_ETAT
        command.Parameters.Add("@value20", MySqlDbType.Date).Value = DATE_ETAT
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = GROUPE
        command.Parameters.Add("@DEPOT_DE_GARANTIE", MySqlDbType.Double).Value = DEPOT_DE_GARANTIE
        command.Parameters.Add("@DAY_USE", MySqlDbType.Int64).Value = DAY_USE
        command.Parameters.Add("@MENSUEL", MySqlDbType.Int64).Value = MENSUEL
        command.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = PETIT_DEJEUNER_ROUTAGE
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CHAMBRE_ROUTAGE
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = VENANT_DE
        command.Parameters.Add("@value27", MySqlDbType.VarChar).Value = SE_RENDANT_A
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = RAISON
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = SOURCE_RESERVATION
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = ROUTAGE
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = ETAT_NOTE_RESERVATION
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NOM_ENTREPRISE

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
    Public Function updateReservationConf(ByVal CODE_RESERVATION As String, ByVal CLIENT_ID As String, ByVal UTILISATEUR_ID As String, ByVal CHAMBRE_ID As String, ByVal AGENCE_ID As String, ByVal NOM_CLIENT As String, ByVal DATE_ENTTRE As Date, ByVal HEURE_ENTREE As DateTime, ByVal DATE_SORTIE As Date, ByVal HEURE_SORTIE As DateTime, ByVal ADULTES As Integer, ByVal NB_PERSONNES As Integer, ByVal ENFANTS As Integer, ByVal RECEVOIR_EMAIL As String, ByVal RECEVOIR_SMS As Integer, ByVal ETAT_RESERVATION As Integer, ByVal ETAT_RESERVATION_NOTE As String, ByVal DATE_CREATION As Date, ByVal HEURE_CREATION As DateTime, ByVal MONTANT_TOTAL_CAUTION As Double, ByVal MOTIF_ETAT As String, ByVal DATE_ETAT As Date, ByVal MONTANT_ACCORDE As Double, ByVal GROUPE As String, ByVal DEPOT_DE_GARANTIE As Double, ByVal DAY_USE As Integer, ByVal MENSUEL As Integer, ByVal BC_ENTREPRISE As String, ByVal TYPE_CHAMBRE As String, Optional ByVal PETIT_DEJEUNER_ROUTAGE As Double = 0, Optional ByVal CHAMBRE_ROUTAGE As String = "", Optional ByVal VENANT_DE As String = "", Optional ByVal SE_RENDANT_A As String = "", Optional ByVal RAISON As String = "", Optional ByVal SOURCE_RESERVATION As String = "", Optional ByVal ROUTAGE As String = "NON", Optional ByVal ETAT_NOTE_RESERVATION As String = "", Optional ByVal CODE_ENTREPRISE As String = "", Optional ByVal NOM_ENTREPRISE As String = "") As Boolean

        Dim updateQuery As String = "UPDATE `reserve_conf` SET `CODE_RESERVATION`=@value1,`CLIENT_ID`=@value2,`UTILISATEUR_ID`=@value3,`CHAMBRE_ID`=@value4,`AGENCE_ID`=@value5,`NOM_CLIENT`=@NOM_CLIENT,`DATE_ENTTRE`=@value6,`HEURE_ENTREE`=@value7,`DATE_SORTIE`=@value8,`HEURE_SORTIE`=@value9,`ADULTES`=@value10,`NB_PERSONNES`=@value11,`ENFANTS`=@value12,`RECEVOIR_EMAIL`=@value13,`RECEVOIR_SMS`=@value14,`ETAT_RESERVATION`=@value15,`ETAT_NOTE_RESERVATION`=@ETAT_NOTE_RESERVATION, `DATE_CREATION`=@value16,`HEURE_CREATION`=@value17,`MONTANT_TOTAL_CAUTION`=@value18,`MOTIF_ETAT`=@value19,`DATE_ETAT`=@value20,`MONTANT_ACCORDE`=@value21,`GROUPE`=@value22,DEPOT_DE_GARANTIE=@DEPOT_DE_GARANTIE, DAY_USE=@DAY_USE, MENSUEL=@MENSUEL,BC_ENTREPRISE =@BC_ENTREPRISE, TYPE_CHAMBRE =@TYPE_CHAMBRE, PETIT_DEJEUNER_ROUTAGE=@value23, CHAMBRE_ROUTAGE=@value24, VENANT_DE=@value25, SE_RENDANT_A=@value26, RAISON=@value27 , SOURCE_RESERVATION=@value28, ROUTAGE=@value29, CODE_ENTREPRISE=@value32 , NOM_ENTREPRISE = @value33 WHERE CODE_RESERVATION=@CODE_RESERVATION"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        If ETAT_NOTE_RESERVATION = "" Then
            ETAT_NOTE_RESERVATION = ETAT_RESERVATION_NOTE
        End If

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CLIENT_ID
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@BC_ENTREPRISE", MySqlDbType.VarChar).Value = BC_ENTREPRISE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = UTILISATEUR_ID
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CHAMBRE_ID
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = AGENCE_ID
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.String).Value = NOM_CLIENT
        command.Parameters.Add("@value6", MySqlDbType.Date).Value = DATE_ENTTRE
        command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = HEURE_ENTREE
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_SORTIE
        command.Parameters.Add("@value9", MySqlDbType.DateTime).Value = HEURE_SORTIE
        command.Parameters.Add("@value10", MySqlDbType.Int32).Value = ADULTES
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = NB_PERSONNES
        command.Parameters.Add("@value12", MySqlDbType.Int32).Value = ENFANTS
        command.Parameters.Add("@value13", MySqlDbType.Int32).Value = RECEVOIR_EMAIL
        command.Parameters.Add("@value14", MySqlDbType.Int32).Value = RECEVOIR_SMS
        command.Parameters.Add("@value15", MySqlDbType.Int32).Value = ETAT_RESERVATION
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value17", MySqlDbType.DateTime).Value = HEURE_CREATION
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = MONTANT_TOTAL_CAUTION
        command.Parameters.Add("@value19", MySqlDbType.String).Value = MOTIF_ETAT
        command.Parameters.Add("@value20", MySqlDbType.Date).Value = DATE_ETAT
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@DEPOT_DE_GARANTIE", MySqlDbType.Double).Value = DEPOT_DE_GARANTIE
        command.Parameters.Add("@DAY_USE", MySqlDbType.Int64).Value = DAY_USE
        command.Parameters.Add("@MENSUEL", MySqlDbType.Int64).Value = MENSUEL
        command.Parameters.Add("@value22", MySqlDbType.String).Value = GROUPE
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = PETIT_DEJEUNER_ROUTAGE
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = CHAMBRE_ROUTAGE
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = VENANT_DE
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = SE_RENDANT_A
        command.Parameters.Add("@value27", MySqlDbType.VarChar).Value = RAISON
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = SOURCE_RESERVATION
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = ROUTAGE
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NOM_ENTREPRISE
        command.Parameters.Add("@ETAT_NOTE_RESERVATION", MySqlDbType.VarChar).Value = ETAT_NOTE_RESERVATION

        command.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
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

    'create a function to update the selected reservation used after migrating from reservation to reserve_conf table
    Public Function updateReservationConfCheckIn(ByVal CODE_RESERVATION As String) As Boolean

        Dim updateQuery As String = "UPDATE `reserve_conf` SET `CHECKIN`=@value2 WHERE CODE_RESERVATION=@CODE_RESERVATION"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = "OUI"

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

    'UPDATE RESERVATION ETAT_RESERVATION_NOTE
    Public Function updateEtatReservationNote(ByVal CODE_RESERVATION As String, ByVal TABLE As String, ByVal ETAT_NOTE_RESERVATION As String) As Boolean

        Dim updateQuery As String = "UPDATE " & TABLE & " SET `ETAT_NOTE_RESERVATION`=@ETAT_NOTE_RESERVATION WHERE CODE_RESERVATION=@CODE_RESERVATION"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@ETAT_NOTE_RESERVATION", MySqlDbType.VarChar).Value = ETAT_NOTE_RESERVATION

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
    'create a function to migrate from reservation to reservation conf reservation
    Public Function insertReservationMigration(ByVal CODE_RESERVATION As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `reserve_conf`(`CODE_RESERVATION`,`CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`,`DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `TYPE`, `SOLDE_RESERVATION`, `SOURCE_RESERVATION` ,`PETIT_DEJEUNER_ROUTAGE` , `CHAMBRE_ROUTAGE`,`VENANT_DE`, `SE_RENDANT_A`,`RAISON`,`ROUTAGE`, `ETAT_NOTE_RESERVATION`, `CODE_ENTREPRISE`,`NOM_ENTREPRISE`,`AFFICHER_PRIX`,`DEPOT_DE_GARANTIE`,`DAY_USE`, `MENSUEL`, `BC_ENTREPRISE`, `TYPE_CHAMBRE`, `LIEN_GOOGLE_MAP`, `BFK_COST`, `PETIT_DEJEUNER`) 
        SELECT `CODE_RESERVATION`,`CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`,`DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `TYPE`, `SOLDE_RESERVATION`, `SOURCE_RESERVATION` , `PETIT_DEJEUNER_ROUTAGE` , `CHAMBRE_ROUTAGE`,`VENANT_DE`,`SE_RENDANT_A`,`RAISON`,`ROUTAGE`, `ETAT_NOTE_RESERVATION`,`CODE_ENTREPRISE`,`NOM_ENTREPRISE`,`AFFICHER_PRIX`,`DEPOT_DE_GARANTIE`, `DAY_USE`, `MENSUEL`, `BC_ENTREPRISE`, `TYPE_CHAMBRE`, `LIEN_GOOGLE_MAP`, `BFK_COST`, `PETIT_DEJEUNER` FROM reservation WHERE CODE_RESERVATION = @CODE_RESERVATION "

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then

            'We update ETAT CONFIRMATION
            Dim updateQuery1 As String = "UPDATE `reserve_conf` SET `ETAT_RESERVATION`=@value2 WHERE CODE_RESERVATION=@CODE_RESERVATION"

            Dim command1 As New MySqlCommand(updateQuery1, GlobalVariable.connect)

            command1.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
            command1.Parameters.Add("@value2", MySqlDbType.VarChar).Value = 1

            'Opening the connection
            'connect.openConnection()

            'Excuting the command and testing if everything went on well
            If (command1.ExecuteNonQuery() = 1) Then
                'connect.closeConnection()
                Return True
            Else
                'connect.closeConnection()
                Return False
            End If

        Else
            'connect.closeConnection()
            Return False
        End If

    End Function


    'insert a new entry
    Public Function insertForfait(ByVal CODE_RESERVATION As String, ByVal NBRE__CAFE As Integer, ByVal PU_CAFE As Double, ByVal NBRE_DEJEUNER As Integer, ByVal PU_DEJEUNER As Double, ByVal NBRE_DINER As Integer, ByVal PU_DINER As Double, ByVal NBRE_TRAITEUR As Integer, ByVal PU_TRAITEUR As Double, ByVal DECORATION As Double, ByVal LOCATION_MATERIEL As Double, ByVal AUTRES As Double, ByVal CODE_EVENEMENT As String, ByVal LIBELLE_EVENEMENT As String, ByVal NBRE_GOUTER As Integer, ByVal PU_GOUTER As Double, ByVal NBRE_COCKTAIL As Integer, ByVal PU_COCKTAIL As Double, ByVal HEURE_PAUSE_CAFE As String, ByVal HEURE_PAUSE_DEJEUNER As String, ByVal HEURE_DINER As String, ByVal HEURE_GOUTER As String, ByVal HEURE_COCKTAIL As String, ByVal VIDEO_PROJ As Integer, ByVal SONO As Integer, ByVal COUVERTS As Integer, ByVal TABLE_CHAISE As Integer, ByVal EAU_PTE_QTE As Integer, ByVal EAU_PTE_MONTANT As Double, ByVal EAU_GRDE_QTE As Integer, ByVal EAU_GRDE_MONTANT As Double, ByVal BOISSONS_GAZEUSES_QTE As Integer, ByVal BOISSONS_GAZEUSES_MONTANT As Double, ByVal BIERES_QTE As Integer, ByVal BIERES_MONTANT As Double, ByVal VIN_ROUGE_QTE As Integer, ByVal VIN_ROUGE_MONTANT As Double, ByVal VIN_ROSE_QTE As Integer, ByVal VIN_ROSE_MONTANT As Double, ByVal BOISSONS_EXT_QTE As Integer, ByVal BOISSONS_EXT_MONTANT As Double, ByVal DROIT_DE_BOUCHON As Double, ByVal MISE_EN_PLACE As Integer, ByVal CLOISONNEMENT As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `forfait_salle`(`CODE_RESERVATION`, `NBRE__CAFE`, `PU_CAFE`, `NBRE_DEJEUNER`, `PU_DEJEUNER`, `NBRE_DINER`, `PU_DINER`, `NBRE_TRAITEUR`, `PU_TRAITEUR`, `DECORATION`, `LOCATION_MATERIEL`, `AUTRES`, `CODE_EVENEMENT`, `LIBELLE_EVENEMENT`, `NBRE_GOUTER`, `PU_GOUTER`, `NBRE_COCKTAIL`, `PU_COCKTAIL`, `HEURE_PAUSE_CAFE`, `HEURE_PAUSE_DEJEUNER`, `HEURE_DINER`, `HEURE_GOUTER`, `HEURE_COCKTAIL`, `VIDEO_PROJ`, `SONO`, `COUVERTS`, `TABLE_CHAISE`, `EAU_PTE_QTE`, `EAU_PTE_MONTANT`, `EAU_GRDE_QTE`, `EAU_GRDE_MONTANT`, `BOISSONS_GAZEUSES_QTE`, `BOISSONS_GAZEUSES_MONTANT`, `BIERES_QTE`, `BIERES_MONTANT`, `VIN_ROUGE_QTE`, `VIN_ROUGE_MONTANT`, `VIN_ROSE_QTE`, `VIN_ROSE_MONTANT`, `BOISSONS_EXT_QTE`, `BOISSONS_EXT_MONTANT`, `DROIT_DE_BOUCHON`, `MISE_EN_PLACE`, `CLOISONNEMENT` ) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9, @value10, @value11, @value12, @value13, @value14, @value15, @value16, @value17, @value18, @value19, @value20,@value21,@value22,@value23,@value24, @value25,@value26,@value27,@value28, @value29,@value30,@value31,@value32,@value33,@value34,@value35,@value36,@value37,@value38,@value39,@value40,@value41,@value42,@value43,@value44,@value45)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)


        command.Parameters.Add("@value2", MySqlDbType.String).Value = CODE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.Int32).Value = NBRE__CAFE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = PU_CAFE
        command.Parameters.Add("@value5", MySqlDbType.Int32).Value = NBRE_DEJEUNER
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = PU_DEJEUNER
        command.Parameters.Add("@value7", MySqlDbType.Int32).Value = NBRE_DINER
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PU_DINER
        command.Parameters.Add("@value9", MySqlDbType.Int32).Value = NBRE_TRAITEUR
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = PU_TRAITEUR
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = DECORATION

        command.Parameters.Add("@value12", MySqlDbType.Double).Value = LOCATION_MATERIEL
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = AUTRES
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_EVENEMENT
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = LIBELLE_EVENEMENT

        command.Parameters.Add("@value16", MySqlDbType.Int32).Value = NBRE_GOUTER
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = PU_GOUTER
        command.Parameters.Add("@value18", MySqlDbType.Int32).Value = NBRE_COCKTAIL
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = PU_COCKTAIL

        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = HEURE_PAUSE_CAFE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = HEURE_PAUSE_DEJEUNER
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = HEURE_DINER
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = HEURE_GOUTER
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = HEURE_COCKTAIL
        command.Parameters.Add("@value25", MySqlDbType.Int64).Value = VIDEO_PROJ
        command.Parameters.Add("@value26", MySqlDbType.Int64).Value = SONO
        command.Parameters.Add("@value27", MySqlDbType.Int64).Value = COUVERTS
        command.Parameters.Add("@value28", MySqlDbType.Int64).Value = TABLE_CHAISE
        command.Parameters.Add("@value29", MySqlDbType.Int64).Value = EAU_PTE_QTE

        command.Parameters.Add("@value30", MySqlDbType.Double).Value = EAU_PTE_MONTANT
        command.Parameters.Add("@value31", MySqlDbType.Int64).Value = EAU_GRDE_QTE
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = EAU_GRDE_MONTANT
        command.Parameters.Add("@value33", MySqlDbType.Int64).Value = BOISSONS_GAZEUSES_QTE
        command.Parameters.Add("@value34", MySqlDbType.Double).Value = BOISSONS_GAZEUSES_MONTANT
        command.Parameters.Add("@value35", MySqlDbType.Int64).Value = BIERES_QTE
        command.Parameters.Add("@value36", MySqlDbType.Double).Value = BIERES_MONTANT
        command.Parameters.Add("@value37", MySqlDbType.Int64).Value = VIN_ROUGE_QTE
        command.Parameters.Add("@value38", MySqlDbType.Double).Value = VIN_ROUGE_MONTANT

        command.Parameters.Add("@value39", MySqlDbType.Int64).Value = VIN_ROSE_QTE
        command.Parameters.Add("@value40", MySqlDbType.Double).Value = VIN_ROSE_MONTANT
        command.Parameters.Add("@value41", MySqlDbType.Int64).Value = BOISSONS_EXT_QTE
        command.Parameters.Add("@value42", MySqlDbType.Double).Value = BOISSONS_EXT_MONTANT
        command.Parameters.Add("@value43", MySqlDbType.Double).Value = DROIT_DE_BOUCHON
        command.Parameters.Add("@value44", MySqlDbType.Int64).Value = MISE_EN_PLACE
        command.Parameters.Add("@value45", MySqlDbType.Int64).Value = CLOISONNEMENT

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

    'insert a new entry
    Public Function updateForfait(ByVal CODE_RESERVATION As String, ByVal NBRE__CAFE As Integer, ByVal PU_CAFE As Double, ByVal NBRE_DEJEUNER As Integer, ByVal PU_DEJEUNER As Double, ByVal NBRE_DINER As Integer, ByVal PU_DINER As Double, ByVal NBRE_TRAITEUR As Integer, ByVal PU_TRAITEUR As Double, ByVal DECORATION As Double, ByVal LOCATION_MATERIEL As Double, ByVal AUTRES As Double, ByVal CODE_EVENEMENT As String, ByVal LIBELLE_EVENEMENT As String, ByVal NBRE_GOUTER As Integer, ByVal PU_GOUTER As Double, ByVal NBRE_COCKTAIL As Integer, ByVal PU_COCKTAIL As Double, ByVal HEURE_PAUSE_CAFE As String, ByVal HEURE_PAUSE_DEJEUNER As String, ByVal HEURE_DINER As String, ByVal HEURE_GOUTER As String, ByVal HEURE_COCKTAIL As String, ByVal VIDEO_PROJ As Integer, ByVal SONO As Integer, ByVal COUVERTS As Integer, ByVal TABLE_CHAISE As Integer, ByVal EAU_PTE_QTE As Integer, ByVal EAU_PTE_MONTANT As Double, ByVal EAU_GRDE_QTE As Integer, ByVal EAU_GRDE_MONTANT As Double, ByVal BOISSONS_GAZEUSES_QTE As Integer, ByVal BOISSONS_GAZEUSES_MONTANT As Double, ByVal BIERES_QTE As Integer, ByVal BIERES_MONTANT As Double, ByVal VIN_ROUGE_QTE As Integer, ByVal VIN_ROUGE_MONTANT As Double, ByVal VIN_ROSE_QTE As Integer, ByVal VIN_ROSE_MONTANT As Double, ByVal BOISSONS_EXT_QTE As Integer, ByVal BOISSONS_EXT_MONTANT As Double, ByVal DROIT_DE_BOUCHON As Double, ByVal MISE_EN_PLACE As Integer, ByVal CLOISONNEMENT As Integer) As Boolean

        Dim insertQuery As String = "UPDATE `forfait_salle` SET `NBRE__CAFE`=@value3,`PU_CAFE`=@value4,`NBRE_DEJEUNER`=@value5,`PU_DEJEUNER`=@value6,`NBRE_DINER`=@value7,`PU_DINER`=@value8,`NBRE_TRAITEUR`=@value9,`PU_TRAITEUR`=@value10,`DECORATION`=@value11, `LOCATION_MATERIEL`=@value12, `AUTRES`=@value13, `CODE_EVENEMENT`=@value14, `LIBELLE_EVENEMENT`=@value15, `NBRE_GOUTER`=@value16 , `PU_GOUTER`=@value17 , `NBRE_COCKTAIL`=@value18 , `PU_COCKTAIL`=@value19, `HEURE_PAUSE_CAFE`=@value20,`HEURE_PAUSE_DEJEUNER`=@value21,`HEURE_DINER`=@value22,`HEURE_GOUTER`=@value23,`HEURE_COCKTAIL`=@value24,`VIDEO_PROJ`=@value25,`SONO`=@value26,`COUVERTS`=@value27,`TABLE_CHAISE`=@value28,`EAU_PTE_QTE`=@value29,`EAU_PTE_MONTANT`=@value30,`EAU_GRDE_QTE`=@value31,`EAU_GRDE_MONTANT`=@value32,`BOISSONS_GAZEUSES_QTE`=@value33,`BOISSONS_GAZEUSES_MONTANT`=@value34,`BIERES_QTE`=@value35,`BIERES_MONTANT`=@value36,`VIN_ROUGE_QTE`=@value37,`VIN_ROUGE_MONTANT`=@value38,`VIN_ROSE_QTE`=@value39,`VIN_ROSE_MONTANT`=@value40,`BOISSONS_EXT_QTE`=@value41,`BOISSONS_EXT_MONTANT`=@value42,`DROIT_DE_BOUCHON`=@value43,`MISE_EN_PLACE`=@value44,`CLOISONNEMENT`=@value45  WHERE CODE_RESERVATION=@value2"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.String).Value = CODE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.Int32).Value = NBRE__CAFE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = PU_CAFE
        command.Parameters.Add("@value5", MySqlDbType.Int32).Value = NBRE_DEJEUNER
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = PU_DEJEUNER
        command.Parameters.Add("@value7", MySqlDbType.Int32).Value = NBRE_DINER
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PU_DINER
        command.Parameters.Add("@value9", MySqlDbType.Int32).Value = NBRE_TRAITEUR
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = PU_TRAITEUR
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = DECORATION

        command.Parameters.Add("@value12", MySqlDbType.Double).Value = LOCATION_MATERIEL
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = AUTRES
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_EVENEMENT
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = LIBELLE_EVENEMENT

        command.Parameters.Add("@value16", MySqlDbType.Int32).Value = NBRE_GOUTER
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = PU_GOUTER
        command.Parameters.Add("@value18", MySqlDbType.Int32).Value = NBRE_COCKTAIL
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = PU_COCKTAIL

        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = HEURE_PAUSE_CAFE
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = HEURE_PAUSE_DEJEUNER
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = HEURE_DINER
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = HEURE_GOUTER
        command.Parameters.Add("@value24", MySqlDbType.VarChar).Value = HEURE_COCKTAIL
        command.Parameters.Add("@value25", MySqlDbType.Int64).Value = VIDEO_PROJ
        command.Parameters.Add("@value26", MySqlDbType.Int64).Value = SONO
        command.Parameters.Add("@value27", MySqlDbType.Int64).Value = COUVERTS
        command.Parameters.Add("@value28", MySqlDbType.Int64).Value = TABLE_CHAISE
        command.Parameters.Add("@value29", MySqlDbType.Int64).Value = EAU_PTE_QTE

        command.Parameters.Add("@value30", MySqlDbType.Double).Value = EAU_PTE_MONTANT
        command.Parameters.Add("@value31", MySqlDbType.Int64).Value = EAU_GRDE_QTE
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = EAU_GRDE_MONTANT
        command.Parameters.Add("@value33", MySqlDbType.Int64).Value = BOISSONS_GAZEUSES_QTE
        command.Parameters.Add("@value34", MySqlDbType.Double).Value = BOISSONS_GAZEUSES_MONTANT
        command.Parameters.Add("@value35", MySqlDbType.Int64).Value = BIERES_QTE
        command.Parameters.Add("@value36", MySqlDbType.Double).Value = BIERES_MONTANT
        command.Parameters.Add("@value37", MySqlDbType.Int64).Value = VIN_ROUGE_QTE
        command.Parameters.Add("@value38", MySqlDbType.Double).Value = VIN_ROUGE_MONTANT

        command.Parameters.Add("@value39", MySqlDbType.Int64).Value = VIN_ROSE_QTE
        command.Parameters.Add("@value40", MySqlDbType.Double).Value = VIN_ROSE_MONTANT
        command.Parameters.Add("@value41", MySqlDbType.Int64).Value = BOISSONS_EXT_QTE
        command.Parameters.Add("@value42", MySqlDbType.Double).Value = BOISSONS_EXT_MONTANT
        command.Parameters.Add("@value43", MySqlDbType.Double).Value = DROIT_DE_BOUCHON
        command.Parameters.Add("@value44", MySqlDbType.Int64).Value = MISE_EN_PLACE
        command.Parameters.Add("@value45", MySqlDbType.Int64).Value = CLOISONNEMENT
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

    'MISE A JOUR DU SOLDE DU CLIENT LIE UNE RESERVATION
    Public Function updateSoldeReservation(ByVal CODE_RESERVATION As String, ByVal TABLE_TO_UPDATE As String, ByVal SOLDE_RESERVATION As Double) As Boolean

        Dim insertQuery As String = "UPDATE " & TABLE_TO_UPDATE & " SET `SOLDE_RESERVATION`=@SOLDE_RESERVATION WHERE CODE_RESERVATION=@value2"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.String).Value = CODE_RESERVATION
        command.Parameters.Add("@SOLDE_RESERVATION", MySqlDbType.Double).Value = SOLDE_RESERVATION

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

    'Mise ajours des Des numero de chambre et et code de reservation 
    'create a function to update the selected reservation used after migrating from reservation to reservation table
    Public Function DuplicateReservation(ByVal NEW_CODE_RESERVATION As String, ByVal ACTUAL_RESERVATION_ID As Integer, ByVal Table As String) As Boolean

        Dim updateQuery As String = "UPDATE " & Table & " SET `CHAMBRE_ID`=@CHAMBRE_ID, CODE_RESERVATION = @NEW_CODE_RESERVATION WHERE ID_RESERVATION = @ACTUAL_RESERVATION_ID"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NEW_CODE_RESERVATION", MySqlDbType.VarChar).Value = NEW_CODE_RESERVATION
        command.Parameters.Add("@CHAMBRE_ID", MySqlDbType.VarChar).Value = "-"
        command.Parameters.Add("@ACTUAL_RESERVATION_ID", MySqlDbType.Int32).Value = ACTUAL_RESERVATION_ID

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

    'ANNULATION D'UNE RESERVATION

    Public Function AnnulationDeReservation(ByVal CODE_RESERVATION As String, ByVal TABLE_TO_UPDATE As String, ByVal ETAT_RESERVATION As Integer, ByVal STATUT_RESERVATION As String) As Boolean

        Dim insertQuery As String = "UPDATE " & TABLE_TO_UPDATE & " SET `ETAT_RESERVATION`=@ETAT_RESERVATION, ETAT_NOTE_RESERVATION=@STATUT_RESERVATION WHERE CODE_RESERVATION=@value2"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        'command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.String).Value = Functions.GeneratingRandomCode("reservation", "ANN")
        command.Parameters.Add("@value2", MySqlDbType.String).Value = CODE_RESERVATION
        command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = ETAT_RESERVATION
        command.Parameters.Add("@STATUT_RESERVATION", MySqlDbType.VarChar).Value = STATUT_RESERVATION

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

    'Check if element Code Exist
    Public Function ChambreDeRoutage(ByVal CODE_CHAMBRE As String) As DataTable
        Dim existQuery As String = "SELECT * From reserve_conf WHERE CHAMBRE_ID = @code AND ETAT_RESERVATION = 1 ORDER BY ID_RESERVATION DESC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@code", MySqlDbType.VarChar).Value = CODE_CHAMBRE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            'GlobalVariable.'connect.closeConnection()
            Return table
        Else
            'GlobalVariable.'connect.closeConnection()
            Return table
        End If

    End Function

    'GESTION DES SOURCE DE RESERVATION

    'insert a new entry

    Public Function insertSourceReservation(ByVal CODE_SOURCE_RESERVATION As String, ByVal SOURCE_RESERVATION As String, ByVal TAUX_COMMISSION As Double, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR As String, ByVal COULEUR As String, ByVal COULEUR_FONT As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `source_reservation`(`CODE_SOURCE_RESERVATION`, `SOURCE_RESERVATION`, `TAUX_COMMISSION`, `CODE_UTILISATEUR`, `DATE_CREATION`,`COULEUR`, `COULEUR_FONT`) VALUES (@value1,@value2,@value3,@value4,@value5, @value6, @value7)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_SOURCE_RESERVATION
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = SOURCE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = TAUX_COMMISSION
        command.Parameters.Add("@value4", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = COULEUR
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = COULEUR_FONT

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

    'Create a function to check if already exists
    Public Function sourceReservationExists(ByVal CODE_SOURCE_RESERVATION) As Boolean

        Dim existQuery As String = "SELECT * From source_reservation WHERE CODE_SOURCE_RESERVATION=@CODE_SOURCE_RESERVATION"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_SOURCE_RESERVATION", MySqlDbType.VarChar).Value = CODE_SOURCE_RESERVATION

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    'create a function to update the selected user
    Public Function updateSourceReservation(ByVal CODE_SOURCE_RESERVATION As String, ByVal SOURCE_RESERVATION As String, ByVal TAUX_COMMISSION As Double, ByVal COULEUR As String, ByVal COULEUR_FONT As String) As Boolean

        Dim insertQuery As String = "UPDATE `source_reservation` SET `SOURCE_RESERVATION`=@value3,`TAUX_COMMISSION`=@value4, `COULEUR`=@COULEUR, COULEUR_FONT=@COULEUR_FONT WHERE CODE_SOURCE_RESERVATION=@CODE_SOURCE_RESERVATION"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = SOURCE_RESERVATION
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = TAUX_COMMISSION
        command.Parameters.Add("@CODE_SOURCE_RESERVATION", MySqlDbType.VarChar).Value = CODE_SOURCE_RESERVATION
        command.Parameters.Add("@COULEUR", MySqlDbType.VarChar).Value = COULEUR
        command.Parameters.Add("@COULEUR_FONT", MySqlDbType.VarChar).Value = COULEUR_FONT

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

    Public Sub updateReservationApresTarificationDynamique(ByVal MONTANT_ACCORDE As Double, ByVal CODE_RESERVATION As String)

        Dim insertQuery As String = "UPDATE `reserve_conf` SET `MONTANT_ACCORDE`=@MONTANT_ACCORDE WHERE CODE_RESERVATION=@CODE_RESERVATION"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@MONTANT_ACCORDE", MySqlDbType.Double).Value = MONTANT_ACCORDE

        command.ExecuteNonQuery()

    End Sub

    Public Function insertMainCouranteJournaliere(ByVal mainCouranteJournaliere As DataTable) As Boolean

        Dim insertQuery As String = "INSERT INTO `main_courante_journaliere`(`CODE_MAIN_COURANTE_JOURNALIERE`, `DATE_MAIN_COURANTE`, `CODE_CHAMBRE`, `MONTANT_ACCORDE`, `ETAT_CHAMBRE`, 
        `NOM_CLIENT`, `PDJ`, `DEJEUNER`, `DINER`, `CAFE`, `BAR`, `CAVE`, `AUTRE`, `SOUS_TOTAL1`, `LOCATION`, `TELE`, `FAX`, `LINGE`, `DIVERS`, `SOUS_TOTAL2`, `TOTAL_JOUR`, `REPORT_VEILLE`, 
        `TOTAL_GENERAL`, `NUM_RESERVATION`, `DEDUCTION`, `ENCAISSEMENT_ESPECE`, `ENCAISSEMENT_CHEQUE`, `ENCAISSEMENT_CARTE_CREDIT`, `DEBITEUR`, `ARRHES`, `A_REPORTER`, `OBSERVATIONS`, 
        `TYPE_CHAMBRE`, `CODE_CLIENT`, `INDICE_FREQUENTATION`, `INDICE_FREQUENTATION_PCT`, `TAUX_OCCUPATION`, `TAUX_OCCUPATION_PCT`, `CLIENTS_ATTENDUS`, `CLIENTS_EN_CHAMBRE`, 
        `CHAMBRES_DISPONIBLES`, `TOTAL_HORS_SERVICE`, `CHAMBRES_HORS_SERVICE`, `TOTAL_FICTIVES`, `CHAMBRES_FICTIVES`, `NOMBRE_MESSAGES`, `TOTAL_GRATUITES`, `CHAMBRES_GRATUITES`,
        `TOTAL_NON_FACTUREES`, `CHAMBRES_NON_FACTUREES`, `CODE_AGENCE`, `ETAT_MAIN_COURANTE`, `BAR_RESTAURANT`, `SERVICES`, `SALON_DE_BEAUTE`, `BOUTIQE`, `CYBERCAFE`, `AUTRES`, `TYPE`, 
        `SPORTS`, `LOISIRS`, `KIOSQUE_A_JOURNAUX`, `BLANCHISSERIE`)
        VALUES (@CODE_MAIN_COURANTE_JOURNALIERE, @DATE_MAIN_COURANTE, @CODE_CHAMBRE,@MONTANT_ACCORDE, @ETAT_CHAMBRE, @NOM_CLIENT, @PDJ, @DEJEUNER, @DINER, @CAFE, @BAR, @CAVE,
        @AUTRE, @value15, @value16, @value17, @value18, @value19, @value20, @value21, @value22, @value23, @value24, @value25, @value26, @value27, @value28, @value29, @value30, 
        @value31, @value32, @value33, @value34, @value35, @value36, @value37, @value38, @value39, @value40, @value41, @value42, @value43, @value44, @value45, @value46, @value47, 
        @value48, @value49, @value50, @value51, @value52, @value53, @value54, @value55, @value56, @value57, @value58, @value59, @value60 , @SPORTS, @LOISIRS, @KIOSQUE_A_JOURNAUX, 
        @BLANCHISSERIE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        '1- COPIE 
        '2- CHANGEMENT DU CODE DE LA NOUVELLE MAIN COURANTE

        'command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
        command.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = Functions.GeneratingRandomCodeWithSpecifications("main_courante_journaliere", "MJ")

        'command.Parameters.Add("@value3", MySqlDbType.Date).Value = mainCouranteJournaliere.Rows(0)("DATE_MAIN_COURANTE")
        Dim nouvellEDateDeTravail As Date = GlobalVariable.DateDeTravail.AddDays(1)
        command.Parameters.Add("@DATE_MAIN_COURANTE", MySqlDbType.Date).Value = nouvellEDateDeTravail

        'command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("CODE_CHAMBRE")

        Dim infoResa As DataTable = Functions.getElementByCode(mainCouranteJournaliere.Rows(0)("NUM_RESERVATION"), "reserve_conf", "CODE_RESERVATION")

        Dim CODE_CHAMBRE As String = ""
        Dim MENSUEL As Integer = 0
        Dim MONTANT_ACCORDE_DANS_RESERVATION As Double = 0
        Dim DATE_SORTIE As Date

        'POUR EVITER QUE LE NUMERO DE CHAMBRE NE SOIT VIDE
        If Not Trim(mainCouranteJournaliere.Rows(0)("CODE_CHAMBRE")) = "" Then
            CODE_CHAMBRE = mainCouranteJournaliere.Rows(0)("CODE_CHAMBRE")
        Else
            If infoResa.Rows.Count > 0 Then
                CODE_CHAMBRE = infoResa.Rows(0)("CHAMBRE_ID")
                MONTANT_ACCORDE_DANS_RESERVATION = infoResa.Rows(0)("MONTANT_ACCORDE")
            End If
        End If

        If infoResa.Rows.Count > 0 Then
            MONTANT_ACCORDE_DANS_RESERVATION = infoResa.Rows(0)("MONTANT_ACCORDE")
            MENSUEL = infoResa.Rows(0)("MENSUEL")
            DATE_SORTIE = infoResa.Rows(0)("DATE_SORTIE")
        End If

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE

        Dim MONTANT_ACCORDE As Double = 0
        Dim CODE_RESERVATION As String = ""

        If GlobalVariable.tarificationDynamiqueActif Then

            Dim tarif As New Tarifs

            Dim DATE_DU_JOUR As Date = CDate(nouvellEDateDeTravail).ToShortDateString
            Dim filepathPlusFile As String = ""

            CODE_RESERVATION = mainCouranteJournaliere.Rows(0)("NUM_RESERVATION")
            Dim SOLDE As Double = Functions.SituationDeReservation(CODE_RESERVATION)
            'ON DOIT VERIFIER L'EXISTENCE DU FICHIER
            Dim extension As String = ".txt"
            Dim nomDuDossier As String = "RESERVATIONS"
            Dim cheminPlusDossier As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossier
            filepathPlusFile = cheminPlusDossier & "\" & CODE_RESERVATION & extension

            'ON SUPPOSE QUE LE FICHIER N'EXISTE PAS

            Dim fichierExist As Boolean = False

            If Directory.Exists(cheminPlusDossier) Then

                If System.IO.File.Exists(filepathPlusFile) Then
                    fichierExist = True
                End If

            End If

            If fichierExist Then

                MONTANT_ACCORDE = tarif.montantAUtiliserUnJourPrecis(DATE_DU_JOUR, CODE_RESERVATION)

                'MISE A JOUR DU MONTANT DANS LA LIGNE DE RESERVATION

                updateReservationApresTarificationDynamique(MONTANT_ACCORDE, CODE_RESERVATION)

            Else
                MONTANT_ACCORDE = mainCouranteJournaliere.Rows(0)("MONTANT_ACCORDE")
            End If

        Else

            'MONTANT ACCORDE AVANT UTILISATION DE LA TARIFICATION DYNAMIQUE

            MONTANT_ACCORDE = mainCouranteJournaliere.Rows(0)("MONTANT_ACCORDE")
        End If

        'DEPUIS FACTURATION ANTICIPE 

        MONTANT_ACCORDE = MONTANT_ACCORDE_DANS_RESERVATION

        If MENSUEL = 1 Then
            MONTANT_ACCORDE = 0
        Else
            If DATE_SORTIE.ToShortDateString = nouvellEDateDeTravail.ToShortDateString Then
                MONTANT_ACCORDE = 0
            End If
        End If

        command.Parameters.Add("@MONTANT_ACCORDE", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("ETAT_CHAMBRE")
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("NOM_CLIENT")

        command.Parameters.Add("@value39", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("TAUX_OCCUPATION_PCT") 'TAXE DE SEJOURS

        Dim TAXE_DE_SEJOUR As Double = mainCouranteJournaliere.Rows(0)("TAUX_OCCUPATION_PCT") 'TAXE DE SEJOURS

        'command.Parameters.Add("@value8", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("PDJ")
        command.Parameters.Add("@PDJ", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@value9", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("DEJEUNER")
        command.Parameters.Add("@DEJEUNER", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@value10", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("DINER")
        command.Parameters.Add("@DINER", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@value11", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("CAFE")
        command.Parameters.Add("@CAFE", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@BAR", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("BAR")
        command.Parameters.Add("@BAR", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@CAVE", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("CAVE")
        command.Parameters.Add("@CAVE", MySqlDbType.Double).Value = 0
        'command.Parameters.Add("@AUTRE", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("AUTRE")
        command.Parameters.Add("@AUTRE", MySqlDbType.Double).Value = 0
        'command.Parameters.Add("@value15", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("SOUS_TOTAL1")
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = 0
        'command.Parameters.Add("@value16", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("LOCATION")
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@value17", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("TELE")
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = 0

        command.Parameters.Add("@value18", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("FAX")
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("LINGE")

        'command.Parameters.Add("@value20", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("DIVERS")
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = 0

        command.Parameters.Add("@value21", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("SOUS_TOTAL2")

        'command.Parameters.Add("@value22", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("TOTAL_JOUR")
        'command.Parameters.Add("@value22", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("MONTANT_ACCORDE") + TAXE_DE_SEJOUR
        command.Parameters.Add("@value22", MySqlDbType.Double).Value = MONTANT_ACCORDE + TAXE_DE_SEJOUR

        Dim REPORT_VEILLE As Double = mainCouranteJournaliere.Rows(0)("A_REPORTER") * -1
        'command.Parameters.Add("@value23", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("REPORT_VEILLE")
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = REPORT_VEILLE

        'SOMME DE TOUS LES VENTES
        'command.Parameters.Add("@value24", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("TOTAL_GENERAL")
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = REPORT_VEILLE + MONTANT_ACCORDE + TAXE_DE_SEJOUR

        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("NUM_RESERVATION")
        'command.Parameters.Add("@value26", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("DEDUCTION")
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@value27", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("ENCAISSEMENT_ESPECE")
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@value28", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("ENCAISSEMENT_CHEQUE")
        command.Parameters.Add("@value28", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@value29", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("ENCAISSEMENT_CARTE_CREDIT")
        command.Parameters.Add("@value29", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@value30", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("DEBITEUR")
        command.Parameters.Add("@value30", MySqlDbType.Double).Value = 0

        command.Parameters.Add("@value31", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("ARRHES")

        'command.Parameters.Add("@value32", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("A_REPORTER")
        'Dim A_REPORTER As Double = Functions.SituationDeReservation(CODE_RESERVATION)
        'command.Parameters.Add("@value32", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("A_REPORTER") + mainCouranteJournaliere.Rows(0)("MONTANT_ACCORDE") + TAXE_DE_SEJOUR
        'command.Parameters.Add("@value32", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("A_REPORTER") + MONTANT_ACCORDE + TAXE_DE_SEJOUR
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = (REPORT_VEILLE + MONTANT_ACCORDE + TAXE_DE_SEJOUR) * -1

        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("OBSERVATIONS")
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("TYPE_CHAMBRE")
        command.Parameters.Add("@value35", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("CODE_CLIENT")
        command.Parameters.Add("@value36", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("INDICE_FREQUENTATION")
        command.Parameters.Add("@value37", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("INDICE_FREQUENTATION_PCT")
        command.Parameters.Add("@value38", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("TAUX_OCCUPATION")

        command.Parameters.Add("@value40", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("CLIENTS_ATTENDUS")
        command.Parameters.Add("@value41", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("CLIENTS_EN_CHAMBRE")
        command.Parameters.Add("@value42", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("CHAMBRES_DISPONIBLES")
        command.Parameters.Add("@value43", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("TOTAL_HORS_SERVICE")
        command.Parameters.Add("@value44", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("CHAMBRES_HORS_SERVICE")
        command.Parameters.Add("@value45", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("TOTAL_FICTIVES")
        command.Parameters.Add("@value46", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("CHAMBRES_FICTIVES")
        command.Parameters.Add("@value47", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("NOMBRE_MESSAGES")
        command.Parameters.Add("@value48", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("TOTAL_GRATUITES")
        command.Parameters.Add("@value49", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("CHAMBRES_GRATUITES")
        command.Parameters.Add("@value50", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("TOTAL_NON_FACTUREES")
        command.Parameters.Add("@value51", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("CHAMBRES_NON_FACTUREES")
        command.Parameters.Add("@value52", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("CODE_AGENCE")

        'command.Parameters.Add("@value53", MySqlDbType.Int64).Value = mainCouranteJournaliere.Rows(0)("ETAT_MAIN_COURANTE")
        command.Parameters.Add("@value53", MySqlDbType.Int64).Value = 0

        'command.Parameters.Add("@value54", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("BAR_RESTAURANT")
        'command.Parameters.Add("@value55", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("SERVICES")
        'command.Parameters.Add("@value56", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("SALON_DE_BEAUTE")
        'command.Parameters.Add("@value57", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("BOUTIQE")
        'command.Parameters.Add("@value58", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("CYBERCAFE")
        'command.Parameters.Add("@value59", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("AUTRES")
        'command.Parameters.Add("@value60", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("TYPE")

        command.Parameters.Add("@value54", MySqlDbType.Double).Value = 0
        command.Parameters.Add("@value55", MySqlDbType.Double).Value = 0
        command.Parameters.Add("@value56", MySqlDbType.Double).Value = 0
        command.Parameters.Add("@value57", MySqlDbType.Double).Value = 0
        command.Parameters.Add("@value58", MySqlDbType.Double).Value = 0
        command.Parameters.Add("@value59", MySqlDbType.Double).Value = 0

        command.Parameters.Add("@value60", MySqlDbType.VarChar).Value = mainCouranteJournaliere.Rows(0)("TYPE")

        'command.Parameters.Add("@SPORTS", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("SPORTS")
        'command.Parameters.Add("@LOISIRS", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("LOISIRS")
        'command.Parameters.Add("@KIOSQUE_A_JOURNAUX", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("KIOSQUE_A_JOURNAUX")
        'command.Parameters.Add("@BLANCHISSERIE", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("BLANCHISSERIE")

        command.Parameters.Add("@SPORTS", MySqlDbType.Double).Value = 0
        command.Parameters.Add("@LOISIRS", MySqlDbType.Double).Value = 0
        command.Parameters.Add("@KIOSQUE_A_JOURNAUX", MySqlDbType.Double).Value = 0
        command.Parameters.Add("@BLANCHISSERIE", MySqlDbType.Double).Value = 0

        'command.Parameters.Add("@DEPOT_DE_GARANTIE", MySqlDbType.Double).Value = mainCouranteJournaliere.Rows(0)("DEPOT_DE_GARANTIE")

        If (command.ExecuteNonQuery() = 1) Then

            '3- MISE A JOUR DE ETAT_MAIN_COURANTE DE L'ANCIENNE MAIN COURANTE (MAIN COURANTE COPIEE)
            'On met ajour la copie en changeant le CODE

            Return True

        Else
            Return False
        End If

        Dim CODE_MAIN_COURANTE As String = mainCouranteJournaliere.Rows(0)("CODE_MAIN_COURANTE_JOURNALIERE")
        Dim ETAT_MAIN_COURANTE As Integer = 1

        miseAjourEtatMainCourante(CODE_MAIN_COURANTE, ETAT_MAIN_COURANTE)

    End Function

    Public Sub miseAjourEtatMainCourante(ByVal CODE_MAIN_COURANTE As String, ByVal ETAT_MAIN_COURANTE As Integer)

        Dim updateQueryMainCouranteJournaliereCopie As String = "UPDATE `main_courante_journaliere` SET `ETAT_MAIN_COURANTE` = @ETAT_MAIN_COURANTE WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE"

        Dim commandMainCouranteJournaliereCopie As New MySqlCommand(updateQueryMainCouranteJournaliereCopie, GlobalVariable.connect)

        commandMainCouranteJournaliereCopie.Parameters.Add("@ETAT_MAIN_COURANTE", MySqlDbType.Int64).Value = ETAT_MAIN_COURANTE
        commandMainCouranteJournaliereCopie.Parameters.Add("@CODE_MAIN_COURANTE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE

        commandMainCouranteJournaliereCopie.ExecuteNonQuery()

    End Sub

    Public Sub etatReservation(ByVal CODE_RESERVATION As String, ByVal ETAT_RESERVATION As Integer, ByVal ETAT_NOTE_RESERVATION As String)

        Dim updateQueryreserve_conf As String = "UPDATE `reserve_conf` SET `ETAT_RESERVATION` = @ETAT_RESERVATION, ETAT_NOTE_RESERVATION=@ETAT_NOTE_RESERVATION WHERE CODE_RESERVATION = @CODE_RESERVATION"

        Dim commandMainCourantereserve_conf As New MySqlCommand(updateQueryreserve_conf, GlobalVariable.connect)

        commandMainCourantereserve_conf.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int64).Value = ETAT_RESERVATION
        commandMainCourantereserve_conf.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        commandMainCourantereserve_conf.Parameters.Add("@ETAT_NOTE_RESERVATION", MySqlDbType.VarChar).Value = ETAT_NOTE_RESERVATION

        commandMainCourantereserve_conf.ExecuteNonQuery()

    End Sub

    Public Function checkOutStateUpdate(ByVal CODE_RESERVATION As String, ByVal ETAT_NOTE_RESERVATION As String)

        Dim updateQuery As String = "UPDATE reserve_conf SET `ETAT_NOTE_RESERVATION` = @ETAT_NOTE_RESERVATION WHERE CODE_RESERVATION = @CODE_RESERVATION"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@ETAT_NOTE_RESERVATION", MySqlDbType.VarChar).Value = ETAT_NOTE_RESERVATION

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Sub insertionInformationPriseEnChargeResa(ByVal PETIT_DEJEUNER As Double, ByVal DEJEUNER As Double, ByVal DINER As Double, ByVal LOGEMENT As Double,
                                                     ByVal BOISSONS As Double, ByVal NAVETTE As Double, ByVal BLANCHISSERIE As Double,
                                                     ByVal SALLE_CONFERENCE As Double, ByVal CODE_RESERVATION As String, ByVal DATE_CREATION As Date,
                                                     ByVal TABLE As String, ByVal AUTHORISATION As String, ByVal REMARQUE As String, Optional ByVal ETAT As Integer = 1)

        Dim insertQuery As String = ""

        If TABLE = "gratuitee_de_resa" Then

            insertQuery = "INSERT INTO " & TABLE & " (`PETIT_DEJEUNER`, `DEJEUNER`, `DINER`, `LOGEMENT`, `BOISSONS`, `NAVETTE`, `BLANCHISSERIE`, `SALLE_CONFERENCE`, `CODE_RESERVATION`, `DATE_CREATION`, `AUTHORISATION`, `REMARQUE`, `ETAT`) VALUES (@value2 ,@value3 ,@value4 ,@value5 ,@value6 ,@value7 ,@value8 ,@value9 ,@value10 , @value11 , @value12 , @value13, @ETAT)"

        ElseIf TABLE = "prise_en_charge_resa" Then

            insertQuery = "INSERT INTO " & TABLE & " (`PETIT_DEJEUNER`, `DEJEUNER`, `DINER`, `LOGEMENT`, `BOISSONS`, `NAVETTE`, `BLANCHISSERIE`, `SALLE_CONFERENCE`, `CODE_RESERVATION`, `DATE_CREATION`) VALUES (@value2 ,@value3 ,@value4 ,@value5 ,@value6 ,@value7 ,@value8 ,@value9 ,@value10 ,@value11 )"

        End If

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.Double).Value = PETIT_DEJEUNER
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = DEJEUNER
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = DINER
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = LOGEMENT
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = BOISSONS
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = NAVETTE
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = BLANCHISSERIE
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = SALLE_CONFERENCE
        command.Parameters.Add("@value10", MySqlDbType.String).Value = CODE_RESERVATION
        command.Parameters.Add("@value11", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value12", MySqlDbType.String).Value = AUTHORISATION
        command.Parameters.Add("@value13", MySqlDbType.String).Value = REMARQUE
        command.Parameters.Add("@ETAT", MySqlDbType.Int16).Value = ETAT

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        command.ExecuteNonQuery()

    End Sub

    'GESTION DES CAUTIONS DE RESERVATION

    Public Sub insertionCaution(ByVal CODE_CAUTION As String, ByVal CODE_RESERVATION As String, ByVal DEBIT As Double, ByVal CREDIT As Double,
                                ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal TYPE As Integer, Optional ByVal ETAT_DEPOT As String = "Affecté", Optional ByVal NOM_CLIENT As String = "")

        Dim insertQuery As String = ""
        Dim PAR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        insertQuery = "INSERT INTO `caution`(`CODE_CAUTION`, `CODE_RESERVATION`, `DEBIT`, `CREDIT`, `RAISON`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`,`SOLDE`, `TYPE`,
        `ETAT_DEPOT`, `PAR`, `NOM_CLIENT`) 
           VALUES (@CODE_CAUTION, @CODE_RESERVATION, @DEBIT, @CREDIT, @RAISON, @DATE_CREATION, @CODE_UTILISATEUR_CREA, `CREDIT` - `DEBIT`, @TYPE, @ETAT_DEPOT, @PAR, @NOM_CLIENT)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAUTION", MySqlDbType.VarChar).Value = CODE_CAUTION
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@DEBIT", MySqlDbType.Double).Value = DEBIT
        command.Parameters.Add("@CREDIT", MySqlDbType.Double).Value = CREDIT
        command.Parameters.Add("@RAISON", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@ETAT_DEPOT", MySqlDbType.VarChar).Value = ETAT_DEPOT
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@TYPE", MySqlDbType.Int16).Value = TYPE
        command.Parameters.Add("@PAR", MySqlDbType.VarChar).Value = PAR
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.VarChar).Value = NOM_CLIENT

        command.ExecuteNonQuery()

    End Sub

    Public Sub reboursementCautionDepot(ByVal CODE_CAUTION As String, ByVal CODE_RESERVATION As String, ByVal CREDIT As Double, ByVal CODE_UTILISATEUR_CREA As String, ByVal TYPE As Integer)

        Dim insertQuery As String = ""
        Dim ETAT_DEPOT As String = ""

        If TYPE = 1 Then
            ETAT_DEPOT = "Remsboursé"
        End If

        insertQuery = "UPDATE `caution` SET `DEBIT`=DEBIT + @CREDIT, `CREDIT`= @CREDIT, SOLDE=`CREDIT` - `DEBIT`, ETAT_DEPOT=@ETAT_DEPOT
        WHERE CODE_RESERVATION=@CODE_RESERVATION AND TYPE=@TYPE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAUTION", MySqlDbType.VarChar).Value = CODE_CAUTION
        command.Parameters.Add("@ETAT_DEPOT", MySqlDbType.VarChar).Value = ETAT_DEPOT
        'command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@CREDIT", MySqlDbType.Double).Value = CREDIT
        command.Parameters.Add("@TYPE", MySqlDbType.Int16).Value = TYPE

        command.ExecuteNonQuery()

    End Sub

    Public Sub updateCaution(ByVal CODE_CAUTION As String, ByVal CODE_RESERVATION As String, ByVal DEBIT As Double, ByVal CREDIT As Double, ByVal CODE_UTILISATEUR_CREA As String, ByVal TYPE As Integer, Optional ByVal ETAT_DEPOT As String = "")

        Dim insertQuery As String = ""
        Dim SOLDE As Double = CREDIT - DEBIT
        insertQuery = "UPDATE `caution` SET `DEBIT`=@DEBIT, `CREDIT`= @CREDIT + DEBIT, SOLDE=`CREDIT` - `DEBIT`, ETAT_DEPOT=@ETAT_DEPOT WHERE CODE_CAUTION=@CODE_CAUTION AND TYPE=@TYPE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAUTION", MySqlDbType.VarChar).Value = CODE_CAUTION
        command.Parameters.Add("@DEBIT", MySqlDbType.Double).Value = DEBIT
        command.Parameters.Add("@CREDIT", MySqlDbType.Double).Value = CREDIT
        command.Parameters.Add("@ETAT_DEPOT", MySqlDbType.VarChar).Value = ETAT_DEPOT
        command.Parameters.Add("@TYPE", MySqlDbType.Int16).Value = TYPE

        command.ExecuteNonQuery()

    End Sub


    Public Sub updateMotifRemboursementPartielDelaCaution(ByVal CODE_CAUTION As String, ByVal RAISON As String)

        Dim insertQuery As String = ""

        insertQuery = "UPDATE `caution` SET `RAISON`=@RAISON WHERE CODE_CAUTION=@CODE_CAUTION"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@RAISON", MySqlDbType.VarChar).Value = RAISON
        command.Parameters.Add("@CODE_CAUTION", MySqlDbType.VarChar).Value = CODE_CAUTION

        command.ExecuteNonQuery()

    End Sub

    Public Sub updateChambreApresDelogement(ByVal CODE_MAIN_COURANTE As String, ByVal CODE_CHAMBRE As String)

        Dim updateQueryMainCouranteJournaliereCopie As String = "UPDATE `main_courante_journaliere` SET `CODE_CHAMBRE` = @CODE_CHAMBRE WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE"

        Dim commandMainCouranteJournaliereCopie As New MySqlCommand(updateQueryMainCouranteJournaliereCopie, GlobalVariable.connect)

        commandMainCouranteJournaliereCopie.Parameters.Add("@CODE_MAIN_COURANTE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE
        commandMainCouranteJournaliereCopie.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE

        commandMainCouranteJournaliereCopie.ExecuteNonQuery()

    End Sub

    Public Sub coChambrier(ByVal CODE_CLIENT As String, ByVal NOM_PRENOM As String, ByVal CODE_RESERVATION As String)

        Dim insertQuery As String = ""

        insertQuery = "INSERT INTO `cochambrier`(`CODE_CLIENT`, `NOM_PRENOM`, `CODE_RESERVATION`) VALUES (@CODE_CLIENT, @NOM_PRENOM, @CODE_RESERVATION)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = NOM_PRENOM
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        command.ExecuteNonQuery()

    End Sub

    Public Sub insertionDesNavettes(ByVal CODE_RESERVATION As String, ByVal COMPANIE As String, ByVal VOL As String, ByVal TYPE_DE_TRAJET As String, ByVal NBRE_PERSONNE As Integer, ByVal DEPART As String, ByVal AUTRE_DEPART As String, ByVal ARRIVER As String, ByVal AUTRE_ARRIVE As String, ByVal DATE_DEPART As Date, ByVal HEURE_ARRIVEE As String, ByVal DATE_ARRIVEE As Date, ByVal HEURE_DEPART As String, ByVal DATE_CREATION As Date)


        Dim insertQuery As String = "INSERT INTO `navette` (`CODE_RESERVATION`, `COMPANIE`, `VOL`, `TYPE_DE_TRAJET`, `NBRE_PERSONNE`, `DEPART`, `AUTRE_DEPART`, `ARRIVER`, `AUTRE_ARRIVE`, `DATE_DEPART`, `HEURE_ARRIVEE`, `DATE_ARRIVEE`, `HEURE_DEPART`, `DATE_CREATION`) 
            VALUES (@CODE_RESERVATION, @COMPANIE, @VOL, @TYPE_DE_TRAJET, @NBRE_PERSONNE, @DEPART, @AUTRE_DEPART, @ARRIVER, @AUTRE_ARRIVE, @DATE_DEPART, @HEURE_ARRIVEE, @DATE_ARRIVEE, @HEURE_DEPART, @DATE_CREATION)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@COMPANIE", MySqlDbType.VarChar).Value = COMPANIE
        command.Parameters.Add("@VOL", MySqlDbType.VarChar).Value = VOL
        command.Parameters.Add("@TYPE_DE_TRAJET", MySqlDbType.VarChar).Value = TYPE_DE_TRAJET
        command.Parameters.Add("@NBRE_PERSONNE", MySqlDbType.Int32).Value = NBRE_PERSONNE
        command.Parameters.Add("@DEPART", MySqlDbType.VarChar).Value = DEPART
        command.Parameters.Add("@AUTRE_DEPART", MySqlDbType.VarChar).Value = AUTRE_DEPART
        command.Parameters.Add("@ARRIVER", MySqlDbType.VarChar).Value = ARRIVER
        command.Parameters.Add("@AUTRE_ARRIVE", MySqlDbType.VarChar).Value = AUTRE_ARRIVE
        command.Parameters.Add("@DATE_DEPART", MySqlDbType.Date).Value = DATE_DEPART
        command.Parameters.Add("@HEURE_ARRIVEE", MySqlDbType.VarChar).Value = HEURE_ARRIVEE
        command.Parameters.Add("@DATE_ARRIVEE", MySqlDbType.Date).Value = DATE_ARRIVEE
        command.Parameters.Add("@HEURE_DEPART", MySqlDbType.VarChar).Value = HEURE_DEPART
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION

        command.ExecuteNonQuery()

    End Sub

    Public Sub UpdateDesNavettes(ByVal CODE_RESERVATION As String, ByVal COMPANIE As String, ByVal VOL As String, ByVal TYPE_DE_TRAJET As String, ByVal NBRE_PERSONNE As Integer, ByVal DEPART As String, ByVal AUTRE_DEPART As String, ByVal ARRIVER As String, ByVal AUTRE_ARRIVE As String, ByVal DATE_DEPART As Date, ByVal HEURE_ARRIVEE As String, ByVal DATE_ARRIVEE As Date, ByVal HEURE_DEPART As String, ByVal DATE_CREATION As Date)

        Dim updateQuery As String = "UPDATE `navette` SET `COMPANIE` = @COMPANIE, `VOL` = @VOL, `TYPE_DE_TRAJET` = @TYPE_DE_TRAJET, `NBRE_PERSONNE` = @NBRE_PERSONNE,
        `DEPART` = @DEPART, `AUTRE_DEPART` = @AUTRE_DEPART, `ARRIVER` = @ARRIVER, `AUTRE_ARRIVE` = @AUTRE_ARRIVE, `DATE_DEPART` = @DATE_DEPART,
        `HEURE_ARRIVEE` = @HEURE_ARRIVEE, `DATE_ARRIVEE` = @DATE_ARRIVEE, `HEURE_DEPART` = @HEURE_DEPART, `DATE_CREATION` = @DATE_CREATION WHERE CODE_RESERVATION=@CODE_RESERVATION"
        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@COMPANIE", MySqlDbType.VarChar).Value = COMPANIE
        command.Parameters.Add("@VOL", MySqlDbType.VarChar).Value = VOL
        command.Parameters.Add("@TYPE_DE_TRAJET", MySqlDbType.VarChar).Value = TYPE_DE_TRAJET
        command.Parameters.Add("@NBRE_PERSONNE", MySqlDbType.Int32).Value = NBRE_PERSONNE
        command.Parameters.Add("@DEPART", MySqlDbType.VarChar).Value = DEPART
        command.Parameters.Add("@AUTRE_DEPART", MySqlDbType.VarChar).Value = AUTRE_DEPART
        command.Parameters.Add("@ARRIVER", MySqlDbType.VarChar).Value = ARRIVER
        command.Parameters.Add("@AUTRE_ARRIVE", MySqlDbType.VarChar).Value = AUTRE_ARRIVE
        command.Parameters.Add("@DATE_DEPART", MySqlDbType.Date).Value = DATE_DEPART
        command.Parameters.Add("@HEURE_ARRIVEE", MySqlDbType.VarChar).Value = HEURE_ARRIVEE
        command.Parameters.Add("@DATE_ARRIVEE", MySqlDbType.Date).Value = DATE_ARRIVEE
        command.Parameters.Add("@HEURE_DEPART", MySqlDbType.VarChar).Value = HEURE_DEPART
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION

        command.ExecuteNonQuery()

    End Sub

    Public Sub insertionSuiviEncodage(ByVal CODE_RESERVATION As String)

        Dim insertQuery As String = "INSERT INTO `suivi_des_encodages` (`CODE_RESERVATION`) VALUES (@CODE_RESERVATION)"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        command.ExecuteNonQuery()

    End Sub


    Public Sub updateDesInformationsEncodage(ByVal CODE_RESERVATION As String, ByVal operation As String)

        Dim updateQuery As String = ""

        Dim HEURE_ENCODAGE As String = Now().ToLongTimeString
        Dim ENCODAGE_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        Dim HEURE_LECTURE As String = Now().ToLongTimeString
        Dim LECTURE_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        Dim HEURE_EFFACEMENT As String = Now().ToLongTimeString
        Dim EFFACEMENT_PAR As String = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")

        If operation = 0 Then
            updateQuery = "UPDATE `suivi_des_encodages` SET `HEURE_ENCODAGE`=@HEURE_ENCODAGE, `ENCODAGE_PAR`=@ENCODAGE_PAR WHERE CODE_RESERVATION =@CODE_RESERVATION"
        ElseIf operation = 1 Then
            updateQuery = "UPDATE `suivi_des_encodages` SET `HEURE_LECTURE`=@HEURE_LECTURE,`LECTURE_PAR`=@LECTURE_PAR WHERE CODE_RESERVATION =@CODE_RESERVATION"
        ElseIf operation = 2 Then
            updateQuery = "UPDATE `suivi_des_encodages` SET `HEURE_EFFACEMENT`=@HEURE_EFFACEMENT,`EFFACEMENT_PAR`=@EFFACEMENT_PAR WHERE CODE_RESERVATION =@CODE_RESERVATION"
        End If

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@HEURE_ENCODAGE", MySqlDbType.VarChar).Value = HEURE_ENCODAGE
        command.Parameters.Add("@ENCODAGE_PAR", MySqlDbType.VarChar).Value = ENCODAGE_PAR
        command.Parameters.Add("@HEURE_LECTURE", MySqlDbType.VarChar).Value = HEURE_LECTURE
        command.Parameters.Add("@LECTURE_PAR", MySqlDbType.VarChar).Value = LECTURE_PAR
        command.Parameters.Add("@HEURE_EFFACEMENT", MySqlDbType.VarChar).Value = HEURE_EFFACEMENT
        command.Parameters.Add("@EFFACEMENT_PAR", MySqlDbType.VarChar).Value = EFFACEMENT_PAR

        command.ExecuteNonQuery()

    End Sub

    Public Function insertTrace(ByVal CODE_RESERVATION As String, ByVal CLIENT_ID As String, ByVal UTILISATEUR_ID As String, ByVal CHAMBRE_ID As String, ByVal AGENCE_ID As String, ByVal NOM_CLIENT As String, ByVal DATE_ENTTRE As Date, ByVal HEURE_ENTREE As DateTime, ByVal DATE_SORTIE As Date, ByVal HEURE_SORTIE As DateTime, ByVal ADULTES As Integer, ByVal NB_PERSONNES As Integer, ByVal ENFANTS As Integer, ByVal RECEVOIR_EMAIL As String, ByVal RECEVOIR_SMS As Integer, ByVal ETAT_RESERVATION As Integer, ByVal DATE_CREATION As Date, ByVal HEURE_CREATION As String, ByVal MONTANT_TOTAL_CAUTION As Double, ByVal MOTIF_ETAT As String, ByVal DATE_ETAT As Date, ByVal MONTANT_ACCORDE As Double, ByVal GROUPE As String, ByVal DEPOT_DE_GARANTIE As Double, ByVal DAY_USE As Integer, ByVal MENSUEL As Integer, ByVal BC_ENTREPRISE As String, ByVal TYPE_CHAMBRE As String, ByVal ACTION As String, ByVal PAR As String, Optional ByVal TYPE As String = "chambre", Optional ByVal PETIT_DEJEUNER_ROUTAGE As Double = 0, Optional ByVal CHAMBRE_ROUTAGE As String = "", Optional ByVal VENANT_DE As String = "", Optional ByVal SE_RENDANT_A As String = "", Optional ByVal RAISON As String = "", Optional ByVal SOURCE_RESERVATION As String = "", Optional ByVal ROUTAGE As String = "NON", Optional ByVal ETAT_NOTE_RESERVATION As String = "", Optional ByVal CODE_ENTREPRISE As String = "", Optional ByVal NOM_ENTREPRISE As String = "", Optional ByVal SOLDE_RESERVATION As Double = 0) As Boolean

        Dim insertQuery As String = "INSERT INTO `trace`(`CODE_RESERVATION`,`CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`,`DATE_ENTTRE`, `HEURE_ENTREE`, 
        `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`,
        `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`,`DEPOT_DE_GARANTIE`, `DAY_USE`, `MENSUEL`, `BC_ENTREPRISE`, `TYPE_CHAMBRE`, `ACTION`, `PAR`, `TYPE`, 
        `PETIT_DEJEUNER_ROUTAGE`, `CHAMBRE_ROUTAGE`, `VENANT_DE`, `SE_RENDANT_A`, `RAISON` , `SOURCE_RESERVATION`, `ROUTAGE`, `ETAT_NOTE_RESERVATION`, `CODE_ENTREPRISE`, 
        `NOM_ENTREPRISE`, `SOLDE_RESERVATION`) 
        VALUES (@CODE_RESERVATION,@value2,@value3,@value4,@value5,@NOM_CLIENT,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,
        @value18,@value19,@value20,@value21,@value22, @DEPOT_DE_GARANTIE, @DAY_USE, @MENSUEL, @BC_ENTREPRISE, @TYPE_CHAMBRE, @ACTION, @PAR, @value23, @value24,@value25,@value26,@value27,
        @value28,@value29,@value30,@value31,@value32, @value33, @SOLDE_RESERVATION)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CLIENT_ID
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@BC_ENTREPRISE", MySqlDbType.VarChar).Value = BC_ENTREPRISE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = UTILISATEUR_ID
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CHAMBRE_ID
        command.Parameters.Add("@value5", MySqlDbType.String).Value = AGENCE_ID
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.String).Value = NOM_CLIENT
        command.Parameters.Add("@value6", MySqlDbType.Date).Value = DATE_ENTTRE
        command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = HEURE_ENTREE
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_SORTIE
        command.Parameters.Add("@value9", MySqlDbType.DateTime).Value = HEURE_SORTIE
        command.Parameters.Add("@value10", MySqlDbType.Int32).Value = ADULTES
        command.Parameters.Add("@value11", MySqlDbType.Int32).Value = NB_PERSONNES
        command.Parameters.Add("@value12", MySqlDbType.Int32).Value = ENFANTS
        command.Parameters.Add("@value13", MySqlDbType.Int32).Value = RECEVOIR_EMAIL
        command.Parameters.Add("@value14", MySqlDbType.Int32).Value = RECEVOIR_SMS
        command.Parameters.Add("@value15", MySqlDbType.Int32).Value = ETAT_RESERVATION
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = HEURE_CREATION
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = MONTANT_TOTAL_CAUTION
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = MOTIF_ETAT
        command.Parameters.Add("@value20", MySqlDbType.Date).Value = DATE_ETAT
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = GROUPE
        command.Parameters.Add("@DEPOT_DE_GARANTIE", MySqlDbType.Double).Value = DEPOT_DE_GARANTIE
        command.Parameters.Add("@DAY_USE", MySqlDbType.Int64).Value = DAY_USE
        command.Parameters.Add("@MENSUEL", MySqlDbType.Int64).Value = MENSUEL
        command.Parameters.Add("@value23", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = PETIT_DEJEUNER_ROUTAGE
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = CHAMBRE_ROUTAGE
        command.Parameters.Add("@value26", MySqlDbType.VarChar).Value = VENANT_DE
        command.Parameters.Add("@value27", MySqlDbType.VarChar).Value = SE_RENDANT_A
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = RAISON
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = SOURCE_RESERVATION
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = ROUTAGE
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = ETAT_NOTE_RESERVATION
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = NOM_ENTREPRISE
        command.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = TYPE_CHAMBRE

        command.Parameters.Add("@ACTION", MySqlDbType.VarChar).Value = ACTION
        command.Parameters.Add("@PAR", MySqlDbType.VarChar).Value = PAR
        command.Parameters.Add("@SOLDE_RESERVATION", MySqlDbType.Double).Value = SOLDE_RESERVATION

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

    Public Function insertForfaitSalleHebergement(ByVal CODE_RESERVATION As String, ByVal CODE_FORFAIT_HEBERGEMENT As String, ByVal HEBERGEMENT As Double, ByVal ENCAISSEMENT As Double, ByVal NBRE_NUITEE As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `forfait_salle_hebergement`(`CODE_FORFAIT_HEBERGEMENT`, `HEBERGEMENT`, `NBRE_NUITEE`, `ENCAISSEMENT`, `CODE_RESERVATION`) 
                    VALUES (@CODE_FORFAIT_HEBERGEMENT,@HEBERGEMENT,@NBRE_NUITEE,@ENCAISSEMENT,@CODE_RESERVATION)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FORFAIT_HEBERGEMENT", MySqlDbType.VarChar).Value = CODE_FORFAIT_HEBERGEMENT
        command.Parameters.Add("@HEBERGEMENT", MySqlDbType.VarChar).Value = HEBERGEMENT
        command.Parameters.Add("@NBRE_NUITEE", MySqlDbType.VarChar).Value = NBRE_NUITEE
        command.Parameters.Add("@ENCAISSEMENT", MySqlDbType.VarChar).Value = ENCAISSEMENT
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    'MISE AJOURS DES DEPOTS DE GARANTIE DANS LA RESERVATION ET DANS LA TABLE DEPOT_DE_GARANTIE
    'APRES DES ENCAISSEMENTS LIES AUX DEPOT DE GARANTIE

    Public Sub miseAjourDesDepotDeGarantiesRreservation(ByVal CODE_RESERVATION As String, ByVal DEPOT_DE_GARANTIE As Double, ByVal DEPOT_DE_GARANTIE_RESA As Double)

        If DEPOT_DE_GARANTIE_RESA > 0 Then

            Dim insertQuery As String = "UPDATE reserve_conf SET DEPOT_DE_GARANTIE = DEPOT_DE_GARANTIE - @DEPOT_DE_GARANTIE WHERE CODE_RESERVATION=@CODE_RESERVATION"
            Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
            command.Parameters.Add("@DEPOT_DE_GARANTIE", MySqlDbType.VarChar).Value = DEPOT_DE_GARANTIE
            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
            command.ExecuteNonQuery()

        End If

    End Sub

    Public Sub miseAjourDesDepotDeGaranties(ByVal CODE_CAUTION As String, ByVal DEPOT_DE_GARANTIE As Double)

        Dim insertQuery_ As String = "UPDATE caution SET DEBIT = DEBIT + @DEPOT_DE_GARANTIE, SOLDE = SOLDE - @DEPOT_DE_GARANTIE WHERE CODE_CAUTION=@CODE_CAUTION"
        Dim command_ As New MySqlCommand(insertQuery_, GlobalVariable.connect)
        command_.Parameters.Add("@DEPOT_DE_GARANTIE", MySqlDbType.VarChar).Value = DEPOT_DE_GARANTIE
        command_.Parameters.Add("@CODE_CAUTION", MySqlDbType.VarChar).Value = CODE_CAUTION
        command_.ExecuteNonQuery()

    End Sub

    Public Function infoCautionUtilisableDepot(ByVal CODE_RESERVATION_CLIENT As String) As DataTable

        Dim query As String = "SELECT * FROM caution WHERE CODE_RESERVATION=@CODE_RESERVATION_CLIENT AND TYPE = 1 AND SOLDE > 0 
            ORDER BY caution.DATE_CREATION DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@CODE_RESERVATION_CLIENT", MySqlDbType.VarChar).Value = CODE_RESERVATION_CLIENT
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)

        Return table

        '394344724

    End Function

    Public Sub facturationEnAvance(ByVal CODE_RESERVATION As String, ByVal POSTER_TAXE As Integer, Optional ByVal MONTANT_A_FACTURER As Double = 0)

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT * FROM reserve_conf WHERE CODE_RESERVATION=@CODE_RESERVATION"

        Dim commandReservation As New MySqlCommand(query, GlobalVariable.connect)
        commandReservation.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        Dim adapterReservation As New MySqlDataAdapter(commandReservation)
        Dim tableReservation As New DataTable()
        adapterReservation.Fill(tableReservation)

        If tableReservation.Rows.Count > 0 Then

            For i = 0 To tableReservation.Rows.Count - 1

                Dim clientInfo As DataTable = Functions.getElementByCode(tableReservation.Rows(i)("CLIENT_ID"), "client", "CODE_CLIENT")

                Dim typeClient As String = ""

                If clientInfo.Rows.Count > 0 Then
                    typeClient = clientInfo.Rows(0)("TYPE_CLIENT")
                End If

                Dim TITRE As String = ""
                Dim TITRE_TYPE As String = ""

                If tableReservation.Rows(i)("TYPE") = "chambre" Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        TITRE = "HEBERGEMENT"
                    Else
                        TITRE = "ACCOMMODATION"
                    End If

                    TITRE_TYPE = "chambre"

                ElseIf tableReservation.Rows(i)("TYPE") = "salle" Then

                    If GlobalVariable.actualLanguageValue = 1 Then
                        TITRE = "LOCATION SALLE"
                    Else
                        TITRE = "HALL RENTING"
                    End If

                    TITRE_TYPE = "salle"

                End If

                If True Then

                    typeClient = ""

                    'insertion d'une ligne dans factures FACTURATION pour chaque client en chambre

                    Dim CODE_FACTURE As String = Functions.GeneratingRandomCodeWithSpecifications("facture", "")
                    Dim CODE_COMMANDE As String = ""
                    Dim NUMERO_TABLE As String = ""
                    Dim CODE_MODE_PAIEMENT As String = tableReservation.Rows(i)("NOM_CLIENT")
                    Dim NUM_MOUVEMENT As String = ""
                    Dim DATE_FACTURE As Date = GlobalVariable.DateDeTravail
                    Dim CODE_COMMERCIAL As String = ""
                    Dim AVANCE As Double = 0
                    Dim RESTE_A_PAYER As Double = 0
                    Dim DATE_PAIEMENT As Date
                    Dim ETAT_FACTURE As Integer = 0

                    Dim LIBELLE_FACTURE As String = TITRE & " (" & tableReservation.Rows(i)("NOM_CLIENT") & " / " & tableReservation.Rows(i)("CHAMBRE_ID") & ")"
                    Dim MONTANT_TRANSPORT As Double = 0
                    Dim MONTANT_REMISE As Double = 0
                    Dim CODE_UTILISATEUR_ANNULE As String = ""
                    Dim CODE_UTILISATEUR_VALIDE As String = ""
                    Dim NOM_CLIENT_FACTURE As String = ""
                    Dim MONTANT_AVANCE As Double = 0
                    Dim CODE_CLIENT As String = tableReservation.Rows(i)("CLIENT_ID")
                    Dim CODE_AGENCE As String = GlobalVariable.codeAgence

                    Dim montant As Double = 0

                    'Insere uniquement le montant accordé
                    'La facturation du logement d'un client ce fait au jour le jour donc le preleve le montant accorde et non le montant total du séjour

                    If MONTANT_A_FACTURER = 0 Then
                        Double.TryParse(tableReservation.Rows(i)("MONTANT_ACCORDE"), montant)
                    Else
                        montant = MONTANT_A_FACTURER
                    End If

                    Dim MONTANT_HT As Double = montant
                    'Dim MONTANT_HT As Double = mainCouranteJournaliere.Rows(0)("SOUS_TOTAL1")
                    Dim MONTANT_TTC As Double = MONTANT_HT
                    'Dim MONTANT_TTC As Double = mainCouranteJournaliere.Rows(0)("SOUS_TOTAL1")
                    Dim TAXE As Double = 0
                    Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
                    Dim CODE_FACTURE_DEJEUNER As String = Functions.GeneratingRandomCodeWithSpecifications("facture", "")

                    Dim Facture As New Facture()
                    Dim OldReservationCode As String = ""

                    Dim MONTANT_HT_DEJEUNER As Double = 0
                    Dim MONTANT_TTC_DEJEUNER As Double = 0

                    'Insertion d'une ligne dans ligne_facture

                    Dim CODE_MOUVEMENT As String = ""
                    Dim CODE_CHAMBRE As String = tableReservation.Rows(i)("CHAMBRE_ID")
                    Dim NOM_CLIENT As String = tableReservation.Rows(i)("NOM_CLIENT")
                    Dim NUMERO_PIECE As String = ""
                    Dim CODE_ARTICLE As String = ""
                    Dim CODE_LOT As String = ""
                    Dim QUANTITE As Double = 1
                    Dim PRIX_UNITAIRE_TTC As Double = MONTANT_TTC
                    Dim HEURE_FACTURE As DateTime = Date.Now().ToShortTimeString
                    Dim DATE_OCCUPATION As Date
                    Dim HEURE_OCCUPATION As DateTime = Date.Now().ToShortTimeString
                    Dim TYPE_LIGNE_FACTURE As String = TITRE
                    Dim NUMERO_SERIE As String = ""
                    Dim NUMERO_ORDRE As Integer = 0
                    Dim DESCRIPTION As String = ""
                    Dim MONTANT_TAXE As Double = TAXE
                    Dim NUMERO_SERIE_DEBUT As String = ""
                    Dim NUMERO_SERIE_FIN As String = ""
                    Dim CODE_MAGASIN As String = ""
                    Dim FUSIONNEE As String = TITRE
                    Dim MONTANT_PETIT_DEJEUNER As Double = 0

                    Dim ligneFacture As New LigneFacture()

                    '-------------------------- LIGNE FACTURATION--------------------------

                    'GESTION DES TAXES DE SEJOURS

                    If POSTER_TAXE > 0 Then

                        Dim CODE_FACTURE_TAXE As String = Functions.GeneratingRandomCode("facture", "")
                        Dim CODE_TAXE_RESERVATION As String = tableReservation.Rows(i)("CODE_RESERVATION")
                        Dim MONTANT_TAXE_SEJOUR As Double = POSTER_TAXE
                        Dim MONTANT_TAXE_SEJOUR_HT As Double = POSTER_TAXE

                        Dim TYPE_LIGNE_FACTURE_ As String = "" ''klg

                        If GlobalVariable.actualLanguageValue = 1 Then
                            TYPE_LIGNE_FACTURE_ = "TAXE DE SEJOURS"
                            If ligneFacture.insertLigneFacture(CODE_FACTURE_TAXE, CODE_TAXE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_TAXE_SEJOUR, TAXE, QUANTITE, MONTANT_TAXE_SEJOUR, MONTANT_TAXE_SEJOUR, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, TYPE_LIGNE_FACTURE_ & " " & "(" + NOM_CLIENT + "/" + CODE_CHAMBRE + ") ", TYPE_LIGNE_FACTURE_, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, TYPE_LIGNE_FACTURE_) Then

                            End If
                        Else
                            TYPE_LIGNE_FACTURE_ = "TOURIST TAX"
                            If ligneFacture.insertLigneFacture(CODE_FACTURE_TAXE, CODE_TAXE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_TAXE_SEJOUR, TAXE, QUANTITE, MONTANT_TAXE_SEJOUR, MONTANT_TAXE_SEJOUR, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, TYPE_LIGNE_FACTURE_ & " " & "(" + NOM_CLIENT + "/" + CODE_CHAMBRE + ") ", TYPE_LIGNE_FACTURE_, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, TYPE_LIGNE_FACTURE_) Then

                            End If
                        End If

                    End If

                    If ligneFacture.insertLigneFacture(CODE_FACTURE, CODE_RESERVATION, CODE_MOUVEMENT, CODE_CHAMBRE, CODE_MODE_PAIEMENT, NUMERO_PIECE, CODE_ARTICLE, CODE_LOT, MONTANT_HT, TAXE, QUANTITE, PRIX_UNITAIRE_TTC, MONTANT_TTC, DATE_FACTURE, HEURE_FACTURE, ETAT_FACTURE, DATE_OCCUPATION, HEURE_OCCUPATION, LIBELLE_FACTURE, TYPE_LIGNE_FACTURE, NUMERO_SERIE, NUMERO_ORDRE, DESCRIPTION, CODE_UTILISATEUR_CREA, CODE_AGENCE, MONTANT_REMISE, MONTANT_TAXE, NUMERO_SERIE_DEBUT, NUMERO_SERIE_FIN, CODE_MAGASIN, FUSIONNEE, TITRE_TYPE) Then

                    End If

                End If
                '----------------------------------------------------

            Next

        End If

    End Sub

    Public Sub facturationEnAvanceApresPronlogement(ByVal CODE_RESERVATION As String, ByVal POSTER_TAX As Integer, ByVal dateDuJour As Date)

        Dim facturer As Boolean = True

        Dim infoSupResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")
        Dim DAY_USE As Integer = 0
        Dim MONTANT_A_FACTURER As Double = 0
        Dim MONTANT_ACCORDE As Double = 0
        Dim MONTANT_TOTAL As Double = 0
        Dim MONTANT_DEJA_FACTURER As Double = 0

        If infoSupResa.Rows.Count > 0 Then

            DAY_USE = infoSupResa.Rows(0)("DAY_USE")
            MONTANT_ACCORDE = infoSupResa.Rows(0)("MONTANT_ACCORDE")

            Dim numberOfHoursToSpend As Integer = 0

            Dim DateTimeArriveeStringFormat As String = CDate(infoSupResa.Rows(0)("HEURE_ENTREE"))
            Dim DateTimeDepartStringFormat As String = CDate(infoSupResa.Rows(0)("HEURE_SORTIE"))

            Dim DateTimeArrivee As DateTime = CDate(DateTimeArriveeStringFormat).ToLongTimeString
            Dim DateTimeDepart As DateTime = CDate(DateTimeDepartStringFormat).ToLongTimeString

            numberOfHoursToSpend = CType((DateTimeDepart - DateTimeArrivee).TotalHours, Int32)

            If numberOfHoursToSpend > 0 Then
                'MONTANT_ACCORDE /= numberOfHoursToSpend
            End If

            MONTANT_TOTAL = MONTANT_ACCORDE

        End If

        If DAY_USE = 1 Then

            'ON DOIT DETERMINER SI LA FACTURATION EXISTE DEJA AVANT DE FACTURER D'AVANCE EN PRENANT EN COMPTE LES FACTURATIONS EXISTANTES
            Dim query As String = "SELECT * FROM ligne_facture 
            WHERE DATE_FACTURE >= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND 
            CODE_RESERVATION=@CODE_RESERVATION AND FUSIONNEE IN ('HEBERGEMENT', 'ACCOMMODATION')"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            If table.Rows.Count > 0 Then

                For i = 0 To table.Rows.Count - 1
                    MONTANT_DEJA_FACTURER += table.Rows(i)("MONTANT_TTC")
                Next

                'DETERMINONS LE MONTANT A FACTURER

                If MONTANT_TOTAL = MONTANT_DEJA_FACTURER Then
                    facturer = False
                Else

                    If MONTANT_TOTAL > MONTANT_DEJA_FACTURER Then
                        facturer = True
                    End If
                    MONTANT_A_FACTURER = MONTANT_TOTAL - MONTANT_DEJA_FACTURER

                End If

            End If

            'FACTURATION ANTICIPE
            If facturer Then

                Dim resa As New Reservation()
                resa.facturationEnAvance(CODE_RESERVATION, POSTER_TAX, MONTANT_A_FACTURER)

                Dim updatedSolde As Double = Functions.SituationDeReservation(CODE_RESERVATION)
                resa.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", updatedSolde)

                Functions.miseAJourDuMontantAReporter(dateDuJour, CODE_RESERVATION)

                Functions.miseAJourMontantAccorderApresFacturationAnticipe(dateDuJour, CODE_RESERVATION, MONTANT_A_FACTURER, POSTER_TAX)

            End If

        Else

            'ON DOIT DETERMINER SI LA FACTURATION EXISTE DEJA AVANT DE FACTURER D'AVANCE
            Dim query As String = "SELECT * FROM ligne_facture 
            WHERE DATE_FACTURE >= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND 
            CODE_RESERVATION=@CODE_RESERVATION AND FUSIONNEE IN ('HEBERGEMENT', 'ACCOMMODATION')"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                facturer = False
            End If

            'FACTURATION ANTICIPE
            If facturer Then

                Dim resa As New Reservation()
                resa.facturationEnAvance(CODE_RESERVATION, POSTER_TAX)

                Dim updatedSolde As Double = Functions.SituationDeReservation(CODE_RESERVATION)
                resa.updateSoldeReservation(CODE_RESERVATION, "reserve_conf", updatedSolde)

                Functions.miseAJourDuMontantAReporter(dateDuJour, CODE_RESERVATION)

                Functions.miseAJourMontantAccorderApresFacturationAnticipe(dateDuJour, CODE_RESERVATION, MONTANT_ACCORDE, POSTER_TAX)

            End If

        End If

    End Sub

    Public Function insertFiscaliteger(ByVal DU As Date, ByVal AU As Date, ByVal CA_CORPORATE As Double, ByVal CA_AUTRES As Double, ByVal CA As Double,
                                       ByVal TAUX As Double, ByVal DATE_CREATION As Date, ByVal NBRE_CORPORATE As Integer, ByVal NBRE_AUTRES As Integer,
                                       ByVal NBRE_TOTAL As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `fiscalite`(`DU`, `AU`, `CA_CORPORATE`, `CA_AUTRES`, `CA`, `TAUX`, `DATE_CREATION`,`NBRE_CORPORATE`, `NBRE_AUTRES`, `NBRE_TOTAL`) 
        VALUES (@DU, @AU, @CA_CORPORATE, @CA_AUTRES, @CA, @TAUX, @DATE_CREATION, @NBRE_CORPORATE, @NBRE_AUTRES, @NBRE_TOTAL)"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@DU", MySqlDbType.Date).Value = DU
        command.Parameters.Add("@AU", MySqlDbType.Date).Value = AU
        command.Parameters.Add("@CA_CORPORATE", MySqlDbType.Double).Value = CA_CORPORATE
        command.Parameters.Add("@CA_AUTRES", MySqlDbType.Double).Value = CA_AUTRES
        command.Parameters.Add("@CA", MySqlDbType.Double).Value = CA
        command.Parameters.Add("@TAUX", MySqlDbType.Double).Value = TAUX
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@NBRE_CORPORATE", MySqlDbType.Int16).Value = NBRE_CORPORATE
        command.Parameters.Add("@NBRE_AUTRES", MySqlDbType.Int16).Value = NBRE_AUTRES
        command.Parameters.Add("@NBRE_TOTAL", MySqlDbType.Int16).Value = NBRE_TOTAL

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Function updateFiscaliteger(ByVal DU As Date, ByVal AU As Date, ByVal CA_CORPORATE As Double, ByVal CA_AUTRES As Double, ByVal CA As Double,
                                       ByVal TAUX As Double, ByVal DATE_CREATION As Date, ByVal NBRE_CORPORATE As Integer, ByVal NBRE_AUTRES As Integer,
                                       ByVal NBRE_TOTAL As Integer, ByVal ID_FISCALITE As Integer) As Boolean

        Dim insertQuery As String = "UPDATE `fiscalite` SET `DU`=@DU,`AU`=@AU,`CA_CORPORATE`=@CA_CORPORATE,`CA_AUTRES`=@CA_AUTRES,
        `CA`=@CA,`TAUX`=@TAUX,`NBRE_CORPORATE`=@NBRE_CORPORATE,`NBRE_AUTRES`=@NBRE_AUTRES,`NBRE_TOTAL`=@NBRE_TOTAL
        WHERE ID_FISCALITE =@ID_FISCALITE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@DU", MySqlDbType.Date).Value = DU
        command.Parameters.Add("@AU", MySqlDbType.Date).Value = AU
        command.Parameters.Add("@CA_CORPORATE", MySqlDbType.Double).Value = CA_CORPORATE
        command.Parameters.Add("@CA_AUTRES", MySqlDbType.Double).Value = CA_AUTRES
        command.Parameters.Add("@CA", MySqlDbType.Double).Value = CA
        command.Parameters.Add("@TAUX", MySqlDbType.Double).Value = TAUX
        'command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@NBRE_CORPORATE", MySqlDbType.Int16).Value = NBRE_CORPORATE
        command.Parameters.Add("@NBRE_AUTRES", MySqlDbType.Int16).Value = NBRE_AUTRES
        command.Parameters.Add("@NBRE_TOTAL", MySqlDbType.Int16).Value = NBRE_TOTAL
        command.Parameters.Add("@ID_FISCALITE", MySqlDbType.Int16).Value = ID_FISCALITE

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
