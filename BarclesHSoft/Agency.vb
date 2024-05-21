Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Agency

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new society

    Public Function insertWhatsApp(ByVal NOM_AGENCE As String, ByVal CODE_AGENCE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal TELEPHONE As String, ByVal VILLE As String, ByVal BOITE_POSTALE As String, ByVal PAYS As String, ByVal RUE As String, ByVal CATEGORIE_HOTEL As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `agence` (`NOM_AGENCE`,`CODE_AGENCE`, `FAX`, `EMAIL`, `TELEPHONE`, `VILLE`, `BOITE_POSTALE`, `PAYS`, `RUE`, `CATEGORIE_HOTEL`) VALUES (@NOM_AGENCE, @CODE_AGENCE, @FAX, @EMAIL, @TELEPHONE, @VILLE, @BOITE_POSTALE, @PAYS, @RUE, @CATEGORIE_HOTEL)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@NOM_AGENCE", MySqlDbType.VarChar).Value = NOM_AGENCE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@FAX", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@TELEPHONE", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@VILLE", MySqlDbType.VarChar).Value = VILLE
        command.Parameters.Add("@BOITE_POSTALE", MySqlDbType.VarChar).Value = BOITE_POSTALE
        command.Parameters.Add("@PAYS", MySqlDbType.VarChar).Value = PAYS
        command.Parameters.Add("@RUE", MySqlDbType.VarChar).Value = RUE
        command.Parameters.Add("@CATEGORIE_HOTEL", MySqlDbType.VarChar).Value = CATEGORIE_HOTEL

        'Opening the connection
        ''connect.openConnection()

        'Excuting the command and testing if everything went on well
        'If (command.ExecuteNonQuery() = 1) Then
        ''connect.closeConnection()
        'Return True
        'Else
        ''connect.closeConnection()
        'Return False
        'End If

    End Function

    Public Function InsertAgency(ByVal NOM_AGENCE As String, ByVal CODE_AGENCE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal TELEPHONE As String,
                                 ByVal VILLE As String, ByVal BOITE_POSTALE As String, ByVal PAYS As String, ByVal RUE As String, ByVal CATEGORIE_HOTEL As String,
                                 ByVal WHATSAPP_1 As String, ByVal WHATSAPP_2 As String, ByVal WHATSAPP_3 As String, ByVal WHATSAPP_4 As String, ByVal WHATSAPP_5 As String,
                                 ByVal WHATSAPP_6 As String, ByVal WHATSAPP_7 As String, ByVal EMAIL_1 As String, ByVal EMAIL_2 As String, ByVal EMAIL_3 As String,
                                 ByVal EMAIL_4 As String, ByVal EMAIL_5 As String, ByVal EMAIL_6 As String, ByVal EMAIL_7 As String,
                                 Optional ByVal GERER_STOCK As Integer = 0, Optional ByVal CLOTURE_MULTIPLE As Integer = 0,
                                 Optional ByVal CHEMIN_SAUVEGARDE_AUTO As String = "", Optional ByVal TARIFICATION_DYNAMIQUE As Integer = 0,
                                 Optional ByVal SESSION_UNIQUE As Integer = 0, Optional ByVal SERRURES As Integer = 0, ByVal Optional MESSAGE_WHATSAPP As Integer = 0,
                                 ByVal Optional CLOTURE_FACTURE As Integer = 0, ByVal Optional LANGUE As Integer = 1, ByVal Optional PRIX_BAR_RESTAU_MODIFIABLE As Integer = 1,
                                 ByVal Optional PAYER_AVANT_ENCODAGE As Integer = 0, ByVal Optional BLOQUER_PRIX_HEBERGEMENT As Integer = 0, ByVal Optional CLUB_ELITE As Integer = 0,
                                 ByVal Optional PRINT_B7 As Integer = 0, ByVal Optional MENSUALITE As Integer = 0, ByVal Optional MONTANT_NAVETTE As Double = 0,
                                 ByVal Optional NUMERO_RECEPTION As String = "", ByVal Optional NUMERO_RECEPTION_CHAMBRE As String = "", ByVal Optional DIRECTION As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `agence` (`NOM_AGENCE`,`CODE_AGENCE`, `FAX`, `EMAIL`, `TELEPHONE`, `VILLE`, `BOITE_POSTALE`, `PAYS`, `RUE`, 
        `CATEGORIE_HOTEL`, `WHATSAPP_1`, `WHATSAPP_2`, `WHATSAPP_3`, `WHATSAPP_4`, `WHATSAPP_5`, `WHATSAPP_6`, `WHATSAPP_7`, `GERER_STOCK`,`CLOTURE_MULTIPLE`,
        `CHEMIN_SAUVEGARDE_AUTO`, `TARIFICATION_DYNAMIQUE`, `SESSION_UNIQUE`, `EMAIL_1`, `EMAIL_2`, `EMAIL_3`, `EMAIL_4`, `EMAIL_5`, `EMAIL_6`, `EMAIL_7`,
        `MESSAGE_WHATSAPP`, `LANGUE`, `PRIX_BAR_RESTAU_MODIFIABLE`, `PAYER_AVANT_ENCODAGE`, `BLOQUER_PRIX_HEBERGEMENT`,`CLUB_ELITE`, `PRINT_B7`,`MENSUALITE`, `NUMERO_RECEPTION`,
        `NUMERO_RECEPTION_CHAMBRE`, `MONTANT_NAVETTE`, `DIRECTION`) 
        VALUES (@NOM_AGENCE, @CODE_AGENCE, @FAX, @EMAIL, @TELEPHONE, @VILLE, @BOITE_POSTALE, @PAYS, @RUE, @CATEGORIE_HOTEL , @WHATSAPP_1, @WHATSAPP_2, @WHATSAPP_3,
        @WHATSAPP_4, @WHATSAPP_5, @WHATSAPP_6, @WHATSAPP_7, @GERER_STOCK, @CLOTURE_MULTIPLE, @CHEMIN_SAUVEGARDE_AUTO, @TARIFICATION_DYNAMIQUE, @SESSION_UNIQUE, @EMAIL_1, 
        @EMAIL_2, @EMAIL_3, @EMAIL_4, @EMAIL_5, @EMAIL_6, @EMAIL_7, @MESSAGE_WHATSAPP, @LANGUE, @PRIX_BAR_RESTAU_MODIFIABLE, @PAYER_AVANT_ENCODAGE, 
        @BLOQUER_PRIX_HEBERGEMENT, @CLUB_ELITE, @PRINT_B7, @MENSUALITE, @NUMERO_RECEPTION, @NUMERO_RECEPTION_CHAMBRE, @MONTANT_NAVETTE, @DIRECTION)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@NOM_AGENCE", MySqlDbType.VarChar).Value = NOM_AGENCE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@FAX", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@TELEPHONE", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@VILLE", MySqlDbType.VarChar).Value = VILLE
        command.Parameters.Add("@BOITE_POSTALE", MySqlDbType.VarChar).Value = BOITE_POSTALE
        command.Parameters.Add("@PAYS", MySqlDbType.VarChar).Value = PAYS
        command.Parameters.Add("@RUE", MySqlDbType.VarChar).Value = RUE
        command.Parameters.Add("@CATEGORIE_HOTEL", MySqlDbType.VarChar).Value = CATEGORIE_HOTEL
        command.Parameters.Add("@WHATSAPP_1", MySqlDbType.VarChar).Value = WHATSAPP_1
        command.Parameters.Add("@WHATSAPP_2", MySqlDbType.VarChar).Value = WHATSAPP_2
        command.Parameters.Add("@WHATSAPP_3", MySqlDbType.VarChar).Value = WHATSAPP_3
        command.Parameters.Add("@WHATSAPP_4", MySqlDbType.VarChar).Value = WHATSAPP_4
        command.Parameters.Add("@WHATSAPP_5", MySqlDbType.VarChar).Value = WHATSAPP_5
        command.Parameters.Add("@WHATSAPP_7", MySqlDbType.VarChar).Value = WHATSAPP_7
        command.Parameters.Add("@WHATSAPP_6", MySqlDbType.VarChar).Value = WHATSAPP_6

        command.Parameters.Add("@EMAIL_1", MySqlDbType.VarChar).Value = EMAIL_1
        command.Parameters.Add("@EMAIL_2", MySqlDbType.VarChar).Value = EMAIL_2
        command.Parameters.Add("@EMAIL_3", MySqlDbType.VarChar).Value = EMAIL_3
        command.Parameters.Add("@EMAIL_4", MySqlDbType.VarChar).Value = EMAIL_4
        command.Parameters.Add("@EMAIL_5", MySqlDbType.VarChar).Value = EMAIL_5
        command.Parameters.Add("@EMAIL_6", MySqlDbType.VarChar).Value = EMAIL_6
        command.Parameters.Add("@EMAIL_7", MySqlDbType.VarChar).Value = EMAIL_7

        command.Parameters.Add("@GERER_STOCK", MySqlDbType.Int64).Value = GERER_STOCK

        command.Parameters.Add("@CLOTURE_MULTIPLE", MySqlDbType.Int64).Value = CLOTURE_MULTIPLE
        command.Parameters.Add("@TARIFICATION_DYNAMIQUE", MySqlDbType.Int64).Value = TARIFICATION_DYNAMIQUE
        command.Parameters.Add("@SESSION_UNIQUE", MySqlDbType.Int64).Value = SESSION_UNIQUE
        command.Parameters.Add("@SERRURES", MySqlDbType.Int64).Value = SERRURES
        command.Parameters.Add("@MESSAGE_WHATSAPP", MySqlDbType.Int64).Value = MESSAGE_WHATSAPP
        command.Parameters.Add("@CLOTURE_FACTURE", MySqlDbType.Int64).Value = CLOTURE_FACTURE

        command.Parameters.Add("@CHEMIN_SAUVEGARDE_AUTO", MySqlDbType.VarChar).Value = CHEMIN_SAUVEGARDE_AUTO

        command.Parameters.Add("@LANGUE", MySqlDbType.Int64).Value = LANGUE
        command.Parameters.Add("@PRIX_BAR_RESTAU_MODIFIABLE", MySqlDbType.Int64).Value = PRIX_BAR_RESTAU_MODIFIABLE
        command.Parameters.Add("@PAYER_AVANT_ENCODAGE", MySqlDbType.Int64).Value = PAYER_AVANT_ENCODAGE
        command.Parameters.Add("@BLOQUER_PRIX_HEBERGEMENT", MySqlDbType.Int64).Value = BLOQUER_PRIX_HEBERGEMENT
        command.Parameters.Add("@CLUB_ELITE", MySqlDbType.Int64).Value = CLUB_ELITE
        command.Parameters.Add("@PRINT_B7", MySqlDbType.Int64).Value = PRINT_B7
        command.Parameters.Add("@MENSUALITE", MySqlDbType.Int64).Value = MENSUALITE

        command.Parameters.Add("@NUMERO_RECEPTION_CHAMBRE", MySqlDbType.VarChar).Value = NUMERO_RECEPTION_CHAMBRE
        command.Parameters.Add("@NUMERO_RECEPTION", MySqlDbType.VarChar).Value = NUMERO_RECEPTION

        command.Parameters.Add("@MONTANT_NAVETTE", MySqlDbType.Double).Value = MONTANT_NAVETTE
        command.Parameters.Add("@DIRECTION", MySqlDbType.String).Value = DIRECTION

        'Opening the connection
        ''connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

    'Create a function to check if the agency already exists
    Public Function AgencyExists(ByVal CODE_AGENCE As String, ByVal NOM_AGENCE As String) As Boolean

        Dim existQuery As String = "SELECT * From agence WHERE CODE_AGENCE=@CODE_AGENCE OR NOM_AGENCE= @NOM_AGENCE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@NOM_AGENCE", MySqlDbType.VarChar).Value = NOM_AGENCE

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

    'create a function to update the selected agency
    Public Function UpdateCompany(ByVal NOM_AGENCE As String, ByVal CODE_AGENCE As String, ByVal FAX As String, ByVal EMAIL As String, ByVal TELEPHONE As String,
                                  ByVal VILLE As String, ByVal BOITE_POSTALE As String, ByVal PAYS As String, ByVal RUE As String, ByVal CATEGORIE_HOTEL As String,
                                  ByVal WHATSAPP_1 As String, ByVal WHATSAPP_2 As String, ByVal WHATSAPP_3 As String, ByVal WHATSAPP_4 As String,
                                  ByVal WHATSAPP_5 As String, ByVal WHATSAPP_6 As String, ByVal WHATSAPP_7 As String, ByVal EMAIL_1 As String, ByVal EMAIL_2 As String,
                                  ByVal EMAIL_3 As String, ByVal EMAIL_4 As String, ByVal EMAIL_5 As String, ByVal EMAIL_6 As String, ByVal EMAIL_7 As String,
                                  ByVal GERER_STOCK As Integer, Optional CLOTURE_MULTIPLE As Integer = 0, Optional ByVal CHEMIN_SAUVEGARDE_AUTO As String = "",
                                  Optional ByVal TARIFICATION_DYNAMIQUE As Integer = 0, Optional ByVal SESSION_UNIQUE As Integer = 0,
                                  Optional ByVal SERRURES As Integer = 0, Optional ByVal MESSAGE_WHATSAPP As Integer = 0, ByVal Optional CLOTURE_FACTURE As Integer = 0,
                                  ByVal Optional LANGUE As Integer = 1, ByVal Optional PRIX_BAR_RESTAU_MODIFIABLE As Integer = 1, ByVal Optional PAYER_AVANT_ENCODAGE As Integer = 0,
                                  ByVal Optional BLOQUER_PRIX_HEBERGEMENT As Integer = 0, ByVal Optional CLUB_ELITE As Integer = 0,
                                  ByVal Optional PRINT_B7 As Integer = 0, ByVal Optional MENSUALITE As Integer = 0, ByVal Optional MONTANT_NAVETTE As Double = 0,
                                  ByVal Optional NUMERO_RECEPTION As String = "", ByVal Optional NUMERO_RECEPTION_CHAMBRE As String = "", ByVal Optional DIRECTION As String = "") As Boolean

        Dim updateQuery As String = "UPDATE `agence` SET NOM_AGENCE=@NOM_AGENCE, CODE_AGENCE=@CODE_AGENCE, FAX=@FAX, EMAIL=@EMAIL, TELEPHONE=@TELEPHONE,
            VILLE=@VILLE, BOITE_POSTALE=@BOITE_POSTALE, PAYS=@PAYS, RUE=@RUE, CATEGORIE_HOTEL=@CATEGORIE_HOTEL, RUE=@RUE, CATEGORIE_HOTEL=@CATEGORIE_HOTEL,
            WHATSAPP_1=@WHATSAPP_1 ,WHATSAPP_2=@WHATSAPP_2 , WHATSAPP_3=@WHATSAPP_3 ,WHATSAPP_4=@WHATSAPP_4, WHATSAPP_5=@WHATSAPP_5 ,WHATSAPP_6=@WHATSAPP_6, 
            WHATSAPP_7=@WHATSAPP_7, EMAIL_1=@EMAIL_1, EMAIL_2=@EMAIL_2, EMAIL_3 = @EMAIL_3, EMAIL_4=@EMAIL_4, EMAIL_5= @EMAIL_5, EMAIL_6=@EMAIL_6, 
            EMAIL_7= @EMAIL_7, CLOTURE_MULTIPLE=@CLOTURE_MULTIPLE, GERER_STOCK=@GERER_STOCK, CHEMIN_SAUVEGARDE_AUTO=@CHEMIN_SAUVEGARDE_AUTO,
            TARIFICATION_DYNAMIQUE=@TARIFICATION_DYNAMIQUE, SESSION_UNIQUE=@SESSION_UNIQUE , SERRURES=@SERRURES , 
            MESSAGE_WHATSAPP =@MESSAGE_WHATSAPP, CLOTURE_FACTURE=@CLOTURE_FACTURE, LANGUE=@LANGUE, PRIX_BAR_RESTAU_MODIFIABLE=@PRIX_BAR_RESTAU_MODIFIABLE,
            PAYER_AVANT_ENCODAGE = @PAYER_AVANT_ENCODAGE, BLOQUER_PRIX_HEBERGEMENT=@BLOQUER_PRIX_HEBERGEMENT , CLUB_ELITE=@CLUB_ELITE
            ,PRINT_B7=@PRINT_B7, MENSUALITE=@MENSUALITE, NUMERO_RECEPTION =@NUMERO_RECEPTION, NUMERO_RECEPTION_CHAMBRE=@NUMERO_RECEPTION_CHAMBRE, 
            MONTANT_NAVETTE=@MONTANT_NAVETTE, DIRECTION=@DIRECTION
            WHERE CODE_AGENCE = @NUM_AGENCE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUM_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@NOM_AGENCE", MySqlDbType.VarChar).Value = NOM_AGENCE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@FAX", MySqlDbType.VarChar).Value = FAX
        command.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = EMAIL
        command.Parameters.Add("@TELEPHONE", MySqlDbType.VarChar).Value = TELEPHONE
        command.Parameters.Add("@VILLE", MySqlDbType.VarChar).Value = VILLE
        command.Parameters.Add("@BOITE_POSTALE", MySqlDbType.VarChar).Value = BOITE_POSTALE
        command.Parameters.Add("@PAYS", MySqlDbType.VarChar).Value = PAYS
        command.Parameters.Add("@RUE", MySqlDbType.VarChar).Value = RUE
        command.Parameters.Add("@CATEGORIE_HOTEL", MySqlDbType.VarChar).Value = CATEGORIE_HOTEL
        command.Parameters.Add("@GERER_STOCK", MySqlDbType.Int64).Value = GERER_STOCK

        command.Parameters.Add("@WHATSAPP_1", MySqlDbType.VarChar).Value = WHATSAPP_1
        command.Parameters.Add("@WHATSAPP_2", MySqlDbType.VarChar).Value = WHATSAPP_2
        command.Parameters.Add("@WHATSAPP_3", MySqlDbType.VarChar).Value = WHATSAPP_3
        command.Parameters.Add("@WHATSAPP_4", MySqlDbType.VarChar).Value = WHATSAPP_4
        command.Parameters.Add("@WHATSAPP_5", MySqlDbType.VarChar).Value = WHATSAPP_5
        command.Parameters.Add("@WHATSAPP_6", MySqlDbType.VarChar).Value = WHATSAPP_6
        command.Parameters.Add("@WHATSAPP_7", MySqlDbType.VarChar).Value = WHATSAPP_7

        command.Parameters.Add("@EMAIL_1", MySqlDbType.VarChar).Value = EMAIL_1
        command.Parameters.Add("@EMAIL_2", MySqlDbType.VarChar).Value = EMAIL_2
        command.Parameters.Add("@EMAIL_3", MySqlDbType.VarChar).Value = EMAIL_3
        command.Parameters.Add("@EMAIL_4", MySqlDbType.VarChar).Value = EMAIL_4
        command.Parameters.Add("@EMAIL_5", MySqlDbType.VarChar).Value = EMAIL_5
        command.Parameters.Add("@EMAIL_6", MySqlDbType.VarChar).Value = EMAIL_6
        command.Parameters.Add("@EMAIL_7", MySqlDbType.VarChar).Value = EMAIL_7

        command.Parameters.Add("@CLOTURE_MULTIPLE", MySqlDbType.Int64).Value = CLOTURE_MULTIPLE
        command.Parameters.Add("@TARIFICATION_DYNAMIQUE", MySqlDbType.Int64).Value = TARIFICATION_DYNAMIQUE
        command.Parameters.Add("@SESSION_UNIQUE", MySqlDbType.Int64).Value = SESSION_UNIQUE
        command.Parameters.Add("@SERRURES", MySqlDbType.Int64).Value = SERRURES
        command.Parameters.Add("@MESSAGE_WHATSAPP", MySqlDbType.Int64).Value = MESSAGE_WHATSAPP
        command.Parameters.Add("@CLOTURE_FACTURE", MySqlDbType.Int64).Value = CLOTURE_FACTURE

        command.Parameters.Add("@CHEMIN_SAUVEGARDE_AUTO", MySqlDbType.VarChar).Value = CHEMIN_SAUVEGARDE_AUTO

        command.Parameters.Add("@LANGUE", MySqlDbType.Int64).Value = LANGUE
        command.Parameters.Add("@PRIX_BAR_RESTAU_MODIFIABLE", MySqlDbType.Int64).Value = PRIX_BAR_RESTAU_MODIFIABLE
        command.Parameters.Add("@PAYER_AVANT_ENCODAGE", MySqlDbType.Int64).Value = PAYER_AVANT_ENCODAGE
        command.Parameters.Add("@BLOQUER_PRIX_HEBERGEMENT", MySqlDbType.Int64).Value = BLOQUER_PRIX_HEBERGEMENT
        command.Parameters.Add("@CLUB_ELITE", MySqlDbType.Int64).Value = CLUB_ELITE
        command.Parameters.Add("@PRINT_B7", MySqlDbType.Int64).Value = PRINT_B7
        command.Parameters.Add("@MENSUALITE", MySqlDbType.Int64).Value = MENSUALITE

        command.Parameters.Add("@NUMERO_RECEPTION_CHAMBRE", MySqlDbType.VarChar).Value = NUMERO_RECEPTION_CHAMBRE
        command.Parameters.Add("@NUMERO_RECEPTION", MySqlDbType.VarChar).Value = NUMERO_RECEPTION

        command.Parameters.Add("@DIRECTION", MySqlDbType.VarChar).Value = DIRECTION
        command.Parameters.Add("@MONTANT_NAVETTE", MySqlDbType.Double).Value = MONTANT_NAVETTE

        If command.ExecuteNonQuery() = 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    'Create a Function to return a company using its id
    Public Function getAgencyById(ByVal ID_AGENCE As Integer) As DataTable

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getUserQuery = "SELECT * agence WHERE ID_AGENCE=@ID_AGENCE"
        Dim Command As New MySqlCommand(getUserQuery, GlobalVariable.connect)
        Command.Parameters.Add("@ID_AGENCE", MySqlDbType.Int32).Value = ID_AGENCE
        adapter.SelectCommand = Command
        adapter.Fill(table)

        Return table

    End Function

    Public Function InsertPiedsDePage(ByVal CODE_PAPIER As String, ByVal EN_TETE_L1 As String, ByVal EN_TETE_L2 As String, ByVal EN_TETE_L3 As String, ByVal EN_TETE_L4 As String, ByVal PIEDS_L1 As String, ByVal PIEDS_L2 As String, ByVal PIEDS_L3 As String, ByVal CODE_AGENCE As String, ByVal UTILISE As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `papier_entete`(`CODE_PAPIER`,`EN_TETE_L1`, `EN_TETE_L2`, `EN_TETE_L3`, `EN_TETE_L4`, `PIEDS_L1`, `PIEDS_L2`, `PIEDS_L3`, `CODE_AGENCE`, `UTILISE`) VALUES (@CODE_PAPIER, @EN_TETE_L1, @EN_TETE_L2, @EN_TETE_L3, @EN_TETE_L4, @PIEDS_L1, @PIEDS_L2, @PIEDS_L3, @CODE_AGENCE, @UTILISE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_PAPIER", MySqlDbType.VarChar).Value = CODE_PAPIER
        command.Parameters.Add("@EN_TETE_L1", MySqlDbType.VarChar).Value = EN_TETE_L1
        command.Parameters.Add("@EN_TETE_L2", MySqlDbType.VarChar).Value = EN_TETE_L2
        command.Parameters.Add("@EN_TETE_L3", MySqlDbType.VarChar).Value = EN_TETE_L3
        command.Parameters.Add("@EN_TETE_L4", MySqlDbType.VarChar).Value = EN_TETE_L4
        command.Parameters.Add("@PIEDS_L1", MySqlDbType.VarChar).Value = PIEDS_L1
        command.Parameters.Add("@PIEDS_L2", MySqlDbType.VarChar).Value = PIEDS_L2
        command.Parameters.Add("@PIEDS_L3", MySqlDbType.VarChar).Value = PIEDS_L3
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@UTILISE", MySqlDbType.Int64).Value = UTILISE

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            ''connect.closeConnection()
            Return True
        Else
            ''connect.closeConnection()
            Return False
        End If

    End Function

End Class
