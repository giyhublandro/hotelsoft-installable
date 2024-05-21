Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Xml

Imports iTextSharp.text.pdf
Imports iTextSharp.text

Imports Excel = Microsoft.Office.Interop.Excel 'Before you add this reference to your project,
' you need to install Microsoft Office and find last version of this file.
Imports Microsoft.Office.Interop

Imports System.Data.Odbc

Public Class DataBaseManipulation

    'Dim connection As MySqlConnection = New MySqlConnection("datasource=localhost;port=3306;password=;username=root;database=barcleshsoftdb;Convert Zero Datetime=True")

    'Normal MYSQL
    Dim connection As MySqlConnection = New MySqlConnection("server=192.168.100.72,192.168.100.51,127.0.0.1;port=3306;uid=root;pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")

    'Normal ODBCMYSQL

    Dim connectionStringMysql As String = "BarclesHSotf Mysql;uid=root"
    Dim connectionStringAccess As String = "Dsn=BarclesHsoft Access;dbq=C:\Users\hotelsoft\Documents\Visual Studio 2017\Projets\BarclesHSoft\db\barcleshsoftdb.mdb;driverid=25;fil=MS Access;maxbuffersize=2048;pagetimeout=5;uid=admin"

    Dim odbcConnection As New Odbc.OdbcConnection("BarclesHSotf Mysql;uid=root")

    'ACCESS
    'Dim AccessConnection As New Odbc.OdbcConnection("Dsn=BarclesHsoft Access")

    'WORKING PERFECTLY FOR RECEPTION AND BAR RESTAURANT
    ' Dim connection As MySqlConnection = New MySqlConnection("server=192.168.100.72, 192.168.100.51,127.0.0.1 ;port=3306; uid=restaurant; pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")

    'Dim SERVER As String = "127.0.0.1"
    'Dim SERVER As String = connectionInformation.Rows(0)("SERVER")
    'Dim PORT As String = "3306"
    'Dim PORT As String = connectionInformation.Rows(0)("PORT")
    'Dim UID As String = "root"
    'Dim UID As String = connectionInformation.Rows(0)("UID")
    'Dim PASSWORD As String = ""
    'Dim PASSWORD As String = connectionInformation.Rows(0)("PASSWORD")
    'Dim DATABASE As String = "barcleshsoftdb"
    'Dim DATABASE As String = connectionInformation.Rows(0)("DATABASE_NAME")

    'Dim connection As MySqlConnection = New MySqlConnection("server=" & SERVER & ";port=" & PORT & ";paswword=" & PASSWORD & ";uid=" & UID & ";database= " & DATABASE & " ;Convert Zero Datetime=True")

    'Dim connection As MySqlConnection = New MySqlConnection("server=localhost;port=3306;password=;username=root;database=barcleshsoftdb;Convert Zero Datetime=True")

    'Working for restaurant
    'Dim connection As MySqlConnection = New MySqlConnection("server=192.168.100.51;port=3306;uid=restaurant;pwd=;database=barcleshsoftdb;Convert Zero Datetime=True")

    'get the connection

    'Connection via ODBC

    Public ReadOnly Property odbcgetConnection As Odbc.OdbcConnection

        Get

            If GlobalVariable.databaseType = "ODBC" Then
                'odbcConnection = New Odbc.OdbcConnection(connectionStringMysql)
                odbcConnection = New Odbc.OdbcConnection("BarclesHSotf Mysql;uid=root")
            ElseIf GlobalVariable.databaseType = "ACCESS" Then
                odbcConnection = New Odbc.OdbcConnection(connectionStringAccess)
            End If

            Return odbcConnection

        End Get

    End Property

    'Connection directe à MYSQL
    Public ReadOnly Property getConnection As MySqlConnection

        Get
            Return connection
        End Get

    End Property

    'open the connection
    'Connection directe à MYSQL via ODBC
    Sub openConnection()
        'Connection directe à MYSQL
        If connection.State = ConnectionState.Closed Then
            Try
                connection.Open()
            Catch ex As Exception
                MessageBox.Show("Erreure lors de l'ouverture", "Erreur lors de la fermeture", MessageBoxButtons.OKCancel)
            End Try
        End If

    End Sub

    'Connection via ODBC
    Sub odbcopenConnection()

        If odbcConnection.State = ConnectionState.Closed Then
            Try
                odbcConnection.Open()
            Catch ex As Exception
                MessageBox.Show("Erreure lors de l'ouverture avec odbc", "Erreur lors de la fermeture", MessageBoxButtons.OKCancel)
            End Try
        End If

    End Sub

    'Close the connection
    Sub odbccloseConnection()

        If odbcConnection.State = ConnectionState.Open Then
            Try
                odbcConnection.Close()
            Catch ex As Exception
                MessageBox.Show("Erreure lors de l'ouverture", "Erreur lors de la fermeture", MessageBoxButtons.OKCancel)
            End Try
        End If

    End Sub

    Sub closeConnection()

        If connection.State = ConnectionState.Open Then
            Try
                connection.Close()
            Catch ex As Exception
                MessageBox.Show("Erreure lors de l'ouverture", "Erreur lors de l'ouverture", MessageBoxButtons.OKCancel)
            End Try
        End If

    End Sub

    Public Shared Function tables() As DataTable

        Dim nombreDeTable As Integer = 110
        Dim tailleDuTableau As Integer = nombreDeTable

        'On crée une structure de tableau
        Dim tableListe(tailleDuTableau) As String

        tableListe(0) = "agence"
        tableListe(1) = "article"
        tableListe(2) = "banque"
        tableListe(3) = "banque_transaction"
        tableListe(4) = "bordereaux"
        tableListe(5) = "bordereau_ligne_annuler"
        tableListe(6) = "bordereau_ligne_temp"
        tableListe(7) = "cahier_consigne"
        tableListe(8) = "cahier_consigne_ligne"
        tableListe(9) = "caisse"
        tableListe(10) = "categorie_article"
        tableListe(11) = "categorie_client"
        tableListe(12) = "category_hotel_taxe_sejour_collectee"
        tableListe(13) = "chambre"
        tableListe(14) = "client"
        tableListe(15) = "cloture"
        tableListe(16) = "cochambrier"
        tableListe(17) = "commande_cuisine"
        tableListe(18) = "compte"
        tableListe(19) = "demande_intervention"
        tableListe(20) = "depense_famille"
        tableListe(21) = "disponibilite_tarif_specifique_periodique"
        tableListe(22) = "dossier_comptable"
        tableListe(23) = "electronic_lock_zeno"
        tableListe(24) = "entreprise"
        tableListe(25) = "evenement"
        tableListe(26) = "facture"
        tableListe(27) = "famille"
        tableListe(28) = "famille_et_sous_famille_panne"
        tableListe(29) = "fiche_technique"
        tableListe(30) = "fiche_technique_article_prepare"
        tableListe(31) = "fiche_technique_ligne"
        tableListe(32) = "forfait_salle"
        tableListe(33) = "fournisseur"
        tableListe(34) = "gratuitee_de_resa"
        tableListe(35) = "groupe_article"
        tableListe(36) = "intervention"
        tableListe(37) = "journal"
        tableListe(38) = "licence"
        tableListe(39) = "ligne_bordereaux"
        tableListe(40) = "ligne_facture"
        tableListe(41) = "caution"
        tableListe(42) = "ligne_facture_bloc_note"
        tableListe(43) = "ligne_facture_gratuite"
        tableListe(44) = "ligne_facture_pm"
        tableListe(45) = "ligne_facture_temp"
        tableListe(46) = "ligne_intervention"
        tableListe(47) = "lot"
        tableListe(48) = "lot_article_magasin"
        tableListe(49) = "magasin"
        tableListe(50) = "main_courante"
        tableListe(51) = "main_courante_autres"
        tableListe(52) = "main_courante_generale"
        tableListe(53) = "main_courante_journaliere"
        tableListe(54) = "menu_du_jour"
        tableListe(55) = "mode_reglement"
        tableListe(56) = "monnaie"
        tableListe(57) = "motif_hors_service"
        tableListe(58) = "mouchards"
        tableListe(59) = "mouvement_comptable"
        tableListe(60) = "mouvement_stock"
        tableListe(61) = "movement_stock_temp"
        tableListe(62) = "mvt_compte"
        tableListe(63) = "nationalite"
        tableListe(64) = "navette"
        tableListe(65) = "nettoyage"
        tableListe(66) = "notification"
        tableListe(67) = "objet__perdu_trouve"
        tableListe(68) = "occupation_chambre"
        tableListe(69) = "ville"
        'tableListe(69) = "papier_entete"
        tableListe(70) = "pays"
        tableListe(71) = "personnel"
        tableListe(72) = "petite_caisse"
        tableListe(73) = "petite_caisse_ligne"
        tableListe(74) = "petite_caisse_ligne_synthese"
        tableListe(75) = "planning"
        tableListe(76) = "planning_hebdomadaire"
        tableListe(77) = "plan_comptable"
        tableListe(78) = "prefernces_du_client"
        tableListe(79) = "print_facture_reglement_temp"
        tableListe(80) = "prise_en_charge_resa"
        tableListe(81) = "production_cuisine"
        tableListe(82) = "reglement"
        tableListe(83) = "regroupement_depenses"
        tableListe(84) = "reservation"
        tableListe(85) = "reserve_conf"
        tableListe(86) = "reserve_temp"
        tableListe(87) = "resume_vente_journaliere"
        'tableListe(88) = "societe"
        tableListe(88) = "utilisateur_magazin"
        tableListe(89) = "source_reservation"
        tableListe(90) = "sous_categorie_objets_perdus_retrouves"
        tableListe(91) = "sous_famille"
        tableListe(92) = "sous_sous_famille"
        tableListe(93) = "statistiques"
        tableListe(94) = "suivi_des_encodages"
        tableListe(95) = "suivi_des_reservations"
        tableListe(96) = "tarif"
        tableListe(97) = "tarification_dynamique"
        tableListe(98) = "tarif_client"
        tableListe(99) = "tarif_prix"
        tableListe(100) = "taxe_sejour_collectee"
        tableListe(101) = "transfert_recette"
        tableListe(102) = "transfert_recette_coupures"
        tableListe(103) = "type_chambre"
        tableListe(104) = "type_personnel"
        tableListe(105) = "unite_comptage"
        tableListe(106) = "utilisateurs"
        tableListe(107) = "utilisateur_acces"
        tableListe(108) = "utilisateur_acces_profil"
        tableListe(109) = "utilisateur_caisse"

        '1- CREATTION DU DATA SET
        Dim ds As New DataSet()

        For i = 0 To nombreDeTable - 1

            Dim dt As DataTable = Functions.allTableFields(tableListe(i))
            ds.Tables.Add(dt)

        Next

        createExcelFile(ds)

        'newCreateExcelFile(ds)



    End Function

    Private Sub x()

        '2- RETRIEVE TABLES OF DATA SET

        Dim ds As DataSet = New DataSet()

        Dim collection As DataTableCollection = ds.Tables

        'For i As Integer = 0 To collection.Count - 1

        ' Get table.
        'Dim table As DataTable = collection(i)
        'Console.WriteLine("{0}: {1}", i, table.TableName)

        'Next



    End Sub

    Private Shared Sub newCreateExcelFile(ByVal ds As DataSet)

        MessageBox.Show("Hello")

        Dim nomDuDossierRapport As String = "HSDB"

        Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.AddDays(-1).ToString("ddMMyy")

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)

        Dim titreFichier As String = ""
        Dim fichier As String = ""
        fichier = filePathAndDirectory & "\" & titreFichier & ".xlsx"

        Dim xlApp As Excel.Application
        xlApp = New Excel.Application

        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets(1)
        xlWorkSheet.Name = "test"
        xlWorkSheet.Cells(1, 1) = "Sheet 1 content"

        xlWorkBook.SaveAs("C:\Users\kamde\Desktop\testing.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
        Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        xlWorkBook.Close(True, misValue, misValue)
        xlApp.Quit()

        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)

        xlApp.DisplayAlerts = False
        Dim filePath As String = "C:\Users\kamde\Desktop\testing.xls"
        xlWorkBook = xlApp.Workbooks.Open(filePath, 0, False, 5, "xlsx", "", False, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", True, False, 0, True, False, False)

        Dim worksheets As Excel.Sheets = xlWorkBook.Worksheets
        Dim xlNewSheet = DirectCast(worksheets.Add(worksheets(1), Type.Missing, Type.Missing, Type.Missing), Excel.Worksheet)
        xlNewSheet.Name = "newsheet"
        xlNewSheet.Cells(1, 1) = "New sheet content"

        xlNewSheet = xlWorkBook.Sheets(1)
        xlNewSheet.Select()

        xlWorkBook.Save()
        xlWorkBook.Close()

        releaseObject(xlNewSheet)
        releaseObject(worksheets)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)

        MessageBox.Show("Excel file created , you can find the file d:\csharp-Excel.xls")

    End Sub

    Private Shared Sub createExcelFile(ByVal ds As DataSet)

        Dim nomDuDossierRapport As String = "HSDB"

        Dim filePathAndDirectory As String = GlobalVariable.AgenceActuelle.Rows(0)("CHEMIN_SAUVEGARDE_AUTO") & "\" & nomDuDossierRapport & "\" & GlobalVariable.DateDeTravail.AddDays(-1).ToString("ddMMyy")

        My.Computer.FileSystem.CreateDirectory(filePathAndDirectory)


        Dim sfd As FolderBrowserDialog = New FolderBrowserDialog

        Dim xlApp As Excel.Application
        xlApp = New Excel.Application

        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        If xlApp Is Nothing Then
            MessageBox.Show("Bien vouloir installer Excel !!")
            Return
        End If

        xlWorkBook = xlApp.Workbooks.Add(misValue)

        xlWorkSheet = xlWorkBook.Sheets(1)
        xlWorkSheet.Name = "agence"

        Dim dt As System.Data.DataTable = ds.Tables(0)
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            xlWorkSheet.Cells(1, colIndex) = dc.ColumnName
        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                xlWorkSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next

        Dim titreFichier As String = "barcleshsoftdb"

        Dim fichier As String = filePathAndDirectory & "\" & titreFichier & ".xls"

        xlWorkSheet.Columns.AutoFit()

        xlWorkSheet.SaveAs(fichier)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        '------------------------------------

        For i = 1 To ds.Tables.Count - 1

            Dim xlApp_ As Excel.Application
            xlApp_ = New Excel.Application

            xlApp_.DisplayAlerts = False
            Dim filePath As String = fichier
            xlWorkBook = xlApp_.Workbooks.Open(filePath, 0, False, 5, "", "", False, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", True, False, 0, True, False, False)

            Dim worksheets As Excel.Sheets = xlWorkBook.Worksheets
            Dim xlNewSheet = DirectCast(worksheets.Add(worksheets(1), Type.Missing, Type.Missing, Type.Missing), Excel.Worksheet)

            '---------------- SHEET NAME --------------------

            If i = 1 Then
                xlNewSheet.Name = "article"
            ElseIf i = 2 Then
                xlNewSheet.Name = "banque"
            ElseIf i = 3 Then
                xlNewSheet.Name = "banque_transaction"
            ElseIf i = 4 Then
                xlNewSheet.Name = "bordereaux"
            ElseIf i = 5 Then
                xlNewSheet.Name = "bordereau_ligne_annuler"
            ElseIf i = 6 Then
                xlNewSheet.Name = "bordereau_ligne_temp"
            ElseIf i = 7 Then
                xlNewSheet.Name = "cahier_consigne"
            ElseIf i = 8 Then
                xlNewSheet.Name = "cahier_consigne_ligne"
            ElseIf i = 9 Then
                xlNewSheet.Name = "caisse"
            ElseIf i = 10 Then
                xlNewSheet.Name = "categorie_article"
            ElseIf i = 11 Then
                xlNewSheet.Name = "categorie_client"
            ElseIf i = 12 Then
                xlNewSheet.Name = "categ_taxe_sejour_collectee" '"category_hotel_taxe_sejour_collectee"
            ElseIf i = 13 Then
                xlNewSheet.Name = "chambre"
            ElseIf i = 14 Then
                xlNewSheet.Name = "client"
            ElseIf i = 15 Then
                xlNewSheet.Name = "cloture"
            ElseIf i = 16 Then
                xlNewSheet.Name = "cochambrier"
            ElseIf i = 17 Then
                xlNewSheet.Name = "commande_cuisine"
            ElseIf i = 18 Then
                xlNewSheet.Name = "compte"
            ElseIf i = 19 Then
                xlNewSheet.Name = "demande_intervention"
            ElseIf i = 20 Then
                xlNewSheet.Name = "depense_famille"
            ElseIf i = 21 Then
                xlNewSheet.Name = "dispo_tarif_specie_perio" '"disponibilite_tarif_specifique_periodique"
            ElseIf i = 22 Then
                xlNewSheet.Name = "dossier_comptable"
            ElseIf i = 23 Then
                xlNewSheet.Name = "electronic_lock_zeno"
            ElseIf i = 24 Then
                xlNewSheet.Name = "entreprise"
            ElseIf i = 25 Then
                xlNewSheet.Name = "evenement"
            ElseIf i = 26 Then
                xlNewSheet.Name = "facture"
            ElseIf i = 27 Then
                xlNewSheet.Name = "famille"
            ElseIf i = 28 Then
                xlNewSheet.Name = "famille_et_sous_famille_panne"
            ElseIf i = 29 Then
                xlNewSheet.Name = "fiche_technique"
            ElseIf i = 30 Then
                xlNewSheet.Name = "ft_article_prepare" '"fiche_technique_article_prepare"
            ElseIf i = 31 Then
                xlNewSheet.Name = "fiche_technique_ligne"
            ElseIf i = 32 Then
                xlNewSheet.Name = "forfait_salle"
            ElseIf i = 33 Then
                xlNewSheet.Name = "fournisseur"
            ElseIf i = 34 Then
                xlNewSheet.Name = "gratuitee_de_resa"
            ElseIf i = 35 Then
                xlNewSheet.Name = "groupe_article"
            ElseIf i = 36 Then
                xlNewSheet.Name = "intervention"
            ElseIf i = 37 Then
                xlNewSheet.Name = "journal"
            ElseIf i = 38 Then
                xlNewSheet.Name = "licence"
            ElseIf i = 39 Then
                xlNewSheet.Name = "ligne_bordereaux"
            ElseIf i = 40 Then
                xlNewSheet.Name = "ligne_facture"
            ElseIf i = 41 Then
                xlNewSheet.Name = "caution"
            ElseIf i = 42 Then
                xlNewSheet.Name = "ligne_facture_bloc_note"
            ElseIf i = 43 Then
                xlNewSheet.Name = "ligne_facture_gratuite"
            ElseIf i = 44 Then
                xlNewSheet.Name = "ligne_facture_pm"
            ElseIf i = 45 Then
                xlNewSheet.Name = "ligne_facture_temp"
            ElseIf i = 46 Then
                xlNewSheet.Name = "ligne_intervention"
            ElseIf i = 47 Then
                xlNewSheet.Name = "lot"
            ElseIf i = 48 Then
                xlNewSheet.Name = "lot_article_magasin"
            ElseIf i = 49 Then
                xlNewSheet.Name = "magasin"
            ElseIf i = 50 Then
                xlNewSheet.Name = "main_courante"
            ElseIf i = 51 Then
                xlNewSheet.Name = "main_courante_autres"
            ElseIf i = 52 Then
                xlNewSheet.Name = "main_courante_generale"
            ElseIf i = 53 Then
                xlNewSheet.Name = "main_courante_journaliere"
            ElseIf i = 54 Then
                xlNewSheet.Name = "menu_du_jour"
            ElseIf i = 55 Then
                xlNewSheet.Name = "mode_reglement"
            ElseIf i = 56 Then
                xlNewSheet.Name = "monnaie"
            ElseIf i = 57 Then
                xlNewSheet.Name = "motif_hors_service"
            ElseIf i = 58 Then
                xlNewSheet.Name = "mouchards"
            ElseIf i = 59 Then
                xlNewSheet.Name = "mouvement_comptable"
            ElseIf i = 60 Then
                xlNewSheet.Name = "mouvement_stock"
            ElseIf i = 61 Then
                xlNewSheet.Name = "movement_stock_temp"
            ElseIf i = 62 Then
                xlNewSheet.Name = "mvt_compte"
            ElseIf i = 63 Then
                xlNewSheet.Name = "nationalite"
            ElseIf i = 64 Then
                xlNewSheet.Name = "navette"
            ElseIf i = 65 Then
                xlNewSheet.Name = "nettoyage"
            ElseIf i = 66 Then
                xlNewSheet.Name = "notification"
            ElseIf i = 67 Then
                xlNewSheet.Name = "objet__perdu_trouve"
            ElseIf i = 68 Then
                xlNewSheet.Name = "occupation_chambre"
            ElseIf i = 69 Then
                xlNewSheet.Name = "ville"
                'xlNewSheet.Name 69 = "papier_entete"
            ElseIf i = 70 Then
                xlNewSheet.Name = "pays"
            ElseIf i = 71 Then
                xlNewSheet.Name = "personnel"
            ElseIf i = 72 Then
                xlNewSheet.Name = "petite_caisse"
            ElseIf i = 73 Then
                xlNewSheet.Name = "petite_caisse_ligne"
            ElseIf i = 74 Then
                xlNewSheet.Name = "petite_caisse_ligne_synthese"
            ElseIf i = 75 Then
                xlNewSheet.Name = "planning"
            ElseIf i = 76 Then
                xlNewSheet.Name = "planning_hebdomadaire"
            ElseIf i = 77 Then
                xlNewSheet.Name = "plan_comptable"
            ElseIf i = 78 Then
                xlNewSheet.Name = "prefernces_du_client"
            ElseIf i = 79 Then
                xlNewSheet.Name = "print_facture_reglement_temp"
            ElseIf i = 80 Then
                xlNewSheet.Name = "prise_en_charge_resa"
            ElseIf i = 81 Then
                xlNewSheet.Name = "production_cuisine"
            ElseIf i = 82 Then
                xlNewSheet.Name = "reglement"
            ElseIf i = 83 Then
                xlNewSheet.Name = "regroupement_depenses"
            ElseIf i = 84 Then
                xlNewSheet.Name = "reservation"
            ElseIf i = 85 Then
                xlNewSheet.Name = "reserve_conf"
            ElseIf i = 86 Then
                xlNewSheet.Name = "reserve_temp"
            ElseIf i = 87 Then
                xlNewSheet.Name = "resume_vente_journaliere"
                'xlNewSheet.Name 88 = "societe"
            ElseIf i = 88 Then
                xlNewSheet.Name = "utilisateur_magazin"
            ElseIf i = 89 Then
                xlNewSheet.Name = "source_reservation"
            ElseIf i = 90 Then
                xlNewSheet.Name = "sous_cat_objets_perd_retr" '"sous_categorie_objets_perdus_retrouves"
            ElseIf i = 91 Then
                xlNewSheet.Name = "sous_famille"
            ElseIf i = 92 Then
                xlNewSheet.Name = "sous_sous_famille"
            ElseIf i = 93 Then
                xlNewSheet.Name = "statistiques"
            ElseIf i = 94 Then
                xlNewSheet.Name = "suivi_des_encodages"
            ElseIf i = 95 Then
                xlNewSheet.Name = "suivi_des_reservations"
            ElseIf i = 96 Then
                xlNewSheet.Name = "tarif"
            ElseIf i = 97 Then
                xlNewSheet.Name = "tarification_dynamique"
            ElseIf i = 98 Then
                xlNewSheet.Name = "tarif_client"
            ElseIf i = 99 Then
                xlNewSheet.Name = "tarif_prix"
            ElseIf i = 100 Then
                xlNewSheet.Name = "taxe_sejour_collectee"
            ElseIf i = 101 Then
                xlNewSheet.Name = "transfert_recette"
            ElseIf i = 102 Then
                xlNewSheet.Name = "transfert_recette_coupures"
            ElseIf i = 103 Then
                xlNewSheet.Name = "type_chambre"
            ElseIf i = 104 Then
                xlNewSheet.Name = "type_personnel"
            ElseIf i = 105 Then
                xlNewSheet.Name = "unite_comptage"
            ElseIf i = 106 Then
                xlNewSheet.Name = "utilisateurs"
            ElseIf i = 107 Then
                xlNewSheet.Name = "utilisateur_acces"
            ElseIf i = 108 Then
                xlNewSheet.Name = "utilisateur_acces_profil"
            ElseIf i = 109 Then
                xlNewSheet.Name = "utilisateur_caisse"
            End If

            '------------------------------------------------

            dt = ds.Tables(i)

            colIndex = 0
            rowIndex = 0

            For Each dc In dt.Columns
                colIndex = colIndex + 1
                xlNewSheet.Cells(1, colIndex) = dc.ColumnName
            Next

            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    xlNewSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next

            xlNewSheet = xlWorkBook.Sheets(1)
            xlNewSheet.Select()

            xlNewSheet.Columns.AutoFit()

            xlWorkBook.Save()
            xlWorkBook.Close()

            releaseObject(xlNewSheet)
            releaseObject(worksheets)
            releaseObject(xlWorkBook)
            releaseObject(xlApp_)

        Next

    End Sub

    Private Shared Sub releaseObject(ByVal obj As Object)

        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try

    End Sub
End Class
