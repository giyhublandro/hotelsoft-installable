Imports System.IO
Imports MySql.Data.MySqlClient

Public Class GeneralAccount

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

    Public Function Insert(ByVal INTITULE As String, ByVal NUMERO_COMPTE As String, ByVal TOTAL_DEBIT As Double, ByVal TOTAL_CREDIT As Double, ByVal SOLDE_COMPTE As Double, ByVal DATE_CREATION As Date, ByVal TYPE_DE_COMPTE As String, ByVal SENS_DU_SOLDE As String, ByVal PLAFONDS_DU_COMPTE As Double, ByVal ETAT_DU_COMPTE As Integer, ByVal PERSONNE_A_CONTACTER As String, ByVal CONTACT_PAIEMENT As String, ByVal ADRESSE_DE_FACTURATION As String, ByVal DELAI_DE_PAIEMENT As Integer) As Boolean

        Dim Inserting As String = "INSERT INTO `compte`(`INTITULE`, `NUMERO_COMPTE`, `TOTAL_DEBIT`, `TOTAL_CREDIT`, `SOLDE_COMPTE`, `DATE_CREATION`, `TYPE_DE_COMPTE`, `SENS_DU_SOLDE`,`PLAFONDS_DU_COMPTE`, `ETAT_DU_COMPTE`, `PERSONNE_A_CONTACTER`, `CONTACT_PAIEMENT`, `ADRESSE_DE_FACTURATION`,`DELAI_DE_PAIEMENT`) VALUES (@value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11, @value12, @value13, @value14, @value15)"
        Dim command As New MySqlCommand(Inserting, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = INTITULE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = NUMERO_COMPTE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = TOTAL_DEBIT
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = TOTAL_CREDIT
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = SOLDE_COMPTE
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = TYPE_DE_COMPTE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = SENS_DU_SOLDE

        command.Parameters.Add("@value10", MySqlDbType.Double).Value = PLAFONDS_DU_COMPTE
        command.Parameters.Add("@value11", MySqlDbType.Int64).Value = ETAT_DU_COMPTE
        command.Parameters.Add("@value12", MySqlDbType.String).Value = PERSONNE_A_CONTACTER
        command.Parameters.Add("@value13", MySqlDbType.String).Value = CONTACT_PAIEMENT
        command.Parameters.Add("@value14", MySqlDbType.String).Value = ADRESSE_DE_FACTURATION

        command.Parameters.Add("@value15", MySqlDbType.Int64).Value = DELAI_DE_PAIEMENT

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    Public Function InsertJournal(ByVal CODE_JOURNAL As String, ByVal LIBELLE_JOURNAL As String, ByVal DATE_CREATION As Date) As Boolean

        Dim Inserting As String = "INSERT INTO `journal`(`CODE_JOURNAL`, `LIBELLE_JOURNAL`) VALUES (@value2,@value3)"
        Dim command As New MySqlCommand(Inserting, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_JOURNAL
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_JOURNAL

        command.Parameters.Add("@value4", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail


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

    Public Function UpdateJournal(ByVal CODE_JOURNAL As String, ByVal LIBELLE_JOURNAL As String) As Boolean

        Dim Inserting As String = "UPDATE `journal` SET `CODE_JOURNAL`=@value2,`LIBELLE_JOURNAL`=@value3"
        Dim command As New MySqlCommand(Inserting, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_JOURNAL
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = LIBELLE_JOURNAL

        command.Parameters.Add("@value4", MySqlDbType.Date).Value = GlobalVariable.DateDeTravail


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
    Public Function accountExists(ByVal NUMERO_COMPTE As String, ByVal INTITULE As String) As Boolean

        Dim existQuery As String = "SELECT * From compte WHERE NUMERO_COMPTE=@NUMERO_COMPTE OR INTITULE=@INTITULE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.VarChar).Value = NUMERO_COMPTE
        command.Parameters.Add("@INTITULE", MySqlDbType.VarChar).Value = INTITULE

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

    'Create a function to check if the company already exists
    Public Function journaltExists(ByVal CODE_JOURNAL As String, ByVal LIBELLE_JOURNAL As String) As Boolean

        Dim existQuery As String = "SELECT * From journal WHERE CODE_JOURNAL=@CODE_JOURNAL OR LIBELLE_JOURNAL=@LIBELLE_JOURNAL"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_JOURNAL", MySqlDbType.VarChar).Value = CODE_JOURNAL
        command.Parameters.Add("@LIBELLE_JOURNAL", MySqlDbType.VarChar).Value = LIBELLE_JOURNAL

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

    'create a function to update the selected entry
    Public Function Update(ByVal INTITULE As String, ByVal NUMERO_COMPTE As String, ByVal TOTAL_DEBIT As Double, ByVal TOTAL_CREDIT As Double, ByVal SOLDE_COMPTE As Double, ByVal DATE_CREATION As Date, ByVal TYPE_DE_COMPTE As String, ByVal SENS_DU_SOLDE As String, ByVal PLAFONDS_DU_COMPTE As Double, ByVal ETAT_DU_COMPTE As Integer, ByVal PERSONNE_A_CONTACTER As String, ByVal CONTACT_PAIEMENT As String, ByVal ADRESSE_DE_FACTURATION As String, ByVal DELAI_DE_PAIEMENT As Integer) As Boolean
        'Dim updateQuery As String = "UPDATE `compte` SET `INTITULE`=@value2,`NUMERO_COMPTE`=@value3,`TOTAL_DEBIT`=@value4,`TOTAL_CREDIT`=@value5,`SOLDE_COMPTE`=@value6,`TYPE_DE_COMPTE`=@value8, `SENS_DU_SOLDE`=@value9, `PLAFONDS_DU_COMPTE`=@value10, `ETAT_DU_COMPTE`=@value11, `PERSONNE_A_CONTACTER`=@value12, `CONTACT_PAIEMENT`=@value13, `ADRESSE_DE_FACTURATION`=@value14, `DELAI_DE_PAIEMENT`=@value15 WHERE NUMERO_COMPTE=@NUMERO_COMPTE"
        Dim updateQuery As String = "UPDATE `compte` SET `INTITULE`=@value2,`NUMERO_COMPTE`=@value3,`TYPE_DE_COMPTE`=@value8, `SENS_DU_SOLDE`=@value9, `PLAFONDS_DU_COMPTE`=@value10, `ETAT_DU_COMPTE`=@value11, `PERSONNE_A_CONTACTER`=@value12, `CONTACT_PAIEMENT`=@value13, `ADRESSE_DE_FACTURATION`=@value14, `DELAI_DE_PAIEMENT`=@value15 WHERE NUMERO_COMPTE=@NUMERO_COMPTE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = INTITULE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = NUMERO_COMPTE
        'command.Parameters.Add("@value4", MySqlDbType.Double).Value = TOTAL_DEBIT
        'command.Parameters.Add("@value5", MySqlDbType.Double).Value = TOTAL_CREDIT
        'command.Parameters.Add("@value6", MySqlDbType.Double).Value = SOLDE_COMPTE
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = TYPE_DE_COMPTE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = SENS_DU_SOLDE

        command.Parameters.Add("@NUMERO_COMPTE", MySqlDbType.VarChar).Value = NUMERO_COMPTE

        command.Parameters.Add("@value10", MySqlDbType.Double).Value = PLAFONDS_DU_COMPTE
        command.Parameters.Add("@value11", MySqlDbType.Int64).Value = ETAT_DU_COMPTE
        command.Parameters.Add("@value12", MySqlDbType.String).Value = PERSONNE_A_CONTACTER
        command.Parameters.Add("@value13", MySqlDbType.String).Value = CONTACT_PAIEMENT
        command.Parameters.Add("@value14", MySqlDbType.String).Value = ADRESSE_DE_FACTURATION

        command.Parameters.Add("@value15", MySqlDbType.String).Value = DELAI_DE_PAIEMENT

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

    Public Function listeDesComptes() As DataTable

        'Dim existQuery As String = "SELECT NUMERO_COMPTE AS 'NUMERO DE COMPTE', INTITULE ,TYPE_DE_COMPTE AS 'TYPE DE COMPTE', CODE_CLIENT AS 'NOM DU CLIENT' , TOTAL_DEBIT AS 'TOTAL DEBIT', TOTAL_CREDIT AS 'TOTAL CREDIT', DATE_CREATION AS 'DATE DE CREATION', SENS_DU_SOLDE As 'SENS DU SOLDE' From compte WHERE CODE_AGENCE=@CODE_AGENCE ORDER BY NUMERO_COMPTE ASC"
        Dim existQuery As String = "SELECT NUMERO_COMPTE AS 'NUMERO DE COMPTE', INTITULE ,TYPE_DE_COMPTE AS 'TYPE DE COMPTE', TOTAL_DEBIT AS 'DEBIT', TOTAL_CREDIT AS 'CREDIT', SOLDE_COMPTE AS 'SOLDE', DATE_CREATION AS 'CREATION', SENS_DU_SOLDE As 'SENS DU SOLDE' From compte WHERE ETAT_DU_COMPTE = @ETAT_DU_COMPTE ORDER BY NUMERO_COMPTE ASC"

        Dim ETAT_DU_COMPTE As Integer = 1

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function totalCreditDebit(ByVal table_ As DataTable, ByVal j As Integer) As Double

        Dim amount As Double = 0

        If table_.Rows.Count > 0 Then

            For i = 0 To table_.Rows.Count - 1
                If j = 0 Then 'Reglements
                    amount += table_.Rows(i)("MONTANT_VERSE")
                ElseIf j = 1 Then 'Factures
                    amount += table_.Rows(i)("MONTANT_TTC")
                End If
            Next

        End If

        Return amount

    End Function

    Public Function listeDesComptesActifOuPas(ByVal ETAT_DU_COMPTE As Integer) As DataTable

        If ETAT_DU_COMPTE = 1 Then


            Dim existQuery_ As String = "SELECT * From compte WHERE ETAT_DU_COMPTE = @ETAT_DU_COMPTE ORDER BY NUMERO_COMPTE ASC"
            Dim command_ As New MySqlCommand(existQuery_, GlobalVariable.connect)
            command_.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE

            Dim adapter_ As New MySqlDataAdapter(command_)
            Dim table_ As New DataTable()
            adapter_.Fill(table_)

            Dim dtCredit As DataTable
            Dim dtDebit As DataTable

            Dim SOLDE_COMPTE As Double = 0
            Dim TOTAL_CREDIT As Double = 0
            Dim TOTAL_DEBIT As Double = 0

            Dim CODE_CLIENT_COMPTE_LABEL As String = ""
            Dim CODE_CLIENT_COMPTE As String = ""

            If table_.Rows.Count > 0 Then

                For i = 0 To table_.Rows.Count - 1

                    If Trim(table_.Rows(i)("CODE_CLIENT")).Equals("") Then

                        CODE_CLIENT_COMPTE_LABEL = "NUMERO_COMPTE"
                        CODE_CLIENT_COMPTE = table_.Rows(i)("NUMERO_COMPTE")

                    Else

                        CODE_CLIENT_COMPTE_LABEL = "CODE_CLIENT"
                        CODE_CLIENT_COMPTE = table_.Rows(i)("CODE_CLIENT")

                    End If

                    dtCredit = Functions.getElementByCode(CODE_CLIENT_COMPTE, "reglement", "CODE_CLIENT")
                    TOTAL_CREDIT = totalCreditDebit(dtCredit, 0)

                    dtDebit = Functions.getElementByCode(CODE_CLIENT_COMPTE, "facture", "CODE_CLIENT")
                    TOTAL_DEBIT = totalCreditDebit(dtDebit, 1)

                    SOLDE_COMPTE = TOTAL_CREDIT - TOTAL_DEBIT

                    Dim updateQuery As String = "UPDATE `compte` SET TOTAL_DEBIT = @TOTAL_DEBIT, SOLDE_COMPTE = @SOLDE_COMPTE, TOTAL_CREDIT = @TOTAL_CREDIT WHERE " & CODE_CLIENT_COMPTE_LABEL & " = @CODE_CLIENT_COMPTE"

                    Dim commandupdateQuery As New MySqlCommand(updateQuery, GlobalVariable.connect)

                    commandupdateQuery.Parameters.Add("@SOLDE_COMPTE", MySqlDbType.Double).Value = SOLDE_COMPTE
                    commandupdateQuery.Parameters.Add("@TOTAL_CREDIT", MySqlDbType.Double).Value = TOTAL_CREDIT
                    commandupdateQuery.Parameters.Add("@TOTAL_DEBIT", MySqlDbType.Double).Value = TOTAL_DEBIT
                    commandupdateQuery.Parameters.Add("@CODE_CLIENT_COMPTE", MySqlDbType.VarChar).Value = CODE_CLIENT_COMPTE

                    commandupdateQuery.ExecuteNonQuery()

                Next

            End If

        End If

        Dim existQuery As String = "SELECT NUMERO_COMPTE AS 'NUMERO DE COMPTE', INTITULE ,TYPE_DE_COMPTE AS 'TYPE DE COMPTE', TOTAL_DEBIT AS 'DEBIT', TOTAL_CREDIT AS 'CREDIT', SOLDE_COMPTE AS 'SOLDE', DATE_CREATION AS 'CREATION', SENS_DU_SOLDE As 'SENS DU SOLDE', CODE_CLIENT From compte WHERE ETAT_DU_COMPTE = @ETAT_DU_COMPTE ORDER BY NUMERO_COMPTE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function listeDesComptesActifOuPasParCritere(ByVal ETAT_DU_COMPTE As Integer, ByVal CRITERE As String, ByVal CRITERE_VALUE As String) As DataTable

        'Dim existQuery As String = "SELECT NUMERO_COMPTE AS 'NUMERO DE COMPTE', INTITULE ,TYPE_DE_COMPTE AS 'TYPE DE COMPTE', CODE_CLIENT AS 'NOM DU CLIENT' , TOTAL_DEBIT AS 'TOTAL DEBIT', TOTAL_CREDIT AS 'TOTAL CREDIT', DATE_CREATION AS 'DATE DE CREATION', SENS_DU_SOLDE As 'SENS DU SOLDE' From compte WHERE CODE_AGENCE=@CODE_AGENCE ORDER BY NUMERO_COMPTE ASC"
        Dim existQuery As String = "SELECT NUMERO_COMPTE AS 'NUMERO DE COMPTE', INTITULE ,TYPE_DE_COMPTE AS 'TYPE DE COMPTE', TOTAL_DEBIT AS 'DEBIT', TOTAL_CREDIT AS 'CREDIT', SOLDE_COMPTE AS 'SOLDE', DATE_CREATION AS 'CREATION', SENS_DU_SOLDE As 'SENS DU SOLDE', CODE_CLIENT From compte WHERE ETAT_DU_COMPTE = @ETAT_DU_COMPTE AND " & CRITERE & " LIKE '%" & CRITERE_VALUE & "%' ORDER BY NUMERO_COMPTE ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@ETAT_DU_COMPTE", MySqlDbType.Int64).Value = ETAT_DU_COMPTE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function listeDesJournaux() As DataTable

        Dim existQuery As String = "SELECT CODE_JOURNAL  AS 'CODE JOURNAL', LIBELLE_JOURNAL AS 'LIBELLE JOURNAL' From journal ORDER BY LIBELLE_JOURNAL ASC"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        'command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

End Class
