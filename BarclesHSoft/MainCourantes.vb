Imports System.IO
Imports MySql.Data.MySqlClient

Public Class MainCourantes

    'Creating an instance of database

    'Dim connect As New DataBaseManipulation()

    '----------------------- MAIN_COURANTE --------------------------------------
    'insert main courante

    Public Function TaxeDeSejourSurUnePeriode(ByVal DateDebut As Date, ByVal DateFin As Date) As Double

        Dim TAXEDESEJOUR As String = "TAXE DE SEJOUR"

        Dim getClientTaxe As String = "SELECT * FROM ligne_facture WHERE DATE_FACTURE <= '" & DateFin.ToString("yyyy-MM-dd") & "' AND DATE_FACTURE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND LIBELLE_FACTURE LIKE '%" & TAXEDESEJOUR & "%'"

        Dim command0 As New MySqlCommand(getClientTaxe, GlobalVariable.connect)

        Dim adapter0 As New MySqlDataAdapter(command0)

        Dim taxe As New DataTable()

        adapter0.Fill(taxe)

        Dim taxeDeSejours As Double = 0

        If taxe.Rows.Count > 0 Then

            For j = 0 To taxe.Rows.Count - 1
                taxeDeSejours += taxe.Rows(j)("MONTANT_HT")
            Next

        End If

        Return taxeDeSejours

    End Function

    Public Function insertMainCourante(ByVal CODE_MAIN_COURANTE As String, ByVal CODE_CLIENT As String, ByVal CODE_RESERVATION As String, ByVal CODE_CHAMBRE As String, ByVal ETAT_CHAMBRE As String, ByVal ETAT_RESERVATION As String, ByVal DATE_ETAT As Date, ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim insertQuery As String = "INSERT INTO `main_courante`(`CODE_MAIN_COURANTE`,`CODE_CLIENT`, `CODE_RESERVATION`, `CODE_CHAMBRE`, `ETAT_CHAMBRE`, `ETAT_RESERVATION`, `DATE_ETAT`, `CODE_AGENCE`, `TYPE`) VALUES (@value1, @value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = ETAT_RESERVATION
        command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = DATE_ETAT
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = TYPE

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



    Public Function updateMainCourante(ByVal CODE_MAIN_COURANTE As String, ByVal CODE_CLIENT As String, ByVal CODE_RESERVATION As String, ByVal CODE_CHAMBRE As String, ByVal ETAT_CHAMBRE As String, ByVal ETAT_RESERVATION As String, ByVal DATE_ETAT As Date, ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim updateQuery As String = "UPDATE `main_courante` SET `CODE_MAIN_COURANTE` = @value1,`CODE_CLIENT`= @value2 ,`CODE_RESERVATION`=@value3,`CODE_CHAMBRE`=@value4,`ETAT_CHAMBRE`=@value5,`ETAT_RESERVATION`=@value6,`CODE_AGENCE`=@value8,`TYPE`=@value9 WHERE CODE_MAIN_COURANTE = @CODE_MAIN_COURANTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = ETAT_RESERVATION
        'command.Parameters.Add("@value7", MySqlDbType.DateTime).Value = DATE_ETAT
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_AGENCE

        command.Parameters.Add("@CODE_MAIN_COURANTE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = TYPE

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

    '----------------------- MAIN_COURANTE_GENRALE--------------------------------------

    'insert main courante genrale
    Public Function insertMainCouranteGenerale(ByVal CODE_MAIN_COURANTE_GENERALE As String, ByVal DATE_MAIN_COURANTE As Date, ByVal CODE_CHAMBRE As String, ByVal MONTANT_ACCORDE As Double, ByVal ETAT_CHAMBRE As String, ByVal NOM_CLIENT As String, ByVal PDJ_FOOD As Double, ByVal PDJ_BOISSON As Double, ByVal DEJEUNER_FOOD As Double, ByVal DEJEUNER_BOISSON As Double, ByVal DINER_FOOD As Double, ByVal DINER_BOISSON As Double, ByVal BANQUET_FOOD As Double, ByVal BANQUET_BOISSON As Double, ByVal BAR_MATIN As Double, ByVal BAR_SOIR As Double, ByVal DIVERS As Double, ByVal TOTAL_JOUR As Double, ByVal REPORT_VEILLE As Double, ByVal TOTAL_GENERAL As Double, ByVal NUM_RESERVATION As String, ByVal DEDUCTION As Double, ByVal ENCAISSEMENT_ESPECE As Double, ByVal ENCAISSEMENT_CHEQUE As Double, ByVal ENCAISSEMENT_CARTE_CREDIT As Double, ByVal A_REPORTER As Double, ByVal OBSERVATIONS As String, ByVal TYPE_CHAMBRE As String, ByVal CODE_CLIENT As String, ByVal INDICE_FREQUENTATION As Double, ByVal INDICE_FREQUENTATION_PCT As Double, ByVal TAUX_OCCUPATION As Double, ByVal TAXE_DE_SEJOURS As Double, ByVal CLIENTS_ATTENDUS As Integer, ByVal CLIENTS_EN_CHAMBRE As Integer, ByVal CHAMBRES_DISPONIBLES As Integer, ByVal TOTAL_HORS_SERVICE As Integer, ByVal CHAMBRES_HORS_SERVICE As Integer, ByVal TOTAL_FICTIVES As Integer, ByVal CHAMBRES_FICTIVES As Integer, ByVal NOMBRE_MESSAGES As Integer, ByVal TOTAL_GRATUITES As Double, ByVal CHAMBRES_GRATUITES As Integer, ByVal TOTAL_NON_FACTUREES As Double, ByVal CHAMBRES_NON_FACTUREES As Integer, ByVal CODE_AGENCE As Integer, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim insertQuery As String = "INSERT INTO `main_courante_generale`(`CODE_MAIN_COURANTE_GENERALE`, `DATE_MAIN_COURANTE`, `CODE_CHAMBRE`, `MONTANT_ACCORDE`, `ETAT_CHAMBRE`, `NOM_CLIENT`, `PDJ_FOOD`, `PDJ_BOISSON`, `DEJEUNER_FOOD`, `DEJEUNER_BOISSON`, `DINER_FOOD`, `DINER_BOISSON`, `BANQUET_FOOD`, `BANQUET_BOISSON`, `BAR_MATIN`, `BAR_SOIR`, `DIVERS`, `TOTAL_JOUR`, `REPORT_VEILLE`, `TOTAL_GENERAL`, `NUM_RESERVATION`, `DEDUCTION`, `ENCAISSEMENT_ESPECE`, `ENCAISSEMENT_CHEQUE`, `ENCAISSEMENT_CARTE_CREDIT`, `A_REPORTER`, `OBSERVATIONS`, `TYPE_CHAMBRE`, `CODE_CLIENT`, `INDICE_FREQUENTATION`, `INDICE_FREQUENTATION_PCT`, `TAUX_OCCUPATION`, `TAUX_OCCUPATION_PCT`, `CLIENTS_ATTENDUS`, `CLIENTS_EN_CHAMBRE`, `CHAMBRES_DISPONIBLES`, `TOTAL_HORS_SERVICE`, `CHAMBRES_HORS_SERVICE`, `TOTAL_FICTIVES`, `CHAMBRES_FICTIVES`, `NOMBRE_MESSAGES`, `TOTAL_GRATUITES`, `CHAMBRES_GRATUITES`, `TOTAL_NON_FACTUREES`, `CHAMBRES_NON_FACTUREES`, `CODE_AGENCE`, `TYPE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35,@value36,@value37,@value38,@value39,@value40,@value41,@value42,@value43,@value44,@value45,@value46,@value47,@value48)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_GENERALE
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_MAIN_COURANTE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NOM_CLIENT
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PDJ_FOOD
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = PDJ_BOISSON
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = DEJEUNER_FOOD
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = DEJEUNER_BOISSON
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = DINER_FOOD
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = DINER_BOISSON
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = BANQUET_FOOD
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = BANQUET_BOISSON
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = BAR_MATIN
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = BAR_SOIR
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = DIVERS
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = TOTAL_JOUR
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = REPORT_VEILLE
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = TOTAL_GENERAL
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = NUM_RESERVATION
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = DEDUCTION
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = ENCAISSEMENT_ESPECE
        command.Parameters.Add("@value25", MySqlDbType.Double).Value = ENCAISSEMENT_CHEQUE
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = ENCAISSEMENT_CARTE_CREDIT
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = A_REPORTER
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value31", MySqlDbType.Double).Value = INDICE_FREQUENTATION
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = INDICE_FREQUENTATION_PCT
        command.Parameters.Add("@value33", MySqlDbType.Double).Value = TAUX_OCCUPATION
        command.Parameters.Add("@value34", MySqlDbType.Double).Value = TAXE_DE_SEJOURS
        command.Parameters.Add("@value35", MySqlDbType.Int64).Value = CLIENTS_ATTENDUS
        command.Parameters.Add("@value36", MySqlDbType.Int64).Value = CLIENTS_EN_CHAMBRE 'NOMBRE DE PERSONNE DANS LA CHAMBRE
        command.Parameters.Add("@value37", MySqlDbType.Int64).Value = CHAMBRES_DISPONIBLES
        command.Parameters.Add("@value38", MySqlDbType.Int64).Value = TOTAL_HORS_SERVICE
        command.Parameters.Add("@value39", MySqlDbType.Int64).Value = CHAMBRES_HORS_SERVICE
        command.Parameters.Add("@value40", MySqlDbType.Int64).Value = TOTAL_FICTIVES
        command.Parameters.Add("@value41", MySqlDbType.Int64).Value = CHAMBRES_FICTIVES
        command.Parameters.Add("@value42", MySqlDbType.Int64).Value = NOMBRE_MESSAGES
        command.Parameters.Add("@value43", MySqlDbType.Double).Value = TOTAL_GRATUITES
        command.Parameters.Add("@value44", MySqlDbType.Int64).Value = CHAMBRES_GRATUITES
        command.Parameters.Add("@value45", MySqlDbType.Double).Value = TOTAL_NON_FACTUREES
        command.Parameters.Add("@value46", MySqlDbType.Int64).Value = CHAMBRES_NON_FACTUREES
        command.Parameters.Add("@value47", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value48", MySqlDbType.VarChar).Value = TYPE

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

    Public Function updateMainCouranteGenerale(ByVal CODE_MAIN_COURANTE_GENERALE As String, ByVal DATE_MAIN_COURANTE As Date, ByVal CODE_CHAMBRE As String, ByVal MONTANT_ACCORDE As Double, ByVal ETAT_CHAMBRE As String, ByVal NOM_CLIENT As String, ByVal PDJ_FOOD As Double, ByVal PDJ_BOISSON As Double, ByVal DEJEUNER_FOOD As Double, ByVal DEJEUNER_BOISSON As Double, ByVal DINER_FOOD As Double, ByVal DINER_BOISSON As Double, ByVal BANQUET_FOOD As Double, ByVal BANQUET_BOISSON As Double, ByVal BAR_MATIN As Double, ByVal BAR_SOIR As Double, ByVal DIVERS As Double, ByVal TOTAL_JOUR As Double, ByVal REPORT_VEILLE As Double, ByVal TOTAL_GENERAL As Double, ByVal NUM_RESERVATION As String, ByVal DEDUCTION As Double, ByVal ENCAISSEMENT_ESPECE As Double, ByVal ENCAISSEMENT_CHEQUE As Double, ByVal ENCAISSEMENT_CARTE_CREDIT As Double, ByVal A_REPORTER As Double, ByVal OBSERVATIONS As String, ByVal TYPE_CHAMBRE As String, ByVal CODE_CLIENT As String, ByVal INDICE_FREQUENTATION As String, ByVal INDICE_FREQUENTATION_PCT As String, ByVal TAUX_OCCUPATION As String, ByVal TAXE_DE_SEJOURS As Double, ByVal CLIENTS_ATTENDUS As String, ByVal CLIENTS_EN_CHAMBRE As String, ByVal CHAMBRES_DISPONIBLES As String, ByVal TOTAL_HORS_SERVICE As String, ByVal CHAMBRES_HORS_SERVICE As String, ByVal TOTAL_FICTIVES As String, ByVal CHAMBRES_FICTIVES As String, ByVal NOMBRE_MESSAGES As String, ByVal TOTAL_GRATUITES As String, ByVal CHAMBRES_GRATUITES As String, ByVal TOTAL_NON_FACTUREES As String, ByVal CHAMBRES_NON_FACTUREES As String, ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim updateQuery As String = "UPDATE `main_courante_generale` SET `CODE_MAIN_COURANTE_GENERALE`=@value2,`CODE_CHAMBRE`=@value4,`MONTANT_ACCORDE`=@value5,`ETAT_CHAMBRE`=@value6,`NOM_CLIENT`=@value7,`PDJ_FOOD`=@value8,`PDJ_BOISSON`=@value9,`DEJEUNER_FOOD`=@value10,`DEJEUNER_BOISSON`=@value11,`DINER_FOOD`=@value12,`DINER_BOISSON`=@value13,`BANQUET_FOOD`=@value14,`BANQUET_BOISSON`=@value15,`BAR_MATIN`=@value16,`BAR_SOIR`=@value17,`DIVERS`=@value18,`TOTAL_JOUR`=@value19,`REPORT_VEILLE`=@value20,`TOTAL_GENERAL`=@value21,`NUM_RESERVATION`=@value22,`DEDUCTION`=@value23,`ENCAISSEMENT_ESPECE`=@value24,`ENCAISSEMENT_CHEQUE`=@value25,`ENCAISSEMENT_CARTE_CREDIT`=@value26,`A_REPORTER`=@value27,`OBSERVATIONS`=@value28,`TYPE_CHAMBRE`=@value29,`CODE_CLIENT`=@value30,`INDICE_FREQUENTATION`=@value31,`INDICE_FREQUENTATION_PCT`=@value32,`TAUX_OCCUPATION`=@value33,`TAUX_OCCUPATION_PCT`=@value34,`CLIENTS_ATTENDUS`=@value35,`CLIENTS_EN_CHAMBRE`=@value36,`CHAMBRES_DISPONIBLES`=@value37,`TOTAL_HORS_SERVICE`=@value38,`CHAMBRES_HORS_SERVICE`=@value39,`TOTAL_FICTIVES`=@value40,`CHAMBRES_FICTIVES`=@value41,`NOMBRE_MESSAGES`=@value42,`TOTAL_GRATUITES`=@value43,`CHAMBRES_GRATUITES`=@value44,`TOTAL_NON_FACTUREES`=@value45,`CHAMBRES_NON_FACTUREES`=@value46,`CODE_AGENCE`=@value47, `TYPE`=@value48 WHERE CODE_MAIN_COURANTE_GENERALE = @CODE_MAIN_COURANTE_GENERALE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE_GENERALE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_GENERALE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_GENERALE
        'command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_MAIN_COURANTE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NOM_CLIENT
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PDJ_FOOD
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = PDJ_BOISSON
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = DEJEUNER_FOOD
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = DEJEUNER_BOISSON
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = DINER_FOOD
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = DINER_BOISSON
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = BANQUET_FOOD
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = BANQUET_BOISSON
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = BAR_MATIN
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = BAR_SOIR
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = DIVERS
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = TOTAL_JOUR
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = REPORT_VEILLE
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = TOTAL_GENERAL
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = NUM_RESERVATION
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = DEDUCTION
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = ENCAISSEMENT_ESPECE
        command.Parameters.Add("@value25", MySqlDbType.Double).Value = ENCAISSEMENT_CHEQUE
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = ENCAISSEMENT_CARTE_CREDIT
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = A_REPORTER
        command.Parameters.Add("@value28", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value29", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
        command.Parameters.Add("@value30", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value31", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION
        command.Parameters.Add("@value32", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION_PCT
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = TAUX_OCCUPATION
        command.Parameters.Add("@value34", MySqlDbType.Double).Value = TAXE_DE_SEJOURS
        command.Parameters.Add("@value35", MySqlDbType.VarChar).Value = CLIENTS_ATTENDUS
        command.Parameters.Add("@value36", MySqlDbType.VarChar).Value = CLIENTS_EN_CHAMBRE
        command.Parameters.Add("@value37", MySqlDbType.VarChar).Value = CHAMBRES_DISPONIBLES
        command.Parameters.Add("@value38", MySqlDbType.VarChar).Value = TOTAL_HORS_SERVICE
        command.Parameters.Add("@value39", MySqlDbType.VarChar).Value = CHAMBRES_HORS_SERVICE
        command.Parameters.Add("@value40", MySqlDbType.VarChar).Value = TOTAL_FICTIVES
        command.Parameters.Add("@value41", MySqlDbType.VarChar).Value = CHAMBRES_FICTIVES
        command.Parameters.Add("@value42", MySqlDbType.VarChar).Value = NOMBRE_MESSAGES
        command.Parameters.Add("@value43", MySqlDbType.VarChar).Value = TOTAL_GRATUITES
        command.Parameters.Add("@value44", MySqlDbType.VarChar).Value = CHAMBRES_GRATUITES
        command.Parameters.Add("@value45", MySqlDbType.VarChar).Value = TOTAL_NON_FACTUREES
        command.Parameters.Add("@value46", MySqlDbType.VarChar).Value = CHAMBRES_NON_FACTUREES
        command.Parameters.Add("@value47", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value48", MySqlDbType.VarChar).Value = TYPE

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

    Public Function updateMainCouranteAfterFacturation(ByVal TYPE_MAIN_COURANTE As String, ByVal CODE_MAIN_COURANTE As String, ByVal BAR_RESTAURANT As Double, ByVal SERVICES As Double, ByVal SALON_DE_BEAUTE As Double, ByVal BOUTIQE As Double, ByVal CYBERCAFE As Double, ByVal AUTRES As Double, ByVal SPORTS As Double, ByVal LOISIRS As Double, ByVal KIOSQUE_A_JOURNAUX As Double, ByVal BLANCHISSERIE As Double, Optional ByVal MONTANT_REGLEMENT As Double = 0)

        Dim updateQuery As String = ""
        Dim TABLE_NAME As String = ""
        Dim FIELD_NAME As String = ""

        'TOTAL_RECETE = TOTAL_RECETTE + @value55 + @value56 + @value57 + @value58 + @value59 + @SPORTS + @LOISIRS + @KIOSQUE_A_JOURNAUX + @BLANCHISSERIE

        If TYPE_MAIN_COURANTE = "journaliere" Then

            TABLE_NAME = "main_courante_journaliere"
            FIELD_NAME = "CODE_MAIN_COURANTE_JOURNALIERE"

            updateQuery = "UPDATE `main_courante_journaliere` SET `BAR_RESTAURANT`=BAR_RESTAURANT + @value54,`SERVICES`=SERVICES + @value55, `SALON_DE_BEAUTE`= SALON_DE_BEAUTE + @value56,`BOUTIQE`=BOUTIQE + @value57, `CYBERCAFE`= CYBERCAFE + @value58, `AUTRES`=AUTRES + @value59, SPORTS= SPORTS + @SPORTS, LOISIRS=LOISIRS+@LOISIRS, KIOSQUE_A_JOURNAUX=KIOSQUE_A_JOURNAUX + @KIOSQUE_A_JOURNAUX, BLANCHISSERIE= BLANCHISSERIE + @BLANCHISSERIE, TOTAL_JOUR = PDJ + DEJEUNER + DINER + CAFE + CAVE + DIVERS + SERVICES + SALON_DE_BEAUTE + BOUTIQE + CYBERCAFE + AUTRES + SPORTS + LOISIRS + KIOSQUE_A_JOURNAUX + BLANCHISSERIE + MONTANT_ACCORDE + TAUX_OCCUPATION_PCT, TOTAL_GENERAL = TOTAL_JOUR + REPORT_VEILLE, A_REPORTER = TOTAL_GENERAL - ENCAISSEMENT_ESPECE - ENCAISSEMENT_CHEQUE - ENCAISSEMENT_CARTE_CREDIT - TELE - TOTAL_GRATUITES WHERE CODE_MAIN_COURANTE_JOURNALIERE=@CODE_MAIN_COURANTE"

        End If

        If TYPE_MAIN_COURANTE = "generale" Then

            'TABLE_NAME = "main_courante_generale"
            'FIELD_NAME = "CODE_MAIN_COURANTE_GENERALE"

            'updateQuery = "UPDATE `main_courante_generale` SET `BAR_RESTAURANT`=BAR_RESTAURANT + @value54,`SERVICES`=SERVICES + @value55, `SALON_DE_BEAUTE`= SALON_DE_BEAUTE + @value56,`BOUTIQE`=BOUTIQE + @value57, `CYBERCAFE`= CYBERCAFE + @value58, `AUTRES`=AUTRES + @value59, SPORTS= SPORTS + @SPORTS, LOISIRS=LOISIRS+@LOISIRS, KIOSQUE_A_JOURNAUX=KIOSQUE_A_JOURNAUX + @KIOSQUE_A_JOURNAUX, BLANCHISSERIE=BLANCHISSERIE + @BLANCHISSERIE, TOTAL_JOUR = PDJ + DEJEUNER + DINER + CAFE + CAVE + DIVERS + SERVICES + SALON_DE_BEAUTE + BOUTIQE + CYBERCAFE + AUTRES + SPORTS + LOISIRS + KIOSQUE_A_JOURNAUX + BLANCHISSERIE + MONTANT_ACCORDE, TOTAL_GENERAL = TOTAL_JOUR + REPORT_VEILLE, A_REPORTER = TOTAL_GENERAL - ENCAISSEMENT_ESPECE - ENCAISSEMENT_CHEQUE - ENCAISSEMENT_CARTE_CREDIT - TELE WHERE CODE_MAIN_COURANTE_GENERALE=@CODE_MAIN_COURANTE"

        End If

        If TYPE_MAIN_COURANTE = "main_courante_autres" Then

            TABLE_NAME = "main_courante_autres"
            FIELD_NAME = "CODE_MAIN_COURANTE_JOURNALIERE"

            'updateQuery = "UPDATE `main_courante_autres` SET `BAR_RESTAURANT`=BAR_RESTAURANT + @value54,`SERVICES`=SERVICES + @value55, `SALON_DE_BEAUTE`= SALON_DE_BEAUTE + @value56,`BOUTIQE`=BOUTIQE + @value57, `CYBERCAFE`= CYBERCAFE + @value58, `AUTRES`=AUTRES + @value59, SPORTS= SPORTS +  @SPORTS, LOISIRS=LOISIRS+@LOISIRS, KIOSQUE_A_JOURNAUX=KIOSQUE_A_JOURNAUX + @KIOSQUE_A_JOURNAUX, BLANCHISSERIE=BLANCHISSERIE + @BLANCHISSERIE, TOTAL_JOUR = BAR_RESTAURANT + SERVICES + SALON_DE_BEAUTE + BOUTIQE + CYBERCAFE + AUTRES + SPORTS + LOISIRS + KIOSQUE_A_JOURNAUX + BLANCHISSERIE + MONTANT_ACCORDE, TOTAL_GENERAL = TOTAL_JOUR + REPORT_VEILLE, A_REPORTER= TOTAL_GENERAL - @MONTANT_REGLEMENT WHERE CODE_MAIN_COURANTE_JOURNALIERE=@CODE_MAIN_COURANTE"

            updateQuery = "UPDATE `main_courante_autres` SET `BAR_RESTAURANT`=BAR_RESTAURANT + @value54,`SERVICES`=SERVICES + @value55, 
            `SALON_DE_BEAUTE`= SALON_DE_BEAUTE + @value56,`BOUTIQE`=BOUTIQE + @value57, `CYBERCAFE`= CYBERCAFE + @value58, `AUTRES`=AUTRES + @value59, 
            SPORTS= SPORTS +  @SPORTS, LOISIRS=LOISIRS+@LOISIRS, KIOSQUE_A_JOURNAUX=KIOSQUE_A_JOURNAUX + @KIOSQUE_A_JOURNAUX, 
            BLANCHISSERIE=BLANCHISSERIE + @BLANCHISSERIE,
            TOTAL_JOUR = PDJ + DEJEUNER + DINER + CAFE + CAVE + DIVERS + SERVICES + SALON_DE_BEAUTE + BOUTIQE + CYBERCAFE + AUTRES + SPORTS + LOISIRS + KIOSQUE_A_JOURNAUX + BLANCHISSERIE + MONTANT_ACCORDE,
            TOTAL_GENERAL = TOTAL_JOUR + REPORT_VEILLE, 
            A_REPORTER = TOTAL_GENERAL - ENCAISSEMENT_ESPECE - ENCAISSEMENT_CHEQUE - ENCAISSEMENT_CARTE_CREDIT - TELE - TOTAL_GRATUITES 
            WHERE CODE_MAIN_COURANTE_JOURNALIERE=@CODE_MAIN_COURANTE"

        End If

        Dim infoMainCourante As DataTable = Functions.getElementByCode(CODE_MAIN_COURANTE, TABLE_NAME, FIELD_NAME)

        If infoMainCourante.Rows.Count > 0 Then

            'MISE A JOURS DES ENCAISSEMENTS DU JOURS DE LA MAIN COURANTE

            Dim updateQueryEncaissement As String = "UPDATE " & TABLE_NAME & " SET ENCAISSEMENT_ESPECE = ENCAISSEMENT_ESPECE + @MONTANT_REGLEMENT WHERE " & FIELD_NAME & "=@CODE_MAIN_COURANTE"
            Dim commandEncaissement As New MySqlCommand(updateQueryEncaissement, GlobalVariable.connect)

            commandEncaissement.Parameters.Add("@MONTANT_REGLEMENT", MySqlDbType.Double).Value = MONTANT_REGLEMENT
            commandEncaissement.Parameters.Add("@CODE_MAIN_COURANTE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE

            commandEncaissement.ExecuteNonQuery()

        End If

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE

        command.Parameters.Add("@value54", MySqlDbType.Double).Value = BAR_RESTAURANT
        command.Parameters.Add("@value55", MySqlDbType.Double).Value = SERVICES
        command.Parameters.Add("@value56", MySqlDbType.Double).Value = SALON_DE_BEAUTE
        command.Parameters.Add("@value57", MySqlDbType.Double).Value = BOUTIQE
        command.Parameters.Add("@value58", MySqlDbType.Double).Value = CYBERCAFE
        command.Parameters.Add("@value59", MySqlDbType.Double).Value = AUTRES

        command.Parameters.Add("@SPORTS", MySqlDbType.Double).Value = SPORTS
        command.Parameters.Add("@LOISIRS", MySqlDbType.Double).Value = LOISIRS
        command.Parameters.Add("@KIOSQUE_A_JOURNAUX", MySqlDbType.Double).Value = KIOSQUE_A_JOURNAUX
        command.Parameters.Add("@BLANCHISSERIE", MySqlDbType.Double).Value = BLANCHISSERIE

        command.Parameters.Add("@MONTANT_REGLEMENT", MySqlDbType.Double).Value = MONTANT_REGLEMENT

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

    '---------------------------------- MAIN_COURANTE_AUTRES------------------------------------

    'insert main courante journaliere

    Public Sub updateMontantAReporter(ByVal CODE_MAIN_COURANT As String, ByVal TABLE_NAME As String, ByVal CODE_FIELD_NAME As String, ByVal MONTANT_REGLEMENT As Double)

        Dim updateQuery As String = "UPDATE " & TABLE_NAME & " SET A_REPORTER = TOTAL_GENERAL - @MONTANT_REGLEMENT WHERE " & CODE_FIELD_NAME & "=@CODE_MAIN_COURANTE"
        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@MONTANT_REGLEMENT", MySqlDbType.Double).Value = MONTANT_REGLEMENT
        command.Parameters.Add("@CODE_MAIN_COURANTE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANT

        command.ExecuteNonQuery()

    End Sub

    Public Function insertMainCouranteAutres(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal DATE_MAIN_COURANTE As Date, ByVal CODE_CHAMBRE As String, ByVal MONTANT_ACCORDE As Double, ByVal ETAT_CHAMBRE As String, ByVal NOM_CLIENT As String, ByVal PDJ As Double, ByVal DEJEUNER As Double, ByVal DINER As Double, ByVal CAFE As Double, ByVal BAR As Double, ByVal CAVE As Double, ByVal AUTRE As Double, ByVal SOUS_TOTAL1 As Double, ByVal LOCATION As Double, ByVal TELE As Double, ByVal FAX As Double, ByVal LINGE As Double, ByVal DIVERS As Double, ByVal SOUS_TOTAL2 As Double, ByVal TOTAL_JOUR As Double, ByVal REPORT_VEILLE As Double, ByVal TOTAL_GENERAL As Double, ByVal NUM_RESERVATION As String, ByVal DEDUCTION As Double, ByVal ENCAISSEMENT_ESPECE As Double, ByVal ENCAISSEMENT_CHEQUE As Double, ByVal ENCAISSEMENT_CARTE_CREDIT As Double, ByVal DEBITEUR As Double, ByVal ARRHES As Double, ByVal A_REPORTER As Double, ByVal OBSERVATIONS As String, ByVal TYPE_CHAMBRE As String, ByVal CODE_CLIENT As String, ByVal INDICE_FREQUENTATION As String, ByVal INDICE_FREQUENTATION_PCT As String, ByVal TAUX_OCCUPATION As String, ByVal TAXE_DE_SEJOURS As Double, ByVal CLIENTS_ATTENDUS As String, ByVal CLIENTS_EN_CHAMBRE As String, ByVal CHAMBRES_DISPONIBLES As String, ByVal TOTAL_HORS_SERVICE As String, ByVal CHAMBRES_HORS_SERVICE As String, ByVal TOTAL_FICTIVES As String, ByVal CHAMBRES_FICTIVES As String, ByVal NOMBRE_MESSAGES As String, ByVal TOTAL_GRATUITES As Double, ByVal CHAMBRES_GRATUITES As String, ByVal TOTAL_NON_FACTUREES As String, ByVal CHAMBRES_NON_FACTUREES As Double, ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim insertQuery As String = "INSERT INTO `main_courante_autres`(CODE_MAIN_COURANTE_JOURNALIERE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT, PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, LOCATION, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION, ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE, TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35,@value36,@value37,@value38,@value39,@value40,@value41,@value42,@value43,@value44,@value45,@value46,@value47,@value48,@value49,@value50,@value51,@value52,@value53)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_MAIN_COURANTE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value6", MySqlDbType.Int64).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NOM_CLIENT
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PDJ
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = DEJEUNER
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = DINER
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = CAFE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = BAR
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = CAVE
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = AUTRE
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = SOUS_TOTAL1
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = LOCATION
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = TELE
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = FAX
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = LINGE
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = DIVERS
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = SOUS_TOTAL2
        command.Parameters.Add("@value22", MySqlDbType.Double).Value = TOTAL_JOUR
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = REPORT_VEILLE
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = TOTAL_GENERAL
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = NUM_RESERVATION
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = DEDUCTION
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = ENCAISSEMENT_ESPECE
        command.Parameters.Add("@value28", MySqlDbType.Double).Value = ENCAISSEMENT_CHEQUE
        command.Parameters.Add("@value29", MySqlDbType.Double).Value = ENCAISSEMENT_CARTE_CREDIT
        command.Parameters.Add("@value30", MySqlDbType.Double).Value = DEBITEUR
        command.Parameters.Add("@value31", MySqlDbType.Double).Value = ARRHES
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = A_REPORTER
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
        command.Parameters.Add("@value35", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value36", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION
        command.Parameters.Add("@value37", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION_PCT
        command.Parameters.Add("@value38", MySqlDbType.VarChar).Value = TAUX_OCCUPATION
        command.Parameters.Add("@value39", MySqlDbType.Double).Value = TAXE_DE_SEJOURS
        command.Parameters.Add("@value40", MySqlDbType.VarChar).Value = CLIENTS_ATTENDUS
        command.Parameters.Add("@value41", MySqlDbType.VarChar).Value = CLIENTS_EN_CHAMBRE
        command.Parameters.Add("@value42", MySqlDbType.VarChar).Value = CHAMBRES_DISPONIBLES
        command.Parameters.Add("@value43", MySqlDbType.VarChar).Value = TOTAL_HORS_SERVICE
        command.Parameters.Add("@value44", MySqlDbType.VarChar).Value = CHAMBRES_HORS_SERVICE
        command.Parameters.Add("@value45", MySqlDbType.VarChar).Value = TOTAL_FICTIVES
        command.Parameters.Add("@value46", MySqlDbType.VarChar).Value = CHAMBRES_FICTIVES
        command.Parameters.Add("@value47", MySqlDbType.VarChar).Value = NOMBRE_MESSAGES
        command.Parameters.Add("@value48", MySqlDbType.Double).Value = TOTAL_GRATUITES
        command.Parameters.Add("@value49", MySqlDbType.VarChar).Value = CHAMBRES_GRATUITES
        command.Parameters.Add("@value50", MySqlDbType.VarChar).Value = TOTAL_NON_FACTUREES
        command.Parameters.Add("@value51", MySqlDbType.Double).Value = CHAMBRES_NON_FACTUREES
        command.Parameters.Add("@value52", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value53", MySqlDbType.VarChar).Value = TYPE

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
    '-------------------------------------------------------------------------------------------

    '------------------------------------- MAIN_COURANTE_JOURNALIERE ---------------------------

    'insert main courante journaliere

    Public Function insertMainCouranteJournaliere(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal DATE_MAIN_COURANTE As Date, ByVal CODE_CHAMBRE As String,
                                                  ByVal MONTANT_ACCORDE As Double, ByVal ETAT_CHAMBRE As String, ByVal NOM_CLIENT As String, ByVal PDJ As Double,
                                                  ByVal DEJEUNER As Double, ByVal DINER As Double, ByVal CAFE As Double, ByVal BAR As Double, ByVal CAVE As Double,
                                                  ByVal AUTRE As Double, ByVal SOUS_TOTAL1 As Double, ByVal LOCATION As Double, ByVal TELE As Double, ByVal FAX As Double,
                                                  ByVal LINGE As Double, ByVal DIVERS As Double, ByVal SOUS_TOTAL2 As Double, ByVal TOTAL_JOUR As Double,
                                                  ByVal REPORT_VEILLE As Double, ByVal TOTAL_GENERAL As Double, ByVal NUM_RESERVATION As String, ByVal DEDUCTION As Double,
                                                  ByVal ENCAISSEMENT_ESPECE As Double, ByVal ENCAISSEMENT_CHEQUE As Double, ByVal ENCAISSEMENT_CARTE_CREDIT As Double,
                                                  ByVal DEBITEUR As Double, ByVal ARRHES As Double, ByVal A_REPORTER As Double, ByVal OBSERVATIONS As String,
                                                  ByVal TYPE_CHAMBRE As String, ByVal CODE_CLIENT As String, ByVal INDICE_FREQUENTATION As String,
                                                  ByVal INDICE_FREQUENTATION_PCT As String, ByVal TAUX_OCCUPATION As String, ByVal TAXE_DE_SEJOURS As Double,
                                                  ByVal CLIENTS_ATTENDUS As String, ByVal CLIENTS_EN_CHAMBRE As String, ByVal CHAMBRES_DISPONIBLES As String,
                                                  ByVal TOTAL_HORS_SERVICE As String, ByVal CHAMBRES_HORS_SERVICE As String, ByVal TOTAL_FICTIVES As String,
                                                  ByVal CHAMBRES_FICTIVES As String, ByVal NOMBRE_MESSAGES As String, ByVal TOTAL_GRATUITES As Double,
                                                  ByVal CHAMBRES_GRATUITES As String, ByVal TOTAL_NON_FACTUREES As String, ByVal CHAMBRES_NON_FACTUREES As Double,
                                                  ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        If Trim(CODE_CHAMBRE).Equals("") Then
            CODE_CHAMBRE = "-"
        End If

        Dim insertQuery As String = "INSERT INTO `main_courante_journaliere`(CODE_MAIN_COURANTE_JOURNALIERE, DATE_MAIN_COURANTE, CODE_CHAMBRE, MONTANT_ACCORDE, ETAT_CHAMBRE, NOM_CLIENT,
        PDJ, DEJEUNER, DINER, CAFE, BAR, CAVE, AUTRE, SOUS_TOTAL1, LOCATION, TELE, FAX, LINGE, DIVERS, SOUS_TOTAL2, TOTAL_JOUR, REPORT_VEILLE, TOTAL_GENERAL, NUM_RESERVATION, DEDUCTION,
        ENCAISSEMENT_ESPECE, ENCAISSEMENT_CHEQUE, ENCAISSEMENT_CARTE_CREDIT, DEBITEUR, ARRHES, A_REPORTER, OBSERVATIONS, TYPE_CHAMBRE, CODE_CLIENT, INDICE_FREQUENTATION, 
        INDICE_FREQUENTATION_PCT, TAUX_OCCUPATION, TAUX_OCCUPATION_PCT, CLIENTS_ATTENDUS, CLIENTS_EN_CHAMBRE, CHAMBRES_DISPONIBLES, TOTAL_HORS_SERVICE, CHAMBRES_HORS_SERVICE,
        TOTAL_FICTIVES, CHAMBRES_FICTIVES, NOMBRE_MESSAGES, TOTAL_GRATUITES, CHAMBRES_GRATUITES, TOTAL_NON_FACTUREES, CHAMBRES_NON_FACTUREES, CODE_AGENCE, TYPE) 
        VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,
        @value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35,@value36,@value37,@value38,
        @value39,@value40,@value41,@value42,@value43,@value44,@value45,@value46,@value47,@value48,@value49,@value50,@value51,@value52,@value53)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_MAIN_COURANTE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NOM_CLIENT
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PDJ
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = DEJEUNER
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = DINER
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = CAFE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = BAR
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = CAVE
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = AUTRE
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = SOUS_TOTAL1
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = LOCATION
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = TELE
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = FAX
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = LINGE
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = DIVERS
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = SOUS_TOTAL2
        command.Parameters.Add("@value22", MySqlDbType.Double).Value = TOTAL_JOUR
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = REPORT_VEILLE
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = TOTAL_GENERAL
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = NUM_RESERVATION
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = DEDUCTION
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = ENCAISSEMENT_ESPECE
        command.Parameters.Add("@value28", MySqlDbType.Double).Value = ENCAISSEMENT_CHEQUE
        command.Parameters.Add("@value29", MySqlDbType.Double).Value = ENCAISSEMENT_CARTE_CREDIT
        command.Parameters.Add("@value30", MySqlDbType.Double).Value = DEBITEUR
        command.Parameters.Add("@value31", MySqlDbType.Double).Value = ARRHES
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = A_REPORTER
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
        command.Parameters.Add("@value35", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value36", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION
        command.Parameters.Add("@value37", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION_PCT
        command.Parameters.Add("@value38", MySqlDbType.VarChar).Value = TAUX_OCCUPATION
        command.Parameters.Add("@value39", MySqlDbType.Double).Value = TAXE_DE_SEJOURS
        command.Parameters.Add("@value40", MySqlDbType.VarChar).Value = CLIENTS_ATTENDUS
        command.Parameters.Add("@value41", MySqlDbType.VarChar).Value = CLIENTS_EN_CHAMBRE
        command.Parameters.Add("@value42", MySqlDbType.VarChar).Value = CHAMBRES_DISPONIBLES
        command.Parameters.Add("@value43", MySqlDbType.VarChar).Value = TOTAL_HORS_SERVICE
        command.Parameters.Add("@value44", MySqlDbType.VarChar).Value = CHAMBRES_HORS_SERVICE
        command.Parameters.Add("@value45", MySqlDbType.VarChar).Value = TOTAL_FICTIVES
        command.Parameters.Add("@value46", MySqlDbType.VarChar).Value = CHAMBRES_FICTIVES
        command.Parameters.Add("@value47", MySqlDbType.VarChar).Value = NOMBRE_MESSAGES
        command.Parameters.Add("@value48", MySqlDbType.Double).Value = TOTAL_GRATUITES
        command.Parameters.Add("@value49", MySqlDbType.VarChar).Value = CHAMBRES_GRATUITES
        command.Parameters.Add("@value50", MySqlDbType.VarChar).Value = TOTAL_NON_FACTUREES
        command.Parameters.Add("@value51", MySqlDbType.Double).Value = CHAMBRES_NON_FACTUREES
        command.Parameters.Add("@value52", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value53", MySqlDbType.VarChar).Value = TYPE

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

    'RESERVATION INFORMATION

    Public Function updateMainCouranteJournaliereResaInfo(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal DATE_MAIN_COURANTE As Date, ByVal CODE_CHAMBRE As String,
                                                          ByVal MONTANT_ACCORDE As Double, ByVal ETAT_CHAMBRE As String, ByVal NOM_CLIENT As String, ByVal PDJ As Double,
                                                          ByVal DEJEUNER As Double, ByVal DINER As Double, ByVal CAFE As Double, ByVal BAR As Double, ByVal CAVE As Double,
                                                          ByVal AUTRE As Double, ByVal SOUS_TOTAL1 As Double, ByVal LOCATION As Double, ByVal TELE As Double, ByVal FAX As Double,
                                                          ByVal LINGE As Double, ByVal DIVERS As Double, ByVal SOUS_TOTAL2 As Double, ByVal TOTAL_JOUR As Double,
                                                          ByVal REPORT_VEILLE As Double, ByVal TOTAL_GENERAL As Double, ByVal NUM_RESERVATION As String,
                                                          ByVal DEDUCTION As Double, ByVal ENCAISSEMENT_ESPECE As Double, ByVal ENCAISSEMENT_CHEQUE As Double,
                                                          ByVal ENCAISSEMENT_CARTE_CREDIT As Double, ByVal DEBITEUR As Double, ByVal ARRHES As Double, ByVal A_REPORTER As Double,
                                                          ByVal OBSERVATIONS As String, ByVal TYPE_CHAMBRE As String, ByVal CODE_CLIENT As String, ByVal INDICE_FREQUENTATION As String,
                                                          ByVal INDICE_FREQUENTATION_PCT As String, ByVal TAUX_OCCUPATION As String, ByVal TAXE_DE_SEJOURS As Double,
                                                          ByVal CLIENTS_ATTENDUS As String, ByVal CLIENTS_EN_CHAMBRE As String, ByVal CHAMBRES_DISPONIBLES As String,
                                                          ByVal TOTAL_HORS_SERVICE As String, ByVal CHAMBRES_HORS_SERVICE As String, ByVal TOTAL_FICTIVES As String,
                                                          ByVal CHAMBRES_FICTIVES As String, ByVal NOMBRE_MESSAGES As String, ByVal TOTAL_GRATUITES As Double,
                                                          ByVal CHAMBRES_GRATUITES As String, ByVal TOTAL_NON_FACTUREES As String, ByVal CHAMBRES_NON_FACTUREES As Double,
                                                          ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        'MATHEMATIQUEMENT LE TOTAL A REPORTER EST DONNE COMME CI-DESSOUS
        'A_REPORTER = TOTAL_GENERAL - ENCAISSEMENT_ESPECE - ENCAISSEMENT_CHEQUE - ENCAISSEMENT_CARTE_CREDIT - TELE - TOTAL_GRATUITES
        'REPORT_VEILLE = A_REPORTER : A LA CLOTURE

        'Dim updateQuery As String = "UPDATE `main_courante_journaliere` SET `CODE_MAIN_COURANTE_JOURNALIERE`=@value2,`CODE_CHAMBRE`=@value4,`MONTANT_ACCORDE`=@value5,
        '`ETAT_CHAMBRE`=@value6,`NOM_CLIENT`=@value7,`NUM_RESERVATION`=@value25,`OBSERVATIONS`=@value33,`TYPE_CHAMBRE`=@value34,`CODE_CLIENT`=@value35, `CLIENTS_ATTENDUS`=@value40, 
        '`CLIENTS_EN_CHAMBRE`=@value41,`TYPE`=@value53, TAUX_OCCUPATION_PCT=@TAXE_DE_SEJOURS, TOTAL_JOUR = PDJ + DEJEUNER + DINER + CAFE + CAVE + DIVERS + SERVICES + SALON_DE_BEAUTE + BOUTIQE + CYBERCAFE + AUTRES + 
        'SPORTS + LOISIRS + KIOSQUE_A_JOURNAUX + BLANCHISSERIE + MONTANT_ACCORDE + TAUX_OCCUPATION_PCT , TOTAL_GENERAL = TOTAL_JOUR + REPORT_VEILLE, 
        'A_REPORTER = @A_REPORTER
        'WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

        Dim updateQuery As String = "UPDATE `main_courante_journaliere` SET `CODE_MAIN_COURANTE_JOURNALIERE`=@value2,`CODE_CHAMBRE`=@value4,
        `ETAT_CHAMBRE`=@value6,`NOM_CLIENT`=@value7,`NUM_RESERVATION`=@value25,`OBSERVATIONS`=@value33,`TYPE_CHAMBRE`=@value34,`CODE_CLIENT`=@value35,
        `CLIENTS_ATTENDUS`=@value40, 
        `CLIENTS_EN_CHAMBRE`=@value41,`TYPE`=@value53, TAUX_OCCUPATION_PCT=@TAXE_DE_SEJOURS, TOTAL_JOUR = PDJ + DEJEUNER + DINER + CAFE + CAVE + DIVERS + 
        SERVICES + SALON_DE_BEAUTE + BOUTIQE + CYBERCAFE + AUTRES + SPORTS + LOISIRS + KIOSQUE_A_JOURNAUX + BLANCHISSERIE + MONTANT_ACCORDE + TAUX_OCCUPATION_PCT , 
        TOTAL_GENERAL = TOTAL_JOUR + REPORT_VEILLE, 
        A_REPORTER = @A_REPORTER
        WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        'command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_MAIN_COURANTE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NOM_CLIENT
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PDJ
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = DEJEUNER
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = DINER
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = CAFE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = BAR
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = CAVE
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = AUTRE
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = SOUS_TOTAL1
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = LOCATION
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = TELE
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = FAX
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = LINGE
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = DIVERS
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = SOUS_TOTAL2
        command.Parameters.Add("@value22", MySqlDbType.Double).Value = TOTAL_JOUR
        'command.Parameters.Add("@REPORT_VEILLE", MySqlDbType.Double).Value = REPORT_VEILLE
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = TOTAL_GENERAL
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = NUM_RESERVATION
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = DEDUCTION
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = ENCAISSEMENT_ESPECE
        command.Parameters.Add("@value28", MySqlDbType.Double).Value = ENCAISSEMENT_CHEQUE
        command.Parameters.Add("@value29", MySqlDbType.Double).Value = ENCAISSEMENT_CARTE_CREDIT
        command.Parameters.Add("@value30", MySqlDbType.Double).Value = DEBITEUR
        command.Parameters.Add("@value31", MySqlDbType.Double).Value = ARRHES
        command.Parameters.Add("@A_REPORTER", MySqlDbType.Double).Value = A_REPORTER
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
        command.Parameters.Add("@value35", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value36", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION
        command.Parameters.Add("@value37", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION_PCT
        command.Parameters.Add("@value38", MySqlDbType.VarChar).Value = TAUX_OCCUPATION
        command.Parameters.Add("@TAXE_DE_SEJOURS", MySqlDbType.Double).Value = TAXE_DE_SEJOURS
        command.Parameters.Add("@value40", MySqlDbType.VarChar).Value = CLIENTS_ATTENDUS
        command.Parameters.Add("@value41", MySqlDbType.VarChar).Value = CLIENTS_EN_CHAMBRE
        command.Parameters.Add("@value42", MySqlDbType.VarChar).Value = CHAMBRES_DISPONIBLES
        command.Parameters.Add("@value43", MySqlDbType.VarChar).Value = TOTAL_HORS_SERVICE
        command.Parameters.Add("@value44", MySqlDbType.VarChar).Value = CHAMBRES_HORS_SERVICE
        command.Parameters.Add("@value45", MySqlDbType.VarChar).Value = TOTAL_FICTIVES
        command.Parameters.Add("@value46", MySqlDbType.VarChar).Value = CHAMBRES_FICTIVES
        command.Parameters.Add("@value47", MySqlDbType.VarChar).Value = NOMBRE_MESSAGES
        command.Parameters.Add("@value48", MySqlDbType.Double).Value = TOTAL_GRATUITES
        command.Parameters.Add("@value49", MySqlDbType.VarChar).Value = CHAMBRES_GRATUITES
        command.Parameters.Add("@value50", MySqlDbType.Double).Value = TOTAL_NON_FACTUREES
        command.Parameters.Add("@value51", MySqlDbType.VarChar).Value = CHAMBRES_NON_FACTUREES
        command.Parameters.Add("@value52", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value53", MySqlDbType.VarChar).Value = TYPE

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



    Public Function updateMainCouranteJournaliere(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal DATE_MAIN_COURANTE As Date, ByVal CODE_CHAMBRE As String, ByVal MONTANT_ACCORDE As Double, ByVal ETAT_CHAMBRE As String, ByVal NOM_CLIENT As String, ByVal PDJ As Double, ByVal DEJEUNER As Double, ByVal DINER As Double, ByVal CAFE As Double, ByVal BAR As Double, ByVal CAVE As Double, ByVal AUTRE As Double, ByVal SOUS_TOTAL1 As Double, ByVal LOCATION As Double, ByVal TELE As Double, ByVal FAX As Double, ByVal LINGE As Double, ByVal DIVERS As Double, ByVal SOUS_TOTAL2 As Double, ByVal TOTAL_JOUR As Double, ByVal REPORT_VEILLE As Double, ByVal TOTAL_GENERAL As Double, ByVal NUM_RESERVATION As String, ByVal DEDUCTION As Double, ByVal ENCAISSEMENT_ESPECE As Double, ByVal ENCAISSEMENT_CHEQUE As Double, ByVal ENCAISSEMENT_CARTE_CREDIT As Double, ByVal DEBITEUR As Double, ByVal ARRHES As Double, ByVal A_REPORTER As Double, ByVal OBSERVATIONS As String, ByVal TYPE_CHAMBRE As String, ByVal CODE_CLIENT As String, ByVal INDICE_FREQUENTATION As String, ByVal INDICE_FREQUENTATION_PCT As String, ByVal TAUX_OCCUPATION As String, ByVal TAXE_DE_SEJOURS As Double, ByVal CLIENTS_ATTENDUS As String, ByVal CLIENTS_EN_CHAMBRE As String, ByVal CHAMBRES_DISPONIBLES As String, ByVal TOTAL_HORS_SERVICE As String, ByVal CHAMBRES_HORS_SERVICE As String, ByVal TOTAL_FICTIVES As String, ByVal CHAMBRES_FICTIVES As String, ByVal NOMBRE_MESSAGES As String, ByVal TOTAL_GRATUITES As Double, ByVal CHAMBRES_GRATUITES As String, ByVal TOTAL_NON_FACTUREES As Double, ByVal CHAMBRES_NON_FACTUREES As String, ByVal CODE_AGENCE As String, Optional ByVal TYPE As String = "chambre") As Boolean

        Dim updateQuery As String = "UPDATE `main_courante_journaliere` SET `CODE_MAIN_COURANTE_JOURNALIERE`=@value2,`CODE_CHAMBRE`=@value4,`MONTANT_ACCORDE`=@value5,`ETAT_CHAMBRE`=@value6,`NOM_CLIENT`=@value7,`PDJ`=@value8,`DEJEUNER`=@value9,`DINER`=@value10,`CAFE`=@value11,`BAR`=@value12,`CAVE`=@value13,`AUTRE`=@value14,`SOUS_TOTAL1`=@value15,`LOCATION`=@value16,`TELE`=@value17,`FAX`=@value18,`LINGE`=@value19,`DIVERS`=@value20,`SOUS_TOTAL2`=@value21,`TOTAL_JOUR`=@value22,`REPORT_VEILLE`=@value23,`TOTAL_GENERAL`=@value24,`NUM_RESERVATION`=@value25,`DEDUCTION`=@value26,`ENCAISSEMENT_ESPECE`=@value27,`ENCAISSEMENT_CHEQUE`=@value28,`ENCAISSEMENT_CARTE_CREDIT`=@value29,`DEBITEUR`=@value30,`ARRHES`=@value31,`A_REPORTER`=@value32,`OBSERVATIONS`=@value33,`TYPE_CHAMBRE`=@value34,`CODE_CLIENT`=@value35,`INDICE_FREQUENTATION`=@value36,`INDICE_FREQUENTATION_PCT`=@value37,`TAUX_OCCUPATION`=@value38,`TAUX_OCCUPATION_PCT`=@value39,`CLIENTS_ATTENDUS`=@value40,`CLIENTS_EN_CHAMBRE`=@value41,`CHAMBRES_DISPONIBLES`=@value42,`TOTAL_HORS_SERVICE`=@value43,`CHAMBRES_HORS_SERVICE`=@value44,`TOTAL_FICTIVES`=@value45,`CHAMBRES_FICTIVES`=@value46,`NOMBRE_MESSAGES`=@value47,`TOTAL_GRATUITES`=@value48,`CHAMBRES_GRATUITES`=@value49,`TOTAL_NON_FACTUREES`=@value50,`CHAMBRES_NON_FACTUREES`=@value51,`CODE_AGENCE`=@value52 ,`TYPE`=@value53 WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        'command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_MAIN_COURANTE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_CHAMBRE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = MONTANT_ACCORDE
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = NOM_CLIENT
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PDJ
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = DEJEUNER
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = DINER
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = CAFE
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = BAR
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = CAVE
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = AUTRE
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = SOUS_TOTAL1
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = LOCATION
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = TELE
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = FAX
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = LINGE
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = DIVERS
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = SOUS_TOTAL2
        command.Parameters.Add("@value22", MySqlDbType.Double).Value = TOTAL_JOUR
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = REPORT_VEILLE
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = TOTAL_GENERAL
        command.Parameters.Add("@value25", MySqlDbType.VarChar).Value = NUM_RESERVATION
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = DEDUCTION
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = ENCAISSEMENT_ESPECE
        command.Parameters.Add("@value28", MySqlDbType.Double).Value = ENCAISSEMENT_CHEQUE
        command.Parameters.Add("@value29", MySqlDbType.Double).Value = ENCAISSEMENT_CARTE_CREDIT
        command.Parameters.Add("@value30", MySqlDbType.Double).Value = DEBITEUR
        command.Parameters.Add("@value31", MySqlDbType.Double).Value = ARRHES
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = A_REPORTER
        command.Parameters.Add("@value33", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value34", MySqlDbType.VarChar).Value = TYPE_CHAMBRE
        command.Parameters.Add("@value35", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value36", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION
        command.Parameters.Add("@value37", MySqlDbType.VarChar).Value = INDICE_FREQUENTATION_PCT
        command.Parameters.Add("@value38", MySqlDbType.VarChar).Value = TAUX_OCCUPATION
        command.Parameters.Add("@value39", MySqlDbType.Double).Value = TAXE_DE_SEJOURS
        command.Parameters.Add("@value40", MySqlDbType.VarChar).Value = CLIENTS_ATTENDUS
        command.Parameters.Add("@value41", MySqlDbType.VarChar).Value = CLIENTS_EN_CHAMBRE
        command.Parameters.Add("@value42", MySqlDbType.VarChar).Value = CHAMBRES_DISPONIBLES
        command.Parameters.Add("@value43", MySqlDbType.VarChar).Value = TOTAL_HORS_SERVICE
        command.Parameters.Add("@value44", MySqlDbType.VarChar).Value = CHAMBRES_HORS_SERVICE
        command.Parameters.Add("@value45", MySqlDbType.VarChar).Value = TOTAL_FICTIVES
        command.Parameters.Add("@value46", MySqlDbType.VarChar).Value = CHAMBRES_FICTIVES
        command.Parameters.Add("@value47", MySqlDbType.VarChar).Value = NOMBRE_MESSAGES
        command.Parameters.Add("@value48", MySqlDbType.Double).Value = TOTAL_GRATUITES
        command.Parameters.Add("@value49", MySqlDbType.VarChar).Value = CHAMBRES_GRATUITES
        command.Parameters.Add("@value50", MySqlDbType.Double).Value = TOTAL_NON_FACTUREES
        command.Parameters.Add("@value51", MySqlDbType.VarChar).Value = CHAMBRES_NON_FACTUREES
        command.Parameters.Add("@value52", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value53", MySqlDbType.VarChar).Value = TYPE

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

    'MISE AJOURS DES MAINSCOURANTES APRES TRANSFERT DE CHARGE DU BAR RESTAURANT

    Public Function updateMainCouranteJournaliereEtAutresApresTransfert(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal TABLE As String, ByVal FIELD As String, FIELDVALUE As Double) As Boolean

        Dim updateQuery As String = "UPDATE " & TABLE & " SET " & FIELD & " = @FIELD + " & FIELD & " ,
        `TOTAL_JOUR` = PDJ + DEJEUNER + DINER + CAFE + CAVE + DIVERS + SERVICES + SALON_DE_BEAUTE + BOUTIQE + CYBERCAFE + AUTRES + SPORTS + LOISIRS + KIOSQUE_A_JOURNAUX + BLANCHISSERIE + MONTANT_ACCORDE + TAUX_OCCUPATION_PCT, BAR_RESTAURANT = PDJ + DINER + DEJEUNER + CAFE + CAVE + DIVERS , TOTAL_GENERAL = TOTAL_JOUR + REPORT_VEILLE, A_REPORTER = TOTAL_GENERAL - ENCAISSEMENT_ESPECE - ENCAISSEMENT_CHEQUE - ENCAISSEMENT_CARTE_CREDIT - TELE - TOTAL_GRATUITES WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        command.Parameters.Add("@FIELD", MySqlDbType.Double).Value = FIELDVALUE

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

    '
    'MISE AJOURS D'UN CHAMP PARTICULIER DE LA MAIN COURANTE JOURNALIERE
    Public Function updateMainCouranteJournaliereConsommationBarRestau(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal TABLE As String, ByVal FIELD As String, FIELDVALUE As Double) As Boolean

        'A_REPORTER = TOTAL_GENERAL - ENCAISSEMENT_ESPECE - ENCAISSEMENT_CHEQUE - ENCAISSEMENT_CARTE_CREDIT - TELE - TOTAL_GRATUITES

        Dim updateQuery As String = "UPDATE " & TABLE & " SET " & FIELD & " = @FIELDVALUE + " & FIELD & " ,
        TOTAL_JOUR = PDJ + DEJEUNER + DINER + CAFE + CAVE + DIVERS + SERVICES + SALON_DE_BEAUTE + BOUTIQE + CYBERCAFE + AUTRES + SPORTS + LOISIRS + KIOSQUE_A_JOURNAUX + BLANCHISSERIE + MONTANT_ACCORDE + TAUX_OCCUPATION_PCT, 
        TOTAL_GENERAL = TOTAL_JOUR + REPORT_VEILLE, A_REPORTER = A_REPORTER WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        command.Parameters.Add("@FIELDVALUE", MySqlDbType.Double).Value = FIELDVALUE

        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function updateMainCouranteJournaliereModeReglement(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal TABLE As String, ByVal FIELD As String, FIELDVALUE As Double) As Boolean

        Dim updateQuery As String = "UPDATE " & TABLE & " SET " & FIELD & " = @FIELDVALUE + " & FIELD & " , A_REPORTER = A_REPORTER - @FIELDVALUE WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        command.Parameters.Add("@FIELDVALUE", MySqlDbType.Double).Value = FIELDVALUE

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    'MISE AJOURS DE L'ARRHES POUR EQUILIBRER LE MONTANT A REPORTER LORSQUE ON A EU DES DEPOSITS
    'SUR TOUT UTILSE LORSQUE LE JOURS DE RESERVATION NE CORRESPOND PAS AU JOUR DE CHECKIN

    Public Function UpdateArrhesMainCourante(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal TABLE As String, ByVal FIELD As String, FIELDVALUE As Double) As Boolean

        Dim updateQuery As String = "UPDATE " & TABLE & " SET " & FIELD & " = @FIELDVALUE + " & FIELD & " WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        command.Parameters.Add("@FIELDVALUE", MySqlDbType.Double).Value = FIELDVALUE

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    'MISE AJOURS D'UN CHAMP PARTICULIER DE LA MAIN COURANTE JOURNALIERE
    Public Function updateMainCouranteAutresEnRetranchant(ByVal CODE_MAIN_COURANTE_JOURNALIERE As String, ByVal TABLE As String, ByVal FIELD As String, FIELDVALUE As Double) As Boolean

        'A_REPORTER = TOTAL_GENERAL - ENCAISSEMENT_ESPECE - ENCAISSEMENT_CHEQUE - ENCAISSEMENT_CARTE_CREDIT - TELE - TOTAL_GRATUITES

        Dim updateQuery As String = "UPDATE " & TABLE & " SET " & FIELD & " = @FIELDVALUE - " & FIELD & "
        WHERE CODE_MAIN_COURANTE_JOURNALIERE = @CODE_MAIN_COURANTE_JOURNALIERE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MAIN_COURANTE_JOURNALIERE", MySqlDbType.VarChar).Value = CODE_MAIN_COURANTE_JOURNALIERE
        command.Parameters.Add("@FIELDVALUE", MySqlDbType.Double).Value = FIELDVALUE

        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function


End Class
