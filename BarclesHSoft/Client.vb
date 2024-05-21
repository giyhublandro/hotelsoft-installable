Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Client

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'Total number of client
    Function TotalNumberOfElementsInTable(ByVal tableToCountElements As String) As Integer

        Dim existQuery As String = "SELECT * From " & tableToCountElements

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            'connect.closeConnection()
            Return table.Rows.Count
        Else
            'connect.closeConnection()
            Return 0
        End If

    End Function

    'insert a new client
    Public Function Insert(ByVal CODE_CLIENT As String, ByVal NOM_CLIENT As String, ByVal NOM_JEUNE_FILLE As String, ByVal PRENOMS As String, ByVal ADRESSE As String, ByVal TELEPHONE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal NUM_COMPTE As String, ByVal NATIONALITE As String, ByVal DATE_DE_NAISSANCE As Date, ByVal LIEU_DE_NAISSANCE As String, ByVal PAYS_RESIDENCE As String, ByVal VILLE_DE_RESIDENCE As String, ByVal PROFESSION As String, ByVal CNI As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUM_COMPTE_COLLECTIF As String, ByVal TYPE_CLIENT As String, ByVal SITE_INTERNET As String, ByVal CODE_AGENCE As String, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_ENTREPRISE As String, ByVal MODE_TRANSPORT As String, ByVal NUM_VEHICULE As String, ByVal MARQUE_VEHICULE As String, ByVal TVA As Integer, ByVal CIVILITE As String, ByVal CODE_ELITE As String) As Boolean


        Dim Inserting As String = "INSERT INTO `client` (`CODE_CLIENT`, `NOM_CLIENT`,`NOM_PRENOM`, `NOM_JEUNE_FILLE`, `PRENOMS`, `ADRESSE`, `TELEPHONE`, `FAX`,`EMAIL`,`NUM_COMPTE`,`NATIONALITE`,`DATE_DE_NAISSANCE`, `LIEU_DE_NAISSANCE`, `PAYS_RESIDENCE`,`VILLE_DE_RESIDENCE`,`PROFESSION`, `CNI`, `CODE_MODE_PAIEMENT`, `NUM_COMPTE_COLLECTIF`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`,`DATE_MODIFICATION`,`TYPE_CLIENT`, `SITE_INTERNET`,`CODE_AGENCE`,`CODE_UTILISATEUR_MODIF`,`CODE_ENTREPRISE`,`MODE_TRANSPORT`,`NUM_VEHICULE`,`MARQUE_VEHICULE`, `TVA`, `CIVILITE`, `CODE_ELITE`) VALUES (@CODE_CLIENT, @NOM_CLIENT,@NOM_PRENOM, @NOM_JEUNE_FILLE, @PRENOMS, @ADRESSE, @TELEPHONE, @FAX, @EMAIL, @NUM_COMPTE, @NATIONALITE, @DATE_DE_NAISSANCE, @LIEU_DE_NAISSANCE, @PAYS_RESIDENCE,@VILLE_DE_RESIDENCE, @PROFESSION, @CNI, @CODE_MODE_PAIEMENT, @NUM_COMPTE_COLLECTIF, @DATE_CREATION, @CODE_UTILISATEUR_CREA, @DATE_MODIFICATION, @TYPE_CLIENT, @SITE_INTERNET, @CODE_AGENCE, @CODE_UTILISATEUR_MODIF, @CODE_ENTREPRISE,@MODE_TRANSPORT,@NUM_VEHICULE ,@MARQUE_VEHICULE, @TVA, @CIVILITE, @CODE_ELITE)"

        Dim command As New MySqlCommand(Inserting, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.VarChar).Value = NOM_CLIENT

        If TYPE_CLIENT.Equals("ENTREPRISE") Then
            command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = NOM_CLIENT
        Else
            command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = NOM_CLIENT + " " + PRENOMS
        End If

        command.Parameters.Add("@NOM_JEUNE_FILLE", MySqlDbType.VarChar).Value = NOM_JEUNE_FILLE
        command.Parameters.Add("@VILLE_DE_RESIDENCE", MySqlDbType.VarChar).Value = VILLE_DE_RESIDENCE
        command.Parameters.Add("@FAX", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@PRENOMS", MySqlDbType.VarChar).Value = PRENOMS
        command.Parameters.Add("@ADRESSE", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@TELEPHONE", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@DATE_DE_NAISSANCE", MySqlDbType.Date).Value = DATE_DE_NAISSANCE
        command.Parameters.Add("@LIEU_DE_NAISSANCE", MySqlDbType.VarChar).Value = LIEU_DE_NAISSANCE
        command.Parameters.Add("@PAYS_RESIDENCE", MySqlDbType.VarChar).Value = PAYS_RESIDENCE
        command.Parameters.Add("@NUM_COMPTE", MySqlDbType.VarChar).Value = NUM_COMPTE
        command.Parameters.Add("@CNI", MySqlDbType.VarChar).Value = CNI
        command.Parameters.Add("@CODE_MODE_PAIEMENT", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@NATIONALITE", MySqlDbType.VarChar).Value = NATIONALITE
        command.Parameters.Add("@DATE_CREATION", MySqlDbType.Date).Value = Now()
        command.Parameters.Add("@CODE_UTILISATEUR_CREA", MySqlDbType.VarChar).Value = ""
        command.Parameters.Add("@DATE_MODIFICATION", MySqlDbType.Date).Value = Now()
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = TYPE_CLIENT
        command.Parameters.Add("@PROFESSION", MySqlDbType.VarChar).Value = PROFESSION
        command.Parameters.Add("@SITE_INTERNET", MySqlDbType.VarChar).Value = SITE_INTERNET
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@NUM_COMPTE_COLLECTIF", MySqlDbType.VarChar).Value = NUM_COMPTE_COLLECTIF
        command.Parameters.Add("@CODE_UTILISATEUR_MODIF", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@CODE_ENTREPRISE", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command.Parameters.Add("@MODE_TRANSPORT", MySqlDbType.VarChar).Value = MODE_TRANSPORT
        command.Parameters.Add("@NUM_VEHICULE", MySqlDbType.VarChar).Value = NUM_VEHICULE
        command.Parameters.Add("@MARQUE_VEHICULE", MySqlDbType.VarChar).Value = MARQUE_VEHICULE
        command.Parameters.Add("@CIVILITE", MySqlDbType.VarChar).Value = CIVILITE
        command.Parameters.Add("@CODE_ELITE", MySqlDbType.VarChar).Value = CODE_ELITE
        command.Parameters.Add("@TVA", MySqlDbType.Int16).Value = TVA

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

    'UPDATE
    Public Function Update(ByVal CODE_CLIENT As String, ByVal NOM_CLIENT As String, ByVal NOM_JEUNE_FILLE As String, ByVal PRENOMS As String, ByVal ADRESSE As String, ByVal TELEPHONE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal NUM_COMPTE As String, ByVal NATIONALITE As String, ByVal DATE_DE_NAISSANCE As Date, ByVal LIEU_DE_NAISSANCE As String, ByVal PAYS_RESIDENCE As String, ByVal VILLE_DE_RESIDENCE As String, ByVal PROFESSION As String, ByVal CNI As String, ByVal CODE_MODE_PAIEMENT As String, ByVal NUM_COMPTE_COLLECTIF As String, ByVal TYPE_CLIENT As String, ByVal SITE_INTERNET As String, ByVal CODE_UTILISATEUR_MODIF As String, ByVal CODE_ENTREPRISE As String, ByVal MODE_TRANSPORT As String, ByVal NUM_VEHICULE As String, ByVal MARQUE_VEHICULE As String, ByVal TVA As Integer, ByVal CIVILITE As String, ByVal CODE_ELITE As String) As Boolean

        Dim updateQuery As String = "UPDATE `client` SET `CODE_CLIENT`=@CODE_CLIENT,`NOM_CLIENT`=@NOM_CLIENT,`NOM_PRENOM`=@NOM_PRENOM,`NOM_JEUNE_FILLE`=@NOM_JEUNE_FILLE,`PRENOMS`=@PRENOMS,`ADRESSE`=@ADRESSE,`TELEPHONE`=@TELEPHONE,`FAX`=@FAX,`EMAIL`=@EMAIL,`NUM_COMPTE`=@NUM_COMPTE,`NATIONALITE`=@NATIONALITE,`DATE_DE_NAISSANCE`=@DATE_DE_NAISSANCE,`LIEU_DE_NAISSANCE`=@LIEU_DE_NAISSANCE,`PAYS_RESIDENCE`=@PAYS_RESIDENCE,`VILLE_DE_RESIDENCE`=@VILLE_DE_RESIDENCE,`PROFESSION`=@PROFESSION,`CNI`=@CNI,`CODE_MODE_PAIEMENT`=@CODE_MODE_PAIEMENT,`NUM_COMPTE_COLLECTIF`=@NUM_COMPTE_COLLECTIF,`DATE_MODIFICATION`=@DATE_MODIFICATION,
            `TYPE_CLIENT`=@TYPE_CLIENT,`SITE_INTERNET`=@SITE_INTERNET,`CODE_UTILISATEUR_MODIF`=@CODE_UTILISATEUR_MODIF,`CODE_ENTREPRISE`=@CODE_ENTREPRISE, 
        MODE_TRANSPORT=@MODE_TRANSPORT, NUM_VEHICULE=@NUM_VEHICULE, MARQUE_VEHICULE=@MARQUE_VEHICULE, TVA=@TVA , CIVILITE=@CIVILITE, CODE_ELITE = @CODE_ELITE WHERE `CODE_CLIENT` = @CODE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@CODE", MySqlDbType.VarChar).Value = CODE_CLIENT

        command.Parameters.Add("@NOM_CLIENT", MySqlDbType.VarChar).Value = NOM_CLIENT

        If TYPE_CLIENT.Equals("ENTREPRISE") Then
            command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = NOM_CLIENT
        Else
            command.Parameters.Add("@NOM_PRENOM", MySqlDbType.VarChar).Value = NOM_CLIENT + " " + PRENOMS
        End If

        command.Parameters.Add("@NOM_JEUNE_FILLE", MySqlDbType.VarChar).Value = NOM_JEUNE_FILLE
        command.Parameters.Add("@VILLE_DE_RESIDENCE", MySqlDbType.VarChar).Value = VILLE_DE_RESIDENCE
        command.Parameters.Add("@FAX", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@PRENOMS", MySqlDbType.VarChar).Value = PRENOMS
        command.Parameters.Add("@ADRESSE", MySqlDbType.VarChar).Value = ADRESSE
        command.Parameters.Add("@TELEPHONE", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@DATE_DE_NAISSANCE", MySqlDbType.Date).Value = DATE_DE_NAISSANCE
        command.Parameters.Add("@LIEU_DE_NAISSANCE", MySqlDbType.VarChar).Value = LIEU_DE_NAISSANCE
        command.Parameters.Add("@PAYS_RESIDENCE", MySqlDbType.VarChar).Value = PAYS_RESIDENCE
        command.Parameters.Add("@NUM_COMPTE", MySqlDbType.VarChar).Value = NUM_COMPTE
        command.Parameters.Add("@CNI", MySqlDbType.VarChar).Value = CNI
        command.Parameters.Add("@CODE_MODE_PAIEMENT", MySqlDbType.VarChar).Value = CODE_MODE_PAIEMENT
        command.Parameters.Add("@NATIONALITE", MySqlDbType.VarChar).Value = NATIONALITE
        command.Parameters.Add("@DATE_MODIFICATION", MySqlDbType.Date).Value = Now()
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = TYPE_CLIENT
        command.Parameters.Add("@PROFESSION", MySqlDbType.VarChar).Value = PROFESSION
        command.Parameters.Add("@SITE_INTERNET", MySqlDbType.VarChar).Value = SITE_INTERNET
        command.Parameters.Add("@NUM_COMPTE_COLLECTIF", MySqlDbType.VarChar).Value = NUM_COMPTE_COLLECTIF
        command.Parameters.Add("@CODE_UTILISATEUR_MODIF", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@CODE_ENTREPRISE", MySqlDbType.VarChar).Value = CODE_ENTREPRISE
        command.Parameters.Add("@MODE_TRANSPORT", MySqlDbType.VarChar).Value = MODE_TRANSPORT
        command.Parameters.Add("@NUM_VEHICULE", MySqlDbType.VarChar).Value = NUM_VEHICULE
        command.Parameters.Add("@MARQUE_VEHICULE", MySqlDbType.VarChar).Value = MARQUE_VEHICULE
        command.Parameters.Add("@TVA", MySqlDbType.Int16).Value = TVA
        command.Parameters.Add("@CIVILITE", MySqlDbType.VarChar).Value = CIVILITE
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

    'Create a function to check if the company already exists
    Public Function typeClientExists(ByVal CODE_CLIENT As String) As Boolean

        Dim existQuery As String = "SELECT * From client WHERE CODE_CLIENT=@CODE_CLIENT AND CODE_AGENCE=@CODE_AGENCE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")

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

    'Update the client

    'Create a Function to return a company using its id
    Public Function getTypeChambreById(ByVal ID_TYPE_CHAMBRE As Integer) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT * type_chambre WHERE ID_TYPE_CHAMBRE=@ID_TYPE_CHAMBRE"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ID_TYPE_CHAMBRE", MySqlDbType.Int32).Value = ID_TYPE_CHAMBRE
        adapter.SelectCommand = Command
        adapter.Fill(table)

        Return table

    End Function

    Public Function insertPreferences(ByVal CODE_CLIENT As String, ByVal PREFERENCE As String, ByVal CODE_PREFERENCE As String) As Boolean

        Dim Inserting As String = "INSERT INTO `prefernces_du_client`(`CODE_CLIENT`, `PREFERENCE`, `CODE_PREFERENCE`) VALUES (@CODE_CLIENT,@PREFERENCE,@CODE_PREFERENCE)"

        Dim command As New MySqlCommand(Inserting, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@PREFERENCE", MySqlDbType.VarChar).Value = PREFERENCE
        command.Parameters.Add("@CODE_PREFERENCE", MySqlDbType.VarChar).Value = CODE_PREFERENCE

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
