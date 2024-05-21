Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Compte
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new entry
    Public Function insertCompte(ByVal INTITULE As String, ByVal NUMERO_COMPTE As String, ByVal CODE_CLIENT As String, ByVal TOTAL_DEBIT As Double, ByVal TOTAL_CREDIT As Double, ByVal SOLDE_COMPTE As Double, ByVal DATE_CREATION As Date, ByVal TYPE_DE_COMPTE As String, ByVal SENS_DU_SOLDE As String, ByVal PLAFONDS_DU_COMPTE As Double, ByVal ETAT_DU_COMPTE As Integer, ByVal PERSONNE_A_CONTACTER As String, ByVal CONTACT_PAIEMENT As String, ByVal ADRESSE_DE_FACTURATION As String, ByVal DELAI_DE_PAIEMENT As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `compte`(`INTITULE`, `NUMERO_COMPTE`, `CODE_CLIENT`, `TOTAL_DEBIT`, `TOTAL_CREDIT`, `SOLDE_COMPTE`, `DATE_CREATION`, `TYPE_DE_COMPTE`, `SENS_DU_SOLDE`,`PLAFONDS_DU_COMPTE`,`ETAT_DU_COMPTE`,`PERSONNE_A_CONTACTER`, `CONTACT_PAIEMENT`, `ADRESSE_DE_FACTURATION`, `DELAI_DE_PAIEMENT`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15 , @value16)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.String).Value = INTITULE
        command.Parameters.Add("@value3", MySqlDbType.String).Value = NUMERO_COMPTE
        command.Parameters.Add("@value4", MySqlDbType.String).Value = CODE_CLIENT
        command.Parameters.Add("@value5", MySqlDbType.Decimal).Value = TOTAL_DEBIT
        command.Parameters.Add("@value6", MySqlDbType.Decimal).Value = TOTAL_CREDIT
        command.Parameters.Add("@value7", MySqlDbType.Decimal).Value = SOLDE_COMPTE
        command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value9", MySqlDbType.String).Value = TYPE_DE_COMPTE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = SENS_DU_SOLDE
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = PLAFONDS_DU_COMPTE
        command.Parameters.Add("@value12", MySqlDbType.Int64).Value = ETAT_DU_COMPTE
        command.Parameters.Add("@value13", MySqlDbType.String).Value = PERSONNE_A_CONTACTER
        command.Parameters.Add("@value14", MySqlDbType.String).Value = CONTACT_PAIEMENT
        command.Parameters.Add("@value15", MySqlDbType.String).Value = ADRESSE_DE_FACTURATION

        command.Parameters.Add("@value16", MySqlDbType.Int64).Value = DELAI_DE_PAIEMENT

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

    'create a function to update the selected account
    Public Function updateCompte(ByVal INTITULE As String, ByVal NUMERO_COMPTE As String, ByVal CODE_CLIENT As String, ByVal TOTAL_DEBIT As Double, ByVal TOTAL_CREDIT As Double, ByVal SOLDE_COMPTE As Double, ByVal DATE_CREATION As Date, ByVal TYPE_DE_COMPTE As String, ByVal SENS_DU_SOLDE As String) As Boolean

        Dim updateQuery As String = "UPDATE `compte` SET `INTITULE`=@value2,`NUMERO_COMPTE`=@value3,`CODE_CLIENT`=@value4,`TOTAL_DEBIT`=@value5,`TOTAL_CREDIT`=TOTAL_CREDIT+@value6,`SOLDE_COMPTE`=TOTAL_CREDIT-TOTAL_DEBIT,`TYPE_DE_COMPTE`=@value9,`SENS_DU_SOLDE`=@value10 WHERE CODE_CLIENT=@CODE_CLIENT OR NUMERO_COMPTE=@NUMERO_COMPTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value2", MySqlDbType.String).Value = INTITULE
        command.Parameters.Add("@value3", MySqlDbType.String).Value = NUMERO_COMPTE
        command.Parameters.Add("@value4", MySqlDbType.String).Value = CODE_CLIENT
        command.Parameters.Add("@value5", MySqlDbType.Decimal).Value = TOTAL_DEBIT
        command.Parameters.Add("@value6", MySqlDbType.Decimal).Value = TOTAL_CREDIT
        'command.Parameters.Add("@value7", MySqlDbType.Decimal).Value = SOLDE_COMPTE
        ' command.Parameters.Add("@value8", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value9", MySqlDbType.String).Value = TYPE_DE_COMPTE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = SENS_DU_SOLDE

        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.VarChar).Value = NUMERO_COMPTE

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

    'create a function to update the account when saving reglement
    Public Function UpdateCompteAfterRegelement(ByVal NUMERO_COMPTE As String, ByVal CODE_CLIENT As String, ByVal TOTAL_DEBIT As Double, ByVal TOTAL_CREDIT As Double, ByVal SOLDE_COMPTE As Double, ByVal SENS_DU_SOLDE As String) As Boolean

        Dim updateQuery As String = "UPDATE `compte` SET `NUMERO_COMPTE`=@value3,`CODE_CLIENT`=@value4,`TOTAL_DEBIT`=@value5,`TOTAL_CREDIT`=TOTAL_CREDIT+@value6,`SOLDE_COMPTE`=SOLDE_COMPTE+@value7,`SENS_DU_SOLDE`=@value10 WHERE CODE_CLIENT=@CODE_CLIENT OR NUMERO_COMPTE=@NUMERO_COMPTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        command.Parameters.Add("@value3", MySqlDbType.String).Value = NUMERO_COMPTE
        command.Parameters.Add("@value4", MySqlDbType.String).Value = CODE_CLIENT
        command.Parameters.Add("@value5", MySqlDbType.Decimal).Value = TOTAL_DEBIT
        command.Parameters.Add("@value6", MySqlDbType.Decimal).Value = TOTAL_CREDIT
        command.Parameters.Add("@value7", MySqlDbType.Decimal).Value = SOLDE_COMPTE

        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = SENS_DU_SOLDE

        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.VarChar).Value = NUMERO_COMPTE

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

    'create a function to update the account when saving reglement
    Public Function updateCompteAuDebit(ByVal NUMERO_COMPTE As String, ByVal CODE_CLIENT As String, ByVal TOTAL_DEBIT As Double, ByVal SOLDE_COMPTE As Double, ByVal SENS_DU_SOLDE As String) As Boolean

        Dim updateQuery As String = "UPDATE `compte` SET `NUMERO_COMPTE`=@value3,`CODE_CLIENT`=@value4,`TOTAL_DEBIT`=TOTAL_DEBIT+@value5, `SOLDE_COMPTE`=@value7,`SENS_DU_SOLDE`=@value10 WHERE CODE_CLIENT=@CODE_CLIENT OR NUMERO_COMPTE=@NUMERO_COMPTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        command.Parameters.Add("@value3", MySqlDbType.String).Value = NUMERO_COMPTE
        command.Parameters.Add("@value4", MySqlDbType.String).Value = CODE_CLIENT

        command.Parameters.Add("@value5", MySqlDbType.Decimal).Value = TOTAL_DEBIT
        command.Parameters.Add("@value7", MySqlDbType.Decimal).Value = SOLDE_COMPTE

        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = SENS_DU_SOLDE

        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.VarChar).Value = NUMERO_COMPTE

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

    Public Function updateCompteAlaClotureDuFolio(ByVal NUMERO_COMPTE As String, ByVal CODE_CLIENT As String, ByVal TOTAL_DEBIT As Double, ByVal TOTAL_CREDIT As Double) As Boolean

        Dim updateQuery As String = "UPDATE `compte` SET `TOTAL_DEBIT`=TOTAL_DEBIT + @TOTAL_DEBIT, `TOTAL_CREDIT`=TOTAL_CREDIT + @TOTAL_CREDIT, SOLDE_COMPTE= TOTAL_CREDIT - TOTAL_DEBIT  WHERE CODE_CLIENT=@CODE_CLIENT AND NUMERO_COMPTE=@NUMERO_COMPTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT

        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.String).Value = NUMERO_COMPTE

        command.Parameters.Add("@TOTAL_DEBIT", MySqlDbType.Decimal).Value = TOTAL_DEBIT

        command.Parameters.Add("@TOTAL_CREDIT", MySqlDbType.Decimal).Value = TOTAL_CREDIT

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

    'FENETRE DE COMPARAISON VERSEMENT ET REGLEMENT CONTROLE AVANT CLOTURE DE CAISSE DU BAR RESTAURANT

    Public Function updateCompteAuDebitEtSolde(ByVal NUMERO_COMPTE As String, ByVal TOTAL_DEBIT As Double) As Boolean

        Dim updateQuery As String = "UPDATE `compte` SET `TOTAL_DEBIT`=`TOTAL_DEBIT` + @TOTAL_DEBIT, `SOLDE_COMPTE` = SOLDE_COMPTE + @DEDUCTION_DEBIT WHERE NUMERO_COMPTE=@NUMERO_COMPTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@TOTAL_DEBIT", MySqlDbType.Decimal).Value = TOTAL_DEBIT
        command.Parameters.Add("@DEDUCTION_DEBIT", MySqlDbType.Decimal).Value = TOTAL_DEBIT * -1
        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.VarChar).Value = NUMERO_COMPTE

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

    'We resgiter all the movements related to an account

    Public Function insertCompteMovement(ByVal NUM_COMPTE As String, ByVal CODE_TIERS As String, ByVal TYPE_TIERS As String, ByVal DATE_MVT As Date, ByVal LIBELLE_MVT As String, ByVal MONTANT_MVT As Double, ByVal SOLDE_AVANT_MVT As Double, ByVal TYPE_MVT As String, ByVal CODE_AGENCE As String, ByVal COMPTE_PAYMASTER As String, ByVal COMPTE_GENERAL As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `mvt_compte`(`NUM_COMPTE`, `CODE_TIERS`, `TYPE_TIERS`, `DATE_MVT`, `LIBELLE_MVT`, `MONTANT_MVT`, `SOLDE_AVANT_MVT`, `TYPE_MVT`, `CODE_AGENCE`,`COMPTE_PAYMASTER`,`COMPTE_GENRAL`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10, @value11, @value12)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.String).Value = NUM_COMPTE
        command.Parameters.Add("@value3", MySqlDbType.String).Value = CODE_TIERS
        command.Parameters.Add("@value4", MySqlDbType.String).Value = TYPE_TIERS
        command.Parameters.Add("@value5", MySqlDbType.DateTime).Value = DATE_MVT
        command.Parameters.Add("@value6", MySqlDbType.String).Value = LIBELLE_MVT
        command.Parameters.Add("@value7", MySqlDbType.Decimal).Value = MONTANT_MVT
        command.Parameters.Add("@value8", MySqlDbType.Decimal).Value = SOLDE_AVANT_MVT
        command.Parameters.Add("@value9", MySqlDbType.String).Value = TYPE_MVT
        command.Parameters.Add("@value10", MySqlDbType.String).Value = CODE_AGENCE
        command.Parameters.Add("@value11", MySqlDbType.String).Value = COMPTE_PAYMASTER
        command.Parameters.Add("@value12", MySqlDbType.String).Value = COMPTE_GENERAL

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


    Public Sub miseAjourDesInfoDuCompteUtilisateur(ByVal CODE_CLIENT As String, ByVal NUMERO_COMPTE As String, ByVal INTITULE As String, ByVal PLAFONDS_DU_COMPTE As Double, ByVal ETAT_DU_COMPTE As Integer, ByVal PERSONNE_A_CONTACTER As String, ByVal CONTACT_PAIEMENT As String, ByVal ADRESSE_DE_FACTURATION As String, ByVal DELAI_DE_PAIEMENT As Integer)

        Dim updateQuery As String = "UPDATE `compte` SET `PLAFONDS_DU_COMPTE`=@PLAFONDS_DU_COMPTE, `INTITULE` = @INTITULE, `ETAT_DU_COMPTE`=@ETAT_DU_COMPTE,`ADRESSE_DE_FACTURATION`=@ADRESSE_DE_FACTURATION, `PERSONNE_A_CONTACTER`=@PERSONNE_A_CONTACTER ,`CONTACT_PAIEMENT`=@CONTACT_PAIEMENT ,`DELAI_DE_PAIEMENT`=@DELAI_DE_PAIEMENT WHERE CODE_CLIENT=@CODE_CLIENT"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@PLAFONDS_DU_COMPTE", MySqlDbType.Double).Value = PLAFONDS_DU_COMPTE
        command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE
        command.Parameters.Add("@CODE_CLIENT", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@PERSONNE_A_CONTACTER", MySqlDbType.VarChar).Value = PERSONNE_A_CONTACTER
        command.Parameters.Add("@INTITULE", MySqlDbType.VarChar).Value = INTITULE
        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.VarChar).Value = NUMERO_COMPTE
        command.Parameters.Add("@CONTACT_PAIEMENT", MySqlDbType.VarChar).Value = CONTACT_PAIEMENT
        command.Parameters.Add("@ADRESSE_DE_FACTURATION", MySqlDbType.VarChar).Value = ADRESSE_DE_FACTURATION

        command.Parameters.Add("@DELAI_DE_PAIEMENT", MySqlDbType.Int64).Value = DELAI_DE_PAIEMENT

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        command.ExecuteNonQuery()

    End Sub

    Public Function updateCompteApresTrasnfert(ByVal NUMERO_COMPTE As String, ByVal TOTAL_DEBIT As Double, ByVal TOTAL_CREDIT As Double) As Boolean

        Dim updateQuery As String = "UPDATE `compte` SET `TOTAL_DEBIT`=TOTAL_DEBIT + @TOTAL_DEBIT, `TOTAL_CREDIT`=TOTAL_CREDIT + @TOTAL_CREDIT, SOLDE_COMPTE= TOTAL_CREDIT - TOTAL_DEBIT  WHERE NUMERO_COMPTE=@NUMERO_COMPTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)
        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.String).Value = NUMERO_COMPTE
        command.Parameters.Add("@TOTAL_DEBIT", MySqlDbType.Decimal).Value = TOTAL_DEBIT
        command.Parameters.Add("@TOTAL_CREDIT", MySqlDbType.Decimal).Value = TOTAL_CREDIT

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function insertPlanComptable(ByVal INTITULE As String, ByVal NUMERO_COMPTE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `plan_comptable`(`INTITULE`, `COMPTE`) VALUES (@value2,@value3)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.String).Value = INTITULE
        command.Parameters.Add("@value3", MySqlDbType.String).Value = NUMERO_COMPTE

        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

End Class
