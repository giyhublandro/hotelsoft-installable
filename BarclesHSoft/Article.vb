Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Article
    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    'insert a new client Catgeory
    Public Function insertArticle(ByVal CODE_ARTICLE As String, ByVal REFERENCE As String, ByVal CODE_BARRE As String, ByVal DESIGNATION_FR As String, ByVal DESIGNATION_EN As String, ByVal DESCRIPTION As String, ByVal CODE_GROUPE_ARTICLE As String, ByVal CODE_FAMILLE As String, ByVal CODE_SOUS_FAMILLE As String, ByVal CODE_SOUS_SOUS_FAMILLE As String, ByVal METHODE_SUIVI_STOCK As String, ByVal TYPE_ARTICLE As String, ByVal CONDITIONNEMENT As String, ByVal SEUIL_PRIX_VENTE_HT As Double, ByVal PRIX_ACHAT_HT As Double, ByVal COUT_U_MOYEN_PONDERE As Double, ByVal PRIX_ACHAT_TTC As Double, ByVal PRIX_VENTE_HT As Double, ByVal PRIX_VENTE_TTC As Double, ByVal PRIX_VENTE1_HT As Double, ByVal PRIX_VENTE1_TTC As Double, ByVal PRIX_VENTE2_HT As Double, ByVal PRIX_VENTE2_TTC As Double, ByVal PRIX_VENTE3_HT As Double, ByVal PRIX_VENTE3_TTC As Double, ByVal PRIX_VENTE4_HT As Double, ByVal PRIX_VENTE4_TTC As Double, ByVal PRIX_VENTE5_HT As Double, ByVal PRIX_VENTE5_TTC As Double, ByVal PRIX_VENTE6_HT As Double, ByVal PRIX_VENTE6_TTC As Double, ByVal PRIX_VENTE7_HT As Double, ByVal PRIX_VENTE7_TTC As Double, ByVal PRIX_VENTE8_HT As Double, ByVal PRIX_VENTE8_TTC As Double, ByVal PRIX_VENTE9_HT As Double, ByVal QUANTITE As Double, ByVal POURCENTAGE_REMISE As Double, ByVal TAUX_EXONERATION_TVA As Double, ByVal SEUIL_REAPPROVISIONNEMENT As Double, ByVal NUMERO_SERIE As String, ByVal ARTICLE_COMPOSE As String, ByVal ARTICLE_LIE As String, ByVal ARTICLE_RECONDITIONNABLE As String, ByVal APPARAIT_SUR_FICHE_CLIENT As String, ByVal ARTICLE_PERISSABLE As String, ByVal ARTICLE_GERE_PAR_LOT As String, ByVal DATE_DEBUT_PROMOTION As Date, ByVal POURCENTAGE_REMISE_PROMOTION As Double, ByVal DATE_FIN_PROMOTION As Date, ByVal CHEMIN_PHOTO As String, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal ARTICLE_A_REMISE As String, ByVal CODE_CLE As String, ByVal DELEGUE As String, ByVal SEUIL_PRIX_VENTE_TTC As Double, ByVal TX_LIMIT As Double, ByVal DAILY_LIMIT As Double, ByVal TAUX_TVA As Double, ByVal SPECIALITE_ARTICLE As String, ByVal ARTICLE_MULTIPRIX As String, ByVal CODE_AGENCE As String, ByVal TYPE As String, ByVal CODE_UNITE_DE_COMPTAGE As String, ByVal CARTE As Integer, ByVal CODE_CONSO As String, ByVal PRIX_CONSO As Double, ByVal CONTENANCE As Double, ByVal BOISSON As Integer, ByVal PRIX_CONSO2 As Double, ByVal PRIX_CONSO3 As Double, ByVal PRIX_CONSO4 As Double, ByVal VISIBLE As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `article`(`CODE_ARTICLE`, `REFERENCE`, `CODE_BARRE`, `DESIGNATION_FR`, `DESIGNATION_EN`, `DESCRIPTION`, `CODE_GROUPE_ARTICLE`, `CODE_FAMILLE`, `CODE_SOUS_FAMILLE`, `CODE_SOUS_SOUS_FAMILLE`, `METHODE_SUIVI_STOCK`, `TYPE_ARTICLE`, `CONDITIONNEMENT`, `SEUIL_PRIX_VENTE_HT`, `PRIX_ACHAT_HT`, `COUT_U_MOYEN_PONDERE`, `PRIX_ACHAT_TTC`, `PRIX_VENTE_HT`, `PRIX_VENTE_TTC`, `PRIX_VENTE1_HT`, `PRIX_VENTE1_TTC`, `PRIX_VENTE2_HT`, `PRIX_VENTE2_TTC`, `PRIX_VENTE3_HT`, `PRIX_VENTE3_TTC`, `PRIX_VENTE4_HT`, `PRIX_VENTE4_TTC`, `PRIX_VENTE5_HT`, `PRIX_VENTE5_TTC`, `PRIX_VENTE6_HT`, `PRIX_VENTE6_TTC`, `PRIX_VENTE7_HT`, `PRIX_VENTE7_TTC`, `PRIX_VENTE8_HT`, `PRIX_VENTE8_TTC`, `PRIX_VENTE9_HT`, `QUANTITE`, `POURCENTAGE_REMISE`, `TAUX_EXONERATION_TVA`, `SEUIL_REAPPROVISIONNEMENT`, `NUMERO_SERIE`, `ARTICLE_COMPOSE`, `ARTICLE_LIE`, `ARTICLE_RECONDITIONNABLE`, `APPARAIT_SUR_FICHE_CLIENT`, `ARTICLE_PERISSABLE`, `ARTICLE_GERE_PAR_LOT`, `DATE_DEBUT_PROMOTION`, `POURCENTAGE_REMISE_PROMOTION`, `DATE_FIN_PROMOTION`, `CHEMIN_PHOTO`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `ARTICLE_A_REMISE`, `CODE_CLE`, `DELEGUE`, `SEUIL_PRIX_VENTE_TTC`, `TX_LIMIT`, `DAILY_LIMIT`, `TAUX_TVA`, `SPECIALITE_ARTICLE`, `ARTICLE_MULTIPRIX`, `CODE_AGENCE`, `TYPE`,`UNITE_COMPTAGE`,`CARTE`,`CODE_CONSO`,`PRIX_CONSO`,`CONTENANCE`,`BOISSON`, `PRIX_CONSO2`, `PRIX_CONSO3`, `PRIX_CONSO4`,`VISIBLE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9,@value10,@value11,@value12,@value13,@value14,@value15,@value16,@value17,@value18,@value19,@value20,@value21,@value22,@value23,@value24,@value25,@value26,@value27,@value28,@value29,@value30,@value31,@value32,@value33,@value34,@value35,@value36,@value37,@QUANTITE,@value39,@value40,@value41,@value42,@value43,@value44,@value45,@value46,@value47,@value48,@value49,@value50,@value51,@value52,@value53,@value54,@value55,@value56,@value57,@value58,@value59,@value60,@value61,@value62,@value63,@value64,@value65,@value66,@value67,@value68,@value69,@value70, @PRIX_CONSO, @CONTENANCE, @BOISSON, @PRIX_CONSO2, @PRIX_CONSO3, @PRIX_CONSO4, @VISIBLE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = REFERENCE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_BARRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = DESIGNATION_FR
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = DESIGNATION_EN
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_GROUPE_ARTICLE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_FAMILLE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_SOUS_FAMILLE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = CODE_SOUS_SOUS_FAMILLE
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = METHODE_SUIVI_STOCK
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = TYPE_ARTICLE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CONDITIONNEMENT
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = SEUIL_PRIX_VENTE_HT
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = PRIX_ACHAT_HT
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = COUT_U_MOYEN_PONDERE
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = PRIX_ACHAT_TTC
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = PRIX_VENTE_HT
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = PRIX_VENTE_TTC
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = PRIX_VENTE1_HT
        command.Parameters.Add("@value22", MySqlDbType.Double).Value = PRIX_VENTE1_TTC
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = PRIX_VENTE2_HT
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = PRIX_VENTE2_TTC
        command.Parameters.Add("@value25", MySqlDbType.Double).Value = PRIX_VENTE3_HT
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = PRIX_VENTE3_TTC
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = PRIX_VENTE4_HT
        command.Parameters.Add("@value28", MySqlDbType.Double).Value = PRIX_VENTE4_TTC
        command.Parameters.Add("@value29", MySqlDbType.Double).Value = PRIX_VENTE5_HT
        command.Parameters.Add("@value30", MySqlDbType.Double).Value = PRIX_VENTE5_TTC
        command.Parameters.Add("@value31", MySqlDbType.Double).Value = PRIX_VENTE6_HT
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = PRIX_VENTE6_TTC
        command.Parameters.Add("@value33", MySqlDbType.Double).Value = PRIX_VENTE7_HT
        command.Parameters.Add("@value34", MySqlDbType.Double).Value = PRIX_VENTE7_TTC
        command.Parameters.Add("@value35", MySqlDbType.Double).Value = PRIX_VENTE8_HT
        command.Parameters.Add("@value36", MySqlDbType.Double).Value = PRIX_VENTE8_TTC
        command.Parameters.Add("@value37", MySqlDbType.Double).Value = PRIX_VENTE9_HT
        command.Parameters.Add("@QUANTITE", MySqlDbType.Double).Value = QUANTITE
        command.Parameters.Add("@value39", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value40", MySqlDbType.Double).Value = TAUX_EXONERATION_TVA
        command.Parameters.Add("@value41", MySqlDbType.VarChar).Value = SEUIL_REAPPROVISIONNEMENT
        command.Parameters.Add("@value42", MySqlDbType.VarChar).Value = NUMERO_SERIE
        command.Parameters.Add("@value43", MySqlDbType.VarChar).Value = ARTICLE_COMPOSE
        command.Parameters.Add("@value44", MySqlDbType.VarChar).Value = ARTICLE_LIE
        command.Parameters.Add("@value45", MySqlDbType.VarChar).Value = ARTICLE_RECONDITIONNABLE
        command.Parameters.Add("@value46", MySqlDbType.VarChar).Value = APPARAIT_SUR_FICHE_CLIENT
        command.Parameters.Add("@value47", MySqlDbType.VarChar).Value = ARTICLE_PERISSABLE
        command.Parameters.Add("@value48", MySqlDbType.VarChar).Value = ARTICLE_GERE_PAR_LOT
        command.Parameters.Add("@value49", MySqlDbType.Date).Value = DATE_DEBUT_PROMOTION
        command.Parameters.Add("@value50", MySqlDbType.Double).Value = POURCENTAGE_REMISE_PROMOTION
        command.Parameters.Add("@value51", MySqlDbType.Date).Value = DATE_FIN_PROMOTION
        command.Parameters.Add("@value52", MySqlDbType.VarChar).Value = CHEMIN_PHOTO
        command.Parameters.Add("@value53", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value54", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value55", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value56", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value57", MySqlDbType.VarChar).Value = ARTICLE_A_REMISE
        command.Parameters.Add("@value58", MySqlDbType.VarChar).Value = CODE_CLE
        command.Parameters.Add("@value59", MySqlDbType.VarChar).Value = DELEGUE
        command.Parameters.Add("@value60", MySqlDbType.Double).Value = SEUIL_PRIX_VENTE_TTC
        command.Parameters.Add("@value61", MySqlDbType.Double).Value = TX_LIMIT
        command.Parameters.Add("@value62", MySqlDbType.Double).Value = DAILY_LIMIT
        command.Parameters.Add("@value63", MySqlDbType.Double).Value = TAUX_TVA
        command.Parameters.Add("@value64", MySqlDbType.VarChar).Value = SPECIALITE_ARTICLE
        command.Parameters.Add("@value65", MySqlDbType.VarChar).Value = ARTICLE_MULTIPRIX
        command.Parameters.Add("@value66", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value67", MySqlDbType.VarChar).Value = TYPE
        command.Parameters.Add("@value68", MySqlDbType.VarChar).Value = CODE_UNITE_DE_COMPTAGE
        command.Parameters.Add("@value69", MySqlDbType.Int64).Value = CARTE
        command.Parameters.Add("@value70", MySqlDbType.VarChar).Value = CODE_CONSO
        command.Parameters.Add("@PRIX_CONSO", MySqlDbType.Double).Value = PRIX_CONSO
        command.Parameters.Add("@CONTENANCE", MySqlDbType.Double).Value = CONTENANCE
        command.Parameters.Add("@BOISSON", MySqlDbType.Int64).Value = BOISSON
        command.Parameters.Add("@PRIX_CONSO2", MySqlDbType.Double).Value = PRIX_CONSO2
        command.Parameters.Add("@PRIX_CONSO3", MySqlDbType.Double).Value = PRIX_CONSO3
        command.Parameters.Add("@PRIX_CONSO4", MySqlDbType.Double).Value = PRIX_CONSO4
        command.Parameters.Add("@VISIBLE", MySqlDbType.Int64).Value = VISIBLE

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
    Public Function updateArticle(ByVal CODE_ARTICLE As String, ByVal REFERENCE As String, ByVal CODE_BARRE As String, ByVal DESIGNATION_FR As String, ByVal DESIGNATION_EN As String, ByVal DESCRIPTION As String, ByVal CODE_GROUPE_ARTICLE As String, ByVal CODE_FAMILLE As String, ByVal CODE_SOUS_FAMILLE As String, ByVal CODE_SOUS_SOUS_FAMILLE As String, ByVal METHODE_SUIVI_STOCK As String, ByVal TYPE_ARTICLE As String, ByVal CONDITIONNEMENT As String, ByVal SEUIL_PRIX_VENTE_HT As Double, ByVal PRIX_ACHAT_HT As Double, ByVal COUT_U_MOYEN_PONDERE As Double, ByVal PRIX_ACHAT_TTC As Double, ByVal PRIX_VENTE_HT As Double, ByVal PRIX_VENTE_TTC As Double, ByVal PRIX_VENTE1_HT As Double, ByVal PRIX_VENTE1_TTC As Double, ByVal PRIX_VENTE2_HT As Double, ByVal PRIX_VENTE2_TTC As Double, ByVal PRIX_VENTE3_HT As Double, ByVal PRIX_VENTE3_TTC As Double, ByVal PRIX_VENTE4_HT As Double, ByVal PRIX_VENTE4_TTC As Double, ByVal PRIX_VENTE5_HT As Double, ByVal PRIX_VENTE5_TTC As Double, ByVal PRIX_VENTE6_HT As Double, ByVal PRIX_VENTE6_TTC As Double, ByVal PRIX_VENTE7_HT As Double, ByVal PRIX_VENTE7_TTC As Double, ByVal PRIX_VENTE8_HT As Double, ByVal PRIX_VENTE8_TTC As Double, ByVal PRIX_VENTE9_HT As Double, ByVal PRIX_VENTE9_TTC As Double, ByVal POURCENTAGE_REMISE As Double, ByVal TAUX_EXONERATION_TVA As Double, ByVal SEUIL_REAPPROVISIONNEMENT As Double, ByVal NUMERO_SERIE As String, ByVal ARTICLE_COMPOSE As String, ByVal ARTICLE_LIE As String, ByVal ARTICLE_RECONDITIONNABLE As String, ByVal APPARAIT_SUR_FICHE_CLIENT As String, ByVal ARTICLE_PERISSABLE As String, ByVal ARTICLE_GERE_PAR_LOT As String, ByVal DATE_DEBUT_PROMOTION As Date, ByVal POURCENTAGE_REMISE_PROMOTION As Double, ByVal DATE_FIN_PROMOTION As Date, ByVal CHEMIN_PHOTO As String, ByVal DATE_CREATION As Date, ByVal CODE_UTILISATEUR_CREA As String, ByVal DATE_MODIFICATION As Date, ByVal CODE_UTILISATEUR_MODIF As String, ByVal ARTICLE_A_REMISE As String, ByVal CODE_CLE As String, ByVal DELEGUE As String, ByVal SEUIL_PRIX_VENTE_TTC As Double, ByVal TX_LIMIT As Double, ByVal DAILY_LIMIT As Double, ByVal TAUX_TVA As Double, ByVal SPECIALITE_ARTICLE As String, ByVal ARTICLE_MULTIPRIX As String, ByVal CODE_AGENCE As String, ByVal CODE_UNITE_DE_COMPTAGE As String, ByVal CARTE As Integer, ByVal CODE_CONSO As String, ByVal PRIX_CONSO As Double, ByVal CONTENANCE As Double, ByVal BOISSON As Integer, ByVal PRIX_CONSO2 As Double, ByVal PRIX_CONSO3 As Double, ByVal PRIX_CONSO4 As Double, ByVal VISIBLE As Integer, ByVal TYPE As String) As Boolean

        Dim updateQuery As String = "UPDATE `article` SET `CODE_ARTICLE`=@value2,`REFERENCE`=@value3,`CODE_BARRE`=@value4,`DESIGNATION_FR`=@value5,`DESIGNATION_EN`=@value6,`DESCRIPTION`=@value7,`CODE_GROUPE_ARTICLE`=@value8,`CODE_FAMILLE`=@value9,`CODE_SOUS_FAMILLE`=@value10,`CODE_SOUS_SOUS_FAMILLE`=@value11,`METHODE_SUIVI_STOCK`=@value12,`TYPE_ARTICLE`=@value13,`CONDITIONNEMENT`=@value14,`SEUIL_PRIX_VENTE_HT`=@value15,`PRIX_ACHAT_HT`=@value16,`COUT_U_MOYEN_PONDERE`=@value17,`PRIX_ACHAT_TTC`=@value18,`PRIX_VENTE_HT`=@value19,`PRIX_VENTE_TTC`=@value20,`PRIX_VENTE1_HT`=@value21,`PRIX_VENTE1_TTC`=@value22,`PRIX_VENTE2_HT`=@value23,`PRIX_VENTE2_TTC`=@value24,`PRIX_VENTE3_HT`=@value25,`PRIX_VENTE3_TTC`=@value26,`PRIX_VENTE4_HT`=@value27,`PRIX_VENTE4_TTC`=@value28,`PRIX_VENTE5_HT`=@value29,`PRIX_VENTE5_TTC`=@value30,`PRIX_VENTE6_HT`=@value31,`PRIX_VENTE6_TTC`=@value32,`PRIX_VENTE7_HT`=@value33,`PRIX_VENTE7_TTC`=@value34,`PRIX_VENTE8_HT`=@value35,`PRIX_VENTE8_TTC`=@value36,`PRIX_VENTE9_HT`=@value37,`PRIX_VENTE9_TTC`=@value38,`POURCENTAGE_REMISE`=@value39,`TAUX_EXONERATION_TVA`=@value40,`SEUIL_REAPPROVISIONNEMENT`=@value41,`NUMERO_SERIE`=@value42,`ARTICLE_COMPOSE`=@value43,`ARTICLE_LIE`=@value44,`ARTICLE_RECONDITIONNABLE`=@value45,`APPARAIT_SUR_FICHE_CLIENT`=@value46,`ARTICLE_PERISSABLE`=@value47,`ARTICLE_GERE_PAR_LOT`=@value48,`DATE_DEBUT_PROMOTION`=@value49,`POURCENTAGE_REMISE_PROMOTION`=@value50,`DATE_FIN_PROMOTION`=@value51,`CHEMIN_PHOTO`=@value52,`DATE_CREATION`=@value53,`CODE_UTILISATEUR_CREA`=@value54,`DATE_MODIFICATION`=@value55,`CODE_UTILISATEUR_MODIF`=@value56,`ARTICLE_A_REMISE`=@value57,`CODE_CLE`=@value58,`DELEGUE`=@value59,`SEUIL_PRIX_VENTE_TTC`=@value60,`TX_LIMIT`=@value61,`DAILY_LIMIT`=@value62,`TAUX_TVA`=@value63,`SPECIALITE_ARTICLE`=@value64,`ARTICLE_MULTIPRIX`=@value65,`CODE_AGENCE`=@value66 ,`UNITE_COMPTAGE`=@value67,`CARTE`=@value68,`CODE_CONSO`=@CODE_CONSO,`PRIX_CONSO`=@PRIX_CONSO,`PRIX_CONSO2`=@PRIX_CONSO2,`PRIX_CONSO3`=@PRIX_CONSO3,`PRIX_CONSO4`=@PRIX_CONSO4, CONTENANCE=@CONTENANCE, BOISSON=@BOISSON, VISIBLE=@VISIBLE,  TYPE=@TYPE WHERE CODE_ARTICLE = @CODE_ARTICLE"

        Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = REFERENCE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_BARRE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = DESIGNATION_FR
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = DESIGNATION_EN
        command.Parameters.Add("@value7", MySqlDbType.VarChar).Value = DESCRIPTION
        command.Parameters.Add("@value8", MySqlDbType.VarChar).Value = CODE_GROUPE_ARTICLE
        command.Parameters.Add("@value9", MySqlDbType.VarChar).Value = CODE_FAMILLE
        command.Parameters.Add("@value10", MySqlDbType.VarChar).Value = CODE_SOUS_FAMILLE
        command.Parameters.Add("@value11", MySqlDbType.VarChar).Value = CODE_SOUS_SOUS_FAMILLE
        command.Parameters.Add("@value12", MySqlDbType.VarChar).Value = METHODE_SUIVI_STOCK
        command.Parameters.Add("@value13", MySqlDbType.VarChar).Value = TYPE_ARTICLE
        command.Parameters.Add("@value14", MySqlDbType.VarChar).Value = CONDITIONNEMENT
        command.Parameters.Add("@value15", MySqlDbType.Double).Value = SEUIL_PRIX_VENTE_HT
        command.Parameters.Add("@value16", MySqlDbType.Double).Value = PRIX_ACHAT_HT
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = COUT_U_MOYEN_PONDERE
        command.Parameters.Add("@value18", MySqlDbType.Double).Value = PRIX_ACHAT_TTC
        command.Parameters.Add("@value19", MySqlDbType.Double).Value = PRIX_VENTE_HT
        command.Parameters.Add("@value20", MySqlDbType.Double).Value = PRIX_VENTE_TTC
        command.Parameters.Add("@value21", MySqlDbType.Double).Value = PRIX_VENTE1_HT
        command.Parameters.Add("@value22", MySqlDbType.Double).Value = PRIX_VENTE1_TTC
        command.Parameters.Add("@value23", MySqlDbType.Double).Value = PRIX_VENTE2_HT
        command.Parameters.Add("@value24", MySqlDbType.Double).Value = PRIX_VENTE2_TTC
        command.Parameters.Add("@value25", MySqlDbType.Double).Value = PRIX_VENTE3_HT
        command.Parameters.Add("@value26", MySqlDbType.Double).Value = PRIX_VENTE3_TTC
        command.Parameters.Add("@value27", MySqlDbType.Double).Value = PRIX_VENTE4_HT
        command.Parameters.Add("@value28", MySqlDbType.Double).Value = PRIX_VENTE4_TTC
        command.Parameters.Add("@value29", MySqlDbType.Double).Value = PRIX_VENTE5_HT
        command.Parameters.Add("@value30", MySqlDbType.Double).Value = PRIX_VENTE5_TTC
        command.Parameters.Add("@value31", MySqlDbType.Double).Value = PRIX_VENTE6_HT
        command.Parameters.Add("@value32", MySqlDbType.Double).Value = PRIX_VENTE6_TTC
        command.Parameters.Add("@value33", MySqlDbType.Double).Value = PRIX_VENTE7_HT
        command.Parameters.Add("@value34", MySqlDbType.Double).Value = PRIX_VENTE7_TTC
        command.Parameters.Add("@value35", MySqlDbType.Double).Value = PRIX_VENTE8_HT
        command.Parameters.Add("@value36", MySqlDbType.Double).Value = PRIX_VENTE8_TTC
        command.Parameters.Add("@value37", MySqlDbType.Double).Value = PRIX_VENTE9_HT
        command.Parameters.Add("@value38", MySqlDbType.Double).Value = PRIX_VENTE9_TTC
        command.Parameters.Add("@value39", MySqlDbType.Double).Value = POURCENTAGE_REMISE
        command.Parameters.Add("@value40", MySqlDbType.Double).Value = TAUX_EXONERATION_TVA
        command.Parameters.Add("@value41", MySqlDbType.VarChar).Value = SEUIL_REAPPROVISIONNEMENT
        command.Parameters.Add("@value42", MySqlDbType.VarChar).Value = NUMERO_SERIE
        command.Parameters.Add("@value43", MySqlDbType.VarChar).Value = ARTICLE_COMPOSE
        command.Parameters.Add("@value44", MySqlDbType.VarChar).Value = ARTICLE_LIE
        command.Parameters.Add("@value45", MySqlDbType.VarChar).Value = ARTICLE_RECONDITIONNABLE
        command.Parameters.Add("@value46", MySqlDbType.VarChar).Value = APPARAIT_SUR_FICHE_CLIENT
        command.Parameters.Add("@value47", MySqlDbType.VarChar).Value = ARTICLE_PERISSABLE
        command.Parameters.Add("@value48", MySqlDbType.VarChar).Value = ARTICLE_GERE_PAR_LOT
        command.Parameters.Add("@value49", MySqlDbType.Date).Value = DATE_DEBUT_PROMOTION
        command.Parameters.Add("@value50", MySqlDbType.Double).Value = POURCENTAGE_REMISE_PROMOTION
        command.Parameters.Add("@value51", MySqlDbType.Date).Value = DATE_FIN_PROMOTION
        command.Parameters.Add("@value52", MySqlDbType.VarChar).Value = CHEMIN_PHOTO
        command.Parameters.Add("@value53", MySqlDbType.Date).Value = DATE_CREATION
        command.Parameters.Add("@value54", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_CREA
        command.Parameters.Add("@value55", MySqlDbType.Date).Value = DATE_MODIFICATION
        command.Parameters.Add("@value56", MySqlDbType.VarChar).Value = CODE_UTILISATEUR_MODIF
        command.Parameters.Add("@value57", MySqlDbType.VarChar).Value = ARTICLE_A_REMISE
        command.Parameters.Add("@value58", MySqlDbType.VarChar).Value = CODE_CLE
        command.Parameters.Add("@value59", MySqlDbType.VarChar).Value = DELEGUE
        command.Parameters.Add("@value60", MySqlDbType.Double).Value = SEUIL_PRIX_VENTE_TTC
        command.Parameters.Add("@value61", MySqlDbType.Double).Value = TX_LIMIT
        command.Parameters.Add("@value62", MySqlDbType.Double).Value = DAILY_LIMIT
        command.Parameters.Add("@value63", MySqlDbType.Double).Value = TAUX_TVA
        command.Parameters.Add("@value64", MySqlDbType.VarChar).Value = SPECIALITE_ARTICLE
        command.Parameters.Add("@value65", MySqlDbType.VarChar).Value = ARTICLE_MULTIPRIX
        command.Parameters.Add("@value66", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@value67", MySqlDbType.VarChar).Value = CODE_UNITE_DE_COMPTAGE
        command.Parameters.Add("@value68", MySqlDbType.Int64).Value = CARTE
        command.Parameters.Add("@CODE_CONSO", MySqlDbType.VarChar).Value = CODE_CONSO
        command.Parameters.Add("@PRIX_CONSO", MySqlDbType.Double).Value = PRIX_CONSO
        command.Parameters.Add("@CONTENANCE", MySqlDbType.Double).Value = CONTENANCE
        command.Parameters.Add("@BOISSON", MySqlDbType.Int64).Value = BOISSON
        command.Parameters.Add("@PRIX_CONSO2", MySqlDbType.Double).Value = PRIX_CONSO2
        command.Parameters.Add("@PRIX_CONSO3", MySqlDbType.Double).Value = PRIX_CONSO3
        command.Parameters.Add("@PRIX_CONSO4", MySqlDbType.Double).Value = PRIX_CONSO4
        command.Parameters.Add("@VISIBLE", MySqlDbType.Int64).Value = VISIBLE
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = TYPE

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


    Public Function insertFicheTechnique(ByVal LIBELLE_FICHE As String, ByVal NOM_ARTICLE As String, ByVal PRIX_VENTE As Double, ByVal CODE_FICHE_TECHNIQUE As String, ByVal CODE_ARTICLE_FICHE As String, ByVal QUANTITE_ARTICLE_FICHE As Integer, ByVal CTR As Double, ByVal PV As Double, ByVal CRPPP As Double, ByVal PMI As Double, ByVal CM As Integer, ByVal CRPPV As Double, ByVal MB As Double, ByVal TM As Double, ByVal DESCRIPTION As String, ByVal DIVERS_POURCENTAGE As Integer, ByVal DIVERS_MONTANT As Double) As Boolean

        Dim insertQuery As String = "INSERT INTO `fiche_technique`(`LIBELLE_FICHE`,`NOM_ARTICLE`, `PRIX_VENTE`, `CODE_FICHE_TECHNIQUE`,`CODE_ARTICLE`,`QUANTITE`, `CTR`, `PV`, `CRPPP`, `PMI`, `CM`, `CRPPV`, `MB`, `TM`, `DESCRIPTION`,`DIVERS_POURCENTAGE`,`DIVERS_MONTANT` ) VALUES (@value1, @value2,@value3,@value4,@value5,@value6, @value7, @value8, @value9, @value10, @value11, @value12, @value13, @value14, @value15, @value16, @value17)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = LIBELLE_FICHE
        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = NOM_ARTICLE
        command.Parameters.Add("@value3", MySqlDbType.Double).Value = PRIX_VENTE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE
        command.Parameters.Add("@value5", MySqlDbType.VarChar).Value = CODE_ARTICLE_FICHE
        command.Parameters.Add("@value6", MySqlDbType.Int64).Value = QUANTITE_ARTICLE_FICHE

        command.Parameters.Add("@value7", MySqlDbType.Double).Value = CTR
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PV
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = CRPPP
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = PMI
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = CM
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = CRPPV
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MB
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = TM

        command.Parameters.Add("@value16", MySqlDbType.Int64).Value = DIVERS_POURCENTAGE
        command.Parameters.Add("@value17", MySqlDbType.Double).Value = DIVERS_MONTANT

        command.Parameters.Add("@value15", MySqlDbType.String).Value = DESCRIPTION

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

    Public Function updateFicheTechnique(ByVal LIBELLE_FICHE As String, ByVal NOM_ARTICLE As String, ByVal PRIX_VENTE As Double, ByVal CODE_FICHE_TECHNIQUE As String, ByVal CODE_ARTICLE_FICHE As String, ByVal QUANTITE_ARTICLE_FICHE As Integer, ByVal CTR As Double, ByVal PV As Double, ByVal CRPPP As Double, ByVal PMI As Double, ByVal CM As Integer, ByVal CRPPV As Double, ByVal MB As Double, ByVal TM As Double, ByVal DATE_PREPARATION As Date, ByVal DIVERS_POURCENTAGE As Integer, ByVal DIVERS_MONTANT As Double) As Boolean

        Dim insertQuery As String = "UPDATE `fiche_technique` SET `NOM_ARTICLE`=@value2, `CODE_ARTICLE`=@value3,`QUANTITE`=@value4,`PRIX_VENTE`=@value5,`CTR`=@value7,`PV`=@value8,
            `CRPPP`=@value9,`PMI`=@value10,`CM`=@value11,`CRPPV`=@value12,`MB`=@value13,`TM`=@value14, `DATE_PREPARATION`=@DATE_PREPARATION, DIVERS_POURCENTAGE=@DIVERS_POURCENTAGE, DIVERS_MONTANT=@DIVERS_MONTANT WHERE CODE_FICHE_TECHNIQUE=@CODE_FICHE_TECHNIQUE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = NOM_ARTICLE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = CODE_ARTICLE_FICHE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = QUANTITE_ARTICLE_FICHE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = PRIX_VENTE

        command.Parameters.Add("@value7", MySqlDbType.Double).Value = CTR
        command.Parameters.Add("@value8", MySqlDbType.Double).Value = PV
        command.Parameters.Add("@value9", MySqlDbType.Double).Value = CRPPP
        command.Parameters.Add("@value10", MySqlDbType.Double).Value = PMI
        command.Parameters.Add("@value11", MySqlDbType.Double).Value = CM
        command.Parameters.Add("@value12", MySqlDbType.Double).Value = CRPPV
        command.Parameters.Add("@value13", MySqlDbType.Double).Value = MB
        command.Parameters.Add("@value14", MySqlDbType.Double).Value = TM
        command.Parameters.Add("@DIVERS_POURCENTAGE", MySqlDbType.Int64).Value = DIVERS_POURCENTAGE
        command.Parameters.Add("@DIVERS_MONTANT", MySqlDbType.Double).Value = DIVERS_MONTANT
        command.Parameters.Add("@DATE_PREPARATION", MySqlDbType.Date).Value = DATE_PREPARATION

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

    Public Function insertLigneFicheTechnique(ByVal CODE_FICHE_TECHNIQUE As String, ByVal CODE_ARTICLE As String, ByVal UNITE_COMPTAGE As String, ByVal QUANTITE As Double, ByVal PRIX_ACHAT As Double, ByVal PRIX_REVIENT As Double, ByVal QUANTITE_PAR_PORTION As Double) As Boolean

        Dim insertQuery As String = "INSERT INTO `fiche_technique_ligne`(`CODE_FICHE_TECHNIQUE`, `CODE_ARTICLE`, `UNITE_COMPTAGE`, `QUANTITE`, `PRIX_ACHAT`, `PRIX_REVIENT`,`QUANTITE_PAR_PORTION`) VALUES (@CODE_FICHE_TECHNIQUE, @CODE_ARTICLE, @UNITE_COMPTAGE, @QUANTITE, @PRIX_ACHAT, @PRIX_REVIENT, @QUANTITE_PAR_PORTION)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE
        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@UNITE_COMPTAGE", MySqlDbType.VarChar).Value = UNITE_COMPTAGE
        command.Parameters.Add("@QUANTITE", MySqlDbType.Double).Value = QUANTITE
        command.Parameters.Add("@PRIX_ACHAT", MySqlDbType.Double).Value = PRIX_ACHAT
        command.Parameters.Add("@PRIX_REVIENT", MySqlDbType.Double).Value = PRIX_REVIENT
        command.Parameters.Add("@QUANTITE_PAR_PORTION", MySqlDbType.Double).Value = QUANTITE_PAR_PORTION

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

    'LIste des fiches techniques

    Public Function ListeDesFichesTechnique() As DataTable

        'Dim existQuery As String = "SELECT `CODE_FICHE_TECHNIQUE` As 'CODE FICHE TECHNIQUE',`NOM_ARTICLE` AS 'ARTICLE', `QUANTITE` AS 'NOMBRE DE PORTION', `PRIX_VENTE` AS 'PRIX DE VENTE', `CTR`, `PV`, `CRPPP`, `PMI`, `CM`, `CRPPV`, `MB`, `TM` FROM `fiche_technique`"

        Dim existQuery As String = "SELECT CODE_FICHE_TECHNIQUE As 'CODE FICHE', `LIBELLE_FICHE` As `LIBELLE FICHE` ,`NOM_ARTICLE` AS 'ARTICLE', 
    `QUANTITE` AS 'NOMBRE DE PORTION', `PRIX_VENTE` AS 'PRIX DE VENTE', `CM` AS 'COEF DE MARGE', `MB` as 'MARGE BRUTE' FROM `fiche_technique`"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            'GlobalVariable.connect.closeConnection()
        End If

        Return table

    End Function

    Public Function elementsDuneFicheTechnique(ByVal CODE_FICHE_TECHNIQUE As String) As DataTable

        Dim existQuery As String = "SELECT fiche_technique_ligne.CODE_ARTICLE AS 'CODE ARTICLE', DESIGNATION_FR As 'DESIGNATION', fiche_technique_ligne.UNITE_COMPTAGE as 'UNITE COMPTAGE', fiche_technique_ligne.QUANTITE As 'QUANTITE UTILISE', fiche_technique_ligne.QUANTITE_PAR_PORTION AS 'QTE / PORTION', fiche_technique_ligne.PRIX_REVIENT AS 'COUT DE REVIENT' , fiche_technique_ligne.PRIX_ACHAT AS 'COUT ACHAT' 
            FROM `fiche_technique_ligne`,`article`  
            WHERE CODE_FICHE_TECHNIQUE=@CODE_FICHE_TECHNIQUE 
            AND fiche_technique_ligne.CODE_ARTICLE=article.CODE_ARTICLE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function elementsDuneFicheTechniquePourPreparation(ByVal CODE_FICHE_TECHNIQUE As String) As DataTable

        Dim existQuery As String = "SELECT fiche_technique_ligne.CODE_ARTICLE AS 'CODE ARTICLE', DESIGNATION_FR As 'DESIGNATION', fiche_technique_ligne.UNITE_COMPTAGE as 'UNITE', fiche_technique_ligne.QUANTITE As 'QTE UTILISE', fiche_technique_ligne.QUANTITE_PAR_PORTION AS 'QTE / PORTION', fiche_technique_ligne.PRIX_REVIENT AS 'COUT DE REVIENT' , fiche_technique_ligne.PRIX_ACHAT AS 'COUT ACHAT' 
            FROM `fiche_technique_ligne`,`article`  
            WHERE CODE_FICHE_TECHNIQUE=@CODE_FICHE_TECHNIQUE 
            AND fiche_technique_ligne.CODE_ARTICLE=article.CODE_ARTICLE"

        'PRIX ACHAT COUT UNITAIRE
        'PRIX PRIX REVIENT COUT TOTAL

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)
        command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function ficheDeStockDunProduitQuelConque(ByVal CODE_ARTICLE As String) As DataTable

        Dim existQuery As String = "SELECT `DATE_MOUVEMENT`,`STOCK_FIN_DU_MOIS`, `QUANTITE_ENTREE`, `QUANTITE_SORTIE`, article.QUANTITE, `SEUIL_REAPPROVISIONNEMENT` 
            , PRIX_ACHAT_HT FROM mouvement_stock, article WHERE article.CODE_ARTICLE=mouvement_stock.CODE_ARTICLE AND article.CODE_ARTICLE=@CODE_ARTICLE"

        Dim command As New MySqlCommand(existQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Return table

    End Function

    Public Function ficheTechniqueArticlePrepare(ByVal CODE_ARTILCE As String, ByVal NOM_ARTICLE As String, ByVal CODE_FICHE_TECHNIQUE As String, ByVal QUANTITE_PREPARE As Double, ByVal DATE_PREPARATION As Date, ByVal PRIX_VENTE As Double, ByVal tableName As String) As Boolean

        Dim insertQuery As String = "INSERT INTO " & tableName & " (`CODE_ARTICLE`, `NOM_ARTICLE`, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE`, `DATE_PREPARATION`, `PRIX_VENTE`) VALUES (@value2,@value3,@value4,@value5,@value6,@value7)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_ARTILCE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = NOM_ARTICLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = QUANTITE_PREPARE
        command.Parameters.Add("@value6", MySqlDbType.Date).Value = DATE_PREPARATION
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = PRIX_VENTE

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

    Public Function preparationDePlusieursPlats(ByVal CODE_ARTILCE As String, ByVal NOM_ARTICLE As String, ByVal CODE_FICHE_TECHNIQUE As String, ByVal QUANTITE_PREPARE As Double, ByVal DATE_PREPARATION As Date, ByVal PRIX_VENTE As Double) As Boolean

        Dim insertQuery As String = "INSERT INTO `preparation_plusieurs_plat`(`CODE_ARTICLE`, `NOM_ARTICLE`, `QUANTITE_PREPAREE`, `DATE_PREPARATION`, `CODE_FICHE_TECHNIQUE`, `PRIX_VENTE`) VALUES (@value2,@value3,@value4,@value5,@value6, @value7)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_ARTILCE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = NOM_ARTICLE
        command.Parameters.Add("@value4", MySqlDbType.Double).Value = QUANTITE_PREPARE
        command.Parameters.Add("@value5", MySqlDbType.Date).Value = DATE_PREPARATION
        command.Parameters.Add("@value6", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE
        command.Parameters.Add("@value7", MySqlDbType.Double).Value = PRIX_VENTE

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

    Public Function commandeCuisine(ByVal CODE_ARTILCE As String, ByVal NOM_ARTICLE As String, ByVal CODE_FICHE_TECHNIQUE As String, ByVal QUANTITE_PREPARE As Double, ByVal DATE_PREPARATION As Date, ByVal RANDOM_CODE As String, ByVal PRIX_VENTE As Double) As Boolean

        Dim insertQuery As String = "INSERT INTO `commande_cuisine`(`CODE_ARTICLE`, `NOM_ARTICLE`, `CODE_FICHE_TECHNIQUE`, `QUANTITE_PREPARE`, `DATE_PREPARATION`,`RANDOM_CODE`, `PRIX_VENTE`) VALUES (@value2,@value3,@value4,@value5,@value6, @value7, @PRIX_VENTE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@value2", MySqlDbType.VarChar).Value = CODE_ARTILCE
        command.Parameters.Add("@value3", MySqlDbType.VarChar).Value = NOM_ARTICLE
        command.Parameters.Add("@value4", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE
        command.Parameters.Add("@value5", MySqlDbType.Double).Value = QUANTITE_PREPARE
        command.Parameters.Add("@PRIX_VENTE", MySqlDbType.Double).Value = PRIX_VENTE
        command.Parameters.Add("@value6", MySqlDbType.Date).Value = DATE_PREPARATION
        command.Parameters.Add("@value7", MySqlDbType.String).Value = RANDOM_CODE

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

    Public Function meneDuJour(ByVal CODE_MENU As String, ByVal CODE_FICHE_TECHNIQUE As String, ByVal LIBELLE_FICHE As String, ByVal DATE_DU_JOUR As Date) As Boolean

        Dim insertQuery As String = "INSERT INTO `menu_du_jour`(`CODE_MENU`, `CODE_FICHE_TECHNIQUE`, `LIBELLE_FICHE`, `DATE_DU_JOUR`) VALUES (@CODE_MENU,@CODE_FICHE_TECHNIQUE,@LIBELLE_FICHE,@DATE_DU_JOUR)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_MENU", MySqlDbType.VarChar).Value = CODE_MENU
        command.Parameters.Add("@CODE_FICHE_TECHNIQUE", MySqlDbType.VarChar).Value = CODE_FICHE_TECHNIQUE
        command.Parameters.Add("@LIBELLE_FICHE", MySqlDbType.VarChar).Value = LIBELLE_FICHE
        command.Parameters.Add("@DATE_DU_JOUR", MySqlDbType.Date).Value = DATE_DU_JOUR

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

    'GESTION DES COMMANDES DE LA CUISINE
    Public Function updateQuantite(ByVal CODE_ARTICLE As String, ByVal QUANTITE As Double) As Boolean

        Dim insertQuery As String = "UPDATE `article` SET `QUANTITE`=@QUANTITE WHERE CODE_ARTICLE=@CODE_ARTICLE AND CODE_AGENCE=@CODE_AGENCE"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_ARTICLE", MySqlDbType.VarChar).Value = CODE_ARTICLE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command.Parameters.Add("@QUANTITE", MySqlDbType.Double).Value = QUANTITE

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
