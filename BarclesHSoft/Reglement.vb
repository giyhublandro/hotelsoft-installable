Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Reglement
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new client Catgeory
    Public Function insertReglement(ByVal NUM_REGLEMENT As String, ByVal NUM_FACTURE As String, ByVal CODE_CAISSIER As String, ByVal MONTANT_VERSE As Double, ByVal DATE_REGLEMENT As Date, ByVal MODE_REGLEMENT As String, ByVal REF_REGLEMENT As String, ByVal CODE_MODE As String, ByVal IMPRIMER As String, ByVal CODE_AGENCE As String, ByVal CODE_RESERVATION As String, ByVal CODE_CLIENT As String, ByVal NUMERO_BLOC_NOTE As String, Optional ByVal MODE_REG_INFO_SUP_1 As String = "", Optional ByVal MODE_REG_INFO_SUP_2 As String = "", Optional ByVal MODE_REG_INFO_SUP_3 As String = "") As Boolean

        Dim insertQuery As String = "INSERT INTO `reglement`(`NUM_REGLEMENT`, `NUM_FACTURE`, `CODE_CAISSIER`, `MONTANT_VERSE`, `DATE_REGLEMENT`, `MODE_REGLEMENT`, `REF_REGLEMENT`, `CODE_MODE`, `IMPRIMER`, `CODE_AGENCE`, `CODE_RESERVATION`, `CODE_CLIENT`, `MODE_REG_INFO_SUP_1`, `MODE_REG_INFO_SUP_2`, `MODE_REG_INFO_SUP_3`,`NUMERO_BLOC_NOTE`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10 ,@value11 , @value12, @value13 , @value14 , @value15 , @value16)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUM_REGLEMENT", MySqlDbType.VarChar).Value = NUM_REGLEMENT
        command.Parameters.Add("@value1", MySqlDbType.String).Value = NUM_REGLEMENT
        command.Parameters.Add("@value2", MySqlDbType.String).Value = NUM_FACTURE
        command.Parameters.Add("@value3", MySqlDbType.String).Value = CODE_CAISSIER
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_VERSE
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_REGLEMENT
        command.Parameters.Add("@value6", MySqlDbType.String).Value = MODE_REGLEMENT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = REF_REGLEMENT
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_MODE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = IMPRIMER
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_CLIENT
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = MODE_REG_INFO_SUP_1
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = MODE_REG_INFO_SUP_2
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = MODE_REG_INFO_SUP_3
        command.Parameters.Add("@value16", MySqlDbType.VarChar).Value = NUMERO_BLOC_NOTE

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

    'create a function to update the selected reservation
    Public Function updateReglement(ByVal NUM_REGLEMENT As String, ByVal NUM_FACTURE As String, ByVal CODE_CAISSIER As String, ByVal MONTANT_VERSE As Double, ByVal DATE_REGLEMENT As Date, ByVal MODE_REGLEMENT As String, ByVal REF_REGLEMENT As String, ByVal CODE_MODE As String, ByVal IMPRIMER As String, ByVal CODE_AGENCE As String, ByVal CODE_RESERVATION As String, ByVal CODE_CLIENT As String) As Boolean

        Dim updateQuery As String = "UPDATE `reglement` SET `NUM_REGLEMENT`=@value1,`NUM_FACTURE`=@value2,`CODE_CAISSIER`=@value3,`MONTANT_VERSE`=MONTANT_VERSE+@value4,`DATE_REGLEMENT`=@value5,`MODE_REGLEMENT`=@value6,`REF_REGLEMENT`=@value7,`CODE_MODE`=@value8,`IMPRIMER`=@value9,`CODE_AGENCE`=@value10, `CODE_RESERVATION`=@value11 , `CODE_CLIENT`=@value12 WHERE NUM_REGLEMENT=@NUM_REGLEMENT"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUM_REGLEMENT", MySqlDbType.VarChar).Value = NUM_REGLEMENT
        command.Parameters.Add("@value1", MySqlDbType.String).Value = NUM_REGLEMENT
        command.Parameters.Add("@value2", MySqlDbType.String).Value = NUM_FACTURE
        command.Parameters.Add("@value3", MySqlDbType.String).Value = CODE_CAISSIER
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_VERSE
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_REGLEMENT
        command.Parameters.Add("@value6", MySqlDbType.String).Value = MODE_REGLEMENT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = REF_REGLEMENT
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_MODE
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = IMPRIMER
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CODE_CLIENT

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


    Public Function ListeDesReglementDeLaReservationEncours(ByVal CODE_RESERVATION As String) As DataTable

        Dim Query As String = "SELECT NUM_REGLEMENT As 'CODE', REF_REGLEMENT AS 'LIBELLE', DATE_REGLEMENT As 'DATE', MONTANT_VERSE AS 'MONTANT'  FROM reglement WHERE CODE_RESERVATION=@CODE_RESERVATION AND CODE_AGENCE=@CODE_AGENCE"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    Public Function updateReglementClotureFolio(ByVal NUM_REGLEMENT As String, ByVal CODE_FACTURE As String, ByVal IMPRIMER As Integer, ByVal CODE_ARTICLE As String, ByVal CODE_RESERVATION As String) As Boolean

        Dim updateQuery As String = "UPDATE `reglement` SET NUM_FACTURE =@CODE_FACTURE, `IMPRIMER`=@IMPRIMER WHERE NUM_REGLEMENT=@NUM_REGLEMENT AND CODE_RESERVATION=@CODE_RESERVATION AND IMPRIMER=@IMPRIMER_OLD"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUM_REGLEMENT", MySqlDbType.VarChar).Value = NUM_REGLEMENT

        command.Parameters.Add("@CODE_FACTURE", MySqlDbType.VarChar).Value = CODE_FACTURE
        command.Parameters.Add("@CODE_RESERVATION", MySqlDbType.VarChar).Value = CODE_RESERVATION

        command.Parameters.Add("@IMPRIMER", MySqlDbType.Int64).Value = IMPRIMER

        'POUR NE PAS TRAITER LES INFORMATIONS DEJA TRAITEES
        command.Parameters.Add("@IMPRIMER_OLD", MySqlDbType.Int64).Value = 0

        'command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

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


    ' ----------------------- RAPPORT DES REGLEMENTS -------------------------

    Public Function ListeDesReglementsPourRapport(ByVal DateDebut As Date, ByVal DateFin As Date) As DataTable

        Dim Query As String = "SELECT NUM_REGLEMENT As 'CODE', REF_REGLEMENT AS 'LIBELLE', DATE_REGLEMENT As 'DATE', MONTANT_VERSE AS 'MONTANT',CODE_RESERVATION As 'RESERVATION'  FROM reglement WHERE CODE_AGENCE=@CODE_AGENCE"

        Dim command As New MySqlCommand(Query, GlobalVariable.connect)

        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapterList As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapterList.Fill(table)

        Return table

    End Function

    'insert a new client Catgeory
    Public Function insertPetiteCaisseLigne(ByVal NUM_REGLEMENT As String, ByVal MONTANT_SORTIE As Double, ByVal CODE_CAISSIER As String, ByVal MONTANT_VERSE As Double, ByVal DATE_REGLEMENT As Date, ByVal MODE_REGLEMENT As String, ByVal REF_REGLEMENT As String, ByVal SERVICE_DEMANDEUR As String, ByVal ETAT As Integer, ByVal CODE_AGENCE As String, ByVal NOM_DU_RECEVEUR As String, ByVal CNI_RECEVEUR As String, ByVal CODE_CAISSE As String, ByVal NATURE_OPERATION As Integer, ByVal APPROUVE_PAR As String, Optional ByVal MODE_REG_INFO_SUP_1 As String = "", Optional ByVal MODE_REG_INFO_SUP_2 As String = "", Optional ByVal MODE_REG_INFO_SUP_3 As String = "2022-05-22") As Boolean

        Dim insertQuery As String = "INSERT INTO `petite_caisse_ligne`(`NUM_REGLEMENT`, `MONTANT_SORTIE`, `CODE_CAISSIER`, `MONTANT_VERSE`, `DATE_REGLEMENT`, `MODE_REGLEMENT`, `REF_REGLEMENT`, `SERVICE_DEMANDEUR`, `ETAT`, `CODE_AGENCE`, `NOM_DU_RECEVEUR`, `CNI_RECEVEUR`,`CODE_CAISSE`, `NATURE_OPERATION`, `APPROUVE_PAR`, `MODE_REG_INFO_SUP_1`, `MODE_REG_INFO_SUP_2`, `MODE_REG_INFO_SUP_3`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10 ,@value11 , @value12, @value16, @NATURE_OPERATION, @APPROUVE_PAR, @value13 , @value14 , @value15)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUM_REGLEMENT", MySqlDbType.VarChar).Value = NUM_REGLEMENT
        command.Parameters.Add("@value1", MySqlDbType.String).Value = NUM_REGLEMENT
        command.Parameters.Add("@value2", MySqlDbType.Double).Value = MONTANT_SORTIE
        command.Parameters.Add("@value3", MySqlDbType.String).Value = CODE_CAISSIER
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_VERSE
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_REGLEMENT
        command.Parameters.Add("@value6", MySqlDbType.String).Value = MODE_REGLEMENT
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = REF_REGLEMENT
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = SERVICE_DEMANDEUR
        command.Parameters.Add("@value9", MySqlDbType.Int64).Value = ETAT
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = NOM_DU_RECEVEUR
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = CNI_RECEVEUR
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = MODE_REG_INFO_SUP_1
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = MODE_REG_INFO_SUP_2
        command.Parameters.Add("@value15", MySqlDbType.String).Value = MODE_REG_INFO_SUP_3
        command.Parameters.Add("@value16", MySqlDbType.VarChar).Value = CODE_CAISSE
        command.Parameters.Add("@NATURE_OPERATION", MySqlDbType.Int64).Value = NATURE_OPERATION
        command.Parameters.Add("@APPROUVE_PAR", MySqlDbType.VarChar).Value = APPROUVE_PAR

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

    '------------------------------------- GESTION DE LA PETITE CAISSE ---------------------------------------4

    Public Function SituationDePetiteCaisse(ByVal depenseTextBox As Label, ByVal SituationCaisseTextBox As Label, ByVal CODE_CAISSE As String) As Boolean

        Dim infoPetiteCaisse As DataTable = Functions.getElementByCode(CODE_CAISSE, "petite_caisse", "CODE_CAISSE")

        If infoPetiteCaisse.Rows.Count > 0 Then
            depenseTextBox.Text = Format(infoPetiteCaisse.Rows(0)("TOTAL_SORTIE"), "#,##0")
            SituationCaisseTextBox.Text = Format(infoPetiteCaisse.Rows(0)("TOTAL_EN_CAISSE"), "#,##0")
        End If

        Return True

    End Function

    Public Function SituationDePetiteCaisseOldPerfectlyWorking(ByVal depenseTextBox As Label, ByVal SituationCaisseTextBox As Label, ByVal CODE_CAISSE As String) As Boolean

        'On selectionne l'ensemble des reglement du client
        Dim query1 As String = "SELECT REF_REGLEMENT, NUM_REGLEMENT,MONTANT_VERSE, MONTANT_SORTIE, DATE_REGLEMENT FROM petite_caisse_ligne WHERE CODE_AGENCE = @CODE_AGENCE AND CODE_CAISSE=@CODE_CAISSE ORDER BY DATE_REGLEMENT DESC"
        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command1.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim tableReglement As New DataTable()

        adapter1.Fill(tableReglement)

        Dim totalEntree As Double = 0
        Dim totalSortie As Double = 0


        If tableReglement.Rows.Count > 0 Then

            For i = 0 To tableReglement.Rows.Count - 1

                totalEntree += tableReglement.Rows(i)("MONTANT_VERSE")
                totalSortie += tableReglement.Rows(i)("MONTANT_SORTIE")

            Next

        End If

        depenseTextBox.Text = Format(totalSortie, "#,##0")
        SituationCaisseTextBox.Text = Format(totalEntree - totalSortie, "#,##0")

        Return True

    End Function

    Public Function UpdateEtatReglementPourClientComptoire(ByVal NUM_REGLEMENT As String, ByVal ETAT As Integer) As Boolean

        Dim updateQuery As String = "UPDATE `reglement` SET `ETAT`=@ETAT WHERE NUM_REGLEMENT=@NUM_REGLEMENT"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@NUM_REGLEMENT", MySqlDbType.VarChar).Value = NUM_REGLEMENT
        command.Parameters.Add("@ETAT", MySqlDbType.Int64).Value = ETAT

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function UpdateMontantSortieEtTotalEnCaissePetiteCaisseLigne(ByVal CODE_CAISSE As String, ByVal NATURE_OPERATION As Integer, ByVal MONTANT As Double) As Boolean

        Dim updateQuery As String = ""

        Dim infoPetiteCaisse As DataTable = Functions.getElementByCode(CODE_CAISSE, "petite_caisse", "CODE_CAISSE")

        If infoPetiteCaisse.Rows.Count > 0 Then

            If NATURE_OPERATION = 0 Then 'ENTREE DE FONDS

                If infoPetiteCaisse.Rows(0)("TOTAL_EN_CAISSE") = 0 Then

                    'PREMIER APPROVISIONNEMENT DE LA PETITE CAISSE
                    updateQuery = "UPDATE `petite_caisse` SET `TOTAL_EN_CAISSE`=TOTAL_EN_CAISSE + @MONTANT WHERE CODE_CAISSE=@CODE_CAISSE"
                Else

                    If infoPetiteCaisse.Rows(0)("TOTAL_SORTIE") = 0 Then
                        'ON A ENCORE FAITE AUCUNE SORTIE
                        updateQuery = "UPDATE `petite_caisse` SET `TOTAL_EN_CAISSE`=TOTAL_EN_CAISSE + @MONTANT WHERE CODE_CAISSE=@CODE_CAISSE"
                    Else
                        'AU MOINS UNE SORTIE A DEJA ETE FAITE
                        updateQuery = "UPDATE `petite_caisse` SET `TOTAL_EN_CAISSE`=TOTAL_EN_CAISSE + @MONTANT, `TOTAL_SORTIE`=TOTAL_SORTIE - @MONTANT WHERE CODE_CAISSE=@CODE_CAISSE"
                    End If

                End If

            ElseIf NATURE_OPERATION = 1 Then 'SORTIE DE FONDS
                updateQuery = "UPDATE `petite_caisse` SET `TOTAL_EN_CAISSE`=TOTAL_EN_CAISSE - @MONTANT, `TOTAL_SORTIE`=TOTAL_SORTIE + @MONTANT WHERE CODE_CAISSE=@CODE_CAISSE"
            End If

        End If

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSE", MySqlDbType.VarChar).Value = CODE_CAISSE
        command.Parameters.Add("@MONTANT", MySqlDbType.Double).Value = MONTANT

        If (command.ExecuteNonQuery() = 1) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
