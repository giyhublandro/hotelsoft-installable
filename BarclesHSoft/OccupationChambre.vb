Imports System.IO
Imports MySql.Data.MySqlClient

Public Class OccupationChambre
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    Public Function insertOccupationChambre(ByVal CODE_OCCUPATION_CHAMBRE As String, ByVal CODE_RESERVATION As String, ByVal CODE_CHAMBRE As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal MONTANT_TTC As Double, ByVal DATE_OCCUPATION As Date, ByVal ETAT_CHAMBRE As String, ByVal OBSERVATIONS As String, ByVal COMMENTAIRE1 As String, ByVal COMMENTAIRE2 As String, ByVal COMMENTAIRE3 As String, ByVal COMMENTAIRE4 As String, ByVal DATE_LIBERATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_PREMIERE_ARRIVEE As Date, ByVal TYPE_RESERVATION As String, ByVal PDJ_INCLUS As String, ByVal TAXE_SEJOURS_INCLUS As String, ByVal TVA_INCLUS As String, ByVal CODE_CLIENT_REEL As String, ByVal CODE_AGENCE As String) As Boolean

        Dim insertQuery As String = "INSERT INTO `occupation_chambre`(`CODE_OCCUPATION_CHAMBRE`, `CODE_RESERVATION`, `CODE_CHAMBRE`, `MONTANT_HT`, `TAXE`, `MONTANT_TTC`, `DATE_OCCUPATION`, `ETAT_CHAMBRE`, `OBSERVATIONS`, `COMMENTAIRE1`, `COMMENTAIRE2`, `COMMENTAIRE3`, `COMMENTAIRE4`, `DATE_LIBERATION`, `CODE_UTILISATEUR_CREA`, `DATE_PREMIERE_ARRIVEE`, `TYPE_RESERVATION`, `PDJ_INCLUS`, `TAXE_SEJOURS_INCLUS`, `TVA_INCLUS`, `CODE_CLIENT_REEL`, `CODE_AGENCE`) VALUES (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.String).Value = CODE_OCCUPATION_CHAMBRE
        command.Parameters.Add("@value2", MySqlDbType.String).Value = CODE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.String).Value = CODE_CHAMBRE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = DATE_OCCUPATION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = COMMENTAIRE1
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = COMMENTAIRE2
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = COMMENTAIRE3
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = COMMENTAIRE4
        command.Parameters.Add("@value14", MySqlDbType.Date).Value = DATE_LIBERATION
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_PREMIERE_ARRIVEE
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = TYPE_RESERVATION
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = PDJ_INCLUS
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = TAXE_SEJOURS_INCLUS
        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = TVA_INCLUS
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = CODE_CLIENT_REEL
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = CODE_AGENCE

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

    'create a function to update entry
    Public Function updateOccupationChambre(ByVal CODE_OCCUPATION_CHAMBRE As String, ByVal CODE_RESERVATION As String, ByVal CODE_CHAMBRE As String, ByVal MONTANT_HT As Double, ByVal TAXE As Double, ByVal MONTANT_TTC As Double, ByVal DATE_OCCUPATION As Date, ByVal ETAT_CHAMBRE As String, ByVal OBSERVATIONS As String, ByVal COMMENTAIRE1 As String, ByVal COMMENTAIRE2 As String, ByVal COMMENTAIRE3 As String, ByVal COMMENTAIRE4 As String, ByVal DATE_LIBERATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_PREMIERE_ARRIVEE As Date, ByVal TYPE_RESERVATION As String, ByVal PDJ_INCLUS As String, ByVal TAXE_SEJOURS_INCLUS As String, ByVal TVA_INCLUS As String, ByVal CODE_CLIENT_REEL As String, ByVal CODE_AGENCE As String) As Boolean

        Dim updateQuery As String = "UPDATE `occupation_chambre` SET `CODE_OCCUPATION_CHAMBRE`=@value1,`CODE_RESERVATION`=@value2,`CODE_CHAMBRE`=@value3,`MONTANT_HT`=@value4,`TAXE`=@value5,`MONTANT_TTC`=@value6,`DATE_OCCUPATION`=@value7,`ETAT_CHAMBRE`=@value8,`OBSERVATIONS`=@value9,`COMMENTAIRE1`=@value10,`COMMENTAIRE2`=@value11,`COMMENTAIRE3`=@value12,`COMMENTAIRE4`=@value13,`DATE_LIBERATION`=@value14,`CODE_UTILISATEUR_CREA`=@value15,`DATE_PREMIERE_ARRIVEE`=@value16,`TYPE_RESERVATION`=@value17,`PDJ_INCLUS`=@value18,`TAXE_SEJOURS_INCLUS`=@value19,`TVA_INCLUS`=@value20,`CODE_CLIENT_REEL`=@value21,`CODE_AGENCE`=@value22 WHERE CODE_OCCUPATION_CHAMBRE=@CODE_OCCUPATION_CHAMBRE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_OCCUPATION_CHAMBRE", MySqlDbType.String).Value = CODE_OCCUPATION_CHAMBRE

        command.Parameters.Add("@value1", MySqlDbType.String).Value = CODE_OCCUPATION_CHAMBRE
        command.Parameters.Add("@value2", MySqlDbType.String).Value = CODE_RESERVATION
        command.Parameters.Add("@value3", MySqlDbType.String).Value = CODE_CHAMBRE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = MONTANT_HT
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = TAXE
        command.Parameters.Add("@value6", MySqlDbType.Double).Value = MONTANT_TTC
        command.Parameters.Add("@value7", MySqlDbType.Date).Value = DATE_OCCUPATION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = ETAT_CHAMBRE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = OBSERVATIONS
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = COMMENTAIRE1
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = COMMENTAIRE2
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = COMMENTAIRE3
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = COMMENTAIRE4
        command.Parameters.Add("@value14", MySqlDbType.Date).Value = DATE_LIBERATION
        command.Parameters.Add("@value15", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value16", MySqlDbType.Date).Value = DATE_PREMIERE_ARRIVEE
        command.Parameters.Add("@value17", MySqlDbType.VarChar).Value = TYPE_RESERVATION
        command.Parameters.Add("@value18", MySqlDbType.VarChar).Value = PDJ_INCLUS
        command.Parameters.Add("@value19", MySqlDbType.VarChar).Value = TAXE_SEJOURS_INCLUS
        command.Parameters.Add("@value20", MySqlDbType.VarChar).Value = TVA_INCLUS
        command.Parameters.Add("@value21", MySqlDbType.VarChar).Value = CODE_CLIENT_REEL
        command.Parameters.Add("@value22", MySqlDbType.VarChar).Value = CODE_AGENCE

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
