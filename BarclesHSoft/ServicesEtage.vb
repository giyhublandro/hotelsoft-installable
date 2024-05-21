Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ServicesEtage

    Public Function insertPlanningHorairePersonnel(ByVal CODE_PLANNING_HORAIRE_PERSONNEL As String, ByVal CODE_PERSONNEL As String, ByVal CODE_TYPE_PERSONNEL As String, ByVal CODE_PLANNING As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `planning_horaire_personnel` (`CODE_PLANNING_HORAIRE_PERSONNEL`, `CODE_PERSONNEL`, `CODE_TYPE_PERSONNEL`, `CODE_PLANNING`) 
            VALUES (@CODE_PLANNING_HORAIRE_PERSONNEL, @CODE_PERSONNEL, @CODE_TYPE_PERSONNEL, @CODE_PLANNING)"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PLANNING_HORAIRE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_PLANNING_HORAIRE_PERSONNEL
        command.Parameters.Add("@CODE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_PERSONNEL
        command.Parameters.Add("@CODE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
        command.Parameters.Add("@CODE_PLANNING", MySqlDbType.VarChar).Value = CODE_PLANNING

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function insert(ByVal INTITULE_PLANNING As String, ByVal CODE_PLANNING As String, ByVal DATE_DEBUT As Date, ByVal DATE_FIN As Date, ByVal CODE_TYPE_PERSONNEL As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `planning_hebdomadaire`(`INTITULE_PLANNING`,`CODE_PLANNING`,`DATE_DEBUT`, `DATE_FIN`, `CODE_TYPE_PERSONNEL`, `CODE_AGENCE`) VALUES (@INTITULE_PLANNING, @CODE_PLANNING, @value1,@value2,@value3,@value4)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PLANNING", MySqlDbType.VarChar).Value = CODE_PLANNING
        command.Parameters.Add("@value1", MySqlDbType.Date).Value = DATE_DEBUT
        command.Parameters.Add("@value2", MySqlDbType.Date).Value = DATE_FIN
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_TYPE_PERSONNEL
        command.Parameters.Add("@INTITULE_PLANNING", MySqlDbType.VarChar).Value = INTITULE_PLANNING
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function insertHoraire(ByVal CODE_PLANNING As String, ByVal HEURE_DEBUT As String, ByVal HEURE_FIN As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `planning_hebdomadaire_horaire` (`CODE_PLANNING`, `HEURE_DEBUT`, `HEURE_FIN`, `HEURE_DEBUT_FIN`) VALUES (@CODE_PLANNING, @value1, @value2, @HEURE_DEBUT_FIN)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PLANNING", MySqlDbType.VarChar).Value = CODE_PLANNING
        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = HEURE_DEBUT
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = HEURE_FIN
        command.Parameters.Add("@HEURE_DEBUT_FIN", MySqlDbType.VarChar).Value = HEURE_DEBUT & " - " & HEURE_FIN

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function insertHorairePlanning(ByVal CODE_PLANNING As String, ByVal ID_HORAIRE As Integer, ByVal DATE_DEBUT As Date, ByVal DATE_FIn As Date) As Boolean

        Dim insertQuery As String = "INSERT INTO `planning_horaire` (`CODE_PLANNING`, `ID_HORAIRE`, `DATE_DEBUT` , `DATE_FIN`) VALUES (@CODE_PLANNING, @ID_HORAIRE, @DATE_DEBUT, @DATE_FIN)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PLANNING", MySqlDbType.VarChar).Value = CODE_PLANNING
        command.Parameters.Add("@ID_HORAIRE", MySqlDbType.Int32).Value = ID_HORAIRE
        command.Parameters.Add("@DATE_DEBUT", MySqlDbType.Date).Value = DATE_DEBUT
        command.Parameters.Add("@DATE_FIN", MySqlDbType.Date).Value = DATE_FIn

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    'create a function to update the selected user
    Public Function update(ByVal CODE_CATEGORIE_HOTEL As String, ByVal LIBELLE As String, ByVal MONTANT_TAXE As Double) As Boolean

        Dim insertQuery As String = "UPDATE `category_hotel_taxe_sejour_collectee` SET `CODE_CATEGORIE_HOTEL`=@value2,`LIBELLE`=@value3,`MONTANT_TAXE`=@value4  WHERE CODE_CATEGORIE_HOTEL=@CODE_CATEGORIE_HOTEL"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_CATEGORIE_HOTEL
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_TAXE
        command.Parameters.Add("@CODE_CATEGORIE_HOTEL", MySqlDbType.VarChar).Value = CODE_CATEGORIE_HOTEL

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

    Public Function insertMotif(ByVal CODE_MOTIF As String, ByVal CODE_CHAMBRE As String, ByVal MOTIF As String, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `motif_hors_service`(`CODE_MOTIF`, `CODE_CHAMBRE`, `MOTIF`, `CODE_AGENCE`) VALUES (@value2,@value3,@value4,@value5)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_MOTIF
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = MOTIF
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

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

    Public Function updateMotif(ByVal CODE_MOTIF As String, ByVal CODE_CHAMBRE As String, ByVal MOTIF As String, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "UPDATE `motif_hors_service` SET `CODE_CHAMBRE`=@value3,`MOTIF`=@value4 WHERE CODE_AGENCE=@CODE_AGENCE AND CODE_MOTIF=@CODE_MOTIF"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MOTIF", MySqlDbType.VarChar).Value = CODE_MOTIF

        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = MOTIF
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

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

    Public Shared Function DernierHorsService(ByVal CODE_CHAMBRE As String) As DataTable

        'GlobalVariable.'connect.openConnection()
        'GlobalVariable.'connect.openConnection()

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT * FROM motif_hors_service WHERE CODE_CHAMBRE = @CODE_CHAMBRE ORDER BY ID_MOTIF DESC"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        adapter.SelectCommand = Command
        adapter.Fill(table)

        'GlobalVariable.'connect.closeConnection()

        Return table

    End Function

    'HISTORIQUE DES CHAMBRES
    Public Shared Function HistoriqueDesChambres(ByVal roomType As String) As DataTable

        'GlobalVariable.'connect.openConnection()

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable

        Dim getUserQuery = "SELECT CODE_CHAMBRE As 'CODE CHAMBRE', CODE_RESERVATION As 'NUMERO RESERVATION', NOM_PRENOM As 'NOM CLIENT',DATE_PREMIERE_ARRIVEE AS 'DATE ARRIVEE',DATE_LIBERATION AS 'DATE DEPART', OBSERVATIONS FROM occupation_chambre INNER JOIN client WHERE client.CODE_CLIENT = occupation_chambre.CODE_CLIENT_REEL AND occupation_chambre.CODE_AGENCE=@CODE_AGENCE AND TYPE=@TYPE ORDER BY DATE_PREMIERE_ARRIVEE DESC"

        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        Command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        Command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = roomType
        adapter.SelectCommand = Command

        adapter.Fill(table)

        Return table

    End Function

    Public Function insertObjet(ByVal CODE_OBJET As String, ByVal TITRE As String, ByVal LIEU As String, ByVal DATE_ANNONCE As Date, ByVal CATEGORIE As String, ByVal SOUS_CATEGORIE As String, ByVal FABRICANT As String, ByVal MODEL As String, ByVal NUMERO_DE_SERIE As String, ByVal DESCRIPTION As String, ByVal COULEUR As String, ByVal NATURE As String, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `objet__perdu_trouve`(`CODE_OBJET`, `TITRE`, `LIEU`, `DATE_ANNONCE`, `CATEGORIE`, `SOUS_CATEGORIE`, `FABRICANT`, `MODEL`, `NUMERO_DE_SERIE`, `DESCRIPTION`, `COULEUR`, `NATURE`, `CODE_AGENCE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_OBJET
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = TITRE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = LIEU
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_ANNONCE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CATEGORIE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = SOUS_CATEGORIE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = FABRICANT
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = MODEL
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = NUMERO_DE_SERIE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = COULEUR
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = NATURE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

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

    Public Function updateObjet(ByVal CODE_OBJET As String, ByVal TITRE As String, ByVal LIEU As String, ByVal DATE_ANNONCE As Date, ByVal CATEGORIE As String, ByVal SOUS_CATEGORIE As String, ByVal FABRICANT As String, ByVal MODEL As String, ByVal NUMERO_DE_SERIE As String, ByVal DESCRIPTION As String, ByVal COULEUR As String, ByVal NATURE As String, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "UPDATE `objet__perdu_trouve` SET `CODE_OBJET`=@value2,`TITRE`=@value3,`LIEU`=@value4,`DATE_ANNONCE`=@value5,`CATEGORIE`=@value6,`SOUS_CATEGORIE`=@value7,`FABRICANT`=@value8,`MODEL`=@value9,`NUMERO_DE_SERIE`=@value10,`DESCRIPTION`=@value11,`COULEUR`=@value12,`NATURE`=@value13,`CODE_AGENCE`=@value14 WHERE CODE_OBJET=@CODE_OBJET"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_OBJET", MySqlDbType.VarChar).Value = CODE_OBJET

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_OBJET
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = TITRE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = LIEU
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_ANNONCE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CATEGORIE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = SOUS_CATEGORIE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = FABRICANT
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = MODEL
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = NUMERO_DE_SERIE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = COULEUR
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = NATURE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

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

    Public Shared Function listeDesObjets(ByVal code As String, ByVal tableName As String, ByVal fieldName As String) As DataTable

        'GlobalVariable.'connect.openConnection()

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT TITRE aS 'TITRE ANNONCE', LIEU 'LIEU DE PERTE/RETROUBVAIL',DATE_ANNONCE AS 'DATE ANNONCE', CATEGORIE, SOUS_CATEGORIE AS 'SOUS_CATEGORIE', DESCRIPTION,FABRICANT, MODEL, COULEUR, NUMERO_DE_SERIE AS 'NUMERO DE SERIE',CODE_OBJET As 'CODE OBJET' FROM " & tableName & " WHERE " & fieldName & " = @CODE"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@CODE", MySqlDbType.VarChar).Value = code
        adapter.SelectCommand = Command
        adapter.Fill(table)

        'GlobalVariable.'connect.closeConnection()

        Return table

    End Function

    'GESTION DES NETTOYAGES
    Public Function insertNettoyage(ByVal CODE_CHAMBRE As String, ByVal COMMENTAIRE As String, ByVal ETAT_CHAMBRE_NOTE As String, ByVal COD_PERSONNEL As String, ByVal NOM_COMPLET_PERSONNEL As String, ByVal date_de_nettoyage As Date) As Boolean

        Dim insertQuery As String = "INSERT INTO `nettoyage`(`CODE_NETTOYAGE`, `CODE_CHAMBRE`, `COMMENTAIRE`, `ETAT_CHAMBRE_NOTE`, `COD_PERSONNEL`, `NOM_COMPLET_PERSONNEL`,`DATE_CREATION`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = Functions.GeneratingRandomCode("nettoyage", "")
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = COMMENTAIRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = ETAT_CHAMBRE_NOTE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = COD_PERSONNEL
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NOM_COMPLET_PERSONNEL
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = date_de_nettoyage

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

    'GESTION DES NETTOYAGES PLANNING DE NETTOYAGE
    Public Function updateNettoyage(ByVal CODE_NETTOYAGE As String, ByVal CODE_CHAMBRE As String, ByVal COMMENTAIRE As String, ByVal ETAT_CHAMBRE_NOTE As String, ByVal COD_PERSONNEL As String, ByVal NOM_COMPLET_PERSONNEL As String, ByVal DATE_CREATION As Date) As Boolean

        Dim insertQuery As String = "UPDATE `nettoyage` SET `CODE_CHAMBRE`=@value3,`COMMENTAIRE`=@value4,`ETAT_CHAMBRE_NOTE`=@value5,`COD_PERSONNEL`=@value6,`NOM_COMPLET_PERSONNEL`=@value7 WHERE CODE_NETTOYAGE=@CODE_NETTOYAGE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_NETTOYAGE", MySqlDbType.VarChar).Value = CODE_NETTOYAGE

        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = COMMENTAIRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = ETAT_CHAMBRE_NOTE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = COD_PERSONNEL
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NOM_COMPLET_PERSONNEL

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

    'ENREGISTREMENT DES HEURES DE DEBUT ET FIN DE NETTOYAGE
    Public Function updateNettoyageTime(ByVal CODE_CHAMBRE As String, ByVal CHAMP As String, ByVal STATUTS As Integer) As Boolean

        Dim insertQuery As String = "UPDATE `nettoyage` SET " & CHAMP & "=@value1, STATUTS = @Value2 WHERE CODE_CHAMBRE=@CODE_CHAMBRE AND STATUTS = @value3"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.DateTime).Value = Now()
        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE

        command.Parameters.Add("@value2", MySqlDbType.Int64).Value = STATUTS

        'Une chambre dont le nettoyage est en cours on ne peut modifier les heures
        If CHAMP = "HEURE_DEBUT" Then
            command.Parameters.Add("@value3", MySqlDbType.Int64).Value = 0
        ElseIf CHAMP = "HEURE_FIN" Then
            command.Parameters.Add("@value3", MySqlDbType.Int64).Value = 1
        ElseIf CHAMP = "HEURE_CONTROL" Then
            command.Parameters.Add("@value3", MySqlDbType.Int64).Value = 2
        End If

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

    'MIse à jour la chambre apres nettoyage
    Public Function updateRoomApresNettoyage(ByVal CODE_CHAMBRE As String, ByVal ETAT_CHAMBRE_NOTE As String) As Boolean

        Dim insertQuery As String = "UPDATE `chambre` SET ETAT_CHAMBRE_NOTE = @ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE=@CODE_CHAMBRE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = ETAT_CHAMBRE_NOTE

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
    'function to insert each nettoyage datagrid into database

    Public Sub calendrierDeNettoyage(ByVal grid As DataGridView, ByVal Nom_comple As String, ByVal CodePersonnel As String)

        If grid.Rows.Count > 0 Then

            Dim date_de_nettoyage As Date = GlobalVariable.DateDeTravail
            For i = 0 To grid.Rows.Count - 1
                insertNettoyage(grid.Rows(i).Cells(0).Value, grid.Rows(i).Cells(1).Value, grid.Rows(i).Cells(2).Value, CodePersonnel, Nom_comple, date_de_nettoyage)
            Next

        End If

    End Sub

    'Ajouter un commentaire à une chambre
    Public Function ajouterUnCommentaire(ByVal CODE_CHAMBRE As String, ByVal COMMENTAIRE As String) As Boolean

        Dim insertQuery As String = "UPDATE `chambre` SET GUEST_DAI = @COMMENTAIRE WHERE CODE_CHAMBRE=@CODE_CHAMBRE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@COMMENTAIRE", MySqlDbType.VarChar).Value = COMMENTAIRE

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

    'Changement de l'état des chambres

    Public Function ChangementEtatDesChambre(ByVal CODE_CHAMBRE As String, ByVal ETAT_CHAMBRE_NOTE As String, ByVal ETAT_CHAMBRE As Integer) As Boolean

        Dim insertQuery As String = "UPDATE `chambre` SET ETAT_CHAMBRE_NOTE = @ETAT_CHAMBRE_NOTE,  ETAT_CHAMBRE = @ETAT_CHAMBRE WHERE CODE_CHAMBRE=@CODE_CHAMBRE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = ETAT_CHAMBRE_NOTE
        command.Parameters.Add("@ETAT_CHAMBRE", MySqlDbType.Int64).Value = ETAT_CHAMBRE

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

    Public Function miseAjourDelaChambreApreNettoyage(ByVal CODE_CHAMBRE As String, ByVal ETAT_CHAMBRE_NOTE As String) As Boolean
        Dim updateQuery As String = "UPDATE nettoyage SET ETAT_CHAMBRE_NOTE=@ETAT_CHAMBRE_NOTE WHERE CODE_CHAMBRE = @CODE_CHAMBRE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CHAMBRE", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        'command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle
        command.Parameters.Add("@ETAT_CHAMBRE_NOTE", MySqlDbType.VarChar).Value = ETAT_CHAMBRE_NOTE

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
