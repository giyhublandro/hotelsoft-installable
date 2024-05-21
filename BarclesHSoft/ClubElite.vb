
Imports MySql.Data.MySqlClient

Public Class ClubElite

    Public Function insertConfigElite(
                                ByVal MEMBRE As String,
                                ByVal ELIGIBILITE_NUITS As Integer,
                                ByVal ELIGIBILITE_POINTS As Integer,
                                ByVal ELIGIBILITE_SEJOURS As Integer,
                                ByVal REDUCTION_ACCORDEE As Double,
                                ByVal VAEUR_DU_POINT As Double,
                                ByVal PALIER_DE_DEPENSE As Double,
                                ByVal POINT_PAR_PALIER_DE_DEPENSE As Integer,
                                ByVal NOMBRE_NUITEE_EGALE_A_UNE_NUITEE As Integer,
                                ByVal NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE As Integer)

        Dim insertQuery As String = "INSERT INTO `club_elite_membre`(`MEMBRE`, `ELIGIBILITE_NUITS`, `ELIGIBILITE_POINTS`, `ELIGIBILITE_SEJOURS`, 
        `REDUCTION_ACCORDEE`, `VAEUR_DU_POINT`, `PALIER_DE_DEPENSE`, `POINT_PAR_PALIER_DE_DEPENSE`, `NOMBRE_NUITEE_EGALE_A_UNE_NUITEE`, `NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE`) 
        VALUES (@MEMBRE,@ELIGIBILITE_NUITS,@ELIGIBILITE_POINTS,@ELIGIBILITE_SEJOURS, @REDUCTION_ACCORDEE, @VAEUR_DU_POINT, @PALIER_DE_DEPENSE, @POINT_PAR_PALIER_DE_DEPENSE, 
        @NOMBRE_NUITEE_EGALE_A_UNE_NUITEE, @NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@MEMBRE", MySqlDbType.VarChar).Value = MEMBRE
        command.Parameters.Add("@ELIGIBILITE_NUITS", MySqlDbType.Int64).Value = ELIGIBILITE_NUITS
        command.Parameters.Add("@ELIGIBILITE_POINTS", MySqlDbType.Int64).Value = ELIGIBILITE_POINTS
        command.Parameters.Add("@ELIGIBILITE_SEJOURS", MySqlDbType.Int64).Value = ELIGIBILITE_SEJOURS
        command.Parameters.Add("@REDUCTION_ACCORDEE", MySqlDbType.Double).Value = REDUCTION_ACCORDEE
        command.Parameters.Add("@VAEUR_DU_POINT", MySqlDbType.Double).Value = VAEUR_DU_POINT
        command.Parameters.Add("@PALIER_DE_DEPENSE", MySqlDbType.Double).Value = PALIER_DE_DEPENSE
        command.Parameters.Add("@POINT_PAR_PALIER_DE_DEPENSE", MySqlDbType.Int64).Value = POINT_PAR_PALIER_DE_DEPENSE
        command.Parameters.Add("@NOMBRE_NUITEE_EGALE_A_UNE_NUITEE", MySqlDbType.Int64).Value = NOMBRE_NUITEE_EGALE_A_UNE_NUITEE
        command.Parameters.Add("@NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE", MySqlDbType.Int64).Value = NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE

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

    Public Function updateConfigElite(
                                ByVal MEMBRE As String,
                                ByVal ELIGIBILITE_NUITS As Integer,
                                ByVal ELIGIBILITE_POINTS As Integer,
                                ByVal ELIGIBILITE_SEJOURS As Integer,
                                ByVal REDUCTION_ACCORDEE As Double,
                                ByVal VAEUR_DU_POINT As Double,
                                ByVal PALIER_DE_DEPENSE As Double,
                                ByVal POINT_PAR_PALIER_DE_DEPENSE As Integer,
                                ByVal NOMBRE_NUITEE_EGALE_A_UNE_NUITEE As Integer,
                                ByVal NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE As Integer)

        Dim insertQuery As String = "UPDATE `club_elite_membre` SET `MEMBRE`=@MEMBRE,`ELIGIBILITE_NUITS`=@ELIGIBILITE_NUITS,
`ELIGIBILITE_POINTS`=@ELIGIBILITE_POINTS,`ELIGIBILITE_SEJOURS`=@ELIGIBILITE_SEJOURS,`REDUCTION_ACCORDEE`=@REDUCTION_ACCORDEE, `VAEUR_DU_POINT`=@VAEUR_DU_POINT,
`PALIER_DE_DEPENSE`=@PALIER_DE_DEPENSE,`POINT_PAR_PALIER_DE_DEPENSE`=@POINT_PAR_PALIER_DE_DEPENSE, NOMBRE_NUITEE_EGALE_A_UNE_NUITEE=@NOMBRE_NUITEE_EGALE_A_UNE_NUITEE, 
NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE=@NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE WHERE `MEMBRE`=@MEMBRE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@MEMBRE", MySqlDbType.VarChar).Value = MEMBRE
        command.Parameters.Add("@ELIGIBILITE_NUITS", MySqlDbType.Int64).Value = ELIGIBILITE_NUITS
        command.Parameters.Add("@ELIGIBILITE_POINTS", MySqlDbType.Int64).Value = ELIGIBILITE_POINTS
        command.Parameters.Add("@ELIGIBILITE_SEJOURS", MySqlDbType.Int64).Value = ELIGIBILITE_SEJOURS
        command.Parameters.Add("@REDUCTION_ACCORDEE", MySqlDbType.Double).Value = REDUCTION_ACCORDEE
        command.Parameters.Add("@VAEUR_DU_POINT", MySqlDbType.Double).Value = VAEUR_DU_POINT
        command.Parameters.Add("@PALIER_DE_DEPENSE", MySqlDbType.Double).Value = PALIER_DE_DEPENSE
        command.Parameters.Add("@POINT_PAR_PALIER_DE_DEPENSE", MySqlDbType.Int64).Value = POINT_PAR_PALIER_DE_DEPENSE
        command.Parameters.Add("@NOMBRE_NUITEE_EGALE_A_UNE_NUITEE", MySqlDbType.Int64).Value = NOMBRE_NUITEE_EGALE_A_UNE_NUITEE
        command.Parameters.Add("@NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE", MySqlDbType.Int64).Value = NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function affectationElite(
                                ByVal TYPE_MEMBRE As String,
                                ByVal CODE_CLIENT_CARTE As String,
                                ByVal ID_CARTE_ELITE As String)

        Dim insertQuery As String = "INSERT INTO `club_elite_membre_client`( `TYPE_MEMBRE`, `CODE_CLIENT_CARTE`, `ID_CARTE_ELITE`) 
                                            VALUES (@TYPE_MEMBRE, @CODE_CLIENT_CARTE, @ID_CARTE_ELITE)"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE_MEMBRE", MySqlDbType.VarChar).Value = TYPE_MEMBRE
        command.Parameters.Add("@CODE_CLIENT_CARTE", MySqlDbType.VarChar).Value = CODE_CLIENT_CARTE
        command.Parameters.Add("@ID_CARTE_ELITE", MySqlDbType.VarChar).Value = ID_CARTE_ELITE

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function updateAffectationElite(
                                ByVal TYPE_MEMBRE As String,
                                ByVal CODE_CLIENT_CARTE As String,
                                ByVal ID_CARTE_ELITE As String,
                                ByVal ID_CARTE_ELITE_OLD As String)

        Dim insertQuery As String = "UPDATE `club_elite_membre_client` SET `TYPE_MEMBRE`=@TYPE_MEMBRE, `CODE_CLIENT_CARTE`=@CODE_CLIENT_CARTE, `ID_CARTE_ELITE`=@ID_CARTE_ELITE 
                                        WHERE ID_CARTE_ELITE=@ID_CARTE_ELITE_OLD"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE_MEMBRE", MySqlDbType.VarChar).Value = TYPE_MEMBRE
        command.Parameters.Add("@CODE_CLIENT_CARTE", MySqlDbType.VarChar).Value = CODE_CLIENT_CARTE
        command.Parameters.Add("@ID_CARTE_ELITE", MySqlDbType.VarChar).Value = ID_CARTE_ELITE
        command.Parameters.Add("@ID_CARTE_ELITE_OLD", MySqlDbType.VarChar).Value = ID_CARTE_ELITE_OLD

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    'LISTE DES MEMBRES AYANT DES CARTE DE FIDELITE

    Public Sub list(ByVal dt As DataGridView, ByVal UPGRADE As Integer, ByVal Optional id_carte_nom_client As String = "")

        Dim insertQuery As String = ""


        If UPGRADE = 0 Then 'TOUS LES CLIENTS

            If Trim(id_carte_nom_client).Equals("") Then
                If GlobalVariable.actualLanguageValue = 1 Then
                    insertQuery = "SELECT `TYPE_MEMBRE` AS MEMBRE, NOM_PRENOM AS CLIENT, `ID_CARTE_ELITE` AS 'ID CARTE', `POINTS`, `SEJOURS`, `NUITS`, CODE_CLIENT_CARTE  
                                FROM club_elite_membre_client, client WHERE CODE_CLIENT_CARTE = CODE_CLIENT ORDER BY ID_CARTE_ELITE ASC"
                Else
                    insertQuery = "SELECT `TYPE_MEMBRE` AS MEMBER, NOM_PRENOM AS CLIENT, `ID_CARTE_ELITE` AS 'ID CARD', `POINTS`, `SEJOURS` AS STAY, `NUITS` AS NIGHTS, CODE_CLIENT_CARTE
                                FROM club_elite_membre_client, client WHERE CODE_CLIENT_CARTE = CODE_CLIENT ORDER BY ID_CARTE_ELITE ASC"
                End If
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    insertQuery = "SELECT `TYPE_MEMBRE` AS MEMBRE, NOM_PRENOM AS CLIENT, `ID_CARTE_ELITE` AS 'ID CARTE', `POINTS`, `SEJOURS`, `NUITS`,CODE_CLIENT_CARTE  
                                FROM club_elite_membre_client, client 
                                WHERE CODE_CLIENT_CARTE = CODE_CLIENT AND ID_CARTE_ELITE LIKE '%" & id_carte_nom_client & "%'
                                OR CODE_CLIENT_CARTE = CODE_CLIENT AND NOM_PRENOM LIKE '%" & id_carte_nom_client & "%'
                                OR CODE_CLIENT_CARTE = CODE_CLIENT AND TYPE_MEMBRE LIKE '%" & id_carte_nom_client & "%'
                                ORDER BY NOM_PRENOM ASC"
                Else
                    insertQuery = "SELECT `TYPE_MEMBRE` AS MEMBER, NOM_PRENOM AS CLIENT, `ID_CARTE_ELITE` AS 'CARD ID', `POINTS`, `SEJOURS` AS STAY, `NUITS` AS NIGHTS, CODE_CLIENT_CARTE
                                FROM club_elite_membre_client, client 
                                WHERE CODE_CLIENT_CARTE = CODE_CLIENT AND ID_CARTE_ELITE LIKE '%" & id_carte_nom_client & "%'
                                OR CODE_CLIENT_CARTE = CODE_CLIENT AND NOM_PRENOM LIKE '%" & id_carte_nom_client & "%' 
                                OR CODE_CLIENT_CARTE = CODE_CLIENT AND TYPE_MEMBRE LIKE '%" & id_carte_nom_client & "%'
                                ORDER BY NOM_PRENOM ASC"
                End If

            End If

        Else

            If Trim(id_carte_nom_client).Equals("") Then 'LES CLIENTS DEVANT ETRE UPGRADE
                If GlobalVariable.actualLanguageValue = 1 Then
                    insertQuery = "SELECT `TYPE_MEMBRE` AS MEMBRE, NOM_PRENOM AS CLIENT, `ID_CARTE_ELITE` AS 'ID CARTE', `POINTS`, `SEJOURS`, `NUITS`, CODE_CLIENT_CARTE  
                                FROM club_elite_membre_client, client WHERE UPGRADE=@UPGRADE AND CODE_CLIENT_CARTE = CODE_CLIENT ORDER BY ID_CARTE_ELITE ASC"
                Else
                    insertQuery = "SELECT `TYPE_MEMBRE` AS MEMBER, NOM_PRENOM AS CLIENT, `ID_CARTE_ELITE` AS 'ID CARD', `POINTS`, `SEJOURS` AS STAY, `NUITS` AS NIGHTS, CODE_CLIENT_CARTE
                                FROM club_elite_membre_client, client WHERE UPGRADE=@UPGRADE AND CODE_CLIENT_CARTE = CODE_CLIENT ORDER BY ID_CARTE_ELITE ASC"
                End If
            Else
                If GlobalVariable.actualLanguageValue = 1 Then
                    insertQuery = "SELECT `TYPE_MEMBRE` AS MEMBRE, NOM_PRENOM AS CLIENT, `ID_CARTE_ELITE` AS 'ID CARTE', `POINTS`, `SEJOURS`, `NUITS`,CODE_CLIENT_CARTE  
                                FROM club_elite_membre_client, client 
                                WHERE UPGRADE=@UPGRADE AND CODE_CLIENT_CARTE = CODE_CLIENT AND ID_CARTE_ELITE LIKE '%" & id_carte_nom_client & "%'
                                OR UPGRADE=@UPGRADE AND CODE_CLIENT_CARTE = CODE_CLIENT AND NOM_PRENOM LIKE '%" & id_carte_nom_client & "%'
                                OR UPGRADE=@UPGRADE AND CODE_CLIENT_CARTE = CODE_CLIENT AND TYPE_MEMBRE LIKE '%" & id_carte_nom_client & "%'
                                ORDER BY NOM_PRENOM ASC"
                Else
                    insertQuery = "SELECT `TYPE_MEMBRE` AS MEMBER, NOM_PRENOM AS CLIENT, `ID_CARTE_ELITE` AS 'CARD ID', `POINTS`, `SEJOURS` AS STAY, `NUITS` AS NIGHTS, CODE_CLIENT_CARTE
                                FROM club_elite_membre_client, client 
                                WHERE UPGRADE=@UPGRADE AND CODE_CLIENT_CARTE = CODE_CLIENT AND ID_CARTE_ELITE LIKE '%" & id_carte_nom_client & "%'
                                OR UPGRADE=@UPGRADE AND CODE_CLIENT_CARTE = CODE_CLIENT AND NOM_PRENOM LIKE '%" & id_carte_nom_client & "%' 
                                OR UPGRADE=@UPGRADE AND CODE_CLIENT_CARTE = CODE_CLIENT AND TYPE_MEMBRE LIKE '%" & id_carte_nom_client & "%'
                                ORDER BY NOM_PRENOM ASC"
                End If

            End If

        End If



        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command.Parameters.Add("@UPGRADE", MySqlDbType.Int64).Value = UPGRADE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            dt.DataSource = table
        Else
            dt.DataSource = Nothing
        End If

    End Sub

    Public Function infoDuCodeElite(ByVal CODE_ELITE As String)

        Dim getUserQuery = "SELECT `MEMBRE`, `ELIGIBILITE_NUITS`, `ELIGIBILITE_POINTS`, `ELIGIBILITE_SEJOURS`, `REDUCTION_ACCORDEE`, `VAEUR_DU_POINT`, `PALIER_DE_DEPENSE`, 
        `POINT_PAR_PALIER_DE_DEPENSE`, `TYPE_MEMBRE`, `CODE_CLIENT_CARTE`, `ID_CARTE_ELITE`, `POINTS`, `SEJOURS`, `NUITS`, `NOMBRE_NUITEE_EGALE_A_UNE_NUITEE`, 
        NOMBRE_SEJOUR_EGALE_A_UNE_NUITEE FROM `club_elite_membre`, club_elite_membre_client WHERE MEMBRE = TYPE_MEMBRE AND ID_CARTE_ELITE=@CODE_ELITE"
        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = CODE_ELITE

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Return dt

    End Function

    'GESTION DE L'AJOUT DES SEJOURS AU BENEFICE DU CLIENT

    Public Sub remplissageDesChampsPermettantLeUpGradingDuClient_(ByVal CODE_CLIENT As String, ByVal dt As DataTable)

        Dim infoSupCLient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

        If infoSupCLient.Rows.Count > 0 Then

            If Not Trim(infoSupCLient.Rows(0)("CODE_ELITE")).Equals("") Then
                Dim CODE_ELITE As String = Trim(infoSupCLient.Rows(0)("CODE_ELITE"))
                Dim eliteInfo As DataTable = infoDuCodeElite(CODE_ELITE)
                Dim CODE_RESERVATION As String = ""

                If dt.Rows.Count > 0 Then
                    CODE_RESERVATION = dt.Rows(0)("CODE_RESERVATION")
                End If

                If eligibleAuPoint(CODE_RESERVATION) Then

                    Dim SEJOURS As Integer = 1
                    Dim NUITS As Integer = 0
                    Dim POINTS As Integer = 0
                    If dt.Rows.Count > 0 Then

                        NUITS = CType((dt.Rows(0)("DATE_SORTIE") - dt.Rows(0)("DATE_ENTTRE")).TotalDays, Int32)

                        If NUITS >= 2 Then

                            NUITS = 0

                            Dim TYPE_CHAMBRE As String = dt.Rows(0)("TYPE_CHAMBRE")

                            update_club_elite_membre_conso_client(CODE_ELITE, CODE_CLIENT, CODE_RESERVATION, TYPE_CHAMBRE)

                            update_club_elite_membre_client(SEJOURS, NUITS, POINTS, CODE_ELITE)

                        End If

                    End If
                End If

            End If
        End If

    End Sub

    'REMPLISSAGE DES POINTS DE SUR L'ENSEMBLE DES EN CHAMBRES
    Public Sub remplissageDesChampsPermettantLeUpGradingDuClient(ByVal enChambre As DataTable)

        Dim infoSupCLient As DataTable

        Dim CODE_RESERVATION As String = ""
        Dim CODE_CLIENT As String = ""

        For i = 0 To enChambre.Rows.Count - 1

            CODE_CLIENT = enChambre.Rows(i)("CODE_ENTREPRISE")
            CODE_RESERVATION = enChambre.Rows(i)("CODE_RESERVATION")

            If Trim(CODE_CLIENT).Equals("") Then
                CODE_CLIENT = enChambre.Rows(i)("CLIENT_ID")
            End If

            infoSupCLient = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

            If infoSupCLient.Rows.Count > 0 Then

                If Not Trim(infoSupCLient.Rows(0)("CODE_ELITE")).Equals("") Then

                    Dim CODE_ELITE As String = Trim(infoSupCLient.Rows(0)("CODE_ELITE"))
                    Dim dt As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")
                    Dim eliteInfo As DataTable = infoDuCodeElite(CODE_ELITE)

                    Dim source As Boolean = eligibleAuPoint(CODE_RESERVATION)

                    If source Then
                        gestionDesElementsDesDuNiveauxAdhesion(CODE_ELITE, dt, eliteInfo, CODE_CLIENT)
                    End If

                End If

            End If

        Next

    End Sub

    Public Function eligibleAuPoint(ByVal CODE_RESERVATION As String)

        Dim Query As String = "SELECT source_reservation.SOURCE_RESERVATION,CODE_RESERVATION  FROM reserve_conf, source_reservation
            WHERE CODE_RESERVATION=@CODE_RESERVATION AND source_reservation.CODE_SOURCE_RESERVATION=reserve_conf.SOURCE_RESERVATION AND source_reservation.SOURCE_RESERVATION IN ('CORPORATE', 'HOTELSOFT.CM', 'COMPTOIR', 'WALK IN')"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim adapterList As New MySqlDataAdapter(command)
        Dim dt As New DataTable()

        adapterList.Fill(dt)

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub update_club_elite_membre_client(ByVal SEJOURS As Integer, ByVal NUITS As Integer, ByVal POINTS As Integer, ByVal CODE_ELITE As String)

        Dim insertQuery As String = "UPDATE `club_elite_membre_client` SET `POINTS`=POINTS + @POINTS, `NUITS`=NUITS + @NUITS, `SEJOURS`=SEJOURS + @SEJOURS 
                                        WHERE ID_CARTE_ELITE=@CODE_ELITE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@SEJOURS", MySqlDbType.Int64).Value = SEJOURS
        command.Parameters.Add("@NUITS", MySqlDbType.Int64).Value = NUITS
        command.Parameters.Add("@POINTS", MySqlDbType.Int64).Value = POINTS
        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = CODE_ELITE

        command.ExecuteNonQuery()

    End Sub

    'POUR LES HEBERGEMENTS PERMET DE REGROUPER LES CONSOMMATIONS PAR TYPE DE CHAMBRE

    Public Sub update_club_elite_membre_conso_client(ByVal CODE_ELITE As String, ByVal CODE_CLIENT As String, ByVal CODE_RESERVATION As String, ByVal TYPE_CHAMBRE As String)

        Dim insertQuery As String = "INSERT INTO `club_elite_membre_conso_client` (`CODE_ELITE`, `CODE_CLIENT`, `CODE_RESERVATION`, `TYPE_CHAMBRE`)
        VALUES (@CODE_ELITE, @CODE_CLIENT, @CODE_RESERVATION, @TYPE_CHAMBRE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = CODE_ELITE
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = TYPE_CHAMBRE

        command.ExecuteNonQuery()

    End Sub

    Public Function totalExpenditure(ByVal CODE_RESERVATION As String)

        Dim expense As Double = 0
        Dim dt As DataTable = Functions.getElementByCode(CODE_RESERVATION, "ligne_facture", "CODE_RESERVATION")

        For i = 0 To dt.Rows.Count - 1
            expense += dt.Rows(i)("MONTANT_TTC")
        Next

        Return expense

    End Function

    Public Function totalExpenditureDuJour(ByVal CODE_RESERVATION As String)

        Dim expense As Double = 0

        Dim DateDebut As Date = GlobalVariable.DateDeTravail.AddDays(-1)
        Dim DateFin As Date = GlobalVariable.DateDeTravail.AddDays(-1)

        Dim Query As String = "SELECT * FROM ligne_facture
            WHERE DATE_FACTURE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE <='" & DateFin.ToString("yyyy-MM-dd") & "'
           AND CODE_RESERVATION=@CODE_RESERVATION"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        Dim adapterList As New MySqlDataAdapter(command)
        Dim dt As New DataTable()

        adapterList.Fill(dt)

        For i = 0 To dt.Rows.Count - 1
            expense += dt.Rows(i)("MONTANT_TTC")
        Next

        Return expense

    End Function

    'AUGMENTATION DES POINTS DES CLIENTS COMPTOIRS
    Public Sub augmentationDesPointsDesClientsComptoirs(ByVal CODE_CLIENT As String, ByVal DEPENSE As Double)

        Dim POINTS As Integer = 0
        Dim NUITS As Integer = 0
        Dim SEJOURS As Integer = 0

        Dim PALIER_DE_DEPENSE As Double = 0
        Dim POINT_PAR_PALIER_DE_DEPENSE As Double = 0
        Dim VAEUR_DU_POINT As Double = 0

        Dim infoSupCLient As DataTable = Functions.getElementByCode(CODE_CLIENT, "client", "CODE_CLIENT")

        If infoSupCLient.Rows.Count > 0 Then

            If Not Trim(infoSupCLient.Rows(0)("CODE_ELITE")).Equals("") Then
                Dim CODE_ELITE As String = Trim(infoSupCLient.Rows(0)("CODE_ELITE"))
                Dim eliteInfo As DataTable = infoDuCodeElite(CODE_ELITE)
                If eliteInfo.Rows.Count > 0 Then

                    PALIER_DE_DEPENSE = eliteInfo.Rows(0)("PALIER_DE_DEPENSE")
                    POINT_PAR_PALIER_DE_DEPENSE = eliteInfo.Rows(0)("POINT_PAR_PALIER_DE_DEPENSE")
                    VAEUR_DU_POINT = eliteInfo.Rows(0)("VAEUR_DU_POINT")

                    If PALIER_DE_DEPENSE > 0 Then
                        POINTS = (DEPENSE / PALIER_DE_DEPENSE) * POINT_PAR_PALIER_DE_DEPENSE
                    End If

                End If

                update_club_elite_membre_client(0, 0, POINTS, CODE_ELITE)

                Dim ACTUEL As Integer = 0
                Dim ID_CARTE As String = CODE_ELITE
                Dim AVANT As Integer = 0

                Dim infoCodeClient As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_CLIENT, "club_elite_membre_client", "CODE_CLIENT_CARTE", CODE_ELITE, "ID_CARTE_ELITE")

                If infoCodeClient.Rows.Count > 0 Then
                    ACTUEL = infoCodeClient.Rows(0)("POINTS")
                End If

                AVANT = ACTUEL - POINTS

                Dim VALEUR_FINANCIERE As Double = ACTUEL * VAEUR_DU_POINT
                historiques_des_points(ACTUEL, AVANT, ID_CARTE, CODE_CLIENT, POINTS, VALEUR_FINANCIERE)

            End If

        End If

    End Sub

    'AUGMENTATION DES POINTS DES CLIENTS LOGES
    Public Sub gestionDesElementsDesDuNiveauxAdhesion(ByVal CODE_ELITE As String, ByVal resaInfo As DataTable, ByVal eliteInfo As DataTable, ByVal CODE_CLIENT As String)

        Dim POINTS As Integer = -1
        Dim NUITS As Integer = -1
        Dim SEJOURS As Integer = 0

        Dim PALIER_DE_DEPENSE As Double = 0
        Dim POINT_PAR_PALIER_DE_DEPENSE As Double = 0
        Dim VAEUR_DU_POINT As Double = 0

        Dim CODE_RESERVATION As String = resaInfo.Rows(0)("CODE_RESERVATION")
        'Dim DEPENSE As Double = totalExpenditure(CODE_RESERVATION)
        Dim DEPENSE As Double = totalExpenditureDuJour(CODE_RESERVATION)

        If resaInfo.Rows.Count > 0 Then

            'NUITS = CType((resaInfo.Rows(0)("DATE_SORTIE") - resaInfo.Rows(0)("DATE_ENTTRE")).TotalDays, Int32)

            NUITS = 1

            Dim TYPE_CHAMBRE As String = resaInfo.Rows(0)("TYPE_CHAMBRE")

            'update_club_elite_membre_conso_client(CODE_ELITE, CODE_CLIENT, CODE_RESERVATION, TYPE_CHAMBRE)

        End If

        If eliteInfo.Rows.Count > 0 Then

            PALIER_DE_DEPENSE = eliteInfo.Rows(0)("PALIER_DE_DEPENSE")
            POINT_PAR_PALIER_DE_DEPENSE = eliteInfo.Rows(0)("POINT_PAR_PALIER_DE_DEPENSE")
            VAEUR_DU_POINT = eliteInfo.Rows(0)("VAEUR_DU_POINT")

            If PALIER_DE_DEPENSE > 0 Then
                POINTS = (DEPENSE / PALIER_DE_DEPENSE) * POINT_PAR_PALIER_DE_DEPENSE
            End If

        End If

        update_club_elite_membre_client(SEJOURS, NUITS, POINTS, CODE_ELITE)

        Dim ACTUEL As Integer = 0
        Dim ID_CARTE As String = CODE_ELITE
        Dim AVANT As Integer = 0

        Dim infoCodeClient As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_CLIENT, "club_elite_membre_client", "CODE_CLIENT_CARTE", CODE_ELITE, "ID_CARTE_ELITE")

        If infoCodeClient.Rows.Count > 0 Then
            ACTUEL = infoCodeClient.Rows(0)("POINTS")
        End If

        AVANT = ACTUEL - POINTS

        Dim VALEUR_FINANCIERE As Double = ACTUEL * VAEUR_DU_POINT
        historiques_des_points(ACTUEL, AVANT, ID_CARTE, CODE_CLIENT, POINTS, VALEUR_FINANCIERE)

    End Sub

    Public Sub historiques_des_points(ByVal ACTUEL As Integer, ByVal AVANT As Integer, ByVal ID_CARTE As String, ByVal CODE_CLIENT As String, ByVal POINTS As Integer, ByVal VALEUR_FINANCIERE As Double)

        Dim insertQuery As String = "INSERT INTO `club_elite_historiques_des_points` (`ACTUEL`, `AVANT`, `DATE_DU_JOUR`, `ID_CARTE`, `CODE_CLIENT`, `POINT`, `VALEUR_FINANCIERE`)
        VALUES (@ACTUEL, @AVANT, @DATE_DU_JOUR, @ID_CARTE, @CODE_CLIENT, @POINT, @VALEUR_FINANCIERE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@ACTUEL", MySqlDbType.Int64).Value = ACTUEL
        command.Parameters.Add("@AVANT", MySqlDbType.Int64).Value = AVANT
        command.Parameters.Add("@POINT", MySqlDbType.Int64).Value = POINTS
        command.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail.AddDays(-1)
        command.Parameters.Add("@ID_CARTE", MySqlDbType.VarChar).Value = ID_CARTE
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@VALEUR_FINANCIERE", MySqlDbType.Double).Value = VALEUR_FINANCIERE

        command.ExecuteNonQuery()

    End Sub


    'PERMET D'EFECTUER DES REDUCTIONS SELON LE NIVEAU ADHESION DU CLUB ELITE
    Public Function affichageDuPrixAvecReduction(ByVal TAUX_REDUCTION As Double, ByVal typeChambreOuSalle As String, ByVal ACCORDE_TEXTBOX As TextBox)

        Dim MONTANT_ACCORDE As Double = 0

        If Not Trim(ACCORDE_TEXTBOX.Text).Equals("") Then
            MONTANT_ACCORDE = ACCORDE_TEXTBOX.Text
        End If

        Dim DISCOUNT As Double = MONTANT_ACCORDE - ((TAUX_REDUCTION / 100) * MONTANT_ACCORDE)

        ACCORDE_TEXTBOX.Text = Format(DISCOUNT, "#,##0")

    End Function

    Public Function nombreDeNuiteeOuSejour(ByVal TYPE_CHAMBRE As String, ByVal CODE_ELITE As String, ByVal CODE_CLIENT As String, ByVal m As Integer)

        Dim n As Integer = 0

        Dim getUserQuery = "SELECT * FROM club_elite_membre_conso_client WHERE CODE_ELITE = @CODE_ELITE AND CODE_CLIENT=@CODE_CLIENT AND ETAT=1"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = CODE_ELITE
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        If dt.Rows.Count > 0 Then

            If m = 1 Then 'NUITEES

                Dim CODE_RESERVATION As String = ""
                Dim DATE_ENTREE As Date
                Dim DATE_SORTIE As Date

                For i = 0 To dt.Rows.Count - 1

                    CODE_RESERVATION = dt.Rows(i)("CODE_RESERVATION")
                    Dim infoSupResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                    If infoSupResa.Rows.Count > 0 Then

                        DATE_ENTREE = infoSupResa.Rows(0)("DATE_ENTTRE")
                        DATE_SORTIE = infoSupResa.Rows(0)("DATE_SORTIE")

                        n += CType((DATE_SORTIE - DATE_ENTREE).TotalDays, Int32)

                    End If

                Next

            ElseIf m = 2 Then 'SEJOURS
                n = dt.Rows.Count
            End If

        End If

        Return n

    End Function


    Public Sub annulationDesSejoursPourNePlusPrendreEnCompteApresReglement(ByVal TYPE_CHAMBRE As String, ByVal CODE_ELITE As String, ByVal CODE_CLIENT As String, ByVal m As Integer)

        Dim n As Integer = 0

        Dim getUserQuery = "SELECT * FROM club_elite_membre_conso_client WHERE CODE_ELITE = @CODE_ELITE AND CODE_CLIENT=@CODE_CLIENT AND ETAT=1"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = CODE_ELITE
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        If dt.Rows.Count > 0 Then

            If m = 1 Then 'NUITEES

                Dim CODE_RESERVATION As String = ""

                For i = 0 To m - 1

                    CODE_RESERVATION = dt.Rows(i)("CODE_RESERVATION")

                    Functions.updateOfFields("club_elite_membre_conso_client", "ETAT", 0, "CODE_RESERVATION", CODE_RESERVATION, 1)

                Next

            ElseIf m = 2 Then 'SEJOURS
                n = dt.Rows.Count
            End If

        End If

    End Sub

    Public Function historiquesAccummulationDesPoints(ByVal CODE_ELITE As String, ByVal CODE_CLIENT As String)

        Dim Query As String = ""

        If GlobalVariable.actualLanguageValue = 1 Then
            Query = "SELECT `DATE_DU_JOUR` AS DATE, `POINT` AS '# POINTS GAGNES / UTILISES', `AVANT` AS '# POINTS PRECEDENTS', `ACTUEL` AS '# POINTS ACTUEL', VALEUR_FINANCIERE AS 'VALEUR FINANCIERE' 
            FROM club_elite_historiques_des_points, client WHERE ID_CARTE=@CODE_ELITE AND club_elite_historiques_des_points.CODE_CLIENT=@CODE_CLIENT AND club_elite_historiques_des_points.CODE_CLIENT = client.CODE_CLIENT
            ORDER BY ID_HOSTORIQUES_DES_POINTS DESC"
        Else
            Query = "SELECT `DATE_DU_JOUR` AS DATE, `POINT` AS '# POINTS WON / USED', `AVANT` AS '# POINTS BEFORE', `ACTUEL` AS 'ACTUAL # POINTS', VALEUR_FINANCIERE AS 'FINANCIAL VALUE'
            FROM club_elite_historiques_des_points, client WHERE ID_CARTE=@CODE_ELITE AND club_elite_historiques_des_points.CODE_CLIENT=@CODE_CLIENT AND club_elite_historiques_des_points.CODE_CLIENT = client.CODE_CLIENT
            ORDER BY ID_HOSTORIQUES_DES_POINTS DESC"
        End If

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = CODE_ELITE
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        Dim adapterList As New MySqlDataAdapter(command)
        Dim dt As New DataTable()

        adapterList.Fill(dt)

        Return dt

    End Function

    Public Function verificationDesUpGradeDesCodeElites(ByVal dtGrid As DataGridView)

        Dim getUserQuery = "SELECT * FROM club_elite_membre_client"

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()

        adapter.SelectCommand = command
        adapter.Fill(dt)

        Dim CODE_ELITE As String = ""
        Dim infoSupCodeElite As DataTable
        Dim infoSupCodeEliteCompare As DataTable

        Dim POINTS As Integer = 0
        Dim SEJOURS As Integer = 0
        Dim NUITS As Integer = 0
        Dim MEMBRE As String = ""

        Dim ELIGIBILITE_NUITS As Integer = 0
        Dim ELIGIBILITE_POINTS As Integer = 0
        Dim ELIGIBILITE_SEJOURS As Integer = 0

        Dim nombreDeUpGrading As Integer = 0

        If dt.Rows.Count > 0 Then

            For i = 0 To dt.Rows.Count - 1

                CODE_ELITE = dt.Rows(i)("ID_CARTE_ELITE")
                MEMBRE = dt.Rows(i)("TYPE_MEMBRE")
                infoSupCodeElite = infoDuCodeElite(CODE_ELITE)

                If infoSupCodeElite.Rows.Count > 0 Then

                    If Trim(MEMBRE).Equals("SILVER") Then
                        infoSupCodeEliteCompare = Functions.getElementByCode("GOLD", "club_elite_membre", "MEMBRE")
                    ElseIf Trim(MEMBRE).Equals("GOLD") Then
                        infoSupCodeEliteCompare = Functions.getElementByCode("PLATINUM", "club_elite_membre", "MEMBRE")
                    End If

                    If Not Trim(MEMBRE).Equals("PLATINUM") Then

                        If Not infoSupCodeEliteCompare Is Nothing Then

                            If infoSupCodeEliteCompare.Rows.Count > 0 Then

                                ELIGIBILITE_NUITS = infoSupCodeEliteCompare.Rows(0)("ELIGIBILITE_NUITS")
                                ELIGIBILITE_POINTS = infoSupCodeEliteCompare.Rows(0)("ELIGIBILITE_POINTS")
                                ELIGIBILITE_SEJOURS = infoSupCodeEliteCompare.Rows(0)("ELIGIBILITE_SEJOURS")

                            End If

                        End If

                        POINTS = infoSupCodeElite.Rows(0)("POINTS")
                        SEJOURS = infoSupCodeElite.Rows(0)("SEJOURS")
                        NUITS = infoSupCodeElite.Rows(0)("NUITS")

                        If NUITS >= ELIGIBILITE_NUITS Then

                        ElseIf POINTS >= ELIGIBILITE_POINTS Then

                        ElseIf SEJOURS >= ELIGIBILITE_POINTS Then

                        End If
                    End If

                End If

            Next

        End If

        Return nombreDeUpGrading

    End Function

End Class
