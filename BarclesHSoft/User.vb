Imports System.IO
Imports MySql.Data.MySqlClient

Public Class User

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new user
    Public Function insertUser(ByVal CODE_UTILISATEUR As String, ByVal NOM_UTILISATEUR As String, ByVal GRIFFE_UTILISATEUR As String, ByVal CATEG_UTILISATEUR As String, ByVal AGENCE_TRAV_NUMBER As Integer, ByVal AGENCE_CREATE_NUMBER As Integer, ByVal PASSWORD_UTILISATEUR As String, ByVal DEBUT_ACCES As Date, ByVal FIN_ACCES As Date, ByVal NOM_CONNEXION As String, ByVal DATE_CHANGE_PWD As Date, ByVal DATE_CREATION As Date, ByVal DATE_EXPIRATION As Date, ByVal DATE_DERNIERE_MAJ As Date, ByVal POSTE_UTILISATEUR As String, ByVal CODE_UTILISATEUR_MAJ As String, ByVal ETAT_UTILISATEUR As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal PEUT_FAIRE_REMISE As String, ByVal PRIX_VENTE_MODIFIABLE As String, ByVal PEUT_FAIRE_DEDUCTION_CLIENT As String, ByVal PEUT_ANNULER_COMMANDE As String, ByVal PEUT_CLOTURER_MAIN_COURANTE As String, ByVal CONNEXION_DISTANTE As String, ByVal PEUT_ATTRIBUER_GRATUITE As String, ByVal PEUT_MODIFIER_TAXE_SEJOUR As String, ByVal LANGUE_PAR_DEFAUT As String, ByVal NUM_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `utilisateurs` (`CODE_UTILISATEUR`, `NOM_UTILISATEUR`, `GRIFFE_UTILISATEUR`, `CATEG_UTILISATEUR`, `AGENCE_TRAV_NUMBER`, `AGENCE_CREATE_NUMBER`, `PASSWORD_UTILISATEUR`, `DEBUT_ACCES`, `FIN_ACCES`, `NOM_CONNEXION`, `DATE_CHANGE_PWD`, `DATE_CREATION`, `DATE_EXPIRATION`, `DATE_DERNIERE_MAJ`, `POSTE_UTILISATEUR`, `CODE_UTILISATEUR_MAJ`, `ETAT_UTILISATEUR`, `CODE_UTILISATEUR_CREA`, `PEUT_FAIRE_REMISE`, `PRIX_VENTE_MODIFIABLE`, `PEUT_FAIRE_DEDUCTION_CLIENT`, `PEUT_ANNULER_COMMANDE`, `PEUT_CLOTURER_MAIN_COURANTE`, `CONNEXION_DISTANTE`, `PEUT_ATTRIBUER_GRATUITE`, `PEUT_MODIFIER_TAXE_SEJOUR`, `LANGUE_PAR_DEFAUT`, `NUM_AGENCE`) VALUES (@CODE_UTILISATEUR, @NOM_UTILISATEUR, @GRIFFE_UTILISATEUR, @CATEG_UTILISATEUR, @AGENCE_TRAV_NUMBER, @AGENCE_CREATE_NUMBER, @PASSWORD_UTILISATEUR, @DEBUT_ACCES, @FIN_ACCES, @NOM_CONNEXION, @DATE_CHANGE_PWD, @DATE_CREATION, @DATE_EXPIRATION, @DATE_DERNIERE_MAJ, @POSTE_UTILISATEUR, @CODE_UTILISATEUR_MAJ, @ETAT_UTILISATEUR, @CODE_UTILISATEUR_CREA, @PEUT_FAIRE_REMISE, @PRIX_VENTE_MODIFIABLE, @PEUT_FAIRE_DEDUCTION_CLIENT, @PEUT_ANNULER_COMMANDE, @PEUT_CLOTURER_MAIN_COURANTE, @CONNEXION_DISTANTE, @PEUT_ATTRIBUER_GRATUITE, @PEUT_MODIFIER_TAXE_SEJOUR, @LANGUE_PAR_DEFAUT,  @NUM_AGENCE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@NOM_UTILISATEUR", MySqlDbType.VarChar).Value = NOM_UTILISATEUR
        command.Parameters.Add("@GRIFFE_UTILISATEUR", MySqlDbType.VarChar).Value = GRIFFE_UTILISATEUR
        command.Parameters.Add("@CATEG_UTILISATEUR", MySqlDbType.VarChar).Value = CATEG_UTILISATEUR
        command.Parameters.Add("@AGENCE_TRAV_NUMBER", MySqlDbType.VarChar).Value = AGENCE_TRAV_NUMBER
        command.Parameters.Add("@AGENCE_CREATE_NUMBER", MySqlDbType.VarChar).Value = AGENCE_CREATE_NUMBER
        command.Parameters.Add("@PASSWORD_UTILISATEUR", MySqlDbType.VarChar).Value = PASSWORD_UTILISATEUR
        command.Parameters.Add("@DEBUT_ACCES", MySqlDbType.Date).Value = DEBUT_ACCES
        command.Parameters.Add("@FIN_ACCES", MySqlDbType.Date).Value = FIN_ACCES
        command.Parameters.Add("@NOM_CONNEXION", MySqlDbType.VarChar).Value = NOM_CONNEXION
        command.Parameters.Add("@DATE_CHANGE_PWD", MySqlDbType.Date).Value = DATE_CHANGE_PWD
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = Now()
        command.Parameters.Add("@DATE_EXPIRATION", MySqlDbType.VarChar).Value = DATE_EXPIRATION
        'The below command is not yeat treated
        command.Parameters.Add("@DATE_DERNIERE_MAJ", MySqlDbType.Date).Value = DATE_DERNIERE_MAJ
        command.Parameters.Add("@POSTE_UTILISATEUR", MySqlDbType.VarChar).Value = POSTE_UTILISATEUR
        command.Parameters.Add("@CODE_UTILISATEUR_MAJ", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MAJ
        command.Parameters.Add("@ETAT_UTILISATEUR", MySqlDbType.VarChar).Value = ETAT_UTILISATEUR
        command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@PEUT_FAIRE_REMISE", MySqlDbType.VarChar).Value = PEUT_FAIRE_REMISE
        command.Parameters.Add("@PRIX_VENTE_MODIFIABLE", MySqlDbType.VarChar).Value = PRIX_VENTE_MODIFIABLE
        command.Parameters.Add("@PEUT_FAIRE_DEDUCTION_CLIENT", MySqlDbType.VarChar).Value = PEUT_FAIRE_DEDUCTION_CLIENT
        command.Parameters.Add("@PEUT_ANNULER_COMMANDE", MySqlDbType.VarChar).Value = PEUT_ANNULER_COMMANDE
        command.Parameters.Add("@PEUT_CLOTURER_MAIN_COURANTE", MySqlDbType.VarChar).Value = PEUT_CLOTURER_MAIN_COURANTE
        command.Parameters.Add("@CONNEXION_DISTANTE", MySqlDbType.VarChar).Value = CONNEXION_DISTANTE
        command.Parameters.Add("@PEUT_ATTRIBUER_GRATUITE", MySqlDbType.VarChar).Value = PEUT_ATTRIBUER_GRATUITE
        command.Parameters.Add("@PEUT_MODIFIER_TAXE_SEJOUR", MySqlDbType.VarChar).Value = PEUT_MODIFIER_TAXE_SEJOUR
        command.Parameters.Add("@LANGUE_PAR_DEFAUT", MySqlDbType.VarChar).Value = LANGUE_PAR_DEFAUT
        command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = NUM_AGENCE

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
    Public Function usernameExists(ByVal CODE_UTILISATEUR As String, ByVal NOM_UTILISATEUR As String) As Boolean

        Dim existQuery As String = "SELECT * From utilisateurs WHERE CODE_UTILISATEUR=@CODE_UTILISATEUR OR NOM_UTILISATEUR=@NOM_UTILISATEUR"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@NOM_UTILISATEUR", MySqlDbType.VarChar).Value = NOM_UTILISATEUR

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

    Public Function updateUserCaisseMagasin(ByVal CODE_UTILISATEUR As String, ByVal OLD_CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "UPDATE `utilisateur_caisse` SET `CODE_UTILISATEUR`=@CODE_UTILISATEUR WHERE CODE_UTILISATEUR=@OLD_CODE_UTILISATEUR"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@OLD_CODE_UTILISATEUR", MySqlDbType.VarChar).Value = OLD_CODE_UTILISATEUR

        'Excuting the command and testing if everything went on well
        command.ExecuteNonQuery()

        insertQuery = "UPDATE `utilisateur_magazin` SET `CODE_UTILISATEUR`=@CODE_UTILISATEUR WHERE CODE_UTILISATEUR=@OLD_CODE_UTILISATEUR"

        Dim command1 As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command1.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command1.Parameters.Add("@OLD_CODE_UTILISATEUR", MySqlDbType.VarChar).Value = OLD_CODE_UTILISATEUR

        'Excuting the command and testing if everything went on well
        command1.ExecuteNonQuery()

    End Function

    'create a function to update the selected user
    Public Function updateUser(ByVal CODE_UTILISATEUR As String, ByVal NOM_UTILISATEUR As String, ByVal GRIFFE_UTILISATEUR As String, ByVal CATEG_UTILISATEUR As String, ByVal AGENCE_TRAV_NUMBER As Integer, ByVal AGENCE_CREATE_NUMBER As Integer, ByVal PASSWORD_UTILISATEUR As String, ByVal DEBUT_ACCES As Date, ByVal FIN_ACCES As Date, ByVal NOM_CONNEXION As String, ByVal DATE_CHANGE_PWD As Date, ByVal DATE_CREATION As Date, ByVal DATE_EXPIRATION As Date, ByVal DATE_DERNIERE_MAJ As Date, ByVal POSTE_UTILISATEUR As String, ByVal CODE_UTILISATEUR_MAJ As String, ByVal ETAT_UTILISATEUR As String, ByVal CODE_UTILISATEUR_CREA As String, ByVal PEUT_FAIRE_REMISE As String, ByVal PRIX_VENTE_MODIFIABLE As String, ByVal PEUT_FAIRE_DEDUCTION_CLIENT As String, ByVal PEUT_ANNULER_COMMANDE As String, ByVal PEUT_CLOTURER_MAIN_COURANTE As String, ByVal CONNEXION_DISTANTE As String, ByVal PEUT_ATTRIBUER_GRATUITE As String, ByVal PEUT_MODIFIER_TAXE_SEJOUR As String, ByVal LANGUE_PAR_DEFAUT As String, ByVal NUM_AGENCE As String, ByVal OLD_CODE_UTILISATEUR As String) As Boolean

        Dim insertQuery As String = "UPDATE `utilisateurs` SET CODE_UTILISATEUR=@CODE_UTILISATEUR, NOM_UTILISATEUR=@NOM_UTILISATEUR, GRIFFE_UTILISATEUR=@GRIFFE_UTILISATEUR, CATEG_UTILISATEUR=@CATEG_UTILISATEUR, AGENCE_TRAV_NUMBER=@AGENCE_TRAV_NUMBER, AGENCE_CREATE_NUMBER=@AGENCE_CREATE_NUMBER, PASSWORD_UTILISATEUR=@PASSWORD_UTILISATEUR, DEBUT_ACCES=@DEBUT_ACCES, FIN_ACCES=@FIN_ACCES, NOM_CONNEXION=@NOM_CONNEXION, DATE_CHANGE_PWD=@DATE_CHANGE_PWD, DATE_CREATION=@DATE_CREATION, DATE_EXPIRATION=@DATE_EXPIRATION, DATE_DERNIERE_MAJ=@DATE_DERNIERE_MAJ, POSTE_UTILISATEUR=@POSTE_UTILISATEUR, CODE_UTILISATEUR_MAJ=@CODE_UTILISATEUR_MAJ, ETAT_UTILISATEUR=@ETAT_UTILISATEUR, CODE_UTILISATEUR_CREA=@CODE_UTILISATEUR_CREA, PEUT_FAIRE_REMISE=@PEUT_FAIRE_REMISE, PRIX_VENTE_MODIFIABLE=@PRIX_VENTE_MODIFIABLE, PEUT_FAIRE_DEDUCTION_CLIENT=@PEUT_FAIRE_DEDUCTION_CLIENT, PEUT_ANNULER_COMMANDE=@PEUT_ANNULER_COMMANDE, PEUT_CLOTURER_MAIN_COURANTE=@PEUT_CLOTURER_MAIN_COURANTE, CONNEXION_DISTANTE=@CONNEXION_DISTANTE, PEUT_ATTRIBUER_GRATUITE=@PEUT_ATTRIBUER_GRATUITE, PEUT_MODIFIER_TAXE_SEJOUR=@PEUT_MODIFIER_TAXE_SEJOUR, LANGUE_PAR_DEFAUT=@LANGUE_PAR_DEFAUT, NUM_AGENCE=@NUM_AGENCE WHERE CODE_UTILISATEUR = @OLD_CODE_UTILISATEUR"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR
        command.Parameters.Add("@OLD_CODE_UTILISATEUR", MySqlDbType.VarChar).Value = OLD_CODE_UTILISATEUR
        command.Parameters.Add("@NOM_UTILISATEUR", MySqlDbType.VarChar).Value = NOM_UTILISATEUR
        command.Parameters.Add("@GRIFFE_UTILISATEUR", MySqlDbType.VarChar).Value = GRIFFE_UTILISATEUR
        command.Parameters.Add("@CATEG_UTILISATEUR", MySqlDbType.VarChar).Value = CATEG_UTILISATEUR
        command.Parameters.Add("@AGENCE_TRAV_NUMBER", MySqlDbType.VarChar).Value = AGENCE_TRAV_NUMBER
        command.Parameters.Add("@AGENCE_CREATE_NUMBER", MySqlDbType.VarChar).Value = AGENCE_CREATE_NUMBER
        command.Parameters.Add("@PASSWORD_UTILISATEUR", MySqlDbType.VarChar).Value = PASSWORD_UTILISATEUR
        command.Parameters.Add("@DEBUT_ACCES", MySqlDbType.Date).Value = DEBUT_ACCES
        command.Parameters.Add("@FIN_ACCES", MySqlDbType.Date).Value = FIN_ACCES
        command.Parameters.Add("@NOM_CONNEXION", MySqlDbType.VarChar).Value = NOM_CONNEXION
        command.Parameters.Add("@DATE_CHANGE_PWD", MySqlDbType.Date).Value = DATE_CHANGE_PWD
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@DATE_EXPIRATION", MySqlDbType.Date).Value = DATE_EXPIRATION
        'The below command is not yeat treated
        command.Parameters.Add("@DATE_DERNIERE_MAJ", MySqlDbType.Date).Value = DATE_DERNIERE_MAJ
        command.Parameters.Add("@POSTE_UTILISATEUR", MySqlDbType.VarChar).Value = POSTE_UTILISATEUR
        command.Parameters.Add("@CODE_UTILISATEUR_MAJ", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MAJ
        command.Parameters.Add("@ETAT_UTILISATEUR", MySqlDbType.VarChar).Value = ETAT_UTILISATEUR
        command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@PEUT_FAIRE_REMISE", MySqlDbType.VarChar).Value = PEUT_FAIRE_REMISE
        command.Parameters.Add("@PRIX_VENTE_MODIFIABLE", MySqlDbType.VarChar).Value = PRIX_VENTE_MODIFIABLE
        command.Parameters.Add("@PEUT_FAIRE_DEDUCTION_CLIENT", MySqlDbType.VarChar).Value = PEUT_FAIRE_DEDUCTION_CLIENT
        command.Parameters.Add("@PEUT_ANNULER_COMMANDE", MySqlDbType.VarChar).Value = PEUT_ANNULER_COMMANDE
        command.Parameters.Add("@PEUT_CLOTURER_MAIN_COURANTE", MySqlDbType.VarChar).Value = PEUT_CLOTURER_MAIN_COURANTE
        command.Parameters.Add("@CONNEXION_DISTANTE", MySqlDbType.VarChar).Value = CONNEXION_DISTANTE
        command.Parameters.Add("@PEUT_ATTRIBUER_GRATUITE", MySqlDbType.VarChar).Value = PEUT_ATTRIBUER_GRATUITE
        command.Parameters.Add("@PEUT_MODIFIER_TAXE_SEJOUR", MySqlDbType.VarChar).Value = PEUT_MODIFIER_TAXE_SEJOUR
        command.Parameters.Add("@LANGUE_PAR_DEFAUT", MySqlDbType.VarChar).Value = LANGUE_PAR_DEFAUT
        command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = NUM_AGENCE

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

    'Create a Function to return a user using his id
    Public Function getUserById(ByVal ID_UTILISATEUR As Integer) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT * utilisateurs WHERE ID_UTILISATEUR=@ID_UTILISATEUR"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ID_UTILISATEUR", MySqlDbType.Int32).Value = ID_UTILISATEUR
        adapter.SelectCommand = Command
        adapter.Fill(table)

        Return table

    End Function

    Public Function updateUserPassword(ByVal CODE_UTILISATEUR As String, ByVal PASSWORD_UTILISATEUR As String, ByVal NUM_AGENCE As String) As Boolean

        Dim insertQuery As String = "UPDATE `utilisateurs` SET PASSWORD_UTILISATEUR=@PASSWORD_UTILISATEUR WHERE CODE_UTILISATEUR = @CODE_UTILISATEUR AND NUM_AGENCE=@NUM_AGENCE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = CODE_UTILISATEUR

        command.Parameters.Add("@PASSWORD_UTILISATEUR", MySqlDbType.VarChar).Value = PASSWORD_UTILISATEUR
        'The below command is not yeat treated

        command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = NUM_AGENCE

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

    Public Shared Function mouchard(ByVal ACTION As String)

        Dim insertQuery As String = "INSERT INTO `mouchards`(`CODE_MOUCHARD`, `ACTION`, `CODE_UTILISATEUR`, `NOM_UTILISATEUR`, `DATE_CREATION`,`CODE_AGENCE`) VALUES (@CODE_MOUCHARD ,@ACTION ,@CODE_UTILISATEUR , @NOM_UTILISATEUR, @DATE_CREATION, @CODE_AGENCE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        Dim CODE_AGENCE As String = ""

        If GlobalVariable.AgenceActuelle.Rows.Count > 0 Then

            If GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE") IsNot Nothing Then
                CODE_AGENCE = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            End If

        End If

        command.Parameters.Add("@CODE_MOUCHARD", MySqlDbType.VarChar).Value = Functions.GeneratingRandomCodePanne("mouchards", "")
        command.Parameters.Add("@ACTION", MySqlDbType.VarChar).Value = ACTION
        command.Parameters.Add("@CODE_UTILISATEUR", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        command.Parameters.Add("@NOM_UTILISATEUR", MySqlDbType.VarChar).Value = GlobalVariable.ConnectedUser.Rows(0)("NOM_UTILISATEUR")
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail

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

    Public Function sendMessage(ByVal CODE_PROFIL As String, ByVal MESSAGE As String, ByVal OBJET As String, ByVal DATE_ENVOI As Date, ByVal EXPEDITEUR As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `notification`(`CODE_PROFIL`, `MESSAGE`, `OBJET`, `DATE_ENVOI`, `CODE_AGENCE`,`EXPEDITEUR`) VALUES (@CODE_PROFIL, @MESSAGE, @OBJET, @DATE_ENVOI, @CODE_AGENCE, @EXPEDITEUR)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PROFIL", MySqlDbType.VarChar).Value = CODE_PROFIL
        command.Parameters.Add("@MESSAGE", MySqlDbType.VarChar).Value = MESSAGE
        command.Parameters.Add("@OBJET", MySqlDbType.VarChar).Value = OBJET
        command.Parameters.Add("@DATE_ENVOI", MySqlDbType.DateTime).Value = DATE_ENVOI
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@EXPEDITEUR", MySqlDbType.VarChar).Value = EXPEDITEUR

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

    Public Function updateMessageState(ByVal ID_NOTIFICATION As Integer, ByVal ETAT As Integer) As Boolean

        Dim updateQuery As String = "UPDATE `notification` SET `ETAT_NOTIFCATION`=@ETAT WHERE ID_NOTIFICATION=@ID_NOTIFICATION"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@ID_NOTIFICATION", MySqlDbType.Int64).Value = ID_NOTIFICATION
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT

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

    Public Shared Function suiviDesReservations(ByVal CODE_SUIVI As String, ByVal CODE_RESERVATION As String, ByVal RESERVATION_PAR As String, ByVal CHECKIN_PAR As String, ByVal CHECKOUT_PAR As String, ByVal DELOGEMENT_PAR As String)

        Dim insertQuery As String = "INSERT INTO `suivi_des_reservations`(`CODE_SUIVI`, `CODE_RESERVATION`, `RESERVATION_PAR`, `CHECKIN_PAR`, `CHECKOUT_PAR`, `DELOGEMENT_PAR`,`CODE_AGENCE`) VALUES (@CODE_SUIVI, @CODE_RESERVATION, @RESERVATION_PAR, @CHECKIN_PAR, @CHECKOUT_PAR, @DELOGEMENT_PAR, @CODE_AGENCE) "

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        Dim CODE_AGENCE As String = ""

        If GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE") IsNot Nothing Then
            CODE_AGENCE = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        End If

        command.Parameters.Add("@CODE_SUIVI", MySqlDbType.VarChar).Value = CODE_SUIVI
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@RESERVATION_PAR", MySqlDbType.VarChar).Value = RESERVATION_PAR
        command.Parameters.Add("@CHECKIN_PAR", MySqlDbType.VarChar).Value = CHECKIN_PAR
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@CHECKOUT_PAR", MySqlDbType.VarChar).Value = CHECKOUT_PAR
        command.Parameters.Add("@DELOGEMENT_PAR", MySqlDbType.VarChar).Value = DELOGEMENT_PAR
        'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Shared Function updateSuiviDesReservations(ByVal FIELD_NAME As String, ByVal FIELD_NAME_VALUE As String, ByVal CODE_RESERVATION As String)

        Dim insertQuery As String = "UPDATE `suivi_des_reservations` SET " & FIELD_NAME & "=@FIELD_NAME_VALUE WHERE CODE_RESERVATION =@CODE_RESERVATION"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        Dim CODE_AGENCE As String = ""

        If GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE") IsNot Nothing Then
            CODE_AGENCE = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
        End If

        command.Parameters.Add("@FIELD_NAME", MySqlDbType.VarChar).Value = FIELD_NAME
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@FIELD_NAME_VALUE", MySqlDbType.VarChar).Value = FIELD_NAME_VALUE

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
