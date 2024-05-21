Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Panne

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    '----------------------------------------------- GESTION DES PANNES

    'Insertion des pannes
    Public Function Insert(ByVal CODE_PANNE As String, ByVal LIBELLE As String, ByVal DESCRIPTION As String, ByVal TYPE_FAMILLE_OU_SOUS_FAMILLE As String, ByVal CODE_AGENCE As String, ByVal PARENT As String, ByVal TYPE As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `famille_et_sous_famille_panne`(`CODE_PANNE`, `LIBELLE`, `DESCRIPTION`, `TYPE_FAMILLE_OU_SOUS_FAMILLE`, `CODE_AGENCE`, `PARENT`, `TYPE`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@TYPE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_PANNE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = TYPE_FAMILLE_OU_SOUS_FAMILLE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = PARENT
        command.Parameters.Add("@TYPE", MySqlDbType.Int64).Value = TYPE

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

    'mise ajours des pannes
    Public Function Update(ByVal CODE_PANNE As String, ByVal LIBELLE As String, ByVal DESCRIPTION As String, ByVal TYPE_FAMILLE_OU_SOUS_FAMILLE As String, ByVal CODE_AGENCE As String, ByVal PARENT As String, ByVal TYPE As Integer) As Boolean

        Dim insertQuery As String = "UPDATE `famille_et_sous_famille_panne` SET `CODE_PANNE`=@value2, `LIBELLE`=@value3, `DESCRIPTION`=@value4, `TYPE_FAMILLE_OU_SOUS_FAMILLE`=@value5, `CODE_AGENCE`=@value6, `PARENT`=@value7, `TYPE`=@TYPE WHERE CODE_PANNE=@CODE_PANNE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_PANNE
        command.Parameters.Add("@CODE_PANNE", MySqlDbType.VarChar).Value = CODE_PANNE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = TYPE_FAMILLE_OU_SOUS_FAMILLE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = PARENT
        command.Parameters.Add("@TYPE", MySqlDbType.Int64).Value = TYPE

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


    '----------------------------------------------- GESTION DES DEMANDES D'INTERVENTION


    Public Function InsertEquipementUtilisePourIntervetion(ByVal CODE_EQUIPEMENT As String, ByVal PRIX_BASE As Double, ByVal PRIX_REEL As Double, ByVal QTE As Double, ByVal PT As Double, ByVal EQUIPËMENT_UTILISE As String, ByVal ETAT As Integer, ByVal UTILISATEUR As String, ByVal CODE_DEMANDE As String, ByVal CODE_INTERVENTION As String)

        Dim insertQuery As String = "INSERT INTO `ligne_intervention`(`CODE_EQUIPEMENT`, `PRIX_BASE`, `PRIX_REEL`, `QTE`, `PT`, `EQUIPËMENT_UTILISE`, `ETAT`, `UTILISATEUR`, `CODE_DEMANDE`, `CODE_INTERVENTION`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11)"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_EQUIPEMENT
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = PRIX_BASE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = PRIX_REEL
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = QTE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = PT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = EQUIPËMENT_UTILISE
        command.Parameters.Add("@value8", MySqlDbType.Int64).Value = ETAT
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = UTILISATEUR
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_DEMANDE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = CODE_INTERVENTION

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function


    'DEMANDE D'INTERVENTION

    Public Function InsertDemande(ByVal CODE_DEMANDE_INTERVENTION As String, ByVal DATE_INTERVENTION As Date, ByVal HEURE_INTERVENTION As String, ByVal SITE As String, ByVal SOUS_ZONE As String, ByVal ZONE As Integer, ByVal STATUT As String, ByVal FAMILLE_PANNE As String, ByVal TYPE_PANNE As String, ByVal ORIGINE_DEMANDE As String, ByVal COMMENTAIRE As String, ByVal CODE_AGENCE As String, ByVal CODE_UTILISATEUR As String, ByVal SERVICE_ORIGIN As String, ByVal LIEU_PANNE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `demande_intervention`(`CODE_DEMANDE_INTERVENTION`, `DATE_INTERVENTION`, `HEURE_INTERVENTION`, `SITE`, `SOUS_ZONE`, `ZONE`, `STATUT`, `FAMILLE_PANNE`, `TYPE_PANNE`, `ORIGINE_DEMANDE`, `COMMENTAIRE`, `CODE_AGENCE`, `CODE_UTILISATEUR`, `SERVICE_ORIGIN`, `LIEU_PANNE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14, @SERVICE_ORIGIN, @LIEU_PANNE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_DEMANDE_INTERVENTION
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_INTERVENTION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = HEURE_INTERVENTION
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = SITE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = SOUS_ZONE
        command.Parameters.Add("@value7", MySqlDbType.Int64).Value = ZONE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = STATUT
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = FAMILLE_PANNE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = TYPE_PANNE ' sous famille de panne
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = ORIGINE_DEMANDE
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = COMMENTAIRE
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@SERVICE_ORIGIN", MySqlDbType.VarChar).Value = SERVICE_ORIGIN
        command.Parameters.Add("@LIEU_PANNE", MySqlDbType.VarChar).Value = LIEU_PANNE

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

    'mise ajours des demandes d'intervention
    Public Function UpdateDemande(ByVal CODE_DEMANDE_INTERVENTION As String, ByVal DATE_INTERVENTION As Date, ByVal HEURE_INTERVENTION As String, ByVal SITE As String, ByVal SOUS_ZONE As String, ByVal ZONE As Integer, ByVal STATUT As String, ByVal FAMILLE_PANNE As String, ByVal TYPE_PANNE As String, ByVal ORIGINE_DEMANDE As String, ByVal COMMENTAIRE As String, ByVal CODE_AGENCE As String, ByVal CODE_UTILISATEUR As String, ByVal SERVICE_ORIGIN As String, ByVal LIEU_PANNE As String) As Boolean

        ' Dim insertQuery As String = "UPDATE `demande_intervention` SET `CODE_DEMANDE_INTERVENTION`=@value2, `DATE_INTERVENTION`=@value3,`HEURE_INTERVENTION`=@value4, `SITE`=@value5,`SOUS_ZONE`=@value6,`ZONE`=@value7, `STATUT`=@value8,`FAMILLE_PANNE`=@value9, `TYPE_PANNE`=@value10,`ORIGINE_DEMANDE`=@value11,`COMMENTAIRE`=@value12,`CODE_AGENCE`=@value13,`CODE_UTILISATEUR`=@value14 WHERE CODE_DEMANDE_INTERVENTION=@CODE_DEMANDE_INTERVENTION"
        Dim insertQuery As String = "UPDATE `demande_intervention` SET `CODE_DEMANDE_INTERVENTION`=@value2, `DATE_INTERVENTION`=@value3, `SITE`=@value5,`SOUS_ZONE`=@value6,`ZONE`=@value7, `STATUT`=@value8,`FAMILLE_PANNE`=@value9, `TYPE_PANNE`=@value10,`ORIGINE_DEMANDE`=@value11,`COMMENTAIRE`=@value12,`CODE_AGENCE`=@value13,`CODE_UTILISATEUR`=@value14, SERVICE_ORIGIN =@SERVICE_ORIGIN, LIEU_PANNE=@LIEU_PANNE WHERE CODE_DEMANDE_INTERVENTION=@CODE_DEMANDE_INTERVENTION"

        'Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_DEMANDE_INTERVENTION", MySqlDbType.VarChar).Value = CODE_DEMANDE_INTERVENTION

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_DEMANDE_INTERVENTION
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_INTERVENTION
        'command.Parameters.Add("@value4", MySqlDbType.DateTime).Value = HEURE_INTERVENTION
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = SITE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = SOUS_ZONE
        command.Parameters.Add("@value7", MySqlDbType.Int64).Value = ZONE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = STATUT
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = FAMILLE_PANNE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = TYPE_PANNE ' sous famille de panne
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = ORIGINE_DEMANDE
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = COMMENTAIRE
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@SERVICE_ORIGIN", MySqlDbType.VarChar).Value = SERVICE_ORIGIN
        command.Parameters.Add("@LIEU_PANNE", MySqlDbType.VarChar).Value = LIEU_PANNE

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

    'mise ajours des demandes d'intervention
    Public Function UpdateStatutDemande(ByVal CODE_DEMANDE_INTERVENTION As String, ByVal STATUT As String) As Boolean

        Dim insertQuery As String = "UPDATE `demande_intervention` SET `STATUT`=@value8 WHERE CODE_DEMANDE_INTERVENTION=@CODE_DEMANDE_INTERVENTION"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_DEMANDE_INTERVENTION", MySqlDbType.VarChar).Value = CODE_DEMANDE_INTERVENTION

        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = "Achevé"

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

    '----------------------------------------------- GESTION DES INTERVENTIONS ----------------------------------------------

    'SELECTION DES INTERENANTS

    Public Function Intervenants() As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable

        Dim getUserQuery = "SELECT NOM_PERSONNEL, PRENOM_PERSONNEL, type_personnel.CODE_TYPE_PERSONNEL,LIBELLE_TYPE_PERSONNEL,CODE_PERSONNEL FROM  personnel INNER JOIN type_personnel WHERE personnel.CODE_TYPE_PERSONNEL = type_personnel.CODE_TYPE_PERSONNEL AND LIBELLE_TYPE_PERSONNEL=@LIBELLE_TYPE_PERSONNEL"

        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@LIBELLE_TYPE_PERSONNEL", MySqlDbType.VarChar).Value = "MAINTENANCIER"

        adapter.SelectCommand = Command
        adapter.Fill(table)

        'GlobalVariable.'connect.closeConnection()

        Return table

    End Function

    Public Function InsertIntervention(ByVal CODE_INTERVENTION As String, ByVal DATE_INTERVENTION As Date, ByVal HEURE_INTERVENTION As String, ByVal SITE As String, ByVal SOUS_ZONE As String, ByVal ZONE As Integer, ByVal STATUT As String, ByVal FAMILLE_PANNE As String, ByVal TYPE_PANNE As String, ByVal DIAGNOSTIQUE As String, ByVal COMMENTAIRE As String, ByVal CODE_AGENCE As String, ByVal CODE_UTILISATEUR As String, ByVal CODE_INTERVENANT As String, ByVal CODE_DEMANDE As String, ByVal TEMPS As Integer, ByVal LIEU_PANNE As String, ByVal ORIGINE_DEMANDE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `intervention`(`CODE_INTERVENTION`, `DATE_INTERVENTION`, `HEURE_INTERVENTION`, `SITE`, `SOUS_ZONE`, `ZONE`, `STATUT`, `FAMILLE_PANNE`, `TYPE_PANNE`, `DIAGNOSTIQUE`, `COMMENTAIRE`, `CODE_AGENCE`, `CODE_UTILISATEUR`,`CODE_INTERVENANT`, `CODE_DEMANDE`, `TEMPS`, `LIEU_PANNE`,`ORIGINE_DEMANDE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17, @LIEU_PANNE, @ORIGINE_DEMANDE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_INTERVENTION
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_INTERVENTION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = HEURE_INTERVENTION
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = SITE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = SOUS_ZONE
        command.Parameters.Add("@value7", MySqlDbType.Int64).Value = ZONE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = STATUT
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = FAMILLE_PANNE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = TYPE_PANNE ' sous famille de panne
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = DIAGNOSTIQUE
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = COMMENTAIRE
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_INTERVENANT
        command.Parameters.Add("@value16", MySqlDbType.VarChar).Value = CODE_DEMANDE
        command.Parameters.Add("@LIEU_PANNE", MySqlDbType.VarChar).Value = LIEU_PANNE
        command.Parameters.Add("@ORIGINE_DEMANDE", MySqlDbType.VarChar).Value = ORIGINE_DEMANDE
        command.Parameters.Add("@value17", MySqlDbType.Int64).Value = TEMPS

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

    Public Function InsertEquipementPourIntervention(ByVal CODE_EQUIPEMENT As String, ByVal PRIX_BASE As Double, ByVal PRIX_REEL As Double, ByVal QTE As Double, ByVal PT As Double, ByVal EQUIPEMENT_UTILISE As String, ByVal ETAT As Integer, ByVal UTILISATEUR As String, ByVal CODE_DEMANDE As String, ByVal CODE_INTERVENTION As String)

        Dim insertQuery As String = "INSERT INTO `ligne_intervention`(`CODE_EQUIPEMENT`, `PRIX_BASE`, `PRIX_REEL`, `QTE`, `PT`, `EQUIPEMENT_UTILISE`, `ETAT`, `UTILISATEUR`, `CODE_DEMANDE`, `CODE_INTERVENTION`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_EQUIPEMENT
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = PRIX_BASE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = PRIX_REEL
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = QTE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = PT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = EQUIPEMENT_UTILISE
        command.Parameters.Add("@value8", MySqlDbType.Int64).Value = ETAT
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = UTILISATEUR
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_DEMANDE ' sous famille de panne
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = CODE_INTERVENTION

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

    Public Function insertProblemeDemande(ByVal CODE_PROBLEME As String, ByVal CODE_DEMANDE As String, ByVal LOCALISATION_PANNE As String, ByVal HABITATION As String, ByVal PROBLEME As String)

        Dim insertQuery As String = "INSERT INTO `demande_intervention_probleme`(`CODE_PROBLEME`, `CODE_DEMANDE`, `LOCALISATION_PANNE`, `HABITATION`, `PROBLEME`) VALUES (@value2,@value3,@value4,@value5,@value6)"
        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_PROBLEME
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_DEMANDE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = LOCALISATION_PANNE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = HABITATION
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = PROBLEME

        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

End Class
