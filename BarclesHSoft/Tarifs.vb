Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Tarifs

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new entry
    Public Function insert(Optional ByVal CODE_TARIF As String = "", Optional ByVal LIBELLE_TARIF As String = "", Optional ByVal DESCRIPTION_TARIF As String = "", Optional ByVal TYPE_TARIF As String = "", ByVal Optional CODE_TYPE As String = "", Optional ByVal PRIX_TARIF1 As Double = 0, Optional ByVal PRIX_TARIF2 As Double = 0, Optional ByVal PRIX_TARIF3 As Double = 0, Optional ByVal PRIX_TARIF4 As Double = 0, Optional ByVal PRIX_TARIF5 As Double = 0, Optional ByVal TABLE As String = "tarif") As Boolean

        Dim insertQuery As String = "INSERT INTO " & TABLE & "(`CODE_TARIF`, `LIBELLE_TARIF`,`DESCRIPTION_TARIF`,  `TYPE_TARIF`, `CODE_TYPE`,`PRIX_TARIF1`, `PRIX_TARIF2`, `PRIX_TARIF3`, `PRIX_TARIF4`, `PRIX_TARIF5`) VALUES (@value2,@value3,@value11,@value4,@value10, @value5,@value6,@value7,@value8,@value9)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_TARIF
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_TARIF
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = DESCRIPTION_TARIF
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = TYPE_TARIF
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = PRIX_TARIF1
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = PRIX_TARIF2
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = PRIX_TARIF3
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PRIX_TARIF4
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = PRIX_TARIF5
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_TYPE

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

    Public Function updateCritere(ByVal CODE_TARIF As String, ByVal CODE_TARIF_DYNAMIQUE As String, ByVal CODE_TYPE As String) As Boolean

        Dim insertQuery As String = "UPDATE tarif_prix SET `CODE_TARIF_DYNAMIQUE`=@CODE_TARIF_DYNAMIQUE WHERE CODE_TARIF = @CODE_TARIF AND CODE_TYPE=@CODE_TYPE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_TARIF_DYNAMIQUE", MySqlDbType.VarChar).Value = CODE_TARIF_DYNAMIQUE
        command.Parameters.Add("@CODE_TYPE", MySqlDbType.VarChar).Value = CODE_TYPE
        command.Parameters.Add("@CODE_TARIF", MySqlDbType.VarChar).Value = CODE_TARIF

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function
    Public Function update(Optional ByVal CODE_TARIF As String = "", Optional ByVal LIBELLE_TARIF As String = "", Optional ByVal DESCRIPTION_TARIF As String = "", Optional ByVal TYPE_TARIF As String = "", ByVal Optional CODE_TYPE As String = "", Optional ByVal PRIX_TARIF1 As Double = 0, Optional ByVal PRIX_TARIF2 As Double = 0, Optional ByVal PRIX_TARIF3 As Double = 0, Optional ByVal PRIX_TARIF4 As Double = 0, Optional ByVal PRIX_TARIF5 As Double = 0, Optional ByVal TABLE As String = "tarif", Optional ByVal ID_TARIF As Integer = 999999) As Boolean

        Dim insertQuery As String = "UPDATE " & TABLE & " SET `LIBELLE_TARIF`=@value3,`DESCRIPTION_TARIF`=@value11,`TYPE_TARIF`=@value4,`CODE_TYPE`=@value10,`PRIX_TARIF1`=@value5,`PRIX_TARIF2`=@value6,`PRIX_TARIF3`=@value7,`PRIX_TARIF4`=@value8,`PRIX_TARIF5`=@value9 WHERE ID_TARIF=@ID_TARIF"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_TARIF
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = DESCRIPTION_TARIF
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = TYPE_TARIF
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = PRIX_TARIF1
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = PRIX_TARIF2
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = PRIX_TARIF3
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PRIX_TARIF4
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = PRIX_TARIF5
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_TYPE
        command.Parameters.Add("@ID_TARIF", MySqlDbType.Int32).Value = ID_TARIF
        command.Parameters.Add("@CODE_TARIF", MySqlDbType.VarChar).Value = CODE_TARIF

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

    'Create a function to check if the username already exists
    Public Function forfaitExists(ByVal CODE_TARIF As String, ByVal LIBELLE_TARIF As String) As Boolean

        Dim existQuery As String = "SELECT * From tarif WHERE CODE_TARIF=@CODE_TARIF OR LIBELLE_TARIF=@LIBELLE_TARIF"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TARIF", MySqlDbType.VarChar).Value = CODE_TARIF
        command.Parameters.Add("@LIBELLE_TARIF", MySqlDbType.VarChar).Value = LIBELLE_TARIF

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

    'SELCTION OF DISCTINCT TARIF

    Public Function SelectDistinctTarif() As DataTable

        Dim FillingListquery As String = "SELECT DISTINCT CODE_TARIF, LIBELLE_TARIF FROM tarif ORDER BY LIBELLE_TARIF ASC"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList_1 As MySqlDataAdapter
        adapterList_1 = New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList_1.Fill(tableList)

        Return tableList

    End Function

    Public Function SelectDistinctTarifPrix(ByVal CODE_TYPE_CHAMBRE As String) As DataTable

        Dim FillingListquery As String = "SELECT * FROM tarif_prix WHERE CODE_TYPE=@CODE_TYPE_CHAMBRE ORDER BY LIBELLE_TARIF ASC"
        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        commandList.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE

        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        Return tableList

    End Function

    'ATTRIBUTION DES PRIX AUX CLIENTS

    Public Function insertTarifClient(ByVal CODE_CLIENT As String, ByVal ID_TARIF_PRIX As Integer, ByVal MONTANT_EN_COURS As Double) As Boolean

        Dim insertQuery As String = "INSERT INTO `tarif_client`(`ID_TARIF_PRIX`, `CODE_CLIENT`, `PRIX_TARIF_ENCOURS`) VALUES (@value2 ,@value3, @value4)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value2", MySqlDbType.Int32).Value = ID_TARIF_PRIX
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_EN_COURS

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

    Public Function updateTarifClient(ByVal ID_TARIF_CLIENT As Integer, ByVal CODE_CLIENT As String, ByVal ID_TARIF_PRIX As Integer, ByVal MONTANT_EN_COURS As Double)
        Dim insertQuery As String = "UPDATE `tarif_client` SET `ID_TARIF_PRIX`=@value2,`CODE_CLIENT`=@value3,`PRIX_TARIF_ENCOURS`=@value4 WHERE ID_TARIF_CLIENT=@ID_TARIF_CLIENT AND CODE_CLIENT=@CODE_CLIENT"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value3", MySqlDbType.Int32).Value = ID_TARIF_PRIX
        command.Parameters.Add("@ID_TARIF_CLIENT", MySqlDbType.Int32).Value = ID_TARIF_CLIENT
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_EN_COURS

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

    'Create a function to check if the username already exists
    Public Function forfaitExistsTarifCLient(ByVal CODE_TARIF As String, ByVal LIBELLE_TARIF As String) As Boolean

        Dim existQuery As String = "SELECT * From tarif WHERE CODE_TARIF=@CODE_TARIF OR LIBELLE_TARIF=@LIBELLE_TARIF"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TARIF", MySqlDbType.VarChar).Value = CODE_TARIF
        command.Parameters.Add("@LIBELLE_TARIF", MySqlDbType.VarChar).Value = LIBELLE_TARIF

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

    Public Function SelectionDesForfaitsDuClient(ByVal CODE_CLIENT As String) As DataTable
        'Public Function SelectionDesForfaitsDuClient(ByVal ID_TARIF_CLIENT As Integer, ByVal CODE_CLIENT As String, ByVal ID_TARIF_PRIX As Integer, ByVal PRIX_TARIF_ENCOURS As Double) As DataTable

        Dim existQuery As String = "SELECT ID_TARIF AS 'ID_TARIF_PRIX',CODE_TARIF As 'CODE APPLIQUE',TYPE_TARIF AS 'TYPE TARIF',CODE_TYPE AS 'CODE TYPE', PRIX_TARIF_ENCOURS AS 'PRIX_TARIF_ENCOURS', PRIX_TARIF1 AS 'PRIX 1', PRIX_TARIF2 AS 'PRIX 2', PRIX_TARIF3 AS 'PRIX 3', PRIX_TARIF4 AS 'PRIX 4',PRIX_TARIF5 AS 'PRIX 5' From tarif_client INNER JOIN tarif_prix WHERE tarif_prix.ID_TARIF = tarif_client.ID_TARIF_PRIX AND CODE_CLIENT=@CODE_CLIENT"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        'command.Parameters.Add("@ID_TARIF_PRIX", MySqlDbType.Int64).Value = ID_TARIF_PRIX

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

        'connect.closeConnection()

    End Function

    ' ----------------------------------- GESTION DES DISPONIBILITES ET TARIFS -----------------------------------------------

    '1- INSERTION DES TARIFS SPECIFIQUE SUR UNE PERIODE

    Public Function insertTarifSpecificDisponibiliteEtTarif(ByVal CODE_TYPE_CHAMBRE As String, ByVal CODE_TARIF As String, ByVal DEBUT_PERIODE As Date, ByVal FIN_PERIODE As Date, ByVal MONTANT As Double, ByVal CODE_DISPO_TARIF_SPECIFIC As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal ETAT As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `disponibilite_tarif_specifique_periodique` (`CODE_TYPE_CHAMBRE`, `CODE_TARIF`, `DEBUT_PERIODE`, `FIN_PERIODE`, `MONTANT`, `CODE_DISPO_TARIF_SPECIFIC`, `CODE_UTILISATEUR_CREA`, `ETAT`) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_TARIF
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DEBUT_PERIODE
        command.Parameters.Add("@value4", MySqlDbType.Date).Value = FIN_PERIODE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = MONTANT
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_DISPO_TARIF_SPECIFIC
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value8", MySqlDbType.Int64).Value = ETAT

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

    '1- INSERTION DES TARIFS SPECIFIQUE SUR UNE PERIODE

    Public Function insertTarifDynamique(ByVal CRITERE As Integer, ByVal LIBELLE_TARIF_DYNAMIQUE As String, ByVal INTERVAL_1 As Double, ByVal INTERVAL_2 As Double, ByVal INTERVAL_3 As Double, ByVal INTERVAL_4 As Double, ByVal INTERVAL_5 As Double, ByVal INTERVAL_11 As Double, ByVal INTERVAL_22 As Double, ByVal INTERVAL_33 As Double, ByVal INTERVAL_44 As Double, ByVal INTERVAL_55 As Double, ByVal UTILISATEUR_CREA As String, ByVal CODE_TARIF_DYNAMIQUE As String, ByVal ETAT As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `tarification_dynamique`(`CRITERE`, `LIBELLE_TARIF_DYNAMIQUE`, `INTERVAL_1`, `INTERVAL_2`, `INTERVAL_3`, `INTERVAL_4`, `INTERVAL_5`, `UTILISATEUR_CREA`, `CODE_TARIF_DYNAMIQUE`, `INTERVAL_11`, `INTERVAL_22`, `INTERVAL_33`, `INTERVAL_44`, `INTERVAL_55`, `ETAT`) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11, @value12, @value13, @value14, @value15)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.Int64).Value = CRITERE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE_TARIF_DYNAMIQUE
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = INTERVAL_1
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = INTERVAL_2
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = INTERVAL_3
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = INTERVAL_4
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = INTERVAL_5
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = UTILISATEUR_CREA
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_TARIF_DYNAMIQUE
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = INTERVAL_11
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = INTERVAL_22
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = INTERVAL_33
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = INTERVAL_44
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = INTERVAL_55
        command.Parameters.Add("@value15", MySqlDbType.Int64).Value = ETAT

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

    Public Function selectionDeTarifDynamique(ByVal CODE_TARIF_DYNAMIQUE As String) As DataTable

        Dim existQuery As String = ""

        'SI LE CODE DE LA TARIFICATION DYNAMIQUE EST VIDE ALORS ON AFFICHE TOUTES LES TARIFICATIONS DYNAMIQUES
        'SINON ON AFFICHE UNE TARIFICATION SPECIFIQUE

        If Trim(CODE_TARIF_DYNAMIQUE).Equals("") Then
            existQuery = "SELECT * From tarification_dynamique ORDER BY LIBELLE_TARIF_DYNAMIQUE ASC"
        ElseIf True Then
            existQuery = "SELECT * From tarification_dynamique WHERE CODE_TARIF_DYNAMIQUE=@CODE_TARIF_DYNAMIQUE"
        End If

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_TARIF_DYNAMIQUE", MySqlDbType.VarChar).Value = CODE_TARIF_DYNAMIQUE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            ''connect.closeConnection()
            Return table

        End If

    End Function

    '---------------------------------------- GESTION DE LA TARIFCATION DYNAMIQUE (MANUELLE ET AUTOMATIQUE) AVEC FICHIER ------------------------------------------------- 

    '1- CREATION DE REPERTOIRE

    Public Sub creationDeRepertoire(ByVal pathPlusDirectory As String)
        If Not Directory.Exists(pathPlusDirectory) Then
            Directory.CreateDirectory(pathPlusDirectory)
        End If
    End Sub

    '2- DETERMINIATION DES PRIX ET INSCRIPTION DES PRIX D'UNE RESERVATION DANS UN FICHIER TEXT

    Public Shared Function determinationDesMontantPourTouteLaPeriodeDelaReservation(ByVal DateDebut As Date, ByVal CODE_RESERVATION As String, ByVal CODE_TARIF_RESERVATION As String, ByVal DateArrivee As Date, ByVal DateDepart As Date, ByVal CODE_TYPE_CHAMBRE As String)


        '0- ON SELECTIONNE LE TYPE DE CHAMBRE DE LA RESERVATION

        Dim existQuery As String = "SELECT * From type_chambre WHERE TYPE=@TYPE AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE ORDER BY CODE_TYPE_CHAMBRE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE

        Dim adapter As New MySqlDataAdapter(command)
        Dim typeChambre As New DataTable()
        adapter.Fill(typeChambre)

        Dim TauxTotal As Double = 0

        Dim totalDesChambreVendable As Integer = 0
        Dim totalDesReservationsNettes As Integer = 0
        Dim dateDuJour As Date
        Dim TOSpecific As Double = 0

        'REMPLISSAGE DE CHAQUE LIGNE AVEC DES DONNEES

        Dim extension As String = ".txt"
        Dim nomDuDossier As String = "RESERVATIONS"
        Dim cheminPlusDossier As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossier
        Dim filepathPlusFile As String = cheminPlusDossier & "\" & CODE_RESERVATION & extension

        If Directory.Exists(cheminPlusDossier) Then

            If System.IO.File.Exists(filepathPlusFile) Then
                File.Delete(filepathPlusFile)
            End If

            If Not System.IO.File.Exists(filepathPlusFile) Then
                System.IO.File.Create(filepathPlusFile).Dispose()
            End If

        Else
            System.IO.File.Create(filepathPlusFile).Dispose()
        End If

        Dim swriter As StreamWriter
        swriter = File.AppendText(filepathPlusFile)

        If typeChambre.Rows.Count > 0 Then

            'Dim nombreDeJour As Integer = DateDiff(DateInterval.Day, DateArrivee, DateDepart)
            Dim nombreDeJour As Integer = DateDiff(DateInterval.Day, DateDebut, DateDepart)

            'VARIABLE UTILISEE POUR DETERMINER LES LIGNES DE DONNEES A AFFICHER

            Dim j As Integer = 0

            Dim rowTypeChambre = 0
            Dim rowHebergementAVendre = 0
            Dim rowResaNet = 0
            Dim rowLibre = 0
            Dim rowTO = 0
            Dim rowDebutTarif = 0

            Dim actuelRow As Integer = 0

            For i = 0 To typeChambre.Rows.Count - 1

                totalDesChambreVendable = 0
                totalDesReservationsNettes = 0
                TOSpecific = 0

                '3- GESTION DES TARIFICATIONS
                '-----------------------------------------------------------------------------------------------------------------------------------------

                'ON PRENDS LES prix_tarif associé a la tarification_dynamique activé (ETAT = 1)
                'AINSI L'ACTIVATION OU DESACTIVATION D'UN TARIF DYNAMIQUE DETERMINE SON AFFICHAGE OU NON

                'Dim existQuerytarif As String = "SELECT * From tarif_prix, tarification_dynamique WHERE LIBELLE_TARIF NOT IN ('GRATUITEE') AND CODE_TYPE=@CODE_TYPE_CHAMBRE AND tarif_prix.CODE_TARIF_DYNAMIQUE = tarification_dynamique.CODE_TARIF_DYNAMIQUE AND tarification_dynamique.ETAT=@ETAT AND tarif_prix.CODE_TARIF_DYNAMIQUE=@CODE_TARIF_DYNAMIQUE ORDER BY LIBELLE_TARIF ASC"

                'ActivationForm.Show()
                'ActivationForm.TopMost = True
                'ActivationForm.GunaTextBoxMessage.Text = " CODE TYPE CHAMBRE : " & typeChambre.Rows(i)("CODE_TYPE_CHAMBRE") & " CODE TARIF : " & CODE_TARIF_RESERVATION & " CODE REGLE DYNAMIQUE : " & CODE_TARIF_DYNAMIQUE

                'ON S'APPUIE SUR :

                '1- LE CODE DU TARIF
                '2- LE TYPE DE CHAMBRE

                'Dim existQuerytarif As String = "SELECT * From tarif_prix, tarification_dynamique WHERE CODE_TYPE=@CODE_TYPE_CHAMBRE AND tarif_prix.CODE_TARIF_DYNAMIQUE = tarification_dynamique.CODE_TARIF_DYNAMIQUE AND tarification_dynamique.ETAT=@ETAT AND tarif_prix.CODE_TARIF = @CODE_TARIF AND tarif_prix.CODE_TARIF_DYNAMIQUE=@CODE_TARIF_DYNAMIQUE ORDER BY LIBELLE_TARIF ASC"

                Dim existQuerytarif As String = "SELECT * From tarif_prix, tarification_dynamique WHERE CODE_TYPE=@CODE_TYPE_CHAMBRE AND tarif_prix.CODE_TARIF_DYNAMIQUE = tarification_dynamique.CODE_TARIF_DYNAMIQUE AND tarification_dynamique.ETAT=@ETAT AND tarif_prix.CODE_TARIF = @CODE_TARIF ORDER BY LIBELLE_TARIF ASC"

                Dim commandtarif As New MySqlCommand(existQuerytarif, GlobalVariable.connect)
                Dim ETAT As Integer = 1

                commandtarif.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")
                commandtarif.Parameters.Add("@CODE_TARIF", MySqlDbType.VarChar).Value = CODE_TARIF_RESERVATION
                'commandtarif.Parameters.Add("@CODE_TARIF_DYNAMIQUE", MySqlDbType.VarChar).Value = CODE_TARIF_DYNAMIQUE
                commandtarif.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT

                Dim adaptertarif As New MySqlDataAdapter(commandtarif)
                Dim tarif As New DataTable()

                adaptertarif.Fill(tarif)

                '-----------------------------------------------------------------------------------------------------------------------------------------

                For k = 0 To nombreDeJour + 1

                    totalDesChambreVendable = 0
                    totalDesReservationsNettes = 0
                    TOSpecific = 0

                    '1- DETERMINONS LES CHAMBRES VENDABLES

                    Dim existQuery1 As String = "SELECT * From chambre WHERE CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND ETAT_CHAMBRE_NOTE NOT IN ('Hors Service') ORDER BY CODE_CHAMBRE ASC"

                    Dim command1 As New MySqlCommand(existQuery1, GlobalVariable.connect)

                    command1.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")
                    Dim adapter1 As New MySqlDataAdapter(command1)
                    Dim chambreVendable As New DataTable()

                    adapter1.Fill(chambreVendable)

                    If chambreVendable.Rows.Count > 0 Then
                        totalDesChambreVendable = chambreVendable.Rows.Count
                    End If

                    '2- DETERMINONS LES RESERVATIONS NETTES

                    '2.1- EN CHAMBRES

                    dateDuJour = DateDebut.AddDays(k).ToShortDateString

                    Dim query01 As String = "SELECT CHAMBRE_ID FROM reserve_conf WHERE DATE_ENTTRE <= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & dateDuJour.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE AND TYPE_CHAMBRE = @TYPE_CHAMBRE ORDER BY CHAMBRE_ID ASC"

                    Dim command01 As New MySqlCommand(query01, GlobalVariable.connect)
                    command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                    command01.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")

                    Dim adapter01 As New MySqlDataAdapter(command01)
                    Dim enChambre As New DataTable()
                    adapter01.Fill(enChambre)

                    If enChambre.Rows.Count > 0 Then
                        totalDesReservationsNettes = enChambre.Rows.Count
                    End If

                    '2.2- LES DEPARTS 

                    Dim query02 As String = "SELECT CHAMBRE_ID FROM reserve_conf WHERE DATE_SORTIE >= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & dateDuJour.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE AND TYPE_CHAMBRE=@TYPE_CHAMBRE ORDER BY CHAMBRE_ID ASC"

                    Dim command02 As New MySqlCommand(query02, GlobalVariable.connect)
                    command02.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                    command02.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")

                    Dim adapter02 As New MySqlDataAdapter(command02)
                    Dim depart As New DataTable()
                    adapter02.Fill(depart)

                    If (depart.Rows.Count > 0) Then
                        totalDesReservationsNettes -= depart.Rows.Count
                    End If

                    '2.3- ATTENDUES

                    Dim query03 As String = "SELECT CHAMBRE_ID FROM reservation WHERE DATE_SORTIE >= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & dateDuJour.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND ETAT_RESERVATION= 0 AND TYPE_CHAMBRE=@TYPE_CHAMBRE ORDER BY CHAMBRE_ID ASC"

                    Dim command03 As New MySqlCommand(query03, GlobalVariable.connect)
                    command03.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                    command03.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")

                    Dim adapter03 As New MySqlDataAdapter(command03)
                    Dim attendu As New DataTable()
                    adapter03.Fill(attendu)

                    If attendu.Rows.Count > 0 Then
                        totalDesReservationsNettes += attendu.Rows.Count
                    End If

                    '2.4- CALCUL DU TAUX D'OCCUPATION

                    If totalDesChambreVendable > 0 Then
                        TOSpecific = (totalDesReservationsNettes / totalDesChambreVendable) * 100
                    End If

                    'AJOUT DES TARIFICATIONS

                    Dim s = 0

                    Dim PRIX_A_AFFICHER As Double = 0

                    'SI ON FAIT LE TRAITEMENT DES TARIF DYNAMIQUE ACTIVE

                    If tarif.Rows.Count > 0 Then

                        For m = 0 To tarif.Rows.Count - 1

                            If Not Trim(tarif.Rows(m)("LIBELLE_TARIF")).Equals("GRATUITEE") Then

                                'ON AFFICHE UN TYPE DE PRIX A SAVOIR LA TARIFICATION DYNAMQUE AU DETRIMANT DU MONTANT AFFICHE OU TARIF PUBLIC

                                Dim TAUX_OCCUPATION As Double = TOSpecific
                                Dim CODE_TYPE As String = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")
                                Dim CODE_TARIF As String = tarif.Rows(m)("CODE_TARIF")

                                PRIX_A_AFFICHER = prixDelaTarificationAAfficherParApportAuCritereDeTarificationDynamique(TAUX_OCCUPATION, CODE_TARIF, CODE_TYPE)

                                'INSERTION DANS LE FICHIER TEXT

                                If DateArrivee.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DateDepart.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                    'swriter = File.AppendText(filepathPlusFile)
                                    swriter.WriteLine(DateDebut.AddDays(k).ToString("yyyy-MM-dd") & "#" & PRIX_A_AFFICHER)

                                End If

                            End If

                        Next

                    Else

                        'ON DETERMINE SI ON A UNE TARIFICATION SPECIFIQUE PERIODIQUE (EDITION DE MASSE) QUI DEVRA REMPLACER LE TARIF PUBLIC EN CETTE DATE LA 
                        'PAR APPORT A CE TYPE DE CHAMBRE ET LA DATE EN COURS DONC LA DATE QUE NOUS SOMMES ENTRAINE DE PARCOURIR
                        'ELLE DEVRA ETRE ACTIVE

                        Dim query04 As String = "SELECT * FROM `disponibilite_tarif_specifique_periodique` WHERE ETAT=@ETAT AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE"
                        Dim ETAT_EDITION_DE_MASSE As Integer = 1

                        Dim command04 As New MySqlCommand(query04, GlobalVariable.connect)
                        command04.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT_EDITION_DE_MASSE
                        command04.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")

                        Dim adapter04 As New MySqlDataAdapter(command04)
                        Dim tarifSpecifiquePeriodique As New DataTable()
                        adapter04.Fill(tarifSpecifiquePeriodique)

                        If tarifSpecifiquePeriodique.Rows.Count > 0 Then

                            For p = 0 To tarifSpecifiquePeriodique.Rows.Count - 1

                                'SI LA DATE ACTUEL SE TROUVE DANS L'INTERVALE PERIODIQUE LE MONTANT A AFFICHER DOIT ETRE CELUI DE L'INTERVALE
                                'disponibilite_tarif_specifique_periodique

                                Dim DEBUT_PERIODE As Date = CDate(tarifSpecifiquePeriodique.Rows(p)("DEBUT_PERIODE")).ToShortDateString
                                Dim FIN_PERIODE As Date = CDate(tarifSpecifiquePeriodique.Rows(p)("FIN_PERIODE")).ToShortDateString

                                If DEBUT_PERIODE.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And FIN_PERIODE.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                    'GESTION D'UNE TARIFICATION
                                    PRIX_A_AFFICHER = tarifSpecifiquePeriodique.Rows(p)("MONTANT")

                                    If DateArrivee.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DateDepart.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                        'swriter = File.AppendText(filepathPlusFile)
                                        swriter.WriteLine(DateDebut.AddDays(k).ToString("yyyy-MM-dd") & "#" & PRIX_A_AFFICHER)

                                    End If

                                Else

                                    PRIX_A_AFFICHER = typeChambre.Rows(i)("PRIX")

                                    If DateArrivee.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DateDepart.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                        'swriter = File.AppendText(filepathPlusFile)
                                        swriter.WriteLine(DateDebut.AddDays(k).ToString("yyyy-MM-dd") & "#" & PRIX_A_AFFICHER)

                                    End If

                                    Dim m As Integer = 0

                                End If

                            Next

                        Else

                            PRIX_A_AFFICHER = typeChambre.Rows(i)("PRIX")

                            If DateArrivee.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DateDepart.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                'swriter = File.AppendText(filepathPlusFile)
                                swriter.WriteLine(DateDebut.AddDays(k).ToString("yyyy-MM-dd") & "#" & PRIX_A_AFFICHER)

                            End If

                            Dim m As Integer = 0

                        End If

                    End If

                Next

            Next

            swriter.Flush()
            swriter.Close()

        End If

    End Function

    '3- RECUPERATION DES PRIX PAR APPORT A UN JOUR QUELCONQUE D'UNE RESERVATION POUR INSCRIPTION DANS UN FICHIER EN PARCOURANT CHAQUE DATE (DATE PAR DATE) 
    'LES TARIFS INSCRIT DANS LE FICHIER EN ACCORD AVEC LA REGLE DE TARIFICATION DYNAMIQUE
    'UTILISE DANS LA FONCTION DE DETERMINAYION DES PRIX D'UN SEJOURS

    Public Shared Function prixDelaTarificationAAfficherParApportAuCritereDeTarificationDynamique(ByVal TAUX_OCCUPATION As Double, ByVal CODE_TARIF As String, ByVal CODE_TYPE As String) As Double

        'ON RECUPERE LE CODE DE LA TARIFICATION DYNAMQIUE ASSOCIE AU TARIF PRIX

        Dim tarif As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_TARIF, "tarif_prix", "CODE_TARIF", CODE_TYPE, "CODE_TYPE")

        If tarif.Rows.Count > 0 Then

            Dim CODE_TARIF_DYNAMIQUE As String = tarif.Rows(0)("CODE_TARIF_DYNAMIQUE")

            Dim infoTarifDynamique As DataTable = Functions.getElementByCode(CODE_TARIF_DYNAMIQUE, "tarification_dynamique", "CODE_TARIF_DYNAMIQUE")

            If infoTarifDynamique.Rows.Count > 0 Then
                'ON DETERMINE QUEL PRIX DE 1 a 5 A AFFICHER PAR POUR LE CRITERE DU TAUX D'OCCUPATION EN E BASANT SUR LES INTERVALES
                If infoTarifDynamique.Rows(0)("CRITERE") = 0 Then
                    'SELON LE TAUX D'OCCUPATION

                    If 0 <= TAUX_OCCUPATION And TAUX_OCCUPATION <= infoTarifDynamique.Rows(0)("INTERVAL_1") Then
                        Return tarif.Rows(0)("PRIX_TARIF1")
                    ElseIf infoTarifDynamique.Rows(0)("INTERVAL_1") < TAUX_OCCUPATION And TAUX_OCCUPATION <= infoTarifDynamique.Rows(0)("INTERVAL_2") Then
                        Return tarif.Rows(0)("PRIX_TARIF2")
                    ElseIf infoTarifDynamique.Rows(0)("INTERVAL_2") < TAUX_OCCUPATION And TAUX_OCCUPATION <= infoTarifDynamique.Rows(0)("INTERVAL_3") Then
                        Return tarif.Rows(0)("PRIX_TARIF3")
                    ElseIf infoTarifDynamique.Rows(0)("INTERVAL_3") < TAUX_OCCUPATION And TAUX_OCCUPATION <= infoTarifDynamique.Rows(0)("INTERVAL_4") Then
                        Return tarif.Rows(0)("PRIX_TARIF4")
                    ElseIf infoTarifDynamique.Rows(0)("INTERVAL_4") < TAUX_OCCUPATION And TAUX_OCCUPATION <= infoTarifDynamique.Rows(0)("INTERVAL_5") Then
                        Return tarif.Rows(0)("PRIX_TARIF5")
                    Else
                        Return tarif.Rows(0)("PRIX_TARIF5")
                    End If

                ElseIf infoTarifDynamique.Rows(0)("CRITERE") = 1 Then
                    'SELON LE NOMBRE DE NUITEE
                End If

            Else

                Return 0

            End If

        End If

    End Function

    '4- LECTURE DU FICHIER POUR DETERMINER LE MONTANT A UTILISER UN JOUR PRECIS

    Public Function montantAUtiliserUnJourPrecis(ByVal DATE_DU_JOUR As Date, ByVal CODE_RESERVATION As String) As Double

        Dim extension As String = ".txt"

        Dim repertoire As String = "RESERVATIONS"
        Dim cheminDuFichierText As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & repertoire

        Dim filepathPlusFile As String = cheminDuFichierText & "\" & CODE_RESERVATION & extension

        Dim montantAUtiliser As Double = 0

        If Not Trim(filepathPlusFile).Equals("") Then

            Dim lineArr() As String

            Dim donne As Boolean = False

            For Each ligne As String In File.ReadLines(filepathPlusFile)

                'NOUS AVONS LA LIGNE CONTENANT DATE : MONTANT
                lineArr = ligne.Split("#")

                If Not lineArr Is Nothing Then

                    'ON SEPARE NOTRE LIGNE EN UN TABLEAU DE DEUX COLONNES (LA DATE D'UNE PART ET LE MONTANT D'AUTRE PART)

                    For count = 0 To lineArr.Length - 1

                        'ON COMPARE NOTRE COLONNE DE DATE PAR APPORT A LA DATE DU JOUR

                        If CDate(lineArr(0)).ToShortDateString = CDate(DATE_DU_JOUR).ToShortDateString Then

                            'MONTANT A UTILISER X JOUR
                            Return Double.Parse(lineArr(1))

                            donne = True

                            Exit For

                        End If

                    Next

                End If

                If donne Then
                    Exit For
                End If

            Next

            donne = False

        End If

    End Function

    Public Function chargementDuFichierTextDansUnTableau(ByVal CODE_RESERVATION As String, ByVal cheminDuFichierText As String) As DataTable

        Dim extension As String = ".txt"

        Dim filepathPlusFile As String = cheminDuFichierText & "\" & CODE_RESERVATION & extension

        Dim montantAUtiliser As Double = 0

        If Not Trim(filepathPlusFile).Equals("") Then

            'ON SE RASSURE DE L'EXISTENCE DU FICHIER AVAN TOUTE MANIPULATION

            If System.IO.File.Exists(filepathPlusFile) Then
                Dim lineArr() As String
                Dim dt As New DataTable()

                dt.Columns.Add("DATE")
                dt.Columns.Add("MONTANT")

                'ON DOIT TESTER LEXISTENCE DU FICHIER TEXT AVANT TOUTE ACTION

                For Each ligne As String In File.ReadLines(filepathPlusFile)

                    'NOUS AVONS LA LIGNE CONTENANT DATE : MONTANT
                    lineArr = ligne.Split("#")

                    If Not lineArr Is Nothing Then

                        'ON SEPARE NOTRE LIGNE EN UN TABLEAU DE DEUX COLONNES (LA DATE D'UNE PART ET LE MONTANT D'AUTRE PART)
                        dt.Rows.Add(lineArr(0), lineArr(1))

                    End If

                Next

                Return dt

            End If

        End If

    End Function

    Public Sub chargementDuTableauDansUnFichierText(ByVal CODE_RESERVATION As String, ByVal cheminDuFichierText As String, ByVal dt As DataGridView)

        Dim extension As String = ".txt"

        Dim filepathPlusFile As String = cheminDuFichierText & "\" & CODE_RESERVATION & extension

        If Directory.Exists(cheminDuFichierText) Then

            If System.IO.File.Exists(filepathPlusFile) Then
                File.Delete(filepathPlusFile)
            End If

            If Not System.IO.File.Exists(filepathPlusFile) Then
                System.IO.File.Create(filepathPlusFile).Dispose()
            End If

        End If

        Dim swriter As StreamWriter
        swriter = File.AppendText(filepathPlusFile)

        If dt.Rows.Count > 0 Then

            For i = 0 To dt.Rows.Count - 1
                swriter.WriteLine(dt.Rows(i).Cells(0).Value.ToString & "#" & dt.Rows(i).Cells(1).Value.ToString)
            Next

        End If

        swriter.Flush()
        swriter.Close()

    End Sub

    'ON DOIT DETERMINER LE MONTANT DE DEPART LORSQUE LE CODE DE LA RESERVATION N'EXISTE PAS ENCORE

    Public Shared Function determinationDuMontantDeDepartPourlaReservation(ByVal DateDebut As Date, ByVal CODE_TARIF_RESERVATION As String, ByVal DateArrivee As Date, ByVal DateDepart As Date, ByVal CODE_TYPE_CHAMBRE As String) As Double

        '0- ON SELECTIONNE LE TYPE DE CHAMBRE DE LA RESERVATION

        Dim existQuery As String = "SELECT * From type_chambre WHERE TYPE=@TYPE AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE ORDER BY CODE_TYPE_CHAMBRE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
        command.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_TYPE_CHAMBRE

        Dim adapter As New MySqlDataAdapter(command)
        Dim typeChambre As New DataTable()
        adapter.Fill(typeChambre)

        Dim TauxTotal As Double = 0

        Dim totalDesChambreVendable As Integer = 0
        Dim totalDesReservationsNettes As Integer = 0
        Dim dateDuJour As Date
        Dim TOSpecific As Double = 0

        'REMPLISSAGE DE CHAQUE LIGNE AVEC DES DONNEES

        If typeChambre.Rows.Count > 0 Then

            Dim nombreDeJour As Integer = DateDiff(DateInterval.Day, DateDebut, DateDepart)

            'VARIABLE UTILISEE POUR DETERMINER LES LIGNES DE DONNEES A AFFICHER

            Dim j As Integer = 0

            Dim rowTypeChambre = 0
            Dim rowHebergementAVendre = 0
            Dim rowResaNet = 0
            Dim rowLibre = 0
            Dim rowTO = 0
            Dim rowDebutTarif = 0

            Dim actuelRow As Integer = 0

            For i = 0 To typeChambre.Rows.Count - 1

                totalDesChambreVendable = 0
                totalDesReservationsNettes = 0
                TOSpecific = 0

                '3- GESTION DES TARIFICATIONS
                '-----------------------------------------------------------------------------------------------------------------------------------------

                'ON PRENDS LES prix_tarif associé a la tarification_dynamique activé (ETAT = 1)
                'AINSI L'ACTIVATION OU DESACTIVATION D'UN TARIF DYNAMIQUE DETERMINE SON AFFICHAGE OU NON

                'Dim existQuerytarif As String = "SELECT * From tarif_prix, tarification_dynamique WHERE tarif_prix.CODE_TYPE=@CODE_TYPE_CHAMBRE AND tarif_prix.CODE_TARIF_DYNAMIQUE = tarification_dynamique.CODE_TARIF_DYNAMIQUE AND tarification_dynamique.ETAT=@ETAT AND tarif_prix.CODE_TARIF=@CODE_TARIF AND tarif_prix.CODE_TARIF_DYNAMIQUE = @CODE_REGLE_DYNAMIQUE ORDER BY LIBELLE_TARIF ASC"

                Dim existQuerytarif As String = "SELECT * From tarif_prix, tarification_dynamique WHERE tarif_prix.CODE_TYPE=@CODE_TYPE_CHAMBRE AND tarif_prix.CODE_TARIF_DYNAMIQUE = tarification_dynamique.CODE_TARIF_DYNAMIQUE AND tarification_dynamique.ETAT=@ETAT AND tarif_prix.CODE_TARIF=@CODE_TARIF ORDER BY LIBELLE_TARIF ASC"

                Dim commandtarif As New MySqlCommand(existQuerytarif, GlobalVariable.connect)
                Dim ETAT As Integer = 1

                commandtarif.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")
                commandtarif.Parameters.Add("@CODE_TARIF", MySqlDbType.VarChar).Value = CODE_TARIF_RESERVATION
                'commandtarif.Parameters.Add("@CODE_REGLE_DYNAMIQUE", MySqlDbType.VarChar).Value = CODE_REGLE_DYNAMIQUE
                commandtarif.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT

                Dim adaptertarif As New MySqlDataAdapter(commandtarif)
                Dim tarif As New DataTable()

                adaptertarif.Fill(tarif)

                '-----------------------------------------------------------------------------------------------------------------------------------------

                For k = 0 To nombreDeJour + 2

                    totalDesChambreVendable = 0
                    totalDesReservationsNettes = 0
                    TOSpecific = 0

                    '1- DETERMINONS LES CHAMBRES VENDABLES

                    Dim existQuery1 As String = "SELECT * From chambre WHERE CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE AND ETAT_CHAMBRE_NOTE NOT IN ('Hors Service') ORDER BY CODE_CHAMBRE ASC"

                    Dim command1 As New MySqlCommand(existQuery1, GlobalVariable.connect)

                    command1.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")
                    Dim adapter1 As New MySqlDataAdapter(command1)
                    Dim chambreVendable As New DataTable()

                    adapter1.Fill(chambreVendable)

                    If chambreVendable.Rows.Count > 0 Then
                        totalDesChambreVendable = chambreVendable.Rows.Count
                    End If

                    '2- DETERMINONS LES RESERVATIONS NETTES

                    '2.1- EN CHAMBRES

                    dateDuJour = DateDebut.AddDays(k).ToShortDateString

                    Dim query01 As String = "SELECT CHAMBRE_ID FROM reserve_conf WHERE DATE_ENTTRE <= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & dateDuJour.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE AND TYPE_CHAMBRE = @TYPE_CHAMBRE ORDER BY CHAMBRE_ID ASC"

                    Dim command01 As New MySqlCommand(query01, GlobalVariable.connect)
                    command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                    command01.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")

                    Dim adapter01 As New MySqlDataAdapter(command01)
                    Dim enChambre As New DataTable()
                    adapter01.Fill(enChambre)

                    If enChambre.Rows.Count > 0 Then
                        totalDesReservationsNettes = enChambre.Rows.Count
                    End If

                    '2.2- LES DEPARTS 

                    Dim query02 As String = "SELECT CHAMBRE_ID FROM reserve_conf WHERE DATE_SORTIE >= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & dateDuJour.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE AND TYPE_CHAMBRE=@TYPE_CHAMBRE ORDER BY CHAMBRE_ID ASC"

                    Dim command02 As New MySqlCommand(query02, GlobalVariable.connect)
                    command02.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                    command02.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")

                    Dim adapter02 As New MySqlDataAdapter(command02)
                    Dim depart As New DataTable()
                    adapter02.Fill(depart)

                    If (depart.Rows.Count > 0) Then
                        totalDesReservationsNettes -= depart.Rows.Count
                    End If

                    '2.3- ATTENDUES

                    Dim query03 As String = "SELECT CHAMBRE_ID FROM reservation WHERE DATE_SORTIE >= '" & dateDuJour.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & dateDuJour.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND ETAT_RESERVATION= 0 AND TYPE_CHAMBRE=@TYPE_CHAMBRE ORDER BY CHAMBRE_ID ASC"

                    Dim command03 As New MySqlCommand(query03, GlobalVariable.connect)
                    command03.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = "chambre"
                    command03.Parameters.Add("@TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")

                    Dim adapter03 As New MySqlDataAdapter(command03)
                    Dim attendu As New DataTable()
                    adapter03.Fill(attendu)

                    If attendu.Rows.Count > 0 Then
                        totalDesReservationsNettes += attendu.Rows.Count
                    End If

                    '2.4- CALCUL DU TAUX D'OCCUPATION

                    If totalDesChambreVendable > 0 Then
                        TOSpecific = (totalDesReservationsNettes / totalDesChambreVendable) * 100
                    End If

                    'AJOUT DES TARIFICATIONS

                    Dim s = 0

                    Dim PRIX_A_AFFICHER As Double = 0

                    'SI ON FAIT LE TRAITEMENT DES TARIF DYNAMIQUE ACTIVE

                    If tarif.Rows.Count > 0 Then

                        For m = 0 To tarif.Rows.Count - 1

                            If Not Trim(tarif.Rows(m)("LIBELLE_TARIF")).Equals("GRATUITEE") Then

                                'ON AFFICHE UN TYPE DE PRIX A SAVOIR LA TARIFICATION DYNAMQUE AU DETRIMANT DU MONTANT AFFICHE OU TARIF PUBLIC

                                Dim TAUX_OCCUPATION As Double = TOSpecific
                                Dim CODE_TYPE As String = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")
                                Dim CODE_TARIF As String = tarif.Rows(m)("CODE_TARIF")

                                PRIX_A_AFFICHER = prixDelaTarificationAAfficherParApportAuCritereDeTarificationDynamique(TAUX_OCCUPATION, CODE_TARIF, CODE_TYPE)

                                'INSERTION DANS LE FICHIER TEXT

                                If DateArrivee.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DateDepart.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                    If DateArrivee.ToString("yyyy-MM-dd") = dateDuJour.ToString("yyyy-MM-dd") Then
                                        Return PRIX_A_AFFICHER
                                    End If

                                End If

                            End If

                        Next

                    Else

                        'ActivationForm.Show()
                        'ActivationForm.TopMost = True

                        'ON DETERMINE SI ON A UNE TARIFICATION SPECIFIQUE PERIODIQUE (EDITION DE MASSE) QUI DEVRA REMPLACER LE TARIF PUBLIC EN CETTE DATE LA 
                        'PAR APPORT A CE TYPE DE CHAMBRE ET LA DATE EN COURS DONC LA DATE QUE NOUS SOMMES ENTRAINE DE PARCOURIR
                        'ELLE DEVRA ETRE ACTIVE

                        Dim query04 As String = "SELECT * FROM `disponibilite_tarif_specifique_periodique` WHERE ETAT=@ETAT AND CODE_TYPE_CHAMBRE=@CODE_TYPE_CHAMBRE"
                        Dim ETAT_EDITION_DE_MASSE As Integer = 1

                        Dim command04 As New MySqlCommand(query04, GlobalVariable.connect)
                        command04.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT_EDITION_DE_MASSE
                        command04.Parameters.Add("@CODE_TYPE_CHAMBRE", MySqlDbType.VarChar).Value = typeChambre.Rows(i)("CODE_TYPE_CHAMBRE")

                        Dim adapter04 As New MySqlDataAdapter(command04)
                        Dim tarifSpecifiquePeriodique As New DataTable()
                        adapter04.Fill(tarifSpecifiquePeriodique)

                        If tarifSpecifiquePeriodique.Rows.Count > 0 Then

                            For p = 0 To tarifSpecifiquePeriodique.Rows.Count - 1

                                'SI LA DATE ACTUEL SE TROUVE DANS L'INTERVALE PERIODIQUE LE MONTANT A AFFICHER DOIT ETRE CELUI DE L'INTERVALE
                                'disponibilite_tarif_specifique_periodique

                                Dim DEBUT_PERIODE As Date = CDate(tarifSpecifiquePeriodique.Rows(p)("DEBUT_PERIODE")).ToShortDateString
                                Dim FIN_PERIODE As Date = CDate(tarifSpecifiquePeriodique.Rows(p)("FIN_PERIODE")).ToShortDateString

                                'ActivationForm.GunaTextBoxMessage.Text = "Edition de Masse => DEBUT PERIODE : " & DEBUT_PERIODE & " JOUR " & dateDuJour.ToString("yyyy-MM-dd") & " FIN PERIODE : " & FIN_PERIODE

                                If DEBUT_PERIODE.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And FIN_PERIODE.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                    'GESTION D'UNE TARIFICATION
                                    PRIX_A_AFFICHER = tarifSpecifiquePeriodique.Rows(p)("MONTANT")

                                    If DateArrivee.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DateDepart.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                        If DateArrivee.ToString("yyyy-MM-dd") = dateDuJour.ToString("yyyy-MM-dd") Then
                                            Return PRIX_A_AFFICHER
                                        End If

                                    End If

                                Else

                                    'ActivationForm.GunaTextBoxMessage.Text = "Edition de Masse Normal => ARRIVEE : " & DateArrivee.ToString("yyyy-MM-dd") & " JOUR : " & dateDuJour.ToString("yyyy-MM-dd") & " DEPART : " & FIN_PERIODE

                                    PRIX_A_AFFICHER = typeChambre.Rows(i)("PRIX")

                                    If DateArrivee.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DateDepart.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                        If DateArrivee.ToString("yyyy-MM-dd") = dateDuJour.ToString("yyyy-MM-dd") Then
                                            Return PRIX_A_AFFICHER
                                        End If

                                    End If

                                End If

                            Next

                        Else

                            'ActivationForm.GunaTextBoxMessage.Text = "Normal"

                            PRIX_A_AFFICHER = typeChambre.Rows(i)("PRIX")

                            If DateArrivee.ToString("yyyy-MM-dd") <= dateDuJour.ToString("yyyy-MM-dd") And DateDepart.ToString("yyyy-MM-dd") >= dateDuJour.ToString("yyyy-MM-dd") Then

                                If DateArrivee.ToString("yyyy-MM-dd") = dateDuJour.ToString("yyyy-MM-dd") Then
                                    Return PRIX_A_AFFICHER
                                End If

                            End If

                        End If

                    End If

                Next

            Next

        End If

    End Function

End Class
